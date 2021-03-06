Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports SautinSoft

Module Sample

    Sub Main()
        Dim pathToPdf As String = "..\..\..\..\Table.pdf"
        Dim pathToExcel As String = Path.ChangeExtension(pathToPdf, ".xls")

        ' Convert only tables from PDF to XLS spreadsheet and skip all textual data.
        Dim f As New SautinSoft.PdfFocus()

        ' This property is necessary only for registered version
        'f.Serial = "XXXXXXXXXXX"

        ' 'true' = Convert all data to spreadsheet (tabular and even textual).
        ' 'false' = Skip textual data and convert only tabular (tables) data.
        f.ExcelOptions.ConvertNonTabularDataToSpreadsheet = False

        ' 'true'  = Preserve original page layout.
        ' 'false' = Place tables before text.
        f.ExcelOptions.PreservePageLayout = True

        f.OpenPdf(pathToPdf)

        If f.PageCount > 0 Then
            Dim result As Integer = f.ToExcel(pathToExcel)

            ' Open the resulted Excel workbook.
            If result = 0 Then
                System.Diagnostics.Process.Start(pathToExcel)
            End If
        End If
    End Sub
End Module
