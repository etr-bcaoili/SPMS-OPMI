Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class CustomerCoordinator
    Private _ID As Integer = -1
    Private _Code As String = String.Empty
    Private _CoordinatorName As String = String.Empty
    Private _DLTFLG As Boolean = False
    Private _IsAction As Boolean = True
    Public ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property
    Public Property Code As String
        Get
            Return _Code
        End Get
        Set(value As String)
            _Code = value
        End Set
    End Property
    Public Property CoordinatorName As String
        Get
            Return _CoordinatorName
        End Get
        Set(value As String)
            _CoordinatorName = value
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
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As CustomerCoordinatorCollection
        Dim col As New CustomerCoordinatorCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _CustomerCoordinator As New CustomerCoordinator
            Dim row As DataRow = Table.Rows(j)
            _CustomerCoordinator._ID = row("ID")
            _CustomerCoordinator._DLTFLG = row("DLTFLG")
            _CustomerCoordinator._Code = row("CODE")
            _CustomerCoordinator._CoordinatorName = row("COORDINATORNAME")
            _CustomerCoordinator._IsAction = row("ISACTIVE")
            col.Add(_CustomerCoordinator)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspCustomerCoordinator", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "SAVE")
            cmd.Parameters.AddWithValue("@ID", _ID)
            cmd.Parameters.AddWithValue("@CODE", _Code)
            cmd.Parameters.AddWithValue("@COORDINATORNAME", _CoordinatorName)
            cmd.Parameters.AddWithValue("@DLTFLG", False)
            cmd.Parameters.AddWithValue("@ISACTIVE", True)
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
            Dim cmd As New SqlCommand("uspCustomerCoordinator", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "Delete")
            cmd.Parameters.AddWithValue("@ID", _ID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As CustomerCoordinatorCollection
        Return BaseFilter(GetRecords("Select * From CustomerCoordinator Where DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As CustomerCoordinatorCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As CustomerCoordinator
        Return Filter("ID = " & ID)(0)
    End Function
    Public Overloads Shared Function LoadByCode(ByVal Code As String) As CustomerCoordinator
        Return Filter("CODE = '" & RefineSQL(Code) & "'")(0)
    End Function
    Public Shared Function CheckOfCustomerCoordinatorExist(ByVal Code As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM CustomerCoordinator Where DLTFLG = 0 AND Code = '" & RefineSQL(Code) & "' AND ID <> " & ID) = "A"
    End Function
    Public Shared Function GetCustomerCoordinatorSql(Optional ByVal Code As String = "") As String
        Return "SELECT ID,Code [Coordinator Code],CoordinatorName [Coordinator Name],case When IsActive = 1 then 'ISACTIVE' Else 'DISACTIVE' END [STATUS] FROM CustomerCoordinator Where DLTFLG = 0"
    End Function
    Public Shared Function GetItemCategoryColumns() As String
        Return "ID;[Coordinator Code];[Coordinator Name];"
    End Function
    Public Shared Function CheckCustomerCoordinator(ByVal CustomerCoordinatorCode As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM CustomerCoordinator  WHERE  DLTFLG = 0 AND Code ='" & CustomerCoordinatorCode & "'") = "A"
    End Function
End Class
Public Class CustomerCoordinatorCollection
    Inherits List(Of CustomerCoordinator)
End Class
