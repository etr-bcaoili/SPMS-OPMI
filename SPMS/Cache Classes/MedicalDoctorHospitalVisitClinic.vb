Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class MedicalDoctorHospitalVisitClinic
    Dim m_ID As Integer = -1

    Dim m_DoctorID As Integer = -1

    Dim m_ClinicName As String = String.Empty

    Dim m_ClinicAddress As String = String.Empty

    Dim m_Createby As String = String.Empty

    Dim m_DoctorIDS As Integer = 0

    Public Property DoctorIDS As Integer
        Get
            Return m_DoctorIDS
        End Get
        Set(value As Integer)
            m_DoctorIDS = value
        End Set
    End Property

    Public ReadOnly Property ID() As Integer
        Get
            Return m_ID
        End Get
    End Property
    Public Property DoctorID As Integer
        Get
            Return m_DoctorID
        End Get
        Set(value As Integer)
            m_DoctorID = value
        End Set
    End Property
    Public Property ClinicName As String
        Get
            Return m_ClinicName
        End Get
        Set(value As String)
            m_ClinicName = value
        End Set
    End Property

    Public Property ClinicAddress As String
        Get
            Return m_ClinicAddress
        End Get
        Set(value As String)
            m_ClinicAddress = value
        End Set
    End Property

    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspMedicalDoctorHospitalVisitClinic", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.Parameters.AddWithValue("@DoctorID", m_DoctorID)
            cmd.Parameters.AddWithValue("@ClinicName", m_ClinicName)
            cmd.Parameters.AddWithValue("@ClinicAddress", m_ClinicAddress)
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
            Dim cmd As New SqlCommand("uspMedicalDoctorHospitalVisitClinic", SPMSOPCI.ConnectionModule.SPMSConn2)
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
    Public Shared Function GetMedicalDoctorHospitalVisitClinicSql(ByVal DoctorID As String) As String
        Return "Select * From MedicalDoctorHospitalVisitClinic Where [DoctorID] = '" & DoctorID & "'"
    End Function
    Public Shared Function DeleteAfterEditDoctor(ByVal DoctorID As String) As String
        ExecuteCommand("Delete From MedicalDoctorHospitalVisitClinic Where [DoctorID] = '" & DoctorID & "'")
    End Function
End Class
