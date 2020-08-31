---
title: "Optimizing  .NET Code using Benchmarks"
date: 2020-05-05T10:25:04+05:30
draft: false
---

## Background
Oftentimes, we come across situation where code does not perform as per expectation. What is typically approch to address it,

 * Performance Testing - Visual Studio Load Tests or Third party tools like  [Locust](https://locust.io/), [Vegeta](https://github.com/tsenart/vegeta), [Gatling](https://gatling.io/) etc.
 * Visual Studio Diagnostics Tools Or
 * Use tools like Perfview/dotTrace/dotMemory to diagnose bottlenecks

What if it is possible to Benchmark code for,

 * Set of varying parameter(s) 
 * Different runtimes (.NET Framework versions, .NET core, Mono etc.) with option to Benchmark it
 * Observe Memory Allocations for diagnostics
 * Get Detailed report on execution timeline
 * Have it as part of test suite so that it can be easily executed with every iteration involving optimized code to get immediate feedback

Enter [BenchmarkDotNet](https://benchmarkdotnet.org/), a Powerful .NET library for benchmarking. It is used by [DotNET](https://github.com/dotnet/performance) Team, Roslyn, ASP.NET Core and many other projects. 

Though [Benchmarkdotnet.org](https://benchmarkdotnet.org/) has nice documentation with detailed examples, Below we will look at how to benchmark a code which is aimed at dumping in-memory list of objects to a delimited file. In real-world scenario, the list of objects could be retrieved from external data store. 

So Lets Start.

## Approach

We will have below before we proceed with using BenchmarkDotNet

* Dummy class that represents Data Structure to be dumped to a file,

`{{< carbon gistid="b2d914a563b49d4dd50a4143166f27ec" >}}`

Refer Gist [here](https://gist.github.com/sachinsu/b2d914a563b49d4dd50a4143166f27ec)

* Class `CardWriter.cs` that generates file using, 

    * Using [StreamWriter](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=netcore-3.1) with Buffer
    * Using Stringbuilder and StreamWriter 
    * Using Open source [CSVHelper](https://joshclose.github.io/CsvHelper/) library

`{{< carbon gistid="b2d914a563b49d4dd50a4143166f27ec?filename=CardWriter.cs">}}`

Refer Gist [here](https://gist.github.com/sachinsu/b2d914a563b49d4dd50a4143166f27ec#file-cardwriter-cs)

* Now, let us write code to benchmark above functions with Memory Diagnostics,

`{{< carbon gistid="b2d914a563b49d4dd50a4143166f27ec?filename=Program.cs">}}`
 
 Refer Gist [here](https://gist.github.com/sachinsu/b2d914a563b49d4dd50a4143166f27ec#file-program-cs)

 Above code,
 * Class `FileGeneratorBenchmark` - This class uses BenchmarkDotNET attributes to decorate set of functions which in turn call functions from `CardWriter.cs` class. 
 * Class `Program` - General purpose class with static `main` function that invokes `BenchmarkRunner` to execute benchmarks.

It is required to run these benchmarks in `Release` mode or else BenchmarkDotNet will alert about the same. After running the benchmark, It will generate detailed report like below, 

![Benchmark Result](/images/capture.png)

Report shows Memory Allocation as well as Execution time lines across  Platform (.NET Framework Vesions) and parameters.

References: 
- [BenchmarkDotNet](https://benchmarkdotnet.org)
- [Introduction to Benchmarking C# Code with Benchmark .NET](https://www.stevejgordon.co.uk/introduction-to-benchmarking-csharp-code-with-benchmark-dot-net)

Happy Coding !!

---

{{< comments >}}