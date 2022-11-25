## 2022-may-30 Mon

- [Amazon interview process][Interview]
    -  STAR (Situation, Task, Action, Result):
        - “What was the situation?”
        - “What were you tasked with?”
        - “What actions did you take?”
        - “What was the result?”
    - Bar Raiser process steps such as preparing a set of behavior-based interview questions in advance of the interview, insisting on written transcripts of the interview, rereading the transcript post interview (before making an assessment), conducting debriefs, basing debriefs on the interview transcripts, and making assessments based on well-understood principles are all steps that seek to eliminate individual biases. Having a diverse group of people involved in the process obviously reduces the chance of unconscious bias worming its way in.

- [Things to consider while making technology choices][Architecture]
    - Software Architecture cannot be created in a vacuum and solid technical foundation is not not enough.
    - Non-technical and cultural implications of the technology are important i.e. receptivity, speed to market and long term maintenance.
    - Reasons behind it
    - Impact on Team 
        - Is it easy for them learn?
        - Are they enthusiastic 
    - External Attractiveness (from New Hire perspective)
    - Effective communication 
    - Time to market
        - Trade off between idealism vs pragmatism 
    - Long term Maintenance
        - Cost of Maintenance in terms of 
            - Testing difficulties
                - Efficiency of QA Team is critical for Software product/application 
            - Employee attrition
                - What specific skills and domain knowledge will your design require, and how much value would be lost if one of your employees were to leave?
                - the more your own developers build; the more you will depend on them.
            - Flexibility 
                - The more vendor agnostic your design is, the more easily you will be able to avoid getting stuck  on an outdated platform and more quickly you'll be able to upgrade or pivot your underlying infrastructure as technology changes. 

- [Architectural thinking][Architecture]
    - Don’t even start considering solutions until you Understand the problem. Your goal should be to “solve” the problem mostly within the problem domain, not the solution domain.
    - eNumerate multiple candidate solutions. Don’t just start prodding at your favorite!
    - Consider a candidate solution, then read the Paper if there is one.
    - Determine the Historical context in which the candidate solution was designed or developed.
    - Weigh Advantages against disadvantages. Determine what was de-prioritized to achieve what was prioritized.
    - Think! Soberly and humbly ponder how well this solution fits your problem. What fact would need to be different for you to change your mind? For instance, how much smaller would the data need to be before you’d elect not to use Hadoop?

- [On Software Architecture][Architecture]

    - Every thing in Software Architecture is a trade off

    - The top 3 soft skills for any software architect are negotiation, facilitation, and leadership. Negotiation is a required skill as an architect because almost every decision you make as an architect will be challenged. Your decisions will be challenged by other architects who think they have a better approach than you do; your decisions will be challenged by business stakeholders because they think your decision takes too long to implement or is too expensive or is not aligned with the business goals; and finally, your decisions will be challenged by development teams who believe they have a better solution. All of this requires an architect to understand the political climate of the enterprise and how to navigate the politics to get your decisions approved and accepted.

    - Facilitation is another necessary soft skill as a software architect. Architects not only collaborate with development teams, but also collaborate closely with various business stakeholders to understand business drivers, explain important architecture characteristics, describe architectural solutions, and so on. All of these gatherings and meetings require a keen sense of facilitation and leadership within these meetings to keep things on track.

    - Finally, leadership is another important soft skill because an architect is responsible for leading and guiding a development team through the implementation of an architecture. They are there as a guide, mentor, coach, and facilitator to make sure the team is on track and is running as smooth as a well-oiled machine, and to be there when the team needs clarification or has questions and concerns about the architecture.

    - Trends of 2021, 
        - Exploration of low-code/no-code environments. 
        - Focus on Architecture as part of daily activities of development process. Realization of importance of evolutionary and incremental architectures
        - Move to hybrid from pure micro-services based architecture. 

    - Three basic Architecture Styles
        - Monolith (Single Deployment)
            - A modular monolith is a system where all of the code powers a single application and there are strictly enforced boundaries between different domains.
        - Service based 
        - Micro-services (independent deployability)
            - Common topologies 
                - API REST-based topology
                - Application REST-based topology - client requests are received through traditional web-based or fat-client business application screens rather than through a simple API layer. service components tend to be larger, more coarse-grained, and represent a small portion of the overall business application rather than fine-grained, single-action services. This topology is common for small to medium-sized business applications that have a relatively low degree of complexity.
                - Centralized messaging topology - instead of using REST for remote access, this topology uses a lightweight centralized message broker.message broker found in this topology does not perform any orchestration, transformation, or complex routing; rather, it is just a lightweight transport to access remote service components.
                - t ypically found in larger business applications or applications requiring more sophisticated control over the transport layer between the user interface and the service components. The benefits of this topology over the simple REST-based topology discussed previously are advanced queuing mechanisms, asynchronous messaging, monitoring, error handling, and better overall load balancing and scalability.

    - An architecture style describes the way your overall system is structured (such as microservices, layered monolith, and so on), whereas architecture patterns are ways of describing certain and specific architectural aspects of that overall structure. 

    - Deriving the required architecture characteristics from business needs is the key. Identify "ilities" that are important for org like Scalability, Performance, data integrity, system availability, fault tolerance, Security.

    - Lessons learned, 
        - Soft skills (people skills) matter in software architecture – they constitute 50% of being an effective software architect.
        -  Always keep the project and business constraints in mind when creating and analyzing software architecture (cost, time, budget, skill levels, etc.)       
        - Don’t get caught up in the hype as a software architect – stop, analyze tradeoffs, study trends, and approach new technology with caution.
        -  Focus more on the “why” rather than the “how” – this is what is truly important is software architecture
        -  Spreading knowledge is more valuable than being an individual contributor.

    - Reference: https://apiumhub.com/tech-blog-barcelona/software-architecture-recommendations-mark-richards/


- [Patterns in Distributed Systems][Architecture] 
    - Unlike a function call, when you make an RPC, the handler may receive your request multiple times. Implement idempotency. And when you respond to the client, it doesn't necessarily receive your response. They might retry, so idempotency helps again.
    - A message in Queue may be delivered multiple times. The message handler gotta be idempotent. It is generally difficult/rare to implement exactly-once semantics. Usually it is at-least-once.
    - Speaking of retries, you should control the rate of requests you send to your deps, and avoid retry storms. Adaptive client-side throttling might help.
    - Unlike functions in the same process, different services have different availability SLOs. In the code path of your API, don't call another API that didn't promise availability as high as you promised in your API. Same with latency.Try to move such calls out, to background jobs
    - The order of requests sent isn't the same as the order of requests received. Assuming otherwise might lead to races. Enqueued messages may be delivered out of order. Consider putting data-that-might-change into a db, and put only an immutable ref to that data into an SQS message
    - A piece of state you read from another machine/service/database isn't necessarily the same when write it back. This also leads to race conditions. When writing it back, *atomically* verify that state is still the same, via ConditionChecks / transactions.
    - Clocks on different machines may show different times. Don't rely on timestamp comparison if must get it 100% correct. This is another source of race conditions.
    - Most race conditions can be addressed by a synchronization mechanism, and in most distributed systems it is your database that supports atomic condition checks / transactions. It is the arbiter of who wins.
    - Unlike state in a single process, most of the time, you can't make mutations in two systems atomically, e.g. marking a purchase order as placed in the database and sending a confirmation email is not atomic.You might successfully mutate first system, but fail on the second one
    - If your storage system supports Change Data Capture, like @dynamodb, only place the purchase order, and in the background listen to committed changes and send the email there. This assumes that sending the email is idempotent.
    - Without CDC, update the order row and atomically insert another row representing an *intention* to send the email. In the background poll "intention rows" and send the email. Usually this is done in conjunction with a queuing system, so typically the intention is to enqueue a msg
    - RPCs have higher overhead than function calls. Put multiple items in a single request if you expect many items.  But don't put all of them into a single batch because RPCs define limits, and you want consistent latency.
    - When calling a stateful dependency, such as a distributed database, different items in a batch might be processed by different nodes. Minimize the number of nodes involved per batch by sorting items by the sharding key before forming batches.
    - RPCs are often more expensive than local function calls. Make RPCs in parallel.
    - But don't forget to limit number of concurrent outgoing requests though, e.g. to avoid running out of file descriptors.
    - Unlike a single process, deployments in a distributed system aren't atomic. Backward incompatible changes require a multiple deployments, e.g.
        - update service1 to accept both old & new protocols
        - update service2 to use the new protocol
        - remove old code from service1

- [Architect Role][Architecture]
    - Avoiding Snake Oil and Evangelism
        - One unfortunate side effect of enthusiasm for technology is evangelism, which should be a luxury reserved for tech leads and developers but tends to get architects in trouble.
        - Trouble comes because, when someone evangelizes a tool, technique, approach, or anything else people build enthusiasm for, they start enhancing the good parts and diminishing the bad parts. Unfortunately, in software architecture, the trade-offs always eventually return to complicate thin
        - An architect should also be wary of any tool or technique that promises any shocking new capabilities, which come and go on a regular basis.
        - Always force evangelists for the tool or technique to provide an honest assessment of the good and bad—nothing in software architecture is all good—which allows a more balanced decision
        - solutions in architecture rarely scale outside narrow confines of a particular problem space
        - Don’t allow others to force you into evangelizing something; bring it back to trade-offs.
        - We advise architects to avoid evangelizing and to try to become the objective arbiter of trade-offs. An architect adds real value to an organization not by chasing silver bullet after silver bullet but rather by honing their skills at analyzing the trade-offs as they appear.

