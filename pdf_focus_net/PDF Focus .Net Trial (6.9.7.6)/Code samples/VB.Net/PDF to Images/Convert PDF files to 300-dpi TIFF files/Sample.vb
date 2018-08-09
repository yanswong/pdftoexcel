Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        'Convert PDF files to 300-dpi TIFF files
        Dim f As New SautinSoft.PdfFocus()
        'this property is necessary only for registered version
        'f.Serial = "XXXXXXXXXXX"

        Dim pdfFiles() As String = Directory.GetFiles("..\..\..\..\", "*.pdf")
        Dim folderWithTiffs As String = "..\..\..\..\"

        For Each pdffile As String In pdfFiles
            f.OpenPdf(pdffile)

            If f.PageCount > 0 Then
                'Set image format: TIFF, 300 dpi
                f.ImageOptions.Dpi = 300
                f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Tiff

                'Save all pages to tiff files with 300 dpi
                f.ToImage(folderWithTiffs, Path.GetFileNameWithoutExtension(pdffile))
            End If
            f.ClosePdf()
        Next pdffile
        'Show folder with tiffs
        System.Diagnostics.Process.Start(folderWithTiffs)
    End Sub
End Module
