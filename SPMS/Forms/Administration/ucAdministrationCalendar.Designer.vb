<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAdministrationCalendar
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
        Me.MainTab = New System.Windows.Forms.TabControl()
        Me.tbEntry = New System.Windows.Forms.TabPage()
        Me.dtEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtStart = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbyear = New System.Windows.Forms.ComboBox()
        Me.cmbcompany = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblGroupCode = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmb12 = New System.Windows.Forms.ComboBox()
        Me.cmb11 = New System.Windows.Forms.ComboBox()
        Me.cmb10 = New System.Windows.Forms.ComboBox()
        Me.cmb9 = New System.Windows.Forms.ComboBox()
        Me.cmb8 = New System.Windows.Forms.ComboBox()
        Me.cmb7 = New System.Windows.Forms.ComboBox()
        Me.cmb6 = New System.Windows.Forms.ComboBox()
        Me.cmb5 = New System.Windows.Forms.ComboBox()
        Me.cmb4 = New System.Windows.Forms.ComboBox()
        Me.cmb3 = New System.Windows.Forms.ComboBox()
        Me.cmb2 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmb1 = New System.Windows.Forms.ComboBox()
        Me.txt12 = New System.Windows.Forms.Label()
        Me.txt11 = New System.Windows.Forms.Label()
        Me.txt10 = New System.Windows.Forms.Label()
        Me.txt9 = New System.Windows.Forms.Label()
        Me.txt8 = New System.Windows.Forms.Label()
        Me.txt7 = New System.Windows.Forms.Label()
        Me.txt6 = New System.Windows.Forms.Label()
        Me.txt5 = New System.Windows.Forms.Label()
        Me.txt4 = New System.Windows.Forms.Label()
        Me.txt3 = New System.Windows.Forms.Label()
        Me.txt2 = New System.Windows.Forms.Label()
        Me.txt1 = New System.Windows.Forms.Label()
        Me.de12 = New System.Windows.Forms.DateTimePicker()
        Me.dt12 = New System.Windows.Forms.DateTimePicker()
        Me.de11 = New System.Windows.Forms.DateTimePicker()
        Me.dt11 = New System.Windows.Forms.DateTimePicker()
        Me.de10 = New System.Windows.Forms.DateTimePicker()
        Me.dt10 = New System.Windows.Forms.DateTimePicker()
        Me.de9 = New System.Windows.Forms.DateTimePicker()
        Me.dt9 = New System.Windows.Forms.DateTimePicker()
        Me.de8 = New System.Windows.Forms.DateTimePicker()
        Me.dt8 = New System.Windows.Forms.DateTimePicker()
        Me.de7 = New System.Windows.Forms.DateTimePicker()
        Me.dt7 = New System.Windows.Forms.DateTimePicker()
        Me.de6 = New System.Windows.Forms.DateTimePicker()
        Me.dt6 = New System.Windows.Forms.DateTimePicker()
        Me.de5 = New System.Windows.Forms.DateTimePicker()
        Me.dt5 = New System.Windows.Forms.DateTimePicker()
        Me.de4 = New System.Windows.Forms.DateTimePicker()
        Me.dt4 = New System.Windows.Forms.DateTimePicker()
        Me.de3 = New System.Windows.Forms.DateTimePicker()
        Me.dt3 = New System.Windows.Forms.DateTimePicker()
        Me.de2 = New System.Windows.Forms.DateTimePicker()
        Me.dt2 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.de1 = New System.Windows.Forms.DateTimePicker()
        Me.dt1 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbListing = New System.Windows.Forms.TabPage()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.cmbfilter = New System.Windows.Forms.ComboBox()
        Me.lblSelection = New System.Windows.Forms.Label()
        Me.GridListing = New System.Windows.Forms.DataGridView()
        Me.colYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCompany = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStartDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEndDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MainTab.SuspendLayout()
        Me.tbEntry.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbListing.SuspendLayout()
        CType(Me.GridListing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTab
        '
        Me.MainTab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainTab.Controls.Add(Me.tbEntry)
        Me.MainTab.Controls.Add(Me.tbListing)
        Me.MainTab.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainTab.Location = New System.Drawing.Point(3, 87)
        Me.MainTab.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainTab.Name = "MainTab"
        Me.MainTab.SelectedIndex = 0
        Me.MainTab.Size = New System.Drawing.Size(710, 551)
        Me.MainTab.TabIndex = 8
        '
        'tbEntry
        '
        Me.tbEntry.BackColor = System.Drawing.Color.White
        Me.tbEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbEntry.Controls.Add(Me.dtEnd)
        Me.tbEntry.Controls.Add(Me.dtStart)
        Me.tbEntry.Controls.Add(Me.Label8)
        Me.tbEntry.Controls.Add(Me.Label11)
        Me.tbEntry.Controls.Add(Me.GroupBox2)
        Me.tbEntry.Controls.Add(Me.GroupBox1)
        Me.tbEntry.Location = New System.Drawing.Point(4, 23)
        Me.tbEntry.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbEntry.Name = "tbEntry"
        Me.tbEntry.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbEntry.Size = New System.Drawing.Size(702, 524)
        Me.tbEntry.TabIndex = 0
        Me.tbEntry.Text = "Entry"
        '
        'dtEnd
        '
        Me.dtEnd.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEnd.Location = New System.Drawing.Point(185, 467)
        Me.dtEnd.Name = "dtEnd"
        Me.dtEnd.Size = New System.Drawing.Size(91, 20)
        Me.dtEnd.TabIndex = 86
        Me.dtEnd.Visible = False
        '
        'dtStart
        '
        Me.dtStart.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStart.Location = New System.Drawing.Point(185, 437)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(91, 20)
        Me.dtStart.TabIndex = 85
        Me.dtStart.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(51, 470)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 13)
        Me.Label8.TabIndex = 84
        Me.Label8.Text = "Effectivity End Date :"
        Me.Label8.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(51, 444)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 13)
        Me.Label11.TabIndex = 83
        Me.Label11.Text = "Effectivity Start Date :"
        Me.Label11.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbyear)
        Me.GroupBox2.Controls.Add(Me.cmbcompany)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblGroupCode)
        Me.GroupBox2.Location = New System.Drawing.Point(27, 17)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(498, 55)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        '
        'cmbyear
        '
        Me.cmbyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbyear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbyear.FormattingEnabled = True
        Me.cmbyear.Location = New System.Drawing.Point(289, 20)
        Me.cmbyear.Name = "cmbyear"
        Me.cmbyear.Size = New System.Drawing.Size(56, 21)
        Me.cmbyear.TabIndex = 26
        '
        'cmbcompany
        '
        Me.cmbcompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcompany.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcompany.FormattingEnabled = True
        Me.cmbcompany.Location = New System.Drawing.Point(108, 20)
        Me.cmbcompany.Name = "cmbcompany"
        Me.cmbcompany.Size = New System.Drawing.Size(93, 21)
        Me.cmbcompany.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(246, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Year :"
        '
        'lblGroupCode
        '
        Me.lblGroupCode.AutoSize = True
        Me.lblGroupCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupCode.Location = New System.Drawing.Point(24, 28)
        Me.lblGroupCode.Name = "lblGroupCode"
        Me.lblGroupCode.Size = New System.Drawing.Size(56, 13)
        Me.lblGroupCode.TabIndex = 24
        Me.lblGroupCode.Text = "Channel :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmb12)
        Me.GroupBox1.Controls.Add(Me.cmb11)
        Me.GroupBox1.Controls.Add(Me.cmb10)
        Me.GroupBox1.Controls.Add(Me.cmb9)
        Me.GroupBox1.Controls.Add(Me.cmb8)
        Me.GroupBox1.Controls.Add(Me.cmb7)
        Me.GroupBox1.Controls.Add(Me.cmb6)
        Me.GroupBox1.Controls.Add(Me.cmb5)
        Me.GroupBox1.Controls.Add(Me.cmb4)
        Me.GroupBox1.Controls.Add(Me.cmb3)
        Me.GroupBox1.Controls.Add(Me.cmb2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmb1)
        Me.GroupBox1.Controls.Add(Me.txt12)
        Me.GroupBox1.Controls.Add(Me.txt11)
        Me.GroupBox1.Controls.Add(Me.txt10)
        Me.GroupBox1.Controls.Add(Me.txt9)
        Me.GroupBox1.Controls.Add(Me.txt8)
        Me.GroupBox1.Controls.Add(Me.txt7)
        Me.GroupBox1.Controls.Add(Me.txt6)
        Me.GroupBox1.Controls.Add(Me.txt5)
        Me.GroupBox1.Controls.Add(Me.txt4)
        Me.GroupBox1.Controls.Add(Me.txt3)
        Me.GroupBox1.Controls.Add(Me.txt2)
        Me.GroupBox1.Controls.Add(Me.txt1)
        Me.GroupBox1.Controls.Add(Me.de12)
        Me.GroupBox1.Controls.Add(Me.dt12)
        Me.GroupBox1.Controls.Add(Me.de11)
        Me.GroupBox1.Controls.Add(Me.dt11)
        Me.GroupBox1.Controls.Add(Me.de10)
        Me.GroupBox1.Controls.Add(Me.dt10)
        Me.GroupBox1.Controls.Add(Me.de9)
        Me.GroupBox1.Controls.Add(Me.dt9)
        Me.GroupBox1.Controls.Add(Me.de8)
        Me.GroupBox1.Controls.Add(Me.dt8)
        Me.GroupBox1.Controls.Add(Me.de7)
        Me.GroupBox1.Controls.Add(Me.dt7)
        Me.GroupBox1.Controls.Add(Me.de6)
        Me.GroupBox1.Controls.Add(Me.dt6)
        Me.GroupBox1.Controls.Add(Me.de5)
        Me.GroupBox1.Controls.Add(Me.dt5)
        Me.GroupBox1.Controls.Add(Me.de4)
        Me.GroupBox1.Controls.Add(Me.dt4)
        Me.GroupBox1.Controls.Add(Me.de3)
        Me.GroupBox1.Controls.Add(Me.dt3)
        Me.GroupBox1.Controls.Add(Me.de2)
        Me.GroupBox1.Controls.Add(Me.dt2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.de1)
        Me.GroupBox1.Controls.Add(Me.dt1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(498, 341)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'cmb12
        '
        Me.cmb12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb12.FormattingEnabled = True
        Me.cmb12.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmb12.Location = New System.Drawing.Point(94, 308)
        Me.cmb12.Name = "cmb12"
        Me.cmb12.Size = New System.Drawing.Size(129, 21)
        Me.cmb12.TabIndex = 188
        '
        'cmb11
        '
        Me.cmb11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb11.FormattingEnabled = True
        Me.cmb11.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmb11.Location = New System.Drawing.Point(94, 282)
        Me.cmb11.Name = "cmb11"
        Me.cmb11.Size = New System.Drawing.Size(129, 21)
        Me.cmb11.TabIndex = 187
        '
        'cmb10
        '
        Me.cmb10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb10.FormattingEnabled = True
        Me.cmb10.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmb10.Location = New System.Drawing.Point(94, 257)
        Me.cmb10.Name = "cmb10"
        Me.cmb10.Size = New System.Drawing.Size(129, 21)
        Me.cmb10.TabIndex = 186
        '
        'cmb9
        '
        Me.cmb9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb9.FormattingEnabled = True
        Me.cmb9.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmb9.Location = New System.Drawing.Point(94, 231)
        Me.cmb9.Name = "cmb9"
        Me.cmb9.Size = New System.Drawing.Size(129, 21)
        Me.cmb9.TabIndex = 185
        '
        'cmb8
        '
        Me.cmb8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb8.FormattingEnabled = True
        Me.cmb8.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmb8.Location = New System.Drawing.Point(94, 205)
        Me.cmb8.Name = "cmb8"
        Me.cmb8.Size = New System.Drawing.Size(129, 21)
        Me.cmb8.TabIndex = 184
        '
        'cmb7
        '
        Me.cmb7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb7.FormattingEnabled = True
        Me.cmb7.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmb7.Location = New System.Drawing.Point(94, 178)
        Me.cmb7.Name = "cmb7"
        Me.cmb7.Size = New System.Drawing.Size(129, 21)
        Me.cmb7.TabIndex = 183
        '
        'cmb6
        '
        Me.cmb6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb6.FormattingEnabled = True
        Me.cmb6.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmb6.Location = New System.Drawing.Point(94, 152)
        Me.cmb6.Name = "cmb6"
        Me.cmb6.Size = New System.Drawing.Size(129, 21)
        Me.cmb6.TabIndex = 182
        '
        'cmb5
        '
        Me.cmb5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb5.FormattingEnabled = True
        Me.cmb5.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmb5.Location = New System.Drawing.Point(94, 127)
        Me.cmb5.Name = "cmb5"
        Me.cmb5.Size = New System.Drawing.Size(129, 21)
        Me.cmb5.TabIndex = 181
        '
        'cmb4
        '
        Me.cmb4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb4.FormattingEnabled = True
        Me.cmb4.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmb4.Location = New System.Drawing.Point(94, 100)
        Me.cmb4.Name = "cmb4"
        Me.cmb4.Size = New System.Drawing.Size(129, 21)
        Me.cmb4.TabIndex = 180
        '
        'cmb3
        '
        Me.cmb3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb3.FormattingEnabled = True
        Me.cmb3.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmb3.Location = New System.Drawing.Point(94, 74)
        Me.cmb3.Name = "cmb3"
        Me.cmb3.Size = New System.Drawing.Size(129, 21)
        Me.cmb3.TabIndex = 179
        '
        'cmb2
        '
        Me.cmb2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb2.FormattingEnabled = True
        Me.cmb2.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmb2.Location = New System.Drawing.Point(94, 50)
        Me.cmb2.Name = "cmb2"
        Me.cmb2.Size = New System.Drawing.Size(129, 21)
        Me.cmb2.TabIndex = 178
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(105, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 177
        Me.Label6.Text = "Month Description :"
        '
        'cmb1
        '
        Me.cmb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb1.FormattingEnabled = True
        Me.cmb1.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmb1.Location = New System.Drawing.Point(94, 24)
        Me.cmb1.Name = "cmb1"
        Me.cmb1.Size = New System.Drawing.Size(129, 21)
        Me.cmb1.TabIndex = 176
        '
        'txt12
        '
        Me.txt12.AutoSize = True
        Me.txt12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt12.Location = New System.Drawing.Point(34, 314)
        Me.txt12.Name = "txt12"
        Me.txt12.Size = New System.Drawing.Size(19, 13)
        Me.txt12.TabIndex = 175
        Me.txt12.Text = "12"
        '
        'txt11
        '
        Me.txt11.AutoSize = True
        Me.txt11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt11.Location = New System.Drawing.Point(34, 289)
        Me.txt11.Name = "txt11"
        Me.txt11.Size = New System.Drawing.Size(19, 13)
        Me.txt11.TabIndex = 174
        Me.txt11.Text = "11"
        '
        'txt10
        '
        Me.txt10.AutoSize = True
        Me.txt10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt10.Location = New System.Drawing.Point(34, 263)
        Me.txt10.Name = "txt10"
        Me.txt10.Size = New System.Drawing.Size(19, 13)
        Me.txt10.TabIndex = 173
        Me.txt10.Text = "10"
        '
        'txt9
        '
        Me.txt9.AutoSize = True
        Me.txt9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt9.Location = New System.Drawing.Point(34, 237)
        Me.txt9.Name = "txt9"
        Me.txt9.Size = New System.Drawing.Size(19, 13)
        Me.txt9.TabIndex = 172
        Me.txt9.Text = "09"
        '
        'txt8
        '
        Me.txt8.AutoSize = True
        Me.txt8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt8.Location = New System.Drawing.Point(34, 211)
        Me.txt8.Name = "txt8"
        Me.txt8.Size = New System.Drawing.Size(19, 13)
        Me.txt8.TabIndex = 171
        Me.txt8.Text = "08"
        '
        'txt7
        '
        Me.txt7.AutoSize = True
        Me.txt7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt7.Location = New System.Drawing.Point(34, 185)
        Me.txt7.Name = "txt7"
        Me.txt7.Size = New System.Drawing.Size(19, 13)
        Me.txt7.TabIndex = 170
        Me.txt7.Text = "07"
        '
        'txt6
        '
        Me.txt6.AutoSize = True
        Me.txt6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt6.Location = New System.Drawing.Point(34, 158)
        Me.txt6.Name = "txt6"
        Me.txt6.Size = New System.Drawing.Size(19, 13)
        Me.txt6.TabIndex = 169
        Me.txt6.Text = "06"
        '
        'txt5
        '
        Me.txt5.AutoSize = True
        Me.txt5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt5.Location = New System.Drawing.Point(34, 132)
        Me.txt5.Name = "txt5"
        Me.txt5.Size = New System.Drawing.Size(19, 13)
        Me.txt5.TabIndex = 168
        Me.txt5.Text = "05"
        '
        'txt4
        '
        Me.txt4.AutoSize = True
        Me.txt4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt4.Location = New System.Drawing.Point(34, 107)
        Me.txt4.Name = "txt4"
        Me.txt4.Size = New System.Drawing.Size(19, 13)
        Me.txt4.TabIndex = 167
        Me.txt4.Text = "04"
        '
        'txt3
        '
        Me.txt3.AutoSize = True
        Me.txt3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt3.Location = New System.Drawing.Point(34, 80)
        Me.txt3.Name = "txt3"
        Me.txt3.Size = New System.Drawing.Size(19, 13)
        Me.txt3.TabIndex = 166
        Me.txt3.Text = "03"
        '
        'txt2
        '
        Me.txt2.AutoSize = True
        Me.txt2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt2.Location = New System.Drawing.Point(34, 51)
        Me.txt2.Name = "txt2"
        Me.txt2.Size = New System.Drawing.Size(19, 13)
        Me.txt2.TabIndex = 165
        Me.txt2.Text = "02"
        '
        'txt1
        '
        Me.txt1.AutoSize = True
        Me.txt1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt1.Location = New System.Drawing.Point(34, 28)
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(19, 13)
        Me.txt1.TabIndex = 164
        Me.txt1.Text = "01"
        '
        'de12
        '
        Me.de12.CalendarMonthBackground = System.Drawing.Color.White
        Me.de12.CalendarTitleBackColor = System.Drawing.Color.White
        Me.de12.CalendarTitleForeColor = System.Drawing.Color.White
        Me.de12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.de12.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.de12.Location = New System.Drawing.Point(367, 308)
        Me.de12.Name = "de12"
        Me.de12.Size = New System.Drawing.Size(97, 22)
        Me.de12.TabIndex = 163
        '
        'dt12
        '
        Me.dt12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt12.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt12.Location = New System.Drawing.Point(249, 309)
        Me.dt12.Name = "dt12"
        Me.dt12.Size = New System.Drawing.Size(96, 22)
        Me.dt12.TabIndex = 162
        '
        'de11
        '
        Me.de11.CalendarMonthBackground = System.Drawing.Color.White
        Me.de11.CalendarTitleBackColor = System.Drawing.Color.White
        Me.de11.CalendarTitleForeColor = System.Drawing.Color.White
        Me.de11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.de11.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.de11.Location = New System.Drawing.Point(367, 282)
        Me.de11.Name = "de11"
        Me.de11.Size = New System.Drawing.Size(97, 22)
        Me.de11.TabIndex = 158
        '
        'dt11
        '
        Me.dt11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt11.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt11.Location = New System.Drawing.Point(249, 283)
        Me.dt11.Name = "dt11"
        Me.dt11.Size = New System.Drawing.Size(96, 22)
        Me.dt11.TabIndex = 157
        '
        'de10
        '
        Me.de10.CalendarMonthBackground = System.Drawing.Color.White
        Me.de10.CalendarTitleBackColor = System.Drawing.Color.White
        Me.de10.CalendarTitleForeColor = System.Drawing.Color.White
        Me.de10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.de10.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.de10.Location = New System.Drawing.Point(367, 256)
        Me.de10.Name = "de10"
        Me.de10.Size = New System.Drawing.Size(97, 22)
        Me.de10.TabIndex = 153
        '
        'dt10
        '
        Me.dt10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt10.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt10.Location = New System.Drawing.Point(249, 257)
        Me.dt10.Name = "dt10"
        Me.dt10.Size = New System.Drawing.Size(96, 22)
        Me.dt10.TabIndex = 152
        '
        'de9
        '
        Me.de9.CalendarMonthBackground = System.Drawing.Color.White
        Me.de9.CalendarTitleBackColor = System.Drawing.Color.White
        Me.de9.CalendarTitleForeColor = System.Drawing.Color.White
        Me.de9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.de9.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.de9.Location = New System.Drawing.Point(367, 230)
        Me.de9.Name = "de9"
        Me.de9.Size = New System.Drawing.Size(97, 22)
        Me.de9.TabIndex = 148
        '
        'dt9
        '
        Me.dt9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt9.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt9.Location = New System.Drawing.Point(249, 231)
        Me.dt9.Name = "dt9"
        Me.dt9.Size = New System.Drawing.Size(96, 22)
        Me.dt9.TabIndex = 147
        '
        'de8
        '
        Me.de8.CalendarMonthBackground = System.Drawing.Color.White
        Me.de8.CalendarTitleBackColor = System.Drawing.Color.White
        Me.de8.CalendarTitleForeColor = System.Drawing.Color.White
        Me.de8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.de8.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.de8.Location = New System.Drawing.Point(367, 204)
        Me.de8.Name = "de8"
        Me.de8.Size = New System.Drawing.Size(97, 22)
        Me.de8.TabIndex = 143
        '
        'dt8
        '
        Me.dt8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt8.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt8.Location = New System.Drawing.Point(249, 205)
        Me.dt8.Name = "dt8"
        Me.dt8.Size = New System.Drawing.Size(96, 22)
        Me.dt8.TabIndex = 142
        '
        'de7
        '
        Me.de7.CalendarMonthBackground = System.Drawing.Color.White
        Me.de7.CalendarTitleBackColor = System.Drawing.Color.White
        Me.de7.CalendarTitleForeColor = System.Drawing.Color.White
        Me.de7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.de7.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.de7.Location = New System.Drawing.Point(367, 178)
        Me.de7.Name = "de7"
        Me.de7.Size = New System.Drawing.Size(97, 22)
        Me.de7.TabIndex = 138
        '
        'dt7
        '
        Me.dt7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt7.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt7.Location = New System.Drawing.Point(249, 179)
        Me.dt7.Name = "dt7"
        Me.dt7.Size = New System.Drawing.Size(96, 22)
        Me.dt7.TabIndex = 137
        '
        'de6
        '
        Me.de6.CalendarMonthBackground = System.Drawing.Color.White
        Me.de6.CalendarTitleBackColor = System.Drawing.Color.White
        Me.de6.CalendarTitleForeColor = System.Drawing.Color.White
        Me.de6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.de6.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.de6.Location = New System.Drawing.Point(367, 152)
        Me.de6.Name = "de6"
        Me.de6.Size = New System.Drawing.Size(97, 22)
        Me.de6.TabIndex = 133
        '
        'dt6
        '
        Me.dt6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt6.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt6.Location = New System.Drawing.Point(249, 153)
        Me.dt6.Name = "dt6"
        Me.dt6.Size = New System.Drawing.Size(96, 22)
        Me.dt6.TabIndex = 132
        '
        'de5
        '
        Me.de5.CalendarMonthBackground = System.Drawing.Color.White
        Me.de5.CalendarTitleBackColor = System.Drawing.Color.White
        Me.de5.CalendarTitleForeColor = System.Drawing.Color.White
        Me.de5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.de5.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.de5.Location = New System.Drawing.Point(367, 126)
        Me.de5.Name = "de5"
        Me.de5.Size = New System.Drawing.Size(97, 22)
        Me.de5.TabIndex = 128
        '
        'dt5
        '
        Me.dt5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt5.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt5.Location = New System.Drawing.Point(249, 127)
        Me.dt5.Name = "dt5"
        Me.dt5.Size = New System.Drawing.Size(96, 22)
        Me.dt5.TabIndex = 127
        '
        'de4
        '
        Me.de4.CalendarMonthBackground = System.Drawing.Color.White
        Me.de4.CalendarTitleBackColor = System.Drawing.Color.White
        Me.de4.CalendarTitleForeColor = System.Drawing.Color.White
        Me.de4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.de4.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.de4.Location = New System.Drawing.Point(367, 100)
        Me.de4.Name = "de4"
        Me.de4.Size = New System.Drawing.Size(97, 22)
        Me.de4.TabIndex = 123
        '
        'dt4
        '
        Me.dt4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt4.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt4.Location = New System.Drawing.Point(249, 101)
        Me.dt4.Name = "dt4"
        Me.dt4.Size = New System.Drawing.Size(96, 22)
        Me.dt4.TabIndex = 122
        '
        'de3
        '
        Me.de3.CalendarMonthBackground = System.Drawing.Color.White
        Me.de3.CalendarTitleBackColor = System.Drawing.Color.White
        Me.de3.CalendarTitleForeColor = System.Drawing.Color.White
        Me.de3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.de3.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.de3.Location = New System.Drawing.Point(367, 74)
        Me.de3.Name = "de3"
        Me.de3.Size = New System.Drawing.Size(97, 22)
        Me.de3.TabIndex = 118
        '
        'dt3
        '
        Me.dt3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt3.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt3.Location = New System.Drawing.Point(249, 75)
        Me.dt3.Name = "dt3"
        Me.dt3.Size = New System.Drawing.Size(96, 22)
        Me.dt3.TabIndex = 117
        '
        'de2
        '
        Me.de2.CalendarMonthBackground = System.Drawing.Color.White
        Me.de2.CalendarTitleBackColor = System.Drawing.Color.White
        Me.de2.CalendarTitleForeColor = System.Drawing.Color.White
        Me.de2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.de2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.de2.Location = New System.Drawing.Point(367, 48)
        Me.de2.Name = "de2"
        Me.de2.Size = New System.Drawing.Size(97, 22)
        Me.de2.TabIndex = 113
        '
        'dt2
        '
        Me.dt2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt2.Location = New System.Drawing.Point(249, 49)
        Me.dt2.Name = "dt2"
        Me.dt2.Size = New System.Drawing.Size(96, 22)
        Me.dt2.TabIndex = 112
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(388, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "End Date :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(265, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 109
        Me.Label4.Text = "Start Date :"
        '
        'de1
        '
        Me.de1.CalendarMonthBackground = System.Drawing.Color.White
        Me.de1.CalendarTitleBackColor = System.Drawing.Color.White
        Me.de1.CalendarTitleForeColor = System.Drawing.Color.White
        Me.de1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.de1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.de1.Location = New System.Drawing.Point(367, 22)
        Me.de1.Name = "de1"
        Me.de1.Size = New System.Drawing.Size(97, 22)
        Me.de1.TabIndex = 108
        '
        'dt1
        '
        Me.dt1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt1.Location = New System.Drawing.Point(249, 22)
        Me.dt1.Name = "dt1"
        Me.dt1.Size = New System.Drawing.Size(96, 22)
        Me.dt1.TabIndex = 107
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 106
        Me.Label3.Text = "Period :"
        '
        'tbListing
        '
        Me.tbListing.BackColor = System.Drawing.Color.White
        Me.tbListing.Controls.Add(Me.btnFilter)
        Me.tbListing.Controls.Add(Me.txtFilter)
        Me.tbListing.Controls.Add(Me.cmbfilter)
        Me.tbListing.Controls.Add(Me.lblSelection)
        Me.tbListing.Controls.Add(Me.GridListing)
        Me.tbListing.Location = New System.Drawing.Point(4, 23)
        Me.tbListing.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbListing.Name = "tbListing"
        Me.tbListing.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbListing.Size = New System.Drawing.Size(702, 524)
        Me.tbListing.TabIndex = 1
        Me.tbListing.Text = "Listing"
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(446, 8)
        Me.btnFilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(79, 24)
        Me.btnFilter.TabIndex = 4
        Me.btnFilter.Text = "Filter "
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'txtFilter
        '
        Me.txtFilter.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilter.Location = New System.Drawing.Point(224, 8)
        Me.txtFilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(207, 22)
        Me.txtFilter.TabIndex = 3
        '
        'cmbfilter
        '
        Me.cmbfilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbfilter.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbfilter.FormattingEnabled = True
        Me.cmbfilter.Items.AddRange(New Object() {"Company", "Year"})
        Me.cmbfilter.Location = New System.Drawing.Point(72, 10)
        Me.cmbfilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbfilter.Name = "cmbfilter"
        Me.cmbfilter.Size = New System.Drawing.Size(146, 21)
        Me.cmbfilter.TabIndex = 2
        '
        'lblSelection
        '
        Me.lblSelection.AutoSize = True
        Me.lblSelection.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelection.Location = New System.Drawing.Point(9, 18)
        Me.lblSelection.Name = "lblSelection"
        Me.lblSelection.Size = New System.Drawing.Size(60, 13)
        Me.lblSelection.TabIndex = 1
        Me.lblSelection.Text = "Selection :"
        '
        'GridListing
        '
        Me.GridListing.AllowUserToAddRows = False
        Me.GridListing.AllowUserToDeleteRows = False
        Me.GridListing.AllowUserToOrderColumns = True
        Me.GridListing.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridListing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridListing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colYear, Me.colCompany, Me.colStartDate, Me.colEndDate})
        Me.GridListing.Location = New System.Drawing.Point(6, 40)
        Me.GridListing.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridListing.Name = "GridListing"
        Me.GridListing.Size = New System.Drawing.Size(690, 382)
        Me.GridListing.TabIndex = 0
        '
        'colYear
        '
        Me.colYear.HeaderText = "Year"
        Me.colYear.Name = "colYear"
        Me.colYear.ReadOnly = True
        '
        'colCompany
        '
        Me.colCompany.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colCompany.HeaderText = "Company "
        Me.colCompany.Name = "colCompany"
        Me.colCompany.ReadOnly = True
        '
        'colStartDate
        '
        Me.colStartDate.HeaderText = "Effectivity Start Date"
        Me.colStartDate.Name = "colStartDate"
        Me.colStartDate.ReadOnly = True
        Me.colStartDate.Visible = False
        Me.colStartDate.Width = 150
        '
        'colEndDate
        '
        Me.colEndDate.HeaderText = "Effectivity End Date"
        Me.colEndDate.Name = "colEndDate"
        Me.colEndDate.ReadOnly = True
        Me.colEndDate.Visible = False
        Me.colEndDate.Width = 150
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.btnEdit, Me.btnDelete, Me.btnSave, Me.ToolStripSeparator2, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 58)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(733, 25)
        Me.ToolStrip1.TabIndex = 13
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.SPMSOPCI.My.Resources.Resources.add1
        Me.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(48, 22)
        Me.btnAdd.Text = "Add"
        '
        'btnEdit
        '
        Me.btnEdit.Image = Global.SPMSOPCI.My.Resources.Resources.page_edit1
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(47, 22)
        Me.btnEdit.Text = "Edit"
        '
        'btnDelete
        '
        Me.btnDelete.Image = Global.SPMSOPCI.My.Resources.Resources.delete1
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 22)
        Me.btnDelete.Text = "Delete"
        '
        'btnSave
        '
        Me.btnSave.Image = Global.SPMSOPCI.My.Resources.Resources.WSS_DocLib1
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(50, 22)
        Me.btnSave.Text = "Save"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnClose
        '
        Me.btnClose.Image = Global.SPMSOPCI.My.Resources.Resources.cancel
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(55, 22)
        Me.btnClose.Text = "Close"
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
        Me.Panel1.Size = New System.Drawing.Size(733, 58)
        Me.Panel1.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(15, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Calendar"
        '
        'ucAdministrationCalendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MainTab)
        Me.Name = "ucAdministrationCalendar"
        Me.Size = New System.Drawing.Size(733, 615)
        Me.MainTab.ResumeLayout(False)
        Me.tbEntry.ResumeLayout(False)
        Me.tbEntry.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbListing.ResumeLayout(False)
        Me.tbListing.PerformLayout()
        CType(Me.GridListing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainTab As System.Windows.Forms.TabControl
    Friend WithEvents tbEntry As System.Windows.Forms.TabPage
    Friend WithEvents tbListing As System.Windows.Forms.TabPage
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents cmbfilter As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelection As System.Windows.Forms.Label
    Friend WithEvents GridListing As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents de12 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt12 As System.Windows.Forms.DateTimePicker
    Friend WithEvents de11 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt11 As System.Windows.Forms.DateTimePicker
    Friend WithEvents de10 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt10 As System.Windows.Forms.DateTimePicker
    Friend WithEvents de9 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt9 As System.Windows.Forms.DateTimePicker
    Friend WithEvents de8 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt8 As System.Windows.Forms.DateTimePicker
    Friend WithEvents de7 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt7 As System.Windows.Forms.DateTimePicker
    Friend WithEvents de6 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt6 As System.Windows.Forms.DateTimePicker
    Friend WithEvents de5 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt5 As System.Windows.Forms.DateTimePicker
    Friend WithEvents de4 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt4 As System.Windows.Forms.DateTimePicker
    Friend WithEvents de3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents de2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents de1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbyear As System.Windows.Forms.ComboBox
    Friend WithEvents cmbcompany As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblGroupCode As System.Windows.Forms.Label
    Friend WithEvents txt12 As System.Windows.Forms.Label
    Friend WithEvents txt11 As System.Windows.Forms.Label
    Friend WithEvents txt10 As System.Windows.Forms.Label
    Friend WithEvents txt9 As System.Windows.Forms.Label
    Friend WithEvents txt8 As System.Windows.Forms.Label
    Friend WithEvents txt7 As System.Windows.Forms.Label
    Friend WithEvents txt6 As System.Windows.Forms.Label
    Friend WithEvents txt5 As System.Windows.Forms.Label
    Friend WithEvents txt4 As System.Windows.Forms.Label
    Friend WithEvents txt3 As System.Windows.Forms.Label
    Friend WithEvents txt2 As System.Windows.Forms.Label
    Friend WithEvents txt1 As System.Windows.Forms.Label
    Friend WithEvents cmb12 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb11 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb10 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb9 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb8 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb7 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb6 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb5 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb4 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmb1 As System.Windows.Forms.ComboBox
    Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents colYear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCompany As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStartDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEndDate As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
