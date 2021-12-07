---
title: "Profiling and benchmarking tools for Applications"
date: 2021-12-10T01:00:00+05:30
draft: true
tags: [pyroscope,crank,flame graph, CPU]
---

## Introduction

We develop a piece of software with aim to fulfil specific business requirements in terms of resource usage, throughput etc. Profiling and benchmarking are approaches that developer has to evaluate the same. 

 - Profiling is defined as `aimed at  understanding the behaviour of a program. A profile result might be a table of time taken per function,` as per [this](https://stackoverflow.com/questions/34801622/difference-between-benchmarking-and-profiling) and [this](https://en.wikipedia.org/wiki/Profiling_(computer_programming)))
 - Benchmarking is `measures the time for some whole operation. e.g. I/O operations per second under some workload. So the result is typically a single number, in either seconds or operations per second. Or a data set with results for different parameters, so you can graph it.`. Refer [this](https://en.wikipedia.org/wiki/Benchmark_(computing)) for more information. Also do check [Benchmarking correctly is hard by Julia Evans](https://jvns.ca/blog/2016/07/23/rigorous-benchmarking-in-reasonable-time/).

We will look at couple of tools in this space. 

## Profiling 
todo: pyroscope
[Pyroscope](https://pyroscope.io) is Open source tool for profiling Application or a function within the application. It is cross-platform i.e. programs in variety of languages can be profiled using it. It works in client server model where in, 
    - Client - pyroscope executable runs the intended code (in languages like C#, Ruby) etc. (in case of Go, it is available as dependency) and collects instrumentation details to be sent to server. 
    - Server - Runs as a separate process (on Linux [Works in WSL if using Windows] or Mac), collects the data from client processes and renders them as table and/or flame graph via Web UI. 

Lets see how a function in C# can be instrumented using PyroScope.

1. Develop function to be profiled

1. Set up Pyroscope

1. Run Pyroscope Server 

1. Configure Pyroscope client and run it

1. Observe the flame graph in Pyroscope Web UI.

## Benchmarking 
todo: crank 
Crank is tool used by Microsoft internally to benchmark application. It is released as Nuget package and currently  .NET based code or Docker Containers can be benchmarked using it. Lets see steps to benchmark .NET Application using Crank.

1. Develop code, intended to be benchmarked 

2. Setup Crank 

3. Run Crank Agent 

4. Record data for benchmarking using Crank CLI. 


## Summary

### Useful References

* [Pyroscope](https://pyroscope.io)
* [Crank](https://github.com/dotnet/crank)

Happy Coding !!

---

{{< comments >}