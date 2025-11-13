<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDistributorItemsPrice
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
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnUpdate = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnFind = New System.Windows.Forms.ToolStripButton()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblErrorMessage = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GrdViewItemPrice = New Telerik.WinControls.UI.RadGridView()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkIsActive = New System.Windows.Forms.CheckBox()
        Me.dtEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtStart = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtChannelCode = New System.Windows.Forms.TextBox()
        Me.LinkProductManager = New System.Windows.Forms.LinkLabel()
        Me.txtChannelName = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.GrdViewItemPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrdViewItemPrice.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1448, 58)
        Me.Panel1.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(15, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Channel Items Price List"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnUpdate, Me.btnSave, Me.btnDelete, Me.btnFind, Me.btnClear, Me.ToolStripSeparator2, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1448, 25)
        Me.ToolStrip1.TabIndex = 31
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
        'btnSave
        '
        Me.btnSave.Image = Global.SPMSOPCI.My.Resources.Resources.WSS_DocLib1
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(50, 22)
        Me.btnSave.Text = "Save"
        '
        'btnDelete
        '
        Me.btnDelete.Image = Global.SPMSOPCI.My.Resources.Resources.delete1
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 22)
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.Visible = False
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
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblErrorMessage)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.ToolStrip2)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 83)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1448, 570)
        Me.Panel2.TabIndex = 32
        '
        'lblErrorMessage
        '
        Me.lblErrorMessage.AutoSize = True
        Me.lblErrorMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblErrorMessage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorMessage.ForeColor = System.Drawing.Color.Red
        Me.lblErrorMessage.Location = New System.Drawing.Point(121, 126)
        Me.lblErrorMessage.Name = "lblErrorMessage"
        Me.lblErrorMessage.Size = New System.Drawing.Size(576, 13)
        Me.lblErrorMessage.TabIndex = 116
        Me.lblErrorMessage.Text = "Errors have been found in the detail. highlight each cell with pink highlight to " &
    "show the error message"
        Me.lblErrorMessage.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.GrdViewItemPrice)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 146)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1446, 422)
        Me.Panel4.TabIndex = 110
        '
        'GrdViewItemPrice
        '
        Me.GrdViewItemPrice.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GrdViewItemPrice.Cursor = System.Windows.Forms.Cursors.Default
        Me.GrdViewItemPrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdViewItemPrice.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.GrdViewItemPrice.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GrdViewItemPrice.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GrdViewItemPrice.Location = New System.Drawing.Point(0, 0)
        '
        'GrdViewItemPrice
        '
        Me.GrdViewItemPrice.MasterTemplate.AllowAddNewRow = False
        Me.GrdViewItemPrice.MasterTemplate.AllowDeleteRow = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.HeaderText = "Item Mother Code"
        GridViewTextBoxColumn1.Name = "column1"
        GridViewTextBoxColumn1.ReadOnly = True
        GridViewTextBoxColumn1.Width = 104
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.HeaderText = "Item Mother Description "
        GridViewTextBoxColumn2.Name = "column2"
        GridViewTextBoxColumn2.ReadOnly = True
        GridViewTextBoxColumn2.Width = 296
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.HeaderText = "Item Brand Name"
        GridViewTextBoxColumn3.Name = "column3"
        GridViewTextBoxColumn3.Width = 354
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.HeaderText = "Chal. Item Code"
        GridViewTextBoxColumn4.Name = "column4"
        GridViewTextBoxColumn4.Width = 138
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.HeaderText = "Chal. Item Description "
        GridViewTextBoxColumn5.Name = "column5"
        GridViewTextBoxColumn5.Width = 306
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.HeaderText = "Chal.Price"
        GridViewTextBoxColumn6.Name = "column6"
        GridViewTextBoxColumn6.Width = 103
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.HeaderText = "Company Price"
        GridViewTextBoxColumn7.Name = "column7"
        GridViewTextBoxColumn7.Width = 90
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.HeaderText = "ID"
        GridViewTextBoxColumn8.IsVisible = False
        GridViewTextBoxColumn8.Name = "column8"
        Me.GrdViewItemPrice.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8})
        Me.GrdViewItemPrice.MasterTemplate.EnableFiltering = True
        Me.GrdViewItemPrice.MasterTemplate.EnableGrouping = False
        Me.GrdViewItemPrice.Name = "GrdViewItemPrice"
        Me.GrdViewItemPrice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GrdViewItemPrice.Size = New System.Drawing.Size(1411, 420)
        Me.GrdViewItemPrice.TabIndex = 2
        Me.GrdViewItemPrice.ThemeName = "Office2010Silver"
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(1411, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(33, 420)
        Me.Panel5.TabIndex = 1
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ToolStripLabel1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 121)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1446, 25)
        Me.ToolStrip2.TabIndex = 109
        Me.ToolStrip2.Text = "Item Master list"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(87, 22)
        Me.ToolStripLabel1.Text = "Item Master List"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.chkIsActive)
        Me.Panel3.Controls.Add(Me.dtEnd)
        Me.Panel3.Controls.Add(Me.dtStart)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.txtChannelCode)
        Me.Panel3.Controls.Add(Me.LinkProductManager)
        Me.Panel3.Controls.Add(Me.txtChannelName)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1446, 121)
        Me.Panel3.TabIndex = 108
        '
        'chkIsActive
        '
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIsActive.Checked = True
        Me.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsActive.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsActive.Location = New System.Drawing.Point(392, 13)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(67, 17)
        Me.chkIsActive.TabIndex = 115
        Me.chkIsActive.Text = "Is Active"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'dtEnd
        '
        Me.dtEnd.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEnd.Location = New System.Drawing.Point(328, 83)
        Me.dtEnd.Name = "dtEnd"
        Me.dtEnd.Size = New System.Drawing.Size(132, 20)
        Me.dtEnd.TabIndex = 114
        '
        'dtStart
        '
        Me.dtStart.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStart.Location = New System.Drawing.Point(328, 60)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(132, 20)
        Me.dtStart.TabIndex = 113
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(211, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 13)
        Me.Label8.TabIndex = 112
        Me.Label8.Text = "Effectivity End Date :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(207, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 13)
        Me.Label11.TabIndex = 111
        Me.Label11.Text = "Effectivity Start Date :"
        '
        'txtChannelCode
        '
        Me.txtChannelCode.BackColor = System.Drawing.Color.White
        Me.txtChannelCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChannelCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChannelCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChannelCode.Location = New System.Drawing.Point(99, 35)
        Me.txtChannelCode.MaxLength = 15
        Me.txtChannelCode.Name = "txtChannelCode"
        Me.txtChannelCode.Size = New System.Drawing.Size(106, 22)
        Me.txtChannelCode.TabIndex = 110
        '
        'LinkProductManager
        '
        Me.LinkProductManager.AutoSize = True
        Me.LinkProductManager.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkProductManager.Location = New System.Drawing.Point(7, 38)
        Me.LinkProductManager.Name = "LinkProductManager"
        Me.LinkProductManager.Size = New System.Drawing.Size(85, 15)
        Me.LinkProductManager.TabIndex = 109
        Me.LinkProductManager.TabStop = True
        Me.LinkProductManager.Text = "Company List :"
        '
        'txtChannelName
        '
        Me.txtChannelName.BackColor = System.Drawing.Color.White
        Me.txtChannelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChannelName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChannelName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChannelName.Location = New System.Drawing.Point(207, 35)
        Me.txtChannelName.Name = "txtChannelName"
        Me.txtChannelName.Size = New System.Drawing.Size(253, 22)
        Me.txtChannelName.TabIndex = 108
        '
        'ucDistributorItemsPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ucDistributorItemsPrice"
        Me.Size = New System.Drawing.Size(1448, 653)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.GrdViewItemPrice.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrdViewItemPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
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
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents chkIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtChannelCode As System.Windows.Forms.TextBox
    Friend WithEvents LinkProductManager As System.Windows.Forms.LinkLabel
    Friend WithEvents txtChannelName As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents GrdViewItemPrice As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblErrorMessage As System.Windows.Forms.Label
    Friend WithEvents Office2010SilverTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme

End Class
