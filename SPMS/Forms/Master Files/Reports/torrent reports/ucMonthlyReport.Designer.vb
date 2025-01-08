<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMonthlyReport
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
        Me.components = New System.ComponentModel.Container
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.btnClose = New System.Windows.Forms.ToolStripButton
        Me.btnAdd = New System.Windows.Forms.ToolStripButton
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Panel_MR = New System.Windows.Forms.Panel
        Me.ComboBox_MRChannel = New System.Windows.Forms.ComboBox
        Me.Label_MRChannel = New System.Windows.Forms.Label
        Me.ComboBox_MR = New System.Windows.Forms.ComboBox
        Me.Label_MRSelect = New System.Windows.Forms.Label
        Me.ComboBox_MRSelect = New System.Windows.Forms.ComboBox
        Me.Panel_National = New System.Windows.Forms.Panel
        Me.ComboBox_National = New System.Windows.Forms.ComboBox
        Me.Label_ItemDiv = New System.Windows.Forms.Label
        Me.ComboBox_ItemDiv = New System.Windows.Forms.ComboBox
        Me.Panel_AM = New System.Windows.Forms.Panel
        Me.ComboBox_AMChannel = New System.Windows.Forms.ComboBox
        Me.Label_AMChannel = New System.Windows.Forms.Label
        Me.ComboBox_AMSelect = New System.Windows.Forms.ComboBox
        Me.ComboBox_AM = New System.Windows.Forms.ComboBox
        Me.Label_AMSelect = New System.Windows.Forms.Label
        Me.Button_OK = New System.Windows.Forms.Button
        Me.ComboBox_Year = New System.Windows.Forms.ComboBox
        Me.ComboBox_Month = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.RadioButton_MR = New System.Windows.Forms.RadioButton
        Me.RadioButton_AM = New System.Windows.Forms.RadioButton
        Me.RadioButton_National = New System.Windows.Forms.RadioButton
        Me.btnExport = New System.Windows.Forms.ToolStripButton
        Me.SPMSDataSet = New SPMS.SPMSDataSet
        Me.SPMSDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel_MR.SuspendLayout()
        Me.Panel_National.SuspendLayout()
        Me.Panel_AM.SuspendLayout()
        CType(Me.SPMSDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SPMSDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Image = Global.SPMS.My.Resources.Resources.WSS_DocLib1
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(50, 22)
        Me.btnSave.Text = "Save"
        '
        'btnClose
        '
        Me.btnClose.Image = Global.SPMS.My.Resources.Resources.cancel
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(55, 22)
        Me.btnClose.Text = "Close"
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.SPMS.My.Resources.Resources.add1
        Me.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(48, 22)
        Me.btnAdd.Text = "Add"
        '
        'btnDelete
        '
        Me.btnDelete.Image = Global.SPMS.My.Resources.Resources.delete1
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 22)
        Me.btnDelete.Text = "Delete"
        '
        'btnEdit
        '
        Me.btnEdit.Image = Global.SPMS.My.Resources.Resources.page_edit1
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(47, 22)
        Me.btnEdit.Text = "Edit"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 21)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Monthly Sales Reports"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMS.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1037, 58)
        Me.Panel1.TabIndex = 14
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnExport, Me.ToolStripSeparator2, Me.ToolStripButton5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1037, 25)
        Me.ToolStrip1.TabIndex = 15
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = Global.SPMS.My.Resources.Resources.cancel
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(55, 22)
        Me.ToolStripButton5.Text = "Close"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.GridColor = System.Drawing.Color.Silver
        Me.DataGridView1.Location = New System.Drawing.Point(342, 95)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 50
        Me.DataGridView1.ShowEditingIcon = False
        Me.DataGridView1.Size = New System.Drawing.Size(657, 524)
        Me.DataGridView1.TabIndex = 18
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel_MR)
        Me.GroupBox1.Controls.Add(Me.Panel_National)
        Me.GroupBox1.Controls.Add(Me.Panel_AM)
        Me.GroupBox1.Controls.Add(Me.Button_OK)
        Me.GroupBox1.Controls.Add(Me.ComboBox_Year)
        Me.GroupBox1.Controls.Add(Me.ComboBox_Month)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.RadioButton_MR)
        Me.GroupBox1.Controls.Add(Me.RadioButton_AM)
        Me.GroupBox1.Controls.Add(Me.RadioButton_National)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 95)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(333, 526)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Monthly Sales Reports"
        '
        'Panel_MR
        '
        Me.Panel_MR.Controls.Add(Me.ComboBox_MRChannel)
        Me.Panel_MR.Controls.Add(Me.Label_MRChannel)
        Me.Panel_MR.Controls.Add(Me.ComboBox_MR)
        Me.Panel_MR.Controls.Add(Me.Label_MRSelect)
        Me.Panel_MR.Controls.Add(Me.ComboBox_MRSelect)
        Me.Panel_MR.Enabled = False
        Me.Panel_MR.Location = New System.Drawing.Point(10, 268)
        Me.Panel_MR.Name = "Panel_MR"
        Me.Panel_MR.Size = New System.Drawing.Size(314, 88)
        Me.Panel_MR.TabIndex = 24
        '
        'ComboBox_MRChannel
        '
        Me.ComboBox_MRChannel.Enabled = False
        Me.ComboBox_MRChannel.FormattingEnabled = True
        Me.ComboBox_MRChannel.Location = New System.Drawing.Point(82, 57)
        Me.ComboBox_MRChannel.Name = "ComboBox_MRChannel"
        Me.ComboBox_MRChannel.Size = New System.Drawing.Size(213, 21)
        Me.ComboBox_MRChannel.TabIndex = 24
        '
        'Label_MRChannel
        '
        Me.Label_MRChannel.AutoSize = True
        Me.Label_MRChannel.Enabled = False
        Me.Label_MRChannel.Location = New System.Drawing.Point(16, 60)
        Me.Label_MRChannel.Name = "Label_MRChannel"
        Me.Label_MRChannel.Size = New System.Drawing.Size(53, 13)
        Me.Label_MRChannel.TabIndex = 23
        Me.Label_MRChannel.Text = "Channel:"
        '
        'ComboBox_MR
        '
        Me.ComboBox_MR.FormattingEnabled = True
        Me.ComboBox_MR.Items.AddRange(New Object() {"1 - Product Wise Sales Report (Target Vs. Achievement)", "2 - Channel Wise Sales Report", "3 - Doctor Wise Sales Report (By Channel)"})
        Me.ComboBox_MR.Location = New System.Drawing.Point(19, 3)
        Me.ComboBox_MR.Name = "ComboBox_MR"
        Me.ComboBox_MR.Size = New System.Drawing.Size(276, 21)
        Me.ComboBox_MR.TabIndex = 11
        '
        'Label_MRSelect
        '
        Me.Label_MRSelect.AutoSize = True
        Me.Label_MRSelect.Location = New System.Drawing.Point(16, 33)
        Me.Label_MRSelect.Name = "Label_MRSelect"
        Me.Label_MRSelect.Size = New System.Drawing.Size(60, 13)
        Me.Label_MRSelect.TabIndex = 21
        Me.Label_MRSelect.Text = "Select MR:"
        '
        'ComboBox_MRSelect
        '
        Me.ComboBox_MRSelect.FormattingEnabled = True
        Me.ComboBox_MRSelect.Location = New System.Drawing.Point(82, 30)
        Me.ComboBox_MRSelect.Name = "ComboBox_MRSelect"
        Me.ComboBox_MRSelect.Size = New System.Drawing.Size(213, 21)
        Me.ComboBox_MRSelect.TabIndex = 22
        '
        'Panel_National
        '
        Me.Panel_National.Controls.Add(Me.ComboBox_National)
        Me.Panel_National.Controls.Add(Me.Label_ItemDiv)
        Me.Panel_National.Controls.Add(Me.ComboBox_ItemDiv)
        Me.Panel_National.Enabled = False
        Me.Panel_National.Location = New System.Drawing.Point(10, 44)
        Me.Panel_National.Name = "Panel_National"
        Me.Panel_National.Size = New System.Drawing.Size(314, 58)
        Me.Panel_National.TabIndex = 24
        '
        'ComboBox_National
        '
        Me.ComboBox_National.FormattingEnabled = True
        Me.ComboBox_National.Items.AddRange(New Object() {"Product Wise Sales Report (Target Vs. Achievement)", "Medical Representative Wise Sales Report (Target Vs. Achievement)", "Product Wise Sales Report (By Item Division)"})
        Me.ComboBox_National.Location = New System.Drawing.Point(19, 3)
        Me.ComboBox_National.Name = "ComboBox_National"
        Me.ComboBox_National.Size = New System.Drawing.Size(276, 21)
        Me.ComboBox_National.TabIndex = 7
        '
        'Label_ItemDiv
        '
        Me.Label_ItemDiv.AutoSize = True
        Me.Label_ItemDiv.Enabled = False
        Me.Label_ItemDiv.Location = New System.Drawing.Point(16, 33)
        Me.Label_ItemDiv.Name = "Label_ItemDiv"
        Me.Label_ItemDiv.Size = New System.Drawing.Size(76, 13)
        Me.Label_ItemDiv.TabIndex = 17
        Me.Label_ItemDiv.Text = "Item Division:"
        '
        'ComboBox_ItemDiv
        '
        Me.ComboBox_ItemDiv.Enabled = False
        Me.ComboBox_ItemDiv.FormattingEnabled = True
        Me.ComboBox_ItemDiv.Location = New System.Drawing.Point(98, 30)
        Me.ComboBox_ItemDiv.Name = "ComboBox_ItemDiv"
        Me.ComboBox_ItemDiv.Size = New System.Drawing.Size(197, 21)
        Me.ComboBox_ItemDiv.TabIndex = 18
        '
        'Panel_AM
        '
        Me.Panel_AM.Controls.Add(Me.ComboBox_AMChannel)
        Me.Panel_AM.Controls.Add(Me.Label_AMChannel)
        Me.Panel_AM.Controls.Add(Me.ComboBox_AMSelect)
        Me.Panel_AM.Controls.Add(Me.ComboBox_AM)
        Me.Panel_AM.Controls.Add(Me.Label_AMSelect)
        Me.Panel_AM.Enabled = False
        Me.Panel_AM.Location = New System.Drawing.Point(10, 142)
        Me.Panel_AM.Name = "Panel_AM"
        Me.Panel_AM.Size = New System.Drawing.Size(314, 87)
        Me.Panel_AM.TabIndex = 23
        '
        'ComboBox_AMChannel
        '
        Me.ComboBox_AMChannel.Enabled = False
        Me.ComboBox_AMChannel.FormattingEnabled = True
        Me.ComboBox_AMChannel.Location = New System.Drawing.Point(82, 57)
        Me.ComboBox_AMChannel.Name = "ComboBox_AMChannel"
        Me.ComboBox_AMChannel.Size = New System.Drawing.Size(213, 21)
        Me.ComboBox_AMChannel.TabIndex = 22
        '
        'Label_AMChannel
        '
        Me.Label_AMChannel.AutoSize = True
        Me.Label_AMChannel.Enabled = False
        Me.Label_AMChannel.Location = New System.Drawing.Point(16, 60)
        Me.Label_AMChannel.Name = "Label_AMChannel"
        Me.Label_AMChannel.Size = New System.Drawing.Size(53, 13)
        Me.Label_AMChannel.TabIndex = 21
        Me.Label_AMChannel.Text = "Channel:"
        '
        'ComboBox_AMSelect
        '
        Me.ComboBox_AMSelect.FormattingEnabled = True
        Me.ComboBox_AMSelect.Location = New System.Drawing.Point(82, 30)
        Me.ComboBox_AMSelect.Name = "ComboBox_AMSelect"
        Me.ComboBox_AMSelect.Size = New System.Drawing.Size(213, 21)
        Me.ComboBox_AMSelect.TabIndex = 20
        '
        'ComboBox_AM
        '
        Me.ComboBox_AM.FormattingEnabled = True
        Me.ComboBox_AM.Items.AddRange(New Object() {"1 - Product Wise Sales Report (Target Vs. Achievement)", "2 - Medical Representative Wise Sales Report (Target Vs. Achievement)", "3 - Channel Wise Sales Report", "4 - Doctor Wise Sales Report (By Channel)"})
        Me.ComboBox_AM.Location = New System.Drawing.Point(19, 3)
        Me.ComboBox_AM.Name = "ComboBox_AM"
        Me.ComboBox_AM.Size = New System.Drawing.Size(276, 21)
        Me.ComboBox_AM.TabIndex = 9
        '
        'Label_AMSelect
        '
        Me.Label_AMSelect.AutoSize = True
        Me.Label_AMSelect.Location = New System.Drawing.Point(16, 33)
        Me.Label_AMSelect.Name = "Label_AMSelect"
        Me.Label_AMSelect.Size = New System.Drawing.Size(60, 13)
        Me.Label_AMSelect.TabIndex = 19
        Me.Label_AMSelect.Text = "Select AM:"
        '
        'Button_OK
        '
        Me.Button_OK.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_OK.Location = New System.Drawing.Point(241, 388)
        Me.Button_OK.Name = "Button_OK"
        Me.Button_OK.Size = New System.Drawing.Size(64, 48)
        Me.Button_OK.TabIndex = 16
        Me.Button_OK.Text = "OK"
        Me.Button_OK.UseVisualStyleBackColor = True
        '
        'ComboBox_Year
        '
        Me.ComboBox_Year.FormattingEnabled = True
        Me.ComboBox_Year.Location = New System.Drawing.Point(92, 415)
        Me.ComboBox_Year.Name = "ComboBox_Year"
        Me.ComboBox_Year.Size = New System.Drawing.Size(143, 21)
        Me.ComboBox_Year.TabIndex = 15
        '
        'ComboBox_Month
        '
        Me.ComboBox_Month.FormattingEnabled = True
        Me.ComboBox_Month.Items.AddRange(New Object() {"1 - January", "2 - February", "3 - March", "4 - April", "5 - May", "6 - June", "7 - July", "8 - August", "9 - September", "10 - October", "11 - November", "12 - December"})
        Me.ComboBox_Month.Location = New System.Drawing.Point(92, 388)
        Me.ComboBox_Month.Name = "ComboBox_Month"
        Me.ComboBox_Month.Size = New System.Drawing.Size(143, 21)
        Me.ComboBox_Month.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 418)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Select Year:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 391)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Select Month:"
        '
        'RadioButton_MR
        '
        Me.RadioButton_MR.AutoSize = True
        Me.RadioButton_MR.Location = New System.Drawing.Point(10, 245)
        Me.RadioButton_MR.Name = "RadioButton_MR"
        Me.RadioButton_MR.Size = New System.Drawing.Size(187, 17)
        Me.RadioButton_MR.TabIndex = 10
        Me.RadioButton_MR.TabStop = True
        Me.RadioButton_MR.Text = "Medical Representative Reports"
        Me.RadioButton_MR.UseVisualStyleBackColor = True
        '
        'RadioButton_AM
        '
        Me.RadioButton_AM.AutoSize = True
        Me.RadioButton_AM.Location = New System.Drawing.Point(11, 119)
        Me.RadioButton_AM.Name = "RadioButton_AM"
        Me.RadioButton_AM.Size = New System.Drawing.Size(140, 17)
        Me.RadioButton_AM.TabIndex = 8
        Me.RadioButton_AM.TabStop = True
        Me.RadioButton_AM.Text = "Area Manager Reports"
        Me.RadioButton_AM.UseVisualStyleBackColor = True
        '
        'RadioButton_National
        '
        Me.RadioButton_National.AutoSize = True
        Me.RadioButton_National.Location = New System.Drawing.Point(10, 21)
        Me.RadioButton_National.Name = "RadioButton_National"
        Me.RadioButton_National.Size = New System.Drawing.Size(184, 17)
        Me.RadioButton_National.TabIndex = 6
        Me.RadioButton_National.TabStop = True
        Me.RadioButton_National.Text = "National Consolidated Reports"
        Me.RadioButton_National.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Image = Global.SPMS.My.Resources.Resources.Printer
        Me.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(102, 22)
        Me.btnExport.Text = "Export to Excel"
        '
        'SPMSDataSet
        '
        Me.SPMSDataSet.DataSetName = "SPMSDataSet"
        Me.SPMSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SPMSDataSetBindingSource
        '
        Me.SPMSDataSetBindingSource.DataSource = Me.SPMSDataSet
        Me.SPMSDataSetBindingSource.Position = 0
        '
        'ucMonthlyReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucMonthlyReport"
        Me.Size = New System.Drawing.Size(1037, 749)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel_MR.ResumeLayout(False)
        Me.Panel_MR.PerformLayout()
        Me.Panel_National.ResumeLayout(False)
        Me.Panel_National.PerformLayout()
        Me.Panel_AM.ResumeLayout(False)
        Me.Panel_AM.PerformLayout()
        CType(Me.SPMSDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SPMSDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents SPMSDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SPMSDataSet As SPMS.SPMSDataSet
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox_ItemDiv As System.Windows.Forms.ComboBox
    Friend WithEvents Label_ItemDiv As System.Windows.Forms.Label
    Friend WithEvents Button_OK As System.Windows.Forms.Button
    Friend WithEvents ComboBox_Year As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox_MR As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButton_MR As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBox_AM As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButton_AM As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBox_National As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButton_National As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBox_MRSelect As System.Windows.Forms.ComboBox
    Friend WithEvents Label_MRSelect As System.Windows.Forms.Label
    Friend WithEvents ComboBox_AMSelect As System.Windows.Forms.ComboBox
    Friend WithEvents Label_AMSelect As System.Windows.Forms.Label
    Friend WithEvents Panel_AM As System.Windows.Forms.Panel
    Friend WithEvents Panel_National As System.Windows.Forms.Panel
    Friend WithEvents Panel_MR As System.Windows.Forms.Panel
    Friend WithEvents ComboBox_AMChannel As System.Windows.Forms.ComboBox
    Friend WithEvents Label_AMChannel As System.Windows.Forms.Label
    Friend WithEvents ComboBox_MRChannel As System.Windows.Forms.ComboBox
    Friend WithEvents Label_MRChannel As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Month As System.Windows.Forms.ComboBox
    Friend WithEvents btnExport As System.Windows.Forms.ToolStripButton

End Class
