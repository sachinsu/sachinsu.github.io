- Work updates
    DH, 
    - Ongoing Application design Review and New architecture

    BFL, 
    - Rule engine in Oneview.  

    Issuance,
        - Issue in CwM App for one of the report only on single server. Currently, deployed on separate server for that client. 
        - Issue with Bank of India for which they had raised penalty and they wanted to understand data flow within systems. Shared updated issuance architecture diagram to be used to explain data flow. 

    Interviews,
        Shortlisting & interview for Mobile & C Architect role

    Axis bank - migration of existing document mgmt system to MOS. Migration of 1Tb of documents. Approach for the same? and whether existing infrastructure can accommodate additional compute?           

    Sahil, 
    - Unified non-card transactions from different channels


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

## 2022-jan-10 Mon

- schadenfreude - a German word for taking pleasure at another’s misfortunes
- In auto industry, the only way to protect your margins is to have a balance of entry and premium products. Entry level products lets you build scale while premium products help you in pricing power and delivering better margins. Sway too much on either side and you either risk losing your margins or not have enough demand to implement economies of scale in your business.

- The most egalitarian societies, hunter-gatherer societies, actually have more envy that less egalitarian ones. This isn't obvious because their lack of wealth seems to imply they are not greedy, and thus, selfish like Westerners, but this is just wishful naïve thinking. There is no tribe where social harmony prevails because each man has as little as the next. For primitive egalitarian societies, envy is both a cause and an effect. Schoeck notes that such communities tend to have no conception of luck, and so see any objective relative prosperity as a sign of theft or alignment with evil forces. Schoeck discusses Native American, African, and Polynesian tribes, and note the strong social pressure for anyone better off to be lavish in hospitality and generous with gifts. He knows that if he fails in this, 'the voice of envy will speak out in the whispers of witchcraft' which would make his life very unpleasant.

- Envy prevents people from accumulating the wealth needed to create technology, and thus the free time needed to create art, science, literature, and philosophy. A lack of differentiation makes more apparent one's inadequacies, in that some will be more clever, athletic, or brave. When people are made equal in endowments, the only reason for not attaining a higher status is within us, our character, our essence.

- Our unprecedented wealth and comfort should have led to less envy, in that we all have access to the knowledge that brings self-actualization and self-esteem, but instead, it has lead to greater envy. The poorly paid op-ed writer of your local newspaper considers themselves not just equal to the rich, but better informed and more articulate, as proven by their many eloquent and insightful essays. Their lack of status motivates envy because they feel just as worthy, as competent, as those who are doing better. David Brooks highlighted this in his book Bobos in Paradise.

- Praise from the praiseworthy is beyond all rewards, why we are more hurt by the lukewarm approval of men we respect than the contempt of fools.

- While there is nothing wrong with having wealth or wanting more, this should be of secondary importance, and wisdom is all about priorities. We should be encouraged to appreciate excellence in others to build excellence in ourselves. This takes faith, in that we have to believe our excellence in character, even if not reflected in the current status hierarchy, is appreciated by someone we admire, if not now, then in the future.

- Lions, for example, are the only social species of cat.


- Effective decision making,
    - People Interventionistas - Often these people come armed with solutions to solve the first-order consequences of a decision but create worse second and subsequent order consequences.iatrogenics to refer to any effect resulting from intervention in excess of gain.

    - when the linkages between cause and effect are murky, the very people who caused the harm are often the people rewarded for improving the situation.

    - Second-order thinking is more deliberate. It is thinking in terms of interactions and time, understanding that despite our intentions our interventions often cause harm. Second order thinkers ask themselves the question “And then what?” This means thinking about the consequences of repeatedly eating a chocolate bar when you are hungry and using that to inform your decision. If you do this you’re more likely to eat something healthy.Extraordinary performance comes from seeing things that other people can’t see.

    - The key lesson here is that if we are to intervene, we need a solid idea of not only the benefits of our interventions but also the harm we may cause
        - Ways to go about "Second-order thinking", 
        - Always ask yourself “And then what?”
        - Think through time — What do the consequences look like in 10 minutes? 10 months? 10 Years? 
        - Create templates like the second image above with 1st, 2nd, and 3rd order consequences. Identify your decision and think through and write down the consequences. If you review these regularly you’ll be able to help calibrate your thinking.
        -(Bonus) If you’re using this to think about business decisions, ask yourself how important parts of the ecosystem are likely to respond. How will employees deal with this? What will my competitors likely do? What about my suppliers? What about the regulators? Often the answer will be little to no impact, but you want to understand the immediate and second-order consequences before you make the decision.

    - Typical Flaws ,
        - The first flaw is the inability to think through second and subsequent order consequences. They fail to realize that the second and subsequent order consequences exist at all or could outweigh the benefits. Most things in life happen at the second, third, or nth steps.
        - The second flaw is a distance from the consequences.
        - The third flaw is a bias for action. - If you’re a policy advisor or politician, or heck, even a modern office worker, social norms make it hard for you to say, “I don’t know.” You’re expected to have an opinion on everything.
        - The fourth flaw is one of the incentives, they have no or little skin in the game. They win if things go right and suffer no consequences if things go wrong.

