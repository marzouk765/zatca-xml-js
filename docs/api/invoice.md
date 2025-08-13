### Simplified Tax Invoice

The `ZATCASimplifiedTaxInvoice` class parses or creates UBL 2.1 simplified tax invoices according to ZATCA rules.

#### Types

```ts
enum ZATCAPaymentMethods {
  CASH = "10",
  CREDIT = "30",
  BANK_ACCOUNT = "42",
  BANK_CARD = "48",
}

enum ZATCAInvoiceTypes {
  INVOICE = "388",
  DEBIT_NOTE = "383",
  CREDIT_NOTE = "381",
}

interface ZATCASimplifiedInvoiceLineItemDiscount {
  amount: number;
  reason: string;
}

interface ZATCASimplifiedInvoiceLineItemTax {
  percent_amount: number; // e.g. 0.15 for 15%
}

interface ZATCASimplifiedInvoiceLineItem {
  id: string;
  name: string;
  quantity: number;
  tax_exclusive_price: number;
  other_taxes?: ZATCASimplifiedInvoiceLineItemTax[];
  discounts?: ZATCASimplifiedInvoiceLineItemDiscount[];
  VAT_percent: number; // e.g. 0.15 for 15%
}

interface ZATCASimplifiedInvoicCancelation {
  canceled_invoice_number: number;
  payment_method: ZATCAPaymentMethods;
  cancelation_type: ZATCAInvoiceTypes;
  reason: string;
}

interface ZATCASimplifiedInvoiceProps {
  egs_info: EGSUnitInfo;
  invoice_counter_number: number;
  invoice_serial_number: string;
  issue_date: string;    // YYYY-MM-DD
  issue_time: string;    // HH:mm:ss
  previous_invoice_hash: string; // base64
  line_items?: ZATCASimplifiedInvoiceLineItem[];
  cancelation?: ZATCASimplifiedInvoicCancelation;
}
```

#### Class: `ZATCASimplifiedTaxInvoice`

```ts
new ZATCASimplifiedTaxInvoice({ invoice_xml_str?: string, props?: ZATCASimplifiedInvoiceProps })
```

- Parse an existing invoice XML string, or create a new unsigned invoice from `props`.

Methods:

- `getXML(): XMLDocument`
  - Returns an internal XML document object suitable for further processing and QR generation.

- `sign(certificate_string: string, private_key_string: string): { signed_invoice_string: string; invoice_hash: string; qr: string }`
  - Signs the invoice with a provided certificate and EC private key. Also embeds the QR.

#### Example: Create and Sign

```ts
import { ZATCASimplifiedTaxInvoice, ZATCAPaymentMethods } from "zatca-xml-js";

const invoice = new ZATCASimplifiedTaxInvoice({
  props: {
    egs_info: egsInfo,
    invoice_counter_number: 1,
    invoice_serial_number: "EGS1-886431145-1",
    issue_date: "2022-03-13",
    issue_time: "14:40:40",
    previous_invoice_hash: "BASE64_PREVIOUS_HASH",
    line_items: [
      { id: "1", name: "Item", quantity: 2, tax_exclusive_price: 10, VAT_percent: 0.15 },
    ],
  },
});

const { signed_invoice_string, invoice_hash, qr } = invoice.sign(
  COMPLIANCE_CERT_PEM,
  PRIVATE_KEY_PEM
);
```

#### Example: Cancellation (Credit/Debit Note)

```ts
const invoice = new ZATCASimplifiedTaxInvoice({
  props: {
    egs_info: egsInfo,
    invoice_counter_number: 2,
    invoice_serial_number: "EGS1-886431145-2",
    issue_date: "2022-03-14",
    issue_time: "10:15:00",
    previous_invoice_hash: "BASE64_PREVIOUS_HASH",
    cancelation: {
      canceled_invoice_number: 1,
      payment_method: ZATCAPaymentMethods.CASH,
      cancelation_type: ZATCAInvoiceTypes.CREDIT_NOTE,
      reason: "Customer return",
    },
  },
});
```

Notes:
- Monetary amounts are formatted according to ZATCA rules (e.g., VAT totals with 2 decimals).
- When creating invoices, ensure `line_items` and VAT percentages follow your business rules and ZATCA guidance.