Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class RawData

    Private m_RawDataID As Integer = -1
    Private m_CompanyCode As String = String.Empty
    Private m_BranchCode As String = String.Empty
    Private m_BrachName As String = String.Empty
    Private m_CustomerNumber As String = String.Empty
    Private m_CustomerName As String = String.Empty
    Private m_CustomerAddress As String = String.Empty
    Private m_CustomerAddress2 As String = String.Empty
    Private m_TransactionDate As String = String.Empty
    Private m_InvoiceNumber As String = String.Empty
    Private m_InvoiceDate As String = String.Empty
    Private m_TransactionType As String = String.Empty
    Private m_ItemNumber As String = String.Empty
    Private m_ItemDescription As String = String.Empty
    Private m_WarehouseNumber As String = String.Empty
    Private m_Class As String = String.Empty
    Private m_QtySold As Decimal = 0
    Private m_QtyFree As Decimal = 0
    Private m_GrossAmount As Decimal = 0
    Private m_LineDiscount As Decimal = 0
    Private m_ProductDiscount As Decimal = 0
    Private m_VatCode As String = String.Empty
    Private m_Route As String = String.Empty
    Private m_Taxes As Decimal = 0
    Private m_Freight As Decimal = 0
    Private m_Additional As Decimal = 0
    Private m_NetAmount As Decimal = 0
    Private m_UnitPrice As Decimal = 0
    Private m_InvoiceReferenceNumber As Integer = -1
    Private m_CMCode As String = String.Empty
    Private m_SONumber As Integer = -1
    Private m_SODate As String = String.Empty
    Private m_SOTerms As String = String.Empty
    Private m_ExpiryDate As String = String.Empty
    Private m_LotNumber As String = String.Empty
    Private m_SalesmanNumber As String = String.Empty
    Private m_SalesmanName As String = String.Empty
    Private m_ShipToName As String = String.Empty
    Private m_ShipToAddress1 As String = String.Empty
    Private m_ShipToAddress2 As String = String.Empty
    Private m_ZipCode As String = String.Empty
    Private m_TerritoryNumber As String = String.Empty
    Private m_Area As String = String.Empty
    Private m_CustomerClass As String = String.Empty
    Private m_ClassName As String = String.Empty
    Private m_Principal As String = String.Empty
    Private m_SubPrincipal As String = String.Empty
    Private m_PrincipalDivisionCode As String = String.Empty
    Private m_SalesWeek As String = String.Empty
    Private m_CustomerDeliveryCode As String = String.Empty
    Private m_ListPriceTaxInclude As String = String.Empty
    Private m_ContractPrincipalApprovalNumber As String = String.Empty
    Private m_OrderType As String = String.Empty
    Private m_IsCode As String = String.Empty
    Private m_UploadDate As Date = "1/1/1900"
    Private m_CutMo As String = String.Empty
    Private m_CutYear As String = String.Empty
    Private m_Region As String = String.Empty
    Private m_UOM As String = String.Empty
    Private m_EffectivityStartDate As Date = "1/1/1900"
    Private m_EffectivityEndDate As Date = "1/1/1900"
    Private m_principalcode As String = String.Empty
    Private m_principalClass As String = String.Empty
    Private m_Address3 As String = String.Empty
    Private m_Address4 As String = String.Empty
    Private m_PaymentType As String = String.Empty
    Private m_PONumber As String = String.Empty
    Private dt As New DataTable
    Private dv As New DataView

    Public ReadOnly Property RawDataID() As Integer
        Get
            Return m_RawDataID
        End Get
    End Property
    Public Property CompanyCode() As String
        Get
            Return m_CompanyCode
        End Get
        Set(ByVal value As String)
            m_CompanyCode = value
        End Set
    End Property
    Public Property BranchCode() As String
        Get
            Return m_BranchCode
        End Get
        Set(ByVal value As String)
            m_BranchCode = value
        End Set
    End Property
    Public Property BranchName() As String
        Get
            Return m_BrachName
        End Get
        Set(ByVal value As String)
            m_BrachName = value
        End Set
    End Property
    Public Property CustomerNumber() As String
        Get
            Return m_CustomerNumber
        End Get
        Set(ByVal value As String)
            m_CustomerNumber = value
        End Set
    End Property
    Public Property CustomerName() As String
        Get
            Return m_CustomerName
        End Get
        Set(ByVal value As String)
            m_CustomerName = value
        End Set
    End Property
    Public Property CustomerAddress() As String
        Get
            Return m_CustomerAddress
        End Get
        Set(ByVal value As String)
            m_CustomerAddress = value
        End Set
    End Property
    Public Property CustomerAddress2() As String
        Get
            Return m_CustomerAddress2
        End Get
        Set(ByVal value As String)
            m_CustomerAddress2 = value
        End Set
    End Property
    Public Property TranscationDate() As String
        Get
            Return m_TransactionDate
        End Get
        Set(ByVal value As String)
            m_TransactionDate = value
        End Set
    End Property
    Public Property InvoiceNumber() As String
        Get
            Return m_InvoiceNumber
        End Get
        Set(ByVal value As String)
            m_InvoiceNumber = value
        End Set
    End Property
    Public Property InvoiceDate() As String
        Get
            Return m_InvoiceDate
        End Get
        Set(ByVal value As String)
            m_InvoiceDate = value
        End Set
    End Property
    Public Property TransactionType() As String
        Get
            Return m_TransactionType
        End Get
        Set(ByVal value As String)
            m_TransactionType = value
        End Set
    End Property
    Public Property ItemNumber() As String
        Get
            Return m_ItemNumber
        End Get
        Set(ByVal value As String)
            m_ItemNumber = value
        End Set
    End Property
    Public Property ItemDescription() As String
        Get
            Return m_ItemDescription
        End Get
        Set(ByVal value As String)
            m_ItemDescription = value
        End Set
    End Property
    Public Property WarehouseNumber() As String
        Get
            Return m_WarehouseNumber
        End Get
        Set(ByVal value As String)
            m_WarehouseNumber = value
        End Set
    End Property
    Public Property _Class() As String
        Get
            Return m_Class
        End Get
        Set(ByVal value As String)
            m_Class = value
        End Set
    End Property
    Public Property QuantitySold() As Decimal
        Get
            Return m_QtySold
        End Get
        Set(ByVal value As Decimal)
            m_QtySold = value
        End Set
    End Property
    Public Property QuantityFree() As String
        Get
            Return m_QtyFree
        End Get
        Set(ByVal value As String)
            m_QtyFree = value
        End Set
    End Property
    Public Property GrossAmount() As Decimal
        Get
            Return m_GrossAmount
        End Get
        Set(ByVal value As Decimal)
            m_GrossAmount = value
        End Set
    End Property
    Public Property LineDiscount() As Decimal
        Get
            Return m_LineDiscount
        End Get
        Set(ByVal value As Decimal)
            m_LineDiscount = value
        End Set
    End Property
    Public Property ProductDiscount() As Decimal
        Get
            Return m_ProductDiscount
        End Get
        Set(ByVal value As Decimal)
            m_ProductDiscount = value
        End Set
    End Property
    Public Property VatCode() As String
        Get
            Return m_VatCode
        End Get
        Set(ByVal value As String)
            m_VatCode = value
        End Set
    End Property
    Public Property Route() As String
        Get
            Return m_Route
        End Get
        Set(ByVal value As String)
            m_Route = value
        End Set
    End Property
    Public Property Taxes() As Decimal
        Get
            Return m_Taxes
        End Get
        Set(ByVal value As Decimal)
            m_Taxes = value
        End Set
    End Property
    Public Property Freight() As Decimal
        Get
            Return m_Freight
        End Get
        Set(ByVal value As Decimal)
            m_Freight = value
        End Set
    End Property
    Public Property Additional() As Decimal
        Get
            Return m_Additional
        End Get
        Set(ByVal value As Decimal)
            m_Additional = value
        End Set
    End Property
    Public Property NetAmount() As Decimal
        Get
            Return m_NetAmount
        End Get
        Set(ByVal value As Decimal)
            m_NetAmount = value
        End Set
    End Property
    Public Property UnitPrice() As Decimal
        Get
            Return m_UnitPrice
        End Get
        Set(ByVal value As Decimal)
            m_UnitPrice = value
        End Set
    End Property
    Public Property InvoiceReferenceNumber() As String
        Get
            Return m_InvoiceReferenceNumber
        End Get
        Set(ByVal value As String)
            m_InvoiceReferenceNumber = value
        End Set
    End Property
    Public Property CMCode() As String
        Get
            Return m_CMCode
        End Get
        Set(ByVal value As String)
            m_CMCode = value
        End Set
    End Property
    Public Property SONumber() As Integer
        Get
            Return m_SONumber
        End Get
        Set(ByVal value As Integer)
            m_SONumber = value
        End Set
    End Property
    Public Property SODate() As String
        Get
            Return m_SODate
        End Get
        Set(ByVal value As String)
            m_SODate = value
        End Set
    End Property
    Public Property SOTerms() As String
        Get
            Return m_SOTerms
        End Get
        Set(ByVal value As String)
            m_SOTerms = value
        End Set
    End Property
    Public Property ExpiryDate() As String
        Get
            Return m_ExpiryDate
        End Get
        Set(ByVal value As String)
            m_ExpiryDate = value
        End Set
    End Property
    Public Property LotNumber() As String
        Get
            Return m_LotNumber
        End Get
        Set(ByVal value As String)
            m_LotNumber = value
        End Set
    End Property
    Public Property SalesmanNumber() As String
        Get
            Return m_SalesmanNumber
        End Get
        Set(ByVal value As String)
            m_SalesmanNumber = value
        End Set
    End Property
    Public Property SalesmanName() As String
        Get
            Return m_SalesmanName
        End Get
        Set(ByVal value As String)
            m_SalesmanName = value
        End Set
    End Property
    Public Property ShipToName() As String
        Get
            Return m_ShipToName
        End Get
        Set(ByVal value As String)
            m_ShipToName = value
        End Set
    End Property
    Public Property ShipToAddress1() As String
        Get
            Return m_ShipToAddress1
        End Get
        Set(ByVal value As String)
            m_ShipToAddress1 = value
        End Set
    End Property
    Public Property ShipToAddress2() As String
        Get
            Return m_ShipToAddress2
        End Get
        Set(ByVal value As String)
            m_ShipToAddress2 = value
        End Set
    End Property
    Public Property Zipcode() As String
        Get
            Return m_ZipCode
        End Get
        Set(ByVal value As String)
            m_ZipCode = value
        End Set
    End Property
    Public Property TerritoryNumber() As String
        Get
            Return m_TerritoryNumber
        End Get
        Set(ByVal value As String)
            m_TerritoryNumber = value
        End Set
    End Property
    Public Property Area() As String
        Get
            Return m_Area
        End Get
        Set(ByVal value As String)
            m_Area = value
        End Set
    End Property
    Public Property CustomerClass() As String
        Get
            Return m_CustomerClass
        End Get
        Set(ByVal value As String)
            m_CustomerClass = value
        End Set
    End Property
    Public Property ClassName() As String
        Get
            Return m_ClassName
        End Get
        Set(ByVal value As String)
            m_ClassName = value
        End Set
    End Property
    Public Property Principal() As String
        Get
            Return m_Principal
        End Get
        Set(ByVal value As String)
            m_Principal = value
        End Set
    End Property
    Public Property SubPrincipal() As String
        Get
            Return m_SubPrincipal
        End Get
        Set(ByVal value As String)
            m_SubPrincipal = value
        End Set
    End Property
    Public Property PrincipalDivisionCode() As String
        Get
            Return m_PrincipalDivisionCode
        End Get
        Set(ByVal value As String)
            m_PrincipalDivisionCode = value
        End Set
    End Property
    Public Property SalesWeek() As String
        Get
            Return m_SalesWeek
        End Get
        Set(ByVal value As String)
            m_SalesWeek = value
        End Set
    End Property
    Public Property CustomerDeliveryCode() As String
        Get
            Return m_CustomerDeliveryCode
        End Get
        Set(ByVal value As String)
            m_CustomerDeliveryCode = value
        End Set
    End Property
    Public Property ListOfTaxIncluse() As String
        Get
            Return m_ListPriceTaxInclude
        End Get
        Set(ByVal value As String)
            m_ListPriceTaxInclude = value
        End Set
    End Property
    Public Property ContractPrincipalApprovalNumber() As String
        Get
            Return m_ContractPrincipalApprovalNumber
        End Get
        Set(ByVal value As String)
            m_ContractPrincipalApprovalNumber = value
        End Set
    End Property
    Public Property OrderType() As String
        Get
            Return m_OrderType
        End Get
        Set(ByVal value As String)
            m_OrderType = value
        End Set
    End Property
    Public Property IsCode() As String
        Get
            Return m_IsCode
        End Get
        Set(ByVal value As String)
            m_IsCode = value
        End Set
    End Property
    Public Property CutMO() As String
        Get
            Return m_CutMo
        End Get
        Set(ByVal value As String)
            m_CutMo = value
        End Set
    End Property
    Public Property CutYear() As String
        Get
            Return m_CutYear
        End Get
        Set(ByVal value As String)
            m_CutYear = value
        End Set
    End Property
    Public Property Region() As String
        Get
            Return m_Region
        End Get
        Set(ByVal value As String)
            m_Region = value
        End Set
    End Property
    Public Property UnitOfMesurement() As String
        Get
            Return m_UOM
        End Get
        Set(ByVal value As String)
            m_UOM = value
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
    Public Property PrincipalCode() As String
        Get
            Return m_principalcode
        End Get
        Set(ByVal value As String)
            m_principalcode = value
        End Set
    End Property
    Public Property PricipalClass() As String
        Get
            Return m_principalClass
        End Get
        Set(ByVal value As String)
            m_principalClass = value
        End Set
    End Property
    Public Property Address3() As String
        Get
            Return m_Address3
        End Get
        Set(ByVal value As String)
            m_Address3 = value
        End Set
    End Property
    Public Property Address4() As String
        Get
            Return m_Address4
        End Get
        Set(ByVal value As String)
            m_Address4 = value
        End Set
    End Property
    Public Property PaymentType() As String
        Get
            Return m_PaymentType
        End Get
        Set(ByVal value As String)
            m_PaymentType = value
        End Set
    End Property

    Public Property PONumber() As String
        Get
            Return m_PONumber
        End Get
        Set(ByVal value As String)
            m_PONumber = value
        End Set
    End Property
    Public Function Save() As Boolean
        Connect()
        Try
            Dim cmd As New SqlCommand("uspRawData", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Save")
            cmd.Parameters.AddWithValue("@RawDataID", m_RawDataID)
            cmd.Parameters.AddWithValue("@CompanyCode", m_CompanyCode)
            cmd.Parameters.AddWithValue("@BranchCode", m_BranchCode)
            cmd.Parameters.AddWithValue("@BranchName", m_BrachName)
            cmd.Parameters.AddWithValue("@CustomerNumber", m_CustomerNumber)
            cmd.Parameters.AddWithValue("@CustomerName", m_CustomerName)
            cmd.Parameters.AddWithValue("@CustomerAddress1", m_CustomerAddress)
            cmd.Parameters.AddWithValue("@CustomerAddress2", m_CustomerAddress2)
            cmd.Parameters.AddWithValue("@TransactionDate", m_TransactionDate)
            cmd.Parameters.AddWithValue("@InvoiceNumber", m_InvoiceNumber)
            cmd.Parameters.AddWithValue("@TransactionType", m_TransactionType)
            cmd.Parameters.AddWithValue("@ItemNumber", m_ItemNumber)
            cmd.Parameters.AddWithValue("@ItemDescription", m_ItemDescription)
            cmd.Parameters.AddWithValue("@WarehouseNumber", m_WarehouseNumber)
            cmd.Parameters.AddWithValue("@Class", m_Class)
            cmd.Parameters.AddWithValue("@QuantitySold", m_QtySold)
            cmd.Parameters.AddWithValue("@QuantityFree", m_QtyFree)
            cmd.Parameters.AddWithValue("@GrossAmount", m_GrossAmount)
            cmd.Parameters.AddWithValue("@LineDiscount", m_LineDiscount)
            cmd.Parameters.AddWithValue("@ProductDiscount", m_ProductDiscount)
            cmd.Parameters.AddWithValue("@VatCode", m_VatCode)
            cmd.Parameters.AddWithValue("@Route", m_Route)
            cmd.Parameters.AddWithValue("@Taxes", m_Taxes)
            cmd.Parameters.AddWithValue("@Freight", m_Freight)
            cmd.Parameters.AddWithValue("@Additional", m_Additional)
            cmd.Parameters.AddWithValue("@NetAmount", m_NetAmount)
            cmd.Parameters.AddWithValue("@UnitPrice", m_UnitPrice)
            cmd.Parameters.AddWithValue("@InvoiceReferenceNumber", m_InvoiceReferenceNumber)
            cmd.Parameters.AddWithValue("@CMCode", m_CMCode)
            cmd.Parameters.AddWithValue("@SONumber", m_SONumber)
            cmd.Parameters.AddWithValue("@SODate", m_SODate)
            cmd.Parameters.AddWithValue("@SOTerms", m_SOTerms)
            cmd.Parameters.AddWithValue("@ExpiryDate", m_ExpiryDate)
            cmd.Parameters.AddWithValue("@LotNumber", m_LotNumber)
            cmd.Parameters.AddWithValue("@SalesmanName", m_SalesmanName)
            cmd.Parameters.AddWithValue("@SalesmanNumber", m_SalesmanNumber)
            cmd.Parameters.AddWithValue("@ShipToName", m_ShipToName)
            cmd.Parameters.AddWithValue("@ShipToAddress1", m_ShipToAddress1)
            cmd.Parameters.AddWithValue("@ShipToAddress2", m_ShipToAddress2)
            cmd.Parameters.AddWithValue("@ZipCode", m_ZipCode)
            cmd.Parameters.AddWithValue("@TerritoryNumber", m_TerritoryNumber)
            cmd.Parameters.AddWithValue("@Area", m_Area)
            cmd.Parameters.AddWithValue("@CustomerClass", m_CustomerClass)
            cmd.Parameters.AddWithValue("@ClassName", m_ClassName)
            cmd.Parameters.AddWithValue("@Principal", m_Principal)
            cmd.Parameters.AddWithValue("@SubPrincipal", m_SubPrincipal)
            cmd.Parameters.AddWithValue("@PrincipalDivisionCode", m_PrincipalDivisionCode)
            cmd.Parameters.AddWithValue("@SalesWeek", m_SalesWeek)
            cmd.Parameters.AddWithValue("@CustomerDeliveryCode", m_CustomerDeliveryCode)
            cmd.Parameters.AddWithValue("@ListPriceTaxInclude", m_ListPriceTaxInclude)
            cmd.Parameters.AddWithValue("@ContractPrincipalApprovalNumber", m_ContractPrincipalApprovalNumber)
            cmd.Parameters.AddWithValue("@OrderType", m_OrderType)
            cmd.Parameters.AddWithValue("@IsCode", m_IsCode)
            cmd.Parameters.AddWithValue("@CutMo", m_CutMo)
            cmd.Parameters.AddWithValue("@CutYear", m_CutYear)
            cmd.Parameters.AddWithValue("@Region", m_Region)
            cmd.Parameters.AddWithValue("@EffectivityStartDate", m_EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EffectivityEndDate", m_EffectivityEndDate)
            m_RawDataID = cmd.ExecuteScalar()
            Disconnect()
            Return True
        Catch ex As System.Exception
            Disconnect()
            Throw
        End Try
    End Function

    Public Function Delete() As Boolean
        Connect()
        Try
            Dim cmd As New SqlCommand("uspRawData", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Delete")
            cmd.Parameters.AddWithValue("@RawDataID", m_RawDataID)
            cmd.Parameters.AddWithValue("@CutMo", m_CutMo)
            cmd.Parameters.AddWithValue("@CutYear", m_CutYear)
            cmd.ExecuteNonQuery()
            Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function

    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As RawDataCollection
        Dim col As New RawDataCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_RawData As New RawData
            Dim row As DataRow = table.Rows(j)
            m_RawData.m_RawDataID = row("RawDataID")
            m_RawData.m_CompanyCode = row("CompanyCode")
            m_RawData.m_BranchCode = row("BranchCode")
            m_RawData.m_BrachName = row("BranchName")
            m_RawData.m_CustomerNumber = row("CustomerNumber")
            m_RawData.m_CustomerName = row("CustomerName")
            m_RawData.m_CustomerAddress = row("CustomerAddress1")
            m_RawData.m_CustomerAddress2 = row("CustomerAddress2")
            m_RawData.m_TransactionDate = row("TransactionDate")
            m_RawData.m_InvoiceNumber = row("InvoiceNumber")
            m_RawData.m_InvoiceDate = row("InvoiceDate")
            m_RawData.m_TransactionType = row("TransactionType")
            m_RawData.m_ItemNumber = row("ItemNumber")
            m_RawData.m_ItemDescription = row("ItemDescription")
            m_RawData.m_WarehouseNumber = row("WarehouseNumber")
            m_RawData.m_Class = row("Class")
            m_RawData.m_QtySold = row("QuantitySold")
            m_RawData.m_QtyFree = row("QuantityFree")
            m_RawData.m_GrossAmount = row("GrossAmount")
            m_RawData.m_LineDiscount = row("LineDiscount")
            m_RawData.m_ProductDiscount = row("ProductDiscount")
            m_RawData.m_VatCode = row("VatCode")
            m_RawData.m_Route = row("Route")
            m_RawData.m_Taxes = row("Taxes")
            m_RawData.m_Freight = row("Freight")
            m_RawData.m_Additional = row("Additional")
            m_RawData.m_NetAmount = row("NetAmount")
            m_RawData.m_UnitPrice = row("UnitPrice")
            m_RawData.m_InvoiceReferenceNumber = row("InvoiceReferenceNumber")
            m_RawData.m_CMCode = row("CMCode")
            m_RawData.m_SONumber = row("SONumber")
            m_RawData.m_SODate = row("SODate")
            m_RawData.m_SOTerms = row("SOTerms")
            m_RawData.m_ExpiryDate = row("ExpiryDate")
            m_RawData.m_LotNumber = row("LotNumber")
            m_RawData.m_SalesmanName = row("SalesmanName")
            m_RawData.m_SalesmanNumber = row("SalesmanNumber")
            m_RawData.m_ShipToName = row("ShipToName")
            m_RawData.m_ShipToAddress1 = row("ShipToAddress1")
            m_RawData.m_ShipToAddress2 = row("ShipToAddress2")
            m_RawData.m_ZipCode = row("ZipCode")
            m_RawData.m_TerritoryNumber = row("TerritoryNumber")
            m_RawData.m_Area = row("Area")
            m_RawData.m_CustomerClass = row("CustomerClass")
            m_RawData.m_ClassName = row("ClassName")
            m_RawData.m_Principal = row("Principal")
            m_RawData.m_SubPrincipal = row("SubPrincipal")
            m_RawData.m_PrincipalDivisionCode = row("PrincipalDivisionCode")
            m_RawData.m_SalesWeek = row("SalesWeek")
            m_RawData.m_CustomerDeliveryCode = row("CustomerDeliveryCode")
            m_RawData.m_ListPriceTaxInclude = row("ListPriceTaxInclude")
            m_RawData.m_ContractPrincipalApprovalNumber = row("ContractPrincipalApprovalNumber")
            m_RawData.m_OrderType = row("OrderType")
            m_RawData.m_IsCode = row("IsCode")
            m_RawData.m_CutMo = row("CutMo")
            m_RawData.m_CutYear = row("CutYear")
            m_RawData.m_Region = row("Region")
            m_RawData.m_UOM = row("UnitOfMesurement")
            m_RawData.m_EffectivityStartDate = row("EffectivityStartDate")
            m_RawData.m_EffectivityEndDate = row("EffectivityEndDate")
            m_RawData.m_principalcode = row("PrincipalCode")
            m_RawData.m_principalClass = row("Principalclass")
            m_RawData.m_Address3 = row("Address3")
            m_RawData.m_Address4 = row("Address4")
            'm_RawData.m_PaymentType = row("PaymentType")
            'm_RawData.m_PONumber = row("PONumber")
            col.Add(m_RawData)
        Next
        Return col
    End Function

    Public Shared Function Filter(ByVal Condition As String) As RawDataCollection
        Return BaseFilter(GetRecords("SELECT * FROM RawData " & IIf(Condition <> "", " WHERE " & Condition, "")))
    End Function

    Public Overloads Shared Function Load() As RawDataCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal RawDataID As Integer) As RawData
        Return Filter("RawDataID = " & RawDataID)(0)
    End Function

    Public Shared Function CheckIfRawDataExist(ByVal CompanyCode As String, ByVal Year As String, ByVal Month As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM RawData Where CompanyCode = '" & CompanyCode & "' AND CutMo = '" & Month & "' AND CutYear = '" & Year & "'") = "A"
    End Function

    Public Shared Function DeleteExistRawData(ByVal CompanyCode As String, ByVal Year As String, ByVal Month As String) As Boolean
        Return ExecuteCommand("DELETE FROM RawData Where CompanyCode = '" & CompanyCode & "' AND CutMo = '" & Month & "' AND CutYear = '" & Year & "'")
    End Function
    Public Function GetData(ByVal CompCode As String, ByVal CutMo As Integer, ByVal CutYear As Integer, ByVal CNum As String) As RawDataCollection
        Dim rcollect As New RawDataCollection
        Dim rtable As New DataTable
        Dim command As New SqlCommand
        Dim dataadapter As New SqlDataAdapter
        Dim scom As New SqlCommand
        Try
            Connect()
            command = New SqlCommand("uspForRebatesTagging", SPMSConn2)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("CompanyCode", CompCode)
            command.Parameters.AddWithValue("CutMo", CutMo)
            command.Parameters.AddWithValue("CutYear", CutYear)
            command.ExecuteNonQuery()
            dataadapter = New SqlDataAdapter(command)
            dataadapter.Fill(rtable)
            rcollect = BaseFilter(rtable)
            Disconnect()
        Catch ex As Exception
        End Try
        Return rcollect
    End Function
    Public Shared Function UpdateGetConversion(ByVal Year As String, ByVal Month As String, ByVal CompanyCode As String) As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspConversionItemPerChannelInRawData", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Year", Year)
            cmd.Parameters.AddWithValue("@Month", Month)
            cmd.Parameters.AddWithValue("@CompanyCode", CompanyCode)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function

    Public Shared Function GetNumberofRecord(ByVal CompanyCode As String, ByVal Year As String, ByVal Month As String) As String
        Return "SELECT COUNT(CompanyCode) [Counts] FROM Rawdata WHERE CUTMO = '" & Month & "' AND CUTYEAR = '" & Year & "' AND CompanyCode = '" & CompanyCode & "'"
    End Function
    Public Shared Function GetTotalQty(ByVal CompanyCode As String, ByVal Year As String, ByVal Month As String) As String
        Return "SELECT SUM(QuantitySold) [TotalQty] FROM Rawdata WHERE CUTMO = '" & Month & "' AND CUTYEAR = '" & Year & "' AND CompanyCode = '" & CompanyCode & "'"
    End Function
    Public Shared Function GetTotalNetAmount(ByVal CompanyCode As String, ByVal Year As String, ByVal Month As String) As String
        Return "SELECT SUM(NetAmount) [TotalNetAmount] FROM Rawdata WHERE CUTMO = '" & Month & "' AND CUTYEAR = '" & Year & "' AND CompanyCode = '" & CompanyCode & "'"
    End Function
    Public Shared Function GetDateTimeUpload(ByVal CompanyCode As String, ByVal Year As String, ByVal Month As String) As String
        Return "SELECT Distinct convert(varchar, UploadDate, 101) [UploadDateTime] FROM Rawdata WHERE CUTMO = '" & Month & "' AND CUTYEAR = '" & Year & "' AND CompanyCode = '" & CompanyCode & "'"
    End Function
    Public Shared Function GetDoctorNameDetails(ByVal CompanyCode As String, ByVal Year As String, ByVal Month As String, ByVal DoctorName As String) As String
        Return "SELECT"
    End Function

End Class

Public Class RawDataCollection
    Inherits List(Of RawData)
End Class
