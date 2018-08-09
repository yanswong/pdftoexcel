Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        'Convert PDF file to Multipage TIFF file
        Dim f As New SautinSoft.PdfFocus()
        'this property is necessary only for registered version
        'f.Serial = "XXXXXXXXXXX"

        Dim pdfPath As String = "..\..\..\..\simple text.pdf"
        Dim tiffPath As String = Path.ChangeExtension(pdfPath, ".tiff")

        f.OpenPdf(pdfPath)

        If f.PageCount > 0 Then
            f.ImageOptions.Dpi = 120
            If f.ToMultipageTiff(tiffPath) = 0 Then
                System.Diagnostics.Process.Start(tiffPath)
            End If
        End If
    End Sub
End Module
