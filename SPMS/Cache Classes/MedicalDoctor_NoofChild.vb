Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class MedicalDoctor_NoofChild
    Private m_ID As Integer = -1

    Private m_DoctorID As String = String.Empty

    Private m_DoctorCode As String = String.Empty

    Private m_FullName As String = String.Empty

    Private m_Age As Integer = -1
    Public ReadOnly Property ID() As Integer
        Get
            Return m_ID
        End Get
    End Property
    Public Property DoctorCode() As String
        Get
            Return m_DoctorCode
        End Get
        Set(ByVal value As String)
            m_DoctorCode = value
        End Set
    End Property
    Public Property DoctorID As Integer
        Get
            Return m_DoctorID
        End Get
        Set(value As Integer)
            m_DoctorID = value
        End Set
    End Property
    Public Property FullName As String
        Get
            Return m_FullName
        End Get
        Set(value As String)
            m_FullName = value
        End Set
    End Property
    Public Property Age As String
        Get
            Return m_Age
        End Get
        Set(value As String)
            m_Age = value
        End Set
    End Property
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspMedicalDoctor_NoofChild", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.Parameters.AddWithValue("@DOCTORID", m_DoctorID)
            cmd.Parameters.AddWithValue("@DoctorCode", m_DoctorCode)
            cmd.Parameters.AddWithValue("@FullName", m_FullName)
            cmd.Parameters.AddWithValue("@Age", m_Age)
            m_ID = cmd.ExecuteScalar()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As MedicalDoctor_NoofChildCollection
        Dim col As New MedicalDoctor_NoofChildCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_MedicalDoctor_NoofChild As New MedicalDoctor_NoofChild
            Dim row As DataRow = table.Rows(j)
            m_MedicalDoctor_NoofChild.m_ID = row("ID")
            m_MedicalDoctor_NoofChild.m_DoctorID = row("DOCTORID")
            m_MedicalDoctor_NoofChild.m_DoctorCode = row("DoctorCode")
            m_MedicalDoctor_NoofChild.m_FullName = row("FullName")
            m_MedicalDoctor_NoofChild.m_Age = row("Age")
            col.Add(m_MedicalDoctor_NoofChild)
        Next
        Return col
    End Function
    Public Shared Function Filter(ByVal Condition As String) As MedicalDoctor_NoofChildCollection
        Return BaseFilter(GetRecords("SELECT * FROM MedicalDoctor_NoofChild  WHERE DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As MedicalDoctor_NoofChildCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As MedicalDoctor_NoofChild
        Return Filter("ID = " & ID)(0)
    End Function

    Public Shared Function LoadByCode(ByVal DOCTORID As String) As MedicalDoctor_NoofChild
        Return Filter("DOCTORID = '" & RefineSQL(DOCTORID) & "'")(0)
    End Function
    Public Shared Function GetMedicalDoctorNoofChildSql(Optional ByVal DoctorID As String = "") As String
        Return "SELECT FullName,Age FROM MedicalDoctor_NoofChild Where DLTFLG = 0 Where DOCTORID = '" & DoctorID & "'"
    End Function
End Class
Public Class MedicalDoctor_NoofChildCollection
    Inherits List(Of MedicalDoctor_NoofChild)
End Class
