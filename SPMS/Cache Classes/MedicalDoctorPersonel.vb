Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class MedicalDoctorPersonel

    Dim m_DoctorID As Integer = -1

    Dim m_DoctorNumber As String = String.Empty

    Dim m_LastName As String = String.Empty

    Dim m_Suffix As String = String.Empty

    Dim m_FirstName As String = String.Empty

    Dim m_Middle As String = String.Empty

    Dim m_Address1 As String = String.Empty

    Dim m_Address2 As String = String.Empty

    Dim m_PTRNO As String = String.Empty

    Dim m_Enrolled As Integer = -1

    Dim m_Gender As Integer = -1

    Dim m_BirthDate As Date = "1/1/1900"

    Dim m_CivilStatus As String = String.Empty

    Dim m_NameOfSpouse As String = String.Empty

    Dim m_HabbiesAndInterest As String = String.Empty

    Dim m_AnniversaryDate As Date = "1/1/1900"

    Dim m_DLTFLG As Boolean = False

    Dim m_IsActive As Boolean = True


    Public ReadOnly Property DoctorID() As Integer
        Get
            Return m_DoctorID
        End Get
    End Property

    Public Property DoctorNumber As String
        Get
            Return m_DoctorNumber
        End Get
        Set(value As String)
            m_DoctorNumber = value
        End Set
    End Property

    Public Property LastName As String
        Get
            Return m_LastName
        End Get
        Set(value As String)
            m_LastName = value
        End Set
    End Property

    Public Property Suffix As String
        Get
            Return m_Suffix
        End Get
        Set(value As String)
            m_Suffix = value
        End Set
    End Property

    Public Property FirstName As String
        Get
            Return m_FirstName
        End Get
        Set(value As String)
            m_FirstName = value
        End Set
    End Property

    Public Property Middle As String
        Get
            Return m_Middle
        End Get
        Set(value As String)
            m_Middle = value
        End Set
    End Property

    Public Property Address1 As String
        Get
            Return m_Address1
        End Get
        Set(value As String)
            m_Address1 = value
        End Set
    End Property

    Public Property Address2 As String
        Get
            Return m_Address2
        End Get
        Set(value As String)
            m_Address2 = value
        End Set
    End Property

    Public Property PTRNO As String
        Get
            Return m_PTRNO
        End Get
        Set(value As String)
            m_PTRNO = value
        End Set
    End Property
    Public Property Enrolled As Integer
        Get
            Return m_Enrolled
        End Get
        Set(value As Integer)
            m_Enrolled = value
        End Set
    End Property

    Public Property Gender As Integer
        Get
            Return m_Gender
        End Get
        Set(value As Integer)
            m_Gender = value
        End Set
    End Property

    Public Property BirthDate As Date
        Get
            Return m_BirthDate
        End Get
        Set(value As Date)
            m_BirthDate = value
        End Set
    End Property

    Public Property CivilStatus As String
        Get
            Return m_CivilStatus
        End Get
        Set(value As String)
            m_CivilStatus = value
        End Set
    End Property

    Public Property NameOfSpouse As String
        Get
            Return m_NameOfSpouse
        End Get
        Set(value As String)
            m_NameOfSpouse = value
        End Set
    End Property

    Public Property HabbiesAndInterest As String
        Get
            Return m_HabbiesAndInterest
        End Get
        Set(value As String)
            m_HabbiesAndInterest = value
        End Set
    End Property

    Public Property AnniversaryDate As Date
        Get
            Return m_AnniversaryDate
        End Get
        Set(value As Date)
            m_AnniversaryDate = value
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
    Public Property IsActive As Boolean
        Get
            Return m_IsActive
        End Get
        Set(value As Boolean)
            m_IsActive = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As MedicalDoctorPersonelCollection
        Dim col As New MedicalDoctorPersonelCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_MedicalDoctor As New MedicalDoctorPersonel
            Dim row As DataRow = table.Rows(j)
            m_MedicalDoctor.m_DoctorID = row("DoctorID")
            m_MedicalDoctor.m_DoctorNumber = row("DoctorCode")
            m_MedicalDoctor.m_LastName = row("LastName")
            m_MedicalDoctor.m_Suffix = row("Suffix")
            m_MedicalDoctor.m_FirstName = row("FirstName")
            m_MedicalDoctor.m_Middle = row("Middle")
            m_MedicalDoctor.m_PTRNO = row("PTRNO")
            m_MedicalDoctor.m_Enrolled = row("Enrolled")
            m_MedicalDoctor.m_Address1 = row("Address1")
            m_MedicalDoctor.m_Address2 = row("Address2")
            m_MedicalDoctor.m_Gender = row("Gender")
            m_MedicalDoctor.m_BirthDate = row("BirthDate")
            m_MedicalDoctor.m_CivilStatus = row("CivilStatus")
            m_MedicalDoctor.m_NameOfSpouse = row("NameOfSpouse")
            m_MedicalDoctor.m_HabbiesAndInterest = row("HabbiesAndInterest")
            m_MedicalDoctor.m_AnniversaryDate = row("AnniversaryDate")
            m_MedicalDoctor.DLTFLG = row("DLTFLG")
            m_MedicalDoctor.IsActive = row("IsActive")
            col.Add(m_MedicalDoctor)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspMedicalDoctor", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@DOCTORID", m_DoctorID)
            cmd.Parameters.AddWithValue("@DoctorCode", m_DoctorNumber)
            cmd.Parameters.AddWithValue("@LastName", m_LastName)
            cmd.Parameters.AddWithValue("@FirstName", m_FirstName)
            cmd.Parameters.AddWithValue("@Middle", m_Middle)
            cmd.Parameters.AddWithValue("@Suffix", m_Suffix)
            cmd.Parameters.AddWithValue("@Gender", m_Gender)
            cmd.Parameters.AddWithValue("@PTRNo", m_PTRNO)
            cmd.Parameters.AddWithValue("@Enrolled", m_Enrolled)
            cmd.Parameters.AddWithValue("@BirthDate", m_BirthDate)
            cmd.Parameters.AddWithValue("@CivilStatus", m_CivilStatus)
            cmd.Parameters.AddWithValue("@Address1", m_Address1)
            cmd.Parameters.AddWithValue("@Address2", m_Address2)
            cmd.Parameters.AddWithValue("@NameOfSpouse", m_NameOfSpouse)
            cmd.Parameters.AddWithValue("@HabbiesAndInterest", m_HabbiesAndInterest)
            cmd.Parameters.AddWithValue("@AnniversaryDate", m_AnniversaryDate)
            cmd.Parameters.AddWithValue("@DLTFLG", m_DLTFLG)
            cmd.Parameters.AddWithValue("@IsActive", m_IsActive)
            m_DoctorID = cmd.ExecuteScalar()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As MedicalDoctorPersonelCollection
        Return BaseFilter(GetRecords("SELECT * FROM MedicalDoctor  WHERE DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As MedicalDoctorPersonelCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal DoctorID As Integer) As MedicalDoctorPersonel
        Return Filter("DoctorID = " & DoctorID)(0)
    End Function
    Public Shared Function LoadByCode(ByVal DoctorCode As String) As MedicalDoctorPersonel
        Return Filter("DoctorCode = '" & RefineSQL(DoctorCode) & "'")(0)
    End Function
    Public Shared Function CheckofMedicalDoctorPersonelAlreadyExist(ByVal Code As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM MedicalDoctor WHERE DLTFLG = 0 AND  DoctorCode = '" & RefineSQL(Code) & "' AND DoctorID <> " & ID) = "A"
    End Function
    Public Shared Function GetMedicalDoctorPersonelSql(Optional ByVal DoctorCode As String = "") As String
        Return "SELECT DoctorID, DoctorCode [Doctor Code], REPLACE(CONCAT(FirstName+' ',Middle+' ',LastName+' '),'  ',' ') [MD Name] FROM MedicalDoctor Where DLTFLG = 0 "
    End Function

End Class
Public Class MedicalDoctorPersonelCollection
    Inherits List(Of MedicalDoctorPersonel)
End Class
