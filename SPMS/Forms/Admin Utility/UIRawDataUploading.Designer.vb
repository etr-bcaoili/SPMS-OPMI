<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIRawDataUploading
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pbar = New System.Windows.Forms.ProgressBar()
        Me.txtFindName = New Telerik.WinControls.UI.RadTextBox()
        Me.btnFind = New Telerik.WinControls.UI.RadButton()
        Me.cmbFiletype = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboyear = New System.Windows.Forms.ComboBox()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.txtChannelName = New Telerik.WinControls.UI.RadTextBox()
        Me.txtChannelCode = New Telerik.WinControls.UI.RadTextBox()
        Me.FindBestTimeCall = New System.Windows.Forms.LinkLabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.RadMenu1 = New Telerik.WinControls.UI.RadMenu()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnUpload = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClose = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.txtFindName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnFind, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChannelName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChannelCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 59)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(432, 228)
        Me.Panel2.TabIndex = 16
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.pbar)
        Me.Panel4.Controls.Add(Me.txtFindName)
        Me.Panel4.Controls.Add(Me.btnFind)
        Me.Panel4.Controls.Add(Me.cmbFiletype)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.cboMonth)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.cboyear)
        Me.Panel4.Controls.Add(Me.lblItemCode)
        Me.Panel4.Controls.Add(Me.txtChannelName)
        Me.Panel4.Controls.Add(Me.txtChannelCode)
        Me.Panel4.Controls.Add(Me.FindBestTimeCall)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(432, 190)
        Me.Panel4.TabIndex = 1
        '
        'pbar
        '
        Me.pbar.ForeColor = System.Drawing.Color.RoyalBlue
        Me.pbar.Location = New System.Drawing.Point(110, 161)
        Me.pbar.Name = "pbar"
        Me.pbar.Size = New System.Drawing.Size(301, 11)
        Me.pbar.Step = 1
        Me.pbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbar.TabIndex = 269
        Me.pbar.Value = 2
        '
        'txtFindName
        '
        Me.txtFindName.AutoSize = False
        Me.txtFindName.BackColor = System.Drawing.Color.White
        Me.txtFindName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFindName.Location = New System.Drawing.Point(110, 131)
        Me.txtFindName.Multiline = True
        Me.txtFindName.Name = "txtFindName"
        Me.txtFindName.ReadOnly = True
        Me.txtFindName.Size = New System.Drawing.Size(301, 24)
        Me.txtFindName.TabIndex = 268
        Me.txtFindName.ThemeName = "Office2010Black"
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(40, 130)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(59, 24)
        Me.btnFind.TabIndex = 267
        Me.btnFind.Text = "Find ..."
        '
        'cmbFiletype
        '
        Me.cmbFiletype.FormattingEnabled = True
        Me.cmbFiletype.Items.AddRange(New Object() {".XLS", ".TXT", ".SP"})
        Me.cmbFiletype.Location = New System.Drawing.Point(110, 99)
        Me.cmbFiletype.Name = "cmbFiletype"
        Me.cmbFiletype.Size = New System.Drawing.Size(110, 21)
        Me.cmbFiletype.TabIndex = 266
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(45, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 15)
        Me.Label3.TabIndex = 265
        Me.Label3.Text = "File Type :"
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(110, 75)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(110, 21)
        Me.cboMonth.TabIndex = 264
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(54, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 15)
        Me.Label2.TabIndex = 263
        Me.Label2.Text = "Month :"
        '
        'cboyear
        '
        Me.cboyear.FormattingEnabled = True
        Me.cboyear.Location = New System.Drawing.Point(110, 51)
        Me.cboyear.Name = "cboyear"
        Me.cboyear.Size = New System.Drawing.Size(110, 21)
        Me.cboyear.TabIndex = 262
        '
        'lblItemCode
        '
        Me.lblItemCode.AutoSize = True
        Me.lblItemCode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemCode.Location = New System.Drawing.Point(68, 53)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Size = New System.Drawing.Size(35, 15)
        Me.lblItemCode.TabIndex = 261
        Me.lblItemCode.Text = "Year :"
        '
        'txtChannelName
        '
        Me.txtChannelName.AutoSize = False
        Me.txtChannelName.BackColor = System.Drawing.Color.White
        Me.txtChannelName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChannelName.Location = New System.Drawing.Point(222, 24)
        Me.txtChannelName.Multiline = True
        Me.txtChannelName.Name = "txtChannelName"
        Me.txtChannelName.ReadOnly = True
        Me.txtChannelName.Size = New System.Drawing.Size(189, 24)
        Me.txtChannelName.TabIndex = 260
        Me.txtChannelName.ThemeName = "Office2010Black"
        '
        'txtChannelCode
        '
        Me.txtChannelCode.AutoSize = False
        Me.txtChannelCode.BackColor = System.Drawing.Color.White
        Me.txtChannelCode.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChannelCode.Location = New System.Drawing.Point(110, 24)
        Me.txtChannelCode.Multiline = True
        Me.txtChannelCode.Name = "txtChannelCode"
        Me.txtChannelCode.ReadOnly = True
        Me.txtChannelCode.Size = New System.Drawing.Size(110, 24)
        Me.txtChannelCode.TabIndex = 259
        Me.txtChannelCode.ThemeName = "Office2010Black"
        '
        'FindBestTimeCall
        '
        Me.FindBestTimeCall.AutoSize = True
        Me.FindBestTimeCall.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FindBestTimeCall.Location = New System.Drawing.Point(27, 29)
        Me.FindBestTimeCall.Name = "FindBestTimeCall"
        Me.FindBestTimeCall.Size = New System.Drawing.Size(76, 14)
        Me.FindBestTimeCall.TabIndex = 258
        Me.FindBestTimeCall.TabStop = True
        Me.FindBestTimeCall.Text = "Channel MD :"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.RadMenu1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 190)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(432, 38)
        Me.Panel3.TabIndex = 0
        '
        'RadMenu1
        '
        Me.RadMenu1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RadMenu1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnUpload, Me.btnClose})
        Me.RadMenu1.Location = New System.Drawing.Point(0, 4)
        Me.RadMenu1.Name = "RadMenu1"
        Me.RadMenu1.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        Me.RadMenu1.Size = New System.Drawing.Size(430, 32)
        Me.RadMenu1.TabIndex = 48
        Me.RadMenu1.ThemeName = "Office2010Blue"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnUpload
        '
        Me.btnUpload.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpload.Image = Global.SPMSOPCI.My.Resources.Resources.file_upload
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseCompatibleTextRendering = False
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = Global.SPMSOPCI.My.Resources.Resources.if_ko_red_539481
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Text = "&Cancel"
        Me.btnClose.UseCompatibleTextRendering = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(432, 59)
        Me.Panel1.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "RawData"
        '
        'UIRawDataUploading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 287)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UIRawDataUploading"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RawData Medical Doctor"
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.txtFindName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnFind, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChannelName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChannelCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents btnUpload As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txtChannelName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtChannelCode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents FindBestTimeCall As System.Windows.Forms.LinkLabel
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboyear As System.Windows.Forms.ComboBox
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Protected WithEvents pbar As System.Windows.Forms.ProgressBar
    Friend WithEvents txtFindName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents btnFind As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmbFiletype As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
