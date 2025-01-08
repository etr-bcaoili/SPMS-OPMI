Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class UnitOfMeasurement
    Private m_UnitOfMeasurementID As Integer = -1

    Private m_Code As String = String.Empty

    Private m_Description As String = String.Empty

    Private m_CreateDate As Date = "1/1/1900"

    Private m_CreatedBy As String = String.Empty

    Private m_LastModifiedDate As Date = "1/1/1900"

    Private m_LastModifiedBy As String = String.Empty

    Private m_IsDeleted As Boolean = False

    Private m_IsActive As Boolean = True

    Public ReadOnly Property UnitOfMeasurementID As Integer
        Get
            Return m_UnitOfMeasurementID
        End Get
    End Property
    Public Property Code As String
        Get
            Return m_Code
        End Get
        Set(value As String)
            m_Code = value
        End Set
    End Property
    Public Property DescriptionName As String
        Get
            Return m_Description
        End Get
        Set(value As String)
            m_Description = value
        End Set
    End Property
    Public Property CreateDate As Date
        Get
            Return m_CreateDate
        End Get
        Set(value As Date)
            m_CreateDate = value
        End Set
    End Property
    Public Property Createby As String
        Get
            Return m_CreatedBy
        End Get
        Set(value As String)
            m_CreatedBy = value
        End Set
    End Property
    Public Property LastModifielDate As Date
        Get
            Return m_LastModifiedDate
        End Get
        Set(value As Date)
            m_LastModifiedDate = value
        End Set
    End Property
    Public Property LastModifielby As String
        Get
            Return m_LastModifiedBy
        End Get
        Set(value As String)
            m_LastModifiedBy = value
        End Set
    End Property
    Public Property IsDeleted As Boolean
        Get
            Return m_IsDeleted
        End Get
        Set(value As Boolean)
            m_IsDeleted = value
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
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As UnitOfMeasurementCollection
        Dim col As New UnitOfMeasurementCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim _UnitOfMeasurement As New UnitOfMeasurement
            Dim row As DataRow = table.Rows(j)
            _UnitOfMeasurement.m_UnitOfMeasurementID = row("UnitOfMeasurementID")
            _UnitOfMeasurement.m_Code = row("Code")
            _UnitOfMeasurement.m_Description = row("Description")
            _UnitOfMeasurement.m_CreateDate = row("CreateDate")
            _UnitOfMeasurement.m_CreatedBy = row("Createby")
            _UnitOfMeasurement.m_LastModifiedDate = row("LastModifiedDate")
            _UnitOfMeasurement.m_LastModifiedBy = row("LastModifiedBy")
            _UnitOfMeasurement.m_IsDeleted = row("IsDeleted")
            _UnitOfMeasurement.m_IsActive = row("IsActive")
            col.Add(_UnitOfMeasurement)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspUnitOfMeasurement", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "Save")
            cmd.Parameters.AddWithValue("@UnitOfMeasurementID", m_UnitOfMeasurementID)
            cmd.Parameters.AddWithValue("@Code", m_Code)
            cmd.Parameters.AddWithValue("@Description", m_Description)
            cmd.Parameters.AddWithValue("@CreatedBy", m_CreatedBy)
            cmd.Parameters.AddWithValue("@LastModifiedBy", m_LastModifiedBy)
            cmd.Parameters.AddWithValue("@IsDeleted", m_IsDeleted)
            cmd.Parameters.AddWithValue("@IsActive", m_IsActive)
            m_UnitOfMeasurementID = cmd.ExecuteScalar
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Function Delete() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspUnitOfMeasurement", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "Delete")
            cmd.Parameters.AddWithValue("@UnitOfMeasurementID", m_UnitOfMeasurementID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As UnitOfMeasurementCollection
        Return BaseFilter(GetRecords("Select * From Unitofmeasurement Where IsDeleted = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As UnitOfMeasurementCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal UnitOfMeasurementID As Integer) As UnitOfMeasurement
        Return Filter("UnitOfMeasurementID = " & UnitOfMeasurementID)(0)
    End Function

    Public Overloads Shared Function LoadByCode(ByVal Code As String) As UnitOfMeasurement
        Return Filter("Code = '" & RefineSQL(Code) & "'")(0)
    End Function
    Public Shared Function GetUnitOfMeasurementSql(Optional ByVal Code As String = "") As String
        Return "Select UnitOfMeasurementID,Code [Code],Description [Description Name] From UnitOfMeasurement Where IsDeleted = 0  "
    End Function
    Public Shared Function CheckUnitOfMeasurement(ByVal Code As String, ByVal UnitOfMeasurementID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM UnitOfMeasurement  WHERE  IsDeleted = 0 AND Code = '" & Code & "' AND UnitOfMeasurementID <> " & UnitOfMeasurementID) = "A"
    End Function
End Class
Public Class UnitOfMeasurementCollection
    Inherits List(Of UnitOfMeasurement)
End Class