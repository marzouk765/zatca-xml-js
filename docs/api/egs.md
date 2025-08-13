### EGS Module

The `EGS` module represents the E-Invoice Generation System unit and orchestrates key/CSR generation and communication with ZATCA services.

#### Types

```ts
interface EGSUnitLocation {
  city: string;
  city_subdivision: string;
  street: string;
  plot_identification: string;
  building: string;
  postal_zone: string;
}

interface EGSUnitInfo {
  uuid: string;
  custom_id: string;
  model: string;
  CRN_number: string;
  VAT_name: string;
  VAT_number: string;
  branch_name: string;
  branch_industry: string;
  location: EGSUnitLocation;

  private_key?: string;
  csr?: string;
  compliance_certificate?: string;
  compliance_api_secret?: string;
  production_certificate?: string;
  production_api_secret?: string;
}
```

#### Class: `EGS`

```ts
new EGS(egs_info: EGSUnitInfo)
```

- Initializes a new EGS instance with the provided info.

Methods:

- `get(): EGSUnitInfo`
  - Returns the current EGS info snapshot.

- `set(egs_info: Partial<EGSUnitInfo>): void`
  - Merges in updates to the EGS info.

- `async generateNewKeysAndCSR(production: boolean, solution_name: string): Promise<void>`
  - Generates a new EC secp256k1 private key and a CSR using OpenSSL. Stores fields in the instance.
  - Requires OpenSSL to be installed and accessible on PATH.
  - Optionally use `process.env.TEMP_FOLDER` to control the temp directory (default `/tmp/`).

- `async issueComplianceCertificate(OTP: string): Promise<string>`
  - Requests a compliance certificate from ZATCA using the generated CSR.
  - Returns the compliance request id.

- `async issueProductionCertificate(compliance_request_id: string): Promise<string>`
  - Requests a production certificate using the compliance certificate.
  - Returns the production request id.

- `async checkInvoiceCompliance(signed_invoice_string: string, invoice_hash: string): Promise<any>`
  - Checks a signed invoice’s compliance.

- `async reportInvoice(signed_invoice_string: string, invoice_hash: string): Promise<any>`
  - Reports a signed invoice using production credentials.

- `signInvoice(invoice: ZATCASimplifiedTaxInvoice, production?: boolean): { signed_invoice_string: string; invoice_hash: string; qr: string }`
  - Signs the provided invoice using the EGS certificate and private key. If `production` is true, uses production certificate; otherwise uses compliance certificate.

#### Example

```ts
import { EGS, ZATCASimplifiedTaxInvoice } from "zatca-xml-js";

const egs = new EGS(egsInfo);
await egs.generateNewKeysAndCSR(false, "solution_name");
const complianceRid = await egs.issueComplianceCertificate("123456");

const invoice = new ZATCASimplifiedTaxInvoice({ props: {/* ... */} });
const { signed_invoice_string, invoice_hash, qr } = egs.signInvoice(invoice);

await egs.checkInvoiceCompliance(signed_invoice_string, invoice_hash);
await egs.issueProductionCertificate(complianceRid);
await egs.reportInvoice(signed_invoice_string, invoice_hash);
```

Notes:
- Ensure OpenSSL is installed when calling key/CSR generation.
- Set `process.env.TEMP_FOLDER` if the default temp directory is not suitable for your environment.