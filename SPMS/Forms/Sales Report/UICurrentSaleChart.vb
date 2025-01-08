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
Public Class UICurrentSaleChart
    Dim table As New DataTable
    Dim dt As SqlDataReader
    Private m_TerritoryCode As String
    Public Property TerritoryCode As String
        Get
            Return m_TerritoryCode
        End Get
        Set(value As String)
            m_TerritoryCode = value
        End Set
    End Property

    Private Sub UICurrentSaleChart_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Me.Closed()
    End Sub
    Private Sub UICurrentSaleChart_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim pieSeries As PieSeries = New PieSeries()
        pieSeries.DataSource = Nothing
        RadChartPie.Series.Clear()
        LoadCurrentSalesOverview(TerritoryCode)
    End Sub
    Private Sub LoadCurrentSalesOverview(ByVal TerritoryCode As String)
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As SqlCommand = New SqlCommand("uspuspPerformancePerTerritory_OverViewWithChart", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SalesActualbyDistrictandTerritoryWithChart")
            cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)
            If dt.Rows.Count <> 0 Then
                Dim pieSeries As PieSeries = New PieSeries()
                Me.RadChartPie.Area.View.Palette = KnownPalette.Metro
                pieSeries.ValueMember = "Actual Value Sales"
                'pieSeries.LabelModeP = "Product Description"
                pieSeries.DataSource = dt
                pieSeries.ShowLabels = True
                pieSeries.LabelMode = PieLabelModes.Radial
                Me.RadChartPie.Series.Clear()
                Me.RadChartPie.ShowSmartLabels = True
                Me.RadChartPie.Title = "Current Sales Product Overview"
                Me.RadChartPie.View.Margin = New Padding(25)
                Me.RadChartPie.ShowTitle = True
                Me.RadChartPie.Series.Add(pieSeries)
                Me.RadChartPie.ShowLegend = True
                Disconnect()
            Else
                RadChartPie.Series.Clear()
            End If
        Catch ex As Exception
            Disconnect()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub Closed()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Closed()
    End Sub

    Private Sub RadChartPie_Click(sender As Object, e As EventArgs) Handles RadChartPie.Click

    End Sub
End Class
