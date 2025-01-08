<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemListUploading
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.EndDate = New System.Windows.Forms.DateTimePicker
        Me.startDate = New System.Windows.Forms.DateTimePicker
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbCompany = New System.Windows.Forms.ComboBox
        Me.txtfile = New System.Windows.Forms.TextBox
        Me.lblBrowseFile = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Picture1 = New System.Windows.Forms.Panel
        Me.lblClose = New System.Windows.Forms.Label
        Me.lblUpload = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Picture1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(299, 60)
        Me.Panel1.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Symbol", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Price List Uploading"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.EndDate)
        Me.Panel2.Controls.Add(Me.startDate)
        Me.Panel2.Controls.Add(Me.ProgressBar1)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 60)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(299, 177)
        Me.Panel2.TabIndex = 28
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(50, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "EffectivityEndDate :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "EffectivityStartDate :"
        '
        'EndDate
        '
        Me.EndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.EndDate.Location = New System.Drawing.Point(157, 116)
        Me.EndDate.Name = "EndDate"
        Me.EndDate.Size = New System.Drawing.Size(130, 20)
        Me.EndDate.TabIndex = 33
        '
        'startDate
        '
        Me.startDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.startDate.Location = New System.Drawing.Point(157, 90)
        Me.startDate.Name = "startDate"
        Me.startDate.Size = New System.Drawing.Size(130, 20)
        Me.startDate.TabIndex = 32
        '
        'ProgressBar1
        '
        Me.ProgressBar1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 71)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(283, 10)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 29
        Me.ProgressBar1.Value = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.cmbCompany)
        Me.GroupBox1.Controls.Add(Me.txtfile)
        Me.GroupBox1.Controls.Add(Me.lblBrowseFile)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 62)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Company :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(0, 111)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(288, 63)
        Me.GroupBox2.TabIndex = 69
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GroupBox2"
        '
        'cmbCompany
        '
        Me.cmbCompany.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCompany.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCompany.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCompany.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbCompany.Location = New System.Drawing.Point(153, 11)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbCompany.Size = New System.Drawing.Size(128, 21)
        Me.cmbCompany.TabIndex = 15
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
        Me.txtfile.Location = New System.Drawing.Point(70, 38)
        Me.txtfile.MaxLength = 0
        Me.txtfile.Multiline = True
        Me.txtfile.Name = "txtfile"
        Me.txtfile.ReadOnly = True
        Me.txtfile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtfile.Size = New System.Drawing.Size(212, 18)
        Me.txtfile.TabIndex = 8
        '
        'lblBrowseFile
        '
        Me.lblBrowseFile.AutoSize = True
        Me.lblBrowseFile.BackColor = System.Drawing.Color.Transparent
        Me.lblBrowseFile.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBrowseFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblBrowseFile.ForeColor = System.Drawing.Color.Black
        Me.lblBrowseFile.Location = New System.Drawing.Point(11, 40)
        Me.lblBrowseFile.Name = "lblBrowseFile"
        Me.lblBrowseFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBrowseFile.Size = New System.Drawing.Size(58, 13)
        Me.lblBrowseFile.TabIndex = 9
        Me.lblBrowseFile.Text = "Open File :"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Timer1
        '
        Me.Timer1.Interval = 20
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
        Me.Picture1.Location = New System.Drawing.Point(0, 202)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(299, 35)
        Me.Picture1.TabIndex = 72
        Me.Picture1.TabStop = True
        '
        'lblClose
        '
        Me.lblClose.BackColor = System.Drawing.Color.Transparent
        Me.lblClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClose.ForeColor = System.Drawing.Color.Blue
        Me.lblClose.Location = New System.Drawing.Point(255, 9)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblClose.Size = New System.Drawing.Size(41, 17)
        Me.lblClose.TabIndex = 1
        Me.lblClose.Text = "Close"
        Me.lblClose.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblUpload
        '
        Me.lblUpload.BackColor = System.Drawing.Color.Transparent
        Me.lblUpload.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUpload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpload.ForeColor = System.Drawing.Color.Blue
        Me.lblUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblUpload.Location = New System.Drawing.Point(160, 8)
        Me.lblUpload.Name = "lblUpload"
        Me.lblUpload.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUpload.Size = New System.Drawing.Size(93, 18)
        Me.lblUpload.TabIndex = 2
        Me.lblUpload.Text = "Start Uploading"
        Me.lblUpload.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ItemListUploading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(299, 237)
        Me.Controls.Add(Me.Picture1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ItemListUploading"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ItemListUploading"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Picture1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents txtfile As System.Windows.Forms.TextBox
    Public WithEvents lblBrowseFile As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents cmbCompany As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Protected WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Public WithEvents Picture1 As System.Windows.Forms.Panel
    Public WithEvents lblClose As System.Windows.Forms.Label
    Public WithEvents lblUpload As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents EndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents startDate As System.Windows.Forms.DateTimePicker
End Class
