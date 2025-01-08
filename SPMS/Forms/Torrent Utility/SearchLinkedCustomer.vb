Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.GlobalFunctionsModule

Public Class SearchLinkedCustomer
    Private b_Query As String = "'"
    Private b_Recordset As ADODB.Recordset
    Private dt As New DataTable

    Public Property Query() As String
        Get
            Return b_Query
        End Get
        Set(ByVal value As String)
            b_Query = value
        End Set
    End Property


    Public Property Recordset() As ADODB.Recordset
        Get
            Return b_Recordset
        End Get
        Set(ByVal value As ADODB.Recordset)
            b_Recordset = value
        End Set
    End Property

    Public Sub PopulateGrid(ByVal rs As ADODB.Recordset)
        If b_Query <> "" Then
            If rs.RecordCount > 0 Then
                Dim da As New OleDb.OleDbDataAdapter

                dt.Clear()
                da.Fill(dt, rs)
                dgData.DataSource = dt
                dgData.Refresh()
            End If
        End If
    End Sub

    Private Function OpenListing(Optional ByVal filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If filter <> "" Then
            filter = " AND " & filter
        End If

        rs.Open(b_Query & filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


        Return rs
    End Function

    Private Sub dgData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgData.CellContentClick

    End Sub

    Private Sub txtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged
        If cboColumns.Text <> "" Then

        End If
    End Sub



End Class