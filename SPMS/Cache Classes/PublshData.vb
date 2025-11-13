Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports Telerik.WinControls.UI.PivotFieldList
Public Class PublshData
    Private _ConfigtypeCode As String = String.Empty
    Private _Year As String = String.Empty
    Private _Month As String = String.Empty
    Private _ChannelCode As String = String.Empty
    Public Property ConfigtypeCode As String
        Get
            Return _ConfigtypeCode
        End Get
        Set(value As String)
            _ConfigtypeCode = value
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
    Public Property ChannelCode As String
        Get
            Return _ChannelCode
        End Get
        Set(value As String)
            _ChannelCode = value
        End Set
    End Property
    Public Function Save() As Boolean
        Connect()
        Try
            Dim cmd As New SqlCommand("uspSyncDataFinalSales", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "DailyImportData")
            cmd.Parameters.AddWithValue("@ConfigtypeCode", _ConfigtypeCode)
            cmd.Parameters.AddWithValue("@Year", _Year)
            cmd.Parameters.AddWithValue("@Month", _Month)
            cmd.ExecuteNonQuery()
            Disconnect()
            Return True
        Catch ex As System.Exception
            Disconnect()
            Throw
        End Try
    End Function
End Class
Public Class PublshDataCollection
    Inherits List(Of PublshData)
End Class