using System;
using System.IO;
using System.Collections.Generic;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Extract all images from 1st PDF page
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            // This property is necessary only for registered version
            // f.Serial = "XXXXXXXXXXX";
            string pdfFile = @"..\..\..\..\..\simple text.pdf";
            string imageDir = Path.GetDirectoryName(pdfFile);

            List<PdfFocus.PdfImage> pdfImages = null;

            f.OpenPdf(pdfFile);

            if (f.PageCount > 0)
            {
                pdfImages = f.ExtractImages(1, 1);                

                // Show all extracted images.
                if (pdfImages != null && pdfImages.Count > 0)
                {

                    for (int i = 0; i < pdfImages.Count; i++)
                    {
                        string imageFile = Path.Combine(imageDir, String.Format("img{0}.png", i + 1));
                        pdfImages[i].Picture.Save(imageFile);
                        System.Diagnostics.Process.Start(imageFile);
                    }
                }
            }
        }
    }
}
