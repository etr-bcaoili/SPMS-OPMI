<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportExcell
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtsave = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        'Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        'Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Save As"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(249, 54)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(67, 26)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "&Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtsave
        '
        Me.txtsave.Location = New System.Drawing.Point(89, 13)
        Me.txtsave.Name = "txtsave"
        Me.txtsave.Size = New System.Drawing.Size(197, 20)
        Me.txtsave.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(287, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(29, 20)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ShapeContainer1
        '
        'Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        'Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        'Me.ShapeContainer1.Name = "ShapeContainer1"
        'Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        'Me.ShapeContainer1.Size = New System.Drawing.Size(319, 83)
        'Me.ShapeContainer1.TabIndex = 4
        'Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        'Me.LineShape1.Name = "LineShape1"
        'Me.LineShape1.X1 = 1
        'Me.LineShape1.X2 = 317
        'Me.LineShape1.Y1 = 45
        'Me.LineShape1.Y2 = 45
        '
        'ExportExcell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(319, 83)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtsave)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        'Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "ExportExcell"
        Me.Text = "ExportExcell Directory "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtsave As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    'Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    'Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
End Class
