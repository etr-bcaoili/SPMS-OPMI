<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportMaintenance
    Inherits Althea.Base.UI.AltheaForm

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
        Me.UcInfraReport1 = New UCInfraReport
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(4, 498)
        Me.Panel1.Size = New System.Drawing.Size(746, 34)
        '
        'Header
        '
        Me.Header.Location = New System.Drawing.Point(4, 31)
        Me.Header.Size = New System.Drawing.Size(746, 41)
        '
        'UcInfraReport1
        '
        Me.UcInfraReport1.AutoScroll = True
        Me.UcInfraReport1.Auxiliary = ""
        Me.UcInfraReport1.BackColor = System.Drawing.Color.White
        Me.UcInfraReport1.CommandText = ""
        Me.UcInfraReport1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcInfraReport1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcInfraReport1.HeaderText = ""
        Me.UcInfraReport1.Location = New System.Drawing.Point(4, 31)
        Me.UcInfraReport1.MainForm = Nothing
        Me.UcInfraReport1.Name = "UcInfraReport1"
        Me.UcInfraReport1.PageIndex = -1
        Me.UcInfraReport1.Size = New System.Drawing.Size(746, 467)
        Me.UcInfraReport1.TabIndex = 6
        '
        'ReportMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 536)
        Me.Controls.Add(Me.UcInfraReport1)
        Me.Name = "ReportMaintenance"
        Me.Text = "ReportMaintenance"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.UcInfraReport1, 0)
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcInfraReport1 As UCInfraReport
End Class
