<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UISalesManager
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
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadPageView3 = New Telerik.WinControls.UI.RadPageView()
        Me.RadPageViewPage8 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GrdViewPeriodOfTransaction = New Telerik.WinControls.UI.RadGridView()
        Me.RadMenu2 = New Telerik.WinControls.UI.RadMenu()
        Me.btnCheckAll = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnUnCheck = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtDistrictSalesManager = New Telerik.WinControls.UI.RadTextBox()
        Me.IscheckEmail = New System.Windows.Forms.CheckBox()
        Me.txtDistrictCode = New Telerik.WinControls.UI.RadTextBox()
        Me.txtEmailAddress = New Telerik.WinControls.UI.RadTextBox()
        Me.chkIsActive = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.txtConfigCode = New Telerik.WinControls.UI.RadTextBox()
        Me.dtEffectivityStartDate = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.Findconfig = New System.Windows.Forms.LinkLabel()
        Me.RadLabel8 = New Telerik.WinControls.UI.RadLabel()
        Me.dtEffectivityEndDate = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.RadMenu1 = New Telerik.WinControls.UI.RadMenu()
        Me.btnNew = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnEdit = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnSave = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnDelete = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnFinddata = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClear = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClose = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Office2010BlackTheme1 = New Telerik.WinControls.Themes.Office2010BlackTheme()
        Me.Panel2.SuspendLayout()
        CType(Me.RadPageView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageView3.SuspendLayout()
        Me.RadPageViewPage8.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.GrdViewPeriodOfTransaction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrdViewPeriodOfTransaction.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadMenu2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.txtDistrictSalesManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDistrictCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmailAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConfigCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtEffectivityStartDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtEffectivityEndDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.RadPageView3)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 91)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1530, 743)
        Me.Panel2.TabIndex = 175
        '
        'RadPageView3
        '
        Me.RadPageView3.Controls.Add(Me.RadPageViewPage8)
        Me.RadPageView3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadPageView3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadPageView3.Location = New System.Drawing.Point(0, 244)
        Me.RadPageView3.Name = "RadPageView3"
        Me.RadPageView3.SelectedPage = Me.RadPageViewPage8
        Me.RadPageView3.Size = New System.Drawing.Size(1528, 497)
        Me.RadPageView3.TabIndex = 402
        Me.RadPageView3.ThemeName = "Crystal"
        CType(Me.RadPageView3.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.None
        '
        'RadPageViewPage8
        '
        Me.RadPageViewPage8.Controls.Add(Me.Panel4)
        Me.RadPageViewPage8.Controls.Add(Me.RadMenu2)
        Me.RadPageViewPage8.Location = New System.Drawing.Point(10, 38)
        Me.RadPageViewPage8.Name = "RadPageViewPage8"
        Me.RadPageViewPage8.Size = New System.Drawing.Size(1507, 448)
        Me.RadPageViewPage8.Text = "Period of Transaction"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.GrdViewPeriodOfTransaction)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 34)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1507, 414)
        Me.Panel4.TabIndex = 176
        '
        'GrdViewPeriodOfTransaction
        '
        Me.GrdViewPeriodOfTransaction.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GrdViewPeriodOfTransaction.Cursor = System.Windows.Forms.Cursors.Default
        Me.GrdViewPeriodOfTransaction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdViewPeriodOfTransaction.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.GrdViewPeriodOfTransaction.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GrdViewPeriodOfTransaction.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GrdViewPeriodOfTransaction.Location = New System.Drawing.Point(0, 0)
        '
        'GrdViewPeriodOfTransaction
        '
        Me.GrdViewPeriodOfTransaction.MasterTemplate.AllowAddNewRow = False
        Me.GrdViewPeriodOfTransaction.MasterTemplate.AllowDeleteRow = False
        GridViewCheckBoxColumn1.EnableExpressionEditor = False
        GridViewCheckBoxColumn1.HeaderText = "[0]"
        GridViewCheckBoxColumn1.MinWidth = 20
        GridViewCheckBoxColumn1.Name = "column1"
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.HeaderText = "Year"
        GridViewTextBoxColumn1.Name = "column2"
        GridViewTextBoxColumn1.ReadOnly = True
        GridViewTextBoxColumn1.Width = 78
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.HeaderText = "Month"
        GridViewTextBoxColumn2.Name = "column3"
        GridViewTextBoxColumn2.ReadOnly = True
        GridViewTextBoxColumn2.Width = 161
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.HeaderText = "Configtype"
        GridViewTextBoxColumn3.Name = "column4"
        GridViewTextBoxColumn3.ReadOnly = True
        GridViewTextBoxColumn3.Width = 240
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.HeaderText = "District Manager Code"
        GridViewTextBoxColumn4.Name = "column5"
        GridViewTextBoxColumn4.ReadOnly = True
        GridViewTextBoxColumn4.Width = 147
        Me.GrdViewPeriodOfTransaction.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn1, GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4})
        Me.GrdViewPeriodOfTransaction.MasterTemplate.EnableFiltering = True
        Me.GrdViewPeriodOfTransaction.MasterTemplate.EnableGrouping = False
        Me.GrdViewPeriodOfTransaction.Name = "GrdViewPeriodOfTransaction"
        Me.GrdViewPeriodOfTransaction.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GrdViewPeriodOfTransaction.Size = New System.Drawing.Size(1505, 412)
        Me.GrdViewPeriodOfTransaction.TabIndex = 9
        Me.GrdViewPeriodOfTransaction.ThemeName = "Office2010Silver"
        '
        'RadMenu2
        '
        Me.RadMenu2.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnCheckAll, Me.btnUnCheck})
        Me.RadMenu2.Location = New System.Drawing.Point(0, 0)
        Me.RadMenu2.Name = "RadMenu2"
        Me.RadMenu2.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        '
        '
        '
        Me.RadMenu2.RootElement.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        Me.RadMenu2.Size = New System.Drawing.Size(1507, 34)
        Me.RadMenu2.TabIndex = 175
        Me.RadMenu2.ThemeName = "Office2010Silver"
        '
        'btnCheckAll
        '
        Me.btnCheckAll.AccessibleDescription = "&Check All"
        Me.btnCheckAll.AccessibleName = "&Check All"
        '
        '
        '
        Me.btnCheckAll.ButtonElement.AccessibleDescription = "&Check All"
        Me.btnCheckAll.ButtonElement.AccessibleName = "&Check All"
        Me.btnCheckAll.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckAll.Image = Global.SPMSOPCI.My.Resources.Resources.icons8_check_25
        Me.btnCheckAll.Name = "btnCheckAll"
        Me.btnCheckAll.Text = "&Check All"
        Me.btnCheckAll.UseCompatibleTextRendering = False
        Me.btnCheckAll.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnUnCheck
        '
        Me.btnUnCheck.AccessibleDescription = "&Un Check"
        Me.btnUnCheck.AccessibleName = "&Un Check"
        '
        '
        '
        Me.btnUnCheck.ButtonElement.AccessibleDescription = "&Un Check"
        Me.btnUnCheck.ButtonElement.AccessibleName = "&Un Check"
        Me.btnUnCheck.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnCheck.Image = Global.SPMSOPCI.My.Resources.Resources.delete_button
        Me.btnUnCheck.Name = "btnUnCheck"
        Me.btnUnCheck.Text = "&Un Check"
        Me.btnUnCheck.UseCompatibleTextRendering = False
        Me.btnUnCheck.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtDistrictSalesManager)
        Me.Panel3.Controls.Add(Me.IscheckEmail)
        Me.Panel3.Controls.Add(Me.txtDistrictCode)
        Me.Panel3.Controls.Add(Me.txtEmailAddress)
        Me.Panel3.Controls.Add(Me.chkIsActive)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.RadLabel7)
        Me.Panel3.Controls.Add(Me.txtConfigCode)
        Me.Panel3.Controls.Add(Me.dtEffectivityStartDate)
        Me.Panel3.Controls.Add(Me.Findconfig)
        Me.Panel3.Controls.Add(Me.RadLabel8)
        Me.Panel3.Controls.Add(Me.dtEffectivityEndDate)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1528, 244)
        Me.Panel3.TabIndex = 401
        '
        'txtDistrictSalesManager
        '
        Me.txtDistrictSalesManager.AutoSize = False
        Me.txtDistrictSalesManager.BackColor = System.Drawing.Color.White
        Me.txtDistrictSalesManager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDistrictSalesManager.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtDistrictSalesManager.Location = New System.Drawing.Point(379, 57)
        Me.txtDistrictSalesManager.Multiline = True
        Me.txtDistrictSalesManager.Name = "txtDistrictSalesManager"
        Me.txtDistrictSalesManager.ReadOnly = True
        Me.txtDistrictSalesManager.Size = New System.Drawing.Size(309, 25)
        Me.txtDistrictSalesManager.TabIndex = 388
        Me.txtDistrictSalesManager.TabStop = False
        Me.txtDistrictSalesManager.ThemeName = "Office2019Light"
        '
        'IscheckEmail
        '
        Me.IscheckEmail.AutoSize = True
        Me.IscheckEmail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.IscheckEmail.Checked = True
        Me.IscheckEmail.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IscheckEmail.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IscheckEmail.Location = New System.Drawing.Point(608, 130)
        Me.IscheckEmail.Name = "IscheckEmail"
        Me.IscheckEmail.Size = New System.Drawing.Size(76, 19)
        Me.IscheckEmail.TabIndex = 398
        Me.IscheckEmail.Text = "Is-Active "
        Me.IscheckEmail.UseVisualStyleBackColor = True
        '
        'txtDistrictCode
        '
        Me.txtDistrictCode.AutoSize = False
        Me.txtDistrictCode.BackColor = System.Drawing.Color.White
        Me.txtDistrictCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDistrictCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDistrictCode.Location = New System.Drawing.Point(233, 57)
        Me.txtDistrictCode.Multiline = True
        Me.txtDistrictCode.Name = "txtDistrictCode"
        Me.txtDistrictCode.ReadOnly = True
        Me.txtDistrictCode.Size = New System.Drawing.Size(143, 25)
        Me.txtDistrictCode.TabIndex = 387
        Me.txtDistrictCode.TabStop = False
        Me.txtDistrictCode.ThemeName = "Office2019Light"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.AutoSize = False
        Me.txtEmailAddress.BackColor = System.Drawing.Color.White
        Me.txtEmailAddress.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtEmailAddress.Location = New System.Drawing.Point(233, 155)
        Me.txtEmailAddress.Multiline = True
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.ReadOnly = True
        Me.txtEmailAddress.Size = New System.Drawing.Size(455, 25)
        Me.txtEmailAddress.TabIndex = 399
        Me.txtEmailAddress.TabStop = False
        Me.txtEmailAddress.ThemeName = "Office2019Light"
        '
        'chkIsActive
        '
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIsActive.Checked = True
        Me.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsActive.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsActive.Location = New System.Drawing.Point(627, 28)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(59, 19)
        Me.chkIsActive.TabIndex = 389
        Me.chkIsActive.Text = "Active"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(52, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 400
        Me.Label2.Text = "Email Address"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(52, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(160, 15)
        Me.Label4.TabIndex = 390
        Me.Label4.Text = "District Sales Manager Name"
        '
        'RadLabel7
        '
        Me.RadLabel7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel7.Location = New System.Drawing.Point(405, 187)
        Me.RadLabel7.Name = "RadLabel7"
        Me.RadLabel7.Size = New System.Drawing.Size(128, 19)
        Me.RadLabel7.TabIndex = 391
        Me.RadLabel7.Text = "Effectivity Start Date :"
        '
        'txtConfigCode
        '
        Me.txtConfigCode.AutoSize = False
        Me.txtConfigCode.BackColor = System.Drawing.Color.White
        Me.txtConfigCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConfigCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtConfigCode.Location = New System.Drawing.Point(233, 85)
        Me.txtConfigCode.Multiline = True
        Me.txtConfigCode.Name = "txtConfigCode"
        Me.txtConfigCode.ReadOnly = True
        Me.txtConfigCode.Size = New System.Drawing.Size(455, 25)
        Me.txtConfigCode.TabIndex = 396
        Me.txtConfigCode.TabStop = False
        Me.txtConfigCode.ThemeName = "Office2019Light"
        '
        'dtEffectivityStartDate
        '
        Me.dtEffectivityStartDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtEffectivityStartDate.CalendarSize = New System.Drawing.Size(290, 320)
        Me.dtEffectivityStartDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEffectivityStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEffectivityStartDate.Location = New System.Drawing.Point(535, 184)
        Me.dtEffectivityStartDate.Name = "dtEffectivityStartDate"
        Me.dtEffectivityStartDate.Size = New System.Drawing.Size(153, 21)
        Me.dtEffectivityStartDate.TabIndex = 392
        Me.dtEffectivityStartDate.TabStop = False
        Me.dtEffectivityStartDate.Text = "7/9/2018"
        Me.dtEffectivityStartDate.ThemeName = "Crystal"
        Me.dtEffectivityStartDate.Value = New Date(2018, 7, 9, 0, 0, 0, 0)
        '
        'Findconfig
        '
        Me.Findconfig.AutoSize = True
        Me.Findconfig.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Findconfig.Location = New System.Drawing.Point(52, 90)
        Me.Findconfig.Name = "Findconfig"
        Me.Findconfig.Size = New System.Drawing.Size(83, 15)
        Me.Findconfig.TabIndex = 395
        Me.Findconfig.TabStop = True
        Me.Findconfig.Text = "Configuration "
        '
        'RadLabel8
        '
        Me.RadLabel8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel8.Location = New System.Drawing.Point(405, 214)
        Me.RadLabel8.Name = "RadLabel8"
        Me.RadLabel8.Size = New System.Drawing.Size(129, 19)
        Me.RadLabel8.TabIndex = 393
        Me.RadLabel8.Text = "Effectivity  End  Date :"
        '
        'dtEffectivityEndDate
        '
        Me.dtEffectivityEndDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtEffectivityEndDate.CalendarSize = New System.Drawing.Size(290, 320)
        Me.dtEffectivityEndDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEffectivityEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEffectivityEndDate.Location = New System.Drawing.Point(535, 211)
        Me.dtEffectivityEndDate.Name = "dtEffectivityEndDate"
        Me.dtEffectivityEndDate.Size = New System.Drawing.Size(153, 21)
        Me.dtEffectivityEndDate.TabIndex = 394
        Me.dtEffectivityEndDate.TabStop = False
        Me.dtEffectivityEndDate.Text = "7/9/2018"
        Me.dtEffectivityEndDate.ThemeName = "Crystal"
        Me.dtEffectivityEndDate.Value = New Date(2018, 7, 9, 0, 0, 0, 0)
        '
        'RadMenu1
        '
        Me.RadMenu1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnNew, Me.btnEdit, Me.btnSave, Me.btnDelete, Me.btnFinddata, Me.btnClear, Me.btnClose})
        Me.RadMenu1.Location = New System.Drawing.Point(0, 58)
        Me.RadMenu1.Name = "RadMenu1"
        Me.RadMenu1.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        '
        '
        '
        Me.RadMenu1.RootElement.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        Me.RadMenu1.Size = New System.Drawing.Size(1530, 33)
        Me.RadMenu1.TabIndex = 174
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.SPMSOPCI.My.Resources.Resources._12
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1530, 58)
        Me.Panel1.TabIndex = 37
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(22, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(169, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Sales District Manager "
        '
        'UISalesManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.RadMenu1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UISalesManager"
        Me.Size = New System.Drawing.Size(1530, 834)
        Me.Panel2.ResumeLayout(False)
        CType(Me.RadPageView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageView3.ResumeLayout(False)
        Me.RadPageViewPage8.ResumeLayout(False)
        Me.RadPageViewPage8.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.GrdViewPeriodOfTransaction.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrdViewPeriodOfTransaction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadMenu2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.txtDistrictSalesManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDistrictCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmailAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConfigCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtEffectivityStartDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtEffectivityEndDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents btnNew As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnEdit As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnFinddata As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClear As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents IscheckEmail As System.Windows.Forms.CheckBox
    Friend WithEvents txtEmailAddress As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtConfigCode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Findconfig As System.Windows.Forms.LinkLabel
    Friend WithEvents dtEffectivityEndDate As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents RadLabel8 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents dtEffectivityStartDate As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtDistrictSalesManager As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents txtDistrictCode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents RadPageView3 As Telerik.WinControls.UI.RadPageView
    Friend WithEvents RadPageViewPage8 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadMenu2 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents btnCheckAll As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnUnCheck As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents GrdViewPeriodOfTransaction As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Office2010BlackTheme1 As Telerik.WinControls.Themes.Office2010BlackTheme

End Class
