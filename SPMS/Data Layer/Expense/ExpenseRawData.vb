

Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports SPMSOPCI.ConnectionModule

Imports System.Data.OleDb


Public Class ExpenseRawData

    Private m_ExpenseRawDataID As Integer = -1

    Private m_SalesAgentCode As String = String.Empty

    Private m_Remarks As String = String.Empty

    Private m_ExpenseDate As Date = "1/1/1900"

    Private m_ExpenseCode As String = String.Empty

    Private m_ExpenseTypeCode As String = String.Empty

    Private m_AccountDescription As String = String.Empty

    Private m_Amount As Double = 0

    Private m_VAT As Double = 0

    Private m_VAT2 As Double = 0

    Private m_Totalvat As Double = 0

    Private m_ExpenseDetails As New ExpenseDetailsCollection

    Public ReadOnly Property ExpenseRawDataID() As Integer
        Get
            Return m_ExpenseRawDataID
        End Get
    End Property

    Public Property SalesAgentCode() As String
        Get
            Return m_SalesAgentCode
        End Get
        Set(ByVal value As String)
            m_SalesAgentCode = value
        End Set
    End Property

    Public Property Remarks() As String
        Get
            Return m_Remarks
        End Get
        Set(ByVal value As String)
            m_Remarks = value
        End Set
    End Property

    Public Property ExpenseTypeCode() As String
        Get
            Return m_ExpenseTypeCode
        End Get
        Set(ByVal value As String)
            m_ExpenseTypeCode = value
        End Set
    End Property

    Public Property ExpenseDate() As Date
        Get
            Return m_ExpenseDate
        End Get
        Set(ByVal value As Date)
            m_ExpenseDate = value
        End Set
    End Property

    Public Property ExpenseCode() As String
        Get
            Return m_ExpenseCode
        End Get
        Set(ByVal value As String)
            m_ExpenseCode = value
        End Set
    End Property
    Public Property Accountdescription() As String
        Get
            Return m_AccountDescription
        End Get
        Set(ByVal value As String)
            m_AccountDescription = value
        End Set
    End Property

    Public Property Amount() As Double
        Get
            Return m_Amount
        End Get
        Set(ByVal value As Double)
            m_Amount = value
        End Set
    End Property

    Public Property VAT() As Double
        Get
            Return m_VAT
        End Get
        Set(ByVal value As Double)
            m_VAT = value
        End Set
    End Property
    Public Property Vat2() As Double
        Get
            Return m_VAT2
        End Get
        Set(ByVal value As Double)
            m_VAT2 = value
        End Set
    End Property
    Public Property TotalVat() As Double
        Get
            Return m_Totalvat
        End Get
        Set(ByVal value As Double)
            m_Totalvat = value
        End Set
    End Property

    Public ReadOnly Property ExpenseDetailsCollection() As ExpenseDetailsCollection
        Get
            Return m_ExpenseDetails
        End Get
    End Property

    Public Function Save() As Boolean
        Connect()
        Try

            Dim cmd As New SqlCommand("uspExpenseRawData", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Save")
            cmd.Parameters.AddWithValue("@ExpenseRawDataID", m_ExpenseRawDataID)
            cmd.Parameters.AddWithValue("@SalesAgentCode", m_SalesAgentCode)
            cmd.Parameters.AddWithValue("@Remarks", m_Remarks)
            cmd.Parameters.AddWithValue("@ExpenseDate", m_ExpenseDate)
            cmd.Parameters.AddWithValue("@ExpenseCode", m_ExpenseCode)
            cmd.Parameters.AddWithValue("@Amount", m_Amount)
            cmd.Parameters.AddWithValue("@VAT", m_VAT)
            cmd.Parameters.AddWithValue("@Totalvat", m_Totalvat)
            m_ExpenseRawDataID = cmd.ExecuteScalar()
            Disconnect()
            Return True
        Catch ex As System.Exception
            Disconnect()
            Throw
        End Try
    End Function

    Public Function Saves() As Boolean
        Connect()
        Try

            Dim cmd As New SqlCommand("uspExpenseUploading", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Save")
            cmd.Parameters.AddWithValue("@ExpenseID", m_ExpenseRawDataID)
            cmd.Parameters.AddWithValue("@SalesAgentCode", m_SalesAgentCode)
            cmd.Parameters.AddWithValue("@Remarks", m_Remarks)
            cmd.Parameters.AddWithValue("@ExpenseDate", m_ExpenseDate)
            cmd.Parameters.AddWithValue("@EntryNumber", m_ExpenseCode)
            cmd.Parameters.AddWithValue("@ExpenseAmount", m_Amount)
            cmd.Parameters.AddWithValue("@ExpenseTypeCode", m_ExpenseTypeCode)
            cmd.Parameters.AddWithValue("@VatExclusiveAmount", m_VAT)
            cmd.Parameters.AddWithValue("@VATInclusiveAmount", m_VAT2)
            cmd.Parameters.AddWithValue("@TotalVat", m_Totalvat)
            cmd.Parameters.AddWithValue("@AccountDescription", m_AccountDescription)

            m_ExpenseRawDataID = cmd.ExecuteScalar()
            Disconnect()
            Return True
        Catch ex As System.Exception
            Disconnect()
            Throw
        End Try
    End Function
    Public Shared Function DeletesExistingData(ByVal Month As String, ByVal Year As String) As Integer
        Connect()
        Dim id As Integer = -1
        Dim cmd As New SqlCommand("uspExpenseUploading", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Action", "Delete")
        cmd.Parameters.AddWithValue("@Month", Convert.ToInt16(Month))
        cmd.Parameters.AddWithValue("@Year", Convert.ToInt16(Year))
        id = cmd.ExecuteScalar
        Disconnect()
        Return id
    End Function
    Public Function Delete() As Boolean
        Connect()
        Try

            Dim cmd As New SqlCommand("uspExpenseRawData", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Delete")
            cmd.Parameters.AddWithValue("@ExpenseRawDataID", m_ExpenseRawDataID)
            cmd.ExecuteNonQuery()
            Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function

    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As ExpenseRawDataCollection
        Dim col As New ExpenseRawDataCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_ExpenseRawData As New ExpenseRawData
            Dim row As DataRow = table.Rows(j)
            m_ExpenseRawData.m_ExpenseRawDataID = row("ExpenseRawDataID")
            m_ExpenseRawData.m_SalesAgentCode = row("SalesAgentCode")
            m_ExpenseRawData.m_Remarks = row("Remarks")
            m_ExpenseRawData.m_ExpenseDate = row("ExpenseDate")
            m_ExpenseRawData.m_ExpenseCode = row("ExpenseCode")
            m_ExpenseRawData.m_Amount = row("Amount")
            'm_ExpenseRawData.m_VAT = row("VAT1")
            ' m_ExpenseRawData.m_VAT2 = row("Vat2")
            m_ExpenseRawData.TotalVat = row("TotalVat")
            col.Add(m_ExpenseRawData)
        Next
        Return col
    End Function

    Public Shared Function UploadExpenseFromSource(ByVal Month As String, ByVal year As String) As Integer

        Connect()
        Dim id As Integer = -1
        Dim cmd As New SqlCommand("uspOPCIInsertExpenseForProcess", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Month", Convert.ToInt16(Month))
        cmd.Parameters.AddWithValue("@Year", Convert.ToInt16(year))
        id = cmd.ExecuteScalar
        Disconnect()
        Return id
    End Function


    Public Shared Function Filter(ByVal Condition As String) As ExpenseRawDataCollection
        Return BaseFilter(GetRecords("SELECT * FROM ExpenseRawData " & IIf(Condition <> "", " WHERE " & Condition, "")))
    End Function

    Public Overloads Shared Function Load() As ExpenseRawDataCollection
        Return Filter("")
    End Function

    Public Overloads Shared Function Load(ByVal ExpenseRawDataID As Integer) As ExpenseRawData
        Return Filter("ExpenseRawDataID = " & ExpenseRawDataID)(0)
    End Function

    Public Shared Function GetSalesAgentCodeForUpload() As String()
        Dim dt As DataTable = GetRecords("SELECT Distinct SalesAgentCode FROM ExpenseRawData")
        Dim agent As New List(Of String)
        For m As Integer = 0 To dt.Rows.Count - 1
            agent.Add(dt.Rows(m)("SalesAgentCode"))
        Next
        Return agent.ToArray
    End Function
    Public Shared Function GetExpenseSqls() As String
        Return "SELECT ExpenseRawdataID, ExpenseCode [Expense No.], ExpenseDate [Expense Date], SLSMNNAME [Sales Agent], Remarks, 	Case Status WHEN 0 THEN 'Pending' WHEN 1 THEN 'Approved' END as Status  FROM 	ExpenseRawData   A, 	MedicalRep B WHERE B.SLSMNCd = A.SalesAgentCode AND B.DLTFLG = 0 "
    End Function

    Public Shared Function LoadBySalesAgent(ByVal SalesAgentCode As String) As ExpenseRawDataCollection
        Return Filter("SalesAgentCode = '" & HandleSingleQuoteInSql(SalesAgentCode) & "' ")
    End Function

    Public Shared Function GetExpenseColumnss() As String
        Return "ExpenseRawdataID; ExpenseCode; ExpenseDate; SLSMNNAME; Remarks; Status;"
    End Function


End Class

Public Class ExpenseRawDataCollection

    Inherits List(Of ExpenseRawData)
End Class
