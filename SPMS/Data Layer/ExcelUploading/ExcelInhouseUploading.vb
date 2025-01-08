Imports System.Drawing
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Collections.Generic
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class ExcelInhouseUploading

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
        Dim connectionStringTemplate As String = _
            "Provider=Microsoft.ACE.OLEDB.12.0;" + _
            "Data Source={0};" + _
            "Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"""
        Dim XLSPath As String = _ExecelLocation
        Dim connectionString As String = String.Format(connectionStringTemplate, XLSPath)
        Dim sqlSelect As String

        sqlSelect = "Select * From [Sheet1$] Where [Channel Code] like '" & CompanyCode & "' And [Year] like '" & Year & "' And [Month] like '" & Month & "'; "

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

End Class
