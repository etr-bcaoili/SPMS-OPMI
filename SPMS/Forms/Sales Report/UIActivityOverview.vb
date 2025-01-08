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
Public Class UIActivityOverview
    Dim table As New DataTable
    Private m_TerritoryCode As String = String.Empty
    Dim m_UICurrentSalesChart As New UICurrentSaleChart
    Dim m_NOSALESTRANSACTION As New NoSalesTransaction
    Private _strKeyColumn1 As String = String.Empty
    Private _strkeyColumn2 As String = String.Empty
    Private _strkeyColumn3 As String = String.Empty

    Private Property strkeyColumn1 As String
        Get
            Return _strKeyColumn1
        End Get
        Set(value As String)
            _strKeyColumn1 = value
        End Set
    End Property
    Private Property strkeyColumn2 As String
        Get
            Return _strkeyColumn2
        End Get
        Set(value As String)
            _strkeyColumn2 = value
        End Set
    End Property
    Private Property strkeyColumn3 As String
        Get
            Return _strkeyColumn3
        End Get
        Set(value As String)
            _strkeyColumn3 = value
        End Set
    End Property
    Private Property TerritoryCode As String
        Get
            Return m_TerritoryCode
        End Get
        Set(value As String)
            m_TerritoryCode = value
        End Set
    End Property

    Private Sub UIActivityOverview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        table = GetRecords(OverviewData.GetTreeViewMasterlist)
        For i As Integer = 0 To table.Rows.Count - 1
            If table.Rows.Count = 0 Then
                RadChartPie.Series.Clear()
                RadChartBars.Series.Clear()
            Else
                Dim GrandParentNode As New RadTreeNode
                GrandParentNode = RadTreeView1.Nodes(table.Rows(i)("Item Division Code"))
                If GrandParentNode Is Nothing Then
                    GrandParentNode = RadTreeView1.Nodes.Add(table.Rows(i)("Item Division Code"))
                End If

                Dim ParentNode As New RadTreeNode
                ParentNode = GrandParentNode.Nodes(table.Rows(i)("District Manager Code"))
                If ParentNode Is Nothing Then
                    ParentNode = GrandParentNode.Nodes.Add(table.Rows(i)("District Manager Code"))
                End If

                Dim ChildNode As New RadTreeNode
                ChildNode = ParentNode.Nodes(table.Rows(i)("Territory Code"))
                If ChildNode Is Nothing Then
                    ' ChildNode = ParentNode.Nodes(DataReader("ShipName").ToString())
                    ChildNode = ParentNode.Nodes.Add(table.Rows(i)("Territory Code"))
                End If

                '  ChildNode.Nodes.Add(DataReader.Item("PilotName").ToString())
            End If
        Next
        If table.Rows.Count <> 0 Then
            LOADPIECHART()
            SetupAggregatesChart()
            LOADLINESALEPERPRINCIPAL()
            LOADTOTALPERPRINCIPAL()
            LOADTOTALSALESALL()
        Else
            ClearChart()
        End If
    End Sub
    Private Sub ClearChart()
        Me.RadChartPie.Series.Clear()
        Me.RadChartBars.Series.Clear()
        Me.RadChartPrincipal.Series.Clear()
        txtDirectAmount.Text = String.Empty
        txtODI.Text = String.Empty
    End Sub

    Private Sub radTreeView1_Selected(ByVal sender As Object, ByVal e As RadTreeViewEventArgs) Handles RadTreeView1.SelectedNodeChanged
        ''Select Case (e.Action)
        'Case RadTreeViewAction.ByMouse
        '        If RadTreeView1.SelectedNode.Nodes.Count = 0 Then
        '            If RadTreeView1.SelectedNode.Text <> Nothing Then

        '                If m_TerritoryCode = Nothing Then
        '                    m_TerritoryCode = (RadTreeView1.SelectedNode.Text)
        '                    SalesCurrentProduct(RadTreeView1.SelectedNode.Text)
        '                    SalesTargetProductPerformance(RadTreeView1.SelectedNode.Text)
        '                    SalesTerritoryDetails(RadTreeView1.SelectedNode.Text)
        '                    SalesItemCustomerComparativeOverview(RadTreeView1.SelectedNode.Text)
        '                    SalesNoTransaction(RadTreeView1.SelectedNode.Text)
        '                    SetConditions()
        '                Else
        '                    TabControl2.TabPages(1).Dispose()
        '                    If TabControl2.TabPages.Count = 2 Then
        '                        TabControl2.TabPages(1).Dispose()
        '                    End If
        '                    m_TerritoryCode = (RadTreeView1.SelectedNode.Text)
        '                    SalesCurrentProduct(RadTreeView1.SelectedNode.Text)
        '                    SalesTargetProductPerformance(RadTreeView1.SelectedNode.Text)
        '                    SalesTerritoryDetails(RadTreeView1.SelectedNode.Text)
        '                    SalesItemCustomerComparativeOverview(RadTreeView1.SelectedNode.Text)
        '                    SalesNoTransaction(RadTreeView1.SelectedNode.Text)
        '                    SetConditions()
        '                End If

        '            End If
        '        Else
        '            GrdCurrentProductSales.DataSource = Nothing
        '        End If
        'End Select
    End Sub
    Private Sub SalesNoTransaction(ByVal TerritoryCode As String)
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspPerformancePerTerritory_OverView", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "NoSalesTransaction")
            cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            GrdViewNotransaction.Rows.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                table = GetRecords(NoSalesTransaction.NoSalesTransaction(dt.Rows(i)("CUSCD"), dt.Rows(i)("CDACD")))
                For a As Integer = 0 To table.Rows.Count - 1
                    Dim rowInfo As GridViewRowInfo = GrdViewNotransaction.Rows.AddNew
                    rowInfo.Cells(0).Value = table.Rows(a)("Year")
                    rowInfo.Cells(1).Value = table.Rows(a)("Distributor Code")
                    rowInfo.Cells(2).Value = table.Rows(a)("Customer Code")
                    rowInfo.Cells(3).Value = table.Rows(a)("Customer Name")
                    rowInfo.Cells(4).Value = table.Rows(a)("ShipTo Address1")
                    rowInfo.Cells(5).Value = table.Rows(a)("ShipTo Address2")
                    rowInfo.Cells(6).Value = table.Rows(a)("Item Mother Code")
                    rowInfo.Cells(7).Value = table.Rows(a)("Item Brand Name")
                    rowInfo.Cells(8).Value = table.Rows(a)("Qty")
                    rowInfo.Cells(9).Value = table.Rows(a)("Net Amount")
                Next
                Exit Sub
            Next
            Disconnect()
        Catch ex As Exception
            Disconnect()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SalesCurrentProduct(ByVal TerritoryCode As String)
        m_UICurrentSalesChart.Closed()
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspPerformancePerTerritory_OverView", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SalesActualbyDistrictandTerritory")
            cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            GrdCurrentProductSales.DataSource = dt
            GrdCurrentProductSales.Columns(0).Width = 95
            GrdCurrentProductSales.Columns(1).Width = 120
            GrdCurrentProductSales.Columns(2).Width = 200
            GrdCurrentProductSales.Columns(3).Width = 200
            GrdCurrentProductSales.Columns(4).Width = 95
            GrdCurrentProductSales.Columns(5).Width = 200
            GrdCurrentProductSales.Columns(6).Width = 100
            GrdCurrentProductSales.Columns(6).FormatString = "{0:###,##0.00}"
            GrdCurrentProductSales.Columns(7).Width = 100
            GrdCurrentProductSales.Columns(7).FormatString = "{0:###,##0.00}"
            Disconnect()

            TabControl1_Tab1(TerritoryCode)
        Catch ex As Exception
            Disconnect()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SalesTargetProductPerformance(ByVal TerritoryCode As String)
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspPerformancePerTerritory_OverView", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "PerformancePerTerritory_OverView")
            cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            GrdViewTarget.DataSource = dt
            GrdViewTarget.Columns(0).Width = 125
            GrdViewTarget.Columns(1).Width = 200
            GrdViewTarget.Columns(2).Width = 95
            GrdViewTarget.Columns(3).Width = 100
            GrdViewTarget.Columns(3).FormatString = "{0:###,##0.00}"
            GrdViewTarget.Columns(4).Width = 100
            GrdViewTarget.Columns(4).FormatString = "{0:###,##0.00}"
            GrdViewTarget.Columns(5).Width = 100
            GrdViewTarget.Columns(5).FormatString = "{0:###,##0.00}"
            GrdViewTarget.Columns(6).Width = 100
            GrdViewTarget.Columns(6).FormatString = "{0:###,##0.00}"
            GrdViewTarget.Columns(7).Width = 100
        Catch ex As Exception
            Disconnect()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SalesTerritoryDetails(ByVal TerritoryCode As String)
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspPerformancePerTerritory_OverView", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SaleTerritoryDetails")
            cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            GrdSalesDetailsTerritory.DataSource = dt
            GrdSalesDetailsTerritory.Columns(0).Width = 150
            GrdSalesDetailsTerritory.Columns(1).Width = 150
            GrdSalesDetailsTerritory.Columns(2).Width = 150
            GrdSalesDetailsTerritory.Columns(3).Width = 150
            GrdSalesDetailsTerritory.Columns(4).Width = 150
            GrdSalesDetailsTerritory.Columns(5).Width = 150
            GrdSalesDetailsTerritory.Columns(6).Width = 150
            GrdSalesDetailsTerritory.Columns(7).Width = 150
            GrdSalesDetailsTerritory.Columns(8).Width = 150
            GrdSalesDetailsTerritory.Columns(9).Width = 150
            GrdSalesDetailsTerritory.Columns(9).FormatString = "{0:###,##0.00}"
            GrdSalesDetailsTerritory.Columns(10).Width = 150
            GrdSalesDetailsTerritory.Columns(10).FormatString = "{0:###,##0.00}"
        Catch ex As Exception
            Disconnect()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SalesItemCustomerComparativeOverview(ByVal TerritoryCode As String)
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspItemCustomerComparativePerMonth_Overview", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            GrdProductAndCustomerYTD.DataSource = dt
            GrdProductAndCustomerYTD.Columns(0).Width = 150
            GrdProductAndCustomerYTD.Columns(1).Width = 150
            GrdProductAndCustomerYTD.Columns(2).Width = 150
            GrdProductAndCustomerYTD.Columns(3).Width = 250
            GrdProductAndCustomerYTD.Columns(4).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(4).Width = 150
            GrdProductAndCustomerYTD.Columns(5).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(5).Width = 150
            GrdProductAndCustomerYTD.Columns(6).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(6).Width = 150
            GrdProductAndCustomerYTD.Columns(7).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(7).Width = 150
            GrdProductAndCustomerYTD.Columns(8).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(8).Width = 150
            GrdProductAndCustomerYTD.Columns(9).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(9).Width = 150
            GrdProductAndCustomerYTD.Columns(10).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(10).Width = 150
            GrdProductAndCustomerYTD.Columns(11).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(11).Width = 150
            GrdProductAndCustomerYTD.Columns(12).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(12).Width = 150
            GrdProductAndCustomerYTD.Columns(13).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(13).Width = 150
            GrdProductAndCustomerYTD.Columns(14).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(14).Width = 150
            GrdProductAndCustomerYTD.Columns(15).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(15).Width = 150
            GrdProductAndCustomerYTD.Columns(16).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(16).Width = 150
            GrdProductAndCustomerYTD.Columns(17).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(17).Width = 150
            GrdProductAndCustomerYTD.Columns(18).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(18).Width = 150
            GrdProductAndCustomerYTD.Columns(19).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(19).Width = 150
            GrdProductAndCustomerYTD.Columns(20).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(20).Width = 150
            GrdProductAndCustomerYTD.Columns(21).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(21).Width = 150
            GrdProductAndCustomerYTD.Columns(22).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(22).Width = 150
            GrdProductAndCustomerYTD.Columns(23).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(23).Width = 150
            GrdProductAndCustomerYTD.Columns(24).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(24).Width = 150
            GrdProductAndCustomerYTD.Columns(25).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(25).Width = 150
            GrdProductAndCustomerYTD.Columns(26).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(26).Width = 150
            GrdProductAndCustomerYTD.Columns(27).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(27).Width = 150
            GrdProductAndCustomerYTD.Columns(28).FormatString = "{0:###,##0.00}"
            GrdProductAndCustomerYTD.Columns(28).Width = 150
        Catch ex As Exception
            Disconnect()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SetConditions()
        'add a couple of sample formatting objects 
        Dim c1 As New ConditionalFormattingObject("Green", ConditionTypes.Equal, "TOTAL", "", True)
        c1.RowBackColor = Color.FromArgb(255, 204, 102)
        c1.RowForeColor = Color.Black
        GrdCurrentProductSales.Columns("Sales Year").ConditionalFormattingObjectList.Add(c1)
    End Sub
    Private Sub TabControl1_SelectedIndexChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            TabControl2.TabPages(1).Dispose()
            If TabControl2.TabPages.Count = 2 Then
                TabControl2.TabPages(1).Dispose()
            End If
            TabControl1_Tab1(TerritoryCode)
        ElseIf TabControl1.SelectedIndex = 1 Then
            TabControl2.TabPages(1).Dispose()
            If TabControl2.TabPages.Count = 2 Then
                TabControl2.TabPages(1).Dispose()
            End If
            TabControl1_TabSalesVSTarget(TerritoryCode)
        ElseIf TabControl1.SelectedIndex = 2 Then
            'TabControl1.SelectTab(TabPage4)
        End If

    End Sub
    Private Sub TabControl1_TabSalesVSTarget(ByVal TerritoryCode As String)
        If TabControl2.TabPages(TabControl2.TabPages.Count - 1).Text <> "Product Sales vs Target" Then
            TabControl2.TabPages.Add(TabControl1.TabPages.Count)
            Dim UISalesVSTarget As New UISalesVsTargetChart
            UISalesVSTarget.SalesTarget_TerritoryCode = TerritoryCode
            UISalesVSTarget.Width = Me.Width
            UISalesVSTarget.Height = TabControl2.TabPages(TabControl2.TabPages.Count - 1).Height
            TabControl2.TabPages(1).AutoScroll = True
            TabControl2.TabPages(TabControl2.TabPages.Count - 1).Text = "Product Sales vs Target"
            TabControl2.TabPages(TabControl2.TabPages.Count - 1).Controls.Add(UISalesVSTarget)
            TabControl2.SelectTab(TabControl2.TabPages.Count - 1)
        Else
            Me.TabControl2.Controls.Remove(Me.TabControl1.TabPages(2))
            TabControl2.TabPages.Add(TabControl1.TabPages.Count)
            Dim UISalesVSTarget As New UISalesVsTargetChart
            UISalesVSTarget.SalesTarget_TerritoryCode = TerritoryCode
            UISalesVSTarget.Width = Me.Width
            UISalesVSTarget.Height = TabControl2.TabPages(TabControl2.TabPages.Count - 1).Height
            TabControl2.TabPages(1).AutoScroll = True
            TabControl2.TabPages(TabControl2.TabPages.Count - 1).Text = "Product Sales vs Target"
            TabControl2.TabPages(TabControl2.TabPages.Count - 1).Controls.Add(UISalesVSTarget)
            TabControl2.SelectTab(TabControl2.TabPages.Count - 1)
        End If
    End Sub
    Private Sub TabControl1_Tab1(ByVal TerritoryCode As String)
        If TabControl2.TabPages(TabControl2.TabPages.Count - 1).Text <> "Current Sales Overview" Then
            TabControl2.TabPages.Add(TabControl1.TabPages.Count)
            Dim UICurrentSaleChart As New UICurrentSaleChart
            UICurrentSaleChart.TerritoryCode = TerritoryCode
            UICurrentSaleChart.Width = Me.Width
            UICurrentSaleChart.Height = TabControl2.TabPages(TabControl2.TabPages.Count - 1).Height
            TabControl2.TabPages(1).AutoScroll = True
            TabControl2.TabPages(TabControl2.TabPages.Count - 1).Text = "Current Sales Overview"
            TabControl2.TabPages(TabControl2.TabPages.Count - 1).Controls.Add(UICurrentSaleChart)
            TabControl2.SelectTab(TabControl2.TabPages.Count - 1)
        Else
            Me.TabControl2.Controls.Remove(Me.TabControl1.TabPages(2))
            TabControl2.TabPages.Add(TabControl1.TabPages.Count)
            Dim UICurrentSaleChart As New UICurrentSaleChart
            UICurrentSaleChart.TerritoryCode = TerritoryCode
            UICurrentSaleChart.Width = Me.Width
            UICurrentSaleChart.Height = TabControl2.TabPages(TabControl2.TabPages.Count - 1).Height
            TabControl2.TabPages(1).AutoScroll = True
            TabControl2.TabPages(TabControl2.TabPages.Count - 1).Text = "Current Sales Overview"
            TabControl2.TabPages(TabControl2.TabPages.Count - 1).Controls.Add(UICurrentSaleChart)
            TabControl2.SelectTab(TabControl2.TabPages.Count - 1)
        End If
    End Sub
    Private Sub TabControl1_Tab2(ByVal TerritoryCode As String, ByVal ProductCode As String, ByVal ProductName As String)
        If TabControl2.TabPages(TabControl2.TabPages.Count - 1).Text <> "Product Sales Value" Then
            TabControl2.TabPages.Add(TabControl1.TabPages.Count)
            Dim UIProductSalesvsTarget As New UIProductSalesvsTarget
            UIProductSalesvsTarget.TerritoryCode = TerritoryCode
            UIProductSalesvsTarget.ProductCode = ProductCode
            UIProductSalesvsTarget.Producstname = ProductName
            UIProductSalesvsTarget.Width = Me.Width
            UIProductSalesvsTarget.Height = TabControl2.TabPages(TabControl2.TabPages.Count - 1).Height
            TabControl2.TabPages(2).AutoScroll = True
            TabControl2.TabPages(TabControl2.TabPages.Count - 1).Text = "Product Sales Value"
            TabControl2.TabPages(TabControl2.TabPages.Count - 1).Controls.Add(UIProductSalesvsTarget)
            TabControl2.SelectTab(TabControl2.TabPages.Count - 1)
        Else
            TabControl2.TabPages(2).Dispose()
            TabControl2.TabPages.Add(TabControl1.TabPages.Count)
            Dim UIProductSalesvsTarget As New UIProductSalesvsTarget
            UIProductSalesvsTarget.TerritoryCode = TerritoryCode
            UIProductSalesvsTarget.ProductCode = ProductCode
            UIProductSalesvsTarget.Producstname = ProductName
            UIProductSalesvsTarget.Width = Me.Width
            UIProductSalesvsTarget.Height = TabControl2.TabPages(TabControl2.TabPages.Count - 1).Height
            TabControl2.TabPages(2).AutoScroll = True
            TabControl2.TabPages(TabControl2.TabPages.Count - 1).Text = "Product Sales Value"
            TabControl2.TabPages(TabControl2.TabPages.Count - 1).Controls.Add(UIProductSalesvsTarget)
            TabControl2.SelectTab(TabControl2.TabPages.Count - 1)
        End If
    End Sub

    Private Sub GrdCurrentProductSales_Click(sender As Object, e As EventArgs) Handles GrdCurrentProductSales.Click
        SelectItem()
    End Sub
    Private Sub SelectItem()
        If GrdCurrentProductSales.SelectedRows.Count > 0 Then
            _strKeyColumn1 = GrdCurrentProductSales.SelectedRows(0).Cells(4).Value
            If GrdCurrentProductSales.ColumnCount > 1 Then
                _strKeyColumn1 = TerritoryCode
                _strkeyColumn2 = GrdCurrentProductSales.SelectedRows(0).Cells(4).Value
                _strkeyColumn3 = GrdCurrentProductSales.SelectedRows(0).Cells(5).Value
                TabControl1_Tab2(_strKeyColumn1, _strkeyColumn2, _strkeyColumn3)
            Else
                _strkeyColumn1 = String.Empty
            End If
        End If
    End Sub

    Private Sub GrdViewTarget_Click(sender As Object, e As EventArgs) Handles GrdViewTarget.Click
        SelectSalesvsTarget()
    End Sub
    Private Sub SelectSalesvsTarget()
        If GrdViewTarget.SelectedRows.Count > 0 Then
            _strKeyColumn1 = GrdViewTarget.SelectedRows(0).Cells(0).Value
            If GrdViewTarget.ColumnCount > 1 Then
                _strKeyColumn1 = TerritoryCode
                _strkeyColumn2 = GrdViewTarget.SelectedRows(0).Cells(0).Value
                _strkeyColumn3 = GrdViewTarget.SelectedRows(0).Cells(1).Value
                If TabControl2.TabPages(1).Text = "Product Sales vs Target" Then
                    TabControl2.TabPages(1).Dispose()
                End If
                TabControl1_TabSalesVSTarget2(_strKeyColumn1, _strkeyColumn2, _strkeyColumn3)
            Else
                _strKeyColumn1 = String.Empty
            End If
        End If
    End Sub
    Private Sub TabControl1_TabSalesVSTarget2(ByVal TerritoryCode As String, ByVal ProductCode As String, ByVal ProductName As String)
        If TabControl2.TabPages(TabControl2.TabPages.Count - 1).Text <> "Product Sales vs Target" Then
            TabControl2.TabPages.Add(TabControl1.TabPages.Count)
            Dim UISalesVSTarget As New UISalesVsTargetChart
            UISalesVSTarget.SalesTarget_TerritoryCode = TerritoryCode
            UISalesVSTarget.ProductCode = ProductCode
            UISalesVSTarget.ProductsName = ProductName
            UISalesVSTarget.Width = Me.Width
            UISalesVSTarget.Height = TabControl2.TabPages(TabControl2.TabPages.Count - 1).Height
            TabControl2.TabPages(1).AutoScroll = True
            TabControl2.TabPages(TabControl2.TabPages.Count - 1).Text = "Product Sales vs Target"
            TabControl2.TabPages(TabControl2.TabPages.Count - 1).Controls.Add(UISalesVSTarget)
            TabControl2.SelectTab(TabControl2.TabPages.Count - 1)
        Else
            Me.TabControl2.Controls.Remove(Me.TabControl1.TabPages(2))
            TabControl2.TabPages.Add(TabControl1.TabPages.Count)
            Dim UISalesVSTarget As New UISalesVsTargetChart
            UISalesVSTarget.SalesTarget_TerritoryCode = TerritoryCode
            UISalesVSTarget.ProductCode = ProductCode
            UISalesVSTarget.Width = Me.Width
            UISalesVSTarget.Height = TabControl2.TabPages(TabControl2.TabPages.Count - 1).Height
            TabControl2.TabPages(1).AutoScroll = True
            TabControl2.TabPages(TabControl2.TabPages.Count - 1).Text = "Product Sales vs Target"
            TabControl2.TabPages(TabControl2.TabPages.Count - 1).Controls.Add(UISalesVSTarget)
            TabControl2.SelectTab(TabControl2.TabPages.Count - 1)
        End If
    End Sub
    Private Sub LOADPIECHART()
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As SqlCommand = New SqlCommand("uspSalesDataViewChart", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "DivisionChart")
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)
            If dt.Rows.Count <> 0 Then
                For i As Integer = 1 To dt.Columns.Count - 1
                    Me.RadChartPie.Series.Clear()
                    Me.RadChartPie.Area.View.Palette = KnownPalette.Metro
                    Dim DonutSeries1 As New DonutSeries
                    DonutSeries1.PointSize = New SizeF(5, 5)
                    DonutSeries1.BorderWidth = 2
                    DonutSeries1.ShowLabels = True

                    DonutSeries1.ValueMember = dt.Columns(2).ColumnName
                    ' DonutSeries1.LegendTitleMember = dt.Columns(1).ColumnName
                    DonutSeries1.DataSource = dt
                    Me.RadChartPie.Series.Add(DonutSeries1)
                Next
            Else
                RadChartPie.Series.Clear()
            End If
        Catch ex As Exception
            Disconnect()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SetupAggregatesChart()
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As SqlCommand = New SqlCommand("uspSalesDataViewChart", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "DistrictManagerSales")
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)
            If dt.Rows.Count <> 0 Then
                For i As Integer = 1 To dt.Columns.Count - 1
                    Me.RadChartBars.Series.Clear()
                    Me.RadChartBars.Area.View.Palette = KnownPalette.Windows8

                    Me.RadChartBars.Series.Clear()
                    Dim lineSeries1 As New BarSeries
                    lineSeries1.LabelMode = BarLabelModes.Top
                    lineSeries1.PointSize = New SizeF(5, 5)
                    lineSeries1.BorderWidth = 2
                    lineSeries1.LabelMode = BarLabelModes.Center
                    lineSeries1.ValueMember = dt.Columns(2).ColumnName
                    lineSeries1.CategoryMember = dt.Columns(1).ColumnName
                    lineSeries1.DataSource = dt
                    Me.RadChartBars.Series.Add(lineSeries1)
                    Me.RadChartBars.GetArea(Of CartesianArea)().Orientation = Orientation.Horizontal


                    Dim LineSeries2 As New LineSeries
                    LineSeries2.PointSize = New SizeF(5, 5)
                    LineSeries2.BorderWidth = 2
                    LineSeries2.Spline = True
                    LineSeries2.ValueMember = dt.Columns(2).ColumnName
                    LineSeries2.CategoryMember = dt.Columns(1).ColumnName
                    LineSeries2.DataSource = dt
                    Me.RadChartBars.Series.Add(LineSeries2)

                Next
            Else
                RadChartBars.Series.Clear()
            End If
        Catch ex As Exception
            Disconnect()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LOADLINESALEPERPRINCIPAL()
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As SqlCommand = New SqlCommand("uspSalesDataViewChart", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SalesPerPrincipla")
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)
            If dt.Rows.Count <> 0 Then
                For i As Integer = 1 To dt.Columns.Count - 1
                    Me.RadChartPrincipal.Series.Clear()
                    Me.RadChartPrincipal.Area.View.Palette = KnownPalette.Metro
                    Dim lineSeries1 As New LineSeries
                    lineSeries1.Name = "DIR"
                    lineSeries1.LegendTitle = "DIR"
                    lineSeries1.PointSize = New SizeF(5, 5)
                    lineSeries1.BorderWidth = 2
                    lineSeries1.Spline = True
                    lineSeries1.ValueMember = dt.Columns(2).ColumnName
                    lineSeries1.CategoryMember = dt.Columns(1).ColumnName
                    lineSeries1.DataSource = dt
                    Me.RadChartPrincipal.Series.Add(lineSeries1)

                    Dim LineSeries2 As New LineSeries
                    LineSeries2.Name = "ODI"
                    LineSeries2.LegendTitle = "ODI"
                    LineSeries2.PointSize = New SizeF(5, 5)
                    LineSeries2.BorderWidth = 2
                    LineSeries2.Spline = True
                    LineSeries2.ValueMember = dt.Columns(3).ColumnName
                    LineSeries2.CategoryMember = dt.Columns(1).ColumnName
                    LineSeries2.DataSource = dt
                    Me.RadChartPrincipal.Series.Add(LineSeries2)
                Next
            Else
                RadChartPrincipal.Series.Clear()
            End If
        Catch ex As Exception
            Disconnect()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LOADTOTALSALESALL()
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As SqlCommand = New SqlCommand("uspSalesDataViewChart", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "TotalSalesOverview")
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)
            If dt.Rows.Count <> 0 Then
                For i As Integer = 1 To dt.Columns.Count - 1
                    Me.RadChartAllSales.Series.Clear()
                    Me.RadChartAllSales.Area.View.Palette = KnownPalette.Metro
                    Dim AreaSeries1 As New AreaSeries
                    AreaSeries1.BorderWidth = 2
                    AreaSeries1.ValueMember = dt.Columns(2).ColumnName
                    AreaSeries1.CategoryMember = dt.Columns(1).ColumnName
                    AreaSeries1.DataSource = dt
                    Me.RadChartAllSales.Series.Add(AreaSeries1)
                Next
            Else
                RadChartAllSales.Series.Clear()
            End If
        Catch ex As Exception
            Disconnect()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LOADTOTALPERPRINCIPAL()
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As SqlCommand = New SqlCommand("uspSalesDataViewChart", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "TotalSalesPerPrincipal")
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)
            If dt.Rows.Count <> 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim DIRNetAmount As String = UCase(SpellNumber(Val(dt.Rows(i)("DIRSales"))))
                    txtDirectAmount.Text = DIRNetAmount
                    Dim ODINetAmount As String = UCase(SpellNumber(Val(dt.Rows(i)("ODISales"))))
                    txtODI.Text = ODINetAmount
                Next
            End If
        Catch ex As Exception
            Disconnect()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class