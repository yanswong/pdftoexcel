Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        Dim pathToPdf As String = "..\..\..\..\Table.pdf"
        Dim pathToExcel As String = Path.ChangeExtension(pathToPdf, ".xls")

        ' Here we have our PDF and Excel docs as byte arrays
        Dim pdf() As Byte = File.ReadAllBytes(pathToPdf)
        Dim xls() As Byte = Nothing

        ' Convert PDF document to Excel workbook in memory
        Dim f As New SautinSoft.PdfFocus()

        ' This property is necessary only for registered version
        'f.Serial = "XXXXXXXXXXX"

        f.OpenPdf(pdf)

        If f.PageCount > 0 Then
            xls = f.ToExcel()

            'Save Excel workbook to a file in order to show it
            If xls IsNot Nothing Then
                File.WriteAllBytes(pathToExcel, xls)
                System.Diagnostics.Process.Start(pathToExcel)
            End If
        End If
    End Sub
End Module
