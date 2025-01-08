<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInHouseRawData
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
        Me.Picture1 = New System.Windows.Forms.Panel()
        Me.lblclose = New System.Windows.Forms.LinkLabel()
        Me.lblUpload = New System.Windows.Forms.LinkLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtfile = New System.Windows.Forms.TextBox()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.cmbCompany = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBrowseFile = New System.Windows.Forms.Label()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Picture1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Picture1.Controls.Add(Me.lblclose)
        Me.Picture1.Controls.Add(Me.lblUpload)
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.Location = New System.Drawing.Point(7, 230)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(457, 34)
        Me.Picture1.TabIndex = 23
        Me.Picture1.TabStop = True
        '
        'lblclose
        '
        Me.lblclose.ActiveLinkColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblclose.AutoSize = True
        Me.lblclose.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblclose.LinkColor = System.Drawing.Color.Orange
        Me.lblclose.Location = New System.Drawing.Point(398, 7)
        Me.lblclose.Name = "lblclose"
        Me.lblclose.Size = New System.Drawing.Size(51, 20)
        Me.lblclose.TabIndex = 1
        Me.lblclose.TabStop = True
        Me.lblclose.Text = "Cancel"
        '
        'lblUpload
        '
        Me.lblUpload.ActiveLinkColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblUpload.AutoSize = True
        Me.lblUpload.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpload.LinkColor = System.Drawing.Color.Orange
        Me.lblUpload.Location = New System.Drawing.Point(339, 7)
        Me.lblUpload.Name = "lblUpload"
        Me.lblUpload.Size = New System.Drawing.Size(53, 20)
        Me.lblUpload.TabIndex = 0
        Me.lblUpload.TabStop = True
        Me.lblUpload.Text = "Upload"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ProgressBar1.Location = New System.Drawing.Point(75, 61)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(374, 12)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 2
        Me.ProgressBar1.Value = 2
        '
        'Timer1
        '
        Me.Timer1.Interval = 20
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
        Me.txtfile.Location = New System.Drawing.Point(75, 33)
        Me.txtfile.MaxLength = 0
        Me.txtfile.Name = "txtfile"
        Me.txtfile.ReadOnly = True
        Me.txtfile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtfile.Size = New System.Drawing.Size(374, 20)
        Me.txtfile.TabIndex = 4
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
        Me.Frame2.Location = New System.Drawing.Point(7, 64)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(457, 67)
        Me.Frame2.TabIndex = 22
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
        Me.Label5.Location = New System.Drawing.Point(4, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(67, 21)
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
        Me.cmbMonth.Location = New System.Drawing.Point(351, 31)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbMonth.Size = New System.Drawing.Size(98, 21)
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
        'lblBrowseFile
        '
        Me.lblBrowseFile.AutoSize = True
        Me.lblBrowseFile.BackColor = System.Drawing.Color.Transparent
        Me.lblBrowseFile.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBrowseFile.Enabled = False
        Me.lblBrowseFile.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrowseFile.ForeColor = System.Drawing.Color.Black
        Me.lblBrowseFile.Location = New System.Drawing.Point(8, 36)
        Me.lblBrowseFile.Name = "lblBrowseFile"
        Me.lblBrowseFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBrowseFile.Size = New System.Drawing.Size(61, 14)
        Me.lblBrowseFile.TabIndex = 6
        Me.lblBrowseFile.Text = "File Open:"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Frame1.Controls.Add(Me.txtfile)
        Me.Frame1.Controls.Add(Me.ProgressBar1)
        Me.Frame1.Controls.Add(Me.lblBrowseFile)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.Color.Orange
        Me.Frame1.Location = New System.Drawing.Point(7, 137)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(457, 90)
        Me.Frame1.TabIndex = 21
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Please select file to be uploaded"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(472, 58)
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
        Me.Label1.Size = New System.Drawing.Size(147, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "In House - RawData"
        '
        'frmInHouseRawData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 265)
        Me.Controls.Add(Me.Picture1)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInHouseRawData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Picture1.ResumeLayout(False)
        Me.Picture1.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents Picture1 As System.Windows.Forms.Panel
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Protected WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents txtfile As System.Windows.Forms.TextBox
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents cmbCompany As System.Windows.Forms.ComboBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents cmbYear As System.Windows.Forms.ComboBox
    Public WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents lblBrowseFile As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblclose As System.Windows.Forms.LinkLabel
    Friend WithEvents lblUpload As System.Windows.Forms.LinkLabel
End Class
