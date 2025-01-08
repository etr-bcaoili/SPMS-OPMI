<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdministrationCustomerMappingSearchTerritory
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
        Me.dgDetail = New System.Windows.Forms.DataGridView
        Me.colAreaCoverageCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAreaCoverageName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        'dgDetail
        '
        Me.dgDetail.AllowUserToAddRows = False
        Me.dgDetail.AllowUserToDeleteRows = False
        Me.dgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAreaCoverageCode, Me.colAreaCoverageName})
        Me.dgDetail.Location = New System.Drawing.Point(6, 21)
        Me.dgDetail.Name = "dgDetail"
        Me.dgDetail.ReadOnly = True
        Me.dgDetail.Size = New System.Drawing.Size(732, 370)
        Me.dgDetail.TabIndex = 1
        '
        'colAreaCoverageCode
        '
        Me.colAreaCoverageCode.HeaderText = "Area Coverage Code"
        Me.colAreaCoverageCode.Name = "colAreaCoverageCode"
        Me.colAreaCoverageCode.ReadOnly = True
        Me.colAreaCoverageCode.Width = 150
        '
        'colAreaCoverageName
        '
        Me.colAreaCoverageName.HeaderText = "TerritoryName"
        Me.colAreaCoverageName.Name = "colAreaCoverageName"
        Me.colAreaCoverageName.ReadOnly = True
        Me.colAreaCoverageName.Width = 300
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgDetail)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(744, 407)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'AdministrationCustomerMappingSearchTerritory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(764, 416)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "AdministrationCustomerMappingSearchTerritory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administration Customer Mapping Search Area Coverage"
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Process1 As System.Diagnostics.Process
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgDetail As System.Windows.Forms.DataGridView
    Friend WithEvents colAreaCoverageCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAreaCoverageName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
