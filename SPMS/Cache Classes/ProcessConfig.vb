Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class ProcessConfig

    'Public Shared Function GetSyncDataSalesManager(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String) As DataTable
    '    Try
    '        Connect()
    '        Dim cmd As New SqlCommand("SyncDataSalesManager", SPMSConn2)
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandTimeout = 0
    '        cmd.Parameters.AddWithValue("@ConfigtypeCode", ConfigtypeCode)
    '        cmd.Parameters.AddWithValue("@Year", Year)
    '        cmd.Parameters.AddWithValue("@Month", Month)
    '        Dim da As New SqlDataAdapter(cmd)
    '        Dim dt = New DataTable
    '        da.Fill(dt)
    '        Return dt
    '    Catch ex As System.Exception
    '        Disconnect()
    '        Throw
    '    End Try
    'End Function

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
    Public Shared Function GetItemSql(Optional ByVal Year As String = "", Optional ByVal Month As String = "", Optional ByVal ConfigtypeCode As String = "") As String
        Return "Select Distinct [Item Mother Code] [ID],[Item Mother Code],[Item Brand Name] from SC02File Where ConfigtypeCode = '" & ConfigtypeCode & "'  And year = '" & Year & "'  and Month = '" & Month & "' And Region <> 'INH'"
    End Function
    Public Shared Function GetDistrictItemSql(Optional ByVal Year As String = "", Optional ByVal Month As String = "", Optional ByVal ConfigtypeCode As String = "", Optional ByVal ItemCode As String = "") As String
        Return "Select Distinct [District Code],[District Name] from SC02File Where ConfigtypeCode = '" & ConfigtypeCode & "'  And year = '" & Year & "'  And Month = '" & Month & "' And Region <> 'INH' And [Item mother Code] = '" & ItemCode & "'"
    End Function
    Public Shared Function GetDistrictlistSql(Optional ByVal Year As String = "", Optional ByVal Month As String = "", Optional ByVal ConfigtypeCode As String = "", Optional ByVal ItemCode As String = "", Optional DistrictList As String = "") As String
        Return "Select Distinct A.[District Code] [ID],A.[District Code],A.[Distributor Code],B.DISTNAME [Distributor Name] From SC02File A Inner JOIN Distributor B ON A.[Distributor Code] = B.DISTCOMID Where A.ConfigtypeCode = '" & ConfigtypeCode & "'  And A.year = '" & Year & "'  And A.Month = '" & Month & "' And A.Region <> 'INH' And [Item mother Code] = '" & ItemCode & "' AND A.[District Code] In (" & DistrictList & ")"
    End Function
    Public Shared Function GetDistrictChannelAndCustomerlistSql(Optional ByVal Year As String = "", Optional ByVal Month As String = "", Optional ByVal ConfigtypeCode As String = "", Optional ByVal ItemCode As String = "", Optional DistrictList As String = "", Optional ChannelCode As String = "") As String
        Return "Select Distinct A.[Distributor Code],B.DISTNAME [Distributor Name],A.[Customer Code],A.[Customer Name],A.[ShipTo Code],A.[ShipTo Address1],A.[ShipTo Address2] From SC02File A Inner JOIN Distributor B ON A.[Distributor Code] = B.DISTCOMID Where A.ConfigtypeCode = '" & ConfigtypeCode & "'  And A.Year = '" & Year & "'  And A.Month = '" & Month & "' And A.Region <> 'INH' And [Item mother Code] = '" & ItemCode & "' AND A.[District Code] In (" & DistrictList & ") AND A.[Distributor Code] = '" & ChannelCode & "'"
    End Function
    Public Shared Function GetDistrictChannelAndCustomerPMRORGlistSql(Optional ByVal Year As String = "", Optional ByVal Month As String = "", Optional ByVal ConfigtypeCode As String = "", Optional ByVal ItemCode As String = "", Optional DistrictList As String = "", Optional ChannelCode As String = "", Optional ByVal CustomerCode As String = "") As String
        Return "Select Distinct A.[Customer Name],A.[Territory Manager Code],UPPER(C.STACOVNAME)[Territory Name] From SC02File A Inner JOIN Distributor B ON A.[Distributor Code] = B.DISTCOMID INNER JOIN Salesmatrix C ON A.[Territory Manager Code] = C.STSLSMNCD  Where A.ConfigtypeCode = '" & ConfigtypeCode & "'  And A.Year = '" & Year & "'  And A.Month = '" & Month & "' And A.Region <> 'INH' And [Item mother Code] = '" & ItemCode & "' AND A.[District Code] In (" & DistrictList & ") AND A.[Distributor Code] = '" & ChannelCode & "' AND [Customer Code] = '" & CustomerCode & "'"
    End Function
    Public Shared Function GetDistrictChannelAndCustomerPMRSHRlistSql(Optional ByVal Year As String = "", Optional ByVal Month As String = "", Optional ByVal ConfigtypeCode As String = "") As String
        Return "Select Distinct A.[Territory Manager Code],A.[Territory Manager Code],UPPER(B.STACOVNAME)[Territory Name] From SC02File A INNER JOIN Salesmatrix B ON A.[Territory Manager Code] = B.STSLSMNCD  Where A.ConfigtypeCode = '" & ConfigtypeCode & "' And Month(B.EffectivityStartDate) = '" & Month & "' AND Year(B.EffectivityStartDate) = '" & Year & "' AND A.Region <> 'INH'"
    End Function
End Class
