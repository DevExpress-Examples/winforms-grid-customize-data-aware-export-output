Namespace GridDataAwareExportCustomization
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
			Me.nwindDataSet = New GridDataAwareExportCustomization.nwindDataSet()
			Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.productsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colProductName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colCategoryID = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colQuantityPerUnit = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colUnitPrice = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colUnitsInStock = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.repositoryItemSpinEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
			Me.colUnitsOnOrder = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.repositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
			Me.colReorderLevel = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.repositoryItemProgressBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
			Me.colDiscontinued = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.categoryName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.btn_Export = New DevExpress.XtraEditors.SimpleButton()
			Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
			CType(Me.nwindDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.layoutControl1.SuspendLayout()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.productsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nwindDataSet
			' 
			Me.nwindDataSet.DataSetName = "nwindDataSet"
			Me.nwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
			' 
			' layoutControl1
			' 
			Me.layoutControl1.Controls.Add(Me.gridControl1)
			Me.layoutControl1.Controls.Add(Me.btn_Export)
			Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControl1.Name = "layoutControl1"
			Me.layoutControl1.Root = Me.layoutControlGroup1
			Me.layoutControl1.Size = New System.Drawing.Size(924, 434)
			Me.layoutControl1.TabIndex = 2
			Me.layoutControl1.Text = "layoutControl1"
			' 
			' gridControl1
			' 
			Me.gridControl1.DataSource = Me.productsBindingSource
			Me.gridControl1.Location = New System.Drawing.Point(12, 38)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() { Me.repositoryItemProgressBar1, Me.repositoryItemSpinEdit1, Me.repositoryItemSpinEdit2})
			Me.gridControl1.Size = New System.Drawing.Size(900, 384)
			Me.gridControl1.TabIndex = 4
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' productsBindingSource
			' 
			Me.productsBindingSource.DataMember = "Products"
			Me.productsBindingSource.DataSource = Me.nwindDataSet
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colProductName, Me.colCategoryID, Me.colQuantityPerUnit, Me.colUnitPrice, Me.colUnitsInStock, Me.colUnitsOnOrder, Me.colReorderLevel, Me.colDiscontinued, Me.categoryName})
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.GroupCount = 1
			Me.gridView1.GroupFormat = " [#image]{1} {2}"
			Me.gridView1.Name = "gridView1"
			Me.gridView1.OptionsView.AllowHtmlDrawHeaders = True
			Me.gridView1.OptionsView.ShowDetailButtons = False
			Me.gridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() { New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.categoryName, DevExpress.Data.ColumnSortOrder.Ascending)})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
			' 
			' colProductName
			' 
			Me.colProductName.FieldName = "ProductName"
			Me.colProductName.Name = "colProductName"
			Me.colProductName.Visible = True
			Me.colProductName.VisibleIndex = 0
			Me.colProductName.Width = 240
			' 
			' colCategoryID
			' 
			Me.colCategoryID.FieldName = "CategoryID"
			Me.colCategoryID.Name = "colCategoryID"
			' 
			' colQuantityPerUnit
			' 
			Me.colQuantityPerUnit.FieldName = "QuantityPerUnit"
			Me.colQuantityPerUnit.Name = "colQuantityPerUnit"
			Me.colQuantityPerUnit.Visible = True
			Me.colQuantityPerUnit.VisibleIndex = 1
			Me.colQuantityPerUnit.Width = 154
			' 
			' colUnitPrice
			' 
			Me.colUnitPrice.DisplayFormat.FormatString = "c"
			Me.colUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
			Me.colUnitPrice.FieldName = "UnitPrice"
			Me.colUnitPrice.Image = (CType(resources.GetObject("colUnitPrice.Image"), System.Drawing.Image))
			Me.colUnitPrice.Name = "colUnitPrice"
			Me.colUnitPrice.Visible = True
			Me.colUnitPrice.VisibleIndex = 5
			Me.colUnitPrice.Width = 144
			' 
			' colUnitsInStock
			' 
			Me.colUnitsInStock.ColumnEdit = Me.repositoryItemSpinEdit2
			Me.colUnitsInStock.FieldName = "UnitsInStock"
			Me.colUnitsInStock.Name = "colUnitsInStock"
			Me.colUnitsInStock.Visible = True
			Me.colUnitsInStock.VisibleIndex = 2
			Me.colUnitsInStock.Width = 132
			' 
			' repositoryItemSpinEdit2
			' 
			Me.repositoryItemSpinEdit2.AutoHeight = False
			Me.repositoryItemSpinEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.repositoryItemSpinEdit2.Name = "repositoryItemSpinEdit2"
			' 
			' colUnitsOnOrder
			' 
			Me.colUnitsOnOrder.ColumnEdit = Me.repositoryItemSpinEdit1
			Me.colUnitsOnOrder.FieldName = "UnitsOnOrder"
			Me.colUnitsOnOrder.Name = "colUnitsOnOrder"
			Me.colUnitsOnOrder.Width = 127
			' 
			' repositoryItemSpinEdit1
			' 
			Me.repositoryItemSpinEdit1.AutoHeight = False
			Me.repositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1"
			' 
			' colReorderLevel
			' 
			Me.colReorderLevel.Caption = "Reorder <b>Level"
			Me.colReorderLevel.ColumnEdit = Me.repositoryItemProgressBar1
			Me.colReorderLevel.FieldName = "ReorderLevel"
			Me.colReorderLevel.Name = "colReorderLevel"
			Me.colReorderLevel.Visible = True
			Me.colReorderLevel.VisibleIndex = 3
			Me.colReorderLevel.Width = 132
			' 
			' repositoryItemProgressBar1
			' 
			Me.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1"
			' 
			' colDiscontinued
			' 
			Me.colDiscontinued.FieldName = "Discontinued"
			Me.colDiscontinued.Name = "colDiscontinued"
			Me.colDiscontinued.Visible = True
			Me.colDiscontinued.VisibleIndex = 4
			Me.colDiscontinued.Width = 80
			' 
			' categoryName
			' 
			Me.categoryName.Caption = "CategoryName"
			Me.categoryName.FieldName = "gridColumn1"
			Me.categoryName.Name = "categoryName"
			Me.categoryName.UnboundType = DevExpress.Data.UnboundColumnType.String
			Me.categoryName.Visible = True
			Me.categoryName.VisibleIndex = 1
			Me.categoryName.Width = 104
			' 
			' btn_Export
			' 
			Me.btn_Export.Location = New System.Drawing.Point(12, 12)
			Me.btn_Export.Name = "btn_Export"
			Me.btn_Export.Size = New System.Drawing.Size(900, 22)
			Me.btn_Export.StyleController = Me.layoutControl1
			Me.btn_Export.TabIndex = 2
			Me.btn_Export.Text = "Export to XLSX format"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
			' 
			' layoutControlGroup1
			' 
			Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
			Me.layoutControlGroup1.GroupBordersVisible = False
			Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlItem2, Me.layoutControlItem1})
			Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlGroup1.Name = "layoutControlGroup1"
			Me.layoutControlGroup1.Size = New System.Drawing.Size(924, 434)
			Me.layoutControlGroup1.TextVisible = False
			' 
			' layoutControlItem2
			' 
			Me.layoutControlItem2.Control = Me.btn_Export
			Me.layoutControlItem2.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlItem2.Name = "layoutControlItem2"
			Me.layoutControlItem2.Size = New System.Drawing.Size(904, 26)
			Me.layoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem2.TextVisible = False
			' 
			' layoutControlItem1
			' 
			Me.layoutControlItem1.Control = Me.gridControl1
			Me.layoutControlItem1.Location = New System.Drawing.Point(0, 26)
			Me.layoutControlItem1.Name = "layoutControlItem1"
			Me.layoutControlItem1.Size = New System.Drawing.Size(904, 388)
			Me.layoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem1.TextVisible = False
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(924, 434)
			Me.Controls.Add(Me.layoutControl1)
			Me.LookAndFeel.SkinName = "Office 2013"
			Me.Name = "Form1"
			Me.Text = "Grid Data-Aware Export"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Load += new System.EventHandler(this.Form1_Load);
			CType(Me.nwindDataSet, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.layoutControl1.ResumeLayout(False)
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.productsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private nwindDataSet As nwindDataSet
		Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
		Private WithEvents btn_Export As DevExpress.XtraEditors.SimpleButton
		Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
		Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private WithEvents gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
		Private productsBindingSource As System.Windows.Forms.BindingSource
		Private colProductName As DevExpress.XtraGrid.Columns.GridColumn
		Private colCategoryID As DevExpress.XtraGrid.Columns.GridColumn
		Private colQuantityPerUnit As DevExpress.XtraGrid.Columns.GridColumn
		Private colUnitPrice As DevExpress.XtraGrid.Columns.GridColumn
		Private colUnitsInStock As DevExpress.XtraGrid.Columns.GridColumn
		Private colUnitsOnOrder As DevExpress.XtraGrid.Columns.GridColumn
		Private colReorderLevel As DevExpress.XtraGrid.Columns.GridColumn
		Private colDiscontinued As DevExpress.XtraGrid.Columns.GridColumn
		Private categoryName As DevExpress.XtraGrid.Columns.GridColumn
		Private repositoryItemSpinEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
		Private repositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
		Private repositoryItemProgressBar1 As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar

	End Class
End Namespace

