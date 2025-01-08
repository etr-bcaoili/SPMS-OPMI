Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class Target
    Private m_TerritoryID As Integer = -1

    Private m_CompanyCode As String = String.Empty

    Private m_TerritoryCode As String = String.Empty

    Private m_Year As Integer = -1

    Private m_Month As Integer = -1

    Private m_ItemDivisionCode As String = String.Empty

    Private m_ItemCode As String = String.Empty

    Private m_ItemName As String = String.Empty

    Private m_Qty As Decimal = 0

    Private m_SaleAmount As Decimal = 0

    Private m_EmployeeCode As String = String.Empty

    Private m_EmployeeName As String = String.Empty

    Private m_Config As String = String.Empty
    Public ReadOnly Property ID As Integer
        Get
            Return m_TerritoryID
        End Get
    End Property
    Public Property CompanyCode As String
        Get
            Return m_CompanyCode
        End Get
        Set(value As String)
            m_CompanyCode = value
        End Set
    End Property

    Public Property TerritoryCode As String
        Get
            Return m_TerritoryCode
        End Get
        Set(value As String)
            m_TerritoryCode = value
        End Set
    End Property

    Public Property Year As Integer
        Get
            Return m_Year
        End Get
        Set(value As Integer)
            m_Year = value
        End Set
    End Property

    Public Property Month As Integer
        Get
            Return m_Month
        End Get
        Set(value As Integer)
            m_Month = value
        End Set
    End Property

    Public Property ItemDivisionCode As String
        Get
            Return m_ItemDivisionCode
        End Get
        Set(value As String)
            m_ItemDivisionCode = value
        End Set
    End Property

    Public Property ItemCode As String
        Get
            Return m_ItemCode
        End Get
        Set(value As String)
            m_ItemCode = value
        End Set
    End Property
    Public Property ItemName As String
        Get
            Return m_ItemName
        End Get
        Set(value As String)
            m_ItemName = value
        End Set
    End Property
    Public Property Qty As Decimal
        Get
            Return m_Qty
        End Get
        Set(value As Decimal)
            m_Qty = value
        End Set
    End Property
    Public Property SaleAmount As Decimal
        Get
            Return m_SaleAmount
        End Get
        Set(value As Decimal)
            m_SaleAmount = value
        End Set
    End Property

    Public Property EmployeeCode As String
        Get
            Return m_EmployeeCode
        End Get
        Set(value As String)
            m_EmployeeCode = value
        End Set
    End Property
    Public Property EmployeeName As String
        Get
            Return m_EmployeeName
        End Get
        Set(value As String)
            m_EmployeeName = value
        End Set
    End Property
    Public Property Config As String
        Get
            Return m_Config
        End Get
        Set(value As String)
            m_Config = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As TargetCollection
        Dim col As New TargetCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_TargetCollection As New Target
            Dim row As DataRow = table.Rows(j)
            m_TargetCollection.m_TerritoryID = row("TerritoryItemTargetID")
            m_TargetCollection.m_CompanyCode = row("ComID")
            m_TargetCollection.m_Year = row("YEAR")
            m_TargetCollection.m_Month = row("MONTH")
            m_TargetCollection.m_ItemDivisionCode = row("ItemDivisionCode")
            m_TargetCollection.m_ItemCode = row("ITEMCD")
            m_TargetCollection.m_ItemName = row("ItemName")
            m_TargetCollection.m_Qty = row("Quantity")
            m_TargetCollection.m_SaleAmount = row("SalesTarget")
            m_TargetCollection.m_TerritoryCode = row("STTERRCD")
            m_TargetCollection.m_EmployeeCode = row("EmployeeCode")
            m_TargetCollection.m_EmployeeName = row("EmployeeName")
            m_TargetCollection.m_Config = row("ConfigTypeCode")
            col.Add(m_TargetCollection)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspTerritoryItemTarget", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@ComID", m_TerritoryID)
            cmd.Parameters.AddWithValue("@STTERRCD", m_TerritoryCode)
            cmd.Parameters.AddWithValue("@YEAR", m_Year)
            cmd.Parameters.AddWithValue("@MONTH", m_Month)
            cmd.Parameters.AddWithValue("@ITEMCD", m_ItemCode)
            cmd.Parameters.AddWithValue("@ITEMDIVISIONCODE", m_ItemDivisionCode)
            cmd.Parameters.AddWithValue("@Quantity", m_Qty)
            cmd.Parameters.AddWithValue("@Amount", "0.00")
            cmd.Parameters.AddWithValue("@SalesTarget", m_SaleAmount)
            cmd.Parameters.AddWithValue("@EmployeeCode", m_EmployeeCode)
            cmd.Parameters.AddWithValue("@EmployeeName", m_EmployeeName)
            cmd.Parameters.AddWithValue("@IsActive", True)
            m_TerritoryID = cmd.ExecuteScalar()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function

    Public Shared Function Filter(ByVal Condition As String) As TargetCollection
        Return BaseFilter(GetRecords("SELECT * FROM TerritoryItemTarget  WHERE DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function

    Public Overloads Shared Function Load() As TargetCollection
        Return Filter("")
    End Function

    Public Overloads Shared Function Load(ByVal TerritoryItemTargetID As Integer) As Target
        Return Filter("TerritoryItemTargetID = " & TerritoryItemTargetID)(0)
    End Function

    Public Shared Function LoadByCode(ByVal DISTCOMID As String) As Target
        Return Filter("DISTCOMID = '" & RefineSQL(DISTCOMID) & "'")(0)
    End Function
    Public Shared Function CheckofTargetAlreadyExist(ByVal Code As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM TerritoryItemTarget WHERE DLTFLG = 0 AND  DISTCOMID = '" & RefineSQL(Code) & "' AND DISTRIBUTORID <> " & ID) = "A"
    End Function
    Public Shared Function GetConfigurationSql() As String
        Return "Select ConfigTypeID,ConfigTypeCode,ConfigTypeName From ConfigurationType Order by ConfigTypeCode"
    End Function
    Public Shared Function GetTargetSql(Optional ByVal CustomerGroup As String = "") As String
        Return "SELECT DISTRIBUTORID, DISTCOMID [Company Code], DISTNAME [Description] FROM TerritoryItemTarget Where DLTFLG = 0 "
    End Function

    Public Shared Function GetTargetCollection(ByVal ItemCode As String, ByVal ItemDivisionCode As String, ByVal ConfigCode As String) As String
        Return "Select Distinct EmployeeCode [TM Code],EmployeeName [TM Name] From TerritoryItemTarget Where ConfigTypeCode = '" & ConfigCode & "' And Itemcd = '" & ItemCode & "' And ItemDivisionCode = '" & ItemDivisionCode & "'"
    End Function
    Public Shared Function GetSalesMatrixCollection(ByVal ItemDivisionCode As String, ByVal ConfigCode As String) As String
        Return "Select Distinct STSLSMNCD,STSLSMNNAME from SalesMatrix Where Configtypecode = '" & ConfigCode & "' AND STITMDIVCD = '" & ItemDivisionCode & "'"
    End Function

    Public Shared Function GetTargetColumns() As String
        Return "DISTRIBUTORID; [Company Code]; [Description];"
    End Function
End Class
Public Class TargetCollection
    Inherits List(Of Target)
End Class
