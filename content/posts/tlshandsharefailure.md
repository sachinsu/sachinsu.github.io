---
title: "Troubleshooting TLS handshake issue"
date: 2023-02-25T10:25:04+05:30
draft: false
tags: [Wireshark, TCP, TLS, .NET, Schannel,SSPI, Bouncy Castle]
---

## Background

Ever encountered a scenario where REST API consumption works from tools like [curl](https://github.com/jeroen/curl), Web Browser but not from Application. Lets dive in.  

The requirement is as simple as consuming REST API from a Application over TLS. 

## Problem Statement

The REST API, to be consumed, is standard API interface which requires access over TLS. The client in this case is Windows 2016 server. 

During Development, Windows 10 is used to develop and test the code. Later, the same is tested on a Windows 2016 Server. It is at this stage, it fails with cryptic Error "The request was aborted: Could not create SSL/TLS secure channel". But it works fine with other tools like curl, PostMan or even from a Web Browser. 

{{< figure src="/images/wireshark-dotnet-error.png" title="Network trace log from Application" >}}


## Causal Analysis

Given that this error was related TLS/SSL and it is standard across platforms. What could be the reason for this behavior? With not much luck with Application level trace, its time to take help of [Wireshark](https://www.wireshark.org/). If you are new to Wireshark then refer to [this](https://jvns.ca/blog/2018/06/19/what-i-use-wireshark-for/) excellent write-up by Julia Evans.  

So, i used wireshark during test from CURL as well as from the Application and below is what is shows,

### Using CURL 

{{< figure src="/images/wireshark-curl-1.png" title="List of Ciphers Exchanged during 'Client Hello'" >}}

{{< figure src="/images/wireshark-curl-2.png" title="Cipher returned by Server during 'Server Hello'" >}}

With CURl, TLS handshare happens as intended and API works as expected.

### Via Application

- Below is list of ciphers exchanged and list is considerably short compared to earlier. 

    {{< figure src="/images/wireshark-app-1.png" title="List of Ciphers Exchanged during 'Client Hello'" >}}

- Below is error logged 

    {{< figure src="/images/wireshark-app-2.png" title="TLS handshake Error" >}}


To understand this behavior, Let's do a quick primer. 

There are many implementations of TLS/SSL (a.k.a. Security service providers) available across platforms. Notably, 

- [Network Security Services](https://en.wikipedia.org/wiki/Network_Security_Services) This is used by browsers like Firefox

- [LibreSSL](https://en.wikipedia.org/wiki/LibreSSL) - Used by Chrome, curl (in ready-to-use build, refer [here](https://everything.curl.dev/build/tls))

Refer [here](https://en.wikipedia.org/wiki/Comparison_of_TLS_implementations) for nice comparison of various implementations in summary format. 

`Microsoft Windows has its own Implementation called Windows SSPI (a.k.a. schannel SSPI). As per [TLS/SSL Overview](https://learn.microsoft.com/en-us/windows-server/security/tls/tls-ssl-schannel-ssp-overview),

``` 

Schannel is a Security Support Provider (SSP) that implements the Secure Sockets Layer (SSL) and Transport Layer Security (TLS) Internet standard authentication protocols.

```

Microsoft Windows and development platforms like .NET use this implementation by default. Via this provider it is possible for Administrators to enforce policies like restrict version of TLS, usage of ciphers and so on. Note that, as part of Security/Compliance requirements, It is often necessary to have these policies enforced and this is exactly what was done.   

Below is Sample C# code using [BouncyCastle](https://github.com/bcgit/bc-csharp) (alternate library for cryptography)

{{< carbon gistid="22bb5e70334101dba1880de3a6c0e504"  >}}


## Wrap up 

Hence, the resolution for this could be,

- Make sure that Server hosting the API complies with any of the ciphers allowed on the client.
- In case if this is not possible then , Cipher restrictions on the client will have to be modified (assuming its within the requirement for Compliance).

### Useful References,

1 - [CURL using OpenSSL in default build](https://github.com/jeroen/curl/issues/100)


Happy Troubleshooting !!

---

{{< comments >}}