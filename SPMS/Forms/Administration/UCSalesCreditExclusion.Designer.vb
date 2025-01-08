<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCSalesCreditExclusion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCSalesCreditExclusion))
        Me.MainTab = New System.Windows.Forms.TabControl
        Me.tbEntry = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbComto = New System.Windows.Forms.ComboBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbyear = New System.Windows.Forms.ComboBox
        Me.cmbMonth = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgDetails = New System.Windows.Forms.DataGridView
        Me.colSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colCustomerCd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colShipto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRegCD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRegName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDistrictCD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDistrictName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAreaCD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAreaName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.llCustomerSelection = New System.Windows.Forms.LinkLabel
        Me.cmbComToDesc = New System.Windows.Forms.ComboBox
        Me.cmbComDesc = New System.Windows.Forms.ComboBox
        Me.cmbcomid = New System.Windows.Forms.ComboBox
        Me.dtEnd = New System.Windows.Forms.DateTimePicker
        Me.dtStart = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbListing = New System.Windows.Forms.TabPage
        Me.GridListing = New System.Windows.Forms.DataGridView
        Me.btnFilter = New System.Windows.Forms.Button
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.cmbfilter = New System.Windows.Forms.ComboBox
        Me.lblSelection = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnAdd = New System.Windows.Forms.ToolStripButton
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnClose = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        '  Me.CachedReportSalesSummaryRegion1 = New SPMS.CachedReportSalesSummaryRegion
        Me.chkIsCreateNew = New System.Windows.Forms.CheckBox
        Me.selCompanyCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.selCompanyName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.selCustoemrCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.selShiptoCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.selCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.selID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.selEffectivityStartDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.selEffectivityEndDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCreateNew = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MainTab.SuspendLayout()
        Me.tbEntry.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbListing.SuspendLayout()
        CType(Me.GridListing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTab
        '
        Me.MainTab.Controls.Add(Me.tbEntry)
        Me.MainTab.Controls.Add(Me.tbListing)
        Me.MainTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTab.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainTab.Location = New System.Drawing.Point(0, 83)
        Me.MainTab.Name = "MainTab"
        Me.MainTab.SelectedIndex = 0
        Me.MainTab.Size = New System.Drawing.Size(618, 491)
        Me.MainTab.TabIndex = 18
        '
        'tbEntry
        '
        Me.tbEntry.BackColor = System.Drawing.Color.White
        Me.tbEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tbEntry.Controls.Add(Me.GroupBox2)
        Me.tbEntry.Location = New System.Drawing.Point(4, 23)
        Me.tbEntry.Name = "tbEntry"
        Me.tbEntry.Padding = New System.Windows.Forms.Padding(3)
        Me.tbEntry.Size = New System.Drawing.Size(610, 464)
        Me.tbEntry.TabIndex = 0
        Me.tbEntry.Text = "Entry"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkIsCreateNew)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbComto)
        Me.GroupBox2.Controls.Add(Me.LinkLabel1)
        Me.GroupBox2.Controls.Add(Me.dgDetails)
        Me.GroupBox2.Controls.Add(Me.llCustomerSelection)
        Me.GroupBox2.Controls.Add(Me.cmbComToDesc)
        Me.GroupBox2.Controls.Add(Me.cmbComDesc)
        Me.GroupBox2.Controls.Add(Me.cmbcomid)
        Me.GroupBox2.Controls.Add(Me.dtEnd)
        Me.GroupBox2.Controls.Add(Me.dtStart)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cmbyear)
        Me.GroupBox2.Controls.Add(Me.cmbMonth)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(604, 458)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 13)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Include to Channel :"
        '
        'cmbComto
        '
        Me.cmbComto.FormattingEnabled = True
        Me.cmbComto.Location = New System.Drawing.Point(175, 67)
        Me.cmbComto.Name = "cmbComto"
        Me.cmbComto.Size = New System.Drawing.Size(121, 21)
        Me.cmbComto.TabIndex = 92
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(8, 108)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(86, 13)
        Me.LinkLabel1.TabIndex = 91
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Delete Selected"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(299, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Year :"
        Me.Label2.Visible = False
        '
        'cmbyear
        '
        Me.cmbyear.FormattingEnabled = True
        Me.cmbyear.Location = New System.Drawing.Point(414, 198)
        Me.cmbyear.Name = "cmbyear"
        Me.cmbyear.Size = New System.Drawing.Size(121, 21)
        Me.cmbyear.TabIndex = 89
        Me.cmbyear.Visible = False
        '
        'cmbMonth
        '
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Location = New System.Drawing.Point(414, 171)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(121, 21)
        Me.cmbMonth.TabIndex = 88
        Me.cmbMonth.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(299, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 87
        Me.Label1.Text = "Month :"
        Me.Label1.Visible = False
        '
        'dgDetails
        '
        Me.dgDetails.AllowUserToAddRows = False
        Me.dgDetails.AllowUserToDeleteRows = False
        Me.dgDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelect, Me.colCustomerCd, Me.colCustomerName, Me.colShipto, Me.colRegCD, Me.colRegName, Me.colDistrictCD, Me.colDistrictName, Me.colAreaCD, Me.colAreaName, Me.colID})
        Me.dgDetails.Location = New System.Drawing.Point(11, 125)
        Me.dgDetails.Name = "dgDetails"
        Me.dgDetails.RowHeadersVisible = False
        Me.dgDetails.Size = New System.Drawing.Size(565, 242)
        Me.dgDetails.TabIndex = 86
        '
        'colSelect
        '
        Me.colSelect.HeaderText = " "
        Me.colSelect.Name = "colSelect"
        Me.colSelect.Width = 35
        '
        'colCustomerCd
        '
        Me.colCustomerCd.HeaderText = "Customer Code"
        Me.colCustomerCd.Name = "colCustomerCd"
        Me.colCustomerCd.ReadOnly = True
        Me.colCustomerCd.Width = 125
        '
        'colCustomerName
        '
        Me.colCustomerName.HeaderText = "Customer Name"
        Me.colCustomerName.Name = "colCustomerName"
        Me.colCustomerName.ReadOnly = True
        Me.colCustomerName.Width = 255
        '
        'colShipto
        '
        Me.colShipto.HeaderText = "Ship to Code"
        Me.colShipto.Name = "colShipto"
        Me.colShipto.ReadOnly = True
        Me.colShipto.Visible = False
        Me.colShipto.Width = 125
        '
        'colRegCD
        '
        Me.colRegCD.HeaderText = "Region Code"
        Me.colRegCD.Name = "colRegCD"
        Me.colRegCD.ReadOnly = True
        Me.colRegCD.Width = 125
        '
        'colRegName
        '
        Me.colRegName.HeaderText = "Region Name"
        Me.colRegName.Name = "colRegName"
        Me.colRegName.ReadOnly = True
        Me.colRegName.Width = 255
        '
        'colDistrictCD
        '
        Me.colDistrictCD.HeaderText = "Province Code"
        Me.colDistrictCD.Name = "colDistrictCD"
        Me.colDistrictCD.ReadOnly = True
        Me.colDistrictCD.Width = 125
        '
        'colDistrictName
        '
        Me.colDistrictName.HeaderText = "Province Name"
        Me.colDistrictName.Name = "colDistrictName"
        Me.colDistrictName.ReadOnly = True
        Me.colDistrictName.Width = 255
        '
        'colAreaCD
        '
        Me.colAreaCD.HeaderText = "Municipality Code"
        Me.colAreaCD.Name = "colAreaCD"
        Me.colAreaCD.ReadOnly = True
        Me.colAreaCD.Width = 125
        '
        'colAreaName
        '
        Me.colAreaName.HeaderText = "Municipality Name"
        Me.colAreaName.Name = "colAreaName"
        Me.colAreaName.ReadOnly = True
        Me.colAreaName.Width = 255
        '
        'colID
        '
        Me.colID.HeaderText = "SalesExtensionID"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Visible = False
        '
        'llCustomerSelection
        '
        Me.llCustomerSelection.AutoSize = True
        Me.llCustomerSelection.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llCustomerSelection.Location = New System.Drawing.Point(100, 108)
        Me.llCustomerSelection.Name = "llCustomerSelection"
        Me.llCustomerSelection.Size = New System.Drawing.Size(139, 13)
        Me.llCustomerSelection.TabIndex = 85
        Me.llCustomerSelection.TabStop = True
        Me.llCustomerSelection.Text = "Click to Select a Customer"
        '
        'cmbComToDesc
        '
        Me.cmbComToDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbComToDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComToDesc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbComToDesc.FormattingEnabled = True
        Me.cmbComToDesc.Location = New System.Drawing.Point(302, 67)
        Me.cmbComToDesc.Name = "cmbComToDesc"
        Me.cmbComToDesc.Size = New System.Drawing.Size(242, 21)
        Me.cmbComToDesc.TabIndex = 84
        '
        'cmbComDesc
        '
        Me.cmbComDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbComDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComDesc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbComDesc.FormattingEnabled = True
        Me.cmbComDesc.Location = New System.Drawing.Point(302, 40)
        Me.cmbComDesc.Name = "cmbComDesc"
        Me.cmbComDesc.Size = New System.Drawing.Size(242, 21)
        Me.cmbComDesc.TabIndex = 84
        '
        'cmbcomid
        '
        Me.cmbcomid.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcomid.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcomid.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcomid.FormattingEnabled = True
        Me.cmbcomid.Location = New System.Drawing.Point(175, 40)
        Me.cmbcomid.Name = "cmbcomid"
        Me.cmbcomid.Size = New System.Drawing.Size(121, 21)
        Me.cmbcomid.TabIndex = 83
        '
        'dtEnd
        '
        Me.dtEnd.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEnd.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEnd.Location = New System.Drawing.Point(153, 419)
        Me.dtEnd.Name = "dtEnd"
        Me.dtEnd.Size = New System.Drawing.Size(91, 22)
        Me.dtEnd.TabIndex = 82
        '
        'dtStart
        '
        Me.dtStart.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStart.Location = New System.Drawing.Point(153, 389)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(91, 22)
        Me.dtStart.TabIndex = 81
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(19, 422)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 13)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "Effectivity End Date :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(19, 396)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 13)
        Me.Label11.TabIndex = 79
        Me.Label11.Text = "Effectivity Start Date :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Exclude from Channel :"
        '
        'tbListing
        '
        Me.tbListing.BackColor = System.Drawing.Color.White
        Me.tbListing.Controls.Add(Me.GridListing)
        Me.tbListing.Controls.Add(Me.btnFilter)
        Me.tbListing.Controls.Add(Me.txtFilter)
        Me.tbListing.Controls.Add(Me.cmbfilter)
        Me.tbListing.Controls.Add(Me.lblSelection)
        Me.tbListing.Location = New System.Drawing.Point(4, 23)
        Me.tbListing.Name = "tbListing"
        Me.tbListing.Padding = New System.Windows.Forms.Padding(3)
        Me.tbListing.Size = New System.Drawing.Size(610, 464)
        Me.tbListing.TabIndex = 1
        Me.tbListing.Text = "Listing"
        '
        'GridListing
        '
        Me.GridListing.AllowUserToAddRows = False
        Me.GridListing.AllowUserToDeleteRows = False
        Me.GridListing.AllowUserToOrderColumns = True
        Me.GridListing.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridListing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridListing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selCompanyCode, Me.selCompanyName, Me.selCustoemrCode, Me.selShiptoCode, Me.selCustomerName, Me.selID, Me.selEffectivityStartDate, Me.selEffectivityEndDate, Me.colCreateNew})
        Me.GridListing.Location = New System.Drawing.Point(9, 45)
        Me.GridListing.Name = "GridListing"
        Me.GridListing.RowHeadersVisible = False
        Me.GridListing.Size = New System.Drawing.Size(595, 363)
        Me.GridListing.TabIndex = 19
        '
        'btnFilter
        '
        Me.btnFilter.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.Location = New System.Drawing.Point(432, 4)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(82, 22)
        Me.btnFilter.TabIndex = 4
        Me.btnFilter.Text = "Filter "
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'txtFilter
        '
        Me.txtFilter.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilter.Location = New System.Drawing.Point(219, 6)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(207, 22)
        Me.txtFilter.TabIndex = 3
        '
        'cmbfilter
        '
        Me.cmbfilter.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbfilter.FormattingEnabled = True
        Me.cmbfilter.Items.AddRange(New Object() {"ChannelCode", "ChannelName", "CustomerCode", "CustomerName"})
        Me.cmbfilter.Location = New System.Drawing.Point(67, 6)
        Me.cmbfilter.Name = "cmbfilter"
        Me.cmbfilter.Size = New System.Drawing.Size(146, 21)
        Me.cmbfilter.TabIndex = 2
        '
        'lblSelection
        '
        Me.lblSelection.AutoSize = True
        Me.lblSelection.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelection.Location = New System.Drawing.Point(6, 14)
        Me.lblSelection.Name = "lblSelection"
        Me.lblSelection.Size = New System.Drawing.Size(60, 13)
        Me.lblSelection.TabIndex = 1
        Me.lblSelection.Text = "Selection :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(182, 21)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Sales Crediting Exclusion"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.btnEdit, Me.btnDelete, Me.btnSave, Me.ToolStripSeparator2, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(618, 25)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnAdd
        '
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(48, 22)
        Me.btnAdd.Text = "Add"
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(47, 22)
        Me.btnEdit.Text = "Edit"
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 22)
        Me.btnDelete.Text = "Delete"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(50, 22)
        Me.btnSave.Text = "Save"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(55, 22)
        Me.btnClose.Text = "Close"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(618, 58)
        Me.Panel1.TabIndex = 16
        '
        'chkIsCreateNew
        '
        Me.chkIsCreateNew.AutoSize = True
        Me.chkIsCreateNew.Checked = True
        Me.chkIsCreateNew.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsCreateNew.Location = New System.Drawing.Point(11, 19)
        Me.chkIsCreateNew.Name = "chkIsCreateNew"
        Me.chkIsCreateNew.Size = New System.Drawing.Size(160, 17)
        Me.chkIsCreateNew.TabIndex = 94
        Me.chkIsCreateNew.Text = "Create New Sales Channel"
        Me.chkIsCreateNew.UseVisualStyleBackColor = True
        '
        'selCompanyCode
        '
        Me.selCompanyCode.HeaderText = "Company Code"
        Me.selCompanyCode.Name = "selCompanyCode"
        Me.selCompanyCode.ReadOnly = True
        Me.selCompanyCode.Width = 125
        '
        'selCompanyName
        '
        Me.selCompanyName.HeaderText = "Company Name"
        Me.selCompanyName.Name = "selCompanyName"
        Me.selCompanyName.ReadOnly = True
        Me.selCompanyName.Width = 255
        '
        'selCustoemrCode
        '
        Me.selCustoemrCode.HeaderText = "Customer Code"
        Me.selCustoemrCode.Name = "selCustoemrCode"
        Me.selCustoemrCode.ReadOnly = True
        Me.selCustoemrCode.Width = 125
        '
        'selShiptoCode
        '
        Me.selShiptoCode.HeaderText = "ShiptoCode"
        Me.selShiptoCode.Name = "selShiptoCode"
        Me.selShiptoCode.ReadOnly = True
        Me.selShiptoCode.Visible = False
        Me.selShiptoCode.Width = 125
        '
        'selCustomerName
        '
        Me.selCustomerName.HeaderText = "Customer Name"
        Me.selCustomerName.Name = "selCustomerName"
        Me.selCustomerName.ReadOnly = True
        Me.selCustomerName.Width = 255
        '
        'selID
        '
        Me.selID.HeaderText = "ID"
        Me.selID.Name = "selID"
        Me.selID.ReadOnly = True
        Me.selID.Visible = False
        '
        'selEffectivityStartDate
        '
        Me.selEffectivityStartDate.HeaderText = "Effectivity Start Date"
        Me.selEffectivityStartDate.Name = "selEffectivityStartDate"
        Me.selEffectivityStartDate.ReadOnly = True
        Me.selEffectivityStartDate.Width = 150
        '
        'selEffectivityEndDate
        '
        Me.selEffectivityEndDate.HeaderText = "Effectivity End Date"
        Me.selEffectivityEndDate.Name = "selEffectivityEndDate"
        Me.selEffectivityEndDate.ReadOnly = True
        Me.selEffectivityEndDate.Width = 150
        '
        'colCreateNew
        '
        Me.colCreateNew.HeaderText = "Create New Channel"
        Me.colCreateNew.Name = "colCreateNew"
        Me.colCreateNew.ReadOnly = True
        '
        'UCSalesCreditExclusion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.MainTab)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "UCSalesCreditExclusion"
        Me.Size = New System.Drawing.Size(618, 574)
        Me.MainTab.ResumeLayout(False)
        Me.tbEntry.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbListing.ResumeLayout(False)
        Me.tbListing.PerformLayout()
        CType(Me.GridListing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainTab As System.Windows.Forms.TabControl
    Friend WithEvents tbEntry As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbListing As System.Windows.Forms.TabPage
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents cmbfilter As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelection As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmbComDesc As System.Windows.Forms.ComboBox
    Friend WithEvents cmbcomid As System.Windows.Forms.ComboBox
    Friend WithEvents dgDetails As System.Windows.Forms.DataGridView
    Friend WithEvents llCustomerSelection As System.Windows.Forms.LinkLabel
    Friend WithEvents GridListing As System.Windows.Forms.DataGridView
    ' Friend WithEvents CachedReportSalesSummaryRegion1 As SPMS.CachedReportSalesSummaryRegion
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbyear As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents colSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colCustomerCd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colShipto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRegCD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRegName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDistrictCD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDistrictName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAreaCD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAreaName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbComto As System.Windows.Forms.ComboBox
    Friend WithEvents cmbComToDesc As System.Windows.Forms.ComboBox
    Friend WithEvents chkIsCreateNew As System.Windows.Forms.CheckBox
    Friend WithEvents selCompanyCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selCompanyName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selCustoemrCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selShiptoCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selEffectivityStartDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selEffectivityEndDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCreateNew As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
