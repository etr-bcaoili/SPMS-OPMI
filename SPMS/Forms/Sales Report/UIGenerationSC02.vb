
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Text
Imports Telerik.WinControls.UI
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Text.RegularExpressions
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI.Export
Imports Microsoft.Office.Interop
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports System.IO
Public Class UIGenerationSC02
    Private m_HasError As Boolean = False
    Private m_Err As New ErrorProvider
    Dim table As New DataTable
    Dim dt As SqlDataReader
    Dim m_Year As DateTime = DateTime.Now
    Private m_OverViewData As New OverviewData

    Private Sub Clear()
        txtConfigName.Text = String.Empty
    End Sub
    Private Sub loadViewConfig()
        table = GetRecords("Select * from ConfigurationType")
        For i As Integer = 0 To table.Rows.Count - 1
            cmbConfig.Items.Add(table.Rows(i)("ConfigTypeCode"))
            txtConfigName.Text = table.Rows(i)("ConfigTypeName")
        Next
    End Sub
    Private Sub LoadItemDivision(ByVal ConfigtypeCode As String)
        Dim myYear As Int32 = m_Year.Year
        table = GetRecords(OverviewData.GetItemDivision(ConfigtypeCode, myYear))
        GrdItemDivision.Rows.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdItemDivision.Rows.AddNew
            rowinfo.Cells(0).Value = False
            rowinfo.Cells(1).Value = table.Rows(i)("Item Division Code")
            rowinfo.Cells(2).Value = table.Rows(i)("Item Division Description")
        Next
    End Sub

    Private Sub UIGenerationSC02_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadViewConfig()
        Clear()
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To GrdItemDivision.Rows.Count - 1
            GrdItemDivision.Rows(m).Cells(0).Value = True
        Next
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To GrdItemDivision.Rows.Count - 1
            GrdItemDivision.Rows(m).Cells(0).Value = False
        Next
    End Sub

    Private Sub cmbConfig_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbConfig.SelectedIndexChanged
        GetConfigName(cmbConfig.Text)
        LoadItemDivision(cmbConfig.Text)
    End Sub
    Private Sub GetConfigName(ByVal configcode As String)
        table = GetRecords("Select * from ConfigurationType where ConfigTypeCode = '" & cmbConfig.Text & "'")
        For i As Integer = 0 To table.Rows.Count - 1
            txtConfigName.Text = table.Rows(i)("ConfigTypeName")
        Next
    End Sub

    Private Sub RadMenuButtonItem2_Click(sender As Object, e As EventArgs) Handles RadMenuButtonItem2.Click
        If TabControl1.SelectedIndex = 0 Then
            TabControl1.SelectedTab = TabPage2
            LoadDistrictManager()
            GrdDistrictManager.AutoExpandGroups = True
        ElseIf TabControl1.SelectedIndex = 1 Then
            TabControl1.SelectTab(TabPage3)
            LoadTerritoryManager()
            GrdTerritory.AutoExpandGroups = True
        ElseIf TabControl1.SelectedIndex = 2 Then
            TabControl1.SelectTab(TabPage4)
        End If
    End Sub
    Private Sub LoadDistrictManager()
        Dim myYear As Int32 = m_Year.Year
        Try
            For m As Integer = 0 To GrdItemDivision.Rows.Count - 1
                Dim rowinfo As GridViewRowInfo = GrdItemDivision.Rows(m)
                If rowinfo.Cells(0).Value = True Then
                    table = GetRecords(OverviewData.GetDistrictManager(cmbConfig.Text, rowinfo.Cells(1).Value, myYear))
                    For i As Integer = 0 To table.Rows.Count - 1
                        Dim rowInfos As GridViewRowInfo = GrdDistrictManager.Rows.AddNew
                        rowInfos.Cells(0).Value = False
                        rowInfos.Cells(1).Value = table.Rows(i)("Item Division Code")
                        rowInfos.Cells(2).Value = table.Rows(i)("District Manager Code")
                        rowInfos.Cells(3).Value = table.Rows(i)("District Manager Name")
                    Next
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadTerritoryManager()
        Dim myYear As Int32 = m_Year.Year
        Try
            For m As Integer = 0 To GrdDistrictManager.Rows.Count - 1
                Dim rowinfo As GridViewRowInfo = GrdDistrictManager.Rows(m)
                If rowinfo.Cells(0).Value = True Then
                    table = GetRecords(OverviewData.GetTerritoryManager(cmbConfig.Text, rowinfo.Cells(1).Value, rowinfo.Cells(2).Value, myYear))
                    For i As Integer = 0 To table.Rows.Count - 1
                        Dim rowinfos As GridViewRowInfo = GrdTerritory.Rows.AddNew
                        rowinfos.Cells(0).Value = False
                        rowinfos.Cells(1).Value = table.Rows(i)("Item Division Code")
                        rowinfos.Cells(2).Value = table.Rows(i)("District Manager Code")
                        rowinfos.Cells(3).Value = table.Rows(i)("Territory Manager Code")
                        rowinfos.Cells(4).Value = table.Rows(i)("Territory Manager Name")
                    Next
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub RadMenuButtonItem1_Click(sender As Object, e As EventArgs) Handles RadMenuButtonItem1.Click
        If TabControl1.SelectedIndex = 3 Then
            TabControl1.SelectedTab = TabPage3
        ElseIf TabControl1.SelectedIndex = 2 Then
            TabControl1.SelectedTab = TabPage2
            GrdTerritory.Rows.Clear()
        ElseIf TabControl1.SelectedIndex = 1 Then
            TabControl1.SelectTab(TabPage1)
            GrdDistrictManager.Rows.Clear()
        End If
    End Sub

    Private Sub LinkLabel6_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        For m As Integer = 0 To GrdItemDivision.Rows.Count - 1
            GrdItemDivision.Rows(m).Cells(0).Value = True
        Next
    End Sub

    Private Sub LinkLabel5_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        For m As Integer = 0 To GrdItemDivision.Rows.Count - 1
            GrdItemDivision.Rows(m).Cells(0).Value = False
        Next
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        For m As Integer = 0 To GrdDistrictManager.Rows.Count - 1
            GrdDistrictManager.Rows(m).Cells(0).Value = True
        Next
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        For m As Integer = 0 To GrdDistrictManager.Rows.Count - 1
            GrdDistrictManager.Rows(m).Cells(0).Value = False
        Next
    End Sub

    Private Sub LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        For m As Integer = 0 To GrdTerritory.Rows.Count - 1
            GrdTerritory.Rows(m).Cells(0).Value = True
        Next
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        For m As Integer = 0 To GrdTerritory.Rows.Count - 1
            GrdTerritory.Rows(m).Cells(0).Value = False
        Next
    End Sub

    Private Sub RadMenuButtonItem3_Click(sender As Object, e As EventArgs) Handles RadMenuButtonItem3.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        OverviewData.ResetOverview()
        Dim myYear As Int32 = m_Year.Year
        RadWaitingBar2.Visible = True
        If GrdTerritory.Rows.Count <> 0 Then
            For m As Integer = 0 To GrdTerritory.Rows.Count - 1
                Dim rowinfo As GridViewRowInfo = GrdTerritory.Rows(m)
                If rowinfo.Cells(0).Value = True Then
                    m_OverViewData.ConfigtypeCopde = cmbConfig.Text
                    m_OverViewData.Year = myYear
                    m_OverViewData.ItemDivisionCode = rowinfo.Cells(1).Value
                    m_OverViewData.DistrictManagerCode = rowinfo.Cells(2).Value
                    m_OverViewData.TerritoryManagerCode = rowinfo.Cells(3).Value
                    m_OverViewData.InsertIntoSalesOverView()
                End If
            Next
            Dim FormOverViewSales As New UIActivityOverview
            FormOverViewSales.Show()
            Me.Close()
        End If
        RadWaitingBar2.Visible = False
    End Sub
End Class