<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UICurrentSaleChart
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
        Dim PieSeries1 As Telerik.WinControls.UI.PieSeries = New Telerik.WinControls.UI.PieSeries()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadChartPie = New Telerik.WinControls.UI.RadChartView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.RadChartPie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.RadChartPie)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1076, 566)
        Me.Panel1.TabIndex = 0
        '
        'RadChartPie
        '
        Me.RadChartPie.AreaType = Telerik.WinControls.UI.ChartAreaType.Pie
        Me.RadChartPie.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadChartPie.LegendTitle = "Product List"
        Me.RadChartPie.Location = New System.Drawing.Point(0, 35)
        Me.RadChartPie.Name = "RadChartPie"
        PieSeries1.LabelMode = Telerik.WinControls.UI.PieLabelModes.Radial
        PieSeries1.ShowLabels = True
        Me.RadChartPie.Series.AddRange(New Telerik.WinControls.UI.ChartSeries() {PieSeries1})
        Me.RadChartPie.ShowGrid = False
        Me.RadChartPie.ShowLegend = True
        Me.RadChartPie.ShowTitle = True
        Me.RadChartPie.Size = New System.Drawing.Size(1074, 529)
        Me.RadChartPie.TabIndex = 20
        Me.RadChartPie.ThemeName = "Fluent"
        Me.RadChartPie.Title = "Current Sales Product Overview"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1074, 35)
        Me.Panel2.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Emoji", 18.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1043, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "X"
        '
        'UICurrentSaleChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UICurrentSaleChart"
        Me.Size = New System.Drawing.Size(1076, 566)
        Me.Panel1.ResumeLayout(False)
        CType(Me.RadChartPie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RadChartPie As Telerik.WinControls.UI.RadChartView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
