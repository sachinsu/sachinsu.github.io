---
title: "Notes on Excellent AI Agent Architecture via A2A/MCP by Jeffrey Richter"
date: 2025-12-01T01:00:00+05:30
draft: true
tags: [Agent-to-Agent,MCP,Anthropic, RAG, Gen AI, Agentic]
---

## Introduction 

This article is more of my notes on excellent Article by Jeffrey Richter on **architecting AI Agents using [Google's Agent-to-Agent (A2A) protocol](https://a2a-protocol.org) and [Anthropic's Model Context Protocol](https://modelcontextprotocol.io/introduction)**. Do read it [here](https://medium.com/@jeffreymrichter/ai-agent-architecture-b864080c4bbc) 

### How AI Models are different

Jeff starts with first principle approach on explaining how Human and AI Models differ from typical Software in terms of precise input and output. He then describes what AI Agent is and its internal Working in terms of  main execution loop (Orchestrator), Need for maintaining conversation history and Agent to MCP interaction to complete the loop. 

Below are the notes, 

- How AI Models differ from Software-centric approach,

  - Both humans and AI Models accept imprecise input such as natural language text, images/video, and audio and attempt to “understand” or “make sense” of it. And, since the imprecise input is subject to interpretation, different humans and AI Models are likely to produce different or imprecise outputs

  - On the other hand, software accepts precise input such as scalar values (Booleans, integers, floats), well-formatted strings (URLs, dates/times, UUIDs, JSON, XML, CSV, etc.), and structures/arrays composed of these. Since the precise input is not subject to interpretation, different software interpret the same input identically.

  - Humans and AI Models typically produce imprecise output while Software produces precise output.

  - a human wants to convert an algorithm in their head (imprecise thoughts) and attempt to output source code in some programming language (precise output). Similarly, an AI Model can be asked via imprecise natural language to produce precise data output

  - Imprecise data is valid input to humans and AI Models, not to software.
  - If humans or AI Models output imprecise data, the output is intended for humans or other AI Models.
  - If humans or AI Models output precise data, the output is intended for humans, AI Models, or software. However, attempting to output precise data may fail and, in this case, passing the imprecise data on is likely to produce unpredictable results.

### AI Agent process flow

    {{< figure
  src="/images/a2a/agent_flow.png"
  alt="A2A process flow"
  caption="A2A process flow"
  class="ma0 w-75"  >}}



  - Each AI Agent specializes in discrete set of skills and likely to rely on other AI agents to complete portion of task. AI Agents accept input requests and reason over the request considering domain-specific knowledge the AI Agent has. This produces an execution plan and then performs actions utilizing various tools at its disposal. 

  - AI Agent is implemented as HTTP Service or can provide user interface and  exposes operations which expect imprecise input and return imprecise output.
  
  - Each AI Agent has a name, description and set of skills (each skill is described as name and description)
  
  - AI models are stateless. So AI Agents must maintain as much conversation history as possible and send it to the AI Model to advance the conversation. Each AI Model documents its context window indicating the maximum size of the conversation it supports. Each message includes 1 or more parts (text, file URI/data, or JSON data).

  - Internally, an AI Agent has a main execution loop referred to as an orchestrator. The orchestrator’s job is to advance the task’s conversation through to completion. Several tools exist to assist developers with building orchestrators such as LangChain, Semantic Kernel, and AutoGen.

  - Processing a new message typically requires the orchestrator to augment the message’s prompt with AI Agent-specific knowledge to improve the quality of the output. This technique is known as Retrieval Augmented Generation (RAG). Specifically, the orchestrator obtains an embedding vector for the user message’s prompt and then does a similarity search against data files, PDFs, etc. to find source content similar to what the user’s prompt is about. The orchestrator embeds this content into the prompt.

  - At this point, orchestrator sends the entire conversation to an AI Model. 
  - AI Model outputs, 
	- an imprecise result which is appended to the task’s conversation.
	- a precise set of specific tool names to call. A tool name either refers to another specialized AI Agent or some software function (usually implemented by an MCP Server)
	- It is the orchestrator’s job to call any tools and calling a software function is what allows an AI Agent to perform actions and be agentic. 

- MCP,
  - One or more MCP Servers must first be registered with Ai Agent. Right now, there is no standard way of achieving this. When AI Agent invokes MCP server, it itself is called MCP Host. 
  - Some MCP Servers are implemented as executable processes that run on the same/local PC as the AI Agent and communicate with them via standard input/output. Other MCP Servers are implemented as HTTP services; the MCP Client communicates with them remotely via HTTP requests to the service’s URL.
  - Each MCP Server exposes to the AI Agent and its orchestrator tools (functions), resources, and prompts.
  - Each MCP implementation exposes list of tools. Each tool has a name, description  and schema (JSON) specifying input required.
  - Orchestrator shares all the tool information with AI Model and Model chooses best tool to call. AI Model may have orchestrator call multiple tools.

  - MCP Server Sampling - An MCP Server might want to use an AI Model for some of its internal work. The MCP protocol accommodates this with a feature called sampling. With sampling, the MCP Server sends a sampling/createMessage message to the AI Agent asking it to use one of its AI Models to do the work. The benefit of this approach is that the MCP Server itself doesn’t need to configure, pay for, or manage API keys/secrets to access its own AI Model. Very few MCP clients support this feature. 
  - MCP Server roots - An AI Agent might want to focus its MCP Servers to a subset of potential resources. for e.g. root path of current project files in VS Code. 

Jeff has covered lot of ground in the article than the above, so please check out the article itself. 


Happy Coding !!

---

{{< comments >}}