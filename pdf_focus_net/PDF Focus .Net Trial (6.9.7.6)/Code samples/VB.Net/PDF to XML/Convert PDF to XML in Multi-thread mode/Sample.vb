Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports System.Threading
Imports SautinSoft

Module Sample

    Sub Main()
        ConvertPdfToXmlInThread()
    End Sub
    Public Class TArgument
        Public Property PdfFile() As String
        Public Property PageNumber() As Integer
    End Class
    Public Sub ConvertPdfToXmlInThread()
        Dim pdfs As String = "..\..\..\..\"
        Dim files() As String = Directory.GetFiles(pdfs, "*.pdf")

        Dim threads As New List(Of Thread)()
        For i As Integer = 0 To files.Length - 1
            Dim targ As New TArgument() With {
                    .PdfFile = files(i),
                    .PageNumber = 1
                }

            Dim t = New Thread(Sub(a) ConvertToXml(a))
            t.Start(targ)
            threads.Add(t)
        Next i

        For Each t As Thread In threads
            t.Join()
        Next t
        Console.WriteLine("Done.")
        Console.ReadLine()
    End Sub

    Public Sub ConvertToXml(ByVal targ As Object)
        Dim targum As TArgument = DirectCast(targ, TArgument)
        Dim pdfFile As String = targum.PdfFile
        Dim page As Integer = targum.PageNumber

        Dim xmlFile As String = Path.ChangeExtension(pdfFile, ".xml")

        Dim f As New SautinSoft.PdfFocus()

        ' Let's convert all data (textual and tabular) to XML.
        f.XmlOptions.ConvertNonTabularDataToSpreadsheet = True

        f.OpenPdf(pdfFile)

        Dim done As Boolean = False

        If f.PageCount > 0 Then
            If page >= f.PageCount Then
                page = 1
            End If

            If f.ToXml(xmlFile, page, page) = 0 Then
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
