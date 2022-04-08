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

## 2022-feb-22 Tue

- Tech
    - Easier ways of doing things
        - SSL certificates, with Let’s Encrypt
        - Concurrency, with async/await (in several languages)
        - Centering in CSS, with flexbox/grid
        - Building fast programs, with Go
        - Image recognition, with transfer learning (someone pointed out that the joke in this XKCD doesn’t make sense anymore)
        - Building cross-platform GUIs, with Electron
        - VPNs, with Wireguard
        - Running your own code inside the Linux kernel, with eBPF
        - Cross-compilation (Go and Rust ship with cross-compilation support out of the box)
        - Configuring cloud infrastructure, with Terraform
        - Setting up a dev environment, with Docker
        - Sharing memory safely with threads, with Rust
    - Easier using hosted services
        - CI/CD, with GitHub Actions/CircleCI/GitLab etc
        - Making useful websites by only writing frontend code, with a variety of “serverless” backend services
        - Training neural networks, with Colab
        - Deploying a website to a server, with Netlify/Heroku etc
        - Running a database, with hosted services like RDS
        - Realtime web applications, with Firebase
        - Image recognition, with hosted ML services like Teachable Machine
        - Cryptography, with opinionated crypto primitives like libsodium
        - Live updates to web pages pushed by the web server, with LiveView/Hotwire
        - Embedded programming, with MicroPython
        - Building videogames, with Roblox / Unity
        - Writing code that runs on GPU in the browser (maybe with Unity?)
        - Building IDE tooling with LSP (the language server protocol)
        - Interactive theorem provers (not sure with what)
        - NLP, with HuggingFace
        - Parsing, with PEG or parser combinator libraries
        - ESP microcontrollers
        - Batch data processing, with Spark

- MySQL 
    - frequently dredging up old data is problematic for performance.
    - determine the ideal data model for the access, then use a data store built for that data model
    - Enqueue writes - Use a queue to stabilize write throughput. It allow the application to respond gracefully and predictably to flood of requests that overwhelms the application, or the database, or both.For write-heavy applications, enqueueing writes is the best practice and practically a requirement. Invest the time to learn and implement a queue.
    - Data Partitioning - separating hot and cold data: frequently and infrequently accessed data, respectively. It partitions by Access and it archives by moving the infrequently accessed (cold) data out of the access path of the frequently accessed (hot) data
    - Reference data size limit of a single MySQL instance to 2 or 4 TB (on SSD):
        - 2 TB - For average queries and access patterns, commodity hardware is sufficient for acceptable performance, and operations complete in reasonable time.
        - 4 TB - For exceptionally optimized queries and access patterns, mid- to highend hardware is sufficient for acceptable performance, but operations might take slightly longer than acceptable.
    - Sharding 
        - High cardinality - An ideal shard key has high cardinality (see “Extreme Selectivity”) so that data is evenly distributed across shards. A great example is a website that lets you watch videos: it could assign each video a unique identifier like dQw4w9WgXcQ. The column that stores that identifier is an ideal shard key because every value is unique, therefore cardinality is maximal.
        - Reference application entities - An ideal shard key references application entities so that access patterns do not cross shards. A great example is an application that stores payments: although each payment is unique (maximal cardinality), the customer is the application entity. Therefore, the primary access pattern for the application is by customer, not by payment. Sharding by customer is ideal because all payments for a single customer should be located on the same shard.
        - When opting for sharding, plan to accomodate at least four years of data growth.
        - ProxySQL and Vitess are middlewares (between app and MySQL) that support sharding by several mechanisms.
    - A common misconception is that the application needs thousands of connections to MySQL for performance or to support thousands of users. This is patently not true. The limiting factor is threads, not connections—more on Threads_running in a moment. A single MySQL instance can easily handle thousands of connections. I’ve seen 4,000 connections in production and more in benchmarks. But for most applications, several hundred connections (total) is more than sufficient. If your application demonstrably requires several thousand connections, then you need to shard.
    - MySQL runs one thread per client connection 
    - One CPU Core runs one thread.When the number of threads running is greater than the number of CPU cores, it means that some threads are stalled - waiting for CPU Time.
    - Four metrics count the occurrence of SELECT statements that are usually bad for performance:
        - Select_scan
        - Select_full_join
        - Select_full_range_join
    - Database Capacity planning
        - the four-year fit is an estimate of data size or access in four years applied to the capacity of your hardware today
        - It’s better to be more precise and collect table sizes every 15 minutes.Near-term data growt trending is used to estimate when the disk will run out of space. Long term trend is used to estimate when sharding is necessary.
    - A deadlock occurs when two (or more) transactions hold row locks that the other transaction needs

- Stock Market#Indices
    - Index providers like MSCI make money in three ways. They charge index funds and managers of exchange-traded funds a few basis points on the assets that track their benchmarks; they charge exchanges like CME a commission on each traded option or futures contract linked to their indices; and they charge subscription fees to a range of third-party users.

- Quotable "Quotes"
    - “A single arrow is easily broken, but not ten in a bundle” 
    - When one buys international stocks there are actually two trades here - one to buy the local currency and the other to buy the stock
    - Peter bernstein 
        - Survival is the only road to riches
        - The riskiest moment is when you’re right.That’s when you’re in the most trouble, because you tend to overstay the good decisions. 
        - When you invest, it’s not your wealth today, but it’s your future that you’re really managing.
        - Pascal’s Law: the consequences of decisions and choices should dominate the probabilities of outcomes
        - Risk-taking is an inevitable ingredient in investing, and in life, but never take a risk you do not have to take
        - Experience shapes memory; memory shapes our view of the future. 
        - there is a tendency for people to expect the status quo either to last indefinitely or to provide advance signals for shifting strategies.  The world does not work like that.  Surprise and shock are endemic to the system, and people should always arrange their affairs to that they will survive such events.

- Minto Pyramid principle
    - Applying the top-down structure of a pyramid in communication methods means that a direct answer is given to the question that has been asked. These could also be recommendations, the results from a study, thesis statement or other key points.
    - Minto Pyramid Principle inverts the traditional method that’s used to arrive at a conclusion. Usually, the conclusion in a text or presentation is given after the facts have been presented, and all analyses and supporting ideas have been discussed.
    - The reason to first make the recommendation and then offer the motivation is that the supervisors often already see the conclusion or recommendation coming when a flood of arguments and reasons is provided. This because they think in such a top-down way, focusing on the bigger picture.
    - Moreover, a direct communication method is more convincing than a conversation that beats about the bush. A direct communication style is a display of assertiveness and self-confidence.

- History
    - Each society has two groups 
        - commercial elites and military elites - and con icts occur based on the incentives of these groups. 
        - There are two types of institutions, inclusive institutions w and extractive institution. Roughly speaking with inclusive institutions the commercial elites have the upper hand, while with extractive institutions the military elites have the upper hand.
        - In a head to head contest between an extractive and inclusive society the extractive society is assumed to be more likely to prevail.

- Quantum Computing (2022)
    - Quantum computing is about doing things much more efficiently than what is currently possible.
    - For now, there is no realistic time scale on when powerful quantum computers would be available that fulfil perceived use cases efficiently.
    - It is far harder to make reliable,scalable quantum processor.
    - Noise - Quantum device leaking the information. 

## 2022-Mar-01 Tue

- Optimistic concurrency 
    - When OTP is generated, it must be getting saved in DB against Card Number. 
    - In that table, add version column (i.e. 'timestamp with time zone')
    - While beginning transaction, read this version and proceed with steps
    - Before commit, check the version as part of 'update ...where ' statement. If rows affected are 0, roll back the transaction.
    - prefer not using triggers 
    - Pessimistic locking (Select ....for update nowait) can not be used here since it requires stateful connection to database and locks can not be held across connections.
    - Alternative to version column is Hash/checksum but its computationally expensive and has some issues with column types like BLOB, LONG, LONG RAW etc. 
    - There is possibility of having Blocking inserts when having table with Unique constraint when two or more transactions are trying to enter same record.  

