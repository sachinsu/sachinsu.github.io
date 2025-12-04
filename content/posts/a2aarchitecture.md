---
title: "Notes on Excellent AI Agent Architecture via A2A/MCP by Jeffrey Richter"
date: 2025-12-02T01:00:00+05:30
draft: false
tags: [Agent-to-Agent,MCP,Anthropic,Google A2A, Lanchain, Semantic Kernel, RAG, Gen AI, Agentic]
---
## Introduction 

This article compiles my notes on an excellent architectural deep-dive by Jeffrey Richter. He outlines how to architect robust AI Agents using **[Google's Agent-to-Agent (A2A) protocol](https://a2a-protocol.org)** for coordination and **[Anthropic's Model Context Protocol (MCP)](https://modelcontextprotocol.io/introduction)** for tool integration. 

It is a must-read for anyone moving beyond simple chatbots to complex agentic workflows. You can read the original article [here](https://medium.com/@jeffreymrichter/ai-agent-architecture-b864080c4bbc).

## 1. First Principles: AI Models vs. Traditional Software

Richter starts by contrasting the "probabilistic" nature of AI with the "deterministic" nature of software. This distinction drives the architecture.

| Feature | Traditional Software | AI Models (Humans) |
| :--- | :--- | :--- |
| **Input** | **Precise:** Scalars, JSON, XML, Structs. | **Imprecise:** Natural language, audio, video. |
| **Processing** | **Deterministic:** Same input always = same output. | **Probabilistic:** Subject to interpretation and context. |
| **Output** | **Precise:** Intended for other software. | **Imprecise:** Intended for humans or other agents. |



**Key Takeaway:** 

* **Imprecise data** is valid input for Humans/AI, but toxic for software functions.
* **Precise data** is the goal of software, but when AI models attempt to output it (e.g., JSON), they may hallucinate or format it incorrectly. 
* **The Architecture Gap:** We need a bridge to safely turn the Model's "thoughts" into "executable actions."

## 2. The AI Agent Process Flow

An AI Agent is essentially a wrapper around a Model that gives it "hands" (tools) and "memory" (history).

{{< figure
  src="/images/a2a/agent_flow.png"
  alt="A2A process flow"
  caption="The Agent Orchestration Loop"
  class="ma0 w-75"  >}}



### The Components

* **The Agent Interface (A2A):** The Agent itself is an HTTP service  (or it may provide User Interface) that accepts **imprecise input** (instructions) and returns **imprecise output** (answers/results).
* **Agent Card:** To be discoverable, every Agent publishes an "Agent Card"—metadata containing its name, description, and the set of skills it possesses.
* **State & History:** Since AI Models are stateless, the Agent must maintain the conversation history. It manages the context window, often deciding which memories to keep or discard.

### The Orchestrator Loop

The "Brain" of the agent is the **Orchestrator** (often built with [LangChain](https://www.langchain.com/), [Semantic Kernel](https://learn.microsoft.com/en-us/semantic-kernel/overview/), [Autogen](https://microsoft.github.io/autogen/stable//index.html) etc.). Its main execution loop looks like this:

1.  **Receive Message:** The Agent receives a task/message.
2.  **RAG Augmentation:** The Orchestrator may augment the prompt with domain-specific knowledge (retrieved from vector databases, PDFs, etc.).
3.  **Model Reasoning:** The full context is sent to the AI Model.
4.  **Decision Point:** The Model outputs either:
    * **Imprecise Result:** Natural language to be sent back to the user.
    * **Precise Tool Call:** A specific request to call a function (e.g., `get_weather(city="Mumbai")`).
5.  **Tool Execution (MCP):** If a tool is requested, the Orchestrator executes it (via MCP) and feeds the result back into the conversation for the Model to interpret.

## 3. The Power of MCP (Model Context Protocol)

While A2A handles Agent-to-Agent chatter, **MCP** standardizes how Agents connect to their tools and data.

* **The Connection:** Agents act as **MCP Hosts**. They connect to **MCP Servers** (which provide the actual tools).
* **Deployment:** MCP Servers can be local executables (stdio) or remote HTTP services.
* **Discovery:** Each MCP Server exposes three things:
    1.  **Tools:** Executable functions with JSON schemas.
    2.  **Resources:** Read-only data (like file contents or logs).
    3.  **Prompts:** Reusable prompt templates.

### Advanced MCP Features
* **Sampling:** This allows an MCP Server to "ask for help." Instead of just running code, the Server can request the Host Agent to process a prompt using the Agent's LLM. This is powerful because the MCP Server doesn't need its own API keys; it just borrows the Agent's brain.
* **Roots:** A security/scoping feature where the Agent defines the "root" boundaries (e.g., a specific folder in VS Code) that the MCP Server is allowed to access.

---

  *Jeff has covered much more than above summary in the original post, specifically regarding the specific JSON schemas and protocol nuances. Highly recommended reading!*

### Useful References,

- [Ai Agents with MCP explained](https://youtu.be/wGz955ZeLpc)



Happy Coding !!

---

{{< comments >}}