<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCInfraReport
    Inherits Althea.Base.UI.BasePage

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCInfraReport))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFind = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnUndo = New System.Windows.Forms.ToolStripButton()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.dgFilters = New System.Windows.Forms.DataGridView()
        Me.colLabel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colColumnName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDataType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSearchTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSqlColumns = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSqlQuery = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtReportTitle = New System.Windows.Forms.TextBox()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.txtSqlStoredProc = New System.Windows.Forms.TextBox()
        Me.lnkSqlStoredProc = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgFilters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BasePageHeader1
        '
        Me.BasePageHeader1.HeaderText = "Report Maintenance"
        Me.BasePageHeader1.Size = New System.Drawing.Size(819, 41)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.ToolStripSeparator1, Me.btnFind, Me.btnSave, Me.btnUndo, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 41)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(819, 25)
        Me.ToolStrip1.TabIndex = 197
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(51, 22)
        Me.btnNew.Text = "&New"
        Me.btnNew.ToolTipText = "Click New button to add new records of unit of measure."
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(47, 22)
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.ToolTipText = "Click Edit button to edit/change records." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.White
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 22)
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.ToolTipText = "Click Delete button to delete the entry."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnFind
        '
        Me.btnFind.Image = CType(resources.GetObject("btnFind.Image"), System.Drawing.Image)
        Me.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(50, 22)
        Me.btnFind.Text = "&Find"
        Me.btnFind.ToolTipText = "Click Find button to search records on Unit of measure."
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.White
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(51, 22)
        Me.btnSave.Text = "&Save"
        Me.btnSave.ToolTipText = "Click Save button to commit changes."
        '
        'btnUndo
        '
        Me.btnUndo.Image = CType(resources.GetObject("btnUndo.Image"), System.Drawing.Image)
        Me.btnUndo.ImageTransparentColor = System.Drawing.Color.White
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(56, 22)
        Me.btnUndo.Text = "Undo"
        Me.btnUndo.ToolTipText = "Click undo to undo the changes."
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 22)
        Me.btnClose.Text = "Close"
        '
        'dgFilters
        '
        Me.dgFilters.AllowUserToAddRows = False
        Me.dgFilters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFilters.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colLabel, Me.colColumnName, Me.colDataType, Me.colSearchTo, Me.colSqlColumns, Me.colSqlQuery})
        Me.dgFilters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgFilters.Location = New System.Drawing.Point(3, 17)
        Me.dgFilters.Name = "dgFilters"
        Me.dgFilters.RowHeadersVisible = False
        Me.dgFilters.Size = New System.Drawing.Size(813, 186)
        Me.dgFilters.TabIndex = 198
        '
        'colLabel
        '
        Me.colLabel.Frozen = True
        Me.colLabel.HeaderText = "Label"
        Me.colLabel.Name = "colLabel"
        '
        'colColumnName
        '
        Me.colColumnName.DataPropertyName = "Parameter"
        Me.colColumnName.Frozen = True
        Me.colColumnName.HeaderText = "Column Name"
        Me.colColumnName.Name = "colColumnName"
        Me.colColumnName.ReadOnly = True
        Me.colColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colDataType
        '
        Me.colDataType.DataPropertyName = "Data Type"
        Me.colDataType.Frozen = True
        Me.colDataType.HeaderText = "Data Type"
        Me.colDataType.Name = "colDataType"
        Me.colDataType.ReadOnly = True
        Me.colDataType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colSearchTo
        '
        Me.colSearchTo.HeaderText = "Search To"
        Me.colSearchTo.Name = "colSearchTo"
        Me.colSearchTo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSearchTo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colSqlColumns
        '
        Me.colSqlColumns.HeaderText = "Columns"
        Me.colSqlColumns.Name = "colSqlColumns"
        Me.colSqlColumns.ReadOnly = True
        '
        'colSqlQuery
        '
        Me.colSqlQuery.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colSqlQuery.HeaderText = "Query"
        Me.colSqlQuery.Name = "colSqlQuery"
        Me.colSqlQuery.ReadOnly = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(49, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 200
        Me.Label2.Text = "Report Title :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(80, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 201
        Me.Label3.Text = "Code :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(52, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 202
        Me.Label4.Text = "Description :"
        '
        'txtReportTitle
        '
        Me.txtReportTitle.Location = New System.Drawing.Point(125, 49)
        Me.txtReportTitle.Name = "txtReportTitle"
        Me.txtReportTitle.Size = New System.Drawing.Size(177, 21)
        Me.txtReportTitle.TabIndex = 203
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(125, 76)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(177, 21)
        Me.txtCode.TabIndex = 204
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(125, 103)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(239, 21)
        Me.txtDescription.TabIndex = 205
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cboType)
        Me.Panel1.Controls.Add(Me.chkActive)
        Me.Panel1.Controls.Add(Me.txtSqlStoredProc)
        Me.Panel1.Controls.Add(Me.lnkSqlStoredProc)
        Me.Panel1.Controls.Add(Me.txtCode)
        Me.Panel1.Controls.Add(Me.txtDescription)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtReportTitle)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 66)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(819, 168)
        Me.Panel1.TabIndex = 206
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(81, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 215
        Me.Label1.Text = "Type :"
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"Sales Summary Report", "Sales Transaction Report", "Master File Report", "Others", "Items", "Customers", "Territory Manager"})
        Me.cboType.Location = New System.Drawing.Point(125, 23)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(177, 21)
        Me.cboType.TabIndex = 214
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Location = New System.Drawing.Point(308, 48)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(56, 17)
        Me.chkActive.TabIndex = 212
        Me.chkActive.Text = "Active"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'txtSqlStoredProc
        '
        Me.txtSqlStoredProc.BackColor = System.Drawing.Color.White
        Me.txtSqlStoredProc.Location = New System.Drawing.Point(125, 130)
        Me.txtSqlStoredProc.Name = "txtSqlStoredProc"
        Me.txtSqlStoredProc.ReadOnly = True
        Me.txtSqlStoredProc.Size = New System.Drawing.Size(239, 21)
        Me.txtSqlStoredProc.TabIndex = 211
        '
        'lnkSqlStoredProc
        '
        Me.lnkSqlStoredProc.AutoSize = True
        Me.lnkSqlStoredProc.Location = New System.Drawing.Point(28, 133)
        Me.lnkSqlStoredProc.Name = "lnkSqlStoredProc"
        Me.lnkSqlStoredProc.Size = New System.Drawing.Size(91, 13)
        Me.lnkSqlStoredProc.TabIndex = 210
        Me.lnkSqlStoredProc.TabStop = True
        Me.lnkSqlStoredProc.Text = "Sql Stored Proc. :"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox1.Controls.Add(Me.dgFilters)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 234)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(819, 206)
        Me.GroupBox1.TabIndex = 207
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filters :"
        '
        'UCInfraReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "UCInfraReport"
        Me.Size = New System.Drawing.Size(819, 440)
        Me.Controls.SetChildIndex(Me.BasePageHeader1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgFilters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnFind As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgFilters As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtReportTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lnkSqlStoredProc As System.Windows.Forms.LinkLabel
    Friend WithEvents txtSqlStoredProc As System.Windows.Forms.TextBox
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents colLabel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colColumnName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDataType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSearchTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSqlColumns As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSqlQuery As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
