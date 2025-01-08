<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIProductSalesvsTarget
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
        Dim CartesianArea1 As Telerik.WinControls.UI.CartesianArea = New Telerik.WinControls.UI.CartesianArea()
        Dim CategoricalAxis1 As Telerik.WinControls.UI.CategoricalAxis = New Telerik.WinControls.UI.CategoricalAxis()
        Dim LinearAxis1 As Telerik.WinControls.UI.LinearAxis = New Telerik.WinControls.UI.LinearAxis()
        Dim LineSeries1 As Telerik.WinControls.UI.LineSeries = New Telerik.WinControls.UI.LineSeries()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadChartLines = New Telerik.WinControls.UI.RadChartView()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.RadChartLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1080, 35)
        Me.Panel2.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Emoji", 18.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1049, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "X"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RadChartLines)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1080, 563)
        Me.Panel1.TabIndex = 21
        '
        'RadChartLines
        '
        CartesianArea1.GridDesign.AlternatingHorizontalColor = False
        CartesianArea1.GridDesign.AlternatingVerticalColor = False
        CartesianArea1.GridDesign.DrawHorizontalFills = False
        CartesianArea1.GridDesign.DrawHorizontalStripes = False
        CartesianArea1.GridDesign.DrawVerticalFills = False
        CartesianArea1.GridDesign.DrawVerticalStripes = False
        CartesianArea1.ShowGrid = True
        Me.RadChartLines.AreaDesign = CartesianArea1
        Me.RadChartLines.AutoScroll = True
        CategoricalAxis1.IsPrimary = True
        CategoricalAxis1.LabelFitMode = Telerik.Charting.AxisLabelFitMode.Rotate
        CategoricalAxis1.LabelRotationAngle = 291.0R
        CategoricalAxis1.Title = "Month Sales "
        LinearAxis1.AxisType = Telerik.Charting.AxisType.Second
        LinearAxis1.IsPrimary = True
        LinearAxis1.LabelRotationAngle = 360.0R
        LinearAxis1.Title = "Actual Sales Product"
        Me.RadChartLines.Axes.AddRange(New Telerik.WinControls.UI.Axis() {CategoricalAxis1, LinearAxis1})
        Me.RadChartLines.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadChartLines.LegendTitle = "Product Name"
        Me.RadChartLines.Location = New System.Drawing.Point(0, 0)
        Me.RadChartLines.Name = "RadChartLines"
        LineSeries1.HorizontalAxis = CategoricalAxis1
        LineSeries1.LabelAngle = 90.0R
        LineSeries1.LabelDistanceToPoint = 15.0R
        LineSeries1.LegendTitle = Nothing
        LineSeries1.VerticalAxis = LinearAxis1
        Me.RadChartLines.Series.AddRange(New Telerik.WinControls.UI.ChartSeries() {LineSeries1})
        Me.RadChartLines.ShowPanZoom = True
        Me.RadChartLines.ShowTitle = True
        Me.RadChartLines.ShowToolTip = True
        Me.RadChartLines.ShowTrackBall = True
        Me.RadChartLines.Size = New System.Drawing.Size(1080, 563)
        Me.RadChartLines.TabIndex = 21
        Me.RadChartLines.ThemeName = "Fluent"
        Me.RadChartLines.Title = "Product Sales Per Month"
        '
        'UIProductSalesvsTarget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "UIProductSalesvsTarget"
        Me.Size = New System.Drawing.Size(1080, 598)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.RadChartLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RadChartLines As Telerik.WinControls.UI.RadChartView

End Class
