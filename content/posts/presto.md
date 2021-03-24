---
title: "A look at Presto - Distributed SQL Engine for variety of data stores"
date: 2021-03-02T10:25:04+05:30
draft: true
tags: [Presto, SQL, Database, Parquet, Analytics, Trino]
---

## Introduction

In a company/enterprise, typically there are multiple sources of data. This could be result of M&A (where each of those add in a new data store) or result of multi year process of using data stores that are in vogue at that time. Result is combination of various types of relational databases, flat file systems, queues and so on. This results in Data Silos. This scenario is typically observed in companies who are running workloads On-prem (i.e. Pre-cloud, Companies who started on Cloud or have moved to it, typically tend to organize data platform better. This could be because of ease of migrating data on cloud. Typically, they centralize it around cheaper object storage (say AWS S3)). 

Company will want to utilize this data, accumulated over the years, for business intelligence, machine learning purposes. Usually, it would require querying efficiently across these data sources or first collecting all the data in central location (say Data Lake or Operational Data store) and then querying on it. 

Overall, below are the widely adopted approaches, 

* **Data warehouse with ETL Approach** - This involves extracting data from Transactional systems (OLTP), ERP, Events store and so on. Transforming the same and then loading it into Data warehouse which is typically a store used for Analytics. Whole process is orchestrated as workflow using ETL Tools. 

* **Lakehouse** - Many companies have two different types of storate: Data Lake and Data warehouse. The data warehouse handles `offline` analytics, such as BI dashboards and reports, that describe what has or is happening in a business.  The data lake is store for raw data (including unstructured). Instead of ETL (Extract - Transform - Load), ELT (Extract - Load - Transform) approach is followed where data from transactional system is loaded into Data Lake. Later, it is transformed/processed for analytics purposes and loaded in data warehouse. Alternatively, there is a trend where data lake itself is used for trend and/or predictive analytics. Data lake is usually based on cheaper, object storage with data stored using open formats (like Parquet , ORC etc.) favouring columnar approach. Columnar store is typically favoured for analytics over relational one.

As explained in [Emerging Architecture for Data Infrastructure](https://a16z.com/2020/10/15/the-emerging-architectures-for-modern-data-infrastructure/), 

* Data warehouse is used for analytics use cases i.e. help business make better decisions. 
* Data lake is used for operational use cases.

All the above approaches typically assume rather large volume of data being handled. Then what can be approach for companies who are having moderate amount of data (few terabytes) and still want to derive actionable insights from it. Such companies are unlikely to have big data systems like HDFC in place. 

For these cases, One may consider [**Presto**](https://prestodb.io/) a.k.a. [**Trino**](https://trino.io). At it's core, Presto translates SQL queries (it supports __ANSI SQL__) into whatever query language is necessary to access the underlying storage medium. Storage medium could be a Elasticsearch cluster, or a set of Parquet files on HDFS, or a relational database.

Presto uses *MPP* (Massively parallel processing) architecture in which it has,

*  ``Coordinator`` node - responsible for creating query plan and distributing the work among workers.
* ``Worker`` node(s) - they push down predicates to those data sources. Only the data necessary to compute join is retrieved. All workers operate in parallel mode.

Presto provides many [connectors](https://trino.io/docs/current/connector.html) like below (but not limited to),
* _Relational Databases_
  * MySQL
  * PostGres
  * SQL Server
* _Non-relational Databases_
  * Mongodb
  * Redis
  * Cassandra
* _Columnar file formats like ORC, Parquet and Avro – stored on:_
  * Amazon S3
  * Google Cloud Store
  * Azure Blog Store
  * HDFS
  * Clustered file systems

It's important to note that Presto does not write intermidiate results to disk, Hence worker nodes are expected to be optimized for processing and memory  over storage. A Single Presto query can combine data from multiple sources. Most importantly, Presto can work without Hadoop. Presto has cost-based optimizer which means query plan takes into account the time cost associated with executing that plan and can therefore do various types of optimizations around join ordering and the sequence with which you execute that query plan to deliver the fastest level of performance. 

Below is apt representation of how Presto works (Ref: [prestodb.io](https://prestodb.io))

{{< figure src="https://prestodb.io/img/presto-overview-2.png" title="Where Presto fits" >}}

{{< figure src="https://prestodb.io/img/presto-architecture.png" title="Typical Presto Deployment" >}}

Typical use cases for Presto are, 

* Ad-hoc, Interactive Analytics 
* Batch ETL processing.
* Centralized Data Access with Query Federation

From the consumption perspective, Presto Offers CLI as well as JDBC Driver. However, there are many [language specific clients](https://trino.io/resources.html) available from Community.

Key points to note while considering Presto, 

* No need for complex ETL/ELT processes and related Monitoring. 
* No need to provision for  specialized data store for Data Lake and/or Data warehouse.
  * *However, this may not hold true if Query results from Presto are required to persisted. Although, overall efforts and cost will much lower.*
  * *This would also mean that existing data stores need to maintain historical data too*
* Any specific use cases not suitable for Presto will have to be alternatively approached.

Some of the points to explore further would be , 

* Given that Presto does not use storage on its own, how can one perform Capacity planning given the expected workflow ?
* How are failures handled? 


### Useful References/Interesting Links,
- [Trino](https://trino.io)
- [PostgreSQL protocol gateway for Presto distributed SQL query engine](https://github.com/treasure-data/prestogres/)
Happy Coding !!

---

{{< comments >}}