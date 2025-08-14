using System.Globalization;
using System.Collections;
using System.Runtime.CompilerServices;

namespace JayPDFLibs.Core.Document
{
    /// <summary>
    /// Represents a single page in a PDF document.
    /// </summary>
    public class PdfPage
    {
        private readonly List<TextElement> _textElements;
        public PdfPage(PageSize size)
        {
            Size = size;
            Width = GetPageWidth(size);
            Height = GetPageHeight(size);
            _textElements = new List<TextElement>();
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

        public IReadOnlyList<TextElement> TextElements => _textElements.AsReadOnly();

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
            var textElement = new TextElement
            {
                Text = text ?? string.Empty,
                X = x,
                Y = y,
                FontName = fontName ?? "Helvetica",
                FontSize = fontSize
            };

            _textElements.Add(textElement);
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

    public class TextElement
    {
        public string Text { get; set; } = string.Empty;
        public float X { get; set; }
        public float Y { get; set; }
        public string FontName { get; set; } = "Helvetica";
        public float FontSize { get; set; } = 12;

    }
}