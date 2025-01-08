Imports SPMSOPCI.ConnectionModule
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports System.IO
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class FrmDownloadReportUtilty
    Dim objApp As Excel.Application
    Dim objBook As Excel._Workbook
    Dim dt As New DataTable
    Dim dt2 As New DataTable
    Private table As New DataTable
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_IsNewMode As Boolean = True
   
    Private Sub cmdConfigtype_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmdConfigtype.SelectedIndexChanged
        Try
            table = GetRecords("Select ConfigTypeName from ConfigurationType where ConfigtypeCode = '" & cmdConfigtype.Text & "'")
            For i As Integer = 0 To table.Rows.Count - 1
                txtConfigtypeName.Text = table.Rows(i)("ConfigTypeName")
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub loadConfigType()
        Try
            table = GetRecords("Select ConfigTypeCode,ConfigTypeName from ConfigurationType")
            For i As Integer = 0 To table.Rows.Count - 1
                cmdConfigtype.Items.Add(table.Rows(i)("ConfigTypeCode"))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmDownloadReportUtilty_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadConfigType()
        LoadCalendarYear()
        LoadCalendarFromMonth()
        LoadCalendarToMonth()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Me.Dispose()
    End Sub
    Private Sub LoadCalendarYear()
        Try
            table = GetRecords("SELECT DISTINCT CAYR FROM Calendar where Comid = '" & GetDefaultCompany() & "' Order by CAYR")
            For i As Integer = 0 To table.Rows.Count - 1
                cmdYear.Items.Add(table.Rows(i)("CAYR"))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadCalendarFromMonth()
        Try
            table = GetRecords("Select Distinct CAPN From Calendar Where Comid = '" & GetDefaultCompany() & "' Order by CAPN")
            For i As Integer = 0 To table.Rows.Count - 1
                cmdFromMonth.Items.Add(table.Rows(i)("CAPN"))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadCalendarToMonth()
        Try
            table = GetRecords("Select Distinct CAPN From Calendar Where Comid = '" & GetDefaultCompany() & "' Order by CAPN")
            For i As Integer = 0 To table.Rows.Count - 1
                cmdToMonth.Items.Add(table.Rows(i)("CAPN"))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExcelReport_Click(sender As Object, e As EventArgs) Handles btnExcelReport.Click
        If cmdConfigtype.Text = "" Then
            MsgBox("Select the ConfigTypeCode", MsgBoxStyle.Exclamation)
        ElseIf cmdYear.Text = String.Empty Then
            MsgBox("Select the  from Year ", MsgBoxStyle.Exclamation)
        ElseIf cmdFromMonth.Text = String.Empty Then
            MsgBox("Select the Month set from", MsgBoxStyle.Exclamation)
        ElseIf cmdToMonth.Text = String.Empty Then
            MsgBox("Select the Month set to", MsgBoxStyle.Exclamation)
        Else
            If chkProductPerfPeriodToPerio.Checked Then
                PrintProductPerfPeriodToPeriod()
            End If
        End If
    End Sub
    Private Function PrintProductPerfPeriodToPeriod() As Boolean
        m_HasError = False
        Dim objBooks As Excel.Workbooks
        Dim objSheets As Excel.Sheets
        Dim objSheet As Excel._Worksheet
        Dim range As Excel.Range

        Try
            If Not File.Exists(ReturnExePath() & "\Report") Then
                Directory.CreateDirectory(ReturnExePath() & "\Report")
            End If
            Directory.CreateDirectory(ReturnExePath() & "\Report" & "\Product Performance")
            objApp = New Excel.Application()
            objBooks = objApp.Workbooks
            objBook = objBooks.Add
            objSheets = objBook.Worksheets

            CreateNationalProductPerformance(objBooks, objSheets, objSheet, range)
            CreateDistrictManagerProductPerformance(objBooks, objSheets, objSheet, range)
            CreateTerritoryProductPerformance(objBooks, objSheets, objSheet, range)
            objSheets.Select(1)
            objSheets("Sheet1").Delete()
            If File.Exists(ReturnExePath() & "Report" & "\Product Performance\" & "Product Performance Period to Period Report(" & cmdYear.Text & "-" & cmdFromMonth.Text & ")-(" & cmdYear.Text & "-" & cmdToMonth.Text & ")" & DateTime.Now.ToString("yyyy-MM-dd hhmmss") & ".xls") Then
                Kill(ReturnExePath() & "Report" & "\Product Performance\" & "Product Performance Period to Period Report(" & cmdYear.Text & "-" & cmdFromMonth.Text & ")-(" & cmdYear.Text & "-" & cmdToMonth.Text & ")" & DateTime.Now.ToString("yyyy-MM-dd hhmmss") & ".xls")
            End If
            objApp.ActiveWorkbook.SaveAs(ReturnExePath() & "Report" & "\Product Performance" & "\Product Performance Period to Period Report (" & cmdYear.Text & "-" & cmdFromMonth.Text & ")-(" & cmdYear.Text & "-" & cmdToMonth.Text & ")" & DateTime.Now.ToString("yyyy-MM-dd hhmmss") & ".xls", Excel.XlFileFormat.xlExcel8)
            objApp.Quit()
            range = Nothing
            objSheet = Nothing
            objSheets = Nothing
            objBooks = Nothing
            MsgBox("File Successfully Downloaded!", MsgBoxStyle.Information, "")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            m_HasError = True
        End Try
        Return Not m_HasError
    End Function
    Private Sub CreateNationalProductPerformance(ByVal objBooks As Excel.Workbooks, ByVal objsheets As Excel.Sheets, ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range)
        objsheet = objsheets.Add
        objsheet.Move(After:=objsheets(1))
        objsheet.Name = "National Product Performance"

        objsheet.Range("A1:E1").Merge()
        objsheet.Range("A1").Value = "ONE PHARMA MARKETING INC."
        objsheet.Range("A1:E1").Font.Bold = True
        objsheet.Range("A1:E1").Font.Size = 12

        objsheet.Range("A2:E2").Merge()
        objsheet.Range("A2").Value = "Product Performance- National"
        objsheet.Range("A2:E2").Font.Bold = True
        objsheet.Range("A2:E2").Font.Size = 12

        objsheet.Range("A3").Value = "Start Period"
        objsheet.Range("A3").Font.Bold = True
        objsheet.Range("A3").Font.Size = 11

        objsheet.Range("B3").Value = cmdFromMonth.Text
        objsheet.Range("B3").Font.Bold = True
        objsheet.Range("B3").Font.Size = 11

        objsheet.Range("C3").Value = "Start Period"
        objsheet.Range("C3").Font.Bold = True
        objsheet.Range("C3").Font.Size = 11

        objsheet.Range("D3").Value = cmdToMonth.Text
        objsheet.Range("D3").Font.Bold = True
        objsheet.Range("D3").Font.Size = 11

        objsheet.Range("A5:F6").Merge()
        objsheet.Range("A5:F6").HorizontalAlignment = Excel.Constants.xlCenter
        objsheet.Range("A5:F6").VerticalAlignment = Excel.Constants.xlCenter
        objsheet.Range("A5").Value = "National Product by Channel Sales Performance"
        objsheet.Range("A5:F6").Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        objsheet.Range("A5:F6").Font.Bold = True
        objsheet.Range("A5:F6").Font.Size = 11



        objsheet.Range("CF5:CW6").Merge()
        objsheet.Range("CF5:CW6").HorizontalAlignment = Excel.Constants.xlCenter
        objsheet.Range("CF5:CW6").VerticalAlignment = Excel.Constants.xlCenter
        objsheet.Range("CF5").Value = "Government Product by Channel Performance"
        objsheet.Range("CF5:CW6").Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        objsheet.Range("CF5:CW6").Font.Bold = True
        objsheet.Range("CF5:CW6").Font.Size = 11



        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0
        Dim ctr As Integer = 0

        Try
            Connect()
            Dim cmd As New SqlCommand("uspSalesAnalysisReport_NationalProductPerformancePerodToPeriod", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@Year", cmdYear.Text)
            cmd.Parameters.AddWithValue("@Month", cmdFromMonth.Text)
            cmd.Parameters.AddWithValue("@ConfigTypeCode", cmdConfigtype.Text)
            cmd.Parameters.AddWithValue("@Month2", cmdToMonth.Text)
            Dim da As New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            Disconnect()
            If dt.Rows.Count > 0 Then
                CreteHeaderNationalProductPerf(objsheet, range, y + yheader)
                For l As Integer = 0 To dt.Rows.Count - 1
                    ProgressBar1.Visible = True
                    ProgressBar1.Value = ctr / dt.Rows.Count * 100
                    Dim dr As DataRow = dt.Rows(l)
                    objsheet.Cells(8 + Counter + l, 1) = "'" & dr("Item Division Code")
                    objsheet.Cells(8 + Counter + l, 2) = "'" & dr("Product Group Description")
                    objsheet.Cells(8 + Counter + l, 3) = "'" & dr("Item Mother Code")
                    objsheet.Cells(8 + Counter + l, 4) = "'" & dr("Item Brand Name")
                    objsheet.Cells(8 + Counter + l, 5) = "'" & dr("Item Group Name")
                    objsheet.Cells(8 + Counter + l, 6) = "'" & dr("Therapeutic Class")
                    objsheet.Cells(8 + Counter + l, 7) = Format(dr("MDC Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 8) = Format(dr("LY MDC Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 9) = dr("MDC Qty Growth")
                    objsheet.Cells(8 + Counter + l, 10) = Format(dr("DIR Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 11) = Format(dr("LY DIR Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 12) = dr("DIR Qty Growth")
                    objsheet.Cells(8 + Counter + l, 13) = Format(dr("ODI Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 14) = Format(dr("LY ODI Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 15) = dr("ODI Qty Growth")
                    objsheet.Cells(8 + Counter + l, 16) = Format(dr("ACT Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 17) = Format(dr("LY ACT Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 18) = dr("ACT Qty Growth")
                    objsheet.Cells(8 + Counter + l, 19) = Format(dr("SSD Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 20) = Format(dr("LY SSD Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 21) = dr("SSD Qty Growth")
                    objsheet.Cells(8 + Counter + l, 22) = Format(dr("WAT Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 23) = Format(dr("LY WAT Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 24) = dr("WAT Qty Growth")
                    objsheet.Cells(8 + Counter + l, 25) = Format(dr("ZURE Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 26) = Format(dr("LY ZURE Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 27) = dr("ZURE Qty Growth")
                    objsheet.Cells(8 + Counter + l, 28) = Format(dr("RPI Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 29) = Format(dr("LY RPI Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 30) = dr("RPI Qty Growth")
                    objsheet.Cells(8 + Counter + l, 31) = Format(dr("Total Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 32) = Format(dr("LY Total Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 33) = dr("Total Qty Growth")
                    objsheet.Cells(8 + Counter + l, 34) = Format(dr("MST Ret Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 35) = Format(dr("LY MST Ret Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 36) = dr("MST Ret Qty Growth")
                    objsheet.Cells(8 + Counter + l, 37) = Format(dr("Total Ret Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 38) = Format(dr("LY Total Ret Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 39) = dr("Total Ret Qty Growth")
                    objsheet.Cells(8 + Counter + l, 40) = Format(dr("Total Net Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 41) = Format(dr("LY Total Net Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 42) = dr("Total Qty NET Growth")
                    objsheet.Cells(8 + Counter + l, 43) = Format(dr("Target Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 44) = dr("PerfQty")
                    objsheet.Cells(8 + Counter + l, 45) = Format(dr("MDC Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 46) = Format(dr("LY MDC Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 47) = dr("MDC Amount Growth")
                    objsheet.Cells(8 + Counter + l, 48) = Format(dr("DIR Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 49) = Format(dr("LY DIR Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 50) = dr("DIR Amount Growth")
                    objsheet.Cells(8 + Counter + l, 51) = Format(dr("ODI Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 52) = Format(dr("LY ODI Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 53) = dr("ODI Amount Growth")
                    objsheet.Cells(8 + Counter + l, 54) = Format(dr("ACT Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 55) = Format(dr("LY ACT Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 56) = dr("ACT Amount Growth")
                    objsheet.Cells(8 + Counter + l, 57) = Format(dr("SSD Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 58) = Format(dr("LY SSD Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 59) = dr("SSD Amount Growth")
                    objsheet.Cells(8 + Counter + l, 60) = Format(dr("WAT Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 61) = Format(dr("LY WAT Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 62) = dr("WAT Amount Growth")
                    objsheet.Cells(8 + Counter + l, 63) = Format(dr("ZURE Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 64) = Format(dr("LY ZURE Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 65) = dr("ZURE Amount Growth")
                    objsheet.Cells(8 + Counter + l, 66) = Format(dr("RPI Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 67) = Format(dr("LY ZURE Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 68) = dr("RPI Amount Growth")
                    objsheet.Cells(8 + Counter + l, 69) = Format(dr("Total Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 70) = Format(dr("LY Total Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 71) = dr("Total Amount Growth")
                    objsheet.Cells(8 + Counter + l, 72) = Format(dr("MDCR Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 73) = Format(dr("LY MDCR Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 74) = dr("MDCR Amount Growth")
                    objsheet.Cells(8 + Counter + l, 75) = Format(dr("Total Ret Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 76) = Format(dr("LY Total Ret Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 77) = dr("Total Ret Amount Growth")
                    objsheet.Cells(8 + Counter + l, 78) = Format(dr("Total Amount Net"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 79) = Format(dr("LY Total Amoun NET"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 80) = dr("Total Amount Net Growth")
                    objsheet.Cells(8 + Counter + l, 81) = Format(dr("Target Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 82) = dr("PerfAmt")
                    ctr += 1
                Next
            End If



            range = objsheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
            range.Font.Name = "Segoe UI"
            range.Font.Size = 8

            range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

            objsheet.Range("A1:CD400").EntireColumn.AutoFit()

            Connect()
            Dim cmd2 As New SqlCommand("uspSalesAnalysisReport_GovermantNationalProductPerformancePerodToPeriod", SPMSConn2)
            cmd2.CommandType = CommandType.StoredProcedure
            cmd2.CommandTimeout = 0
            cmd2.Parameters.AddWithValue("@Year", cmdYear.Text)
            cmd2.Parameters.AddWithValue("@Month", cmdFromMonth.Text)
            cmd2.Parameters.AddWithValue("@ConfigTypeCode", cmdConfigtype.Text)
            cmd2.Parameters.AddWithValue("@Month2", cmdToMonth.Text)
            Dim das As New SqlDataAdapter(cmd2)
            dt2 = New DataTable
            das.Fill(dt2)
            Disconnect()
            If dt2.Rows.Count > 0 Then
                CreteHeaderNationalProductGOV(objsheet, range, y + yheader)
                For l As Integer = 0 To dt2.Rows.Count - 1
                    Dim dr As DataRow = dt2.Rows(l)
                    objsheet.Cells(8 + Counter + l, 84) = Format(dr("DIRGOV Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 85) = Format(dr("LY DIRGOV Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 86) = dr("DIRGOV Qty Growth")
                    objsheet.Cells(8 + Counter + l, 87) = Format(dr("ODIGOV Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 88) = Format(dr("LY ODIGOV Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 89) = dr("ODIGOV Qty Growth")

                    objsheet.Cells(8 + Counter + l, 90) = Format(dr("Total Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 91) = Format(dr("LY Total Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 92) = dr("Total Qty Growth")

                    objsheet.Cells(8 + Counter + l, 93) = Format(dr("DIRGOV Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 94) = Format(dr("LY DIRGOV Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 95) = dr("DIRGOV Amount Growth")
                    objsheet.Cells(8 + Counter + l, 96) = Format(dr("ODIGOV Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 97) = Format(dr("LY ODIGOV Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 98) = dr("ODIGOV Amount Growth")

                    objsheet.Cells(8 + Counter + l, 99) = Format(dr("Total Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 100) = Format(dr("LY Total Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 101) = dr("Total Amount Growth")
                Next

            End If

            range = objsheet.Range("CF" & Convert.ToString(y + yheader), Reflection.Missing.Value)
            range = range.Resize(dt2.Rows.Count + 1, dt2.Columns.Count)
            range.Font.Name = "Segoe UI"
            range.Font.Size = 8

            range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

            objsheet.Range("A1:CW400").EntireColumn.AutoFit()

            ProgressBar1.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub CreteHeaderNationalProductGOV(ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)
        objsheet.Cells(y, 84) = "DIRGOV Qty"
        objsheet.Cells(y, 85) = "LY DIRGOV Qty"
        objsheet.Cells(y, 86) = "DIRGOV Qty Growth"
        objsheet.Cells(y, 87) = "ODIGOV Qty"
        objsheet.Cells(y, 88) = "LY ODIGOV Qty"
        objsheet.Cells(y, 89) = "ODIGOV Qty Growth"
        objsheet.Cells(y, 90) = "Total Qty"
        objsheet.Cells(y, 91) = "LY Total Qty"
        objsheet.Cells(y, 92) = "Total Qty Growth"
        objsheet.Cells(y, 93) = "DIRGOV Amount"
        objsheet.Cells(y, 94) = "LY DIRGOV Amount"
        objsheet.Cells(y, 95) = "DIRGOV Amount Growth"
        objsheet.Cells(y, 96) = "ODIGOV Amount"
        objsheet.Cells(y, 97) = "LY ODIGOV Amount"
        objsheet.Cells(y, 98) = "ODIGOV Amount Growth"
        objsheet.Cells(y, 99) = "Total Amount"
        objsheet.Cells(y, 100) = "LY Total Amount"
        objsheet.Cells(y, 101) = "Total Amount Growth"
        range = objsheet.Range("A" & Convert.ToString(y) & ":CW" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter
    End Sub
    Private Sub CreteHeaderNationalProductPerf(ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)
        objsheet.Cells(y, 1) = "Item Division Code"
        objsheet.Cells(y, 2) = "Product Group Description"
        objsheet.Cells(y, 3) = "Item Mother Code"
        objsheet.Cells(y, 4) = "Item Brand Name"
        objsheet.Cells(y, 5) = "Item Group Name"
        objsheet.Cells(y, 6) = "Therapeutic Class"
        objsheet.Cells(y, 7) = "MDC Qty"
        objsheet.Cells(y, 8) = "LY MDC Qty"
        objsheet.Cells(y, 9) = "MDC Qty Growth"
        objsheet.Cells(y, 10) = "DIR Qty"
        objsheet.Cells(y, 11) = "LY INH Qty"
        objsheet.Cells(y, 12) = "INH Qty Growth"
        objsheet.Cells(y, 13) = "ODI Qty"
        objsheet.Cells(y, 14) = "LY ODI Qty"
        objsheet.Cells(y, 15) = "ODI Qty Growth"
        objsheet.Cells(y, 16) = "ACT Qty"
        objsheet.Cells(y, 17) = "LY ACT Qty"
        objsheet.Cells(y, 18) = "ACT Qty Growth"
        objsheet.Cells(y, 19) = "SSD Qty"
        objsheet.Cells(y, 20) = "LY SSD Qty"
        objsheet.Cells(y, 21) = "SSD Qty Growth"
        objsheet.Cells(y, 22) = "WAT Qty"
        objsheet.Cells(y, 23) = "LY WAT Qty"
        objsheet.Cells(y, 24) = "WAT Qty Growth"
        objsheet.Cells(y, 25) = "ZURE Qty"
        objsheet.Cells(y, 26) = "LY ZURE Qty"
        objsheet.Cells(y, 27) = "ZURE Qty Growth"
        objsheet.Cells(y, 28) = "RPI Qty"
        objsheet.Cells(y, 29) = "LY RPI Qty"
        objsheet.Cells(y, 30) = "RPI Qty Growth"
        objsheet.Cells(y, 31) = "Total Qty"
        objsheet.Cells(y, 32) = "LY Total Qty"
        objsheet.Cells(y, 33) = "Total Qty Growth"
        objsheet.Cells(y, 34) = "MST Ret Qty"
        objsheet.Cells(y, 35) = "LY MST Ret Qty"
        objsheet.Cells(y, 36) = "MST Ret Qty Growth"
        objsheet.Cells(y, 37) = "Total Ret Qty"
        objsheet.Cells(y, 38) = "LY Total Ret Qty"
        objsheet.Cells(y, 39) = "Total Ret Qty Growth"
        objsheet.Cells(y, 40) = "Total Qty Net"
        objsheet.Cells(y, 41) = "LY Total Net Qty"
        objsheet.Cells(y, 42) = "Total NET Growth"
        objsheet.Cells(y, 43) = "Target Qty"
        objsheet.Cells(y, 44) = "Perf %"
        objsheet.Cells(y, 45) = "MDC Amount"
        objsheet.Cells(y, 46) = "LY MDC Amount"
        objsheet.Cells(y, 47) = "MDC Amount Growth"
        objsheet.Cells(y, 48) = "DIR Amount"
        objsheet.Cells(y, 49) = "LY DIR Amount"
        objsheet.Cells(y, 50) = "DIR Amount Growth"
        objsheet.Cells(y, 51) = "ODI Amount"
        objsheet.Cells(y, 52) = "LY ODI Amount"
        objsheet.Cells(y, 53) = "ODI Amount Growth"
        objsheet.Cells(y, 54) = "ACT Amount"
        objsheet.Cells(y, 55) = "LY ACT Amount"
        objsheet.Cells(y, 56) = "ACT Amount Growth"
        objsheet.Cells(y, 57) = "SSD Amount"
        objsheet.Cells(y, 58) = "LY SSD Amount"
        objsheet.Cells(y, 59) = "SSD Amount Growth"
        objsheet.Cells(y, 60) = "WAT Amount"
        objsheet.Cells(y, 61) = "LY WAT Amount"
        objsheet.Cells(y, 62) = "WAT Amount Growth"
        objsheet.Cells(y, 63) = "ZURE Amount"
        objsheet.Cells(y, 64) = "LY ZURE Amount"
        objsheet.Cells(y, 65) = "ZURE Amount Growth"
        objsheet.Cells(y, 66) = "RPI Amount"
        objsheet.Cells(y, 67) = "LY RPI Amount"
        objsheet.Cells(y, 68) = "RPI Amount Growth"
        objsheet.Cells(y, 69) = "Total Amount"
        objsheet.Cells(y, 70) = "LY Total Amount"
        objsheet.Cells(y, 71) = "Total Amount Growth"
        objsheet.Cells(y, 72) = "MST Ret Amount"
        objsheet.Cells(y, 73) = "LY MST Ret Amount"
        objsheet.Cells(y, 74) = "MST Amount Ret Growth"
        objsheet.Cells(y, 75) = "Total Ret Amount"
        objsheet.Cells(y, 76) = "LY Total Ret Amount"
        objsheet.Cells(y, 77) = "Total Ret Amount Growth"
        objsheet.Cells(y, 78) = "Total Amount Net"
        objsheet.Cells(y, 79) = "LY Total Amoun NET"
        objsheet.Cells(y, 80) = "Total Amount Net Growth"
        objsheet.Cells(y, 81) = "Target Amount"
        objsheet.Cells(y, 82) = "Perf %"
        range = objsheet.Range("A" & Convert.ToString(y) & ":CP" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter
    End Sub
    Private Sub CreateDistrictManagerProductPerformance(ByVal objbooks As Excel.Workbooks, ByVal objsheets As Excel.Sheets, ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range)
        objsheet = objsheets.Add
        objsheet.Move(After:=objsheets(2))
        objsheet.Name = "District Product Performance"


        objsheet.Range("A1:E1").Merge()
        objsheet.Range("A1").Value = "ONE PHARMA MARKETING INC."
        objsheet.Range("A1:E1").Font.Bold = True
        objsheet.Range("A1:E1").Font.Size = 12

        objsheet.Range("A2:E2").Merge()
        objsheet.Range("A2").Value = "District Manager of Performance"
        objsheet.Range("A2:E2").Font.Bold = True
        objsheet.Range("A2:E2").Font.Size = 12

        objsheet.Range("A3").Value = "Start Period"
        objsheet.Range("A3").Font.Bold = True
        objsheet.Range("A3").Font.Size = 11

        objsheet.Range("B3").Value = cmdFromMonth.Text
        objsheet.Range("B3").Font.Bold = True
        objsheet.Range("B3").Font.Size = 11

        objsheet.Range("C3").Value = "Start Period"
        objsheet.Range("C3").Font.Bold = True
        objsheet.Range("C3").Font.Size = 11

        objsheet.Range("D3").Value = cmdToMonth.Text
        objsheet.Range("D3").Font.Bold = True
        objsheet.Range("D3").Font.Size = 11

        objsheet.Range("A5:I6").Merge()
        objsheet.Range("A5:I6").HorizontalAlignment = Excel.Constants.xlCenter
        objsheet.Range("A5:I6").VerticalAlignment = Excel.Constants.xlCenter
        objsheet.Range("A5").Value = "District Manager by Channel Sales Performance "
        objsheet.Range("A5:I6").Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        objsheet.Range("A5:I6").Font.Bold = True
        objsheet.Range("A5:I6").Font.Size = 11

        objsheet.Range("CI5:CZ6").Merge()
        objsheet.Range("CI5:CZ6").HorizontalAlignment = Excel.Constants.xlCenter
        objsheet.Range("CI5:CZ6").VerticalAlignment = Excel.Constants.xlCenter
        objsheet.Range("CI5").Value = "Government District Manager Sales Per Channel Performance"
        objsheet.Range("CI5:CZ6").Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        objsheet.Range("CI5:CZ6").Font.Bold = True
        objsheet.Range("CI5:CZ6").Font.Size = 11



        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0
        Dim ctr As Integer = 0

        Try
            Connect()
            Dim cmd As New SqlCommand("uspSalesAnalysisReport_DistrictManagerProductPerformancePerodToPeriod", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@Year", cmdYear.Text)
            cmd.Parameters.AddWithValue("@Month", cmdFromMonth.Text)
            cmd.Parameters.AddWithValue("@ConfigTypeCode", cmdConfigtype.Text)
            cmd.Parameters.AddWithValue("@Month2", cmdToMonth.Text)
            Dim da As New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            Disconnect()
            If dt.Rows.Count > 0 Then
                CreteHeaderDistrictProductPerf(objsheet, range, y + yheader)
                For l As Integer = 0 To dt.Rows.Count - 1
                    ProgressBar1.Visible = True
                    ProgressBar1.Value = ctr / dt.Rows.Count * 100
                    Dim dr As DataRow = dt.Rows(l)
                    objsheet.Cells(8 + Counter + l, 1) = "'" & dr("Item Division Code")
                    objsheet.Cells(8 + Counter + l, 2) = "'" & dr("Product Group Description")
                    objsheet.Cells(8 + Counter + l, 3) = "'" & dr("RegionName")
                    objsheet.Cells(8 + Counter + l, 4) = "'" & dr("District Code")
                    objsheet.Cells(8 + Counter + l, 5) = "'" & dr("District Manager Name")
                    objsheet.Cells(8 + Counter + l, 6) = "'" & dr("Item Mother Code")
                    objsheet.Cells(8 + Counter + l, 7) = "'" & dr("Item Brand Name")
                    objsheet.Cells(8 + Counter + l, 8) = "'" & dr("Item Group Name")
                    objsheet.Cells(8 + Counter + l, 9) = "'" & dr("Therapeutic Class")
                    objsheet.Cells(8 + Counter + l, 10) = Format(dr("MDC Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 11) = Format(dr("LY MDC Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 12) = dr("MDC Qty Growth")
                    objsheet.Cells(8 + Counter + l, 13) = Format(dr("DIR Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 14) = Format(dr("LY DIR Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 15) = dr("DIR Qty Growth")
                    objsheet.Cells(8 + Counter + l, 16) = Format(dr("ODI Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 17) = Format(dr("LY ODI Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 18) = dr("ODI Qty Growth")
                    objsheet.Cells(8 + Counter + l, 19) = Format(dr("ACT Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 20) = Format(dr("LY ACT Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 21) = dr("ACT Qty Growth")
                    objsheet.Cells(8 + Counter + l, 22) = Format(dr("SSD Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 23) = Format(dr("LY SSD Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 24) = dr("SSD Qty Growth")
                    objsheet.Cells(8 + Counter + l, 25) = Format(dr("WAT Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 26) = Format(dr("LY WAT Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 27) = dr("WAT Qty Growth")
                    objsheet.Cells(8 + Counter + l, 28) = Format(dr("ZURE Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 29) = Format(dr("LY ZURE Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 30) = dr("ZURE Qty Growth")
                    objsheet.Cells(8 + Counter + l, 31) = Format(dr("RPI Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 32) = Format(dr("LY RPI Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 33) = dr("RPI Qty Growth")
                    objsheet.Cells(8 + Counter + l, 34) = Format(dr("Total Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 35) = Format(dr("LY Total Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 36) = dr("Total Qty Growth")
                    objsheet.Cells(8 + Counter + l, 37) = Format(dr("MST Ret Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 38) = Format(dr("LY MST Ret Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 39) = dr("MST Ret Qty Growth")
                    objsheet.Cells(8 + Counter + l, 40) = Format(dr("Total Ret Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 41) = Format(dr("LY Total Ret Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 42) = dr("Total Ret Qty Growth")
                    objsheet.Cells(8 + Counter + l, 43) = Format(dr("Total Net Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 44) = Format(dr("LY Total Net Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 45) = dr("Total Qty NET Growth")
                    objsheet.Cells(8 + Counter + l, 46) = Format(dr("Target Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 47) = dr("PerfQty")
                    objsheet.Cells(8 + Counter + l, 48) = Format(dr("MDC Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 49) = Format(dr("LY MDC Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 50) = dr("MDC Amount Growth")
                    objsheet.Cells(8 + Counter + l, 51) = Format(dr("DIR Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 52) = Format(dr("LY DIR Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 53) = dr("DIR Amount Growth")
                    objsheet.Cells(8 + Counter + l, 54) = Format(dr("ODI Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 55) = Format(dr("LY ODI Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 56) = dr("ODI Amount Growth")
                    objsheet.Cells(8 + Counter + l, 57) = Format(dr("ACT Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 58) = Format(dr("LY ACT Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 59) = dr("ACT Amount Growth")
                    objsheet.Cells(8 + Counter + l, 60) = Format(dr("SSD Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 61) = Format(dr("LY SSD Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 62) = dr("SSD Amount Growth")
                    objsheet.Cells(8 + Counter + l, 63) = Format(dr("WAT Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 64) = Format(dr("LY WAT Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 65) = dr("WAT Amount Growth")
                    objsheet.Cells(8 + Counter + l, 66) = Format(dr("ZURE Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 67) = Format(dr("LY ZURE Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 68) = dr("ZURE Amount Growth")
                    objsheet.Cells(8 + Counter + l, 69) = Format(dr("RPI Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 70) = Format(dr("LY ZURE Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 71) = dr("RPI Amount Growth")
                    objsheet.Cells(8 + Counter + l, 72) = Format(dr("Total Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 73) = Format(dr("LY Total Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 74) = dr("Total Amount Growth")
                    objsheet.Cells(8 + Counter + l, 75) = Format(dr("MDCR Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 76) = Format(dr("LY MDCR Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 77) = dr("MDCR Amount Growth")
                    objsheet.Cells(8 + Counter + l, 78) = Format(dr("Total Ret Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 79) = Format(dr("LY Total Ret Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 80) = dr("Total Ret Amount Growth")
                    objsheet.Cells(8 + Counter + l, 81) = Format(dr("Total Amount Net"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 82) = Format(dr("LY Total Amoun NET"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 83) = dr("Total Amount Net Growth")
                    objsheet.Cells(8 + Counter + l, 84) = Format(dr("Target Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 85) = dr("PerfAmt")
                    ctr += 1
                Next
            End If
            range = objsheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
            range.Font.Name = "Segoe UI"
            range.Font.Size = 8

            range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

            objsheet.Range("A1:CG400").EntireColumn.AutoFit()


            Connect()
            Dim cmd2 As New SqlCommand("uspSalesAnalysisReport_GovermentDistrictManagerProductPerformancePerodToPeriod", SPMSConn2)
            cmd2.CommandType = CommandType.StoredProcedure
            cmd2.CommandTimeout = 0
            cmd2.Parameters.AddWithValue("@Year", cmdYear.Text)
            cmd2.Parameters.AddWithValue("@Month", cmdFromMonth.Text)
            cmd2.Parameters.AddWithValue("@ConfigTypeCode", cmdConfigtype.Text)
            cmd2.Parameters.AddWithValue("@Month2", cmdToMonth.Text)
            Dim das As New SqlDataAdapter(cmd2)
            dt2 = New DataTable
            das.Fill(dt2)
            Disconnect()
            If dt2.Rows.Count > 0 Then
                CreteHeaderGovernmentDistrictProductPerf(objsheet, range, y + yheader)
                For l As Integer = 0 To dt2.Rows.Count - 1
                    Dim dr As DataRow = dt2.Rows(l)
                    objsheet.Cells(8 + Counter + l, 87) = Format(dr("DIRGOV Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 88) = Format(dr("LY DIRGOV Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 89) = dr("DIRGOV Qty Growth")
                    objsheet.Cells(8 + Counter + l, 90) = Format(dr("ODIGOV Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 91) = Format(dr("LY ODIGOV Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 92) = dr("ODIGOV Qty Growth")

                    objsheet.Cells(8 + Counter + l, 93) = Format(dr("Total Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 94) = Format(dr("LY Total Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 95) = dr("Total Qty Growth")

                    objsheet.Cells(8 + Counter + l, 96) = Format(dr("DIRGOV Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 97) = Format(dr("LY DIRGOV Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 98) = dr("DIRGOV Amount Growth")
                    objsheet.Cells(8 + Counter + l, 99) = Format(dr("ODIGOV Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 100) = Format(dr("LY ODIGOV Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 101) = dr("ODIGOV Amount Growth")

                    objsheet.Cells(8 + Counter + l, 102) = Format(dr("Total Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 103) = Format(dr("LY Total Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 104) = dr("Total Amount Growth")
                    ctr += 1
                Next
            End If
            range = objsheet.Range("CI" & Convert.ToString(y + yheader), Reflection.Missing.Value)
            range = range.Resize(dt2.Rows.Count + 1, dt2.Columns.Count)
            range.Font.Name = "Segoe UI"
            range.Font.Size = 8

            range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

            objsheet.Range("A1:CZ400").EntireColumn.AutoFit()


            ProgressBar1.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub CreteHeaderGovernmentDistrictProductPerf(ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)
        objsheet.Cells(y, 87) = "DIRGOV Qty"
        objsheet.Cells(y, 88) = "LY DIRGOV Qty"
        objsheet.Cells(y, 89) = "DIRGOV Qty Growth"
        objsheet.Cells(y, 90) = "ODIGOV Qty"
        objsheet.Cells(y, 91) = "LY ODIGOV Qty"
        objsheet.Cells(y, 92) = "ODIGOV Qty Growth"
        objsheet.Cells(y, 93) = "Total Qty"
        objsheet.Cells(y, 94) = "LY Total Qty"
        objsheet.Cells(y, 95) = "Total Qty Growth"
        objsheet.Cells(y, 96) = "DIRGOV Amount"
        objsheet.Cells(y, 97) = "LY DIRGOV Amount"
        objsheet.Cells(y, 98) = "DIRGOV Amount Growth"
        objsheet.Cells(y, 99) = "ODIGOV Amount"
        objsheet.Cells(y, 100) = "LY ODIGOV Amount"
        objsheet.Cells(y, 101) = "ODIGOV Amount Growth"
        objsheet.Cells(y, 102) = "Total Amount"
        objsheet.Cells(y, 103) = "LY Total Amount"
        objsheet.Cells(y, 104) = "Total Amount Growth"
        range = objsheet.Range("CI" & Convert.ToString(y) & ":CZ" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter
    End Sub

    Private Sub CreteHeaderDistrictProductPerf(ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)
        objsheet.Cells(y, 1) = "Item Division Code"
        objsheet.Cells(y, 2) = "Product Group Description"
        objsheet.Cells(y, 3) = "Region Name"
        objsheet.Cells(y, 4) = "District Manager Code"
        objsheet.Cells(y, 5) = "District Manager Name"
        objsheet.Cells(y, 6) = "Item Mother Code"
        objsheet.Cells(y, 7) = "Item Brand Name"
        objsheet.Cells(y, 8) = "Item Group Name"
        objsheet.Cells(y, 9) = "Therapeutic Class"
        objsheet.Cells(y, 10) = "MDC Qty"
        objsheet.Cells(y, 11) = "LY MDC Qty"
        objsheet.Cells(y, 12) = "MDC Qty Growth"
        objsheet.Cells(y, 13) = "DIR Qty"
        objsheet.Cells(y, 14) = "LY DIR Qty"
        objsheet.Cells(y, 15) = "DIR Qty Growth"
        objsheet.Cells(y, 16) = "ODI Qty"
        objsheet.Cells(y, 17) = "LY ODI Qty"
        objsheet.Cells(y, 18) = "ODI Qty Growth"
        objsheet.Cells(y, 19) = "ACT Qty"
        objsheet.Cells(y, 20) = "LY ACT Qty"
        objsheet.Cells(y, 21) = "ACT Qty Growth"
        objsheet.Cells(y, 22) = "SSD Qty"
        objsheet.Cells(y, 23) = "LY SSD Qty"
        objsheet.Cells(y, 24) = "SSD Qty Growth"
        objsheet.Cells(y, 25) = "WAT Qty"
        objsheet.Cells(y, 26) = "LY WAT Qty"
        objsheet.Cells(y, 27) = "WAT Qty Growth"
        objsheet.Cells(y, 28) = "ZURE Qty"
        objsheet.Cells(y, 29) = "LY ZURE Qty"
        objsheet.Cells(y, 30) = "ZURE Qty Growth"
        objsheet.Cells(y, 31) = "RPI Qty"
        objsheet.Cells(y, 32) = "LY RPI Qty"
        objsheet.Cells(y, 33) = "RPI Qty Growth"
        objsheet.Cells(y, 34) = "Total Qty"
        objsheet.Cells(y, 35) = "LY Total Qty"
        objsheet.Cells(y, 36) = "Total Qty Growth"
        objsheet.Cells(y, 37) = "MST Ret Qty"
        objsheet.Cells(y, 38) = "LY MST Ret Qty"
        objsheet.Cells(y, 39) = "MST Ret Qty Growth"
        objsheet.Cells(y, 40) = "Total Ret Qty"
        objsheet.Cells(y, 41) = "LY Total Ret Qty"
        objsheet.Cells(y, 42) = "Total Ret Qty Growth"
        objsheet.Cells(y, 43) = "Total Qty Net"
        objsheet.Cells(y, 44) = "LY Total Net Qty"
        objsheet.Cells(y, 45) = "Total NET Growth"
        objsheet.Cells(y, 46) = "Target Qty"
        objsheet.Cells(y, 47) = "Perf %"
        objsheet.Cells(y, 48) = "MDC Amount"
        objsheet.Cells(y, 49) = "LY MDC Amount"
        objsheet.Cells(y, 50) = "MDC Amount Growth"
        objsheet.Cells(y, 51) = "DIR Amount"
        objsheet.Cells(y, 52) = "LY DIR Amount"
        objsheet.Cells(y, 53) = "DIR Amount Growth"
        objsheet.Cells(y, 54) = "ODI Amount"
        objsheet.Cells(y, 55) = "LY ODI Amount"
        objsheet.Cells(y, 56) = "ODI Amount Growth"
        objsheet.Cells(y, 57) = "ACT Amount"
        objsheet.Cells(y, 58) = "LY ACT Amount"
        objsheet.Cells(y, 59) = "ACT Amount Growth"
        objsheet.Cells(y, 60) = "SSD Amount"
        objsheet.Cells(y, 61) = "LY SSD Amount"
        objsheet.Cells(y, 62) = "SSD Amount Growth"
        objsheet.Cells(y, 63) = "WAT Amount"
        objsheet.Cells(y, 64) = "LY WAT Amount"
        objsheet.Cells(y, 65) = "WAT Amount Growth"
        objsheet.Cells(y, 66) = "ZURE Amount"
        objsheet.Cells(y, 67) = "LY ZURE Amount"
        objsheet.Cells(y, 68) = "ZURE Amount Growth"
        objsheet.Cells(y, 69) = "RPI Amount"
        objsheet.Cells(y, 70) = "LY RPI Amount"
        objsheet.Cells(y, 71) = "RPI Amount Growth"
        objsheet.Cells(y, 72) = "Total Amount"
        objsheet.Cells(y, 73) = "LY Total Amount"
        objsheet.Cells(y, 74) = "Total Amount Growth"
        objsheet.Cells(y, 75) = "MST Ret Amount"
        objsheet.Cells(y, 76) = "LY MST Ret Amount"
        objsheet.Cells(y, 77) = "MST Amount Ret Growth"
        objsheet.Cells(y, 78) = "Total Ret Amount"
        objsheet.Cells(y, 79) = "LY Total Ret Amount"
        objsheet.Cells(y, 80) = "Total Ret Amount Growth"
        objsheet.Cells(y, 81) = "Total Amount Net"
        objsheet.Cells(y, 82) = "LY Total Amoun NET"
        objsheet.Cells(y, 83) = "Total Amount Net Growth"
        objsheet.Cells(y, 84) = "Target Amount"
        objsheet.Cells(y, 85) = "Perf %"
        range = objsheet.Range("A" & Convert.ToString(y) & ":CG" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter
    End Sub
    Private Sub CreateTerritoryProductPerformance(ByVal objbooks As Excel.Workbooks, ByVal objsheets As Excel.Sheets, ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range)

        objsheet = objsheets.Add
        objsheet.Move(After:=objsheets(3))
        objsheet.Name = "Territory Product Performance"



        objsheet.Range("A1:E1").Merge()
        objsheet.Range("A1").Value = "ONE PHARMA MARKETING INC."
        objsheet.Range("A1:E1").Font.Bold = True
        objsheet.Range("A1:E1").Font.Size = 12

        objsheet.Range("A2:E2").Merge()
        objsheet.Range("A2").Value = "Territory Product Performance"
        objsheet.Range("A2:E2").Font.Bold = True
        objsheet.Range("A2:E2").Font.Size = 12

        objsheet.Range("A3").Value = "Start Period"
        objsheet.Range("A3").Font.Bold = True
        objsheet.Range("A3").Font.Size = 11

        objsheet.Range("B3").Value = cmdFromMonth.Text
        objsheet.Range("B3").Font.Bold = True
        objsheet.Range("B3").Font.Size = 11

        objsheet.Range("C3").Value = "Start Period"
        objsheet.Range("C3").Font.Bold = True
        objsheet.Range("C3").Font.Size = 11

        objsheet.Range("D3").Value = cmdToMonth.Text
        objsheet.Range("D3").Font.Bold = True
        objsheet.Range("D3").Font.Size = 11

        objsheet.Range("A5:K6").Merge()
        objsheet.Range("A5:K6").HorizontalAlignment = Excel.Constants.xlCenter
        objsheet.Range("A5:K6").VerticalAlignment = Excel.Constants.xlCenter
        objsheet.Range("A5").Value = "Territory Per Channel Sales Performance"
        objsheet.Range("A5:K6").Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        objsheet.Range("A5:K6").Font.Bold = True
        objsheet.Range("A5:K6").Font.Size = 11

        objsheet.Range("CK5:DB6").Merge()
        objsheet.Range("CK5:DB6").HorizontalAlignment = Excel.Constants.xlCenter
        objsheet.Range("CK5:DB6").VerticalAlignment = Excel.Constants.xlCenter
        objsheet.Range("CK5").Value = "Government Territory Sales Per Channel Performance"
        objsheet.Range("CK5:DB6").Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        objsheet.Range("CK5:DB6").Font.Bold = True
        objsheet.Range("CK5:DB6").Font.Size = 11


        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0
        Dim ctr As Integer = 0

        Try
            Connect()
            Dim cmd As New SqlCommand("uspSalesAnalysisReport_ProductPerformancePerodToPeriod", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@Year", cmdYear.Text)
            cmd.Parameters.AddWithValue("@Month", cmdFromMonth.Text)
            cmd.Parameters.AddWithValue("@ConfigTypeCode", cmdConfigtype.Text)
            cmd.Parameters.AddWithValue("@Month2", cmdToMonth.Text)
            Dim da As New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            Disconnect()
            If dt.Rows.Count > 0 Then
                CreteHeaderTerritoryProductPerf(objsheet, range, y + yheader)
                For l As Integer = 0 To dt.Rows.Count - 1
                    ProgressBar1.Visible = True
                    ProgressBar1.Value = ctr / dt.Rows.Count * 100
                    Dim dr As DataRow = dt.Rows(l)
                    objsheet.Cells(8 + Counter + l, 1) = "'" & dr("Item Division Code")
                    objsheet.Cells(8 + Counter + l, 2) = "'" & dr("Product Group Description")
                    objsheet.Cells(8 + Counter + l, 3) = "'" & dr("RegionName")
                    objsheet.Cells(8 + Counter + l, 4) = "'" & dr("District Code")
                    objsheet.Cells(8 + Counter + l, 5) = "'" & dr("District Manager Name")
                    objsheet.Cells(8 + Counter + l, 6) = "'" & dr("Territory Code")
                    objsheet.Cells(8 + Counter + l, 7) = "'" & dr("Territory Manager Name")
                    objsheet.Cells(8 + Counter + l, 8) = "'" & dr("ITEM MOTHER CODE")
                    objsheet.Cells(8 + Counter + l, 9) = "'" & dr("Item Brand Name")
                    objsheet.Cells(8 + Counter + l, 10) = "'" & dr("Item Group Name")
                    objsheet.Cells(8 + Counter + l, 11) = "'" & dr("Therapeutic Class")
                    objsheet.Cells(8 + Counter + l, 12) = Format(dr("MDC Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 13) = Format(dr("LY MDC Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 14) = dr("MDC Qty Growth")
                    objsheet.Cells(8 + Counter + l, 15) = Format(dr("DIR Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 16) = Format(dr("LY DIR Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 17) = dr("DIR Qty Growth")
                    objsheet.Cells(8 + Counter + l, 18) = Format(dr("ODI Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 19) = Format(dr("LY ODI Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 20) = dr("ODI Qty Growth")
                    objsheet.Cells(8 + Counter + l, 21) = Format(dr("ACT Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 22) = Format(dr("LY ACT Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 23) = dr("ACT Qty Growth")
                    objsheet.Cells(8 + Counter + l, 24) = Format(dr("SSD Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 25) = Format(dr("LY SSD Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 26) = dr("SSD Qty Growth")
                    objsheet.Cells(8 + Counter + l, 27) = Format(dr("WAT Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 28) = Format(dr("LY WAT Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 29) = dr("WAT Qty Growth")
                    objsheet.Cells(8 + Counter + l, 30) = Format(dr("ZURE Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 31) = Format(dr("LY ZURE Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 32) = dr("ZURE Qty Growth")
                    objsheet.Cells(8 + Counter + l, 33) = Format(dr("RPI Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 34) = Format(dr("LY RPI Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 35) = dr("RPI Qty Growth")
                    objsheet.Cells(8 + Counter + l, 36) = Format(dr("Total Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 37) = Format(dr("LY Total Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 38) = dr("Total Qty Growth")
                    objsheet.Cells(8 + Counter + l, 39) = Format(dr("MST Ret Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 40) = Format(dr("LY MST Ret Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 41) = dr("MST Ret Qty Growth")
                    objsheet.Cells(8 + Counter + l, 42) = Format(dr("Total Ret Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 43) = Format(dr("LY Total Ret Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 44) = dr("Total Ret Qty Growth")
                    objsheet.Cells(8 + Counter + l, 45) = Format(dr("Total Net Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 46) = Format(dr("LY Total Net Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 47) = dr("Total Qty NET Growth")
                    objsheet.Cells(8 + Counter + l, 48) = Format(dr("Target Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 49) = dr("PerfQty")
                    objsheet.Cells(8 + Counter + l, 50) = Format(dr("MDC Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 51) = Format(dr("LY MDC Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 52) = dr("MDC Amount Growth")
                    objsheet.Cells(8 + Counter + l, 53) = Format(dr("DIR Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 54) = Format(dr("LY DIR Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 55) = dr("DIR Amount Growth")
                    objsheet.Cells(8 + Counter + l, 56) = Format(dr("ODI Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 57) = Format(dr("LY ODI Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 58) = dr("ODI Amount Growth")
                    objsheet.Cells(8 + Counter + l, 59) = Format(dr("ACT Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 60) = Format(dr("LY ACT Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 61) = dr("ACT Amount Growth")
                    objsheet.Cells(8 + Counter + l, 62) = Format(dr("SSD Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 63) = Format(dr("LY SSD Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 64) = dr("SSD Amount Growth")
                    objsheet.Cells(8 + Counter + l, 65) = Format(dr("WAT Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 66) = Format(dr("LY WAT Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 67) = dr("WAT Amount Growth")
                    objsheet.Cells(8 + Counter + l, 68) = Format(dr("ZURE Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 69) = Format(dr("LY ZURE Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 70) = dr("ZURE Amount Growth")
                    objsheet.Cells(8 + Counter + l, 71) = Format(dr("RPI Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 72) = Format(dr("LY ZURE Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 73) = dr("RPI Amount Growth")
                    objsheet.Cells(8 + Counter + l, 74) = Format(dr("Total Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 75) = Format(dr("LY Total Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 76) = dr("Total Amount Growth")
                    objsheet.Cells(8 + Counter + l, 77) = Format(dr("MDCR Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 78) = Format(dr("LY MDCR Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 79) = dr("MDCR Amount Growth")
                    objsheet.Cells(8 + Counter + l, 80) = Format(dr("Total Ret Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 81) = Format(dr("LY Total Ret Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 82) = dr("Total Ret Amount Growth")
                    objsheet.Cells(8 + Counter + l, 83) = Format(dr("Total Amount Net"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 84) = Format(dr("LY Total Amoun NET"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 85) = dr("Total Amount Net Growth")
                    objsheet.Cells(8 + Counter + l, 86) = Format(dr("Target Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 87) = dr("PerfAmt")
                    ctr += 1
                Next
            End If
            range = objsheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
            range.Font.Name = "Segoe UI"
            range.Font.Size = 8

            range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

            objsheet.Range("A1:CI400").EntireColumn.AutoFit()


            Connect()
            Dim cmd2 As New SqlCommand("uspSalesAnalysisReport_GovermentDistrictManagerProductPerformancePerodToPeriod", SPMSConn2)
            cmd2.CommandType = CommandType.StoredProcedure
            cmd2.CommandTimeout = 0
            cmd2.Parameters.AddWithValue("@Year", cmdYear.Text)
            cmd2.Parameters.AddWithValue("@Month", cmdFromMonth.Text)
            cmd2.Parameters.AddWithValue("@ConfigTypeCode", cmdConfigtype.Text)
            cmd2.Parameters.AddWithValue("@Month2", cmdToMonth.Text)
            Dim das As New SqlDataAdapter(cmd2)
            dt2 = New DataTable
            das.Fill(dt2)
            Disconnect()
            If dt2.Rows.Count > 0 Then
                CreteHeaderGovernmentTerritoryProductPerf(objsheet, range, y + yheader)
                For l As Integer = 0 To dt2.Rows.Count - 1
                    Dim dr As DataRow = dt2.Rows(l)
                    objsheet.Cells(8 + Counter + l, 89) = Format(dr("DIRGOV Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 90) = Format(dr("LY DIRGOV Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 91) = dr("DIRGOV Qty Growth")
                    objsheet.Cells(8 + Counter + l, 92) = Format(dr("ODIGOV Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 93) = Format(dr("LY ODIGOV Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 94) = dr("ODIGOV Qty Growth")

                    objsheet.Cells(8 + Counter + l, 95) = Format(dr("Total Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 96) = Format(dr("LY Total Qty"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 97) = dr("Total Qty Growth")

                    objsheet.Cells(8 + Counter + l, 98) = Format(dr("DIRGOV Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 99) = Format(dr("LY DIRGOV Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 100) = dr("DIRGOV Amount Growth")
                    objsheet.Cells(8 + Counter + l, 101) = Format(dr("ODIGOV Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 102) = Format(dr("LY ODIGOV Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 103) = dr("ODIGOV Amount Growth")

                    objsheet.Cells(8 + Counter + l, 104) = Format(dr("Total Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 105) = Format(dr("LY Total Amount"), "#,##0.00")
                    objsheet.Cells(8 + Counter + l, 106) = dr("Total Amount Growth")
                    ctr += 1
                Next
            End If
            range = objsheet.Range("CK" & Convert.ToString(y + yheader), Reflection.Missing.Value)
            range = range.Resize(dt2.Rows.Count + 1, dt2.Columns.Count)
            range.Font.Name = "Segoe UI"
            range.Font.Size = 8

            range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

            objsheet.Range("CK1:DB400").EntireColumn.AutoFit()

            ProgressBar1.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub CreteHeaderGovernmentTerritoryProductPerf(ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)
        objsheet.Cells(y, 89) = "DIRGOV Qty"
        objsheet.Cells(y, 90) = "LY DIRGOV Qty"
        objsheet.Cells(y, 91) = "DIRGOV Qty Growth"
        objsheet.Cells(y, 92) = "ODIGOV Qty"
        objsheet.Cells(y, 93) = "LY ODIGOV Qty"
        objsheet.Cells(y, 94) = "ODIGOV Qty Growth"
        objsheet.Cells(y, 95) = "Total Qty"
        objsheet.Cells(y, 96) = "LY Total Qty"
        objsheet.Cells(y, 97) = "Total Qty Growth"
        objsheet.Cells(y, 98) = "DIRGOV Amount"
        objsheet.Cells(y, 99) = "LY DIRGOV Amount"
        objsheet.Cells(y, 100) = "DIRGOV Amount Growth"
        objsheet.Cells(y, 101) = "ODIGOV Amount"
        objsheet.Cells(y, 102) = "LY ODIGOV Amount"
        objsheet.Cells(y, 103) = "ODIGOV Amount Growth"
        objsheet.Cells(y, 104) = "Total Amount"
        objsheet.Cells(y, 105) = "LY Total Amount"
        objsheet.Cells(y, 106) = "Total Amount Growth"

        range = objsheet.Range("CK" & Convert.ToString(y) & ":DB" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter
    End Sub


    Private Sub CreteHeaderTerritoryProductPerf(ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)
        objsheet.Cells(y, 1) = "Item Division Code"
        objsheet.Cells(y, 2) = "Product Group Description"
        objsheet.Cells(y, 3) = "Region Name"
        objsheet.Cells(y, 4) = "District Code"
        objsheet.Cells(y, 5) = "District Manager Name"
        objsheet.Cells(y, 6) = "Territory Code"
        objsheet.Cells(y, 7) = "Territory Manager Name"
        objsheet.Cells(y, 8) = "Item Mother Code"
        objsheet.Cells(y, 9) = "Item Brand Name"
        objsheet.Cells(y, 10) = "Item Group Name"
        objsheet.Cells(y, 11) = "Therapeutic Class"
        objsheet.Cells(y, 12) = "MDC Qty"
        objsheet.Cells(y, 13) = "LY MDC Qty"
        objsheet.Cells(y, 14) = "MDC Qty Growth"
        objsheet.Cells(y, 15) = "DIR Qty"
        objsheet.Cells(y, 16) = "LY DIR Qty"
        objsheet.Cells(y, 17) = "DIR Qty Growth"
        objsheet.Cells(y, 18) = "ODI Qty"
        objsheet.Cells(y, 19) = "LY ODI Qty"
        objsheet.Cells(y, 20) = "ODI Qty Growth"
        objsheet.Cells(y, 21) = "ACT Qty"
        objsheet.Cells(y, 22) = "LY ACT Qty"
        objsheet.Cells(y, 23) = "ACT Qty Growth"
        objsheet.Cells(y, 24) = "SSD Qty"
        objsheet.Cells(y, 25) = "LY SSD Qty"
        objsheet.Cells(y, 26) = "SSD Qty Growth"
        objsheet.Cells(y, 27) = "WAT Qty"
        objsheet.Cells(y, 28) = "LY WAT Qty"
        objsheet.Cells(y, 29) = "WAT Qty Growth"
        objsheet.Cells(y, 30) = "ZURE Qty"
        objsheet.Cells(y, 31) = "LY ZURE Qty"
        objsheet.Cells(y, 32) = "ZURE Qty Growth"
        objsheet.Cells(y, 33) = "RPI Qty"
        objsheet.Cells(y, 34) = "LY RPI Qty"
        objsheet.Cells(y, 35) = "RPI Qty Growth"
        objsheet.Cells(y, 36) = "Total Qty"
        objsheet.Cells(y, 37) = "LY Total Qty"
        objsheet.Cells(y, 38) = "Total Qty Growth"
        objsheet.Cells(y, 39) = "MST Ret Qty"
        objsheet.Cells(y, 40) = "LY MST Ret Qty"
        objsheet.Cells(y, 41) = "MST Ret Qty Growth"
        objsheet.Cells(y, 42) = "Total Ret Qty"
        objsheet.Cells(y, 43) = "LY Total Ret Qty"
        objsheet.Cells(y, 44) = "Total Ret Qty Growth"
        objsheet.Cells(y, 45) = "Total Qty Net"
        objsheet.Cells(y, 46) = "LY Total Net Qty"
        objsheet.Cells(y, 47) = "Total Qty NET Growth"
        objsheet.Cells(y, 48) = "Target Qty"
        objsheet.Cells(y, 49) = "Perf %"
        objsheet.Cells(y, 50) = "MDC Amount"
        objsheet.Cells(y, 51) = "LY MDC Amount"
        objsheet.Cells(y, 52) = "MDC Amount Growth"
        objsheet.Cells(y, 53) = "DIR Amount"
        objsheet.Cells(y, 54) = "LY DIR Amount"
        objsheet.Cells(y, 55) = "DIR Amount Growth"
        objsheet.Cells(y, 56) = "ODI Amount"
        objsheet.Cells(y, 57) = "LY ODI Amount"
        objsheet.Cells(y, 58) = "ODI Amount Growth"
        objsheet.Cells(y, 59) = "ACT Amount"
        objsheet.Cells(y, 60) = "LY ACT Amount"
        objsheet.Cells(y, 61) = "ACT Amount Growth"
        objsheet.Cells(y, 62) = "SSD Amount"
        objsheet.Cells(y, 63) = "LY SSD Amount"
        objsheet.Cells(y, 64) = "SSD Amount Growth"
        objsheet.Cells(y, 65) = "WAT Amount"
        objsheet.Cells(y, 66) = "LY WAT Amount"
        objsheet.Cells(y, 67) = "WAT Amount Growth"
        objsheet.Cells(y, 68) = "ZURE Amount"
        objsheet.Cells(y, 69) = "LY ZURE Amount"
        objsheet.Cells(y, 70) = "ZURE Amount Growth"
        objsheet.Cells(y, 71) = "RPI Amount"
        objsheet.Cells(y, 72) = "LY RPI Amount"
        objsheet.Cells(y, 73) = "RPI Amount Growth"
        objsheet.Cells(y, 74) = "Total Amount"
        objsheet.Cells(y, 75) = "LY Total Amount"
        objsheet.Cells(y, 76) = "Total Amount Growth"
        objsheet.Cells(y, 77) = "MST Ret Amount"
        objsheet.Cells(y, 78) = "LY MST Ret Amount"
        objsheet.Cells(y, 79) = "MST Amount Ret Growth"
        objsheet.Cells(y, 80) = "Total Ret Amount"
        objsheet.Cells(y, 81) = "LY Total Ret Amount"
        objsheet.Cells(y, 82) = "Total Ret Amount Growth"
        objsheet.Cells(y, 83) = "Total Amount Net"
        objsheet.Cells(y, 84) = "LY Total Amoun NET"
        objsheet.Cells(y, 85) = "Total Amount Net Growth"
        objsheet.Cells(y, 86) = "Target Amount"
        objsheet.Cells(y, 87) = "Perf %"
        range = objsheet.Range("A" & Convert.ToString(y) & ":CT" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter
    End Sub
    Private Sub MergeCell(ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal FromRange As String, _
                         ByVal ToRange As String, ByVal Value As String, ByVal FontSize As Integer, ByVal Bold As Boolean, ByVal horizontalalign As Excel.Constants, ByVal vertical As Excel.Constants)

        range = objsheet.Range(FromRange, ToRange)

        range.Merge()
        range.HorizontalAlignment = horizontalalign
        range.VerticalAlignment = vertical

        range.WrapText = True
        range.ShrinkToFit = False
        range.Value = Value
        range.Font.Size = FontSize
        range.Font.Bold = Bold
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Dispose()
    End Sub
End Class