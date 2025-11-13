Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class SalesAccountSpecialistCollection
    Private m_SalesAccountSpecialistID As Integer = -1

    Private m_DistrictManagerCode As String = String.Empty

    Private m_DistrictManagerName As String = String.Empty

    Private m_EmployeeCode As String = String.Empty

    Private m_EffectivityStartDate As Date = "1/1/1990"

    Private m_EffectivityEndDate As Date = "1/1/1990"

    Private m_ConfigtypeCode As String = String.Empty

    Private m_DistrictManagerMultipleValue As String = String.Empty

    Private m_DistributorCodeMultipleValue As String = String.Empty

    Private m_TerritoryCodeMultipleValue As String = String.Empty

    Private m_TerritoryNameMultipleValue As String = String.Empty

    Private m_IsActive As Boolean = False

    Private m_CustomerCodeMultipleValue As String = String.Empty

    Public Property DistrictManagerCode As String
        Get
            Return m_DistrictManagerCode
        End Get
        Set(value As String)
            m_DistrictManagerCode = value
        End Set
    End Property
    Public Property DistrictManagerName As String
        Get
            Return m_DistrictManagerName
        End Get
        Set(value As String)
            m_DistrictManagerName = value
        End Set
    End Property
    Public Property SalesAccountSpecialistID As Integer
        Get
            Return m_SalesAccountSpecialistID
        End Get
        Set(value As Integer)
            m_SalesAccountSpecialistID = value
        End Set
    End Property
    Public Property EmployeeCode As String
        Get
            Return m_EmployeeCode
        End Get
        Set(value As String)
            m_EmployeeCode = value
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
    Public Property ConfigtypeCode As String
        Get
            Return m_ConfigtypeCode
        End Get
        Set(value As String)
            m_ConfigtypeCode = value
        End Set
    End Property
    Public Property DistrictManagerCodeMultipleValue As String
        Get
            Return m_DistrictManagerMultipleValue
        End Get
        Set(value As String)
            m_DistrictManagerMultipleValue = value
        End Set
    End Property
    Public Property DistributorCodeMultipleValue As String
        Get
            Return m_DistributorCodeMultipleValue
        End Get
        Set(value As String)
            m_DistributorCodeMultipleValue = value
        End Set
    End Property
    Public Property TerritoryCodeMultipleValues As String
        Get
            Return m_TerritoryCodeMultipleValue
        End Get
        Set(value As String)
            m_TerritoryCodeMultipleValue = value
        End Set
    End Property
    Public Property TerritoryNameMultipleValues As String
        Get
            Return m_TerritoryNameMultipleValue
        End Get
        Set(value As String)
            m_TerritoryNameMultipleValue = value
        End Set
    End Property
    Public Property IsActive As String
        Get
            Return m_IsActive
        End Get
        Set(value As String)
            m_IsActive = value
        End Set
    End Property
    Public Property CustomerCodeMultipleValue As String
        Get
            Return m_CustomerCodeMultipleValue
        End Get
        Set(value As String)
            m_CustomerCodeMultipleValue = value
        End Set
    End Property

    Public Function Save() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspSalesAccountSpecialistCollection", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@SalesAccountSpecialistID", m_SalesAccountSpecialistID)
            cmd.Parameters.AddWithValue("@DistrictManagerCode", m_DistrictManagerCode)
            cmd.Parameters.AddWithValue("@DistrictManagerName", m_DistrictManagerName)
            cmd.Parameters.AddWithValue("@PMRCode", m_TerritoryCodeMultipleValue)
            cmd.Parameters.AddWithValue("@PMRName", m_TerritoryNameMultipleValue)
            cmd.Parameters.AddWithValue("@EffectivityStartDate", m_EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EffectivityEndDate", m_EffectivityEndDate)
            cmd.Parameters.AddWithValue("@ConfigtypeCode", m_ConfigtypeCode)
            cmd.Parameters.AddWithValue("@IsActive", m_IsActive)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Public Function SASGetInsert() As Boolean
        Try
            SaveMatrixSAS(m_EmployeeCode, m_DistributorCodeMultipleValue, m_DistrictManagerMultipleValue, m_TerritoryCodeMultipleValue, m_CustomerCodeMultipleValue, m_ConfigtypeCode, m_EffectivityStartDate, m_EffectivityEndDate)
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Public Shared Function SalesAccountSpecialistICollectionDelete(ByVal SalesAccountSpecialistID As Integer) As Boolean
        Return ExecuteCommand("DELETE FROM [SalesAccountSpecialistCollection] WHERE SalesAccountSpecialistID = '" & SalesAccountSpecialistID & "'")
    End Function
    Public Shared Function CheckSalesAccountSpecialistIsAlreadyExist(ByVal EmployeeCode As String, ByVal ConfigtypeCode As String, ByVal EffectivityStartDate As Date, ByVal EffectivityEndDate As Date) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM ConfigurationSASMatix Where EmployeeCode = '" & EmployeeCode & "' AND ConfigtypeCode = '" & ConfigtypeCode & "' AND EffectivityStartDate = '" & EffectivityStartDate & "' AND EffectivityEndDate = '" & EffectivityEndDate & "'") = "A"
    End Function

    Public Shared Function GetSalesAccountSpecialistICollection(ByVal SalesAccountSpecialistID As Integer)
        Return "Select IsActive,DistrictManagerName,PMRCode,PMRName,DistrictManagerCode from [SalesAccountSpecialistCollection] Where SalesAccountSpecialistID = '" & SalesAccountSpecialistID & "' Order by DistrictManagerCode,PMRCode"
    End Function

    Public Shared Function GetSalesAccountSpecialistDistributor(ByVal DistrictManagerCode As String, ByVal ConfigtypeCode As String)
        Return "Select Distinct [Distributor Code],UPPER([Distributor Name])[Distributor Name] from SC02File Where  [District Manager Code] In (" & DistrictManagerCode & ") And Configtypecode = '" & ConfigtypeCode & "'"
    End Function
    Public Shared Function GetSalesAccountSpecialistTerritorybyDistrictManager(ByVal DistrictManagerCode As String, ByVal ConfigtypeCode As String, ByVal DistributorCode As String)
        Return "Select Distinct [Territory Manager Code],UPPER([Territory Manager Name])[Territory Manager Name],[Territory Name]   from SC02File Where  [District Manager Code] In (" & DistrictManagerCode & ") And Configtypecode = '" & ConfigtypeCode & "' And [Distributor Code] In (" & DistributorCode & ")"
    End Function

    Public Shared Function GetSalesAccountSpecialistCustomer(ByVal DistrictManagerCode As String, ByVal ConfigtypeCode As String, ByVal TerritoryCode As String, ByVal DistributorCode As String)
        Return "Select Distinct [Customer Code],[Customer Name],[ShipTo Address1]+' '+ [ShipTo Address2] AS [Address] From SC02File Where  [District Manager Code] In (" & DistrictManagerCode & ") And Configtypecode = '" & ConfigtypeCode & "' And [Territory Code] In (" & TerritoryCode & ") And [Distributor Code] In (" & DistributorCode & ")"
    End Function
    Public Shared Function GetSalesAccountSpecialistRecord(ByVal EmployeeCode As String)
        Return "Select Distinct EmployeeCode,EffectivityStartDate,EffectivityEndDate,ConfigtypeCode  from SC02File_SASPROFILE Where EmployeeCode = '" & EmployeeCode & "'"
    End Function
    Public Shared Function SaveMatrixSAS(ByVal EmployeeCode As String, ByVal DistributorCode As String, ByVal DistrictManagerMultipleValue As String, ByVal TerritoryCodeMultipleValue As String, ByVal CustomerCodeMultipleValue As String, ByVal ConfigtypeCode As String, ByVal EffectivityStartDate As Date, ByVal EffectivityEndDate As Date) As Boolean
        Return ExecuteCommand("INSERT INTO [ConfigurationSASMatix] Select Distinct '" & EmployeeCode & "',[District Manager Code],[Territory Code],[Customer Code],'" & EffectivityStartDate & "','" & EffectivityEndDate & "', Configtypecode From SC02File Where [District Manager Code] In (" & DistrictManagerMultipleValue & ") And [Distributor Code] IN (" & DistributorCode & ") And [Territory Manager Code] IN (" & TerritoryCodeMultipleValue & ") AND [Customer Code] IN (" & CustomerCodeMultipleValue & ") And Configtypecode = '" & ConfigtypeCode & "' And Year = Year('" & EffectivityEndDate & "')")
    End Function
End Class
