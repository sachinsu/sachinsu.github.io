+++
title = 'High availability For Critical Applications'
date = 2026-09-24T07:07:07+01:00
draft = false
tags = [postgresql,HA,high availability,yugabytedb,patroni,citus]
+++

# Executive Summary and key Constraints

In every enterprise, there are applications with specific high availability requirements.  Deploying high-availability (HA) architectures for Online Transaction Processing (OLTP) workloads across multi-site environments requires balancing *data consistency*, *recovery objectives*, and *operational complexity* while adhering to constraints.

This post evaluates architecture options for a **write-heavy, mission-critical OLTP application** deployed across two on-premise data centers using open-source tools.

## Current State (Deployment)


 ![Current Deployment Architecture](/images/hadc_image1.svg)


## Objectives and Constraints

The requirement is to provide High availability for mission-critical  Applications with below objectives,

  - 99.9% (~ 8.8 hours of downtime/year) availability for the Application utilizing two on-premise/private data centers. Distance between these 2 is approx. 1000 KM and are connected by 1 Gbps network. This bandwidth is shared.
  - Application has write-heavy access pattern.
  - Current Application throughput must be maintained as per the SLO along side availability target.
  - Aim for near Zero Recovery Point Objective (```RPO = 0```).
  - To be cost effective by means of using open source tools/applications as much as possible.
  - Aim for lesser operational complexity. 


Basis objectives and current state, important points to note are, 
  - *No Data loss* (i.e. RPO = 0)  will require synchronous replication between database nodes. In this, data-modifying transaction is not considered committed until all servers have committed the transaction. This will force a harsh write-latency penalty.
  - With no 3rd physical data center, consensus based approaches like RAFT or using patroni for PG Failover can not operate in case of failure at both data centers as they required odd (```2n+1```) participants. 

Referring to "Current state deployment" above, the authoritative state of the application is stored in PostgreSQL (Community Edition)  Database.  standard single-primary deployments present a single point of failure (SPOF). 

## Landscape of PostgreSQL Distributed Architectures

Current landscape of PostgreSQL Distributed Architectures is as follows (Some of the options like "Read replicas", "Cloud database offerings" are not listed as they are not relevant for the use case),

| Type |	Description	| Pros and Cons|
|:--- |:--- |:--- |
| Network-attached block storage (e.g. SAN storage)| <ul><li> Database files are stored on a different device</li><li>  The database    server typically runs in a virtual machine in a Hypervisor, which exposes a block device to the VM. Any reads and writes to the block device will result in network calls to a block storage API.</li><li>The durability and availability benefits of network-attached storage usually outweigh the performance downsides.</li></ul>| - Pros <ul><li> Higher durability (replication) </li><li> Higher uptime (replace VM, reattach) 	</li><li> Fast backups and replica creation (snapshots) </li><li> Disk is resizable </li></ul><br>- Cons 	<ul><li> Higher disk latency (~20μs -> ~1000μs)	</li><li> Lower IOPS (~1M -> ~10k IOPS) 	</li><li> Crash recovery on restart takes time	</li><li> Cost can be high </li></ul>|
|Active-active (e.g. BDR)|In the active-active architecture, any node can accept writes without coordination with other nodes. It is typically used with replicas in multiple sites, each of which will then see low read and write latency, and can survive failure of other sites. Active-active systems do not have a linear history, even at the row level, which makes them very hard to program against.|- Pros<ul>	<li>Very high read and write availability</li><li>Low read and write latency</li><li>Read throughput scales linearly</li></ul>- Cons<ul><li>Eventual read-your-writes consistency</li>	<li>No monotonic read consistency</li>	<li>No linear history (updates might conflict after commit)</li><li>Not offered as part of Community Edition</li></ul>|
|Transparent Sharding (e.g. Citus)|Transparent sharding systems like Citus distribute tables by a shard key and/or replicate tables across multiple primary nodes. Each node shows the distributed tables as if they were regular PostgreSQL tables and queries & transactions are transparently routed or parallelized across nodes.Data is stored in shards, which are regular PostgreSQL tables.|- Pros <ul><li> Scale throughput for reads & writes (CPU & IOPS)	</li><li> Scale memory for large working sets	</li><li> Parallelize analytical queries, batch operations</li></ul>- Cons	<ul><li> High read and write latency	</li><li> Data model decisions have high impact on performance</li><li>Snapshot isolation concessions</li></ul>|
|Distributed key-value storage with SQL (e.g. yugabyteDB)|These databases  introduce the notion of a distributed key-value store that supports transactions across nodes (key ranges) with snapshot isolation in a scalable manner by using globally synchronized clocks. Subsequent evolutions then added a SQL layer on top, and ultimately even a PostgreSQL interface.Open source/On-prem options like CockroachDB and Yugabyte followed a similar approach without the requirement of synchronized clocks, at the cost of significantly higher latency.|- Pros	<ul><li> Good read and write availability (shard-level failover)	</li><li> Single table, single key operations scale well	</li><li> No additional data modeling steps or snapshot isolation concessions</li></ul>- Cons	<ul><li> Many internal operations incur high latency	</li><li> No local joins in current implementations</li><li> Not actually PostgreSQL, and less mature and optimized</li></ul>|
|Streaming Replication/Hot Standby|Warm and hot standby servers are kept current by reading a stream of write-ahead log (WAL) records from primary. If the main server fails, the standby contains almost all of the data of the main server, and can be quickly promoted. This can be  quorum based where all the standbys appearing in the list will be used as candidates for synchronous standbys. Even if one of them should fail, the other standbys will keep performing the role of candidates of synchronous standby.|-Pros <ul><li>Fail over of primary does not result in data loss within Data center.</li></ul> -Cons <ul><li>Synchronous replication usually requires carefully planing and placing of  standby servers to ensure applications perform acceptably.</li><li>Iincautious use of synchronous replication will reduce performance for database applications because of increased response times and higher contention.</li></ul>|

