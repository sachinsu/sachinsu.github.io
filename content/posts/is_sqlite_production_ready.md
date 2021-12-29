---
title: "Can SQLite be used in Production?"
date: 2021-12-30T01:00:00+05:30
draft: true
tags: [sqlite, go, litestream, rqlite, bombardier]
---

## Introduction

Recently, i came across session by [Ben Johnson](https://twitter.com/benbjohnson?lang=en) on using [SQLite in production](https://www.youtube.com/watch?v=XcAYkriuQ1o). 

At the outset, SQLite is well-known as file-based database used in specific use cases like software running on peripheral/low resource devices such as Mobile Apps or in browsers for intermediate storage. In the Video, it is mentioned that SQLite can potentially be used for server applications having 100s of concurrent requests.  lets check.

In SQlite, There can only be a single writer at a time. However, it supports concurrency by allowing multiple connections to be opened to database and it internally serializes the write requests. It is enhanced further when  [WAL (Write Ahead Log) mode](https://www.sqlite.org/wal.html) is used, where transactions are first written to a separate file (called 'log' file) and then moved to database on commit. When WAL Mode is used, it supports simultaneous readers and writers. 

Lets verify if How many concurrent requests can be handled by SQlite.

### Code

To have proof of concept as close to typical real world example, lets expose HTTP based API using [Go](https://go.dev/) as below,

```
import (
	"database/sql"
	"fmt"
	"log"
	"net/http"
	"os"
	"runtime"
	"strings"

	"github.com/rs/xid"
	_ "modernc.org/sqlite"
)

const dbfilepath string = "./foo.db"
const params string = "?_pragma=busy_timeout%3d5000&_pragma=journal_mode%3dwal"

// Open opens the database connection.
func Open(dsn string) (*sql.DB, error) {
	db, err := sql.Open("sqlite", dsn)
	if err != nil {
		log.Fatal(err)
		return nil, err
	}
	// setting this to higher number (i.e.> 1) not only causes constraint violation (probably because the way isolation works in SQLITE over same and diff. connections) and but also degrades performances
	db.SetMaxOpenConns(runtime.NumCPU())

	return db, nil
}


```
We will use [ModernC Sqlite](https://pkg.go.dev/modernc.org/sqlite) library which is CGO free port of Sqlite. However, there are other libraries listed [here](https://pkg.go.dev/search?q=sqlite&m=)

Largely, databases are expected to provide,

| Criteria      | Description | SQLite |
| ----------- | ----------- | ----------- |
| ACID Guarantees       | Is Database expected to provide Strong Consistency guarantees? <br> (_this may not be required for every use case_)  |  Yes.<br/>It provides isolation between operations in separate database connections. However, there is no isolation between operations that occur within the same database connection.
| Data Durability  | Does Database maintain data in durable ,consistent way? |Yes        |
| Reliability | Does it provide reliable storage ? (Although storage reliability is not limited only to software and often depends on other factors like type of storage, associated hardware.) | Yes | 
| Availability  | Is database highly available?         | Sqlite being file based
| network partition support | Does database support partitioning of data? | No. Being a file based data storage system, it is constrained on single node i.e. it can be scaled vertically. However, it can be setup in active + Stand-by backup mode using specific tools. Additionally, other databases (files on same node) can be attached to and accessed by application as one database.
| Support   | In case of [FOSS](https://g.co/kgs/P4FWMh) software, is Community active in terms of releases/bug fixes as well as on discussion forums? <br> Are their any providers who provide paid support?        |


https://www.sqlite.org/limits.html

### Useful References

* [Pyroscope](https://pyroscope.io)
* [Crank](https://github.com/dotnet/crank)

Happy Coding !!

---

{{< comments >}}