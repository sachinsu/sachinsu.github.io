-m--
title: "OCR using LLM: evaluating capabilities"
date: 2026-05-23T01:00:00+05:30
draft: true
tags: [glm, zai, LLM, AI, OCR,ollama, localai, python,go,golang]
---
## Introduction 

[Taxhacker](https://github.com/vas3k/TaxHacker), is interesting open source project that uses LLM for [OCR](https://en.wikipedia.org/wiki/Optical_character_recognition) to extract text and other useful information from images (e.g. invoices). 

Further, it builds Tracker (using extracted information) for income/expenses or whatever else that needs to be tracked and involves performing scanning to extract data. It uses LiteLLM Proxy so that any AI Provider can be plugged in.

I decided to try OCR capabilities of LLM locally with below setup,

- [Ollama](https://ollama.com/) for local inference
- [GLM-OCR](https://ollama.com/library/glm-ocr) Model

Ollama is running locally on my laptop with 16 GB RAM. GLM-OCR  has size of 2.2 GB and runs comfortably.
 

## Code

Golang code below, evaluates  OCR capabilities of  model using pre-determined images. It uses ollama go library.

### Below is snippet of code that uses Ollama go library,

```go

 func (c *LLMConfig) ProcessOCR(ctx context.Context, imagedata []byte, docType string) (*OCRResponse, error) {

    start := time.Now()

    client, err := api.ClientFromEnvironment()

    if err != nil {

        c.logger.Error("Error creating ollama client",

            zap.Error(err),

        )

        return nil, fmt.Errorf("failed to marshal request: %w", err)

    }

    var ocrResp *OCRResponse

    // Build the OCR prompt based on document type

    prompt := c.buildPrompt(docType)

    c.logger.Info("Prompt", zap.String("Prompt", prompt), zap.String("doctype", docType))

    // Prepare request for Ollama Generate API with vision

    generateReq := &api.GenerateRequest{

        Model:  c.model,

        Prompt: prompt,

        Stream: new(false),

        Images: []api.ImageData{imagedata}, // Ollama API expects base64 image

        Options: map[string]interface{}{

            "temperature": 0.3, // Lower temperature for consistent extraction

            "top_p":        0.9,

            "num_predict": 2048,

        },

    }

    respFunc := func(resp api.GenerateResponse) error {

        // In streaming mode, responses are partial so we call fmt.Print (and not

        // Println) in order to avoid spurious newlines being introduced. The

        // model will insert its own newlines if it wants.

        // Extract structured data from the response

        structuredData := c.parseStructuredData(resp.Response)

        confidence := 0.0 //c.calculateConfidence(structuredData)

        ocrResp = &OCRResponse{

            Success:        true,

            RawText:        resp.Response,

            StructuredData: structuredData,

            Confidence:     0,

            ProcessingTime: time.Since(start).Milliseconds(),

            ModelUsed:      c.model,

        }

        c.logger.Info("OCR processing completed",

            zap.Duration("duration", time.Since(start)),

            zap.Float64("confidence", confidence),

            zap.String("model", c.model),

            zap.String("response", resp.Response),

        )

        return nil

    }

    err = client.Generate(ctx, generateReq, respFunc)

    if err != nil {

        c.logger.Error("Failed to marshal request",

            zap.Error(err),

        )

        return nil, fmt.Errorf("failed to marshal request: %w", err)

    }

    return ocrResp, nil

}

 

```

### Sample document used for testing has below content,

 

```

═══════════════════════════════════════════════════════════════════

                            INVOICE

═══════════════════════════════════════════════════════════════════

 

Invoice Number:    INV-2024-001

Date:             January 15, 2024

Due Date:         February 14, 2024

 

FROM:

─────────────────────────────────────────────────────────────────

Tech Solutions Inc

123 Business Street

San Francisco, CA 94102

USA

 

Phone: (415) 555-0100

Email: billing@techsolutions.com

Tax ID: 45-1234567

 

BILL TO:

─────────────────────────────────────────────────────────────────

Acme Corporation

456 Corporate Drive

New York, NY 10001

USA

 

Attention: John Smith

Phone: (212) 555-0200

 

═══════════════════════════════════════════════════════════════════

DESCRIPTION                          QUANTITY    UNIT PRICE    TOTAL

═══════════════════════════════════════════════════════════════════

 

Professional Consulting Services        40 hrs      $150.00   $6,000.00

Software Development (Backend)          80 hrs      $125.00  $10,000.00

Quality Assurance & Testing             20 hrs      $100.00   $2,000.00

Project Management & Coordination       15 hrs       $95.00   $1,425.00

 

═══════════════════════════════════════════════════════════════════

                                              SUBTOTAL: $19,425.00

                                          Tax (12%):   $2,331.00

                                    ─────────────────────────────

                                    TOTAL AMOUNT DUE:  $21,756.00

═══════════════════════════════════════════════════════════════════

 

PAYMENT TERMS:

Net 30 days from invoice date

 

PAYMENT METHOD:

Wire Transfer:

Bank Name: First National Bank

Account: 123456789

Routing: 021000021

 

Notes:

Thank you for your business. Please include invoice number with payment.

For questions, contact our accounting department.

 

═══════════════════════════════════════════════════════════════════

 

```

Above sample invoice is converted into image using python [pillow](https://github.com/python-pillow/Pillow) library.


The prompt is as follows,


```

 

You are an expert document analyst. Extract structured data from this invoice image and respond ONLY with valid JSON object without markdown code blocks.

{

  "invoice_number": "",

  "date": "",

  "vendor_name": "",

  "vendor_address": "",

  "vendor_phone": "",

  "line_items": [{"description": "", "quantity": 0, "unit_price": 0, "total": 0}],

  "subtotal": 0,

  "tax": 0,

  "tax_rate": "",

  "total_amount": 0,

  "payment_terms": "",

  "due_date": "",

  "notes": ""

}

Extract ALL visible fields. For numeric values, use numbers not strings. For missing fields, use null.

 

```

 

The response received from GLM-OCR is as follows,

 

```

 

```json

 

{

  "invoice_number": "INV-2024-001",

  "date": "January 15, 2024",

  "vendor_name": "Tech Solutions Inc",

  "vendor_address": "123 Business Street San Francisco, CA 94102 USA",

  "vendor_phone": "(415) 555-0100",

  "line_items": [

    {

      "description": "Professional Consulting Services 40 hrs",

      "quantity": 0,

      "unit_price": 150,

      "total": 0

    },

    {

      "description": "Software Development (Backend) 80 hrs",

      "quantity": 0,

      "unit_price": 125,

      "total": 0

    },

    {

      "description": "Quality Assurance & Testing 20 hrs",

      "quantity": 0,

      "unit_price": 100,

      "total": 0

    },

    {

      "description": "Project Management & Coordination 15 hrs",

      "quantity": 0,

      "unit_price": 95,

      "total": 0

    }

  ],

  "subtotal": 0,

  "tax": 0,

  "tax_rate": "",

  "total_amount": 21756,

  "payment_terms": "Net 30 days from invoice date",

  "due_date": "",

  "notes": "Thank you for your business. Please include invoice number with payment. For questions, contact our accounting department."

}

 

 

```


 

### Summary

Below are the observations

- Model returns json though its wrapped in Markdown blocks. This is despite of instructing model to return valid JSON
- While extracting line items in invoice, it is unable to segregate quantity/count from the item description itself.
- "Due date" is returned as nil/empty instead of actual value
- Calculated fields like "subtotal", "tax" are not extracted 


Overall, More testing is needed along with enhanced prompt techniques to overcome above anamolies. However, using local LLMs for OCR looks promising and presents viable alternative to traditional OCR techniques.

Happy **Vibe** Coding !!

---

{{< comments >}}
