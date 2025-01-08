Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class MedicalDoctor_EducationalAndSkill

    Private m_ID As Integer = -1

    Private m_DoctorID As String = String.Empty

    Private m_DoctorCode As String = String.Empty

    Private m_PostGraduate As String = String.Empty

    Private m_PostGraduateDate As Date = "1/1/1990"

    Private m_MedicalSchoolGraduate As String = String.Empty

    Private m_MedicalGraduateDate As Date = "1/1/1990"

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

    Public Property PostGraduate As String
        Get
            Return m_PostGraduate
        End Get
        Set(value As String)
            m_PostGraduate = value
        End Set
    End Property

    Public Property PostGraduateDate As Date
        Get
            Return m_PostGraduateDate
        End Get
        Set(value As Date)
            m_PostGraduateDate = value
        End Set
    End Property

    Public Property MedicalSchoolGraduate As String
        Get
            Return m_MedicalSchoolGraduate
        End Get
        Set(value As String)
            m_MedicalSchoolGraduate = value
        End Set
    End Property

    Public Property MedicalGraduateDate As Date
        Get
            Return m_MedicalGraduateDate
        End Get
        Set(value As Date)
            m_MedicalGraduateDate = value
        End Set
    End Property

    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspMedicalDoctor_EducationalAndSkill", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.Parameters.AddWithValue("@DOCTORID", m_DoctorID)
            cmd.Parameters.AddWithValue("@DoctorCode", m_DoctorCode)
            cmd.Parameters.AddWithValue("@FullName", m_PostGraduate)
            cmd.Parameters.AddWithValue("@Age", m_PostGraduateDate)
            cmd.Parameters.AddWithValue("@MedicalSchoolGraduate", m_MedicalSchoolGraduate)
            cmd.Parameters.AddWithValue("@MedicalGraduateDate", m_MedicalGraduateDate)
            m_ID = cmd.ExecuteScalar()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As MedicalDoctor_EducationalAndSkillCollection
        Dim col As New MedicalDoctor_EducationalAndSkillCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_MedicalDoctor_EducationalAndSkill As New MedicalDoctor_EducationalAndSkill
            Dim row As DataRow = table.Rows(j)
            m_MedicalDoctor_EducationalAndSkill.m_ID = row("ID")
            m_MedicalDoctor_EducationalAndSkill.m_DoctorID = row("DOCTORID")
            m_MedicalDoctor_EducationalAndSkill.m_DoctorCode = row("DoctorCode")
            m_MedicalDoctor_EducationalAndSkill.m_PostGraduate = row("PostGraduate")
            m_MedicalDoctor_EducationalAndSkill.m_PostGraduateDate = row("PostGraduateDate")
            m_MedicalDoctor_EducationalAndSkill.m_MedicalSchoolGraduate = row("MedicalSchoolGraduate")
            m_MedicalDoctor_EducationalAndSkill.m_MedicalGraduateDate = row("MedicalGraduateDate")
            col.Add(m_MedicalDoctor_EducationalAndSkill)
        Next
        Return col
    End Function
    Public Shared Function Filter(ByVal Condition As String) As MedicalDoctor_EducationalAndSkillCollection
        Return BaseFilter(GetRecords("SELECT * FROM MedicalDoctor_EducationalAndSkill  WHERE DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As MedicalDoctor_EducationalAndSkillCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As MedicalDoctor_EducationalAndSkill
        Return Filter("ID = " & ID)(0)
    End Function

    Public Shared Function LoadByCode(ByVal DOCTORID As String) As MedicalDoctor_EducationalAndSkill
        Return Filter("DOCTORID = '" & RefineSQL(DOCTORID) & "'")(0)
    End Function
    Public Shared Function GetmedicalDoctorEducationalAndSkillSql(Optional ByVal DoctorID As String = "") As String
        Return "SELECT PostGraduate,PostGraduateDate,MedicalSchoolGraduate,MedicalGraduateDate FROM MedicalDoctor_EducationalAndSkill Where DLTFLG = 0 Where DOCTORID = '" & DoctorID & "'"
    End Function

End Class
Public Class MedicalDoctor_EducationalAndSkillCollection
    Inherits List(Of MedicalDoctor_EducationalAndSkill)
End Class