<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UISalesVsTargetChart
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
        Dim LogarithmicAxis1 As Telerik.WinControls.UI.LogarithmicAxis = New Telerik.WinControls.UI.LogarithmicAxis()
        Dim BarSeries1 As Telerik.WinControls.UI.BarSeries = New Telerik.WinControls.UI.BarSeries()
        Dim CategoricalDataPoint1 As Telerik.Charting.CategoricalDataPoint = New Telerik.Charting.CategoricalDataPoint()
        Dim CategoricalDataPoint2 As Telerik.Charting.CategoricalDataPoint = New Telerik.Charting.CategoricalDataPoint()
        Dim BarSeries2 As Telerik.WinControls.UI.BarSeries = New Telerik.WinControls.UI.BarSeries()
        Dim CategoricalDataPoint3 As Telerik.Charting.CategoricalDataPoint = New Telerik.Charting.CategoricalDataPoint()
        Dim CategoricalDataPoint4 As Telerik.Charting.CategoricalDataPoint = New Telerik.Charting.CategoricalDataPoint()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadChartLines = New Telerik.WinControls.UI.RadChartView()
        CType(Me.RadChartLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1185, 35)
        Me.Panel2.TabIndex = 20
        '
        'RadChartLines
        '
        CartesianArea1.GridDesign.AlternatingHorizontalColor = False
        CartesianArea1.GridDesign.AlternatingVerticalColor = False
        CartesianArea1.GridDesign.DrawHorizontalFills = False
        CartesianArea1.GridDesign.DrawVerticalFills = False
        CartesianArea1.GridDesign.DrawVerticalStripes = False
        CartesianArea1.ShowGrid = True
        Me.RadChartLines.AreaDesign = CartesianArea1
        Me.RadChartLines.AutoScroll = True
        CategoricalAxis1.IsPrimary = True
        CategoricalAxis1.LabelRotationAngle = 300.0R
        CategoricalAxis1.Title = ""
        LogarithmicAxis1.AxisType = Telerik.Charting.AxisType.Second
        LogarithmicAxis1.ExponentStep = 1.0R
        LogarithmicAxis1.IsPrimary = True
        LogarithmicAxis1.LabelRotationAngle = 300.0R
        LogarithmicAxis1.LogarithmBase = 10.0R
        LogarithmicAxis1.Title = ""
        Me.RadChartLines.Axes.AddRange(New Telerik.WinControls.UI.Axis() {CategoricalAxis1, LogarithmicAxis1})
        Me.RadChartLines.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadChartLines.Location = New System.Drawing.Point(0, 35)
        Me.RadChartLines.Name = "RadChartLines"
        CategoricalDataPoint1.Category = "A"
        CategoricalDataPoint1.Label = 500.0R
        CategoricalDataPoint1.Value = 500.0R
        CategoricalDataPoint2.Category = "B"
        CategoricalDataPoint2.Label = 34324.0R
        CategoricalDataPoint2.Value = 34324.0R
        BarSeries1.DataPoints.AddRange(New Telerik.Charting.DataPoint() {CategoricalDataPoint1, CategoricalDataPoint2})
        BarSeries1.HorizontalAxis = CategoricalAxis1
        BarSeries1.LabelMode = Telerik.WinControls.UI.BarLabelModes.Top
        BarSeries1.LegendTitle = Nothing
        BarSeries1.VerticalAxis = LogarithmicAxis1
        CategoricalDataPoint3.Category = "A"
        CategoricalDataPoint3.Label = 600.0R
        CategoricalDataPoint3.Value = 600.0R
        CategoricalDataPoint4.Category = "B"
        CategoricalDataPoint4.Label = 324.0R
        CategoricalDataPoint4.Value = 324.0R
        BarSeries2.DataPoints.AddRange(New Telerik.Charting.DataPoint() {CategoricalDataPoint3, CategoricalDataPoint4})
        BarSeries2.HorizontalAxis = CategoricalAxis1
        BarSeries2.LabelMode = Telerik.WinControls.UI.BarLabelModes.Top
        BarSeries2.VerticalAxis = LogarithmicAxis1
        Me.RadChartLines.Series.AddRange(New Telerik.WinControls.UI.ChartSeries() {BarSeries1, BarSeries2})
        Me.RadChartLines.ShowLegend = True
        Me.RadChartLines.ShowTitle = True
        Me.RadChartLines.Size = New System.Drawing.Size(1185, 597)
        Me.RadChartLines.TabIndex = 23
        Me.RadChartLines.ThemeName = "Fluent"
        Me.RadChartLines.Title = "Product Sales vs Target "
        '
        'UISalesVsTargetChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.RadChartLines)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "UISalesVsTargetChart"
        Me.Size = New System.Drawing.Size(1185, 632)
        CType(Me.RadChartLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RadChartLines As Telerik.WinControls.UI.RadChartView

End Class
