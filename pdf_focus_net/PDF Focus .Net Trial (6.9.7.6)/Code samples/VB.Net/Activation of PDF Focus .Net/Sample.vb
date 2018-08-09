Imports System.IO
Module Sample
    Sub Main()
        ' Activation of PDF Focus .Net after purchasing
        Dim f As New SautinSoft.PdfFocus()

        ' Place your serial number here.
        ' You will get an own serial number after purchasing the license.
        ' If have any questions, email us to sales@sautinsoft.com or ask at online chat http://www.sautinsoft.com.
        f.Serial = "1234567890"

        Dim pdfPath As String = "..\..\..\simple text.pdf"
        Dim tiffPath As String = Path.ChangeExtension(pdfPath, ".tiff")

        ' Open PDF
        f.OpenPdf(pdfPath)

        If f.PageCount > 0 Then
            ' 0 - converting successfully            
            ' 2 - can't create output file, check the output path
            ' 3 - converting failed
            f.ImageOptions.Dpi = 120
            If f.ToMultipageTiff(tiffPath) = 0 Then
                System.Diagnostics.Process.Start(tiffPath)
            End If
        End If
    End Sub
End Module
