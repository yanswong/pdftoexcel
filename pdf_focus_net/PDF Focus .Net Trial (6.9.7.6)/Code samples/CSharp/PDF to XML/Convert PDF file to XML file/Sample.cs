using System;
using System.IO;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string pathToPdf = @"..\..\..\..\..\Table.pdf";
            string pathToXml = Path.ChangeExtension(pathToPdf, ".xml");

            // Convert PDF file to XML file.
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

	    	// This property is necessary only for registered version.
		    //f.Serial = "XXXXXXXXXXX";

            // Let's convert only tables to XML and skip all textual data.
            f.XmlOptions.ConvertNonTabularDataToSpreadsheet = false;

            f.OpenPdf(pathToPdf);

            if (f.PageCount > 0)
            {
                int result = f.ToXml(pathToXml);
                
                //Show HTML document in browser
                if (result==0)
                {
                    System.Diagnostics.Process.Start(pathToXml);
                }
            }
        }
    }
}
