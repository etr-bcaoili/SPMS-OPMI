Imports System.Data.SqlClient
Imports SPMSOPCI.ConnectionModule
Public Class InqueryValidationData
    Private m_TMCode As String = String.Empty

    Private m_TMName As String = String.Empty

    Private m_TMAreaName As String = String.Empty

    Private m_EffectivityStartDate As String = String.Empty

    Private m_EffectivityEndDate As String = String.Empty

    Private m_ConfigtypeCode As String = String.Empty

    Private m_TMTerritoryCode As String = String.Empty

    Private m_Month As String = String.Empty

    Private m_Year As String = String.Empty


    Public Property TMCode As String
        Get
            Return m_TMCode
        End Get
        Set(value As String)
            m_TMCode = value
        End Set
    End Property
    Public Property TMName As String
        Get
            Return m_TMName
        End Get
        Set(value As String)
            m_TMName = value
        End Set
    End Property
    Public Property TMAreaName As String
        Get
            Return m_TMAreaName
        End Get
        Set(value As String)
            m_TMAreaName = value
        End Set
    End Property
    Public Property EffectivityStartDate As String
        Get
            Return m_EffectivityStartDate
        End Get
        Set(value As String)
            m_EffectivityStartDate = value
        End Set
    End Property
    Public Property EffectivityEndDate As String
        Get
            Return m_EffectivityEndDate
        End Get
        Set(value As String)
            m_EffectivityEndDate = value
        End Set
    End Property
    Public Property ConfigtypeCode As String
        Get
            Return m_ConfigtypeCode
        End Get
        Set(value As String)
            m_ConfigtypeCode = value
        End Set
    End Property
    Public Property TMTerritoryCode As String
        Get
            Return m_TMTerritoryCode
        End Get
        Set(value As String)
            m_TMTerritoryCode = value
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
    Public Property Year As String
        Get
            Return m_Year
        End Get
        Set(value As String)
            m_Year = value
        End Set
    End Property
    Public Function UpdateSalesMatrix() As Boolean
        Try
            Connect()
            Dim cmd As New SqlCommand("uspInqueryDataRecord", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SalesMatrix")
            cmd.Parameters.AddWithValue("@TMName", m_TMName)
            cmd.Parameters.AddWithValue("@TMAreaName", m_TMAreaName)
            cmd.Parameters.AddWithValue("@TMCode", m_TMCode)
            cmd.Parameters.AddWithValue("@ConfigtypeCode", m_ConfigtypeCode)
            cmd.Parameters.AddWithValue("@EffectivityStartDate", m_EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EffectivityEndDate", m_EffectivityEndDate)
            cmd.ExecuteNonQuery()
            Disconnect()
            Return True
        Catch ex As Exception
            Disconnect()
        End Try
    End Function
    Public Function UpdateSharing() As Boolean
        Try
            Connect()
            Dim cmd As New SqlCommand("uspInqueryDataRecord", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Sharing")
            cmd.Parameters.AddWithValue("@TMCode", m_TMCode)
            cmd.Parameters.AddWithValue("@TMName", m_TMName)
            cmd.Parameters.AddWithValue("@TMTerritoryCode", m_TMTerritoryCode)
            cmd.Parameters.AddWithValue("@Month", m_Month)
            cmd.Parameters.AddWithValue("@Year", m_Year)
            cmd.Parameters.AddWithValue("@ConfigtypeCode", m_ConfigtypeCode)
            cmd.ExecuteNonQuery()
            Disconnect()
            Return True
        Catch ex As Exception
            Disconnect()
        End Try
    End Function
    Public Function UpdateFinal() As Boolean
        Try
            Connect()
            Dim cmd As New SqlCommand("uspInqueryDataRecord", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "FINAL")
            cmd.Parameters.AddWithValue("@TMTerritoryCode", m_TMTerritoryCode)
            cmd.Parameters.AddWithValue("@TMAreaName", m_TMAreaName)
            cmd.Parameters.AddWithValue("@TMCode", m_TMCode)
            cmd.Parameters.AddWithValue("@TMName", m_TMName)
            cmd.Parameters.AddWithValue("@Month", m_Month)
            cmd.Parameters.AddWithValue("@Year", m_Year)
            cmd.Parameters.AddWithValue("@ConfigtypeCode", m_ConfigtypeCode)
            cmd.ExecuteNonQuery()
            Disconnect()
            Return True
        Catch ex As Exception
            Disconnect()
        End Try
    End Function
    Public Shared Function GetSalesMatrix(ByVal ConfigtypeCode As String, ByVal TMCode As String) As String
        Return "Select Distinct STSLSMNCD,STSLSMNNAME,STACOVNAME,EffectivityStartDate,EffectivityEndDate From SalesMatrix Where STSLSMNCD = '" & TMCode & "' And Configtypecode = '" & ConfigtypeCode & "' Order by EffectivityStartDate"
    End Function
    Public Shared Function GetSharing(ByVal ConfigtypeCode As String, ByVal TMCode As String) As String
        Return "Select Distinct STSLSMNCD,STSLSMNNAME,terrcd,CUTYEAR ,CUTMO From Sharing Where Configtypecode = '" & ConfigtypeCode & "' And STSLSMNCD = '" & TMCode & "' Order by CUTYEAR,CUTMO"
    End Function
    Public Shared Function GetFinal(ByVal ConfigtypeCode As String, ByVal TMCode As String) As String
        Return "Select Distinct [Territory Manager Code],[Territory Manager Name],[Territory Code],[Territory Name],Year,Month From SC02File Where Configtypecode = '" & ConfigtypeCode & "' and [Territory Manager Code] = '" & TMCode & "' Order by year,Month"
    End Function
End Class
