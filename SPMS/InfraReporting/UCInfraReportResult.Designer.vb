<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCInfraReportResult
    Inherits Althea.Base.UI.BasePage

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueList1 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(10350469)
        Dim ValueList2 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(10391032)
        Dim ValueList3 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(10391547)
        Dim ValueList4 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(10391829)
        Dim ValueList5 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(10392047)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCInfraReportResult))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgFilter = New System.Windows.Forms.DataGridView()
        Me.colInputType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLabel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClear = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.txtReportTitle = New System.Windows.Forms.TextBox()
        Me.lnkReportTitle = New System.Windows.Forms.LinkLabel()
        Me.dgView = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.colExporttoExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.Panel1.SuspendLayout()
        CType(Me.dgFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BasePageHeader1
        '
        Me.BasePageHeader1.HeaderText = "Report Viewer"
        Me.BasePageHeader1.Size = New System.Drawing.Size(758, 41)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cboType)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dgFilter)
        Me.Panel1.Controls.Add(Me.txtReportTitle)
        Me.Panel1.Controls.Add(Me.lnkReportTitle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 66)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(758, 153)
        Me.Panel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(60, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 217
        Me.Label2.Text = "Type :"
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"Sales Summary Report", "Sales Transaction Report", "Master File Report", "Others", "Item", "Customer", "Territory Manager"})
        Me.cboType.Location = New System.Drawing.Point(104, 11)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(177, 21)
        Me.cboType.TabIndex = 216
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Filter/s :"
        '
        'dgFilter
        '
        Me.dgFilter.AllowUserToAddRows = False
        Me.dgFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFilter.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInputType, Me.colLabel, Me.colValue, Me.colClear})
        Me.dgFilter.Location = New System.Drawing.Point(104, 67)
        Me.dgFilter.Name = "dgFilter"
        Me.dgFilter.RowHeadersVisible = False
        Me.dgFilter.Size = New System.Drawing.Size(405, 80)
        Me.dgFilter.TabIndex = 2
        '
        'colInputType
        '
        Me.colInputType.HeaderText = "Input Type"
        Me.colInputType.Name = "colInputType"
        Me.colInputType.ReadOnly = True
        '
        'colLabel
        '
        Me.colLabel.HeaderText = "Label"
        Me.colLabel.Name = "colLabel"
        Me.colLabel.ReadOnly = True
        '
        'colValue
        '
        Me.colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colValue.HeaderText = "Value"
        Me.colValue.Name = "colValue"
        '
        'colClear
        '
        Me.colClear.HeaderText = "Clear"
        Me.colClear.Name = "colClear"
        Me.colClear.ReadOnly = True
        Me.colClear.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colClear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'txtReportTitle
        '
        Me.txtReportTitle.Location = New System.Drawing.Point(104, 38)
        Me.txtReportTitle.Name = "txtReportTitle"
        Me.txtReportTitle.Size = New System.Drawing.Size(175, 21)
        Me.txtReportTitle.TabIndex = 1
        '
        'lnkReportTitle
        '
        Me.lnkReportTitle.AutoSize = True
        Me.lnkReportTitle.Location = New System.Drawing.Point(32, 41)
        Me.lnkReportTitle.Name = "lnkReportTitle"
        Me.lnkReportTitle.Size = New System.Drawing.Size(66, 13)
        Me.lnkReportTitle.TabIndex = 0
        Me.lnkReportTitle.TabStop = True
        Me.lnkReportTitle.Text = "Repor Title :"
        '
        'dgView
        '
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgView.DisplayLayout.Appearance = Appearance2
        Me.dgView.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgView.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.dgView.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgView.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.dgView.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance5.BackColor = System.Drawing.Color.White
        Appearance5.BackColor2 = System.Drawing.Color.White
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgView.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.dgView.DisplayLayout.MaxColScrollRegions = 1
        Me.dgView.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgView.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.Color.White
        Appearance7.ForeColor = System.Drawing.Color.White
        Me.dgView.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Appearance16.BackColor = System.Drawing.Color.White
        Me.dgView.DisplayLayout.Override.AddRowAppearance = Appearance16
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.dgView.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dgView.DisplayLayout.Override.CellAppearance = Appearance9
        Me.dgView.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.dgView.DisplayLayout.Override.CellPadding = 0
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Client
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.dgView.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.ForeColor = System.Drawing.Color.Black
        Appearance11.TextHAlignAsString = "Left"
        Me.dgView.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.dgView.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsVista
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.dgView.DisplayLayout.Override.RowAppearance = Appearance12
        Me.dgView.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BorderColor = System.Drawing.Color.White
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.ForeColor = System.Drawing.Color.Gray
        Me.dgView.DisplayLayout.Override.SummaryFooterAppearance = Appearance1
        Appearance15.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance15.BackColor2 = System.Drawing.Color.White
        Appearance15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgView.DisplayLayout.Override.SummaryFooterCaptionAppearance = Appearance15
        Me.dgView.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.[True]
        Appearance14.BackColor = System.Drawing.Color.White
        Appearance14.BackColor2 = System.Drawing.Color.White
        Me.dgView.DisplayLayout.Override.SummaryValueAppearance = Appearance14
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dgView.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.dgView.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgView.DisplayLayout.UseFixedHeaders = True
        ValueList1.Key = "0"
        Me.dgView.DisplayLayout.ValueLists.AddRange(New Infragistics.Win.ValueList() {ValueList1, ValueList2, ValueList3, ValueList4, ValueList5})
        Me.dgView.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dgView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgView.Location = New System.Drawing.Point(0, 219)
        Me.dgView.Name = "dgView"
        Me.dgView.Size = New System.Drawing.Size(758, 206)
        Me.dgView.TabIndex = 102
        Me.dgView.Text = "Report"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRefresh, Me.colExporttoExcel, Me.ToolStripSeparator1, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 41)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(758, 25)
        Me.ToolStrip1.TabIndex = 103
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(66, 22)
        Me.btnRefresh.Text = "Refresh"
        '
        'colExporttoExcel
        '
        Me.colExporttoExcel.Image = CType(resources.GetObject("colExporttoExcel.Image"), System.Drawing.Image)
        Me.colExporttoExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.colExporttoExcel.Name = "colExporttoExcel"
        Me.colExporttoExcel.Size = New System.Drawing.Size(103, 22)
        Me.colExporttoExcel.Text = "Export to Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 22)
        Me.btnClose.Text = "Close"
        '
        'UCInfraReportResult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgView)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "UCInfraReportResult"
        Me.Size = New System.Drawing.Size(758, 425)
        Me.Controls.SetChildIndex(Me.BasePageHeader1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.dgView, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgFilter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgView As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgFilter As System.Windows.Forms.DataGridView
    Friend WithEvents txtReportTitle As System.Windows.Forms.TextBox
    Friend WithEvents lnkReportTitle As System.Windows.Forms.LinkLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents colInputType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLabel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colClear As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents colExporttoExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox

End Class
