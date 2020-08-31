---
title: "Using Github Actions for Automated Testing and Deployment"
date: 2020-05-28T10:25:04+05:30
draft: false
---

## Background

The source code of [tracfee.com](https://tracfee.com) is hosted on Github Private. 

At a High level, Tracfee's Architecture involves, 
- Single Page Application using VueJS, deployed on [Netlify](https://netlify.com)
- API in [Go](https://golang.org), deployed on [Oracle Cloud](https://www.oracle.com/in/cloud/)

So far, API testing has been automated and we were looking at ways to automate deployment of both UI and API. Steps required to deploy API are less since we are using Docker to run it on VM. However, in case of Netlify, it is required to build and then upload the output folder on Netlify. 

Accordingly, it was decided to explore Github actions to automate deployment.

## Using Github actions

As per [Github](https://github.com/features/actions),

```
GitHub Actions makes it easy to automate all your software workflows, now with world-class CI/CD. Build, test, and deploy your code right from GitHub. Make code reviews, branch management, and issue triaging work the way you want.
```

GitHub actions work by provisioning Virtual machine to run an Event based workflow. It provides option to provision Linux/MacOS/Windows based Virtual machines. Steps in Workflow will have to be configured in [YAML](https://yaml.org) file. Trigger for Workflow can be (but not limited to) wide variety of events like on Push or commit on branch and so on.

Post trigger, set of action(s) can be configured like,

- Checkout the branch 
- Setup environment (Install [Node.JS](https://github.com/actions/setup-node))
- Perform build
- Deployment

Github has Marketplace which has many pre-built actions available. My requirement was to,
- Provision Linux (i.e. ubuntu-latest) Virtual Machine
- Checkout the code (using [actions/checkout@v2](https://github.com/actions/checkout))
- Setup Node.js (using [actions/setup-node](https://github.com/actions/setup-node))
- perform Build and test using [NPM](https://www.npmjs.com/)
- Deploy to Netlify using [netlify/actions/cli@master](https://github.com/netlify/actions)
- Any secrets required as part of Workflow can be maintained using [Github secrets](https://help.github.com/en/actions/configuring-and-managing-workflows/creating-and-storing-encrypted-secrets)

Above workflow needs to be maintained in ```.github\workflows``` folder in the repository. 

build.yml for [tracfee.com](https://tracfee.com) looks like, 

{{< carbon gistid="f98fbca1049e15f0360c140610fa4cc4"  >}}

Refer Gist [here](https://gist.github.com/sachinsu/f98fbca1049e15f0360c140610fa4cc4).

## Testing the Build Workflow 

After configuring the workflow steps, next question is to check whether it is possible to test it locally? Luckily, there is tool available to do this. Enter [Act](https://github.com/nektos/act) , which is a tool to  ```Run your GitHub Actions locally ```.  Local testing is useful for Faster feedback. In Nutshell, Act uses local docker setup to provision container and then runs workflow steps in it. Give it a try !!

As a next step, Plan is to automate deployment of API on Oracle Cloud using OCI CLI interface. 

### Useful References,
- [Build with GitHub Actions, host on Netlify](https://medium.com/@MarekPukaj/build-with-github-actions-host-on-netlify-ebf5fa505616)
- [Adventures in CI/CD [#4]: Deploying A Microservice To The Oracle Cloud With GitHub Actions [OCI CLI Edition]](https://blogs.oracle.com/developers/adventures-in-cicd-4-deploying-a-microservice-to-the-oracle-cloud-with-github-actions-oci-cli-edition)

Happy Coding !!

---

{{< comments >}}