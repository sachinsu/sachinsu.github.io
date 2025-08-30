---
title: "Clean Architecture, Modular Monolith and Vertical Slice Architecture "
date: 2025-09-15T01:00:00+05:30
draft: true
tags: [Architecture, Services, Modularity, Microservices, Monolith]
---

## Introduction

Architecture plays a pivotal role in the delivery of software in terms of achieving business goals set forth for the software like maintainability, availability, performance and many more. It helps introduce structured approach to development by means of having appropriate abstractions. Typical driving forces for a software are,

- Functional requirements 
- Quality attributes (performance, scalability, availability etc.)
- Agility (Need to respond fluently to changes) 
- Constraints (Deployment platform)
- Principles (Automated testing, Automated deployment etc.) 

In this pursuit, there are alternate styles to structure software. Lets look at below ones which are dominant, 

  - **Monolith** - Traditional approach involving tiering or layering by means of separation of concerns like UI, business logic and Data into layers/tiers. Each layer is "horizontally" sliced (Packaged by Layer). Promotes rules like UI/Controller must talk to Service which should only talk to Repository/Data Access layer. Typical observation is that changes to any one of the layers usually results in changes across all layers. Any change typically involves re-deployment of entire or most parts of Application.

  - **Microservices** - an approach for developing a single application as a suite of small services, each running in it's own processes and communicating with lightweight mechanisms like HTTP based APIs. Services are built around business capabilities and are independently deployable. Key objective is bare minimum of centralized management. Typically suitable for Large, complex software projects. 

At a high level, Monolith approach has shown need for adaptation when it comes of agility expected from Software, while MicroServices provides agility , its often requires change in Organization's approach and found to be suitable for large use cases where benefits outweigh  related concerns like Eventual consistency, Operational Complexity and Distributed nature (Remote calls/(Fallacies of Distributed computing)[https://en.wikipedia.org/wiki/Fallacies_of_distributed_computing]).

Given this, are their tailored approaches aimed at specific requirements ?   Let's look at them , 

