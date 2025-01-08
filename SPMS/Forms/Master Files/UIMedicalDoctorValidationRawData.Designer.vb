<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIMedicalDoctorValidationRawData
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.GrdViewRawData = New Telerik.WinControls.UI.RadGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.txtUploadDateTime = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotalQty = New Telerik.WinControls.UI.RadTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotalAmount = New Telerik.WinControls.UI.RadTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNumberofRecord = New Telerik.WinControls.UI.RadTextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboyear = New System.Windows.Forms.ComboBox()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.txtChannelName = New Telerik.WinControls.UI.RadTextBox()
        Me.txtChannelCode = New Telerik.WinControls.UI.RadTextBox()
        Me.FindBestTimeCall = New System.Windows.Forms.LinkLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Office2019LightTheme1 = New Telerik.WinControls.Themes.Office2010BlueTheme
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.btnExportExcel = New System.Windows.Forms.ToolStripButton()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.btnFinalized = New System.Windows.Forms.ToolStripButton()
        Me.btnOpenFile = New System.Windows.Forms.ToolStripButton()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.GrdViewRawData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrdViewRawData.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.txtTotalQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumberofRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.txtChannelName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChannelCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 59)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1378, 611)
        Me.Panel2.TabIndex = 22
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.GrdViewRawData)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 127)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1376, 482)
        Me.Panel5.TabIndex = 1
        '
        'GrdViewRawData
        '
        Me.GrdViewRawData.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GrdViewRawData.Cursor = System.Windows.Forms.Cursors.Default
        Me.GrdViewRawData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdViewRawData.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.GrdViewRawData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GrdViewRawData.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GrdViewRawData.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.GrdViewRawData.MasterTemplate.AllowAddNewRow = False
        Me.GrdViewRawData.MasterTemplate.AllowDeleteRow = False
        Me.GrdViewRawData.MasterTemplate.AllowEditRow = False
        Me.GrdViewRawData.MasterTemplate.EnableFiltering = True
        Me.GrdViewRawData.MasterTemplate.EnableGrouping = False
        Me.GrdViewRawData.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.GrdViewRawData.Name = "GrdViewRawData"
        Me.GrdViewRawData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GrdViewRawData.Size = New System.Drawing.Size(1374, 480)
        Me.GrdViewRawData.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Panel7)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1376, 127)
        Me.Panel3.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.txtUploadDateTime)
        Me.Panel7.Controls.Add(Me.Label7)
        Me.Panel7.Controls.Add(Me.Label6)
        Me.Panel7.Controls.Add(Me.txtTotalQty)
        Me.Panel7.Controls.Add(Me.Label5)
        Me.Panel7.Controls.Add(Me.txtTotalAmount)
        Me.Panel7.Controls.Add(Me.Label4)
        Me.Panel7.Controls.Add(Me.txtNumberofRecord)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(556, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(325, 125)
        Me.Panel7.TabIndex = 1
        '
        'txtUploadDateTime
        '
        Me.txtUploadDateTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUploadDateTime.AutoSize = True
        Me.txtUploadDateTime.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUploadDateTime.Location = New System.Drawing.Point(175, 99)
        Me.txtUploadDateTime.Name = "txtUploadDateTime"
        Me.txtUploadDateTime.Size = New System.Drawing.Size(0, 15)
        Me.txtUploadDateTime.TabIndex = 288
        Me.txtUploadDateTime.Visible = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Courier New", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(16, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 15)
        Me.Label7.TabIndex = 287
        Me.Label7.Text = "Upload Date Time :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Courier New", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(65, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 15)
        Me.Label6.TabIndex = 285
        Me.Label6.Text = "Total Qty :"
        '
        'txtTotalQty
        '
        Me.txtTotalQty.AutoSize = False
        Me.txtTotalQty.BackColor = System.Drawing.Color.White
        Me.txtTotalQty.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQty.Location = New System.Drawing.Point(162, 35)
        Me.txtTotalQty.Multiline = True
        Me.txtTotalQty.Name = "txtTotalQty"
        Me.txtTotalQty.ReadOnly = True
        Me.txtTotalQty.Size = New System.Drawing.Size(160, 24)
        Me.txtTotalQty.TabIndex = 284
        Me.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalQty.ThemeName = "Office2019Light"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(44, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 15)
        Me.Label5.TabIndex = 283
        Me.Label5.Text = "Total Amount :"
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.AutoSize = False
        Me.txtTotalAmount.BackColor = System.Drawing.Color.White
        Me.txtTotalAmount.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmount.Location = New System.Drawing.Point(162, 62)
        Me.txtTotalAmount.Multiline = True
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(160, 24)
        Me.txtTotalAmount.TabIndex = 282
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalAmount.ThemeName = "Office2019Light"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Courier New", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(9, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 15)
        Me.Label4.TabIndex = 281
        Me.Label4.Text = "Number of Records :"
        '
        'txtNumberofRecord
        '
        Me.txtNumberofRecord.AutoSize = False
        Me.txtNumberofRecord.BackColor = System.Drawing.Color.White
        Me.txtNumberofRecord.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberofRecord.Location = New System.Drawing.Point(162, 8)
        Me.txtNumberofRecord.Multiline = True
        Me.txtNumberofRecord.Name = "txtNumberofRecord"
        Me.txtNumberofRecord.ReadOnly = True
        Me.txtNumberofRecord.Size = New System.Drawing.Size(160, 24)
        Me.txtNumberofRecord.TabIndex = 280
        Me.txtNumberofRecord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNumberofRecord.ThemeName = "Office2019Light"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Controls.Add(Me.ToolStrip1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(556, 125)
        Me.Panel4.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.cboMonth)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.cboyear)
        Me.Panel6.Controls.Add(Me.lblItemCode)
        Me.Panel6.Controls.Add(Me.txtChannelName)
        Me.Panel6.Controls.Add(Me.txtChannelCode)
        Me.Panel6.Controls.Add(Me.FindBestTimeCall)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 25)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(554, 98)
        Me.Panel6.TabIndex = 23
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(99, 63)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(110, 21)
        Me.cboMonth.TabIndex = 278
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Courier New", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(37, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 277
        Me.Label2.Text = "Month :"
        '
        'cboyear
        '
        Me.cboyear.FormattingEnabled = True
        Me.cboyear.Location = New System.Drawing.Point(99, 39)
        Me.cboyear.Name = "cboyear"
        Me.cboyear.Size = New System.Drawing.Size(110, 21)
        Me.cboyear.TabIndex = 276
        '
        'lblItemCode
        '
        Me.lblItemCode.AutoSize = True
        Me.lblItemCode.Font = New System.Drawing.Font("Courier New", 9.0!)
        Me.lblItemCode.Location = New System.Drawing.Point(44, 41)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Size = New System.Drawing.Size(49, 15)
        Me.lblItemCode.TabIndex = 275
        Me.lblItemCode.Text = "Year :"
        '
        'txtChannelName
        '
        Me.txtChannelName.AutoSize = False
        Me.txtChannelName.BackColor = System.Drawing.Color.White
        Me.txtChannelName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChannelName.Location = New System.Drawing.Point(211, 12)
        Me.txtChannelName.Multiline = True
        Me.txtChannelName.Name = "txtChannelName"
        Me.txtChannelName.ReadOnly = True
        Me.txtChannelName.Size = New System.Drawing.Size(338, 24)
        Me.txtChannelName.TabIndex = 274
        Me.txtChannelName.ThemeName = "Office2019Light"
        '
        'txtChannelCode
        '
        Me.txtChannelCode.AutoSize = False
        Me.txtChannelCode.BackColor = System.Drawing.Color.White
        Me.txtChannelCode.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChannelCode.Location = New System.Drawing.Point(99, 12)
        Me.txtChannelCode.Multiline = True
        Me.txtChannelCode.Name = "txtChannelCode"
        Me.txtChannelCode.ReadOnly = True
        Me.txtChannelCode.Size = New System.Drawing.Size(110, 24)
        Me.txtChannelCode.TabIndex = 273
        Me.txtChannelCode.ThemeName = "Office2019Light"
        '
        'FindBestTimeCall
        '
        Me.FindBestTimeCall.AutoSize = True
        Me.FindBestTimeCall.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FindBestTimeCall.Location = New System.Drawing.Point(16, 17)
        Me.FindBestTimeCall.Name = "FindBestTimeCall"
        Me.FindBestTimeCall.Size = New System.Drawing.Size(76, 14)
        Me.FindBestTimeCall.TabIndex = 272
        Me.FindBestTimeCall.TabStop = True
        Me.FindBestTimeCall.Text = "Channel MD :"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRefresh, Me.ToolStripSeparator4, Me.btnExportExcel, Me.ToolStripSeparator1, Me.btnClear, Me.ToolStripSeparator3, Me.btnFinalized, Me.btnOpenFile, Me.ToolStripSeparator2, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(554, 25)
        Me.ToolStrip1.TabIndex = 22
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = Global.SPMSOPCI.My.Resources.Resources.icons8_repeat_32
        Me.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(66, 22)
        Me.btnRefresh.Text = "&Refresh"
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Image = Global.SPMSOPCI.My.Resources.Resources.excel1
        Me.btnExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(88, 22)
        Me.btnExportExcel.Text = "Export Excel"
        '
        'btnClear
        '
        Me.btnClear.Image = Global.SPMSOPCI.My.Resources.Resources.close_copy
        Me.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(53, 22)
        Me.btnClear.Text = "Clear"
        '
        'btnFinalized
        '
        Me.btnFinalized.Image = Global.SPMSOPCI.My.Resources.Resources.icons8_project_setup_32
        Me.btnFinalized.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFinalized.Name = "btnFinalized"
        Me.btnFinalized.Size = New System.Drawing.Size(74, 22)
        Me.btnFinalized.Text = "&Read File"
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Image = Global.SPMSOPCI.My.Resources.Resources.find__1_
        Me.btnOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(106, 22)
        Me.btnOpenFile.Text = "Open file Batch"
        '
        'btnClose
        '
        Me.btnClose.Image = Global.SPMSOPCI.My.Resources.Resources.cancel
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(55, 22)
        Me.btnClose.Text = "Close"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1378, 59)
        Me.Panel1.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Validation RawData "
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'UIMedicalDoctorValidationRawData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UIMedicalDoctorValidationRawData"
        Me.Size = New System.Drawing.Size(1378, 670)
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.GrdViewRawData.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrdViewRawData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.txtTotalQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumberofRecord, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.txtChannelName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChannelCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboyear As System.Windows.Forms.ComboBox
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents txtChannelName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtChannelCode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents FindBestTimeCall As System.Windows.Forms.LinkLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnFinalized As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnOpenFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents GrdViewRawData As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents txtUploadDateTime As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotalQty As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotalAmount As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNumberofRecord As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Office2019LightTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme
    Friend WithEvents btnExportExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator

End Class
