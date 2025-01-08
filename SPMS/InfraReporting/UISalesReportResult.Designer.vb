<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UISalesReportResult
    Inherits System.Windows.Forms.UserControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UISalesReportResult))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.colExporttoExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
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
        Me.rptViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1378, 58)
        Me.Panel1.TabIndex = 50
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(5, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Sales Report Viewer"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRefresh, Me.colExporttoExcel, Me.ToolStripSeparator1, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1378, 25)
        Me.ToolStrip1.TabIndex = 104
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
        Me.colExporttoExcel.Size = New System.Drawing.Size(105, 22)
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
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 83)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1378, 579)
        Me.Panel2.TabIndex = 105
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 176)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1378, 403)
        Me.Panel4.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.cboType)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.dgFilter)
        Me.Panel3.Controls.Add(Me.txtReportTitle)
        Me.Panel3.Controls.Add(Me.lnkReportTitle)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1378, 176)
        Me.Panel3.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(48, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 223
        Me.Label2.Text = "Type :"
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"Sales Summary Report", "Sales Transaction Report", "Master File Report", "Others", "Item", "Customer", "Territory Manager"})
        Me.cboType.Location = New System.Drawing.Point(92, 14)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(175, 21)
        Me.cboType.TabIndex = 222
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 221
        Me.Label1.Text = "Filter/s :"
        '
        'dgFilter
        '
        Me.dgFilter.AllowUserToAddRows = False
        Me.dgFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFilter.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInputType, Me.colLabel, Me.colValue, Me.colClear})
        Me.dgFilter.Location = New System.Drawing.Point(92, 62)
        Me.dgFilter.Name = "dgFilter"
        Me.dgFilter.RowHeadersVisible = False
        Me.dgFilter.Size = New System.Drawing.Size(405, 107)
        Me.dgFilter.TabIndex = 220
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
        Me.txtReportTitle.Location = New System.Drawing.Point(92, 38)
        Me.txtReportTitle.Name = "txtReportTitle"
        Me.txtReportTitle.Size = New System.Drawing.Size(405, 20)
        Me.txtReportTitle.TabIndex = 219
        '
        'lnkReportTitle
        '
        Me.lnkReportTitle.AutoSize = True
        Me.lnkReportTitle.Location = New System.Drawing.Point(20, 41)
        Me.lnkReportTitle.Name = "lnkReportTitle"
        Me.lnkReportTitle.Size = New System.Drawing.Size(65, 13)
        Me.lnkReportTitle.TabIndex = 218
        Me.lnkReportTitle.TabStop = True
        Me.lnkReportTitle.Text = "Repor Title :"
        '
        'rptViewer
        '
        Me.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptViewer.Location = New System.Drawing.Point(119, 11)
        Me.rptViewer.Name = "rptViewer"
        Me.rptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.rptViewer.ServerReport.ReportServerUrl = New System.Uri("", System.UriKind.Relative)
        Me.rptViewer.Size = New System.Drawing.Size(723, 548)
        Me.rptViewer.TabIndex = 2
        '
        'UISalesReportResult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UISalesReportResult"
        Me.Size = New System.Drawing.Size(1378, 662)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents colExporttoExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgFilter As System.Windows.Forms.DataGridView
    Friend WithEvents colInputType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLabel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colClear As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents txtReportTitle As System.Windows.Forms.TextBox
    Friend WithEvents lnkReportTitle As System.Windows.Forms.LinkLabel
    Private WithEvents rptViewer As Microsoft.Reporting.WinForms.ReportViewer

End Class
