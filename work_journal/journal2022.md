- Work updates
    DH, 
    - Ongoing Application design Review and New architecture

    BFL, 
    - Dynamic Rules in Oneview.  

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

- Tech#PostgreSQL

    - Triggers for scaleout 

        - is limited to single server 
        - working set does not fit in memory
        - reaching limit of network attached storage, CPU
        - Analytical queries take too long
        - Autovacuum can not keep up with transaction load

- Tech#Raft consensus protocol

     - raft log - sequence of events persisted to disk representing a series of changes to state machine.
     - leader - the single node in a cluster responsible for coordinating replication of raft log
     - Follower - one or more nodes in a cluster that maintain copies of the Raft log. Any follower can be elected Leader if the current leader fails. 

- Tech#RQLite

    - Use cases 
        - storage of few megabytes of critical data.
        - if out of the box HTTP API is needed
        - easy to use as alternative to hosted options  

- Society etc.
    - Power is the ability to exert coercive force over others against their will. Rights stand in contradistinction to power. They are protections against/limitation of power


    -Govt. Budget - So govt had plans of spending x trillion this year, of this y (often less than spending) came through savings schemes, taxes. It also earned dividends and profits shared by companies it owns and from RBI. Total earnings minus spending gives fiscal deficit. To address deficit, govt. borrows from market. 

    - All institutions exhibit reflection of society.

    - It started in 1969... the great fillip came after the split and in an effort to have a populist image, Mrs. Gandhi, as advised by P.N. Haksar, went on the (concept of a) committed bureaucracy, committed judiciary" (Sunday Mail, April 5, 1992).

    - DNA Dataset of Maharashtra Brahmins have Ancient iranians and steppe pastoralist contribution and same is with CKP population.

    - Humanities rule the world, scientists are at their mercy.

    - Baumol's cost disease - If workers in other industries get more productive, it gives lesser ones bargaining power. Lesser paying industry would constantly lose talent.

    - CM Chase rules for Options,
    - We only write/sell options in this approach.
    - If the futures signal says go long at 17500, assuming the spot is around the same value, you will sell 100 points ITM current week put. ie 17600 PE. 
    - As and when that becomes ATM you move 100 points ITM again.
    - For SL, calculate the difference between your current SL and LTP on futures multiply it by 0.8 and add that value to the options premium. For example, If your entry on futures is at 17500 and SL is 17400. You will take 80+(Options Premium) as SL.
    - You will continue this till Thursday/expiry day, and rollover to next week on the expiry day, assuming the futures trade continues till then. 

    - Recency bias - Put simply, recency bias is the practice of giving disproportionate weight to the events of the recent past when formulating expectations and plans.

    - India as Market - India isn’t really one big market. There are multiple markets and markets within markets. India is not a single language market when it comes to the entertainment business. Also, not many Indians speak English.Just because India has 1.4 billion people doesn’t mean that the market for any product is as big or even a small portion of it.India and Indians seek value for money every time they spend money on something, and Netflix simply doesn’t provide that for most of us. Any form of mass communication needs to be simple enough for the average individual to understand, irrespective of whether it is writing that wants to entertain or propaganda that intends to influence.

## 2022-feb-02 Wed

- Tech
    - SoftPOS - Mastercard's multi-factor white-label solution for banks and payments facilitators that enables a smartphone to function as merchant acceptance device.
    - Superset is built as a Python Flask web application and leverages SQLAlchemy, a Python SQL toolkit, to provide a consistent abstraction layer to relational data sources
    - Baseline for Web Development for 2022,
        - Safari is the baseline in terms of web standards: The sites we develop must work in Safari versions at least 2 years old.
        - Low-tier Android devices are the baseline in terms of performance: Low-tier Android devices have advanced little in the past few years so we must make sure our sites are super performant.
        - 4G is the baseline in terms of networks: Mobile networks have become a lot faster and stabler worldwide in recent years.

