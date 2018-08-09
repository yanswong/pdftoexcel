using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            ConvertPdfBytesToHtml();
            //ConvertPdfStreamToHtml();
        }

        private static void ConvertPdfBytesToHtml()
        {
            string pathToPdf = @"..\..\..\..\..\simple text.pdf";
            string pathToHtml = Path.ChangeExtension(pathToPdf, ".htm");

            // Convert PDF to HTML in memory
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            // Let's force the component to store images inside HTML document
            // using base-64 encoding.
            // Thus the component will not use HDD.
            f.HtmlOptions.IncludeImageInHtml = true;
            f.HtmlOptions.Title = "Simple text";
            f.HtmlOptions.InlineCSS = true;

            // This property is necessary only for registered version
            //f.Serial = "XXXXXXXXXXX";

            // Read a PDF document to byte array
            // Assume that we already had PDF as bytes array before converting.
            byte[] pdf = File.ReadAllBytes(pathToPdf);

            f.OpenPdf(pdf);

            if (f.PageCount > 0)
            {
                // Convert PDF to HTML in memory
                string html = f.ToHtml();

                // Save HTML to a file only for demonstration purpose.
                if (html != null)
                {
                    File.WriteAllText(pathToHtml, html);
                    System.Diagnostics.Process.Start(pathToHtml);
                }
            }
        }
        private static void ConvertPdfStreamToHtml()
        {
            string pathToPdf = @"..\..\..\..\..\simple text.pdf";
            string pathToHtml = Path.ChangeExtension(pathToPdf, ".htm");

            // Convert PDF to HTML in memory
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            // Let's force the component to store images inside HTML document
            // using base-64 encoding.
            // Thus the component will not use HDD.
            f.HtmlOptions.IncludeImageInHtml = true;
            f.HtmlOptions.Title = "Simple text";
            f.HtmlOptions.InlineCSS = true;

            // This property is necessary only for registered version
            //f.Serial = "XXXXXXXXXXX";

            // Read a PDF document to byte array
            // Assume that we have a PDF document as Stream.

            using (FileStream fs = File.OpenRead(pathToPdf))
            {
                f.OpenPdf(fs);

                if (f.PageCount > 0)
                {
                    // Convert PDF to HTML string.
                    string html = f.ToHtml();

                    // Save HTML to a file only for demonstration purposes.
                    if (html != null)
                    {
                        File.WriteAllText(pathToHtml, html);
                        System.Diagnostics.Process.Start(pathToHtml);
                    }
                }
            }
        }

    }
}
