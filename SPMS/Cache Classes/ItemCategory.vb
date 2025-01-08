Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class ItemCategory
    Private _ID As Integer = -1
    Private _ItemCode As String = String.Empty
    Private _ItemDescription As String = String.Empty
    Private _DLTFLG As Boolean = False
    Private _IsAction As Boolean = True

    Public ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property
    Public Property ItemCode As String
        Get
            Return _ItemCode
        End Get
        Set(value As String)
            _ItemCode = value
        End Set
    End Property
    Public Property ItemDescription As String
        Get
            Return _ItemDescription
        End Get
        Set(value As String)
            _ItemDescription = value
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
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As ItemCategoryCollection
        Dim col As New ItemCategoryCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _ItemCategory As New ItemCategory
            Dim row As DataRow = Table.Rows(j)
            _ItemCategory._ID = row("ID")
            _ItemCategory._DLTFLG = row("DLTFLG")
            _ItemCategory._ItemCode = row("ITEMCODE")
            _ItemCategory._ItemDescription = row("ITEMDESCRIPTION")
            _ItemCategory._IsAction = row("ISACTIVE")
            col.Add(_ItemCategory)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspItemCategory", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "SAVE")
            cmd.Parameters.AddWithValue("@ID", _ID)
            cmd.Parameters.AddWithValue("@ITEMCODE", _ItemCode)
            cmd.Parameters.AddWithValue("@ITEMDESCRIPTION", _ItemDescription)
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
            Dim cmd As New SqlCommand("uspItemCategory", SPMSOPCI.ConnectionModule.SPMSConn2)
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
    Public Shared Function Filter(ByVal Condition As String) As ItemCategoryCollection
        Return BaseFilter(GetRecords("Select * From ItemCategory Where DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As ItemCategoryCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As ItemCategory
        Return Filter("ID = " & ID)(0)
    End Function
    Public Overloads Shared Function LoadByCode(ByVal ItemCode As String) As ItemCategory
        Return Filter("ItemCode = '" & RefineSQL(ItemCode) & "'")(0)
    End Function
    Public Shared Function CheckOfItemCategoryAlreadyExist(ByVal ItemCode As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM ItemCategory Where DLTFLG = 0 AND ItemCode = '" & RefineSQL(ItemCode) & "' AND ID <> " & ID) = "A"
    End Function
    Public Shared Function GetItemCategorySql(Optional ByVal ItemCode As String = "") As String
        Return "SELECT ID,ItemCode [Item Code],ItemDescription [Item Description],case When IsActive = 1 then 'ISACTIVE' Else 'DISACTIVE' END [STATUS] FROM ItemCategory Where DLTFLG = 0"
    End Function
    Public Shared Function GetItemCategoryColumns() As String
        Return "ID;[ItemCode];[ItemDecription];"
    End Function
End Class
Public Class ItemCategoryCollection
    Inherits List(Of ItemCategory)
End Class
