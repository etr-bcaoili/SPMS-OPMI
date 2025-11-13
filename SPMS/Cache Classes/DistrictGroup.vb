Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.STRegion
Imports System.Data.SqlClient
Public Class DistrictGroup
    Private m_ID As Integer = -1

    Private m_Code As String = String.Empty

    Private m_Description As String = String.Empty

    Private m_Createby As String = String.Empty
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
    Public Property Createby As String
        Get
            Return m_Createby
        End Get
        Set(value As String)
            m_Createby = value
        End Set
    End Property
    Public Function Save() As Boolean
        Connect()
        Try
            Dim cmd As New SqlCommand("uspDistrictGroup", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Save")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.Parameters.AddWithValue("@Code", m_Code)
            cmd.Parameters.AddWithValue("@Description", m_Description)
            cmd.Parameters.AddWithValue("@Createby", m_Createby)
            m_ID = cmd.ExecuteScalar
            Disconnect()
            Return True
        Catch ex As System.Exception
            Disconnect()
        End Try
    End Function
    Public Function Delete() As Boolean
        Connect()
        Try
            Dim cmd As New SqlCommand("uspDistrictGroup", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "DELETE")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.ExecuteNonQuery()
            Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As DistrictGroupCollection
        Dim col As New DistrictGroupCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_DistrictGroup As New DistrictGroup
            Dim row As DataRow = table.Rows(j)
            m_DistrictGroup.m_ID = row("ID")
            m_DistrictGroup.m_Code = row("Code")
            m_DistrictGroup.m_Description = row("Description")
            m_DistrictGroup.m_Createby = row("Createby")
            col.Add(m_DistrictGroup)
        Next
        Return col
    End Function
    Public Shared Function Filter(ByVal Condition As String) As DistrictGroupCollection
        Return BaseFilter(GetRecords("Select * from [DistrictGroup]  WHERE [IsDeleted] = 0" & IIf(Condition <> "", " AND " & Condition, "")))
    End Function
    Public Overloads Shared Function Load() As DistrictGroupCollection
        Return Filter("")
    End Function

    Public Overloads Shared Function Load(ByVal ID As Integer) As DistrictGroup
        Return Filter("ID = " & ID)(0)
    End Function
    Public Shared Function LoadByCode(ByVal Pm_code As String) As DistrictGroup
        Return Filter("Code = '" & HandleSingleQuoteInSql(Pm_code) & "'")(0)
    End Function
    Public Shared Function CheckDistrictGroupIsAlreadyExist(ByVal Code As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM DistrictGroup Where IsDeleted = 0 AND Code = '" & RefineSQL(Code) & "' AND ID <> " & ID) = "A"
    End Function
    Public Shared Function GetDistrictGroupql() As String
        Return "Select ID, Code [Code], Description [Description Name] From DistrictGroup"
    End Function
End Class
Public Class DistrictGroupCollection
    Inherits List(Of DistrictGroup)
End Class