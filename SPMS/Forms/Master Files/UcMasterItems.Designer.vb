<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcMasterItems
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtProductManagerCode = New System.Windows.Forms.TextBox()
        Me.LinkProductManager = New System.Windows.Forms.LinkLabel()
        Me.txtProductManagerName = New System.Windows.Forms.TextBox()
        Me.txtProductCategoryCode = New System.Windows.Forms.TextBox()
        Me.LinkProductCategory = New System.Windows.Forms.LinkLabel()
        Me.txtProductItemCategory = New System.Windows.Forms.TextBox()
        Me.txtItemGroupCode = New System.Windows.Forms.TextBox()
        Me.txtItemTherapeuticCode = New System.Windows.Forms.TextBox()
        Me.txtItemDivisionCode = New System.Windows.Forms.TextBox()
        Me.LinkItemGroup = New System.Windows.Forms.LinkLabel()
        Me.LinkTherapeutic = New System.Windows.Forms.LinkLabel()
        Me.LinkItemDivision = New System.Windows.Forms.LinkLabel()
        Me.txtMotherCode = New System.Windows.Forms.TextBox()
        Me.lnkMotherCode = New System.Windows.Forms.LinkLabel()
        Me.txtmotherDesc = New System.Windows.Forms.TextBox()
        Me.txtunitment = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtBrandName = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtStart = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtItemGroupName = New System.Windows.Forms.TextBox()
        Me.txtItemClassName = New System.Windows.Forms.TextBox()
        Me.txtItemdivisionName = New System.Windows.Forms.TextBox()
        Me.txtItemSize = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtItemStrength = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtItemForm = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtGenericName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtItemDescription = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnUpdate = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnFind = New System.Windows.Forms.ToolStripButton()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1176, 666)
        Me.Panel1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 83)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1174, 581)
        Me.Panel3.TabIndex = 25
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.txtProductManagerCode)
        Me.GroupBox1.Controls.Add(Me.LinkProductManager)
        Me.GroupBox1.Controls.Add(Me.txtProductManagerName)
        Me.GroupBox1.Controls.Add(Me.txtProductCategoryCode)
        Me.GroupBox1.Controls.Add(Me.LinkProductCategory)
        Me.GroupBox1.Controls.Add(Me.txtProductItemCategory)
        Me.GroupBox1.Controls.Add(Me.txtItemGroupCode)
        Me.GroupBox1.Controls.Add(Me.txtItemTherapeuticCode)
        Me.GroupBox1.Controls.Add(Me.txtItemDivisionCode)
        Me.GroupBox1.Controls.Add(Me.LinkItemGroup)
        Me.GroupBox1.Controls.Add(Me.LinkTherapeutic)
        Me.GroupBox1.Controls.Add(Me.LinkItemDivision)
        Me.GroupBox1.Controls.Add(Me.txtMotherCode)
        Me.GroupBox1.Controls.Add(Me.lnkMotherCode)
        Me.GroupBox1.Controls.Add(Me.txtmotherDesc)
        Me.GroupBox1.Controls.Add(Me.txtunitment)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtBrandName)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.dtEnd)
        Me.GroupBox1.Controls.Add(Me.dtStart)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtItemGroupName)
        Me.GroupBox1.Controls.Add(Me.txtItemClassName)
        Me.GroupBox1.Controls.Add(Me.txtItemdivisionName)
        Me.GroupBox1.Controls.Add(Me.txtItemSize)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtItemStrength)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtItemForm)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtGenericName)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtItemDescription)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtItemCode)
        Me.GroupBox1.Controls.Add(Me.lblItemCode)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(18, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(491, 542)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'txtProductManagerCode
        '
        Me.txtProductManagerCode.BackColor = System.Drawing.Color.White
        Me.txtProductManagerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductManagerCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductManagerCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductManagerCode.Location = New System.Drawing.Point(146, 340)
        Me.txtProductManagerCode.MaxLength = 15
        Me.txtProductManagerCode.Name = "txtProductManagerCode"
        Me.txtProductManagerCode.Size = New System.Drawing.Size(121, 22)
        Me.txtProductManagerCode.TabIndex = 99
        '
        'LinkProductManager
        '
        Me.LinkProductManager.AutoSize = True
        Me.LinkProductManager.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkProductManager.Location = New System.Drawing.Point(35, 344)
        Me.LinkProductManager.Name = "LinkProductManager"
        Me.LinkProductManager.Size = New System.Drawing.Size(105, 15)
        Me.LinkProductManager.TabIndex = 98
        Me.LinkProductManager.TabStop = True
        Me.LinkProductManager.Text = "Product Manager :"
        '
        'txtProductManagerName
        '
        Me.txtProductManagerName.BackColor = System.Drawing.Color.White
        Me.txtProductManagerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductManagerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductManagerName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductManagerName.Location = New System.Drawing.Point(269, 340)
        Me.txtProductManagerName.Name = "txtProductManagerName"
        Me.txtProductManagerName.Size = New System.Drawing.Size(210, 22)
        Me.txtProductManagerName.TabIndex = 97
        '
        'txtProductCategoryCode
        '
        Me.txtProductCategoryCode.BackColor = System.Drawing.Color.White
        Me.txtProductCategoryCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductCategoryCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductCategoryCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductCategoryCode.Location = New System.Drawing.Point(146, 316)
        Me.txtProductCategoryCode.MaxLength = 15
        Me.txtProductCategoryCode.Name = "txtProductCategoryCode"
        Me.txtProductCategoryCode.Size = New System.Drawing.Size(121, 22)
        Me.txtProductCategoryCode.TabIndex = 96
        '
        'LinkProductCategory
        '
        Me.LinkProductCategory.AutoSize = True
        Me.LinkProductCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkProductCategory.Location = New System.Drawing.Point(35, 320)
        Me.LinkProductCategory.Name = "LinkProductCategory"
        Me.LinkProductCategory.Size = New System.Drawing.Size(106, 15)
        Me.LinkProductCategory.TabIndex = 95
        Me.LinkProductCategory.TabStop = True
        Me.LinkProductCategory.Text = "Product Category :"
        '
        'txtProductItemCategory
        '
        Me.txtProductItemCategory.BackColor = System.Drawing.Color.White
        Me.txtProductItemCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductItemCategory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductItemCategory.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductItemCategory.Location = New System.Drawing.Point(269, 316)
        Me.txtProductItemCategory.Name = "txtProductItemCategory"
        Me.txtProductItemCategory.Size = New System.Drawing.Size(210, 22)
        Me.txtProductItemCategory.TabIndex = 94
        '
        'txtItemGroupCode
        '
        Me.txtItemGroupCode.BackColor = System.Drawing.Color.White
        Me.txtItemGroupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemGroupCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemGroupCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemGroupCode.Location = New System.Drawing.Point(146, 283)
        Me.txtItemGroupCode.MaxLength = 15
        Me.txtItemGroupCode.Name = "txtItemGroupCode"
        Me.txtItemGroupCode.Size = New System.Drawing.Size(121, 22)
        Me.txtItemGroupCode.TabIndex = 93
        '
        'txtItemTherapeuticCode
        '
        Me.txtItemTherapeuticCode.BackColor = System.Drawing.Color.White
        Me.txtItemTherapeuticCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemTherapeuticCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemTherapeuticCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemTherapeuticCode.Location = New System.Drawing.Point(146, 259)
        Me.txtItemTherapeuticCode.MaxLength = 15
        Me.txtItemTherapeuticCode.Name = "txtItemTherapeuticCode"
        Me.txtItemTherapeuticCode.Size = New System.Drawing.Size(121, 22)
        Me.txtItemTherapeuticCode.TabIndex = 92
        '
        'txtItemDivisionCode
        '
        Me.txtItemDivisionCode.BackColor = System.Drawing.Color.White
        Me.txtItemDivisionCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemDivisionCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemDivisionCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemDivisionCode.Location = New System.Drawing.Point(146, 234)
        Me.txtItemDivisionCode.MaxLength = 15
        Me.txtItemDivisionCode.Name = "txtItemDivisionCode"
        Me.txtItemDivisionCode.Size = New System.Drawing.Size(121, 22)
        Me.txtItemDivisionCode.TabIndex = 91
        '
        'LinkItemGroup
        '
        Me.LinkItemGroup.AutoSize = True
        Me.LinkItemGroup.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkItemGroup.Location = New System.Drawing.Point(37, 287)
        Me.LinkItemGroup.Name = "LinkItemGroup"
        Me.LinkItemGroup.Size = New System.Drawing.Size(104, 15)
        Me.LinkItemGroup.TabIndex = 90
        Me.LinkItemGroup.TabStop = True
        Me.LinkItemGroup.Text = "Item Group Code :"
        '
        'LinkTherapeutic
        '
        Me.LinkTherapeutic.AutoSize = True
        Me.LinkTherapeutic.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkTherapeutic.Location = New System.Drawing.Point(9, 262)
        Me.LinkTherapeutic.Name = "LinkTherapeutic"
        Me.LinkTherapeutic.Size = New System.Drawing.Size(132, 15)
        Me.LinkTherapeutic.TabIndex = 89
        Me.LinkTherapeutic.TabStop = True
        Me.LinkTherapeutic.Text = "Item Therapeutic Class :"
        '
        'LinkItemDivision
        '
        Me.LinkItemDivision.AutoSize = True
        Me.LinkItemDivision.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkItemDivision.Location = New System.Drawing.Point(28, 237)
        Me.LinkItemDivision.Name = "LinkItemDivision"
        Me.LinkItemDivision.Size = New System.Drawing.Size(113, 15)
        Me.LinkItemDivision.TabIndex = 88
        Me.LinkItemDivision.TabStop = True
        Me.LinkItemDivision.Text = "Item Division Code :"
        '
        'txtMotherCode
        '
        Me.txtMotherCode.BackColor = System.Drawing.Color.White
        Me.txtMotherCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMotherCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMotherCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotherCode.Location = New System.Drawing.Point(146, 210)
        Me.txtMotherCode.MaxLength = 15
        Me.txtMotherCode.Name = "txtMotherCode"
        Me.txtMotherCode.Size = New System.Drawing.Size(121, 22)
        Me.txtMotherCode.TabIndex = 87
        '
        'lnkMotherCode
        '
        Me.lnkMotherCode.AutoSize = True
        Me.lnkMotherCode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkMotherCode.Location = New System.Drawing.Point(58, 213)
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
        Me.txtmotherDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmotherDesc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmotherDesc.Location = New System.Drawing.Point(269, 210)
        Me.txtmotherDesc.Name = "txtmotherDesc"
        Me.txtmotherDesc.Size = New System.Drawing.Size(210, 22)
        Me.txtmotherDesc.TabIndex = 85
        '
        'txtunitment
        '
        Me.txtunitment.BackColor = System.Drawing.Color.White
        Me.txtunitment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtunitment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtunitment.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtunitment.Location = New System.Drawing.Point(146, 162)
        Me.txtunitment.Name = "txtunitment"
        Me.txtunitment.ReadOnly = True
        Me.txtunitment.Size = New System.Drawing.Size(122, 22)
        Me.txtunitment.TabIndex = 82
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(14, 164)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(128, 15)
        Me.Label13.TabIndex = 81
        Me.Label13.Text = "Unit of Measurement  :"
        '
        'txtBrandName
        '
        Me.txtBrandName.BackColor = System.Drawing.Color.White
        Me.txtBrandName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBrandName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBrandName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrandName.Location = New System.Drawing.Point(146, 64)
        Me.txtBrandName.Name = "txtBrandName"
        Me.txtBrandName.ReadOnly = True
        Me.txtBrandName.Size = New System.Drawing.Size(333, 22)
        Me.txtBrandName.TabIndex = 80
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(36, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(106, 15)
        Me.Label12.TabIndex = 79
        Me.Label12.Text = "Item Brand Name :"
        '
        'dtEnd
        '
        Me.dtEnd.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEnd.Location = New System.Drawing.Point(358, 446)
        Me.dtEnd.Name = "dtEnd"
        Me.dtEnd.Size = New System.Drawing.Size(121, 22)
        Me.dtEnd.TabIndex = 78
        '
        'dtStart
        '
        Me.dtStart.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStart.Location = New System.Drawing.Point(358, 421)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(121, 22)
        Me.dtStart.TabIndex = 77
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(239, 448)
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
        Me.Label11.Location = New System.Drawing.Point(234, 424)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(119, 15)
        Me.Label11.TabIndex = 75
        Me.Label11.Text = "Effectivity Start Date :"
        '
        'txtItemGroupName
        '
        Me.txtItemGroupName.BackColor = System.Drawing.Color.White
        Me.txtItemGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemGroupName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemGroupName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemGroupName.Location = New System.Drawing.Point(269, 283)
        Me.txtItemGroupName.Name = "txtItemGroupName"
        Me.txtItemGroupName.Size = New System.Drawing.Size(210, 22)
        Me.txtItemGroupName.TabIndex = 74
        '
        'txtItemClassName
        '
        Me.txtItemClassName.BackColor = System.Drawing.Color.White
        Me.txtItemClassName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemClassName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemClassName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemClassName.Location = New System.Drawing.Point(269, 259)
        Me.txtItemClassName.Name = "txtItemClassName"
        Me.txtItemClassName.Size = New System.Drawing.Size(210, 22)
        Me.txtItemClassName.TabIndex = 73
        '
        'txtItemdivisionName
        '
        Me.txtItemdivisionName.BackColor = System.Drawing.Color.White
        Me.txtItemdivisionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemdivisionName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemdivisionName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemdivisionName.Location = New System.Drawing.Point(269, 234)
        Me.txtItemdivisionName.Name = "txtItemdivisionName"
        Me.txtItemdivisionName.Size = New System.Drawing.Size(210, 22)
        Me.txtItemdivisionName.TabIndex = 72
        '
        'txtItemSize
        '
        Me.txtItemSize.BackColor = System.Drawing.Color.White
        Me.txtItemSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemSize.Location = New System.Drawing.Point(146, 186)
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
        Me.Label7.Location = New System.Drawing.Point(41, 189)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 15)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Quantity Per Box :"
        '
        'txtItemStrength
        '
        Me.txtItemStrength.BackColor = System.Drawing.Color.White
        Me.txtItemStrength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemStrength.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemStrength.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemStrength.Location = New System.Drawing.Point(146, 137)
        Me.txtItemStrength.Name = "txtItemStrength"
        Me.txtItemStrength.ReadOnly = True
        Me.txtItemStrength.Size = New System.Drawing.Size(122, 22)
        Me.txtItemStrength.TabIndex = 50
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(57, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 15)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "Item Strength :"
        '
        'txtItemForm
        '
        Me.txtItemForm.BackColor = System.Drawing.Color.White
        Me.txtItemForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemForm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemForm.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemForm.Location = New System.Drawing.Point(146, 113)
        Me.txtItemForm.Name = "txtItemForm"
        Me.txtItemForm.ReadOnly = True
        Me.txtItemForm.Size = New System.Drawing.Size(122, 22)
        Me.txtItemForm.TabIndex = 48
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(74, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 15)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Item Form :"
        '
        'txtGenericName
        '
        Me.txtGenericName.BackColor = System.Drawing.Color.White
        Me.txtGenericName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGenericName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGenericName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGenericName.Location = New System.Drawing.Point(146, 88)
        Me.txtGenericName.Name = "txtGenericName"
        Me.txtGenericName.ReadOnly = True
        Me.txtGenericName.Size = New System.Drawing.Size(333, 22)
        Me.txtGenericName.TabIndex = 46
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(54, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 15)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Generic Name :"
        '
        'txtItemDescription
        '
        Me.txtItemDescription.BackColor = System.Drawing.Color.White
        Me.txtItemDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemDescription.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemDescription.Location = New System.Drawing.Point(146, 40)
        Me.txtItemDescription.Name = "txtItemDescription"
        Me.txtItemDescription.ReadOnly = True
        Me.txtItemDescription.Size = New System.Drawing.Size(333, 22)
        Me.txtItemDescription.TabIndex = 44
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(42, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 15)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Item Description :"
        '
        'txtItemCode
        '
        Me.txtItemCode.BackColor = System.Drawing.Color.White
        Me.txtItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemCode.Location = New System.Drawing.Point(146, 16)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.ReadOnly = True
        Me.txtItemCode.Size = New System.Drawing.Size(122, 22)
        Me.txtItemCode.TabIndex = 37
        '
        'lblItemCode
        '
        Me.lblItemCode.AutoSize = True
        Me.lblItemCode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemCode.Location = New System.Drawing.Point(74, 20)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Size = New System.Drawing.Size(68, 15)
        Me.lblItemCode.TabIndex = 38
        Me.lblItemCode.Text = "Item Code :"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnUpdate, Me.btnDelete, Me.btnSave, Me.btnFind, Me.btnClear, Me.ToolStripSeparator2, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1174, 25)
        Me.ToolStrip1.TabIndex = 24
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNew
        '
        Me.btnNew.Image = Global.SPMSOPCI.My.Resources.Resources.add1
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(48, 22)
        Me.btnNew.Text = "Add"
        '
        'btnUpdate
        '
        Me.btnUpdate.Image = Global.SPMSOPCI.My.Resources.Resources.page_edit1
        Me.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(47, 22)
        Me.btnUpdate.Text = "Edit"
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
        'btnFind
        '
        Me.btnFind.Image = Global.SPMSOPCI.My.Resources.Resources.File
        Me.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(50, 22)
        Me.btnFind.Text = "Find"
        '
        'btnClear
        '
        Me.btnClear.Image = Global.SPMSOPCI.My.Resources.Resources.close_copy
        Me.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(53, 22)
        Me.btnClear.Text = "Clear"
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1174, 58)
        Me.Panel2.TabIndex = 19
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
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(146, 364)
        Me.TextBox1.MaxLength = 15
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(121, 22)
        Me.TextBox1.TabIndex = 102
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(22, 368)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(118, 15)
        Me.LinkLabel1.TabIndex = 101
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Product Item Group :"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(269, 364)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(210, 22)
        Me.TextBox2.TabIndex = 100
        '
        'UcMasterItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UcMasterItems"
        Me.Size = New System.Drawing.Size(1176, 666)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnUpdate As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnFind As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtProductManagerCode As System.Windows.Forms.TextBox
    Friend WithEvents LinkProductManager As System.Windows.Forms.LinkLabel
    Friend WithEvents txtProductManagerName As System.Windows.Forms.TextBox
    Friend WithEvents txtProductCategoryCode As System.Windows.Forms.TextBox
    Friend WithEvents LinkProductCategory As System.Windows.Forms.LinkLabel
    Friend WithEvents txtProductItemCategory As System.Windows.Forms.TextBox
    Friend WithEvents txtItemGroupCode As System.Windows.Forms.TextBox
    Friend WithEvents txtItemTherapeuticCode As System.Windows.Forms.TextBox
    Friend WithEvents txtItemDivisionCode As System.Windows.Forms.TextBox
    Friend WithEvents LinkItemGroup As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkTherapeutic As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkItemDivision As System.Windows.Forms.LinkLabel
    Friend WithEvents txtMotherCode As System.Windows.Forms.TextBox
    Friend WithEvents lnkMotherCode As System.Windows.Forms.LinkLabel
    Friend WithEvents txtmotherDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtunitment As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtBrandName As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtItemGroupName As System.Windows.Forms.TextBox
    Friend WithEvents txtItemClassName As System.Windows.Forms.TextBox
    Friend WithEvents txtItemdivisionName As System.Windows.Forms.TextBox
    Friend WithEvents txtItemSize As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtItemStrength As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtItemForm As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtGenericName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtItemDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox

End Class
