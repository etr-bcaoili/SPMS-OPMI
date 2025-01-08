<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UProductManagerMapping
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
        Dim GridViewCheckBoxColumn2 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim TableViewDefinition4 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim TableViewDefinition5 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim TableViewDefinition6 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.MainTab = New System.Windows.Forms.TabControl()
        Me.tbEntry = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.gridviewCustomer = New Telerik.WinControls.UI.RadGridView()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.gridvieConvertMotherAccount = New Telerik.WinControls.UI.RadGridView()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtPm_Name = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtPM_ID = New System.Windows.Forms.TextBox()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.tbListing = New System.Windows.Forms.TabPage()
        Me.GridviewproductManager = New Telerik.WinControls.UI.RadGridView()
        Me.Office2010BlueTheme1 = New Telerik.WinControls.Themes.Office2010BlueTheme()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.MainTab.SuspendLayout()
        Me.tbEntry.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.gridviewCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridviewCustomer.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.gridvieConvertMotherAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridvieConvertMotherAccount.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.tbListing.SuspendLayout()
        CType(Me.GridviewproductManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridviewproductManager.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(1118, 58)
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
        Me.Label5.Size = New System.Drawing.Size(196, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Product Manager Mapping"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.btnSave, Me.ToolStripSeparator2, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1118, 25)
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
        'MainTab
        '
        Me.MainTab.Controls.Add(Me.tbEntry)
        Me.MainTab.Controls.Add(Me.tbListing)
        Me.MainTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTab.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainTab.Location = New System.Drawing.Point(0, 83)
        Me.MainTab.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainTab.Name = "MainTab"
        Me.MainTab.SelectedIndex = 0
        Me.MainTab.Size = New System.Drawing.Size(1118, 596)
        Me.MainTab.TabIndex = 29
        '
        'tbEntry
        '
        Me.tbEntry.BackColor = System.Drawing.Color.White
        Me.tbEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbEntry.Controls.Add(Me.Panel3)
        Me.tbEntry.Controls.Add(Me.Panel2)
        Me.tbEntry.Location = New System.Drawing.Point(4, 23)
        Me.tbEntry.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbEntry.Name = "tbEntry"
        Me.tbEntry.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbEntry.Size = New System.Drawing.Size(1110, 569)
        Me.tbEntry.TabIndex = 0
        Me.tbEntry.Text = "Entry"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.ToolStrip2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 90)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1104, 475)
        Me.Panel3.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.gridviewCustomer)
        Me.Panel5.Controls.Add(Me.ToolStrip3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(493, 25)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(611, 450)
        Me.Panel5.TabIndex = 23
        '
        'gridviewCustomer
        '
        Me.gridviewCustomer.BackColor = System.Drawing.Color.White
        Me.gridviewCustomer.Cursor = System.Windows.Forms.Cursors.Default
        Me.gridviewCustomer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridviewCustomer.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.gridviewCustomer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.gridviewCustomer.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.gridviewCustomer.Location = New System.Drawing.Point(0, 25)
        '
        '
        '
        Me.gridviewCustomer.MasterTemplate.AllowAddNewRow = False
        GridViewCheckBoxColumn2.EnableExpressionEditor = False
        GridViewCheckBoxColumn2.MinWidth = 20
        GridViewCheckBoxColumn2.Name = "column1"
        GridViewCheckBoxColumn2.Width = 27
        Me.gridviewCustomer.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn2})
        Me.gridviewCustomer.MasterTemplate.EnableAlternatingRowColor = True
        Me.gridviewCustomer.MasterTemplate.EnableFiltering = True
        Me.gridviewCustomer.MasterTemplate.EnableGrouping = False
        Me.gridviewCustomer.MasterTemplate.ShowRowHeaderColumn = False
        Me.gridviewCustomer.MasterTemplate.ViewDefinition = TableViewDefinition4
        Me.gridviewCustomer.Name = "gridviewCustomer"
        Me.gridviewCustomer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.gridviewCustomer.Size = New System.Drawing.Size(609, 423)
        Me.gridviewCustomer.TabIndex = 32
        Me.gridviewCustomer.ThemeName = "Office2010Blue"
        '
        'ToolStrip3
        '
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton5, Me.ToolStripSeparator3})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(609, 25)
        Me.ToolStrip3.TabIndex = 22
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = Global.SPMSOPCI.My.Resources.Resources.add1
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(94, 22)
        Me.ToolStripButton5.Text = "Add Selected"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.gridvieConvertMotherAccount)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 25)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(493, 450)
        Me.Panel4.TabIndex = 22
        '
        'gridvieConvertMotherAccount
        '
        Me.gridvieConvertMotherAccount.BackColor = System.Drawing.Color.White
        Me.gridvieConvertMotherAccount.Cursor = System.Windows.Forms.Cursors.Default
        Me.gridvieConvertMotherAccount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridvieConvertMotherAccount.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridvieConvertMotherAccount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.gridvieConvertMotherAccount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.gridvieConvertMotherAccount.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.gridvieConvertMotherAccount.MasterTemplate.AllowAddNewRow = False
        Me.gridvieConvertMotherAccount.MasterTemplate.EnableGrouping = False
        Me.gridvieConvertMotherAccount.MasterTemplate.ViewDefinition = TableViewDefinition5
        Me.gridvieConvertMotherAccount.Name = "gridvieConvertMotherAccount"
        Me.gridvieConvertMotherAccount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.gridvieConvertMotherAccount.Size = New System.Drawing.Size(491, 448)
        Me.gridvieConvertMotherAccount.TabIndex = 33
        Me.gridvieConvertMotherAccount.ThemeName = "VisualStudio2012Light"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ToolStripButton4})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1104, 25)
        Me.ToolStrip2.TabIndex = 21
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = Global.SPMSOPCI.My.Resources.Resources.cancel
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(67, 22)
        Me.ToolStripButton4.Text = "Remove"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.txtPm_Name)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.txtPM_ID)
        Me.Panel2.Controls.Add(Me.lblItemCode)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1104, 86)
        Me.Panel2.TabIndex = 0
        '
        'txtPm_Name
        '
        Me.txtPm_Name.BackColor = System.Drawing.Color.White
        Me.txtPm_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPm_Name.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPm_Name.Location = New System.Drawing.Point(157, 39)
        Me.txtPm_Name.Name = "txtPm_Name"
        Me.txtPm_Name.ReadOnly = True
        Me.txtPm_Name.Size = New System.Drawing.Size(243, 22)
        Me.txtPm_Name.TabIndex = 48
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(8, 41)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(140, 15)
        Me.Label14.TabIndex = 47
        Me.Label14.Text = "Product Manager Name :"
        '
        'txtPM_ID
        '
        Me.txtPM_ID.BackColor = System.Drawing.Color.White
        Me.txtPM_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPM_ID.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPM_ID.Location = New System.Drawing.Point(157, 15)
        Me.txtPM_ID.Name = "txtPM_ID"
        Me.txtPM_ID.ReadOnly = True
        Me.txtPM_ID.Size = New System.Drawing.Size(243, 22)
        Me.txtPM_ID.TabIndex = 45
        '
        'lblItemCode
        '
        Me.lblItemCode.AutoSize = True
        Me.lblItemCode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemCode.Location = New System.Drawing.Point(29, 19)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Size = New System.Drawing.Size(119, 15)
        Me.lblItemCode.TabIndex = 46
        Me.lblItemCode.Text = "Product Manager ID :"
        '
        'tbListing
        '
        Me.tbListing.BackColor = System.Drawing.SystemColors.Control
        Me.tbListing.Controls.Add(Me.GridviewproductManager)
        Me.tbListing.Location = New System.Drawing.Point(4, 23)
        Me.tbListing.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbListing.Name = "tbListing"
        Me.tbListing.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbListing.Size = New System.Drawing.Size(1110, 569)
        Me.tbListing.TabIndex = 1
        Me.tbListing.Text = "Listing"
        '
        'GridviewproductManager
        '
        Me.GridviewproductManager.BackColor = System.Drawing.Color.White
        Me.GridviewproductManager.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridviewproductManager.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridviewproductManager.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.GridviewproductManager.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.GridviewproductManager.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GridviewproductManager.Location = New System.Drawing.Point(3, 4)
        '
        '
        '
        Me.GridviewproductManager.MasterTemplate.AllowAddNewRow = False
        Me.GridviewproductManager.MasterTemplate.EnableAlternatingRowColor = True
        Me.GridviewproductManager.MasterTemplate.EnableFiltering = True
        Me.GridviewproductManager.MasterTemplate.EnableGrouping = False
        Me.GridviewproductManager.MasterTemplate.EnableSorting = False
        Me.GridviewproductManager.MasterTemplate.ShowRowHeaderColumn = False
        Me.GridviewproductManager.MasterTemplate.ViewDefinition = TableViewDefinition6
        Me.GridviewproductManager.Name = "GridviewproductManager"
        Me.GridviewproductManager.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GridviewproductManager.Size = New System.Drawing.Size(1104, 561)
        Me.GridviewproductManager.TabIndex = 33
        Me.GridviewproductManager.ThemeName = "VisualStudio2012Light"
        '
        'UProductManagerMapping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.MainTab)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UProductManagerMapping"
        Me.Size = New System.Drawing.Size(1118, 679)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MainTab.ResumeLayout(False)
        Me.tbEntry.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.gridviewCustomer.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridviewCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.gridvieConvertMotherAccount.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridvieConvertMotherAccount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.tbListing.ResumeLayout(False)
        CType(Me.GridviewproductManager.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridviewproductManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents MainTab As System.Windows.Forms.TabControl
    Friend WithEvents tbEntry As System.Windows.Forms.TabPage
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tbListing As System.Windows.Forms.TabPage
    Friend WithEvents txtPm_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPM_ID As System.Windows.Forms.TextBox
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents gridviewCustomer As Telerik.WinControls.UI.RadGridView
    Friend WithEvents gridvieConvertMotherAccount As Telerik.WinControls.UI.RadGridView
    Friend WithEvents GridviewproductManager As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Office2010BlueTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme

End Class
