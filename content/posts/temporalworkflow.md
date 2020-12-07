---
title: "Checking out Temporal.io - Service Orchestration Platform"
date: 2020-12-02T08:25:04+05:30
draft: true
tags: [Go, Golang, MicroServices,MySQL, Cassandra, Uber, Cadence]
---

## Background

In a typical business Application, there are often requirements for, 
* Batch processing - Often long running Tasks like data import/export, End of day processing etc. These tasks are often scheduled to be executed at pre-defined interval or on occurance of an Event.
*  Asychronous processing - Tasks, often part of business process / workflow, that can be performed asychronously or offloaded.

Such requirements are often fulfilled with custom approaches like batch processing frameworks, ETL Tools or using Queues or specific database features.

I had been following how Uber fulfils these requirements using their [Cadence](https://cadenceworkflow.io/) platform. Cadence (now [Temporal](https://temporal.io))  is a distributed, scalable, durable, and highly available orchestration engine to execute asynchronous long-running business logic in a scalable and resilient way.

Temporal defines [workflow](https://softwareengineeringdaily.com/wp-content/uploads/2020/04/SED1043-Cadence-Workflow-Orchestration.pdf) as any program which,
* goes beyond single request-reply
* has multiple steps tied together with inherent state
* can be short or long lived.
* performs Event processing
* involves infrastructure automation

This is interesting perspective that accomodates various use cases irrespective of architecture style (i.e. Monolith, Microservices) in use. In Temporal, one has to create workflow which in turn consists of one or more activities. Activities are functions containing actions to be taken on each step of the workflow. Temporal transparently preserves all the state associated with workflow and its activities.

Below is System architecture of Temporal, more details [here](https://docs.temporal.io/docs/system-architecture/), 

    {{< figure src="https://docs.temporal.io/assets/images/system-architecture-d064cede0c97fc4a86defdc1c9fd020c.png" title="Temporal Architecture" >}}

Overall, Temporal offers following features, 
 * Workflow implemented as Application code - Basically it allows to implement Workflow as code, just like rest of the codebase of the application. Thus allowing one to concentrate on business logic and reduces complexity about authoring workflow as DSL, JSON etc.
* Retries and Timeouts - Nowadays, quite a few steps in workflow involve remote service invocation and whenever one crosses boundary of the application, it is important to have retries and timeouts in place.
* Reliability - Robustness against failure
* Scalability - Horizontally Scalable 
* Support for SAGAs - If a Workflow calls multiple external/remote services and if one of them fails then, compensation call to other services will have to be made to complete rollback.
* Distributed Cron - Scheduled processing of workflow or steps in workflow.
* Persistent Storage in MySQL, Cassandra among others
* Frontend for tracking and dignostics
* Monitoring using Prometheus or other backends.

It is very easy to get basic "Helloworld" workflow up and running using detailed instructions on setup provided [here](https://docs.temporal.io/docs/go-sdk-tutorial-prerequisites) provided docker desktop or such environment is easily available. Temporal documentation does a great job on this.

To evaluate Temporal further, we will orchestrate below, 
* List of users are imported/received from a file 
* Each of these users are verified/validated by Admin through some Frontend.
* Upon verification, Email  /SMS is sent to user welcoming them 

This may not resemble real world scenario but it will help evaluate below features of Temporal, 
* Signals - Waiting on Events (such as human intervention)
* Retries - Retrying sending email/SMS.



Temporal documentation has reference to Helm charts for deploying temporal in clustered configuration, for organization who is managing own data center it would be interesting to know if it also supports bare metal based deployment in addition to Kubernetes. Will update this post as and when details are available on this.

- [Collection of Temporal related stuff](https://github.com/firdaus/awesome-cadence-temporal-workflow)

Happy Coding !!

---

{{< comments >}}