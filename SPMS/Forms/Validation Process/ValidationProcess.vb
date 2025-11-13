Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing
Imports System.Text
Imports Telerik.WinControls.UI
Imports System.Windows.Forms
Imports Telerik.WinControls
Imports System.Runtime.Remoting.Channels
Imports Telerik.WinControls.UI.Export
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.Dialogs
Imports Aphrodite.Core

Public Class ValidationProcess
    Dim table As New DataTable
    Dim _ExcelResult As New ExcelProductGroupSharing
    Dim dt As New DataTable
    Private m_Channel As New Distributor
    Private m_ConfigtypeCode As New Configuration
    Private m_DistributorPrimary As String = "OPCI"
    Private m_ExternalChannelCode As String = String.Empty
    Private m_ExternalConfigtypeCode As String = String.Empty
    Private m_ExternalMonth As String = String.Empty
    Private m_ExternalYear As String = String.Empty
    Private m_RebuildProcess As Boolean = False

    Public Property ExternalChannelCode As String
        Get
            Return m_ExternalChannelCode
        End Get
        Set(value As String)
            m_ExternalChannelCode = value
        End Set
    End Property
    Public Property ExternalConfigtypeCode As String
        Get
            Return m_ExternalConfigtypeCode
        End Get
        Set(value As String)
            m_ExternalConfigtypeCode = value
        End Set
    End Property
    Public Property ExternalMonth As String
        Get
            Return m_ExternalMonth
        End Get
        Set(value As String)
            m_ExternalMonth = value
        End Set
    End Property
    Public Property ExternalYear As String
        Get
            Return m_ExternalYear
        End Get
        Set(value As String)
            m_ExternalYear = value
        End Set
    End Property
    Public Property RebuildProcess As Boolean
        Get
            Return m_RebuildProcess
        End Get
        Set(value As Boolean)
            m_RebuildProcess = value
        End Set
    End Property

    Private Sub LoadYear()
        table = GetRecords(Configuration.GetYearbyConfig)
        For i As Integer = 0 To table.Rows.Count - 1
            DropYear.Items.Add(table.Rows(i)("CAYR"))
        Next
    End Sub
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Medical Configuration")
        If Not tag Is Nothing Then
            txtConfigtypeCode.Text = tag.KeyColumn11
            txtConfigtypeName.Text = tag.KeyColumn33
        End If
    End Sub

    Private Sub DropYear_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles DropYear.SelectedIndexChanged
        If DropYear.SelectedIndex = -1 Then Exit Sub
        LoadMonth(m_DistributorPrimary, DropYear.Text)
    End Sub
    Private Sub LoadMonth(ByVal DistributorCode As String, ByVal Year As String)
        DropMonth.Items.Clear()
        table = GetRecords(Configuration.GetMonthConfigtype(DistributorCode, Year))
        For i As Integer = 0 To table.Rows.Count - 1
            DropMonth.Items.Add(table.Rows(i)("CAPN"))
        Next
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If txtConfigtypeCode.Text <> "" Then
            Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Distributor.GetDistributorSql, "Search Item")
            If Not tag Is Nothing Then
                LoadChannel(tag.KeyColumn22)
            End If
        End If
    End Sub
    Private Sub LoadChannel(ByVal ChannelCode As String)
        m_Channel = Distributor.LoadByCode(ChannelCode)
        m_Channel.DISTCOMID = m_Channel.DISTCOMID
        txtChannelCode.Text = m_Channel.DISTCOMID
        txtChannelName.Text = m_Channel.DISTNAME
    End Sub
    Private Sub LoadConfigtype(ByVal ConfigtypeCode As String)
        m_ConfigtypeCode = Configuration.LoadbyCode(ConfigtypeCode)
        m_ConfigtypeCode.ConfigTypeCode = m_ConfigtypeCode.ConfigTypeCode
        txtConfigtypeCode.Text = m_ConfigtypeCode.ConfigTypeCode
        txtConfigtypeName.Text = m_ConfigtypeCode.ConfigTypeName
    End Sub

    Private Sub ValidationProcess_Load(sender As Object, e As EventArgs) Handles Me.Load
        If m_RebuildProcess = True Then
            LoadYear()
            LoadChannel(m_ExternalChannelCode)
            LoadConfigtype(m_ExternalConfigtypeCode)
            DropYear.Text = m_ExternalYear
            DropMonth.Text = m_ExternalMonth
            LoadMismatchCustomerItemSharing()
            LoadMismatchCustomerItemSharingProduct()
        Else
            LoadYear()
        End If
    End Sub
    Private Sub LoadMismatchCustomerItemSharing()
        Dim dt As DataTable = GetCustomerItemSharing()

        If dt.Rows.Count > 0 Then
            PopulateGridFromDataTable(dt, GrdView)
        Else
            GrdView.Rows.Clear()
            'MessageBox.Show("No data to display.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub LoadMismatchCustomerItemSharingProduct()
        Dim dt As DataTable = GetCustomerItemSharingProduct()

        If dt.Rows.Count > 0 Then
            PopulateGridFromDataTableProduct(dt, GrdView)
        Else
            grdViewProduct.Rows.Clear()
            'MessageBox.Show("No data to display.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Public Function GetCustomerItemSharing() As DataTable
        Dim dt As New DataTable()

        Try
            SPMSOPCI.ConnectionModule.Connect()

            Using cmd As New SqlCommand("Select * from [ValidationData] Where [InvalidatCode] = 1 ", SPMSOPCI.ConnectionModule.SPMSConn2)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using

            SPMSOPCI.ConnectionModule.Disconnect()

        Catch ex As Exception
            Throw
        End Try

        Return dt
    End Function
    Public Function GetCustomerItemSharingProduct() As DataTable
        Dim dt As New DataTable()

        Try
            SPMSOPCI.ConnectionModule.Connect()

            Using cmd As New SqlCommand("Select * from [ValidationData] Where [InvalidatCode] = 2", SPMSOPCI.ConnectionModule.SPMSConn2)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using

            SPMSOPCI.ConnectionModule.Disconnect()

        Catch ex As Exception
            Throw
        End Try

        Return dt
    End Function

    Public Sub PopulateGridFromDataTableProduct(table As DataTable, grdView As Telerik.WinControls.UI.RadGridView)
        Dim dt As DataTable = GetCustomerItemSharingProduct()

        grdViewProduct.Rows.Clear() ' Optional: Clear existing rows before populating

        For Each row As DataRow In table.Rows
            Dim rowinfo As GridViewRowInfo = grdViewProduct.Rows.AddNew()
            rowinfo.Cells(0).Value = row("ChannelCode")
            rowinfo.Cells(1).Value = row("CustomerCode")
            rowinfo.Cells(2).Value = row("CustomerName")
            rowinfo.Cells(3).Value = row("ShipToCode")
            rowinfo.Cells(4).Value = row("DistrictCode")
            rowinfo.Cells(5).Value = row("SC02_Mapping")
            rowinfo.Cells(6).Value = row("InvalidMapping")
            rowinfo.Cells(7).Value = row("ItemCode")
            rowinfo.Cells(8).Value = row("ItemName")
            rowinfo.Cells(9).Value = row("ProductGroupCode")
            rowinfo.Cells(10).Value = row("SharedType")
        Next
    End Sub
    Public Sub PopulateGridFromDataTable(table As DataTable, grdView As Telerik.WinControls.UI.RadGridView)
        Dim dt As DataTable = GetCustomerItemSharing()

        grdView.Rows.Clear() ' Optional: Clear existing rows before populating

        For Each row As DataRow In table.Rows
            Dim rowinfo As GridViewRowInfo = grdView.Rows.AddNew()
            rowinfo.Cells(0).Value = row("ChannelCode")
            rowinfo.Cells(1).Value = row("CustomerCode")
            rowinfo.Cells(2).Value = row("CustomerName")
            rowinfo.Cells(3).Value = row("ShipToCode")
            rowinfo.Cells(4).Value = row("DistrictCode")
            rowinfo.Cells(5).Value = row("SC02_Mapping")
            rowinfo.Cells(6).Value = row("InvalidMapping")
            rowinfo.Cells(7).Value = row("ItemCode")
            rowinfo.Cells(8).Value = row("ItemName")
            rowinfo.Cells(9).Value = row("ProductGroupCode")
            rowinfo.Cells(10).Value = row("SharedType")
        Next
    End Sub


    Private Sub RadMenuButtonItem5_Click(sender As Object, e As EventArgs) Handles RadMenuButtonItem5.Click
        Dim dt As DataTable = GetCustomerItemSharing()

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "CSV files (*.csv)|*.csv"
        saveFileDialog.FileName = "CustomerItemSharing_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ExportDataTableToCSV(dt, saveFileDialog.FileName)
            MessageBox.Show("Export successful!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Public Sub ExportDataTableToCSV(dt As DataTable, filePath As String)
        Using writer As New StreamWriter(filePath)
            ' Write header
            For i As Integer = 0 To dt.Columns.Count - 1
                writer.Write(dt.Columns(i).ColumnName)
                If i < dt.Columns.Count - 1 Then writer.Write(",")
            Next
            writer.WriteLine()

            ' Write rows
            For Each row As DataRow In dt.Rows
                For i As Integer = 0 To dt.Columns.Count - 1
                    Dim columnName As String = dt.Columns(i).ColumnName
                    Dim value As String = row(i).ToString().Replace("""", """""")

                    If columnName = "ShipToCode" Or columnName = "CustomerCode" Then
                        writer.Write("'" & value)  ' Add apostrophe before the value
                    Else
                        writer.Write("""" & value & """")
                    End If

                    If i < dt.Columns.Count - 1 Then
                        writer.Write(",")
                    End If
                Next
                writer.WriteLine()
            Next

        End Using
    End Sub

    Private Sub RadMenuButtonItem1_Click(sender As Object, e As EventArgs) Handles RadMenuButtonItem1.Click
        Dim dt As DataTable = GetCustomerItemSharingProduct()

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "CSV files (*.csv)|*.csv"
        saveFileDialog.FileName = "CustomerItemSharing_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ExportDataTableToCSVProduct(dt, saveFileDialog.FileName)
            MessageBox.Show("Export successful!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Public Sub ExportDataTableToCSVProduct(dt As DataTable, filePath As String)
        Using writer As New StreamWriter(filePath)
            ' Write header
            For i As Integer = 0 To dt.Columns.Count - 1
                writer.Write(dt.Columns(i).ColumnName)
                If i < dt.Columns.Count - 1 Then writer.Write(",")
            Next
            writer.WriteLine()

            ' Write rows
            For Each row As DataRow In dt.Rows
                For i As Integer = 0 To dt.Columns.Count - 1
                    Dim columnName As String = dt.Columns(i).ColumnName
                    Dim value As String = row(i).ToString().Replace("""", """""")

                    If columnName = "ShipToCode" Or columnName = "CustomerCode" Then
                        writer.Write("'" & value)  ' Add apostrophe before the value
                    Else
                        writer.Write("""" & value & """")
                    End If

                    If i < dt.Columns.Count - 1 Then
                        writer.Write(",")
                    End If
                Next
                writer.WriteLine()
            Next

        End Using
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If txtChannelCode.Text <> "" Or txtConfigtypeCode.Text <> "" Then
            SPMSConn.Execute("Exec ValidationViews @ChannelCode = '" & txtChannelCode.Text & "',@ConfigtypeCode = '" & txtConfigtypeCode.Text & "',@Month = '" & DropMonth.Text & "',@Year = '" & DropYear.Text & "'")
            LoadMismatchCustomerItemSharing()
            LoadMismatchCustomerItemSharingProduct()
        End If
    End Sub
End Class
