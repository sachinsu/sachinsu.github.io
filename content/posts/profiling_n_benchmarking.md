---
title: "Profiling and benchmarking tools for Applications"
date: 2021-12-10T01:00:00+05:30
draft: true
tags: [pyroscope,crank,flame graph, CPU]
---

## Introduction

We develop a piece of software with aim to fulfil specific business requirements in terms of resource usage, throughput etc. Profiling and benchmarking are approaches that developer has to evaluate the same. 

 - Profiling is defined as `aimed at  understanding the behaviour of a program. A profile result might be a table of time taken per function,` as per [this](https://stackoverflow.com/questions/34801622/difference-between-benchmarking-and-profiling) and [this](https://en.wikipedia.org/wiki/Profiling_(computer_programming)))
 - Benchmarking  `measures the time for some whole operation. e.g. I/O operations per second under some workload. So the result is typically a single number, in either seconds or operations per second. Or a data set with results for different parameters, so you can graph it.`. Refer [this](https://en.wikipedia.org/wiki/Benchmark_(computing)) for more information. Also do check [Benchmarking correctly is hard by Julia Evans](https://jvns.ca/blog/2016/07/23/rigorous-benchmarking-in-reasonable-time/).

We will look at couple of tools in this space. 

## Profiling 
todo: pyroscope
[Pyroscope](https://pyroscope.io) is Open Source Application for profiling Application. It is a cross-language tool i.e. programs in variety of languages can be profiled using it. It works in client server model where in, 
    - Client - pyroscope executable runs the intended code (in languages like C#, Ruby) etc. (in case of Go, it is available as dependency) and collects instrumentation details to be sent to server. 
    - Server - Runs as a separate process (on Linux [Works in WSL if using Windows] or Mac), collects the data from client processes and renders them as table and/or flame graph via Web UI.A flamegraph is a way to visualize resources used by a program, like CPU usage or memory allocations, and see which parts of your code were responsible. 

Lets see how a function in C# can be instrumented using PyroScope.

1. Develop function to be profiled
Lets have ASP.NET Core 5.0 based Web API as below,

{{< figure src="/images/profiling3.png" title="Simple Web API handle in C#" >}}

1. Set up Pyroscope

Install Pyroscope Application by following instructions [here](https://pyroscope.io/docs/agent-install-windows) for Windows. Note that, Pyroscope server component won't run on Windows in which case either [Windows Subsystem for Linux (WSL)](https://docs.microsoft.com/en-us/windows/wsl/install) or [Docker](https://pyroscope.io/docs/docker-guide) can be used. In case of Linux, instructions provided [here](https://pyroscope.io/docs/server-install-linux) are sufficient for both client and server components. 

I have setup the application on Windows 10 while using WSL for Pyroscope Server.

1. Configure Pyroscope client and run the Application

    - Build the application using `dotnet build`
    - Configure below environment variables (below is powershell format or you can use `SET ...` commands on command prompt),  

        ```
    
            $env:PYROSCOPE_SPY_NAME="dotnetspy";
            $env:PYROSCOPE_APPLICATION_NAME="my.dotnet.app";
            $env:PYROSCOPE_SERVER_ADDRESS="http://localhost:4040";

        ```
- Update path to include pyroscope installation folder using `$env:Path += ";C:\Program Files\Pyroscope\Pyroscope Agent\"`
    
    - Run the Application using `pyroscope exec dotnet .\bin\Debug\net5.0\webapi.dll`. 

1. Run Pyroscope Server 

- Start pyroscope server from WSL Linux prompt using, `sudo pyroscope server`. The output of this command should show Port on which server is running. 

    - Either use [curl](https://curl.se/) or [hey](https://github.com/rakyll/hey) tool to invoke the API. Below command shows how to generate load using hey,
        - run `.\hey.exe -m GET -c 10 -q 2 http://localhost:5000/weatherforecast` (Note: Modify the URL As appropriate)

1. Observe the flame graph in Pyroscope Web UI.

    - Observe the Table and/or flamegraph using Pyroscope Web interface. Below screenshot shows flamegraph for above code.

        {{< figure src="/images/profiling1.png" title="Table and flamegraph for API" >}}

        {{< figure src="/images/profiling2.png" title="Table and flamegraph for API" >}}

Overall, pyroscope provides easy way to observe Memory/CPU utilization as part of developer workflow on workstation itself. This is especially useful for development enviroments which do not provide profiling out of the box. 


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