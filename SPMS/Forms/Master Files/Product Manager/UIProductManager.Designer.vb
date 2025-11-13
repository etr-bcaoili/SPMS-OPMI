<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIProductManager
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadMenu1 = New Telerik.WinControls.UI.RadMenu()
        Me.btnNew = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnEdit = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnSave = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnDelete = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnFinddata = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClear = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClose = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.RadLabel10 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.txtConfigCode = New Telerik.WinControls.UI.RadTextBox()
        Me.txtConfgName = New Telerik.WinControls.UI.RadTextBox()
        Me.Findconfig = New System.Windows.Forms.LinkLabel()
        Me.dtEffectivityEndDate = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.RadLabel8 = New Telerik.WinControls.UI.RadLabel()
        Me.dtEffectivityStartDate = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.chkIsActive = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel6 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.txtProductManagerName = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.txtProductManagerCode = New Telerik.WinControls.UI.RadTextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConfigCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConfgName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtEffectivityEndDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtEffectivityStartDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIsActive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductManagerName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductManagerCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1666, 59)
        Me.Panel1.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(33, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(196, 21)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Product Manager Mapping"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(-61, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product Manager"
        '
        'RadMenu1
        '
        Me.RadMenu1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnNew, Me.btnEdit, Me.btnSave, Me.btnDelete, Me.btnFinddata, Me.btnClear, Me.btnClose})
        Me.RadMenu1.Location = New System.Drawing.Point(0, 59)
        Me.RadMenu1.Name = "RadMenu1"
        Me.RadMenu1.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        '
        '
        '
        Me.RadMenu1.RootElement.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        Me.RadMenu1.Size = New System.Drawing.Size(1666, 38)
        Me.RadMenu1.TabIndex = 173
        Me.RadMenu1.ThemeName = "Office2010Silver"
        '
        'btnNew
        '
        Me.btnNew.AccessibleDescription = "&New"
        Me.btnNew.AccessibleName = "&New"
        '
        '
        '
        Me.btnNew.ButtonElement.AccessibleDescription = "&New"
        Me.btnNew.ButtonElement.AccessibleName = "&New"
        Me.btnNew.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Image = Global.SPMSOPCI.My.Resources.Resources.if_Plus_1891033
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Text = "&New"
        Me.btnNew.UseCompatibleTextRendering = False
        Me.btnNew.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnEdit
        '
        Me.btnEdit.AccessibleDescription = "&Edit"
        Me.btnEdit.AccessibleName = "&Edit"
        '
        '
        '
        Me.btnEdit.ButtonElement.AccessibleDescription = "&Edit"
        Me.btnEdit.ButtonElement.AccessibleName = "&Edit"
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Image = Global.SPMSOPCI.My.Resources.Resources.if_edit_173002
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.UseCompatibleTextRendering = False
        Me.btnEdit.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnSave
        '
        Me.btnSave.AccessibleDescription = "&Save"
        Me.btnSave.AccessibleName = "&Save"
        '
        '
        '
        Me.btnSave.ButtonElement.AccessibleDescription = "&Save"
        Me.btnSave.ButtonElement.AccessibleName = "&Save"
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.SPMSOPCI.My.Resources.Resources.if_save_173091
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseCompatibleTextRendering = False
        Me.btnSave.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleDescription = "&Delete"
        Me.btnDelete.AccessibleName = "&Delete"
        '
        '
        '
        Me.btnDelete.ButtonElement.AccessibleDescription = "&Delete"
        Me.btnDelete.ButtonElement.AccessibleName = "&Delete"
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = Global.SPMSOPCI.My.Resources.Resources.rubbish
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseCompatibleTextRendering = False
        Me.btnDelete.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnFinddata
        '
        Me.btnFinddata.AccessibleDescription = "&Find"
        Me.btnFinddata.AccessibleName = "&Find"
        '
        '
        '
        Me.btnFinddata.ButtonElement.AccessibleDescription = "&Find"
        Me.btnFinddata.ButtonElement.AccessibleName = "&Find"
        Me.btnFinddata.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinddata.Image = Global.SPMSOPCI.My.Resources.Resources.iconfinder_binocular__spyglass__view__search_2538706
        Me.btnFinddata.Name = "btnFinddata"
        Me.btnFinddata.Text = "&Find"
        Me.btnFinddata.UseCompatibleTextRendering = False
        Me.btnFinddata.Visibility = Telerik.WinControls.ElementVisibility.Visible
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
        'RadLabel10
        '
        Me.RadLabel10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadLabel10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel10.Location = New System.Drawing.Point(37, 333)
        Me.RadLabel10.Name = "RadLabel10"
        Me.RadLabel10.Size = New System.Drawing.Size(180, 19)
        Me.RadLabel10.TabIndex = 892
        Me.RadLabel10.Text = "Product Manager Cycle Period "
        '
        'RadLabel5
        '
        Me.RadLabel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadLabel5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel5.Location = New System.Drawing.Point(37, 229)
        Me.RadLabel5.Name = "RadLabel5"
        Me.RadLabel5.Size = New System.Drawing.Size(88, 19)
        Me.RadLabel5.TabIndex = 891
        Me.RadLabel5.Text = "Configuration "
        '
        'txtConfigCode
        '
        Me.txtConfigCode.AutoSize = False
        Me.txtConfigCode.BackColor = System.Drawing.Color.White
        Me.txtConfigCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConfigCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtConfigCode.Location = New System.Drawing.Point(210, 258)
        Me.txtConfigCode.Multiline = True
        Me.txtConfigCode.Name = "txtConfigCode"
        Me.txtConfigCode.NullText = "Code"
        Me.txtConfigCode.ReadOnly = True
        Me.txtConfigCode.Size = New System.Drawing.Size(236, 26)
        Me.txtConfigCode.TabIndex = 889
        Me.txtConfigCode.TabStop = False
        '
        'txtConfgName
        '
        Me.txtConfgName.AutoSize = False
        Me.txtConfgName.BackColor = System.Drawing.Color.White
        Me.txtConfgName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConfgName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtConfgName.Location = New System.Drawing.Point(210, 288)
        Me.txtConfgName.Multiline = True
        Me.txtConfgName.Name = "txtConfgName"
        Me.txtConfgName.NullText = "Description"
        Me.txtConfgName.ReadOnly = True
        Me.txtConfgName.Size = New System.Drawing.Size(446, 26)
        Me.txtConfgName.TabIndex = 890
        Me.txtConfgName.TabStop = False
        Me.txtConfgName.ThemeName = "Office2019Light"
        '
        'Findconfig
        '
        Me.Findconfig.AutoSize = True
        Me.Findconfig.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Findconfig.Location = New System.Drawing.Point(57, 261)
        Me.Findconfig.Name = "Findconfig"
        Me.Findconfig.Size = New System.Drawing.Size(95, 17)
        Me.Findconfig.TabIndex = 888
        Me.Findconfig.TabStop = True
        Me.Findconfig.Text = "Configuration "
        '
        'dtEffectivityEndDate
        '
        Me.dtEffectivityEndDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtEffectivityEndDate.CalendarSize = New System.Drawing.Size(290, 320)
        Me.dtEffectivityEndDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEffectivityEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEffectivityEndDate.Location = New System.Drawing.Point(210, 389)
        Me.dtEffectivityEndDate.Name = "dtEffectivityEndDate"
        Me.dtEffectivityEndDate.Size = New System.Drawing.Size(168, 21)
        Me.dtEffectivityEndDate.TabIndex = 887
        Me.dtEffectivityEndDate.TabStop = False
        Me.dtEffectivityEndDate.Text = "7/9/2018"
        Me.dtEffectivityEndDate.ThemeName = "Crystal"
        Me.dtEffectivityEndDate.Value = New Date(2018, 7, 9, 0, 0, 0, 0)
        '
        'RadLabel8
        '
        Me.RadLabel8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel8.Location = New System.Drawing.Point(57, 392)
        Me.RadLabel8.Name = "RadLabel8"
        Me.RadLabel8.Size = New System.Drawing.Size(123, 19)
        Me.RadLabel8.TabIndex = 886
        Me.RadLabel8.Text = "Effectivity  End  Date"
        '
        'dtEffectivityStartDate
        '
        Me.dtEffectivityStartDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtEffectivityStartDate.CalendarSize = New System.Drawing.Size(290, 320)
        Me.dtEffectivityStartDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEffectivityStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEffectivityStartDate.Location = New System.Drawing.Point(210, 362)
        Me.dtEffectivityStartDate.Name = "dtEffectivityStartDate"
        Me.dtEffectivityStartDate.Size = New System.Drawing.Size(168, 21)
        Me.dtEffectivityStartDate.TabIndex = 885
        Me.dtEffectivityStartDate.TabStop = False
        Me.dtEffectivityStartDate.Text = "7/9/2018"
        Me.dtEffectivityStartDate.ThemeName = "Crystal"
        Me.dtEffectivityStartDate.Value = New Date(2018, 7, 9, 0, 0, 0, 0)
        '
        'RadLabel7
        '
        Me.RadLabel7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel7.Location = New System.Drawing.Point(57, 367)
        Me.RadLabel7.Name = "RadLabel7"
        Me.RadLabel7.Size = New System.Drawing.Size(125, 19)
        Me.RadLabel7.TabIndex = 884
        Me.RadLabel7.Text = "Effectivity Start Date "
        '
        'chkIsActive
        '
        Me.chkIsActive.CheckAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIsActive.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsActive.Location = New System.Drawing.Point(588, 151)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(67, 19)
        Me.chkIsActive.TabIndex = 898
        Me.chkIsActive.Text = "IsActive"
        Me.chkIsActive.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIsActive.ThemeName = "TelerikMetroBlue"
        '
        'RadLabel6
        '
        Me.RadLabel6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadLabel6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel6.Location = New System.Drawing.Point(37, 127)
        Me.RadLabel6.Name = "RadLabel6"
        Me.RadLabel6.Size = New System.Drawing.Size(106, 19)
        Me.RadLabel6.TabIndex = 897
        Me.RadLabel6.Text = "Entry Information"
        '
        'RadLabel1
        '
        Me.RadLabel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel1.Location = New System.Drawing.Point(57, 193)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(141, 19)
        Me.RadLabel1.TabIndex = 896
        Me.RadLabel1.Text = "Product Manager Name"
        '
        'txtProductManagerName
        '
        Me.txtProductManagerName.AutoSize = False
        Me.txtProductManagerName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtProductManagerName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.txtProductManagerName.Location = New System.Drawing.Point(210, 189)
        Me.txtProductManagerName.Multiline = True
        Me.txtProductManagerName.Name = "txtProductManagerName"
        Me.txtProductManagerName.NullText = "Product Manager Name"
        Me.txtProductManagerName.ReadOnly = True
        Me.txtProductManagerName.Size = New System.Drawing.Size(445, 26)
        Me.txtProductManagerName.TabIndex = 895
        Me.txtProductManagerName.TabStop = False
        Me.txtProductManagerName.ThemeName = "Office2010Blue"
        '
        'RadLabel4
        '
        Me.RadLabel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadLabel4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel4.Location = New System.Drawing.Point(57, 164)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(137, 19)
        Me.RadLabel4.TabIndex = 894
        Me.RadLabel4.Text = "Product Manager Code"
        '
        'txtProductManagerCode
        '
        Me.txtProductManagerCode.AutoSize = False
        Me.txtProductManagerCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtProductManagerCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.txtProductManagerCode.Location = New System.Drawing.Point(210, 160)
        Me.txtProductManagerCode.Multiline = True
        Me.txtProductManagerCode.Name = "txtProductManagerCode"
        Me.txtProductManagerCode.NullText = "Code"
        Me.txtProductManagerCode.ReadOnly = True
        Me.txtProductManagerCode.Size = New System.Drawing.Size(236, 26)
        Me.txtProductManagerCode.TabIndex = 893
        Me.txtProductManagerCode.TabStop = False
        '
        'UIProductManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Controls.Add(Me.chkIsActive)
        Me.Controls.Add(Me.RadLabel6)
        Me.Controls.Add(Me.RadLabel1)
        Me.Controls.Add(Me.txtProductManagerName)
        Me.Controls.Add(Me.RadLabel4)
        Me.Controls.Add(Me.txtProductManagerCode)
        Me.Controls.Add(Me.RadLabel10)
        Me.Controls.Add(Me.RadLabel5)
        Me.Controls.Add(Me.txtConfigCode)
        Me.Controls.Add(Me.txtConfgName)
        Me.Controls.Add(Me.Findconfig)
        Me.Controls.Add(Me.dtEffectivityEndDate)
        Me.Controls.Add(Me.RadLabel8)
        Me.Controls.Add(Me.dtEffectivityStartDate)
        Me.Controls.Add(Me.RadLabel7)
        Me.Controls.Add(Me.RadMenu1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UIProductManager"
        Me.Size = New System.Drawing.Size(1666, 843)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConfigCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConfgName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtEffectivityEndDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtEffectivityStartDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIsActive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductManagerName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductManagerCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents btnNew As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnEdit As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnFinddata As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClear As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents RadLabel10 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtConfigCode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtConfgName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Findconfig As LinkLabel
    Friend WithEvents dtEffectivityEndDate As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents RadLabel8 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents dtEffectivityStartDate As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkIsActive As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtProductManagerName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtProductManagerCode As Telerik.WinControls.UI.RadTextBox
End Class
