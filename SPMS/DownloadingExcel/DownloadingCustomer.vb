Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.GlobalFunctionsModule
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports Excel = Microsoft.Office.Interop.Excel
'Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports System.IO
Public Class DownloadingCustomer
    Dim objApp As Excel.Application
    Dim objBook As Excel._Workbook
    Dim table As New DataTable
    Dim dt As New DataTable
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Downloadingdata()
    End Sub
    Private Sub Downloadingdata()

        Dim objBooks As Excel.Workbooks
        Dim objSheets As Excel.Sheets
        Dim objSheet As Excel._Worksheet
        Dim range As Excel.Range
        Dim b As String

        If Not File.Exists(ReturnExePath() & "\MY SPMS DOWNLOAD") Then
            Directory.CreateDirectory(ReturnExePath() & "\MY SPMS DOWNLOAD")
        End If
        Directory.CreateDirectory(ReturnExePath() & "\MY SPMS DOWNLOAD" & "\Customer")
        objApp = New Excel.Application()
        objBooks = objApp.Workbooks
        objBook = objBooks.Add
        objSheets = objBook.Worksheets
        Export(objBooks, objSheets, objSheet, range)
        objSheets.Select(1)
        If File.Exists(ReturnExePath() & "MY SPMS DOWNLOAD" & "\Customer\" & "Master list Customer.xls") Then
            Kill(ReturnExePath() & "MY SPMS DOWNLOAD" & "\Customer\" & "Master list Customer.xls")
        End If
        objApp.ActiveWorkbook.SaveAs(ReturnExePath() & "MY SPMS DOWNLOAD" & "\Customer" & "\Master list Customer", Excel.XlFileFormat.xlExcel8)
        objApp.Quit()
        range = Nothing
        objSheet = Nothing
        objSheets = Nothing
        objBooks = Nothing

        MsgBox("File Successfully Downloaded", MsgBoxStyle.Information, "Download")
        Me.Close()
    End Sub
    Public Sub export(ByVal objbooks As Excel.Workbooks, ByVal objsheets As Excel.Sheets, ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range)
        objsheet = objsheets.Add

        Dim Counter As Integer = 0
        Dim y As Integer = 1
        Dim yheader As Integer = 0
        Dim ctr As Integer = 0

        Connect()
        Dim cmd As New SqlCommand("uspDonwloadingCustomer", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@COMID", cbocompany.Text)
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        If dt.Rows.Count > 0 Then
            CreteHeaderCustomer(objsheet, range, y + yheader)
            For l As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Visible = True
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(l)
                objsheet.Cells(2 + Counter + l, 1) = dr("CHANNEL")
                objsheet.Cells(2 + Counter + l, 2) = "'" & dr("CUSTOMERCODE")
                objsheet.Cells(2 + Counter + l, 3) = dr("CUSTOMERNAME")
                objsheet.Cells(2 + Counter + l, 4) = "'" & dr("SHIPTOCODE")
                objsheet.Cells(2 + Counter + l, 5) = dr("SHIPTONAME")
                objsheet.Cells(2 + Counter + l, 6) = dr("ADDRESS1")
                objsheet.Cells(2 + Counter + l, 7) = dr("ADDRESS2")
                objsheet.Cells(2 + Counter + l, 8) = "'" & dr("REGIONCODE")
                objsheet.Cells(2 + Counter + l, 9) = dr("REGIONAME")
                objsheet.Cells(2 + Counter + l, 10) = "'" & dr("PROVINCECODE")
                objsheet.Cells(2 + Counter + l, 11) = dr("PROVINCENAME")
                objsheet.Cells(2 + Counter + l, 12) = "'" & dr("MUNICIPALITYCODE")
                objsheet.Cells(2 + Counter + l, 13) = dr("MUNICIPLITYNAME")
                objsheet.Cells(2 + Counter + l, 14) = "'" & dr("ZIPCODE")
                objsheet.Cells(2 + Counter + l, 15) = dr("CUSTOMERGROUP")
                objsheet.Cells(2 + Counter + l, 16) = dr("CUSTOMERGROUPNAME")
                objsheet.Cells(2 + Counter + l, 17) = "'" & dr("CUSTOMERCLASS")
                objsheet.Cells(2 + Counter + l, 18) = dr("CUSTOMERCLASSNAME")
                objsheet.Cells(2 + Counter + l, 19) = dr("ACCOUNT SHARED")
                ctr += 1
            Next
        End If

        ProgressBar1.Visible = False
    End Sub
    Private Sub CreteHeaderCustomer(ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)
        objsheet.Cells(y, 1) = "CHANNEL"
        objsheet.Cells(y, 2) = "CUSTOMERCODE"
        objsheet.Cells(y, 3) = "CUSTOMERNAME"
        objsheet.Cells(y, 4) = "SHIPTOCODE"
        objsheet.Cells(y, 5) = "SHIPTONAME"
        objsheet.Cells(y, 6) = "ADDRESS1"
        objsheet.Cells(y, 7) = "ADDRESS2"
        objsheet.Cells(y, 8) = "REGIONCODE"
        objsheet.Cells(y, 9) = "REGIONAME"
        objsheet.Cells(y, 10) = "PROVINCECODE"
        objsheet.Cells(y, 11) = "PROVINCENAME"
        objsheet.Cells(y, 12) = "MUNICIPALITYCODE"
        objsheet.Cells(y, 13) = "MUNICIPLITYNAME"
        objsheet.Cells(y, 14) = "ZIPCODE"
        objsheet.Cells(y, 15) = "CUSTOMERGROUP"
        objsheet.Cells(y, 16) = "CUSTOMERGROUPNAME"
        objsheet.Cells(y, 17) = "CUSTOMERCLASS"
        objsheet.Cells(y, 18) = "CUSTOMERCLASSNAME"
        objsheet.Cells(y, 19) = "ACCOUNT SHARED"

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
        objBook.SaveAs("C:\MY SPMS DOWNLOAD\CUSTOMER.xls")
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

    Private Sub DownloadingCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateComboBox()
    End Sub
    Private Sub PopulateComboBox()
        cbocompany.SelectedText = "All"
        table = GetRecords("SELECT * FROM DISTRIBUTOR WHERE DLTFLG = 0")
        For I As Integer = 0 To table.Rows.Count - 1
            cbocompany.Items.Add(table.Rows(I)("DISTCOMID"))
        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()

    End Sub

    Private Sub lblUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblUpload.Click
        Downloadingdata()
    End Sub

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        Me.Close()
    End Sub
End Class