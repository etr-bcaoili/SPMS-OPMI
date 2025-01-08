Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class CivilStatus
    Private _ID As Integer = -1
    Private _Code As String = String.Empty
    Private _DescriptionName As String = String.Empty
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
    Public Property DescriptionName As String
        Get
            Return _DescriptionName
        End Get
        Set(value As String)
            _DescriptionName = value
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
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As CivilStatusCollection
        Dim col As New CivilStatusCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _CivilStatus As New CivilStatus
            Dim row As DataRow = Table.Rows(j)
            _CivilStatus._ID = row("ID")
            _CivilStatus._DLTFLG = row("DLTFLG")
            _CivilStatus.Code = row("Code")
            _CivilStatus.DescriptionName = row("Description")
            _CivilStatus._IsAction = row("IsActive")
            col.Add(_CivilStatus)
        Next
        Return col
    End Function
    Public Shared Function Filter(ByVal Condition As String) As CivilStatusCollection
        Return BaseFilter(GetRecords("Select * From CivilStatus Where DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As CivilStatusCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As CivilStatus
        Return Filter("ID =" & ID)(0)
    End Function
    Public Overloads Shared Function LoadByCode(ByVal Code As String) As CivilStatus
        Return Filter("Code = '" & RefineSQL(Code) & "'")(0)
    End Function
    Public Shared Function GetCivilStatusSql() As String
        Return "Select Code,Code,Description From CivilStatus Order by ID"
    End Function
    Public Shared Function GetCivilStatus(ByVal Code As String) As String
        Return LoadByCode(Code).DescriptionName
    End Function
End Class
Public Class CivilStatusCollection
    Inherits List(Of CivilStatus)
End Class
