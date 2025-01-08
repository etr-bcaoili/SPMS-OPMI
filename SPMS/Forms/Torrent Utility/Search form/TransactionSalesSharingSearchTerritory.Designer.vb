<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransactionSalesSharingSearchTerritory
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
        Me.Process1 = New System.Diagnostics.Process
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgDetail = New System.Windows.Forms.DataGridView
        Me.colTerritoryCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTerritoryName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMRCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Process1
        '
        Me.Process1.StartInfo.Domain = ""
        Me.Process1.StartInfo.LoadUserProfile = False
        Me.Process1.StartInfo.Password = Nothing
        Me.Process1.StartInfo.StandardErrorEncoding = Nothing
        Me.Process1.StartInfo.StandardOutputEncoding = Nothing
        Me.Process1.StartInfo.UserName = ""
        Me.Process1.SynchronizingObject = Me
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgDetail)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(744, 407)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'dgDetail
        '
        Me.dgDetail.AllowUserToAddRows = False
        Me.dgDetail.AllowUserToDeleteRows = False
        Me.dgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTerritoryCode, Me.colTerritoryName, Me.colMRCode, Me.colMR})
        Me.dgDetail.Location = New System.Drawing.Point(6, 21)
        Me.dgDetail.Name = "dgDetail"
        Me.dgDetail.ReadOnly = True
        Me.dgDetail.Size = New System.Drawing.Size(732, 370)
        Me.dgDetail.TabIndex = 1
        '
        'colTerritoryCode
        '
        Me.colTerritoryCode.HeaderText = "TerritoryCode"
        Me.colTerritoryCode.Name = "colTerritoryCode"
        Me.colTerritoryCode.ReadOnly = True
        Me.colTerritoryCode.Width = 150
        '
        'colTerritoryName
        '
        Me.colTerritoryName.HeaderText = "TerritoryName"
        Me.colTerritoryName.Name = "colTerritoryName"
        Me.colTerritoryName.ReadOnly = True
        Me.colTerritoryName.Width = 250
        '
        'colMRCode
        '
        Me.colMRCode.HeaderText = "MR Code"
        Me.colMRCode.Name = "colMRCode"
        Me.colMRCode.ReadOnly = True
        '
        'colMR
        '
        Me.colMR.HeaderText = "MR"
        Me.colMR.Name = "colMR"
        Me.colMR.ReadOnly = True
        Me.colMR.Width = 250
        '
        'TransactionSalesSharingSearchTerritory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(768, 466)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.Name = "TransactionSalesSharingSearchTerritory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TransactionSalesSharingSearchTerritory"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Process1 As System.Diagnostics.Process
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgDetail As System.Windows.Forms.DataGridView
    Friend WithEvents colTerritoryCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTerritoryName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMRCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMR As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
