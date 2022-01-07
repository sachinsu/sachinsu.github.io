- Work updates
    DH, 
    - Ongoing App Review and New architecture

    Sahil, 
    - Unified non-card transactions from different channels

    BFL, 
    - System Optimization initiative - Reducing load on Oracle, shifting reporting to MIS 

    Axis bank -  migration of existing document mgmt system to MOS. Migration of 1Tb of documents. Approach for the same? and whether existing infrastructure can accommodate additional compute?           

    Issuance, 
        - Issue with Bank of India for which they had raised penalty and they wanted to understand data flow within systems. Shared updated issuance architecture diagram to be used to explain data flow. 

Shortlisting & interview for Mobile & C Architect role

## 2022-jan-03 Mon

- Tech

    - VMs, Serverless and when they are useful,
        - Virtual machines (e.g. EC2 or Compute Engine) are useful for workloads that change no faster than you’re able to add capacity, or for work loads that can tolerate delay in scaling (e.g. queue based event systems). They are also useful for short lived sessions that can tolerate scale down events
        -  Containers (e.g. a Kubernetes cluster or Fargate) which run on top of fixed compute. Like virtual machines are useful for traffic volumes which slowly change over time. While you’re able to start up a new container quickly to handle a new session, you’re still limited by the underlying compute instance on which the containers are running. The underlying compute hardware has to scale to meet the demands of the running containers. Containers are great for long lived, stateful sessions, as they can be ported between physical hardware instances while still running.
        - Serverless functions (e.g. Lambda or Cloud Run) are, in essence, containers running on top of physical hardware. They are ideally suited for handling unpredictable traffic volumes and for non-persistent and stateless connections.

## 2022-jan-05 Wed

- Economics 101 says that when a currency is devaluing & inflation is rising in the country, central banks usually raise the interest rates. This makes borrowing expensive & discourages spending. Less consumption will reduce demand for the assets, eventually bringing down inflation. Raising interest rates also increases demand for the currency, as it encourages people to save more.
    - Wholesale Transfer Pricing(WTP) - occurs when a player, already in a business relationship with another, is held hostage by the latter.
    - Indian fintechs are overly dependent upon ‘Old Banks’ who have the chops to navigate the technology waters, and the lending landscape, and the regulatory compliance 
    - Multitasking, in short, is not only not thinking, it impairs your ability to think. Thinking means concentrating on one thing long enough to develop an idea about it. Not learning other people’s ideas, or memorizing a body of information, however much those may sometimes be useful. 


-Tech#NewSQL - Relational databases designed to support scalable workloads for operational applications.
    - They use shared nothing architecture which means each node is isolated not accessing resources from other nodes 
    - Middleware - Transparent data sharding and query redirecting over cluster of single-node DBMSs (Citusdata, Scalebase, ScaleArc, Codefutures, Continuent)
    - Database as a service - Most of them use MySQL underneath.

- Tech#How honeycomb.io uses serverless (i.e. Lambda) 
    - They store data as segments in their NOSQL database 
    - Aiming to store data for last 60 ddays 
    - That duration indicates huge observability (traces, logs etc.) data i.e. in tune of gigabytes
    - Rather than having storage for all of data this, the historical data is pushed to S3 periodically. 

