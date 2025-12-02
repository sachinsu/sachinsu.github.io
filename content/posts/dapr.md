---
title: " Why use Dapr (Distributed Application Runtime)?"
date: 2025-12-02T01:00:00+05:30
draft: true
tags: [Observability, Database, MySQL, Monitoring, Microservices,Distributed, Message Queues, Gen AI, Agentic]
---
## Introduction 

Every developer is a developer or consumer of distributed systems, as mentioned by Brendan Burns [here](https://info.microsoft.com/rs/157-GQE-382/images/EN-CNTNT-eBook-DesigningDistributedSystems.pdf). 

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

    {{< figure src="/images/dapr/modular_landscape.png">}}

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
      -     {{< figure src="/images/dapr/tenant-service.png" alt="Tenant service Controller" >}}
  - Below snapshot shows Notification service using Dapr .NET SDK to push message, 
     -   {{< figure src="/images/dapr/notification-service.png" alt="Notification service Controller" >}}
 
- Demo uses below  building blocks are used for the demo, 
  - Service invocation 
  - Pub/sub 
  
- Dapr [Multi-app run](https://docs.dapr.io/developing-applications/local-development/multi-app-dapr-run/multi-app-overview/) is very handy for local development lifecycle and same is used for this. Below is dapr configuration used,

  -     {{< figure src="/images/dapr/dapryaml.png" alt="Dapr Multi app config" >}}
 
- Resiliency configuration looks like below, 

    {{< figure src="/images/dapr/resiliency.png" alt="Resiliency configuration" >}}


## All is good but what is trade-off?

Lets do some load testing to assess impact of sidecar pattern of dapr vis-a-vis direct invocation. We will use [k6](https://k6.io/) to perform  load testing. Note that, below test was conducted on my development laptop with no specific optimizations and modalities.  

- Load testing criteria is setup as below, 

    {{< figure src="/images/dapr/loadtest-criteria.png" alt="Load test criteria" >}}

- Below are the results, 
  - With dapr
    - HTTP
        http_req_duration..............: avg=6.51ms min=510µs med=2.11ms max=1.83s p(90)=3.7ms p(95)=4.89ms
      { expected_response:true }...: avg=6.52ms min=510µs med=2.11ms max=1.83s p(90)=3.7ms p(95)=4.89ms

 
  - Without dapr
    -  HTTP
        http_req_duration..............: avg=9.39ms min=308.09µs med=3.9ms max=2.94s p(90)=8.63ms p(95)=16.3ms
          { expected_response:true }...: avg=9.4ms  min=308.09µs med=3.9ms max=2.94s p(90)=8.63ms p(95)=16.31ms

It seems that dapr results in better throughput than direct. This will have to dealt in detail on why this happens as generally direct communication will not have any overhead associated with sidecar. Let me know your thoughts in comments.

### Gen AI 

Dapr is keeping pace with tech. landscape changes and When it comes to Generative AI use cases and its implementation, it has a  building block named [Dapr Agents](https://github.com/dapr/dapr-agents) for it. In this, all the building blocks are extended to serve agentic Workload aimed at data crunching, inferencing  with Large Language Models (LLM) and operate them at scale.

It excels at below aspects compared to other Agentic frameworks, 
    - Guardrails - Obfuscation of Sensitive data while interacting with LLMs
    - Authentication over MCP (Built-in identity using SPIFEE) 
    - mTLS for securing communication between Agents. 
    - Durable workflows 
    - Event driven ingestion  

## Summary 

Dapr helps with 
- Standardized vendor-neutral approach, eliminating concerns about lock-in, intellectual property risks, or proprietary restrictions. 
- Organizations gain full flexibility and control over their Distributed/microservices based applications.
- Dapr works both for greenfield projects (built from scratch) and brownfield applications (existing applications being modernized or migrated).  
- A common scenario is migrating a monolithic or traditional service-based app to Kubernetes or another cloud-native infrastructure: Dapr can be introduced to handle inter-service communication, messaging, state, secrets — without rewriting the whole application.  

Happy Coding !!

---

{{< comments >}}