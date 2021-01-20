---
title: "Learnings from Jeff Richter's Designing and Versioning HTTP REST APIs Video Course"
date: 2021-01-20T00:00:00+05:30
draft: false
tags: [HTTP, REST, Jeffrey Richter,Microsoft, Azure, AWS, API]
---

## Background

Recently, i went through excellent video series on  ```Designing & Versioning HTTP_REST APIs``` presented by [Jeffrey Richter](https://www.linkedin.com/in/jeffrichter/). It is available [here](https://www.youtube.com/watch?v=9Ng00IlBCtw). In the past, i had read Jeff's books on CLR and found his writing to be very clear and understandable. So is my experience with this Video Series. Below is summary of learnings from this Video Series. I do not claim that every aspect is covered here so please do check out the videos.

I have been developing REST APIs for many years  but the video series opened up many new aspects that were previously unknown. Jeff starts with Need to Good API Design and related considerations, REST Fundamentals and then dives deeper into aspects like idempotent behavior, versioning, ETags and so on. 

Jeff covers REST fundamentals, need for thoughtful API design as it might be difficult to amend it later followed by practices covering Naming,Need for Idempotency, Error Handling and so on.  Below is an attempt to summarize aspects from these videos.

#### REST Fundamentals

REST is an architectural style with emphasis on,

* Scalability
* Reduced latency via Caching
* Independent Deployment
* Encapsulating legacy Systems

A REST service has resources where they represent state but not behavior. These behaviors are CRUD (Created, Read, Update and Delete). All operations of service must be idempotent.

URL of the REST Service is expected to be stable over long period of time. URL (apart from HTTP scheme and host name:port), consists of

* Document (eg. ```song-management```) - sometimes omitted in which case the host determines document.
* Collection resource (```users``` or ```playlists```) - Hold items; use plural lowercase noun; avoid more than 2 collections.
* Item resource - Request/Response body holds the item's state
* Method - Prefer 'PATCH', with JSON Merge Patch request body, over 'PUT'. 'PUT' for whole creation or replacement but may introduce  issues between different versions of service. Avoid 'POST' as it involves challenges in ensuring Idempotent behavior.  The argument against 'POST' is that it always creates resource and returns identifier which may get lost and client may retry. .

#### Error Handling

Videos contain tables explaining HTTP status code to be returned along with body in different conditions. below is quick summary, 

* If something unexpected happens return Status 500
* If service is booting, too busy or shutting down then return Status 303
* If HTTP Version not 1.1 then return status 505
* If Authorization fails then return status 401
* If Client makes too many requests/second then return status 429
* If URL too long then return status 414
* If HTTP Method not supported at all then return status 501
* If resource not accessible to client then return status 403
* If No support for HTTP Method not 1.1 then return status 405
* If request not in acceptable format then return status 406
* In case service returns non-success/error response for a request, 
  * It is recommended to add header in response that indicates the same (that way client can inspect it before deserializing/inspecting the response).
  * Also if error is recoverable @ runtime then, string is specific else string is list of similar errors. Response body could be in JSON format as,

	```JSON

	{
		"error": { 
			"code":"",
			"message":"",
			"target": "",
			"innererror": {
				"code": "", 
				"minLength": 6
			}
		}
	}

	```
* If server is overloaded then return 503
* If tenant exceeds quota then return 429

### Checklist for REST APIs

* Focus on great and consistent naming - This is very important because once in production, this is unlikely to change.
* Ensure that resource path make sense
* Always try to simplify call to Service (by having fewer query parameters & JSON fields)
* Use

  * ```PUT``` to Create/Replace whole resources. It should return ```200-Ok```, ```201-Created```.
  * ```PATCH``` to Create/Modify resource with JSON Merge Patch. It should return ```200-Ok```, ```201-Created```.
  * ```GET``` to Get the resource.It should return ````200-Ok````.
  * ```DELETE``` to remove resource. It should return ```200-Ok```, ```204-No content``` but  ```404-not found``` should be avoided.

	Jeff recommends avoiding usage of ```POST``` unless request is idempotent. The rationale being that ```POST``` request creates new resource and response contains new ID, Now client may not get this and resorts to retrying it which will result in resource getting leaked. I am not sure how using ```PUT``` will avoid resource leakage, may be will have to gather more details.

* A URL should be stable/immutable
* Use proper response codes to enable customers to self-fix
* Have clear contracts for string values
* Share samples (Code) that really use your API
* Use Etag (Entity Tag) to identify the version of the resource,

  * Etag is usually computed as checksum or as sequence value (which is incremented on every change)
  * for single item response, it is set in header and for collections, it is added as field in body.
  * Caching - Clients can use it for resource caching (send GET Request with ETag and server responds with 304-Not modified if resource hasn't changed)
  * Concurrent/Conditional Updates -Etag along with 'if-none-match'/'if-match' headers allows conditional update/delete
* Services must fail fast if requests are greater than quota (requests/time)
* Every request must be assigned unique ID for logging /tracing purposes. this ID can be returned in header of response.
* Generate Telemetry for the Service. It should include User Agent information for diagnostic purposes. Also consider adding Distributed tracing (OpenTelemetry is standardization initiative in this regard).  
* In case of client retries, services must be idempotent (Idempotency indicates retrying a request has same intended effect, even if the original request succeeded, though response might differ)
* Service must remain fault-tolerant in case of failures.
* Typically REST is meant for State transfer/CRUD Operations but many times the purpose of end point is to offer action. In such cases specify the action being performed at the end , i.e. after establishing the exact resource, of URL like, ```/user-management/users/{userid}/:send-sms```. In this,

    * 'user-management' indicates host
    * 'users' indicates users collection 
    * '{userid}' is to identify user by ID 
    * ':send-sms' indicates action (prefixed with ':') to be performed.

#### Reviewing REST APIs

While reviewing HTTP REST APis, below aspects should be evaluated,

* Does the API Match Customer's Expectation? Aspects to check are, 

  * URLs 
  * idempotency
  * atomicity
  * json 
  * casing
  * status codes
  * paging 
  * long running operations

* Consistency with other Services
* Is the Service/API sustainable over time i.e. API must be able to grow/version over time without breaking customer apps

In no way, the above covers all the points covered in the Video series. So if you are interested, check it out [here](https://www.youtube.com/watch?v=9Ng00IlBCtw).

### Useful References

* [Making retries safe with Idempotent APIs](https://d1.awsstatic.com/builderslibrary/pdfs/making-retries-safe-with-idempotent-apis-malcolm-featonby.pdf)

Happy API designing !!

---

{{< comments >}}