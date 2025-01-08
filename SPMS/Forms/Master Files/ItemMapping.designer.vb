<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemMapping
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
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbEntry = New System.Windows.Forms.TabPage
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.txtcount = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboedit = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtmathercode = New System.Windows.Forms.TextBox
        Me.cbomthecode = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgtails = New System.Windows.Forms.DataGridView
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colItemcodediv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colItemnamediv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colitemname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.groups = New System.Windows.Forms.GroupBox
        Me.txtItemdivcode = New System.Windows.Forms.TextBox
        Me.chkIsActive = New System.Windows.Forms.CheckBox
        Me.txtdivname = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtitemname = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtItemCode = New System.Windows.Forms.TextBox
        Me.lblItemCode = New System.Windows.Forms.Label
        Me.MainTab = New System.Windows.Forms.TabControl
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tbEntry.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgtails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groups.SuspendLayout()
        Me.MainTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.btnEdit, Me.btnDelete, Me.btnSave, Me.ToolStripSeparator2, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(932, 25)
        Me.ToolStrip1.TabIndex = 20
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
        Me.Panel1.Size = New System.Drawing.Size(932, 58)
        Me.Panel1.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(15, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Item Mapping"
        '
        'tbEntry
        '
        Me.tbEntry.BackColor = System.Drawing.Color.White
        Me.tbEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbEntry.Controls.Add(Me.Label6)
        Me.tbEntry.Controls.Add(Me.Button4)
        Me.tbEntry.Controls.Add(Me.Button3)
        Me.tbEntry.Controls.Add(Me.txtcount)
        Me.tbEntry.Controls.Add(Me.GroupBox2)
        Me.tbEntry.Controls.Add(Me.dgtails)
        Me.tbEntry.Controls.Add(Me.groups)
        Me.tbEntry.Location = New System.Drawing.Point(4, 23)
        Me.tbEntry.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbEntry.Name = "tbEntry"
        Me.tbEntry.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbEntry.Size = New System.Drawing.Size(911, 500)
        Me.tbEntry.TabIndex = 0
        Me.tbEntry.Text = "Entry"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(738, 444)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 14)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Total Count :"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(870, 464)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(32, 29)
        Me.Button4.TabIndex = 17
        Me.Button4.Text = ">|"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(832, 464)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(32, 29)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "|<"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtcount
        '
        Me.txtcount.Location = New System.Drawing.Point(811, 438)
        Me.txtcount.Name = "txtcount"
        Me.txtcount.Size = New System.Drawing.Size(91, 20)
        Me.txtcount.TabIndex = 11
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboedit)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtmathercode)
        Me.GroupBox2.Controls.Add(Me.cbomthecode)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(896, 76)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'cboedit
        '
        Me.cboedit.FormattingEnabled = True
        Me.cboedit.Location = New System.Drawing.Point(98, 19)
        Me.cboedit.Name = "cboedit"
        Me.cboedit.Size = New System.Drawing.Size(171, 22)
        Me.cboedit.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 14)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Item Division :"
        '
        'txtmathercode
        '
        Me.txtmathercode.Location = New System.Drawing.Point(96, 48)
        Me.txtmathercode.Name = "txtmathercode"
        Me.txtmathercode.Size = New System.Drawing.Size(217, 20)
        Me.txtmathercode.TabIndex = 2
        '
        'cbomthecode
        '
        Me.cbomthecode.FormattingEnabled = True
        Me.cbomthecode.Location = New System.Drawing.Point(98, 18)
        Me.cbomthecode.Name = "cbomthecode"
        Me.cbomthecode.Size = New System.Drawing.Size(171, 22)
        Me.cbomthecode.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Mother Code :"
        '
        'dgtails
        '
        Me.dgtails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgtails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemCode, Me.colItemcodediv, Me.colItemnamediv, Me.colitemname})
        Me.dgtails.Location = New System.Drawing.Point(15, 89)
        Me.dgtails.Name = "dgtails"
        Me.dgtails.ReadOnly = True
        Me.dgtails.Size = New System.Drawing.Size(887, 194)
        Me.dgtails.TabIndex = 10
        '
        'colItemCode
        '
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Width = 200
        '
        'colItemcodediv
        '
        Me.colItemcodediv.HeaderText = "Item Code Division "
        Me.colItemcodediv.Name = "colItemcodediv"
        Me.colItemcodediv.ReadOnly = True
        Me.colItemcodediv.Width = 200
        '
        'colItemnamediv
        '
        Me.colItemnamediv.HeaderText = "Item Division Name"
        Me.colItemnamediv.Name = "colItemnamediv"
        Me.colItemnamediv.ReadOnly = True
        Me.colItemnamediv.Width = 240
        '
        'colitemname
        '
        Me.colitemname.HeaderText = "Item Name "
        Me.colitemname.Name = "colitemname"
        Me.colitemname.ReadOnly = True
        Me.colitemname.Width = 200
        '
        'groups
        '
        Me.groups.BackColor = System.Drawing.Color.White
        Me.groups.Controls.Add(Me.txtItemdivcode)
        Me.groups.Controls.Add(Me.chkIsActive)
        Me.groups.Controls.Add(Me.txtdivname)
        Me.groups.Controls.Add(Me.Label12)
        Me.groups.Controls.Add(Me.Label1)
        Me.groups.Controls.Add(Me.txtitemname)
        Me.groups.Controls.Add(Me.Label4)
        Me.groups.Controls.Add(Me.Label3)
        Me.groups.Controls.Add(Me.txtItemCode)
        Me.groups.Controls.Add(Me.lblItemCode)
        Me.groups.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groups.Location = New System.Drawing.Point(15, 289)
        Me.groups.Name = "groups"
        Me.groups.Size = New System.Drawing.Size(887, 133)
        Me.groups.TabIndex = 9
        Me.groups.TabStop = False
        '
        'txtItemdivcode
        '
        Me.txtItemdivcode.Location = New System.Drawing.Point(158, 48)
        Me.txtItemdivcode.Name = "txtItemdivcode"
        Me.txtItemdivcode.Size = New System.Drawing.Size(210, 22)
        Me.txtItemdivcode.TabIndex = 98
        '
        'chkIsActive
        '
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.Checked = True
        Me.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsActive.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsActive.Location = New System.Drawing.Point(301, 17)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(67, 17)
        Me.chkIsActive.TabIndex = 97
        Me.chkIsActive.Text = "Is Active"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'txtdivname
        '
        Me.txtdivname.BackColor = System.Drawing.Color.White
        Me.txtdivname.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdivname.Location = New System.Drawing.Point(158, 73)
        Me.txtdivname.Name = "txtdivname"
        Me.txtdivname.Size = New System.Drawing.Size(210, 22)
        Me.txtdivname.TabIndex = 96
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(111, 13)
        Me.Label12.TabIndex = 95
        Me.Label12.Text = "Item Division Name :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 89
        '
        'txtitemname
        '
        Me.txtitemname.BackColor = System.Drawing.Color.White
        Me.txtitemname.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtitemname.Location = New System.Drawing.Point(158, 98)
        Me.txtitemname.Name = "txtitemname"
        Me.txtitemname.Size = New System.Drawing.Size(210, 22)
        Me.txtitemname.TabIndex = 88
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 87
        Me.Label4.Text = "Item  Name :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "Item Division  :"
        '
        'txtItemCode
        '
        Me.txtItemCode.BackColor = System.Drawing.Color.White
        Me.txtItemCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemCode.Location = New System.Drawing.Point(158, 21)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(122, 22)
        Me.txtItemCode.TabIndex = 83
        '
        'lblItemCode
        '
        Me.lblItemCode.AutoSize = True
        Me.lblItemCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemCode.Location = New System.Drawing.Point(8, 21)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Size = New System.Drawing.Size(65, 13)
        Me.lblItemCode.TabIndex = 84
        Me.lblItemCode.Text = "Item Code :"
        '
        'MainTab
        '
        Me.MainTab.Controls.Add(Me.tbEntry)
        Me.MainTab.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainTab.Location = New System.Drawing.Point(0, 87)
        Me.MainTab.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainTab.Name = "MainTab"
        Me.MainTab.SelectedIndex = 0
        Me.MainTab.Size = New System.Drawing.Size(919, 527)
        Me.MainTab.TabIndex = 21
        '
        'ItemMapping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.MainTab)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Name = "ItemMapping"
        Me.Size = New System.Drawing.Size(932, 618)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tbEntry.ResumeLayout(False)
        Me.tbEntry.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgtails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groups.ResumeLayout(False)
        Me.groups.PerformLayout()
        Me.MainTab.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbEntry As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtcount As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtmathercode As System.Windows.Forms.TextBox
    Friend WithEvents cbomthecode As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgtails As System.Windows.Forms.DataGridView
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemcodediv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemnamediv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colitemname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents groups As System.Windows.Forms.GroupBox
    Friend WithEvents chkIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents txtdivname As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtitemname As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents MainTab As System.Windows.Forms.TabControl
    Friend WithEvents txtItemdivcode As System.Windows.Forms.TextBox
    Friend WithEvents cboedit As System.Windows.Forms.ComboBox

End Class
