Imports SPMSGPI.ConnectionModule
Imports SPMSGPI.GlobalFunctionsModule
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports Excel = Microsoft.Office.Interop.Excel
'Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Public Class ItempriceDownloading
    Dim m_Destributor As New ItempriceListUploading
    Dim table As New DataTable

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Downloadingdata()
    End Sub
    Private Sub Downloadingdata()
        ProgressBar1.Visible = True

        table = GetRecords("Exec [uspDonwloadingPriceslist] @COMID = '" & cbocompany.Text & "',@StartDate = '" & startDate.Text & "',@EndDate = '" & EndDate.Text & "'")
        If table.Rows.Count = 0 Then
            MsgBox("No transaction to be downloaded, please check your entries.", MsgBoxStyle.Information)
        Else

            Export()
            Me.Cursor = Cursors.Default
            MsgBox("File Successfully Downloaded", MsgBoxStyle.Information, "Download")
            Me.Close()
        End If
    End Sub

    Private Sub Export()

        On Error GoTo errHandler
        Dim crt As Integer = 0
        Dim str As String
        Dim repfile, rep1, r As String
        Dim Sheet1, xappl As Object
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


        objExcel = New Excel.Application
        'objExcel.Visible = True
        objExcel.DisplayAlerts = False
        ' Adding a collection of Workbooks to the Excel object
        objBook = CType(objExcel.Workbooks.Add(), Excel.Workbook)

        objBooks = objExcel.Workbooks
        objSheet = CType(objBooks(1).Sheets.Item(1), Excel.Worksheet)
        objSheets = objBook.Worksheets
        ' Adding multiple worksheets to workbook
        'objSheets = objBook.Worksheets("Sheet1")

        ' Summary log file sheet
        ' adding first sheet as summary log file
        objBook = objBooks.Item(1)
        objSheet = CType(objSheets.Item(1), Excel.Worksheet)





        For i As Integer = 0 To table.Columns.Count - 1

            objExcel.Cells(1, i + 1).value = table.Columns(i).ColumnName
        Next
        Me.Cursor = Cursors.WaitCursor
        For i As Integer = 2 To table.Rows.Count + 1
            ProgressBar1.Value = crt / table.Rows.Count * 100
            Dim dr As DataRow = table.Rows(i - 2)

            For o As Integer = 0 To table.Columns.Count - 1
                objExcel.Cells(i, o + 1).value = dr.Item(o)
            Next
            crt += 1
        Next

        ProgressBar1.Value = False

        ' Focus on summary log file sheet
        objSheet = objBook.ActiveSheet()
        Dim objFirstSheet As Excel.Worksheet
        objSheets = objBook.Worksheets
        objFirstSheet = CType(objSheets.Item(1), Excel.Worksheet)
        objFirstSheet.Activate()

        Marshal.ReleaseComObject(objSheet)
        Marshal.ReleaseComObject(objSheets)

        'Saving the Workbook as a normal workbook format under log location
        objBook.SaveAs("C:\MY SPMS DOWNLOAD\PRICELIST.xls")
        objBook.Close()
        'objBook.SaveAs("Billing Order Download", Excel.XlFileFormat.xlWorkbookNormal, System.Reflection.Missing.Value, System.Reflection.Missing.Value, True, False, Excel.XlSaveAsAccessMode.xlNoChange, False, False, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
        Exit Sub
errHandler:


        objExcel.Quit()
    End Sub


    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub ItempriceDownloading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadCompanylist()
        PopulateComboBox()
    End Sub
    Private Sub loadCompanylist()

    End Sub
    Private Sub PopulateComboBox()
        cbocompany.SelectedText = "All"
        table = GetRecords("SELECT * FROM DISTRIBUTOR WHERE DLTFLG = 0")
        For I As Integer = 0 To table.Rows.Count - 1
            cbocompany.Items.Add(table.Rows(I)("DISTCOMID"))
        Next
    End Sub

    Private Sub lblUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblUpload.Click
        Downloadingdata()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        Me.Close()
    End Sub
End Class