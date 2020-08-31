---
title: "Using .NET standard Assembly in .NET core and .NET Framework"
date: 2020-02-07T10:25:04+05:30
draft: false
---

## Background
One of the key project(s) at my current organization is developed on .NET 4.6.1. It is developed as [Modular Monolith](https://www.youtube.com/watch?v=5OjqD-ow8GE). As part of it's functionality, it supports different channels like Mobiles, Terminals and Web. For the *Web* channel, there was need to develop a Web application with,
* High availability
* Lightweight, High throughput (Need to support few thousand(s) active users)

Accordingly, we have been exploring developing this Web Application in .NET core 3.1. However, it also means that we will have to use class libraries, targeted at .NET framework 4.6.1, in .NET core and vice-versa. How can this be done?

__.NET Standard to the rescue !!__

[.Net Standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) is a standard that enabled development of portable libraries usable across .NET versions. 

Below is approach adopted to create usable libraries across .NET framework & .NET Core.

* .NET & IDE versions used are,
  * .Net Framework 4.6.1
  * .Net core 3.1
  * Visual Studio 2015 - for .NET Framework 4.6.1 development
  * Visual Studio Code - For .NET core development

* Step 1 - 
    * Create a library that targets .NET Standard.
        * Refer to Table on [Implementation Support](https://docs.microsoft.com/en-us/dotnet/standard/net-standard#net-implementation-support) to decide on version that can be targetted at. In my case, it was 2.0 (Remember that higher the version, more APIs will be available to use). Do check [.NET API browser](https://docs.microsoft.com/en-us/dotnet/api/), which lists API available with each version.
        * Using .NET core, use below command,
      ``` dotnet new classlib <name> ```

            Note that, by default csproj file generated targets .NET Standard, but do confirm by checking in ```<name>.csproj``` file, It should have entry like,

            ```
            <PropertyGroup>
                <TargetFramework>netstandard2.0</TargetFramework>
            </PropertyGroup>
            ```
        
            Change the version of .NET Standard if required.
        * Add necessary code to the library and build it using,
        ``` dotnet build ```
        * Create a Nuget Package using, 
        ```dotnet pack```
        This will generate ```<name>1.0.0.nupkg``` package in bin\debug folder (assuming that you are using Debug mode)

* Step 2 -
    * Lets consume this library from console Application, using .NET Framework 4.6.1, in Visual Studio 2015.

        * Create New Console Application and ensure that it is targeted at .NET Framework 4.6.1 or Higher.
        * Before consuming .NET standard library, few steps are needed since VS 2015 only has legacy support for consuming .NET core artifacts also it does not have latest version of Nuget, so lets do below,
            * Install NuGet 3.6.0 or higher for VS 2015 from [NuGet's download site](https://www.nuget.org/downloads)
            * Install the ".NET Standard Support for Visual Studio 2015" from [here](https://www.microsoft.com/net/download/core)
            * Open the csproj file in Text Editor and add  ```<ImplicitlyExpandDesignTimeFacades>``` tag as shown in below example,
            

            ```
            <?xml version="1.0" encoding="utf-8"?>
            <Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
            <PropertyGroup>
                <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
                <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
                <ProjectGuid>{75678902-8224-4222-BB33-756784B2FA29}</ProjectGuid>
                <OutputType>Library</OutputType>
                <RootNamespace>FooBar</RootNamespace>
                <AssemblyName>FooBar</AssemblyName>
                <TargetFrameworkVersion>v4.6.1</TargetFrameworkVersion>
                ...
                <ImplicitlyExpandDesignTimeFacades>false</ImplicitlyExpandDesignTimeFacades>
            </PropertyGroup>
            ```


            Post update to file, VS 2015 will prompt to reload the project. 
            
            Now we are set to consume .NET standard library, authored in .NET Core, in this project. 
* Step 3 - 
    * Within VS 2015, Goto Nuget Console and install the package created earlier. This [link](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-visual-studio) has steps to consume local nuget package(s).

Happy Coding !!

---

{{< comments >}}