- Economics, Society etc.
    - Pax Americana is a term applied to the concept of relative peace in the Western Hemisphere and later the world after the end of World War II in 1945, when the United States became the world's dominant economic and military power. 
    - One of the best predictors of insurgency is having the kinds of terrain that governments cannot reach, like swamps, forests and mountains.
    - Once you’re the kind of people who can’t inconvenience yourselves enough to have kids, you are not going to risk your lives for a political ideal. 
    - side that wants to fight a guerrilla war has to be the one that is willing to take a much larger number of casualties

    - Second order thinking and Chesterton's fence
        - Chesterton describes the classic case of the reformer who notices something, such as a fence, and fails to see the reason for its existence. However, before they decide to remove it, they must figure out why it exists in the first place. It means "Do not remove a fence until you know why it was put up in the first place." or " If a fence exists, there is likely a reason for it. "

        -The test of a first-rate intelligence is the ability to hold two opposing ideas in mind at the same time and still retain the ability to function. One should, for example, be able to see that things are hopeless yet be determined to make them otherwise.

    - Markets & Investing
        - A wash trade is a form of market manipulation in which an investor simultaneously sells and buys the same financial instruments to create misleading, artificial activity in the marketplace. First, an investor will place a sell order, then place a buy order to buy from themself, or vice
        versa.Wash trading works best when the market is thin. If your above-fair-price wash trades run into real orders from other traders, you’ll lose money! You want to maximize the likelihood that you actually sell to yourself.

        - One reason stocks tend to have high returns over the long run is to compensate investors for the ever-present risk of losing at least half their money in the short run.

        - virtue of great investors: skepticism. If I've learned anything in decades of reporting on investing, it's that the main product of the financial industry isn't portfolios; it's propaganda. And propaganda with numbers, cloaked in jargon, can hit investors like general anesthesia: You just drift off to sleep while financial professionals surgically remove your money.
            - When someone says, "Studies have shown that...," ask the names of the studies, where they were published and whether this person has read them in full.
            - When someone describes a "strategy," ask how that differs from a tactic.
            - When asset managers talk about "sell discipline," ask if they measure how the stocks they sell do after being sold. If the firm doesn't know that, how does it know its sell discipline works?
            - Are these past results based on a backtest? 
            - What do the results look like after trading costs, fees and taxes?
            - Do these numbers account for survivorship bias?
            - Who's on the other side of this trade, and why would they let you make so much money?
            - Is there data on the average performance of people who have tried this in the past? How did they do, and what makes me or you so special that we should believe we can do better?
            - Always read the footnotes. Read financial disclosures from back to front, as if they were written in Hebrew or Arabic. The stuff you really need to know is almost always near the back.

    - A great company is a great investment only when you pay the right price for it.

## 2022-feb-03 Thu

- Network Terminology
    - muxing is the process of combining multiple inputs into a single singal, de-muxing naturally is the opposite process. De-muxing, aka 
    Demultiplexing, is the process of separating a single output into its inputs

- Software Architecture is about, 
    - Shared/Common understanding in stake holders about technically important aspects
    - Is not about craftmanship vs. economics. Economics always wins.
    - Architecture is about internal quality which is not directly visible. Quality is directly proportional to Customer satisfaction.
    - is about ensuring code is in healthy state like regularly refactored, cleaner code base while being adaptability to change

- Economics
    - What is Infrastructure? Long lived capital assets.
    - due to Covid, production has shifted from unorganized to organized.

## 2022-feb-07 Mon

- Default size of the stack,
    - 1 MB

- Open source data stack 
    - Airflow - Workflow
    - Airbyte - ELT
    - dbt - ELT
    - Metabase - Dashboards and reporting 
    - superset - Dashboards and reporting 
    - PostgreSQL - RDBMS
    - Great_Expectations - Data pipeline testing
    - datahub - Data catalog/lineage

