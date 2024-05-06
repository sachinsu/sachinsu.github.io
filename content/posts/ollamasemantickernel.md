---
title: "Using local LLM with Ollama and Semantic Kernel"
date: 2024-05-12T10:25:04+05:30
draft: true
tags: [.net core, llm, ollama, phi-3,semantickernel,gpt]
---


## Introduction 

Artificial Intelligence, especially Large language models (LLMs) are all in high demand. Since OpenAI released ChatGPT, interest has gone up multi-fold. Since 2023, Powerful LLMs can be run on local machines. Local Large Language Models  offer advantages in terms of data privacy and security and can be enriched using enterprise-specific data using Retrieval augmentation generation (RAG).Several tools exist that make it relatively easy to obtain, run and manage such models locally on our machines. Few examples are [Ollama](https://ollama.com/), [Langchain](https://github.com/hwchase17/langchain),  [LocalAI](localai.io). 

[Semantic Kernel](https://github.com/microsoft/semantic-kernel) is an SDK from Microsoft that integrates Large Language Models (LLMs) like OpenAI, Azure OpenAI, and Hugging Face with conventional programming languages like C#, Python, and Java. Semantic Kernel also has plugins that can be chained together to integrate with other tools like Ollama. 

This post describes usage of Ollama to run  model locally, communicate with it using REST API from Semantic kernel SDK. 

## Ollama 

To setup Ollama follow the installation and setup instructions from the Ollama [website](https://ollama.ai). Ollama runs as a service, exposing a REST API on a localhost port.Once installed, you can invoke ollama run <modelname> to talk to this model; the model is downloaded, if not already and cached the first time it's requested.

For the sake of this post, we can use Phi3 model, so run ```ollama run phi3```. This will download phi3 model, if not already, and once done, it will present a prompt. Using this prompt, one can start chatting with the model. 

## Why SemanticKernel ?

As such , Ollama can be integrated with from any application via REST API. Then why go for SemanticKernel SDK?  It provides a simplified integration of AI capabilities into existing applications, lowering the barrier of entry for new developers and supporting the ability to fine-tune models. It supports multiple languages like C#, Python and Java.

## Using Ollama 

Install Ollama by following instructions [here](https://github.com/ollama/ollama/blob/main/README.md#quickstart).Ollama exposes set of REST APIs, check Documentation [here](https://github.com/ollama/ollama/blob/main/docs/api.md). It provides range of functions like get response for Prompt, get Chat response. for Specific operations, it supports streaming and non-streaming response. First step is to download/pull  using ```ollama run phi3```. This will pull, if required, the model and set it up locally. In the end, it will show prompt where user can interact with model. 

Now Ollama API can be easily accessed. Below is the gateway class.

```
public class OllamaApiClient 
{

    private HttpClient _client = new();

	public Configuration Config { get; }

	public interface IResponseStreamer<T>
	{
		void Stream(T stream);
	}
	public class ChatMessage { 

			[JsonPropertyName("role")]
			public string Role { get; set;}
			
			[JsonPropertyName("content")]
			public string Content {get;set;}

	}

	public class ChatResponse
	{
		[JsonPropertyName("model")]
		public string Model { get; set; }

		[JsonPropertyName("created_at")]
		public string CreatedAt { get; set; }

		[JsonPropertyName("response")]
		public string Response { get; set; }


		[JsonPropertyName("message")]
		public ChatMessage? Message { get; set; }


		[JsonPropertyName("messages")]
		public List<ChatMessage> Messages { get; set; }


		[JsonPropertyName("embedding")]
		public List<Double> Embeddings { get; set; }


		[JsonPropertyName("done")]
		public bool Done { get; set; }
	}

	public class ChatRequest { 
		[JsonPropertyName("model")]
		public string Model { get;set;}

		[JsonPropertyName("prompt")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Prompt {get; set;}


		[JsonPropertyName("format")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Format {get; set;}


		[JsonPropertyName("messages")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public IList<ChatMessage> Messages {get; set;}

		[JsonPropertyName("stream")]
		public bool Stream {get; set;} = false;
	}


    public class Configuration
		{
			public Uri Uri { get; set; }

			public string Model { get; set; }
		}


    public OllamaApiClient(string uriString, string defaultModel = "")
        : this(new Uri(uriString), defaultModel)
		{
		}

    public OllamaApiClient(Uri uri, string defaultModel = "")
			: this(new Configuration { Uri = uri, Model = defaultModel })
		{
		}

    public OllamaApiClient(Configuration config)
			: this(new HttpClient() { BaseAddress = config.Uri }, config.Model)
		{
    		Config = config;

			}

    public OllamaApiClient(HttpClient client, string defaultModel = "")
		{
			_client = client ?? throw new ArgumentNullException(nameof(client));
			_client.Timeout = TimeSpan.FromMinutes(10);

			(Config ??=  new Configuration()).Model = defaultModel;
			
		}

	public async Task<ChatResponse> GetEmbeddingsAsync(ChatRequest message, CancellationToken token) {
		message.Model = this.Config.Model;
		return await PostAsync<ChatRequest,ChatResponse>("/api/embeddings",message,token);
	}


	public async Task<ChatResponse> GetResponseForChatAsync(ChatRequest message, CancellationToken token) {
		message.Model = this.Config.Model;
		return await PostAsync<ChatRequest,ChatResponse>("/api/chat",message,token);
	}


	public async Task<ChatResponse> GetResponseForPromptAsync(ChatRequest message, CancellationToken token) {
		message.Model = this.Config.Model;
		return await PostAsync<ChatRequest,ChatResponse>("/api/generate",message,token);
	}

	public async IAsyncEnumerable<ChatResponse> GetStreamForPromptAsync(ChatRequest message, CancellationToken token) {
		message.Model = this.Config.Model;
		message.Stream = true;
		await foreach(ChatResponse resp in  StreamPostAsync<ChatRequest,ChatResponse>("/api/generate",message,token)) {
			yield return resp;
		}
	}

	public async IAsyncEnumerable<ChatResponse> GetStreamForChatAsync(ChatRequest message, CancellationToken token) {
		message.Model = this.Config.Model;
		message.Stream = true;
		await foreach(ChatResponse resp in  StreamPostAsync<ChatRequest,ChatResponse>("/api/chat",message,token)) {
			yield return resp;
		}
	}

    private async Task<TResponse> GetAsync<TResponse>(string endpoint, CancellationToken cancellationToken)
		{
			var response = await _client.GetAsync(endpoint, cancellationToken);
			response.EnsureSuccessStatusCode();

			var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
			return JsonSerializer.Deserialize<TResponse>(responseBody);
		}

    private async Task PostAsync<TRequest>(string endpoint, TRequest request, CancellationToken cancellationToken)
		{
			var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
			var response = await _client.PostAsync(endpoint, content, cancellationToken);
			response.EnsureSuccessStatusCode();
		}



    private async IAsyncEnumerable<TResponse> StreamPostAsync<TRequest,TResponse>(string endpoint, TRequest request, CancellationToken cancellationToken)
		{
			var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
			var response = await _client.PostAsync(endpoint, content, cancellationToken);

 			using Stream stream = await response.Content.ReadAsStreamAsync();

			using StreamReader reader = new StreamReader(stream);

			while (!reader.EndOfStream) {
				var jsonString = await reader.ReadLineAsync(cancellationToken);
				TResponse  result =  JsonSerializer.Deserialize<TResponse>(jsonString);
				yield return result;
			}

			yield break;
	}


    private async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken cancellationToken)
		{
			var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
			var response = await _client.PostAsync(endpoint, content, cancellationToken);
			response.EnsureSuccessStatusCode();

			var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);

			return JsonSerializer.Deserialize<TResponse>(responseBody);
		}
}

```

With this class in place, now it can be integrated with SemanticKernel.

## Integrating with SemanticKernel 

Semantickernel SDK operates on a plug-in system, where developers can use pre-built plugins or create their own. These plugins consist of prompts that the AI model should respond to, as well as functions that can complete specialized tasks. Accordingly, it provides interfaces for (Chat completion)[https://learn.microsoft.com/en-us/dotnet/api/microsoft.semantickernel.chatcompletion.ichatcompletionservice?view=semantic-kernel-dotnet] and [Text Generation](https://learn.microsoft.com/en-us/dotnet/api/microsoft.semantickernel.textgeneration.itextgenerationservice?view=semantic-kernel-dotnet) tasks which can be use
d to integrate with external implementation like Ollama.

Below are implementations of these interfaces that use Ollama API, 

- Text Generation 

```
public class TextGenerationService : ITextGenerationService
{
    
    public string ModelApiEndPoint { get; set; }
    public string ModelName { get; set; }

    public IReadOnlyDictionary<string, object?> Attributes => throw new NotImplementedException();

    public async Task<IReadOnlyList<TextContent>> GetTextContentsAsync(string prompt, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, CancellationToken cancellationToken = default)
    {
          
        var client = new OllamaApiClient(ModelApiEndPoint, ModelName);

        OllamaApiClient.ChatRequest req = new OllamaApiClient.ChatRequest() {
                Model=ModelName,
                Prompt=prompt,
        };

        OllamaApiClient.ChatResponse resp = await client.GetResponseForPromptAsync(req
            , cancellationToken);

        return new List<TextContent>() { new TextContent(resp.Response) };
    }

    public async IAsyncEnumerable<StreamingTextContent> GetStreamingTextContentsAsync(string prompt, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, CancellationToken cancellationToken = default)
    {
            var ollama = new OllamaApiClient(ModelApiEndPoint, ModelName);

            OllamaApiClient.ChatRequest req = new OllamaApiClient.ChatRequest() {
                    Prompt=prompt,
                    Stream=true
            };

            await foreach( OllamaApiClient.ChatResponse resp in ollama.GetStreamForPromptAsync(req, cancellationToken)) {
                    yield return new StreamingTextContent( text:  resp.Response) ;
            } 

    }
}

```

- Chat Completion 

```

public class OllamaChatCompletionService : IChatCompletionService
{
    public string ModelApiEndPoint { get; set; }
    public string ModelName { get; set; }

    public IReadOnlyDictionary<string, object?> Attributes => throw new NotImplementedException();
    
    public async Task<IReadOnlyList<ChatMessageContent>> GetChatMessageContentsAsync(ChatHistory chatHistory, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, CancellationToken cancellationToken = default)
   {


        var client = new OllamaApiClient(ModelApiEndPoint, ModelName);

        OllamaApiClient.ChatRequest req = new OllamaApiClient.ChatRequest() {
                Model=ModelName
        };

        req.Messages = new List<OllamaApiClient.ChatMessage>();

        // iterate though chatHistory Messages
        foreach (var history in chatHistory)
        {
            req.Messages.Add(new OllamaApiClient.ChatMessage{
                Role=history.Role.ToString(),
                Content=history.Content
            });
        }

        OllamaApiClient.ChatResponse resp = await client.GetResponseForChatAsync(req
            , cancellationToken);

        List<ChatMessageContent> content = new();
        content.Add( new(role:resp.Message.Role.Equals("system",StringComparison.InvariantCultureIgnoreCase)?AuthorRole.System:AuthorRole.User,content:resp.Message.Content));

        return content;
    }

    public async IAsyncEnumerable<StreamingChatMessageContent> GetStreamingChatMessageContentsAsync(ChatHistory chatHistory, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, CancellationToken cancellationToken = default)
    {

        var client = new OllamaApiClient(ModelApiEndPoint, ModelName);

        OllamaApiClient.ChatRequest req = new OllamaApiClient.ChatRequest() {
                Model=ModelName
        };

        req.Messages = new List<OllamaApiClient.ChatMessage>();

        // iterate though chatHistory Messages
        foreach (var history in chatHistory)
        {
            req.Messages.Add(new OllamaApiClient.ChatMessage{
                Role=history.Role.ToString(),
                Content=history.Content
            });
        }

        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken token = source.Token;

        await foreach (OllamaApiClient.ChatResponse resp in  client.GetStreamForChatAsync(req,token)) { 
            yield return new(role:resp.Message.Role.Equals("system",StringComparison.InvariantCultureIgnoreCase)?AuthorRole.System:AuthorRole.User,
            content:resp.Message.Content ?? string.Empty); 
        }

     }
}


```

Above implementation is for demonstration purposes only. I am sure further optimization is certainly possible.  

After this, it is time to use it as client of SemanticKernel SDK. Below is the test case for chat completion service, 

```

    [Fact]
    public async void TestChatGenerationviaSK() 
    {
        var ollamachat = ServiceProvider.GetChatCompletionService();


        // semantic kernel builder
        var builder = Kernel.CreateBuilder();
        builder.Services.AddKeyedSingleton<IChatCompletionService>("ollamaChat", ollamachat);
        // builder.Services.AddKeyedSingleton<ITextGenerationService>("ollamaText", ollamaText);
        var kernel = builder.Build();


        // chat generation
        var chatGen = kernel.GetRequiredService<IChatCompletionService>();
        ChatHistory chat = new("You are an AI assistant that helps people find information.");
        chat.AddUserMessage("What is Sixth Sense?");
        var answer = await chatGen.GetChatMessageContentAsync(chat);
        Assert.NotNull(answer);
        Assert.NotEmpty(answer.Content!);
        System.Diagnostics.Debug.WriteLine(answer.Content!);


    }


```

Full Source code of this post is available [here](https://github.com/sachinsu/ollamsmk).


## Summary

Local AI combined with Retrieval Augmented Generation is powerful combination that any one get started with without need for subscriptions while conserving data privacy. Next step in this is to Use RAG for augmenting the results using enterprise/private data. 


Happy Coding !!

## Helpful Links

- [Demystifying Retrieval Augmented Generation with .NET](https://devblogs.microsoft.com/dotnet/demystifying-retrieval-augmented-generation-with-dotnet/)
- [Gemma, ollama and Langchaingo](https://eli.thegreenplace.net/2024/gemma-ollama-and-langchaingo/)