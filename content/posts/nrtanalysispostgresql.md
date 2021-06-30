---
title: "Near real time Analysis with Grafana and PostgreSQL"
date: 2021-06-30T10:25:04+05:30
draft: true
tags: [postgresql, real-time, analytics, sql, timescaledb]
---

## Introduction 

In a scenario where Application is distributed in nature and based on Micro services/Service Oriented Architecture and it is expected to be available 24*7, having proper monitoring of Application health in place is very important. What if Monitoring is after thought and Application is already in production  using relational data store with no apetite for adding specialized storage for logs/metrics/traces? 

Typical pillars of "Observability" are Application Logs, Metrics and traces. With standards like Opentelemetry, some have [suggested](https://logz.io/blog/opentracing-opencensus-opentelemetry-what-is-distributed-tracing/) that traces (distributed ) will be only thing that matters going forward. 

Anyway, for the sake of this post, let us see how we can add Near real time monitoring of APIs using relational data store (PostgreSQL) and open source Visualization tool, Grafana.

## Approach 

The current high level architecture looks like below, 

todo: add diagram

Given that, Organization is already heavily invested in infrastructure for Compute (API Layer etc.), Data storage for OLTP and has no apetite for additional dedicated hardware for Observability, this approach primarily leverages data store already in use, as below, 
 
* [PostgreSQL](https://www.postgresql.org) - Data store for Analytics and Reporting 
* [TimescaleDB](https://www.timescale.com) - Timescale plugin for PostgreSQL 
* [Grafana](https://grafana.com/oss/) - Data Visualization.
* [FluentBit](https://fluentbit.io/) - Processing of Web Server logs & forwarding to database

## Setup & Installation
todo:  timescaledb, fluentbit, grafana


create table apilog
(time    timestamptz  not null,
 business  text not null,
 outcome  text not null,
 timeout  timestamptz );


insert into apilog
SELECT (current_timestamp - '0 day'::interval), (case when x = 1 then 'finance' 
                                  else 'it' end),  (case when x < 2 then 'success' else 'failure' end),   (current_timestamp - '0 day'::interval) + trunc(random()  * 20) * '1 second'::interval FROM generate_series(0, 5000, 5) AS t(x);

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

## steps to dashboard


Happy Coding !!

---

{{< comments >}}