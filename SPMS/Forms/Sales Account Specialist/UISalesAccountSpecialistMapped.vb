
Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports Telerik.WinControls.UI
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports Infragistics.Win.FormattedLinkLabel
Imports DataLayer
Imports SPMSOPCI.MainWindow
Public Class UISalesAccountSpecialistMapped
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private Table As DataTable

    Private m_ConfigtypeCode As String = String.Empty
    Private _CompanyCodes As String = String.Empty

    Private _SalesAccountSpecialist As New SalesAccountSpecialist
    Private _DistrictAssignment As New DistrictAssignment
    Private _SalesAccountSpecialistTagging As New SalesAccountSpecialistTagging
    Private _SalesAccountSpecialistProcess As New SalesAccountSpecialistProcess

    Private Sub Clear()
        txtSalesAccountCode.Text = String.Empty
        txtSalesmanAccountName.Text = String.Empty
    End Sub
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode
        btnApplyDistrict.Enabled = IsEditMode
        btnApplyArea.Enabled = IsEditMode

        txtSalesAccountCode.ReadOnly = Not IsEditMode
        txtSalesAccountCode.BackColor = Color.White

        txtSalesmanAccountName.ReadOnly = Not IsEditMode
        txtSalesmanAccountName.BackColor = Color.White
    End Sub
    Private Sub NewRecord()
        Clear()
        EditMode(True)
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnDelete.Click, btnEdit.Click, btnFinddata.Click, btnSave.Click, btnClear.Click, btnClose.Click
        If sender Is btnNew Then
            NewRecord()
        ElseIf sender Is btnClose Then
            Close()
        ElseIf sender Is btnFinddata Then
            ''Find()
        ElseIf sender Is btnSave Then
            'If ValidateData() Then
            '    SaveRecord()
            'End If
        End If
    End Sub
    Private Sub FindSAS()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(SalesAccountSpecialist.GetSalesAccountSpecialistMappedSql, "Sales Account Specialist")
        If Not tag Is Nothing Then
            txtSalesAccountCode.Text = tag.KeyColumn22
            txtSalesmanAccountName.Text = tag.KeyColumn33
            m_ConfigtypeCode = tag.KeyColumn44
        End If
    End Sub
    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Sub Findconfig_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Findconfig.LinkClicked
        FindSAS()
        LoadSASTarget()
        LoadChannel(m_ConfigtypeCode)
    End Sub
    Private Sub LoadSASTarget()
        Table = GetRecords(SASDistrictTaget.LoadSASDistrictSQL)
        GrdViewDistrictProperty.Rows.Clear()
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewDistrictProperty.Rows.AddNew
            rowinfo.Cells(0).Value = False
            rowinfo.Cells(1).Value = Table.Rows(i)("DistrictCode")
            rowinfo.Cells(2).Value = Table.Rows(i)("STDISTRCTNAME")
            rowinfo.Cells(3).Value = Table.Rows(i)("TargetAmount")
        Next
    End Sub
    Private Sub UISalesAccountSpecialistMapped_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadSASTarget()
    End Sub
    Private Sub ShowDataChannelbySAS(ByVal SASCode As String)
        Table = GetRecords(SalesAccountSpecialistTagging.GetSalesAccountSpecialistChannelbySASSql(SASCode))
        GrdViewChannel.Rows.Clear()
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfoChannel As GridViewRowInfo = GrdViewChannel.Rows.AddNew
            rowinfoChannel.Cells(0).Value = Table.Rows(i)("CheckIn")
            rowinfoChannel.Cells(1).Value = Table.Rows(i)("ChannelCode")
            rowinfoChannel.Cells(2).Value = Table.Rows(i)("DISTNAME")
        Next
    End Sub
    Private Sub GrdViewChannel_CellEndEdit(sender As Object, e As GridViewCellEventArgs) Handles GrdViewChannel.CellEndEdit
        For m As Integer = 0 To GrdViewChannel.Rows.Count - 1
            Dim rowinfos As GridViewRowInfo = GrdViewChannel.Rows(m)
            If rowinfos.Cells(0).Value = True Then
                '''ShowAreaName(rowinfos.Cells(1).Value)
            End If
        Next
    End Sub

    Private Sub btnApplyDistrict_Click(sender As Object, e As EventArgs) Handles btnApplyDistrict.Click
        GrdViewAreaName.Rows.Clear()
        For m As Integer = 0 To GrdViewDistrictProperty.Rows.Count - 1
            Dim rowinfos As GridViewRowInfo = GrdViewDistrictProperty.Rows(m)
            If rowinfos.Cells(0).Value = True Then
                ShowAreaName(rowinfos.Cells(1).Value)
                CountRowActive()
            End If
        Next
    End Sub
    Private Sub LoadChannel(ByVal ConfigtypeCode As String)
        Table = GetRecords(SalesAccountSpecialistTagging.GetChannelSql(ConfigtypeCode))
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewChannel.Rows.AddNew
            rowinfo.Cells(0).Value = False
            rowinfo.Cells(1).Value = Table.Rows(i)("Distributor Code")
            rowinfo.Cells(2).Value = Table.Rows(i)("Distributor Name")
        Next
    End Sub

    Private Sub ShowAreaName(ByVal DistrictGroupCode As String)
        Table = GetRecords(SalesAccountSpecialistTagging.GetSalesAccountSpecialAreaNameSql(DistrictGroupCode, m_ConfigtypeCode))
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewAreaName.Rows.AddNew
            rowinfo.Cells(0).Value = False
            rowinfo.Cells(1).Value = Table.Rows(i)("STDISTRCTNAME")
            rowinfo.Cells(2).Value = Table.Rows(i)("STACOVNAME")
            rowinfo.Cells(3).Value = "0.00"
            rowinfo.Cells(4).Value = Table.Rows(i)("DistrictGroup")
            CountRowActive()
        Next
    End Sub

    Private Sub btnApplyArea_Click(sender As Object, e As EventArgs) Handles btnApplyArea.Click
        GrdViewCustomer.Rows.Clear()
        Dim companyCode As New List(Of String)
        For m As Integer = 0 To GrdViewAreaName.Rows.Count - 1
            Dim rowAreaName As GridViewRowInfo = GrdViewAreaName.Rows(m)
            If rowAreaName.Cells(0).Value = True Then
                ShowCustomersWithChannel(rowAreaName.Cells(2).Value, _CompanyCodes, rowAreaName.Cells(3).Value, rowAreaName.Cells(4).Value, rowAreaName.Cells(1).Value)
            End If
        Next
    End Sub
    Private Sub ShowCustomersWithChannel(ByVal AreaName As String, ByVal ChannelCode As String, ByVal TargetAmount As Decimal, ByVal DistrictGroup As String, ByVal DistrictName As String)
        Table = GetRecords(SalesAccountSpecialistTagging.GetSalesAccountSpecialCustomerWithChannelSql(AreaName, ChannelCode, m_ConfigtypeCode))
        Dim TotalCount As Integer = Table.Rows.Count
        Dim TargetAmountAll As Decimal = "0.00"
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfoCustomer As GridViewRowInfo = GrdViewCustomer.Rows.AddNew
            rowinfoCustomer.Cells(0).Value = True
            rowinfoCustomer.Cells(1).Value = Table.Rows(i)("STACOVNAME")
            rowinfoCustomer.Cells(2).Value = Table.Rows(i)("Customer Code")
            rowinfoCustomer.Cells(3).Value = Table.Rows(i)("Customer Name")
            rowinfoCustomer.Cells(4).Value = Math.Round(TargetAmount / TotalCount, 2)
            rowinfoCustomer.Cells(5).Value = Table.Rows(i)("Distributor Code")
            rowinfoCustomer.Cells(6).Value = DistrictGroup
            rowinfoCustomer.Cells(7).Value = DistrictName
        Next
    End Sub
    Private Sub CountRowActive()
        Dim activeCount As Integer = 0
        Dim DistrictTargetAmount As Decimal = 0
        Dim AreaTargetAmount As Decimal = 0
        Dim CustomerAmount As Decimal = 0
        If GrdViewDistrictProperty.Rows.Count <> 0 Then
            Dim Num1 As Integer = 0
            For m As Integer = 0 To GrdViewDistrictProperty.Rows.Count - 1
                Dim rowfoDistrict As GridViewRowInfo = GrdViewDistrictProperty.Rows(m)
                If rowfoDistrict.Cells(0).Value = True Then

                End If
            Next
            btnApplyDistrict.Enabled = True
            btnUnCheck.Enabled = True
        End If
        If GrdViewChannel.Rows.Count <> 0 Then
            Dim Num2 As Integer = 0
            _CompanyCodes = String.Empty
            For m As Integer = 0 To GrdViewChannel.Rows.Count - 1
                Dim rowfoChannel As GridViewRowInfo = GrdViewChannel.Rows(m)
                If rowfoChannel.Cells(0).Value = True Then
                    Dim companyCode As String = rowfoChannel.Cells(1).Value.ToString()
                    If _CompanyCodes <> "" Then
                        _CompanyCodes &= ","  ' Add a comma between company codes
                    End If
                    _CompanyCodes &= "'" & companyCode & "'"  ' Add company code to the string
                End If
            Next
        End If
        If GrdViewAreaName.Rows.Count <> 0 Then
            Dim Num3 As Integer = 0
            For m As Integer = 0 To GrdViewAreaName.Rows.Count - 1
                Dim rowfoAreaName As GridViewRowInfo = GrdViewAreaName.Rows(m)
                If rowfoAreaName.Cells(0).Value = True Then
                End If
            Next
            btnApplyArea.Enabled = True
            btnUncheckArea.Enabled = True
        End If
        If GrdViewCustomer.Rows.Count <> 0 Then
            Dim Num4 As Integer = 0
            For m As Integer = 0 To GrdViewCustomer.Rows.Count - 1
                Dim rowfoCustomer As GridViewRowInfo = GrdViewCustomer.Rows(m)
                If rowfoCustomer.Cells(0).Value = True Then
                End If
            Next
        End If
    End Sub
End Class
