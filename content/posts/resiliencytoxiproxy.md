---
title: "Resiliency Testing with Toxiproxy"
date: 2021-01-09T10:25:04+05:30
draft: false
tags: [Chaosengineering, golang, postgresql, toxiproxy,shopify]
---

## Background

In a typical workflow of software development, Developer implements a Unit/component, tests it and pushes  the changes to source control repository. It then goes through Continuous integration, automated testing, provisioning and deployment. Given High availability requirements expected (or should i say assumed) nowadays,  As much as functional correctness of the Unit, it is also important to test how a Unit/Component handles failures, delays etc. in distributed environment.  Often, such behavior is observed in production itself, unless project team is following practices of [Chaos engineering](https://netflixtechblog.com/tagged/chaos-engineering).

Wouldn't it be great if it is possible to start testing the resiliency features as part of development and during CI/CD pipeline execution itself ? Enter [Toxiproxy](https://toxiproxy.io)

Toxiproxy is a TCP Proxy to simulate network and system conditions for chaos and resiliency Testing.

Toxiproxy essentially acts as middleman between your application and remote service/system being tested, allowing injection of delays, simulate Bandwidth restriction or turn interface off (down)
etc. 

It provides CLI as well as http API for applications to  inject these behaviors or toxics. Refer [here](https://github.com/shopify/toxiproxy#toxics) for various toxics supported. 

### Lets use Toxiproxy

Lets see how one can use it in typical use case where Application uses PostgreSQL database and requirement is to benchmark it against database hosted remotely. Toxiproxy can help simulate production like behavior by means of introducing network delay.

The full source code of this application is available [here](https://github.com/sachinsu/toxiproxyPOC). One can refer to Numbers (only as reference cause live conditions may widely vary) [here](https://github.com/sirupsen/napkin-math) while deciding on how much toxicity to introduce.

Application itself is a Web server in [Go](https://golang.org) using excellent [HTTPRouter](https://github.com/julienschmidt/httprouter), It does, 
   * provision a table in Postgresql and load [dummy data](https://github.com/sachinsu/toxiproxyPOC/tree/main/assets) in it.
   * Exposes REST API that reads data from database and returns JSON 
   * Setup proxy between application and database either through Toxiproxy CLI (it can also be done programmatically using Toxiproxy-Go client), 

        ```
            [
                {
                    "name": "pgsql", 
                    "listen" : "[::]:6000",
                    "upstream" : "127.0.0.1:5432",
                    "enabled": true
                }
            ]
        ```

        or through Code like, 

        ```
            // InjectLatency helper
            func InjectLatency(name string, delay int) *toxiproxy.Proxy {
                proxy, err := toxiClient.Proxy(name)

                if err != nil {
                    panic(err)
                }

                proxy.AddToxic("", "latency", "", 1, toxiproxy.Attributes{
                    "latency": delay,
                })
                return proxy
            }
        ```

   * Use [hey](https://github.com/rakyll/hey) or any other HTTP Benchmarking tool to test end points with and without toxicity 
   
   or
   
   * Go [benchmark](https://dave.cheney.net/2013/06/30/how-to-write-benchmarks-in-go) [tests](https://github.com/sachinsu/toxiproxyPOC/tree/main/api/server) tests that are executed against HTTP end points.

In my opinion, Toxiproxy allows us to embed aspect(s) of resiliency verification in the code itself so developer can test it before committing the code and it can be embedded in DevOps pipeline to get early feedback before facing the music in production environment. 

Like latency, one can easily introduce other Toxics like Bandwidth, Down and Timeout to check Application's behavior when faced with such occurrences.

### Useful References,
* [ToxiProxy](https://toxiproxy.io) - for all details on the tool like Clients available in various languages, server releases and so on.

Happy Coding !!

---

{{< comments >}}