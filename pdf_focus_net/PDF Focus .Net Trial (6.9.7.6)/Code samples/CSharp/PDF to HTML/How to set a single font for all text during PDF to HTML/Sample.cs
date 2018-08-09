using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pdfFile = @"..\..\..\..\..\Text.pdf";
            string htmlFile = Path.ChangeExtension(pdfFile, ".htm");

            // Convert PDF file to HTML file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            // Let's change all text to Verdana 8pt.
            f.HtmlOptions.SingleFontFamily = "Verdana";
            f.HtmlOptions.SingleFontSize = 8;


            // After purchasing the license, please insert your serial number here to activate the component:
            //f.Serial = "123456789";

            f.OpenPdf(pdfFile);

            if (f.PageCount > 0)
            {
                int from = 1;
                int to = (3 > f.PageCount) ? f.PageCount : 3;

                int result = f.ToHtml(htmlFile, from, to);

                // Show resulted HTML document in a browser.
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(htmlFile);
                }
            }
        }
    }
}
