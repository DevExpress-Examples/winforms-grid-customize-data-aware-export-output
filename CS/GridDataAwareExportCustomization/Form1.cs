using DevExpress.Export;
using DevExpress.Export.Xl;
using DevExpress.Printing.ExportHelpers;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;

namespace GridDataAwareExportCustomization{
    public partial class Form1 : XtraForm{
        
        readonly string tblGrid = "Products";
        const string tblLookUp = "Categories";

        public Form1(){
            InitializeComponent();
            InitNWindData();
            gridView1.ExpandAllGroups();
        }

        void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e){
            if (e.Column == categoryName)
                if (e.IsGetData)
                    e.Value = nwindDataSet.Categories.FindByCategoryID((int)(gridView1.GetRowCellValue(gridView1.GetRowHandle(e.ListSourceRowIndex), colCategoryID))).CategoryName;
        }

        private void btn_Export_Click(object sender, EventArgs e) {
            // Ensure that the data-aware export mode is enabled.
            ExportSettings.DefaultExportType = ExportType.DataAware;
            // Create a new object defining how a document is exported to the XLSX format.
            var options = new XlsxExportOptionsEx();
            // Specify a name of the sheet in the created XLSX file.
            options.SheetName = "DevAV price";

            // Subscribe to export customization events. 
            options.CustomizeSheetSettings += options_CustomizeSheetSettings;
            options.CustomizeSheetHeader += options_CustomizeSheetHeader;
            options.CustomizeCell += options_CustomizeCell;
            options.CustomizeSheetFooter += options_CustomizeSheetFooter;
            options.AfterAddRow += options_AfterAddRow;

            // Export the grid data to the XLSX format.
            gridControl1.ExportToXlsx("grid-export.xlsx", options);
            // Open the created document.
            Process.Start("grid-export.xlsx");
        }

        #region #AfterAddRowEvent
        void options_AfterAddRow(AfterAddRowEventArgs e) {
            // Merge cells in rows that correspond to the grid's group rows.
            if (e.DataSourceRowIndex < 0) {
                e.ExportContext.MergeCells(new XlCellRange(new XlCellPosition(0, e.DocumentRow-1), new XlCellPosition(5, e.DocumentRow-1)));
            }
        }
        #endregion #AfterAddRowEvent

        #region #CustomizeCellEvent
        // Specify the value alignment for Discontinued field.
        XlCellAlignment aligmentForDiscontinuedColumn = new XlCellAlignment() {
            HorizontalAlignment = XlHorizontalAlignment.Center,
            VerticalAlignment = XlVerticalAlignment.Center
        };

        void options_CustomizeCell(CustomizeCellEventArgs e){
            // Substitute Boolean values within the Discontinued column by special symbols.
            if(e.ColumnFieldName == "Discontinued"){
                if(e.Value is bool){
                    e.Handled = true;
                    e.Formatting.Alignment = aligmentForDiscontinuedColumn;
                    e.Value = ((bool) e.Value) ? "☑" : "☐";
                }
            }
        }
        #endregion #CustomizeCellEvent

        #region #CustomizeSheetHeaderEvent
        delegate void AddCells(ContextEventArgs e, XlFormattingObject formatFirstCell, XlFormattingObject formatSecondCell);

        Dictionary<int, AddCells> methods = CreateMethodSet();
        
        static Dictionary<int, AddCells> CreateMethodSet(){
            var dictionary = new Dictionary<int, AddCells>();
            dictionary.Add(9, AddAddressRow);
            dictionary.Add(10, AddAddressLocationCityRow);
            dictionary.Add(11, AddPhoneRow);
            dictionary.Add(12, AddFaxRow);
            dictionary.Add(13, AddEmailRow);
            return dictionary;
        }
        void options_CustomizeSheetHeader(ContextEventArgs e){
            // Specify cell formatting. 
            var formatFirstCell = CreateXlFormattingObject(true, 24);
            var formatSecondCell = CreateXlFormattingObject(true, 18);
            // Add new rows displaying custom information. 
            for(var i = 0; i < 15; i++){
                AddCells addCellMethod;
                if(methods.TryGetValue(i, out addCellMethod))
                    addCellMethod(e, formatFirstCell, formatSecondCell);
                else e.ExportContext.AddRow();
            }
            // Merge specific cells.
            MergeCells(e);
            // Add an image to the top of the document.
            var file = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("GridDataAwareExportCustomization.Resources.1.jpg");
            if(file != null){
                var imageToHeader = new Bitmap(Image.FromStream(file));
                var imageToHeaderRange = new XlCellRange(new XlCellPosition(0, 0), new XlCellPosition(5, 7));
                e.ExportContext.MergeCells(imageToHeaderRange);
                e.ExportContext.InsertImage(imageToHeader, imageToHeaderRange);
            }
            e.ExportContext.MergeCells(new XlCellRange(new XlCellPosition(0, 8), new XlCellPosition(5, 8)));           
        }

