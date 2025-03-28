---
title: "Taming Time: Strategies for Out-of-Order and Delayed Processing"
date: 2025-04-01T10:25:04+05:30
draft: true
tags: [asynchronous, background-jobs, queue, message-broker, concurrency, distributed-systems]
---

## Summary 

Explore various approaches to handle out-of-order or delayed processing, addressing scenarios like bulk operations and long-running tasks. Learn about message queues, background workers, and other techniques to improve application responsiveness.


## Introduction 

In the world of software development, we often encounter tasks that don't need to or (should not) be completed immediately. Whether it's sending mass emails, processing large datasets, or handling complex computations. Blocking the user's main flow (Either on Web App or API) for these operations is rarely a good idea. That's where out-of-order or delayed processing comes in.

This post will delve into different strategies for managing these asynchronous tasks, comparing their strengths and weaknesses, and providing practical examples.

### Use Cases

- Bulk Operations: Sending bulk emails, generating reports, or processing large files.
- Long-Running Tasks: Video transcoding, complex calculations, or data analysis.
- Non-Blocking User Interactions: Accepting user requests without waiting for completion, improving responsiveness

### Approaches


1.  **Thread Pools (In-Process Concurrency)**

    * **Description:** Using threads to execute tasks concurrently within the same application process.
    * **Pros:** Simple to implement, low overhead for small tasks.
    * **Cons:** Limited scalability, potential for resource contention, not suitable for distributed systems.
    * **Example (Go):**

    ```go
    package main

    import (
        "fmt"
        "sync"
    )

    func processTask(taskID int) {
        fmt.Printf("Processing task %d\n", taskID)
    }

    func main() {
        tasks := []int{1, 2, 3, 4, 5}
        var wg sync.WaitGroup

        for _, task := range tasks {
            wg.Add(1)
            go func(id int) {
                defer wg.Done()
                processTask(id)
            }(task)
        }

        wg.Wait()
    }
    ```

    * **Example (C#):**

    ```csharp
    using System;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task ProcessTask(int taskID)
        {
            // Console.WriteLine($"Processing task {taskID}");
            await Task.Delay(taskID);
        }

        public static async Task Main(string[] args)
        {
            int[] tasks = { 1, 2, 3, 4, 5 };

            var taskList = new Task[tasks.Length];

            for (int i = 0; i < tasks.Length; i++)
            {
                int taskID = tasks[i];
                taskList[i] = ProcessTask(taskID);
            }

            await Task.WhenAll(taskList);

            Console.WriteLine("All tasks completed.");
        }
    }
    ```


2.  **Background Workers (Dedicated Processes or as a sidekick)**

    * **Description:** Running dedicated processes or services to handle background tasks.
    * **Pros:** Good isolation, scalability, suitable for long-running tasks.
    * **Cons:** Increased complexity, requires process management.
    * **Examples:** Machinery (Go), Quartz.net (.NET), Hangfire (.NET).
    * **Often used with message queues.**
    * **Go:** Implementing a background worker involves creating a separate executable, or using a library that facilitates background task execution like [Machinery](https://github.com/RichardKnop/machinery).
    * **C#** , Out-of-process approach can be implemented using [Windows Service](https://learn.microsoft.com/en-us/dotnet/core/extensions/windows-service) or [Systemd](https://devblogs.microsoft.com/dotnet/net-core-and-systemd/) on Linux. Alternatively, dedicated processes can be run  as scoped service and process task(s) sequentially. Refer to "Queued Background tasks" example [here](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-9.0&tabs=visual-studio#queued-background-tasks).

 

3.  **Scheduled Tasks (Cron Jobs/Task Schedulers)**

    * **Description:** Executing tasks at specific intervals or times.
    * **Pros:** Simple scheduling, suitable for recurring tasks.
    * **Cons:** Less flexible than message queues, not ideal for event-driven tasks.
    * **Go:** Using `cron` libraries like [Gocron](https://github.com/go-co-op/gocron) or Windows Task Scheduler.
    * **C#:** Using Windows Task Scheduler, or libraries like Quartz.NET/hangfire.


4.  **Message Queues (Asynchronous Communication)**

    * **Description:** Using a message broker (e.g., RabbitMQ, Kafka, Redis Pub/Sub) to decouple task producers and consumers.
    * **Pros:** Scalable, fault-tolerant, supports distributed systems, excellent for decoupling.
    * **Cons:** Requires additional infrastructure, increased complexity.
    * **Example (Conceptual):**
        * Producer: Sends a message (task details) to a queue.
        * Consumer (Worker): Retrieves the message from the queue and processes the task.
    * **Considerations:** Message durability, delivery guarantees, message serialization.
    * **Go (using RabbitMQ):** (Requires RabbitMQ client library)

    ```go
    // Example using amqp library. Add error handling.
    // ...
    ```

    * **C# (using RabbitMQ):** (Requires RabbitMQ client library)

    ```csharp
    // Example using RabbitMQ.Client library. Add error handling.
    // ...
    ```



5.  **Asynchronous APIs (Callbacks/Promises/Async-Await)**

    * **Description:** Allowing client applications to initiate tasks and receive results later without blocking.
    * **Pros:** Improves client-side responsiveness, good for web applications.
    * **Cons:** Requires careful handling of asynchronous operations, potential for callback hell (older callback based approaches).d q
    * **Go:** Using Goroutines and channels for asynchronous communication.
    * **C#:** refer to implementation of Asynchronous (long-running) Apis [here](https://learn.microsoft.com/en-us/azure/architecture/patterns/async-request-reply).

    Typical flow is as follow,

        {{< figure src="/images/async-request.png" title="Async Request/Reply pattern" >}}

6.  **Outbox Pattern**

    **Description:** The Outbox Pattern provides a reliable way to publish events or messages when database transactions are involved. Instead of directly publishing messages to a message queue, events are stored in an `outbox` table within the same database. This helps with consistency issues as updates can be part of same transaction context.  A separate process then reads these events from the `outbox` table and publishes them to the message queue. This pattern is typically used alongside other patterns mentioned above. 

    * **Benefits:**
      * **Atomicity:** Ensures that events are published only if the database transaction succeeds.
      * **Reliability:** Prevents message loss in case of application crashes or network issues.
      * **Decoupling:** Decouples the application from the message queue.
    * **Implementation:**
              1.  **Outbox Table:** Typical `outbox` table to store events:

                ```sql
                CREATE TABLE outbox (
                    id SERIAL PRIMARY KEY,
                    payload JSONB NOT NULL,
                    destination VARCHAR(255) NOT NULL,
                    processed BOOLEAN NOT NULL DEFAULT FALSE,
                    created_at TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT NOW()
                );
                ```

        1.  **Publishing Events:** When an event occurs, insert a row into the `outbox` table within the same database transaction as the business logic.
        2.  **Background Processor:** Create a background process that reads events from the `outbox` table, publishes them to the message queue, and updates the `processed` column.
        3.  **Idempotency:** ensure that the message consumer is idempotent, to handle possible duplicate messages.

  * **Example (C# with PostgreSQL):**

            ```csharp
            using Npgsql;
            using System.Text;
            using System.Text.Json;
            using System.Threading;
            using System.Threading.Tasks;

            public class OutboxProcessor
            {
                private readonly string _connectionString;
                private readonly IConnection _rabbitConnection;

                public OutboxProcessor(string connectionString, IConnection rabbitConnection)
                {
                    _connectionString = connectionString;
                    _rabbitConnection = rabbitConnection;
                }

                public async Task ProcessOutbox(CancellationToken cancellationToken)
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        try
                        {
                            using (var connection = new NpgsqlConnection(_connectionString))
                            {
                                await connection.OpenAsync(cancellationToken);

                                using (var transaction = connection.BeginTransaction())
                                {
                                    using (var command = new NpgsqlCommand(
                                        "SELECT id, payload, destination FROM outbox WHERE processed = FALSE FOR UPDATE SKIP LOCKED LIMIT 1",
                                        connection, transaction))
                                    {
                                        using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                                        {
                                            if (await reader.ReadAsync(cancellationToken))
                                            {
                                                int id = reader.GetInt32(0);
                                                string payload = reader.GetString(1);
                                                string destination = reader.GetString(2);

                                                PublishToRabbitMQ(destination, payload);

                                                using (var updateCommand = new NpgsqlCommand(
                                                    "UPDATE outbox SET processed = TRUE WHERE id = @id", connection, transaction))
                                                {
                                                    updateCommand.Parameters.AddWithValue("id", id);
                                                    await updateCommand.ExecuteNonQueryAsync(cancellationToken);
                                                }
                                            }
                                        }
                                    }
                                    await transaction.CommitAsync(cancellationToken);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error processing outbox: {ex.Message}");
                        }
                        await Task.Delay(1000, cancellationToken);
                    }
                }

                private void PublishToRabbitMQ(string destination, string payload)
                {
                    using (var channel = _rabbitConnection.CreateModel())
                    {
                        channel.BasicPublish(exchange: "", routingKey: destination, basicProperties: null, body: Encoding.UTF8.GetBytes(payload));
                    }
                }
            }
            ```
        Notice the use of `SELECT .... FOR UPDATE ..... SKIP LOCKED`. This is useful in case outbox table will be accessed/read concurrently by multiple processes. This ensures read operation will skip (and not wait) records that have `read lock`. This feature is available in most of RDBMS. 



### Comparison Table

|Approach	|Scalability	|Complexity	|Fault Tolerance|	Use Cases|
|-----------|---------------|-----------|---------------|------------|
|Thread Pools|	Low|	Low|	Low|	Simple, in-process tasks|
|Message Queues|	High|	High|	High|	Distributed systems, decoupling, asynchronous communication|
|Background Workers|	High|	Medium|	Medium|	Long-running tasks, dedicated processing|
|Scheduled Tasks|	Medium|	Low|	Low|	Recurring tasks, scheduled operations|
|Asynchronous APIs|	Medium|	Medium|	Medium|	Web applications, non-blocking client interactions, improved responsiveness|
|-----------|---------------|-----------|---------------|------------|



## Conclusion 

Choosing the right approach depends on the specific requirements of your application. Message queues and background workers offer excellent scalability and fault tolerance for complex, distributed systems. Thread pools and scheduled tasks are suitable for simpler scenarios. Asynchronous APIs are crucial for improving client-side responsiveness in web applications.

By understanding these techniques, you can effectively manage out-of-order and delayed processing, enhancing the performance and user experience of your applications.

### Useful links (#usefullinks)



Happy Coding !!

---

{{< comments >}}