# How to: Customize the GridControl's Data-Aware Export Output


<p>This example demonstrates how to customize the GridControl's data-aware export output.</p>
<p>In this example, the grid's data is exported to XLSX format using the <strong>GridControl.ExportToXlsx</strong> method with a parameter (an <strong>XlsxExportOptionsEx</strong> object) that regulates export settings and behavior. This parameter provides events that allow you to add a header and footer to the export output, to customize cells, add rows, etc.</p>
<p>To add a header displaying custom information to the generated MS Excel document, the <strong>XlsxExportOptionsEx.CustomizeSheetHeader</strong> event is handled. In the event handler, the <strong>AddRow</strong>, <strong>InsertImage</strong> and <strong>MergeCells</strong> methods of the event's <strong>ExportContext</strong> parameter are used to add rows with the company name and contact information, insert the company logo and merge specific cells. Cell formatting is specified using objects of the <strong>XlFormattingObject</strong> class.</p>
<p>The <strong>XlsxExportOptionsEx.CustomizeCell</strong> event is used to replace values in the <strong>Discontinued</strong> column with special symbols. The <strong>ColumnName</strong> event parameter allows recognizing the desired column. The <strong>Value</strong> parameter is utilized to substitute certain cell values. The <strong>Handled</strong> parameter is set to <strong>true</strong> to apply the changes made.</p>
<p>The <strong>XlsxExportOptionsEx.AfterAddRow</strong> event handler merges cells in rows that correspond to the grid's group rows using the <strong>ExportContext.MergeCells</strong> method. For group rows, the <strong>DataSourceRowIndex</strong> event parameter returns negative values. The current row in the export output is specified by the <strong>DocumentRow</strong> parameter.</p>
<p>To add a footer to the export document, the <strong>XlsxExportOptionsEx.CustomizeSheetFooter</strong> event is handled. In this event handler, two new rows are added to the output document by calling the <strong>AddRow</strong> method, and their formatting is specified using objects of the <strong>XlFormattingObject</strong> class.</p>
<p>The <strong>XlsxExportOptionsEx.CustomizeSheetSettings</strong> event is handled to specify export settings. The <strong>ExportContext.SetFixedHeader</strong> event method is used to anchor the output document's header to the top, and to set the fixed header height. The <strong>ExportContext.SetFixedHeader</strong> method is called to add the AutoFilter button to the document's cells corresponding to the grid column headers.</p>

<br/>


