Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class EmployeeDistrictManager
    Private m_EmployeeID As Integer = -1

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

    Private m_DateEntry As Date = "1/1/1990"

    Private m_Datehired As Date = "1/1/1900"

    Private m_IsActive As Boolean = True

    Private m_IsDelete As Boolean = False


    Public ReadOnly Property EmployeeID As Integer
        Get
            Return m_EmployeeID
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
    Public Property DateEntry As Date
        Get
            Return m_DateEntry
        End Get
        Set(value As Date)
            m_DateEntry = value
        End Set
    End Property
    Public Property DateHired As Date
        Get
            Return m_Datehired
        End Get
        Set(value As Date)
            m_Datehired = value
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

    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As EmployeeDistrictManagerCollection
        Dim col As New EmployeeDistrictManagerCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim m_EmployeeDistrictManager As New EmployeeDistrictManager
            Dim row As DataRow = Table.Rows(j)
            m_EmployeeDistrictManager.m_EmployeeID = row("EmployeeID")
            m_EmployeeDistrictManager.m_EmployeeCode = row("EmployeeCode")
            m_EmployeeDistrictManager.m_EmployeeFirstName = row("FirstName")
            m_EmployeeDistrictManager.m_EmployeeLastName = row("LastName")
            m_EmployeeDistrictManager.m_EmployeeMiddleName = row("MiddleName")
            m_EmployeeDistrictManager.m_EmployeePhoneNumber = row("PhoneNumber")
            m_EmployeeDistrictManager.m_EmployeeGender = row("Gender")
            m_EmployeeDistrictManager.m_EmployeeEmail = row("Email")
            m_EmployeeDistrictManager.m_EmployeeAddress1 = row("Address1")
            m_EmployeeDistrictManager.m_EmployeeAddress2 = row("Address2")
            m_EmployeeDistrictManager.m_EmployeePosition = row("Position")
            m_EmployeeDistrictManager.m_DateEntry = row("DateEntry")
            m_EmployeeDistrictManager.m_Datehired = row("DateHired")
            m_EmployeeDistrictManager.m_IsActive = row("IsActive")
            m_EmployeeDistrictManager.m_IsDelete = row("IsDeleted")
            col.Add(m_EmployeeDistrictManager)
        Next
        Return col
    End Function

    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspEmployeeDistrictManager", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@EmployeeID", m_EmployeeID)
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
            cmd.Parameters.AddWithValue("@DateEntry", m_DateEntry)
            cmd.Parameters.AddWithValue("@DateHired", m_Datehired)
            cmd.Parameters.AddWithValue("@IsActive", m_IsActive)
            cmd.Parameters.AddWithValue("@IsDeleted", m_IsDelete)
            m_EmployeeID = cmd.ExecuteScalar
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            SPMSOPCI.ConnectionModule.Disconnect()
        End Try
    End Function
    Public Function Delete() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspEmployeeDistrictManager", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "DELETE")
            cmd.Parameters.AddWithValue("@EmployeeID", m_EmployeeID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function

    Public Shared Function Filter(ByVal Condition As String) As EmployeeDistrictManagerCollection
        Return BaseFilter(GetRecords("SELECT * FROM [EmployeeDistrictManager]  WHERE IsDeleted = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As EmployeeDistrictManagerCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal EmployeeID As Integer) As EmployeeDistrictManager
        Return Filter("EmployeeID = " & EmployeeID)(0)
    End Function
    Public Shared Function LoadByCode(ByVal EmployeeCode As String) As EmployeeDistrictManager
        Return Filter("EmployeeCode = '" & RefineSQL(EmployeeCode) & "'")(0)
    End Function
    Public Shared Function CheckofEmployeeDistrictManagerAlreadyExist(ByVal EmployeeCode As String, ByVal EmployeeID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM EmployeeDistrictManager Where IsDeleted = 0 And EmployeeCode = '" & RefineSQL(EmployeeCode) & "' And EmployeeID <> " & EmployeeID) = "A"
    End Function
    Public Shared Function CheckofDistrictManagerStartDateAlreadyExist(ByVal DistrictCode As String, ByVal StartDate As String, ByVal ConfigtypeCode As String) As Boolean
        Return ExecuteCommand("Select 'A' From EmployeeDistrictCollection A Inner Join EmployeeDistrictManager B ON A.EmployeeID = B.EmployeeID Where A.DistrictCode = '" & DistrictCode & "' And B.IsDeleted = 0 And ConfigtypeCode = '" & ConfigtypeCode & "' And Month(A.EffectivityStartDate) <= '" & StartDate & "'") = "A"
    End Function
    Public Shared Function CheckofDistrictManagerEndDateAlreadyExist(ByVal DistrictCode As String, ByVal EndDate As String, ByVal ConfigtypeCode As String) As Boolean
        Return ExecuteCommand("Select 'A' From EmployeeDistrictCollection A Inner Join EmployeeSalesman B ON A.EmployeeID = B.EmployeeID Where A.DistrictCode = '" & DistrictCode & "'  And B.IsDeleted = 0 And ConfigtypeCode = '" & ConfigtypeCode & "' And Month(A.EffectivityStartDate) <= '" & EndDate & "'") = "A"
    End Function
    Public Shared Function GetEmployeeDistrictManagerSql() As String
        Return "SELECT Distinct EmployeeID,EmployeeCode,RTRIM(LTRIM(CONCAT(COALESCE(FirstName + ' ', ''),COALESCE(MiddleName + ' ', ''),COALESCE(Lastname, '')))) AS [Full Name] FROM [EmployeeDistrictManager] WHERE  IsDeleted = 0"
    End Function


End Class
Public Class EmployeeDistrictManagerCollection
    Inherits List(Of EmployeeDistrictManager)
End Class