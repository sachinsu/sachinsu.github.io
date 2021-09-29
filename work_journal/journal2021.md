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

- Work updates
    Issuance, 
    - IDBI Bank audit - Participation 
    - Issue with Bank of India for which they had raised penalty and they wanted to 
    understand data flow within systems. Shared updated issuance
    architecture diagram to be used to explain data flow. 

    BFL, 
    - Production issue, HTTP to Microsoft Kaizala , its only on production servers and 
    not on dev/SIT servers. Confguration changes needed 

- Investing
    - Owning a business that has the opportunity to invest some or all of its profits at a very high level of return can contribute to a very high rate of earnings growth.

- Forex# Range of the day pricing 
    - Fx Specialist @ Bank would select the best rate for the back and worst rate for the customer from the FX price fluctuations from the beginning of the trading day until the time of transaction.

## 2021-sep-30 Thu

