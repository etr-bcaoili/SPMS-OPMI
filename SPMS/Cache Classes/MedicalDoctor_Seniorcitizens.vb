Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class MedicalDoctor_Seniorcitizens

    Dim m_DoctorID As Integer = -1

    Dim m_DoctorNumber As String = String.Empty

    Dim m_LastName As String = String.Empty

    Dim m_Suffix As String = String.Empty

    Dim m_FirstName As String = String.Empty

    Dim m_MiddleName As String = String.Empty

    Dim m_AddressLine1 As String = String.Empty

    Dim m_AddressLine2 As String = String.Empty

    Dim m_PTRNO As String = String.Empty

    Dim m_IsActive As Boolean = True

    Dim m_DLTFLG As Boolean = False

    Dim m_Createby As String = String.Empty

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
    Public Property PTRNO As String
        Get
            Return m_PTRNO
        End Get
        Set(value As String)
            m_PTRNO = value
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

    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspMedicalDoctor_Seniorcitizens", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@DoctorID", m_DoctorID)
            cmd.Parameters.AddWithValue("@DoctorNumber", m_DoctorNumber)
            cmd.Parameters.AddWithValue("@LastName", m_LastName)
            cmd.Parameters.AddWithValue("@Suffix", m_Suffix)
            cmd.Parameters.AddWithValue("@FirstName", m_FirstName)
            cmd.Parameters.AddWithValue("@MiddleName", m_MiddleName)
            cmd.Parameters.AddWithValue("@PTRNO", m_PTRNO)
            cmd.Parameters.AddWithValue("@AddressLine1", m_AddressLine1)
            cmd.Parameters.AddWithValue("@AddressLine2", m_AddressLine2)
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
    Public Function Delete() As Boolean
        Try
            If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspMedicalDoctor_Seniorcitizens", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Delete")
            cmd.Parameters.AddWithValue("@DoctorID", m_DoctorID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As MedicalDoctor_Seniorcitizens_Collection
        Dim col As New MedicalDoctor_Seniorcitizens_Collection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_MedicalDoctor As New MedicalDoctor_Seniorcitizens
            Dim row As DataRow = table.Rows(j)
            m_MedicalDoctor.m_DoctorID = row("DoctorID")
            m_MedicalDoctor.m_DoctorNumber = row("DoctorNumber")
            m_MedicalDoctor.m_LastName = row("LastName")
            m_MedicalDoctor.m_Suffix = row("Suffix")
            m_MedicalDoctor.m_FirstName = row("FirstName")
            m_MedicalDoctor.m_MiddleName = row("MiddleName")
            m_MedicalDoctor.m_PTRNO = row("PTRNO")
            m_MedicalDoctor.m_AddressLine1 = row("AddressLine1")
            m_MedicalDoctor.m_AddressLine2 = row("AddressLine2")
            m_MedicalDoctor.m_IsActive = row("IsActive")
            m_MedicalDoctor.DLTFLG = row("DLTFLG")
            m_MedicalDoctor.Createby = row("Createby")
            col.Add(m_MedicalDoctor)
        Next
        Return col
    End Function
    Public Shared Function Filter(ByVal Condition As String) As MedicalDoctor_Seniorcitizens_Collection
        Return BaseFilter(GetRecords("SELECT * FROM MedicalDoctor_Seniorcitizens  WHERE DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As MedicalDoctor_Seniorcitizens_Collection
        Return Filter("")
    End Function

    Public Overloads Shared Function Load(ByVal DoctorID As Integer) As MedicalDoctor_Seniorcitizens
        Return Filter("DoctorID = " & DoctorID)(0)
    End Function

    Public Shared Function LoadByCode(ByVal DoctorNumber As String) As MedicalDoctor_Seniorcitizens
        Return Filter("DoctorNumber = '" & RefineSQL(DoctorNumber) & "'")(0)
    End Function
    Public Shared Function CheckofMedicalDoctor_SeniorcitizensAlreadyExist(ByVal Code As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM MedicalDoctor_Seniorcitizens WHERE DLTFLG = 0 AND  DoctorNumber = '" & RefineSQL(Code) & "' AND DoctorID <> " & ID) = "A"
    End Function
    Public Shared Function GetMedicalDoctor_SeniorcitizensSql(Optional ByVal DoctorNumber As String = "") As String
        Return "SELECT DoctorID, DoctorNumber [Doctor Code], REPLACE(CONCAT(FirstName+' ',MiddleName+' ',LastName+' '),'  ',' ') [MD Name] FROM MedicalDoctor_Seniorcitizens Where DLTFLG = 0 "
    End Function
End Class
Public Class MedicalDoctor_Seniorcitizens_Collection
    Inherits List(Of MedicalDoctor_Seniorcitizens)
End Class