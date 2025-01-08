Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class MedicalDoctor_SeniorcitizensCollection
    Dim m_ID As Integer = -1

    Dim m_DoctorID As Integer = -1

    Dim m_DoctorNumber As String = String.Empty

    Dim m_BranchCode As String = String.Empty

    Dim m_BranchName As String = String.Empty

    Dim m_AddressLine1 As String = String.Empty

    Dim m_AddressLine2 As String = String.Empty

    Dim m_IsActive As Boolean = True

    Dim m_DLTFLG As Boolean = False

    Dim m_Createby As String = String.Empty

    Public ReadOnly Property ID As Integer
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

    Public Property DoctorNumber As String
        Get
            Return m_DoctorNumber
        End Get
        Set(value As String)
            m_DoctorNumber = value
        End Set
    End Property
    Public Property BranchCode As String
        Get
            Return m_BranchCode
        End Get
        Set(value As String)
            m_BranchCode = value
        End Set
    End Property

    Public Property BranchName As String
        Get
            Return m_BranchName
        End Get
        Set(value As String)
            m_BranchName = value
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
            Dim cmd As New SqlCommand("uspMedicalDoctor_SeniorcitizensCollection", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@DoctorID", m_DoctorID)
            cmd.Parameters.AddWithValue("@DoctorNumber", m_DoctorNumber)
            cmd.Parameters.AddWithValue("@BranchCode", m_BranchCode)
            cmd.Parameters.AddWithValue("@BranchName", m_BranchName)
            cmd.Parameters.AddWithValue("@AddressLine1", m_AddressLine1)
            cmd.Parameters.AddWithValue("@AddressLine2", m_AddressLine2)
            cmd.Parameters.AddWithValue("@IsActive", m_IsActive)
            cmd.Parameters.AddWithValue("@DLTFLG", m_DLTFLG)
            cmd.Parameters.AddWithValue("@Createby", m_Createby)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Function Delete(ByVal BranchCode As String) As Boolean
        Try
            If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspMedicalDoctor_SeniorcitizensCollection", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Delete")
            cmd.Parameters.AddWithValue("@BranchCode", BranchCode)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function DeleteAll(ByVal DoctorCode As String) As Boolean
        Try
            If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspMedicalDoctor_SeniorcitizensCollection", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "DELETEALL")
            cmd.Parameters.AddWithValue("@DoctorNumber", DoctorCode)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As MedicalDoctor_SeniorcitizensCollection_Collection
        Dim col As New MedicalDoctor_SeniorcitizensCollection_Collection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_MedicalDoctor As New MedicalDoctor_SeniorcitizensCollection
            Dim row As DataRow = table.Rows(j)
            m_MedicalDoctor.m_ID = row("ID")
            m_MedicalDoctor.m_DoctorID = row("DoctorID")
            m_MedicalDoctor.m_DoctorNumber = row("DoctorNumber")
            m_MedicalDoctor.m_BranchCode = row("BranchCode")
            m_MedicalDoctor.m_BranchName = row("BranchName")
            m_MedicalDoctor.m_AddressLine1 = row("AddressLine1")
            m_MedicalDoctor.m_AddressLine2 = row("AddressLine2")
            m_MedicalDoctor.m_IsActive = row("IsActive")
            m_MedicalDoctor.DLTFLG = row("DLTFLG")
            m_MedicalDoctor.Createby = row("Createby")
            col.Add(m_MedicalDoctor)
        Next
        Return col
    End Function

    Public Shared Function CheckofMedicalDoctor_SeniorcitizensCollectionAlreadyExist(ByVal DoctorCode As String, ByVal BranchCode As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM MedicalDoctor_SeniorcitizensCollection WHERE DLTFLG = 0 AND  DoctorNumber = '" & DoctorCode & "' AND BranchCode = " & BranchCode) = "A"
    End Function
    Public Shared Function GetOpenBranchCodeSql(ByVal DoctorCode As String) As String
        Return "Select BranchCode [Branch Code],BranchName [Branch Name],AddressLine1 [Branch Address 1],AddressLine2 [Branch Address 2] From MedicalDoctor_SeniorcitizensCollection Where DoctorNumber = '" & DoctorCode & "'"
    End Function
End Class
Public Class MedicalDoctor_SeniorcitizensCollection_Collection
    Inherits List(Of MedicalDoctor_SeniorcitizensCollection)
End Class