- Bikeshedding is a metaphor to illustrate the strange tendency we have to spend excessive time on trivial matters, often glossing over important ones.
    - The Law of Triviality states that the amount of time spent discussing an issue in an organization is inversely correlated to its actual importance in the scheme of things.Major, complex issues get the least discussion while simple, minor ones get the most discussion.
    - Bike-shedding happens because the simpler a topic is, the more people will have an opinion on it and thus more to say about it. When something is outside of our circle of competence,we dont even try to articulate an opinion
    - With any issue, we shouldn’t be according equal importance to every opinion anyone adds. We should emphasize the inputs from those who have done the work to have an opinion.
    - The most informed opinions are most relevant. 

- Insecure, ossified societies always look backwards (Wahabism, Ram rajya etc.), while societies feeling secure look forward.

- Europe was ahead of India (as well as turks) when it comes to mideval military architecture be it canons, fortification and so on.
    - from 1400-1500, europe started forward march w.r.t. rest of the world 
    - Europe (below are visible in india only under british rule), 
    - Long distance trade
    - Centralization 
    - Urbanization 
    - Growth in private wealth
    - Trading cities directly under rule of King and not local lords

- Plague pandemic caused loss of faith in Church in Europe.

- Quantum computing and 3d printing. 
    - Quantum computing  has the potential to break the encryption used to protect sensitive data in the digital world of today and tomorrow.Powerful countries, companies, and universities are pouring money into the task of building a quantum computer powerful enough to perform exponentially faster than the computers of today.Google and IBM use the same basic building block in their machines to create quantum behavior, known as transmon qubits which were invented by NSA.
    - Monitoring 5G successfully requires a deep understanding of what makes it fundamentally different from its predecessors: higher speed, lower range, more distribution nodes, different data protocols.
    - NSA says "In the future, superpowers will be made or broken based on the strength of their cryptanalytic programs"


- Constantly claiming to be a victim is not a sign of virtue. It's a strategy for narcissists and psychopaths to get ahead. Data: people who regularly signal victimhood are more willing to lie, cheat, and steal. Beware those who air personal grievances like every day is Festivus.

- Crypto, 
    - Smart intermediary are the only ones who are earning money. 
    - Markets are lightly regulated 

- Financial Industry
    - Reversion to mean -  yesterday’s best performing funds are tomorrow's worst performing funds.
    - selecting your fund for tomorrow by picking a winner from yesterday is an exercise fraught with peril.
    - Best-performing funds become worst and vice versa. But index funds continue to earn market returns. They are neither the best-performing nor the worst performing, they are squarely in the middle.
    - Nifty 50 Index fund charges 0.07%-0.20%, and active large-cap funds charge about 1-1.5%. So they have to generate 1-1.5% outperformance, just to cover the costs and then beat the index.

- Criteria for Assets for Asset allocation plan, 
    - Fundamentally different - asset classes must be fundamentally different and have unique risk. Stocks and bonds are different; one is ownership and the other is loan. U.S. stocks are different from international stocks in base currency and government policy. Real estate and commodities differ from common stocks in collateral structure. In contrast, U.S. mid-cap stocks are not fundamentally different than large cap and there is very little unique risk.  
    - Real return – an asset class must generate a real return in the long-term (after-inflation). U.S. stocks have outperformed inflation by about six percent historically and real estate has earned about the same. Government bonds have outperformed by about two percent.  In contrast, commodities have no expected return over the inflation rate and do not pass this gate.

    - High liquidity – an asset class must have daily liquidity. Stocks that trade on an organized exchange, and bonds that trade over-the-counter on a regular basis, pass this gate. Real estate ownership − outright or in a partnership − would not pass this gate, although real estate investment trusts (REITs) are exchange traded and do pass. Coins, artwork and other collectables tend to be illiquid and do not qualify.

    - Diversified, low-cost funds – the asset class must be packaged in a liquid, low-cost and broadly diversified product such as a mutual fund or exchange-traded fund (ETF). Since all the analysis on has been based on an index, I prefer to replicate that index in portfolios with index funds and ETFs. An actively-managed product can be used (absent of a good index product), as long as it is broadly diversified and low cost. 

