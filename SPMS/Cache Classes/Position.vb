Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class Position
    Private m_ID As Integer = -1

    Private m_Code As String = String.Empty

    Private m_Description As String = String.Empty

    Private m_EffectivityStartDate As Date = "1/1/1990"

    Private m_EffectivityEndDate As Date = "1/1/1900"

    Private m_IsActive As Boolean = True

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
    Public Property IsActive As Boolean
        Get
            Return m_IsActive
        End Get
        Set(value As Boolean)
            m_IsActive = value
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
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As PositionCollection
        Dim col As New PositionCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim m_Position As New Position
            Dim row As DataRow = Table.Rows(j)
            m_Position.m_ID = row("ID")
            m_Position.m_Code = row("Code")
            m_Position.m_Description = row("Description")
            m_Position.m_IsActive = row("IsActive")
            m_Position.m_IsDelete = row("IsDeleted")
            m_Position.m_EffectivityStartDate = row("EffectivityStartDate")
            m_Position.m_EffectivityEndDate = row("EffectivityEndDate")
            col.Add(m_Position)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspPosition", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.Parameters.AddWithValue("@Code  ", m_Code)
            cmd.Parameters.AddWithValue("@Description", m_Description)
            cmd.Parameters.AddWithValue("@EffectivityStartDate", m_EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EffectivityEndDate", m_EffectivityStartDate)
            cmd.Parameters.AddWithValue("@IsActive", m_IsActive)
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
            Dim cmd As New SqlCommand("uspPosition", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "DELETE")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As PositionCollection
        Return BaseFilter(GetRecords("SELECT * FROM [Position]  WHERE IsDeleted = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As PositionCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As Position
        Return Filter("ID = " & ID)(0)
    End Function
    Public Shared Function LoadByCode(ByVal Code As String) As Position
        Return Filter("Code = '" & RefineSQL(Code) & "'")(0)
    End Function
    Public Shared Function CheckofPositionAlreadyExist(ByVal Code As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM Position Where IsDeleted = 0 And Code = '" & RefineSQL(Code) & "' And ID <> " & ID) = "A"
    End Function
    Public Shared Function GetPositionSql() As String
        Return "SELECT ID,Code,Description FROM [Position] WHERE IsDeleted = 0"
    End Function
End Class
Public Class PositionCollection
    Inherits List(Of Position)
End Class
