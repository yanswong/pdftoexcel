using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            //foreach (string file in Directory.EnumerateFiles(@"C:\Users\yanswong\source\repos\Convert PDF file to Excel file\C#\SW\", "*.pdf"))
            foreach (string file in Directory.EnumerateFiles(@"C:\Users\yanswong\Desktop\CMM\May-2017\", "*.pdf",SearchOption.AllDirectories))
            //foreach (string [] file in Directory.GetDirectories(@"\\pngnas2.mys.agilent.com\EUC_Gshare\vpdpenang\VPD LDA\VPD LDA\CMM MEASUREMENT RESULT\2018\","*",SearchOption.AllDirectories))
            {


                //string pathToPdf = @"C:\Users\yanswong\source\repos\Convert PDF file to Excel file\C#\SW\3700391-115-01-18-2.pdf";
                //string pathToExcel = Path.ChangeExtension(pathToPdf, ".xls");
                string pathToExcel = Path.ChangeExtension(file, ".xls");
                // Convert PDF file to Excel file
                SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

                // 'true' = Convert all data to spreadsheet (tabular and even textual).
                // 'false' = Skip textual data and convert only tabular (tables) data.
                f.ExcelOptions.ConvertNonTabularDataToSpreadsheet = true;

                // 'true'  = Preserve original page layout.
                // 'false' = Place tables before text.
                f.ExcelOptions.PreservePageLayout = true;

                //f.OpenPdf(pathToPdf);
                f.OpenPdf(file);
                if (f.PageCount > 0)
                {
                    int result = f.ToExcel(pathToExcel);

                    //Open a produced Excel workbook
                    //if (result==0)
                    //{
                    //    System.Diagnostics.Process.Start(pathToExcel);
                    //}
                }
            }
        }
    }
}
