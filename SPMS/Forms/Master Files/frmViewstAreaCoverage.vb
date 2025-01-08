Imports System.Data.SqlClient
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.UCproductManager

Public Class frmViewStAreaCoverage
    Private TR_TerritoryCode As String = ""
    Private TR_TerritoryName As String = ""


    Public Property TerritoryCode() As String
        Get
            Return TR_TerritoryCode
        End Get
        Set(ByVal value As String)
            TR_TerritoryCode = value
        End Set
    End Property
    Public Property TerritoryName() As String
        Get
            Return TR_TerritoryName
        End Get
        Set(ByVal value As String)
            TR_TerritoryName = value
        End Set
    End Property

    Private Sub frmViewStAreaCoverage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call loadviewing()
    End Sub

    Private Sub loadviewing()

        Connect()
        Dim cmd As New SqlCommand("uspViewTerritory", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        Dim sqlda As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim tb As New DataTable
        sqlda.Fill(tb)
        'gview.DataSource = tb

        For m As Integer = 0 To tb.Rows.Count - 1
            Dim dr As DataRow = tb.Rows(m)
            Dim row As DataGridViewRow = gview.Rows(gview.Rows.Add)
            row.Cells("colTerritoryCode").Value = dr("Territory Code")
            row.Cells("colTerritoryName").Value = dr("Territory Name")
        Next

    End Sub

  
    Private Sub gDistrictView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gview.CellContentClick

    End Sub

    Private Sub gDistrictView_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gview.CellContentDoubleClick
        Dim row As DataGridViewRow = gview.Rows(e.RowIndex)
        TerritoryCode = row.Cells("colTerritoryCode").Value
        TerritoryName = row.Cells("colTerritoryName").Value
        Me.Dispose()
    End Sub

    Private Sub txtpmname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub gview_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gview.CellDoubleClick
        Dim row As DataGridViewRow = gview.Rows(e.RowIndex)
        TerritoryCode = row.Cells("colTerritoryCode").Value
        TerritoryName = row.Cells("colTerritoryName").Value
        Me.Dispose()
    End Sub
    Public Shared Function GetTerritoryArea() As String
        Return "Select STACOVCD,STACOVCD [Territory Code],STACOVNAME[Territory Name] From  STAreaCoverage where DLTFLG = 0 and STACOVCD <>  'HSE' and STACOVCD <> 'PH3' and STACOVCD <> 'MER' order by STACOVCD"
    End Function
End Class