- Investment Portfolio
    - One is that it’s a bad idea to overhaul your portfolio when you’re afraid. The time to become more conservative is when things are going well, not when the world seems to be coming apart.
    - consider embracing surprise instead of fleeing from it.

- Air force 
    - Mirage 2000 aircraft is very robust,over-built aircraft in the sense it can take upto 11g of Gravitational load (on its airframe) when pitched in. This means that it can carry on offering service well after its official service time. Same is with Rafale.
    - In Defence,  localize special/deniable items and import or buy Off the shelf commodities technologies

- International Trade 
    - National economies no long matter rather what matters is multinational corporations coordinating far flung “value chains.”

- Sleep
    - Caffeine, nicotine and alchohol impacts negatively.
    - Identify your sleep pattern - like 11-7am or 10-5am and act accordingly, There are five types , extreme morning, morning, neutral, evening and extreme evening type.
    - As far as possible do not nap during day - even if you have to take it before 1pm and that too it shud be brief like less than 10 minutes.
    - If you are looking for sympathy, it is between shit and psyphelis (i.e. its very bad)
    - Dont spend too much time in bed as it affects next day's sleep
    - Dont go to bed earlier
    - Dont put clocks in bedroom and dont look at time (on smartphone) while sleeping

- How Petrodollars work
    - The crucial point that this highlights is that Russia’s reserve accumulation, like reserve accumulation by other oil and gas producers such as Norway or Saudi Arabia, is a source of funding in Western markets. The reserves do not simply sit idly in central banks accounts, they are lent out. With sanctions, the funding provided by Russia’s petro- and gas-dollars is in jeopardy. And that impacts not only the Russians.The Russian funds in European central banks are not simply pools of money sitting idly. They are part of complex chains of transactions that may now be put in jeopardy by the sanctions.This is true more generally for global financial markets at a time of huge uncertainty.

## 2022-Mar-03 Thu

- Quantum Computing's impact
    -  the most important security and privacy properties to protect in the face of a quantum computer are confidentiality and authentication.
        - quantum computers will not only be able to decrypt on-going traffic, but also any traffic that was recorded and stored prior to their arrival.
        - The threat model for authentication is a little more complex: a quantum computer could be used to impersonate a party in a connection or conversation. 

## 2022-Mar-04 Fri

- China and Russia Trade
    - By 2020, only 46% of the trade between two countries was conducted in dollars.
    - Removing russia from SWIFT may accelerate the process of de-dollarization
    - In response to covid-19, the Federal Reserve increased its total assets from $4.1 trillion in January 2020 to $8.3 trillion as of August 2021. This historic level of money printing has led to US inflation reaching its highest level in 40-years.
    - Russia is one of the world's largest exporters of oil with the United States importing more than 600,000 barrels per day. Russian oil represents more than a third of Europe's total imports.

- International Payments
    - Banks largely cannot hold money extraterritorially directly, for most useful values of “directly.” Instead, they rely on a correspondent banking relationship.
    - Banks can have accounts at other banks, and extremely frequently do. A major reason to do this internationally is to facilitate payments in other currencies and other jurisdictions.
    - SWIFT: The world’s most expensive encrypted messaging service
    - SWIFT is almost synonymous with international wires because it is the primary way that banks and their correspondents choose to interoperate with respect to wires
    -  Specifically, they send a MT 103 message, which is a bit longer than a tweet, and then each bank operates their internal books and other banking systems to make the request encoded in the message a reality (or fail gracefully) 
 

- Gold only has value, if “gold whales” (=central banks) aren’t selling it.

- Inflation is not result of Central bank printing money but rather due to Government's borrowings and how much credit is created in economy.  India has around 200 lakh crore money in circulation. out of this, 10% of money is in circulation.

## 2022-Mar-07 Mon

- Analysing Balance Sheet 
    - Check "Profit before Tax" against "Net Fixed assets". See if company is generating healthy profit compared to other safe investment options like Govt. Bonds etc.

- Psychology of Money 
    - what people really want in life is independence and autonomy. Money is a conduit to gain it.

- Internation investment through NSE IFSC 
    - When a company listed on exchanges in one country wants to attract investors and trading in another country, it is done through Depository Receipts (DRs). If the company offers the DR, it is called sponsored DR and if the company isn’t involved, it is called unsponsored DR.
    - Charges
    - the exchange itself will charge 12 cents for every $100 or 0.12% compared to 0.00345% charged within India for equity trades. ( the transaction charges would go down with an increase in trading volumes.)
    - A T+3 day settlement, which means stocks or DRs once bought will get credited after 3 days (it is 2 days in India) to the demat account. similarly, funds from stocks sold will get credited after 3 days.

- Saudi History 
    - Ibn ʻAbd al-Wahhabʼs students were the only people who knew how to read and write and history was written from their perspective. Ibn 'Abd al-Wahhabʼs writing has been used by many extremists for their own agendas.
    - Saudi Arabia is a monarchy,  beneath the monarchy there is a complex structure of tribal and urban monarchical system like tribal chiefs and urban leaders.

- Strategy
    - The importance of randomized strategies was one of the early insights of game theory.
    - Rules, 
        - 1: Look ahead and reason back. Anticipate where your inxittial decisions will ultimately lead, and use this information to calculate your best choice.

## 2022-Mar-09 Wed

- Linux Diagnostic tools
    - ‘vmstat’ - reports information about processes, memory, paging, block IO, traps, and CPU activity.
    - ‘iostat’ - reports CPU and input/output statistics of the system.
    - ‘netstat’ - displays statistical data related to IP, TCP, UDP, and ICMP protocols.
    - ‘lsof’ - lists open files of the current system.
    - ‘pidstat’ - monitors the utilization of system resources by all or specified processes, including CPU, memory, device IO, task switching, threads, etc.

- Financial Instruments
    - credit default swap is an insurance policy on the bonds of a country or company. If you buy a $100 bond and a $100 CDS, you should always get back $100.

- Investing 
    - Warning signs
        - No response to queries even after followups
    - Criteria
        - Sales & Profit growth 
        - No Cyclic profits but should be consistent
        - Enough Cash flows (Profits converted into cash) 
        - Low in debt
        - Management Quality

- Futures
    - Futures are mark-to-market financial products, and when the futures price goes up, the short side of the futures contract has to put up money today.

- Tech#Database Record Access
    - Why indexes, 
        - When data is stored on disk-based storage devices, it is stored as blocks of data. These blocks are accessed in their entirety, making them the atomic disk access operation. Disk blocks are structured in much the same way as linked lists; both contain a section for data, a pointer to the location of the next node (or block), and both need not be stored contiguously. Due to the fact that a number of records can only be sorted on one field, we can state that searching on a field that isn’t sorted requires a Linear Search which requires (N+1)/2 block accesses (on average), where N is the number of blocks that the table spans. If that field is a non-key field (i.e. doesn’t contain unique entries) then the entire tablespace must be searched at N block accesses. Whereas with a sorted field, a Binary Search may be used, which has log2 N block accesses. Also since the data is sorted given a non-key field, the rest of the table doesn’t need to be searched for duplicate values, once a higher value is found. Thus the performance increase is substantial.

    - What is indexing?
        - Indexing is a way of sorting a number of records on multiple fields. Creating an index on a field in a table creates another data structure which holds the field value, and a pointer to the record it relates to. This index structure is then sorted, allowing Binary Searches to be performed on it. The downside to indexing is that these indices require additional space on the disk since the indices are stored together in a table using the MyISAM engine, this file can quickly reach the size limits of the underlying file system if many fields within the same table are indexed. 
    - When should it be used?
        - Given that creating an index requires additional disk space (277,778 blocks extra from the above example, a ~28% increase), and that too many indices can cause issues arising from the file systems size limits, careful thought must be used to select the correct fields to index.

## 2022-Mar-10 Thu

