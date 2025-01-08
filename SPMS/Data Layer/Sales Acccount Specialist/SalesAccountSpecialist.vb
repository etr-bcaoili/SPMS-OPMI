Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class SalesAccountSpecialist

    Private m_SalesAccountSpecialistID As Integer = -1

    Private m_EmployeeCode As String = String.Empty

    Private m_EmployeeFirstName As String = String.Empty

    Private m_EmployeeLastName As String = String.Empty

    Private m_EmployeeMiddleName As String = String.Empty

    Private m_EmployeeEmail As String = String.Empty

    Private m_EmployeePosition As String = String.Empty

    Private m_EmployeeGender As String = String.Empty

    Private m_EmployeePhoneNumber As String = String.Empty

    Private m_EmployeeAddress1 As String = String.Empty

    Private m_EmployeeAddress2 As String = String.Empty

    Private m_DateEnd As Date = "1/1/1990"

    Private m_DateStart As Date = "1/1/1900"

    Private m_IsActive As Boolean = True

    Private m_IsDelete As Boolean = False
    Public ReadOnly Property SalesAccountSpecialistID As Integer
        Get
            Return m_SalesAccountSpecialistID
        End Get
    End Property
    Public Property EmployeeCode As String
        Get
            Return m_EmployeeCode
        End Get
        Set(value As String)
            m_EmployeeCode = value
        End Set
    End Property
    Public Property EmployeeFirstName As String
        Get
            Return m_EmployeeFirstName
        End Get
        Set(value As String)
            m_EmployeeFirstName = value
        End Set
    End Property
    Public Property EmployeeLastName As String
        Get
            Return m_EmployeeLastName
        End Get
        Set(value As String)
            m_EmployeeLastName = value
        End Set
    End Property
    Public Property EmployeeMeddleName As String
        Get
            Return m_EmployeeMiddleName
        End Get
        Set(value As String)
            m_EmployeeMiddleName = value
        End Set
    End Property
    Public Property EmployeeEmail As String
        Get
            Return m_EmployeeEmail
        End Get
        Set(value As String)
            m_EmployeeEmail = value
        End Set
    End Property
    Public Property EmployeePosition As String
        Get
            Return m_EmployeePosition
        End Get
        Set(value As String)
            m_EmployeePosition = value
        End Set
    End Property
    Public Property EmployeeAddress1 As String
        Get
            Return m_EmployeeAddress1
        End Get
        Set(value As String)
            m_EmployeeAddress1 = value
        End Set
    End Property
    Public Property EmployeeAddress2 As String
        Get
            Return m_EmployeeAddress2
        End Get
        Set(value As String)
            m_EmployeeAddress2 = value
        End Set
    End Property

    Public Property EmployeeGender As String
        Get
            Return m_EmployeeGender
        End Get
        Set(value As String)
            m_EmployeeGender = value
        End Set
    End Property
    Public Property EmployeePhoneNumber As String
        Get
            Return m_EmployeePhoneNumber
        End Get
        Set(value As String)
            m_EmployeePhoneNumber = value
        End Set
    End Property
    Public Property DateEnd As Date
        Get
            Return m_DateEnd
        End Get
        Set(value As Date)
            m_DateEnd = value
        End Set
    End Property
    Public Property DateStart As Date
        Get
            Return m_DateStart
        End Get
        Set(value As Date)
            m_DateStart = value
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
    Public Property IsDelete As Boolean
        Get
            Return m_IsDelete
        End Get
        Set(value As Boolean)
            m_IsDelete = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As SalesAccountSpecialitsCollection
        Dim col As New SalesAccountSpecialitsCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim m_SalesAccountSpecialist As New SalesAccountSpecialist
            Dim row As DataRow = Table.Rows(j)
            m_SalesAccountSpecialist.m_SalesAccountSpecialistID = row("SalesAccountSpecialistID")
            m_SalesAccountSpecialist.m_EmployeeCode = row("EmployeeCode")
            m_SalesAccountSpecialist.m_EmployeeFirstName = row("FirstName")
            m_SalesAccountSpecialist.m_EmployeeLastName = row("LastName")
            m_SalesAccountSpecialist.m_EmployeeMiddleName = row("MiddleName")
            m_SalesAccountSpecialist.m_EmployeePhoneNumber = row("PhoneNumber")
            m_SalesAccountSpecialist.m_EmployeeGender = row("Gender")
            m_SalesAccountSpecialist.m_EmployeeEmail = row("Email")
            m_SalesAccountSpecialist.m_EmployeeAddress1 = row("Address1")
            m_SalesAccountSpecialist.m_EmployeeAddress2 = row("Address2")
            m_SalesAccountSpecialist.m_EmployeePosition = row("Position")
            m_SalesAccountSpecialist.m_DateStart = row("EffectivityStartDate")
            m_SalesAccountSpecialist.m_DateEnd = row("EffectivityEndDate")
            m_SalesAccountSpecialist.m_IsActive = row("IsActive")
            m_SalesAccountSpecialist.m_IsDelete = row("IsDeleted")
            col.Add(m_SalesAccountSpecialist)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspSalesAccountSpecialist", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@SalesAccountSpecialistID", m_SalesAccountSpecialistID)
            cmd.Parameters.AddWithValue("@EmployeeCode  ", m_EmployeeCode)
            cmd.Parameters.AddWithValue("@FirstName", m_EmployeeFirstName)
            cmd.Parameters.AddWithValue("@LastName", m_EmployeeLastName)
            cmd.Parameters.AddWithValue("@MiddleName", m_EmployeeMiddleName)
            cmd.Parameters.AddWithValue("@PhoneNumber", m_EmployeePhoneNumber)
            cmd.Parameters.AddWithValue("@Gender", m_EmployeeGender)
            cmd.Parameters.AddWithValue("@Email", m_EmployeeEmail)
            cmd.Parameters.AddWithValue("@Position", m_EmployeePosition)
            cmd.Parameters.AddWithValue("@Address1", m_EmployeeAddress1)
            cmd.Parameters.AddWithValue("@Address2", m_EmployeeAddress2)
            cmd.Parameters.AddWithValue("@EffectivityStartDate", m_DateStart)
            cmd.Parameters.AddWithValue("@EffectivityEndDate", m_DateEnd)
            cmd.Parameters.AddWithValue("@IsActive", m_IsActive)
            cmd.Parameters.AddWithValue("@IsDeleted", m_IsDelete)
            m_SalesAccountSpecialistID = cmd.ExecuteScalar
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            SPMSOPCI.ConnectionModule.Disconnect()
        End Try
    End Function
    Public Function Delete() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspSalesAccountSpecialist", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "DELETE")
            cmd.Parameters.AddWithValue("@SalesAccountSpecialistID", m_SalesAccountSpecialistID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As SalesAccountSpecialitsCollection
        Return BaseFilter(GetRecords("SELECT * FROM [SalesAccountSpecialist]  WHERE IsDeleted = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As SalesAccountSpecialitsCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal SalesAccountSpecialistID As Integer) As SalesAccountSpecialist
        Return Filter("SalesAccountSpecialistID = " & SalesAccountSpecialistID)(0)
    End Function
    Public Shared Function LoadByCode(ByVal EmployeeCode As String) As SalesAccountSpecialist
        Return Filter("EmployeeCode = '" & RefineSQL(EmployeeCode) & "'")(0)
    End Function
    Public Shared Function CheckofSalesAccountSpecialistAlreadyExist(ByVal EmployeeCode As String, ByVal SalesAccountSpecialistID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM SalesAccountSpecialist Where IsDeleted = 0 And EmployeeCode = '" & RefineSQL(EmployeeCode) & "' And SalesAccountSpecialistID <> " & SalesAccountSpecialistID) = "A"
    End Function
    Public Shared Function GetConfigtypeCode() As String
        Return "Select ConfigTypeCode from ConfigurationType Order by ConfigTypeCode"
    End Function
    Public Shared Function GetSalesAccountSpecialistSql() As String
        Return "SELECT SalesAccountSpecialistID,EmployeeCode,RTRIM(LTRIM(CONCAT(COALESCE(FirstName + ' ', ''),COALESCE(MiddleName + ' ', ''),COALESCE(Lastname, '')))) AS [Full Name],DateHired [Date Hired] FROM [SalesAccountSpecialist] WHERE  IsDeleted = 0"
    End Function
    Public Shared Function GetSalesAccountSpecialistbyEmployeeSql(ByVal EmployeeCode As String) As String
        Return "SELECT SalesAccountSpecialistID,EmployeeCode,RTRIM(LTRIM(CONCAT(COALESCE(FirstName + ' ', ''),COALESCE(MiddleName + ' ', ''),COALESCE(Lastname, '')))) AS [Full Name],EffectivityStartDate,EffectivityEndDate FROM [SalesAccountSpecialist] WHERE  IsDeleted = 0 And SalesAccountSpecialistID = '" & EmployeeCode & "'"
    End Function
End Class
Public Class SalesAccountSpecialitsCollection
    Inherits List(Of SalesAccountSpecialist)
End Class
