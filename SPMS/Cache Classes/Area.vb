Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class Area
    Private m_AreaID As Integer = -1
    Private m_AreaCode As String = String.Empty
    Private m_AreaName As String = String.Empty
    Private m_RegionCode As String = String.Empty
    Private m_DistrictCode As String = String.Empty
    Private m_Createby As String = String.Empty
    Private m_DLTFLG As Boolean = False
    Private m_IsActive As Boolean = True
    Public ReadOnly Property ID As Integer
        Get
            Return m_AreaID
        End Get
    End Property
    Public Property AreaCode As String
        Get
            Return m_AreaCode
        End Get
        Set(value As String)
            m_AreaCode = value
        End Set
    End Property
    Public Property AreaName As String
        Get
            Return m_AreaName
        End Get
        Set(value As String)
            m_AreaName = value
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
    Public Property DistrictCode As String
        Get
            Return m_DistrictCode
        End Get
        Set(value As String)
            m_DistrictCode = value
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
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As AreaCollection
        Dim col As New AreaCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _Area As New Area
            Dim row As DataRow = Table.Rows(j)
            _Area.m_AreaID = row("Areaid")
            _Area.m_AreaCode = row("AREACD")
            _Area.m_AreaName = row("AreaName")
            _Area.m_RegionCode = row("REGCD")
            _Area.m_DistrictCode = row("DISTRCTCD")
            _Area.m_Createby = row("CRTU")
            _Area.m_DLTFLG = row("DLTFLG")
            _Area.m_IsActive = row("IsActive")
            col.Add(_Area)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspArea", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "SAVE")
            cmd.Parameters.AddWithValue("@AreaID", m_AreaID)
            cmd.Parameters.AddWithValue("@DLTFLG", False)
            cmd.Parameters.AddWithValue("@REGCD", m_RegionCode)
            cmd.Parameters.AddWithValue("@DISTRCTCD", m_DistrictCode)
            cmd.Parameters.AddWithValue("@AREACD", m_AreaCode)
            cmd.Parameters.AddWithValue("@AREANAME", m_AreaName)
            cmd.Parameters.AddWithValue("@ISACTIVE", True)
            m_AreaID = cmd.ExecuteScalar
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
            Dim cmd As New SqlCommand("uspRegion", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "DELETE")
            cmd.Parameters.AddWithValue("@REGCD", m_RegionCode)
            cmd.Parameters.AddWithValue("@DISTRCTCD", m_DistrictCode)
            cmd.Parameters.AddWithValue("@AREACD", m_AreaCode)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As AreaCollection
        Return BaseFilter(GetRecords("Select * From Area Where DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As AreaCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As Area
        Return Filter("AREAID = " & ID)(0)
    End Function

    Public Overloads Shared Function LoadByCode(ByVal Code As String) As Area
        Return Filter("AREACD = '" & RefineSQL(Code) & "'")(0)
    End Function
    Public Shared Function GetAreaSql(Optional ByVal Code As String = "") As String
        Return "Select AREACD,AREACD [Area Code],AREANAME [Area Name] From Area Where DLTFLG = 0  "
    End Function
    Public Shared Function GetAreaSql1(Optional ByVal Code As String = "") As String
        Return "Select Areaid,AREACD [Area Code],AREANAME [Area Name],DISTRCTCD [District Code],REGCD [Region Code] from Area Where DLTFLG = 0   "
    End Function
    Public Shared Function GetAreabyRegionAndDistrict(ByVal RegionCode As String, ByVal DistrictCode As String) As String
        Return "Select AREACD,Areacd [Area Code],Areaname [Area Name] from Area Where REGCD = '" & RegionCode & "' AND DISTRCTCD = '" & DistrictCode & "'"
    End Function
    Public Shared Function CheckCustomerArea(ByVal CustomerAreaCode As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM Area  WHERE  DLTFLG = 0 AND Areacd ='" & CustomerAreaCode & "'") = "A"
    End Function
    Public Shared Function CheckCustomerArea1(ByVal CustomerAreaCode As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM Area  WHERE  DLTFLG = 0 AND Areacd = '" & CustomerAreaCode & "' AND AREAID <> " & ID) = "A"
    End Function

End Class
Public Class AreaCollection
    Inherits List(Of Area)
End Class