- PostgreSQL Learnings, 
    - LEFT JOIN in place of an INNER JOIN helps the planner make more accurate row count predictions. Adding redundant ON clauses improves Hash Joins.
    -  ANY(VALUES ...) instead of IN can enforce a Hash Aggregate with many elements.
    - It’s a bad idea to make the table primary key a varchar.
    - CLUSTER rocks when the query returns many related rows.
    - pg_hint_plan offers powerful hints, including the estimated row count correction Rows, JOIN sequence enforcer Leading, and the index override IndexScan. Though the latter may strike back.
    - https://explain.tensor.ru to visualize EXPLAIN-s.

## 2022-Mar-11 Fri

- Purposely low expectations is the only way to survive in a world that's not kind enough to reward every ambitious person with success.
- In a index of 500 stocks, fewer than 20 companies make up most of returns. sometimes its fewer than 5 companies. The rest range from ok to disastorous returns. 
- Things are unlikely to change because for most people the way things are right now is indistringuishable from magic relative to how things used to be.Hence any little improvements that happen to come along feel incredible.

## 2022-Mar-14 Mon

- "No man ever steps in the same river twice, for it is not the same river and he is not the same man."--Heraclitus

- Crude oil 
    -  Depending on its chemical composition, crude oil can be either “sweet” or “sour” depending on its sulfur content; or “heavy” or “light” depending on its gravity (i.e. whether it is heavier or lighter than water). These distinctions matter because re neries can only process one type of crude oil at a time. The process of converting them to handle another can take between months and years. Even if another re nery was available that could process the oil, it might not have sufficient capacity to handle the additional throughput.

    - Natural gas -  cheapest way to transport natural gas is by pipeline. Overseas transport is an expensive and technologically challenging process due to the need to liquefy and then re-gasify the natural gas. Oil, by contrast, can be shipped on land or sea in whatever form is required without the need for pressurized containers. For that reason, most producers and consumers of natural gas depend on long-term contracts that lock in prices for the latter (usually linked to oil but o en at a discount) and amortize the cost of constructing and maintaining pipelines for the former. 

- Innovation at Companies 
    - Slow down to innovate
    - "Good ideas can get trapped inside big companies because they're not staffed to succeed. The challenge at any established company is that the demands of your core business will always soak up all of the bandwidth of your leaders."
    - Your process for finding new product ideas should come down to this: What helps you make the right decision to take
    the next step and figure out if A) this is the customer problem you want to solve, and B) this is the customer experience that solves that problem?
    - If you can't describe something that sounds compelling and that people really want and need in a one-page press release, then there's no point in building it.
    - Good intentions don't work, mechanisms do.
    -You can't get to a place where you don't know if your business was better this week than it was last week or this quarter over last quarter — otherwise, it will continue to get worse, undetected.

-- Genghis khan - a persistent cycle of pragmatic learning, experimental adaptation, and constant revision driven by his uniquely disciplined and focused will. He took chinese noodles to west. 

- Prof. Richard Thaler's advice on investing 
    - Put away money to take care of emergency (typically government bonds)
    - Use low-cost index funds as core holdings. Plan on investing for decades.
    - Decide on Asset allocation

- Investing#Index fund
    - TRI - Total returns index - Nifty index values are ignoring dividends but TRI shows figure dividends/bonuses re-invested back. 
    - It is necessary to compare index fund returns with TRI and not index itself.

- Russian History   
    - Post Soviet breakup, two harward economists (Shliefer and sacks) were enlisted as advisors by Russian Govt. (Chuikov) as advisors for privatization
    - One of these advisors faced lawsuit for conflict of interest and had to settle it out of court. 
    - This privatization gave rise to Oligarch. Majority of these oligarchs are jewish 

- Self descipline can be taught.
- Assessing Judgement of somebody else - Accept that they r making it under certain context. Stand in their shoes before passing it on. 
- Next war may be won or loss even before people realize it happened.

- Tech#HAProxy - HAProxy is a high-availability server used for load balancing and as a proxy for TCP and HTTP applications. It can do TLS offloading, header-based and route-based routing, and health checks for backends. It supports protocols like WebSocket, gRPC, HTTP and more.

- GeoPolitics
    - Post Soviet breakup, Russia started privatization with 2 russian-american jewish harvard professors (Shleifer and sacks) as advisors
    - Shleifer's involvement with both Harvard and the Russian government culminated many years later in a conflict of interest scandal involving personal gains from investments in Russian securities. After an investigation, both Harvard and Shleifer were forced to pay fines in 2005 to bring the matter to an end.
    - This privatization gave rise to russian oligarchs
    - Majority of these oligarch's are jewish, hence israel's outrich w.r.t. Russia-Ukraine crisis.


- Markets# Options
    - A put option allows you to sell a security at an agreed price any time before it expires. It is a way to bet that the thing will go down. 

- When you make a decision , you shouldn't be thinking about its impact tomorrow but its impact 10 years down the line - Margaret Thatcher

- Certainty is impossible goal. Some people keep asking for more and more information aiming to drive uncertainty to zero 

- Psychology
    - You can’t be an important and life-changing presence for some people without also being a joke and an embarrassment to others.
    - when a person has no problems, the mind automatically finds a way to invent some.
    - finding something important and meaningful in your life is perhaps the most productive use of your time and energy
    - Maturity is what happens when one learns to only give a bother about what’s truly bother worthy.
    - The life itself is a form of suffering
    - Two ways people think about their problems, 
        - Denial. Some people deny that their problems exist in the first place. And because they deny reality, they must constantly delude or distract themselves from reality. This may make them feel good in the short term, but it leads to a life of insecurity, neuroticism, and emotional repression.
        - Victim Mentality. Some choose to believe that there is nothing they can do to solve their problems, even when they in fact could. Victims seek to blame others for their problems or
        blame outside circumstances. This may make them feel better in the short term, but it leads to a life of anger, helplessness, and despair.
    - Highs - Whether it’s a substance like alcohol, the moral righteousness that comes from blaming
    others, or the thrill of some new risky adventure, highs are shallow and unproductive ways to go about one’ life.Highs also generate addiction. The more you rely on them to feel better about your underlying problems, the more you will seek them out.
    - Everything comes with inherent sacrifice
    - Make a habit of questioning emotions
    - What creates our positive experiences will define our negative experiences
    - The path to happiness is a path full of shitheaps and shame. 
    - Entitled people exude a delusional degree of self-confidence
    - problem with entitlement is that it makes people need to feel good about themselves all the time, even at the expense of those around them
    - Research shows that once one is able to provide for basic physical needs (food, shelter, and so on), the correlation between happiness and worldly success quickly approaches zero.
    - people who base their self-worth on being right about everything prevent themselves from learning from their mistakes 
    - Good values are 1) reality-based, 2) socially constructive, and 3) immediate and controllable

- Tech#Encryption 
    - Symmetric-key algorithm - the same key is used to encrypt and decrypt.

## 2022-Mar-17 Thu

- Database Workloads 
    - OLTP
        - Characterstics, 
            - Inserts, updates, and deletes only affect a single row. An example: Adding an item to a user’s shopping cart.
            - Read operations only read a handful of items from the database. An example: listing the items in a shopping cart for a user.
            - Aggregations are used rarely, and when they are used they are only used on small sets of data. Example: getting the total price of all items in a user their shopping cart.
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
            - How long it took to run all of the queries that are part of the benchmark
            - How long it took to run each of the queries, measured separately per query 
    - HTAP (Hybrid transactional/analytical processing)
        - Combines characteristics from OLTP and OLAP
    - Important questions while benchmarking 
        - Is it running on production infrastructure? A lot more performance can usually be achieved when critical production features have been disabled. Things like backups, High Availability (HA) or security features (like TLS) can all impact performance.
        - How big is the dataset that was used? Does it fit in RAM or not? Reading from disk is much slower than reading from RAM. So, it matters a lot for the results of a benchmark if all the data fits in RAM.
        - Is the hardware excessively expensive? Obviously a database that costs $500 per month is expected to perform worse than one that costs $50,000 per month.
        - What benchmark implementation was used? Many vendors publish results of a TPC benchmark specification, where the benchmark was run using a custom implementation of the spec. These implementations have often not been validated and thus might not implement the specification correctly.

