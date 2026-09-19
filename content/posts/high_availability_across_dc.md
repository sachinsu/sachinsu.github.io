+++
title = 'High availability For Critical Applications with multi-datacenter deployment'
date = 2026-09-18T07:07:07+01:00
draft = true
+++

# Excutive Summary and key Constraints

To provide High availability for mission-critical  Applications with below objectives,

  - Aim for 99.9% (~ 8.8 hours of downtime/year) availability utilizing two on-premises data centers  with 1 Gbps network bandwidth between datacenters. Bandwidth is shared.
  - Applications have balanced-mix (Read and write) access pattern
  - Aim for Zero Recovery Point Objective (RPO = 0)
  - To be cost effective by means of using open source tools/applications as much as possible.
  - Aim for lesser operational complexity. 

## Current State (Deployment)

 ![Current Deployment Architecture](/images/hadc_image1.svg)

  - **Infrastructure:** Two (2) Physical On-Premises Data Centers (DC1 & DC2). No third physical tie-breaker location is available.
  - **Connectivity:** Dedicated 1 Gbps network bandwidth link between data centers.
  - **Workload:** Heavily biased toward database writes (ingestion, updates, state changes)

## Landscape of PostgreSQL Distributed Architectures

Given above, the authoritative state of the application is stored in PostgreSQL  Database. In order to adhere to SLA requirements listed earlier, a single machine PostgreSQL will not suffice.

  - **Goals**
    - **Replication** - Place copies of data on different machines
	- **Distribution** - Place partitions of data on different machines
	- **Decentralization** - Place different DBMS activities on different machines
	
Current landscape of PostgreSQL Distributed Architectures is as follows (Some of the options like "Read replicas", "Cloud database offerings" are not listed as is not relevant for the use case),

| Type |	Description	| Pros and Cons|
|:--- |:--- |:--- |
| Network-attached block storage (e.g. SAN storage)| <ul><li> database files are stored on a different device</li><li>  The database    server typically runs in a virtual machine in a Hypervisor, which exposes a block device to the VM. Any reads and writes to the block device will result in network calls to a block storage API.</li><li>T    he durability and availability benefits of network-attached storage usually outweigh the performance downsides.</li></ul>| - Pros <ul><li> Higher durability (replication) </li><li> Higher uptime (replace VM, reattach) 	</li><li> Fast backups and replica creation (snapshots) </li><li> Disk is resizable </li></ul><br>- Cons 	<ul><li> Higher disk latency (~20μs -> ~1000μs)	</li><li> Lower IOPS (~1M -> ~10k IOPS) 	</li><li> Crash recovery on restart takes time	</li><li> Cost can be high </li></ul>|
|Active-active (e.g. BDR)|In the active-active architecture any node can locally accept writes without coordination with other nodes. It is typically used with replicas in multiple sites, each of which will then see low read and write latency, and can survive failure of other sites. Active-active systems do not have a linear history, even at the row level, which makes them very hard to program against.|- Pros<ul>	<li>Very high read and write availability</li><li>Low read and write latency</li><li>Read throughput scales linearly</li></ul>- Cons<ul><li>Eventual read-your-writes consistency</li>	<li>No monotonic read consistency</li>	<li>No linear history (updates might conflict after commit)</li></ul>|
|Transparent Sharding (e.g. Citus)|Transparent sharding systems like Citus distribute tables by a shard key and/or replicate tables across multiple primary nodes. Each node shows the distributed tables as if they were regular PostgreSQL tables and queries & transactions are transparently routed or parallelized across nodes.Data is stored in shards, which are regular PostgreSQL tables.|- Pros <ul><li> Scale throughput for reads & writes (CPU & IOPS)	</li><li> Scale memory for large working sets	</li><li> Parallelize analytical queries, batch operations</li></ul>- Cons	<ul><li> High read and write latency	</li><li> Data model decisions have high impact on performance</li><li>Snapshot isolation concessions</li></ul>|
|Distributed key-value storage with SQL (e.g. yugabyteDB)|These databases  introduce the notion of a distributed key-value store that supports transactions across nodes (key ranges) with snapshot isolation in a scalable manner by using globally synchronized clocks. Subsequent evolutions then added a SQL layer on top, and ultimately even a PostgreSQL interface.Open source/On-prem options like CockroachDB and Yugabyte followed a similar approach without the requirement of synchronized clocks, at the cost of significantly higher latency.|- Pros	<ul><li> Good read and write availability (shard-level failover)	</li><li> Single table, single key operations scale well	</li><li> No additional data modeling steps or snapshot isolation concessions</li></ul>- Cons	<ul><li> Many internal operations incur high latency	</li><li> No local joins in current implementations</li><li> Not actually PostgreSQL, and less mature and optimized</li></ul>|

Based on the above, lets us go through alternate approaches.

