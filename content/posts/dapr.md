---
title: " Why use Dapr (Distributed Application Runtime)?"
date: 2025-12-02T01:00:00+05:30
draft: true
tags: [Observability, Databases, Monitoring, Microservices,Distributed, Message Queues, Gen AI, Agentic]
---
## Introduction 

If you build software today, you are likely building a distributed system. Whether it's two services talking or a monolith calling a lambda, you have crossed the process boundary.

Distributed applications are software systems that consist of multiple components or modules running on different infrastructure within a network. These components work together to achieve a common goal or provide a service, communicating and coordinating their actions across the network.

Most organizations build distributed applications for two main reasons. First, they have multiple development teams that need to work independently while contributing to a larger system. Second, they require a solution where components built using different programming languages can interact with each other.

Developing distributed applications is challenging because numerous components need to work cohesively. Developers must consider resiliency, observability, security, and scalability across multiple services and runtimes. Furthermore, distributed applications typically don’t operate in isolation; they interact with message brokers, data stores, and external services. Integrating with these resources requires knowledge of specific APIs and SDKs which increases the complexity to build such systems.

To summarize, 

-  **Development** - They are harder to develop and operate. Programming models are often optimized for in-process communication in terms of development and testing. However, Services, in a distributed application, involve remote/out of process calls (e.g. https/gRPC). This makes it difficult to program, debug/test and operate them.
- **Eventual Consistency** - Microservices introduce eventual consistency  because of their laudable insistence on decentralized data management. One is most likely to face issue of "Dual writes" (The dual-write problem occurs when two external systems must be updated in an atomic fashion) in distributed application. 
- **Operability** - Managing multiple independent services have its pros but induce complexity when it comes to frequent deployments and monitoring. As aptly put by Martin fowler [here](https://martinfowler.com/articles/microservice-trade-offs.html#distribution), "Low bar for skill is higher in a microservice environment".
- **Deployment** - Cloud brings in another dimension where companies want to leverage them for their benefits but want to be agnostic or avoid lock-in to a particular vendor. 
  
[Fallacies of Distributed Computing](https://en.wikipedia.org/wiki/Fallacies_of_distributed_computing) articulates all these relevant aspects. 

This post details how [Dapr](https://dapr.io) helps with Distributed Applications Development as well as Agentic workloads.

## Dapr 

[**Dapr**](https://dapr.io), short for Distributed Application Runtime, is a [CNCF graduated open source project](https://www.cncf.io/projects/dapr/). 

Since it's inception in 2019, it has evolved and is battle tested. True to the moto of CNCF,  It provides vendor-neutral approach that decouples the infrastructure from application code so developers can focus on business logic instead of infra. plumbing.  

It uses a sidecar pattern that runs as a separate process alongside the application. It provides multiple building blocks, from service invocation and messaging, jobs, workflow to distributed lock, all of which are common patterns in distributed communication. It makes it seamless to design, develop and run distributed applications from local environment to remote (be it private data center or cloud). 

Key benefits of Dapr are,

- *No more boilerplate*: Store state through the Dapr API and let the platform team pick Redis, Cosmos DB, DynamoDB, etc. Doing pub/sub messaging? Swap RabbitMQ for Kafka via config, not code.
- *Polyglot by design*: Java, .NET, Python, Go, JavaScript; mix and match safely across teams.
- *Built-in Resilience and security* : mTLS, retries, circuit breakers, and consistent observability patterns are part of the runtime “golden path.”
- Designed for [Operations](https://docs.dapr.io/operations/) - Supports integration with observability tools to make it easier to *run* the system.
- sidecars, runtime, components, and configuration can all be managed and deployed easily and securely to match your organization’s needs.

Below is summary of some of the interesting  building blocks.  For complete list, refer [here](https://docs.dapr.io/concepts/building-blocks-concept/).

    {{< figure src="/images/dapr/modular_landscape.png" title="No more boilerplate">}}

### Service invocation

Helps abstract service discovery and perform secure calls between services. 

Typical use cases, 
        - Abstract details (location etc.) needed for invoking services thus making them deployable on various target platforms

### Workflows 

Code-first approach for authoring workflow steps. Diagrid offers workflow code generator which prompts for workflow modelled as diagram (UML, BPMN etc.) and generates boilerplate code that uses Dapr SDK. Check it out [here](https://workflows.diagrid.io/).

Typical use cases, 
- Event-driven data pipelines and ETL jobs
- Payment and transaction processing with compensations
- Customer onboarding and document verification flows
- Automated deployment or model training pipelines
- IoT device provisioning and firmware rollout sequences 

### Pub/sub

Provides a platform-agnostic API to send and receive messages for a service. Avoids hard dependency on specific Messaging system. 

### State Management 

Provides HTTP API to persist and retrieve key-value pairs from State while having pluggable state store. supports automatic client encryption of application state with support for key rotations. As part of state management, it enables developers to use the outbox pattern for achieving a single transaction across a transactional state store and any message broker. Refer [here](https://docs.dapr.io/developing-applications/building-blocks/state-management/howto-outbox/) for more details.

### Jobs

jobs API is an orchestrator for scheduling these future jobs, either at a specific time or for a specific interval.

Typical use cases,
  - Batch processing - Long running processing of large number of transactions. reports generation etc. 

## Demo

For the purpose of the Demo, Lets have hypothetical use case for a Tenant Management System with below services, 

- Tenant Service - Responsible for managing lifecycle of Tenant starting with onboarding. It receives request for new tenant, validates it and invokes notification to intimate tenant itself via e-mail. 

- Notification Service - This services exposes interface to receive requests from notification and then pushes it to pub/sub queue for processing by specific services meant for sending e-mail, SMS and so on. 

Below is depiction of the flow, 

    {{< figure src="/images/dapr/flow-1.png" alt="use case flow" >}}

- Setup Dapr by following instructions [here](https://docs.dapr.io/getting-started/)
  
- Tenant service is developed using Spring Boot while Notification Service uses .NET Core.
  - Below snapshot shows Controller function that calls notification service, 
    ```Java
    
       @PostMapping
    public ResponseEntity<Tenant> createTenant(@Valid @RequestBody Tenant tenant) {
        log.info("POST /tenant - Create tenant request received");
        
        Tenant createdTenant = tenantService.createTenant(tenant);
        log.info("sending notification ");
        //https://devblogs.microsoft.com/java/embracing-virtual-threads-migration-tips-for-java-developers/
        virtualThreadExecutor.submit(() -> {
            SendNotification(tenant);
        });
        return ResponseEntity.status(HttpStatus.CREATED).body(createdTenant);
    }
    
    private void SendNotification(Tenant tenant) { 
        String dapr_url = "http://localhost:" + DAPR_HTTP_PORT + "/notification";
        // Example assuming tenant.getName() and tenant.getEmailId() return strings
        String tenantName = tenant.getName();
        String tenantEmail = tenant.getEmailId();

            // Proper JSON string construction
            String tBody = String.format("{\"Name\":\"%s\",\"Emailid\":\"%s\"}",
            tenantName.replace("\"", "\\\""), // Escape any double quotes within the values
            tenantEmail.replace("\"", "\\\"")); // Escape any double quotes within the values

        // System.out.println("notification service url "+ dapr_url  + "," + tBody);
			HttpRequest request = HttpRequest.newBuilder()
					.POST(HttpRequest.BodyPublishers.ofString(tBody))
					.uri(URI.create(dapr_url))
					.header("Content-Type", "application/json")
				    .header("dapr-app-id", "notification-service")
					.build();

            try {
                // System.out.println("Request URL: " + dapr_url);
                // System.out.println("Request Body: " + tBody);
                HttpResponse<String> response = httpClient.send(request, HttpResponse.BodyHandlers.ofString());
                log.info("tenant notified: "+ tenant.getId());
            } catch (InterruptedException e) {
                log.error("Notification service call interrupted"); // Or something more intellegent
            } catch (IOException e) {
                e.printStackTrace();
                log.error("Notification service call failed - " + e.getStackTrace().toString()); // Or something more intellegent
            }
    }
 
    ```
  - Below snapshot shows Notification service using Dapr .NET SDK to push message, 

    ```C#
    using Dapr.Client;

    const string PUBSUB_NAME = "my-pub-sub";
    const string TOPIC_NAME = "tenants";

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddDaprClient();

    var random = new Random();


    var app = builder.Build();


    var client = app.Services.GetRequiredService<DaprClient>();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
    app.MapOpenApi();
    }

    app.UseHttpsRedirection();


    app.MapPost("/notification",async (CancellationToken token,  Tenant tenant) =>
    {
        
    await client.PublishEventAsync(PUBSUB_NAME, TOPIC_NAME, tenant.Id <= 0 ? random.Next(1,1000) : tenant.Id, token);
    // await Task.Delay(10);

    app.Logger.LogInformation("Sending notification for " + tenant);
    return tenant.ToString();

    });


    ```
 
- Demo uses below  building blocks are used for the demo, 
  - Service invocation 
  - Pub/sub 
  
- Dapr [Multi-app run](https://docs.dapr.io/developing-applications/local-development/multi-app-dapr-run/multi-app-overview/) is very handy for local development lifecycle and same is used for this. Below is dapr configuration used,

  -     {{< figure src="/images/dapr/dapryaml.png" alt="Dapr Multi app config" >}}
 
- Resiliency configuration looks like below, 

    {{< figure src="/images/dapr/resiliency.png" alt="Resiliency configuration" >}}


## All is good but what is the trade-off?

All this abstraction isn't free. The Sidecar pattern introduces an extra "hop" for network traffic 

(Service A --> Sidecar A --> Sidecar B --> Service B).

I ran a quick load test using [k6](https://k6.io) to quantify this overhead on a local development machine.

Load testing criteria is setup as below, 

    {{< figure src="/images/dapr/loadtest-criteria.png" alt="Load test criteria" >}}


The Results:

|Mode|Measure|Latency|
|---|--|--|
|Direct HTTP| P95| ~9.4ms 
|Via Dapr| P95|~13.4ms|
  
**The Verdict**: Dapr, induced sidecar, added approximately 4ms of overhead per request in this scenario.Is it worth it?If you are building a High Frequency Trading platform where microseconds count, Dapr might not be for you. However, for 99% of business applications, trading 4ms of latency for automatic mTLS, distributed tracing, and retry logic is a bargain. You would likely incur more latency implementing those features poorly in your own code.

### Dapr and AI Wave 

Dapr is evolving to meet the needs of Agentic workflows. It recently introduced [Dapr Agents](https://github.com/dapr/dapr-agents) for it. In this, all the building blocks are extended to serve agentic Workload aimed at data crunching, inferencing  with Large Language Models (LLM) and operate them at scale.

Instead of managing complex python scripts for agent coordination, Dapr Agents allows you to:

- Control Loop Management: It handles the "Reason $\rightarrow$ Act" loop reliably using the underlying Dapr Actor model.
- Built-in Guardrails: Leverage Dapr bindings to obfuscate PII (Personally Identifiable Information) before it ever hits the LLM provider.
- Identity: Secure your agents. Since Dapr handles mTLS, your agents can authenticate via SPIFFE, ensuring that "Agent A" is authorized to talk to "Agent B".

## Summary 

Dapr helps with 

- Standardized, vendor-neutral approach, eliminating concerns about lock-in, intellectual property risks, or proprietary restrictions. 
- Organizations gain full flexibility and control over their Distributed/microservices based applications.
- Dapr works both for greenfield projects (built from scratch) and brownfield applications (existing applications being modernized or migrated).  
- A common scenario is migrating a monolithic or traditional service-based app to Kubernetes or another cloud-native infrastructure: Dapr can be introduced to handle inter-service communication, messaging, state, secrets — without rewriting the whole application.  

While this article was meant to provide key aspects, Dapr provides much more than this. Do not forget to go through the documentation.

Happy Coding !!

---

{{< comments >}}