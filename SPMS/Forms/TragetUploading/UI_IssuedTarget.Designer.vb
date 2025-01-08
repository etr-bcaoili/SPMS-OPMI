<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UI_IssuedTarget
    Inherits Telerik.WinControls.UI.RadForm

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
        Me.Office2010BlueTheme1 = New Telerik.WinControls.Themes.Office2010BlueTheme()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbConfigtypeCode = New System.Windows.Forms.ToolStripComboBox()
        Me.txtconfigtypeName = New System.Windows.Forms.ToolStripLabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.Find = New System.Windows.Forms.LinkLabel()
        Me.txtFileName = New Telerik.WinControls.UI.RadTextBox()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.cboyear = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadMenu1 = New Telerik.WinControls.UI.RadMenu()
        Me.btnUpload = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnCanceled = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.pgbr = New Telerik.WinControls.UI.RadProgressBar()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox2.SuspendLayout()
        CType(Me.txtFileName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.cboyear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pgbr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cmbConfigtypeCode, Me.txtconfigtypeName})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 60)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(442, 25)
        Me.ToolStrip1.TabIndex = 58
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(74, 22)
        Me.ToolStripLabel1.Text = "ConfigType :"
        '
        'cmbConfigtypeCode
        '
        Me.cmbConfigtypeCode.Name = "cmbConfigtypeCode"
        Me.cmbConfigtypeCode.Size = New System.Drawing.Size(121, 25)
        '
        'txtconfigtypeName
        '
        Me.txtconfigtypeName.Name = "txtconfigtypeName"
        Me.txtconfigtypeName.Size = New System.Drawing.Size(0, 22)
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.RadGroupBox2)
        Me.Panel3.Controls.Add(Me.RadGroupBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 85)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(442, 193)
        Me.Panel3.TabIndex = 59
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 150)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(442, 43)
        Me.Panel2.TabIndex = 2
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox2.Controls.Add(Me.pgbr)
        Me.RadGroupBox2.Controls.Add(Me.Find)
        Me.RadGroupBox2.Controls.Add(Me.txtFileName)
        Me.RadGroupBox2.HeaderText = "Please select file to be Uploaded"
        Me.RadGroupBox2.Location = New System.Drawing.Point(5, 63)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        Me.RadGroupBox2.Size = New System.Drawing.Size(426, 81)
        Me.RadGroupBox2.TabIndex = 1
        Me.RadGroupBox2.Text = "Please select file to be Uploaded"
        Me.RadGroupBox2.ThemeName = "Office2010Blue"
        '
        'Find
        '
        Me.Find.AutoSize = True
        Me.Find.Location = New System.Drawing.Point(30, 37)
        Me.Find.Name = "Find"
        Me.Find.Size = New System.Drawing.Size(42, 13)
        Me.Find.TabIndex = 152
        Me.Find.TabStop = True
        Me.Find.Text = "Find ..."
        '
        'txtFileName
        '
        Me.txtFileName.AutoSize = False
        Me.txtFileName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFileName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileName.Location = New System.Drawing.Point(78, 30)
        Me.txtFileName.Multiline = True
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(343, 25)
        Me.txtFileName.TabIndex = 4
        Me.txtFileName.ThemeName = "Office2010Blue"
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Controls.Add(Me.cboyear)
        Me.RadGroupBox1.FooterImageAlignment = System.Drawing.ContentAlignment.TopRight
        Me.RadGroupBox1.HeaderText = "Issued Target Year "
        Me.RadGroupBox1.HeaderTextAlignment = System.Drawing.ContentAlignment.TopRight
        Me.RadGroupBox1.Location = New System.Drawing.Point(5, 9)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(426, 48)
        Me.RadGroupBox1.TabIndex = 0
        Me.RadGroupBox1.Text = "Issued Target Year "
        Me.RadGroupBox1.ThemeName = "Office2010Blue"
        '
        'cboyear
        '
        Me.cboyear.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboyear.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboyear.Location = New System.Drawing.Point(78, 19)
        Me.cboyear.Name = "cboyear"
        Me.cboyear.Size = New System.Drawing.Size(125, 21)
        Me.cboyear.TabIndex = 1
        Me.cboyear.ThemeName = "Office2010Black"
        '
        'RadMenu1
        '
        Me.RadMenu1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RadMenu1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnUpload, Me.btnCanceled})
        Me.RadMenu1.Location = New System.Drawing.Point(0, 237)
        Me.RadMenu1.Name = "RadMenu1"
        Me.RadMenu1.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        Me.RadMenu1.Size = New System.Drawing.Size(442, 41)
        Me.RadMenu1.TabIndex = 60
        Me.RadMenu1.ThemeName = "Office2010Blue"
        '
        'btnUpload
        '
        Me.btnUpload.Image = Global.SPMSOPCI.My.Resources.Resources.iconfinder_Rounded_06_2024632
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Text = "&Upload"
        Me.btnUpload.UseCompatibleTextRendering = False
        '
        'btnCanceled
        '
        Me.btnCanceled.Image = Global.SPMSOPCI.My.Resources.Resources.if_Close_1891023__1_
        Me.btnCanceled.Name = "btnCanceled"
        Me.btnCanceled.Text = "Canceled"
        Me.btnCanceled.UseCompatibleTextRendering = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(442, 60)
        Me.Panel1.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(16, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Issued Target"
        '
        'Timer1
        '
        Me.Timer1.Interval = 20
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'pgbr
        '
        Me.pgbr.Location = New System.Drawing.Point(78, 58)
        Me.pgbr.Name = "pgbr"
        Me.pgbr.Size = New System.Drawing.Size(343, 18)
        Me.pgbr.TabIndex = 153
        Me.pgbr.Visible = False
        '
        'UI_IssuedTarget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 278)
        Me.Controls.Add(Me.RadMenu1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UI_IssuedTarget"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ""
        Me.ThemeName = "Office2010Blue"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox2.ResumeLayout(False)
        Me.RadGroupBox2.PerformLayout()
        CType(Me.txtFileName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.cboyear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pgbr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Office2010BlueTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbConfigtypeCode As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents txtconfigtypeName As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadGroupBox2 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents cboyear As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents Find As System.Windows.Forms.LinkLabel
    Friend WithEvents txtFileName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents btnUpload As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnCanceled As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pgbr As Telerik.WinControls.UI.RadProgressBar
End Class

