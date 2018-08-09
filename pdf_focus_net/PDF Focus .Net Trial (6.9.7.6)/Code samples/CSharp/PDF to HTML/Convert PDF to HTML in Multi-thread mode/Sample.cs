using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            ConvertPdfToHtmlInThread();
        }
        public class TArgument
        {
            public string PdfFile { get; set; }
            public int PageNumber { get; set; }
        }
        public static void ConvertPdfToHtmlInThread()
        {
            string pdfs = @"..\..\..\..\..\";
            string[] files = Directory.GetFiles(pdfs, "*.pdf");

            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < files.Length; i++)
            {
                TArgument targ = new TArgument()
                {
                    PdfFile = files[i],
                    PageNumber = 1
                };

                var t = new Thread((a) => ConvertToHtml(a));
                t.Start(targ);
                threads.Add(t);
            }

            foreach (var thread in threads)
                thread.Join();
            Console.WriteLine("Done.");
            Console.ReadLine();
        }

        public static void ConvertToHtml(object targ)
        {
            TArgument targum = (TArgument)targ;
            string pdfFile = targum.PdfFile;
            int page = targum.PageNumber;

            string htmlFile = Path.ChangeExtension(pdfFile, ".html");

            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            f.HtmlOptions.ImageType = PdfFocus.CHtmlOptions.eHtmlImageType.Png;
            f.HtmlOptions.IncludeImageInHtml = false;
            f.HtmlOptions.ImageSubFolder = String.Format("{0}_images", Path.GetFileNameWithoutExtension(pdfFile));
            f.HtmlOptions.ImageFileName = "pict";        

            f.OpenPdf(pdfFile);

            bool done = false;

            if (f.PageCount > 0)
            {
                if (page >= f.PageCount)
                    page = 1;

                if (f.ToHtml(htmlFile, page, page) == 0)
                    done = true;
                f.ClosePdf();
            }

            if (done)
                Console.WriteLine("{0}\t - Done!", Path.GetFileName(pdfFile));
            else
                Console.WriteLine("{0}\t - Error!", Path.GetFileName(pdfFile));
        }
    }
}
