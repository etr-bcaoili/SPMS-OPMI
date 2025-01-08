<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UITerritoryProductPerformance
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cmdToMonth = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.txtConfigCode = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.txtConfgName = New Telerik.WinControls.UI.RadTextBox()
        Me.cmdYear = New Telerik.WinControls.UI.RadDropDownList()
        Me.cmdFromMonth = New Telerik.WinControls.UI.RadDropDownList()
        Me.Findconfig = New System.Windows.Forms.LinkLabel()
        Me.RadMenu1 = New Telerik.WinControls.UI.RadMenu()
        Me.btnTransfered = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClear = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClose = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.GridView = New Telerik.WinControls.UI.RadGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.cmdToMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConfigCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConfgName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdFromMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 58)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1492, 147)
        Me.Panel2.TabIndex = 23
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.RadMenu1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(606, 145)
        Me.Panel3.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.cmdToMonth)
        Me.Panel4.Controls.Add(Me.RadLabel1)
        Me.Panel4.Controls.Add(Me.txtConfigCode)
        Me.Panel4.Controls.Add(Me.RadLabel2)
        Me.Panel4.Controls.Add(Me.RadLabel4)
        Me.Panel4.Controls.Add(Me.txtConfgName)
        Me.Panel4.Controls.Add(Me.cmdYear)
        Me.Panel4.Controls.Add(Me.cmdFromMonth)
        Me.Panel4.Controls.Add(Me.Findconfig)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 33)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(604, 110)
        Me.Panel4.TabIndex = 175
        '
        'cmdToMonth
        '
        Me.cmdToMonth.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdToMonth.Location = New System.Drawing.Point(454, 70)
        Me.cmdToMonth.Name = "cmdToMonth"
        Me.cmdToMonth.Size = New System.Drawing.Size(137, 23)
        Me.cmdToMonth.TabIndex = 777
        Me.cmdToMonth.ThemeName = "Office2010Silver"
        '
        'RadLabel1
        '
        Me.RadLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel1.Location = New System.Drawing.Point(375, 71)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(68, 19)
        Me.RadLabel1.TabIndex = 776
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
        Me.txtConfigCode.ThemeName = "Office2019Light"
        '
        'RadLabel2
        '
        Me.RadLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel2.Location = New System.Drawing.Point(23, 48)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(31, 19)
        Me.RadLabel2.TabIndex = 770
        Me.RadLabel2.Text = "Year"
        '
        'RadLabel4
        '
        Me.RadLabel4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel4.Location = New System.Drawing.Point(22, 74)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(77, 19)
        Me.RadLabel4.TabIndex = 771
        Me.RadLabel4.Text = "From Month"
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
        Me.Findconfig.Location = New System.Drawing.Point(22, 25)
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
        Me.RadMenu1.Size = New System.Drawing.Size(604, 33)
        Me.RadMenu1.TabIndex = 174
        Me.RadMenu1.ThemeName = "Office2010Silver"
        '
        'btnTransfered
        '
        Me.btnTransfered.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransfered.Image = Global.SPMSOPCI.My.Resources.Resources.icons8_database_administrator_24
        Me.btnTransfered.Name = "btnTransfered"
        Me.btnTransfered.Text = "&Transafered Data"
        Me.btnTransfered.UseCompatibleTextRendering = False
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Image = Global.SPMSOPCI.My.Resources.Resources.if_ko_red_539481
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Text = "&Clear"
        Me.btnClear.UseCompatibleTextRendering = False
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = Global.SPMSOPCI.My.Resources.Resources.icons8_close_window_24
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Text = "Close"
        Me.btnClose.UseCompatibleTextRendering = False
        '
        'GridView
        '
        Me.GridView.BackColor = System.Drawing.Color.White
        Me.GridView.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridView.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.GridView.ForeColor = System.Drawing.Color.Black
        Me.GridView.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GridView.Location = New System.Drawing.Point(0, 205)
        '
        '
        '
        Me.GridView.MasterTemplate.AllowAddNewRow = False
        Me.GridView.MasterTemplate.AllowDeleteRow = False
        Me.GridView.MasterTemplate.AllowEditRow = False
        Me.GridView.MasterTemplate.EnableAlternatingRowColor = True
        Me.GridView.MasterTemplate.EnableFiltering = True
        Me.GridView.MasterTemplate.EnableGrouping = False
        Me.GridView.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.GridView.Name = "GridView"
        Me.GridView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GridView.Size = New System.Drawing.Size(1492, 625)
        Me.GridView.TabIndex = 55
        Me.GridView.ThemeName = "Office2010Silver"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1492, 58)
        Me.Panel1.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(369, 30)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Territory Product Performance by Pivot"
        '
        'UITerritoryProductPerformance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.GridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UITerritoryProductPerformance"
        Me.Size = New System.Drawing.Size(1492, 830)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.cmdToMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConfigCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConfgName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdFromMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtConfgName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtConfigCode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Findconfig As System.Windows.Forms.LinkLabel
    Friend WithEvents cmdYear As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents cmdFromMonth As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents GridView As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnTransfered As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClear As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents Office2010SilverTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme
    Friend WithEvents cmdToMonth As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel

End Class
