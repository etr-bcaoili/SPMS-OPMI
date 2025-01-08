Imports System.Data.Sql
Imports System.Data.SqlClient
Imports SPMSOPCI.ConnectionModule
Public Class Rebates

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
    Private m_Status As Integer = 0
    Private m_RebatesPercentage As Double = 0
    Private m_RebatesValue As Double = 0

    Private dt As DataTable
    Private dv As DataView

    '-----
    Dim rwd As New RawData
    Dim rwd_collec As New RawDataCollection
    '-----


    Public ReadOnly Property RecordID() As Integer
        Get
            Return m_recordID
        End Get
    End Property

    Public Property CompanyCode() As String
        Get
            Return m_companycode
        End Get
        Set(ByVal value As String)
            m_companycode = value
        End Set
    End Property

    Public Property CustomerNumber() As String
        Get
            Return m_customernumber
        End Get
        Set(ByVal value As String)
            m_customernumber = value
        End Set
    End Property

    Public Property CustomerName() As String
        Get
            Return m_customername
        End Get
        Set(ByVal value As String)
            m_customername = value
        End Set
    End Property

    Public Property CustomerAddress1() As String
        Get
            Return m_customeraddress1
        End Get
        Set(ByVal value As String)
            m_customeraddress1 = value
        End Set
    End Property

    Public Property CustomerAddress2() As String
        Get
            Return m_customeraddress2
        End Get
        Set(ByVal value As String)
            m_customeraddress2 = value
        End Set
    End Property

    Public Property TransactionDate() As String
        Get
            Return m_transactiondate
        End Get
        Set(ByVal value As String)
            m_transactiondate = value
        End Set
    End Property

    Public Property InvoiceNumber() As String
        Get
            Return m_invoicenumber
        End Get
        Set(ByVal value As String)
            m_invoicenumber = value
        End Set
    End Property

    Public Property ItemNumber() As String
        Get
            Return m_itemnumber
        End Get
        Set(ByVal value As String)
            m_itemnumber = value
        End Set
    End Property

    Public Property ItemDescription() As String
        Get
            Return m_itemdescription
        End Get
        Set(ByVal value As String)
            m_itemdescription = value
        End Set

    End Property

    Public Property QuantitySold() As Integer
        Get
            Return m_quantitysold
        End Get
        Set(ByVal value As Integer)
            m_quantitysold = value
        End Set
    End Property

    Public Property QuantityFree() As Integer
        Get
            Return m_quantityfree
        End Get
        Set(ByVal value As Integer)
            m_quantityfree = value
        End Set
    End Property

    Public Property NetAmount() As Double
        Get
            Return m_netamount
        End Get
        Set(ByVal value As Double)
            m_netamount = value
        End Set
    End Property

    Public Property CutMo() As String
        Get
            Return m_cutmo
        End Get
        Set(ByVal value As String)
            m_cutmo = value
        End Set
    End Property

    Public Property CutYear() As String
        Get
            Return m_cutyear
        End Get
        Set(ByVal value As String)
            m_cutyear = value
        End Set
    End Property

    Public Property Status() As Integer
        Get
            Return m_status
        End Get
        Set(ByVal value As Integer)
            m_status = value
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
            Return m_RebatesValue
        End Get
        Set(ByVal value As Double)
            m_RebatesValue = value
        End Set
    End Property

    Public Function Save() As Boolean

        Connect()
        Try
            Dim command As New SqlCommand("uspRebates", SPMSConn2)
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

            m_recordID = command.ExecuteScalar()

            Disconnect()

            m_recordID = -1

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Function

    Private Shared Function HoldRawData(ByVal table As DataTable) As RebatesCollection

        Dim rbinfo As Rebates
        Dim myrow As DataRow
        Dim rbcoll2 As New RebatesCollection

        For Each myrow In table.Rows

            rbinfo = New Rebates
            rbinfo.m_RecordID = myrow.Item("RecordID")
            rbinfo.m_CompanyCode = myrow.Item("CompanyCode")
            rbinfo.m_CustomerNumber = myrow.Item("CustomerNumber")
            rbinfo.m_CustomerName = myrow.Item("CustomerName")
            rbinfo.m_CustomerAddress1 = myrow.Item("CustomerAddress1")
            rbinfo.m_CustomerAddress2 = myrow.Item("CustomerAddress2")
            rbinfo.m_TransactionDate = myrow.Item("TransactionDate")
            rbinfo.m_InvoiceNumber = myrow.Item("InvoiceNumber")
            rbinfo.m_ItemNumber = myrow.Item("ItemNumber")
            rbinfo.m_ItemDescription = myrow.Item("ItemDescription")
            rbinfo.m_QuantitySold = myrow.Item("QuantitySold")
            rbinfo.m_QuantityFree = myrow.Item("QuantityFree")
            rbinfo.m_NetAmount = myrow.Item("NetAmount")
            rbinfo.m_CutMo = myrow.Item("CUTMO")
            rbinfo.m_CutYear = myrow.Item("CUTYEAR")
            rbinfo.m_RebatesPercentage = myrow.Item("RebatesPercentage")
            rbinfo.m_RebatesValue = myrow.Item("RebatesValue")


            rbcoll2.Add(rbinfo)

        Next

        Return rbcoll2

    End Function



    Public Shared Function Filter(ByVal Filterparam As String) As RebatesCollection

        Dim rcollect As New RebatesCollection
        Dim rtable As New DataTable
        Dim command As New SqlCommand
        Dim dataadapter As New SqlDataAdapter
        Dim scom As New SqlCommand


        Dim sqlQuery As String

        Try
            Connect()

            If Filterparam <> "" Then
                sqlQuery = "select * from Rebates  rwd where not exists(Select * from RebatesDetail  rb where rb.CompanyCode=rwd.CompanyCode and rb.CUTMO=rwd.CUTMO and rb.CUTYEAR=rwd.CUTYEAR and rb.ItemNumber= rwd.ItemNumber and rb.InvoiceNumber=rwd.InvoiceNumber and rb.Status=2 ) and " & Filterparam

            Else
                sqlQuery = "select * from Rebates  rwd where not  exists(Select * from RebatesDetail  rb where rb.CompanyCode=rwd.CompanyCode and rb.CUTMO=rwd.CUTMO and rb.CUTYEAR=rwd.CUTYEAR and rb.ItemNumber= rwd.ItemNumber and rb.InvoiceNumber=rwd.InvoiceNumber and rb.Status<>2 )"

            End If

            command = New SqlCommand(sqlQuery, SPMSConn2)

            dataadapter = New SqlDataAdapter(command)

            dataadapter.Fill(rtable)
            rcollect = HoldRawData(rtable)

            Disconnect()
        Catch ex As Exception

        End Try


        Return rcollect

    End Function

    Public Overloads Shared Function Load(ByVal ccompanycode As String, ByVal ccutmonth As Integer, ByVal ccutyear As Integer) As RebatesCollection

        Dim rebcollec As New RebatesCollection

        rebcollec = Filter("CompanyCode= '" & ccompanycode & "'" & " and CUTMo= " & ccutmonth & " and CutYear= " & ccutyear)

        Return rebcollec

    End Function

    Public Overloads Shared Function Load(ByVal cRecordID As Integer) As Rebates

        Dim rebates2 As New Rebates
        Dim rebcoll As New RebatesCollection

        rebcoll = Filter("RecordID = " & cRecordID)
        rebates2 = rebcoll.Item(0)

        Return rebates2


    End Function


    '------------------


    '------------------

End Class


Public Class RebatesCollection
    Inherits List(Of Rebates)

End Class


