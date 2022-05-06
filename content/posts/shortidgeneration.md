---
title: "URL Shortener in High Throughput Service"
date: 2022-05-15T01:00:00+05:30
draft: false
tags: [HTTP, Nanoid, UUID, REST, .NET, C#, Oracle, URL, Latency, SMS]
---

## Background

A Client has E-commerce Application consisting of services aimed at specific domains of business functionality it serves. One of these services is responsible for accepting the order, authenticating it and forwarding it for further processing in terms of inventory checks, payment and so on. For  Authentication, this service sends [SMS](https://en.wikipedia.org/wiki/SMS) to Customer's  Mobile number (and e-mail id) and customer is supposed to confirm this order placement by means of entering Code received in it. This code is valid for a short duration.  

The requirement is to add a [URL](https://en.wikipedia.org/wiki/URL) to this SMS which customer can use to view the order and confirm it on Mobile itself. 

For above, there are constraints like, 
  - Service is expected to trigger SMS, with required content like code, URL Etc.,  instantaneously. This is because  time-bound action is expected from customer post receiving this SMS. 
  - SMS Message size restrictions to be taken into consideration while adding URL to it (since it already has other content in it). 

## Implementation details

Given the size restrictions on SMS, a URL need to be as short as possible. Hence, URL Shortener will have to be used which reduces length of overall URL. Additionally, very low latency is expected while preparing content of SMS and sending the same (by calling Telecom Service Provider's API) hence external services like [Bitly](https://bitly.com/) are most probably not useful. This is because the whole response time will then be tied to performance, up-time of this external service. Better alternative is to generate short / nano ID within Service itself. This will work assuming  appropriate short domain (like t.me or youtu.be etc.) is available.   

Below are the alternatives to generate short id within the Service, 
  - [Nanoid](https://github.com/ai/nanoid)  
  - [HashIds](https://hashids.org/net/) 
  - [Base62 algorithm](https://microsoft.github.io/makecode-csp/unit-6/day-14/base63-url-shorteners)

One can choose any of the above considering tolerance for Collision. With Nanoid, one can check extent to which length can be reduced while avoiding collision  using this [Calculator](https://zelark.github.io/nano-id-cc/).

This approach helps with, 
  - Encapsulation - Keeping logic of short id generation, logging it in storage (ie. database), and responding to request for URL containing this short id within service itself. 
  - Keep external dependencies to minimum as much as possible so as to have better control over latency/throughput and easier monitoring.

### Useful References

* [Why Nanoids by Planetscale](https://planetscale.com/blog/why-we-chose-nanoids-for-planetscales-api)
* [Building highly reliable Web sites](https://www.kalzumeus.com/2010/04/20/building-highly-reliable-websites-for-small-companies/)
* [System Designer's Interview - Insider's Guide - Has Nice chapter on URL Shorteners](https://www.amazon.com/System-Design-Interview-insiders-Second/dp/B08CMF2CQF)


Happy Coding !!

---

{{< comments >}}