<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UISalesMatrix
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
        Me.txtConfigurationName = New System.Windows.Forms.Label()
        Me.txtfileName = New System.Windows.Forms.TextBox()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.txtSheetName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtStartDate = New System.Windows.Forms.DateTimePicker()
        Me.cboCompanycode = New System.Windows.Forms.ComboBox()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.RadMenu1 = New Telerik.WinControls.UI.RadMenu()
        Me.btnFind = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClear = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 73)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(661, 261)
        Me.Panel2.TabIndex = 25
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.pbar)
        Me.Panel4.Controls.Add(Me.txtConfigurationName)
        Me.Panel4.Controls.Add(Me.txtfileName)
        Me.Panel4.Controls.Add(Me.RadButton1)
        Me.Panel4.Controls.Add(Me.txtSheetName)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.dtEndDate)
        Me.Panel4.Controls.Add(Me.dtStartDate)
        Me.Panel4.Controls.Add(Me.cboCompanycode)
        Me.Panel4.Controls.Add(Me.lblItemCode)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(659, 208)
        Me.Panel4.TabIndex = 1
        '
        'pbar
        '
        Me.pbar.ForeColor = System.Drawing.Color.RoyalBlue
        Me.pbar.Location = New System.Drawing.Point(189, 182)
        Me.pbar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pbar.Name = "pbar"
        Me.pbar.Size = New System.Drawing.Size(445, 12)
        Me.pbar.Step = 1
        Me.pbar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbar.TabIndex = 90
        Me.pbar.Value = 2
        '
        'txtConfigurationName
        '
        Me.txtConfigurationName.AutoSize = True
        Me.txtConfigurationName.Location = New System.Drawing.Point(344, 32)
        Me.txtConfigurationName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtConfigurationName.Name = "txtConfigurationName"
        Me.txtConfigurationName.Size = New System.Drawing.Size(0, 17)
        Me.txtConfigurationName.TabIndex = 89
        '
        'txtfileName
        '
        Me.txtfileName.BackColor = System.Drawing.Color.White
        Me.txtfileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtfileName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfileName.Location = New System.Drawing.Point(189, 148)
        Me.txtfileName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtfileName.Multiline = True
        Me.txtfileName.Name = "txtfileName"
        Me.txtfileName.ReadOnly = True
        Me.txtfileName.Size = New System.Drawing.Size(445, 29)
        Me.txtfileName.TabIndex = 88
        '
        'RadButton1
        '
        Me.RadButton1.Location = New System.Drawing.Point(100, 148)
        Me.RadButton1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(79, 28)
        Me.RadButton1.TabIndex = 87
        Me.RadButton1.Text = "Find ..."
        '
        'txtSheetName
        '
        Me.txtSheetName.BackColor = System.Drawing.Color.White
        Me.txtSheetName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSheetName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSheetName.Location = New System.Drawing.Point(189, 114)
        Me.txtSheetName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSheetName.Multiline = True
        Me.txtSheetName.Name = "txtSheetName"
        Me.txtSheetName.Size = New System.Drawing.Size(445, 29)
        Me.txtSheetName.TabIndex = 86
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(80, 119)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 20)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Sheet Name :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 89)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 20)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "Effectivity End Date :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 60)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 20)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "Effectivity Start Date :"
        '
        'dtEndDate
        '
        Me.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEndDate.Location = New System.Drawing.Point(189, 86)
        Me.dtEndDate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtEndDate.Name = "dtEndDate"
        Me.dtEndDate.Size = New System.Drawing.Size(145, 22)
        Me.dtEndDate.TabIndex = 82
        '
        'dtStartDate
        '
        Me.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStartDate.Location = New System.Drawing.Point(189, 58)
        Me.dtStartDate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtStartDate.Name = "dtStartDate"
        Me.dtStartDate.Size = New System.Drawing.Size(145, 22)
        Me.dtStartDate.TabIndex = 81
        '
        'cboCompanycode
        '
        Me.cboCompanycode.FormattingEnabled = True
        Me.cboCompanycode.Location = New System.Drawing.Point(189, 28)
        Me.cboCompanycode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboCompanycode.Name = "cboCompanycode"
        Me.cboCompanycode.Size = New System.Drawing.Size(145, 24)
        Me.cboCompanycode.TabIndex = 73
        '
        'lblItemCode
        '
        Me.lblItemCode.AutoSize = True
        Me.lblItemCode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemCode.Location = New System.Drawing.Point(31, 30)
        Me.lblItemCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Size = New System.Drawing.Size(142, 20)
        Me.lblItemCode.TabIndex = 58
        Me.lblItemCode.Text = "Configuration Type :"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.RadMenu1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 208)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(659, 51)
        Me.Panel3.TabIndex = 0
        '
        'RadMenu1
        '
        Me.RadMenu1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RadMenu1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnFind, Me.btnClear})
        Me.RadMenu1.Location = New System.Drawing.Point(0, 16)
        Me.RadMenu1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadMenu1.Name = "RadMenu1"
        Me.RadMenu1.Padding = New System.Windows.Forms.Padding(3, 2, 0, 0)
        '
        '
        '
        Me.RadMenu1.RootElement.Padding = New System.Windows.Forms.Padding(3, 2, 0, 0)
        Me.RadMenu1.Size = New System.Drawing.Size(657, 33)
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
        Me.btnFind.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFind.Image = Global.SPMSOPCI.My.Resources.Resources._10671434201602907700_24
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Text = "Upload"
        Me.btnFind.UseCompatibleTextRendering = False
        Me.btnFind.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnClear
        '
        Me.btnClear.AccessibleDescription = "&Closed"
        Me.btnClear.AccessibleName = "&Closed"
        '
        '
        '
        Me.btnClear.ButtonElement.AccessibleDescription = "&Closed"
        Me.btnClear.ButtonElement.AccessibleName = "&Closed"
        Me.btnClear.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Image = Global.SPMSOPCI.My.Resources.Resources.icons8_close_window_24
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Text = "&Closed"
        Me.btnClear.UseCompatibleTextRendering = False
        Me.btnClear.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(661, 73)
        Me.Panel1.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(28, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 32)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Sales Matrix"
        '
        'UISalesMatrix
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(661, 334)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "UISalesMatrix"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UISalesMatrix"
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnFind As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClear As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents cboCompanycode As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtfileName As System.Windows.Forms.TextBox
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtSheetName As System.Windows.Forms.TextBox
    Friend WithEvents txtConfigurationName As System.Windows.Forms.Label
    Protected WithEvents pbar As System.Windows.Forms.ProgressBar
End Class
