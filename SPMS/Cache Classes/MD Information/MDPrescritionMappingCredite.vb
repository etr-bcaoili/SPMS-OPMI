Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class MDPrescritionMappingCredite

    Private m_ID As Integer = -1

    Private m_MDID As Integer = -1

    Private m_DMCode As String = String.Empty

    Private m_PMRCode As String = String.Empty

    Private m_EmployeeCode As String = String.Empty

    Private m_CreatedBy As String = String.Empty

    Private m_LastModifiedBy As String = String.Empty

    Public ReadOnly Property ID As Integer
        Get
            Return m_ID
        End Get
    End Property
    Public Property MDID As String
        Get
            Return m_MDID
        End Get
        Set(value As String)
            m_MDID = value
        End Set
    End Property
    Public Property DMCode As String
        Get
            Return m_DMCode
        End Get
        Set(value As String)
            m_DMCode = value
        End Set
    End Property
    Public Property PMRCode As String
        Get
            Return m_PMRCode
        End Get
        Set(value As String)
            m_PMRCode = value
        End Set
    End Property
    Public Property EmployeeCode As String
        Get
            Return m_EmployeeCode
        End Get
        Set(value As String)
            m_EmployeeCode = value
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
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As MDPrescritionMappingCrediteCollection
        Dim col As New MDPrescritionMappingCrediteCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim m_MDPrescritionMappingCredite As New MDPrescritionMappingCredite
            Dim row As DataRow = Table.Rows(j)
            m_MDPrescritionMappingCredite.m_ID = row("ID")
            m_MDPrescritionMappingCredite.m_MDID = row("MDID")
            m_MDPrescritionMappingCredite.m_DMCode = row("DMCode")
            m_MDPrescritionMappingCredite.m_PMRCode = row("PMRCode")
            m_MDPrescritionMappingCredite.m_EmployeeCode = row("EmployeeCode")
            m_MDPrescritionMappingCredite.m_CreatedBy = row("CreatedBy")
            m_MDPrescritionMappingCredite.m_LastModifiedBy = row("LastModifiedBy")
            col.Add(m_MDPrescritionMappingCredite)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspMDPrescritionMappingCredite", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.Parameters.AddWithValue("@MDID", m_MDID)
            cmd.Parameters.AddWithValue("@DMCode", m_DMCode)
            cmd.Parameters.AddWithValue("@PMRCode", m_PMRCode)
            cmd.Parameters.AddWithValue("@EmployeeCode", m_EmployeeCode)
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
            Dim cmd As New SqlCommand("uspMDPrescritionMappingCredite", SPMSOPCI.ConnectionModule.SPMSConn2)
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
    Public Shared Function GetMDPrescritionMappingCredite() As String
        Return "Select EmployeeID,EmployeeCode,RTRIM(LTRIM(LastName + ' ' + FirstName + CASE WHEN MiddleName IS NOT NULL AND MiddleName <> '' THEN ' ' + MiddleName ELSE '' END)) AS [Employee Salesman] from [EmployeeSalesman]"
    End Function
    Public Shared Function GetMDPrescritionMappingCredites(ByVal EmployeeID As Integer) As String
        Return "Select DISTINCT S.STDISTRCTCD,D.STSLSMGRNAME,A.EmployeeCode,S.STSLSMNCD,RTRIM(LTRIM(A.LastName + ' ' + A.FirstName + CASE WHEN A.MiddleName IS NOT NULL AND A.MiddleName <> '' THEN ' ' + A.MiddleName ELSE '' END)) [PMR Name],B.TerritoryCode,S.STACOVNAME From [EmployeeSalesman] A INNER JOIN [EmployeeSalesmanCollection] B ON A.EmployeeID = B.EmployeeID INNER JOIN SalesMatrix S ON B.TerritoryCode = S.STSLSMNCD INNER JOIN [STSalesManager] D ON S.STDISTRCTCD = D.STSLSMGRCD WHERE A.EmployeeID = '" & EmployeeID & "'"
    End Function
    Public Shared Function GetMDPrescritionMappingCreditebyMDID(ByVal MDID As Integer) As String
        Return "Select DISTINCT S.STDISTRCTCD,D.STSLSMGRNAME,A.EmployeeCode,S.STSLSMNCD,RTRIM(LTRIM(A.LastName + ' ' + A.FirstName + CASE WHEN A.MiddleName IS NOT NULL AND A.MiddleName <> '' THEN ' ' + A.MiddleName ELSE '' END)) [PMR Name],B.TerritoryCode,S.STACOVNAME From [EmployeeSalesman] A INNER JOIN [EmployeeSalesmanCollection] B ON A.EmployeeID = B.EmployeeID INNER JOIN SalesMatrix S ON B.TerritoryCode = S.STSLSMNCD INNER JOIN [STSalesManager] D ON S.STDISTRCTCD = D.STSLSMGRCD INNER JOIN MDPrescritionMappingCredite MD ON S.STDISTRCTCD = DMCode AND S.STSLSMNCD = MD.PMRCode  WHERE MD.MDID = '" & MDID & "'"
    End Function

End Class
Public Class MDPrescritionMappingCrediteCollection
    Inherits List(Of MDPrescritionMappingCredite)
End Class