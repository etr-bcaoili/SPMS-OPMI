Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Imports Telerik.WinControls.UI.PivotFieldList
Public Class SalesAccountSpecialist

    Private m_SalesAccountSpecialistID As Integer = -1

    Private m_SalesAccountSpecialistCode As String = String.Empty

    Private m_Gender As Integer = -1

    Private m_EmployeeFirstName As String = String.Empty

    Private m_SalesAccountSpecialistName As String = String.Empty

    Private m_PhoneNumber As String = String.Empty

    Private m_Email As String = String.Empty

    Private m_ConfigtypeCode As String = String.Empty

    Private m_DateEnd As Date = "1/1/1990"

    Private m_DateStart As Date = "1/1/1900"

    Private m_IsActive As Boolean = True

    Private m_IsDelete As Boolean = False

    Private m_Createby As String = String.Empty

    Public ReadOnly Property SalesAccountSpecialistID As Integer
        Get
            Return m_SalesAccountSpecialistID
        End Get
    End Property
    Public Property SalesAccountSpecialistCode As String
        Get
            Return m_SalesAccountSpecialistCode
        End Get
        Set(value As String)
            m_SalesAccountSpecialistCode = value
        End Set
    End Property
    Public Property SalesAccountSpecialistName As String
        Get
            Return m_SalesAccountSpecialistName
        End Get
        Set(value As String)
            m_SalesAccountSpecialistName = value
        End Set
    End Property
    Public Property Gender As Integer
        Get
            Return m_Gender
        End Get
        Set(value As Integer)
            m_Gender = value
        End Set
    End Property
    Public Property PhoneNumber As String
        Get
            Return m_PhoneNumber
        End Get
        Set(value As String)
            m_PhoneNumber = value
        End Set
    End Property
    Public Property Email As String
        Get
            Return m_Email
        End Get
        Set(value As String)
            m_Email = value
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
    Public Property Createby As String
        Get
            Return m_Createby
        End Get
        Set(value As String)
            m_Createby = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As SalesAccountSpecialitsCollection
        Dim col As New SalesAccountSpecialitsCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim m_SalesAccountSpecialist As New SalesAccountSpecialist
            Dim row As DataRow = Table.Rows(j)
            m_SalesAccountSpecialist.m_SalesAccountSpecialistID = row("SalesAccountSpecialistID")
            m_SalesAccountSpecialist.SalesAccountSpecialistCode = row("SalesAccountSpecialistCode")
            m_SalesAccountSpecialist.m_SalesAccountSpecialistName = row("SalesAccountSpecialistName")
            m_SalesAccountSpecialist.m_Gender = row("Gender")
            m_SalesAccountSpecialist.m_PhoneNumber = row("PhoneNumber")
            m_SalesAccountSpecialist.m_Email = row("Email")
            m_SalesAccountSpecialist.m_ConfigtypeCode = row("ConfigtypeCode")
            m_SalesAccountSpecialist.m_DateStart = row("EffectivityStartDate")
            m_SalesAccountSpecialist.m_DateEnd = row("EffectivityEndDate")
            m_SalesAccountSpecialist.m_IsActive = row("IsActive")
            m_SalesAccountSpecialist.m_IsDelete = row("IsDeleted")
            m_SalesAccountSpecialist.m_Createby = row("Createby")
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
            cmd.Parameters.AddWithValue("@SalesAccountSpecilistCode", m_SalesAccountSpecialistCode)
            cmd.Parameters.AddWithValue("@SalesAccountSpecialistName", m_SalesAccountSpecialistName)
            cmd.Parameters.AddWithValue("@Gender", m_Gender)
            cmd.Parameters.AddWithValue("@ContactNo", m_PhoneNumber)
            cmd.Parameters.AddWithValue("@EmailAddress", m_Email)
            cmd.Parameters.AddWithValue("@ConfigtypeCode", m_ConfigtypeCode)
            cmd.Parameters.AddWithValue("@EffectivityStartDate", m_DateStart)
            cmd.Parameters.AddWithValue("@EffectivityEndDate", m_DateEnd)
            cmd.Parameters.AddWithValue("@IsActive", m_IsActive)
            cmd.Parameters.AddWithValue("@IsDeleted", m_IsDelete)
            cmd.Parameters.AddWithValue("@Createby", m_Createby)
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
    Public Shared Function LoadByCode(ByVal SalesAccountSpecialistCode As String) As SalesAccountSpecialist
        Return Filter("SalesAccountSpecialistCode = '" & RefineSQL(SalesAccountSpecialistCode) & "'")(0)
    End Function
    Public Shared Function CheckofSalesAccountSpecialistAlreadyExist(ByVal SalesAccountSpecialistCode As String, ByVal SalesAccountSpecialistID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM SalesAccountSpecialist Where IsDeleted = 0 And SalesAccountSpecialistCode = '" & RefineSQL(SalesAccountSpecialistCode) & "' And SalesAccountSpecialistID <> " & SalesAccountSpecialistID) = "A"
    End Function
    Public Shared Function GetConfigtypeCode() As String
        Return "Select ConfigTypeCode from ConfigurationType Order by ConfigTypeCode"
    End Function
    Public Shared Function GetSalesAccountSpecialistSql() As String
        Return "Select SalesAccountSpecialistID,SalesAccountSpecialistCode [SAS Code],SalesAccountSpecialistName [SAS Name] from SalesAccountSpecialist Where IsDeleted = 0 "
    End Function
    Public Shared Function GetSalesAccountSpecialistMappedSql() As String
        Return "Select SalesAccountSpecialistID,SalesAccountSpecialistCode [SAS Code],SalesAccountSpecialistName [SAS Name],ConfigtypeCode From SalesAccountSpecialist Where IsDeleted = 0 "
    End Function

    Public Shared Function GetSearchSalesAccountSpecialistSql() As String
        Return "Select SalesAccountSpecialistCode [SAS Code],SalesAccountSpecialistName [Sales Account Specialist Name] from SalesAccountSpecialist Where IsDeleted = 0  Order by SalesAccountSpecialistID"
    End Function
End Class
Public Class SalesAccountSpecialitsCollection
    Inherits List(Of SalesAccountSpecialist)
End Class
