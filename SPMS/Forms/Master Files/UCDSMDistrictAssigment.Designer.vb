<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCDSMDistrictAssigment
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
        Me.chkIsActive = New System.Windows.Forms.CheckBox
        Me.txtRegionCode = New System.Windows.Forms.TextBox
        Me.cmbRegionCode = New System.Windows.Forms.ComboBox
        Me.lblCode = New System.Windows.Forms.Label
        Me.txtdistrictCode = New System.Windows.Forms.TextBox
        Me.lblDistrictDescription = New System.Windows.Forms.Label
        Me.lbldistrictCode = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.cboRegionDesc = New System.Windows.Forms.ComboBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btnFilter = New System.Windows.Forms.Button
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.cmbfilter = New System.Windows.Forms.ComboBox
        Me.lblSelection = New System.Windows.Forms.Label
        Me.dgListing = New System.Windows.Forms.DataGridView
        Me.colDivCD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDivName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAreaCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgListing, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(1024, 58)
        Me.Panel1.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(15, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "District Creation"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.btnEdit, Me.btnDelete, Me.btnSave, Me.ToolStripSeparator2, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1024, 25)
        Me.ToolStrip1.TabIndex = 14
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
        'chkIsActive
        '
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.Checked = True
        Me.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsActive.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsActive.Location = New System.Drawing.Point(442, 6)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(67, 17)
        Me.chkIsActive.TabIndex = 52
        Me.chkIsActive.Text = "Is Active"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'txtRegionCode
        '
        Me.txtRegionCode.BackColor = System.Drawing.Color.White
        Me.txtRegionCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegionCode.Location = New System.Drawing.Point(505, 30)
        Me.txtRegionCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtRegionCode.Name = "txtRegionCode"
        Me.txtRegionCode.ReadOnly = True
        Me.txtRegionCode.Size = New System.Drawing.Size(15, 22)
        Me.txtRegionCode.TabIndex = 51
        Me.txtRegionCode.Visible = False
        '
        'cmbRegionCode
        '
        Me.cmbRegionCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbRegionCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRegionCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRegionCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRegionCode.FormattingEnabled = True
        Me.cmbRegionCode.Location = New System.Drawing.Point(136, 30)
        Me.cmbRegionCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbRegionCode.Name = "cmbRegionCode"
        Me.cmbRegionCode.Size = New System.Drawing.Size(125, 21)
        Me.cmbRegionCode.TabIndex = 50
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.BackColor = System.Drawing.Color.Transparent
        Me.lblCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCode.Location = New System.Drawing.Point(12, 39)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(113, 13)
        Me.lblCode.TabIndex = 45
        Me.lblCode.Text = "Sales Division Code :"
        '
        'txtdistrictCode
        '
        Me.txtdistrictCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdistrictCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdistrictCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdistrictCode.Location = New System.Drawing.Point(134, 60)
        Me.txtdistrictCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtdistrictCode.Name = "txtdistrictCode"
        Me.txtdistrictCode.Size = New System.Drawing.Size(125, 20)
        Me.txtdistrictCode.TabIndex = 47
        '
        'lblDistrictDescription
        '
        Me.lblDistrictDescription.AutoSize = True
        Me.lblDistrictDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblDistrictDescription.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDistrictDescription.Location = New System.Drawing.Point(12, 87)
        Me.lblDistrictDescription.Name = "lblDistrictDescription"
        Me.lblDistrictDescription.Size = New System.Drawing.Size(81, 13)
        Me.lblDistrictDescription.TabIndex = 46
        Me.lblDistrictDescription.Text = "District Name :"
        '
        'lbldistrictCode
        '
        Me.lbldistrictCode.AutoSize = True
        Me.lbldistrictCode.BackColor = System.Drawing.Color.Transparent
        Me.lbldistrictCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldistrictCode.Location = New System.Drawing.Point(12, 65)
        Me.lbldistrictCode.Name = "lbldistrictCode"
        Me.lbldistrictCode.Size = New System.Drawing.Size(79, 13)
        Me.lbldistrictCode.TabIndex = 49
        Me.lbldistrictCode.Text = "District Code :"
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(134, 83)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(375, 20)
        Me.txtDescription.TabIndex = 48
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(3, 96)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1018, 669)
        Me.TabControl1.TabIndex = 53
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.cboRegionDesc)
        Me.TabPage1.Controls.Add(Me.cmbRegionCode)
        Me.TabPage1.Controls.Add(Me.chkIsActive)
        Me.TabPage1.Controls.Add(Me.txtDescription)
        Me.TabPage1.Controls.Add(Me.txtRegionCode)
        Me.TabPage1.Controls.Add(Me.lbldistrictCode)
        Me.TabPage1.Controls.Add(Me.lblDistrictDescription)
        Me.TabPage1.Controls.Add(Me.lblCode)
        Me.TabPage1.Controls.Add(Me.txtdistrictCode)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1010, 643)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Entry"
        '
        'cboRegionDesc
        '
        Me.cboRegionDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboRegionDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRegionDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegionDesc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRegionDesc.FormattingEnabled = True
        Me.cboRegionDesc.Location = New System.Drawing.Point(261, 30)
        Me.cboRegionDesc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboRegionDesc.Name = "cboRegionDesc"
        Me.cboRegionDesc.Size = New System.Drawing.Size(248, 21)
        Me.cboRegionDesc.TabIndex = 53
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.btnFilter)
        Me.TabPage2.Controls.Add(Me.txtFilter)
        Me.TabPage2.Controls.Add(Me.cmbfilter)
        Me.TabPage2.Controls.Add(Me.lblSelection)
        Me.TabPage2.Controls.Add(Me.dgListing)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1010, 643)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Listing"
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(462, 7)
        Me.btnFilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(79, 22)
        Me.btnFilter.TabIndex = 9
        Me.btnFilter.Text = "Filter "
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(220, 7)
        Me.txtFilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(207, 22)
        Me.txtFilter.TabIndex = 8
        '
        'cmbfilter
        '
        Me.cmbfilter.FormattingEnabled = True
        Me.cmbfilter.Items.AddRange(New Object() {"All", "RegionCode", "DistrictCode", "Description"})
        Me.cmbfilter.Location = New System.Drawing.Point(68, 7)
        Me.cmbfilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbfilter.Name = "cmbfilter"
        Me.cmbfilter.Size = New System.Drawing.Size(146, 21)
        Me.cmbfilter.TabIndex = 7
        '
        'lblSelection
        '
        Me.lblSelection.AutoSize = True
        Me.lblSelection.Location = New System.Drawing.Point(7, 16)
        Me.lblSelection.Name = "lblSelection"
        Me.lblSelection.Size = New System.Drawing.Size(60, 13)
        Me.lblSelection.TabIndex = 6
        Me.lblSelection.Text = "Selection :"
        '
        'dgListing
        '
        Me.dgListing.AllowUserToAddRows = False
        Me.dgListing.AllowUserToDeleteRows = False
        Me.dgListing.AllowUserToOrderColumns = True
        Me.dgListing.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgListing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgListing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDivCD, Me.colDivName, Me.colAreaCode, Me.colStatus})
        Me.dgListing.Location = New System.Drawing.Point(7, 38)
        Me.dgListing.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgListing.Name = "dgListing"
        Me.dgListing.Size = New System.Drawing.Size(997, 598)
        Me.dgListing.TabIndex = 5
        '
        'colDivCD
        '
        Me.colDivCD.HeaderText = "Sales District Code"
        Me.colDivCD.Name = "colDivCD"
        Me.colDivCD.ReadOnly = True
        Me.colDivCD.Width = 150
        '
        'colDivName
        '
        Me.colDivName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDivName.HeaderText = "Sales District Name"
        Me.colDivName.Name = "colDivName"
        Me.colDivName.ReadOnly = True
        '
        'colAreaCode
        '
        Me.colAreaCode.HeaderText = "Sales Division Code"
        Me.colAreaCode.Name = "colAreaCode"
        Me.colAreaCode.ReadOnly = True
        Me.colAreaCode.Width = 150
        '
        'colStatus
        '
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        '
        'UCDSMDistrictAssigment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UCDSMDistrictAssigment"
        Me.Size = New System.Drawing.Size(1024, 768)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgListing, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents chkIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents txtRegionCode As System.Windows.Forms.TextBox
    Friend WithEvents cmbRegionCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtdistrictCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDistrictDescription As System.Windows.Forms.Label
    Friend WithEvents lbldistrictCode As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents cmbfilter As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelection As System.Windows.Forms.Label
    Friend WithEvents dgListing As System.Windows.Forms.DataGridView
    Friend WithEvents cboRegionDesc As System.Windows.Forms.ComboBox
    Friend WithEvents colDivCD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDivName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAreaCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
