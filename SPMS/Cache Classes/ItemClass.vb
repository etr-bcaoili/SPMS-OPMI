Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class ItemClass
    Private _ID As Integer = -1
    Private _ItemClassCode As String = String.Empty
    Private _ItemClassDescription As String = String.Empty
    Private _DLTFLG As Boolean = False
    Private _IsAction As Boolean = True
    Public ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property
    Public Property ItemClassCode As String
        Get
            Return _ItemClassCode
        End Get
        Set(value As String)
            _ItemClassCode = value
        End Set
    End Property
    Public Property ItemClassDescription As String
        Get
            Return _ItemClassDescription
        End Get
        Set(value As String)
            _ItemClassDescription = value
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
    Public Property IsAction As Boolean
        Get
            Return _IsAction
        End Get
        Set(value As Boolean)
            _IsAction = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As ItemClassCollection
        Dim col As New ItemClassCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _ItemClass As New ItemClass
            Dim row As DataRow = Table.Rows(j)
            _ItemClass._ID = row("ITEMCLASSID")
            _ItemClass._DLTFLG = row("ITEMCLASSDEL")
            _ItemClass._ItemClassCode = row("ITEMCLASSCD")
            _ItemClass._ItemClassDescription = row("ITEMCLASSNAME")
            _ItemClass._IsAction = row("IsActive")
            col.Add(_ItemClass)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspItemClass", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "SAVE")
            cmd.Parameters.AddWithValue("@ITEMCLASSID", _ID)
            cmd.Parameters.AddWithValue("@ITEMCLASSCD", _ItemClassCode)
            cmd.Parameters.AddWithValue("@ITEMCLASSNAME", _ItemClassDescription)
            cmd.Parameters.AddWithValue("@ITEMCLASSDEL", _DLTFLG)
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
            Dim cmd As New SqlCommand("uspItemClass", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "Delete")
            cmd.Parameters.AddWithValue("@ITEMCLASSID", _ID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As ItemClassCollection
        Return BaseFilter(GetRecords("Select * From ITEMCLASS Where ITEMCLASSDEL = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As ItemClassCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As ItemClass
        Return Filter("ITEMCLASSID = " & ID)(0)
    End Function
    Public Overloads Shared Function LoadByCode(ByVal ItemClassCode As String) As ItemClass
        Return Filter("ITEMCLASSCD = '" & ItemClassCode & "'")(0)
    End Function
    Public Shared Function CheckOfItemClassAlreadyExist(ByVal ItemClassCode As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("Select 'A' From ITEMCLASS Where ITEMCLASSDEL = 0 And ITEMCLASSCD = '" & RefineSQL(ItemClassCode) & "' And ITEMCLASSID <> " & ID) = "A"
    End Function
    Public Shared Function GetItemClassSql(Optional ByVal ItemClassCode As String = "") As String
        Return "Select  ITEMCLASSID,ITEMCLASSCD [Item Class Code],ITEMCLASSNAME [Item Class Description] From ITEMCLASS Where ITEMCLASSDEL = 0 "
    End Function
End Class
Public Class ItemClassCollection
    Inherits List(Of ItemClass)
End Class
