Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class DispensingPioneer
    Private _ID As Integer = -1
    Private _PioneerCustomerCode As String = String.Empty
    Private _PioneerCode As String = String.Empty
    Private _PioneerName As String = String.Empty
    Private _PioneerShipto As String = String.Empty
    Private _DLTFLG As Boolean = False
    Private _IsAction As Boolean = True
    Private _CustomerID As Integer = -1

    Public ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property
    Public Property PioneerCustomerCode As String
        Get
            Return _PioneerCustomerCode
        End Get
        Set(value As String)
            _PioneerCustomerCode = value
        End Set
    End Property
    Public Property PioneerCode As String
        Get
            Return _PioneerCode
        End Get
        Set(value As String)
            _PioneerCode = value
        End Set
    End Property
    Public Property PioneerName As String
        Get
            Return _PioneerName
        End Get
        Set(value As String)
            _PioneerName = value
        End Set
    End Property
    Public Property PioneerShipTo As String
        Get
            Return _PioneerShipto
        End Get
        Set(value As String)
            _PioneerShipto = value
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
    Public Property IsAction As String
        Get
            Return _IsAction
        End Get
        Set(value As String)
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
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As DispensingPioneerCollection
        Dim col As New DispensingPioneerCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _Dispensingpioneer As New DispensingPioneer
            Dim row As DataRow = Table.Rows(j)
            _Dispensingpioneer._ID = row("ID")
            _Dispensingpioneer._DLTFLG = row("DLTFLG")
            _Dispensingpioneer._PioneerCustomerCode = row("CustomerCod")
            _Dispensingpioneer._PioneerCode = row("Code")
            _Dispensingpioneer._PioneerName = row("Name")
            _Dispensingpioneer._PioneerShipto = row("Shipto")
            _Dispensingpioneer._IsAction = row("IsActive")
            _Dispensingpioneer._CustomerID = row("CustomerID")
            col.Add(_Dispensingpioneer)
        Next
        Return col
    End Function
    Public Function Save() As Boolean

        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspPioneer", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Save")
            cmd.Parameters.AddWithValue("@ID", _ID)
            cmd.Parameters.AddWithValue("@DLTFLG", False)
            cmd.Parameters.AddWithValue("@CustomerCode", _PioneerCustomerCode)
            cmd.Parameters.AddWithValue("@Code", _PioneerCode)
            cmd.Parameters.AddWithValue("@Name", _PioneerName)
            cmd.Parameters.AddWithValue("@Shipto", _PioneerShipto)
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
            Dim cmd As New SqlCommand("uspPioneer", SPMSOPCI.ConnectionModule.SPMSConn2)
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
    Public Shared Function Filter(ByVal Condition As String) As DispensingPioneerCollection
        Return BaseFilter(GetRecords("Select * From [Pioneer] Where DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As DispensingPioneerCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As DispensingPioneer
        Return Filter("ID =" & ID)(0)
    End Function
    Public Overloads Shared Function LoadByCode(ByVal Code As String) As DispensingPioneer
        Return Filter("Code = '" & RefineSQL(Code) & "'")(0)
    End Function
    Public Shared Function GetPioneerSql(ByVal Code As String, ByVal Shipto As String) As String
        Return "SELECT ID,Code,Name,Shipto From [Pioneer] Where DLTFLG = 0 And Code = '" & Code & "' And Shipto = '" & Shipto & "'"
    End Function
    Public Shared Function DeleteExistPioneer(ByVal CustomerCode As String, ByVal PioneerCode As String) As Boolean
        Return ExecuteCommand("DELETE Pioneer  WHERE CustomerCode = '" & CustomerCode & "' And Code ='" & PioneerCode & "'")
    End Function
End Class
Public Class DispensingPioneerCollection
    Inherits List(Of DispensingPioneer)
End Class
