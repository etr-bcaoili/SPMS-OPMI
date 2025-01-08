<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MRTerritoryAssignmentCopyFrom
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
        Me.dt1From = New System.Windows.Forms.DateTimePicker
        Me.dt2To = New System.Windows.Forms.DateTimePicker
        Me.dt2From = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.dt1To = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.lnkStartProcess = New System.Windows.Forms.LinkLabel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.lnkProcess = New System.Windows.Forms.LinkLabel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtconfigname = New System.Windows.Forms.TextBox
        Me.cboConfig = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        'Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        'Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dt1From
        '
        Me.dt1From.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt1From.Location = New System.Drawing.Point(205, 130)
        Me.dt1From.Name = "dt1From"
        Me.dt1From.Size = New System.Drawing.Size(106, 22)
        Me.dt1From.TabIndex = 59
        '
        'dt2To
        '
        Me.dt2To.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt2To.Location = New System.Drawing.Point(332, 158)
        Me.dt2To.Name = "dt2To"
        Me.dt2To.Size = New System.Drawing.Size(106, 22)
        Me.dt2To.TabIndex = 66
        '
        'dt2From
        '
        Me.dt2From.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt2From.Location = New System.Drawing.Point(332, 130)
        Me.dt2From.Name = "dt2From"
        Me.dt2From.Size = New System.Drawing.Size(106, 22)
        Me.dt2From.TabIndex = 65
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(84, 162)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 13)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "Effectivity End Date :"
        '
        'dt1To
        '
        Me.dt1To.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt1To.Location = New System.Drawing.Point(205, 158)
        Me.dt1To.Name = "dt1To"
        Me.dt1To.Size = New System.Drawing.Size(106, 22)
        Me.dt1To.TabIndex = 63
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(329, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "To :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(84, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Effectivity Start Date :"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.Controls.Add(Me.LinkLabel2)
        Me.Panel2.Controls.Add(Me.lnkStartProcess)
        Me.Panel2.Controls.Add(Me.LinkLabel1)
        Me.Panel2.Controls.Add(Me.lnkProcess)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 196)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(447, 30)
        Me.Panel2.TabIndex = 55
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(403, 8)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(35, 13)
        Me.LinkLabel2.TabIndex = 3
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Close"
        '
        'lnkStartProcess
        '
        Me.lnkStartProcess.AutoSize = True
        Me.lnkStartProcess.Location = New System.Drawing.Point(327, 8)
        Me.lnkStartProcess.Name = "lnkStartProcess"
        Me.lnkStartProcess.Size = New System.Drawing.Size(72, 13)
        Me.lnkStartProcess.TabIndex = 2
        Me.lnkStartProcess.TabStop = True
        Me.lnkStartProcess.Text = "Start Process"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(626, 8)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(35, 13)
        Me.LinkLabel1.TabIndex = 1
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Close"
        '
        'lnkProcess
        '
        Me.lnkProcess.AutoSize = True
        Me.lnkProcess.Location = New System.Drawing.Point(550, 8)
        Me.lnkProcess.Name = "lnkProcess"
        Me.lnkProcess.Size = New System.Drawing.Size(72, 13)
        Me.lnkProcess.TabIndex = 0
        Me.lnkProcess.TabStop = True
        Me.lnkProcess.Text = "Start Process"
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
        Me.Panel1.Size = New System.Drawing.Size(447, 60)
        Me.Panel1.TabIndex = 54
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(4, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(310, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "MR Territory Assignment Copy From Utility"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(202, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "From :"
        '
        'txtconfigname
        '
        Me.txtconfigname.BackColor = System.Drawing.Color.White
        Me.txtconfigname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtconfigname.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtconfigname.Location = New System.Drawing.Point(190, 77)
        Me.txtconfigname.Multiline = True
        Me.txtconfigname.Name = "txtconfigname"
        Me.txtconfigname.ReadOnly = True
        Me.txtconfigname.Size = New System.Drawing.Size(249, 20)
        Me.txtconfigname.TabIndex = 74
        '
        'cboConfig
        '
        Me.cboConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConfig.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboConfig.FormattingEnabled = True
        Me.cboConfig.Location = New System.Drawing.Point(84, 76)
        Me.cboConfig.Name = "cboConfig"
        Me.cboConfig.Size = New System.Drawing.Size(104, 21)
        Me.cboConfig.TabIndex = 73
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(4, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 13)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "ConfigType :"
        '
        'ShapeContainer1
        '
        'Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        'Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        'Me.ShapeContainer1.Name = "ShapeContainer1"
        'Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        'Me.ShapeContainer1.Size = New System.Drawing.Size(447, 226)
        'Me.ShapeContainer1.TabIndex = 75
        'Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        'Me.LineShape1.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        'Me.LineShape1.Name = "LineShape1"
        'Me.LineShape1.X1 = 10
        'Me.LineShape1.X2 = 437
        'Me.LineShape1.Y1 = 108
        'Me.LineShape1.Y2 = 108
        '
        'MRTerritoryAssignmentCopyFrom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(447, 226)
        Me.Controls.Add(Me.txtconfigname)
        Me.Controls.Add(Me.cboConfig)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dt1From)
        Me.Controls.Add(Me.dt2To)
        Me.Controls.Add(Me.dt2From)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dt1To)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        'Me.Controls.Add(Me.ShapeContainer1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MRTerritoryAssignmentCopyFrom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Utility"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dt1From As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt2To As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt2From As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dt1To As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkStartProcess As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkProcess As System.Windows.Forms.LinkLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtconfigname As System.Windows.Forms.TextBox
    Friend WithEvents cboConfig As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    'Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    'Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
End Class
