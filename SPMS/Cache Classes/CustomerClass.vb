Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class CustomerClass
    Private m_CustomerClassID As Integer = -1
    Private m_CustomerClassCode As String = String.Empty
    Private m_CustomerClassName As String = String.Empty
    Private m_DLTFLG As Boolean = False
    Private m_Createby As String = String.Empty
    Private m_IsActive As Boolean = True

    Public ReadOnly Property ID As Integer
        Get
            Return m_CustomerClassID
        End Get
    End Property
    Public Property CustomrClassCode As String
        Get
            Return m_CustomerClassCode
        End Get
        Set(value As String)
            m_CustomerClassCode = value
        End Set
    End Property
    Public Property CustomerClassName As String
        Get
            Return m_CustomerClassName
        End Get
        Set(value As String)
            m_CustomerClassName = value
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
    Public Property IsActive As Boolean
        Get
            Return m_IsActive
        End Get
        Set(value As Boolean)
            m_IsActive = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As CustomerClassCollection
        Dim col As New CustomerClassCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _CustomerGroup As New CustomerClass
            Dim row As DataRow = Table.Rows(j)
            _CustomerGroup.m_CustomerClassID = row("CUSTOMERCLASSID")
            _CustomerGroup.m_CustomerClassCode = row("CUSTOMERCLASSCD")
            _CustomerGroup.m_CustomerClassName = row("CUSTOMERCLASSNAME")
            _CustomerGroup.m_Createby = row("CRTU")
            _CustomerGroup.m_DLTFLG = row("DLTFLG")
            col.Add(_CustomerGroup)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspCustomerClass", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "ADD")
            cmd.Parameters.AddWithValue("@DLTFLG", False)
            cmd.Parameters.AddWithValue("@CustomerClassCD", m_CustomerClassCode)
            cmd.Parameters.AddWithValue("@CustomerClassNAME", m_CustomerClassName)
            cmd.Parameters.AddWithValue("@CRTU", m_Createby)
            cmd.Parameters.AddWithValue("@ISACTIVE", True)
            m_CustomerClassID = cmd.ExecuteScalar
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
            Dim cmd As New SqlCommand("uspCustomerClass", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "DELETE")
            cmd.Parameters.AddWithValue("@CustomerClassCD", m_CustomerClassCode)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As CustomerClassCollection
        Return BaseFilter(GetRecords("Select * From CustomerClass Where DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As CustomerClassCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As CustomerClass
        Return Filter("CUSTOMERCLASSID = " & ID)(0)
    End Function

    Public Overloads Shared Function LoadByCode(ByVal Code As String) As CustomerClass
        Return Filter("CUSTOMERCLASSCD = '" & RefineSQL(Code) & "'")(0)
    End Function
    Public Shared Function GetCustomerClassSql(Optional ByVal Code As String = "") As String
        Return "Select CustomerClassCD [Customer Class ID] ,CustomerClassCD [Customer Class Code],CustomerClassNAME [Customer Class Name]  from CustomerClass Where DLTFLG =  0 "
    End Function
    Public Shared Function CheckCustomerClass(ByVal CustomerClassCode As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM CustomerClass  WHERE  DLTFLG = 0 AND CustomerClassCD ='" & CustomerClassCode & "'") = "A"
    End Function
End Class
Public Class CustomerClassCollection
    Inherits List(Of CustomerClass)
End Class
