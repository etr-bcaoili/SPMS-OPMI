<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIPosition
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadMenu1 = New Telerik.WinControls.UI.RadMenu()
        Me.btnNew = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnEdit = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnSave = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnDelete = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnFinddata = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClear = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClose = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.txtCode = New Telerik.WinControls.UI.RadTextBox()
        Me.txtDescription = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.chkIsActive = New Telerik.WinControls.UI.RadCheckBox()
        Me.dtEnddate = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.RadLabel53 = New Telerik.WinControls.UI.RadLabel()
        Me.dtStartDate = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.RadLabel17 = New Telerik.WinControls.UI.RadLabel()
        Me.Office2010BlackTheme1 = New Telerik.WinControls.Themes.Office2010BlackTheme()
        Me.Office2019LightTheme1 = New Telerik.WinControls.Themes.Office2010BlueTheme
        Me.Panel1.SuspendLayout()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIsActive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtEnddate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel53, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtStartDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel17, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1526, 59)
        Me.Panel1.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 30)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Position Entry"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(-61, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(199, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product Manager"
        '
        'RadMenu1
        '
        Me.RadMenu1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnNew, Me.btnEdit, Me.btnSave, Me.btnDelete, Me.btnFinddata, Me.btnClear, Me.btnClose})
        Me.RadMenu1.Location = New System.Drawing.Point(0, 59)
        Me.RadMenu1.Name = "RadMenu1"
        Me.RadMenu1.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        Me.RadMenu1.Size = New System.Drawing.Size(1526, 33)
        Me.RadMenu1.TabIndex = 173
        Me.RadMenu1.ThemeName = "Office2010Silver"
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Image = Global.SPMSOPCI.My.Resources.Resources.if_Plus_1891033
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Text = "&New"
        Me.btnNew.UseCompatibleTextRendering = False
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Image = Global.SPMSOPCI.My.Resources.Resources.if_edit_173002
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.UseCompatibleTextRendering = False
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.SPMSOPCI.My.Resources.Resources.if_save_173091
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseCompatibleTextRendering = False
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = Global.SPMSOPCI.My.Resources.Resources.rubbish
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseCompatibleTextRendering = False
        '
        'btnFinddata
        '
        Me.btnFinddata.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinddata.Image = Global.SPMSOPCI.My.Resources.Resources.iconfinder_binocular__spyglass__view__search_2538706
        Me.btnFinddata.Name = "btnFinddata"
        Me.btnFinddata.Text = "&Find"
        Me.btnFinddata.UseCompatibleTextRendering = False
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
        'RadLabel3
        '
        Me.RadLabel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel3.Location = New System.Drawing.Point(22, 152)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(84, 19)
        Me.RadLabel3.TabIndex = 757
        Me.RadLabel3.Text = "Position Code"
        '
        'txtCode
        '
        Me.txtCode.AutoSize = False
        Me.txtCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.txtCode.Location = New System.Drawing.Point(121, 151)
        Me.txtCode.Multiline = True
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(162, 25)
        Me.txtCode.TabIndex = 755
        Me.txtCode.ThemeName = "Office2019Light"
        '
        'txtDescription
        '
        Me.txtDescription.AutoSize = False
        Me.txtDescription.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDescription.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.txtDescription.Location = New System.Drawing.Point(121, 180)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(466, 24)
        Me.txtDescription.TabIndex = 756
        Me.txtDescription.ThemeName = "Office2019Light"
        '
        'RadLabel1
        '
        Me.RadLabel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel1.Location = New System.Drawing.Point(22, 180)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(74, 19)
        Me.RadLabel1.TabIndex = 758
        Me.RadLabel1.Text = "Description "
        '
        'chkIsActive
        '
        Me.chkIsActive.CheckAlignment = System.Drawing.ContentAlignment.TopRight
        Me.chkIsActive.Checked = System.Windows.Forms.CheckState.Checked
        Me.chkIsActive.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsActive.Location = New System.Drawing.Point(519, 151)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(68, 17)
        Me.chkIsActive.TabIndex = 759
        Me.chkIsActive.Text = "Is Active"
        Me.chkIsActive.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkIsActive.ThemeName = "Office2019Light"
        Me.chkIsActive.ToggleState = Telerik.WinControls.Enumerations.ToggleState.[On]
        '
        'dtEnddate
        '
        Me.dtEnddate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtEnddate.CalendarSize = New System.Drawing.Size(290, 320)
        Me.dtEnddate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.dtEnddate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEnddate.Location = New System.Drawing.Point(439, 266)
        Me.dtEnddate.Name = "dtEnddate"
        Me.dtEnddate.Size = New System.Drawing.Size(148, 25)
        Me.dtEnddate.TabIndex = 879
        Me.dtEnddate.TabStop = False
        Me.dtEnddate.Text = "7/9/2018"
        Me.dtEnddate.ThemeName = "Crystal"
        Me.dtEnddate.Value = New Date(2018, 7, 9, 0, 0, 0, 0)
        '
        'RadLabel53
        '
        Me.RadLabel53.BackColor = System.Drawing.Color.White
        Me.RadLabel53.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel53.Location = New System.Drawing.Point(296, 272)
        Me.RadLabel53.Name = "RadLabel53"
        Me.RadLabel53.Size = New System.Drawing.Size(116, 19)
        Me.RadLabel53.TabIndex = 878
        Me.RadLabel53.Text = "Effectivity End Date"
        '
        'dtStartDate
        '
        Me.dtStartDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtStartDate.CalendarSize = New System.Drawing.Size(290, 320)
        Me.dtStartDate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStartDate.Location = New System.Drawing.Point(439, 236)
        Me.dtStartDate.Name = "dtStartDate"
        Me.dtStartDate.Size = New System.Drawing.Size(148, 25)
        Me.dtStartDate.TabIndex = 877
        Me.dtStartDate.TabStop = False
        Me.dtStartDate.Text = "7/9/2018"
        Me.dtStartDate.ThemeName = "Crystal"
        Me.dtStartDate.Value = New Date(2018, 7, 9, 0, 0, 0, 0)
        '
        'RadLabel17
        '
        Me.RadLabel17.BackColor = System.Drawing.Color.White
        Me.RadLabel17.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel17.Location = New System.Drawing.Point(296, 242)
        Me.RadLabel17.Name = "RadLabel17"
        Me.RadLabel17.Size = New System.Drawing.Size(122, 19)
        Me.RadLabel17.TabIndex = 876
        Me.RadLabel17.Text = "Effectivity Start Date"
        '
        'UIPosition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.dtEnddate)
        Me.Controls.Add(Me.RadLabel53)
        Me.Controls.Add(Me.dtStartDate)
        Me.Controls.Add(Me.RadLabel17)
        Me.Controls.Add(Me.chkIsActive)
        Me.Controls.Add(Me.RadLabel3)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.RadLabel1)
        Me.Controls.Add(Me.RadMenu1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UIPosition"
        Me.Size = New System.Drawing.Size(1526, 834)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIsActive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtEnddate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel53, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtStartDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel17, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents btnNew As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnEdit As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnFinddata As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClear As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtCode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtDescription As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkIsActive As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents dtEnddate As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents RadLabel53 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents dtStartDate As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents RadLabel17 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents Office2010BlackTheme1 As Telerik.WinControls.Themes.Office2010BlackTheme
    Friend WithEvents Office2019LightTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme
End Class