- Intervention—by people or governments—should only be used when the benefits visibly outweigh the negatives . 
- A simple rule for the decision-maker is that intervention needs to prove its benefits and those benefits need to be orders of magnitude higher than the natural (that is non-interventionist) path.
- We must also recognize that some systems self-correct; this is the essence of homeostasis. Naive interventionists, or the interventionista, often deny that natural homeostatic mechanisms are sufficient, that “something needs to be done” — yet often the best course of action is nothing at all.

- A lot of extraordinary things in life are the result of things that are first-order negative, second order positive
- One big mistake people repeatedly make is focusing on proving themselves right, instead of focusing on achieving the best outcome. 

- First principles 
    - Process of Socratic questioning
        - Clarifying your thinking and explaining the origins of your ideas. (Why do I think this? What exactly do I think?) 
        - Challenging assumptions. (How do I know this is true? What if I thought the opposite?) 
        - Looking for evidence. (How can I back this up? What are the sources?) 
        - Considering alternative perspectives. (What might others think? How do I know I am correct?) 
        - Examining consequences and implications. (What if I am wrong? What are the consequences if I am?) 
        - Questioning the original questions. (Why did I think that? Was I correct? What conclusions can I draw from the reasoning process?) 
    
    
    - Reasoning from first principles allows us to step outside of history and conventional wisdom and see what is possible. When you really understand the principles at work, you can decide if the existing methods make sense. Often they don’t.  Many people mistakenly believe that creativity is something that only some of us are born with, and either we have it or we don’t. Fortunately, there seems to be ample evidence that this isn’t true. We’re all born rather creative, but during our formative years, it can be beaten out of us by busy parents and teachers. As adults, we rely on convention and what we’re told because that’s easier than breaking things down into first principles and thinking for yourself. Thinking through first principles is a way of taking off the blinders. Most things suddenly seem more possible. 

- Blockchain
    - Dapps are a growing movement of applications that use Ethereum to disrupt business models or invent new ones. 
    - Almost all dApps use either Infura or Alchemy in order to interact with the blockchain. 

- Buy now pay later 
    - The BNPL is a software company brokering a very complex credit transaction in a fashion which makes it free to the user, by producing ex nihilo high interest debt, manufactured out of the interchange fee the business paid. BNPL Companies originate the loan but they are not interested in owing it further. Typically, they dont want to be in business of borrowing and lending at a spread. They do not have franchise that attract deposits which they could use to lend out. 
    - Finance loves making simple things sound complicated because that ensures the continued employment of lot of finance professionals at high wages.
    - In most cases, BNPL ties with capital partner and they share risk of non-payment.
    -  A $100 pay in four transaction needs $75 of capital backing it for six weeks (because the user immediately pays a quarter upfront). The average amount of capital required over the term of the loan is half of that, due to repayment. If the BNPL was willing to pay 2% of the original transaction (sliced from their fee) to the capital provider in lieu of interest, the capital provider would receive $77 in repayments for their committed capital for 6 weeks, representing about 2.67% yield on $37.50 over 6 weeks. This works out to 25% annualized, give or take.
    - “Rails” are payment jargon for the technological and financial links between various entities which allow money movement. Visa provides rails, debit card networks provide rails, etc etc.
    -  BNPLs don't want to acquire one transaction; they want to acquire a continuing stream of transactions from a customer, ideally changing their purchasing behavior for certain sectors and charging their partners for the change.

## 2022-jan-12 Wed

- Markets
    - While rising yields are generally a bullish sign for the economy, they also make riskier assets—like expensive tech stocks—less attractive compared to other names that may get a boost from higher interest rates. 

