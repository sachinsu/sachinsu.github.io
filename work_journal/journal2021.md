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
- Work updates
    Issuance, 
    - IDBI Bank audit - Participation 
    - Issue with Bank of India for which they had raised penalty and they wanted to 
    understand data flow within systems. Shared updated issuance
    architecture diagram to be used to explain data flow. 

    BFL, 
    - Production issue, HTTP to Microsoft Kaizala , its only on production servers and 
    not on dev/SIT servers. Confguration changes needed 

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