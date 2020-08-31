# Using Channels to implement Producer Consumer pattern

## Background
Recently, i got involved in assignment where in  an application was facing issues with throughput. Expectation is to support more than 500 transactions per second while load testing results were indicating system was experiencing high latency beyond 100+ transactions per second.

This application is developed in .NET Framework + .NET Core and primarily uses Relational Database for persistence and has point to point integration (mainly over HTTP) with internal & external application(s).

## Approach

The high level approach decided to perform diagnostics and subsequent corrective action(s) were,

* Benchmark code that involves Database and take corrective action
* Identify tasks in hot code path that could potentially be decoupled or done in fire-n-forget mode.

For point 2 from above, some of the tasks identified were,

- Sending Email/SMS on myriad of events
- Integration with External Applications over HTTP

Next task was to arrive at approach on how to perform them effectively outside of hot code path without incurring need of any additional resources (hardware or software)as far as possible. Accordingly, we had two options,

* _Polling_ - Periodically polling database to check for occurance of event and then performing the action.
* _Event Driven_ - Using Event notification feature of database (e.g. [Listen/Notify](https://www.postgresql.org/docs/current/sql-notify.html) in PostgreSQL or [Change Notification](https://docs.oracle.com/cd/B28359_01/appdev.111/b28424/adfns_cqn.htm)/[Advanced Queuing](https://www.oracle.com/database/technologies/advanced-queuing.html) in Oracle).

We decided to go with _Event driven_ as, 

* Cleaner approach that doesn't require perodically checking for events thus consuming a database connection and more code.
* We may have to have more than one such daemons to cater to different events in application.

Post finalizing on event driven approach for gathering events, next task was to determine how to effectively send email/sms or any other HTTP requests considering that rate of arrival of events will not be matching rate of processing them. Also these 

So what are the options available in .NET Ecosystem, Below are the ones i am aware of, 

* [Channels](https://devblogs.microsoft.com/dotnet/an-introduction-to-system-threading-channels/) - High performance implementation of In-memory producer/consumer pattern.
* [TPL Dataflow](https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/dataflow-task-parallel-library) - Super set of Channels Library. Aimed at use cases where blocks of logic are to be linked together to same or different consumers and so on. Also all these features come with additional overheads. 

For the task at hand, functionality offered by Channels is sufficient to implement in-memory producer consumer pattern. 

So we wrapped above event processing in a Windows service implemented as [.NET Core Worker
Service](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-3.1&tabs=visual-studio)

Generic Implementation is as follows, 

- Event Generator - In practice, this class will be responsible for wiring up to receive events from database 

```
using System;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace channels {
public class EventGenerator {

    public struct StringArgs {
        internal string Id { get; }
        
        internal StringArgs(string id) {
            Id = id;
        }
    }
    
    public event EventHandler<StringArgs> DataChanged;
    
    public void GenerateLoad(int loadFactor) {
        for (int i = 0; i < loadFactor; i++) {
            DataChanged?.Invoke(this,new StringArgs(i.ToString()));
        }            
    }
    
}
}
```
- Event Consumer which uses channels to process events in parallel

```
using System;
using System.Collections.Generic;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace channels
{

    public class EventConsumer
    {

        private readonly System.Threading.Channels.Channel<string> channel;
        private readonly int workerCount;
        private readonly IWebService _service;
        private readonly ILogger _logger;

        public EventConsumer(ILogger<EventConsumer> logger, IWebService service, int maxMessageCount, int workerCount)
        {
            this.workerCount = workerCount;
            this._service = service;
            this._logger = logger;
            this.channel = Channel.CreateBounded<string>(maxMessageCount);
        }

        // Using ValueTask: https://devblogs.microsoft.com/dotnet/understanding-the-whys-whats-and-whens-of-valuetask/
        public async ValueTask SetupChannel()
        {

            var tasks = new List<Task>(this.workerCount);
            for (var count = 1; count < this.workerCount; count++)
            {
                tasks.Add(Task.Run(() => this.ProcessChannelMessage(this.channel.Reader)));
            }

            //        writer.Complete();

            await this.channel.Reader.Completion;
            await Task.WhenAll(tasks);
        }

        public async ValueTask Send(string request)
        {
            await this.channel.Writer.WriteAsync(request);
        }


        private async ValueTask ProcessChannelMessage(ChannelReader<string> reader)
        {
            //because async methods use a state machine to handle awaits
            //it is safe to await in an infinte loop. Thank you C# compiler gods!

            while (await reader.WaitToReadAsync())//if this returns false the channel is completed
            {
                //as a note, if there are multiple readers but only one message, only one reader
                //wakes up. This prevents inefficent races.

                string messageString;
                while (reader.TryRead(out messageString))//yes, yes I know about 'out var messageString'...
                {
                    var RequestTime = DateTime.Now;
                    this._logger.LogDebug($"The listener just read {messageString} at {RequestTime}!");
                    await this._service.GetPage(messageString).ConfigureAwait(false);
                    var ResponseTime = DateTime.Now;
                    this._logger.LogDebug($"The listener  done {messageString}  at {ResponseTime}!", DateTime.Now);
                }
            }
        }
    }

}

```
## Summary 
Other languages (notably [Channels in Go](https://tour.golang.org/concurrency/2)) have been providing out of the box implementation for in-memory producer with concurrent, parallel consumers. With Channels, .NET Ecosystem finally has construct that can be effectively put to use for high performance, concurrent use cases.


### Useful References,
- [Event Pattern in C#](https://docs.microsoft.com/en-us/dotnet/csharp/event-pattern#defining-and-raising-field-like-events)
- [Gist on using Channels](https://gist.github.com/AlgorithmsAreCool/b0960ce8a3400305e43fe8ffdf89b32c)

Happy Coding !!