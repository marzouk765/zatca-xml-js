### Logger

The library includes a minimal logger utility used internally.

```ts
log(type: string, source: string, message: string): void
```

- Logging is enabled when `process.env.LOGGING === "1"`.
- Messages are printed to stdout with timestamp and colored tags.

Example:

```ts
process.env.LOGGING = "1";
// internal modules will start emitting logs
```