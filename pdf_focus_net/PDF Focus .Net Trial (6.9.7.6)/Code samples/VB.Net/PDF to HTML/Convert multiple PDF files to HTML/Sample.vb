Imports System.IO
Imports System.Text
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        'ConvertMultiplePdfToHtmls()
        ConvertMultiplePdfToSingleHtml()
    End Sub
    ''' <summary>
    ''' Converts multiple PDF files to HTML files.
    ''' </summary>
    Sub ConvertMultiplePdfToHtmls()
        ' Directory with *.pdf files.
        Dim pdfDirectory As String = Path.GetFullPath("..\..\..\..\")
        Dim pdfFiles() As String = Directory.GetFiles(pdfDirectory, "*.pdf")

        Dim f As New PdfFocus()

        ' After purchasing the license, please insert your serial number here to activate the component:
        'f.Serial = "123456789";

        Dim success As Integer = 0
        Dim total As Integer = 0

        For Each pdfFile As String In pdfFiles
            Console.WriteLine("Converting {0} ...", Path.GetFileName(pdfFile))

            f.OpenPdf(pdfFile)
            total += 1

            If f.PageCount > 0 Then
                ' Path (must exist) to a directory to store images after converting. Notice also to the property "ImageSubFolder".
                f.HtmlOptions.ImageFolder = Path.GetDirectoryName(pdfFile)
                ' A folder (will be created by the component) without any drive letters, only the folder as "myfolder".
                f.HtmlOptions.ImageSubFolder = String.Format("{0}_images", Path.GetFileNameWithoutExtension(pdfFile))
                ' We recommend to use PNG type for storing images.
                f.HtmlOptions.ImageType = PdfFocus.CHtmlOptions.eHtmlImageType.Png
                ' How to store images: Inside HTML document as base64 images or as linked separate image files.
                f.HtmlOptions.IncludeImageInHtml = False

                Dim resultFile As String = Path.ChangeExtension(pdfFile, ".html")
                If f.ToHtml(resultFile) = 0 Then
                    success += 1
                End If
            End If
        Next pdfFile
        ' Show results:
        Console.WriteLine("{0} of {1} files converted successfully!", success, total)
        Console.WriteLine("Press any key ...")
        Console.ReadLine()
        ' Open folder with HTML files after converting.
        System.Diagnostics.Process.Start(pdfDirectory)

    End Sub
    ''' <summary>
    ''' Converts multiple PDF files into a single HTML document.
    ''' </summary>
    Sub ConvertMultiplePdfToSingleHtml()
        ' Directory with *.pdf files.
        Dim pdfDirectory As String = Path.GetFullPath("..\..\..\..\")
        Dim htmlFile As String = Path.GetFullPath("Result.html")

        Dim pdfFiles() As String = Directory.GetFiles(pdfDirectory, "*.pdf")

        ' Here we'll keep our Html document.
        Dim singleHtml As New StringBuilder()
        singleHtml.Append("<html><body>")


        Dim f As New PdfFocus()
        'f.Serial = "123456789";

        Dim success As Integer = 0
        Dim total As Integer = 0

        For Each pdfFile As String In pdfFiles
            Console.WriteLine("Converting {0} ...", Path.GetFileName(pdfFile))

            f.OpenPdf(pdfFile)
            total += 1

            If f.PageCount > 0 Then
                ' Path (must exist) to a directory to store images after converting. Notice also to the property "ImageSubFolder".
                f.HtmlOptions.ImageFolder = Path.GetDirectoryName(htmlFile)
                ' A folder (will be created by the component) without any drive letters, only the folder as "myfolder".
                f.HtmlOptions.ImageSubFolder = "images"
                ' We recommend to use PNG type for storing images.
                f.HtmlOptions.ImageType = PdfFocus.CHtmlOptions.eHtmlImageType.Png
                ' How to store images: Inside HTML document as base64 images or as linked separate image files.
                f.HtmlOptions.IncludeImageInHtml = False
                ' Let's make our CSS inline to be able merge HTML documents without any problems.
                f.HtmlOptions.InlineCSS = True
                ' We need only contents of <body>...</body>.
                f.HtmlOptions.ProduceOnlyHtmlBody = True

                Dim tempHtml As String = f.ToHtml()

                If Not String.IsNullOrEmpty(tempHtml) Then
                    success += 1
                    ' Add tempHtml into a single HTML.
                    singleHtml.Append(tempHtml)
                End If

            End If
        Next pdfFile
        singleHtml.Append("</body></html>")

        ' Show results:
        File.WriteAllText(htmlFile, singleHtml.ToString())

        Console.WriteLine("{0} of {1} files converted and merged into {2}!", success, total, Path.GetFileName(htmlFile))
        Console.WriteLine("Press any key ...")
        Console.ReadLine()
        ' Open our single HTML document.
        System.Diagnostics.Process.Start(htmlFile)
    End Sub
End Module