- Neural Net (https://sirupsen.com/napkin/neural-net?utm_source=computer-napkins&utm_medium=email), 
    - Basically training the system by adjusting the weights so as to get optimal desired result. 
    - Has 3 layers 
        - Input layer - has representation of data to feed to network. 
        - Hidden layer - Does a math on the input layer to convert it to our prediction. Training refers to changing math of this layer to generate predictions. Values in this layer are called weights 
        -  Output layer - Contains Final prediction.
    - Training indicates adjusting weights in hidden layer so as to achieve better prediction. Its like teaching hidden layer to apply certain function without actually applying it. 
    - loss function indicates how the prediction fair against expected outcome. large loss means wrong model and vice-versa. 
    - Minimizing the loss of a function is absolutely fundamental to machine learning.
    - While training, gradient descent is a method that minimizes value of a function. It helps in avoiding ad-hoc randomization (to achieve better prediction) and reducing loss .
    - epoch  - an iteration over the full training set is referred to as an epoch. 
    - Autograd (pytorch) is an automatic differentiation engine. grad stands for gradient, which we can think of as the derivative/slope of a function with more than one parameter. It keeps track of all the math functions applied and applies derivative.
    - To avoid overstepping in gradient descent, something called as "learning rate" is applied. 
    - For a Non-linear use cases (e.g. identify cat vs. calculate average), one has to add non-linear component to neural net. This is called as activation function. 
    - The core operations in neural net involve matrix multiplication. Frameworks like Pytorch perform this in underneath 'C' layer instead of Python. Using GPUs make them even faster.

## 2022-jan-06 Thu

- How ASP.NET requests are processed (ref: https://docs.microsoft.com/en-us/aspnet/web-forms/overview/performance-and-caching/using-asynchronous-methods-in-aspnet-45), 
    - .NET framework maintains pool of threads and dispatched for a new request.
    - If request is processed synchronously then respective thread is busy for that duration 
    - Max number of threads is 5000 for .NET 4.5
    - If long running processing of requests blocks many threads then its called as thread starvation 
    - In case of "thread starvation", web server queues requests and when queue is full it responds with HTTP 203 (server busy)
    - Each new thread has overhead of about 1MB of RAM
    - In case when "async...await" is used,  ASP.NET will not be using any threads between the async method call and the await.
    - An asynchronous request takes the same amount of time to process as a synchronous request. However, during an asynchronous call, a thread is not blocked from responding to other requests while it waits for the first request to complete. Therefore, asynchronous requests prevent request queuing and thread pool growth when there are many concurrent requests that invoke long-running operations.
    - Guidance, 
        - Use synchronous when,
            - Operation is short-lived
            - Simplicity is more important (No need for parallelism)
            - Primarily CPU based instead of I/o (Network, Disk etc.)

## 2022-jan-07 Fri

- Business philosophy
    - Genuine desire to delight customer - day in day out - No business following this has ever failed. 
- Web3
    - blockchain and cryptocurrency as technological implementation details, and Web3 as the communities, businesses, and social relationships that form on top of that technology.
    - What it may do?
        - Digital identity - Web3 introduces wallets that use public key cryptography to let people identify via a private key owned by themselves instead of a OAuth2 login provided by a corporation (e.g. Google).It also introduces authentication via a smart contract that enables advances features like social recovery, which lets you recover your account if you lose your key via a smart contract that takes votes from guardians (friends or paid services).Social recovery wallets are based on smart contracts which fundamentally based on the blockchain, and solve a huge problem relating to digital identity ownership that hasn’t been solved previously with non-blockchain solutions.

- How your organization works (https://copyconstruct.medium.com/know-how-your-org-works-or-how-to-become-a-more-effective-engineer-1a3287d1f58d)
    - Organizations usually reward those who "get the job done"
    - Necessary to understand skills that get rewarded 
    - Soft skills are hard skills
    - Understand implicit hierarchies 
    - Know the culture - Top-down or bottom-up
    - In all the mess that has evolved over long time, it is important to, 
    - how to gather just the right amount of information to get on with your task
    - how to reproduce bugs quickly without elaborate local configurations and setups
    - how to read a lot of code at a fast clip and come away with a reasonably good mental model of what it’s trying to do
    - how to come up with hypothesis and use a variety of general purpose techniques and tools to validate the hypothesis
    - Look for small wins
    - Understand Org constraints and manage your expectation 
    - Force multiplier characteristics, 
    - good at solving pressing problems
    - relentlessly getting things done
    - successfully creating change than just endlessly talking about the need to do so

- Watercooler#Vodka
    - all (unflavoured) vodkas are pure ethanol plus distilled water. There is no difference between a cheap and expensive vodka
- Homo Sapiens
    -Ever since the Cognitive Revolution, Sapiens has thus been living in a dual reality. On the one hand, the objective reality of rivers, trees and lions; and on the other hand, the imagined reality of gods, nations and corporations. As time went by, the imagined reality became ever more powerful, so that today the very survival of rivers, trees and lions depends on the grace of imagined entities such as gods, nations and corporations.
    
- Amazon Documentation culture 
    - Every important decision is presented as document which covers, 
        - PRFAQ - Press Release and Frequently asked questions: a document format used to pitch a new idea or investment opportunity
        - OP1 - A team’s one-year business plan: what they are going to work on and try and accomplish
        - BRD - A tactical plan for a particular project that lists all of the requirements in detail
        - Design Document - An engineering document that lays out the technical strategy with a high level of detail, documenting the approach as well as alternatives considered
        - 1 Pager - A summary document used to bring a stakeholder up to speed on a particular topic used for building alignment around goals


