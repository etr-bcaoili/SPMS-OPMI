Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule

Public Class TransactionSalesSharingSearchTerritory

    Private b_ReturnTerrCode As String = ""
    Private b_ReturnTerrName As String = ""
    Private b_ReturnAgenCode As String = ""
    Private b_ReturnAgenName As String = ""


    Public Property ReturnAgentCode() As String
        Get
            Return b_ReturnAgenCode
        End Get
        Set(ByVal value As String)
            b_ReturnAgenCode = value
        End Set
    End Property

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

    Public Property ReturnAgentName() As String
        Get
            Return b_ReturnAgenName
        End Get
        Set(ByVal value As String)
            b_ReturnAgenName = value
        End Set
    End Property

    Private Sub TransactionSalesSharingSearchTerritory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ApplyGridTheme(dgDetail)
    End Sub

    Public Sub PopulateGrid(ByVal ItemDivisionCode As String)
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("select * from salesmatrix where dltflg = 0  and stitmdivcd = '" & ItemDivisionCode & "' order by stterrcd, stacovname", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgDetail.Rows.Clear()
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim row As DataGridViewRow = dgDetail.Rows(dgDetail.Rows.Add)

                row.Cells(colTerritoryCode.Index).Value = rs.Fields("stterrcd").Value
                row.Cells(colTerritoryName.Index).Value = rs.Fields("stacovname").Value
                row.Cells(colMR.Index).Value = rs.Fields("stslsmnname").Value
                row.Cells(colMRCode.Index).Value = rs.Fields("stslsmncd").Value
                rs.MoveNext()
            Next
        End If
    End Sub


    Private Sub dgDetail_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dgDetail_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellDoubleClick
        Dim row As DataGridViewRow = dgDetail.Rows(e.RowIndex)

        ReturnAgentName = row.Cells(colMR.Index).Value
        ReturnTerrCode = row.Cells(colTerritoryCode.Index).Value
        ReturnTerrName = row.Cells(colTerritoryName.Index).Value
        ReturnAgentCode = row.Cells(colMRCode.Index).Value
        Me.Close()
    End Sub

    Private Sub dgDetail_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub
End Class