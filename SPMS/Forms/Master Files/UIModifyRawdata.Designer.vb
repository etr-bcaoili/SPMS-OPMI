<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIModifyRawdata
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GrdViewRawData = New Telerik.WinControls.UI.RadGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.RadTextBox1 = New Telerik.WinControls.UI.RadTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtAddressLine2 = New Telerik.WinControls.UI.RadTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAddressLine1 = New Telerik.WinControls.UI.RadTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSuffix = New Telerik.WinControls.UI.RadTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMiddleName = New Telerik.WinControls.UI.RadTextBox()
        Me.txtFirstName = New Telerik.WinControls.UI.RadTextBox()
        Me.txtLastName = New Telerik.WinControls.UI.RadTextBox()
        Me.txtMDNumber = New Telerik.WinControls.UI.RadTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnOpenFile = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Office2019LightTheme1 = New Telerik.WinControls.Themes.Office2010BlueTheme
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.GrdViewRawData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrdViewRawData.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.RadTextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddressLine2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddressLine1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSuffix, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMiddleName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFirstName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLastName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMDNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(897, 58)
        Me.Panel1.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(238, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Modify RawData Medical Doctor "
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.GrdViewRawData)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 58)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(897, 237)
        Me.Panel2.TabIndex = 18
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
        Me.GrdViewRawData.Size = New System.Drawing.Size(895, 235)
        Me.GrdViewRawData.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 295)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(897, 333)
        Me.Panel3.TabIndex = 19
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Controls.Add(Me.ToolStrip1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 25)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(897, 308)
        Me.Panel5.TabIndex = 19
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.RadTextBox1)
        Me.Panel6.Controls.Add(Me.Label10)
        Me.Panel6.Controls.Add(Me.txtAddressLine2)
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.txtAddressLine1)
        Me.Panel6.Controls.Add(Me.Label8)
        Me.Panel6.Controls.Add(Me.txtSuffix)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Controls.Add(Me.txtMiddleName)
        Me.Panel6.Controls.Add(Me.txtFirstName)
        Me.Panel6.Controls.Add(Me.txtLastName)
        Me.Panel6.Controls.Add(Me.txtMDNumber)
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Controls.Add(Me.Label4)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(895, 281)
        Me.Panel6.TabIndex = 24
        '
        'RadTextBox1
        '
        Me.RadTextBox1.AutoSize = False
        Me.RadTextBox1.BackColor = System.Drawing.Color.White
        Me.RadTextBox1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadTextBox1.Location = New System.Drawing.Point(562, 42)
        Me.RadTextBox1.Multiline = True
        Me.RadTextBox1.Name = "RadTextBox1"
        Me.RadTextBox1.ReadOnly = True
        Me.RadTextBox1.Size = New System.Drawing.Size(321, 24)
        Me.RadTextBox1.TabIndex = 320
        Me.RadTextBox1.ThemeName = "Office2019Light"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(489, 46)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 15)
        Me.Label10.TabIndex = 319
        Me.Label10.Text = "PTR No :"
        '
        'txtAddressLine2
        '
        Me.txtAddressLine2.AutoSize = False
        Me.txtAddressLine2.BackColor = System.Drawing.Color.White
        Me.txtAddressLine2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddressLine2.Location = New System.Drawing.Point(133, 205)
        Me.txtAddressLine2.Multiline = True
        Me.txtAddressLine2.Name = "txtAddressLine2"
        Me.txtAddressLine2.ReadOnly = True
        Me.txtAddressLine2.Size = New System.Drawing.Size(321, 62)
        Me.txtAddressLine2.TabIndex = 318
        Me.txtAddressLine2.ThemeName = "Office2019Light"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(5, 209)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(119, 15)
        Me.Label9.TabIndex = 317
        Me.Label9.Text = "Addrees Line 2 :"
        '
        'txtAddressLine1
        '
        Me.txtAddressLine1.AutoSize = False
        Me.txtAddressLine1.BackColor = System.Drawing.Color.White
        Me.txtAddressLine1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddressLine1.Location = New System.Drawing.Point(133, 149)
        Me.txtAddressLine1.Multiline = True
        Me.txtAddressLine1.Name = "txtAddressLine1"
        Me.txtAddressLine1.ReadOnly = True
        Me.txtAddressLine1.Size = New System.Drawing.Size(321, 53)
        Me.txtAddressLine1.TabIndex = 316
        Me.txtAddressLine1.ThemeName = "Office2019Light"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(5, 154)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 15)
        Me.Label8.TabIndex = 315
        Me.Label8.Text = "Addrees Line 1 :"
        '
        'txtSuffix
        '
        Me.txtSuffix.AutoSize = False
        Me.txtSuffix.BackColor = System.Drawing.Color.White
        Me.txtSuffix.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuffix.Location = New System.Drawing.Point(133, 68)
        Me.txtSuffix.Multiline = True
        Me.txtSuffix.Name = "txtSuffix"
        Me.txtSuffix.ReadOnly = True
        Me.txtSuffix.Size = New System.Drawing.Size(104, 24)
        Me.txtSuffix.TabIndex = 290
        Me.txtSuffix.ThemeName = "Office2019Light"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(61, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 15)
        Me.Label7.TabIndex = 289
        Me.Label7.Text = "Suffix :"
        '
        'txtMiddleName
        '
        Me.txtMiddleName.AutoSize = False
        Me.txtMiddleName.BackColor = System.Drawing.Color.White
        Me.txtMiddleName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMiddleName.Location = New System.Drawing.Point(133, 122)
        Me.txtMiddleName.Multiline = True
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.ReadOnly = True
        Me.txtMiddleName.Size = New System.Drawing.Size(321, 24)
        Me.txtMiddleName.TabIndex = 288
        Me.txtMiddleName.ThemeName = "Office2019Light"
        '
        'txtFirstName
        '
        Me.txtFirstName.AutoSize = False
        Me.txtFirstName.BackColor = System.Drawing.Color.White
        Me.txtFirstName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(133, 95)
        Me.txtFirstName.Multiline = True
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.ReadOnly = True
        Me.txtFirstName.Size = New System.Drawing.Size(321, 24)
        Me.txtFirstName.TabIndex = 287
        Me.txtFirstName.ThemeName = "Office2019Light"
        '
        'txtLastName
        '
        Me.txtLastName.AutoSize = False
        Me.txtLastName.BackColor = System.Drawing.Color.White
        Me.txtLastName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(133, 41)
        Me.txtLastName.Multiline = True
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.ReadOnly = True
        Me.txtLastName.Size = New System.Drawing.Size(321, 24)
        Me.txtLastName.TabIndex = 286
        Me.txtLastName.ThemeName = "Office2019Light"
        '
        'txtMDNumber
        '
        Me.txtMDNumber.AutoSize = False
        Me.txtMDNumber.BackColor = System.Drawing.Color.White
        Me.txtMDNumber.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMDNumber.Location = New System.Drawing.Point(133, 14)
        Me.txtMDNumber.Multiline = True
        Me.txtMDNumber.Name = "txtMDNumber"
        Me.txtMDNumber.ReadOnly = True
        Me.txtMDNumber.Size = New System.Drawing.Size(188, 24)
        Me.txtMDNumber.TabIndex = 285
        Me.txtMDNumber.ThemeName = "Office2019Light"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Courier New", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(26, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 15)
        Me.Label3.TabIndex = 280
        Me.Label3.Text = "Doctor Code :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(40, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 15)
        Me.Label4.TabIndex = 281
        Me.Label4.Text = "Last Name :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(33, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 15)
        Me.Label5.TabIndex = 282
        Me.Label5.Text = "First Name :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(26, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 15)
        Me.Label6.TabIndex = 283
        Me.Label6.Text = "Middle Name :"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpenFile, Me.ToolStripSeparator3, Me.btnEdit, Me.ToolStripSeparator1, Me.btnClear, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 281)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(895, 25)
        Me.ToolStrip1.TabIndex = 23
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Image = Global.SPMSOPCI.My.Resources.Resources.find__1_
        Me.btnOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(77, 22)
        Me.btnOpenFile.Text = "&Open MD"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnEdit
        '
        Me.btnEdit.Image = Global.SPMSOPCI.My.Resources.Resources.icons8_pencil_drawing_32
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(65, 22)
        Me.btnEdit.Text = "&Update"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnClear
        '
        Me.btnClear.Image = Global.SPMSOPCI.My.Resources.Resources.close_copy
        Me.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(53, 22)
        Me.btnClear.Text = "Clear"
        '
        'btnClose
        '
        Me.btnClose.Image = Global.SPMSOPCI.My.Resources.Resources.cancel
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(55, 22)
        Me.btnClose.Text = "Close"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(897, 25)
        Me.Panel4.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Medical Doctor "
        '
        'UIModifyRawdata
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(897, 628)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UIModifyRawdata"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.GrdViewRawData.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrdViewRawData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.RadTextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAddressLine2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAddressLine1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSuffix, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMiddleName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFirstName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLastName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMDNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GrdViewRawData As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnOpenFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtSuffix As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMiddleName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtFirstName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtLastName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtMDNumber As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents RadTextBox1 As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAddressLine2 As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAddressLine1 As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Office2019LightTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme
End Class
