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
            ConvertPdfToExcelInThread();
        }
        public class TArgument
        {
            public string PdfFile { get; set; }
            public int PageNumber { get; set; }
        }
        public static void ConvertPdfToExcelInThread()
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

                var t = new Thread((a) => ConvertToExcel(a));
                t.Start(targ);
                threads.Add(t);
            }

            foreach (var thread in threads)
                thread.Join();
            Console.WriteLine("Done.");
            Console.ReadLine();
        }

        public static void ConvertToExcel(object targ)
        {
            TArgument targum = (TArgument)targ;
            string pdfFile = targum.PdfFile;
            int page = targum.PageNumber;

            string excelFile = Path.ChangeExtension(pdfFile, ".xls");

            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            // 'true' = Convert all data to spreadsheet (tabular and even textual).
            // 'false' = Skip textual data and convert only tabular (tables) data.
            f.ExcelOptions.ConvertNonTabularDataToSpreadsheet = true;

            // 'true'  = Preserve original page layout.
            // 'false' = Place tables before text.
            f.ExcelOptions.PreservePageLayout = true;

            f.OpenPdf(pdfFile);

            bool done = false;

            if (f.PageCount > 0)
            {
                if (page >= f.PageCount)
                    page = 1;

                if (f.ToExcel(excelFile, page, page) == 0)
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
