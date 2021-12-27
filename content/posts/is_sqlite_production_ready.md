---
title: "Can SQLite be used in Production?"
date: 2021-12-30T01:00:00+05:30
draft: true
tags: [sqlite, go, litestream, rqlite, bombardier]
---

## Introduction

Recently, i saw talk given by [Ben Johnson](Todo:twitter link) on using SQLITE for in production (i.e. for non-trivial use cases). check it out [here](https://www.youtube.com/watch?v=XcAYkriuQ1o). At the outset, SQLite is well in use in specific areas where need is to have  intermediate storage which is better than raw File I/o and when CPU/RAM availability is on the lower end like Mobile Apps, Raspberry Pi based apps and so on. In this Video, it is mentioned that SQLite has support for concurrent writes and can do well for 100s of concurrent requests.  Let us check if SQLite can really be used for non-trivial applications (Excluding those already mentioned like Mobile Apps etc.)



This article is attempt to evaluate SQLITE from the perspective of, 
    - Concurrency support
    - ACID Properties 


https://www.sqlite.org/limits.html

### Useful References

* [Pyroscope](https://pyroscope.io)
* [Crank](https://github.com/dotnet/crank)

Happy Coding !!

---

{{< comments >}}