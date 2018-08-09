using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            ConvertPdfToAll();
        }
        /// <summary>
        /// Converts PDF to DOCX, RTF, HTML, XML, Excel (XLS), PNG, Multipage TIFF, Text.
        /// </summary>
        public static void ConvertPdfToAll()
        {
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            string pdfFile = @"..\..\..\..\simple text.pdf";
            string outFile = String.Empty;

            f.OpenPdf(pdfFile);
            if (f.PageCount > 0)
            {
                // To Docx.
                outFile = Path.ChangeExtension(pdfFile, ".docx");
                f.WordOptions.Format = PdfFocus.CWordOptions.eWordDocument.Docx;
                if (f.ToWord(outFile) == 0)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });

                // To Rtf.
                outFile = Path.ChangeExtension(pdfFile, ".rtf");
                f.WordOptions.Format = PdfFocus.CWordOptions.eWordDocument.Rtf;
                if (f.ToWord(outFile) == 0)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });

                // To Excel.
                outFile = Path.ChangeExtension(pdfFile, ".xls");
                f.ExcelOptions.ConvertNonTabularDataToSpreadsheet = true;
                if (f.ToExcel(outFile) == 0)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });

                // To HTML.
                outFile = Path.ChangeExtension(pdfFile, ".html");
                f.ExcelOptions.ConvertNonTabularDataToSpreadsheet = true;
                if (f.ToHtml(outFile) == 0)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });

                // To XML.
                outFile = Path.ChangeExtension(pdfFile, ".xml");
                f.XmlOptions.ConvertNonTabularDataToSpreadsheet = true;
                if (f.ToXml(outFile) == 0)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });

                // To Image.
                outFile = Path.ChangeExtension(pdfFile, ".png");
                f.ImageOptions.Dpi = 300;
                f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
                if (f.ToImage(outFile, 1) == 0)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });

                // To Multipage Tiff (Black & White).
                outFile = Path.ChangeExtension(pdfFile, ".tiff");
                f.ImageOptions.ColorDepth = PdfFocus.CImageOptions.eColorDepth.BlackWhite1bpp;
                if (f.ToMultipageTiff(outFile, System.Drawing.Imaging.EncoderValue.CompressionCCITT4) == 0)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });

                // To Text.
                outFile = Path.ChangeExtension(pdfFile, ".txt");
                if (f.ToText(outFile) == 0)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
            }
            else
            {
                Console.WriteLine("Error: {0}!", f.Exception.Message);
                Console.ReadLine();
            }
        }

    }
}
