Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class MDPrescription

    Private m_MDID As Integer = -1

    Private m_MDCode As String = String.Empty

    Private m_LastName As String = String.Empty

    Private m_FirstName As String = String.Empty

    Private m_MiddleName As String = String.Empty

    Private m_SPCode As String = String.Empty

    Private m_IsDeleted As Boolean = False

    Private m_CreatedBy As String = String.Empty

    Private m_LastModifiedBy As String = String.Empty

    Private GetDataTable As New DataTable
    Public ReadOnly Property MDID As Integer
        Get
            Return m_MDID
        End Get
    End Property

    Public Property MDCode As String
        Get
            Return m_MDCode
        End Get
        Set(value As String)
            m_MDCode = value
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
    Public Property SPCode As String
        Get
            Return m_SPCode
        End Get
        Set(value As String)
            m_SPCode = value
        End Set
    End Property

    Public Property IsDeleted As Boolean
        Get
            Return m_IsDeleted
        End Get
        Set(value As Boolean)
            m_IsDeleted = value
        End Set
    End Property

    Public Property CreatedBy As String
        Get
            Return m_CreatedBy
        End Get
        Set(value As String)
            m_CreatedBy = value
        End Set
    End Property

    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As MDPrescriptionCollection
        Dim col As New MDPrescriptionCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim m_MDPrescription As New MDPrescription
            Dim row As DataRow = Table.Rows(j)
            m_MDPrescription.m_MDID = row("MDID")
            m_MDPrescription.m_MDCode = row("MDCode")
            m_MDPrescription.m_LastName = row("LastName")
            m_MDPrescription.m_FirstName = row("FirstName")
            m_MDPrescription.m_MiddleName = row("MiddleName")
            m_MDPrescription.m_SPCode = row("SPCode")
            m_MDPrescription.m_IsDeleted = row("IsDeleted")
            m_MDPrescription.m_CreatedBy = row("CreatedBy")
            m_MDPrescription.m_LastModifiedBy = row("LastModifiedBy")
            col.Add(m_MDPrescription)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspMDPrescrition", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@MDID", m_MDID)
            cmd.Parameters.AddWithValue("@MDCode", m_MDCode)
            cmd.Parameters.AddWithValue("@LastName", m_LastName)
            cmd.Parameters.AddWithValue("@FirstName", m_FirstName)
            cmd.Parameters.AddWithValue("@MiddleName", m_MiddleName)
            cmd.Parameters.AddWithValue("@SPCode", m_SPCode)
            cmd.Parameters.AddWithValue("@IsDeleted", m_IsDeleted)
            cmd.Parameters.AddWithValue("@CreatedBy", m_CreatedBy)
            cmd.Parameters.AddWithValue("@LastModifiedBy", m_LastModifiedBy)
            m_MDID = cmd.ExecuteScalar
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            SPMSOPCI.ConnectionModule.Disconnect()
        End Try
    End Function
    Public Function Delete() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspMDPrescrition", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "DELETE")
            cmd.Parameters.AddWithValue("@MDID", m_MDID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As MDPrescriptionCollection
        Return BaseFilter(GetRecords("SELECT * FROM MDPrescrition  WHERE IsDeleted = 1 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As MDPrescriptionCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal MDID As Integer) As MDPrescription
        Return Filter("MDID = " & MDID)(0)
    End Function
    Public Shared Function LoadByCode(ByVal MDCode As String) As MDPrescription
        Return Filter("MDCode = '" & RefineSQL(MDCode) & "'")(0)
    End Function
    Public Shared Function CheckofMDPrecriptionAlreadyExist(ByVal MDCode As String, ByVal MDID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM MDPrescrition Where IsDeleted = 0 And MDCode = '" & RefineSQL(MDCode) & "' And MDID <> " & MDID) = "A"
    End Function
    Public Shared Function GetMDPrescriptionSql() As String
        Return "SELECT A.MDID,A.MDCode AS [Doctor Code],RTRIM(LTRIM(A.LastName + ' ' + A.FirstName + CASE WHEN A.MiddleName IS NOT NULL AND A.MiddleName <> '' THEN ' ' + A.MiddleName ELSE '' END)) AS [Doctor Name],B.SpecialtyName [Specilization] FROM [dbo].[MDPrescrition] A LEFT JOIN [Specialization] B ON B.SpecialtyCode = A.SPCode WHERE A.IsDeleted = 1"
    End Function
    Public Shared Function GenerateNewMDCode() As String
        Dim newCode As String = ""
        Dim nextNumber As Integer = 1


        Try
            Dim sql As String =
            "SELECT TOP 1 MDCode " &
            "FROM MDPrescrition WITH (UPDLOCK, HOLDLOCK) " &
            "WHERE IsDeleted = 1 " &
            "ORDER BY MDCode DESC"

            Dim dt As DataTable = GetRecords(sql)

            If dt.Rows.Count > 0 Then
                ' Get latest code and increment
                Dim currentCode As String = dt.Rows(0)("MDCode").ToString().Trim()
                Dim numericPart As String = currentCode.Substring(3)
                nextNumber = CInt(numericPart) + 1
            End If

            ' Build next formatted code
            newCode = "MD-" & nextNumber.ToString("D10")

            ' Ensure code is unique (optional)
            Do While CheckofMDPrecriptionAlreadyExist(newCode, 0)
                nextNumber += 1
                newCode = "MD-" & nextNumber.ToString("D10")
            Loop

        Catch ex As Exception
            MessageBox.Show("Error generating MD Code: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            newCode = "MD-" & nextNumber.ToString("D10") ' fallback
        End Try

        Return newCode
    End Function

End Class
Public Class MDPrescriptionCollection
    Inherits List(Of MDPrescription)
End Class
