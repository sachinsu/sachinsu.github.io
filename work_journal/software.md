## 2022-may-30 Mon

- [Amazon interview process][Interview]
    -  STAR (Situation, Task, Action, Result):
        - “What was the situation?”
        - “What were you tasked with?”
        - “What actions did you take?”
        - “What was the result?”
    - Bar Raiser process steps such as preparing a set of behavior-based interview questions in advance of the interview, insisting on written transcripts of the interview, rereading the transcript post interview (before making an assessment), conducting debriefs, basing debriefs on the interview transcripts, and making assessments based on well-understood principles are all steps that seek to eliminate individual biases. Having a diverse group of people involved in the process obviously reduces the chance of unconscious bias worming its way in.

- [On Software Architecture][Architecture]

    - Every thing in Software Architecture is a trade off

    - The top 3 soft skills for any software architect are negotiation, facilitation, and leadership. Negotiation is a required skill as an architect because almost every decision you make as an architect will be challenged. Your decisions will be challenged by other architects who think they have a better approach than you do; your decisions will be challenged by business stakeholders because they think your decision takes too long to implement or is too expensive or is not aligned with the business goals; and finally, your decisions will be challenged by development teams who believe they have a better solution. All of this requires an architect to understand the political climate of the enterprise and how to navigate the politics to get your decisions approved and accepted.

    - Facilitation is another necessary soft skill as a software architect. Architects not only collaborate with development teams, but also collaborate closely with various business stakeholders to understand business drivers, explain important architecture characteristics, describe architectural solutions, and so on. All of these gatherings and meetings require a keen sense of facilitation and leadership within these meetings to keep things on track.

    - Finally, leadership is another important soft skill because an architect is responsible for leading and guiding a development team through the implementation of an architecture. They are there as a guide, mentor, coach, and facilitator to make sure the team is on track and is running as smooth as a well-oiled machine, and to be there when the team needs clarification or has questions and concerns about the architecture.

    - Trends of 2021, 
        - Exploration of low-code/no-code environments. 
        - Focus on Architecture as part of daily activities of development process. Realization of importance of evolutionary and incremental architectures
        - Move to hybrid from pure microservices based architecture. 

    - Three basic Architecture Styles
        - Monolith (Single Deployment)
        - Service based 
        - Microservices (independant deployability)
            - Common topologies 
                - API REST-based topology
                - application REST-based topology - client requests are received through traditional web-based or fat-client business application screens rather than through a simple API layer. service components tend to be larger, more coarse-grained, and represent a small portion of the overall business application rather than fine-grained, single-action services. This topology is common for small to medium-sized business applications that have a relatively low degree of complexity.
                - centralized messaging topology - instead of using REST for remote access, this topology uses a lightweight centralized message broker.message broker found in this topology does not perform any orchestration, transformation, or complex routing; rather, it is just a lightweight transport to access remote service components.
                - typically found in larger business applications or applications requiring more sophisticated control over the transport layer between the user interface and the service components. The benefits of this topology over the simple REST-based topology discussed previously are advanced queuing mechanisms, asynchronous messaging, monitoring, error handling, and better overall load balancing and scalability.

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
        - Difficult to autoscale 
    - Yelp is using Lucene based alternate search solution call nrtsearch, at https://github.com/Yelp/nrtsearch 
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


- [.NET Specific Tech. Tips][Architecture]
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
                - APIs that masquarade as synchronous but are actually blocking async methods 
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
    
    -  It all started with need for business leaders to understand how business was doing. so process was to get data out of operational data systems , transform it into a central place (Data warehouse) and perform analytics on it.
    - This enabled business analysts to understand how was business was performing 
    - However, this approach started to have challenges when,
        - need arises for handling more data types , typically unstructured data like videos, audio and images. 
        - also on-prem infra was difficult and expensive to scale with ever growing data. This is because at on-prem compute and storage were typically coupled.
        - There was appetite to perform forward looking analytics which gave indication on how business would perform in future based on available data. This required adding ML & AI on data sets.
        
    - This is where Concept of "Data lake" started getting adopted, 
        - Basically, its cheap storage area where data is just dumped from sources like OLTP systems, Other Applications, logs etc. 
        - From here, Subset of the data is moved to classical data warehouse (typically on cloud) for analytics or gaining insights  
        - Reasons are, 
            - In the Sources to DWH approach, one has to have schema up-front which is hard to get right at the beginning. Data lake to DWH provides flexibility in this. 
        - A structural transaction layer is built on top of it 
        - with lake-house pattern, BI tool can query data lake directly without the need to have DWH or transactional layer in between.
        
    - When it comes to AI and machine learning, a lot of the secret sauce to getting really great results or predictions comes from augmenting your data with additional metadata that you have.

    - Streaming
        - All the ETL use cases are potentially candidates for streaming

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
            - Built-in instrumentation. For example, in MySQL, it’s the performance schema
            statement digest tables; in PostgreSQL it’s the pg_stat_statements extension;
            MongoDB doesn’t have a great solution for this internally, but you can get
            most of the way there with the top() command; or if you can accept higher
            performance impact, the MongoDB profiler. These have to be enabled, and
            often aren’t enabled by default, especially on systems like Amazon RDS, but
            this instrumentation is valuable and worth enabling, even if it requires a server restart. Oracle and SQL Server have lots of robust instrumentation. Most monitoring tools can use this data.

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