- Tech#DNS Servers
    - Two types
        - Resolvers - handle DNS Queries
        - Authoritative Nameservers - Has database of DNS Entries.
- Psychology 
    - Everything comes with an inherent sacrifice
    - What creates our positive experiences will define our negative experiences

## 2022-Mar-21 Mon

- Recommended Online security measures 
    - Use 2FA - Avoid SMS for second authentication as it is vulnerable to SIM jacking (i.e. SIM Swapping attack where In these attacks, a hacker convinces your mobile provider to reroute your phone number to their device. They can then access information and accounts linked to that phone.)
    - Use password Manager
    - Patch O/s for latest updates
    - Review cloud, social, and financial security/privacy settings
    - Only download software from official sites 
    - change passwords and close unused accounts
    - setup email aliases for online accounts
    - Use VPN not public networks or computers

- Web Appliation Monitoring 
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
    - Relevant Metrics should be available to slice by endpoint or job, tenant_id, app_id, worker_id, zone, hostname, and queue (for jobs).
    - In absense of observability setup, start with logs. For Format, consider using https://stripe.com/blog/canonical-log-lines

    - Key Non-functional aspects of a Payments System
        - Reliability and fauly tolerance 
        - Reconciliation 

    - Non relational databases are good for below requirements, 
        - Application requires super-low latency
        - Data is unstructured or no relational data
        - Only need to serialize/de-serialize data 
        - Store massive amount of data

    - Message queues provide Decoupling, async processing which is good for scalability of applications
    - Idempotency in API, 
        - idempotency key is usually a unique value that is generated by the client and expires after a certain period of time. A UUID is commonly used as an idempotency key and it is recommended 
        - To perform an idempotent payment request, an idempotency key is added to the HTTP header <idempotency-key: key_value>
        - an idempotency key is sent to the payment system as part of the HTTP request
        - For the second request, it’s treated as a retry because the payment system has already seen the idempotency key. When we include a previously specified idempotency key in the request header, the payment system returns the latest status of the previous request. 
        - If multiple concurrent requests are detected with the same idempotency key, only one request is processed and the others receive the “429 Too Many Requests” status code. 
        - To support idempotency, we can use the database's unique key constraint.

- India
    - TN
        -  is probably top urbanized state in India (more than 60%)
        - % share of Agriculture could be 8%

- Investing
    - John Bogle's recommendation for portfolio, 
    - 95% - Core allocation - Equity, Debt ...
    - 5% - Funny money, trading 
    - Howard marks on Investing 
        - Market has become Efficient compared to 60 years back
        - Access to data, live feeds have enabled many people to become smart at investing
        - Emotion is the greatest enemy of superior investing. 
        - In 2022, readily available quantitative information about the present cannot be the road to superior performance, most people, they should invest through others. Whether it’s an index fund, an ETF, or an actively managed account. We don’t do our own legal work, dental work, medical work, we don’t fix our own cars. Why should we manage our own money? Why should we believe that we have the ability as part-timers to do that? So the amateur should basically pick funds and managers, in my opinions.you want to go into a global fund that includes China under their charter. 

- Payments industry 
    - The process by which a business discerns that some money has the colour of revenue is called revenue recognition.

- CBDC (Central bank Digital Currency)
    - Database maintained by Central Bank 
    - Like cash, it would not earn any interest
    - only way to have account with RBI
    - Crypto is de-centralized (so to say), CBDC is not 
    - It can be programmed for restricted use like destination bound (as food coupons),or being time bound etc.
    - Dollar reserves of RBI - Only onshore US banks can have these dollars and not RBI. Every central bank has account with one of these banks. US is aware of all international transactions happening in Dollars. 
    - CBDC can potentially be used as alternative to USD with RBI acting as banker. India is Well placed for this because it has consistent current account deficit.

- Tech 
    - Consistent Hashing - Used to distribute requests/data efficiently and evenly across servers. One way to distribute hash keys across servers in a range. Lets say, given SHA-1 algorithm for hashing, we find out min (i.e. 0) and max of this algorithm and then allocate keys across servers in this range.

## 2022-Mar-23 Wed

- What is Observability?
    - Observability means gaining visibility into the internal state of a system. It’s used to give users the tools to figure out what’s happening, where it’s happening, and why. At Cloudflare, we believe that observability has three core components: monitoring, analytics, and forensics. Monitoring measures the health of a system - it tells you when something is going wrong. Analytics give you the tools to visualize data to identify patterns and insights. Forensics helps you answer very specific questions about an event.

- Human Psychology
    - Uncertainty is the root of all progress and all growth. As the old adage goes, the man who believes he knows everything learns nothing
    - Work expands so as to fill up the time available for its completion

- Joel Greenblatt's wisdom
    - 1. Understand incentives -Companies are run by people. Understand how the top management is being motivated.  Out of their total package, how much compensation is fixed and variable? Do they see their companies as their life's work or just another "job"?
    2. Don't sell too early - If a company is performing well and its valuation is sensible, never sell it. (I'll probably sell a bit to feel good, but I'll keep the bulk.)We have our blind spots. Overcome it by sharing our thesis with others and listening to feedback.
    3. The hard part - focusing on easy companies  - Simplicity is key. Invest in what we can understand well so we can succeed. In investing, it's about the returns we can generate -- not how complex our ideas are.
    4. Control our emotions and do proper valuation work.= Take control of our emotions when we're investing. Don't take the shortcut, do proper work on valuations. Valuation work acts as an anchor during volatile markets.
    5.  Focus on normalised earnings When Wall Street is short-sighted, it is easy to outperform just by being a long term investor. Focus on the bigger picture.If a high-quality business is facing short term challenges that are not fatal, give it a break. Stay vested.
    6. Less leverage the better - we could be right in our analysis but short-term prices may disagree -- causing temporary negative losses.  If we're leveraged up, we may potentially suffer from a margin call before we're proven right.
    7. Mr Market will eventually get it right = In the short term, the stock market is terrible at valuing businesses.  That is your opportunity. But in the long term, if your company is worth its weight, it will be reflected in its share price. 

- US Taxation
    -  if you buy stocks in your 401(k) tax-advantaged retirement account, and you sell them to buy other stocks in the 401(k), you don’t pay taxes; a 401(k) defers taxes until you take money out at retirement.
    - if you buy shares in a mutual fund, and they go up, and you don’t sell, you might have to pay taxes anyway. A mutual fund pools your money with many other people’s money and buys a bunch of stocks for all of you. And if the mutual fund sells stocks, it incurs capital gains taxes, which it passes on to its holders. Roughly speaking what this means is that if you invest in a mutual fund, and it goes up, and you don’t sell, but other investors in the mutual fund do sell, then you have to pay taxes. (As do they.) One reason people like to invest in exchange- traded funds is that this rule is weird and the ETF business has found ways to avoid it.

-  a cyclical is a company that will prosper in good times and suffer in bad. That's because it makes or sells expensive products or luxury items that customers can put off buying when they are short on cash. People continue to buy deodorant, dental floss, Big Macs, and headache pills no matter what, which is why drugstores and fast-food restaurants are not cyclicals.
- The best time to get involved with cyclicals is when the economy is at its weakest, earnings are at their lowest, and public sentiment is at its bleakest.

- Peter lynch's stock criteria,
    - Relatively debt free
    - beaten down in market
    - selling for less than cash in their bank accounts
    - If it's a choice between investing in a good company in a great industry, or a great company in a lousy industry, I'll take the great company in the lousy industry any day. Good management, a strong balance sheet, and a sensible plan of action will overcome many obstacles, but when you've got weak management, a weak balance sheet, and a misguided plan of action, the greatest industry in the world won't bail you out
    
