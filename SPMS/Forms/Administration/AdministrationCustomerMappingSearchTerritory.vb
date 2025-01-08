Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class AdministrationCustomerMappingSearchTerritory
    Private b_ReturnTerrCode As String = ""
    Private b_ReturnTerrName As String = ""



    Public Property ReturnTerrCode() As String
        Get
            Return b_ReturnTerrCode
        End Get
        Set(ByVal value As String)
            b_ReturnTerrCode = value
        End Set
    End Property

    Public Property ReturnTerrName() As String
        Get
            Return b_ReturnTerrName
        End Get
        Set(ByVal value As String)
            b_ReturnTerrName = value
        End Set
    End Property

    

    Private Sub TransactionSalesSharingSearchTerritory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ApplyGridTheme(dgDetail)
    End Sub

    Public Sub PopulateGrid()
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rs.Open("select distinct stterrcd, stacovname, stslsmnname from salesmatrix where dltflg = 0   order by stterrcd, stacovname", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        rs.Open("select STACOVCD,STACOVNAME from STAREACOVERAGE where dltflg = 0   order by STACOVCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgDetail.Rows.Clear()
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim row As DataGridViewRow = dgDetail.Rows(dgDetail.Rows.Add)

                row.Cells(colAreaCoverageCode.Index).Value = rs.Fields("STACOVCD").Value
                row.Cells(colAreaCoverageName.Index).Value = rs.Fields("STACOVNAME").Value
                rs.MoveNext()
            Next
        End If
    End Sub


    Private Sub dgDetail_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dgDetail_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellDoubleClick
        Dim row As DataGridViewRow = dgDetail.Rows(e.RowIndex)


        ReturnTerrCode = row.Cells(colAreaCoverageCode.Index).Value
        ReturnTerrName = row.Cells(colAreaCoverageName.Index).Value
        Me.Close()
    End Sub

End Class