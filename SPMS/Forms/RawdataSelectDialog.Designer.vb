<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RawdataSelectDialog
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.dgData = New System.Windows.Forms.DataGridView
        Me.colCompanycode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colBatch = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colmonth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colyear = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colamounth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colqauntity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colnetamount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colProductDisc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colUploadDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cboColumns = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblFields = New System.Windows.Forms.Label
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCode
        '
        Me.txtCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtCode.Location = New System.Drawing.Point(182, 41)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(413, 20)
        Me.txtCode.TabIndex = 0
        '
        'dgData
        '
        Me.dgData.AllowUserToAddRows = False
        Me.dgData.AllowUserToDeleteRows = False
        Me.dgData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgData.BackgroundColor = System.Drawing.Color.White
        Me.dgData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCompanycode, Me.colBatch, Me.colmonth, Me.colyear, Me.colamounth, Me.colqauntity, Me.colnetamount, Me.colProductDisc, Me.colUploadDate})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgData.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgData.Location = New System.Drawing.Point(0, 72)
        Me.dgData.MultiSelect = False
        Me.dgData.Name = "dgData"
        Me.dgData.ReadOnly = True
        Me.dgData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgData.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgData.RowHeadersVisible = False
        Me.dgData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgData.Size = New System.Drawing.Size(627, 386)
        Me.dgData.TabIndex = 6
        '
        'colCompanycode
        '
        Me.colCompanycode.HeaderText = "Company Code"
        Me.colCompanycode.Name = "colCompanycode"
        Me.colCompanycode.ReadOnly = True
        Me.colCompanycode.Width = 96
        '
        'colBatch
        '
        Me.colBatch.HeaderText = "Batch "
        Me.colBatch.Name = "colBatch"
        Me.colBatch.ReadOnly = True
        Me.colBatch.Width = 63
        '
        'colmonth
        '
        Me.colmonth.HeaderText = "Month"
        Me.colmonth.Name = "colmonth"
        Me.colmonth.ReadOnly = True
        Me.colmonth.Width = 62
        '
        'colyear
        '
        Me.colyear.HeaderText = "Year"
        Me.colyear.Name = "colyear"
        Me.colyear.ReadOnly = True
        Me.colyear.Width = 54
        '
        'colamounth
        '
        Me.colamounth.HeaderText = "Total Gross Amount"
        Me.colamounth.Name = "colamounth"
        Me.colamounth.ReadOnly = True
        Me.colamounth.Width = 115
        '
        'colqauntity
        '
        Me.colqauntity.HeaderText = "Total Quantity "
        Me.colqauntity.Name = "colqauntity"
        Me.colqauntity.ReadOnly = True
        Me.colqauntity.Width = 93
        '
        'colnetamount
        '
        Me.colnetamount.HeaderText = "Total Net Amount"
        Me.colnetamount.Name = "colnetamount"
        Me.colnetamount.ReadOnly = True
        Me.colnetamount.Width = 106
        '
        'colProductDisc
        '
        Me.colProductDisc.HeaderText = "Total Product Disc"
        Me.colProductDisc.Name = "colProductDisc"
        Me.colProductDisc.ReadOnly = True
        Me.colProductDisc.Width = 110
        '
        'colUploadDate
        '
        Me.colUploadDate.HeaderText = "UploadDate "
        Me.colUploadDate.Name = "colUploadDate"
        Me.colUploadDate.ReadOnly = True
        Me.colUploadDate.Width = 92
        '
        'btnCancel
        '
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.Location = New System.Drawing.Point(534, 7)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 25)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 464)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(627, 39)
        Me.Panel1.TabIndex = 8
        '
        'cboColumns
        '
        Me.cboColumns.FormattingEnabled = True
        Me.cboColumns.Location = New System.Drawing.Point(9, 41)
        Me.cboColumns.Name = "cboColumns"
        Me.cboColumns.Size = New System.Drawing.Size(167, 21)
        Me.cboColumns.TabIndex = 2
        Me.cboColumns.Text = "All"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.txtCode)
        Me.GroupBox1.Controls.Add(Me.cboColumns)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblFields)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(0, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(627, 70)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Find"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(188, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Find What"
        '
        'lblFields
        '
        Me.lblFields.AutoSize = True
        Me.lblFields.Location = New System.Drawing.Point(6, 25)
        Me.lblFields.Name = "lblFields"
        Me.lblFields.Size = New System.Drawing.Size(43, 13)
        Me.lblFields.TabIndex = 3
        Me.lblFields.Text = "Look In"
        '
        'RawdataSelectDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 503)
        Me.Controls.Add(Me.dgData)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "RawdataSelectDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RawData Uploading Record"
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboColumns As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFields As System.Windows.Forms.Label
    Private WithEvents dgData As System.Windows.Forms.DataGridView
    Friend WithEvents colCompanycode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBatch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colmonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colyear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colamounth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colqauntity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colnetamount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProductDisc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUploadDate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
