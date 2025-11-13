<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UISASDistrictTarget
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pbar = New System.Windows.Forms.ProgressBar()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.txtFileName = New Telerik.WinControls.UI.RadTextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnUploadinFormat = New Telerik.WinControls.UI.RadButton()
        Me.btnStartProcess = New Telerik.WinControls.UI.RadButton()
        Me.btnCanced = New Telerik.WinControls.UI.RadButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtConfigtypeCode = New Telerik.WinControls.UI.RadTextBox()
        Me.txtConfigtypeName = New Telerik.WinControls.UI.RadTextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.DropYear = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel29 = New Telerik.WinControls.UI.RadLabel()
        Me.txtInvalidYear = New Telerik.WinControls.UI.RadLabel()
        Me.txtInvalidMonth = New Telerik.WinControls.UI.RadLabel()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFileName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.btnUploadinFormat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnStartProcess, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCanced, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.txtConfigtypeCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConfigtypeName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DropYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInvalidYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInvalidMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(657, 293)
        Me.Panel1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.pbar)
        Me.Panel4.Controls.Add(Me.RadLabel1)
        Me.Panel4.Controls.Add(Me.LinkLabel2)
        Me.Panel4.Controls.Add(Me.txtFileName)
        Me.Panel4.Controls.Add(Me.txtInvalidMonth)
        Me.Panel4.Controls.Add(Me.txtInvalidYear)
        Me.Panel4.Controls.Add(Me.RadLabel29)
        Me.Panel4.Controls.Add(Me.DropYear)
        Me.Panel4.Controls.Add(Me.LinkLabel3)
        Me.Panel4.Controls.Add(Me.txtConfigtypeName)
        Me.Panel4.Controls.Add(Me.txtConfigtypeCode)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 59)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(655, 190)
        Me.Panel4.TabIndex = 61
        '
        'pbar
        '
        Me.pbar.BackColor = System.Drawing.Color.PowderBlue
        Me.pbar.ForeColor = System.Drawing.Color.RoyalBlue
        Me.pbar.Location = New System.Drawing.Point(130, 147)
        Me.pbar.Margin = New System.Windows.Forms.Padding(2)
        Me.pbar.Name = "pbar"
        Me.pbar.Size = New System.Drawing.Size(503, 16)
        Me.pbar.TabIndex = 907
        '
        'RadLabel1
        '
        Me.RadLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel1.Location = New System.Drawing.Point(130, 92)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(111, 19)
        Me.RadLabel1.TabIndex = 906
        Me.RadLabel1.Text = "File Name location"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.Location = New System.Drawing.Point(19, 124)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(92, 15)
        Me.LinkLabel2.TabIndex = 905
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Open File Name"
        '
        'txtFileName
        '
        Me.txtFileName.AutoSize = False
        Me.txtFileName.BackColor = System.Drawing.Color.White
        Me.txtFileName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileName.Location = New System.Drawing.Point(130, 115)
        Me.txtFileName.Multiline = True
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(503, 26)
        Me.txtFileName.TabIndex = 904
        Me.txtFileName.TabStop = False
        Me.txtFileName.ThemeName = "Office2019Light"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.btnUploadinFormat)
        Me.Panel3.Controls.Add(Me.btnStartProcess)
        Me.Panel3.Controls.Add(Me.btnCanced)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 249)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(655, 42)
        Me.Panel3.TabIndex = 60
        '
        'btnUploadinFormat
        '
        Me.btnUploadinFormat.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUploadinFormat.Location = New System.Drawing.Point(6, 4)
        Me.btnUploadinFormat.Name = "btnUploadinFormat"
        Me.btnUploadinFormat.Size = New System.Drawing.Size(107, 32)
        Me.btnUploadinFormat.TabIndex = 4
        Me.btnUploadinFormat.Text = "Uploading Format"
        Me.btnUploadinFormat.ThemeName = "Office2010Silver"
        '
        'btnStartProcess
        '
        Me.btnStartProcess.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartProcess.Location = New System.Drawing.Point(476, 4)
        Me.btnStartProcess.Name = "btnStartProcess"
        Me.btnStartProcess.Size = New System.Drawing.Size(83, 32)
        Me.btnStartProcess.TabIndex = 3
        Me.btnStartProcess.Text = "Start Upload"
        Me.btnStartProcess.ThemeName = "Office2010Silver"
        '
        'btnCanced
        '
        Me.btnCanced.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCanced.Location = New System.Drawing.Point(564, 4)
        Me.btnCanced.Name = "btnCanced"
        Me.btnCanced.Size = New System.Drawing.Size(83, 32)
        Me.btnCanced.TabIndex = 2
        Me.btnCanced.Text = "&Closed"
        Me.btnCanced.ThemeName = "Office2010Silver"
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
        Me.Panel2.Size = New System.Drawing.Size(655, 59)
        Me.Panel2.TabIndex = 59
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(11, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(137, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "SAS District Target"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtConfigtypeCode
        '
        Me.txtConfigtypeCode.AutoSize = False
        Me.txtConfigtypeCode.BackColor = System.Drawing.Color.White
        Me.txtConfigtypeCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfigtypeCode.Location = New System.Drawing.Point(130, 54)
        Me.txtConfigtypeCode.Multiline = True
        Me.txtConfigtypeCode.Name = "txtConfigtypeCode"
        Me.txtConfigtypeCode.ReadOnly = True
        Me.txtConfigtypeCode.Size = New System.Drawing.Size(150, 26)
        Me.txtConfigtypeCode.TabIndex = 897
        Me.txtConfigtypeCode.TabStop = False
        Me.txtConfigtypeCode.ThemeName = "Office2019Light"
        '
        'txtConfigtypeName
        '
        Me.txtConfigtypeName.AutoSize = False
        Me.txtConfigtypeName.BackColor = System.Drawing.Color.White
        Me.txtConfigtypeName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfigtypeName.Location = New System.Drawing.Point(282, 54)
        Me.txtConfigtypeName.Multiline = True
        Me.txtConfigtypeName.Name = "txtConfigtypeName"
        Me.txtConfigtypeName.ReadOnly = True
        Me.txtConfigtypeName.Size = New System.Drawing.Size(351, 26)
        Me.txtConfigtypeName.TabIndex = 898
        Me.txtConfigtypeName.TabStop = False
        Me.txtConfigtypeName.ThemeName = "Office2019Light"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel3.Location = New System.Drawing.Point(19, 61)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(67, 15)
        Me.LinkLabel3.TabIndex = 899
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "ConfigType"
        '
        'DropYear
        '
        Me.DropYear.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DropYear.Location = New System.Drawing.Point(130, 26)
        Me.DropYear.Name = "DropYear"
        Me.DropYear.Size = New System.Drawing.Size(150, 23)
        Me.DropYear.TabIndex = 900
        '
        'RadLabel29
        '
        Me.RadLabel29.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel29.Location = New System.Drawing.Point(19, 28)
        Me.RadLabel29.Name = "RadLabel29"
        Me.RadLabel29.Size = New System.Drawing.Size(31, 19)
        Me.RadLabel29.TabIndex = 901
        Me.RadLabel29.Text = "Year"
        '
        'txtInvalidYear
        '
        Me.txtInvalidYear.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvalidYear.Location = New System.Drawing.Point(292, 36)
        Me.txtInvalidYear.Name = "txtInvalidYear"
        Me.txtInvalidYear.Size = New System.Drawing.Size(2, 2)
        Me.txtInvalidYear.TabIndex = 902
        '
        'txtInvalidMonth
        '
        Me.txtInvalidMonth.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvalidMonth.Location = New System.Drawing.Point(292, 34)
        Me.txtInvalidMonth.Name = "txtInvalidMonth"
        Me.txtInvalidMonth.Size = New System.Drawing.Size(2, 2)
        Me.txtInvalidMonth.TabIndex = 903
        '
        'UISASDistrictTarget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(657, 293)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "UISASDistrictTarget"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UISASDistrictTarget"
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFileName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.btnUploadinFormat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnStartProcess, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCanced, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.txtConfigtypeCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConfigtypeName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DropYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInvalidYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInvalidMonth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnStartProcess As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCanced As Telerik.WinControls.UI.RadButton
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnUploadinFormat As Telerik.WinControls.UI.RadButton
    Friend WithEvents pbar As ProgressBar
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents txtFileName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents txtInvalidMonth As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtInvalidYear As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel29 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents DropYear As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents txtConfigtypeName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtConfigtypeCode As Telerik.WinControls.UI.RadTextBox
End Class
