Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class MedicalDoctor
    Dim m_DoctorID As Integer = -1

    Dim m_DoctorNumber As String = String.Empty

    Dim m_LastName As String = String.Empty

    Dim m_Suffix As String = String.Empty

    Dim m_FirstName As String = String.Empty

    Dim m_MiddleName As String = String.Empty

    Dim m_DoctorType As Integer = -1

    Dim m_MidLevel As Boolean = False

    Dim m_Specialist As Boolean = False

    Dim m_Individual As Boolean = False

    Dim m_AddressLine1 As String = String.Empty

    Dim m_AddressLine2 As String = String.Empty

    Dim m_ZipCode As String = String.Empty

    Dim m_City As String = String.Empty

    Dim m_HomePhone As String = String.Empty

    Dim m_EmailAddress As String = String.Empty

    Dim m_IsActive As Boolean = True

    Dim m_DLTFLG As Boolean = False

    Dim m_Createby As String = String.Empty

    Dim m_DoctorIDS As Integer = 0

    Dim m_SpecializationCode As String = String.Empty

    Dim m_SpecializationName As String = String.Empty



    Public Property DoctorIDS As Integer
        Get
            Return m_DoctorIDS
        End Get
        Set(value As Integer)
            m_DoctorIDS = value
        End Set
    End Property


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

    Public Property MiddleName As String
        Get
            Return m_MiddleName
        End Get
        Set(value As String)
            m_MiddleName = value
        End Set
    End Property
    Public Property DoctorType As String
        Get
            Return m_DoctorType
        End Get
        Set(value As String)
            m_DoctorType = value
        End Set
    End Property

    Public Property MidLevel As Boolean
        Get
            Return m_MidLevel
        End Get
        Set(value As Boolean)
            m_MidLevel = value
        End Set
    End Property

    Public Property Specialist As Boolean
        Get
            Return m_Specialist
        End Get
        Set(value As Boolean)
            m_Specialist = value
        End Set
    End Property
    Public Property Individual As Boolean
        Get
            Return m_Individual
        End Get
        Set(value As Boolean)
            m_Individual = value
        End Set
    End Property
    Public Property AddressLine1 As String
        Get
            Return m_AddressLine1
        End Get
        Set(value As String)
            m_AddressLine1 = value
        End Set
    End Property

    Public Property AddressLine2 As String
        Get
            Return m_AddressLine2
        End Get
        Set(value As String)
            m_AddressLine2 = value
        End Set
    End Property

    Public Property ZipCode As String
        Get
            Return m_ZipCode
        End Get
        Set(value As String)
            m_ZipCode = value
        End Set
    End Property

    Public Property City As String
        Get
            Return m_City
        End Get
        Set(value As String)
            m_City = value
        End Set
    End Property

    Public Property HomePhone As String
        Get
            Return m_HomePhone
        End Get
        Set(value As String)
            m_HomePhone = value
        End Set
    End Property

    Public Property EmailAddress As String
        Get
            Return m_EmailAddress
        End Get
        Set(value As String)
            m_EmailAddress = value
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
    Public Property SpecializationCode As String
        Get
            Return m_SpecializationCode
        End Get
        Set(value As String)
            m_SpecializationCode = value
        End Set
    End Property
    Public Property SpecializationName As String
        Get
            Return m_SpecializationName
        End Get
        Set(value As String)
            m_SpecializationName = value
        End Set
    End Property
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspMedicalDoctor", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@DoctorID", m_DoctorID)
            cmd.Parameters.AddWithValue("@DoctorNumber", m_DoctorNumber)
            cmd.Parameters.AddWithValue("@LastName", m_LastName)
            cmd.Parameters.AddWithValue("@Suffix", m_Suffix)
            cmd.Parameters.AddWithValue("@FirstName", m_FirstName)
            cmd.Parameters.AddWithValue("@MiddleName", m_MiddleName)
            cmd.Parameters.AddWithValue("@DoctorType", m_DoctorType)
            cmd.Parameters.AddWithValue("@MidLevel", m_MidLevel)
            cmd.Parameters.AddWithValue("@Specialist", m_Specialist)
            cmd.Parameters.AddWithValue("", m_SpecializationCode)
            cmd.Parameters.AddWithValue("@Individual", m_Individual)
            cmd.Parameters.AddWithValue("@AddressLine1", m_AddressLine1)
            cmd.Parameters.AddWithValue("@AddressLine2", m_AddressLine2)
            cmd.Parameters.AddWithValue("@ZipCode", m_ZipCode)
            cmd.Parameters.AddWithValue("@City", m_City)
            cmd.Parameters.AddWithValue("@HomePhone", m_HomePhone)
            cmd.Parameters.AddWithValue("@EmailAddress", m_EmailAddress)
            cmd.Parameters.AddWithValue("@IsActive", m_IsActive)
            cmd.Parameters.AddWithValue("@DLTFLG", m_DLTFLG)
            cmd.Parameters.AddWithValue("@Createby", m_Createby)
            m_DoctorID = cmd.ExecuteScalar()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Function Delete(ByVal DoctorID As Integer) As Boolean
        Try
            If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspMedicalDoctor", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Delete")
            cmd.Parameters.AddWithValue("@DoctorID", DoctorID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As MedicalDoctorCollection
        Dim col As New MedicalDoctorCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_MedicalDoctor As New MedicalDoctor
            Dim row As DataRow = table.Rows(j)
            m_MedicalDoctor.m_DoctorID = row("DoctorID")
            m_MedicalDoctor.m_DoctorNumber = row("DoctorNumber")
            m_MedicalDoctor.m_LastName = row("LastName")
            m_MedicalDoctor.m_Suffix = row("Suffix")
            m_MedicalDoctor.m_FirstName = row("FirstName")
            m_MedicalDoctor.m_MiddleName = row("MiddleName")
            m_MedicalDoctor.m_DoctorType = row("DoctorType")
            m_MedicalDoctor.m_MidLevel = row("MidLevel")
            m_MedicalDoctor.m_Specialist = row("Specialist")
            m_MedicalDoctor.m_Individual = row("Individual")
            m_MedicalDoctor.m_AddressLine1 = row("AddressLine1")
            m_MedicalDoctor.m_AddressLine2 = row("AddressLine2")
            m_MedicalDoctor.m_ZipCode = row("ZipCode")
            m_MedicalDoctor.m_City = row("City")
            m_MedicalDoctor.m_HomePhone = row("HomePhone")
            m_MedicalDoctor.m_EmailAddress = row("EmailAddress")
            m_MedicalDoctor.m_IsActive = row("IsActive")
            m_MedicalDoctor.DLTFLG = row("DLTFLG")
            m_MedicalDoctor.Createby = row("Createby")
            col.Add(m_MedicalDoctor)
        Next
        Return col
    End Function
    Public Shared Function Filter(ByVal Condition As String) As MedicalDoctorCollection
        Return BaseFilter(GetRecords("SELECT * FROM MedicalDoctor  WHERE DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function

    Public Overloads Shared Function Load() As MedicalDoctorCollection
        Return Filter("")
    End Function

    Public Overloads Shared Function Load(ByVal DoctorID As Integer) As MedicalDoctor
        Return Filter("DoctorID = " & DoctorID)(0)
    End Function
    Public Shared Function LoadByCode(ByVal DoctorNumber As String) As MedicalDoctor
        Return Filter("DoctorNumber = '" & RefineSQL(DoctorNumber) & "'")(0)
    End Function
    Public Shared Function CheckofMedicalDoctorAlreadyExist(ByVal DoctorNumber As String, ByVal DoctorID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM MedicalDoctor WHERE DLTFLG = 0 AND  DoctorNumber = '" & RefineSQL(DoctorNumber) & "' AND DoctorID <> " & DoctorID) = "A"
    End Function
    Public Shared Function GetMedicalDoctorsSql(Optional ByVal DoctorCode As String = "") As String
        Return "SELECT DoctorID,DoctorNumber [Doctor Code] ,RTRIM(LTRIM(CONCAT(COALESCE(FirstName + ' ', ' '),COALESCE(MiddleName + '. ', ' '), COALESCE(Lastname +', ', ' '), COALESCE(Suffix + ' ', ' ')) )) AS [Doctor Name] FROM MedicalDoctor"
    End Function

End Class
Public Class MedicalDoctorCollection
    Inherits List(Of MedicalDoctor)
End Class
