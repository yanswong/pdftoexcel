Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        ' Convert PDF file to BlackAndWhite Multipage-TIFF.
        Dim f As New SautinSoft.PdfFocus()

        ' This property is necessary only for registered version.
        'f.Serial = "XXXXXXXXXXX"

        Dim pdfPath As String = "..\..\..\..\simple text.pdf"
        Dim tiffPath As String = Path.ChangeExtension(pdfPath, ".png")

        f.OpenPdf(pdfPath)

        If f.PageCount > 0 Then
            f.ImageOptions.Dpi = 120
            f.ImageOptions.ColorDepth = SautinSoft.PdfFocus.CImageOptions.eColorDepth.BlackWhite1bpp
            ' EncoderValue.CompressionCCITT4 - also makes image black&white 1 bit
            If f.ToMultipageTiff(tiffPath, EncoderValue.CompressionCCITT4) = 0 Then
                System.Diagnostics.Process.Start(tiffPath)
            End If
        End If
    End Sub
End Module