        static void AddEmailRow(ContextEventArgs e, XlFormattingObject formatFirstCell,
            XlFormattingObject formatSecondCell){
            var emailCellName = CreateCell("Email :", formatFirstCell);
            var emailCellLocation = CreateCell("corpsales@devav.com", formatSecondCell);
            emailCellLocation.Hyperlink = "corpsales@devav.com";
            e.ExportContext.AddRow(new[]{ emailCellName, null, emailCellLocation });
        }
        static void AddFaxRow(ContextEventArgs e, XlFormattingObject formatFirstCell,
            XlFormattingObject formatSecondCell){
            var faxCellName = CreateCell("Fax :", formatFirstCell);
            var faxCellLocation = CreateCell("+ 1 (213) 555-1824", formatSecondCell);
            e.ExportContext.AddRow(new[]{ faxCellName, null, faxCellLocation });
        }
        static void AddPhoneRow(ContextEventArgs e, XlFormattingObject formatFirstCell,
            XlFormattingObject formatSecondCell){
            var phoneCellName = CreateCell("Phone :", formatFirstCell);
            var phoneCellLocation = CreateCell("+ 1 (213) 555-2828", formatSecondCell);
            e.ExportContext.AddRow(new[]{ phoneCellName, null, phoneCellLocation });
        }
        static void AddAddressLocationCityRow(ContextEventArgs e, XlFormattingObject formatFirstCell,
            XlFormattingObject formatSecondCell){
            var AddressLocationCityCell = CreateCell("Los Angeles CA 90731 USA", formatSecondCell);
            e.ExportContext.AddRow(new[]{ null, null, AddressLocationCityCell });
        }
        static void AddAddressRow(ContextEventArgs e, XlFormattingObject formatFirstCell,
            XlFormattingObject formatSecondCell){
            var AddressCellName = CreateCell("Address: ", formatFirstCell);
            var AddresssCellLocation = CreateCell("807 West Paseo Del Mar", formatSecondCell);
            e.ExportContext.AddRow(new[]{ AddressCellName, null, AddresssCellLocation });
        }

        // Create a new cell with a specified value and format settings.
        static CellObject CreateCell(object value, XlFormattingObject formatCell){
            return new CellObject{ Value = value, Formatting = formatCell };
        }

        // Merge specific cells.
        static void MergeCells(ContextEventArgs e){
            MergeCells(e, 2, 9, 5, 9);
            MergeCells(e, 0, 9, 1, 10);
            MergeCells(e, 2, 10, 5, 10);
            MergeCells(e, 0, 11, 1, 11);
            MergeCells(e, 2, 11, 5, 11);
            MergeCells(e, 0, 12, 1, 12);
            MergeCells(e, 2, 12, 5, 12);
            MergeCells(e, 0, 13, 1, 13);
            MergeCells(e, 2, 13, 5, 13);
            MergeCells(e, 0, 14, 5, 14);
        }
        static void MergeCells(ContextEventArgs e, int left, int top, int right, int bottom){
            e.ExportContext.MergeCells(new XlCellRange(new XlCellPosition(left, top), new XlCellPosition(right, bottom)));
        }

        // Specify a cell's alignment and font settings. 
        static XlFormattingObject CreateXlFormattingObject(bool bold, double size){
            var cellFormat = new XlFormattingObject{
                Font = new XlCellFont{
                    Bold = bold,
                    Size = size
                },
                Alignment = new XlCellAlignment{
                    RelativeIndent = 10,
                    HorizontalAlignment = XlHorizontalAlignment.Center,
                    VerticalAlignment = XlVerticalAlignment.Center
                }
            };
            return cellFormat;
        }
        #endregion #CustomizeSheetHeaderEvent

        #region #CustomizeSheetFooterEvent
        void options_CustomizeSheetFooter(ContextEventArgs e){
            // Add an empty row to the document's footer.
            e.ExportContext.AddRow();

            // Create a new row.
            var firstRow = new CellObject();
            // Specify row values.
            firstRow.Value = @"The report is generated from the NorthWind database.";
            // Specify the cell content alignment and font settings.
            var rowFormatting = CreateXlFormattingObject(true, 18);
            rowFormatting.Alignment.HorizontalAlignment = XlHorizontalAlignment.Left;
            firstRow.Formatting = rowFormatting;
            // Add the created row to the output document. 
            e.ExportContext.AddRow(new[]{ firstRow });

            // Create one more row.
            var secondRow = new CellObject();
            // Specify the row value. 
            secondRow.Value = @"The addresses and phone numbers are fictitious.";
            // Change the row's font settings.
            rowFormatting.Font.Size = 14;
            rowFormatting.Font.Bold = false;
            rowFormatting.Font.Italic = true;  
            secondRow.Formatting = rowFormatting;
            // Add this row to the output document.
            e.ExportContext.AddRow(new[]{ secondRow });
        }
        #endregion #CustomizeSheetFooterEvent

        #region #CustomizeSheetSettingsEvent
        void options_CustomizeSheetSettings(CustomizeSheetEventArgs e) {
            // Anchor the output document's header to the top and set its fixed height. 
            const int lastHeaderRowIndex = 15;
            e.ExportContext.SetFixedHeader(lastHeaderRowIndex);
            // Add the AutoFilter button to the document's cells corresponding to the grid column headers.
            e.ExportContext.AddAutoFilter(new XlCellRange(new XlCellPosition(0, lastHeaderRowIndex), new XlCellPosition(5, 100)));
        }
        #endregion #CustomizeSheetSettingsEvent

        void InitMDBData(string connectionString){
            var oleDBAdapter1 = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM " + tblGrid, connectionString);
            var oleDBAdapter2 = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM " + tblLookUp, connectionString);
            oleDBAdapter1.Fill(nwindDataSet.Products);
            oleDBAdapter2.Fill(nwindDataSet.Categories);
        }

        void InitNWindData(){
            var dbFileName = string.Empty;
            dbFileName = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, "nwind.mdb");
            if(dbFileName != string.Empty){
                InitMDBData("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbFileName);
            }
        }

        void Form1_Load(object sender, EventArgs e){
            gridView1.BestFitColumns(true);
        }
       
    }
}