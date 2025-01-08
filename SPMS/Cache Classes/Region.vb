Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class Regions
    Private m_RegionID As Integer = -1
    Private m_RegionCode As String = String.Empty
    Private m_RegionName As String = String.Empty
    Private m_DLTFLG As Boolean = False
    Private m_IsActive As Boolean = True
    Private m_Createby As String = String.Empty

    Public ReadOnly Property ID As Integer
        Get
            Return m_RegionID
        End Get
    End Property
    Public Property RegionCode As String
        Get
            Return m_RegionCode
        End Get
        Set(value As String)
            m_RegionCode = value
        End Set
    End Property
    Public Property RegionName As String
        Get
            Return m_RegionName
        End Get
        Set(value As String)
            m_RegionName = value
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
    Public Property IsActive As Boolean
        Get
            Return m_IsActive
        End Get
        Set(value As Boolean)
            m_IsActive = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As RegionCollection
        Dim col As New RegionCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _Region As New Regions
            Dim row As DataRow = Table.Rows(j)
            _Region.m_RegionID = row("REGIONID")
            _Region.m_RegionCode = row("REGCD")
            _Region.m_RegionName = row("REGNAME")
            _Region.m_Createby = row("CRTU")
            _Region.m_DLTFLG = row("DLTFLG")
            col.Add(_Region)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspRegion", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "SAVE")
            cmd.Parameters.AddWithValue("@REGID", m_RegionID)
            cmd.Parameters.AddWithValue("@DLTFLG", False)
            cmd.Parameters.AddWithValue("@REGCD", m_RegionCode)
            cmd.Parameters.AddWithValue("@REGNAME", m_RegionName)
            cmd.Parameters.AddWithValue("@CRTU", m_Createby)
            cmd.Parameters.AddWithValue("@ISACTIVE", True)
            m_RegionID = cmd.ExecuteScalar
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
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As RegionCollection
        Return BaseFilter(GetRecords("Select * From Region Where DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As RegionCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As Regions
        Return Filter("REGIONID = " & ID)(0)
    End Function

    Public Overloads Shared Function LoadByCode(ByVal Code As String) As Regions
        Return Filter("REGCD = '" & RefineSQL(Code) & "'")(0)
    End Function
    Public Shared Function GetRegionSql(Optional ByVal Code As String = "") As String
        Return "Select REGCD,REGCD [Region Code],REGNAME [Region Name] From Region Where DLTFLG = 0   "
    End Function
    Public Shared Function GetRegion1Sql(Optional ByVal Code As String = "") As String
        Return "Select REGIONID,REGCD [Region Code],REGNAME [Region Name] From Region Where DLTFLG = 0   "
    End Function
    Public Shared Function CheckCustomerRegion(ByVal CustomerRegionCode As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM Region  WHERE  DLTFLG = 0 AND REGCD ='" & RefineSQL(CustomerRegionCode) & "' And REGIONID <> " & ID) = "A"
    End Function
    Public Shared Function CheckCustomerRegion1(ByVal CustomerRegionCode As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM Region  WHERE  DLTFLG = 0 AND REGCD ='" & RefineSQL(CustomerRegionCode) & "'") = "A"
    End Function
End Class
Public Class RegionCollection
    Inherits List(Of Regions)
End Class