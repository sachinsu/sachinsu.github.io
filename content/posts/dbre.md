---
title: "Upgrading API: Learnings"
date: 2021-05-15T01:00:00+05:30
draft: true
tags: [HTTP, SOAP, REST, .NET, WCF, CoreWCF, ASMX, C#]
---

## Introduction

* Elimination of Toil - Toil is the kind of work tied to running a production service that tends to be manual, repetitive, automatable, tactical, devoid of enduring value, and that scales linearly as a service grows.

* Latency, also known as response time, is a time-based measurement indicating how long it takes to receive a response from a request. It is best to measure this for end-to-end response from the customer rather than breaking it down component by component. This is customer-centric design and is crucial for any system that has customers, which is any system

* Availability - This is generally expressed as a percentage of overall time the system is expected to be available. Availability is defined as the ability to return an expected response to the requesting client. Note that time is not considered here, which is why most SLOs include both response time and availability. After a certain latency point, the system can be considered unavailable even if the request is still completing. Availability is often denoted in percentages, such as
99.9% over a certain window. All samples within that window will be aggregated

* The case for synthetic monitoring is to provide coverage that is consistent and thorough. Users might come from different regions and be active at different times. This can cause blind spots if we are not monitoring all possible regions and code paths into our service. With synthetic monitoring, we are able to  identify areas where availability or latency is proving to be unstable or degraded, and prepare or mitigate appropriately. Examples of such preparation/mitigation include adding extra capacity, performance tuning queries, or even moving traffic away from unstable region

* Latency SLO - Ninety-nine percent request latency over one minute must be between 25 and 100 ms.

* WHY MTTR (Mean time to recover) OVER MTBF (Mean time between failure)?
When you create a system that rarely breaks, you create a system that is inherently fragile. Will your team be ready to do repairs when the system does fail? Will it even know what to do? Systems that have frequent failures that are controlled and mitigated such that their impact is negligible have teams that know what to do when things go sideways. Processes are well documented and honed, and automated remediation becomes actually useful rather than hiding in the dark corners of your system

* Important metrics to be observed, 
    * Latency - How long are client calls to your service ?
    * Availability - How many calls result in errors?
    * Call Rates - How oftern are calls sent to service?
    * Utilization - How critical resources are being utilized  ensure quality of service and capacity.


* Types of Metrics, 
    * Counters - These are cumulative metrics that represent how many times a specific occurrence of something has occurred.
    * Gauges - These are metrics that change in any direction, and indicate a current value, such as temperature, jobs in queue, or active locks.
    * Histograms - A number of events broken up into configured buckets to show distribution.
    * Summaries - This is similar to histogram but focused on proving counts over sliding windows of time

* Events - An event is a discrete action that has occurred in the environment. A change to a config is an event. A code deployment is an event. A database master failover is an event. Each of these can be signals that are used to correlate symptoms to causes.

Types of Notifications expected from Operational Visibility framework, 

* Alerts - An alert is an interrupt to a human that instructs him to drop what he’s doing and investigate a rules violation that caused the alert to be sent. This is an
expensive operation and should be utilized only when SLOs are in imminent danger of violation.

* Tickets/tasks - For work that must be done but there is o imminent disaster. The output of monitoring should be tickets/tasks for developers

* Notifications - Events like Code Deployment completed. 

* Automation - One example is Autoscaling basis outcome of monitoring. 

* Visualization - GUI tool for visualizing outcome of monitoring. 

* Minimum Viable monitoring set 
    * Databases 
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
            * DB restarts (faster than your monitor!)
            * Corruption
    * Application
        *  measuring and logging all requests and responses to pages or API endpoints. also  external services, which includes databases, search indexes, 3rd party APIs and caches.
        * Any jobs or independent workflows that should be similarly monitored.
        * Any independent, reusable code like a method or function that interacts with databases, caches, and other datastores should be similarly instrumented.
        * Monitor how many database calls are executed by each endpoint, page, or function/method
        * When doing SQL tuning, a big challenge is mapping SQL running in the database to the specific place in the codebase from which it is being called. In many database engines, you can add comments for information. These comments will show up in the database query logs. This is a great place to insert the codebase location
        * Logging
            * Logs should include stack traces
    * Server (Metrics)
        *   CPU
        * Memory
        * Network interfaces
        * Storage I/O
        * Storage capacity
        * Storage controllers
        * Network controllers
        * CPU interconnect
        * Memory interconnect
        * Storage interconnect

    * Server (Logs) - should be sent to processors (e.g. Logstash)
        * kernel, cron, authentication, mail, and general messages logs as well as process- or application-specific log to ingest, such as MySQL, or nginx

    * Datastore 
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

* High availability - For any mission-critical data that you truly care about, you should avoid running with less than three live copies. That’s one primary and two-plus secondaries for leader-follower data stores like MySQL or MongoDB or a replication factor of three for distributed data stores like Cassandra or Hadoop. Because you never, ever want to find yourself in a situation in which you have a single copy of any  data you care about, ever. This means that you need to be able to lose one instance while still maintaining redundancy, which is why three is a minimum number of copies, not two.

* Setting up an external check for each major product or service, as well as a health check on the monitoring service itself, is a good best practice

* Infrastructure engineering 

* Database Servers 
    * physical servers - Recommended to have dedicated ones for database (and not shared)
        * Why ? 
            * Much control with OS and more visibility
            * May find redundant capacity on a dedicated hardware.            
    * User resource limits
    * I/O SCheduler
    * Memory allocation and fragmentation 
    * Linux is not particularly optimized for database loads requiring low latency and high concurrency. The kernel is not predictable when it goes into reclaim mode,
        and one of the best recommendations we can give is to simply ensure that you never fully use your physical memory by reserving it to avoid stalls and significant latency impacts. You can reserve this memory by not allocating it in configuration

    * Storage 
        * Capacity - Single large disks are single points of failure, unless mirrored (RAID 1). RAID 0 will have its MTBF reduced by a factor of N, where N is the number of disks striped together.
        * Throughput - When considering the needs, you must consider IOPS for the peak of a database’s workload rather than the average.
        * Latency - Latency is the end-to-end client time of an I/O operation; in other words, the time elapsed between sending an I/O to storage and receiving an
            acknowledgement that the I/O read or write is complete.
            * Transactional database applications are sensitive to increased I/O latency and are good candidates for SSDs. You can maintain high IOPS while keeping latency down by maintaining a low queue length and a high number of IOPS available to the volume. Consistently driving more IOPS to a volume than it has available can cause increased I/O latency.
            * Throughput-intensive applications like large MapReduce queries are less sensitive to increased I/O latency and are well-suited for HDD volumes. You can
            maintain high throughput to HDD-backed volumes by maintaining a high queue length when performing large, sequential I/O
        * Availability - Plan for disk failures.
        * Durability - Finally, there is durability. When your database goes to commit data to physical disk with guarantees of durability, it issues an operating system call known as rather than relying on page cache flushing. An example of this is when a redo log or write-ahead log is being generated and must be truly written to disk to ensure recoverability of the database. Filesystem operations can also cause corruption and inconsistency during failure events, such as crashes. Journaling filesystems like XFS and EXT4 significantly reduce the possibility of such events, however.

        * Storage Area Networks (SAN) - data snapshots and movement are some of the nicest features in modern infrastructures, where SSDs provide better IO than traditional SANs.

    * Virtualization 
        * Hypervisor - A hypervisor or virtual machine monitor (VMM) can be software, firmware, or hardware. The hypervisor creates and runs VMs. A computer on which a
            hypervisor runs one or more VMs is called a host machine, and each VM is called a guest machine. The hypervisor presents the guest operating systems with
            a virtual operating platform and manages the execution of the guest operating systems.  Databases running within hypervisors show lower boundaries for concurrency than the same software on bare metal. When designing for these virtualized environments, the focus should be on a horizontally scaled approach, minimizing concurrency within nodes.

        * Storage - Storage durability and performance are not what you would expect in the virtualized world. Between the page cache of your VM and the physical
            controller lies a virtual controller, the hypervisor, and the host’s page cache. This means increased latency for I/O. For writes, hypervisors do not honor
            calls in order to manage performance. This means that you cannot guarantee that your writes are flushed to disk when there is a crash.
    
        * Important aspects, 
            *  Relaxed durability means data loss must be considered an inevitability.
            * Instance instability means automation, failover, and recovery must be very reliable.
            * Horizontal scale requires automation to manage significant numbers of servers.
            * Applications must be able to tolerate latency instability.

    * Infrastructure Management
        * Packer is a tool from Hashicorp that creates images. The interesting thing about Packer is that it can create images for different environments (such as Amazon
            EC2 or VMWare images) from the same configuration. Most configuration management utilities can create baked images as well.
            * An immutable infrastructure is one that is not allowed to mutate, or change, after it has been deployed. If there are changes that must happen, they are done     to the  version controlled configuration definition, and the service is redeployed.In the interest of moderation and middle ground, there can be some mutations that are frequent, automated and predictable, and can be allowed in the environment. Manual changes are still prohibited, keeping a significant amount of the value of predictability and recoverability while minimizing operational overhead

        * Service Discovery & Service catalog - Service discovery is an abstraction that maps specific designations and port numbers of your services and load balancers to semantic names. A service catalog can be very simple, storing service data to integrates services, or it can include numerous additional facilities, including health checks to ensure that data in the catalog provides working resources.