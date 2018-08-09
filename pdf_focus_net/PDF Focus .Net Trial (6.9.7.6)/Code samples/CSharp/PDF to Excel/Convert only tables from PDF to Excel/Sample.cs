using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pathToPdf = @"..\..\..\..\..\Table.pdf";
            string pathToExcel = Path.ChangeExtension(pathToPdf, ".xls");

            // Convert only tables from PDF to XLS spreadsheet and skip all textual data.
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            
	    	// This property is necessary only for registered version
		    //f.Serial = "XXXXXXXXXXX";

            // 'true' = Convert all data to spreadsheet (tabular and even textual).
            // 'false' = Skip textual data and convert only tabular (tables) data.
            f.ExcelOptions.ConvertNonTabularDataToSpreadsheet = false;

            // 'true'  = Preserve original page layout.
            // 'false' = Place tables before text.
            f.ExcelOptions.PreservePageLayout = true;

            f.OpenPdf(pathToPdf);

            if (f.PageCount > 0)
            {
                int result = f.ToExcel(pathToExcel);
                
                // Open the resulted Excel workbook.
                if (result==0)
                {
                    System.Diagnostics.Process.Start(pathToExcel);
                }
            }
        }
    }
}
