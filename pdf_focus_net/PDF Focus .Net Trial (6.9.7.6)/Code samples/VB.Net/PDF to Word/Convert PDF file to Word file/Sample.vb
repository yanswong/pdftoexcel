Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        Dim pdfFile As String = "..\..\..\..\text and graphics.pdf"
        Dim wordFile As String = Path.ChangeExtension(pdfFile, ".docx")

        ' Convert a PDF file to a Word file
        Dim f As New SautinSoft.PdfFocus()
        'this property is necessary only for registered version
        'f.Serial = "XXXXXXXXXXX"

        f.OpenPdf(pdfFile)

        If f.PageCount > 0 Then
            ' You may choose output format between Docx and Rtf.
            f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx

            Dim result As Integer = f.ToWord(wordFile)

            ' Show the resulting Word document.
            If result = 0 Then
                System.Diagnostics.Process.Start(wordFile)
            End If
        End If

    End Sub
End Module
