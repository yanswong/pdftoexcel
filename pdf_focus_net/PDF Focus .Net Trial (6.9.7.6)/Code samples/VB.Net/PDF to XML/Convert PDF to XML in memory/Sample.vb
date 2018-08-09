Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        Dim pathToPdf As String = "..\..\..\..\Table.pdf"
        Dim pathToXml As String = Path.ChangeExtension(pathToPdf, ".xml")

        Dim pdf() As Byte = File.ReadAllBytes(pathToPdf)
        Dim xml As String = Nothing

        ' Convert PDF file to XML file.
        Dim f As New SautinSoft.PdfFocus()

        ' This property is necessary only for registered version.
        'f.Serial = "XXXXXXXXXXX"

        ' Let's convert all data (textual and tabular) to XML.
        f.XmlOptions.ConvertNonTabularDataToSpreadsheet = True

        f.OpenPdf(pdf)

        If f.PageCount > 0 Then
            xml = f.ToXml()

            'Show XML document in browser
            If Not String.IsNullOrEmpty(xml) Then
                File.WriteAllText(pathToXml, xml)
                System.Diagnostics.Process.Start(pathToXml)
            End If
        End If
    End Sub
End Module
