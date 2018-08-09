using System;
using System.IO;
using System.Text;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            //ConvertMultiplePdfToHtmls();
            ConvertMultiplePdfToSingleHtml();
        }

        /// <summary>
        /// Converts multiple PDF files to HTML files.
        /// </summary>
        static void ConvertMultiplePdfToHtmls()
        {
            // Directory with *.pdf files.
            string pdfDirectory = Path.GetFullPath(@"..\..\..\..\..\");
            string[] pdfFiles = Directory.GetFiles(pdfDirectory, "*.pdf");

            PdfFocus f = new PdfFocus();

            // After purchasing the license, please insert your serial number here to activate the component:
            //f.Serial = "123456789";

            int success = 0;
            int total = 0;

            foreach (string pdfFile in pdfFiles)
            {
                Console.WriteLine("Converting {0} ...", Path.GetFileName(pdfFile));

                f.OpenPdf(pdfFile);
                total++;

                if (f.PageCount > 0)
                {
                    // Path (must exist) to a directory to store images after converting. Notice also to the property "ImageSubFolder".
                    f.HtmlOptions.ImageFolder = Path.GetDirectoryName(pdfFile);
                    // A folder (will be created by the component) without any drive letters, only the folder as "myfolder".
                    f.HtmlOptions.ImageSubFolder = String.Format("{0}_images", Path.GetFileNameWithoutExtension(pdfFile));
                    // We recommend to use PNG type for storing images.
                    f.HtmlOptions.ImageType = PdfFocus.CHtmlOptions.eHtmlImageType.Png;
                    // How to store images: Inside HTML document as base64 images or as linked separate image files.
                    f.HtmlOptions.IncludeImageInHtml = false;

                    string resultFile = Path.ChangeExtension(pdfFile, ".html");
                    if (f.ToHtml(resultFile) == 0)
                    {
                        success++;
                    }
                }
            }
            // Show results:
            Console.WriteLine("{0} of {1} files converted successfully!", success, total);
            Console.WriteLine("Press any key ...");
            Console.ReadLine();
            // Open folder with HTML files after converting.
            System.Diagnostics.Process.Start(pdfDirectory);

        }
        /// <summary>
        /// Converts multiple PDF files into a single HTML document.
        /// </summary>
        static void ConvertMultiplePdfToSingleHtml()
        {
            // Directory with *.pdf files.
            string pdfDirectory = Path.GetFullPath(@"..\..\..\..\..\");
            string htmlFile = Path.GetFullPath("Result.html");

            string[] pdfFiles = Directory.GetFiles(pdfDirectory, "*.pdf");

            // Here we'll keep our Html document.
            StringBuilder singleHtml = new StringBuilder();
            singleHtml.Append("<html><body>");


            PdfFocus f = new PdfFocus();
            //f.Serial = "123456789";

            int success = 0;
            int total = 0;

            foreach (string pdfFile in pdfFiles)
            {
                Console.WriteLine("Converting {0} ...", Path.GetFileName(pdfFile));

                f.OpenPdf(pdfFile);                
                total++;

                if (f.PageCount > 0)
                {
                    // Path (must exist) to a directory to store images after converting. Notice also to the property "ImageSubFolder".
                    f.HtmlOptions.ImageFolder = Path.GetDirectoryName(htmlFile);
                    // A folder (will be created by the component) without any drive letters, only the folder as "myfolder".
                    f.HtmlOptions.ImageSubFolder = "images";
                    // We recommend to use PNG type for storing images.
                    f.HtmlOptions.ImageType = PdfFocus.CHtmlOptions.eHtmlImageType.Png;
                    // How to store images: Inside HTML document as base64 images or as linked separate image files.
                    f.HtmlOptions.IncludeImageInHtml = false;
                    // Let's make our CSS inline to be able merge HTML documents without any problems.
                    f.HtmlOptions.InlineCSS = true;
                    // We need only contents of <body>...</body>.
                    f.HtmlOptions.ProduceOnlyHtmlBody = true;

                    string tempHtml = f.ToHtml();

                    if (!String.IsNullOrEmpty(tempHtml))
                    {
                        success++;
                        // Add tempHtml into a single HTML.
                        singleHtml.Append(tempHtml);
                    }

                }
            }
            singleHtml.Append("</body></html>");

            // Show results:
            File.WriteAllText(htmlFile, singleHtml.ToString());

            Console.WriteLine("{0} of {1} files converted and merged into {2}!", success, total, Path.GetFileName(htmlFile));
            Console.WriteLine("Press any key ...");
            Console.ReadLine();
            // Open our single HTML document.
            System.Diagnostics.Process.Start(htmlFile);
        }

    }
}
