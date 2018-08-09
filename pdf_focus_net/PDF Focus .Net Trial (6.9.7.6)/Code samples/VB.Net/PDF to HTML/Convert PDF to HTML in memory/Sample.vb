Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        ConvertPdfBytesToHtml()
        'ConvertPdfStreamToHtml()
    End Sub
    Sub ConvertPdfBytesToHtml()
        Dim pathToPdf As String = "..\..\..\..\simple text.pdf"
        Dim pathToHtml As String = Path.ChangeExtension(pathToPdf, ".htm")

        ' Convert PDF to HTML in memory
        Dim f As New SautinSoft.PdfFocus()
        ' Let's force the component to store images inside HTML document
        ' using base-64 encoding.
        ' Thus the component will not use HDD.
        f.HtmlOptions.IncludeImageInHtml = True
        f.HtmlOptions.Title = "Simple text"
        f.HtmlOptions.InlineCSS = True

        ' This property is necessary only for registered version
        'f.Serial = "XXXXXXXXXXX"

        ' Read a PDF document to byte array
        ' Assume that we already had PDF as bytes array before converting.
        Dim pdf() As Byte = File.ReadAllBytes(pathToPdf)

        f.OpenPdf(pdf)

        If f.PageCount > 0 Then
            ' Convert PDF to HTML in memory
            Dim html As String = f.ToHtml()

            ' Save HTML to a file only for demonstration purpose.
            If html IsNot Nothing Then
                File.WriteAllText(pathToHtml, html)
                System.Diagnostics.Process.Start(pathToHtml)
            End If
        End If
    End Sub
    Sub ConvertPdfStreamToHtml()
        Dim pathToPdf As String = "..\..\..\..\simple text.pdf"
        Dim pathToHtml As String = Path.ChangeExtension(pathToPdf, ".htm")

        ' Convert PDF to HTML in memory
        Dim f As New SautinSoft.PdfFocus()
        ' Let's force the component to store images inside HTML document
        ' using base-64 encoding.
        ' Thus the component will not use HDD.
        f.HtmlOptions.IncludeImageInHtml = True
        f.HtmlOptions.Title = "Simple text"
        f.HtmlOptions.InlineCSS = True

        ' This property is necessary only for registered version
        'f.Serial = "XXXXXXXXXXX"

        ' Read a PDF document to byte array
        ' Assume that we have a PDF document as Stream.

        Using fs As FileStream = File.OpenRead(pathToPdf)
            f.OpenPdf(fs)

            If f.PageCount > 0 Then
                ' Convert PDF to HTML string.
                Dim html As String = f.ToHtml()

                ' Save HTML to a file only for demonstration purposes.
                If html IsNot Nothing Then
                    File.WriteAllText(pathToHtml, html)
                    System.Diagnostics.Process.Start(pathToHtml)
                End If
            End If
        End Using
    End Sub

End Module
