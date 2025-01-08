Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ucMasterRegion
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class frmViewPosition
    Private mp_PositionCode As String = ""
    Private mp_PositionCodes As String = ""

    Public Property PositionCode() As String
        Get
            Return mp_PositionCode
        End Get
        Set(ByVal value As String)
            mp_PositionCode = value
        End Set
    End Property
    Public Property PositionCodes() As String
        Get
            Return mp_PositionCodes
        End Get
        Set(ByVal value As String)
            mp_PositionCodes = value
        End Set
    End Property

    Private Sub frmViewPosition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call loadviewDetails()
    End Sub
    Private Sub loadviewDetails()
        Connect()
        Dim cmd As New SqlCommand("uspProductManagerView", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        Dim sqlda As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim tb As New DataTable
        sqlda.Fill(tb)
        If tb.Rows.Count = 0 Then
            gproductmanager.Rows.Clear()
        Else
            For m As Integer = 0 To tb.Rows.Count - 1
                Dim dr As DataRow = tb.Rows(m)
                Dim row As DataGridViewRow = gproductmanager.Rows(gproductmanager.Rows.Add)
                row.Cells(colid.Index).Value = dr("ID")
                row.Cells(colprodid.Index).Value = dr("PM_code")
                row.Cells(colprodname.Index).Value = dr("PM_Name")
            Next
        End If
        gproductmanager.Refresh()
    End Sub

    Private Sub gproductmanager_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gproductmanager.CellContentClick
        Dim row As DataGridViewRow = gproductmanager.Rows(e.RowIndex)
        PositionCode = row.Cells(colprodname.Index).Value
        PositionCodes = row.Cells(colprodid.Index).Value
        Me.Dispose()
    End Sub

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub gproductmanager_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gproductmanager.CellDoubleClick
        Dim row As DataGridViewRow = gproductmanager.Rows(e.RowIndex)
        PositionCode = row.Cells(colprodname.Index).Value
        PositionCodes = row.Cells(colprodid.Index).Value
        Me.Dispose()
    End Sub
End Class