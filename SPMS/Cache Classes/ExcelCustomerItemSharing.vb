Imports System.Data
Imports System.Text
Imports System.Collections.Generic
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class ExcelCustomerItemSharing
    Private m_Path As String
    Private m_CompanyCode As String
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
        Dim connectionStringTemplate As String =
            "Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source={0};" +
            "Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"""
        Dim XLSPath As String = _ExecelLocation
        Dim connectionString As String = String.Format(connectionStringTemplate, XLSPath)
        Dim sqlSelect As String = "SELECT * FROM [Sharing per Channel$A9:N]  Where  [Company] like '" & CompanyCode & "';"
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
