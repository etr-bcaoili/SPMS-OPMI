<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMasterSTDistrict
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
        Me.MainTab = New System.Windows.Forms.TabControl
        Me.tbEntry = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboDistrictName = New System.Windows.Forms.ComboBox
        Me.txtDivisionCode = New System.Windows.Forms.TextBox
        Me.cboDistrictCode = New System.Windows.Forms.ComboBox
        Me.chkIsActive = New System.Windows.Forms.CheckBox
        Me.dtEnd = New System.Windows.Forms.DateTimePicker
        Me.dtStart = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtRegionCode = New System.Windows.Forms.TextBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.txtSalesManagerCode = New System.Windows.Forms.TextBox
        Me.txtSalesManagerName = New System.Windows.Forms.TextBox
        Me.cmbRegionCode = New System.Windows.Forms.ComboBox
        Me.lblCode = New System.Windows.Forms.Label
        Me.txtdistrictCode = New System.Windows.Forms.TextBox
        Me.lbldistrictCode = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.tbListing = New System.Windows.Forms.TabPage
        Me.btnFilter = New System.Windows.Forms.Button
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.cmbfilter = New System.Windows.Forms.ComboBox
        Me.lblSelection = New System.Windows.Forms.Label
        Me.GridListing = New System.Windows.Forms.DataGridView
        Me.colCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSalesDivisionName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDistrictCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEffectivityStartDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEffectivityEndDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnAdd = New System.Windows.Forms.ToolStripButton
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnClose = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.MainTab.SuspendLayout()
        Me.tbEntry.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbListing.SuspendLayout()
        CType(Me.GridListing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.MainTab.Size = New System.Drawing.Size(786, 355)
        Me.MainTab.TabIndex = 12
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
        Me.tbEntry.Size = New System.Drawing.Size(778, 328)
        Me.tbEntry.TabIndex = 0
        Me.tbEntry.Text = "Entry"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboDistrictName)
        Me.GroupBox1.Controls.Add(Me.txtDivisionCode)
        Me.GroupBox1.Controls.Add(Me.cboDistrictCode)
        Me.GroupBox1.Controls.Add(Me.chkIsActive)
        Me.GroupBox1.Controls.Add(Me.dtEnd)
        Me.GroupBox1.Controls.Add(Me.dtStart)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtRegionCode)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.txtSalesManagerCode)
        Me.GroupBox1.Controls.Add(Me.txtSalesManagerName)
        Me.GroupBox1.Controls.Add(Me.cmbRegionCode)
        Me.GroupBox1.Controls.Add(Me.lblCode)
        Me.GroupBox1.Controls.Add(Me.txtdistrictCode)
        Me.GroupBox1.Controls.Add(Me.lbldistrictCode)
        Me.GroupBox1.Controls.Add(Me.txtDescription)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(536, 314)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'cboDistrictName
        '
        Me.cboDistrictName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboDistrictName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDistrictName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistrictName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDistrictName.FormattingEnabled = True
        Me.cboDistrictName.Location = New System.Drawing.Point(267, 25)
        Me.cboDistrictName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboDistrictName.Name = "cboDistrictName"
        Me.cboDistrictName.Size = New System.Drawing.Size(170, 21)
        Me.cboDistrictName.TabIndex = 47
        '
        'txtDivisionCode
        '
        Me.txtDivisionCode.BackColor = System.Drawing.Color.White
        Me.txtDivisionCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDivisionCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDivisionCode.Location = New System.Drawing.Point(139, 50)
        Me.txtDivisionCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDivisionCode.Multiline = True
        Me.txtDivisionCode.Name = "txtDivisionCode"
        Me.txtDivisionCode.Size = New System.Drawing.Size(125, 20)
        Me.txtDivisionCode.TabIndex = 46
        '
        'cboDistrictCode
        '
        Me.cboDistrictCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboDistrictCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDistrictCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistrictCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDistrictCode.FormattingEnabled = True
        Me.cboDistrictCode.Location = New System.Drawing.Point(140, 26)
        Me.cboDistrictCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboDistrictCode.Name = "cboDistrictCode"
        Me.cboDistrictCode.Size = New System.Drawing.Size(125, 21)
        Me.cboDistrictCode.TabIndex = 45
        '
        'chkIsActive
        '
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.Checked = True
        Me.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsActive.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsActive.Location = New System.Drawing.Point(453, 27)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(67, 17)
        Me.chkIsActive.TabIndex = 44
        Me.chkIsActive.Text = "Is Active"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'dtEnd
        '
        Me.dtEnd.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEnd.Location = New System.Drawing.Point(139, 123)
        Me.dtEnd.Name = "dtEnd"
        Me.dtEnd.Size = New System.Drawing.Size(126, 22)
        Me.dtEnd.TabIndex = 38
        '
        'dtStart
        '
        Me.dtStart.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStart.Location = New System.Drawing.Point(139, 97)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(126, 22)
        Me.dtStart.TabIndex = 37
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 15)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Effectivity End Date :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 15)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Effectivity Start Date :"
        '
        'txtRegionCode
        '
        Me.txtRegionCode.BackColor = System.Drawing.Color.White
        Me.txtRegionCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRegionCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegionCode.Location = New System.Drawing.Point(266, 49)
        Me.txtRegionCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtRegionCode.Multiline = True
        Me.txtRegionCode.Name = "txtRegionCode"
        Me.txtRegionCode.Size = New System.Drawing.Size(254, 20)
        Me.txtRegionCode.TabIndex = 29
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(6, 75)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(129, 15)
        Me.LinkLabel1.TabIndex = 28
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "District Sales Manager :"
        '
        'txtSalesManagerCode
        '
        Me.txtSalesManagerCode.BackColor = System.Drawing.Color.White
        Me.txtSalesManagerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesManagerCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesManagerCode.Location = New System.Drawing.Point(139, 72)
        Me.txtSalesManagerCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSalesManagerCode.Name = "txtSalesManagerCode"
        Me.txtSalesManagerCode.Size = New System.Drawing.Size(125, 20)
        Me.txtSalesManagerCode.TabIndex = 27
        '
        'txtSalesManagerName
        '
        Me.txtSalesManagerName.BackColor = System.Drawing.Color.White
        Me.txtSalesManagerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesManagerName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesManagerName.Location = New System.Drawing.Point(266, 72)
        Me.txtSalesManagerName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSalesManagerName.Name = "txtSalesManagerName"
        Me.txtSalesManagerName.Size = New System.Drawing.Size(254, 20)
        Me.txtSalesManagerName.TabIndex = 26
        '
        'cmbRegionCode
        '
        Me.cmbRegionCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbRegionCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRegionCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRegionCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRegionCode.FormattingEnabled = True
        Me.cmbRegionCode.Location = New System.Drawing.Point(140, 49)
        Me.cmbRegionCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbRegionCode.Name = "cmbRegionCode"
        Me.cmbRegionCode.Size = New System.Drawing.Size(125, 21)
        Me.cmbRegionCode.TabIndex = 23
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.BackColor = System.Drawing.Color.Transparent
        Me.lblCode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCode.Location = New System.Drawing.Point(20, 52)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(115, 15)
        Me.lblCode.TabIndex = 18
        Me.lblCode.Text = "Sales Division Code :"
        '
        'txtdistrictCode
        '
        Me.txtdistrictCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdistrictCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdistrictCode.Location = New System.Drawing.Point(139, 27)
        Me.txtdistrictCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtdistrictCode.Name = "txtdistrictCode"
        Me.txtdistrictCode.Size = New System.Drawing.Size(125, 20)
        Me.txtdistrictCode.TabIndex = 20
        '
        'lbldistrictCode
        '
        Me.lbldistrictCode.AutoSize = True
        Me.lbldistrictCode.BackColor = System.Drawing.Color.Transparent
        Me.lbldistrictCode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldistrictCode.Location = New System.Drawing.Point(54, 30)
        Me.lbldistrictCode.Name = "lbldistrictCode"
        Me.lbldistrictCode.Size = New System.Drawing.Size(81, 15)
        Me.lbldistrictCode.TabIndex = 22
        Me.lbldistrictCode.Text = "District Code :"
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(266, 26)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(172, 20)
        Me.txtDescription.TabIndex = 21
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
        Me.tbListing.Size = New System.Drawing.Size(778, 328)
        Me.tbListing.TabIndex = 1
        Me.tbListing.Text = "Listing"
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(432, 5)
        Me.btnFilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(79, 22)
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
        Me.cmbfilter.FormattingEnabled = True
        Me.cmbfilter.Items.AddRange(New Object() {"All", "RegionCode", "DistrictCode", "Description"})
        Me.cmbfilter.Location = New System.Drawing.Point(67, 6)
        Me.cmbfilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbfilter.Name = "cmbfilter"
        Me.cmbfilter.Size = New System.Drawing.Size(146, 22)
        Me.cmbfilter.TabIndex = 2
        '
        'lblSelection
        '
        Me.lblSelection.AutoSize = True
        Me.lblSelection.Location = New System.Drawing.Point(6, 15)
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
        Me.GridListing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCode, Me.colSalesDivisionName, Me.colDistrictCode, Me.colDescription, Me.colEffectivityStartDate, Me.colEffectivityEndDate, Me.colStatus})
        Me.GridListing.Location = New System.Drawing.Point(4, 37)
        Me.GridListing.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridListing.Name = "GridListing"
        Me.GridListing.Size = New System.Drawing.Size(771, 287)
        Me.GridListing.TabIndex = 0
        '
        'colCode
        '
        Me.colCode.HeaderText = "Sales Division Code"
        Me.colCode.Name = "colCode"
        Me.colCode.ReadOnly = True
        Me.colCode.Width = 130
        '
        'colSalesDivisionName
        '
        Me.colSalesDivisionName.HeaderText = "Sales Division Name"
        Me.colSalesDivisionName.Name = "colSalesDivisionName"
        Me.colSalesDivisionName.Width = 210
        '
        'colDistrictCode
        '
        Me.colDistrictCode.HeaderText = "District Code"
        Me.colDistrictCode.Name = "colDistrictCode"
        Me.colDistrictCode.ReadOnly = True
        '
        'colDescription
        '
        Me.colDescription.HeaderText = "District Name"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        Me.colDescription.Width = 350
        '
        'colEffectivityStartDate
        '
        Me.colEffectivityStartDate.HeaderText = "Effectivity Start Date"
        Me.colEffectivityStartDate.Name = "colEffectivityStartDate"
        '
        'colEffectivityEndDate
        '
        Me.colEffectivityEndDate.HeaderText = "Effectivity End Date"
        Me.colEffectivityEndDate.Name = "colEffectivityEndDate"
        '
        'colStatus
        '
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.btnEdit, Me.btnDelete, Me.btnSave, Me.ToolStripSeparator2, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(786, 25)
        Me.ToolStrip1.TabIndex = 13
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
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 58)
        Me.Panel1.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(15, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "DSM to District Assignment"
        '
        'ucMasterSTDistrict
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.MainTab)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ucMasterSTDistrict"
        Me.Size = New System.Drawing.Size(786, 438)
        Me.MainTab.ResumeLayout(False)
        Me.tbEntry.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbListing.ResumeLayout(False)
        Me.tbListing.PerformLayout()
        CType(Me.GridListing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MainTab As System.Windows.Forms.TabControl
    Friend WithEvents tbEntry As System.Windows.Forms.TabPage
    Friend WithEvents tbListing As System.Windows.Forms.TabPage
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents cmbfilter As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelection As System.Windows.Forms.Label
    Friend WithEvents GridListing As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents colCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSalesDivisionName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDistrictCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEffectivityStartDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEffectivityEndDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDistrictName As System.Windows.Forms.ComboBox
    Friend WithEvents txtDivisionCode As System.Windows.Forms.TextBox
    Friend WithEvents cboDistrictCode As System.Windows.Forms.ComboBox
    Friend WithEvents chkIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRegionCode As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtSalesManagerCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesManagerName As System.Windows.Forms.TextBox
    Friend WithEvents cmbRegionCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtdistrictCode As System.Windows.Forms.TextBox
    Friend WithEvents lbldistrictCode As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox

End Class
