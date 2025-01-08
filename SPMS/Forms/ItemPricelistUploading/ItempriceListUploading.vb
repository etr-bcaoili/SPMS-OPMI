
Imports System.Data.SqlClient
Imports SPMSOPCI.ConnectionModule

Public Class ItempriceListUploading

    Private m_DISTID As Integer = -1

    Private m_COMID As String = String.Empty

    Private m_ITEMCD As String = String.Empty

    Private m_ITEMNAME As String = String.Empty

    Private m_DISTITEMCD As String = String.Empty

    Private m_DISTITEMPRICE As Decimal = 0

    Private m_EffectivityStartDate As Date = "1/1/1900"

    Private m_EffectivityEndDate As Date = "1/1/1900"

    Private m_IsActive As String = String.Empty

    Private m_CompanyPrice As Decimal = 0


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
    Public Property ITEMNAME() As String
        Get
            Return m_ITEMNAME
        End Get
        Set(ByVal value As String)
            m_ITEMNAME = value
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
    Public Property DISTITEMPRICE() As String
        Get
            Return m_DISTITEMPRICE
        End Get
        Set(ByVal value As String)
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

    Public Property IsActive() As String
        Get
            Return m_IsActive
        End Get
        Set(ByVal value As String)
            m_IsActive = value
        End Set
    End Property
    Public Property CompanyPrice() As Decimal
        Get
            Return m_CompanyPrice
        End Get
        Set(ByVal value As Decimal)
            m_CompanyPrice = value
        End Set
    End Property

    Public Function Save() As Boolean
        Connect()
        Try
            Dim cmd As New SqlCommand("uspDistributorItems", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Save")
            cmd.Parameters.AddWithValue("@DISTID", m_DISTID)
            cmd.Parameters.AddWithValue("@COMID", m_COMID)
            cmd.Parameters.AddWithValue("@ITEMCD", m_ITEMCD)
            cmd.Parameters.AddWithValue("@DISTITEMCD", m_DISTITEMCD)
            cmd.Parameters.AddWithValue("@ITEMNAME", m_ITEMNAME)
            cmd.Parameters.AddWithValue("@DISTITEMPRICE", m_DISTITEMPRICE)
            cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", m_EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", m_EffectivityEndDate)
            cmd.Parameters.AddWithValue("@ISACTIVE", m_IsActive)
            m_DISTID = cmd.ExecuteScalar()
            Disconnect()
            Return True
        Catch ex As System.Exception
            Disconnect()
            Throw
        End Try
    End Function
    Public Function Update() As Boolean
        Connect()
        Try
            Dim cmd As New SqlCommand("uspDistributorItems", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Update")
            cmd.Parameters.AddWithValue("@DISTID", m_DISTID)
            cmd.Parameters.AddWithValue("@COMID", m_COMID)
            cmd.Parameters.AddWithValue("@ITEMCD", m_ITEMCD)
            cmd.Parameters.AddWithValue("@DISTITEMCD", m_DISTITEMCD)
            cmd.Parameters.AddWithValue("@ITEMNAME", m_ITEMNAME)
            cmd.Parameters.AddWithValue("@DISTITEMPRICE", m_DISTITEMPRICE)
            cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", m_EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", m_EffectivityEndDate)
            cmd.Parameters.AddWithValue("@ISACTIVE", m_IsActive)


            m_DISTID = cmd.ExecuteScalar()
            Disconnect()
            Return True
        Catch ex As System.Exception
            Disconnect()
            Throw
        End Try
    End Function
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As ItempriceListUploadingCollection
        Dim col As New ItempriceListUploadingCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_Itemlist As New ItempriceListUploading
            Dim row As DataRow = table.Rows(j)
            m_Itemlist.m_DISTID = row("DISTID")
            m_Itemlist.m_COMID = row("COMID")
            m_Itemlist.m_DISTITEMCD = row("DISTITEMCD")
            m_Itemlist.m_CompanyPrice = row("CompanyPrice")
            m_Itemlist.m_DISTITEMPRICE = row("DISTITEMPRICE")
            m_Itemlist.m_IsActive = row("IsActive")
            m_Itemlist.m_ITEMCD = row("ITEMCD")
            m_Itemlist.m_ITEMNAME = row("ITEMNAME")
            m_Itemlist.m_EffectivityEndDate = row("EffectivityEndDate")
            m_Itemlist.m_EffectivityStartDate = row("EffectivityStartDate")
            col.Add(m_Itemlist)
        Next
        Return col
    End Function
    Public Shared Function Filter(ByVal Condition As String) As ItempriceListUploadingCollection
        Return BaseFilter(GetRecords("SELECT * FROM DISTRIBUTORITEMS " & IIf(Condition <> "", " WHERE " & Condition, "")))
    End Function
    Public Shared Function CheckIfItempriceListDataExist(ByVal CompanyCode As String, ByVal StartDate As String, ByVal EndDate As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM DISTRIBUTORITEMS Where Comid = '" & CompanyCode & "' and  EffectivityStartDate = '" & StartDate & "' and EffectivityEndDate = '" & EndDate & "'") = "A"
    End Function
    Public Shared Function DeleteExistIfitempriceList(ByVal CompanyCode As String, ByVal StartDate As String, ByVal EndDate As String) As Boolean
        Return ExecuteCommand("DELETE FROM DISTRIBUTORITEMS Where Comid = '" & CompanyCode & "' and  EffectivityStartDate = '" & StartDate & "' and EffectivityEndDate = '" & EndDate & "'")
    End Function
    Public Overloads Shared Function Load() As ItempriceListUploadingCollection
        Return Filter("")
    End Function

    Public Overloads Shared Function Load(ByVal RawDataID As Integer) As ItempriceListUploading
        Return Filter("RawDataID = " & RawDataID)(0)
    End Function
    Public Shared Function GetItempriceList(ByVal Companycode As String) As Boolean
        Return "select * from  DISTRIBUTORITEMS where COMID = '" & Companycode & "'"
    End Function
    Public Class ItempriceListUploadingCollection
        Inherits List(Of ItempriceListUploading)
    End Class
End Class

