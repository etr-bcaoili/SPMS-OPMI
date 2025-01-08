Imports System.Drawing
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Collections.Generic
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class TargetSalesUploading


    Private m_RawData As New TargerSales

    Dim dv As New DataView

    Dim dt As New DataTable

    Private m_Path As String

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
        Dim sqlSelect As String = "SELECT * FROM [Sheet1$] 'A' where COMID  ;"
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


        ' If Not Customer.CheckCustomerIfExist(CompanyCode) Then

        For m As Integer = 0 To dt.Rows.Count - 1
            Dim dr As DataRow = dt.Rows(m)
            '  If Not dr("COMPANY CODE") = CompanyCode Then Exit Sub

            m_RawData = New TargerSales
            m_RawData.CompanyCode = dr("COMID")
            m_RawData.TerretoryCode = dr("TerritoryCode")
            m_RawData.EmployeeID = dr("EmployeeID")
            m_RawData.EmployeeName = dr("EmployeeName")
            m_RawData.ItemCode = dr("ItemCode")
            m_RawData.ItemName = dr("ItemName")
            m_RawData.CutYear = dr("Year")
            m_RawData.QuantityTagetJanuary = dr("QT01")
            m_RawData.SalesTargetJanuary = dr("ST01")
            m_RawData.QuantitytargetFebrary = dr("QT02")
            m_RawData.SalesTargetFebrary = dr("ST02")
            m_RawData.QuantityTagetMarch = dr("QT03")
            m_RawData.SaleTagetMarch = dr("ST03")
            m_RawData.QuantityTargetApril = dr("QT04")
            m_RawData.SaleTargerApril = dr("QT04")
            m_RawData.QuantityTargetMay = dr("QT05")
            m_RawData.SaleTargetMay = dr("ST05")
            m_RawData.QuantityTargerJune = dr("QT06")
            m_RawData.SaleTargetJune = dr("ST06")
            m_RawData.QuantityTargetJuly = dr("QT07")
            m_RawData.SalesTargetJuly = ("ST07")
            m_RawData.QuantityTargetAugust = ("QRT08")
            m_RawData.SaleTargetAugust = ("ST08")
            m_RawData.QuantityTargetSeptember = dr("QT09")
            m_RawData.SaleTargetSeptember = dr("ST09")
            m_RawData.QuantityTargetOctober = dr("QT10")
            m_RawData.SaleTargetOctober = dr("ST10")
            m_RawData.QuantityTargetNovember = dr("QT11")
            m_RawData.SalesTargetNovember = dr("ST11")
            m_RawData.QuantityTargetDecember = dr("QT12")
            m_RawData.Salestragetdecember = dr("ST12")
            ctr += 1
            m_RawData.Save()
        Next
        'Else
        'Customer.DeleteExistCustomer(CompanyCode)
        'For m As Integer = 0 To dt.Rows.Count - 1
        '    Dim dr As DataRow = dt.Rows(m)
        '    If Not dr("COMPANY CODE") = CompanyCode Then Exit Sub

        '    m_RawData = New RawData
        '    m_RawData.CompanyCode = dr("COMPANY CODE")
        '    m_RawData.TranscationDate = dr("TRANS DATE")
        '    m_RawData.InvoiceNumber = dr("INVOICE #")
        '    m_RawData.SalesmanNumber = dr("DETAILMAN #")
        '    m_RawData.SalesmanName = dr("SALESMAN")
        '    m_RawData.CustomerNumber = dr("CUSTOMER CODE")
        '    m_RawData.CustomerName = dr("CUSTOMER NAME")
        '    m_RawData.CustomerAddress = dr("CUSTOMER ADDRESS")
        '    m_RawData.ItemNumber = dr("ITEM CODE")
        '    m_RawData.ItemDescription = dr("ITEM NAME")
        '    m_RawData.QuantitySold = dr("SOLD QTY")
        '    m_RawData.QuantityFree = dr("FREE GOODS")
        '    m_RawData.UnitPrice = dr("UNIT PRICE")
        '    m_RawData.LineDiscount = dr("% DISCOUNT")
        '    m_RawData.GrossAmount = dr("AMOUNT")
        '    m_RawData.ShipToName = dr("CUSTOMER NAME")
        '    m_RawData.ShipToAddress1 = dr("CUSTOMER ADDRESS")
        '    m_RawData.CustomerDeliveryCode = "001"

        '    ctr += 1
        '    m_RawData.Save()
        'Next
        'End If

    End Sub


End Class
