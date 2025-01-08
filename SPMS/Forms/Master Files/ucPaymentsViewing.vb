Imports System.Data.SqlClient
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.GlobalFunctionsModule
Imports Microsoft.Office.Interop
'Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices


Public Class ucPaymentsViewing

    Dim paymentview As New RebatesPayment
    Dim tableName As DataGridViewHeaderCell
    Dim dvpayholder As DataView
    Dim m_customernumber As String
    Dim m_invoicenumber As String

    Dim m_compmoyr As New RebatesCompanyMonthYear
    Dim m_colleccompmoyr As New RebatesCompanyMonthYearCollection

    '-----
    Dim rbcache As New RebatesCache
    '-----
    Private dataAdapter As New SqlDataAdapter()
    Private table As New DataTable()

    Private Sub ucPaymentsViewing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ApplyGridTheme(paymentsviewdgv)

        cmboxCompCode.DropDownStyle = ComboBoxStyle.DropDownList
        cmboxMonth.DropDownStyle = ComboBoxStyle.DropDownList
        cmboxYear.DropDownStyle = ComboBoxStyle.DropDownList

        FillComboBox()


    End Sub

    Private Sub FillComboBox()
        m_colleccompmoyr = m_compmoyr.YearLoader


        For x As Integer = 0 To m_colleccompmoyr.Count - 1
            cmboxYear.Items.Add(m_colleccompmoyr.Item(x).Year)
        Next

        m_colleccompmoyr = m_compmoyr.MonthLoader

        For x As Integer = 0 To m_colleccompmoyr.Count - 1
            cmboxMonth.Items.Add(m_colleccompmoyr.Item(x).Month)
        Next

        m_colleccompmoyr = m_compmoyr.CompanyCodeLoader("RebatesDetail")

        For x As Integer = 0 To m_colleccompmoyr.Count - 1
            cmboxCompCode.Items.Add(m_colleccompmoyr.Item(x).CompanyCode)
        Next


    End Sub


    Private Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Load.Click

        Dim selectedcompany As String = cmboxCompCode.Text
        Dim selectedmonth As String = cmboxMonth.Text
        Dim selectedyear As String = cmboxYear.Text

        If VerifyCompCode() = True Then 'And VerifyCutMo() = True And VerifyCutYr() = True Then


            ApplyGridTheme(paymentsviewdgv)
            paymentsviewdgv.ReadOnly = True

            paymentsviewdgv.Columns.Clear()

            FillPaymentsDGV(selectedcompany, selectedmonth, selectedyear)

        End If


    End Sub

    Private Sub Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close.Click
        On Error Resume Next
        Dim m_tabPage As TabPage = Me.Parent
        CType(m_tabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_tabPage)
        Me.Dispose()
    End Sub

    '=====
    Private Sub FillPaymentsDGV(ByVal companycode As String, ByVal cmmonth As Integer, ByVal cmyear As Integer)

        Dim rpayment_collec As New RebatesPaymentCollection
        Dim x As Integer = 0

        rpayment_collec = RebatesPayment.Filter(companycode, cmmonth, cmyear)
        x = rpayment_collec.Count


        paymentsviewdgv.Columns.Add("colCompanyCode", "CompanyCode")
        paymentsviewdgv.Columns.Add("colCustomerNumber", "CustomerNumber")
        paymentsviewdgv.Columns.Add("colCustomerName", "CustomerName")
        paymentsviewdgv.Columns.Add("colPayTo", "PayTo")
        paymentsviewdgv.Columns.Add("colTransactionDate", "TransactionDate")
        paymentsviewdgv.Columns.Add("colInvoiceNumber", "InvoiceNumber")
        paymentsviewdgv.Columns.Add("colNetAmount", "NetAmount")
        paymentsviewdgv.Columns.Add("colCUTMO", "CUTMO")
        paymentsviewdgv.Columns.Add("colCUTYEAR", "CUTYEAR")
        paymentsviewdgv.Columns.Add("colRebatesPercentage", "RebatesPercentage")
        paymentsviewdgv.Columns.Add("colRebatesValue", "RebatesValue")
        paymentsviewdgv.Columns.Add("colCheckNumber", "CheckNumber")
        paymentsviewdgv.Columns.Add("colCheckDate", "CheckDate")
        paymentsviewdgv.Columns.Add("colPaymentAmount", "PaymentAmount")
        paymentsviewdgv.Columns.Add("colRemainingBalance", "RemainingBalance")
        paymentsviewdgv.Columns.Add("colStatus", "Status")
        paymentsviewdgv.Columns.Add("ColSalesAgent", "SalesAgent")


        For i As Integer = 0 To x - 1

            Dim rows As DataGridViewRow = paymentsviewdgv.Rows(paymentsviewdgv.Rows.Add)

            rows.Cells("colCompanyCode").Value = rpayment_collec.Item(i).CompanyCode
            rows.Cells("colCustomerNumber").Value = rpayment_collec.Item(i).CustomerNumber
            rows.Cells("colCustomerName").Value = rpayment_collec.Item(i).CustomerName
            rows.Cells("colPayTo").Value = rpayment_collec.Item(i).PayTo
            rows.Cells("colTransactionDate").Value = rpayment_collec.Item(i).TransactionDate
            rows.Cells("colInvoiceNumber").Value = rpayment_collec.Item(i).InvoiceNumber
            rows.Cells("colNetAmount").Value = rpayment_collec.Item(i).NetAmount
            rows.Cells("colCUTMO").Value = rpayment_collec.Item(i).CutMo
            rows.Cells("colCUTYEAR").Value = rpayment_collec.Item(i).CutYear
            rows.Cells("colRebatesPercentage").Value = rpayment_collec.Item(i).RebatesPercentage
            rows.Cells("colRebatesValue").Value = rpayment_collec.Item(i).RebatesValue
            rows.Cells("colCheckNumber").Value = rpayment_collec.Item(i).CheckNumber
            rows.Cells("colCheckDate").Value = rpayment_collec.Item(i).CheckDate
            rows.Cells("colPaymentAmount").Value = rpayment_collec.Item(i).PaymentAmount
            rows.Cells("colRemainingBalance").Value = rpayment_collec.Item(i).RemainingBalance
            rows.Cells("colStatus").Value = rpayment_collec.Item(i).Status
            rows.Cells("colSalesAgent").Value = rpayment_collec.Item(i).SalesCodes

        Next

    End Sub

    '=====

    Private Sub ExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcel.Click
        Export()
    End Sub


    Private Sub Export()

        Dim saveFileDialog1 As New SaveFileDialog
        saveFileDialog1.Filter = "Excel File|*.xls"
        saveFileDialog1.Title = "Save an Excel File"
        saveFileDialog1.ShowDialog()
        If saveFileDialog1.FileName <> "" Then
            saveExcelFile(saveFileDialog1.FileName)
        End If
    End Sub

    Private Sub saveExcelFile(ByVal FileName As String)

        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer

        xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("Sheet1")



        For i = 0 To paymentsviewdgv.RowCount - 1
            For j = 0 To paymentsviewdgv.ColumnCount - 1
                For k As Integer = 1 To paymentsviewdgv.Columns.Count
                    xlWorkSheet.Cells(1, k) = paymentsviewdgv.Columns(k - 1).HeaderText
                    xlWorkSheet.Cells(i + 2, j + 1) = paymentsviewdgv(j, i).Value.ToString()
                Next
            Next
        Next

        xlWorkSheet.SaveAs(FileName)
        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

        MsgBox(" Successfull Export PaymentRebates")
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

    '        Dim rpreport As New RebatesCollection
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


    '        objSheet.Name = "PaymentRebates"




    '        For i As Integer = 0 To rptable.Columns.Count - 1
    '            objExcel.Cells(1, i + 1).value = rptable.Columns(i).ColumnName
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
    '        objBook.SaveAs("Payment Rebates ", Excel.XlFileFormat.xlWorkbookNormal, System.Reflection.Missing.Value, System.Reflection.Missing.Value, True, False, Excel.XlSaveAsAccessMode.xlNoChange, False, False, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
    '        Exit Sub
    'errHandler:

    '        objExcel.Quit()
    'End Sub


    Private Sub txtCustNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustNumber.TextChanged
        Filter()

    End Sub

    Private Sub txtInvNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvNumber.TextChanged
        Filter()


    End Sub


    Private Function VerifyCompCode() As Boolean

        If cmboxCompCode.Text = "" Then
            MsgBox("Select a Company")
        ElseIf cmboxYear.Text = "" Then
            MsgBox("Select a Year")
        ElseIf cmboxMonth.Text = "" Then
            MsgBox("Select a Month")

        Else
            cmboxCompCode.Text = cmboxCompCode.Text
            cmboxYear.Text = cmboxYear.Text
            cmboxMonth.Text = cmboxMonth.Text
            Return True
        End If
        Return False

    End Function

    Private Function VerifyCutMo() As Boolean

        If cmboxMonth.Text = "" Then
            MsgBox("Select a Month")
        Else
            cmboxMonth.Text = cmboxMonth.Text
            Return True
        End If
        Return False

    End Function

    Private Function VerifyCutYr() As Boolean

        If cmboxYear.Text = "" Then
            MsgBox("Select a Year")
        Else
            cmboxYear.Text = cmboxYear.Text
            Return True
        End If

        Return False

    End Function


    Private Sub Filter()
        rbcache.CustomerNumber = txtCustNumber.Text
        rbcache.InvoiceNumber = txtInvNumber.Text

        ' paymentsviewdgv.DataSource = rbcache.DVFilter(dtpayholder)
    End Sub

    Private Sub cboxcompcode_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmboxCompCode.SelectedIndexChanged

        Dim selecteditem As String = cmboxCompCode.Items(cmboxCompCode.SelectedIndex)

        cmboxCompCode.Text = selecteditem

    End Sub

    Private Sub cboxmo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmboxMonth.SelectedIndexChanged

        Dim selecteditem As String = cmboxMonth.Items(cmboxMonth.SelectedIndex)

        cmboxMonth.Text = selecteditem

    End Sub


    Private Sub cboxyr_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmboxYear.SelectedIndexChanged

        Dim selecteditem As String = cmboxYear.Items(cmboxYear.SelectedIndex)

        cmboxYear.Text = selecteditem

    End Sub


End Class
