using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pdfFile = @"..\..\..\..\..\simple text.pdf";
            string htmlFile = Path.ChangeExtension(pdfFile, ".htm");

            // Convert PDF file to HTML file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            // Path (must exist) to a directory to store images after converting. Notice also to the property "ImageSubFolder".
            f.HtmlOptions.ImageFolder = Path.GetDirectoryName(pdfFile);
            // A folder (will be created by the component) without any drive letters, only the folder as "myfolder".
            f.HtmlOptions.ImageSubFolder = String.Format("{0}_images", Path.GetFileNameWithoutExtension(pdfFile));
            // We recommend to use PNG type for storing images.
            f.HtmlOptions.ImageType = PdfFocus.CHtmlOptions.eHtmlImageType.Png;
            // How to store images: Inside HTML document as base64 images or as linked separate image files.
            f.HtmlOptions.IncludeImageInHtml = false;
            // Set <title>...</title>
            f.HtmlOptions.Title = "Simple text";

            // After purchasing the license, please insert your serial number here to activate the component:
            //f.Serial = "123456789";

            f.OpenPdf(pdfFile);

            if (f.PageCount > 0)
            {
                int result = f.ToHtml(htmlFile);
                
                // Show resulted HTML document in a browser.
                if (result==0)
                {
                    System.Diagnostics.Process.Start(htmlFile);
                }
            }
        }
    }
}
