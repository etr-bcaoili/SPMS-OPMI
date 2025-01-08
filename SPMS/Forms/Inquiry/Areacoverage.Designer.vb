<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Areacoverage
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
        Me.lnkClose = New System.Windows.Forms.LinkLabel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lnkStartUploading = New System.Windows.Forms.LinkLabel
        Me.lblBrowseFile = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.pbar = New System.Windows.Forms.ProgressBar
        Me.txtfile = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboCompanycode = New System.Windows.Forms.ComboBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lnkClose
        '
        Me.lnkClose.AutoSize = True
        Me.lnkClose.Location = New System.Drawing.Point(238, 6)
        Me.lnkClose.Name = "lnkClose"
        Me.lnkClose.Size = New System.Drawing.Size(33, 13)
        Me.lnkClose.TabIndex = 40
        Me.lnkClose.TabStop = True
        Me.lnkClose.Text = "Close"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.Controls.Add(Me.lnkClose)
        Me.Panel2.Controls.Add(Me.lnkStartUploading)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 156)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(284, 28)
        Me.Panel2.TabIndex = 62
        '
        'lnkStartUploading
        '
        Me.lnkStartUploading.AutoSize = True
        Me.lnkStartUploading.Location = New System.Drawing.Point(152, 6)
        Me.lnkStartUploading.Name = "lnkStartUploading"
        Me.lnkStartUploading.Size = New System.Drawing.Size(80, 13)
        Me.lnkStartUploading.TabIndex = 39
        Me.lnkStartUploading.TabStop = True
        Me.lnkStartUploading.Text = "Start Uploading"
        '
        'lblBrowseFile
        '
        Me.lblBrowseFile.AutoSize = True
        Me.lblBrowseFile.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrowseFile.ForeColor = System.Drawing.Color.Orange
        Me.lblBrowseFile.Location = New System.Drawing.Point(5, 102)
        Me.lblBrowseFile.Name = "lblBrowseFile"
        Me.lblBrowseFile.Size = New System.Drawing.Size(60, 13)
        Me.lblBrowseFile.TabIndex = 60
        Me.lblBrowseFile.Text = "Open File.:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(15, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Area Coverage"
        '
        'pbar
        '
        Me.pbar.ForeColor = System.Drawing.Color.RoyalBlue
        Me.pbar.Location = New System.Drawing.Point(102, 129)
        Me.pbar.Name = "pbar"
        Me.pbar.Size = New System.Drawing.Size(169, 10)
        Me.pbar.Step = 1
        Me.pbar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbar.TabIndex = 61
        Me.pbar.Value = 2
        '
        'txtfile
        '
        Me.txtfile.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfile.Location = New System.Drawing.Point(102, 102)
        Me.txtfile.MaxLength = 50
        Me.txtfile.Name = "txtfile"
        Me.txtfile.Size = New System.Drawing.Size(169, 21)
        Me.txtfile.TabIndex = 59
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "ConfigType :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'cboCompanycode
        '
        Me.cboCompanycode.FormattingEnabled = True
        Me.cboCompanycode.Location = New System.Drawing.Point(102, 75)
        Me.cboCompanycode.Name = "cboCompanycode"
        Me.cboCompanycode.Size = New System.Drawing.Size(99, 21)
        Me.cboCompanycode.TabIndex = 57
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
        Me.Panel1.Size = New System.Drawing.Size(284, 60)
        Me.Panel1.TabIndex = 56
        '
        'Areacoverage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 184)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lblBrowseFile)
        Me.Controls.Add(Me.pbar)
        Me.Controls.Add(Me.txtfile)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboCompanycode)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Areacoverage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Upload"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lnkClose As System.Windows.Forms.LinkLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lnkStartUploading As System.Windows.Forms.LinkLabel
    Friend WithEvents lblBrowseFile As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Protected WithEvents pbar As System.Windows.Forms.ProgressBar
    Friend WithEvents txtfile As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCompanycode As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
