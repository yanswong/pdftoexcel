using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            ConvertPdfToDocx();
            //ConvertPdfToRtf();
        }

        private static void ConvertPdfToDocx()
        {
            string pdfFile = @"..\..\..\..\..\text and graphics.pdf";
            string wordFile = Path.ChangeExtension(pdfFile, ".docx");

            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            //this property is necessary only for registered version
            //f.Serial = "XXXXXXXXXXX";

            f.OpenPdf(pdfFile);

            if (f.PageCount > 0)
            {
                f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx;
                int result = f.ToWord(wordFile);

                // Show the produced result.
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(wordFile);
                }
            }
        }
        private static void ConvertPdfToRtf()
        {
            string pdfFile = @"..\..\..\..\..\text and graphics.pdf";
            string wordFile = Path.ChangeExtension(pdfFile, ".rtf");

            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            //this property is necessary only for registered version
            //f.Serial = "XXXXXXXXXXX";

            f.OpenPdf(pdfFile);

            if (f.PageCount > 0)
            {
                f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Rtf;
                int result = f.ToWord(wordFile);

                // Show the produced result.
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(wordFile);
                }
            }
        }
    }
}
