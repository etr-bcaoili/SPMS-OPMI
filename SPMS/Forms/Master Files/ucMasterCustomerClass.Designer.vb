<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMasterCustomerClass
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnAdd = New System.Windows.Forms.ToolStripButton
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnClose = New System.Windows.Forms.ToolStripButton
        Me.tbListing = New System.Windows.Forms.TabPage
        Me.btnFilter = New System.Windows.Forms.Button
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.cmbfilter = New System.Windows.Forms.ComboBox
        Me.lblSelection = New System.Windows.Forms.Label
        Me.GridListing = New System.Windows.Forms.DataGridView
        Me.ColCustomerGroup = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerGroupName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColClassCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colClassName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEffectivityStartDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEffectivityEndDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tbEntry = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtEnd = New System.Windows.Forms.DateTimePicker
        Me.dtStart = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbCustomerGroup = New System.Windows.Forms.ComboBox
        Me.txtCustomerGroupName = New System.Windows.Forms.TextBox
        Me.txtCustomerClassDescription = New System.Windows.Forms.TextBox
        Me.txtCustomerClassCode = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblGroupCode = New System.Windows.Forms.Label
        Me.MainTab = New System.Windows.Forms.TabControl
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.tbListing.SuspendLayout()
        CType(Me.GridListing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbEntry.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.MainTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(892, 58)
        Me.Panel1.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Customer Class"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.btnEdit, Me.btnDelete, Me.btnSave, Me.ToolStripSeparator2, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(892, 25)
        Me.ToolStrip1.TabIndex = 25
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
        Me.tbListing.Size = New System.Drawing.Size(884, 398)
        Me.tbListing.TabIndex = 1
        Me.tbListing.Text = "Listing"
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(475, 6)
        Me.btnFilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(79, 24)
        Me.btnFilter.TabIndex = 4
        Me.btnFilter.Text = "Filter "
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(219, 6)
        Me.txtFilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(207, 20)
        Me.txtFilter.TabIndex = 3
        '
        'cmbfilter
        '
        Me.cmbfilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbfilter.FormattingEnabled = True
        Me.cmbfilter.Items.AddRange(New Object() {"All", "CustomerGroupCode", "CustomerClassCode", "CustomerClassName"})
        Me.cmbfilter.Location = New System.Drawing.Point(67, 4)
        Me.cmbfilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbfilter.Name = "cmbfilter"
        Me.cmbfilter.Size = New System.Drawing.Size(146, 22)
        Me.cmbfilter.TabIndex = 2
        '
        'lblSelection
        '
        Me.lblSelection.AutoSize = True
        Me.lblSelection.Location = New System.Drawing.Point(6, 9)
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
        Me.GridListing.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridListing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridListing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCustomerGroup, Me.CustomerGroupName, Me.ColClassCode, Me.colClassName, Me.colEffectivityStartDate, Me.colEffectivityEndDate})
        Me.GridListing.Location = New System.Drawing.Point(6, 40)
        Me.GridListing.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridListing.Name = "GridListing"
        Me.GridListing.Size = New System.Drawing.Size(872, 354)
        Me.GridListing.TabIndex = 0
        '
        'ColCustomerGroup
        '
        Me.ColCustomerGroup.HeaderText = "Customer Group Code"
        Me.ColCustomerGroup.Name = "ColCustomerGroup"
        Me.ColCustomerGroup.ReadOnly = True
        Me.ColCustomerGroup.Width = 140
        '
        'CustomerGroupName
        '
        Me.CustomerGroupName.HeaderText = "Customer Group Name"
        Me.CustomerGroupName.Name = "CustomerGroupName"
        Me.CustomerGroupName.Width = 240
        '
        'ColClassCode
        '
        Me.ColClassCode.HeaderText = "Customer Class Code"
        Me.ColClassCode.Name = "ColClassCode"
        Me.ColClassCode.ReadOnly = True
        Me.ColClassCode.Width = 140
        '
        'colClassName
        '
        Me.colClassName.HeaderText = "Customer Class Name"
        Me.colClassName.Name = "colClassName"
        Me.colClassName.ReadOnly = True
        Me.colClassName.Width = 300
        '
        'colEffectivityStartDate
        '
        Me.colEffectivityStartDate.HeaderText = "Effectivity Start Date"
        Me.colEffectivityStartDate.Name = "colEffectivityStartDate"
        Me.colEffectivityStartDate.Visible = False
        '
        'colEffectivityEndDate
        '
        Me.colEffectivityEndDate.HeaderText = "Effectivity End Date"
        Me.colEffectivityEndDate.Name = "colEffectivityEndDate"
        Me.colEffectivityEndDate.Visible = False
        '
        'tbEntry
        '
        Me.tbEntry.BackColor = System.Drawing.SystemColors.Control
        Me.tbEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbEntry.Controls.Add(Me.GroupBox1)
        Me.tbEntry.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEntry.Location = New System.Drawing.Point(4, 23)
        Me.tbEntry.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbEntry.Name = "tbEntry"
        Me.tbEntry.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbEntry.Size = New System.Drawing.Size(884, 398)
        Me.tbEntry.TabIndex = 0
        Me.tbEntry.Text = "Entry"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.dtEnd)
        Me.GroupBox1.Controls.Add(Me.dtStart)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbCustomerGroup)
        Me.GroupBox1.Controls.Add(Me.txtCustomerGroupName)
        Me.GroupBox1.Controls.Add(Me.txtCustomerClassDescription)
        Me.GroupBox1.Controls.Add(Me.txtCustomerClassCode)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblGroupCode)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(446, 384)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'dtEnd
        '
        Me.dtEnd.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEnd.Location = New System.Drawing.Point(136, 127)
        Me.dtEnd.Name = "dtEnd"
        Me.dtEnd.Size = New System.Drawing.Size(110, 22)
        Me.dtEnd.TabIndex = 34
        '
        'dtStart
        '
        Me.dtStart.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStart.Location = New System.Drawing.Point(136, 101)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(110, 22)
        Me.dtStart.TabIndex = 33
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 15)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Effectivity End Date :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 15)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Effectivity Start Date :"
        '
        'cmbCustomerGroup
        '
        Me.cmbCustomerGroup.FormattingEnabled = True
        Me.cmbCustomerGroup.Location = New System.Drawing.Point(135, 27)
        Me.cmbCustomerGroup.Name = "cmbCustomerGroup"
        Me.cmbCustomerGroup.Size = New System.Drawing.Size(110, 21)
        Me.cmbCustomerGroup.TabIndex = 28
        '
        'txtCustomerGroupName
        '
        Me.txtCustomerGroupName.BackColor = System.Drawing.Color.White
        Me.txtCustomerGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerGroupName.Location = New System.Drawing.Point(247, 26)
        Me.txtCustomerGroupName.Name = "txtCustomerGroupName"
        Me.txtCustomerGroupName.Size = New System.Drawing.Size(190, 22)
        Me.txtCustomerGroupName.TabIndex = 27
        '
        'txtCustomerClassDescription
        '
        Me.txtCustomerClassDescription.BackColor = System.Drawing.Color.White
        Me.txtCustomerClassDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerClassDescription.Location = New System.Drawing.Point(136, 76)
        Me.txtCustomerClassDescription.Name = "txtCustomerClassDescription"
        Me.txtCustomerClassDescription.Size = New System.Drawing.Size(301, 22)
        Me.txtCustomerClassDescription.TabIndex = 23
        '
        'txtCustomerClassCode
        '
        Me.txtCustomerClassCode.BackColor = System.Drawing.Color.White
        Me.txtCustomerClassCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerClassCode.Location = New System.Drawing.Point(136, 51)
        Me.txtCustomerClassCode.Name = "txtCustomerClassCode"
        Me.txtCustomerClassCode.Size = New System.Drawing.Size(301, 22)
        Me.txtCustomerClassCode.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 15)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Customer Class Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 15)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Customer Class Code :"
        '
        'lblGroupCode
        '
        Me.lblGroupCode.AutoSize = True
        Me.lblGroupCode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupCode.Location = New System.Drawing.Point(31, 30)
        Me.lblGroupCode.Name = "lblGroupCode"
        Me.lblGroupCode.Size = New System.Drawing.Size(101, 15)
        Me.lblGroupCode.TabIndex = 24
        Me.lblGroupCode.Text = "Customer Group :"
        '
        'MainTab
        '
        Me.MainTab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainTab.Controls.Add(Me.tbEntry)
        Me.MainTab.Controls.Add(Me.tbListing)
        Me.MainTab.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainTab.Location = New System.Drawing.Point(0, 83)
        Me.MainTab.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainTab.Name = "MainTab"
        Me.MainTab.SelectedIndex = 0
        Me.MainTab.Size = New System.Drawing.Size(892, 425)
        Me.MainTab.TabIndex = 16
        '
        'ucMasterCustomerClass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MainTab)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ucMasterCustomerClass"
        Me.Size = New System.Drawing.Size(892, 508)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.tbListing.ResumeLayout(False)
        Me.tbListing.PerformLayout()
        CType(Me.GridListing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbEntry.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MainTab.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbListing As System.Windows.Forms.TabPage
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents cmbfilter As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelection As System.Windows.Forms.Label
    Friend WithEvents GridListing As System.Windows.Forms.DataGridView
    Friend WithEvents ColCustomerGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerGroupName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColClassCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colClassName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEffectivityStartDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEffectivityEndDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tbEntry As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbCustomerGroup As System.Windows.Forms.ComboBox
    Friend WithEvents txtCustomerGroupName As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerClassDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerClassCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblGroupCode As System.Windows.Forms.Label
    Friend WithEvents MainTab As System.Windows.Forms.TabControl

End Class
