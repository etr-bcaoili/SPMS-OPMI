Imports System.Drawing
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Collections.Generic
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class ExcelSalesMatrix

    Private s_ConfigTypeCode As String
    Private s_EffectivityStartDate As Date
    Private s_EffectivityEndDate As Date
    Private s_Path As String
    Dim m_sheetName

    Public Property ConfigTypeCode() As String
        Get
            Return s_ConfigTypeCode
        End Get
        Set(value As String)
            s_ConfigTypeCode = value
        End Set
    End Property

    Public Property EffectivityStartDate() As Date
        Get
            Return s_EffectivityStartDate
        End Get
        Set(value As Date)
            s_EffectivityStartDate = value
        End Set
    End Property

    Public Property EffectivityEndDate() As Date
        Get
            Return s_EffectivityEndDate
        End Get
        Set(value As Date)
            s_EffectivityEndDate = value
        End Set
    End Property

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

    Public Property _ExcelLocation() As String
        Get
            Return s_Path
        End Get
        Set(value As String)
            s_Path = value
        End Set
    End Property

    Public Function GetExcelData(ByVal _ExecelLocation As String) As DataTable
        Dim connectionStringTemplate As String = _
            "Provider=Microsoft.ACE.OLEDB.12.0;" + _
            "Data Source={0};" + _
            "Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"""
        Dim XLSPath As String = _ExecelLocation
        If SheetName Is Nothing Then
            Try
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Dim connectionString As String = String.Format(connectionStringTemplate, XLSPath)
            Dim sqlSelect As String = "SELECT * FROM [" & SheetName & "$A8:L];"
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
