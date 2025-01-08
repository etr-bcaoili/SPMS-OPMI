Imports SPMSOPCI.ConnectionModule
Imports System.Data
Imports System.Data.SqlClient


Imports Microsoft.Office.Interop
'Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices

Public Class UCReportGeographicalMap

    Private bindingSource1 As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Private table As New DataTable()

    Private Sub GetData(ByVal selectCommand As String)

        Try
            ' Specify a connection string. Replace the given value with a 
            ' valid connection string for a Northwind SQL Server sample
            ' database accessible to your system.
            Dim connectionString As String = ""

            If SqlConnectionExists() = True Then
                connectionString = GetSqlconnectionPath()

            Else
                connectionString = "data source=192.168.0.2; initial catalog=SPMS; user id=sa; password=;"
            End If

            ' Create a new data adapter based on the specified query.
            Me.dataAdapter = New SqlDataAdapter(selectCommand, connectionString)

            ' Create a command builder to generate SQL update, insert, and
            ' delete commands based on selectCommand. These are used to
            ' update the database.
            Dim commandBuilder As New SqlCommandBuilder(Me.dataAdapter)

            ' Populate a new data table and bind it to the BindingSource.
            ' Dim table As New DataTable()
            table = New DataTable
            table.Locale = System.Globalization.CultureInfo.InvariantCulture
            Me.dataAdapter.Fill(table)
            Me.bindingSource1.DataSource = table

            ' Right Align double data types
            Dim style As DataGridViewCellStyle
            Dim i As Integer
            Dim j As Decimal
            style = New DataGridViewCellStyle()
            style.Alignment = DataGridViewContentAlignment.MiddleRight
            i = 0
            While i < DataGridView1.ColumnCount
                If (DataGridView1.Columns.Item(i).ValueType Is j.GetType) Then
                    DataGridView1.Columns.Item(i).DefaultCellStyle = style
                End If
                i = i + 1
            End While


        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        Me.DataGridView1.ClearSelection()
        'Me.Label4.Text = "Sales Report for Current Month"
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData(" EXECUTE uspMasterZipCode ")
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

    Private Sub UCReportMasterFileDownload_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(DataGridView1)
    End Sub

    Private Function RsLockedCompany(Optional ByVal Filter As String = "", Optional ByVal Orderby As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " where " & Filter
        End If
        If Orderby <> "" Then
            Orderby = " order by " & Orderby

        End If
        rs.Open("select * from company" & Filter & Orderby, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function



    Private Sub Export()
        On Error GoTo errHandler
        'Create the Excel object declaration

        ' create a excel application object
        Dim objExcel As Excel.Application = Nothing
        ' create a excel workbooks object
        Dim objBooks As Excel.Workbooks = Nothing
        ' create a workbook object
        Dim objBook As Excel.Workbook = Nothing
        ' create a excel sheets object
        Dim objSheets As Excel.Sheets = Nothing
        ' create a excel sheet object
        Dim objSheet As Excel.Worksheet = Nothing
        ' create a excel range object
        Dim objRange As Excel.Range = Nothing

        Dim rs As New ADODB.Recordset
        rs = RsLockedCompany()
        If rs.RecordCount > 0 Then
            ConvertBytesToImageFile(rs.Fields("CompanyLogo").Value, ReturnExePath() & "\companylogo.jpg")
        End If


        ' Create a new object of the Excel application object
        objExcel = New Excel.Application
        objExcel.Visible = True
        objExcel.DisplayAlerts = False
        ' Adding a collection of Workbooks to the Excel object
        objBook = CType(objExcel.Workbooks.Add(), Excel.Workbook)

        objBooks = objExcel.Workbooks
        objSheet = CType(objBooks(1).Sheets.Item(1), Excel.Worksheet)
        objSheets = objBook.Worksheets
        ' Adding multiple worksheets to workbook
        objSheets.Add(Count:=6)

        ' Summary log file sheet
        ' adding first sheet as summary log file
        objBook = objBooks.Item(1)
        objSheet = CType(objSheets.Item(1), Excel.Worksheet)

        Dim pic As New Object
        pic = objSheet.Pictures.Insert(ReturnExePath() & "\companylogo.jpg")

        With pic
            .height = 50
            .top = objSheet.Cells(1, 1).top
            .left = objSheet.Cells(1, 1).left
        End With


        objSheet.Name = "SalesAchievementTerritoryWise"
        objSheet.Range("A4", "A6").Font.Size = 14
        objSheet.Range("A4", "A6").Font.Bold = True
        'objExcel.Cells(4, 1).value = rs.Fields("COMNAME").Value
        objExcel.Cells(5, 1).value = lblTitle.Text
        'objExcel.Cells(6, 1).value = "Date Range: " & cmbStartYear.Text & " " & cmbStartMonth.Text & " To " & cmbEndYear.Text & " " & cmbEndMonth.Text


        For i As Integer = 0 To table.Columns.Count - 1
            objSheet.Range("A8", "ZA8").Font.Size = 12
            objSheet.Range("A8", "ZA8").Font.Bold = True

            objExcel.Cells(8, i + 1).value = table.Columns(i).ColumnName
        Next
        For i As Integer = 9 To table.Rows.Count + 8
            Dim dr As DataRow = table.Rows(i - 9)

            For o As Integer = 0 To table.Columns.Count - 1
                objExcel.Cells(i, o + 1).value = dr.Item(o)
            Next
        Next
        objSheet.Range("B1:az400").EntireColumn.AutoFit()
        DeleteObject(ReturnExePath() & "\companylogo.jpg")

        ' Focus on summary log file sheet

        objSheet = objBook.ActiveSheet()
        Dim objFirstSheet As Excel.Worksheet
        objSheets = objBook.Worksheets
        objFirstSheet = CType(objSheets.Item(1), Excel.Worksheet)
        objFirstSheet.Activate()

        Marshal.ReleaseComObject(objSheet)
        Marshal.ReleaseComObject(objSheets)

        'Saving the Workbook as a normal workbook format under log location
        objBook.SaveAs("Geographical Map Master List", Excel.XlFileFormat.xlWorkbookNormal, System.Reflection.Missing.Value, System.Reflection.Missing.Value, True, False, Excel.XlSaveAsAccessMode.xlNoChange, False, False, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)




        Exit Sub
errHandler:

        objExcel.Quit()

    End Sub



    '    Private Sub Export()
    '        On Error GoTo errHandler
    '        'Create the Excel object declaration

    '        ' create a excel application object
    '        Dim objExcel As Excel.Application = Nothing
    '        ' create a excel workbooks object
    '        Dim objBooks As Excel.Workbooks = Nothing
    '        ' create a workbook object
    '        Dim objBook As Excel.Workbook = Nothing
    '        ' create a excel sheets object
    '        Dim objSheets As Excel.Sheets = Nothing
    '        ' create a excel sheet object
    '        Dim objSheet As Excel.Worksheet = Nothing
    '        ' create a excel range object
    '        Dim objRange As Excel.Range = Nothing

    '        ' Create a new object of the Excel application object
    '        objExcel = New Excel.Application
    '        objExcel.Visible = True
    '        objExcel.DisplayAlerts = False
    '        ' Adding a collection of Workbooks to the Excel object
    '        objBook = CType(objExcel.Workbooks.Add(), Excel.Workbook)

    '        objBooks = objExcel.Workbooks
    '        objSheet = CType(objBooks(1).Sheets.Item(1), Excel.Worksheet)
    '        objSheets = objBook.Worksheets
    '        ' Adding multiple worksheets to workbook
    '        objSheets.Add(Count:=6)

    '        ' Summary log file sheet
    '        ' adding first sheet as summary log file
    '        objBook = objBooks.Item(1)
    '        objSheet = CType(objSheets.Item(1), Excel.Worksheet)


    '        objSheet.Name = "Geographical Map Master List"




    '        For i As Integer = 0 To table.Columns.Count - 1
    '            objExcel.Cells(1, i + 1).value = table.Columns(i).ColumnName
    '        Next
    '        For i As Integer = 2 To table.Rows.Count + 1
    '            Dim dr As DataRow = table.Rows(i - 2)

    '            For o As Integer = 0 To table.Columns.Count - 1
    '                objExcel.Cells(i, o + 1).value = dr.Item(o)
    '            Next
    '        Next


    '        ' Focus on summary log file sheet
    '        objSheet = objBook.ActiveSheet()
    '        Dim objFirstSheet As Excel.Worksheet
    '        objSheets = objBook.Worksheets
    '        objFirstSheet = CType(objSheets.Item(1), Excel.Worksheet)
    '        objFirstSheet.Activate()

    '        Marshal.ReleaseComObject(objSheet)
    '        Marshal.ReleaseComObject(objSheets)

    '        'Saving the Workbook as a normal workbook format under log location
    '        objBook.SaveAs("Geographical Map Master List Report", Excel.XlFileFormat.xlWorkbookNormal, System.Reflection.Missing.Value, System.Reflection.Missing.Value, True, False, Excel.XlSaveAsAccessMode.xlNoChange, False, False, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
    '        Exit Sub
    'errHandler:
    '        ShowInformation(Err.Description, "")
    '        objExcel.Quit()
    '    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
    End Sub

End Class
