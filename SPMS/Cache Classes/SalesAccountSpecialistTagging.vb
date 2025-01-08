Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class SalesAccountSpecialistTagging
    Private m_ConfigtypeCode As String = String.Empty

    Private m_year As String = String.Empty

    Private m_Month As String = String.Empty

    Private m_DistributorCode As String = String.Empty

    Public Property ConfigtypeCode As String
        Get
            Return m_ConfigtypeCode
        End Get
        Set(value As String)
            m_ConfigtypeCode = value
        End Set
    End Property
    Public Property Year As String
        Get
            Return m_year
        End Get
        Set(value As String)
            m_year = value
        End Set
    End Property
    Public Property Month As String
        Get
            Return m_Month
        End Get
        Set(value As String)
            m_Month = value
        End Set
    End Property
    Public Property DistributorCode As String
        Get
            Return m_DistributorCode
        End Get
        Set(value As String)
            m_DistributorCode = value
        End Set
    End Property

    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspSalesAccountSpecialistTemp", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "Insert")
            cmd.Parameters.AddWithValue("@ConfigtypeCode", m_ConfigtypeCode)
            cmd.Parameters.AddWithValue("@Year", m_year)
            cmd.Parameters.AddWithValue("@Month", m_Month)
            cmd.Parameters.AddWithValue("@DistributorCode", m_DistributorCode)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function GetCompanyListSql(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String) As String
        Return "Select Distinct [Distributor Code],[Distributor Name] From SC02File Where Configtypecode = '" & ConfigtypeCode & "' and Year = '" & Year & "' and Month Like '%" & Month & "%' Order by [Distributor Code]"
    End Function
    Public Shared Function GetDistrictManagerListSql(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String, ByVal DistributorList As String) As String
        Return "Select Distinct [District Manager Code],[District Manager Name] From SC02File Where Configtypecode = '" & ConfigtypeCode & "' And Year = '" & Year & "' and Month Like '%" & Month & "%' And [Distributor Code] In (" & DistributorList & ")"
    End Function
    Public Shared Function GetTerritoryListSql(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String, ByVal DistributorList As String, ByVal DistrictManagerCode As String) As String
        Return "Select Distinct [Territory Manager Code],[Territory Manager Name] From SC02File Where Configtypecode = '" & ConfigtypeCode & "' And Year = '" & Year & "' and Month Like '%" & Month & "%' And [Distributor Code] In (" & DistributorList & ") And [District Manager Code] In (" & DistrictManagerCode & ")"
    End Function
    Public Shared Function GetCustomerListSql(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String, ByVal DistributorList As String, ByVal DistrictManagerCode As String, ByVal TerritoryCode As String) As String
        Return "Select Distinct [Customer Code],[Customer Name],[ShipTo Code],[ShipTo Address1] +' '+[ShipTo Address2] [Address] From SC02File Where Configtypecode = '" & ConfigtypeCode & "' And Year = '" & Year & "' and Month Like '%" & Month & "%' And [Distributor Code] In (" & DistributorList & ") And [District Manager Code] In (" & DistrictManagerCode & ") And [Territory Manager Code] In (" & TerritoryCode & ")"
    End Function
    Public Shared Function TruncateTableSalesAccountSpecialistTemp() As String
        ExecuteCommand("Truncate table SalesAccountSpecialistTemp")
    End Function
End Class
