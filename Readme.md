<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128627083/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T247610)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WinForms Data Grid - Customize data-aware export output

This example shows how to export the grid's data to a file in XLSX format and customize the output. The example uses the [GridControl.ExportToXlsx](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.GridControl.ExportToXlsx(System.String-DevExpress.XtraPrinting.XlsxExportOptions)) method, which takes a parameter ([XlsxExportOptionsEx](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.XlsxExportOptionsEx)) that regulates export settings and behavior, and implements events that allow you to add a header and footer to the export output, customize cells, add rows, etc.

* The [XlsxExportOptionsEx.CustomizeSheetHeader](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.XlsxExportOptionsEx.CustomizeSheetHeader) event is handled to add a header with custom information to the generated Microsoft Excel document. The `e.ExportContext.AddRow`, `e.ExportContext.InsertImage`, and `e.ExportContext.MergeCells` methods are used to add rows with the company name and contact information, insert the company logo, and merge certain cells. Cell formatting is specified using objects of the `XlFormattingObject` class.

* The [XlsxExportOptionsEx.CustomizeCell](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.XlsxExportOptionsEx.CustomizeCell) event is handled to replace values in the **Discontinued** column with special symbols. The `e.ColumnFieldName` event parameter identifies the column. The `e.Value` parameter is used to substitute certain cell values. The `e.Handled` parameter is set to **true** to apply the changes made.

* The [XlsxExportOptionsEx.AfterAddRow](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.XlsxExportOptionsEx.AfterAddRow) event is handled to merge cells in rows that correspond to the grid's group rows. The `e.ExportContext.MergeCells` method is used to merge cells. The `e.DataSourceRowIndex` event parameter returns negative values for group rows. The `e.DocumentRow` parameter specifies the current row in the export output.

* The [XlsxExportOptionsEx.CustomizeSheetFooter](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.XlsExportOptionsEx.CustomizeSheetFooter) event is handled to add a footer to the document. The event handler uses the `e.ExportContext.AddRow` method to add two rows to the output document. Format settings are specified using objects of the `XlFormattingObject` class.

* The [XlsxExportOptionsEx.CustomizeSheetSettings](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.XlsxExportOptionsEx.CustomizeSheetSettings) event is handled to specify export settings. The `e.ExportContext.SetFixedHeader` method is used to anchor the output document's header to the top, and to set the fixed header height. The `e.ExportContext.AddAutoFilter` method is used to add the **AutoFilter** button to cells that correspond to grid column headers.</p>


## Files to Review

* [Form1.cs](./CS/GridDataAwareExportCustomization/Form1.cs) (VB: [Form1.vb](./VB/GridDataAwareExportCustomization/Form1.vb))

## Documentation

* [Export to XLS and XLSX Formats](https://docs.devexpress.com/WindowsForms/17733/controls-and-libraries/data-grid/export-and-printing/export-to-xls-and-xlsx-formats)

## See Also

* [DevExpress WinForms Troubleshooting - Grid Control](https://go.devexpress.com/CheatSheets_WinForms_Examples_T934742.aspx)

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-customize-data-aware-export-output&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-customize-data-aware-export-output&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
