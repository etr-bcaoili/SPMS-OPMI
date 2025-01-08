Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class ItemGroup
    Private _ID As Integer = -1
    Private _ItemGroupCode As String = String.Empty
    Private _ItemGroupDescription As String = String.Empty
    Private _DLTFLG As Boolean = False
    Private _IsAction As Boolean = True

    Public ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property
    Public Property ItemGroupCode As String
        Get
            Return _ItemGroupCode
        End Get
        Set(value As String)
            _ItemGroupCode = value
        End Set
    End Property
    Public Property ItemGroupDescription As String
        Get
            Return _ItemGroupDescription
        End Get
        Set(value As String)
            _ItemGroupDescription = value
        End Set
    End Property
    Public Property IsAction As Boolean
        Get
            Return _IsAction
        End Get
        Set(value As Boolean)
            _IsAction = value
        End Set
    End Property
    Public Property DLTFLG As Boolean
        Get
            Return _DLTFLG
        End Get
        Set(value As Boolean)
            _DLTFLG = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As ItemGroupCollection
        Dim col As New ItemGroupCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _ItemGroup As New ItemGroup
            Dim row As DataRow = Table.Rows(j)
            _ItemGroup._ID = row("ITEMGROUPID")
            _ItemGroup._ItemGroupCode = row("ITEMGROUPCD")
            _ItemGroup._ItemGroupDescription = row("ITEMGROUPNAME")
            _ItemGroup._IsAction = row("ISACTIVE")
            _ItemGroup._DLTFLG = row("ITEMGROUPDEL")
            col.Add(_ItemGroup)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspItemGroup", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "SAVE")
            cmd.Parameters.AddWithValue("@ITEMGROUPID", _ID)
            cmd.Parameters.AddWithValue("@ITEMGROUPCD", _ItemGroupCode)
            cmd.Parameters.AddWithValue("@ITEMGROUPNAME", _ItemGroupDescription)
            cmd.Parameters.AddWithValue("@ITEMGROUPDEL", _DLTFLG)
            cmd.Parameters.AddWithValue("@ISACTIVE", _IsAction)
            _ID = cmd.ExecuteScalar
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
            Dim cmd As New SqlCommand("uspItemGroup", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "Delete")
            cmd.Parameters.AddWithValue("@ITEMGROUPID", _ID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As ItemGroupCollection
        Return BaseFilter(GetRecords("Select * From ItemGroup Where ITEMGROUPDEL = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As ItemGroupCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As ItemGroup
        Return Filter("ITEMGROUPID = " & ID)(0)
    End Function
    Public Overloads Shared Function LoadByCode(ByVal ItemGroupCode As String) As ItemGroup
        Return Filter("ITEMGROUPCD = '" & RefineSQL(ItemGroupCode) & "'")(0)
    End Function
    Public Shared Function CheckOfItemGroupAlreadyExist(ByVal ItemGroupCode As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM ItemGroup Where ITEMGROUPDEL = 0 AND ITEMGROUPCD = '" & RefineSQL(ItemGroupCode) & "' AND ITEMGROUPID <> " & ID) = "A"
    End Function
    Public Shared Function GetItemGroupSql(Optional ByVal ItemCode As String = "") As String
        Return "SELECT ITEMGROUPID,ITEMGROUPCD [Item Group Code],ITEMGROUPNAME [Item Group Description],case When IsActive = 1 then 'ISACTIVE' Else 'DISACTIVE' END [STATUS] FROM ItemGroup Where ITEMGROUPDEL = 0"
    End Function
End Class
Public Class ItemGroupCollection
    Inherits List(Of ItemGroup)
End Class