- Philosophy
    - Consistency is the playground of dull minds.
    -  a human being who belongs to any particular culture must hold contradictory beliefs and be riven by incompatible values. 

- The McNamara Fallacy is to presume that
    -  quantitative models of reality are always more accurate than other models;
    - the quantitative measurements that can be made most easily must be the most relevant; 
    -  factors other than those currently being used in quantitative metrics must either not exist or not have a significant influence on success

## 2022-feb-08 Tue

- PostgreSQL Explain Analyzer 
    - Lateral Joins -  run the inner query for every row produced by the outer query.  Useful when one knows approximately how many rows the outer query will return.
    - Consider below output,
        Limit  (cost=0.44..289.59 rows=1 width=52) (actual time=189.343..189.344 rows=1 loops=1)                                                       
        Buffers: shared hit=23168                                                 
        ->  Index Scan using ix_ts on truck_reading  (cost=0.44..627742.58 rows=2171 width=52) (actual time=189.341..189.341 rows=1 loops=1)|
                Filter: (truck_id = 1234)                                           
                Rows Removed by Filter: 1532532                                     
                Buffers: shared hit=23168  

        - This indicates, 
            - PostgreSQL had to scan the entire index and FILTER out more than 1.53 million rows
            - the amount of data PostgreSQL had to process to correctly retrieve the one row of data we were asking for - ~184MB of data! (23168 buffers x 8kb per buffer)

- Reference Data Architecture, 
    
    - An API management platform (often called an API gateway) is necessary to create and publish data-centric APIs, implement usage policies, control access, and measure usage and performance. This  platform also allows developers and users to search for existing data interfaces and reuse them rather than build new ones. An API gateway is often embedded as a separate zone within a data hub but can also be developed as a standalone capability outside of the hub.


- History 
    - Christianity began as an esoteric Jewish sect that sought to convince Jews that Jesus of Nazareth was their long-awaited messiah.
    - Christian success served as a model for another monotheist religion that appeared in the Arabian peninsula in the seventh century – Islam
    - Buddhism - suffering arises from craving; the only way to be fully liberated from suffering is to be fully liberated from craving; and the only way to be liberated from craving is to train the mind to experience reality as it is.

    - Middle east
        - Iran - Was pamperred child of US before religious revolution.
        - One of the main reasons for revolution was 1973 huge drop in oil prices (due to israel war) 
        - reza pahlavi was already fled Iran.
        - Khomaini was installed by religious body
        - Saudi 
        - Has 2 key regions, 
        - Hejaz (Mecca) - South western part consisting of Medina, Jeddah
        - Nejd - Central/eastern part which was poorer than Hejaz
        - Al Saud's come from Nejd and they hold onto power by cajoling salafist nejdi ulama.   
        - Qatar funds brookings think tank in DC.

    - Why study history?
        - Unlike physics or economics, history is not a means for making accurate predictions. We study history not to know the future but to widen our horizons, to understand that our present situation is neither natural nor inevitable, and that we consequently have many more possibilities before us than we imagine.


- Foundation of a economy is always manufacturing

- On Markets - Being really right is a double-edged sword, because it makes you even more confident in your abilities. And you are inclined to lean even harder into your current beliefs. But markets are dynamic, and strategies that outperform today will likely underperform at some point down the road. At the end of the day, Valuation Matters.

- The harder we try with the conscious will to do something, the less we shall succeed. Proficiency and results come only to those who have learned the paradoxical art of doing and not doing, or combining relaxation with activity

