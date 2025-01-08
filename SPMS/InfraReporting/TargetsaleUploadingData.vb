Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class TargetsaleUploadingData

    Private m_targetsaleID As Integer = -1

    Private m_Comid As String = String.Empty

    Private m_Territorycode As String = String.Empty

    Private m_EmployeeId As String = String.Empty

    Private m_EmployeeName As String = String.Empty

    Private m_Year As String = String.Empty

    Private m_Month As String = String.Empty

    Private m_Itemcode As String = String.Empty

    Private m_ItemName As String = String.Empty

    Private m_Quantity As String = String.Empty

    Private m_Sales As Integer = 0

    Public ReadOnly Property TargetSaleID() As Integer
        Get
            Return m_targetsaleID
        End Get
    End Property
    Public Property CompanyCode() As String
        Get
            Return m_Comid
        End Get
        Set(ByVal value As String)
            m_Comid = value
        End Set
    End Property
    Public Property EmployeeID() As String
        Get
            Return m_EmployeeId
        End Get
        Set(ByVal value As String)
            m_EmployeeId = value
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
    Public Property Year() As String
        Get
            Return m_Year
        End Get
        Set(ByVal value As String)
            m_Year = value
        End Set
    End Property
    Public Property Month() As String
        Get
            Return m_Month
        End Get
        Set(ByVal value As String)
            m_Month = value
        End Set
    End Property
    Public Property Quantity() As String
        Get
            Return m_Quantity
        End Get
        Set(ByVal value As String)
            m_Quantity = value
        End Set
    End Property
    Public Property Sales() As Integer
        Get
            Return m_Sales
        End Get
        Set(ByVal value As Integer)
            m_Sales = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As TargerSaleUploadingDataCollection
        Dim col As New TargerSaleUploadingDataCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_RawData As New TargetsaleUploadingData
            Dim row As DataRow = table.Rows(j)
            m_RawData.m_targetsaleID = row("TargetSalesID")
            m_RawData.m_Comid = row("Comid")
            m_RawData.m_EmployeeId = row("EmployeeID")
            m_RawData.m_EmployeeName = row("EmployeeName")
            m_RawData.m_Year = row("Year")
            m_RawData.m_Month = row("Month")
            m_RawData.m_Itemcode = row("ItemCode")
            m_RawData.m_ItemName = row("ItemName")
            m_RawData.m_Quantity = row("Quantity")
            m_RawData.m_Sales = row("Sales")
            col.Add(m_RawData)
        Next
        Return col
    End Function
    Public Shared Function Filter(ByVal Condition As String) As TargerSaleUploadingDataCollection
        Return BaseFilter(GetRecords("SELECT * FROM TargetSalesup " & IIf(Condition <> "", " WHERE " & Condition, "")))
    End Function
    Public Overloads Shared Function Load(ByVal TargetSaleID As Integer) As TargetsaleUploadingData
        Return Filter("TargerSaleID = " & TargetSaleID)(0)
    End Function
    Public Overloads Shared Function Load() As TargerSaleUploadingDataCollection
        Return Filter("")
    End Function
    Public Shared Function CheckIfRawDataExist(ByVal Month As String, ByVal Year As String) As Boolean
        Return ExecuteCommand("SELECT  *  FROM TargetsaleUploading Where Month >= '" & Month & "' AND <= '" & Month & "'  AND Year = '" & Year & "'")
    End Function
    Public Class TargerSaleUploadingDataCollection
        Inherits List(Of TargetsaleUploadingData)
    End Class
End Class
