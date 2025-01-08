<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TorrentUtility
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.FillWithStrings = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.chkNationalReport = New System.Windows.Forms.RadioButton()
        Me.chkForAM = New System.Windows.Forms.RadioButton()
        Me.chkMedicalRep = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ChkNationalDivision = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.checkitemdistrict = New System.Windows.Forms.RadioButton()
        Me.chkConsolitededDistrict = New System.Windows.Forms.RadioButton()
        Me.cboYear3 = New System.Windows.Forms.ComboBox()
        Me.ChkconsolitededTerrity = New System.Windows.Forms.RadioButton()
        Me.optItem = New System.Windows.Forms.RadioButton()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboMonth3 = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboMonth2 = New System.Windows.Forms.ComboBox()
        Me.cboYear2 = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbConfigtypeCode = New System.Windows.Forms.ToolStripComboBox()
        Me.txtconfigtypeName = New System.Windows.Forms.ToolStripLabel()
        Me.cmbItemdiv1 = New System.Windows.Forms.ToolStripComboBox()
        Me.cmbItemdiv2 = New System.Windows.Forms.ToolStripComboBox()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(92, 425)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(205, 28)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Create Excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FillWithStrings
        '
        Me.FillWithStrings.AutoSize = True
        Me.FillWithStrings.Location = New System.Drawing.Point(215, 459)
        Me.FillWithStrings.Name = "FillWithStrings"
        Me.FillWithStrings.Size = New System.Drawing.Size(81, 17)
        Me.FillWithStrings.TabIndex = 1
        Me.FillWithStrings.Text = "CheckBox1"
        Me.FillWithStrings.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(338, 432)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 21)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.Controls.Add(Me.ProgressBar1)
        Me.Panel2.Controls.Add(Me.LinkLabel3)
        Me.Panel2.Controls.Add(Me.LinkLabel2)
        Me.Panel2.Controls.Add(Me.LinkLabel1)
        Me.Panel2.Location = New System.Drawing.Point(0, 292)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(515, 30)
        Me.Panel2.TabIndex = 42
        '
        'ProgressBar1
        '
        Me.ProgressBar1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ProgressBar1.Location = New System.Drawing.Point(7, 9)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(307, 13)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 4
        Me.ProgressBar1.Value = 2
        Me.ProgressBar1.Visible = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(324, 9)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(69, 13)
        Me.LinkLabel3.TabIndex = 3
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Print Report"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(399, 9)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(35, 13)
        Me.LinkLabel2.TabIndex = 2
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Close"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(902, 8)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(35, 13)
        Me.LinkLabel1.TabIndex = 1
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Close"
        '
        'chkNationalReport
        '
        Me.chkNationalReport.AutoSize = True
        Me.chkNationalReport.Checked = True
        Me.chkNationalReport.Location = New System.Drawing.Point(19, 13)
        Me.chkNationalReport.Name = "chkNationalReport"
        Me.chkNationalReport.Size = New System.Drawing.Size(69, 17)
        Me.chkNationalReport.TabIndex = 50
        Me.chkNationalReport.TabStop = True
        Me.chkNationalReport.Text = "National"
        Me.chkNationalReport.UseVisualStyleBackColor = True
        '
        'chkForAM
        '
        Me.chkForAM.AutoSize = True
        Me.chkForAM.Location = New System.Drawing.Point(19, 55)
        Me.chkForAM.Name = "chkForAM"
        Me.chkForAM.Size = New System.Drawing.Size(97, 17)
        Me.chkForAM.TabIndex = 51
        Me.chkForAM.TabStop = True
        Me.chkForAM.Text = "Area Manager"
        Me.chkForAM.UseVisualStyleBackColor = True
        '
        'chkMedicalRep
        '
        Me.chkMedicalRep.AutoSize = True
        Me.chkMedicalRep.Location = New System.Drawing.Point(19, 97)
        Me.chkMedicalRep.Name = "chkMedicalRep"
        Me.chkMedicalRep.Size = New System.Drawing.Size(88, 17)
        Me.chkMedicalRep.TabIndex = 52
        Me.chkMedicalRep.TabStop = True
        Me.chkMedicalRep.Text = "Medical Rep"
        Me.chkMedicalRep.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.Controls.Add(Me.ChkNationalDivision)
        Me.Panel3.Controls.Add(Me.RadioButton1)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.checkitemdistrict)
        Me.Panel3.Controls.Add(Me.chkConsolitededDistrict)
        Me.Panel3.Controls.Add(Me.cboYear3)
        Me.Panel3.Controls.Add(Me.ChkconsolitededTerrity)
        Me.Panel3.Controls.Add(Me.optItem)
        Me.Panel3.Controls.Add(Me.chkMedicalRep)
        Me.Panel3.Controls.Add(Me.chkNationalReport)
        Me.Panel3.Controls.Add(Me.chkForAM)
        Me.Panel3.Location = New System.Drawing.Point(0, 87)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(515, 136)
        Me.Panel3.TabIndex = 53
        '
        'ChkNationalDivision
        '
        Me.ChkNationalDivision.AutoSize = True
        Me.ChkNationalDivision.Checked = True
        Me.ChkNationalDivision.Enabled = False
        Me.ChkNationalDivision.Location = New System.Drawing.Point(341, 97)
        Me.ChkNationalDivision.Name = "ChkNationalDivision"
        Me.ChkNationalDivision.Size = New System.Drawing.Size(133, 17)
        Me.ChkNationalDivision.TabIndex = 59
        Me.ChkNationalDivision.TabStop = True
        Me.ChkNationalDivision.Text = "National per Division"
        Me.ChkNationalDivision.UseVisualStyleBackColor = True
        Me.ChkNationalDivision.Visible = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Enabled = False
        Me.RadioButton1.Location = New System.Drawing.Point(341, 55)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(166, 17)
        Me.RadioButton1.TabIndex = 54
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Customer Listing  - Territory" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(440, 123)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "Year :"
        Me.Label8.Visible = False
        '
        'checkitemdistrict
        '
        Me.checkitemdistrict.AutoSize = True
        Me.checkitemdistrict.Enabled = False
        Me.checkitemdistrict.Location = New System.Drawing.Point(136, 97)
        Me.checkitemdistrict.Name = "checkitemdistrict"
        Me.checkitemdistrict.Size = New System.Drawing.Size(105, 17)
        Me.checkitemdistrict.TabIndex = 58
        Me.checkitemdistrict.TabStop = True
        Me.checkitemdistrict.Text = "District Per Item"
        Me.checkitemdistrict.UseVisualStyleBackColor = True
        '
        'chkConsolitededDistrict
        '
        Me.chkConsolitededDistrict.AutoSize = True
        Me.chkConsolitededDistrict.Location = New System.Drawing.Point(136, 13)
        Me.chkConsolitededDistrict.Name = "chkConsolitededDistrict"
        Me.chkConsolitededDistrict.Size = New System.Drawing.Size(178, 17)
        Me.chkConsolitededDistrict.TabIndex = 56
        Me.chkConsolitededDistrict.TabStop = True
        Me.chkConsolitededDistrict.Text = "Consolidated Report - District"
        Me.chkConsolitededDistrict.UseVisualStyleBackColor = True
        '
        'cboYear3
        '
        Me.cboYear3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboYear3.FormattingEnabled = True
        Me.cboYear3.Location = New System.Drawing.Point(477, 115)
        Me.cboYear3.Name = "cboYear3"
        Me.cboYear3.Size = New System.Drawing.Size(30, 21)
        Me.cboYear3.TabIndex = 51
        Me.cboYear3.Visible = False
        '
        'ChkconsolitededTerrity
        '
        Me.ChkconsolitededTerrity.AutoSize = True
        Me.ChkconsolitededTerrity.Location = New System.Drawing.Point(136, 55)
        Me.ChkconsolitededTerrity.Name = "ChkconsolitededTerrity"
        Me.ChkconsolitededTerrity.Size = New System.Drawing.Size(184, 17)
        Me.ChkconsolitededTerrity.TabIndex = 55
        Me.ChkconsolitededTerrity.TabStop = True
        Me.ChkconsolitededTerrity.Text = "Consolidated Report - Territory" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.ChkconsolitededTerrity.UseVisualStyleBackColor = True
        '
        'optItem
        '
        Me.optItem.AutoSize = True
        Me.optItem.Enabled = False
        Me.optItem.Location = New System.Drawing.Point(341, 13)
        Me.optItem.Name = "optItem"
        Me.optItem.Size = New System.Drawing.Size(52, 17)
        Me.optItem.TabIndex = 53
        Me.optItem.TabStop = True
        Me.optItem.Text = "Items"
        Me.optItem.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.Control
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.cboMonth3)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.cboMonth2)
        Me.Panel5.Controls.Add(Me.cboYear2)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Location = New System.Drawing.Point(0, 224)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(515, 66)
        Me.Panel5.TabIndex = 55
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(263, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(19, 13)
        Me.Label11.TabIndex = 55
        Me.Label11.Text = "To"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(245, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "From "
        '
        'cboMonth3
        '
        Me.cboMonth3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboMonth3.FormattingEnabled = True
        Me.cboMonth3.Location = New System.Drawing.Point(347, 35)
        Me.cboMonth3.Name = "cboMonth3"
        Me.cboMonth3.Size = New System.Drawing.Size(101, 21)
        Me.cboMonth3.TabIndex = 50
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(286, 36)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "Month :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(44, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Year :"
        '
        'cboMonth2
        '
        Me.cboMonth2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboMonth2.FormattingEnabled = True
        Me.cboMonth2.Location = New System.Drawing.Point(347, 9)
        Me.cboMonth2.Name = "cboMonth2"
        Me.cboMonth2.Size = New System.Drawing.Size(101, 21)
        Me.cboMonth2.TabIndex = 46
        '
        'cboYear2
        '
        Me.cboYear2.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboYear2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboYear2.FormattingEnabled = True
        Me.cboYear2.Location = New System.Drawing.Point(90, 22)
        Me.cboYear2.Name = "cboYear2"
        Me.cboYear2.Size = New System.Drawing.Size(100, 21)
        Me.cboYear2.TabIndex = 47
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(287, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Month :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(515, 60)
        Me.Panel1.TabIndex = 17
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
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cmbConfigtypeCode, Me.txtconfigtypeName})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 60)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(515, 25)
        Me.ToolStrip1.TabIndex = 56
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(73, 22)
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
        'cmbItemdiv1
        '
        Me.cmbItemdiv1.Name = "cmbItemdiv1"
        Me.cmbItemdiv1.Size = New System.Drawing.Size(121, 23)
        '
        'cmbItemdiv2
        '
        Me.cmbItemdiv2.Name = "cmbItemdiv2"
        Me.cmbItemdiv2.Size = New System.Drawing.Size(121, 23)
        '
        'TorrentUtility
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(515, 323)
        Me.ControlBox = False
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.FillWithStrings)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "TorrentUtility"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Downloading"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents FillWithStrings As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents chkNationalReport As System.Windows.Forms.RadioButton
    Friend WithEvents chkForAM As System.Windows.Forms.RadioButton
    Friend WithEvents chkMedicalRep As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents optItem As System.Windows.Forms.RadioButton
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboMonth3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboYear3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboMonth2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboYear2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Public WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    'Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents chkConsolitededDistrict As System.Windows.Forms.RadioButton
    Friend WithEvents ChkconsolitededTerrity As System.Windows.Forms.RadioButton
    'Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents checkitemdistrict As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbConfigtypeCode As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents txtconfigtypeName As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbItemdiv1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents cmbItemdiv2 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ChkNationalDivision As System.Windows.Forms.RadioButton
End Class
