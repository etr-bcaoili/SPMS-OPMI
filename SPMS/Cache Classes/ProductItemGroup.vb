Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class ProductItemGroup
    Private m_ID As Integer = -1

    Private m_PGCode As String = String.Empty

    Private m_PGDescription As String = String.Empty

    Private m_DLTFLG As Boolean = False

    Private m_Createby As String = String.Empty

    Public ReadOnly Property ID As Integer
        Get
            Return m_ID
        End Get
    End Property
    Public Property PGCode As String
        Get
            Return m_PGCode
        End Get
        Set(value As String)
            m_PGCode = value
        End Set
    End Property
    Public Property PGDescription As String
        Get
            Return m_PGDescription
        End Get
        Set(value As String)
            m_PGDescription = value
        End Set
    End Property
    Public Property DLFLG As Boolean
        Get
            Return m_DLTFLG
        End Get
        Set(value As Boolean)
            m_DLTFLG = value
        End Set
    End Property

    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspProductItemGroup", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.Parameters.AddWithValue("@PGCode", m_PGCode)
            cmd.Parameters.AddWithValue("@PGDescription", m_PGDescription)
            cmd.Parameters.AddWithValue("@DLTFLG", m_DLTFLG)
            m_ID = cmd.ExecuteScalar()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Function Delete() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspProductItemGroup", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "DELETE")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As ProductItemGroupCollection
        Dim col As New ProductItemGroupCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_ProductItemGroup As New ProductItemGroup
            Dim row As DataRow = table.Rows(j)
            m_ProductItemGroup.m_ID = row("ID")
            m_ProductItemGroup.m_PGCode = row("PGCode")
            m_ProductItemGroup.m_PGDescription = row("PGDescription")
            m_ProductItemGroup.m_DLTFLG = row("DLTFLG")
            m_ProductItemGroup.m_Createby = row("CRTU")
            col.Add(m_ProductItemGroup)
        Next
        Return col
    End Function
    Public Shared Function Filter(ByVal Condition As String) As ProductItemGroupCollection
        Return BaseFilter(GetRecords("SELECT * FROM ProductItemGroup  WHERE DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As ProductItemGroupCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As ProductItemGroup
        Return Filter("ID = " & ID)(0)
    End Function
    Public Shared Function LoadByCode(ByVal PGCode As String) As ProductItemGroup
        Return Filter("PGCode = '" & RefineSQL(PGCode) & "'")(0)
    End Function
    Public Shared Function CheckofProductItemGroupAlreadyExist(ByVal PGCode As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM ProductItemGroup WHERE DLTFLG = 0 AND  PGCode = '" & RefineSQL(PGCode) & "' AND ID <> " & ID) = "A"
    End Function
    Public Shared Function CheckofProductItemGroupCodeExist(ByVal PGCode As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM ProductItemGroup WHERE DLTFLG = 0 AND  PGCode = '" & RefineSQL(PGCode) & "'") = "A"
    End Function
    Public Shared Function GetProductItemGroupSql(Optional ByVal CustomerGroup As String = "") As String
        Return "SELECT ID,PGCode [Product Item Code],PGDescription [Product Item Group Description] FROM ProductItemGroup Where DLTFLG = 0 AND  "
    End Function
    Public Shared Function GetProductGroupList()
        Return "Select PGCode,PGDescription from ProductItemGroup Where PGCode NOT IN ('99','NPP')"
    End Function
    Public Shared Function GetPMRList()
        Return "Select PMRAB,PMRC,PMRD,PMREF,ID from [ItemSharingbyPMR]"
    End Function
    Public Shared Function GetProductItemGroupColumns() As String
        Return "ID; [Product Item Code]; [Product Item Group Description];"
    End Function
End Class
Public Class ProductItemGroupCollection
    Inherits List(Of ProductItemGroup)
End Class