- [System Architecture Decision Making][Architecture] 
    -  Don't adopt a new system unless you can make the first-principle argument for why your current stack fundamentally can't handle it.
    - Whenever you find yourself arguing for improving infrastructure by yanking up complexity, you need to be very careful. 
    - Typical issues while adopting new technologies are, 
        - Slower performance (hard to debug)
        - Scalability issues (because you don't know the system well)
        - Complexity may lead to more downtime
    - Stop thinking about technologies, and start thinking in first-principle requirements (the idea is to break down complicated problems into basic elements and then reassemble them from the ground up), 
        - In case of databases, it could be, 
            - You need faster inserts/updates (i.e. Not Synching every write to disk immediately which can be done in Mysql using [flush log settings](https://dev.mysql.com/doc/refman/8.0/en/innodb-parameters.html#sysvar_innodb_flush_log_at_trx_commit) and in postgresql using [Asynchronous commits](https://www.postgresql.org/docs/9.4/wal-async-commit.html))
            - You need terabytes of storage to have runway for the next ~5 years
            - You need more read capacity (i.e. use Read Replicas)

-   [Sync and Async ( Everything can't be async )][Architecture]
    - Javascript solves this by making everything non-blocking because blocking would destroy browser's UI Thread which is it's primary use case.
    - golang does this via go routines
    - .NET is one of the platforms that has excellent support for interop with the underlying OS (pinvokes) aka FFI (foreign function interfaces). It has one of the best FFI systems on the market
    - The moment you need to call into the underlying platform, you need to context switch from your current “green” thread, to one compatible to what the underlying platform supports. This is one of the big costs and why golang had to rewrite things in go and goasm.
    - The other difficulty .NET has is that it allows pinning memory. Maybe you pinned some object to get the address or pass it to another function. This is problematic, when you want you want to grow the stack dynamically in your user mode thread implementation.
    - The inability to copy the stack means you need to do a linked list instead. This is a complex and inefficient implementation. Java and go can both copy because there’s no way to get the underlying address of anything (without really unsafe code).
    - Async state machines in .NET form linked list. 

-  [Machine Learning][AIML]
    - It is tricky to apply it effectively 
    - Requires data and labels
    - First iteration should preferably be without machine learning
    - How to start?
        - Try to understand data 
            - Try to find correlations between feature and target variable
            - Scatter plots are a favorite for visualizing numerical values. Have the feature on the x-axis and the target variable on the y-axis and let the relationship reveal itself.
            - try box plot
        - Apply simple Heuristics
            - Recommendations: Recommend top-performing items from the previous period;
            - Product classification: Regex-based rules on product titles. Here’s an example from Walmart’s product classifier (Section 4.5): If product title contains “ring”, “wedding band”, “diamond. *bridal”, etc., classify it in the ring category.
            - Review spam identification: Rules based on the count of reviews from the same IP, time the review was made (e.g., odd timing like 3 am), similarity (e.g., edit distance) between the current review and other reviews made on the same day.

- Crypto
    - NFT is unique (non-fungible) digital item that can be traded online using blockchain technology. It is used for Digital Art, Collectibles, Sports. 
    - Why NFT? 
        - Pride of Ownership
        - Psychological effect - once basic needs are fulfilled, we seek more. Entire art industry is about the idea of people assigning monetary value to a canvas
        - Speculative nature
    - [How Blockchain works](https://graphics.reuters.com/TECHNOLOGY-BLOCKCHAIN/010070MF1E7/index.html)
        - Consists of database that has record bundled together into blocks and added to chain one after another. It has, 
            - The record  - can be any information (e.g. deal)
            - The block - block of records
            - Chain - link between blocks
    - ElasticSearch shortcomings documented by Yelp w.r.t. Scale, 
        - Document is indexed individually on every replica 
        - Uneven load distribution across cluster 
        - Difficult to auto-scale 
    - Yelp is using Lucene based alternate search solution called nrtsearch, at https://github.com/Yelp/nrtsearch 
        It Provides, 
        - Near real time segment replication 
        - Concurrent query execution

- UI
    - Framework for front-end
        - React: easy componentization, commonly used, flexible
        - Apollo GraphQL: commonly used (good docs), simple, automatic type generation
        - Next.js: SSR by default, capable filesystem server, built-in SPA router, helpful docs
        - Typescript: catch runtime errors at build, easy debugging
    - SSR and CSR
        - Server-side rendering does basically the same job as client-side rendering: generating HTML. 
        - The only real difference is that server-side rendering provides pre-rendered HTML to clients while client-side rendering requires the client to run JS files to render the HTML. 
        - server-side rendering is ideal for websites that need strong search engine presence, since search engine bots can just read the static content immediately instead of possibly running into issues with JS content. 
        - Server-side rendering is also necessary if clients have technical limitations, such as being unable to run JavaScript. Otherwise, server-side rendering is practically equal to client-side rendering.

- [Memory Management][SystemArchitecture]
    - OS has Virtual memory manager (VMM) that allocates VM to processes
        - VM enables both isolation and sharing
        - Hardware implements a mechanism called paging which allows the OS to implement virtual memory
        - Provided by the MMU (Memory Management Unit)
        - Memory divided in pages (usually 4k)
        - Virtual to physical page mapping in page tables (that the MMU walks)
        - When a virtual page doesn’t have a valid corresponding physical page, a page fault occurs
        - Control is transferred to the OS to provide a physical page (or an AV) Demand paging

    - How does Garbage collector (GC) decides if it should collect out object?
        - GC.Collect() collects the whole heap
            - This means GC does NOT decide the objects’ lifetime
            - GC only gets told by others if an object is live
            - In this case JIT tells the GC that object is still live 
            - JIT is free to lengthen the object lifetime till the end of method and has always been
 
- Serverless on Cloudflare
    - R2 will run across Cloudflare’s global network, which is most known for providing anti-DDoS services to its customers by absorbing and dispersing the massive amounts of traffic that accompany denial-of-service attacks on websites. It will be compatible with S3’s API, which makes it much easier to move applications already written with S3 in mind, and Cloudflare said that beyond the elimination of egress fees, the new service will be 10% cheaper to operate than S3.
    
    - Cloudflare is aiming at lower end of market (with low margins). The big incumbents have innovator's dilemma trying to come down and deal with companies (Cloudflare) serving lower end of market. 

    - For Compute, 
        - First, usage may be uneven, whether that be because a business is seasonal, hit-driven, or anything in-between. That means that compute capacity has to be built out for the worst case scenario, even though that means most resources are sitting idle most of the time.
        - Second, compute capacity is likely growing — hopefully rapidly, in the case of a new business. Building out infrastructure, though, is not a linear process: new capacity comes online all at once, which means a business has to overbuild for their current needs so that they can accommodate future growth, which again means that most resources are sitting idle most of the time.
        - Third, compute capacity is complex and expensive. That means there are both huge fixed costs that have to be invested before the compute can be used, and also significant ongoing marginal costs to manage the compute already online.

        -  This is why AWS was so transformative: Amazon would spend all of the up-front money to build out compute capacity for all of its customers, and then rent it on-demand, solving all of the problems I just listed:

            - Customers could scale their compute up-or-down instantly in response to their needs.
            - Customers could rent exactly how much compute they needed at any moment in time, even as they were able to seamlessly handle growth.
            - AWS would be responsible for all of the up-front investment and ongoing maintenance, and because they would operate at such scale, they would get much better prices from suppliers than any individual company could on its own.

        - Amazon has a lot less cash and, more importantly, a lot less profit than Google or Microsoft. 
        - Amazon already has significantly more scale, which means their costs on a per-customer basis are lower than Microsoft or Google.
        - AWS charges for data transferred out of their network but not for data transferred into their network

    - R2 is a compelling choice for a certain class of applications that could be built to s erve a lot of data without much compute. Moreover, by virtue of using the S3 API, R2 can also be dropped into existing projects; developers can place R2 in front of S3, pulling out data as needed, once, and getting free egress forever-after.

    - Moreover, like any true disruption, it will be very difficult for Amazon to respond: sure, R2 may lead Amazon to reduce its egress fees, but given the importance of those fees to both AWS’s margins and its lock-in, it’s hard to see them going away completely. More importantly, AWS itself is locked-in to its integrated approach: the entire service is architected both technically and economically to be an all-encompassing offering; to modularize itself in response to Cloudflare would be suicidal.

- Case for Cloud vs. On-prem
    - Bursty Workload ( If your workload goes through long periods of idleness punctuated with large unpredictable bursts of activity) is good case for a cloud based architecture
    - Using CDN is a good use of Cloud infrastructure
    - Today's servers are highly capable and scaling vertically is easy. Once limit of the server is reached then go for sharding and horizontal scaling or use cloud architecture that gives horizontal scaling for "free". 
    - Using one big server is comparatively cheap, keeps your overheads at a minimum, and actually has a pretty good availability story if you are careful to prevent correlated hardware failures. It’s not glamorous and it won’t help your resume, but one big server will serve you well.

- [.NET Specific Tech. Tips][Architecture]
    - Azure App service account can (and should) be used to host multiple applications
    - at scale could means 
        - no. of users 
        - size of data
        - processing large number of requests 
    
    - Use Streams/pipelines for large data sets
        - If streams are using Buffers then always FlushAsync.  
    - Pool and re-use buffers when you need to operate on in-memory data.
    - RegEx compilation is like 5000 lines of code 
    - ConcurrentDictionary 
        - conceptually similar to Dictionary where 
            - Reads are lock free but writes are not
        - The default number of concurrent writes is equal to the number of processors on the machine.
        - always enumerate over entries and not over keys
        -Dictionary with lock - "Poor read speed, lightweight to create and medium update speed."
        - Dictionary as immutable object - "best read speed and lightweight to create but  heavy update. Copy and modify on mutation e.g. new Dictionary(old).Add(key, value)"
        - Hashtable - "Good read speed (no lock required), same-ish weight as dictionary but more expensive to mutate and no generics!"
        - ImmutableDictionary - "Poorish read speed, no locking required but more allocations require to update than a dictionary."
    - in C#, avoid hashtable and use Dictionary<> instead
        - Hashtable is weakly typed and while it allows you to have keys that map to different kinds of objects which may seem attractive at first, you'll need to "box" the objects up and boxing and unboxing is expensive. You'll almost always want to use Dictionary instead.
    - Handling long-running operations in REST API (Azure Way),
        - The client sends the initial request to the resource to initiate the long-running operation. This initial request could be a PUT, PATCH, POST, or DELETE method.

        - The resource validates the request and initiates the operation processing. It sends a response to client with a 200-OK HTTP status code (or 201-Created if the operation is a create operation) and a representation of the resource where the status field is set to a value indicating that the operation processing has been started.

        - The client then issues a GET request to the resource to determine if the operation processing has completed.

        - The resource responds with a representation of the resource. While the operation is still being processed, the status field will contain a "non-terminal" value, like Processing.

        - After the operation processing has completed, a GET request from the client will receive a response where the status field contains a "terminal" value -- Succeeded, Failed, or Canceled -- that indicates the result of the operation
    
    - C# has a class MemoryMappedFile. A memory-mapped file contains the contents of a file in virtual memory. This mapping between a file and memory space enables an application, including multiple processes, to modify the file by reading and writing directly to the memory.  This could be useful when dealing with large files. Often preferred over buffers as buffering is difficult to get right.

    - The rule-of-thumb for allocations is that they should either die in the first generation (Gen0) or live forever in the last (Gen2).

    - Long running operations with status monitor 
        - The client sends the request to initiate the long-running operation. As in the RELO pattern, the initial request could be a PUT, PATCH, POST, or DELETE method.

        - The resource validates the request and initiates the operation processing. It sends a response to the client with a 202-Accepted HTTP status code. Included in this response is an Operation-location response header with the absolute URL of status monitor for this specific operation. The response also includes a Retry-after header telling the client a minimum time to wait (in seconds) before sending a request to the status monitor URL.

        - After waiting at least the amount of time specified by the previous response's Retry-after header, the client issues a GET request to the status monitor URL.

        - The status monitor URL responds with information about the operation including its current status, which should be represented as one of a fixed set of string values in a field named status. If the operation is still being processed, the status field will contain a "non-terminal" value, like Processing.

        - After the operation processing completes, a GET request to status monitor URL returns a response with a status field containing a terminal value -- Succeeded, Failed, or Canceled -- that indicates the result of the operation. If the status is Failed, the status monitor resource must contain an error field with a code and message that describes the failure. If the status is Succeeded, the response may contain additional fields as appropriate, such as results of the operation processing.

- [Logging rules][Architecture](https://tuhrig.de/my-logging-best-practices/)
    - INFO Level is for business while DEBUG is for developers
    - Log INFO after the operation is over and not before 
    - Distinguish between WARNING (Typically can be retried) and error

- [.NET Performance][Architecture]
    - Avoid LINQ. LINQ is great in application code, but rarely belongs on a hot path in library/framework code. LINQ is difficult for the JIT to optimize (IEnumerable<T>...) and tends to be allocation-happy.
    - Use concrete types instead of interfaces or abstract types. This was mentioned above in the context of inlining, but this has other benefits. Perhaps the most common being that if you are iterating over a List<T>, it's best to not cast that list to IEnumerable<T> first (eg, by using LINQ or passing it to a method as an IEnumerable<T> parameter). The reason for this is that enumerating over a list using foreach uses a non-allocating List<T>.Enumerator struct, but when it's cast to IEnumerable<T>, that struct must be boxed to IEnumerator<T> fo+r foreach.
    - Mark classes as sealed by default. When a class/method is marked as sealed, RyuJIT can take that into account and is likely able to inline a method call.
    - Mark override methods as sealed if possible.
    - Pass Struct by ref to minimize on-stack copies

- [API Architecture][Architecture][API] 
    - [OpenAPI](https://openapitools.org) & ASyncAPI - refers to API Specification 
    - OpenAPI is specification while swagger is tooling that uses OpenAPI Specification
    - API Definition - JSON/YAML documents that capture unique API's business intent aimed at meeting specification requirements.
    - OpenAPI Generator allowes generation of API Client libraries (SDK generation), server stubs, documentation and configuration automatically given an OpenAPI Spec.
    - Postman can be used to generate test cases basis OpenAPI Document
    - [OpenAPI tools](https://openapi.tools) - We  site that has many online tools like OpenAPI Specification generators, converters and so on.
    - API platforms are systems with integrated tools and processes that allow producers and consumers to effectively build, manage , publish and consume APIs.
        - Tools 
            - API Client - to send PAI Calls
            - API Designing and mocking 
            - API testing and automation 
            - API Documentation 
            - API Monitoring
        - Collaboration capabilities
            - API Workspaces (Collaboration on API Related workflows) 
            - API Catalog
        - Governance Capabilities
            - API Security - Checks during development, testing and production 
            - API Observability - Measuring API Traffic 
        - Integration with SDLC 
        - General Principles 
            - API Should Do One Thing and Do it Well
            - API Should Be As Small As Possible But No Smaller
            - Minimize Accessibility of Everything (Classes, Methods etc.)
            - Names should be self-explanatory
            - Document religiously
            - Consider Performance Consequences of API Design Decisions
            - Minimize mutability of classes 
            - for Methods, avoid long parameter list Three or fewer parameters is ideal. 
                - Two techniques for shortening parameter lists
                    _ Break up method
                    _ Create helper class to hold parameters

- [Confidential Computing][Cryptography]
    - Confidential computing is a breakthrough approach to data protection: sensitive workloads are run inside hardware-isolated and runtime-encrypted environments called enclaves. Enclaves can protect against threats like malware or rootkits and even rogue administrators and physical intruders. 

- [.NET Performance][Architecture]
    - What affects scale 
        - GC (Too many GC Pauses)
        - Threadpool starvation
        - Too many timers
        - Exceptions 
        - Synchronous IO
        - Highly contended locks
    - For scale
        - for fixed RPS, monitor CPU Usage and memory usage 
        - Understand how much scale unit, your deployment can handle (e.g. each VM can handle 1000 RPS)
    - Checklist
        - CPU 
            - CPU Usage
            - Threadpool (work items and worker threads)
            - GC (Gen0,Gen1 & Gen2) collections
            - Locks
            - Application logic 
                - chatty IO
                - Serialization 
        - Memory
            - Usage
            - Number of threads
            - Application Logic 
                - Strings
                - Reading everything in memory instead of using streaming 
                    - Disk IO
                    - Network IO
                - Disposable objects not being disposed
                - AsyncLocal leaks
        - Threadpool 
            - Sync over async 
                - APIs that masquerade as synchronous but are actually blocking async methods 
                - Uses 2 threads to complete single operation 
            - Blocking APIs are bad 
                - Avoid blocking APIs e.g. Task.Wait, Task.Result, Thread.Sleep, 
                    GetAwaiter.GetResult()
            - Excessive blocking causes thread starvation 
            - Thread injection rate beyond configured max is slow
        - Web Applications 
            - Always prefer Concurrent implementations (ConcurrentDictionary) over other alternatives.
        - GC
            - Allocating object is cheap, collecting it isn't
            - Allocating lots of objects can lead to GC pauses
            - Allocating objects over 85Kb in size ends up on large object heap
                - LOH is collected in gen 02 
        - JSON Parsing in APIs
            - As much as possible , use parser provided by framework.
        - CancelAfter implementation 
            ```
            public static async Task<T> TimeoutAfter<T>(this Task<T> task, TimeSpan timeout) 
            {
                using (var cts = new CancellationTokenSource())
                {
                    var delayTask = Task.Delay(timeout, cts.Token);

                    var resultTask = await Task.WhenAny(task, delayTask);

                    if (resultTask == delayTask) {
                        throw new OperationCancelledException();
                    } else {
                        cts.Cancel();
                    }

                    return await Task;
                }
            }

            ```
    - Async programming - don't block

- TCP Protocol
    - Runs on top of IP.any data you send via TCP gets converted into one or more datagrams, then sent over the networking using IP, then is reassembled into a stream of data on the other end. 
    - Created to ensure that all packets sent arrive at the destination. That too in same sequence and without duplication
    - In UDP, data is sent one datagram at a time unlike TCP. 
    - Socket is a endpoint for network communication. Its a virtual device exposed on a computer.

- Websockets
    -  web socket server starts off by being an HTTP server, accepting TCP conections and handling the HTTP requests on the TCP connection. When a request comes in that switches that connection to a being a web socket connection, the protocol handler is changed from an HTTP handler to a WebSocket handler. So it is only that TCP connection that gets its role changed: the server continues to be an HTTP server for other requests, while the TCP socket underlying that one connection is used as a web socket.


- EBPF
    - small snippets of code that run in linux kernel
    - It can hook into events
    - Can be attached to network socket 
    - It an listen to events and make changes to albeit with restrictions
    - Written in stripped down 'C' language
    - Available in all linux distributions and has some support on window but not MacOS yet
    - Allows to run code in kernel space 
    -Typically the way it works is user space program loads eBPF in kernel
    - LLVM dictates specification ofor EBPF
    - Use cases are, 
        - Security - Analyzing trace events to correlate & Detect intrusion 
        - Observability /SRE


- [History of Data Architectures][Architecture][Data] 
    
    - Best practices for Data Ingestion 
        - Write down all of the most important connectors for your business, the skills and time your team has to offer, and your budget when deciding on the right ingestion tool.
        - Document all of your data sources and how they are being ingested into your data warehouse, including any special setup.
        - Always keep a database with your raw, untouched data.
        - Run data syncs and models synchronously so there are no gaps in data.
        - Create alerts at the data sources rather than downstream data models. 

    - Parameters to evaluate Data Ingestion tool 
        - Data connectors available (Shopify, Azure Blob, Facebook, NetSuite, etc.) 
        - Capabilities of your team (time to set-up, time to maintain, skillset, etc.)
        - Budget (monthly costs to ingest expected volume of data)
        - Support (Slack communities, dedicated support agents, etc.)

    -  It all started with need for business leaders to understand how business was doing. so process was to get data out of operational data systems , transform it into a central place (Data warehouse) and perform analytics on it.
    - This enabled business analysts to understand how was business was performing 
    - However, this approach started to have challenges when,
        - need arises for handling more data types , typically unstructured data like videos, audio and images. 
        - also on-prem infra was difficult and expensive to scale with ever growing data. This is because at on-prem compute and storage were typically coupled.
        - There was appetite to perform forward looking analytics which gave indication on how business would perform in future based on available data. This required adding ML & AI on data sets.
        
    - This is where Concept of "Data lake" started getting adopted, 
        - Basically, its cheap storage area where data is just dumped from sources like OLTP systems, Other Applications, logs etc. 
        - Alternate Explaination : A data lake is a storage system with an underlying Data Lake File Format and its different Data Lake Table Formats that store vast amounts of unstructured and semi-structured data, stored as-is, without a specific purpose. Its the primary destination for growing volumes and varieties of exploratory and operational data next to data warehouse destinations. 
        - From here, Subset of the data is moved to classical data warehouse (typically on cloud) for analytics or gaining insights  
        - Reasons are, 
            - In the Sources to DWH approach, one has to have schema up-front which is hard to get right at the beginning. Data lake to DWH provides flexibility in this.
            - With a data lake, data becomes increasingly available, and early adopters discovered that they could extract insight through new applications built to serve the business. 
            - The data lake supports capturing and storing raw data at scale for a low cost with many different types of data. 
        - A structural transaction layer is built on top of it 
        - with lake-house pattern, BI tool can query data lake directly without the need to have DWH or transactional layer in between.
        - Components of Data Lake 
            - Storage Layer - Typically object storage service is used (e.g. S3)
            - Data lake file formats -  that mainly compresses the data for either row or column-oriented writing or querying. E.g. Apache Parquet, Apache Avro , Apache Arrow. These formats provide features such as split ability and schema evolution (adding new columns without breaking anything or even enlarging some types).             
            - Data lake table formats sit on top of these file formats to provide robust features. data lake table format bundles distributed files into one table that is otherwise hard to manage.They allow to efficiently query your data directly out of your data lake. They lack support for ACID transactions and support for ANSI SQL. Some of the data formats are Delta lake, Apache Iceberg, Apache Hudi.
                - Delta lake is open source layer that uses parquet for storage with Apache Spark. It supports automated partitioning
        
    - When it comes to AI and machine learning, a lot of the secret sauce to getting really great results or predictions comes from augmenting your data with additional metadata that you have.

    - Streaming
        - All the ETL use cases are potentially candidates for streaming

    - A data warehouse is a relational database in which the data is stored in a schema that is optimized for data analytics rather than transactional workloads. Commonly, the data from a transactional store is de-normalized into a schema in which numeric values are stored in central fact tables, which are related to one or more dimension tables that represent entities by which the data can be aggregated. For example a fact table might contain sales order data, which can be aggregated by customer, product, store, and time dimensions (enabling you, for example, to easily find monthly total sales revenue by product for each store). This kind of fact and dimension table schema is called a star schema; though it's often extended into a snowflake schema by adding additional tables related to the dimension tables to represent dimensional hierarchies (for example, product might be related to product categories). A data warehouse is a great choice when you have transactional data that can be organized into a structured schema of tables, and you want to use SQL to query them.

    - Data Lineage allows one to track data flow from its source to the consumers, by also tracking all its transformations in between

    - A data lake is a file store, usually on a distributed file system for high performance data access. Technologies like Spark or Hadoop are often used to process queries on the stored files and return data for reporting and analytics. These systems often apply a schema-on-read approach to define tabular schemas on semi-structured data files at the point where the data is read for analysis, without applying constraints when it's stored. Data lakes are great for supporting a mix of structured, semi-structured, and even unstructured data that you want to analyze without the need for schema enforcement when the data is written to the store.

    - Data lakehouse - The raw data is stored as files in a data lake, and a relational storage layer abstracts the underlying files and expose them as tables, which can be queried using SQL. SQL pools in Azure Synapse Analytics include PolyBase, which enables you to define external tables based on files in a data lake (and other sources) and query them using SQL. Synapse Analytics also supports a Lake Database approach in which you can use database templates to define the relational schema of your data warehouse, while storing the underlying data in data lake storage – separating the storage and compute for your data warehousing solution. Data lake houses are a relatively new approach in Spark-based systems, and are enabled through technologies like Delta Lake; which adds relational storage capabilities to Spark, so you can define tables that enforce schemas and transactional consistency, support batch-loaded and streaming data sources, and provide a SQL API for querying.
    
    - Star schema (The name “star schema” comes from the fact that when the table relationships are visualized, the fact table is in the middle, surrounded by its dimension tables; the connections to these tables are like the rays of a star.)
        - Fact table - represents an event that occurred at a particular time
        - Dimension table - dimensions represent the who, what, where, when, how, and why of the event. Dimension tables are usually much smaller (millions of rows).
        - Snowflake schema - where dimensions are further broken down into sub-dimensions.Snowflake schemas are more normalized than star schemas, but star schemas are often preferred because they are simpler for analysts to work with.
        - The idea behind column-oriented storage is simple: don’t store all the values from one row together, but store all the values from each column together instead. If each column is stored in a separate file, a query only needs to read and parse those columns that are used in that query, which can save a lot of work. Columnar storage can be significantly faster for ad hoc analytical queries.
    - OLAP Cubes are a grid of aggregates grouped by different dimensions.
    - LSM-trees - All writes first go to an in-memory store, where they are added to a sorted structure and prepared for writing to disk. It doesn’t matter whether the in-memory store is row-oriented or column-oriented. When enough writes have accumulated, they are merged with the column files on disk and written to new files in bulk.
    - Replication 
        - Synchronous - the leader waits until follower 1 confirms receipt of changes/updates
        - Asynchronous - the leader Doesn't wait for confirmation from follower 
    - Data vault 
        -  designed for historical tracking all aspects of data – relationships and attributes as well as where the data is being sourced from over time. Satellites, which are similar to dimensions.
        - Puts forth a set of design principles & structures for increasing historical tracking performance within the Vault (PiT and Bridge). The Data Vault model is flexible enough to adopt these structures at any point in time within the iterative modeling process and does not require advanced planning.
        - Data Vault is essentially a layer between the information mart / star schema and staging. There is some additional overhead that comes with developing this layer both in terms of ETL development and modeling. If the project is on a small scale or the project’s life is short-lived, it may not be worth pursuing a Data Vault model.
        - One of the main driving factors behind using Data Vault is for both audit and historical tracking purposes. If none of these are important to you or your organization, it can be difficult to eat the overhead required to introduce another layer into your modeling. However, speaking from long-term requirements, it may be a worthwhile investment upfront.
    - Wherescape
        - Additional layer between Staging and Star schema 
        - Wherescape (WS) doesn't address Real time integration itself...needs another product 
        - There is additional overhead but advantages are better historical tracking and auditing
        - WS has dependency on Windows 
        - It has dependency on SQL Server for Modelling (?) ...not sure if it has to be in HA Mode .... One option discussed was free SQL Server Express Edition but  HA Options with these edition are not available.

- [API Gateway][Architecture] 
       - Implementing security and cross-cutting concerns like security and authorization on every internal service can require significant development effort. A possible approach is to have those services within the Docker host or internal cluster to restrict direct access to them from the outside, and to implement those cross-cutting concerns in a centralized place, like an API Gateway.
       - Coupling - Without API Gateway, Client apps are coupled to the internal services. Any changes in internal services directly impact clients. 
       - Security - Api Gateway can handle security aspects required for endpoints exposed to outside world 
       - Cross cutting concerns - Authorisation, TLS/SSL can be handled at API Gateway layer. 

        - Features of API Gateway, 
            - Reverse proxy or gateway routing. The API Gateway offers a reverse proxy to redirect or route requests (layer 7 routing, usually HTTP requests) to the endpoints of the internal microservices. 
            - Requests aggregation. As part of the gateway pattern you can aggregate multiple client requests (usually HTTP requests) targeting multiple internal microservices into a single client request.
            - Cross-cutting concerns or gateway offloading. like 
                - Authentication and authorization
                - Service discovery integration
                - Response caching
                - Retry policies, circuit breaker, and QoS
                - Rate limiting and throttling
                - Load balancing
                - Logging, tracing, correlation
                - RT or NRT Monitoring of API Traffic
                - Headers, query strings, and claims transformation
                - IP allowlisting

            - reference: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/architect-microservice-container-applications/direct-client-to-microservice-communication-versus-the-api-gateway-pattern

- [Retry guidelines][Architecture] 
    - As a general guideline, use an exponential back-off strategy for background operations, and immediate or regular interval retry strategies for interactive operations. In both cases, you should choose the delay and the retry count so that the maximum latency for all retry attempts is within the required end-to-end latency requirement.

    - Anti-patterns
        - avoid implementations that include duplicated layers of retry code. Avoid designs that include cascading retry mechanisms, or that implement retry at every stage of an operation that involves a hierarchy of requests, unless you have specific requirements that demand this.
        - Never implement an endless retry mechanism
        - Never perform an immediate retry more than once.
        - Avoid using a regular retry interval, especially when you have a large number of retry attempts.
        - Prevent multiple instances of the same client, or multiple instances of different clients, from sending retries at the same times.
        [Reference](https://docs.microsoft.com/en-us/azure/architecture/best-practices/transient-faults)


- [DevOps for Database][DevOps][Databases]
    - CELT Metrics 
        - Concurrency is the number of simultaneous requests NN
        - Error Rate is what it sounds like
        - Latency is response time, as previously defined RR
        - Throughput is requests per second XX

    These can all be calculated as average (or p99) during intervals or as they apply to individual requests (except for Throughput).

        - How to get CELT Metrics
            - Query logs. Built-in, but high-overhead to enable on busy systems; accessible only to privileged users; expensive to analyze; and most of the tooling is opsand DBA-focused, not developer-friendly.
            -  TCP traffic. Golden, if you can get it: low overhead, high fidelity, and great developer-friendly tools exist. The main downside is reverse engineering a database’s network protocol is a hard, technical problem. (Database Performance Monitor shines here.)
            - Built-in instrumentation. For example, in MySQL, it’s the performance schema statement digest tables; in PostgreSQL it’s the pg_stat_statements extension; MongoDB doesn’t have a great solution for this internally, but you can get most of the way there with the top() command; or if you can accept higher performance impact, the MongoDB profiler. These have to be enabled, and often aren’t enabled by default, especially on systems like Amazon RDS, but this instrumentation is valuable and worth enabling, even if it requires a server restart. Oracle and SQL Server have lots of robust instrumentation. Most monitoring tools can use this data.

    - Use Method
        - Utilization
        - Saturation 
        - Errors

- [Every database technology has its Kryptonite][Databases]

        - MySQL: the query cache, replication, the buffer pool.MySQL lacks transactional schema changes and has brittle replication.
        - PostgreSQL: VACUUM, connection overhead, shared buffers. PostgreSQL is susceptible to vacuum and bloat problems during long-running transactions.
        - MongoDB: missing indexes, lock contention


- Citus for PostgreSQL
    - Sharding. Citus handles all of the sharding, so applications do not need to be shard-aware.
    - Multi-tenancy. Applications built to colocate multiple customers’ databases on a shared cluster—like most SaaS applications—are called multi-tenant. Sharding, scaling, resharding, rebalancing, and so on are common pain points in modern SaaS platforms, all of which Citus solves.
    - Analytics. Citus is not exclusively an analytical database, but it certainly is deployed for distributed, massively parallel analytics workloads a lot. Part of this is because Citus supports complex queries, building upon Postgres’s own very robust SQL support. Citus can shard queries that do combinations of things like distributed GROUP BY and JOIN together.

    - A Citus cluster is composed of PostgreSQL nodes with one of two roles: coordinator or worker. A coordinator receives queries, then decomposes them into smaller queries that execute on shards of data in the worker nodes. The coordinator then reassembles the results and returns them to the client.

    - Citus is not middleware: it’s an extension to Postgres that turns a collection of nodes into a clustered database. This means that all of the query rewriting, scatter-gather MPP processing, etc happens within the PostgreSQL server process, so it can take advantage of lots of PostgreSQL’s existing codebase and functionality.

- Vitess for MySQL
    -  Sharding. Sharding is essential for scaling traditional relational databases that weren’t built natively to operate as a distributed cluster of many nodes forming a single database. Every large-scale MySQL deployment—and there are thousands—uses sharding, bar none.
    - Kubernetes deployment. You can’t just run a database like MySQL on Kubernetes without a robust suite of operational tooling for high availability. MySQL just wasn’t built to run on ephemeral machines. Vitess makes it possible to treat a MySQL node as disposable.
    - Guardrails. MySQL, like most databases, is pretty easy for a badly behaved application or user to take down completely. A single runaway query or resource hog can create priority inversions and starve all the useful work. Vitess prevents this

    - Vitess can be described as “sharding and HA middleware,” but really it’s a new distributed database that is built on the shoulders of giants. Individual nodes run MySQL and leverage its capabilities as a leaf storage node. The resulting database automatically shards a single application’s data across many nodes, and automatically distributes a single query to run in a scatter-gather pattern in parallel across those nodes too. It is more designed for transactional workloads, than analytics workloads.

- Kubernetes    
    - A Pod is an environment for multiple containers to run inside. The pod is the smallest deployable unit you can ask Kubernetes to run and all containers in it will be launched on the same node. A pod has its own IP address, can mount in storage, and its namespaces surround the containers created by the container runtime such as containerd or CRI-O.
    - pod is a single instance of your application, and to scale to demand, many identical pods are used to replicate the application by a workload resource (such as a Deployment, DaemonSet, or StatefulSet). Your pods may include sidecar containers supporting monitoring, network, and security, and “init” containers for pod bootstrap, enabling you to deploy different application styles. These sidecars are likely to have elevated privileges and be of interest to an adversary.
    - The lifecycle of a pod is controlled by the kubelet, the Kubernetes API server’s deputy, deployed on each node in the cluster to manage and run containers. If the kubelet loses contact with the API server, it will continue to manage its workloads, restarting them if necessary. If the kubelet crashes, the container manager will also keep containers running in case they crash. The kubelet and container manager oversee your workloads.

- Data orchestration landscape (Source: https://airbyte.com/blog/data-engineering-past-present-and-future), 
	- Evolution 
		- In 1987, it started with the mother of all scheduling tools, (Vixie) cron
		- to more graphical drag-and-drop ETL tools around 2000 such as Oracle OWB, SQL Server Integration Services, Informatica 
		- to simple orchestrators around 2014 with Apache Airflow, Luigi, Oozie
		- to modern orchestrators around 2019 such as Prefect, Kedro, Dagster, or Temporal

	- Airflow - recommended to use intermediary storage to pass data between different tasks.
	- Prefect if you need a fast and dynamic modern orchestration with a straightforward way to scale out.
	- Dagster when you foresee higher-level data engineering problems. They focus heavily on data integrity, testing, idempotency, data assets, etc. 


- [Apache Airflow for ETL][ETL][Airflow] 
    - Primarily a workflow Management tool
    - Using Airflow to schedule and monitor ELT pipelines, but use other open-source projects that are better suited for the extract, load and transform steps. Notably, using Airbyte for the extract and load steps and dbt for the transformation step.
    -   With Airflow you can use operators to transform data locally (PythonOperator, BashOperator...), remotely (SparkSubmitOperator, KubernetesPodOperator…) or in a data store (PostgresOperator, BigQueryInsertJobOperator...).
    -  One of the main issues of ETL pipelines is that they transform data in transit, so they break easier. Hence move to ELT.
    - Airflow transfer operators together with database operators can be used to build ELT pipelines

- [Container Strategy][SystemArchitecture]
    - Containers are an application packaging format that help developers and organizations to develop, ship, and run applications
    - Why?
        - they effectively bundle applications, related libraries, dependencies, and configurations in a package that can be deployed across multiple environments
        - ease reproducibility and reliability of build-time and run-time software environments
        - consistently build and run containers on a variety of host environments (e.g., different OSes / different Linux distributions).
        - lighter than virtual machines, allowing efficient use of hardware and creating higher utilization of existing hardware.
        - provide a system for isolating processes and data without the full virtualization of the whole operating system.

    - Why not?
        - not optimized for monolithic applications, which can be expensive to rewrite or convert into microservices.

    - Plan for Operationalization process
        - Education, training and planning can significantly reduce development time and transition risk. Container-focused deployments can be subtly different from bare-metal or virtual machine focused deployments.
        - Pursue best practices such as good base image selection, container hierarchies, dependency version management, package selection minimalism, layer management practices, cache cleaning, reproducibility, and documentation. 
        -  Images should be rebuilt cleanly on a periodic basis incorporating vetted versions, patches and updates. Teams should frequently remove unnecessary or disused packages and assets as part of their maintenance process, test changes, and redeploy. 
        - Containers are not inherently secure; Container hardening should be integrated into the build process well before deployment. Thinking about security considerations proactively and early can help reduce risk. Scanning individual images for potential vulnerabilities is and should be a standard practice in any new environment.
        - having a strong organizational capability to plan, organize, and deploy incremental system changes is critical to any change while maintaining continuity of operations
        - Orchestrating containers is the best way to accomplish complex tasks.Kubernetes, a popular orchestrator, can be provided by many cloud vendors as well as on-premise infrastructure software vendors such as VMWare or Red Hat. The cost and maintenance of these infrastructures should be heavily weighed.
        - Individuals’ behaviors are guided (implicitly or explicitly) by underlying structures. Adoption must start with a purpose, whether that is a service or part of a larger project. Investment is needed during spin up to ensure proper experience is gained by project members. The chosen project must also have a clearly defined success metric.
        - Some Questions to consider, 
            - What paradigms will we follow when building and deploying containers?
            - How will we provide guidance on container creation?
            - How will we keep each container as optimized as possible?
            - What strategies will support long-term storage needs?
            - How might we build from small and functional base images?
            - What guidelines are needed to ensure that projects are easily rebuilt?
            - What processes are needed to keep images up to date?
            - What are you going to do to scan your images before build and deployment?

- [Technology Arch - How much spare capacity][Architecture][Sizing]
    - Suppose it takes a week (168 hours) to repair the capacity and the MTBF is 100,000 hours. There is a 168/1; 000; 000 * 100 = 1.7 percent, or 1 in 60, chance of a second failure. Now suppose the MTBF is two weeks (336 hours). In this case, there is a 168/336  100 = 50 percent, or 1 in 2, chance of a second failure—the same as a coin flip. Adding an additional replica becomes prudent. MTTR is a function of a number of factors. A process that dies and needs to be restarted has a very fast MTTR.If all this math makes your head spin, here is a simple rule of thumb: N+1 is a minimum for a service; N+2 is needed if a second outage is likely while you are fixing the first one.


- [Tech#Backpressure][Architecture]
    - In a producer-consumer system, there could be mismatch between rates at which production and consumption happens.  Backpressure is the ability of the consumer to say “Yo, hang on a minute!” to the producer, causing the producer to stop until the consumer catches up.

- [Tech#Scale versus Resiliency][Architecture]
    - If we are load balancing over two machines, each at 40 percent utilization, then either machine can die and the remaining machines will be 80 percent utilized. In such a case, the load balancer is used for resiliency.
    - If we are load balancing over two machines, each at 80 percent utilization, then there is no spare capacity available if one goes down. If one machine died, the remaining replica would receive all the traffic, which is 160 percent of what the machine can handle. The machine will be overloaded and may cease to function. Two machines each at 80 percent utilization represents an N+0 configuration. In this situation, the load balancer is used for scale, not resiliency.

- [Tech#Scaling, Sharding etc.][Architecture][Databases]
    - Drawbacks of Scale Up
        - there are limits to system size. The fastest, largest, most powerful computer available may not be sufficient for the task at hand. No one computer can store the entire corpus of a web search engine or has the CPU power to process petabyte-scale datasets or respond to millions of HTTP queries per second. There are limits as to what is available on the market today.
        - this approach is not economical. A machine that is twice as fast costs more than twice as much. Such machines are not sold very often and, therefore, are not mass produced. You pay a premium when buying the latest CPU, disk drives, and other components.
        - scaling up simply won’t work in all situations.
            - Buying a faster, more powerful machine without changing the design of the software being used usually won’t result in proportionally faster throughput.
            - Software that is single-threaded will not run faster on a machine with multiple processors.
            - Software that is written to spread across all processors may not see much performance improvement beyond a certain number of CPUs due to bottlenecks such as lock contention.
    - Some Scaling techniques, 
        - Segment plus Replicas: Segments that are being accessed more frequently can be replicated at a greater depth. This enables scaling to larger datasets (moresegments) and better performance (more replicas of a segment). 
        - Dynamic Replicas: Replicas are added and removed dynamically to achieve required performance. If latency is too high, add replicas. If utilization is too low, remove replicas.
        -  Architectural Change: Replicas are moved to faster or slower technology based on need. Infrequently accessed shards are moved to slower, less expensive technology such as disk. Shards in higher demand are moved to faster technology such as solid-state drives (SSD). Extremely old segments might be archived to tape or optical disk.
    - Cache 
        - The Least Recently Used (LRU) algorithm tracks when each cache entry was used and discards the least recently accessed entry    
        - The Least Frequently Used (LFU) algorithm counts the number of times a cache entry is accessed and discards the least active entries

    - Data Sharding  - is a way to segment the database that is flexible, scalable and resilient. A hash function is algorithm that maps data of varying length to a fixed length value. 
        - Distributed hash table pattern involves generating hash of the key and allocating data as per hash value like, 
            - Odd or even or power of 2 (i.e. 2(n) where n is last n bits of hash) -- For 2 shards
            - reminder of hash divided by 4 - for 4 shards

- [Threads vs Processes][Architecture]
    - Processes have their own address space, memory and open file tables
    - Processes are self isolating i.e. corrupt process cannot hurt other processes 
    - Existing processes can execute task much faster. (An example of queueing implemented with processes is the Prefork processing module for the Apache web server. On startup, Apache forks off a certain number of subprocesses. Requests are distributed to subprocesses by a master process.)
    - So how do we decide between multiprocessing and multithreading?
        - Multithreading for I/O intensive tasks
            - Multiprocessing for CPU intensive tasks (if you have multiple cores available)

- [Architecture Decision Records (ADR)](https://www.cognitect.com/blog/2011/11/15/documenting-architecture-decisions)[Architecture]
    
    - Format of ADR 
        - Title - For Example: "ADR 1: Deployment on Ruby on rails 3.0.10" 
        - Context - Describes forces at play including technological, political, social and project local. The language in this section should be describing facts and nothing else
        - Decision - Describes response to forces mentioned in "Context".  It is stated in full sentences, with active voice. "We will …"
        - Status - A decision may be "proposed" if the project stakeholders haven't agreed with it yet, or "accepted" once it is agreed. If a later ADR changes or reverses a decision, it may be marked as "deprecated" or "superseded" with a reference to its replacement.
        - Consequences - This section describes the resulting context, after applying the decision. All consequences should be listed here, not just the "positive" ones. A particular decision may have positive, negative, and neutral consequences, but all of them affect the team and project in the future.

- [Format for "Design Document"][Architecture][Documentation] 
    - Title : Title of the document 
    - Date: Date of last revision
    - Author(s)/Reviewer(s)/Approver(s)
    - Revision Number 
    - Status - In draft/in review/approved/in progress.
    - Executive Summary - brief summary of the project that contains the major goal of the project and how it is achieved.
    - Goals ("In Scope") - What is to be achieved by the project, typically represented as a bullet list. Include non-tangible, process goals such as standardization or metrics requirements.  
    - Non-goals ("Out of scope") - A list of non-goals should explicitly identify what is not included in the scope for this project.
    - Background - brief history. Identify any acronyms or unusual terminology used. Document any previous decisions made that resulted in limitations or constraints. 
    - High-level Design - How design works at a high level. 
    - Detailed Design - The full design, including diagrams, sample configuration files, algorithms, and so on. This will be your full and detailed description of what you plan to accomplish on this project
    - Alternatives Considered - A list of alternatives that were rejected, along with why they were rejected.
    - Special Constraints - A list of special constraints regarding things like security, auditing controls, privacy, and so on.

    Below are not mandatory but could be useful, 

    - Cost Projections: The cost of the project—both initial capital and operational costs, plus a forecast of the costs to keep the systems running.
    - Support Requirements: Operational maintenance requirements. This ties into Cost Projections, as support staff have salary and benefit costs, hardware and licensing have costs, and so on.
    - Schedule: Timeline of which project events happen when, in relation to each other.
    - Security Concerns: Special mention of issues regarding security related to the project, such as protection of data.
    - Privacy and PII Concerns: Special mention of issues regarding user privacy or anonymity, including plans for handling personally identifiable information (PII) in accordance with applicable rules and regulations.
    - Compliance Details: Compliance and audit plans for meeting regulatory obligations under SOX, HIPPA, PCI, FISMA, or similar laws.
    - Launch Details: Roll-out or launch operational details and requirements.


- AKF Scaling Cube
    - x-axis (horizontal scaling) - cloning systems or increasing their capacities to achieve greater performance.
    - y-axis (vertical scaling) - scales by isolating transactions by their type or scope, such as using read-only database replicas for read queries and sequestering writes to the master database only.
    - z-axis (lookup based scaling) - is about splitting data across servers so that the workload is distributed according to data usage or physical geography

- [Software Resiliency][Architecture]
    - Spare capacity is like an insurance policy: it is an expense you pay now to prepare for future trouble that you hope does not happen. It is better to have insurance and not need it than to need insurance and not have it.
    - in a 1+1 redundant system, 50 percent of the capacity is spare. In a 20+1 redundant system, less than
    5 percent of the capacity is spare. The latter is more cost-efficient.
    - Mean time between failures (MTBF) - The MTBF of the system is only as high as that of its lowest-MTBF part.
    - The time it takes to repair or replace the down capacity is called the mean time to repair (MTTR).
    - The probability of second failure happening during repair window is MTTR/MTBF * 100
    - If we are load balancing over two machines, each at 40 percent utilization, then either machine can die and the remaining machines will be 80 percent utilized. In such a case, the load balancer is used for resiliency.A load balancer provides scale when we use it to keep up with capacity, and resiliency when we use it to exceed capacity.


- Data Lake pattern 
    - Response to complexity, expense and failures of datawarehouse pattern.
    - Inverse of Data warehouse Pattern 
    - Centralized data collection 
    - "Load and transform" rather than "transform and load" 
    - Data extracted from many sources and often stored as-is or in "raw" format
    - disadvantages, 
        - Difficult to understand relationships due to raw format
        - Ad-hoc transformations
        - lack of ownership from original owners

- [Data Mesh][Architecture][Databases]
    - a data mesh allows data sources to remain distributed and controlled by different organizations, but accessible to a centralized application. With a data mesh architecture, data is guaranteed to be highly available, easily discoverable, secure and interoperable with the applications that depend on accessing it.
    - Domain ownership - Data is owned by domains that are intimately familiar with it. 
    - Data as a Product - encourage domains to share the data. 
    - Self serve Data platform - 
    - Computational federated governance - Data mesh introduces a federated decisionmaking model composed of domain data product owners. The policies they formulate are automated and embedded as code in each and every data product.
    - Data Product Quantum - overlays microservices architecture. 
        - Source-aligned (native) DPQ - Provides analytical data on behalf of the collaborating architecture quantum, typically a microservice, acting as a cooperative quantum.
        - Aggregate DQP - Aggregates data from multiple inputs, either synchronously or asynchronously. For example, for some aggregations, an asynchronous request may be sufficient; for others, the aggregator DPQ may need to perform synchronous queries for a source-aligned DPQ.
        - Fit-for-purpose DPQ - A custom-made DPQ to serve a particular requirement, which may encompass analytical reporting, business intelligence, machine learning, or other supporting capability.
    - Highly suitable for Microservices based architecture 
    - Requires asynchronous communication and eventual consistency
    - It is more difficult in architectures where analytical and operational data must stay in sync at all times, which presents a daunting challenge in distributed architectures.

- Observability - Higher the SLA/SLO requirements for Service, Higher the Need for Observability
    - Structured log events with rich context specific details (often maintained as key-value pair) are highly useful where aim of observability  is for swiftly identifying where in your system the error or problem is coming from, so you can debug it — by reproducing it, or seeing what it has in common with other erroring requests. 
    - The rule is to have one observability event per request per service hop (example, if your request hit the edge, API, four internal services, two databases … but ran 1 query on one db and 10 queries on the second db … you would generate a total of *19 observability events* for this request where all of them are linked by randomly generated "Request ID".) 
    - Structure events are richer than metrics due to its payload. 
    - Think about the data you need while debugging the issue.
    - Request id must be unique and sequence of these events should be preserved.
    - only gather observability events from services that we can and do introspect
    - Each event should be dense all the useful context like,
        - Metadata like src, dst headers
        - The timing stats and contents of every network call (our beelines wrap all outgoing http calls and db queries automatically) 
        - Every raw db query, normalized query family, execution time etc
        - Infra details like AZ, instance type, provider
        - Language/environment context like $lang version, build flags, $ENV variables
        - Any and all unique identifying bits you can get your grubby little paws on — request ID, shopping cart ID, user ID, request ID, transaction ID, any other ID … these are always the highest value data for debugging.
        - Any other useful application context.  Service name, build id, ordering info, error rates, cache hit rate, counters, whatever.
        - Possibly the system resource state at this point in time.  e.g. values from /proc/net/ipv4 stats 
    - pretty metrics and dashboards and aggregates from structured events
    - Event storage - How long and which, 
        - Events must be sampled and some rules are, 
        -  health checks that return 200 OK usually represent a significant chunk of your traffic and are basically useless, while 500s are almost always interesting
        - all requests to /login or /payment endpoints
        -  For database traffic: SELECTs for health checks are useless, DELETEs and all other mutations are rare but you should keep all of them.


- Google's measures for handling overload, 
	- we implement a per-request retry budget of up to three attempts. If a request has already failed three times, we let the failure bubble up to the caller. The rationale is that if a request has already landed on overloaded tasks three times, it's relatively unlikely that attempting it again will help because the whole datacenter is likely overloaded.
	- we implement a per-client retry budget. Each client keeps track of the ratio of requests that correspond to retries. A request will only be retried as long as this ratio is below 10%. The rationale is that if only a small subset of tasks are overloaded, there will be relatively little need to retry.
	- Observability 
		- Latency - The time it takes to service a request. It’s important to distinguish between the latency of successful requests and the latency of failed requests. For example, an HTTP 500 error triggered due to loss of connection to a database or other critical backend might be served very quickly; however, as an HTTP 500 error indicates a failed request, factoring 500s into your overall latency might result in misleading calculations. On the other hand, a slow error is even worse than a fast error! Therefore, it’s important to track error latency, as opposed to just filtering out errors.
        - Traffic - A measure of how much demand is being placed on your system, measured in a high-level system-specific metric. For a web service, this measurement is usually HTTP requests per second, perhaps broken out by the nature of the requests (e.g., static versus dynamic content). For an audio streaming system, this measurement might focus on network I/O rate or concurrent sessions. For a key-value storage system, this measurement might be transactions and retrievals per second.
        - Errors - The rate of requests that fail, either explicitly (e.g., HTTP 500s), implicitly (for example, an HTTP 200 success response, but coupled with the wrong content), or by policy (for example, "If you committed to one-second response times, any request over one second is an error"). Where protocol response codes are insufficient to express all failure conditions, secondary (internal) protocols may be necessary to track partial failure modes. Monitoring these cases can be drastically different: catching HTTP 500s at your load balancer can do a decent job of catching all completely failed requests, while only end-to-end system tests can detect that you’re serving the wrong content.
        - Saturation - How "full" your service is. A measure of your system fraction, emphasizing the resources that are most constrained (e.g., in a memory-constrained system, show memory; in an I/O-constrained system, show I/O). Note that many systems degrade in performance before they achieve 100% utilization, so having a utilization target is essential.In complex systems, saturation can be supplemented with higher-level load measurement: can your service properly handle double the traffic, handle only 10% more traffic, or handle even less traffic than it currently receives? For very simple services that have no parameters that alter the complexity of the request (e.g., "Give me a nonce" or "I need a globally unique monotonic integer") that rarely change configuration, a static value from a load test might be adequate. As discussed in the previous paragraph, however, most services need to use indirect signals like CPU utilization or network bandwidth that have a known upper bound. Latency increases are often a leading indicator of saturation. Measuring your 99th percentile response time over some small window (e.g., one minute) can give a very early signal of saturation.Finally, saturation is also concerned with predictions of impending saturation, such as "It looks like your database will fill its hard drive in 4 hours."

## 2022-jan-03 Mon

- [VMs or Serverless][Architecture][Infrastructure]
    - VMs, Serverless and when they are useful,
        - Virtual machines (e.g. EC2 or Compute Engine) are useful for workloads that change no faster than you’re able to add capacity, or for work loads that can tolerate delay in scaling (e.g. queue based event systems). They are also useful for short lived sessions that can tolerate scale down events
        -  Containers (e.g. a Kubernetes cluster or Fargate) which run on top of fixed compute. Like virtual machines are useful for traffic volumes which slowly change over time. While you’re able to start up a new container quickly to handle a new session, you’re still limited by the underlying compute instance on which the containers are running. The underlying compute hardware has to scale to meet the demands of the running containers. Containers are great for long lived, stateful sessions, as they can be ported between physical hardware instances while still running.
        - Serverless functions (e.g. Lambda or Cloud Run) are, in essence, containers running on top of physical hardware. They are ideally suited for handling unpredictable traffic volumes and for non-persistent and stateless connections.

- [Neural Networks](https://sirupsen.com/napkin/neural-net?utm_source=computer-napkins&utm_medium=email)[AIML], 
    - Basically training the system by adjusting the weights so as to get optimal desired result. 
    - Has 3 layers 
        - Input layer - has representation of data to feed to network. 
        - Hidden layer - Does a math on the input layer to convert it to our prediction. Training refers to changing math of this layer to generate predictions. Values in this layer are called weights 
        -  Output layer - Contains Final prediction.
    - Training indicates adjusting weights in hidden layer so as to achieve better prediction. Its like teaching hidden layer to apply certain function without actually applying it. 
    - loss function indicates how the prediction fair against expected outcome. large loss means wrong model and vice-versa. 
    - Minimizing the loss of a function is absolutely fundamental to machine learning.
    - While training, gradient descent is a method that minimizes value of a function. It helps in avoiding ad-hoc randomization (to achieve better prediction) and reducing loss .
    - epoch  - an iteration over the full training set is referred to as an epoch. 
    - Autograd (pytorch) is an automatic differentiation engine. grad stands for gradient, which we can think of as the derivative/slope of a function with more than one parameter. It keeps track of all the math functions applied and applies derivative.
    - To avoid overstepping in gradient descent, something called as "learning rate" is applied. 
    - For a Non-linear use cases (e.g. identify cat vs. calculate average), one has to add non-linear component to neural net. This is called as activation function. 
    - The core operations in neural net involve matrix multiplication. Frameworks like Pytorch perform this in underneath 'C' layer instead of Python. Using GPUs make them even faster.

- [How ASP.NET requests are processed](https://docs.microsoft.com/en-us/aspnet/web-forms/overview/performance-and-caching/using-asynchronous-methods-in-aspnet-45)[Architecture][dotnet] 
    - .NET framework maintains pool of threads and dispatched for a new request.
    - If request is processed synchronously then respective thread is busy for that duration 
    - Max number of threads is 5000 for .NET 4.5
    - If long running processing of requests blocks many threads then its called as thread starvation 
    - In case of "thread starvation", web server queues requests and when queue is full it responds with HTTP 203 (server busy)
    - Each new thread has overhead of about 1MB of RAM
    - In case when "async...await" is used,  ASP.NET will not be using any threads between the async method call and the await.
    - An asynchronous request takes the same amount of time to process as a synchronous request. However, during an asynchronous call, a thread is not blocked from responding to other requests while it waits for the first request to complete. Therefore, asynchronous requests prevent request queuing and thread pool growth when there are many concurrent requests that invoke long-running operations.
    - Guidance, 
        - Use synchronous when,
            - Operation is short-lived
            - Simplicity is more important (No need for parallelism)
            - Primarily CPU based instead of I/o (Network, Disk etc.)

- [PostgreSQL Replication][Databases] 
    - PostgreSQL supports block-based (physical) replication as well as the row-based (logical) replication. Physical replication is traditionally used to create read-only replicas of a primary instance, and utilized in both self-managed and managed deployments of PostgreSQL. Uses for physical read replicas can include high availability, disaster recovery, and scaling out the reader nodes. 

- [Data storage][Databases][Architecture]
    - Row oriented - Because data on a persistent medium such as a disk is typically accessed block-wise (in other words, a minimal unit of disk access is a block), a single block will contain data for all columns.This is great for cases when we’d like to access an entire user record, but makes queries accessing individual fields of multiple user records (for example, queries fetching only the phone numbers) more expensive, since data for the other fields will be paged in as well
    - Column-oriented - Store values by vertical partitioning ie. by column against storing values by horizontal partitioning (as in RDBMS).
        - In column-oriented layout, values of same column are stored contiguously on disk.For example, if we store historical stock market prices, price quotes are stored together. Storing values for different columns in separate files or file segments allows efficient queries by column, since they can be read in one pass rather than consuming entire rows and discarding data for columns that weren’t queried.
        - Column-oriented stores are a good fit for analytical workloads that compute aggregates, such as finding trends, computing average values, etc. Processing complex aggregates can be used in cases when logical records have multiple fields, but some of them (in this case, price quotes) have different importance and are often consumed together.
        - Apache Parquet, Apache ORC are column-oriented file formats.
            - Parquet
                - They use hybrid (row & colum) approach for storage. Values of each column for set of rows (rowgroups) are stored contiguously.
                - Usually not stored as single file. 
                - Supports Compression using techniques like RLE (Run length encoding). Stores repeated value only once and associated encoded data. 
                - Smaller files results in lesser I/O
                - Can be inspected using Parquet-tools
                - Uses optimization techniques like predicate pushdown (which stores range of column value per row. This is then used during querying)
        - Reading multiple values for the same column in one run significantly improves cache utilization and computational efficiency.
        - If the read data is consumed in records (i.e., most or all of the columns are requested) and the workload consists mostly of point queries and range scans, the row-oriented approach is likely to yield better results. If scans span many rows, or compute aggregate over a subset of columns, it is worth considering a column-oriented approach.
        - Wide column stores 
            - data is represented as a multidimensional map, columns are grouped into column families (usually storing data of the same type), and inside each column family, data is stored row-wise. This layout is best for storing data retrieved by a key or a sequence of keys.
            -Each row is indexed by its row key. Related columns are grouped together in column families.
            - Each column inside a column family is identified by the column key, which is a combination of the column family name and a qualifier.
            - Column families store multiple versions of data by timestamp.


- [PostgreSQL Connection Pool size][Databases]
    - Formula
        pool size = min(num_cores, max_parallel_ios)/active_Factor*Parallelism 
    - Determining Active Factor 
        - PostgreSQL 14,
            - easy with the new session statistics in PostgreSQL v14:
                    SELECT active_time / (active_time + idle_in_transaction_time)
                    FROM pg_stat_database
                    WHERE datname = 'mydb'
                    AND active_time > 0
        - Alternate way
            - for a coarse estimate, query pg_stat_activity several times and use  an average:
                    SELECT (count(*) FILTER (WHERE state = 'active'))::float8
                    / count(*) FILTER (WHERE state in
                    ('active', 'idle in transaction'))
                    FROM pg_stat_activity
                    WHERE datname = 'mydb';
    - “num_cores” is the number of CPU cores
    - “max_parallel_ios” is the upper limit of concurrent I/O requests that the disk can handle
     - “parallelism” is the average number of server processes used for a single SQL statement

- [Postgres indexes][Databases], 
    - B-tree indexes are the most common type of index and would be the default if you create an index and don’t specify the type. B-tree indexes are great for general purpose indexing on information you frequently query. 
    - BRIN indexes are block range indexes, specially targeted at very large datasets where the data you’re searching is in blocks, like timestamps and date ranges. They are known to be very performant and space efficient.
    - GIST indexes build a search tree inside your database and are most often used for spatial databases and full-text search use cases. 
    - GIN indexes are useful when you have multiple values in a single column which is very common when you’re storing array or json data. 

- [Postgres Triggers][Databases]
    - is limited to single server 
    - working set does not fit in memory
    - reaching limit of network attached storage, CPU
    - Analytical queries take too long
    - Autovacuum can not keep up with transaction load


- [Database schema migrations - general flow of online schema migration][Databases], 
    - Create a new, empty table, in the likeness of the original table. We title this the ghost table.
    - ALTER the ghost table. Since the table is empty, there is no overhead to this operation.
    - Validate the structural change is compatible with tooling requirements.
    - Analyze the diff.
    - Begin a long running process of copying existing rows from the original tables to the ghost table. Rows are copied in small batches.
    - Capture or react to ongoing changes to the original table, and continuously apply them onto the ghost table.
    - Monitor general database and replication metric, and throttle so as to prioritize production traffic as needed.   
    - When the existing data copy is complete, the migration is generally considered as ready to cut-over, give or take some small backlog or state of the replication topology.
    - Final step is the cut-over: renaming away of the original table, and renaming the ghost table in its place. Up to some locking or small table outage time, the users and apps are largely ignorant that the table has been swapped under their feet.

- [Open source data stack][Architecture] 
    - Airflow - Workflow
    - Airbyte - ELT
    - dbt - ELT
    - Metabase - Dashboards and reporting 
    - superset - Dashboards and reporting 
    - PostgreSQL - RDBMS
    - Great_Expectations - Data pipeline testing
    - datahub - Data catalog/lineage

- Quantum computing and 3d printing. 
    - Quantum computing  has the potential to break the encryption used to protect sensitive data in the digital world of today and tomorrow.Powerful countries, companies, and universities are pouring money into the task of building a quantum computer powerful enough to perform exponentially faster than the computers of today.Google and IBM use the same basic building block in their machines to create quantum behavior, known as transmon qubits which were invented by NSA.
    - Monitoring 5G successfully requires a deep understanding of what makes it fundamentally different from its predecessors: higher speed, lower range, more distribution nodes, different data protocols.
    - NSA says "In the future, superpowers will be made or broken based on the strength of their cryptanalytic programs"

## 2022-Mar-03 Thu

- Quantum Computing's impact
    -  the most important security and privacy properties to protect in the face of a quantum computer are confidentiality and authentication.
        - quantum computers will not only be able to decrypt on-going traffic, but also any traffic that was recorded and stored prior to their arrival.
        - The threat model for authentication is a little more complex: a quantum computer could be used to impersonate a party in a connection or conversation. 

- [Database Record Access][Databases]
    - Why indexes, 
        - When data is stored on disk-based storage devices, it is stored as blocks of data. These blocks are accessed in their entirety, making them the atomic disk access operation. Disk blocks are structured in much the same way as linked lists; both contain a section for data, a pointer to the location of the next node (or block), and both need not be stored contiguously. Due to the fact that a number of records can only be sorted on one field, we can state that searching on a field that isn’t sorted requires a Linear Search which requires (N+1)/2 block accesses (on average), where N is the number of blocks that the table spans. If that field is a non-key field (i.e. doesn’t contain unique entries) then the entire tablespace must be searched at N block accesses. Whereas with a sorted field, a Binary Search may be used, which has log2 N block accesses. Also since the data is sorted given a non-key field, the rest of the table doesn’t need to be searched for duplicate values, once a higher value is found. Thus the performance increase is substantial.

    - What is indexing?
        - Indexing is a way of sorting a number of records on multiple fields. Creating an index on a field in a table creates another data structure which holds the field value, and a pointer to the record it relates to. This index structure is then sorted, allowing Binary Searches to be performed on it. The downside to indexing is that these indices require additional space on the disk since the indices are stored together in a table using the MyISAM engine, this file can quickly reach the size limits of the underlying file system if many fields within the same table are indexed. 
    - When should it be used?
        - Given that creating an index requires additional disk space (277,778 blocks extra from the above example, a ~28% increase), and that too many indices can cause issues arising from the file systems size limits, careful thought must be used to select the correct fields to index.

## 2022-Mar-10 Thu

- PostgreSQL Learnings, 
    - LEFT JOIN in place of an INNER JOIN helps the planner make more accurate row count predictions. Adding redundant ON clauses improves Hash Joins.
    -  ANY(VALUES ...) instead of IN can enforce a Hash Aggregate with many elements.
    - It’s a bad idea to make the table primary key a varchar.
    - CLUSTER rocks when the query returns many related rows.
    - pg_hint_plan offers powerful hints, including the estimated row count correction Rows, JOIN sequence enforcer Leading, and the index override IndexScan. Though the latter may strike back.
    - https://explain.tensor.ru to visualize EXPLAIN-s.

- When should NOSQL be used?
    - Massive write scaling is required, more than a single server can provide 
    - Only simple data access pattern is required 
    - Strong transactional or data retention guarantees are not required 
    - Unstructured duplicate data that greatly benefits from column compression

- When relational storage be used?
    - Variable workloads and reporting 
    - Easy Administration 
    - Simplified development
    - Strong data retention

- [Postgres High availability with Patroni][Databases][Architecture], 
    - When used in a single datacenter, the environment is typically setup as a 3-node cluster on three separate database hosts. 
    - Basic components, 
        - PostgreSQL cluster: the database cluster, usually consisting of a primary and two or more replicas
        - Patroni: used as the failover management utility
        - etcd: used as a distributed configuration store (DCS), containing cluster information such as configuration, health, and current status.
    - How HA Works, 
        - Each PostgreSQL instance within the cluster has one application database. These instances are kept in sync through streaming replication.
        -  Each database host has its own Patroni instance which monitors the health of its PostgreSQL database and stores this information in etcd. 
        - The Patroni instances use this data to:
            - keep track of which database instance is primary
            - maintain quorum among available replicas and keep track of which replica is the most "current"
            - determine what to do in order to keep the cluster healthy as a whole
            - Patroni manages the instances by periodically sending out a heartbeat request to etcd which communicates the health and status of the PostgreSQL instance. etcd records this information and sends a response back to Patroni. 
        - Streaming replication
            - Keeps replica more up to date compared to file based log shipping. 
            - The standby connects to the primary, which streams WAL records to the standby as they're generated, without waiting for the WAL file to be filled.
            - is asynchronous by default.

- [Database Query performance analysis (MySQL)][Databases] 
    -  lock time greater than 50% of query time is a problem because MySQL should spend the vast majority of its time doing work, not waiting.
    - Locks are primarily used for writes (INSERT, UPDATE, DELETE, REPLACE) because rows must be locked before they can be written. Response time for writes depends, in part, on lock time
    - For reads (SELECT), there are nonlocking and locking reads. The distinction is easy because there are only two locking reads: SELECT…FOR UPDATE and SELECT…FOR SHARE. If not one of those two, the SELECT is nonlocking, which is the normal case.
    - Locking reads should be avoided, especially SELECT…FOR UPDATE, because they don’t scale, they tend to cause problems, and there is usually a nonlocking solution to achieve the same result
    - Rows examined is the number of rows that MySQL accessed to find matching rows. It indicates the selectivity of the query and the indexes. The more selective both are, the less time MySQL wastes examining nonmatching rows.


- [How postgre stores rows][Databases]
    - PostgreSQL stores the actual data into segment files (more generally called heap files). Typically its fixed to 1GB size but you can configure that at compile time using --with-segsize. When a table or index exceeds 1 GB, it is divided into gigabyte-sized segments. This arrangement avoids problems on platforms that have file size limitations but 1GB is very conservative choice for any modern platform. These segment files contain data in fixed size pages which is usually 8Kb, although a different page size can be selected when compiling the server with --with-blocksize option but this size usually falls in ideal size when considering performance and reliability tradeoffs. If the page size is too small, rows won’t fit inside the page and if it’s too large there is risk of write failure because hardware generally can only guarantee atomicity for a fixed size blocks which can vary disk to disk (usually ranges from 512 bytes to 4096 bytes).
    - Internally PostgreSQL maintains a unique row id for our data which is usually opaque to users. We can query it explicitly to see its value.in ctid First digit stand for the page number and the second digit stands for the tuple number. PostgreSQL moves around these tuples when VACUUM is run to defragment the page. 


- [Code Obfuscation types][Security]
    - Name obfuscation - replaces the names of packages, classes, methods, and fields with meaningless sequences of characters. Sometimes the package structure is also modified, which further obscures the names of packages and classes.
    - Flow obfuscation -  modifies code order or the controlflow graph, and string encryption, whic encrypts the constant strings in the code. Some tools may go further and obfuscate the XML files in the resource part of the APK

- [Easier ways of doing things][SystemArchitecture]
    - SSL certificates, with Let’s Encrypt
    - Concurrency, with async/await (in several languages)
    - Centering in CSS, with flexbox/grid
    - Building fast programs, with Go
    - Image recognition, with transfer learning (someone pointed out that the joke in this XKCD doesn’t make sense anymore)
    - Building cross-platform GUIs, with Electron
    - VPNs, with Wireguard
    - Running your own code inside the Linux kernel, with eBPF
    - Cross-compilation (Go and Rust ship with cross-compilation support out of the box)
    - Configuring cloud infrastructure, with Terraform
    - Setting up a dev environment, with Docker
    - Sharing memory safely with threads, with Rust
    - Easier using hosted services
    - CI/CD, with GitHub Actions/CircleCI/GitLab etc
    - Making useful websites by only writing frontend code, with a variety of “serverless” backend services
    - Training neural networks, with Colab
    - Deploying a website to a server, with Netlify/Heroku etc
    - Running a database, with hosted services like RDS
    - Realtime web applications, with Firebase
    - Image recognition, with hosted ML services like Teachable Machine
    - Cryptography, with opinionated crypto primitives like libsodium
    - Live updates to web pages pushed by the web server, with LiveView/Hotwire
    - Embedded programming, with MicroPython
    - Building videogames, with Roblox / Unity
    - Writing code that runs on GPU in the browser (maybe with Unity?)
    - Building IDE tooling with LSP (the language server protocol)
    - Interactive theorem provers (not sure with what)
    - NLP, with HuggingFace
    - Parsing, with PEG or parser combinator libraries
    - ESP microcontrollers
    - Batch data processing, with Spark

- [MySQL][Databases] 
    - frequently dredging up old data is problematic for performance.
    - determine the ideal data model for the access, then use a data store built for that data model
    - Enqueue writes - Use a queue to stabilize write throughput. It allow the application to respond gracefully and predictably to flood of requests that overwhelms the application, or the database, or both.For write-heavy applications, enqueueing writes is the best practice and practically a requirement. Invest the time to learn and implement a queue.
    - Data Partitioning - separating hot and cold data: frequently and infrequently accessed data, respectively. It partitions by Access and it archives by moving the infrequently accessed (cold) data out of the access path of the frequently accessed (hot) data
    - Reference data size limit of a single MySQL instance to 2 or 4 TB (on SSD):
        - 2 TB - For average queries and access patterns, commodity hardware is sufficient for acceptable performance, and operations complete in reasonable time.
        - 4 TB - For exceptionally optimized queries and access patterns, mid- to highend hardware is sufficient for acceptable performance, but operations might take slightly longer than acceptable.
    - Sharding 
        - High cardinality - An ideal shard key has high cardinality (see “Extreme Selectivity”) so that data is evenly distributed across shards. A great example is a website that lets you watch videos: it could assign each video a unique identifier like dQw4w9WgXcQ. The column that stores that identifier is an ideal shard key because every value is unique, therefore cardinality is maximal.
        - Reference application entities - An ideal shard key references application entities so that access patterns do not cross shards. A great example is an application that stores payments: although each payment is unique (maximal cardinality), the customer is the application entity. Therefore, the primary access pattern for the application is by customer, not by payment. Sharding by customer is ideal because all payments for a single customer should be located on the same shard.
        - When opting for sharding, plan to accomodate at least four years of data growth.
        - ProxySQL and Vitess are middlewares (between app and MySQL) that support sharding by several mechanisms.
    - A common misconception is that the application needs thousands of connections to MySQL for performance or to support thousands of users. This is patently not true. The limiting factor is threads, not connections—more on Threads_running in a moment. A single MySQL instance can easily handle thousands of connections. I’ve seen 4,000 connections in production and more in benchmarks. But for most applications, several hundred connections (total) is more than sufficient. If your application demonstrably requires several thousand connections, then you need to shard.
    - MySQL runs one thread per client connection 
    - One CPU Core runs one thread.When the number of threads running is greater than the number of CPU cores, it means that some threads are stalled - waiting for CPU Time.
    - Four metrics count the occurrence of SELECT statements that are usually bad for performance:
        - Select_scan
        - Select_full_join
        - Select_full_range_join
    - Database Capacity planning
        - the four-year fit is an estimate of data size or access in four years applied to the capacity of your hardware today
        - It’s better to be more precise and collect table sizes every 15 minutes.Near-term data growt trending is used to estimate when the disk will run out of space. Long term trend is used to estimate when sharding is necessary.
    - A deadlock occurs when two (or more) transactions hold row locks that the other transaction needs



- [Database Workloads][Databases] 
    - OLTP
        - Characterstics, 
            - Inserts, updates, and deletes only affect a single row. An example: Adding an item to a user’s shopping cart.
            - Read operations only read a handful of items from the database. An example: listing the items in a shopping cart for a user.
            - Aggregations are used rarely, and when they are used they are only used on small sets of data. Example: getting the total price of all items in a user their shopping cart.
        - Relevant benchmarks
            - Throughput in TPS (transactions per second)
            - Query latency, usually at different percentiles (p95, etc.)
    - OLAP 
        - Characteristics, 
            - Periodic batch inserts of data. 
            - Read operations often read large parts of the database.
            - Aggregations are used in almost every query.
            - Queries are large and complex. 
            - Not a lot of concurrent users 
        - Relevant benchmarks
            - How long it took to run all of the queries that are part of the benchmark
            - How long it took to run each of the queries, measured separately per query 
    - HTAP (Hybrid transactional/analytical processing)
        - Combines characteristics from OLTP and OLAP
    - Important questions while benchmarking 
        - Is it running on production infrastructure? A lot more performance can usually be achieved when critical production features have been disabled. Things like backups, High Availability (HA) or security features (like TLS) can all impact performance.
        - How big is the dataset that was used? Does it fit in RAM or not? Reading from disk is much slower than reading from RAM. So, it matters a lot for the results of a benchmark if all the data fits in RAM.
        - Is the hardware excessively expensive? Obviously a database that costs $500 per month is expected to perform worse than one that costs $50,000 per month.
        - What benchmark implementation was used? Many vendors publish results of a TPC benchmark specification, where the benchmark was run using a custom implementation of the spec. These implementations have often not been validated and thus might not implement the specification correctly.

- [Web Application Monitoring][Architecture][Observability] 
    - Metrics to observe for Web Applications
        - Response Time p50, p90, p99, sum, avg 
        - Throughput by HTTP status 
        - Worker Utilization 
        - Request Queuing Time 
        - Service calls 
        - Database(s), caches, internal services, third-party APIs, ..
        - Enqueued jobs are important!
        - Circuit Breaker tripping  
        - Errors, throughput, latency p50, p90, p99
        - Throttling 
        - Cache hits and misses % 
        - CPU and Memory Utilization
        - Exception counts 

    - Metrics to observe for Web Applications
        - Job Backend (e.g. Sidekiq, Celery, Bull, ..)
        - Job Execution Time p50, p90, p99, sum, avg 
        - Throughput by Job Status {error, success, retry} 
        - Worker Utilization 
        - Time in Queue  
        - Queue Sizes  
        - Don’t forget scheduled jobs and retries!
        - Service calls p50, p90, p99, count, by type 
        - Throttling 
        - CPU and Memory Utilization
        - Exception counts  
    - Relevant Metrics should be available to slice by endpoint or job, tenant_id, app_id, worker_id, zone, hostname, and queue (for jobs).
    - In absense of observability setup, start with logs. For Format, consider using https://stripe.com/blog/canonical-log-lines

    - Key Non-functional aspects of a Payments System
        - Reliability and fauly tolerance 
        - Reconciliation 

    - Non relational databases are good for below requirements, 
        - Application requires super-low latency
        - Data is unstructured or no relational data
        - Only need to serialize/de-serialize data 
        - Store massive amount of data

    - Message queues provide Decoupling, async processing which is good for scalability of applications
    - Idempotency in API, 
        - idempotency key is usually a unique value that is generated by the client and expires after a certain period of time. A UUID is commonly used as an idempotency key and it is recommended 
        - To perform an idempotent payment request, an idempotency key is added to the HTTP header <idempotency-key: key_value>
        - an idempotency key is sent to the payment system as part of the HTTP request
        - For the second request, it’s treated as a retry because the payment system has already seen the idempotency key. When we include a previously specified idempotency key in the request header, the payment system returns the latest status of the previous request. 
        - If multiple concurrent requests are detected with the same idempotency key, only one request is processed and the others receive the “429 Too Many Requests” status code. 
        - To support idempotency, we can use the database's unique key constraint.


- What is Observability?
    - Observability means gaining visibility into the internal state of a system. It’s used to give users the tools to figure out what’s happening, where it’s happening, and why. At Cloudflare, we believe that observability has three core components: monitoring, analytics, and forensics. Monitoring measures the health of a system - it tells you when something is going wrong. Analytics give you the tools to visualize data to identify patterns and insights. Forensics helps you answer very specific questions about an event.


- [Perspectives on Software Development][SystemArchitecture],
    1.	Don’t fight the tools: libraries, language, platform, etc. Use as much native constructs as possible. Don’t bend the technology, but don’t bend the problem either. Pick the right tool for the job or you’ll have to find the right job for the tool you got.
    2.	You don’t write the code for the machines, you write it for your colleagues and your future self (unless it’s a throw away project or you’re writing assembly). Write it for the junior ones as a reference.
    3.	Any significant and rewarding piece of software is the result of collaboration. Communicate effectively and collaborate openly. Trust others and earn their trust. Respect people more than code. Lead by example. Convert your followers to leaders.
    4.	Divide and conquer. Write isolated modules with separate concerns which are loosely coupled. Test each part separately and together. Keep the tests close to reality but test the edge cases too.
    5.	Deprecate yourself. Don’t be the go-to person for the code. Optimize it for people to find their way fixing bugs and adding features to the code. Free yourself to move on to the next project/company. Don’t own the code or you’ll never grow beyond that.
    6.	Security comes in layers: each layer needs to be assessed individually but also in relation to the whole. Risk is a business decision and has direct relation to vulnerability and probability. Each product/organization has a different risk appetite (the risk they are willing to take for a bigger win). Often these 3 concerns fight with each other: UX, Security, Performance.
    7.	Realize that every code has a life cycle and will die. Sometimes it dies in its infancy before seeing the light of production. Be OK with letting go. Know the difference between 4 categories of features and where to put your time and energy: Core: like an engine in a car. The product is meaningless without it. Necessary: like a car’s spare wheel. It’s rarely used but when needed, its function decides the success of the system. Added value: like a car’s cup-holder. It’s nice to have but the product is perfectly usable without it. Unique Selling Point: the main reason people should buy your product instead of your rivals. For example, your car is the best off-road vehicle.
    8.	Don’t attach your identity to your code. Don’t attach anyone’s identity to their code. Realize that people are separate from the artifacts they produce. Don’t take code criticism personally but be very careful when criticizing others’ code.
    9.	Tech debt is like fast food. Occasionally it’s acceptable but if you get used to it, it’ll kill the product faster than you think (and in a painful way).
    10.	When making decisions about the solution all things equal, go for this priority:
    **Security > Reliability > Usability (Accessibility & UX) > Maintainability > Simplicity (Developer experience/DX) > Brevity (code length) > Finance > Performance**
    But don’t follow that blindly because it is dependent on the nature of the product. Like any career, the more experience you earn, the more you can find the right balance for each given situation. For example, when designing a game engine, performance has the highest priority, but when creating a banking app, security is the most important factor.
    11.	Bugs’ genitals are called copy & paste. That’s how they reproduce. Always read what you copy, always audit what you import. Bugs take shelter in complexity. “Magic” is fine in my dependency but not in my code.
    12.	Don’t only write code for the happy scenario. Write good errors that answer why it happened, how it was detected and what can be done to resolve it. Validate all system input (including user input): fail early but recover from errors whenever possible. Assume the user hold a gun: put enough effort into your errors to convince them to shoot something other than your head!
    13.	Don’t use dependencies unless the cost of importing, maintaining, dealing with their edge cases/bugs and refactoring when they don’t satisfy the needs is significantly less than the code that you own.
    14.	Stay clear from hype-driven development. But learn all you can. Always have pet projects.
    15.	Get out of your comfort zone. Learn every day. Teach what you learn. If you’re the master, you’re not learning. Expose yourself to other languages, technologies, culture and stay curious.
    16.	Good code doesn’t need documentation, great code is well documented so that anyone who hasn’t been part of the evolution, trial & error process and requirements that led to the current status can be productive with it. An undocumented feature is a non-existing feature. A non-existing feature shouldn’t have code.
    17.	Avoid overriding, inheritance and implicit smartness as much as possible. Write pure functions. They are easier to test and reason about. Any function that’s not pure should be a class. Any code construct that has a different function, should have a different name.
    18.	Never start coding (making a solution) unless you fully understand the problem. It’s very normal to spend more time listening and reading than typing code. Understand the domain before starting to code. A problem is like a maze. You need to progressively go through the code-test-improve cycle and explore the problem space till you reach the end.
    19.	Don’t solve a problem that doesn’t exist. Don’t do speculative programming. Only make the code extensible if it is a validated assumption that it’ll be extended. Chances are by the time it gets extended, the problem definition looks different from when you wrote the code. Don’t overengineer: focus on solving the problem at hand and an effective solution implemented in an efficient manner.
    20.	Software is more fun when it’s made together. Build a sustainable community. Listen. Inspire. Learn. Share.


- [MySQL Replication][Databases] 
    - Typical issues
        - Temporary lag - caused by cold cache after restart
        - Occasional lag - caused by write burst or long transactions 
        - Perpetual lag - Slaves almost never catch up
        - How to avoid lags 
            - avoid long transactions
            - manage batches
            - increase replication throughput 
            - Alternative is to Shard
        - Some use cases for replication, 
            - backups are faster and less disruptive on slaves than master
            - reading from slaves helps in resilience (when master is down or loaded)
    - How to monitor lag - Either Pg_heartbeat from percona toolkit or "second behind master" from "show slave status"


- SQLite - Litestream - How it works 
    -  In WAL-mode (the mode you very much want on a server, as it means writers do not block readers), SQLite appends to a WAL file and then periodically folds its contents back into the main database file as part of a checkpoint. Litestream interposes itself in this process: it grabs a lock so that no other process can checkpoint. It then watches the WAL file and streams the appended blocks up to S3, periodically checkpointing the database for you when it has the necessary segments uploaded.
    - Storing integers instead of floating point numbers is much more efficient as SQLite does not compress floats.
    
     
- [Database Indexes][Databases]
    - Cardinality is the inverse of "the number of records returned per value." High cardinality returns one record per index value, and low cardinality returns many records per index value. Efficient indexes are high-cardinality indexes. Primary keys are the best example of a high-cardinality index. String-based tags are an example of a low-cardinality index because there are typically many objects assigned to a single tag.Build the indexes to match your query needs, and note that high-cardinality is faster.
    - Table scan happens when no suitable index exists.When using a table scan, the database keeps all of the records in RAM while comparing values.    
    - All databases employ some level of copy-on-write. Postgres writes a new version of a row each time it inserts or updates a value. Other databases have a block-size allocated for a value, then, if an updated value exceeds the size, it writes to a new location. Other databases reject updates, claim immutability, and push the tracking of updates off to the application developer.

- Apache Parquet 
    - language-independent storage format, designed for online analytics, so:
        - Column oriented
        - Typed
        - Binary
        - Compressed
    - A Parquet file stores data column-oriented on the disk, in batches called "row groups".
    - Parquet storage can provide substantial space savings.
    - Parquet storage is a bit slower than native storage, but can offload management of static data from the back-up and reliability operations needed by the rest of the data.

- gRPC and REST
    - Allows browser apps to call gRPC services as RESTful APIs with JSON. The browser app doesn’t need to generate a gRPC client or know anything about gRPC.
        - grpc-gateway is another technology for creating RESTful JSON APIs from gRPC services. It generates reverse proxy to convert RESTFUL calls to gRPC and vice versa
        - gRPC JSON transcoding runs inside an ASP.NET Core app. It deserializes JSON into Protobuf messages, then invokes the gRPC service directly.JSON transcoding deserializes JSON to Protobuf messages and invokes the gRPC service directly. There are significant performance benefits in doing this in-process vs. making a new gRPC call to a different server.

- Cryptography, Crypto economics etc.
    - Hashing use cases - To verify the sendor , Password storage , Time-stamping
    - Public key encryption
        - Message encrypted usng public key can  be decrypted using private key and vice-versa. 
        - Digital Signature - Message is encrypted using private key but can be decrypted using public key.
    - transposition cypher, replacing each letter in a sentence with a different letter, say, the next in the alphabet
    - transposition cypher with random key is difficult to decrypt.
    - in 1976 Whitfield Diffie and Martin Hellman created a new kind of cryptography, one that allowed for secure communication of a secret key over an insecure network.Diffie and Hellman revolutionized cryptography by proving that a secret key could be distributed over an insecure network.
    - RSA, showed that the key used to encrypt a message did not have to be the same as the key used to decrypt a message.
        - Using RSA, two keys are created public and private. Public key is shared.  Public key is used to encrypt a message which can only be decrypted using private key. It works reverse too i.e. encryption using private key and decryption using public key. 
    - Message services such as WhatsApp and Signal also use Diffie-Hellman algorithms so that people across the world can communicate securely. 
    - Each smart card has a unique public key known to the credit card com- pany, say Visa, and a corresponding private key stored on the chip in the card. When the card is presented for payment,Visa sends it a random number. The chip in the card encrypts the random number using its private key and sends the encrypted message back to Visa.Visa then attempts to decrypt the message using the card’s public key. If the decrypted message reveals the random num- ber sent by Visa, then Visa knows exactly which card is being used.
    - A digital signature is a message that can only be decrypted using Publius’s public key.
    - A cryptographic hash is like a digital fingerprint, a much shorter message that in practice can be uniquely associated with any message.a cryptographic hash function takes any data as input and out- puts a digital fingerprint of that data, an essentially unique ID such that if any piece of the data is ever changed it won’t hash to the same ID. 
    - SHA256 algorithm converts any input to a 256 digit long hash consisting of 0's and 1's.
        - Hash functions like SHA256 are collision-resistant that is it is infeasible to find two messages with the same hash.
    - Digital Signatures offer, 
        - Authenticity means that a digital signature is strong evidence that the signer has the identity associated with the public key.
        - The integrity of the message is provided by comparing the message hash within the signature with the hash of the message. 
        -  since only the holder of the private key can sign the digital signature, the signer cannot repudiate having signed the document.

    -  NFT - An NFT is just a cryptographic hash of an art- work (or other digital file) signed with a digital signature
    - How Bitcoin network works - When Alice wants to send Bob a bitcoin she doesn’t contact her bank or Visa or Stripe. Instead she broadcasts a message to the bitcoin network that says “I authorize a transfer of bitcoin to Bob. Here’s my digital signature.” Bitcoin “miners” listen for transaction messages, verify that the transactions are valid and compile them into blocks. In about 10 min- utes (we explain why it takes 10 minutes further below) a block with Alice’s new transaction will be added to the blockchain. Anyone in the world can then verify that Alice transferred a bitcoin to Bob and if Bob wants to make a subsequent transaction with Tom anyone can verify that he has the funds to do so. Alice has no contract with the miners and they are not obligated to pro- duce blocks.
    - Why bitcoin mining is computationally expensive -  bitcoin miners must try trillions of hashes to find the rare hash to deploy block onto the blockchain. 
    -  blockchain makes data more secure because tampering with one element requires changing every subsequent block
    - A smart contract is a kind of contract where the performance is guaranteed by software instead of by lawyers and judges
    - CryptoCurrency
        -  an electronic payment system based on cryptographic proof instead of trust, allowing any two willing parties to transact directly with each other without the need for a trusted third party. 
        - Bitcoin is basically Public key and associated balance of bitcoins. Owner as corresponding private key which allows him to trade. Combination of public and private key is enough to define a coin. Cryptocurrency is called cryptocurrency because it’s a currency derived from cryptography. Every transaction of bitcoin is broadcasted to entire network so everyone who maintains ledger can update it.
    	- Mining the bitcoin involves taking the hash of the previous block, plus the transactions that have come in since then, plus a new nonce, and try to find a new hash.Each miner takes a summary of the list of transactions in the block, along with a hash of the previous block. Then the miner sticks another arbitrary number—called a “nonce”—on the end of the list. The miner runs the whole thing (list plus nonce) through a SHA-256 hashing algorithm. This generates a 64-digit hexadecimal number. If that number is small enough, then the miner has mined the block. If not, the miner tries again with a different nonce.



- Data science use cases
    - Spelling corrections 
        - Dictionary approach - Involves creating a dictionary of correctly spelled words and then 
        - Classify it - identify misspelled words
        - Recommendation - Present possible corrections 
        - Transformation - automatically replace with corrections.Has certain limitations like lack of regular updates to word list for slang words, proper names; it can autocorrect grammatical errors.
    - Data intensive approach - Corpus consisting of compilation of text is prepared. This has certain advantages like language-specific dictionary is not needed. It can show words in context unlike Dictionary approach with does word by word checks.
        - Speech Recognition / Speech to text 
        - Its hard because, 
            - Speech is analog and each person’s speech is a little bit different, whereas every typist
            who transposes the “ie” in “belief” ends up with exactly the same result, “beleif.”
            - Speech has systematic variation due to different accents, mixed language, speech
            impediments, random variation due to background noise, and multiple people speaking
            at once.
            - Speech has ambiguity due to homophones as well as the absence of capitalization and
            punctuation.
            - Transcription errors can be distracting to users, but are usually not life-threatening. Risks
            related to errors, could prevent ASR’s use in applications where an error would cause
            great harm.
        - This area is dominated by neural networks. They can learn to compensate for accents and user-supplied corrections to system errors. 
    - Music Recommendation 
        -  These systems recommend a user's next song, movie, book, app, or romantic partner.
        - The recommendation system builds a model from three types of data: a song's waveform, a song's metadata (title, artist, genre, composer, date recorded, length, etc.), and listener reactions. A “reaction” may be passively listening to the currently playing song, or it may be actively starting, skipping or replaying a song, or rating it with a star or a thumbs down.A song's waveform can be analyzed for tempo, beat, timbre, and other factors. The system can recommend a song with similar features to songs that the user has previously liked or, for variety, perhaps recommend a contrasting song. The recommendations can be specialized for activity or time of day; perhaps fast, energetic songs for exercising and slow mellow songs at the end of the day. Metadata can be applied in many ways and even extended to permit creation of predictive,semantic relations between its entities.
        - Collaborative filtering builds on this idea to examine the songs a listener has liked (or disliked), and compares them to every other listener’s reactions. When it finds a similar history, the songs that the user likes can be recommended to each other.
        - How approaches apply in the field of investment management, 
            - Momentum investing based on understanding what others are doing is analogous to
            collaborative filtering.
            - Fundamental investing based on knowledge of an investment’s business is analogous to using semantic knowledge.
            - Technical investing based on raw stock prices and market volumes is analogous to musical signal analysis.
    - Protein folding 
        - Healthcare 
        - Prediction about patients more  at risk of developing diseases so as to benefit from preventive actions. 



- Types of databases and related industries/use cases
    - Relational - Lift and shift, Finance, ERP , CRM 
    - Key-value - Real-time bidding, shopping cart, social , product catalog, customer preferences 
    - Document - Content Mgmt, Personalization, Mobile
    - In-memory - Leaderboards, real-time analytics, caching
    - Graph - Fraud detection, social networking, recommendation engine 
    - Time-series - IoT, event tracking 
    - Ledger - System of records, supply chain, healthcare, registrations, financial.


- Asynchonicity, Queues  [Src](https://www.youtube.com/watch?v=bHSV916YbHE&feature=youtu.be)
    - "Asynchronous" - Your application sends a message or event and then carries on doing something else. It does not sit around waiting for an outcome.
    - asynchronous messaging infrastructure does,
        * Decoupling: A system handling work behind a messaging infrastructure can be running at capacity and yet not be overwhelmed and can even be down while the messaging infrastructure still accepts messages on its behalf.
        * Delivery: You can entrust over your messages and the messaging system will try its best not lose them. It will then attempt to deliver them to the right parties and will retry as often as necessary.
        * Buffering: A messaging infrastructure is generally great at accepting bursts of messages at once and organizing them for later retrieval. The retrieval can then occur at the pace that your application can handle. That is also called load-leveling.
        * Network-Bridging: Messaging infrastructures can often be attached to multiple networks, allowing information to pass between applications in those networks without there being IP-level connectivity between them.
    - Queues are One of the most fundamental and most important data structures in computing 
        - Sequence of records , commonly ordered by moment of arrival
        - Write/add at the bottom , read/consume at the top 
        - Consumed records are removed
        - Length of queue can always be read 
    - Characteristics of Message queues 
        - Accepts, stores and makes message available for consumption 
        - Queue individually manages lifecycle of each message
        - Each mesage is exclusively acquired by one consumer
        - The queue length can be queried
    - Kafka is not a "message queue"
        - Messages are acquired by consumer groups 
        - consumer groups can query topic back and forth.
        - Its event streaming engine
        - Use cases
            - Load leveling - allows a business process to handle transactions at optimal capacity use and without getting overwhelmed.Spiky loads are buffered by the queue until the processor can handle them .
            - Discrete event router - Push style distribution of discrete events to serverless workloads or other messaging infrastructures (Azure event grid)
            - Queue pub/sub broker - Pull-style, queue based transfer of  jobs (RabbitMQ)
            - Event Stream engine - Partitioned, high volume, sequential recording and unlimited pull style re-reads of event streams. (kafka, pulsar) 
            - Event stream aggregator - Stateful processing of event streams yielding event streams (Apache samza, apache flink)

- New Techniques in Browser, 
    - For Server-sent events, 
        - The EventSource interface is web content's interface to server-sent events. An EventSource instance opens a persistent connection to an HTTP server, which sends events in text/event-stream format. The connection remains open until closed by calling EventSource.close().
        - Unlike WebSockets, server-sent events are unidirectional; that is, data messages are delivered in one direction, from the server to the client (such as a user's web browser). That makes them an excellent choice when there's no need to send data from the client to the server in message form. For example, EventSource is a useful approach for handling things like social media status updates, news feeds, or delivering data into a client-side storage mechanism like IndexedDB or web storage.
        - Example of Public API using this technique - https://wikitech.wikimedia.org/wiki/Event_Platform/EventStreams 


- HTTP/3
    - TCP has been cornerstone protocol and http runs on top of it.
    - QUIC is intended to replace TCP and HTTP/3 is small adaptation of HTTP/2 to run top of it.
    - QUIC is a generic transport protocol which can be used for HTTP. It runs on top of UDP. QUIC essentially reimplements almost all features that make TCP such a powerful and popular (yet somewhat slower) protocol
    - HTTP/3 isn’t magically faster than HTTP/2 just because we swapped TCP for UDP.
    - QUIC deeply integrates with TLS.
    - QUIC supports multiple independent byte streams.
    - QUIC uses connection IDs. Faster connection setup
    - QUIC uses frames.
    - QUIC is more secure as its not possible to transport cleartext

- Data oriented programming 
    - `lscpu` command shows info about CPUs 
    - Each CPU Core, 
        - Has L1 cache
        - May share L2 cache with other cores 
        - shares L3 Cache with all other CPU cores
        - L1 is fastest 
    - All operations between Core and L1/L2/L3 cache are way faster than accessing main memory 
    - Crux is "Identify where you have many objects in memory and make the size of each object smaller 
    - Every construct (e.g. struct) has natural alignment and size. 
    - Strategies to reduce memory footprint, 
    - 64 bit CPUs can access more RAM but they also consume more memory (for e.g. 32 bit for pointer whereas its 16-bit on 32-bit CPUs). Consider avoiding pointers and use indexes. 
    - store boolean out of band. (out of struct) 
    - Eliminate padding with having struct of Arrays. 
    - Store sparse data in separate hashmap than as part of struct. 

- On Estimation 
    - estimation is valuable when it helps you make a significant decision.
    - Estimation is useful when it helps with coordination within teams

- Cypress.io - End to end test platform
    - Cypress takes screenshots as tests run 
    - automatically reloads when tests are changed
    - Waits for commands and assertions 
    - is not a general purpose tool like for indexing the web.
    - Only JS is supported for test cases
    - Each test is bound to single domain.

- Vaccum in PostgreSQL
    - Postgres uses Multiversion Concurrency Control (MVCC) to guarantee isolation while providing concurrent access to data. This means multiple versions of a row can exist in the database simultaneously. So, when rows are deleted, older versions are still kept around, since older transactions may still be accessing those versions. Once all transactions which require a row version are complete, those row versions can be removed. This can be done by the VACUUM command. 

- Unix Philosophy, 
    1. Make each program do one thing well. To do a new job, build afresh rather than complicate old programs by adding new “features”.
    2. Expect the output of every program to become the input to another, as yet unknown, program. Don’t clutter output with extraneous information. Avoid stringently columnar or binary input formats. Don’t insist on interactive input.
    3. Design and build software, even operating systems, to be tried early, ideally within weeks. Don’t hesitate to throw away the clumsy parts and rebuild them.
    4. Use tools in preference to unskilled help to lighten a programming task, even if you have to detour to build the tools and expect to throw some of them out after you’ve finished using them.
    5. In Unix, file descriptor is an interface which can be used to represent things like actual file on filesystem, Communication channel to other process, a device driver, a TCP socket etc.

- Quantum resistant Encryption 
    - Problem: Quantum computers will be able to break current cryptography schemes (mainly asymmetric encryption, like RSA) easily.
    - Solution: Use Lattice-based (a mathematical concept) Encryption, which is currently believed to be hard for quantum computers to solve efficiently.
    - In Sum: Quantum computers are becoming an imminent problem. We as developers need to start thinking about implementing post-quantum cryptography algorithms to protect them now before it’s too late.
    - Prepare for the future: Post-quantum cryptography is around the corner (Q-day), and starting to spread awareness and implementing strong encryption mechanisms today is important for that future. 
    - Hidden advancements: The biggest quantum computer we know about is currently IBM’s Eagle with 127 stable qbits, planning to reach 433 in 2022. The question is, what about bad actors and rogue nation-states working on quantum computers we don’t know about? They might reach quantum supremacy a lot sooner than we anticipate.
    - Hack now, decrypt later: There are threat actors that save ciphertexts from hacked targets right now, to later decrypt them with quantum computers. This means that sensitive information sent today is still prone to attack.
    - Most promising: At the moment, lattices seem like the best candidates to secure against quantum computers

- Distributed Systems 
    - The closer the processing and caching of your data is kept to its persistent storage, the more efficient your processing, and the easier it will be to keep your caching consistent and fast. Networks have more failures and more latency than pointer dereferences and fread(3).
    -  Extract services. “Service” here means “a distributed system that incorporates higher-level logic than a storage system and typically has a request-response style API”. Be on the lookout for code changes that would be easier to do if the code existed in a separate service instead of in your system. An extracted service provides the benefits of encapsulation typically associated with creating libraries
    - "Feature flags” are a common way product engineers roll out new features in a system. Feature flags are typically associated with frontend A/B testing where they are used to show a new design or feature to only some of the userbase.
    - Exposing metrics (such as latency percentiles, increasing counters on certain actions, rates of change) is the only way to cross the gap from what you believe your system does in production and what it actually is doing.
    - Find ways to be partially available. Partial availability is being able to return some results even when parts of your system is failing.
    - Implement backpressure throughout your system. Backpressure is the signaling of failure from a serving system to the requesting system and how the requesting system handles those failures to prevent overloading itself and the serving system. Designing for backpressure means bounding resource use during times of overload and times of system failure. This is one of the basic building blocks of creating a robust distributed system.

- Javascript on web, 
    - JavaScript is known as a “render-blocking” resource. This means when a browser encounters JavaScript it goes through a multistep process which involves it being downloaded, then uncompressed, before it’s finally parsed and executed. This all happens within a device's available Central Processing Unit (CPU) and memory. These tasks can be very slow and energy intensive depending on the device and connection. 
    - Images and image data aren't “render-blocking”, meaning parts of the webpage can be painted to the page while additional image data is being downloaded in parallel. Therefore, a 32 Kb image has much less of a performance impact than 32 Kb of compressed JavaScript. This is especially true for users on low specification devices that are generally slower, older and less expensive.

- Cassandra - NOSQL Database 
    - Features
        - Linear Scalability
        - Automatic Failover
        - Low Maintenance
        - Predictable Performance 
    - Data Modelling
        - KKV Store 
            - The first K is the partition key and is used to determine which node the data lives on and where it is found on disk. The partition contains multiple rows within it and a row within a partition is identified by the second K, which is the clustering key. The clustering key acts as both a primary key within the partition and how the rows are sorted. 
        - Schemas are cheap to alter without performance penalty
    - it trades strong consistency for availability
    - Reads are expensive than writes 
    - Scylla, a Cassandra compatible database written in C++

- On Minimum Viable Product 
    - Lets you objectively measure customer response fast and then tweak
    - so cheap and fast to build, you can try lots of different ones, add and remove advertised features, and see how that changes user responses
- Market Niche -  If you can name a conference attended by a particular group of people, that group is a market niche.

- Triggers for choosing service boundaries, 
    - Security isolation could be one of the trigger for splitting functionalities in services.
    - Monolith taking long time to startup. This makes upgrades painful. so you might want to split out the slow part to make upgrading other things go faster.
    - Do some parts scale differently from other parts? 
    - Do expensive requests need to be run with less parallelism?  - If solution is to use messaging i.e. relaying messages through queue/broker then be vary of Queue Explosion which generates heavy load on message brokers. Alternatives are HTTP based (REST, gRPC) services or Messaging based on peer to peer or routed protocols (where instead of sending messages to a broker which persists messages, messages are either sent directly to another consumer via a point-to-point network connection or are sent to a router which immediately sends the message to a consumer) using say ZeroMQ or Apache QPID Proton 

- System Characteristics (Quality Attribute Requirements) 
    - Concurrency—relating to the number of concurrent users, sensors, and other devices that create events to which the product must respond.
    - Throughput—relating to the volume of transactions or data that the product must be able to process over a defined time period.
    - Latency and responsiveness—relating to how quickly the product must respond to events.
    - Scalability—relating to the ability of a system to handle an increased workload by increasing the cost of the system, general in a near-linear relationship.
    - Persistency—relating to the throughput and structure (or lack thereof) of data that must be stored and retrieved by the product. Often includes decisions about different kinds of data storage technologies (e.g. SQL DBMS, NoSQL DBMS, etc.). 
    - Security—relating to how the product will protect itself from unauthorized use or access to product data, by achieving confidentiality, integrity, and availability.
    - Monitoring—relating to how the product will be instrumented so that the people who support the product can understand when the product starts to fail to meet QARs and prevent critical system issues.
    - Platform—relating to how the product will meet QARs related to system resource constraints such as memory, storage, event signaling, etc. For example, real-time and embedded products (such as a digital watch, or an automatic braking system) have quite different constraints than cloud-based information systems.
    - User interface—relating to decisions made about how the product will communicate with users; for example, virtual reality interfaces have quite different QARs than 2-dimensional graphical user interfaces, which have quite different QARs than command-line interfaces. These decisions may affect other QARs noted above. (GUI, VR, command line, or other kinds of interfaces.)

- Networking 
	- MAC addresses: All devices that people use to ac- cess the Internet have been assigned an identifier by the device manufacturer. This is the media access control (MAC) address, sometimes also called hard- ware address or burned-in address. The standards for MAC addresses are set by the Institute of Electri- cal and Electronics Engineers (IEEE), a US-based pro- fessional association. The most used addresses are 48-bit long, which allows for 248, i.e., more than 281 trillion, possible MAC addresses
	- Radio Access Networks: This term is specifically used for the radio connection of mobile phones to antennas that are connected to the wired core net- work of mobile network operators and the Internet at large. RAN standards are ordered into generations (e.g., 3G, 4G, 5G) and set by the industrial partner- ship 3GPP and the ITU. 
	- Wide Area Networks (WANs): Companies may think that the public packet-switched Internet is too unre- liable, insecure, and path-agnostic for connecting their sites. Hence, they may use a layer 2 WAN to connect different locations of offices, production sites, and stores belonging to the same company. One option for a WAN is for companies to lease a private communications circuit from an ISP, which reserves a specific amount of bandwidth for them. The downside of leased lines is that they are expen- sive. An alternative is the use of multiprotocol label switching (MPLS). This is a “layer 2.5” protocol that adds an additional label on IP-packets which con- tains a predetermined route.A more recent alternative is the use of software-de-fined networking.66 Its key feature is that the rules for how to forward data packets are computed in and then distributed from a central location to switches or routers in the entire network. In its ter- minology, the forwarding rules are the control plane, whereas the switches or routers that implement the forwarding are called the data plane. A software-de- fined WAN (SD-WAN) is generally cheaper than MPLS.
	- Network Layers
		- IPV4 (32) bit that can have upto 4.3 billion unique addresses while IPv4(128) bit can have 340 trillion trillion trillion unique IPv6 addresses.

- Stable Diffusion
	- Open source image synthesis model that generates images basis natural language
	- Can be run on PC with GPU
	- Uses technique called Latent diffusion - the model learns to recognize familiar shapes in a field of pure noise, then gradually brings those elements into focus if they match the words in the prompt.
	-  the model associates words with images thanks to a technique called CLIP (Contrastive Language–Image Pre-training), which was invented by OpenAI
	- As per authors, Stable diffusion will run on smartphones in future.

- Aspects in Building Systems
    -	Defining Requirements - work with the Product Manager to understand what problem they want to solve; maybe you’ll have some ideas on how to solve it with much lower effort?
    -	Defining NFR’s - talk to your PM about the non-functional requirements - how many users should the System handle, what are the requirements for performance, throughput, latency? Are there any security or compliance considerations? Do we need auditing? What’s the desired availability?
    -	Planning Iterations - work with your team to propose an implementation plan; make sure you define small, demoable milestones, so that you can start delivering value ASAP; agree with the PM on the milestones.
    -	Determining Dependencies - make sure you identified all the dependencies outside of your team and work with your EM or with the teams directly to get some ETA’s for them. Adjust your milestones accordingly.
    -	Testing - depending on how your company operates, decide on your testing strategy with your team or with the QE team. Agree on the quality threshold needed for the rollout (e.g. no unresolved Major bugs or test coverage above X%).
    -	Deployment - work with your team to decide how the system will be deployed. Do you need some new infrastructure for it or can you reuse the existing? If you need a lot of it, what will be the cost?
    -	Observability - decide how are you going to monitor the health of the system and set up processes for solving production issues (e.g. team on-call). Use a third-party solution (like Sumo Logic) to set up monitors and dashboards for that purpose.
    -	Rollout Communication - once you agree on a rollout date with your team and the PM, make sure that all stakeholders are aware of it. Check whether any documentation changes are required.
    -	Measuring Success - decide on metrics that will tell you whether the project was a success. Is anyone using the new system? Do users manage to accomplish their tasks? You can leverage your Observability suite for this purpose.

- Code Hale on Organizations,
	- Centralize Decision making and vision
	- Create a small group of people who are on same page, open to new ideas,be imperical, have small meetings and make decision quickly. 
	- then decentralize for execution. give developers autonomy. 
	- avoid exponential bikeshading

- Statistics 
	- Median
		- If set of values are odd then, the middle value when ordered is Median
		- If set of values are even then, the average of 2 middle values is Median
		- Median is not affected by outliers (Extremes in data set)
	- Mean 
		- Some of all the values in set divided by number of values 
		- Mean gets impacted by outliers. 
	- Standard deviation - measures the average distance , the data values are, from the mean (average).
    	- It can not be negative 
	- Rounding rule - Always round the number to one more additional digit.
    - Standard deviation
		- Data value outside of 3 times standard deviation (from mean) is extremely rare.
	- Z-score - # of standard deviations away from the mean a data value is.
	- Quartiles 
		- 1st Quartile - bottom 25% of ordered set 
		- 2nd Quartile - bottom 50% (median) of ordered set 
		- 3rd quartile - bottom 75% of ordered set (excluding median)
	- Percentiles - separates data into hundred parts
		- percentile of x = [count (values)  less than x/ total # of values]*100
    - Probability
        - Observed probability (What did happen) - Estimated based on observation
        - Classical probability (what should happen) - Based on change of an event occuring.
        - Subjective Probability - Educated guess. No data available.


- WebAuthn is a protocol for using hardware devices in order to authenticate users by proof of ownership. The basic idea is that you have a hardware security module of some kind (such as an iPhone’s Secure Enclave or a Yubikey) that contains a private key, and then the server validates signatures against the public key of the device to authenticate sessions. It is also set up so that phishing attacks are impossible to pull off, each WebAuthn registration is bound to the domain it was set up with. A keypair for xeiaso.net cannot be used to authenticate with evil-xeiaso.net. The user experience is fantastic. A website makes a request to the authentication API and then the browser spawns an authentication window in such a way that cannot be replicated with web technologies. The browser itself will ask you what authenticator you want to use (usually this lets you pick between an embedded hardware security module or a USB security key) and then proceed from there. It is impossible to phish this. Even if the visual styles were copied, the authenticator will do nothing to authenticate the browser!
    - An authenticator is a map from (RP ID, user ID) pairs, to public key credentials.
    - An authenticator, traditionally, is the physical thing that holds keys and signs stuff. Security keys are authenticators
    - An RP ID identifies a website. It's a string that contains a domain name. (In non-web cases, like SSH, it can be a URL, but I'm not covering them here.) 

- Queues
	- Help off-load tasks from the critical path 
	- Transform, filter and fan-out messages thus enabling parallel processing 
	- Cost for queueing, 
		- To effectively deliver a message, it usually takes three operations: one write, one read, and one acknowledgement. You can estimate your usage by considering the cost of messages delivered by multiplying cost per operation by 3. 

- Characteristics of Distributed System
	- Communication - Reliable links, secure links, discovery, APIs.
	- Coordination - System models, failure detection, time, leader election, replication, coordination avoidance, transactions.
	- Scalability - HTTP caching, content delivery networks, partitioning, file storage, data storage, caching, microservices, control panes and data panes, messaging.
	- Resiliency - Common failure causes, redundancy, fault isolation, downstream resiliency, upstream resiliency.
	- Maintainability - Testing, continuous delivery and deployment, monitoring, observability, and manageability.

	- Downstream resiliency	
		- Timeout - As a rule of thumb, always set timeouts when making network calls, and be wary of third-party libraries that make network calls but don’t expose settings for timeouts. 	
		- Retries with exponential back-off

	- Upstream resiliency
		- Load shedding - Rejecting the request(s) once beyond server's capacity.
		- Load leveling - Introducing messaging channel between client and service to decouple load on Service. However, this works in cases where client is not expecting immediate response.
		- Load-shedding and load leveling don’t address an increase in load directly but rather protect a service from getting overloaded.
		- Rate limiting 

- Measures for resilient systems by Shopify
	- Ensure that timeout is specified for network request like over HTTP or TCP. Try to lower them whenever possible
	- Use circuit breakers
	- Monitoring and alerting for below, 
		- Latency: the amount of time it takes to process a unit of work, broken down between success and failures. With circuit breakers failures can happen very fast and lead to misleading graphs.
		- Traffic: the rate in which new work comes into the system, typically expressed in requests per minute.
		- Errors: the rate of unexpected things happening. In payments, we distinguish between payment failures and errors. An example of a failure is a charge being declined due to insufficient funds, which isn’t unexpected at all. HTTP 500 response codes from our financial partners on the other hand are. However a sudden increase in failures might need further investigation.
		- Saturation: how much load the system is under, relative to its total capacity. This could be the amount of memory used versus available or a thread pool’s active threads versus total number of threads available, in any layer of the system.
	- Implement structured logging - Use co-relation id for every request.


- Approach to Selecting/Upgrading the technology/tool
    - Always Measure first 
        - Define your service level objectives (SLOs) and measure them via an observability system like Datadog. You usually want, at a minimum, an availability SLO (i.e., 99.9% of requests succeed) and a latency SLO (p99 latency is < 1s).
        - Define your load objective. This is just the number of users you want to be able to support at a given time. If you’re launching a new product, ask marketing how much traffic they expect on launch day and double it. If there isn’t going to be a splashy launch, try to project out where you’ll be in, say, one year, and add a 10-20% buffer.
        - Run a load test by spinning up a test cluster and writing some scripts to simulate real usage. Keep fixing bottlenecks and re-running load tests until you hit your objective.

- Typical Archetypes in Software engineering, 
	- The Team Lead guides the approach and execution of a particular team. Most frequently they partner closely with a single manager, but sometimes they partner with two or three managers within a focused area.
	- The Architect is responsible for the direction, quality and approach within a critical area, both today and stretching into the multi-year future horizon. They combine a deep knowledge of technical constraints, user needs, and organization level leadership.
	- The Right Hand is a partner and an extension of an executive-level manager, borrowing their scope and authority to operate particularly complex organizations. They provide additional leadership bandwidth to leaders of large-scale organizations.

	- The Solver digs deep into arbitrarily complex problems and finds an appropriate path forward. Some focus on a given area for long periods, others bounce from hotspot to hotspot as guided by organizational leadership.

- What is Wine? wine is a “dynamic loader” for Windows executables. It’s a native Linux binary, hence it can just run normally, and it knows how to deal with EXE and DLLs.

- Pschycology for Software Development 
	- Spend more time to consider, 
		- the financial costs 
		- the payoff periods 
		- the opportunity costs
	- focused on work that paid off sooner than later - engineers should avoid work that pays off too far into the future. This mistake happens particularly when it comes to engineering migrations.I have a rule that any engineering work must have a minimum of 2x of the rewards to justify the cost.
	- calculated if the work was worth their time or not before diving into it
	- weighed the opportunity costs of their work

- Approach for modernization of problematic source code
	- Get testing in place ...if not already available
	- use Strangler pattern - one piece at a time 

- Use cases for Kafka and RabbitMQ
    - Kafka 
        -Pub/Sub Messaging. Kaˆa can be a good match for the pub/sub use cases that exhibit the following properties: (i) if the routing logic is simple, so that a Kaˆa “topic” concept can handle the requirements, (ii) if throughput per topic is beyond what RabbitMQ can handle (e.g. event €rehose). 
        - Scalable Ingestion System. Many of the leading Big Data processing platforms enable high throughput processing of data once it has been loaded into the system. However, in many cases, loading of the data into such platforms is the main boŠleneck. Kaˆa o‚ers a scalable solution for such scenarios and it has already been integrated into many of such platforms including Apache Spark and Apache Flink, to name a few.
        - Scalable Ingestion System. Many of the leading Big Data processing platforms enable high throughput processing of data once it has been loaded into the system. However, in many cases, loading of the data into such platforms is the main boŠleneck. Kaˆa o‚ers a scalable solution for such scenarios and it has already been integrated into many of such platforms including Apache Spark and Apache Flink, to name a few. 6Recent versions of Kaˆa have a notion of federation, but more in the sense of cross-datacenter replication.
        - Data-Layer Infrastructure. Due to its durability and ecient multicast, Kaˆa can serve as an underlying data infrastructure that connects various batch and streaming services and applications within an enterprise.
        - Capturing Change Feeds. Change feeds are sequences of update events that capture all the changes applied on an initial state (e.g. a table in database, or a particular row within that table). Traditionally, change feeds have been used internally by DBMSs to synchronize replicas. More recently, however, some of the modern data stores have exposed their change feeds externally, so they can be used to synchronize state in distributed environments. Kaˆa’s log-centric design, makes it an excellent backend for an application built in this style. 
        - Stream Processing. Starting in Kaˆa version 0.10.0.0, a light-weight stream processing library called Kaˆa Streams is available in Apache Kaˆa to perform stateful and fault-tolerant data processing. Furthermore, Apache Samza, an open-source stream processing platform is based on Kaˆa. 
    - RabbitMQ 
        - Pub/Sub Messaging. Since this is exactly why RabbitMQ was created, it will satisfy most of the requirements. Œis is even more so in an edge/core message routing scenario where brokers are running in a particular interconnect topology. 
        - Request-Response Messaging. RabbitMQ offers a lot of support for RPC style communication by means of the correlation ID and direct reply-to feature, which allows RPC clients to receive replies directly from their RPC server, without going through a dedicated reply queue that needs to be set up. Hence, RabbitMQ, having speci€c support to facilitate this usecase and stronger ordering guarantees, would be the preferred choice. 
        - Operational Metrics Tracking. RabbitMQ would be a good choice for realtime processing, based on the complex €ltering the broker could provide. Although Kaˆa would be a good choice as an interface to apply o„ine analytics, given that it can store messages for a long time and allows replay of messages. Œroughput per topic could be another criterion to decide. 
        - Underlying Layer for IoT Applications Platform. RabbitMQ can be used to connect individual operator nodes in a dataƒow graph, regardless of where the operators are instantiated. A lot of the features of RabbitMQ directly cover platform requirements: (i) sub 5ms latency for the majority of the packets, throughput up to 40Kpps for single nodes, (ii) excellent visibility on internal metrics and easy test and debug cycles for dataƒow setup through the web management interface, (iii) support for the MQTT protocol, (iv) sophisticated routing capability allows to expose packet €lters as part of an associated data processing language, and (v) the possibility to handle a very large number of streams that all have rather small throughput requirements, with a large number of applications all interested in di‚erent small subsets of these streams. - Information-centric Networking. Œis is essentially a game on the capabilities of the architecture to intelligently route packets. Œerefore, RabbitMQ would be the preferred choice, maybe even with a speci€c exchange that understands the link between routing key and destination.

    - Domain driven design basics, 
        - The composition of domain objects:
            •	Entity: a domain object that has ID and life cycle. 
            •	Value Object: a domain object without ID. It is used to describe the property of Entity.
            •	Aggregate: a collection of Entities that are bounded together by Aggregate Root (which is also an entity). It is the unit of storage. 
        - The life cycle of domain objects:
            •	Repository: storing and loading the Aggregate.
            •	Factory: handling the creation of the Aggregate.
        - Behavior of domain objects:
            •	Domain Service: orchestrate multiple Aggregate.
            •	Domain Event: a description of what has happened to the Aggregate. The publication is made public so others can consume and reconstruct it.