---
title: "Ninja - Using lightweight build system for Go projects "
date: 2020-10-27T10:25:04+05:30
draft: false
tags: [go, golang, ninja, make, cmake]
---

## Background

I primarily work on Windows for development purposes. Whenever its about writing code in Golang, invariably one comes across usage of Make. A quick check on popular Go projects on Github will show Makefile being used to automate tasks like linting, build, testing and deployment.  

Being on Windows, i have been looking for alternative build tool that is easy to setup (i.e. doesn't require mingw and such environments) and use compared to Make (which is primarily targetted at Unix and Unix like Operating Systems).

Following a wonderful post by Julia Evans (read [here](https://jvns.ca/blog/2020/10/26/ninja--a-simple-way-to-do-builds/)) on [Ninja](https://ninja-build.org). I decided to give it a try for a Golang Application.

Julia, in her post, has covered important aspects of Ninja but to summarize, Ninja is,

- A build automation tool
- Lightweight, with focus on speed 
- Easy to configure
- Cross platform (Easy to setup across Windows and Linux)

With this, lets give it a try,

To start with, lets create a simple go 'Hello World' project, 

- Initiate Go Module (in a Empty folder), `go mod init github.com/sachinsu/ninjabuild`

- Create a 'main.go' that prints 'Hello World',

```go
        package main

        import "fmt"

        func main() {
            fmt.Println("hello world")
        }
```

- Now setup Ninja, It is as easy as downloading binary for your Platform. It is also possible to build it locally, if you prefer it that way. For details, refer [here](https://ninja-build.org/)

- Once ninja is setup, lets create build configuration file (i.e. build.ninja),

```YAML
GOARCH = amd64
GOOS = linux

rule lint
 command = go vet -mod=vendor ./...

build lintoutput: lint 

rule unit
 command = go test -mod=vendor -cover -v -short ./...

build utest: unit 


rule compile
 command = cmd /c go mod tidy && go mod vendor &&  go build -o $out $in  && echo "build done."
 description = compile $in

build ninjabuild.exe: compile .
```

lets go through the contents of this file, 

- One can define variables ```GOARCH = amd64``` and refer them as ```$GOARCH```

- Ninja configuration is combination of build step and associated rule, for e.g.

```YAML
rule compile
 command = cmd /c go mod tidy && go mod vendor &&  go build -o $out $in  && echo "build done."
 description = compile $in

build ninjabuild.exe: compile .
```

- Above snippet, defines rule ```compile``` with associated command that builds the code. Being on Windows, i have used ```cmd /c``` to start a new shell and concatenate multiple commands as part of ```compile ```rule using ```&&``` which chains the commands and executes next one only if current one succeeds.

As demonstrated in above file, Ninja can be used to automate wide variety of tasks like build, tests, deployment and so on. 

Many of you using Make will find the approach similar to it. In contrast to Make, Ninja lacks features such as string manipulation, as Ninja build files are not meant to be written by hand. Instead, a "build generator" should be used to generate Ninja build files.  

 I found simplicity (of installation and configuration) and easy of use to be  key aspects of this tool.

Happy Coding !!

---

{{< comments >}}