# Option 1: PostgreSQL Community Edition (OSS) with Data Partitioning
 
## Brief
 
  As of this writing, PostgreSQL does not offer Synchronous Multi-master deployment (ref: here) where any server can accept write requests. Efforts towards this are very much "in-progress".   
 - To address this, Data Partitioning based approach can be considered, 
   - Data partitioning splits tables into data sets. Each set can be modified by only one server. For example, data can be partitioned by offices, e.g., London and Paris, with a server in each office. If queries combining London and Paris data are necessary, an application can query both servers, or primary/standby replication can be used to keep a read-only copy of the other office's data on each server.
   - Why data partitioning/Sharding?
     - The core motivation behind data partitioning is to divide the data set so that it could be distributed across servers such that there is no data overlap.
     - Without data overlap, each server can make authoritative decisions about data modifications without communication overhead.
 - Since PG enforces single-primary architecture, all application writes must be routed to designated primary node in respective data centers.

## Approach 

![Proposed Architecture with Sharding](/images/hadc_image2.svg)

  - Sharding can be implemented at Application level or Database level. We will look at both the options. 
  - Implementing sharding will require choosing Sharding key (information that is used to decide which server is responsible for the data that you are looking for). 
  - Sharding At Application level 
    - Below image shows manual sharding 
      ![Sharding Approach](/images/hadc_image3.svg)

    - It requires arrive at sharing key (e.g. Institution ID) to split the data so it could live in separate databases and then find a way to route all of your queries to the right database server. The data store does not need to support sharding for application to use it.
      - One Probable approach (among many) is to, 
        - Use modulo function to map from the sharding key value to the database number, but each database is just a logical PG database rather than a physical machine
        - This will require initial number of PG Servers to start with and forecast how many more servers will be needed down the road. 
        - For e.g., to begin with 2 servers with 32 databases each, each of these will be provisioned as logic databases with exact same schema on these servers. Refer below diagram, 
            ![Manual Sharding at Database](/images/hadc_bookimage.png)
        - At Application level, implement mapping functions that allow you to find the database number and the physical server number based on the sharding key value. For e.g. ```getDbNumber``` function that maps the sharding key value (like a Institution ID) to the database number (in this case, 32 of them) and ```getServerNumber```, which maps the database number to a physical server number (in this case, we have two). 
        - As the database grows and need is to scale out, simply split your physical servers in two. For e.g.  take half of the logical database and move it to new hardware. At the same time,  modify  mapping code so that getServerNumber would return the correct server number for each logical database number.
        -  Challenges 
           -  With application level sharding, There will be need to generate globally unique identifier that is unique across shards. PG UUID data type is one such data type that can be considered.
           -  For future horizontal scalability of database, shard-specific database will have to be migrated to new servers with appropriate configuration changes to application sharding logic. 
           -  Cross-shard queries will require additional consideration as it will require "Scatter-gather" approach to connect to multiple databases and then aggregating results. 
         This is one of the many approaches for sharding and will need careful consideration before finalizing it.
    -  For the business case at hand, The load balancer is likely to route requests in round-robin or using any other algorithm, with no consideration for sharding across data centers. Hence, application in each data center will have to determine if it can process the request based on sharding key or else route the request to other data center.
        
        ![Sequence showing routing](/images/hadc_image4.svg)
    -  This approach can  be further enhanced as below, 
       -  Routing logic can be implemented as service which can be independently deployed in redundant configuration if required. 
       -  Such service can implement health check check/Liveness probs for endpoint in other data center to continuously monitor the health and proactively respond with error for requests that require such routing. 
    -  Drawbacks ,
       -  This is not a truly High availability configuration since In case if all servers in any data center are not available then significant percentage (up to 50% if shards are evenly distributed across data centers) of transactions will be impacted. Measures like provisioning exact replica of Application + Database servers will have to be planned in corresponding data center. This will result in additional expenditure and operational considerations.
       -  Horizontal scaling of database and movement of respective shards (logical databases) will require careful operating procedure to minimize down time. 

  - Sharding at Database level
    - Although application-level sharding is a great way to increase your I/O capacity and allow your application to handle more data, a lot of challenges come with it. Code becomes much more complex, cross-shard queries are a pain point, and adding hardware and migrating data can be a challenge.
    -  Within PostgreSQL Universe, Citus (ref: here), open source extension, provides sharding at database level.  It provides row-based and schema-based sharding. With schema-based sharding (ref: here), the schema becomes the logical shard within the database. Multi-tenant apps can a use a schema per tenant to easily shard along the tenant dimension. Query changes are not required and the application usually only needs a small modification to set the proper search_path when switching tenants.  While  row-based sharding is claimed to be suitable for analytical workload , schema based can be considered for Multi-tenant or microservices based OLTP workload.
    -  Citus provides,
      - Schema management with appropriate transactions and locking
      - automatic zero-downtime rebalancing
      - reference tables enable more compact data models
    - Pros and Cons
      - Leveraging open source extension backed by Microsoft.
      - Routing at the Application level is still needed but connection management to connect to sharded schema is not needed in Application 
      - Automatic rebalancing of shards
      - Additional database nodes for coordinator in HA configuration
      - Cross-shard queries are not natively supported.
      - Read and write latency will have to be verified 

