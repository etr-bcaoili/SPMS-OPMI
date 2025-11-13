<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIUploadingCustomerItemSharing
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbar = New System.Windows.Forms.ProgressBar()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.txtFileName = New Telerik.WinControls.UI.RadTextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.txtChannelName = New Telerik.WinControls.UI.RadTextBox()
        Me.txtChannelCode = New Telerik.WinControls.UI.RadTextBox()
        Me.txtInvalidMonth = New Telerik.WinControls.UI.RadLabel()
        Me.txtInvalidYear = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.DropMonth = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel29 = New Telerik.WinControls.UI.RadLabel()
        Me.DropYear = New Telerik.WinControls.UI.RadDropDownList()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.txtConfigtypeName = New Telerik.WinControls.UI.RadTextBox()
        Me.txtConfigtypeCode = New Telerik.WinControls.UI.RadTextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnStartProcess = New Telerik.WinControls.UI.RadButton()
        Me.btnCanced = New Telerik.WinControls.UI.RadButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFileName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChannelName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChannelCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInvalidMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInvalidYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DropMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DropYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConfigtypeName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConfigtypeCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.btnStartProcess, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCanced, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(651, 59)
        Me.Panel2.TabIndex = 56
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(9, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(249, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Customer-Item Sharing Uploading"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pbar)
        Me.Panel1.Controls.Add(Me.RadLabel1)
        Me.Panel1.Controls.Add(Me.LinkLabel2)
        Me.Panel1.Controls.Add(Me.txtFileName)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.txtChannelName)
        Me.Panel1.Controls.Add(Me.txtChannelCode)
        Me.Panel1.Controls.Add(Me.txtInvalidMonth)
        Me.Panel1.Controls.Add(Me.txtInvalidYear)
        Me.Panel1.Controls.Add(Me.RadLabel2)
        Me.Panel1.Controls.Add(Me.DropMonth)
        Me.Panel1.Controls.Add(Me.RadLabel29)
        Me.Panel1.Controls.Add(Me.DropYear)
        Me.Panel1.Controls.Add(Me.LinkLabel3)
        Me.Panel1.Controls.Add(Me.txtConfigtypeName)
        Me.Panel1.Controls.Add(Me.txtConfigtypeCode)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 59)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(651, 274)
        Me.Panel1.TabIndex = 57
        '
        'pbar
        '
        Me.pbar.BackColor = System.Drawing.Color.PowderBlue
        Me.pbar.ForeColor = System.Drawing.Color.RoyalBlue
        Me.pbar.Location = New System.Drawing.Point(135, 203)
        Me.pbar.Margin = New System.Windows.Forms.Padding(2)
        Me.pbar.Name = "pbar"
        Me.pbar.Size = New System.Drawing.Size(503, 16)
        Me.pbar.TabIndex = 880
        '
        'RadLabel1
        '
        Me.RadLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel1.Location = New System.Drawing.Point(135, 148)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(111, 19)
        Me.RadLabel1.TabIndex = 879
        Me.RadLabel1.Text = "File Name location"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.Location = New System.Drawing.Point(24, 180)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(92, 15)
        Me.LinkLabel2.TabIndex = 878
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Open File Name"
        '
        'txtFileName
        '
        Me.txtFileName.AutoSize = False
        Me.txtFileName.BackColor = System.Drawing.Color.White
        Me.txtFileName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileName.Location = New System.Drawing.Point(135, 171)
        Me.txtFileName.Multiline = True
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(503, 26)
        Me.txtFileName.TabIndex = 877
        Me.txtFileName.TabStop = False
        Me.txtFileName.ThemeName = "Office2019Light"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(24, 114)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(50, 15)
        Me.LinkLabel1.TabIndex = 875
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Channel"
        '
        'txtChannelName
        '
        Me.txtChannelName.AutoSize = False
        Me.txtChannelName.BackColor = System.Drawing.Color.White
        Me.txtChannelName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChannelName.Location = New System.Drawing.Point(287, 108)
        Me.txtChannelName.Multiline = True
        Me.txtChannelName.Name = "txtChannelName"
        Me.txtChannelName.ReadOnly = True
        Me.txtChannelName.Size = New System.Drawing.Size(351, 26)
        Me.txtChannelName.TabIndex = 874
        Me.txtChannelName.TabStop = False
        Me.txtChannelName.ThemeName = "Office2019Light"
        '
        'txtChannelCode
        '
        Me.txtChannelCode.AutoSize = False
        Me.txtChannelCode.BackColor = System.Drawing.Color.White
        Me.txtChannelCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChannelCode.Location = New System.Drawing.Point(135, 108)
        Me.txtChannelCode.Multiline = True
        Me.txtChannelCode.Name = "txtChannelCode"
        Me.txtChannelCode.ReadOnly = True
        Me.txtChannelCode.Size = New System.Drawing.Size(150, 26)
        Me.txtChannelCode.TabIndex = 873
        Me.txtChannelCode.TabStop = False
        Me.txtChannelCode.ThemeName = "Office2019Light"
        '
        'txtInvalidMonth
        '
        Me.txtInvalidMonth.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvalidMonth.Location = New System.Drawing.Point(297, 61)
        Me.txtInvalidMonth.Name = "txtInvalidMonth"
        Me.txtInvalidMonth.Size = New System.Drawing.Size(2, 2)
        Me.txtInvalidMonth.TabIndex = 872
        '
        'txtInvalidYear
        '
        Me.txtInvalidYear.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvalidYear.Location = New System.Drawing.Point(297, 37)
        Me.txtInvalidYear.Name = "txtInvalidYear"
        Me.txtInvalidYear.Size = New System.Drawing.Size(2, 2)
        Me.txtInvalidYear.TabIndex = 871
        '
        'RadLabel2
        '
        Me.RadLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel2.Location = New System.Drawing.Point(24, 53)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(44, 19)
        Me.RadLabel2.TabIndex = 870
        Me.RadLabel2.Text = "Month"
        '
        'DropMonth
        '
        Me.DropMonth.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DropMonth.Location = New System.Drawing.Point(135, 51)
        Me.DropMonth.Name = "DropMonth"
        Me.DropMonth.Size = New System.Drawing.Size(150, 23)
        Me.DropMonth.TabIndex = 869
        '
        'RadLabel29
        '
        Me.RadLabel29.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel29.Location = New System.Drawing.Point(24, 26)
        Me.RadLabel29.Name = "RadLabel29"
        Me.RadLabel29.Size = New System.Drawing.Size(31, 19)
        Me.RadLabel29.TabIndex = 868
        Me.RadLabel29.Text = "Year"
        '
        'DropYear
        '
        Me.DropYear.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DropYear.Location = New System.Drawing.Point(135, 24)
        Me.DropYear.Name = "DropYear"
        Me.DropYear.Size = New System.Drawing.Size(150, 23)
        Me.DropYear.TabIndex = 867
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel3.Location = New System.Drawing.Point(24, 85)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(67, 15)
        Me.LinkLabel3.TabIndex = 866
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "ConfigType"
        '
        'txtConfigtypeName
        '
        Me.txtConfigtypeName.AutoSize = False
        Me.txtConfigtypeName.BackColor = System.Drawing.Color.White
        Me.txtConfigtypeName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfigtypeName.Location = New System.Drawing.Point(287, 78)
        Me.txtConfigtypeName.Multiline = True
        Me.txtConfigtypeName.Name = "txtConfigtypeName"
        Me.txtConfigtypeName.ReadOnly = True
        Me.txtConfigtypeName.Size = New System.Drawing.Size(351, 26)
        Me.txtConfigtypeName.TabIndex = 865
        Me.txtConfigtypeName.TabStop = False
        Me.txtConfigtypeName.ThemeName = "Office2019Light"
        '
        'txtConfigtypeCode
        '
        Me.txtConfigtypeCode.AutoSize = False
        Me.txtConfigtypeCode.BackColor = System.Drawing.Color.White
        Me.txtConfigtypeCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfigtypeCode.Location = New System.Drawing.Point(135, 78)
        Me.txtConfigtypeCode.Multiline = True
        Me.txtConfigtypeCode.Name = "txtConfigtypeCode"
        Me.txtConfigtypeCode.ReadOnly = True
        Me.txtConfigtypeCode.Size = New System.Drawing.Size(150, 26)
        Me.txtConfigtypeCode.TabIndex = 864
        Me.txtConfigtypeCode.TabStop = False
        Me.txtConfigtypeCode.ThemeName = "Office2019Light"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.btnStartProcess)
        Me.Panel3.Controls.Add(Me.btnCanced)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 230)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(649, 42)
        Me.Panel3.TabIndex = 57
        '
        'btnStartProcess
        '
        Me.btnStartProcess.Location = New System.Drawing.Point(466, 3)
        Me.btnStartProcess.Name = "btnStartProcess"
        Me.btnStartProcess.Size = New System.Drawing.Size(83, 32)
        Me.btnStartProcess.TabIndex = 3
        Me.btnStartProcess.Text = "Start Upload"
        Me.btnStartProcess.ThemeName = "Office2010Silver"
        '
        'btnCanced
        '
        Me.btnCanced.Location = New System.Drawing.Point(554, 3)
        Me.btnCanced.Name = "btnCanced"
        Me.btnCanced.Size = New System.Drawing.Size(83, 32)
        Me.btnCanced.TabIndex = 2
        Me.btnCanced.Text = "&Closed"
        Me.btnCanced.ThemeName = "Office2010Silver"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'UIUploadingCustomerItemSharing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(651, 333)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "UIUploadingCustomerItemSharing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UIUploadingCustomerItemSharing"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFileName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChannelName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChannelCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInvalidMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInvalidYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DropMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DropYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConfigtypeName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConfigtypeCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.btnStartProcess, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCanced, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnStartProcess As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCanced As Telerik.WinControls.UI.RadButton
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents txtChannelName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtChannelCode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtInvalidMonth As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtInvalidYear As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents DropMonth As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadLabel29 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents DropYear As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents txtConfigtypeName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtConfigtypeCode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents txtFileName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents pbar As ProgressBar
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