- **Modular Monolith** - Approach that tries to have golden mean between Monolith and Microservices by structuring the application into independent modules or components with well-defined boundaries with future possibilities of carving out microservices.
- **Vertical Slice Architecture (VSA)**- Architecture is built around distinct requests, encapsulating and grouping all concerns from front-end to back-end.
- **Clean Architecture** - Paradigm originally proposed by Robert Martin that isolates interfaces (user interfaces, databases, external systems, devices) from business logic. 

   This article aims to provide general context and aid in decision making about the above architecture styles. Please note [Limitations of General Advice](https://martinfowler.com/bliki/LimitationsOfGeneralAdvice.html)

## Understanding Each Architecture Individually:

### Modular Monolith

- **Core Idea**: is a way of organizing a software application into set of well defined, independent, extractable Modules.Modules have ‌specific functionality, which can be independently developed and tested, while the entire application is deployed as a single unit. 
- **Key Characteristics**: Encapsulation, clear boundaries between modules, high cohesion within modules, low coupling between modules.
- **Benefits**: Easier to start, single deployment, can evolve towards microservices if needed, good for smaller to medium teams. Suitable to manage when significant domain-specific changes are expected.
- **Potential Drawbacks/Concerns**: Can become a "big ball of mud" if modularity isn't strictly enforced, deployment unit size. These issues may be addressed using [Fitness functions](https://en.wikipedia.org/wiki/Fitness_function) (e.g. Cyclomatic complexity, coupling) and static code analysis etc. Carries on with some monolith bottlenecks like fault tolerance, scalability, elasticity etc.

    {{< figure align="center" src="/images/modularmonolith.png" title="Modular Monolith" >}}

###  Vertical Slice Architecture (VSA)
    
- **Core Idea**: This is in a way evolution of Modular Monolith where focus is on axes of expected change and modelling features end-to-end for it. For every individual request(s), all the code is co-located across layers. Organizing code around business capabilities or "verticals" (e.g., user management, order processing) rather than technical layers (UI, Business Logic, Data Access). A Module may have one or more features. Each feature  is self-contained and can be developed/tested independently. Module boundaries are explicit. Aim is to Minimize coupling between slices and maximize within slice.    
- **Key Characteristics**: Code organized by feature/capability, strong encapsulation within slices, minimal dependencies between slices, often involves defining clear boundaries.
- **Benefits**: High cohesion within slices, improved team autonomy, easier to understand and modify specific features, good for evolving complexity. 
- **Potential Drawbacks**: Can lead to duplication if not managed carefully (e.g., common domain logic), requires a discipline of keeping slices truly independent. 
  
    {{< figure align="center" src="/images/vas.png" title="Vertical Slice Architecture" >}}

    {{< figure align="center" src="/images/vsa-2.png" title="Vertical Slice Architecture" >}}

###  Clean Architecture (or similar layered/hexagonal approaches):

- **Core Idea**: opinionated way to structure  code and to separate the concerns of the application into layers. Core aim is to separate the business logic from infrastructure (i.e. data Access, external integrations etc.) and presentation layers. Originally popularized by [Robert C Martin](https://www.amazon.in/Clean-Architecture-Craftsmans-Software-Structure/dp/0134494164). Crux is to have business logic isolated from less stable external elements.
- **Key Characteristics**: 
  - Domain as the core, use of interfaces for external interactions.
  - Aim is to achieve maintainability, testability, and extendability 
  - Ability to change infrastructure and presentation without affecting core business logic
  - Ideal for complex, medium to large scale applications where maintainability and scalability are key objectives.
- **Benefits**: High testability, framework independence, maintainability, clear separation of concerns, easier to swap out external components.
- **Potential Drawbacks**: Can be perceived as overly complex for simple projects. Strict adhering to layering and use of interfaces often lead to lot of boilerplate code. Simple Applications may find it as overhead to implement.  
        
    {{< figure align="center" src="/images/clean_architecture.png" title="Clean Architecture" >}}


## Comparative Analysis:

| Aspect | Modular Monolith | Vertical Slice Architecture | Clean Architecture | 
|---|---|---|---|
| Application Size | Suitable for small to medium Sized Applications. Easy to get started and is cost effective.    | Agnostic of Application size. But keep watch for refactoring opty. | Larger initial codebase due to abstractions but clean separation helps irrespective of size 
| Organization | Modular approach per  Domain functionalities | By feature or use case, with each slice containing all relevant layers. | by layers i.e. Presentation, Domain and Infrastructure
| Maintainability, Testability | Individual slices/use cases can be tested  | Easier to maintain and test, as changes are localized to a single feature slice. | Improved testability
| Flexibility | Improved due to modularity but may require complete deployment | High. Different features can use different technical implementations. | High due to isolation of layers
| Scalability | Useful when future scalability requirements are uncertain.   |Slices can be deployed independently  |  Can be achieved by means of isolation of state management and ability to switch implementations
| Testability | better than trad.Monolith | High |Each layer can be tested independently,


## Synergies and Overlaps:

As one says there is no "one size fits all", similarly there is no reason to constrain self to use a specific architectural style for Application and neither of the above styles are mutually exclusive.  A Modular Monolith is where modules are structured but can use Vertical slice Architecture principles. A VSA based implementation can adopt clean Architecture principles with clean separation between domain logic and adapters (UI, Data stores, external integrations etc.) While VSA focuses on what to organize by, Clean Architecture focuses on how to organize within those boundaries.


## Conclusion:

The Architecture styles evolve as they are tested against real-time requirements in terms of flexibility, maintainability, scalability and so on. There is no one architecture style that fits many situation but each of the style provides path way to think and analyze fitment for the actual use case. As the First Law of Software Architecture states that **everything in software is a trade-off**, key is to evaluate these styles against requirements and arrive at [tradeoffs](https://www.youtube.com/watch?v=52haYbu80e8) and decide based on it.


### Useful References

* [Modular Monolith 1](https://www.thoughtworks.com/en-in/insights/blog/microservices/modular-monolith-better-way-build-software)
* [Modular Monolith 2](https://www.youtube.com/watch?v=fc6_NtD9soI)
* [Modular Monolith 3](https://static.simonbrown.je/modular-monoliths.pdf)
* [Vertical Slice Architecture 1](https://www.jimmybogard.com/vertical-slice-architecture/)
* [Clean Architecture from Robert Martin](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
* [Clean Architecture 1](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures)
* [Clean Architecture 2](https://devblogs.microsoft.com/ise/next-level-clean-architecture-boilerplate/)
* [Clean Architecture 3](https://jasontaylor.dev/clean-architecture-getting-started/)
  
Happy Coding !!

---

{{< comments >}}