- Nietzsche
    - In any population, you are going to have a group of people who are more talented/gifted/intelligent than average. Let’s call them The Strong. You are also going to have a group of people who are less talented/gifted/intelligent than average. Let’s call them The Weak
    - The Strong will naturally accrue the power in society for no other reason than they are more capable and talented than the others.
    - Because The Strong won their greater power and influence through outsmarting or outperforming others, they will come to adopt ethical beliefs that justify their position: that might makes right, that they are entitled to their privileged position, that they earned what is theirs. Nietzsche calls this “Master Morality.”
    - Because The Weak lost their power and influence by being outsmarted and outperformed, they will come to adopt ethical beliefs that justify their position: that people deserve aid and charity, that one should give away one’s possessions to the less fortunate, that you should live for others and not yourself. Nietzsche calls this “Slave Morality.”
    - Master/Slave Moralities have been in a kind of tension in every society for all of recorded history. Many political/social conflicts are side effects of the struggle between Master and Slave Moralities.
    - Nietzsche believed that the ideas of guilt, punishment and a “bad conscience” are all culturally constructed and used by The Weak to chip away at the dominance and power of The Strong. He also believed that Slave Morality is just as capable of corrupting and oppressing a society as Master Morality. He used Christianity as his primary example of this.
    - Nietzsche believed that Slave Morality stifled man’s greatest characteristics: creativity, innovation, ambition, and even happiness itself.
    -  Claiming that the weak people had to invent God so that they could believe their suffering actually meant something.


## 2022-feb-11 Fri

- Postgres High availability with Patroni, 
    - When used in a single datacenter, the environment is typically setup as a 3-node cluster on three separate database hosts. 
    - Basic components, 
        - PostgreSQL cluster: the database cluster, usually consisting of a primary and two or more replicas
        - Patroni: used as the failover management utility
        - etcd: used as a distributed configuration store (DCS), containing cluster information such as configuration, health, and current status.
    - How HA Works, 
        - Each PostgreSQL instance within the cluster has one application database. These instances are kept in sync through streaming replication.
        -  Each database host has its own Patroni instance which monitors the health of its PostgreSQL database and stores this information in etcd. 
        - The Patroni instances use this data to:
            - keep track of which database instance is primary
            - maintain quorum among available replicas and keep track of which replica is the most "current"
            - determine what to do in order to keep the cluster healthy as a whole
            - Patroni manages the instances by periodically sending out a heartbeat request to etcd which communicates the health and status of the PostgreSQL instance. etcd records this information and sends a response back to Patroni. 
        - Streaming replication
            - Keeps replica more up to date compared to file based log shipping. 
            - The standby connects to the primary, which streams WAL records to the standby as they're generated, without waiting for the WAL file to be filled.
            - is asynchronous by default.

