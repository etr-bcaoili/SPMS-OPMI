Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Imports System.Windows.Forms.Form

Public Class UCNonDataFilesOnSystem
    Private table As New DataTable
    Private tb As New DataTable

    Private Sub UCNonDataFilesOnSystem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadCompanyCode()
    End Sub
    Private Sub loadCompanyCode()
        table = GetRecords("Select * from Distributor where DLTFLG = 0 ")
        For i As Integer = 0 To table.Rows.Count - 1
            cmbCompanyCode.Items.Add(table.Rows(i)("DistComid"))
        Next
    End Sub

    Private Sub cmbCompanyCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompanyCode.SelectedIndexChanged
        If cmbCompanyCode.SelectedIndex = -1 Then Exit Sub
        LoadCompanyName(cmbCompanyCode.Text)
        cmbMonth.Items.Clear()
        LoadMonth(cmbCompanyCode.Text)
    End Sub
    Private Sub LoadCompanyName(ByVal DistributorCode As String)
        table = GetRecords("Select DistName from Distributor where  DistComid = '" & DistributorCode & "'")
        For i As Integer = 0 To table.Rows.Count - 1
            txtCompanyName.Text = table.Rows(i)("DistName")
        Next
    End Sub
    Private Sub LoadMonth(ByVal DistricCode As String)
        table = GetRecords("Select Distinct CAPN  from Calendar where COMID = '" & DistricCode & "' order by CAPN")
        For i As Integer = 0 To table.Rows.Count - 1
            cmbMonth.Items.Add(table.Rows(i)("CAPN"))
        Next
    End Sub

    Private Sub cmbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedIndexChanged
        If cmbMonth.SelectedIndex = -1 Then Exit Sub
        cmbyear.Items.Clear()
        LoadMonths(cmbMonth.Text)
        LoadYear(cmbCompanyCode.Text)
    End Sub
    Private Sub LoadYear(ByVal DistributorCode As String)
        Table = GetRecords("Select Distinct Cayr from Calendar where comid = '" & DistributorCode & "'")
        For i As Integer = 0 To Table.Rows.Count - 1
            cmbyear.Items.Add(Table.Rows(i)("CAYR"))
        Next
    End Sub
    Private Sub LoadMonths(ByVal Month As String)
        table = GetRecords("Select Distinct CAPN,MonthDescription   from Calendar where CAPN = '" & Month & "' Order by CAPN")
        For i As Integer = 0 To table.Rows.Count - 1
            txtMonthName.Text = table.Rows(i)("MonthDescription")
        Next
    End Sub

    Private Sub btnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheck.Click
        LoadCustomerNotSystem()
    End Sub
    Private Sub LoadCustomerNotSystem()
        Connect()
        Dim cmd As New SqlCommand("uspNotInCustomerToSharing")
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@Action", "CustomerNotInSystem")
        cmd.Parameters.AddWithValue("@CompanyCode", cmbCompanyCode.Text)
        cmd.Parameters.AddWithValue("@Month", cmbMonth.Text)
        cmd.Parameters.AddWithValue("@Year", cmbyear.Text)
        Dim da As New SqlDataAdapter(cmd)
        tb = New DataTable
        da.Fill(tb)
        GridCustomer.Rows.Clear()
        If tb.Rows.Count > 0 Then
            For m As Integer = 0 To tb.Rows.Count - 1
                Dim dr As DataRow = tb.Rows(m)
                Dim row As DataGridViewRow = GridCustomer.Rows(GridCustomer.Rows.Add)
                row.Cells(ColCustomerNumber.Index).Value = dr("CustomerNumber")
                row.Cells(ColShiptoCustomerName.Index).Value = dr("ShiptoName")
                row.Cells(ColShiptoAddress.Index).Value = dr("ShipToAddress1")
                row.Cells(colshipToaddress2.Index).Value = dr("ShipToAddress2")
            Next
        End If
    End Sub

End Class
