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
Public Class UIDMICTerritoryManagerPeriodToPeriodPivot
    Dim table As New DataTable
    Private _Distributor As New Distributor
    Private _ExportSourceData As New ExportSourceData

    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False


    Private Sub UIDMICTerritoryManagerPeriodToPeriodPivot_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.GrdCompanyView.TableElement.RowHeight = 40
        Me.GridView.TableElement.RowHeight = 40
        LoadDistributor()
        LoadCalendarFromMonth()
        LoadCalendarToMonth()
        LoadCalendarYear()
    End Sub
    Private Sub LoadDistributor()
        table = GetRecords(Distributor.GetDistributorSql)
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdCompanyView.Rows.AddNew
            rowinfo.Cells(0).Value = False
            rowinfo.Cells(1).Value = table.Rows(i)("Company Code")
            rowinfo.Cells(2).Value = table.Rows(i)("Description")
        Next
    End Sub
    Private Sub LoadCalendarYear()
        Try
            table = GetRecords("SELECT DISTINCT CAYR FROM Calendar where Comid = '" & GetDefaultCompany() & "' Order by CAYR")
            For i As Integer = 0 To table.Rows.Count - 1
                cmdYear.Items.Add(table.Rows(i)("CAYR"))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadCalendarFromMonth()
        Try
            table = GetRecords("Select Distinct CAPN From Calendar Where Comid = '" & GetDefaultCompany() & "' Order by CAPN")
            For i As Integer = 0 To table.Rows.Count - 1
                cmdFromMonth.Items.Add(table.Rows(i)("CAPN"))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadCalendarToMonth()
        Try
            table = GetRecords("Select Distinct CAPN From Calendar Where Comid = '" & GetDefaultCompany() & "' Order by CAPN")
            For i As Integer = 0 To table.Rows.Count - 1
                cmdToMonth.Items.Add(table.Rows(i)("CAPN"))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Findconfig_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Findconfig.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Configuration")
        If Not tag Is Nothing Then
            txtConfigCode.Text = tag.KeyColumn11
            txtConfgName.Text = tag.KeyColumn33
        End If
    End Sub


    Private Sub btnTransfered_Click(sender As Object, e As EventArgs) Handles btnTransfered.Click
        If GrdCompanyView.RowCount <> 0 Or txtConfigCode.Text = "" Or cmdFromMonth.Text = "" Or cmdYear.Text = "" Then
            For i As Integer = 0 To GrdCompanyView.Rows.Count - 1
                Dim rowinfo As GridViewRowInfo = GrdCompanyView.Rows(i)
                If rowinfo.Cells(0).Value = True Then
                    _ExportSourceData.ConfigtypeCode = txtConfigCode.Text
                    _ExportSourceData.FromMonth = cmdFromMonth.Text
                    _ExportSourceData.ToMonth = cmdToMonth.Text
                    _ExportSourceData.Year = cmdYear.Text
                    _ExportSourceData.CompanyCode = rowinfo.Cells(1).Value
                    _ExportSourceData.DMCustomerTerritoryComparativePeriodtoPeriodNetVATMTDM()
                End If
            Next
            TransferSuccess()
            LoadDMCustomerTerritoryComparativePeriodtoPeriodNetVATMTDM(cmdYear.Text, cmdFromMonth.Text, cmdToMonth.Text, txtConfigCode.Text)
        End If
    End Sub
    Private Sub LoadDMCustomerTerritoryComparativePeriodtoPeriodNetVATMTDM(ByVal Year As String, ByVal StartMonth As String, ByVal EndMonth As String, ByVal ConfigtypeCode As String)
        table = GetRecords(_ExportSourceData.DMCustomerTerritoryComparativePeriodtoPeriodNetVATMTDM(Year, StartMonth, EndMonth, ConfigtypeCode))
        GridView.DataSource = table
        GridView.Columns(0).Width = 120
        GridView.Columns(1).Width = 120
        GridView.Columns(2).Width = 120
        GridView.Columns(3).Width = 120
        GridView.Columns(4).Width = 120
        GridView.Columns(5).Width = 120
        GridView.Columns(6).Width = 120
        GridView.Columns(7).Width = 120
        GridView.Columns(8).Width = 120
        GridView.Columns(9).Width = 120
        GridView.Columns(10).Width = 120
        GridView.Columns(11).Width = 120
        GridView.Columns(12).Width = 120
        GridView.Columns(13).Width = 120
        GridView.Columns(14).Width = 120
        GridView.Columns(15).Width = 120
        GridView.Columns(16).Width = 120
        GridView.Columns(17).Width = 120
        GridView.Columns(18).Width = 120
        GridView.Columns(19).Width = 120
        GridView.Columns(20).Width = 120
        GridView.Columns(21).Width = 120
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        GridView.Rows.Clear()
        txtConfgName.Text = String.Empty
        txtConfigCode.Text = String.Empty
        cmdFromMonth.Text = String.Empty
        cmdYear.Text = String.Empty
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
End Class
