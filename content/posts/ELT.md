---
title: "ELT approach to Data Pipeline"
date: 2021-03-14T00:00:00+05:30
draft: false
tags: [DBT, ELT, ETL, Python, Go, PostgreSQL, CSV,data pipeline, nsetools]
---

## Introduction

While gathering data for Analytics, one often has to source data from multiple sources. Traditionally, the approach has been to do ETL (Extract-Transform-load) where,

* **Extract** - typically involves retrieving data from source. This could also be via streaming
* **Transform** - Apply transformation to the extracted data.
* **Load** -  Loading the data in Operation Data store (ODS) or data warehouse
Refer [here](https://www.sas.com/en_us/insights/data-management/what-is-etl.html#close) for more details on ETL. ETL has been made easy by tools like [Talend](https://www.talend.com/products/talend-open-studio/), [SSIS](https://docs.microsoft.com/en-us/sql/integration-services/sql-server-integration-services) and so on.

However, there has been shift from above approach due to,

* Need to handle different kinds of data (Structured and Unstructured) 
* hugh volumes of data (IOT, Customer data management) 
* Availability of cheaper storage and compute along with availability of internet scale cloud based data warehouses

has recently caused wide adoption of ELT (Extract-transform-load) over ETL.

ELT offers an alternative to ETL in which data is loaded into the warehouse (sometimes in storage area called as data lake) before transforming it. It allows focussing on extraction and loading with heavy transformation offloaded to later stage. Since the transformation happens in the warehouse, it can potentially be defined using SQL (thus using same language across the pipeline). This allows more roles (say Data Analysts) to contribute to (or entirely own) the transformation logic. Data warehouse becomes single source of truth for data. Ref: [ETL vs ELT](https://dataschool.com/data-governance/etl-vs-elt/)

Typically, Data flow pipeline consists of below phases (it also lists available tools for each phase),

* Ingestion - [Airbyte](https://airbyte.io), [Fivetran](https://fivetran.com), [Stitch](https://stitchdata.com) 
* Warehousing - [Snowflake](https://snowflake.com), [BigQuery](https://cloud.google.com/bigquery), [Redshift](https://aws.amazon.com/redshift), [PostgreSQL](https://postgresql.org)
* Transformation - [dbt](https://getdbt.com)
* Orchestration - [Airflow](airflow.apache.org), [Prefect](https://prefect.io), [Dagster](https://dagster.io)
* BI - [Superset](superset.apache.org), [Metabase](https://metabase.com), [Redash](redash.io), [Looker](looker.com) etc.

I think the best way to understand the landscape is to use above tools. So i decided to implement below problem statement. The requirement is to run a weekly process that,

1. Downloads list of CNX 500 companies from Exchange's web site
2. For each of the company , get Last traded price(`ltp`) and 52 week high price (`yearlyhigh`)
3. Exclude companies having ltp < 20 or ltp > 50000
4. Rank companies by closeness of `ltp` to `yearlyhigh`
5. Prepare `buy` list of up to 20 such companies. Earlier short listed stocks, which are not in top 20 this week or further than 5% from their `yearlyhigh`, should be marked for `sell`.

Above is hypothetical example and using full fledged data stack may be overkill but should suffice the purpose of this article.

### `E` & `L` in ELT -  Get the list of CNX 500 Companies and also get stock price for each of them 

Below are some of the options available for this task under `extract` and `load` category,

* Use Python to download list of stocks and then use [yfinance](https://pypi.org/project/yfinance/) to get the price and yearly high. 
* Use tool like [Airbyte](https://airbyte.io) which provides declarative way of importing the data via HTTP. I am planning to explore this option later.
* Use Go to perform the task. I decided to go with this one and code is available at [here](https://github.com/sachinsu/momentumflow/tree/main/gover). It downloads CSV file from Exchange's website (containing list of stocks in Index) and loads them to database. Since Yahoo finance no longer provides Free tier for API, It uses [htmlquery](github.com/antchfx/htmlquery) library to parse HTML and retrieve stock price and yearly high value. 

### `T` in ELT - Transform the company-wise data to arrive at weekly list of momentum stocks

This is implemented using [dbt](https://getdbt.com). dbt (Data Build Tool) is a framework to facilitate transformations using SQL along with version control, automates tests, support for incremental load, snapshots and so on. It has `notion` of **project** or **workspace** that many developers are familiar with. 
It is offered as Command line interface (CLI)  as well as on cloud which also provides web based UI. I have used CLI for this exercise. For a quick recap of dbt folder structure, refer [here]https://towardsdatascience.com/data-stacks-for-fun-nonprofit-part-ii-d375d824abf3).

Source code of dbt project [here](https://github.com/sachinsu/momentumflow/tree/main/dbt).  We will go through key part of this project which are Models that carry out the transformation. After the initial setup of dbt like configuring target (i.e. data source which in this case is a PostgreSQL database), below are Models used,

 * Since Loading  of company-wise data is already done in earlier step, next step is to rank the companies w.r.t. `closeness` to their yearly high. Below is `dbt` SQL which does it (At run time, dbt converts below SQL to the one understood by the Target database), 

        ```

        {{
            config(
                materialized='incremental',
            )
        }}

        with
            cnxcompanies
            as
            (

                select
                    symbol,
                    company,
                    ltp,
                    yearlyhigh,
                    updatedat,
                    rank() over (order by yearlyhigh-ltp) as diff_rank
                from {{ source('datastore', 'cnx500companies') }}
            where yearlyhigh::money::numeric::float8 - ltp::money::numeric::float8 > 0 and ltp::money::numeric::float8 > 20 and ltp::money::numeric::float8 < 50000

        ),
        cnxtopstocks as
        (

            select
            symbol,
            company,
            ltp,
            yearlyhigh,
            updatedat,
            diff_rank
            from  cnxcompanies
            order by updatedat desc,diff_rank 
        )

        select * from cnxtopstocks

        ```
   Above model creates corresponding table in database (as such dbt abstracts changes to database from developer and manages it on its own). Note that model is marked `incremental` so that it doesn't overwrite the table on every run but rather incrementally applies changes. 

* Next step is to arrive at Weekly list of stocks to `buy` and even `sell` those which are lacking momentum. 

        ```

        {{
        config(
        materialized='incremental',
        unique_key='concat(symbol,updatedat)'
            )
        }}

        with currentlist as (
            select distinct symbol,
                    company,
                    ltp,
                    yearlyhigh,
                    updatedat,diff_rank,'buy' as buyorsell
            from  {{ref('rankstocks')}} 
            where (yearlyhigh-ltp)/ltp*100 <= 5
            order by updatedat desc, diff_rank
            limit 20
        ),
        finallist as (
            {% if is_incremental() %}
                select symbol,
                    company,
                    ltp,
                    yearlyhigh,
                    updatedat,diff_rank,'sell' as buyorsell from {{this}} as oldlist
                    where not exists (select symbol from currentlist where symbol=oldlist.symbol and (yearlyhigh-ltp)/ltp*100 <= 5 )
                union 
                select  symbol,
                    company,
                    ltp,
                    yearlyhigh,
                    updatedat,diff_rank,'buy' as buyorsell  from  currentlist 
                    where not exists (select symbol from {{this}} where symbol=currentlist.symbol and buyorsell='buy')   
            {% else %}
                select * from currentlist
            {% endif %}
        )


        select * from finallist

        ```

    This model refers to earlier one using `{{..}}` jinja directive. It also refers to itself using `{{this}}` directive. 

    Among others, below are key feature of DBT that were observed,

  * Concept of Project/Workspace which programmers are typically familiar with
  * Using SQL for Data Transformation
  * Support for Version control
  * Support for testing
  * Support for incremental load 
  * Support for snapshots
  * Automatic schema updates
  * Out of the box Documentation browser covering traceability across sources and models.

### Orchestration 

After completing `ELT` aspects, now it's time to  orchestrate this pipeline wherein the whole process will run every week. Typically, one can use task scheduler like Airflow or Prefect to do this. But for the purpose of this article, lets use [at](https://docs.microsoft.com/en-us/troubleshoot/windows-client/system-management-components/use-at-command-to-schedule-tasks) on windows (or [cron](https://en.wikipedia.org/wiki/Cron) if you are using Linux). 

so a simplest possible batch file (as below), 

```
set http_proxy=
set https_proxy=

.\gover\go run .

.\.venv\scripts\activate & .\dbt\dbt run
```    

will run the whole process and generate weekly list in `weeklylist` table in database. This batch file can be scheduled to run on weekly basis using command `at 23:00 /every:F runscript.bat`. 

This is very basic approach to scheduling (with no error handling/retries or monitoring). Hopefully, i will be able to work on these part (something like [this](https://docs.airbyte.io/tutorials/connecting-el-with-t-using-dbt)). Till then...

### Useful References

* [Reverse ETL](https://medium.com/memory-leak/reverse-etl-a-primer-4e6694dcc7fb)
* [Data stacks for Fun and Profit](https://towardsdatascience.com/data-stacks-for-fun-nonprofit-part-ii-d375d824abf3)
* [What warehouse to use](https://dataschool.com/data-governance/what-warehouse-to-use/)

Happy Coding !!

---

{{< comments >}}