Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class DistrictAssignment
    Private m_DistrictID As Integer = -1

    Private m_DLTFLG As Boolean = 0

    Private m_RegionCode As String = String.Empty

    Private m_DistrictCode As String = String.Empty

    Private m_DistrictName As String = String.Empty

    Private m_DMDistrictCode As String = String.Empty

    Private m_EffectivityStartDate As Date = "1/1/1990"

    Private m_EffectivityEndDate As Date = "1/1/1990"

    Private m_DistrictGroup As String = String.Empty

    Public ReadOnly Property DistrictID As Integer
        Get
            Return m_DistrictID
        End Get
    End Property
    Public Property RegionCodde As String
        Get
            Return m_RegionCode
        End Get
        Set(value As String)
            m_RegionCode = value
        End Set
    End Property
    Public Property DistrictCode As String
        Get
            Return m_DistrictCode
        End Get
        Set(value As String)
            m_DistrictCode = value
        End Set
    End Property
    Public Property DistrictName As String
        Get
            Return m_DistrictName
        End Get
        Set(value As String)
            m_DistrictName = value
        End Set
    End Property
    Public Property DMDistrictCode As String
        Get
            Return m_DMDistrictCode
        End Get
        Set(value As String)
            m_DMDistrictCode = value
        End Set
    End Property
    Public Property EffectivityStartDate As Date
        Get
            Return m_EffectivityStartDate
        End Get
        Set(value As Date)
            m_EffectivityStartDate = value
        End Set
    End Property
    Public Property EffectivityEndDate As Date
        Get
            Return m_EffectivityEndDate
        End Get
        Set(value As Date)
            m_EffectivityEndDate = value
        End Set
    End Property
    Public Property DistrictGroup As String
        Get
            Return m_DistrictGroup
        End Get
        Set(value As String)
            m_DistrictGroup = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As DistrictAssignmentCollection
        Dim col As New DistrictAssignmentCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _DistrictAssignment As New DistrictAssignment
            Dim row As DataRow = Table.Rows(j)
            _DistrictAssignment.m_DistrictID = row("STDistrictID")
            _DistrictAssignment.m_RegionCode = row("STREGCD")
            _DistrictAssignment.m_DistrictCode = row("STDISTRCTCD")
            _DistrictAssignment.m_DistrictName = row("STDISTRCTNAME")
            _DistrictAssignment.m_DLTFLG = row("DLTFLG")
            _DistrictAssignment.m_DMDistrictCode = row("STSLSMGRCD")
            _DistrictAssignment.EffectivityStartDate = row("EFFECTIVITYSTARTDATE")
            _DistrictAssignment.EffectivityEndDate = row("EFFECTIVITYENDDATE")
            _DistrictAssignment.DistrictGroup = row("DistrictGroup")
            col.Add(_DistrictAssignment)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspSTDistrict", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "SAVE")
            cmd.Parameters.AddWithValue("@STDistrictID", m_DistrictID)
            cmd.Parameters.AddWithValue("@DLTFLG", m_DLTFLG)
            cmd.Parameters.AddWithValue("@STREGCD", m_RegionCode)
            cmd.Parameters.AddWithValue("@STDISTRCTCD", m_DistrictCode)
            cmd.Parameters.AddWithValue("@STDISTRCTNAME", m_DistrictName)
            cmd.Parameters.AddWithValue("@STSLSMGRCD", m_DMDistrictCode)
            cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", m_EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", m_EffectivityEndDate)
            cmd.Parameters.AddWithValue("@DistrictGroup", m_DistrictGroup)
            m_DistrictID = cmd.ExecuteScalar
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Function Delete() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspSTDistrict", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "Delete")
            cmd.Parameters.AddWithValue("@STDistrictID", m_DistrictID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As DistrictAssignmentCollection
        Return BaseFilter(GetRecords("Select * From STDISTRICT Where DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As DistrictAssignmentCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal STDistrictID As Integer) As DistrictAssignment
        Return Filter("STDistrictID = " & STDistrictID)(0)
    End Function
    Public Overloads Shared Function LoadByCode(ByVal STDISTRCTCD As String) As DistrictAssignment
        Return Filter("STDISTRCTCD = '" & RefineSQL(STDISTRCTCD) & "'")(0)
    End Function
    Public Shared Function CheckOfDistrictAssignAlreadyExist(ByVal STDISTRCTCD As String, ByVal STDistrictID As Integer) As Boolean
        Return ExecuteCommand("Select 'A' From STDISTRICT Where DLTFLG = 0 And STDISTRCTCD = '" & RefineSQL(STDISTRCTCD) & "' And STDistrictID <> " & STDistrictID) = "A"
    End Function
    Public Shared Function GetDMDistrictSql(Optional ByVal ItemDivisionCode As String = "") As String
        Return "Select STDISTRCTCD,STDISTRCTCD [District Code],STDISTRCTNAME [District Name], STSLSMGRCD [DM District],[DistrictGroup] [District Group] From STDISTRICT Where DLTFLG = 0"
    End Function
    Public Shared Function GetDistrictAssignmentSql() As String
        Return "Select Distinct DistrictGroup,STDISTRCTNAME from STDISTRICT Where DLTFLG = 0 AND STREGCD NOT IN ('INH','999')  Order by DistrictGroup"
    End Function
    Public Shared Function GetDistrictAssignmentbySASSql(ByVal SASCode As String) As String
        Return "Select Distinct CheckIn,DistrictGroupCode,DistrictName,TargetAmount from SalesAccountSpecialistDistrict Where SASCode = '" & SASCode & "'"
    End Function
    Public Shared Function GetTargetDistrictAssignmentbySql(ByVal SASCode As String) As String
        Return "Select SUM(TargetAmount) [TargetAmount] from SalesAccountSpecialistDistrict Where SASCode = '" & SASCode & "'"
    End Function
End Class
Public Class DistrictAssignmentCollection
    Inherits List(Of DistrictAssignment)
End Class