Based on above comparison, lets us go through couple of approaches in detail.

# Option 1: PostgreSQL Community Edition (OSS) with Data Partitioning (a.k.a Sharding)
 
## Brief
 
  As of this writing, PostgreSQL Community Edition does not offer Synchronous Multi-master deployment (ref: [here](https://www.postgresql.org/docs/current/different-replication-solutions.html)) where any server can accept write requests. 
  
 Considering above, Data Partitioning based approach can be considered. In a nutshell, Data Partitioning is one of the basic scalability technique.
 It works by dividing the data into smaller sets and assigning it to a Server (in this case PG Database). So a server becomes independant of others as they share nothing.

 - Why data partitioning/Sharding?
     - The core motivation behind data partitioning is to divide the data set so that it could be distributed across servers such that there is no data overlap.
     - Without data overlap, each server can make authoritative decisions about data modifications without communication overhead and without affecting availability during partial system failures.

 - Since PG only supports single-primary architecture, all application writes must be routed to designated primary node in respective data centers. Data partitioning can help achieve this.
 - Overall approach is to assign tenants per data center so as to achieve shared nothing scheme. 
 
## Approach 

![Proposed Architecture with Sharding](/images/hadc_image2.svg)

  - Sharding can be implemented at Application level or Database level. We will look at both the options. 
  - Sharding helps address the concerns with  data size per server by distributing them across. However, for the purpose at hand, primary interest is in shared nothing approach it offers so as to overcome lack of "Active-Active"/Multi-master support in PostgreSQL. 
  - **Sharding key** - is the information that is used to decide which server is responsible for the data that you are looking for (e.g. Institution ID). It helps to split the data so it could live in separate databases and then find a way to route all of your queries to the right database server. The data store does not need to support sharding for application to use it.
  - For sharded systems, below are concerns from operational perspective, 
    - *Monitoring* - Aggregate metrics and logs across data centers to get view of system health
    - *Backup and restore* - Need to plan back up and restore process for shards.A point-in-time restore of one shard can create inconsistencies with other shards.
    - *Schema changes* - Data definition language (DDL) changes need to be planned across shards. 

  - Below image shows how sharding looks like,  
  
      ![Sharding Approach](/images/hadc_image3.svg)

  - Sharding at Application level 
      - Within Application, one probable approach (among many) is to, 
        - Use modulo function to map from the sharding key value to the database number, but to start with, each database can be  a logical PG database rather than a physical machine 
        - To start with,  initial number of PG Servers will have to provisioned in Active-Passive mode  and forecast how many more servers will be needed down the road. 
        - For e.g., to begin with 2 servers with 32 databases each, each of these will be provisioned as logic databases with exact same schema on these servers. Refer below diagram, 

            ![Manual Sharding at Database](/images/hadc_bookimage.png)

        - At Application level, implement mapping functions that allow you to find the database number and the physical server number based on the sharding key value. For e.g.  ```getDbNumber``` function that maps the sharding key value (like a Institution ID) to the database number (in this case, 32 of them) and ```getServerNumber```, which maps the database number to a physical server number (in this case, we have two). 
        - As the database grows and need is to scale out, simply split your physical servers in two. For e.g.  take half of the logical database and move it to new hardware. At the same time,  modify  mapping code so that getServerNumber would return the correct server number for each logical database number.
        - *No data loss* requirement requires us to use *Streaming replication/Hot standy* within a data center. However, this can only address failure of primary database and not the failure of Application nodes or data center itself. This confiuration can be deployed using [Patroni](https://github.com/zalando/patroni) or [pg_auto_failover](https://github.com/hapostgres/pg_auto_failover).

        - Challenges 
           - *Modulo* function based approach  works for static shard counts, but for dynamic shards, alternate approaches  `Consistent Hashing` or `Directory-based mapping` will have to be considered. Refer [here](https://learn.microsoft.com/en-us/azure/architecture/patterns/sharding#advantages-and-considerations-for-each-strategy) for comparison of sharding strategy. Selection of strategy will have impact on infrastructure required as well as on operational complexity.
           -  For future horizontal scalability of database, shard-specific database will have to be migrated to new servers with appropriate configuration changes to application sharding logic. 
           -  Cross-shard queries will require additional consideration as it will require "Scatter-gather" approach to connect to multiple databases and then aggregating results. 
         This is one of the many approaches for sharding and will need careful consideration before finalizing it.

    -  For the business case at hand, The load balancer is likely to route requests in round-robin or using any other algorithm, with no consideration for sharding across data centers. Hence, application in each data center will have to determine if it can process the request based on sharding key or else route the request to other data center.
        
    ![Sequence showing routing](/images/hadc_image4.svg)

    - This approach can be further enhanced as below, 
       -  Routing logic can be implemented as service  which can be independently deployed in redundant configuration if required.
       -  This service will act as *pass-through* proxy where it decrypts the request and either forwards it to local App for processing or routes it to  other data center depending on sharding logic. 
       -  Such service can implement health check check/Liveness probs for endpoint in other data center to continuously monitor the health and proactively respond with error for requests that require such routing. 
    -  Drawbacks ,
       -  This is not a truly High availability configuration since In case of disruption at any data center, significant percentage (up to 50% if shards are evenly distributed across data centers) of transactions will be impacted. Measures like provisioning exact replica of Application + Database servers will have to be planned in corresponding data center. This will result in additional expenditure and operational considerations.
       -  Horizontal scaling of database and movement of respective shards (logical databases) will require careful operating procedure to minimize down time. 
       -  Routing of requests between shards results in additional network round trips and will impact throughput. 
        

  - Sharding at Database level (Automatic Sharding)
    - Although application-level sharding is a great way to increase your I/O capacity and allow your application to handle more data, a lot of challenges come with it. Code becomes much more complex, cross-shard queries are a pain point, and adding hardware and migrating data can be a challenge.
    -  Within PostgreSQL Universe, Citus (ref: [here](https://docs.citusdata.com/en/stable/get_started/concepts.html)), open source extension, provides sharding at database level.  It provides row-based and schema-based sharding. With schema-based sharding (ref: here), the schema becomes the logical shard within the database. Multi-tenant apps can a use a schema per tenant to easily shard along the tenant dimension. Query changes are not required and the application usually only needs a small modification to set the proper search_path when switching tenants.  While  row-based sharding is claimed to be suitable for analytical workload , schema based can be considered for Multi-tenant or microservices based OLTP workload.
  
     - Citus provides,
        - Schema management with appropriate transactions and locking
        - automatic zero-downtime rebalancing
        - reference tables enable more compact data models

    ![Automatic Sharding using Citus](/images/hadc_image6.svg)

      - Pros and Cons
        - Leveraging open source extension backed by Microsoft.
        - Application instance still needs to decide if it can serve the request but connection management to connect to sharded schema is not needed in Application 
        - Automatic rebalancing of shards
        - Additional database nodes for coordinator 
        - Cross-shard queries are not natively supported.
        - Read and write latency needs to be verified against expected SLOs

## Summary
  
-  This approach provides workaround for lack of Multi-master support in PG Community Edition without any proprietary/commercial software . 
- Sharding introduces substantial and permanent complexity into your data architecture. That complexity affects development, operations, testing, query design, and failure recovery for the system's lifetime. 
-  Note that is not a true Active-Active setup but given the objectives,  with careful planning,  RPO can be minimized as even in case of failure at one of the data center, tenants on other data center can still be served.
-  Sharding logic at Application level can be as simple as the one explained (i.e. using ```Modulo```) or it can be complex that uses DCS (Distributed configuration store) like etcd to manage sharding information. This will be dictated by Application requirements.
-  Although application-level sharding is a great way to increase your I/O capacity and allow your application to handle more data, a lot of challenges come with it. Your code becomes much more complex, cross-shard queries are a pain point. If this concerns outweigh the benefits then sharding using Citus can be considered.
-  Alternative to application-level sharding is to use automatic sharding for PostgreSQL using extension like Citus.

# Option 2: Using YugaByte OSS
 
## Brief
 This approach uses YugaByte OSS, open source distributed database with support for PostgreSQL protocol. Yugabyte is a distributed database and offers horizontal scalability by auto sharding data on multiple servers to enhance fault tolerance with no specific measures required in Application. Within a cluster, it needs to maintain quorum depending on the RTO/RPO requirements.  Every table is shared in tablets and stored across nodes in cluster. Within cluster, data is replicated synchronously. Replication occurs at tablet level. One tablet is initialized as leader and the rest are followers. It provides XCluster replication setup for setting up bi-directional replication across data centers. However, only Asynchonous replication is supported in bi-directional mode. YugabyteDB replicates data across fault domains (i.e. data center in this case) in order to tolerate faults. The replication factor (RF) is the number of copies of data in a YugabyteDB cluster.

 ![Using Yugabyte OSS as Data store](/images/hadc_image5.svg)

  - Pros
	  - No need for Application level routing/sharding as both Data centers can be in Active mode.
		- Automatic partitioning by the database 
		- Xcluster bi-directional /two-way works with 2 data centers.

  - Cons
    - To achieve a fault tolerance of 1 data Center, the primary cluster has to be configured with a RF of at least 3 [] 2*(1) + 1].Accordingly, additional infrastructure (Bare metal or VM Servers) will be needed as well as for control pane (for monitoring, configuration etc.) 
		- In bi-directional replication mode, 
			- Only supports Asynchronous replication.
			- For conflict resolution, it implements "Last write wins" approach.
			- Potential data loss: In the event of a data center failure, any data that has not yet been replicated to the secondary data center will be lost.
			- Stale reads: When reading from the secondary data center, there may be a delay in data availability due to the asynchronous nature of the replication. This can result in stale reads
			- Read and write latency needs to be analyzed.
		- May lead to inconsistencies if schemas or data modifications are not carefully coordinated across clusters.
		- Tools and interfaces are only provided in Commercial version. This may make operational management (via command line tools) cumbersome.

# Comparison of Options 

|Architecture Metric|PostgreSQL OSS with Application level Sharding|Postgresql OSS with automatic data Sharding using Citus|Using Distributed SQL (YugaByte)|
|:--- |:--- |:--- |:--|
|True Active-Active Writes|No. Active-Passive at DB level. Writes must hit a single designated Primary node.|No. Active-Passive at DB  Level.|Yes. Distributed sharding allows concurrent writes across nodes in both DCs but with asynchronous replication.|
|RPO = 0 Capability|No but can be minimized|No but can be minimized|No as Asynchronous replication between data centers might result in data loss|
|Automated Failover|Manual / High Risk. Automatic promotion of replica/slave will need tools like Patroni or pg_auto_failover.|Manual / High Risk. Automatic promotion of replica/slave will need tools like Patroni or pg_auto_failover.| Yes.|
|Operational Overhead|Sharding will be done at Application with need for routing layer. Managing a manually sharded environment increases the difficulty of routine tasks. Schema updates, backups, and point-in-time recovery must be coordinated across multiple independent instances.|Yes.Coordinater nodes to be deployed in HA mode. Requires familiarity operating Citus. |Zero manual sharding needed; horizontal scaling is handled natively by the engine. More efforts needed by DBA for OSS Version as Control pane is not available for configuration|
 

## Reference Links, 

- [PostgreSQL: Comparison of replication solutions](https://www.postgresql.org/docs/current/different-replication-solutions.html)
- [Why sharding is bad for business](https://www.cockroachlabs.com/blog/sharding-bad-business/)
- [Understanding partitioning and sharding in Postgres and Citus - Citus Data](https://www.citusdata.com/blog/2023/08/04/understanding-partitioning-and-sharding-in-postgres-and-citus/)
- [Concepts — Citus 13.0.1 documentation](https://docs.citusdata.com/en/stable/get_started/concepts.html)
- [Cluster Management — Citus 13.0.1 documentation](https://docs.citusdata.com/en/stable/admin_guide/cluster_management.html?highlight=high+availability)
- [Sharding Pattern - Azure Architecture Center | Microsoft Learn](https://learn.microsoft.com/en-us/azure/architecture/patterns/sharding)
- [PostgreSQL: Documentation: 18: 26.1. Comparison of Different Solutions](https://www.postgresql.org/docs/current/different-replication-solutions.html)
- [What is data sharding | Google Cloud](https://cloud.google.com/discover/what-is-database-sharding)
