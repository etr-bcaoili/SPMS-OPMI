<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCCustomerMappingListing
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnfilter = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnClose = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbChannelName = New System.Windows.Forms.ComboBox
        Me.cmbChannel = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgdetails = New System.Windows.Forms.DataGridView
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colComid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCustomerCd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colShiptoCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colShiptoname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAddress1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAddress2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCustomerGroup = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRegionCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRegionName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDistrictCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDistrictName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAreaCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAreaName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colZipCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAreaCoverage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAreaCoverageName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDivisionCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMedicalRep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMedicalRepName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgdetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnfilter, Me.ToolStripSeparator2, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(751, 25)
        Me.ToolStrip1.TabIndex = 91
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnfilter
        '
        Me.btnfilter.Image = Global.SPMSOPCI.My.Resources.Resources.WSS_DocLib1
        Me.btnfilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfilter.Name = "btnfilter"
        Me.btnfilter.Size = New System.Drawing.Size(53, 22)
        Me.btnfilter.Text = "&Filter"
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
        Me.btnClose.Text = "&Close"
        Me.btnClose.ToolTipText = "&Close"
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
        Me.Panel1.Size = New System.Drawing.Size(751, 58)
        Me.Panel1.TabIndex = 90
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Customer Mapping Listing"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.cmbChannelName)
        Me.GroupBox1.Controls.Add(Me.cmbChannel)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(751, 92)
        Me.GroupBox1.TabIndex = 92
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter Selection"
        '
        'cmbChannelName
        '
        Me.cmbChannelName.FormattingEnabled = True
        Me.cmbChannelName.Location = New System.Drawing.Point(236, 34)
        Me.cmbChannelName.Name = "cmbChannelName"
        Me.cmbChannelName.Size = New System.Drawing.Size(121, 21)
        Me.cmbChannelName.TabIndex = 97
        '
        'cmbChannel
        '
        Me.cmbChannel.FormattingEnabled = True
        Me.cmbChannel.Location = New System.Drawing.Point(109, 34)
        Me.cmbChannel.Name = "cmbChannel"
        Me.cmbChannel.Size = New System.Drawing.Size(121, 21)
        Me.cmbChannel.TabIndex = 96
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 95
        Me.Label2.Text = "Channel :"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.dgdetails)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 175)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(751, 362)
        Me.GroupBox2.TabIndex = 93
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Listing"
        '
        'dgdetails
        '
        Me.dgdetails.AllowUserToAddRows = False
        Me.dgdetails.AllowUserToDeleteRows = False
        Me.dgdetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colComid, Me.colCustomerCd, Me.colCustomerName, Me.colShiptoCode, Me.colShiptoname, Me.colAddress1, Me.colAddress2, Me.colCustomerGroup, Me.colRegionCode, Me.colRegionName, Me.colDistrictCode, Me.colDistrictName, Me.colAreaCode, Me.colAreaName, Me.colZipCode, Me.colAreaCoverage, Me.colAreaCoverageName, Me.colDivisionCode, Me.colMedicalRep, Me.colMedicalRepName})
        Me.dgdetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgdetails.Location = New System.Drawing.Point(3, 18)
        Me.dgdetails.Name = "dgdetails"
        Me.dgdetails.RowHeadersVisible = False
        Me.dgdetails.Size = New System.Drawing.Size(745, 341)
        Me.dgdetails.TabIndex = 0
        '
        'colID
        '
        Me.colID.HeaderText = "ID"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Visible = False
        '
        'colComid
        '
        Me.colComid.HeaderText = "ChannelCode"
        Me.colComid.Name = "colComid"
        Me.colComid.ReadOnly = True
        '
        'colCustomerCd
        '
        Me.colCustomerCd.HeaderText = "CustomerCode"
        Me.colCustomerCd.Name = "colCustomerCd"
        Me.colCustomerCd.ReadOnly = True
        '
        'colCustomerName
        '
        Me.colCustomerName.HeaderText = "CustomerName"
        Me.colCustomerName.Name = "colCustomerName"
        Me.colCustomerName.ReadOnly = True
        '
        'colShiptoCode
        '
        Me.colShiptoCode.HeaderText = "ShiptoCode"
        Me.colShiptoCode.Name = "colShiptoCode"
        Me.colShiptoCode.ReadOnly = True
        '
        'colShiptoname
        '
        Me.colShiptoname.HeaderText = "ShiptoName"
        Me.colShiptoname.Name = "colShiptoname"
        Me.colShiptoname.ReadOnly = True
        '
        'colAddress1
        '
        Me.colAddress1.HeaderText = "Address1"
        Me.colAddress1.Name = "colAddress1"
        Me.colAddress1.ReadOnly = True
        '
        'colAddress2
        '
        Me.colAddress2.HeaderText = "Address2"
        Me.colAddress2.Name = "colAddress2"
        Me.colAddress2.ReadOnly = True
        '
        'colCustomerGroup
        '
        Me.colCustomerGroup.HeaderText = "CustomerGroup"
        Me.colCustomerGroup.Name = "colCustomerGroup"
        Me.colCustomerGroup.ReadOnly = True
        '
        'colRegionCode
        '
        Me.colRegionCode.HeaderText = "RegionCode"
        Me.colRegionCode.Name = "colRegionCode"
        Me.colRegionCode.ReadOnly = True
        '
        'colRegionName
        '
        Me.colRegionName.HeaderText = "RegionName"
        Me.colRegionName.Name = "colRegionName"
        Me.colRegionName.ReadOnly = True
        '
        'colDistrictCode
        '
        Me.colDistrictCode.HeaderText = "ProvinceCode"
        Me.colDistrictCode.Name = "colDistrictCode"
        Me.colDistrictCode.ReadOnly = True
        '
        'colDistrictName
        '
        Me.colDistrictName.HeaderText = "ProvinceName"
        Me.colDistrictName.Name = "colDistrictName"
        Me.colDistrictName.ReadOnly = True
        '
        'colAreaCode
        '
        Me.colAreaCode.HeaderText = "MunicipalityCode"
        Me.colAreaCode.Name = "colAreaCode"
        Me.colAreaCode.ReadOnly = True
        '
        'colAreaName
        '
        Me.colAreaName.HeaderText = "MunicipalityName"
        Me.colAreaName.Name = "colAreaName"
        Me.colAreaName.ReadOnly = True
        '
        'colZipCode
        '
        Me.colZipCode.HeaderText = "ZipCode"
        Me.colZipCode.Name = "colZipCode"
        Me.colZipCode.ReadOnly = True
        '
        'colAreaCoverage
        '
        Me.colAreaCoverage.HeaderText = "AreaCoverage"
        Me.colAreaCoverage.Name = "colAreaCoverage"
        Me.colAreaCoverage.ReadOnly = True
        '
        'colAreaCoverageName
        '
        Me.colAreaCoverageName.HeaderText = "AreaCoverageName"
        Me.colAreaCoverageName.Name = "colAreaCoverageName"
        Me.colAreaCoverageName.ReadOnly = True
        '
        'colDivisionCode
        '
        Me.colDivisionCode.HeaderText = "DivisionCode"
        Me.colDivisionCode.Name = "colDivisionCode"
        Me.colDivisionCode.ReadOnly = True
        '
        'colMedicalRep
        '
        Me.colMedicalRep.HeaderText = "MedicalRepresentative"
        Me.colMedicalRep.Name = "colMedicalRep"
        Me.colMedicalRep.ReadOnly = True
        Me.colMedicalRep.Width = 150
        '
        'colMedicalRepName
        '
        Me.colMedicalRepName.HeaderText = "MedicalRepresentativeName"
        Me.colMedicalRepName.Name = "colMedicalRepName"
        Me.colMedicalRepName.ReadOnly = True
        Me.colMedicalRepName.Width = 300
        '
        'UCCustomerMappingListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "UCCustomerMappingListing"
        Me.Size = New System.Drawing.Size(751, 537)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgdetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnfilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbChannelName As System.Windows.Forms.ComboBox
    Friend WithEvents cmbChannel As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgdetails As System.Windows.Forms.DataGridView
    Friend WithEvents colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colComid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCustomerCd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colShiptoCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colShiptoname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAddress1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAddress2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCustomerGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRegionCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRegionName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDistrictCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDistrictName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAreaCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAreaName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colZipCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAreaCoverage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAreaCoverageName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDivisionCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMedicalRep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMedicalRepName As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
