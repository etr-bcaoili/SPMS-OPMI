<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCRawDataAnalyzerOld
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
        Me.MainTab = New System.Windows.Forms.TabControl
        Me.tbEntry = New System.Windows.Forms.TabPage
        Me.txtBatchNo = New System.Windows.Forms.TextBox
        Me.lnkBatch = New System.Windows.Forms.LinkLabel
        Me.dgBatch = New System.Windows.Forms.DataGridView
        Me.colCompanyCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFileName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCutMo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colYear = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblBatchNo = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.txtMonthDescription = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboMonth = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboCalendarYear = New System.Windows.Forms.ComboBox
        Me.txtCompany = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboCompany = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.tbtasks = New System.Windows.Forms.TabPage
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.chkUnmappedShipto = New System.Windows.Forms.CheckBox
        Me.chkOverrideShipToCustomers = New System.Windows.Forms.CheckBox
        Me.LinkLabel17 = New System.Windows.Forms.LinkLabel
        Me.ProgressBar4 = New System.Windows.Forms.ProgressBar
        Me.chkShipto = New System.Windows.Forms.CheckBox
        Me.lnkAddressProblem = New System.Windows.Forms.LinkLabel
        Me.chkCustWithoutAssignedTerritory = New System.Windows.Forms.CheckBox
        Me.chkOverrideUnmappedCustomer = New System.Windows.Forms.CheckBox
        Me.pbar2 = New System.Windows.Forms.ProgressBar
        Me.pbar4 = New System.Windows.Forms.ProgressBar
        Me.chkItemsNotInSystem = New System.Windows.Forms.CheckBox
        Me.chkOverrideCustomerWithStateAreaTerritoryProblem = New System.Windows.Forms.CheckBox
        Me.lnkUnmappedShipToCustomers = New System.Windows.Forms.LinkLabel
        Me.ProgressBar3 = New System.Windows.Forms.ProgressBar
        Me.lnkShipToNotInSystem = New System.Windows.Forms.LinkLabel
        Me.chkShipToNotInSystem = New System.Windows.Forms.CheckBox
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar
        Me.lnkItemsNotInPricelist = New System.Windows.Forms.LinkLabel
        Me.chkItemsNotinPricelist = New System.Windows.Forms.CheckBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.lnkSharing = New System.Windows.Forms.LinkLabel
        Me.chkUnmapped = New System.Windows.Forms.CheckBox
        Me.lnkWithoutAgent = New System.Windows.Forms.LinkLabel
        Me.lnkCustomersNotInSystem = New System.Windows.Forms.LinkLabel
        Me.pbar3 = New System.Windows.Forms.ProgressBar
        Me.chkCustWithStateAreaTerritoryProblem = New System.Windows.Forms.CheckBox
        Me.pbar1 = New System.Windows.Forms.ProgressBar
        Me.chkCustNotInSystem = New System.Windows.Forms.CheckBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.chkStartCrediting = New System.Windows.Forms.CheckBox
        Me.chkRunPreUpload = New System.Windows.Forms.CheckBox
        Me.tbListing = New System.Windows.Forms.TabPage
        Me.tbPages = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label7 = New System.Windows.Forms.Label
        Me.LinkLabel7 = New System.Windows.Forms.LinkLabel
        Me.Label1 = New System.Windows.Forms.Label
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.dgCustomerNotintheSystem = New System.Windows.Forms.DataGridView
        Me.colSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colCustomerCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCustomerClass = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCustomerAddress = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCustomerAddress2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colShipTo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colShipToName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRegion = New System.Windows.Forms.DataGridViewLinkColumn
        Me.colProvince = New System.Windows.Forms.DataGridViewLinkColumn
        Me.colArea = New System.Windows.Forms.DataGridViewLinkColumn
        Me.colZipCode = New System.Windows.Forms.DataGridViewLinkColumn
        Me.col1Shared = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.LinkLabel29 = New System.Windows.Forms.LinkLabel
        Me.TabPage8 = New System.Windows.Forms.TabPage
        Me.LinkLabel23 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel24 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel25 = New System.Windows.Forms.LinkLabel
        Me.Label19 = New System.Windows.Forms.Label
        Me.dgShipToNotInSystem = New System.Windows.Forms.DataGridView
        Me.col8Select = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.col8CustomerCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col8CustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col8ShipToCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col8ShipToName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col8ShipToCustomerAddress1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col8ShipToAddress2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col8CustomerGrp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col8Region = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col8Province = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col8Municipality = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col8ZipCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabPage9 = New System.Windows.Forms.TabPage
        Me.LinkLabel26 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel27 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel28 = New System.Windows.Forms.LinkLabel
        Me.Label24 = New System.Windows.Forms.Label
        Me.dgCompanyItemsNotInSystem = New System.Windows.Forms.DataGridView
        Me.col9Select = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.col9ItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col9ItemBrandName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.LinkLabel21 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel11 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel12 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel13 = New System.Windows.Forms.LinkLabel
        Me.Label10 = New System.Windows.Forms.Label
        Me.dgCustomerWithStateAreaTerritory = New System.Windows.Forms.DataGridView
        Me.col4Select = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.col4CustomerCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col4CustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col4CustomerAddress1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col4CustomerAddress2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col4Region = New System.Windows.Forms.DataGridViewLinkColumn
        Me.col4RegionName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col4Province = New System.Windows.Forms.DataGridViewLinkColumn
        Me.col4ProvinceName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col4Municipality = New System.Windows.Forms.DataGridViewLinkColumn
        Me.col4MunicipalityName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col4ZipCode = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TabPage7 = New System.Windows.Forms.TabPage
        Me.LinkLabel22 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel18 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel19 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel20 = New System.Windows.Forms.LinkLabel
        Me.Label18 = New System.Windows.Forms.Label
        Me.dgShipToCustomer = New System.Windows.Forms.DataGridView
        Me.col6Select = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.col6CustomerCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col6CustName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col6ShipToCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col6ShipToName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col6CustomerAddress = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col6CustomerAddress2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col6Region = New System.Windows.Forms.DataGridViewLinkColumn
        Me.col6RegionName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col6Province = New System.Windows.Forms.DataGridViewLinkColumn
        Me.col6ProvinceName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col6Municipality = New System.Windows.Forms.DataGridViewLinkColumn
        Me.col6MunicipalityName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col6ZipCode = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TabPage6 = New System.Windows.Forms.TabPage
        Me.LinkLabel14 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel15 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel16 = New System.Windows.Forms.LinkLabel
        Me.Label11 = New System.Windows.Forms.Label
        Me.dgUnmappedCustomers = New System.Windows.Forms.DataGridView
        Me.col5Select = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.col5CustomerCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col5CustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col5CustomerAddress1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col5CustomerAddress2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col5Region = New System.Windows.Forms.DataGridViewLinkColumn
        Me.col5Province = New System.Windows.Forms.DataGridViewLinkColumn
        Me.col5Municipality = New System.Windows.Forms.DataGridViewLinkColumn
        Me.col5ZipCode = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel10 = New System.Windows.Forms.LinkLabel
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgUnmappedShipToCustomers = New System.Windows.Forms.DataGridView
        Me.col10Select = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.col10CustCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col10CustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col10ShipToCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col10ShipToName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col10ShipToAddress1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col10ShipToAddress2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col10Region = New System.Windows.Forms.DataGridViewLinkColumn
        Me.col10RegionName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col10Province = New System.Windows.Forms.DataGridViewLinkColumn
        Me.col10ProvinceName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col10Municipality = New System.Windows.Forms.DataGridViewLinkColumn
        Me.col10MunicipalityName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col10ZipCode = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dtEnd = New System.Windows.Forms.DateTimePicker
        Me.dtStart = New System.Windows.Forms.DateTimePicker
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.LinkLabel9 = New System.Windows.Forms.LinkLabel
        Me.Label8 = New System.Windows.Forms.Label
        Me.dgCustomerWithoutTerritory = New System.Windows.Forms.DataGridView
        Me.col2Select = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.col2CustomerCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2CustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2CustomerGroup = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2CustomerAddress = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2ShipTo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2ShipToName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Region = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Province = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Area = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2ZipCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2SalesDivision = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTerritory = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.LinkLabel8 = New System.Windows.Forms.LinkLabel
        Me.txtTerritory = New System.Windows.Forms.TextBox
        Me.lnkTerritory = New System.Windows.Forms.LinkLabel
        Me.Label2 = New System.Windows.Forms.Label
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.lblChannel = New System.Windows.Forms.ToolStripLabel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.MainTab.SuspendLayout()
        Me.tbEntry.SuspendLayout()
        CType(Me.dgBatch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbtasks.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.tbListing.SuspendLayout()
        Me.tbPages.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgCustomerNotintheSystem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage8.SuspendLayout()
        CType(Me.dgShipToNotInSystem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage9.SuspendLayout()
        CType(Me.dgCompanyItemsNotInSystem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgCustomerWithStateAreaTerritory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage7.SuspendLayout()
        CType(Me.dgShipToCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        CType(Me.dgUnmappedCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgUnmappedShipToCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgCustomerWithoutTerritory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTab
        '
        Me.MainTab.Controls.Add(Me.tbEntry)
        Me.MainTab.Controls.Add(Me.tbtasks)
        Me.MainTab.Controls.Add(Me.tbListing)
        Me.MainTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTab.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainTab.Location = New System.Drawing.Point(0, 83)
        Me.MainTab.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainTab.Name = "MainTab"
        Me.MainTab.SelectedIndex = 0
        Me.MainTab.Size = New System.Drawing.Size(1024, 685)
        Me.MainTab.TabIndex = 16
        '
        'tbEntry
        '
        Me.tbEntry.BackColor = System.Drawing.Color.White
        Me.tbEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbEntry.Controls.Add(Me.txtBatchNo)
        Me.tbEntry.Controls.Add(Me.lnkBatch)
        Me.tbEntry.Controls.Add(Me.dgBatch)
        Me.tbEntry.Controls.Add(Me.lblBatchNo)
        Me.tbEntry.Controls.Add(Me.Label25)
        Me.tbEntry.Controls.Add(Me.PictureBox1)
        Me.tbEntry.Controls.Add(Me.txtMonthDescription)
        Me.tbEntry.Controls.Add(Me.Label12)
        Me.tbEntry.Controls.Add(Me.cboMonth)
        Me.tbEntry.Controls.Add(Me.Label17)
        Me.tbEntry.Controls.Add(Me.cboCalendarYear)
        Me.tbEntry.Controls.Add(Me.txtCompany)
        Me.tbEntry.Controls.Add(Me.Label4)
        Me.tbEntry.Controls.Add(Me.cboCompany)
        Me.tbEntry.Controls.Add(Me.Label6)
        Me.tbEntry.Location = New System.Drawing.Point(4, 22)
        Me.tbEntry.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbEntry.Name = "tbEntry"
        Me.tbEntry.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbEntry.Size = New System.Drawing.Size(1016, 659)
        Me.tbEntry.TabIndex = 0
        Me.tbEntry.Text = "Options"
        Me.tbEntry.UseVisualStyleBackColor = True
        '
        'txtBatchNo
        '
        Me.txtBatchNo.BackColor = System.Drawing.Color.White
        Me.txtBatchNo.Location = New System.Drawing.Point(77, 66)
        Me.txtBatchNo.Name = "txtBatchNo"
        Me.txtBatchNo.ReadOnly = True
        Me.txtBatchNo.Size = New System.Drawing.Size(104, 22)
        Me.txtBatchNo.TabIndex = 39
        '
        'lnkBatch
        '
        Me.lnkBatch.AutoSize = True
        Me.lnkBatch.Location = New System.Drawing.Point(15, 71)
        Me.lnkBatch.Name = "lnkBatch"
        Me.lnkBatch.Size = New System.Drawing.Size(60, 13)
        Me.lnkBatch.TabIndex = 38
        Me.lnkBatch.TabStop = True
        Me.lnkBatch.Text = "Batch No :"
        '
        'dgBatch
        '
        Me.dgBatch.AllowUserToAddRows = False
        Me.dgBatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBatch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCompanyCode, Me.colFileName, Me.colCutMo, Me.colYear})
        Me.dgBatch.Location = New System.Drawing.Point(18, 131)
        Me.dgBatch.Name = "dgBatch"
        Me.dgBatch.RowHeadersVisible = False
        Me.dgBatch.Size = New System.Drawing.Size(440, 199)
        Me.dgBatch.TabIndex = 37
        Me.dgBatch.Visible = False
        '
        'colCompanyCode
        '
        Me.colCompanyCode.HeaderText = "Channel"
        Me.colCompanyCode.Name = "colCompanyCode"
        Me.colCompanyCode.ReadOnly = True
        '
        'colFileName
        '
        Me.colFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colFileName.HeaderText = "Batch No"
        Me.colFileName.Name = "colFileName"
        Me.colFileName.ReadOnly = True
        '
        'colCutMo
        '
        Me.colCutMo.HeaderText = "Month"
        Me.colCutMo.Name = "colCutMo"
        Me.colCutMo.ReadOnly = True
        Me.colCutMo.Width = 50
        '
        'colYear
        '
        Me.colYear.HeaderText = "Year"
        Me.colYear.Name = "colYear"
        Me.colYear.ReadOnly = True
        Me.colYear.Width = 50
        '
        'lblBatchNo
        '
        Me.lblBatchNo.AutoSize = True
        Me.lblBatchNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBatchNo.Location = New System.Drawing.Point(82, 112)
        Me.lblBatchNo.Name = "lblBatchNo"
        Me.lblBatchNo.Size = New System.Drawing.Size(0, 13)
        Me.lblBatchNo.TabIndex = 36
        Me.lblBatchNo.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(19, 115)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(57, 13)
        Me.Label25.TabIndex = 35
        Me.Label25.Text = "Batch No :"
        Me.Label25.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources.ETRPMS
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(559, 236)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(451, 393)
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        '
        'txtMonthDescription
        '
        Me.txtMonthDescription.BackColor = System.Drawing.Color.White
        Me.txtMonthDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonthDescription.Location = New System.Drawing.Point(327, 92)
        Me.txtMonthDescription.Name = "txtMonthDescription"
        Me.txtMonthDescription.ReadOnly = True
        Me.txtMonthDescription.Size = New System.Drawing.Size(196, 21)
        Me.txtMonthDescription.TabIndex = 33
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(190, 95)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 13)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Month :"
        '
        'cboMonth
        '
        Me.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(234, 92)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(89, 21)
        Me.cboMonth.TabIndex = 31
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(39, 95)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(36, 13)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "Year :"
        '
        'cboCalendarYear
        '
        Me.cboCalendarYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCalendarYear.FormattingEnabled = True
        Me.cboCalendarYear.Location = New System.Drawing.Point(76, 92)
        Me.cboCalendarYear.Name = "cboCalendarYear"
        Me.cboCalendarYear.Size = New System.Drawing.Size(105, 21)
        Me.cboCalendarYear.TabIndex = 29
        '
        'txtCompany
        '
        Me.txtCompany.Location = New System.Drawing.Point(186, 39)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Size = New System.Drawing.Size(338, 22)
        Me.txtCompany.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Data Source"
        '
        'cboCompany
        '
        Me.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompany.FormattingEnabled = True
        Me.cboCompany.Location = New System.Drawing.Point(78, 40)
        Me.cboCompany.Name = "cboCompany"
        Me.cboCompany.Size = New System.Drawing.Size(104, 21)
        Me.cboCompany.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Distributor :"
        '
        'tbtasks
        '
        Me.tbtasks.BackColor = System.Drawing.Color.White
        Me.tbtasks.Controls.Add(Me.Panel3)
        Me.tbtasks.Controls.Add(Me.Label15)
        Me.tbtasks.Controls.Add(Me.Label16)
        Me.tbtasks.Controls.Add(Me.chkStartCrediting)
        Me.tbtasks.Controls.Add(Me.chkRunPreUpload)
        Me.tbtasks.Location = New System.Drawing.Point(4, 22)
        Me.tbtasks.Name = "tbtasks"
        Me.tbtasks.Padding = New System.Windows.Forms.Padding(3)
        Me.tbtasks.Size = New System.Drawing.Size(1016, 659)
        Me.tbtasks.TabIndex = 2
        Me.tbtasks.Text = "Tasks"
        Me.tbtasks.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.Panel3.Controls.Add(Me.chkUnmappedShipto)
        Me.Panel3.Controls.Add(Me.chkOverrideShipToCustomers)
        Me.Panel3.Controls.Add(Me.LinkLabel17)
        Me.Panel3.Controls.Add(Me.ProgressBar4)
        Me.Panel3.Controls.Add(Me.chkShipto)
        Me.Panel3.Controls.Add(Me.lnkAddressProblem)
        Me.Panel3.Controls.Add(Me.chkCustWithoutAssignedTerritory)
        Me.Panel3.Controls.Add(Me.chkOverrideUnmappedCustomer)
        Me.Panel3.Controls.Add(Me.pbar2)
        Me.Panel3.Controls.Add(Me.pbar4)
        Me.Panel3.Controls.Add(Me.chkItemsNotInSystem)
        Me.Panel3.Controls.Add(Me.chkOverrideCustomerWithStateAreaTerritoryProblem)
        Me.Panel3.Controls.Add(Me.lnkUnmappedShipToCustomers)
        Me.Panel3.Controls.Add(Me.ProgressBar3)
        Me.Panel3.Controls.Add(Me.lnkShipToNotInSystem)
        Me.Panel3.Controls.Add(Me.chkShipToNotInSystem)
        Me.Panel3.Controls.Add(Me.ProgressBar2)
        Me.Panel3.Controls.Add(Me.lnkItemsNotInPricelist)
        Me.Panel3.Controls.Add(Me.chkItemsNotinPricelist)
        Me.Panel3.Controls.Add(Me.ProgressBar1)
        Me.Panel3.Controls.Add(Me.lnkSharing)
        Me.Panel3.Controls.Add(Me.chkUnmapped)
        Me.Panel3.Controls.Add(Me.lnkWithoutAgent)
        Me.Panel3.Controls.Add(Me.lnkCustomersNotInSystem)
        Me.Panel3.Controls.Add(Me.pbar3)
        Me.Panel3.Controls.Add(Me.chkCustWithStateAreaTerritoryProblem)
        Me.Panel3.Controls.Add(Me.pbar1)
        Me.Panel3.Controls.Add(Me.chkCustNotInSystem)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Location = New System.Drawing.Point(12, 100)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(703, 305)
        Me.Panel3.TabIndex = 23
        '
        'chkUnmappedShipto
        '
        Me.chkUnmappedShipto.AutoSize = True
        Me.chkUnmappedShipto.Location = New System.Drawing.Point(47, 254)
        Me.chkUnmappedShipto.Name = "chkUnmappedShipto"
        Me.chkUnmappedShipto.Size = New System.Drawing.Size(116, 17)
        Me.chkUnmappedShipto.TabIndex = 42
        Me.chkUnmappedShipto.Text = "Override this task"
        Me.chkUnmappedShipto.UseVisualStyleBackColor = True
        '
        'chkOverrideShipToCustomers
        '
        Me.chkOverrideShipToCustomers.AutoSize = True
        Me.chkOverrideShipToCustomers.Location = New System.Drawing.Point(48, 182)
        Me.chkOverrideShipToCustomers.Name = "chkOverrideShipToCustomers"
        Me.chkOverrideShipToCustomers.Size = New System.Drawing.Size(116, 17)
        Me.chkOverrideShipToCustomers.TabIndex = 41
        Me.chkOverrideShipToCustomers.Text = "Override this task"
        Me.chkOverrideShipToCustomers.UseVisualStyleBackColor = True
        '
        'LinkLabel17
        '
        Me.LinkLabel17.AutoSize = True
        Me.LinkLabel17.Location = New System.Drawing.Point(22, 165)
        Me.LinkLabel17.Name = "LinkLabel17"
        Me.LinkLabel17.Size = New System.Drawing.Size(398, 13)
        Me.LinkLabel17.TabIndex = 40
        Me.LinkLabel17.TabStop = True
        Me.LinkLabel17.Text = "Customer Ship To(s) without Region or Province or Municipality or Zip Code "
        '
        'ProgressBar4
        '
        Me.ProgressBar4.Location = New System.Drawing.Point(437, 165)
        Me.ProgressBar4.MarqueeAnimationSpeed = 150
        Me.ProgressBar4.Name = "ProgressBar4"
        Me.ProgressBar4.Size = New System.Drawing.Size(156, 17)
        Me.ProgressBar4.Step = 25
        Me.ProgressBar4.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar4.TabIndex = 39
        Me.ProgressBar4.Value = 50
        '
        'chkShipto
        '
        Me.chkShipto.AutoSize = True
        Me.chkShipto.Checked = True
        Me.chkShipto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShipto.Location = New System.Drawing.Point(8, 166)
        Me.chkShipto.Name = "chkShipto"
        Me.chkShipto.Size = New System.Drawing.Size(15, 14)
        Me.chkShipto.TabIndex = 38
        Me.chkShipto.UseVisualStyleBackColor = True
        '
        'lnkAddressProblem
        '
        Me.lnkAddressProblem.AutoSize = True
        Me.lnkAddressProblem.Location = New System.Drawing.Point(24, 272)
        Me.lnkAddressProblem.Name = "lnkAddressProblem"
        Me.lnkAddressProblem.Size = New System.Drawing.Size(200, 13)
        Me.lnkAddressProblem.TabIndex = 23
        Me.lnkAddressProblem.TabStop = True
        Me.lnkAddressProblem.Text = "Customers without Assigned Territory"
        '
        'chkCustWithoutAssignedTerritory
        '
        Me.chkCustWithoutAssignedTerritory.AutoSize = True
        Me.chkCustWithoutAssignedTerritory.Checked = True
        Me.chkCustWithoutAssignedTerritory.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCustWithoutAssignedTerritory.Location = New System.Drawing.Point(9, 271)
        Me.chkCustWithoutAssignedTerritory.Name = "chkCustWithoutAssignedTerritory"
        Me.chkCustWithoutAssignedTerritory.Size = New System.Drawing.Size(15, 14)
        Me.chkCustWithoutAssignedTerritory.TabIndex = 15
        Me.chkCustWithoutAssignedTerritory.UseVisualStyleBackColor = True
        '
        'chkOverrideUnmappedCustomer
        '
        Me.chkOverrideUnmappedCustomer.AutoSize = True
        Me.chkOverrideUnmappedCustomer.Location = New System.Drawing.Point(48, 217)
        Me.chkOverrideUnmappedCustomer.Name = "chkOverrideUnmappedCustomer"
        Me.chkOverrideUnmappedCustomer.Size = New System.Drawing.Size(116, 17)
        Me.chkOverrideUnmappedCustomer.TabIndex = 37
        Me.chkOverrideUnmappedCustomer.Text = "Override this task"
        Me.chkOverrideUnmappedCustomer.UseVisualStyleBackColor = True
        '
        'pbar2
        '
        Me.pbar2.Location = New System.Drawing.Point(437, 270)
        Me.pbar2.MarqueeAnimationSpeed = 150
        Me.pbar2.Name = "pbar2"
        Me.pbar2.Size = New System.Drawing.Size(156, 17)
        Me.pbar2.Step = 25
        Me.pbar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbar2.TabIndex = 19
        Me.pbar2.Value = 50
        '
        'pbar4
        '
        Me.pbar4.Location = New System.Drawing.Point(436, 237)
        Me.pbar4.MarqueeAnimationSpeed = 150
        Me.pbar4.Name = "pbar4"
        Me.pbar4.Size = New System.Drawing.Size(156, 17)
        Me.pbar4.Step = 25
        Me.pbar4.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbar4.TabIndex = 21
        Me.pbar4.Value = 50
        '
        'chkItemsNotInSystem
        '
        Me.chkItemsNotInSystem.AutoSize = True
        Me.chkItemsNotInSystem.Checked = True
        Me.chkItemsNotInSystem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkItemsNotInSystem.Location = New System.Drawing.Point(8, 238)
        Me.chkItemsNotInSystem.Name = "chkItemsNotInSystem"
        Me.chkItemsNotInSystem.Size = New System.Drawing.Size(15, 14)
        Me.chkItemsNotInSystem.TabIndex = 16
        Me.chkItemsNotInSystem.UseVisualStyleBackColor = True
        '
        'chkOverrideCustomerWithStateAreaTerritoryProblem
        '
        Me.chkOverrideCustomerWithStateAreaTerritoryProblem.AutoSize = True
        Me.chkOverrideCustomerWithStateAreaTerritoryProblem.Location = New System.Drawing.Point(47, 144)
        Me.chkOverrideCustomerWithStateAreaTerritoryProblem.Name = "chkOverrideCustomerWithStateAreaTerritoryProblem"
        Me.chkOverrideCustomerWithStateAreaTerritoryProblem.Size = New System.Drawing.Size(116, 17)
        Me.chkOverrideCustomerWithStateAreaTerritoryProblem.TabIndex = 36
        Me.chkOverrideCustomerWithStateAreaTerritoryProblem.Text = "Override this task"
        Me.chkOverrideCustomerWithStateAreaTerritoryProblem.UseVisualStyleBackColor = True
        '
        'lnkUnmappedShipToCustomers
        '
        Me.lnkUnmappedShipToCustomers.AutoSize = True
        Me.lnkUnmappedShipToCustomers.Location = New System.Drawing.Point(23, 238)
        Me.lnkUnmappedShipToCustomers.Name = "lnkUnmappedShipToCustomers"
        Me.lnkUnmappedShipToCustomers.Size = New System.Drawing.Size(414, 13)
        Me.lnkUnmappedShipToCustomers.TabIndex = 25
        Me.lnkUnmappedShipToCustomers.TabStop = True
        Me.lnkUnmappedShipToCustomers.Text = "Customer Ship To(s) with default Region or Province or Municipality or ZipCode"
        '
        'ProgressBar3
        '
        Me.ProgressBar3.Location = New System.Drawing.Point(437, 78)
        Me.ProgressBar3.MarqueeAnimationSpeed = 150
        Me.ProgressBar3.Name = "ProgressBar3"
        Me.ProgressBar3.Size = New System.Drawing.Size(156, 17)
        Me.ProgressBar3.Step = 25
        Me.ProgressBar3.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar3.TabIndex = 35
        Me.ProgressBar3.Value = 50
        '
        'lnkShipToNotInSystem
        '
        Me.lnkShipToNotInSystem.AutoSize = True
        Me.lnkShipToNotInSystem.Location = New System.Drawing.Point(24, 77)
        Me.lnkShipToNotInSystem.Name = "lnkShipToNotInSystem"
        Me.lnkShipToNotInSystem.Size = New System.Drawing.Size(169, 13)
        Me.lnkShipToNotInSystem.TabIndex = 34
        Me.lnkShipToNotInSystem.TabStop = True
        Me.lnkShipToNotInSystem.Text = "Ship To Customer not in System"
        '
        'chkShipToNotInSystem
        '
        Me.chkShipToNotInSystem.AutoSize = True
        Me.chkShipToNotInSystem.Checked = True
        Me.chkShipToNotInSystem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShipToNotInSystem.Location = New System.Drawing.Point(9, 77)
        Me.chkShipToNotInSystem.Name = "chkShipToNotInSystem"
        Me.chkShipToNotInSystem.Size = New System.Drawing.Size(15, 14)
        Me.chkShipToNotInSystem.TabIndex = 33
        Me.chkShipToNotInSystem.UseVisualStyleBackColor = True
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(437, 101)
        Me.ProgressBar2.MarqueeAnimationSpeed = 150
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(156, 17)
        Me.ProgressBar2.Step = 25
        Me.ProgressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar2.TabIndex = 31
        Me.ProgressBar2.Value = 50
        '
        'lnkItemsNotInPricelist
        '
        Me.lnkItemsNotInPricelist.AutoSize = True
        Me.lnkItemsNotInPricelist.Location = New System.Drawing.Point(22, 102)
        Me.lnkItemsNotInPricelist.Name = "lnkItemsNotInPricelist"
        Me.lnkItemsNotInPricelist.Size = New System.Drawing.Size(106, 13)
        Me.lnkItemsNotInPricelist.TabIndex = 30
        Me.lnkItemsNotInPricelist.TabStop = True
        Me.lnkItemsNotInPricelist.Text = "Items not in System"
        '
        'chkItemsNotinPricelist
        '
        Me.chkItemsNotinPricelist.AutoSize = True
        Me.chkItemsNotinPricelist.Checked = True
        Me.chkItemsNotinPricelist.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkItemsNotinPricelist.Location = New System.Drawing.Point(7, 102)
        Me.chkItemsNotinPricelist.Name = "chkItemsNotinPricelist"
        Me.chkItemsNotinPricelist.Size = New System.Drawing.Size(15, 14)
        Me.chkItemsNotinPricelist.TabIndex = 29
        Me.chkItemsNotinPricelist.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(436, 201)
        Me.ProgressBar1.MarqueeAnimationSpeed = 150
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(156, 17)
        Me.ProgressBar1.Step = 25
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 28
        Me.ProgressBar1.Value = 50
        '
        'lnkSharing
        '
        Me.lnkSharing.AutoSize = True
        Me.lnkSharing.Location = New System.Drawing.Point(23, 200)
        Me.lnkSharing.Name = "lnkSharing"
        Me.lnkSharing.Size = New System.Drawing.Size(373, 13)
        Me.lnkSharing.TabIndex = 27
        Me.lnkSharing.TabStop = True
        Me.lnkSharing.Text = "Customer(s) with default Region or Province or Municipality or ZipCode"
        '
        'chkUnmapped
        '
        Me.chkUnmapped.AutoSize = True
        Me.chkUnmapped.Checked = True
        Me.chkUnmapped.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUnmapped.Location = New System.Drawing.Point(8, 200)
        Me.chkUnmapped.Name = "chkUnmapped"
        Me.chkUnmapped.Size = New System.Drawing.Size(15, 14)
        Me.chkUnmapped.TabIndex = 26
        Me.chkUnmapped.UseVisualStyleBackColor = True
        '
        'lnkWithoutAgent
        '
        Me.lnkWithoutAgent.AutoSize = True
        Me.lnkWithoutAgent.Location = New System.Drawing.Point(23, 127)
        Me.lnkWithoutAgent.Name = "lnkWithoutAgent"
        Me.lnkWithoutAgent.Size = New System.Drawing.Size(357, 13)
        Me.lnkWithoutAgent.TabIndex = 24
        Me.lnkWithoutAgent.TabStop = True
        Me.lnkWithoutAgent.Text = "Customer(s) without Region or Province or Municipality or Zip Code "
        '
        'lnkCustomersNotInSystem
        '
        Me.lnkCustomersNotInSystem.AutoSize = True
        Me.lnkCustomersNotInSystem.Location = New System.Drawing.Point(25, 54)
        Me.lnkCustomersNotInSystem.Name = "lnkCustomersNotInSystem"
        Me.lnkCustomersNotInSystem.Size = New System.Drawing.Size(236, 13)
        Me.lnkCustomersNotInSystem.TabIndex = 22
        Me.lnkCustomersNotInSystem.TabStop = True
        Me.lnkCustomersNotInSystem.Text = "Customers in the raw data not in the system."
        '
        'pbar3
        '
        Me.pbar3.Location = New System.Drawing.Point(436, 127)
        Me.pbar3.MarqueeAnimationSpeed = 150
        Me.pbar3.Name = "pbar3"
        Me.pbar3.Size = New System.Drawing.Size(156, 17)
        Me.pbar3.Step = 25
        Me.pbar3.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbar3.TabIndex = 20
        Me.pbar3.Value = 50
        '
        'chkCustWithStateAreaTerritoryProblem
        '
        Me.chkCustWithStateAreaTerritoryProblem.AutoSize = True
        Me.chkCustWithStateAreaTerritoryProblem.Checked = True
        Me.chkCustWithStateAreaTerritoryProblem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCustWithStateAreaTerritoryProblem.Location = New System.Drawing.Point(8, 128)
        Me.chkCustWithStateAreaTerritoryProblem.Name = "chkCustWithStateAreaTerritoryProblem"
        Me.chkCustWithStateAreaTerritoryProblem.Size = New System.Drawing.Size(15, 14)
        Me.chkCustWithStateAreaTerritoryProblem.TabIndex = 18
        Me.chkCustWithStateAreaTerritoryProblem.UseVisualStyleBackColor = True
        '
        'pbar1
        '
        Me.pbar1.Location = New System.Drawing.Point(437, 54)
        Me.pbar1.MarqueeAnimationSpeed = 150
        Me.pbar1.Name = "pbar1"
        Me.pbar1.Size = New System.Drawing.Size(156, 17)
        Me.pbar1.Step = 25
        Me.pbar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbar1.TabIndex = 17
        Me.pbar1.Value = 50
        '
        'chkCustNotInSystem
        '
        Me.chkCustNotInSystem.AutoSize = True
        Me.chkCustNotInSystem.Checked = True
        Me.chkCustNotInSystem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCustNotInSystem.Location = New System.Drawing.Point(9, 54)
        Me.chkCustNotInSystem.Name = "chkCustNotInSystem"
        Me.chkCustNotInSystem.Size = New System.Drawing.Size(15, 14)
        Me.chkCustNotInSystem.TabIndex = 14
        Me.chkCustNotInSystem.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 34)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Analysis Options"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 7)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(552, 13)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "This may take a few minutes depending on the number of options and number of reco" & _
            "rds in the raw data."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 35)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(313, 13)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Select the tasks you want to do before starting the process."
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(9, 13)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 13)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "Tasks"
        '
        'chkStartCrediting
        '
        Me.chkStartCrediting.AutoSize = True
        Me.chkStartCrediting.Checked = True
        Me.chkStartCrediting.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkStartCrediting.Location = New System.Drawing.Point(12, 411)
        Me.chkStartCrediting.Name = "chkStartCrediting"
        Me.chkStartCrediting.Size = New System.Drawing.Size(367, 17)
        Me.chkStartCrediting.TabIndex = 20
        Me.chkStartCrediting.Text = "Start Crediting Process. (Will only continue if analysis is successful)"
        Me.chkStartCrediting.UseVisualStyleBackColor = True
        '
        'chkRunPreUpload
        '
        Me.chkRunPreUpload.AutoSize = True
        Me.chkRunPreUpload.Checked = True
        Me.chkRunPreUpload.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRunPreUpload.Location = New System.Drawing.Point(12, 77)
        Me.chkRunPreUpload.Name = "chkRunPreUpload"
        Me.chkRunPreUpload.Size = New System.Drawing.Size(184, 17)
        Me.chkRunPreUpload.TabIndex = 19
        Me.chkRunPreUpload.Text = "Run Pre-Upload Data Analyzer "
        Me.chkRunPreUpload.UseVisualStyleBackColor = True
        '
        'tbListing
        '
        Me.tbListing.BackColor = System.Drawing.Color.White
        Me.tbListing.Controls.Add(Me.tbPages)
        Me.tbListing.Location = New System.Drawing.Point(4, 22)
        Me.tbListing.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbListing.Name = "tbListing"
        Me.tbListing.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbListing.Size = New System.Drawing.Size(1016, 659)
        Me.tbListing.TabIndex = 1
        Me.tbListing.Text = "Analysis Results"
        Me.tbListing.UseVisualStyleBackColor = True
        '
        'tbPages
        '
        Me.tbPages.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPages.Controls.Add(Me.TabPage1)
        Me.tbPages.Controls.Add(Me.TabPage8)
        Me.tbPages.Controls.Add(Me.TabPage9)
        Me.tbPages.Controls.Add(Me.TabPage5)
        Me.tbPages.Controls.Add(Me.TabPage7)
        Me.tbPages.Controls.Add(Me.TabPage6)
        Me.tbPages.Controls.Add(Me.TabPage3)
        Me.tbPages.Controls.Add(Me.TabPage2)
        Me.tbPages.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPages.Location = New System.Drawing.Point(3, 0)
        Me.tbPages.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbPages.Name = "tbPages"
        Me.tbPages.SelectedIndex = 0
        Me.tbPages.Size = New System.Drawing.Size(1004, 535)
        Me.tbPages.TabIndex = 17
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.LinkLabel7)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.LinkLabel2)
        Me.TabPage1.Controls.Add(Me.LinkLabel1)
        Me.TabPage1.Controls.Add(Me.dgCustomerNotintheSystem)
        Me.TabPage1.Controls.Add(Me.LinkLabel29)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Size = New System.Drawing.Size(996, 509)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Page 1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(181, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Customer(s) not in the System"
        '
        'LinkLabel7
        '
        Me.LinkLabel7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel7.AutoSize = True
        Me.LinkLabel7.Location = New System.Drawing.Point(833, 488)
        Me.LinkLabel7.Name = "LinkLabel7"
        Me.LinkLabel7.Size = New System.Drawing.Size(74, 13)
        Me.LinkLabel7.TabIndex = 4
        Me.LinkLabel7.TabStop = True
        Me.LinkLabel7.Text = "Add Selected"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 3
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(58, 488)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(67, 13)
        Me.LinkLabel2.TabIndex = 2
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Uncheck All"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(6, 488)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(54, 13)
        Me.LinkLabel1.TabIndex = 1
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Check All"
        '
        'dgCustomerNotintheSystem
        '
        Me.dgCustomerNotintheSystem.AllowUserToAddRows = False
        Me.dgCustomerNotintheSystem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCustomerNotintheSystem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCustomerNotintheSystem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelect, Me.colCustomerCode, Me.colCustomerName, Me.colCustomerClass, Me.colCustomerAddress, Me.colCustomerAddress2, Me.colShipTo, Me.colShipToName, Me.colRegion, Me.colProvince, Me.colArea, Me.colZipCode, Me.col1Shared})
        Me.dgCustomerNotintheSystem.Location = New System.Drawing.Point(3, 26)
        Me.dgCustomerNotintheSystem.Name = "dgCustomerNotintheSystem"
        Me.dgCustomerNotintheSystem.RowHeadersVisible = False
        Me.dgCustomerNotintheSystem.Size = New System.Drawing.Size(903, 459)
        Me.dgCustomerNotintheSystem.TabIndex = 0
        '
        'colSelect
        '
        Me.colSelect.HeaderText = ""
        Me.colSelect.Name = "colSelect"
        Me.colSelect.Width = 30
        '
        'colCustomerCode
        '
        Me.colCustomerCode.HeaderText = "Customer Code"
        Me.colCustomerCode.Name = "colCustomerCode"
        Me.colCustomerCode.ReadOnly = True
        Me.colCustomerCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCustomerCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colCustomerName
        '
        Me.colCustomerName.HeaderText = "CustomerName"
        Me.colCustomerName.Name = "colCustomerName"
        Me.colCustomerName.ReadOnly = True
        Me.colCustomerName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCustomerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colCustomerClass
        '
        Me.colCustomerClass.HeaderText = "Cust. Group"
        Me.colCustomerClass.Name = "colCustomerClass"
        Me.colCustomerClass.ReadOnly = True
        '
        'colCustomerAddress
        '
        Me.colCustomerAddress.HeaderText = "Cust. Address 1"
        Me.colCustomerAddress.Name = "colCustomerAddress"
        Me.colCustomerAddress.ReadOnly = True
        Me.colCustomerAddress.Width = 150
        '
        'colCustomerAddress2
        '
        Me.colCustomerAddress2.HeaderText = "Cust. Address 2"
        Me.colCustomerAddress2.Name = "colCustomerAddress2"
        Me.colCustomerAddress2.ReadOnly = True
        Me.colCustomerAddress2.Width = 150
        '
        'colShipTo
        '
        Me.colShipTo.HeaderText = "Ship To"
        Me.colShipTo.Name = "colShipTo"
        '
        'colShipToName
        '
        Me.colShipToName.HeaderText = "Ship To Name"
        Me.colShipToName.Name = "colShipToName"
        '
        'colRegion
        '
        Me.colRegion.HeaderText = "Region"
        Me.colRegion.Name = "colRegion"
        Me.colRegion.ReadOnly = True
        Me.colRegion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colRegion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colProvince
        '
        Me.colProvince.HeaderText = "City / Province"
        Me.colProvince.Name = "colProvince"
        Me.colProvince.ReadOnly = True
        Me.colProvince.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colProvince.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colProvince.Width = 200
        '
        'colArea
        '
        Me.colArea.HeaderText = "Municipality / Location"
        Me.colArea.Name = "colArea"
        Me.colArea.ReadOnly = True
        Me.colArea.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colArea.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colArea.Width = 200
        '
        'colZipCode
        '
        Me.colZipCode.HeaderText = "ZipCode"
        Me.colZipCode.Name = "colZipCode"
        Me.colZipCode.ReadOnly = True
        Me.colZipCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colZipCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col1Shared
        '
        Me.col1Shared.HeaderText = "Shared Account"
        Me.col1Shared.Name = "col1Shared"
        '
        'LinkLabel29
        '
        Me.LinkLabel29.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel29.AutoSize = True
        Me.LinkLabel29.Location = New System.Drawing.Point(662, 9)
        Me.LinkLabel29.Name = "LinkLabel29"
        Me.LinkLabel29.Size = New System.Drawing.Size(245, 13)
        Me.LinkLabel29.TabIndex = 20
        Me.LinkLabel29.TabStop = True
        Me.LinkLabel29.Text = "Create Default Ship To For Selected Customers"
        '
        'TabPage8
        '
        Me.TabPage8.BackColor = System.Drawing.Color.White
        Me.TabPage8.Controls.Add(Me.LinkLabel23)
        Me.TabPage8.Controls.Add(Me.LinkLabel24)
        Me.TabPage8.Controls.Add(Me.LinkLabel25)
        Me.TabPage8.Controls.Add(Me.Label19)
        Me.TabPage8.Controls.Add(Me.dgShipToNotInSystem)
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(996, 509)
        Me.TabPage8.TabIndex = 6
        Me.TabPage8.Text = "Page 2"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'LinkLabel23
        '
        Me.LinkLabel23.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel23.AutoSize = True
        Me.LinkLabel23.Location = New System.Drawing.Point(835, 488)
        Me.LinkLabel23.Name = "LinkLabel23"
        Me.LinkLabel23.Size = New System.Drawing.Size(74, 13)
        Me.LinkLabel23.TabIndex = 19
        Me.LinkLabel23.TabStop = True
        Me.LinkLabel23.Text = "Add Selected"
        '
        'LinkLabel24
        '
        Me.LinkLabel24.AutoSize = True
        Me.LinkLabel24.Location = New System.Drawing.Point(60, 488)
        Me.LinkLabel24.Name = "LinkLabel24"
        Me.LinkLabel24.Size = New System.Drawing.Size(67, 13)
        Me.LinkLabel24.TabIndex = 18
        Me.LinkLabel24.TabStop = True
        Me.LinkLabel24.Text = "Uncheck All"
        '
        'LinkLabel25
        '
        Me.LinkLabel25.AutoSize = True
        Me.LinkLabel25.Location = New System.Drawing.Point(8, 488)
        Me.LinkLabel25.Name = "LinkLabel25"
        Me.LinkLabel25.Size = New System.Drawing.Size(54, 13)
        Me.LinkLabel25.TabIndex = 17
        Me.LinkLabel25.TabStop = True
        Me.LinkLabel25.Text = "Check All"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(6, 8)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(209, 13)
        Me.Label19.TabIndex = 16
        Me.Label19.Text = "Customer Ship To not in the System"
        '
        'dgShipToNotInSystem
        '
        Me.dgShipToNotInSystem.AllowUserToAddRows = False
        Me.dgShipToNotInSystem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgShipToNotInSystem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgShipToNotInSystem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col8Select, Me.col8CustomerCode, Me.col8CustomerName, Me.col8ShipToCode, Me.col8ShipToName, Me.col8ShipToCustomerAddress1, Me.col8ShipToAddress2, Me.col8CustomerGrp, Me.col8Region, Me.col8Province, Me.col8Municipality, Me.col8ZipCode})
        Me.dgShipToNotInSystem.Location = New System.Drawing.Point(3, 24)
        Me.dgShipToNotInSystem.Name = "dgShipToNotInSystem"
        Me.dgShipToNotInSystem.RowHeadersVisible = False
        Me.dgShipToNotInSystem.Size = New System.Drawing.Size(903, 461)
        Me.dgShipToNotInSystem.TabIndex = 15
        '
        'col8Select
        '
        Me.col8Select.HeaderText = ""
        Me.col8Select.Name = "col8Select"
        Me.col8Select.Width = 30
        '
        'col8CustomerCode
        '
        Me.col8CustomerCode.HeaderText = "Customer Code"
        Me.col8CustomerCode.Name = "col8CustomerCode"
        Me.col8CustomerCode.ReadOnly = True
        Me.col8CustomerCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col8CustomerCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'col8CustomerName
        '
        Me.col8CustomerName.HeaderText = "CustomerName"
        Me.col8CustomerName.Name = "col8CustomerName"
        Me.col8CustomerName.ReadOnly = True
        Me.col8CustomerName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col8CustomerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'col8ShipToCode
        '
        Me.col8ShipToCode.HeaderText = "Ship To Code"
        Me.col8ShipToCode.Name = "col8ShipToCode"
        Me.col8ShipToCode.ReadOnly = True
        '
        'col8ShipToName
        '
        Me.col8ShipToName.HeaderText = "Ship To Name"
        Me.col8ShipToName.Name = "col8ShipToName"
        Me.col8ShipToName.ReadOnly = True
        '
        'col8ShipToCustomerAddress1
        '
        Me.col8ShipToCustomerAddress1.HeaderText = "Ship To Cust. Address 1"
        Me.col8ShipToCustomerAddress1.Name = "col8ShipToCustomerAddress1"
        Me.col8ShipToCustomerAddress1.ReadOnly = True
        Me.col8ShipToCustomerAddress1.Width = 150
        '
        'col8ShipToAddress2
        '
        Me.col8ShipToAddress2.HeaderText = "Ship To Cust. Address 2"
        Me.col8ShipToAddress2.Name = "col8ShipToAddress2"
        Me.col8ShipToAddress2.ReadOnly = True
        Me.col8ShipToAddress2.Width = 150
        '
        'col8CustomerGrp
        '
        Me.col8CustomerGrp.HeaderText = "Cust. Group"
        Me.col8CustomerGrp.Name = "col8CustomerGrp"
        Me.col8CustomerGrp.ReadOnly = True
        '
        'col8Region
        '
        Me.col8Region.HeaderText = "Region"
        Me.col8Region.Name = "col8Region"
        Me.col8Region.ReadOnly = True
        '
        'col8Province
        '
        Me.col8Province.HeaderText = "City / Province"
        Me.col8Province.Name = "col8Province"
        Me.col8Province.ReadOnly = True
        Me.col8Province.Width = 200
        '
        'col8Municipality
        '
        Me.col8Municipality.HeaderText = "Municipality / Location"
        Me.col8Municipality.Name = "col8Municipality"
        Me.col8Municipality.ReadOnly = True
        Me.col8Municipality.Width = 200
        '
        'col8ZipCode
        '
        Me.col8ZipCode.HeaderText = "ZipCode"
        Me.col8ZipCode.Name = "col8ZipCode"
        Me.col8ZipCode.ReadOnly = True
        '
        'TabPage9
        '
        Me.TabPage9.BackColor = System.Drawing.Color.White
        Me.TabPage9.Controls.Add(Me.LinkLabel26)
        Me.TabPage9.Controls.Add(Me.LinkLabel27)
        Me.TabPage9.Controls.Add(Me.LinkLabel28)
        Me.TabPage9.Controls.Add(Me.Label24)
        Me.TabPage9.Controls.Add(Me.dgCompanyItemsNotInSystem)
        Me.TabPage9.Location = New System.Drawing.Point(4, 22)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Size = New System.Drawing.Size(996, 509)
        Me.TabPage9.TabIndex = 7
        Me.TabPage9.Text = "Page 4"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'LinkLabel26
        '
        Me.LinkLabel26.AutoSize = True
        Me.LinkLabel26.Location = New System.Drawing.Point(834, 490)
        Me.LinkLabel26.Name = "LinkLabel26"
        Me.LinkLabel26.Size = New System.Drawing.Size(74, 13)
        Me.LinkLabel26.TabIndex = 21
        Me.LinkLabel26.TabStop = True
        Me.LinkLabel26.Text = "Add Selected"
        Me.LinkLabel26.Visible = False
        '
        'LinkLabel27
        '
        Me.LinkLabel27.AutoSize = True
        Me.LinkLabel27.Location = New System.Drawing.Point(56, 490)
        Me.LinkLabel27.Name = "LinkLabel27"
        Me.LinkLabel27.Size = New System.Drawing.Size(67, 13)
        Me.LinkLabel27.TabIndex = 20
        Me.LinkLabel27.TabStop = True
        Me.LinkLabel27.Text = "Uncheck All"
        '
        'LinkLabel28
        '
        Me.LinkLabel28.AutoSize = True
        Me.LinkLabel28.Location = New System.Drawing.Point(4, 490)
        Me.LinkLabel28.Name = "LinkLabel28"
        Me.LinkLabel28.Size = New System.Drawing.Size(54, 13)
        Me.LinkLabel28.TabIndex = 19
        Me.LinkLabel28.TabStop = True
        Me.LinkLabel28.Text = "Check All"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(3, 7)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(210, 13)
        Me.Label24.TabIndex = 18
        Me.Label24.Text = "Items not maintained in the system"
        '
        'dgCompanyItemsNotInSystem
        '
        Me.dgCompanyItemsNotInSystem.AllowUserToAddRows = False
        Me.dgCompanyItemsNotInSystem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCompanyItemsNotInSystem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCompanyItemsNotInSystem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col9Select, Me.col9ItemCode, Me.col9ItemBrandName})
        Me.dgCompanyItemsNotInSystem.Location = New System.Drawing.Point(3, 31)
        Me.dgCompanyItemsNotInSystem.Name = "dgCompanyItemsNotInSystem"
        Me.dgCompanyItemsNotInSystem.RowHeadersVisible = False
        Me.dgCompanyItemsNotInSystem.Size = New System.Drawing.Size(906, 456)
        Me.dgCompanyItemsNotInSystem.TabIndex = 17
        '
        'col9Select
        '
        Me.col9Select.HeaderText = ""
        Me.col9Select.Name = "col9Select"
        Me.col9Select.Width = 30
        '
        'col9ItemCode
        '
        Me.col9ItemCode.HeaderText = "Item Code"
        Me.col9ItemCode.Name = "col9ItemCode"
        Me.col9ItemCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col9ItemCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col9ItemCode.Width = 150
        '
        'col9ItemBrandName
        '
        Me.col9ItemBrandName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col9ItemBrandName.HeaderText = "Item Brand Name"
        Me.col9ItemBrandName.Name = "col9ItemBrandName"
        Me.col9ItemBrandName.ReadOnly = True
        Me.col9ItemBrandName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col9ItemBrandName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.White
        Me.TabPage5.Controls.Add(Me.LinkLabel21)
        Me.TabPage5.Controls.Add(Me.LinkLabel11)
        Me.TabPage5.Controls.Add(Me.LinkLabel12)
        Me.TabPage5.Controls.Add(Me.LinkLabel13)
        Me.TabPage5.Controls.Add(Me.Label10)
        Me.TabPage5.Controls.Add(Me.dgCustomerWithStateAreaTerritory)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(996, 509)
        Me.TabPage5.TabIndex = 3
        Me.TabPage5.Text = "Page 5"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'LinkLabel21
        '
        Me.LinkLabel21.AutoSize = True
        Me.LinkLabel21.Location = New System.Drawing.Point(785, 459)
        Me.LinkLabel21.Name = "LinkLabel21"
        Me.LinkLabel21.Size = New System.Drawing.Size(125, 13)
        Me.LinkLabel21.TabIndex = 21
        Me.LinkLabel21.TabStop = True
        Me.LinkLabel21.Text = "Set Selected To Default"
        '
        'LinkLabel11
        '
        Me.LinkLabel11.AutoSize = True
        Me.LinkLabel11.Location = New System.Drawing.Point(694, 459)
        Me.LinkLabel11.Name = "LinkLabel11"
        Me.LinkLabel11.Size = New System.Drawing.Size(91, 13)
        Me.LinkLabel11.TabIndex = 20
        Me.LinkLabel11.TabStop = True
        Me.LinkLabel11.Text = "Update Selected"
        '
        'LinkLabel12
        '
        Me.LinkLabel12.AutoSize = True
        Me.LinkLabel12.Location = New System.Drawing.Point(59, 459)
        Me.LinkLabel12.Name = "LinkLabel12"
        Me.LinkLabel12.Size = New System.Drawing.Size(67, 13)
        Me.LinkLabel12.TabIndex = 19
        Me.LinkLabel12.TabStop = True
        Me.LinkLabel12.Text = "Uncheck All"
        '
        'LinkLabel13
        '
        Me.LinkLabel13.AutoSize = True
        Me.LinkLabel13.Location = New System.Drawing.Point(7, 459)
        Me.LinkLabel13.Name = "LinkLabel13"
        Me.LinkLabel13.Size = New System.Drawing.Size(54, 13)
        Me.LinkLabel13.TabIndex = 18
        Me.LinkLabel13.TabStop = True
        Me.LinkLabel13.Text = "Check All"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(4, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(388, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Customer(s) without Region or Province or Municipality or Zip Code "
        '
        'dgCustomerWithStateAreaTerritory
        '
        Me.dgCustomerWithStateAreaTerritory.AllowUserToAddRows = False
        Me.dgCustomerWithStateAreaTerritory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCustomerWithStateAreaTerritory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCustomerWithStateAreaTerritory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col4Select, Me.col4CustomerCode, Me.col4CustomerName, Me.col4CustomerAddress1, Me.col4CustomerAddress2, Me.col4Region, Me.col4RegionName, Me.col4Province, Me.col4ProvinceName, Me.col4Municipality, Me.col4MunicipalityName, Me.col4ZipCode})
        Me.dgCustomerWithStateAreaTerritory.Location = New System.Drawing.Point(3, 24)
        Me.dgCustomerWithStateAreaTerritory.Name = "dgCustomerWithStateAreaTerritory"
        Me.dgCustomerWithStateAreaTerritory.RowHeadersVisible = False
        Me.dgCustomerWithStateAreaTerritory.Size = New System.Drawing.Size(906, 432)
        Me.dgCustomerWithStateAreaTerritory.TabIndex = 2
        '
        'col4Select
        '
        Me.col4Select.HeaderText = ""
        Me.col4Select.Name = "col4Select"
        Me.col4Select.Width = 30
        '
        'col4CustomerCode
        '
        Me.col4CustomerCode.HeaderText = "Cust. Code"
        Me.col4CustomerCode.Name = "col4CustomerCode"
        Me.col4CustomerCode.ReadOnly = True
        Me.col4CustomerCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col4CustomerCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col4CustomerCode.Width = 75
        '
        'col4CustomerName
        '
        Me.col4CustomerName.HeaderText = "Cust. Name"
        Me.col4CustomerName.MinimumWidth = 75
        Me.col4CustomerName.Name = "col4CustomerName"
        Me.col4CustomerName.ReadOnly = True
        Me.col4CustomerName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col4CustomerName.Width = 150
        '
        'col4CustomerAddress1
        '
        Me.col4CustomerAddress1.HeaderText = "Cust. Address 1"
        Me.col4CustomerAddress1.Name = "col4CustomerAddress1"
        Me.col4CustomerAddress1.ReadOnly = True
        Me.col4CustomerAddress1.Width = 150
        '
        'col4CustomerAddress2
        '
        Me.col4CustomerAddress2.HeaderText = "Cust. Address 2"
        Me.col4CustomerAddress2.Name = "col4CustomerAddress2"
        Me.col4CustomerAddress2.Width = 150
        '
        'col4Region
        '
        Me.col4Region.HeaderText = "Region"
        Me.col4Region.Name = "col4Region"
        Me.col4Region.ReadOnly = True
        Me.col4Region.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col4Region.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col4Region.Width = 75
        '
        'col4RegionName
        '
        Me.col4RegionName.HeaderText = "Region Name"
        Me.col4RegionName.Name = "col4RegionName"
        Me.col4RegionName.ReadOnly = True
        '
        'col4Province
        '
        Me.col4Province.HeaderText = "Province"
        Me.col4Province.Name = "col4Province"
        Me.col4Province.ReadOnly = True
        Me.col4Province.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col4Province.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col4Province.Width = 75
        '
        'col4ProvinceName
        '
        Me.col4ProvinceName.HeaderText = "Province Name"
        Me.col4ProvinceName.Name = "col4ProvinceName"
        Me.col4ProvinceName.ReadOnly = True
        '
        'col4Municipality
        '
        Me.col4Municipality.HeaderText = "Municipality"
        Me.col4Municipality.Name = "col4Municipality"
        Me.col4Municipality.ReadOnly = True
        Me.col4Municipality.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col4Municipality.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col4Municipality.Width = 90
        '
        'col4MunicipalityName
        '
        Me.col4MunicipalityName.HeaderText = "Municipality Name"
        Me.col4MunicipalityName.Name = "col4MunicipalityName"
        Me.col4MunicipalityName.ReadOnly = True
        '
        'col4ZipCode
        '
        Me.col4ZipCode.HeaderText = "Zip Code"
        Me.col4ZipCode.Name = "col4ZipCode"
        Me.col4ZipCode.ReadOnly = True
        Me.col4ZipCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col4ZipCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col4ZipCode.Width = 78
        '
        'TabPage7
        '
        Me.TabPage7.BackColor = System.Drawing.Color.White
        Me.TabPage7.Controls.Add(Me.LinkLabel22)
        Me.TabPage7.Controls.Add(Me.LinkLabel18)
        Me.TabPage7.Controls.Add(Me.LinkLabel19)
        Me.TabPage7.Controls.Add(Me.LinkLabel20)
        Me.TabPage7.Controls.Add(Me.Label18)
        Me.TabPage7.Controls.Add(Me.dgShipToCustomer)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(996, 509)
        Me.TabPage7.TabIndex = 5
        Me.TabPage7.Text = "Page 6"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'LinkLabel22
        '
        Me.LinkLabel22.AutoSize = True
        Me.LinkLabel22.Location = New System.Drawing.Point(784, 463)
        Me.LinkLabel22.Name = "LinkLabel22"
        Me.LinkLabel22.Size = New System.Drawing.Size(125, 13)
        Me.LinkLabel22.TabIndex = 24
        Me.LinkLabel22.TabStop = True
        Me.LinkLabel22.Text = "Set Selected To Default"
        '
        'LinkLabel18
        '
        Me.LinkLabel18.AutoSize = True
        Me.LinkLabel18.Location = New System.Drawing.Point(690, 463)
        Me.LinkLabel18.Name = "LinkLabel18"
        Me.LinkLabel18.Size = New System.Drawing.Size(91, 13)
        Me.LinkLabel18.TabIndex = 23
        Me.LinkLabel18.TabStop = True
        Me.LinkLabel18.Text = "Update Selected"
        '
        'LinkLabel19
        '
        Me.LinkLabel19.AutoSize = True
        Me.LinkLabel19.Location = New System.Drawing.Point(59, 463)
        Me.LinkLabel19.Name = "LinkLabel19"
        Me.LinkLabel19.Size = New System.Drawing.Size(67, 13)
        Me.LinkLabel19.TabIndex = 22
        Me.LinkLabel19.TabStop = True
        Me.LinkLabel19.Text = "Uncheck All"
        '
        'LinkLabel20
        '
        Me.LinkLabel20.AutoSize = True
        Me.LinkLabel20.Location = New System.Drawing.Point(7, 463)
        Me.LinkLabel20.Name = "LinkLabel20"
        Me.LinkLabel20.Size = New System.Drawing.Size(54, 13)
        Me.LinkLabel20.TabIndex = 21
        Me.LinkLabel20.TabStop = True
        Me.LinkLabel20.Text = "Check All"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(4, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(432, 13)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "Customer Ship To(s) without Region or Province or Municipality or Zip Code "
        '
        'dgShipToCustomer
        '
        Me.dgShipToCustomer.AllowUserToAddRows = False
        Me.dgShipToCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgShipToCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgShipToCustomer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col6Select, Me.col6CustomerCode, Me.col6CustName, Me.col6ShipToCode, Me.col6ShipToName, Me.col6CustomerAddress, Me.col6CustomerAddress2, Me.col6Region, Me.col6RegionName, Me.col6Province, Me.col6ProvinceName, Me.col6Municipality, Me.col6MunicipalityName, Me.col6ZipCode})
        Me.dgShipToCustomer.Location = New System.Drawing.Point(3, 28)
        Me.dgShipToCustomer.Name = "dgShipToCustomer"
        Me.dgShipToCustomer.RowHeadersVisible = False
        Me.dgShipToCustomer.Size = New System.Drawing.Size(906, 432)
        Me.dgShipToCustomer.TabIndex = 18
        '
        'col6Select
        '
        Me.col6Select.HeaderText = ""
        Me.col6Select.Name = "col6Select"
        Me.col6Select.Width = 30
        '
        'col6CustomerCode
        '
        Me.col6CustomerCode.HeaderText = "Cust.Code"
        Me.col6CustomerCode.Name = "col6CustomerCode"
        Me.col6CustomerCode.ReadOnly = True
        '
        'col6CustName
        '
        Me.col6CustName.HeaderText = "Customer Name"
        Me.col6CustName.Name = "col6CustName"
        Me.col6CustName.ReadOnly = True
        Me.col6CustName.Width = 125
        '
        'col6ShipToCode
        '
        Me.col6ShipToCode.HeaderText = "Ship To Code"
        Me.col6ShipToCode.Name = "col6ShipToCode"
        Me.col6ShipToCode.ReadOnly = True
        Me.col6ShipToCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col6ShipToCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col6ShipToCode.Width = 75
        '
        'col6ShipToName
        '
        Me.col6ShipToName.HeaderText = "Ship To Name"
        Me.col6ShipToName.MinimumWidth = 75
        Me.col6ShipToName.Name = "col6ShipToName"
        Me.col6ShipToName.ReadOnly = True
        Me.col6ShipToName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col6ShipToName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col6ShipToName.Width = 150
        '
        'col6CustomerAddress
        '
        Me.col6CustomerAddress.HeaderText = "Cust. Address 1"
        Me.col6CustomerAddress.Name = "col6CustomerAddress"
        Me.col6CustomerAddress.ReadOnly = True
        Me.col6CustomerAddress.Width = 150
        '
        'col6CustomerAddress2
        '
        Me.col6CustomerAddress2.HeaderText = "Cust. Address 2"
        Me.col6CustomerAddress2.Name = "col6CustomerAddress2"
        Me.col6CustomerAddress2.Width = 150
        '
        'col6Region
        '
        Me.col6Region.HeaderText = "Region"
        Me.col6Region.Name = "col6Region"
        Me.col6Region.ReadOnly = True
        Me.col6Region.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col6Region.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col6Region.Width = 75
        '
        'col6RegionName
        '
        Me.col6RegionName.HeaderText = "Region Name"
        Me.col6RegionName.Name = "col6RegionName"
        Me.col6RegionName.ReadOnly = True
        '
        'col6Province
        '
        Me.col6Province.HeaderText = "Province"
        Me.col6Province.Name = "col6Province"
        Me.col6Province.ReadOnly = True
        Me.col6Province.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col6Province.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col6Province.Width = 75
        '
        'col6ProvinceName
        '
        Me.col6ProvinceName.HeaderText = "Province Name"
        Me.col6ProvinceName.Name = "col6ProvinceName"
        Me.col6ProvinceName.ReadOnly = True
        '
        'col6Municipality
        '
        Me.col6Municipality.HeaderText = "Municipality"
        Me.col6Municipality.Name = "col6Municipality"
        Me.col6Municipality.ReadOnly = True
        Me.col6Municipality.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col6Municipality.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col6Municipality.Width = 90
        '
        'col6MunicipalityName
        '
        Me.col6MunicipalityName.HeaderText = "Municipality Name"
        Me.col6MunicipalityName.Name = "col6MunicipalityName"
        Me.col6MunicipalityName.ReadOnly = True
        '
        'col6ZipCode
        '
        Me.col6ZipCode.HeaderText = "Zip Code"
        Me.col6ZipCode.Name = "col6ZipCode"
        Me.col6ZipCode.ReadOnly = True
        Me.col6ZipCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col6ZipCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col6ZipCode.Width = 78
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.Color.White
        Me.TabPage6.Controls.Add(Me.LinkLabel14)
        Me.TabPage6.Controls.Add(Me.LinkLabel15)
        Me.TabPage6.Controls.Add(Me.LinkLabel16)
        Me.TabPage6.Controls.Add(Me.Label11)
        Me.TabPage6.Controls.Add(Me.dgUnmappedCustomers)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(996, 509)
        Me.TabPage6.TabIndex = 4
        Me.TabPage6.Text = "Page 7"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'LinkLabel14
        '
        Me.LinkLabel14.AutoSize = True
        Me.LinkLabel14.Location = New System.Drawing.Point(818, 460)
        Me.LinkLabel14.Name = "LinkLabel14"
        Me.LinkLabel14.Size = New System.Drawing.Size(91, 13)
        Me.LinkLabel14.TabIndex = 23
        Me.LinkLabel14.TabStop = True
        Me.LinkLabel14.Text = "Update Selected"
        '
        'LinkLabel15
        '
        Me.LinkLabel15.AutoSize = True
        Me.LinkLabel15.Location = New System.Drawing.Point(59, 460)
        Me.LinkLabel15.Name = "LinkLabel15"
        Me.LinkLabel15.Size = New System.Drawing.Size(67, 13)
        Me.LinkLabel15.TabIndex = 22
        Me.LinkLabel15.TabStop = True
        Me.LinkLabel15.Text = "Uncheck All"
        '
        'LinkLabel16
        '
        Me.LinkLabel16.AutoSize = True
        Me.LinkLabel16.Location = New System.Drawing.Point(7, 460)
        Me.LinkLabel16.Name = "LinkLabel16"
        Me.LinkLabel16.Size = New System.Drawing.Size(54, 13)
        Me.LinkLabel16.TabIndex = 21
        Me.LinkLabel16.TabStop = True
        Me.LinkLabel16.Text = "Check All"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(2, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(406, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Customer(s) with default Region or Province or Municipality or ZipCode"
        '
        'dgUnmappedCustomers
        '
        Me.dgUnmappedCustomers.AllowUserToAddRows = False
        Me.dgUnmappedCustomers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgUnmappedCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgUnmappedCustomers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col5Select, Me.col5CustomerCode, Me.col5CustomerName, Me.col5CustomerAddress1, Me.col5CustomerAddress2, Me.col5Region, Me.col5Province, Me.col5Municipality, Me.col5ZipCode})
        Me.dgUnmappedCustomers.Location = New System.Drawing.Point(3, 25)
        Me.dgUnmappedCustomers.Name = "dgUnmappedCustomers"
        Me.dgUnmappedCustomers.RowHeadersVisible = False
        Me.dgUnmappedCustomers.Size = New System.Drawing.Size(906, 432)
        Me.dgUnmappedCustomers.TabIndex = 3
        '
        'col5Select
        '
        Me.col5Select.HeaderText = ""
        Me.col5Select.Name = "col5Select"
        Me.col5Select.Width = 30
        '
        'col5CustomerCode
        '
        Me.col5CustomerCode.HeaderText = "Cust. Code"
        Me.col5CustomerCode.Name = "col5CustomerCode"
        Me.col5CustomerCode.ReadOnly = True
        Me.col5CustomerCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col5CustomerCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col5CustomerCode.Width = 75
        '
        'col5CustomerName
        '
        Me.col5CustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col5CustomerName.HeaderText = "Cust. Name"
        Me.col5CustomerName.MinimumWidth = 75
        Me.col5CustomerName.Name = "col5CustomerName"
        Me.col5CustomerName.ReadOnly = True
        Me.col5CustomerName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'col5CustomerAddress1
        '
        Me.col5CustomerAddress1.HeaderText = "Cust. Address 1"
        Me.col5CustomerAddress1.Name = "col5CustomerAddress1"
        Me.col5CustomerAddress1.ReadOnly = True
        Me.col5CustomerAddress1.Width = 150
        '
        'col5CustomerAddress2
        '
        Me.col5CustomerAddress2.HeaderText = "Cust. Address 2"
        Me.col5CustomerAddress2.Name = "col5CustomerAddress2"
        Me.col5CustomerAddress2.Width = 150
        '
        'col5Region
        '
        Me.col5Region.HeaderText = "Region"
        Me.col5Region.Name = "col5Region"
        Me.col5Region.ReadOnly = True
        Me.col5Region.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col5Region.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col5Region.Width = 75
        '
        'col5Province
        '
        Me.col5Province.HeaderText = "Province"
        Me.col5Province.Name = "col5Province"
        Me.col5Province.ReadOnly = True
        Me.col5Province.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col5Province.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col5Province.Width = 75
        '
        'col5Municipality
        '
        Me.col5Municipality.HeaderText = "Municipality"
        Me.col5Municipality.Name = "col5Municipality"
        Me.col5Municipality.ReadOnly = True
        Me.col5Municipality.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col5Municipality.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col5Municipality.Width = 90
        '
        'col5ZipCode
        '
        Me.col5ZipCode.HeaderText = "Zip Code"
        Me.col5ZipCode.Name = "col5ZipCode"
        Me.col5ZipCode.ReadOnly = True
        Me.col5ZipCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col5ZipCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col5ZipCode.Width = 78
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.White
        Me.TabPage3.Controls.Add(Me.LinkLabel5)
        Me.TabPage3.Controls.Add(Me.LinkLabel6)
        Me.TabPage3.Controls.Add(Me.LinkLabel10)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.dgUnmappedShipToCustomers)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(996, 509)
        Me.TabPage3.TabIndex = 8
        Me.TabPage3.Text = "Page 8"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'LinkLabel5
        '
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.Location = New System.Drawing.Point(817, 465)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(91, 13)
        Me.LinkLabel5.TabIndex = 26
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "Update Selected"
        '
        'LinkLabel6
        '
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.Location = New System.Drawing.Point(58, 465)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(67, 13)
        Me.LinkLabel6.TabIndex = 25
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Text = "Uncheck All"
        '
        'LinkLabel10
        '
        Me.LinkLabel10.AutoSize = True
        Me.LinkLabel10.Location = New System.Drawing.Point(6, 465)
        Me.LinkLabel10.Name = "LinkLabel10"
        Me.LinkLabel10.Size = New System.Drawing.Size(54, 13)
        Me.LinkLabel10.TabIndex = 24
        Me.LinkLabel10.TabStop = True
        Me.LinkLabel10.Text = "Check All"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(432, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Customer Ship To(s) without Region or Province or Municipality or Zip Code "
        '
        'dgUnmappedShipToCustomers
        '
        Me.dgUnmappedShipToCustomers.AllowUserToAddRows = False
        Me.dgUnmappedShipToCustomers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgUnmappedShipToCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgUnmappedShipToCustomers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col10Select, Me.col10CustCode, Me.col10CustomerName, Me.col10ShipToCode, Me.col10ShipToName, Me.col10ShipToAddress1, Me.col10ShipToAddress2, Me.col10Region, Me.col10RegionName, Me.col10Province, Me.col10ProvinceName, Me.col10Municipality, Me.col10MunicipalityName, Me.col10ZipCode})
        Me.dgUnmappedShipToCustomers.Location = New System.Drawing.Point(2, 30)
        Me.dgUnmappedShipToCustomers.Name = "dgUnmappedShipToCustomers"
        Me.dgUnmappedShipToCustomers.RowHeadersVisible = False
        Me.dgUnmappedShipToCustomers.Size = New System.Drawing.Size(906, 432)
        Me.dgUnmappedShipToCustomers.TabIndex = 20
        '
        'col10Select
        '
        Me.col10Select.HeaderText = ""
        Me.col10Select.Name = "col10Select"
        Me.col10Select.Width = 30
        '
        'col10CustCode
        '
        Me.col10CustCode.HeaderText = "Cust.Code"
        Me.col10CustCode.Name = "col10CustCode"
        Me.col10CustCode.ReadOnly = True
        '
        'col10CustomerName
        '
        Me.col10CustomerName.HeaderText = "Customer Name"
        Me.col10CustomerName.Name = "col10CustomerName"
        Me.col10CustomerName.ReadOnly = True
        Me.col10CustomerName.Width = 125
        '
        'col10ShipToCode
        '
        Me.col10ShipToCode.HeaderText = "Ship To Code"
        Me.col10ShipToCode.Name = "col10ShipToCode"
        Me.col10ShipToCode.ReadOnly = True
        Me.col10ShipToCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col10ShipToCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col10ShipToCode.Width = 75
        '
        'col10ShipToName
        '
        Me.col10ShipToName.HeaderText = "Ship To Name"
        Me.col10ShipToName.MinimumWidth = 75
        Me.col10ShipToName.Name = "col10ShipToName"
        Me.col10ShipToName.ReadOnly = True
        Me.col10ShipToName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col10ShipToName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col10ShipToName.Width = 150
        '
        'col10ShipToAddress1
        '
        Me.col10ShipToAddress1.HeaderText = "Cust. Address 1"
        Me.col10ShipToAddress1.Name = "col10ShipToAddress1"
        Me.col10ShipToAddress1.ReadOnly = True
        Me.col10ShipToAddress1.Width = 150
        '
        'col10ShipToAddress2
        '
        Me.col10ShipToAddress2.HeaderText = "Cust. Address 2"
        Me.col10ShipToAddress2.Name = "col10ShipToAddress2"
        Me.col10ShipToAddress2.Width = 150
        '
        'col10Region
        '
        Me.col10Region.HeaderText = "Region"
        Me.col10Region.Name = "col10Region"
        Me.col10Region.ReadOnly = True
        Me.col10Region.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col10Region.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col10Region.Width = 75
        '
        'col10RegionName
        '
        Me.col10RegionName.HeaderText = "Region Name"
        Me.col10RegionName.Name = "col10RegionName"
        Me.col10RegionName.ReadOnly = True
        '
        'col10Province
        '
        Me.col10Province.HeaderText = "Province"
        Me.col10Province.Name = "col10Province"
        Me.col10Province.ReadOnly = True
        Me.col10Province.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col10Province.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col10Province.Width = 75
        '
        'col10ProvinceName
        '
        Me.col10ProvinceName.HeaderText = "Province Name"
        Me.col10ProvinceName.Name = "col10ProvinceName"
        Me.col10ProvinceName.ReadOnly = True
        '
        'col10Municipality
        '
        Me.col10Municipality.HeaderText = "Municipality"
        Me.col10Municipality.Name = "col10Municipality"
        Me.col10Municipality.ReadOnly = True
        Me.col10Municipality.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col10Municipality.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col10Municipality.Width = 90
        '
        'col10MunicipalityName
        '
        Me.col10MunicipalityName.HeaderText = "Municipality Name"
        Me.col10MunicipalityName.Name = "col10MunicipalityName"
        Me.col10MunicipalityName.ReadOnly = True
        '
        'col10ZipCode
        '
        Me.col10ZipCode.HeaderText = "Zip Code"
        Me.col10ZipCode.Name = "col10ZipCode"
        Me.col10ZipCode.ReadOnly = True
        Me.col10ZipCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col10ZipCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col10ZipCode.Width = 78
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.dtEnd)
        Me.TabPage2.Controls.Add(Me.dtStart)
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.Label21)
        Me.TabPage2.Controls.Add(Me.LinkLabel9)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.dgCustomerWithoutTerritory)
        Me.TabPage2.Controls.Add(Me.TextBox6)
        Me.TabPage2.Controls.Add(Me.TextBox5)
        Me.TabPage2.Controls.Add(Me.TextBox4)
        Me.TabPage2.Controls.Add(Me.TextBox3)
        Me.TabPage2.Controls.Add(Me.TextBox2)
        Me.TabPage2.Controls.Add(Me.TextBox1)
        Me.TabPage2.Controls.Add(Me.LinkLabel8)
        Me.TabPage2.Controls.Add(Me.txtTerritory)
        Me.TabPage2.Controls.Add(Me.lnkTerritory)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.LinkLabel3)
        Me.TabPage2.Controls.Add(Me.LinkLabel4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage2.Size = New System.Drawing.Size(996, 509)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Page 3"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dtEnd
        '
        Me.dtEnd.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEnd.Location = New System.Drawing.Point(756, 34)
        Me.dtEnd.Name = "dtEnd"
        Me.dtEnd.Size = New System.Drawing.Size(132, 22)
        Me.dtEnd.TabIndex = 99
        '
        'dtStart
        '
        Me.dtStart.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStart.Location = New System.Drawing.Point(756, 7)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(132, 22)
        Me.dtStart.TabIndex = 98
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(636, 36)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(112, 13)
        Me.Label20.TabIndex = 97
        Me.Label20.Text = "Effectivity End Date :"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(635, 12)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(116, 13)
        Me.Label21.TabIndex = 96
        Me.Label21.Text = "Effectivity Start Date :"
        '
        'LinkLabel9
        '
        Me.LinkLabel9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel9.AutoSize = True
        Me.LinkLabel9.Location = New System.Drawing.Point(832, 486)
        Me.LinkLabel9.Name = "LinkLabel9"
        Me.LinkLabel9.Size = New System.Drawing.Size(74, 13)
        Me.LinkLabel9.TabIndex = 16
        Me.LinkLabel9.TabStop = True
        Me.LinkLabel9.Text = "Add Selected"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(231, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Customer(s) without assigned Territory"
        '
        'dgCustomerWithoutTerritory
        '
        Me.dgCustomerWithoutTerritory.AllowUserToAddRows = False
        Me.dgCustomerWithoutTerritory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCustomerWithoutTerritory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCustomerWithoutTerritory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col2Select, Me.col2CustomerCode, Me.col2CustomerName, Me.col2CustomerGroup, Me.col2CustomerAddress, Me.col2ShipTo, Me.col2ShipToName, Me.col2Region, Me.col2Province, Me.col2Area, Me.col2ZipCode, Me.col2SalesDivision, Me.colTerritory})
        Me.dgCustomerWithoutTerritory.Location = New System.Drawing.Point(3, 62)
        Me.dgCustomerWithoutTerritory.Name = "dgCustomerWithoutTerritory"
        Me.dgCustomerWithoutTerritory.RowHeadersVisible = False
        Me.dgCustomerWithoutTerritory.Size = New System.Drawing.Size(906, 421)
        Me.dgCustomerWithoutTerritory.TabIndex = 1
        '
        'col2Select
        '
        Me.col2Select.HeaderText = ""
        Me.col2Select.Name = "col2Select"
        Me.col2Select.Width = 30
        '
        'col2CustomerCode
        '
        Me.col2CustomerCode.HeaderText = "Cust. Code"
        Me.col2CustomerCode.Name = "col2CustomerCode"
        Me.col2CustomerCode.ReadOnly = True
        Me.col2CustomerCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2CustomerCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col2CustomerCode.Width = 75
        '
        'col2CustomerName
        '
        Me.col2CustomerName.HeaderText = "Cust. Name"
        Me.col2CustomerName.MinimumWidth = 75
        Me.col2CustomerName.Name = "col2CustomerName"
        Me.col2CustomerName.ReadOnly = True
        Me.col2CustomerName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2CustomerName.Width = 125
        '
        'col2CustomerGroup
        '
        Me.col2CustomerGroup.HeaderText = "Cust. Group"
        Me.col2CustomerGroup.Name = "col2CustomerGroup"
        Me.col2CustomerGroup.ReadOnly = True
        '
        'col2CustomerAddress
        '
        Me.col2CustomerAddress.HeaderText = "Cust. Address"
        Me.col2CustomerAddress.Name = "col2CustomerAddress"
        Me.col2CustomerAddress.ReadOnly = True
        Me.col2CustomerAddress.Width = 150
        '
        'col2ShipTo
        '
        Me.col2ShipTo.HeaderText = "Ship To Code"
        Me.col2ShipTo.Name = "col2ShipTo"
        '
        'col2ShipToName
        '
        Me.col2ShipToName.HeaderText = "Ship To Name"
        Me.col2ShipToName.Name = "col2ShipToName"
        '
        'col2Region
        '
        Me.col2Region.HeaderText = "Region"
        Me.col2Region.Name = "col2Region"
        Me.col2Region.ReadOnly = True
        Me.col2Region.Width = 75
        '
        'col2Province
        '
        Me.col2Province.HeaderText = "Province"
        Me.col2Province.Name = "col2Province"
        Me.col2Province.ReadOnly = True
        Me.col2Province.Width = 75
        '
        'col2Area
        '
        Me.col2Area.HeaderText = "Municipality"
        Me.col2Area.Name = "col2Area"
        Me.col2Area.ReadOnly = True
        Me.col2Area.Width = 90
        '
        'col2ZipCode
        '
        Me.col2ZipCode.HeaderText = "Zip Code"
        Me.col2ZipCode.Name = "col2ZipCode"
        Me.col2ZipCode.ReadOnly = True
        Me.col2ZipCode.Width = 78
        '
        'col2SalesDivision
        '
        Me.col2SalesDivision.HeaderText = "Item Division"
        Me.col2SalesDivision.Name = "col2SalesDivision"
        Me.col2SalesDivision.ReadOnly = True
        '
        'colTerritory
        '
        Me.colTerritory.HeaderText = "Territory"
        Me.colTerritory.Name = "colTerritory"
        Me.colTerritory.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colTerritory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colTerritory.Width = 150
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(615, 174)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(97, 22)
        Me.TextBox6.TabIndex = 14
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(513, 174)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(100, 22)
        Me.TextBox5.TabIndex = 13
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(414, 174)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 22)
        Me.TextBox4.TabIndex = 12
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(314, 174)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(98, 22)
        Me.TextBox3.TabIndex = 11
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(118, 174)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(195, 22)
        Me.TextBox2.TabIndex = 10
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(10, 174)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(107, 22)
        Me.TextBox1.TabIndex = 9
        '
        'LinkLabel8
        '
        Me.LinkLabel8.AutoSize = True
        Me.LinkLabel8.Location = New System.Drawing.Point(449, 26)
        Me.LinkLabel8.Name = "LinkLabel8"
        Me.LinkLabel8.Size = New System.Drawing.Size(91, 13)
        Me.LinkLabel8.TabIndex = 8
        Me.LinkLabel8.TabStop = True
        Me.LinkLabel8.Text = "Update Selected"
        '
        'txtTerritory
        '
        Me.txtTerritory.BackColor = System.Drawing.Color.White
        Me.txtTerritory.Location = New System.Drawing.Point(129, 25)
        Me.txtTerritory.Name = "txtTerritory"
        Me.txtTerritory.ReadOnly = True
        Me.txtTerritory.Size = New System.Drawing.Size(317, 22)
        Me.txtTerritory.TabIndex = 7
        '
        'lnkTerritory
        '
        Me.lnkTerritory.AutoSize = True
        Me.lnkTerritory.Location = New System.Drawing.Point(6, 29)
        Me.lnkTerritory.Name = "lnkTerritory"
        Me.lnkTerritory.Size = New System.Drawing.Size(91, 13)
        Me.lnkTerritory.TabIndex = 6
        Me.lnkTerritory.TabStop = True
        Me.lnkTerritory.Text = "Select  Territory :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 5
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(57, 486)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(67, 13)
        Me.LinkLabel3.TabIndex = 4
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Uncheck All"
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Location = New System.Drawing.Point(5, 486)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(54, 13)
        Me.LinkLabel4.TabIndex = 3
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Check All"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.ToolStripSeparator2, Me.btnClose, Me.ToolStripSeparator1, Me.lblChannel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1024, 25)
        Me.ToolStrip1.TabIndex = 17
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1024, 58)
        Me.Panel1.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(15, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Raw Data Analyzer"
        '
        'UCRawDataAnalyzer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.MainTab)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UCRawDataAnalyzer"
        Me.Size = New System.Drawing.Size(1024, 768)
        Me.MainTab.ResumeLayout(False)
        Me.tbEntry.ResumeLayout(False)
        Me.tbEntry.PerformLayout()
        CType(Me.dgBatch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbtasks.ResumeLayout(False)
        Me.tbtasks.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.tbListing.ResumeLayout(False)
        Me.tbPages.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgCustomerNotintheSystem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage8.PerformLayout()
        CType(Me.dgShipToNotInSystem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage9.ResumeLayout(False)
        Me.TabPage9.PerformLayout()
        CType(Me.dgCompanyItemsNotInSystem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.dgCustomerWithStateAreaTerritory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        CType(Me.dgShipToCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        CType(Me.dgUnmappedCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgUnmappedShipToCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgCustomerWithoutTerritory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents MainTab As System.Windows.Forms.TabControl
    Friend WithEvents tbEntry As System.Windows.Forms.TabPage
    Friend WithEvents tbListing As System.Windows.Forms.TabPage
    Friend WithEvents tbPages As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgCustomerNotintheSystem As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgCustomerWithoutTerritory As System.Windows.Forms.DataGridView
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCompany As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbtasks As System.Windows.Forms.TabPage
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ProgressBar3 As System.Windows.Forms.ProgressBar
    Friend WithEvents lnkShipToNotInSystem As System.Windows.Forms.LinkLabel
    Friend WithEvents chkShipToNotInSystem As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents lnkItemsNotInPricelist As System.Windows.Forms.LinkLabel
    Friend WithEvents chkItemsNotinPricelist As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lnkSharing As System.Windows.Forms.LinkLabel
    Friend WithEvents chkUnmapped As System.Windows.Forms.CheckBox
    Friend WithEvents lnkUnmappedShipToCustomers As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkWithoutAgent As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAddressProblem As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkCustomersNotInSystem As System.Windows.Forms.LinkLabel
    Friend WithEvents pbar4 As System.Windows.Forms.ProgressBar
    Friend WithEvents pbar3 As System.Windows.Forms.ProgressBar
    Friend WithEvents pbar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents chkCustWithStateAreaTerritoryProblem As System.Windows.Forms.CheckBox
    Friend WithEvents pbar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents chkItemsNotInSystem As System.Windows.Forms.CheckBox
    Friend WithEvents chkCustWithoutAssignedTerritory As System.Windows.Forms.CheckBox
    Friend WithEvents chkCustNotInSystem As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chkStartCrediting As System.Windows.Forms.CheckBox
    Friend WithEvents chkRunPreUpload As System.Windows.Forms.CheckBox
    Friend WithEvents LinkLabel7 As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkTerritory As System.Windows.Forms.LinkLabel
    Friend WithEvents txtTerritory As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel8 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel9 As System.Windows.Forms.LinkLabel
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents dgCustomerWithStateAreaTerritory As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel11 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel12 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel13 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dgUnmappedCustomers As System.Windows.Forms.DataGridView
    Friend WithEvents chkOverrideUnmappedCustomer As System.Windows.Forms.CheckBox
    Friend WithEvents chkOverrideCustomerWithStateAreaTerritoryProblem As System.Windows.Forms.CheckBox
    Friend WithEvents LinkLabel14 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel15 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel16 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtMonthDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboCalendarYear As System.Windows.Forms.ComboBox
    Friend WithEvents lblChannel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dgShipToCustomer As System.Windows.Forms.DataGridView
    Friend WithEvents chkOverrideShipToCustomers As System.Windows.Forms.CheckBox
    Friend WithEvents LinkLabel17 As System.Windows.Forms.LinkLabel
    Friend WithEvents ProgressBar4 As System.Windows.Forms.ProgressBar
    Friend WithEvents chkShipto As System.Windows.Forms.CheckBox
    Friend WithEvents LinkLabel18 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel19 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel20 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel21 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel22 As System.Windows.Forms.LinkLabel
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents LinkLabel23 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel24 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel25 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents dgShipToNotInSystem As System.Windows.Forms.DataGridView
    Friend WithEvents col8Select As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents col8CustomerCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col8CustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col8ShipToCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col8ShipToName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col8ShipToCustomerAddress1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col8ShipToAddress2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col8CustomerGrp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col8Region As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col8Province As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col8Municipality As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col8ZipCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents dgCompanyItemsNotInSystem As System.Windows.Forms.DataGridView
    Friend WithEvents LinkLabel26 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel27 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel28 As System.Windows.Forms.LinkLabel
    Friend WithEvents col9Select As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents col9ItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col9ItemBrandName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblBatchNo As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents dgBatch As System.Windows.Forms.DataGridView
    Friend WithEvents colCompanyCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFileName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCutMo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colYear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lnkBatch As System.Windows.Forms.LinkLabel
    Friend WithEvents txtBatchNo As System.Windows.Forms.TextBox
    Friend WithEvents col6Select As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents col6CustomerCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col6CustName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col6ShipToCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col6ShipToName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col6CustomerAddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col6CustomerAddress2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col6Region As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents col6RegionName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col6Province As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents col6ProvinceName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col6Municipality As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents col6MunicipalityName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col6ZipCode As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgUnmappedShipToCustomers As System.Windows.Forms.DataGridView
    Friend WithEvents chkUnmappedShipto As System.Windows.Forms.CheckBox
    Friend WithEvents col10Select As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents col10CustCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col10CustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col10ShipToCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col10ShipToName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col10ShipToAddress1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col10ShipToAddress2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col10Region As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents col10RegionName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col10Province As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents col10ProvinceName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col10Municipality As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents col10MunicipalityName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col10ZipCode As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents LinkLabel5 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel6 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel10 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel29 As System.Windows.Forms.LinkLabel
    Friend WithEvents col4Select As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents col4CustomerCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col4CustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col4CustomerAddress1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col4CustomerAddress2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col4Region As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents col4RegionName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col4Province As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents col4ProvinceName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col4Municipality As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents col4MunicipalityName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col4ZipCode As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents col5Select As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents col5CustomerCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col5CustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col5CustomerAddress1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col5CustomerAddress2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col5Region As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents col5Province As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents col5Municipality As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents col5ZipCode As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents col2Select As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents col2CustomerCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2CustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2CustomerGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2CustomerAddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2ShipTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2ShipToName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Region As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Province As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Area As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2ZipCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2SalesDivision As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTerritory As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents colSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colCustomerCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCustomerClass As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCustomerAddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCustomerAddress2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colShipTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colShipToName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRegion As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents colProvince As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents colArea As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents colZipCode As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents col1Shared As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
