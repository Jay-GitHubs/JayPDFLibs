// tests/JayPDFLibs.Tests/PdfGenerationTests.cs
using JayPDFLibs.Core.Document;

namespace JayPDFLibs.Tests
{
    public class PdfGenerationTests
    {
        [Fact]
        public void PdfDocument_SaveToFile_Should_Create_Valid_PDF()
        {
            // Arrange
            var tempFile = Path.GetTempFileName();
            
            try
            {
                using var document = new PdfDocument
                {
                    Title = "Test PDF",
                    Author = "JayPDFLibs Test"
                };

                var page = document.AddPage();
                page.AddText("Hello, World!", 100, 700);
                page.AddText("This is a test PDF", 100, 680);

                // Act
                document.SaveToFile(tempFile);

                // Assert
                Assert.True(File.Exists(tempFile));
                var fileContent = File.ReadAllBytes(tempFile);
                Assert.True(fileContent.Length > 0);
                
                // Check PDF header
                var header = System.Text.Encoding.UTF8.GetString(fileContent, 0, Math.Min(8, fileContent.Length));
                Assert.StartsWith("%PDF-1.4", header);
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        [Fact]
        public void PdfDocument_SaveToStream_Should_Write_PDF_Content()
        {
            // Arrange
            using var document = new PdfDocument();
            var page = document.AddPage();
            page.AddText("Stream test", 50, 750);

            using var stream = new MemoryStream();

            // Act
            document.SaveToStream(stream);

            // Assert
            Assert.True(stream.Length > 0);
            var content = System.Text.Encoding.UTF8.GetString(stream.ToArray());
            Assert.Contains("%PDF-1.4", content);
            Assert.Contains("Stream test", content);
        }

        [Fact]
        public void PdfPage_AddText_Should_Store_Text_Elements()
        {
            // Arrange
            using var document = new PdfDocument();
            var page = document.AddPage();

            // Act
            page.AddText("First text", 100, 700)
                .AddText("Second text", 100, 680, "Arial", 14);

            // Assert
            Assert.Equal(2, page.TextElements.Count);
            
            Assert.Equal("First text", page.TextElements[0].Text);
            Assert.Equal(100, page.TextElements[0].X);
            Assert.Equal(700, page.TextElements[0].Y);
            Assert.Equal("Helvetica", page.TextElements[0].FontName); // Default font
            Assert.Equal(12, page.TextElements[0].FontSize); // Default size

            Assert.Equal("Second text", page.TextElements[1].Text);
            Assert.Equal("Arial", page.TextElements[1].FontName);
            Assert.Equal(14, page.TextElements[1].FontSize);
        }

        [Fact]
        public void PdfDocument_Multiple_Pages_Should_Be_Supported()
        {
            // Arrange
            using var document = new PdfDocument();

            // Act
            var page1 = document.AddPage(PageSize.A4);
            page1.AddText("Page 1 content", 100, 700);

            var page2 = document.AddPage(PageSize.Letter);
            page2.AddText("Page 2 content", 100, 700);

            var page3 = document.AddPage(PageSize.A3);
            page3.AddText("Page 3 content", 100, 700);

            // Assert
            Assert.Equal(3, document.PageCount);
            Assert.Equal(PageSize.A4, document.Pages[0].Size);
            Assert.Equal(PageSize.Letter, document.Pages[1].Size);
            Assert.Equal(PageSize.A3, document.Pages[2].Size);
        }

        [Theory]
        [InlineData(PageSize.A4, 595.0f, 842.0f)]
        [InlineData(PageSize.Letter, 612.0f, 792.0f)]
        [InlineData(PageSize.A3, 842.0f, 1191.0f)]
        public void PdfPage_Should_Have_Correct_Dimensions(PageSize size, float expectedWidth, float expectedHeight)
        {
            // Arrange & Act
            using var document = new PdfDocument();
            var page = document.AddPage(size);

            // Assert
            Assert.Equal(expectedWidth, page.Width);
            Assert.Equal(expectedHeight, page.Height);
            Assert.Equal(size, page.Size);
        }

        [Fact]
        public void PdfDocument_With_Thai_Text_Should_Be_Created()
        {
            // Arrange
            var tempFile = Path.GetTempFileName();
            
            try
            {
                using var document = new PdfDocument
                {
                    Title = "ทดสอบ PDF ภาษาไทย",
                    Author = "ผู้ทดสอบ"
                };

                var page = document.AddPage();
                page.AddText("สวัสดีครับ", 100, 700);
                page.AddText("ยินดีต้อนรับสู่ JayPDFLibs", 100, 680);
                page.AddText("Mixed: Hello สวัสดี World", 100, 660);

                // Act
                document.SaveToFile(tempFile);

                // Assert
                Assert.True(File.Exists(tempFile));
                var content = File.ReadAllText(tempFile, System.Text.Encoding.UTF8);
                Assert.Contains("สวัสดีครับ", content);
                Assert.Contains("ยินดีต้อนรับสู่ JayPDFLibs", content);
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }
    }
}