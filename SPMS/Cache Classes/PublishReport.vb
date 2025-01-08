Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class PublishReport
    Public Shared Function GetSyncDataFinalSales(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String) As DataTable
        Try
            Connect()
            Dim cmd As New SqlCommand("uspSyncDataFinalSales", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@Action", "ExportData")
            cmd.Parameters.AddWithValue("@ConfigtypeCode", ConfigtypeCode)
            cmd.Parameters.AddWithValue("@Year", Year)
            cmd.Parameters.AddWithValue("@Month", Month)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt = New DataTable
            da.Fill(dt)
            Return dt
        Catch ex As System.Exception
            Disconnect()
            Throw
        End Try
    End Function
    Public Shared Function GetSyncDataSalesmatrix(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String) As DataTable
        Try
            Connect()
            Dim cmd As New SqlCommand("SyncDataSalesmatrix", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@ConfigtypeCode", ConfigtypeCode)
            cmd.Parameters.AddWithValue("@Year", Year)
            cmd.Parameters.AddWithValue("@Month", Month)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt = New DataTable
            da.Fill(dt)
            Return dt
        Catch ex As System.Exception
            Disconnect()
            Throw
        End Try
    End Function
    Public Shared Function GetSyncDataTerritories(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String) As DataTable
        Try
            Connect()
            Dim cmd As New SqlCommand("SyncDataTerritories", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@ConfigtypeCode", ConfigtypeCode)
            cmd.Parameters.AddWithValue("@Year", Year)
            cmd.Parameters.AddWithValue("@Month", Month)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt = New DataTable
            da.Fill(dt)
            Return dt
        Catch ex As System.Exception
            Disconnect()
            Throw
        End Try
    End Function
    Public Shared Function GetSyncDataDistricts(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String) As DataTable
        Try
            Connect()
            Dim cmd As New SqlCommand("SyncDataDistricts", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@ConfigtypeCode", ConfigtypeCode)
            cmd.Parameters.AddWithValue("@Year", Year)
            cmd.Parameters.AddWithValue("@Month", Month)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt = New DataTable
            da.Fill(dt)
            Return dt
        Catch ex As System.Exception
            Disconnect()
            Throw
        End Try
    End Function
    Public Shared Function GetSyncDataAgents(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String) As DataTable
        Try
            Connect()
            Dim cmd As New SqlCommand("SyncDataAgents", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@ConfigtypeCode", ConfigtypeCode)
            cmd.Parameters.AddWithValue("@Year", Year)
            cmd.Parameters.AddWithValue("@Month", Month)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt = New DataTable
            da.Fill(dt)
            Return dt
        Catch ex As System.Exception
            Disconnect()
            Throw
        End Try
    End Function
    Public Shared Function GetSyncDataSalesManager(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String) As DataTable
        Try
            Connect()
            Dim cmd As New SqlCommand("SyncDataSalesManager", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@ConfigtypeCode", ConfigtypeCode)
            cmd.Parameters.AddWithValue("@Year", Year)
            cmd.Parameters.AddWithValue("@Month", Month)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt = New DataTable
            da.Fill(dt)
            Return dt
        Catch ex As System.Exception
            Disconnect()
            Throw
        End Try
    End Function
    Public Shared Function GetSyncDataItems(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String) As DataTable
        Try
            Connect()
            Dim cmd As New SqlCommand("SyncDataItems", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@ConfigtypeCode", ConfigtypeCode)
            cmd.Parameters.AddWithValue("@Year", Year)
            cmd.Parameters.AddWithValue("@Month", Month)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt = New DataTable
            da.Fill(dt)
            Return dt
        Catch ex As System.Exception
            Disconnect()
            Throw
        End Try
    End Function
    Public Shared Function GetSyncDataTarget(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String) As DataTable
        Try
            Connect()
            Dim cmd As New SqlCommand("SyncDataTarget", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@ConfigtypeCode", ConfigtypeCode)
            cmd.Parameters.AddWithValue("@Year", Year)
            cmd.Parameters.AddWithValue("@Month", Month)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt = New DataTable
            da.Fill(dt)
            Return dt
        Catch ex As System.Exception
            Disconnect()
            Throw
        End Try
    End Function
    Public Shared Function GetSyncDataCustomer(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String) As DataTable
        Try
            Connect()
            Dim cmd As New SqlCommand("SyncDataCustomer", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@ConfigtypeCode", ConfigtypeCode)
            cmd.Parameters.AddWithValue("@Year", Year)
            cmd.Parameters.AddWithValue("@Month", Month)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt = New DataTable
            da.Fill(dt)
            Return dt
        Catch ex As System.Exception
            Disconnect()
            Throw
        End Try
    End Function
End Class
