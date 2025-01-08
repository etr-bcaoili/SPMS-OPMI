Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class IssuedItemTarget
    Private m_targetSalesID As Integer = -1

    Private m_Comidi As String = String.Empty

    Private m_TerretoryID As String = String.Empty

    Private m_EmployeeID As String = String.Empty

    Private m_EmployeeName As String = String.Empty

    Private m_ItemCodeDivision As String = String.Empty

    Private m_ItemCode As String = String.Empty

    Private m_ItemName As String = String.Empty

    Private m_CutYear As String = String.Empty

    Private m_ConfigtypeCode As String = String.Empty

    Private m_QT01 As Decimal = 0

    Private m_ST01 As Decimal = 0

    Private m_QT02 As Decimal = 0

    Private m_ST02 As Decimal = 0

    Private m_QT03 As Decimal = 0

    Private m_ST03 As Decimal = 0

    Private m_QT04 As Decimal = 0

    Private m_ST04 As Decimal = 0

    Private m_QT05 As Decimal = 0

    Private m_ST05 As Decimal = 0

    Private m_QT06 As Decimal = 0

    Private m_ST06 As Decimal = 0

    Private m_QT07 As Decimal = 0

    Private m_ST07 As Decimal = 0

    Private m_QT08 As Decimal = 0

    Private m_ST08 As Decimal = 0

    Private m_QT09 As Decimal = 0

    Private m_ST09 As Decimal = 0

    Private m_QT10 As Decimal = 0

    Private m_ST10 As Decimal = 0

    Private m_QT11 As Decimal = 0

    Private m_ST11 As Decimal = 0

    Private m_QT12 As Decimal = 0

    Private m_ST12 As Decimal = 0

    Public ReadOnly Property TargerSalesID() As Integer
        Get
            Return m_targetSalesID
        End Get
    End Property

    Public Property CompanyCode() As String
        Get
            Return m_Comidi
        End Get
        Set(ByVal value As String)
            m_Comidi = value
        End Set
    End Property
    Public Property TerretoryCode() As String
        Get
            Return m_TerretoryID
        End Get
        Set(ByVal value As String)
            m_TerretoryID = value
        End Set
    End Property
    Public Property EmployeeID() As String
        Get
            Return m_EmployeeID
        End Get
        Set(ByVal value As String)
            m_EmployeeID = value
        End Set
    End Property
    Public Property EmployeeName() As String
        Get
            Return m_EmployeeName
        End Get
        Set(ByVal value As String)
            m_EmployeeName = value
        End Set
    End Property
    Public Property ItemCodeDivision() As String
        Get
            Return m_ItemCodeDivision
        End Get
        Set(ByVal value As String)
            m_ItemCodeDivision = value
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

    Public Property ItemName() As String
        Get
            Return m_ItemName
        End Get
        Set(ByVal value As String)
            m_ItemName = value
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
    Public Property ConfigtypeCode() As String
        Get
            Return m_ConfigtypeCode
        End Get
        Set(ByVal value As String)
            m_ConfigtypeCode = value
        End Set
    End Property
    Public Property QuantityTagetJanuary() As Decimal
        Get
            Return m_QT01
        End Get
        Set(ByVal value As Decimal)
            m_QT01 = value
        End Set
    End Property
    Public Property SalesTargetJanuary() As Decimal
        Get
            Return m_ST01
        End Get
        Set(ByVal value As Decimal)
            m_ST01 = value
        End Set
    End Property
    Public Property QuantitytargetFebrary() As Decimal
        Get
            Return m_QT02
        End Get
        Set(ByVal value As Decimal)
            m_QT02 = value
        End Set
    End Property
    Public Property SalesTargetFebrary() As Decimal
        Get
            Return m_ST02
        End Get
        Set(ByVal value As Decimal)
            m_ST02 = value
        End Set
    End Property
    Public Property QuantityTagetMarch() As Decimal
        Get
            Return m_QT03
        End Get
        Set(ByVal value As Decimal)
            m_QT03 = value
        End Set
    End Property
    Public Property SaleTagetMarch() As Decimal
        Get
            Return m_ST03
        End Get
        Set(ByVal value As Decimal)
            m_ST03 = value
        End Set
    End Property
    Public Property QuantityTargetApril() As Decimal
        Get
            Return m_QT04
        End Get
        Set(ByVal value As Decimal)
            m_QT04 = value
        End Set
    End Property
    Public Property SaleTargerApril() As Decimal
        Get
            Return m_ST04
        End Get
        Set(ByVal value As Decimal)
            m_ST04 = value
        End Set
    End Property
    Public Property QuantityTargetMay() As Decimal
        Get
            Return m_QT05
        End Get
        Set(ByVal value As Decimal)
            m_QT05 = value
        End Set
    End Property
    Public Property SaleTargetMay() As Decimal
        Get
            Return m_ST05
        End Get
        Set(ByVal value As Decimal)
            m_ST05 = value
        End Set
    End Property
    Public Property QuantityTargerJune() As Decimal
        Get
            Return m_QT06
        End Get
        Set(ByVal value As Decimal)
            m_QT06 = value
        End Set
    End Property
    Public Property SaleTargetJune() As Decimal
        Get
            Return m_ST06
        End Get
        Set(ByVal value As Decimal)
            m_ST06 = value
        End Set
    End Property
    Public Property QuantityTargetJuly() As Decimal
        Get
            Return m_QT07
        End Get
        Set(ByVal value As Decimal)
            m_QT07 = value
        End Set
    End Property
    Public Property SalesTargetJuly() As Decimal
        Get
            Return m_ST07
        End Get
        Set(ByVal value As Decimal)
            m_ST07 = value
        End Set
    End Property
    Public Property QuantityTargetAugust() As Decimal
        Get
            Return m_QT08
        End Get
        Set(ByVal value As Decimal)
            m_QT08 = value
        End Set
    End Property
    Public Property SaleTargetAugust() As Decimal
        Get
            Return m_ST08
        End Get
        Set(ByVal value As Decimal)
            m_ST08 = value
        End Set
    End Property
    Public Property QuantityTargetSeptember() As Decimal
        Get
            Return m_QT09
        End Get
        Set(ByVal value As Decimal)
            m_QT09 = value
        End Set
    End Property
    Public Property SaleTargetSeptember() As Decimal
        Get
            Return m_ST09
        End Get
        Set(ByVal value As Decimal)
            m_ST09 = value
        End Set
    End Property
    Public Property QuantityTargetOctober() As Decimal
        Get
            Return m_QT10
        End Get
        Set(ByVal value As Decimal)
            m_QT10 = value
        End Set
    End Property
    Public Property SaleTargetOctober() As Decimal
        Get
            Return m_ST10
        End Get
        Set(ByVal value As Decimal)
            m_ST10 = value
        End Set
    End Property
    Public Property QuantityTargetNovember() As Decimal
        Get
            Return m_QT11
        End Get
        Set(ByVal value As Decimal)
            m_QT11 = value
        End Set
    End Property
    Public Property SalesTargetNovember() As Decimal
        Get
            Return m_ST11
        End Get
        Set(ByVal value As Decimal)
            m_ST11 = value
        End Set
    End Property
    Public Property QuantityTargetDecember() As Decimal
        Get
            Return m_QT12
        End Get
        Set(ByVal value As Decimal)
            m_QT12 = value
        End Set
    End Property
    Public Property Salestragetdecember() As Decimal
        Get
            Return m_ST12
        End Get
        Set(ByVal value As Decimal)
            m_ST12 = value
        End Set
    End Property
    Public Function Save() As Boolean
        Connect()
        Try
            Dim cmd As New SqlCommand("uspIssuedItemTarget_Temp", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Save")
            cmd.Parameters.AddWithValue("@TargerSaleID", m_targetSalesID)
            cmd.Parameters.AddWithValue("@Comid", m_Comidi)
            cmd.Parameters.AddWithValue("@TerritoryCode", m_TerretoryID)
            cmd.Parameters.AddWithValue("@EmployeeID ", m_EmployeeID)
            cmd.Parameters.AddWithValue("@EmployeeName", m_EmployeeName)
            cmd.Parameters.AddWithValue("@ItemDivisionCode", m_ItemCodeDivision)
            cmd.Parameters.AddWithValue("@Itemcode", m_ItemCode)
            cmd.Parameters.AddWithValue("@ItemName", m_ItemName)
            cmd.Parameters.AddWithValue("@Year", m_CutYear)
            cmd.Parameters.AddWithValue("@ConfigtypeCode", m_ConfigtypeCode)
            cmd.Parameters.AddWithValue("@QT01", m_QT01)
            cmd.Parameters.AddWithValue("@ST01", m_ST01)
            cmd.Parameters.AddWithValue("@QT02", m_QT02)
            cmd.Parameters.AddWithValue("@ST02", m_ST02)
            cmd.Parameters.AddWithValue("@QT03", m_QT03)
            cmd.Parameters.AddWithValue("@ST03", m_ST03)
            cmd.Parameters.AddWithValue("@QT04", m_QT04)
            cmd.Parameters.AddWithValue("@ST04", m_ST04)
            cmd.Parameters.AddWithValue("@QT05", m_QT05)
            cmd.Parameters.AddWithValue("@ST05", m_ST05)
            cmd.Parameters.AddWithValue("@QT06", m_QT06)
            cmd.Parameters.AddWithValue("@ST06", m_ST06)
            cmd.Parameters.AddWithValue("@QT07", m_QT07)
            cmd.Parameters.AddWithValue("@ST07", m_ST07)
            cmd.Parameters.AddWithValue("@QT08", m_QT08)
            cmd.Parameters.AddWithValue("@ST08", m_ST08)
            cmd.Parameters.AddWithValue("@QT09", m_QT09)
            cmd.Parameters.AddWithValue("@ST09", m_ST09)
            cmd.Parameters.AddWithValue("@QT10", m_QT10)
            cmd.Parameters.AddWithValue("@ST10", m_ST10)
            cmd.Parameters.AddWithValue("@QT11", m_QT11)
            cmd.Parameters.AddWithValue("@ST11", m_ST11)
            cmd.Parameters.AddWithValue("@QT12", m_QT12)
            cmd.Parameters.AddWithValue("@ST12", m_ST12)


            m_targetSalesID = cmd.ExecuteScalar()
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

            Dim cmd As New SqlCommand("uspIssuedItemTarget_Temp", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Delete")
            cmd.Parameters.AddWithValue("@TargetSaleID", m_targetSalesID)
            cmd.ExecuteNonQuery()
            Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As IssuedItemTargetCollection
        Dim col As New IssuedItemTargetCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_RawData As New IssuedItemTarget
            Dim row As DataRow = table.Rows(j)
            m_RawData.m_targetSalesID = row("RawDataID")
            m_RawData.m_Comidi = row("CompanyCode")
            m_RawData.m_EmployeeID = row("BranchCode")
            m_RawData.m_EmployeeName = row("BranchName")
            m_RawData.m_ItemCodeDivision = row("ItemCodeDivision")
            m_RawData.m_ItemCode = row("CustomerNumber")
            m_RawData.m_ItemName = row("CustomerName")
            m_RawData.m_CutYear = row("CustomerAddress1")
            m_RawData.m_QT01 = row("CustomerAddress2")
            m_RawData.m_ST01 = row("TransactionDate")
            m_RawData.m_QT02 = row("InvoiceNumber")
            m_RawData.m_ST02 = row("TransactionType")
            m_RawData.m_QT03 = row("ItemNumber")
            m_RawData.m_ST03 = row("ItemDescription")
            m_RawData.m_QT04 = row("WarehouseNumber")
            m_RawData.m_ST04 = row("Class")
            m_RawData.m_QT05 = row("QuantitySold")
            m_RawData.m_ST05 = row("QuantityFree")
            m_RawData.m_QT06 = row("GrossAmount")
            m_RawData.m_ST06 = row("LineDiscount")
            m_RawData.m_QT07 = row("ProductDiscount")
            m_RawData.m_QT08 = row("VatCode")
            m_RawData.m_ST08 = row("Route")
            m_RawData.m_QT09 = row("Taxes")
            m_RawData.m_ST09 = row("Freight")
            m_RawData.m_QT10 = row("Additional")
            m_RawData.m_ST10 = row("NetAmount")
            m_RawData.m_QT11 = row("UnitPrice")
            m_RawData.m_ST11 = row("InvoiceReferenceNumber")
            m_RawData.m_QT12 = row("CMCode")
            m_RawData.m_ST12 = row("SONumber")
            col.Add(m_RawData)
        Next
        Return col
    End Function

    Public Shared Function Filter(ByVal Condition As String) As IssuedItemTargetCollection
        Return BaseFilter(GetRecords("SELECT * FROM IssuedTargetTemp " & IIf(Condition <> "", " WHERE " & Condition, "")))
    End Function

    Public Overloads Shared Function Load() As IssuedItemTargetCollection
        Return Filter("")
    End Function

    Public Overloads Shared Function Load(ByVal TargetSaleID As Integer) As IssuedItemTarget
        Return Filter("TargerSaleID = " & TargetSaleID)(0)
    End Function

    Public Shared Function CheckIfRawDataExist(ByVal Year As String, ByVal ConfigtypeCode As String) As Boolean
        Return ExecuteCommand("DELETE FROM IssuedItemTarget WHERE  Year = '" & Year & "' and ConfigTypeCode = '" & ConfigtypeCode & "'")
    End Function

    'Public Shared Function CheckIfDataExist(ByVal CompanyCode As String, ByVal Year As String, ByVal Month As String) As Boolean
    '    Return ExecuteCommand("SELECT 'A' FROM RawData Where CompanyCode = '" & CompanyCode & "' AND CutMo = " & Month & "' AND CutYear = '" & Year & "'") = "A"
    'End Function

    Public Shared Function DeleteExistRawData(ByVal CompanyCode As String) As Boolean
        Return ExecuteCommand("DELETE FROM IssuedtargetTemp Where Comid = '" & CompanyCode & "'")
    End Function

    Public Class IssuedItemTargetCollection
        Inherits List(Of IssuedItemTarget)
    End Class



End Class
