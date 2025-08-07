# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

JayPDFLibs is a modern, high-performance C# library for generating PDF documents from dynamic templates and data sources, with comprehensive Thai language support and zero commercial licensing concerns. This is currently a **documentation-only repository** in active development phase targeting Q4 2025 release.

**Current Status:** Development Phase - Documentation and Planning Complete
**Target Framework:** .NET 8.0
**License:** Apache 2.0

## Repository Structure

This repository contains comprehensive documentation for the JayPDFLibs project:

- `README.md` - Main project overview and features
- `CONTRIBUTING.md` - Development setup and contribution guidelines  
- `project_structure_update.md` - Detailed project architecture and namespace organization
- `template_reference.md` - Complete XML template syntax documentation
- `user_guide.md` - Comprehensive user documentation with examples
- `thai_language_guide_md.md` - Thai language support documentation

## Key Architecture Components

Based on the documentation, the planned architecture includes:

### Core Namespaces
- `JayPDFLibs.Core` - PDF document structure and primitives
- `JayPDFLibs.Templates` - XML/JSON template processing engine
- `JayPDFLibs.DataSources` - CSV, Excel, JSON, SQL database integrations
- `JayPDFLibs.Rendering` - PDF output generation and layout engine

### Planned Project Structure
```
src/
├── JayPDFLibs.Core/           # Core PDF functionality
├── JayPDFLibs.Templates/      # Template processing
├── JayPDFLibs.DataSources/    # Data source integrations  
├── JayPDFLibs.Rendering/      # PDF output generation
tests/
├── JayPDFLibs.Tests/          # Unit and integration tests
└── JayPDFLibs.Benchmarks/     # Performance benchmarks
examples/
└── JayPDFLibs.Examples/       # Sample projects
```

## Development Commands

Since this is currently a documentation repository, standard .NET commands are not yet applicable. When development begins:

```bash
# Build the solution
dotnet build

# Run tests  
dotnet test

# Run benchmarks
dotnet run --project tests/JayPDFLibs.Benchmarks/ -c Release

# Run examples
dotnet run --project examples/JayPDFLibs.Examples/

# Create NuGet packages
dotnet pack -c Release -o packages/
```

## Key Features & Focus Areas

### Thai Language Support
This library has extensive Thai language support as a primary feature:
- Thai font loading and embedding (Sarabun, Prompt, Kanit, Noto Sans Thai)
- Complex Thai text layout and character positioning
- Thai numerals and currency formatting
- Buddhist calendar date formatting
- Thai business document templates (invoices, receipts, purchase orders)

### Template System
- XML-based template engine with variable substitution
- Support for loops, conditionals, and functions
- Thai-specific formatting functions
- Data binding from multiple sources

### Data Sources
Planned support for:
- CSV files with Thai character encoding
- JSON data sources
- SQL Server, MySQL, PostgreSQL
- Excel files
- REST API integration

## Common Development Patterns

### Font Management
```csharp
// Standard pattern for loading Thai fonts
document.Fonts.LoadFont("Sarabun-Regular.ttf", "sarabun-regular");
document.Fonts.SetFallbackChain("sarabun-regular", new[] {
    "sarabun-regular", "noto-sans-thai", "arial-unicode-ms"
});
```

### Template Usage
```csharp
// XML template with Thai content
var template = TemplateLoader.FromXmlFile("thai-invoice.xml");
var document = template.Generate(data);
document.SaveToFile("output.pdf");
```

### Thai Text Rendering
```csharp
// Proper Thai text rendering with complex layout
page.AddText("สวัสดีครับ", 100, 700, 
    fontName: "sarabun-regular", 
    fontSize: 16,
    options: new TextRenderingOptions {
        EnableComplexTextLayout = true,
        Script = Script.Thai,
        Language = "th-TH"
    });
```

## Testing Approach

When implementation begins, testing should focus on:
- Thai character rendering accuracy
- Template processing correctness  
- Performance benchmarks (target: 1000+ pages in <15 seconds)
- Memory usage optimization
- Cross-platform compatibility

## Performance Considerations

- Font subsetting for large documents
- Streaming mode for memory efficiency
- Batch processing for multiple documents
- Glyph caching for repeated text

## Documentation Standards

All documentation should:
- Include Thai language examples alongside English
- Provide complete code samples that can be executed
- Cover error handling and edge cases
- Include performance considerations
- Follow Thai business document conventions

## Contributing Guidelines

Key points for contributors:
- Thai language testing is mandatory for Thai-related features
- All code must include XML documentation
- Follow existing naming conventions (PascalCase for public members)
- Include unit tests for all new functionality
- Performance benchmarks for core operations

## File Organization

When working with this codebase:
- Documentation files are in root directory
- Follow the namespace structure defined in `project_structure_update.md`
- Thai-specific code should include cultural context
- Template examples should be production-ready