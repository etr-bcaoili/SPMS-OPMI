Imports System.Drawing
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Collections.Generic
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class DocumentSheetSalesMatrix
    Dim dv As New DataView

    Dim dt As New DataTable
    Dim m_sheetName
    Public Property SheetName() As String
        Get
            Return m_sheetName
        End Get
        Set(ByVal value As String)
            If m_sheetName <> value Then
                m_sheetName = value
            End If
            m_sheetName = value
        End Set
    End Property
    Public Function GetExcelData(ByVal _ExecelLocation As String) As DataTable
        Dim connectionStringTemplate As String = _
            "Provider=Microsoft.ACE.OLEDB.12.0;" + _
            "Data Source={0};" + _
            "Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"""
        Dim XLSPath As String = _ExecelLocation
        Dim connectionString As String = String.Format(connectionStringTemplate, XLSPath)
        If SheetName Is Nothing Then
            Try
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Dim sqlSelect As String = "SELECT * FROM [" & SheetName & "$A8:L];"
            ' Load the Excel worksheet into a DataTable
            Dim workbook As DataSet = New DataSet()
            Dim excelAdapter As System.Data.Common.DataAdapter = New System.Data.OleDb.OleDbDataAdapter(sqlSelect, connectionString)
            Try
                excelAdapter.Fill(workbook)
                Dim worksheet As DataTable = workbook.Tables(0)
                Return worksheet
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function
    Public Function CheckIfExist(ByVal _ExcelFile) As Boolean
        Dim _Result As Boolean = False
        If System.IO.File.Exists(_ExcelFile) = True Then
            _Result = True
        End If
        Return _Result
    End Function
End Class
