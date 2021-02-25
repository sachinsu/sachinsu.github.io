---
title: "Upgrading API: Learnings"
date: 2021-02-26T00:00:00+05:30
draft: false
tags: [HTTP, SOAP, REST, .NET, WCF]
---

## Introduction

One of the design considerations stressed upon by Jeffrey richter about APIs (Read more [here](/posts/restapiversioning/)) is that "API is expected to be stable over long period of time". Recently,for a .NET based project, we decided to upgrade some of the ASMX  (legacy SOAP based approach) based APIs and were immediately reminded by Customer(s) to avoid any kind of impact on existing users. 

This means that upgrade must be done keeping in mind, 

* No changes to API Contract (SOAP remains SOAP and so on)
* No changes to URLs
* Testing to ensure no impact

Initial plan was to move away from SOAP to adopt REST based approach. This thinking was aided by fact that .NET core may not support WCF (framework that supports SOAP apart from ASMX Web Services) in addition to other aspects like simplicity and wide adoption of REST. However, even microsoft has now decided to support WCF in .NET Core via [CoreWCF](https://github.com/CoreWCF/CoreWCF). 

With this constraints, we found below options to upgrade ASMX based services to WCF (the only other framework that supports SOAP based services), 

| Approach| Description|
| :------:|:----------|
| Have existing ASMX Service call new WCF Service using Async/Await | This involves hosting additional WCF Service and making HTTP requests to it. It also means maintaining both ASMX & WCF endpoints. Also to be mindful of latency introduced due to HTTP communication between the two.  |
| New WCF Service and URL Rewrite rules to handle requests to ASMX | This involves developing new WCF Service, compatible to current service contract, and configuration to route/re-write incoming requests to new service. Existing ASMX end point can be sunset      |
| New WCF Service and mapping `.asmx` handler to WCF handler  | This involves developing new WCF Service,compatible to current service contract, and configuration so that requests to `.asmx` url will be served by WCF handler. Existing ASMX end point can be sunset.       |


Lets go through above approaches in detail.

## WCF service invoked from ASMX asynchronously

This involves developing new WCF Service. Existing ASMX based web service will be modified to invoke new WCF Service. Asynchronously invocation should help in this case since whole operation is I/O bound (`Asynchrony is a way to get concurrency without multithreading. E.g., freeing up the calling thread instead of blocking it while an I/O operation is in progress` Stephen Cleary). Since ASMX is legacy framework and only support Event-based asynchronous pattern (EAP), it is necessary to combine EAP with Task based asynchronous pattern (TAP) which is what async/await uses. Below is sample snippet, 

```
 private async Task<string> FooAsync(int arg)
        {
            using (var resp = await client.GetAsync(string.Format("https://jsonplaceholder.typicode.com/todos/{0}", arg)).ConfigureAwait(false)) {
                resp.EnsureSuccessStatusCode();

                using (var contentStream = await resp.Content.ReadAsStreamAsync().ConfigureAwait(false)) { 

                    APIResponse obj = await JsonSerializer.DeserializeAsync<APIResponse>(contentStream).ConfigureAwait(false);

                   string output =  string.Format("{0} at {1}", obj.Title, DateTime.Now.Ticks);
                    System.Diagnostics.Debug.WriteLine(output);
                    return output;
                }
            }

        }

        [WebMethod]
        public IAsyncResult BeginFoo(int arg, AsyncCallback callback, object state)
        {
            return FooAsync(arg).ToApm(callback, state);           
        }

        [WebMethod]
        public string EndFoo(IAsyncResult result)
        {
            try
            {
                return ((Task<string>)result).Result;
            }
            catch (AggregateException ae) { throw ae.InnerException; }
        }

```
Where `ToApm` is extension function from Stephen Toub's excellent blog (link in code as comment),

```

  //ref: https://devblogs.microsoft.com/pfxteam/using-tasks-to-implement-the-apm-pattern/
        //ref: https://blog.stephencleary.com/2012/08/async-wcf-today-and-tomorrow.html
        public static Task<TResult> ToApm<TResult>(this Task<TResult> task, AsyncCallback callback, object state)
        {
            if (task.AsyncState == state)
            {
                if (callback != null)
                {
                    task.ContinueWith(delegate { callback(task); },
                        CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default);
                }
                return task;
            }

            var tcs = new TaskCompletionSource<TResult>(state);
            task.ContinueWith(delegate
            {
                if (task.IsFaulted) tcs.TrySetException(task.Exception.InnerExceptions);
                else if (task.IsCanceled) tcs.TrySetCanceled();
                else tcs.TrySetResult(task.Result);

                if (callback != null) callback(tcs.Task);

            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default);
            return tcs.Task;
        }

```

### Summary

This approach involves,

* hosting and maintaining both (current and new) API end-points.
* We also came across issues where async/await was not working properly in case code blocks.
* Measuring and mitigating any latency induced due to this additional hop
* Additional Monitoring and logging to track WCF end-point

We decided to explore alternative approaches instead of this.

## WCF service with URL re-write

This requires hosting WCF Service which is backward compatible with ASMX based SOAP implementation. 

Typically thhis involves,

* supporting `basicHttpBinding` 
* Adding namespaces and support for XML Serialization to Service contract like, 

```

  [ServiceContract(Name = "RequestReplyService", Namespace = "http://tempuri.org/"),XmlSerializerFormat]

```

* Adding Action to OperationContract attribute like, 

```
[OperationContract(IsOneWay = false, Action = "http://tempuri.org/DoWork")]

```
Additional configuration to re-write incoming requests to `.asmx` to new service in `web.config` as below, 

```

 <system.webServer>
    <validation validateIntegratedModeConfiguration="false" />    
    <rewrite>
      <rules>
        <rule name="asmxtosvc" stopProcessing="true">
          <match url="^service.asmx(.*)$" />
          <action type="Rewrite" url="Service.svc{R:1}"/>
        </rule>
      </rules>
    </rewrite>
  </system.webServer>

```

One may want to test above re-write settings in IIS as older versions of it require installation of URL Rewrite module.

This is followed by testing new WCF service from existing client(s), be it .NET based clients or other ones with no changes. .NET based clients typically invoke service through generated proxy class. For other clients, we basically simulated it via Postman.

### Summary

This approach provides cleaner implementation vis-a-vis earlier approach such that it is still new WCF based implementation with no ASMX in use.

## WCF service with .asmx extension mapped to WCF handler

This approach is very similar to last one with only change being instead of using URL re-write module, we will map `.asmx` extension to WCF Handler. So the changes are only in web.config as below,

```

<system.web>
    <!-- ref: https://docs.microsoft.com/en-us/dotnet/framework/wcf/feature-details/comparing-aspnet-web-services-to-wcf-based-on-development -->
    <!-- ref: https://stackoverflow.com/questions/5686320/asmx-to-wcf-conversion -->
    <httpHandlers>
    <remove path=".asmx" verb="*" />
    <add path="*.asmx" verb="*" type="System.ServiceModel.Activation.HttpHandler, System.ServiceModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" validate="false" />
    </httpHandlers>
    <compilation debug="true" targetFramework="4.8">
    <buildProviders>
        <remove extension=".asmx"/>
        <add extension=".asmx" type="System.ServiceModel.Activation.ServiceBuildProvider, System.ServiceModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"/>
      </buildProviders>
    </compilation>
    <httpRuntime targetFramework="4.8"/>
  </system.web>
....


<system.webServer>
  <handlers>
    <remove name="WebServiceHandlerFactory-Integrated"/>
    <add name="MyNewAsmxHandler" path="*.asmx" verb="*" type="System.ServiceModel.Activation.HttpHandler, System.ServiceModel.Activation, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
  </handlers>
  <validation validateIntegratedModeConfiguration="false" />
</system.webServer>

```

This was tested in same way as earlier with existing .NET and other clients.

### Summary

This feels like even more cleaner approach than using URL re-write as it doesn't involve using any additional module/library.

Finally, we went ahead with this approach.

Hopefully,this article will be helpful to anyone involved in legacy modernization initiatives.

### Useful References

* [Comparing ASMX web services to WCF](https://docs.microsoft.com/en-us/dotnet/framework/wcf/feature-details/comparing-aspnet-web-services-to-wcf-based-on-development)

Happy Coding !!

---

{{< comments >}}