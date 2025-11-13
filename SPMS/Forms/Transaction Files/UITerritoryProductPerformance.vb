Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class UITerritoryProductPerformance
    Private _ConfigurationType As New Configuration
    Dim table As New DataTable
    Private _ExportSourceData As New ExportSourceData

    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False

    Private Sub Findconfig_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Findconfig.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Medical Configuration")
        If Not tag Is Nothing Then
            txtConfigCode.Text = tag.KeyColumn11
            txtConfgName.Text = tag.KeyColumn33
        End If
    End Sub

    Private Sub UITerritoryProductPerformance_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadCalendarYear()
        LoadCalendarFromMonth()
        LoadCalendarToMonth()
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

    Private Sub btnTransfered_Click(sender As Object, e As EventArgs) Handles btnTransfered.Click
        If txtConfigCode.Text = "" Or cmdFromMonth.Text = "" Or cmdYear.Text = "" Then
            MessageBox.Show("Please see set the parameter details", "Invalid Select", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            table = GetRecords(_ExportSourceData.GetMonthReport(txtConfigCode.Text, cmdYear.Text, cmdFromMonth.Text, cmdToMonth.Text))
            For i As Integer = 0 To table.Rows.Count - 1
                _ExportSourceData.ConfigtypeCode = txtConfigCode.Text
                _ExportSourceData.FromMonth = table.Rows(i)("Month")
                _ExportSourceData.Year = cmdYear.Text
                _ExportSourceData.TrasnferDataTerritoryPerformance()
            Next
            TransferSuccess()
            LoadTransferDataTerritory(cmdFromMonth.Text, cmdToMonth.Text, txtConfigCode.Text)
        End If
    End Sub
    Private Sub LoadTransferDataTerritory(ByVal Month As String, ByVal ToMonth As String, ByVal ConfigtypeCode As String)
        table = GetRecords(_ExportSourceData.TransferDatabyTerritorybyPivot(Month, ToMonth, ConfigtypeCode))
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
        GridView.Columns(22).Width = 120
        GridView.Columns(23).Width = 120
        GridView.Columns(24).Width = 120
        GridView.Columns(25).Width = 120
        GridView.Columns(26).Width = 120
        GridView.Columns(27).Width = 120
        GridView.Columns(28).Width = 120
        GridView.Columns(29).Width = 120
        GridView.Columns(30).Width = 120
        GridView.Columns(31).Width = 120
        GridView.Columns(32).Width = 120
        GridView.Columns(33).Width = 120
        GridView.Columns(34).Width = 120
        GridView.Columns(35).Width = 120
        GridView.Columns(36).Width = 120
        GridView.Columns(37).Width = 120
        GridView.Columns(38).Width = 120
        GridView.Columns(39).Width = 120
        GridView.Columns(40).Width = 120
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

    Private Sub cmdFromMonth_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles cmdFromMonth.SelectedIndexChanged

    End Sub
End Class
