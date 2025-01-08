Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class DistributorItems

    Private m_DISTID As Integer = -1
    Private m_COMID As String = String.Empty
    Private m_ITEMCD As String = String.Empty
    Private m_DISTITEMCD As String = String.Empty
    Private m_ITEMNAME As String = String.Empty
    Private m_DISTITEMPRICE As Double = 0
    Private m_EffectivityStartDate As Date = "1/1/1900"
    Private m_EffectivityEndDate As Date = "1/1/1900"
    Private m_IsActive As Boolean = False
    Private m_CompanyPrice As Double = 0

    Public ReadOnly Property DISTID() As Integer
        Get
            Return m_DISTID
        End Get
    End Property

    Public Property COMID() As String
        Get
            Return m_COMID
        End Get
        Set(ByVal value As String)
            m_COMID = value
        End Set
    End Property

    Public Property ITEMCD() As String
        Get
            Return m_ITEMCD
        End Get
        Set(ByVal value As String)
            m_ITEMCD = value
        End Set
    End Property

    Public Property DISTITEMCD() As String
        Get
            Return m_DISTITEMCD
        End Get
        Set(ByVal value As String)
            m_DISTITEMCD = value
        End Set
    End Property

    Public Property ITEMNAME() As String
        Get
            Return m_ITEMNAME
        End Get
        Set(ByVal value As String)
            m_ITEMNAME = value
        End Set
    End Property

    Public Property DISTITEMPRICE() As Double
        Get
            Return m_DISTITEMPRICE
        End Get
        Set(ByVal value As Double)
            m_DISTITEMPRICE = value
        End Set
    End Property

    Public Property EffectivityStartDate() As Date
        Get
            Return m_EffectivityStartDate
        End Get
        Set(ByVal value As Date)
            m_EffectivityStartDate = value
        End Set
    End Property

    Public Property EffectivityEndDate() As Date
        Get
            Return m_EffectivityEndDate
        End Get
        Set(ByVal value As Date)
            m_EffectivityEndDate = value
        End Set
    End Property

    Public Property IsActive() As Boolean
        Get
            Return m_IsActive
        End Get
        Set(ByVal value As Boolean)
            m_IsActive = value
        End Set
    End Property

    Public Property CompanyPrice() As Double
        Get
            Return m_CompanyPrice
        End Get
        Set(ByVal value As Double)
            m_CompanyPrice = value
        End Set
    End Property

    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspDISTRIBUTORITEM", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@DISTID", m_DISTID)
            cmd.Parameters.AddWithValue("@COMID", m_COMID)
            cmd.Parameters.AddWithValue("@ITEMCD", m_ITEMCD)
            cmd.Parameters.AddWithValue("@DISTITEMCD", m_DISTITEMCD)
            cmd.Parameters.AddWithValue("@ITEMNAME", m_ITEMNAME)
            cmd.Parameters.AddWithValue("@DISTITEMPRICE", m_DISTITEMPRICE)
            cmd.Parameters.AddWithValue("@EffectivityStartDate", m_EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EffectivityEndDate", m_EffectivityEndDate)
            cmd.Parameters.AddWithValue("@IsActive", m_IsActive)
            cmd.Parameters.AddWithValue("@CompanyPrice", m_CompanyPrice)
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function

    Public Function Delete() As Boolean

        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspDISTRIBUTORITEM", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Delete")
            cmd.Parameters.AddWithValue("DISTID", m_DISTID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function

    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As DistributorItemsCollection
        Dim col As New DistributorItemsCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_DistributorItems As New DistributorItems
            Dim row As DataRow = table.Rows(j)
            m_DistributorItems.m_DISTID = row("DISTID")
            m_DistributorItems.m_COMID = row("COMID")
            m_DistributorItems.m_ITEMCD = row("ITEMCD")
            m_DistributorItems.m_DISTITEMCD = row("DISTITEMCD")
            m_DistributorItems.m_ITEMNAME = row("ITEMNAME")
            m_DistributorItems.m_DISTITEMPRICE = row("DISTITEMPRICE")
            m_DistributorItems.m_IsActive = row("IsActive")
            m_DistributorItems.m_EffectivityStartDate = row("EFFECTIVITYSTARTDATE")
            m_DistributorItems.m_EffectivityEndDate = row("EFFECTIVITYENDDATE")
            m_DistributorItems.m_CompanyPrice = row("COMPANYPRICE")
            col.Add(m_DistributorItems)
        Next
        Return col
    End Function

    Public Shared Function Filter(ByVal Condition As String) As DistributorItemsCollection
        Return BaseFilter(GetRecords("SELECT * FROM Distributor  WHERE " & IIf(Condition <> "", Condition, "")))
    End Function

    Public Overloads Shared Function Load() As DistributorItemsCollection
        Return Filter("")
    End Function

    Public Overloads Shared Function Load(ByVal DISTID As Integer) As DistributorItems
        Return Filter("DISTID = " & DISTID)(0)
    End Function

    Public Shared Function GetDistributorItemsSql(Optional ByVal CustomerGroup As String = "") As String
        Return "SELECT DISTID, COMID, ITEMCD FROM DISTRIBUTORITEM"
    End Function
    Public Shared Function CheckDistributorItemExist(ByVal DistributorCode As String, ByVal EffectivityStartDate As Date, ByVal EffectivityEndDate As Date)
        Return ExecuteCommand("Select 'A' From DISTRIBUTORITEM Where DLTFLG = 0 And COMID = '" & RefineSQL(DistributorCode) & "' And EFFECTIVITYSTARTDATE = '" & EffectivityStartDate & "' AND EFFECTIVITYENDDATE = '" & EffectivityEndDate) = "A"
    End Function

    Public Shared Function GetDistributorItemsColumns() As String
        Return "DISTID; COMID; ITEMCD;"
    End Function
    Public Shared Function GetDistributionItemsCompany() As String
        Return "SELECT Distinct (Comid) from DistributorItems"
    End Function
    Public Shared Function GetListPrice(ByVal COMID As String, ByVal ITEMCD As String) As String
        Return ExecuteCommand("Select DISTITEMPRICE From DistributorItems Where COMID = '" & COMID & "' AND ITEMCD = '" & ITEMCD & "'")
    End Function
End Class

Public Class DistributorItemsCollection

    Inherits List(Of DistributorItems)
End Class