- History
    - history’s choices are not made for the benefit of humans. This is difficult to evaluate due to lack of scale.
    - There is no proof that cultures that are beneficial to humans must inexorably succeed and spread, while less beneficial cultures disappear. 
    - How modern science differs, 
        -  The willingness to admit ignorance. Modern science is based on the Latin injunction ignoramus – ‘we do not know’. It assumes that we don’t know everything. Even more critically, it accepts that the things that we think we know could be proven wrong as we gain more  knowledge. No concept, idea or theory is sacred and beyond challenge. 
        -  The centrality of observation and mathematics. Having admitted ignorance, modern science aims to obtain new knowledge. It does so by gathering observations and then using mathematical tools to connect these observations into comprehensive theories.
        - The acquisition of new powers. Modern science is not content with creating theories. It uses these theories in order to acquire new powers, and in particular to develop new technologies.
        - The willingness to admit ignorance has made modern science more dynamic, supple and inquisitive than any previous tradition of knowledge.
        - The willingness to admit ignorance has made modern science more dynamic, supple and inquisitive than any previous tradition of knowledge. This has hugely expanded our capacity to understand how the world works and our ability to invent new technologies. But it presents us with a serious problem that most of our ancestors did not have to cope with. Our current assumption that we do not know everything, and that even the knowledge we possess is tentative, extends to the shared myths that enable millions of strangers to cooperate effectively. If the evidence shows that many of those myths are doubtful, how can we hold society together? How can our communities, countries and international system function? All modern attempts to stabilise the sociopolitical order have had no choice but to rely on either of two unscientific methods: 
        - Take a scientific theory, and in opposition to common scientific practices, declare that it is a final and absolute truth. This was the method used by Nazis (who claimed that their racial policies were the corollaries of biological facts) and Communists (who claimed that Marx and Lenin had divined absolute economic truths that could never be refuted). 
        - Leave science out of it and live in accordance with a non-scientific absolute truth. This has been the strategy of liberal humanism, which is built on a dogmatic belief in the unique worth and rights of human beings – a doctrine which has embarrassingly little in common with the scientific study of Homo sapiens. 
        - Science, industry and military technology intertwined only with the advent of the capitalist system and the Industrial Revolution.
            -  social poverty, which withholds from some people the opportunities available to others;
            - biological poverty, which puts the very lives of individuals at risk due to lack of food and shelter.
            - Most scientific studies are funded because somebody believes they can help attain some political, economic or religious goal.
        - What did Asian cultures lacked when compared to European/British from 15th century onwards, 
            - They lacked the values, myths, judicial apparatus and sociopolitical structures that took centuries to form and mature in the West and which could not be copied and internalised rapidly. Asians organized their society differently.
        - France and the United States quickly followed in Britain’s footsteps because the French and Americans already shared the most important British myths and social structures. 
        - Europeans were used to thinking and behaving in a scientific and capitalist way even before they enjoyed any significant technological advantages
        -  European imperialists set out to distant shores in the hope of obtaining new knowledge along with new territories.
        -  Europeans favour present observations over past traditions
        - Banks are allowed to loan $10 for every dollar they actually possess, which means that 90 per cent of all the money in our bank accounts is not covered by actual coins and notes.


- decentralized finance?
    - Traditional finance involves many financial intermediaries like stock markets, hedge funds and banks. Banks, for example, stand in between savers and borrowers and, as we explain in Modern Principles, they perform useful services like evaluating borrowers and creating easy means of payments like credit cards and checks. Naturally, financial intermediaries also take a cut of the proceeds, about 8% of GDP!.
    - Decentralized finance replaces some of these intermediaries with code, smart contracts, that allows buyers and sellers, borrowers and lenders and others to interact more directly and we hope at lower cost and with greater innovation.

- Consumer lending 
    - Consumer lending seems easy, but it's not. There are three categories of people. Those that don't need credit. Those that need credit but manage money responsibly & will pay you back. And those that will take whatever credit they are offered, manage money poorly, and will default
    - Success in consumer lending is about finding a way to successfully differentiate between category 2 and 3. And it's not that easy - particularly because you can remain current on your loans for quite a while if you have access to more credit borrow more from A to repay B.

## 2022-feb-14 Mon

- Jack Bogle's investment advice 
    - Regular rebalancing is not necessary 
    - 60-40 is probably good allocation 
    - key things to think about how much risk one can take 
    -pay attention to GDP

- Adam Smith in "The wealth of nations", 
    - an increase in the profits of private entrepreneurs is the basis for the increase in collective wealth and prosperity.
    - Egoism is altruism.
    -  Capital consists of money, goods and resources that are invested in production.

- Mideval Europe
    - In Europe, kings and generals gradually adopted the mercantile way of thinking, until merchants and bankers became the ruling elite
    - The European conquest of the world was increasingly financed through credit rather than taxes, and was increasingly directed by capitalists whose main ambition was to receive maximum returns on their investments. 
    - The mercantile empires were simply much shrewder in financing their conquests.
    -  credit financed new discoveries; discoveries led to colonies; colonies provided profits; profits built trust; and trust translated into more credit. For Asian empires, Credit was secondary and during campaigns they ran out of fuel after a few thousand kilometres. Capitalist entrepreneurs only increased their financial momentum from conquest to conquest.
    - Due to uncertain nature of campaigns and risks involved, europeans adopted approach of limited liability joint stock companies where multiple investors bet money on campaign with less risk for individual. 
    - Decade by decade, western Europe witnessed the development of a sophisticated financial system that could raise large amounts of credit on short notice and put it at the disposal of private entrepreneurs and governments. This system could finance explorations and conquests far more efficiently than any kingdom or empire.
    - Capital trickles away from dictatorial states that fail to defend private individuals and their property. Instead, it flows into states upholding the rule of law and private property.
    - the British Empire was established and run largely by private joint-stock companies based in the London stock exchange

