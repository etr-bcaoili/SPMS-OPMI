<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SharingMapping
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnClose = New System.Windows.Forms.ToolStripButton
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
        Me.colsharing2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtcodenum = New System.Windows.Forms.TextBox
        Me.txtmonth = New System.Windows.Forms.TextBox
        Me.txtyear = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCustomerCode = New System.Windows.Forms.TextBox
        Me.lnkDeleteSelected = New System.Windows.Forms.LinkLabel
        Me.txtcustname = New System.Windows.Forms.TextBox
        Me.cmbCompany = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbListing = New System.Windows.Forms.TabPage
        Me.GridListing = New System.Windows.Forms.DataGridView
        Me.btnFilter = New System.Windows.Forms.Button
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.cmbfilter = New System.Windows.Forms.ComboBox
        Me.lblSelection = New System.Windows.Forms.Label
        Me.colComID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCustomerCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colShipToCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colcutMo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCutYear = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.MainTab.SuspendLayout()
        Me.tbEntry.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbListing.SuspendLayout()
        CType(Me.GridListing, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(918, 58)
        Me.Panel1.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(15, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = " Sharing  Mapping"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnEdit, Me.btnDelete, Me.btnSave, Me.ToolStripSeparator2, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(918, 25)
        Me.ToolStrip1.TabIndex = 16
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'MainTab
        '
        Me.MainTab.Controls.Add(Me.tbEntry)
        Me.MainTab.Controls.Add(Me.tbListing)
        Me.MainTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTab.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainTab.Location = New System.Drawing.Point(0, 83)
        Me.MainTab.Name = "MainTab"
        Me.MainTab.SelectedIndex = 0
        Me.MainTab.Size = New System.Drawing.Size(918, 500)
        Me.MainTab.TabIndex = 17
        '
        'tbEntry
        '
        Me.tbEntry.BackColor = System.Drawing.Color.White
        Me.tbEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbEntry.Controls.Add(Me.GroupBox1)
        Me.tbEntry.Location = New System.Drawing.Point(4, 23)
        Me.tbEntry.Name = "tbEntry"
        Me.tbEntry.Padding = New System.Windows.Forms.Padding(3)
        Me.tbEntry.Size = New System.Drawing.Size(910, 473)
        Me.tbEntry.TabIndex = 0
        Me.tbEntry.Text = "Entry"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgDetail)
        Me.GroupBox1.Controls.Add(Me.txtcodenum)
        Me.GroupBox1.Controls.Add(Me.txtmonth)
        Me.GroupBox1.Controls.Add(Me.txtyear)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtCustomerCode)
        Me.GroupBox1.Controls.Add(Me.lnkDeleteSelected)
        Me.GroupBox1.Controls.Add(Me.txtcustname)
        Me.GroupBox1.Controls.Add(Me.cmbCompany)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1355, 743)
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
        Me.dgDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelect, Me.colItemDiv, Me.colDescription, Me.ColTercode, Me.colTerritory, Me.colTerritoryName, Me.colMRCode, Me.colRep, Me.colSharing, Me.colsharing2})
        Me.dgDetail.Location = New System.Drawing.Point(18, 122)
        Me.dgDetail.Name = "dgDetail"
        Me.dgDetail.RowHeadersVisible = False
        Me.dgDetail.Size = New System.Drawing.Size(1331, 607)
        Me.dgDetail.TabIndex = 38
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
        Me.colDescription.Width = 150
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
        Me.colTerritoryName.Width = 450
        '
        'colMRCode
        '
        Me.colMRCode.HeaderText = "MRCode"
        Me.colMRCode.Name = "colMRCode"
        Me.colMRCode.ReadOnly = True
        Me.colMRCode.Width = 124
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
        'colsharing2
        '
        Me.colsharing2.HeaderText = "Column1"
        Me.colsharing2.Name = "colsharing2"
        Me.colsharing2.Visible = False
        '
        'txtcodenum
        '
        Me.txtcodenum.BackColor = System.Drawing.Color.White
        Me.txtcodenum.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcodenum.Location = New System.Drawing.Point(251, 67)
        Me.txtcodenum.Name = "txtcodenum"
        Me.txtcodenum.ReadOnly = True
        Me.txtcodenum.Size = New System.Drawing.Size(139, 22)
        Me.txtcodenum.TabIndex = 35
        '
        'txtmonth
        '
        Me.txtmonth.BackColor = System.Drawing.Color.White
        Me.txtmonth.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmonth.Location = New System.Drawing.Point(135, 67)
        Me.txtmonth.Name = "txtmonth"
        Me.txtmonth.ReadOnly = True
        Me.txtmonth.Size = New System.Drawing.Size(110, 22)
        Me.txtmonth.TabIndex = 34
        '
        'txtyear
        '
        Me.txtyear.BackColor = System.Drawing.Color.White
        Me.txtyear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtyear.Location = New System.Drawing.Point(135, 42)
        Me.txtyear.Name = "txtyear"
        Me.txtyear.ReadOnly = True
        Me.txtyear.Size = New System.Drawing.Size(111, 22)
        Me.txtyear.TabIndex = 33
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 14)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Month :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 14)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Year :"
        '
        'txtCustomerCode
        '
        Me.txtCustomerCode.BackColor = System.Drawing.Color.White
        Me.txtCustomerCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerCode.Location = New System.Drawing.Point(252, 40)
        Me.txtCustomerCode.Name = "txtCustomerCode"
        Me.txtCustomerCode.ReadOnly = True
        Me.txtCustomerCode.Size = New System.Drawing.Size(138, 22)
        Me.txtCustomerCode.TabIndex = 30
        '
        'lnkDeleteSelected
        '
        Me.lnkDeleteSelected.AutoSize = True
        Me.lnkDeleteSelected.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkDeleteSelected.Location = New System.Drawing.Point(29, 96)
        Me.lnkDeleteSelected.Name = "lnkDeleteSelected"
        Me.lnkDeleteSelected.Size = New System.Drawing.Size(86, 13)
        Me.lnkDeleteSelected.TabIndex = 28
        Me.lnkDeleteSelected.TabStop = True
        Me.lnkDeleteSelected.Text = "Delete Selected"
        '
        'txtcustname
        '
        Me.txtcustname.BackColor = System.Drawing.Color.White
        Me.txtcustname.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcustname.Location = New System.Drawing.Point(252, 12)
        Me.txtcustname.Name = "txtcustname"
        Me.txtcustname.ReadOnly = True
        Me.txtcustname.Size = New System.Drawing.Size(182, 22)
        Me.txtcustname.TabIndex = 26
        '
        'cmbCompany
        '
        Me.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCompany.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCompany.FormattingEnabled = True
        Me.cmbCompany.Location = New System.Drawing.Point(136, 13)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.Size = New System.Drawing.Size(110, 21)
        Me.cmbCompany.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Channel :"
        '
        'tbListing
        '
        Me.tbListing.BackColor = System.Drawing.Color.White
        Me.tbListing.Controls.Add(Me.GridListing)
        Me.tbListing.Controls.Add(Me.btnFilter)
        Me.tbListing.Controls.Add(Me.txtFilter)
        Me.tbListing.Controls.Add(Me.cmbfilter)
        Me.tbListing.Controls.Add(Me.lblSelection)
        Me.tbListing.Location = New System.Drawing.Point(4, 23)
        Me.tbListing.Name = "tbListing"
        Me.tbListing.Padding = New System.Windows.Forms.Padding(3)
        Me.tbListing.Size = New System.Drawing.Size(910, 473)
        Me.tbListing.TabIndex = 1
        Me.tbListing.Text = "Listing"
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
        Me.GridListing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colComID, Me.colCustomerCode, Me.colShipToCode, Me.colCustomerName, Me.colcutMo, Me.colCutYear})
        Me.GridListing.Location = New System.Drawing.Point(6, 34)
        Me.GridListing.Name = "GridListing"
        Me.GridListing.Size = New System.Drawing.Size(898, 433)
        Me.GridListing.TabIndex = 5
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
        'colComID
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colComID.DefaultCellStyle = DataGridViewCellStyle1
        Me.colComID.HeaderText = "Channel ID"
        Me.colComID.Name = "colComID"
        Me.colComID.ReadOnly = True
        Me.colComID.Width = 70
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
        Me.colShipToCode.Width = 70
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
        'colcutMo
        '
        Me.colcutMo.HeaderText = "Month"
        Me.colcutMo.Name = "colcutMo"
        Me.colcutMo.Width = 70
        '
        'colCutYear
        '
        Me.colCutYear.HeaderText = "Year"
        Me.colCutYear.Name = "colCutYear"
        Me.colCutYear.Width = 80
        '
        'SharingMapping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.MainTab)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "SharingMapping"
        Me.Size = New System.Drawing.Size(918, 583)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents MainTab As System.Windows.Forms.TabControl
    Friend WithEvents tbEntry As System.Windows.Forms.TabPage
    Friend WithEvents tbListing As System.Windows.Forms.TabPage
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents cmbfilter As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelection As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtcodenum As System.Windows.Forms.TextBox
    Friend WithEvents txtmonth As System.Windows.Forms.TextBox
    Friend WithEvents txtyear As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents lnkDeleteSelected As System.Windows.Forms.LinkLabel
    Friend WithEvents txtcustname As System.Windows.Forms.TextBox
    Friend WithEvents cmbCompany As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GridListing As System.Windows.Forms.DataGridView
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
    Friend WithEvents colsharing2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colComID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCustomerCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colShipToCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colcutMo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCutYear As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
