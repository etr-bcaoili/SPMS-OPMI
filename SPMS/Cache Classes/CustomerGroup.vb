Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class CustomerGroup
    Private m_CustomerGroupID As Integer = -1
    Private m_CustomerGroupCode As String = String.Empty
    Private m_CustomerGroupName As String = String.Empty
    Private m_DLTFLG As Boolean = False
    Private m_Createby As String = String.Empty

    Public ReadOnly Property ID As Integer
        Get
            Return m_CustomerGroupID
        End Get
    End Property
    Public Property CustomerGroupCode As String
        Get
            Return m_CustomerGroupCode
        End Get
        Set(value As String)
            m_CustomerGroupCode = value
        End Set
    End Property
    Public Property CustomerGroupName As String
        Get
            Return m_CustomerGroupName
        End Get
        Set(value As String)
            m_CustomerGroupName = value
        End Set
    End Property
    Public Property DLTFLG As Boolean
        Get
            Return m_DLTFLG
        End Get
        Set(value As Boolean)
            m_DLTFLG = value
        End Set
    End Property
    Public Property Createby As String
        Get
            Return m_Createby
        End Get
        Set(value As String)
            m_Createby = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As CustomerGroupCollection
        Dim col As New CustomerGroupCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _CustomerGroup As New CustomerGroup
            Dim row As DataRow = Table.Rows(j)
            _CustomerGroup.m_CustomerGroupID = row("CUSTOMERGROUPID")
            _CustomerGroup.m_CustomerGroupCode = row("CUSTOMERGROUPCD")
            _CustomerGroup.m_CustomerGroupName = row("CUSTOMERGROUPNAME")
            _CustomerGroup.m_Createby = row("CRTU")
            _CustomerGroup.m_DLTFLG = row("DLTFLG")
            col.Add(_CustomerGroup)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspCustomerGroup", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "ADD")
            cmd.Parameters.AddWithValue("@DLTFLG", False)
            cmd.Parameters.AddWithValue("@CustomerGroupCD", m_CustomerGroupCode)
            cmd.Parameters.AddWithValue("@CustomerGroupNAME", m_CustomerGroupName)
            cmd.Parameters.AddWithValue("@CRTU", m_Createby)
            cmd.Parameters.AddWithValue("@ISACTIVE", True)
            m_CustomerGroupID = cmd.ExecuteScalar
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
            Dim cmd As New SqlCommand("uspCustomerGroup", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "Delete")
            cmd.Parameters.AddWithValue("@CustomerGroupCD", m_CustomerGroupCode)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As CustomerGroupCollection
        Return BaseFilter(GetRecords("Select * From CustomerGroup Where DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As CustomerGroupCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function LoadByCode(ByVal Code As String) As CustomerGroup
        Return Filter("CustomerGroupCD = '" & RefineSQL(Code) & "'")(0)
    End Function
    Public Shared Function GetCustomerGroupSql(Optional ByVal Code As String = "") As String
        Return "Select CUSTOMERGROUPCD [Customer Group Code],CustomerGroupName [Customer Group Name]  from CustomerGroup Where DLTFLG =  0 "
    End Function
    Public Shared Function CheckCustomerGroup(ByVal CustomerGroupCode As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM CustomerGroup  WHERE  DLTFLG = 0 AND CUSTOMERGROUPCD ='" & CustomerGroupCode & "'") = "A"
    End Function
End Class
Public Class CustomerGroupCollection
    Inherits List(Of CustomerGroup)
End Class