## 2022-feb-17 Thu

- Public discourse etc.
    -Religion is a culture of faith; science is a culture of doubt 
    -Institutions are hard to institute & maintain, because human beings are self-righteous, hubristic, and power-hungry (a la Trudeau "I will get my way no matter what"). We are always tempted to discard institutions when they become a short term nuisance/obstruction to expediency

- Portfolio Construction , John Bogle ***
    - Benjamin Graham believed that investors should never be entirely out of the stock market (or entirely in it, either).
    - Graham advised that when enthusiasm is high, you should trim back your stocks, but never to zero -- and when pessimism prevails, you should raise your allocation to stocks, but never to 100%.
    - Graham suggested keeping a minimum of 25% and a maximum of 75% in stocks, with the rest in bonds.

    - On virtues of Investors, 
        - Investors can cultivate their independence by working at it, by always asking whether what other people are saying or doing makes sense, by never pursuing a course of action just because other people are.
    - Norway Model vs Yale Model 
        - Norway has Social security program worth 1.3T for 5 million population 
        - It began after it discovered an abundance of oil back in 1969, and the country designed an investment strategy to grow their newfound wealth.
        - More than half of assets are in growth stocks alone. The Norway Pension Fund Global is the single  largest owner of global stocks in the entire world.
        - The Norway Model is characterized by minimal use of expensive products, like private equity and hedge funds, and focuses instead on keeping fees low, and diversifying across publicly traded stocks and bonds. It uses passive management – meaning the investment decision-makers don't purport to have the expertise to pick which stocks will outperform which other stocks. They just buy a little bit of every stock.
        -  Norway's pension fund currently has money in over 9,100 stocks, across 69 countries!
        - The other model is  Yale Model is characterized by usage of expensive alternative assets like hedge funds and private equity.
        -It is access to certain people, deals, and funds that make investing in expensive, private products potentially worth it. An institution like Yale has this access, and these connections, in spades. It is the institutions who don't have elite access, most of whom have, like lemmings, followed Yale into this investment approach, whose communities and alumni bases are being poorly served. Not everyone is Yale.

- International payments,
    -  cross-border transfers: “Correspondent banking is an arrangement, where one bank (the correspondent) holds deposits
    owned by other banks (the respondents) and provides payments and other services to them.
    - “Closed loop” (or in-house) payment systems, where one organization (exclusively) provides the services to both originator and beneficiary.
    - Fintechs have developed very cost efficient cross-border payment services for often used currency pairs. They use local accounts in both currencies. As soon as the originator pays an amount to the account of the fintech in his country of residence, the fintech account in the country of residence of the beneficiary credits an equivalent amount. A real currency conversion is not necessary.
    - SWIFT's main function is to communicate payment instructions across borders, but without the actual clearing and settlement.
    - Ripple has tried to establish a faster wholesale alternative to correspondence banking with SWIFT, based on distributed ledger technology,
    - More than 90% of the $140 trillion of cross-border transmissions in 2020 – equivalent to 152 percent of global GDP – were signaled via SWIFT (The Economist 2021).
    - SWIFT operated a data center in the US where all messages were stored for 124 days. Since last few years, SWIFT has segregated message storage between Europe (for intra-europe transactions) and rest in US.
    - SPFS (System for Transfer of Financial Messages) is a Russian alternative to SWIFT.Mainly used within Russia. 
    - China operates the “Cross-Border Interbank Payment System” (CIPS). not only a financial messaging system such as SWIFT, but a complete payment system, also incorporating clearing and settlement.

