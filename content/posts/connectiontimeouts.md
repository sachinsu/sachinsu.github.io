---
title: "Trobleshooting TCP Connection request time outs"
date: 2020-08-25T10:25:04+05:30
draft: false
tags: [Oracle, TCP, Firewall, .NET, Polly]
---

## Background

I recently had opportunity to support team who has been battling with Intermittent (scary i know :)) issues with TCP connectivity in Production.

Simplified deployment Architecture is as below,

{{< figure src="/images/conntimeoutarch.png" title="High Level Architecture" >}}

Technology Stack used is Microsoft .NET Framework 4.8 using ODP.NET for Oracle Connectivity (Oracle Server is 8 CPU box). Each of Web Servers in cluster have IIS hosted on it with multiple Applications (Application domains) serving HTTP(s) based traffic. These applications connect to Oracle Database.

Team is experienced in developing and running .NET Apps, but they needed help to diagnose and fix "Connection request timed out" exceptions being thrown while connecting to backend database.

## Problem Statement

Host of .NET Applications (Web Applications, Web APIs) connect to Oracle Database. Each of them use [ODP.NET](https://www.oracle.com/database/technologies/appdev/dotnet/odp.html). ODP.NET maintains connection pool per Application domain (Database resident Connection pool is not used). Some of these applications receive high number of requests per second compared to others.

`Oracle.ManagedDataAccess.Client.OracleException (0x80004005): Connection request timed out....` has been reported randomly which results in failure of business transactions. ODP.NET provides extensive trace and along with above trace also contains `OracleInternal.Network.NetworkException (0x80004005): Network Transport: TCP transport address connect failure ---> System.Net.Sockets.SocketException (0x80004005): A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond`

Specifically, Applications, receiving less traffic, were reporting it often compared to those with high traffic.

## Approach

- Simulate the Exception in Test Environment - We decided to try and simulate this exception in a Test Environment. Test environment is scaled down (50%) compared to production. Random Exceptions in production could not be simulated due to lack of Test Automation. for example, In Production, each server receives traffic for multiple HTTP End points whereas in Test environment, load testing was being done only against Single Application.

This was like a end of the road since simulation would have greatly helped in diagnosing the issue. However, the show must go on so we decided to, 

- Check online documentation regarding this exception,
    - "Pooled" or "Non-pooled" Connection - Whenever, ODP.NET raises "..timed out" error, it diffrentiates the same to indicate whether error is due to delay in retrieving connection from pool or if it is due to delay from the database server (Ref: [Here](https://docs.oracle.com/en/database/oracle/oracle-data-access-components/19.3/odpnt/featConnecting.html#GUID-1152D13D-464C-4FE7-9949-32FCA9572B59)). From this, it was clear that issue is clearly due to delay in obtaining response from database server.While this was happening , Database server (8 CPU Core box) was reporting less than 50% CPU Usage but it still had large number of inactive sessions originated from IIS Servers.
     - Since the exception was reported frequently in low traffic applications, it was decided to track and verify the same on firewall and database server,
        - Firewall - Firewall had TCP Timeout of 30 minutes and  maintains detailed log of sessions. Quick analysis of it revealed that, 
            - Production Environment - Unusually high number of sessions were being destroyed due to "Age out" (i.e. time out)
            - Test Environment - No abnormal activity was reported. Most probably because of differences in traffic. 

        - Database Server - Listener Log on Oracle Database server did not had any log entry for request at the precise time when Application(s) had reported Exception.

   - Next is to check settings in Application for connectivity with Oracle. Though ODP.NET does not have any direct  "Time out" or "Time to live" settings, it does provide few parameters that can influence it, 
        - "Connection Lifetime" - ODP.NET uses this whenever Connection is closed and disposed by the Application. It will be destroyed (after maintaining number of connections as per "Min Pool Size")  if it has exceeded life time. For whatever reasons, this was set to unusually high duration (i.e. 90000 seconds).
        - "Connection Timeout" - Period for which ODP.NET waits for the connection to be made available. This was set to 60 Seconds.

   -  Oracle has articles titled "ODP-1000 "Connection Request Timed Out" Explained" and "Resolving Problems with Connection Idle Timeout With Firewall (Doc ID 257650.1)" where it primarily recommends measures for tuning Application as well as database.

    On the basis of above, it was decided to modify the code for below,
    - Thorough code review to verify that every ODP.NET Project is closed/disposed.
    - Upgrade ODP.NET to latest version (v19.8.0 as of this writing)
    - Turn "KeepAlive" while connecting to database
    - Leverage ODP.NET tracing in case of exception
    - Modify the connection lifetime to be less than time out at firewall and increase the "Time out" period.
    - Introduce Retry functionality using Excellent [Polly](https://github.com/App-vNext/Polly) library with exponential back-off. 

    `{{< carbon gistid="d3888ab4418b937a650e880ec4682653?filename=extensions.cs">}}`

    These changes have been deployed to production and so far % of "Connection Request Timed out" errors have gone down significantly. 

## Wrap up 

Some key areas of focus are,
- For a distributed system, Always validate assumptions by dignosing end to end. 
- Plan to have test automation readyness to simulate production like load.
- Monitoring the behavior end to end using logs.
- Currently, Pool settings across applications is not optimal going by Oracle Real world Guidelines, also be mindful of [Connection Storms](https://docs.oracle.com/en/database/oracle/oracle-database/18/adfns/connection_strategies.html)


Happy Troubleshooting !!

---

{{< comments >}}