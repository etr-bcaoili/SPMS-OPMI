Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Imports Telerik.WinControls.UI.PivotFieldList
Public Class ProductManager
    Private _ID As Integer = -1
    Private _ProductID As String = String.Empty
    Private _ProductManager As String = String.Empty
    Private _IsActive As Boolean = False
    Private _EffectivityStartDate As Date = "1/1/1990"
    Private _EffectivityEndDate As Date = "1/1/1990"

    Public ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property
    Public Property PriductID As String
        Get
            Return _ProductID
        End Get
        Set(value As String)
            _ProductID = value
        End Set
    End Property
    Public Property ProductManager As String
        Get
            Return _ProductManager
        End Get
        Set(value As String)
            _ProductManager = value
        End Set
    End Property
    Public Property IsActive As Boolean
        Get
            Return _IsActive
        End Get
        Set(value As Boolean)
            _IsActive = value
        End Set
    End Property
    Public Property EffectivityStartDate As Date
        Get
            Return _EffectivityStartDate
        End Get
        Set(value As Date)
            _EffectivityStartDate = value
        End Set
    End Property
    Public Property EffectivityEndDate As Date
        Get
            Return _EffectivityEndDate
        End Get
        Set(value As Date)
            _EffectivityEndDate = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As ProductManagerCollection
        Dim col As New ProductManagerCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _ProductManager As New ProductManager
            Dim row As DataRow = Table.Rows(j)
            _ProductManager._ID = row("ID")
            _ProductManager._ProductID = row("PM_ID")
            _ProductManager._ProductManager = row("PM_Name")
            _ProductManager._IsActive = row("ISACTIVE")
            _ProductManager._EffectivityStartDate = row("EFFECTIVITYSTARTDATE")
            _ProductManager._EffectivityEndDate = row("EFFECTIVITYENDDATE")

            col.Add(_ProductManager)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspProductManagers", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "SAVE")
            cmd.Parameters.AddWithValue("@ID", _ID)
            cmd.Parameters.AddWithValue("@PM_ID", _ProductID)
            cmd.Parameters.AddWithValue("@PM_Name", _ProductManager)
            cmd.Parameters.AddWithValue("@ISACTIVE", True)
            cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", _EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", _EffectivityEndDate)
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
            Dim cmd As New SqlCommand("uspProductManagers", SPMSOPCI.ConnectionModule.SPMSConn2)
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
    Public Shared Function Filter(ByVal Condition As String) As ProductManagerCollection
        Return BaseFilter(GetRecords("Select * From ProductManagers Where ISACTIVE = 1 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As ProductManagerCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As ProductManager
        Return Filter("ID = " & ID)(0)
    End Function
    Public Overloads Shared Function LoadByCode(ByVal PM_ID As String) As ProductManager
        Return Filter("PM_ID = '" & RefineSQL(PM_ID) & "'")(0)
    End Function
    Public Shared Function CheckOProductManagerAlreadyExist(ByVal PM_ID As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM ProductManagers Where ISACTIVE = 1 AND PM_ID = '" & RefineSQL(PM_ID) & "' AND ID <> " & ID) = "A"
    End Function
    Public Shared Function GetProductManagerSql(Optional ByVal PM_ID As String = "") As String
        Return "SELECT ID,PM_ID,PM_Name FROM ProductManagers Where ISACTIVE = 1"
    End Function
End Class
Public Class ProductManagerCollection
    Inherits List(Of ProductManager)
End Class