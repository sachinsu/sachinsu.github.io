---
title: "Can SQLite be considered for Server Applications?"
date: 2021-12-30T01:00:00+05:30
draft: false
tags: [SQLite, go, litestream, rqlite, bombardier]
---

## Introduction

While embarking on building any new server application, one of the key requirement is whether it needs durable, persistent storage of data (and in most cases, it does). This is followed by evaluating suitable data store. Likely evaluation criteria is Application's Requirement (Tolerance for eventual consistency, High Availability etc.), Team's familiarity, Costs, Tech. support availability and so on. 
 In case of choices in relational databases, typical go to options are MySQL, PostgreSQL or even proprietary databases like Oracle , SQL Server. Seldom one considers [SQLite](https://SQLite.org) for this purpose. 

At the outset, SQLite is well-known as file-based database used in specific use cases like software running on peripheral/low resource devices such as Mobiles, tablets or in browsers for intermediate storage.Recently, i came across session by [Ben Johnson](https://twitter.com/benbjohnson?lang=en) on using [SQLite in production](https://www.youtube.com/watch?v=XcAYkriuQ1o). In the Video, it is mentioned that SQLite can potentially be used for server applications having 100s of concurrent requests. 

In SQLite, There can only be a single writer at a time. However, it supports concurrency by allowing multiple connections to be opened to database and it internally serializes the write requests. This limitation (of single writer) was addressed by means of implementing [Write ahead log](https://www.SQLite.org/wal.html). In this, where transactions are first written to a separate file (called 'log' file) and then moved to database on commit. When WAL Mode is used, it supports much better concurrent reads and writes to the database. 

Lets check if SQLite can really be considered for non-trivial, server based  applications.

### Code

To have proof of concept (POC) to simulate typical real world use case, lets expose HTTP based API using [Go](https://go.dev/) as below,

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
	db, err := sql.Open("SQLite", dsn)
	if err != nil {
		log.Fatal(err)
		return nil, err
	}
	// setting this to higher number (i.e.> 1) not only causes constraint violation (probably because the way isolation works in SQLite over same and diff. connections) and but also degrades performances
	db.SetMaxOpenConns(runtime.NumCPU())

	return db, nil
}

```
We will use [ModernC SQLite](https://pkg.go.dev/modernc.org/SQLite) library which is CGO free port of SQLite. However, there are other libraries listed [here](https://pkg.go.dev/search?q=SQLite&m=)

Next,we have HTTP handler which exposes `POST` end point and writes data to SQLite database, 

```

func main() {

	err := setUpDB()
	if err != nil {
		log.Println("Error while setting up database")
		return
	}

	db, err := Open(dbfilepath + params)
	if err != nil {
		log.Printf("%q: %s\n", err, dbfilepath+params)
		return
	}

	defer db.Close()

	mux := http.NewServeMux()
	mux.HandleFunc("/Addfoo", FooHandler(db))

	log.Println("Listening on :3000...")
	err = http.ListenAndServe(":3000", mux)
	log.Fatal(err)
}

func genXid() string {
	guid := xid.New()

	return guid.String()
}

func FooHandler(db *sql.DB) func(http.ResponseWriter, *http.Request) {
	return func(w http.ResponseWriter, r *http.Request) {
		if r.URL.Path != "/Addfoo" {
			http.NotFound(w, r)
			return
		}

		switch r.Method {
		case http.MethodGet:
			// Handle the GET request...
			http.Error(w, "method not allowed", http.StatusMethodNotAllowed)

		case http.MethodPost:
			// Handle the POST request...
			tx, err := db.Begin()
			if err != nil {
				log.Printf("begin. Exec error=%s\n", err)
				return
			}
			defer tx.Commit()
			// intVal := randomSeed.Int63()
			uid := genXid()
			_, err = tx.Exec(fmt.Sprintf("insert into Foo(id, Name) values('%s','name-%s')", uid, uid))
			if err != nil {
				log.Printf("Error inserting record -> %s\t%s\n", err.Error(), strings.HasSuffix(err.Error(), "(SQLite_BUSY)"))
				http.Error(w, "Internal Error", http.StatusInternalServerError)
				return
			}
			w.WriteHeader(http.StatusCreated)
		case http.MethodOptions:
			w.Header().Set("Allow", "GET, POST, OPTIONS")
			w.WriteHeader(http.StatusNoContent)
		default:
			w.Header().Set("Allow", "GET, POST, OPTIONS")
			http.Error(w, "method not allowed", http.StatusMethodNotAllowed)
		}
	}
}

```

Above is simple HTTP handler function which is invoked on call to `/Addfoo` endpoint and adds a record to a table in database. 

Next is to check throughput provided by this HTTP API. We can use benchmarking tool for this purpose. It generates a load against API and records the response times, errors and so on and presents analysis based on it.  One such tool is [Bombardier](https://github.com/codesenberg/bombardier) and there are others like [wrk](https://github.com/wg/wrk), [wrk2](https://github.com/giltene/wrk2) and so on. I used Bombardier primarily because it is cross-platform (Golang based) and works on Windows, which i am using to conduct this POC. 

First, application is started as `go run .` which starts the HTTP server, ready to receive requests.

Next is to use Bombardier to assess throughput of the API, 

- With limit of 100 requests per second, result shows,
	-  average latency of 2.23ms with no errors thrown 
	- Database has around 1252 records.
```
bombardier.exe -m POST -l  -r 100  http://localhost:3000/Addfoo 
Bombarding http://localhost:3000/Addfoo for 10s using 125 connection(s)
[===========================================================================================================================================================] 10s
Done!
Statistics        Avg      Stdev        Max
  Reqs/sec        99.96      32.72     254.39
  Latency        2.23ms     4.39ms   119.61ms
  Latency Distribution
     50%     1.72ms
     75%     2.32ms
     90%     3.12ms
     95%     3.31ms
     99%     4.44ms
  HTTP codes:
    1xx - 0, 2xx - 1001, 3xx - 0, 4xx - 0, 5xx - 0
    others - 0
  Throughput:    21.20KB/s

```

- With limit of 100 requests per second, result shows,
	-  average latency of 2.23ms with no errors thrown 
	- Database has around 1252 records.
```
bombardier.exe -m POST -l  -r 100  http://localhost:3000/Addfoo 
Bombarding http://localhost:3000/Addfoo for 10s using 125 connection(s)
[===========================================================================================================================================================] 10s
Done!
Statistics        Avg      Stdev        Max
  Reqs/sec        99.96      32.72     254.39
  Latency        2.23ms     4.39ms   119.61ms
  Latency Distribution
     50%     1.72ms
     75%     2.32ms
     90%     3.12ms
     95%     3.31ms
     99%     4.44ms
  HTTP codes:
    1xx - 0, 2xx - 1001, 3xx - 0, 4xx - 0, 5xx - 0
    others - 0
  Throughput:    21.20KB/s

```

- With limit of 1000 requests per second,
	- Latency has gone up 15x 
	- Still no error reported and database has additional records.

```
bombardier.exe -m POST -l  -r 1000  http://localhost:3000/Addfoo 
Bombarding http://localhost:3000/Addfoo for 10s using 125 connection(s)
[===========================================================================================================================================================] 10s
Done!
Statistics        Avg      Stdev        Max
  Reqs/sec       964.73     314.04    2149.94
  Latency       30.05ms    80.20ms      1.48s
  Latency Distribution
     50%     4.02ms
     75%    16.00ms
     90%    74.75ms
     95%   155.30ms
     99%   434.48ms
  HTTP codes:
    1xx - 0, 2xx - 9670, 3xx - 0, 4xx - 0, 5xx - 0
    others - 0
  Throughput:   202.72KB/s
  ```

- With limit of 4000 requests per second, it looks like below, 

```

bombardier.exe -m POST -l  -r 4000  http://localhost:3000/Addfoo 
Bombarding http://localhost:3000/Addfoo for 10s using 125 connection(s)
[===========================================================================================================================================================] 10s
Done!
Statistics        Avg      Stdev        Max
  Reqs/sec      1304.49     688.92    2199.91
  Latency       95.00ms   174.73ms      2.40s
  Latency Distribution
     50%    35.00ms
     75%    95.11ms
     90%   228.16ms
     95%   382.68ms
     99%      1.02s
  HTTP codes:
    1xx - 0, 2xx - 13186, 3xx - 0, 4xx - 0, 5xx - 0
    others - 0
  Throughput:   275.73KB/s

  ```

Overall, above shows that, 

- SQLite with `WAL` mode on and busy timeout set to 5 seconds can support high concurrency 
- Above is very simplistic test, in real application it is likely going to be very different (i.e. most likely on the lower side of throughput) since there will be multiple connections reading and writing to not one but many tables concurrently. This is likely to impact throughput and latency. 
- One of the factors on why better throughput is recorded could be because SQLite, being implemented as library, can be easily integrated with application and resides on same node/VM as application. This helps tremendously in avoiding network round trip and helps in much better performance. Refer to Martin Fowler's [First law](https://martinfowler.com/bliki/FirstLaw.html)

Back to evaluating  databases for a given use case and SQLite fits in ,

| Criteria      | Description | SQLite |
| ----------- | ----------- | ----------- |
| ACID Guarantees       | Is Database expected to provide Strong Consistency guarantees? <br> (_this may not be required for every use case_)  |  Yes.<br/>Note that, there is no isolation between operations that occur within the same database connection.
| Data Durability  | Does Database maintain data in durable ,consistent way? |Yes        |
| Reliability | Does it provide reliable storage ? (Although storage reliability is not limited only to software and often depends on other factors like type of storage, associated hardware.) | Yes | 
| Availability  | Is database highly available?         | SQLite being file based, availability is confined to the Node/VM on which it is running. It can be further enhanced using tools like, [Litestream](https://litestream.io) (which implements change data capture and syncs it with remote storage like AWS S3 or SFTP among others). [rqlite](https://github.com/rqlite/rqlite) is clustered database based on SQLite. 
| network partition support | Does database support partitioning of data? | No. Being a file based data storage system, it is constrained on single node i.e. it can be scaled vertically. However, it can be setup in active + Stand-by backup mode using specific tools. Additionally, other databases (files on same node) can be attached to and accessed by application as one database.
| Tech. Support   | In case of [FOSS](https://g.co/kgs/P4FWMh) software, is Community active in terms of releases/bug fixes as well as on discussion forums? <br> Are their any providers who provide paid support? | SQLite is mature database. Though, it is open source, it does not accept pull requests from anyone out side of core committers. Having said that, one has to check for availability of  support in case things go north (corrupted database and so on.) |
| Database features | Support for Typical RDBMS features like Data types, User Management & Security, Stored procedures & trigger etc. | Refer [here](https://www.digitalocean.com/community/tutorials/sqlite-vs-mysql-vs-postgresql-a-comparison-of-relational-database-management-systems) for detailed comparison of features across SQLite and populate RDBMSs.  

Hopefully, above provides good starting point in deciding database for your next application. As always, comments/suggestions are welcome. 

### Useful References

* [Limits in SQLite](https://www.SQLite.org/limits.html)
* [Consider SQLite](https://blog.wesleyac.com/posts/consider-SQLite)

Happy Coding !!

---

{{< comments >}}