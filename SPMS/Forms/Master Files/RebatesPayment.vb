Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient


Public Class RebatesPayment
    Private m_RecordID As Integer = -1
    Private m_CompanyCode As String = ""
    Private m_CustomerNumber As String = ""
    Private m_CustomerName As String = ""
    Private m_CustomerAddress1 As String = ""
    Private m_CustomerAddress2 As String = ""
    Private m_TransactionDate As String = ""
    Private m_InvoiceNumber As String = ""
    Private m_ItemNumber As String = ""
    Private m_ItemDescription As String = ""
    Private m_QuantitySold As Integer = 0
    Private m_QuantityFree As Integer = 0
    Private m_NetAmount As Double = 0
    Private m_CutMo As String = ""
    Private m_CutYear As String = ""
    Private m_RebatesPercentage As Double = 0
    Private m_RebatesValue As Double = 0
    Private m_CheckNumber As String = ""
    Private m_CheckDate As DateTime = "1/1/1999"
    Private m_PaymentAmount As Double = 0
    Private m_RemainingBalance As Double = 0
    Private m_PayTo As String = ""
    Private m_CreateDate As String = ""
    Private m_CreatedBy As Integer = -1
    Private m_saleCode As String = ""




    Public Enum enumStatus
        Unpaid = 0
        PartialPayment = 1
        FullPayment = 2

    End Enum

    Private m_Status As enumStatus = enumStatus.Unpaid


    Dim dt As DataTable

    Public ReadOnly Property RecordID() As Integer
        Get
            Return m_RecordID
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

    Public Property CustomerAddress1() As String
        Get
            Return m_CustomerAddress1
        End Get
        Set(ByVal value As String)
            m_CustomerAddress1 = value
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

    Public Property TransactionDate() As String
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

    Public Property QuantitySold() As Integer
        Get
            Return m_QuantitySold
        End Get
        Set(ByVal value As Integer)
            m_QuantitySold = value
        End Set
    End Property

    Public Property QuantityFree() As Integer
        Get
            Return m_QuantityFree
        End Get
        Set(ByVal value As Integer)
            m_QuantityFree = value
        End Set
    End Property

    Public Property NetAmount() As Double
        Get
            Return m_NetAmount
        End Get
        Set(ByVal value As Double)
            m_NetAmount = value
        End Set
    End Property

    Public Property CutMo() As String
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


    Public Property RebatesPercentage() As Double
        Get
            Return m_RebatesPercentage
        End Get
        Set(ByVal value As Double)
            m_RebatesPercentage = value
        End Set
    End Property

    Public Property RebatesValue() As Double
        Get
            Return m_rebatesvalue
        End Get
        Set(ByVal value As Double)
            m_rebatesvalue = value
        End Set
    End Property

    Public Property CheckNumber() As String
        Get
            Return m_CheckNumber
        End Get
        Set(ByVal value As String)
            m_CheckNumber = value
        End Set
    End Property

    Public Property CheckDate() As String
        Get
            Return m_CheckDate
        End Get
        Set(ByVal value As String)
            m_CheckDate = value
        End Set
    End Property


    Public Property PaymentAmount() As Double
        Get
            Return m_PaymentAmount
        End Get
        Set(ByVal value As Double)
            m_PaymentAmount = value
        End Set
    End Property


    Public Property RemainingBalance() As Double
        Get
            Return m_RemainingBalance
        End Get
        Set(ByVal value As Double)
            m_RemainingBalance = value
        End Set
    End Property
    Public Property SalesCodes() As String
        Get
            Return m_saleCode
        End Get
        Set(ByVal value As String)
            m_saleCode = value
        End Set
    End Property



    Public Property PayTo() As String
        Get
            Return m_PayTo
        End Get
        Set(ByVal value As String)
            m_PayTo = value
        End Set
    End Property

    Public Property CreateDate() As DateTime
        Get
            Return m_CreateDate
        End Get
        Set(ByVal value As DateTime)
            m_CreateDate = value
        End Set
    End Property

    Public Property CreatedBy() As Integer
        Get
            Return m_CreatedBy
        End Get
        Set(ByVal value As Integer)
            m_CreatedBy = value
        End Set
    End Property

    Public Property Status() As enumStatus
        Get
            Return m_Status
        End Get
        Set(ByVal value As enumStatus)
            m_Status = value
        End Set
    End Property


    Public Function Save() As Boolean

        Try
            Connect()

            Dim command As New SqlCommand("uspRebatesPayment", SPMSConn2)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Action", "Save")
            command.Parameters.AddWithValue("@RecordID", m_RecordID)
            command.Parameters.AddWithValue("@CompanyCode", m_CompanyCode)
            command.Parameters.AddWithValue("@CustomerNumber", m_CustomerNumber)
            command.Parameters.AddWithValue("@CustomerName", m_CustomerName)
            command.Parameters.AddWithValue("@CustomerAddress1", m_CustomerAddress1)
            command.Parameters.AddWithValue("@CustomerAddress2", m_CustomerAddress2)
            command.Parameters.AddWithValue("@TransactionDate", m_TransactionDate)
            command.Parameters.AddWithValue("@InvoiceNumber", m_InvoiceNumber)
            command.Parameters.AddWithValue("@ItemNumber", m_ItemNumber)
            command.Parameters.AddWithValue("@ItemDescription", m_ItemDescription)
            command.Parameters.AddWithValue("@QuantitySold", m_QuantitySold)
            command.Parameters.AddWithValue("@QuantityFree", m_QuantityFree)
            command.Parameters.AddWithValue("@NetAmount", m_NetAmount)
            command.Parameters.AddWithValue("@CUTMo", m_CutMo)
            command.Parameters.AddWithValue("@CUTYear", m_CutYear)
            command.Parameters.AddWithValue("@Status", m_Status)
            command.Parameters.AddWithValue("@RebatesPercentage", m_RebatesPercentage)
            command.Parameters.AddWithValue("@RebatesValue", m_RebatesValue)
            command.Parameters.AddWithValue("@CheckNumber", m_CheckNumber)
            command.Parameters.AddWithValue("@CheckDate", m_CheckDate)
            command.Parameters.AddWithValue("@PaymentAmount", m_PaymentAmount)
            command.Parameters.AddWithValue("@RemainingBalance", m_RemainingBalance)
           command.Parameters.AddWithValue("@PayTo", m_PayTo)
            command.Parameters.AddWithValue("@CreateDate", m_CreateDate)
            command.Parameters.AddWithValue("@CreatedBy", m_CreatedBy)
            command.Parameters.AddWithValue("@DETCD", m_saleCode)

            m_RecordID = command.ExecuteScalar()

            Disconnect()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Function

    Private Shared Function GetRebatesHolder(ByVal table As DataTable) As RebatesPaymentCollection

        Dim rebpayinfo As RebatesPayment
        Dim myrow As DataRow
        Dim rebpaycollec As New RebatesPaymentCollection

        For Each myrow In table.Rows
            rebpayinfo = New RebatesPayment

            rebpayinfo.m_RecordID = myrow.Item("RecordID")
            rebpayinfo.m_CompanyCode = myrow.Item("CompanyCode")
            rebpayinfo.m_CustomerNumber = myrow.Item("CustomerNumber")
            rebpayinfo.m_CustomerName = myrow.Item("CustomerName")
            rebpayinfo.m_CustomerAddress1 = myrow.Item("CustomerAddress1")
            rebpayinfo.m_CustomerAddress2 = myrow.Item("CustomerAddress2")
            rebpayinfo.m_TransactionDate = myrow.Item("TransactionDate")
            rebpayinfo.m_InvoiceNumber = myrow.Item("InvoiceNumber")
            rebpayinfo.m_ItemNumber = myrow.Item("ItemNumber")
            rebpayinfo.m_ItemDescription = myrow.Item("ItemDescription")
            rebpayinfo.m_QuantitySold = myrow.Item("QuantitySold")
            rebpayinfo.m_QuantityFree = myrow.Item("QuantityFree")
            rebpayinfo.m_NetAmount = myrow.Item("NetAmount")
            rebpayinfo.m_CutMo = myrow.Item("CUTMO")
            rebpayinfo.m_CutYear = myrow.Item("CUTYEAR")
            rebpayinfo.m_RebatesPercentage = myrow.Item("RebatesPercentage")
            rebpayinfo.m_RebatesValue = myrow.Item("RebatesValue")
            rebpayinfo.Status = myrow.Item("Status")
            rebpayinfo.m_CheckNumber = myrow.Item("CheckNumber")
            rebpayinfo.m_CheckDate = myrow.Item("CheckDate")
            rebpayinfo.m_PaymentAmount = myrow.Item("PaymentAmount")
            rebpayinfo.m_RemainingBalance = myrow.Item("RemainingBalance")
           rebpayinfo.m_PayTo = myrow.Item("PayTo")
            rebpayinfo.m_CreateDate = myrow.Item("CreateDate")
            rebpayinfo.m_CreatedBy = myrow.Item("CreatedBy")
            rebpayinfo.m_saleCode = myrow.Item("SLSMNNAME")
            rebpaycollec.Add(rebpayinfo)


        Next

        Return rebpaycollec


    End Function


    Public Shared Function BaseFilter(ByVal FilterParam As String) As RebatesPaymentCollection

        Dim rpcollect As New RebatesPaymentCollection
        Dim rptable As New DataTable
        Dim command As New SqlCommand
        Dim dataadapter As New SqlDataAdapter
        Dim scom As New SqlCommand

        Dim sqlQuery As String

        If FilterParam <> "" Then
            sqlQuery = " select RecordID,CompanyCode, CustomerNumber, CustomerName, CustomerAddress1, CustomerAddress2, TransactionDate, InvoiceNumber, ItemNumber, ItemDescription, QuantitySold, QuantityFree, NetAmount, CUTMO, CUTYEAR, Status, RebatesPercentage, RebatesValue, CheckNumber,CheckDate, PaymentAmount, RemainingBalance, PayTo ,CreateDate, CreatedBy,pre.SLSMNNAME from RebatesDetail  left join MEDICALREP pre on pre.SLSMNCD = RebatesDetail.DETCD where " & FilterParam
        Else
            sqlQuery = "Select * from RebatesDetail  "
        End If

        Try

            Connect()

            command = New SqlCommand(sqlQuery, SPMSConn2)

            dataadapter = New SqlDataAdapter(command)

            dataadapter.Fill(rptable)

            rpcollect = GetRebatesHolder(rptable)

            Disconnect()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Return rpcollect

    End Function

    Public Shared Function Filter(ByVal rpCompanyCode As String, ByVal rpMonth As Integer, ByVal rpYear As Integer) As RebatesPaymentCollection
        Dim rpcollec2 As New RebatesPaymentCollection

        rpcollec2 = BaseFilter("CompanyCode= '" & rpCompanyCode & "'" & " and CUTMo= " & rpMonth & " and CutYear= " & rpYear)

        Return rpcollec2

    End Function

    Public Overloads Shared Function Load(ByVal RecordID As Integer) As RebatesPayment
        Dim rpcollec3 As New RebatesPaymentCollection
        Dim rpinfo2 As New RebatesPayment

        rpcollec3 = BaseFilter("RecordID= " & RecordID)

        rpinfo2 = rpcollec3.Item(0)

        Return rpinfo2

    End Function


End Class

Public Class RebatesPaymentCollection
    Inherits List(Of RebatesPayment)

End Class
