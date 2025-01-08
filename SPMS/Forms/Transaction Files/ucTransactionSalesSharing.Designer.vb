<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucTransactionSalesSharing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucTransactionSalesSharing))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnAdd = New System.Windows.Forms.ToolStripButton
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.MainTab = New System.Windows.Forms.TabControl
        Me.tbEntry = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgDetail = New System.Windows.Forms.DataGridView
        Me.colSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colItemDiv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColTercode = New System.Windows.Forms.DataGridViewLinkColumn
        Me.colTerritory = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTerritoryName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMRCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSharing = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtTo = New System.Windows.Forms.DateTimePicker
        Me.dtFrom = New System.Windows.Forms.DateTimePicker
        Me.txtCustomerCode = New System.Windows.Forms.TextBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.lnkDeleteSelected = New System.Windows.Forms.LinkLabel
        Me.cmbitemdiv = New System.Windows.Forms.ComboBox
        Me.txtcomname = New System.Windows.Forms.TextBox
        Me.btninsert = New System.Windows.Forms.Button
        Me.txtCustomerName = New System.Windows.Forms.TextBox
        Me.cmbYear = New System.Windows.Forms.ComboBox
        Me.cmbMonth = New System.Windows.Forms.ComboBox
        Me.cmbCustomerCode = New System.Windows.Forms.ComboBox
        Me.cmbCompany = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbListing = New System.Windows.Forms.TabPage
        Me.btnFilter = New System.Windows.Forms.Button
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.cmbfilter = New System.Windows.Forms.ComboBox
        Me.lblSelection = New System.Windows.Forms.Label
        Me.GridListing = New System.Windows.Forms.DataGridView
        Me.colComID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCustomerCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colShipToCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCutMo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCutYear = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        Me.MainTab.SuspendLayout()
        Me.tbEntry.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbListing.SuspendLayout()
        CType(Me.GridListing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.btnEdit, Me.btnDelete, Me.btnSave, Me.ToolStripSeparator2, Me.btnClose, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(977, 25)
        Me.ToolStrip1.TabIndex = 15
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
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(131, 22)
        Me.ToolStripButton1.Text = "Auto Create Sharing"
        '
        'MainTab
        '
        Me.MainTab.Controls.Add(Me.tbEntry)
        Me.MainTab.Controls.Add(Me.tbListing)
        Me.MainTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTab.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainTab.Location = New System.Drawing.Point(0, 83)
        Me.MainTab.Name = "MainTab"
        Me.MainTab.SelectedIndex = 0
        Me.MainTab.Size = New System.Drawing.Size(977, 557)
        Me.MainTab.TabIndex = 16
        '
        'tbEntry
        '
        Me.tbEntry.BackColor = System.Drawing.Color.White
        Me.tbEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbEntry.Controls.Add(Me.GroupBox1)
        Me.tbEntry.Location = New System.Drawing.Point(4, 23)
        Me.tbEntry.Name = "tbEntry"
        Me.tbEntry.Padding = New System.Windows.Forms.Padding(3)
        Me.tbEntry.Size = New System.Drawing.Size(969, 530)
        Me.tbEntry.TabIndex = 0
        Me.tbEntry.Text = "Entry"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgDetail)
        Me.GroupBox1.Controls.Add(Me.dtTo)
        Me.GroupBox1.Controls.Add(Me.dtFrom)
        Me.GroupBox1.Controls.Add(Me.txtCustomerCode)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.lnkDeleteSelected)
        Me.GroupBox1.Controls.Add(Me.cmbitemdiv)
        Me.GroupBox1.Controls.Add(Me.txtcomname)
        Me.GroupBox1.Controls.Add(Me.btninsert)
        Me.GroupBox1.Controls.Add(Me.txtCustomerName)
        Me.GroupBox1.Controls.Add(Me.cmbYear)
        Me.GroupBox1.Controls.Add(Me.cmbMonth)
        Me.GroupBox1.Controls.Add(Me.cmbCustomerCode)
        Me.GroupBox1.Controls.Add(Me.cmbCompany)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(945, 501)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'dgDetail
        '
        Me.dgDetail.AllowUserToAddRows = False
        Me.dgDetail.AllowUserToDeleteRows = False
        Me.dgDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelect, Me.colItemDiv, Me.colDescription, Me.ColTercode, Me.colTerritory, Me.colTerritoryName, Me.colMRCode, Me.colRep, Me.colSharing})
        Me.dgDetail.Location = New System.Drawing.Point(13, 152)
        Me.dgDetail.Name = "dgDetail"
        Me.dgDetail.RowHeadersVisible = False
        Me.dgDetail.Size = New System.Drawing.Size(921, 333)
        Me.dgDetail.TabIndex = 24
        '
        'colSelect
        '
        Me.colSelect.HeaderText = ""
        Me.colSelect.Name = "colSelect"
        Me.colSelect.Width = 30
        '
        'colItemDiv
        '
        Me.colItemDiv.HeaderText = "ItemDivision"
        Me.colItemDiv.Name = "colItemDiv"
        Me.colItemDiv.ReadOnly = True
        '
        'colDescription
        '
        Me.colDescription.HeaderText = "Division Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        Me.colDescription.Width = 200
        '
        'ColTercode
        '
        Me.ColTercode.HeaderText = "TerritoryCode"
        Me.ColTercode.Name = "ColTercode"
        Me.ColTercode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColTercode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colTerritory
        '
        Me.colTerritory.HeaderText = "Territory"
        Me.colTerritory.Name = "colTerritory"
        Me.colTerritory.ReadOnly = True
        Me.colTerritory.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colTerritory.Visible = False
        '
        'colTerritoryName
        '
        Me.colTerritoryName.HeaderText = "Territoryname"
        Me.colTerritoryName.Name = "colTerritoryName"
        Me.colTerritoryName.ReadOnly = True
        Me.colTerritoryName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colTerritoryName.Width = 250
        '
        'colMRCode
        '
        Me.colMRCode.HeaderText = "MRCode"
        Me.colMRCode.Name = "colMRCode"
        Me.colMRCode.ReadOnly = True
        '
        'colRep
        '
        Me.colRep.HeaderText = "MR Name"
        Me.colRep.Name = "colRep"
        Me.colRep.ReadOnly = True
        Me.colRep.Width = 250
        '
        'colSharing
        '
        Me.colSharing.HeaderText = "Sharing %"
        Me.colSharing.Name = "colSharing"
        '
        'dtTo
        '
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(136, 58)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(100, 20)
        Me.dtTo.TabIndex = 32
        '
        'dtFrom
        '
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFrom.Location = New System.Drawing.Point(136, 30)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(100, 20)
        Me.dtFrom.TabIndex = 31
        '
        'txtCustomerCode
        '
        Me.txtCustomerCode.BackColor = System.Drawing.Color.White
        Me.txtCustomerCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerCode.Location = New System.Drawing.Point(136, 114)
        Me.txtCustomerCode.Name = "txtCustomerCode"
        Me.txtCustomerCode.ReadOnly = True
        Me.txtCustomerCode.Size = New System.Drawing.Size(104, 22)
        Me.txtCustomerCode.TabIndex = 30
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(15, 117)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(92, 13)
        Me.LinkLabel1.TabIndex = 29
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Customer Code :"
        '
        'lnkDeleteSelected
        '
        Me.lnkDeleteSelected.AutoSize = True
        Me.lnkDeleteSelected.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkDeleteSelected.Location = New System.Drawing.Point(13, 135)
        Me.lnkDeleteSelected.Name = "lnkDeleteSelected"
        Me.lnkDeleteSelected.Size = New System.Drawing.Size(86, 13)
        Me.lnkDeleteSelected.TabIndex = 28
        Me.lnkDeleteSelected.TabStop = True
        Me.lnkDeleteSelected.Text = "Delete Selected"
        '
        'cmbitemdiv
        '
        Me.cmbitemdiv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbitemdiv.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbitemdiv.FormattingEnabled = True
        Me.cmbitemdiv.Location = New System.Drawing.Point(710, 117)
        Me.cmbitemdiv.Name = "cmbitemdiv"
        Me.cmbitemdiv.Size = New System.Drawing.Size(104, 21)
        Me.cmbitemdiv.TabIndex = 27
        Me.cmbitemdiv.Visible = False
        '
        'txtcomname
        '
        Me.txtcomname.BackColor = System.Drawing.Color.White
        Me.txtcomname.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcomname.Location = New System.Drawing.Point(246, 87)
        Me.txtcomname.Name = "txtcomname"
        Me.txtcomname.ReadOnly = True
        Me.txtcomname.Size = New System.Drawing.Size(282, 22)
        Me.txtcomname.TabIndex = 26
        '
        'btninsert
        '
        Me.btninsert.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btninsert.Location = New System.Drawing.Point(615, 117)
        Me.btninsert.Name = "btninsert"
        Me.btninsert.Size = New System.Drawing.Size(86, 26)
        Me.btninsert.TabIndex = 25
        Me.btninsert.Text = "Add Sharing"
        Me.btninsert.UseVisualStyleBackColor = True
        Me.btninsert.Visible = False
        '
        'txtCustomerName
        '
        Me.txtCustomerName.BackColor = System.Drawing.Color.White
        Me.txtCustomerName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerName.Location = New System.Drawing.Point(246, 114)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.ReadOnly = True
        Me.txtCustomerName.Size = New System.Drawing.Size(282, 22)
        Me.txtCustomerName.TabIndex = 23
        '
        'cmbYear
        '
        Me.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Location = New System.Drawing.Point(710, 60)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(104, 21)
        Me.cmbYear.TabIndex = 22
        Me.cmbYear.Visible = False
        '
        'cmbMonth
        '
        Me.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonth.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cmbMonth.Location = New System.Drawing.Point(710, 90)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(104, 21)
        Me.cmbMonth.TabIndex = 21
        Me.cmbMonth.Visible = False
        '
        'cmbCustomerCode
        '
        Me.cmbCustomerCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCustomerCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCustomerCode.FormattingEnabled = True
        Me.cmbCustomerCode.Location = New System.Drawing.Point(710, 32)
        Me.cmbCustomerCode.Name = "cmbCustomerCode"
        Me.cmbCustomerCode.Size = New System.Drawing.Size(104, 21)
        Me.cmbCustomerCode.TabIndex = 20
        Me.cmbCustomerCode.Visible = False
        '
        'cmbCompany
        '
        Me.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCompany.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCompany.FormattingEnabled = True
        Me.cmbCompany.Location = New System.Drawing.Point(136, 87)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.Size = New System.Drawing.Size(104, 21)
        Me.cmbCompany.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Effectivity Date From :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "To :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(609, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Customer Code :"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Channel :"
        '
        'tbListing
        '
        Me.tbListing.BackColor = System.Drawing.Color.White
        Me.tbListing.Controls.Add(Me.btnFilter)
        Me.tbListing.Controls.Add(Me.txtFilter)
        Me.tbListing.Controls.Add(Me.cmbfilter)
        Me.tbListing.Controls.Add(Me.lblSelection)
        Me.tbListing.Controls.Add(Me.GridListing)
        Me.tbListing.Location = New System.Drawing.Point(4, 23)
        Me.tbListing.Name = "tbListing"
        Me.tbListing.Padding = New System.Windows.Forms.Padding(3)
        Me.tbListing.Size = New System.Drawing.Size(969, 530)
        Me.tbListing.TabIndex = 1
        Me.tbListing.Text = "Listing"
        '
        'btnFilter
        '
        Me.btnFilter.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.Location = New System.Drawing.Point(432, 6)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(79, 22)
        Me.btnFilter.TabIndex = 4
        Me.btnFilter.Text = "Filter "
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'txtFilter
        '
        Me.txtFilter.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilter.Location = New System.Drawing.Point(219, 6)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(207, 22)
        Me.txtFilter.TabIndex = 3
        '
        'cmbfilter
        '
        Me.cmbfilter.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbfilter.FormattingEnabled = True
        Me.cmbfilter.Items.AddRange(New Object() {"CompanyCode", "CustomerCode", "CustomerName", "Month", "Year"})
        Me.cmbfilter.Location = New System.Drawing.Point(67, 6)
        Me.cmbfilter.Name = "cmbfilter"
        Me.cmbfilter.Size = New System.Drawing.Size(146, 21)
        Me.cmbfilter.TabIndex = 2
        '
        'lblSelection
        '
        Me.lblSelection.AutoSize = True
        Me.lblSelection.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelection.Location = New System.Drawing.Point(6, 15)
        Me.lblSelection.Name = "lblSelection"
        Me.lblSelection.Size = New System.Drawing.Size(60, 13)
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
        Me.GridListing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colComID, Me.colCustomerCode, Me.colShipToCode, Me.colCustomerName, Me.colCutMo, Me.colCutYear})
        Me.GridListing.Location = New System.Drawing.Point(9, 37)
        Me.GridListing.Name = "GridListing"
        Me.GridListing.Size = New System.Drawing.Size(941, 487)
        Me.GridListing.TabIndex = 0
        '
        'colComID
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colComID.DefaultCellStyle = DataGridViewCellStyle1
        Me.colComID.HeaderText = "Channel ID"
        Me.colComID.Name = "colComID"
        Me.colComID.ReadOnly = True
        '
        'colCustomerCode
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCustomerCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.colCustomerCode.HeaderText = "Customer Code"
        Me.colCustomerCode.Name = "colCustomerCode"
        Me.colCustomerCode.ReadOnly = True
        Me.colCustomerCode.Width = 130
        '
        'colShipToCode
        '
        Me.colShipToCode.HeaderText = "Ship To Code"
        Me.colShipToCode.Name = "colShipToCode"
        Me.colShipToCode.ReadOnly = True
        '
        'colCustomerName
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCustomerName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colCustomerName.HeaderText = "Customer Name"
        Me.colCustomerName.Name = "colCustomerName"
        Me.colCustomerName.ReadOnly = True
        Me.colCustomerName.Width = 310
        '
        'colCutMo
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCutMo.DefaultCellStyle = DataGridViewCellStyle4
        Me.colCutMo.HeaderText = "Start Date"
        Me.colCutMo.Name = "colCutMo"
        Me.colCutMo.ReadOnly = True
        '
        'colCutYear
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCutYear.DefaultCellStyle = DataGridViewCellStyle5
        Me.colCutYear.HeaderText = "End Date"
        Me.colCutYear.Name = "colCutYear"
        Me.colCutYear.ReadOnly = True
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
        Me.Panel1.Size = New System.Drawing.Size(977, 58)
        Me.Panel1.TabIndex = 14
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
        Me.Label5.Text = "Sales Sharing"
        '
        'ucTransactionSalesSharing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.MainTab)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucTransactionSalesSharing"
        Me.Size = New System.Drawing.Size(977, 640)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MainTab.ResumeLayout(False)
        Me.tbEntry.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbListing.ResumeLayout(False)
        Me.tbListing.PerformLayout()
        CType(Me.GridListing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
    Friend WithEvents cmbitemdiv As System.Windows.Forms.ComboBox
    Friend WithEvents txtcomname As System.Windows.Forms.TextBox
    Friend WithEvents btninsert As System.Windows.Forms.Button
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCustomerCode As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCompany As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbListing As System.Windows.Forms.TabPage
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents cmbfilter As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelection As System.Windows.Forms.Label
    Friend WithEvents GridListing As System.Windows.Forms.DataGridView
    Friend WithEvents lnkDeleteSelected As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents colComID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCustomerCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colShipToCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCutMo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCutYear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgDetail As System.Windows.Forms.DataGridView
    Friend WithEvents colSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colItemDiv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTercode As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents colTerritory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTerritoryName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMRCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSharing As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
