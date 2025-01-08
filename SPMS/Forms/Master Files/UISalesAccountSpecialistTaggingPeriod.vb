Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.Windows
Imports Telerik.WinControls
Imports Telerik.Windows.Controls
Imports Telerik.WinControls.UI
Public Class UISalesAccountSpecialistTaggingPeriod
    Private _SalesAccountSpecialist As New SalesAccountSpecialist
    Private _SalesAccountSpecialistCollection As New SalesAccountSpecialistCollection
    Private _SalesAccountSpecialistTagging As New SalesAccountSpecialistTagging
    Private table As New DataTable
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_SASCode As String = String.Empty
    Private m_ConfigtypeCode As String = String.Empty
    Private m_DistrictbutorCode As String = String.Empty
    Private m_DistrictManagerCode As String = String.Empty
    Private m_TerritoryCode As String = String.Empty

    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Sub Clear()
        GrdViewTransaction.Rows.Clear()
        GrdViewDistrictManager.Rows.Clear()
        GrdViewTerritory.Rows.Clear()
        GrdViewCustomer.Rows.Clear()
    End Sub
    Private Sub FindSAS()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(SalesAccountSpecialist.GetSalesAccountSpecialistSql, "Sales Account Specialist")
        If Not tag Is Nothing Then
            m_SASCode = tag.KeyColumn22
            txtEmployeeFirstName.Text = tag.KeyColumn33
        End If
    End Sub

    Private Sub btnFindSAS_Click(sender As Object, e As EventArgs) Handles btnFindSAS.Click
        FindSAS()
    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Medical Configuration")
        If Not tag Is Nothing Then
            m_ConfigtypeCode = tag.KeyColumn11
            txtConfigtypeName.Text = tag.KeyColumn33
        End If
    End Sub
 
    Public Function LastDayOfMonth(ByRef dt As Date, ByVal wd As DayOfWeek) As Date
        Return New Date(dt.Year, dt.Month, Date.DaysInMonth(dt.Year, dt.Month))
    End Function

    Private Sub UISalesAccountSpecialistTaggingPeriod_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.GrdViewDistributor.TableElement.RowHeight = 30
        SalesAccountSpecialistTagging.TruncateTableSalesAccountSpecialistTemp()
    End Sub
    Private Sub LoadDistributor(ByVal ConfigtypeCode As String, ByVal Year As String, Month As String)
        table = GetRecords(SalesAccountSpecialistTagging.GetCompanyListSql(ConfigtypeCode, Year, Month))
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewDistributor.Rows.AddNew
            rowinfo.Cells(0).Value = False
            rowinfo.Cells(1).Value = table.Rows(i)("Distributor Code")
            rowinfo.Cells(2).Value = table.Rows(i)("Distributor Name")
        Next
    End Sub
    Private Sub LoadDistrictManager(ByVal ConfigtypeCode As String, ByVal Year As String, Month As String, ByVal DistributorList As String)
        table = GetRecords(SalesAccountSpecialistTagging.GetDistrictManagerListSql(ConfigtypeCode, Year, Month, DistributorList))
        GrdViewDistrictManager.Rows.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewDistrictManager.Rows.AddNew
            rowinfo.Cells(0).Value = False
            rowinfo.Cells(1).Value = table.Rows(i)("District Manager Code")
            rowinfo.Cells(2).Value = table.Rows(i)("District Manager Name")
        Next
    End Sub

    Private Sub RadMenu1_Click(sender As Object, e As EventArgs) Handles RadMenu1.Click
        If m_ConfigtypeCode = "" Or m_SASCode = "" Then
            ShowExclamationCompleteDetails()
        Else
            ''LoadDistributor(m_ConfigtypeCode, dtStartEffectivity.Value.Year, dtStartEffectivity.Value.Month)
        End If
    End Sub

    Private Sub dtStartEffectivity_ValueChanged(sender As Object, e As EventArgs)
        'If sender Is dtStartEffectivity Then
        '    dtEndEffectivity.Value = LastDayOfMonth(dtStartEffectivity.Value, DayOfWeek.Friday)
        'End If
    End Sub
    Private Sub GrdViewDistrictManager_CellClick(sender As Object, e As GridViewCellEventArgs) Handles GrdViewDistrictManager.CellClick
        Dim SelectedRow As Boolean = False
        Dim concatenatedValues As String = ""
        For m As Integer = 0 To GrdViewDistrictManager.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewDistrictManager.Rows(m)
            If TypeOf rowinfo.Cells(0).Value Is Boolean AndAlso CType(rowinfo.Cells(0).Value, Boolean) Then
                SelectedRow = True
                concatenatedValues &= "'" & rowinfo.Cells(1).Value.ToString() & "', "
            End If
        Next
        If concatenatedValues.Length > 2 Then
            concatenatedValues = concatenatedValues.Substring(0, concatenatedValues.Length - 2)
            m_DistrictManagerCode = concatenatedValues
        End If
        If SelectedRow = True Then
            ''LoadGetTerritorybyDistrictManager(m_ConfigtypeCode, dtStartEffectivity.Value.Year, dtStartEffectivity.Value.Month, m_DistrictbutorCode, m_DistrictManagerCode)
        Else
            GrdViewTerritory.Rows.Clear()
        End If
    End Sub
    Private Sub LoadGetTerritorybyDistrictManager(ByVal ConfigtypeCode As String, ByVal Year As String, Month As String, ByVal DistributorList As String, ByVal DistrictMangerCode As String)
        table = GetRecords(SalesAccountSpecialistTagging.GetTerritoryListSql(ConfigtypeCode, Year, Month, DistributorList, DistrictMangerCode))
        GrdViewTerritory.Rows.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewTerritory.Rows.AddNew
            rowinfo.Cells(0).Value = False
            rowinfo.Cells(1).Value = table.Rows(i)("Territory Manager Code")
            rowinfo.Cells(2).Value = table.Rows(i)("Territory Manager Name")
        Next
    End Sub

    Private Sub GrdViewDistributor_CellClick(sender As Object, e As GridViewCellEventArgs) Handles GrdViewDistributor.CellClick
        Dim SelectedRow As Boolean = False
        Dim concatenatedValues As String = ""
        For m As Integer = 0 To GrdViewDistributor.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewDistributor.Rows(m)
            If TypeOf rowinfo.Cells(0).Value Is Boolean AndAlso CType(rowinfo.Cells(0).Value, Boolean) Then
                SelectedRow = True
                concatenatedValues &= "'" & rowinfo.Cells(1).Value.ToString() & "', "
            End If
        Next
        If concatenatedValues.Length > 2 Then
            concatenatedValues = concatenatedValues.Substring(0, concatenatedValues.Length - 2)
            m_DistrictbutorCode = concatenatedValues
        End If
        If SelectedRow = True Then
            ''LoadDistrictManager(m_ConfigtypeCode, dtStartEffectivity.Value.Year, dtStartEffectivity.Value.Month, concatenatedValues)
        Else
            GrdViewTerritory.Rows.Clear()
        End If
    End Sub
    Private Sub GrdViewDistributor_CellValueChanged(sender As Object, e As GridViewCellEventArgs) Handles GrdViewDistributor.CellValueChanged
        Dim SelectedRow As Boolean = False
        Dim concatenatedValues As String = ""
        For m As Integer = 0 To GrdViewDistributor.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewDistributor.Rows(m)
            If TypeOf rowinfo.Cells(0).Value Is Boolean AndAlso CType(rowinfo.Cells(0).Value, Boolean) Then
                SelectedRow = True
                concatenatedValues &= "'" & rowinfo.Cells(1).Value.ToString() & "', "
            End If
        Next
        If concatenatedValues.Length > 2 Then
            concatenatedValues = concatenatedValues.Substring(0, concatenatedValues.Length - 2)
            m_DistrictbutorCode = concatenatedValues
        End If
        If SelectedRow = True Then
            ' LoadDistrictManager(m_ConfigtypeCode, dtStartEffectivity.Value.Year, dtStartEffectivity.Value.Month, concatenatedValues)
        Else
            GrdViewDistributor.Rows.Clear()
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
         If m_ConfigtypeCode = "" Or m_SASCode = "" Then
            ShowExclamationCompleteDetails()
        Else
            ''LoadDistributor(m_ConfigtypeCode)
        End If
    End Sub

    Private Sub GrdViewDistributor_SelectionChanged(sender As Object, e As EventArgs) Handles GrdViewDistributor.SelectionChanged
        Dim SelectedRow As Boolean = False
        Dim concatenatedValues As String = ""
        For m As Integer = 0 To GrdViewDistributor.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewDistributor.Rows(m)
            If TypeOf rowinfo.Cells(0).Value Is Boolean AndAlso CType(rowinfo.Cells(0).Value, Boolean) Then
                SelectedRow = True
                concatenatedValues &= "'" & rowinfo.Cells(1).Value.ToString() & "', "
            End If
        Next
        If concatenatedValues.Length > 2 Then
            concatenatedValues = concatenatedValues.Substring(0, concatenatedValues.Length - 2)
        End If
        If SelectedRow = True Then
            ''LoadDistrictManager(m_ConfigtypeCode, dtStartEffectivity.Value.Year, dtStartEffectivity.Value.Month, concatenatedValues)
        Else
            GrdViewTerritory.Rows.Clear()
        End If
    End Sub

    Private Sub GrdViewDistrictManager_Click(sender As Object, e As EventArgs) Handles GrdViewDistrictManager.Click
        Dim SelectedRow As Boolean = False
        Dim concatenatedValues As String = ""
        For m As Integer = 0 To GrdViewDistrictManager.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewDistrictManager.Rows(m)
            If TypeOf rowinfo.Cells(0).Value Is Boolean AndAlso CType(rowinfo.Cells(0).Value, Boolean) Then
                SelectedRow = True
                concatenatedValues &= "'" & rowinfo.Cells(1).Value.ToString() & "', "
            End If
        Next
        If concatenatedValues.Length > 2 Then
            concatenatedValues = concatenatedValues.Substring(0, concatenatedValues.Length - 2)
            m_DistrictManagerCode = concatenatedValues
        End If
        If SelectedRow = True Then
            ' LoadGetTerritorybyDistrictManager(m_ConfigtypeCode, dtStartEffectivity.Value.Year, dtStartEffectivity.Value.Month, m_DistrictbutorCode, m_DistrictManagerCode)
        Else
            GrdViewTerritory.Rows.Clear()
        End If
    End Sub

    Private Sub GrdViewTerritory_Click(sender As Object, e As EventArgs) Handles GrdViewTerritory.Click
        Dim SelectedRow As Boolean = False
        Dim concatenatedValues As String = ""
        For m As Integer = 0 To GrdViewTerritory.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewTerritory.Rows(m)
            If TypeOf rowinfo.Cells(0).Value Is Boolean AndAlso CType(rowinfo.Cells(0).Value, Boolean) Then
                SelectedRow = True
                concatenatedValues &= "'" & rowinfo.Cells(1).Value.ToString() & "', "
            End If
        Next
        If concatenatedValues.Length > 2 Then
            concatenatedValues = concatenatedValues.Substring(0, concatenatedValues.Length - 2)
            m_TerritoryCode = concatenatedValues
        End If
        If SelectedRow = True Then
            '' LoadCustomerSAS(m_ConfigtypeCode, dtStartEffectivity.Value.Year, dtStartEffectivity.Value.Month, m_DistrictbutorCode, m_DistrictManagerCode, m_TerritoryCode)
        Else
            GrdViewCustomer.Rows.Clear()
        End If
    End Sub
    Private Sub LoadCustomerSAS(ByVal ConfigtypeCode As String, ByVal Year As String, Month As String, ByVal DistributorList As String, ByVal DistrictMangerCode As String, ByVal TerritoryCode As String)
        table = GetRecords(SalesAccountSpecialistTagging.GetCustomerListSql(ConfigtypeCode, Year, Month, DistributorList, DistrictMangerCode, TerritoryCode))
        GrdViewCustomer.Rows.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewCustomer.Rows.AddNew
            rowinfo.Cells(0).Value = True
            rowinfo.Cells(1).Value = table.Rows(i)("Customer Code")
            rowinfo.Cells(2).Value = table.Rows(i)("Customer Name")
            rowinfo.Cells(3).Value = table.Rows(i)("ShipTo Code")
            rowinfo.Cells(4).Value = table.Rows(i)("Address")
        Next
    End Sub

    Private Sub GrdViewDistributor_Click(sender As Object, e As EventArgs) Handles GrdViewDistributor.Click

    End Sub
End Class
