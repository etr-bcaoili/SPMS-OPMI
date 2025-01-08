<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIDistributorChannelGroup
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadMenu1 = New Telerik.WinControls.UI.RadMenu()
        Me.btnNew = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnEdit = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnSave = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnDelete = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnFinddata = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClear = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClose = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.chkIsActive = New Telerik.WinControls.UI.RadCheckBox()
        Me.txtChannelGroupDescription = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.txtChannelGroupCode = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.txtChannelDescription = New Telerik.WinControls.UI.RadTextBox()
        Me.txtChannelCode = New Telerik.WinControls.UI.RadTextBox()
        Me.lnkDistributorCode = New System.Windows.Forms.LinkLabel()
        Me.dtTodate = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.dtFromDate = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.RadLabel9 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel10 = New Telerik.WinControls.UI.RadLabel()
        Me.Panel1.SuspendLayout()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIsActive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChannelGroupDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChannelGroupCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChannelDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChannelCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTodate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFromDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(1463, 59)
        Me.Panel1.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(18, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Distributor Channel Group"
        '
        'RadMenu1
        '
        Me.RadMenu1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnNew, Me.btnEdit, Me.btnSave, Me.btnDelete, Me.btnFinddata, Me.btnClear, Me.btnClose})
        Me.RadMenu1.Location = New System.Drawing.Point(0, 59)
        Me.RadMenu1.Name = "RadMenu1"
        Me.RadMenu1.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        Me.RadMenu1.Size = New System.Drawing.Size(1463, 33)
        Me.RadMenu1.TabIndex = 172
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
        'chkIsActive
        '
        Me.chkIsActive.CheckAlignment = System.Drawing.ContentAlignment.TopRight
        Me.chkIsActive.Checked = System.Windows.Forms.CheckState.Checked
        Me.chkIsActive.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsActive.Location = New System.Drawing.Point(628, 124)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(68, 17)
        Me.chkIsActive.TabIndex = 759
        Me.chkIsActive.Text = "Is Active"
        Me.chkIsActive.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkIsActive.ThemeName = "Office2019Light"
        Me.chkIsActive.ToggleState = Telerik.WinControls.Enumerations.ToggleState.[On]
        '
        'txtChannelGroupDescription
        '
        Me.txtChannelGroupDescription.AutoSize = False
        Me.txtChannelGroupDescription.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtChannelGroupDescription.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChannelGroupDescription.Location = New System.Drawing.Point(186, 207)
        Me.txtChannelGroupDescription.Multiline = True
        Me.txtChannelGroupDescription.Name = "txtChannelGroupDescription"
        Me.txtChannelGroupDescription.ReadOnly = True
        Me.txtChannelGroupDescription.Size = New System.Drawing.Size(510, 26)
        Me.txtChannelGroupDescription.TabIndex = 754
        Me.txtChannelGroupDescription.ThemeName = "Office2019Light"
        '
        'RadLabel2
        '
        Me.RadLabel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel2.Location = New System.Drawing.Point(37, 208)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(131, 19)
        Me.RadLabel2.TabIndex = 757
        Me.RadLabel2.Text = "Channel Group Name "
        '
        'txtChannelGroupCode
        '
        Me.txtChannelGroupCode.AutoSize = False
        Me.txtChannelGroupCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtChannelGroupCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChannelGroupCode.Location = New System.Drawing.Point(186, 177)
        Me.txtChannelGroupCode.Multiline = True
        Me.txtChannelGroupCode.Name = "txtChannelGroupCode"
        Me.txtChannelGroupCode.ReadOnly = True
        Me.txtChannelGroupCode.Size = New System.Drawing.Size(510, 26)
        Me.txtChannelGroupCode.TabIndex = 753
        Me.txtChannelGroupCode.ThemeName = "Office2019Light"
        '
        'RadLabel1
        '
        Me.RadLabel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel1.Location = New System.Drawing.Point(37, 179)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(123, 19)
        Me.RadLabel1.TabIndex = 756
        Me.RadLabel1.Text = "Channel Group Code"
        '
        'txtChannelDescription
        '
        Me.txtChannelDescription.AutoSize = False
        Me.txtChannelDescription.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtChannelDescription.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChannelDescription.Location = New System.Drawing.Point(326, 147)
        Me.txtChannelDescription.Multiline = True
        Me.txtChannelDescription.Name = "txtChannelDescription"
        Me.txtChannelDescription.ReadOnly = True
        Me.txtChannelDescription.Size = New System.Drawing.Size(370, 26)
        Me.txtChannelDescription.TabIndex = 752
        Me.txtChannelDescription.ThemeName = "Office2019Light"
        '
        'txtChannelCode
        '
        Me.txtChannelCode.AutoSize = False
        Me.txtChannelCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtChannelCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChannelCode.Location = New System.Drawing.Point(186, 147)
        Me.txtChannelCode.Multiline = True
        Me.txtChannelCode.Name = "txtChannelCode"
        Me.txtChannelCode.ReadOnly = True
        Me.txtChannelCode.Size = New System.Drawing.Size(137, 26)
        Me.txtChannelCode.TabIndex = 751
        Me.txtChannelCode.ThemeName = "Office2019Light"
        '
        'lnkDistributorCode
        '
        Me.lnkDistributorCode.AutoSize = True
        Me.lnkDistributorCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkDistributorCode.Location = New System.Drawing.Point(37, 153)
        Me.lnkDistributorCode.Name = "lnkDistributorCode"
        Me.lnkDistributorCode.Size = New System.Drawing.Size(94, 15)
        Me.lnkDistributorCode.TabIndex = 760
        Me.lnkDistributorCode.TabStop = True
        Me.lnkDistributorCode.Text = "Distributor Code"
        '
        'dtTodate
        '
        Me.dtTodate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtTodate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtTodate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTodate.Location = New System.Drawing.Point(560, 432)
        Me.dtTodate.Name = "dtTodate"
        Me.dtTodate.Size = New System.Drawing.Size(136, 23)
        Me.dtTodate.TabIndex = 764
        Me.dtTodate.TabStop = False
        Me.dtTodate.Text = "7/9/2018"
        Me.dtTodate.ThemeName = "Office2010Blue"
        Me.dtTodate.Value = New Date(2018, 7, 9, 0, 0, 0, 0)
        '
        'dtFromDate
        '
        Me.dtFromDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtFromDate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFromDate.Location = New System.Drawing.Point(560, 406)
        Me.dtFromDate.Name = "dtFromDate"
        Me.dtFromDate.Size = New System.Drawing.Size(136, 23)
        Me.dtFromDate.TabIndex = 763
        Me.dtFromDate.TabStop = False
        Me.dtFromDate.Text = "7/9/2018"
        Me.dtFromDate.ThemeName = "Office2010Blue"
        Me.dtFromDate.Value = New Date(2018, 7, 9, 0, 0, 0, 0)
        '
        'RadLabel9
        '
        Me.RadLabel9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadLabel9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel9.Location = New System.Drawing.Point(428, 435)
        Me.RadLabel9.Name = "RadLabel9"
        Me.RadLabel9.Size = New System.Drawing.Size(116, 19)
        Me.RadLabel9.TabIndex = 762
        Me.RadLabel9.Text = "Effectivity End Date"
        '
        'RadLabel10
        '
        Me.RadLabel10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadLabel10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel10.Location = New System.Drawing.Point(428, 409)
        Me.RadLabel10.Name = "RadLabel10"
        Me.RadLabel10.Size = New System.Drawing.Size(125, 19)
        Me.RadLabel10.TabIndex = 761
        Me.RadLabel10.Text = "Effectivity Start Date "
        '
        'UIDistributorChannelGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.dtTodate)
        Me.Controls.Add(Me.dtFromDate)
        Me.Controls.Add(Me.RadLabel9)
        Me.Controls.Add(Me.RadLabel10)
        Me.Controls.Add(Me.lnkDistributorCode)
        Me.Controls.Add(Me.chkIsActive)
        Me.Controls.Add(Me.txtChannelGroupDescription)
        Me.Controls.Add(Me.RadLabel2)
        Me.Controls.Add(Me.txtChannelGroupCode)
        Me.Controls.Add(Me.RadLabel1)
        Me.Controls.Add(Me.txtChannelDescription)
        Me.Controls.Add(Me.txtChannelCode)
        Me.Controls.Add(Me.RadMenu1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UIDistributorChannelGroup"
        Me.Size = New System.Drawing.Size(1463, 851)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIsActive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChannelGroupDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChannelGroupCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChannelDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChannelCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTodate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFromDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents btnNew As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnEdit As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnFinddata As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClear As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents chkIsActive As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents txtChannelGroupDescription As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtChannelGroupCode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtChannelDescription As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtChannelCode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lnkDistributorCode As System.Windows.Forms.LinkLabel
    Friend WithEvents dtTodate As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents dtFromDate As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents RadLabel9 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel10 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents Office2010SilverTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme

End Class
