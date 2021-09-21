Even Eric Evans explicitly states that DDD isn't suitable for problems when there's substantial technical complexity, but little business domain complexity. Using DDD is most beneficial when the complexity of the domain makes it challenging for the domain experts to communicate their needs to the software developers. By investing your time and effort into modeling the domain and coming up with a set of terminology that's understood for each subdomain, the process of understanding and solving the problem becomes much simpler and smoother

Modeling is an intense examination of the problem space. Key to this is working together with the subject matter experts to identify the core domain and other subdomains that you'll be tackling. Another important aspect of modeling is identifying what's called bounded contexts. And within each of these bounded contexts, you focus on modeling a particular subdomain. As a result of modeling a bounded context, you'll identify entities, value objects, aggregates, domain events, repositories, and more and how they interact with each other.

the ubiquitous language. A simple definition of a ubiquitous language is to come up with terms that'll be commonly used when discussing a particular subdomain. And they will most likely be terms that come from the problem space, not the software world, but they have to be agreed upon so that as discussions move forward, there is no confusion or misunderstanding created by the terminology used by various members of the team

Projects, 
- Frontdesk.core - contains domain model
- Frontdesk.infrastructure - integration with database and rabbitmq
- Frontdesk.API - API Endpoints


bounded contexts maintain their separation by giving each context its own team, codebase, and database schema. 

subdomain is a view on the problem space, how you've chosen to break down the business or domain activity, whereas a bounded context represents the solution space, how the software and the development of that software has been organized. Quite often, these will match up perfectly, but not always.

Same Entity can appear in more than one bounded context

The Domain Layer is responsible for representing concepts of the business, information about the business situation, and business rules. State that reflects the business situation is controlled and used here, even though the technical details of storing it are delegated to the infrastructure. This layer of the domain is the heart of business software.


Value object is an object that is used to measure, quantify, or describe something in your domain. Rather than having an identity key, its identity is based on the composition of the values of all of its properties. Because the property values define a value object, it should be immutable. In other words, you shouldn't be able to change any of the properties once you've created one of these objects. Instead, you would simply create another instance with the new values. If you need to compare two value objects to determine if they are equal, you should do so by comparing all of the values. Value objects may have methods and behavior, but they should never have side effects. Any methods on the value objects should only compute things; they shouldn't change the state of the value object, since it's immutable, or the system. If a new value is needed, a new value object should be returned. In DDD, both entities and value objects are typically defined as classes. Classes have advantages over structs when it comes to encapsulation and support for inheritance‑based extension and reuse.Value objects typically don't exist alone, they're usually applied to an entity to describe something about it.

domain services give you a place to put logic and behavior that you can't find a home for in the entities and value objects in your domain.domain services should generally only be used if you don't have an entity or value object where the behavior makes sense.domain services should be stateless, though they may have side effects. What this means is we should always be able to simply create a new instance of a service to perform an operation, rather than having to rely on any previous history that might have occurred within a particular service instance. But of course, the result of calling a method on a service might result in changes to the state of the system itself. These rules apply specifically to domain services which belong in the core of our application.

Side effects are changes that occur in your application or any kind of interaction with the outside world.

Aggregates consist of one or more entities and value objects that change together. We need to treat them as a unit for data changes, and we need to consider the entire aggregate's consistency before we apply changes.an aggregate is a cluster of associated objects that we treat as a unit for the purpose of data changes.

A bidirectional association means that both objects can be understood only together. When application requirements do not call for traversal in both directions, adding a traversal direction reduces interdependence and simplifies the design.

An aggregate is a group of related objects that work together in a transaction. The root becomes the entry point through which you do any work with the aggregate, and the root also is what's in charge of making sure that all of the rules that apply to that graph of objects are met. ‑Each of the rules that describes the state that the system must be in in order to be valid is called an invariant. Within our aggregates, we have objects that are related to one another. In DDD, we refer to these relationships as associations. If you use an ORM, you may hear the term navigation properties, which refers to those properties that reference the related objects in the model. And we talked about the importance of defaulting to one‑way relationships, which we also refer to as unidirectional relationships. ‑In addition to these important terms, Steve and I shared a lot of guidance around creating aggregates and roots in your domain models. Nobody wants to work with a big ball of mud. We use aggregates to organize our model. An aggregate is a set of related objects that live in a single transaction while encapsulating the rules and enforcing invariance of that transaction, making sure that the system is in a consistent state. When designing how related objects work together, your job will be easier with one‑way relationships. Use those as a default, and only introduce bidirectional navigation if you really need to. ‑And most importantly, don't resist updating your model as you and your team of domain experts learn more about the domain. Hopefully, most of this will happen early on, and then just once in a while you might have a big breakthrough, like we did when we realized that the schedule made more sense as an aggregate root than trying to have each appointment be its own aggregate.

be sure to provide repositories only for aggregate roots that require direct access. And next, keep the clients focused on the model, while delegating all of the object storage and access concerns to the repositories.

each domain event should be its own class

Domain events are a type of object that actually represents something that occurred within the domain that other parts of the system may find interesting and want to tie their behavior to.

anti‑corruption layers, which use a variety of design patterns to insulate our model from the design choices of other applications or bounded contexts.
