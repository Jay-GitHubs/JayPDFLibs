using System.Text;
using JayPDFLibs.Core.Document;

namespace JayPDFLibs.Core.Pdf
{
    /// <summary>
    /// Writes PDF documents to streams following PDF 1.4 specification.
    /// </summary>
    public class PdfWriter
    {
        private readonly Stream _stream;
        private readonly List<PdfObject> _objects;
        private long _currentPosition;
        private int _nextObjectNumber;

        public PdfWriter(Stream stream)
        {
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));
            _objects = new List<PdfObject>();
            _currentPosition = 0;
            _nextObjectNumber = 1;
        }

        /// <summary>
        /// Writes a complete PDF document to the stream.
        /// </summary>
        public void WritePdf(PdfDocument document)
        {
            // Write PDF header
            WriteHeader();

            // Create catalog and pages objects
            var catalogRef = CreateCatalogObject();
            var pagesRef = CreatePagesObject(document);

            // Create page objects
            var pageRefs = new List<PdfObjectReference>();
            foreach (var page in document.Pages)
            {
                var pageRef = CreatePageObject(page, pagesRef);
                pageRefs.Add(pageRef);
            }

            // Update pages object with page references
            UpdatePagesObject(pagesRef, pageRefs);

            // Create info object
            var infoRef = CreateInfoObject(document);

            // Write all objects
            WriteObjects();

            // Write cross-reference table
            var xrefOffset = WriteCrossReferenceTable();

            // Write trailer
            WriteTrailer(catalogRef, infoRef, xrefOffset);
        }

        private void WriteHeader()
        {
            WriteString("%PDF-1.4\n");
            WriteString("%âãÏÓ\n"); // Binary comment for PDF compatibility
        }

        private PdfObjectReference CreateCatalogObject()
        {
            var catalogRef = new PdfObjectReference(_nextObjectNumber++, 0);
            var catalog = new PdfObject(catalogRef)
            {
                Content = "<<\n/Type /Catalog\n/Pages 2 0 R\n>>"
            };
            _objects.Add(catalog);
            return catalogRef;
        }

        private PdfObjectReference CreatePagesObject(PdfDocument document)
        {
            var pagesRef = new PdfObjectReference(_nextObjectNumber++, 0);
            // Will be updated later with actual page count and references
            var pages = new PdfObject(pagesRef)
            {
                Content = $"<<\n/Type /Pages\n/Count {document.PageCount}\n/Kids []\n>>"
            };
            _objects.Add(pages);
            return pagesRef;
        }

        private PdfObjectReference CreatePageObject(PdfPage page, PdfObjectReference pagesRef)
        {
            var pageRef = new PdfObjectReference(_nextObjectNumber++, 0);
            
            // Create page content stream
            var contentRef = CreatePageContentStream(page);
            
            var pageContent = $@"<<
                                /Type /Page
                                /Parent {pagesRef.Number} {pagesRef.Generation} R
                                /MediaBox [0 0 {page.Width} {page.Height}]
                                /Contents {contentRef.Number} {contentRef.Generation} R
                                /Resources <<
                                /Font <<
                                    /F1 << /Type /Font /Subtype /Type1 /BaseFont /Helvetica >>
                                >>
                                >>
                                >>";

            var pageObject = new PdfObject(pageRef)
            {
                Content = pageContent
            };
            _objects.Add(pageObject);
            return pageRef;
        }

        private PdfObjectReference CreatePageContentStream(PdfPage page)
        {
            var contentRef = new PdfObjectReference(_nextObjectNumber++, 0);
            
            // Generate content stream for the page
            var contentBuilder = new StringBuilder();
            contentBuilder.AppendLine("BT"); // Begin text
            
            // Add text operations from page
            foreach (var textElement in page.TextElements)
            {
                contentBuilder.AppendLine($"/F1 {textElement.FontSize} Tf");
                contentBuilder.AppendLine($"{textElement.X} {textElement.Y} Td");
                contentBuilder.AppendLine($"({EscapePdfString(textElement.Text)}) Tj");
            }
            
            contentBuilder.AppendLine("ET"); // End text

            var content = contentBuilder.ToString();
            var contentStream = $@"<<
                                    /Length {Encoding.UTF8.GetByteCount(content)}
                                    >>
                                    stream
                                    {content}endstream";

            var contentObject = new PdfObject(contentRef)
            {
                Content = contentStream
            };
            _objects.Add(contentObject);
            return contentRef;
        }

        private void UpdatePagesObject(PdfObjectReference pagesRef, List<PdfObjectReference> pageRefs)
        {
            var pagesObject = _objects.Find(obj => obj.Reference.Equals(pagesRef));
            if (pagesObject != null)
            {
                var pageRefsString = string.Join(" ", pageRefs.ConvertAll(r => $"{r.Number} {r.Generation} R"));
                pagesObject.Content = $@"<<
                                        /Type /Pages
                                        /Count {pageRefs.Count}
                                        /Kids [{pageRefsString}]
                                        >>";
            }
        }

        private PdfObjectReference CreateInfoObject(PdfDocument document)
        {
            var infoRef = new PdfObjectReference(_nextObjectNumber++, 0);
            var info = new PdfObject(infoRef)
            {
                Content = $@"<<
                            /Title ({EscapePdfString(document.Title ?? "")})
                            /Author ({EscapePdfString(document.Author ?? "")})
                            /Creator (JayPDFLibs)
                            /Producer (JayPDFLibs v1.0)
                            /CreationDate (D:{document.CreationDate:yyyyMMddHHmmss}+00'00')
                            >>"
            };
            _objects.Add(info);
            return infoRef;
        }

        private void WriteObjects()
        {
            foreach (var obj in _objects)
            {
                obj.Offset = _currentPosition;
                WriteString($"{obj.Reference.Number} {obj.Reference.Generation} obj\n");
                WriteString(obj.Content);
                WriteString("\nendobj\n");
            }
        }

        private long WriteCrossReferenceTable()
        {
            var xrefOffset = _currentPosition;
            WriteString("xref\n");
            WriteString($"0 {_objects.Count + 1}\n");
            WriteString("0000000000 65535 f \n");

            foreach (var obj in _objects)
            {
                WriteString($"{obj.Offset:D10} 00000 n \n");
            }

            return xrefOffset;
        }

        private void WriteTrailer(PdfObjectReference catalogRef, PdfObjectReference infoRef, long xrefOffset)
        {
            WriteString("trailer\n");
            WriteString($@"<<
                        /Size {_objects.Count + 1}
                        /Root {catalogRef.Number} {catalogRef.Generation} R
                        /Info {infoRef.Number} {infoRef.Generation} R
                        >>
                        startxref
                        {xrefOffset}
                        %%EOF");
        }

        private void WriteString(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            _stream.Write(bytes);
            _currentPosition += bytes.Length;
        }

        private static string EscapePdfString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";

            return input.Replace("\\", "\\\\")
                       .Replace("(", "\\(")
                       .Replace(")", "\\)")
                       .Replace("\r", "\\r")
                       .Replace("\n", "\\n")
                       .Replace("\t", "\\t");
        }
    }

    /// <summary>
    /// Represents a PDF object reference.
    /// </summary>
    public record PdfObjectReference(int Number, int Generation)
    {
        public override string ToString() => $"{Number} {Generation} R";
    }

    /// <summary>
    /// Represents a PDF object.
    /// </summary>
    public class PdfObject
    {
        public PdfObject(PdfObjectReference reference)
        {
            Reference = reference;
            Content = "";
        }

        public PdfObjectReference Reference { get; }
        public string Content { get; set; }
        public long Offset { get; set; }
    }
}