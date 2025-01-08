Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class Districts
    Private m_DistrictID As Integer = -1
    Private m_DistrictCode As String = String.Empty
    Private m_Districtname As String = String.Empty
    Private m_RegionCode As String = String.Empty
    Private m_DLTFLG As Boolean = False
    Private m_IsActive As Boolean = True
    Private m_Createby As String = String.Empty

    Public ReadOnly Property ID As Integer
        Get
            Return m_DistrictID
        End Get
    End Property
    Public Property DistrinctCode As String
        Get
            Return m_DistrictCode
        End Get
        Set(value As String)
            m_DistrictCode = value
        End Set
    End Property
    Public Property DistrictName As String
        Get
            Return m_Districtname
        End Get
        Set(value As String)
            m_Districtname = value
        End Set
    End Property
    Public Property RegionCode As String
        Get
            Return m_RegionCode
        End Get
        Set(value As String)
            m_RegionCode = value
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
    Public Property CreateBy As String
        Get
            Return m_Createby
        End Get
        Set(value As String)
            m_Createby = value
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
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As DistrictCollection
        Dim col As New DistrictCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _District As New Districts
            Dim row As DataRow = Table.Rows(j)
            _District.m_DistrictID = row("DISTRICTID")
            _District.m_DistrictCode = row("DISTRCTCD")
            _District.m_Districtname = row("DISTRCTNAME")
            _District.m_RegionCode = row("REGCD")
            _District.m_Createby = row("CRTU")
            _District.m_DLTFLG = row("DLTFLG")
            col.Add(_District)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspDistrict", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "SAVE")
            cmd.Parameters.AddWithValue("@DISTRICTID", m_DistrictID)
            cmd.Parameters.AddWithValue("@DLTFLG", False)
            cmd.Parameters.AddWithValue("@DISTRCTCD", m_DistrictCode)
            cmd.Parameters.AddWithValue("@DISTRCTNAME", m_Districtname)
            cmd.Parameters.AddWithValue("@REGCD", m_RegionCode)
            cmd.Parameters.AddWithValue("@CRTU", m_Createby)
            cmd.Parameters.AddWithValue("@ISACTIVE", True)
            m_DistrictID = cmd.ExecuteScalar
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Function Delete() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspDistrict", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "DELETE")
            cmd.Parameters.AddWithValue("@DISTRCTCD", m_DistrictCode)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As DistrictCollection
        Return BaseFilter(GetRecords("Select * From DISTRICT Where DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As DistrictCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As Districts
        Return Filter("DistrictID = " & ID)(0)
    End Function

    Public Overloads Shared Function LoadByCode(ByVal Code As String) As Districts
        Return Filter("Distrctcd = '" & RefineSQL(Code) & "'")(0)
    End Function
    Public Shared Function GetDistrictSql(Optional ByVal Code As String = "") As String
        Return "Select Distrctcd,Distrctcd [District Code],Distrctname [District Name],Regcd [Region Code] from District Where DLTFLG = 0"
    End Function
    Public Shared Function GetDistrictSql1(Optional ByVal Code As String = "") As String
        Return "Select DISTRICTID,Distrctcd [District Code],Distrctname [District Name],Regcd [Region Code] from District Where DLTFLG = 0"
    End Function
    Public Shared Function GetDistrictbyRegion(ByVal RegionCode As String) As String
        Return "Select Distrctcd,Distrctcd [District Code],Distrctname [District Name] from District Where DLTFLG = 0 And Regcd ='" & RegionCode & "'"
    End Function
    Public Shared Function GetDistrictsql2(ByVal DistrictCode As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM District  WHERE  DLTFLG = 0 AND Distrctcd ='" & DistrictCode & "'") = "A"
    End Function
    Public Shared Function CheckCustomerDistrict(ByVal CustomerRegionCode As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM District  WHERE  DLTFLG = 0 AND Distrctcd ='" & CustomerRegionCode & "'") = "A"
    End Function
    Public Shared Function CheckCustomerDistrict1(ByVal DistrictCode As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM District  WHERE  DLTFLG = 0 AND Distrctcd ='" & RefineSQL(DistrictCode) & "' And DISTRICTID <> " & ID) = "A"
    End Function
End Class
Public Class DistrictCollection
    Inherits List(Of Districts)
End Class
