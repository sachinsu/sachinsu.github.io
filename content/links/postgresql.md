---
title: "PostgreSQL"
date: 2022-01-10T15:08:50+05:30
draft: false
---

# PostgreSQL 

## General Articles

- [Free Postgres database (or SQLite) from fly.io](https://fly.io/blog/free-postgres/?utm_source=hackernewsletter&utm_medium=email&utm_term=code)
- [Using generate_series feature for reporting](https://rob.conery.io/2018/08/01/simple-monthly-reports-in-postgresql-using-generate_series/)
- [When Postgres blocks: 7 tips for dealing with locks](https://www.citusdata.com/blog/2018/02/22/seven-tips-for-dealing-with-postgres-locks/)
- [PostgreSQL - Don't do this](https://wiki.postgresql.org/wiki/Don%27t_Do_This#Database_Encoding)
- [Is PostgreSQL good enough?](http://renesd.blogspot.com/2017/02/is-postgresql-good-enough.html)
- [Online event processing by Martin Klepmann](https://queue.acm.org/detail.cfm?id=3321612)
- [PostgreSQL rocks, except when it blocks: Understanding locks](https://www.citusdata.com/blog/2018/02/15/when-postgresql-blocks/)
- [Connection handling best practice with PostgreSQL](https://techcommunity.microsoft.com/t5/azure-database-for-postgresql/connection-handling-best-practice-with-postgresql/ba-p/790883)
- [10 Things I Hate About PostgreSQL](https://medium.com/@rbranson/10-things-i-hate-about-postgresql-20dbab8c2791)
- [PostgreSQL - Advanced Administration by Bruce Momjian](https://momjian.us/main/writings/pgsql/administration.pdf)
- [Top Tools and Recommendations to Manage Postgres in an Enterprise: Administration, Performance, High Availability, and Migration](https://www.enterprisedb.com/blog/top-tools-and-recommendations-manage-postgres-enterprise-administration-performance-high)
- [Using PostgreSQL as Cache and Read Optimization tips](http://renesd.blogspot.com/2019/10/using-postgresql-as-cache.html)
- [Adyen's Use of PostgreSQL](https://www.adyen.com/blog/updating-a-50-terabyte-postgresql-database)
- [PostgreSQL version Upgrade @ Gitlab](https://about.gitlab.com/blog/2020/09/11/gitlab-pg-upgrade/)
- [Zombodb - PostgreSQL and ElasticSearch work together](https://www.zombodb.com/)
- [Using pg_timetable for job scheduling](https://www.cybertec-postgresql.com/en/products/pg_timetable/)
- [Using pg_cron to schedule background tasks](https://techcommunity.microsoft.com/t5/azure-database-for-postgresql/evolving-pg-cron-together-postgres-13-audit-log-background/ba-p/1829588)
- [Using pg_cron to roll up for Analytics](https://www.citusdata.com/blog/2017/12/27/real-time-analytics-dashboards-with-citus/)
- [PG Database Configuration Helper](https://postgresqlco.nf/)
- [Full text search in PostgreSQL](http://rachbelaid.com/postgres-full-text-search-is-good-enough/)
- [Full text search (Crunchydata)](https://blog.crunchydata.com/blog/postgres-full-text-search-a-search-engine-in-a-database)
- [PostgreSQL - Best practices(Azure)](https://docs.microsoft.com/en-us/azure/postgresql/application-best-practices)
- [Designing high performance time series data table in (RDS) postgresql while using BRIN Index](https://aws.amazon.com/blogs/database/designing-high-performance-time-series-data-tables-on-amazon-rds-for-postgresql/)
- [Informative blog on PostgreSQL](https://depesz.com)
- [Understanding GIN indexes](https://pganalyze.com/blog/gin-index)
- [PostgreSQL - Using SQL for Data Analysis](https://hakibenita.com/sql-for-data-analysis)
- [Approach to Bulk Import in PostGreSQL](https://www.cybertec-postgresql.com/en/postgresql-bulk-loading-huge-amounts-of-data/)
- [Schema updates with zero downtime in PostgreSQL](https://fabianlindfors.se/blog/schema-migrations-in-postgres/)
- [Ways to easily generate JSON in PostgreSQL](https://blog.crunchydata.com/blog/generating-json-directly-from-postgres)
- [Grouping, Rollups and Cubes](https://www.cybertec-postgresql.com/en/postgresql-grouping-sets-rollup-cube/)
- [Row level Security](https://www.tangramvision.com/blog/hands-on-with-postgresql-authorization-part-2-row-level-security)

## Performance tuning, configuration etc.

- [OrioleDB- Solving Wicked problems of PostgreSQL](https://www.slideshare.net/AlexanderKorotkov/solving-postgresql-wicked-problems)
- [5 Minutes in PostgreSQL - Videos](https://www.youtube.com/channel/UCDV_1Dz2Ixgl1nT_3DUZVFw/videos)
- [PostgreSQL Tips](https://www.crunchydata.com/postgres-tips)
- [Optimizing AutoVaccum in Postgresql](https://www.citusdata.com/blog/2022/07/28/debugging-postgres-autovacuum-problems-13-tips/)
- [10 Things i hate about PostgreSQL](https://rbranson.medium.com/10-things-i-hate-about-postgresql-20dbab8c2791)
- [Various index types and their usage](https://blog.crunchydata.com/blog/postgres-indexes-for-newbies?utm_source=hackernewsletter&utm_medium=email&utm_term=data)
- [Few gotchas for Application Developers](https://www.hagander.net/talks/PostgreSQL%20Gotchas%20for%20App%20Developers.pdf)
- [Five tips for healthy PostgreSQL database](https://blog.crunchydata.com/blog/five-tips-for-a-healthier-postgres-database-in-the-new-year)
- [Make PostgreSQL healthy and speedy](https://info.crunchydata.com/blog/cleaning-up-your-postgres-database)
- [Diagnose Linux related Disk & RAM issues](https://www.highgo.ca/2021/02/08/troubleshooting-performance-issues-due-to-disk-and-ram/)
- [PostgreSQL database configuration tuning advicer](https://postgresqltuner.pl)
- [Database configuration for Web Services](https://tightlycoupled.io/my-goto-postgres-configuration-for-web-services/)
- [Online explain analyzer & Generally Good Blog on PostgreSQL](https://explain.depesz.com/)
- [Vertically scaling PostgreSQL](https://pgdash.io/blog/scaling-postgres.html)
- [How PostgreSQL Query Optimizer works](https://www.cybertec-postgresql.com/en/how-the-postgresql-query-optimizer-works/)
- [A Performance Dashboard](https://github.com/ankane/pghero)
- [Simple script to analyse your PostgreSQL database configuration, and give tuning advice](https://postgresqltuner.pl)
- [Tuning PostgreSQL for High Write Throughput](https://www.slideshare.net/GrantMcAlister/tuning-postgresql-for-high-write-throughput)
- [Postgres is a great pub/sub & job server](https://webapp.io/blog/postgres-is-the-answer/)
- [PostgreSQL - Optimize Configuration](https://postgresqlco.nf/en/doc/param/9275132/real-life-example-when-to-use-outer-cross-apply-in-sql/9275865#9275865)
- [Be careful with CTE in PostgreSQL](https://hakibenita.com/be-careful-with-cte-in-postgre-sql)
- [Per core Connection limit guidance for EDB](https://richyen.com/postgres/2021/09/03/less-is-more-max-connections.html)
- [PostgreSQL - Claim unused Index size](https://hakibenita.com/postgresql-unused-index-size)
- [PgBadger - A fast PostgreSQL Log Analyzer](https://github.com/darold/pgbadger)
- [Using CTE to perform binary search on table](https://www.endpoint.com/blog/2020/10/02/postgresql-binary-search-correlated-data-cte)
- [Top tools to manage PostgreSQL](https://www.enterprisedb.com/blog/top-tools-manage-postgres-enterprise-administration-performance-high-availability-and)
- [Performance Impact of idle Postgresql connections (usage of Pgbench)](https://aws.amazon.com/blogs/database/performance-impact-of-idle-postgresql-connections/)
- [How to Manage Connections Efficiently in Postgres, or Any Database](https://brandur.org/postgres-connections)
- [How to Audit PostgreSQL Database](https://severalnines.com/database-blog/how-to-audit-postgresql-database)
- [SQL Optimizations in PostgreSQL: IN vs EXISTS vs ANY/ALL vs JOIN](https://www.percona.com/blog/2020/04/16/sql-optimizations-in-postgresql-in-vs-exists-vs-any-all-vs-join/)
- [PostgreSQL Scaling advice in 2021](https://www.cybertec-postgresql.com/en/postgres-scaling-advice-for-2021/)
- [Security Hardening for PostgreSQL](https://goteleport.com/blog/securing-postgres-postgresql/)
- [Working with Postgres @ Zerodha](https://zerodha.tech/blog/working-with-postgresql/)
- [Using PostgreSQL for Data warehouse](https://www.narrator.ai/blog/using-postgresql-as-a-data-warehouse/)
- [Testing PG High availability with Patroni](https://www.percona.com/blog/2021/06/11/postgresql-ha-with-patroni-your-turn-to-test-failure-scenarios/)
- [Comparison of PostgreSQL Monitoring tools](https://sematext.com/blog/postgresql-monitoring/)
- [Using Timeout feature of PostgreSQL](https://blog.crunchydata.com/blog/control-runaway-postgres-queries-with-statement-timeout)
- [Benchmarking bulk data ingestion in PostgreSQL](https://aws.amazon.com/blogs/database/speed-up-time-series-data-ingestion-by-partitioning-tables-on-amazon-rds-for-postgresql/)
- [All about indexes in PostgreSQL](https://pganalyze.com/blog/postgres-create-index)
- [Use cases for Partitioning](https://blog.anayrat.info/en/2021/09/01/partitioning-use-cases-with-postgresql/#storage-tiering)
- [Asynchronous Commits for faster data loading](https://www.percona.com/blog/2020/08/21/postgresql-synchronous_commit-options-and-synchronous-standby-replication/)
- [Push style Notifications and Background Queue Processing using Listen/Notify and skiplocked](https://www.enterprisedb.com/blog/listening-postgres-how-listen-and-notify-syntax-promote-high-availability-application-layer)

## Interesting Extensions/Products

- [End-to-end machine learning solution](https://postgresml.org/)
- [Incrementally update Materialized Views in real-time using Materialize](https://materialize.io/)
- [Artificial Intelligence with PostgreSQL](https://momjian.us/main/writings/pgsql/AI.pdf)
- [Materialize - Incrementally-updated materialized views - in ANSI Standard SQL and in real time.](https://materialize.com/)
- [pg_bulkload - pg_bulkload is a high speed data loading tool for PostgreSQL.](https://github.com/ossc-db/pg_bulkload)
- [pgcenter - Command-line admin tool for observing and troubleshooting Postgres.](https://github.com/lesovsky/pgcenter)
- [TOTP implementation in PLPGSQL](https://github.com/pyramation/totp)
- [Connection pooler - Odyssey](https://github.com/yandex/odyssey)
- [Connection pooler - PGBouncer](https://www.pgbouncer.org/)
- [Setting up Multiple pgBouncer Instances](https://www.2ndquadrant.com/en/blog/running-multiple-pgbouncer-instances-with-systemd/)
- [Connection pooler and much more - Pgpool-II](https://www.pgpool.net/)
- [Change data capture in PostgreSQL](https://techcommunity.microsoft.com/t5/azure-database-for-postgresql/change-data-capture-in-postgres-how-to-use-logical-decoding-and/ba-p/1396421)
- [Swarm64 DA -20x faster PostgreSQL query performance](https://swarm64.com/swarm64-da/)
- [Greenplum - data warehouse, based on PostgreSQL](https://github.com/greenplum-db/gpdb)
- [Apache Age - graph database functionality for PostgreSQL](https://age.apache.org/)
- [Distributed job-queue built specifically for queuing and executing heavy SQL read jobs asynchronously. Supports MySQL and Postgres.](https://github.com/knadh/sql-jobber)
- [Supabase -Listen to PG changes in real time without using Listen/Notify](https://github.com/supabase/realtime)
- [Job queues, Single reader and pub/sub](https://spin.atomicobject.com/2021/02/04/redis-postgresql/)
- [Use cases for scaling out PostgreSQL - Citus](https://techcommunity.microsoft.com/t5/azure-database-for-postgresql/when-to-use-hyperscale-citus-to-scale-out-postgres/ba-p/1958269)
- [Database lab Engine - Fast cloning of Database for dev/QA/staging](https://postgres.ai/products/how-it-works)
- [PGSync - Sync data from one Postgres database to another](https://github.com/ankane/pgsync)
- [Neon - Serverless Open source PostgreSQL](https://github.com/neondatabase/neon)
- [Push PG Listen/Notify events over Websockets](https://github.com/CrunchyData/pg_eventserv)

## Migration to PostgreSQL

- [Migration Guide from Oracle to PostgreSQL](https://techcommunity.microsoft.com/t5/azure-database-for-postgresql/new-oracle-to-postgres-migration-guide-for-azure/ba-p/2055303)
- [Lessons while migrating from Oracle to PostgreSQL](https://www.cybertec-postgresql.com/en/building-an-oracle-to-postgresql-migrator-lessons-learned/)
- [Reshape - easy-to-use, zero-downtime schema migration tool](https://github.com/fabianlindfors/reshape)
- [Migra - diff tool for PostgreSQL Schema](https://github.com/djrobstep/migra)

## High Availability 

- [Tools for Multi-Master Replication](https://wiki.postgresql.org/wiki/Replication,_Clustering,_and_Connection_Pooling)

## Change Data Capture, Asynchronous change processing etc. 

- [PGQ - Queueing Solution](https://wiki.postgresql.org/wiki/PGQ_Tutorial)
- [PGQ - as used by Skype](https://www.pgcon.org/2009/schedule/attachments/91_pgq.pdf)
- [Bucardo - Asynchronous replication for PostgreSQL using Triggers](https://bucardo.org/Bucardo/)
- [Using Logical Decoding, Wal2json for CDC](https://techcommunity.microsoft.com/t5/azure-database-for-postgresql/change-data-capture-in-postgres-how-to-use-logical-decoding-and/ba-p/1396421)
- [Webedia's approach of using Customer processor (walparser) to read from Wal2JSON and  CDC between PG and Elasticsearch](https://www.postgresql.eu/events/pgconfeu2019/sessions/session/2651/slides/237/Deploy%20your%20own%20replication%20system%20with%20Wal2json.pdf)
- [Message queuing using native postgresql](https://blog.crunchydata.com/blog/message-queuing-using-native-postgresql)
- [Queues in PostgreSQL](https://www.pgcon.org/2016/schedule/attachments/414_queues-pgcon-2016.pdf)
- [Message queueing with native postgresql](https://blog.crunchydata.com/blog/message-queuing-using-native-postgresql)
- [Using PGQ to invalidate caches](https://www.hagander.net/talks/cache_invalidation_2014.pdf)
- [pgstream- turns your  database into an event stream](https://github.com/tmc/pqstream)
- [Wal-listener CLI](https://github.com/ihippik/wal-listener)
- [Postgres as Message Queue](https://dagster.io/blog/skip-kafka-use-postgres-message-queue)

## Data Privacy

- [PostgreSQL Anonymizer -  hides or replaces personally identifiable information (PII)](https://www.postgresql.org/about/news/postgresql-anonymizer-10-privacy-by-design-for-postgres-2452/)