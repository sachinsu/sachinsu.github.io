---
title: "Near real time Analysis with Grafana and PostgreSQL"
date: 2021-06-30T10:25:04+05:30
draft: true
tags: [postgresql, real-time, analytics, sql, timescaledb]
---

## Introduction 

In a scenario where Application is based on Micro services/Service Oriented Architecture

 mainly of HTTP APIs, i
todo: Brief Requirement 


## Approach 

todo: cover brief approach

## Setup & Installation
todo:  PostgreSQL , timescaledb, fluentbit, grafana


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