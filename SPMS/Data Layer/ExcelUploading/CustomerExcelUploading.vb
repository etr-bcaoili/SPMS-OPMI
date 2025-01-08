Imports System.Drawing
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Collections.Generic
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class CustomerExcelUploading

    Dim dv As New DataView

    Dim dt As New DataTable

    Private m_Customer As New Customer

    Private m_CustShipTo As New CustomerShipTo

    Private m_CompanyCode As String

    Private m_Path As String

    Public Property CompanyCode() As String
        Get
            Return m_CompanyCode
        End Get
        Set(ByVal value As String)
            m_CompanyCode = value
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
        Dim sqlSelect As String = "SELECT * FROM [Sheet1$] where [CHANNEL] like '" & CompanyCode & "';"
        ' Load the Excel worksheet into a DataTable
        Dim workbook As DataSet = New DataSet()
        Dim excelAdapter As System.Data.Common.DataAdapter = New System.Data.OleDb.OleDbDataAdapter(sqlSelect, connectionString)
        ' Try
        excelAdapter.Fill(workbook)
        Dim worksheet As DataTable = workbook.Tables(0)
        Return worksheet
        'Catch ex As Exception

        ' MsgBox(ex.Message)
        ' End Try
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
                If Not dr("CHANNEL") = CompanyCode Then Exit Sub
                m_Customer = New Customer
                m_CustShipTo = New CustomerShipTo


                m_Customer.COMID = dr("CHANNEL")
                m_CustShipTo.COMID = dr("CHANNEL")
                m_Customer.CUSTOMERCD = dr("CUSTOMERCODE").ToString
                m_CustShipTo.CUSTOMERCD = dr("CUSTOMERCODE").ToString
                m_Customer.CUSTOMERNAME = dr("CUSTOMERNAME")
                m_CustShipTo.CDANAME = dr("SHIPTONAME")
                m_Customer.DISTRIBCD = dr("CHANNEL")
                m_CustShipTo.CDACD = dr("SHIPTOCODE")
                If dr("ADDRESS1") <> "" Then
                    m_Customer.CADD1 = dr("ADDRESS1")
                    m_CustShipTo.CDACADD1 = dr("ADDRESS1")
                Else
                    m_Customer.CADD1 = ""
                    m_CustShipTo.CDACADD1 = ""
                End If

                If dr("ADDRESS2") <> "" Then
                    m_Customer.CADD2 = dr("ADDRESS2")
                    m_CustShipTo.CDACADD2 = dr("ADDRESS2")
                Else
                    m_Customer.CADD2 = ""
                    m_CustShipTo.CDACADD2 = ""
                End If
                m_Customer.ZIPCD = dr("ZIPCODE")
                m_CustShipTo.ZIPCD = dr("ZIPCODE")
                m_Customer.REGCD = dr("REGIONCODE")
                m_CustShipTo.REGCD = dr("REGIONCODE")
                m_Customer.CMGRP = dr("CUSTOMERGROUP")
                m_CustShipTo.CMGRP = dr("CUSTOMERGROUP")
                m_Customer.CMCLASS = dr("CUSTOMERCLASS")
                m_CustShipTo.CMCLASS = dr("CUSTOMERCLASS")
                m_Customer.ACCNTSHRD = dr("ACCOUNT SHARED")
                m_CustShipTo.ACCNTSHRD = dr("ACCOUNT SHARED")
                m_Customer.PHReg = dr("PHReg")

                ctr += 1
                m_Customer.Save()

            Next
        Else
            Customer.DeleteExistCustomer(CompanyCode)
            For m As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(m)
                If Not dr("CHANNEL") = CompanyCode Then Exit Sub
                m_Customer = New Customer
                m_CustShipTo = New CustomerShipTo


                m_Customer.COMID = dr("CHANNEL")
                m_CustShipTo.COMID = dr("CHANNEL")
                m_Customer.CUSTOMERCD = dr("CUSTOMERCODE").ToString
                m_CustShipTo.CUSTOMERCD = dr("CUSTOMERCODE").ToString
                m_Customer.CUSTOMERNAME = dr("CUSTOMERNAME")
                m_CustShipTo.CDANAME = dr("SHIPTONAME")
                m_Customer.DISTRIBCD = dr("CHANNEL")
                m_CustShipTo.CDACD = dr("SHIPTOCODE")
                If dr("ADDRESS1") <> "" Then
                    m_Customer.CADD1 = dr("ADDRESS1")
                    m_CustShipTo.CDACADD1 = dr("ADDRESS1")
                Else
                    m_Customer.CADD1 = ""
                    m_CustShipTo.CDACADD1 = ""
                End If

                If dr("ADDRESS2") <> "" Then
                    m_Customer.CADD2 = dr("ADDRESS2")
                    m_CustShipTo.CDACADD2 = dr("ADDRESS2")
                Else
                    m_Customer.CADD2 = ""
                    m_CustShipTo.CDACADD2 = ""
                End If
                m_Customer.ZIPCD = dr("ZIPCODE")
                m_CustShipTo.ZIPCD = dr("ZIPCODE")
                m_Customer.REGCD = dr("REGIONCODE")
                m_CustShipTo.REGCD = dr("REGIONCODE")
                m_Customer.CMGRP = dr("CUSTOMERGROUP")
                m_CustShipTo.CMGRP = dr("CUSTOMERGROUP")
                m_Customer.CMCLASS = dr("CUSTOMERCLASS")
                m_CustShipTo.CMCLASS = dr("CUSTOMERCLASS")
                m_Customer.ACCNTSHRD = dr("ACCOUNT SHARED")
                m_CustShipTo.ACCNTSHRD = dr("ACCOUNT SHARED")
                m_Customer.PHReg = dr("PHReg")

                ctr += 1
                m_Customer.Save()

            Next
        End If

    End Sub

End Class
