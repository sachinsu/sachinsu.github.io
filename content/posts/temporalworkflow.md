---
title: "Using Temporal.io to build Long running Workflows"
date: 2020-12-07T08:25:04+05:30
draft: false
tags: [Go, Golang, MicroServices,MySQL, Cassandra, Uber, Cadence,temporal.io]
---

## Background

In a typical business Application, there are often requirements for, 
* Batch processing - Often long running Tasks like data import/export, End of day processing etc. These tasks are often scheduled to be executed at pre-defined interval or on occurance of an Event.
*  Asychronous processing - Tasks, often part of business process / workflow, that can be performed asychronously or offloaded.

Such requirements are often fulfilled with custom approaches like batch processing frameworks, ETL Tools or using Queues or specific database features.

I had been following how Uber fulfils these requirements using their [Cadence](https://cadenceworkflow.io/) platform. Cadence (now [Temporal](https://temporal.io))  is a distributed, scalable, durable, and highly available orchestration engine to execute asynchronous long-running business logic in a scalable and resilient way.

Temporal defines [workflow](https://softwareengineeringdaily.com/wp-content/uploads/2020/04/SED1043-Cadence-Workflow-Orchestration.pdf) as any program which,
* goes beyond single request-reply
* has multiple steps tied together with inherent state
* can be short or long lived.
* performs Event processing
* involves infrastructure automation

This is interesting perspective that accomodates various use cases irrespective of architecture style (i.e. Monolith, Microservices) in use. In Temporal, one has to create workflow which in turn consists of one or more activities. Activities are functions containing actions to be taken on each step of the workflow. Temporal transparently preserves all the state associated with workflow and its activities.

Below is System architecture of Temporal, more details [here](https://docs.temporal.io/docs/system-architecture/), 

    {{< figure src="https://docs.temporal.io/assets/images/system-architecture-d064cede0c97fc4a86defdc1c9fd020c.png" title="Temporal Architecture" >}}

Overall, Temporal offers following features, 
 * Workflow implemented as Application code - Basically it allows to implement Workflow as code, just like rest of the codebase of the application. Thus allowing one to concentrate on business logic and reduces complexity about authoring workflow as DSL, JSON etc.
* Retries and Timeouts - Nowadays, quite a few steps in workflow involve remote service invocation and whenever one crosses boundary of the application, it is important to have retries and timeouts in place.
* Reliability - Robustness against failure
* Scalability - Horizontally Scalable 
* Support for SAGAs - If a Workflow calls multiple external/remote services and if one of them fails then, compensation call to other services will have to be made to complete rollback.
* Distributed Cron - Scheduled processing of workflow or steps in workflow.
* Persistent Storage in MySQL, Cassandra among others
* Frontend for tracking and dignostics
* Monitoring using Prometheus or other backends.

It is very easy to get basic "Helloworld" workflow up and running using detailed instructions on setup provided [here](https://docs.temporal.io/docs/go-sdk-tutorial-prerequisites) provided docker desktop or such environment is easily available. Temporal documentation does a great job on this.

To evaluate Temporal further, we will orchestrate below, 
* List of users are imported/received (say from a file or provided as input)
* These users are verified/validated by Admin through some Frontend (to simulate a maker/checker process).

This may not resemble real world scenario but it will help evaluate features of Temporal like  Signals - Waiting on Events (such as human intervention). 

* We will have below activities in our workflow, 
    * Import users - This activity will import list of users from file/stream. For the sake of similicity, we will just pass it as string.

    ```
    func ImportUsers(ctx context.Context, userdata string, DbConnectionString string) (int, error) {

        logger := activity.GetLogger(ctx)

        logger.Info("ImportUsers activity started.", zap.String("Dbconn", DbConnectionString))

        // Open connection to database
        db, close, err := GetSQLXConnection(context.Background(), DbConnectionString)
        if err != nil {
            logger.Error("Cant open connection to database", zap.Error(err))
            return 0, err
        }

        defer close()

        if _, err := db.Exec(DBSchema); err != nil {
            logger.Error("Error while executing Schema", zap.Error(err))
            return 0, err
        }

        logger.Info("Database connection opened, now parsing user data")

        sqlStmt := "insert into users(name,dob,city) values(?,?,?)"

        tx := db.MustBegin()

        defer func() {
            if err != nil {
                tx.Rollback()
            }
            tx.Commit()
        }()

        r := csv.NewReader(strings.NewReader(string(userdata)))
        r.Comma = ','
        r.Comment = '#'

        records, err := r.ReadAll()
        if err != nil {
            logger.Error("Error while reading", zap.Error(err))
            return 0, err
        }

        i := 0

        for i, record := range records {
            if i == 0 {
                continue
            }

            logger.Info("Record read is ->", record[0])

            if _, err := tx.Exec(sqlStmt, record[0], record[1], record[2]); err != nil {
                logger.Error("Error while writing user record", zap.Error(err))
                return 0, err
            }
        }

        return i, nil
    }

    ```

    * Approve users - This activity will mark all those users, Approved by Admininstrator via Service, as approved.

    ```
    func ApproveUsers(ctx context.Context, DbConnectionString string, Users string) (int, error) {

        logger := activity.GetLogger(ctx)
        logger.Info("ApprovedUsers called", zap.String("Dbconn", DbConnectionString), zap.String("Userlist", Users))

        db, close, err := GetSQLXConnection(context.Background(), DbConnectionString)
        if err != nil {
            logger.Error("Cant open connection to database", zap.Error(err))
            return 0, err
        }

        defer close()

        if _, err := db.Exec(DBSchema); err != nil {
            logger.Error("Error while executing Schema", zap.Error(err))
            return 0, err
        }

        r := csv.NewReader(strings.NewReader(Users))

        tx := db.MustBegin()

        defer func() {
            if err != nil {
                tx.Rollback()
            }
            tx.Commit()
        }()

        sqlStmt := "update users set isapproved =1 where id =:1"

        i := 0

        for {
            record, err := r.Read()
            if err == io.EOF {
                break
            }

            if err != nil {
                logger.Error("Error while reading from file", zap.Error(err))
                return 0, err
            }

            if i == 0 {
                continue
            }
            i++

            if _, err := tx.Exec(sqlStmt, record[0]); err != nil {
                logger.Error("Error while writing user record", zap.Error(err))
                return 0, err

            }
        }
        return i, nil
    }
    ``` 

    * HTTP Service - This service will receive list of approved users and send it over to workflow via Signal,

    ```
        func (s *server) UpdateUsers(w http.ResponseWriter, r *http.Request, ps httprouter.Params) {

            creader := csv.NewReader(r.Body)
            records, err := creader.ReadAll()
            if err != nil {
                log.Fatal(err.Error())
                http.Error(w, err.Error(), http.StatusBadRequest)
                return
            }

            // Create the client object just once per process
            c, err := client.NewClient(client.Options{})
            if err != nil {
                log.Fatalln("unable to create Temporal client", err)
                http.Error(w, "Internal Error :Temporal", http.StatusInternalServerError)
                return
            }
            defer c.Close()

            workflowOptions := client.StartWorkflowOptions{
                ID:        app.UserApprovalWorkflow,
                TaskQueue: app.UserApprovalTaskQueue,
                RetryPolicy: &temporal.RetryPolicy{
                    InitialInterval:    time.Second,
                    BackoffCoefficient: 2.0,
                    MaximumInterval:    time.Minute,
                    MaximumAttempts:    5,
                },
            }

            _, err = c.SignalWithStartWorkflow(r.Context(), app.UserApprovalWorkflow, app.ApprovalSignalName,
                records, workflowOptions, app.OnboardUsers, app.Userdata, s.DBConnection)

            if err != nil {
                log.Fatal(err.Error())
                http.Error(w, "Internal Error: Workflow", http.StatusInternalServerError)
                return
            }

            fmt.Fprint(w, "Success")
    }

    ```

    * HTTP service uses `workflow.SignalWithStartWorkflow` function. This function sends the signal to running instance of workflow or starts new if none is in progress.

Full source code is available [here](https://github.com/sachinsu/temporalevaluation)

Temporal documentation has reference to Helm charts for deploying temporal in clustered configuration, for organization who is managing own data center it would be interesting to know if it also supports bare metal based deployment in addition to Kubernetes. Will update this post as and when details are available on this.

Overall, Temporal provides a different approach to workflow orchestration. Its been battle tested at [Uber](https://uber.com) and host of other companies. Temporal [Community](community.temporal.io) is a very active one with founders actively partcipating in discussions.


- [Collection of Temporal related stuff](https://github.com/firdaus/awesome-cadence-temporal-workflow)

Happy Coding !!

---

{{< comments >}}