## 2022-Mar-24 Thu

- Tech
    - Directed acyclic graph (DAG) programming model, which defines tasks in stages so they can be executed sequentially or parallely.

- Perspectives on Software Development,
    1.	Don’t fight the tools: libraries, language, platform, etc. Use as much native constructs as possible. Don’t bend the technology, but don’t bend the problem either. Pick the right tool for the job or you’ll have to find the right job for the tool you got.
    2.	You don’t write the code for the machines, you write it for your colleagues and your future self (unless it’s a throw away project or you’re writing assembly). Write it for the junior ones as a reference.
    3.	Any significant and rewarding piece of software is the result of collaboration. Communicate effectively and collaborate openly. Trust others and earn their trust. Respect people more than code. Lead by example. Convert your followers to leaders.
    4.	Divide and conquer. Write isolated modules with separate concerns which are loosely coupled. Test each part separately and together. Keep the tests close to reality but test the edge cases too.
    5.	Deprecate yourself. Don’t be the go-to person for the code. Optimize it for people to find their way fixing bugs and adding features to the code. Free yourself to move on to the next project/company. Don’t own the code or you’ll never grow beyond that.
    6.	Security comes in layers: each layer needs to be assessed individually but also in relation to the whole. Risk is a business decision and has direct relation to vulnerability and probability. Each product/organization has a different risk appetite (the risk they are willing to take for a bigger win). Often these 3 concerns fight with each other: UX, Security, Performance.
    7.	Realize that every code has a life cycle and will die. Sometimes it dies in its infancy before seeing the light of production. Be OK with letting go. Know the difference between 4 categories of features and where to put your time and energy: Core: like an engine in a car. The product is meaningless without it. Necessary: like a car’s spare wheel. It’s rarely used but when needed, its function decides the success of the system. Added value: like a car’s cup-holder. It’s nice to have but the product is perfectly usable without it. Unique Selling Point: the main reason people should buy your product instead of your rivals. For example, your car is the best off-road vehicle.
    8.	Don’t attach your identity to your code. Don’t attach anyone’s identity to their code. Realize that people are separate from the artifacts they produce. Don’t take code criticism personally but be very careful when criticizing others’ code.
    9.	Tech debt is like fast food. Occasionally it’s acceptable but if you get used to it, it’ll kill the product faster than you think (and in a painful way).
    10.	When making decisions about the solution all things equal, go for this priority:
    **Security > Reliability > Usability (Accessibility & UX) > Maintainability > Simplicity (Developer experience/DX) > Brevity (code length) > Finance > Performance**
    But don’t follow that blindly because it is dependent on the nature of the product. Like any career, the more experience you earn, the more you can find the right balance for each given situation. For example, when designing a game engine, performance has the highest priority, but when creating a banking app, security is the most important factor.
    11.	Bugs’ genitals are called copy & paste. That’s how they reproduce. Always read what you copy, always audit what you import. Bugs take shelter in complexity. “Magic” is fine in my dependency but not in my code.
    12.	Don’t only write code for the happy scenario. Write good errors that answer why it happened, how it was detected and what can be done to resolve it. Validate all system input (including user input): fail early but recover from errors whenever possible. Assume the user hold a gun: put enough effort into your errors to convince them to shoot something other than your head!
    13.	Don’t use dependencies unless the cost of importing, maintaining, dealing with their edge cases/bugs and refactoring when they don’t satisfy the needs is significantly less than the code that you own.
    14.	Stay clear from hype-driven development. But learn all you can. Always have pet projects.
    15.	Get out of your comfort zone. Learn every day. Teach what you learn. If you’re the master, you’re not learning. Expose yourself to other languages, technologies, culture and stay curious.
    16.	Good code doesn’t need documentation, great code is well documented so that anyone who hasn’t been part of the evolution, trial & error process and requirements that led to the current status can be productive with it. An undocumented feature is a non-existing feature. A non-existing feature shouldn’t have code.
    17.	Avoid overriding, inheritance and implicit smartness as much as possible. Write pure functions. They are easier to test and reason about. Any function that’s not pure should be a class. Any code construct that has a different function, should have a different name.
    18.	Never start coding (making a solution) unless you fully understand the problem. It’s very normal to spend more time listening and reading than typing code. Understand the domain before starting to code. A problem is like a maze. You need to progressively go through the code-test-improve cycle and explore the problem space till you reach the end.
    19.	Don’t solve a problem that doesn’t exist. Don’t do speculative programming. Only make the code extensible if it is a validated assumption that it’ll be extended. Chances are by the time it gets extended, the problem definition looks different from when you wrote the code. Don’t overengineer: focus on solving the problem at hand and an effective solution implemented in an efficient manner.
    20.	Software is more fun when it’s made together. Build a sustainable community. Listen. Inspire. Learn. Share.

## 2022-Mar-28 Mon

- Behavioural Psychology 
    - absolute freedom, by itself, means nothing.
    - Travel is a fantastic self development tool, because it extricates you from the values of your culture and shows you that another society can live with entirely different values and still function and not hate themselves
    - Appearances and salesmanship became more advantageous forms of expression in a society where there existed an abundance of economic opportunity
    - There is such pressure in the West to be likable that people often reconfigure their entire personality depending on the person they’re dealing with.
    - Rejection makes your life better. if we reject nothing (perhaps in fear of being rejected by something ourselves), we essentially have no identity at all.
    - The desire to avoid rejection at all costs, to avoid confrontation and conflict, the desire to attempt to accept everything equally and to make everything cohere and harmonize, is a deep and subtle form of entitlement
    - Healthy love is based on two people acknowledging and addressing their own problems with each other’s support.
    - People in a healthy relationship with strong boundaries will take responsibility for their own values and problems and not take responsibility for their partner’s values and problems.
    - Entitled people expect other people to take responsibility of their problem or they take too much responsibility for other people's problems.
    - The setting of proper boundaries doesn’t mean you can’t help or support your partner or be helped and supported yourself. You both should support each other. But only because you choose to support and be supported. Not because you feel obligated or entitled.
    - People with strong boundaries are not afraid of a temper tantrum, an argument, or getting hurt.People with weak boundaries are terrified of those things and will constantly mold their own behavior to fit the highs and lows of their relational emotional roller coaster
    - People with strong boundaries, 
        - It’s unreasonable to expect two people to accommodate each other 100 percent and fulfill every need the other has.
        - They may hurt someone’s feelings sometimes, but ultimately they can’t determine how other people feel.
        - A healthy relationship is not about controlling one another’s emotions, but rather about each partner supporting the other in their individual growth and in solving their own problems.
    - When we’re overloaded with opportunities and options, we suffer from what psychologists refer to as the paradox of choice. Basically, the more options we’re given, the less satisfied we become with whatever we choose, because we’re aware of all the other options we’re potentially forfeiting.

- Stock Markets
    - Peter Lynch on Stock Markets "Some event will come out of left field, and the market will go down, or the market will go up. Volatility will occur. Markets will continue to have these ups and downs. … Basic corporate profits have grown about 8% a year historically. So, corporate profits double about every nine years. The stock market ought to double about every nine years. So I think — the market is about 3,800 today, or 3,700 — I'm pretty convinced the next 3,800 points will be up; it won't be down. The next 500 points, the next 600 points — I don’t know which way they’ll go. So, the market ought to double in the next eight or nine years. They’ll double again in eight or nine years after that. Because profits go up 8% a year, and stocks will follow. That's all there is to it."

## 2022-Mar-29 Tue

- Energy
    - Synthesis of the ammonia needed to produce nitrogenous fertilizers now depends heavily on natural gas as the source of hydrogen
    - There could be no natural gas–powered flight, as the energy density of methane is three orders of magnitude lower than that of aviation kerosene, and also no coal-powered flight—the density difference is not that large, but coal would not flow from wing tanks to engines.
    - Crude oil needs refining to separate the complex mixture of hydrocarbons into specific fuels—gasoline being the lightest; residual fuel oil the heaviest.

