### Signing Helpers

These functions power invoice signing and QR generation under the hood.

- `getPureInvoiceString(invoice_xml: XMLDocument): string`
  - Removes signature and QR related elements and canonicalizes the XML for hashing.

- `getInvoiceHash(invoice_xml: XMLDocument): string`
  - Computes SHA-256 over the canonicalized invoice and returns base64.

- `getCertificateHash(certificate_string: string): string`
  - Computes SHA-256 over the base64 PEM body and returns base64.

- `createInvoiceDigitalSignature(invoice_hash: string, private_key_string: string): string`
  - Signs the invoice hash using EC secp256k1 private key. Returns base64 signature.

- `getCertificateInfo(certificate_string: string)`
  - Extracts `hash`, `issuer`, `serial_number`, `public_key`, `signature` from an X.509 PEM.

- `cleanUpCertificateString(certificate_string: string): string`
- `cleanUpPrivateKeyString(certificate_string: string): string`

- `generateSignedXMLString({ invoice_xml, certificate_string, private_key_string })`
  - High-level function used by `ZATCASimplifiedTaxInvoice#sign` and `EGS#signInvoice` to inject UBL signature and QR.

Example (low-level flow, normally not needed):

```ts
import { XMLDocument } from "zatca-xml-js";
// These are used internally; public sign APIs should be preferred.
```

Notes:
- Prefer `ZATCASimplifiedTaxInvoice#sign` or `EGS#signInvoice` for application code.