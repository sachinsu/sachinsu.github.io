---
title: "ASP.NET Core - Mind the SameSite HTTP Cookie settings"
date: 2020-04-09T10:25:04+05:30
draft: false
---

## Background
A Web Application, developed in ASP.NET Core (Runtime Version 3.1.100) using Razor Pages and Web API, is expected to be launched from within third-party Web Application in iframe, with complete HTML being rendered.

During the Development, a mock HTML Page was developed to simulate launching of ASP.NET core based Web Application in iframe. Note that this page as well as Application was hosted on same IIS Server and it worked fine. Subsequently, Web Application was deployed on Test Server and URL was shared for integration with third party Application and then it happened Boom.... i.e. Application when launched in iframe rendered HTML but none of the post request would work (returning HTTP Error 400). Careful inspection showed that,

-  Browser's [Dev tools](https://developers.google.com/web/tools/chrome-devtools) showed HTTP 400 

- There were no entries in Application's Log File which indicates that Request was rejected either by IIS or ASP.NET Core's chain of filters i.e. even before it reaches handler.

- IIS Log depicted that Request was rejected but had no additional details. May be some of the log settings were missing.

- Next up is to carefully look at Request sent by browser in 'Network' tab of Dev tools. It showed that none of the cookies required by Application (i.e. for Session, CSRF token etc.) were present.

Enter [SameSite](https://docs.microsoft.com/en-us/aspnet/core/security/samesite?view=aspnetcore-3.1)


#### SameSite

SameSite is a standard designed to provide some protection against cross-site request forgery (CSRF) attacks. Support for Samesite was added from .NET Core 2.2 and onwards. It is expected that developer will control the value of SameSite attribute using ```HttpCookie.SameSite``` property.Setting the SameSite property to Strict, Lax, or None results in those values being written on the network with the cookie.

   - Cookies without SameSite header are treated as SameSite=Lax by default.
   - SameSite=None must be used to allow cross-site cookie use.
   - Cookies that assert SameSite=None must also be marked as Secure.
   - Applications that use ```<iframe>``` may experience issues with sameSite=Lax or sameSite=Strict cookies because ```<iframe>``` is treated as cross-site scenarios.
   - The value SameSite=None is not allowed by the 2016 standard and causes some implementations to treat such cookies as SameSite=Strict. 

The SameSite=Lax setting works for most application cookies.

Accordingly, below settings were made in startup.cs of the ASP.NET Core Application.

```
services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                // Samesite Settings.
                options.Cookie.SameSite = SameSiteMode.Lax;
                options.Cookie.IsEssential = true;
            });

services.AddAntiforgery(options =>
{
    options.Cookie.SameSite = SameSiteMode.Lax;
});
```
##### References
- [SameSite cookie updates in ASP.net, or how the .Net Framework from December changed my cookie usage. ](https://techcommunity.microsoft.com/t5/iis-support-blog/samesite-cookie-updates-in-asp-net-or-how-the-net-framework-from/ba-p/1156246)
- [Changes in SameSite Cookie in ASP.NET/Core and How it Impacts the Browser (Specifically Chrome) ](https://techcommunity.microsoft.com/t5/iis-support-blog/changes-in-samesite-cookie-in-asp-net-core-and-how-it-impacts/ba-p/1150771)
- [HTTP 203 Podcast covering CORS,CORB, Samesite](https://http203.libsyn.com/fish-scripts-special)

Happy Coding !!

---

{{< comments >}}