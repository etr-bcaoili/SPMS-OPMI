Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class ItemModifiedSales
    Private _ConfigtypeCode As String = String.Empty

    Private _ItemCode As String = String.Empty

    Private _ItemMotherCode As String = String.Empty

    Private _Year As String = String.Empty

    Private _Month As String = String.Empty

    Public Property ConfigtypeCode As String
        Get
            Return _ConfigtypeCode
        End Get
        Set(value As String)
            _ConfigtypeCode = value
        End Set
    End Property
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
    Public Property Year As String
        Get
            Return _Year
        End Get
        Set(value As String)
            _Year = value
        End Set
    End Property
    Public Property Month As String
        Get
            Return _Month
        End Get
        Set(value As String)
            _Month = value
        End Set
    End Property
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspModifiedItemSales", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "UPDATE")
            cmd.Parameters.AddWithValue("@ConfigtypeCode", ConfigtypeCode)
            cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
            cmd.Parameters.AddWithValue("@ItemMotherCode", ItemMotherCode)
            cmd.Parameters.AddWithValue("@Year", Year)
            cmd.Parameters.AddWithValue("@Month", Month)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
End Class
