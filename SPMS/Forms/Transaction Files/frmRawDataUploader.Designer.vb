<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRawDataUploader
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.cmbCompany = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.txtfile = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblBrowseFile = New System.Windows.Forms.Label()
        Me.Picture1 = New System.Windows.Forms.Panel()
        Me.lblUpload = New System.Windows.Forms.Label()
        Me.lblClose = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbFiletype = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(470, 60)
        Me.Panel1.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "RawData"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Frame2.Controls.Add(Me.cmbCompany)
        Me.Frame2.Controls.Add(Me.Label5)
        Me.Frame2.Controls.Add(Me.cmbYear)
        Me.Frame2.Controls.Add(Me.cmbMonth)
        Me.Frame2.Controls.Add(Me.Label4)
        Me.Frame2.Controls.Add(Me.Label2)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(7, 62)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(457, 67)
        Me.Frame2.TabIndex = 16
        Me.Frame2.TabStop = False
        '
        'cmbCompany
        '
        Me.cmbCompany.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCompany.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCompany.FlatStyle = System.Windows.Forms.FlatStyle.Popup
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
        Me.Label5.Location = New System.Drawing.Point(9, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(73, 21)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Company :"
        '
        'cmbYear
        '
        Me.cmbYear.BackColor = System.Drawing.SystemColors.Window
        Me.cmbYear.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbYear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbYear.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbYear.Location = New System.Drawing.Point(205, 31)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbYear.Size = New System.Drawing.Size(87, 21)
        Me.cmbYear.TabIndex = 10
        '
        'cmbMonth
        '
        Me.cmbMonth.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMonth.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonth.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbMonth.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMonth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbMonth.Location = New System.Drawing.Point(362, 31)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbMonth.Size = New System.Drawing.Size(87, 21)
        Me.cmbMonth.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(170, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(41, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Year:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(298, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(58, 17)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Month:"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Frame1.Controls.Add(Me.txtfile)
        Me.Frame1.Controls.Add(Me.ProgressBar1)
        Me.Frame1.Controls.Add(Me.lblBrowseFile)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.Color.Orange
        Me.Frame1.Location = New System.Drawing.Point(7, 177)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(457, 77)
        Me.Frame1.TabIndex = 15
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Please select file to be uploaded"
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
        Me.txtfile.Location = New System.Drawing.Point(72, 30)
        Me.txtfile.MaxLength = 0
        Me.txtfile.Name = "txtfile"
        Me.txtfile.ReadOnly = True
        Me.txtfile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtfile.Size = New System.Drawing.Size(377, 20)
        Me.txtfile.TabIndex = 4
        '
        'ProgressBar1
        '
        Me.ProgressBar1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ProgressBar1.Location = New System.Drawing.Point(72, 56)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(377, 12)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 2
        Me.ProgressBar1.Value = 2
        '
        'lblBrowseFile
        '
        Me.lblBrowseFile.AutoSize = True
        Me.lblBrowseFile.BackColor = System.Drawing.Color.Transparent
        Me.lblBrowseFile.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBrowseFile.Enabled = False
        Me.lblBrowseFile.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrowseFile.ForeColor = System.Drawing.Color.Blue
        Me.lblBrowseFile.Location = New System.Drawing.Point(37, 33)
        Me.lblBrowseFile.Name = "lblBrowseFile"
        Me.lblBrowseFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBrowseFile.Size = New System.Drawing.Size(29, 14)
        Me.lblBrowseFile.TabIndex = 6
        Me.lblBrowseFile.Text = "File:"
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Picture1.Controls.Add(Me.lblUpload)
        Me.Picture1.Controls.Add(Me.lblClose)
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.Location = New System.Drawing.Point(8, 259)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(456, 36)
        Me.Picture1.TabIndex = 17
        Me.Picture1.TabStop = True
        '
        'lblUpload
        '
        Me.lblUpload.BackColor = System.Drawing.Color.Transparent
        Me.lblUpload.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUpload.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpload.ForeColor = System.Drawing.Color.Orange
        Me.lblUpload.Location = New System.Drawing.Point(331, 10)
        Me.lblUpload.Name = "lblUpload"
        Me.lblUpload.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUpload.Size = New System.Drawing.Size(61, 18)
        Me.lblUpload.TabIndex = 2
        Me.lblUpload.Text = "Upload"
        '
        'lblClose
        '
        Me.lblClose.BackColor = System.Drawing.Color.Transparent
        Me.lblClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClose.ForeColor = System.Drawing.Color.Orange
        Me.lblClose.Location = New System.Drawing.Point(394, 10)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblClose.Size = New System.Drawing.Size(54, 17)
        Me.lblClose.TabIndex = 1
        Me.lblClose.Text = "Cancel"
        '
        'Timer1
        '
        Me.Timer1.Interval = 20
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(18, 149)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "File Type :"
        '
        'cmbFiletype
        '
        Me.cmbFiletype.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbFiletype.FormattingEnabled = True
        Me.cmbFiletype.Items.AddRange(New Object() {".XLS", ".TXT", ".SP"})
        Me.cmbFiletype.Location = New System.Drawing.Point(79, 146)
        Me.cmbFiletype.Name = "cmbFiletype"
        Me.cmbFiletype.Size = New System.Drawing.Size(93, 21)
        Me.cmbFiletype.TabIndex = 19
        '
        'frmRawDataUploader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(470, 298)
        Me.Controls.Add(Me.cmbFiletype)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Picture1)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Panel1)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRawDataUploader"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Picture1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents cmbYear As System.Windows.Forms.ComboBox
    Public WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents txtfile As System.Windows.Forms.TextBox
    Public WithEvents lblBrowseFile As System.Windows.Forms.Label
    Public WithEvents Picture1 As System.Windows.Forms.Panel
    Public WithEvents lblUpload As System.Windows.Forms.Label
    Public WithEvents lblClose As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents cmbCompany As System.Windows.Forms.ComboBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbFiletype As System.Windows.Forms.ComboBox
    Protected WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
