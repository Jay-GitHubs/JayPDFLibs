# Thai Language Guide - Working with Thai Text in PDFs

This comprehensive guide covers everything you need to know about working with Thai language text in JayPDFLibs, from basic setup to advanced typography features.

## 📚 Table of Contents

1. [Thai Language Basics](#-thai-language-basics)
2. [Font Setup and Configuration](#-font-setup-and-configuration)
3. [Text Rendering](#-text-rendering)
4. [Typography and Layout](#-typography-and-layout)
5. [Number and Date Formatting](#-number-and-date-formatting)
6. [Business Applications](#-business-applications)
7. [Troubleshooting](#-troubleshooting)
8. [Best Practices](#-best-practices)

## 🇹🇭 Thai Language Basics

### Character Set Overview
Thai script consists of several character types that require special handling:

```csharp
// Thai consonants (พยัญชนะ)
var consonants = "กขคงจฉชซฌญฎฏฐฑฒณดตถทธนบปผฝพฟภมยรลวศษสหฬอฮ";

// Thai vowels (สระ)
var vowels = "ะาิีึืุูเแโใไ";

// Thai tone marks (วรรณยุกต์)
var toneMarks = "่้๊๋";

// Thai numerals (เลขไทย)
var thaiNumerals = "๐๑๒๓๔๕๖๗๘๙";

// Special characters
var specialChars = "ฯๆ์";
```

### Unicode Ranges
Thai characters are distributed across these Unicode blocks:

| Block | Range | Description |
|-------|-------|-------------|
| Thai | U+0E00–U+0E7F | Main Thai block |
| Thai Extended | U+AA80–U+AADF | Additional characters |

### Text Direction and Layout
- **Reading Direction**: Left-to-right (LTR)
- **Character Positioning**: Complex - vowels and tone marks can appear above, below, before, or after base characters
- **Word Boundaries**: Thai doesn't use spaces between words
- **Line Breaking**: Requires dictionary-based word segmentation

## 🔤 Font Setup and Configuration

### Recommended Thai Fonts

#### Production-Ready Fonts (Open Source)
```csharp
var recommendedFonts = new Dictionary<string, FontInfo>
{
    ["Sarabun"] = new FontInfo
    {
        Family = "Sarabun",
        Source = "Google Fonts",
        Styles = new[] { "Regular", "Bold", "Light", "Medium", "SemiBold", "ExtraBold" },
        BestFor = "Documents, reports, formal text",
        License = "Open Font License",
        DownloadUrl = "https://fonts.google.com/specimen/Sarabun"
    },
    
    ["Prompt"] = new FontInfo
    {
        Family = "Prompt",
        Source = "Google Fonts", 
        Styles = new[] { "Thin", "Light", "Regular", "Medium", "SemiBold", "Bold", "ExtraBold", "Black" },
        BestFor = "UI, presentations, modern designs",
        License = "Open Font License",
        DownloadUrl = "https://fonts.google.com/specimen/Prompt"
    },
    
    ["Kanit"] = new FontInfo
    {
        Family = "Kanit",
        Source = "Google Fonts",
        Styles = new[] { "Thin", "ExtraLight", "Light", "Regular", "Medium", "SemiBold", "Bold", "ExtraBold", "Black" },
        BestFor = "Headings, titles, modern branding",
        License = "Open Font License",
        DownloadUrl = "https://fonts.google.com/specimen/Kanit"
    },
    
    ["Noto Sans Thai"] = new FontInfo
    {
        Family = "Noto Sans Thai",
        Source = "Google Fonts",
        Styles = new[] { "Thin", "ExtraLight", "Light", "Regular", "Medium", "SemiBold", "Bold", "ExtraBold", "Black" },
        BestFor = "Multi-language documents, universal compatibility",
        License = "Open Font License",
        DownloadUrl = "https://fonts.google.com/noto/specimen/Noto+Sans+Thai"
    }
};
```

### Font Installation and Loading
```csharp
using JayPDFLibs.Core;

var document = new PdfDocument();

// Method 1: Load from file system
document.Fonts.LoadFont("fonts/Sarabun-Regular.ttf", "sarabun-regular");
document.Fonts.LoadFont("fonts/Sarabun-Bold.ttf", "sarabun-bold");

// Method 2: Load from embedded resources
document.Fonts.LoadFontFromResource("MyApp.Resources.Fonts.Sarabun-Regular.ttf", "sarabun-regular");

// Method 3: Auto-discover fonts in directory
document.Fonts.LoadFontsFromDirectory("assets/fonts/", recursive: true);

// Method 4: Load font family with multiple weights
var sarabunFamily = new FontFamily("sarabun")
    .AddFont("fonts/Sarabun-Light.ttf", FontWeight.Light)
    .AddFont("fonts/Sarabun-Regular.ttf", FontWeight.Regular)
    .AddFont("fonts/Sarabun-Medium.ttf", FontWeight.Medium)
    .AddFont("fonts/Sarabun-Bold.ttf", FontWeight.Bold);

document.Fonts.RegisterFontFamily(sarabunFamily);
```

### Font Fallback Configuration
```csharp
// Set up font fallback chain for comprehensive character support
document.Fonts.SetFallbackChain("primary-thai", new[]
{
    "sarabun-regular",          // Primary Thai font
    "noto-sans-thai",           // Universal fallback
    "arial-unicode-ms",         // System fallback
    "dejavu-sans"               // Final fallback
});

// Configure automatic fallback detection
document.Fonts.EnableAutoFallback = true;
document.Fonts.FallbackTimeout = TimeSpan.FromMilliseconds(100);

// Test font support
var fontSupport = document.Fonts.TestCharacterSupport("sarabun-regular", "สวัสดี");
Console.WriteLine($"Character support: {fontSupport.SupportedChars}/{fontSupport.TotalChars}");
```

## 📝 Text Rendering

### Basic Thai Text Rendering
```csharp
var page = document.AddPage();

// Simple Thai text
page.AddText("สวัสดีครับ", 100, 700, fontName: "sarabun-regular", fontSize: 16);

// Thai text with formatting
page.AddText("หัวข้อสำคัญ", 100, 670, 
    fontName: "sarabun-bold", 
    fontSize: 18, 
    color: Color.DarkBlue);

// Mixed Thai-English content
page.AddText("บริษัท ABC Company จำกัด", 100, 640, 
    fontName: "sarabun-regular", 
    fontSize: 14);

// Thai text with special characters
var complexText = "กรุงเทพมหานคร อมรรัตนโกสินทร์ มหินทรายุธยา";
page.AddText(complexText, 100, 610, 
    fontName: "sarabun-regular", 
    fontSize: 12);
```

### Multi-line Thai Text
```csharp
// Thai text block with proper word wrapping
var thaiParagraph = @"
ประเทศไทยมีชื่อเป็นทางการว่า ราชอาณาจักรไทย เป็นประเทศที่ตั้งอยู่ในเอเชียตะวันออกเฉียงใต้ 
มีอาณาเขตทางทิศเหนือและทิศตะวันตกติดกับพม่า ทิศตะวันออกติดกับลาวและกัมพูชา 
ทิศใต้ติดกับอ่าวไทยและมาเลเซีย
";

page.AddTextBlock(thaiParagraph.Trim(), 
    x: 100, y: 580, width: 400, height: 100,
    fontName: "sarabun-regular", 
    fontSize: 12,
    lineHeight: 1.6f,
    alignment: TextAlignment.Justify);
```

### Text Measurement and Positioning
```csharp
// Measure Thai text dimensions
var textMetrics = page.MeasureText("ข้อความทดสอบ", "sarabun-regular", 14);
Console.WriteLine($"Width: {textMetrics.Width}, Height: {textMetrics.Height}");

// Center Thai text precisely
var centerX = (page.Width - textMetrics.Width) / 2;
page.AddText("ข้อความกลางหน้า", centerX, 500, "sarabun-regular", 14);

// Align Thai text to baseline
var baselineY = 450;
page.AddText("ข้อความบรรทัดฐาน", 100, baselineY, 
    fontName: "sarabun-regular", 
    fontSize: 12,
    baselineAlignment: BaselineAlignment.Baseline);
```

## 🎨 Typography and Layout

### Character Positioning and Spacing
```csharp
// Adjust character spacing for Thai text
page.AddText("ก า ร เ ว ้ น ร ะ ย ะ", 100, 420,
    fontName: "sarabun-regular",
    fontSize: 14,
    letterSpacing: 2.0f); // Increase letter spacing

// Adjust word spacing
page.AddText("คำ หนึ่ง คำ สอง คำ สาม", 100, 400,
    fontName: "sarabun-regular", 
    fontSize: 14,
    wordSpacing: 1.5f);

// Line height adjustment for Thai text
var thaiLines = new[] { "บรรทัดที่หนึ่ง", "บรรทัดที่สอง", "บรรทัดที่สาม" };
for (int i = 0; i < thaiLines.Length; i++)
{
    page.AddText(thaiLines[i], 100, 380 - (i * 25), 
        fontName: "sarabun-regular", 
        fontSize: 14);
}
```

### Thai Text Styling
```csharp
// Bold Thai text
page.AddText("ตัวหนา", 100, 350, 
    fontName: "sarabun-bold", 
    fontSize: 14, 
    fontStyle: FontStyle.Bold);

// Underlined Thai text  
page.AddText("ขีดเส้นใต้", 100, 330,
    fontName: "sarabun-regular",
    fontSize: 14,
    textDecoration: TextDecoration.Underline);

// Colored Thai text
page.AddText("ข้อความสี", 100, 310,
    fontName: "sarabun-regular",
    fontSize: 14, 
    color: Color.FromRgb(220, 20, 60)); // Crimson

// Background highlight
page.AddText("ไฮไลท์", 100, 290,
    fontName: "sarabun-regular",
    fontSize: 14,
    backgroundColor: Color.Yellow);
```

### Thai Typography Rules
```csharp
// Proper Thai punctuation handling
var thaiSentence = "นี่คือประโยคภาษาไทย ใช้เครื่องหมายวรรคตอนถูกต้อง";
page.AddText(thaiSentence, 100, 270, "sarabun-regular", 12);

// Thai quotation marks
var quotedText = "\"คำพูดในเครื่องหมายคำพูด\" และ 'คำพูดเดี่ยว'";
page.AddText(quotedText, 100, 250, "sarabun-regular", 12);

// Thai bullet points
var bulletPoints = new[]
{
    "• รายการที่หนึ่ง",
    "• รายการที่สอง", 
    "• รายการที่สาม"
};

for (int i = 0; i < bulletPoints.Length; i++)
{
    page.AddText(bulletPoints[i], 120, 230 - (i * 20), "sarabun-regular", 11);
}
```

## 🔢 Number and Date Formatting

### Thai Numeral Conversion
```csharp
// Arabic to Thai numeral conversion
var numbers = new[] { "123", "4567", "89.50", "1,234,567" };
foreach (var number in numbers)
{
    var thaiNumber = ConvertToThaiNumerals(number);
    page.AddText($"Arabic: {number} = Thai: {thaiNumber}", 
        100, yPosition, "sarabun-regular", 12);
    yPosition -= 20;
}

// Helper method for Thai numeral conversion
string ConvertToThaiNumerals(string arabicNumber)
{
    var mapping = new Dictionary<char, char>
    {
        ['0'] = '๐', ['1'] = '๑', ['2'] = '๒', ['3'] = '๓', ['4'] = '๔',
        ['5'] = '๕', ['6'] = '๖', ['7'] = '๗', ['8'] = '๘', ['9'] = '๙'
    };
    
    return string.Join("", arabicNumber.Select(c => mapping.GetValueOrDefault(c, c)));
}
```

### Thai Currency Formatting
```csharp
// Currency formatting with Thai baht symbol
var amounts = new[] { 100.50m, 1234.75m, 50000m };
foreach (var amount in amounts)
{
    // Standard format
    page.AddText($"฿{amount:N2}", 100, yPosition, "sarabun-regular", 12);
    
    // Thai numerals
    var thaiAmount = ConvertToThaiNumerals(amount.ToString("N2"));
    page.AddText($"฿{thaiAmount}", 200, yPosition, "sarabun-regular", 12);
    
    yPosition -= 20;
}

// Amount in Thai words
page.AddText(ConvertAmountToThaiWords(1234.56m), 100, yPosition, "sarabun-regular", 10);

string ConvertAmountToThaiWords(decimal amount)
{
    // Implementation for converting numbers to Thai words
    // Example: 1234.56 -> "หนึ่งพันสองร้อยสามสิบสี่บาทห้าสิบหกสตางค์"
    return ThaiNumberToWords.Convert(amount);
}
```

### Thai Date Formatting
```csharp
var date = DateTime.Now;

// Standard Thai date formats
var thaiDates = new[]
{
    FormatThaiDate(date, "dd/MM/yyyy"),      // 15/01/2568
    FormatThaiDate(date, "dd MMMM yyyy"),    // 15 มกราคม 2568  
    FormatThaiDate(date, "dddd dd MMMM yyyy"), // วันจันทร์ 15 มกราคม 2568
    FormatBuddhistDate(date)                  // 15 มกราคม พ.ศ. 2568
};

foreach (var thaiDate in thaiDates)
{
    page.AddText(thaiDate, 100, yPosition, "sarabun-regular", 12);
    yPosition -= 20;
}

// Helper methods
string FormatThaiDate(DateTime date, string format)
{
    var thaiCulture = new CultureInfo("th-TH");
    var buddhistDate = date.AddYears(543); // Convert to Buddhist era
    return buddhistDate.ToString(format, thaiCulture);
}

string FormatBuddhistDate(DateTime date)
{
    var buddhistYear = date.Year + 543;
    var thaiMonths = new[]
    {
        "", "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน",
        "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม"
    };
    
    return $"{date.Day} {thaiMonths[date.Month]} พ.ศ. {buddhistYear}";
}
```

## 💼 Business Applications

### Thai Invoice Template
```csharp
void CreateThaiInvoice(InvoiceData invoice)
{
    var document = new PdfDocument();
    document.Fonts.LoadFont("Sarabun-Regular.ttf", "sarabun");
    document.Fonts.LoadFont("Sarabun-Bold.ttf", "sarabun-bold");
    
    var page = document.AddPage();
    
    // Invoice header
    page.AddText("ใบแจ้งหนี้", 250, 750, "sarabun-bold", 20, alignment: TextAlignment.Center);
    page.AddText("INVOICE", 250, 725, "sarabun", 14, alignment: TextAlignment.Center);
    
    // Company information
    var companyInfo = new[]
    {
        invoice.Company.ThaiName,
        invoice.Company.EnglishName,
        invoice.Company.Address,
        $"เลขประจำตัวผู้เสียภาษี: {invoice.Company.TaxId}",
        $"โทรศัพท์: {invoice.Company.Phone}"
    };
    
    float yPos = 680;
    foreach (var info in companyInfo)
    {
        page.AddText(info, 100, yPos, "sarabun", 10);
        yPos -= 15;
    }
    
    // Invoice details
    page.AddText($"เลขที่ใบแจ้งหนี้: {invoice.Number}", 350, 680, "sarabun", 10);
    page.AddText($"วันที่: {FormatThaiDate(invoice.Date, "dd MMMM yyyy")}", 350, 665, "sarabun", 10);
    page.AddText($"กำหนดชำระ: {FormatThaiDate(invoice.DueDate, "dd MMMM yyyy")}", 350, 650, "sarabun", 10);
    
    // Items table
    CreateThaiInvoiceTable(page, invoice.Items, yPos - 50);
    
    document.SaveToFile($"invoice-{invoice.Number}.pdf");
}

void CreateThaiInvoiceTable(PdfPage page, List<InvoiceItem> items, float startY)
{
    var table = page.CreateTable(100, startY, 400)
        .SetFont("sarabun", 10)
        .SetBorder(Color.Black, 1);
    
    // Headers
    table.AddHeaderRow()
        .AddCell("รายการสินค้า/บริการ", 200, "sarabun-bold")
        .AddCell("จำนวน", 60, "sarabun-bold", TextAlignment.Center)
        .AddCell("ราคาต่อหน่วย", 70, "sarabun-bold", TextAlignment.Right)
        .AddCell("จำนวนเงิน", 70, "sarabun-bold", TextAlignment.Right);
    
    // Data rows
    foreach (var item in items)
    {
        table.AddRow()
            .AddCell(item.Description)
            .AddCell(ConvertToThaiNumerals(item.Quantity.ToString()), alignment: TextAlignment.Center)
            .AddCell($"฿{ConvertToThaiNumerals(item.UnitPrice.ToString("N2"))}", alignment: TextAlignment.Right)
            .AddCell($"฿{ConvertToThaiNumerals(item.TotalPrice.ToString("N2"))}", alignment: TextAlignment.Right);
    }
    
    // Totals
    var subtotal = items.Sum(i => i.TotalPrice);
    var vat = subtotal * 0.07m;
    var total = subtotal + vat;
    
    table.AddFooterRow()
        .AddCell("รวมย่อย", colspan: 3, alignment: TextAlignment.Right, font: "sarabun-bold")
        .AddCell($"฿{ConvertToThaiNumerals(subtotal.ToString("N2"))}", alignment: TextAlignment.Right);
        
    table.AddFooterRow()
        .AddCell("ภาษีมูลค่าเพิ่ม 7%", colspan: 3, alignment: TextAlignment.Right, font: "sarabun-bold")
        .AddCell($"฿{ConvertToThaiNumerals(vat.ToString("N2"))}", alignment: TextAlignment.Right);
        
    table.AddFooterRow(backgroundColor: Color.LightGray)
        .AddCell("รวมทั้งสิ้น", colspan: 3, alignment: TextAlignment.Right, font: "sarabun-bold")
        .AddCell($"฿{ConvertToThaiNumerals(total.ToString("N2"))}", alignment: TextAlignment.Right, font: "sarabun-bold");
}
```

### Thai Address Formatting
```csharp
public class ThaiAddress
{
    public string HouseNumber { get; set; }
    public string Moo { get; set; }
    public string Soi { get; set; }
    public string Road { get; set; }
    public string Subdistrict { get; set; }
    public string District { get; set; }
    public string Province { get; set; }
    public string PostalCode { get; set; }
    
    public string FormatFullAddress()
    {
        var parts = new List<string>();
        
        if (!string.IsNullOrEmpty(HouseNumber)) parts.Add($"บ้านเลขที่ {HouseNumber}");
        if (!string.IsNullOrEmpty(Moo)) parts.Add($"หมู่ {Moo}");
        if (!string.IsNullOrEmpty(Soi)) parts.Add($"ซอย{Soi}");
        if (!string.IsNullOrEmpty(Road)) parts.Add($"ถนน{Road}");
        if (!string.IsNullOrEmpty(Subdistrict)) parts.Add($"ตำบล{Subdistrict}");
        if (!string.IsNullOrEmpty(District)) parts.Add($"อำเภอ{District}");
        if (!string.IsNullOrEmpty(Province)) parts.Add($"จังหวัด{Province}");
        if (!string.IsNullOrEmpty(PostalCode)) parts.Add(PostalCode);
        
        return string.Join(" ", parts);
    }
}

// Usage in PDF
void AddThaiAddress(PdfPage page, ThaiAddress address, float x, float y)
{
    var formattedAddress = address.FormatFullAddress();
    page.AddTextBlock(formattedAddress, x, y, 250, 60, 
        fontName: "sarabun", 
        fontSize: 10, 
        lineHeight: 1.4f);
}
```

### Thai Business Forms
```csharp
// Receipt (ใบเสร็จรับเงิน)
void CreateThaiReceipt(ReceiptData receipt)
{
    var document = new PdfDocument();
    var page = document.AddPage(PageSize.A5); // Smaller size for receipt
    
    // Header
    page.AddText("ใบเสร็จรับเงิน", 150, 400, "sarabun-bold", 16, TextAlignment.Center);
    page.AddText("RECEIPT", 150, 380, "sarabun", 12, TextAlignment.Center);
    
    // Receipt details
    page.AddText($"เลขที่: {receipt.Number}", 50, 350, "sarabun", 10);
    page.AddText($"วันที่: {FormatThaiDate(receipt.Date, "dd MMMM yyyy")}", 200, 350, "sarabun", 10);
    
    page.AddText($"ได้รับเงินจาก: {receipt.CustomerName}", 50, 320, "sarabun", 10);
    page.AddText($"จำนวนเงิน: ฿{ConvertToThaiNumerals(receipt.Amount.ToString("N2"))}", 50, 300, "sarabun", 10);
    page.AddText($"({ConvertAmountToThaiWords(receipt.Amount)})", 50, 280, "sarabun", 9);
    page.AddText($"สำหรับ: {receipt.Description}", 50, 260, "sarabun", 10);
    
    // Signature section
    page.DrawLine(200, 200, 280, 200, Color.Black, 1);
    page.AddText("ผู้รับเงิน", 220, 185, "sarabun", 9, TextAlignment.Center);
}

// Purchase Order (ใบสั่งซื้อ)
void CreateThaiPurchaseOrder(PurchaseOrderData po)
{
    var document = new PdfDocument();
    var page = document.AddPage();
    
    // Header
    page.AddText("ใบสั่งซื้อ", 250, 750, "sarabun-bold", 18, TextAlignment.Center);
    page.AddText("PURCHASE ORDER", 250, 730, "sarabun", 14, TextAlignment.Center);
    
    // PO details
    page.AddText($"เลขที่ใบสั่งซื้อ: {po.Number}", 100, 700, "sarabun-bold", 12);
    page.AddText($"วันที่สั่ง: {FormatThaiDate(po.OrderDate, "dd MMMM yyyy")}", 350, 700, "sarabun", 10);
    page.AddText($"กำหนดส่ง: {FormatThaiDate(po.DeliveryDate, "dd MMMM yyyy")}", 350, 680, "sarabun", 10);
    
    // Vendor info
    page.AddText("ข้อมูลผู้ขาย:", 100, 660, "sarabun-bold", 12);
    AddThaiAddress(page, po.Vendor.Address, 100, 620);
    
    // Items table
    CreatePurchaseOrderTable(page, po.Items, 550);
}
```

## 🔧 Troubleshooting

### Common Thai Text Issues

#### Issue 1: Thai Characters Not Displaying
```csharp
// Problem: Thai text shows as squares or boxes
// Solution: Check font loading and character support

// Debug font loading
try 
{
    document.Fonts.LoadFont("Sarabun-Regular.ttf", "sarabun");
    var fontInfo = document.Fonts.GetFontInfo("sarabun");
    
    Console.WriteLine($"Font loaded: {fontInfo.IsLoaded}");
    Console.WriteLine($"Supports Thai: {fontInfo.SupportsThai}");
    Console.WriteLine($"Character count: {fontInfo.CharacterCount}");
    
    // Test specific characters
    var testChars = "กขคง";
    foreach (char c in testChars)
    {
        var supported = fontInfo.SupportsCharacter(c);
        Console.WriteLine($"Character '{c}' (U+{((int)c):X4}): {supported}");
    }
}
catch (FontLoadException ex)
{
    Console.WriteLine($"Font loading failed: {ex.Message}");
    // Use fallback font
    document.Fonts.LoadFont("NotoSansThai-Regular.ttf", "sarabun");
}
```

#### Issue 2: Incorrect Character Positioning
```csharp
// Problem: Tone marks or vowels appear in wrong positions
// Solution: Enable complex text layout

var textOptions = new TextRenderingOptions
{
    EnableComplexTextLayout = true,
    TextDirection = TextDirection.LeftToRight,
    Script = Script.Thai,
    Language = "th-TH"
};

page.AddText("กำ่ก้ก๊ก๋", 100, 600, "sarabun", 16, options: textOptions);

// Verify character clustering
var textAnalysis = TextAnalyzer.Analyze("กำ่ก้ก๊ก๋", "th-TH");
foreach (var cluster in textAnalysis.Clusters)
{
    Console.WriteLine($"Cluster: {cluster.Text}, Characters: {cluster.CharacterCount}");
}
```

#### Issue 3: Word Breaking Problems
```csharp
// Problem: Thai text breaks in wrong places
// Solution: Use Thai word segmentation

var thaiText = "ประเทศไทยเป็นประเทศที่สวยงาม";

// Enable Thai word breaking
var breakOptions = new LineBreakOptions
{
    Language = "th-TH",
    UseWordBreaking = true,
    BreakAlgorithm = BreakAlgorithm.Dictionary,
    HyphenationEnabled = false // Thai doesn't use hyphenation
};

page.AddTextBlock(thaiText, 100, 500, 300, 100, 
    fontName: "sarabun", 
    fontSize: 12,
    lineBreakOptions: breakOptions);

// Manual word segmentation if needed
var segments = ThaiWordSegmenter.Segment(thaiText);
Console.WriteLine($"Word segments: {string.Join(" | ", segments)}");
```

### Performance Issues

#### Slow Thai Text Rendering
```csharp
// Problem: Thai text rendering is slow
// Solutions:

// 1. Preload and cache fonts
FontCache.PreloadFonts(new[] { "sarabun", "sarabun-bold" });

// 2. Use font subsetting
document.Fonts.EnableSubsetting = true;

// 3. Batch similar text operations
var textBatch = new TextBatch("sarabun", 12);
textBatch.AddText("ข้อความที่ 1", 100, 600);
textBatch.AddText("ข้อความที่ 2", 100, 580);
textBatch.AddText("ข้อความที่ 3", 100, 560);
page.RenderTextBatch(textBatch); // Render all at once

// 4. Disable complex layout for simple text
var simpleOptions = new TextRenderingOptions
{
    EnableComplexTextLayout = false, // Only for simple Thai text without tone marks
    CacheGlyphMetrics = true
};
```

#### Memory Usage with Thai Fonts
```csharp
// Problem: High memory usage with Thai fonts
// Solutions:

// 1. Use font streaming for large documents
var streamingFont = new StreamingFont("Sarabun-Regular.ttf");
document.Fonts.Register("sarabun", streamingFont);

// 2. Dispose of fonts when not needed
using var document = new PdfDocument();
// Fonts will be automatically disposed

// 3. Monitor memory usage
var memoryBefore = GC.GetTotalMemory(false);
RenderThaiDocument();
var memoryAfter = GC.GetTotalMemory(true);
Console.WriteLine($"Memory used: {(memoryAfter - memoryBefore) / 1024 / 1024} MB");
```

## 📋 Best Practices

### Font Management
```csharp
// 1. Create a centralized font manager
public static class ThaiFontManager
{
    private static readonly Dictionary<string, FontInfo> _fonts = new();
    
    static ThaiFontManager()
    {
        RegisterStandardFonts();
    }
    
    private static void RegisterStandardFonts()
    {
        _fonts["sarabun-regular"] = new FontInfo("fonts/Sarabun-Regular.ttf");
        _fonts["sarabun-bold"] = new FontInfo("fonts/Sarabun-Bold.ttf");
        _fonts["prompt-regular"] = new FontInfo("fonts/Prompt-Regular.ttf");
    }
    
    public static void LoadFonts(PdfDocument document)
    {
        foreach (var font in _fonts)
        {
            document.Fonts.LoadFont(font.Value.Path, font.Key);
        }
        
        // Set up fallback chains
        document.Fonts.SetFallbackChain("sarabun-regular", new[]
        {
            "sarabun-regular", "noto-sans-thai", "arial-unicode-ms"
        });
    }
}

// 2. Validate Thai text before rendering
public static class ThaiTextValidator
{
    public static ValidationResult ValidateThaiText(string text, string fontName)
    {
        var result = new ValidationResult();
        
        // Check for unsupported characters
        var font = FontRegistry.GetFont(fontName);
        foreach (char c in text)
        {
            if (IsThaiCharacter(c) && !font.SupportsCharacter(c))
            {
                result.UnsupportedCharacters.Add(c);
            }
        }
        
        // Check for proper text structure
        if (HasIncorrectCharacterOrder(text))
        {
            result.Warnings.Add("Text may have incorrect character ordering");
        }
        
        return result;
    }
    
    private static bool IsThaiCharacter(char c)
    {
        return c >= 0x0E00 && c <= 0x0E7F; // Thai Unicode block
    }
}
```

### Text Layout Guidelines
```csharp
// 1. Use appropriate line heights for Thai text
public static class ThaiTextLayout
{
    public const float RecommendedLineHeight = 1.6f; // 60% more than font size
    public const float MinimumLineHeight = 1.4f;
    public const float MaximumLineHeight = 2.0f;
    
    public static float CalculateOptimalLineHeight(float fontSize, bool hasComplexCharacters)
    {
        var baseHeight = fontSize * RecommendedLineHeight;
        
        // Increase line height for text with tone marks
        if (hasComplexCharacters)
        {
            baseHeight *= 1.1f;
        }
        
        return Math.Max(baseHeight, fontSize * MinimumLineHeight);
    }
    
    public static TextLayoutOptions GetDefaultThaiLayout()
    {
        return new TextLayoutOptions
        {
            LineHeight = RecommendedLineHeight,
            WordBreaking = WordBreakingMode.Dictionary,
            TextDirection = TextDirection.LeftToRight,
            Justification = JustificationMode.InterWord,
            HangingPunctuation = true
        };
    }
}

// 2. Handle mixed Thai-English content properly
public static void AddMixedContent(PdfPage page, string text, float x, float y)
{
    var segments = SeparateThaiEnglish(text);
    float currentX = x;
    
    foreach (var segment in segments)
    {
        var fontName = segment.IsThaiText ? "sarabun-regular" : "arial";
        var textWidth = page.MeasureText(segment.Text, fontName, 12).Width;
        
        page.AddText(segment.Text, currentX, y, fontName, 12);
        currentX += textWidth + 2; // Small spacing between segments
    }
}

private static List<TextSegment> SeparateThaiEnglish(string text)
{
    var segments = new List<TextSegment>();
    var currentSegment = new StringBuilder();
    bool? isCurrentThai = null;
    
    foreach (char c in text)
    {
        bool isThaiChar = IsThaiCharacter(c);
        
        if (isCurrentThai == null)
        {
            isCurrentThai = isThaiChar;
        }
        else if (isCurrentThai != isThaiChar)
        {
            // Language change - save current segment and start new one
            if (currentSegment.Length > 0)
            {
                segments.Add(new TextSegment(currentSegment.ToString(), isCurrentThai.Value));
                currentSegment.Clear();
            }
            isCurrentThai = isThaiChar;
        }
        
        currentSegment.Append(c);
    }
    
    // Add final segment
    if (currentSegment.Length > 0)
    {
        segments.Add(new TextSegment(currentSegment.ToString(), isCurrentThai ?? false));
    }
    
    return segments;
}
```

### Document Structure Best Practices
```csharp
// 1. Create a Thai document template base class
public abstract class ThaiDocumentBase
{
    protected PdfDocument Document { get; private set; }
    protected readonly Dictionary<string, string> _fonts;
    
    protected ThaiDocumentBase()
    {
        Document = new PdfDocument();
        _fonts = new Dictionary<string, string>
        {
            ["thai-regular"] = "sarabun-regular",
            ["thai-bold"] = "sarabun-bold",
            ["thai-light"] = "sarabun-light",
            ["english-regular"] = "arial",
            ["english-bold"] = "arial-bold"
        };
        
        SetupFonts();
        SetupDocumentProperties();
    }
    
    private void SetupFonts()
    {
        ThaiFontManager.LoadFonts(Document);
        
        // Configure text rendering defaults
        Document.DefaultTextOptions = new TextRenderingOptions
        {
            EnableComplexTextLayout = true,
            Script = Script.Thai,
            Language = "th-TH"
        };
    }
    
    private void SetupDocumentProperties()
    {
        Document.Author = "DynamicPDFLibrary";
        Document.Creator = "Thai Document Generator";
        Document.Language = "th-TH";
        Document.TextDirection = TextDirection.LeftToRight;
    }
    
    protected PdfPage CreateStandardPage()
    {
        var page = Document.AddPage(PageSize.A4);
        page.SetMargins(20, 30, 20, 40); // Standard Thai document margins
        return page;
    }
    
    protected void AddThaiHeader(PdfPage page, string title, string subtitle = null)
    {
        var titleFont = _fonts["thai-bold"];
        var subtitleFont = _fonts["thai-regular"];
        
        page.AddText(title, page.Width / 2, 750, titleFont, 18, 
            alignment: TextAlignment.Center);
        
        if (!string.IsNullOrEmpty(subtitle))
        {
            page.AddText(subtitle, page.Width / 2, 725, subtitleFont, 14,
                alignment: TextAlignment.Center);
        }
        
        // Add decorative line
        page.DrawLine(100, 700, page.Width - 100, 700, Color.Gray, 1);
    }
    
    public virtual void Save(string filePath)
    {
        Document.SaveToFile(filePath);
    }
    
    public virtual void Dispose()
    {
        Document?.Dispose();
    }
}

// 2. Implementation example: Thai Invoice
public class ThaiInvoiceDocument : ThaiDocumentBase
{
    public void CreateInvoice(InvoiceData invoice)
    {
        var page = CreateStandardPage();
        
        AddThaiHeader(page, "ใบแจ้งหนี้", "INVOICE");
        
        // Company info section
        AddCompanyInfo(page, invoice.Company, 100, 650);
        
        // Customer info section  
        AddCustomerInfo(page, invoice.Customer, 300, 650);
        
        // Invoice details
        AddInvoiceDetails(page, invoice, 100, 550);
        
        // Items table
        AddItemsTable(page, invoice.Items, 100, 450);
        
        // Total section
        AddTotalSection(page, invoice, 300, 250);
        
        // Footer
        AddThaiFooter(page, invoice);
    }
    
    private void AddCompanyInfo(PdfPage page, CompanyInfo company, float x, float y)
    {
        var font = _fonts["thai-regular"];
        float lineHeight = 15;
        float currentY = y;
        
        var lines = new[]
        {
            company.ThaiName,
            company.EnglishName,
            company.Address.FormatFullAddress(),
            $"เลขประจำตัวผู้เสียภาษี: {company.TaxId}",
            $"โทรศัพท์: {company.Phone}"
        };
        
        foreach (var line in lines)
        {
            if (!string.IsNullOrEmpty(line))
            {
                page.AddText(line, x, currentY, font, 10);
                currentY -= lineHeight;
            }
        }
    }
    
    private void AddItemsTable(PdfPage page, List<InvoiceItem> items, float x, float y)
    {
        var table = new ThaiTable(page, x, y, 400);
        
        // Configure Thai table settings
        table.SetDefaultFont(_fonts["thai-regular"], 10)
             .SetHeaderFont(_fonts["thai-bold"], 11)
             .SetBorderStyle(BorderStyle.Solid, Color.Black, 1)
             .SetAlternatingRowColors(Color.White, Color.FromRgb(248, 249, 250));
        
        // Add headers
        table.AddHeader("รายการสินค้า/บริการ", 200)
             .AddHeader("จำนวน", 60, TextAlignment.Center)
             .AddHeader("ราคาต่อหน่วย", 70, TextAlignment.Right)
             .AddHeader("จำนวนเงิน", 70, TextAlignment.Right);
        
        // Add data rows
        foreach (var item in items)
        {
            table.AddRow()
                 .AddCell(item.ThaiDescription)
                 .AddCell(FormatThaiNumber(item.Quantity), TextAlignment.Center)
                 .AddCell($"฿{FormatThaiCurrency(item.UnitPrice)}", TextAlignment.Right)
                 .AddCell($"฿{FormatThaiCurrency(item.TotalPrice)}", TextAlignment.Right);
        }
        
        // Add totals
        var subtotal = items.Sum(i => i.TotalPrice);
        var vat = subtotal * 0.07m;
        var total = subtotal + vat;
        
        table.AddFooterRow()
             .AddCell("รวมย่อย", colspan: 3, alignment: TextAlignment.Right)
             .AddCell($"฿{FormatThaiCurrency(subtotal)}", TextAlignment.Right);
             
        table.AddFooterRow()
             .AddCell("ภาษีมูลค่าเพิ่ม 7%", colspan: 3, alignment: TextAlignment.Right)
             .AddCell($"฿{FormatThaiCurrency(vat)}", TextAlignment.Right);
             
        table.AddFooterRow(backgroundColor: Color.FromRgb(230, 243, 255))
             .AddCell("รวมทั้งสิ้น", colspan: 3, alignment: TextAlignment.Right, font: _fonts["thai-bold"])
             .AddCell($"฿{FormatThaiCurrency(total)}", TextAlignment.Right, font: _fonts["thai-bold"]);
        
        table.Render();
    }
}
```

### Testing Thai Text Rendering
```csharp
// Unit tests for Thai text functionality
[TestFixture]
public class ThaiTextRenderingTests
{
    private PdfDocument _document;
    private PdfPage _page;
    
    [SetUp]
    public void Setup()
    {
        _document = new PdfDocument();
        ThaiFontManager.LoadFonts(_document);
        _page = _document.AddPage();
    }
    
    [TearDown]
    public void TearDown()
    {
        _document?.Dispose();
    }
    
    [Test]
    public void Should_Render_Basic_Thai_Text()
    {
        // Arrange
        var thaiText = "สวัสดีครับ";
        
        // Act
        _page.AddText(thaiText, 100, 700, "sarabun-regular", 14);
        
        // Assert
        var renderedText = _page.GetRenderedText();
        Assert.That(renderedText, Contains.Substring(thaiText));
    }
    
    [Test]
    public void Should_Handle_Complex_Thai_Characters()
    {
        // Arrange - Text with tone marks and complex combinations
        var complexText = "กำ่ก้ก๊ก๋";
        
        // Act
        _page.AddText(complexText, 100, 700, "sarabun-regular", 14);
        
        // Assert
        var textBounds = _page.GetTextBounds(complexText, "sarabun-regular", 14);
        Assert.That(textBounds.Width, Is.GreaterThan(0));
        Assert.That(textBounds.Height, Is.GreaterThan(0));
    }
    
    [Test]
    public void Should_Format_Thai_Currency_Correctly()
    {
        // Arrange
        var amount = 1234.56m;
        
        // Act
        var formattedAmount = FormatThaiCurrency(amount);
        
        // Assert
        Assert.That(formattedAmount, Is.EqualTo("๑,๒๓๔.๕๖"));
    }
    
    [Test]
    public void Should_Convert_Amount_To_Thai_Words()
    {
        // Arrange
        var amount = 1234.56m;
        
        // Act
        var thaiWords = ConvertAmountToThaiWords(amount);
        
        // Assert
        Assert.That(thaiWords, Is.EqualTo("หนึ่งพันสองร้อยสามสิบสี่บาทห้าสิบหกสตางค์"));
    }
    
    [Test]
    public void Should_Break_Thai_Text_At_Word_Boundaries()
    {
        // Arrange
        var longThaiText = "ประเทศไทยเป็นประเทศที่มีความสวยงามและมีวัฒนธรรมที่เก่าแก่";
        
        // Act
        _page.AddTextBlock(longThaiText, 100, 600, 200, 100, 
            "sarabun-regular", 12, 
            lineBreakOptions: new LineBreakOptions 
            { 
                Language = "th-TH", 
                UseWordBreaking = true 
            });
        
        // Assert
        var lines = _page.GetRenderedLines();
        Assert.That(lines.Count, Is.GreaterThan(1));
        
        // Verify no words are broken mid-character
        foreach (var line in lines)
        {
            Assert.That(line.Text, Does.Not.EndWith("ก")); // Should not break mid-word
        }
    }
}

// Performance tests for Thai text
[TestFixture]
public class ThaiTextPerformanceTests
{
    [Test]
    public void Thai_Text_Rendering_Should_Meet_Performance_Requirements()
    {
        // Arrange
        var document = new PdfDocument();
        ThaiFontManager.LoadFonts(document);
        var page = document.AddPage();
        
        var thaiTexts = GenerateThaiTextSamples(1000);
        var stopwatch = Stopwatch.StartNew();
        
        // Act
        foreach (var text in thaiTexts)
        {
            page.AddText(text, 100, 700 - (Array.IndexOf(thaiTexts, text) * 0.5f), 
                "sarabun-regular", 10);
        }
        
        stopwatch.Stop();
        
        // Assert - Should render 1000 Thai texts in under 2 seconds
        Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(2000));
        
        document.Dispose();
    }
    
    private string[] GenerateThaiTextSamples(int count)
    {
        var samples = new string[count];
        var thaiWords = new[] 
        { 
            "ประเทศไทย", "สวัสดี", "ยินดีต้อนรับ", "ขอบคุณ", 
            "โรงเรียน", "มหาวิทยาลัย", "โรงพยาบาล", "ตลาด" 
        };
        
        var random = new Random(42); // Fixed seed for consistent tests
        
        for (int i = 0; i < count; i++)
        {
            var wordCount = random.Next(1, 5);
            var words = new List<string>();
            
            for (int j = 0; j < wordCount; j++)
            {
                words.Add(thaiWords[random.Next(thaiWords.Length)]);
            }
            
            samples[i] = string.Join(" ", words);
        }
        
        return samples;
    }
}
```

## 📈 Advanced Thai Features

### Thai Collation and Sorting
```csharp
public static class ThaiCollation
{
    // Thai alphabetical order (different from Unicode order)
    private static readonly string ThaiOrder = 
        "กขฃคฅฆงจฉชซฌญฎฏฐฑฒณดตถทธนบปผฝพฟภมยรฤลฦวศษสหฬอฮ";
    
    public static int CompareThaiStrings(string str1, string str2)
    {
        var normalized1 = NormalizeThaiString(str1);
        var normalized2 = NormalizeThaiString(str2);
        
        return String.Compare(normalized1, normalized2, 
            CultureInfo.CreateSpecificCulture("th-TH"), 
            CompareOptions.StringSort);
    }
    
    public static string NormalizeThaiString(string input)
    {
        // Remove tone marks for sorting purposes
        var normalized = new StringBuilder();
        
        foreach (char c in input)
        {
            if (!IsThaiToneMark(c))
            {
                normalized.Append(c);
            }
        }
        
        return normalized.ToString();
    }
    
    public static bool IsThaiToneMark(char c)
    {
        return c >= 0x0E48 && c <= 0x0E4B; // Thai tone marks
    }
    
    public static List<string> SortThaiStrings(IEnumerable<string> strings)
    {
        return strings.OrderBy(s => s, new ThaiStringComparer()).ToList();
    }
}

public class ThaiStringComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        return ThaiCollation.CompareThaiStrings(x, y);
    }
}
```

### Thai Date and Calendar Support
```csharp
public static class ThaiCalendar
{
    private static readonly string[] ThaiMonthNames = 
    {
        "", "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน",
        "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม"
    };
    
    private static readonly string[] ThaiDayNames =
    {
        "อาทิตย์", "จันทร์", "อังคาร", "พุธ", "พฤหัสบดี", "ศุกร์", "เสาร์"
    };
    
    private static readonly Dictionary<DateTime, string> ThaiHolidays = 
        new Dictionary<DateTime, string>
        {
            [new DateTime(2025, 1, 1)] = "วันปีใหม่",
            [new DateTime(2025, 2, 12)] = "วันมาฆบูชา",
            [new DateTime(2025, 4, 6)] = "วันจักรี",
            [new DateTime(2025, 4, 13)] = "วันสงกรานต์",
            [new DateTime(2025, 5, 1)] = "วันแรงงาน",
            [new DateTime(2025, 5, 11)] = "วันวิสาขบูชา",
            [new DateTime(2025, 7, 28)] = "วันเฉลิมพระชนมพรรษา",
            [new DateTime(2025, 8, 12)] = "วันแม่แห่งชาติ",
            [new DateTime(2025, 10, 13)] = "วันคล้ายวันสวรรคต พระบาทสมเด็จพระปรมินทรมหาภูมิพลอดุลยเดช",
            [new DateTime(2025, 10, 23)] = "วันปิยมหาราช",
            [new DateTime(2025, 12, 5)] = "วันพ่อแห่งชาติ",
            [new DateTime(2025, 12, 10)] = "วันรัฐธรรมนูญ"
        };
    
    public static string FormatThaiDate(DateTime date, ThaiDateFormat format = ThaiDateFormat.Full)
    {
        var buddhistYear = date.Year + 543;
        var dayName = ThaiDayNames[(int)date.DayOfWeek];
        var monthName = ThaiMonthNames[date.Month];
        
        return format switch
        {
            ThaiDateFormat.Short => $"{date.Day}/{date.Month}/{buddhistYear}",
            ThaiDateFormat.Medium => $"{date.Day} {monthName} {buddhistYear}",
            ThaiDateFormat.Long => $"{date.Day} {monthName} พ.ศ. {buddhistYear}",
            ThaiDateFormat.Full => $"วัน{dayName}ที่ {date.Day} {monthName} พ.ศ. {buddhistYear}",
            _ => throw new ArgumentException("Invalid Thai date format")
        };
    }
    
    public static bool IsThaiHoliday(DateTime date)
    {
        return ThaiHolidays.ContainsKey(date.Date);
    }
    
    public static string GetThaiHolidayName(DateTime date)
    {
        return ThaiHolidays.GetValueOrDefault(date.Date, null);
    }
}

public enum ThaiDateFormat
{
    Short,   // 15/1/2568
    Medium,  // 15 มกราคม 2568  
    Long,    // 15 มกราคม พ.ศ. 2568
    Full     // วันจันทร์ที่ 15 มกราคม พ.ศ. 2568
}
```

### Custom Thai Template Functions
```csharp
public static class ThaiTemplateFunctions
{
    public static void RegisterThaiHelpers(TemplateEngine engine)
    {
        // Register Thai-specific helper functions
        engine.RegisterHelper("thai_date", (date, format) => 
        {
            if (date is DateTime dt)
            {
                var thaiFormat = Enum.TryParse<ThaiDateFormat>(format?.ToString(), out var fmt) 
                    ? fmt : ThaiDateFormat.Medium;
                return ThaiCalendar.FormatThaiDate(dt, thaiFormat);
            }
            return date?.ToString();
        });
        
        engine.RegisterHelper("thai_number", (number) => 
        {
            return ConvertToThaiNumerals(number?.ToString() ?? "0");
        });
        
        engine.RegisterHelper("thai_currency", (amount) => 
        {
            if (decimal.TryParse(amount?.ToString(), out var value))
            {
                return $"฿{ConvertToThaiNumerals(value.ToString("N2"))}";
            }
            return "฿0.00";
        });
        
        engine.RegisterHelper("thai_words", (amount) => 
        {
            if (decimal.TryParse(amount?.ToString(), out var value))
            {
                return ConvertAmountToThaiWords(value);
            }
            return "";
        });
        
        engine.RegisterHelper("thai_sort", (array) => 
        {
            if (array is IEnumerable<string> strings)
            {
                return ThaiCollation.SortThaiStrings(strings);
            }
            return array;
        });
        
        engine.RegisterHelper("is_thai_holiday", (date) => 
        {
            if (date is DateTime dt)
            {
                return ThaiCalendar.IsThaiHoliday(dt);
            }
            return false;
        });
    }
}
```

## 🎓 Conclusion

This comprehensive Thai Language Guide covers all aspects of working with Thai text in DynamicPDFLibrary. Key takeaways:

### ✅ Essential Points
- **Font Setup**: Always use proper Thai fonts (Sarabun, Prompt, Kanit) with fallback chains
- **Character Encoding**: Ensure UTF-8 encoding throughout your application
- **Text Layout**: Use appropriate line heights (1.6x) and enable complex text layout
- **Cultural Considerations**: Format dates in Buddhist era, use proper Thai numerals, and follow business document conventions

### 🚀 Performance Tips
- Preload fonts for better performance
- Use font subsetting for large documents  
- Batch similar text operations
- Enable glyph caching for repeated text

### 🔧 Troubleshooting
- Validate font loading and character support
- Test with complex Thai character combinations
- Monitor memory usage with large Thai documents
- Implement proper error handling for missing fonts

### 📚 Further Resources
- [Thai Typography Guidelines](https://thai-typography.org)
- [Google Fonts Thai Collection](https://fonts.google.com/?subset=thai)
- [Unicode Thai Block Reference](https://unicode.org/charts/PDF/U0E00.pdf)
- [Thai Government Digital Standards](https://standard.dga.or.th)

For additional help with Thai language features, please refer to our [community forums](https://github.com/yourusername/DynamicPDFLibrary/discussions) or [submit an issue](https://github.com/yourusername/DynamicPDFLibrary/issues) on GitHub.