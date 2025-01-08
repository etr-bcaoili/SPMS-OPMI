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
Public Class UISalesExportSourceData
    Private _Distributor As New Distributor
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Dim table As New DataTable
    Dim dt As SqlDataReader
    Private _ExportSourceData As New ExportSourceData
    Private Sub lnkDistributorCode_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDistributorCode.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Configuration")
        If Not tag Is Nothing Then
            txtConfigtypeCode.Text = tag.KeyColumn11
            txtConfigtypeName.Text = tag.KeyColumn33
        End If
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

    Private Sub UISalesExportSourceData_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.GrdCompanyView.TableElement.RowHeight = 45
        Me.GridView.TableElement.RowHeight = 45
        LoadDistributor()
        LoadCalendarFromMonth()
        LoadCalendarToMonth()
        LoadCalendarYear()
    End Sub
    Private Sub btnTransfered_Click(sender As Object, e As EventArgs) Handles btnTransfered.Click
        If GrdCompanyView.RowCount <> 0 Then
            For i As Integer = 0 To GrdCompanyView.Rows.Count - 1
                Dim rowinfo As GridViewRowInfo = GrdCompanyView.Rows(i)
                If rowinfo.Cells(0).Value = True Then
                    _ExportSourceData.ConfigtypeCode = txtConfigtypeCode.Text
                    _ExportSourceData.FromMonth = cmdFromMonth.Text
                    _ExportSourceData.ToMonth = cmdToMonth.Text
                    _ExportSourceData.Year = cmdYear.Text
                    _ExportSourceData.LastYear = cmdYear.Text - 1
                    _ExportSourceData.CompanyCode = rowinfo.Cells(1).Value
                    _ExportSourceData.TrasnferData()
                End If
            Next
            TransferSuccess()
            LoadTransferData()
        End If
    End Sub
    Private Sub LoadTransferData()
        For i As Integer = 0 To GrdCompanyView.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdCompanyView.Rows(i)
            If rowinfo.Cells(0).Value = True Then
                Try
                    SPMSOPCI.ConnectionModule.Connect()
                    Dim cmd As SqlCommand = New SqlCommand("uspSourceDataView", SPMSOPCI.ConnectionModule.SPMSConn2)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@Action", "ViewTable")
                    cmd.Parameters.AddWithValue("@Year", cmdYear.Text)
                    cmd.Parameters.AddWithValue("@FromMonth", cmdFromMonth.Text)
                    cmd.Parameters.AddWithValue("@ToMonth", cmdToMonth.Text)
                    cmd.Parameters.AddWithValue("@ConfigtypeCode", txtConfigtypeCode.Text)
                    cmd.Parameters.AddWithValue("@ChannelCode", rowinfo.Cells(1).Value)
                    DataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    dt = DataReader
                    Do While DataReader.Read = True
                        Dim rowinfos As GridViewRowInfo = GridView.Rows.AddNew
                        rowinfos.Cells(0).Value = dt(0)
                        rowinfos.Cells(1).Value = dt(1)
                        rowinfos.Cells(2).Value = dt(2)
                        rowinfos.Cells(3).Value = dt(3)
                        rowinfos.Cells(4).Value = dt(4)
                        rowinfos.Cells(5).Value = dt(5)
                        rowinfos.Cells(6).Value = dt(6)
                        rowinfos.Cells(7).Value = dt(7)
                        rowinfos.Cells(8).Value = dt(8)
                        rowinfos.Cells(9).Value = dt(9)
                        rowinfos.Cells(10).Value = dt(10)
                        rowinfos.Cells(11).Value = dt(11)
                        rowinfos.Cells(12).Value = dt(12)
                        rowinfos.Cells(13).Value = dt(13)
                        rowinfos.Cells(14).Value = dt(14)
                        rowinfos.Cells(15).Value = dt(15)
                        rowinfos.Cells(16).Value = dt(16)
                        rowinfos.Cells(17).Value = dt(17)
                        rowinfos.Cells(18).Value = dt(18)
                    Loop
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Next
    End Sub

    Private Sub btnFinddata_Click(sender As Object, e As EventArgs) Handles btnFinddata.Click
        If txtConfigtypeCode.Text = "" Then
            MessageBox.Show("Please see set the parameter details", "Invalid Select", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            GridView.Rows.Clear()
            LoadTransferData()
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        GridView.Rows.Clear()
        txtConfigtypeCode.Text = String.Empty
        txtConfigtypeName.Text = String.Empty
        cmdFromMonth.Text = String.Empty
        cmdToMonth.Text = String.Empty
        cmdYear.Text = String.Empty
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        For i As Integer = 0 To GrdCompanyView.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdCompanyView.Rows(i)
            If rowinfo.Cells(0).Value = True Then
                _ExportSourceData.ConfigtypeCode = txtConfigtypeCode.Text
                _ExportSourceData.FromMonth = cmdFromMonth.Text
                _ExportSourceData.ToMonth = cmdToMonth.Text
                _ExportSourceData.Year = cmdYear.Text
                _ExportSourceData.LastYear = cmdYear.Text - 1
                _ExportSourceData.CompanyCode = rowinfo.Cells(1).Value
                _ExportSourceData.TrasnferDelete()
                TransferSuccessDeleted()
                LoadTransferData()
            End If
        Next
    End Sub

    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
End Class
