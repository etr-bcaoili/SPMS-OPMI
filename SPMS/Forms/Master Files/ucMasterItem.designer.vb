<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCMasterItem
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtMotherCode = New System.Windows.Forms.TextBox()
        Me.lnkMotherCode = New System.Windows.Forms.LinkLabel()
        Me.txtmotherDesc = New System.Windows.Forms.TextBox()
        Me.txtunitment = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtBrandName2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtStart = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtItemGroupName = New System.Windows.Forms.TextBox()
        Me.txtItemClassName = New System.Windows.Forms.TextBox()
        Me.txtItemdivisionName = New System.Windows.Forms.TextBox()
        Me.cboItemDivision = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboItemClass = New System.Windows.Forms.ComboBox()
        Me.cboItemGroup = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtItemSize = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtItemStrength = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtItemForm = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtGenericName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtItemBrand = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtItemCode1 = New System.Windows.Forms.TextBox()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.tbListing = New System.Windows.Forms.TabPage()
        Me.lnkRefresh = New System.Windows.Forms.LinkLabel()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.cboSelection = New System.Windows.Forms.ComboBox()
        Me.lblSelection = New System.Windows.Forms.Label()
        Me.dgItemList = New System.Windows.Forms.DataGridView()
        Me.colItemDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemBrandName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStartDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEndDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MainTab.SuspendLayout()
        Me.tbEntry.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbListing.SuspendLayout()
        CType(Me.dgItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.btnEdit, Me.btnDelete, Me.btnSave, Me.ToolStripSeparator2, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(982, 25)
        Me.ToolStrip1.TabIndex = 19
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
        Me.Panel1.Size = New System.Drawing.Size(982, 58)
        Me.Panel1.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(15, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Item Creation"
        '
        'MainTab
        '
        Me.MainTab.Controls.Add(Me.tbEntry)
        Me.MainTab.Controls.Add(Me.tbListing)
        Me.MainTab.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainTab.Location = New System.Drawing.Point(5, 87)
        Me.MainTab.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainTab.Name = "MainTab"
        Me.MainTab.SelectedIndex = 0
        Me.MainTab.Size = New System.Drawing.Size(977, 518)
        Me.MainTab.TabIndex = 20
        '
        'tbEntry
        '
        Me.tbEntry.BackColor = System.Drawing.SystemColors.Control
        Me.tbEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbEntry.Controls.Add(Me.GroupBox1)
        Me.tbEntry.Location = New System.Drawing.Point(4, 23)
        Me.tbEntry.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbEntry.Name = "tbEntry"
        Me.tbEntry.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbEntry.Size = New System.Drawing.Size(969, 491)
        Me.tbEntry.TabIndex = 0
        Me.tbEntry.Text = "Entry"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMotherCode)
        Me.GroupBox1.Controls.Add(Me.lnkMotherCode)
        Me.GroupBox1.Controls.Add(Me.txtmotherDesc)
        Me.GroupBox1.Controls.Add(Me.txtunitment)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtBrandName2)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.dtEnd)
        Me.GroupBox1.Controls.Add(Me.dtStart)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtItemGroupName)
        Me.GroupBox1.Controls.Add(Me.txtItemClassName)
        Me.GroupBox1.Controls.Add(Me.txtItemdivisionName)
        Me.GroupBox1.Controls.Add(Me.cboItemDivision)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cboItemClass)
        Me.GroupBox1.Controls.Add(Me.cboItemGroup)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtItemSize)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtItemStrength)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtItemForm)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtGenericName)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtItemBrand)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtItemCode1)
        Me.GroupBox1.Controls.Add(Me.lblItemCode)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(458, 442)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtMotherCode
        '
        Me.txtMotherCode.BackColor = System.Drawing.Color.White
        Me.txtMotherCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMotherCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotherCode.Location = New System.Drawing.Point(141, 210)
        Me.txtMotherCode.MaxLength = 15
        Me.txtMotherCode.Name = "txtMotherCode"
        Me.txtMotherCode.ReadOnly = True
        Me.txtMotherCode.Size = New System.Drawing.Size(121, 22)
        Me.txtMotherCode.TabIndex = 87
        '
        'lnkMotherCode
        '
        Me.lnkMotherCode.AutoSize = True
        Me.lnkMotherCode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkMotherCode.Location = New System.Drawing.Point(53, 214)
        Me.lnkMotherCode.Name = "lnkMotherCode"
        Me.lnkMotherCode.Size = New System.Drawing.Size(83, 15)
        Me.lnkMotherCode.TabIndex = 86
        Me.lnkMotherCode.TabStop = True
        Me.lnkMotherCode.Text = "Mother Code :"
        '
        'txtmotherDesc
        '
        Me.txtmotherDesc.BackColor = System.Drawing.Color.White
        Me.txtmotherDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtmotherDesc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmotherDesc.Location = New System.Drawing.Point(264, 210)
        Me.txtmotherDesc.Name = "txtmotherDesc"
        Me.txtmotherDesc.ReadOnly = True
        Me.txtmotherDesc.Size = New System.Drawing.Size(169, 22)
        Me.txtmotherDesc.TabIndex = 85
        '
        'txtunitment
        '
        Me.txtunitment.BackColor = System.Drawing.Color.White
        Me.txtunitment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtunitment.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtunitment.Location = New System.Drawing.Point(141, 162)
        Me.txtunitment.Name = "txtunitment"
        Me.txtunitment.ReadOnly = True
        Me.txtunitment.Size = New System.Drawing.Size(122, 22)
        Me.txtunitment.TabIndex = 82
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(9, 164)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(128, 15)
        Me.Label13.TabIndex = 81
        Me.Label13.Text = "Unit of Measurement  :"
        '
        'txtBrandName2
        '
        Me.txtBrandName2.BackColor = System.Drawing.Color.White
        Me.txtBrandName2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBrandName2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrandName2.Location = New System.Drawing.Point(141, 64)
        Me.txtBrandName2.Name = "txtBrandName2"
        Me.txtBrandName2.ReadOnly = True
        Me.txtBrandName2.Size = New System.Drawing.Size(292, 22)
        Me.txtBrandName2.TabIndex = 80
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(31, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(106, 15)
        Me.Label12.TabIndex = 79
        Me.Label12.Text = "Item Brand Name :"
        '
        'dtEnd
        '
        Me.dtEnd.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEnd.Location = New System.Drawing.Point(140, 335)
        Me.dtEnd.Name = "dtEnd"
        Me.dtEnd.Size = New System.Drawing.Size(121, 22)
        Me.dtEnd.TabIndex = 78
        '
        'dtStart
        '
        Me.dtStart.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStart.Location = New System.Drawing.Point(141, 309)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(121, 22)
        Me.dtStart.TabIndex = 77
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 337)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 15)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Effectivity End Date :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(17, 312)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(119, 15)
        Me.Label11.TabIndex = 75
        Me.Label11.Text = "Effectivity Start Date :"
        '
        'txtItemGroupName
        '
        Me.txtItemGroupName.BackColor = System.Drawing.Color.White
        Me.txtItemGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemGroupName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemGroupName.Location = New System.Drawing.Point(214, 283)
        Me.txtItemGroupName.Name = "txtItemGroupName"
        Me.txtItemGroupName.ReadOnly = True
        Me.txtItemGroupName.Size = New System.Drawing.Size(219, 22)
        Me.txtItemGroupName.TabIndex = 74
        '
        'txtItemClassName
        '
        Me.txtItemClassName.BackColor = System.Drawing.Color.White
        Me.txtItemClassName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemClassName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemClassName.Location = New System.Drawing.Point(214, 259)
        Me.txtItemClassName.Name = "txtItemClassName"
        Me.txtItemClassName.ReadOnly = True
        Me.txtItemClassName.Size = New System.Drawing.Size(219, 22)
        Me.txtItemClassName.TabIndex = 73
        '
        'txtItemdivisionName
        '
        Me.txtItemdivisionName.BackColor = System.Drawing.Color.White
        Me.txtItemdivisionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemdivisionName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemdivisionName.Location = New System.Drawing.Point(214, 234)
        Me.txtItemdivisionName.Name = "txtItemdivisionName"
        Me.txtItemdivisionName.ReadOnly = True
        Me.txtItemdivisionName.Size = New System.Drawing.Size(219, 22)
        Me.txtItemdivisionName.TabIndex = 72
        '
        'cboItemDivision
        '
        Me.cboItemDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemDivision.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboItemDivision.FormattingEnabled = True
        Me.cboItemDivision.Location = New System.Drawing.Point(140, 234)
        Me.cboItemDivision.Name = "cboItemDivision"
        Me.cboItemDivision.Size = New System.Drawing.Size(72, 21)
        Me.cboItemDivision.TabIndex = 71
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(23, 237)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 15)
        Me.Label8.TabIndex = 70
        Me.Label8.Text = "Item Division Code :"
        '
        'cboItemClass
        '
        Me.cboItemClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemClass.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(140, 259)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(72, 21)
        Me.cboItemClass.TabIndex = 69
        '
        'cboItemGroup
        '
        Me.cboItemGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemGroup.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboItemGroup.FormattingEnabled = True
        Me.cboItemGroup.Location = New System.Drawing.Point(140, 284)
        Me.cboItemGroup.Name = "cboItemGroup"
        Me.cboItemGroup.Size = New System.Drawing.Size(72, 21)
        Me.cboItemGroup.TabIndex = 68
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(32, 287)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 15)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "Item Group Code :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 262)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(133, 15)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "Item Therapeutic Class :"
        '
        'txtItemSize
        '
        Me.txtItemSize.BackColor = System.Drawing.Color.White
        Me.txtItemSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemSize.Location = New System.Drawing.Point(141, 186)
        Me.txtItemSize.MaxLength = 3
        Me.txtItemSize.Name = "txtItemSize"
        Me.txtItemSize.ReadOnly = True
        Me.txtItemSize.Size = New System.Drawing.Size(122, 22)
        Me.txtItemSize.TabIndex = 52
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(36, 189)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 15)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Quantity Per Box :"
        '
        'txtItemStrength
        '
        Me.txtItemStrength.BackColor = System.Drawing.Color.White
        Me.txtItemStrength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemStrength.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemStrength.Location = New System.Drawing.Point(141, 137)
        Me.txtItemStrength.Name = "txtItemStrength"
        Me.txtItemStrength.ReadOnly = True
        Me.txtItemStrength.Size = New System.Drawing.Size(122, 22)
        Me.txtItemStrength.TabIndex = 50
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(52, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 15)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "Item Strength :"
        '
        'txtItemForm
        '
        Me.txtItemForm.BackColor = System.Drawing.Color.White
        Me.txtItemForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemForm.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemForm.Location = New System.Drawing.Point(141, 113)
        Me.txtItemForm.Name = "txtItemForm"
        Me.txtItemForm.ReadOnly = True
        Me.txtItemForm.Size = New System.Drawing.Size(122, 22)
        Me.txtItemForm.TabIndex = 48
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(69, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 15)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Item Form :"
        '
        'txtGenericName
        '
        Me.txtGenericName.BackColor = System.Drawing.Color.White
        Me.txtGenericName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGenericName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGenericName.Location = New System.Drawing.Point(141, 88)
        Me.txtGenericName.Name = "txtGenericName"
        Me.txtGenericName.ReadOnly = True
        Me.txtGenericName.Size = New System.Drawing.Size(292, 22)
        Me.txtGenericName.TabIndex = 46
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(49, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 15)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Generic Name :"
        '
        'txtItemBrand
        '
        Me.txtItemBrand.BackColor = System.Drawing.Color.White
        Me.txtItemBrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemBrand.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemBrand.Location = New System.Drawing.Point(141, 40)
        Me.txtItemBrand.Name = "txtItemBrand"
        Me.txtItemBrand.ReadOnly = True
        Me.txtItemBrand.Size = New System.Drawing.Size(292, 22)
        Me.txtItemBrand.TabIndex = 44
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(37, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 15)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Item Description :"
        '
        'txtItemCode1
        '
        Me.txtItemCode1.BackColor = System.Drawing.Color.White
        Me.txtItemCode1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemCode1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemCode1.Location = New System.Drawing.Point(141, 16)
        Me.txtItemCode1.Name = "txtItemCode1"
        Me.txtItemCode1.ReadOnly = True
        Me.txtItemCode1.Size = New System.Drawing.Size(122, 22)
        Me.txtItemCode1.TabIndex = 37
        '
        'lblItemCode
        '
        Me.lblItemCode.AutoSize = True
        Me.lblItemCode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemCode.Location = New System.Drawing.Point(69, 20)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Size = New System.Drawing.Size(68, 15)
        Me.lblItemCode.TabIndex = 38
        Me.lblItemCode.Text = "Item Code :"
        '
        'tbListing
        '
        Me.tbListing.BackColor = System.Drawing.SystemColors.Control
        Me.tbListing.Controls.Add(Me.lnkRefresh)
        Me.tbListing.Controls.Add(Me.btnFilter)
        Me.tbListing.Controls.Add(Me.txtFilter)
        Me.tbListing.Controls.Add(Me.cboSelection)
        Me.tbListing.Controls.Add(Me.lblSelection)
        Me.tbListing.Controls.Add(Me.dgItemList)
        Me.tbListing.Location = New System.Drawing.Point(4, 23)
        Me.tbListing.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbListing.Name = "tbListing"
        Me.tbListing.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbListing.Size = New System.Drawing.Size(969, 491)
        Me.tbListing.TabIndex = 1
        Me.tbListing.Text = "Listing"
        '
        'lnkRefresh
        '
        Me.lnkRefresh.AutoSize = True
        Me.lnkRefresh.Location = New System.Drawing.Point(876, 22)
        Me.lnkRefresh.Name = "lnkRefresh"
        Me.lnkRefresh.Size = New System.Drawing.Size(69, 14)
        Me.lnkRefresh.TabIndex = 5
        Me.lnkRefresh.TabStop = True
        Me.lnkRefresh.Text = "Refresh Grid"
        '
        'btnFilter
        '
        Me.btnFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilter.Location = New System.Drawing.Point(432, 4)
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
        Me.txtFilter.Size = New System.Drawing.Size(207, 20)
        Me.txtFilter.TabIndex = 3
        '
        'cboSelection
        '
        Me.cboSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSelection.FormattingEnabled = True
        Me.cboSelection.Location = New System.Drawing.Point(67, 6)
        Me.cboSelection.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboSelection.Name = "cboSelection"
        Me.cboSelection.Size = New System.Drawing.Size(146, 22)
        Me.cboSelection.TabIndex = 2
        '
        'lblSelection
        '
        Me.lblSelection.AutoSize = True
        Me.lblSelection.Location = New System.Drawing.Point(6, 16)
        Me.lblSelection.Name = "lblSelection"
        Me.lblSelection.Size = New System.Drawing.Size(57, 14)
        Me.lblSelection.TabIndex = 1
        Me.lblSelection.Text = "Selection :"
        '
        'dgItemList
        '
        Me.dgItemList.AllowUserToAddRows = False
        Me.dgItemList.AllowUserToDeleteRows = False
        Me.dgItemList.AllowUserToOrderColumns = True
        Me.dgItemList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemDescription, Me.colItemBrandName, Me.colItemCode, Me.colStartDate, Me.colEndDate})
        Me.dgItemList.Location = New System.Drawing.Point(6, 40)
        Me.dgItemList.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgItemList.Name = "dgItemList"
        Me.dgItemList.Size = New System.Drawing.Size(960, 447)
        Me.dgItemList.TabIndex = 0
        '
        'colItemDescription
        '
        Me.colItemDescription.HeaderText = "Generic Name"
        Me.colItemDescription.Name = "colItemDescription"
        Me.colItemDescription.ReadOnly = True
        Me.colItemDescription.Width = 350
        '
        'colItemBrandName
        '
        Me.colItemBrandName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colItemBrandName.HeaderText = "Brand Name"
        Me.colItemBrandName.Name = "colItemBrandName"
        Me.colItemBrandName.ReadOnly = True
        '
        'colItemCode
        '
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Width = 200
        '
        'colStartDate
        '
        Me.colStartDate.HeaderText = "Effectivity Start Date"
        Me.colStartDate.Name = "colStartDate"
        Me.colStartDate.ReadOnly = True
        Me.colStartDate.Visible = False
        Me.colStartDate.Width = 150
        '
        'colEndDate
        '
        Me.colEndDate.HeaderText = "Effectivity End Date"
        Me.colEndDate.Name = "colEndDate"
        Me.colEndDate.ReadOnly = True
        Me.colEndDate.Visible = False
        Me.colEndDate.Width = 150
        '
        'UCMasterItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.MainTab)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UCMasterItem"
        Me.Size = New System.Drawing.Size(982, 611)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MainTab.ResumeLayout(False)
        Me.tbEntry.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbListing.ResumeLayout(False)
        Me.tbListing.PerformLayout()
        CType(Me.dgItemList, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents cboItemGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtItemSize As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtItemStrength As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtItemForm As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtGenericName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtItemBrand As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtItemCode1 As System.Windows.Forms.TextBox
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents tbListing As System.Windows.Forms.TabPage
    Friend WithEvents lnkRefresh As System.Windows.Forms.LinkLabel
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents cboSelection As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelection As System.Windows.Forms.Label
    Friend WithEvents dgItemList As System.Windows.Forms.DataGridView
    Friend WithEvents cboItemDivision As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtItemGroupName As System.Windows.Forms.TextBox
    Friend WithEvents txtItemClassName As System.Windows.Forms.TextBox
    Friend WithEvents txtItemdivisionName As System.Windows.Forms.TextBox
    Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents colItemDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemBrandName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStartDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEndDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtBrandName2 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtunitment As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtmotherDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtMotherCode As System.Windows.Forms.TextBox
    Friend WithEvents lnkMotherCode As System.Windows.Forms.LinkLabel

End Class
