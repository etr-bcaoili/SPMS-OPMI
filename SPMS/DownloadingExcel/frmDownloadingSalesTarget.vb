Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.GlobalFunctionsModule
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports Excel = Microsoft.Office.Interop.Excel
'Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Public Class frmDownloadingSalesTarget
    Dim table As New DataTable
    Dim dt As New DataTable
    Dim m_colleccompmoyr As New RebatesCompanyMonthYearCollection
    Dim m_compmoyr As New RebatesCompanyMonthYear
    Dim _ExcelResult As New ExcelUploading
    Dim m_Err As New ErrorProvider
    Dim Has_Error As Boolean = False
    Private m_CompanyName As String
    Private Sub cboyear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboyear.SelectedIndexChanged
        If cboyear.SelectedIndex = -1 Then Exit Sub
        LoadYear(cboyear.Text)
    End Sub
    Private Sub LoadYear(ByVal DistributorCode As String)
        table = GetRecords("SELECT Distinct CAYR  FROM Calendar WHERE COMID = '" & DistributorCode & "' ")
        For i As Integer = 0 To table.Rows.Count - 1
            cboyear.Items.Add(table.Rows(i)("CAYR"))
        Next
        _ExcelResult.Year = cboyear.Text
    End Sub
    Private Sub LoadMonth(ByVal DistributorCode As String, ByVal Year As String)

        table = GetRecords("SELECT * FROM Calendar WHERE COMID = '" & DistributorCode & "' AND CAYR = '" & Year & "' ")
        For I As Integer = 0 To table.Rows.Count - 1
            cboCompany.Items.Add(table.Rows(I)("CAPN"))
        Next
        _ExcelResult.Month = cboCompany.Text
    End Sub

    Private Sub frmDownloadingSalesTarget_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillComboBox()
        PopulateComboBox()
    End Sub
    Private Sub PopulateComboBox()
        table = GetRecords("Select * from Configurationtype")
        For I As Integer = 0 To table.Rows.Count - 1
            cboCompany.Items.Add(table.Rows(I)("Configtypecode"))
        Next
    End Sub

    Private Sub FillComboBox()
        m_colleccompmoyr = m_compmoyr.YearLoader
        For x As Integer = 0 To m_colleccompmoyr.Count - 1
            cboyear.Items.Add(m_colleccompmoyr.Item(x).Year)
        Next
        m_colleccompmoyr = m_compmoyr.MonthLoader
    End Sub

    Private Sub cboCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCompany.SelectedIndexChanged
        If cboCompany.SelectedIndex = -1 Then Exit Sub
        LoadYear(cboCompany.Text)
    End Sub

    Private Sub lblUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender Is Label3 Then
            If Validatedata() Then
                Downloadingdata()
            End If
        End If
    End Sub
    Private Function Validatedata() As Boolean
        m_Err.Clear()
        Has_Error = False
        If cboCompany.Text = String.Empty Then
            m_Err.SetError(cboCompany, "Select the Company")
            Has_Error = True
        End If
        If cboyear.Text = String.Empty Then
            m_Err.SetError(cboyear, "Select The Year")
            Has_Error = True
        End If
        Return Not Has_Error
    End Function
 
    Private Sub Downloadingdata()
        ProgressBar1.Visible = True

        table = GetRecords("Exec [uspSalesTargetDownloading] @Year = '" & cboyear.Text & "',@ConfigtypeCode = '" & cboCompany.Text & "'")
        If table.Rows.Count = 0 Then
            MsgBox("No transaction to be downloaded, please check your entries.", MsgBoxStyle.Information)
        Else
            Label3.Enabled = False
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
        objBook.SaveAs("C:\MY SPMS DOWNLOAD\SALES TARGET.xls")
        objBook.Close()
        'objBook.SaveAs("Billing Order Download", Excel.XlFileFormat.xlWorkbookNormal, System.Reflection.Missing.Value, System.Reflection.Missing.Value, True, False, Excel.XlSaveAsAccessMode.xlNoChange, False, False, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
        Exit Sub
errHandler:


        objExcel.Quit()

    End Sub

    Private Sub lblcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        If sender Is Label3 Then
            If CheckBox1.Checked = True Then
                DownloadingDefualt()
            Else
                If Validatedata() Then
                    Downloadingdata()
                End If
            End If
        End If
    End Sub
    Private Sub DownloadingDefualt()
        ProgressBar1.Visible = True

        table = GetRecords("Exec [uspSalesTargetDownloading] @Year = '" & cboyear.Text & "',@Configtypecode = '" & "GPI" & "'")
        If table.Rows.Count = 0 Then
            MsgBox("No transaction to be downloaded, please check your entries.", MsgBoxStyle.Information)
        Else
            Label3.Enabled = False
            Export()
            Me.Cursor = Cursors.Default
            MsgBox("The Territory ItemTarget is Successfully Downloaded in " & "Drive C:\MY SPMS Donwloading" & "Folder.", MsgBoxStyle.Information, "")
            Me.Close()
        End If
    End Sub

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            cboCompany.Enabled = False
        End If
    End Sub
End Class