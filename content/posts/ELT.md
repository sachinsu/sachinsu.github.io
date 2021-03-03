---
title: "Approaches to Data Pipeline"
date: 2021-03-25T00:00:00+05:30
draft: true
tags: [DBT, ELT, ETL, Python, Go, PostgreSQL, CSV,data pipeline]
---

## Introduction

While gathering data for Analytics, one often has to source data from multiple sources. Traditionally, the approach has been to do ETL (Extract-Transform-load) where,

* **Extract** - typically involves retrieving data from source. This could also be via streaming
* **Transform** - Apply transformation to the extracted data.
* **Load** -  Loading the data in Operation Data store (ODS) or data warehouse
Refer [here](https://www.sas.com/en_us/insights/data-management/what-is-etl.html#close) for more details on ETL. 

Need to handle different kinds of (Structured and Unstructured) and hugh volumes of data (IOT, Customer data management) coupled with advent of application of Machine learning models on data and availability of internet scale cloud based data warehouses, have recently caused wide adoption of ELT (Extract-transform-load) over ETL.

ELT offers an alternative to ETL in which  data is loaded into the warehouse (sometimes in storage called as data lake) before transforming it.  Since the transformation happens in the warehouse, it can be defined using SQL. This allows more roles (say Data Analysts) to contribute to (or entirely own) the transformation logic. Data warehouse becomes single source of truth for data. Ref: [ETL vs ELT](https://dataschool.com/data-governance/etl-vs-elt/)

Typically, Data flow pipeline consists of below phases as below (it also lists available solutions for each phase), 

* Ingestion - [Airbyte](https://airbyte.io), [Fivetran](https://fivetran.com), [Stitch](https://stitchdata.com) 
* Warehousing - [Snowflake](https://snowflake.com), [BigQuery](https://cloud.google.com/bigquery), [Redshift](https://aws.amazon.com/redshift), [PostgreSQL](https://postgresql.org)
* Transformation - [dbt](https://getdbt.com)
* Orchestration - [Airflow](airflow.apache.org), [Prefect](https://prefect.io), [Dagster](https://dagster.io)
* BI - [Superset](superset.apache.org), [Metabase](https://metabase.com), [Redash](redash.io), [Looker](looker.com) etc.




Key feature of DBT,

* Concept of Project/Workspace which programmers are typically familiar with
* Using SQL for Data Transformation
* Support for Version control
* Support for testing
* Support for incremental load 
* Support for snapshots
* Out of the box Documentation browser covering traceability across sources and models. 



### Useful References

* [Reverse ETL](https://medium.com/memory-leak/reverse-etl-a-primer-4e6694dcc7fb)
* [Data stacks for Fun and Profit](https://towardsdatascience.com/data-stacks-for-fun-nonprofit-part-ii-d375d824abf3)
* [What warehouse to use](https://dataschool.com/data-governance/what-warehouse-to-use/)


Happy Coding !!

---

{{< comments >}}