## Summary
  
-  This approach provides workaround for lack of Multi-master support in PG Community Edition without any proprietary/commercial software . 
-  Note that is not a true Active-Active setup but with careful planning RPO can be minimized. 
-  Although application-level sharding is a great way to increase your I/O capacity and allow your application to handle more data, a lot of challenges come with it. Your code becomes much more complex, cross-shard queries are a pain point. If this concerns outweigh the benefits then sharding using Citus can be considered.

# Option 2: Using YugaByte OSS
 
## Brief
 This approach involves using YugaByte OSS , which offers PostgreSQL interface, as database. Yugabyte is a distributed database in contrast to PG, works by storing data in multiple servers to enhance fault tolerance. Within a cluster, there are multiple nodes.  Every table is shared in tablets and stored across nodes in cluster. Within cluster, data is replicated synchronously. Replication occurs at tablet level. One tablet is initialized as leader and the rest are followers.

 ![Using Yugabyte OSS as Data store](/images/hadc_image5.svg)

  - Pros
	  - No need for Application level routing/sharding as both Data centers can be in Active mode.
		- Automatic partitioning by the database 
		- Xcluster bi-directional /two-way works with 2 data centers.

  - Cons
    - Additional infrastructure: Minimum of 3 nodes are recommended for Xcluster setup in each data center to achieve replication factor of 3 and may go up if higher replication factor is desired. Additional node is needed for control pane (for monitoring, configuration etc.) 
		- In bi-directional replication mode, 
			- Only supports Asynchronous replication (dependent on network speed, load on servers)
			- For conflict resolution, it implements "Last write wins" approach.
			- Potential data loss: In the event of a data center failure, any data that has not yet been replicated to the secondary data center will be lost.
			- Stale reads: When reading from the secondary data center, there may be a delay in data availability due to the asynchronous nature of the replication. This can result in stale reads
			- Read and write latency needs to be analyzed.
		- May lead to inconsistencies if schemas or data modifications are not carefully coordinated across clusters.
		- Tools and interfaces are only provided in Commercial version. This may make operational management (via command line tools) cumbersome.

# Comparison of Options 

|Architecture Metric|PostgreSQL OSS with Application level Sharding|Postgresql OSS with automatic data Sharding using Citus|Using Distributed SQL (YugaByte)|
|:--- |:--- |:--- |:--|
|True Active-Active Writes|No. Active-Passive at DB level. Writes must hit a single designated Primary node.|No. Active-Passive at DB  Level.|Yes. Distributed sharding allows concurrent writes across nodes in both DCs.|
|RPO = 0 Capability|No but can be minimized|No but can be minimized|No as Asynchronous replication between data centers might result in data loss|
|Automated Failover|Manual / High Risk. Automatic promotion of replica/slave will need tools like Patroni or pg_auto_failover.|Manual / High Risk. Automatic promotion of replica/slave will need tools like Patroni or pg_auto_failover.| <to check>|
|Operational Overhead|Sharding will be done at Application with need for routing layer. Managing a manually sharded environment increases the difficulty of routine tasks. Schema updates, backups, and point-in-time recovery must be coordinated across multiple independent instances.|Coordinater nodes to be deployed in HA mode. Requires familiarity operating Citus. |Zero manual sharding needed; horizontal scaling is handled natively by the engine. More efforts needed by DBA for OSS Version as Control pane is not available for configuration|
 

## Reference Links, 

- [Why sharding is bad for business](https://www.cockroachlabs.com/blog/sharding-bad-business/)
- [Understanding partitioning and sharding in Postgres and Citus - Citus Data](https://www.citusdata.com/blog/2023/08/04/understanding-partitioning-and-sharding-in-postgres-and-citus/)
- [Concepts — Citus 13.0.1 documentation](https://docs.citusdata.com/en/stable/get_started/concepts.html)
- [Cluster Management — Citus 13.0.1 documentation](https://docs.citusdata.com/en/stable/admin_guide/cluster_management.html?highlight=high+availability)
- [Sharding Pattern - Azure Architecture Center | Microsoft Learn](https://learn.microsoft.com/en-us/azure/architecture/patterns/sharding)
- [PostgreSQL: Documentation: 18: 26.1. Comparison of Different Solutions](https://www.postgresql.org/docs/current/different-replication-solutions.html)
- [What is data sharding | Google Cloud](https://cloud.google.com/discover/what-is-database-sharding)