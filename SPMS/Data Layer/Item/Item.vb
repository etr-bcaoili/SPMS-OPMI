Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices.ComTypes

Public Class Items
    Private m_ItemDel As Boolean = False
    Private m_ItemCode As String = String.Empty
    Private m_ItemCode1 As String = String.Empty
    Private m_itemthr As String = String.Empty
    Private m_ItemMMDES As String = String.Empty
    Private m_ItemBrand As String = String.Empty
    Private m_ItemBrand2 As String = String.Empty
    Private m_ItemGeneric As String = String.Empty
    Private m_ItemForm As String = String.Empty
    Private m_ItemStrength As String = String.Empty
    Private m_ItemUnit As String = String.Empty
    Private m_ItemGroupCode As String = String.Empty
    Private m_ProductItemGroup As String = String.Empty
    Private m_ItemClassCode As String = String.Empty
    Private m_ItemDivisionCode As String = String.Empty
    Private m_ItemCreateDate As Date = "1/1/1990"
    Private m_ItemCreatedUser As String = String.Empty
    Private m_ItemUpdatedDate As Date = "1/1/1990"
    Private m_ItemUpdatedUser As String = String.Empty
    Private m_EffectivityStartDate As Date = "1/1/1990"
    Private m_EffectivityEndDate As Date = "1/1/1990"
    Private m_IsActive As Boolean = False
    Private m_ItemQuantity As Decimal = 0
    Private m_ItemDivName As String = String.Empty
    Private m_ItemProductCategory As String = String.Empty
    Private m_ItemProductAssign As String = String.Empty
    Private _ID As Integer = -1
    Public ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property
    Public Property ItemDel() As Boolean
        Get
            Return m_ItemDel
        End Get
        Set(ByVal value As Boolean)
            m_ItemDel = value
        End Set
    End Property

    Public Property ItemCode() As String
        Get
            Return m_ItemCode
        End Get
        Set(ByVal value As String)
            m_ItemCode = value
        End Set
    End Property

    Public Property ItemCode1() As String
        Get
            Return m_ItemCode1
        End Get
        Set(ByVal value As String)
            m_ItemCode1 = value
        End Set
    End Property

    Public Property Itemthr() As String
        Get
            Return m_itemthr
        End Get
        Set(ByVal value As String)
            m_itemthr = value
        End Set
    End Property

    Public Property ItemMMDES() As String
        Get
            Return m_ItemMMDES
        End Get
        Set(ByVal value As String)
            m_ItemMMDES = value
        End Set
    End Property

    Public Property ItemBrand() As String
        Get
            Return m_ItemBrand
        End Get
        Set(ByVal value As String)
            m_ItemBrand = value
        End Set
    End Property

    Public Property ItemBrand2() As String
        Get
            Return m_ItemBrand2
        End Get
        Set(ByVal value As String)
            m_ItemBrand2 = value
        End Set
    End Property

    Public Property ItemGeneric() As String
        Get
            Return m_ItemGeneric
        End Get
        Set(ByVal value As String)
            m_ItemGeneric = value
        End Set
    End Property

    Public Property ItemForm() As String
        Get
            Return m_ItemForm
        End Get
        Set(ByVal value As String)
            m_ItemForm = value
        End Set
    End Property

    Public Property ItemStrength() As String
        Get
            Return m_ItemStrength
        End Get
        Set(ByVal value As String)
            m_ItemStrength = value
        End Set
    End Property

    Public Property ItemQuantity() As String
        Get
            Return m_ItemQuantity
        End Get
        Set(ByVal value As String)
            m_ItemQuantity = value
        End Set
    End Property

    Public Property ItemGroupCode() As String
        Get
            Return m_ItemGroupCode
        End Get
        Set(ByVal value As String)
            m_ItemGroupCode = value
        End Set
    End Property

    Public Property ItemClassCode() As String
        Get
            Return m_ItemClassCode
        End Get
        Set(ByVal value As String)
            m_ItemClassCode = value
        End Set
    End Property

    Public Property ItemDivisionCode() As String
        Get
            Return m_ItemDivisionCode
        End Get
        Set(ByVal value As String)
            m_ItemDivisionCode = value
        End Set
    End Property
    Public Property ProductItemGroup As String
        Get
            Return m_ProductItemGroup
        End Get
        Set(value As String)
            m_ProductItemGroup = value
        End Set
    End Property

    Public Property ItemCreateDate() As Date
        Get
            Return m_ItemCreateDate
        End Get
        Set(ByVal value As Date)
            m_ItemCreateDate = value
        End Set
    End Property

    Public Property ItemCreatedUser() As String
        Get
            Return m_ItemCreatedUser
        End Get
        Set(ByVal value As String)
            m_ItemCreatedUser = value
        End Set
    End Property

    Public Property ItemUpdatedDate() As Date
        Get
            Return m_ItemUpdatedDate
        End Get
        Set(ByVal value As Date)
            m_ItemUpdatedDate = value
        End Set
    End Property

    Public Property ItemUpdatedUser() As String
        Get
            Return m_ItemUpdatedUser
        End Get
        Set(ByVal value As String)
            m_ItemUpdatedUser = value
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
    Public Property ItemUnit As String
        Get
            Return m_ItemUnit
        End Get
        Set(value As String)
            m_ItemUnit = value
        End Set
    End Property
    Public Property ItemProductCategoryCode As String
        Get
            Return m_ItemProductCategory
        End Get
        Set(value As String)
            m_ItemProductCategory = value
        End Set
    End Property
    Public Property ItemProductAssign As String
        Get
            Return m_ItemProductAssign
        End Get
        Set(value As String)
            m_ItemProductAssign = value
        End Set
    End Property


    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()

        Try
            Dim cmd As New SqlCommand("uspItem", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@ID", _ID)
            cmd.Parameters.AddWithValue("@ItemDel", m_ItemDel)
            cmd.Parameters.AddWithValue("@ItemCd", m_ItemCode1)
            cmd.Parameters.AddWithValue("@itemthr", m_itemthr)
            cmd.Parameters.AddWithValue("@ItemCd1", m_ItemCode1)
            cmd.Parameters.AddWithValue("@ITEMMDES", m_ItemMMDES)
            cmd.Parameters.AddWithValue("@ImdBrn", m_ItemBrand)
            cmd.Parameters.AddWithValue("@ImdBrn2", m_ItemBrand2)
            cmd.Parameters.AddWithValue("@ImdGen", m_ItemGeneric)
            cmd.Parameters.AddWithValue("@ImdFrm", m_ItemForm)
            cmd.Parameters.AddWithValue("@ImdStr", m_ItemStrength)
            cmd.Parameters.AddWithValue("@ItemUnit", m_ItemUnit)
            cmd.Parameters.AddWithValue("@ItemGrpCd", m_ItemGroupCode)
            cmd.Parameters.AddWithValue("@ItemClsCd", m_ItemClassCode)
            cmd.Parameters.AddWithValue("@ItemDivCd", m_ItemDivisionCode)
            cmd.Parameters.AddWithValue("@ProductItemGroup", m_ProductItemGroup)
            cmd.Parameters.AddWithValue("@ImCrdt", m_ItemCreateDate)
            cmd.Parameters.AddWithValue("@ImCrtu", m_ItemCreatedUser)
            cmd.Parameters.AddWithValue("@ImUpdd", m_ItemUpdatedDate)
            cmd.Parameters.AddWithValue("@ImUpdu", m_ItemUpdatedUser)
            cmd.Parameters.AddWithValue("@IsActive", m_IsActive)
            cmd.Parameters.AddWithValue("@ItemQuantity", m_ItemQuantity)
            cmd.Parameters.AddWithValue("@ItemDivName", m_ItemDivName)
            cmd.Parameters.AddWithValue("@ItemProductCategory", m_ItemProductCategory)
            'cmd.Parameters.AddWithValue("@ItemProductAssign", m_ItemProductAssign)
            _ID = cmd.ExecuteScalar
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
            Dim cmd As New SqlCommand("uspItem", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Delete")
            cmd.Parameters.AddWithValue("@ITEMCD", m_ItemCode)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function


    Private Shared Function BaseFilter(ByVal dtItem As DataTable) As ItemCollection
        Dim col As New ItemCollection

        For m As Integer = 0 To dtItem.Rows.Count - 1
            Dim dr As DataRow = dtItem.Rows(m)
            Dim m_Item As New Items
            m_Item._ID = dr("ID")
            m_Item.m_ItemDel = dr("ItemDel")
            m_Item.m_ItemCode = dr("ItemCd")
            m_Item.m_itemthr = dr("itemthr")
            m_Item.m_ItemCode1 = dr("ItemCd1")
            m_Item.m_ItemMMDES = dr("ITEMMDES")
            m_Item.m_ItemBrand = dr("ImdBrn")
            m_Item.m_ItemBrand2 = dr("ImdBrn2")
            m_Item.m_ItemGeneric = dr("ImdGen")
            m_Item.m_ItemForm = dr("ImdFrm")
            m_Item.m_ItemStrength = dr("ImdStr")
            m_Item.m_ItemQuantity = dr("PCKSIZE")
            m_Item.m_ItemGroupCode = dr("ItemGrpCd")
            m_Item.m_ItemClassCode = dr("ItemClsCd")
            m_Item.m_ItemDivisionCode = dr("ItemDivCd")
            m_Item.m_ProductItemGroup = dr("ProductGroupCode")
            m_Item.m_ItemCreateDate = dr("ImCrdt")
            m_Item.m_ItemCreatedUser = dr("ImCrtu")
            m_Item.m_ItemUpdatedDate = dr("ImUpdd")
            m_Item.m_ItemUpdatedUser = dr("ImUpdu")
            m_Item.m_IsActive = dr("IsActive")
            m_Item.m_ItemUnit = dr("ImdSiz")
            m_Item.m_ItemDivName = dr("ItemDivName")
            m_Item.m_ItemProductCategory = dr("ItemProductCategory")
            'm_Item.m_ItemProductAssign = dr("ItemProductAssign")
            col.Add(m_Item)
        Next
        Return col
    End Function

    Public Shared Function Filter(ByVal Condition As String) As ItemCollection
        Return BaseFilter(GetRecords("SELECT * FROM Item  WHERE ITEMDEL = 0" & IIf(Condition <> "", " AND " & Condition, "")))
    End Function

    Public Overloads Shared Function Load() As ItemCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As Items
        Return Filter("ID = " & ID)(0)
    End Function
    Public Shared Function LoadByCode(ByVal ItemCode As String) As Items
        Return Filter("Itemcd = '" & HandleSingleQuoteInSql(ItemCode) & "'")(0)
    End Function
    Public Shared Function LoadByMotherCode(ByVal ItemThr As String) As Items
        Return Filter("itemthr = '" & RefineSQL(ItemThr) & "'")(0)
    End Function
    Public Shared Function LoadByItemCode(ByVal ItemCode As String) As Items
        Return Filter("Itemcd = '" & RefineSQL(ItemCode) & "'")(0)
    End Function


    Public Shared Function GetItemName(ByVal ItemCode As String) As String
        Return LoadByCode(ItemCode).ItemBrand
    End Function

    Public Shared Function GetItemListOfScantron() As List(Of String)
        Dim St As New List(Of String)
        Dim dt As New DataTable
        dt = (GetRecords("Select ItemCode From ImportItemList order by itemcode Asc"))
        For r As Integer = 0 To dt.Rows.Count - 1
            Dim row As DataRow = dt.Rows(r)
            St.Add(row("ItemCode"))
        Next
        Return St
    End Function
    Public Shared Function CheckItemCodeIsAlreadyExist(ByVal ItemCode As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM Item Where ITEMDEL = 0 AND ITEMCD = '" & RefineSQL(ItemCode) & "' AND ID <> " & ID) = "A"
    End Function

    Public Shared Function GetItemSql() As String
        Return ("SELECT ITEMCD as [Item Code],ITEMCD1 as [Item Code],itemthr AS [Item Mother Code],ITEMMDES as [Item Description],IMDBRN as [Item Brand],ProductGroupCode [Product Item Group] FROM Item WHERE ITEMDEL = 0 AND IsActive = 1")
    End Function
    Public Shared Function GetItemTargetSql() As String
        Return ("Select itemthr,itemthr [Item Code],ITEMMDES [Item Description],ITEMDIVCD [Item Division Code]   from Item")
    End Function
    Public Shared Function GetItemColumns() As String
        Return "ITEMCD; ITEMCD1; ITEMMDES;"
    End Function
    Public Shared Function GetItempricelist(ByVal ItemCode As String, ByVal CompanyCode As String, ByVal StartDate As Date) As String
        Return "Select DISTITEMPRICE  from DISTRIBUTORITEMS Where DISTITEMCD = '" & ItemCode & "' And Comid = '" & CompanyCode & "' AND ('" & StartDate & "' BETWEEN EffectivityStartDate And EffectivityEndDate AND IsActive = 1)"
    End Function
    Public Shared Function GetNewPriceItemSetup() As String
        Return "SELECT itemthr,ITEMMDES,IMDBRN FROM Item WHERE ITEMDEL = 0 AND IsActive = 1"
    End Function
    Public Shared Function GetItems(ByVal ItemCode As String) As String
        Return LoadByCode(ItemCode).ItemMMDES
    End Function
End Class
Public Class ItemCollection
    Inherits List(Of Items)
End Class

