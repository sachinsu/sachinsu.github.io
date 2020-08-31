---
title: "Is WebAssembly future of Web Development"
date: 2020-06-02T10:25:04+05:30
draft: false
tags: [WebAssembly, Golang,C#]
---

Over the last many years, de-facto language of the Web (specifically front-end) has been Javascript (and variants like Typescript, ECMAScript versions and so on). The Web development has been revolving around HTML+CSS+Javascript trio. It all started with support for Javascript in browsers, followed by addition of XMLHTTP API, Rich DOM Manipulation Support in Javascript. To induce order and apply patterns to Javascript's usage in browsers, numerous frameworks and libraries were introduced like [React](https://reactjs.org) and [Vue](https://vuejs.org) among others. To begin with, The target used to be browsers on Large Devices like Desktop & Laptops. However, soon all sorts of devices were targetted with advent of Responsive and Progressive CSS+Javascript libraries eg. [Bootstrap](https://getbootstrap.com). Offline Support soon came in ref: [Electron](https://electronjs.org) and [Progressive Web Applications](https://web.dev/progressive-web-apps/). 

As a result, Javascript has become lingua franca of Web Development and is being used on server side development ([Nodejs](https://nodejs.org)).

The reason for this whole rant on history (which you are most likely to be aware of) is that latest kid on the Block could possibly challenge Monopoly of Javascript (and its ilk) at far as browsers are concerned. 

***Enter WebAssembly (A.K.A. WASM)***

## WebAssembly

As per [Wikipedia](https://en.wikipedia.org/wiki/WebAssembly),

 > WebAssembly (often shortened to Wasm) is an open standard that defines a portable binary-code format for executable programs, and a corresponding textual assembly language, as well as interfaces for facilitating interactions between such programs and their host environment.

> WebAssembly or wasm is a low-level bytecode format for in-browser client-side scripting, evolved from JavaScript. It is [intermidiate representation](https://evilmartians.com/chronicles/hands-on-webassembly-try-the-basics)(IR) where IR is transformed into machine instructions for the client architecture by browser.

WebAssembly executables are precompiled, hence it is possible to use a variety of programming languages to make them. This essentially means that one can use same language for Server Side as well as Client side (i.e. in browser) development like ([C#](https://docs.microsoft.com/en-us/dotnet/csharp/) or [Golang](https://golang.org/)).

WebAssembly was announced in 2015 and has since being supported by prominent browser(s) like Chrome and Firefox. 

Along side browsers, many Vendors and open source communities/contributors have released libraries to make development of WebAssembly easy.  We will look at how a WebAssembly can be developed in C# and Golang.

*Note: [All major languages](https://github.com/appcypher/awesome-wasm-langs) now support WebAssembly.*

### C#

During Microsoft Build 2020 [^1] event, Steve Sanderson had very good session on building WebAssembly using Blazor framework in .NET. Highly recommended to watch it.

Blazor scaffolding provided with .NET core allows, 

- Blazor Server App - A Template that runs server-side inside an ASP.NET Core app and handles user interactions over a SignalR connection.

- Blazor WebAssembly App - A Template for creating a Blazor app that runs on WebAssembly.

Choosing Blazor WebAssembly App project type generates a project that has sample WebAssembly running. Overall, it makes development easy for any .NET developer easy since, it uses[Razor](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-3.1) syntax to add C# code along with HTML. During Build, it generates assembly for C# Code. When Accessed via browser, it downloads .NET runtime for WebAssembly (~ 621 KB) and the project assembly itself apart from static content (i.e. HTML files, images etc). The default scafolding includes Bootstrap CSS and prepares the UI to be responsive. 

The repository referenced by Steve during presentation is available [here](https://aka.ms/blazor-carchecker).

### Golang

[Go](https://golang.org) has got clean, fast tooling. it produces static binaries and has superb concurrency primitives. 

[Vugu](https://www.vugu.org/) is an open source library that allows building a Web front-end in Go using WebAssembly. Generally static binaries are bulky and Vugu has addressed it using [TinyGo](https://tinygo.org) compiler. Vugu is still work in progress but does work great in its current form.  Check out their [getting started](https://www.vugu.org/doc/start) page.

Interesting take on Journey of JavaScript and what lies ahead for it, read it [here](https://www.swyx.io/writing/js-third-age/).

## Summary 
In nutshell, Concept of WebAssembly provides compelling way to have full stack development in a language of your choice. It remains to be seen how and whether it provides viable alternative to current Javascript driven ecosystem.

### Useful References,
[^1]: [Modern Web UI with Blazor](https://channel9.msdn.com/Events/Build/2020/BOD104)

Happy Coding !!

---

{{< comments >}}