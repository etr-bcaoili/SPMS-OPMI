<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Calendar
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
        Me.BasePageHeader1 = New Althea.Base.UI.BasePageHeader
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnOk = New Althea.Base.UI.JButton
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BasePageHeader1
        '
        Me.BasePageHeader1.AutoScroll = True
        Me.BasePageHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.BasePageHeader1.HeaderText = "Calendar :"
        Me.BasePageHeader1.Location = New System.Drawing.Point(0, 0)
        Me.BasePageHeader1.Name = "BasePageHeader1"
        Me.BasePageHeader1.Size = New System.Drawing.Size(204, 44)
        Me.BasePageHeader1.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.btnOk)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 202)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(204, 31)
        Me.Panel1.TabIndex = 3
        '
        'btnOk
        '
        Me.btnOk.BorderColor = System.Drawing.Color.Gray
        Me.btnOk.DefaultBorderColor = System.Drawing.Color.Black
        Me.btnOk.DisableColor = System.Drawing.Color.Gray
        Me.btnOk.GradientColor1 = System.Drawing.Color.WhiteSmoke
        Me.btnOk.GradientColor2 = System.Drawing.Color.LightSteelBlue
        Me.btnOk.HighlightColor = System.Drawing.Color.White
        Me.btnOk.HoverColor = System.Drawing.Color.DarkGray
        Me.btnOk.Image = Nothing
        Me.btnOk.ImageIndex = 0
        Me.btnOk.Location = New System.Drawing.Point(120, 6)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(72, 22)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.BackColor = System.Drawing.Color.Azure
        Me.MonthCalendar1.Location = New System.Drawing.Point(0, 44)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.ShowWeekNumbers = True
        Me.MonthCalendar1.TabIndex = 4
        '
        'Calendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(204, 233)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BasePageHeader1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Calendar"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BasePageHeader1 As Althea.Base.UI.BasePageHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnOk As Althea.Base.UI.JButton
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
End Class
