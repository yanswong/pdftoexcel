Imports System.IO
Imports SautinSoft

Module Sample
    Sub Main()
        ConvertPdfToAll()
    End Sub
    ''' <summary>
    ''' Converts PDF to DOCX, RTF, HTML, XML, Excel (XLS), PNG, Multipage TIFF, Text.
    ''' </summary>
    Public Sub ConvertPdfToAll()
        Dim f As New SautinSoft.PdfFocus()

        Dim pdfFile As String = "..\..\..\simple text.pdf"
        Dim outFile As String = String.Empty

        f.OpenPdf(pdfFile)
        If f.PageCount > 0 Then
            ' To Docx.
            outFile = Path.ChangeExtension(pdfFile, ".docx")
            f.WordOptions.Format = PdfFocus.CWordOptions.eWordDocument.Docx
            If f.ToWord(outFile) = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
            End If

            ' To Rtf.
            outFile = Path.ChangeExtension(pdfFile, ".rtf")
            f.WordOptions.Format = PdfFocus.CWordOptions.eWordDocument.Rtf
            If f.ToWord(outFile) = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
            End If

            ' To Excel.
            outFile = Path.ChangeExtension(pdfFile, ".xls")
            f.ExcelOptions.ConvertNonTabularDataToSpreadsheet = True
            If f.ToExcel(outFile) = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
            End If

            ' To HTML.
            outFile = Path.ChangeExtension(pdfFile, ".html")
            f.ExcelOptions.ConvertNonTabularDataToSpreadsheet = True
            If f.ToHtml(outFile) = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
            End If

            ' To XML.
            outFile = Path.ChangeExtension(pdfFile, ".xml")
            f.XmlOptions.ConvertNonTabularDataToSpreadsheet = True
            If f.ToXml(outFile) = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
            End If

            ' To Image.
            outFile = Path.ChangeExtension(pdfFile, ".png")
            f.ImageOptions.Dpi = 300
            f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Png
            If f.ToImage(outFile, 1) = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
            End If

            ' To Multipage Tiff (Black & White).
            outFile = Path.ChangeExtension(pdfFile, ".tiff")
            f.ImageOptions.ColorDepth = PdfFocus.CImageOptions.eColorDepth.BlackWhite1bpp
            If f.ToMultipageTiff(outFile, System.Drawing.Imaging.EncoderValue.CompressionCCITT4) = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
            End If

            ' To Text.
            outFile = Path.ChangeExtension(pdfFile, ".txt")
            If f.ToText(outFile) = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
            End If
        Else
            Console.WriteLine("Error: {0}!", f.Exception.Message)
            Console.ReadLine()
        End If
    End Sub
End Module
