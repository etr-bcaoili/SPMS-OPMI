<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UISharingUploading
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
        Me.pbar = New System.Windows.Forms.ProgressBar()
        Me.btnClear = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.txtFilename = New Telerik.WinControls.UI.RadTextBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.txtDistributor = New Telerik.WinControls.UI.RadTextBox()
        Me.lnkMotherCode = New System.Windows.Forms.LinkLabel()
        Me.txtConfig = New Telerik.WinControls.UI.RadTextBox()
        Me.RadMenu1 = New Telerik.WinControls.UI.RadMenu()
        Me.btnFind = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel2.SuspendLayout()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFilename, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDistributor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConfig, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbar
        '
        Me.pbar.BackColor = System.Drawing.Color.PowderBlue
        Me.pbar.ForeColor = System.Drawing.Color.RoyalBlue
        Me.pbar.Location = New System.Drawing.Point(15, 174)
        Me.pbar.Margin = New System.Windows.Forms.Padding(2)
        Me.pbar.Name = "pbar"
        Me.pbar.Size = New System.Drawing.Size(387, 10)
        Me.pbar.TabIndex = 54
        '
        'btnClear
        '
        Me.btnClear.AccessibleDescription = "&Cancel"
        Me.btnClear.AccessibleName = "&Cancel"
        '
        '
        '
        Me.btnClear.ButtonElement.AccessibleDescription = "&Cancel"
        Me.btnClear.ButtonElement.AccessibleName = "&Cancel"
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Image = Global.SPMSOPCI.My.Resources.Resources.if_ko_red_539482
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Text = "&Cancel"
        Me.btnClear.UseCompatibleTextRendering = False
        Me.btnClear.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.pbar)
        Me.Panel2.Controls.Add(Me.RadLabel1)
        Me.Panel2.Controls.Add(Me.RadLabel3)
        Me.Panel2.Controls.Add(Me.cboMonth)
        Me.Panel2.Controls.Add(Me.cboYear)
        Me.Panel2.Controls.Add(Me.txtFilename)
        Me.Panel2.Controls.Add(Me.LinkLabel2)
        Me.Panel2.Controls.Add(Me.LinkLabel1)
        Me.Panel2.Controls.Add(Me.txtDistributor)
        Me.Panel2.Controls.Add(Me.lnkMotherCode)
        Me.Panel2.Controls.Add(Me.txtConfig)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 59)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(418, 195)
        Me.Panel2.TabIndex = 49
        '
        'RadLabel1
        '
        Me.RadLabel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel1.Location = New System.Drawing.Point(12, 92)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(44, 19)
        Me.RadLabel1.TabIndex = 731
        Me.RadLabel1.Text = "Month"
        '
        'RadLabel3
        '
        Me.RadLabel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel3.Location = New System.Drawing.Point(12, 68)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(35, 19)
        Me.RadLabel3.TabIndex = 730
        Me.RadLabel3.Text = "Year "
        '
        'cboMonth
        '
        Me.cboMonth.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(129, 90)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(132, 23)
        Me.cboMonth.TabIndex = 729
        '
        'cboYear
        '
        Me.cboYear.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(129, 64)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(132, 23)
        Me.cboYear.TabIndex = 728
        '
        'txtFilename
        '
        Me.txtFilename.AutoSize = False
        Me.txtFilename.BackColor = System.Drawing.Color.White
        Me.txtFilename.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilename.Location = New System.Drawing.Point(84, 145)
        Me.txtFilename.Multiline = True
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.ReadOnly = True
        Me.txtFilename.Size = New System.Drawing.Size(318, 24)
        Me.txtFilename.TabIndex = 727
        Me.txtFilename.TabStop = False
        Me.txtFilename.ThemeName = "Office2019Light"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.Location = New System.Drawing.Point(12, 150)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(63, 15)
        Me.LinkLabel2.TabIndex = 726
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "File Name "
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(12, 42)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(67, 15)
        Me.LinkLabel1.TabIndex = 725
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Distributor "
        '
        'txtDistributor
        '
        Me.txtDistributor.AutoSize = False
        Me.txtDistributor.BackColor = System.Drawing.Color.White
        Me.txtDistributor.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDistributor.Location = New System.Drawing.Point(129, 37)
        Me.txtDistributor.Multiline = True
        Me.txtDistributor.Name = "txtDistributor"
        Me.txtDistributor.ReadOnly = True
        Me.txtDistributor.Size = New System.Drawing.Size(273, 24)
        Me.txtDistributor.TabIndex = 724
        Me.txtDistributor.TabStop = False
        Me.txtDistributor.ThemeName = "Office2019Light"
        '
        'lnkMotherCode
        '
        Me.lnkMotherCode.AutoSize = True
        Me.lnkMotherCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkMotherCode.Location = New System.Drawing.Point(12, 16)
        Me.lnkMotherCode.Name = "lnkMotherCode"
        Me.lnkMotherCode.Size = New System.Drawing.Size(100, 15)
        Me.lnkMotherCode.TabIndex = 723
        Me.lnkMotherCode.TabStop = True
        Me.lnkMotherCode.Text = "ConfigType Code "
        '
        'txtConfig
        '
        Me.txtConfig.AutoSize = False
        Me.txtConfig.BackColor = System.Drawing.Color.White
        Me.txtConfig.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfig.Location = New System.Drawing.Point(129, 11)
        Me.txtConfig.Multiline = True
        Me.txtConfig.Name = "txtConfig"
        Me.txtConfig.ReadOnly = True
        Me.txtConfig.Size = New System.Drawing.Size(273, 24)
        Me.txtConfig.TabIndex = 722
        Me.txtConfig.TabStop = False
        Me.txtConfig.ThemeName = "Office2019Light"
        '
        'RadMenu1
        '
        Me.RadMenu1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RadMenu1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnFind, Me.btnClear})
        Me.RadMenu1.Location = New System.Drawing.Point(0, 254)
        Me.RadMenu1.Name = "RadMenu1"
        Me.RadMenu1.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        '
        '
        '
        Me.RadMenu1.RootElement.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        Me.RadMenu1.Size = New System.Drawing.Size(418, 38)
        Me.RadMenu1.TabIndex = 48
        Me.RadMenu1.ThemeName = "Office2010Blue"
        '
        'btnFind
        '
        Me.btnFind.AccessibleDescription = "Upload"
        Me.btnFind.AccessibleName = "Upload"
        '
        '
        '
        Me.btnFind.ButtonElement.AccessibleDescription = "Upload"
        Me.btnFind.ButtonElement.AccessibleName = "Upload"
        Me.btnFind.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFind.Image = Global.SPMSOPCI.My.Resources.Resources.file_upload1
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Text = "Upload"
        Me.btnFind.UseCompatibleTextRendering = False
        Me.btnFind.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(418, 59)
        Me.Panel1.TabIndex = 31
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(184, 30)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Sharing Uploading"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(-61, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product Manager"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'UISharingUploading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 292)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.RadMenu1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "UISharingUploading"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UISharingUploading"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFilename, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDistributor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConfig, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents btnFind As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClear As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtFilename As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtDistributor As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lnkMotherCode As System.Windows.Forms.LinkLabel
    Friend WithEvents txtConfig As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents pbar As System.Windows.Forms.ProgressBar
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
