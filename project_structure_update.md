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
│           └── Noto-Sans-Thai-Regular.ttf
├── .github/
│   ├── workflows/
│   │   ├── ci.yml
│   │   ├── release.yml
│   │   └── benchmark.yml
│   ├── ISSUE_TEMPLATE/
│   │   ├── bug_report.md
│   │   ├── feature_request.md
│   │   └── thai_language_issue.md
│   └── PULL_REQUEST_TEMPLATE.md
├── scripts/
│   ├── build.sh
│   ├── test.sh
│   ├── benchmark.sh
│   └── package.sh
└── tools/
    ├── font-validator/
    ├── template-validator/
    └── performance-analyzer/
```

## 🏗️ Namespace Structure

### Core Namespaces
```csharp
// Core PDF functionality
JayPDFLibs.Core
JayPDFLibs.Core.Document
JayPDFLibs.Core.Graphics
JayPDFLibs.Core.Text
JayPDFLibs.Core.Fonts

// Template system
JayPDFLibs.Templates
JayPDFLibs.Templates.Parser
JayPDFLibs.Templates.Engine
JayPDFLibs.Templates.Variables

// Data source integrations
JayPDFLibs.DataSources
JayPDFLibs.DataSources.Csv
JayPDFLibs.DataSources.Excel
JayPDFLibs.DataSources.Database
JayPDFLibs.DataSources.Json

// Rendering engine
JayPDFLibs.Rendering
JayPDFLibs.Rendering.Layout
JayPDFLibs.Rendering.Pages
JayPDFLibs.Rendering.Output

// Thai language specific
JayPDFLibs.Thai
JayPDFLibs.Thai.Text
JayPDFLibs.Thai.Fonts
JayPDFLibs.Thai.Formatting

// Utilities and extensions
JayPDFLibs.Utils
JayPDFLibs.Extensions
JayPDFLibs.Exceptions
```

## 📦 NuGet Package Structure

### Main Packages
```xml
<!-- Core package -->
<PackageId>JayPDFLibs</PackageId>
<Description>Core PDF generation library with Thai language support</Description>

<!-- Template package -->
<PackageId>JayPDFLibs.Templates</PackageId>
<Description>Template-based PDF generation for JayPDFLibs</Description>

<!-- Data sources package -->
<PackageId>JayPDFLibs.DataSources</PackageId>
<Description>Data source integrations for JayPDFLibs</Description>

