---
title: "Programming Languages - .NET"
date: 2020-02-07T14:14:27+05:30
draft: false
---

# Microsoft .NET 

Platform where i have spent most time till now.

## General Links

- [What is .NET? by Scott Hanselman](https://www.youtube.com/watch?time_continue=1&v=bEfBfBQq7EE&feature=emb_logo)
- [Async in Depth](https://docs.microsoft.com/en-us/dotnet/standard/async-in-depth)
- [Using Async/Await in WCF or ASMX with AsyncEx](https://blog.stephencleary.com/2012/08/async-wcf-today-and-tomorrow.html)
- [Comparing Async/Await with GoRoutines](https://alexyakunin.medium.com/go-vs-c-part-1-goroutines-vs-async-await-ac909c651c11)
- [.NET Presentations - Events in a Box](https://presentations.dotnetfoundation.org/)
- [Building Microservices in .NET](https://altkomsoftware.pl/en/blog/building-microservices-on-net-core-1/)
- [Materialized View Pattern for Cross Service Queries](https://docs.microsoft.com/en-us/azure/architecture/patterns/materialized-view)
- [Oracle DB & .NET - Optimizing Real-World Performance with Static Connection Pools](https://docs.oracle.com/en/database/oracle/oracle-database/12.2/jjucp/optimizing-real-world-performance.html#GUID-BC09F045-5D80-4AF5-93F5-FEF0531E0E1D)
- [Clean Code concepts and tools adapted for .NET](https://github.com/thangchung/clean-code-dotnet)
- [Multiple ways how to limit parallel tasks processing](https://docs.microsoft.com/en-us/archive/blogs/fkaduk/multiple-ways-how-to-limit-parallel-tasks-processing)
- [Parallel programming in .NET](https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/)
- [Clean Architecture in .NET](https://github.com/ardalis/CleanArchitecture)
- [You’re (probably still) using HttpClient wrong and it is destabilizing your software](https://josefottosson.se/you-are-probably-still-using-httpclient-wrong-and-it-is-destabilizing-your-software/)
- [Async/Await - Guidance & Best Practices in Asynchronous Programming](https://github.com/davidfowl/AspNetCoreDiagnosticScenarios/blob/master/AsyncGuidance.md#asynchronous-programming)
- [Async/Await - Deep dive for Windows based Async I/O](https://tooslowexception.com/net-asyncawait-in-a-single-picture/)
- [One more look at why Async/Await, what happens underneath](https://blog.scooletz.com/2018/05/14/task-async-await-valuetask-ivaluetasksource-and-how-to-keep-your-sanity-in-modern-net-world/)
- [Implement a producer-consumer dataflow pattern](https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-implement-a-producer-consumer-dataflow-pattern)
- [Use Arrays of Blocking Collections in a Pipeline](https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/how-to-use-arrays-of-blockingcollections)

## Performance related 

- [Web forms, Asynchronous operations and its performance impact](https://docs.microsoft.com/en-us/aspnet/web-forms/overview/performance-and-caching/using-asynchronous-methods-in-aspnet-45)
- [List of Awesome Resources](https://github.com/adamsitnik/awesome-dot-net-performance)
- [Using System.Diagnostics.StopWatch.GetTimeStamp for accurate duration](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch.gettimestamp?view=net-5.0)
- [C# Job Queues with TPL Dataflow and Failure Handling](https://michaelscodingspot.com/c-job-queues-part-3-with-tpl-dataflow-and-failure-handling/)
- [Know about Threadpool, types of Threads in CLR and changing them to improve performance](https://gist.github.com/JonCole/e65411214030f0d823cb)
- [Work flow of diagnosing memory performance issues](https://devblogs.microsoft.com/dotnet/work-flow-of-diagnosing-memory-performance-issues-part-0/)
- [***Contention, poor performance, and deadlocks when you make calls to Web services from an ASP.NET application](https://support.microsoft.com/en-us/help/821268/contention-poor-performance-and-deadlocks-when-you-make-calls-to-web-s)
- [.NET GC - Memory fundamentals](https://github.com/Maoni0/mem-doc/blob/master/doc/.NETMemoryPerformanceAnalysis.md#Memory-Fundamentals)
- [Debug high CPU usage in .NET Core](https://docs.microsoft.com/en-us/dotnet/core/diagnostics/debug-highcpu?WT.mc_id=-blog-scottha&tabs=windows)
- [Measure performance of High frequency events in .NET Core App](https://docs.microsoft.com/en-us/dotnet/core/diagnostics/event-counter-perf)
- [.NET Core debug memory leak, High CPU Usage, Deadlock](https://docs.microsoft.com/en-us/dotnet/core/diagnostics/debug-highcpu?tabs=windows)
- [TCP Connection Pool and how it works in .NET Framework/.NET Core](https://devblogs.microsoft.com/azure-sdk/net-framework-connection-pool-limits/)
- [Using max number of worker threads using Semaphore](https://www.codeproject.com/Articles/859108/Writing-a-Web-Server-from-Scratch)
- [Performance tuning for .NET Core](https://reubenbond.github.io/posts/dotnet-perf-tuning)


## ASP.NET Web forms

- [What not to do in ASP.NET, and what to do instead](https://docs.microsoft.com/en-us/aspnet/aspnet/overview/web-development-best-practices/what-not-to-do-in-aspnet-and-what-to-do-instead#standards)
- [Use Task.Run at the invocation, not in the implementation](https://blog.stephencleary.com/2013/11/taskrun-etiquette-examples-dont-use.html)
- [Take Advantage of ASP.NET Built-in Features to Fend Off Web Attacks](https://docs.microsoft.com/en-us/previous-versions/dotnet/articles/ms972969(v=msdn.10)?redirectedfrom=MSDN)

## Windows Forms 

- [Task.run vs. BackgroundWorker](https://blog.stephencleary.com/2013/09/taskrun-vs-backgroundworker-conclusion.html)

## Tools, Libraries

- [Generate PDF using Scriban and Playwright](https://www.meziantou.net/generate-pdf-files-using-an-html-template-and-playwright.htm)
- [.NET Playground](https://sharplab.io/)
- [RestSharp - REST HTTP Client](https://github.com/restsharp/RestSharp)
- [Ocelot - API Gateway](https://ocelot.readthedocs.io/en/latest/features/configuration.html)
- [AsyncAwaitBestPractices](https://github.com/brminnick/AsyncAwaitBestPractices)
- [Flurl](https://flurl.dev/)
- [Distributed transaction solution in micro-service base on eventually consistency, also an eventbus with Outbox pattern](http://cap.dotnetcore.xyz/)
- [Simple Swiss Army knife for http/https troubleshooting and profiling](https://github.com/trimstray/htrace.sh)
- [Vegeta - HTTP load testing tool and library.](https://github.com/tsenart/vegeta)
- [Bombardier - Fast cross-platform HTTP benchmarking tool written in Go ](https://github.com/codesenberg/bombardier)
- [Plow - A high-performance HTTP benchmarking tool with real-time web UI](https://github.com/six-ddc/plow)
- [Hey - HTTP load generator, ApacheBench (ab) replacement](https://github.com/rakyll/hey)
- [Collection of HTTP(S) benchmark tools, testing/debugging, & restAPI (RESTful) ](https://github.com/denji/awesome-http-benchmark)
- [Light weight cross-platform test automation](https://gauge.org)
- [Event sourcing using variety of stores like AMQP, database](https://github.com/eventflow/EventFlow)
- [Feature Management library for ASP.NET Core](https://github.com/microsoft/FeatureManagement-Dotnet)
- [General Checklist for Projects](https://github.com/StephenCleary/Docs/blob/master/libraries/README.md)
- [Open Source ing tool for .NET Core/.NET Framework that helps your application generate document-like reports](https://www.fast-report.com)
- [Open source database, Optimized for Event sourcing](https://github.com/eventstore/eventstore)
- [bflat - No-frills, standalone compiler for .net](https://github.com/MichalStrehovsky/bflat)


## Task Queue/Scheduling tools

- [Hangfire](https://www.hangfire.io)
- [Tempus](https://github.com/Workshell/tempus)
- [Background tasks with hosted services in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-5.0&tabs=visual-studio)
- [Rebus - Smart end-points, dumb pipes service bus for .net](https://github.com/rebus-org/Rebus/wiki)


## .NET Core

- [.NET Portability Analyzer](https://github.com/microsoft/dotnet-apiport/blob/dev/docs/Console/README.md)
- [ASP.NET Core Architecture Overview](https://speakerdeck.com/davidfowl/asp-dot-net-core-architecture-overview)
- [ASP.NET Core Performance Best Practices](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices?WT.mc_id=ondotnet-channel9-cephilli&view=aspnetcore-2.2)
- [Diagnosing Issues Under Load Of WebAPI App Migrated To ASPNETCore On Linux](https://www.hanselman.com/blog/CustomerNotesDiagnosingIssuesUnderLoadOfWebAPIAppMigratedToASPNETCoreOnLinux.aspx)
- [Model binding in ASP.NET core](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-3.1)
- [HttpClient Connection Pooling in .NET Core](https://www.stevejgordon.co.uk/httpclient-connection-pooling-in-dotnet-core)
- [An Introduction to System.Threading.Channels](https://devblogs.microsoft.com/dotnet/an-introduction-to-system-threading-channels/)
- [Working with Channels With Stephen Toub](https://channel9.msdn.com/Shows/On-NET/Working-with-Channels-in-NET?WT.mc_id=ondotnet-c9-cephilli)
- [BackgroundService Gotcha: Application Lifetime](https://blog.stephencleary.com/2020/06/backgroundservice-gotcha-application-lifetime.html)
- [AWS Porting Assistant for .NET](https://aws.amazon.com/blogs/aws/announcing-the-porting-assistant-for-net/)
- [Sample of Micro services in .NET Core](https://github.com/madslundt/NetCoreMicroservicesSample)
- [WCF on .NET Core](https://corewcf.github.io/blog/2021/02/19/corewcf-ga-release)
- [ASP.NET Web API Versioning](https://github.com/microsoft/aspnet-api-versioning)
- [Samples of ASP.NET Core you can use](https://github.com/dodyg/practical-aspnetcore)
- [Step by Step OpenTelemetry in .NET Core](https://logz.io/blog/csharp-dotnet-opentelemetry-instrumentation/#conc)

## Security

- [Microsoft RESTler-Security testing using Automated Fuzzing](https://www.microsoft.com/en-us/research/blog/restler-finds-security-and-reliability-bugs-through-automated-fuzzing/)
- [Security Code Scan in .NET](https://security-code-scan.github.io/)


## Networking 

- [.NET 5 Networking Improvements](https://devblogs.microsoft.com/dotnet/net-5-new-networking-improvements/)

## Twitter Handles

- [Scott Hanselman](https://twitter.com/shanselman)

## General

- [.NET Conf 2021 Videos, Slides etc.](https://github.com/dotnet-presentations/dotNETConf/tree/master/2021/MainEvent/Technical)