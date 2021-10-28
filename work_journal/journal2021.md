## 2021-sep-21 Tue

- [Morgan housel explains how things work in world, Excellent at](http://collaborativefund.com/blog/100-little-ideas/)
- [List of Spy books](https://berthub.eu/articles/posts/useful-spy-books/?utm_source=hackernewsletter&utm_medium=email&utm_term=books)  
- Market Linked Debentures - 
    - Complex market linked Debt products typically issued by NBFCs.
    - Advantages is lower tax outgo as interest is not added to income. 
    - Typically, downside is protected or that principle is paid.
    - High entry barrier (10L onwards for entry)
    - Suitable for those who understands the complexity and have ability to go against issuer if required
    - Early withdrawal is not possible
    - Understanding terms is very important
    - May be nice if markets r looking like they will fail were principal-protected debenture will allow to participate in upside but protect downside.

- Value investing criteria
    - Buying cheaper than present value of future cash flows for a business that is sustainable over long periods of time (e.g Bajaj, HDFC, IT, Pharma).
    - So a Low ROCE Company is no no 
    - Value mostly underperforms in prolonged bull market. Momentum performs very well in prolonged bull market.  


## 2021-sep-22 Wed
- Evergrande 
    - Real estate sector is overreliant on debt
    - Most indebted RE player in world
    - liabilities account for ~ 2 % of china's annual GDP
    - they presold appartments to buyers and paid of contractors and suppliers with commercial papers and receivables instead of cash
    - They also sold wealth management products to retail investors 
    - due to bubble, housing prices r serveral times higher (relative to housing income) than they r in developed countries like US. 
    - property sector accounts for 25% of china's GDP
    - This caused real estate boom with many speculators.
    - now regulators r trying to make lenders reluctant to fund non-productive investment projects (like evergrande) 
    - Good read at https://carnegieendowment.org/chinafinancialmarkets/85391

- Momentum, value and everything else 
    - Be aware of limits of Momentum stategy as it can underperform. Accordingly do asset allocation.

## 2021-sep-22 Thu

- To try, https://medium.com/raposa-technologies/testing-turtle-trading-the-system-that-made-newbie-traders-millions-61bcb168ba5c 

- Auto Market in India
    - Mainly small car market 
    - middle class consumption explosion never realized 
    - Between Maruti (48%) and Hyndai (12$), they control 60%+ of passenger car market 
    - Other Global companies could never thrive in small car market. Basically, they entered india with expectation that over the period of time trend will shift to bigger cars but that hasn't happened.

- TSMC 
    - World's largest Contract manufacturer of Semiconductors and chips 
    - Most of world's devices have some component made by them 
    - It got immense traction during move to handheld (Smartphone, tab ...) from PC 
    - AMD, Qualcomm design the chips and outsource manufacturing entirely to companies like TSMC 
    - Mediatek is another taiwanese company but they design and manufacture their own processors.

- Very nice write up by Morgan Housel on beliefs, 
    - Other people's bad circumstances cudnt happen to you is a illusion 
    - Imagining an unrealistic world where progress and success don’t demand a fee, and a belief that hassle, nonsense, disagreement and uncertainty are bugs rather than a cost of admission to getting ahead.
    - An assumption that your view of the world is the view of the world, and a belief that what you’ve seen and experienced are the sights and experiences that explain how the world works.

- Cyclical nature of industry
    - buy sugar company on the news that sugar prices have gone up. The industry goes through cycles and that higher prices means more sugar will be produced resulting in oversupply next year 

- Faster housing financing
    - Securing a loan from Bank for Homes often takes time because of the processes they follow like due diligence, underwriting and so on. Nowadays, all-cash bidders are preferred over others by sellers. Instead of months it takes to secure loan from bank for a house,  There are companies (flyhomes.com) who buy the property on behalf of buyer in all-cash deals. They later sell it to buyer after few weeks when their loan is approved by bank. They are called cash offer companies. They make money through commisions and/or fees like between 1% to 3% of purchase price.This is example of financial engineering filling in gaps in market.     

## 2021-sep-23 Fri

- NFT is unique (non-fungible) digital item that can be traded online using blockchain technology. It is used for Digital Art, Collectibles, Sports. 
- Why NFT? 
    - Pride of Ownership
    - Psychological effect - once basic needs are fulfilled, we seek more. Entire art industry is about the idea of people assigining monetory value to a canvas
    - Speculative nature
- [How Blockchain works](https://graphics.reuters.com/TECHNOLOGY-BLOCKCHAIN/010070MF1E7/index.html)
    - Consists of database that has record bundled together into blocks and added to chain one after another. It has, 
        - The record  - can be any information (e.g. deal)
        - The block - block of records
        - Chain - link between blocks
- ElasticSearch shortcomings documented by Yelp w.r.t. Scale, 
    - Document is indexed individually on every replica 
    - Uneven load distribution across cluster 
    - Difficult to autoscale 
- Yelp is using Lucene based alternate search solution call nrtsearch, at https://github.com/Yelp/nrtsearch 
    It Provides, 
    - Near real time segment replication 
    - Concurrent query execution
- https://github.com/grpc-ecosystem/grpc-gateway - gRPC Gateway provides HTTP+JSON interface for gRPC Service. It is a plugin that is used to generate reverse-proxy server which translates a RESTful HTTP API into gRPC. This helps to test/access gRPC based API via REST. 

- https://github.com/mikemccand/luceneserver - HTTP REST API over Apache lucene.

- Openlineage - Standard API specification that functions as glue between data sources (schedulers, processing engines (Spark), ETL tools....) and DataOps tools (Margquez, Amundsen ....)

## 2021-sep-26 Sun

-   Sync and Async ( Everything can't be async ) 
    - Javascript solves this by making everything non-blocking because blocking would destroy browser's UI Thread which is it's primary use case.
    - golang does this via go routines
    - .NET is one of the platforms that has excellent support for interop with the underlying OS (pinvokes) aka FFI (foreign function interfaces). It has one of the best FFI systems on the market
    - The moment you need to call into the underlying platform, you need to context switch from your current “green” thread, to one compatible to what the underlying platform supports. This is one of the big costs and why golang had to rewrite things in go and goasm.
    - The other difficulty .NET has is that it allows pinning memory. Maybe you pinned some object to get the address or pass it to another function. This is problematic, when you want you want to grow the stack dynamically in your user mode thread implementation.
    - The inability to copy the stack means you need to do a linked list instead. This is a complex and inefficient implementation. Java and go can both copy because there’s no way to get the underlying address of anything (without really unsafe code).
    - Async state machines in .NET form linked list. 

- Rationality
    - “scout mindset,” which can help you “to recognize when you are wrong, to seek out your blind spots, to test your assumptions and change course.”  
    - The “soldier mindset,” by contrast, encourages you to defend your positions at any cost.

    - Introspection is key to rationality. 
    - A rational person must practice what is called “metacognition,” or “the ability to think about our own thinking”—“a fragile, beautiful, and frankly bizarre feature of the human mind.”
    -  successful student uses metacognition to know when he needs to study more and when he’s studied enough: essentially, parts of his brain are monitoring other parts.
    - The trick is to break the illusion of fluency, and to encourage an “awareness of ignorance.”
    - Knowing about what you know is Rationality 101.

    - Bayesian reasoning 
    - When new information comes in, you don’t want it to replace old information wholesale. Instead, you want it to modify what you already know to an appropriate degree. 
    - The degree of modification depends both on your confidence in your preëxisting knowledge and on the value of the new data. Bayesian reasoners begin with what they call the “prior” probability of something being true, and then find out if they need to adjust it.
    - Best practices
        - Start with the big picture, fixing it firmly in your mind. Be cautious as you integrate new information, and don’t jump to conclusions. Notice when new data points do and do not alter your baseline assumptions (most of the time, they won’t alter them), but keep track of how often those assumptions seem contradicted by what’s new. Beware the power of alarming news, and proceed by putting it in a broader, real-world context.
        - Real power of bayesian thinking is that it replaces the facts in our mind with probabilities
        - a rationalist must also be “metarational,” willing to hand over the thinking keys when someone else is better informed or better trained

## 2021-sep-27 Mon

-  Machine Learning 
    - It is tricky to apply it effectively 
    - Requires data and labels
    - First iteration should preferably be without machine learning
    - How to start?
        - Try to understand data 
            - Try to find correlations between feature and target variable
            - Scatter plots are a favorite for visualizing numerical values. Have the feature on the x-axis and the target variable on the y-axis and let the relationship reveal itself.
            - try box plot
        - Apply simple Heuristics
            - Recommendations: Recommend top-performing items from the previous period;
            - Product classification: Regex-based rules on product titles. Here’s an example from Walmart’s product classifier (Section 4.5): If product title contains “ring”, “wedding band”, “diamond. *bridal”, etc., classify it in the ring category.
            - Review spam identification: Rules based on the count of reviews from the same IP, time the review was made (e.g., odd timing like 3 am), similarity (e.g., edit distance) between the current review and other reviews made on the same day.

- Business#Telecom 
    - Tower companies are those who come up with infrastructure for hosting antennas from telecom provider 
    - They generate revenues when telecom companies put up their antennas on their towers
    - Telecom companies refrain from building their own towers because of high capital expenditure 
    - Only reliance jio started with building its own towers and then hived it off (to brookfield)
    - With 5G, more investment is needed in fibre infrastructure than towers.
    - In telecommunications, a base station is a fixed trasceiver, the main communication point for one or more wireless mobile client devices. A base station serves as central connection point for a wireless device to communicate.

- Defence#Submarines

    - Underwater gradient in Arabian sea is too low (e.g. water is only 50 meters deep till about 50 Km from karachi harbor) while it is deep in Bay of Bengal 
    - Hence two pronged strategy of 
        - Conventional (diesel-electric with Air independent propulsion) submarines for Western fleet 
        - Nuclean SSN & SSBN for Eastern fleet.
        - Nuclear submarines can use either Low enriched uranium (LEU --> France) or Highly enriched euranium (HEU --> US & UK). Us technology doesnt need to refuel nuclear submarine for its life span (35 years) where Russian one requires cutting open hull, refuel it and welding it back. French model has hatches for refuelling which does not require lengthy refits.
    
## 2021-sep-28 Tue

- Investing#Traits to avoid while investing (Anand Sridharan)
    - Bad Promotors 
    - Government Owned
    - True owner is at a different level (Cummins inc and Cummins india)
    - No Owner (Credit ratings, Stock exchanges etc)
    - Private Equity owned

- UITECH#RANT Framework for front-end
    - React: easy componentization, commonly used, flexible
    - Apollo GraphQL: commonly used (good docs), simple, automatic type generation
    - Next.js: SSR by default, capable filesystem server, built-in SPA router, helpful docs
    - Typescript: catch runtime errors at build, easy debugging
- UITECH# SSR and CSR
    - Server-side rendering does basically the same job as client-side rendering: generating HTML. 
    - The only real difference is that server-side rendering provides pre-rendered HTML to clients while client-side rendering requires the client to run JS files to render the HTML. 
    - server-side rendering is ideal for websites that need strong search engine presence, since search engine bots can just read the static content immediately instead of possibly running into issues with JS content. 
    - Server-side rendering is also necessary if clients have technical limitations, such as being unable to run JavaScript. Otherwise, server-side rendering is practically equal to client-side rendering.

- Investing#Margin of safety - Practice of buying shares of a company only when they trade at a large discount to true value. Difference between estimated value of share and purchase price is margin of safety.

- Investing#Earnings yield - earnings per share / share price
    - higher earnings yield is better than lower (obviously)
    - business that earn high return on capital are better
    - high return on capital companies availble at bargain prices i.e. companies with high earning yield and high return on capital.
    - buy shares in companies with high returns on equity only when they are available at bargain prices (i.e. giving high earning yield)

- Investing#Options trading 
    - Trading with self (Its risky since someone else might put counter order just in time) across multiple exchanges is called "Wash trading" and its illegal.

## 2021-sep-29 Wed

- Sociology - Urban centers tend to homogenize the culture of the population.

- Semiconductors 
    - Semiconductors are the world’s 4th most traded good after crude oil, refined oil and cars. Strong demand existed before COVID and reflected the chip-intensity of 5G, AI, electric vehicles ( 3-5x the chip content of ICE cars) and the internet of things. Current chip shortages are mostly related to older and simpler 200-mm silicon wafers used in cars, computers, monitors, laptops, TVs, refrigerators and washing machines. 
    - There’s limited economic incentive to build new 200-mm chip plants given wafer-thin margins;
    - Malaysia is major center for chip testing and packaging
    - Semiconductor fabrication typically requires lot of water

- China and world's shipping
    - Chinese companies affiliated with its government make 95% of the world’s containers
    - China has 37% of the shipbuilding market in 2019 by deadweight, and 45% of all new shipbuilding orders

- Investing
    - Owning a business that has the opportunity to invest some or all of its profits at a very high level of return can contribute to a very high rate of earnings growth.

- Forex# Range of the day pricing 
    - Fx Specialist @ Bank would select the best rate for the back and worst rate for the customer from the FX price fluctuations from the beginning of the trading day until the time of transaction.

## 2021-sep-30 Thu

- Technology# Memory Management
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
 
  - Psychology of human misjudgement
    - jacobi's principle of inversion
        - Study instances of bad judgement to recognize good judgement
    - if you would persuade, appeal to interest and not to reason.
        - Especially fear professional advice when it is especially good for the advisor
        - learn and use the basic elements of your advisor's trade as you deal with your advisor
        - double check, disbelieve or replace much of what you are told, to the degree that seems appropriate after objective thought
        - bad behavior is intensely habit forming when it is rewarded - B.F. Skinner
        - Whose bread i eat, his songs i sing. 
    - Granny's rule - Children eat their carrots before they get dessert (business executives force themselves daily to first do their unpleasant and necessary tasks before rewarding themseleves by proceeding to their pleasant tasks)

    - Liking/loving tendency
        - Consequences
            - Ignore faults of, and compley with wishes of, the object of his affection
            - to favor people, products and actions merely associated with the object of his affection. 
            - to distort the facts to facilitate love 
    
    - Disliking/hating tendency 
        - dislikings and hatred never go away completely. 
        - Politics is art of marshaling hatreds
        - consequences 
            - ignore virtues in the object of dislike
            - dislike people, products and actions merely associate with object of his dislike
            - distort facts to facilitate hatred
    
    - Doubt avoidance tendency
        - puzzlement and stress triggers doubt avoidance. 
    
    - Inconsistency avoidance tendency 
        - an ounce of prevention is worth a pound of cure 
    
    - Curiosity Tendency 
        - helps man to prevent or reduce bad consequences arising from other psychological tendencies.

    - Kantian fairness Tendency
        - "fair sharing" conduct, strangers often voluntarily share equally in unexpected, unearned good and bad fortune. 

    - Envy/Jealousy tendency 
        - It is not envy that drives the world but envy
        - sibling jealousy is very strong and kantian fairness tendency probably contributes to it. 
    
    - Reciprocation tendency 
        - Humans have automatic tendency to reciprocate both favors and disfavors. 
        - Wise employers  try to oppose reciprocate-favor tendencies of employees engaged in purchasing. Simple antidote is don't let them accept any favors from vendors. 
        - feeling of guilt is outcome of reciprocate tendency gone wrong.

    -  Influence-from-Mere-Association Tendency
        - Advertisers know about the power of mere association other example is military playing impressive music
        - The proper antidotes to being made such a patsy by past success are 
            -  to carefully examine each past success, looking for accidental, non- causative factors associated with such success that will tend to mislead as one appraises odds implicit in a proposed new undertaking 
            -  to look for dangerous aspects of the new undertaking that were not present when past success occurred.  
        - underappraising both the comptetency and morals of competitor you dislike causes miscalculation 

## 2021-oct-4 Mon

- R2 will run across Cloudflare’s global network, which is most known for providing anti-DDoS services to its customers by absorbing and dispersing the massive amounts of traffic that accompany denial-of-service attacks on websites. It will be compatible with S3’s API, which makes it much easier to move applications already written with S3 in mind, and Cloudflare said that beyond the elimination of egress fees, the new service will be 10% cheaper to operate than S3.

- Cloudflare is aiming at lower end of market (with low margins). The big incumbants have innovator's dilemma trying to come down and deal with companies (Cloudflare) serving lower end of market. 

- Because new-market disruptions compete against nonconsumption, the incumbent leaders feel no pain and little threat until the disruption is in its final stages.

- In a vacuum, most businesses would prefer making a fixed cost investment instead of paying on a marginal use basis. Consider Spotify’s music-streaming business: one of the company’s core challenges is that the more customers Spotify has the more it has to pay music labels — streaming rights are a marginal cost. A streaming service like Netflix, on the other hand, that spends up front for its own content, gets to keep whatever increased revenue that content drives for itself. This same logic applies to computing capacity: buying your own servers is, in theory, cheaper than renting compute from a service like AWS. 

For Compute, 
- First, usage may be uneven, whether that be because a business is seasonal, hit-driven, or anything in-between. That means that compute capacity has to be built out for the worst case scenario, even though that means most resources are sitting idle most of the time.
- Second, compute capacity is likely growing — hopefully rapidly, in the case of a new business. Building out infrastructure, though, is not a linear process: new capacity comes online all at once, which means a business has to overbuild for their current needs so that they can accommodate future growth, which again means that most resources are sitting idle most of the time.
- Third, compute capacity is complex and expensive. That means there are both huge fixed costs that have to be invested before the compute can be used, and also significant ongoing marginal costs to manage the compute already online.

-   This is why AWS was so transformative: Amazon would spend all of the up-front money to build out compute capacity for all of its customers, and then rent it on-demand, solving all of the problems I just listed:

    - Customers could scale their compute up-or-down instantly in response to their needs.
    - Customers could rent exactly how much compute they needed at any moment in time, even as they were able to seamlessly handle growth.
    - AWS would be responsible for all of the up-front investment and ongoing maintenance, and because they would operate at such scale, they would get much better prices from suppliers than any individual company could on its own.

    - Amazon has a lot less cash and, more importantly, a lot less profit than Google or Microsoft. 
    - Amazon already has significantly more scale, which means their costs on a per-customer basis are lower than Microsoft or Google.
    - AWS charges for data transferred out of their network but not for data transferred into their network

-R2 is a compelling choice for a certain class of applications that could be built to s erve a lot of data without much compute. Moreover, by virtue of using the S3 API, R2 can also be dropped into existing projects; developers can place R2 in front of S3, pulling out data as needed, once, and getting free egress forever-after.

- Moreover, like any true disruption, it will be very difficult for Amazon to respond: sure, R2 may lead Amazon to reduce its egress fees, but given the importance of those fees to both AWS’s margins and its lock-in, it’s hard to see them going away completely. More importantly, AWS itself is locked-in to its integrated approach: the entire service is architected both technically and economically to be an all-encompassing offering; to modularize itself in response to Cloudflare would be suicidal.

- Technology#Web3
    - Theme is about decentralization 
        - In a decentralised web, each participant holds a secret key. They can then use it to identify each other.
        - In a Web3 setting where web participants own their data, they can selectively share these data with applications they interact with. Participants can also leverage this system to prove interactions they had with one another. For example, if a college issues you a Decentralized Identifier (DID), you can later prove you have been registered at this college without reaching out to the college again. Decentralized Identities can also serve as a placeholder for a public profile, where participants agree to use a blockchain as a source of trust
    - Primer on CryptoCurrency, 
        - A peer-to-peer network is a network architecture. It consists of a set of computers, called nodes, that store and relay information. Each node is equally privileged, preventing one node from becoming a single point of failure. In the Bitcoin case, nodes can send, receive, and process Bitcoin transactions.
        - A ledger is a collection of accounts in which transactions are recorded. For Bitcoin, the ledger records Bitcoin transactions.
        - A distributed ledger is a ledger that is shared and synchronized among multiple computers. This happens through a consensus, so each computer holds a similar replica of the ledger. With Bitcoin, the consensus process is performed over a P2P network, the Bitcoin network.
        - A blockchain is a type of distributed ledger that stores data in “blocks” that are cryptographically linked together into an immutable chain that preserves their chronological order. Bitcoin leverages blockchain technology to establish a shared, single source of truth of transactions and the sequence in which they occurred, thereby mitigating the double-spending problem.

- Psychology of human misjudgement
  - The best antidote to folly from an excess of sel-regard is to force yourself to be more objective when you are thinking about yourself, your family and friends, property and value of your past and future activity. 
  - The trustworthy an , even after allowing for the inconviniences of his chosen course,ordinarily has a life that averages out better than he would have if he provided less reliability.

  - Deprival Superreaction Tendency - Man  ordinarily reacts with irrational intensity to even a small loss, or threatened loss of property, friendship etc. As a natural result, bureaucratic infighting over the threatened loss of dominated territory often causes immense damage to an institution as a whole. 

  - extremes of ideology causs extremes of cognitive dysfunction 
    - One antidote is extreme culture of courtesy kept in place despite ideological differences. 

- Learn how to ignore the examples from others when they are wrong.

- skills of very high order can be maintained only with daily practice

- be careful whom you appoint to power because a dominant authority figure will often be hard to remove, aided as he will be by authority-misinfluence tendency.

- Ideas got through best when reasons for the ideas were meticulously laid out

## 2021-oct-5 Tue 

- Confidence is comfort due to repetition

- Investing#Equity Risk Premium - The compounded return differential between investment in equity vs. debt (Liquid fund). 
    - one approach could be that keep a higher allocation to equity, in general, when the equity risk premium is lower than 10%. Above that, no further investments in equity.

- Tech#Cybersecurity for AI/ML Systems
    - In AL/ML based systems, system behaviour cannot be assumed to be "locked down" as it is for non AI/ML Systems.
    - The threats where the attacker adjusts the input to the model to make it do something that is to the attacker's advantage  are called evasive threats
        - They work in following ways, 
            - By reducing confidence in the result of the model
            - by misclassifying an input
            - by misclassifying input into a class that the attacker wants the input to be classified into
    - backdooring the model - here the input is not being changes, its model itself has been.
    - poisoning the model - input of the model is altered but the purpose is not to make the model do something it should not , but for it to learn something it should not. 
    
    - the key intent here is to make AI/ML system do it was not supposed to.

    - Model theft consists of reverse-engineerin a trained model in totality or extracting information enough to reconstruct the model not to the fidelity of the original but acceptable enought for the purpose of the attacker.

    - What are protection measures for AI/ML based systems
        - Guard the Model 
            - Infrastructure hardening
            - Access via APIs (thru authentication), with limits on API Access
            - Requests monitoring for identifying pattern of leaching
            - Encryption (with keys stored in secure enclaves)
            - multiple levels of flash protection (disc, file system and application level)
        - Guard the training process
            - offline - training during system development
                - Training is continous process i.e. even after deployment, model continues to learn in iterative way 
                - Access to training environment should be protected by least privilege
                - New model behavior should be tested for adverse results including behavioral fuzzing 
            - online - System learns "on the job". Changing its behavior dynamically. Difficult to secure than "offline".
        - Guard the source of data 
            - always cryptographically authenticate source of data
        - Put AI/ML systems in safety cages
            -Controls imposed outside of model to ensure that any "bad behavior" that is learned does not lead to harm 
                - Human oversight 
                - allowing intelligent action only in certain benign zones of operation 
        - Use resilient AI/ML Algorithms
            - "adversarial ML" - developing robust learning methods that have multiple mathematical protections against evasion attacks. 

- Tech#Facebook Outage 
    - BGP stands for Border Gateway Protocol. It's a mechanism to exchange routing information between autonomous systems (AS) on the Internet. The big routers that make the Internet work have huge, constantly updated lists of the possible routes that can be used to deliver every network packet to their final destinations. Without BGP, the Internet routers wouldn't know what to do, and the Internet wouldn't work.
    - The Internet is literally a network of networks, and it’s bound together by BGP. BGP allows one network (say Facebook) to advertise its presence to other networks that form the Internet. As we write Facebook is not advertising its presence, ISPs and other networks can’t find Facebook’s network and so it is unavailable.
    - When someone types the https://facebook.com URL in the browser, the DNS resolver, responsible for translating domain names into actual IP addresses to connect to, first checks if it has something in its cache and uses it. If not, it tries to grab the answer from the domain nameservers, typically hosted by the entity that owns it.If the nameservers are unreachable or fail to respond because of some other reason, then a SERVFAIL is returned, and the browser issues an error to the user.
    - Border Gateway Protocol (BGP) is the postal service of the Internet. When someone drops a letter into a mailbox, the postal service processes that piece of mail and chooses a fast, efficient route to deliver that letter to its recipient. Similarly, when someone submits data across the Internet, BGP is responsible for looking at all of the available paths that data could travel and picking the best route, which usually means hopping between autonomous systems.BGP is the protocol that makes the Internet work. It does this by enabling data routing on the Internet. When a user in Singapore loads a website with origin servers in Argentina, BGP is the protocol that enables that communication to happen quickly and efficiently.

    - Investing#Call options 
        - Buying a call option at strike price (typically greater than CMP) is 
            - bet on the price of the stock at expiry
            - rewarded if underlying stock price goes up a lot
            - not penalized if it goes down ( just lose the amount paid for the option)
            - "delta" effect is when chances of stock prices going up at expiry is high because of jump in stock price 
            - "theta" effect is if stock prices remain same over period of time in direction of expiry
            - "vega" effect is if stock is volatile due to which Market thinks there will be hugh action at expiry. 

## 2021-oct-6 Wed

- Tech#BGP
    - BGP is a protocol that companies use to advertise BGP Routes. 
    - If Company makes announcement for withdrawal of BGP Routes then all routers would delete those routes and site becomes inaccessible.

- Tech#Micosoft .NET 
    - at scale could means 
        - no. of users 
        - size of data
        - processing large number of requests 
    
    - Use Streams/pipelines for large data sets
        - If streams are using Buffers then always FlushAsync.  
    - Pool and re-use buffers when you need to operate on in-memory data.
    - RegEx compilation is like 5000 lines of code 
    - ConcurrentDictionary 
        - conceptually similar to Dictionary where 
            - Reads are lock free but writes are not
        - The default number of concurrent writes is equal to the number of processors on the machine.
        - always enumerate over entries and not over keys
        -Dictionary with lock - "Poor read speed, lightweight to create and medium update speed."
        - Dictionary as immutable object - "best read speed and lightweight to create but  heavy update. Copy and modify on mutation e.g. new Dictionary(old).Add(key, value)"
        - Hashtable - "Good read speed (no lock required), same-ish weight as dictionary but more expensive to mutate and no generics!"
        - ImmutableDictionary - "Poorish read speed, no locking required but more allocations require to update than a dictionary."
    - in C#, avoid hashtable and use Dictionary<> instead
        - Hashtable is weakly typed and while it allows you to have keys that map to different kinds of objects which may seem attractive at first, you'll need to "box" the objects up and boxing and unboxing is expensive. You'll almost always want to use Dictionary instead.
    - Handling long-running operations in REST API (Azure Way),
        - The client sends the initial request to the resource to initiate the long-running operation. This initial request could be a PUT, PATCH, POST, or DELETE method.

        - The resource validates the request and initiates the operation processing. It sends a response to client with a 200-OK HTTP status code (or 201-Created if the operation is a create operation) and a representation of the resource where the status field is set to a value indicating that the operation processing has been started.

        - The client then issues a GET request to the resource to determine if the operation processing has completed.

        - The resource responds with a representation of the resource. While the operation is still being processed, the status field will contain a "non-terminal" value, like Processing.

        - After the operation processing has completed, a GET request from the client will receive a response where the status field contains a "terminal" value -- Succeeded, Failed, or Canceled -- that indicates the result of the operation
    
    - Long running operations with status monitor 
        - The client sends the request to initiate the long-running operation. As in the RELO pattern, the initial request could be a PUT, PATCH, POST, or DELETE method.

        - The resource validates the request and initiates the operation processing. It sends a response to the client with a 202-Accepted HTTP status code. Included in this response is an Operation-location response header with the absolute URL of status monitor for this specific operation. The response also includes a Retry-after header telling the client a minimum time to wait (in seconds) before sending a request to the status monitor URL.

        - After waiting at least the amount of time specified by the previous response's Retry-after header, the client issues a GET request to the status monitor URL.

        - The status monitor URL responds with information about the operation including its current status, which should be represented as one of a fixed set of string values in a field named status. If the operation is still being processed, the status field will contain a "non-terminal" value, like Processing.

        - After the operation processing completes, a GET request to status monitor URL returns a response with a status field containing a terminal value -- Succeeded, Failed, or Canceled -- that indicates the result of the operation. If the status is Failed, the status monitor resource must contain an error field with a code and message that describes the failure. If the status is Succeeded, the response may contain additional fields as appropriate, such as results of the operation processing.

- Tech#Logging rules (https://tuhrig.de/my-logging-best-practices/)
    - INFO Level is for business while DEBUG is for developers
    - Log INFO after the operation is over and not before 
    - Distinguish between WARNING (Typically can be retried) and error

## 2021-oct-7 Thu

- Worldly Wisdom
    - Well known companies have advantage of scale or informational advantage
    - Well known companies also have social proof. 
    - The greatest defect of scale is that as you get big, you get the bureaucracy and with bureaucracy comes the territoriality.
        - they also tend to be corrupt. they are too slow to make any decisions.
        - folks typically respond to these issues by 
            - creating little decentralized units, fancy motivation and training programs.
    - life is everlasting battle between two forces - to get advantages of scale on one side and tendency to get lethargic bureaucracy
    - The concept of chain store is fascinating as it gices huge purchasing power, thus lowering merchandise costs. It allows experimentation and as a result specialization.
    - Capitalism is a pretty brutal place.
    - The great lesson in microeconomics is to discriminate between when technology is going to help you and when its going to kill you.
    - Productivity gains in commodity business typically benefit buyers than owners
    - when technology moves too fast it causes competitive destruction
    - every person has circle of competence and its hard to advance that circle
    - if you play games where other peopl ehave the aptitudes and you don't then you are going to lose.
    - people can rise quite high in life by slowly developing circle of competence.
    - Its not given to human beings to have such talent that they can just know everything about everything all the time.
    - The wise ones bet heavily when the world offers them that opportunity. 
    - the way to win is to work,work,work....and hope to have few insights
    - Winner has to bet selectively.
    - getting the incentives right is a very, very important lesson
    - Classic ben graham concept got the world wised up and those real obvious bargains disappeared. 
    - Most investment managers are in a game where the clients expects them to know a lot about lot of things.
    - it makes sense to load up on the very few good insights you have instead of pretending to know everyting about everything all the time
    - over the long term, its hard for a stock to earn a much better return than the business which underlies it earns
    - anytime anybody offers you anything with a big commission and 200 page prospeturs, dont buy it
    - nothing is automatic and easy
    - Important to remain on the edge of improvements.

- Tech#Large file I/o
    - C# has a class MemoryMappedFile. A memory-mapped file contains the contents of a file in virtual memory. This mapping between a file and memory space enables an application, including multiple processes, to modify the file by reading and writing directly to the memory.  This could be useful when dealing with large files. Often preferred over buffers as buffering is difficult to get right.

- Tech#Garbage collection 
    - The rule-of-thumb for allocations is that they should either die in the first generation (Gen0) or live forever in the last (Gen2).

- Tech#Peformance rules 
    - Avoid LINQ. LINQ is great in application code, but rarely belongs on a hot path in library/framework code. LINQ is difficult for the JIT to optimize (IEnumerable<T>...) and tends to be allocation-happy.
    - Use concrete types instead of interfaces or abstract types. This was mentioned above in the context of inlining, but this has other benefits. Perhaps the most common being that if you are iterating over a List<T>, it's best to not cast that list to IEnumerable<T> first (eg, by using LINQ or passing it to a method as an IEnumerable<T> parameter). The reason for this is that enumerating over a list using foreach uses a non-allocating List<T>.Enumerator struct, but when it's cast to IEnumerable<T>, that struct must be boxed to IEnumerator<T> fo+r foreach.
    - Mark classes as sealed by default. When a class/method is marked as sealed, RyuJIT can take that into account and is likely able to inline a method call.
    - Mark override methods as sealed if possible.
    - Pass Struct by ref to minimize on-stack copies

## 2021-oct-8 Fri

- Tech#API 
    - [OpenAPI](https://openapitools.org) & ASyncAPI - refers to API Specification 
    - OpenAPI is specification while swagger is tooling that uses OpenAPI Specification
    - API Definition - JSON/YAML documents that capture unique API's business intent aimed at meeting specification requirements.
    - OpenAPI Generator allowes generation of API Client libraries (SDK generation), server stubs, documentation and configuration automatically given an OpenAPI Spec.
    - Postman can be used to generate test cases basis OpenAPI Document
    - [OpenAPI tools](https://openapi.tools) - We  site that has many online tools like OpenAPI Specification generators, converters and so on.
    - API platforms are systems with integrated tools and processes that allow producers and consumers to effectively build, manage , publish and consume APIs.
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
- Finance/Defi
    - Stablecoin lines on a blockchain , is easily exchangeable for Bitcoin (or other crypto assets) using the tools and exchanges and brokerages andprocesses of crypto world, but is always worth a dollar. 
    - Libor is in theory the rate at which big banks can borrow unsecured for some some specified period of time. 
    - SOFT, the secured overnight financing rate, which is the rate that big institutions pay to borow overnight secured by Treasury securities. 

- Confidential Computing
    - Confidential computing is a breakthrough approach to data protection: sensitive workloads are run inside hardware-isolated and runtime-encrypted environments called enclaves. Enclaves can protect against threats like malware or rootkits and even rogue administrators and physical intruders. 

- Tech#.NET
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
                - APIs that masquarade as synchronous but are actually blocking async methods 
                - Uses 2 threads to complete single operation 
            - Blocking APIs are bad 
                - Avoid blocking APIs e.g. Task.Wait, Task.Result, Thread.Sleep, 
                    GetAwaiter.GetResult()
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
    - Async programming - don't block

## 2021-oct-10 Sun


- Tech# Application of AI and ML in Investing 
    - Machine learning approaches are typically structured to predict something from a fixed number of inputs. However, in the investment world, the input data typically come in sequences (for example, how a company’s operating results evolve over time), and the distribution of investment outcomes are conditioned by the evolution of those sequences. Recurrent neural networks, which have claimed many successes in recent years, are designed precisely for this type of sequenced data.

    - In quantitative investment research, a great deal of effort is put into “factor engineering” – the process of determining which features of a company are most valuable to forecasting the future. Deep learning provides the potential opportunity to let the algorithms discover the features based on raw financial data. That is, the “deep” in deep learning means that successive layers of a model are able to untangle important relationships in a hierarchical way from data as found “in the wild,” and these relationships may be stronger than the ones found via traditional approaches to factor engineering.

- Investing#Position Sizing 
    - First, clean up: Download current list of holdings, add a column “Percentage of Portfolio”, filter for holdings under 1%. Exit them. It doesn’t matter whether the next Amazon or the next Suzlon is in t here because they won’t move the needle, but they clutter up the screen and mind with their greens and reds.
    - Assign Conviction levels: Look through the remainder, assign Low-Medium-High conviction levels to each holding. This is not about a DCF valuation exercise but putting down your level of confidence that made you buy the stock in the first place. Note, “holding” here can mean individual stock, mutual fund, or even a set of stocks you transact as a portfolio e.g. if you allocate to a momentum portfolio, you wouldn’t assess each individual stock but the portfolio itself
    - Take Action - 
         - if < 4% allocation, 
            and convictionis low - Exit
            and conviction is  high - increase significantly
         - if  4% to 8% allocation, 
            and convictionis low - Reduce
            and conviction is  high - maintain
         - if  > 8% allocation, 
            and convictionis low - Reduce
            and conviction is  high - maintain/Trim
       - Criteria, 
            - Low Conviction Stocks: Why not exit all of them? That’d be rational. But to account for the resistance that comes from making big changes at once
            - Medium Conviction Stocks: Probably where we’d end up spending the most time. At the first pass of assigning conviction, we’ll have a bunch of these, like when guests are coming over and we stuff the living room mess out of sight into the closest drawers. Either bump medium-conviction stocks to “High” or downgrade them to “Low”. Tough as it will be to move things out of this noncommital bucket, that’s the work we’d need to do as active investors. And if you hate doing this, then ask yourself whether you really enjoy active decisions. And if not, buy the index.
            - High Conviction Stocks: Making sure to not be below a minimum alloction in these, and where a stock or two might have become an outsized part of the whole, revisit and either continue holding or reduce

- Investing 
    - alpha low vol strategy is combination of momentum and low volatility scores and arrive at list 

    - IEX commands more than 90% market share in the power exchange volumes and single digit share in overall power volumes. The 2nd exchange - PXIL is a marginal player. The 3rd exchange is currently under works and would be operational sometime in 2022.

    - IEX charges 2 paise each from buyer & seller for facilitating trading of each unit (unit=Kilo Watt Hour) of electricity. This amount is regulated by CERC (Central Electricity Regulatory Commission).

## 2021-oct-11 Mon

- Food
    - Fermentation is the process by which microorganisms—bacteria, molds, yeasts—break down food and drink and by doing so preserve them and make them more delicious and nutritious. Some food and drink ferments beloved worldwide include cheese, leavened breads, cured meats, wine, soy sauce, miso, sauerkraut, and sour pickles.

- History of AI
    - Companies such as Nvidia had developed chips called graphics processing units (GPUs) for the heavy processing required to render images in video games. Game developers used GPUs to do sophisticated kinds of shading and geometric transformation

    - NVIDIA  CUDA, a platform that enabled researchers to use GPUs for general-purpose processing.

    -the amount of computational power required to train the biggest AI systems doubled every two years until 2012—and after that it doubled every 3.4 months. 

- Crypto

    - Tether is what’s come to be known in financial circles as a stablecoin—stable because one Tether is supposed to be backed by one dollar. But it’s actually more like a bank. The company that issues the currency, Tether Holdings Ltd., takes in dollars from people who want to trade crypto and credits their digital wallets with an equal amount of Tethers in return. Once they have Tethers, people can send them to cryptocurrency exchanges and use them to bet on the price of Bitcoin, Ether, or any of the thousands of other coins.

    - There are now 69 billion Tethers in circulation, 48 billion of them issued this year. That means the company supposedly holds a corresponding $69 billion in real money to back the coins—an amount that would make it one of the 50 largest banks in the U.S., if it were a U.S. bank and not an unregulated offshore company

    -One of Tether’s former bankers told me that its top executive had been putting its reserves at risk by investing them to earn potentially hundreds of millions of dollars of profit for himself. “It’s not a stablecoin, it’s a high-risk offshore hedge fund,” said John Betts, who ran a bank in Puerto Rico Tether used. “Even their own banking partners don’t know the extent of their holdings, or if they exist.”

- Economics#

    - Poorer regions are usually poorer because their social, economic, legal, and cultural institutions prevent businesses and workers from being able to absorb high levels of capital productively.

- Tech
    - I/o Ring or io-uring (linux) - A way to synchronously queue multiple I/O operations. 
    - Networking
        - TCP is Connection-oriented protocol; UDP is a connectionless protocol

## 2021-oct-12 Tue

- How Bank Works? 
    - A bank makes a bunch of loans in exchange for senior claims on businesses, houses, etc. Then it pools those loans together on its balance sheet and issues a bunch of different claims on that balance sheet. The most senior claims, classically, are “bank deposits”; the most junior claims are “equity” or “capital.” Some people want to own a bank; they think that First Bank of X is good at running its business and will grow its assets and improve its margins and its stock will be worth more in the future, so they buy equity (shares of stock) of the bank. Other people, though, just want to keep their money somewhere safe; they put their deposits in the First Bank of X because they are confident that a dollar deposited in an account there will always be worth a dollar. The fundamental reason for this confidence is that bank deposits are senior claims (deposits) on a pool of senior claims (loans) on a diversified set of good assets (businesses, houses). (In modern banking there are other reasons — deposit insurance, etc. — but this is the fundamental reason.) But notice that this is magic: At one end of the process you have risky businesses, at the other end of the process you have perfectly safe dollars. Again, this is due in part to deposit insurance and regulation and lenders of last resort, but it is due mainly to the magic of composing senior claims on senior claims. You use seniority to turn risky things into safe things.
    - When you open a bank account, the bank doesn’t tell you “well we have a 9% capital ratio, so if our loans lose 9% of their value or less your account will be money-good, and our loans are made at an average loan-to-value ratio of 68%, so if the underlying assets lose 32% of their value or less our loans will be good, and if you multiply that it means that your cash won’t be touched unless the underlying assets lose more than 38% of their value in a correlated way, which we have calculated has a less than 1-in-1,000,000 chance of happening.” If your bank told you that you would never give them your money. What your bank tells you is “if you put a dollar in this account it’s a dollar.” There are enough layers of opacity between your deposit and the underlying risky assets that you don’t think of them as being at all connected.

    - Tech#Networking 
        - Hashing is process of forming simple numbers out of the bytes of data.

    - Strategy
        - Strategic decisions are those whose results depend on the actions and reactions of other economic entities.
        - Tactical decisions are ones that can be made in isolnation and hinge largely on effective implementation. 

## 2021-oct-13 Wed

- Competition Demystified 
    - devising strategy without taking that response into account can be
    a glaring mistake.

    - five forces that can affect competitive environment are Substitutes, Suppliers, Potential Entrants, Buyers, and Competitors within the Industry

    - Genuine competitive advantages from supply side are, 
        - Supply
        - Demand - dvantages arise because of customer captivity that is based on habit, on the costs of switching, or on the difficulties and expenses of
        searching for a substitute provider. Economies of scale. 
        - Economies of scale

    - Groucho Marx’s rule not to join any club that would have him as a member
    - To develop an effective strategy, a company not only needs to know what its competitors are doing, but to also be able to anticipate these competitors’ reactions to any move the company makes. This is the true essence of strategic planning

    -  It embraces all of the things a company does in which a competitor’s direct reactions are critical to its performance—pricing policies, new product lines, geographical expansions, capacity additions.

    - Classical game theory is primarily useful because it imposes a systematic approach to collecting and organizing the mass of information about how competitors may behave.


- Investing 
    - Dont bet what you can't afford to lose
    - Don't bet when your instincts say the game's rigged
    - Regulators may be biased
    - The game isn't fair 
    
## 2021-oct-14 Thu

- Competition
    - It is barrier to entry, not differentiation by itself, that creates strategic opportunities
    - Market price of commodity is determined in the long run by the cost levels of the most efficient producers, competitors who can not match this level of efficiency will not survive.

- Module Organization and Microservices (src: https://outline.com/DjELNf) 
    - A business that is separated into independent operations can be described as having a modular organizational structure.
    - Micro services help in 
        - Reducing internal coordination 
        - The real power of microservices is in reducing coordination and communication costs throughout the organization.

- Websockets
    -  web socket server starts off by being an HTTP server, accepting TCP conections and handling the HTTP requests on the TCP connection. When a request comes in that switches that connection to a being a web socket connection, the protocol handler is changed from an HTTP handler to a WebSocket handler. So it is only that TCP connection that gets its role changed: the server continues to be an HTTP server for other requests, while the TCP socket underlying that one connection is used as a web socket.

## 2021-oct-18 Mon

- To criticise the other person is protection against being hurt. 

- Investing 

    - There’s a long history of this verified by looking at tree rings, which incribe both heavy rainfall and subsequent fire scars. The two go hand in hand. “A wet year reduces fires while increasing vegetation growth, but then the increased vegetation dries out in subsequent dry years, thereby increasing the fire fuel,” 
    - In Japanese markets,  Returns were so extreme from 1950 to 1990 that there was nothing left over for subsequent decades.
    - Howard Marks once talked about an investor whose annual results were never ranked in the top quartile, but over a 14-year period he was in the top 4% of all investors. If he keeps those mediocre returns up for another 10 years he may be in the top 1% of his peers – one of the greatest of his generation despite being unmentionable in any given year.

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

- Investing#Arbritage,

    - The act of buying something and selling it almost immediately at a higher price is arbitrage.
    - Buying a future is like buying a stock, except that it is settled at a later date.On the expiry date of the future, the future is “settled” at the closing price in the cash market — which means the prices in the two markets converge.

- Indian Economy,

    -	As of October – 2021,
        -	India’s GDP is around 2 lakh crores
        - 	Savings are around 30% which is ~ 60 thousand crores
            -	Of this , household saving is around 65-70%
                -	Of this, Physical savings is around 50% which is  mainly Real Estate
                -	Rest is financial savings which constitutes bank deposits, insurance and Equity
                    -	Of  this,
                        -	55% is in Banks
                        -	2-3% in direct equity
                        -	3-4% in equity & debt via MF
        -	In India, Stock markets are weekly efficient
        -	In India,
            -  	50% of GDP is constituted by MSME, informal sector
            -	10% is by big corporates
            -	20% is by agriculture
            -	Sensex/Nifty constitute around 5% of GDP
    -	In US, corporate sector constitutes around 70% of GDP

- Investing#Momentum rules
    - not to buy a stock which is up 3 days in a row.
    - stock needs to have orderly move (not zigzag)
    - stock should also have orderly consolidation 
    - do not buy on extended breakout 

## 2021-oct-19 Tue

- Investing#Thoughts from Samit Vartak

    - Valuation is secondary and business analysis is primary concern 
    - ROE - 25%
    - Predictable businesses like FMCG is not high growth ones
    - Typically, 20 stock portfolio is needed to have 3-4 stocks which become 10x in 10 years 
    - nothing is stable, one has evolve with change. One has to survive and remain ahead of competition (market share)
    - Hawkins produces best quality products but they are not aggresive in marketing products. 
    - PLI Scheme - Focus on Export oriented business
    - Real estate looks like new thing, 
    - Building Material - Steel pipes, Electrical cables, tiles
    - In china, in case of layoff, company needs to compensate for n+1 months where n is no. of years completed.
    - China going more socialist from extreme capitalism
    - India has strong banking, corporate and govt. balance sheet.
    - Top 5% contribute to incremental growth of GDP; discretionary spending 
    - not very positive on financials namely corporate lending (many r generating enough cash), unsecured lending is risky. Alpha not present.
    - Auto sector - cost of manufacturing is up, cost of running has gone up. Disruption is Ahead (EV) 
    - In india , Execution is the most important aspect which may not be true for US
    - We are spending way more time in reading but less time in thinking over those readings. 

## 2021-oct-20 Wed


- Oil & Gas Industry in India, 

    - The oil and gas industry can be broken down into three main segments: upstream, midstream, and downstream.

    - Upstream businesses consist of companies searching for, recovering, and producing crude oil and natural gas. These companies are often known as “E&P” for “exploration and production.” (Oil india, GAIL)

    - Midstream businesses are those that are focused on moving the commodities via pipelines and various other modes. (GAIL, GSPC, PETRONET)

    - Lastly, downstream businesses are involved in refining and marketing various types of fuels. (BPCL, HPCL, MGL etc.)


- Investing#Stock Trading 

    - One of the main drivers of a gamma squeeze is an influx of call option purchases, which causes market makers to hedge their writing of the call options by purchasing the underlying stock, driving up the stock price in the process. 

    - The way stock trading works is that a buyer and seller agree to a trade on the stock exchange and then, two days later, the buyer delivers the money and the seller delivers the shares. That creates two days of credit risk: If the buyer vanishes, the seller doesn’t get paid. To solve this, there are clearinghouses that essentially guarantee every trade; if you sell stock, you can be confident that you’ll get your money in two days, because the clearinghouse will pay you. The main stock clearinghouse is the National Securities Clearing Corp. (NSCC); the main options one is the Options Clearing Corp. (OCC). Brokers are required to keep cash at the clearinghouses to guarantee their obligations to settle trades. The more trades a broker does, and the riskier those obligations are, the more cash the broker needs. When there’s a ton of trading in very volatile stocks, the clearinghouses will call brokers for more money.

## 2021-oct-22 Fri

- Intersection politics - Muslims are useful for this. Hindus have tendency to blend in so they just get absorbed. 
- To Indians and Chinese, talk harshly. sweet talking indicates weakness. 


- What is Convertible Debt?
    -  The way this works is typically that the lender gives the company $1,000 and the company pays back, say, $20 per year and then $1,000 at the end of five years. But at any time during those five years, the lender can, at its option, trade in the debt for shares of stock in the company. When it converts, it no longer gets any interest, and it doesn’t get its $1,000 back at the end. Instead it just gets stock.

    - In regular public-company convertible bonds, the lender gets a fixed amount of stock. If a public company issues a convertible bond when its stock is at $20, it might do it at a conversion price of, say, $25, a 25% premium to the current stock price. So a $1,000 bond will convert into 40 shares of stock. This ratio will be fixed at the time the bond is issued and stays the same no matter what the stock does. If the stock stays at $20, the bondholders won’t convert; they’d rather get their $1,000 back than convert into $800 worth of stock. If the stock goes up to $50, the bondholders will (eventually) convert; they’d rather get $2,000 worth of stock than just get their $1,000 back.

- What is Negative Working Capital?
    - Company gets paid in advance from distributors and shop keepers but tey pay their vendors after n days


- Pre-historic roving bandits realized that instead of raiding groups of humans and moving on, they could earn more by staying put and stealing from their victims all the time.

- In Moneyland, citizens are able to keep their assets outside the communities they steal them from, they don’t care what happens in the long term. The more they steal now, the more they and their children get to keep. In fact, they make money from instability: the more disputes there are, the more money there is for them to cream off

- Post world war II @ Bretton Woods, It was decided that all currencies would be pegged to the dollar, which would in turn be pegged to gold. An ounce of gold would cost $35.The US Treasury pledged that, if a foreign government turned up with $35, it could always buy an ounce of gold.

-  If other countries wished to change the value of their currency by a significant amount, they promised that they would only do so with the approval of a new body called the International Monetary Fund.

- Money flows ceaselessly between countries, nosing out investment opportunities in China, or Brazil, or Russia, or wherever. If a currency is overvalued, investors sense the weakness and gang up on it like sharks around a sickly whale. In times of global crisis, the money retreats into the safety of gold or US government bonds. In boom times, it pumps up share prices elsewhere, in its restless quest for a good return. These waves of liquid capital have such power that they can wash away all but the strongest governments. The prolonged speculative attacks on the euro, or on the rouble, or the pound, which have been such a feature of the last few decades, would have been impossible under the Bretton Woods system, which was specifically designed to stop them happening.

## 2021-oct-26 Tue

- How International transactions work, 

    - Remittances work the same way but due of the size of these transactions there are some differences in both operations and also in settlement. We will take the most popular settlement – USD. Most oil gets sold in USD, which means both buyer and seller will have to necessarily settle through a bank in US of A, irrespective of where they are. Lets take an example. BPCL buys from Saudi Aramco. BPCL Banks with SBI, Mumbai and Aramco with Al Rajhi bank in Riyadh.
    - LC Process: To place an oder with Aramco, BPCL will have to “Open” an LC favouring Aramco. Aramco will furnish it to its bank Al Rajhi and ask if the LC is trustworthy. If Al Rajhi is not comfortable with SBI’s trustworthiness or if their limits are exhausted, Al Rajhi can ask another bank to “confirm” SBI’s trustworthiness. By Confirming, this intermediate bank (say Citibank Riyadh) acts as a guarantor. All the banks in the chain make money with LC fees. Remember, without lending a $, by lending their trust (of course managing the risk)  banks make money. So this LC business, which you can see as “fee based” income in bank’s annual reports is something banks fight for.
    - In case of Iran – India payments, since it was a govt backed deal, no LCs were required to be opened. And for the purists who are reading this, there would be some open account (non LC Based) transactions between two trusted trade partners and LCs will come in only when the amounts are beyond a limit.
    - Settlement(s):
        - Goods settlement: When the ship calls on the port and unloads to the customs’ warehouse / oil farm, BPCL, by sending an “acceptance” through SBI, gets the title for goods in the port / and lifts the goods.
        The payment terms can be on “Sighting” the goods – i.e pay the money and take the goods, or agree to pay x days after “accepting” to pay. This payment period is truly between the trade partners BPCL & Aramco.
        Money settlement : Since the transaction is in USD and as both SBI and Al Rajhi, aren’t present in USD settlement zones (for now think US of A), both of them need correspondent banks in the US of A. So lets say SBI Mumbai’s correspondent bank is SBI New York and Al Rajhi’s is Citibank NY. BPCL asks SBI Mum to pay, say 500 Mn to Aramco’s a/c held with Al Rajhi, Riyad. SBI Mum will “inform” SBI NY (through SWIFT) to pay Al Rajhi’s a/c with Citi NY, SBI Mum will also send a message to Al Rajhi saying this payment is against invoice numbers 1,2,3 with a value date, say 27th Oct. Note this is 2 days from the date of initiating the message (today 25th Oct).
        This value date is important as that is the date SBI BY settles USD to CITI NY. SBI Mum’s a/c with SBI NY and AL Rajhi’s a/c with Citi NY will get debited & credited on this date. The banks dont lose money as the date is the same. But for BPCL and Aramco, it may not be the same. Due to time zone & banking system differences, the dates can be one or two days apart. Since the amounts are huge and even a single day’s float (interest) can also be huge, these payments are orchestrated days in advance. The FX rates are also negotiated based on relationship value. In reality Aramco, BPCL and every oil marketing company will have their treasurers poring through Reuters terminals to get the best rates and also enter into FX forward contracts many days in advance (typically on the day they make the order for oil itself). Several hedging tools (Forwards, futures, Swaps)  are deployed depending on frequency, value and open positions. This is risk management practiced as high art and precise science.

## 2021-oct-27 Wed

- Investing rules, 

    - Cut your losses -  put a stop point to how much money you can lose in a stock. And when you reach that point, get the hell out. How much? Well, for some people it’s 2% per trade. For others it’s 30% absolute on each investment. That’s for you to figure out.

    - Don’t buy when there’s nothing to buy - If you go to a market for tomatoes and you find only rotten bananas, will you buy them? Some people feel that when they have decided that money must go in equities they have to buy some shares right now. That is stupid. Find opportunities. It may take some time, and they may not be visible (who has the time to track everything) – but only invest when it’s a no-brainer.

    - Ride your profits -When something’s going well, stick with it. It’s always tempting to take your profits when they’re on the table. But the best profits are on a long term trend.

    - Don’t act on what you hear - Too many people feel the need to talk. They come on TV and the internet and spit out random theories on where you should invest and what you should do. Don’t just listen to them ; do your own research. I am one of these characters – so don’t listen to me, do your own research.But why do such people, including me, feel the need to educate you, or to tell you what to do? Because it satisfies their need to feel like a hero. And some of them earn their living that way – when you think they are a hero you will buy their random recommendations. For others it is a way to reinforce their own trading decisions – i.e. when they want to sell, they need to have people to buy, so they “recommend” the stock. Whichever way you look at it, it does not serve YOUR needs. In all probability you don’t know what your needs are, but you might be right for thinking it’s to profit on your investment.

    - Set a goal, and get bored - investing without a goal is like driving without a destination. It’s thrilling to know that you can drive. And you feel like you’re exploring something, learning something new. But once you realize that you have to drive everyday, it gets more and more boring until all you do when you drive is curse the traffic and long for the destination.

    - Lastly, my free advice. Don’t take free advice. It’s never worth the money you don’t pay.

- Work updates
    Issuance, 
    - Issue with Bank of India for which they had raised penalty and they wanted to understand data flow within systems. Shared updated issuance architecture diagram to be used to explain data flow. 

    Axis bank -  migration of existing document mgmt system to MOS. Migration of 1Tb of documents. Approach for the same? and whether existing infrastructure can accomodate additional compute?   
    
    BFL, 
    - Integration with BFL Services - Issues in Dashboard updates and long queue lengths for unprocessed messages. Approach is to combine tables and use partitions and also use separate Queue for BFL Updates.
    - Change in business requirements to maintain product line with limits for one card per customer 
    
    DH, 
    - Ongoing App Review 

    Sahil, 
    - Unified non-card transactions from different channels

- History of Data Architectures 
    
    -  It all started with need for business leaders to understand how business was doing. so process was to get data out of operational data systems , transform it into a central place (Data warehouse) and perform analytics on it.
    - This enabled business analysts to understand how was business was performing 
    - However, this approach started to have challenges when,
        - need arised for handling more data types , typically unstructured data like videos, audio and images. 
        - also on-prem infra was difficult and expensive to scale with evergrowing data. This is because at on-prem compute and storage were typically coupled.
        - There was apetite to perform forward looking analytics which gave indication on how business would perform in future based on available data. This required adding ML & AI on data sets.
        
    - This is where Concept of "Data lake" started getting adopted, 
        - Basically, its cheap storage area where data is just dumped from sources like OLTP systems, Other Applications, logs etc. 
        - From here, Subset of the data is moved to classical data warehouse (typically on cloud) for analytics or gaining insights  
        - Reasons are, 
            - In the Sources to DWH approach, one has to have schema up-front which is hard to get right at the beginning. Data lake to DWH provides flexibility in this. 
        - A structural transaction layer is built on top of it 
        - with lakehouse pattern, BI tool can query data lake directly without the need to have DWH or transactional layer in between.
        
    - When it comes to AI and machine learning, a lot of the secret sauce to getting really great results or predictions comes from augmenting your data with additional metadata that you have.

    - Streaming
        - All the ETL use cases are potentially candidates for streaming

## 2021-oct-28 Thu

   - API Gateway or not 
       - Implementing security and cross-cutting concerns like security and authorization on every internal service can require significant development effort. A possible approach is to have those services within the Docker host or internal cluster to restrict direct access to them from the outside, and to implement those cross-cutting concerns in a centralized place, like an API Gateway.
       - Coupling - Without API Gateway, Client apps are coupled to the internal services. Any changes in internal services directly impact clients. 
       - Security - Api Gateway can handle security aspects required for endpoints exposed to outside world 
       - Cross cutting concerns - Authorisation , TLS/SSL can be handled at API Gateway layer. 

    - Features of API Gateway, 
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

        - reference: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/architect-microservice-container-applications/direct-client-to-microservice-communication-versus-the-api-gateway-pattern

- onthropology 
    - Anthropologically, only 2-7% of population can do white collar jobs
    - rest are bread for blue collar jobs (meant to be beasts of burden)
    - Industrialization disturbed it. 
    - Manufacturing to services migration further disturbed it
    - with services, top end is white collar but remaining is blue collar but they form quasi-white collar category
    - quasi-white collar category got voice via internet and social media.
    - people want to blame everybody else for their failures...social media amplifies it 
    - wokeism is alliance between losers and failures 

    - Humanities are monopolized by leftists
