Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class ItemProductAssignment
    Private _ID As Integer = -1
    Private _ItemProductID As String = String.Empty
    Private _ItemProductManagerAssignment As String = String.Empty
    Private _DLTFLG As Boolean = False
    Private _IsAction As Boolean = True
    Public ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property
    Public Property ItemPriductID As String
        Get
            Return _ItemProductID
        End Get
        Set(value As String)
            _ItemProductID = value
        End Set
    End Property
    Public Property ItemProductManagerAssignment As String
        Get
            Return _ItemProductManagerAssignment
        End Get
        Set(value As String)
            _ItemProductManagerAssignment = value
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
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As ItemProductAssignmentCollection
        Dim col As New ItemProductAssignmentCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _ItemCategory As New ItemProductAssignment
            Dim row As DataRow = Table.Rows(j)
            _ItemCategory._ID = row("ID")
            _ItemCategory._DLTFLG = row("DLTFLG")
            _ItemCategory._ItemProductID = row("ITEMPRODUCTID")
            _ItemCategory._ItemProductManagerAssignment = row("ITEMPRODUCTMANAGERASSIGNMENT")
            _ItemCategory._IsAction = row("ISACTIVE")
            col.Add(_ItemCategory)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspItemProductManagerAssignment", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "SAVE")
            cmd.Parameters.AddWithValue("@ID", _ID)
            cmd.Parameters.AddWithValue("@ITEMPRODUCTID", _ItemProductID)
            cmd.Parameters.AddWithValue("@ITEMPRODUCTMANAGERASSIGNMENT", _ItemProductManagerAssignment)
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
            Dim cmd As New SqlCommand("uspItemProductManagerAssignment", SPMSOPCI.ConnectionModule.SPMSConn2)
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
    Public Shared Function Filter(ByVal Condition As String) As ItemProductAssignmentCollection
        Return BaseFilter(GetRecords("Select * From ItemProductManagerAssigment Where DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As ItemProductAssignmentCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As ItemProductAssignment
        Return Filter("ID = " & ID)(0)
    End Function
    Public Overloads Shared Function LoadByCode(ByVal ItemProductID As String) As ItemProductAssignment
        Return Filter("ITEMPRODUCTID = '" & RefineSQL(ItemProductID) & "'")(0)
    End Function
    Public Shared Function CheckOfItemProductManagerAlreadyExist(ByVal ItemCode As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM ItemProductManagerAssigment Where DLTFLG = 0 AND ITEMPRODUCTID = '" & RefineSQL(ItemCode) & "' AND ID <> " & ID) = "A"
    End Function
    Public Shared Function GetItemProductManagerAssigmentSql(Optional ByVal ItemCode As String = "") As String
        Return "SELECT ID,ITEMPRODUCTID [Item ProductID],ITEMPRODUCTMANAGERASSIGNMENT [Item Product Manager Assignment] ,case When IsActive = 1 then 'ISACTIVE' Else 'DISACTIVE' END [STATUS] FROM ItemProductManagerAssigment Where DLTFLG = 0"
    End Function
    Public Shared Function GetItemCategoryColumns() As String
        Return "ID;[Item ProductID];[Item Product Manager Assignment];"
    End Function
End Class
Public Class ItemProductAssignmentCollection
    Inherits List(Of ItemProductAssignment)
End Class