## 2022-Mar-30 Wed

- Investing#REIT
    - Exist in developed markets since long time
    - ~ 6% p.a. can be expected 
    - Taxation
        - Dividends are tax free
        - Interest paid is taxable at slab rate
        - Selling units attracts Capital Gains tax

- Software 
    - monomorphized - Multiple implementations of same function but with different input data types.
    - Generics in Go -  passing interfaces to a generic function in Go is never a good idea

- Nuclear weapons, Ability to deploy and yield are important parameters 
    - Tactical- Maint to be used in battle. 
    - Strategic - More as a deterrent. they are Weapons of mass destruction

- Electricity/Energy
    -  it is still impossible to store electricity affordably in quantities sufficient to meet the demand of a medium-sized city (500,000 people) for only a week or two, or to supply a megacity (more than 10 million people) for just half a day.
    - Electricity is the best form of energy for lighting: it has no competitor on any scale of private or public illumination, and very few innovations have produced such an impact on modern civilization as has the ability to remove the limits of daylight and to illuminate the night.
    -  A nuclear renaissance would be particularly helpful if we cannot develop better ways of large-scale electricity storage soon. 
    - modern nuclear reactors, if properly built and carefully run, offer safe, long lasting, and highly reliable ways of electricity generation; as already noted, they are able to operate more than 90 percent of the time, and their lifespan can exceed 40 years.
    -  batteries, compressed air, and supercapacitors, still have capacities orders of magnitude lower than needed by large cities, even for a single day’s worth of storage.
    - Nitrogen is needed in such great quantities because it is in every living cell: it is in chlorophyll, whose excitation powers photosynthesis; in the nucleic acids DNA and RNA, which store and process all genetic information; and in amino acids, which make up all theproteins required for the growth and maintenance of our tissues.The element is abundan —it makes up nearly 80 percent of the atmosphere, organisms live submerged in it—and yet it is a key limiting factor in crop productivity as well as in human growth. This is one of the great paradoxical realities of the biosphere and its explanation is simple: nitrogen exists in the atmosphere as a non-reactive molecule (N2), and only a few natural processes can split the bond between the two nitrogen atoms and make the element available to form reactive compounds.
    -  Old way to enrich soil with  nitrogen stores was to collect and apply human and animal wastes

## 2022-apr-04 Mon

- MySQL Replication 
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
            - reading from slaves helps in resilience (when master is down or loaded)
    - How to monitor lag - Either Pg_heartbeat from percona toolkit or "second behind master" from "show slave status"

- World Finance (New Monitory Regime)
    - Russia had no treasury securities and no onshore US dollar exposure, has no banking presense in US
    - Eurodollars - Stateless money, its no one's liability
    - Bretton woods 3 
        - Bretton Woods 1 - US Dollars recognized as World's reserve currency
        - Bretton Woods 2 was formal recognition of trade between US and china where china exports to US and earns dollars and invest those in treasuries.
        - Way of exporting to US and earning dollars is no more going to work smoothly.

- SQLite - Litestream - How it works 
    -  In WAL-mode (the mode you very much want on a server, as it means writers do not block readers), SQLite appends to a WAL file and then periodically folds its contents back into the main database file as part of a checkpoint. Litestream interposes itself in this process: it grabs a lock so that no other process can checkpoint. It then watches the WAL file and streams the appended blocks up to S3, periodically checkpointing the database for you when it has the necessary segments uploaded.

- Lee Kuan Yew (LKY) of Singapore 
	- relentless determination to follow the facts where they lead
	-  a pattern of initial tight control, caution, and centralized planning, followed by a slow move towards a freer economy as long as everything seemed to be working 
    - insist that state-run corporations stay in the black or shut down. As they succeeded, they privatized--telecommunications, the port, and public utilities all started within the government and became independent profitabable companies over time
	- We noted by the 1970s that when governments undertook primary responsibility for the basic duties of the head of a family, the drive in people weakened. Welfare undermined self-reliance. People did not have to work for their families' well-being. The handout became a way of life. The downward spiral was relentless as motivation and productivity went down. People lost the drive to achieve because they paid too.much in taxes. They became dependent on the state for their basic needs.
	- constant tinkering and fine-tuning around incentive systems is core to LKY's planning.
	- Taxation in Singapore 
		- Top Tax rate is 22%
		- Corporate tax rate is 17%
		- No capital gains tax
		- 7% GST 
		- No duty on imports
		- no inheritance/estate tax
	-  The freedom of the press was the freedom of its owners to advance their personal and class interests.
	-  the Asian Wall Street Journal (AWSJ) published an alleged defamatory article and had sales restricted, the AWSJ offered to distribute its journal free to its deprived subscribers to "forego its sales revenue in the spirit of helping Singapore businessmen". Singapore's government agreed, as long as it left out advertisements. The paper backed out, claiming cost issues. Singapore offered to cover half the additional costs. When the paper refused, Singapore gave an official response: "You are not interested in the business community getting information. You want the freedom to make money selling advertisements."
	- 75 percent of Singaporeans are Chinese.
	- On Minority communities, 
		- Every solution on the table, go for the most direct and efficient way to achieve a goal, push forward regardless of decorum.More compelling was his emphasis on working with and through minority government members each time he worked with minority communities.
         -  From experience, we knew that govt. officials could not reach out to minority parents and students in the way their own community leaders did. The respect these leaders enjoyed and their sincere interest in the welfare of the less successful persuaded parents and children to make the effort. Paid bureaucrats could never have the same commitment, zest, and rapport to move parents and their children. ...On such personal-emotional issues involving ethnic and family pride, only leaders of the wider ethnic family can reach out to the parents and their children.
		-  LKY's approach blends traditional, family values and blunt realism easy to associate with the right with a determination to work with affected minorities and concern for their welfare that pattern-matches more clearly to the left. That mixture of familiarity and foreignness in his approach, and that tension between traditional and progressive values, is one reason this work was so refreshing for me, coming from a US background.
	- Education and birthrate typically have an inverse correlation.
		-  Provide preferential school selection for children of graduate mothers who have at least three kids.
		- Establish a government matchmaking system to "facilitate socializing between men and women graduates"
	- pay for performance over time on job.
	- On Trade Unions
		- Strict laws and tough talk alone could not have achieved this. It was our overall policy that convinced our workers and union leaders... but ultimately it was the trust and confidence they had in me, gained over long years of association, that helped transform industrial relations from one of militancy and confrontation to cooperation and partnership. 
        - The key to peace and harmony in society is a sense of fair play, that everyone has a share in the fruits of our progress
	- "Singapore will remain clean and honest only if honest and able men are willing to fight elections and assume office. They must be paid a wage commensurate with that men of their ability and integrity are earning for managing a big corporation or a sucessful legal or other professional practice 
    - Basic Principles, 
		- social cohesion through sharing the benefits of progress,
		- equal opportunities for all, and meritocracy, with the best man or woman for the job, especially as leaders in government.


