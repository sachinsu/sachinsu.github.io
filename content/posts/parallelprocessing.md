---
title: "Using Asynchronous programming to manage parallel processing "
date: 2024-07-30T10:25:04+05:30
draft: false
---

## Background

There was a requirement to perform series of tasks, involving generation of output files, such that the required throughput is achieved. These tasks involve database read operation, external API invocation and file i/o. Generally, benchmarking showed that executing them in sequential way was not helpful.  What if asynchronous programming be used to perform this task. 

So Lets Start.

## Approach

Lets assume that this typical use case requires,

    - fetching data from database for the purpose of merging placeholders in a Template and perform mail merge 

    - Generate PDF file from mail-merged output of last step (say HTML to PDF)

    - send notification to users via third party API. 

--- 

The requirement is to perform these steps in such a way that 50 or more notifications (with file) are sent per minute. 

For the purpose of simplicity, lets assume,

- Assume that Database read operation and HTML generation basis template, takes upto 2 seconds per iteration 
- We will use [Puppeteer Sharp](https://www.puppeteersharp.com/) library for PDF Generation 
- External API Integration takes up to 2 seconds per call

Since current approach of sequential execution is not helpful, lets try below (both the methods process 5 requests[i.e. generate 5 pdf files] per iteration), 

    - Using  [Task asynchronous programming model](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/task-asynchronous-programming-model)  - This uses Task library to start tasks in parallel and subsequently process them as each completes.   
        
{{< figure src="/images/pl-taskasync.png" title="Using Task Async. Library" >}}


    - Using [Dataflow - Task Parallel Library](https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/dataflow-task-parallel-library)  - This uses Dataflow Library to orchestrate each step in the process and use parallelism for performance. 


{{< figure src="/images/pl-dataflow.png" title="Using DataFlow Library" >}}


--- 

Below is the  Report from Benchmarkdotnet for both the approaches.

{{< figure src="/images/pl-benchmark.png" title="Benchmark Results" >}}


As one can see, using above techniques, It is straightforward to  write asynchronous code that performs parallel execution and achieves better performance compared to sequential alternate approach.

References: 
- [BenchmarkDotNet](https://benchmarkdotnet.org)
- [Introduction to Benchmarking C# Code with Benchmark .NET](https://www.stevejgordon.co.uk/introduction-to-benchmarking-csharp-code-with-benchmark-dot-net)

Happy Coding !!

---

{{< comments >}}