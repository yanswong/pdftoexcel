Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports System.Threading
Imports SautinSoft

Module Sample

    Sub Main()
        ConvertPdfToHtmlInThread()
    End Sub
    Public Class TArgument
        Public Property PdfFile() As String
        Public Property PageNumber() As Integer
    End Class
    Public Sub ConvertPdfToHtmlInThread()
        Dim pdfs As String = "..\..\..\..\"
        Dim files() As String = Directory.GetFiles(pdfs, "*.pdf")

        Dim threads As New List(Of Thread)()
        For i As Integer = 0 To files.Length - 1
            Dim targ As New TArgument() With {
                    .PdfFile = files(i),
                    .PageNumber = 1
                }

            Dim t = New Thread(Sub(a) ConvertToHtml(a))
            t.Start(targ)
            threads.Add(t)
        Next i

        For Each t As Thread In threads
            t.Join()
        Next t
        Console.WriteLine("Done.")
        Console.ReadLine()
    End Sub

    Public Sub ConvertToHtml(ByVal targ As Object)
        Dim targum As TArgument = DirectCast(targ, TArgument)
        Dim pdfFile As String = targum.PdfFile
        Dim page As Integer = targum.PageNumber

        Dim htmlFile As String = Path.ChangeExtension(pdfFile, ".html")

        Dim f As New SautinSoft.PdfFocus()

        f.HtmlOptions.ImageType = PdfFocus.CHtmlOptions.eHtmlImageType.Png
        f.HtmlOptions.IncludeImageInHtml = False
        f.HtmlOptions.ImageSubFolder = String.Format("{0}_images", Path.GetFileNameWithoutExtension(pdfFile))
        f.HtmlOptions.ImageFileName = "pict"

        f.OpenPdf(pdfFile)

        Dim done As Boolean = False

        If f.PageCount > 0 Then
            If page >= f.PageCount Then
                page = 1
            End If

            If f.ToHtml(htmlFile, page, page) = 0 Then
                done = True
            End If
            f.ClosePdf()
        End If

        If done Then
            Console.WriteLine("{0}" & ControlChars.Tab & " - Done!", Path.GetFileName(pdfFile))
        Else
            Console.WriteLine("{0}" & ControlChars.Tab & " - Error!", Path.GetFileName(pdfFile))
        End If
    End Sub


    Public Sub ConvertToWord(ByVal targ As Object)
        Dim targum As TArgument = DirectCast(targ, TArgument)
        Dim pdfFile As String = targum.PdfFile
        Dim page As Integer = targum.PageNumber

        Dim docxFile As String = Path.ChangeExtension(pdfFile, ".docx")

        Dim f As New SautinSoft.PdfFocus()

        f.WordOptions.Format = PdfFocus.CWordOptions.eWordDocument.Docx
        f.WordOptions.RenderMode = PdfFocus.CWordOptions.eRenderMode.Flowing

        f.OpenPdf(pdfFile)

        Dim done As Boolean = False

        If f.PageCount > 0 Then
            If page >= f.PageCount Then
                page = 1
            End If

            If f.ToWord(docxFile, page, page) = 0 Then
                done = True
            End If
            f.ClosePdf()
        End If

        If done Then
            Console.WriteLine("{0}" & ControlChars.Tab & " - Done!", Path.GetFileName(pdfFile))
        Else
            Console.WriteLine("{0}" & ControlChars.Tab & " - Error!", Path.GetFileName(pdfFile))
        End If
    End Sub

End Module
