### QR Utilities

#### Function: `generatePhaseOneQR`

```ts
generatePhaseOneQR({ invoice_xml }: { invoice_xml: any }): string
```

- Generates a Phase One QR code payload (base64) from an invoice XML document. Provided for backward compatibility where Phase Two is not fully deployed.

Parameters:
- `invoice_xml`: The XML document returned by `ZATCASimplifiedTaxInvoice#getXML()`.

Returns:
- Base64-encoded QR string.

Example:

```ts
import { ZATCASimplifiedTaxInvoice, generatePhaseOneQR } from "zatca-xml-js";

const invoice = new ZATCASimplifiedTaxInvoice({ props: {/* ... */} });
const qr = generatePhaseOneQR({ invoice_xml: invoice.getXML() });
```

Note:
- For fully compliant Phase Two flows, use `EGS#signInvoice(...)` or `ZATCASimplifiedTaxInvoice#sign(...)` which also returns a QR that includes the digital signature and cryptographic stamp.