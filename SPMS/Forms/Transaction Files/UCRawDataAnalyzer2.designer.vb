<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCRawDataAnalyzer2
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.lblChannel = New System.Windows.Forms.ToolStripLabel
        Me.tbEntry = New System.Windows.Forms.TabPage
        Me.GviewTotalSales = New System.Windows.Forms.DataGridView
        Me.colitemcode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSalesQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRawSalesQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAmountSales = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtConfig = New System.Windows.Forms.TextBox
        Me.txtBatchNo = New System.Windows.Forms.TextBox
        Me.txtMonthDescription = New System.Windows.Forms.TextBox
        Me.txtCompany = New System.Windows.Forms.TextBox
        Me.cboConfig = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lnkBatch = New System.Windows.Forms.LinkLabel
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboMonth = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboCalendarYear = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboCompany = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.MainTab = New System.Windows.Forms.TabControl
        Me.Label2 = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        Me.tbEntry.SuspendLayout()
        CType(Me.GviewTotalSales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'BasePageHeader1
        '
        Me.BasePageHeader1.HeaderText = "RawData Analyzer"
        Me.BasePageHeader1.Location = New System.Drawing.Point(0, 25)
        Me.BasePageHeader1.Size = New System.Drawing.Size(650, 41)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.ToolStripSeparator2, Me.btnClose, Me.ToolStripSeparator1, Me.lblChannel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(650, 25)
        Me.ToolStrip1.TabIndex = 41
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSave
        '
        Me.btnSave.Image = Global.SPMSOPCI.My.Resources.Resources.WSS_DocLib1
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(51, 22)
        Me.btnSave.Text = "Start"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnClose
        '
        Me.btnClose.Image = Global.SPMSOPCI.My.Resources.Resources.cancel
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(55, 22)
        Me.btnClose.Text = "Close"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblChannel
        '
        Me.lblChannel.Name = "lblChannel"
        Me.lblChannel.Size = New System.Drawing.Size(50, 22)
        Me.lblChannel.Text = "Channel"
        '
        'tbEntry
        '
        Me.tbEntry.BackColor = System.Drawing.SystemColors.Control
        Me.tbEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbEntry.Controls.Add(Me.Label2)
        Me.tbEntry.Controls.Add(Me.GviewTotalSales)
        Me.tbEntry.Controls.Add(Me.txtConfig)
        Me.tbEntry.Controls.Add(Me.txtBatchNo)
        Me.tbEntry.Controls.Add(Me.txtMonthDescription)
        Me.tbEntry.Controls.Add(Me.txtCompany)
        Me.tbEntry.Controls.Add(Me.cboConfig)
        Me.tbEntry.Controls.Add(Me.Label1)
        Me.tbEntry.Controls.Add(Me.lnkBatch)
        Me.tbEntry.Controls.Add(Me.Label12)
        Me.tbEntry.Controls.Add(Me.cboMonth)
        Me.tbEntry.Controls.Add(Me.Label17)
        Me.tbEntry.Controls.Add(Me.cboCalendarYear)
        Me.tbEntry.Controls.Add(Me.Label4)
        Me.tbEntry.Controls.Add(Me.cboCompany)
        Me.tbEntry.Controls.Add(Me.Label6)
        Me.tbEntry.Location = New System.Drawing.Point(4, 22)
        Me.tbEntry.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbEntry.Name = "tbEntry"
        Me.tbEntry.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbEntry.Size = New System.Drawing.Size(642, 742)
        Me.tbEntry.TabIndex = 0
        Me.tbEntry.Text = "Parameter"
        '
        'GviewTotalSales
        '
        Me.GviewTotalSales.AllowUserToAddRows = False
        Me.GviewTotalSales.CausesValidation = False
        Me.GviewTotalSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GviewTotalSales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colitemcode, Me.colItemName, Me.colSalesQty, Me.colRawSalesQty, Me.colAmountSales})
        Me.GviewTotalSales.Location = New System.Drawing.Point(19, 160)
        Me.GviewTotalSales.Name = "GviewTotalSales"
        Me.GviewTotalSales.Size = New System.Drawing.Size(636, 440)
        Me.GviewTotalSales.TabIndex = 43
        '
        'colitemcode
        '
        Me.colitemcode.HeaderText = "Item Mother Code"
        Me.colitemcode.Name = "colitemcode"
        Me.colitemcode.Width = 125
        '
        'colItemName
        '
        Me.colItemName.HeaderText = "Item Monther Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.Width = 155
        '
        'colSalesQty
        '
        Me.colSalesQty.HeaderText = "Sales Qty"
        Me.colSalesQty.Name = "colSalesQty"
        Me.colSalesQty.Width = 90
        '
        'colRawSalesQty
        '
        Me.colRawSalesQty.HeaderText = "RawData Qty"
        Me.colRawSalesQty.Name = "colRawSalesQty"
        '
        'colAmountSales
        '
        Me.colAmountSales.HeaderText = "Sales Amount"
        Me.colAmountSales.Name = "colAmountSales"
        '
        'txtConfig
        '
        Me.txtConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConfig.Location = New System.Drawing.Point(203, 32)
        Me.txtConfig.Name = "txtConfig"
        Me.txtConfig.Size = New System.Drawing.Size(447, 22)
        Me.txtConfig.TabIndex = 42
        '
        'txtBatchNo
        '
        Me.txtBatchNo.BackColor = System.Drawing.Color.White
        Me.txtBatchNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchNo.Location = New System.Drawing.Point(97, 107)
        Me.txtBatchNo.Name = "txtBatchNo"
        Me.txtBatchNo.ReadOnly = True
        Me.txtBatchNo.Size = New System.Drawing.Size(553, 22)
        Me.txtBatchNo.TabIndex = 39
        '
        'txtMonthDescription
        '
        Me.txtMonthDescription.BackColor = System.Drawing.Color.White
        Me.txtMonthDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMonthDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonthDescription.Location = New System.Drawing.Point(346, 82)
        Me.txtMonthDescription.Name = "txtMonthDescription"
        Me.txtMonthDescription.ReadOnly = True
        Me.txtMonthDescription.Size = New System.Drawing.Size(304, 21)
        Me.txtMonthDescription.TabIndex = 33
        '
        'txtCompany
        '
        Me.txtCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompany.Location = New System.Drawing.Point(203, 57)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Size = New System.Drawing.Size(447, 22)
        Me.txtCompany.TabIndex = 14
        '
        'cboConfig
        '
        Me.cboConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConfig.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboConfig.FormattingEnabled = True
        Me.cboConfig.Location = New System.Drawing.Point(97, 32)
        Me.cboConfig.Name = "cboConfig"
        Me.cboConfig.Size = New System.Drawing.Size(104, 21)
        Me.cboConfig.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "ConfigType :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lnkBatch
        '
        Me.lnkBatch.AutoSize = True
        Me.lnkBatch.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkBatch.LinkColor = System.Drawing.Color.Orange
        Me.lnkBatch.Location = New System.Drawing.Point(29, 110)
        Me.lnkBatch.Name = "lnkBatch"
        Me.lnkBatch.Size = New System.Drawing.Size(62, 15)
        Me.lnkBatch.TabIndex = 38
        Me.lnkBatch.TabStop = True
        Me.lnkBatch.Text = "Batch No :"
        Me.lnkBatch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(203, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 15)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Month :"
        '
        'cboMonth
        '
        Me.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonth.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(253, 82)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(89, 21)
        Me.cboMonth.TabIndex = 31
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(56, 84)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(36, 15)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "Year :"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCalendarYear
        '
        Me.cboCalendarYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCalendarYear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboCalendarYear.FormattingEnabled = True
        Me.cboCalendarYear.Location = New System.Drawing.Point(97, 82)
        Me.cboCalendarYear.Name = "cboCalendarYear"
        Me.cboCalendarYear.Size = New System.Drawing.Size(103, 21)
        Me.cboCalendarYear.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Data Source"
        '
        'cboCompany
        '
        Me.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompany.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboCompany.FormattingEnabled = True
        Me.cboCompany.Location = New System.Drawing.Point(97, 57)
        Me.cboCompany.Name = "cboCompany"
        Me.cboCompany.Size = New System.Drawing.Size(104, 21)
        Me.cboCompany.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(24, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Distributor :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MainTab
        '
        Me.MainTab.Controls.Add(Me.tbEntry)
        Me.MainTab.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MainTab.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainTab.Location = New System.Drawing.Point(0, 66)
        Me.MainTab.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainTab.Name = "MainTab"
        Me.MainTab.SelectedIndex = 0
        Me.MainTab.Size = New System.Drawing.Size(650, 768)
        Me.MainTab.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Product Sales "
        '
        'UCRawDataAnalyzer2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MainTab)
        Me.Name = "UCRawDataAnalyzer2"
        Me.Size = New System.Drawing.Size(650, 768)
        Me.Controls.SetChildIndex(Me.MainTab, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
        Me.Controls.SetChildIndex(Me.BasePageHeader1, 0)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.tbEntry.ResumeLayout(False)
        Me.tbEntry.PerformLayout()
        CType(Me.GviewTotalSales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainTab.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblChannel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tbEntry As System.Windows.Forms.TabPage
    Friend WithEvents txtConfig As System.Windows.Forms.TextBox
    Friend WithEvents txtBatchNo As System.Windows.Forms.TextBox
    Friend WithEvents txtMonthDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtCompany As System.Windows.Forms.TextBox
    Friend WithEvents cboConfig As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lnkBatch As System.Windows.Forms.LinkLabel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboCalendarYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCompany As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MainTab As System.Windows.Forms.TabControl
    Friend WithEvents MasterTemplate As Telerik.WinControls.UI.RadGridView
    Friend WithEvents GviewTotalSales As System.Windows.Forms.DataGridView
    Friend WithEvents colitemcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSalesQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRawSalesQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmountSales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
