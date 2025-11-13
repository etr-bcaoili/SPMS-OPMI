<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIDistrictGroup
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.chkIsActive = New System.Windows.Forms.CheckBox()
        Me.txtDistrictName = New Telerik.WinControls.UI.RadTextBox()
        Me.txtCode = New Telerik.WinControls.UI.RadTextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDistrictName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(1589, 58)
        Me.Panel1.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 30)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "District Group"
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
        Me.RadMenu1.Size = New System.Drawing.Size(1589, 38)
        Me.RadMenu1.TabIndex = 413
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
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.RadLabel4)
        Me.Panel2.Controls.Add(Me.chkIsActive)
        Me.Panel2.Controls.Add(Me.txtDistrictName)
        Me.Panel2.Controls.Add(Me.txtCode)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 96)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1589, 745)
        Me.Panel2.TabIndex = 414
        '
        'RadLabel4
        '
        Me.RadLabel4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel4.Location = New System.Drawing.Point(53, 62)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(85, 19)
        Me.RadLabel4.TabIndex = 772
        Me.RadLabel4.Text = "District Group"
        '
        'chkIsActive
        '
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIsActive.Checked = True
        Me.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsActive.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsActive.Location = New System.Drawing.Point(547, 34)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(59, 19)
        Me.chkIsActive.TabIndex = 410
        Me.chkIsActive.Text = "Active"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'txtDistrictName
        '
        Me.txtDistrictName.AutoSize = False
        Me.txtDistrictName.BackColor = System.Drawing.Color.White
        Me.txtDistrictName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDistrictName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtDistrictName.Location = New System.Drawing.Point(301, 59)
        Me.txtDistrictName.Multiline = True
        Me.txtDistrictName.Name = "txtDistrictName"
        Me.txtDistrictName.ReadOnly = True
        Me.txtDistrictName.Size = New System.Drawing.Size(309, 25)
        Me.txtDistrictName.TabIndex = 409
        Me.txtDistrictName.TabStop = False
        Me.txtDistrictName.ThemeName = "Office2019Light"
        '
        'txtCode
        '
        Me.txtCode.AutoSize = False
        Me.txtCode.BackColor = System.Drawing.Color.White
        Me.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtCode.Location = New System.Drawing.Point(155, 59)
        Me.txtCode.Multiline = True
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(143, 25)
        Me.txtCode.TabIndex = 408
        Me.txtCode.TabStop = False
        Me.txtCode.ThemeName = "Office2019Light"
        '
        'UIDistrictGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.RadMenu1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UIDistrictGroup"
        Me.Size = New System.Drawing.Size(1589, 841)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDistrictName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents btnNew As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnEdit As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnFinddata As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClear As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtDistrictName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtCode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents chkIsActive As CheckBox
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
End Class
