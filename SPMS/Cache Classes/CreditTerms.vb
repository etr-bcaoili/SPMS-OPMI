Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class CreditTerms

    Private m_CreditID As Integer = -1
    Private m_CreditCode As String = String.Empty
    Private m_DLTFLG As Boolean = False
    Private m_CreditName As String = String.Empty
    Private m_CreditDay As String = String.Empty
    Private m_LeadTime As String = String.Empty

    Public ReadOnly Property ID As Integer
        Get
            Return m_CreditID
        End Get
    End Property
    Public Property CreditCode As String
        Get
            Return m_CreditCode
        End Get
        Set(value As String)
            m_CreditCode = value
        End Set
    End Property
    Public Property CreditName As String
        Get
            Return m_CreditName
        End Get
        Set(value As String)
            m_CreditName = value
        End Set
    End Property
    Public Property CreditDays As String
        Get
            Return m_CreditDay
        End Get
        Set(value As String)
            m_CreditDay = value
        End Set
    End Property

    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As CreditTermsCollection
        Dim col As New CreditTermsCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _CreditTerms As New CreditTerms
            Dim row As DataRow = Table.Rows(j)
            _CreditTerms.m_CreditID = row("CRTermKey")
            _CreditTerms.m_CreditCode = row("Code")
            _CreditTerms.m_CreditName = row("CreditTerm")
            _CreditTerms.m_LeadTime = row("LeadTime")
            _CreditTerms.m_CreditDay = row("Days")
            col.Add(_CreditTerms)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspCreditTerms", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "SAVE")
            cmd.Parameters.AddWithValue("@CRTermKey", m_CreditID)
            cmd.Parameters.AddWithValue("@Code", m_CreditCode)
            cmd.Parameters.AddWithValue("@Days", m_CreditDay)
            cmd.Parameters.AddWithValue("@CreditTerm", m_CreditName)
            cmd.Parameters.AddWithValue("@LeadTime", m_LeadTime)
            m_CreditID = cmd.ExecuteScalar
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
            Dim cmd As New SqlCommand("uspCreditTerms", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "Delete")
            cmd.Parameters.AddWithValue("@CRTermKey", m_CreditID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As CreditTermsCollection
        Return BaseFilter(GetRecords("Select * From Credit_Terms Where " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As CreditTermsCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As CreditTerms
        Return Filter("CRTermKey = " & ID)(0)
    End Function
    Public Overloads Shared Function LoadByCode(ByVal Code As String) As CreditTerms
        Return Filter("Code = '" & RefineSQL(Code) & "'")(0)
    End Function
    Public Shared Function GetCreditTermsSql(Optional ByVal Code As String = "") As String
        Return "SELECT CRTermKey [ID], Code [Code],Days [Days],CreditTerm [Credit Term]  FROM Credit_Terms "
    End Function
End Class
Public Class CreditTermsCollection
    Inherits List(Of CreditTerms)
End Class
