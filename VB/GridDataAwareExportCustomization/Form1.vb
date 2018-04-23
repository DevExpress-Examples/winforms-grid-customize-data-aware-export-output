Imports DevExpress.Export
Imports DevExpress.Export.Xl
Imports DevExpress.Printing.ExportHelpers
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPrinting
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Base

Namespace GridDataAwareExportCustomization
    Partial Public Class Form1
        Inherits XtraForm

        Private ReadOnly tblGrid As String = "Products"
        Private Const tblLookUp As String = "Categories"

        Public Sub New()
            InitializeComponent()
            InitNWindData()
            gridView1.ExpandAllGroups()
        End Sub

        Private Sub gridView1_CustomUnboundColumnData(ByVal sender As Object, ByVal e As CustomColumnDataEventArgs) Handles gridView1.CustomUnboundColumnData
            If e.Column Is categoryName Then
                If e.IsGetData Then
                    e.Value = nwindDataSet.Categories.FindByCategoryID(CInt((gridView1.GetRowCellValue(gridView1.GetRowHandle(e.ListSourceRowIndex), colCategoryID)))).CategoryName
                End If
            End If
        End Sub

        Private Sub btn_Export_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Export.Click
            ' Ensure that the data-aware export mode is enabled.
            ExportSettings.DefaultExportType = ExportType.DataAware
            ' Create a new object defining how a document is exported to the XLSX format.
            Dim options = New XlsxExportOptionsEx()
            ' Specify a name of the sheet in the created XLSX file.
            options.SheetName = "DevAV price"

            ' Subscribe to export customization events. 
            AddHandler options.CustomizeSheetSettings, AddressOf options_CustomizeSheetSettings
            AddHandler options.CustomizeSheetHeader, AddressOf options_CustomizeSheetHeader
            AddHandler options.CustomizeCell, AddressOf options_CustomizeCell
            AddHandler options.CustomizeSheetFooter, AddressOf options_CustomizeSheetFooter
            AddHandler options.AfterAddRow, AddressOf options_AfterAddRow

            ' Export the grid data to the XLSX format.
            gridControl1.ExportToXlsx("grid-export.xlsx", options)
            ' Open the created document.
            Process.Start("grid-export.xlsx")
        End Sub

        #Region "#AfterAddRowEvent"
        Private Sub options_AfterAddRow(ByVal e As AfterAddRowEventArgs)
            ' Merge cells in rows that correspond to the grid's group rows.
            If e.DataSourceRowIndex < 0 Then
                e.ExportContext.MergeCells(New XlCellRange(New XlCellPosition(0, e.DocumentRow-1), New XlCellPosition(5, e.DocumentRow-1)))
            End If
        End Sub
        #End Region ' #AfterAddRowEvent

        #Region "#CustomizeCellEvent"
        ' Specify the value alignment for Discontinued field.
        Private aligmentForDiscontinuedColumn As New XlCellAlignment() With {.HorizontalAlignment = XlHorizontalAlignment.Center, .VerticalAlignment = XlVerticalAlignment.Center}

        Private Sub options_CustomizeCell(ByVal e As CustomizeCellEventArgs)
            ' Substitute Boolean values within the Discontinued column by special symbols.
            If e.ColumnFieldName = "Discontinued" Then
                If TypeOf e.Value Is Boolean Then
                    e.Handled = True
                    e.Formatting.Alignment = aligmentForDiscontinuedColumn
                    e.Value = If(CBool(e.Value), "☑", "☐")
                End If
            End If
        End Sub
        #End Region ' #CustomizeCellEvent

        #Region "#CustomizeSheetHeaderEvent"
        Private Delegate Sub AddCells(ByVal e As ContextEventArgs, ByVal formatFirstCell As XlFormattingObject, ByVal formatSecondCell As XlFormattingObject)

        Private methods As Dictionary(Of Integer, AddCells) = CreateMethodSet()

        Private Shared Function CreateMethodSet() As Dictionary(Of Integer, AddCells)
            Dim dictionary = New Dictionary(Of Integer, AddCells)()
            dictionary.Add(9, AddressOf AddAddressRow)
            dictionary.Add(10, AddressOf AddAddressLocationCityRow)
            dictionary.Add(11, AddressOf AddPhoneRow)
            dictionary.Add(12, AddressOf AddFaxRow)
            dictionary.Add(13, AddressOf AddEmailRow)
            Return dictionary
        End Function
        Private Sub options_CustomizeSheetHeader(ByVal e As ContextEventArgs)
            ' Specify cell formatting. 
            Dim formatFirstCell = CreateXlFormattingObject(True, 24)
            Dim formatSecondCell = CreateXlFormattingObject(True, 18)
            ' Add new rows displaying custom information. 
            For i = 0 To 14
                Dim addCellMethod As AddCells = Nothing
                If methods.TryGetValue(i, addCellMethod) Then
                    addCellMethod(e, formatFirstCell, formatSecondCell)
                Else
                    e.ExportContext.AddRow()
                End If
            Next i
            ' Merge specific cells.
            MergeCells(e)
            ' Add an image to the top of the document.
            Dim file = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Resources.1.jpg")
            If file IsNot Nothing Then
                Dim imageToHeader = New Bitmap(Image.FromStream(file))
                Dim imageToHeaderRange = New XlCellRange(New XlCellPosition(0, 0), New XlCellPosition(5, 7))
                e.ExportContext.MergeCells(imageToHeaderRange)
                e.ExportContext.InsertImage(imageToHeader, imageToHeaderRange)
            End If
            e.ExportContext.MergeCells(New XlCellRange(New XlCellPosition(0, 8), New XlCellPosition(5, 8)))
        End Sub

        Private Shared Sub AddEmailRow(ByVal e As ContextEventArgs, ByVal formatFirstCell As XlFormattingObject, ByVal formatSecondCell As XlFormattingObject)
            Dim emailCellName = CreateCell("Email :", formatFirstCell)
            Dim emailCellLocation = CreateCell("corpsales@devav.com", formatSecondCell)
            emailCellLocation.Hyperlink = "corpsales@devav.com"
            e.ExportContext.AddRow({ emailCellName, Nothing, emailCellLocation })
        End Sub
        Private Shared Sub AddFaxRow(ByVal e As ContextEventArgs, ByVal formatFirstCell As XlFormattingObject, ByVal formatSecondCell As XlFormattingObject)
            Dim faxCellName = CreateCell("Fax :", formatFirstCell)
            Dim faxCellLocation = CreateCell("+ 1 (213) 555-1824", formatSecondCell)
            e.ExportContext.AddRow({ faxCellName, Nothing, faxCellLocation })
        End Sub
        Private Shared Sub AddPhoneRow(ByVal e As ContextEventArgs, ByVal formatFirstCell As XlFormattingObject, ByVal formatSecondCell As XlFormattingObject)
            Dim phoneCellName = CreateCell("Phone :", formatFirstCell)
            Dim phoneCellLocation = CreateCell("+ 1 (213) 555-2828", formatSecondCell)
            e.ExportContext.AddRow({ phoneCellName, Nothing, phoneCellLocation })
        End Sub
        Private Shared Sub AddAddressLocationCityRow(ByVal e As ContextEventArgs, ByVal formatFirstCell As XlFormattingObject, ByVal formatSecondCell As XlFormattingObject)
            Dim AddressLocationCityCell = CreateCell("Los Angeles CA 90731 USA", formatSecondCell)
            e.ExportContext.AddRow({ Nothing, Nothing, AddressLocationCityCell })
        End Sub
        Private Shared Sub AddAddressRow(ByVal e As ContextEventArgs, ByVal formatFirstCell As XlFormattingObject, ByVal formatSecondCell As XlFormattingObject)
            Dim AddressCellName = CreateCell("Address: ", formatFirstCell)
            Dim AddresssCellLocation = CreateCell("807 West Paseo Del Mar", formatSecondCell)
            e.ExportContext.AddRow({ AddressCellName, Nothing, AddresssCellLocation })
        End Sub

        ' Create a new cell with a specified value and format settings.
        Private Shared Function CreateCell(ByVal value As Object, ByVal formatCell As XlFormattingObject) As CellObject
            Return New CellObject With {.Value = value, .Formatting = formatCell}
        End Function

        ' Merge specific cells.
        Private Shared Sub MergeCells(ByVal e As ContextEventArgs)
            MergeCells(e, 2, 9, 5, 9)
            MergeCells(e, 0, 9, 1, 10)
            MergeCells(e, 2, 10, 5, 10)
            MergeCells(e, 0, 11, 1, 11)
            MergeCells(e, 2, 11, 5, 11)
            MergeCells(e, 0, 12, 1, 12)
            MergeCells(e, 2, 12, 5, 12)
            MergeCells(e, 0, 13, 1, 13)
            MergeCells(e, 2, 13, 5, 13)
            MergeCells(e, 0, 14, 5, 14)
        End Sub
        Private Shared Sub MergeCells(ByVal e As ContextEventArgs, ByVal left As Integer, ByVal top As Integer, ByVal right As Integer, ByVal bottom As Integer)
            e.ExportContext.MergeCells(New XlCellRange(New XlCellPosition(left, top), New XlCellPosition(right, bottom)))
        End Sub

        ' Specify a cell's alignment and font settings. 
        Private Shared Function CreateXlFormattingObject(ByVal bold As Boolean, ByVal size As Double) As XlFormattingObject
            Dim cellFormat = New XlFormattingObject With { _
                .Font = New XlCellFont With {.Bold = bold, .Size = size}, _
                .Alignment = New XlCellAlignment With {.RelativeIndent = 10, .HorizontalAlignment = XlHorizontalAlignment.Center, .VerticalAlignment = XlVerticalAlignment.Center} _
            }
            Return cellFormat
        End Function
        #End Region ' #CustomizeSheetHeaderEvent

        #Region "#CustomizeSheetFooterEvent"
        Private Sub options_CustomizeSheetFooter(ByVal e As ContextEventArgs)
            ' Add an empty row to the document's footer.
            e.ExportContext.AddRow()

            ' Create a new row.
            Dim firstRow = New CellObject()
            ' Specify row values.
            firstRow.Value = "The report is generated from the NorthWind database."
            ' Specify the cell content alignment and font settings.
            Dim rowFormatting = CreateXlFormattingObject(True, 18)
            rowFormatting.Alignment.HorizontalAlignment = XlHorizontalAlignment.Left
            firstRow.Formatting = rowFormatting
            ' Add the created row to the output document. 
            e.ExportContext.AddRow({ firstRow })

            ' Create one more row.
            Dim secondRow = New CellObject()
            ' Specify the row value. 
            secondRow.Value = "The addresses and phone numbers are fictitious."
            ' Change the row's font settings.
            rowFormatting.Font.Size = 14
            rowFormatting.Font.Bold = False
            rowFormatting.Font.Italic = True
            secondRow.Formatting = rowFormatting
            ' Add this row to the output document.
            e.ExportContext.AddRow({ secondRow })
        End Sub
        #End Region ' #CustomizeSheetFooterEvent

        #Region "#CustomizeSheetSettingsEvent"
        Private Sub options_CustomizeSheetSettings(ByVal e As CustomizeSheetEventArgs)
            ' Anchor the output document's header to the top and set its fixed height. 
            Const lastHeaderRowIndex As Integer = 15
            e.ExportContext.SetFixedHeader(lastHeaderRowIndex)
            ' Add the AutoFilter button to the document's cells corresponding to the grid column headers.
            e.ExportContext.AddAutoFilter(New XlCellRange(New XlCellPosition(0, lastHeaderRowIndex), New XlCellPosition(5, 100)))
        End Sub
        #End Region ' #CustomizeSheetSettingsEvent

        Private Sub InitMDBData(ByVal connectionString As String)
            Dim oleDBAdapter1 = New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM " & tblGrid, connectionString)
            Dim oleDBAdapter2 = New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM " & tblLookUp, connectionString)
            oleDBAdapter1.Fill(nwindDataSet.Products)
            oleDBAdapter2.Fill(nwindDataSet.Categories)
        End Sub

        Private Sub InitNWindData()
            Dim dbFileName = String.Empty
            dbFileName = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, "nwind.mdb")
            If dbFileName <> String.Empty Then
                InitMDBData("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbFileName)
            End If
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            gridView1.BestFitColumns(True)
        End Sub

    End Class
End Namespace