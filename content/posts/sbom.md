---
title: "What is Software Bill of Material (SBOM)"
date: 2025-09-09T01:00:00+05:30
draft: false
tags: [Software, BOM, SBOM, SPDX, CycloneDX, syft, DevOps]
---

## Introduction

A Software Bill of Materials (SBOM) is a list of all the components, libraries, and modules that make
up a software, providing transparency into its composition. It describes various packages and dependencies that go into creating a software artifact.

Software products are composed of many different components, some of which might come from
third party sources. These third-party components and dependencies can have vulnerabilities, which
attackers can exploit, leading to security incident or breaches. Key threats include attackers inserting
malicious code, vulnerabilities in outdated components, and breaches by compromised suppliers. These issues can lead to data breaches, operational disruptions, and reputational damage. SBOM can help improve software security and protect against potential threats.


### Why ?


- **Effective Incident Response** - SBOM can assist in speeding up by providing detailed information on dependencies. 

- **Vulnerabilities identification and patch management** - Using SBOM, organizations can quickly spot and address known vulnerabilities in the software by patching them.

- **Compliance** - SBOM helps organizations to streamline adherence to security regulations, guidelines and best practices on software security by providing required transparency in software composition.  

Many Governments around that world are now recommending SBOM like, 
  - [NIST](https://www.nsa.gov/Press-Room/Press-Releases-Statements/Press-Release-View/Article/4292020/nsa-cisa-and-others-release-a-shared-vision-of-software-bill-of-materials-sbom/)
  - [CERT-IN](https://www.cert-in.org.in/PDF/TechnicalGuidelines-on-SBOM,QBOM&CBOM,AIBOM_and_HBOM_ver2.0.pdf)

## Tools and Processes

Lets look at ways to generate SBOM. 

There are standards/specifications available to represent bills of material including SBOM. When it comes to SBOM, below are widely adopted standards, 

- [**SPDX**](https://spdx.dev/) - An open standard capable of representing systems with software components in as SBOMs (Software Bill of Materials) and other AI, data and security references supporting a range of risk management use cases.
- [**CycloneDX**](https://owasp.org/www-project-cyclonedx/) - is a full-stack Bill of Materials (BOM) standard that provides advanced supply chain capabilities for cyber risk reduction. CycloneDX is an Ecma International standard published as ECMA-424.  

Various tools and libraries typically scan the container images, file systems and generate a Software Bill of Materials as per above specifications. Each tool supports parsing of files for various languages/platforms to extract details on dependencies.  

Below are some of the open source tools available, 

- **CycloneDX** has repository that contains various tools  like,
  - [Cyclonedx-CLI](https://github.com/CycloneDX/cyclonedx-cli) - Cli for conversion, analysis, merging
  - [cyclonedx-dotnet](https://github.com/CycloneDX/cyclonedx-dotnet) - for .NET projects
  - [cyclonedx-gomod](https://github.com/CycloneDX/cyclonedx-gomod) - for Go Modules
  - [cyclonedx-core-java](https://github.com/CycloneDX/cyclonedx-core-java) - For Core Java
- [Syft](https://github.com/anchore/syft) - Supports C/C++/Dotnet/Java/JavaScript and many more. Refer [here](https://github.com/anchore/syft?tab=readme-ov-file#supported-ecosystems).It can generate BOM in either SPDX or CycloneDX specification.
- [Microsoft SBOM tool](https://github.com/microsoft/sbom-tool) - Generates SPDX 2.2 compatible SBOM.
  
Once SBOM is generated, one can use below tools to find About  vulnerabilities, misconfigurations, secrets etc. Refer to [Trivy](https://github.com/aquasecurity/trivy?tab=readme-ov-file#quick-start). Trivy can be used to scan Containers, File systems or sbom (SPDX or CycloneDX JSON only as of writing of this article).

The above tools are typically integrated in Build (CI/CD)  pipeline for automated SBOM Generation, vulnerabilities detection and reporting. 

High level Adoption approach could be, 
  - *Initiation*
    - Identify Critical Assets and Develop a Project Plan.
    - Determine the SBOM format and minimum requirements.
    - Identify security requirements,secure storage and tooling.
    - Plan for Proof of Concept 
  - *Progress*
    - Secure Installation and Operation Guidance Development.
    - Preparation of SBOM
    - Integrate SBOM in each phase of Secure Software Development Lifecycle.
    - Scan for vulnerabilities, secrets, misconfigurations 
    - Take corrective actions.
  - *On going*
    - Analysis and review of existing SBOM periodically and any changes as needed 
  

## Conclusion:

Each of the above tool help generate SBOM for the platform in either the standard Specification format (SPDX/CycloneDX) or tool's own proprietary format (e.g. syft has its own specification too.). Depending on the requirement, these tools can be effectively used for the projects. 


### Useful References
  
* [HBOM](https://cyclonedx.org/capabilities/hbom/) - Inventory hardware components for IoT, ICS, and other types of embedded and connected devices.
* [OWASP AIBOM](https://owasp.org/www-project-aibom/) - AIBOM aims to provide transparency into how AI models are built, trained, and deployed.

Happy Coding !!

---

{{< comments >}}