- Database schema migrations - general flow of online schema migration, 
    - Create a new, empty table, in the likeness of the original table. We title this the ghost table.
    - ALTER the ghost table. Since the table is empty, there is no overhead to this operation.
    - Validate the structural change is compatible with tooling requirements.
    - Analyze the diff.
    - Begin a long running process of copying existing rows from the original tables to the ghost table. Rows are copied in small batches.
    - Capture or react to ongoing changes to the original table, and continuously apply them onto the ghost table.
    - Monitor general database and replication metric, and throttle so as to prioritize production traffic as needed.
    - When the existing data copy is complete, the migration is generally considered as ready to cut-over, give or take some small backlog or state of the replication topology.
    - Final step is the cut-over: renaming away of the original table, and renaming the ghost table in its place. Up to some locking or small table outage time, the users and apps are largely ignorant that the table has been swapped under their feet.

- Never believe in individual rather believe in institutions. Hero worship should be abandoned.

- Corelation - two things happening at the same time
- causation - mistakenly conclude that one causes the other.

-There are two approaches to applying inversion in your life. 
    - Start by assuming that what you’re trying to prove is either true or false, then show what else would have to be true. 
    - Instead of aiming directly for your goal, think deeply about what you want to avoid and then see what options are left over. 

## 2022-jan-13 Thu

- Kurt lewin's force field analysis, 
    1. Identify the problem 
    2. Define your objective 
    3. Identify the forces that support change towards your objective 
    4. Identify the forces that impede change towards the objective 
    6. Strategize a solution! This may involve both augmenting or adding to the forces in step 3, and reducing or eliminating the forces in step 4. 

- Occam’s Razor, a classic principle of logic and problem-solving, indicates that Simpler explanations are more likely to be true than complicated ones.
- Hanlon's Razor demonstrates that there are fewer true villains than you might suppose—what people are is human, and like you, all humans make mistakes and fall into traps of laziness, bad thinking, and bad incentives. Our lives are easier, better, and more effective when we recognize this truth and act accordingly.

## 2022-jan-17 Mon

- Tech#about headless browser libraries, 
    - Puppeteer - Puppeteer is the most popular browser automation library, that just like the name implies, allows you to manipulate a web page like a puppet and scrape the data you need using a Chrome browser.
    - Playwright - Released by Microsoft in 2020, Playwright.js is the new kid on the block and it very similar to Puppeteer in many ways (many of the Puppeteer team left Google, and created Playwright at Microsoft). However, it has been gaining a lot of traction because of its cross-browser support (can drive Chromium, WebKit, and Firefox browsers, whilst Puppeteer only drives Chromium) and some developer experience improvements that would have been breaking changes with Puppeteer.

- Finance#covered calls are a yield-enhancement play that involve selling call options against stocks that you own. The call option gives you extra income, but—during the life of the option—your gains are capped at the call option’s strike price. if the stock goes nowhere—or even if it rises slightly—you get the call premium while still hanging on to the stock.

- Zwicky's model for problem solving (https://nesslabs.com/zwicky-box), 
    - Figure out your categories and list them each in a column
    - brainstorm each category and add values to it 
    - Create unique combinations from each category. Continue to create these combinations until something valuable is found.
    - It can be used for following, 
    - Creativity. From story planning to content creation, creatives can utilise the Zwicky box to generate original ideas.
    - Innovation. You can use a Zwicky box for market innovation, business model creation, product development, and prototyping.
    - Decision making. A Zwicky box can help you with strategizing, financial modelling, and daily decision making.
    - Brainstorming in a team. It can be helpful to brainstorm ideas with your team with a Zwicky box where everyone can contribute to creating and filling the Zwicky box.

- Difference between ETF and MF
    - Because ETFs are cheaper, they can get big too fast and they almost never limit their growth in terms of AUM. Unlike mutual fund where AMC can stop inflows, ETF inflows can not be stopped. At the most, creation of new units will be halted but it means that existing units will be available at premium. This is not a problem for index tracking ETFs but it is for other (thematic or otherwise).
    - You can only buy future performance.

- The difference between genius and stupidity is that genius has its limits.

- Latest from Howard marks (the decision to trim positions or to sell out entirely comes down to judgment . . . like everything else that matters in investing) , 
    - we should base our investment decisions on our estimates of each asset’s potential,
    - we shouldn’t sell just because the price has risen and the position has swelled,
    - there can be legitimate reasons to limit the size of the positions we hold,
    - but there’s no way to scientifically calculate what those limits should be. 
    - simply being invested is by far “the most important thing.”.
    - someone entering adulthood today is practically guaranteed to be well fixed by the time they retire if they merely start investing promptly and avoid tampering with the process by trading

- Economy#The way to get out of the middle-income trap is to compete on brand and technology rather than price, and that generally means making a job that doesn’t exist yet. There wasn’t a market for Walkman before Sony made them; they had to build the product and then sell it.

