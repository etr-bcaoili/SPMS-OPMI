<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIDMICTerritoryManagerPeriodToPeriodPivot
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
        Dim GridViewCheckBoxColumn1 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.cmdToMonth = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.txtConfigCode = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.txtConfgName = New Telerik.WinControls.UI.RadTextBox()
        Me.cmdYear = New Telerik.WinControls.UI.RadDropDownList()
        Me.cmdFromMonth = New Telerik.WinControls.UI.RadDropDownList()
        Me.Findconfig = New System.Windows.Forms.LinkLabel()
        Me.RadMenu1 = New Telerik.WinControls.UI.RadMenu()
        Me.btnTransfered = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClear = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClose = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.GrdCompanyView = New Telerik.WinControls.UI.RadGridView()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.GridView = New Telerik.WinControls.UI.RadGridView()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdToMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConfigCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConfgName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdFromMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.GrdCompanyView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrdCompanyView.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(1539, 47)
        Me.Panel1.TabIndex = 35
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(22, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(680, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "District Manager Customer Territory Manager Comparative Period to Period (Net of " &
    "VAT, MT, DM)"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 47)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1539, 148)
        Me.Panel2.TabIndex = 36
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.RadMenu1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(606, 146)
        Me.Panel3.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.RadLabel4)
        Me.Panel4.Controls.Add(Me.cmdToMonth)
        Me.Panel4.Controls.Add(Me.RadLabel1)
        Me.Panel4.Controls.Add(Me.txtConfigCode)
        Me.Panel4.Controls.Add(Me.RadLabel2)
        Me.Panel4.Controls.Add(Me.txtConfgName)
        Me.Panel4.Controls.Add(Me.cmdYear)
        Me.Panel4.Controls.Add(Me.cmdFromMonth)
        Me.Panel4.Controls.Add(Me.Findconfig)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 38)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(604, 106)
        Me.Panel4.TabIndex = 175
        '
        'RadLabel4
        '
        Me.RadLabel4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel4.Location = New System.Drawing.Point(28, 74)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(77, 19)
        Me.RadLabel4.TabIndex = 776
        Me.RadLabel4.Text = "From Month"
        '
        'cmdToMonth
        '
        Me.cmdToMonth.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdToMonth.Location = New System.Drawing.Point(454, 74)
        Me.cmdToMonth.Name = "cmdToMonth"
        Me.cmdToMonth.Size = New System.Drawing.Size(137, 23)
        Me.cmdToMonth.TabIndex = 775
        Me.cmdToMonth.ThemeName = "Office2010Silver"
        '
        'RadLabel1
        '
        Me.RadLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel1.Location = New System.Drawing.Point(375, 75)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(68, 19)
        Me.RadLabel1.TabIndex = 774
        Me.RadLabel1.Text = "To Month :"
        '
        'txtConfigCode
        '
        Me.txtConfigCode.AutoSize = False
        Me.txtConfigCode.BackColor = System.Drawing.Color.White
        Me.txtConfigCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConfigCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtConfigCode.Location = New System.Drawing.Point(136, 18)
        Me.txtConfigCode.Multiline = True
        Me.txtConfigCode.Name = "txtConfigCode"
        Me.txtConfigCode.ReadOnly = True
        Me.txtConfigCode.Size = New System.Drawing.Size(143, 25)
        Me.txtConfigCode.TabIndex = 395
        Me.txtConfigCode.TabStop = False
        Me.txtConfigCode.ThemeName = "Office2019Light"
        '
        'RadLabel2
        '
        Me.RadLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel2.Location = New System.Drawing.Point(28, 47)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(31, 19)
        Me.RadLabel2.TabIndex = 770
        Me.RadLabel2.Text = "Year"
        '
        'txtConfgName
        '
        Me.txtConfgName.AutoSize = False
        Me.txtConfgName.BackColor = System.Drawing.Color.White
        Me.txtConfgName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConfgName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtConfgName.Location = New System.Drawing.Point(282, 18)
        Me.txtConfgName.Multiline = True
        Me.txtConfgName.Name = "txtConfgName"
        Me.txtConfgName.ReadOnly = True
        Me.txtConfgName.Size = New System.Drawing.Size(309, 25)
        Me.txtConfgName.TabIndex = 396
        Me.txtConfgName.TabStop = False
        Me.txtConfgName.ThemeName = "Office2019Light"
        '
        'cmdYear
        '
        Me.cmdYear.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdYear.Location = New System.Drawing.Point(136, 46)
        Me.cmdYear.Name = "cmdYear"
        Me.cmdYear.Size = New System.Drawing.Size(143, 23)
        Me.cmdYear.TabIndex = 773
        Me.cmdYear.ThemeName = "Office2010Silver"
        '
        'cmdFromMonth
        '
        Me.cmdFromMonth.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFromMonth.Location = New System.Drawing.Point(136, 72)
        Me.cmdFromMonth.Name = "cmdFromMonth"
        Me.cmdFromMonth.Size = New System.Drawing.Size(143, 23)
        Me.cmdFromMonth.TabIndex = 772
        Me.cmdFromMonth.ThemeName = "Office2010Silver"
        '
        'Findconfig
        '
        Me.Findconfig.AutoSize = True
        Me.Findconfig.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Findconfig.Location = New System.Drawing.Point(28, 24)
        Me.Findconfig.Name = "Findconfig"
        Me.Findconfig.Size = New System.Drawing.Size(83, 14)
        Me.Findconfig.TabIndex = 394
        Me.Findconfig.TabStop = True
        Me.Findconfig.Text = "Configuration "
        '
        'RadMenu1
        '
        Me.RadMenu1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnTransfered, Me.btnClear, Me.btnClose})
        Me.RadMenu1.Location = New System.Drawing.Point(0, 0)
        Me.RadMenu1.Name = "RadMenu1"
        Me.RadMenu1.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        '
        '
        '
        Me.RadMenu1.RootElement.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        Me.RadMenu1.Size = New System.Drawing.Size(604, 38)
        Me.RadMenu1.TabIndex = 174
        Me.RadMenu1.ThemeName = "Office2010Silver"
        '
        'btnTransfered
        '
        Me.btnTransfered.AccessibleDescription = "&Transafered Data"
        Me.btnTransfered.AccessibleName = "&Transafered Data"
        '
        '
        '
        Me.btnTransfered.ButtonElement.AccessibleDescription = "&Transafered Data"
        Me.btnTransfered.ButtonElement.AccessibleName = "&Transafered Data"
        Me.btnTransfered.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransfered.Image = Global.SPMSOPCI.My.Resources.Resources.icons8_database_administrator_24
        Me.btnTransfered.Name = "btnTransfered"
        Me.btnTransfered.Text = "&Transafered Data"
        Me.btnTransfered.UseCompatibleTextRendering = False
        Me.btnTransfered.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnClear
        '
        Me.btnClear.AccessibleDescription = "&Clear"
        Me.btnClear.AccessibleName = "&Clear"
        '
        '
        '
        Me.btnClear.ButtonElement.AccessibleDescription = "&Clear"
        Me.btnClear.ButtonElement.AccessibleName = "&Clear"
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Image = Global.SPMSOPCI.My.Resources.Resources.if_ko_red_539481
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Text = "&Clear"
        Me.btnClear.UseCompatibleTextRendering = False
        Me.btnClear.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnClose
        '
        Me.btnClose.AccessibleDescription = "Close"
        Me.btnClose.AccessibleName = "Close"
        '
        '
        '
        Me.btnClose.ButtonElement.AccessibleDescription = "Close"
        Me.btnClose.ButtonElement.AccessibleName = "Close"
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = Global.SPMSOPCI.My.Resources.Resources.icons8_close_window_24
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Text = "Close"
        Me.btnClose.UseCompatibleTextRendering = False
        Me.btnClose.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.GrdCompanyView)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 195)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(433, 646)
        Me.Panel5.TabIndex = 37
        '
        'GrdCompanyView
        '
        Me.GrdCompanyView.BackColor = System.Drawing.Color.White
        Me.GrdCompanyView.Cursor = System.Windows.Forms.Cursors.Default
        Me.GrdCompanyView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdCompanyView.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.GrdCompanyView.ForeColor = System.Drawing.Color.Black
        Me.GrdCompanyView.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GrdCompanyView.Location = New System.Drawing.Point(0, 0)
        '
        'GrdCompanyView
        '
        Me.GrdCompanyView.MasterTemplate.AllowAddNewRow = False
        Me.GrdCompanyView.MasterTemplate.AllowDeleteRow = False
        GridViewCheckBoxColumn1.EnableExpressionEditor = False
        GridViewCheckBoxColumn1.HeaderText = "[0]"
        GridViewCheckBoxColumn1.MinWidth = 20
        GridViewCheckBoxColumn1.Name = "column1"
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.HeaderText = "COMPANY CODE"
        GridViewTextBoxColumn1.Name = "column2"
        GridViewTextBoxColumn1.ReadOnly = True
        GridViewTextBoxColumn1.Width = 120
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.HeaderText = "COMPANY NAME"
        GridViewTextBoxColumn2.Name = "column3"
        GridViewTextBoxColumn2.ReadOnly = True
        GridViewTextBoxColumn2.Width = 219
        Me.GrdCompanyView.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn1, GridViewTextBoxColumn1, GridViewTextBoxColumn2})
        Me.GrdCompanyView.MasterTemplate.EnableAlternatingRowColor = True
        Me.GrdCompanyView.MasterTemplate.EnableFiltering = True
        Me.GrdCompanyView.MasterTemplate.EnableGrouping = False
        Me.GrdCompanyView.Name = "GrdCompanyView"
        Me.GrdCompanyView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GrdCompanyView.Size = New System.Drawing.Size(433, 646)
        Me.GrdCompanyView.TabIndex = 55
        Me.GrdCompanyView.ThemeName = "Office2010Silver"
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.GridView)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(433, 195)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1106, 646)
        Me.Panel6.TabIndex = 38
        '
        'GridView
        '
        Me.GridView.BackColor = System.Drawing.Color.White
        Me.GridView.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridView.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.GridView.ForeColor = System.Drawing.Color.Black
        Me.GridView.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GridView.Location = New System.Drawing.Point(0, 0)
        '
        'GridView
        '
        Me.GridView.MasterTemplate.AllowAddNewRow = False
        Me.GridView.MasterTemplate.AllowDeleteRow = False
        Me.GridView.MasterTemplate.AllowEditRow = False
        Me.GridView.MasterTemplate.EnableAlternatingRowColor = True
        Me.GridView.MasterTemplate.EnableFiltering = True
        Me.GridView.MasterTemplate.EnableGrouping = False
        Me.GridView.Name = "GridView"
        Me.GridView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GridView.Size = New System.Drawing.Size(1104, 644)
        Me.GridView.TabIndex = 56
        Me.GridView.ThemeName = "Office2010Silver"
        '
        'UIDMICTerritoryManagerPeriodToPeriodPivot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UIDMICTerritoryManagerPeriodToPeriodPivot"
        Me.Size = New System.Drawing.Size(1539, 841)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdToMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConfigCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConfgName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdFromMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        CType(Me.GrdCompanyView.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrdCompanyView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        CType(Me.GridView.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txtConfigCode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtConfgName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmdYear As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents cmdFromMonth As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents Findconfig As System.Windows.Forms.LinkLabel
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents btnTransfered As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClear As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents GrdCompanyView As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents cmdToMonth As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents CrystalTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme
    Friend WithEvents GridView As Telerik.WinControls.UI.RadGridView

End Class
