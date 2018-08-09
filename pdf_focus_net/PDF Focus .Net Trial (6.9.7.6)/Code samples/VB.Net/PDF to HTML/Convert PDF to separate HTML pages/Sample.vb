Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        ' Convert PDF to separate HTMLs.
        ' Each PDF page will be converted to a single HTML document.

        ' Path to PDF file.
        Dim pdfPath As String = Path.GetFullPath("..\..\..\..\simple text.pdf")

        ' Directory to store HTML documents.
        Dim htmlDir As String = Path.GetDirectoryName(pdfPath)

        Dim f As New SautinSoft.PdfFocus()

        f.HtmlOptions.IncludeImageInHtml = False
        ' Path (must exist) to a directory to store images after converting. Notice also to the property "ImageSubFolder".
        f.HtmlOptions.ImageFolder = htmlDir

        f.OpenPdf(pdfPath)

        ' Convert each PDF page to separate HTML document.
        ' simple text.html, simple text.html ... simple text.html.
        For page As Integer = 1 To f.PageCount
            f.HtmlOptions.Title = String.Format("Simple Text - Page {0}", page)
            f.HtmlOptions.ImageSubFolder = String.Format("images-page{0}", page)
            Dim htmlString As String = f.ToHtml(page, page)

            ' Save htmlString to file
            Dim htmlPath As String = Path.Combine(htmlDir, String.Format("Page{0}.html", page))
            File.WriteAllText(htmlPath, htmlString)

            ' Let's show first and last HTML pages.
            If page = 1 OrElse page = f.PageCount Then
                System.Diagnostics.Process.Start(htmlPath)
            End If
        Next page
    End Sub
End Module
