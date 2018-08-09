Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        Dim pathToPdf As String = "..\..\..\..\Table.pdf"
        Dim pathToXml As String = Path.ChangeExtension(pathToPdf, ".xml")

        ' Convert PDF file to XML file.
        Dim f As New SautinSoft.PdfFocus()

        ' This property is necessary only for registered version.
        'f.Serial = "XXXXXXXXXXX"

        ' Let's convert only tables to XML and skip all textual data.
        f.XmlOptions.ConvertNonTabularDataToSpreadsheet = False

        f.OpenPdf(pathToPdf)

        If f.PageCount > 0 Then
            Dim result As Integer = f.ToXml(pathToXml)

            'Show HTML document in browser
            If result = 0 Then
                System.Diagnostics.Process.Start(pathToXml)
            End If
        End If
    End Sub
End Module
