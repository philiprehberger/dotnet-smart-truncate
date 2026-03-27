# Philiprehberger.SmartTruncate

[![CI](https://github.com/philiprehberger/dotnet-smart-truncate/actions/workflows/ci.yml/badge.svg)](https://github.com/philiprehberger/dotnet-smart-truncate/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/Philiprehberger.SmartTruncate.svg)](https://www.nuget.org/packages/Philiprehberger.SmartTruncate)
[![License](https://img.shields.io/github/license/philiprehberger/dotnet-smart-truncate)](LICENSE)
[![Sponsor](https://img.shields.io/badge/sponsor-GitHub%20Sponsors-ec6cb9)](https://github.com/sponsors/philiprehberger)

Truncate strings at word boundaries — no cut words, no ugly mid-word breaks.

## Installation

```bash
dotnet add package Philiprehberger.SmartTruncate
```

## Usage

```csharp
using Philiprehberger.SmartTruncate;

// Basic truncation at word boundary
StringTruncator.Truncate("The quick brown fox jumped", 20);
// => "The quick brown..."

// Custom suffix
StringTruncator.Truncate("The quick brown fox jumped", 20, " [more]");
// => "The quick [more]"

// Text fits — returned as-is
StringTruncator.Truncate("Hello", 20);
// => "Hello"

// No word boundary found — hard truncate
StringTruncator.Truncate("superlongwordwithoutspaces", 10);
// => "superlo..."
```

### Custom Suffix

```csharp
using Philiprehberger.SmartTruncate;

StringTruncator.Truncate("Hello wonderful world", 15, " [more]");
// "Hello [more]"
```

### Short Strings

```csharp
using Philiprehberger.SmartTruncate;

StringTruncator.Truncate("Hi", 10);   // "Hi" — no truncation needed
StringTruncator.Truncate("Hello", 3); // "..." — suffix only when too short
```

## API

### `StringTruncator`

| Method | Description |
|--------|-------------|
| `Truncate(string text, int maxLength, string suffix = "...")` | Truncate at the last word boundary before `maxLength`; fall back to hard truncation if no space is found |

**Notes:**
- If `text` fits within `maxLength`, it is returned unchanged.
- The returned string (including suffix) is always at most `maxLength` characters.
- The suffix defaults to `"..."`.

## Development

```bash
dotnet build src/Philiprehberger.SmartTruncate.csproj --configuration Release
```

## License

[MIT](LICENSE)