- Life lessons, 

	- Sometimes getting what you want is as simple as asking for it. Closed mouths don’t get fed.

	- Talk to strangers—in the grocery store, at the airport, in line at the DMV—you'll meet cool people, have great stories to tell, and maybe even make a lonely person's day.

	- It's cheap and easy to keep your home neat and clean. The positive mental benefits are enormous.

	- On that note, cleaning is easy when you do it often. Wiping up a recent spill takes two seconds. Scraping dried spaghetti sauce from the counter takes too long.

	- No coffee after noon and no alcohol at least four hours before bed improves sleep dramatically.

	- Drink more water. 

	- Publish content online. It's a creative outlet. It's fun to watch your work improve. It's a magnet for interesting people you’d otherwise never meet.

	- Money spent on books is money well spent. Even if you only read some, you're getting more knowledge and entertainment than you're paying for.

	- Spend more time working on mobility. You'll have fewer injuries. You'll feel better. As you get older, you'll maintain a higher quality of life for longer.

	- Get comfortable sitting alone in silence. It’s something you'll need to practice. Put away your phone, pour a cup of coffee, and sit in a quiet place. Turn off the radio on your next long car ride. Allow yourself to be alone with your thoughts.

	- Have more patience, especially with your parents. If anyone deserves your patience, it's the people who had to live with you during your most annoying years.

	- Spend long weekends with good friends. Living together—even for a few days—deepens bonds and strengthens friendships. Life gets busy, and it's easy to not do this, but the dividends the relationship will pay throughout your life is worth the small time investment now.

	- Make a habit of forming habits. They are the building blocks of the person you want to become. The best way to build a habit is to start smaller than you think you can accomplish, then work up.

	- Bring your lunch to work, especially in your 20s. The compound interest lost from the money you spent on lunch is a terrible waste.

	- Early in your career you should optimize for one of three things: making a lot of money, building a marketable skill, or doing something you love. My preference is for the first. If you make a lot of money and invest it wisely, you'll be able to pursue your passions while you're still young—without having to worry about finances.

	- Write handwritten thank you notes. It takes five minutes and means a lot to the recipients, especially if they’re older.

	- When it comes to clothing, fit is more important than fashion. A $10 t-shirt that fits you perfectly looks better than a $90 dress shirt that's baggy and loose in the arms.

	- When you're planning anything, take the amount of time you think you’ll need and double it. Tasks usually take longer than you expect, and it's good to build in a buffer. Underpromise and overdeliver, even if it's just for yourself.

	- There's value in sticking with one job for a long period of time—you'll get really good at it, your confidence will increase, you'll become specialized which is rewarded financially if it's in the right area. But there's also value in jumping around—bigger salary increases, bigger network, potentially broader base of skills, more unique experiences. Neither way is wrong, you just have to be clear with yourself about what you want.

	- Setting reasonable expectations is a superpower. If you consistently underpromise and over deliver, people will always be happy with you.

	- On the other side, never agree to something you're not positive you can do. People generally don't care if you say no in the first place. They'll get really mad if you say yes and then let them down.

	- Your possessions increase to fill the amount of space you have. And possessions tend to be more burdensome than liberating. Before moving to a larger space, think about it deliberately. With each additional possession you purchase, ask yourself, “do I really need this thing?”

	- One of the biggest wins in life is finding the things you REALLY care about, and then only focusing on those things. This won’t be easy at first, but if you filter all your decisions through the question, "Does this get me closer to or further from the things I REALLY care about?" you'll continuously move your life in a direction that makes you happy. Auditing the decisions you make, and ensuring they're aligned with the things that bring you the most joy, is one of the most important habits you can build. Do I really care about driving this car that costs me $600/month? No, I'd be happy with a car that costs $200/month. But I do really care about this family vacation every year, and reducing my car payment by $400/month helps me pay for the vacation.

	- Do I really care about watching this thing I'm watching on TV right now? No, I wouldn't care at all if I missed it. But I do really care about getting better at playing the guitar. Cutting out the hour of TV I watch every night makes more room for guitar practice. 

	= Marriage is for making things work. Dating is for finding the best person to make things work with. When you break up, break up. Don’t stay friends. Don’t take a break. Move on. Delete their social media. Block their number. Forget about them. It hurts at first and it’s easier to drag things out, but you’ll feel better faster if you don’t.

	- People will use jargon and complicated language to make you think they're smart. But the smartest people you'll ever meet will speak so simply that you’ll underestimate their intelligence. This is because it takes an immense amount of intelligence and mastery to explain complicated topics in a simple way. If you don't have this level of mastery, you can either admit it (most people won't) or you can confuse people with big words and complicated phrases until they stop asking questions. 

	- When you meet a jargon junkie, you can expose them by persistently asking simple questions and maintaining your composure. But the more mature you become, the less likely you’ll be to do this. Instead, you’ll start to feel bad for these people.

	- Relatedly, the most insecure people you meet will often be the loudest. Confident people don't need to draw attention to themselves. Insecure people do. They are compensating for a lack of confidence or competence. It's meant to be a distraction so people don't "find them out."

	- The biggest difference between this observation and #25 is intelligence level. This tactic will more often be used by people with lesser education or lower intelligence. The previous tactic will be used by people with higher education or intelligence. 

	- Cell phones are best used resourcefully, not reflexively.

	- Pull out your cell phone when you have a specific task to complete—you need directions, you have to make a call, you want to listen to music—not when you have time to kill. 

	- My experience with cell phone scrolling is that it results in two things: dissatisfaction and anxiety. People say you never regret a workout, well, the opposite is true with a scroll session: you always regret it.

	- Avoid complainers at all costs.

	- Complaining is more contagious than COVID, and it's more deadly.

		Being a complainer means you always find the bad in a situation rather than the good. You often find an excuse rather than a solution. And your overall mood and wellbeing will suffer.

		Being around complainers makes you more likely to complain. It kills morale and productivity in teams. It limits your potential.

		As a manager, do not tolerate complaining on your team. As a parent, don't complain in front of your children, and respond to their complaints with the positive side of the situation. As an adult, be direct with your friends and family members. Tell them you don't tolerate complaining. The sooner you eliminate it from your life, the happier and more successful you will be.

		When people perpetually have "bad luck," it's usually not bad luck. It's the result of their perpetually poor decisions. Identify these people and avoid them.

		- One heuristic to tell how good someone is at making decisions is by how much time they have. The busiest people are often the ones who make the worst decisions. Busy people spend a lot of time correcting poor decisions. And because they’re so busy correcting past decisions, they don’t have time to make good decisions. - Shane Parrish

	- The best time to do everything was ten years ago—investing, exercising, learning a new skill, etc. Talk with older people you respect and ask what they wish they had started doing in their 20s, then start doing that thing immediately. It's rarely too late, but it's always better to start sooner rather than later.

	W- aking up naturally, without an alarm, is a great feeling. Creating a consistent routine is one way to do this. Freeing yourself from work obligations is another. I recommend pursuing both. 

	- You have to take calculated financial risks to see large increases in your net worth. I bought and sold investment properties leading to about a 15% increase in my net worth. I bought crypto which also increased my net worth by about 15%. I started a company that never made money and cost me about 6% of my net worth. Two wins and one loss, but the wins significantly outweighed the loss. The key is calculated risks. In each of the above ventures, I knew my absolute worst case scenario—my downside was capped. I also predicted potential upside in each case and determined the potential upside outweighed the potential downside. You won't be right every time, but if you take calculated risks, you should be right more often than you're wrong.

	- Think about starting a lot of businesses. You won’t follow through on most of them, but the act of thinking through a big idea is a special type of exercise most people don't do often (or ever).

	- One of the biggest secrets of fitness is avoiding injury. If you're healthy, you can exercise consistently. If you can exercise consistently, compounding will do its work. To avoid injury, tame your ego. There's rarely any reason to push past 85%, and if you don't, you're less likely to get injured.

	- Seek advice from everyone, but filter it to fit your life. The purpose of asking for advice is to gain as much perspective as possible then make your own decision with that perspective, not to get someone else to make your decision for you.

	- Good enough and done is better than perfect but imagined. 

	- So much of the technology we lose our patience with today would've looked like magic ten years ago. Remember this when your phone is taking too long to play a YouTube video while you’re sitting on the beach.

	- If you're constantly busy, you have underlying issues to address.

	- If someone is bothering you, it's your fault until you've told them.

	- If you aren't absolutely thrilled to watch it, turn off the TV and pick up a book instead. 

	- Get on the dance floor at every wedding. Nobody cares if you're bad at dancing. They're too concerned about how bad they are. Plus, the more people on the dance floor, the more fun the wedding. Consider it your gift to the newlyweds. 

	- Set rules for yourself. They make life better 95% of the time. Then break them 5% of the time.

	- Spend less time checking boxes and more time building relationships. Checking boxes brings a certain level of success, but relationships bring fulfillment and opportunity you'll never find on your own.

	- Buy a nice suit in your 20s and never let yourself outgrow it.

	- Pick one or two hobbies you love and spend time getting better at them. Seeing yourself progress through deliberate practice is a confidence builder and a satisfaction booster.

	- Spend enough time alone that you're comfortable doing it. Enjoying your own company is a wonderful gift to give yourself. 

