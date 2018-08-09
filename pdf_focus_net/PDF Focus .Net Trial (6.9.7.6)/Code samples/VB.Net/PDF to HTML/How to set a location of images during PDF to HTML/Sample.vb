Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        ' Here you will find various ways to store images
        Dim pdfFile As String = "..\..\..\..\simple text.pdf"
        Dim htmlFile As String = Path.ChangeExtension(pdfFile, ".htm")

        ' Convert PDF file to HTML file
        Dim f As New SautinSoft.PdfFocus()

        ' Way 1: Images will be stored as physical PNG files in: ImageFolder + ImageSubFolder.
        ' For example: "d:\" + "special folder" = "d:\special folder\"

        'f.HtmlOptions.ImageFolder = @"d:\";
        'f.HtmlOptions.ImageSubFolder = "special folder";
        'f.HtmlOptions.ImageType = PdfFocus.CHtmlOptions.eHtmlImageType.Png;

        ' Way 2: Images will be stored as PNG files in the same directory with HTML file.
        ' All images on each page will be combined in a single image.

        'f.HtmlOptions.ImageFolder = Path.GetDirectoryName(pdfFile);
        'f.HtmlOptions.ImageType = PdfFocus.CHtmlOptions.eHtmlImageType.Png;
        'f.HtmlOptions.ImageSubFolder = "";
        'f.HtmlOptions.CombineImages = true;

        ' Way 3: Images will be stored as Jpeg files in a special folder "my images".
        ' Images will have name "picture100.jpg", "picture101.jpg" .. "pictureN.jpg".

        ' Let's set the quality for jpeg images to 95 percents.
        f.HtmlOptions.ImageFolder = Path.GetDirectoryName(pdfFile)
        f.HtmlOptions.ImageType = PdfFocus.CHtmlOptions.eHtmlImageType.Jpeg
        f.HtmlOptions.JpegQuality = 95
        f.HtmlOptions.ImageSubFolder = "my images"
        f.HtmlOptions.ImageFileName = "picture"
        f.HtmlOptions.ImageNumStart = 100
        f.HtmlOptions.CombineImages = False

        ' Way 4: Images will be stored inside HTML document as base64 images.
        'f.HtmlOptions.IncludeImageInHtml = true;

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
