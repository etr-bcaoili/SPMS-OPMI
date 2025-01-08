Imports System.Drawing
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Collections.Generic
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class SalesExcelUploading

    Dim dv As New DataView

    Dim dt As New DataTable

    Private m_RawData As New RawData

    Private m_CompanyCode As String

    Private m_Year As String

    Private m_Month As String

    Private m_Path As String

    Public Property CompanyCode() As String
        Get
            Return m_CompanyCode
        End Get
        Set(ByVal value As String)
            m_CompanyCode = value
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


    Public Property _ExecelLocation()
        Get
            Return m_Path
        End Get
        Set(ByVal value)
            m_Path = value
        End Set
    End Property

    Public Function GetExcelData(ByVal _ExecelLocation As String) As DataTable

        Dim connectionStringTemplate As String = _
            "Provider=Microsoft.ACE.OLEDB.12.0;" + _
            "Data Source={0};" + _
            "Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"""
        Dim XLSPath As String = _ExecelLocation
        Dim connectionString As String = String.Format(connectionStringTemplate, XLSPath)
        Dim sqlSelect As String = "SELECT * FROM [Sheet1$B5:P] where [COMPANY CODE] like '" & CompanyCode & "';"
        ' Load the Excel worksheet into a DataTable
        Dim workbook As DataSet = New DataSet()
        Dim excelAdapter As System.Data.Common.DataAdapter = New System.Data.OleDb.OleDbDataAdapter(sqlSelect, connectionString)
        Try
            excelAdapter.Fill(workbook)
            Dim worksheet As DataTable = workbook.Tables(0)
            Return worksheet
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
    End Function

    Public Function CheckIfExist(ByVal _ExcelFile) As Boolean
        Dim _Result As Boolean = False
        If System.IO.File.Exists(_ExcelFile) = True Then
            _Result = True
        End If
        Return _Result
    End Function
    Public Sub StartProcess()
        Dim ctr As Integer = 0


        If Not Customer.CheckCustomerIfExist(CompanyCode) Then

            For m As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(m)
                If Not dr("COMPANY CODE") = CompanyCode Then Exit Sub

                m_RawData = New RawData
                m_RawData.CompanyCode = dr("COMPANY CODE")
                m_RawData.TranscationDate = dr("TRANS DATE")
                m_RawData.InvoiceNumber = dr("INVOICE #")
                m_RawData.SalesmanNumber = dr("DETAILMAN #")
                m_RawData.SalesmanName = dr("SALESMAN")
                m_RawData.CustomerNumber = dr("CUSTOMER CODE")
                m_RawData.CustomerName = dr("CUSTOMER NAME")
                m_RawData.CustomerAddress = dr("CUSTOMER ADDRESS")
                m_RawData.ItemNumber = dr("ITEM CODE")
                m_RawData.ItemDescription = dr("ITEM NAME")
                m_RawData.QuantitySold = dr("SOLD QTY")
                m_RawData.QuantityFree = dr("FREE GOODS")
                m_RawData.UnitPrice = dr("UNIT PRICE")
                m_RawData.LineDiscount = dr("% DISCOUNT")
                m_RawData.GrossAmount = dr("AMOUNT")
                m_RawData.ShipToName = dr("CUSTOMER NAME")
                m_RawData.ShipToAddress1 = dr("CUSTOMER ADDRESS")
                m_RawData.CustomerDeliveryCode = "001"

                ctr += 1
                m_RawData.Save()
            Next
        Else
            Customer.DeleteExistCustomer(CompanyCode)
            For m As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(m)
                If Not dr("COMPANY CODE") = CompanyCode Then Exit Sub

                m_RawData = New RawData
                m_RawData.CompanyCode = dr("COMPANY CODE")
                m_RawData.TranscationDate = dr("TRANS DATE")
                m_RawData.InvoiceNumber = dr("INVOICE #")
                m_RawData.SalesmanNumber = dr("DETAILMAN #")
                m_RawData.SalesmanName = dr("SALESMAN")
                m_RawData.CustomerNumber = dr("CUSTOMER CODE")
                m_RawData.CustomerName = dr("CUSTOMER NAME")
                m_RawData.CustomerAddress = dr("CUSTOMER ADDRESS")
                m_RawData.ItemNumber = dr("ITEM CODE")
                m_RawData.ItemDescription = dr("ITEM NAME")
                m_RawData.QuantitySold = dr("SOLD QTY")
                m_RawData.QuantityFree = dr("FREE GOODS")
                m_RawData.UnitPrice = dr("UNIT PRICE")
                m_RawData.LineDiscount = dr("% DISCOUNT")
                m_RawData.GrossAmount = dr("AMOUNT")
                m_RawData.ShipToName = dr("CUSTOMER NAME")
                m_RawData.ShipToAddress1 = dr("CUSTOMER ADDRESS")
                m_RawData.CustomerDeliveryCode = "001"

                ctr += 1
                m_RawData.Save()
            Next
        End If

    End Sub

End Class