## 2022-jan-19 Wed

- Data Storage for Observability use case
    - Metrics with a single value are referred to as univariate, whereas metrics comprised of multiple values are called multivariate. 
    - Embedded key value stores - designed to be general purpose but limited their ingestion throughput.
    - Full-fledged TSDBs (TimescaleDB, Clickhouse etc.) - are geared towards analytical queries rather than ingestion performance.
    - Prometheus - Optimized for Ingestion performance. Does not support multivariate data. 
    - Thanos , M3 , and Monarch  are distributed metrics and monitoring systems. They focus primarily on the distributed coordination layer and rely on a lower-level storage engine under the hood. For example, Thanos and M3 are designed to manage many distributed Prometheus instances running in a cloud environment
    - Synthetic monitoring, also known as synthetic testing, is an application performance monitoring practice that emulates the paths users might take when engaging with an application. It uses scripts to generate simulated user behavior for different scenarios, geographic locations, device types, and other variables.

- Distributed systems 
    - Backpressure is a strategy that allows us to cope with producers that publish messages at a rate that is faster than the rate at which consumers can process them by slowing down the producers.

- PostgreSQL Replication 
    - PostgreSQL supports block-based (physical) replication as well as the row-based (logical) replication. Physical replication is traditionally used to create read-only replicas of a primary instance, and utilized in both self-managed and managed deployments of PostgreSQL. Uses for physical read replicas can include high availability, disaster recovery, and scaling out the reader nodes. 

- Data storage
    - Row oriented - Because data on a persistent medium such as a disk is typically accessed block-wise (in other words, a minimal unit of disk access is a block), a single block will contain data for all columns.This is great for cases when we’d like to access an entire user record, but makes queries accessing individual fields of multiple user records (for example, queries fetching only the phone numbers) more expensive, since data for the other fields will be paged in as well
    - Column-oriented - Store values by vertical partitioning ie. by column against storing values by horizontal partitioning (as in RDBMS).
        - In column-oriented layout, values of same column are stored contiguously on disk.For example, if we store historical stock market prices, price quotes are stored together. Storing values for different columns in separate files or file segments allows efficient queries by column, since they can be read in one pass rather than consuming entire rows and discarding data for columns that weren’t queried.
        - Column-oriented stores are a good fit for analytical workloads that compute aggregates, such as finding trends, computing average values, etc. Processing complex aggregates can be used in cases when logical records have multiple fields, but some of them (in this case, price quotes) have different importance and are often consumed together.
        - Apache Parquet, Apache ORC are column-oriented file formats.
        - Reading multiple values for the same column in one run significantly improves cache utilization and computational efficiency.
        - If the read data is consumed in records (i.e., most or all of the columns are requested) and the workload consists mostly of point queries and range scans, the row-oriented approach is likely to yield better results. If scans span many rows, or compute aggregate over a subset of columns, it is worth considering a column-oriented approach.
        - Wide column stores 
            - data is represented as a multidimensional map, columns are grouped into column families (usually storing data of the same type), and inside each column family, data is stored row-wise. This layout is best for storing data retrieved by a key or a sequence of keys.
            -Each row is indexed by its row key. Related columns are grouped together in column families.
            - Each column inside a column family is identified by the column key, which is a combination of the column family name and a qualifier.
            - Column families store multiple versions of data by timestamp.

- Eurodollar - Offshore (outside US) currency systems, denominated in US Dollars. Outside the scope of US Regulation. Has nothing to do with Euro. Timed deposits, dollar denominated deposits kept in UK Banks outside of US Jurisdiction. Instead of immediately remitting the foreign currency to the central bank or depositing it in their accounts in the U.S., banks used their dollar deposits for loans to third parties either in the U.K. or abroad. This system was supposedly very big till 2007. Global financial crisis was Eurodollar system breaking down. All the global banks are heavily involved in it. It essentially means Global money. It is US dollar denominated but a ledger, ghost money. Without the Eurodollar, Globalization might not have taken place. The US dollar denominated resources were created without actual currency involved. Fed reserve, treasury dep. or authorities in countries have no influence on eurodollar capacity. They don't have capacity, wisdom. 

## 2022-jan-20 Thu

- David sinclair takeaways for healthy life 
    - Eat less often (Skip a meal), don't snack
    - avoid sugary drinks and food
    - reduce meat intake and opt for more plant based diet
    - choose the veggies that are stressed out 
    - Put the sugar at the end of the meal

- Education has general benefits in improving quality of thinking and receptiveness to information.
- When you have to make decision, break it into sub-decisions/sub-aspects  that you are going to look at and score them individually. Do not form intermediate impression.do not form intuition until more information is available which is going to improve quality of sub-decisions. 

