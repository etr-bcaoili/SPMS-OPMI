Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

Public Class UCReportSalesSummaryByCompany
    Private bindingSource1 As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Private table As New DataTable()

    Private m_Err As New ErrorProvider
    Dim dv As New DataView

    Private Sub UCReportSalesSummaryByCompany_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(Me.DataGridView1)
        FillComboBox()
    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        RefreshData()
    End Sub

    Sub RefreshData()
        Me.DataGridView1.ClearSelection()

        table = GetRecords("Exec uspSalesSummary @STARTYEAR='" & cmbStartYear.Text & "',@ENDYEAR='" & cmbEndYear.Text & "',@STARTMONTH='" & cmbStartMonth.Text & "',@ENDMONTH='" & cmbEndMonth.Text & "'")

        Me.DataGridView1.DataSource = table
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Sub FillComboBox()

        table = GetRecords("SELECT DISTINCT CAYR FROM CALENDAR WHERE COMID='" & ConnectionModule.GetDefaultCompany & "'")

        For i As Integer = 0 To table.Rows.Count - 1
            cmbStartYear.Items.Add(table.Rows(i)(0))
            cmbEndYear.Items.Add(table.Rows(i)(0))
        Next

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

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


        objSheet.Name = "Sales Summary by Company"

        For i As Integer = 0 To table.Columns.Count - 1
            objExcel.Cells(1, i + 1).value = table.Columns(i).ColumnName
        Next
        For i As Integer = 2 To table.Rows.Count + 1
            Dim dr As DataRow = table.Rows(i - 2)

            For o As Integer = 0 To table.Columns.Count - 1
                objExcel.Cells(i, o + 1).value = dr.Item(o)
            Next
        Next
        ' Focus on summary log file sheet
        objSheet = objBook.ActiveSheet()
        Dim objFirstSheet As Excel.Worksheet
        objSheets = objBook.Worksheets
        objFirstSheet = CType(objSheets.Item(1), Excel.Worksheet)
        objFirstSheet.Activate()

        Marshal.ReleaseComObject(objSheet)
        Marshal.ReleaseComObject(objSheets)

        'Saving the Workbook as a normal workbook format under log location
        objBook.SaveAs("Sales Summary by Company", Excel.XlFileFormat.xlWorkbookNormal, System.Reflection.Missing.Value, System.Reflection.Missing.Value, True, False, Excel.XlSaveAsAccessMode.xlNoChange, False, False, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
        Exit Sub
errHandler:
        objExcel.Quit()
    End Sub

    Private Sub cmbStartYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStartYear.SelectedIndexChanged
        table = GetRecords("SELECT DISTINCT CAPN FROM CALENDAR WHERE CAYR='" & cmbStartYear.Text & "' AND COMID='" & ConnectionModule.GetDefaultCompany & "'")
        cmbStartMonth.Items.Clear()
        For I As Integer = 0 To table.Rows.Count - 1
            cmbStartMonth.Items.Add(table.Rows(I)(0))
        Next
    End Sub

    Private Sub cmbEndYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEndYear.SelectedIndexChanged
        table = GetRecords("SELECT DISTINCT CAPN FROM CALENDAR WHERE CAYR='" & cmbEndYear.Text & "' AND COMID='" & ConnectionModule.GetDefaultCompany & "'")
        cmbEndMonth.Items.Clear()
        For I As Integer = 0 To table.Rows.Count - 1
            cmbEndMonth.Items.Add(table.Rows(I)(0))
        Next
    End Sub
End Class
