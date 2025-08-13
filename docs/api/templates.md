### Templates (Advanced)

These helpers return XML or config strings used internally to assemble UBL invoices and signatures. They are exported from their modules but are typically not needed by consumers unless you are customizing low-level behavior.

#### Simplified Tax Invoice Template

```ts
function populate(props: ZATCASimplifiedInvoiceProps): string
```
- Returns a base UBL Invoice XML string with placeholders populated from `props`.
- See `invoice.md` for `ZATCASimplifiedInvoiceProps` details.

#### UBL Signature Extensions

- Signed Properties (for hashing vs. after signing):
```ts
function defaultUBLExtensionsSignedPropertiesForSigning(props: {
  sign_timestamp: string;
  certificate_hash: string;
  certificate_issuer: string;
  certificate_serial_number: string;
}): string

function populate(props: {
  sign_timestamp: string;
  certificate_hash: string;
  certificate_issuer: string;
  certificate_serial_number: string;
}): string
```

- UBL Sign Extension block:
```ts
function populate(
  invoice_hash: string,
  signed_properties_hash: string,
  digital_signature: string,
  certificate_string: string,
  signed_properties_xml: string,
): string
```

#### Billing Reference Template

```ts
function populate(invoice_number: number): string
```

#### CSR OpenSSL Config Template

```ts
function populate(props: {
  private_key_pass?: string;
  production?: boolean;
  egs_model: string;
  egs_serial_number: string;
  solution_name: string;
  vat_number: string;
  branch_location: string;
  branch_industry: string;
  branch_name: string;
  taxpayer_name: string;
  taxpayer_provided_id: string;
}): string
```

Notes:
- Modifying low-level templates can break compliance. Prefer high-level APIs unless you fully understand ZATCA requirements.