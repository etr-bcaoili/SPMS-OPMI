Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.WinControls.UI
Imports System.Runtime.Remoting.Channels
Public Class ItemSharingCopyFrom
    Private _ItemSharing As New ItemSharing
    Private m_CustomerItemSharing As New CustomerItemSharing
    Private m_CustomerItemSharingUploading As New CustomerItemSharingUploading
    Private _ConfigurationType As New Configuration
    Private m_Channel As New Distributor
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Dim table As New DataTable
    Private m_TRSCODE As String = String.Empty
    Private Sub Clear()
        txtChannelCode.Text = String.Empty
        txtChannelName.Text = String.Empty
        txtConfigtypeCode.Text = String.Empty
        txtConfigtypeName.Text = String.Empty

        DropYearFrom.Text = String.Empty
        DropYearTo.Text = String.Empty
        DropMonthFrom.Text = String.Empty
        DropMonthTo.Text = String.Empty

    End Sub

    Private Sub btnFinddata_Click(sender As Object, e As EventArgs) Handles btnFinddata.Click
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(CustomerItemSharingUploading.GetItemSharingListSql, "Item Sharing")
        If Not tag Is Nothing Then
            Clear()
            ShowItemSharing(tag.KeyColumn22, tag.KeyColumn33, tag.KeyColumn44, tag.KeyColumn55)
        End If
    End Sub
    Private Sub ShowItemSharing(ByVal ChannelCode As String, ByVal Year As String, ByVal Month As String, ByVal ConfigtypeCode As String)
        table = GetRecords(CustomerItemSharingUploading.GetCustomerItemSharingListSql(ChannelCode, Year, Month, ConfigtypeCode))
        For i As Integer = 0 To table.Rows.Count - 1
            LoadConfigtype(table.Rows(i)("ConfigtypeCode"))
            LoadChannel(table.Rows(i)("ChannelCode"))
            DropYearFrom.Text = table.Rows(i)("Year")
            DropMonthFrom.Text = table.Rows(i)("Month")
            Exit Sub
        Next
    End Sub

    Private Sub ItemSharingCopyFrom_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadYearFrom()
        LoadYearTo()
    End Sub

    Private Sub LoadYearFrom()
        table = GetRecords("Select Distinct CAYR from Calendar Order by CAYR")
        DropYearFrom.Items.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            DropYearFrom.Items.Add(table.Rows(i)("CAYR"))
        Next
    End Sub

    Private Sub LoadMonthFrom(ByVal Year As String)
        table = GetRecords("Select Distinct CAPN from Calendar Where CAYR = '" & Year & "' Order by CAPN")
        DropMonthFrom.Items.Clear()
        For I As Integer = 0 To table.Rows.Count - 1
            DropMonthFrom.Items.Add(table.Rows(I)("CAPN"))
        Next
    End Sub

    Private Sub DropYearFrom_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles DropYearFrom.SelectedIndexChanged
        If DropYearFrom.SelectedIndex = -1 Then Exit Sub
        LoadMonthFrom(DropYearFrom.Text)
    End Sub
    Private Sub LoadYearTo()
        table = GetRecords("Select Distinct CAYR from Calendar Order by CAYR")
        DropYearTo.Items.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            DropYearTo.Items.Add(table.Rows(i)("CAYR"))
        Next
    End Sub
    Private Sub LoadMonthTo(ByVal Year As String)
        table = GetRecords("Select Distinct CAPN from Calendar Where CAYR = '" & Year & "' Order by CAPN")
        DropMonthTo.Items.Clear()
        For I As Integer = 0 To table.Rows.Count - 1
            DropMonthTo.Items.Add(table.Rows(I)("CAPN"))
        Next
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clear()
    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles btnCanced.Click
        Me.Close()
    End Sub

    Private Sub DropYearTo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles DropYearTo.SelectedIndexChanged
        If DropYearTo.SelectedIndex = -1 Then Exit Sub
        LoadMonthTo(DropYearTo.Text)
    End Sub
    Private Sub btnStartProcess_Click(sender As Object, e As EventArgs) Handles btnStartProcess.Click
        If txtConfigtypeCode.Text <> "" Or txtChannelCode.Text <> "" Or DropYearTo.Text <> "" Or DropMonthTo.Text <> "" Then
            CustomerItemSharing.GetResetCopyFromSql(txtConfigtypeCode.Text, txtChannelCode.Text, DropYearTo.Text, DropMonthTo.Text)
            For i As Integer = 0 To table.Rows.Count - 1
                m_CustomerItemSharingUploading = New CustomerItemSharingUploading
                m_CustomerItemSharingUploading.YearFrom = DropYearFrom.Text
                m_CustomerItemSharingUploading.MonthFrom = DropMonthFrom.Text
                m_CustomerItemSharingUploading.YearTo = DropYearTo.Text
                m_CustomerItemSharingUploading.MonthTo = DropMonthTo.Text
                m_CustomerItemSharingUploading.ChannelCode = txtChannelCode.Text
                m_CustomerItemSharingUploading.ConfigtypeCode = txtConfigtypeCode.Text
                m_CustomerItemSharingUploading.CustomerItemSharingCopyFrom()
            Next
            ShowCopyFromSuccessfulDialog()
            'Me.Close()
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Medical Configuration")
        If Not tag Is Nothing Then
            LoadConfigtype(tag.KeyColumn11)
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If txtConfigtypeCode.Text <> "" Then
            Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Distributor.GetDistributorSql, "Search Item")
            If Not tag Is Nothing Then
                LoadChannel(tag.KeyColumn22)
            End If
        End If
    End Sub
    Private Sub LoadConfigtype(ByVal ConfigtypeCode As String)
        _ConfigurationType = Configuration.LoadbyCode(ConfigtypeCode)
        _ConfigurationType.ConfigTypeID = _ConfigurationType.ConfigTypeID
        txtConfigtypeCode.Text = _ConfigurationType.ConfigTypeCode
        txtConfigtypeName.Text = _ConfigurationType.ConfigTypeName
    End Sub
    Private Sub LoadChannel(ByVal ChannelCode As String)
        m_Channel = Distributor.LoadByCode(ChannelCode)
        m_Channel.DISTCOMID = m_Channel.DISTCOMID
        txtChannelCode.Text = m_Channel.DISTCOMID
        txtChannelName.Text = m_Channel.DISTNAME
    End Sub
End Class