Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        Dim pdfFile As String = "..\..\..\..\simple text.pdf"
        Dim htmlFile As String = Path.ChangeExtension(pdfFile, ".htm")

        ' Convert PDF file to HTML file
        Dim f As New SautinSoft.PdfFocus()

        ' Path (must exist) to a directory to store images after converting. Notice also to the property "ImageSubFolder".
        f.HtmlOptions.ImageFolder = Path.GetDirectoryName(pdfFile)
        ' A folder (will be created by the component) without any drive letters, only the folder as "myfolder".
        f.HtmlOptions.ImageSubFolder = String.Format("{0}_images", Path.GetFileNameWithoutExtension(pdfFile))
        ' We recommend to use PNG type for storing images.
        f.HtmlOptions.ImageType = PdfFocus.CHtmlOptions.eHtmlImageType.Png
        ' How to store images: Inside HTML document as base64 images or as linked separate image files.
        f.HtmlOptions.IncludeImageInHtml = False
        ' Set <title>...</title>
        f.HtmlOptions.Title = "Simple text"

        ' After purchasing the license, please insert your serial number here to activate the component:
        'f.Serial = "123456789";

        f.OpenPdf(pdfFile)

        If f.PageCount > 0 Then
            Dim result As Integer = f.ToHtml(htmlFile)

            ' Show resulted HTML document in a browser.
            If result = 0 Then
                System.Diagnostics.Process.Start(htmlFile)
            End If
        End If
    End Sub
End Module
