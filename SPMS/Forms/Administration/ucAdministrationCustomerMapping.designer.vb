<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAdministrationCustomerMapping
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.llUncheck = New System.Windows.Forms.LinkLabel
        Me.cmbCustomerGroup = New System.Windows.Forms.ComboBox
        Me.txtCustomerGroup = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.llCheckAll = New System.Windows.Forms.LinkLabel
        Me.dgCustomer = New System.Windows.Forms.DataGridView
        Me.colSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colCompanyCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCustomerCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colShiptoCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colShiptoName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRegion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRegionDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToAddress1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToAddress2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colProvince = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colProvinceDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMunicipality = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMunicipalityDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colZipCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCustomerGroup = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtCustomerCode = New System.Windows.Forms.TextBox
        Me.cmbCustomerCode = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtCompany = New System.Windows.Forms.TextBox
        Me.cmbCompany = New System.Windows.Forms.ComboBox
        Me.cmbMunicipalityDesc = New System.Windows.Forms.ComboBox
        Me.cmbDistrictDesc = New System.Windows.Forms.ComboBox
        Me.cmbRegionDesc = New System.Windows.Forms.ComboBox
        Me.cmbMunicipality = New System.Windows.Forms.ComboBox
        Me.cmbDistrict = New System.Windows.Forms.ComboBox
        Me.cmbRegion = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbzipCode = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblCheckUncheckAllMunicipality = New System.Windows.Forms.LinkLabel
        Me.lblCheckAllMunicipality = New System.Windows.Forms.LinkLabel
        Me.dgMunicipality = New System.Windows.Forms.DataGridView
        Me.check = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.MunicipalityCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MunicipalityName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRegionCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRegionName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colProvinceCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colProvinceName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ZipCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtArea = New System.Windows.Forms.TextBox
        Me.txtDistrict = New System.Windows.Forms.TextBox
        Me.txtRegion = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtTerritory = New System.Windows.Forms.TextBox
        Me.llTerritory = New System.Windows.Forms.LinkLabel
        Me.txtTerritoryCode = New System.Windows.Forms.TextBox
        Me.tbListing = New System.Windows.Forms.TabPage
        Me.btnFilter = New System.Windows.Forms.Button
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.cmbfilter = New System.Windows.Forms.ComboBox
        Me.lblSelection = New System.Windows.Forms.Label
        Me.GridListing = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnAdd = New System.Windows.Forms.ToolStripButton
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnClose = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkIsActive = New System.Windows.Forms.CheckBox
        Me.dtEnd = New System.Windows.Forms.DateTimePicker
        Me.dtStart = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.ChannelCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AreaCoverageCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AreaCoverageName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colStartDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEndDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.REGCD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DISTCD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AREACD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ZIPCD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MainTab.SuspendLayout()
        Me.tbEntry.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgMunicipality, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tbListing.SuspendLayout()
        CType(Me.GridListing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTab
        '
        Me.MainTab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.MainTab.Controls.Add(Me.tbEntry)
        Me.MainTab.Controls.Add(Me.tbListing)
        Me.MainTab.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainTab.Location = New System.Drawing.Point(3, 93)
        Me.MainTab.Name = "MainTab"
        Me.MainTab.SelectedIndex = 0
        Me.MainTab.Size = New System.Drawing.Size(938, 560)
        Me.MainTab.TabIndex = 18
        '
        'tbEntry
        '
        Me.tbEntry.BackColor = System.Drawing.Color.White
        Me.tbEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tbEntry.Controls.Add(Me.GroupBox3)
        Me.tbEntry.Controls.Add(Me.GroupBox2)
        Me.tbEntry.Controls.Add(Me.GroupBox1)
        Me.tbEntry.Location = New System.Drawing.Point(4, 23)
        Me.tbEntry.Name = "tbEntry"
        Me.tbEntry.Padding = New System.Windows.Forms.Padding(3)
        Me.tbEntry.Size = New System.Drawing.Size(930, 533)
        Me.tbEntry.TabIndex = 0
        Me.tbEntry.Text = "Entry"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.llUncheck)
        Me.GroupBox3.Controls.Add(Me.cmbCustomerGroup)
        Me.GroupBox3.Controls.Add(Me.txtCustomerGroup)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.llCheckAll)
        Me.GroupBox3.Controls.Add(Me.dgCustomer)
        Me.GroupBox3.Controls.Add(Me.txtCustomerCode)
        Me.GroupBox3.Controls.Add(Me.cmbCustomerCode)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 252)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(918, 275)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Customer Mapping"
        '
        'llUncheck
        '
        Me.llUncheck.AutoSize = True
        Me.llUncheck.Location = New System.Drawing.Point(74, 47)
        Me.llUncheck.Name = "llUncheck"
        Me.llUncheck.Size = New System.Drawing.Size(64, 14)
        Me.llUncheck.TabIndex = 12
        Me.llUncheck.TabStop = True
        Me.llUncheck.Text = "Uncheck All"
        '
        'cmbCustomerGroup
        '
        Me.cmbCustomerGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCustomerGroup.FormattingEnabled = True
        Me.cmbCustomerGroup.Location = New System.Drawing.Point(114, 16)
        Me.cmbCustomerGroup.Name = "cmbCustomerGroup"
        Me.cmbCustomerGroup.Size = New System.Drawing.Size(287, 22)
        Me.cmbCustomerGroup.TabIndex = 2
        '
        'txtCustomerGroup
        '
        Me.txtCustomerGroup.Location = New System.Drawing.Point(410, 18)
        Me.txtCustomerGroup.Name = "txtCustomerGroup"
        Me.txtCustomerGroup.Size = New System.Drawing.Size(137, 20)
        Me.txtCustomerGroup.TabIndex = 1
        Me.txtCustomerGroup.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer Group :"
        '
        'llCheckAll
        '
        Me.llCheckAll.AutoSize = True
        Me.llCheckAll.Location = New System.Drawing.Point(16, 47)
        Me.llCheckAll.Name = "llCheckAll"
        Me.llCheckAll.Size = New System.Drawing.Size(52, 14)
        Me.llCheckAll.TabIndex = 11
        Me.llCheckAll.TabStop = True
        Me.llCheckAll.Text = "Check All"
        '
        'dgCustomer
        '
        Me.dgCustomer.AllowUserToAddRows = False
        Me.dgCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCustomer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelect, Me.colCompanyCode, Me.colCustomerCode, Me.colShiptoCode, Me.colShiptoName, Me.colRegion, Me.colRegionDesc, Me.ShipToAddress1, Me.ShipToAddress2, Me.colProvince, Me.colProvinceDesc, Me.colMunicipality, Me.colMunicipalityDesc, Me.colZipCode, Me.colCustomerGroup, Me.colID})
        Me.dgCustomer.Location = New System.Drawing.Point(14, 64)
        Me.dgCustomer.Name = "dgCustomer"
        Me.dgCustomer.Size = New System.Drawing.Size(894, 202)
        Me.dgCustomer.TabIndex = 10
        '
        'colSelect
        '
        Me.colSelect.HeaderText = ""
        Me.colSelect.Name = "colSelect"
        Me.colSelect.Width = 35
        '
        'colCompanyCode
        '
        Me.colCompanyCode.HeaderText = "Channel Code"
        Me.colCompanyCode.Name = "colCompanyCode"
        Me.colCompanyCode.ReadOnly = True
        '
        'colCustomerCode
        '
        Me.colCustomerCode.HeaderText = "CustomerCode"
        Me.colCustomerCode.Name = "colCustomerCode"
        Me.colCustomerCode.ReadOnly = True
        Me.colCustomerCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCustomerCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colCustomerCode.Width = 80
        '
        'colShiptoCode
        '
        Me.colShiptoCode.HeaderText = "ShiptoCode"
        Me.colShiptoCode.Name = "colShiptoCode"
        Me.colShiptoCode.ReadOnly = True
        '
        'colShiptoName
        '
        Me.colShiptoName.HeaderText = "ShipToName"
        Me.colShiptoName.Name = "colShiptoName"
        Me.colShiptoName.ReadOnly = True
        Me.colShiptoName.Width = 310
        '
        'colRegion
        '
        Me.colRegion.HeaderText = "Region"
        Me.colRegion.Name = "colRegion"
        Me.colRegion.Width = 60
        '
        'colRegionDesc
        '
        Me.colRegionDesc.HeaderText = "Region Name"
        Me.colRegionDesc.Name = "colRegionDesc"
        Me.colRegionDesc.ReadOnly = True
        Me.colRegionDesc.Width = 255
        '
        'ShipToAddress1
        '
        Me.ShipToAddress1.HeaderText = "Ship To Address 1"
        Me.ShipToAddress1.Name = "ShipToAddress1"
        Me.ShipToAddress1.Width = 300
        '
        'ShipToAddress2
        '
        Me.ShipToAddress2.HeaderText = "Ship To Address 2"
        Me.ShipToAddress2.Name = "ShipToAddress2"
        Me.ShipToAddress2.Width = 300
        '
        'colProvince
        '
        Me.colProvince.HeaderText = "Province"
        Me.colProvince.Name = "colProvince"
        '
        'colProvinceDesc
        '
        Me.colProvinceDesc.HeaderText = "Province Name"
        Me.colProvinceDesc.Name = "colProvinceDesc"
        Me.colProvinceDesc.ReadOnly = True
        Me.colProvinceDesc.Width = 255
        '
        'colMunicipality
        '
        Me.colMunicipality.HeaderText = "Municipality"
        Me.colMunicipality.Name = "colMunicipality"
        '
        'colMunicipalityDesc
        '
        Me.colMunicipalityDesc.HeaderText = "Municipality Name"
        Me.colMunicipalityDesc.Name = "colMunicipalityDesc"
        Me.colMunicipalityDesc.ReadOnly = True
        Me.colMunicipalityDesc.Width = 255
        '
        'colZipCode
        '
        Me.colZipCode.HeaderText = "Zipcode"
        Me.colZipCode.Name = "colZipCode"
        '
        'colCustomerGroup
        '
        Me.colCustomerGroup.HeaderText = "CustomerGroup"
        Me.colCustomerGroup.Name = "colCustomerGroup"
        '
        'colID
        '
        Me.colID.HeaderText = "ID"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Visible = False
        '
        'txtCustomerCode
        '
        Me.txtCustomerCode.Location = New System.Drawing.Point(549, 19)
        Me.txtCustomerCode.Name = "txtCustomerCode"
        Me.txtCustomerCode.Size = New System.Drawing.Size(222, 20)
        Me.txtCustomerCode.TabIndex = 6
        Me.txtCustomerCode.Visible = False
        '
        'cmbCustomerCode
        '
        Me.cmbCustomerCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCustomerCode.FormattingEnabled = True
        Me.cmbCustomerCode.Location = New System.Drawing.Point(549, 45)
        Me.cmbCustomerCode.Name = "cmbCustomerCode"
        Me.cmbCustomerCode.Size = New System.Drawing.Size(63, 22)
        Me.cmbCustomerCode.TabIndex = 5
        Me.cmbCustomerCode.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(595, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 14)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Customer :"
        Me.Label7.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtCompany)
        Me.GroupBox2.Controls.Add(Me.cmbCompany)
        Me.GroupBox2.Controls.Add(Me.cmbMunicipalityDesc)
        Me.GroupBox2.Controls.Add(Me.cmbDistrictDesc)
        Me.GroupBox2.Controls.Add(Me.cmbRegionDesc)
        Me.GroupBox2.Controls.Add(Me.cmbMunicipality)
        Me.GroupBox2.Controls.Add(Me.cmbDistrict)
        Me.GroupBox2.Controls.Add(Me.cmbRegion)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cmbzipCode)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.lblCheckUncheckAllMunicipality)
        Me.GroupBox2.Controls.Add(Me.lblCheckAllMunicipality)
        Me.GroupBox2.Controls.Add(Me.dgMunicipality)
        Me.GroupBox2.Controls.Add(Me.txtArea)
        Me.GroupBox2.Controls.Add(Me.txtDistrict)
        Me.GroupBox2.Controls.Add(Me.txtRegion)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 75)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(918, 171)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Geographical Map"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 137)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 14)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Channel :"
        '
        'txtCompany
        '
        Me.txtCompany.Location = New System.Drawing.Point(183, 134)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Size = New System.Drawing.Size(181, 20)
        Me.txtCompany.TabIndex = 30
        '
        'cmbCompany
        '
        Me.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCompany.FormattingEnabled = True
        Me.cmbCompany.Location = New System.Drawing.Point(98, 134)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.Size = New System.Drawing.Size(79, 22)
        Me.cmbCompany.TabIndex = 29
        '
        'cmbMunicipalityDesc
        '
        Me.cmbMunicipalityDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMunicipalityDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMunicipalityDesc.FormattingEnabled = True
        Me.cmbMunicipalityDesc.Location = New System.Drawing.Point(183, 72)
        Me.cmbMunicipalityDesc.Name = "cmbMunicipalityDesc"
        Me.cmbMunicipalityDesc.Size = New System.Drawing.Size(181, 22)
        Me.cmbMunicipalityDesc.TabIndex = 24
        '
        'cmbDistrictDesc
        '
        Me.cmbDistrictDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbDistrictDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDistrictDesc.FormattingEnabled = True
        Me.cmbDistrictDesc.Location = New System.Drawing.Point(183, 45)
        Me.cmbDistrictDesc.Name = "cmbDistrictDesc"
        Me.cmbDistrictDesc.Size = New System.Drawing.Size(181, 22)
        Me.cmbDistrictDesc.TabIndex = 22
        '
        'cmbRegionDesc
        '
        Me.cmbRegionDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbRegionDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRegionDesc.FormattingEnabled = True
        Me.cmbRegionDesc.Location = New System.Drawing.Point(183, 19)
        Me.cmbRegionDesc.Name = "cmbRegionDesc"
        Me.cmbRegionDesc.Size = New System.Drawing.Size(181, 22)
        Me.cmbRegionDesc.TabIndex = 20
        '
        'cmbMunicipality
        '
        Me.cmbMunicipality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMunicipality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMunicipality.FormattingEnabled = True
        Me.cmbMunicipality.Location = New System.Drawing.Point(99, 72)
        Me.cmbMunicipality.Name = "cmbMunicipality"
        Me.cmbMunicipality.Size = New System.Drawing.Size(78, 22)
        Me.cmbMunicipality.TabIndex = 23
        '
        'cmbDistrict
        '
        Me.cmbDistrict.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbDistrict.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDistrict.FormattingEnabled = True
        Me.cmbDistrict.Location = New System.Drawing.Point(100, 45)
        Me.cmbDistrict.Name = "cmbDistrict"
        Me.cmbDistrict.Size = New System.Drawing.Size(77, 22)
        Me.cmbDistrict.TabIndex = 21
        '
        'cmbRegion
        '
        Me.cmbRegion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbRegion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRegion.FormattingEnabled = True
        Me.cmbRegion.Location = New System.Drawing.Point(99, 19)
        Me.cmbRegion.Name = "cmbRegion"
        Me.cmbRegion.Size = New System.Drawing.Size(78, 22)
        Me.cmbRegion.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 14)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Municipalty :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 14)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Province :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 14)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Region :"
        '
        'cmbzipCode
        '
        Me.cmbzipCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbzipCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbzipCode.FormattingEnabled = True
        Me.cmbzipCode.Location = New System.Drawing.Point(99, 98)
        Me.cmbzipCode.Name = "cmbzipCode"
        Me.cmbzipCode.Size = New System.Drawing.Size(78, 22)
        Me.cmbzipCode.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 14)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Zip Code :"
        '
        'lblCheckUncheckAllMunicipality
        '
        Me.lblCheckUncheckAllMunicipality.AutoSize = True
        Me.lblCheckUncheckAllMunicipality.Location = New System.Drawing.Point(445, 16)
        Me.lblCheckUncheckAllMunicipality.Name = "lblCheckUncheckAllMunicipality"
        Me.lblCheckUncheckAllMunicipality.Size = New System.Drawing.Size(64, 14)
        Me.lblCheckUncheckAllMunicipality.TabIndex = 14
        Me.lblCheckUncheckAllMunicipality.TabStop = True
        Me.lblCheckUncheckAllMunicipality.Text = "Uncheck All"
        '
        'lblCheckAllMunicipality
        '
        Me.lblCheckAllMunicipality.AutoSize = True
        Me.lblCheckAllMunicipality.Location = New System.Drawing.Point(387, 16)
        Me.lblCheckAllMunicipality.Name = "lblCheckAllMunicipality"
        Me.lblCheckAllMunicipality.Size = New System.Drawing.Size(52, 14)
        Me.lblCheckAllMunicipality.TabIndex = 13
        Me.lblCheckAllMunicipality.TabStop = True
        Me.lblCheckAllMunicipality.Text = "Check All"
        '
        'dgMunicipality
        '
        Me.dgMunicipality.AllowUserToAddRows = False
        Me.dgMunicipality.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMunicipality.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.check, Me.MunicipalityCode, Me.MunicipalityName, Me.colRegionCode, Me.colRegionName, Me.colProvinceCode, Me.colProvinceName, Me.ZipCode})
        Me.dgMunicipality.Location = New System.Drawing.Point(385, 38)
        Me.dgMunicipality.Name = "dgMunicipality"
        Me.dgMunicipality.Size = New System.Drawing.Size(525, 116)
        Me.dgMunicipality.TabIndex = 12
        '
        'check
        '
        Me.check.HeaderText = ""
        Me.check.Name = "check"
        Me.check.Width = 35
        '
        'MunicipalityCode
        '
        Me.MunicipalityCode.HeaderText = "Municipality Code"
        Me.MunicipalityCode.Name = "MunicipalityCode"
        Me.MunicipalityCode.ReadOnly = True
        Me.MunicipalityCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MunicipalityCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MunicipalityName
        '
        Me.MunicipalityName.HeaderText = "Municipality Name"
        Me.MunicipalityName.Name = "MunicipalityName"
        Me.MunicipalityName.Width = 165
        '
        'colRegionCode
        '
        Me.colRegionCode.HeaderText = "Region Code"
        Me.colRegionCode.Name = "colRegionCode"
        '
        'colRegionName
        '
        Me.colRegionName.HeaderText = "Region Name"
        Me.colRegionName.Name = "colRegionName"
        '
        'colProvinceCode
        '
        Me.colProvinceCode.HeaderText = "Province Code"
        Me.colProvinceCode.Name = "colProvinceCode"
        Me.colProvinceCode.Width = 120
        '
        'colProvinceName
        '
        Me.colProvinceName.HeaderText = "Province Name"
        Me.colProvinceName.Name = "colProvinceName"
        Me.colProvinceName.Width = 160
        '
        'ZipCode
        '
        Me.ZipCode.HeaderText = "Zip Code"
        Me.ZipCode.Name = "ZipCode"
        '
        'txtArea
        '
        Me.txtArea.BackColor = System.Drawing.Color.White
        Me.txtArea.Location = New System.Drawing.Point(410, 104)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.ReadOnly = True
        Me.txtArea.Size = New System.Drawing.Size(137, 20)
        Me.txtArea.TabIndex = 10
        Me.txtArea.Visible = False
        '
        'txtDistrict
        '
        Me.txtDistrict.BackColor = System.Drawing.Color.White
        Me.txtDistrict.Location = New System.Drawing.Point(407, 79)
        Me.txtDistrict.Name = "txtDistrict"
        Me.txtDistrict.ReadOnly = True
        Me.txtDistrict.Size = New System.Drawing.Size(135, 20)
        Me.txtDistrict.TabIndex = 9
        Me.txtDistrict.Visible = False
        '
        'txtRegion
        '
        Me.txtRegion.BackColor = System.Drawing.Color.White
        Me.txtRegion.Location = New System.Drawing.Point(407, 50)
        Me.txtRegion.Name = "txtRegion"
        Me.txtRegion.ReadOnly = True
        Me.txtRegion.Size = New System.Drawing.Size(135, 20)
        Me.txtRegion.TabIndex = 5
        Me.txtRegion.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkIsActive)
        Me.GroupBox1.Controls.Add(Me.dtEnd)
        Me.GroupBox1.Controls.Add(Me.dtStart)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtTerritory)
        Me.GroupBox1.Controls.Add(Me.llTerritory)
        Me.GroupBox1.Controls.Add(Me.txtTerritoryCode)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(918, 70)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Territory"
        '
        'txtTerritory
        '
        Me.txtTerritory.BackColor = System.Drawing.Color.White
        Me.txtTerritory.Location = New System.Drawing.Point(270, 14)
        Me.txtTerritory.Multiline = True
        Me.txtTerritory.Name = "txtTerritory"
        Me.txtTerritory.ReadOnly = True
        Me.txtTerritory.Size = New System.Drawing.Size(517, 20)
        Me.txtTerritory.TabIndex = 3
        '
        'llTerritory
        '
        Me.llTerritory.AutoSize = True
        Me.llTerritory.Location = New System.Drawing.Point(7, 20)
        Me.llTerritory.Name = "llTerritory"
        Me.llTerritory.Size = New System.Drawing.Size(96, 14)
        Me.llTerritory.TabIndex = 1
        Me.llTerritory.TabStop = True
        Me.llTerritory.Text = "Select a Territory :"
        '
        'txtTerritoryCode
        '
        Me.txtTerritoryCode.BackColor = System.Drawing.Color.White
        Me.txtTerritoryCode.Location = New System.Drawing.Point(132, 14)
        Me.txtTerritoryCode.Name = "txtTerritoryCode"
        Me.txtTerritoryCode.ReadOnly = True
        Me.txtTerritoryCode.Size = New System.Drawing.Size(135, 20)
        Me.txtTerritoryCode.TabIndex = 2
        '
        'tbListing
        '
        Me.tbListing.BackColor = System.Drawing.Color.White
        Me.tbListing.Controls.Add(Me.btnFilter)
        Me.tbListing.Controls.Add(Me.txtFilter)
        Me.tbListing.Controls.Add(Me.cmbfilter)
        Me.tbListing.Controls.Add(Me.lblSelection)
        Me.tbListing.Controls.Add(Me.GridListing)
        Me.tbListing.Location = New System.Drawing.Point(4, 23)
        Me.tbListing.Name = "tbListing"
        Me.tbListing.Padding = New System.Windows.Forms.Padding(3)
        Me.tbListing.Size = New System.Drawing.Size(930, 533)
        Me.tbListing.TabIndex = 1
        Me.tbListing.Text = "Listing"
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
        Me.cmbfilter.Items.AddRange(New Object() {"All", "CompanyID", "CoverageCode"})
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
        'GridListing
        '
        Me.GridListing.AllowUserToAddRows = False
        Me.GridListing.AllowUserToDeleteRows = False
        Me.GridListing.AllowUserToOrderColumns = True
        Me.GridListing.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridListing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridListing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ChannelCode, Me.AreaCoverageCode, Me.AreaCoverageName, Me.colStartDate, Me.colEndDate, Me.colStatus, Me.REGCD, Me.DISTCD, Me.AREACD, Me.ZIPCD})
        Me.GridListing.Location = New System.Drawing.Point(6, 34)
        Me.GridListing.Name = "GridListing"
        Me.GridListing.Size = New System.Drawing.Size(916, 482)
        Me.GridListing.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.btnEdit, Me.btnDelete, Me.btnSave, Me.ToolStripSeparator2, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(942, 25)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.SPMSOPCI.My.Resources.Resources.add1
        Me.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(48, 22)
        Me.btnAdd.Text = "Add"
        '
        'btnEdit
        '
        Me.btnEdit.Image = Global.SPMSOPCI.My.Resources.Resources.page_edit1
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(47, 22)
        Me.btnEdit.Text = "Edit"
        '
        'btnDelete
        '
        Me.btnDelete.Image = Global.SPMSOPCI.My.Resources.Resources.delete1
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 22)
        Me.btnDelete.Text = "Delete"
        '
        'btnSave
        '
        Me.btnSave.Image = Global.SPMSOPCI.My.Resources.Resources.WSS_DocLib1
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
        Me.btnClose.Image = Global.SPMSOPCI.My.Resources.Resources.cancel
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(55, 22)
        Me.btnClose.Text = "Close"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(942, 58)
        Me.Panel1.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 21)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Customer Mapping"
        '
        'chkIsActive
        '
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.Checked = True
        Me.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsActive.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsActive.Location = New System.Drawing.Point(841, 14)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(67, 17)
        Me.chkIsActive.TabIndex = 96
        Me.chkIsActive.Text = "Is Active"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'dtEnd
        '
        Me.dtEnd.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEnd.Location = New System.Drawing.Point(385, 40)
        Me.dtEnd.Name = "dtEnd"
        Me.dtEnd.Size = New System.Drawing.Size(132, 20)
        Me.dtEnd.TabIndex = 95
        '
        'dtStart
        '
        Me.dtStart.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStart.Location = New System.Drawing.Point(135, 40)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(132, 20)
        Me.dtStart.TabIndex = 94
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(273, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 13)
        Me.Label9.TabIndex = 93
        Me.Label9.Text = "Effectivity End Date :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 13)
        Me.Label11.TabIndex = 92
        Me.Label11.Text = "Effectivity Start Date :"
        '
        'ChannelCode
        '
        Me.ChannelCode.HeaderText = "Channel's Code"
        Me.ChannelCode.Name = "ChannelCode"
        Me.ChannelCode.ReadOnly = True
        Me.ChannelCode.Width = 130
        '
        'AreaCoverageCode
        '
        Me.AreaCoverageCode.HeaderText = "Area Coverage Code"
        Me.AreaCoverageCode.Name = "AreaCoverageCode"
        Me.AreaCoverageCode.Width = 150
        '
        'AreaCoverageName
        '
        Me.AreaCoverageName.HeaderText = "Area Coverage Name"
        Me.AreaCoverageName.Name = "AreaCoverageName"
        Me.AreaCoverageName.Width = 200
        '
        'colStartDate
        '
        Me.colStartDate.HeaderText = "Effectivity Start Date"
        Me.colStartDate.Name = "colStartDate"
        Me.colStartDate.ReadOnly = True
        Me.colStartDate.Width = 140
        '
        'colEndDate
        '
        Me.colEndDate.HeaderText = "Effectivity End Date"
        Me.colEndDate.Name = "colEndDate"
        Me.colEndDate.ReadOnly = True
        Me.colEndDate.Width = 140
        '
        'colStatus
        '
        Me.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        '
        'REGCD
        '
        Me.REGCD.HeaderText = "REGCD"
        Me.REGCD.Name = "REGCD"
        Me.REGCD.Visible = False
        '
        'DISTCD
        '
        Me.DISTCD.HeaderText = "DISTCD"
        Me.DISTCD.Name = "DISTCD"
        Me.DISTCD.Visible = False
        '
        'AREACD
        '
        Me.AREACD.HeaderText = "AREACD"
        Me.AREACD.Name = "AREACD"
        Me.AREACD.Visible = False
        '
        'ZIPCD
        '
        Me.ZIPCD.HeaderText = "ZIPCD"
        Me.ZIPCD.Name = "ZIPCD"
        Me.ZIPCD.Visible = False
        '
        'ucAdministrationCustomerMapping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.MainTab)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ucAdministrationCustomerMapping"
        Me.Size = New System.Drawing.Size(942, 656)
        Me.MainTab.ResumeLayout(False)
        Me.tbEntry.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgMunicipality, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbListing As System.Windows.Forms.TabPage
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents cmbfilter As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelection As System.Windows.Forms.Label
    Friend WithEvents GridListing As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbCustomerGroup As System.Windows.Forms.ComboBox
    Friend WithEvents txtCustomerGroup As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtArea As System.Windows.Forms.TextBox
    Friend WithEvents txtDistrict As System.Windows.Forms.TextBox
    Friend WithEvents txtRegion As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents llTerritory As System.Windows.Forms.LinkLabel
    Friend WithEvents txtTerritory As System.Windows.Forms.TextBox
    Friend WithEvents txtTerritoryCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents cmbCustomerCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgCustomer As System.Windows.Forms.DataGridView
    Friend WithEvents llCheckAll As System.Windows.Forms.LinkLabel
    Friend WithEvents dgMunicipality As System.Windows.Forms.DataGridView
    Friend WithEvents lblCheckUncheckAllMunicipality As System.Windows.Forms.LinkLabel
    Friend WithEvents lblCheckAllMunicipality As System.Windows.Forms.LinkLabel
    Friend WithEvents check As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MunicipalityCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MunicipalityName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRegionCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRegionName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProvinceCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProvinceName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ZipCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents llUncheck As System.Windows.Forms.LinkLabel
    Friend WithEvents cmbMunicipalityDesc As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDistrictDesc As System.Windows.Forms.ComboBox
    Friend WithEvents cmbRegionDesc As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMunicipality As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDistrict As System.Windows.Forms.ComboBox
    Friend WithEvents cmbRegion As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbzipCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCompany As System.Windows.Forms.TextBox
    Friend WithEvents cmbCompany As System.Windows.Forms.ComboBox
    Friend WithEvents colSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colCompanyCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCustomerCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colShiptoCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colShiptoName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRegion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRegionDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToAddress1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToAddress2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProvince As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProvinceDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMunicipality As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMunicipalityDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colZipCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCustomerGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ChannelCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AreaCoverageCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AreaCoverageName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStartDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEndDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REGCD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DISTCD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AREACD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ZIPCD As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
