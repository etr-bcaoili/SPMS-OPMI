Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class SalesManager
    Private m_DistrictID As Integer = -1

    Private m_DLTFLG As Boolean = False

    Private m_DistrictCode As String = String.Empty

    Private m_DistrictName As String = String.Empty

    Private m_IsActive As Boolean = True

    Private m_ConfigtypeCode As String = String.Empty

    Private m_EffectivityStartDate As Date = "1/1/1990"

    Private m_EffectivityEndDate As Date = "1/1/1990"

    Private m_EmailAddress As String = String.Empty

    Private m_EmailIsActive As Boolean = True

    Private m_SASCode As Integer = -1


    Public ReadOnly Property DistrictID As Integer
        Get
            Return m_DistrictID
        End Get
    End Property
    Public Property DistrictCode As String
        Get
            Return m_DistrictCode
        End Get
        Set(value As String)
            m_DistrictCode = value
        End Set
    End Property
    Public Property DistrictName As String
        Get
            Return m_DistrictName
        End Get
        Set(value As String)
            m_DistrictName = value
        End Set
    End Property
    Public Property IsActive As Boolean
        Get
            Return m_IsActive
        End Get
        Set(value As Boolean)
            m_IsActive = value
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
    Public Property EffectivityStartDate As Date
        Get
            Return m_EffectivityStartDate
        End Get
        Set(value As Date)
            m_EffectivityStartDate = value
        End Set
    End Property
    Public Property EffectivityEndDate As Date
        Get
            Return m_EffectivityEndDate
        End Get
        Set(value As Date)
            m_EffectivityEndDate = value
        End Set
    End Property
    Public Property EmailAddress As String
        Get
            Return m_EmailAddress
        End Get
        Set(value As String)
            m_EmailAddress = value
        End Set
    End Property
    Public Property EmailIsActive As Boolean
        Get
            Return m_EmailIsActive
        End Get
        Set(value As Boolean)
            m_EmailIsActive = value
        End Set
    End Property
    Public Property SASCode As Integer
        Get
            Return m_SASCode
        End Get
        Set(value As Integer)
            m_SASCode = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As SalesManagerCollection
        Dim col As New SalesManagerCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_SalesManager As New SalesManager
            Dim row As DataRow = table.Rows(j)
            m_SalesManager.m_DistrictID = row("STSLSMGRID")
            m_SalesManager.m_DLTFLG = row("DLTFLG")
            m_SalesManager.m_DistrictCode = row("STSLSMGRCD")
            m_SalesManager.m_DistrictName = row("STSLSMGRNAME")
            m_SalesManager.m_ConfigtypeCode = row("CONFIGTYPECODE")
            m_SalesManager.m_EffectivityStartDate = row("EFFECTIVITYSTARTDATE")
            m_SalesManager.m_EffectivityEndDate = row("EFFECTIVITYENDDATE")
            m_SalesManager.m_EmailAddress = row("EmailAddress")
            m_SalesManager.m_EmailIsActive = row("EmailIsActive")
            col.Add(m_SalesManager)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspSalesManager", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@SalesmaManagerID", m_DistrictID)
            cmd.Parameters.AddWithValue("@DLTFLG", m_DLTFLG)
            cmd.Parameters.AddWithValue("@SalesmanManagerCode", m_DistrictCode)
            cmd.Parameters.AddWithValue("@SalesmanManagerName", m_DistrictName)
            cmd.Parameters.AddWithValue("@IsActive", m_IsActive)
            cmd.Parameters.AddWithValue("@ConfigTypeCode", m_ConfigtypeCode)
            cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", m_EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", m_EffectivityEndDate)
            cmd.Parameters.AddWithValue("@EmailAddress", m_EmailAddress)
            cmd.Parameters.AddWithValue("@EmailIsActive", m_EmailIsActive)
            m_DistrictID = cmd.ExecuteScalar
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Function Update() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspSalesManager", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "UPDATE")
            cmd.Parameters.AddWithValue("@DLTFLG", m_DLTFLG)
            cmd.Parameters.AddWithValue("@SalesmanManagerCode", m_DistrictCode)
            cmd.Parameters.AddWithValue("@SalesmanManagerName", m_DistrictName)
            cmd.Parameters.AddWithValue("@IsActive", m_IsActive)
            cmd.Parameters.AddWithValue("@ConfigTypeCode", m_ConfigtypeCode)
            cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", m_EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", m_EffectivityEndDate)
            cmd.Parameters.AddWithValue("@EmailAddress", m_EmailAddress)
            cmd.Parameters.AddWithValue("@IsActiveEmail", m_EmailIsActive)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Function Delete() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspSalesManager", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Delete")
            cmd.Parameters.AddWithValue("@SalesmaManagerID", m_DistrictID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function

    Public Function InsertDistrict() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspDistrict_CollectionSAS", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Get")
            cmd.Parameters.AddWithValue("@SASCode", m_SASCode)
            cmd.Parameters.AddWithValue("@DistrictCode", m_DistrictCode)
            cmd.Parameters.AddWithValue("@ConfigTypeCode", m_ConfigtypeCode)
            cmd.Parameters.AddWithValue("@EffectivityStartDate", m_EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EffectivityEndDate", m_EffectivityEndDate)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As SalesManagerCollection
        Return BaseFilter(GetRecords("SELECT * FROM STSALESMANAGER  WHERE DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As SalesManagerCollection
        Return Filter("")
    End Function
    Public Shared Function LoadByCode(ByVal STSLSMGRCD As String) As SalesManager
        Return Filter("STSLSMGRCD = '" & RefineSQL(STSLSMGRCD) & "'")(0)
    End Function
    Public Shared Function LoadID(ByVal STSLSMGRID As String) As SalesManager
        Return Filter("STSLSMGRID = '" & RefineSQL(STSLSMGRID) & "'")(0)
    End Function
    Public Shared Function CheckofDistrictManagerAlreadyExist(ByVal Code As String, ByVal ConfigCode As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM STSALESMANAGER Where DLTFLG = 0 And STSLSMGRCD = '" & RefineSQL(Code) & "' And CONFIGTYPECODE = '" & ConfigCode & "'  And STSLSMGRID <> " & ID) = "A"
    End Function

    Public Shared Function GetDistrictManagerSql() As String
        Return "SELECT STSLSMGRID, STSLSMGRCD [District Manager Code], STSLSMGRNAME [District Manager Name],CONFIGTYPECODE [Configtype Code] FROM STSALESMANAGER Where DLTFLG = 0 "
    End Function
    Public Shared Function GetDistrictPMRSASSql() As String
        Return "SELECT STSLSMGRCD, STSLSMGRCD [District Manager Code], STSLSMGRNAME [District Manager Name],CONFIGTYPECODE [Configtype Code] FROM STSALESMANAGER Where DLTFLG = 0 "
    End Function
    Public Shared Function GetDistrictManagerProcessSql(ByVal ConfigCode As String, ByVal DistrictCode As String) As String
        Return "Select Distinct Year,Month,[District Manager Code],Configtypecode from SC02File  Where Configtypecode = '" & ConfigCode & "' And [District Manager Code] = '" & DistrictCode & "' Order by Year"
    End Function
    Public Shared Function UpdatebyProcessDistrictManager(ByVal Year As String, ByVal Month As String, ByVal ConfigCode As String, ByVal DistrictCode As String, ByVal DistrictManagerName As String) As Boolean
        Return ExecuteCommand("Update SC02File SET [District Manager Name] = '" & DistrictManagerName & "' Where Year = '" & Year & "' AND Month = '" & Month & "' And Configtypecode = '" & ConfigCode & "' And [District Manager Code] = '" & DistrictCode & "'")
    End Function
End Class
Public Class SalesManagerCollection
    Inherits List(Of SalesManager)
End Class