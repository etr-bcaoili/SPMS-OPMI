Imports System.Drawing
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Collections.Generic
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class ExcelItemCostingUpload
    Dim dv As New DataView

    Dim dt As New DataTable

    Private m_Customer As New Customer

    Private m_CustShipTo As New CustomerShipTo

    Private m_CompanyCode As String

    Private m_Month As String

    Private m_year As String

    Private m_Path As String
    Public Property CompanyCode() As String
        Get
            Return m_CompanyCode
        End Get
        Set(ByVal value As String)
            m_CompanyCode = value
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
    Public Property Year() As String
        Get
            Return m_year
        End Get
        Set(ByVal value As String)
            m_year = value
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
        Dim sqlSelect As String = "SELECT * FROM [Sheet1$] where [Channel Code] like  '" & CompanyCode & "' and [Month] like '" & Month & "' and [Year] like '" & Year & "';"
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
End Class
