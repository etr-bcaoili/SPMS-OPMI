<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucUploadedRawdata
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnClose = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GridListing = New System.Windows.Forms.DataGridView
        Me.CompanyCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FileName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UploadedDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Uploadedby = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalGrossAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductDisc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalNetAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnFilter = New System.Windows.Forms.Button
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.cmbfilter = New System.Windows.Forms.ComboBox
        Me.lblSelection = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridListing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(885, 25)
        Me.ToolStrip1.TabIndex = 19
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(885, 58)
        Me.Panel1.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 21)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Raw Data Log File"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GridListing)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 132)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(934, 468)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'GridListing
        '
        Me.GridListing.AllowUserToAddRows = False
        Me.GridListing.AllowUserToDeleteRows = False
        Me.GridListing.AllowUserToOrderColumns = True
        Me.GridListing.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridListing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridListing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CompanyCode, Me.FileName, Me.UploadedDate, Me.Uploadedby, Me.TotalGrossAmount, Me.ProductDisc, Me.TotalNetAmount, Me.TotalQuantity})
        Me.GridListing.Location = New System.Drawing.Point(6, 20)
        Me.GridListing.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridListing.Name = "GridListing"
        Me.GridListing.Size = New System.Drawing.Size(922, 441)
        Me.GridListing.TabIndex = 1
        '
        'CompanyCode
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompanyCode.DefaultCellStyle = DataGridViewCellStyle1
        Me.CompanyCode.HeaderText = "Channel's Code"
        Me.CompanyCode.Name = "CompanyCode"
        Me.CompanyCode.ReadOnly = True
        Me.CompanyCode.Width = 160
        '
        'FileName
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileName.DefaultCellStyle = DataGridViewCellStyle2
        Me.FileName.HeaderText = "File Name"
        Me.FileName.Name = "FileName"
        Me.FileName.Width = 160
        '
        'UploadedDate
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UploadedDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.UploadedDate.HeaderText = "Upload Date"
        Me.UploadedDate.Name = "UploadedDate"
        Me.UploadedDate.ReadOnly = True
        Me.UploadedDate.Width = 160
        '
        'Uploadedby
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Uploadedby.DefaultCellStyle = DataGridViewCellStyle4
        Me.Uploadedby.HeaderText = "Upload By"
        Me.Uploadedby.Name = "Uploadedby"
        Me.Uploadedby.ReadOnly = True
        Me.Uploadedby.Width = 160
        '
        'TotalGrossAmount
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.TotalGrossAmount.DefaultCellStyle = DataGridViewCellStyle5
        Me.TotalGrossAmount.HeaderText = "Total Gross Amount"
        Me.TotalGrossAmount.Name = "TotalGrossAmount"
        Me.TotalGrossAmount.Width = 140
        '
        'ProductDisc
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.ProductDisc.DefaultCellStyle = DataGridViewCellStyle6
        Me.ProductDisc.HeaderText = "Product Discount"
        Me.ProductDisc.Name = "ProductDisc"
        Me.ProductDisc.Width = 140
        '
        'TotalNetAmount
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.TotalNetAmount.DefaultCellStyle = DataGridViewCellStyle7
        Me.TotalNetAmount.HeaderText = "Total Net Amount"
        Me.TotalNetAmount.Name = "TotalNetAmount"
        Me.TotalNetAmount.Width = 140
        '
        'TotalQuantity
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.TotalQuantity.DefaultCellStyle = DataGridViewCellStyle8
        Me.TotalQuantity.HeaderText = "Total Quantity"
        Me.TotalQuantity.Name = "TotalQuantity"
        Me.TotalQuantity.Width = 140
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(453, 103)
        Me.btnFilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(79, 24)
        Me.btnFilter.TabIndex = 24
        Me.btnFilter.Text = "Filter "
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'txtFilter
        '
        Me.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFilter.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilter.Location = New System.Drawing.Point(231, 103)
        Me.txtFilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(207, 22)
        Me.txtFilter.TabIndex = 23
        '
        'cmbfilter
        '
        Me.cmbfilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbfilter.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbfilter.FormattingEnabled = True
        Me.cmbfilter.Items.AddRange(New Object() {"Channel's Code", "File Name", "Upload Date", "Upload By"})
        Me.cmbfilter.Location = New System.Drawing.Point(79, 105)
        Me.cmbfilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbfilter.Name = "cmbfilter"
        Me.cmbfilter.Size = New System.Drawing.Size(146, 21)
        Me.cmbfilter.TabIndex = 22
        '
        'lblSelection
        '
        Me.lblSelection.AutoSize = True
        Me.lblSelection.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelection.Location = New System.Drawing.Point(16, 109)
        Me.lblSelection.Name = "lblSelection"
        Me.lblSelection.Size = New System.Drawing.Size(60, 13)
        Me.lblSelection.TabIndex = 21
        Me.lblSelection.Text = "Selection :"
        '
        'ucUploadedRawdata
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.cmbfilter)
        Me.Controls.Add(Me.lblSelection)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucUploadedRawdata"
        Me.Size = New System.Drawing.Size(885, 578)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridListing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GridListing As System.Windows.Forms.DataGridView
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents cmbfilter As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelection As System.Windows.Forms.Label
    Friend WithEvents CompanyCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FileName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UploadedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Uploadedby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalGrossAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductDisc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalNetAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalQuantity As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
