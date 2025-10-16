- Current Experience 
  - Closed loop EMI Cards Issuance and transaction processing Platform for Large NBFC in India
       - Implemented Architecture based on Service based, Clean Architecture paradigm on  Microsoft platform.  Oracle 21c RAC (Active-Active) is used as  OLTP data store while EDB PostgreSQL is used for MIS Reporting. REDIS is used for caching and Talend/Airbyte for ETL. Integration with Azure IAM for single sign-on for internal users. 
       - Infrastructure sizing for on-prem implementation based on load testing for critical services and volume  projections from business.
       - Worked on improving the throughput of hot Path (e.g. Payment Authorisation for E-commerce Merchants during flash sale) by,
         - Optimizing SQL Queries
         - Out of order processing for those tasks (like SMS ec.) that can be delayed or performed in near real time. 
         - API first driven approach for EMI transaction management..
         - Industry standard tools and libraries are used for cross-cutting concerns like logging, tracing,  monitoring etc Load testing based validation and verification for fulfilling specific non-functional objectives related to response time and throughput
  - Data Hub
    - Platform to offload reporting requirements both near real time and batch from OLTP applications.
    - Architecture is based on using Message queue (RabbitMQ) and API based integration between source systems  and Data Warehousing platform as well as batch approach for bulk data transfer using Talend/Airbyte. PostgreSQL is used as a data store with Data Vault Methodology for modelling and rich Analysis provided using Metabase and Custom Developed Visualization App based on SPA Paradigm.
  - Multi-tenant EMI Platform
     - Ideated and developed Architecture for EMI Platform for Credit Cards, UPI involving onboarding of various entities like Issuers, Acquirers, Brand/OEMs using Services based scalable Architecture
     - Led Technical Architecture discussions with Teams with the aim of addressing critical requirements
     - Conducted Technology Proof of concepts to validate assumptions
   - Enterprise level Responsibilities
     - Technical SME for all platforms built on various tech. stacks like .NET, Java, PHP and databases like   Oracle, PostgreSQL. Evaluation and roll out of automated CI/CD processes across projects.
     - Creation and Maintenance of Technical Capability Model in terms of Reference Architectures, Best practices,Tools, Assets,Standards, Security Aspects (PCI-DSS Compliance). Leveraging Threat modelling tools for early identification and mitigation.
     - Overall Ownership of non-functional aspects like scalability, high availability, Maintainability, for all technology platforms. Evaluation of COTS and Open source products, libraries and tools.
     - Infrastructure Sizing for New Opportunities and customer demos and workshops

- Cloud
  - Typical Flow (GCP)
    - User -> Launches web app -> Cloud DNS -> Cloud CDN -> Global Load Balancer -> Cloud Armour -> On-prem or another cloud (If applicable) -> Compute Engine (Managed instance group)(Web server etc.) -> Internal L.B. -> Compute Engine (Managed instance group)(App server etc.) -> Cloud SQL / Fire store / Cloud Storage

  - Cloud vs. on-prem
    - If your load is quite predictable (i.e., the number of machines you need does not fluctuate wildly), then it’s often cheaper to buy your own machines and run the software on them yourself
    - If you need a system that you don’t already know how to deploy and operate, then adopting a cloud service is often easier and quicker than learning to manage the system yourself. If you have to hire and train staff specifically to maintain and operate the system, that can get very expensive. You still need an operations team when you’re using the cloud,  but outsourcing the basic system administration can free up your team to focus on higher-level concern
    - Other salient aspects
      - Separation of compute and storage (Virtual disk storage)
      - Specialized services like Object storage (S3/Filestore)
      - Multi-tenancy - rather than having a separate machine for each customer, data and computation from several different customers are handled on the same shared hardware by the same service 
    - Some downsides are,
       -    Lack of specific feature
       -    Cloud provider's down time
       -    Change of terms for Service that makes it expensive,
       -    Data privacy, security concerns
       -    Operational task are still required like, maintaining the security of an application and the libraries it uses, managing the interactions between your own services, monitoring the load on your services, and tracking down the cause of problems such as performance degradations or outages. 
     - Cloud migration advantages,
       - Specific cloud migration principles
         - Use before reuse
           -    Design from front-to-back (build consumer-driven APIs that provide the services in a format that the front-ends prefer.)
           -    Best tool is the one that suits your level
           -    Understand pricing models and how they fit your usage patterns
           -    Use automation to reduce cost
           -    Use transparency to understand and manage cost
           -    Spend time understanding your own usage patterns
           -    Read price reduction case studies carefully to see what impacted the price and whether that applies to you
           -    Acquire resources as needed (compute, storage, networks and databases)
           -    Convert upfront capital expenditure to operational expenditure (pay as you go)
           -  Other reasons
              - Uptime
              - Velocity - Accelerated Software Delivery via fully managed CI/CD pipelines
              - Security - Via custom built hardware and offerings like software defined networks, firewalls, Web Application firewalls.
              - Transparency w.r.t. infra inventory
      - Some relevant workloads
        - Data Analytics
        - Data backup and Archiving 

