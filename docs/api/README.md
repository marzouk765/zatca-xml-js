### API Reference

This library implements Saudi Arabia ZATCA E-Invoicing processes and standards in TypeScript. This section documents the public API exported by `zatca-xml-js`.

- Modules
  - EGS (E-Invoice Generation System): `EGS`, `EGSUnitInfo`, `EGSUnitLocation`
  - Simplified Tax Invoice: `ZATCASimplifiedTaxInvoice`, `ZATCAPaymentMethods`, `ZATCAInvoiceTypes`, `ZATCASimplifiedInvoiceLineItem`, `ZATCASimplifiedInvoiceProps`
  - QR Utilities: `generatePhaseOneQR`

Note: The EGS module uses OpenSSL to generate EC secp256k1 key pairs and CSRs. Ensure OpenSSL is installed on the target system when using key/CSR generation.

### Installation

```bash
npm install zatca-xml-js
```

### Importing

```ts
import {
  EGS, EGSUnitInfo,
  ZATCASimplifiedTaxInvoice,
  ZATCAPaymentMethods, ZATCAInvoiceTypes,
  generatePhaseOneQR,
} from "zatca-xml-js";
```

### Quickstart

```ts
import { EGS, ZATCASimplifiedTaxInvoice, ZATCAPaymentMethods } from "zatca-xml-js";

const egsInfo = {
  uuid: "6f4d20e0-6bfe-4a80-9389-7dabe6620f12",
  custom_id: "EGS1-886431145",
  model: "IOS",
  CRN_number: "454634645645654",
  VAT_name: "Your Company",
  VAT_number: "301121971500003",
  location: {
    city: "Khobar",
    city_subdivision: "West",
    street: "King Fahd St",
    plot_identification: "0000",
    building: "0000",
    postal_zone: "31952",
  },
  branch_name: "Main Branch",
  branch_industry: "Food",
} as const;

const invoice = new ZATCASimplifiedTaxInvoice({
  props: {
    egs_info: egsInfo,
    invoice_counter_number: 1,
    invoice_serial_number: "EGS1-886431145-1",
    issue_date: "2022-03-13",
    issue_time: "14:40:40",
    previous_invoice_hash: "BASE64_PREVIOUS_HASH",
    line_items: [{
      id: "1",
      name: "Sample Item",
      quantity: 2,
      tax_exclusive_price: 10,
      VAT_percent: 0.15,
    }],
  },
});

const egs = new EGS(egsInfo);
await egs.generateNewKeysAndCSR(false, "your_solution_name");
const complianceRequestId = await egs.issueComplianceCertificate("OTP_FROM_PORTAL");

const { signed_invoice_string, invoice_hash, qr } = egs.signInvoice(invoice);
await egs.checkInvoiceCompliance(signed_invoice_string, invoice_hash);

await egs.issueProductionCertificate(complianceRequestId);
await egs.reportInvoice(signed_invoice_string, invoice_hash);
```

### Modules

- EGS: See `egs.md`
- Simplified Tax Invoice: See `invoice.md`
- QR Utilities: See `qr.md`
- XML Parser: See `parser.md`
- Signing Helpers: See `signing.md`
- Templates (Advanced): See `templates.md`