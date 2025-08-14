using JayPDFLibs.Core.Pdf;

namespace JayPDFLibs.Core.Document
{
    /// <summary>
    /// Represents a PDF document with support for Thai language content.
    /// </summary>
    public class PdfDocument : IDisposable
    {
        private readonly List<PdfPage> _pages;
        private bool _disposed = false;

        public PdfDocument()
        {
            _pages = new List<PdfPage>();
            CreationDate = DateTime.Now;
        }

        /// <summary>
        /// Gets the pages in the document.
        /// </summary>
        public IReadOnlyList<PdfPage> Pages => _pages.AsReadOnly();

        /// <summary>
        /// Gets the number of pages in the document.
        /// </summary>
        public int PageCount => _pages.Count;

        /// <summary>
        /// Gets or sets the document title.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the document author.
        /// </summary>
        public string? Author { get; set; }

        /// <summary>
        /// Gets the creation date of the document.
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        /// Adds a new page to the document.
        /// </summary>
        /// <param name="size">The page size (default: A4)</param>
        /// <returns>The newly created page</returns>
        public PdfPage AddPage(PageSize size = PageSize.A4)
        {
            var page = new PdfPage(size);
            _pages.Add(page);
            return page;
        }

        /// <summary>
        /// Saves the document to a file.
        /// </summary>
        /// <param name="filePath">The file path to save to</param>
        public void SaveToFile(string filePath)
        {
            using var fileStream = new FileStream(filePath, FileMode.Create);
            SaveToStream(fileStream);
        }

        /// <summary>
        /// Saves the document to a stream.
        /// </summary>
        /// <param name="stream">The stream to save to</param>
        public void SaveToStream(Stream stream)
        {
            var writer = new PdfWriter(stream);
            writer.WritePdf(this);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _pages?.Clear();
                _disposed = true;
            }
        }
    }
}