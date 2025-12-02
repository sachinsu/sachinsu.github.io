---
title: "Dapr - Distributed Application Runtime"
date: 2021-09-05T01:00:00+05:30
draft: true
tags: [Observability, Database, MySQL, Monitoring, Honeycomb]
---

## Introduction

key aspects, 
    - Platform agnostic
    - Abstraction over Infrastructure
    - Cloud Agnostic
    - Open source
    - AI Agents (Dapr Agents etc.)


Dapr works both for greenfield projects (built from scratch) and brownfield applications (existing applications being modernized or migrated).  

A common scenario is migrating a monolithic or traditional service-based app to Kubernetes or another cloud-native infrastructure: Dapr can be introduced to handle inter-service communication, messaging, state, secrets — without rewriting the whole application.  

Another scenario: organizations that start with one message broker (e.g. Kafka) but later need to switch to another (e.g. RabbitMQ, SNS, Pulsar) — Dapr’s component model enables swapping backends without touching application logic.  


Distributed applications are software systems that consist of multiple components or modules running on different infrastructure within a network. These components work together to achieve a common goal or provide a service, communicating and coordinating their actions across the network.

Most organizations build distributed applications for two main reasons. First, they have multiple development teams that need to work independently while contributing to a larger system. Second, they require a solution where components built using different programming languages can interact with each other.

Developing distributed applications is challenging because numerous components need to work cohesively. Developers must consider resiliency, observability, security, and scalability across multiple services and runtimes. Furthermore, distributed applications typically don’t operate in isolation; they interact with message brokers, data stores, and external services. Integrating with these resources requires knowledge of specific APIs and SDKs which increases the complexity to build such systems.

 

Dapr, an open source project to expedite distributed application development by providing integrated APIs for communication, state, and workflow.  Dapr’s modular architecture which provides a swappable component model, standardized APIs, and built-in best-practices and patterns for distributed application development, allowing developers to be more efficient building microservices.  It provides platform-agnostic building blocks like service discovery, state management, pub/sub messaging, and observability out of the box. It enables developers to focus on writing business logic without worrying about infrastructure plumbing.

 

The application code that uses the Dapr APIs has no reference to specific client SDKs for the underlying resources. It remains the same when replacing one component for another of the same type. The resource-specific connection is abstracted away and is the responsibility of the Dapr sidecar.

If only some of your applications use Dapr, partial adoption of Dapr’s Pub/Sub API can also bring flexibility in architecture by leveraging different producer or subscriber applications.

 

Using Dapr’s Service Invocation API, developers can easily communicate between different microservices with a standard set of APIs and in-built encryption, metrics, tracing, retries, and backoff handling.

 

 the Dapr Pub/Sub API abstracts the messages that are produced and subscribed in the message broker, the producer and subscriber applications are not impacted by switching to Amazon MSK in this particular use-case

 

Microservices orchestration is the process of managing and coordinating the interactions between multiple microservices in a distributed application architecture. Workflow orchestration involves coordinating the communication, data flow, and execution of various services to ensure that they work together seamlessly. One of the most important features of a workflow system is that the workflow execution is reliable. A workflow should always run to completion even if the workflow engine is temporarily not available. Dapr Workflow offers durable execution of long running workflows where developers author these workflows as code. A large benefit of authoring workflows as code is that they can be unit tested, resulting in a well-documented and maintainable code base.

 

Dapr Workflow provides workflow patterns developers can use to build reliable workflows such as task chaining, fan-out/fan-in, waiting for external events, and asynchronous HTTP response handling

 

 

Benefit of Dapr’s State Management API is that it allows you to replace the state store with an alternative service depending on your business needs without changing the application code.

 

Worldline, Cardlink, GoPay and Santeos are registered trademarks and trade names owned by the Worldline Group. This e-mail and any documents attached are confidential and intended solely for the addressee. It may also be privileged. If you are not the intended recipient of this e-mail, you are not authorized to copy, disclose, use or retain it. Please notify the sender immediately and delete this e-mail (including any attachments) from your systems. As e-mails may be intercepted, amended or lost, they are not secure. Therefore, Worldline’s and its subsidiaries’ liability cannot be triggered for the message content. Although the Worldline Group endeavors to maintain a virus-free network, we do not warrant that this e-mail is virus-free and do not accept liability for any damages, losses or consequences resulting from any transmitted virus if any. The risks are deemed to be accepted by anyone who communicates with Worldline or its subsidiaries by e-mail.
Please consider the environment before printing, sending or forwarding this email.





Happy Coding !!

---

{{< comments >}}