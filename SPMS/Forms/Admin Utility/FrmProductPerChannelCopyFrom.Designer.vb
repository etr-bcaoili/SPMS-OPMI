<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductPerChannelCopyFrom
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.lnkMotherCode = New System.Windows.Forms.LinkLabel()
        Me.txtChannelName = New Telerik.WinControls.UI.RadTextBox()
        Me.txtChannelCode = New Telerik.WinControls.UI.RadTextBox()
        Me.Office2019LightTheme1 = New Telerik.WinControls.Themes.Office2010BlueTheme()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadMenu1 = New Telerik.WinControls.UI.RadMenu()
        Me.btnNew = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnClose = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dtToEnd = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.dtToStart = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.dtEndFrom = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.RadLabel8 = New Telerik.WinControls.UI.RadLabel()
        Me.dtStartFrom = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.Panel1.SuspendLayout()
        CType(Me.txtChannelName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChannelCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.dtToEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtToStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtEndFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtStartFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(566, 60)
        Me.Panel1.TabIndex = 55
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(9, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(277, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Product Per Channel Copy From Utility"
        '
        'lnkMotherCode
        '
        Me.lnkMotherCode.AutoSize = True
        Me.lnkMotherCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkMotherCode.Location = New System.Drawing.Point(14, 22)
        Me.lnkMotherCode.Name = "lnkMotherCode"
        Me.lnkMotherCode.Size = New System.Drawing.Size(63, 15)
        Me.lnkMotherCode.TabIndex = 723
        Me.lnkMotherCode.TabStop = True
        Me.lnkMotherCode.Text = "Find Batch"
        '
        'txtChannelName
        '
        Me.txtChannelName.AutoSize = False
        Me.txtChannelName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtChannelName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChannelName.Location = New System.Drawing.Point(223, 16)
        Me.txtChannelName.Multiline = True
        Me.txtChannelName.Name = "txtChannelName"
        Me.txtChannelName.ReadOnly = True
        Me.txtChannelName.Size = New System.Drawing.Size(331, 26)
        Me.txtChannelName.TabIndex = 722
        Me.txtChannelName.TabStop = False
        Me.txtChannelName.ThemeName = "Office2019Light"
        '
        'txtChannelCode
        '
        Me.txtChannelCode.AutoSize = False
        Me.txtChannelCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtChannelCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChannelCode.Location = New System.Drawing.Point(87, 16)
        Me.txtChannelCode.Multiline = True
        Me.txtChannelCode.Name = "txtChannelCode"
        Me.txtChannelCode.ReadOnly = True
        Me.txtChannelCode.Size = New System.Drawing.Size(133, 26)
        Me.txtChannelCode.TabIndex = 721
        Me.txtChannelCode.TabStop = False
        Me.txtChannelCode.ThemeName = "Office2019Light"
        '
        'RadLabel3
        '
        Me.RadLabel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel3.Location = New System.Drawing.Point(221, 60)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(39, 19)
        Me.RadLabel3.TabIndex = 725
        Me.RadLabel3.Text = "From "
        '
        'RadLabel1
        '
        Me.RadLabel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel1.Location = New System.Drawing.Point(400, 60)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(21, 19)
        Me.RadLabel1.TabIndex = 727
        Me.RadLabel1.Text = "To"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RadMenu1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 218)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(566, 32)
        Me.Panel2.TabIndex = 732
        '
        'RadMenu1
        '
        Me.RadMenu1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RadMenu1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnNew, Me.btnClose})
        Me.RadMenu1.Location = New System.Drawing.Point(0, -1)
        Me.RadMenu1.Name = "RadMenu1"
        Me.RadMenu1.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        '
        '
        '
        Me.RadMenu1.RootElement.Padding = New System.Windows.Forms.Padding(2, 2, 0, 0)
        Me.RadMenu1.Size = New System.Drawing.Size(566, 33)
        Me.RadMenu1.TabIndex = 172
        Me.RadMenu1.ThemeName = "Office2010Blue"
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
        Me.btnNew.Image = Global.SPMSOPCI.My.Resources.Resources.file_upload
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Text = "&New"
        Me.btnNew.UseCompatibleTextRendering = False
        Me.btnNew.Visibility = Telerik.WinControls.ElementVisibility.Visible
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
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel3.Controls.Add(Me.dtToEnd)
        Me.Panel3.Controls.Add(Me.dtToStart)
        Me.Panel3.Controls.Add(Me.dtEndFrom)
        Me.Panel3.Controls.Add(Me.RadLabel8)
        Me.Panel3.Controls.Add(Me.dtStartFrom)
        Me.Panel3.Controls.Add(Me.RadLabel7)
        Me.Panel3.Controls.Add(Me.txtChannelCode)
        Me.Panel3.Controls.Add(Me.txtChannelName)
        Me.Panel3.Controls.Add(Me.lnkMotherCode)
        Me.Panel3.Controls.Add(Me.RadLabel3)
        Me.Panel3.Controls.Add(Me.RadLabel1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 60)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(566, 158)
        Me.Panel3.TabIndex = 733
        '
        'dtToEnd
        '
        Me.dtToEnd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtToEnd.CalendarSize = New System.Drawing.Size(290, 320)
        Me.dtToEnd.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtToEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtToEnd.Location = New System.Drawing.Point(400, 111)
        Me.dtToEnd.Name = "dtToEnd"
        Me.dtToEnd.Size = New System.Drawing.Size(153, 21)
        Me.dtToEnd.TabIndex = 737
        Me.dtToEnd.TabStop = False
        Me.dtToEnd.Text = "2/2/2024"
        Me.dtToEnd.ThemeName = "Crystal"
        Me.dtToEnd.Value = New Date(2024, 2, 2, 9, 7, 0, 0)
        '
        'dtToStart
        '
        Me.dtToStart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtToStart.CalendarSize = New System.Drawing.Size(290, 320)
        Me.dtToStart.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtToStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtToStart.Location = New System.Drawing.Point(400, 84)
        Me.dtToStart.Name = "dtToStart"
        Me.dtToStart.Size = New System.Drawing.Size(153, 21)
        Me.dtToStart.TabIndex = 736
        Me.dtToStart.TabStop = False
        Me.dtToStart.Text = "2/2/2024"
        Me.dtToStart.ThemeName = "Crystal"
        Me.dtToStart.Value = New Date(2024, 2, 2, 9, 7, 0, 0)
        '
        'dtEndFrom
        '
        Me.dtEndFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtEndFrom.CalendarSize = New System.Drawing.Size(290, 320)
        Me.dtEndFrom.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEndFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEndFrom.Location = New System.Drawing.Point(220, 112)
        Me.dtEndFrom.Name = "dtEndFrom"
        Me.dtEndFrom.Size = New System.Drawing.Size(153, 21)
        Me.dtEndFrom.TabIndex = 735
        Me.dtEndFrom.TabStop = False
        Me.dtEndFrom.Text = "2/2/2024"
        Me.dtEndFrom.ThemeName = "Crystal"
        Me.dtEndFrom.Value = New Date(2024, 2, 2, 9, 7, 0, 0)
        '
        'RadLabel8
        '
        Me.RadLabel8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel8.Location = New System.Drawing.Point(81, 115)
        Me.RadLabel8.Name = "RadLabel8"
        Me.RadLabel8.Size = New System.Drawing.Size(129, 19)
        Me.RadLabel8.TabIndex = 734
        Me.RadLabel8.Text = "Effectivity  End  Date :"
        '
        'dtStartFrom
        '
        Me.dtStartFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtStartFrom.CalendarSize = New System.Drawing.Size(290, 320)
        Me.dtStartFrom.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStartFrom.Location = New System.Drawing.Point(220, 85)
        Me.dtStartFrom.Name = "dtStartFrom"
        Me.dtStartFrom.Size = New System.Drawing.Size(153, 21)
        Me.dtStartFrom.TabIndex = 733
        Me.dtStartFrom.TabStop = False
        Me.dtStartFrom.Text = "2/2/2024"
        Me.dtStartFrom.ThemeName = "Crystal"
        Me.dtStartFrom.Value = New Date(2024, 2, 2, 9, 7, 0, 0)
        '
        'RadLabel7
        '
        Me.RadLabel7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel7.Location = New System.Drawing.Point(81, 88)
        Me.RadLabel7.Name = "RadLabel7"
        Me.RadLabel7.Size = New System.Drawing.Size(128, 19)
        Me.RadLabel7.TabIndex = 732
        Me.RadLabel7.Text = "Effectivity Start Date :"
        '
        'FrmProductPerChannelCopyFrom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(566, 250)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmProductPerChannelCopyFrom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product Per Channel Copy From"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtChannelName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChannelCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dtToEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtToStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtEndFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtStartFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lnkMotherCode As System.Windows.Forms.LinkLabel
    Friend WithEvents txtChannelName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtChannelCode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Office2019LightTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents btnNew As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents dtToEnd As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents dtToStart As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents dtEndFrom As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents RadLabel8 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents dtStartFrom As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
End Class
