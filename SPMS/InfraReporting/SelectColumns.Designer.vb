<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectColumns
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
        Me.BasePageHeader1 = New Althea.Base.UI.BasePageHeader
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.JButton1 = New Althea.Base.UI.JButton
        Me.dgTableColumns = New System.Windows.Forms.DataGridView
        Me.colSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAlias = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.dgTableColumns, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BasePageHeader1
        '
        Me.BasePageHeader1.AutoScroll = True
        Me.BasePageHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.BasePageHeader1.HeaderText = "Select Columns :"
        Me.BasePageHeader1.Location = New System.Drawing.Point(0, 0)
        Me.BasePageHeader1.Name = "BasePageHeader1"
        Me.BasePageHeader1.Size = New System.Drawing.Size(340, 44)
        Me.BasePageHeader1.TabIndex = 221
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.JButton1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 267)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(340, 31)
        Me.Panel1.TabIndex = 222
        '
        'JButton1
        '
        Me.JButton1.BorderColor = System.Drawing.Color.Gray
        Me.JButton1.DefaultBorderColor = System.Drawing.Color.Black
        Me.JButton1.DisableColor = System.Drawing.Color.Gray
        Me.JButton1.GradientColor1 = System.Drawing.Color.WhiteSmoke
        Me.JButton1.GradientColor2 = System.Drawing.Color.LightSteelBlue
        Me.JButton1.HighlightColor = System.Drawing.Color.White
        Me.JButton1.HoverColor = System.Drawing.Color.DarkGray
        Me.JButton1.Image = Nothing
        Me.JButton1.ImageIndex = 0
        Me.JButton1.Location = New System.Drawing.Point(262, 3)
        Me.JButton1.Name = "JButton1"
        Me.JButton1.Size = New System.Drawing.Size(72, 22)
        Me.JButton1.TabIndex = 2
        Me.JButton1.Text = "OK"
        Me.JButton1.UseVisualStyleBackColor = True
        '
        'dgTableColumns
        '
        Me.dgTableColumns.AllowUserToAddRows = False
        Me.dgTableColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTableColumns.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelect, Me.colName, Me.colAlias})
        Me.dgTableColumns.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTableColumns.Location = New System.Drawing.Point(0, 44)
        Me.dgTableColumns.Name = "dgTableColumns"
        Me.dgTableColumns.RowHeadersVisible = False
        Me.dgTableColumns.Size = New System.Drawing.Size(340, 223)
        Me.dgTableColumns.TabIndex = 223
        '
        'colSelect
        '
        Me.colSelect.Frozen = True
        Me.colSelect.HeaderText = ""
        Me.colSelect.Name = "colSelect"
        Me.colSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colSelect.Width = 25
        '
        'colName
        '
        Me.colName.DataPropertyName = "Name"
        Me.colName.HeaderText = "Column Name"
        Me.colName.Name = "colName"
        Me.colName.ReadOnly = True
        '
        'colAlias
        '
        Me.colAlias.HeaderText = "Alias"
        Me.colAlias.Name = "colAlias"
        '
        'SelectColumns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 298)
        Me.Controls.Add(Me.dgTableColumns)
        Me.Controls.Add(Me.BasePageHeader1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SelectColumns"
        Me.Text = "SelectColumns"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgTableColumns, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BasePageHeader1 As Althea.Base.UI.BasePageHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents JButton1 As Althea.Base.UI.JButton
    Friend WithEvents dgTableColumns As System.Windows.Forms.DataGridView
    Friend WithEvents colSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAlias As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
