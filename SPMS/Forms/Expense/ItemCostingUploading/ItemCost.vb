

Imports System.Data.SqlClient
Imports SPMSOPCI.ConnectionModule
Public Class ItemCost

    Dim m_ItemcostID As Integer = -1

    Dim m_ItemcodeID As Integer = -1

    Dim m_ItemcostCompanyCode As String = String.Empty

    Dim m_ItemCostMonth As String = String.Empty

    Dim m_ItemCostYear As String = String.Empty

    Dim m_ItemcostCHItemCode As String = String.Empty

    Dim m_ItemcostItemCode As String = String.Empty

    Dim m_ItemcostDescription As String = String.Empty

    Dim m_itemCostprice As Decimal = 0
    Public ReadOnly Property ItemcostsID() As Integer
        Get
            Return m_ItemcodeID
        End Get
    End Property
    Public Property ItemCostTC() As String
        Get
            Return m_ItemcostItemCode
        End Get
        Set(ByVal value As String)
            m_ItemcostItemCode = value
        End Set
    End Property

    Public Property ItemCostID() As Integer
        Get
            Return m_ItemcodeID
        End Get
        Set(ByVal value As Integer)
            m_ItemcodeID = value
        End Set
    End Property
    Public Property ItemcostCompanyCode() As String
        Get
            Return m_ItemcostCompanyCode
        End Get
        Set(ByVal value As String)
            m_ItemcostCompanyCode = value
        End Set
    End Property
    Public Property Month() As String
        Get
            Return m_ItemCostMonth
        End Get
        Set(ByVal value As String)
            m_ItemCostMonth = value
        End Set
    End Property
    Public Property Year() As String
        Get
            Return m_ItemCostYear
        End Get
        Set(ByVal value As String)
            m_ItemCostYear = value
        End Set
    End Property

    Public Property ChannelCodeItemCode() As String
        Get
            Return m_ItemcostCHItemCode
        End Get
        Set(ByVal value As String)
            m_ItemcostCHItemCode = value
        End Set
    End Property
    Public Property ItemcostDescription() As String
        Get
            Return m_ItemcostDescription
        End Get
        Set(ByVal value As String)
            m_ItemcostDescription = value
        End Set
    End Property
    Public Property ItemCostprice() As Decimal
        Get
            Return m_itemCostprice
        End Get
        Set(ByVal value As Decimal)
            m_itemCostprice = value
        End Set
    End Property

    Public Function Save() As Boolean
        Connect()
        Try
            Dim cmd As New SqlCommand("uspItemCostingDetails ", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Save")
            cmd.Parameters.AddWithValue("@ItemCostingDetailID", m_ItemcostID)
            cmd.Parameters.AddWithValue("@ItemCostingID", m_ItemcodeID)
            cmd.Parameters.AddWithValue("@ItemCode", m_ItemcostItemCode)
            cmd.Parameters.AddWithValue("@ChannelItemCode", m_ItemcostCHItemCode)
            cmd.Parameters.AddWithValue("@CHCompany", m_ItemcostCompanyCode)
            cmd.Parameters.AddWithValue("@Month", m_ItemCostMonth)
            cmd.Parameters.AddWithValue("@Year", m_ItemCostYear)
            cmd.Parameters.AddWithValue("@ItemDescription", m_ItemcostDescription)
            cmd.Parameters.AddWithValue("@Itemcost", m_itemCostprice)
            m_ItemcostID = cmd.ExecuteScalar()
            Disconnect()
            Return True
        Catch ex As Exception

        End Try
    End Function
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As ItemCostCollection
        Dim col As New ItemCostCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_ItemCosts As New ItemCost
            Dim row As DataRow = table.Rows(j)
            m_ItemCosts.m_ItemcodeID = row("ItemCostDetailID")
            m_ItemCosts.m_ItemcostID = row("ItemCostingID")
            m_ItemCosts.m_ItemcostItemCode = row("Itemcode")
            m_ItemCosts.m_ItemcostCHItemCode = row("ChannelItemCode")
            m_ItemCosts.m_ItemcostCHItemCode = row("CHCode")
            m_ItemCosts.m_ItemCostMonth = row("Month")
            m_ItemCosts.m_ItemCostYear = row("Year")
            m_ItemCosts.m_ItemcostDescription = row("ItemDescription")
            m_ItemCosts.m_itemCostprice = row("Itemcost")
            col.Add(m_ItemCosts)
        Next
        Return col
    End Function

    Public Shared Function Filter(ByVal Condition As String) As ItemCostCollection
        Return BaseFilter(GetRecords("SELECT * FROM ItemCostingDetails " & IIf(Condition <> "", " WHERE " & Condition, "")))
    End Function
    Public Shared Function CheckIfItemcostDataExist(ByVal CompanyCode As String, ByVal Month As String, ByVal Year As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM ItemCostingDetails  Where CHCode = '" & CompanyCode & "' AND Month = '" & Month & "' AND year = '" & Year & "'") = "A"
    End Function
    Public Shared Function DeleteExistIFItemcost(ByVal CompanyCode As String, ByVal Month As String, ByVal Year As String) As Boolean
        Return ExecuteCommand("DELETE FROM ItemCostingDetails  Where CHCode = '" & CompanyCode & "' AND Month = '" & Month & "' AND Year = '" & Year & "'")
    End Function
    Public Overloads Shared Function Load() As ItemCostCollection
        Return Filter("")
    End Function

    Public Overloads Shared Function Load(ByVal ItemCostID As Integer) As ItemCost
        Return Filter("ItemCostingDetailID = " & ItemCostID)(0)
    End Function
    Public Shared Function GetItemCostCompany(ByVal Companycode As String) As Boolean
        Return "select * from  ItemCostingDetails where CHCode = '" & Companycode & "'"
    End Function
End Class

Public Class ItemCostCollection
    Inherits List(Of ItemCost)
End Class
