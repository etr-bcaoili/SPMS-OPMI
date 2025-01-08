Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Public Class frmItemModifieldSales
    Private _ConfigurationType As New Configuration
    Private _ItemModifiedSales As New ItemModifiedSales
    Private _ItemCode As String = String.Empty
    Private _ItemMotherCode As String = String.Empty
    Public Property ItemCode As String
        Get
            Return _ItemCode
        End Get
        Set(value As String)
            _ItemCode = value
        End Set
    End Property
    Public Property ItemMotherCode As String
        Get
            Return _ItemMotherCode
        End Get
        Set(value As String)
            _ItemMotherCode = value
        End Set
    End Property
    Private Sub Findconfig_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Findconfig.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Medical Configuration")
        If Not tag Is Nothing Then
            txtConfigCode.Text = tag.KeyColumn11
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If txtConfigCode.Text <> "" Or txtItemCode.Text <> "" Or txtItemMotherCode.Text <> "" Then
            If ShowUpdateItemModifiedSalesDialog() = DialogResult.Yes Then
                _ItemModifiedSales.ConfigtypeCode = txtConfigCode.Text
                _ItemModifiedSales.ItemCode = txtItemCode.Text
                _ItemModifiedSales.ItemMotherCode = txtItemMotherCode.Text
                _ItemModifiedSales.Year = cmbStartYear.Text
                _ItemModifiedSales.Month = cmbStartMonth.Text
                _ItemModifiedSales.Save()
                ItemModifiedsalesSuccess()
            Else
                UnItemModifiedsalesSuccess()
            End If
        End If
    End Sub

    Private Sub frmItemModifieldSales_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtItemCode.Text = ItemCode
        txtItemMotherCode.Text = ItemMotherCode
        PopulateComboBox()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub PopulateComboBox()
        Dim rs As New ADODB.Recordset
        cmbStartYear.Items.Clear()
        cmbStartMonth.Items.Clear()
        'for the year   
        rs = RsGpiCalendarYear()
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbStartYear.Items.Add(rs.Fields("cayr").Value)
                rs.MoveNext()
            Next
        End If
    End Sub
    Private Function RsGpiCalendarYear(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If
        rs.Open("SELECT DISTINCT CAYR FROM CALENDAR WHERE COMID = '" & ConnectionModule.GetDefaultCompany & "' " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs
    End Function

    Private Sub cmbStartYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStartYear.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
            cmbStartMonth.Items.Clear()
            rs = RsGpiCalendarMonth("CAYR = '" & cmbStartYear.Text & "' ")
            If rs.RecordCount > 0 Then
                For i As Integer = 1 To rs.RecordCount
                    cmbStartMonth.Items.Add(rs.Fields("CAPN").Value)
                    rs.MoveNext()
                Next
            End If
    End Sub
    Private Function RsGpiCalendarMonth(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If
        rs.Open("SELECT DISTINCT CAPN FROM CALENDAR WHERE COMID = '" & ConnectionModule.GetDefaultCompany & "' " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs
    End Function
End Class