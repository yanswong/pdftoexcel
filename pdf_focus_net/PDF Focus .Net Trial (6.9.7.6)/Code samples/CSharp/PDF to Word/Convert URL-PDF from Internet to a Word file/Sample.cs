using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string remotePdfUrl = @"http://www.sautinsoft.net/samples/simple%20text.pdf";
            string pathToWord = @"..\..\..\..\..\Result.docx";

            //Convert URL-PDF from Internet to a Word file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            //this property is necessary only for registered version
            //f.Serial = "XXXXXXXXXXX";

            Uri uri = new Uri(remotePdfUrl);

            f.OpenPdf(uri);

            if (f.PageCount > 0)
            {
                int result = f.ToWord(pathToWord);

                //Show the resulting Word document
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(pathToWord);
                }
            }
        }
    }
}
