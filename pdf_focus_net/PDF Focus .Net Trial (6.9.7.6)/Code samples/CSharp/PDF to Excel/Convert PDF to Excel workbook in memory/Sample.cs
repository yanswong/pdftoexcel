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

            // Here we have our PDF and Excel docs as byte arrays
            byte[] pdf = File.ReadAllBytes(pathToPdf);
            byte[] xls = null;

            // Convert PDF document to Excel workbook in memory
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            
	    	// This property is necessary only for registered version
		    //f.Serial = "XXXXXXXXXXX";

            f.OpenPdf(pdf);

            if (f.PageCount > 0)
            {
                xls = f.ToExcel();
                
                //Save Excel workbook to a file in order to show it
                if (xls!=null)
                {
                    File.WriteAllBytes(pathToExcel, xls);
                    System.Diagnostics.Process.Start(pathToExcel);
                }
            }
        }
    }
}
