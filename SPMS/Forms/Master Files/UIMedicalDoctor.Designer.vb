<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIMedicalDoctor
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
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnUpdate = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFind = New System.Windows.Forms.ToolStripButton()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.GrdViewBranch = New Telerik.WinControls.UI.RadGridView()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.btnFindBatch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSaveBranch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnBranchremove = New System.Windows.Forms.ToolStripButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkIsActive = New System.Windows.Forms.CheckBox()
        Me.txtPTRNO = New Telerik.WinControls.UI.RadTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtAddressLine2 = New Telerik.WinControls.UI.RadTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAddressLine1 = New Telerik.WinControls.UI.RadTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSuffix = New Telerik.WinControls.UI.RadTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMiddleName = New Telerik.WinControls.UI.RadTextBox()
        Me.txtFirstName = New Telerik.WinControls.UI.RadTextBox()
        Me.txtLastName = New Telerik.WinControls.UI.RadTextBox()
        Me.txtMDNumber = New Telerik.WinControls.UI.RadTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Office2019LightTheme1 = New Telerik.WinControls.Themes.Office2010BlueTheme
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.GrdViewBranch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrdViewBranch.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.txtPTRNO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddressLine2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddressLine1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSuffix, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMiddleName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFirstName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLastName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMDNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnUpdate, Me.btnSave, Me.ToolStripSeparator4, Me.btnDelete, Me.ToolStripSeparator5, Me.btnFind, Me.btnClear, Me.ToolStripSeparator2, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1343, 25)
        Me.ToolStrip1.TabIndex = 21
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
        Me.btnUpdate.Image = Global.SPMSOPCI.My.Resources.Resources.icons8_pencil_drawing_323
        Me.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(47, 22)
        Me.btnUpdate.Text = "Edit"
        '
        'btnSave
        '
        Me.btnSave.Image = Global.SPMSOPCI.My.Resources.Resources.icons8_save_32_spms3
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(50, 22)
        Me.btnSave.Text = "Save"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnDelete
        '
        Me.btnDelete.Image = Global.SPMSOPCI.My.Resources.Resources.rubbish1
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 22)
        Me.btnDelete.Text = "Delete"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
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
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 83)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1343, 597)
        Me.Panel2.TabIndex = 22
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.ToolStrip2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 284)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1341, 311)
        Me.Panel4.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.GrdViewBranch)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 25)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1339, 284)
        Me.Panel5.TabIndex = 22
        '
        'GrdViewBranch
        '
        Me.GrdViewBranch.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GrdViewBranch.Cursor = System.Windows.Forms.Cursors.Default
        Me.GrdViewBranch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdViewBranch.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.GrdViewBranch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GrdViewBranch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GrdViewBranch.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.GrdViewBranch.MasterTemplate.AllowAddNewRow = False
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.HeaderText = "Branch Code"
        GridViewTextBoxColumn5.Name = "column1"
        GridViewTextBoxColumn5.ReadOnly = True
        GridViewTextBoxColumn5.Width = 200
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.HeaderText = "Branch Name"
        GridViewTextBoxColumn6.Name = "column2"
        GridViewTextBoxColumn6.ReadOnly = True
        GridViewTextBoxColumn6.Width = 255
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.HeaderText = "Branch Address 1"
        GridViewTextBoxColumn7.Name = "column3"
        GridViewTextBoxColumn7.ReadOnly = True
        GridViewTextBoxColumn7.Width = 300
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.HeaderText = "Branch Address 2"
        GridViewTextBoxColumn8.Name = "column4"
        GridViewTextBoxColumn8.ReadOnly = True
        GridViewTextBoxColumn8.Width = 600
        Me.GrdViewBranch.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8})
        Me.GrdViewBranch.MasterTemplate.EnableGrouping = False
        Me.GrdViewBranch.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.GrdViewBranch.Name = "GrdViewBranch"
        Me.GrdViewBranch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GrdViewBranch.Size = New System.Drawing.Size(1337, 282)
        Me.GrdViewBranch.TabIndex = 0
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnFindBatch, Me.ToolStripSeparator1, Me.btnSaveBranch, Me.ToolStripSeparator3, Me.btnBranchremove})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1339, 25)
        Me.ToolStrip2.TabIndex = 21
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btnFindBatch
        '
        Me.btnFindBatch.Image = Global.SPMSOPCI.My.Resources.Resources._12735427001557740369_241
        Me.btnFindBatch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFindBatch.Name = "btnFindBatch"
        Me.btnFindBatch.Size = New System.Drawing.Size(96, 22)
        Me.btnFindBatch.Text = "Find Branch's"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnSaveBranch
        '
        Me.btnSaveBranch.Image = Global.SPMSOPCI.My.Resources.Resources.page_edit1
        Me.btnSaveBranch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSaveBranch.Name = "btnSaveBranch"
        Me.btnSaveBranch.Size = New System.Drawing.Size(96, 22)
        Me.btnSaveBranch.Text = "&Save Branch's"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnBranchremove
        '
        Me.btnBranchremove.Image = Global.SPMSOPCI.My.Resources.Resources.delete1
        Me.btnBranchremove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBranchremove.Name = "btnBranchremove"
        Me.btnBranchremove.Size = New System.Drawing.Size(113, 22)
        Me.btnBranchremove.Text = "Remove Branch's"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.chkIsActive)
        Me.Panel3.Controls.Add(Me.txtPTRNO)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.txtAddressLine2)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.txtAddressLine1)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.txtSuffix)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.txtMiddleName)
        Me.Panel3.Controls.Add(Me.txtFirstName)
        Me.Panel3.Controls.Add(Me.txtLastName)
        Me.Panel3.Controls.Add(Me.txtMDNumber)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1341, 284)
        Me.Panel3.TabIndex = 0
        '
        'chkIsActive
        '
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.Checked = True
        Me.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsActive.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsActive.Location = New System.Drawing.Point(405, 16)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(68, 19)
        Me.chkIsActive.TabIndex = 354
        Me.chkIsActive.Text = "Active"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'txtPTRNO
        '
        Me.txtPTRNO.AutoSize = False
        Me.txtPTRNO.BackColor = System.Drawing.Color.White
        Me.txtPTRNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPTRNO.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPTRNO.Location = New System.Drawing.Point(567, 43)
        Me.txtPTRNO.Multiline = True
        Me.txtPTRNO.Name = "txtPTRNO"
        Me.txtPTRNO.ReadOnly = True
        Me.txtPTRNO.Size = New System.Drawing.Size(266, 24)
        Me.txtPTRNO.TabIndex = 353
        Me.txtPTRNO.ThemeName = "Office2019Light"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(490, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 15)
        Me.Label10.TabIndex = 352
        Me.Label10.Text = "PTR No :"
        '
        'txtAddressLine2
        '
        Me.txtAddressLine2.AutoSize = False
        Me.txtAddressLine2.BackColor = System.Drawing.Color.White
        Me.txtAddressLine2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddressLine2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddressLine2.Location = New System.Drawing.Point(152, 207)
        Me.txtAddressLine2.Multiline = True
        Me.txtAddressLine2.Name = "txtAddressLine2"
        Me.txtAddressLine2.ReadOnly = True
        Me.txtAddressLine2.Size = New System.Drawing.Size(321, 62)
        Me.txtAddressLine2.TabIndex = 351
        Me.txtAddressLine2.ThemeName = "Office2019Light"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(19, 211)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(119, 15)
        Me.Label9.TabIndex = 350
        Me.Label9.Text = "Addrees Line 2 :"
        '
        'txtAddressLine1
        '
        Me.txtAddressLine1.AutoSize = False
        Me.txtAddressLine1.BackColor = System.Drawing.Color.White
        Me.txtAddressLine1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddressLine1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddressLine1.Location = New System.Drawing.Point(152, 151)
        Me.txtAddressLine1.Multiline = True
        Me.txtAddressLine1.Name = "txtAddressLine1"
        Me.txtAddressLine1.ReadOnly = True
        Me.txtAddressLine1.Size = New System.Drawing.Size(321, 53)
        Me.txtAddressLine1.TabIndex = 349
        Me.txtAddressLine1.ThemeName = "Office2019Light"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(19, 154)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 15)
        Me.Label8.TabIndex = 348
        Me.Label8.Text = "Addrees Line 1 :"
        '
        'txtSuffix
        '
        Me.txtSuffix.AutoSize = False
        Me.txtSuffix.BackColor = System.Drawing.Color.White
        Me.txtSuffix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSuffix.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuffix.Location = New System.Drawing.Point(152, 70)
        Me.txtSuffix.Multiline = True
        Me.txtSuffix.Name = "txtSuffix"
        Me.txtSuffix.ReadOnly = True
        Me.txtSuffix.Size = New System.Drawing.Size(148, 24)
        Me.txtSuffix.TabIndex = 347
        Me.txtSuffix.ThemeName = "Office2019Light"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(75, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 15)
        Me.Label7.TabIndex = 346
        Me.Label7.Text = "Suffix :"
        '
        'txtMiddleName
        '
        Me.txtMiddleName.AutoSize = False
        Me.txtMiddleName.BackColor = System.Drawing.Color.White
        Me.txtMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMiddleName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMiddleName.Location = New System.Drawing.Point(152, 124)
        Me.txtMiddleName.Multiline = True
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.ReadOnly = True
        Me.txtMiddleName.Size = New System.Drawing.Size(321, 24)
        Me.txtMiddleName.TabIndex = 345
        Me.txtMiddleName.ThemeName = "Office2019Light"
        '
        'txtFirstName
        '
        Me.txtFirstName.AutoSize = False
        Me.txtFirstName.BackColor = System.Drawing.Color.White
        Me.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFirstName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(152, 97)
        Me.txtFirstName.Multiline = True
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.ReadOnly = True
        Me.txtFirstName.Size = New System.Drawing.Size(321, 24)
        Me.txtFirstName.TabIndex = 344
        Me.txtFirstName.ThemeName = "Office2019Light"
        '
        'txtLastName
        '
        Me.txtLastName.AutoSize = False
        Me.txtLastName.BackColor = System.Drawing.Color.White
        Me.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(152, 43)
        Me.txtLastName.Multiline = True
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.ReadOnly = True
        Me.txtLastName.Size = New System.Drawing.Size(321, 24)
        Me.txtLastName.TabIndex = 343
        Me.txtLastName.ThemeName = "Office2019Light"
        '
        'txtMDNumber
        '
        Me.txtMDNumber.AutoSize = False
        Me.txtMDNumber.BackColor = System.Drawing.Color.White
        Me.txtMDNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMDNumber.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMDNumber.Location = New System.Drawing.Point(152, 16)
        Me.txtMDNumber.Multiline = True
        Me.txtMDNumber.Name = "txtMDNumber"
        Me.txtMDNumber.ReadOnly = True
        Me.txtMDNumber.Size = New System.Drawing.Size(148, 24)
        Me.txtMDNumber.TabIndex = 342
        Me.txtMDNumber.ThemeName = "Office2019Light"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Courier New", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(40, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 15)
        Me.Label3.TabIndex = 338
        Me.Label3.Text = "Doctor Code :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(54, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 15)
        Me.Label4.TabIndex = 339
        Me.Label4.Text = "Last Name :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(47, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 15)
        Me.Label5.TabIndex = 340
        Me.Label5.Text = "First Name :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(40, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 15)
        Me.Label6.TabIndex = 341
        Me.Label6.Text = "Middle Name :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1343, 58)
        Me.Panel1.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Medical Doctor Sales"
        '
        'UIMedicalDoctor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UIMedicalDoctor"
        Me.Size = New System.Drawing.Size(1343, 680)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.GrdViewBranch.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrdViewBranch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.txtPTRNO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAddressLine2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAddressLine1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSuffix, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMiddleName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFirstName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLastName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMDNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnUpdate As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnFind As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Office2019LightTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents chkIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents txtPTRNO As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAddressLine2 As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAddressLine1 As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSuffix As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMiddleName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtFirstName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtLastName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtMDNumber As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents GrdViewBranch As Telerik.WinControls.UI.RadGridView
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnFindBatch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSaveBranch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnBranchremove As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator

End Class
