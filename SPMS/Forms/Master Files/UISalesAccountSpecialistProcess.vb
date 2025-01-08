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
Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.Dialogs
Public Class UISalesAccountSpecialistProcess
    Private m_Err As New ErrorProvider
    Private m_Action As String = ""
    Private m_HasError As Boolean = False

    Private m_EmployeeCode As String = String.Empty
    Private m_EmployeeID As String = String.Empty
    Private m_SalesAccountSpecialistCollection As New SalesAccountSpecialistCollection
    Private m_SalesAccountSpecialist As New SalesAccountSpecialist
    Private m_ConfigtypeCode As New Configuration
    Private table As New DataTable
    Private m_concatenatedValues As String = String.Empty
    Private m_concatenatedValuesDistributorCode As String = String.Empty
    Private m_concatenatedValuesterritory As String = String.Empty
    Private m_CustomerSASincomplate As String = String.Empty
    Private m_EffectivityStartDate As Date = "1/1/1900"
    Private m_EffectivityEndDate As Date = "1/1/1900"

    Public Property EmployeeCode As String
        Get
            Return m_EmployeeCode
        End Get
        Set(value As String)
            m_EmployeeCode = value
        End Set
    End Property
    Public Property EmployeeID As String
        Get
            Return m_EmployeeID
        End Get
        Set(value As String)
            m_EmployeeID = value
        End Set
    End Property

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If TabControl1.SelectedIndex = 0 Then
            TabControl1.SelectedTab = TabPage1
        ElseIf TabControl1.SelectedIndex = 5 Then
            TabControl1.SelectedTab = TabPage1
        ElseIf TabControl1.SelectedIndex = 4 Then
            TabControl1.SelectedTab = TabPage5
        ElseIf TabControl1.SelectedIndex = 3 Then
            TabControl1.SelectedTab = TabPage4
        ElseIf TabControl1.SelectedIndex = 2 Then
            TabControl1.SelectedTab = TabPage3
        ElseIf TabControl1.SelectedIndex = 1 Then
            TabControl1.SelectTab(TabPage1)
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If TabControl1.SelectedIndex = 0 Then
            If ValidateData() Then
                TabControl1.SelectedTab = TabPage3
                LoadDistributorAndbyConfigtype(txtConfigCode.Text)
            End If
        ElseIf TabControl1.SelectedIndex = 1 Then
            TabControl1.SelectTab(TabPage4)
            LoadDistributorbyTerritoryAndConfigtype(txtConfigCode.Text)
        ElseIf TabControl1.SelectedIndex = 2 Then
            TabControl1.SelectTab(TabPage5)
            LoadDistrictManagerAndConfigtypeCodeAndTerritory(txtConfigCode.Text)
        ElseIf TabControl1.SelectedIndex = 3 Then
            TabControl1.SelectTab(TabPage7)
            ProcessSAS()
        End If
    End Sub

    Private Sub UISalesAccountSpecialistProcess_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadEmployee(m_EmployeeCode)
    End Sub
    Private Sub LoadEmployee(ByVal EmployeeCode As String)
        table = GetRecords(SalesAccountSpecialist.GetSalesAccountSpecialistbyEmployeeSql(EmployeeCode))
        For i As Integer = 0 To table.Rows.Count - 1
            m_EmployeeID = table.Rows(i)("SalesAccountSpecialistID")
            txtEmployeeCode.Text = table.Rows(i)("EmployeeCode")
            m_EmployeeCode = table.Rows(i)("SalesAccountSpecialistID")
            txtEmployeeFullName.Text = table.Rows(i)("Full Name")
            m_EffectivityStartDate = table.Rows(i)("EffectivityStartDate")
            m_EffectivityEndDate = table.Rows(i)("EffectivityEndDate")
            Exit Sub
        Next
    End Sub
    Private Sub LoadEmployeeAndDistrictManager(ByVal EmployeeCode As String)
        table = GetRecords(SalesAccountSpecialistCollection.GetSalesAccountSpecialistICollection(EmployeeCode))
        GrdViewDistrictManager.Rows.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfos As GridViewRowInfo = GrdViewDistrictManager.Rows.AddNew
            rowinfos.Cells(0).Value = True
            rowinfos.Cells(1).Value = table.Rows(i)("DistrictManagerCode")
            rowinfos.Cells(2).Value = table.Rows(i)("DistrictManagerName")
        Next
    End Sub
    Private Sub LoadDistributorAndbyConfigtype(ByVal ConfigtypeCode As String)
        Dim SelectedRow As Boolean = False
        table = GetRecords(SalesAccountSpecialistCollection.GetSalesAccountSpecialistICollection(EmployeeCode))
        For i As Integer = 0 To table.Rows.Count - 1
            SelectedRow = True
            m_concatenatedValues &= "'" & table.Rows(i)("DistrictManagerCode") & "', "
        Next
        If m_concatenatedValues.Length > 2 Then
            m_concatenatedValues = m_concatenatedValues.Substring(0, m_concatenatedValues.Length - 2)
        End If
        If SelectedRow = True Then
            LoadDistributorAndbyConfigtypeExtension(m_concatenatedValues, txtConfigCode.Text)
        Else
            GrdViewDistrictManager.Rows.Clear()
        End If
    End Sub
    Private Sub LoadDistributorbyTerritoryAndConfigtype(ByVal ConfigtypeCode As String)
        Dim SelectedRow As Boolean = False
        table = GetRecords(SalesAccountSpecialistCollection.GetSalesAccountSpecialistICollection(EmployeeCode))
        'For i As Integer = 0 To table.Rows.Count - 1
        '    SelectedRow = True
        '    m_concatenatedValues &= "'" & table.Rows(i)("DistrictManagerCode") & "', "
        'Next
        'If m_concatenatedValues.Length > 2 Then
        '    m_concatenatedValues = m_concatenatedValues.Substring(0, m_concatenatedValues.Length - 2)
        'End If

        For m As Integer = 0 To GrdViewDistributor.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewDistributor.Rows(m)
            If rowinfo.Cells(0).Value = True Then
                SelectedRow = True
                m_concatenatedValuesDistributorCode &= "'" & rowinfo.Cells(1).Value.ToString() & "', "
            End If
        Next
        If m_concatenatedValuesDistributorCode.Length > 2 Then
            m_concatenatedValuesDistributorCode = m_concatenatedValuesDistributorCode.Substring(0, m_concatenatedValuesDistributorCode.Length - 2)
        End If

        If SelectedRow = True Then
            LoadTerrorybyDistrictManager(m_concatenatedValues, txtConfigCode.Text, m_concatenatedValuesDistributorCode)
        Else
            GrdViewDistributor.Rows.Clear()
        End If
    End Sub
    Private Sub LoadDistrictManagerAndConfigtypeCodeAndTerritory(ByVal ConfigtypeCode As String)
        Dim SelectedRow As Boolean = False
        m_concatenatedValues = String.Empty
        m_concatenatedValuesDistributorCode = String.Empty
        m_concatenatedValuesterritory = String.Empty

        table = GetRecords(SalesAccountSpecialistCollection.GetSalesAccountSpecialistICollection(EmployeeCode))
        For i As Integer = 0 To table.Rows.Count - 1
            SelectedRow = True
            m_concatenatedValues &= "'" & table.Rows(i)("DistrictManagerCode") & "', "
        Next
        If m_concatenatedValues.Length > 2 Then
            m_concatenatedValues = m_concatenatedValues.Substring(0, m_concatenatedValues.Length - 2)
        End If

        For m As Integer = 0 To GrdViewDistributor.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewDistributor.Rows(m)
            If TypeOf rowinfo.Cells(0).Value Is Boolean AndAlso CType(rowinfo.Cells(0).Value, Boolean) Then
                SelectedRow = True
                m_concatenatedValuesDistributorCode &= "'" & rowinfo.Cells(1).Value.ToString() & "', "
            End If
        Next
        If m_concatenatedValuesDistributorCode.Length > 2 Then
            m_concatenatedValuesDistributorCode = m_concatenatedValuesDistributorCode.Substring(0, m_concatenatedValuesDistributorCode.Length - 2)
        End If

        For m As Integer = 0 To GrdViewPMR.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewPMR.Rows(m)
            If TypeOf rowinfo.Cells(0).Value Is Boolean AndAlso CType(rowinfo.Cells(0).Value, Boolean) Then
                SelectedRow = True
                m_concatenatedValuesterritory &= "'" & rowinfo.Cells(1).Value.ToString() & "', "
            End If
        Next
        If m_concatenatedValuesterritory.Length > 2 Then
            m_concatenatedValuesterritory = m_concatenatedValuesterritory.Substring(0, m_concatenatedValuesterritory.Length - 2)
        End If

        If SelectedRow = True Then
            LoadCustomerList(m_concatenatedValues, txtConfigCode.Text, m_concatenatedValuesterritory, m_concatenatedValuesDistributorCode)
        End If
    End Sub
    Private Sub ProcessSAS()
        Dim SelectedRow As Boolean = False
        m_concatenatedValues = String.Empty
        m_concatenatedValuesDistributorCode = String.Empty
        m_concatenatedValuesterritory = String.Empty
        m_CustomerSASincomplate = String.Empty
        table = GetRecords(SalesAccountSpecialistCollection.GetSalesAccountSpecialistICollection(EmployeeCode))
        For i As Integer = 0 To table.Rows.Count - 1
            SelectedRow = True
            m_concatenatedValues &= "'" & table.Rows(i)("DistrictManagerCode") & "', "
        Next
        If m_concatenatedValues.Length > 2 Then
            m_concatenatedValues = m_concatenatedValues.Substring(0, m_concatenatedValues.Length - 2)
        End If

        For m As Integer = 0 To GrdViewDistributor.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewDistributor.Rows(m)
            If TypeOf rowinfo.Cells(0).Value Is Boolean AndAlso CType(rowinfo.Cells(0).Value, Boolean) Then
                SelectedRow = True
                m_concatenatedValuesDistributorCode &= "'" & rowinfo.Cells(1).Value.ToString() & "', "
            End If
        Next
        If m_concatenatedValuesDistributorCode.Length > 2 Then
            m_concatenatedValuesDistributorCode = m_concatenatedValuesDistributorCode.Substring(0, m_concatenatedValuesDistributorCode.Length - 2)
        End If

        For m As Integer = 0 To GrdViewPMR.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewPMR.Rows(m)
            If TypeOf rowinfo.Cells(0).Value Is Boolean AndAlso CType(rowinfo.Cells(0).Value, Boolean) Then
                SelectedRow = True
                m_concatenatedValuesterritory &= "'" & rowinfo.Cells(1).Value.ToString() & "', "
            End If
        Next
        If m_concatenatedValuesterritory.Length > 2 Then
            m_concatenatedValuesterritory = m_concatenatedValuesterritory.Substring(0, m_concatenatedValuesterritory.Length - 2)
        End If


        For m As Integer = 0 To GrdViewCustomer.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewCustomer.Rows(m)
            If TypeOf rowinfo.Cells(0).Value Is Boolean AndAlso CType(rowinfo.Cells(0).Value, Boolean) Then
                SelectedRow = True
                m_CustomerSASincomplate &= "'" & rowinfo.Cells(1).Value.ToString() & "', "
            End If
        Next
        If m_CustomerSASincomplate.Length > 2 Then
            m_CustomerSASincomplate = m_CustomerSASincomplate.Substring(0, m_CustomerSASincomplate.Length - 2)
        End If


    End Sub
    Private Sub LoadDistributorAndbyConfigtypeExtension(ByVal DistrinctManagerCode As String, ByVal ConfigtypeCode As String)
        GrdViewDistributor.Rows.Clear()
        table = GetRecords(SalesAccountSpecialistCollection.GetSalesAccountSpecialistDistributor(DistrinctManagerCode, ConfigtypeCode))
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfos As GridViewRowInfo = GrdViewDistributor.Rows.AddNew
            rowinfos.Cells(0).Value = True
            rowinfos.Cells(1).Value = table.Rows(i)("Distributor Code")
            rowinfos.Cells(2).Value = table.Rows(i)("Distributor Name")
        Next
    End Sub
    Private Sub LoadTerrorybyDistrictManager(ByVal DistrinctManagerCode As String, ByVal ConfigtypeCode As String, ByVal DistributorCode As String)
        GrdViewPMR.Rows.Clear()
        table = GetRecords(SalesAccountSpecialistCollection.GetSalesAccountSpecialistTerritorybyDistrictManager(DistrinctManagerCode, ConfigtypeCode, DistributorCode))
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfos As GridViewRowInfo = GrdViewPMR.Rows.AddNew
            rowinfos.Cells(0).Value = True
            rowinfos.Cells(1).Value = table.Rows(i)("Territory Manager Code")
            rowinfos.Cells(2).Value = table.Rows(i)("Territory Manager Name")
            rowinfos.Cells(3).Value = table.Rows(i)("Territory Name")
        Next
    End Sub
    Private Sub LoadCustomerList(ByVal DistrinctManagerCode As String, ByVal ConfigtypeCode As String, ByVal TerritoryCode As String, ByVal DistributorCode As String)
        GrdViewCustomer.Rows.Clear()
        table = GetRecords(SalesAccountSpecialistCollection.GetSalesAccountSpecialistCustomer(DistrinctManagerCode, ConfigtypeCode, TerritoryCode, DistributorCode))
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfos As GridViewRowInfo = GrdViewCustomer.Rows.AddNew
            rowinfos.Cells(0).Value = True
            rowinfos.Cells(1).Value = table.Rows(i)("Customer Code")
            rowinfos.Cells(2).Value = table.Rows(i)("Customer Name")
            rowinfos.Cells(3).Value = table.Rows(i)("Address")
        Next
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Medical Configuration")
        If Not tag Is Nothing Then
            txtConfigCode.Text = tag.KeyColumn11
            txtConfgName.Text = tag.KeyColumn33
        End If
    End Sub
    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False
        If SalesAccountSpecialistCollection.CheckSalesAccountSpecialistIsAlreadyExist(txtEmployeeCode.Text, txtConfigCode.Text, m_EffectivityStartDate, m_EffectivityEndDate) Then
            If ShowIsAlreadyExist() = DialogResult.Yes Then
                m_HasError = False
            Else
                m_HasError = True
            End If
        End If
        Return Not m_HasError
    End Function

    Private Sub LinkLabel10_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        If IsDBNull(m_concatenatedValues) And IsDBNull(m_concatenatedValuesDistributorCode) And IsDBNull(m_concatenatedValuesterritory) = True Then
            MessageBox.Show("Please complete the Selection data", "Invalid Generate")
        Else
            radWaitingBar.Visible = True
            radWaitingBar.StartWaiting()
            m_SalesAccountSpecialistCollection.EmployeeCode = txtEmployeeCode.Text
            m_SalesAccountSpecialistCollection.ConfigtypeCode = txtConfigCode.Text
            m_SalesAccountSpecialistCollection.DistrictManagerCodeMultipleValue = m_concatenatedValues
            m_SalesAccountSpecialistCollection.DistributorCodeMultipleValue = m_concatenatedValuesDistributorCode
            m_SalesAccountSpecialistCollection.CustomerCodeMultipleValue = m_CustomerSASincomplate
            m_SalesAccountSpecialistCollection.SASGetInsert()
            radWaitingBar.StopWaiting()
            radWaitingBar.Visible = False
            MessageBox.Show("Successfull Generate SAS", "Successfully")
            TabControl1.SelectTab(TabPage1)
        End If
    End Sub

    Private Sub btnhistory_Click(sender As Object, e As EventArgs) Handles btnhistory.Click
        TabControl1.SelectTab(TabPage2)
        LoadSASGetProcess(txtEmployeeCode.Text)
    End Sub
    Private Sub LoadSASGetProcess(ByVal EmployeeCode As String)
        Me.GrdViewhistoricalRecord.TableElement.RowHeight = 35
        GrdViewhistoricalRecord.Rows.Clear()
        table = GetRecords(SalesAccountSpecialistCollection.GetSalesAccountSpecialistRecord(EmployeeCode))
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfos As GridViewRowInfo = GrdViewhistoricalRecord.Rows.AddNew
            rowinfos.Cells(0).Value = table.Rows(i)("EmployeeCode")
            rowinfos.Cells(1).Value = table.Rows(i)("EffectivityStartDate")
            rowinfos.Cells(2).Value = table.Rows(i)("EffectivityEndDate")
            rowinfos.Cells(3).Value = table.Rows(i)("ConfigtypeCode")
        Next
    End Sub

    Private Sub GrdViewhistoricalRecord_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles GrdViewhistoricalRecord.CellDoubleClick
        For m As Integer = 0 To GrdViewhistoricalRecord.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewhistoricalRecord.Rows(m)
            m_SalesAccountSpecialist = SalesAccountSpecialist.LoadByCode(rowinfo.Cells(0).Value)
            txtEmployeeCode.Text = m_SalesAccountSpecialist.EmployeeCode
            txtEmployeeFullName.Text = m_SalesAccountSpecialist.EmployeeLastName & " ," & m_SalesAccountSpecialist.EmployeeFirstName & " " & m_SalesAccountSpecialist.EmployeeMeddleName
            m_ConfigtypeCode = Configuration.LoadbyCode(rowinfo.Cells(3).Value)
            txtConfigCode.Text = m_ConfigtypeCode.ConfigTypeCode
            txtConfgName.Text = m_ConfigtypeCode.ConfigTypeName
            TabControl1.SelectTab(TabPage1)
            Exit Sub
        Next
    End Sub
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If IsDBNull(m_concatenatedValues) And IsDBNull(m_concatenatedValuesDistributorCode) And IsDBNull(m_concatenatedValuesterritory) = True Then
            MessageBox.Show("Please complete the Selection data", "Invalid Generate")
        Else
            radWaitingBar.Visible = True
            radWaitingBar.StartWaiting()
            SalesAccountSpecialist.GetSalesAccountSpecialistSql()
            m_SalesAccountSpecialistCollection.EmployeeCode = txtEmployeeCode.Text
            m_SalesAccountSpecialistCollection.ConfigtypeCode = txtConfigCode.Text
            m_SalesAccountSpecialistCollection.DistrictManagerCodeMultipleValue = m_concatenatedValues
            m_SalesAccountSpecialistCollection.DistributorCodeMultipleValue = m_concatenatedValuesDistributorCode
            m_SalesAccountSpecialistCollection.TerritoryCodeMultipleValues = m_concatenatedValuesterritory
            m_SalesAccountSpecialistCollection.CustomerCodeMultipleValue = m_CustomerSASincomplate
            m_SalesAccountSpecialistCollection.EffectivityStartDate = m_EffectivityStartDate
            m_SalesAccountSpecialistCollection.EffectivityEndDate = m_EffectivityEndDate
            m_SalesAccountSpecialistCollection.SASGetInsert()
            radWaitingBar.StopWaiting()
            radWaitingBar.Visible = False
            MessageBox.Show("Successfull Generate SAS", "Successfully")
            TabControl1.SelectTab(TabPage1)
        End If
    End Sub

    Private Sub LinkLabel4_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(SalesAccountSpecialist.GetSalesAccountSpecialistSql, "Sales Account Specialist")
        If Not tag Is Nothing Then
            ShowDataSAS(tag.KeyColumn11)
        End If
    End Sub
    Private Sub ShowDataSAS(ByVal RecordCode As String)
        LoadEmployee(RecordCode)
    End Sub

    Private Sub LinkLabel3_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Medical Configuration")
        If Not tag Is Nothing Then
            txtConfigCode.Text = tag.KeyColumn11
            txtConfgName.Text = tag.KeyColumn33
        End If
    End Sub
End Class