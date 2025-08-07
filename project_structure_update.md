# JayPDFLibs - Updated Project Structure & Namespace Guide

## 📁 Repository Structure

```
JayPDFLibs/
├── README.md
├── CONTRIBUTING.md
├── LICENSE
├── .gitignore
├── JayPDFLibs.sln                      # Solution file
├── src/
│   ├── JayPDFLibs.Core/
│   │   ├── JayPDFLibs.Core.csproj
│   │   ├── Document/
│   │   │   ├── PdfDocument.cs
│   │   │   ├── PdfPage.cs
│   │   │   ├── PdfMetadata.cs
│   │   │   └── PdfObjects/
│   │   ├── Graphics/
│   │   │   ├── PdfGraphics.cs
│   │   │   ├── Primitives/
│   │   │   │   ├── Line.cs
│   │   │   │   ├── Rectangle.cs
│   │   │   │   └── Circle.cs
│   │   │   └── Colors/
│   │   │       ├── Color.cs
│   │   │       └── ColorSpace.cs
│   │   ├── Text/
│   │   │   ├── TextRenderer.cs
│   │   │   ├── TextLayout.cs
│   │   │   ├── FontManager.cs
│   │   │   └── Unicode/
│   │   │       ├── ThaiTextProcessor.cs
│   │   │       └── UnicodeHelper.cs
│   │   └── Fonts/
│   │       ├── TrueTypeFont.cs
│   │       ├── FontEmbedder.cs
│   │       ├── FontCache.cs
│   │       └── ThaiFont/
│   │           ├── ThaiTextAnalyzer.cs
│   │           └── ThaiCharacterMap.cs
│   ├── JayPDFLibs.Templates/
│   │   ├── JayPDFLibs.Templates.csproj
│   │   ├── Parser/
│   │   │   ├── XmlTemplateParser.cs
│   │   │   ├── JsonTemplateParser.cs
│   │   │   └── TemplateValidator.cs
│   │   ├── Engine/
│   │   │   ├── TemplateEngine.cs
│   │   │   ├── TemplateProcessor.cs
│   │   │   └── RenderingContext.cs
│   │   └── Variables/
│   │       ├── VariableResolver.cs
│   │       ├── ExpressionEvaluator.cs
│   │       └── ThaiFormatters.cs
│   ├── JayPDFLibs.DataSources/
│   │   ├── JayPDFLibs.DataSources.csproj
│   │   ├── Csv/
│   │   │   ├── CsvDataSource.cs
│   │   │   ├── CsvParser.cs
│   │   │   └── CsvStreamReader.cs
│   │   ├── Excel/
│   │   │   ├── ExcelDataSource.cs
│   │   │   └── ExcelReader.cs
│   │   ├── Database/
│   │   │   ├── SqlServerDataSource.cs
│   │   │   ├── MySqlDataSource.cs
│   │   │   ├── PostgreSqlDataSource.cs
│   │   │   └── DatabaseConnection.cs
│   │   └── Json/
│   │       ├── JsonDataSource.cs
│   │       └── JsonParser.cs
│   └── JayPDFLibs.Rendering/
│       ├── JayPDFLibs.Rendering.csproj
│       ├── Layout/
│       │   ├── PageLayout.cs
│       │   ├── TableLayout.cs
│       │   └── TextLayout.cs
│       ├── Pages/
│       │   ├── PageManager.cs
│       │   ├── PageSize.cs
│       │   └── PageOrientation.cs
│       └── Output/
│           ├── PdfWriter.cs
│           ├── PdfSerializer.cs
│           └── CompressionEngine.cs
├── tests/
│   ├── JayPDFLibs.Tests/
│   │   ├── JayPDFLibs.Tests.csproj
│   │   ├── Unit/
│   │   │   ├── Core/
│   │   │   │   ├── DocumentTests.cs
│   │   │   │   ├── FontTests.cs
│   │   │   │   └── ThaiTextTests.cs
│   │   │   ├── Templates/
│   │   │   │   ├── ParserTests.cs
│   │   │   │   └── EngineTests.cs
│   │   │   └── DataSources/
│   │   │       ├── CsvTests.cs
│   │   │       └── DatabaseTests.cs
│   │   ├── Integration/
│   │   │   ├── EndToEndTests.cs
│   │   │   └── ThaiDocumentTests.cs
│   │   └── Performance/
│   │       ├── BenchmarkTests.cs
│   │       └── MemoryTests.cs
│   └── JayPDFLibs.Benchmarks/
│       ├── JayPDFLibs.Benchmarks.csproj
│       ├── DocumentGenerationBenchmarks.cs
│       ├── ThaiTextBenchmarks.cs
│       └── ComparisonBenchmarks.cs
├── examples/
│   ├── JayPDFLibs.Examples/
│   │   ├── JayPDFLibs.Examples.csproj
│   │   ├── Program.cs
│   │   └── Examples/
│   │       ├── BasicGeneration.cs
│   │       ├── ThaiDocument.cs
│   │       ├── CsvToPdf.cs
│   │       └── TemplateInvoice.cs
│   └── SampleData/
│       ├── templates/
│       │   ├── invoice-template.xml
│       │   ├── report-template.xml
│       │   └── thai-template.xml
│       ├── data/
│       │   ├── customers.csv
│       │   ├── products.json
│       │   └── sample-data.xlsx
│       └── fonts/
│           ├── thai/
│           │   ├── Sarabun-Regular.ttf
│           │   ├── Sarabun-Bold.ttf
│           │   ├── Prompt-Regular.ttf
│           │   └── Kanit-Regular.ttf
│           └── english/
│               ├── Arial.ttf
│               └── Arial-Bold.ttf
├── docs/
│   ├── api/
│   │   ├── README.md
│   │   ├── core.md
│   │   ├── templates.md
│   │   ├── datasources.md
│   │   └── rendering.md
│   ├── guides/
│   │   ├── user-guide.md
│   │   ├── template-reference.md
│   │   ├── thai-language-guide.md
│   │   ├── performance.md
│   │   └── getting-started.md
│   ├── architecture/
│   │   ├── overview.md
│   │   ├── design-decisions.md
│   │   └── diagrams/
│   └── examples/
│       ├── basic-usage.md
│       ├── advanced-templates.md
│       └── thai-documents.md
├── assets/
│   ├── images/
│   │   ├── logo.png
│   │   ├── architecture-diagram.png
│   │   └── screenshots/
│   └── fonts/
│       └── thai/
│           ├── Sarabun-Regular.ttf
│           ├── Sarabun-Bold.ttf
│           ├── Prompt-Regular.ttf
│           └── Noto-Sans-Thai