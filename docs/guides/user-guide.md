# User Guide - JayPDFLibs

Welcome to JayPDFLibs! This comprehensive guide will help you get started with generating professional PDF documents with Thai language support.

## 📚 Table of Contents

1. [Installation](#-installation)
2. [Quick Start](#-quick-start)
3. [Basic PDF Creation](#-basic-pdf-creation)
4. [Working with Thai Fonts](#-working-with-thai-fonts)
5. [Template System](#-template-system)
6. [Data Sources](#-data-sources)
7. [Advanced Features](#-advanced-features)
8. [Performance Tips](#-performance-tips)
9. [Troubleshooting](#-troubleshooting)
10. [Examples](#-examples)

## 🚀 Installation

### NuGet Package (Recommended)
```bash
dotnet add package JayPDFLibs
```

### From Source
```bash
git clone https://github.com/yourusername/JayPDFLibs.git
cd JayPDFLibs
dotnet build
dotnet pack
```

### System Requirements
- .NET 8.0 or later
- Windows, macOS, or Linux
- Minimum 512MB RAM
- 100MB disk space for fonts and examples

## ⚡ Quick Start

### Your First PDF
```csharp
using JayPDFLibs.Core;

// Create a new PDF document
var document = new PdfDocument();

// Add a page
var page = document.AddPage(PageSize.A4);

// Add some text
page.AddText("Hello, World!", 100, 700, fontName: "Arial", fontSize: 18);

// Save to file
document.SaveToFile("my-first-pdf.pdf");

// Clean up
document.Dispose();
```

### Thai Language PDF
```csharp
using JayPDFLibs.Core;

var document = new PdfDocument();
var page = document.AddPage();

// Load Thai font first
document.Fonts.LoadFont("Sarabun-Regular.ttf", "sarabun");

// Add Thai text
page.AddText("สวัสดีครับ", 100, 700, fontName: "sarabun", fontSize: 16)
    .AddText("ยินดีต้อนรับสู่ DynamicPDFLibrary", 100, 670, fontName: "sarabun", fontSize: 14);

document.SaveToFile("thai-greeting.pdf");
document.Dispose();
```

## 📄 Basic PDF Creation

### Document Setup
```csharp
// Create document with metadata
var document = new PdfDocument()
{
    Title = "My Document",
    Author = "Your Name", 
    Subject = "PDF Generation Example",
    Keywords = "PDF, Thai, Dynamic"
};

// Add pages with different sizes
var page1 = document.AddPage(PageSize.A4);           // 210 × 297 mm
var page2 = document.AddPage(PageSize.Letter);       // 8.5 × 11 inches  
var page3 = document.AddPage(PageSize.A3);           // 297 × 420 mm

// Custom page size
var customPage = document.AddPage(new PageSize(300, 400)); // 300 × 400 points
```

### Page Properties
```csharp
var page = document.AddPage();

// Set margins (left, top, right, bottom)
page.SetMargins(20, 30, 20, 40);

// Set orientation
page.Orientation = PageOrientation.Landscape;

// Background color
page.BackgroundColor = Color.FromRgb(245, 245, 245);
```

### Text Operations
```csharp
var page = document.AddPage();

// Basic text
page.AddText("Simple text", 100, 700);

// Formatted text
page.AddText("Formatted text", 100, 670, 
    fontName: "Arial", 
    fontSize: 14, 
    color: Color.Blue,
    isBold: true,
    isItalic: false);

// Multi-line text
page.AddTextBlock("This is a long text that will wrap to multiple lines automatically.", 
    x: 100, y: 640, width: 400, height: 60,
    fontName: "Arial", fontSize: 12);

// Aligned text
page.AddText("Centered", 300, 580, alignment: TextAlignment.Center);
page.AddText("Right aligned", 500, 560, alignment: TextAlignment.Right);
```

## 🌏 Working with Thai Fonts

### Font Installation
```csharp
var document = new PdfDocument();

// Method 1: Load from file
document.Fonts.LoadFont("path/to/Sarabun-Regular.ttf", "sarabun-regular");
document.Fonts.LoadFont("path/to/Sarabun-Bold.ttf", "sarabun-bold");

// Method 2: Load from embedded resources
document.Fonts.LoadFontFromResource("MyApp.Fonts.Sarabun-Regular.ttf", "sarabun-regular");

// Method 3: Auto-load from fonts directory
document.Fonts.LoadFontsFromDirectory("assets/fonts/");
```

### Thai Text Rendering
```csharp
var page = document.AddPage();

// Basic Thai text
page.AddText("ประเทศไทย", 100, 700, fontName: "sarabun-regular", fontSize: 16);

// Mixed Thai-English content
page.AddText("Hello สวัสดี World โลก", 100, 670, fontName: "sarabun-regular", fontSize: 14);

// Thai numerals
page.AddText("Thai: ๑๒๓๔๕ Arabic: 12345", 100, 640, fontName: "sarabun-regular", fontSize: 12);

// Complex Thai text with tone marks
var complexThai = "กรุงเทพมหานคร อมรรัตนโกสินทร์ มหินทรายุธยา มหาดิลกภพ นพรัตนราชธานี";
page.AddText(complexThai, 100, 610, fontName: "sarabun-regular", fontSize: 10);
```

### Font Fallback System
```csharp
// Set up font fallback for missing characters
document.Fonts.SetFallbackChain("sarabun-regular", new[] 
{
    "sarabun-regular",
    "noto-sans-thai", 
    "arial-unicode-ms"
});

// Text will automatically use fallback fonts for missing characters
page.AddText("Mixed: Hello สวัสดี 你好 مرحبا", 100, 580, fontName: "sarabun-regular");
```

### Recommended Thai Fonts
| Font | Style | Best For | License |
|------|-------|----------|---------|
| **Sarabun** | Modern, clean | Documents, reports | Open Font License |
| **Prompt** | Friendly, rounded | UI, presentations | Open Font License |  
| **Kanit** | Contemporary | Headings, titles | Open Font License |
| **Noto Sans Thai** | Universal | Multi-language docs | Open Font License |

## 📋 Template System

### XML Templates
```xml
<?xml version="1.0" encoding="utf-8"?>
<pdf-template>
  <page size="A4" margins="20,20,20,20">
    <!-- Header section -->
    <header>
      <text x="100" y="750" font="sarabun-bold" size="18" color="#333333">
        {{document.title}}
      </text>
      <line x1="100" y1="740" x2="500" y2="740" color="#cccccc" width="1"/>
    </header>
    
    <!-- Body content -->
    <body>
      <text x="100" y="700" font="sarabun-regular" size="14">
        วันที่: {{current.date | format:'dd/MM/yyyy'}}
      </text>
      
      <!-- Dynamic table -->
      <table x="100" y="650" width="400" border="1">
        <headers font="sarabun-bold" size="12" background="#f0f0f0">
          <column width="200">รายการ</column>
          <column width="100">จำนวน</column>  
          <column width="100">ราคา (฿)</column>
        </headers>
        
        <rows data-source="items" font="sarabun-regular" size="10">
          <column>{{name}}</column>
          <column align="center">{{quantity}}</column>
          <column align="right">{{price | currency:'THB'}}</column>
        </rows>
        
        <footer font="sarabun-bold" size="12" background="#e0e0e0">
          <column colspan="2">รวมทั้งสิ้น</column>
          <column align="right">{{items | sum:'price' | currency:'THB'}}</column>
        </footer>
      </table>
    </body>
    
    <!-- Footer section -->
    <footer>
      <text x="100" y="50" font="sarabun-regular" size="8" color="#666666">
        หน้า {{page.number}} จาก {{page.total}}
      </text>
    </footer>
  </page>
</pdf-template>
```

### Using Templates
```csharp
using JayPDFLibs.Templates;

// Load template
var template = TemplateLoader.FromXmlFile("invoice-template.xml");

// Create data context
var data = new 
{
    document = new { title = "ใบแจ้งหนี้" },
    current = new { date = DateTime.Now },
    items = new[]
    {
        new { name = "สินค้า A", quantity = 2, price = 100.00m },
        new { name = "สินค้า B", quantity = 1, price = 250.00m },
        new { name = "สินค้า C", quantity = 3, price = 75.00m }
    }
};

// Generate PDF from template
var document = template.Generate(data);
document.SaveToFile("invoice.pdf");
```

### Template Variables and Functions
```xml
<!-- Basic variable substitution -->
<text>{{customer.name}}</text>

<!-- Conditional content -->
<text if="{{customer.vip}}">VIP Customer</text>
<text unless="{{customer.vip}}">Regular Customer</text>

<!-- Loops -->
<repeat data-source="orders">
  <text>Order #{{id}}: {{total | currency:'THB'}}</text>
</repeat>

<!-- Formatting functions -->
{{date | format:'dd/MM/yyyy'}}           <!-- Date formatting -->
{{price | currency:'THB'}}               <!-- Currency formatting -->  
{{text | upper}}                         <!-- Uppercase -->
{{text | truncate:50}}                   <!-- Truncate text -->
{{items | count}}                        <!-- Count items -->
{{numbers | sum}}                        <!-- Sum numbers -->
{{numbers | average}}                    <!-- Average -->
```

## 📊 Data Sources

### CSV Data Source
```csharp
using JayPDFLibs.DataSources;

// From file
var csvData = new CsvDataSource("customers.csv");

// From string
var csvString = @"
ชื่อ,อายุ,เมือง
สมชาย,25,กรุงเทพฯ
สมหญิง,30,เชียงใหม่
สมศักดิ์,35,ภูเก็ต";

var csvData = new CsvDataSource(csvString, hasHeaders: true);

// Configure CSV parsing
var csvData = new CsvDataSource("data.csv")
{
    Delimiter = ",",
    Encoding = Encoding.UTF8,
    HasHeaders = true,
    SkipEmptyRows = true
};

// Use with template
var template = TemplateLoader.FromXmlFile("customer-list.xml");
var document = template.Generate(csvData);
document.SaveToFile("customers.pdf");
```

### JSON Data Source
```csharp
// From JSON string
var jsonData = @"{
    'company': {
        'name': 'บริษัท ABC จำกัด',
        'address': '123 ถนนสุขุมวิท กรุงเทพฯ 10110'
    },
    'customers': [
        { 'name': 'คุณสมชาย', 'email': 'somchai@email.com' },
        { 'name': 'คุณสมหญิng', 'email': 'somying@email.com' }
    ]
}";

var jsonSource = new JsonDataSource(jsonData);

// From file
var jsonSource = new JsonDataSource("data.json");

// From URL
var jsonSource = new JsonDataSource("https://api.example.com/data");
```

### Database Data Source
```csharp
// SQL Server
var connectionString = "Server=localhost;Database=MyDB;Trusted_Connection=true;";
var query = "SELECT CustomerName as ชื่อ, Email, City as เมือง FROM Customers";

var dbSource = new SqlServerDataSource(connectionString, query);

// MySQL
var mysqlConnection = "Server=localhost;Database=mydb;Uid=user;Pwd=password;";
var mysqlSource = new MySqlDataSource(mysqlConnection, query);

// PostgreSQL  
var pgConnection = "Host=localhost;Database=mydb;Username=user;Password=password";
var pgSource = new PostgreSqlDataSource(pgConnection, query);

// Use with parameters
var query = "SELECT * FROM Orders WHERE OrderDate >= @startDate AND CustomerId = @customerId";
var parameters = new Dictionary<string, object>
{
    ["@startDate"] = DateTime.Now.AddMonths(-1),
    ["@customerId"] = 12345
};

var dbSource = new SqlServerDataSource(connectionString, query, parameters);
```

## 🎨 Advanced Features

### Tables and Layouts
```csharp
var page = document.AddPage();

// Create table
var table = page.CreateTable(x: 100, y: 600, width: 400)
    .SetBorders(Color.Black, 1)
    .SetHeaderBackground(Color.LightGray);

// Add headers
table.AddHeader("รายการ", width: 200, font: "sarabun-bold")
     .AddHeader("จำนวน", width: 100, alignment: TextAlignment.Center)
     .AddHeader("ราคา", width: 100, alignment: TextAlignment.Right);

// Add data rows
table.AddRow("สินค้า A", "2", "฿200.00")
     .AddRow("สินค้า B", "1", "฿150.00")  
     .AddRow("สินค้า C", "3", "฿450.00");

// Add footer
table.AddFooter("", "รวม", "฿800.00", font: "sarabun-bold");

// Render table
table.Render();
```

### Images and Graphics
```csharp
// Add image
page.AddImage("logo.png", x: 100, y: 700, width: 100, height: 50);

// Draw shapes
page.DrawRectangle(x: 100, y: 600, width: 200, height: 100, 
    fillColor: Color.LightBlue, borderColor: Color.Blue, borderWidth: 2);

page.DrawCircle(x: 300, y: 650, radius: 25, 
    fillColor: Color.Yellow, borderColor: Color.Orange);

page.DrawLine(x1: 100, y1: 580, x2: 400, y2: 580, 
    color: Color.Red, width: 3);
```

### Headers and Footers
```csharp
// Global header for all pages
document.SetHeader((page, pageNumber) => 
{
    page.AddText("บริษัท ABC จำกัด", 100, 780, "sarabun-bold", 14);
    page.AddText($"วันที่: {DateTime.Now:dd/MM/yyyy}", 400, 780, "sarabun-regular", 10);
    page.DrawLine(100, 770, 500, 770, Color.Gray, 1);
});

// Global footer
document.SetFooter((page, pageNumber, totalPages) =>
{
    page.DrawLine(100, 60, 500, 60, Color.Gray, 1);
    page.AddText($"หน้า {pageNumber} จาก {totalPages}", 300, 40, 
        "sarabun-regular", 10, alignment: TextAlignment.Center);
});
```

## ⚡ Performance Tips

### Memory Optimization
```csharp
// Use 'using' statements for automatic disposal
using var document = new PdfDocument();
using var page = document.AddPage();

// Dispose of large objects explicitly
var largeImage = page.AddImage("large-image.jpg", 100, 600);
largeImage.Dispose(); // Free memory immediately

// Use object pooling for repeated operations
var fontPool = new FontPool();
fontPool.PreloadFonts("sarabun-regular", "sarabun-bold", "arial");

// Stream processing for large data sources
var csvStream = new CsvStreamDataSource("large-file.csv");
await foreach (var row in csvStream.ReadRowsAsync())
{
    // Process one row at a time
    ProcessRow(row);
}
```

### Batch Processing
```csharp
// Generate multiple PDFs efficiently
var batchGenerator = new PdfBatchGenerator()
    .WithTemplate("invoice-template.xml")
    .WithOutputDirectory("output/")
    .WithConcurrency(Environment.ProcessorCount);

// Process in batches
var customers = GetCustomers(); // 10,000+ customers
await batchGenerator.GenerateAsync(customers, 
    batchSize: 100, 
    fileNamePattern: "invoice-{customer.id}.pdf");
```

### Font Optimization
```csharp
// Preload fonts once
document.Fonts.PreloadFonts(new[] 
{
    "sarabun-regular",
    "sarabun-bold", 
    "arial"
});

// Use font subsetting for large documents
document.Fonts.EnableSubsetting = true; // Only embed used characters

// Cache font metrics
document.Fonts.EnableMetricsCache = true;
```

### Large Document Handling
```csharp
// Enable streaming mode for large documents
var document = new PdfDocument(PdfMode.Streaming);

// Process pages in chunks
const int pageChunkSize = 50;
for (int i = 0; i < totalPages; i += pageChunkSize)
{
    var chunk = data.Skip(i).Take(pageChunkSize);
    ProcessPageChunk(document, chunk);
    
    // Force garbage collection periodically
    if (i % (pageChunkSize * 10) == 0)
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
```

## 🔧 Troubleshooting

### Common Issues

#### Thai Text Not Displaying
```csharp
// Problem: Thai text shows as squares or missing characters
// Solution 1: Ensure Thai font is loaded
document.Fonts.LoadFont("Sarabun-Regular.ttf", "sarabun");
page.AddText("สวัสดี", 100, 700, fontName: "sarabun"); // ✅ Correct

// Solution 2: Check font file encoding
var fontInfo = document.Fonts.GetFontInfo("sarabun");
Console.WriteLine($"Font supports Thai: {fontInfo.SupportsThai}");
Console.WriteLine($"Unicode blocks: {string.Join(", ", fontInfo.UnicodeBlocks)}");

// Solution 3: Use fallback fonts
document.Fonts.SetFallbackChain("sarabun", new[] 
{
    "sarabun-regular",
    "noto-sans-thai",
    "arial-unicode-ms"
});
```

#### Memory Issues with Large Documents
```csharp
// Problem: OutOfMemoryException with large PDFs
// Solution: Use streaming mode and dispose objects
using var document = new PdfDocument(PdfMode.Streaming);

for (int pageNum = 1; pageNum <= totalPages; pageNum++)
{
    using var page = document.AddPage();
    // Add content to page
    
    // Explicitly dispose when done with page
} // Page automatically disposed here

// Monitor memory usage
var memoryBefore = GC.GetTotalMemory(false);
GenerateLargePDF();
var memoryAfter = GC.GetTotalMemory(true);
Console.WriteLine($"Memory used: {(memoryAfter - memoryBefore) / 1024 / 1024} MB");
```

#### Template Parsing Errors
```csharp
try 
{
    var template = TemplateLoader.FromXmlFile("template.xml");
}
catch (TemplateParseException ex)
{
    Console.WriteLine($"Template error at line {ex.LineNumber}: {ex.Message}");
    
    // Common fixes:
    // 1. Check XML syntax and encoding
    // 2. Verify all tags are properly closed
    // 3. Ensure data-source attributes match your data
    // 4. Validate template schema
}

// Enable template validation
var template = TemplateLoader.FromXmlFile("template.xml", validateSchema: true);
```

#### Performance Issues
```csharp
// Problem: Slow PDF generation
// Solution: Profile and optimize

// 1. Use benchmarking
[Benchmark]
public void GeneratePDF()
{
    var document = CreateTestDocument();
    document.SaveToFile("benchmark.pdf");
}

// 2. Enable performance logging  
document.EnablePerformanceLogging = true;
document.SaveToFile("output.pdf");

// Check performance report
var report = document.GetPerformanceReport();
Console.WriteLine($"Font loading: {report.FontLoadingTime}ms");
Console.WriteLine($"Text rendering: {report.TextRenderingTime}ms");
Console.WriteLine($"PDF writing: {report.PdfWritingTime}ms");

// 3. Optimize based on bottlenecks
if (report.FontLoadingTime > 1000)
{
    // Preload fonts
    document.Fonts.PreloadAll();
}
```

### Debugging Tips
```csharp
// Enable detailed logging
var document = new PdfDocument();
document.Logger.SetLevel(LogLevel.Debug);

// Log font loading
document.Fonts.FontLoaded += (sender, args) =>
{
    Console.WriteLine($"Loaded font: {args.FontName} ({args.FilePath})");
};

// Log text rendering
document.TextRendered += (sender, args) =>
{
    Console.WriteLine($"Rendered: '{args.Text}' at ({args.X}, {args.Y})");
};

// Validate PDF output
document.ValidateOnSave = true; // Throws exception if PDF is invalid
```

## 📋 Examples

### Example 1: Simple Invoice
```csharp
using DynamicPDFLibrary.Core;

var document = new PdfDocument();
var page = document.AddPage();

// Load Thai font
document.Fonts.LoadFont("Sarabun-Regular.ttf", "sarabun");
document.Fonts.LoadFont("Sarabun-Bold.ttf", "sarabun-bold");

// Header
page.AddText("ใบแจ้งหนี้", 250, 750, "sarabun-bold", 20, alignment: TextAlignment.Center);

// Company info
page.AddText("บริษัท ABC จำกัด", 100, 700, "sarabun-bold", 14);
page.AddText("123 ถนนสุขุมวิท กรุงเทพฯ 10110", 100, 680, "sarabun", 10);
page.AddText("โทร: 02-123-4567", 100, 665, "sarabun", 10);

// Invoice details
page.AddText($"วันที่: {DateTime.Now:dd/MM/yyyy}", 400, 700, "sarabun", 10);
page.AddText("เลขที่ใบแจ้งหนี้: INV-2025-001", 400, 680, "sarabun", 10);

// Items table (simplified)
page.DrawLine(100, 620, 500, 620, Color.Black, 1);
page.AddText("รายการ", 100, 600, "sarabun-bold", 12);
page.AddText("จำนวน", 250, 600, "sarabun-bold", 12);
page.AddText("ราคาต่อหน่วย", 320, 600, "sarabun-bold", 12);
page.AddText("รวม", 450, 600, "sarabun-bold", 12);
page.DrawLine(100, 590, 500, 590, Color.Black, 1);

// Items
page.AddText("สินค้า A", 100, 570, "sarabun", 10);
page.AddText("2", 250, 570, "sarabun", 10);
page.AddText("฿100.00", 320, 570, "sarabun", 10);
page.AddText("฿200.00", 450, 570, "sarabun", 10);

page.AddText("สินค้า B", 100, 550, "sarabun", 10);
page.AddText("1", 250, 550, "sarabun", 10);
page.AddText("฿150.00", 320, 550, "sarabun", 10);
page.AddText("฿150.00", 450, 550, "sarabun", 10);

// Total
page.DrawLine(100, 530, 500, 530, Color.Black, 1);
page.AddText("รวมทั้งสิ้น", 400, 510, "sarabun-bold", 12);
page.AddText("฿350.00", 450, 510, "sarabun-bold", 12);

document.SaveToFile("thai-invoice.pdf");
document.Dispose();
```

### Example 2: CSV to PDF Report
```csharp
using JayPDFLibs.Core;
using JayPDFLibs.DataSources;
using JayPDFLibs.Templates;

// CSV data with Thai content
var csvData = @"
ชื่อ,ตำแหน่ง,แผนก,เงินเดือน
สมชาย ใจดี,ผู้จัดการ,การขาย,45000
สมหญิง สวยงาม,พนักงาน,บัญชี,25000
สมศักดิ์ รวยเงิน,หัวหน้า,IT,40000
";

// Create data source
var dataSource = new CsvDataSource(csvData, hasHeaders: true);

// Create template
var template = @"
<pdf-template>
  <page size='A4' margins='20,20,20,20'>
    <header>
      <text x='250' y='750' font='sarabun-bold' size='18' align='center'>
        รายงานพนักงาน
      </text>
      <text x='100' y='720' font='sarabun' size='10'>
        วันที่: {{current.date | format:'dd/MM/yyyy'}}
      </text>
    </header>
    
    <body>
      <table x='100' y='680' width='400' border='1'>
        <headers font='sarabun-bold' size='12' background='#f0f0f0'>
          <column width='120'>ชื่อ</column>
          <column width='100'>ตำแหน่ง</column>
          <column width='80'>แผนก</column>
          <column width='100'>เงินเดือน</column>
        </headers>
        
        <rows data-source='employees' font='sarabun' size='10'>
          <column>{{ชื่อ}}</column>
          <column>{{ตำแหน่ง}}</column>
          <column>{{แผนก}}</column>
          <column align='right'>฿{{เงินเดือน | number}}</column>
        </rows>
      </table>
    </body>
  </page>
</pdf-template>";

// Generate PDF
var templateObj = TemplateLoader.FromXmlString(template);
var data = new { employees = dataSource.GetData(), current = new { date = DateTime.Now } };
var document = templateObj.Generate(data);

document.SaveToFile("employee-report.pdf");
document.Dispose();
```

### Example 3: Multi-Page Document with Headers/Footers
```csharp
var document = new PdfDocument();

// Load fonts
document.Fonts.LoadFont("Sarabun-Regular.ttf", "sarabun");
document.Fonts.LoadFont("Sarabun-Bold.ttf", "sarabun-bold");

// Set global header
document.SetHeader((page, pageNumber) =>
{
    page.AddText("รายงานประจำเดือน", 100, 780, "sarabun-bold", 14);
    page.AddText($"เดือน: {DateTime.Now:MMMM yyyy}", 400, 780, "sarabun", 10);
    page.DrawLine(100, 770, 500, 770, Color.Gray, 1);
});

// Set global footer
document.SetFooter((page, pageNumber, totalPages) =>
{
    page.DrawLine(100, 60, 500, 60, Color.Gray, 1);
    page.AddText($"หน้า {pageNumber} จาก {totalPages}", 300, 40, 
        "sarabun", 10, alignment: TextAlignment.Center);
    page.AddText("ลับ", 450, 40, "sarabun", 8, color: Color.Red);
});

// Add multiple pages with content
for (int i = 1; i <= 5; i++)
{
    var page = document.AddPage();
    page.AddText($"เนื้อหาหน้า {i}", 100, 700, "sarabun", 14);
    page.AddText($"นี่คือเนื้อหาของหน้าที่ {i} ในรายงานนี้", 100, 670, "sarabun", 12);
    
    // Add some sample content
    for (int j = 1; j <= 10; j++)
    {
        page.AddText($"รายการที่ {j}: ข้อมูลตัวอย่าง", 120, 640 - (j * 20), "sarabun", 10);
    }
}

document.SaveToFile("multi-page-report.pdf");
document.Dispose();
```

## 🎯 Best Practices

### 1. Resource Management
```csharp
// Always dispose of documents
using var document = new PdfDocument();
// Document will be automatically disposed

// Or use explicit disposal
var document = new PdfDocument();
try
{
    // Generate PDF
}
finally
{
    document.Dispose();
}
```

### 2. Font Loading Strategy
```csharp
// Load fonts once at application startup
public static class FontRegistry 
{
    private static readonly Dictionary<string, string> _fonts = new();
    
    public static void Initialize()
    {
        _fonts["sarabun"] = "assets/fonts/Sarabun-Regular.ttf";
        _fonts["sarabun-bold"] = "assets/fonts/Sarabun-Bold.ttf";
        _fonts["prompt"] = "assets/fonts/Prompt-Regular.ttf";
    }
    
    public static void LoadFonts(PdfDocument document)
    {
        foreach (var font in _fonts)
        {
            document.Fonts.LoadFont(font.Value, font.Key);
        }
    }
}
```

### 3. Error Handling
```csharp
public async Task<byte[]> GeneratePdfAsync(object data)
{
    try
    {
        using var document = new PdfDocument();
        
        // Load template with validation
        var template = await TemplateLoader.FromFileAsync("template.xml", 
            validateSchema: true);
        
        // Generate with error handling
        var pdf = template.Generate(data);
        
        using var stream = new MemoryStream();
        pdf.SaveToStream(stream);
        
        return stream.ToArray();
    }
    catch (TemplateException ex)
    {
        // Handle template-specific errors
        Logger.LogError($"Template error: {ex.Message}");
        throw new ApplicationException("Failed to process template", ex);
    }
    catch (FontException ex)
    {
        // Handle font-related errors
        Logger.LogError($"Font error: {ex.Message}");
        throw new ApplicationException("Font loading failed", ex);
    }
    catch (Exception ex)
    {
        // Handle general errors
        Logger.LogError($"PDF generation failed: {ex.Message}");
        throw;
    }
}
```

### 4. Testing Strategy
```csharp
[Test]
public void Should_Generate_Thai_PDF_Correctly()
{
    // Arrange
    using var document = new PdfDocument();
    document.Fonts.LoadFont("test-fonts/Sarabun-Regular.ttf", "sarabun");
    
    var page = document.AddPage();
    var thaiText = "ทดสอบภาษาไทย";
    
    // Act
    page.AddText(thaiText, 100, 700, "sarabun", 14);
    
    using var stream = new MemoryStream();
    document.SaveToStream(stream);
    
    // Assert
    stream.Length.Should().BeGreaterThan(1000); // PDF has content
    
    // Validate PDF structure
    var pdfBytes = stream.ToArray();
    pdfBytes.Take(4).Should().Equal(new byte[] { 0x25, 0x50, 0x44, 0x46 }); // %PDF
}
```

## 🔗 Additional Resources

### Documentation Links
- [API Reference](../api/README.md) - Complete API documentation
- [Template Reference](template-reference.md) - Detailed template syntax
- [Thai Language Guide](thai-language-guide.md) - Thai-specific features
- [Performance Guide](performance.md) - Optimization techniques

### External Resources
- [PDF Specification](https://www.adobe.com/content/dam/acom/en/devnet/pdf/pdfs/PDF32000_2008.pdf) - Official PDF format reference
- [Thai Typography](https://github.com/solaristhesun/thai-typography) - Thai typography guidelines
- [Google Fonts](https://fonts.google.com/?subset=thai) - Free Thai fonts

### Community
- [GitHub Discussions](https://github.com/yourusername/DynamicPDFLibrary/discussions) - Community support
- [Stack Overflow](https://stackoverflow.com/questions/tagged/dynamicpdflibrary) - Q&A
- [Discord Server](https://discord.gg/dynamicpdflibrary) - Real-time chat

---

Need help? Check our [troubleshooting section](#-troubleshooting) or reach out to the community!