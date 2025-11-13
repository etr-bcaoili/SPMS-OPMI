Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports SPMSOPCI.ConnectionModule

Public Class SalesMatrixs

    Private m_SaleMatrixID As Integer = -1

    Private m_DLTFLG As String = String.Empty

    Private m_ExpenseDate As Date = "1/1/1900"

    Private m_STRREGCD As String = String.Empty

    Private m_STDISTRCTCD As String = String.Empty

    Private m_STTEAMCD As String = String.Empty

    Private m_STITMDIVCD As String = String.Empty

    Private m_STTERRCD As String = String.Empty

    Private m_STACOVD As String = String.Empty

    Private m_STACOVNAME As String = String.Empty

    Private m_CRTDATE As Date = "1/1/1900"

    Private m_STSLSMNCD As String = String.Empty

    Private m_LastModifiedDate As Date = "1/1/1900"

    Private m_STSLSMNNAME As String = String.Empty

    Private m_UploadDate As Date = "1/1/1900"

    Private m_EffictivityStartDate As Date = "1/1/1900"

    Private m_EffictivityEndDate As Date = "1/1/1900"

    Private m_ConfigTypeCode As String = String.Empty

    Private m_ItemgroupproductCode As String = String.Empty

    Private m_IsActive As Boolean = True


    Public Property DLFLG() As String
        Get
            Return m_DLTFLG
        End Get
        Set(ByVal value As String)
            m_DLTFLG = value
        End Set
    End Property
    Public Property SalesAreacode() As String
        Get
            Return m_STRREGCD
        End Get
        Set(ByVal value As String)
            m_STRREGCD = value
        End Set
    End Property

    Public Property SalesDistrictCode() As String
        Get
            Return m_STDISTRCTCD
        End Get
        Set(ByVal value As String)
            m_STDISTRCTCD = value
        End Set
    End Property
    Public Property SalesTeamCode() As String
        Get
            Return m_STTEAMCD
        End Get
        Set(ByVal value As String)
            m_STTEAMCD = value
        End Set
    End Property
    Public Property SalesTerritoryDivision() As String
        Get
            Return m_STITMDIVCD
        End Get
        Set(ByVal value As String)
            m_STITMDIVCD = value
        End Set
    End Property
    Public Property SalesTerritoryCodeas() As String
        Get
            Return m_STTERRCD
        End Get
        Set(ByVal value As String)
            m_STTERRCD = value
        End Set
    End Property
    Public Property SalesDivisionCode() As String
        Get
            Return m_STITMDIVCD
        End Get
        Set(ByVal value As String)
            m_STITMDIVCD = value
        End Set
    End Property
    Public Property SalesTerritoryName As String
        Get
            Return m_STACOVNAME
        End Get
        Set(ByVal value As String)
            m_STACOVNAME = value
        End Set
    End Property

    Public Property SalesmanCode() As String
        Get
            Return m_STSLSMNCD
        End Get
        Set(ByVal value As String)
            m_STSLSMNCD = value
        End Set
    End Property
    Public Property SalesmanName() As String
        Get
            Return m_STSLSMNNAME
        End Get
        Set(ByVal value As String)
            m_STSLSMNNAME = value
        End Set
    End Property
    Public Property CreatDate() As Date
        Get
            Return m_CRTDATE
        End Get
        Set(ByVal value As Date)
            m_CRTDATE = value
        End Set
    End Property
    Public Property UploadDate() As Date
        Get
            Return m_UploadDate
        End Get
        Set(ByVal value As Date)
            m_UploadDate = value
        End Set
    End Property
    Public Property ConfigTypeCode() As String
        Get
            Return m_ConfigTypeCode
        End Get
        Set(ByVal value As String)
            m_ConfigTypeCode = value
        End Set
    End Property
    Public Property EffictivetyStart() As Date
        Get
            Return m_EffictivityStartDate
        End Get
        Set(ByVal value As Date)
            m_EffictivityStartDate = value
        End Set
    End Property
    Public Property EffictivetyEndDate() As Date
        Get
            Return m_EffictivityEndDate
        End Get
        Set(ByVal value As Date)
            m_EffictivityEndDate = value
        End Set
    End Property
    Public Property ItemGroupProductCode() As String
        Get
            Return m_ItemgroupproductCode
        End Get
        Set(ByVal value As String)
            m_ItemgroupproductCode = value
        End Set
    End Property

    Public Property IsActive() As Boolean
        Get
            Return m_IsActive
        End Get
        Set(ByVal value As Boolean)
            m_IsActive = True
        End Set
    End Property

    Public Function Save() As Boolean
        Connect()
        Try
            Dim cmd As New SqlCommand("uspSalesMatrix", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "ADD")
            cmd.Parameters.AddWithValue("@SalesmatrixID", m_SaleMatrixID)
            cmd.Parameters.AddWithValue("@DLTFLG", m_DLTFLG)
            cmd.Parameters.AddWithValue("@STREGCD", m_STRREGCD)
            cmd.Parameters.AddWithValue("@STDISTRCTCD", m_STDISTRCTCD)
            cmd.Parameters.AddWithValue("@STTEAMCD", m_STTEAMCD)
            cmd.Parameters.AddWithValue("@STITMDIVCD", m_STITMDIVCD)
            cmd.Parameters.AddWithValue("@STTERRCD", m_STTERRCD)
            cmd.Parameters.AddWithValue("@STACOVCD", m_STACOVD)
            cmd.Parameters.AddWithValue("@STACOVNAME", m_STACOVNAME)
            cmd.Parameters.AddWithValue("@STSLSMNCD", m_STSLSMNCD)
            cmd.Parameters.AddWithValue("@STSLSMNNAME", m_STSLSMNNAME)
            cmd.Parameters.AddWithValue("@CRTDATE", "")
            cmd.Parameters.AddWithValue("@CRTU", "")
            cmd.Parameters.AddWithValue("@UPDD", "")
            cmd.Parameters.AddWithValue("@UPDU", "")
            cmd.Parameters.AddWithValue("@ConfigTypeCode", m_ConfigTypeCode)
            cmd.Parameters.AddWithValue("@ITEMGRPCD", m_ItemgroupproductCode)
            cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", m_EffictivityStartDate)
            cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", m_EffictivityEndDate)
            cmd.Parameters.AddWithValue("@IsActive", m_IsActive)
            m_SaleMatrixID = cmd.ExecuteScalar()
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
            Dim cmd As New SqlCommand("uspSalesMatrix", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Delete")
            cmd.Parameters.AddWithValue("@ConfigTypeCode", m_ConfigTypeCode)
            cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", m_EffictivityStartDate)
            cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", m_EffictivityEndDate)
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function

    Public Function ExecuteInsetNotInConfigtypeTerritory() As Boolean
        Dim Years As Integer = m_EffictivityStartDate.Year
        Dim Monhts As Integer = m_EffictivityStartDate.Month
        Connect()
        Try
            Dim cmd As New SqlCommand("uspProcessMatrixNotIN", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ConfigtypeCode", m_ConfigTypeCode)
            cmd.Parameters.AddWithValue("@Month", Monhts)
            cmd.Parameters.AddWithValue("@Year", Years)
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As SalesMatrixCollection
        Dim col As New SalesMatrixCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_Expense As New Expense
            Dim row As DataRow = table.Rows(j)
            'm_Expense.m_ExpenseID = row("ExpenseID")
            'm_Expense.m_EntryNumber = row("EntryNumber")
            'm_Expense.m_ExpenseDate = row("ExpenseDate")
            'm_Expense.m_SalesAgentCode = row("SalesAgentCode")
            'm_Expense.m_Remarks = row("Remarks")
            'm_Expense.m_VatInclusiveAmount = row("VatInclusiveAmount")
            'm_Expense.m_VatExclusiveAmount = row("VatExclusiveAmount")
            'm_Expense.m_TotalVat = row("TotalVat")
            'm_Expense.m_TotalEWT = row("TotalEWT")
            'm_Expense.m_CreatedBy = row("CreatedBy")
            'm_Expense.m_CreateDate = row("CreateDate")
            'm_Expense.m_LastModifiedBy = row("LastModifiedBy")
            'm_Expense.m_LastModifiedDate = row("LastModifiedDate")
            'm_Expense.m_Status = row("Status")
            'm_Expense.m_ExpenseDetails = ExpenseDetails.LoadByExpenseID(m_Expense.m_ExpenseID)
            'col.Add(m_Expense)
        Next
        'Return col
    End Function
    Public Shared Function Filter(ByVal Condition As String) As SalesMatrixCollection
        Return BaseFilter(GetRecords("SELECT * FROM SaleMatrix " & IIf(Condition <> "", " WHERE " & Condition, "")))
    End Function

    Public Overloads Shared Function Load() As SalesMatrixCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ExpenseID As Integer) As SalesMatrixs
        Return Filter("SalesMatrixID = " & ExpenseID)(0)
    End Function
    Public Shared Function CheckField(ByVal CompanyCode As String, ByVal EffectivityStartDate As Date, ByVal EffectivityEndDate As Date) As Boolean
        Return ExecuteCommand("Select * from SalesMatrix where Configtypecode = '" & CompanyCode & "' And EffectivityStartDate = '" & EffectivityStartDate.ToShortDateString & "' And EffectivityEndDate = '" & EffectivityEndDate.ToShortDateString & "' ")
    End Function
    Public Shared Function DeletedField(ByVal CompanyCode As String, ByVal EffectivityStartDate As Date, ByVal EffectivityEndDate As Date) As Boolean
        Return ExecuteCommand("Delete from SalesMatrix where ConfigTypeCode = '" & CompanyCode & "' And EffectivityStartDate = '" & EffectivityStartDate.ToShortDateString & "' And EffectivityEndDate = '" & EffectivityEndDate.ToShortDateString & "' ")
    End Function
End Class
Public Class SalesMatrixCollection
    Inherits List(Of SalesMatrixs)
End Class
