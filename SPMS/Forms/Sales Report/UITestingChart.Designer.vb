<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UITestingChart
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadChartLines = New Telerik.WinControls.UI.RadChartView()
        Me.Panel2.SuspendLayout()
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
        Me.Panel2.Size = New System.Drawing.Size(1144, 35)
        Me.Panel2.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Emoji", 18.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1113, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "X"
        '
        'RadChartLines
        '
        CartesianArea1.GridDesign.AlternatingHorizontalColor = False
        CartesianArea1.GridDesign.AlternatingVerticalColor = False
        CartesianArea1.GridDesign.DrawHorizontalFills = False
        CartesianArea1.GridDesign.DrawVerticalFills = False
        CartesianArea1.ShowGrid = True
        Me.RadChartLines.AreaDesign = CartesianArea1
        Me.RadChartLines.AutoScroll = True
        CategoricalAxis1.IsPrimary = True
        CategoricalAxis1.LabelFitMode = Telerik.Charting.AxisLabelFitMode.MultiLine
        CategoricalAxis1.LabelRotationAngle = 300.0R
        CategoricalAxis1.Title = ""
        LogarithmicAxis1.AxisType = Telerik.Charting.AxisType.Second
        LogarithmicAxis1.ExponentStep = 1.0R
        LogarithmicAxis1.IsPrimary = True
        LogarithmicAxis1.LabelFitMode = Telerik.Charting.AxisLabelFitMode.MultiLine
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
        BarSeries1.ShowLabels = True
        BarSeries1.VerticalAxis = LogarithmicAxis1
        CategoricalDataPoint3.Category = "A"
        CategoricalDataPoint3.Label = 600.0R
        CategoricalDataPoint3.Value = 600.0R
        CategoricalDataPoint4.Category = "B"
        CategoricalDataPoint4.Label = 324.0R
        CategoricalDataPoint4.Value = 324.0R
        BarSeries2.DataPoints.AddRange(New Telerik.Charting.DataPoint() {CategoricalDataPoint3, CategoricalDataPoint4})
        BarSeries2.HorizontalAxis = CategoricalAxis1
        BarSeries2.LabelMode = Telerik.WinControls.UI.BarLabelModes.Center
        BarSeries2.ShowLabels = True
        BarSeries2.VerticalAxis = LogarithmicAxis1
        Me.RadChartLines.Series.AddRange(New Telerik.WinControls.UI.ChartSeries() {BarSeries1, BarSeries2})
        Me.RadChartLines.ShowLegend = True
        Me.RadChartLines.ShowTitle = True
        Me.RadChartLines.ShowTrackBall = True
        Me.RadChartLines.Size = New System.Drawing.Size(1144, 595)
        Me.RadChartLines.TabIndex = 22
        Me.RadChartLines.ThemeName = "Fluent"
        Me.RadChartLines.Title = "Product Sales vs Target "
        '
        'UITestingChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.RadChartLines)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "UITestingChart"
        Me.Size = New System.Drawing.Size(1144, 630)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.RadChartLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadChartLines As Telerik.WinControls.UI.RadChartView

End Class
