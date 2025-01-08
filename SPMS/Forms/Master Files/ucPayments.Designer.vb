<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPayments
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.Load = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Close = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtinvoicenum = New System.Windows.Forms.TextBox
        Me.txtcustNumber = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboxMonth = New System.Windows.Forms.ComboBox
        Me.cboxYear = New System.Windows.Forms.ComboBox
        Me.cboxCompCode = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtSaleAgentName = New System.Windows.Forms.TextBox
        Me.txtSaleAgentCode = New System.Windows.Forms.TextBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.dtpCheckDate = New System.Windows.Forms.DateTimePicker
        Me.txtPaymentAmt = New System.Windows.Forms.TextBox
        Me.txtPayTo = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Compute = New System.Windows.Forms.Button
        Me.txtremainingBal = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtcheckNum = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtrebateAmt = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rebatesdgv = New System.Windows.Forms.DataGridView
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.rebatesdgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Load, Me.ToolStripSeparator1, Me.btnSave, Me.ToolStripSeparator2, Me.Close})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(787, 25)
        Me.ToolStrip1.TabIndex = 23
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Load
        '
        Me.Load.Image = Global.SPMSOPCI.My.Resources.Resources.refresh
        Me.Load.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Load.Name = "Load"
        Me.Load.Size = New System.Drawing.Size(53, 22)
        Me.Load.Text = "Load"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnSave
        '
        Me.btnSave.Image = Global.SPMSOPCI.My.Resources.Resources.WSS_DocLib1
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(51, 22)
        Me.btnSave.Text = "Save"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Close
        '
        Me.Close.Image = Global.SPMSOPCI.My.Resources.Resources.delete
        Me.Close.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Close.Name = "Close"
        Me.Close.Size = New System.Drawing.Size(56, 22)
        Me.Close.Text = "Close"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.txtinvoicenum)
        Me.GroupBox1.Controls.Add(Me.txtcustNumber)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cboxMonth)
        Me.GroupBox1.Controls.Add(Me.cboxYear)
        Me.GroupBox1.Controls.Add(Me.cboxCompCode)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(787, 108)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter"
        '
        'txtinvoicenum
        '
        Me.txtinvoicenum.Location = New System.Drawing.Point(346, 50)
        Me.txtinvoicenum.Name = "txtinvoicenum"
        Me.txtinvoicenum.Size = New System.Drawing.Size(100, 20)
        Me.txtinvoicenum.TabIndex = 9
        '
        'txtcustNumber
        '
        Me.txtcustNumber.Location = New System.Drawing.Point(346, 19)
        Me.txtcustNumber.Name = "txtcustNumber"
        Me.txtcustNumber.Size = New System.Drawing.Size(100, 20)
        Me.txtcustNumber.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(239, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Invoice Number"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(239, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Customer Number"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Month Select "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Year  Select "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Company Code"
        '
        'cboxMonth
        '
        Me.cboxMonth.FormattingEnabled = True
        Me.cboxMonth.Location = New System.Drawing.Point(102, 78)
        Me.cboxMonth.Name = "cboxMonth"
        Me.cboxMonth.Size = New System.Drawing.Size(77, 21)
        Me.cboxMonth.TabIndex = 2
        '
        'cboxYear
        '
        Me.cboxYear.FormattingEnabled = True
        Me.cboxYear.Location = New System.Drawing.Point(102, 47)
        Me.cboxYear.Name = "cboxYear"
        Me.cboxYear.Size = New System.Drawing.Size(77, 21)
        Me.cboxYear.TabIndex = 1
        '
        'cboxCompCode
        '
        Me.cboxCompCode.FormattingEnabled = True
        Me.cboxCompCode.Location = New System.Drawing.Point(102, 19)
        Me.cboxCompCode.Name = "cboxCompCode"
        Me.cboxCompCode.Size = New System.Drawing.Size(77, 21)
        Me.cboxCompCode.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.txtSaleAgentName)
        Me.GroupBox2.Controls.Add(Me.txtSaleAgentCode)
        Me.GroupBox2.Controls.Add(Me.LinkLabel1)
        Me.GroupBox2.Controls.Add(Me.dtpCheckDate)
        Me.GroupBox2.Controls.Add(Me.txtPaymentAmt)
        Me.GroupBox2.Controls.Add(Me.txtPayTo)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Compute)
        Me.GroupBox2.Controls.Add(Me.txtremainingBal)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtcheckNum)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtrebateAmt)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 191)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(787, 128)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Payment Details"
        '
        'txtSaleAgentName
        '
        Me.txtSaleAgentName.Location = New System.Drawing.Point(595, 29)
        Me.txtSaleAgentName.Name = "txtSaleAgentName"
        Me.txtSaleAgentName.Size = New System.Drawing.Size(186, 20)
        Me.txtSaleAgentName.TabIndex = 18
        '
        'txtSaleAgentCode
        '
        Me.txtSaleAgentCode.Location = New System.Drawing.Point(522, 29)
        Me.txtSaleAgentCode.Name = "txtSaleAgentCode"
        Me.txtSaleAgentCode.Size = New System.Drawing.Size(67, 20)
        Me.txtSaleAgentCode.TabIndex = 17
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(452, 34)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(64, 13)
        Me.LinkLabel1.TabIndex = 16
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Sales Agent"
        '
        'dtpCheckDate
        '
        Me.dtpCheckDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCheckDate.Location = New System.Drawing.Point(102, 90)
        Me.dtpCheckDate.Name = "dtpCheckDate"
        Me.dtpCheckDate.Size = New System.Drawing.Size(100, 20)
        Me.dtpCheckDate.TabIndex = 15
        '
        'txtPaymentAmt
        '
        Me.txtPaymentAmt.BackColor = System.Drawing.SystemColors.Window
        Me.txtPaymentAmt.Location = New System.Drawing.Point(346, 27)
        Me.txtPaymentAmt.Name = "txtPaymentAmt"
        Me.txtPaymentAmt.Size = New System.Drawing.Size(100, 20)
        Me.txtPaymentAmt.TabIndex = 14
        '
        'txtPayTo
        '
        Me.txtPayTo.Location = New System.Drawing.Point(522, 63)
        Me.txtPayTo.Name = "txtPayTo"
        Me.txtPayTo.Size = New System.Drawing.Size(259, 20)
        Me.txtPayTo.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(452, 66)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Pay To"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Check Date"
        '
        'Compute
        '
        Me.Compute.Location = New System.Drawing.Point(346, 90)
        Me.Compute.Name = "Compute"
        Me.Compute.Size = New System.Drawing.Size(100, 28)
        Me.Compute.TabIndex = 8
        Me.Compute.Text = "Compute"
        Me.Compute.UseVisualStyleBackColor = True
        '
        'txtremainingBal
        '
        Me.txtremainingBal.Location = New System.Drawing.Point(346, 58)
        Me.txtremainingBal.Name = "txtremainingBal"
        Me.txtremainingBal.ReadOnly = True
        Me.txtremainingBal.Size = New System.Drawing.Size(100, 20)
        Me.txtremainingBal.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(243, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Remaining Balance"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(243, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Payment Amount"
        '
        'txtcheckNum
        '
        Me.txtcheckNum.Location = New System.Drawing.Point(102, 57)
        Me.txtcheckNum.Name = "txtcheckNum"
        Me.txtcheckNum.Size = New System.Drawing.Size(100, 20)
        Me.txtcheckNum.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Check Number"
        '
        'txtrebateAmt
        '
        Me.txtrebateAmt.Location = New System.Drawing.Point(102, 27)
        Me.txtrebateAmt.Name = "txtrebateAmt"
        Me.txtrebateAmt.ReadOnly = True
        Me.txtrebateAmt.Size = New System.Drawing.Size(100, 20)
        Me.txtrebateAmt.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Rebates Amount"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(787, 58)
        Me.Panel1.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 21)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Payments"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.rebatesdgv)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 319)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(787, 229)
        Me.GroupBox3.TabIndex = 29
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Result"
        '
        'rebatesdgv
        '
        Me.rebatesdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.rebatesdgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rebatesdgv.Location = New System.Drawing.Point(3, 16)
        Me.rebatesdgv.Name = "rebatesdgv"
        Me.rebatesdgv.Size = New System.Drawing.Size(781, 210)
        Me.rebatesdgv.TabIndex = 0
        '
        'ucPayments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ucPayments"
        Me.Size = New System.Drawing.Size(787, 548)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.rebatesdgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Load As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboxMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cboxYear As System.Windows.Forms.ComboBox
    Friend WithEvents cboxCompCode As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Compute As System.Windows.Forms.Button
    Friend WithEvents txtremainingBal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcheckNum As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtrebateAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtinvoicenum As System.Windows.Forms.TextBox
    Friend WithEvents txtcustNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPayTo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpCheckDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtPaymentAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtSaleAgentCode As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtSaleAgentName As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rebatesdgv As System.Windows.Forms.DataGridView

End Class
