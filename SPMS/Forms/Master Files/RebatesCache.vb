Imports SPMSOPCI.GlobalFunctionsModule
Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

'search class for the rebates module 

Public Class RebatesCache
    Private dt As DataTable
    Private dv As DataView


    Private m_customernumber As String = String.Empty
    Private m_invoicenumber As String = String.Empty


    Public Property CustomerNumber() As String
        Get
            Return m_customernumber
        End Get
        Set(ByVal value As String)
            m_customernumber = value
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

    Public Sub InitializedCache(ByVal compcode As String, ByVal cutmonth As Integer, ByVal cutyear As Integer)

        dt = LoadDataTable(compcode, cutmonth, cutyear)

    End Sub


    Private Function LoadDataTable(ByVal companycode As String, ByVal cmonth As Integer, ByVal cyear As Integer) As DataTable

        Dim command As New SqlCommand
        Dim dataadapter As New SqlDataAdapter
        Dim scom As New SqlCommand
        Connect()

        command = New SqlCommand("uspForRebatesTagging", SPMSConn2)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddWithValue("CompanyCode", companycode)
        command.Parameters.AddWithValue("CutMo", cmonth)
        command.Parameters.AddWithValue("CutYear", cyear)

        dataadapter = New SqlDataAdapter(command)

        dt = New DataTable()

        dataadapter.Fill(dt)
        Disconnect()

        Return dt


    End Function

    Public Function DVFilter() As DataView
        dv = dt.DefaultView

        Dim m_filter As String = ""

        If m_customernumber <> "" Then
            If m_filter <> "" Then m_filter &= " AND "
            m_filter &= "CustomerNumber like '%" & HandleSingleQuoteInSql(RefineSQL(m_customernumber)) & "%' "

        End If

        If m_invoicenumber <> "" Then
            If m_filter <> "" Then m_filter &= " AND "
            m_filter &= "InvoiceNumber like '%" & HandleSingleQuoteInSql(RefineSQL(m_invoicenumber)) & "%' "

        End If

        dv.RowFilter = m_filter

        Return dv

    End Function



End Class
