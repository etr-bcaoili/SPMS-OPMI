Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class DispensingProponent
    Private _ID As Integer = -1
    Private _ProponentCustomerCode As String = String.Empty
    Private _ProponentCode As String = String.Empty
    Private _ProponentName As String = String.Empty
    Private _ProponentShipto As String = String.Empty
    Private _DLTFLG As Boolean = False
    Private _IsAction As Boolean = True
    Private _CustomerID As Integer = -1

    Public ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property
    Public Property ProponentCustomerCode As String
        Get
            Return _ProponentCustomerCode
        End Get
        Set(value As String)
            _ProponentCustomerCode = value
        End Set
    End Property
    Public Property ProponentCode As String
        Get
            Return _ProponentCode
        End Get
        Set(value As String)
            _ProponentCode = value
        End Set
    End Property
    Public Property ProponentName As String
        Get
            Return _ProponentName
        End Get
        Set(value As String)
            _ProponentName = value
        End Set
    End Property
    Public Property ProponentShipto As String
        Get
            Return _ProponentShipto
        End Get
        Set(value As String)
            _ProponentShipto = value
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
    Public Property CustomerID As Integer
        Get
            Return _CustomerID
        End Get
        Set(value As Integer)
            _CustomerID = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As DispensingProponentCollection
        Dim col As New DispensingProponentCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _DispensingProponent As New DispensingProponent
            Dim row As DataRow = Table.Rows(j)
            _DispensingProponent._ID = row("ID")
            _DispensingProponent._DLTFLG = row("DLTFLG")
            _DispensingProponent._ProponentCustomerCode = row("CustomerCode")
            _DispensingProponent._ProponentCode = row("Code")
            _DispensingProponent._ProponentName = row("Name")
            _DispensingProponent._ProponentShipto = row("Shipto")
            _DispensingProponent._IsAction = row("IsActive")
            _DispensingProponent._CustomerID = row("CustomerID")
            col.Add(_DispensingProponent)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspProponent", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Save")
            cmd.Parameters.AddWithValue("@ID", _ID)
            cmd.Parameters.AddWithValue("@DLTFLG", False)
            cmd.Parameters.AddWithValue("@Code", _ProponentCode)
            cmd.Parameters.AddWithValue("@CustomerCode", _ProponentCustomerCode)
            cmd.Parameters.AddWithValue("@Name", _ProponentName)
            cmd.Parameters.AddWithValue("@Shipto", _ProponentShipto)
            cmd.Parameters.AddWithValue("@ISACTIVE", True)
            cmd.Parameters.AddWithValue("@CustomerID", _CustomerID)
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
            Dim cmd As New SqlCommand("uspProponent", SPMSOPCI.ConnectionModule.SPMSConn2)
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
    Public Shared Function Filter(ByVal Condition As String) As DispensingProponentCollection
        Return BaseFilter(GetRecords("Select * From [Proponent] Where DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As DispensingProponentCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As DispensingProponent
        Return Filter("ID =" & ID)(0)
    End Function
    Public Overloads Shared Function LoadByCode(ByVal Code As String) As DispensingProponent
        Return Filter("Code = '" & RefineSQL(Code) & "'")(0)
    End Function
    Public Shared Function GetProponentSql(ByVal Code As String, ByVal Shipto As String) As String
        Return "SELECT ID,Code,Name,Shipto From [Proponent] Where DLTFLG = 0 And Code = '" & Code & "' And Shipto = '" & Shipto & "'"
    End Function
    Public Shared Function DeleteExistProponent(ByVal CustomerCode As String, ByVal ProponentCode As String) As Boolean
        Return ExecuteCommand("DELETE Proponent  WHERE CustomerCode = '" & CustomerCode & "' And Code ='" & ProponentCode & "'")
    End Function
End Class
Public Class DispensingProponentCollection
    Inherits List(Of DispensingProponent)
End Class