-  Architecture Roadmap,
   - 6 Code Quality Areas:
          - Readability
          - Flexibility
          - Reusability
          - Scalability
          - Extendibility
          - Maintainability  

     - **Security > Reliability > Usability (Accessibility & UX) > Maintainability > Simplicity (Developer experience/DX) > Brevity (code length) > Finance > Performance**

     | Objective | Notes | Existing Infrastructure | Business Requirement | Technical Requirement | solution Component |

     - Objective - deliver maximum business value while adhering for optimal performance, security, reliability, cost-efficiency, and operational excellence.
     - Notes 
       - Operational Excellence - Infrastructure as code, clear documentation, traceability, and observability.
       - Security - Emphasizes maximizing data and workload security, designing for privacy, and aligning with regulatory requirements. Principles include applying security at all layers, automating controls, and protecting data in transit and at rest.
       - Reliability - Principles include testing recovery procedures, automating recovery, and scaling horizontally.
       - Performance Efficiency - Principles include leveraging advanced technologies (e.g., serverless), using data-driven approaches, and promoting experimentation.
       - Cost Optimization - Concentrates on designing with cost efficiency in mind. Principles include  adopting a consumption model, implementing automated controls and alerts, measuring efficiency, and using managed services.
       - Documentation - Crucial for cross-functional team communication, alignment, and future decision-making.
       - Simplicity and Managed Services -  Design should be simple. Where feasible, use fully managed GCP services to minimize management overhead, risks, and effort.
       - Decoupled Architecture: Break down applications and services into smaller, independent components for increased flexibility, independent upgrades, specific security controls, and granular monitoring.
       - Stateless Architecture: Preferred for increased reliability and scalability, as applications can scale quickly with minimal dependencies.
       - Phased Approach/Migration Frameworks: For existing infrastructure, GCP advocates for a phased migration approach (e.g., Assess, Plan, Migrate, Optimize, Govern). This involves detailed discovery and analysis.
     - Existing Infrastructure
       - a thorough understanding of the existing infrastructure is paramount. 
       - Discovery and Inventory:
         - Mapping all applications, servers, databases, and IT assets.
         - Identifying owners, configurations, and existing dependencies (application, network, security).
         - Understanding hardware, performance requirements, licensing, and compliance.
       - Workload Assessment:
         - categorizing applications (e.g., "Easy to Move," "Hard to Move," "Can't Move").
         - Determining resource and capacity needs for each workload.
         - Analyzing application availability (SLA Matrix, HA/DR).
       - Network Discovery:
         - Understanding current network architecture (layout, firewall rules, VPNs, load balancing).
       - Security Posture:
         - Reviewing existing security controls, policies, and compliance requirements.
       - Data Analysis:
         - Identifying data sources, volume, access patterns (streaming vs. batch), and processing needs.
         - Considering data location, data protection needs, and retention policies. 
         - Factors to decide about service/component boundary identification, 
     - Business Requirements
       - Business Motivation - key drivers for moving to or building on the cloud
       - Business Outcomes: 
         - Fiscal: Increased revenue, optimized costs, physical asset recovery, operational cost reduction.
         - Agility: Faster time-to-market, swift response to change.
         - Performance: High availability, zero data loss, minimal disruptions.
         - Security & Compliance: Continuous compliance, adherence to regulations.
         - Reach & Customer Engagement: Global access, data sovereignty compliance, meeting customer needs faster.
     - Technical Requirements
       - Resiliency. If an infrastructure component fails (a service dies, a network connection becomes unavailable), does the system remain functional? Can it recover without human intervention?
       - Speed. How fast is the software, compared to the theoretical limit? Is work being done in the hot path that isn’t strictly necessary?
       - Readability. Is the software easy to take in at a glance and to onboard new engineers to? Are functions relatively short and named well? Is the system well-documented?
       - Correctness. Is it possible to represent an invalid state in the system? How locked-down is the system with tests, types, and asserts? Do the tests use techniques like fuzzing? In the extreme case, has the program been proven correct by formal methods like Alloy?
       - Flexibility. Can the system be trivially extended? How easy is it to make a change? If I need to change something, how many different parts of the program do I need to touch in order to do so?
       - Portability. Is the system tied down to a particular operational environment (say, Microsoft Windows, or AWS)? If the system needs to be redeployed elsewhere, can that happen without a lot of engineering work?
       - Scalability. If traffic goes up 10x, will the system fall over? What about 100x? Does the system have to be over-provisioned or can it scale automatically? What bottlenecks will require engineering intervention?
       - Development speed. If I need to extend the system, how fast can it be done? Can most engineers work on it, or does it require a domain expert?

         - Performance:
         - Latency (e.g., sub-millisecond, milliseconds)
         - Throughput (e.g., requests per second, data transfer rates)
         - Scalability (e.g., handle X concurrent users, scale to Y transactions/second)
         - Peak load handling, burst capacity.
       - Reliability/Availability:
         - SLA (Service Level Agreement) requirements (e.g., 99.99% uptime)
         - Disaster Recovery (DR) and Business Continuity (BC) objectives (RTO, RPO)
         - Fault tolerance, redundancy.
       - Security:
         - Identity and Access Management (IAM) policies (least privilege, MFA)
         - Data encryption (at rest and in transit), key management (KMS)
         - Network security (VPC design, firewall rules, private connectivity)
         - Compliance standards (e.g., SOC 2, ISO 27001, HIPAA, GDPR)
         - Vulnerability management, incident response.
       - Cost:
         - Budget constraints, cost predictability.
         - Cost optimization strategies (right-sizing, committed use discounts, managed services).
         - Cost allocation and reporting needs.
       - Operational:
         - Monitoring and logging requirements (observability, alerting)
         - Automation (CI/CD, infrastructure as code)
         - Management and maintenance overhead (minimize manual tasks)
         - Deployment frequency, rollback capabilities.
       - Data:
         - Storage type (file, object, block, database)
         - Data volume and growth rate.
         - Data ingestion patterns (streaming, batch).
         - Data processing and transformation needs.
         - Data governance, residency, and sovereignty.
       - Integration:
         - Integration with existing on-premises systems or other cloud environments (hybrid/multi-cloud).
         - API requirements, data exchange formats.
     - Solution Component
       - High level design - Sketching out the overall architecture, showing how different  services will interact to meet the requirements.
       - Detailed Design - Specifying configurations, settings, and integrations for each selected service.
       - Architectural Patterns: Applying proven architectural patterns (e.g., microservices, serverless, event-driven) where appropriate.
       - Roadmap and Phasing: Defining a migration or implementation roadmap, including pilot projects and iterative deployments.
       - Cost Estimation: Using relevant tools to estimate costs based on the proposed solution.

    - Architecture, design learnings,
      - Design is about behavior whereas Architecture is about capabilities (Scalability, performance)
       - Tips for Evolvable architecture (Notes on Building Evolutionary Architectures. | Irrational Exuberance)
      - “Remove needless variability” through adoption of immutable infrastructure, long-lived -feature flags, and so on.
      - “Make decisions reversible” by making it easy to undo deploys and such. Prefer immediately shifting traffic off a broken new version to slowly deploying a previous revision. Prefer  flipping flags to disable new features over deployment, etc.
      - “Prefer evolvable over predictable.” If you optimize for the known challenges for an architecture, you’ll get stuck because there are at least as many unknown challenges as known challenges. It’s better to be able to respond to problems quickly than to cleanly address -what you’re currently aware of.
      - “Build anticorruption layers.” Mostly this means building good interfaces so you can shift -out the implementation underneath. The act of adding interfaces can be expensive as well, so -balance this with finding the last responsible moment to make the decision.
      - “Build sacrificial architectures.” Assume that you’ll make tradeoffs that won’t last forever, and be okay with occasionally throwing away your implementations. Uses example of Ebray rewriting from Perl to C++ to Java over course of seven years.
     -   “Mitigate external change.” For example, don’t rely on global package repositories, but instead pull in copies of packages you need locally. Then you can manage your upgrade timing in addition to owning your build pipeline reliability.
     -    “Libraries versus frameworks.” Argues against frameworks, since you write code that integrates with frameworks, as opposed to writing code that calls out to libraries. Consequently, there is tighter coupling in frameworks.
     -     “Version services internally.” Discussed earlier in these notes, don’t leak version identifiers to users, instead inspect the incoming requests and handle them appropriately. Easier for service to manage that complexity than all clients to handle it.
     -     “Product over project.” Structure your teams, and consequently your architecture, around long-lived products, not to short-lived projects.
     -     “Dealing with external change.” Your clients (as in, software generating requests to your service) will change their needs over time, define explicit contracts to state these agreements, perhaps as Service Level Objectives.
     -     “Culture of experimentation.” Evolution is built on structured, measured experimentation, which requires a structured, thoughtful approach.
     -     Start with low-hanging fruit. Easy wins beget larger wins, start where it’s easy. (I also had a chat earlier this week with Keith Adams who described a power function for which files/systems are frequently changes, so perhaps start where most changes happen.)
     -     Use fitness functions - a particular type of objective integrity assessment of some architectural characteristics
          - Atomic - run against a singular context and exercise one particular aspect of the architecture. Eg. asserting valid types on a codebase, check that no incompatible dependencies exists
          -    Holistic - run against a shared context and exercise a combination of architectural aspects such as security and scalability. e.g. ensuring that no PII Data is published in logs; Monitoring latency due to code change.
  - Design for change
      - Enforce high cohesion and loose coupling
      - Encapsulate Domain knowledge
      - Use asynchronous messaging
      - Don’t build domain knowledge in gateway
      - Expose open interfaces
      - Design and test against service contracts
         - Contract testing is a technique for testing an integration point by checking each application in isolation to ensure the messages it sends or receives conform to a shared understanding that is documented in a "contract". Contract testing is immediately applicable anywhere where you have two services that need to communicate - such as an API client and a web front-end.
      - Use fitness functions - a particular type of objective function that is used to summarize…how close a given design solution is to achieving the set aims
      - Abstract infrastructure (messaging, persistence) away from domain logic
      - Offload cross-cutting
      - Deploy services independently
        - Integrations are #1 risk to stability
          - Every out of process call can kill system including database calls
            - Useful patterns - timeouts, circuit breakers, decoupling middleware, test harness
            - Hunt for resource leaks
            - Handle traffic surges
            - Degrade automatically
            - Shed load
            - Don’t wait forever
            - Test with realistic data volumes
            - Put limits in your APIs
              - Throttling - Not only about abuse prevention but also resource allocation under constraints (could be financial/technical or business related). Some tenets of throttling systems are,
                - Clearly distinguish between customer protection and system protection use cases
                - Integrate closely with auto-scaling infrastructure
                - Use capacity-based limits rather than static ones where possible
                - Prioritize established usage patterns over new spikes
                - Treat throttling as a resource allocation problem, not just an abuse prevention one
                - Test harnesses to emulate the remote system on the other end of each integration point. Consider building a test harness that substitutes for the remote end of every web services call.

     - Architecture and System design decisions
       - Not the "best possible" but "least worst"
       - Good Architecture makes it possible to defer the technical decision(s). Maximizes the number of decisions not made.
       - Architects need to adopt lateral thinking. 
       - Architect needs to have a holistic view of each component regarding performance, scaling, high availability.
 
  - Evolvable Architecture 
       - Guidelines
           - Understand the fragile places within your complex technology stack and automate protections via fitness functions. fitness functions should be used to ensure integrity of integration points.
           - When coupling points impede evolution or other importance architectural characteristics, break the coupling by forking or duplication.
           - Don’t become irrationally attached to handcrafted artifacts. 
           - Reporting in Microservices Architecture  - Many microservices architectures solve the reporting problem by separating behavior, where the isolation of services benefits separation but not consolidation. Architects commonly build these architectures using event streaming or message queues to populate domain “system of record” databases, each embedded within the architectural quantum of the service, using eventual consistency rather than transactional behavior. A set of reporting services also listens to the event stream, populating a denormalized reporting database optimized for reporting. Using eventual consistency frees architects from coordination—a form of coupling from an architectural standpoint—allowing different abstractions for different uses of the application.
         
          - Reduce needless variability  - Immutable Infrastructure (including Development environment), Pair Programming
          - Make Decisions Reversible - Blue/green deployments, Feature Toggles
          - Prefer evolvable over predictable - Use incidental plumbing like message queues, search engines etc. Avoid "wiring" too much to external dependencies by isolating them behind interfaces  .
            - Controlling the coupling points in an application, especially to external resources, is one of an architect’s key responsibilities.  As an architect, remember that dependencies provide benefits but also impose constraints
          - Make sacrificial Architecture -
              - If developers have a project they want to test, building the initial version in the cloud greatly reduces the resources required to release the software. If the project is successful, architects can take the time to build a more suitable architecture. If developers are careful about anti-corruption layers and other evolutionary architecture practices, they can mitigate some of the pains of the migration.
          - Mitigate External Change
              - A good start on dependency management models external dependencies using a pull model. For example, set up an internal version-control repository to act as a third-party component store, and treat changes from the outside world as pull requests to that repository. If a beneficial change occurs, allow it into the ecosystem.
          - Updating libraries versus frameworks
              -  Libraries are preferred because they introduce less coupling to your application, making them easier to swap out when the technical architecture needs to evolve.
              -  One reason to treat libraries and frameworks differently comes down to engineering practices. Frameworks include capabilities such as UI, object-relational mapper, scaffolding like model-view-controller, and so on. Because the framework forms the scaffolding for the reminder of the application, all the code in the application is subject to impact by changes to the framework. Many of us have felt this pain viscerally—​any time a team allows a fundamental framework to become outdated by more than two major versions, the effort (and pain) to finally update it is excruciating.
             -  Update framework dependencies aggressively; update libraries passively.
          - Version Services internally
                -  Patterns used,
                    -  Version Numbering - developers create a new endpoint name, often including the version number, when a breaking change occurs
                    -  Internal Resolution - callers never change the endpoint—​instead, developers build logic into the endpoint to determine the context of the caller, returning the correct version. The advantage of retaining the name forever is less coupling to specific version numbers in calling applications.

           -  Fitness function driven Architecture,
                 -  Building a fitness function that governs critical (like Response time, throughput that determine success) capability to help drive design ensures that it stays top of mind as the architect designs other parts.
                     - Fitness function to measure real performance in production system,
                       - Calculates the number of incoming calls in production to verify the maximum number of requests that the service needs to support and what would be the auto-scaling factor to guarantee availability with horizontal scaling
                       - Make new load and concurrency tests using the new number of requests per second
                       - Monitor the memory and CPU, and define the stress point


  - Generative AI
    - Context Engineering 
      - is the delicate art and science of filling the context window with just the right information for the next step. Science because doing this right involves task descriptions and explanations, few shot examples, RAG, related (possibly multi-modal) data, tools, state and history, compacting 
    - MCP (Model Context Protocol)
      - lets you build servers that expose data and functionality to LLM applications in a secure, standardized way. Think of it like a web API, but specifically designed for LLM interactions.
      - Resources - Allows to expose Data (Similar to HTTP GET) 
      - Tools - Uses to execute code or produce a side effect (Similar to HTTP Post)
      - Prompts - Allows defining interaction patterns

  - API Practices 
    - One the API is public, avoid making changes that will break existing integrations. Changes like addition of field to a response is acceptable
    - Use versioning only when breaking change is absolutely necessary, as far as possible manage versioning internally within API instead of expecting changes in Userspace.
    - For Authentication - Use long lived keys (Easier for non technical users) or OAuth 
    - Idempotency and retries (mainly for write requests) - Support Idempotency keys - Unique, user-defined string in request header or body that allows API to decide action to be taken (like ignore duplicate keys). Maintain such keys in fast store like in-memory cache with expiry
    - Rate limiting - Implement rate limiting metadata in API Responses e.g. X-Limit-Remaining. 
    - Pagination - Prefer cursor based pagination like `where id > [Last value] Order by id limit 10` instead of `?page=2` as it helps in translating it to SQL queries as well. This is because relational databases have to count through your offset every time, so each page you serve gets slower than last page. 

  - Microservices Architecture
    - Why
        - Greater flexibility (Adopt new features fast)
        - Fast dev cycles, smaller teams and code base
        - Fault isolation
        - Cloud ready
        - Platform and language agnostics
        - Better scalability 
    - Costs/Challenges
         - A major challenge of microservices is the complexity that's caused because the application is a distributed system. Developers need to choose and implement an inter-services communication mechanism. The services must also handle partial failures and unavailability of upstream services.
         - Need to manage transactions across different microservices (also referred to as a distributed transaction). Business operations that update multiple business entities are fairly common.
         - More complexity in comprehensive testing
         - Complex deployment
         - Operations overhead in terms of monitoring. Microservice architecture also has more points of failure due to the increased points of service-to-service communication.
         - Latency due to isolated deployment and additional network overhead
         - Check whether per-service databases fit your application
         - must instrument and monitor the environment so that you can identify bottlenecks, detect and prevent failures, and support diagnostics
         - need to secure access to each service both within the environment and from external applications that consume its APIs
         - asynchronous, message-based communication. Synchronous interservice communication typically reduces the availability of an application. 

   -  Services based architecture (Modular Monolith)
       -  Deconstructing a system into a set of complementary services decouples the operation of those pieces from one another. This abstraction helps establish clear relationships between the service, its underlying environment, and the consumers of that service. Creating these clear delineations can help isolate problems, but also allows each piece to scale independently of one another. This sort of service-oriented design for systems is very similar to object-oriented design for programming.
       -  Identifying services
          -  One of the criteria could be read vs. write 
             - Writes are generally expensive than Reads.
             - Web Server perspective, Apache or lighttpd typically has an upper limit on the number of simultaneous connections it can maintain (defaults are around 500, but can go much higher) and in high traffic, writes can quickly consume all of those. Since reads can be asynchronous, or take advantage of other performance optimizations like gzip compression or chunked transfer encoding, the web server can switch serve reads faster and switch between clients quickly serving many more requests per second than the max number of connections (with Apache and max connections set to 500, it is not uncommon to serve several thousand read requests per second). Writes, on the other hand, tend to maintain an open connection for the duration for the upload, so uploading a 1MB file could take more than 1 second on most home networks, so that web server could only handle 500 such simultaneous writes.
             - Planning for this sort of bottleneck makes a good case to split out reads and writes of images into their own services. This allows us to scale each of them independently .Finally, this separates future concerns, which would make it easier to troubleshoot and scale a problem like slow reads.
       -   DB Rules for Modular monolith services, Modular Monolith Data Isolation (milanjovanovic.tech)

    - Architectural Quantum:  the smallest independently deployable unit containing all necessary components (often including a  database). Decisions about separation often define the boundaries of these quanta.
         - Important points while Architecting as per Randy Shoup
           - Application Summary 
                -Who
                 - Who are the users?
                 - Who are the developers?
                 - Who are the stakeholders?
               - What     
                 - What does the system do?
                 - What are it's main features?
               - Why
                 -  Why is the system needed?
              -  When
                 -  When do the users need and/or want the solution?
                 -  When can the developers be done?
              -  How
                 -  How will the system work?
                 -  How many users will there be?
                 -  How much data will there be?
           - Engineering is about solving problems
           - May not want to start with microservices
           - Prototype the Architecture
           - "Just enough" Architecture (Simple, familiar technology)
           - Focus on core competency and leverage Third party services for Logging/Monitoring/alerting,Authentication, Payments/billing/fraud detection
           - Modularity Discipline (Use "shared libraries")
             - Service boundaries match the problem domain
             - All interactions through published service interface (interface hides implementation detail)
             - Separate domain logic from I/O
           - Detailed logging and instrumentation (Understand behaviour, enable diagnosis and recovery)
           - Continuous delivery (Automated deployment)
           - Feature flags
           - A/B Testing
         - When to re-architect (and if it's Monolith)?
           - Reduced feature velocity (slow time to market, team can not work independently)
           - Scalability (Limits of vertical scaling reached)
           - Need for partial deployment 
         - Scalability approaches
           -Technology that scales (Asynchrony, independent systems/services, Events Queue, horizontally scalable persistence) 
         - Observability
           - Infrastructure-level metrics
              ▪ Application throughput & response time
              ▪ Warnings & errors
              ▪ Memory use, CPU load, Storage I/O & network I/O, including a way to distinguish platform from network latency
              - Common mistakes with observability
                - Introducing it too late.
                - Dashboards, unless they are dynamic and allow you to ask questions, are a poor view into software.
                - SLOs (Service Level Objectives) should be the entry point, not dashboards. 
            - App-level metrics
              - GC, Exceptions, Network Latency
              - Request tracing using correlation ID , both for incoming and outgoing requests.
              - Consider an agent as an operations adapter
        - Security
            Threat modelling is a technique that applies framework (e.g. STRIDE) to a system basis data-flow within it to find potential security issues. It is a iterative to process to find and fix issues that begins along with design of the application. Excellent Criteria for Identification of Learn 

      - Criteria for Identification of component/service:
         - Cohesion / Single Responsibility Principle (SRP):
            - Criterion: Does the logic represent a singe, well-defined responsibility or concept? Does it all relate to one primary purpose?
            - Evaluation: Highly cohesive logic (focused on one task) is a strong candidate for separation. If a potential component does many unrelated things, it might need further decomposition. Group things together that change together for the same reasons.
            - Goal: Improve clarity, maintainability, and testability by ensuring components have a clear focus.
         - Volatility / Rate and Reason for Change:
           -  Criterion: Is this logic expected to change frequently? Does it change for different reasons or at a different cadence than the surrounding logic?
           -  Evaluation: Logic that changes often, especially independently of other parts, benefits from separation. This isolates the impact of changes, reducing the risk of breaking unrelated functionality.
           -  Goal: Increase system stability, reduce regression risks, facilitate faster updates to volatile parts.
          - Reusability:
           -  Criterion: Is this logic needed in multiple places within the current system, or potentially by other systems in the future?
           -  Evaluation: If the logic has clear potential for reuse, separating it into a well-defined component (like a library or service) avoids duplication (DRY - Don't Repeat Yourself).
           -  Goal: Promote code reuse, consistency, and reduce maintenance overhead.
         - Scalability Requirements:
           -  Criterion: Does this specific piece of logic have significantly different scaling needs (e.g., much higher throughput, different load patterns) compared to the rest of the system?
           -  Evaluation: If a specific activity is a performance bottleneck or needs to scale independently, separating it (often as a distinct service) allows targeted scaling (e.g., adding more instances just for that component).
           -  Goal: Optimize resource utilization, improve performance and responsiveness under load.
         - Fault Isolation / Availability Requirements:
           -  Criterion: If this logic fails, should it impact the availability of the entire system? Is it critical, or can the system function in a degraded state without it?
           -  Evaluation: Separating logic into components (especially services) can create fault isolation boundaries. The failure of one component is less likely to cascade and bring down others.
           -  Goal: Improve overall system resilience and availability.
         - Security Boundaries:
              Criterion: Does this logic handle sensitive data or operations that require different or stricter security controls than other parts of the system?
              Evaluation: Separation allows you to create a distinct security perimeter around the component, applying specific authentication, authorization, and auditing rules.
              Goal: Reduce the attack surface, enforce security policies more effectively, aid compliance.
         - Independent Deployability:
              Criterion: Is there a business or operational need to deploy updates to this logic independently of the rest of the system?
              Evaluation: Separation (particularly into independently deployable units like microservices) allows for faster release cycles and reduces the scope and risk of deployments.
              Goal: Increase deployment frequency, reduce lead time for changes, enable CI/CD practices.
         - Team Autonomy / Organizational Structure (Conway's Law):
              Criterion: Can a dedicated team reasonably own the development, testing, deployment, and operation of this logic?
              Evaluation: Aligning component boundaries with team structures can improve focus, ownership, and parallel development speed. (Conway's Law suggests systems often mirror the communication structures of the organizations that build them).
              Goal: Enable parallel development, foster ownership, improve team efficiency.
         - Technology or Infrastructure Affinity:
              Criterion: Does this logic have specific technology dependencies (e.g., a particular library, framework, database type, hardware like GPUs) that you don't want to impose on the entire system?
              Evaluation: Separation allows isolating these specific dependencies, giving more flexibility in choosing technologies for different parts of the system.
              Goal: Prevent technology lock-in, allow use of best-fit technology for specific tasks, simplify dependency management.
         - Bounded Context (Domain-Driven Design):
              Criterion: Does the logic belong to a distinct subdomain within the overall business domain, potentially with its own ubiquitous language and model?
              Evaluation: Aligning component boundaries with DDD Bounded Contexts helps maintain conceptual integrity and clarity within complex domains.
              Goal: Create clearer domain models, reduce ambiguity, align software structure with business structure.
         - Complexity Management:
          -   Criterion: Is the logic itself complex? Would separating it make both the new component and the remaining system easier to understand and reason about?
          -   Evaluation: Sometimes separation is justified simply to break down a large, complex problem into smaller, more manageable pieces.
          -   Goal: Reduce cognitive load for developers, improve understandability.

         - Important Considerations:
          -  Trade-offs: Separation is not free. It can introduce new complexities like network latency (for services), data consistency challenges, more complex deployment orchestration, and the need for inter-component communication protocols.
          -  Granularity: The "size" of the component matters. The criteria apply differently when deciding between classes versus microservices. The cost/benefit ratio changes with granularity.
          -  Start Simple: Don't over-decompose initially. It's often easier to combine components later than to split them prematurely.

      Evaluate these criteria based on the specific context, priorities, and constraints of your project. The decision often involves balancing several of these factors

        -  Factors to decide on communication style i.e. synchronous or asynchronous
          -  Synchronous Communication (e.g., REST API calls, gRPC):
                Characteristics: The caller sends a request and blocks (waits) until it receives a response (or timeout/error).
                Pros:
                    Simpler programming model for request-response interactions.
                    Immediate feedback to the caller (success, failure, data).
                    Easier to reason about the immediate flow of control.
                Cons:
                    Temporal Coupling: The caller and receiver must both be available simultaneously. If the receiver is down or slow, the caller is blocked or fails.
                    Reduced Resilience: Failures can cascade easily. A slow downstream service can exhaust resources (threads, connections) in upstream services.
                    Potential Performance Bottlenecks: Long-running synchronous calls can hold up callers.
                When to Consider:
                    Queries (read operations) where the user/caller needs an immediate answer.
                    Commands where immediate confirmation of acceptance/initial validation is required.
                    Interactions within a single architectural quantum where high consistency and immediate feedback are needed, and components are deployed together.
          -  Asynchronous Communication (e.g., Message Queues, Event Streams):
                Characteristics: The caller sends a message/event to an intermediary (like a queue or broker) and does not wait for it to be processed.5 The receiver processes the message independently when it's ready.
                Pros:
                    Temporal Decoupling: Sender and receiver don't need to be available simultaneously. Improves system resilience and availability.
                    Increased Scalability: Receivers can process messages at their own pace; load spikes can be absorbed by the queue. Senders aren't blocked.
                    Enhanced Resilience: Failure of a receiver doesn't immediately impact the sender. Messages can often be retried.
                    Flexibility: Easy to add new consumers for the same message/event later.
                Cons:
                    Increased Complexity: Requires message broker infrastructure. Error handling, monitoring, and debugging become more complex (e.g., handling poison messages, ensuring idempotency, distributed tracing).
                    Eventual Consistency: The caller doesn't get immediate confirmation that the action is fully complete, only that the request was accepted. Data consistency across services takes time.
                    Different programming model (event-driven).
                When to Consider:
                    Commands or events where immediate processing isn't strictly required.
                    Workflows spanning multiple services/domains.
                    Notifications or triggering side effects.
                    Improving system resilience and decoupling critical pathways.
                    Situations where eventual consistency is acceptable./

        - Non-functional aspects
          -  Performance - using response time percentiles, using throughput metrics
                Response time - The elapsed time from the moment when a user makes a request until they receive the requested answer.
                    The response time is what the client sees; it includes all delays incurred anywhere in the system.
                    The service time is the duration for which the service is actively processing the user request.
                    Percentiles are often used in service level objectives (SLOs) and service level agreements (SLAs) as ways of defining the expected performance and availability of a service 
          -     Throughput - The number of requests per second, or the data volume per second, that the system is processing. For a given allocation of hardware resources, there is a maximum throughput that can be handled.
          -  Scalability is a closely related concept to performance i.e. ensuring performance stays the same when the load grows. Involves breaking a task down into smaller parts that can operate independently
          -  Reliability - Using fault tolerance techniques, which allows a system to continue providing its service even if some component (e.g., a disk, a machine, or another service) is faulty. Another aspect of achieving reliability is to build resilience against humans making mistakes, and we saw blameless postmortems as a technique for learning from incidents.
          -  Maintainability - Making it easy to evolve an application’s functionality over time.
          -  Operability - Make it easy for the organization to keep the system running smoothly.
                Allowing monitoring tools to check the system’s key metrics, and supporting observability tools
                Avoiding dependency on individual machines
                Good documentation and easy-to-understand operations model
                Self-healing, good default behaviour
         -   Evolvability - Make it easy for engineers to make changes to the system in the future, adapting it and extending it for unanticipated use cases as requirements change.
         -   Simplicity
                Abstraction -  A good abstraction can hide a great deal of implementation detail behind a clean, simple-to-understand façade. A good abstraction can also be used for a wide range of different applications. 

    - Distributed Systems 
          ○ What is a Distributed System?
               · It runs on multiple processes/servers
               · The number of servers in a cluster can vary from as few as three servers to a few thousand servers
               · It manages data. So these are inherently 'stateful' systems
               · Process communicate by message passing
               · It tolerates partial failures.
          ○ Gist of 12 factors 
               · Services should be simple to build, test and deploy
               · Lightweight (run fast, use less RAM) 
               · Reproducible results on all environments like dev, test, prod etc.
          ○ Stability patterns for distributed Architecture 
               ○ Application Resilience 
                    § RPO	How much data can you afford to lose and recreate?
                    RTO	How quickly must you recover? What is the cost of downtime?
               ○ Integrations are #1 risk to stability 
                    § Every out of process call can kill system including database calls
                    § Useful patterns - timeouts, circuit breakers, decoupling middleware, test harness
               ○ Hunt for resource leaks 
               ○ Handle traffic surges 
                    § Degrade automatically
                    § Shed load
                    § Don’t wait forever 
               ○ Test with realistic data volumes
               ○ Put limits in your APIs
               ○ Throttling - Not only about abuse prevention but also resource allocation under constraints (could be financial/technical or business related). Some tenets of throttling systems are,
                    · Clearly distinguish between customer protection and system protection use cases
                    · Integrate closely with auto-scaling infrastructure
                    · Use capacity-based limits rather than static ones where possible
                    · Prioritize established usage patterns over new spikes
                    · Treat throttling as a resource allocation problem, not just an abuse prevention one
               ○ Test harnesses to emulate the remote system on the other end of each integration point. 
               Consider building a test harness that substitutes for the remote end of every web services call. 
               A test harnesses runs as a separate server, so it is not obliged to conform to any interface. It
               can provoke network errors, protocol errors, or application-level errors.
          ○ Disaster recovery 
               - Design according to your recovery goals (RPO and RTO)
               - DR Patterns 
                    ○ Cold - DR Site needs to be brought up. Typically, DR Site only has cheap storage as target for data backup and nothing else.
                    ○ Warm - DR Site is ready but not automatically up. e.g. Batch processing workloads (i.e. short pause before  processing can be continued)
                    ○ Hot - Switch to DR is almost immediate when needed. e.g. E-commerce (transactional part). Typically involves Hot HA across primary and DR site. 
          ○ Capacity management is an ongoing process of monitoring and optimization. It involves many dimensions and opposing dynamics. Software changes, traffic changes, and even marketing campaigns can all cause different forces to dominate your capacity. Working with capacity requires a big-picture view of the system as a whole. Capacity is fundamentally a measure of how much revenue the system can generate during a given period of time.
               - Place safety limits on everything: timeouts, maximum memory consumption, maximum number of connections, and so on.
               - Try to do the most work when nobody is waiting for it
               - Monitor capacity continuously. Each application release can affect scalability and performance. Changes in user demand or traffic patterns change the system’s workload
          ○ Fallacies of Distributed Computing
               · Effects of Fallacies of distributed computing 
                    □ App needs error handling/retries 
                    □ App should minimize # of requests 
                    □ App should send small payloads
                    □ Must secure data and authenticate requests 
                    □ Changes affect latency, bandwidth and endpoints 
                    □ Changes affect ability to reach destination 
                    □ Network affects reliability , latency and bandwidth
               - Single (Single tenant) vs. distributed systems (Multi tenant) 
                 - Distributed Systems offer higher availability due to redundancy 
                 - Multiple copies of data on multiple machines is a way to make online data durable. Single-System approaches like RAID do not offer failure independence
                 - Multi-tenant systems achieve lower costs and higher utilization by packing multiple diverse workloads onto same resources. Also allows systems with unpredictable load spikes to share spare burst resources. 
                 - Better latency management due to spread of short-term spikes of load over a larger pool of resources. 
                 - Segregation/isolation of specialized workload like latency-sensitive, throughput-sensitive, locality-sensitive, compute-sensitive, memory-sensitive etc. 
                 - changes can be managed by taking advantage of high availability mechanisms of the system to allow for safe zero-impact patching and deployment.
               · In-process call vs. network request
                    □ Performance: Worse, increases network congestion, unpredictable timing
                    □ Unreliable: Requires retries, timeouts, & circuit breakers
                    □ Server code must be idempotent
                    □ Security: Requires authentication, authorization, & encryption
                    □ Required in VNET for compliance or running 3rd-party (untrusted) code
                    □ Diagnostics: network issues, perf counters/events/logs, causality/call stacks. NOTE: Servers’ clocks are not absolutely synchronized
          ○ Understanding distributed systems through patterns 
               · Write-ahead log - to sync multiple data stores while performing update one at a time in atomic way. 
               · Leaders and followers - To achieve fault tolerance in systems that manage data, the data needs to be replicated on multiple servers. In this context , one of the nodes is marked as the leader, and the others are considered followers. The leader is responsible for taking decisions on behalf of the entire cluster and propagating the decisions to all the other servers. It deals with situation of leader failing by means of heartbeat (a regular message sent between nodes).
                    □ Generational clock - number that increments with each leadership election.a simple technique used to determine ordering of events across a set of processes, without depending on a system clock. Each process maintains an integer counter, which is incremented after every action the process performs. Each process also sends this integer to other processes along with the messages processes exchange. The process receiving the message sets its integer counter by choosing the maximum between its own counter and the integer value of the message.
                    □ High water mark - Maintained by the leader and is equal to index of latest update to be committed.
              - Singular update queue - Allowing client threads to write entries onto  a queue. A separate  processing thread reads entries from this queue and carries out the processing in order. 
              - Segmented log - Single log is split into multiple segments. Log files are rolled after a specified size limit. This is to avoid issues with single log file getting too large.
              - Low water mark -  A mechanism to tell logging machinery which portion of the log can be safely discarded. Different types include snapshot based , time based
              - Heartbeat - Timely detection of server failures is important for taking corrective actions. Heartbeat involves periodically sending a request to all other nodes to check liveness. Typically duration is set at higher value than time for network round trip between servers. -Other messages between servers can also serve the purpose of heartbeats.
                - Consensus based systems (Raft/Zookeeper) - Leader server sends heartbeats to all follower nodes.
                - Large clusters, gossip based  
              - Majority Quorum -  Need to ensure that in the event of crash , results of operations are available to all clients. In a cluster, how many servers are needed to confirm to leader that  operation was successful. To balance overall system performance and integrity ,cluster agrees that operation is deemed successful if majority of nodes acknowledge it. For a cluster of n nodes, the quorum is n / 2 + 1.The need for a quorum indicates how many failures can be tolerated—which is the size of the cluster minus the quorum. A cluster of five nodes can tolerate two of them failing. In general, if we want to tolerate f failures we need a cluster size of 2f + 1.Quoram size is adjusted as per proportion of expected read vs. write volumes etc.
              - Paxos - phases
                   □ Prepare phase: Establish the latest Generation Clock and gather any already accepted values
                   □ Accept phase: Propose a value for this generation for replicas to accept
                   □ Commit phase: Let all the replicas know that a value has been chosen. 
              - Idempotent receiver - Identify requests from clients uniquely so you can ignore duplicate requests when client retries.

    - Asynchronicity, Queues
         - "Asynchronous" - Your application sends a message or event and then carries on doing something else. It does not sit around waiting for an outcome.
         - asynchronous messaging infrastructure does,
             * Decoupling: A system handling work behind a messaging infrastructure can be running at capacity and yet not be overwhelmed and   can even be down while the messaging infrastructure still accepts   messages on its behalf.
             * Delivery: You can entrust over your messages and the   messaging system will try its best not lose them. It will then attempt   to deliver them to the right parties and will retry as often as necessary.
             * Buffering: A messaging infrastructure is generally great at   accepting bursts of messages at once and organizing them for later   retrieval. The retrieval can then occur at the pace that your   application can handle. That is also called load-leveling.
             * Network-Bridging: Messaging infrastructures can often be   attached to multiple networks, allowing information to pass between   applications in those networks without there being IP-level connectivity   between them.
         - Queues are One of the most fundamental and most important data  structures in computing
             - Sequence of records , commonly ordered by moment of arrival
             - Write/add at the bottom , read/consume at the top
             - Consumed records are removed
             - Length of queue can always be read
         - Characteristics of Message queues
             - Accepts, stores and makes message available for consumption
             - Queue individually manages lifecycle of each message
             - Each message is exclusively acquired by one consumer
             - The queue length can be queried
             - Queues do not improve end-to-end latency
             - Queues do not improve mean throughput
             - Queues do not provide total event ordering
             - Queues can offer at-most-once or at-least-once delivery
             - Queues do improve burst throughput
             - Distributed queues also improve fault tolerance (if they don’t lose data)
             - Every queue is a place for things to go horribly, horribly wrong
         - Kafka is not a "message queue"
             - Messages are acquired by consumer groups
             - consumer groups can query topic back and forth.
             - Its event streaming engine
             - Use cases
               - Load leveling - allows a business process to handle   transactions at optimal capacity use and without getting overwhelmed.Spiky loads are buffered by the queue until the processor   can handle them .
               - Discrete event router - Push style distribution of   discrete events to serverless workloads or other messaging infrastructures (Azure event grid)
               - Queue pub/sub broker - Pull-style, queue based transfer   of  jobs (RabbitMQ)
               - Event Stream engine - Partitioned, high volume,   sequential recording and unlimited pull style re-reads of event streams.   (kafka, pulsar)
               - Event stream aggregator - Stateful processing of event   streams yielding event streams (Apache Samza, Apache Flink)

- Data Architecture
  - FLAIR data principles
         -  Findable - The ability to view which data assets are available, access metadata and other attributes related to governance and compliance
         -  Lineage - The ability to find data origin, trace data back, understand and visualize data as it flows through data sources
         -  Accessibility - Ask for Security credentials while accessing data asset. Networking infrastructure to facilitate efficient access
         -  Interoperability - Using format acceptable to most internal processing systems
         -  Reusability - Data  is part of known schema.
  - Aspects
    - Property                 OLTP                                             OLAP 
     Main read pattern        Point queries (fetch individual records by key)   Aggregate over large number of records

     Main write pattern       Create, update, and delete individual records     Bulk import (ETL) or event stream
     
     Human user example       End user of web/mobile application                Internal analyst, for decision support
     
     Machine use example      Checking if an action is authorized               Detecting fraud/abuse patterns
     
     Type of queries          Fixed set of queries, predefined by application   arbitrary queries by analyst

     State of data            Latest state of data (current point in time)      History of events that happened over time

     - Data/Database
        - Aggregate  orientation  is  the  preference  to  operate  on  data  that  is  related  and  has  a complex  data  structure.
        - Identify Data Domains - Data domain is logical/physical segregation of database objects related to a particular domain e.g. customer, Survey and so on.
        - Why Disintegrate Operational Data? 
          - Change control - How many services are impacted by a database table change?
          - Connection Mgmt. - Can my database handle the connections needed from multiple distributed services?
            - Connection quota per service approach or using connection pooler like pgBouncer. It is recommended to start out with the even distribution approach and creating fitness  functions  to  measure  the  concurrent  connection  usage  for  each  service.  We also  recommend  keeping  the  connection  quota  values  in  an  external  configuration server  (or  service)  so  that  the  values  can  be  easily  adjusted  either  manually  or  pro‐grammatically through simple machine learning algorithms. This technique not only helps  mitigate  connection  saturation  risk,  but  also  properly  balances  available  data‐base connections between distributed services to ensure that no idle connections are wasted.
         - Scalability - Can the database scale to meet the demands of the services accessing it?
         - Fault Tolerance - How many services are impacted by a database crash or maintenance downtime?
         - when sharing a sin‐gle  database,  overall  fault  tolerance  is  low  because  if  the  database  goes  down,  all services become nonoperational.
         - Architectural Quanta - Is  a  single  shared  database  forcing  me  into  an  undesirable  single  architecture quantum?
         - Database type Optimization - Can I optimize my data by using multiple database types?
        - Drivers for integrating the data 
          - Data relationships - Are  there  foreign  keys,  triggers,  or  views  that  form  close  relationships  between the tables?
          - Database transactions - Is a single transactional unit of work necessary to ensure data integrity and consistency?

  - Data Architecture best practices
    -   Understanding Actual data access patterns of the Application
        - Partitioning of the tables
        - Routine archival and purging
        - OLTP schema is not good for data warehousing
        - Decouple pipeline between ingestion, storage, processing and insights for increased fault tolerance
    -   Things to consider while determining tools
        - Structure of data
        - Maximum acceptable latency
        - Minimum acceptable throughput
        - Typical access patterns of end-users
    -   Things to consider for Data Ingestion
        - Structure of Data
        - How quickly does new data needs to be available for querying?
        - What is the size of data ingest?
        - What is total volume and growth rate?
        - What the cost will be to store and query the data in any particular location

  - Questionnaire for Architecture Design Session  for Data Warehouse project,
     -  Is your business using the cloud?
     -  Is the data architecture you’re considering a new solution or a /ration?
     -  What are the skill sets of the engineers?
     -  Will you use nonrelational data?
     -  How much data do you need to store?
     -  Will you have streaming data?
     -  Will you use dashboards and/or ad-hoc queries?
     -  Will you use batch or interactive queries?
     -  Are their service level agreements (SLA) for performance of reports?
     -  Will the data be used for predictive analytics or ML Models?
     -  HA and DR Requirements
     -  Is MDM needed? (Master  data  management  (MDM)  involves  creating  a  single  master  record  foreach  person,  place,  or  thing  in  a  business,  gathered  from  across  internal  and external data sources and applications. These master records can then be used to build more accurate reports, dashboards, queries, and machine learning models.)
     -  Are there any security limitations with storing data in the cloud
     -  Does this solution require 24/7 client access?
     -  How many concurrent users will be accessing the solution at peak times? And how many on average?
     -  Skill level of end user?
     -  Budget?
     -  Planned time line
     -  Is the source data on cloud or on-prem?
     -  Volume of data to be imported every day
     -  Current pain points
     -  Third-party or Open source tools?
     -  Security requirements? Data Sovereignty?

    - Operational systems consist of the backend services and data infrastructure where data is created, for example by serving external users. Here, the application code both reads and modifies the data in its databases, based on the actions performed by the users.
    - Analytical systems serve the needs of business analysts and data scientists. They contain a read-only copy of the data from the operational systems, and they are optimized for the types of data processing that are needed for analytics.
          data lake: a centralized data repository that holds a copy of any data that might be useful for analysis, obtained from operational systems via ETL processes
          DevOps
              Automation—preferring repeatable processes over manual one-off jobs,
              preferring ephemeral virtual machines and services over long running servers,
              enabling frequent application updates,
              learning from incidents, and
              preserving the organization’s knowledge about the system, even as individual people come and go

- General Architecture build Guidelines
  - Logging rules
     - ERROR: "your code is really broken"
     - WARNING: "your code is broken, but only in a subtle way that will bite you later"
     - INFO: "irrelevant trivia"
     - DEBUG: "information that would help you understand what's going on if you had enabled debug logging in production which you didn't"
     - INFO Level is for business while DEBUG is for developers
     - Log INFO after the operation is over and not before
     - Distinguish between WARNING (Typically can be retried) and error
     - While Logging, ask questions like,
         - Is this log really needed? does it rely important information I couldn’t get from the other logs in the same flow?
         - Am I going to log an object that can be huge on production? If so, can I just log a few metrics of that objects instead? for example, it’s length, or handpick a few important attribute to log.
         - Does the information I am about to log will help me to debug/understand the flow?
     - Alternative use of Log levels
         - ERROR: Parts of the flow failed, we want to send alerts to our on-call for this failures.
         - WARNING: Doesn’t necessarily point to a failure, but an unexpected behavior that should be investigated.
         - INFO: Record major events in the flow to help the developer reading it understand what was being executed.
         - DEBUG: Like INFO but more detailed, including inspection into objects, data structures, etc.
    - scenario based 
	- The requirement is An online retailer runs a flash sale with 500 units of a hot product. Within minutes, they've processed 742 orders. Their inventory shows -242 units. You are 		using postgresql and thinking about using locks on inventory table to overcome this issue however it impacts throughput. What are different approaches to handle this?
		- Use optimistic locking - Have version being maintained in inventory table and check version every time stock level is to be updated. Retry if stock level update fails due 		to retries.  It offers a good balance of performance and data consistency, pushing the complexity to the application for retries, which is often manageable.
		- Queue-Based Order Processing (Where all updates are queued and processed by separate worker(s)) is a strong contender, especially if the volume of orders during the flash sale is truly enormous. It provides excellent scalability and resilience, but at the cost of increased architectural complexity and eventual consistency.
		- Avoid pessimistic locking using 'For update'  as its not scalable 

    - Web Application Monitoring
         - Metrics to observe for Web Applications
             - Response Time p50, p90, p99, sum, avg
             - Throughput by HTTP status
             - Worker Utilization
             - Request Queuing Time
             - Service calls
             - Database(s), caches, internal services, third-party APIs, ..
             - Enqueued jobs are important!
             - Circuit Breaker tripping
             - Errors, throughput, latency p50, p90, p99
             - Throttling
             - Cache hits and misses %
             - CPU and Memory Utilization
             - Exception counts

         - Metrics to observe for Web Applications
             - Job Backend (e.g. Sidekiq, Celery, Bull, ..)
             - Job Execution Time p50, p90, p99, sum, avg
             - Throughput by Job Status {error, success, retry}
             - Worker Utilization
             - Time in Queue
             - Queue Sizes
             - Don’t forget scheduled jobs and retries!
             - Service calls p50, p90, p99, count, by type
             - Throttling
             - CPU and Memory Utilization
             - Exception counts
         - Relevant Metrics should be available to slice by endpoint or job,
    tenant_id, app_id, worker_id, zone, hostname, and queue (for jobs).
         - In absense of observability setup, start with logs.
         - Key Non-functional aspects of a Payments System
             - Reliability and fauly tolerance
             - Reconciliation
         - Non relational databases are good for below requirements,
             - Application requires super-low latency
             - Data is unstructured or no relational data
             - Only need to serialize/de-serialize data
             - Store massive amount of data

   - Approach for Architecture building (Monolith to Service based Migration)
        - There must be business drivers to go for Service based Architecture
          - Availability
          - Scalability
          - Separation of Concerns (Reporting functionality , reporting load)
          - Agility (faster implementation of changes)
          - Testability
          - Better and faster deployability

        - Architectural  quantum  is  defined  as  an  independently deployable artifact with high functional cohesion, high static coupling, and synchro‐nous  dynamic  coupling

        - Application 
          - High cohesion, low coupling - "Things that change together should stay together" 
          - logically  group  components  together (those performing some sort of related functionality)  so  that  more  coarse-grained domain services can be created when breaking up an application.
          - a component  as   a   building   block   of   the   application   that   has   a   well-defined   role   and responsibility  in  the  system  and  a  well-defined  set  of  operations.
          - Typical Namespace composition  can be "Application.Domain.SubDomain.Component.Class".
          - Infrastructure Cross-cutting functionality is operational in nature and common to all processes (like logging, metrics, security)  but there may exist some domain functionality that can be shared across some processes.Examples of Infrastructure related Cross cutting/common functions are logging, security, utilities, formatters, converters, extractors, auditing, monitoring. 
          - Identify and Size Components 
            - analyze  the incoming  and  outgoing  dependencies  (coupling)  between  components  to  determine what  the  resulting  service  dependency  graph  might  look  like  after  breaking  up  the monolithic application. This is not individual class dependencies within a component(i.e. across namespaces). A component dependency is formed when a class from one component (namespace) interacts with a class from another component (namespace). A monolithic application with too many component dependencies is not feasible to break apart. component  coupling  is  one  of  the  most  significant factors in determining the overall success (and feasibility) of a monolithic migration effort. Both afferent (incoming) and efferent (Outgoing) coupling should summed up.

            - One metric that could be used is calculating  the  total  number  of  statements  within  a given  component  (the  sum  of  statements  within  all  source  files  contained  within  a namespace  or  directory). 
                -  A  statement  is  a  single  complete  action  performed  in  the source  code,  usually  terminated  by  a  special  character  (such  as  a  semicolon  in  languages such as Java, C, C++, C#, Go, and JavaScript. Having  a  relatively  consistent  component  size  within  an  application  is  important.Generally speaking, the size of components in an application should fall between one to two standard deviations from the average (or mean) component size.
            - Additional factors for Service Scoping  
                - Aspects to identify service boundaries 
                  - Business functionality groups - Mimicking existing business communication hierarchy
                  - Transactional Boundaries - Check for transactional boundaries adhered to by Business 
                  - Deployment goals - Partition on the basis of, 
                    - Release frequency
                    - Operational Characteristics (e.g. Scalability)
                - Service scope and function - Is the service doing too many unrelated things?
                - Code volatility - Are changes isolated to only one part of the service?
                - Scalability and throughput - Do parts of the service need to scale differently?
                - Fault tolerance - Are there errors that cause critical functions to fail within the service?
                - Security - Do some parts of the service need higher security levels than others?
                - Extensibility -  Is the service always expanding to add new contexts?
                - Cohesion - the degree and manner in which the operations correlate.
                - Over performance and responsiveness - if  the  functionalities  are  tightly      coupled  and  dependent  on  one another then its better to keep service together. A good rule of thumb is to take into consideration  the  number  of  requests  that  require  multiple  services  to  communicate with  one  another,  also  taking  into  account  the  criticality  of  those  requests  requiring interservice  communication.  For  example,  if  30%  of  the  requests  require  a  workflow between  services  to  complete  the  request  and  70%  are  purely  atomic  (dedicated  to only  one  service  without  the  need  for  any  additional  communication),  then  it  might be  OK  to  keep  the  services  separate.
                - Code volatility - the rate at which the source code changes—is another good driver for breaking a service into smaller ones.
                - Scalability and throughput - The  scalability  demands  of  different  functions  of  a  service  can  be  objectively  measured  to  qualify  whether  a  service  should  be  broken  apart.
                - Fault Tolerance - describes the ability of an application or functionality within a particular domain to continue to operate, even though a fatal crash occurs (such as an out-of-memory   condition).
                - Security - Separation of Service based on Security needs of parts.
                - Extensibility - the  ability to add additional functionality as the service context grows.
                - Database Transactions - Is an ACID transaction required between separate services? if  having  a  single-unit-of-work  ACID  transaction  is required from a business perspective, these services should be consolidated into a single service.If data integrity and data consistency are important or critical to an operation, it might be wise to consider putting those services back together.
                - Workflow and Choreography - Do services need to talk to one another? Shared code: Do services need to share code among one another? Database relationships: Although a service can be bro‐ken apart, can the data it uses be broken apart as well? Too much workflow (Service to service communication) impacts overall performance and responsiveness
          - Functional Decomposition Approach - Identify % Codebase dedicated to a specific component or business task (e.g. Trouble Ticket component  containing  22%  of  the  codebase  that  is  responsible  for ticket creation, assignment, routing, and completion). If  no  clear  subdomains  exist within a large component, then leave the component as is.
  - Fitness functions 
      - All namespaces under <root namespace node> should be restricted to <listof domains>
      - All components in <some domain service> should start with the same namespace
      - Maintain component inventory - It’s used to alert  architect of components that might have been added or removed by the development team. Identifying new or removed components is not only critical for this pattern, but for the other decomposition patterns as well
      - No component shall exceed <some percent> of the overall codebase - identifies  components  that  exceed  a  given  threshold  in  terms  of  the percentage  of  overall  source  code  represented  by  that  component,  and  raise alert.
      - No component shall exceed <some number of standard deviations> from the mean component size - identifies  components  that  exceed  a  given  threshold  in  terms  of  the number  of  standard  deviations  from  the  mean  of  all  component  sizes  (based  on  the total number of statements in the component), and raises alert.
      -make sure no  component  has  “too  many”  dependencies,  and  to  restrict  certain  components from  being  coupled  to  other  components
      - No component shall have more than <some number> of total dependencies
      - <some component> should not have a dependency on <anothercomponent>


  - Template for "Design Document"
       - Title : Title of the document
       - Date: Date of last revision
       - Author(s)/Reviewer(s)/Approver(s)
       - Revision Number
       - Status - In draft/in review/approved/in progress.
       - Executive Summary - brief summary of the project that contains the major goal of the project and how it is achieved.
       - Goals ("In Scope") - What is to be achieved by the project, typically represented as a bullet list. Include non-tangible, process goals such as standardization or metrics requirements.
       - Non-goals ("Out of scope") - A list of non-goals should explicitly identify what is not included in the scope for this project.
       - Background - brief history. Identify any acronyms or unusual terminology used. Document any previous decisions made that resulted in limitations or constraints.
       - High-level Design - How design works at a high level.
       - Detailed Design - The full design, including diagrams, sample configuration files, algorithms, and so on. This will be your full and detailed description of what you plan to accomplish on this project
       - Alternatives Considered - A list of alternatives that were rejected, along with why they were rejected.
       - Special Constraints - A list of special constraints regarding things like security, auditing controls, privacy, and so on.

       Below are not mandatory but could be useful,

       - Cost Projections: The cost of the project—both initial capital and operational costs, plus a forecast of the costs to keep the systems running.
       - Support Requirements: Operational maintenance requirements. This ties into Cost Projections, as support staff have salary and benefit costs, hardware and licensing have costs, and so on.
       - Schedule: Timeline of which project events happen when, in relation to each other.
       - Security Concerns: Special mention of issues regarding security related to the project, such as protection of data.
       - Privacy and PII Concerns: Special mention of issues regarding user privacy or anonymity, including plans for handling personally identifiable information (PII) in accordance with applicable rules and regulations.
       - Compliance Details: Compliance and audit plans for meeting regulatory obligations under SOX, HIPPA, PCI, FISMA, or similar laws.
       - Launch Details: Roll-out or launch operational details and requirements.


=========================================================================================================


  - Understanding distributed systems through patterns
    -     Write-ahead log - to sync multiple data stores while performing update one at a time in atomic way.
    -     Leaders and followers - To achieve fault tolerance in systems that manage data, the data needs to be replicated on multiple servers. In this context , one of the nodes is marked as the leader, and the others are considered followers. The leader is responsible for taking decisions on behalf of the entire cluster and propagating the decisions to all the other servers. It deals with situation of leader failing by means of heartbeat (a regular message sent between nodes).
    -         Generational clock - number that increments with each leadership election.a simple technique used to determine ordering of events across a set of processes, without depending on a system clock. Each process maintains an integer counter, which is incremented after every action the process performs. Each process also sends this integer to other processes along with the messages processes exchange. The process receiving the message sets its integer counter by choosing the maximum between its own counter and the integer value of the message.
    -         High water mark - Maintained by the leader and is equal to index of latest update to be committed.
    -     Singular update queue - Allowing client threads to write entries onto  a queue. A separate processing thread reads entries from this queue and carries out the processing in order.
    -     Segmented log - Single log is split into multiple segments. Log files are rolled after a specified size limit. This is to avoid issues with single log file getting too large.
    -     Low water mark -  A mechanism to tell logging machinery which portion of the log can be safely discarded. Different types include snapshot based , time based
    -     Heartbeat - Timely detection of server failures is important for taking corrective actions. Heartbeat involves periodically sending a request to all other nodes to check liveness. Typically duration is set at higher value than time for network round trip between servers. Other messages between servers can also serve the purpose of heartbeats.
    -         Consensus based systems (Raft/Zookeeper) - Leader server sends heartbeats to all follower nodes.
    -         Large clusters, gossip based  
    -     Majority Quorum -  Need to ensure that in the event of crash , results of operations are available to all clients. In a cluster, how many servers are needed to confirm to leader that operation was successful. To balance overall system performance and integrity ,cluster agrees that operation is deemed successful if majority of nodes acknowledge it. For a cluster of n nodes, the quorum is n / 2 + 1.The need for a quorum indicates how many failures can be tolerated—which is the size of the cluster minus the quorum. A cluster of five nodes can tolerate two of them failing. In general, if we want to tolerate f failures we need a cluster size of 2f + 1.Quoram size is adjusted as per proportion of expected read vs. write volumes etc.
    -     Paxos - phases
          - Prepare phase: Establish the latest Generation Clock and gather any already accepted values
          - Accept phase: Propose a value for this generation for replicas to accept
          - Commit phase: Let all the replicas know that a value has been chosen. 
    -     Idempotent receiver - Identify requests from clients uniquely so you can ignore duplicate requests when client retries.


- Concepts
  - New Techniques in Browser,
       - For Server-sent events,
           - The EventSource interface is web content's interface to   server-sent events. An EventSource instance opens a persistent   connection to an HTTP server, which sends events in text/event-stream  format. The connection remains open until closed by calling EventSource.close().
           - Unlike WebSockets, server-sent events are unidirectional;   that is, data messages are delivered in one direction, from the server   to the client (such as a user's web browser). That makes them an  excellent choice when there's no need to send data from the client to the server in message form. For example, EventSource is a useful   approach for handling things like social media status updates, news feeds, or delivering data into a client-side storage mechanism like   IndexedDB or web storage.

  - UI
      - Micro frontend - the user interface elements that interact on behalf of the services are  emitted  from  the  services  themselves.
     - Server side web app or SPA
         - Use traditional web applications when:
             - Your application’s client-side requirements are simple or even read-only.
             - Your application needs to function in browsers without JavaScript support.
             - Your team is unfamiliar with JavaScript or TypeScript development techniques
         - Use a SPA when:
             - Your application must expose a rich user interface with many features.
             - Your team is familiar with JavaScript, TypeScript, or Blazor WebAssembly development.
             - Your application must already expose an API for other (internal or public) clients.
         - Framework for front-end
             - React: easy componentization, commonly used, flexible
             - Apollo GraphQL: commonly used (good docs), simple, automatic type generation
             - Next.js: SSR by default, capable filesystem server, built-in SPA router, helpful docs
             - Typescript: catch runtime errors at build, easy debugging

     - SSR and CSR
         - Server-side rendering does basically the same job as client-side rendering: generating HTML.
         - The only real difference is that server-side rendering provides pre-rendered HTML to clients while client-side rendering requires the client to run JS files to render the HTML.
         - server-side rendering is ideal for websites that need strong search engine presence, since search engine bots can just read the static content immediately instead of possibly running into issues with JS content.
         - Server-side rendering is also necessary if clients have technical limitations, such as being unable to run JavaScript. Otherwise, server-side rendering is practically equal to client-side rendering.

  - Process vs Threads
     - Processes have their own address space, memory and open file tables
     - Processes are self isolating i.e. corrupt process cannot hurt other processes
     - Existing processes can execute task much faster. (An example of queueing implemented with processes is the Pre-fork processing module for the Apache web server. On startup, Apache forks off a certain number of subprocesses. Requests are distributed to subprocesses by a master process.)
     - So how do we decide between multiprocessing and multithreading?
         - Multithreading for I/O intensive tasks
         - Multiprocessing for CPU intensive tasks (if you have multiple cores available)   
     - Process - Unit of isolation at OS level. Process starts when OS runs program which is stored as file.
     - Thread - Unit of execution within process. Process at least has one thread.

  - Sync and Async ( Everything can't be async )
     - Javascript solves this by making everything non-blocking because blocking would destroy browser's UI Thread which is it's primary use case.
     - golang does this via go routines
     - .NET is one of the platforms that has excellent support for interop with the underlying OS (pinvokes) aka FFI (foreign function interfaces). It has one of the best FFI systems on the market
     - The moment you need to call into the underlying platform, you need to context switch from your current “green” thread, to one compatible to what the underlying platform supports. This is one of the big costs and why golang had to rewrite things in go and goasm.
     - The other difficulty .NET has is that it allows pinning memory. Maybe you pinned some object to get the address or pass it to another function. This is problematic, when you want you want to grow the stack dynamically in your user mode thread implementation.
     - The inability to copy the stack means you need to do a linked list instead. This is a complex and inefficient implementation. Java and go can both copy because there’s no way to get the underlying address of anything (without really unsafe code).
     - Async state machines in .NET form linked list.

  - TCP Protocol
     - Runs on top of IP.any data you send via TCP gets converted into one or more datagrams, then sent over the networking using IP, then is reassembled into a stream of data on the other end.
     - Created to ensure that all packets sent arrive at the destination. That too in same sequence and without duplication
     - In UDP, data is sent one datagram at a time unlike TCP.
     - Socket is a endpoint for network communication. Its a virtual device exposed on a computer.

  - Websockets
     -  web socket server starts off by being an HTTP server, accepting TCP conections and handling the HTTP requests on the TCP connection. When a request comes in that switches that connection to a being a web socket connection, the protocol handler is changed from an HTTP handler to a WebSocket handler. So it is only that TCP connection that gets its role changed: the server continues to be an HTTP server for other requests, while the TCP socket underlying that one connection is used as a web socket.

  - EBPF
       - small snippets of code that run in linux kernel
       - It can hook into events
       - Can be attached to network socket
       - It an listen to events and make changes to albeit with restrictions
       - Written in stripped down 'C' language
       - Available in all linux distributions and has some support on window but not MacOS yet
       - Allows to run code in kernel space
       -Typically the way it works is user space program loads eBPF in kernel
       - LLVM dictates specification ofor EBPF
       - Use cases are,
           - Security - Analyzing trace events to correlate & Detect intrusion
           - Observability /SRE

  - Back-pressure 
     - In a producer-consumer system, there could be mismatch between rates at which production and consumption happens. Back-pressure is the ability of the consumer to say “Yo, hang on a minute!” to the producer, causing the producer to stop until the consumer catches up.


    - Memory Management
     - OS has Virtual memory manager (VMM) that allocates VM to processes
         - VM enables both isolation and sharing
         - Hardware implements a mechanism called paging which allows the OS to implement virtual memory
         - Provided by the MMU (Memory Management Unit)
         - Memory divided in pages (usually 4k)
         - Virtual to physical page mapping in page tables (that the MMU walks)
         - When a virtual page doesn’t have a valid corresponding physical page, a page fault occurs
         - Control is transferred to the OS to provide a physical page (or an AV) Demand paging

    - How does Garbage collector (GC) decides if it should collect out object?
         - GC.Collect() collects the whole heap
             - This means GC does NOT decide the objects’ lifetime
             - GC only gets told by others if an object is live
             - In this case JIT tells the GC that object is still live
             - JIT is free to lengthen the object lifetime till the end of method and has always been

- General Architecture Guidelines 
    - An architect can seek to understand a team’s engineering culture by asking questions like:
       - Does everyone on the team know what fitness functions are and consider the impact of new tool or product choices on the ability to evolve new fitness functions?
       - Are teams measuring how well their system meets their defined fitness functions?
       - Do engineers understand cohesion and coupling? What about connascence [is a software quality metric that provides a taxonomy for different types of coupling in code]?
       - Are there conversations about what domain and technical concepts belong together?
       - Do teams choose solutions not based on what technology they want to learn but based on its ability to make changes?
       - How are teams responding to business changes? Do they struggle to incorporate small business changes, or are they spending too much time on them?  
       - Anti patterns
           -  Low code/No code Environments - typically fall short to cover 100% of user's requirements
           -  Vendor driven - an architecture built entirely around a vendor’s product that pathologically couples the organization to a tool.To escape this anti-pattern, treat all software as just another integration point, even if it initially has broad responsibilities. By assuming integration at the outset, developers can more easily replace behavior that isn’t useful with other integration points, dethroning the king.
          -  Understand the fragile places within your complex technology stack and automate protections via fitness functions.
          - Governance - pick three technology stacks for standardization—​simple, intermediate, and complex ​and allow individual service requirements to drive stack requirements. This gives teams the flexibility to choose a suitable technology stack while still providing the company some benefits of standards.        

     - Three basic Architecture Styles
       -  modern trade-off analysis in software architecture:
           - Find what parts are entangled together.
           - Analyze how they are coupled to one another.
           - Assess   trade-offs   by   determining   the   impact   of   change   on   inter dependent systems
           - Trappings  of  microservices  (such  as  data decomposition,  distributed  workflows,  distributed  transactions,  operational  automation,  containerization)
           - Architects  shouldn’t  break  a  system  into  smaller  parts  unless  clear  business  drivers exist.  The  primary  business  drivers  for  breaking  applications  into  smaller  parts include  speed-to-market  (sometimes  called  time-to-market)  and  achieving  a  level  of competitive advantage in the marketplace. Speed-to-market  is  achieved  through  architectural  agility—the  ability  to  respond quickly  to  change.  Agility  is  a  compound  architectural  characteristic  made  up  of many  other  architecture  characteristics,  including  maintainability,  testability,  and deployability.     
          - Fallacies of Distributed computing, 
            - The network is reliable;
            - Latency is zero;
            - Bandwidth is infinite;
            - The network is secure;
            - Topology doesn't change;
            - There is one administrator;
            - Transport cost is zero;
            - The network is homogeneous;
            - Observability is optional
            - Compensating updates always work 

         - Monolith (Single Deployment)
           - Big ball of Mud
        
         - Modular Monolith or Service based Architecture   
           - Allows technical organizations to avoid coordinating (the more the organization needs different pieces to coordinate with one another to work, the less its going to be able to grow) on things like data models, implementation choices , fleet management, tool choices and such things that aren't core to their business. APIs are fundamentally contracts that move coordination from human-to-human to system-to-system and constrain that coordination in ways that allow systems to handle it efficiently.
           - is a software architecture pattern that combines the advantages of monolith with microservices architecture. In this, Systems are organized into loosely coupled modules, each delineating well-defined boundaries and explicit dependencies on other modules. 
             - Each module is independent (or minimally dependant) with its own layers such as Domain, Infrastructure and API. 
             - Each module is autonomously developed, tested and deployed
             - Loose coupling and cohesion
             - Communication between modules happen through APIs , preferably in asynchonous manner 
             - Unified database schema 
             - All modules operate within same virtual machine or have dedicated VMs. May not use Containers
             - High cohesion, low coupling - "Things that change together should stay together" 
             -  modules expose interface in two ways: Externally, the module offers an API via REST HTTP/GRPC, with API calls managed by a proxy/gateway. internally, services access the module through abstracted interface, without direct access to implementation.
             -  Process of identifying modules, 
                -  Analyze the business problem 
                -  identify subdomains (e.g. for library system, it wud be "book borrowing", "inventory of books"). 
                -  Each subdomain have actor e.g. patron in case of book borrowing. 
                -  Subdomain has bounded context which also defines scope for a module
                -  each bounded context only exposes specific classes to be used by other bounded contexts.  They act as interface of contexts.
           - A modular monolith is a system where all of the code powers a single application and there are strictly enforced boundaries between different domains.
           - Enforce boundaries adhering to Domain driven perspective,
               - Think of Module (or Micro-service) as bounded context
               - It helps with,
                   - No price to be paid for Network and potential associated failures
                   - Rapid development if going with Modular Monolith
                   - Possibility of breaking off a Module and convert it in Micro-service, if needed
                   - being purposeful - Architecture that satisfies business needs.

            - Moving  to  a  service-based  architecture  is  suitable  as  a  final  target  or  as  a  stepping-stone to microservices
              - Allows to determine needed granularity for services
              - Does not require database to be broken apart
              - Does not require operational automation or containerization
              - Technical in nature with no or minimal impact on business stakeholders or IT department

           - Service-based Architecture,  a  distributed  macro-layered  structure  consisting  of   
                 - a  separately  deployed  user  interface
                 - separately  deployed  remote  coarse-grained  services
                 - a  monolithic  database.
           - Services  in  a  service-based  architecture  follow  the  same  principles  a microservices (based on domain-driven design’s bounded context) but rely on a single relational  database  because  the  architects  didn’t  see  value  in  separation  (or  saw  too many negative trade-offs). 
           - services in a  service-based architecture are coarse grained and usually contain the entire domain in  one  deployment  unit  (such  as  order  processing  or  warehouse  management),  and generally have too long of a mean time to startup (MTTS) to respond fast enough to immediate  demand  for  elasticity  due  to  their  large  size  (domain-level  scalability  and fair  MTTS). 
           - Service-based architecture is a hybrid of the microservices architecture style where an application is broken  into  domain  services,  which  are  coarse-grained,  separately  deployed  services containing all of the business logic for a particular domain.
          -  Modular Monolith is a software architecture pattern that strategically combines the simplicity of a monolithic structure with the advantages of microservices. In this approach, the system is organized into loosely coupled modules, each delineating well-defined boundaries and explicit dependencies on other modules.
          -   Characteristics
               - Segregation of modules. Each module is independent with its own layers such as Domain, Infrastructure and API. Modules are autonomously developed, tested, and deployed, affording the flexibility to employ diverse database solutions
               - Modularity with loose coupling and high cohesion. Modules exhibit loose interdependence and strong internal cohesion. Communication between modules occurs through APIs, preferably adopting loosely coupled asynchronous communication patterns
               - Unified Database Schema. The system adheres to a singular database schema, in contrast to microservices, where each microservice necessitates an individual schema
               - Monolithic Deployment Structure. All modules within the modular monolith operate within the same Virtual Machine (VM), or each module may run on dedicated VMs. The scale of modules renders them impractical to be encapsulated within containers
               - General Structure - structure that exposes module interfaces in two ways: Externally, the module offers an API via REST HTTP or GRPC, with API calls managed by a proxy or gateway. Internally, services access the module through an abstracted interface, enabling information retrieval without direct access to the implementation. This upholds a clear separation of concerns, preserving application processes
               - Examples are Service Weaver framework where you write your application as a modular monolith and compile it into a single binary. The Service Weaver runtime then splits the binary and deploys it as a set of distributed services. This programming model enables you to focus on what your code does without worrying so much about where it runs. You can deploy your application across multiple execution environments, locally on your laptop, across a pool of machines via SSH, or in any cloud! Additionally, the Service Weaver runtime can reduce infrastructure costs and improve application latency by several orders of magnitude compared to the status quo.

         - Micro-services (independent deployability)
               - with  microservices,  both  scalability  and  elasticity  are  maximized  because  of  the  small,  single-purpose,  fine-grained  nature  of  each  separately deployed service (function-level scalability and excellent MTTS)
               - Use Tech stacks that meet the requirement
               - shorter time for deployment
               - New components can be deployed without impacting entire system
               - Outage could be limited to a Service 
             - Common topologies
                 - API REST-based topology
                 - Application REST-based topology - client requests are received through traditional web-based or fat-client business application screens rather than through a simple API layer. service components tend to be larger, more coarse-grained, and represent a small portion of the overall business application rather than fine-grained, single-action services. This topology is common for small to medium-sized business applications that have a relatively low degree of complexity.
                 - Centralized messaging topology - instead of using REST for remote access, this topology uses a lightweight centralized message broker.message broker found in this topology does not perform any orchestration, transformation, or complex routing; rather, it is just a lightweight transport to access remote service components.
                 - Typically found in larger business applications or applications requiring more sophisticated control over the transport layer between the user interface and the service components. The benefits of this topology over the simple REST-based topology discussed previously are advanced queuing mechanisms, asynchronous messaging, monitoring, error handling, and better overall load balancing and scalability.

         - An architecture style describes the way your overall system is structured (such as microservices, layered monolith, and so on), whereas architecture patterns are ways of describing certain and specific architectural aspects of that overall structure.

         - Deriving the required architecture characteristics from business needs is the key. Identify "ilities" that are important for org like Scalability, Performance, data integrity, system availability, fault tolerance, Security.


    - Web Application Monitoring
         - Metrics to observe for Web Applications
             - Response Time p50, p90, p99, sum, avg
             - Throughput by HTTP status
             - Worker Utilization
             - Request Queuing Time
             - Service calls
             - Database(s), caches, internal services, third-party APIs, ..
             - Enqueued jobs are important!
             - Circuit Breaker tripping
             - Errors, throughput, latency p50, p90, p99
             - Throttling
             - Cache hits and misses %
             - CPU and Memory Utilization
             - Exception counts

         - Metrics to observe for Web Applications
             - Job Backend (e.g. Sidekiq, Celery, Bull, ..)
             - Job Execution Time p50, p90, p99, sum, avg
             - Throughput by Job Status {error, success, retry}
             - Worker Utilization
             - Time in Queue
             - Queue Sizes
             - Don’t forget scheduled jobs and retries!
             - Service calls p50, p90, p99, count, by type
             - Throttling
             - CPU and Memory Utilization
             - Exception counts
         - Relevant Metrics should be available to slice by endpoint or job,
    tenant_id, app_id, worker_id, zone, hostname, and queue (for jobs).
         - In absense of observability setup, start with logs.
         - Key Non-functional aspects of a Payments System
             - Reliability and fauly tolerance
             - Reconciliation
         - Non relational databases are good for below requirements,
             - Application requires super-low latency
             - Data is unstructured or no relational data
             - Only need to serialize/de-serialize data
             - Store massive amount of data
 
  - Patterns in Distributed Systems
     - Unlike a function call, when you make an RPC, the handler may receive your request multiple times. Implement idempotency. And when you respond to the client, it doesn't necessarily receive your response. They might retry, so idempotency helps again.
     - A message in Queue may be delivered multiple times. The message handler gotta be idempotent. It is generally difficult/rare to implement exactly-once semantics. Usually it is at-least-once.
     - Speaking of retries, you should control the rate of requests you send to your deps, and avoid retry storms. Adaptive client-side throttling might help.
     - Unlike functions in the same process, different services have different availability SLOs. In the code path of your API, don't call another API that didn't promise availability as high as you promised in your API. Same with latency.Try to move such calls out, to background jobs
     - The order of requests sent isn't the same as the order of requests received. Assuming otherwise might lead to races. Enqueued messages may be delivered out of order. Consider putting data-that-might-change into a db, and put only an immutable ref to that data into an SQS message
     - A piece of state you read from another machine/service/database isn't necessarily the same when write it back. This also leads to race conditions. When writing it back, *atomically* verify that state is still the same, via ConditionChecks / transactions.
     - Clocks on different machines may show different times. Don't rely on timestamp comparison if must get it 100% correct. This is another source of race conditions.
     - Most race conditions can be addressed by a synchronization mechanism, and in most distributed systems it is your database that supports atomic condition checks / transactions. It is the arbiter of who wins.
     - Unlike state in a single process, most of the time, you can't make mutations in two systems atomically, e.g. marking a purchase order as placed in the database and sending a confirmation email is not atomic.You might successfully mutate first system, but fail on the second one
     - If your storage system supports Change Data Capture, like @dynamodb, only place the purchase order, and in the background listen to committed changes and send the email there. This assumes that sending the email is idempotent.
     - Without CDC, update the order row and atomically insert another row representing an *intention* to send the email. In the background poll "intention rows" and send the email. Usually this is done in conjunction with a queuing system, so typically the intention is to enqueue a message.
     - RPCs have higher overhead than function calls. Put multiple items in a single request if you expect many items.  But don't put all of them into a single batch because RPCs define limits, and you want consistent latency.
     - When calling a stateful dependency, such as a distributed database, different items in a batch might be processed by different nodes. Minimize the number of nodes involved per batch by sorting items by the sharding key before forming batches.
     - RPCs are often more expensive than local function calls. Make RPCs in parallel.
     - But don't forget to limit number of concurrent outgoing requests though, e.g. to avoid running out of file descriptors.
     - Unlike a single process, deployments in a distributed system aren't atomic. Backward incompatible changes require a multiple deployments, e.g.
         - update service1 to accept both old & new protocols
         - update service2 to use the new protocol
         - remove old code from service1

  - What is "tech stack" in context of Product
     - Customers don't care about how Novel tech stack is
     - Customers want software that delivers problem-solving impact.
     - Set overarching goal and tie technology decisions to it, like
         - Ship the product - Frequently and reliably
         - Support Growth - Be able to bring in more people, gradually that can "Ship the product"
         - Specific goals
             - No sacred bits: Launch, learn, iterate.
             - Today’s bets over tomorrow’s theoreticals.
             - Favor “boring technology” and in-house expertise.
             - Buy non-core competencies whenever prudent.

    - Things to consider in software engineering 
         - I don't know - The reason many of us love software is because we   are lifelong learners, and in software no matter which direction you   look, there are wide vistas of knowledge going off in every direction     and expanding by the day. This means that you can spend decades in your     career, and still have a huge knowledge gap compared to someone who has also spent decades in a seemingly similar role. The sooner you realize     this, the sooner you can start to shed your imposter syndrome and     instead delight in learning from and teaching others.
         - The hardest part is building the right thing - Due to Complexity and irrationality of the environments. Designing software is mostly a     listening activity, and we often have to be part software engineer, part     psychic, and part anthropologist. Investing in this design process,     whether through dedicated UX team members or by simply educating yourself, will deliver enormous dividends.
         - Think like Designers - Concentrate on User experience of the Code. Be it API, UI ; consider who will be using it , why and how it     will be used and what is important to the users.
         - the best code is no code or the one you don't have to maintain
         - The primary job of software engineer is delivering value
         - Maintain balance between research and getting started with     implementation
         - be wary of people designing systems who haven't written code in     long time. keep up with developer ecosystem.
         - Worry less about elegance and perfection; instead strive for continuous improvement and creating a livable system that your team enjoys working in and sustainably delivers value.
         - keep asking questions about assumptions and approaches even if they sound dumb.
         - Avoid programmers who wastes time, doesn’t ask for feedback, doesn’t test their code, doesn’t consider edge cases.
         - As a senior, you must have opinion about way things should be. Best way to levelling up for this is explore other languages, libraries, and paradigms
         - People expect cheap wins and novelty under the pretext of "Innovation"
         - Strive to keep data in clean and orderly fashion as it is likely to outlive code
         - Dont bet against older technologies and replace them only if there is good reason for it (e.g. inherent Limitations)
         -  Never assume that just because someone isn’t throwing their opinions in your face that they don’t have anything to add.
         -  regularly blog, journal, write documentation and in general do    anything that requires them to keep their written communication skills sharp
         - Stay lean on process until you know you need more
         - Remember team need to feel ownership for them to deliver
         - Always strive to build a smaller system
           - Don’t fight the tools: libraries, language, platform, etc. Use as much native constructs as possible. Don’t bend the technology,   but don’t bend the problem either. Pick the right tool for the job or   you’ll have to find the right job for the tool you got.
           - You don’t write the code for the machines, you write it for your colleagues and your future self (unless it’s a throw away project   or you’re writing assembly). Write it for the junior ones as a reference.
           - Any significant and rewarding piece of software is the result   of collaboration. Communicate effectively and collaborate openly. Trust   others and earn their trust. Respect people more than code. Lead by   example. Convert your followers to leaders.
           - Divide and conquer. Write isolated modules with separate   concerns which are loosely coupled. Test each part separately and   together. Keep the tests close to reality but test the edge cases too.        
           - Deprecate yourself. Don’t be the go-to person for the code. Optimize it for people to find their way fixing bugs and adding features   to the code. Free yourself to move on to the next project/company. Don’t   own the code or you’ll never grow beyond that.
           -    Security comes in layers: each layer needs to be assessed   individually but also in relation to the whole. Risk is a business   decision and has direct relation to vulnerability and probability. Each   product/organization has a different risk appetite (the risk they are willing to take for a bigger win). Often these 3 concerns fight with each other: UX, Security, Performance.
           -    Realize that every code has a life cycle and will die.   Sometimes it dies in its infancy before seeing the light of production.  Be OK with letting go. Know the difference between 4 categories of   features and where to put your time and energy: Core: like an engine in      a car. The product is meaningless without it. Necessary: like a car’s   spare wheel. It’s rarely used but when needed, its function decides the   success of the system. Added value: like a car’s cup-holder. It’s nice   to have but the product is perfectly usable without it. Unique Selling   Point: the main reason people should buy your product instead of your   rivals. For example, your car is the best off-road vehicle.
           -    Don’t attach your identity to your code. Don’t attach   anyone’s identity to their code. Realize that people are separate from   the artifacts they produce. Don’t take code criticism personally but be   very careful when criticizing others’ code.
           -    Tech debt is like fast food. Occasionally it’s acceptable but   if you get used to it, it’ll kill the product faster than you think (and   in a painful way).
           -    When making decisions about the solution all things equal,  go for this priority:But don’t follow that blindly because it is dependent on the nature of the product. Like any career, the more experience you earn, the more you can find the right balance for each given situation. For example,
      when designing a game engine, performance has the highest priority, but when creating a banking app, security is the most important factor.
           -    Bugs’ genitals are called copy & paste. That’s how they
      reproduce. Always read what you copy, always audit what you import. Bugs
      take shelter in complexity. “Magic” is fine in my dependency but not in
      my code.
           -    Don’t only write code for the happy scenario. Write good
      errors that answer why it happened, how it was detected and what can be
      done to resolve it. Validate all system input (including user input):
      fail early but recover from errors whenever possible. Assume the user
      hold a gun: put enough effort into your errors to convince them to shoot
      something other than your head!
           -    Don’t use dependencies unless the cost of importing,
      maintaining, dealing with their edge cases/bugs and refactoring when
      they don’t satisfy the needs is significantly less than the code that
      you own.
           -    Stay clear from hype-driven development. But learn all you
      can. Always have pet projects.
           -    Get out of your comfort zone. Learn every day. Teach what
      you learn. If you’re the master, you’re not learning. Expose yourself to
      other languages, technologies, culture and stay curious.
           -    Good code doesn’t need documentation, great code is well
      documented so that anyone who hasn’t been part of the evolution, trial &
      error process and requirements that led to the current status can be
      productive with it. An undocumented feature is a non-existing feature. A
      non-existing feature shouldn’t have code.
           -    Avoid overriding, inheritance and implicit smartness as much as possible. Write pure functions. They are easier to test and reason about. Any function that’s not pure should be a class. Any code construct that has a different function, should have a different name.
           -    Never start coding (making a solution) unless you fully understand the problem. It’s very normal to spend more time listening and reading than typing code. Understand the domain before starting to code. A problem is like a maze. You need to progressively go through the code-test-improve cycle and explore the problem space till you reach the end.
           -    Don’t solve a problem that doesn’t exist. Don’t do speculative programming. Only make the code extensible if it is a validated assumption that it’ll be extended. Chances are by the time it gets extended, the problem definition looks different from when you wrote the code. Don’t overengineer: focus on solving the problem at hand and an effective solution implemented in an efficient manner.
           -    Software is more fun when it’s made together. Build a sustainable community. Listen. Inspire. Learn. Share.

     - Software Architecture cannot be created in a vacuum and solid technical foundation is not enough.
     - Non-technical and cultural implications of the technology are important i.e. receptivity, speed to market and long term maintenance.
     - Impact on Team
         - Is it easy for them to learn?
         - Are they enthusiastic
     - External Attractiveness (from New Hire perspective)
     - Effective communication
     - Time to market
         - Trade off between idealism vs pragmatism
     - Long term Maintenance
         - Cost of Maintenance in terms of
             - Testing difficulties
                 - Efficiency of QA Team is critical for Software product/application
             - Employee attrition
                 - What specific skills and domain knowledge will your design require, and how much value would be lost if one of your employees were to leave?
                 - the more your own developers build; the more you will depend on them.
             - Flexibility
                 - The more vendor agnostic your design is, the more easily you will be able to avoid getting stuck  on an outdated platform and more quickly you'll be able to upgrade or pivot your underlying infrastructure as technology changes.

  - Architectural thinking
     - Don’t even start considering solutions until you Understand the problem. Your goal should be to “solve” the problem mostly within the problem domain, not the solution domain.
     - enumerate multiple candidate solutions. Don’t just start prodding at your favorite!
     - Consider a candidate solution, then read the Paper if there is one.
     - Determine the Historical context in which the candidate solution was designed or developed.
     - Weigh Advantages against disadvantages. Determine what was de-prioritized to achieve what was prioritized.
     - Think! Soberly and humbly ponder how well this solution fits your problem. What fact would need to be different for you to change your mind? For instance, how much smaller would the data need to be before you’d elect not to use Hadoop?
     - Every thing in Software Architecture is a trade off
     - The top 3 soft skills for any software architect are negotiation, facilitation, and leadership. Negotiation is a required skill as an architect because almost every decision you make as an architect will be challenged. Your decisions will be challenged by other architects who think they have a better approach than you do; your decisions will be challenged by business stakeholders because they think your decision takes too long to implement or is too expensive or is not aligned with the business goals; and finally, your decisions will be challenged by development teams who believe they have a better solution. All of this requires an architect to understand the political climate of the enterprise and how to navigate the politics to get your decisions approved and accepted.
     - Facilitation is another necessary soft skill as a software architect. Architects not only collaborate with development teams, but also collaborate closely with various business stakeholders to understand business drivers, explain important architecture characteristics, describe architectural solutions, and so on. All of these gatherings and meetings require a keen sense of facilitation and leadership within these meetings to keep things on track.
     - Finally, leadership is another important soft skill because an architect is responsible for leading and guiding a development team through the implementation of an architecture. They are there as a guide, mentor, coach, and facilitator to make sure the team is on track and is running as smooth as a well-oiled machine, and to be there when the team needs clarification or has questions and concerns about the architecture.
     - the role of an architect is to measure and analyze these trade-offs but not necessarily make the decision, but to bring these trade-offs to a product partner, somebody on the product team, to be able to understand these particular forces and which is more important, that we are able to better scale or have better data consistency

     - Avoiding Snake Oil and Evangelism
         - One unfortunate side effect of enthusiasm for technology is evangelism, which should be a luxury reserved for tech leads and developers but tends to get architects in trouble.
         - Trouble comes because, when someone evangelizes a tool,technique, approach, or anything else people build enthusiasm for, they start enhancing the good parts and diminishing the bad parts. Unfortunately, in software architecture, the trade-offs always eventually return to complicate thin
         - An architect should also be wary of any tool or technique that promises any shocking new capabilities, which come and go on a regular basis.
         - Always force evangelists for the tool or technique to provide an honest assessment of the good and bad. Nothing in software architecture is all good—which allows a more balanced decision
         - solutions in architecture rarely scale outside narrow confines of a particular problem space
         - Don’t allow others to force you into evangelizing something; bring it back to trade-offs.
         - We advise architects to avoid evangelizing and to try to become the objective arbiter of trade-offs. An architect adds real value to an organization not by chasing silver bullet after silver bullet but rather by honing their skills at analyzing the trade-offs as they appear.
         -  Don't adopt a new system unless you can make the first-principle argument for why your current stack fundamentally can't handle it.
         - Whenever you find yourself arguing for improving infrastructure by yanking up complexity, you need to be very careful.
         - Typical issues while adopting new technologies are,
           - Slower performance (hard to debug)
           - Scalability issues (because you don't know the system well)
           - Complexity may lead to more downtime
         - Stop thinking about technologies, and start thinking in first-principle requirements (the idea is to break down complicated problems into basic elements and then reassemble them from the ground up),
         - How you choose to develop, deploy, and manage services will always be driven by the product you’re designing, the skillset of the team building it, and the experience you want to deliver to customers (and of course things like cost, speed, and resiliency).
         - In case of databases, it could be,
             - You need faster inserts/updates (i.e. Not Synching every write to disk immediately which can be done in Mysql using  flush log settings and in postgresql using Asynchronous commits
             - You need terabytes of storage to have runway for the next ~5 years
             - You need more read capacity (i.e. use Read Replicas)

      - Cloud Computing
         - Cloud computing is the on-demand delivery of IT resources with    primarily pay-as-you-go pricing.
         - Four aspects you need to consider when deciding which AWS Region    to use, compliance, latency, price, and service availability.
             - Latency - If your application is sensitive to latency (the    delay between a request for data and the response), choose a Region that    is close to your user base. This helps prevent long wait times for your    customers. Synchronous applications such as gaming, telephony,    WebSockets, and Internet of Things (IoT) are significantly affected by high latency. Asynchronous workloads, such as ecommerce applications,     can also suffer from user connectivity delays.
             - Price - Due to the local economy and the physical nature of     operating data centers, prices vary from one Region to another. Internet     connectivity, imported equipment costs, customs, real estate, and other     factors impact a Region's pricing. Instead of charging a flat rate     worldwide, AWS charges based on the financial factors specific to each     Region.
             - Service Availability - Some services might not be available    in some Regions. The AWS documentation provides a table that shows the     services available in each Region.
             - Data Compliance - Enterprise companies often must comply with    regulations that require customer data to be stored in a specific     geographic territory. If applicable, choose a Region that meets your     compliance requirements.
         - Each region has Availability zones (AZ) and each AZ has one or     more data centers.
         - Each AWS Service is scoped at Global or Region or AZ (With these     services, you are often responsible for increasing the data durability     and high availability of these resources) level.
         - For high availability and resiliency, At a minimum, you should     use two Availability Zones.
            - 99.5% ( Two and half-nines) uptime which means weekly downtime     of 50 minutes is reasonably achievable without excessive costs.
            - AWS guarantees 99.99% uptime for application deployed in     redundancy mode across availability zones. Single Machine instances on     EC2 only have 99.5% guarantee
            -  Each layer of the system needs to have  a higher reliability,     in isolation, than the final uptime you're aiming for, because error     rates are cumulative.

      - Case for Cloud vs. On-prem
         - Bursty Workload ( If your workload goes through long periods of idleness punctuated with large unpredictable bursts of activity) is good case for a cloud based architecture
         - Using CDN is a good use of Cloud infrastructure
         - Today's servers are highly capable and scaling vertically is easy. Once limit of the server is reached then go for sharding and horizontal scaling or use cloud architecture that gives horizontal scaling for "free".
         - Using one big server is comparatively cheap, keeps your overheads at a minimum, and actually has a pretty good availability story if you are careful to prevent correlated hardware failures. It’s not glamorous and it won’t help your resume, but one big server will serve you well.
         - On-premise is generally less vulnerable to price increase, data leakage or external security threats (assuming internal security is mature.)
         - If the ratio of annual perpetual license is more than 2x of cloud subscription rate then cloud is attractive else it is on-premise that scores.
         - Cost control and Governance are key when deciding about cloud vs. on-prem.
         - If an organization has high confidence in the capacity of internal IT resources and high confidence in their ability to deliver necessary results, then the On-Premise cost structure can be expected to save money over the longer term when compared to Cloud. If, instead, the convenience and flexibility of Cloud is sought, with the extra hand-holding for upgrades and guidance services, and the operating budget can afford an ongoing multi-year Cloud subscription, then relying on the external centralized hosted solution could be more compelling.

      - Sizing, Availability 
         - Suppose it takes a week (168 hours) to repair the capacity and the MTBF is 100,000 hours. There is a 168/1; 000; 000 * 100 = 1.7 percent, or 1 in 60, chance of a second failure. Now suppose the MTBF is two weeks (336 hours). In this case, there is a 168/336   100 = 50 percent, or 1 in 2, chance of a second failure—the same as a coin flip. Adding an additional replica becomes prudent. MTTR is a function of a number of factors. A process that dies and needs to be restarted has a very fast MTTR.If all this math makes your head spin, here is a simple rule of thumb: N+1 is a minimum for a service; N+2 is needed if a second outage is likely while you are fixing the first one.
         - If we are load balancing over two machines, each at 40 percent utilization, then either machine can die and the remaining machines will be 80 percent utilized. In such a case, the load balancer is used for resiliency.
         - If we are load balancing over two machines, each at 80 percent   utilization, then there is no spare capacity available if one goes down.   If one machine died, the remaining replica would receive all the  traffic, which is 160 percent of what the machine can handle. The   machine will be overloaded and may cease to function. Two machines each   at 80 percent utilization represents an N+0 configuration. In this situation, the load balancer is used for scale, not resiliency.
         - in a 1+1 redundant system, 50 percent of the capacity is spare. In a 20+1 redundant system, less than 5 percent of the capacity is spare. The latter is more cost-efficient.
         - Mean time between failures (MTBF) - The MTBF of the system is only as high as that of its lowest-MTBF part.
         - The time it takes to repair or replace the down capacity is called the mean time to repair (MTTR).
         - The probability of second failure happening during repair window is MTTR/MTBF * 100
         - If we are load balancing over two machines, each at 40 percent utilization, then either machine can die and the remaining machines will be 80 percent utilized. In such a case, the load balancer is used for resiliency.A load balancer provides scale when we use it to keep up with capacity, and resiliency when we use it to exceed capacity.

     - Scalability
         - Drawbacks of Scale Up
           - there are limits to system size. The fastest, largest, most powerful computer available may not be sufficient for the task at hand. No one computer can store the entire corpus of a web search engine or has the CPU power to process petabyte-scale datasets or respond to millions of HTTP queries per second. There are limits as to what is available on the market today.
         - this approach is not economical. A machine that is twice as fast costs more than twice as much. Such machines are not sold very often and, therefore, are not mass produced. You pay a premium when buying the latest CPU, disk drives, and other components.
         - scaling up simply won’t work in all situations.
             - Buying a faster, more powerful machine without changing the design of the software being used usually won’t result in proportionally faster throughput.
             - Software that is single-threaded will not run faster on a machine with multiple processors.
             - Software that is written to spread across all processors may not see much performance improvement beyond a certain number of CPUs due to bottlenecks such as lock contention.
         - Some Scaling techniques,
             - Segment plus Replicas: Segments that are being accessed more frequently can be replicated at a greater depth. This enables scaling to larger datasets (more segments) and better performance (more replicas of a segment).
             - Dynamic Replicas: Replicas are added and removed dynamically to achieve required performance. If latency is too high, add replicas. If utilization is too low, remove replicas.
             -  Architectural Change: Replicas are moved to faster or slower technology based on need. Infrequently accessed shards are moved to slower, less expensive technology such as disk. Shards in higher demand are moved to faster technology such as solid-state drives (SSD). Extremely old segments might be archived to tape or optical disk.
         - Cache
             - The Least Recently Used (LRU) algorithm tracks when each cache entry was used and discards the least recently accessed entry
             - The Least Frequently Used (LFU) algorithm counts the number of times a cache entry is accessed and discards the least active entries
         - Data Sharding is a way to segment the database that is flexible, scalable and resilient. A hash function is algorithm that maps data of varying length to a fixed length value.
           - Distributed hash table pattern involves generating hash of the key and allocating data as per hash value like,
             - Odd or even or power of 2 (i.e. 2(n) where n is last n bits of hash) -- For 2 shards
             - reminder of hash divided by 4 - for 4 shards

    - Kubernetes
       - A Pod is an environment for multiple containers to run inside. The pod is the smallest deployable unit you can ask Kubernetes to run and all containers in it will be launched on the same node. A pod has its own IP address, can mount in storage, and its namespaces surround the containers created by the container runtime such as containerd or CRI-O.
       - pod is a single instance of your application, and to scale to demand, many identical pods are used to replicate the application by a workload resource (such as a Deployment, DaemonSet, or StatefulSet). Your pods may include sidecar containers supporting monitoring, network, and security, and “init” containers for pod bootstrap, enabling you to deploy different application styles. These sidecars are likely to have elevated privileges and be of interest to an adversary.
       - The lifecycle of a pod is controlled by the kubelet, the Kubernetes API server’s deputy, deployed on each node in the cluster to manage and run containers. If the kubelet loses contact with the API server, it will continue to manage its workloads, restarting them if necessary. If the kubelet crashes, the container manager will also keep containers running in case they crash. The kubelet and container manager oversee your workloads.

    - Container Strategy
         - Containers are an application packaging format that help developers and organizations to develop, ship, and run applications
         - Why?
             - they effectively bundle applications, related libraries, dependencies, and configurations in a package that can be deployed across multiple environments
             - ease reproducibility and reliability of build-time and run-time software environments
             - consistently build and run containers on a variety of host environments (e.g., different OSes / different Linux distributions).
             - lighter than virtual machines, allowing efficient use of hardware and creating higher utilization of existing hardware.
             - provide a system for isolating processes and data without the full virtualization of the whole operating system.

         - Why not?
             - not optimized for monolithic applications, which can be expensive to rewrite or convert into microservices.

         - Plan for Operationalization process
             - Education, training and planning can significantly reduce development time and transition risk. Container-focused deployments can be subtly different from bare-metal or virtual machine focused deployments.
             - Pursue best practices such as good base image selection, container hierarchies, dependency version management, package selection minimalism, layer management practices, cache cleaning, reproducibility,and documentation.
             -  Images should be rebuilt cleanly on a periodic basis incorporating vetted versions, patches and updates. Teams should frequently remove unnecessary or disused packages and assets as part of their maintenance process, test changes, and redeploy.
             - Containers are not inherently secure; Container hardening should be integrated into the build process well before deployment. Thinking about security considerations proactively and early can help reduce risk. Scanning individual images for potential vulnerabilities is and should be a standard practice in any new environment.
             - having a strong organizational capability to plan, organize, and deploy incremental system changes is critical to any change while maintaining continuity of operations
             - Orchestrating containers is the best way to accomplish complex tasks.Kubernetes, a popular orchestrator, can be provided by many cloud vendors as well as on-premise infrastructure software vendors such as VMWare or Red Hat. The cost and maintenance of these infrastructures should be heavily weighed.
             - Individuals’ behaviors are guided (implicitly or explicitly) by underlying structures. Adoption must start with a purpose, whether that is a service or part of a larger project. Investment is needed during spin up to ensure proper experience is gained by project members. The chosen project must also have a clearly defined success metric.


    - Observability
        - Observability really is about the ability of a particular service to expose or export its information, its telemetry. It could be about response time, error rates, amount of messages processed in one hour.
 
        - Observability means gaining visibility into the internal state of a system. It’s used to give users the tools to figure out what’s happening, where it’s happening, and why. Observability has three core components: monitoring, analytics, and forensics. Monitoring measures the health of a system - it tells you when something is going wrong. Analytics give you the tools to visualize data to identify patterns and insights. Forensics helps you answer very specific questions about an event.
          - Higher the SLA/SLO requirements for Service, Higher the Need for Observability
         - Structured log events with rich context specific details (often maintained as key-value pair) are highly useful where aim of observability  is for swiftly identifying where in your system the error or problem is coming from, so you can debug it — by reproducing it, or seeing what it has in common with other erroring requests.
         - The rule is to have one observability event per request per service hop (example, if your request hit the edge, API, four internal services, two databases … but ran 1 query on one db and 10 queries on the second db … you would generate a total of *19 observability events* for this request where all of them are linked by randomly generated "Request ID".)
         - Structure events are richer than metrics due to its payload.
         - Think about the data you need while debugging the issue.
         - Request id must be unique and sequence of these events should be preserved.
         - only gather observability events from services that we can and do introspect
         - Each event should be dense all the useful context like,
             - Metadata like src, dst headers
             - The timing stats and contents of every network call (our beelines wrap all outgoing http calls and db queries automatically)
             - Every raw db query, normalized query family, execution time etc
             - Infra details like AZ, instance type, provider
             - Language/environment context like $lang version, build flags, $ENV variables
             - Any and all unique identifying bits you can get your grubby little paws on — request ID, shopping cart ID, user ID, request ID, transaction ID, any other ID … these are always the highest value data for debugging.
             - Any other useful application context.  Service name, build id, ordering info, error rates, cache hit rate, counters, whatever.
             - Possibly the system resource state at this point in time. e.g. values from /proc/net/ipv4 stats
         - pretty metrics and dashboards and aggregates from structured events
         - Event storage - How long and which,
             - Events must be sampled and some rules are,
             -  health checks that return 200 OK usually represent a significant chunk of your traffic and are basically useless, while 500s are almost always interesting
             -  Types of Health Checks:
                    Liveness Checks: Basic checks (e.g., listening on a port, responding to HTTP 200) that don't require application-specific knowledge.
                    Local Health Checks: Go deeper to verify application function, testing resources not shared with peers (e.g., disk I/O, critical process health, missing support processes). Less likely to cause fleet-wide failures.
                    Dependency Health Checks: Test interaction with adjacent systems. Prone to false positives when the dependency itself has issues.
                    Anomaly Detection: Compares server behavior to peers (e.g., clock skew, outdated code) to find outliers that individual servers might miss.
             - all requests to /login or /payment endpoints
             -  For database traffic: SELECTs for health checks are useless, DELETEs and all other mutations are rare but you should keep all of them.
             - Latency - The time it takes to service a request. It’s important to distinguish between the latency of successful requests and the latency of failed requests. For example, an HTTP 500 error triggered due to loss of connection to a database or other critical backend might be served very quickly; however, as an HTTP 500 error indicates a failed request, factoring 500s into your overall latency might result in misleading calculations. On the other hand, a slow error is even worse than a fast error! Therefore, it’s important to track error latency, as opposed to just filtering out errors.
             - Traffic - A measure of how much demand is being placed on your system, measured in a high-level system-specific metric. For a web service, this measurement is usually HTTP requests per second, perhaps broken out by the nature of the requests (e.g., static versus dynamic content). For an audio streaming system, this measurement might focus on network I/O rate or concurrent sessions. For a key-value storage system, this measurement might be transactions and retrievals per second.
             - Errors - The rate of requests that fail, either explicitly (e.g., HTTP 500s), implicitly (for example, an HTTP 200 success response, but coupled with the wrong content), or by policy (for example, "If you committed to one-second response times, any request over one second is an error"). Where protocol response codes are insufficient to express all failure conditions, secondary (internal) protocols may be necessary to track partial failure modes. Monitoring these cases can be drastically different: catching HTTP 500s at your load balancer can do a decent job of catching all completely failed requests, while only end-to-end system tests can detect that you’re serving the wrong content.
             - Saturation - How "full" your service is. A measure of your system fraction, emphasizing the resources that are most constrained (e.g., in a memory-constrained system, show memory; in an I/O-constrained system, show I/O). Note that many systems degrade in performance before they achieve 100% utilization, so having a utilization target is essential.In complex systems, saturation can be supplemented with higher-level load measurement: can your service properly handle double the traffic, handle only 10% more traffic, or handle even less traffic than it currently receives? For very simple services that have no parameters that alter the complexity of the request (e.g., "Give me a nonce" or "I need a globally unique monotonic integer") that rarely change configuration, a static value from a load test might be adequate. As discussed in the previous paragraph, however,most services need to use indirect signals like CPU utilization or network bandwidth that have a known upper bound. Latency increases are often a leading indicator of saturation. Measuring your 99th percentile response time over some small window (e.g., one minute) can give a yearly signal of saturation.Finally, saturation is also concerned with predictions of impending saturation, such as "It looks like your database will fill its hard drive in 4 hours."


      - Easier ways of doing things
           - SSL certificates, with Let’s Encrypt
           - Concurrency, with async/await (in several languages)
           - Centering in CSS, with flexbox/grid
           - Building fast programs, with Go
           - Image recognition, with transfer learning (someone pointed out
      that the joke in this XKCD doesn’t make sense anymore)
           - Building cross-platform GUIs, with Electron
           - VPNs, with Wireguard
           - Running your own code inside the Linux kernel, with eBPF
           - Cross-compilation (Go and Rust ship with cross-compilation
      support out of the box)
           - Configuring cloud infrastructure, with Terraform
           - Setting up a dev environment, with Docker
           - Sharing memory safely with threads, with Rust
           - Easier using hosted services
           - CI/CD, with GitHub Actions/CircleCI/GitLab etc
           - Making useful websites by only writing frontend code, with a
      variety of “serverless” backend services
           - Training neural networks, with Colab
           - Deploying a website to a server, with Netlify/Heroku etc
           - Running a database, with hosted services like RDS
           - Realtime web applications, with Firebase
           - Image recognition, with hosted ML services like Teachable Machine
           - Cryptography, with opinionated crypto primitives like libsodium
           - Live updates to web pages pushed by the web server, with
      LiveView/Hotwire
           - Embedded programming, with MicroPython
           - Building videogames, with Roblox / Unity
           - Writing code that runs on GPU in the browser (maybe with Unity?)
           - Building IDE tooling with LSP (the language server protocol)
           - Interactive theorem provers (not sure with what)
           - NLP, with HuggingFace
           - Parsing, with PEG or parser combinator libraries
           - ESP microcontrollers
           - Batch data processing, with Spark


    - Data Architecture

        - Database Workloads
             - OLTP
                 - Characterstics,
                     - Inserts, updates, and deletes only affect a single row. An example: Adding an item to a user’s shopping cart.
                     - Read operations only read a handful of items from the
        database. An example: listing the items in a shopping cart for a user.
                     - Aggregations are used rarely, and when they are used they
        are only used on small sets of data. Example: getting the total price of
        all items in a user their shopping cart.
                 - Relevant benchmarks
                     - Throughput in TPS (transactions per second)
                     - Query latency, usually at different percentiles (p95, etc.)
             - OLAP
                 - Characteristics,
                     - Periodic batch inserts of data.
                     - Read operations often read large parts of the database.
                     - Aggregations are used in almost every query.
                     - Queries are large and complex.
                     - Not a lot of concurrent users
                 - Relevant benchmarks
                     - How long it took to run all of the queries that are part
        of the benchmark
                     - How long it took to run each of the queries, measured
        separately per query
             - HTAP (Hybrid transactional/analytical processing)
                 - Combines characteristics from OLTP and OLAP
             - Important questions while benchmarking
                 - Is it running on production infrastructure? A lot more
        performance can usually be achieved when critical production features
        have been disabled. Things like backups, High Availability (HA) or
        security features (like TLS) can all impact performance.
                 - How big is the dataset that was used? Does it fit in RAM or
        not? Reading from disk is much slower than reading from RAM. So, it
        matters a lot for the results of a benchmark if all the data fits in RAM.
                 - Is the hardware excessively expensive? Obviously a database
        that costs $500 per month is expected to perform worse than one that
        costs $50,000 per month.
                 - What benchmark implementation was used? Many vendors publish
        results of a TPC benchmark specification, where the benchmark was run
        using a custom implementation of the spec. These implementations have
        often not been validated and thus might not implement the specification
        correctly.

      - PostgreSQL Connection Pool size 
         - If a server is provisioned with 128 cores. With hyperthreading on, it can handle 256 processes. EDB expects factor of 4 to be acceptable while setting max_connections parameter. 
         - Connection pooler (e.g. pgbouncer) allows thousands of clients/application connections to share a relatively small pool of database sessions
         - A connection pooler is a vital part of any high-throughput databasesystem, as it eliminates connection overhead and reserves larger portions
      of memory and CPU time to a smaller set of database connection,
      preventing unwanted resource contention and performace degradation.
           - Formula
               pool size = min(num_cores,
      max_parallel_ios)/active_Factor*Parallelism
           - Determining Active Factor
               - PostgreSQL 14,
                   - easy with the new session statistics in PostgreSQL v14:
                           SELECT active_time / (active_time +
      idle_in_transaction_time)
                           FROM pg_stat_database
                           WHERE datname = 'mydb'
                           AND active_time > 0
               - Alternate way
                   - for a coarse estimate, query pg_stat_activity several
      times and use  an average:
                           SELECT (count(*) FILTER (WHERE state =
      'active'))::float8
                           / count(*) FILTER (WHERE state in
                           ('active', 'idle in transaction'))
                           FROM pg_stat_activity
                           WHERE datname = 'mydb';
           - “num_cores” is the number of CPU cores
           - “max_parallel_ios” is the upper limit of concurrent I/O requests
      that the disk can handle
            - “parallelism” is the average number of server processes used for
      a single SQL statement


     - Best practices for Data Ingestion
         - Write down all of the most important connectors for your business, the skills and time your team has to offer, and your budget when deciding on the right ingestion tool.
         - Document all of your data sources and how they are being ingested into your data warehouse, including any special setup.
         - Always keep a database with your raw, untouched data.
         - Run data syncs and models synchronously so there are no gaps in data.
         - Create alerts at the data sources rather than downstream data models.

     - Parameters to evaluate Data Ingestion tool
         - Data connectors available (Shopify, Azure Blob, Facebook,NetSuite, etc.)
         - Capabilities of your team (time to set-up, time to maintain, skillset, etc.)
         - Budget (monthly costs to ingest expected volume of data)
         - Support (Slack communities, dedicated support agents, etc.)

     - Data Lake,
        - Operational data - Data  used  for  the  operation  of  the  business,  including  sales,  transactional  data,inventory, and so on. This data is what the company runs on—if something inter‐rupts this data, the organization cannot function for very long. This type of data is  defined  as  Online  Transactional  Processing  (OLTP),  which  typically  involves inserting, updating, and deleting data in a database.

        - Analytical data - Data used by data scientists and other business analysts for predictions, trending,and other business intelligence. This data is typically not transactional and often not  relational—it  may  be  in  a  graph  database  or  snapshots  in  a  different  format than  its  original  transactional  form.  This  data  isn’t  critical  for  the  day-to-day operation but rather for the long-term strategic direction and decisions

         - Basically, its cheap storage area where data is just dumped from sources like OLTP systems, Other Applications, logs etc.
         - Alternate Explanation : A data lake is a storage system with an underlying Data Lake File Format and its different Data Lake Table Formats that store vast amounts of unstructured and semi-structured data, stored as-is, without a specific purpose. Its the primary destination for growing volumes and varieties of exploratory and operational data next to data warehouse destinations.
         - From here, Subset of the data is moved to classical data warehouse (typically on cloud) for analytics or gaining insights
         - Reasons are,
             - In the Sources to DWH approach, one has to have schema up-front which is hard to get right at the beginning. Data lake to DWH provides flexibility in this.
             - With a data lake, data becomes increasingly available, and early adopters discovered that they could extract insight through new applications built to serve the business.
             - The data lake supports capturing and storing raw data at scale for a low cost with many different types of data.
         - A structural transaction layer is built on top of it
         - with lake-house pattern, BI tool can query data lake directly without the need to have DWH or transactional layer in between.
         - Components of Data Lake
             - Storage Layer - Typically object storage service is used (e.g. S3)
             - Data lake file formats -  that mainly compresses the data for either row or column-oriented writing or querying. E.g. Apache Parquet, Apache Avro , Apache Arrow. These formats provide features such as split ability and schema evolution (adding new columns without breaking anything or even enlarging some types).
             - Apache Arrow - In memory, Columnar Data format.
             - Data lake table formats sit on top of these file formats to provide robust features. data lake table format bundles distributed files into one table that is otherwise hard to manage.They allow to efficiently query your data directly out of your data lake. They lack support for ACID transactions and support for ANSI SQL. Some of the data formats are Delta lake, Apache Iceberg, Apache Hudi.
                 - Delta lake is open source layer that uses parquet for storage with Apache Spark. It supports automated partitioning
     - Streaming
         - All the ETL use cases are potentially candidates for streaming

     - A data warehouse is a relational database in which the data is tored in a schema that is optimized for data analytics rather than transactional workloads. Commonly, the data from a transactional store is de-normalized into a schema in which numeric values are stored in central fact tables, which are related to one or more dimension tables that represent entities by which the data can be aggregated. For example a fact table might contain sales order data, which can be aggregated by customer, product, store, and time dimensions (enabling you, for example, to easily find monthly total sales revenue by product for each store). This kind of fact and dimension table schema is called a star schema; though it's often extended into a snowflake schema by adding additional tables related to the dimension tables to represent dimensional hierarchies (for example, product might be related to product categories). A data warehouse is a great choice when you have transactional data that can be organized into a structured schema of tables, and you want to use SQL to query them.
         - Star schema
             - Fact table - 1 table usually. Typically very large. Updated frequently and usually append only. They reference dimension tables.
                 - Examples - Sales transactions, Course enrollments, Page views
             - Dimension table - Many tables. Infrequent updates. Not very large.
                 - Examples - Stores, items, Customers, Students, Courses.
             - Typical Query Flow over Star Schema - Join ==> Filter ==> Group ==> Aggregate
             - Extensive use of Materialized Views.
             - Data cube (a.k.a. multidimensional OLAP)
                 - Dimension tables form axes while fact data in cells.
         - Dimension Modelling Process
             - Choose the business process e.g. track monthly revenue
             - Declare the grain e.g. per customer
             - Identify the dimensions (Context, e groups of hierarchies and descriptors that define the facts)
             - Identify the fact (measures, numeric values that can be aggregated)
             - PREP TABLES: prep_<subject> = Used to clean raw data and prepare it for dimensional analysis.
             - FACT TABLES: fct_<verb> Facts represent events or real-world processes that occur. Facts can often be identified because they represent the action or 'verb'. (e.g. session, transaction)
                 - All fact tables must have a primary key. The Primary Key can be either a single column using a column(surrogate key), a column(natural key), or set of columns(composite key) that have meaning to the business user and uniquely identifies a row in a table. The primary key should be the first column in the fact table.
                 - All fact tables should have a foreign key section
                 - Atomic Facts are the things being measured in a process. The terms measurement or metric are often used instead of fact to describe what is happening in the model. The Atomic Facts are modeled at the lowest level of the process they are measuring. They do not filter out any data and include all the rows that have been generated from the process the Atomic Fact table is describing.
                 - Derived Facts Derived Facts are built on top of the Atomic Facts. The Derived Fact directly references the Atomic Fact thereby creating an auditable, traceable lineage.
             - DIMENSION TABLES: Dimensions provide descriptive context to the fact records. Dimensions
            can often be identified because they are 'nouns' such as a person, place, or thing (e.g. customer, employee) The dimension attributes act as 'adjectives'. (e.g. customer type, employee division)
                  - All dimensions must have a surrogate key. The hashed surrogate key is a type of primary key that uniquely identifies each record in a model.
                  - All dimensions must have a natural key.A natural key is a type of primary key that uniquely identifies each record in a model. The natural key is fetched from the source system application.A  natural key can be a single field key value or the key value can be composed from multiple columns to generate uniqueness.
                  - All dimensions must have a missing member value.
            - MART TABLES: mart_<subject> = Join dimension and fact tables together with minimal filters and aggregations. Because they have minimal filters and aggregations, mart tables can be used for a wide variety of reporting purposes.
                  - Marts are a combination of dimensions and facts that are joined together and used by business entities for insights and analytics. They are often grouped by business units such as marketing,finance, product, and sales.
            - REPORT TABLES: rpt_<subject> = Can be built on top of dim, fact, and mart tables. Very specific filters are applied that make report tables applicable to a narrow subset of reporting purposes.
            - PUMP TABLES: pump_<subject> = Can be built on top of dim,fact, mart, and report tables. Used for models that will be piped into a third party tool.
            - MAP TABLES: map_<subjects> = Used to maintain one-to-one relationships between data that come from different sources.
            - BRIDGE TABLES: bdg_<subjects> = Used to maintain many-to-many relationships between data that come from different sources. See the Kimball Group's documentation for tips on how to build bridge tables.
            - These tables act as intermediate tables to resolve many-to-many relationships between two tables.

   - Data Lineage allows one to track data flow from its source to the consumers, by also tracking all its transformations in between. It helps understand how data flows within our warehouse and through to consumption surfaces

   - Operational Workload vs. Analytics Workload
       - Operational
         - Needs fresh data
         - Typically uses canned queries (instead of Ad-hoc)
         - Uptime is important
         - Internal/External Alerts and Notifications
         - Customer Segmentation
         - Dynamic pricing & recommendations
         - Business Automation and Workflows
         - Online feature serving for ML and AI
       - Analytical
         - Business Intelligence exploration
         - Ad-Hoc Exploratory Analysis of metrics
         - KPI Dashboards
         - Prototyping and exploring hypothetical scenarios

     - Data lakehouse - The raw data is stored as files in a data lake, and a relational storage layer abstracts the underlying files and expose them as tables, which can be queried using SQL.

     - Star schema (The name “star schema” comes from the fact that when the table relationships are visualized, the fact table is in the middle, surrounded by its dimension tables; the connections to these tables are like the rays of a star.)
         - Fact table - represents an event that occurred at a particular time
         - Dimension table - dimensions represent the who, what, where, when, how, and why of the event. Dimension tables are usually much smaller (millions of rows).
         - Snowflake schema - where dimensions are further broken down into sub-dimensions.Snowflake schemas are more normalized than star schemas, but star schemas are often preferred because they are simpler for analysts to work with.
         - The idea behind column-oriented storage is simple: don’t store all the values from one row together, but store all the values from each column together instead. If each column is stored in a separate file, a query only needs to read and parse those columns that are used in that query, which can save a lot of work. Columnar storage can be significantly faster for ad hoc analytical queries.
     - OLAP Cubes are a grid of aggregates grouped by different dimensions.
     - LSM-trees - All writes first go to an in-memory store, where they are added to a sorted structure and prepared for writing to disk. It doesn’t matter whether the in-memory store is row-oriented or column-oriented. When enough writes have accumulated, they are merged with the column files on disk and written to new files in bulk.
     -Data  Replication
         - Synchronous - the leader waits until follower 1 confirms receipt of changes/updates
         - Asynchronous - the leader Doesn't wait for confirmation from follower
     - Data vault
         -  designed for historical tracking all aspects of data 
         -  relationships and attributes as well as where the data is being sourced from over time. Satellites, which are similar to dimensions.
         - Puts forth a set of design principles & structures for increasing historical tracking performance within the Vault (PiT and Bridge). The Data Vault model is flexible enough to adopt these structures at any point in time within the iterative modeling process and does not require advanced planning.
         - Data Vault is essentially a layer between the information mart / star schema and staging. There is some additional overhead that comes with developing this layer both in terms of ETL development and modeling. If the project is on a small scale or the project’s life is
        short-lived, it may not be worth pursuing a Data Vault model.
         - One of the main driving factors behind using Data Vault is for both audit and historical tracking purposes. If none of these are important to you or your organization, it can be difficult to eat the overhead required to introduce another layer into your modeling. However, speaking from long-term requirements, it may be a worthwhile investment upfront.
        - Wherescape
            - Additional layer between Staging and Star schema
            - Wherescape (WS) doesn't address Real time integration itself...needs another product
            - There is additional overhead but advantages are better     historical tracking and auditing
            - WS has dependency on Windows
            - It has dependency on SQL Server for Modelling (?) ...not sure     if it has to be in HA Mode .... One option discussed was free SQL Server    Express Edition but  HA Options with these edition are not available.

        -  Databases - Gotchas
            - MySQL: the query cache, replication, the buffer pool.MySQL lacks transactional schema changes and has brittle replication.
                - innodb_buffer_pool size / table size decides whether there’ll be a performance downgrade.
                - A more meaningful metric to tell whether you need to split a MySQL table is query runtime / buffer pool hit rate. If the queries always hit the buffer, there’ll not be any performance issue. 20M rows is just a value based on experience.
                - Except for splitting table, increase innodb_buffer_pool size / database memory is also a choice.
                - If possible, avoid select * in production, which causes 2 times index tree lookup in the worst case.
            - PostgreSQL: VACUUM, connection overhead, shared buffers. PostgreSQL is susceptible to vacuum and bloat problems during long-running transactions.
            - MongoDB: missing indexes, lock contention
            - index merge (Query using multiple individual indexes to arrive at result) will be ~10x slower than the composite index.
           - Citus for PostgreSQL
              - Sharding. Citus handles all of the sharding, so applications do not need to be shard-aware.
              - Multi-tenancy. Applications built to colocate multiple customers’ databases on a shared cluster—like most SaaS applications—are called multi-tenant. Sharding, scaling, resharding, rebalancing, and so on are common pain points in modern SaaS platforms, all of which Citus solves.
              - Analytics. Citus is not exclusively an analytical database, but it certainly is deployed for distributed, massively parallel analytics workloads a lot. Part of this is because Citus supports complex queries, building upon Postgres’s own very robust SQL support. Citus can shard queries that do combinations of things like distributed GROUP BY and JOIN together.

              - A Citus cluster is composed of PostgreSQL nodes with one of two roles: coordinator or worker. A coordinator receives queries, then decomposes them into smaller queries that execute on shards of data in the worker nodes. The coordinator then reassembles the results and returns them to the client.

              - Citus is not middleware: it’s an extension to Postgres that turns a collection of nodes into a clustered database. This means that all of the query rewriting, scatter-gather MPP processing, etc happens within the PostgreSQL server process, so it can take advantage of lots of PostgreSQL’s existing codebase and functionality.

        - Data Mesh
            - a data mesh allows data sources to remain distributed and controlled by different organizations, but accessible to a centralized application. With a data mesh architecture, data is guaranteed to be highly available, easily discoverable, secure and interoperable with the applications that depend on accessing it.
            - Domain ownership - Data is owned by domains that are intimately familiar with it.
            - Data as a Product - encourage domains to share the data.
            - Self serve Data platform -
            - Computational federated governance - Data mesh introduces a federated decisionmaking model composed of domain data product owners. The policies they formulate are automated and embedded as code in each and every data product.
            - Data Product Quantum - overlays microservices architecture.
                - Source-aligned (native) DPQ - Provides analytical data on behalf of the collaborating architecture quantum, typically a microservice, acting as a cooperative quantum.
                - Aggregate DQP - Aggregates data from multiple inputs, either synchronously or asynchronously. For example, for some aggregations, an asynchronous request may be sufficient; for others, the aggregator DPQ may need to perform synchronous queries for a source-aligned DPQ.
                - Fit-for-purpose DPQ - A custom-made DPQ to serve a particular requirement, which may encompass analytical reporting, business intelligence, machine learning, or other supporting capability.
            - Highly suitable for Microservices based architecture
            - Requires asynchronous communication and eventual consistency
            - It is more difficult in architectures where analytical and operational data must stay in sync at all times, which presents a daunting challenge in distributed architectures.

       - Data orchestration landscape ,
             - Evolution
                 - In 1987, it started with the mother of all scheduling tools, (Vixie) cron
                 - to more graphical drag-and-drop ETL tools around 2000 such as Oracle OWB, SQL Server Integration Services, Informatica
                 - to simple orchestrators around 2014 with Apache Airflow, Luigi, Oozie
                 - to modern orchestrators around 2019 such as Prefect, Kedro, Dagster, or Temporal
             - Airflow - recommended to use intermediary storage to pass data between different tasks.
             - Prefect if you need a fast and dynamic modern orchestration with a straightforward way to scale out.
             - Dagster when you foresee higher-level data engineering problems. They focus heavily on data integrity, testing, idempotency, data assets, etc.


        - Apache Airflow for ETL
             - Primarily a workflow Management tool
             - Using Airflow to schedule and monitor ELT pipelines, but use other open-source projects that are better suited for the extract, load and transform steps. Notably, using Airbyte for the extract and load steps and dbt for the transformation step.
             -   With Airflow you can use operators to transform data locally (PythonOperator, BashOperator...), remotely (SparkSubmitOperator, KubernetesPodOperator…) or in a data store (PostgresOperator, BigQueryInsertJobOperator...).
             -  One of the main issues of ETL pipelines is that they transform data in transit, so they break easier. Hence move to ELT.
             - Airflow transfer operators together with database operators can be used to build ELT pipelines




- API 
     - Idempotency in API,
               - idempotency key is usually a unique value that is generated by the client and expires after a certain period of time. A UUID is commonly used as an idempotency key and it is recommended
               - To perform an idempotent payment request, an idempotency keyis added to the HTTP header <idempotency-key: key_value>
               - an idempotency key is sent to the payment system as part of the HTTP request
               - For the second request, it’s treated as a retry because the  payment system has already seen the idempotency key. When we include a previously specified idempotency key in the request header, the payment system returns the latest status of the previous request.
               - If multiple concurrent requests are detected with the same idempotency key, only one request is processed and the others receive the “429 Too Many Requests” status code.
               - To support idempotency, we can use the database's unique key constraint.


     - Handling long-running operations in REST API (Azure Way),
         - The client sends the initial request to the resource to initiate the long-running operation. This initial request could be a PUT, PATCH, POST, or DELETE method.

         - The resource validates the request and initiates the operation processing. It sends a response to client with a 200-OK HTTP status code (or 201-Created if the operation is a create operation) and a representation of the resource where the status field is set to a value indicating that the operation processing has been started.

         - The client then issues a GET request to the resource to determine if the operation processing has completed.

         - The resource responds with a representation of the resource. While the operation is still being processed, the status field will contain a "non-terminal" value, like Processing.

         - After the operation processing has completed, a GET request from the client will receive a response where the status field contains a "terminal" value -- Succeeded, Failed, or Canceled -- that indicates the result of the operation

    - OpenAPI Specification
         - OpenAPI is specification while swagger is tooling that uses OpenAPI Specification
         - API Definition - JSON/YAML documents that capture unique API's business intent aimed at meeting specification requirements.
         - OpenAPI Generator allows generation of API Client libraries (SDK generation), server stubs, documentation and configuration automatically given an OpenAPI Spec.
         - Postman can be used to generate test cases basis OpenAPI Document
         - API platforms are systems with integrated tools and processes that allow producers and consumers to effectively build, manage, publish and consume APIs.
             - Tools
                 - API Client - to send PAI Calls
                 - API Designing and mocking
                 - API testing and automation
                 - API Documentation
                 - API Monitoring
             - Collaboration capabilities
                 - API Workspaces (Collaboration on API Related workflows)
                 - API Catalog
             - Governance Capabilities
                 - API Security - Checks during development, testing and production
                 - API Observability - Measuring API Traffic
             - Integration with SDLC
             - General Principles
                 - API Should Do One Thing and Do it Well
                 - API Should Be As Small As Possible But No Smaller
                 - Minimize Accessibility of Everything (Classes, Methods etc.)
                 - Names should be self-explanatory
                 - Document religiously
                 - Consider Performance Consequences of API Design Decisions
                 - Minimize mutability of classes
                 - for Methods, avoid long parameter list Three or fewer parameters is ideal.
                     - Two techniques for shortening parameter lists
                         _ Break up method
                         _ Create helper class to hold parameters


  - API Gateway
        - Implementing security and cross-cutting concerns like security and authorization on every internal service can require significant development effort. A possible approach is to have those services within the Docker host or internal cluster to restrict direct access to them from the outside, and to implement those cross-cutting concerns in a centralized place, like an API Gateway.
        - Coupling - Without API Gateway, Client apps are coupled to the internal services. Any changes in internal services directly impact clients.
        - Security - Api Gateway can handle security aspects required for endpoints exposed to outside world
        - Cross cutting concerns - Authorisation, TLS/SSL can be handled at API Gateway layer.

         - Features of API Gateway,
           - Microservices or services based architecture with need for single point of entry  for all APIs
           - Authentication and Authorization using Tokens (JWT/OAuth2) , key management
           - Rate limiting
           - Aggregate responses from services  
             - Reverse proxy or gateway routing. The API Gateway offers a reverse proxy to redirect or route requests (layer 7 routing, usually HTTP requests) to the endpoints of the internal microservices.
             - Requests aggregation. As part of the gateway pattern you can aggregate multiple client requests (usually HTTP requests) targeting multiple internal microservices into a single client request.
             - Cross-cutting concerns or gateway offloading. like
                 - Authentication and authorization
                 - Service discovery integration
                 - Response caching
                 - Retry policies, circuit breaker, and QoS
                 - Rate limiting and throttling
                 - Load balancing
                 - Logging, tracing, correlation
                 - RT or NRT Monitoring of API Traffic
                 - Headers, query strings, and claims transformation
                 - IP allowlisting


- Performance 

    - .NET Performance 
       - Avoid LINQ. LINQ is great in application code, but rarely belongs on a hot path in library/framework code. LINQ is difficult for the JIT   to optimize (IEnumerable<T>...) and tends to be allocation-happy.
       - Use concrete types instead of interfaces or abstract types. This was mentioned above in the context of inlining, but this has other benefits. Perhaps the most common being that if you are iterating over a List<T>, it's best to not cast that list to IEnumerable<T> first (eg, by using LINQ or passing it to a method as an IEnumerable<T> parameter). The reason for this is that enumerating over a list using foreach uses a non-allocating List<T>.Enumerator struct, but when it's cast to IEnumerable<T>, that struct must be boxed to IEnumerator<T> fo+r foreach.
       - Mark classes as sealed by default. When a class/method is marked as sealed, RyuJIT can take that into account and is likely able to inline a method call.
       - Mark override methods as sealed if possible.
       - Pass Struct by ref to minimize on-stack copies

       - Use Streams/pipelines for large data sets
         - If streams are using Buffers then always FlushAsync.
         - Pool and re-use buffers when you need to operate on in-memory data.
         - RegEx compilation is like 5000 lines of code
       - ConcurrentDictionary
           - conceptually similar to Dictionary where Reads are lock free but writes are not
           - The default number of concurrent writes is equal to the number of processors on the machine.
           - always enumerate over entries and not over keys
           -Dictionary with lock - "Poor read speed, lightweight to create and medium update speed."
           - Dictionary as immutable object - "best read speed and lightweight to create but  heavy update. Copy and modify on mutation e.g. new Dictionary(old).Add(key, value)"
           - Hashtable - "Good read speed (no lock required), same-ish weight as dictionary but more expensive to mutate and no generics!"
           - ImmutableDictionary - "Poorish read speed, no locking required but more allocations require to update than a dictionary."
       - in C#, avoid hashtable and use Dictionary<> instead
           - Hashtable is weakly typed and while it allows you to have keys that map to different kinds of objects which may seem attractive at first, you'll need to "box" the objects up and boxing and unboxing is expensive. You'll almost always want to use Dictionary instead.

       - C# has a class MemoryMappedFile. A memory-mapped file contains the contents of a file in virtual memory. This mapping between a file and memory space enables an application, including multiple processes, to modify the file by reading and writing directly to the memory.  This could be useful when dealing with large files. Often preferred over buffers as buffering is difficult to get right.

       - The rule-of-thumb for allocations is that they should either die in the first generation (Gen0) or live forever in the last (Gen2).
       - What affects scale
         - GC (Too many GC Pauses)
         - Threadpool starvation
         - Too many timers
         - Exceptions
         - Synchronous IO
         - Highly contended locks
       - For scale
           - for fixed RPS, monitor CPU Usage and memory usage
           - Understand how much scale unit, your deployment can handle (e.g. each VM can handle 1000 RPS)
       - Checklist
           - CPU
               - CPU Usage
               - Threadpool (work items and worker threads)
               - GC (Gen0,Gen1 & Gen2) collections
               - Locks
               - Application logic
                   - chatty IO
                   - Serialization
           - Memory
               - Usage
               - Number of threads
               - Application Logic
                   - Strings
                   - Reading everything in memory instead of using streaming
                       - Disk IO
                       - Network IO
                   - Disposable objects not being disposed
                   - AsyncLocal leaks
           - Threadpool
               - Sync over async
                   - APIs that masquerade as synchronous but are actually blocking async methods
                   - Uses 2 threads to complete single operation
               - Blocking APIs are bad
                   - Avoid blocking APIs e.g. Task.Wait, Task.Result, Thread.Sleep, GetAwaiter.GetResult()
               - Excessive blocking causes thread starvation
               - Thread injection rate beyond configured max is slow
           - Web Applications
               - Always prefer Concurrent implementations (ConcurrentDictionary) over other alternatives.
           - GC
               - Allocating object is cheap, collecting it isn't
               - Allocating lots of objects can lead to GC pauses
               - Allocating objects over 85Kb in size ends up on large object heap
                   - LOH is collected in gen 02
           - JSON Parsing in APIs
               - As much as possible , use parser provided by framework.
           - CancelAfter implementation
               ```
               public static async Task<T> TimeoutAfter<T>(this Task<T> task, TimeSpan timeout)
               {
                   using (var cts = new CancellationTokenSource())
                   {
                       var delayTask = Task.Delay(timeout, cts.Token);

                       var resultTask = await Task.WhenAny(task, delayTask);

                       if (resultTask == delayTask) {
                           throw new OperationCancelledException();
                       } else {
                           cts.Cancel();
                       }

                       return await Task;
                   }
               }

               ```
       - Async programming - don't block
        - How ASP.NET requests are processed
            - .NET framework maintains pool of threads and dispatched for a new request.
            - If request is processed synchronously then respective thread is busy for that duration
            - Max number of threads is 5000 for .NET 4.5
            - If long running processing of requests blocks many threads then its called as thread starvation
            - In case of "thread starvation", web server queues requests and when queue is full it responds with HTTP 203 (server busy)
            - Each new thread has overhead of about 1MB of RAM
            - In case when "async...await" is used,  ASP.NET will not be using any threads between the async method call and the await.
            - An asynchronous request takes the same amount of time to process as a synchronous request. However, during an asynchronous call, a thread is not blocked from responding to other requests while it waits for the first request to complete. Therefore, asynchronous requests prevent
        request queuing and thread pool growth when there are many concurrent
        requests that invoke long-running operations.
            - Guidance,
                - Use synchronous when,
                    - Operation is short-lived
                    - Simplicity is more important (No need for parallelism)
                    - Primarily CPU based instead of I/o (Network, Disk etc.)


- Interview Tips 
       - If the interviewer interrupts you, it's probably because you’re
  going off track.
       - It's more important to cover everything broadly than it is to
  explain every small thing in detail.Interviewers are not looking for
  specific answers with ironclad certainty. They want to see
  well-reasoned, qualified decisions based on engineering trade-offs.
       - Whatever decision you make, explain why. In a system design
  interview, why is more important than what. For anything you say, be
  prepared to explain why.
       - Your interviewer cares less about whether your design is good in
  itself, and more about whether you are able to talk about the trade-offs
  (positives and negatives) of your decisions.
       - For a System design interview, Interviewer looks for,
               - a broad, base-level understanding of system design
  fundamentals.
               - back-and-forth about problem constraints and parameters.
               - well-reasoned, qualified decisions based on engineering
  trade-offs.
               - the unique direction your experience and decisions take them.
               - a holistic view of a system and its users.
               - Not interested in deep expertise in the given problem
  domain.

    -  STAR (Situation, Task, Action, Result):
         - “What was the situation?”
         - “What were you tasked with?”
         - “What actions did you take?”
         - “What was the result?”
         - Bar Raiser process steps such as preparing a set of behavior-based interview questions in advance of the interview, insisting on written transcripts of the interview, rereading the
    transcript post interview (before making an assessment), conducting debriefs, basing debriefs on the interview transcripts, and making assessments based on well-understood principles are all steps that seek to eliminate individual biases. Having a diverse group of people involved in the process obviously reduces the chance of unconscious bias worming its way in.

     - Lessons learned,
         - Soft skills (people skills) matter in software architecture 
         -  Always keep the project and business constraints in mind when creating and analyzing software architecture (cost, time, budget, skill levels, etc.)
         - Don’t get caught up in the hype as a software architect. Stop, analyze tradeoffs, study trends, and approach new technology with caution.
         -  Focus more on the “why” rather than the “how” – this is what is truly important is software architecture
         -  Spreading knowledge is more valuable than being an individual contributor.

    - Why are you looking for a change?
       - "I have reached a point in my career where I'm seeking new challenges and opportunities for growth. While I've gained valuable     experience at my current job, I believe that transitioning to a new role     will allow me to further develop my skills and contribute in a different     capacity."
       - "I am looking to change my job because I am seeking a role that     offers greater alignment with my career objectives and allows me to     utilize my strengths and expertise to make a meaningful impact."

- Miscellaneous 
    - Web Testing
        - Unit testing - Unit testing is a testing type in which minor
    testable parts or units of an application are individually and
    independently tested for proper operation. These units can vary in scope
    from functions, classes, or interfaces, to services or complete
    components. Their primary attributes are execution speed, isolation, and
    comfortable maintainability.  Tools: Vitest/JEST
        - Integration Testing - Integration testing focuses on interactions
    between components or systems. In other words, on how well they work
    together. Typical examples of integration tests are API or component
    tests. Tools: WebDriverIO, Cypress
       - End to End Testing - These tests are often called UI tests and this
    name explains their function even better. These tests interact with your
    application's UI, including the complete application stack, and test
    your application from one end to the other. Tools: WebDriveIO, Cypress,
    PlayWright,

       - Cypress.io - End to end test platform
           - Cypress takes screenshots as tests run
           - automatically reloads when tests are changed
           - Waits for commands and assertions
           - is not a general purpose tool like for indexing the web.
           - Only JS is supported for test cases
           - Each test is bound to single domain.

  - Architecture Decision Records (ADR)
       - Format of ADR
           - Title - For Example: "ADR 1: Deployment on Ruby on rails 3.0.10"
           - Context - Describes forces at play including technological, political, social and project local. The language in this section should be describing facts and nothing else
           - Decision - Describes response to forces mentioned in "Context".  It is stated in full sentences, with active voice. "We will …"
           - Status - A decision may be "proposed" if the project stakeholders haven't agreed with it yet, or "accepted" once it is agreed. If a later ADR changes or reverses a decision, it may be marked as "deprecated" or "superseded" with a reference to its replacement.
           - Consequences - This section describes the resulting context, after applying the decision. All consequences should be listed here, not just the "positive" ones. A particular decision may have positive, negative, and neutral consequences, but all of them affect the team and project in the future.

  - Template for "Design Document"
       - Title : Title of the document
       - Date: Date of last revision
       - Author(s)/Reviewer(s)/Approver(s)
       - Revision Number
       - Status - In draft/in review/approved/in progress.
       - Executive Summary - brief summary of the project that contains the major goal of the project and how it is achieved.
       - Goals ("In Scope") - What is to be achieved by the project, typically represented as a bullet list. Include non-tangible, process goals such as standardization or metrics requirements.
       - Non-goals ("Out of scope") - A list of non-goals should explicitly identify what is not included in the scope for this project.
       - Background - brief history. Identify any acronyms or unusual terminology used. Document any previous decisions made that resulted in limitations or constraints.
       - High-level Design - How design works at a high level.
       - Detailed Design - The full design, including diagrams, sample configuration files, algorithms, and so on. This will be your full and detailed description of what you plan to accomplish on this project
       - Alternatives Considered - A list of alternatives that were rejected, along with why they were rejected.
       - Special Constraints - A list of special constraints regarding things like security, auditing controls, privacy, and so on.

       Below are not mandatory but could be useful,

       - Cost Projections: The cost of the project—both initial capital and operational costs, plus a forecast of the costs to keep the systems running.
       - Support Requirements: Operational maintenance requirements. This ties into Cost Projections, as support staff have salary and benefit costs, hardware and licensing have costs, and so on.
       - Schedule: Timeline of which project events happen when, in relation to each other.
       - Security Concerns: Special mention of issues regarding security related to the project, such as protection of data.
       - Privacy and PII Concerns: Special mention of issues regarding user privacy or anonymity, including plans for handling personally identifiable information (PII) in accordance with applicable rules and regulations.
       - Compliance Details: Compliance and audit plans for meeting regulatory obligations under SOX, HIPPA, PCI, FISMA, or similar laws.
       - Launch Details: Roll-out or launch operational details and requirements.

    - VMs or Serverless
         - VMs, Serverless and when they are useful,
             - Virtual machines (e.g. EC2 or Compute Engine) are useful for workloads that change no faster than you’re able to add capacity, or for work loads that can tolerate delay in scaling (e.g. queue based event systems). They are also useful for short lived sessions that can tolerate scale down events
             -  Containers (e.g. a Kubernetes cluster or Fargate) which run on top of fixed compute. Like virtual machines are useful for traffic volumes which slowly change over time. While you’re able to start up a new container quickly to handle a new session, you’re still limited by
            the underlying compute instance on which the containers are running. The underlying compute hardware has to scale to meet the demands of the running containers. Containers are great for long lived, stateful sessions, as they can be ported between physical hardware instances
            while still running.
             - Serverless functions (e.g. Lambda or Cloud Run) are, in essence, containers running on top of physical hardware. They are ideally suited for handling unpredictable traffic volumes and for non-persistent and stateless connections.

    - How perplexity works
       - The user enters a query. Perplexity may ask follow-up questions to clarify the user's intent, then transforms the query into one or more queries optimized for a search engine. It then passes those queries to Google and/or Bing (presumably using SerpAPI and/or Bing's API), which in turn return a list of top links. It seems to me that Perplexity not only uses Google and Bing, but also weighs certain sources like news sites and Yelp somewhat more heavily. 
       -  Once Perplexity gets a list of links back, it now needs to visit those on your behalf. Typically, this would involve navigating to the page, rendering its DOM, extracting the core content, and preparing to pass it to an LLM. They almost certainly maintain a cache of those pages such that that doesn't happen on every query. 
      -  The scraped contents of those pages are then passed to an LLM which is asked to answer the user's query using a summary of their contents. Based on their pricing page, it seems like Perplexity nowadays uses a mix of various models ranging from ones they've trained themselves to off-the-shelf APIs like Claude 4 and GPT-4o. That summary is then streamed to the user's client in real time.


===================


- [PostgreSQL Replication][Databases]
     - PostgreSQL supports block-based (physical) replication as well as the row-based (logical) replication. Physical replication is traditionally used to create read-only replicas of a primary instance, and utilized in both self-managed and managed deployments of PostgreSQL. Uses for physical read replicas can include high availability, disaster recovery, and scaling out the reader nodes.
     -   High availability
         - Recovery Point Objective (RPO) -  the time span within which transactions may be lost after recovery
         - Recovery Time Objective (RTO) - the time it takes from failure to successful recovery

- [Data storage][Databases][Architecture]
     - Row oriented - Because data on a persistent medium such as a disk is typically accessed block-wise (in other words, a minimal unit of disk access is a block), a single block will contain data for all columns.This is great for cases when we’d like to access an entire user record, but makes queries accessing individual fields of multiple user records (for example, queries fetching only the phone numbers) more expensive, since data for the other fields will be paged in as well
     - Column-oriented - Store values by vertical partitioning ie. by column against storing values by horizontal partitioning (as in RDBMS).
         - In column-oriented layout, values of same column are stored contiguously on disk.For example, if we store historical stock market prices, price quotes are stored together. Storing values for different columns in separate files or file segments allows efficient queries by column, since they can be read in one pass rather than consuming entire rows and discarding data for columns that weren’t queried.
         - Column-oriented stores are a good fit for analytic workloads that compute aggregates, such as finding trends, computing average values, etc. Processing complex aggregates can be used in cases when logical records have multiple fields, but some of them (in this case, price quotes) have different importance and are often consumed together.
         - Apache Parquet, Apache ORC are column-oriented file formats.
             - Parquet
                 - They use hybrid (row & colum) approach for storage. Values of each column for set of rows (rowgroups) are stored contiguously.
                 - Usually not stored as single file.
                 - Supports Compression using techniques like RLE (Run length encoding). Stores repeated value only once and associated encoded data.
                 - Smaller files results in lesser I/O
                 - Can be inspected using Parquet-tools
                 - Uses optimization techniques like predicate pushdown (which stores range of column value per row. This is then used during querying)
         - Reading multiple values for the same column in one run significantly improves cache utilization and computational efficiency.
         - If the read data is consumed in records (i.e., most or all of the columns are requested) and the workload consists mostly of point queries and range scans, the row-oriented approach is likely to yield better results. If scans span many rows, or compute aggregate over a subset of columns, it is worth considering a column-oriented approach.
         - Wide column stores
             - data is represented as a multidimensional map, columns are grouped into column families (usually storing data of the same type), and inside each column family, data is stored row-wise. This layout is best for storing data retrieved by a key or a sequence of keys.
             -Each row is indexed by its row key. Related columns are grouped together in column families.
             - Each column inside a column family is identified by the column key, which is a combination of the column family name and a qualifier.
             - Column families store multiple versions of data by timestamp.


- [Postgres indexes][Databases],
     - B-tree indexes are the most common type of index and would be the
default if you create an index and don’t specify the type. B-tree
indexes are great for general purpose indexing on information you
frequently query.
     - BRIN indexes are block range indexes, specially targeted at very
large datasets where the data you’re searching is in blocks, like
timestamps and date ranges. They are known to be very performant and
space efficient.
     - GIST indexes build a search tree inside your database and are
most often used for spatial databases and full-text search use cases.
     - GIN indexes are useful when you have multiple values in a single
column which is very common when you’re storing array or json data.

- [Postgres Triggers][Databases]
     - is limited to single server
     - working set does not fit in memory
     - reaching limit of network attached storage, CPU
     - Analytical queries take too long
     - Autovacuum can not keep up with transaction load


- [Database schema migrations - general flow of online schema
migration][Databases],
     - Create a new, empty table, in the likeness of the original table.
We title this the ghost table.
     - ALTER the ghost table. Since the table is empty, there is no
overhead to this operation.
     - Validate the structural change is compatible with tooling
requirements.
     - Analyze the diff.
     - Begin a long running process of copying existing rows from the
original tables to the ghost table. Rows are copied in small batches.
     - Capture or react to ongoing changes to the original table, and
continuously apply them onto the ghost table.
     - Monitor general database and replication metric, and throttle so
as to prioritize production traffic as needed.
     - When the existing data copy is complete, the migration is
generally considered as ready to cut-over, give or take some small
backlog or state of the replication topology.
     - Final step is the cut-over: renaming away of the original table,
and renaming the ghost table in its place. Up to some locking or small
table outage time, the users and apps are largely ignorant that the
table has been swapped under their feet.

- [Open source data stack][Architecture]
     - Airflow - Workflow
     - Airbyte - ELT
     - dbt - ELT
     - Metabase - Dashboards and reporting
     - superset - Dashboards and reporting
     - PostgreSQL - RDBMS
     - Great_Expectations - Data pipeline testing
     - datahub - Data catalog/lineage

- Quantum computing and 3d printing.
     - Quantum computing  has the potential to break the encryption used to protect sensitive data in the digital world of today and tomorrow.Powerful countries, companies, and universities are pouring money into the task of building a quantum computer powerful enough to perform exponentially faster than the computers of today.Google and IBM use the same basic building block in their machines to create quantum behavior, known as transmon qubits which were invented by NSA.
     - Monitoring 5G successfully requires a deep understanding of what makes it fundamentally different from its predecessors: higher speed, lower range, more distribution nodes, different data protocols.
     - NSA says "In the future, superpowers will be made or broken based on the strength of their cryptanalytic programs"

- Quantum Computing's impact
     -  the most important security and privacy properties to protect in the face of a quantum computer are confidentiality and authentication.
         - quantum computers will not only be able to decrypt on-going traffic, but also any traffic that was recorded and stored prior to their arrival.
         - The threat model for authentication is a little more complex: a quantum computer could be used to impersonate a party in a connection or conversation.

- [Database Record Access][Databases]
     - Why indexes,
         - When data is stored on disk-based storage devices, it is
stored as blocks of data. These blocks are accessed in their entirety,
making them the atomic disk access operation. Disk blocks are structured
in much the same way as linked lists; both contain a section for data, a
pointer to the location of the next node (or block), and both need not
be stored contiguously. Due to the fact that a number of records can
only be sorted on one field, we can state that searching on a field that
isn’t sorted requires a Linear Search which requires (N+1)/2 block
accesses (on average), where N is the number  of blocks that the table
spans. If that field is a non-key field (i.e. doesn’t contain unique
entries) then the entire tablespace must be searched at N block
accesses. Whereas with a sorted field, a Binary Search may be used,
which has log2 N block accesses. Also since the data is sorted given a
non-key field, the rest of the table doesn’t need to be searched for
duplicate values, once a higher value is found. Thus the performance
increase is substantial.

     - What is indexing?
         - Indexing is a way of sorting a number of records on multiple fields. Creating an index on a field in a table creates another data structure which holds the field value, and a pointer to the record it relates to. This index structure is then sorted, allowing Binary Searches to be performed on it. The downside to indexing is that these indices require additional space on the disk since the indices are stored together in a table using the MyISAM engine, this file can quickly reach the size limits of the underlying file system if many fields within the same table are indexed.
     - When should it be used?
         - Given that creating an index requires additional disk space
(277,778 blocks extra from the above example, a ~28% increase), and that
too many indices can cause issues arising from the file systems size
limits, careful thought must be used to select the correct fields to index.

- PostgreSQL Learnings,
     - LEFT JOIN in place of an INNER JOIN helps the planner make more
accurate row count predictions. Adding redundant ON clauses improves
Hash Joins.
     -  ANY(VALUES ...) instead  of IN can enforce a Hash Aggregate with
many elements.
     - It’s a bad idea to make the table primary key a varchar.
     - CLUSTER rocks when the query returns many related rows.
     - pg_hint_plan offers powerful hints, including the estimated row
count correction Rows, JOIN sequence enforcer Leading, and the index
override IndexScan. Though the latter may strike back.

- When should NOSQL be used?
     - Massive write scaling is required, more than a single server can
provide
     - Only simple data access pattern is required
     - Strong transactional or data retention guarantees are not required
     - Unstructured duplicate data that greatly benefits from column
compression
     - Tradeoff vis-a-vis relational,
         - Basically Available – The system can guarantee availability, as defined by the CAP theorem, but by potentially trading off consistency.
         - Soft State – The database doesn’t enforce data consistency, and values may change without interaction, due to eventual consistency.
         - Eventual Consistency – When data is written, it isn’t guaranteed to be immediately consistent to all database consumers. Generally speaking, it has to be replicated across all nodes in the database, which means that any reads occurring during that time could be inconsistent.

- When relational storage be used?
     - Variable workloads and reporting
     - Easy Administration
     - Simplified development
     - Strong data retention

- Postgres High availability with Patroni,
     - When used in a single datacenter, the environment is typically
setup as a 3-node cluster on three separate database hosts.
     - Basic components,
         - PostgreSQL cluster: the database cluster, usually consisting
of a primary and two or more replicas
         - Patroni: used as the failover management utility
         - etcd: used as a distributed configuration store (DCS),
containing cluster information such as configuration, health, and
current status.
     - How HA Works,
         - Each PostgreSQL instance within the cluster has one
application database. These instances are kept in sync through streaming
replication.
         -  Each database host has its own Patroni instance which
monitors the health of its PostgreSQL database and stores this
information in etcd.
         - The Patroni instances use this data to:
             - keep track of which database instance is primary
             - maintain quorum among available replicas and keep track
of which replica is the most "current"
             - determine what to do in order to keep the cluster healthy
as a whole
             - Patroni manages the instances by periodically sending out
a heartbeat request to etcd which communicates the health and status of
the PostgreSQL instance. etcd records this information and sends a
response back to Patroni.
         - Streaming replication
             - Keeps replica more up to date compared to file based log
shipping.
             - The standby connects to the primary, which streams WAL
records to the standby as they're generated, without waiting for the WAL
file to be filled.
             - is asynchronous by default.

- [Database Query performance analysis (MySQL)][Databases]
     -  lock time greater than 50% of query time is a problem because MySQL should spend the vast majority of its time doing work, not waiting.
     - Locks are primarily used for writes (INSERT, UPDATE, DELETE, REPLACE) because rows must be locked before they can be written. Response time for writes depends, in part, on lock time
     - For reads (SELECT), there are nonlocking and locking reads. The distinction is easy because there are only two locking reads: SELECT…FOR UPDATE and SELECT…FOR SHARE. If not one of those two, the SELECT is nonlocking, which is the normal case.
     - Locking reads should be avoided, especially SELECT…FOR UPDATE, because they don’t scale, they tend to cause problems, and there is usually a nonlocking solution to achieve the same result
     - Rows examined is the number of rows that MySQL accessed to find matching rows. It indicates the selectivity of the query and the indexes. The more selective both are, the less time MySQL wastes examining nonmatching rows.


- [How postgre stores rows][Databases]
     - PostgreSQL stores the actual data into segment files (more generally called heap files). Typically its fixed to 1GB size but you can configure that at compile time using --with-segsize. When a table or index exceeds 1 GB, it is divided into gigabyte-sized segments. This arrangement avoids problems on platforms that have file size limitations but 1GB is very conservative choice for any modern platform. These segment files contain data in fixed size pages which is usually 8Kb, although a different page size can be selected when compiling the server with --with-blocksize option but this size usually falls in ideal size when considering performance and reliability tradeoffs. If the page size is too small, rows won’t fit inside the page and if it’s too large there is risk of write failure because hardware generally can only guarantee atomicity for a fixed size blocks which can vary disk to disk (usually ranges from 512 bytes to 4096 bytes).
     - Internally PostgreSQL maintains a unique row id for our data which is usually opaque to users. We can query it explicitly to see its value.in ctid First digit stand for the page number and the second digit stands for the tuple number. PostgreSQL moves around these tuples when VACUUM is run to defragment the page.


- Code Obfuscation types
     - Name obfuscation - replaces the names of packages, classes, methods, and fields with meaningless sequences of characters. Sometimes the package structure is also modified, which further obscures the names of packages and classes.
     - Flow obfuscation -  modifies code order or the control flow graph, and string encryption, whic encrypts the constant strings in the code. Some tools may go further and obfuscate the XML files in the resource part of the APK

- MySQL
     - frequently dredging up old data is problematic for performance.
     - determine the ideal data model for the access, then use a data
store built for that data model
     - Enqueue writes - Use a queue to stabilize write throughput. It
allow the application to respond gracefully and predictably to flood of
requests that overwhelms the application, or the database, or both.For
write-heavy applications, enqueueing writes is the best practice and
practically a requirement. Invest the time to learn and implement a queue.
     - Data Partitioning - separating hot and cold data: frequently and
infrequently accessed data, respectively. It partitions by Access and it
archives by moving the infrequently accessed (cold) data out of the
access path of the frequently accessed (hot) data
     - Reference data size limit of a single MySQL instance to 2 or 4 TB
(on SSD):
         - 2 TB - For average queries and access patterns, commodity
hardware is sufficient for acceptable performance, and operations
complete in reasonable time.
         - 4 TB - For exceptionally optimized queries and access
patterns, mid- to highend hardware is sufficient for acceptable
performance, but operations might take slightly longer than acceptable.
     - Sharding
         - High cardinality - An ideal shard key has high cardinality
(see “Extreme Selectivity”) so that data is evenly distributed across
shards. A great example is a website that lets you watch videos: it
could assign each video a unique identifier like dQw4w9WgXcQ. The column
that stores that identifier is an ideal shard key because every value is
unique, therefore cardinality is maximal.
         - Reference application entities - An ideal shard key
references application entities so that access patterns do not cross
shards. A great example is an application that stores payments: although
each payment is unique (maximal cardinality), the customer is the
application entity. Therefore, the primary access pattern for the
application is by customer, not by payment. Sharding by customer is
ideal because all payments for a single customer should be located on
the same shard.
         - When opting for sharding, plan to accomodate at least four
years of data growth.
         - ProxySQL and Vitess are middlewares (between app and MySQL)
that support sharding by several mechanisms.
     - A common misconception is that the application needs thousands of
connections to MySQL for performance or to support thousands of users.
This is patently not true. The limiting factor is threads, not
connections—more on Threads_running in a moment. A single MySQL instance
can easily handle thousands of connections. I’ve seen 4,000 connections
in production and more in benchmarks. But for most applications, several
hundred connections (total) is more than sufficient. If your application
demonstrably requires several thousand connections, then you need to shard.
     - MySQL runs one thread per client connection
     - One CPU Core runs one thread.When the number of threads running
is greater than the number of CPU cores, it means that some threads are
stalled - waiting for CPU Time.
     - Four metrics count the occurrence of SELECT statements that are
usually bad for performance:
         - Select_scan
         - Select_full_join
         - Select_full_range_join
     - Database Capacity planning
         - the four-year fit is an estimate of data size or access in
four years applied to the capacity of your hardware today
         - It’s better to be more precise and collect table sizes every
15 minutes.Near-term data growt trending is used to estimate when the
disk will run out of space. Long term trend is used to estimate when
sharding is necessary.
     - A deadlock occurs when two (or more) transactions hold row locks
that the other transaction needs



- [MySQL Replication][Databases]
     - Typical issues
         - Temporary lag - caused by cold cache after restart
         - Occasional lag - caused by write burst or long transactions
         - Perpetual lag - Slaves almost never catch up
         - How to avoid lags
             - avoid long transactions
             - manage batches
             - increase replication throughput
             - Alternative is to Shard
         - Some use cases for replication,
             - backups are faster and less disruptive on slaves than master
             - reading from slaves helps in resilience (when master is
down or loaded)
     - How to monitor lag - Either Pg_heartbeat from percona toolkit or
"second behind master" from "show slave status"


- SQLite - Litestream - How it works
     -  In WAL-mode (the mode you very much want on a server, as it
means writers do not block readers), SQLite appends to a WAL file and
then periodically folds its contents back into the main database file as
part of a checkpoint. Litestream interposes itself in this process: it
grabs a lock so that no other process can checkpoint. It then watches
the WAL file and streams the appended blocks up to S3, periodically
checkpointing the database for you when it has the necessary segments
uploaded.
     - Storing integers instead of floating point numbers is much more
efficient as SQLite does not compress floats.


- [Database Indexes][Databases]
     - Cardinality is the inverse of "the number of records returned per
value." High cardinality returns one record per index value, and low
cardinality returns many records per index value. Efficient indexes are
high-cardinality indexes. Primary keys are the best example of a
high-cardinality index. String-based tags are an example of a
low-cardinality index because there are typically many objects assigned
to a single tag.Build the indexes to match your query needs, and note
that high-cardinality is faster.
     - Table scan happens when no suitable index exists.When using a
table scan, the database keeps all of the records in RAM while comparing
values.
     - All databases employ some level of copy-on-write. Postgres writes
a new version of a row each time it inserts or updates a value. Other
databases have a block-size allocated for a value, then, if an updated
value exceeds the size, it writes to a new location. Other databases
reject updates, claim immutability, and push the tracking of updates off
to the application developer.

- Apache Parquet
     - language-independent storage format, designed for online
analytics, so:
         - Column oriented
         - Typed
         - Binary
         - Compressed
     - A Parquet file stores data column-oriented on the disk, in
batches called "row groups".
     - Parquet storage can provide substantial space savings.
     - Parquet storage is a bit slower than native storage, but can
offload management of static data from the back-up and reliability
operations needed by the rest of the data.

- gRPC and REST
     - Allows browser apps to call gRPC services as RESTful APIs with
JSON. The browser app doesn’t need to generate a gRPC client or know
anything about gRPC.
         - grpc-gateway is another technology for creating RESTful JSON
APIs from gRPC services. It generates reverse proxy to convert RESTFUL
calls to gRPC and vice versa
         - gRPC JSON transcoding runs inside an ASP.NET Core app. It
deserializes JSON into Protobuf messages, then invokes the gRPC service
directly.JSON transcoding deserializes JSON to Protobuf messages and
invokes the gRPC service directly. There are significant performance
benefits in doing this in-process vs. making a new gRPC call to a
different server.

- Cryptography, Crypto economics etc.
     - Hashing use cases - To verify the sendor , Password storage , Time-stamping
     - Public key encryption
         - This has 2 parts, public key and private key
             - Public key is made up by multiplying 2 random prime
numbers and this is published along with auxilliary value.
             - Two  prime numbers are kept secret and they can be used
to decrypt the message.
         - Message encrypted usng public key can  be decrypted using
private key and vice-versa.
         - Digital Signature - Message is encrypted using private key
but can be decrypted using public key.
     - transposition cypher, replacing each letter in a sentence with a
different letter, say, the next in the alphabet
     - transposition cypher with random key is difficult to decrypt.
     - in 1976 Whitfield Diffie and Martin Hellman created a new kind of
cryptography, one that allowed for secure communication of a secret key
over an insecure network.Diffie and Hellman revolutionized cryptography
by proving that a secret key could be distributed over an insecure network.
     - RSA, showed that the key used to encrypt a message did not have
to be the same as the key used to decrypt a message.
         - Using RSA, two keys are created public and private. Public
key is shared.  Public key is used to encrypt a message which can only
be decrypted using private key. It works reverse too i.e. encryption
using private key and decryption using public key.
     - Message services such as WhatsApp and Signal also use
Diffie-Hellman algorithms so that people across the world can
communicate securely.
     - Each smart card has a unique public key known to the credit card
com- pany, say Visa, and a corresponding private key stored on the chip
in the card. When the card is presented for payment,Visa sends it a
random number. The chip in the card encrypts the random number using its
private key and sends the encrypted message back to Visa.Visa then
attempts to decrypt the message using the card’s public key. If the
decrypted message reveals the random num- ber sent by Visa, then Visa
knows exactly which card is being used.
     - A digital signature is a message that can only be decrypted using
Publius’s public key.
     - A cryptographic hash is like a digital fingerprint, a much
shorter message that in practice can be uniquely associated with any
message.a cryptographic hash function takes any data as input and out-
puts a digital fingerprint of that data, an essentially unique ID such
that if any piece of the data is ever changed it won’t hash to the same ID.
     - SHA256 algorithm converts any input to a 256 digit long hash
consisting of 0's and 1's.
         - Hash functions like SHA256 are collision-resistant that is it
is infeasible to find two messages with the same hash.
     - Digital Signatures offer,
         - Authenticity means that a digital signature is strong
evidence that the signer has the identity associated with the public key.
         - The integrity of the message is provided by comparing the
message hash within the signature with the hash of the message.
         -  since only the holder of the private key can sign the
digital signature, the signer cannot repudiate having signed the document.

     -  NFT - An NFT is just a cryptographic hash of an art- work (or
other digital file) signed with a digital signature
     - How Bitcoin network works - When Alice wants to send Bob a
bitcoin she doesn’t contact her bank or Visa or Stripe. Instead she
broadcasts a message to the bitcoin network that says “I authorize a
transfer of bitcoin to Bob. Here’s my digital signature.” Bitcoin
“miners” listen for transaction messages, verify that the transactions
are valid and compile them into blocks. In about 10 min- utes (we
explain why it takes 10 minutes further below) a block with Alice’s new
transaction will be added to the blockchain. Anyone in the world can
then verify that Alice transferred a bitcoin to Bob and if Bob wants to
make a subsequent transaction with Tom anyone can verify that he has the
funds to do so. Alice has no contract with the miners and they are not
obligated to pro- duce blocks.
     - Why bitcoin mining is computationally expensive -  bitcoin miners
must try trillions of hashes to find the rare hash to deploy block onto
the blockchain.
     -  blockchain makes data more secure because tampering with one
element requires changing every subsequent block
     - A smart contract is a kind of contract where the performance is
guaranteed by software instead of by lawyers and judges
     - CryptoCurrency
         -  an electronic payment system based on cryptographic proof
instead of trust, allowing any two willing parties to transact directly
with each other without the need for a trusted third party.
         - Bitcoin is basically Public key and associated balance of
bitcoins. Owner as corresponding private key which allows him to trade.
Combination of public and private key is enough to define a coin.
Cryptocurrency is called cryptocurrency because it’s a currency derived
from cryptography. Every transaction of bitcoin is broadcasted to entire
network so everyone who maintains ledger can update it.
         - Mining the bitcoin involves taking the hash of the previous
block, plus the transactions that have come in since then, plus a new
nonce, and try to find a new hash.Each miner takes a summary of the list
of transactions in the block, along with a hash of the previous block.
Then the miner sticks another arbitrary number—called a “nonce”—on the
end of the list. The miner runs the whole thing (list plus nonce)
through a SHA-256 hashing algorithm. This generates a 64-digit
hexadecimal number. If that number is small enough, then the miner has
mined the block. If not, the miner tries again with a different nonce.



- Data science use cases
     - Spelling corrections
         - Dictionary approach - Involves creating a dictionary of
correctly spelled words and then
         - Classify it - identify misspelled words
         - Recommendation - Present possible corrections
         - Transformation - automatically replace with corrections.Has
certain limitations like lack of regular updates to word list for slang
words, proper names; it can autocorrect grammatical errors.
     - Data intensive approach - Corpus consisting of compilation of
text is prepared. This has certain advantages like language-specific
dictionary is not needed. It can show words in context unlike Dictionary
approach with does word by word checks.
         - Speech Recognition / Speech to text
         - Its hard because,
             - Speech is analog and each person’s speech is a little bit
different, whereas every typist
             who transposes the “ie” in “belief” ends up with exactly
the same result, “beleif.”
             - Speech has systematic variation due to different accents,
mixed language, speech
             impediments, random variation due to background noise, and
multiple people speaking
             at once.
             - Speech has ambiguity due to homophones as well as the
absence of capitalization and
             punctuation.
             - Transcription errors can be distracting to users, but are
usually not life-threatening. Risks
             related to errors, could prevent ASR’s use in applications
where an error would cause
             great harm.
         - This area is dominated by neural networks. They can learn to
compensate for accents and user-supplied corrections to system errors.
     - Music Recommendation
         -  These systems recommend a user's next song, movie, book,
app, or romantic partner.
         - The recommendation system builds a model from three types of
data: a song's waveform, a song's metadata (title, artist, genre,
composer, date recorded, length, etc.), and listener reactions. A
“reaction” may be passively listening to the currently playing song, or
it may be actively starting, skipping or replaying a song, or rating it
with a star or a thumbs down.A song's waveform can be analyzed for
tempo, beat, timbre, and other factors. The system can recommend a song
with similar features to songs that the user has previously liked or,
for variety, perhaps recommend a contrasting song. The recommendations
can be specialized for activity or time of day; perhaps fast, energetic
songs for exercising and slow mellow songs at the end of the day.
Metadata can be applied in many ways and even extended to permit
creation of predictive,semantic relations between its entities.
         - Collaborative filtering builds on this idea to examine the
songs a listener has liked (or disliked), and compares them to every
other listener’s reactions. When it finds a similar history, the songs
that the user likes can be recommended to each other.
         - How approaches apply in the field of investment management,
             - Momentum investing based on understanding what others are
doing is analogous to
             collaborative filtering.
             - Fundamental investing based on knowledge of an
investment’s business is analogous to using semantic knowledge.
             - Technical investing based on raw stock prices and market
volumes is analogous to musical signal analysis.
     - Protein folding
         - Healthcare
         - Prediction about patients more  at risk of developing
diseases so as to benefit from preventive actions.



- Types of databases and related industries/use cases
     - Relational - Lift and shift, Finance, ERP , CRM
     - Key-value - Real-time bidding, shopping cart, social , product
catalog, customer preferences
     - Document - Content Mgmt, Personalization, Mobile
     - In-memory - Leaderboards, real-time analytics, caching
     - Graph - Fraud detection, social networking, recommendation engine
     - Time-series - IoT, event tracking
     - Ledger - System of records, supply chain, healthcare,
registrations, financial.




- HTTP/3
     - TCP has been cornerstone protocol and http runs on top of it.
     - QUIC is intended to replace TCP and HTTP/3 is small adaptation of
HTTP/2 to run top of it.
     - QUIC is a generic transport protocol which can be used for HTTP.
It runs on top of UDP. QUIC essentially reimplements almost all features
that make TCP such a powerful and popular (yet somewhat slower) protocol
     - HTTP/3 isn’t magically faster than HTTP/2 just because we swapped
TCP for UDP.
     - QUIC deeply integrates with TLS.
     - QUIC supports multiple independent byte streams.
     - QUIC uses connection IDs. Faster connection setup
     - QUIC uses frames.
     - QUIC is more secure as its not possible to transport cleartext

- Data oriented programming
     - `lscpu` command shows info about CPUs
     - Each CPU Core,
         - Has L1 cache
         - May share L2 cache with other cores
         - shares L3 Cache with all other CPU cores
         - L1 is fastest
     - All operations between Core and L1/L2/L3 cache are way faster
than accessing main memory
     - Crux is "Identify where you have many objects in memory and make
the size of each object smaller
     - Every construct (e.g. struct) has natural alignment and size.
     - Strategies to reduce memory footprint,
     - 64 bit CPUs can access more RAM but they also consume more memory
(for e.g. 32 bit for pointer whereas its 16-bit on 32-bit CPUs).
Consider avoiding pointers and use indexes.
     - store boolean out of band. (out of struct)
     - Eliminate padding with having struct of Arrays.
     - Store sparse data in separate hashmap than as part of struct.

- On Estimation
     - estimation is valuable when it helps you make a significant decision.
     - Estimation is useful when it helps with coordination within teams

- Vaccum in PostgreSQL
     - Postgres uses Multiversion Concurrency Control (MVCC) to
guarantee isolation while providing concurrent access to data. This
means multiple versions of a row can exist in the database
simultaneously. So, when rows are deleted, older versions are still kept
around, since older transactions may still be accessing those versions.
Once all transactions which require a row version are complete, those
row versions can be removed. This can be done by the VACUUM command.

- Unix Philosophy,
     1. Make each program do one thing well. To do a new job, build
afresh rather than complicate old programs by adding new “features”.
     1. Expect the output of every program to become the input to
another, as yet unknown, program. Don’t clutter output with extraneous
information. Avoid stringently columnar or binary input formats. Don’t
insist on interactive input.
     1. Design and build software, even operating systems, to be tried
early, ideally within weeks. Don’t hesitate to throw away the clumsy
parts and rebuild them.
     1. Use tools in preference to unskilled help to lighten a
programming task, even if you have to detour to build the tools and
expect to throw some of them out after you’ve finished using them.
     1. In Unix, file descriptor is an interface which can be used to
represent things like actual file on filesystem, Communication channel
to other process, a device driver, a TCP socket etc.

- Quantum resistant Encryption
     - Problem: Quantum computers will be able to break current
cryptography schemes (mainly asymmetric encryption, like RSA) easily.
     - Solution: Use Lattice-based (a mathematical concept) Encryption,
which is currently believed to be hard for quantum computers to solve
efficiently.
     - In Sum: Quantum computers are becoming an imminent problem. We as
developers need to start thinking about implementing post-quantum
cryptography algorithms to protect them now before it’s too late.
     - Prepare for the future: Post-quantum cryptography is around the
corner (Q-day), and starting to spread awareness and implementing strong
encryption mechanisms today is important for that future.
     - Hidden advancements: The biggest quantum computer we know about
is currently IBM’s Eagle with 127 stable qbits, planning to reach 433 in
2022. The question is, what about bad actors and rogue nation-states
working on quantum computers we don’t know about? They might reach
quantum supremacy a lot sooner than we anticipate.
     - Hack now, decrypt later: There are threat actors that save
ciphertexts from hacked targets right now, to later decrypt them with
quantum computers. This means that sensitive information sent today is
still prone to attack.
     - Most promising: At the moment, lattices seem like the best
candidates to secure against quantum computers

- Distributed Systems
     - The closer the processing and caching of your data is kept to its
persistent storage, the more efficient your processing, and the easier
it will be to keep your caching consistent and fast. Networks have more
failures and more latency than pointer dereferences and fread(3).
     -  Extract services. “Service” here means “a distributed system
that incorporates higher-level logic than a storage system and typically
has a request-response style API”. Be on the lookout for code changes
that would be easier to do if the code existed in a separate service
instead of in your system. An extracted service provides the benefits of
encapsulation typically associated with creating libraries
     - "Feature flags” are a common way product engineers roll out new
features in a system. Feature flags are typically associated with
frontend A/B testing where they are used to show a new design or feature
to only some of the userbase.
     - Exposing metrics (such as latency percentiles, increasing
counters on certain actions, rates of change) is the only way to cross
the gap from what you believe your system does in production and what it
actually is doing.
     - Find ways to be partially available. Partial availability is
being able to return some results even when parts of your system is failing.
     - Implement backpressure throughout your system. Backpressure is
the signaling of failure from a serving system to the requesting system
and how the requesting system handles those failures to prevent
overloading itself and the serving system. Designing for backpressure
means bounding resource use during times of overload and times of system
failure. This is one of the basic building blocks of creating a robust
distributed system.

- Javascript on web,
     - JavaScript is known as a “render-blocking” resource. This means
when a browser encounters JavaScript it goes through a multistep process
which involves it being downloaded, then uncompressed, before it’s
finally parsed and executed. This all happens within a device's
available Central Processing Unit (CPU) and memory. These tasks can be
very slow and energy intensive depending on the device and connection.
     - Images and image data aren't “render-blocking”, meaning parts of
the webpage can be painted to the page while additional image data is
being downloaded in parallel. Therefore, a 32 Kb image has much less of
a performance impact than 32 Kb of compressed JavaScript. This is
especially true for users on low specification devices that are
generally slower, older and less expensive.

- Cassandra - NOSQL Database
     - Features
         - Linear Scalability
         - Automatic Failover
         - Low Maintenance
         - Predictable Performance
     - Data Modelling
         - KKV Store
             - The first K is the partition key and is used to determine
which node the data lives on and where it is found on disk. The
partition contains multiple rows within it and a row within a partition
is identified by the second K, which is the clustering key. The
clustering key acts as both a primary key within the partition and how
the rows are sorted.
         - Schemas are cheap to alter without performance penalty
     - it trades strong consistency for availability
     - Reads are expensive than writes
     - Scylla, a Cassandra compatible database written in C++

- On Minimum Viable Product
     - Lets you objectively measure customer response fast and then tweak
     - so cheap and fast to build, you can try lots of different ones,
add and remove advertised features, and see how that changes user responses
- Market Niche -  If you can name a conference attended by a particular
group of people, that group is a market niche.

- Triggers for choosing service boundaries,
     - Security isolation could be one of the trigger for splitting
functionalities in services.
     - Monolith taking long time to startup. This makes upgrades
painful. so you might want to split out the slow part to make upgrading
other things go faster.
     - Do some parts scale differently from other parts?
     - Do expensive requests need to be run with less parallelism? - If
solution is to use messaging i.e. relaying messages through queue/broker
then be vary of Queue Explosion which generates heavy load on message
brokers. Alternatives are HTTP based (REST, gRPC) services or Messaging
based on peer to peer or routed protocols (where instead of sending
messages to a broker which persists messages, messages are either sent
directly to another consumer via a point-to-point network connection or
are sent to a router which immediately sends the message to a consumer)
using say ZeroMQ or Apache QPID Proton

- System Characteristics (Quality Attribute Requirements)
     - Concurrency—relating to the number of concurrent users, sensors,
and other devices that create events to which the product must respond.
     - Throughput—relating to the volume of transactions or data that
the product must be able to process over a defined time period.
     - Latency and responsiveness—relating to how quickly the product
must respond to events.
     - Scalability—relating to the ability of a system to handle an
increased workload by increasing the cost of the system, general in a
near-linear relationship.
     - Persistency—relating to the throughput and structure (or lack
thereof) of data that must be stored and retrieved by the product. Often
includes decisions about different kinds of data storage technologies
(e.g. SQL DBMS, NoSQL DBMS, etc.).
     - Security—relating to how the product will protect itself from
unauthorized use or access to product data, by achieving
confidentiality, integrity, and availability.
     - Monitoring—relating to how the product will be instrumented so
that the people who support the product can understand when the product
starts to fail to meet QARs and prevent critical system issues.
     - Platform—relating to how the product will meet QARs related to
system resource constraints such as memory, storage, event signaling,
etc. For example, real-time and embedded products (such as a digital
watch, or an automatic braking system) have quite different constraints
than cloud-based information systems.
     - User interface—relating to decisions made about how the product
will communicate with users; for example, virtual reality interfaces
have quite different QARs than 2-dimensional graphical user interfaces,
which have quite different QARs than command-line interfaces. These
decisions may affect other QARs noted above. (GUI, VR, command line, or
other kinds of interfaces.)

- Networking
     - MAC addresses: All devices that people use to ac- cess the
Internet have been assigned an identifier by the device manufacturer.
This is the media access control (MAC) address, sometimes also called
hard- ware address or burned-in address. The standards for MAC addresses
are set by the Institute of Electri- cal and Electronics Engineers
(IEEE), a US-based pro- fessional association. The most used addresses
are 48-bit long, which allows for 248, i.e., more than 281 trillion,
possible MAC addresses
     - Radio Access Networks: This term is specifically used for the
radio connection of mobile phones to antennas that are connected to the
wired core net- work of mobile network operators and the Internet at
large. RAN standards are ordered into generations (e.g., 3G, 4G, 5G) and
set by the industrial partner- ship 3GPP and the ITU.
     - Wide Area Networks (WANs): Companies may think that the public
packet-switched Internet is too unre- liable, insecure, and
path-agnostic for connecting their sites. Hence, they may use a layer 2
WAN to connect different locations of offices, production sites, and
stores belonging to the same company. One option for a WAN is for
companies to lease a private communications circuit from an ISP, which
reserves a specific amount of bandwidth for them. The downside of leased
lines is that they are expen- sive. An alternative is the use of
multiprotocol label switching (MPLS). This is a “layer 2.5” protocol
that adds an additional label on IP-packets which con- tains a
predetermined route.A more recent alternative is the use of
software-de-fined networking.66 Its key feature is that the rules for
how to forward data packets are computed in and then distributed from a
central location to switches or routers in the entire network. In its
ter- minology, the forwarding rules are the control plane, whereas the
switches or routers that implement the forwarding are called the data
plane. A software-de- fined WAN (SD-WAN) is generally cheaper than MPLS.
     - Network Layers
         - IPV4 (32) bit that can have upto 4.3 billion unique addresses
while IPv4(128) bit can have 340 trillion trillion trillion unique IPv6
addresses.

- Stable Diffusion
     - Open source image synthesis model that generates images basis
natural language
     - Can be run on PC with GPU
     - Uses technique called Latent diffusion - the model learns to
recognize familiar shapes in a field of pure noise, then gradually
brings those elements into focus if they match the words in the prompt.
     -  the model associates words with images thanks to a technique
called CLIP (Contrastive Language–Image Pre-training), which was
invented by OpenAI
     - As per authors, Stable diffusion will run on smartphones in future.

- Aspects in Building Systems
     -    Defining Requirements - work with the Product Manager to
understand what problem they want to solve; maybe you’ll have some ideas
on how to solve it with much lower effort?
     -    Defining NFR’s - talk to your PM about the non-functional
requirements - how many users should the System handle, what are the
requirements for performance, throughput, latency? Are there any
security or compliance considerations? Do we need auditing? What’s the
desired availability?
     -    Planning Iterations - work with your team to propose an
implementation plan; make sure you define small, demoable milestones, so
that you can start delivering value ASAP; agree with the PM on the
milestones.
     -    Determining Dependencies - make sure you identified all the
dependencies outside of your team and work with your EM or with the
teams directly to get some ETA’s for them. Adjust your milestones
accordingly.
     -    Testing - depending on how your company operates, decide on
your testing strategy with your team or with the QE team. Agree on the
quality threshold needed for the rollout (e.g. no unresolved Major bugs
or test coverage above X%).
     -    Deployment - work with your team to decide how the system will
be deployed. Do you need some new infrastructure for it or can you reuse
the existing? If you need a lot of it, what will be the cost?
     -    Observability - decide how are you going to monitor the health
of the system and set up processes for solving production issues (e.g.
team on-call). Use a third-party solution (like Sumo Logic) to set up
monitors and dashboards for that purpose.
     -    Rollout Communication - once you agree on a rollout date with
your team and the PM, make sure that all stakeholders are aware of it.
Check whether any documentation changes are required.
     -    Measuring Success - decide on metrics that will tell you
whether the project was a success. Is anyone using the new system? Do
users manage to accomplish their tasks? You can leverage your
Observability suite for this purpose.

- Code Hale on Organizations,
     - Centralize Decision making and vision
     - Create a small group of people who are on same page, open to new
ideas,be imperical, have small meetings and make decision quickly.
     - then decentralize for execution. give developers autonomy.
     - avoid exponential bikeshading

- Statistics
     - Median
         - If set of values are odd then, the middle value when ordered
is Median
         - If set of values are even then, the average of 2 middle
values is Median
         - Median is not affected by outliers (Extremes in data set)
     - Mean
         - Some of all the values in set divided by number of values
         - Mean gets impacted by outliers.
     - Standard deviation - measures the average distance , the data
values are, from the mean (average).
         - It can not be negative
     - Rounding rule - Always round the number to one more additional digit.
     - Standard deviation
         - Data value outside of 3 times standard deviation (from mean)
is extremely rare.
     - Z-score - # of standard deviations away from the mean a data
value is.
     - Quartiles
         - 1st Quartile - bottom 25% of ordered set
         - 2nd Quartile - bottom 50% (median) of ordered set
         - 3rd quartile - bottom 75% of ordered set (excluding median)
     - Percentiles - separates data into hundred parts
         - percentile of x = [count (values)  less than x/ total # of
values]*100
     - Probability
         - Observed probability (What did happen) - Estimated based on
observation
         - Classical probability (what should happen) - Based on change
of an event occuring.
         - Subjective Probability - Educated guess. No data available.


- WebAuthn is a protocol for using hardware devices in order to
authenticate users by proof of ownership. The basic idea is that you
have a hardware security module of some kind (such as an iPhone’s Secure
Enclave or a Yubikey) that contains a private key, and then the server
validates signatures against the public key of the device to
authenticate sessions. It is also set up so that phishing attacks are
impossible to pull off, each WebAuthn registration is bound to the
domain it was set up with. A keypair for xeiaso.net cannot be used to
authenticate with evil-xeiaso.net. The user experience is fantastic. A
website makes a request to the authentication API and then the browser
spawns an authentication window in such a way that cannot be replicated
with web technologies. The browser itself will ask you what
authenticator you want to use (usually this lets you pick between an
embedded hardware security module or a USB security key) and then
proceed from there. It is impossible to phish this. Even if the visual
styles were copied, the authenticator will do nothing to authenticate
the browser!
     - An authenticator is a map from (RP ID, user ID) pairs, to public
key credentials.
     - An authenticator, traditionally, is the physical thing that holds
keys and signs stuff. Security keys are authenticators
     - An RP ID identifies a website. It's a string that contains a
domain name. (In non-web cases, like SSH, it can be a URL, but I'm not
covering them here.)

- Queues
     - Help off-load tasks from the critical path
     - Transform, filter and fan-out messages thus enabling parallel
processing
     - Cost for queueing,
         - To effectively deliver a message, it usually takes three
operations: one write, one read, and one acknowledgement. You can
estimate your usage by considering the cost of messages delivered by
multiplying cost per operation by 3.

- Characteristics of Distributed System
     - Communication - Reliable links, secure links, discovery, APIs.
     - Coordination - System models, failure detection, time, leader
election, replication, coordination avoidance, transactions.
     - Scalability - HTTP caching, content delivery networks,
partitioning, file storage, data storage, caching, microservices,
control panes and data panes, messaging.
     - Resiliency - Common failure causes, redundancy, fault isolation,
downstream resiliency, upstream resiliency.
     - Maintainability - Testing, continuous delivery and deployment,
monitoring, observability, and manageability.

     - Downstream resiliency
         - Timeout - As a rule of thumb, always set timeouts when making
network calls, and be wary of third-party libraries that make network
calls but don’t expose settings for timeouts.
         - Retries with exponential back-off

     - Upstream resiliency
         - Load shedding - Rejecting the request(s) once beyond server's
capacity.
         - Load leveling - Introducing messaging channel between client
and service to decouple load on Service. However, this works in cases
where client is not expecting immediate response.
         - Load-shedding and load leveling don’t address an increase in
load directly but rather protect a service from getting overloaded.
         - Rate limiting

- Measures for resilient systems by Shopify
     - Ensure that timeout is specified for network request like over
HTTP or TCP. Try to lower them whenever possible
     - Use circuit breakers
     - Monitoring and alerting for below,
         - Latency: the amount of time it takes to process a unit of
work, broken down between success and failures. With circuit breakers
failures can happen very fast and lead to misleading graphs.
         - Traffic: the rate in which new work comes into the system,
typically expressed in requests per minute.
         - Errors: the rate of unexpected things happening. In payments,
we distinguish between payment failures and errors. An example of a
failure is a charge being declined due to insufficient funds, which
isn’t unexpected at all. HTTP 500 response codes from our financial
partners on the other hand are. However a sudden increase in failures
might need further investigation.
         - Saturation: how much load the system is under, relative to
its total capacity. This could be the amount of memory used versus
available or a thread pool’s active threads versus total number of
threads available, in any layer of the system.
     - Implement structured logging - Use co-relation id for every request.


- Approach to Selecting/Upgrading the technology/tool
     - Always Measure first
         - Define your service level objectives (SLOs) and measure them
via an observability system like Datadog. You usually want, at a
minimum, an availability SLO (i.e., 99.9% of requests succeed) and a
latency SLO (p99 latency is < 1s).
         - Define your load objective. This is just the number of users
you want to be able to support at a given time. If you’re launching a
new product, ask marketing how much traffic they expect on launch day
and double it. If there isn’t going to be a splashy launch, try to
project out where you’ll be in, say, one year, and add a 10-20% buffer.
         - Run a load test by spinning up a test cluster and writing
some scripts to simulate real usage. Keep fixing bottlenecks and
re-running load tests until you hit your objective.

- Typical Archetypes in Software engineering,
     - The Team Lead guides the approach and execution of a particular
team. Most frequently they partner closely with a single manager, but
sometimes they partner with two or three managers within a focused area.
     - The Architect is responsible for the direction, quality and
approach within a critical area, both today and stretching into the
multi-year future horizon. They combine a deep knowledge of technical
constraints, user needs, and organization level leadership.
     - The Right Hand is a partner and an extension of an
executive-level manager, borrowing their scope and authority to operate
particularly complex organizations. They provide additional leadership
bandwidth to leaders of large-scale organizations.

     - The Solver digs deep into arbitrarily complex problems and finds
an appropriate path forward. Some focus on a given area for long
periods, others bounce from hotspot to hotspot as guided by
organizational leadership.

- What is Wine? wine is a “dynamic loader” for Windows executables. It’s
a native Linux binary, hence it can just run normally, and it knows how
to deal with EXE and DLLs.

- Pschycology for Software Development
     - Spend more time to consider,
         - the financial costs
         - the payoff periods
         - the opportunity costs
     - focused on work that paid off sooner than later - engineers
should avoid work that pays off too far into the future. This mistake
happens particularly when it comes to engineering migrations.I have a
rule that any engineering work must have a minimum of 2x of the rewards
to justify the cost.
     - calculated if the work was worth their time or not before diving
into it
     - weighed the opportunity costs of their work

- Approach for modernization of problematic source code
     - Get testing in place ...if not already available
     - use Strangler pattern - one piece at a time

- RabbitMQ Concepts,
     -    Exchange: this is the entry point to which messages are published.
     -    Queue: exchanges are linked to one or more message queues. A
message queue is exactly as it says.
     -    Binding: the connection between the exchange and the queues.
Bindings can have binding keys.
     -    Routing policy: the strategy on how the exchange handles routing.
         -     Fanout: sends all inbound messages to the exchange and
all queues bound to it, regardless of routing keys. This approach
ignores routing keys.
         -     Direct: the message is sent to queues for which the
routing key matches the binding key.
         -     Topic: allows wildcat matching between the routing key
and the binding key. For example, you could set a topic of “tasks” and
this would route to both the “tasks.important” and “tasks.unimportant”
bindings.
         -    Headers: uses the header of a request to decide routings.
     - Rabbit's main problem is its handling of partitions and general
cluster interruptions.
         - recovering from a dead cluster usually involves resetting it
completely
         - creating/destroying  a queue and bindings in RabbitMQ is slow
and expensive.

- Big Data
     - When the cost of keeping data around is less than the cost of
figuring out what to throw away.
     - Keep questioning whether you really need so much data
     - Data is a liability.
         - Non-compliance to regulatiohs (keeping data beyond what is
allowed) can attract penalties/law suits.
         - Old data contributes to Big Data. If you are keeping around
old data, it is good to understand why you are keeping it.
         - Are you really generating a huge amount of data?
             - If so, do you really need to use a huge amount of data at
once?
             - If so, is the data really too big to fit on one machine?
             - If so, are you sure you’re not just a data hoarder?
             - If so, are you sure you wouldn’t be better off summarizing?


- Use cases for Kafka and RabbitMQ
     - Kafka
         -Pub/Sub Messaging. Kaˆa can be a good match for the pub/sub
use cases that exhibit the following properties: (i) if the routing
logic is simple, so that a Kaˆa “topic” concept can handle the
requirements, (ii) if throughput per topic is beyond what RabbitMQ can
handle (e.g. event €rehose).
         - Scalable Ingestion System. Many of the leading Big Data
processing platforms enable high throughput processing of data once it
has been loaded into the system. However, in many cases, loading of the
data into such platforms is the main boŠleneck. Kaˆa o‚ers a scalable
solution for such scenarios and it has already been integrated into many
of such platforms including Apache Spark and Apache Flink, to name a few.
         - Scalable Ingestion System. Many of the leading Big Data
processing platforms enable high throughput processing of data once it
has been loaded into the system. However, in many cases, loading of the
data into such platforms is the main boŠleneck. Kaˆa o‚ers a scalable
solution for such scenarios and it has already been integrated into many
of such platforms including Apache Spark and Apache Flink, to name a
few. 6Recent versions of Kaˆa have a notion of federation, but more in
the sense of cross-datacenter replication.
         - Data-Layer Infrastructure. Due to its durability and ecient
multicast, Kaˆa can serve as an underlying data infrastructure that
connects various batch and streaming services and applications within an
enterprise.
         - Capturing Change Feeds. Change feeds are sequences of update
events that capture all the changes applied on an initial state (e.g. a
table in database, or a particular row within that table).
Traditionally, change feeds have been used internally by DBMSs to
synchronize replicas. More recently, however, some of the modern data
stores have exposed their change feeds externally, so they can be used
to synchronize state in distributed environments. Kaˆa’s log-centric
design, makes it an excellent backend for an application built in this
style.
         - Stream Processing. Starting in Kaˆa version 0.10.0.0, a
light-weight stream processing library called Kaˆa Streams is available
in Apache Kaˆa to perform stateful and fault-tolerant data processing.
Furthermore, Apache Samza, an open-source stream processing platform is
based on Kaˆa.
     - RabbitMQ
         - Pub/Sub Messaging. Since this is exactly why RabbitMQ was
created, it will satisfy most of the requirements. Œis is even more so
in an edge/core message routing scenario where brokers are running in a
particular interconnect topology.
         - Request-Response Messaging. RabbitMQ offers a lot of support
for RPC style communication by means of the correlation ID and direct
reply-to feature, which allows RPC clients to receive replies directly
from their RPC server, without going through a dedicated reply queue
that needs to be set up. Hence, RabbitMQ, having speci€c support to
facilitate this usecase and stronger ordering guarantees, would be the
preferred choice.
         - Operational Metrics Tracking. RabbitMQ would be a good choice
for realtime processing, based on the complex €ltering the broker could
provide. Although Kaˆa would be a good choice as an interface to apply
o„ine analytics, given that it can store messages for a long time and
allows replay of messages. Œroughput per topic could be another
criterion to decide.
         - Underlying Layer for IoT Applications Platform. RabbitMQ can
be used to connect individual operator nodes in a dataƒow graph,
regardless of where the operators are instantiated. A lot of the
features of RabbitMQ directly cover platform requirements: (i) sub 5ms
latency for the majority of the packets, throughput up to 40Kpps for
single nodes, (ii) excellent visibility on internal metrics and easy
test and debug cycles for dataƒow setup through the web management
interface, (iii) support for the MQTT protocol, (iv) sophisticated
routing capability allows to expose packet €lters as part of an
associated data processing language, and (v) the possibility to handle a
very large number of streams that all have rather small throughput
requirements, with a large number of applications all interested in
di‚erent small subsets of these streams. - Information-centric
Networking. Œis is essentially a game on the capabilities of the
architecture to intelligently route packets. Œerefore, RabbitMQ would be
the preferred choice, maybe even with a speci€c exchange that
understands the link between routing key and destination.

     - Domain driven design basics,
         - Bounded contexts are a central pattern in Domain-Driven
Design. They provide a way of tackling complexity in large applications
or organizations by breaking it up into separate conceptual modules.
Each conceptual module then represents a context that is separated from
other contexts (hence, bounded), and can evolve independently. Each
bounded context should ideally be free to choose its own names for
concepts within it, and should have exclusive access to its own
persistence store
         - The composition of domain objects:
             •    Entity: a domain object that has ID and life cycle.
             •    Value Object: a domain object without ID. It is used
to describe the property of Entity.
             •    Aggregate: a collection of Entities that are bounded
together by Aggregate Root (which is also an entity). It is the unit of
storage.
         - The life cycle of domain objects:
             •    Repository: storing and loading the Aggregate.
             •    Factory: handling the creation of the Aggregate.
         - Behavior of domain objects:
             •    Domain Service: orchestrate multiple Aggregate.
             •    Domain Event: a description of what has happened to
the Aggregate. The publication is made public so others can consume and
reconstruct it.

* Characteristics of Common distributed systems
     * Outsourced heaps
         * Redis, memcached, ...
         * Data fits in memory, complex data structures
         * Useful when your language's built-in data structures are
slow/awful
         * Excellent as a cache
         * Or as a quick-and-dirty scratchpad for shared state between
platforms
         * Not particularly safe
     * KV stores
         * Riak, Couch, Mongo, Cassandra, RethinkDB, HDFS, ...
         * Often 1,2,3 dimensions of keys
         * O(1) access, sometimes O(range) range scans by ID
         * No strong relationships between values
         * Objects may be opaque or structured
         * Large data sets
         * Often linear scalability
         * Often no transactions
         * Range of consistency models--often optional
linearizable/sequential ops.
     * SQL databases
         * Postgres, MySQL, Percona XtraDB, Oracle, MSSQL, VoltDB,
CockroachDB, ...
             *        Defi*ned by relational algebra: restrictions of
products of records, etc
             *        Mode*rate sized data sets
             *        Almo*st always include multi-record transactions
             *        Rela*tions and transactions require coordination,
which reduces scalability
             *        Many* systems are primary-secondary failover
             *        Acce*ss cost varies depending on indexes
             *        Typically strong consistency (SI, serializable,
strict serializable)
     *   Search
         *  Elasticsear*ch, SolrCloud, ...
         * Documents r*eferenced by indices
         * Moderate-to*-large data sets
         * Usually O(1*) document access, log-ish search
         * Good scalab*ility
         * Typically w*eak consistency
     * Coordination services
         *  Zookeeper, etcd, Consul, ...*
         * Typically strong (sequential or l*inearizable) consistency
         * mall data sets
         * Useful as a coordination primitive for stateless services
     * Streaming systems
         * Storm, Spark...
         * Usually custom-designed, or toolkits to build your own.
         * Typically small in-memory data volume
         * Low latencies
         * High throughput
         * Weak consistency
     * Distributed queues
         * Kafka, Kestrel, Rabbit, IronMQ, ActiveMQ, HornetQ, Beanstalk,
SQS, Celery, ...
         * Journals work to disk on multiple nodes for redundancy
         * Useful when you need to acknowledge work now, and actually do
it later
         * Send data reliably between stateless services
         * The only one I know that won't lose data in a partition is Kafka
         * Maybe SQS?
         * Queues do not improve end-to-end latency
         * Always faster to do the work immediately
         * Queues do not improve mean throughput
         * Mean throughput limited by consumers
         * Queues do not provide total event ordering when consumers are
concurrent
         * Your consumers are almost definitely concurrent
         * Likewise, queues don't guarantee event order with async consumers
         * Because consumer side effects could take place out of order
         * So, don't rely on order
         * Queues can offer at-most-once or at-least-once delivery
         * Anyone claiming otherwise is trying to sell you something
         * Recovering exactly-once delivery requires careful control of
side effects
         * Make your queued operations idempotent
         * Queues do improve burst throughput
         * Smooth out load spikes
         * Distributed queues also improve fault tolerance (if they
don't lose data)
             * If you don't need the fault-tolerance or large buffering,
just use TCP
             * Lots of people use a queue with six disk writes and
fifteen network hops where a single socket write() could have sufficed
         * Queues can get you out of a bind when you've chosen a poor
runtime

- P2PE (Point to point Encryption) -  is an encryption standard
established by the Payment Card Industry Security Standards Council. It
stipulates that cardholder information is encrypted immediately after
the card is used with the merchant’s point-of-sale terminal and isn’t
decrypted until it has been processed by the payment processor.
     - Encryption of card information at the POI/payment terminal
     - Secure management of all encryption and decryption devices
     - P2PE applications at the POI
     - Secure management of the description environment and decrypted data
     - Use of encryption methodologies and cryptographic key operations


- PageRank Algorithm - Each page receives a ranking based on the number
and importance of other pages that are linking to it. The pages with a
higher page rank, increase the ranking of the page they link to more
than the pages with a lower rank. In graph database terminology, the
PageRank algorithm is used to measure the importance of each node based
on the number of incoming relationships and the rank of the related
source nodes. What the PageRank algorithm actually outputs is a
probability distribution that represents the likelihood of visiting any
particular node by randomly traversing the graph.

- Apache Spark
     - Designed to work with distributed file system like HDFC or GFS.
Spark generates On the fly java byte code that executes on nodes/Workers
and target partitioned/sharded file (i.e. chunk of file being operated
upon).
     - Primarily aimed at big data use cases.
     - It also manages node failures.
     - Suitable for batch processing involving hugh data.
     - Evolution of Map-Reduce. Also provides some streaming support.
     - Can use languages like Scala to write jobs.
     - Delayed execution like reading the file only when processing
instructions are executed on it.


- ChatGPT
     - is always fundamentally trying to do is to produce a “reasonable
continuation” of whatever text it’s got so far
     - It does this (i.e. picking up next word) based on probabilities
of single words and n-grams. However, it is very difficult to get
miningful english text only basis this.
     - There are about 40000 reasonably commonly used words in english.
Using large corpus of english text, it is possible to get frequency of
occurance of each word.Using these frequencies, one can start
constructing sentenses.
     - While finding out next words with top probabality, a factor
called temperature is introduced to indicate whether to always pickup
next word with highest probability or apply temperature and choose one
with slightly lower probabilty.

   - Initial prompts to system design problems tend to be
intentionally light on detail. Do not extrapolate from it basis
assumptions but Ask for details.
     - You can never go wrong by making the end user the driving force
in your design.
     - Design Concepts
         - API - 3 Architectural styles - REST, RPC and GraphQL
         - Databases
             - SQL Databases
                 - Preferred when consistency is important
                 - Slower write but faster query - B-trees based storage
is slower while writing (Data is stored in a B-Tree structure that
divides the available space into fixed-size blocks called pages;each
page is traditionally 4 KB in size and maps onto a specific sector of
hard drive space. Once a page becomes too large, this page is
repartitioned to point to new children pages and the values get sorted
into them.)
                 -
             - NoSQL Databases
                 - Different types like key/value,Document, Columnar etc.
                 - Do not require fixed Schemas
                 - Faster write but slower query -  since they use log
structure that only appends data.
         - Authentication
             - Session vs JWT - While a session token is an opaque
string that means nothing without access to the session database, a JWT
explicitly encodes the user's access.
         - Message Queues
             - Characteristics
                 -     Guaranteed delivery.
                 - No duplicate messages are delivered.
                 - Ensure that the order of messages is maintained.
                 - At least once delivery with idempotent consumers.
         - Replication
             - Replica: Copy of data
             - Leader: Machine that handles write requests to the data
store.
             - Followers: Machines that are replicas of the leader node,
and cater to read requests.

- Web fingerprinting - Fingerprinting is a more sophisticated approach
to identify a user among millions of others. It works by studying your
web browser and hardware configuration. Many websites use a
fingerprinting library to generate a unique ID. This library collects
data from multiple JavaScript APIs offered by your web browser. For
example, websites can see web browser version, number of CPUs on your
device, screen size, number of touchpoints, video/audio codecs,
operating system and many other details that you would not want a
typical news website to see. All of these values are combined to
generate a unique ID. Surprisingly, each user’s device and browser
specifications differ so much that they get a unique ID among millions.

- GPU - Graphics processing units or GPUs are dedicated highly parallel
hardware accelerators that were originally design to accelerate the
creation of images. More recently, folks have been looking at GPUs to
accelerate other workloads like Database analytics and transaction
processing (OLTP). Although GPUs have little or no use for OLTP style
workloads, they have been shown to accelerate analytics.

- Vector Databases
     - Vectors are mathematical objects , represented as arrays of
numbers, where each element corresponds to a specific dimension or
component.
     - Vectors are primarily used for semantic search like similarity,
clustering and classification
     - Each vector represents mathematical arrays of numbers that
represent the characteristics or attributes of data points.
     - They are ideal for pattern detection, predictive analytics.
     - Large language models such as GPT-3/4, LLaMA and PaLM work in
terms of tokens. They take text, convert it into tokens (integers), then
predict which tokens should come next.
     - Need from Generative AI perspective,
       - Embeddings
         - Embeddings are vector representations of data points that
capture their semantic meaning or relationships.Embeddings represent any
content into array of floating point numbers which are always of same
length irrespective of the length/size of the original content.
         - Data embeddings convert objects like users, products,
documents, and more into dense numerical vectors.
           -   Image transformer for image to vector
           -   NLP transformer for document to vector
           -   Audio transformer for Audio to vector
         - Because of advancements in LLMs the embeddings we get have a
better “understanding” of your text. This means that querying for the
similarity between those vectors produces much better semantic results
than before
         - Vector databases use algorithms like ANN (Approximate Nearest
Neighbours) so they can facilitate efficient storage, retrieval, and
similarity search operations, rather than relying on exact match or
range queries. This is especially important for recommendation systems
or semantic search, where the nearest or most similar items are as
valuable as exact matches.
         - Popular use cases
           - Personalized recommendations
           - Fraud detection
           - Scientific research
           - Content Moderation

     - Why not RDBMS
             RDBMS excel at handling structured data with a fixed
schema, they often struggle with unstructured or high-dimensional data,
such as images, audio, and text. Traditional databases have not been
designed to efficiently handle the task of searching for similar items
in a large dataset, specifically high-dimensional vector data which
makes them perform worse at scale.
             There are extensions being made available (e.g. pgvector,
RediSearch ) that extend RDBMS to support Vector storage/search
functionality

     - Dimensionality reduction - techniques aim to reduce the number of
dimensions in a vector representation while preserving the essential
information. This can help alleviate the challenges associated with
high-dimensional data.
         - Feature selection - Selecting subset of features appropriate
for task
         - Hashing - lower dimensional representation using hash
         - Principal Component Analysis (PCA): A statistical technique
that identifies the principal components or directions of greatest
variance in the data
     - Distance metrics are mathematical tools used to define and
measure the way we compute the
         similarity (or dissimilarity) between vectors. They are crucial
for operations in vector databases
           - Euclidean distance - Measures the straight-line distance
between two points in a vector space.Very sensitive to the magnitude of
vectors
           - Manhattan Distance - Use Manhattan distance when you want
to focus on how much each feature is different, not just how different
they all are together. Useful for financial analysis, image retrieval
           - Cosine distance - Measures the cosine of the angle between
two vectors where a higher cosine value indicates greater similarity.
Useful for text similarity where the frequency of words (term frequency)
is less important than the angle or "direction" of the overall word
           - Jaccard Similarity - used to compute the similarity between
two objects, such as two text documents
     - Similarity search involves locating the closest vectors to the
query vector as per a chosen distance metric.
     - Algorithms
       - KNN - algorithm used in both classification and regression
tasks which
       operates on the principle that similar items exist close to each
other. It calculates the distance between points using methods like
Euclidean, Manhattan, or Hamming distance. The choice of distance metric
depends on the type of data.
       - ANN - technique used to efficiently find points in a large
dataset that are similar,
       but not necessarily identical, to a given query point. Useful in
high-dimensional spaces, where traditional search methods become
intractable due to the curse of dimensionality.
     - Indexes for Vectors
       -  Flat index - Use Flat for small datasets where precision is
critical.
       -  Inverted file index - Use IVF for medium to large datasets
where there's a balance between precision and speed.
       -  ANNOY - Use HNSW or Annoy for very large datasets where query
speed is more important than precision
       -  Product quantization - Use PQ when storage or memory is
limited, as it provides a compressed representation.
       - Hierarchical Navigable Small World (HNSW) -  algorithm is based
on the concept of small world  networks, where most nodes can be reached
from every other by a small number of steps despite the network's large
size.
     - Advantages
             Embeddings generation is relatively cheaper than invoking a
full LLM API call (OpenAI offers an API to generate embeddings for a
string of text using its language model. You feed it any text
information (blog articles, documentation, your company's knowledge
base), and it will output a vector of floating point numbers that
represents the “meaning” of that text.). Querying our embeddings against
our DB is much cheaper. Embeddings still retain some semantic
information about the text, so we could get the best of both worlds.


 - Security - Shared Responsibility. AWS is responsible for securing
base layer (i.e. upto virtualization layer.). Customer is responsible
for securing Operating System (for EC2 VMs), Encrypting data in transit
and at rest,Configuring firewall, User Access Management, Customer Data.
     - AWS Root user
         - Has two sets of credentials
             - 1 - email address and password
             - 2 - Access key (which has 2 parts Acess key ID and Secret
Access key). Recommended to disable/delete this one.
         - Best practices
             - Choose a strong password for the root user.
             - Enable multi-factor authentication (MFA) for the root user.
             - Never share your root user password or access keys with
anyone.
             - Disable or delete the access keys associated with the
root user.
             - Create an Identity and Access Management (IAM) user for
administrative tasks or everyday tasks.
         - Support MFA devices
              - Virtual MFA - Apps like Google authenticator
              - Hardware TOTP token
              - FIDO Security keys
     - AWS Identity and Access Management (IAM) is an AWS service that
helps you manage access to your AWS account and resources. It also
provides a centralized view of who and what are allowed inside your AWS
account (authentication), and who and what have permissions to use and
work with your AWS resources (authorization).
         - IAM is global and not specific to any one Region. You can see
and use your IAM configurations from any Region in the AWS Management Conso
         - IAM is integrated with many AWS services by default.
         - You can grant other identities permission to administer and
use resources in your AWS account without having to share your password
and key.
         - IAM supports MFA. You can add MFA to your account and to
individual users for extra security.
         - IAM supports identity federation, which allows users with
passwords elsewhere—like your corporate network or internet identity
provider—to get temporary access to your AWS account.
         - Any AWS customer can use IAM; the service is offered at no
additional charge.
         - An IAM group is a collection of users. All users in the group
inherit the permissions assigned to the group. This makes it possible to
give permissions to multiple users at once. It’s a more convenient and
scalable way of managing permissions for users in your AWS account. This
is why using IAM groups is a best practice.
         - To manage access and provide permissions to AWS services and
resources, you create IAM policies and attach them to an IAM identity.
Whenever an IAM identity makes a request, AWS evaluates the policies
associated with them.
         - Most policies are stored in AWS as JSON documents with
several policy elements.
         - Best practices
             - Lock down AWS root user
             - Follow the principle of least privilege
             - Use IAM apropriately
             - Use IAM Roles when possible
             - Consider using Identity provider
             - Regularly review and remove unused users, roles etc.
     - AWS EC2
         - To create an EC2 Instance,
             - Hardware specifications: CPU, memory, network, and storage
             - Logical configurations: Networking location, firewall
rules, authentication, and the operating system of your choice
         - Amazon Machine Image (AMI) are bundled operating system
images offered by AWS.
         - EC2 instances are a combination of virtual processors
(vCPUs), memory, network, and, in some cases, instance storage and
graphics processing units (GPUs).
         - Instance families
             - General purpose - Ideal for applications that use these
resources in equal proportions, such as web servers and code repositories
             - Compute Optimized - Well-suited for batch processing
workloads, media transcoding, high performance web servers, high
performance computing (HPC), scientific modeling, dedicated gaming
servers and ad server engines, machine learning inference, and other
compute intensive applications
             - Memory Optimized - Memory-intensive applications, such as
high-performance databases, distributed web-scale in-memory caches,
mid-size in-memory databases, real-time big-data analytics, and other
enterprise applications
             - Accelerated computing - Machine learning, HPC,
computational fluid dynamics, computational finance, seismic analysis,
speech recognition, autonomous vehicles, and drug discovery
             - Storage optimized- NoSQL databases (Cassandra, MongoDB
and Redis), in-memory databases, scale-out transactional databases, data
warehousing, Elasticsearch, and analytics
             - HPC optimized - Ideal for applications that benefit from
high-performance processors, such as large, complex simulations and deep
learning workloads
             - EC2 Instance states,
                 - Pending - Billing has not started
                 - Running - billing begins
                 - Rebooting - reboot operating system
                 - Stopping/Stopped
                 - Terminate - Both public and private IP are lost.
Billing stops.
             - Types of instances
                 - On-demand instances (pay for compute capacity per
hour or per second)
                     - Users who prefer the low cost and flexibility of
Amazon EC2 without upfront payment or long-term commitments
                     - Applications with short-term, spiky, or
unpredictable workloads that cannot be interrupted
                     - Applications being developed or tested on Amazon
EC2 for the first time
                 - Spot instances (for up to 90 percent off the
On-Demand price)
                     - Applications that have flexible start and end times
                     - Applications that are only feasible at very low
compute prices
                     - Users with fault-tolerant or stateless workloads
                 - Savings Plan (low usage prices for a 1-year or 3-year
term commitment to a consistent amount of usage)
                     - Workloads with a consistent and steady-state usage
                     - Customers who want to use different instance
types and compute solutions across different locations
                     - Customers who can make monetary commitment to use
Amazon EC2 over a 1-year or 3-year term
                 - Reserved instances (save up to 75 percent compared to
On-Demand Instance pricing.)
                 - Dedicated hosts -  physical Amazon EC2 server. Ideal
for managing server bound licenses like Windows/Oracle
     - Container Services
         - containers can run on EC2 instances.Amazon ECS is an
end-to-end container orchestration service that helps you spin up new
containers.
         - If you choose to have more control by running and managing
your containers on a cluster of Amazon EC2 instances, you will also need
to install the Amazon ECS container agent on your EC2 instances.
         - Amazon EKS is a managed service that you can use to run
Kubernetes on AWS without needing to install, operate, and maintain your
own Kubernetes control plane or nodes.
         - ECS vs. EKS
             - In Amazon ECS, the machine that runs the containers is an
EC2 instance that has an ECS agent installed and configured to run and
manage your containers. This instance is called a container instance. In
Amazon EKS, the machine that runs the containers is called a worker node
or Kubernetes node.
             - An ECS container is called a task. An EKS container is
called a pod.
             - Amazon ECS runs on AWS native technology. Amazon EKS runs
on Kubernetes.
         - Serverless
             - Characteristics
                 - There are no servers to provision or manage.
                 - It scales with usage.
                 - You never pay for idle resources.
                 - Availability and fault tolerance are built in.
             - Fargate abstracts the EC2 instance so that you’re not
required to manage the underlying compute infrastructure. However, with
Fargate, you can use all the same Amazon ECS concepts, APIs, and AWS
integrations. It natively integrates with IAM and Amazon Virtual Private
Cloud (Amazon VPC).
                 - AWS Fargate is a purpose-built serverless compute
engine for containers. AWS Fargate scales and manages the
infrastructure, so developers can work on what they do best, application
development. It achieves this by allocating the right amount of compute.
This eliminates the need to choose and manage EC2 instances, cluster
capacity, and scaling. Fargate supports both Amazon ECS and Amazon EKS
architecture and provides workload isolation and improved security by
design.
             - AWS Lambda - The Lambda function is the foundational
principle of AWS Lambda.
                 - Concepts
                     - Function - A function is a resource that you can
invoke to run your code in Lambda. Lambda runs instances of your
function to process events.
                     - Triggers describe when a Lambda function should
run. A trigger integrates your Lambda function with other AWS services
and event source mappings. So you can run your Lambda function in
response to certain API calls or by reading items from a stream or queue.
                     - An event is a JSON-formatted document that
contains data for a Lambda function to process. The runtime converts the
event to an object and passes it to your function code. When you invoke
a function, you determine the structure and contents of the event.
                     - The AWS Lambda function handler is the method in
your function code that processes events. When your function is invoked,
Lambda runs the handler method. When the handler exits or returns a
response, it becomes available to handle another event.
         - Which AWS Compute Service Should I Choose For My Use Case?
     - Networking
         -  IP addresses
             - CIDR notation is a compressed way of representing a range
of IP addresses.
                 - It begins with a starting IP address and is separated
by a forward slash (the / character) followed by a number. The number at
the end specifies how many of the bits of the IP address are fixed. In
this example, the first 24 bits of the IP address are fixed. The rest
(the last 8 bits) are flexible.The higher the number after the /, the
smaller the number of IP addresses in your network. For example, a range
of 192.168.1.0/24 is smaller than 192.168.1.0/16.
         - A virtual private cloud (VPC) is an isolated network that you
create in the AWS Cloud, similar to a traditional network in a data center.
             - IP range for the VPC in CIDR notation – This determines
the size of your network. Each VPC can have up to five CIDRs: one
primary and four secondaries for IPv4. Each of these ranges can be
between /28 (in CIDR notation) and /16 in size.
             - Subnet - Smaller network inside base network. In an
on-premises network, the typical use case for subnets is to isolate or
optimize network traffic. In AWS, subnets are used to provide high
availability and connectivity options for your resources. Use a public
subnet for resources that must be connected to the i nternet and a
private subnet for resources that won't be connected to the internet.
Creating subnets that are configured in two availability zones is
recommended.
                 - AWS reserves 5 IP addresses in each subnet that can
not be assigned to a resource.
             - Internet Gateway - Connects VPC to internet and is highly
available and scalable.
             - Virtual private gateway - A virtual private gateway
connects your VPC to another private network.
             - AWS Direct connect - to establish secure physical
connection between on-premises data center and Amazon VPC.With AWS
Direct Connect, your internal network is linked to an AWS Direct Connect
location over a standard Ethernet fiber-optic cable.
             - Main route table -  A route table contains a set of
rules, called routes, that are used to determine where network traffic
is directed.
             - Network Access control list - Acts as a virtual firewall
at the subnet level.A network ACL lets you control what kind of traffic
is allowed to enter or leave your subnet.
             - Security groups - Virtual firewall to control
inbound/outbound traffic for EC2 instance.
     - Storage
         - Block storage - File storage treats files as a singular unit,
but block storage splits files into fixed-size chunks of data called
blocks that have their own addresses. Each block is an individual piece
of data storage. Because each block is addressable, blocks can be
retrieved efficiently. Think of block storage as a more direct route to
access the data. Optimized for low-latency operations, it is a preferred
storage choice for high-performance enterprise workloads and
transactional, mission-critical, and I/O-intensive applications.
analogous to direct-attached storage (DAS) or a storage area network (SAN).
             - Use cases,
                 - Transactional workloads
                 - Containers
                 - Virtual Machines
         - Object storage - In object storage, files are stored as
objects. These objects are stored in a bucket using a flat structure,
meaning there are no folders, directories, or complex hierarchies. Each
object contains a unique identifier. This identifier, along with any
additional metadata, is bundled with the data and stored.
             - Use cases,
                 - Data archiving
                 - Backup and Recovery
                 - Rich Media
         - Elastic File System - set-and-forget file system that
automatically grows and shrinks as you add and remove files. There is no
need for provisioning or managing storage capacity and performance.
Amazon EFS can be used with AWS compute services and on-premises resources.
         - Fsx - FSx is a fully managed service that offers reliability,
security, scalability, and a broad set of capabilities that make it
convenient and cost effective to launch, run, and scale high-performance
file systems in the cloud.
         - EC2 Instance Store - provides temporary block-level storage
for an instance. This storage is located on disks that are physically
attached to the host computer. This ties the lifecycle of the data to
the lifecycle of the EC2 instance.  ideal if you host applications that
replicate data to other EC2 instances
         - Elastic Block store (EBS) - Block level storage that can be
attached to EC2 instance. EBS volumes are organized into two main
categories: solid-state drives (SSDs) and hard-disk drives (HDDs). SSDs
are used for transactional workloads with frequent read/write operations
with small I/O size. HDDs are used for large streaming workloads that
need high throughput performance.  EBS snapshots are incremental backups
that only save the blocks on the volume that have changed after your
most recent snapshot.
             - Use cases,
                 - Operating system
                 - Databases
                 - Enterprise Applications
                 - Big Data Analytical Engines
         - S3 -Amazon S3 is an object storage service. Object storage
stores data in a flat structure. An object is a file combined with
metadata. You can store as many of these objects as you want. All the
characteristics of object storage are also characteristics of Amazon
S3.Amazon S3 reinforces encryption in transit (as it travels to and from
Amazon S3) and at rest. To protect data, Amazon S3 automatically
encrypts all objects on upload and applies server-side encryption with
S3-managed keys as the base level of encryption for every bucket in
Amazon S3 at no additional cost.
             - Use cases,
                 - Backup and storage
                 - Media Hosting
                 - Software delivery
                 - Data lakes
                 - Static websites
                 - Static content
         - When to use what,
             - EC2 instance store - well suited for temporary storage of
information that is constantly changing, such as buffers, caches, and
scratch data. It is not meant for data that is persistent or long lasting.
             - EBS - meant for data that changes frequently and must
persist through instance stops, terminations, or hardware failures.
             - S3 - If your data doesn’t change often, Amazon S3 might
be a cost-effective and scalable storage solution for you. Amazon S3 is
ideal for storing static web content and media, backups and archiving,
and data for analytics. It can also host entire static websites with
custom domain names.
             - EFS -  ideal for workloads that require the highest
levels of durability and availability. EFS One Zone storage classes are
ideal for workloads such as development, build, and staging environments.
             - FSx - machine learning, analytics, high performance
computing (HPC) applications, and media and entertainment.
     - Databases
         - Unmanaged - If you operate a relational database on premises,
you are responsible for all aspects of operation. This includes data
center security and electricity, host machines management, database
management, query optimization, and customer data management. You are
responsible for absolutely everything, which means you have control over
absolutely everything.
         - Managed - These services provide the setup of both the EC2
instance and the database, and they provide systems for high
availability, scalability, patching, and backups. However, in this
model, you’re still responsible for database tuning, query optimization,
and ensuring that your customer data is secure. This option provides the
ultimate convenience but the least amount of control compared to the two
previous options.
         - RDS
             Amazon RDS supports most of the popular RDBMSs, ranging
from commercial options to open-source options and even a specific AWS
option. The storage portion of DB instances for Amazon RDS use Amazon
Elastic Block Store (Amazon EBS) volumes for database and log storage.
This includes MySQL, MariaDB, PostgreSQL, Oracle, and SQL Server. When
using Aurora, data is stored in cluster volumes, which are single,
virtual volumes that use solid-state drives (SSDs).
             - Backups - It is advisable to deploy both backup options.
Automated backups are beneficial for point-in-time recovery. With manual
snapshots, you can retain backups for longer than 35 days.
             -  Redundancy - Amazon RDS Multi-AZ ensures that you have
two copies of your database running and that one of them is in the
primary role. If an availability issue arises, such as the primary
database loses connectivity, Amazon RDS initiates an automatic failover.
             - Security - Network ACLs and security groups help users
dictate the flow of traffic. If you want to restrict the actions and
resources others can access, you can use AWS Identity and Access
Management (IAM) policies.

             Supported Amazon RDS engines include the following:
                 - Commercial: Oracle, SQL Server
                 - Open source: MySQL, PostgreSQL, MariaDB
                 - Cloud native: Aurora
         - Purpose built
             -  DynamoDB is the database of choice for high-scale and
serverless applications, it can work for nearly all online transaction
processing (OLTP) application workloads.
             - Easticcache - Provides in-memory cache using Redis or
Memcached
             - MemoryDB - a fully managed, primary database to build
high-performance applications. You do not need to separately manage a
cache, durable database, or the required underlying infrastructure.
             - DocumentDB - Use cases are content management systems,
profile management, and web and mobile applications.
             - Keyspaces - Good option for high-volume applications with
straightforward access patterns. With Amazon Keyspaces, you can run your
Cassandra workloads on AWS using the same Cassandra Query Language (CQL)
code, Apache 2.0 licensed drivers, and tools that you use today.
             - Neptune - Use cases are Recommendation engines, fraud
detection, and knowledge graphs.
             - Timestream - Used for measuring events that change over
time, such as stock prices over time or temperature measurements over time.
             - Quantum Ledger DB - provides a complete and
cryptographically verifiable history of all changes made to your
application data.
     - Monitoring
         - Cloudwatch - CloudWatch is a monitoring and observability
service that collects your resource data and provides actionable
insights into your applications. With CloudWatch, you can respond to
system-wide performance changes, optimize resource usage, and get a
unified view of operational health.
             - Metrics - Metrics are the fundamental concept in
CloudWatch. A metric represents a time-ordered set of data points that
are published to CloudWatch.
     - Load balancer - Elastic Load Balancer
         - Hybrid mode – Because ELB can load balance to IP addresses,
it can work in a hybrid mode, which means it also load balances to
on-premises servers.
         - High availability – ELB is highly available. The only option
you must ensure is that the load balancer's targets are deployed across
multiple Availability Zones.
         - Scalability – In terms of scalability, ELB automatically
scales to meet the demand of the incoming traffic. It handles the
incoming traffic and sends it to your backend application.
         - ELB supports 2 types of health checks,
             - Establishing a connection to a backend EC2 instance using
TCP and marking the instance as available if the connection is successful.
             - Making an HTTP or HTTPS request to a webpage that you
specify and validating that an HTTP response code is returned.
         - Types of load balancers,
             - Application Load Balancer - An Application Load Balancer
functions at Layer 7 of the Open Systems Interconnection (OSI) model. It
is ideal for load balancing HTTP and HTTPS traffic. After the load
balancer receives a request, it evaluates the listener rules in priority
order to determine which rule to apply. It then routes traffic to
targets based on the request content.
             - Network Load Balancer - ideal for load balancing TCP and
UDP traffic. It functions at Layer 4 of the OSI model, routing
connections from a target in the target group based on IP protocol data.
             - Gateway Load Balancer - helps you to deploy, scale, and
manage your third-party appliances, such as firewalls, intrusion
detection and prevention systems, and deep packet inspection systems. It
provides a gateway for distributing traffic across multiple virtual
appliances while scaling them up and down based on demand.
     - EC2 auto scaling
         - The Amazon EC2 Auto Scaling service adds and removes capacity
to keep a steady and predictable performance at the lowest possible
cost. By adjusting the capacity to exactly what your application uses,
you only pay for what your application needs. This means Amazon EC2 Auto
Scaling helps scale your infrastructure and ensure high availability.
the ELB service integrates seamlessly with Amazon EC2 Auto Scaling. As
soon as a new EC2 instance is added to or removed from the Amazon EC2
Auto Scaling group, ELB is notified.

- Key Architectural Considerations,
     - Ability to Scale
     - Fault Tolerance
     - Latency  (Includes Internet Latency)
         - WebRTC vs. WebSocket
             - WebRTC - UDP based. UDP offers no delivery or ordering
guarantees.
             - WebSockets - TCP based
             - MQTT - Offers three levels of message delivery guarantee,
                 - Once, not guaranteed
                 - At least once
                 - Only once.


- Hardware Sizing using Ratio Modelling
     - Used for quick, low-precision forecast.
     - These ratios can be gathered using Oracle Instrumentation (e.g.
v$Session etc.)
     - Determine OLTP to CPU ratio  (R1) - 100 (i.e. 100 Users for every
CPU)
     - Determine Concurrent users/requests (C)
     - Determine Batch to CPU Ratio (R2) - 1 (i.e. 1 batchjob to 1 CPU)
     - Determine max concurrent batch jobs (c2)

     - Formula,
         - CPU Count at Peak (100%) Utilization (P) = (C / R1) + (C2/R2)
         - To arrive at CPU Count at lower utilization (say 50%) P50 = P/0.5
         - R1 of 400 and R2 of 4.00 could be considered as highly optimistic

     - Capacity Planning notes
         - Compute
             - Throughput calculation
                  - Peak QPS
                     - Event driven Peaks
                     - Time-driven Peaks
                  - Daily Active users + Pageviews/User
             - Per instance QPS capacity  (e.g. Each worker can handle 5
queries per second)
         - Network
             - Bandwidth and data in transit
                 - Request size + Added size due to encryption
             - Client to server (ingress)
             - Server to Client (egress)
         - Storage and data at rest
             - Understanding Request sizes
         - Caching
             - Caching needs to alleviate write bottlenecks
         - Operating Capacity
             - Alerts & Monitoring

- General database Guidelines
     - Prefer bare metal over VM (as it provides ~ 10-15% performance boost)
     - Analyze tables periodically
     - Clean database for ROT ( Redundant, out-of-date, Trivial content
) tables.
     - Have Archive/purge policy in place. This is must for tables that
store activity log.
     - Partition any table with more than 2 million rows.


- Solution Architecture
     - Solution architecture is not just about providing a software solution. It covers all aspects of a system, which includes, but is not limited to, system infrastructure, networking, security, compliance requirement, system operation, cost, and reliability.
     - Business Requirement and Vision: A solution architect works with business stakeholders to understand their vision.
 -  - Requirement Analysis and Technical Vision: Analysis of the
requirements, defining a technical vision in order to execute the
business strategy.
     - Prototyping and Recommendation: Makes a technology selection by
developing POC and showcasing prototypes.
     - Solution Design: A solution architect develops solution designs
in line with an organization's standards and in collaboration with other
impacted groups.
     - Development: Works with the development team on solution
development,and as a bridge between the business and technical team.
     - Integration and Testing: Makes sure that the final solution is
working as expected with all functional and non-functional requirements.
     - Implementation: Works with the development and deployment team
for smooth implementation and guides them through any issues.
     - Operation and Maintenance: Ensures logging and monitoring are in
place and guides the team on scaling and disaster recovery as required.


- Cloud Architect
     - Plan and design cloud environment
     - Responsible for deploying and managing Cloud computing Strategy
     - Provide depth and breadth of Cloud Services
     - be able to define cloud-native design
     - Advise how on-premises applications will connect to the cloud and
how different traditional offerings fit into a cloud environment.

- Data Architect
     - Selection of database technology
     - Structured and unstructured data store choice
     - Streaming and batch data processing
     - A data lake as the centralized datastore
     - A relational database schema for application development
     - Data warehousing for data analysis and BI tools
     - Datamart design
     - Data security and encryption
     - Data compliance

- Enterprise Architect Role
     - works closely with stakeholders, subject matter experts, and management to identify organizational strategies for information technology and make sure that their knowledge aligns with company business objectives 
     - Enterprise architects handle solution design across the organization; they create long-term plans and solutions with stakeholders and leadership.
     - Finalize the technologies that should be used by the company.
     - Fill the gap between organizational strategy and its successful execution

- Cloud migration types
     - Refactor - Re-architect application into more modularized such as monolithic to microservice
     - Replatform - Migrate application to upgraded platform without changing core architecture, such
     traditional database to cloud or higher operating system version
     - Repurchase -  Replacing your current enviroment by purchasing a cloud-based solution
     - Rehost -  Quickly lift and shift your applications to the cloud without architecture changes
     - Retain-  Leaving the application on-premises for now at least
     - Relocate - Quickly relocate applications to the cloud without changing them, such as container- based applications


- Kalman filter - A Kalman Filter is a funnel which takes two or more imperfect and unreliable information sources and generates a more accurate estimate of what you want to know.  trust based weighted averaging is the heart of the Kalman filter.


- How CPU works,
     - RAM - computer’s main memory bank, a large multi-purpose space
which stores all the data used by programs running on your computer.
That includes the program code itself as well as the code at the core of
the operating system. The CPU always reads machine code directly from
RAM, and code can’t be run if it isn’t loaded into RAM.
     - The CPU stores an instruction pointer which points to the
location in RAM where it’s going to fetch the next instruction. After
executing each instruction, the CPU moves the pointer and repeats. This
is the fetch-execute cycle
     - This instruction pointer is stored in a register. Registers are
small storage buckets that are extremely fast for the CPU to read and
write to. Each CPU architecture has a xed set of registers, used for
everything from storing temporary values during computations to
conguring the processor.
     - The kernel, however, is the core of the operating system. When
you boot up your computer, the instruction pointer starts at a program
somewhere. That program is the kernel. The kernel has near-full access
to your computer’s memory, peripherals, and other resources, and is in
charge of running software installed on your computer (known as
userland  programs).
     - Processors execute instructions in an innite fetch-execute loop
and don’t have any concept of operating systems or programs. The
processor’s mode, usually stored in a register, determines what
instructions may be executed. Operating system code runs in kernel mode
and switches to user mode to run programs.
     - To run a binary, the operating system switches to user mode and
points the processor to
     the code’s entry point in RAM. Because they only have the
privileges of user mode,
     programs that want to interact with the world need to jump to OS
code for help. System
     calls are a standardized way for programs to switch from user mode
to kernel mode and
     into OS code.
     - Programs typically use these syscalls by calling shared library
functions. These wrap
     machine code for either software interrupts or architecture-specic
syscall instructions
     that transfer control to the OS kernel and switch rings. The kernel
does its business and
     switches back to user mode and returns to the program code.

- Differences in type of Testing
   - Regression vs Mutation - Regression tests check if new code is buggy while mutation tests check whether test themselves are reliable by twicking the code.
   - Smoke Testing - This is done after API development is complete. Simply validate if the APIs are working and nothing breaks.
   - Functional Testing - This creates a test plan based on the functional requirements and compares the results with the expected results.
   - Integration Testing - This test combines several API calls to perform end-to-end tests. The intra-service communications and data transmissions are tested.
   - Regression Testing - This test ensures that bug fixes or new features shouldn’t break the existing behaviors of APIs.
   - Load Testing - This tests applications’ performance by simulating different loads. Then we can calculate the capacity of the application.
   - Stress Testing - We deliberately create high loads to the APIs and test if the APIs are able to function normally.
   - Security Testing - This tests the APIs against all possible external threats.
   - UI Testing - This tests the UI interactions with the APIs to make sure the data can be displayed properly.
   - Fuzz Testing - This injects invalid or unexpected input data into the API and tries to crash the API. In this way, it identifies the API vulnerabilities.

- from google blog,
   -     Performance testing - Measuring the latency or throughput of your application or service.
   -    Load and scalability testing - Testing your application or service under higher and higher load.
   -    Fault-tolerance testing - Testing your application’s behavior as different dependencies either fail or go down entirely.
   -    Security testing - Testing for known vulnerabilities in your service or application.
   -    Accessibility testing - Making sure the product is accessible and usable for everyone, including people with a wide range of disabilities.
   -    Localization testing - Making sure the product can be used in a particular language or region.
   -    Globalization testing - Making sure the product can be used by people all over the world.
   -    Privacy testing - Assessing and mitigating privacy risks in the product.
   -    Usability testing - Testing for user friendliness.



- Learning for Database Performance from ScyllaDB,
- As much as possible, choose official driver for your environment
     - Checklist for driver selection
         - Clear documentation
         - Long term support and being active maintained
         - Asynchonous API
         - Decent test coverage
         - Database specific optimizations

- Wireshark is a great open-source tool for interpreting network packets

- Make the client-side timeouts around twice as long as server-side
ones, unless you have an extremely good reason to do otherwise.

- Inspecting logs and dashboards is helpful in investigating such cases,
so make sure that observability tools are available.

- Estimate the characteristics of your workload,
     - Is it likely to be a predictable, steady flow of requests (e.g., updates being fetched from other systems periodically)?
     - Is the variance high and hard to predict, with the system being idle for
     - Cloud platforms offering of provisioned throughput is cost efficient and it incurs certain cost regardless of To database activity while on demand pricing is per request.

- Always expect spikes. Even if your workload is absolutely steady, a temporary hardware failure or a surprworkise DDoS attack can cause a sharp increase in incoming requests

- Whenever possible, schedule maintenance options for times with
expected low pressure on the system.

- Infrastructure
   - Storage
     - When latency is critical - Locally attached NVMe SSDs provide
standard performance, prefer Serial AT over PCI Interface. Avoid network
attached disks.
     - When latency is not super critical - use Disks with SATA Interface.
     - RAID - General recommendation for creating a RAID-0 setup is to
use all disks of the same type and capacity to avoid variable
performance during your daily workload. For best performance,
recommendation is local NVMe SSD with RAID 0.  The recommended file
system is XFS.
     - Disk size - be sure to account for your existing
data—replicated—plus your anticipated near-term data growth, and also
leave sufficient room for the overhead of internal operations (like
compactions [for LSM-tree-based databases], the commit log, backups, etc.).
     - Start with replication factor of 3 over raw/base data size and
then account for,
         - Data Growth Rate
         - Data retention requirements

   - Cores - More cores will generally mean better performance. This is important for achieving optimal performance from databases that are architected to benefit from multithreading,and it’s absolutely essential for databases that are architected with a shard-per-core architecture—running a separate shard on each core in each server. In this case, themore cores the CPU has, the more shards—and the better data distribution—the database will have. Hyper threaded cores/virtual cores are not same as Physical CPUs and s that's the case then double the number of physical CPU will be needed.  Scylla has published benchmark of QPS (Queries per second) for a payload on a single physical CPU, this can be used for further apportion. Scylla's max recommended ratio of Storage/memory is  30:1.  So for a system having 128GB of memory, recommenced upper bound is 3.8TB. For production purposes, scylladb recommends 8GB of RAM per CPU Core.

    - Every database has an ideal memory-to-storage ratio—for example, a certain amount of TB or GB per node that it can support with optimal performance.

   - Write-heavy  workloads ->     a database that stores data in
immutable files (e.g., Cassandra, ScyllaDB, and others that use LSM
trees).But be prepared for higher storage requirements and the potential
for slower reads

   - Hot Data - Data that's accessed and likely cached.

   - To determine where reads are from Hot or Cold data, check ratio of
cache misses.

   - Delete heavy workloads - example is using database as durable
queue. Avoid database that works on immutable files as deleting is expensive

   - Competing Workloads  (i.e. OLTP and OLAP) - Identify which workload
is more important for use case and prioritize for it. Important aspects are,

   - Item size - Size of items being stored will dictate whether
workload is CPU or Storage bound. Higher payloads require more
processing, I/O and network traffic. Larger the payload, higher cache
utilization will be required. Write-optimized databases cache writes
before flushing it to stores.  This also requires more disk I/O.  On the
other hand, smaller the payload, greater chances of introducing memory
fragmentation which results in database unable to fully utilize the
available memory.

  - Item type - Choose the data type thats the minimum needed to store
the type of data you need and choose database thats optimized for that
data type (.e.g. JSON for MongoDB)

  - Factoring in your growth is critical for avoiding unpleasant
surprises in production, from an operational as well as a budget
perspective.

  - To understand latency, always prefer 99th percentile latency over
median or average latency

- Autoscaling - is not instantaneous. This is not ideal for unexpected
or extreme spikes.  Its best when,
     - Load changes have high amplitude
     -  The rate of change is in magnitude of hours

  - When ACID properties are important for workload, For cluster setup,
pay attention to master node.
- LSM tree based databases are optimized for heavy write workloads while
b-tree are optimized for heavy read workloads

-  Banchmarking - always take iterative approach i.e. start with small
target, optimize and repeat.
     - Throughput focus: You measure the maximum throughput by sending a
new request as soon as the previous request completes. This helps you
understand the highest number of IOPS that the database can sustain.
Throughput-focused benchmarks are often the focus for analytics use
cases (fraud detection, cybersecurity, etc.)
          - The number of requests per second, or the data volume per second, that the system is processing. For a given a particular allocation of hardware resources, there is a maximum throughput that can be handled. The unit of measurement is “somethings per second”
          - 
     - Latency focus: You assess how many IOPS the database can handle
without compromising latency. This is usually the focus for most
user-facing and real-time applications.
      - Some questions to ask while performing benchmarking  per
database connection,
         - average latency
         - P99 percentile latency
         - Maximum latency experienced in recent time frame

     -     The response time is what the client sees; it includes all delays incurred anywhere in the system.

    -     The service time is the duration for which the service is actively processing the user request.

    -     Queueing delays can occur at several points in the flow: for example, after a request is received, it might need to wait until a CPU is available before it can be processed; a response packet might need to be buffered before it is sent over the network if other tasks on the same machine are sending a lot of data via the outbound network interface.

    -     Latency is a catch-all term for time during which a request is not being actively processed, i.e., during which it is latent. In particular, network latency or network delay refers to the time that request and response spend traveling through the network.


- CPU vs GPU
   - CPUs are designed for sequential processing while GPUs have been
designed for massive levels of parallelism and high throughput, at the
cost of medium to high instruction latency.
   - GPU's design direction has been influenced by their use in video
games, graphics, numerical computing, and now deep learning
     - A GPU consists of several streaming multiprocessors (SM), where
each SM has several processing cores.
     - There is an off chip global memory, which is a HBM or DRAM. It is
far from the SMs on the chip and has high latency.
     - There is an off chip L2 cache and an on chip L1 cache. These L1
and L2 caches operate similarly to how L1/L2 caches operate in CPUs.
     - There is a small amount of configurable shared memory on each SM.
This is shared between the cores. Typically, threads within a thread
block load a piece of data into the shared memory and then reuse it
instead of loading it again from global memory.

- LLMS in nutshell,
   - A token is the basic unit of text understood by the LLM.
   -  tokens represent sequences of characters that are shorter or
longer than whole words. Punctuation symbols and spaces are also
represented as tokens, either individually or grouped with other characters.
   - The byte pair encoding (BPE) algorithm is commonly used by LLMs to
generate a token vocabulary given an input dataset. The BPE algorithm
doesn't always map entire words to tokens. In fact, words that are less
frequently used do not get to be their own token and have to be encoded
with multiple tokens.
   - Each token in an LLM's vocabulary is given a unique identifier,
usually a number. The LLM uses a tokenizer to convert between regular
text given as a string and an equivalent sequence of tokens, given as a
list of token numbers.

   - LLM in simplest form is made up of two files,
         1 - parameters file on which model is trained. Parameters are
weights of neural network.
         2 - C/python/Go  Program which references parameters file and
runs model.

   - Above is what is needed to run model locally without internet
connectivity. this is true only for open source models lika LLAMA and
not in case of closed source like ChatGPT because they havent released
model architecture.



   - Computational Complexity is in generating parameters. This is also
the first phase of training (pre-training).  Parameters are generated by
crawling data (e.g. text from internet) and processed on large GPU
Cluster and very expensive. This process in a way compresses this text
in a parameter file. Loss compression ratio is typically 100x.
   - Neural network in LLM is typically trying to predict next word in
sentence.
   - Little is known about how it does it. It suffers from reverse curse
i.e. it is correct in one direction but not in reverse way.
   - Second phase of training is called Fine tuning. This is done via
human assistance in a coversational mode. In this, Manual efforts are
made to fine tune the model. Quality is preferred over quantity.  Output
of this phase is assistant model.
   - In summary,
     - Stage 1: Pretraining - Requires large GPU Cluster - Hugh cost ($
Millions) -> obtain base model. This happens once a year.
     - Stage 2: Fine tuning - Fine tuning base model using high quality
Q&A responses. -> obtain Assistant Model. Verify and repeat fine tuning
steps. Cheaper compared to pre-training hence can be done more frequently.
     - Stage 3 (Optional): Involves using comparison labels or
reinforcement learning.
   - Llama 2 , relased by Meta, has both base model and assistant model.
It  is open source
   - Closed models like GPT can not be fine tuned etc.
- Performance of LLMs is a function of ,
   - N - number of parameters in the network
   - D - The amount of text we train on.
- LLMs currently only have system 1 level features..i.e. no thinking on
its part.
- LLM security aspects are still evolving. few areas are jailbreak,
prompt injectiom, data poisoning etc.

- PostgreSQL
   - Logical replication allows the real-time streaming of changes from
a database into any system that can understand the PostgreSQL logical
replication protocol.
   - One advantage this has over physical (or binary) replication is
that you can use logical replication to stream changes from a PostgreSQL
15 to a PostgreSQL 16 system as part of a major version upgrade.
   - Active-active -  managing an active-active system is extremely
complicated: it impacts application design, requires you to have a
write-conflict management and resolution strategy, and requires careful
fault tolerance monitoring to help ensure data integrity (e.g. a
“conflict storm”) and replication health (e.g. what happens if an
instance can’t replicate changes for several hours?).
     - One or more primaries replicating with each other
     - Requires conflict detection/resolution
     - Application needs to be designed for multiple primaries.
     - No failver required
     - Postgresql 16 supports bi-directional replication
   - Active-standby - One primary (Active) , one or more replicas
(standby). Used for High availability, read load balancing.
   - Physical replication- Copies data exactly as it appears on disk
   - Logical replication - copies data in a format that can be
interpreted by other systems. Uses publisher/subscriber model. Possible
to replicate between heterogenous systems. It doesnt support DDL and
foreign keys.


- LLMs at the end of 2023,
   - LLMs help when high level reasoning is not needed, task involves
regurgitating same stuff again in slightly different forms. They are
limited by maximum size of their context
   - what sense does it make today not to use LLMs for programming?
Asking LLMs the right questions is a fundamental skill. The less it is
practiced, the less one will be able to improve their work thanks to AI.
And then, developing a descriptive ability of problems is also useful
when talking to other human beings.
   - LLMs can not be trained at much lower cost (in thousands of $) and
can be run locally or on Mobile devices.


- Search, Semantic Search
   - Traditional search engines, including Elasticsearch/OpenSearch do
this lookup efficiently by building an inverted index, a data structure
that creates a key/value pair where the key is the term and the value is
a collection of all the documents that match the term and performing
retrieval from the inverted index. Retrieval performance from an
inverted index can vary depending on how it’s implemented, but it is
O(1) in the best case, making it an efficient data structure.  A common
classic retrieval method from an inverted index is BM25, which is based
on TF-IDF and calculates a relevance score for each element in the
inverted index. The retrieval mechanism first selects all the documents
with the keyword from the index, the calculates a relevance score, then
ranks the documents based on the relevance score.
   - Semantic search looks for near-meanings instead of exact match.
   - search engines will implement a number of both keyword-based and
semantic approaches in a solution known as hybrid search

- Distributed Postgresql and use cases,
- Network attached storage ->    the durability and availability
benefits of network-attached storage usually outweigh the performance
downsides, but it’s worth keeping in mind that PostgreSQL can be much
faster.
- read replicas    -> Consider using read replicas when you need >100k
reads/sec or observe a CPU bottleneck due to reads, best avoided for
dependent transactions and large working sets.

-DBMS optimized cloud storage ->    Can be beneficial for complex
workloads, but important to measure whether price-performance under load
is actually better than using a bigger machine.
active-active    Consider only for very simple workloads (e.g. queues)
and only if you really need the benefits.

-Transparent sharding  -> Use for multi-tenant apps, otherwise use for
large working set (>100GB) or compute heavy queries

-Distributed key-value storage with SQL ->    Just use PostgreSQL 😉 For
simple applications, the availability and scalability benefits can be usefu


- Using command line tools , with parallel processing, for data
processing jobs,
-- This problem of unused cores can be fixed with the wonderful xargs command, which will allow us to parallelize the grep. Since xargs expects input in a certain way, it is safer and easier to use find with
the -print0 argument in order to make sure that each file name being passed to xargs is null-terminated. The corresponding -0 tells xargs to expected null-terminated input. Additionally, the -n how many inputs to
give each process and the -P indicates the number of processes to run in parallel. Also important to be aware of is that such a parallel pipeline doesn’t guarantee delivery order, but this isn’t a problem if you are
used to dealing with distributed processing systems. The -F for grep indicates that we are only matching on fixed strings and not doing any fancy regex.

```

find . -type f -name '*.pgn' -print0 | xargs -0 -n1 -P4 grep -F "Result"
| gawk '{ split($0, a, "-"); res = substr(a[1], length(a[1]), 1); if
(res == 1) white++; if (res == 0) black++; if (res == 2) draw++;} END {
print NR, white, black, draw }'


```

- Laws of consulting as per Jerry weinberg,
- The First Law of Consulting states that consultants will never admit that they are sick. To get clients to hire you, you must agree that the client is competent, and then ask if there are any areas that need
improvement.
- "The Second Law of Consulting: No matter how it looks at first, it's always a people problem.



- RDBMS Database connection pooling (Ref:
https://aws.amazon.com/blogs/database/resources-consumed-by-idle-postgresql-connections/)

   - PostgreSQL connections consume memory and CPU resources even when idle. As queries are run on a connection, memory gets allocated. This memory isn’t completely freed up even when the connection goes idle. In all the scenarios described in this post, idle connections result in memory consumption irrespective of DISCARD ALL.The amount of memory consumed by each connection varies based on factors such as the type and count of queries run by the connection, and the usage of temporary tables. As per the test results shown in this post, the memory utilization ranged from around 1.5–14.5 MB per connection. 
   - As you increase the number of database connections, the context switching and resource contention also increases, which impacts performance. - PostgreSQL connections consume resources even when they’re idle, so the common assumption that idle connections don’t have any performance impact is not correct. (Around 1.5-14.5 MB per idle connection)
  - If your application is configured in a way that results in idle connections, it’s recommended to use a connection pooler so your memory and CPU resources aren’t wasted just to manage the idle connections.


- What is Retrieval Augmented Generation (RAG)?
   - RAG is a technique that enhances text generation by supplementing
it with information from private or proprietary data sources.
   - Use cases for RAG,
       - We want the LLM to "ingest" a large body of text it wasn't
trained on, and then chat to it about it
       - Even if the full body of text fits the LLM's context window,
this may be too expensive for each query
       - Therefore, we'll run a separate information retrieval stage,
finding the most relevant information for our query
       - Finally, we'll add this information as the context for our
query and chat with the LLM about it
   - Typically, LLM models are pre-trained on generic text. To add
specific context to the result obtained from it as well as to keep it
updated with any additional private text reposiory, RAG is used.
   - It typically involves injesting additional custom text store,
calculating embeddings for it and using these embeddings for answering
the question.


- REDIS
   - Employs asynchronous replication for high availability and read
scaling and an on-disk transaction log for local durability
   - Does not offer replication solution that can tolerate loss of nodes
without data loss or can offer scalable strongly-consistent reads. This
limites its ability to be leveraged for use cases beyond caching
   - Supports server-side execution of lua scripts which also execute
atomically. it allows to implement complex logic wholly within cluster
   - Supports point-in-time snapshots and on disk transaction log. It
can also persist mutations to disk using an append-only file (AOF)
feature that appends all mutating commands to a file. In a single node
configuration, AOF could provide durability at the expense of availability.
   - Single threaded and sequentially executes all commands it receives.
however, it may lose committed writes across failovers due to
asychronous propagation.


- Service based Architecture 
  - Terms and their defintions
    - Service - is a cohesive collection of functionality deployed as
an independent executable.
     - Coupling - Two artifacts (including services) are coupled if a change in one might require a change in the other to maintain proper functionality.Static coupling refers to
     the way architectural parts (classes, components, services, and so on) are wired
     together: dependencies, coupling degree, connection points, and so on.Dynamic coupling refers to how architecture parts call one another: what kind of communication, what information is passed, strictness of contracts, and so on.

     - Component - An architectural building block of the application that does some sort of business or infrastructure function, usually manifested through a package structure (Java), namespace (C#), or a physical grouping of source code files within some sort of directory structure.
     - Synchronous communication - Two artifacts communicate synchronously if the caller must wait for the response before proceeding
     - Asynchronous communication - Two artifacts communicate asynchronously if the caller does not wait for the response before proceeding. Optionally, the caller can be notified by the receiver through a separate channel when the request has completed.
     - Choreographed coordination - A workflow is choreographed when it lacks an orchestrator; rather, the services in the workflow share the coordination responsibilities of the workflow.
  