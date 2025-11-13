Imports SPMSOPCI.ConnectionModule
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports System.IO
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class FrmProductPerChannelCopyFrom
    Private table As New DataTable
    Private m_Err As New ErrorProvider
    Private _Distributor As New Distributor
    Private m_HasError As Boolean = False
    Private Sub lnkMotherCode_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkMotherCode.LinkClicked
        LoadChannel()
    End Sub
    Private Sub LoadChannel()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(DistributorItemPrices.GetProductItemCopyFromSql, "Distributor")
        If Not tag Is Nothing Then
            ShowDataDistributor(tag.KeyColumn11)
            dtStartFrom.Value = tag.KeyColumn33
            dtEndFrom.Value = tag.KeyColumn44
        End If
    End Sub
    Private Sub ShowDataDistributor(ByVal RecordCode As String)
        _Distributor = Distributor.LoadByCode(RecordCode)
        txtChannelCode.Tag = _Distributor.DISTRIBUTORID
        txtChannelCode.Text = _Distributor.DISTCOMID
        txtChannelName.Text = _Distributor.DISTNAME
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If txtChannelCode.Text <> "" And txtChannelName.Text <> "" Then
            If CheckofDistributorExist(txtChannelCode.Text, dtStartFrom.Text, dtEndFrom.Text) <> True Then
                'ChannelItemPrice()
            Else
                    GenerateCopyFrom(txtChannelCode.Text, dtStartFrom.Text, dtEndFrom.Text, dtToStart.Text, dtToEnd.Text)
                    CompyFromPriceSuccess()
                End If
            End If
    End Sub
  
    Private Function GenerateCopyFrom(ByVal CompanyCode As String, ByVal StartFrom As Date, ByVal EndFrom As Date, ByVal StartTo As Date, ByVal EndTo As Date)
        m_HasError = False
        Try
            Connect()
            Dim cmd As SqlCommand = New SqlCommand("uspDistributorChannelCopyFrom", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Generate")
            cmd.Parameters.AddWithValue("@Companycode", CompanyCode)
            cmd.Parameters.AddWithValue("@StartFrom", StartFrom)
            cmd.Parameters.AddWithValue("@EndFrom", EndFrom)
            cmd.Parameters.AddWithValue("@StartTo", StartTo)
            cmd.Parameters.AddWithValue("@EndTo", EndTo)
            cmd.ExecuteNonQuery()
            Disconnect()
        Catch ex As Exception
            Disconnect()
            m_HasError = True
        End Try
        Return Not m_HasError
    End Function
    Public Shared Function CheckofDistributorExist(ByVal Code As String, ByVal StartDate As Date, ByVal EndDate As Date) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM DISTRIBUTORITEMS WHERE isActive = 1  And  Comid = '" & RefineSQL(Code) & "' And EffectivityStartDate = '" & StartDate & "' And EffectivityEndDate = '" & EndDate & "'") = "A"
    End Function
    Public Function LastDayOfMonth(ByRef dt As Date, ByVal wd As DayOfWeek) As Date
        Return New Date(dt.Year, dt.Month, Date.DaysInMonth(dt.Year, dt.Month))
    End Function

    Private Sub ValueChangeCalendar(sender As Object, e As EventArgs) Handles dtStartFrom.ValueChanged, dtToStart.ValueChanged
        If sender Is dtStartFrom Then
            dtEndFrom.Value = LastDayOfMonth(dtStartFrom.Value, DayOfWeek.Friday)
        ElseIf sender Is dtToStart Then
            dtToEnd.Value = LastDayOfMonth(dtToStart.Value, DayOfWeek.Friday)
        End If
    End Sub
End Class