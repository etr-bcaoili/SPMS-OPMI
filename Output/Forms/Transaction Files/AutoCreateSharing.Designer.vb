<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutoCreateSharing
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtTo = New System.Windows.Forms.DateTimePicker
        Me.dtFrom = New System.Windows.Forms.DateTimePicker
        Me.txtcomname = New System.Windows.Forms.TextBox
        Me.cboCompany = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.lnkProcess = New System.Windows.Forms.LinkLabel
        Me.dgCustomers = New System.Windows.Forms.DataGridView
        Me.colSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colCustomerCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colShipToCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colShipToName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAddress1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAddress2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.txtItemdivisionName = New System.Windows.Forms.TextBox
        Me.cboItemDivision = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMS.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(671, 60)
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
        Me.Label5.Size = New System.Drawing.Size(190, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Auto Create Sales Sharing"
        '
        'dtTo
        '
        Me.dtTo.Enabled = False
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(549, 130)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(100, 20)
        Me.dtTo.TabIndex = 39
        '
        'dtFrom
        '
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFrom.Location = New System.Drawing.Point(549, 104)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(100, 20)
        Me.dtFrom.TabIndex = 38
        '
        'txtcomname
        '
        Me.txtcomname.BackColor = System.Drawing.Color.White
        Me.txtcomname.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcomname.Location = New System.Drawing.Point(195, 76)
        Me.txtcomname.Multiline = True
        Me.txtcomname.Name = "txtcomname"
        Me.txtcomname.ReadOnly = True
        Me.txtcomname.Size = New System.Drawing.Size(454, 20)
        Me.txtcomname.TabIndex = 37
        '
        'cboCompany
        '
        Me.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompany.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCompany.FormattingEnabled = True
        Me.cboCompany.Location = New System.Drawing.Point(90, 75)
        Me.cboCompany.Name = "cboCompany"
        Me.cboCompany.Size = New System.Drawing.Size(104, 21)
        Me.cboCompany.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(412, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Effectivity Date From :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(505, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "To :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(28, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Channel :"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.Controls.Add(Me.LinkLabel1)
        Me.Panel2.Controls.Add(Me.lnkProcess)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 155)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(671, 30)
        Me.Panel2.TabIndex = 40
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(626, 8)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(33, 13)
        Me.LinkLabel1.TabIndex = 1
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Close"
        '
        'lnkProcess
        '
        Me.lnkProcess.AutoSize = True
        Me.lnkProcess.Location = New System.Drawing.Point(550, 8)
        Me.lnkProcess.Name = "lnkProcess"
        Me.lnkProcess.Size = New System.Drawing.Size(70, 13)
        Me.lnkProcess.TabIndex = 0
        Me.lnkProcess.TabStop = True
        Me.lnkProcess.Text = "Start Process"
        '
        'dgCustomers
        '
        Me.dgCustomers.AllowUserToAddRows = False
        Me.dgCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCustomers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelect, Me.colCustomerCode, Me.colCustomerName, Me.colShipToCode, Me.colShipToName, Me.colAddress1, Me.colAddress2})
        Me.dgCustomers.Location = New System.Drawing.Point(12, 159)
        Me.dgCustomers.Name = "dgCustomers"
        Me.dgCustomers.RowHeadersVisible = False
        Me.dgCustomers.Size = New System.Drawing.Size(647, 255)
        Me.dgCustomers.TabIndex = 41
        '
        'colSelect
        '
        Me.colSelect.HeaderText = ""
        Me.colSelect.Name = "colSelect"
        Me.colSelect.Width = 30
        '
        'colCustomerCode
        '
        Me.colCustomerCode.HeaderText = "Customer Code"
        Me.colCustomerCode.Name = "colCustomerCode"
        Me.colCustomerCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCustomerCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colCustomerName
        '
        Me.colCustomerName.HeaderText = "Customer Name"
        Me.colCustomerName.Name = "colCustomerName"
        Me.colCustomerName.Width = 125
        '
        'colShipToCode
        '
        Me.colShipToCode.HeaderText = "Ship To Code"
        Me.colShipToCode.Name = "colShipToCode"
        Me.colShipToCode.Width = 125
        '
        'colShipToName
        '
        Me.colShipToName.HeaderText = "Ship To Name"
        Me.colShipToName.Name = "colShipToName"
        Me.colShipToName.Width = 150
        '
        'colAddress1
        '
        Me.colAddress1.HeaderText = "Ship To Address 1"
        Me.colAddress1.Name = "colAddress1"
        Me.colAddress1.Width = 200
        '
        'colAddress2
        '
        Me.colAddress2.HeaderText = "Ship To Address 2"
        Me.colAddress2.Name = "colAddress2"
        Me.colAddress2.Width = 200
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(448, 419)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(211, 13)
        Me.LinkLabel2.TabIndex = 42
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Create Auto Sharing for selected customers"
        '
        'txtItemdivisionName
        '
        Me.txtItemdivisionName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemdivisionName.Location = New System.Drawing.Point(194, 102)
        Me.txtItemdivisionName.Multiline = True
        Me.txtItemdivisionName.Name = "txtItemdivisionName"
        Me.txtItemdivisionName.Size = New System.Drawing.Size(187, 20)
        Me.txtItemdivisionName.TabIndex = 75
        '
        'cboItemDivision
        '
        Me.cboItemDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemDivision.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboItemDivision.FormattingEnabled = True
        Me.cboItemDivision.Location = New System.Drawing.Point(90, 102)
        Me.cboItemDivision.Name = "cboItemDivision"
        Me.cboItemDivision.Size = New System.Drawing.Size(104, 21)
        Me.cboItemDivision.TabIndex = 74
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(5, 106)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "Item Division :"
        '
        'AutoCreateSharing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(671, 185)
        Me.Controls.Add(Me.txtItemdivisionName)
        Me.Controls.Add(Me.cboItemDivision)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.dgCustomers)
        Me.Controls.Add(Me.dtTo)
        Me.Controls.Add(Me.dtFrom)
        Me.Controls.Add(Me.txtcomname)
        Me.Controls.Add(Me.cboCompany)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "AutoCreateSharing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Utility"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtcomname As System.Windows.Forms.TextBox
    Friend WithEvents cboCompany As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkProcess As System.Windows.Forms.LinkLabel
    Friend WithEvents dgCustomers As System.Windows.Forms.DataGridView
    Friend WithEvents colSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colCustomerCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colShipToCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colShipToName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAddress1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAddress2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtItemdivisionName As System.Windows.Forms.TextBox
    Friend WithEvents cboItemDivision As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
