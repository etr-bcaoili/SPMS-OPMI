<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerUploading
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
        Me.components = New System.ComponentModel.Container
        Me.Picture1 = New System.Windows.Forms.Panel
        Me.lblUpload = New System.Windows.Forms.Label
        Me.lblClose = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtfile = New System.Windows.Forms.TextBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblBrowseFile = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.cmbCompany = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.cmbFiletype = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Picture1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Picture1.Controls.Add(Me.lblClose)
        Me.Picture1.Controls.Add(Me.lblUpload)
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Picture1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.Location = New System.Drawing.Point(0, 241)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(310, 39)
        Me.Picture1.TabIndex = 23
        Me.Picture1.TabStop = True
        '
        'lblUpload
        '
        Me.lblUpload.BackColor = System.Drawing.Color.Transparent
        Me.lblUpload.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUpload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpload.ForeColor = System.Drawing.Color.Blue
        Me.lblUpload.Location = New System.Drawing.Point(171, 13)
        Me.lblUpload.Name = "lblUpload"
        Me.lblUpload.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUpload.Size = New System.Drawing.Size(95, 17)
        Me.lblUpload.TabIndex = 2
        Me.lblUpload.Text = "Start Uploading"
        '
        'lblClose
        '
        Me.lblClose.BackColor = System.Drawing.Color.Transparent
        Me.lblClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClose.ForeColor = System.Drawing.Color.Blue
        Me.lblClose.Location = New System.Drawing.Point(251, 13)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblClose.Size = New System.Drawing.Size(41, 17)
        Me.lblClose.TabIndex = 1
        Me.lblClose.Text = "Close"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(310, 41)
        Me.Panel1.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Customer"
        '
        'txtfile
        '
        Me.txtfile.AcceptsReturn = True
        Me.txtfile.BackColor = System.Drawing.SystemColors.Window
        Me.txtfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtfile.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtfile.Enabled = False
        Me.txtfile.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfile.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfile.Location = New System.Drawing.Point(72, 37)
        Me.txtfile.MaxLength = 0
        Me.txtfile.Name = "txtfile"
        Me.txtfile.ReadOnly = True
        Me.txtfile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtfile.Size = New System.Drawing.Size(213, 20)
        Me.txtfile.TabIndex = 4
        '
        'Timer1
        '
        Me.Timer1.Interval = 20
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.White
        Me.Frame1.Controls.Add(Me.txtfile)
        Me.Frame1.Controls.Add(Me.ProgressBar1)
        Me.Frame1.Controls.Add(Me.Label3)
        Me.Frame1.Controls.Add(Me.lblBrowseFile)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(7, 142)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(301, 96)
        Me.Frame1.TabIndex = 21
        Me.Frame1.TabStop = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ProgressBar1.Location = New System.Drawing.Point(8, 63)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(277, 12)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 1
        Me.ProgressBar1.Value = 2
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(241, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Please select file to be uploaded"
        '
        'lblBrowseFile
        '
        Me.lblBrowseFile.AutoSize = True
        Me.lblBrowseFile.BackColor = System.Drawing.Color.Transparent
        Me.lblBrowseFile.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBrowseFile.Enabled = False
        Me.lblBrowseFile.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrowseFile.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblBrowseFile.Location = New System.Drawing.Point(8, 43)
        Me.lblBrowseFile.Name = "lblBrowseFile"
        Me.lblBrowseFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBrowseFile.Size = New System.Drawing.Size(29, 14)
        Me.lblBrowseFile.TabIndex = 6
        Me.lblBrowseFile.Text = "File:"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'cmbCompany
        '
        Me.cmbCompany.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCompany.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCompany.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCompany.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbCompany.Location = New System.Drawing.Point(72, 31)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbCompany.Size = New System.Drawing.Size(93, 21)
        Me.cmbCompany.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(4, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(67, 21)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Company :"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.Color.White
        Me.Frame2.Controls.Add(Me.cmbCompany)
        Me.Frame2.Controls.Add(Me.Label5)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(7, 43)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(301, 67)
        Me.Frame2.TabIndex = 22
        Me.Frame2.TabStop = False
        '
        'cmbFiletype
        '
        Me.cmbFiletype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFiletype.Enabled = False
        Me.cmbFiletype.FormattingEnabled = True
        Me.cmbFiletype.Items.AddRange(New Object() {".XLS", ".TXT"})
        Me.cmbFiletype.Location = New System.Drawing.Point(79, 120)
        Me.cmbFiletype.Name = "cmbFiletype"
        Me.cmbFiletype.Size = New System.Drawing.Size(93, 21)
        Me.cmbFiletype.TabIndex = 25
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Sylfaen", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(15, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 16)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "File Type :"
        '
        'CustomerUploading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(310, 280)
        Me.Controls.Add(Me.cmbFiletype)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Picture1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Frame2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CustomerUploading"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Uploading"
        Me.Picture1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents Picture1 As System.Windows.Forms.Panel
    Public WithEvents lblUpload As System.Windows.Forms.Label
    Public WithEvents lblClose As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtfile As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents lblBrowseFile As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Public WithEvents cmbCompany As System.Windows.Forms.ComboBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbFiletype As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
