using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pdfFile = @"..\..\..\..\..\Potato Beetle.pdf";
            string textFile = Path.ChangeExtension(pdfFile, ".txt");

            //Convert PDF file to Text file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            //this property is necessary only for registered version
            //f.Serial = "XXXXXXXXXXX";

            f.OpenPdf(pdfFile);

            if (f.PageCount > 0)
            {
                int result = f.ToText(textFile);

                //Show Text document
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(textFile);
                }
            }
        }
    }
}
