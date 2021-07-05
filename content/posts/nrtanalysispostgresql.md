---
title: "Near real time Analysis with Grafana and PostgreSQL"
date: 2021-06-30T10:25:04+05:30
draft: true
tags: [postgresql, real-time, analytics, sql, timescaledb]
---

## Introduction 

Suppose you have a distributed application running in production and it is based on Micro services/Service Oriented Architecture and have SLA of being "always on" (be available 24*7, barring deployments of course !!). In such cases, having proper monitoring of Application health in place is absolutely essential.

What if Monitoring is after thought and Application is already in production using relational data store with no apetite for additional components like (Visualization tools, specialized storage for logs/metrics/traces) for monitoring? 

Monitoring and more generically,  "Observability" has three pillars. They are  Logs, Metrics and traces. Many of the existing applications are producing either (mostly logs or traces) but seldom all. There are on-going developments With standards like Opentelemetry in this field.  Some have [suggested](https://logz.io/blog/opentracing-opencensus-opentelemetry-what-is-distributed-tracing/) that traces (distributed) will be only thing that matters going forward. 

Anyway, for the sake of this post, let us see (one among many) approach to provide Near real time monitoring of APIs using relational data store (PostgreSQL) and open source Visualization tool, Grafana.

## Approach 

The high level architecture looks like below, 

{{< figure src="/images/apparch.png" title="High Level Architecture" >}}

Given that, Organization is already heavily invested in infrastructure for Compute ,relational Data storage  and has no apetite (for now) for additional dedicated hardware for Observability, this approach primarily leverages below, 
 
* [PostgreSQL](https://www.postgresql.org) - Data store for Analytics and Reporting 
* [TimescaleDB](https://www.timescale.com) - Timescale plugin for PostgreSQL 
* [Grafana](https://grafana.com/oss/) - Data Visualization.
* [FluentBit](https://fluentbit.io/) - Processing of Web Server logs & forwarding to database

## Setup & Installation
todo:  timescaledb, fluentbit, grafana

### TimescaleDB

[Timescale](https://www.timescale.com) is a Postgresql Plugin for time-series data management.

*Rationale*

-  The reports and dashboards expected for near real time API monitoring are time intensive in nature. 
- TimescaleDB is optimized for such [time intensive reporting](http://softwareengineeringdaily.com/wp-content/uploads/2021/06/SED1289-Mike-Freedman.pdf) and suits well for this use case as it is a plugin over PostgreSQL, which is already being used for analytics/reporting. 

Installation of plugin is straightforward. Step by Step [tutorial](https://docs.timescale.com/timescaledb/latest/how-to-guides/install-timescaledb/self-hosted/rhel-centos/installation-yum/#yum-installation) is very helpful.

Next step is to create a database for the data to be used for Monitoring. [Hyper table(s)](https://docs.timescale.com/timescaledb/latest/overview/core-concepts/hypertables-and-chunks/) in this database will contain Metrics data, collected from Application and web server (IIS). 

One of the dashboard was to monitor APIs in terms of success & failure (%), Response times (in buckets). For each API invocation, application will collect below details and persist in database. This table will look like below,

| Attribute | Description       |
|-----------|-------------------|
|  Time     | Timestamp of event |
|  Tusiness | Attribute indicating domain of API  |
|  Outcome  | Outcome of the API Invocation i.e. Success or Failure | 
|  Timeout  | Timestamp of completion of API invocation |

Above are minimum attributes needed. As per the use case, this table definition will have to be further updated.

The DDL command will look like,

```

create table apilog
(time    timestamptz  not null,
 business  text not null,
 outcome  text not null,
 timeout  timestamptz );

```

After creation of table, this table will have to be converted into `Hypertable` by using, 

`SELECT create_hypertable('apilog', 'time');`

Note: Once hyper table is created, as such nothing changes from the perspective of SQL Developer and one can easily add data to it with below command (note that below generates dummy data),

```
insert into apilog
SELECT (current_timestamp - '0 day'::interval), (case when x = 1 then 'finance' 
                                  else 'it' end),  (case when x < 2 then 'success' else 'failure' end),   (current_timestamp - '0 day'::interval) + trunc(random()  * 20) * '1 second'::interval FROM generate_series(0, 5000, 5) AS t(x);

```

Next step is to populate this table with real log data. Currently, Application generates log events in OLTP Database and data from this database is replicated to Reporting database. Since we have created new Hyper table to host this data,a simple approach of [Trigger](https://www.postgresql.org/docs/13/sql-createtrigger.html) can be used to populate it from current table. In real scenario, you may want to consider replicating the data directly to hyper table. 

### Web Server Logs 

*** TODO 


With data getting added to timescaledb Hyper table,Lets see how it can be visualized.

Typically, there are 2 approaches to be considered for Visualization, 

- Custom-built Web UI - This only makes sense if, 
  - There is already a Reporting/Visualization Web UI in place and adding new dashboards/reports is not much pain 
  - Not much customization and/or slicing-dicing is expected.
  - Limited Efforts available.

- Off the shelf Tools - This approach makes sense if, 
 - It is expected that Monitoring dashboards should be flexible and provide ease of customization by business or power users. 
 - Additional dashboards are expected or can be provisioned with minimal or no coding. 

  There are many paid and open source tools available. Notable OSS options are,

  - [Grafana](https://grafana.com/oss/) - Tailor made for Monitoring and extensive analysis of Time series data. 
  - [Apache Superset](https://superset.apache.org/) - open-source application for data exploration and data visualization able to handle data at petabyte scale.

Lets see how Grafana can be used for visualization (Probably, i may evaluate superset some time and update this post.)

### Grafana 

Grafana has multiple offerings and one of them being Open source, Self-hosted Application. It has [Go](https://golang.org) backend and is very easy to install. For Windows, Just follow the steps at [Installation](https://grafana.com/docs/grafana/latest/installation/windows/).

** TODO: Add connectivity to postgresql, screenshots of table visualization, screenshots of specific visualization. 




select  $__time(time), business,
    count(*) as total, 
    count(*) filter (where outcome='success')*100.00/count(*)  as successcount,
    count(*) filter (where outcome!='success')*100.00/count(*)  failcount,
    (count(*) filter (where eXTRACT(EPOCH FROM (timeout - time)) = 0) *100.00/count(*) ) as zerocount, 
    (count(*) filter (where eXTRACT(EPOCH FROM (timeout - time)) = 1) *100.00/count(*) ) as onecount, 
    (count(*) filter (where eXTRACT(EPOCH FROM (timeout - time)) = 2) *100.00/count(*) ) as twocount, 
    (count(*) filter (where eXTRACT(EPOCH FROM (timeout - time)) between 3 and 5) *100.00/count(*) ) as threetofivecount, 
    (count(*) filter (where eXTRACT(EPOCH FROM (timeout - time)) between 6 and 10) *100.00/count(*) ) as fivetotencount, 
    (count(*) filter (where eXTRACT(EPOCH FROM (timeout - time)) > 10) *100.00/count(*) ) as morethan10count
    from apilog 
    where $__timeFilter(time)
    group by time,business




Happy Coding !!

---

{{< comments >}}