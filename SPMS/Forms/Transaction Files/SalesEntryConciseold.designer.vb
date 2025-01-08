<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesEntryConciseold
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalesEntryConciseold))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnNew = New System.Windows.Forms.ToolStripButton
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnFind = New System.Windows.Forms.ToolStripButton
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.btnUndo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnApprove = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnCancel = New System.Windows.Forms.ToolStripButton
        Me.btnRelease = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.btnClose = New System.Windows.Forms.ToolStripButton
        Me.btnSelectStocks = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtSalesmancode = New System.Windows.Forms.TextBox
        Me.txtSalesmanCodes = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.lnkDistributor = New System.Windows.Forms.LinkLabel
        Me.txtCompany = New System.Windows.Forms.TextBox
        Me.txtCompanyName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtSOdate = New System.Windows.Forms.DateTimePicker
        Me.lblBillingDate = New System.Windows.Forms.Label
        Me.lblDistInvoiceNo = New System.Windows.Forms.Label
        Me.txtInvoiceNumber = New System.Windows.Forms.TextBox
        Me.txtCustomerShipTo = New System.Windows.Forms.TextBox
        Me.lblShipToAddress = New System.Windows.Forms.Label
        Me.txtCustromerShioToAddress = New System.Windows.Forms.TextBox
        Me.lnkCustomer = New System.Windows.Forms.LinkLabel
        Me.txtCustomer = New System.Windows.Forms.TextBox
        Me.lblBillingNo = New System.Windows.Forms.Label
        Me.txtSONumber = New System.Windows.Forms.TextBox
        Me.dtInvoiceDate = New System.Windows.Forms.DateTimePicker
        Me.lblOrderDate = New System.Windows.Forms.Label
        Me.lblAddress = New System.Windows.Forms.Label
        Me.txtCustomerAddress = New System.Windows.Forms.TextBox
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dgDetails = New System.Windows.Forms.DataGridView
        Me.colSelectedDetails = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colamount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSalesAgent = New System.Windows.Forms.DataGridViewLinkColumn
        Me.colShare = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDistrictCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDistrictDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colIsFree = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colListPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDiscFormula = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDiscAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCreditedAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.lnkRemoveItem = New System.Windows.Forms.LinkLabel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtGrossTotal = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtDiscFormula = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtDiscTotal = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtNetTotal = New System.Windows.Forms.TextBox
        Me.UcItemGrid1 = New SPMSOPCI.UCItemGrid
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BasePageHeader1
        '
        Me.BasePageHeader1.HeaderText = "Sales Order"
        Me.BasePageHeader1.Size = New System.Drawing.Size(1412, 53)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.ToolStripSeparator1, Me.btnFind, Me.btnSave, Me.btnUndo, Me.ToolStripSeparator3, Me.btnApprove, Me.ToolStripSeparator2, Me.btnCancel, Me.btnRelease, Me.ToolStripSeparator4, Me.btnClose, Me.btnSelectStocks})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 53)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(1412, 25)
        Me.ToolStrip1.TabIndex = 174
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(48, 22)
        Me.btnNew.Tag = "btnNew"
        Me.btnNew.Text = "&New"
        Me.btnNew.ToolTipText = "Click New to add new records on sales order."
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(45, 22)
        Me.btnEdit.Tag = "btnEdit"
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.ToolTipText = "Click Edit button to edit records on sales order."
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.White
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(58, 22)
        Me.btnDelete.Tag = "btnDelete"
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.ToolTipText = "Click Delete button to delete  the entry."
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
        Me.btnFind.Size = New System.Drawing.Size(47, 22)
        Me.btnFind.Tag = "btnFind"
        Me.btnFind.Text = "&Find"
        Me.btnFind.ToolTipText = "Click Find button to search records."
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.White
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(51, 22)
        Me.btnSave.Tag = "btnSave"
        Me.btnSave.Text = "&Save"
        Me.btnSave.ToolTipText = "Click Save to commit the changes."
        '
        'btnUndo
        '
        Me.btnUndo.Image = CType(resources.GetObject("btnUndo.Image"), System.Drawing.Image)
        Me.btnUndo.ImageTransparentColor = System.Drawing.Color.White
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(52, 22)
        Me.btnUndo.Tag = "btnUndo"
        Me.btnUndo.Text = "&Undo"
        Me.btnUndo.ToolTipText = "Click Undo button to undo the changes."
        Me.btnUndo.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnApprove
        '
        Me.btnApprove.Image = CType(resources.GetObject("btnApprove.Image"), System.Drawing.Image)
        Me.btnApprove.ImageTransparentColor = System.Drawing.Color.White
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(68, 22)
        Me.btnApprove.Text = "Approve"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator2.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(59, 22)
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.Visible = False
        '
        'btnRelease
        '
        Me.btnRelease.Image = CType(resources.GetObject("btnRelease.Image"), System.Drawing.Image)
        Me.btnRelease.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRelease.Name = "btnRelease"
        Me.btnRelease.Size = New System.Drawing.Size(65, 22)
        Me.btnRelease.Text = "Release"
        Me.btnRelease.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.White
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(53, 22)
        Me.btnClose.Tag = "btnClose"
        Me.btnClose.Text = "Close"
        Me.btnClose.ToolTipText = "Click Close button to exit on this application."
        '
        'btnSelectStocks
        '
        Me.btnSelectStocks.Image = CType(resources.GetObject("btnSelectStocks.Image"), System.Drawing.Image)
        Me.btnSelectStocks.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSelectStocks.Name = "btnSelectStocks"
        Me.btnSelectStocks.Size = New System.Drawing.Size(90, 22)
        Me.btnSelectStocks.Text = "Select Stocks"
        Me.btnSelectStocks.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtSalesmancode)
        Me.Panel1.Controls.Add(Me.txtSalesmanCodes)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.lnkDistributor)
        Me.Panel1.Controls.Add(Me.txtCompany)
        Me.Panel1.Controls.Add(Me.txtCompanyName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtSOdate)
        Me.Panel1.Controls.Add(Me.lblBillingDate)
        Me.Panel1.Controls.Add(Me.lblDistInvoiceNo)
        Me.Panel1.Controls.Add(Me.txtInvoiceNumber)
        Me.Panel1.Controls.Add(Me.txtCustomerShipTo)
        Me.Panel1.Controls.Add(Me.lblShipToAddress)
        Me.Panel1.Controls.Add(Me.txtCustromerShioToAddress)
        Me.Panel1.Controls.Add(Me.lnkCustomer)
        Me.Panel1.Controls.Add(Me.txtCustomer)
        Me.Panel1.Controls.Add(Me.lblBillingNo)
        Me.Panel1.Controls.Add(Me.txtSONumber)
        Me.Panel1.Controls.Add(Me.dtInvoiceDate)
        Me.Panel1.Controls.Add(Me.lblOrderDate)
        Me.Panel1.Controls.Add(Me.lblAddress)
        Me.Panel1.Controls.Add(Me.txtCustomerAddress)
        Me.Panel1.Location = New System.Drawing.Point(3, 81)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1075, 193)
        Me.Panel1.TabIndex = 177
        '
        'txtSalesmancode
        '
        Me.txtSalesmancode.Location = New System.Drawing.Point(480, 34)
        Me.txtSalesmancode.Name = "txtSalesmancode"
        Me.txtSalesmancode.Size = New System.Drawing.Size(237, 21)
        Me.txtSalesmancode.TabIndex = 203
        '
        'txtSalesmanCodes
        '
        Me.txtSalesmanCodes.Location = New System.Drawing.Point(480, 7)
        Me.txtSalesmanCodes.Name = "txtSalesmanCodes"
        Me.txtSalesmanCodes.Size = New System.Drawing.Size(160, 21)
        Me.txtSalesmanCodes.TabIndex = 202
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(368, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 201
        Me.Label2.Text = "Salesman Name :"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(368, 15)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(87, 13)
        Me.LinkLabel1.TabIndex = 200
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Salesman Code :"
        '
        'lnkDistributor
        '
        Me.lnkDistributor.AutoSize = True
        Me.lnkDistributor.Location = New System.Drawing.Point(49, 67)
        Me.lnkDistributor.Name = "lnkDistributor"
        Me.lnkDistributor.Size = New System.Drawing.Size(59, 13)
        Me.lnkDistributor.TabIndex = 199
        Me.lnkDistributor.TabStop = True
        Me.lnkDistributor.Text = "Company :"
        '
        'txtCompany
        '
        Me.txtCompany.BackColor = System.Drawing.Color.White
        Me.txtCompany.Location = New System.Drawing.Point(113, 64)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.ReadOnly = True
        Me.txtCompany.Size = New System.Drawing.Size(224, 21)
        Me.txtCompany.TabIndex = 198
        '
        'txtCompanyName
        '
        Me.txtCompanyName.BackColor = System.Drawing.Color.White
        Me.txtCompanyName.Location = New System.Drawing.Point(349, 64)
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.ReadOnly = True
        Me.txtCompanyName.Size = New System.Drawing.Size(368, 21)
        Me.txtCompanyName.TabIndex = 195
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(459, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 192
        Me.Label1.Text = "Ship To :"
        '
        'dtSOdate
        '
        Me.dtSOdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtSOdate.Location = New System.Drawing.Point(848, 11)
        Me.dtSOdate.Name = "dtSOdate"
        Me.dtSOdate.Size = New System.Drawing.Size(174, 21)
        Me.dtSOdate.TabIndex = 191
        Me.dtSOdate.Value = New Date(2007, 8, 17, 0, 0, 0, 0)
        '
        'lblBillingDate
        '
        Me.lblBillingDate.AutoSize = True
        Me.lblBillingDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBillingDate.Location = New System.Drawing.Point(733, 15)
        Me.lblBillingDate.Name = "lblBillingDate"
        Me.lblBillingDate.Size = New System.Drawing.Size(76, 13)
        Me.lblBillingDate.TabIndex = 190
        Me.lblBillingDate.Text = "Billing Date :"
        '
        'lblDistInvoiceNo
        '
        Me.lblDistInvoiceNo.AutoSize = True
        Me.lblDistInvoiceNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDistInvoiceNo.Location = New System.Drawing.Point(11, 40)
        Me.lblDistInvoiceNo.Name = "lblDistInvoiceNo"
        Me.lblDistInvoiceNo.Size = New System.Drawing.Size(97, 13)
        Me.lblDistInvoiceNo.TabIndex = 188
        Me.lblDistInvoiceNo.Text = "Dist.Invoice No.:"
        '
        'txtInvoiceNumber
        '
        Me.txtInvoiceNumber.BackColor = System.Drawing.Color.White
        Me.txtInvoiceNumber.Location = New System.Drawing.Point(113, 37)
        Me.txtInvoiceNumber.Name = "txtInvoiceNumber"
        Me.txtInvoiceNumber.Size = New System.Drawing.Size(224, 21)
        Me.txtInvoiceNumber.TabIndex = 189
        '
        'txtCustomerShipTo
        '
        Me.txtCustomerShipTo.BackColor = System.Drawing.Color.White
        Me.txtCustomerShipTo.Location = New System.Drawing.Point(585, 94)
        Me.txtCustomerShipTo.Name = "txtCustomerShipTo"
        Me.txtCustomerShipTo.ReadOnly = True
        Me.txtCustomerShipTo.Size = New System.Drawing.Size(437, 21)
        Me.txtCustomerShipTo.TabIndex = 186
        '
        'lblShipToAddress
        '
        Me.lblShipToAddress.AutoSize = True
        Me.lblShipToAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShipToAddress.Location = New System.Drawing.Point(459, 115)
        Me.lblShipToAddress.Name = "lblShipToAddress"
        Me.lblShipToAddress.Size = New System.Drawing.Size(91, 13)
        Me.lblShipToAddress.TabIndex = 184
        Me.lblShipToAddress.Text = "Ship To Address :"
        '
        'txtCustromerShioToAddress
        '
        Me.txtCustromerShioToAddress.BackColor = System.Drawing.Color.White
        Me.txtCustromerShioToAddress.Location = New System.Drawing.Point(585, 121)
        Me.txtCustromerShioToAddress.Multiline = True
        Me.txtCustromerShioToAddress.Name = "txtCustromerShioToAddress"
        Me.txtCustromerShioToAddress.ReadOnly = True
        Me.txtCustromerShioToAddress.Size = New System.Drawing.Size(437, 44)
        Me.txtCustromerShioToAddress.TabIndex = 185
        '
        'lnkCustomer
        '
        Me.lnkCustomer.AutoSize = True
        Me.lnkCustomer.Location = New System.Drawing.Point(48, 91)
        Me.lnkCustomer.Name = "lnkCustomer"
        Me.lnkCustomer.Size = New System.Drawing.Size(60, 13)
        Me.lnkCustomer.TabIndex = 183
        Me.lnkCustomer.TabStop = True
        Me.lnkCustomer.Text = "Customer :"
        '
        'txtCustomer
        '
        Me.txtCustomer.BackColor = System.Drawing.Color.White
        Me.txtCustomer.Location = New System.Drawing.Point(113, 91)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(325, 21)
        Me.txtCustomer.TabIndex = 182
        '
        'lblBillingNo
        '
        Me.lblBillingNo.AutoSize = True
        Me.lblBillingNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBillingNo.Location = New System.Drawing.Point(42, 15)
        Me.lblBillingNo.Name = "lblBillingNo"
        Me.lblBillingNo.Size = New System.Drawing.Size(66, 13)
        Me.lblBillingNo.TabIndex = 92
        Me.lblBillingNo.Text = "Billing No. :"
        '
        'txtSONumber
        '
        Me.txtSONumber.Location = New System.Drawing.Point(113, 12)
        Me.txtSONumber.Name = "txtSONumber"
        Me.txtSONumber.ReadOnly = True
        Me.txtSONumber.Size = New System.Drawing.Size(224, 21)
        Me.txtSONumber.TabIndex = 93
        '
        'dtInvoiceDate
        '
        Me.dtInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtInvoiceDate.Location = New System.Drawing.Point(848, 38)
        Me.dtInvoiceDate.Name = "dtInvoiceDate"
        Me.dtInvoiceDate.Size = New System.Drawing.Size(174, 21)
        Me.dtInvoiceDate.TabIndex = 94
        Me.dtInvoiceDate.Value = New Date(2007, 8, 17, 0, 0, 0, 0)
        '
        'lblOrderDate
        '
        Me.lblOrderDate.AutoSize = True
        Me.lblOrderDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderDate.Location = New System.Drawing.Point(733, 42)
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Size = New System.Drawing.Size(75, 13)
        Me.lblOrderDate.TabIndex = 95
        Me.lblOrderDate.Text = "Invoice Date :"
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress.Location = New System.Drawing.Point(55, 115)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(53, 13)
        Me.lblAddress.TabIndex = 96
        Me.lblAddress.Text = "Address :"
        '
        'txtCustomerAddress
        '
        Me.txtCustomerAddress.BackColor = System.Drawing.Color.White
        Me.txtCustomerAddress.Location = New System.Drawing.Point(113, 115)
        Me.txtCustomerAddress.Multiline = True
        Me.txtCustomerAddress.Name = "txtCustomerAddress"
        Me.txtCustomerAddress.ReadOnly = True
        Me.txtCustomerAddress.Size = New System.Drawing.Size(325, 44)
        Me.txtCustomerAddress.TabIndex = 97
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgDetails)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1100, 169)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Transaction Details"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgDetails
        '
        Me.dgDetails.AllowUserToAddRows = False
        Me.dgDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelectedDetails, Me.colamount, Me.colSalesAgent, Me.colShare, Me.colCode, Me.colDescription, Me.colDistrictCode, Me.colDistrictDesc, Me.colIsFree, Me.colQty, Me.colListPrice, Me.colDiscFormula, Me.colDiscAmount, Me.colTotal, Me.colCreditedAmount, Me.colRemarks})
        Me.dgDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgDetails.Location = New System.Drawing.Point(3, 3)
        Me.dgDetails.Name = "dgDetails"
        Me.dgDetails.RowHeadersVisible = False
        Me.dgDetails.Size = New System.Drawing.Size(1094, 163)
        Me.dgDetails.TabIndex = 181
        '
        'colSelectedDetails
        '
        Me.colSelectedDetails.HeaderText = ""
        Me.colSelectedDetails.Name = "colSelectedDetails"
        Me.colSelectedDetails.Width = 30
        '
        'colamount
        '
        Me.colamount.HeaderText = "Amount"
        Me.colamount.Name = "colamount"
        Me.colamount.Visible = False
        '
        'colSalesAgent
        '
        Me.colSalesAgent.HeaderText = "Sales Agent"
        Me.colSalesAgent.Name = "colSalesAgent"
        Me.colSalesAgent.Visible = False
        Me.colSalesAgent.Width = 200
        '
        'colShare
        '
        Me.colShare.HeaderText = "Share"
        Me.colShare.Name = "colShare"
        Me.colShare.Visible = False
        '
        'colCode
        '
        Me.colCode.HeaderText = "Code"
        Me.colCode.Name = "colCode"
        Me.colCode.ReadOnly = True
        Me.colCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colDescription
        '
        Me.colDescription.HeaderText = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        Me.colDescription.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colDescription.Width = 150
        '
        'colDistrictCode
        '
        Me.colDistrictCode.HeaderText = "Dist.Code"
        Me.colDistrictCode.Name = "colDistrictCode"
        Me.colDistrictCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDistrictCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colDistrictCode.Visible = False
        '
        'colDistrictDesc
        '
        Me.colDistrictDesc.HeaderText = "Dist.Desc."
        Me.colDistrictDesc.Name = "colDistrictDesc"
        Me.colDistrictDesc.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDistrictDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colDistrictDesc.Visible = False
        Me.colDistrictDesc.Width = 150
        '
        'colIsFree
        '
        Me.colIsFree.HeaderText = "Is Free"
        Me.colIsFree.Name = "colIsFree"
        Me.colIsFree.Width = 50
        '
        'colQty
        '
        Me.colQty.HeaderText = "Qty"
        Me.colQty.Name = "colQty"
        '
        'colListPrice
        '
        Me.colListPrice.HeaderText = "List Price"
        Me.colListPrice.Name = "colListPrice"
        Me.colListPrice.ReadOnly = True
        '
        'colDiscFormula
        '
        Me.colDiscFormula.HeaderText = "Disc.Formula"
        Me.colDiscFormula.Name = "colDiscFormula"
        '
        'colDiscAmount
        '
        Me.colDiscAmount.HeaderText = "Disc.Amount"
        Me.colDiscAmount.Name = "colDiscAmount"
        Me.colDiscAmount.ReadOnly = True
        '
        'colTotal
        '
        Me.colTotal.HeaderText = "Total"
        Me.colTotal.Name = "colTotal"
        Me.colTotal.ReadOnly = True
        '
        'colCreditedAmount
        '
        Me.colCreditedAmount.HeaderText = "Credited Amt"
        Me.colCreditedAmount.Name = "colCreditedAmount"
        Me.colCreditedAmount.Visible = False
        '
        'colRemarks
        '
        Me.colRemarks.HeaderText = "Remarks"
        Me.colRemarks.Name = "colRemarks"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(3, 293)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1108, 195)
        Me.TabControl1.TabIndex = 180
        '
        'lnkRemoveItem
        '
        Me.lnkRemoveItem.AutoSize = True
        Me.lnkRemoveItem.BackColor = System.Drawing.Color.Transparent
        Me.lnkRemoveItem.Location = New System.Drawing.Point(3, 277)
        Me.lnkRemoveItem.Name = "lnkRemoveItem"
        Me.lnkRemoveItem.Size = New System.Drawing.Size(71, 13)
        Me.lnkRemoveItem.TabIndex = 184
        Me.lnkRemoveItem.TabStop = True
        Me.lnkRemoveItem.Text = "Remove Item"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtRemarks)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.txtGrossTotal)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.txtDiscFormula)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txtDiscTotal)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtNetTotal)
        Me.Panel2.Location = New System.Drawing.Point(3, 2146)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1101, 131)
        Me.Panel2.TabIndex = 185
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 198
        Me.Label7.Text = "Remarks :"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.Location = New System.Drawing.Point(72, 21)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ReadOnly = True
        Me.txtRemarks.Size = New System.Drawing.Size(464, 80)
        Me.txtRemarks.TabIndex = 199
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(562, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 196
        Me.Label11.Text = "Gross Total :"
        '
        'txtGrossTotal
        '
        Me.txtGrossTotal.BackColor = System.Drawing.Color.White
        Me.txtGrossTotal.Location = New System.Drawing.Point(689, 8)
        Me.txtGrossTotal.Name = "txtGrossTotal"
        Me.txtGrossTotal.ReadOnly = True
        Me.txtGrossTotal.Size = New System.Drawing.Size(284, 21)
        Me.txtGrossTotal.TabIndex = 197
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(554, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 13)
        Me.Label10.TabIndex = 194
        Me.Label10.Text = "Disc.Formula :"
        '
        'txtDiscFormula
        '
        Me.txtDiscFormula.BackColor = System.Drawing.Color.White
        Me.txtDiscFormula.Location = New System.Drawing.Point(689, 32)
        Me.txtDiscFormula.Name = "txtDiscFormula"
        Me.txtDiscFormula.ReadOnly = True
        Me.txtDiscFormula.Size = New System.Drawing.Size(284, 21)
        Me.txtDiscFormula.TabIndex = 195
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(568, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 192
        Me.Label9.Text = "Disc. Total :"
        '
        'txtDiscTotal
        '
        Me.txtDiscTotal.BackColor = System.Drawing.Color.White
        Me.txtDiscTotal.Location = New System.Drawing.Point(689, 56)
        Me.txtDiscTotal.Name = "txtDiscTotal"
        Me.txtDiscTotal.ReadOnly = True
        Me.txtDiscTotal.Size = New System.Drawing.Size(284, 21)
        Me.txtDiscTotal.TabIndex = 193
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(575, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 190
        Me.Label8.Text = "Net Total :"
        '
        'txtNetTotal
        '
        Me.txtNetTotal.BackColor = System.Drawing.Color.White
        Me.txtNetTotal.Location = New System.Drawing.Point(689, 80)
        Me.txtNetTotal.Name = "txtNetTotal"
        Me.txtNetTotal.ReadOnly = True
        Me.txtNetTotal.Size = New System.Drawing.Size(284, 21)
        Me.txtNetTotal.TabIndex = 191
        '
        'UcItemGrid1
        '
        Me.UcItemGrid1.AutoSize = True
        Me.UcItemGrid1.BackColor = System.Drawing.Color.Transparent
        Me.UcItemGrid1.Location = New System.Drawing.Point(1181, 287)
        Me.UcItemGrid1.Name = "UcItemGrid1"
        Me.UcItemGrid1.Size = New System.Drawing.Size(231, 562)
        Me.UcItemGrid1.TabIndex = 181
        '
        'SalesEntryConciseold
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.UcItemGrid1)
        Me.Controls.Add(Me.lnkRemoveItem)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.HeaderText = "Billing Order"
        Me.Name = "SalesEntryConciseold"
        Me.Size = New System.Drawing.Size(1016, 431)
        Me.Controls.SetChildIndex(Me.BasePageHeader1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.lnkRemoveItem, 0)
        Me.Controls.SetChildIndex(Me.UcItemGrid1, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
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
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnApprove As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRelease As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSelectStocks As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblBillingDate As System.Windows.Forms.Label
    Friend WithEvents lblDistInvoiceNo As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerShipTo As System.Windows.Forms.TextBox
    Friend WithEvents lblShipToAddress As System.Windows.Forms.Label
    Friend WithEvents txtCustromerShioToAddress As System.Windows.Forms.TextBox
    Friend WithEvents lnkCustomer As System.Windows.Forms.LinkLabel
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents lblBillingNo As System.Windows.Forms.Label
    Friend WithEvents txtSONumber As System.Windows.Forms.TextBox
    Friend WithEvents dtInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblOrderDate As System.Windows.Forms.Label
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents txtCustomerAddress As System.Windows.Forms.TextBox
    Friend WithEvents dtSOdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgDetails As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents UcItemGrid1 As SPMSOPCI.UCItemGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents lnkDistributor As System.Windows.Forms.LinkLabel
    Friend WithEvents txtCompany As System.Windows.Forms.TextBox
    Friend WithEvents lnkRemoveItem As System.Windows.Forms.LinkLabel
    Friend WithEvents colSelectedDetails As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colamount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSalesAgent As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents colShare As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDistrictCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDistrictDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIsFree As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colListPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiscFormula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiscAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCreditedAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtSalesmancode As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesmanCodes As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtGrossTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDiscFormula As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDiscTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNetTotal As System.Windows.Forms.TextBox

End Class
