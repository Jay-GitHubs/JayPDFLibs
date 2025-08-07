namespace JayPDFLibs.Core.Document
{
    /// <summary>
    /// Represents a single page in a PDF document.
    /// </summary>
    public class PdfPage
    {
        public PdfPage(PageSize size)
        {
            Size = size;
            Width = GetPageWidth(size);
            Height = GetPageHeight(size);
        }

        /// <summary>
        /// Gets the page size.
        /// </summary>
        public PageSize Size { get; }

        /// <summary>
        /// Gets the page width in points.
        /// </summary>
        public float Width { get; }

        /// <summary>
        /// Gets the page height in points.
        /// </summary>
        public float Height { get; }

        /// <summary>
        /// Adds text to the page.
        /// </summary>
        /// <param name="text">The text to add</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="fontName">Font name (optional)</param>
        /// <param name="fontSize">Font size (optional)</param>
        /// <returns>This page for method chaining</returns>
        public PdfPage AddText(string text, float x, float y, string? fontName = null, float fontSize = 12)
        {
            // TODO: Implement text rendering
            Console.WriteLine($"Adding text: '{text}' at ({x}, {y})");
            return this;
        }

        private static float GetPageWidth(PageSize size) => size switch
        {
            PageSize.A4 => 595.0f,
            PageSize.Letter => 612.0f,
            PageSize.A3 => 842.0f,
            _ => 595.0f
        };

        private static float GetPageHeight(PageSize size) => size switch
        {
            PageSize.A4 => 842.0f,
            PageSize.Letter => 792.0f,
            PageSize.A3 => 1191.0f,
            _ => 842.0f
        };
    }

    /// <summary>
    /// Defines standard page sizes.
    /// </summary>
    public enum PageSize
    {
        A4,
        Letter,
        A3
    }
}