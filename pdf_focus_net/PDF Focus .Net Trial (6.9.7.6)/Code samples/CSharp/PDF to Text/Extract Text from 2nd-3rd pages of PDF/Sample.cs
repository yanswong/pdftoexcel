using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pdfFile = @"..\..\..\..\..\Text.pdf";
            string textFile = Path.ChangeExtension(pdfFile, ".txt");

            //Extract Text from 2nd-3rd pages of PDF
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            //this property is necessary only for registered version
            //f.Serial = "XXXXXXXXXXX";

            f.OpenPdf(pdfFile);

            if (f.PageCount > 2)
            {
                //Convert only pages 2 - 3 to Text
                int result = f.ToText(textFile, 2, 3);

                //Show Text document
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(textFile);
                }
            }
        }
    }
}
