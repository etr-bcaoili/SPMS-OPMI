<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCMasterZipCodeAssignmentToTerritory
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
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnClose = New System.Windows.Forms.ToolStripButton
        Me.MainTab = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.llUncheck = New System.Windows.Forms.LinkLabel
        Me.llcheck = New System.Windows.Forms.LinkLabel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DGZip = New System.Windows.Forms.DataGridView
        Me.selCheckBox = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.selRegCd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.selRegionDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.selDistrictCD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.selDistrictDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.selAreaCD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.selAreaDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.selZipCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.selZipID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtEnd = New System.Windows.Forms.DateTimePicker
        Me.dtStart = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtdiv = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.dgMuni = New System.Windows.Forms.DataGridView
        Me.llUncheckAll = New System.Windows.Forms.LinkLabel
        Me.llCheckAll = New System.Windows.Forms.LinkLabel
        Me.cmbMunicipalityDesc = New System.Windows.Forms.ComboBox
        Me.cmbDistrictDesc = New System.Windows.Forms.ComboBox
        Me.cmbRegionDesc = New System.Windows.Forms.ComboBox
        Me.cmbMunicipality = New System.Windows.Forms.ComboBox
        Me.cmbDistrict = New System.Windows.Forms.ComboBox
        Me.cmbRegion = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbAreaDesc = New System.Windows.Forms.ComboBox
        Me.cmbArea = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbzipCode = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btnFilter = New System.Windows.Forms.Button
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.cmbfilter = New System.Windows.Forms.ComboBox
        Me.lblSelection = New System.Windows.Forms.Label
        Me.GridListing = New System.Windows.Forms.DataGridView
        Me.colZipCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colZipMappingID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCoverageCD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCoverageName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAreaCd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAreaDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRegCd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRegDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDistrictCd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDistrictDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colStartDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEndDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.selSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.selMunicipality = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.selMunicipalityDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1.SuspendLayout()
        Me.MainTab.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGZip, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgMuni, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.GridListing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.btnEdit, Me.btnDelete, Me.btnSave, Me.ToolStripSeparator1, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(844, 25)
        Me.ToolStrip1.TabIndex = 26
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnClose
        '
        Me.btnClose.Image = Global.SPMSOPCI.My.Resources.Resources.cancel
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(55, 22)
        Me.btnClose.Text = "Close"
        '
        'MainTab
        '
        Me.MainTab.Controls.Add(Me.TabPage1)
        Me.MainTab.Controls.Add(Me.TabPage2)
        Me.MainTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTab.Location = New System.Drawing.Point(0, 83)
        Me.MainTab.Name = "MainTab"
        Me.MainTab.SelectedIndex = 0
        Me.MainTab.Size = New System.Drawing.Size(844, 580)
        Me.MainTab.TabIndex = 27
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.llUncheck)
        Me.TabPage1.Controls.Add(Me.llcheck)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(836, 554)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Entry"
        '
        'llUncheck
        '
        Me.llUncheck.AutoSize = True
        Me.llUncheck.Dock = System.Windows.Forms.DockStyle.Top
        Me.llUncheck.Location = New System.Drawing.Point(57, 211)
        Me.llUncheck.Name = "llUncheck"
        Me.llUncheck.Size = New System.Drawing.Size(67, 13)
        Me.llUncheck.TabIndex = 4
        Me.llUncheck.TabStop = True
        Me.llUncheck.Text = "Uncheck All"
        '
        'llcheck
        '
        Me.llcheck.AutoSize = True
        Me.llcheck.Dock = System.Windows.Forms.DockStyle.Left
        Me.llcheck.Location = New System.Drawing.Point(3, 211)
        Me.llcheck.Name = "llcheck"
        Me.llcheck.Size = New System.Drawing.Size(54, 13)
        Me.llcheck.TabIndex = 3
        Me.llcheck.TabStop = True
        Me.llcheck.Text = "Check All"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.DGZip)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(3, 211)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(830, 340)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Zip Code Information :"
        '
        'DGZip
        '
        Me.DGZip.AllowUserToAddRows = False
        Me.DGZip.AllowUserToDeleteRows = False
        Me.DGZip.AllowUserToResizeColumns = False
        Me.DGZip.AllowUserToResizeRows = False
        Me.DGZip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGZip.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selCheckBox, Me.selRegCd, Me.selRegionDesc, Me.selDistrictCD, Me.selDistrictDescription, Me.selAreaCD, Me.selAreaDescription, Me.selZipCode, Me.selZipID})
        Me.DGZip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGZip.Location = New System.Drawing.Point(3, 18)
        Me.DGZip.Name = "DGZip"
        Me.DGZip.Size = New System.Drawing.Size(824, 319)
        Me.DGZip.TabIndex = 0
        '
        'selCheckBox
        '
        Me.selCheckBox.HeaderText = ""
        Me.selCheckBox.Name = "selCheckBox"
        Me.selCheckBox.Width = 35
        '
        'selRegCd
        '
        Me.selRegCd.HeaderText = "Region Code"
        Me.selRegCd.Name = "selRegCd"
        Me.selRegCd.ReadOnly = True
        '
        'selRegionDesc
        '
        Me.selRegionDesc.HeaderText = "Region Description"
        Me.selRegionDesc.Name = "selRegionDesc"
        Me.selRegionDesc.ReadOnly = True
        Me.selRegionDesc.Width = 255
        '
        'selDistrictCD
        '
        Me.selDistrictCD.HeaderText = "Province Code"
        Me.selDistrictCD.Name = "selDistrictCD"
        Me.selDistrictCD.ReadOnly = True
        Me.selDistrictCD.Width = 130
        '
        'selDistrictDescription
        '
        Me.selDistrictDescription.HeaderText = "Province Description"
        Me.selDistrictDescription.Name = "selDistrictDescription"
        Me.selDistrictDescription.ReadOnly = True
        Me.selDistrictDescription.Width = 255
        '
        'selAreaCD
        '
        Me.selAreaCD.HeaderText = "Municipality Code"
        Me.selAreaCD.Name = "selAreaCD"
        Me.selAreaCD.ReadOnly = True
        Me.selAreaCD.Width = 150
        '
        'selAreaDescription
        '
        Me.selAreaDescription.HeaderText = "Municipality Description"
        Me.selAreaDescription.Name = "selAreaDescription"
        Me.selAreaDescription.ReadOnly = True
        Me.selAreaDescription.Width = 255
        '
        'selZipCode
        '
        Me.selZipCode.HeaderText = "ZipCode"
        Me.selZipCode.Name = "selZipCode"
        Me.selZipCode.ReadOnly = True
        '
        'selZipID
        '
        Me.selZipID.HeaderText = "ZipID"
        Me.selZipID.Name = "selZipID"
        Me.selZipID.ReadOnly = True
        Me.selZipID.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.dtEnd)
        Me.GroupBox1.Controls.Add(Me.dtStart)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtdiv)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dgMuni)
        Me.GroupBox1.Controls.Add(Me.llUncheckAll)
        Me.GroupBox1.Controls.Add(Me.llCheckAll)
        Me.GroupBox1.Controls.Add(Me.cmbMunicipalityDesc)
        Me.GroupBox1.Controls.Add(Me.cmbDistrictDesc)
        Me.GroupBox1.Controls.Add(Me.cmbRegionDesc)
        Me.GroupBox1.Controls.Add(Me.cmbMunicipality)
        Me.GroupBox1.Controls.Add(Me.cmbDistrict)
        Me.GroupBox1.Controls.Add(Me.cmbRegion)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbAreaDesc)
        Me.GroupBox1.Controls.Add(Me.cmbArea)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbzipCode)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(830, 208)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Zip Code Selection :"
        '
        'dtEnd
        '
        Me.dtEnd.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEnd.Location = New System.Drawing.Point(692, 181)
        Me.dtEnd.Name = "dtEnd"
        Me.dtEnd.Size = New System.Drawing.Size(132, 22)
        Me.dtEnd.TabIndex = 94
        '
        'dtStart
        '
        Me.dtStart.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStart.Location = New System.Drawing.Point(692, 151)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(132, 22)
        Me.dtStart.TabIndex = 93
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(558, 184)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 13)
        Me.Label8.TabIndex = 92
        Me.Label8.Text = "Effectivity End Date :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(558, 158)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 13)
        Me.Label11.TabIndex = 91
        Me.Label11.Text = "Effectivity Start Date :"
        '
        'txtdiv
        '
        Me.txtdiv.BackColor = System.Drawing.Color.White
        Me.txtdiv.Location = New System.Drawing.Point(139, 152)
        Me.txtdiv.Name = "txtdiv"
        Me.txtdiv.ReadOnly = True
        Me.txtdiv.Size = New System.Drawing.Size(123, 22)
        Me.txtdiv.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(45, 161)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Division :"
        '
        'dgMuni
        '
        Me.dgMuni.AllowUserToAddRows = False
        Me.dgMuni.AllowUserToDeleteRows = False
        Me.dgMuni.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgMuni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMuni.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selSelect, Me.selMunicipality, Me.selMunicipalityDesc})
        Me.dgMuni.Location = New System.Drawing.Point(484, 47)
        Me.dgMuni.Name = "dgMuni"
        Me.dgMuni.Size = New System.Drawing.Size(340, 99)
        Me.dgMuni.TabIndex = 13
        '
        'llUncheckAll
        '
        Me.llUncheckAll.AutoSize = True
        Me.llUncheckAll.Location = New System.Drawing.Point(544, 24)
        Me.llUncheckAll.Name = "llUncheckAll"
        Me.llUncheckAll.Size = New System.Drawing.Size(67, 13)
        Me.llUncheckAll.TabIndex = 12
        Me.llUncheckAll.TabStop = True
        Me.llUncheckAll.Text = "Uncheck All"
        '
        'llCheckAll
        '
        Me.llCheckAll.AutoSize = True
        Me.llCheckAll.Location = New System.Drawing.Point(484, 24)
        Me.llCheckAll.Name = "llCheckAll"
        Me.llCheckAll.Size = New System.Drawing.Size(54, 13)
        Me.llCheckAll.TabIndex = 11
        Me.llCheckAll.TabStop = True
        Me.llCheckAll.Text = "Check All"
        '
        'cmbMunicipalityDesc
        '
        Me.cmbMunicipalityDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMunicipalityDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMunicipalityDesc.FormattingEnabled = True
        Me.cmbMunicipalityDesc.Location = New System.Drawing.Point(268, 74)
        Me.cmbMunicipalityDesc.Name = "cmbMunicipalityDesc"
        Me.cmbMunicipalityDesc.Size = New System.Drawing.Size(210, 21)
        Me.cmbMunicipalityDesc.TabIndex = 5
        '
        'cmbDistrictDesc
        '
        Me.cmbDistrictDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbDistrictDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDistrictDesc.FormattingEnabled = True
        Me.cmbDistrictDesc.Location = New System.Drawing.Point(268, 47)
        Me.cmbDistrictDesc.Name = "cmbDistrictDesc"
        Me.cmbDistrictDesc.Size = New System.Drawing.Size(210, 21)
        Me.cmbDistrictDesc.TabIndex = 3
        '
        'cmbRegionDesc
        '
        Me.cmbRegionDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbRegionDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRegionDesc.FormattingEnabled = True
        Me.cmbRegionDesc.Location = New System.Drawing.Point(268, 21)
        Me.cmbRegionDesc.Name = "cmbRegionDesc"
        Me.cmbRegionDesc.Size = New System.Drawing.Size(210, 21)
        Me.cmbRegionDesc.TabIndex = 1
        '
        'cmbMunicipality
        '
        Me.cmbMunicipality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMunicipality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMunicipality.FormattingEnabled = True
        Me.cmbMunicipality.Location = New System.Drawing.Point(138, 74)
        Me.cmbMunicipality.Name = "cmbMunicipality"
        Me.cmbMunicipality.Size = New System.Drawing.Size(124, 21)
        Me.cmbMunicipality.TabIndex = 4
        '
        'cmbDistrict
        '
        Me.cmbDistrict.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbDistrict.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDistrict.FormattingEnabled = True
        Me.cmbDistrict.Location = New System.Drawing.Point(139, 47)
        Me.cmbDistrict.Name = "cmbDistrict"
        Me.cmbDistrict.Size = New System.Drawing.Size(123, 21)
        Me.cmbDistrict.TabIndex = 2
        '
        'cmbRegion
        '
        Me.cmbRegion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbRegion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRegion.FormattingEnabled = True
        Me.cmbRegion.Location = New System.Drawing.Point(138, 21)
        Me.cmbRegion.Name = "cmbRegion"
        Me.cmbRegion.Size = New System.Drawing.Size(124, 21)
        Me.cmbRegion.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(45, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Municipalty :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(45, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Province :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(45, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Region :"
        '
        'cmbAreaDesc
        '
        Me.cmbAreaDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAreaDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAreaDesc.FormattingEnabled = True
        Me.cmbAreaDesc.Location = New System.Drawing.Point(268, 127)
        Me.cmbAreaDesc.Name = "cmbAreaDesc"
        Me.cmbAreaDesc.Size = New System.Drawing.Size(210, 21)
        Me.cmbAreaDesc.TabIndex = 8
        '
        'cmbArea
        '
        Me.cmbArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Location = New System.Drawing.Point(138, 127)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(124, 21)
        Me.cmbArea.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Assign Territory :"
        '
        'cmbzipCode
        '
        Me.cmbzipCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbzipCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbzipCode.FormattingEnabled = True
        Me.cmbzipCode.Location = New System.Drawing.Point(138, 100)
        Me.cmbzipCode.Name = "cmbzipCode"
        Me.cmbzipCode.Size = New System.Drawing.Size(124, 21)
        Me.cmbzipCode.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Zip Code :"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(139, 153)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(123, 22)
        Me.DateTimePicker1.TabIndex = 16
        Me.DateTimePicker1.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.btnFilter)
        Me.TabPage2.Controls.Add(Me.txtFilter)
        Me.TabPage2.Controls.Add(Me.cmbfilter)
        Me.TabPage2.Controls.Add(Me.lblSelection)
        Me.TabPage2.Controls.Add(Me.GridListing)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(836, 554)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Listing"
        '
        'btnFilter
        '
        Me.btnFilter.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.Location = New System.Drawing.Point(471, 5)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(82, 22)
        Me.btnFilter.TabIndex = 9
        Me.btnFilter.Text = "Filter "
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'txtFilter
        '
        Me.txtFilter.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilter.Location = New System.Drawing.Point(258, 7)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(207, 22)
        Me.txtFilter.TabIndex = 8
        '
        'cmbfilter
        '
        Me.cmbfilter.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbfilter.FormattingEnabled = True
        Me.cmbfilter.Items.AddRange(New Object() {"All", "Region Code", "City/Province Code", "Municipality / Location Code", "Municipality / Location Name", "ZipCode"})
        Me.cmbfilter.Location = New System.Drawing.Point(69, 7)
        Me.cmbfilter.Name = "cmbfilter"
        Me.cmbfilter.Size = New System.Drawing.Size(183, 21)
        Me.cmbfilter.TabIndex = 7
        '
        'lblSelection
        '
        Me.lblSelection.AutoSize = True
        Me.lblSelection.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelection.Location = New System.Drawing.Point(8, 15)
        Me.lblSelection.Name = "lblSelection"
        Me.lblSelection.Size = New System.Drawing.Size(60, 13)
        Me.lblSelection.TabIndex = 6
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
        Me.GridListing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colZipCode, Me.colZipMappingID, Me.colCoverageCD, Me.colCoverageName, Me.colAreaCd, Me.colAreaDesc, Me.colRegCd, Me.colRegDesc, Me.colDistrictCd, Me.colDistrictDesc, Me.colStartDate, Me.colEndDate})
        Me.GridListing.Location = New System.Drawing.Point(8, 35)
        Me.GridListing.Name = "GridListing"
        Me.GridListing.Size = New System.Drawing.Size(817, 402)
        Me.GridListing.TabIndex = 5
        '
        'colZipCode
        '
        Me.colZipCode.HeaderText = "ZipCode"
        Me.colZipCode.Name = "colZipCode"
        Me.colZipCode.ReadOnly = True
        '
        'colZipMappingID
        '
        Me.colZipMappingID.HeaderText = "Zip MappingID"
        Me.colZipMappingID.Name = "colZipMappingID"
        Me.colZipMappingID.ReadOnly = True
        Me.colZipMappingID.Visible = False
        '
        'colCoverageCD
        '
        Me.colCoverageCD.HeaderText = "Territory Code"
        Me.colCoverageCD.Name = "colCoverageCD"
        Me.colCoverageCD.ReadOnly = True
        Me.colCoverageCD.Width = 150
        '
        'colCoverageName
        '
        Me.colCoverageName.HeaderText = "Territory Name"
        Me.colCoverageName.Name = "colCoverageName"
        Me.colCoverageName.ReadOnly = True
        Me.colCoverageName.Width = 255
        '
        'colAreaCd
        '
        Me.colAreaCd.HeaderText = "Municipality Code"
        Me.colAreaCd.Name = "colAreaCd"
        Me.colAreaCd.ReadOnly = True
        '
        'colAreaDesc
        '
        Me.colAreaDesc.HeaderText = "Municipality Name"
        Me.colAreaDesc.Name = "colAreaDesc"
        Me.colAreaDesc.ReadOnly = True
        Me.colAreaDesc.Width = 250
        '
        'colRegCd
        '
        Me.colRegCd.HeaderText = "Region Code"
        Me.colRegCd.Name = "colRegCd"
        Me.colRegCd.ReadOnly = True
        '
        'colRegDesc
        '
        Me.colRegDesc.HeaderText = "Region Description"
        Me.colRegDesc.Name = "colRegDesc"
        Me.colRegDesc.ReadOnly = True
        Me.colRegDesc.Width = 250
        '
        'colDistrictCd
        '
        Me.colDistrictCd.HeaderText = "Province Code"
        Me.colDistrictCd.Name = "colDistrictCd"
        Me.colDistrictCd.ReadOnly = True
        '
        'colDistrictDesc
        '
        Me.colDistrictDesc.HeaderText = "Province Description"
        Me.colDistrictDesc.Name = "colDistrictDesc"
        Me.colDistrictDesc.ReadOnly = True
        Me.colDistrictDesc.Width = 250
        '
        'colStartDate
        '
        Me.colStartDate.HeaderText = "EffectivityStartDate"
        Me.colStartDate.Name = "colStartDate"
        Me.colStartDate.ReadOnly = True
        '
        'colEndDate
        '
        Me.colEndDate.HeaderText = "EffecitivtyEndDate"
        Me.colEndDate.Name = "colEndDate"
        Me.colEndDate.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(844, 58)
        Me.Panel1.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Zip Code Assignment to Territory"
        '
        'selSelect
        '
        Me.selSelect.HeaderText = ""
        Me.selSelect.Name = "selSelect"
        Me.selSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.selSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.selSelect.Width = 35
        '
        'selMunicipality
        '
        Me.selMunicipality.HeaderText = "Municipality Code"
        Me.selMunicipality.Name = "selMunicipality"
        Me.selMunicipality.ReadOnly = True
        Me.selMunicipality.Width = 150
        '
        'selMunicipalityDesc
        '
        Me.selMunicipalityDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.selMunicipalityDesc.HeaderText = "Municipaltity Desc"
        Me.selMunicipalityDesc.Name = "selMunicipalityDesc"
        Me.selMunicipalityDesc.ReadOnly = True
        '
        'UCMasterZipCodeAssignmentToTerritory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.MainTab)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UCMasterZipCodeAssignmentToTerritory"
        Me.Size = New System.Drawing.Size(844, 663)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MainTab.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DGZip, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgMuni, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.GridListing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MainTab As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents cmbfilter As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelection As System.Windows.Forms.Label
    Friend WithEvents GridListing As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DGZip As System.Windows.Forms.DataGridView
    Friend WithEvents cmbzipCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbAreaDesc As System.Windows.Forms.ComboBox
    Friend WithEvents cmbArea As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbMunicipality As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDistrict As System.Windows.Forms.ComboBox
    Friend WithEvents cmbRegion As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbMunicipalityDesc As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDistrictDesc As System.Windows.Forms.ComboBox
    Friend WithEvents cmbRegionDesc As System.Windows.Forms.ComboBox
    Friend WithEvents selCheckBox As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents selRegCd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selRegionDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selDistrictCD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selDistrictDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selAreaCD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selAreaDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selZipCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selZipID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents llUncheck As System.Windows.Forms.LinkLabel
    Friend WithEvents llcheck As System.Windows.Forms.LinkLabel
    Friend WithEvents llUncheckAll As System.Windows.Forms.LinkLabel
    Friend WithEvents llCheckAll As System.Windows.Forms.LinkLabel
    Friend WithEvents dgMuni As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtdiv As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents colZipCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colZipMappingID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCoverageCD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCoverageName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAreaCd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAreaDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRegCd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRegDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDistrictCd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDistrictDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStartDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEndDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents selMunicipality As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selMunicipalityDesc As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
