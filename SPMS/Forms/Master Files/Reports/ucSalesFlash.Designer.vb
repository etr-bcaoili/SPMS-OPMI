<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSalesFlash
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LL_UPS5 = New System.Windows.Forms.LinkLabel
        Me.LL_UPS4 = New System.Windows.Forms.LinkLabel
        Me.LL_UPS3 = New System.Windows.Forms.LinkLabel
        Me.LL_UPS2 = New System.Windows.Forms.LinkLabel
        Me.LL_UPS1 = New System.Windows.Forms.LinkLabel
        Me.LL_PS8 = New System.Windows.Forms.LinkLabel
        Me.LL_PS7 = New System.Windows.Forms.LinkLabel
        Me.LL_PS6 = New System.Windows.Forms.LinkLabel
        Me.LL_PS4 = New System.Windows.Forms.LinkLabel
        Me.LL_PS5 = New System.Windows.Forms.LinkLabel
        Me.LL_PS3 = New System.Windows.Forms.LinkLabel
        Me.LL_PS2 = New System.Windows.Forms.LinkLabel
        Me.LL_PS1 = New System.Windows.Forms.LinkLabel
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.SPMSDataSet = New SPMSOPCI.SPMSDataSet
        Me.SPMSDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SPMSDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SPMSDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Image = Global.SPMSOPCI.My.Resources.Resources.WSS_DocLib1
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(50, 22)
        Me.btnSave.Text = "Save"
        '
        'btnClose
        '
        Me.btnClose.Image = Global.SPMSOPCI.My.Resources.Resources.cancel
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(55, 22)
        Me.btnClose.Text = "Close"
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.SPMSOPCI.My.Resources.Resources.add1
        Me.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(48, 22)
        Me.btnAdd.Text = "Add"
        '
        'btnDelete
        '
        Me.btnDelete.Image = Global.SPMSOPCI.My.Resources.Resources.delete1
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 22)
        Me.btnDelete.Text = "Delete"
        '
        'btnEdit
        '
        Me.btnEdit.Image = Global.SPMSOPCI.My.Resources.Resources.page_edit1
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
        Me.Label4.Size = New System.Drawing.Size(144, 21)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Sales Flash Reports"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton5})
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
        Me.ToolStripButton5.Image = Global.SPMSOPCI.My.Resources.Resources.cancel
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(55, 22)
        Me.ToolStripButton5.Text = "Close"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.LL_UPS5)
        Me.GroupBox1.Controls.Add(Me.LL_UPS4)
        Me.GroupBox1.Controls.Add(Me.LL_UPS3)
        Me.GroupBox1.Controls.Add(Me.LL_UPS2)
        Me.GroupBox1.Controls.Add(Me.LL_UPS1)
        Me.GroupBox1.Controls.Add(Me.LL_PS8)
        Me.GroupBox1.Controls.Add(Me.LL_PS7)
        Me.GroupBox1.Controls.Add(Me.LL_PS6)
        Me.GroupBox1.Controls.Add(Me.LL_PS4)
        Me.GroupBox1.Controls.Add(Me.LL_PS5)
        Me.GroupBox1.Controls.Add(Me.LL_PS3)
        Me.GroupBox1.Controls.Add(Me.LL_PS2)
        Me.GroupBox1.Controls.Add(Me.LL_PS1)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 95)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(307, 526)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sales Flash Reports"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 292)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Under-Processing Sales"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Processed Sales"
        '
        'LL_UPS5
        '
        Me.LL_UPS5.AutoSize = True
        Me.LL_UPS5.Location = New System.Drawing.Point(29, 424)
        Me.LL_UPS5.Name = "LL_UPS5"
        Me.LL_UPS5.Size = New System.Drawing.Size(238, 13)
        Me.LL_UPS5.TabIndex = 12
        Me.LL_UPS5.TabStop = True
        Me.LL_UPS5.Text = "5.    Division and Product Wise Mapped Sales"
        '
        'LL_UPS4
        '
        Me.LL_UPS4.AutoSize = True
        Me.LL_UPS4.Location = New System.Drawing.Point(29, 398)
        Me.LL_UPS4.Name = "LL_UPS4"
        Me.LL_UPS4.Size = New System.Drawing.Size(253, 13)
        Me.LL_UPS4.TabIndex = 11
        Me.LL_UPS4.TabStop = True
        Me.LL_UPS4.Text = "4.    Division and Product Wise UnMapped Sales"
        '
        'LL_UPS3
        '
        Me.LL_UPS3.AutoSize = True
        Me.LL_UPS3.Location = New System.Drawing.Point(29, 370)
        Me.LL_UPS3.Name = "LL_UPS3"
        Me.LL_UPS3.Size = New System.Drawing.Size(240, 13)
        Me.LL_UPS3.TabIndex = 10
        Me.LL_UPS3.TabStop = True
        Me.LL_UPS3.Text = "3.    Division and Territory Wise Mapped Sales"
        '
        'LL_UPS2
        '
        Me.LL_UPS2.AutoSize = True
        Me.LL_UPS2.Location = New System.Drawing.Point(29, 342)
        Me.LL_UPS2.Name = "LL_UPS2"
        Me.LL_UPS2.Size = New System.Drawing.Size(241, 13)
        Me.LL_UPS2.TabIndex = 9
        Me.LL_UPS2.TabStop = True
        Me.LL_UPS2.Text = "2.    Division and Channel Wise Mapped Sales"
        '
        'LL_UPS1
        '
        Me.LL_UPS1.AutoSize = True
        Me.LL_UPS1.Location = New System.Drawing.Point(29, 316)
        Me.LL_UPS1.Name = "LL_UPS1"
        Me.LL_UPS1.Size = New System.Drawing.Size(255, 13)
        Me.LL_UPS1.TabIndex = 8
        Me.LL_UPS1.TabStop = True
        Me.LL_UPS1.Text = "1.    Division and Channel Wise Unmapped Sales"
        '
        'LL_PS8
        '
        Me.LL_PS8.AutoSize = True
        Me.LL_PS8.Location = New System.Drawing.Point(29, 248)
        Me.LL_PS8.Name = "LL_PS8"
        Me.LL_PS8.Size = New System.Drawing.Size(212, 13)
        Me.LL_PS8.TabIndex = 7
        Me.LL_PS8.TabStop = True
        Me.LL_PS8.Text = "8.    Division Wise Default Territory Sales"
        '
        'LL_PS7
        '
        Me.LL_PS7.AutoSize = True
        Me.LL_PS7.Location = New System.Drawing.Point(29, 224)
        Me.LL_PS7.Name = "LL_PS7"
        Me.LL_PS7.Size = New System.Drawing.Size(230, 13)
        Me.LL_PS7.TabIndex = 6
        Me.LL_PS7.TabStop = True
        Me.LL_PS7.Text = "7.    Division and Customer Class Wise Sales"
        '
        'LL_PS6
        '
        Me.LL_PS6.AutoSize = True
        Me.LL_PS6.Location = New System.Drawing.Point(29, 199)
        Me.LL_PS6.Name = "LL_PS6"
        Me.LL_PS6.Size = New System.Drawing.Size(237, 13)
        Me.LL_PS6.TabIndex = 5
        Me.LL_PS6.TabStop = True
        Me.LL_PS6.Text = "6.    Division and Customer Group Wise Sales"
        '
        'LL_PS4
        '
        Me.LL_PS4.AutoSize = True
        Me.LL_PS4.Location = New System.Drawing.Point(29, 150)
        Me.LL_PS4.Name = "LL_PS4"
        Me.LL_PS4.Size = New System.Drawing.Size(189, 13)
        Me.LL_PS4.TabIndex = 4
        Me.LL_PS4.TabStop = True
        Me.LL_PS4.Text = "4.    Division and Region Wise Sales"
        '
        'LL_PS5
        '
        Me.LL_PS5.AutoSize = True
        Me.LL_PS5.Location = New System.Drawing.Point(29, 173)
        Me.LL_PS5.Name = "LL_PS5"
        Me.LL_PS5.Size = New System.Drawing.Size(195, 13)
        Me.LL_PS5.TabIndex = 3
        Me.LL_PS5.TabStop = True
        Me.LL_PS5.Text = "5.    Division and Channel Wise Sales"
        '
        'LL_PS3
        '
        Me.LL_PS3.AutoSize = True
        Me.LL_PS3.Location = New System.Drawing.Point(29, 113)
        Me.LL_PS3.Name = "LL_PS3"
        Me.LL_PS3.Size = New System.Drawing.Size(227, 13)
        Me.LL_PS3.TabIndex = 2
        Me.LL_PS3.TabStop = True
        Me.LL_PS3.Text = "3.    Division and District Wise Achievement"
        '
        'LL_PS2
        '
        Me.LL_PS2.AutoSize = True
        Me.LL_PS2.Location = New System.Drawing.Point(29, 88)
        Me.LL_PS2.Name = "LL_PS2"
        Me.LL_PS2.Size = New System.Drawing.Size(233, 13)
        Me.LL_PS2.TabIndex = 1
        Me.LL_PS2.TabStop = True
        Me.LL_PS2.Text = "2.    Division and Territory Wise Achievement"
        '
        'LL_PS1
        '
        Me.LL_PS1.AutoSize = True
        Me.LL_PS1.Location = New System.Drawing.Point(29, 63)
        Me.LL_PS1.Name = "LL_PS1"
        Me.LL_PS1.Size = New System.Drawing.Size(231, 13)
        Me.LL_PS1.TabIndex = 0
        Me.LL_PS1.TabStop = True
        Me.LL_PS1.Text = "1.    Division and Product Wise Achievement"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.GridColor = System.Drawing.Color.Silver
        Me.DataGridView1.Location = New System.Drawing.Point(316, 95)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 50
        Me.DataGridView1.ShowEditingIcon = False
        Me.DataGridView1.Size = New System.Drawing.Size(662, 524)
        Me.DataGridView1.TabIndex = 18
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
        'ucSalesFlash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucSalesFlash"
        Me.Size = New System.Drawing.Size(1037, 749)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SPMSDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SPMSDataSet As SPMSOPCI.SPMSDataSet
    Friend WithEvents LL_PS3 As System.Windows.Forms.LinkLabel
    Friend WithEvents LL_PS2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LL_PS1 As System.Windows.Forms.LinkLabel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents LL_PS8 As System.Windows.Forms.LinkLabel
    Friend WithEvents LL_PS7 As System.Windows.Forms.LinkLabel
    Friend WithEvents LL_PS6 As System.Windows.Forms.LinkLabel
    Friend WithEvents LL_PS4 As System.Windows.Forms.LinkLabel
    Friend WithEvents LL_PS5 As System.Windows.Forms.LinkLabel
    Friend WithEvents LL_UPS5 As System.Windows.Forms.LinkLabel
    Friend WithEvents LL_UPS4 As System.Windows.Forms.LinkLabel
    Friend WithEvents LL_UPS3 As System.Windows.Forms.LinkLabel
    Friend WithEvents LL_UPS2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LL_UPS1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
