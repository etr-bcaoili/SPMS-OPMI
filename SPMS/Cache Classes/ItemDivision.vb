Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class ItemDivision
    Private _ID As Integer = -1
    Private _ItemDivisionCode As String = String.Empty
    Private _ItemDivisionName As String = String.Empty
    Private _DLTFLG As Boolean = False
    Private _IsAction As Boolean = True

    Public ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property
    Public Property ItemDivisionCode As String
        Get
            Return _ItemDivisionCode
        End Get
        Set(value As String)
            _ItemDivisionCode = value
        End Set
    End Property
    Public Property ItemDivisionName As String
        Get
            Return _ItemDivisionName
        End Get
        Set(value As String)
            _ItemDivisionName = value
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
            _IsAction = True
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As ItemDivisionCollection
        Dim col As New ItemDivisionCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _ItemDivision As New ItemDivision
            Dim row As DataRow = Table.Rows(j)
            _ItemDivision._ID = row("ITEMDIVISIONID")
            _ItemDivision._ItemDivisionCode = row("ITMDIVCD")
            _ItemDivision._ItemDivisionName = row("ITMDIVNAME")
            _ItemDivision._DLTFLG = row("DLTFLG")
            _ItemDivision._IsAction = row("IsActive")
            col.Add(_ItemDivision)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspItemDivision", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "SAVE")
            cmd.Parameters.AddWithValue("@ITEMDIVID", _ID)
            cmd.Parameters.AddWithValue("@ITMDIVCD", _ItemDivisionCode)
            cmd.Parameters.AddWithValue("@ITMDIVNAME", _ItemDivisionName)
            cmd.Parameters.AddWithValue("@DLTFLG", _DLTFLG)
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
            Dim cmd As New SqlCommand("uspItemDivision", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "Delete")
            cmd.Parameters.AddWithValue("@ITEMDIVID", _ID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As ItemDivisionCollection
        Return BaseFilter(GetRecords("Select * From ItemDivision Where DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As ItemDivisionCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As ItemDivision
        Return Filter("ITEMDIVISIONID = " & ID)(0)
    End Function
    Public Overloads Shared Function LoadByCode(ByVal ItemDivisionCode As String) As ItemDivision
        Return Filter("ITMDIVCD = '" & RefineSQL(ItemDivisionCode) & "'")(0)
    End Function
    Public Shared Function CheckOfItemDivisionAlreadyExist(ByVal ItemDivisionCode As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("Select 'A' From ItemDivision Where DLTFLG = 0 And ITMDIVCD = '" & RefineSQL(ItemDivisionCode) & "' And ITEMDIVISIONID <> " & ID) = "A"
    End Function
    Public Shared Function GetItemDivisionSql(Optional ByVal ItemDivisionCode As String = "") As String
        Return "Select ITEMDIVISIONID,ITMDIVCD [Item Division Code],ITMDIVNAME [Item Division Name] From ITEMDIVISION Where DLTFLG = 0"
    End Function

End Class
Public Class ItemDivisionCollection
    Inherits List(Of ItemDivision)
End Class