## 2022-feb-18 Fri

- Obfuscation for Android 
    - R8 - standard optimizer and obfuscator. All classes, functions and variables are renamed to short, unreadable names. Proguard is alternative free Code obfuscation tool. 

- Database Query performance analysis (MySQL) 
    -  lock time greater than 50% of query time is a problem because MySQL should spend the vast majority of its time doing work, not waiting.
    - Locks are primarily used for writes (INSERT, UPDATE, DELETE, REPLACE) because rows must be locked before they can be written. Response time for writes depends, in part, on lock time
    - For reads (SELECT), there are nonlocking and locking reads. The distinction is easy because there are only two locking reads: SELECT…FOR UPDATE and SELECT…FOR SHARE. If not one of those two, the SELECT is nonlocking, which is the normal case.
    - Locking reads should be avoided, especially SELECT…FOR UPDATE, because they don’t scale, they tend to cause problems, and there is usually a nonlocking solution to achieve the same result
    - Rows examined is the number of rows that MySQL accessed to find matching rows. It indicates the selectivity of the query and the indexes. The more selective both are, the less time MySQL wastes examining nonmatching rows.

## 2022-feb-21 Mon

- basic lesson of evolutionary psychology: a need shaped in the wild continues to be felt subjectively even if it is no longer really necessary for survival and reproduction. 

- Cosmic rays altering the state of bit in a computer. Higher you go from earth's surface cosmic radiation increases. Blue screen appearing randomly could be due to cosmic particles 

- Tech#How postgre stores rows
    - PostgreSQL stores the actual data into segment files (more generally called heap files). Typically its fixed to 1GB size but you can configure that at compile time using --with-segsize. When a table or index exceeds 1 GB, it is divided into gigabyte-sized segments. This arrangement avoids problems on platforms that have file size limitations but 1GB is very conservative choice for any modern platform. These segment files contain data in fixed size pages which is usually 8Kb, although a different page size can be selected when compiling the server with --with-blocksize option but this size usually falls in ideal size when considering performance and reliability tradeoffs. If the page size is too small, rows won’t fit inside the page and if it’s too large there is risk of write failure because hardware generally can only guarantee atomicity for a fixed size blocks which can vary disk to disk (usually ranges from 512 bytes to 4096 bytes).
    - Internally PostgreSQL maintains a unique row id for our data which is usually opaque to users. We can query it explicitly to see its value.in ctid First digit stand for the page number and the second digit stands for the tuple number. PostgreSQL moves around these tuples when VACUUM is run to defragment the page. 

- Stock Markets
    - Terminologies used by Short sellers
    -  “spoofing,” -  involves flooding the market with fake orders in an effort to push a stock price up or down,
    - "Scalping" - short-sellers cash out their positions without disclosing it

- Code Obfuscation types
    - Name obfuscation - replaces the names of packages, classes, methods, and fields with meaningless sequences of characters. Sometimes the package structure is also modified, which further obscures the names of packages and classes.
    - Flow obfuscation - h modifies code order or the controlflow graph, and string encryption, whic encrypts the constant strings in the code. Some tools may go further and obfuscate the XML files in the resource part of the APK

- Deng Xiaoping is going to go down as one of the greatest leaders that any nation ever had. Because he had to give up his own ideology to do something else that worked better.

- Each newspaper—all those local monopolies—was an independent bastion of power. The economic position was so impregnable, they were all monopolies. The ethos of the journalists was trying to tell it like it is. They were really a branch of the government. They call them the Fourth Estate, meaning the fourth branch of the government. 

- cognitive dissonance, the tension that arises when beliefs and reality collide.


- .NET Async streams
- Can be used with "Async/await" and then using "yield return" within the function 
- Cancellationtoken can be passed for cancelling the stream