- liberalism - thrives on perpetual victimhood narrative.
- Malthusianism is the idea that population growth is potentially exponential while the growth of the food supply or other resources is linear, which eventually reduces living standards to the point of triggering a population die off.

## 2022-jan-24 Mon

- Economy#Inflation, Interest Rates etc.
    - The (US) Fed increases rates, this increases borrowing costs for banks and pretty much everyone else. Interest rates increase drive mortgage and credit card rates up, disposable income goes down. the consumer, are spending less money. When you spend less, firms sell less stuff. This in turn affects company earnings, and by extension their stock prices.
    - Stocks always compete with the safest options in the market – bank fixed deposits or government securities.This makes for an inverse relationship between interest rates and equity valuations. 
    - the excess money and easy credit light the fuse that sparks inflation. This is because the supply side does not have the confidence to grow even as easy money with the spenders drives up demand. 
    - Worry is that high interest rates would slow down economic activity, slow down demand and eat into profits
    - The US dollar is the world's reserve currency or the medium of exchange in which international trade is largely carried out and the currency in which other countries hold a good portion of their foreign exchange reserves. So, whatever the Federal Reserve does to control inflation through interest rates, impacts countries across the world, including India.
    - Treasury bonds are financial securities issued by the US government to borrow money to finance its fiscal deficit or the difference between what it earns and what it spends.
    - The American government was spending much more than it was earning. To finance the spending, it sold treasury bonds. Large financial investors such as banks, insurance companies, pension funds and mutual funds, bought these bonds. At the same time, the Fed was buying treasury bonds from the same large financial investors and thus financing the government indirectly.


- Tech#Postgres indexes, 
    - B-tree indexes are the most common type of index and would be the default if you create an index and don’t specify the type. B-tree indexes are great for general purpose indexing on information you frequently query. 
    - BRIN indexes are block range indexes, specially targeted at very large datasets where the data you’re searching is in blocks, like timestamps and date ranges. They are known to be very performant and space efficient.
    - GIST indexes build a search tree inside your database and are most often used for spatial databases and full-text search use cases. 
    - GIN indexes are useful when you have multiple values in a single column which is very common when you’re storing array or json data. 

- Psychology
    - Wisdom is coexistence of contradictory truths, and money is the clearest example of this. We must internalize its importance while also recognizing its pointlessness.

- Country
    - In India, State governments are merely intermediaries but with no value addition.
    - POTA - pulled out of thin air

- Techniques#Spacing effect 
    - A typical spaced repetition system includes these key components:
        - A schedule for review of information. Typical systems involve going over information after an hour, then a day, then every other day, then weekly, then fortnightly, then monthly, then every six months, then yearly. Guess correctly and the information moves to the next level and is reviewed less often. Guess incorrectly and it moves down a level and is reviewed more often.
        - A means of storing and organizing information. Flashcards or spaced repetition software (such as Anki and SuperMemo) are the most common options. Software has the obvious advantage of requiring little effort to maintain, and of having an inbuilt repetition schedule. Anecdotal evidence suggests that writing information out on flashcards contributes to the learning process.
        - A metric for tracking progress. Spaced repetition systems work best if they include built-in positive reinforcement. This is why learning programs like Duolingo and Memrise incorporate a points system, daily goals, leaderboards and so on. Tracking progress gives us a sense of progression and improvement.
        - A set duration for review sessions. If we practice for too long, our attention wanes and we retain decreasing amounts of information. Likewise, a session needs to be long enough to ensure focused immersion. A typical recommendation is no more than 30 minutes, with a break before any other review sessions.

## 2022-jan-27 Thu

- Tech#Linux 
    - In Linux architecture, memory is separated into kernel space and user space. The kernel space is used to run the core kernel code and the device drivers. Processes running in kernel space have unrestricted access to all hardware, including CPU, memory, and disks. All other processes run in the user space, which relies on the kernel to access the hardware. Processes running in the user space use system calls to communicate with the kernel for privileged operations like disk or network I/O.A buggy code in a kernel module can easily crash the kernel. This is why Linux provides a way to run secure, verified sandboxed code in the kernel space through eBPF.
    - Good Article about eBPF, https://www.containiq.com/post/ebpf  

- Observability#Sampling in Tracing
    - In distributed tracing, sampling is frequently used to reduce the number of traces that are collected and stored in the backend. This is often desirable because it is easy to produce more data than can be efficiently stored and queried. Sampling allows us to store only a subset of the total traces produced.