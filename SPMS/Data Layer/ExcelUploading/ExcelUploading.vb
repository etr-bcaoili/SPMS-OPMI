Imports System.Drawing
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Collections.Generic
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class ExcelUploading

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

    Public Function GetExcelData(ByVal _ExecelLocation As String, Optional ByVal SQLsentence As String = "") As DataTable
        '"Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"""
        '"Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1"""
        Dim connectionStringTemplate As String = _
            "Provider=Microsoft.ACE.OLEDB.12.0;" + _
            "Data Source={0};" + _
            "Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"""
        Dim XLSPath As String = _ExecelLocation
        Dim connectionString As String = String.Format(connectionStringTemplate, XLSPath)
        Dim temps As String = "ONE PHARMA CO"
        Dim sqlSelect As String = String.Empty
        If CompanyCode = "MER" Then
            sqlSelect = "SELECT * FROM [Sales Transaction$A7:AW]"
        ElseIf CompanyCode = "OPCI" Then
            sqlSelect = "SELECT [CustomerCode],[CustomerName],[ItemCode],[Invoice/CMNumber],[Invoice/CMDate],[ItemName],[Quantity],[UOM],[TM Code],[TM Name],[Net] from [Sheet1$A6:M] 'ABC' where [CustomerCode];"
            ' sqlSelect = "SELECT [ItemCode] From [Sheet1$A6:M] ORDER BY  'ABC'[ItemCode]  ;"
            ' sqlSelect = "SELECT * from [sheet1$] 'A' where CMP  ;"
        ElseIf CompanyCode = "PRI" Then
            sqlSelect = "SELECT * from [sheet1$] 'A' where CMP ;"
        ElseIf CompanyCode = "SSD" Then
            sqlSelect = "SELECT * FROM [Vendor SKU Transfers SKU$A18:F];"
        ElseIf CompanyCode = "WAT" Then
            sqlSelect = "SELECT * FROM [per sku$A4:F];"
        ElseIf CompanyCode = "ZURE" Then
            sqlSelect = "SELECT * FROM [Sheet1$A4:D];"
        ElseIf CompanyCode = "GB" Then
            sqlSelect = "SELECT * FROM [SHEET1$A9:U] 'A' where F1;"
        ElseIf CompanyCode = "MDI" Then
            sqlSelect = "SELECT * FROM [SHEET1$];"
        ElseIf CompanyCode = "MDC" Then
            sqlSelect = "SELECT * FROM [SHEET1$]"
        ElseIf CompanyCode = "MDCR" Then
            sqlSelect = "SELECT * FROM [SHEET1$]"
        ElseIf CompanyCode = "RBC" Then
            sqlSelect = "Select * from [SALES$] ;"
        ElseIf CompanyCode = "ODIGOV" Then
            sqlSelect = "SELECT * FROM [Invoice Listing$A7:AW]"
        ElseIf CompanyCode = "DIRGOV" Then
            sqlSelect = "SELECT * from [Sheet1$A7:Q];"
        ElseIf CompanyCode = "MLA" Then
            sqlSelect = "SELECT * FROM [Sheet1$B5:P] where [COMPANY CODE] like '" & CompanyCode & "';"
        ElseIf CompanyCode = "BAC" Then
            sqlSelect = "SELECT * FROM [Sheet1$B5:P] where [COMPANY CODE] like '" & CompanyCode & "';"
        ElseIf CompanyCode = "ALD" Then
            sqlSelect = "SELECT * FROM [Sheet1$B5:P] where [COMPANY CODE] like '" & CompanyCode & "';"
        ElseIf CompanyCode = "DAV" Then
            sqlSelect = "SELECT * FROM [Sheet1$B5:P] where [COMPANY CODE] like '" & CompanyCode & "';"
        ElseIf CompanyCode = "CEB" Then
            sqlSelect = "SELECT * FROM [Sheet1$B5:P] where [COMPANY CODE] like '" & CompanyCode & "';"
        ElseIf CompanyCode = "ODI" Then
            sqlSelect = "SELECT * FROM [Sales Report$A7:AW]"
        ElseIf CompanyCode = "ACT" Then
            sqlSelect = "Select * from [Sheet1$]"
        ElseIf CompanyCode = "DIR" Then
            sqlSelect = "SELECT * from [Sheet1$A7:Q];"
        End If


        ' Load the Excel worksheet into a DataTable
        Dim workbook As DataSet = New DataSet(0)
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
        Dim _Restult As Boolean = False
        If System.IO.File.Exists(_ExcelFile) = True Then
            _Restult = True
        End If
        Return _Restult
    End Function
    Public Sub StartProcess()
        Dim ctr As Integer = 0
        Dim TotalQuantity As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim ProductDiscount As Decimal = 0
        Dim _Month As String = String.Empty



        If Not RawData.CheckIfRawDataExist(CompanyCode, Year, Month) Then

            For m As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(m)
                If Not dr("DistributorCode") = CompanyCode Then Exit Sub
                m_RawData = New RawData

                m_RawData.CompanyCode = dr("DistributorCode")
                m_RawData.BranchCode = dr("ITEMCD").ToString
                If IsDBNull(dr("IMDBRN")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("IMDBRN")
                End If

                m_RawData.CustomerNumber = dr("CUSTOMERCD")
                m_RawData.CustomerName = dr("CUSTOMERNAME")
                If dr("CADD1") <> "" Then
                    m_RawData.CustomerAddress = dr("CADD1")
                    m_RawData.ShipToAddress1 = dr("CADD1")
                Else
                    m_RawData.CustomerAddress = ""
                    m_RawData.ShipToAddress1 = ""
                End If

                If dr("CADD2") <> "" Then
                    m_RawData.CustomerAddress2 = dr("CADD2")
                    m_RawData.ShipToAddress2 = dr("CADD2")
                Else
                    m_RawData.CustomerAddress2 = ""
                    m_RawData.ShipToAddress2 = ""
                End If
                m_RawData.TranscationDate = dr("InvoiceDate")
                m_RawData.InvoiceNumber = dr("InvoiceNumber")

                If dr("VLAMT") = 0 Then
                    m_RawData.QuantityFree = dr("QuantityFree")
                    TotalQuantity = TotalQuantity + dr("QTYSH")
                    m_RawData.QuantitySold = dr("QuantitySold")
                Else
                    m_RawData.QuantitySold = dr("QuantitySold")
                    TotalQuantity = TotalQuantity + dr("QuantitySold")
                    m_RawData.QuantityFree = 0
                    m_RawData.UnitPrice = dr("ListPrice")
                    m_RawData.NetAmount = dr("Amount")
                    GrossAmount = GrossAmount + dr("Amount")
                End If
                If IsDBNull(dr("InvoiceNumber")) Then
                    m_RawData.InvoiceReferenceNumber = -1
                Else
                    m_RawData.InvoiceReferenceNumber = dr("InvoiceNumber")
                End If
                m_RawData.LineDiscount = dr("Discount")
                If dr("LOTNO") <> "" Then
                    m_RawData.LotNumber = dr("LOTNO").ToString
                Else
                    m_RawData.LotNumber = ""
                End If

                m_RawData.SalesmanNumber = dr("SalesManCode")
                m_RawData.SalesmanName = dr("SLSMNNAME")
                m_RawData.CutMO = m_Month
                m_RawData.CutYear = m_Year

                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & CompanyCode & "','" & _ExecelLocation & "','" & Month & "','" & Year & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        Else

            RawData.DeleteExistRawData(CompanyCode, Year, Month)
            For m As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(m)
                If Not dr("DistributorCode") = CompanyCode Then Exit Sub
                m_RawData = New RawData

                m_RawData.CompanyCode = dr("DistributorCode")
                m_RawData.BranchCode = dr("ITEMCD").ToString
                If IsDBNull(dr("IMDBRN")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("IMDBRN")
                End If

                m_RawData.CustomerNumber = dr("CUSTOMERCD")
                m_RawData.CustomerName = dr("CUSTOMERNAME")
                If dr("CADD1") <> "" Then
                    m_RawData.CustomerAddress = dr("CADD1")
                    m_RawData.ShipToAddress1 = dr("CADD1")
                Else
                    m_RawData.CustomerAddress = ""
                    m_RawData.ShipToAddress1 = ""
                End If

                If dr("CADD2") <> "" Then
                    m_RawData.CustomerAddress2 = dr("CADD2")
                    m_RawData.ShipToAddress2 = dr("CADD2")
                Else
                    m_RawData.CustomerAddress2 = ""
                    m_RawData.ShipToAddress2 = ""
                End If
                m_RawData.TranscationDate = dr("InvoiceDate")
                m_RawData.InvoiceNumber = dr("InvoiceNumber")

                If dr("VLAMT") = 0 Then
                    m_RawData.QuantityFree = dr("QuantityFree")
                    TotalQuantity = TotalQuantity + dr("QTYSH")
                    m_RawData.QuantitySold = dr("QuantitySold")
                Else
                    m_RawData.QuantitySold = dr("QuantitySold")
                    TotalQuantity = TotalQuantity + dr("QuantitySold")
                    m_RawData.QuantityFree = 0
                    m_RawData.UnitPrice = dr("ListPrice")
                    m_RawData.NetAmount = dr("Amount")
                    GrossAmount = GrossAmount + dr("Amount")
                End If
                If IsDBNull(dr("InvoiceNumber")) Then
                    m_RawData.InvoiceReferenceNumber = -1
                Else
                    m_RawData.InvoiceReferenceNumber = dr("InvoiceNumber")
                End If
                m_RawData.LineDiscount = dr("Discount")
                If dr("LOTNO") <> "" Then
                    m_RawData.LotNumber = dr("LOTNO").ToString
                Else
                    m_RawData.LotNumber = ""
                End If

                m_RawData.SalesmanNumber = dr("SalesManCode")
                m_RawData.SalesmanName = dr("SLSMNNAME")
                m_RawData.CutMO = m_Month
                m_RawData.CutYear = m_Year

                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & CompanyCode & "','" & _ExecelLocation & "','" & Month & "','" & Year & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        End If

    End Sub

End Class
