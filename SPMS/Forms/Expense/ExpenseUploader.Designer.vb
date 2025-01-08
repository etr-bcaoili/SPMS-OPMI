<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExpenseUploader
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lnkClose = New System.Windows.Forms.LinkLabel
        Me.lnkStartUploading = New System.Windows.Forms.LinkLabel
        Me.cboMonth = New System.Windows.Forms.ComboBox
        Me.cboYear = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtfile = New System.Windows.Forms.TextBox
        Me.lblBrowseFile = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.pbar = New System.Windows.Forms.ProgressBar
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(263, 60)
        Me.Panel1.TabIndex = 36
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(15, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(142, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Expense Uploading"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.Controls.Add(Me.lnkClose)
        Me.Panel2.Controls.Add(Me.lnkStartUploading)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 165)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(263, 28)
        Me.Panel2.TabIndex = 37
        '
        'lnkClose
        '
        Me.lnkClose.AutoSize = True
        Me.lnkClose.Location = New System.Drawing.Point(218, 6)
        Me.lnkClose.Name = "lnkClose"
        Me.lnkClose.Size = New System.Drawing.Size(35, 13)
        Me.lnkClose.TabIndex = 40
        Me.lnkClose.TabStop = True
        Me.lnkClose.Text = "Close"
        '
        'lnkStartUploading
        '
        Me.lnkStartUploading.AutoSize = True
        Me.lnkStartUploading.Location = New System.Drawing.Point(127, 6)
        Me.lnkStartUploading.Name = "lnkStartUploading"
        Me.lnkStartUploading.Size = New System.Drawing.Size(89, 13)
        Me.lnkStartUploading.TabIndex = 39
        Me.lnkStartUploading.TabStop = True
        Me.lnkStartUploading.Text = "Start Uploading"
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(97, 98)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(154, 21)
        Me.cboMonth.TabIndex = 42
        '
        'cboYear
        '
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(97, 76)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(154, 21)
        Me.cboYear.TabIndex = 43
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Month :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Year :"
        '
        'txtfile
        '
        Me.txtfile.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfile.Location = New System.Drawing.Point(76, 121)
        Me.txtfile.MaxLength = 50
        Me.txtfile.Name = "txtfile"
        Me.txtfile.Size = New System.Drawing.Size(175, 21)
        Me.txtfile.TabIndex = 46
        '
        'lblBrowseFile
        '
        Me.lblBrowseFile.AutoSize = True
        Me.lblBrowseFile.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrowseFile.ForeColor = System.Drawing.Color.Orange
        Me.lblBrowseFile.Location = New System.Drawing.Point(8, 126)
        Me.lblBrowseFile.Name = "lblBrowseFile"
        Me.lblBrowseFile.Size = New System.Drawing.Size(60, 13)
        Me.lblBrowseFile.TabIndex = 47
        Me.lblBrowseFile.Text = "Open File.:"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'pbar
        '
        Me.pbar.ForeColor = System.Drawing.Color.RoyalBlue
        Me.pbar.Location = New System.Drawing.Point(10, 147)
        Me.pbar.Name = "pbar"
        Me.pbar.Size = New System.Drawing.Size(240, 10)
        Me.pbar.Step = 1
        Me.pbar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbar.TabIndex = 48
        Me.pbar.Value = 2
        '
        'ExpenseUploader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(263, 193)
        Me.ControlBox = False
        Me.Controls.Add(Me.pbar)
        Me.Controls.Add(Me.lblBrowseFile)
        Me.Controls.Add(Me.txtfile)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboYear)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ExpenseUploader"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Utility"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lnkClose As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkStartUploading As System.Windows.Forms.LinkLabel
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtfile As System.Windows.Forms.TextBox
    Friend WithEvents lblBrowseFile As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Protected WithEvents pbar As System.Windows.Forms.ProgressBar
End Class