- During times of abundance, worldviews don’t get tested very strongly and people are shielded from the consequences of being inaccurate. It’s during the times of scarcity that reality reasserts itself and filters out the workable from the unworkable worldviews.


## 2022-apr-06 Wed

- Processed food - A lack of taste memory is one reason why Coca-Cola is such a profitable business. The recipe is engineered to not come with a taste memory, which is why the drink is so addicting. Cheetos are similar. According to the food scientist Steven Witherly, they bring so much pleasure because of the way each puff melts in your mouth. The way the food melts in the mouth is known as “vanishing caloric density,” which makes your brain think there are no calories in the food, which is why you can eat them for so long.

- Parameters for Evaluation of decision/strategy, 
    - Technical ease 
    - Short term impact
    - Long term impact
    - Capital ease
    - Ease of Organizational support 
    - Ease of Scaling

- World's dependence on Fossil fuels, 
    - our food supply—be it staple grains, clucking birds, favorite vegetables, or seafood praised for its nutritious quality—has become increasingly dependent on fossil fuels.
    - Eating meat has been as significant a component of our evolutionary heritage as our large brains (which evolved partly because of meat eating), bipedalism, and symbolic language.
    - Four indespensible materials to modern civilization - cement, steel, plastics, and ammonia.
    - claims about 17 percent of the world’s primary energy supply, and 25 percent of all CO2 emissions originating in the combustion of fossil fuels—and currently there are no commercially available and readily deployable mass-scale alternatives to displace these established processes
    - Ammonia is used as dominant nitrogen fertilizer.Ammonia is a simple inorganic compound of one nitrogen and three hydrogens (NH3), which means that nitrogen makes up 82 percent of its mass.Nitrates are also used to produce explosives.natural gas is used as the source of hydrogen, and  efficient centrifugal compressors and better catalysts are used in process to produce ammonia. synthetic nitrogen feeds half of humanity—or, everything else being equal, half of the world’s population could not be sustained without synthetic nitrogenous fertilizers.About 80 percent of global ammonia production is used to fertilize crops; the rest is used to make nitric acid, explosives, rocket propellants, dyes, fibers, and window and floor cleaners.

- Power stocks, 
    - if you’re buying power stocks at p/b of 3x you deserve to lose money. NTPC was 3x in 2011, thereafter it was flat for a decade excl. dividend. power stocks can’t earn more than cost of capital, so better to buy them at book or below book value. or not buy them at all.


- Four indispensable materials to modern civilization - cement, steel, plastics, and ammonia.
    - Steel - Modern steels are made from cast iron by reducing its high carbon content to 0.08–2.1 percent by weight.Steel’s typical tensile strength is about seven times that of aluminum and nearly four times that of copper; its hardness is, respectively, four and eight times higher; and it is heat resistant—aluminum melts at 660oC, copper at 1,085oC, steel only at 1,425oC. Iron is the Earth’s dominant element by mass because it is heavy (nearly eight times as heavy as water) and because it forms the planet’s core. But it is also abundant in the Earth’s crust: only three elements (oxygen, silicon, and aluminum) are more common; iron, with nearly 6 percent, ranks fourth.    
        - Steel manufacturing process -  The process starts with blast furnaces (tall iron and steel structures lined with heat-resistant materials) that produce liquid (cast or pig) iron by smelting iron ore, coke, and limestone.74 The second step—reducing cast iron’s high carbon content and producing steel—takes place in a BOF (basic oxygen furnace; the adjective refers to the chemical properties of the produced slag). 

    - Plastic - Plastics are a large group of synthetic (or semisynthetic) organic materials whose commonquality is that they are fit for forming (molding). The malleability of plastics makes it possible to form them by casting, pressing, or extruding, and they create shapes ranging from thin film to heavy-duty pipes and from feather-light bottles to massive and sturdy waste containers. Global output has been dominated by thermoplastics—polymers that soften readily when heated and harden again when cooled. 
    
    - Cement - Cement is the indispensable component of concrete, and it is produced by heating (to at least 1,450oC) ground limestone (a source of calcium) and clay, shale, or waste materials (sources of silicon, aluminum, and iron) in large kilns—long (100–220 meters) inclined metal cylinders.79 This high-temperature sintering produces clinker (fused limestone and aluminosilicates) that is ground to yield fine, powdery cement. 

    - A typical lithium car battery weighing about 450 kilograms contains about 11 kilograms of lithium, nearly 14 kilograms of cobalt, 27 kilograms of nickel, more than 40 kilograms of copper, and 50 kilograms of graphite—as well as about 181 kilograms of steel, aluminum, and plastics. Supplying these materials for a single vehicle requires processing about 40 tons of ores, and given the low concentration of many elements in their ores it necessitates extracting and processing about 225 tons of raw materials. 
    
- Equity Investments 
    - Direct indexing, investors own a benchmark’s underlying shares. That is, while index-fund owners possess one investment, those who index directly typically hold dozens or even hundreds of securities, depending upon whether they fully replicate an index, or only sample it. 

- Tech 
    - Approach to migration from one to another cloud
        - Set up haproxy, nginx or similar as reverse proxy and carefully decide if you can handle retries on failed queries. If you want true zero-downtime migration there's a challenge here in making sure you have a setup that lets you add and remove backends transparently. There are many ways of doing this of various complexity. I've tended to favour using dynamic dns updates for this; in this specific instance we used Hashicorp's Consul to keep dns updated w/services. I've also used ngx_mruby for instances where I needed more complex backend selection (allows writing Ruby code to execute within nginx)

        - Set up a VPN (or more depending on your networking setup) between the locations so that the reverse proxy can reach backends in both/all locations, and so that the backends can reach databases both places.

      - Replicate the database to the new location.

        - Ensure your app has a mechanism for determining which database to use as the master. Just as for the reverse proxy we used Consul to select. All backends would switch on promoting a replica to master.

        - Ensure you have a fast method to promote a database replica to a master. You don't want to be in a situation of having to fiddle with this. We had fully automated scripts to do the failover.

        - Ensure your app gracefully handles database failure of whatever it thinks the current master is. This is the trickiest bit in some cases, as you either need to make sure updates are idempotent, or you need to make sure updates during the switchover either reliably fail or reliably succeed. In the case I mentioned we were able to safely retry requests, but in many cases it'll be safer to just punt on true zero downtime migration assuming your setup can handle promotion of the new master fast enough (in our case the promotion of the new Postgres master took literally a couple of seconds, during which any failing updates would just translate to some page loads being slow as they retried, but if we hadn't been able to retry it'd have meant a few seconds downtime).

        - Once you have the new environment running and capable of handling requests (but using the database in the old environment):

        - Reduce DNS record TTL.

        - Ensure the new backends are added to the reverse proxy. You should start seeing requests flow through the new backends and can verify error rates aren't increasing. This should be quick to undo if you see errors.

        - Update DNS to add the new environment reverse proxy. You should start seeing requests hit the new reverse proxy, and some of it should flow through the new backends. Wait to see if any issues.

        - Promote the replica in the new location to master and verify everything still works. Ensure whatever replication you need from the new master works. You should now see all database requests hitting the new master.

        - Drain connections from the old backends (remove them from the pool, but leave them running until they're not handling any requests). You should now have all traffic past the reverse proxy going via the new environment.

        - Update DNS to remove the old environment reverse proxy. Wait for all traffic to stop hitting the old reverse proxy.

        - When you're confident everything is fine, you can disable the old environment and bring DNS TTL back up.

