Imports System.ComponentModel
Imports System.Text
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI.Export
Imports Microsoft.Office.Interop
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports System.IO
Imports SPMSOPCI.ConnectionModule
Public Class UISalesVsTargetChart
    Dim table As New DataTable
    Dim dt As SqlDataReader
    Private m_SalesTargetTerritoryCode As String
    Private m_ProductCode As String
    Private m_ProductName As String
    Public Property SalesTarget_TerritoryCode As String
        Get
            Return m_SalesTargetTerritoryCode
        End Get
        Set(value As String)
            m_SalesTargetTerritoryCode = value
        End Set
    End Property
    Public Property ProductCode As String
        Get
            Return m_ProductCode
        End Get
        Set(value As String)
            m_ProductCode = value
        End Set
    End Property
    Public Property ProductsName As String
        Get
            Return m_ProductName
        End Get
        Set(value As String)
            m_ProductName = value
        End Set
    End Property
    Private Sub UISalesVsTargetChart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If m_ProductCode = Nothing Then
            LoadCharts(m_SalesTargetTerritoryCode)
        Else
            LoadChartsWithProduct(m_SalesTargetTerritoryCode, m_ProductCode, m_ProductName)
        End If
        ''LoadCharts("2-NL-108")
    End Sub
    Private Sub LoadCharts(ByVal TerritoryCode As String)
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As SqlCommand = New SqlCommand("uspSalesVSTarget_OverViewWithChart", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SalesvsTarget")
            cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)
            If dt.Rows.Count <> 0 Then
                For i As Integer = 1 To dt.Columns.Count - 1
                    Me.RadChartLines.Series.Clear()
                    Me.RadChartLines.Area.View.Palette = KnownPalette.Metro
                    Dim lineSeries1 As New BarSeries
                    lineSeries1.Name = "Target Sales"
                    lineSeries1.LegendTitle = "Target Sales"
                    lineSeries1.PointSize = New SizeF(5, 5)
                    lineSeries1.BorderWidth = 1
                    lineSeries1.ShowLabels = True
                    lineSeries1.LabelMode = BarLabelModes.Center
                    lineSeries1.ValueMember = dt.Columns(2).ColumnName
                    lineSeries1.CategoryMember = dt.Columns(1).ColumnName
                    lineSeries1.DataSource = dt
                    Me.RadChartLines.Series.Add(lineSeries1)

                    Dim lineSeries2 As New BarSeries
                    lineSeries2.Name = "Sales Amount"
                    lineSeries2.LegendTitle = "Sales Amount"
                    lineSeries2.PointSize = New SizeF(5, 5)
                    lineSeries2.BorderWidth = 1
                    lineSeries2.ShowLabels = True
                    lineSeries2.LabelMode = BarLabelModes.Center
                    lineSeries2.ValueMember = dt.Columns(3).ColumnName
                    lineSeries2.CategoryMember = dt.Columns(1).ColumnName
                    lineSeries2.DataSource = dt
                    Me.RadChartLines.Series.Add(lineSeries2)
                Next
            Else
                RadChartLines.Series.Clear()
            End If
        Catch ex As Exception
            Disconnect()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadChartsWithProduct(ByVal TerritoryCode As String, ByVal ProductCode As String, ByVal ProductsName As String)
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As SqlCommand = New SqlCommand("uspuspSalesVSTargetPerproduct_OverViewWithChart", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SalesvsTargetWithProduct")
            cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode)
            cmd.Parameters.AddWithValue("@ProductCode", ProductCode)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)
            If dt.Rows.Count <> 0 Then
                For i As Integer = 1 To dt.Columns.Count - 1
                    Me.RadChartLines.Series.Clear()
                    Me.RadChartLines.Area.View.Palette = KnownPalette.Metro
                    Me.RadChartLines.Title = "Product Sales vs Target" & " " & "(" & ProductCode & "-" & ProductsName & ")"
                    Dim lineSeries1 As New BarSeries
                    lineSeries1.Name = "Target Sales"
                    lineSeries1.LegendTitle = "Target Sales"
                    lineSeries1.PointSize = New SizeF(5, 5)
                    lineSeries1.BorderWidth = 1
                    lineSeries1.ShowLabels = True
                    lineSeries1.LabelMode = BarLabelModes.Center
                    lineSeries1.ValueMember = dt.Columns(2).ColumnName
                    lineSeries1.CategoryMember = dt.Columns(1).ColumnName
                    lineSeries1.DataSource = dt
                    Me.RadChartLines.Series.Add(lineSeries1)

                    Dim lineSeries2 As New BarSeries
                    lineSeries2.Name = "Sales Amount"
                    lineSeries2.LegendTitle = "Sales Amount"
                    lineSeries2.PointSize = New SizeF(5, 5)
                    lineSeries2.BorderWidth = 1
                    lineSeries2.ShowLabels = True
                    lineSeries2.LabelMode = BarLabelModes.Center
                    lineSeries2.ValueMember = dt.Columns(3).ColumnName
                    lineSeries2.CategoryMember = dt.Columns(1).ColumnName
                    lineSeries2.DataSource = dt
                    Me.RadChartLines.Series.Add(lineSeries2)
                Next
            Else
                RadChartLines.Series.Clear()
            End If
        Catch ex As Exception
            Disconnect()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs)
        Closed()
    End Sub
    Public Sub Closed()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub RadChartLines_Click(sender As Object, e As EventArgs) Handles RadChartLines.Click

    End Sub
End Class
