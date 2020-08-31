---
title: "Windows Service with Cancelable Task"
date: 2020-05-05T12:25:04+05:30
draft: false
---

### Background
Recently, we had requirement wherein a process should, 
 
 * Periodically (Poll) or Asynchronously (Pub-sub) listen on incoming requests/messages. The whole process is expected to be long running.
 * Should also implement clean disposal of in-flight requests and subsequent cleanup using something similar to Cancelble [Context](https://golang.org/pkg/context/) in Go
 
 The first of the objective is somewhat dependent on mechanism (Pub/sub, Listener), protocol (TCP, HTTP etc.). For the second one, .NET framework (and .NET Core) offers [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=netcore-3.1). It is maint for co-operative cancellation between threads and Task Objects. So Armed with this, is it possible to come up with a template that allows cancellation of long running task while also being deployed as Windows Service (or using systemd in Linux) ?

 Lets get Started,

### Approach

We can use below to construct service, 
 * [Topshelf](http://topshelf-project.com/) - Allows Hosting  services in-process as console apps or Windows services. 
 * [NLog](htps://nlog-project.org) - For Logging
 
Accordingly, we will have below Components, 

* Listener.cs - It wraps the long running process in a C# Task. It exposes Start and Stop functions which are essentially event handlers awaiting for Signal from the service. 

{{< carbon gistid="b2869d4f44fe14f439c6f0e60ea2b5d5?filename=Queuelistener.cs" >}}

Refer Gist [here](https://gist.github.com/sachinsu/b2869d4f44fe14f439c6f0e60ea2b5d5#file-queuelistener-cs)
 
* Program.cs - It configures the startup parameters for the service and initializes it. Using Topshelf, one can easily debug it as Console Application before deploying it as Service.

{{< carbon gistid="b2869d4f44fe14f439c6f0e60ea2b5d5?filename=Program.cs" >}}

Refer Gist [here](https://gist.github.com/sachinsu/b2869d4f44fe14f439c6f0e60ea2b5d5#file-program-cs)
 
Above Code was targetted at .NET Framework but the same can potentially be used on .NET Core thus targetting both Windows and Linux.

Happy Coding !!

---

{{< comments >}}