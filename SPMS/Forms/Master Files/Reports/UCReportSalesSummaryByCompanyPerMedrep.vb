Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

Public Class UCReportSalesSummaryByCompanyPerMedrep
    Dim table As New DataTable

    Private Sub UCReportSalesSummaryByCompanyPerMedrep_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(Me.DataGridView1)
        FillComboYear()
        chckAll.Checked = True
    End Sub

    Sub FillComboYear()

        table = GetRecords("SELECT DISTINCT CAYR FROM CALENDAR WHERE COMID='" & ConnectionModule.GetDefaultCompany & "'")

        For i As Integer = 0 To table.Rows.Count - 1
            cmbStartYear.Items.Add(table.Rows(i)(0))
            cmbEndYear.Items.Add(table.Rows(i)(0))
        Next
        LoadDivision()
    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        RefreshData()
    End Sub

    Sub RefreshData()

        table = GetRecords("Exec uspSalesSummary_Detailed @STARTYEAR='" & cmbStartYear.Text & "',@STARTMONTH='" & cmbStartMonth.Text & "',@ENDYEAR='" & cmbEndYear.Text & "',@ENDMONTH='" & cmbEndMonth.Text & "',@DIVCD='" & cmbDivisionCode.Text & "'")
        'Me.DataGridView1.ro
        Me.DataGridView1.DataSource = table
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

    Private Sub Export()
        'On Error GoTo errHandler
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


        objSheet.Name = "Summary by Company Per Rep"

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
        objBook.SaveAs("Summary by Company Per Medrep", Excel.XlFileFormat.xlWorkbookNormal, System.Reflection.Missing.Value, System.Reflection.Missing.Value, True, False, Excel.XlSaveAsAccessMode.xlNoChange, False, False, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
        Exit Sub
errHandler:
        objExcel.Quit()
    End Sub

    Private Sub cmbStartYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStartYear.SelectedIndexChanged
        table = GetRecords("SELECT DISTINCT CAPN FROM CALENDAR WHERE CAYR ='" & cmbStartYear.Text & "' AND COMID='" & ConnectionModule.GetDefaultCompany & "'")
        cmbStartMonth.Items.Clear()
        For I As Integer = 0 To table.Rows.Count - 1
            cmbStartMonth.Items.Add(table.Rows(I)(0))
        Next
    End Sub

    Private Sub cmbEndYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEndYear.SelectedIndexChanged
        table = GetRecords("SELECT DISTINCT CAPN FROM CALENDAR WHERE CAYR ='" & cmbEndYear.Text & "' AND COMID='" & ConnectionModule.GetDefaultCompany & "'")
        cmbEndMonth.Items.Clear()
        For I As Integer = 0 To table.Rows.Count - 1
            cmbEndMonth.Items.Add(table.Rows(I)(0))
        Next
    End Sub

    Sub LoadDivision()
        table = GetRecords("SELECT DISTINCT DIVCD ,B.ITMDIVNAME " & _
                            "FROM cust_div_item_sales  A " & _
                             "LEFT JOIN ItemDivision B " & _
                              "ON A.DIVCD = B.ITMDIVCD ")
        For i As Integer = 0 To table.Rows.Count - 1
            cmbDivisionCode.Items.Add(table.Rows(i)(0))
            cmbDivisionName.Items.Add(table.Rows(i)(1))
        Next
    End Sub

    Private Sub cmbDivisionCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDivisionCode.SelectedIndexChanged
        cmbDivisionName.SelectedIndex = cmbDivisionCode.SelectedIndex
    End Sub

    Private Sub cmbDivisionName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDivisionName.SelectedIndexChanged
        cmbDivisionCode.SelectedIndex = cmbDivisionName.SelectedIndex
    End Sub

    Private Sub chckAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckAll.CheckedChanged
        If chckAll.Checked = True Then
            cmbDivisionCode.SelectedIndex = -1
            cmbDivisionName.SelectedIndex = -1
            cmbDivisionCode.Enabled = False
            cmbDivisionName.Enabled = False
        Else
            cmbDivisionCode.SelectedIndex = 0
            cmbDivisionName.SelectedIndex = 0
            cmbDivisionCode.Enabled = True
            cmbDivisionName.Enabled = True
        End If
    End Sub
End Class
