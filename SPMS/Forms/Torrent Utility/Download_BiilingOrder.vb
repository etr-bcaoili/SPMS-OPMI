Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.GlobalFunctionsModule
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports Excel = Microsoft.Office.Interop.Excel
'Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Public Class Download_BiilingOrder
    Private dataAdapter As New SqlDataAdapter()
    Private table As New DataTable()
    Dim dv As New DataView
    Dim m_err As New ErrorProvider
    Dim Has_Error As Boolean = False
    Dim m_Month As New Calendar

    Private Sub Download_BiilingOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Combox_Customer()
    End Sub
    Private Sub Combox_Customer()
        table = GetRecords("SELECT * FROM DISTRIBUTOR WHERE DLTFLG = 0")
        For i As Integer = 0 To table.Rows.Count - 1
            cboCustomer.Items.Add(table.Rows(i)(2))
        Next
    End Sub

    Private Sub LoadYear(ByVal DistributorCode As String)
        m_Month = New Calendar
        table = GetRecords("SELECT Distinct CAYR  FROM Calendar WHERE COMID = '" & DistributorCode & "' ")
        For i As Integer = 0 To table.Rows.Count - 1
            cmbYear.Items.Add(table.Rows(i)("CAYR"))
        Next
    End Sub
    Private Sub LoadMonth(ByVal DistributorCode As String, ByVal Year As String)

        table = GetRecords("SELECT Distinct CAPN FROM Calendar WHERE COMID = '" & DistributorCode & "' AND CAYR = '" & Year & "' ")
        For i As Integer = 0 To table.Rows.Count - 1
            cmbMonth.Items.Add(table.Rows(i)("CAPN"))
        Next

    End Sub

    Private Sub cmbYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.SelectedIndexChanged
        If cmbYear.SelectedIndex = -1 Then Exit Sub
        LoadMonth(cboCustomer.Text, cmbYear.Text)
    End Sub
   
    Private Sub cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedIndexChanged
        If cboCustomer.SelectedIndex = -1 Then Exit Sub
        LoadYear(cboCustomer.Text)

    End Sub

   
    Private Sub DownloadedFile()
        'Try

        ProgressBar1.Visible = True
        table = GetRecords(" EXEC [uspBillingOrderDownload] @Cutmo = ' " & cmbMonth.Text & "',@cutyear = '" & cmbYear.Text & "',@Comid = '" & cboCustomer.Text & "'")
        If table.Rows.Count = 0 Then
            MsgBox("No transaction to be downloaded, please check your entries.", MsgBoxStyle.Information)
        Else
            Label1.Visible = True
            Export()
            MsgBox("File Successfully Downloaded", MsgBoxStyle.Information, "Download")
            Me.Close()
        End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

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


        str = cboCustomer.Text & " " & cmbMonth.Text & " " & cmbYear.Text


        For i As Integer = 0 To table.Columns.Count - 1

            objExcel.Cells(1, i + 1).value = table.Columns(i).ColumnName
        Next
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
        objBook.SaveAs("C:\MY SPMS DOWNLOAD\Sales Order\" & str & ".xls")
        objBook.Close()
        'objBook.SaveAs("Billing Order Download", Excel.XlFileFormat.xlWorkbookNormal, System.Reflection.Missing.Value, System.Reflection.Missing.Value, True, False, Excel.XlSaveAsAccessMode.xlNoChange, False, False, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
        Exit Sub
errHandler:


        objExcel.Quit()


    End Sub
    Private Function ValidateData() As Boolean
        m_err.Clear()
        Has_Error = False

        If cboCustomer.Text = "" Then
            m_err.SetError(cboCustomer, "Company Code is empty")
            Has_Error = True
        End If
        If cmbMonth.Text = "" Then
            m_err.SetError(cmbMonth, "Month of Billing Download is empty")
            Has_Error = True
        End If
        If cmbYear.Text = "" Then
            m_err.SetError(cmbYear, "Year of Billing Download is empty")
            Has_Error = True
        End If
        Return Not Has_Error
    End Function

    'Private Sub lblDownloaded_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblDownloaded.LinkClicked
    '    If sender Is lblDownloaded Then

    '        If ValidateData() Then
    '            DownloadedFile()
    '            Label1.Visible = True
    '        ElseIf sender Is lblClose Then
    '            Me.Close()
    '        End If
    '    End If
    'End Sub

    Private Sub lblClose_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Close()
    End Sub

    Private Sub btnDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click
        If sender Is btnDownload Then
            If ValidateData() Then
                DownloadedFile()

            ElseIf sender Is btnClose Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class