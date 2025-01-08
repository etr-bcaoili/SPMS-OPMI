Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ucMasterRegion
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule

Public Class FindSalesManager
    Private b_ManagerCode As String = ""
    Private b_ManagerName As String = ""

    Public Property ManagerCode() As String
        Get
            Return b_ManagerCode
        End Get
        Set(ByVal value As String)
            b_ManagerCode = value
        End Set
    End Property

    Public Property ManagerName() As String
        Get
            Return b_ManagerName
        End Get
        Set(ByVal value As String)
            b_ManagerName = value
        End Set
    End Property

    Private GridRs As New ADODB.Recordset
    Private Sub OpenListing()
        If GridRs.State = 1 Then GridRs.Close()
        

        GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        GridRs.Open("SELECT * FROM STSALESMANAGER WHERE DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        DataGridView1.Rows.Clear()
        If GridRs.RecordCount > 0 Then
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = DataGridView1.Rows(DataGridView1.Rows.Add)
                row.Cells(SalesManagerCode.Index).Value = GridRs.Fields("STSLSMGRCD").Value
                row.Cells(SalesManagerName.Index).Value = GridRs.Fields("STSLSMGRNAME").Value
                GridRs.MoveNext()
            Next


        End If
    End Sub

    Private Sub FindSalesManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        OpenListing()
        ApplyGridTheme(DataGridView1)
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        ManagerCode = row.Cells(SalesManagerCode.Index).Value
        ManagerName = row.Cells(SalesManagerName.Index).Value
        Me.Dispose()
    End Sub
End Class