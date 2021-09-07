---
title: "Database Reliability Engineering - My Notes"
date: 2021-09-05T01:00:00+05:30
draft: false
tags: [Observability, Database, MySQL, Monitoring, Honeycomb]
---

## Introduction

I have been reading excellent [Database Reliability Engineering](https://www.oreilly.com/library/view/database-reliability-engineering/9781491925935/) book and below are my notes from it. 

* Key Incentive(s) for Automation 
    * Elimination of Toil - Toil is the kind of work tied to running a production service that tends to be manual, repetitive, automatable, tactical, devoid of enduring value, and that scales linearly as a service grows.

*  Important System Characteristics 

    * _Latency_, also known as response time, is a time-based measurement indicating how long it takes to receive a response from a request. It is best to measure this for end-to-end response from the customer rather than breaking it down component by component. This is customer-centric design and is crucial for any system that has customers, which is any system

    * _Availability_ - This is generally expressed as a percentage of overall time the system is expected to be available. Availability is defined as the ability to return an expected response to the requesting client. Note that time is not considered here, which is why most SLOs include both response time and availability. After a certain latency point, the system can be considered unavailable even if the request is still completing. Availability is often denoted in percentages, such as 99.9% over a certain window. All samples within that window will be aggregated

    * _High availability_ - For any mission-critical data that you truly care about, you should avoid running with less than three live copies. That’s one primary and two-plus secondaries for leader-follower data stores like MySQL or MongoDB or a replication factor of three for distributed data stores like Cassandra or Hadoop. Because you never, ever want to find yourself in a situation in which you have a single copy of any  data you care about, ever. This means that you need to be able to lose one instance while still maintaining redundancy, which is why three is a minimum number of copies, not two.


### Infrastructure engineering 

  *  _Virtualization_ 
    * Hypervisor - A hypervisor or virtual machine monitor (VMM) can be software, firmware, or hardware. The hypervisor creates and runs VMs. A computer on which             hypervisor runs one or more VMs is called a host machine, and each VM is called a guest machine. The hypervisor presents the guest operating systems with a virtual operating platform and manages the execution of the guest operating systems.  Databases running within hypervisors show lower boundaries for concurrency than the same software on bare metal. When designing for these virtualized environments, the focus should be on a horizontally scaled approach, minimizing concurrency within nodes.

  * Storage - Storage durability and performance are not what you would expect in the virtualized world. Between the page cache  of your VM and the physical controller lies a virtual controller, the hypervisor, and the host’s page cache. This means increased latency for I/O. For writes, hypervisors do not honor calls in order to manage performance. This means that you cannot guarantee that your writes are flushed to disk when there is a crash.


  * _Database Servers_ 
    * Physical servers - Recommended to have dedicated ones for database (and not shared)
        * Why ? 
            * Much control with OS and more visibility
            * May find redundant capacity on a dedicated hardware.            
    * Linux 
        - is not particularly optimized for database loads requiring low latency and high concurrency. The kernel is not predictable when it goes into reclaim mode,
        - one of the best recommendations we can give is to simply ensure that you never fully use your physical memory by reserving it to avoid stalls and significant latency impacts. You can reserve this memory by not allocating it in configuration

  * _Storage_ 
    * Capacity - Single large disks are single points of failure, unless mirrored (RAID 1). RAID 0 will have its MTBF reduced by a factor of N, where N is the number of disks striped together.
    * Throughput - When considering the needs, you must consider IOPS for the peak of a database’s workload rather than the average.
    * Latency - Latency is the end-to-end client time of an I/O operation; in other words, the time elapsed between sending an I/O to storage and receiving an acknowledgement that the I/O read or write is complete.
        * _Transactional applications_ are sensitive to increased I/O latency and are good candidates for SSDs. You can maintain high IOPS while keeping latency down by maintaining a low queue length and a high number of IOPS available to the volume. Consistently driving more IOPS to a volume than it has available can cause increased I/O latency.
        * _Throughput-intensive applications_ like large MapReduce queries are less sensitive to increased I/O latency and are well-suited for HDD volumes. You can maintain high throughput to HDD-backed volumes by maintaining a high queue length when performing large, sequential I/O
    * Availability - Plan for disk failures.
    * Durability - When your database goes to commit data to physical disk with guarantees of durability, it issues an operating system call known as rather than relying on page cache flushing. An example of this is when a redo log or write-ahead log is being generated and must be truly written to disk to ensure recoverability of the database. Filesystem operations can also cause corruption and inconsistency during failure events, such as crashes. Journaling filesystems like XFS and EXT4 significantly reduce the possibility of such events, however.

    * Storage Area Networks (SAN) vs. SSDs - Data snapshots and movement are some of the nicest features in modern infrastructures, where SSDs provide better IO than traditional SANs.

* _Relational Database Internals_ 

    * In Relational databases, data is stored in containers called blocks or pages that correspond to a specific number of bytes on disk. Different databases will use blocks or pages in their terminology. In this book, we use blocks to refer to both. Blocks are the finest level of granularity for storing records. Oracle Database stores data in data blocks. A page is a fixed size called a block, just like blocks on disks. Blocks are the smallest size that can be read or written to access data. This means that if a row is 1 K and the block size is 16 K, you will still incur a 16 K read operation. If a database block size is smaller than the filesystem block size, you will be wasting I/O for operations that require multiple pages. A block require some metadata to be stored, as well, usually in the form of a header and trailer or footer. This will include disk address information, information about the object the block belongs to, and information about the rows and activity that have occurred within that block. 

    * Most databases structure their data in a binary tree format, also known as B-tree. A Btree is a data structure that self-balances while keeping data sorted. The B-tree is optimized for the reading and writing of blocks of data, which is why B-trees are commonly found in databases and filesystems

        * Summary of the attributes and benefits of B-trees:
            * Excellent performance for range-based queries.
            * Not the most ideal model for single-row lookups
            * Keys exist in sorted order for efficient key lookups and range scans.
            * Structure minimizes page reads for large datasets.
            * By not packing keys into each page, deletes and inserts are efficient, with only occasional splits and merges being needed.
            * Perform much better if the entire structure can fit within memory.

            * A crucial variable in configuring your databases for underlying storage is the database block size. We’ve discussed the importance of aligning database block sizes with the underlying disk block sizes, but that is not enough. If you are using Solid-State Drives (SSDs), for instance, you might find smaller block sizes provide much better performance while traversing B-trees. An SSD can experience a 30% to 40% latency penalty on larger blocks versus performance on Hard Disk Drives (HDDs). Because reads and writes are required in B-tree structures, this must be taken into account.

    * _Non-Relational Database Internals_ 

        * What is sorted-string tables (SST) storage engine? - It has a number of files, each with a set of sorted key–value pairs inside. Unlike in the block storage discussed earlier, there is no need for the metadata overhead at the block or row level. Keys and their values are opaque to the DBMS and stored as arbitrary binary large objects (BLOBs). Because they are stored in a sorted fashion, they can be read sequentially and treated as an index onthe key by which they are sorted.

        * There is an algorithm that combines in-memory tables, batch flushing, and periodic compaction in SST storage engines. This algorithm is referred to a log-structured merge (LSM) tree architecture

        * A bloom filter is a data structure that you can use to evaluate whether a record key is present in a given set.

    * Database Indexes 
        * Hash indexes - A hash map is a collection of buckets that contain the results of a hash function applied to a key. That hash points to the location where the records can be found. A hash map is only viable for single-key lookups because a range scan would be prohibitively expensive. 
        * Bitmap Indexes - A bitmap index stores its data as bit arrays (bitmaps). When you traverse the index, it is done by performing bitwise logical operations on the bitmaps. In B-trees, the index performs the best on values that are not repeated often. This is also known as high cardinality. The bitmap index functions much better when there are a small number of values being indexed

    * Replication
        * Types  
            * Synchronous - A transaction that is written to a log on the leader is shipped immediately over the network to the followers. The leader will not commit the transaction until the followers have confirmed that they have recorded the write. This ensures that every node in the cluster is at the same commit point. This means that reads will be consistent regardless of what node they come from, and any node can take over as a leader without risk of data loss if the current leader fails. On the other hand, network latency or degraded nodes can all cause write latency for the transaction on the leader.
            * Asynchronous - A transaction is written to a log on the leader and then committed and flushed to disk. A separate process is responsible for shipping those logs to the followers, where they are applied as soon as possible. In asynchronous replication models, there is always some lag between what is committed on the leader and what is committed on the followers. Additionally, there is no guarantee that the commit point on one follower is the same as the others. In practice, the time gap between commit points might be too small to notice.
            
            * Semi-synchronous -  In this algorithm, only one node is required to confirm to the leader that they have recorded the write. This reduces the risk of latency impacts when one or more nodes are functioning in degraded states while guaranteeing that at least two nodes on the cluster are at the same commit point. In this mode, there is no longer a guarantee that all nodes in the cluster will return the same data if a read is issued on any reader.
            
            * Formats used during Replication
                * Statement based logs - the actual SQL or data write statement used to execute the write is recorded and shipped from the leader to followers. e.g. MySQL 
                * Write-ahead logs -  A write-ahead log (WAL), also known as a redo log, contains a series of events, each event mapped to a transaction or write. In the log are all of the bytes required to apply a transaction to disk. In systems, such as PostgreSQL, that use this method, the same log is shipped directly to the followers for application to disk.

            * Approaches 
                * Row based Replication - In row-based replication (also called logical), writes are written to replication logs on the leader as events indicating how individual table rows are changed. Columns with new data are indicated, columns with updated information show before/after images, and deletes of rows are indicated as well. Replicas use this data to directly modify the row rather than needing to execute the original statement.

                * Block level Replication - Block-level replication is synchronous and eliminates significant overhead in the replicated write. However, you cannot have a running database instance on the secon‐dary node. So, when a failover occurs, a database instance must be started. If the for‐mer master failed without a clean database shutdown, this instance will need to perform recovery just as if the instance had been restarted on the same node.

            *  Methods
                * Single Leader -  (Simplest of replicated environments) All writes go to single leader and are replicated to other nodes. Advantages are that there will be no consistency conflicts. There are some variations like data getting replicated to only few followers which further replicate to remaining ones. By far the most common implementation of replication due to simplicity.

                * Multiple Leaders - There are 2 approaches, 
                    * There are typically 2 leaders responsible for receiving writes and propagating them to replicas. each leader is located in different data centers/availability zones. 
                    * Any node can take reads or writes at any time. 
                    More complex than Single Leader approach due to need for conflict resolution.

                    Use cases, 
                    
                    -    Availability - In case of failover with Single Leader approach, impact may last from 30 seconds to minutes depending on how the system is designed. This is due to replication consistency checks, crash recovery and more such steps. This impact could be unacceptable.
                    -    Locality - Application is requirement is such that it needs to cater to users in different regions with separate datacenters. This could be to for data protection purposes or to ensure low latency.
                    -    Disaster Recovery -  Highly critical application with need to have multiple data centers to ensure availability.

                   Conflict resolution approaches, 
                    -   Sharding - distribute range of primary keys across leaders 
                    -   Affinity - Specific users (by region, unique ID) are always redirected to specific leader
                    -   Shard by Application layer ie. Application instance is deployed in each datacenter avoid need for active/active cross region replication 
                
                * Write anywhere- Any node can take read or write requests. Attributes typically associated with such systems are, 
                    * Eventual consistency -  there is no guarantee that data is consistent across all nodes at any time, that data will eventually converge.
                    * Read & Write Quorum - It indicates minimum number of readers or writers necessary to guarantee consistency of data. Quorum of 2 in 3 node cluster means one node's failure is tolerated. Formula: N is the number of nodes in a cluster.R is the number of read nodes available, and W is the number of write nodes. If R + W is greater than N, you have an effective quorum to guarantee at least one good read after a write.
                    * Sloppy quorums - Indicates situation when nodes are available but unable to meet quorum due to lack of data.
                    * Anti Entropy - Mechanism to keep data synchronized across nodes even in case of inactivity (i.e. no reads). Anti-entropy is critical for datastores that store a lot of cold, or infrequently accessed,data.

    * _Data governance_ is the management of the availability, integrity, and security of the data that an organization saves and uses. Intro‐duction of new data attributes is something that should be considered carefully and documented. The use of JSON for data storage allows new data attributes to be introduced too easily and even accidentally.
    
    
    * Important aspects in Infrastructure Architecture,

        * Relaxed durability means data loss must be considered an inevitability.
        * Instance instability means automation, failover, and recovery must be very reliable.
        * Horizontal scale requires automation to manage significant numbers of servers.
        * Applications must be able to tolerate latency instability.

### Infrastructure Management

* An immutable infrastructure is one that is not allowed to mutate, or change, after it has been deployed. If there are changes that must happen, they are done to the  version controlled configuration definition, and the service is redeployed.In the interest of moderation and middle ground, there can be some mutations that are frequent, automated and predictable, and can be allowed in the environment. Manual changes are still prohibited, keeping a significant amount of the value of predictability and recoverability while minimizing operational overhead. , Packer allows you to create multiple images from the same configuration. This includes images for virtual machines on your workstation. Using a tool like Vagrant on your workstation allows you to download the latest images, build the VMs, and even run through a standard test suite to verify that everything works as expected.
    * [Packer](https://www.packer.io) is one such tool from Hashicorp that creates images. The interesting thing about Packer is that it can create images for different environments (such as Amazon EC2 or VMWare images) from the same configuration. Most configuration management utilities can create baked images as well.

* Service Discovery & Service catalog - Service discovery is an abstraction that maps specific designations and port numbers of your services and load balancers to semantic names. A service catalog can be very simple, storing service data to integrates services, or it can include numerous additional facilities, including health checks to ensure that data in the catalog provides working resources.

* Isolation of Network Traffic - Network traffic can be broken up in, 
    * Internode communications
    * Application traffic
    * Administrative traffic
    * Backup and recovery traffic 
    Isolation of traffic is one of the first steps to proper networking for your databases. You can do this via physical network interface cards (NICs), or by partitioning one NIC

* Data Security
    * Tracking every failed and successful SQL statement sent to database is critical for identifying SQL injection attacks. SQL syntax errors can be a leading indicator

* Data Architecture
    * Frontline Datastores - Historically, these systems have been referred to as OnLine Transactional Processing (OLTP) systems. They were characterized by a lot of quick transactions, and thus they were designed for very fast queries, data integrity in high concurrency, and scale based on the number of transactions they can handle concurrently. All data is expected to be real time with all of the necessary details to support the services using them. Each user or transaction is seeking a small subset of the data. This means query patterns tend to focus on finding and accessing a small, specific dataset within a large set. Effective indexing, isolation, and concurrency are critical for this, which is why it tends to be fulfilled by relational systems. Typical characteristics are,
        * Low-latency writes and queries
        * High availability
        * Low Mean Time to Recover (MTTR)
        * Ability to scale with application traffic
        * Easy integration with application and operational services
        * _Database proxies_  - Sits between application and frontline datastores. It could be,
            * _Layer 4 (Networking transport layer)_ - Uses the information available at networking layer like destination IP Addresses to distribute the traffic. This type can not work with factors like load or replication lag while distributing traffic
            * _Layer 7_ - Operates at higher level of networking transport layer. At this layer, proxy can include functionality like, 
                * Health checking and redirection to healthy servers
                * Splitting of reads and writes to send reads to replicas
                * Query rewriting to optimize queries that cannot be tuned in code
                * Caching query results and returning them
                * Redirecting traffic to replicas that are not lagged
                * Generate metrics on queries
                * Perform firewall filtering on query types or hosts 

        * _Event and Messaging systems_ - Used for actions to be triggered after a transaction like, 
            * Data must be put into downstream analytics and warehouses
            * Orders must be fulfilled
            * Fraud detection must review a transaction
            * Data must be uploaded to caches or Content Delivery Networks (CDNs)
            * Personalization options must be recalibrated and published

        * _Caches and Memory Store_ - Used to overcome slowness in Disk I/o. Approaches to putting data are, 
            * Putting data in cache after its been written to persistent data store 
            * Writing to cache and datastore at the same time (Fragile due to possibility of one of the store failing)
            * Writing to cache first and then to datstore asynchronously (Write-through approach)

        * _Lambda Architecture_ - The Lambda architecture is designed to handle a significant volume of data that is processed rapidly to serve near-real-time requests, while also supporting longrunning computation. Lambda consists of three layers: batch processing, real-time processing, and a query layer.If data is written to a frontend datastore, you can use a distributed log such as Kafka to create a distributed and immutable log for the Lambda processing layers. Some data is written directly to log services rather than going through a datastore. The pro‐cessing layers ingest this data.
        
        * _Kappa Architecture_ - Append only immutable log is used in this Architecture. Kappa architecture eliminates the batch processing system, with the expectation that the streaming system can handle all transformations and computations. One of the biggest values to Kappa is the reduction in complexity and operational expense of Lambda by eliminating the batch processing layer. It also aims to reduce the pain of migrations and reorganizations. When you want to reprocess data, you can start a reprocessing, test it, and switch over to it.

        * _Application Architecture Patterns_
            * _Event sourcing pattern_ - Changes to entities are saved as sequence of state changes. When state changes, a new event is appended to the log. The datastore is called as event store. it maintains audit of life cycle of entity which helps in recreation or populating the tables in case of data loss. However, evolution of entity over period of time needs to be managed as it may invalidate previous events. It allows giving full historical access via API for auditing, reconstruction, and different transformations can provide significant benefits. 

            * _CQRS_ - The driver for this is the idea that same data can be represented for consumption using multiple models or views. like Append only log for writes and read optimized data stores for queries.

### Monitoring and Observability

* _Synthetic Monitoring_ - The case for synthetic monitoring is to provide coverage that is consistent and thorough. Users might come from different regions and be active at different times. This can cause blind spots if we are not monitoring all possible regions and code paths into our service. With synthetic monitoring, we are able to  identify areas where availability or latency is proving to be unstable or degraded, and prepare or mitigate appropriately. Examples of such preparation/mitigation include adding extra capacity, performance tuning queries, or even moving traffic away from unstable region

* _Latency SLO_ - Service Level Objective could be "Ninety-nine percent request latency over one minute must be between 25 and 100 ms".

* WHY _MTTR_ (Mean time to recover) Over _MTBF_ (Mean time between failure)?
    When you create a system that rarely breaks, you create a system that is inherently fragile. Will your team be ready to do repairs when the system does fail? Will it even know what to do? Systems that have frequent failures that are controlled and mitigated such that their impact is negligible have teams that know what to do when things go sideways. Processes are well documented and honed, and automated remediation becomes actually useful rather than hiding in the dark corners of your system

* Some of the Important statistics (Metrics, Events, Logs....) to be observed from observability perspective are,
    * Metrics
        * _Latency_ - How long are client calls to your service ?
        * _Availability_ - How many calls result in errors?
        * _Call Rates_ - How oftern are calls sent to service?
        * _Utilization_ - How critical resources are being utilized to ensure quality of service and capacity.

        - Types of Metrics, 
            * _Counters_ - These are cumulative metrics that represent how many times a specific occurrence of something has occurred.
            * _Gauges_ - These are metrics that change in any direction, and indicate a current value, such as temperature, jobs in queue, or active locks.
            * _Histograms_ - A number of events broken up into configured buckets to show distribution.
            * _Summaries_ - This is similar to histogram but focused on proving counts over sliding windows of time

    * _Events_ - An event is a discrete action that has occurred in the environment. A change to a config is an event. A code deployment is an event. A database master failover is an event. Each of these can be signals that are used to correlate symptoms to causes.

    * _Alerts & Notifications_

        * _Alerts_ - An alert is an interrupt to a human that instructs him to drop what he’s doing and investigate a rules violation that caused the alert to be sent. This is an
        expensive operation and should be utilized only when SLOs are in imminent danger of violation.

        * _Tickets/tasks_ - For work that must be done but there is o imminent disaster. The output of monitoring should be tickets/tasks for developers

        * _Notifications_ - Events like Code Deployment completed. 

    * _Automation_ - One example is Autoscaling basis outcome of monitoring. 

    * _Visualization_ - GUI tool for visualizing outcome of monitoring. 

### _Minimum Viable monitoring set_ 

* _Databases_ 
    * Monitor if your databases are up or down (pull checks). Monitor overall latency/error metrics and end-to-end health checks (push checks). 
    * Instrument th application layer to measure latency/errors for every database call (push checks).
    * Gather as many metrics as possible about the system, storage, database, and app layers, regardless of whether you think they will be useful. Most operating systems, services, and databases will have plug-ins that are fairly comprehensive.
    * Create specific checks for known problems. For example, checks based on losing x percent of database nodes or a global lock percent that is too high
    * Health check at the application level that queries all frontend datastores
    * Query run against each partition in each datastore member, for each datastore
    * Imminent capacity issues
        * Disk capacity
        * Database connections
    * Error log scraping
        * DB restarts 
        * Corruption
    * Database connection layer - A tracing system should be in place be able to break out time talking to a proxy and time from the proxy to the backend as well. You can capture this via tcpdump and Tshark/Wireshark for ad hoc sampling. This can be automated for occasional sampling.
        * Utilization
            * Connection upper bound and connection count (Tip: PostgreSQL uses one Unix process per connection. MySQL, Cassandra, and MongoDB use a thread per connection)
            * Connection states (working, sleeping, aborted, and others)
            * Kernel-level Open file utilization
            * Kernel-level max processes utilization
            * Memory utilization
            * Thread pool metrics such as MySQL table cache or MongoDB thread
            * pool utilization
            * Network throughput utilization
        * Measure Saturation using, 
            * TCP connection backlog
            * Database-specific connection queuing, such as MySQL back_log
            * Connection timeout errors
            * Waiting on threads in the connection pools
            * Memory swapping
            * Database processes that are locked
            With utilization and saturation, you can determine whether capacity constraints and bottlenecks are affecting the latency of your database connection layer.
        * Monitor Errors, 
            * Database logs will provide error codes when database-level failures occur. Sometimes you have configurations with various degrees of verbosity. Make sure you have logging verbose enough to identify connection errors, but do be careful about overhead, particularly if your logs are sharing storage and IO resources with your database.
            * Application and proxy logs will also provide rich sources of errors.
            * Host errors discussed in the previous section should also be utilized
    * Internal Database Activity
        * Throughput and latency metrics 
            * Reads
            * Writes
                * Inserts
                * Updates
                * Deletes
            * Other Operations
                * Commits
                * Rollbacks
                * DDL Statements
                * Other admin. tasks
            * Commits, redo, journaling 
                * Dirty buffers (MySQL)
                * Checkpoint age (MySQL)
                * Pending and completed compaction tasks (Cassandra)
                * Tracked dirty bytes (MongoDB)
                * (Un)Modified pages evicted (MongoDB)
            * Memory structures
                * A mutex (Mutually Exclusive Lock) is a locking mechanism used to synchronize access to a resource such as a cache entry. Only one task can acquire the mutex. This means that there is ownership associated with mutexes, and only the owner can release the lock (mutex). This protects from corruption.
                * A semaphore restricts the number of simultaneous users of a shared resource up to a maximum number. Threads can request access to the resource (decrementing the semaphore) and can signal that they have finished using the resource (incrementing the semaphore).
            
    * _Application_
        * Measuring and logging all requests and responses to pages or API endpoints. also  external services, which includes databases, search indexes, 3rd party APIs and caches.
        * Any jobs or independent workflows that should be monitored.
        * Any independent, reusable code like a method or function that interacts with databases, caches, and other datastores should be instrumented.
        * Monitor how many database calls are executed by each endpoint, page, or function/method
        * When doing SQL tuning, a big challenge is mapping SQL running in the database to the specific place in the codebase from which it is being called. In many database engines, you can add comments for information. These comments will show up in the database query logs. This is a great place to insert the codebase location
        * Logging - Logs should include stack traces
        * Setting up an external check for each major product or service, as well as a health check on the monitoring service itself, is a good best practice

    * _Server_ (Metrics)
        * CPU
        * Memory
        * Network interfaces
        * Storage I/O
        * Storage capacity
        * Storage controllers
        * Network controllers
        * CPU interconnect
        * Memory interconnect
        * Storage interconnect

    * _Server_ (Logs) - should be sent to processors (e.g. Logstash, Loki)
        * kernel, cron, authentication, mail, and general messages logs as well as process- or application-specific log to ingest, such as MySQL, or nginx

Overall, this book is highly recommended for understanding the Observability landscape. Though focussed on databases, it covers lot of ground on other aspects involved in infrastructure. 

Happy Coding !!

---

{{< comments >}}