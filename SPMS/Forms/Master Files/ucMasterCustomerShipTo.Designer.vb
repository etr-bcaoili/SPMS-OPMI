<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMasterCustomerShipTo
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnAdd = New System.Windows.Forms.ToolStripButton
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnClose = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.MainTab = New System.Windows.Forms.TabControl
        Me.tbEntry = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboDistrictDesc = New System.Windows.Forms.ComboBox
        Me.cboAreaDesc = New System.Windows.Forms.ComboBox
        Me.cboRegionDesc = New System.Windows.Forms.ComboBox
        Me.dtEnd = New System.Windows.Forms.DateTimePicker
        Me.dtStart = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtArea = New System.Windows.Forms.TextBox
        Me.txtDistrict = New System.Windows.Forms.TextBox
        Me.txtRegion = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.cboZipCode = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.cboDistrict = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.cboArea = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboRegion = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkAccountShared = New System.Windows.Forms.CheckBox
        Me.txtCustomerClass = New System.Windows.Forms.TextBox
        Me.txtCustomerGroup = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.cboCustomerClass = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.cboCustomerGroup = New System.Windows.Forms.ComboBox
        Me.txtCustomerCode = New System.Windows.Forms.TextBox
        Me.lnkCustCode = New System.Windows.Forms.LinkLabel
        Me.txtPhoneNumber = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtContactPerson = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtCustomerShiptoName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtCompany = New System.Windows.Forms.TextBox
        Me.txtCustomerAddress2 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCustomerAddress1 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboCompany = New System.Windows.Forms.ComboBox
        Me.txtCustomerShipToCode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCustomerName = New System.Windows.Forms.TextBox
        Me.cboAreaOfCoverage = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtAreaOfCoverage = New System.Windows.Forms.TextBox
        Me.tbListing = New System.Windows.Forms.TabPage
        Me.lnkRefresh = New System.Windows.Forms.LinkLabel
        Me.btnFilter = New System.Windows.Forms.Button
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.cboSelection = New System.Windows.Forms.ComboBox
        Me.lblSelection = New System.Windows.Forms.Label
        Me.GridListing = New System.Windows.Forms.DataGridView
        Me.ChannelsCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerShipToCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerShipToName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerShipToAddress1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerShipToAddress2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRegion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRegionName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CityProvince = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CityProvinceName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Municipality = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MunicipalityName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ZipCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MainTab.SuspendLayout()
        Me.tbEntry.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbListing.SuspendLayout()
        CType(Me.GridListing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.btnEdit, Me.btnDelete, Me.btnSave, Me.ToolStripSeparator2, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1024, 25)
        Me.ToolStrip1.TabIndex = 28
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
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1024, 58)
        Me.Panel1.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Customer Ship To"
        '
        'MainTab
        '
        Me.MainTab.Controls.Add(Me.tbEntry)
        Me.MainTab.Controls.Add(Me.tbListing)
        Me.MainTab.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainTab.Location = New System.Drawing.Point(3, 87)
        Me.MainTab.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainTab.Name = "MainTab"
        Me.MainTab.SelectedIndex = 0
        Me.MainTab.Size = New System.Drawing.Size(1000, 565)
        Me.MainTab.TabIndex = 29
        '
        'tbEntry
        '
        Me.tbEntry.BackColor = System.Drawing.SystemColors.Control
        Me.tbEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbEntry.Controls.Add(Me.GroupBox2)
        Me.tbEntry.Controls.Add(Me.GroupBox1)
        Me.tbEntry.Controls.Add(Me.cboAreaOfCoverage)
        Me.tbEntry.Controls.Add(Me.Label23)
        Me.tbEntry.Controls.Add(Me.txtAreaOfCoverage)
        Me.tbEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEntry.Location = New System.Drawing.Point(4, 22)
        Me.tbEntry.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbEntry.Name = "tbEntry"
        Me.tbEntry.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbEntry.Size = New System.Drawing.Size(992, 539)
        Me.tbEntry.TabIndex = 0
        Me.tbEntry.Text = "Entry"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboDistrictDesc)
        Me.GroupBox2.Controls.Add(Me.cboAreaDesc)
        Me.GroupBox2.Controls.Add(Me.cboRegionDesc)
        Me.GroupBox2.Controls.Add(Me.dtEnd)
        Me.GroupBox2.Controls.Add(Me.dtStart)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtArea)
        Me.GroupBox2.Controls.Add(Me.txtDistrict)
        Me.GroupBox2.Controls.Add(Me.txtRegion)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.cboZipCode)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.cboDistrict)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.cboArea)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.cboRegion)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(563, 24)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(424, 223)
        Me.GroupBox2.TabIndex = 50
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Geographical Map"
        '
        'cboDistrictDesc
        '
        Me.cboDistrictDesc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDistrictDesc.FormattingEnabled = True
        Me.cboDistrictDesc.Location = New System.Drawing.Point(220, 55)
        Me.cboDistrictDesc.Name = "cboDistrictDesc"
        Me.cboDistrictDesc.Size = New System.Drawing.Size(166, 21)
        Me.cboDistrictDesc.TabIndex = 82
        '
        'cboAreaDesc
        '
        Me.cboAreaDesc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAreaDesc.FormattingEnabled = True
        Me.cboAreaDesc.Location = New System.Drawing.Point(220, 84)
        Me.cboAreaDesc.Name = "cboAreaDesc"
        Me.cboAreaDesc.Size = New System.Drawing.Size(166, 21)
        Me.cboAreaDesc.TabIndex = 81
        '
        'cboRegionDesc
        '
        Me.cboRegionDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRegionDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRegionDesc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRegionDesc.FormattingEnabled = True
        Me.cboRegionDesc.Location = New System.Drawing.Point(220, 28)
        Me.cboRegionDesc.Name = "cboRegionDesc"
        Me.cboRegionDesc.Size = New System.Drawing.Size(166, 21)
        Me.cboRegionDesc.TabIndex = 80
        '
        'dtEnd
        '
        Me.dtEnd.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEnd.Location = New System.Drawing.Point(139, 184)
        Me.dtEnd.Name = "dtEnd"
        Me.dtEnd.Size = New System.Drawing.Size(91, 22)
        Me.dtEnd.TabIndex = 78
        Me.dtEnd.Visible = False
        '
        'dtStart
        '
        Me.dtStart.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStart.Location = New System.Drawing.Point(139, 156)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(91, 22)
        Me.dtStart.TabIndex = 77
        Me.dtStart.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 184)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 13)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "Effectivity End Date :"
        Me.Label7.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 158)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 13)
        Me.Label8.TabIndex = 75
        Me.Label8.Text = "Effectivity Start Date :"
        Me.Label8.Visible = False
        '
        'txtArea
        '
        Me.txtArea.BackColor = System.Drawing.Color.White
        Me.txtArea.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArea.Location = New System.Drawing.Point(389, 85)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.ReadOnly = True
        Me.txtArea.Size = New System.Drawing.Size(21, 22)
        Me.txtArea.TabIndex = 74
        Me.txtArea.Visible = False
        '
        'txtDistrict
        '
        Me.txtDistrict.BackColor = System.Drawing.Color.White
        Me.txtDistrict.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDistrict.Location = New System.Drawing.Point(389, 55)
        Me.txtDistrict.Name = "txtDistrict"
        Me.txtDistrict.ReadOnly = True
        Me.txtDistrict.Size = New System.Drawing.Size(21, 22)
        Me.txtDistrict.TabIndex = 73
        Me.txtDistrict.Visible = False
        '
        'txtRegion
        '
        Me.txtRegion.BackColor = System.Drawing.Color.White
        Me.txtRegion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegion.Location = New System.Drawing.Point(389, 27)
        Me.txtRegion.Name = "txtRegion"
        Me.txtRegion.ReadOnly = True
        Me.txtRegion.Size = New System.Drawing.Size(21, 22)
        Me.txtRegion.TabIndex = 72
        Me.txtRegion.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(75, 116)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(60, 13)
        Me.Label20.TabIndex = 68
        Me.Label20.Text = "Zip Code :"
        '
        'cboZipCode
        '
        Me.cboZipCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZipCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZipCode.FormattingEnabled = True
        Me.cboZipCode.Location = New System.Drawing.Point(139, 112)
        Me.cboZipCode.Name = "cboZipCode"
        Me.cboZipCode.Size = New System.Drawing.Size(79, 21)
        Me.cboZipCode.TabIndex = 67
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(46, 58)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(89, 13)
        Me.Label19.TabIndex = 66
        Me.Label19.Text = "Province / City :"
        '
        'cboDistrict
        '
        Me.cboDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistrict.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDistrict.FormattingEnabled = True
        Me.cboDistrict.Location = New System.Drawing.Point(139, 55)
        Me.cboDistrict.Name = "cboDistrict"
        Me.cboDistrict.Size = New System.Drawing.Size(79, 21)
        Me.cboDistrict.TabIndex = 65
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(1, 87)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(134, 13)
        Me.Label18.TabIndex = 64
        Me.Label18.Text = "Municipality / Location :"
        '
        'cboArea
        '
        Me.cboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboArea.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboArea.FormattingEnabled = True
        Me.cboArea.Location = New System.Drawing.Point(139, 84)
        Me.cboArea.Name = "cboArea"
        Me.cboArea.Size = New System.Drawing.Size(79, 21)
        Me.cboArea.TabIndex = 63
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(85, 33)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(50, 13)
        Me.Label17.TabIndex = 62
        Me.Label17.Text = "Region :"
        '
        'cboRegion
        '
        Me.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRegion.FormattingEnabled = True
        Me.cboRegion.Location = New System.Drawing.Point(139, 28)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(79, 21)
        Me.cboRegion.TabIndex = 61
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkAccountShared)
        Me.GroupBox1.Controls.Add(Me.txtCustomerClass)
        Me.GroupBox1.Controls.Add(Me.txtCustomerGroup)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.cboCustomerClass)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.cboCustomerGroup)
        Me.GroupBox1.Controls.Add(Me.txtCustomerCode)
        Me.GroupBox1.Controls.Add(Me.lnkCustCode)
        Me.GroupBox1.Controls.Add(Me.txtPhoneNumber)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtContactPerson)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtCustomerShiptoName)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtCompany)
        Me.GroupBox1.Controls.Add(Me.txtCustomerAddress2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtCustomerAddress1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboCompany)
        Me.GroupBox1.Controls.Add(Me.txtCustomerShipToCode)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtCustomerName)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(551, 411)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        '
        'chkAccountShared
        '
        Me.chkAccountShared.AutoSize = True
        Me.chkAccountShared.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAccountShared.Location = New System.Drawing.Point(177, 290)
        Me.chkAccountShared.Name = "chkAccountShared"
        Me.chkAccountShared.Size = New System.Drawing.Size(107, 17)
        Me.chkAccountShared.TabIndex = 95
        Me.chkAccountShared.Text = "Account Shared"
        Me.chkAccountShared.UseVisualStyleBackColor = True
        '
        'txtCustomerClass
        '
        Me.txtCustomerClass.BackColor = System.Drawing.Color.White
        Me.txtCustomerClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerClass.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerClass.Location = New System.Drawing.Point(265, 264)
        Me.txtCustomerClass.Name = "txtCustomerClass"
        Me.txtCustomerClass.ReadOnly = True
        Me.txtCustomerClass.Size = New System.Drawing.Size(190, 22)
        Me.txtCustomerClass.TabIndex = 93
        '
        'txtCustomerGroup
        '
        Me.txtCustomerGroup.BackColor = System.Drawing.Color.White
        Me.txtCustomerGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerGroup.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerGroup.Location = New System.Drawing.Point(265, 237)
        Me.txtCustomerGroup.Name = "txtCustomerGroup"
        Me.txtCustomerGroup.ReadOnly = True
        Me.txtCustomerGroup.Size = New System.Drawing.Size(190, 22)
        Me.txtCustomerGroup.TabIndex = 92
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(77, 268)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(95, 13)
        Me.Label22.TabIndex = 91
        Me.Label22.Text = "Customer Class. :"
        '
        'cboCustomerClass
        '
        Me.cboCustomerClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCustomerClass.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomerClass.FormattingEnabled = True
        Me.cboCustomerClass.Location = New System.Drawing.Point(176, 264)
        Me.cboCustomerClass.Name = "cboCustomerClass"
        Me.cboCustomerClass.Size = New System.Drawing.Size(87, 21)
        Me.cboCustomerClass.TabIndex = 90
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(73, 240)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(99, 13)
        Me.Label21.TabIndex = 89
        Me.Label21.Text = "Customer Group :"
        '
        'cboCustomerGroup
        '
        Me.cboCustomerGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCustomerGroup.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomerGroup.FormattingEnabled = True
        Me.cboCustomerGroup.Location = New System.Drawing.Point(176, 237)
        Me.cboCustomerGroup.Name = "cboCustomerGroup"
        Me.cboCustomerGroup.Size = New System.Drawing.Size(87, 21)
        Me.cboCustomerGroup.TabIndex = 88
        '
        'txtCustomerCode
        '
        Me.txtCustomerCode.BackColor = System.Drawing.Color.White
        Me.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerCode.Location = New System.Drawing.Point(176, 45)
        Me.txtCustomerCode.Name = "txtCustomerCode"
        Me.txtCustomerCode.ReadOnly = True
        Me.txtCustomerCode.Size = New System.Drawing.Size(87, 22)
        Me.txtCustomerCode.TabIndex = 87
        '
        'lnkCustCode
        '
        Me.lnkCustCode.AutoSize = True
        Me.lnkCustCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkCustCode.Location = New System.Drawing.Point(109, 49)
        Me.lnkCustCode.Name = "lnkCustCode"
        Me.lnkCustCode.Size = New System.Drawing.Size(63, 13)
        Me.lnkCustCode.TabIndex = 86
        Me.lnkCustCode.TabStop = True
        Me.lnkCustCode.Text = "Customer :"
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhoneNumber.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhoneNumber.Location = New System.Drawing.Point(176, 209)
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Size = New System.Drawing.Size(279, 22)
        Me.txtPhoneNumber.TabIndex = 78
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(82, 212)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 13)
        Me.Label12.TabIndex = 77
        Me.Label12.Text = "Phone Number :"
        '
        'txtContactPerson
        '
        Me.txtContactPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactPerson.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactPerson.Location = New System.Drawing.Point(176, 183)
        Me.txtContactPerson.Name = "txtContactPerson"
        Me.txtContactPerson.Size = New System.Drawing.Size(279, 22)
        Me.txtContactPerson.TabIndex = 76
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(81, 187)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 13)
        Me.Label13.TabIndex = 75
        Me.Label13.Text = "Contact Person :"
        '
        'txtCustomerShiptoName
        '
        Me.txtCustomerShiptoName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerShiptoName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerShiptoName.Location = New System.Drawing.Point(176, 99)
        Me.txtCustomerShiptoName.Name = "txtCustomerShiptoName"
        Me.txtCustomerShiptoName.Size = New System.Drawing.Size(364, 22)
        Me.txtCustomerShiptoName.TabIndex = 71
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(57, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 13)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "Cust. Ship To Name :"
        '
        'txtCompany
        '
        Me.txtCompany.BackColor = System.Drawing.Color.White
        Me.txtCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompany.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompany.Location = New System.Drawing.Point(266, 19)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.ReadOnly = True
        Me.txtCompany.Size = New System.Drawing.Size(274, 22)
        Me.txtCompany.TabIndex = 69
        '
        'txtCustomerAddress2
        '
        Me.txtCustomerAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerAddress2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerAddress2.Location = New System.Drawing.Point(176, 153)
        Me.txtCustomerAddress2.Multiline = True
        Me.txtCustomerAddress2.Name = "txtCustomerAddress2"
        Me.txtCustomerAddress2.Size = New System.Drawing.Size(364, 22)
        Me.txtCustomerAddress2.TabIndex = 56
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(159, 13)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Customer Ship To Address 2 :"
        '
        'txtCustomerAddress1
        '
        Me.txtCustomerAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerAddress1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerAddress1.Location = New System.Drawing.Point(176, 127)
        Me.txtCustomerAddress1.Multiline = True
        Me.txtCustomerAddress1.Name = "txtCustomerAddress1"
        Me.txtCustomerAddress1.Size = New System.Drawing.Size(364, 22)
        Me.txtCustomerAddress1.TabIndex = 54
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(159, 13)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Customer Ship To Address 1 :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(116, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Channel :"
        '
        'cboCompany
        '
        Me.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompany.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCompany.FormattingEnabled = True
        Me.cboCompany.Location = New System.Drawing.Point(176, 19)
        Me.cboCompany.Name = "cboCompany"
        Me.cboCompany.Size = New System.Drawing.Size(87, 21)
        Me.cboCompany.TabIndex = 51
        '
        'txtCustomerShipToCode
        '
        Me.txtCustomerShipToCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerShipToCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerShipToCode.Location = New System.Drawing.Point(176, 72)
        Me.txtCustomerShipToCode.Name = "txtCustomerShipToCode"
        Me.txtCustomerShipToCode.Size = New System.Drawing.Size(87, 22)
        Me.txtCustomerShipToCode.TabIndex = 50
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(61, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Cust. Ship To Code :"
        '
        'txtCustomerName
        '
        Me.txtCustomerName.BackColor = System.Drawing.Color.White
        Me.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerName.Location = New System.Drawing.Point(266, 46)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.ReadOnly = True
        Me.txtCustomerName.Size = New System.Drawing.Size(274, 22)
        Me.txtCustomerName.TabIndex = 47
        '
        'cboAreaOfCoverage
        '
        Me.cboAreaOfCoverage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAreaOfCoverage.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAreaOfCoverage.FormattingEnabled = True
        Me.cboAreaOfCoverage.Location = New System.Drawing.Point(702, 312)
        Me.cboAreaOfCoverage.Name = "cboAreaOfCoverage"
        Me.cboAreaOfCoverage.Size = New System.Drawing.Size(79, 21)
        Me.cboAreaOfCoverage.TabIndex = 69
        Me.cboAreaOfCoverage.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(569, 316)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(103, 13)
        Me.Label23.TabIndex = 70
        Me.Label23.Text = "Area Of Coverage :"
        Me.Label23.Visible = False
        '
        'txtAreaOfCoverage
        '
        Me.txtAreaOfCoverage.BackColor = System.Drawing.Color.White
        Me.txtAreaOfCoverage.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAreaOfCoverage.Location = New System.Drawing.Point(787, 312)
        Me.txtAreaOfCoverage.Name = "txtAreaOfCoverage"
        Me.txtAreaOfCoverage.ReadOnly = True
        Me.txtAreaOfCoverage.Size = New System.Drawing.Size(186, 22)
        Me.txtAreaOfCoverage.TabIndex = 71
        Me.txtAreaOfCoverage.Visible = False
        '
        'tbListing
        '
        Me.tbListing.BackColor = System.Drawing.SystemColors.Control
        Me.tbListing.Controls.Add(Me.lnkRefresh)
        Me.tbListing.Controls.Add(Me.btnFilter)
        Me.tbListing.Controls.Add(Me.txtFilter)
        Me.tbListing.Controls.Add(Me.cboSelection)
        Me.tbListing.Controls.Add(Me.lblSelection)
        Me.tbListing.Controls.Add(Me.GridListing)
        Me.tbListing.Location = New System.Drawing.Point(4, 22)
        Me.tbListing.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbListing.Name = "tbListing"
        Me.tbListing.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbListing.Size = New System.Drawing.Size(992, 539)
        Me.tbListing.TabIndex = 1
        Me.tbListing.Text = "Listing"
        '
        'lnkRefresh
        '
        Me.lnkRefresh.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkRefresh.AutoSize = True
        Me.lnkRefresh.Location = New System.Drawing.Point(905, 23)
        Me.lnkRefresh.Name = "lnkRefresh"
        Me.lnkRefresh.Size = New System.Drawing.Size(71, 13)
        Me.lnkRefresh.TabIndex = 5
        Me.lnkRefresh.TabStop = True
        Me.lnkRefresh.Text = "Refresh Grid"
        '
        'btnFilter
        '
        Me.btnFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilter.Location = New System.Drawing.Point(432, 5)
        Me.btnFilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(79, 24)
        Me.btnFilter.TabIndex = 4
        Me.btnFilter.Text = "Filter "
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(219, 7)
        Me.txtFilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(207, 22)
        Me.txtFilter.TabIndex = 3
        '
        'cboSelection
        '
        Me.cboSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSelection.FormattingEnabled = True
        Me.cboSelection.Location = New System.Drawing.Point(67, 6)
        Me.cboSelection.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboSelection.Name = "cboSelection"
        Me.cboSelection.Size = New System.Drawing.Size(146, 21)
        Me.cboSelection.TabIndex = 2
        '
        'lblSelection
        '
        Me.lblSelection.AutoSize = True
        Me.lblSelection.Location = New System.Drawing.Point(6, 16)
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
        Me.GridListing.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridListing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridListing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ChannelsCode, Me.CustomerCode, Me.CustomerShipToCode, Me.CustomerShipToName, Me.CustomerShipToAddress1, Me.CustomerShipToAddress2, Me.colRegion, Me.colRegionName, Me.CityProvince, Me.CityProvinceName, Me.Municipality, Me.MunicipalityName, Me.ZipCode})
        Me.GridListing.Location = New System.Drawing.Point(6, 40)
        Me.GridListing.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridListing.Name = "GridListing"
        Me.GridListing.RowHeadersVisible = False
        Me.GridListing.Size = New System.Drawing.Size(980, 470)
        Me.GridListing.TabIndex = 0
        '
        'ChannelsCode
        '
        Me.ChannelsCode.HeaderText = "Channel's Code"
        Me.ChannelsCode.Name = "ChannelsCode"
        Me.ChannelsCode.ReadOnly = True
        Me.ChannelsCode.Width = 125
        '
        'CustomerCode
        '
        Me.CustomerCode.HeaderText = "Customer Code"
        Me.CustomerCode.Name = "CustomerCode"
        Me.CustomerCode.ReadOnly = True
        Me.CustomerCode.Width = 130
        '
        'CustomerShipToCode
        '
        Me.CustomerShipToCode.HeaderText = "Customer Ship To Code"
        Me.CustomerShipToCode.Name = "CustomerShipToCode"
        Me.CustomerShipToCode.ReadOnly = True
        Me.CustomerShipToCode.Width = 160
        '
        'CustomerShipToName
        '
        Me.CustomerShipToName.HeaderText = "Customer Ship To Name"
        Me.CustomerShipToName.Name = "CustomerShipToName"
        Me.CustomerShipToName.ReadOnly = True
        Me.CustomerShipToName.Width = 180
        '
        'CustomerShipToAddress1
        '
        Me.CustomerShipToAddress1.HeaderText = "Customer Ship To Address 1"
        Me.CustomerShipToAddress1.Name = "CustomerShipToAddress1"
        Me.CustomerShipToAddress1.ReadOnly = True
        Me.CustomerShipToAddress1.Width = 300
        '
        'CustomerShipToAddress2
        '
        Me.CustomerShipToAddress2.HeaderText = "Customer Ship To Address 2"
        Me.CustomerShipToAddress2.Name = "CustomerShipToAddress2"
        Me.CustomerShipToAddress2.ReadOnly = True
        Me.CustomerShipToAddress2.Width = 300
        '
        'colRegion
        '
        Me.colRegion.HeaderText = "Region"
        Me.colRegion.Name = "colRegion"
        Me.colRegion.ReadOnly = True
        '
        'colRegionName
        '
        Me.colRegionName.HeaderText = "Region Name"
        Me.colRegionName.Name = "colRegionName"
        Me.colRegionName.ReadOnly = True
        '
        'CityProvince
        '
        Me.CityProvince.HeaderText = "City/Province"
        Me.CityProvince.Name = "CityProvince"
        Me.CityProvince.ReadOnly = True
        '
        'CityProvinceName
        '
        Me.CityProvinceName.HeaderText = "CityProvinceName"
        Me.CityProvinceName.Name = "CityProvinceName"
        Me.CityProvinceName.ReadOnly = True
        '
        'Municipality
        '
        Me.Municipality.HeaderText = "Municipality"
        Me.Municipality.Name = "Municipality"
        Me.Municipality.ReadOnly = True
        '
        'MunicipalityName
        '
        Me.MunicipalityName.HeaderText = "Municipaltity Name"
        Me.MunicipalityName.Name = "MunicipalityName"
        Me.MunicipalityName.ReadOnly = True
        '
        'ZipCode
        '
        Me.ZipCode.HeaderText = "Zip Code"
        Me.ZipCode.Name = "ZipCode"
        Me.ZipCode.ReadOnly = True
        '
        'ucMasterCustomerShipTo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.MainTab)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucMasterCustomerShipTo"
        Me.Size = New System.Drawing.Size(1024, 768)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MainTab.ResumeLayout(False)
        Me.tbEntry.ResumeLayout(False)
        Me.tbEntry.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbListing.ResumeLayout(False)
        Me.tbListing.PerformLayout()
        CType(Me.GridListing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MainTab As System.Windows.Forms.TabControl
    Friend WithEvents tbEntry As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCompany As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCompany As System.Windows.Forms.ComboBox
    Friend WithEvents txtCustomerShipToCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbListing As System.Windows.Forms.TabPage
    Friend WithEvents lnkRefresh As System.Windows.Forms.LinkLabel
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents cboSelection As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelection As System.Windows.Forms.Label
    Friend WithEvents GridListing As System.Windows.Forms.DataGridView
    Friend WithEvents txtCustomerShiptoName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPhoneNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtContactPerson As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents lnkCustCode As System.Windows.Forms.LinkLabel
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents txtArea As System.Windows.Forms.TextBox
    Friend WithEvents txtDistrict As System.Windows.Forms.TextBox
    Friend WithEvents txtRegion As System.Windows.Forms.TextBox
    Friend WithEvents txtAreaOfCoverage As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cboAreaOfCoverage As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboZipCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboDistrict As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboArea As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents txtCustomerClass As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerGroup As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerGroup As System.Windows.Forms.ComboBox
    Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboDistrictDesc As System.Windows.Forms.ComboBox
    Friend WithEvents cboAreaDesc As System.Windows.Forms.ComboBox
    Friend WithEvents cboRegionDesc As System.Windows.Forms.ComboBox
    Friend WithEvents chkAccountShared As System.Windows.Forms.CheckBox
    Friend WithEvents ChannelsCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerShipToCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerShipToName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerShipToAddress1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerShipToAddress2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRegion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRegionName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CityProvince As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CityProvinceName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Municipality As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MunicipalityName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ZipCode As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
