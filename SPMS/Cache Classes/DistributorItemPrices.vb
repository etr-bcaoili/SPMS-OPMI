Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class DistributorItemPrices
    Private _ID As Integer = -1
    Private _IDS As Integer = -1
    Private _CompanyCode As String = String.Empty
    Private _ItemCode As String = String.Empty
    Private _ChannelItemCode As String = String.Empty
    Private _ChannelItemDescription As String = String.Empty
    Private _ChannelPrices As Double = 0
    Private _CompanyPrices As Double = 0
    Private _EffectivityStartDate As Date = "1/1/1990"
    Private _EffectivityEndDate As Date = "1/1/1990"
    Private _DLTFLG As Boolean = False
    Private _IsAction As Boolean = True
    Public ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property
    Public Property IDS As Integer
        Get
            Return _IDS
        End Get
        Set(value As Integer)
            _IDS = value
        End Set
    End Property
    Public Property CompanyCode As String
        Get
            Return _CompanyCode
        End Get
        Set(value As String)
            _CompanyCode = value
        End Set
    End Property
    Public Property ItemCode As String
        Get
            Return _ItemCode
        End Get
        Set(value As String)
            _ItemCode = value
        End Set
    End Property
    Public Property ChannelItemCode As String
        Get
            Return _ChannelItemCode
        End Get
        Set(value As String)
            _ChannelItemCode = value
        End Set
    End Property
    Public Property ChannelItemDescription As String
        Get
            Return _ChannelItemDescription
        End Get
        Set(value As String)
            _ChannelItemDescription = value
        End Set
    End Property
    Public Property ChannelPrices As Double
        Get
            Return _ChannelPrices
        End Get
        Set(value As Double)
            _ChannelPrices = value
        End Set
    End Property
    Public Property CompanyPrices As Double
        Get
            Return _CompanyPrices
        End Get
        Set(value As Double)
            _CompanyPrices = value
        End Set
    End Property
    Public Property EffectivityStartDate As Date
        Get
            Return _EffectivityStartDate
        End Get
        Set(value As Date)
            _EffectivityStartDate = value
        End Set
    End Property
    Public Property EffectivityEndDate As Date
        Get
            Return _EffectivityEndDate
        End Get
        Set(value As Date)
            _EffectivityEndDate = value
        End Set
    End Property
    Public Property IsAction As Boolean
        Get
            Return _IsAction
        End Get
        Set(value As Boolean)
            _IsAction = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As DistributorItemPricesCollection
        Dim col As New DistributorItemPricesCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _ItemDistributor As New DistributorItemPrices
            Dim row As DataRow = Table.Rows(j)
            _ItemDistributor._IDS = row("DISTID")
            _ItemDistributor._ID = row("DISTID")
            _ItemDistributor._CompanyCode = row("COMID")
            _ItemDistributor._ItemCode = row("ITEMCD")
            _ItemDistributor._ChannelItemCode = row("DISTITEMCD")
            _ItemDistributor._ChannelItemDescription = row("ITEMNAME")
            _ItemDistributor._ChannelPrices = row("DISTITEMPRICE")
            _ItemDistributor._CompanyPrices = row("CompanyPrice")
            _ItemDistributor._EffectivityStartDate = row("EFFECTIVITYSTARTDATE")
            _ItemDistributor._EffectivityEndDate = row("EFFECTIVITYENDDATE")
            _ItemDistributor._IsAction = row("ISACTIVE")
            col.Add(_ItemDistributor)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspDistributorItems", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "SAVE")
            cmd.Parameters.AddWithValue("@DISTID", _ID)
            cmd.Parameters.AddWithValue("@COMID", _CompanyCode)
            cmd.Parameters.AddWithValue("@ITEMCD", _ItemCode)
            cmd.Parameters.AddWithValue("@DISTITEMCD", _ChannelItemCode)
            cmd.Parameters.AddWithValue("@ITEMNAME", _ChannelItemDescription)
            cmd.Parameters.AddWithValue("@DISTITEMPRICE", _ChannelPrices)
            cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", _EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", _EffectivityEndDate)
            cmd.Parameters.AddWithValue("@ISACTIVE", True)
            _ID = cmd.ExecuteScalar
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Function Update() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspDistributorItems", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "UPDATE")
            cmd.Parameters.AddWithValue("@DISTID", _IDS)
            cmd.Parameters.AddWithValue("@COMID", _CompanyCode)
            cmd.Parameters.AddWithValue("@ITEMCD", _ItemCode)
            cmd.Parameters.AddWithValue("@DISTITEMCD", _ChannelItemCode)
            cmd.Parameters.AddWithValue("@ITEMNAME", _ChannelItemDescription)
            cmd.Parameters.AddWithValue("@DISTITEMPRICE", _ChannelPrices)
            cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", _EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", _EffectivityEndDate)
            cmd.Parameters.AddWithValue("@ISACTIVE", _IsAction)
            _ID = cmd.ExecuteScalar
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
            Dim cmd As New SqlCommand("uspDistributorItems", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "DELETE")
            cmd.Parameters.AddWithValue("@DISTID", _IDS)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Shared Function GetItemDescriptionSql(Optional ByVal ItemCode As String = "") As String
        Return "SELECT COMID,COMID [Company Code],EffectivityStartDate [Effectivity Start Date], EffectivityEndDate [Effectivity End Date],CASE When IsActive = 1 Then 'Active' Else 'Inactive' End [Status]  from distributoritems Where IsActive = 1  GROUP BY COMID,EffectivityStartDate,EffectivityEndDate,IsActive Order by COMID"
    End Function
    Public Shared Function GetItemsSql() As String
        Return "Select Distinct itemthr,ITEMMDES,IMDBRN from Item Where ITEMDEL = 0"
    End Function
    Public Shared Function GetProductItemCopyFromSql() As String
        Return "SELECT COMID,COMID [Distributor Code],EffectivityStartDate [Effectivity Start Date], EffectivityEndDate [Effectivity End Date]  from distributoritems Where IsActive = 1  GROUP BY COMID,EffectivityStartDate,EffectivityEndDate,IsActive Order by COMID"
    End Function
    Public Shared Function GetItemDescriptionPriceSql(ByVal CompanyCode As String, ByVal EffectivityStartDate As Date, ByVal EffectivityEndDate As Date) As String
        Return "SELECT Itemcd,Distitemcd,ItemName,Distitemprice,CompanyPrice,DISTID FROM DistributorItems WHERE COMID = '" & CompanyCode & "' And EffectivityStartDate = '" & EffectivityStartDate & "' And EffectivityEndDate = '" & EffectivityEndDate & "' And IsActive = 1 Order by ITEMNAME"
    End Function
    Public Shared Function GetCheckIfItemExistSql(ByVal ItemDescriptionCode As String, ByVal CompanyCode As String, ByVal EffectivityStartDate As Date, ByVal EffectivityEndDate As Date, ByVal DISTID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM DistributorItems WHERE  DISTITEMCD = '" & HandleSingleQuoteInSql(ItemDescriptionCode) & "' AND COMID = '" & HandleSingleQuoteInSql(CompanyCode) & "'  AND EffectivityStartDate  = '" & EffectivityStartDate & "' AND EffectivityEndDate = '" & EffectivityEndDate & "' And IsActive = 1 AND DISTID <> '" & DISTID & "'") = "A"
    End Function
    Public Shared Function CheckOfDistributorChannelAlreadyExist(ByVal CompanyCode As String, ByVal StartDate As Date, ByVal EndDate As Date) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM DistributorItems Where COMID = '" & CompanyCode & "' AND EffectivityStartDate = '" & StartDate & "' AND EffectivityEndDate = '" & EndDate & "'") = "A"
    End Function
End Class
Public Class DistributorItemPricesCollection
    Inherits List(Of DistributorItemPrices)
End Class
