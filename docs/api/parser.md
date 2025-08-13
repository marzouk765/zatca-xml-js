### XML Parser

The `XMLDocument` utility parses, queries, mutates, and serializes UBL XML used across the library.

```ts
class XMLDocument {
  constructor(xml_str?: string)

  get(path_query?: string, condition?: any): XMLObject[] | undefined
  delete(path_query?: string, condition?: any): boolean
  set(path_query: string, overwrite: boolean, set_xml: XMLObject | string): boolean
  toString({ no_header }?: { no_header?: boolean }): string
}

interface XMLObject { [tag: string]: any }
```

- `get(path, condition?)`: Returns an array of elements matching the path (and condition) or `undefined`.
- `delete(path, condition?)`: Deletes matching elements. Returns `true` if something was deleted.
- `set(path, overwrite, value)`: Sets or appends an element at `path`. If `overwrite` is `true`, replaces existing; otherwise appends, turning single elements into arrays if needed.
- `toString({ no_header })`: Serializes the XML back to a string. If `no_header` is true, removes the XML declaration header.

Example:

```ts
import { XMLDocument } from "zatca-xml-js";

const xml = new XMLDocument('<Invoice><cbc:ID>123</cbc:ID></Invoice>');
const id = xml.get('Invoice/cbc:ID')?.[0];
xml.set('Invoice/cbc:IssueDate', true, '2022-10-01');
const str = xml.toString({ no_header: false });
```