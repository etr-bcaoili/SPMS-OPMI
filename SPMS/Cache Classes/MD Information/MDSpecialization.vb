Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class MDSpecialization
    Private m_ID As Integer = -1

    Private m_Code As String = String.Empty

    Private m_Description As String = String.Empty

    Private m_IsDelete As Boolean = False

    Public ReadOnly Property ID As Integer
        Get
            Return m_ID
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
    Public Property Description As String
        Get
            Return m_Description
        End Get
        Set(value As String)
            m_Description = value
        End Set
    End Property
    Public Property IsDeleted As Boolean
        Get
            Return m_IsDelete
        End Get
        Set(value As Boolean)
            m_IsDelete = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As MDSpecializationCollection
        Dim col As New MDSpecializationCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim m_MDSpecialization As New MDSpecialization
            Dim row As DataRow = Table.Rows(j)
            m_MDSpecialization.m_ID = row("SpecialtyID")
            m_MDSpecialization.m_Code = row("SpecialtyCode")
            m_MDSpecialization.m_Description = row("SpecialtyName")
            m_MDSpecialization.m_IsDelete = row("IsDeleted")
            col.Add(m_MDSpecialization)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspSpecialization", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@SpecialtyID", m_ID)
            cmd.Parameters.AddWithValue("@SpecialtyCode", m_Code)
            cmd.Parameters.AddWithValue("@SpecialtyName", m_Description)
            cmd.Parameters.AddWithValue("@IsDeleted", m_IsDelete)
            m_ID = cmd.ExecuteScalar
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            SPMSOPCI.ConnectionModule.Disconnect()
        End Try
    End Function
    Public Function Delete() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspSpecialization", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "DELETE")
            cmd.Parameters.AddWithValue("@SpecialtyID", m_ID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As MDSpecializationCollection
        Return BaseFilter(GetRecords("SELECT * FROM Specialization  WHERE IsDeleted = 1 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As MDSpecializationCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal SpecialtyID As Integer) As MDSpecialization
        Return Filter("SpecialtyID = " & SpecialtyID)(0)
    End Function
    Public Shared Function LoadByCode(ByVal SpecialtyCode As String) As MDSpecialization
        Return Filter("SpecialtyCode = '" & RefineSQL(SpecialtyCode) & "'")(0)
    End Function
    Public Shared Function CheckofSpecializationAlreadyExist(ByVal Code As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM Specialization Where IsDeleted = 0 And SpecialtyCode = '" & RefineSQL(Code) & "' And SpecialtyID <> " & ID) = "A"
    End Function
    Public Shared Function GetSpecializationSql() As String
        Return "SELECT SpecialtyID,SpecialtyCode,SpecialtyName FROM Specialization WHERE IsDeleted = 1"
    End Function
End Class
Public Class MDSpecializationCollection
    Inherits List(Of MDSpecialization)
End Class