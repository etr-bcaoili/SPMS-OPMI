Imports SPMSOPCI.ConnectionModule
Public Class UCItemGrid
    Private m_RsItem As New ADODB.Recordset
    Private dt As New DataTable

    Public Event ItemSelected(ByVal ItemCode As String, ByVal ItemDescription As String)
    Public Sub InitializeControl()
        LoadItems()
    End Sub


    Private Sub LoadItems(Optional ByVal Condiition As String = "")
        If m_RsItem.State = 1 Then m_RsItem.Close()
        OpenConnection()
        m_RsItem.Open("SELECT * FROM Item WHERE ITEMDEL = 0" & IIf(Condiition <> "", " AND " & Condiition, ""), SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsItem.RecordCount > 0 Then
            'Dim da As New OleDb.OleDbDataAdapter
            'dt = New DataTable
            'da.Fill(dt, m_RsItem)
            LoadGrid(m_RsItem)
        End If
    End Sub

    Private Sub FilterItems()
        Dim FilterString As String = ""
        If txtItemCode.Text <> "" Then
            FilterString &= " ITEMCD like '%" & HandleSingleQuoteInSql(txtItemCode.Text) & "%'"
        End If
        If txtItemDescription.Text <> "" Then
            If FilterString <> "" Then FilterString &= " AND "
            FilterString &= " IMDBRN like '%" & HandleSingleQuoteInSql(txtItemDescription.Text) & "%'"
        End If
        LoadItems(FilterString)
    End Sub

    Private Sub LoadGrid(ByVal rs As ADODB.Recordset)

        dgItemGrid.Rows.Clear()
        For m As Integer = 0 To rs.RecordCount - 1
            Dim row As DataGridViewRow = dgItemGrid.Rows(dgItemGrid.Rows.Add)
            row.Cells(colItemCode.Index).Value = rs.Fields("ItemCD").Value
            row.Cells(colItemDesc.Index).Value = rs.Fields("IMDBRN").Value
            rs.MoveNext()
        Next

    End Sub

    Private Sub dgItemGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItemGrid.CellContentClick

    End Sub

    Private Sub dgItemGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItemGrid.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub

        Dim row As DataGridViewRow = dgItemGrid.Rows(e.RowIndex)
        RaiseEvent ItemSelected(row.Cells(colItemCode.Index).Value, row.Cells(colItemDesc.Index).Value)
    End Sub


    Private Sub UCItemGrid_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(dgItemGrid)
        dgItemGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub txtItemCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemCode.TextChanged, txtItemDescription.TextChanged
        FilterItems()
    End Sub

    Private Sub dgItemGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgItemGrid.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            If dgItemGrid.CurrentRow.Index = -1 Then Exit Sub
            Dim row As DataGridViewRow = dgItemGrid.Rows(dgItemGrid.CurrentRow.Index - 1)
            RaiseEvent ItemSelected(row.Cells(colItemCode.Index).Value, row.Cells(colItemDesc.Index).Value)
        End If
    End Sub
End Class
