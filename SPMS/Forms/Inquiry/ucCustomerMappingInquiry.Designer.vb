<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCustomerMappingInquiry
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgdetails = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnClose = New System.Windows.Forms.ToolStripButton
        Me.colZipCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCustomerCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colShiptoCD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colShipToName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colReg = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colProvince = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTerrCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTerrName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDivision = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.dgdetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(804, 58)
        Me.Panel1.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(242, 21)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Zip Code with Multiple Territories"
        '
        'dgdetails
        '
        Me.dgdetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colZipCode, Me.colCustomerCode, Me.colShiptoCD, Me.colShipToName, Me.colReg, Me.colProvince, Me.colTerrCode, Me.colTerrName, Me.colDivision})
        Me.dgdetails.Location = New System.Drawing.Point(13, 114)
        Me.dgdetails.Name = "dgdetails"
        Me.dgdetails.Size = New System.Drawing.Size(632, 337)
        Me.dgdetails.TabIndex = 19
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(804, 25)
        Me.ToolStrip1.TabIndex = 20
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnClose
        '
        Me.btnClose.Image = Global.SPMSOPCI.My.Resources.Resources.cancel
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(55, 22)
        Me.btnClose.Text = "Close"
        '
        'colZipCode
        '
        Me.colZipCode.HeaderText = "Zip Code"
        Me.colZipCode.Name = "colZipCode"
        Me.colZipCode.ReadOnly = True
        Me.colZipCode.Width = 125
        '
        'colCustomerCode
        '
        Me.colCustomerCode.HeaderText = "Customer Code"
        Me.colCustomerCode.Name = "colCustomerCode"
        Me.colCustomerCode.ReadOnly = True
        Me.colCustomerCode.Width = 125
        '
        'colShiptoCD
        '
        Me.colShiptoCD.HeaderText = "Ship To Code"
        Me.colShiptoCD.Name = "colShiptoCD"
        Me.colShiptoCD.ReadOnly = True
        Me.colShiptoCD.Width = 125
        '
        'colShipToName
        '
        Me.colShipToName.HeaderText = "Customer ShipToName"
        Me.colShipToName.Name = "colShipToName"
        Me.colShipToName.ReadOnly = True
        Me.colShipToName.Width = 255
        '
        'colReg
        '
        Me.colReg.HeaderText = "Region"
        Me.colReg.Name = "colReg"
        Me.colReg.ReadOnly = True
        '
        'colProvince
        '
        Me.colProvince.HeaderText = "Province"
        Me.colProvince.Name = "colProvince"
        Me.colProvince.ReadOnly = True
        '
        'colTerrCode
        '
        Me.colTerrCode.HeaderText = "Territory Code"
        Me.colTerrCode.Name = "colTerrCode"
        Me.colTerrCode.ReadOnly = True
        Me.colTerrCode.Width = 125
        '
        'colTerrName
        '
        Me.colTerrName.HeaderText = "TerritoryName"
        Me.colTerrName.Name = "colTerrName"
        Me.colTerrName.ReadOnly = True
        Me.colTerrName.Width = 125
        '
        'colDivision
        '
        Me.colDivision.HeaderText = "Division"
        Me.colDivision.Name = "colDivision"
        Me.colDivision.ReadOnly = True
        Me.colDivision.Width = 125
        '
        'ucCustomerMappingInquiry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.dgdetails)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ucCustomerMappingInquiry"
        Me.Size = New System.Drawing.Size(804, 451)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgdetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgdetails As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents colZipCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCustomerCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colShiptoCD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colShipToName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProvince As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTerrCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTerrName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDivision As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
