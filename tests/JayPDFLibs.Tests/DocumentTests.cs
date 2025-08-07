using JayPDFLibs.Core.Document;

namespace JayPDFLibs.Tests
{
    public class DocumentTests
    {
        [Fact]
        public void PdfDocument_Should_Create_Successfully()
        {
            // Arrange & Act
            using var document = new PdfDocument();

            // Assert
            Assert.NotNull(document);
            Assert.Equal(0, document.PageCount);
        }

        [Fact]
        public void PdfDocument_AddPage_Should_Increase_PageCount()
        {
            // Arrange
            using var document = new PdfDocument();

            // Act
            var page = document.AddPage();

            // Assert
            Assert.Equal(1, document.PageCount);
            Assert.NotNull(page);
        }

        [Fact]
        public void PdfPage_AddText_Should_Return_Same_Page()
        {
            // Arrange
            using var document = new PdfDocument();
            var page = document.AddPage();

            // Act
            var result = page.AddText("Hello World", 100, 700);

            // Assert
            Assert.Same(page, result);
        }

        [Fact]
        public void PdfDocument_Should_Set_Properties()
        {
            // Arrange & Act
            using var document = new PdfDocument
            {
                Title = "Test Document",
                Author = "Test Author"
            };

            // Assert
            Assert.Equal("Test Document", document.Title);
            Assert.Equal("Test Author", document.Author);
        }
    }
}