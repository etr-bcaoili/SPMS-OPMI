<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIDistributors
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
        Me.RadMenu1 = New Telerik.WinControls.UI.RadMenu()
        Me.btnNew = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnEdit = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnSave = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnDelete = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnFind = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClear = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClose = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CheckNetVat = New System.Windows.Forms.CheckBox()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDistributorMargin = New Telerik.WinControls.UI.RadTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMunicipalTax = New Telerik.WinControls.UI.RadTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtTodate = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.dtFromDate = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.RadLabel9 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel10 = New Telerik.WinControls.UI.RadLabel()
        Me.chkIsActive = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtChannelAddress = New Telerik.WinControls.UI.RadTextBox()
        Me.txtChannelDescription = New Telerik.WinControls.UI.RadTextBox()
        Me.txtChannelCode = New Telerik.WinControls.UI.RadTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.txtDistributorMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMunicipalTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTodate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFromDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChannelAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChannelDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChannelCode, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(1445, 58)
        Me.Panel1.TabIndex = 36
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(35, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Channel Entry"
        '
        'RadMenu1
        '
        Me.RadMenu1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnNew, Me.btnEdit, Me.btnSave, Me.btnDelete, Me.btnFind, Me.btnClear, Me.btnClose})
        Me.RadMenu1.Location = New System.Drawing.Point(0, 58)
        Me.RadMenu1.Name = "RadMenu1"
        Me.RadMenu1.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        '
        '
        '
        Me.RadMenu1.RootElement.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        Me.RadMenu1.Size = New System.Drawing.Size(1445, 38)
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
        'btnFind
        '
        Me.btnFind.AccessibleDescription = "&Find"
        Me.btnFind.AccessibleName = "&Find"
        '
        '
        '
        Me.btnFind.ButtonElement.AccessibleDescription = "&Find"
        Me.btnFind.ButtonElement.AccessibleName = "&Find"
        Me.btnFind.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFind.Image = Global.SPMSOPCI.My.Resources.Resources.iconfinder_binocular__spyglass__view__search_2538706
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Text = "&Find"
        Me.btnFind.UseCompatibleTextRendering = False
        Me.btnFind.Visibility = Telerik.WinControls.ElementVisibility.Visible
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
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.CheckNetVat)
        Me.Panel2.Controls.Add(Me.RadGroupBox1)
        Me.Panel2.Controls.Add(Me.dtTodate)
        Me.Panel2.Controls.Add(Me.dtFromDate)
        Me.Panel2.Controls.Add(Me.RadLabel9)
        Me.Panel2.Controls.Add(Me.RadLabel10)
        Me.Panel2.Controls.Add(Me.chkIsActive)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtChannelAddress)
        Me.Panel2.Controls.Add(Me.txtChannelDescription)
        Me.Panel2.Controls.Add(Me.txtChannelCode)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 96)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1445, 762)
        Me.Panel2.TabIndex = 174
        '
        'CheckNetVat
        '
        Me.CheckNetVat.AutoSize = True
        Me.CheckNetVat.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.CheckNetVat.Location = New System.Drawing.Point(572, 342)
        Me.CheckNetVat.Name = "CheckNetVat"
        Me.CheckNetVat.Size = New System.Drawing.Size(79, 19)
        Me.CheckNetVat.TabIndex = 787
        Me.CheckNetVat.Text = "Active Vat"
        Me.CheckNetVat.UseVisualStyleBackColor = True
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Controls.Add(Me.Label7)
        Me.RadGroupBox1.Controls.Add(Me.txtDistributorMargin)
        Me.RadGroupBox1.Controls.Add(Me.Label8)
        Me.RadGroupBox1.Controls.Add(Me.Label6)
        Me.RadGroupBox1.Controls.Add(Me.txtMunicipalTax)
        Me.RadGroupBox1.Controls.Add(Me.Label3)
        Me.RadGroupBox1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.RadGroupBox1.HeaderText = "Net of Vat"
        Me.RadGroupBox1.Location = New System.Drawing.Point(41, 356)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        '
        '
        '
        Me.RadGroupBox1.RootElement.Padding = New System.Windows.Forms.Padding(2, 18, 2, 2)
        Me.RadGroupBox1.Size = New System.Drawing.Size(615, 114)
        Me.RadGroupBox1.TabIndex = 789
        Me.RadGroupBox1.Text = "Net of Vat"
        Me.RadGroupBox1.ThemeName = "Office2010Silver"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(358, 69)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 15)
        Me.Label7.TabIndex = 786
        Me.Label7.Text = "Percentage %"
        '
        'txtDistributorMargin
        '
        Me.txtDistributorMargin.AutoSize = False
        Me.txtDistributorMargin.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDistributorMargin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDistributorMargin.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.txtDistributorMargin.Location = New System.Drawing.Point(159, 64)
        Me.txtDistributorMargin.Multiline = True
        Me.txtDistributorMargin.Name = "txtDistributorMargin"
        Me.txtDistributorMargin.NullText = "0.00"
        Me.txtDistributorMargin.ReadOnly = True
        Me.txtDistributorMargin.Size = New System.Drawing.Size(195, 26)
        Me.txtDistributorMargin.TabIndex = 785
        Me.txtDistributorMargin.TabStop = False
        Me.txtDistributorMargin.ThemeName = "Office2019Light"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 15)
        Me.Label8.TabIndex = 784
        Me.Label8.Text = "Distributor Margin"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(358, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 15)
        Me.Label6.TabIndex = 783
        Me.Label6.Text = "Percentage %"
        '
        'txtMunicipalTax
        '
        Me.txtMunicipalTax.AutoSize = False
        Me.txtMunicipalTax.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtMunicipalTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMunicipalTax.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.txtMunicipalTax.Location = New System.Drawing.Point(159, 35)
        Me.txtMunicipalTax.Multiline = True
        Me.txtMunicipalTax.Name = "txtMunicipalTax"
        Me.txtMunicipalTax.NullText = "0.00"
        Me.txtMunicipalTax.ReadOnly = True
        Me.txtMunicipalTax.Size = New System.Drawing.Size(195, 26)
        Me.txtMunicipalTax.TabIndex = 782
        Me.txtMunicipalTax.TabStop = False
        Me.txtMunicipalTax.ThemeName = "Office2019Light"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 15)
        Me.Label3.TabIndex = 781
        Me.Label3.Text = "Municipal Tax of "
        '
        'dtTodate
        '
        Me.dtTodate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtTodate.CalendarSize = New System.Drawing.Size(290, 320)
        Me.dtTodate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtTodate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTodate.Location = New System.Drawing.Point(200, 271)
        Me.dtTodate.Name = "dtTodate"
        Me.dtTodate.Size = New System.Drawing.Size(136, 23)
        Me.dtTodate.TabIndex = 788
        Me.dtTodate.TabStop = False
        Me.dtTodate.Text = "7/9/2018"
        Me.dtTodate.ThemeName = "Crystal"
        Me.dtTodate.Value = New Date(2018, 7, 9, 0, 0, 0, 0)
        '
        'dtFromDate
        '
        Me.dtFromDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtFromDate.CalendarSize = New System.Drawing.Size(290, 320)
        Me.dtFromDate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFromDate.Location = New System.Drawing.Point(200, 243)
        Me.dtFromDate.Name = "dtFromDate"
        Me.dtFromDate.Size = New System.Drawing.Size(136, 23)
        Me.dtFromDate.TabIndex = 787
        Me.dtFromDate.TabStop = False
        Me.dtFromDate.Text = "7/9/2018"
        Me.dtFromDate.ThemeName = "Crystal"
        Me.dtFromDate.Value = New Date(2018, 7, 9, 0, 0, 0, 0)
        '
        'RadLabel9
        '
        Me.RadLabel9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadLabel9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel9.Location = New System.Drawing.Point(44, 275)
        Me.RadLabel9.Name = "RadLabel9"
        Me.RadLabel9.Size = New System.Drawing.Size(116, 19)
        Me.RadLabel9.TabIndex = 786
        Me.RadLabel9.Text = "Effectivity End Date"
        '
        'RadLabel10
        '
        Me.RadLabel10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadLabel10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel10.Location = New System.Drawing.Point(44, 247)
        Me.RadLabel10.Name = "RadLabel10"
        Me.RadLabel10.Size = New System.Drawing.Size(125, 19)
        Me.RadLabel10.TabIndex = 785
        Me.RadLabel10.Text = "Effectivity Start Date "
        '
        'chkIsActive
        '
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.Checked = True
        Me.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsActive.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.chkIsActive.Location = New System.Drawing.Point(587, 42)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(59, 19)
        Me.chkIsActive.TabIndex = 784
        Me.chkIsActive.Text = "Active"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(38, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 15)
        Me.Label1.TabIndex = 783
        Me.Label1.Text = "Channel Address"
        '
        'txtChannelAddress
        '
        Me.txtChannelAddress.AutoSize = False
        Me.txtChannelAddress.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtChannelAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChannelAddress.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.txtChannelAddress.Location = New System.Drawing.Point(200, 129)
        Me.txtChannelAddress.Multiline = True
        Me.txtChannelAddress.Name = "txtChannelAddress"
        Me.txtChannelAddress.NullText = "Address"
        Me.txtChannelAddress.ReadOnly = True
        Me.txtChannelAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtChannelAddress.Size = New System.Drawing.Size(446, 69)
        Me.txtChannelAddress.TabIndex = 782
        Me.txtChannelAddress.TabStop = False
        Me.txtChannelAddress.ThemeName = "Office2019Light"
        '
        'txtChannelDescription
        '
        Me.txtChannelDescription.AutoSize = False
        Me.txtChannelDescription.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtChannelDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChannelDescription.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.txtChannelDescription.Location = New System.Drawing.Point(200, 83)
        Me.txtChannelDescription.Multiline = True
        Me.txtChannelDescription.Name = "txtChannelDescription"
        Me.txtChannelDescription.NullText = "Description Name"
        Me.txtChannelDescription.ReadOnly = True
        Me.txtChannelDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtChannelDescription.Size = New System.Drawing.Size(446, 43)
        Me.txtChannelDescription.TabIndex = 781
        Me.txtChannelDescription.TabStop = False
        Me.txtChannelDescription.ThemeName = "Office2019Light"
        '
        'txtChannelCode
        '
        Me.txtChannelCode.AutoSize = False
        Me.txtChannelCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtChannelCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChannelCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.txtChannelCode.Location = New System.Drawing.Point(200, 54)
        Me.txtChannelCode.Multiline = True
        Me.txtChannelCode.Name = "txtChannelCode"
        Me.txtChannelCode.NullText = "Code"
        Me.txtChannelCode.ReadOnly = True
        Me.txtChannelCode.Size = New System.Drawing.Size(195, 26)
        Me.txtChannelCode.TabIndex = 780
        Me.txtChannelCode.TabStop = False
        Me.txtChannelCode.ThemeName = "Office2019Light"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(38, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 15)
        Me.Label2.TabIndex = 778
        Me.Label2.Text = "Channel Code"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(38, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 15)
        Me.Label4.TabIndex = 779
        Me.Label4.Text = "Channel Description"
        '
        'UIDistributors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.RadMenu1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UIDistributors"
        Me.Size = New System.Drawing.Size(1445, 858)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.txtDistributorMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMunicipalTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTodate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFromDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChannelAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChannelDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChannelCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents btnNew As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnEdit As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnFind As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClear As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtChannelDescription As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtChannelCode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtTodate As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents dtFromDate As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents RadLabel9 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel10 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkIsActive As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtChannelAddress As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txtMunicipalTax As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CheckNetVat As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDistributorMargin As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
End Class
