using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Convert PDF to separate HTMLs.
            // Each PDF page will be converted to a single HTML document.

            // Path to PDF file.
            string pdfPath = Path.GetFullPath(@"..\..\..\..\..\simple text.pdf");

            // Directory to store HTML documents.
            string htmlDir = Path.GetDirectoryName(pdfPath);
            
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            f.HtmlOptions.IncludeImageInHtml = false;
            // Path (must exist) to a directory to store images after converting. Notice also to the property "ImageSubFolder".
            f.HtmlOptions.ImageFolder = htmlDir;

            f.OpenPdf(pdfPath);

            // Convert each PDF page to separate HTML document.
            // simple text.html, simple text.html ... simple text.html.
            for (int page = 1; page <= f.PageCount; page++)
            {
                f.HtmlOptions.Title = String.Format("Simple Text - Page {0}", page);
                f.HtmlOptions.ImageSubFolder = String.Format("images-page{0}", page);
                string htmlString = f.ToHtml(page, page);

                // Save htmlString to file
                string htmlPath = Path.Combine(htmlDir, String.Format("Page{0}.html", page));
                File.WriteAllText(htmlPath, htmlString);

                // Let's show first and last HTML pages.
                if (page == 1 || page==f.PageCount)
                    System.Diagnostics.Process.Start(htmlPath);
            }

        }
    }
}
