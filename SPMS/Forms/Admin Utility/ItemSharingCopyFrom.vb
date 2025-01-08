Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.WinControls.UI
Public Class ItemSharingCopyFrom
    Private _ItemSharing As New ItemSharing
    Private m_CustomerItemSharing As New CustomerItemSharing
    Private _ConfigurationType As New Configuration

    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Dim table As New DataTable
    Private m_TRSCODE As String = String.Empty
    Private Sub Clear()
        txtItemCode.Text = String.Empty
        txtItemName.Text = String.Empty
        txtConfigCode.Text = String.Empty
        txtConfgName.Text = String.Empty

        DropYearFrom.Text = String.Empty
        DropYearTo.Text = String.Empty
        DropMonthFrom.Text = String.Empty
        DropMonthTo.Text = String.Empty

    End Sub

    Private Sub btnFinddata_Click(sender As Object, e As EventArgs) Handles btnFinddata.Click
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(CustomerItemSharing.GetItemSharingListSql, "Item Sharing")
        If Not tag Is Nothing Then
            Clear()
            ShowItemSharing(tag.KeyColumn22, tag.KeyColumn55, tag.KeyColumn33, tag.KeyColumn44)
        End If
    End Sub
    Private Sub ShowItemSharing(ByVal ConfigtypeCode As String, ByVal ItemCode As String, ByVal Year As String, ByVal Month As String)
        table = GetRecords(CustomerItemSharing.GetItemSharingListbyOneSQl(ConfigtypeCode, ItemCode, Year, Month))
        For i As Integer = 0 To table.Rows.Count - 1
            txtConfigCode.Text = table.Rows(i)("ConfigtypeCode")
            txtConfgName.Text = table.Rows(i)("ConfigTypeName")
            txtItemCode.Text = table.Rows(i)("ITEMCODE")
            txtItemName.Text = table.Rows(i)("IMDBRN")
            DropYearFrom.Text = table.Rows(i)("Year")
            DropMonthFrom.Text = table.Rows(i)("Month")
            Exit Sub
        Next
    End Sub

    Private Sub ItemSharingCopyFrom_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadYearFrom()
        LoadYearTo
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
    Private Sub NewTransaction()
        m_TRSCODE = "TR-" & SystemSequences.GetMedicalDoctorSequence
    End Sub

    Private Sub btnStartProcess_Click(sender As Object, e As EventArgs) Handles btnStartProcess.Click
        If txtConfigCode.Text <> "" Or txtItemCode.Text <> "" Or DropYearTo.Text <> "" Or DropMonthTo.Text <> "" Then
            CustomerItemSharing.GetResetCopyFromSql(txtConfigCode.Text, txtItemCode.Text, DropYearTo.Text, DropMonthTo.Text)
            table = GetRecords(CustomerItemSharing.GetCustomerItemSharingSQL(txtConfigCode.Text, txtItemCode.Text, DropYearFrom.Text, DropMonthFrom.Text))
            For i As Integer = 0 To table.Rows.Count - 1
                m_CustomerItemSharing = New CustomerItemSharing
                NewTransaction()
                m_CustomerItemSharing.YearFrom = DropYearFrom.Text
                m_CustomerItemSharing.MonthFrom = DropMonthFrom.Text
                m_CustomerItemSharing.YearTo = DropYearTo.Text
                m_CustomerItemSharing.MonthTo = DropMonthTo.Text
                m_CustomerItemSharing.ItemCode = txtItemCode.Text
                m_CustomerItemSharing.ConfigtypeCode = txtConfigCode.Text
                m_CustomerItemSharing.TRSCODE = m_TRSCODE
                m_CustomerItemSharing.CustomerItemSharingCopyFrom()
            Next
            ShowCopyFromSuccessfulDialog()
            Me.Close()
        End If
    End Sub
End Class