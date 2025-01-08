Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class Coordinator
    Private _ID As Integer = -1
    Private _CoordinatorID As String = String.Empty
    Private _CoordinatorName As String = String.Empty
    Private _DLTFLG As Boolean = False
    Private _IsAction As Boolean = True
    Public ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property
    Public Property CoordinatorID As String
        Get
            Return _CoordinatorID
        End Get
        Set(value As String)
            _CoordinatorID = value
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
    Public Property IsActive As Boolean
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
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As CoordinatoCollection
        Dim col As New CoordinatoCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _Coordinator As New Coordinator
            Dim row As DataRow = Table.Rows(j)
            _Coordinator._ID = row("ID")
            _Coordinator._DLTFLG = row("DLTFLG")
            _Coordinator.CoordinatorID = row("Coordinatorid")
            _Coordinator._CoordinatorName = row("CoordinatorName")
            _Coordinator._IsAction = row("IsActive")
            col.Add(_Coordinator)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspItem_Coordinator", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Save")
            cmd.Parameters.AddWithValue("@ID", _ID)
            cmd.Parameters.AddWithValue("@Coordinatorid", _CoordinatorID)
            cmd.Parameters.AddWithValue("@CoordinatorName", _CoordinatorName)
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
            Dim cmd As New SqlCommand("uspItem_Coordinator", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Delete")
            cmd.Parameters.AddWithValue("@ID", ID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As CoordinatoCollection
        Return BaseFilter(GetRecords("Select * From Coordinator Where DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As CoordinatoCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As Coordinator
        Return Filter("ID =" & ID)(0)
    End Function
    Public Overloads Shared Function LoadByCode(ByVal CoordinatoID As String) As Coordinator
        Return Filter("Coordinatorid = '" & RefineSQL(CoordinatoID) & "'")(0)
    End Function
    Public Shared Function CheckOfCoordinatorAlreadyExist(ByVal CoodinatorID As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("Select 'A' From Coordinator Where DLTFLG = 0 And Coordinatorid = '" & RefineSQL(CoodinatorID) & "' And ID <> " & ID) = "A"
    End Function
    Public Shared Function GetCoordinatorSql(Optional ByVal CoordinatorID As String = "") As String
        Return "SELECT Coordinatorid,Coordinatorid [Customer Class Code],CoordinatorName [Customer Class Name] ,case When IsActive = 1 then 'ISACTIVE' Else 'DISACTIVE' END [STATUS] FROM [Coordinator] Where DLTFLG = 0"
    End Function
    Public Shared Function GetCoordinatorSqlID(Optional ByVal CoordinatorID As String = "") As String
        Return "SELECT ID,Coordinatorid [Customer Class Code],CoordinatorName [Customer Class Name] ,case When IsActive = 1 then 'ISACTIVE' Else 'DISACTIVE' END [STATUS] FROM [Coordinator] Where DLTFLG = 0"
    End Function
    Public Shared Function GetCoordinator_ItemSql() As String
        Return "Select Distinct Itemcd,Itemcd [Item Code],Itemmdes [Item Description],ITEMDIVNAME [Item Division] From Item Order by ITEMCD"
    End Function
    Public Shared Function GetItemCategoryColumns() As String
        Return "ID;[Coordinator ID];[Coordinator Name];"
    End Function
    Public Shared Function CheckCustomerClass(ByVal CustomerClass As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM Coordinator  WHERE  DLTFLG = 0 AND Coordinatorid ='" & CustomerClass & "'") = "A"
    End Function

End Class

Public Class CoordinatoCollection
    Inherits List(Of Coordinator)
End Class