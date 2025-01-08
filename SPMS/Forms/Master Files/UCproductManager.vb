Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class UCproductManager

    Private pm_Id As Integer = -1

    Private pm_PmCode As String = String.Empty

    Private pm_PmName As String = String.Empty

    Private pm_pmTerritoryCode As String = String.Empty

    Private pm_pmsharing As String = String.Empty

    Private pm_EFFECTIVITYSTARTDATE As Date = "1/01/1900"

    Private pm_EFFECTIVITYENDDATE As Date = "1/01/1900"

    Private pm_PMID As String = ""




    Public ReadOnly Property ID() As Integer
        Get
            Return pm_Id
        End Get
    End Property
    Public Property PMID() As String
        Get
            Return pm_PMID
        End Get
        Set(ByVal value As String)
            pm_PMID = value
        End Set
    End Property
    Public Property PmCode() As String
        Get
            Return pm_PmCode
        End Get
        Set(ByVal value As String)
            pm_PmCode = value
        End Set
    End Property
    Public Property PmName() As String
        Get
            Return pm_PmName
        End Get
        Set(ByVal value As String)
            pm_PmName = value
        End Set
    End Property
    Public Property PmTerritoryCode() As String
        Get
            Return pm_pmTerritoryCode
        End Get
        Set(ByVal value As String)
            pm_pmTerritoryCode = value
        End Set
    End Property
    Public Property PmSharing() As String
        Get
            Return pm_pmsharing
        End Get
        Set(ByVal value As String)
            pm_pmsharing = value
        End Set
    End Property
    Public Property EFFECTIVITYSTARTDATE() As Date
        Get
            Return pm_EFFECTIVITYSTARTDATE
        End Get
        Set(ByVal value As Date)
            pm_EFFECTIVITYSTARTDATE = value
        End Set
    End Property
    Public Property EFFECTIVITYENDDATE() As Date
        Get
            Return pm_EFFECTIVITYENDDATE
        End Get
        Set(ByVal value As Date)
            pm_EFFECTIVITYENDDATE = value
        End Set
    End Property
    Public Function Save() As Boolean
        Connect()
        Try
            Dim cmd As New SqlCommand("uspProductManager", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action ", "Save")
            cmd.Parameters.AddWithValue("@PmID", pm_Id)
            cmd.Parameters.AddWithValue("@PmCode", pm_PmCode)
            cmd.Parameters.AddWithValue("@PmName", pm_PmName)
            cmd.Parameters.AddWithValue("@PmterritoryCode", pm_pmTerritoryCode)
            cmd.Parameters.AddWithValue("@PmSharing", pm_pmsharing)
            cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", pm_EFFECTIVITYSTARTDATE)
            cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", pm_EFFECTIVITYENDDATE)
            pm_Id = cmd.ExecuteScalar
            Disconnect()
            Return True
        Catch ex As System.Exception
            Disconnect()
        End Try
    End Function
    Public Function Edit() As Boolean
        Connect()
        Try
            Dim cmd As New SqlCommand("uspProductManager", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Edit")
            cmd.Parameters.AddWithValue("@PMID", pm_PMID)
            cmd.Parameters.AddWithValue("@Pmcode", pm_PmCode)
            cmd.Parameters.AddWithValue("@PmName", pm_PmName)
            cmd.Parameters.AddWithValue("@PmTerritoryCode", pm_pmTerritoryCode)
            cmd.Parameters.AddWithValue("@PMSharing", PmSharing)
            cmd.ExecuteNonQuery()
            Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Public Function Delete() As Boolean
        Connect()
        Try
            Dim cmd As New SqlCommand("uspProductManager", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@PmID", pm_Id)
            cmd.ExecuteNonQuery()
            Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As UCProductManagerCollection
        Dim col As New UCProductManagerCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_pm As New UCproductManager
            Dim row As DataRow = table.Rows(j)
            m_pm.pm_Id = row("ID")
            m_pm.pm_PmCode = row("Pm_Code")
            m_pm.pm_PmName = row("Pm_name")
            m_pm.pm_pmTerritoryCode = row("Pm_Territorycode")
            m_pm.pm_pmsharing = row("Pm_Sharing")
            col.Add(m_pm)
        Next
        Return col
    End Function '

    Public Shared Function Filter(ByVal Condition As String) As UCProductManagerCollection
        Return BaseFilter(GetRecords("Select * from ProductManager" & IIf(Condition <> "", "Where" & Condition, "")))
    End Function
    Public Overloads Shared Function Load() As UCProductManagerCollection
        Return Filter("")
    End Function

    Public Overloads Shared Function Load(ByVal ID As Integer) As UCproductManager
        Return Filter("ID = " & ID)(0)
    End Function

    Public Shared Function CheckifProductManagerExist(ByVal PM_Code As String) As Boolean
        Return ExecuteCommand("Select 'A' from ProductManager where Pm_Code '" & PM_Code & "'") = "A"
    End Function
    Public Shared Function GetPositionsql() As String
        Return "Select Pm_code,Pm_code [Position Code],Pm_Name [Position Name] From ProductManager"
    End Function

    Public Shared Function SQLOpenDatas() As Boolean
        Return ExecuteCommand("Select * from ProductManager")
    End Function
    Public Class UCProductManagerCollection
        Inherits List(Of UCproductManager)
    End Class
End Class
