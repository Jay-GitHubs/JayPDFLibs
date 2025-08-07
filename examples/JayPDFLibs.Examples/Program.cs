using JayPDFLibs.Core.Document;

namespace JayPDFLibs.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("JayPDFLibs - Basic Example");
            Console.WriteLine("==========================");

            try
            {
                // Create a new PDF document
                using var document = new PdfDocument
                {
                    Title = "My First PDF",
                    Author = "JayPDFLibs User"
                };

                // Add a page
                var page = document.AddPage(PageSize.A4);

                // Add some text (placeholder implementation)
                page.AddText("Hello, World!", 100, 700)
                    .AddText("This is my first PDF with JayPDFLibs", 100, 680)
                    .AddText("สวัสดีครับ (Hello in Thai)", 100, 660);

                // Save to file
                document.SaveToFile("example.pdf");

                Console.WriteLine("✅ PDF created successfully: example.pdf");
                Console.WriteLine($"📄 Pages: {document.PageCount}");
                Console.WriteLine($"📝 Title: {document.Title}");
                Console.WriteLine($"👤 Author: {document.Author}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}