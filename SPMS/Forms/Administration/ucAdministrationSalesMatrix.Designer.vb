<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCAdministrationSalesMatrix
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MainTab = New System.Windows.Forms.TabControl()
        Me.tbEntry = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtConfigtypename = New System.Windows.Forms.TextBox()
        Me.cmbConfigtype = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chkIsActive = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtItemGroup = New System.Windows.Forms.TextBox()
        Me.cmbItemGroup = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtStart = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmbrepDesc = New System.Windows.Forms.ComboBox()
        Me.txtREp = New System.Windows.Forms.TextBox()
        Me.cmbRep = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbCoverageName = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTerritory = New System.Windows.Forms.TextBox()
        Me.txtCoverageName = New System.Windows.Forms.TextBox()
        Me.cmbcoverage = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ItemDivision = New System.Windows.Forms.GroupBox()
        Me.txtDivision = New System.Windows.Forms.TextBox()
        Me.cmbDivision = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbdistrict = New System.Windows.Forms.ComboBox()
        Me.cmbregion = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRegion = New System.Windows.Forms.TextBox()
        Me.txtDistrict = New System.Windows.Forms.TextBox()
        Me.txtTeamDescription = New System.Windows.Forms.TextBox()
        Me.cmbTeam = New System.Windows.Forms.ComboBox()
        Me.lblTeam = New System.Windows.Forms.Label()
        Me.tbListing = New System.Windows.Forms.TabPage()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.cmbfilter = New System.Windows.Forms.ComboBox()
        Me.lblSelection = New System.Windows.Forms.Label()
        Me.GridListing = New System.Windows.Forms.DataGridView()
        Me.colmrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTerritory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTerritoryName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemDivision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemDivisionName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMRName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColConfigTypeCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStartDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEndDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MainTab.SuspendLayout()
        Me.tbEntry.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ItemDivision.SuspendLayout()
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
        Me.ToolStrip1.Size = New System.Drawing.Size(991, 25)
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
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(991, 58)
        Me.Panel1.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(15, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(184, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "MR Territory Assignment"
        '
        'MainTab
        '
        Me.MainTab.Controls.Add(Me.tbEntry)
        Me.MainTab.Controls.Add(Me.tbListing)
        Me.MainTab.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainTab.Location = New System.Drawing.Point(3, 91)
        Me.MainTab.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainTab.Name = "MainTab"
        Me.MainTab.SelectedIndex = 0
        Me.MainTab.Size = New System.Drawing.Size(988, 528)
        Me.MainTab.TabIndex = 18
        '
        'tbEntry
        '
        Me.tbEntry.BackColor = System.Drawing.SystemColors.Control
        Me.tbEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbEntry.Controls.Add(Me.GroupBox5)
        Me.tbEntry.Controls.Add(Me.chkIsActive)
        Me.tbEntry.Controls.Add(Me.txtTerritory)
        Me.tbEntry.Controls.Add(Me.GroupBox4)
        Me.tbEntry.Controls.Add(Me.dtEnd)
        Me.tbEntry.Controls.Add(Me.dtStart)
        Me.tbEntry.Controls.Add(Me.Label2)
        Me.tbEntry.Controls.Add(Me.Label8)
        Me.tbEntry.Controls.Add(Me.cmbTeam)
        Me.tbEntry.Controls.Add(Me.lblTeam)
        Me.tbEntry.Controls.Add(Me.txtTeamDescription)
        Me.tbEntry.Controls.Add(Me.Label11)
        Me.tbEntry.Controls.Add(Me.GroupBox3)
        Me.tbEntry.Controls.Add(Me.GroupBox2)
        Me.tbEntry.Controls.Add(Me.ItemDivision)
        Me.tbEntry.Controls.Add(Me.GroupBox1)
        Me.tbEntry.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEntry.Location = New System.Drawing.Point(4, 23)
        Me.tbEntry.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbEntry.Name = "tbEntry"
        Me.tbEntry.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbEntry.Size = New System.Drawing.Size(980, 501)
        Me.tbEntry.TabIndex = 0
        Me.tbEntry.Text = "Entry"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtConfigtypename)
        Me.GroupBox5.Controls.Add(Me.cmbConfigtype)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(8, 325)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(635, 54)
        Me.GroupBox5.TabIndex = 93
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Configuration Type"
        '
        'txtConfigtypename
        '
        Me.txtConfigtypename.BackColor = System.Drawing.Color.White
        Me.txtConfigtypename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConfigtypename.Location = New System.Drawing.Point(266, 20)
        Me.txtConfigtypename.Name = "txtConfigtypename"
        Me.txtConfigtypename.ReadOnly = True
        Me.txtConfigtypename.Size = New System.Drawing.Size(326, 22)
        Me.txtConfigtypename.TabIndex = 2
        '
        'cmbConfigtype
        '
        Me.cmbConfigtype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbConfigtype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbConfigtype.FormattingEnabled = True
        Me.cmbConfigtype.Location = New System.Drawing.Point(142, 21)
        Me.cmbConfigtype.Name = "cmbConfigtype"
        Me.cmbConfigtype.Size = New System.Drawing.Size(118, 21)
        Me.cmbConfigtype.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "ConfigTypeCode :"
        '
        'chkIsActive
        '
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.Checked = True
        Me.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsActive.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsActive.Location = New System.Drawing.Point(573, 7)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(67, 17)
        Me.chkIsActive.TabIndex = 92
        Me.chkIsActive.Text = "Is Active"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtItemGroup)
        Me.GroupBox4.Controls.Add(Me.cmbItemGroup)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(649, 245)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(635, 47)
        Me.GroupBox4.TabIndex = 91
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Item Group"
        Me.GroupBox4.Visible = False
        '
        'txtItemGroup
        '
        Me.txtItemGroup.BackColor = System.Drawing.Color.White
        Me.txtItemGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemGroup.Location = New System.Drawing.Point(261, 16)
        Me.txtItemGroup.Name = "txtItemGroup"
        Me.txtItemGroup.ReadOnly = True
        Me.txtItemGroup.Size = New System.Drawing.Size(326, 22)
        Me.txtItemGroup.TabIndex = 2
        Me.txtItemGroup.Visible = False
        '
        'cmbItemGroup
        '
        Me.cmbItemGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbItemGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbItemGroup.FormattingEnabled = True
        Me.cmbItemGroup.Location = New System.Drawing.Point(137, 18)
        Me.cmbItemGroup.Name = "cmbItemGroup"
        Me.cmbItemGroup.Size = New System.Drawing.Size(118, 21)
        Me.cmbItemGroup.TabIndex = 1
        Me.cmbItemGroup.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Item Group  : "
        Me.Label9.Visible = False
        '
        'dtEnd
        '
        Me.dtEnd.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEnd.Location = New System.Drawing.Point(548, 428)
        Me.dtEnd.Name = "dtEnd"
        Me.dtEnd.Size = New System.Drawing.Size(91, 22)
        Me.dtEnd.TabIndex = 90
        '
        'dtStart
        '
        Me.dtStart.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStart.Location = New System.Drawing.Point(548, 398)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(91, 22)
        Me.dtStart.TabIndex = 89
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(414, 431)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 13)
        Me.Label8.TabIndex = 88
        Me.Label8.Text = "Effectivity End Date :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(414, 405)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 13)
        Me.Label11.TabIndex = 87
        Me.Label11.Text = "Effectivity Start Date :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmbrepDesc)
        Me.GroupBox3.Controls.Add(Me.txtREp)
        Me.GroupBox3.Controls.Add(Me.cmbRep)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(13, 22)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(630, 69)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Medical Rep"
        '
        'cmbrepDesc
        '
        Me.cmbrepDesc.FormattingEnabled = True
        Me.cmbrepDesc.Location = New System.Drawing.Point(261, 32)
        Me.cmbrepDesc.Name = "cmbrepDesc"
        Me.cmbrepDesc.Size = New System.Drawing.Size(321, 21)
        Me.cmbrepDesc.TabIndex = 4
        '
        'txtREp
        '
        Me.txtREp.BackColor = System.Drawing.Color.White
        Me.txtREp.Location = New System.Drawing.Point(590, 32)
        Me.txtREp.Name = "txtREp"
        Me.txtREp.ReadOnly = True
        Me.txtREp.Size = New System.Drawing.Size(23, 22)
        Me.txtREp.TabIndex = 3
        Me.txtREp.Visible = False
        '
        'cmbRep
        '
        Me.cmbRep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbRep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRep.FormattingEnabled = True
        Me.cmbRep.Location = New System.Drawing.Point(134, 31)
        Me.cmbRep.Name = "cmbRep"
        Me.cmbRep.Size = New System.Drawing.Size(121, 21)
        Me.cmbRep.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Medical Rep  :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbCoverageName)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtCoverageName)
        Me.GroupBox2.Controls.Add(Me.cmbcoverage)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(8, 259)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(635, 60)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Territory"
        '
        'cmbCoverageName
        '
        Me.cmbCoverageName.FormattingEnabled = True
        Me.cmbCoverageName.Location = New System.Drawing.Point(266, 23)
        Me.cmbCoverageName.Name = "cmbCoverageName"
        Me.cmbCoverageName.Size = New System.Drawing.Size(323, 21)
        Me.cmbCoverageName.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Territory Code  :"
        '
        'txtTerritory
        '
        Me.txtTerritory.BackColor = System.Drawing.Color.White
        Me.txtTerritory.Location = New System.Drawing.Point(749, 306)
        Me.txtTerritory.Name = "txtTerritory"
        Me.txtTerritory.ReadOnly = True
        Me.txtTerritory.Size = New System.Drawing.Size(120, 22)
        Me.txtTerritory.TabIndex = 3
        Me.txtTerritory.Visible = False
        '
        'txtCoverageName
        '
        Me.txtCoverageName.BackColor = System.Drawing.Color.White
        Me.txtCoverageName.Location = New System.Drawing.Point(598, 22)
        Me.txtCoverageName.Name = "txtCoverageName"
        Me.txtCoverageName.ReadOnly = True
        Me.txtCoverageName.Size = New System.Drawing.Size(21, 22)
        Me.txtCoverageName.TabIndex = 2
        Me.txtCoverageName.Visible = False
        '
        'cmbcoverage
        '
        Me.cmbcoverage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcoverage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcoverage.FormattingEnabled = True
        Me.cmbcoverage.Location = New System.Drawing.Point(137, 22)
        Me.cmbcoverage.Name = "cmbcoverage"
        Me.cmbcoverage.Size = New System.Drawing.Size(120, 21)
        Me.cmbcoverage.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(653, 309)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Territory Name  :"
        Me.Label2.Visible = False
        '
        'ItemDivision
        '
        Me.ItemDivision.Controls.Add(Me.txtDivision)
        Me.ItemDivision.Controls.Add(Me.cmbDivision)
        Me.ItemDivision.Controls.Add(Me.Label1)
        Me.ItemDivision.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemDivision.Location = New System.Drawing.Point(10, 197)
        Me.ItemDivision.Name = "ItemDivision"
        Me.ItemDivision.Size = New System.Drawing.Size(633, 56)
        Me.ItemDivision.TabIndex = 2
        Me.ItemDivision.TabStop = False
        Me.ItemDivision.Text = "Item Division"
        '
        'txtDivision
        '
        Me.txtDivision.BackColor = System.Drawing.Color.White
        Me.txtDivision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDivision.Location = New System.Drawing.Point(264, 23)
        Me.txtDivision.Name = "txtDivision"
        Me.txtDivision.ReadOnly = True
        Me.txtDivision.Size = New System.Drawing.Size(326, 22)
        Me.txtDivision.TabIndex = 2
        '
        'cmbDivision
        '
        Me.cmbDivision.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbDivision.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDivision.FormattingEnabled = True
        Me.cmbDivision.Location = New System.Drawing.Point(137, 23)
        Me.cmbDivision.Name = "cmbDivision"
        Me.cmbDivision.Size = New System.Drawing.Size(118, 21)
        Me.cmbDivision.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item Division  : "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbdistrict)
        Me.GroupBox1.Controls.Add(Me.cmbregion)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtRegion)
        Me.GroupBox1.Controls.Add(Me.txtDistrict)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 97)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(631, 94)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Territorial Configuration"
        '
        'cmbdistrict
        '
        Me.cmbdistrict.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbdistrict.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbdistrict.FormattingEnabled = True
        Me.cmbdistrict.Location = New System.Drawing.Point(135, 58)
        Me.cmbdistrict.Name = "cmbdistrict"
        Me.cmbdistrict.Size = New System.Drawing.Size(120, 21)
        Me.cmbdistrict.TabIndex = 8
        '
        'cmbregion
        '
        Me.cmbregion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbregion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbregion.FormattingEnabled = True
        Me.cmbregion.Location = New System.Drawing.Point(135, 28)
        Me.cmbregion.Name = "cmbregion"
        Me.cmbregion.Size = New System.Drawing.Size(120, 21)
        Me.cmbregion.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Sales Division :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "District :"
        '
        'txtRegion
        '
        Me.txtRegion.BackColor = System.Drawing.Color.White
        Me.txtRegion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRegion.Location = New System.Drawing.Point(262, 29)
        Me.txtRegion.Name = "txtRegion"
        Me.txtRegion.ReadOnly = True
        Me.txtRegion.Size = New System.Drawing.Size(321, 22)
        Me.txtRegion.TabIndex = 4
        '
        'txtDistrict
        '
        Me.txtDistrict.BackColor = System.Drawing.Color.White
        Me.txtDistrict.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDistrict.Location = New System.Drawing.Point(262, 57)
        Me.txtDistrict.Name = "txtDistrict"
        Me.txtDistrict.ReadOnly = True
        Me.txtDistrict.Size = New System.Drawing.Size(321, 22)
        Me.txtDistrict.TabIndex = 3
        '
        'txtTeamDescription
        '
        Me.txtTeamDescription.BackColor = System.Drawing.Color.White
        Me.txtTeamDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTeamDescription.Location = New System.Drawing.Point(649, 139)
        Me.txtTeamDescription.Name = "txtTeamDescription"
        Me.txtTeamDescription.ReadOnly = True
        Me.txtTeamDescription.Size = New System.Drawing.Size(321, 22)
        Me.txtTeamDescription.TabIndex = 2
        Me.txtTeamDescription.Visible = False
        '
        'cmbTeam
        '
        Me.cmbTeam.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbTeam.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTeam.FormattingEnabled = True
        Me.cmbTeam.Location = New System.Drawing.Point(691, 112)
        Me.cmbTeam.Name = "cmbTeam"
        Me.cmbTeam.Size = New System.Drawing.Size(121, 21)
        Me.cmbTeam.TabIndex = 1
        Me.cmbTeam.Visible = False
        '
        'lblTeam
        '
        Me.lblTeam.AutoSize = True
        Me.lblTeam.Location = New System.Drawing.Point(646, 120)
        Me.lblTeam.Name = "lblTeam"
        Me.lblTeam.Size = New System.Drawing.Size(39, 13)
        Me.lblTeam.TabIndex = 0
        Me.lblTeam.Text = "Team :"
        Me.lblTeam.Visible = False
        '
        'tbListing
        '
        Me.tbListing.BackColor = System.Drawing.SystemColors.Control
        Me.tbListing.Controls.Add(Me.btnFilter)
        Me.tbListing.Controls.Add(Me.txtFilter)
        Me.tbListing.Controls.Add(Me.cmbfilter)
        Me.tbListing.Controls.Add(Me.lblSelection)
        Me.tbListing.Controls.Add(Me.GridListing)
        Me.tbListing.Location = New System.Drawing.Point(4, 23)
        Me.tbListing.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbListing.Name = "tbListing"
        Me.tbListing.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbListing.Size = New System.Drawing.Size(980, 501)
        Me.tbListing.TabIndex = 1
        Me.tbListing.Text = "Listing"
        '
        'btnFilter
        '
        Me.btnFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilter.Location = New System.Drawing.Point(439, 10)
        Me.btnFilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(79, 24)
        Me.btnFilter.TabIndex = 4
        Me.btnFilter.Text = "Filter "
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'txtFilter
        '
        Me.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFilter.Location = New System.Drawing.Point(224, 12)
        Me.txtFilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(207, 20)
        Me.txtFilter.TabIndex = 3
        '
        'cmbfilter
        '
        Me.cmbfilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbfilter.FormattingEnabled = True
        Me.cmbfilter.Items.AddRange(New Object() {"All", "Territory Code", "Territory Name", "Item Division", "Employee Code", "MR Name"})
        Me.cmbfilter.Location = New System.Drawing.Point(72, 10)
        Me.cmbfilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbfilter.Name = "cmbfilter"
        Me.cmbfilter.Size = New System.Drawing.Size(146, 22)
        Me.cmbfilter.TabIndex = 2
        '
        'lblSelection
        '
        Me.lblSelection.AutoSize = True
        Me.lblSelection.Location = New System.Drawing.Point(9, 18)
        Me.lblSelection.Name = "lblSelection"
        Me.lblSelection.Size = New System.Drawing.Size(57, 14)
        Me.lblSelection.TabIndex = 1
        Me.lblSelection.Text = "Selection :"
        '
        'GridListing
        '
        Me.GridListing.AllowUserToAddRows = False
        Me.GridListing.AllowUserToDeleteRows = False
        Me.GridListing.AllowUserToOrderColumns = True
        Me.GridListing.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridListing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridListing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colmrid, Me.colTerritory, Me.colTerritoryName, Me.colItemDivision, Me.colItemDivisionName, Me.colMR, Me.colMRName, Me.ColConfigTypeCode, Me.colStartDate, Me.colEndDate, Me.colStatus})
        Me.GridListing.Location = New System.Drawing.Point(6, 40)
        Me.GridListing.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridListing.Name = "GridListing"
        Me.GridListing.Size = New System.Drawing.Size(968, 442)
        Me.GridListing.TabIndex = 0
        '
        'colmrid
        '
        Me.colmrid.HeaderText = "ID"
        Me.colmrid.Name = "colmrid"
        Me.colmrid.ReadOnly = True
        Me.colmrid.Visible = False
        '
        'colTerritory
        '
        Me.colTerritory.HeaderText = "Territory Code"
        Me.colTerritory.Name = "colTerritory"
        Me.colTerritory.ReadOnly = True
        Me.colTerritory.Width = 120
        '
        'colTerritoryName
        '
        Me.colTerritoryName.HeaderText = "Territory Name"
        Me.colTerritoryName.Name = "colTerritoryName"
        Me.colTerritoryName.ReadOnly = True
        Me.colTerritoryName.Width = 400
        '
        'colItemDivision
        '
        Me.colItemDivision.HeaderText = "Item Division Code"
        Me.colItemDivision.Name = "colItemDivision"
        Me.colItemDivision.ReadOnly = True
        Me.colItemDivision.Width = 130
        '
        'colItemDivisionName
        '
        Me.colItemDivisionName.HeaderText = "Item Division Name"
        Me.colItemDivisionName.Name = "colItemDivisionName"
        Me.colItemDivisionName.Width = 130
        '
        'colMR
        '
        Me.colMR.HeaderText = "Employee Code"
        Me.colMR.Name = "colMR"
        Me.colMR.ReadOnly = True
        Me.colMR.Width = 120
        '
        'colMRName
        '
        Me.colMRName.HeaderText = "MR Name"
        Me.colMRName.Name = "colMRName"
        Me.colMRName.Width = 150
        '
        'ColConfigTypeCode
        '
        Me.ColConfigTypeCode.HeaderText = "ConfigTypeCode"
        Me.ColConfigTypeCode.Name = "ColConfigTypeCode"
        Me.ColConfigTypeCode.Width = 120
        '
        'colStartDate
        '
        Me.colStartDate.HeaderText = "Effectivity Start Date"
        Me.colStartDate.Name = "colStartDate"
        Me.colStartDate.ReadOnly = True
        Me.colStartDate.Width = 150
        '
        'colEndDate
        '
        Me.colEndDate.HeaderText = "Effectivity End Date"
        Me.colEndDate.Name = "colEndDate"
        Me.colEndDate.ReadOnly = True
        Me.colEndDate.Width = 150
        '
        'colStatus
        '
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        '
        'UCAdministrationSalesMatrix
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.MainTab)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "UCAdministrationSalesMatrix"
        Me.Size = New System.Drawing.Size(991, 614)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MainTab.ResumeLayout(False)
        Me.tbEntry.ResumeLayout(False)
        Me.tbEntry.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ItemDivision.ResumeLayout(False)
        Me.ItemDivision.PerformLayout()
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents MainTab As System.Windows.Forms.TabControl
    Friend WithEvents tbEntry As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtREp As System.Windows.Forms.TextBox
    Friend WithEvents cmbRep As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTerritory As System.Windows.Forms.TextBox
    Friend WithEvents txtCoverageName As System.Windows.Forms.TextBox
    Friend WithEvents cmbcoverage As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ItemDivision As System.Windows.Forms.GroupBox
    Friend WithEvents txtDivision As System.Windows.Forms.TextBox
    Friend WithEvents cmbDivision As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRegion As System.Windows.Forms.TextBox
    Friend WithEvents txtDistrict As System.Windows.Forms.TextBox
    Friend WithEvents txtTeamDescription As System.Windows.Forms.TextBox
    Friend WithEvents cmbTeam As System.Windows.Forms.ComboBox
    Friend WithEvents lblTeam As System.Windows.Forms.Label
    Friend WithEvents tbListing As System.Windows.Forms.TabPage
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents cmbfilter As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelection As System.Windows.Forms.Label
    Friend WithEvents GridListing As System.Windows.Forms.DataGridView
    Friend WithEvents cmbdistrict As System.Windows.Forms.ComboBox
    Friend WithEvents cmbregion As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtItemGroup As System.Windows.Forms.TextBox
    Friend WithEvents cmbItemGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbrepDesc As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCoverageName As System.Windows.Forms.ComboBox
    Friend WithEvents chkIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtConfigtypename As System.Windows.Forms.TextBox
    Friend WithEvents cmbConfigtype As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents colmrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTerritory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTerritoryName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemDivision As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemDivisionName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMRName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColConfigTypeCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStartDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEndDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
