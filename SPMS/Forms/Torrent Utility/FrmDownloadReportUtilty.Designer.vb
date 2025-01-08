<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDownloadReportUtilty
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
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.cmdToMonth = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.cmdFromMonth = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.cmdYear = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.chkProductPerfPeriodToPerio = New System.Windows.Forms.RadioButton()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.txtConfigtypeName = New Telerik.WinControls.UI.RadTextBox()
        Me.cmdConfigtype = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.RadMenu1 = New Telerik.WinControls.UI.RadMenu()
        Me.btnExcelReport = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClear = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox2.SuspendLayout()
        CType(Me.cmdToMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdFromMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.txtConfigtypeName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdConfigtype, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 60)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(470, 249)
        Me.Panel2.TabIndex = 19
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.RadGroupBox2)
        Me.Panel5.Controls.Add(Me.RadGroupBox1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(470, 211)
        Me.Panel5.TabIndex = 44
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox2.BackColor = System.Drawing.Color.White
        Me.RadGroupBox2.Controls.Add(Me.cmdToMonth)
        Me.RadGroupBox2.Controls.Add(Me.RadLabel4)
        Me.RadGroupBox2.Controls.Add(Me.cmdFromMonth)
        Me.RadGroupBox2.Controls.Add(Me.RadLabel3)
        Me.RadGroupBox2.Controls.Add(Me.cmdYear)
        Me.RadGroupBox2.Controls.Add(Me.RadLabel2)
        Me.RadGroupBox2.Controls.Add(Me.chkProductPerfPeriodToPerio)
        Me.RadGroupBox2.HeaderText = "Selected Info"
        Me.RadGroupBox2.Location = New System.Drawing.Point(7, 70)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        '
        '
        '
        Me.RadGroupBox2.RootElement.Padding = New System.Windows.Forms.Padding(2, 18, 2, 2)
        Me.RadGroupBox2.Size = New System.Drawing.Size(455, 112)
        Me.RadGroupBox2.TabIndex = 1
        Me.RadGroupBox2.Text = "Selected Info"
        Me.RadGroupBox2.ThemeName = "Office2010Silver"
        '
        'cmdToMonth
        '
        Me.cmdToMonth.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdToMonth.Location = New System.Drawing.Point(335, 84)
        Me.cmdToMonth.Name = "cmdToMonth"
        Me.cmdToMonth.Size = New System.Drawing.Size(107, 20)
        Me.cmdToMonth.TabIndex = 183
        Me.cmdToMonth.ThemeName = "Office2010Black"
        '
        'RadLabel4
        '
        Me.RadLabel4.Location = New System.Drawing.Point(241, 85)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(61, 18)
        Me.RadLabel4.TabIndex = 182
        Me.RadLabel4.Text = "To Month :"
        '
        'cmdFromMonth
        '
        Me.cmdFromMonth.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFromMonth.Location = New System.Drawing.Point(335, 60)
        Me.cmdFromMonth.Name = "cmdFromMonth"
        Me.cmdFromMonth.Size = New System.Drawing.Size(107, 20)
        Me.cmdFromMonth.TabIndex = 181
        Me.cmdFromMonth.ThemeName = "Office2010Black"
        '
        'RadLabel3
        '
        Me.RadLabel3.Location = New System.Drawing.Point(241, 61)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(74, 18)
        Me.RadLabel3.TabIndex = 180
        Me.RadLabel3.Text = "From Month :"
        '
        'cmdYear
        '
        Me.cmdYear.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdYear.Location = New System.Drawing.Point(122, 64)
        Me.cmdYear.Name = "cmdYear"
        Me.cmdYear.Size = New System.Drawing.Size(107, 20)
        Me.cmdYear.TabIndex = 179
        Me.cmdYear.ThemeName = "Office2010Black"
        '
        'RadLabel2
        '
        Me.RadLabel2.Location = New System.Drawing.Point(20, 65)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(50, 18)
        Me.RadLabel2.TabIndex = 178
        Me.RadLabel2.Text = "Year of  :"
        '
        'chkProductPerfPeriodToPerio
        '
        Me.chkProductPerfPeriodToPerio.AutoSize = True
        Me.chkProductPerfPeriodToPerio.Checked = True
        Me.chkProductPerfPeriodToPerio.Location = New System.Drawing.Point(122, 22)
        Me.chkProductPerfPeriodToPerio.Name = "chkProductPerfPeriodToPerio"
        Me.chkProductPerfPeriodToPerio.Size = New System.Drawing.Size(218, 17)
        Me.chkProductPerfPeriodToPerio.TabIndex = 60
        Me.chkProductPerfPeriodToPerio.TabStop = True
        Me.chkProductPerfPeriodToPerio.Text = "Product Performance Period to Period"
        Me.chkProductPerfPeriodToPerio.UseVisualStyleBackColor = True
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.BackColor = System.Drawing.Color.White
        Me.RadGroupBox1.Controls.Add(Me.txtConfigtypeName)
        Me.RadGroupBox1.Controls.Add(Me.cmdConfigtype)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel1)
        Me.RadGroupBox1.HeaderText = "ConfigType Code"
        Me.RadGroupBox1.Location = New System.Drawing.Point(7, 5)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        '
        '
        '
        Me.RadGroupBox1.RootElement.Padding = New System.Windows.Forms.Padding(2, 18, 2, 2)
        Me.RadGroupBox1.Size = New System.Drawing.Size(455, 62)
        Me.RadGroupBox1.TabIndex = 0
        Me.RadGroupBox1.Text = "ConfigType Code"
        Me.RadGroupBox1.ThemeName = "Office2010Silver"
        '
        'txtConfigtypeName
        '
        Me.txtConfigtypeName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfigtypeName.Location = New System.Drawing.Point(235, 27)
        Me.txtConfigtypeName.Name = "txtConfigtypeName"
        Me.txtConfigtypeName.Size = New System.Drawing.Size(207, 21)
        Me.txtConfigtypeName.TabIndex = 179
        Me.txtConfigtypeName.TabStop = False
        '
        'cmdConfigtype
        '
        Me.cmdConfigtype.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdConfigtype.Location = New System.Drawing.Point(122, 28)
        Me.cmdConfigtype.Name = "cmdConfigtype"
        Me.cmdConfigtype.Size = New System.Drawing.Size(107, 20)
        Me.cmdConfigtype.TabIndex = 177
        Me.cmdConfigtype.ThemeName = "Office2010Black"
        '
        'RadLabel1
        '
        Me.RadLabel1.Location = New System.Drawing.Point(20, 29)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(96, 18)
        Me.RadLabel1.TabIndex = 176
        Me.RadLabel1.Text = "Configtype Code :"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.ProgressBar1)
        Me.Panel3.Controls.Add(Me.LinkLabel1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 211)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(470, 38)
        Me.Panel3.TabIndex = 43
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.RadMenu1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(292, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(176, 36)
        Me.Panel4.TabIndex = 5
        '
        'RadMenu1
        '
        Me.RadMenu1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RadMenu1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnExcelReport, Me.btnClear})
        Me.RadMenu1.Location = New System.Drawing.Point(4, 0)
        Me.RadMenu1.Name = "RadMenu1"
        Me.RadMenu1.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        '
        '
        '
        Me.RadMenu1.RootElement.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        Me.RadMenu1.Size = New System.Drawing.Size(172, 58)
        Me.RadMenu1.TabIndex = 47
        Me.RadMenu1.ThemeName = "Office2010Silver"
        '
        'btnExcelReport
        '
        Me.btnExcelReport.AccessibleDescription = "Excel Report"
        Me.btnExcelReport.AccessibleName = "Excel Report"
        '
        '
        '
        Me.btnExcelReport.ButtonElement.AccessibleDescription = "Excel Report"
        Me.btnExcelReport.ButtonElement.AccessibleName = "Excel Report"
        Me.btnExcelReport.Image = Global.SPMSOPCI.My.Resources.Resources.if_logo_brand_brands_logos_excel_3215579
        Me.btnExcelReport.Name = "btnExcelReport"
        Me.btnExcelReport.Text = "Excel Report"
        Me.btnExcelReport.Visibility = Telerik.WinControls.ElementVisibility.Visible
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
        Me.btnClear.Image = Global.SPMSOPCI.My.Resources.Resources.if_ko_red_53948
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Text = "&Cancel"
        Me.btnClear.UseCompatibleTextRendering = False
        Me.btnClear.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'ProgressBar1
        '
        Me.ProgressBar1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 11)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(283, 16)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 4
        Me.ProgressBar1.Value = 2
        Me.ProgressBar1.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(902, 8)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(33, 13)
        Me.LinkLabel1.TabIndex = 1
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Close"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(470, 60)
        Me.Panel1.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(445, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "X"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(7, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(154, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Report Downloading"
        '
        'FrmDownloadReportUtilty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(470, 309)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDownloadReportUtilty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox2.ResumeLayout(False)
        Me.RadGroupBox2.PerformLayout()
        CType(Me.cmdToMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdFromMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.txtConfigtypeName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdConfigtype, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents btnExcelReport As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClear As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents cmdConfigtype As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadGroupBox2 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txtConfigtypeName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmdYear As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkProductPerfPeriodToPerio As System.Windows.Forms.RadioButton
    Friend WithEvents cmdToMonth As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdFromMonth As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Public WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Office2010SilverTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme
End Class
