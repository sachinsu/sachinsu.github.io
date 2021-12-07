- Work updates
    DH, 
    - Ongoing App Review and New architecture

    Sahil, 
    - Unified non-card transactions from different channels

    Shortlisting & interview for Mobile & C Architect role

    BFL, 
    - System Optimization initiative - Reducing load on Oracle, shifting reporting to MIS 

    Issuance, 
    - Issue with Bank of India for which they had raised penalty and they wanted to understand data flow within systems. Shared updated issuance architecture diagram to be used to explain data flow. 

    Axis bank -  migration of existing document mgmt system to MOS. Migration of 1Tb of documents. Approach for the same? and whether existing infrastructure can accomodate additional compute?           

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
       - Cross cutting concerns - Authorisation, TLS/SSL can be handled at API Gateway layer. 

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

- Retry guidelines 
    - As a general guideline, use an exponential back-off strategy for background operations, and immediate or regular interval retry strategies for interactive operations. In both cases, you should choose the delay and the retry count so that the maximum latency for all retry attempts is within the required end-to-end latency requirement.

    - Anti-patterns
    
     - avoid implementations that include duplicated layers of retry code. Avoid designs that include cascading retry mechanisms, or that implement retry at every stage of an operation that involves a hierarchy of requests, unless you have specific requirements that demand this.

     - Never implement an endless retry mechanism

     - Never perform an immediate retry more than once.

     - Avoid using a regular retry interval, especially when you have a large number of retry attempts.

     - Prevent multiple instances of the same client, or multiple instances of different clients, from sending retries at the same times.

     [Reference](https://docs.microsoft.com/en-us/azure/architecture/best-practices/transient-faults)


## 2021-nov-01 Mon

- India Economy, 
    - South preferred over North; Central govt. discriminated against North
    - Freight equalisation policy was adopted by the government of India to facilitate the equal growth of industry all over the country. This meant a factory could be set up anywhere in India and the transportation of minerals would be subsidised by the central government. As a result of the policy, businesses preferred setting up industrial locations closer to the coastal trade hubs and markets in other parts of the country.
    - In other countries - Industries sprout around areas having abundant raw material. 
    - State governments have become retail redistribution company 
    - 80% of state revenue goes on paying pension, salaries etc.

- SoftPOS Host sends requests to WL IPG for SMSPay transactions. 
- For AmazonPay, TTMS processes the transaction.

## 2021-nov-02 Tue

- Logistics
    
    - Hauling cargo via Containers was invented by Malcolm mclean in 1956.  It provided perfect platform to drive global connectivity as they connected all dots through transportation, infrastructure, supply chain and logistics (ship,rails & trucks)
    - The International Maritime Organization (IMO) published a set of shipping container standards in the 1970s. 

- On Software Architecture

    - Every thing in Software Architecture is a trade off

    - The top 3 soft skills for any software architect are negotiation, facilitation, and leadership. Negotiation is a required skill as an architect because almost every decision you make as an architect will be challenged. Your decisions will be challenged by other architects who think they have a better approach than you do; your decisions will be challenged by business stakeholders because they think your decision takes too long to implement or is too expensive or is not aligned with the business goals; and finally, your decisions will be challenged by development teams who believe they have a better solution. All of this requires an architect to understand the political climate of the enterprise and how to navigate the politics to get your decisions approved and accepted.

    - Facilitation is another necessary soft skill as a software architect. Architects not only collaborate with development teams, but also collaborate closely with various business stakeholders to understand business drivers, explain important architecture characteristics, describe architectural solutions, and so on. All of these gatherings and meetings require a keen sense of facilitation and leadership within these meetings to keep things on track.

    - Finally, leadership is another important soft skill because an architect is responsible for leading and guiding a development team through the implementation of an architecture. They are there as a guide, mentor, coach, and facilitator to make sure the team is on track and is running as smooth as a well-oiled machine, and to be there when the team needs clarification or has questions and concerns about the architecture.

    - Trends of 2021, 
        - Exploration of low-code/no-code environments. 
        - Focus on Architecture as part of daily activities of development process. Realization of importance of evolutionary and incremental architectures
        - Move to hybrid from pure microservices based architecture. 

    - Three basic Architecture Styles
        - Monolith (Single Deployment)
        - Service based 
        - Microservices (independant deployability)
            - Common topologies 
                - API REST-based topology
                - application REST-based topology - client requests are received through traditional web-based or fat-client business application screens rather than through a simple API layer. service components tend to be larger, more coarse-grained, and represent a small portion of the overall business application rather than fine-grained, single-action services. This topology is common for small to medium-sized business applications that have a relatively low degree of complexity.
                - centralized messaging topology - instead of using REST for remote access, this topology uses a lightweight centralized message broker.message broker found in this topology does not perform any orchestration, transformation, or complex routing; rather, it is just a lightweight transport to access remote service components.
                - typically found in larger business applications or applications requiring more sophisticated control over the transport layer between the user interface and the service components. The benefits of this topology over the simple REST-based topology discussed previously are advanced queuing mechanisms, asynchronous messaging, monitoring, error handling, and better overall load balancing and scalability.

    - An architecture style describes the way your overall system is structured (such as microservices, layered monolith, and so on), whereas architecture patterns are ways of describing certain and specific architectural aspects of that overall structure. 

    - Deriving the required architecture characteristics from business needs is the key. Identify "ilities" that are important for org like Scalability, Performance, data integrity, system availability, fault tolerance, Security.

    - Lessons learned, 
        - Soft skills (people skills) matter in software architecture – they constitute 50% of being an effective software architect.
        -  Always keep the project and business constraints in mind when creating and analyzing software architecture (cost, time, budget, skill levels, etc.)       
        - Don’t get caught up in the hype as a software architect – stop, analyze tradeoffs, study trends, and approach new technology with caution.
        -  Focus more on the “why” rather than the “how” – this is what is truly important is software architecture
        -  Spreading knowledge is more valuable than being an individual contributor.

    - Reference: https://apiumhub.com/tech-blog-barcelona/software-architecture-recommendations-mark-richards/

- How to get useful answers to your questions
    - ask yes/no questions
    - state your current understanding
    - be willing to interrupt
    - don’t accept responses that don’t answer your question
    - being good at extracting information is a superpower

## 2021-nov-03 Wed

- Behavioral
    - Extrinsically Motivated Goals (EM)- Owning a home,Money,fame,image   
    - Intrinsically Motivated Goals (IM)- Personal growth, intimacy, community
    - people are less happy with materialistic acquisitions 
    - homes are depreciating assets.
    - You are paying rent whether you own a house or not

- Money fundas
    - have money but dont get tempted.
    - let money be facilitator
    - FD Rate + 5-7% is equity returns...anything promised over it is scam
    - if u dont understand financial  product, walk away 
    - Less risky way in Equity markets is to invest in Index fund 
    - financial product are their to solve your money problems and it should not be other way round.
    - buy because you need it
    - Upto 10 years -> Allocate to Debt; More than 10 years -> Allocate to Equity

## 2021-nov-08 Mon

- On ETFs 
    -  market maker is someone who buys and sells an asset in order to profit from the spread, not someone who accurately forecasts the price of an asset six months from now. End users want to buy or sell stocks or bonds or houses, they want to do it quickly at a predictable price, so they go to a market maker who will provide that service. The market maker buys from sellers and sells from buyers and does its best to match them up; ideally it buys an asset from a seller and resells it to a buyer within a fairly short time. It collects a “spread” from the buyer and seller: It buys from the buyer at a bit less than the fair market price, and sells to the seller at a bit more than the fair market price, because it is providing them a valuable service, the service of “immediacy” or “liquidity,” the service of always being available to buy or sell. 
    - Substantial differences from NAV rarely happen because traders all over the world actively trade ETF’s. They will sell ETF’s when they drift above their NAV and buy when they are below it. These actions keep the ETF’s share price close to the NAV.
    Another tool that ETF’s have to keep the price around the NAV is called creation/redemption. The ETF has agreements in place with entities known as authorized participants to exchange baskets of the ETF’s assets in exchange for shares. Authorized participants can also sell the ETF baskets of assets. The ETF can create new shares when the price is above NAV and destroy shares when the price is too low below NAV. Creation/redemption helps keep share prices in line with NAV.

- On Cement

    - Portland cement is made by first heating limestone and clay in a kiln to around 1,500ºC. The resulting mixture—known as clinker—is then mixed with gypsum and pulverised into fine powder, which can then be mixed with water and aggregates (such as sand and gravel) to make concrete. Significant amounts of carbon dioxide come from the limestone as it breaks down in the kiln. 


- Architecture 

    - The rapid development of powerful consumer-focused computing tools like smartphones has shifted the distribution of technology from central computing to the edge: the consumers themselves. 
    - consumerization of technology is driving capital disbursement in computing and storage capacity on the edge, outside of cloud and data center boundaries.

    - Modern enterprise applications have,
        - Secure - use latest encryption and protocols
        - Service oriented APIs with focus on communication.
        - Modular & Composable
        - Easily maintainable

- Delivery Performance 

    - LEAD TIME - There are two parts to lead time: the time it takes to validate a feature and the time it takes to deliver it to customers. Measuring the design part of lead time can be difficult as acceptance criteria may vary. However, the delivery part of the lead time - the time it takes for work to be implemented, tested, and delivered - is easier to measure and has lower variability.

    Shorter API lead times are better for many reasons. Like we know from API description creation and mocking, faster feedback provides quicker validation and course correction. Reduced lead times also mean defects or outages are more quickly corrected. Short lead times fulfill the portion of the Agile Manifesto that seeks to "satisfy the customer early".

    - DEPLOYMENT FREQUENCY - If not handled appropriately, deploying more often may be a risky proposition. In these situations, deployments are treated as delicate, precarious events that attract oversight and numerous controls. Similarly, conventional wisdom states that consumers want to build on a stable, consistent foundation, not integrate with the API-equivalent of a construction site. With that apparent paradox, how do we create environments capable of change?
    
    The key is satisfying both of these concerns while enabling more rapid releases is to lower batch sizes for additive changes. Reducing the amount delivered (or batch size) reduces variability in estimates, accelerates feedback, reduces risk and overhead while increasing urgency. Further, we can achieve both speed and stability if those smaller batches adhere to API Evolution principles or avoid breaking changes.

    Feature toggles are also a method to enable the benefits of continuous development while synchronizing with timed marketing or product releases. A response from the State of API Survey had this to say:

    "We deploy APIs to production multiple times a week. We deploy changes as soon as they’re completed and tested, and we keep them feature-flagged off until the whole feature is ready to go live." — Sindhu N., Technical Architect

    - MEAN TIME TO RESTORE - Creating more APIs and API changes quicker should not come at the expense of API reliability. Usually, reliability is thought of as the time between failures. However, modern API experiences are rapidly changing complex systems. In these situations, it is not a question of if an implementation will fail, but when. In this light, the critical metric becomes how quickly teams can restore service.

    High-performing API organizations recover more quickly when outages do occur. The difference is minutes rather than in hours (or even days) of their contemporaries.

    - CHANGE FAIL PERCENTAGE - A key metric when making changes to a system is what percentage of changes to production fail. Failure may include degraded service or accidental introduction of a breaking change requiring a hotfix, a rollback, or a patch. A metric like ‘change fail percentage’ helps ensure that while we encourage greater delivery tempo, we do not do so by making the system less stable.

    High-performing teams’ changes to production APIs require a lower percentage of hotfixes, rollbacks, and patches than their fellows.

- DevOps for Database

    - CELT Metrics 
        - Concurrency is the number of simultaneous requests NN
        - Error Rate is what it sounds like
        - Latency is response time, as previously defined RR
        - Throughput is requests per second XX

    These can all be calculated as average (or p99) during intervals or as they apply to individual requests (except for Throughput).

        - How to get CELT Metrics
            - Query logs. Built-in, but high-overhead to enable on busy systems; accessible only to privileged users; expensive to analyze; and most of the tooling is opsand DBA-focused, not developer-friendly.
            -  TCP traffic. Golden, if you can get it: low overhead, high fidelity, and great developer-friendly tools exist. The main downside is reverse engineering a database’s network protocol is a hard, technical problem. (Database Performance Monitor shines here.)
            - Built-in instrumentation. For example, in MySQL, it’s the performance schema
            statement digest tables; in PostgreSQL it’s the pg_stat_statements extension;
            MongoDB doesn’t have a great solution for this internally, but you can get
            most of the way there with the top() command; or if you can accept higher
            performance impact, the MongoDB profiler. These have to be enabled, and
            often aren’t enabled by default, especially on systems like Amazon RDS, but
            this instrumentation is valuable and worth enabling, even if it requires a server restart. Oracle and SQL Server have lots of robust instrumentation. Most monitoring tools can use this data.

    - Use Method
        - Utilization
        - Saturation 
        - Errors

    - Every database technology has its Kryptonite.

        - MySQL: the query cache, replication, the buffer pool.MySQL lacks transactional schema changes and has brittle replication.
        - PostgreSQL: VACUUM, connection overhead, shared buffers. PostgreSQL is susceptible to vacuum and bloat problems during long-running transactions.
        - MongoDB: missing indexes, lock contention

- Citus for PostgreSQL

    - Sharding. Citus handles all of the sharding, so applications do not need to be shard-aware.
    - Multi-tenancy. Applications built to colocate multiple customers’ databases on a shared cluster—like most SaaS applications—are called multi-tenant. Sharding, scaling, resharding, rebalancing, and so on are common pain points in modern SaaS platforms, all of which Citus solves.
    - Analytics. Citus is not exclusively an analytical database, but it certainly is deployed for distributed, massively parallel analytics workloads a lot. Part of this is because Citus supports complex queries, building upon Postgres’s own very robust SQL support. Citus can shard queries that do combinations of things like distributed GROUP BY and JOIN together.

    - A Citus cluster is composed of PostgreSQL nodes with one of two roles: coordinator or worker. A coordinator receives queries, then decomposes them into smaller queries that execute on shards of data in the worker nodes. The coordinator then reassembles the results and returns them to the client.

    - Citus is not middleware: it’s an extension to Postgres that turns a collection of nodes into a clustered database. This means that all of the query rewriting, scatter-gather MPP processing, etc happens within the PostgreSQL server process, so it can take advantage of lots of PostgreSQL’s existing codebase and functionality.

- Vitess for MySQL
    -  Sharding. Sharding is essential for scaling traditional relational databases that weren’t built natively to operate as a distributed cluster of many nodes forming a single database. Every large-scale MySQL deployment—and there are thousands—uses sharding, bar none.
    - Kubernetes deployment. You can’t just run a database like MySQL on Kubernetes without a robust suite of operational tooling for high availability. MySQL just wasn’t built to run on ephemeral machines. Vitess makes it possible to treat a MySQL node as disposable.
    - Guardrails. MySQL, like most databases, is pretty easy for a badly behaved application or user to take down completely. A single runaway query or resource hog can create priority inversions and starve all the useful work. Vitess prevents this

    - Vitess can be described as “sharding and HA middleware,” but really it’s a new distributed database that is built on the shoulders of giants. Individual nodes run MySQL and leverage its capabilities as a leaf storage node. The resulting database automatically shards a single application’s data across many nodes, and automatically distributes a single query to run in a scatter-gather pattern in parallel across those nodes too. It is more designed for transactional workloads, than analytics workloads.

- Kubernetes    
    - A Pod is an environment for multiple containers to run inside. The pod is the smallest deployable unit you can ask Kubernetes to run and all containers in it will be launched on the same node. A pod has its own IP address, can mount in storage, and its namespaces surround the containers created by the container runtime such as containerd or CRI-O.
    - pod is a single instance of your application, and to scale to demand, many identical
    pods are used to replicate the application by a workload resource (such as a Deployment, DaemonSet, or StatefulSet).
    Your pods may include sidecar containers supporting monitoring, network, and security,
    and “init” containers for pod bootstrap, enabling you to deploy different application
    styles. These sidecars are likely to have elevated privileges and be of interest to an
    adversary.
    - The lifecycle of a pod is controlled by the kubelet, the Kubernetes API server’s
    deputy, deployed on each node in the cluster to manage and run containers. If the
    kubelet loses contact with the API server, it will continue to manage its workloads,
    restarting them if necessary. If the kubelet crashes, the container manager will also
    keep containers running in case they crash. The kubelet and container manager
    oversee your workloads.

## 2021-nov-11 tue

  - Data Discovery - inner workings 
    - Unified Metadata store for relational/Data warehouse, ETL tools and BI tools each 
    - Query Parsing (with support for different SQL Dialect) to analyze how tables,columns are being used to arrive at popularity model like say Top n usage  
    - Data lineage is the common thread that ties together all of your data pipelines, workflows, and systems.  

  - Disk Access
    - Disk accesses are slow because they involve mechanical operations. To read a
block of data from a disk requires the read arm to move to the right track; the platter
must then spin until the desired block is under the read head. This process typically
takes 10 ms. Compare this to reading the same amount of information from RAM,
which takes 0.002 ms, which is 5,000 times faster. The arm and platters (known as
a spindle) can process only one request at a time. However, once the head is on
the right track, it can read many sequential blocks. Therefore reading two blocks
is often nearly as fast as reading one block if the two blocks are adjacent. Solidstate
drives (SSDs) do not have mechanical spinning platters and are much faster,
though more expensive.

## 2021-nov-12 wed

- Apache Airflow for ETL 
    - Primarily a workflow Management tool
    - Using Airflow to schedule and monitor ELT pipelines, but use other open-source projects that are better suited for the extract, load and transform steps. Notably, using Airbyte for the extract and load steps and dbt for the transformation step.
    -   With Airflow you can use operators to transform data locally (PythonOperator, BashOperator...), remotely (SparkSubmitOperator, KubernetesPodOperator…) or in a data store (PostgresOperator, BigQueryInsertJobOperator...).
    -  One of the main issues of ETL pipelines is that they transform data in transit, so they break easier. Hence move to ELT.
    - Airflow transfer operators together with database operators can be used to build ELT pipelines

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
        - Pursue best practices such as good base image selection, container hierarchies, dependency version management, package selection minimalism, layer management practices, cache cleaning, reproducibility, and documentation. 
        -  Images should be rebuilt cleanly on a periodic basis incorporating vetted versions, patches and updates. Teams should frequently remove unnecessary or disused packages and assets as part of their maintenance process, test changes, and redeploy. 
        - Containers are not inherently secure; Container hardening should be integrated into the build process well before deployment. Thinking about security considerations proactively and early can help reduce risk. Scanning individual images for potential vulnerabilities is and should be a standard practice in any new environment.
        - having a strong organizational capability to plan, organize, and deploy incremental system changes is critical to any change while maintaining continuity of operations
        - Orchestrating containers is the best way to accomplish complex tasks.Kubernetes, a popular orchestrator, can be provided by many cloud vendors as well as on-premise infrastructure software vendors such as VMWare or Red Hat. The cost and maintenance of these infrastructures should be heavily weighed.
        - Individuals’ behaviors are guided (implicitly or explicitly) by underlying structures. Adoption must start with a purpose, whether that is a service or part of a larger project. Investment is needed during spin up to ensure proper experience is gained by project members. The chosen project must also have a clearly defined success metric.
        - Some Questions to consider, 
            - What paradigms will we follow when building and deploying containers?
            - How will we provide guidance on container creation?
            - How will we keep each container as optimized as possible?
            - What strategies will support long-term storage needs?
            - How might we build from small and functional base images?
            - What guidelines are needed to ensure that projects are easily rebuilt?
            - What processes are needed to keep images up to date?
            - What are you going to do to scan your images before build and deployment?

## 2021-nov-11 thu

- humanities control masses ( and human mind)
- Science has always been slave to humanities

- Corruption in ex-colonies, 
    - The political theorist Francis Fukuyama – who has given up on the idea that history has come to an end – argues in his 2011 book The Origins of Political Order that this is a damagingly wrong way of looking at the world. The liberal capitalism of Western Europe, the United States and the other Western countries is not only extremely unusual, but also just one of multiple kinds of government. Corruption, he writes, often emerges where a Western-style state and economic structure has been imposed through ignorance or arrogance on to a society with totally different traditions.In essence what this meant was that the ex-colonies gained a dual form of government: kinship-based structures on the one hand, and a European-style state structure on the other. The post-independence rulers were able to use whichever form of government benefited them at any particular time, whether to enrich themselves or to punish their enemies, and to switch back and forth between them as often as they wanted.

- Isolation of china - Why not possible?
    - Artificial supply constraints 
        - Semiconductors - China is artificially constraining the supply of semiconductors and can ramp up production overnight which is barrier for other countries to build their own production lines 
        - Rare Earths - China can flood the market at favourable price points
    - Compromised leadership

- Technology Arch - How much spare capacity
    - Suppose it takes a week (168 hours) to repair the capacity and the MTBF is 100,000 hours. There is a 168/1; 000; 000 * 100 = 1.7 percent, or 1 in 60, chance of a second failure. Now suppose the MTBF is two weeks (336 hours). In this case, there is a 168/336  100 = 50 percent, or 1 in 2, chance of a second failure—the same as a coin flip. Adding an additional replica becomes prudent. MTTR is a function of a number of factors. A process that dies and needs to be restarted has a very fast MTTR.If all this math makes your head spin, here is a simple rule of thumb: N+1 is a minimum for a service; N+2 is needed if a second outage is likely while you are fixing the first one.

## 2021-nov-12 fri

- Economy
    - Baltic dry index has fallen significantly this week. This means demand for bulk shipping is crashing.

- Tech#Backpressure
    - In a producer-consumer system, there could be mismatch between rates at which production and consumption happens.  Backpressure is the ability of the consumer to say “Yo, hang on a minute!” to the producer, causing the producer to stop until the consumer catches up.

- Tech#Scale versus Resiliency
    - If we are load balancing over two machines, each at 40 percent utilization, then either machine can die and the remaining machines will be 80 percent utilized. In such a case, the load balancer is used for resiliency.
    - If we are load balancing over two machines, each at 80 percent utilization, then there is no spare capacity available if one goes down. If one machine died, the remaining replica would receive all the traffic, which is 160 percent of what the machine can handle. The machine will be overloaded and may cease to function. Two machines each at 80 percent utilization represents an N+0 configuration. In this situation, the load balancer is used for scale, not resiliency.

- Tech#RAM Chip Manufacturing 
    - you must understand that the difference between high-quality RAM chips and normal-quality chips is how much testing they pass. RAM chips are manufactured and then tested. The ones that pass the most QA testing are sold as “high quality” at a high price. The ones that pass the standard QA tests are sold as normal for the regular price. All others are thrown away.

## 2021-nov-15 Mon

- Tech#Governance and Security related aspects of API
    - Naming convention or case configuration
    - Default response handling based on status code
    - Security headers or authentication required on APIs

- Tech#Scaling, Sharding etc.
    - Drawbacks of Scale Up
        - there are limits to system size. The fastest, largest, most powerful computer available may not be sufficient for the task at hand. No one computer can store the entire corpus of a web search engine or has the CPU power to process petabyte-scale datasets or respond to millions of HTTP queries per second. There are limits as to what is available on the market today.
        - this approach is not economical. A machine that is twice as fast costs more than twice as much. Such machines are not sold very often and, therefore, are not mass produced. You pay a premium when buying the latest CPU, disk drives, and other components.
        - scaling up simply won’t work in all situations.
            - Buying a faster, more powerful machine without changing the design of the software being used usually won’t result in proportionally faster throughput.
            - Software that is single-threaded will not run faster on a machine with multiple processors.
            - Software that is written to spread across all processors may not see much performance improvement beyond a certain number of CPUs due to bottlenecks such as lock contention.
    - Some Scaling techniques, 
        - Segment plus Replicas: Segments that are being accessed more frequently can be replicated at a greater depth. This enables scaling to larger datasets (moresegments) and better performance (more replicas of a segment). 
        - Dynamic Replicas: Replicas are added and removed dynamically to achieve required performance. If latency is too high, add replicas. If utilization is too low, remove replicas.
        -  Architectural Change: Replicas are moved to faster or slower technology based on need. Infrequently accessed shards are moved to slower, less expensive technology such as disk. Shards in higher demand are moved to faster technology such as solid-state drives (SSD). Extremely old segments might be archived to tape or optical disk.
    - Cache 
        - The Least Recently Used (LRU) algorithm tracks when each cache entry was used and discards the least recently accessed entry    
        - The Least Frequently Used (LFU) algorithm counts the number of times a cache entry is accessed and discards the least active entries

    - Data Sharding  - is a way to segment the database that is flexible, scalable and resilient. A hash function is algorithm that maps data of varying length to a fixed length value. 
        - Distributed hash table pattern involves generating hash of the key and allocating data as per hash value like, 
            - Odd or even or power of 2 (i.e. 2(n) where n is last n bits of hash) -- For 2 shards
            - reminder of hash divided by 4 - for 4 shards

    - Threads vs Processes
        - Processes have their own address space, memory and open file tables
        - Processes are self isolating i.e. corrupt process cannot hurt other processes 
        - Existing processes can execute task much faster. (An example of queueing implemented with processes is the Prefork processing module for the Apache web server. On startup, Apache forks off a certain number of subprocesses. Requests are distributed to subprocesses by a master process.)

## 2021-nov-16 Tue

- History

Caution! External email. Do not open attachments or click links, unless this email comes from a known sender and you know the content is safe.
    - The original Islamic rulers weren’t particularly interested in converting Christians as these provided them with tax revenues –the proselytism of Islam did not address those called “people of the book”, i.e. individuals of Abrahamic faith. In fact, my ancestors who survived thirteen centuries under Muslim rule saw advantages in not being Muslim: mostly in the avoidance of military conscription.

    - Gnostic religions are those with mysteries and knowledge that is typically accessible to only a minority of elders, with the rest of the members in the dark about the details of the faith

- Economy
    - When fewer people move to a town/city, demand for housing falls, and when the demand for housing falls, so does the cost of living.

- Architecture Decision Records (ADR) (https://www.cognitect.com/blog/2011/11/15/documenting-architecture-decisions)
    
    - Format of ADR 
        - Title - For Example: "ADR 1: Deployment on Ruby on rails 3.0.10" 
        - Context - Describes forces at play including technological, political, social and project local. The language in this section should be describing facts and nothing else
        - Decision - Describes response to forces mentioned in "Context".  It is stated in full sentences, with active voice. "We will …"
        - Status - A decision may be "proposed" if the project stakeholders haven't agreed with it yet, or "accepted" once it is agreed. If a later ADR changes or reverses a decision, it may be marked as "deprecated" or "superseded" with a reference to its replacement.
        - Consequences - This section describes the resulting context, after applying the decision. All consequences should be listed here, not just the "positive" ones. A particular decision may have positive, negative, and neutral consequences, but all of them affect the team and project in the future.

- AKF Scaling Cube
    - x-axis (horizontal scaling) - cloning systems or increasing their capacities to achieve greater performance.
    - y-axis (vertical scaling) - scales by isolating transactions by their type or scope, such as using read-only database replicas for read queries and sequestering writes to the master database only.
    - z-axis (lookup based scaling) - is about splitting data across servers so that the workload is distributed according to data usage or physical geography

- Software Resiliency
    - Spare capacity is like an insurance policy: it is an expense you pay now to prepare for future trouble that you hope does not happen. It is better to have insurance and not need it than to need insurance and not have it.
    - in a 1+1 redundant system, 50 percent of the capacity is spare. In a 20+1 redundant system, less than
    5 percent of the capacity is spare. The latter is more cost-efficient.
    - Mean time between failures (MTBF) - The MTBF of the system is only as high as that of its lowest-MTBF part.
    - The time it takes to repair or replace the down capacity is called the mean time to repair (MTTR).
    - The probability of second failure happening during repair window is MTTR/MTBF * 100
    - If we are load balancing over two machines, each at 40 percent utilization, then either machine can die and the remaining machines will be 80 percent utilized. In such a case, the load balancer is used for resiliency.A load balancer provides scale when we use it to keep up with capacity, and resiliency when we use it to exceed capacity.

- DOS Attacks
    - A denial-of-service (DoS) attack is an attempt to bring down a service by sending a large volume of queries. A distributed denial-of-service (DDoS) attack occurs when many computers around the Internet are used in a coordinated fashion to create an extremely large DoS attack. DDoS attacks are commonly initiated from botnets, which are large collections of computers around the world that have been successfully infiltrated and are now controlled centrally, without the knowledge of their owners.
    - This kind of Attack must be blocked from outside your network, usually by the ISPs or CDNs you connect to.

- Scraping Attacks
    - involves extracting useful information from site. often fast scraper is equivalent of DOS Attack. 
    - Usually mitigated by having all frontends report information about queries to central scraping detector service.

- Crash Data Collection & Analysis 
    - Every crash should be logged. Crashes usually leave behind a lot of information in a crash report. The crash report includes statistics such as amount of RAM and CPU usage at the time of the process’s death, as well as detailed information such as a traceback of which function call and line of code was executing when the problem occurred
    - A coredump—a file containing the contents of the process’s memory—is often written out during a crash

- Disadvantages of Database Triggers (MySQL Specific but most likely applicable to others too)
    - Triggers are stored routine. They are interpreted and not compiled
    - Triggers are in same transactions as incoming queries and are executed concurrently. This means additional locks for resources 

- Format for "Design Document" 
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

- Data Lake pattern 
    - Response to complexity, expense and failures of datawarehouse pattern.
    - Inverse of Data warehouse Pattern 
    - Centralized data collection 
    - "Load and transform" rather than "transform and load" 
    - Data extracted from many sources and often stored as-is or in "raw" format
    - disadvantages, 
        - diffcult to understand relationships due to raw format
        - Ad-hoc transformations
        - lack of ownership from original owners

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

## 2021-nov-19 Fri

- The Overton window is the range of policies politically acceptable to the mainstream population at a given time. It is also known as the window of discourse.

- Throwing the stone in water and watching ripples

- Carefully crafted PR Strategy

- diversity not in terms of Opinion

## 2021-nov-22 Mon

- Financial Markets & Human Psychology
    - Currency Market, 
        - At $6.6 trillion in daily volume, the foreign exchange market is the largest financial market in the world.
        - Currency returns are driven by two variables: changes in the spot rate (i.e., how many rupees you can buy with a dollar) and changes in the spread between countries’ interest rates (i.e., how much interest rupees earn versus how much interest dollars earn in interest-bearing accounts).
        - Falling interest rate differentials and declining volatility have made currency markets a difficult place to make money.

    - ETF,
        - An ETF is simply a basket of securities that are publicly traded in the marketplace.
        - Throughout the day, there is an “INAV,” or intra-day net-asset-value, which tracks the value of an ETF on a 15-second basis. The INAV will be based on the prices associated with underlying stocks.Unfortunately, INAVs are not always 100% accurate, and by design, they can be up to 15-seconds delayed. 

        - One way the market maker makes money is by creating a bid/ask spread around the ETFs true tick-by-tick value. For example, let’s say the value of the underlying basket of stocks in an ETF is worth $25. A market maker might post a bid at 24.95 and post an ask of 25.05. So if someone wants to sell the ETF, they will get 24.95, not $25. The 5 cent difference goes to the market maker. Similarly, on the buy transaction, an ETF buyer will pay $25.05 for the ETF. The buyer will get an asset worth $25, and the 5 cent premium will go to the market maker for making a market in the ETF.


        - Secondary Market Purchase - Now let’s say someone comes along in the secondary market, sees the posted Ask, and wants to purchase the ETF at $83.91. When this happens, what does the market maker do?
        The authorized participant (AP) does not own any ETF shares to sell. However, as a market maker, he can effectively create new shares by  “selling short” a TECH share to this secondary market participant for $83.91. The AP is “short,” in the sense that he will at some point in the future (within 6 days) need to deliver these ETF shares to the buyer. As he sells the ETF “short” in the secondary market, he will simultaneously go into the market and go long the basket for $83.86, as a hedge. The AP wants to be fully hedged: he is long the basket of names, and short the ETF (but has to deliver it in the future). He has made the market, is fully hedged, and has made a small spread in the transaction.

        - Secondary Market Sale -Now let’s say someone comes along in the secondary market, sees the posted Bid, and wants to sell the ETF at $83.75. So the market maker buys the ETF from this secondary market participant at $83.75, and in order to hedge, he shorts the basket of names at $83.80.

        - Points to remember, 
            - Pay attention to the liquidity on the holdings of your ETF–this will explain the spreads in the secondary market.
            - Trade ETFs when the underlyings are liquid–avoid trading ETFs at the open or when overall market volume is lackluster.
            - Avoid huge market orders, and stick to limit orders. Moreover, for huge trades, communicate directly with the market maker or your ETF trading desk. 

- Psychology
    - That human beings have an inbuilt tendency to look for and favour evidence that confirms their pre-existing beliefs – about investment, politics, or any other subject – is not a particularly new or radical idea.
    - It seems we’ve long been naturally inclined to take mental short-cuts. In other words, we make up our minds about something and then surround ourselves with messages that support our position on that subject. We’re philosophically and emotionally dug in.
    - In recent years, with the decline of traditional media and the rise of social and niche media, it’s become ever easier to wrap oneself in the blanket of news and information that reinforces one’s preconceptions.
    - In politics, that can lead to people latching on to crazy conspiracy theories. In investment, it can lead to missed opportunities or highly concentrated portfolios or botched attempts at market timing.
    - One solution suggested by psychologists is to encourage the client to imagine they are on the other side of the argument and, without changing their fundamental position, put together a case for the opposition.

- Tech#When to disintegrate operational data 
    - Change control - How many services are impacted by database changes?
    - Connection Management - Can the database handle the connections needed?
    - Scalability - Can the database scale to meet demands of services?
    - Fault Tolerance - How many services are impacted by database crash / downtime?
    - Architectural Quanta - Is single shared database forcing to undesirable quantum ?
    - Can i optimize my data using different database types?

## 2021-nov-23 Tue

- An architectural quantum is defined as an independently deployable artifact with high functional cohesion, high static coupling, and synchronous dynamic coupling.
    - Coupling - Two parts of a software system are coupled if a change in one might cause a change in the other.
    - Static coupling  - Represents how static dependencies resolve within the architecture via contracts.
These dependencies include operating system, frameworks, and/or libraries delivered via transitive dependency management, and any other operational requirement to allow the quantum to operate.
   - High static coupling implies that the elements inside the architecture quantum are tightly wired together, which is really an aspect of contracts.
   - Dynamic coupling -Represents how quanta communicate at runtime, either synchronously or asynchronously.
Thus, fitness functions for these characteristics must be continuous, typically utilizing monitors

- A data domain is a collection of coupled database artifacts—tables, views, foreign keys, and triggers—that are all related to a particular domain and frequently used together within a limited functional scope
    - A data domain is an architectural concept, whereas a schema is a database construct that holds the database objects belonging to a particular data domain. While the relationship between a data domain and a schema is usually one to one, data domains can be mapped to one or more schemas, particularly when combining data domains because of tightly coupled data relationships

- Aspects for Data integration and disintegration 
    - Data relationships
        - Is Change control more important than preserving foreign key relationships
        - Is fault tolerance more important than preserving materialized views between tables 
    - Database transactions
        - Is transactional unit of work required or will eventual consistency be acceptable

- Column family databases, also known as wide column databases or big table databases, have rows with varying numbers of columns, where each column is a name-value pair. With columnar databases, the name is known as a column-key, the value is known as a column-value, and the primary key of a row is known as a row key.

## 2021-nov-23 Wed
    
- R. Bala's Wisdom on finance and investing
    - On Financial Freedom 
        - Maximum possible contribution to PPF and Continue till 25 years
        - Manual Monthly SIP in Index ETF. SIP amount to be increased with rise in income
        - 10% in Gold ETF or paper (SGB) on regular basis 
        - One year's expenses in Savings account or Fixed Deposit
        - Insurance 
        - Health - Start with Modest policy of 5-10 lakh and top-up later in life
        - Life - Term Policy only. Even for it, stop paying once you are financially secure and provided for your family. Look out for "Negotiable" Term policy.
        - Borrowings - The ONLY borrowing one shoul ever do in life is to take a housing loan. Any other borrowing is a path todebt, personal loans, loans against shares, properties etc will land you in a soup.to our ruin.
        - Lending - do not lend to any one if answer is yes for "Will it hurt me or bother me if the money does not come back?"
    - On PSU stocks, 
        - They are not investing but trading/speculative opportunities
        - Smokestack PSUs [BHEL etc.] - Price to Book (PB) would be far lower than private sector couterpart. buy if the market conditions are normal (not in these pandemic times) and the prices are close to historic lows based on P/BV.
        - New Age (Post 1991) PSUs [Concor, IRCTC, RITES etc.] - Earnings are valuation anchor. buying trigger here has to be something like an earnings surprise on the downside or news flow that brings the price crashing.
        - Window-dressing PSUs  (PFC] - Mainly financiers. Avoid these companies.
        - PSU Banks - Privatisation could be opportunity but luck would play a very big role in this.
    - On Banking and finance stocks, 
        - CAMEL Approach - "Capital adequacy, Asset quality, Management, Earnings, Liquidity, and Sensitivity."
        -  In early companies or new entities, the “M” becomes a key determinant. If the “M” is high quality, the rest of the CAMEL should logically follow.
        -  Bajaj Finance has a dominant market share in financing consumer appliances. Their speed, their technology and their size give them an advantage that is not easy to conquer. The management quality is also very favourable in terms of trust. They enjoy a great ROE. Similarly, Sundaram Finance has built its core competencies in the vehicle financing segment. Their management of risk across businesses is outstanding. Cholamandalam has demonstrated its strength in vehicle finance and is now making headway in Home Loans and MSME lending. Muthoot/ Manappuram have their dominant market positions in gold loans. Similarly, there are micro finance companies that have done well in their chosen niche. 
        - Checklist to choose lending stock (in below order), 
            - Who owns and manages the company 
            - Their customer segment and growth potential
            - Check the ROE
            - Check if there are subsidiaries (e.g. , a Kotak Bank or a HDFC Ltd own other businesses which are worth more than the original cost of business attached to them. )
            - refer to buy when the Price to Book Value is closer to the lower end of historical highs/lows
    - On Trading
        - Divide portfolio in 2 categories
            - Long-term (based on "Earnings") - Typically from services, information technology, BFSI, FMCG. 
            - Trading ("Balance sheet") 
        - buy them when the Price to Book Value number is close to the historical lows
        - The P/BV is typically low when the commodity price cycle is in the doldrums, earnings tend to be in the brackets and the PE multiples are either absent due to losses or very high
        - dedicated corpus for speculative trading 
        - To Sell, 
            - See the historical high and low P/E and also look at the ROE trend of a stock
            - Prepare list of top stocks which are closer to high end of historical P/E
        - Rules
            - Stop loss of 10 %
            - Stop profit at 30%
            - Get out in 2 months no matter what 
 
    - On Market Falls 
        - As long as global flows of portfolio money in to our markets are not threatened, panics will be short lived. 
        - avoid 
            - simply stop SIPs or new investments
            - Sell in the hope of being able to buy lower or simply sell and cut perceived losses
            - Sell only those shares which show a ‘profit’ and hang on to those under water

- Architect Role
    - Avoiding Snake Oil and Evangelism
        - One unfortunate side effect of enthusiasm for technology is evangelism, which should be a luxury reserved for tech leads and developers but tends to get architects in trouble.
        - Trouble comes because, when someone evangelizes a tool, technique, approach, or anything else people build enthusiasm for, they start enhancing the good parts and diminishing the bad parts. Unfortunately, in software architecture, the trade-offs always eventually return to complicate thin
        - An architect should also be wary of any tool or technique that promises any shocking new capabilities, which come and go on a regular basis.
        - Always force evangelists for the tool or technique to provide an honest assessment of the good and bad—nothing in software architecture is all good—which allows a more balanced decision
        - solutions in architecture rarely scale outside narrow confines of a particular problem space
        - Don’t allow others to force you into evangelizing something; bring it back to trade-offs.
        - We advise architects to avoid evangelizing and to try to become the objective arbiter of trade-offs. An architect adds real value to an organization not by chasing silver bullet after silver bullet but rather by honing their skills at analyzing the trade-offs as they appear.

- Travel#East Asia
---- If you are in Taiwan or china or japan, ask for buddhist amitabha restaurant who serve vegetarian food.

- Finance#How options work
    - The basic deal with options is that when you buy an option from a dealer, the dealer will hedge the option by buying or selling the underlying stock; in particular the dealer will adjust its hedge by buying the stock when it goes up and selling it when it goes down. This makes the stock more volatile: When it goes up, options dealers are buying and pushing it up more; when it goes down, they’re selling and pushing it down more. Dealers who sell options are said to be “selling volatility.” They produce volatility with their trading and sell it to customers. Customers want a lot of Tesla volatility. So a lot of Tesla volatility is produced and delivered to them

## 2021-nov-26 Fri

- Renko charts 
    - plots price movement as renga (which is bricks in Japanese) 
    - Brick size indicates % change in price movement in underlying instrument basis which brick would be plotted
    - Easier to represents trend than with other chart types like line, bar , candlestick etc. 
        - Methods to plot Renko charts, 
            - Absolute - Absolute brick size. Closing price is used. Preferred for short term trading.
            - ATR based - Brick size determined by Volatility indicator (like ATR).
            - High/low method - New bricks on high/low value. 
            - Fixed percentage - Brick size based on percentage. Preferred for long term trend identification.
    - Renko Reversal - brick color change 


- Cash flow statement (https://online.hbs.edu/blog/post/how-to-read-a-cash-flow-statement) 
    - typically broken into three sections:
        - Operating activities - cash flow that’s generated once the company delivers its regular goods or services, and includes both revenue and expenses.
        - Investing activities -  include cash flow from purchasing or selling assets—think physical property, such as real estate or vehicles, and non-physical property, like patents—using free cash, not debt.
        - Financing activities - detail cash flow from both debt and equity financing.

    - Ideally, a company’s cash from operating income should routinely exceed its net income, because a positive cash flow speaks to a company’s ability to remain solvent and grow its operations.
    - Direct Method - To calculate the operation section using the direct method, take all cash collections from operating activities, and subtract all of the cash disbursements from the operating activities.
    - Indirect Method - convert net income to actual cash flow by de-accruing it through a process of identifying any non-cash expenses for the period from the income statement. The most common and consistent of these are depreciation, the reduction in the value of an asset over time, and amortization, the spreading of payments over multiple periods.

    
## 2021-nov-29 Mon

- Payments in Some countries 
    - Japan - furikomi (Zengin) is a clearing house; it operates as an interbank intermidiary which both routes information about individual payments and also acts as a counterparty for settlements. A user’s bank credits them with funds instantly if received during business hours; the funds are actually received after business hours, when Zengin totals up funds flows for the day and sends instructions to the Bank of Japan for net settlement between participating financial institutions. Typically used for B2B or large ticket purchases by consumers.

    - US - Automated clearing house (ACH) - ACH transfers support both push and pull transaction. ACH based payment confirmation are delayed and it accordingly affects release of goods. They are generally free to end users.

    - Europe - Single European payment area (SEPA) offers free and instance transactions between european banks. they are pull based. Fraud rates are highest than Furikomi, ACH or UPI. 


- Investing
    - BIN - Bias, information and noise. Noise is twice as important as bias 
    - Investors are buying partial stakes in companies. They need to ground their thinking in cash flow models. Speculators, in contrast, are trying to find stocks that go up. While there are pockets of speculation.

    - Present Value is today’s value of tomorrow's cash flow. A dollar in the present is worth more than a dollar in the future because you can invest a dollar today and earn a positive rate of return. This process is called compounding. The reverse of compounding is discounting, which converts a future cash flow into a present value.

    - Sales growth is often the value trigger that has the greatest impact on shareholder value

- Demand and Supply
    - If prices and quantities are moving in the same direction, it is a change in demand that is driving the price change. If prices and quantities are moving in opposite directions, it is a change in supply that is driving the price change

## 2021-dec-01 Wed

- Quote - "It is difficult to get a man to understand something, when his salary depends on his not understanding it" - Upton Sinclair

- Architecture 
    -  Don't adopt a new system unless you can make the first-principle argument for why your current stack fundamentally can't handle it.
    - Whenever you find yourself arguing for improving infrastructure by yanking up complexity, you need to be very careful. 
    - Typical issues while adopting new technologies are, 
        - Slower performance (hard to debug)
        - Scalability issues (because you don't know the system well)
        - Complexity may lead to more downtime
    - Stop thinking about technologies, and start thinking in first-principle requirements (the idea is to break down complicated problems into basic elements and then reassemble them from the ground up), 
        - In case of databases, it could be, 
            - You need faster inserts/updates (i.e. Not Synching every write to disk immediately which can be done in Mysql using [flush log settings](https://dev.mysql.com/doc/refman/8.0/en/innodb-parameters.html#sysvar_innodb_flush_log_at_trx_commit) and in postgresql using [Asynchronous commits](https://www.postgresql.org/docs/9.4/wal-async-commit.html))
            - You need terabytes of storage to have runway for the next ~5 years
            - You need more read capacity (i.e. use Read Replicas)

- Approaches to First Principles thinking, 
  - Socratic questioning generally follows this process:
    - Clarifying your thinking and explaining the origins of your ideas (Why do I think this? What exactly do I think?)
    - Challenging assumptions (How do I know this is true? What if I thought the opposite?)
    - Looking for evidence (How can I back this up? What are the sources?)
    - Considering alternative perspectives (What might others think? How do I know I am correct?)
    - Examining consequences and implications (What if I am wrong? What are the consequences if I am?)
    - Questioning the original questions (Why did I think that? Was I correct? What conclusions can I draw from the reasoning process?)

- Reasoning by first principles is useful when you are 
  - (1) doing something for the first time, 
  - (2) dealing with complexity, and 
  - (3) trying to understand a situation that you’re having problems with.

## 2021-dec-02 Thu

- IT 

    - CPaaS stands for Communications Platform as a Service. It is one of the coolest ways of enriching your customer communication channels. It acts as a platform for businesses to combine the reliability and backend of proven communication services with their custom applications through the use of APIs (application programming interface). It is programmable, customizable, and very versatile. 

- Finance

    - Hedge funds usually employ short-selling and leverage to generate alpha.

    - Stocks and Inflation 
        - Periods of very high inflation hurt your overall returns in terms of constant purchasing power
        - If we are going to a period of much lower inflation, we should start getting “real returns”.
        - Therefore it’s better to invest during a period of low inflation, but of course, stock prices have be justifiable.

- BlockChain/Crypto

    - A DAO is a company that has no leadership structure. Everything is done by vote using tokens (of course, this time called a governance token). DAOs are themselves super interesting. Just last night, a recently formed DAO called ConstitutionDAO tried and failed to buy one of the 13 physical copies of the U.S. Constitution, largely just because. The idea was to pool a LOT of money together to go buy a big thing, and then everyone who contributed the money would somehow get to vote on what to do with it.

- Behavioral/psychology
    - Paradoxes of life, 
        - Have you noticed that the most argumentative people rarely persuade anyone of…well…anything? The most persuasive people don’t argue—they observe, listen, and ask questions.
        - You have to put in more effort to make something appear effortless.
        - The more you learn, the more you are exposed to the immense unknown.
        - To do truly great, creative work, you have to be a lion. Sprint when inspired. Rest. Repeat.
        - Every successful investor & builder has stories of the invaluable lessons learned from a terrible loss in their career. Sometimes you have to pay to learn.
        - Our greatest moments of growth often stem directly from our greatest failures. Don’t fear failure, just learn to fail smart and fast.
        - Say yes to what matters, say no to what doesn’t. Protect your time as a gift to be cherished.
        - Make a habit of getting closer to your fears.
        - Taleb calls it the noise bottleneck: As you consume more data, the noise to signal ratio increases, so you end up knowing less about what is actually going on.
        - Growth is never linear. Shedding deadweight may feel like a step back, but it is a necessity for long-term growth.

- Sociology

    - Why are cows revered ? - Typically in de-urbanized, feudal society and pastoral society, cattle are much more valuable. 
    - There is a strong evidence that hadappa civilization consumed beef 
    - India is too economically left leaning, likes living on hangouts, dont want to do hard work.
    - Right wings politics is for people with self respect and want to do hard work.
    - In ancient islamic and christian world, charging interest was considered crime and banking was left to jews. When you can't pay your debt, you try to demonize/kill bank/bankers. This could be one of the reasons for anti-semitism. 
    - Wokism is powerful tool for internal control and external suppression.
    - The basis of religion and passion is wealth
    - Money is the base of all the assignments

## 2021-dec-03 Fri

- Approach to API Design
    - Set the Right Design goals (e.g. incrased conversion rate, access to data and services)
    - Sketch and prototype iteratively 
    - API Design Reviews. It can cover, 
        - Visibility of System Status
        - Match between system and real world
        - Consistency and Standards
            - Are interface and data models internally  consistent?
            - Does the API adhere to specifications and organizational standards?
        - Error Prevention 
        - Flexibility and efficiency of Use
        - Help Users recognize, Diagnose and recover from errors 
        - Help & Documentation 
    - Use Participatory Design 
    - 
- API Styles 
        - Tunnel-RPC style
        - CRUD Style
        - Hypermedia style
        - Query style
        - Event driven style

- How loan against securities (LAS) work, 
    - Max LAS against equity is 10 lakh according to some RBI/SEBI rule - does matter what the value of your collateral security is. So banks can't lend beyond this in a single loan. I think NBFCs are more lenient with respect to this.
    - You need 20 lakh worth of equities to get a 10 lakh loan (50% margin is typical, some relaxations can be obtained apparently)
    - You can get upto 85% of collateral value using debt funds. Do not know what is the max they will lend
    - You cannot use this money for equity trading. It can only be used for personal purposes. I do not know how they track end use but at least on paper speculative use is banned.
    - In case of banks, they open current account for loan disbursal and interest is charged on withdrawals.

- Stocks#Philip Fisher's approach 
    - shouldn’t be over-wedded to valuation, providing we own great businesses (Valuation is a secondary concern). Great businesses grow faster than investors expect, and sustain growth for longer. While they often seem expensive based on current profits, their extraordinary growth potential means their valuation is often more than justified.
    - every company has a personality. More successful the corporation is more likely it is to be unique in it's policies. 
    - Important aspects of a company are Sales and R&D.
    - he placed great emphasis on the management and culture of an organisation.
    - Fisher was also very aware of the dangers of complacency setting in to an organisation. Many companies, having achieved success, stop doing the things that made them successful. A culture of entrepreneurialism combined with a willingness to experiment and push boundaries, is replaced with bureaucracy, politics and a desire to preserve the status quo.
    -  Only by getting better can a company be sure of not growing worse
    - Rigid companies that do not constantly challenge themselves will fail.
    - High quality management possess two things 1) They handle day-to-day business tasks with above-average efficiency 2) They are able to look ahead and make long-range plans that will produce significant future growth for the business without compromising existing operations
    - Good investing is like being a detective or investigative journalist. You look for clues and try to build a picture that gets you closer to true understanding.

- On Equity portfolio construction
    - Great businesses are rare. Great businesses that are also well managed are rarer still. I don’t want to ‘diworsify’ my portfolio by adding sub-par companies because I believe this increases rather than reduces risk. I agree with Phil Fisher – it’s better to own a few great businesses than a great many mediocre ones.
    - Good ideas are rare (at least for me!). When I have one it needs to make a difference.I like to understand the businesses I own (especially important in a concentrated portfolio). There are only so many companies I can track and develop enough knowledge on.
    - Most of the best investors I know have or had concentrated portfolios, although there are exceptions (such as Peter Lynch).
    - When you own fewer positions, it forces you to make tough decisions. Do I really understand this business well enough? Would I be better off holding this company instead? To me this is a better approach than adding more and more names, akin to a stamp collector – there are no prizes for collecting large albums of stocks.
    - Many studies show that beyond about 30 holdings, the benefits of adding more positions for diversifying risk are minimal.

- Sociology
    - Parents in extreme poverty need many children… [Not just] for child labour but also to have extra children in case some children die… Once parents see children survive and once the children are no longer needed for child labour… both the men and the women instead start dreaming of having fewer, well-educated children.
    - In theory, if on an average 100 women have 210 children during their childbearing years and this trend continues over the decades, the population will eventually stabilize and continue to remain stable.

## 2021-dec-06 Mon

- Stoicism - knowledge can be obtained through reason and truth can be separated from falsity.The method for applying reason to determine truth is a Zen-style unattachment in accepting the world as it is and to not have one’s mind hijacked by greed, envy, fear and other action-distorting emotions.
    - Contemplate the worst 
    - acknowledge what you can't control - There’s no point worrying about what you can’t control; focus on what you can.
    - allocate time to worry 
    - Cut out the noise - Exercise, read, take a walk or plant some seeds instead.
    -  Live in the uncertainty and work at it - Being humble, managing your anxiety and working at becoming a better investor is how you become a better investor.

- Crypto#
    - Crypto’s Commingling Scandal - What crypto exchanges do, 
        - They have a single (or a few) wallet address that holds a consolidated amount of coin
        - When you’re on the exchange and you buy/sell, it’s with another party on the same exchange, so to the external world, nothing changes. The exchange is still the owner.
        - Within the exchange, who determines who’s the owner? The exchange itself. It maintains a database.
        - But wait, we are trusting an exchange now? Wasn’t bitcoin supposed to be trustless – so that your bitcoin is your bitcoin?
        - Well, no. Not in such exchanges.
        - The best way to handle this is to move your coin outside the exchange, into your personal wallet. When you need to trade, move it back in. Centralized Exchanges (CExes in short) have massive commingling issues. 

- Notes from talk by Sankaran Naren,
    -  Global central banks are responsible for equity bull markets
    -  In US, pure value approach (low P/E ) does not work anymore only Moat approach in value investory works 
    - Be conservative when markets are high and aggressive when markets are low
    - In india, corporate governance is cyclical (improves with bull market vice versa)
    - Temparament is most important thing in investment
    -  Any asset class falls 40%, add money to it. 
    -  if any asset class has done badly then put money vice-versa withdraw money
    - James montier's tenets of investing, 
        -  Always insist on a margin of safety
            - Screener for Value opportunities -  stocks are required to have an earnings yield of twice the AAA bond yield, a dividend yield of at least two-thirds of the AAA bond yield, and total debt less then two-thirds of the tangible book value. The stocks passing must have a Graham and Dodd P/E  of less than 16.5x.
        - This time is never different
        - Be patient and wait for the fat pitch
        - Be contrarian
        - Risk is the permanent loss of capital, never a number
        - Be leery of leverage
        - Never invest in something you don’t understand
            - Investing is always about making decisions under a cloud of uncertainty. It is how one deals with the uncertainty that distinguishes the long-term value-based investor from the rest. Rather than acting as if the uncertainty doesn’t exist (the current fad), the value investor embraces it and demands a margin of safety to reflect the unknown

- Critical thinking Approach 
    - Who does this benefit?
    - What's the context?
    - When or where would this work?
    - Whys is this a problem?

- Tech#Datawarehouses
    - Snowflake Warehouse is a single integrated system with fully independent scaling for compute, storage and services. Unlike shared-storage architectures that tie storage and compute together, Snowflake enables automatic scaling of storage, analytics, or workgroup resources for any job, instantly and easily.

## 2021-dec-07 Tue

- Supply chain# Shipping and Containers 
-  A freight-forwarder is basically a middleman in the supply chain which buys a guaranteed amount of space on ships, often via multi-year contracts at guaranteed rates with guaranteed space, and then re-sells that space to people who need it.

- Tech#How DNS Works,
    - When you make a DNS request (for example when you type google.com in your browser), you make a request to a DNS resolver, like 8.8.8.8.
    - When you create a DNS record for a domain, you set the DNS record on an authoritative nameserver.The authoritative nameserver never pushes updates, it just replies with the current record when it receives a query.
    - While the DNS record creation is instateneous (i.e. available instantly). Updates to DNS records are not as they are cached by resolvers. Resolver server will query it again once it's cache is expired.

- Tech#Data Mesh - Centralized approach doesnt work. Decentralized approach where domain that creates the data is responsible for publishing feed of analytical data. They think this data feed as product. Platform to publish and consume data feeds and decentralized governance approach. New requirement for analytics will require approaching data product teams to understand and gather data. One has to goto business units and get details on data product. 
    - Data Products are data-centric, digital artifacts that are produced and consumed in a multi-party exchange for the purposes of meeting the needs of a job that the consumer is trying to get done. Further, the lifecycle controls of data products closely mirror those of physical products in the commercial realm.
    - Issues with centralization - from where the data has come from? How is it organized?