<!-- Thai language package -->
<PackageId>JayPDFLibs.Thai</PackageId>
<Description>Enhanced Thai language support for JayPDFLibs</Description>
```

## 🔧 Project File Updates

### Solution File (JayPDFLibs.sln)
```
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "JayPDFLibs.Core", "src\JayPDFLibs.Core\JayPDFLibs.Core.csproj", "{GUID1}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "JayPDFLibs.Templates", "src\JayPDFLibs.Templates\JayPDFLibs.Templates.csproj", "{GUID2}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "JayPDFLibs.DataSources", "src\JayPDFLibs.DataSources\JayPDFLibs.DataSources.csproj", "{GUID3}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "JayPDFLibs.Rendering", "src\JayPDFLibs.Rendering\JayPDFLibs.Rendering.csproj", "{GUID4}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "JayPDFLibs.Tests", "tests\JayPDFLibs.Tests\JayPDFLibs.Tests.csproj", "{GUID5}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "JayPDFLibs.Examples", "examples\JayPDFLibs.Examples\JayPDFLibs.Examples.csproj", "{GUID6}"
EndProject
```

### Core Project File (JayPDFLibs.Core.csproj)
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <LangVersion>latest</LangVersion>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    
    <!-- Package Information -->
    <PackageId>JayPDFLibs</PackageId>
    <Title>JayPDFLibs - PDF Generation Library</Title>
    <Description>A modern C# library for generating PDF documents with comprehensive Thai language support</Description>
    <Authors>Your Name</Authors>
    <Company>Your Company</Company>
    <Product>JayPDFLibs</Product>
    <Copyright>Copyright © 2025</Copyright>
    
    <!-- Version Information -->
    <Version>1.0.0</Version>
    <AssemblyVersion>1.0.0.0</AssemblyVersion>
    <FileVersion>1.0.0.0</FileVersion>
    
    <!-- Package Metadata -->
    <PackageProjectUrl>https://github.com/yourusername/JayPDFLibs</PackageProjectUrl>
    <PackageLicenseExpression>Apache-2.0</PackageLicenseExpression>
    <PackageReadmeFile>README.md</PackageReadmeFile>
    <RepositoryUrl>https://github.com/yourusername/JayPDFLibs.git</RepositoryUrl>
    <RepositoryType>git</RepositoryType>
    <PackageTags>pdf;thai;document-generation;pdf-generation;thai-language;reporting</PackageTags>
    <PackageReleaseNotes>Initial release with Thai language support</PackageReleaseNotes>
    
    <!-- Build Properties -->
    <GeneratePackageOnBuild>false</GeneratePackageOnBuild>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <IncludeSymbols>true</IncludeSymbols>
    <SymbolPackageFormat>snupkg</SymbolPackageFormat>
  </PropertyGroup>

  <PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|AnyCPU'">
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <WarningsAsErrors />
    <WarningsNotAsErrors />
  </PropertyGroup>

  <PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Release|AnyCPU'">
    <DefineConstants>TRACE</DefineConstants>
    <Optimize>true</Optimize>
  </PropertyGroup>

  <ItemGroup>
    <None Include="..\..\README.md" Pack="true" PackagePath="\" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="System.Text.Json" Version="8.0.0" />
    <PackageReference Include="System.Drawing.Common" Version="8.0.0" />
  </ItemGroup>
</Project>
```

## 🚀 CLI Commands for Setup

### Initial Repository Setup
```bash
# Create new repository structure
mkdir JayPDFLibs
cd JayPDFLibs

# Initialize git repository
git init
git remote add origin https://github.com/yourusername/JayPDFLibs.git

# Create solution
dotnet new sln -n JayPDFLibs

# Create project structure
mkdir -p src/JayPDFLibs.Core
mkdir -p src/JayPDFLibs.Templates  
mkdir -p src/JayPDFLibs.DataSources
mkdir -p src/JayPDFLibs.Rendering
mkdir -p tests/JayPDFLibs.Tests
mkdir -p tests/JayPDFLibs.Benchmarks
mkdir -p examples/JayPDFLibs.Examples
mkdir -p docs/{api,guides,architecture,examples}
mkdir -p assets/{images,fonts/thai}
mkdir -p .github/{workflows,ISSUE_TEMPLATE}

# Create projects
dotnet new classlib -n JayPDFLibs.Core -o src/JayPDFLibs.Core
dotnet new classlib -n JayPDFLibs.Templates -o src/JayPDFLibs.Templates
dotnet new classlib -n JayPDFLibs.DataSources -o src/JayPDFLibs.DataSources
dotnet new classlib -n JayPDFLibs.Rendering -o src/JayPDFLibs.Rendering
dotnet new xunit -n JayPDFLibs.Tests -o tests/JayPDFLibs.Tests
dotnet new console -n JayPDFLibs.Examples -o examples/JayPDFLibs.Examples

# Add projects to solution
dotnet sln add src/JayPDFLibs.Core/JayPDFLibs.Core.csproj
dotnet sln add src/JayPDFLibs.Templates/JayPDFLibs.Templates.csproj
dotnet sln add src/JayPDFLibs.DataSources/JayPDFLibs.DataSources.csproj  
dotnet sln add src/JayPDFLibs.Rendering/JayPDFLibs.Rendering.csproj
dotnet sln add tests/JayPDFLibs.Tests/JayPDFLibs.Tests.csproj
dotnet sln add examples/JayPDFLibs.Examples/JayPDFLibs.Examples.csproj

# Set up project references
dotnet add src/JayPDFLibs.Templates/JayPDFLibs.Templates.csproj reference src/JayPDFLibs.Core/JayPDFLibs.Core.csproj
dotnet add src/JayPDFLibs.DataSources/JayPDFLibs.DataSources.csproj reference src/JayPDFLibs.Core/JayPDFLibs.Core.csproj
dotnet add src/JayPDFLibs.Rendering/JayPDFLibs.Rendering.csproj reference src/JayPDFLibs.Core/JayPDFLibs.Core.csproj
dotnet add tests/JayPDFLibs.Tests/JayPDFLibs.Tests.csproj reference src/JayPDFLibs.Core/JayPDFLibs.Core.csproj
dotnet add tests/JayPDFLibs.Tests/JayPDFLibs.Tests.csproj reference src/JayPDFLibs.Templates/JayPDFLibs.Templates.csproj
dotnet add examples/JayPDFLibs.Examples/JayPDFLibs.Examples.csproj reference src/JayPDFLibs.Core/JayPDFLibs.Core.csproj

# Build to verify setup
dotnet build
dotnet test
```

