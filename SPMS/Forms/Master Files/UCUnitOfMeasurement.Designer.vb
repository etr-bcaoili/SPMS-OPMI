<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCUnitOfMeasurement
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
        Me.btnFinddata = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClear = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClose = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.chkIsActive = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.txtDescription = New Telerik.WinControls.UI.RadTextBox()
        Me.txtCode = New Telerik.WinControls.UI.RadTextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIsActive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(1516, 58)
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
        Me.Label5.Size = New System.Drawing.Size(157, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Unit of Measurement"
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
        Me.RadMenu1.Size = New System.Drawing.Size(1516, 38)
        Me.RadMenu1.TabIndex = 172
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
        'chkIsActive
        '
        Me.chkIsActive.CheckAlignment = System.Drawing.ContentAlignment.TopRight
        Me.chkIsActive.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsActive.Location = New System.Drawing.Point(485, 126)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(67, 19)
        Me.chkIsActive.TabIndex = 755
        Me.chkIsActive.Text = "Is Active"
        Me.chkIsActive.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkIsActive.ThemeName = "Office2019Light"
        Me.chkIsActive.ToggleState = Telerik.WinControls.Enumerations.ToggleState.[On]
        '
        'RadLabel1
        '
        Me.RadLabel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel1.Location = New System.Drawing.Point(39, 178)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(74, 19)
        Me.RadLabel1.TabIndex = 754
        Me.RadLabel1.Text = "Description "
        '
        'RadLabel3
        '
        Me.RadLabel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel3.Location = New System.Drawing.Point(39, 151)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(36, 19)
        Me.RadLabel3.TabIndex = 753
        Me.RadLabel3.Text = "Code"
        '
        'txtDescription
        '
        Me.txtDescription.AutoSize = False
        Me.txtDescription.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDescription.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(130, 175)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(423, 25)
        Me.txtDescription.TabIndex = 752
        Me.txtDescription.TabStop = False
        Me.txtDescription.ThemeName = "Office2019Light"
        '
        'txtCode
        '
        Me.txtCode.AutoSize = False
        Me.txtCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.Location = New System.Drawing.Point(130, 147)
        Me.txtCode.Multiline = True
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(165, 25)
        Me.txtCode.TabIndex = 751
        Me.txtCode.TabStop = False
        Me.txtCode.ThemeName = "Office2019Light"
        '
        'UCUnitOfMeasurement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Controls.Add(Me.chkIsActive)
        Me.Controls.Add(Me.RadLabel1)
        Me.Controls.Add(Me.RadLabel3)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.RadMenu1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UCUnitOfMeasurement"
        Me.Size = New System.Drawing.Size(1516, 834)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIsActive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents chkIsActive As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtDescription As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtCode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Office2019LightTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme

End Class