### Development Workflow Commands
```bash
# Build all projects
dotnet build

# Run tests
dotnet test

# Run specific test project
dotnet test tests/JayPDFLibs.Tests/

# Run benchmarks
dotnet run --project tests/JayPDFLibs.Benchmarks/ -c Release

# Run examples
dotnet run --project examples/JayPDFLibs.Examples/

# Create NuGet packages
dotnet pack -c Release -o packages/

# Install local package for testing
dotnet add package JayPDFLibs --source ./packages/

# Clean solution
dotnet clean

# Restore packages
dotnet restore
```

## 📋 Migration Checklist

### Code Migration Tasks
- [ ] Update all namespace declarations from `DynamicPDFLibrary.*` to `JayPDFLibs.*`
- [ ] Update project file names and references
- [ ] Update assembly names and package IDs
- [ ] Update using statements in all source files
- [ ] Update test project references and namespaces
- [ ] Update example project references and namespaces

### Documentation Migration Tasks  
- [ ] Update README.md with new project name
- [ ] Update CONTRIBUTING.md references
- [ ] Update all documentation files in docs/ folder
- [ ] Update API documentation links
- [ ] Update GitHub repository references
- [ ] Update NuGet package references in guides

### Infrastructure Migration Tasks
- [ ] Update GitHub repository name
- [ ] Update CI/CD pipeline references
- [ ] Update Docker file references (if any)
- [ ] Update NuGet package configuration
- [ ] Update issue templates with new repository name
- [ ] Update GitHub Actions workflow files

### Example Migration
```csharp
// Before (old namespace)
using DynamicPDFLibrary.Core;
using DynamicPDFLibrary.Templates;

namespace MyApp
{
    public class DocumentGenerator
    {
        public void CreatePDF()
        {
            var document = new DynamicPDFLibrary.Core.PdfDocument();
            // ...
        }
    }
}

// After (new namespace)  
using JayPDFLibs.Core;
using JayPDFLibs.Templates;

namespace MyApp
{
    public class DocumentGenerator
    {
        public void CreatePDF()
        {
            var document = new JayPDFLibs.Core.PdfDocument();
            // ...
        }
    }
}
```

## 🎯 Brand Identity

### Project Identity
- **Name**: JayPDFLibs
- **Tagline**: "Professional PDF Generation with Thai Language Excellence"
- **Key Features**: Thai language support, Open source, High performance, Template-driven
- **Target Audience**: C# developers, Thai businesses, Document automation systems
- **Unique Value Proposition**: First open-source PDF library with comprehensive Thai language support

### Logo and Branding (Future)
- Colors: Blue (#4A90E2) for technology, Gold (#FFD700) for Thai cultural elements
- Typography: Modern sans-serif for English, Thai-friendly fonts for Thai text
- Icons: PDF symbol with Thai script elements

This comprehensive structure provides a solid foundation for the renamed JayPDFLibs project while maintaining all the original functionality and documentation quality.