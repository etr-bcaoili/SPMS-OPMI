Imports SPMSOPCI.ConnectionModule
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.IO

Public Class TorrentUtility

    Dim objApp As Excel.Application
    Dim objBook As Excel._Workbook
    Dim dt As New DataTable
    Private m_RsYear As New ADODB.Recordset
    Private m_RsMonths As New ADODB.Recordset
    Private m_RsMedicalRep As New ADODB.Recordset
    Private m_RsTerritory As New ADODB.Recordset
    Private m_RsDistrict As New ADODB.Recordset
    Private m_RsSalesManager As New ADODB.Recordset
    Private m_RsDistrictAnalysis As New ADODB.Recordset
    Private table As New DataTable
    Private m_RsItems As New ADODB.Recordset
    Private b As String = String.Empty
    Private DCode As String = String.Empty

    Public Property DistrictCoded() As String
        Get
            Return DCode
        End Get
        Set(ByVal value As String)
            DCode = value
        End Set
    End Property
    Public Property lastyear() As String
        Get
            Return b
        End Get
        Set(ByVal value As String)
            b = value
        End Set
    End Property
    Private Sub LoadCalendarYear()
        If m_RsYear.State = 1 Then m_RsYear.Close()
        m_RsYear.Open("SELECT DISTINCT CAYR FROM Calendar WHERE  COMID = '" & GetDefaultCompany() & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
        cboYear2.Items.Clear()
        cboYear3.Items.Clear()
        If m_RsYear.RecordCount > 0 Then
            cboYear2.Items.Add("")
            m_RsYear.MoveFirst()
            For m As Integer = 0 To m_RsYear.RecordCount - 1
                cboYear2.Items.Add(m_RsYear.Fields("CAYR").Value)
                m_RsYear.MoveNext()
            Next
            cboYear3.Items.Add("")
            m_RsYear.MoveFirst()
            For m As Integer = 0 To m_RsYear.RecordCount - 1
                cboYear3.Items.Add(m_RsYear.Fields("CAYR").Value)
                m_RsYear.MoveNext()
            Next
        End If
    End Sub

    Private Sub LoadMonths(ByVal Year As Integer, ByVal cbo As ComboBox)
        If m_RsMonths.State = 1 Then m_RsMonths.Close()
        m_RsMonths.Open("SELECT DISTINCT CAPN FROM Calendar WHERE COMID = '" & GetDefaultCompany() & "' AND  CAYR = '" & Year & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
        cbo.Items.Clear()
        If m_RsMonths.RecordCount > 0 Then
            cbo.Items.Add("")
            For m As Integer = 0 To m_RsMonths.RecordCount - 1
                cbo.Items.Add(m_RsMonths.Fields("CAPN").Value)
                m_RsMonths.MoveNext()
            Next
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim objBooks As Excel.Workbooks
        Dim objSheets As Excel.Sheets
        Dim objSheet As Excel._Worksheet
        Dim range As Excel.Range

        ' Create a new instance of Excel and start a new workbook.
        objApp = New Excel.Application()
        objBooks = objApp.Workbooks
        objBook = objBooks.Add
        objSheets = objBook.Worksheets
        objSheet = objSheets(1)

        'Get the range where the starting cell has the address
        'm_sStartingCell and its dimensions are m_iNumRows x m_iNumCols.
        range = objSheet.Range("A1", Reflection.Missing.Value)
        range = range.Resize(5, 5)

        If (Me.FillWithStrings.Checked = False) Then
            'Create an array.
            Dim saRet(5, 5) As Double
            'Fill the array.
            Dim iRow As Long
            Dim iCol As Long
            For iRow = 0 To 5
                For iCol = 0 To 5
                    'Put a counter in the cell.
                    saRet(iRow, iCol) = iRow * iCol
                Next iCol
            Next iRow

            'Set the range value to the array.
            range.Value = saRet
        Else
            'Create an array.
            Dim saRet(5, 5) As String
            'Fill the array.
            Dim iRow As Long
            Dim iCol As Long
            For iRow = 0 To 5
                For iCol = 0 To 5
                    'Put the row and column address in the cell.
                    saRet(iRow, iCol) = iRow.ToString() + "|" + iCol.ToString()
                Next iCol
            Next iRow

            'Set the range value to the array.
            range.Value = saRet
        End If

        'Return control of Excel to the user.
        objApp.Visible = True
        objApp.UserControl = True

        'Clean up a little.
        range = Nothing
        objSheet = Nothing
        objSheets = Nothing
        objBooks = Nothing
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim objSheets As Excel.Sheets
        Dim objSheet As Excel._Worksheet
        Dim range As Excel.Range

        'Get a reference to the first sheet of the workbook.
        On Error GoTo ExcelNotRunning
        objSheets = objBook.Worksheets
        objSheet = objSheets(1)

ExcelNotRunning:
        If (Not (Err.Number = 0)) Then
            MessageBox.Show("Cannot find the Excel workbook.  Try clicking Button1 to " + _
            "create an Excel workbook with data before running Button2.", _
            "Missing Workbook?")

            'We cannot automate Excel if we cannot find the data we created, 
            'so leave the subroutine.
            Exit Sub
        End If

        'Get a range of data.
        range = objSheet.Range("A1", "E5")

        'Retrieve the data from the range.
        Dim saRet(,) As Object
        saRet = range.Value

        'Determine the dimensions of the array.
        Dim iRows As Long
        Dim iCols As Long
        iRows = saRet.GetUpperBound(0)
        iCols = saRet.GetUpperBound(1)

        'Build a string that contains the data of the array.
        Dim valueString As String
        valueString = "Array Data" + vbCrLf

        Dim rowCounter As Long
        Dim colCounter As Long
        For rowCounter = 1 To iRows
            For colCounter = 1 To iCols

                'Write the next value into the string.
                valueString = String.Concat(valueString, _
                    saRet(rowCounter, colCounter).ToString() + ", ")

            Next colCounter

            'Write in a new line.
            valueString = String.Concat(valueString, vbCrLf)
        Next rowCounter

        'Report the value of the array.
        MessageBox.Show(valueString, "Array Values")

        'Clean up a little.
        range = Nothing
        objSheet = Nothing
        objSheets = Nothing
    End Sub

    Private Function LoadDistrict() As ADODB.Recordset

        Dim rs As New ADODB.Recordset
        'rs.Open("SELECT DISTINCT [District Code],[District Name] FROM SC02 WHERE [District Code] NOT IN ('HA','WAT','ZPC') AND ConfigTypeCode  = '" & cmbConfigtypeCode.Text & "' ORDER BY [District Code] ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
        rs.Open("SELECT  DISTINCT   STDISTRCTCD as [District Code]  FROM SALESMATRIX      WHERE(DLTFLG = 0) and ConfigTypeCode = '" & cmbConfigtypeCode.Text & "' and STDISTRCTCD not in ('HA','D99','ZPC')  ORDER BY STDISTRCTCD   DESC", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
        If rs.RecordCount > 0 Then
            Return rs
        Else
            Return Nothing
        End If

    End Function
    Private Function LoadSalesmaCode() As ADODB.Recordset

        Dim rs As New ADODB.Recordset
        rs.Open("SELECT Distinct STSLSMGRCD,STSLSMGRNAME  FROM  STSalesManager  Where DLTFLG = 0 and STSLSMGRCD not in('DSM99','DSMHA','DSMZPC') order by STSLSMGRCD  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
        If rs.RecordCount > 0 Then
            Return rs
        Else
            Return Nothing
        End If

    End Function

#Region "PreviousPrintReport"
    'Private Sub PRintReport()
    '    Dim objBooks As Excel.Workbooks
    '    Dim objSheets As Excel.Sheets
    '    Dim objSheet As Excel._Worksheet
    '    Dim range As Excel.Range

    '    ' Create a new instance of Excel and start a new workbook.

    '    If Not File.Exists(ReturnExePath() & "\Report\MR Reports") Then
    '        Directory.CreateDirectory(ReturnExePath() & "\Report")
    '    End If
    '    Directory.CreateDirectory(ReturnExePath() & "\Report\" & cboYear.Text)
    '    Directory.CreateDirectory(ReturnExePath() & "\Report\" & cboYear.Text & "\" & cboMonth.Text)

    '    If cboMedicalRep.Text <> "" Then
    '        objApp = New Excel.Application()
    '        objBooks = objApp.Workbooks
    '        objBook = objBooks.Add
    '        objSheets = objBook.Worksheets


    '        Directory.CreateDirectory(ReturnExePath() & "Report\MR Reports\" & cboYear.Text & "\" & cboMonth.Text & "\" & cboMedicalRep.Text & " - " & txtMedicalRep.Text)

    '        CreateMedicalRepConsolidatedSalesVsTarget(objBooks, objSheets, objSheet, range, cboMedicalRep.Text, txtMedicalRep.Text)
    '        CreateMedicalRepMonthlyChannelSales(objBooks, objSheets, objSheet, range, cboMedicalRep.Text, txtMedicalRep.Text)
    '        CreateMedicalRepConsolidatedSalesPerCompany(objBooks, objSheets, objSheet, range, cboMedicalRep.Text, txtMedicalRep.Text)


    '        objSheets.Select(1)
    '        If File.Exists(ReturnExePath() & "Report\MR Reports\" & cboYear.Text & "\" & cboMonth.Text & "\" & cboMedicalRep.Text & " - " & txtMedicalRep.Text & "\" & cboMedicalRep.Text & " - ConsolidatedSalesVsTarget as of " & cboYear.Text & "-" & cboMonth.Text & ".xls") Then
    '            Kill(ReturnExePath() & "Report\MR Reports\" & cboYear.Text & "\" & cboMonth.Text & "\" & cboMedicalRep.Text & " - " & txtMedicalRep.Text & "\" & cboMedicalRep.Text & " - ConsolidatedSalesVsTarget as of " & cboYear.Text & "-" & cboMonth.Text & ".xls")
    '        End If

    '        '     objApp.ActiveWorkbook.SaveAs(ReturnExePath() & "Report\MR Reports\" & cboYear.Text & "\" & cboMonth.Text & "\" & cboMedicalRep.Text & " - " & txtMedicalRep.Text & "\" & cboMedicalRep.Text & " - ConsolidatedSalesVsTarget as of " & cboYear.Text & "-" & cboMonth.Text & ".xls")
    '        objApp.ActiveWorkbook.SaveAs(ReturnExePath() & "Report\MR Reports\" & cboYear.Text & "\" & cboMonth.Text & "\" & cboMedicalRep.Text & " - " & txtMedicalRep.Text & "\" & cboMedicalRep.Text & " - ConsolidatedSalesVsTarget as of " & cboYear.Text & "-" & cboMonth.Text, Excel.XlFileFormat.xlExcel8)
    '        objApp.Quit()




    '    Else
    '        m_RsMedicalRep.MoveFirst()
    '        For m As Integer = 0 To m_RsMedicalRep.RecordCount - 1

    '            objApp = New Excel.Application()
    '            objBooks = objApp.Workbooks
    '            objBook = objBooks.Add

    '            objSheets = objBook.Worksheets
    '            'Directory.CreateDirectory(ReturnExePath() & "Report\MR Reports\" & cboYear.Text & "\" & cboMonth.Text & "\" & m_RsMedicalRep.Fields("SLSMNCD").Value & " - " & m_RsMedicalRep.Fields("SLSMNNAME").Value)
    '            'CreateMedicalRepConsolidatedSalesVsTarget(objBooks, objSheets, objSheet, range, m_RsMedicalRep.Fields("SLSMNCD").Value, m_RsMedicalRep.Fields("SLSMNNAME").Value)
    '            'CreateMedicalRepMonthlyChannelSales(objBooks, objSheets, objSheet, range, m_RsMedicalRep.Fields("SLSMNCD").Value, m_RsMedicalRep.Fields("SLSMNNAME").Value)
    '            'CreateMedicalRepConsolidatedSalesPerCompany(objBooks, objSheets, objSheet, range, m_RsMedicalRep.Fields("SLSMNCD").Value, m_RsMedicalRep.Fields("SLSMNNAME").Value)
    '            'objSheets.Select(1)
    '            'If File.Exists(ReturnExePath() & "Report\MR Reports\" & cboYear.Text & "\" & cboMonth.Text & "\" & m_RsMedicalRep.Fields("SLSMNCD").Value & " - " & m_RsMedicalRep.Fields("SLSMNNAME").Value & "\" & m_RsMedicalRep.Fields("SLSMNCD").Value & " - ConsolidatedSalesVsTarget as of " & cboYear.Text & "-" & cboMonth.Text & ".xls") Then
    '            '    Kill(ReturnExePath() & "Report\MR Reports\" & cboYear.Text & "\" & cboMonth.Text & "\" & m_RsMedicalRep.Fields("SLSMNCD").Value & " - " & m_RsMedicalRep.Fields("SLSMNNAME").Value & "\" & m_RsMedicalRep.Fields("SLSMNCD").Value & " - ConsolidatedSalesVsTarget as of " & cboYear.Text & "-" & cboMonth.Text & ".xls")
    '            'End If
    '            'objApp.ActiveWorkbook.SaveAs(ReturnExePath() & "Report\MR Reports\" & cboYear.Text & "\" & cboMonth.Text & "\" & m_RsMedicalRep.Fields("SLSMNCD").Value & " - " & m_RsMedicalRep.Fields("SLSMNNAME").Value & "\" & m_RsMedicalRep.Fields("SLSMNCD").Value & " - ConsolidatedSalesVsTarget as of " & cboYear.Text & "-" & cboMonth.Text & ".xls")

    '            Directory.CreateDirectory(ReturnExePath() & "Report\MR Reports\" & cboYear.Text & "\" & cboMonth.Text & "\" & m_RsMedicalRep.Fields("STTERRCD").Value & " - " & m_RsMedicalRep.Fields("STSLSMNNAME").Value)
    '            CreateMedicalRepConsolidatedSalesVsTarget(objBooks, objSheets, objSheet, range, m_RsMedicalRep.Fields("STTERRCD").Value, m_RsMedicalRep.Fields("STSLSMNNAME").Value)
    '            CreateMedicalRepMonthlyChannelSales(objBooks, objSheets, objSheet, range, m_RsMedicalRep.Fields("STTERRCD").Value, m_RsMedicalRep.Fields("STSLSMNNAME").Value)
    '            CreateMedicalRepConsolidatedSalesPerCompany(objBooks, objSheets, objSheet, range, m_RsMedicalRep.Fields("STTERRCD").Value, m_RsMedicalRep.Fields("STSLSMNNAME").Value)
    '            objSheets.Select(1)
    '            If File.Exists(ReturnExePath() & "Report\MR Reports\" & cboYear.Text & "\" & cboMonth.Text & "\" & m_RsMedicalRep.Fields("STTERRCD").Value & " - " & m_RsMedicalRep.Fields("STSLSMNNAME").Value & "\" & m_RsMedicalRep.Fields("STTERRCD").Value & " - ConsolidatedSalesVsTarget as of " & cboYear.Text & "-" & cboMonth.Text & ".xls") Then
    '                Kill(ReturnExePath() & "Report\MR Reports\" & cboYear.Text & "\" & cboMonth.Text & "\" & m_RsMedicalRep.Fields("STTERRCD").Value & " - " & m_RsMedicalRep.Fields("STSLSMNNAME").Value & "\" & m_RsMedicalRep.Fields("STTERRCD").Value & " - ConsolidatedSalesVsTarget as of " & cboYear.Text & "-" & cboMonth.Text & ".xls")
    '            End If
    '            'objApp.ActiveWorkbook.SaveAs(ReturnExePath() & "Report\MR Reports\" & cboYear.Text & "\" & cboMonth.Text & "\" & m_RsMedicalRep.Fields("STTERRCD").Value & " - " & m_RsMedicalRep.Fields("STSLSMNNAME").Value & "\" & m_RsMedicalRep.Fields("STTERRCD").Value & " - ConsolidatedSalesVsTarget as of " & cboYear.Text & "-" & cboMonth.Text & ".xls")
    '            objApp.ActiveWorkbook.SaveAs(ReturnExePath() & "Report\MR Reports\" & cboYear.Text & "\" & cboMonth.Text & "\" & m_RsMedicalRep.Fields("STTERRCD").Value & " - " & m_RsMedicalRep.Fields("STSLSMNNAME").Value & "\" & m_RsMedicalRep.Fields("STTERRCD").Value & " - ConsolidatedSalesVsTarget as of " & cboYear.Text & "-" & cboMonth.Text, FileFormat:=Excel.XlFileFormat.xlExcel8)

    '            objApp.Quit()
    '            m_RsMedicalRep.MoveNext()
    '        Next
    '    End If

    '    'Return control of Excel to the user.
    '    'objApp.Visible = True
    '    'objApp.UserControl = True

    '    'Clean up a little.
    '    range = Nothing
    '    objSheet = Nothing
    '    objSheets = Nothing
    '    objBooks = Nothing
    'End Sub
#End Region

    Private Sub PRintReport()
        Dim objBooks As Excel.Workbooks
        Dim objSheets As Excel.Sheets
        Dim objSheet As Excel._Worksheet
        Dim range As Excel.Range

        ' Create a new instance of Excel and start a new workbook.

        If Not File.Exists(ReturnExePath() & "\Report") Then
            Directory.CreateDirectory(ReturnExePath() & "\Report")
        End If
        Directory.CreateDirectory(ReturnExePath() & "\Report" & "\Medical Rep")

        Dim m_rsDistrict As ADODB.Recordset = LoadDistrict()
        For l As Integer = 0 To m_rsDistrict.RecordCount - 1

            LoadMedicalRep(m_rsDistrict.Fields("District Code").Value)
            On Error Resume Next
            m_RsMedicalRep.MoveFirst()
            Directory.CreateDirectory(ReturnExePath() & "Report" & "\Medical Rep" & "\" & m_rsDistrict.Fields("District Code").Value)
            For m As Integer = 0 To m_RsMedicalRep.RecordCount - 1
                objApp = New Excel.Application()
                objBooks = objApp.Workbooks
                objBook = objBooks.Add
                objSheets = objBook.Worksheets
                CreateMedicalRepChannel_TerritoryCode(objBooks, objSheets, objSheet, range, m_RsMedicalRep.Fields("Msr Code").Value, m_RsMedicalRep.Fields("Msr Name").Value)
                CreateSalesAnalysisReport_Territory(objBooks, objSheets, objSheet, range, m_RsMedicalRep.Fields("Msr Code").Value, m_RsMedicalRep.Fields("Msr Name").Value)
                CreateMedicalRepConsolidatedSalesVsTarget(objBooks, objSheets, objSheet, range, m_RsMedicalRep.Fields("Msr Code").Value, m_RsMedicalRep.Fields("Msr Name").Value)
                objSheets.Select(1)
                If File.Exists(ReturnExePath() & "Report" & "\Medical Rep" & "\" & m_rsDistrict.Fields("District Code").Value & "\" & m_RsMedicalRep.Fields("Msr Code").Value & " - In Market Sales Analysis Report(" & cboYear2.Text & "-" & cboMonth2.Text & ")-(" & cboYear2.Text & "-" & cboMonth3.Text & ").xls") Then
                    Kill(ReturnExePath() & "Report" & "\Medical Rep" & "\" & m_rsDistrict.Fields("District Code").Value & "\" & m_RsMedicalRep.Fields("Msr Code").Value & " - In Market Sales Analysis Report(" & cboYear2.Text & "-" & cboMonth2.Text & ")-(" & cboYear2.Text & "-" & cboMonth3.Text & ").xls")
                End If
                objApp.ActiveWorkbook.SaveAs(ReturnExePath() & "Report" & "\Medical Rep\" & m_rsDistrict.Fields("District Code").Value & "\" & m_RsMedicalRep.Fields("MSr Code").Value & " - In Market Sales Analysis Report(" & cboYear2.Text & "-" & cboMonth2.Text & ")-(" & cboYear2.Text & "-" & cboMonth3.Text & ")", FileFormat:=Excel.XlFileFormat.xlExcel8)
                objApp.Quit()
                m_RsMedicalRep.MoveNext()
            Next
            m_rsDistrict.MoveNext()
        Next

        range = Nothing
        objSheet = Nothing
        objSheets = Nothing
        objBooks = Nothing
        MsgBox("File Successfully Downloaded!", MsgBoxStyle.Information, "")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CreateHeader(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)
        objSheet.Cells(y, 1) = "Territory Code"
        objSheet.Cells(y, 2) = "Territory Name"
        objSheet.Cells(y, 3) = "Company Code"
        objSheet.Cells(y, 4) = "Customer Code"
        objSheet.Cells(y, 5) = "Customer Name"
        objSheet.Cells(y, 6) = "Product Code"
        objSheet.Cells(y, 7) = "Product Name"


        range = objSheet.Range("H" & Convert.ToString(y), "I" & Convert.ToString(y))
        range.Font.Bold = True
        range.Merge()
        range.HorizontalAlignment = Excel.Constants.xlCenter
        range.WrapText = True
        range.ShrinkToFit = False
        range.Value = "Net Achievement"
        range.Font.Bold = True

        For m As Integer = 0 To 0 Step 1
            objSheet.Cells(y + 1, m + 8) = "QTY"
            objSheet.Cells(y + 1, m + 9) = "VALUE"
        Next

    End Sub
    Private Sub CreateHeaderForperDistrictItem(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)
        objSheet.Cells(y, 1) = "Territory Code"

        range = objSheet.Range("B" & Convert.ToString(y), "H" & Convert.ToString(y))
        range.Font.Bold = True
        range.Merge()
        range.HorizontalAlignment = Excel.Constants.xlCenter
        range.WrapText = True
        range.ShrinkToFit = False
        range.Value = "RESTORADERM"
        range.Font.Bold = True
        For m As Integer = 0 To 0 Step 7
            objSheet.Cells(y + 1, m + 2) = "Value-Moist"
            objSheet.Cells(y + 1, m + 3) = "Budget-Moist"
            objSheet.Cells(y + 1, m + 4) = "Value-Wash"
            objSheet.Cells(y + 1, m + 5) = "Budget-Wash"
            objSheet.Cells(y + 1, m + 6) = "SalesTotal"
            objSheet.Cells(y + 1, m + 7) = "TargetTotal"
            objSheet.Cells(y + 1, m + 8) = "PF %"
        Next

        range = objSheet.Range("I" & Convert.ToString(y), "O" & Convert.ToString(y))
        range.Font.Bold = True
        range.Merge()
        range.HorizontalAlignment = Excel.Constants.xlCenter
        range.WrapText = True
        range.ShrinkToFit = False
        range.Value = "DERMACONTROL"
        range.Font.Bold = True
        For m As Integer = 0 To 0 Step 7
            objSheet.Cells(y + 1, m + 9) = "Value-Moist"
            objSheet.Cells(y + 1, m + 10) = "Budget-Moist"
            objSheet.Cells(y + 1, m + 11) = "Value-Wash"
            objSheet.Cells(y + 1, m + 12) = "Budget-Wash"
            objSheet.Cells(y + 1, m + 13) = "SalesTotal"
            objSheet.Cells(y + 1, m + 14) = "TargetTotal"
            objSheet.Cells(y + 1, m + 15) = "PF %"
        Next


        range = objSheet.Range("P" & Convert.ToString(y), "V" & Convert.ToString(y))
        range.Font.Bold = True
        range.Merge()
        range.HorizontalAlignment = Excel.Constants.xlCenter
        range.WrapText = True
        range.ShrinkToFit = False
        range.Value = "DESOWEN"
        range.Font.Bold = True
        For m As Integer = 0 To 0 Step 7
            objSheet.Cells(y + 1, m + 16) = "Value-Cream"
            objSheet.Cells(y + 1, m + 17) = "Budget-Cream"
            objSheet.Cells(y + 1, m + 18) = "Value-Lotion"
            objSheet.Cells(y + 1, m + 19) = "Budget-Lotion"
            objSheet.Cells(y + 1, m + 20) = "SalesTotal"
            objSheet.Cells(y + 1, m + 21) = "TargetTotal"
            objSheet.Cells(y + 1, m + 22) = "PF %"
        Next

        range = objSheet.Range("W" & Convert.ToString(y), "AA" & Convert.ToString(y))
        range.Font.Bold = True
        range.Merge()
        range.HorizontalAlignment = Excel.Constants.xlCenter
        range.WrapText = True
        range.ShrinkToFit = False
        range.Value = "EPIDUO"
        range.Font.Bold = True

        For m As Integer = 0 To 0 Step 5
            objSheet.Cells(y + 1, m + 23) = "Value-Cream"
            objSheet.Cells(y + 1, m + 24) = "Budget-Cream"
            objSheet.Cells(y + 1, m + 25) = "SalesTotal"
            objSheet.Cells(y + 1, m + 26) = "TargetTotal"
            objSheet.Cells(y + 1, m + 27) = "PF %"
        Next

        range = objSheet.Range("AB" & Convert.ToString(y), "AF" & Convert.ToString(y))
        range.Font.Bold = True
        range.Merge()
        range.HorizontalAlignment = Excel.Constants.xlCenter
        range.WrapText = True
        range.ShrinkToFit = False
        range.Value = "TETRALYSAL"
        range.Font.Bold = True

        For m As Integer = 0 To 0 Step 5
            objSheet.Cells(y + 1, m + 28) = "Value-Cream"
            objSheet.Cells(y + 1, m + 29) = "Budget-Cream"
            objSheet.Cells(y + 1, m + 30) = "SalesTotal"
            objSheet.Cells(y + 1, m + 31) = "TargetTotal"
            objSheet.Cells(y + 1, m + 32) = "PF %"
        Next
    End Sub
    Private Sub CreateHeaderTerritoryCode(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)

        objSheet.Cells(y, 1) = "Territory Code"
        objSheet.Cells(y, 2) = "Territory Name"
        objSheet.Cells(y, 3) = "Company Code "
        objSheet.Cells(y, 3) = "Customer code"
        objSheet.Cells(y, 4) = "Customer Name"
        objSheet.Cells(y, 5) = "Product Code"
        objSheet.Cells(y, 6) = "Product Name"


        range = objSheet.Range("G" & Convert.ToString(y), "H" & Convert.ToString(y))
        range.Merge()
        range.HorizontalAlignment = Excel.Constants.xlCenter
        range.WrapText = True
        range.ShrinkToFit = False
        range.Value = "Net Achievement"
        For m As Integer = 0 To 1 Step 1
            objSheet.Cells(y + 1, m + 8) = "NetQuantity"
            objSheet.Cells(y + 1, m + 9) = "NetValue"
        Next

    End Sub

    Private Function GetTerritoryPerMR(ByVal Month As String, ByVal Year As String, ByVal MRCode As String) As ADODB.Recordset
        If m_RsTerritory.State = 1 Then m_RsTerritory.Close()
        m_RsTerritory.Open("select  DISTINCT TERRCD, TERRNAME FROM vwConsolidatedSales where CUTMO = '" & Month & "' and CUTYEAR = '" & Year & "' and DETCD = '" & HandleSingleQuoteInSql(MRCode) & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
        Return m_RsTerritory
    End Function

    Private Function GetTerritoryName(ByVal TerritoryCode As String) As String
        Dim rs As New ADODB.Recordset
        rs.Open("SELECT STACOVNAME FROM STAREACOVERAGE WHERE STACOVCD = '" & HandleSingleQuoteInSql(TerritoryCode) & "' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
        If rs.RecordCount > 0 Then
            Return rs.Fields("STACOVNAME").Value
        Else
            Return ""
        End If
    End Function

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

    Private Sub CreateMedicalRepPerTerritoryCodeSaleAnalysisReport(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range)
        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(1))
        objSheet.Name = "TSMBR - Territory"

        MergeCell(objSheet, range, "A2", "G2", GetDefaultCompanyName, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        Dim Counter As Integer = 0
        Dim y As Integer = 8
        Dim yheader As Integer = 0
        Connect()
        Dim cmd As New SqlCommand("usprptTerritoryCodeperMonth", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        If dt.Rows.Count > 0 Then
            CreateHeaderTerritoryCode(objSheet, range, y + yheader)
            For l As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(l)

                If l = 0 Then
                    objSheet.Cells(10 + Counter + l, 1) = "'" & UCase(dr("Territory Code"))
                End If
                objSheet.Cells(10 + Counter + l, 2) = UCase(dr("Territory Name"))
                objSheet.Cells(10 + Counter + l, 3) = UCase(dr("Company Code"))
                objSheet.Cells(10 + Counter + l, 4) = dr("Customer Code")
                objSheet.Cells(10 + Counter + l, 5) = dr("CustomerName")
                objSheet.Cells(10 + Counter + l, 6) = dr("Item Mother Code")
                objSheet.Cells(10 + Counter + l, 7) = dr("Item Mother Name")
                objSheet.Cells(10 + Counter + l, 8) = dr("Quantity")
                objSheet.Cells(10 + Counter + l, 9) = dr("Amount")
            Next
            range = objSheet.Range("A" & Convert.ToSingle(y + Counter), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 2, dt.Columns.Count)
            'range.Font.Name = "Segoe UI"
            'range.Font.Size = 8

            range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

            range = objSheet.Range("A" & Convert.ToSingle(y + Counter), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 3, dt.Columns.Count - 1)
            range.Cells.NumberFormat = "#,##0.00"
            Counter += dt.Rows.Count + 3
            yheader += dt.Rows.Count + 3
        End If
        '    m_RsTerritory.MoveNext()
        'Next

        objSheet.Range("A1:AZ400").EntireColumn.AutoFit()
        'End If


    End Sub

    Private Sub CreateMedicalRepConsolidatedSalesVsTarget(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal MRCode As String, ByVal MRName As String)

        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(3))
        objSheet.Name = "Trade Sales"

        objSheet.Cells(2, 1) = txtconfigtypeName.Text
        range = objSheet.Range("A2", "G2")
        range.WrapText = False
        range.ShrinkToFit = False
        range.Font.Bold = True
        range.Font.Size = 9
        objSheet.Cells(3, 1) = "Trade Sales Monthly Breakdown Report"
        range = objSheet.Range("A3", "G3")
        range.WrapText = False
        range.ShrinkToFit = False
        range.Font.Bold = True
        range.Font.Size = 9
        objSheet.Cells(4, 1) = "By Distributor, By Territory, By Customer, By item (" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear2.Text & ")"
        range = objSheet.Range("A4", "G4")
        range.WrapText = False
        range.ShrinkToFit = False
        range.Font.Bold = True
        range.Font.Size = 9
        objSheet.Cells(5, 1) = "Medical Rep : " & MRCode & " - " & MRName
        range = objSheet.Range("A5", "G5")
        range.WrapText = False
        range.ShrinkToFit = False
        range.Font.Bold = True
        range.Font.Size = 9
        Connect()
        Dim Counter As Integer = 0
        Dim y As Integer = 8
        Dim yheader As Integer = 0
        Dim ctr As Integer = 0
        Dim terrname As String = GetTerritoryName(MRCode)

        objSheet.Cells(6, 1) = "Area : " & terrname
        range = objSheet.Range("A6", "G6")
        range.WrapText = False
        range.ShrinkToFit = False
        range.Font.Size = 9




        Dim cmd As New SqlCommand("usprptTerritoryCodeperMonth", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0

        cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
        cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
        cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
        cmd.Parameters.AddWithValue("@TC", MRCode)
        cmd.Parameters.AddWithValue("@ConfigTypeCode", cmbConfigtypeCode.Text)
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        If dt.Rows.Count > 0 Then
            CreateHeader(objSheet, range, y + yheader)
            For l As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Visible = True
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(l)
                objSheet.Cells(10 + Counter + l, 1) = UCase(dr("Territory Code"))
                objSheet.Cells(10 + Counter + l, 2) = UCase(dr("Territory Name"))
                objSheet.Cells(10 + Counter + l, 3) = dr("Company Code")
                objSheet.Cells(10 + Counter + l, 4) = ("'" & dr("Customer Code"))
                objSheet.Cells(10 + Counter + l, 5) = dr("CustomerName")
                objSheet.Cells(10 + Counter + l, 6) = ("'" & dr("Item Mother Code"))
                objSheet.Cells(10 + Counter + l, 7) = dr("Item Mother Name")
                objSheet.Cells(10 + Counter + l, 8) = dr("Quantity")
                objSheet.Cells(10 + Counter + l, 9) = dr("Amount")

                ctr += 1

            Next


            range = objSheet.Range("A" & Convert.ToSingle(y + Counter), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 2, dt.Columns.Count)
            range.Font.Name = "Segoe UI"
            range.Font.Size = 8

            range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

            range = objSheet.Range("A" & Convert.ToSingle(y + Counter), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 3, dt.Columns.Count - 1)
            range.Cells.NumberFormat = "#,##0.00"
            Counter += dt.Rows.Count + 7
            yheader += dt.Rows.Count + 7
        End If

        objSheet.Range("A1:AZ400").EntireColumn.AutoFit()
        ProgressBar1.Visible = False



    End Sub
    Private Sub CreateSalesAnalysisReport_Territory(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal MRCode As String, ByVal MRName As String)
        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(2))
        objSheet.Name = "SalesAnalysisReportTerritory"


        MergeCell(objSheet, range, "A2", "E2", txtconfigtypeName.Text, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A3", "E3", "In-market Sales Analysis Report - Territory :(" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear2.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A5", "E5", "Medical Rep : " & MRCode & " - " & MRName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)



        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0
        Dim b As String
        Dim ctr As Integer = 0



        Dim terrname As String = GetTerritoryName(MRCode)




        Connect()

        Dim cmd As New SqlCommand("uspSalesAnalysisReport_Territory", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
        cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
        cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
        cmd.Parameters.AddWithValue("@TerritoryCode", MRCode)
        cmd.Parameters.AddWithValue("@ConfigTypeCode", cmbConfigtypeCode.Text)
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        If dt.Rows.Count > 0 Then
            CreateHeaderForAMMonthlySalesTerritoryCode(objSheet, range, y + yheader)
            For l As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Visible = True
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(l)
                If l = 0 Then
                    objSheet.Cells(8 + Counter + l, 1) = m_RsMedicalRep.Fields("MSR CODE").Value
                End If
                objSheet.Cells(8 + Counter + l, 2) = (dr("ITEMTEAMGROUP"))
                objSheet.Cells(8 + Counter + l, 3) = (dr("PRODUCT"))
                objSheet.Cells(8 + Counter + l, 4) = dr("MDC")
                objSheet.Cells(8 + Counter + l, 5) = dr("INH")
                objSheet.Cells(8 + Counter + l, 6) = dr("ZPC")
                objSheet.Cells(8 + Counter + l, 7) = dr("TOTAL")
                objSheet.Cells(8 + Counter + l, 8) = dr("FC")
                objSheet.Cells(8 + Counter + l, 9) = dr("PERF %") * 100 & Format("%")
                objSheet.Cells(8 + Counter + l, 10) = dr("MDC")
                objSheet.Cells(8 + Counter + l, 11) = dr("GROWTH %") * 100 & Format("%")
                objSheet.Cells(8 + Counter + l, 12) = dr("INH")
                objSheet.Cells(8 + Counter + l, 13) = dr("GROWTH %") * 100 & Format("%")
                objSheet.Cells(8 + Counter + l, 14) = dr("ZPC")
                objSheet.Cells(8 + Counter + l, 15) = dr("GROWTH %") * 100 & Format("%")
                objSheet.Cells(8 + Counter + l, 16) = dr("TOTAL")
                objSheet.Cells(8 + Counter + l, 17) = dr("FC")
                objSheet.Cells(8 + Counter + l, 18) = dr("PREF%") & Format("%")
                ctr += 1
            Next
        End If

        range = objSheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count + 1)
        range.Font.Name = "Segoe UI"
        range.Font.Size = 8

        range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

        range = objSheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        range.Cells.NumberFormat = "#,##0.00"
        Counter += dt.Rows.Count + 3
        yheader += dt.Rows.Count + 3


        objSheet.Range("A1:AZ400").EntireColumn.AutoFit()
        ProgressBar1.Visible = False
    End Sub
    Private Sub CreateMedicalRepChannel_TerritoryCode(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal MRCode As String, ByVal MRName As String)


        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(1))
        objSheet.Name = "Territory - Sales Per Channel"


        MergeCell(objSheet, range, "A2", "E2", txtconfigtypeName.Text, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A3", "E3", "Sales Summary Per Channel :(" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear2.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A5", "E5", "Medical Rep : " & MRCode & " - " & MRName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)



        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0
        Dim ctr As Integer = 0



        Dim terrname As String = GetTerritoryName(MRCode)




        Connect()

        Dim cmd As New SqlCommand("uspRptPerChannelMedicalrep", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@TerritoryCode", MRCode)
        cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
        cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
        cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
        cmd.Parameters.AddWithValue("@ConfigTypeCode", cmbConfigtypeCode.Text)
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        If dt.Rows.Count > 0 Then
            CreteHeaderNationalPerchannelTerritory(objSheet, range, y + yheader)
            For l As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Visible = True
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(l)
                objSheet.Cells(8 + Counter + l, 1) = dr("Company Code")
                objSheet.Cells(8 + Counter + l, 2) = dr("Amount")
                objSheet.Cells(8 + Counter + l, 3) = dr("Percentage") & Format("%")
                ctr += 1
            Next
        End If

        range = objSheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        'range.Font.Name = "Segoe UI"
        'range.Font.Size = 8

        range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

        range = objSheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        range.Cells.NumberFormat = "#,##0.00"
        Counter += dt.Rows.Count + 3
        yheader += dt.Rows.Count + 3


        objSheet.Range("A1:AZ400").EntireColumn.AutoFit()
        ProgressBar1.Visible = False

    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Dispose()
    End Sub
    Private Sub LoadSalesManCode(Optional ByVal SalemanCode As String = "")
        If m_RsMedicalRep.State = 1 Then m_RsMedicalRep.Close()
        'm_RsMedicalRep.Open("SELECT SLSMNCD, SLSMNNAME FROM MedicalRep Where DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)

        If SalemanCode = "" Then
            m_RsMedicalRep.Open("select [District Manager Code],[District Manager Name] from SC02 Where [District Manager Code] not in('DSM99','DSMHA','DSMZPC') and ConfigTypeCode = '" & cmbConfigtypeCode.Text & "' order by [District Manager Code]", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
        Else
            m_RsMedicalRep.Open("SELECT Distinct STSLSMGRCD  FROM  STSalesManager  Where DLTFLG = 0 and STSLSMGRCD not in('DSM99','DSMHA','DSMZPC')  and STSLSMGRCD = '" & SalemanCode & "' order by STSLSMGRCD ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
        End If

        'If m_RsMedicalRep.RecordCount > 0 Then

        For m As Integer = 0 To m_RsMedicalRep.RecordCount - 1
            'cboMedicalRep.Items.Add(m_RsMedicalRep.Fields("STSLSMGRCD").Value)
            'm_RsMedicalRep.MoveNext()

        Next
        ''End If
    End Sub
    Private Sub LoadMedicalRep(Optional ByVal DistrictCd As String = "")
        If m_RsMedicalRep.State = 1 Then m_RsMedicalRep.Close()
        'm_RsMedicalRep.Open("SELECT SLSMNCD, SLSMNNAME FROM MedicalRep Where DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
        If DistrictCd = "" Then
            m_RsMedicalRep.Open("SELECT DISTINCT stterrcd as  [MSR CODE],stslsmnname as  [MSR NAME] FROM  salesmatrix  WHERE stterrcd NOT IN ('HA','WAT','ZPC') and (dltflg = 0)  And ConfigTypeCode = '" & cmbConfigtypeCode.Text & "' And Month(EffectivityEndDate) = '" & cboMonth3.Text & "' And Year(EffectivityEndDate) = '" & cboYear2.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
            'm_RsMedicalRep.Open("SELECT DISTINCT stterrcd as  [MSR CODE],stslsmnname as  [MSR NAME] FROM  salesmatrix  WHERE stterrcd NOT IN ('HA','WAT','ZPC') and (dltflg = 0)  And ConfigTypeCode = '" & cmbConfigtypeCode.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
        Else
            m_RsMedicalRep.Open("Select Distinct stterrcd as [MSR Code], stslsmnname as [MSR Name] from salesmatrix  where stterrcd not in ('999','MDC','PM','SSD','WAT','Z') and (dltflg = 0) and ConfigTypeCode = '" & cmbConfigtypeCode.Text & "'  and  STDISTRCTCD = '" & DistrictCd & "' And Month(EffectivityEndDate) = '" & cboMonth3.Text & "' And Year(EffectivityEndDate) = '" & cboYear2.Text & "' order by stterrcd", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
            'm_RsMedicalRep.Open("Select Distinct stterrcd as [MSR Code], stslsmnname as [MSR Name] from salesmatrix  where stterrcd not in ('999','MDC','PM','SSD','WAT','Z') and (dltflg = 0) and ConfigTypeCode = '" & cmbConfigtypeCode.Text & "'  and  STDISTRCTCD = '" & DistrictCd & "' order by stterrcd", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
        End If
    End Sub
    Private Sub loadConfigType()
        table = GetRecords("Select ConfigTypeCode,ConfigTypeName from ConfigurationType")
        For i As Integer = 0 To table.Rows.Count - 1
            cmbConfigtypeCode.Items.Add(table.Rows(i)("ConfigTypeCode"))
        Next
    End Sub
    Private Sub loadMedicalRepTer()

        If m_RsMedicalRep.State = 1 Then m_RsMedicalRep.Close()

            m_RsMedicalRep.Open("select distinct stterrcd, stslsmnname from salesmatrix where(dltflg = 0) and STTERRCD not in('999','Z')  order by stterrcd ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
        'cboMedicalRep.Items.Clear()
        If m_RsMedicalRep.RecordCount > 0 Then
            For m As Integer = 0 To m_RsMedicalRep.RecordCount - 1
                'cboMedicalRep.Items.Add(m_RsMedicalRep.Fields("stterrcd").Value)
                m_RsMedicalRep.MoveNext()
            Next
        End If
    End Sub

    Private Sub LoadSalesManager()
        If m_RsSalesManager.State = 1 Then m_RsSalesManager.Close()
        'm_RsSalesManager.Open("select Distinct [District Manager Code],[District Manager Name] from SC02 where [District Manager Code] not in('DSM99','DSMHA','DSMZPC') and ConfigTypeCode = '" & cmbConfigtypeCode.Text & "' Order by [District Manager Code] ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
        m_RsSalesManager.Open("SELECT Distinct STSLSMGRCD as [District Manager Code] ,STSLSMGRNAME as [District Manager Name]  FROM  STSalesManager  Where DLTFLG = 0 and STSLSMGRCD not in('DSM99','DSMHA','DSMZPC') and ConfigTypeCode = '" & cmbConfigtypeCode.Text & "'order by STSLSMGRCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
        'cboAM.Items.Clear()
        If m_RsSalesManager.RecordCount > 0 Then
            For m As Integer = 0 To m_RsSalesManager.RecordCount - 1
                'cboAM.Items.Add(m_RsSalesManager.Fields("STSLSMGRCD").Value)
                m_RsSalesManager.MoveNext()
            Next
        End If

    End Sub

    Private Function LoadSalesManagerForDownloading() As ADODB.Recordset

        Dim rs As New ADODB.Recordset
        rs.Open("SELECT Distinct STSLSMGRCD as [District Manager Code] ,STSLSMGRNAME as [District Manager Name]  FROM  STSalesManager  Where DLTFLG = 0 and STSLSMGRCD not in('DSM99','DSMHA','DSMZPC') and ConfigTypeCode = '" & cmbConfigtypeCode.Text & "'order by STSLSMGRCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
        If rs.RecordCount > 0 Then
            Return rs
        Else
            Return Nothing
        End If

    End Function

    Private Sub TorrentUtility_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'LoadMedicalRep()
        'LoadSalesManager()
        LoadCalendarYear()
        loadConfigType()

    End Sub

    Private Sub CreteHeaderNationalPerchannelTerritory(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)
        objSheet.Cells(y, 1) = "Company Code"
        objSheet.Cells(y, 2) = "Amount"
        objSheet.Cells(y, 3) = "% Share"

        range = objSheet.Range("A" & Convert.ToString(y) & ":AA" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter

    End Sub

    Private Sub CreateHeaderForSalesPerCompany(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range)

        objSheet.Cells(8, 1) = "Channel"
        objSheet.Cells(8, 2) = "Customer Code"
        objSheet.Cells(8, 3) = "Customer Name"
        objSheet.Cells(8, 4) = "Item Code"
        objSheet.Cells(8, 5) = "Item Name"
        objSheet.Cells(8, 6) = "Gross Quantity"
        objSheet.Cells(8, 7) = "Gross Value"
        objSheet.Cells(8, 8) = "Return Quantity"
        objSheet.Cells(8, 9) = "Return Value"
        objSheet.Cells(8, 10) = "Net Quantity"
        objSheet.Cells(8, 11) = "Net Value"

        range = objSheet.Range("A8:K8")
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter

    End Sub

    Private Sub CreateMedicalRepConsolidatedSalesPerCompany(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal MRCode As String, ByVal MRName As String)
        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(3))
        objSheet.Name = "Monthly Report Per Channel"

        MergeCell(objSheet, range, "A2", "K2", GetDefaultCompanyName, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A3", "K3", "Monthly Report Per Channel for the month of :  (" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear3.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A5", "K5", "Medical Rep : " & MRCode & " - " & MRName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)


        Connect()

        Dim cmd As New SqlCommand("uspMRPerCompanySales", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        'cmd.Parameters.AddWithValue("@Month", cboMonth.Text)
        'cmd.Parameters.AddWithValue("@Year", cboYear.Text)
        cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
        cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
        cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
        cmd.Parameters.AddWithValue("@Year2", cboYear3.Text)
        cmd.Parameters.AddWithValue("@MRCode", MRCode)
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        If dt.Rows.Count > 0 Then
            CreateHeaderForSalesPerCompany(objSheet, range)
            For l As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(l)
                objSheet.Cells(9 + l, 1) = (dr("COMID"))
                objSheet.Cells(9 + l, 2) = ("'" & dr("CUST"))
                objSheet.Cells(9 + l, 3) = dr("CNAME")
                objSheet.Cells(9 + l, 4) = "'" & dr("PROD")
                objSheet.Cells(9 + l, 5) = dr("PDES")
                objSheet.Cells(9 + l, 6) = dr("GrossQty")
                objSheet.Cells(9 + l, 7) = dr("GrossValue")
                objSheet.Cells(9 + l, 8) = dr("ReturnQty")
                objSheet.Cells(9 + l, 9) = dr("ReturnValue")
                objSheet.Cells(9 + l, 10) = dr("NetQty")
                objSheet.Cells(9 + l, 11) = dr("NetValue")
            Next
        End If

        range = objSheet.Range("A8", Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        'range.Font.Name = "Segoe UI"
        'range.Font.Size = 8

        range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

        range = objSheet.Range("A8", Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        range.Cells.NumberFormat = "#,##0.00"

        objSheet.Range("A1:AZ400").EntireColumn.AutoFit()
    End Sub

    Private Sub CreateMedicalRepMonthlyChannelSales(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal MRCode As String, ByVal MRName As String)
        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(2))
        objSheet.Name = "Mo. Sales Rpt Per Channel Cust"

        MergeCell(objSheet, range, "A2", "D2", GetDefaultCompanyName, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A3", "D3", "Monthly Sales Rpt Per Channel Customer  for  the month of :  (" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear3.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A5", "D5", "Medical Rep : " & MRCode & " - " & MRName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)


        Connect()

        Dim cmd As New SqlCommand("uspMRMonthlyChannelSales", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
        cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
        cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
        cmd.Parameters.AddWithValue("@Year2", cboYear3.Text)
        cmd.Parameters.AddWithValue("@MRCode", MRCode)
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        If dt.Rows.Count > 0 Then
            CreateHeaderForMonthlySalesPerCompany(objSheet, range)
            For l As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(l)
                objSheet.Cells(9 + l, 1) = (dr("COMID"))
                objSheet.Cells(9 + l, 2) = (dr("DISTNAME"))
                objSheet.Cells(9 + l, 3) = dr("Net Achievement")
                objSheet.Cells(9 + l, 4) = dr("Percent Contribution") & "%"
            Next
        End If

        range = objSheet.Range("A8", Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        range.Font.Name = "Segoe UI"
        range.Font.Size = 8

        range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous
        range = objSheet.Range("A8", Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count - 1)
        range.Cells.NumberFormat = "#,##0.00"
        objSheet.Range("A1:AZ400").EntireColumn.AutoFit()
    End Sub

    Private Sub CreateHeaderForMonthlySalesPerCompany(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range)

        objSheet.Cells(8, 1) = "Channel Code"
        objSheet.Cells(8, 2) = "Channel Name"
        objSheet.Cells(8, 3) = "Net Achievement"
        objSheet.Cells(8, 4) = "Percent Contribution"

        range = objSheet.Range("A8:D8")
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter

    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If cmbConfigtypeCode.Text = "" Then
            MsgBox("Select the ConfigTypeCode", MsgBoxStyle.Exclamation)
        ElseIf cboYear2.Text = String.Empty Then
            MsgBox("Select the  from Year ", MsgBoxStyle.Exclamation)
        ElseIf cboMonth2.Text = String.Empty Then
            MsgBox("Select the Month set from", MsgBoxStyle.Exclamation)
        ElseIf cboMonth3.Text = String.Empty Then
            MsgBox("Select the Month set to", MsgBoxStyle.Exclamation)
        Else

            If chkNationalReport.Checked Then
                PrintNationalReport()
            ElseIf chkForAM.Checked Then
                PRintAMReport()
            ElseIf chkMedicalRep.Checked Then
                PRintReport()
            ElseIf optItem.Checked Then
                PrintItemReport()
            ElseIf RadioButton1.Checked Then
                printDonwloadPerTerritorycode()
            ElseIf chkConsolitededDistrict.Checked Then
                PrintConsolidatedDistrict()
            ElseIf ChkconsolitededTerrity.Checked Then
                PrintConsolidatedTerritory()
            ElseIf checkitemdistrict.Checked Then
                PrintCheckItemDistrict()
            End If
        End If

    End Sub
    Private Sub PrintCheckItemDistrict()

        Dim objBooks As Excel.Workbooks
        Dim objSheets As Excel.Sheets
        Dim objSheet As Excel._Worksheet
        Dim range As Excel.Range
        If Not File.Exists(ReturnExePath() & "\Report\District and Territory Items") Then
            Directory.CreateDirectory(ReturnExePath() & "\Report\District and Territory Items")
        End If
        LoadSalesManager()
        m_RsSalesManager.MoveFirst()
        objApp = New Excel.Application()
        objBooks = objApp.Workbooks
        objBook = objBooks.Add
        objSheets = objBook.Worksheets

        Dim ctr As Integer = 1
        For m As Integer = 0 To m_RsSalesManager.RecordCount - 1
            m_RsDistrict = GetDistrictPerAM(m_RsSalesManager.Fields("District Manager Code").Value)
            If CreateDistrictItems(objBooks, objSheets, objSheet, range, ctr, m_RsSalesManager.Fields("District Manager Code").Value, m_RsSalesManager.Fields("District Manager Name").Value) Then ctr += 1
            m_RsSalesManager.MoveNext()
        Next
        objSheets.Select(1)
        If File.Exists(ReturnExePath() & "\Report\District and Territory Items\District and Territory Items.xls") Then
            Kill(ReturnExePath() & "\Report\District and Territory Items\District and Territory Items.xls")
        End If
        objApp.ActiveWorkbook.SaveAs(ReturnExePath() & "Report\District and Territory Items\District and Territory Items", Excel.XlFileFormat.xlExcel8)
        objApp.Quit()
        range = Nothing
        objSheet = Nothing
        objSheets = Nothing
        objBooks = Nothing
        MsgBox("File Successfully Downloaded!", MsgBoxStyle.Information, "")
    End Sub
    Private Function CreateDistrictItems(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal index As Integer, ByVal AMCode As String, ByVal AMName As String) As Boolean
        On Error Resume Next

        m_RsDistrict.MoveFirst()

        For m As Integer = 0 To m_RsDistrict.RecordCount - 1

            Connect()
            Dim cmd As New SqlCommand("usprptperItemdownload", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
            cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
            cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
            cmd.Parameters.AddWithValue("@DistrictCode", m_RsDistrict.Fields("District Code").Value)
            cmd.Parameters.AddWithValue("@ConfigTypeCode", cmbConfigtypeCode.Text)
            Dim da As New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            Disconnect()

            If dt.Columns.Count <= 1 Then
                Return False
            End If
            If dt.Rows.Count = 0 Then
                Return False
            End If

            objSheet = objSheets.Add

            objSheet.Move(After:=objSheets(index))
            If AMName.IndexOf(" ") < 2 Then
                objSheet.Name = AMCode & "-" & AMName.Substring(0, AMName.Length)
            Else
                objSheet.Name = AMCode & "-" & AMName.Substring(0, AMName.IndexOf(" "))
            End If

            objSheet.Cells(2, 1) = txtconfigtypeName.Text
            range = objSheet.Range("A2", "A2")

            range.WrapText = False
            range.ShrinkToFit = False
            range.Font.Size = 15
            range.Font.Bold = True

            objSheet.Cells(4, 1) = "Item performance Per District Per Territory"
            range = objSheet.Range("A4", "A4")

            range.WrapText = False
            range.ShrinkToFit = False
            range.Font.Size = 13
            range.Font.Bold = True

            objSheet.Cells(5, 1) = "DistrictCode:  " & AMCode & " - " & AMName - "(" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear2.Text & ")"
            range = objSheet.Range("A5", "A5")

            range.WrapText = False
            range.ShrinkToFit = False
            range.Font.Size = 11
            range.Font.Bold = True

            Dim Counter As Integer = 0
            Dim y As Integer = 8
            Dim yheader As Integer = 0
            Dim ctr As Integer = 0



            CreateHeaderForperDistrictItem(objSheet, range, y + yheader)
            For l As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Visible = True
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(l)
                objSheet.Cells(10 + Counter + l, 1) = (dr("Territory"))
                objSheet.Cells(10 + Counter + l, 2) = (dr("RMOIST"))
                objSheet.Cells(10 + Counter + l, 3) = dr("RTMOIST")
                objSheet.Cells(10 + Counter + l, 4) = dr("RSWASH")
                objSheet.Cells(10 + Counter + l, 5) = dr("RTWASH")
                objSheet.Cells(10 + Counter + l, 6) = dr("RSTOTAL")
                objSheet.Cells(10 + Counter + l, 7) = dr("RTTOTAL")
                objSheet.Cells(10 + Counter + l, 8) = dr("RPF")
                objSheet.Cells(10 + Counter + l, 9) = dr("DERMSMOIST")
                objSheet.Cells(10 + Counter + l, 10) = dr("DERMTMOIST")
                objSheet.Cells(10 + Counter + l, 11) = dr("DERMSWASH")
                objSheet.Cells(10 + Counter + l, 12) = dr("DERMTWASH")
                objSheet.Cells(10 + Counter + l, 13) = dr("DERMSTOTAL")
                objSheet.Cells(10 + Counter + l, 14) = dr("DERMTTOTAL")
                objSheet.Cells(10 + Counter + l, 15) = dr("DERMPF")
                objSheet.Cells(10 + Counter + l, 16) = dr("DESSCREAM")
                objSheet.Cells(10 + Counter + l, 17) = dr("DESTCREAM")
                objSheet.Cells(10 + Counter + l, 18) = dr("DESSLOTION")
                objSheet.Cells(10 + Counter + l, 19) = dr("DESTLOTION")
                objSheet.Cells(10 + Counter + l, 20) = dr("DESSTOTAL")
                objSheet.Cells(10 + Counter + l, 21) = dr("DESTTOTAL")
                objSheet.Cells(10 + Counter + l, 22) = dr("DESPF")
                objSheet.Cells(10 + Counter + l, 23) = dr("ESGEL")
                objSheet.Cells(10 + Counter + l, 24) = dr("ETGEL")
                objSheet.Cells(10 + Counter + l, 25) = dr("ESTOTAL")
                objSheet.Cells(10 + Counter + l, 26) = dr("ETTOTAL")
                objSheet.Cells(10 + Counter + l, 27) = dr("EPF")
                objSheet.Cells(10 + Counter + l, 28) = dr("TESGEL")
                objSheet.Cells(10 + Counter + l, 29) = dr("TETGEL")
                objSheet.Cells(10 + Counter + l, 30) = dr("TETSTOTAL")
                objSheet.Cells(10 + Counter + l, 31) = dr("TETTOTAL")
                objSheet.Cells(10 + Counter + l, 32) = dr("TEPF")
                ctr += 1
            Next
            range = objSheet.Range("A" & Convert.ToString(y + Counter), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 2, dt.Columns.Count)
            range.Font.Name = "Segoe UI"
            range.Font.Size = 8

            range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous
            range = objSheet.Range("A" & Convert.ToString(y + Counter), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 3, dt.Columns.Count - 1)
            range.Cells.NumberFormat = "#,##0.00"
            objSheet.Range("B1:AZ400").EntireColumn.AutoFit()

            Counter += dt.Rows.Count + 3
            yheader += dt.Rows.Count + 3
            m_RsDistrict.MoveNext()
        Next

        ProgressBar1.Visible = False

        Return True

    End Function
    Private Sub PrintConsolidatedTerritory()

        Dim objBooks As Excel.Workbooks
        Dim objSheets As Excel.Sheets
        Dim objSheet As Excel._Worksheet
        Dim range As Excel.Range
        If Not File.Exists(ReturnExePath() & "\Report\Consolidated Sales  Territory") Then
            Directory.CreateDirectory(ReturnExePath() & "\Report\Consolidated Sales Territory")
        End If
        m_RsMedicalRep = loadterritoryCode()
        objApp = New Excel.Application()
        objBooks = objApp.Workbooks
        objBook = objBooks.Add
        objSheets = objBook.Worksheets
        Dim ctr As Integer = 1
        For m As Integer = 0 To m_RsMedicalRep.RecordCount - 1
            If CreateTerritryPerMonthSalesAnlysisReport(objBooks, objSheets, objSheet, range, ctr, m_RsMedicalRep.Fields("MSR Code").Value, m_RsMedicalRep.Fields("MSR Name").Value) Then ctr += 1
            m_RsMedicalRep.MoveNext()
        Next
        CreateConsolidatedTerritory(objBooks, objSheets, objSheet, range)
        objSheets.Select(1)
        If File.Exists(ReturnExePath() & "Report\Consolidated Sales Territory\Consolidated Sales Territory Report.xls") Then
            Kill(ReturnExePath() & "Report\Consolidated Sales  Territory\Consolidated Sales Territory Report.xls")
        End If
        objApp.ActiveWorkbook.SaveAs(ReturnExePath() & "Report\Consolidated Sales Territory\Consolidated Sales Territory Report", Excel.XlFileFormat.xlExcel8)
        objApp.Quit()
        range = Nothing
        objSheet = Nothing
        objSheets = Nothing
        objBooks = Nothing
        MsgBox("File Successfull Downloaded!", MsgBoxStyle.Information, "Successfull")
    End Sub
    Private Sub PrintConsolidatedDistrict()

        Dim objBooks As Excel.Workbooks
        Dim objSheets As Excel.Sheets
        Dim objSheet As Excel._Worksheet
        Dim range As Excel.Range
        If Not File.Exists(ReturnExePath() & "\Report\Consolidated Sale District") Then
            Directory.CreateDirectory(ReturnExePath() & "\Report\Consolidated Sales District")
        End If
        LoadSalesManager()
        m_RsSalesManager.MoveFirst()
        objApp = New Excel.Application()
        objBooks = objApp.Workbooks
        objBook = objBooks.Add
        objSheets = objBook.Worksheets

        Dim ctr As Integer = 1
        For m As Integer = 0 To m_RsSalesManager.RecordCount - 1
            m_RsDistrict = GetDistrictPerAM(m_RsSalesManager.Fields("District Manager Code").Value)
            If CreateDistrictConsolidatedReport(objBooks, objSheets, objSheet, range, ctr, m_RsSalesManager.Fields("District Manager Code").Value, m_RsSalesManager.Fields("District Manager Name").Value) Then ctr += 1
            m_RsSalesManager.MoveNext()
        Next
        CreateConsolidatedDistrict(objBooks, objSheets, objSheet, range)
        objSheets.Select(1)
        If File.Exists(ReturnExePath() & "Report\Consolidated Sales District\Consolidated Sales District Report.xls") Then
            Kill(ReturnExePath() & "Report\Consolidated Sales District\Consolidated Sales District Report.xls")
        End If
        objApp.ActiveWorkbook.SaveAs(ReturnExePath() & "Report\Consolidated Sales District\Consolidated Sales District Report", Excel.XlFileFormat.xlExcel8)
        objApp.Quit()
        range = Nothing
        objSheet = Nothing
        objSheets = Nothing
        objBooks = Nothing
        MsgBox("File Successfully Downloaded!", MsgBoxStyle.Information, "")

    End Sub

    Private Sub printDonwloadPerTerritorycode()
        Dim objBooks As Excel.Workbooks
        Dim objSheets As Excel.Sheets
        Dim objSheet As Excel._Worksheet
        Dim range As Excel.Range
        If Not File.Exists(ReturnExePath() & "\Report\CustomerlistingTerritory ") Then
            Directory.CreateDirectory(ReturnExePath() & "\Report\CustomerlistingTerritory")
        End If
        m_RsMedicalRep = loadterritoryCode()
        objApp = New Excel.Application()
        objBooks = objApp.Workbooks
        objBook = objBooks.Add
        objSheets = objBook.Worksheets
        Dim ctr As Integer = 1
        For m As Integer = 0 To m_RsMedicalRep.RecordCount - 1
            If CreateTerritryPerMonth(objBooks, objSheets, objSheet, range, ctr, m_RsMedicalRep.Fields("Msr Code").Value, m_RsMedicalRep.Fields("Msr Name").Value) Then ctr += 1
            m_RsMedicalRep.MoveNext()
        Next
        objSheets.Select(1)
        If File.Exists(ReturnExePath() & "Report\CustomerlistingTerritory\Customer listing per Territory.xls") Then
            Kill(ReturnExePath() & "Report\CustomerlistingTerritory\Customer listing per Territory.xls")
        End If
        objApp.ActiveWorkbook.SaveAs(ReturnExePath() & "Report\CustomerlistingTerritory\Customer listing per Territory", Excel.XlFileFormat.xlExcel8)
        objApp.Quit()
        range = Nothing
        objSheet = Nothing
        objSheets = Nothing
        objBooks = Nothing
        MsgBox("File Successfully Downloaded!", MsgBoxStyle.Information, "")
    End Sub

    Private Function GetDistrictPerAM(ByVal AMCode As String) As ADODB.Recordset
        If m_RsDistrict.State = 1 Then m_RsDistrict.Close()
        m_RsDistrict.Open("SELECT DISTINCT [District Code],[District Name] FROM SC02 WHERE [District Code] NOT IN ('HA','ZPC','D99') AND [District Manager Code] = '" & AMCode & "' and ConfigTypeCode = '" & cmbConfigtypeCode.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
        Return m_RsDistrict
    End Function
    Private Sub printDistrictreport()

        Dim objBooks As Excel.Workbooks
        Dim objSheets As Excel.Sheets
        Dim objSheet As Excel._Worksheet
        Dim range As Excel.Range

        ' Create a new instance of Excel and start a new workbook.

        If Not File.Exists(ReturnExePath() & "\Report") Then
            Directory.CreateDirectory(ReturnExePath() & "\Report")
        End If
        Directory.CreateDirectory(ReturnExePath() & "\Report" & "\DM Reports")
        m_RsSalesManager.MoveFirst()
        For m As Integer = 0 To m_RsSalesManager.RecordCount - 1

            objApp = New Excel.Application()
            objBooks = objApp.Workbooks
            objBook = objBooks.Add

            objSheets = objBook.Worksheets
            Directory.CreateDirectory(ReturnExePath() & "Report\" & "DM Reports" & "\" & m_RsSalesManager.Fields("STSLSMGRCD").Value & " - " & m_RsSalesManager.Fields("STSLSMGRNAME").Value)


            m_RsDistrictAnalysis = GetDistrictPerAM(m_RsSalesManager.Fields("STSLSMGRCD").Value)
            If m_RsDistrictAnalysis.RecordCount > 0 Then

                If File.Exists(ReturnExePath() & "Report\" & "DM Reports" & "\" & m_RsSalesManager.Fields("STSLSMGRCD").Value & " - " & m_RsSalesManager.Fields("STSLSMGRNAME").Value & "\" & m_RsSalesManager.Fields("STSLSMGRCD").Value & " - ConsolidatedSalesVsTarget as of (" & cboYear2.Text & "-" & cboMonth2.Text & ")-(" & cboYear3.Text & "-" & cboMonth3.Text & ").xls") Then
                    Kill(ReturnExePath() & "Report\" & "DM Reports" & "\" & m_RsSalesManager.Fields("STSLSMGRCD").Value & " - " & m_RsSalesManager.Fields("STSLSMGRNAME").Value & "\" & m_RsSalesManager.Fields("STSLSMGRCD").Value & " - ConsolidatedSalesVsTarget as of (" & cboYear2.Text & "-" & cboMonth2.Text & ")-(" & cboYear3.Text & "-" & cboMonth3.Text & ").xls")
                End If

                'objApp.ActiveWorkbook.SaveAs(ReturnExePath() & "Report\AM Reports\" & cboYear.Text & "\" & cboMonth.Text & "\" & m_RsSalesManager.Fields("STSLSMGRCD").Value & " - " & m_RsSalesManager.Fields("STSLSMGRNAME").Value & "\" & m_RsSalesManager.Fields("STSLSMGRCD").Value & " - ConsolidatedSalesVsTarget as of " & cboYear.Text & "-" & cboMonth.Text & ".xls")
                objApp.ActiveWorkbook.SaveAs(ReturnExePath() & "Report\" & "DM Reports" & "\" & m_RsSalesManager.Fields("STSLSMGRCD").Value & " - " & m_RsSalesManager.Fields("STSLSMGRNAME").Value & "\" & m_RsSalesManager.Fields("STSLSMGRCD").Value & " - ConsolidatedSalesVsTarget as of (" & cboYear2.Text & "-" & cboMonth2.Text & ")-(" & cboYear3.Text & "-" & cboMonth3.Text & ")", Excel.XlFileFormat.xlExcel8)
            End If
            objApp.Quit()
            m_RsSalesManager.MoveNext()
        Next
        ' ''End If
        range = Nothing
        objSheet = Nothing
        objSheets = Nothing
        objBooks = Nothing
    End Sub

    Private Sub PRintAMReport()

        Dim ctr As Integer = 0
        Dim objBooks As Excel.Workbooks = Nothing
        Dim objSheets As Excel.Sheets = Nothing
        Dim objSheet As Excel._Worksheet = Nothing
        Dim range As Excel.Range = Nothing

        If Not File.Exists(ReturnExePath() & "\Report") Then
            Directory.CreateDirectory(ReturnExePath() & "\Report")
        End If
        Directory.CreateDirectory(ReturnExePath() & "\Report" & "\Area Manager")
        Dim m_RsSalesManager As ADODB.Recordset = LoadSalesManagerForDownloading()
        On Error Resume Next
        m_RsSalesManager.MoveFirst()
        For m As Integer = 0 To m_RsSalesManager.RecordCount - 1

            objApp = New Excel.Application()
            objBooks = objApp.Workbooks
            objBook = objBooks.Add
            objSheets = objBook.Worksheets

            Directory.CreateDirectory(ReturnExePath() & "Report\" & "Area Manager" & "\" & m_RsSalesManager.Fields("District Manager Code").Value & " - " & m_RsSalesManager.Fields("District Manager Name").Value)

            m_RsDistrict = GetDistrictPerAM(m_RsSalesManager.Fields("District Manager Code").Value)
            If m_RsDistrict.RecordCount > 0 Then
                CreateAMMPerChannelSales(objBooks, objSheets, objSheet, range, m_RsSalesManager.Fields("District Manager Code").Value, m_RsSalesManager.Fields("District Manager Name").Value)
                CreateAMMonthlyPerDistrictCode(objBooks, objSheets, objSheet, range, m_RsSalesManager.Fields("District Manager Code").Value, m_RsSalesManager.Fields("District Manager Name").Value)
                CreateAMMonthlyDistrictCode(objBooks, objSheets, objSheet, range, m_RsSalesManager.Fields("District Manager Code").Value, m_RsSalesManager.Fields("District Manager Name").Value)
                objSheets.Select(1)
                If File.Exists(ReturnExePath() & "Report\" & "Area Manager" & "\" & m_RsSalesManager.Fields("District Manager Code").Value & " - " & m_RsSalesManager.Fields("District Manager Name").Value & "\" & m_RsSalesManager.Fields("District Manager Code").Value & " - In Market  Sales Analysis Report(" & cboYear2.Text & "-" & cboMonth2.Text & ")-(" & cboYear2.Text & "-" & cboMonth3.Text & ").xls") Then
                    Kill(ReturnExePath() & "Report\" & "Area Manager" & "\" & m_RsSalesManager.Fields("District Manager Code").Value & " - " & m_RsSalesManager.Fields("District Manager Name").Value & "\" & m_RsSalesManager.Fields("District Manager Code").Value & " - In Market Sales Analysis Report(" & cboYear2.Text & "-" & cboMonth2.Text & ")-(" & cboYear2.Text & "-" & cboMonth3.Text & ").xls")
                End If
                objApp.ActiveWorkbook.SaveAs(ReturnExePath() & "Report\" & "Area Manager" & "\" & m_RsSalesManager.Fields("District Manager Code").Value & " - " & m_RsSalesManager.Fields("District Manager Name").Value & "\" & m_RsSalesManager.Fields("District Manager Code").Value & " - In Market Sales Analysis Report (" & cboYear2.Text & "-" & cboMonth2.Text & ")-(" & cboYear2.Text & "-" & cboMonth3.Text & ")", Excel.XlFileFormat.xlExcel8)
            End If
            objApp.Quit()
            m_RsSalesManager.MoveNext()
        Next
        range = Nothing
        objSheet = Nothing
        objSheets = Nothing
        objBooks = Nothing
        MsgBox("File Successfully Downloaded!", MsgBoxStyle.Information, "")

    End Sub
    Private Sub CreateConsolidatedDistrict(ByVal objbooks As Excel.Workbooks, ByVal objsheets As Excel.Sheets, ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range)
        objsheet = objsheets.Add
        objsheet.Move(After:=objsheets(1))
        objsheet.Name = "Summ.ConsDistrict"
        MergeCell(objsheet, range, "A2", "F2", txtconfigtypeName.Text, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objsheet, range, "A3", "F3", "Consolidated Sales Per District : (" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear2.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader = 0
        Dim ctr As Integer = 0

        Connect()

        Dim cmd As New SqlCommand("uspRptConsolidatedDistrict", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@year", cboYear2.Text)
        cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
        cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
        cmd.Parameters.AddWithValue("@ConfigTypeCode", cmbConfigtypeCode.Text)
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        If dt.Rows.Count > 0 Then
            CreateheaderConsolidatedDistrict(objsheet, range, y + yheader)
            For l As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(l)
                ProgressBar1.Visible  = True
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                objsheet.Cells(8 + Counter + l, 1) = dr("District Name")
                objsheet.Cells(8 + Counter + l, 2) = dr("Promoted")
                objsheet.Cells(8 + Counter + l, 3) = dr("Percentage")
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

        range = objsheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        range.Cells.NumberFormat = "#,##0.00"

        Counter += dt.Rows.Count + 3
        yheader += dt.Rows.Count + 3

        objsheet.Range("A1:AZ400").EntireColumn.AutoFit()

        ProgressBar1.Visible = False
    End Sub
    Private Sub CreateConsolidatedTerritory(ByVal objbooks As Excel.Workbooks, ByVal objsheets As Excel.Sheets, ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range)
        objsheet = objsheets.Add
        objsheet.Move(After:=objsheets(1))
        objsheet.Name = "Summ.ConsTerritory"
        MergeCell(objsheet, range, "A2", "G2", txtconfigtypeName.Text, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objsheet, range, "A3", "G3", "Consolidated Sales Per Territory : (" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear2.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0
        Dim ctr As Integer = 0
        Connect()
        Dim cmd As New SqlCommand("uspRptCosolidatedTerritory", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@year", cboYear2.Text)
        cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
        cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
        cmd.Parameters.AddWithValue("@ConfigTypeCode", cmbConfigtypeCode.Text)
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        If dt.Rows.Count > 0 Then
            CreateHeaderConsolidatedTerritory(objsheet, range, y + yheader)
            For l As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Visible = True
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(l)
                objsheet.Cells(8 + Counter + l, 1) = dr("MSR Code")
                objsheet.Cells(8 + Counter + l, 2) = dr("MSR Name")
                objsheet.Cells(8 + Counter + l, 3) = dr("Promoted")
                objsheet.Cells(8 + Counter + l, 4) = dr("Percentage")
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

        range = objsheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        range.Cells.NumberFormat = "#,##0.00"

        Counter += dt.Rows.Count + 4
        yheader += dt.Rows.Count + 4

        objsheet.Range("A1:AZ400").EntireColumn.AutoFit()

        ProgressBar1.Visible = False
    End Sub
    Private Sub CreateheaderConsolidatedDistrict(ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)
        objsheet.Cells(y, 1) = "District Name"
        objsheet.Cells(y, 2) = "Amount"
        objsheet.Cells(y, 3) = "% Share"

        range = objsheet.Range("A" & Convert.ToString(y) & ":C" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter

    End Sub
    Private Sub CreateHeaderConsolidatedTerritory(ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)
        objsheet.Cells(y, 1) = "MSR Code" '
        objsheet.Cells(y, 2) = "MSR Name"
        objsheet.Cells(y, 3) = "Amount"
        objsheet.Cells(y, 4) = "% Share"

        range = objsheet.Range("A" & Convert.ToString(y) & ":D" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter

    End Sub

    Private Sub CreatePerChannelofNational(ByVal objbooks As Excel.Workbooks, ByVal objsheets As Excel.Sheets, ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range)
        objsheet = objsheets.Add

        objsheet.Move(After:=objsheets(1))
        objsheet.Name = "National - Sales Per Channel"

        MergeCell(objsheet, range, "A2", "G2", txtconfigtypeName.Text, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objsheet, range, "A3", "G3", "National Sales Per Channel :  (" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear2.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        '  MergeCell(objSheet, range, "A5", "G5", "Area Manager: " & AMCode & " - " & AMName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)


        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0
        Dim ctr As Integer = 0

        Connect()
        Dim cmd As New SqlCommand("uspRptPerChannel", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
        cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
        cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
        cmd.Parameters.AddWithValue("@ConfigtypeCode", cmbConfigtypeCode.Text)
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        If dt.Rows.Count > 0 Then
            CreteHeaderNationalPerchannel(objsheet, range, y + yheader)
            For l As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Visible = True
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(l)
                objsheet.Cells(8 + Counter + l, 1) = dr("Company Code")
                objsheet.Cells(8 + Counter + l, 2) = dr("Item Division Name")
                objsheet.Cells(8 + Counter + l, 3) = dr("Amount")
                objsheet.Cells(8 + Counter + l, 4) = dr("Percentage")
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

        range = objsheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        range.Cells.NumberFormat = "#,##0.00"

        Counter += dt.Rows.Count + 3
        yheader += dt.Rows.Count + 3

        objsheet.Range("A1:AZ400").EntireColumn.AutoFit()

        ProgressBar1.Visible = False

    End Sub

    Private Sub CreatePerChannelNationalperDivision(ByVal objbooks As Excel.Workbooks, ByVal objsheets As Excel.Sheets, ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range)
        objsheet = objsheets.Add

        objsheet.Move(After:=objsheets(1))
        objsheet.Name = "National - Sales Per Channel Per Division"

        MergeCell(objsheet, range, "A2", "G2", txtconfigtypeName.Text, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objsheet, range, "A3", "G3", "National Sales Per Channel :  (" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear2.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        '  MergeCell(objSheet, range, "A5", "G5", "Area Manager: " & AMCode & " - " & AMName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)


        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0
        Dim ctr As Integer = 0

        Connect()
        Dim cmd As New SqlCommand("uspRptPerChannelPerDivision", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
        cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
        cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
        cmd.Parameters.AddWithValue("@ConfigtypeCode", cmbConfigtypeCode.Text)
        cmd.Parameters.AddWithValue("@itemdiv1", cmbItemdiv1.Text)
        cmd.Parameters.AddWithValue("@itemdiv2", cmbItemdiv2.Text)
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        If dt.Rows.Count > 0 Then
            CreteHeaderNationalPerchannel(objsheet, range, y + yheader)
            For l As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Visible = True
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(l)
                objsheet.Cells(8 + Counter + l, 1) = dr("Company Code")
                objsheet.Cells(8 + Counter + l, 2) = dr("Item Division Name")
                objsheet.Cells(8 + Counter + l, 3) = dr("Amount")
                objsheet.Cells(8 + Counter + l, 4) = dr("Percentage")
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

        range = objsheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        range.Cells.NumberFormat = "#,##0.00"

        Counter += dt.Rows.Count + 3
        yheader += dt.Rows.Count + 3

        objsheet.Range("A1:AZ400").EntireColumn.AutoFit()

        ProgressBar1.Visible = False

    End Sub
    Private Sub CreateAMMedrepWise(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal AMCode As String, ByVal AMName As String)
        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(2))
        objSheet.Name = "AM - MedRep Wise"

        MergeCell(objSheet, range, "A2", "G2", GetDefaultCompanyName, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A3", "G3", "AM - MedRep Wise  for  the month of :  (" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear3.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A5", "G5", "Area Manager: " & AMCode & " - " & AMName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)

        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0


        For m As Integer = 0 To m_RsDistrict.RecordCount - 1


            Connect()

            Dim cmd As New SqlCommand("uspTPIAMMedrepWise", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            'cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
            'cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
            cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
            cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
            cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
            cmd.Parameters.AddWithValue("@Year2", cboYear3.Text)
            cmd.Parameters.AddWithValue("@DistrictCode", m_RsDistrict.Fields("STDISTRCTCD").Value)
            Dim da As New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            Disconnect()
            If dt.Rows.Count > 0 Then
                CreateHeaderForAMMedRepWise(objSheet, range, y + yheader)
                For l As Integer = 0 To dt.Rows.Count - 1
                    Dim dr As DataRow = dt.Rows(l)

                    If l = 0 Then
                        objSheet.Cells(8 + Counter + l, 1) = m_RsDistrict.Fields("STDISTRCTCD").Value
                    End If

                    objSheet.Cells(8 + Counter + l, 2) = "'" & (dr("TerrCd"))
                    objSheet.Cells(8 + Counter + l, 3) = (dr("DETCD"))
                    objSheet.Cells(8 + Counter + l, 4) = dr("SSE")
                    objSheet.Cells(8 + Counter + l, 5) = dr("Net")
                    objSheet.Cells(8 + Counter + l, 6) = dr("Target")
                    objSheet.Cells(8 + Counter + l, 7) = dr("Percentage")
                Next
            End If

            range = objSheet.Range("A" & Convert.ToString(y + Counter), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count + 1)
            'range.Font.Name = "Segoe UI"
            'range.Font.Size = 8

            range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

            range = objSheet.Range("A" & Convert.ToString(y + Counter), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
            range.Cells.NumberFormat = "#,##0.00"
            Counter += dt.Rows.Count + 3
            yheader += dt.Rows.Count + 3
            m_RsDistrict.MoveNext()
        Next
        objSheet.Range("A1:AZ400").EntireColumn.AutoFit()
    End Sub
    Private Sub CreteHeaderNationalPerchannel(ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)
        objsheet.Cells(y, 1) = "Channel Code"
        objsheet.Cells(y, 2) = "Item Division Name"
        objsheet.Cells(y, 3) = "Amount"
        objsheet.Cells(y, 4) = "% Share"

        range = objsheet.Range("A" & Convert.ToString(y) & ":D" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter
    End Sub
    Private Sub CreateHeaderForAMMedRepWise(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)

        objSheet.Cells(y, 1) = "District"
        objSheet.Cells(y, 2) = "Territory"
        objSheet.Cells(y, 3) = "Med Rep Code"
        objSheet.Cells(y, 4) = "Med Rep Name"
        objSheet.Cells(y, 5) = "Net Sales"
        objSheet.Cells(y, 6) = "Target Sales"
        objSheet.Cells(y, 7) = "Percentage"

        range = objSheet.Range("A" & Convert.ToString(y) & ":G" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter

    End Sub
    Private Sub CreateHeaderForDistrictAnalysis(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)

        objSheet.Cells(y, 1) = "Product"
        objSheet.Cells(y, 2) = "MDC"
        objSheet.Cells(y, 3) = "ZPC"
        objSheet.Cells(y, 4) = "INH"
        objSheet.Cells(y, 5) = "TOTAL"
        objSheet.Cells(y, 6) = "FC"
        objSheet.Cells(y, 7) = "PERF%"
        objSheet.Cells(y, 8) = "MDC"
        objSheet.Cells(y, 9) = "GROWTH %"
        objSheet.Cells(y, 10) = "ZPC"
        objSheet.Cells(y, 11) = "GROWTH %"
        objSheet.Cells(y, 12) = "INH"
        objSheet.Cells(y, 13) = "GROWTH %"
        objSheet.Cells(y, 14) = "TOTAL"
        objSheet.Cells(y, 15) = "GROWTH %"
        objSheet.Cells(y, 16) = "FC"
        objSheet.Cells(y, 17) = "PERF%"


        range = objSheet.Range("A" & Convert.ToString(y) & ":X" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter

    End Sub


    Private Sub CreateAMMonthlyDistrictCode(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal AMCode As String, ByVal AMName As String)


        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(3))
        objSheet.Name = "InmarketAnalysis"

        MergeCell(objSheet, range, "A2", "E2", txtconfigtypeName.Text, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A3", "E3", "In-market Sales Analysis Report - District:  (" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear2.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A5", "E5", "Area Manager : " & AMCode & " - " & AMName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)


        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0
        Dim b As String
        Dim ctr As Integer = 0

        m_RsDistrict.MoveFirst()

        For m As Integer = 0 To m_RsDistrict.RecordCount - 1

            Connect()

            Dim cmd As New SqlCommand("uspSalesAnalysisReport_District", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
            cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
            cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
            cmd.Parameters.AddWithValue("@DisctrictCode", m_RsDistrict.Fields("District Code").Value)
            cmd.Parameters.AddWithValue("@ConfigTypeCode", cmbConfigtypeCode.Text)
            Dim da As New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            Disconnect()
            If dt.Rows.Count > 0 Then
                CreateHeaderForAMMonthlySalesPerCompany(objSheet, range, y + yheader)
                For l As Integer = 0 To dt.Rows.Count - 1
                    ProgressBar1.Visible = True
                    ProgressBar1.Value = ctr / dt.Rows.Count * 100
                    Dim dr As DataRow = dt.Rows(l)
                    If l = 0 Then
                        objSheet.Cells(8 + Counter + l, 1) = m_RsDistrict.Fields("District Code").Value
                    End If
                    objSheet.Cells(8 + Counter + l, 2) = (dr("ITEMTEAMGROUP"))
                    objSheet.Cells(8 + Counter + l, 3) = (dr("PRODUCT"))
                    objSheet.Cells(8 + Counter + l, 4) = dr("MDC")
                    objSheet.Cells(8 + Counter + l, 5) = dr("ZPC")
                    objSheet.Cells(8 + Counter + l, 6) = dr("INH")
                    objSheet.Cells(8 + Counter + l, 7) = dr("TOTAL")
                    objSheet.Cells(8 + Counter + l, 8) = dr("FC")
                    objSheet.Cells(8 + Counter + l, 9) = dr("PERF %") * 100 & Format("%")
                    objSheet.Cells(8 + Counter + l, 10) = dr("MDC1")
                    objSheet.Cells(8 + Counter + l, 11) = dr("GROWTH %") * 100 & Format("%")
                    objSheet.Cells(8 + Counter + l, 12) = dr("ZPC1")
                    objSheet.Cells(8 + Counter + l, 13) = dr("GROWTH %1") * 100 & Format("%")
                    objSheet.Cells(8 + Counter + l, 14) = dr("INH1")
                    objSheet.Cells(8 + Counter + l, 15) = dr("GROWTH %2") * 100 & Format("%")
                    objSheet.Cells(8 + Counter + l, 16) = dr("TOTAL1")
                    objSheet.Cells(8 + Counter + l, 17) = dr("GROWHTLA")
                    objSheet.Cells(8 + Counter + l, 18) = dr("FC1")
                    objSheet.Cells(8 + Counter + l, 19) = dr("PREF%") & Format("%")
                    ctr += 1
                Next
            End If

            range = objSheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count + 1)
            range.Font.Name = "Segoe UI"
            range.Font.Size = 8

            range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

            range = objSheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
            range.Cells.NumberFormat = "#,##0.00"
            Counter += dt.Rows.Count + 3
            yheader += dt.Rows.Count + 3
            m_RsDistrict.MoveNext()
        Next

        objSheet.Range("A1:AZ400").EntireColumn.AutoFit()
        ProgressBar1.Visible = False

    End Sub
    Private Sub CreateAMMPerChannelSales(ByVal objBooks As Excel.Workbooks, ByVal objsheets As Excel.Sheets, ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal AMCode As String, ByVal AMName As String)

        objsheet = objsheets.Add

        objsheet.Move(After:=objsheets(1))
        objsheet.Name = "District-SalesPerChannel"

        MergeCell(objsheet, range, "A2", "E2", txtconfigtypeName.Text, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objsheet, range, "A3", "E3", "Sales Summary Per Channel :(" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear2.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objsheet, range, "A5", "E5", "Area Manager : " & AMCode & " - " & AMName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)


        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0
        Dim ctr As Integer = 0
        m_RsDistrict.MoveFirst()

        For m As Integer = 0 To m_RsDistrict.RecordCount - 1

            Connect()

            Dim cmd As New SqlCommand("uspRptPerChannelDistrict", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
            cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
            cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
            cmd.Parameters.AddWithValue("@DistrictCode", m_RsDistrict.Fields("District Code").Value)
            cmd.Parameters.AddWithValue("@ConfigTypeCode", cmbConfigtypeCode.Text)
            Dim da As New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            Disconnect()
            If dt.Rows.Count > 0 Then
                CreateHeaderForperChannelDistrict(objsheet, range, y + yheader)
                For l As Integer = 0 To dt.Rows.Count - 1
                    ProgressBar1.Visible = True
                    ProgressBar1.Value = ctr / dt.Rows.Count * 100
                    Dim dr As DataRow = dt.Rows(l)
                    objsheet.Cells(8 + Counter + l, 1) = dr("Company Code")
                    objsheet.Cells(8 + Counter + l, 2) = dr("Amount")
                    objsheet.Cells(8 + Counter + l, 3) = dr("Percentage")
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

            range = objsheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
            range.Cells.NumberFormat = "#,##0.00"

            objsheet.Range("A1:AZ400").EntireColumn.AutoFit()

            m_RsDistrict.MoveNext()
        Next
        ProgressBar1.Visible = False
    End Sub

    Private Sub CreateAMMonthlyPerDistrictCode(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal AMCode As String, ByVal AMName As String)


        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(2))
        objSheet.Name = "Summ.perTerritory"

        MergeCell(objSheet, range, "A2", "E2", txtconfigtypeName.Text, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A3", "E3", "Sales Summary Per Territory :  (" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear2.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A5", "E5", "Area Manager : " & AMCode & " - " & AMName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)


        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0
        Dim ctr As Integer = 0
        On Error Resume Next
        m_RsDistrict.MoveFirst()

        For m As Integer = 0 To m_RsDistrict.RecordCount - 1

            Connect()

            Dim cmd As New SqlCommand("uspRptPerDestrict", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
            cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
            cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
            cmd.Parameters.AddWithValue("@DisctrictCode", m_RsDistrict.Fields("District Code").Value)
            cmd.Parameters.AddWithValue("@ConfigTypeCode", cmbConfigtypeCode.Text)
            Dim da As New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            Disconnect()
            If dt.Rows.Count > 0 Then
                CreateHeaderForDistrict(objSheet, range, y + yheader)
                For l As Integer = 0 To dt.Rows.Count - 1
                    ProgressBar1.Visible = True
                    ProgressBar1.Value = ctr / dt.Rows.Count * 100
                    Dim dr As DataRow = dt.Rows(l)
                    objSheet.Cells(8 + Counter + l, 1) = "'" & (dr("District Code"))
                    objSheet.Cells(8 + Counter + l, 2) = "'" & (dr("Territory Code"))
                    objSheet.Cells(8 + Counter + l, 3) = (dr("MSR Name"))
                    objSheet.Cells(8 + Counter + l, 4) = dr("NetValue")
                    objSheet.Cells(8 + Counter + l, 5) = dr("TargetValue")
                    objSheet.Cells(8 + Counter + l, 6) = "'" & (dr("Growth"))
                    objSheet.Cells(8 + Counter + l, 7) = "'" & (dr("Percentage"))
                    ctr += 1
                Next
            End If

            range = objSheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
            range.Font.Name = "Segoe UI"
            range.Font.Size = 8

            range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

            range = objSheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count - 1)
            range.Cells.NumberFormat = "#,##0.00"

            objSheet.Range("A1:AZ400").EntireColumn.AutoFit()

            m_RsDistrict.MoveNext()
        Next
        ProgressBar1.Visible = False

        'objSheet.Range("A1:AZ400").EntireColumn.AutoFit()
    End Sub
    Private Sub CreateAMMonthlyChannelSales(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal AMCode As String, ByVal AMName As String)
        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(2))
        objSheet.Name = "Mo. Sales Rpt Per Channel Cust"

        MergeCell(objSheet, range, "A2", "E2", GetDefaultCompanyName, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A3", "E3", "Monthly Sales Rpt Per Channel Customer  for  the month of :  (" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear3.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A5", "E5", "Area Manager : " & AMCode & " - " & AMName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)


        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0

        m_RsDistrict.MoveFirst()

        For m As Integer = 0 To m_RsDistrict.RecordCount - 1

            Connect()

            Dim cmd As New SqlCommand("uspAMMonthlyChannelSales", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            'cmd.Parameters.AddWithValue("@Month", cboMonth.Text)
            'cmd.Parameters.AddWithValue("@Year", cboYear.Text)
            cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
            cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
            cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
            cmd.Parameters.AddWithValue("@Year2", cboYear3.Text)
            cmd.Parameters.AddWithValue("@DistrictCode", m_RsDistrict.Fields("STDISTRCTCD").Value)
            Dim da As New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            Disconnect()
            If dt.Rows.Count > 0 Then
                CreateHeaderForAMMonthlySalesPerCompany(objSheet, range, y + yheader)
                For l As Integer = 0 To dt.Rows.Count - 1
                    Dim dr As DataRow = dt.Rows(l)
                    If l = 0 Then
                        objSheet.Cells(8 + Counter + l, 1) = m_RsDistrict.Fields("STDISTRCTCD").Value
                    End If

                    objSheet.Cells(8 + Counter + l, 2) = (dr("COMID"))
                    objSheet.Cells(8 + Counter + l, 3) = (dr("DISTNAME"))
                    objSheet.Cells(8 + Counter + l, 4) = dr("Net Achievement")
                    objSheet.Cells(8 + Counter + l, 5) = dr("Percent Contribution") & "%"
                Next
            End If

            range = objSheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count + 1)
            'range.Font.Name = "Segoe UI"
            'range.Font.Size = 8

            range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

            range = objSheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
            range.Cells.NumberFormat = "#,##0.00"
            Counter += dt.Rows.Count + 3
            yheader += dt.Rows.Count + 3
            m_RsDistrict.MoveNext()
        Next

        objSheet.Range("A1:AZ400").EntireColumn.AutoFit()
    End Sub
    Private Sub CreateHeaderForperChannelDistrict(ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)
        objsheet.Cells(y, 1) = "Channel Code"
        objsheet.Cells(y, 2) = "Amount"
        objsheet.Cells(y, 3) = "% Share"
        range = objsheet.Range("A" & Convert.ToString(y) & ":C" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter
    End Sub
    Private Sub CreateHeaderForDistrict(ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)
        objsheet.Cells(y, 1) = "District Code"
        objsheet.Cells(y, 2) = "Territory Code" '
        objsheet.Cells(y, 3) = "Med Rep Name"
        objsheet.Cells(y, 4) = "Net Value"
        objsheet.Cells(y, 5) = "Target Value"
        objsheet.Cells(y, 6) = "Growth %"
        objsheet.Cells(y, 7) = "Perf %"

        range = objsheet.Range("A" & Convert.ToString(y) & ":G" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter

    End Sub
    Private Sub CreateHeaderForAMMonthlySalesPerCompany(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)

        objSheet.Cells(y, 1) = "DISTRICTCODE"
        objSheet.Cells(y, 2) = "CATEGORY"
        objSheet.Cells(y, 3) = "PRODUCT"
        objSheet.Cells(y, 4) = "MDC"
        objSheet.Cells(y, 5) = "ZPC"
        objSheet.Cells(y, 6) = "INH"
        objSheet.Cells(y, 7) = "TOTAL"
        objSheet.Cells(y, 8) = "FC"
        objSheet.Cells(y, 9) = "PERF %"
        objSheet.Cells(y, 10) = "MDC"
        objSheet.Cells(y, 11) = "GR %"
        objSheet.Cells(y, 12) = "ZPC"
        objSheet.Cells(y, 13) = "GR %"
        objSheet.Cells(y, 14) = "INH"
        objSheet.Cells(y, 15) = "GR %"
        objSheet.Cells(y, 16) = "TOTAL"
        objSheet.Cells(y, 17) = "GR %"
        objSheet.Cells(y, 18) = "FC"
        objSheet.Cells(y, 19) = "PERF %"


        range = objSheet.Range("A" & Convert.ToString(y) & ":AA" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter

    End Sub
    Private Sub CreateHeaderForAMMonthlySalesTerritoryCode(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)

        objSheet.Cells(y, 1) = "Territory Code"
        objSheet.Cells(y, 2) = "CATEGORY"
        objSheet.Cells(y, 3) = "PRODUCT"
        objSheet.Cells(y, 4) = "MDC"
        objSheet.Cells(y, 5) = "INH"
        objSheet.Cells(y, 6) = "ZPC"
        objSheet.Cells(y, 7) = "TOTAL"
        objSheet.Cells(y, 8) = "FC"
        objSheet.Cells(y, 9) = "PERF %"
        objSheet.Cells(y, 10) = "MDC"
        objSheet.Cells(y, 11) = "GR %"
        objSheet.Cells(y, 12) = "INH"
        objSheet.Cells(y, 13) = "GR %"
        objSheet.Cells(y, 14) = "ZPC"
        objSheet.Cells(y, 15) = "GR %"
        objSheet.Cells(y, 16) = "TOTAL"
        objSheet.Cells(y, 17) = "FC"
        objSheet.Cells(y, 18) = "PERF %"


        range = objSheet.Range("A" & Convert.ToString(y) & ":AA" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter

    End Sub
    Private Sub CreateHeaderForNationalallDistrict(ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)

        objsheet.Cells(y, 1) = "CATEGORY"
        objsheet.Cells(y, 2) = "PRODUCT"
        objsheet.Cells(y, 3) = "MDC"
        objsheet.Cells(y, 4) = "ZPC"
        objsheet.Cells(y, 5) = "INH"
        objsheet.Cells(y, 6) = "TOTAL"
        objsheet.Cells(y, 7) = "FC"
        objsheet.Cells(y, 8) = "PERF %"
        objsheet.Cells(y, 9) = "MDC"
        objsheet.Cells(y, 10) = "GR %"
        objsheet.Cells(y, 11) = "ZPC"
        objsheet.Cells(y, 12) = "GR %"
        objsheet.Cells(y, 13) = "INH"
        objsheet.Cells(y, 14) = "GR %"
        objsheet.Cells(y, 15) = "TOTAL"
        objsheet.Cells(y, 16) = "GR %"
        objsheet.Cells(y, 17) = "FC"
        objsheet.Cells(y, 18) = "PERF %"

        range = objsheet.Range("A" & Convert.ToString(y) & ":Z" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter

    End Sub

    Private Sub CreateAMConsolidatedSalesVsTarget(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal AMCode As String, ByVal AMName As String)
        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(3))
        objSheet.Name = "CONSOL TGT VS ACH MTHLY"


        MergeCell(objSheet, range, "A2", "L2", GetDefaultCompanyName, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A3", "L3", "AM - CONSOLIDATED TGT VS ACH  SALES REPORT FOR THE MONTH OF :   (" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear3.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A5", "L5", "Area Manager :  " & AMCode & " - " & AMName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)

        Connect()

        Dim Counter As Integer = 0
        Dim y As Integer = 8
        Dim yheader As Integer = 0

        m_RsDistrict.MoveFirst()
        If m_RsDistrict.RecordCount > 0 Then

            '  objSheet.Cells(7, 2) = "Area Coverage Code:" & m_RsTerritory.Fields("TERRCD").Value
            'MergeCell(objSheet, range, "A6", "L6", "Area : " & m_RsDistrict.Fields("STDISTRCTNAME").Value, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
            For m As Integer = 0 To m_RsDistrict.RecordCount - 1

                Dim cmd As New SqlCommand("uspTPICosilidatedVsTargetPerAM", SPMSConn2)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandTimeout = 0
                'cmd.Parameters.AddWithValue("@Month", cboMonth.Text)
                'cmd.Parameters.AddWithValue("@Year", cboYear.Text)
                cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
                cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
                cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
                cmd.Parameters.AddWithValue("@Year2", cboYear3.Text)
                cmd.Parameters.AddWithValue("@DistrictCode", m_RsDistrict.Fields("STDISTRCTCD").Value)
                Dim da As New SqlDataAdapter(cmd)
                dt = New DataTable
                da.Fill(dt)
                Disconnect()
                If dt.Rows.Count > 0 Then
                    CreateHeader(objSheet, range, y + yheader)
                    For l As Integer = 0 To dt.Rows.Count - 1
                        Dim dr As DataRow = dt.Rows(l)

                        If l = 0 Then
                            objSheet.Cells(10 + Counter + l, 1) = "'" & m_RsDistrict.Fields("STDISTRCTCD").Value
                        End If

                        objSheet.Cells(10 + Counter + l, 2) = "'" & UCase(dr("ITEMCD"))
                        objSheet.Cells(10 + Counter + l, 3) = UCase(dr("PDES"))
                        objSheet.Cells(10 + Counter + l, 4) = dr("TargetQTY")
                        objSheet.Cells(10 + Counter + l, 5) = dr("TargetValue")
                        objSheet.Cells(10 + Counter + l, 6) = dr("GrossQTY")
                        objSheet.Cells(10 + Counter + l, 7) = dr("GrossValue")
                        objSheet.Cells(10 + Counter + l, 8) = dr("ReturnQty")
                        objSheet.Cells(10 + Counter + l, 9) = dr("ReturnValue")
                        objSheet.Cells(10 + Counter + l, 10) = dr("NetQTY")
                        objSheet.Cells(10 + Counter + l, 11) = dr("NetValue")
                        objSheet.Cells(10 + Counter + l, 12) = dr("PErf")
                    Next


                    range = objSheet.Range("A" & Convert.ToSingle(y + Counter), Reflection.Missing.Value)
                    range = range.Resize(dt.Rows.Count + 2, dt.Columns.Count)
                    'range.Font.Name = "Segoe UI"
                    'range.Font.Size = 8

                    range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
                    range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

                    range = objSheet.Range("A" & Convert.ToSingle(y + Counter), Reflection.Missing.Value)
                    range = range.Resize(dt.Rows.Count + 3, dt.Columns.Count - 1)
                    range.Cells.NumberFormat = "#,##0.00"
                    Counter += dt.Rows.Count + 3
                    yheader += dt.Rows.Count + 3
                End If
                m_RsDistrict.MoveNext()
            Next

            objSheet.Range("A1:AZ400").EntireColumn.AutoFit()
        End If




    End Sub

    Private Sub CreateAMConsolidatedSalesPerCompany(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal AMCode As String, ByVal AMName As String)
        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(4))
        objSheet.Name = "Monthly Report Per Channel"

        MergeCell(objSheet, range, "A2", "K2", GetDefaultCompanyName, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A3", "K3", "AM - Monthly Report Per Channel for the month of :  (" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear3.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A5", "K5", "Area Manager : " & AMCode & " - " & AMName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)


        Dim Counter As Integer = 0
        Dim y As Integer = 8
        Dim yheader As Integer = 0

        If m_RsDistrict.RecordCount > 0 Then
            m_RsDistrict.MoveFirst()

            For m As Integer = 0 To m_RsDistrict.RecordCount - 1

                Connect()

                Dim cmd As New SqlCommand("uspAMPerCompanySales", SPMSConn2)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandTimeout = 0
                'cmd.Parameters.AddWithValue("@Month", cboMonth.Text)
                'cmd.Parameters.AddWithValue("@Year", cboYear.Text)
                cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
                cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
                cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
                cmd.Parameters.AddWithValue("@Year2", cboYear3.Text)
                cmd.Parameters.AddWithValue("@DistrictCode", m_RsDistrict.Fields("STDISTRCTCD").Value)
                Dim da As New SqlDataAdapter(cmd)
                dt = New DataTable
                da.Fill(dt)
                Disconnect()
                If dt.Rows.Count > 0 Then
                    CreateHeaderForAMSalesPerCompany(objSheet, range, y + yheader)
                    For l As Integer = 0 To dt.Rows.Count - 1
                        Dim dr As DataRow = dt.Rows(l)
                        If l = 0 Then
                            objSheet.Cells(9 + Counter + l, 1) = m_RsDistrict.Fields("STDISTRCTCD").Value
                        End If
                        objSheet.Cells(9 + Counter + l, 2) = (dr("COMID"))
                        objSheet.Cells(9 + Counter + l, 3) = ("'" & dr("CUST"))
                        objSheet.Cells(9 + Counter + l, 4) = dr("CNAME")
                        objSheet.Cells(9 + Counter + l, 5) = "'" & dr("PROD")
                        objSheet.Cells(9 + Counter + l, 6) = dr("PDES")
                        objSheet.Cells(9 + Counter + l, 7) = dr("GrossQty")
                        objSheet.Cells(9 + Counter + l, 8) = dr("GrossValue")
                        objSheet.Cells(9 + Counter + l, 9) = dr("ReturnQty")
                        objSheet.Cells(9 + Counter + l, 10) = dr("ReturnValue")
                        objSheet.Cells(9 + Counter + l, 11) = dr("NetQty")
                        objSheet.Cells(9 + Counter + l, 12) = dr("NetValue")
                    Next
                End If

                range = objSheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
                range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count + 1)
                'range.Font.Name = "Segoe UI"
                'range.Font.Size = 8

                range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
                range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

                range = objSheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
                range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count + 1)
                range.Cells.NumberFormat = "#,##0.00"
                Counter += dt.Rows.Count + 3
                yheader += dt.Rows.Count + 3
                m_RsDistrict.MoveNext()
            Next

            objSheet.Range("A1:AZ400").EntireColumn.AutoFit()
        End If
    End Sub

    Private Sub CreateHeaderForAMSalesPerCompany(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)

        objSheet.Cells(y, 1) = "District"
        objSheet.Cells(y, 2) = "Channel"
        objSheet.Cells(y, 3) = "Customer Code"
        objSheet.Cells(y, 4) = "Customer Name"
        objSheet.Cells(y, 5) = "Item Code"
        objSheet.Cells(y, 6) = "Item Name"
        objSheet.Cells(y, 7) = "Gross Quantity"
        objSheet.Cells(y, 8) = "Gross Value"
        objSheet.Cells(y, 9) = "Return Quantity"
        objSheet.Cells(y, 10) = "Return Value"
        objSheet.Cells(y, 11) = "Net Quantity"
        objSheet.Cells(y, 12) = "Net Value"

        range = objSheet.Range("A" & Convert.ToString(y) & ":L" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter

    End Sub
    Private Sub PrintNationalReport()
        Dim objBooks As Excel.Workbooks
        Dim objSheets As Excel.Sheets
        Dim objSheet As Excel._Worksheet
        Dim range As Excel.Range
        Dim b As String


        ' Create a new instance of Excel and start a new workbook.

        If Not File.Exists(ReturnExePath() & "\Report") Then
            Directory.CreateDirectory(ReturnExePath() & "\Report")
        End If
        Directory.CreateDirectory(ReturnExePath() & "\Report" & "\National")
        objApp = New Excel.Application()
        objBooks = objApp.Workbooks
        objBook = objBooks.Add
        objSheets = objBook.Worksheets
        CreatePerChannelofNational(objBooks, objSheets, objSheet, range)
        CreateNationalMedrepDistrictTerritory(objBooks, objSheets, objSheet, range)
        CreateNationalPerMonthAndyear(objBooks, objSheets, objSheet, range)
        objSheets.Select(1)
        If File.Exists(ReturnExePath() & "Report" & "\National\" & "In Market Sales  Analysis Report (" & cboYear2.Text & "-" & cboMonth2.Text & ")-(" & cboYear2.Text & "-" & cboMonth3.Text & ").xls") Then
            Kill(ReturnExePath() & "Report" & "\National\" & "In Market Sales  Analysis Report (" & cboYear2.Text & "-" & cboMonth2.Text & ")-(" & cboYear2.Text & "-" & cboMonth3.Text & ").xls")
        End If
        objApp.ActiveWorkbook.SaveAs(ReturnExePath() & "Report" & "\National" & "\In Market Sales  Analysis Report (" & cboYear2.Text & "-" & cboMonth2.Text & ")-(" & cboYear2.Text & "-" & cboMonth3.Text & ")", Excel.XlFileFormat.xlExcel8)
        objApp.Quit()
        range = Nothing
        objSheet = Nothing
        objSheets = Nothing
        objBooks = Nothing
        MsgBox("File Successfully Downloaded!", MsgBoxStyle.Information, "")
    End Sub

    Private Sub CreateNationalMedrepWise(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range)
        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(1))
        objSheet.Name = "National - MedRep Wise"

        MergeCell(objSheet, range, "A2", "G2", GetDefaultCompanyName, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A3", "G3", "National - MedRep Wise  for  the month of :  (" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear3.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        '  MergeCell(objSheet, range, "A5", "G5", "Area Manager: " & AMCode & " - " & AMName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)

        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0

        Connect()
        Dim cmd As New SqlCommand("uspTPINationalMedrepWise", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
        cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
        cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
        cmd.Parameters.AddWithValue("@Year2", cboYear3.Text)
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        If dt.Rows.Count > 0 Then
            CreateHeaderForAMMedRepWise(objSheet, range, y + yheader)
            For l As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(l)
                objSheet.Cells(8 + Counter + l, 1) = "'" & dr("DISTRCTCD")
                objSheet.Cells(8 + Counter + l, 2) = "'" & (dr("TerrCd"))
                objSheet.Cells(8 + Counter + l, 3) = (dr("DETCD"))
                objSheet.Cells(8 + Counter + l, 4) = dr("SSE")
                objSheet.Cells(8 + Counter + l, 5) = dr("Net")
                objSheet.Cells(8 + Counter + l, 6) = dr("Target")
                objSheet.Cells(8 + Counter + l, 7) = dr("Percentage")
            Next
        End If

        range = objSheet.Range("A" & Convert.ToString(y + Counter), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        'range.Font.Name = "Segoe UI"
        'range.Font.Size = 8

        range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

        range = objSheet.Range("A" & Convert.ToString(y + Counter), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count - 1)
        range.Cells.NumberFormat = "#,##0.00"


        objSheet.Range("A1:AZ400").EntireColumn.AutoFit()
    End Sub
    Private Sub CreateNationalPerChannelCode(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range)
        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(2))
        objSheet.Name = "National - PerChannel"

        MergeCell(objSheet, range, "A2", "G2", GetDefaultCompanyName, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A3", "G3", "National - Per Channel Customer of the month of :(" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear3.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)

        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0


        Connect()
        Dim cmd As New SqlCommand("usprPerCompanyofMonth", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
        cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        If dt.Rows.Count > 0 Then
            CreateHeaderForNationalPerChannel(objSheet, range, y + yheader)
            For l As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(l)
                If l = 0 Then
                    objSheet.Cells(8 + Counter + l, 1) = dr(("Company Code"))
                End If
                objSheet.Cells(8 + Counter + l, 2) = dr("Customer Code")
                objSheet.Cells(8 + Counter + l, 3) = dr("CustomerName")
                objSheet.Cells(8 + Counter + l, 4) = dr("Item Code")
                objSheet.Cells(8 + Counter + l, 5) = dr("Item Name")
                objSheet.Cells(8 + Counter + l, 6) = dr("Return Quantity")
                objSheet.Cells(8 + Counter + l, 7) = dr("Return Value")
                objSheet.Cells(8 + Counter + l, 8) = dr("Net Quantity")
                objSheet.Cells(8 + Counter + l, 9) = dr("Net Value")
            Next
        End If

        range = objSheet.Range("A" & Convert.ToString(y + Counter), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        'range.Font.Name = "Segoe UI"
        'range.Font.Size = 8

        range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

        range = objSheet.Range("A" & Convert.ToString(y + Counter), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count - 1)
        range.Cells.NumberFormat = "#,##0.00"


        objSheet.Range("A1:AZ400").EntireColumn.AutoFit()

    End Sub
    Private Sub CreateNationalPerMonthAndyear(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range)
        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(3))
        objSheet.Name = "National - InMarketSalesReport"

        MergeCell(objSheet, range, "A2", "G2", txtconfigtypeName.Text, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A3", "G3", "National - In-Market Sales Report :  (" & cboMonth2.Text & " - " & cboYear2.Text & ")(" & cboMonth3.Text & " - " & cboYear2.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        '  MergeCell(objSheet, range, "A5", "G5", "Area Manager: " & AMCode & " - " & AMName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)

        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0
        Dim ctr As Integer = 0



        Connect()
        Dim cmd As New SqlCommand("uspSalesAnalysisReport_national", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
        cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
        cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
        cmd.Parameters.AddWithValue("@ConfigTypeCode", cmbConfigtypeCode.Text)
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        If dt.Rows.Count > 0 Then
            CreateHeaderForNationalallDistrict(objSheet, range, y + yheader)
            For l As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Visible = True
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(l)
                objSheet.Cells(8 + Counter + l, 1) = dr("Itemteamgroup")
                objSheet.Cells(8 + Counter + l, 2) = (dr("PRODUCT"))
                objSheet.Cells(8 + Counter + l, 3) = dr("MDC")
                objSheet.Cells(8 + Counter + l, 4) = dr("ZPC")
                objSheet.Cells(8 + Counter + l, 5) = dr("INH")
                objSheet.Cells(8 + Counter + l, 6) = dr("TOTAL")
                objSheet.Cells(8 + Counter + l, 7) = dr("FC")
                objSheet.Cells(8 + Counter + l, 8) = dr("PERF %") * 100 & Format("%")
                objSheet.Cells(8 + Counter + l, 9) = dr("MDC1")
                objSheet.Cells(8 + Counter + l, 10) = dr("GROWTH %") * 100 & Format("%")
                objSheet.Cells(8 + Counter + l, 11) = dr("ZPC1")
                objSheet.Cells(8 + Counter + l, 12) = dr("GROWTH %1") * 100 & Format("%")
                objSheet.Cells(8 + Counter + l, 13) = dr("INH1")
                objSheet.Cells(8 + Counter + l, 14) = dr("GROWTH %2") * 100 & Format("%")
                objSheet.Cells(8 + Counter + l, 15) = dr("TOTAL1")
                objSheet.Cells(8 + Counter + l, 16) = dr("GROWHTLA")
                objSheet.Cells(8 + Counter + l, 17) = dr("FC1")
                objSheet.Cells(8 + Counter + l, 18) = dr("PREF%") & Format("%")
                ctr += 1
            Next
        End If

        range = objSheet.Range("A" & Convert.ToString(y + Counter), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        range.Font.Name = "Segoe UI"
        range.Font.Size = 8

        range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

        range = objSheet.Range("A" & Convert.ToString(y + Counter), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count - 1)
        range.Cells.NumberFormat = "#,##0.00"


        objSheet.Range("A1:AZ400").EntireColumn.AutoFit()
        ProgressBar1.Visible = False

    End Sub
    Private Sub CreateNationalMedrepDistrictTerritory(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range)
        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(2))
        objSheet.Name = "National-SalesDistrictTerritory"

        MergeCell(objSheet, range, "A2", "F2", txtconfigtypeName.Text, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A3", "F3", "National - Sales District Per Territory  :(" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear2.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        '  MergeCell(objSheet, range, "A5", "G5", "Area Manager: " & AMCode & " - " & AMName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)

        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0
        Dim ctr As Integer = 0
        Connect()
        Dim cmd As New SqlCommand("uspNationalDistrictPerMsrName", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
        cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
        cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
        cmd.Parameters.AddWithValue("@ConfigTypeCode", cmbConfigtypeCode.Text)
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        If dt.Rows.Count > 0 Then
            CreateHeaderForNationalDistrictTerritory(objSheet, range, y + yheader)
            For l As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Visible = True
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(l)
                objSheet.Cells(8 + Counter + l, 1) = "'" & dr("District Code")
                objSheet.Cells(8 + Counter + l, 2) = "'" & (dr("Territory Code"))
                objSheet.Cells(8 + Counter + l, 3) = (dr("Territory Name"))
                objSheet.Cells(8 + Counter + l, 4) = dr("NetValue")
                objSheet.Cells(8 + Counter + l, 5) = dr("TargetValue")
                objSheet.Cells(8 + Counter + l, 6) = "'" & dr(("Growth"))
                objSheet.Cells(8 + Counter + l, 7) = "'" & dr(("Percentage"))
                ctr += 1
            Next
        End If

        range = objSheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        range.Font.Name = "Segoe UI"
        range.Font.Size = 8

        range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

        range = objSheet.Range("D" & Convert.ToString(y + yheader), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count-1)
        range.Cells.NumberFormat = "#,##0.00"

        range = objSheet.Range("E" & Convert.ToString(y + yheader), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count - 1)
        range.Cells.NumberFormat = "#,##0.00"
        Counter += dt.Rows.Count + 3
        yheader += dt.Rows.Count + 3


        objSheet.Range("A1:AZ400").EntireColumn.AutoFit()

        ProgressBar1.Visible = False
    End Sub

    Private Sub CreateHeaderForNationalMedRepWise(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)

        objSheet.Cells(y, 1) = "District"
        objSheet.Cells(y, 2) = "Territory"
        objSheet.Cells(y, 3) = "Med Rep Code"
        objSheet.Cells(y, 4) = "Med Rep Name"
        objSheet.Cells(y, 5) = "Net Sales"
        objSheet.Cells(y, 6) = "Target Sales"
        objSheet.Cells(y, 7) = "Percentage"

        range = objSheet.Range("A" & Convert.ToString(y) & ":G" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter

    End Sub
    Private Sub CreateHeaderForNationalPerChannel(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)

        objSheet.Cells(y, 1) = "Company Code"
        objSheet.Cells(y, 2) = "Customer Code"
        objSheet.Cells(y, 3) = "Customer Name"
        objSheet.Cells(y, 4) = "Item Code"
        objSheet.Cells(y, 5) = "Item Name"
        objSheet.Cells(y, 6) = "Retrun Quantity"
        objSheet.Cells(y, 7) = "Return Value"
        objSheet.Cells(y, 8) = "Net Quantity"
        objSheet.Cells(y, 9) = "Net Value"

        range = objSheet.Range("A" & Convert.ToString(y) & ":G" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter

    End Sub
    Private Sub CreateHeaderForNationalDistrictTerritory(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)

        objSheet.Cells(y, 1) = "District Code"
        objSheet.Cells(y, 2) = "Territory Code"
        objSheet.Cells(y, 3) = "Med Rep Name"
        objSheet.Cells(y, 4) = "Net Sales"
        objSheet.Cells(y, 5) = "Target Sales"
        objSheet.Cells(y, 6) = "Growth %"
        objSheet.Cells(y, 7) = "Perf %"

        range = objSheet.Range("A" & Convert.ToString(y) & ":G" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter

    End Sub


    Private Sub CreateNationalConsolidatedSalesPerCompany(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range)
        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(2))
        objSheet.Name = "Monthly Report Per Channel"

        MergeCell(objSheet, range, "A2", "K2", GetDefaultCompanyName, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A3", "K3", "National - Monthly Report Per Channel for the month of :  (" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear3.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        'MergeCell(objSheet, range, "A5", "K5", "Area Manager : " & AMCode & " - " & AMName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)

        Dim Counter As Integer = 0
        Dim y As Integer = 8
        Dim yheader As Integer = 0
        Dim cmd As New SqlCommand("uspNationalPerCompanySales", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        'cmd.Parameters.AddWithValue("@Month", cboMonth.Text)  -ORIG
        'cmd.Parameters.AddWithValue("@Year", cboYear.Text)     -ORIG
        cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)  ' ADDED
        cmd.Parameters.AddWithValue("@Year", cboYear2.Text)      'ADDED
        cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)  ' ADDED
        cmd.Parameters.AddWithValue("@Year2", cboYear3.Text)      'ADDED
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        If dt.Rows.Count > 0 Then
            CreateHeaderForNationalSalesPerCompany(objSheet, range, y + yheader)
            For l As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(l)
                objSheet.Cells(9 + Counter + l, 1) = (dr("COMID"))
                objSheet.Cells(9 + Counter + l, 2) = ("'" & dr("CUST"))
                objSheet.Cells(9 + Counter + l, 3) = dr("CNAME")
                objSheet.Cells(9 + Counter + l, 4) = "'" & dr("PROD")
                objSheet.Cells(9 + Counter + l, 5) = dr("PDES")
                objSheet.Cells(9 + Counter + l, 6) = dr("GrossQty")
                objSheet.Cells(9 + Counter + l, 7) = dr("GrossValue")
                objSheet.Cells(9 + Counter + l, 8) = dr("ReturnQty")
                objSheet.Cells(9 + Counter + l, 9) = dr("ReturnValue")
                objSheet.Cells(9 + Counter + l, 10) = dr("NetQty")
                objSheet.Cells(9 + Counter + l, 11) = dr("NetValue")
            Next
        End If

        range = objSheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        'range.Font.Name = "Segoe UI"
        'range.Font.Size = 8

        range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

        range = objSheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        range.Cells.NumberFormat = "#,##0.00"
        Counter += dt.Rows.Count + 3
        yheader += dt.Rows.Count + 3

        objSheet.Range("A1:AZ400").EntireColumn.AutoFit()
    End Sub

    Private Sub CreateHeaderForNationalSalesPerCompany(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)
        objSheet.Cells(y, 1) = "Channel"
        objSheet.Cells(y, 2) = "Customer Code"
        objSheet.Cells(y, 3) = "Customer Name"
        objSheet.Cells(y, 4) = "Item Code"
        objSheet.Cells(y, 5) = "Item Name"
        objSheet.Cells(y, 6) = "Gross Quantity"
        objSheet.Cells(y, 7) = "Gross Value"
        objSheet.Cells(y, 8) = "Return Quantity"
        objSheet.Cells(y, 9) = "Return Value"
        objSheet.Cells(y, 10) = "Net Quantity"
        objSheet.Cells(y, 11) = "Net Value"
        range = objSheet.Range("A" & Convert.ToString(y) & ":K" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter
    End Sub

    Private Sub CreateNationalConsolidatedSalesPerDistrict(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range)
        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(3))
        objSheet.Name = "Monthly Report Per District"

        MergeCell(objSheet, range, "A2", "K2", GetDefaultCompanyName, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A3", "K3", "National - Monthly Report Per District for the month of :  (" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear3.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        'MergeCell(objSheet, range, "A5", "K5", "Area Manager : " & AMCode & " - " & AMName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)

        Dim Counter As Integer = 0
        Dim y As Integer = 8
        Dim yheader As Integer = 0
        Dim cmd As New SqlCommand("uspNationalDistrictProductWise", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        'cmd.Parameters.AddWithValue("@Month", cboMonth.Text)
        'cmd.Parameters.AddWithValue("@Year", cboYear.Text)
        cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
        cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
        cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
        cmd.Parameters.AddWithValue("@Year2", cboYear3.Text)
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        If dt.Rows.Count > 0 Then
            CreateHeaderForNationalSalesPerDistrict(objSheet, range, y + yheader)
            For l As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(l)
                objSheet.Cells(9 + Counter + l, 1) = "'" & (dr("DISTRCTCD"))
                objSheet.Cells(9 + Counter + l, 2) = ("'" & dr("CUST"))
                objSheet.Cells(9 + Counter + l, 3) = dr("CNAME")
                objSheet.Cells(9 + Counter + l, 4) = "'" & dr("PROD")
                objSheet.Cells(9 + Counter + l, 5) = dr("PDES")
                objSheet.Cells(9 + Counter + l, 6) = dr("GrossQty")
                objSheet.Cells(9 + Counter + l, 7) = dr("GrossValue")
                objSheet.Cells(9 + Counter + l, 8) = dr("ReturnQty")
                objSheet.Cells(9 + Counter + l, 9) = dr("ReturnValue")
                objSheet.Cells(9 + Counter + l, 10) = dr("NetQty")
                objSheet.Cells(9 + Counter + l, 11) = dr("NetValue")
            Next
        End If

        range = objSheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        'range.Font.Name = "Segoe UI"
        'range.Font.Size = 8

        range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

        range = objSheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        range.Cells.NumberFormat = "#,##0.00"
        Counter += dt.Rows.Count + 3
        yheader += dt.Rows.Count + 3

        objSheet.Range("A1:AZ400").EntireColumn.AutoFit()
    End Sub

    Private Sub CreateHeaderForNationalSalesPerDistrict(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)
        objSheet.Cells(y, 1) = "District"
        objSheet.Cells(y, 2) = "Customer Code"
        objSheet.Cells(y, 3) = "Customer Name"
        objSheet.Cells(y, 4) = "Item Code"
        objSheet.Cells(y, 5) = "Item Name"
        objSheet.Cells(y, 6) = "Gross Quantity"
        objSheet.Cells(y, 7) = "Gross Value"
        objSheet.Cells(y, 8) = "Return Quantity"
        objSheet.Cells(y, 9) = "Return Value"
        objSheet.Cells(y, 10) = "Net Quantity"
        objSheet.Cells(y, 11) = "Net Value"
        range = objSheet.Range("A" & Convert.ToString(y) & ":K" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter
    End Sub


    Private Sub CreateNationalConsolidatedSalesPerDistrictMedRepWise(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range)
        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(4))
        objSheet.Name = "Monthly Rpt Per AM - MR"

        MergeCell(objSheet, range, "A2", "K2", GetDefaultCompanyName, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objSheet, range, "A3", "K3", "National - Monthly Report Per District - MedRep for the month of :  (" & cboMonth2.Text & " - " & cboYear2.Text & ")-(" & cboMonth3.Text & " - " & cboYear3.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        'MergeCell(objSheet, range, "A5", "K5", "Area Manager : " & AMCode & " - " & AMName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)

        Dim Counter As Integer = 0
        Dim y As Integer = 8
        Dim yheader As Integer = 0
        Dim cmd As New SqlCommand("uspNationalDistrictMedrepWise", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        'cmd.Parameters.AddWithValue("@Month", cboMonth.Text)
        'cmd.Parameters.AddWithValue("@Year", cboYear.Text)
        cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
        cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
        cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
        cmd.Parameters.AddWithValue("@Year2", cboYear3.Text)
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        If dt.Rows.Count > 0 Then
            CreateHeaderForNationalSalesPerDistrictMedRepWIse(objSheet, range, y + yheader)
            For l As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(l)
                objSheet.Cells(9 + Counter + l, 1) = dr("COMID")
                objSheet.Cells(9 + Counter + l, 2) = "'" & dr("DistrctCD")
                objSheet.Cells(9 + Counter + l, 3) = "'" & dr("TERRCD")
                objSheet.Cells(9 + Counter + l, 4) = "'" & dr("DETCD")
                objSheet.Cells(9 + Counter + l, 5) = dr("SSE")
                objSheet.Cells(9 + Counter + l, 6) = dr("GrossQty")
                objSheet.Cells(9 + Counter + l, 7) = dr("GrossValue")
                objSheet.Cells(9 + Counter + l, 8) = dr("ReturnQty")
                objSheet.Cells(9 + Counter + l, 9) = dr("ReturnValue")
                objSheet.Cells(9 + Counter + l, 10) = dr("NetQty")
                objSheet.Cells(9 + Counter + l, 11) = dr("NetValue")
            Next
        End If

        range = objSheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        'range.Font.Name = "Segoe UI"
        'range.Font.Size = 8

        range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

        range = objSheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        range.Cells.NumberFormat = "#,##0.00"
        Counter += dt.Rows.Count + 3
        yheader += dt.Rows.Count + 3

        objSheet.Range("A1:AZ400").EntireColumn.AutoFit()
    End Sub

    Private Sub CreateHeaderForNationalSalesPerDistrictMedRepWIse(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)
        objSheet.Cells(y, 1) = "Channel"
        objSheet.Cells(y, 2) = "District"
        objSheet.Cells(y, 3) = "Territory"
        objSheet.Cells(y, 4) = "Med Rep Code"
        objSheet.Cells(y, 5) = "Med Rep Name"
        objSheet.Cells(y, 6) = "Gross Quantity"
        objSheet.Cells(y, 7) = "Gross Value"
        objSheet.Cells(y, 8) = "Return Quantity"
        objSheet.Cells(y, 9) = "Return Value"
        objSheet.Cells(y, 10) = "Net Quantity"
        objSheet.Cells(y, 11) = "Net Value"
        range = objSheet.Range("A" & Convert.ToString(y) & ":J" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter
    End Sub

    Private Sub chkNationalReport_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNationalReport.CheckedChanged
        If chkNationalReport.Checked Then
            chkMedicalRep.Checked = False
            chkForAM.Checked = False

            'Me.Height = 282
            'Panel5.Enabled = False
            cboYear3.Visible = False
            Label8.Visible = False
        End If
    End Sub

    Private Sub chkForAM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkForAM.CheckedChanged
        If chkForAM.Checked Then
            chkNationalReport.Checked = False
            chkMedicalRep.Checked = False
            cboMonth2.Enabled = False
            cboYear2.Enabled = True
            cboMonth2.Enabled = True
            cboMonth3.Enabled = True
            cboYear3.Visible = False
            Label8.Visible = False
            'Me.Height = 282
            'Panel5.Enabled = False
        End If
    End Sub

    Private Sub chkMedicalRep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMedicalRep.CheckedChanged
        If chkMedicalRep.Checked Then
            chkForAM.Checked = False
            chkNationalReport.Checked = False

            cboYear2.Enabled = True
            cboMonth2.Enabled = True
            cboMonth3.Enabled = True
            cboYear3.Visible = False
            Label8.Visible = False

            'Me.Height = 282
            'Panel5.Enabled = False
            LoadMedicalRep()
        End If
    End Sub

    Private Sub optItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optItem.CheckedChanged
        Me.Height = 356
        Panel5.Enabled = True
    End Sub

    Private Sub cboYear2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYear2.SelectedIndexChanged
        If cboYear2.SelectedIndex = -1 Then Exit Sub
        LoadMonths(cboYear2.Text, cboMonth2)
        '  LoadMonths(cboYear3.Text, cboMonth3)
    End Sub

    Private Sub cboYear3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYear3.SelectedIndexChanged
        If cboYear3.SelectedIndex = -1 Then Exit Sub
        LoadMonths(cboYear3.Text, cboMonth3)
    End Sub

    Private Sub PrintItemReport()
        Dim objBooks As Excel.Workbooks
        Dim objSheets As Excel.Sheets
        Dim objSheet As Excel._Worksheet
        Dim range As Excel.Range

        ' Create a new instance of Excel and start a new workbook.

        If Not File.Exists(ReturnExePath() & "\Report\Item Reports") Then
            Directory.CreateDirectory(ReturnExePath() & "\Report\Item Reports")
        End If
        '   Directory.CreateDirectory(ReturnExePath() & "\Report\Item Reports\" & cboYear2.Text)
        m_RsItems = LoadItems()

        objApp = New Excel.Application()
        objBooks = objApp.Workbooks
        objBook = objBooks.Add
        objSheets = objBook.Worksheets
        Dim ctr As Integer = 1
        For m As Integer = 0 To m_RsItems.RecordCount - 1

            'Directory.CreateDirectory(ReturnExePath() & "Report\AM Reports\" & cboYear.Text & "\" & cboMonth.Text & "\" & m_RsSalesManager.Fields("STSLSMGRCD").Value & " - " & m_RsSalesManager.Fields("STSLSMGRNAME").Value)

            If CreateItemReports(objBooks, objSheets, objSheet, range, ctr, m_RsItems.Fields("ITEMCD").Value, m_RsItems.Fields("IMDBRN").Value) Then ctr += 1

            m_RsItems.MoveNext()
        Next

        objSheets.Select(1)
        If File.Exists(ReturnExePath() & "Report\Item Reports\Monthly Sales Performance Productwise.xls") Then
            Kill(ReturnExePath() & "Report\Item Reports\Monthly Sales Performance Productwise.xls")
        End If

        'objApp.ActiveWorkbook.SaveAs(ReturnExePath() & "Report\Item Reports\Monthly Sales Performance Productwise.xls")
        objApp.ActiveWorkbook.SaveAs(ReturnExePath() & "Report\Item Reports\Monthly Sales Performance Productwise", Excel.XlFileFormat.xlExcel8)

        objApp.Quit()

        'Return control of Excel to the user.
        'objApp.Visible = True
        'objApp.UserControl = True

        'Clean up a little.
        range = Nothing
        objSheet = Nothing
        objSheets = Nothing
        objBooks = Nothing
        MessageBox.Show("File Successfully Downloaded!")
    End Sub

    Private Function LoadItems() As ADODB.Recordset
        Dim rs As New ADODB.Recordset

        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT ITEMCD, IMDBRN FROM ITEM WHERE  ITEMDEL = 0 Order BY ItemCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)

        Return rs
    End Function
    Private Function loadterritoryCode() As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        'rs.Open("select distinct [Msr Code],[Msr Name] from sc02 where [Msr Code] not in('ZPC','WAT','WAT-999','SSD','999','MDC','PM') and ConfigTypeCode = '" & cmbConfigtypeCode.Text & "'   order by [Msr Code]", SPMSConn, 3, 3)
        rs.Open("Select Distinct stterrcd as [MSR Code], stslsmnname as [MSR Name] from salesmatrix Where stterrcd Not In('ZPC','WAT','WAT-999','SSD','999','MDC','PM') and ConfigTypeCode = '" & cmbConfigtypeCode.Text & "' And Month(EffectivityEndDate) = '" & cboMonth3.Text & "' And Year(EffectivityEndDate) = '" & cboYear2.Text & "'   order by stterrcd", SPMSConn, 3, 3)
        Return rs
    End Function


    Private Function CreateItemReports(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal index As Integer, ByVal ItemCode As String, ByVal ItemName As String) As Boolean

        Connect()

        Dim cmd As New SqlCommand("uspPerformanceMonthWise_MedrepProductWise", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@FromCutMo", cboMonth2.Text)
        cmd.Parameters.AddWithValue("@FromCutYear", cboYear2.Text)
        cmd.Parameters.AddWithValue("@ToCutMo", cboMonth3.Text)
        cmd.Parameters.AddWithValue("@ToCutYear", cboYear3.Text)
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)

        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()

        If dt.Columns.Count <= 1 Then
            Return False
        End If
        If dt.Rows.Count = 0 Then
            Return False
        End If

        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(index))
        If ItemName.IndexOf(" ") < 1 Then
            objSheet.Name = ItemCode & "-" & ItemName.Substring(0, ItemName.Length)
        Else
            objSheet.Name = ItemCode & "-" & ItemName.Substring(0, ItemName.IndexOf(" "))
        End If

        objSheet.Cells(2, 1) = txtconfigtypeName.Text
        range = objSheet.Range("A2", "A2")

        range.WrapText = False
        range.ShrinkToFit = False
        range.Font.Size = 15
        range.Font.Bold = True

        objSheet.Cells(4, 1) = "Monthly Sales Performance Productwise"
        range = objSheet.Range("A4", "A4")

        range.WrapText = False
        range.ShrinkToFit = False
        range.Font.Size = 13
        range.Font.Bold = True

        objSheet.Cells(5, 1) = "Item :  " & ItemCode & " - " & ItemName
        range = objSheet.Range("A5", "A5")

        range.WrapText = False
        range.ShrinkToFit = False
        range.Font.Size = 11
        range.Font.Bold = True
        'MergeCell(objSheet, range, "A2", "k2", GetDefaultCompanyName, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        'MergeCell(objSheet, range, "A3", "G3", "Monthly Sales Performance Productwise", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        'MergeCell(objSheet, range, "A5", "k5", "Item : " & ItemCode & " - " & ItemName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)

        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0




        For l As Integer = 0 To dt.Rows.Count - 1
            Dim dr As DataRow = dt.Rows(l)

            For m As Integer = 0 To dt.Columns.Count - 1
                objSheet.Cells(8 + l, m + 1) = dr(dt.Columns(m).Caption)
            Next

            'objSheet.Cells(8 + Counter + l, 1) = "'" & dr("DISTRCTCD")
            'objSheet.Cells(8 + Counter + l, 2) = "'" & (dr("TerrCd"))
            'objSheet.Cells(8 + Counter + l, 3) = (dr("DETCD"))
            'objSheet.Cells(8 + Counter + l, 4) = dr("SSE")
            'objSheet.Cells(8 + Counter + l, 5) = dr("Net")
            'objSheet.Cells(8 + Counter + l, 6) = dr("Target")
            'objSheet.Cells(8 + Counter + l, 7) = dr("Percentage")
        Next

        range = objSheet.Range("A" & Convert.ToString(y + Counter), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        'range.Font.Name = "Segoe UI"
        'range.Font.Size = 8

        range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

        range = objSheet.Range("E" & Convert.ToString(y + Counter), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count - 1)
        range.Cells.NumberFormat = "#,##0.00"


        objSheet.Range("B1:AZ400").EntireColumn.AutoFit()

        Return True

    End Function

    Private Function CreateTerritryPerMonth(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal index As Integer, ByVal TRCODE As String, ByVal TRNAME As String) As Boolean

        Connect()

        Dim cmd As New SqlCommand("usprptTerritory", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
        cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
        cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
        cmd.Parameters.AddWithValue("@TC", TRCODE)
        cmd.Parameters.AddWithValue("@ConfigTypeCode", cmbConfigtypeCode.Text)

        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()

        If dt.Columns.Count <= 1 Then
            Return False
        End If
        If dt.Rows.Count = 0 Then
            Return False
        End If

        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(index))
        If TRNAME.IndexOf(" ") < 1 Then
            objSheet.Name = TRCODE & "-" & TRNAME.Substring(0, TRNAME.Length)
        Else
            objSheet.Name = TRCODE & "-" & TRNAME.Substring(0, TRNAME.IndexOf(" "))
        End If

        objSheet.Cells(2, 1) = txtconfigtypeName.Text
        range = objSheet.Range("A2", "A2")

        range.WrapText = False
        range.ShrinkToFit = False
        range.Font.Size = 15
        range.Font.Bold = True

        objSheet.Cells(4, 1) = "Customer listing Per Territory"
        range = objSheet.Range("A4", "A4")

        range.WrapText = False
        range.ShrinkToFit = False
        range.Font.Size = 13
        range.Font.Bold = True

        objSheet.Cells(5, 1) = "Territory :  " & TRCODE & " - " & TRNAME
        range = objSheet.Range("A5", "A5")

        range.WrapText = False
        range.ShrinkToFit = False
        range.Font.Size = 11
        range.Font.Bold = True
        'MergeCell(objSheet, range, "A2", "k2", GetDefaultCompanyName, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        'MergeCell(objSheet, range, "A3", "G3", "Monthly Sales Performance Productwise", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        'MergeCell(objSheet, range, "A5", "k5", "Item : " & ItemCode & " - " & ItemName, 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)

        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0
        Dim ctr As Integer = 0



        CreateHeaderForTerritoryReport(objSheet, range, y + yheader)
        For l As Integer = 0 To dt.Rows.Count - 1
            ProgressBar1.Visible = True
            ProgressBar1.Value = ctr / dt.Rows.Count * 100
            Dim dr As DataRow = dt.Rows(l)
            objSheet.Cells(8 + Counter + l, 1) = dr("District Name")
            objSheet.Cells(8 + Counter + l, 2) = dr("Company Code")
            objSheet.Cells(8 + Counter + l, 3) = "'" & dr("Customer Code")
            objSheet.Cells(8 + Counter + l, 4) = dr("CustomerName")
            objSheet.Cells(8 + Counter + l, 5) = "'" & dr("Shipto Code")
            objSheet.Cells(8 + Counter + l, 6) = dr("Ship to Address1")
            objSheet.Cells(8 + Counter + l, 7) = dr("Shipto Address2")
            ctr += 1
        Next
        range = objSheet.Range("A" & Convert.ToString(y + Counter), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        range.Font.Name = "Segoe UI"
        range.Font.Size = 8

        range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

        range = objSheet.Range("A" & Convert.ToString(y + Counter), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        range.Cells.NumberFormat = "#,##0.00"


        objSheet.Range("B1:AZ400").EntireColumn.AutoFit()
        ProgressBar1.Visible = False

        Return True

    End Function
    Private Function CreateDistrictConsolidatedReport(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal index As Integer, ByVal AMCode As String, ByVal AMName As String) As Boolean

        On Error Resume Next
        m_RsDistrict.MoveFirst()

        For m As Integer = 0 To m_RsDistrict.RecordCount - 1

            Connect()
            Dim cmd As New SqlCommand("uspSalesAnalysisReport_District", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
            cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
            cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
            cmd.Parameters.AddWithValue("@DisctrictCode", m_RsDistrict.Fields("District Code").Value)
            cmd.Parameters.AddWithValue("@ConfigTypeCode", cmbConfigtypeCode.Text)
            Dim da As New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            Disconnect()

            If dt.Columns.Count <= 1 Then
                Return False
            End If
            If dt.Rows.Count = 0 Then
                Return False
            End If

            objSheet = objSheets.Add

            objSheet.Move(After:=objSheets(index))
            If AMName.IndexOf(" ") < 2 Then
                objSheet.Name = AMCode & "-" & AMName.Substring(0, AMName.Length)
            Else
                objSheet.Name = AMCode & "-" & AMName.Substring(0, AMName.IndexOf(" "))
            End If

            objSheet.Cells(2, 1) = txtconfigtypeName.Text
            range = objSheet.Range("A2", "A2")

            range.WrapText = False
            range.ShrinkToFit = False
            range.Font.Size = 15
            range.Font.Bold = True

            objSheet.Cells(4, 1) = "In-market Sales Analysis Report - District"
            range = objSheet.Range("A4", "A4")

            range.WrapText = False
            range.ShrinkToFit = False
            range.Font.Size = 13
            range.Font.Bold = True

            objSheet.Cells(5, 1) = "DistrictCode:  " & AMCode & " - " & AMName
            range = objSheet.Range("A5", "A5")

            range.WrapText = False
            range.ShrinkToFit = False
            range.Font.Size = 11
            range.Font.Bold = True

            Dim Counter As Integer = 0
            Dim y As Integer = 7
            Dim yheader As Integer = 0
            Dim ctr As Integer = 0



            CreateHeaderForConsolidatedbyDistrict(objSheet, range, y + yheader)
            For l As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Visible = True
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(l)
                objSheet.Cells(8 + Counter + l, 1) = (dr("ITEMTEAMGROUP"))
                objSheet.Cells(8 + Counter + l, 2) = (dr("PRODUCT"))
                objSheet.Cells(8 + Counter + l, 3) = dr("MDC")
                objSheet.Cells(8 + Counter + l, 4) = dr("ZPC")
                objSheet.Cells(8 + Counter + l, 5) = dr("INH")
                objSheet.Cells(8 + Counter + l, 6) = dr("TOTAL")
                objSheet.Cells(8 + Counter + l, 7) = dr("FC")
                objSheet.Cells(8 + Counter + l, 8) = dr("PERF %") * 100 & Format("%")
                objSheet.Cells(8 + Counter + l, 9) = dr("MDC1")
                objSheet.Cells(8 + Counter + l, 10) = dr("GROWTH %") * 100 & Format("%")
                objSheet.Cells(8 + Counter + l, 11) = dr("ZPC1")
                objSheet.Cells(8 + Counter + l, 12) = dr("GROWTH %1") * 100 & Format("%")
                objSheet.Cells(8 + Counter + l, 13) = dr("INH1")
                objSheet.Cells(8 + Counter + l, 14) = dr("GROWTH %2") * 100 & Format("%")
                objSheet.Cells(8 + Counter + l, 15) = dr("TOTAL1")
                objSheet.Cells(8 + Counter + l, 16) = dr("GrowhtLA")
                objSheet.Cells(8 + Counter + l, 17) = dr("FC1")
                objSheet.Cells(8 + Counter + l, 18) = dr("PREF%") * 100 & Format("%")
                ctr += 1
            Next
            range = objSheet.Range("A" & Convert.ToString(y + Counter), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)

            range.Font.Name = "Segoe UI"
            range.Font.Size = 8
            range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous
            range = objSheet.Range("A" & Convert.ToString(y + Counter), Reflection.Missing.Value)
            range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
            range.Cells.NumberFormat = "#,##0.00"
            objSheet.Range("B1:AZ400").EntireColumn.AutoFit()

            m_RsDistrict.MoveNext()
        Next

        ProgressBar1.Visible = False

        Return True

    End Function
    Private Function CreateTerritryPerMonthSalesAnlysisReport(ByVal objBooks As Excel.Workbooks, ByVal objSheets As Excel.Sheets, ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal index As Integer, ByVal TRCODE As String, ByVal TRNAME As String) As Boolean

        Connect()

        Dim cmd As New SqlCommand("uspSalesAnalysisReport_Territory", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@Month", cboMonth2.Text)
        cmd.Parameters.AddWithValue("@Year", cboYear2.Text)
        cmd.Parameters.AddWithValue("@Month2", cboMonth3.Text)
        cmd.Parameters.AddWithValue("@TerritoryCode", TRCODE)
        cmd.Parameters.AddWithValue("@ConfigtypeCode", cmbConfigtypeCode.Text)
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()

        If dt.Columns.Count <= 1 Then
            Return False
        End If
        If dt.Rows.Count = 0 Then
            Return False
        End If

        objSheet = objSheets.Add

        objSheet.Move(After:=objSheets(index))
        If TRNAME.IndexOf(" ") < 1 Then
            objSheet.Name = TRCODE & "-" & TRNAME.Substring(0, TRNAME.Length)
        Else
            objSheet.Name = TRCODE & "-" & TRNAME.Substring(0, TRNAME.IndexOf(" "))
        End If

        objSheet.Cells(2, 1) = txtconfigtypeName.Text
        range = objSheet.Range("A2", "A2")

        range.WrapText = False
        range.ShrinkToFit = False
        range.Font.Size = 15
        range.Font.Bold = True

        objSheet.Cells(4, 1) = "In-market Sales Analysis Report - Territory"
        range = objSheet.Range("A4", "A4")

        range.WrapText = False
        range.ShrinkToFit = False
        range.Font.Size = 13
        range.Font.Bold = True

        objSheet.Cells(5, 1) = "Territory :  " & TRCODE & " - " & TRNAME
        range = objSheet.Range("A5", "A5")

        range.WrapText = False
        range.ShrinkToFit = False
        range.Font.Size = 11
        range.Font.Bold = True

        Dim Counter As Integer = 0
        Dim y As Integer = 7
        Dim yheader As Integer = 0
        Dim ctr As Integer = 0



        CreateHeaderForTerritoryReportAnalysisReport(objSheet, range, y + yheader)
        For l As Integer = 0 To dt.Rows.Count - 1
            ProgressBar1.Visible = True
            ProgressBar1.Value = ctr / dt.Rows.Count * 100
            Dim dr As DataRow = dt.Rows(l)

            objSheet.Cells(8 + Counter + l, 1) = (dr("ITEMTEAMGROUP"))
            objSheet.Cells(8 + Counter + l, 2) = (dr("PRODUCT"))
            objSheet.Cells(8 + Counter + l, 3) = dr("MDC")
            objSheet.Cells(8 + Counter + l, 4) = dr("ZPC")
            objSheet.Cells(8 + Counter + l, 5) = dr("INH")
            objSheet.Cells(8 + Counter + l, 6) = dr("TOTAL")
            objSheet.Cells(8 + Counter + l, 7) = dr("FC")
            objSheet.Cells(8 + Counter + l, 8) = dr("PERF %") * 100 & Format("%")
            objSheet.Cells(8 + Counter + l, 9) = dr("MDC1")
            objSheet.Cells(8 + Counter + l, 10) = dr("GROWTH %") * 100 & Format("%")
            objSheet.Cells(8 + Counter + l, 11) = dr("ZPC1")
            objSheet.Cells(8 + Counter + l, 12) = dr("GROWTH %1") * 100 & Format("%")
            objSheet.Cells(8 + Counter + l, 13) = dr("INH1")
            objSheet.Cells(8 + Counter + l, 14) = dr("GROWTH %2") * 100 & Format("%")
            objSheet.Cells(8 + Counter + l, 15) = dr("TOTAL1")
            objSheet.Cells(8 + Counter + l, 16) = dr("GROWHTLA")
            objSheet.Cells(8 + Counter + l, 17) = dr("FC1")
            objSheet.Cells(8 + Counter + l, 18) = dr("PREF%") * 100 & Format("%")
            ctr += 1
        Next
        range = objSheet.Range("A" & Convert.ToString(y + Counter), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        range.Font.Name = "Segoe UI"
        range.Font.Size = 8

        range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

        range = objSheet.Range("A" & Convert.ToString(y + Counter), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        range.Cells.NumberFormat = "#,##0.00"


        objSheet.Range("B1:AZ400").EntireColumn.AutoFit()
        ProgressBar1.Visible = False

        Return True

    End Function
    Private Sub CreateHeaderForTerritoryReportAnalysisReport(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)

        objSheet.Cells(y, 1) = "CATEGORY"
        objSheet.Cells(y, 2) = "PRODUCT"
        objSheet.Cells(y, 3) = "MDC"
        objSheet.Cells(y, 4) = "ZPC"
        objSheet.Cells(y, 5) = "INH"
        objSheet.Cells(y, 6) = "TOTAL"
        objSheet.Cells(y, 7) = "FC"
        objSheet.Cells(y, 8) = "PERF %"
        objSheet.Cells(y, 9) = "MDC"
        objSheet.Cells(y, 10) = "GR %"
        objSheet.Cells(y, 11) = "ZPC"
        objSheet.Cells(y, 12) = "GR %"
        objSheet.Cells(y, 13) = "INH"
        objSheet.Cells(y, 14) = "GR %"
        objSheet.Cells(y, 15) = "TOTAL"
        objSheet.Cells(y, 16) = "GR %"
        objSheet.Cells(y, 17) = "FC"
        objSheet.Cells(y, 18) = "PERF %"
        range = objSheet.Range("A" & Convert.ToString(y) & ":AB" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter

    End Sub
    Private Sub CreateHeaderForConsolidatedbyDistrict(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)

        objSheet.Cells(y, 1) = "CATEGORY"
        objSheet.Cells(y, 2) = "PRODUCT"
        objSheet.Cells(y, 3) = "MDC"
        objSheet.Cells(y, 4) = "ZPC"
        objSheet.Cells(y, 5) = "INH"
        objSheet.Cells(y, 6) = "TOTAL"
        objSheet.Cells(y, 7) = "FC"
        objSheet.Cells(y, 8) = "PERF %"
        objSheet.Cells(y, 9) = "MDC"
        objSheet.Cells(y, 10) = "GR %"
        objSheet.Cells(y, 11) = "ZPC"
        objSheet.Cells(y, 12) = "GR %"
        objSheet.Cells(y, 13) = "INH"
        objSheet.Cells(y, 14) = "GR %"
        objSheet.Cells(y, 15) = "TOTAL"
        objSheet.Cells(y, 16) = "GR %"
        objSheet.Cells(y, 17) = "FC"
        objSheet.Cells(y, 18) = "PERF %"

        range = objSheet.Range("A" & Convert.ToString(y) & ":AA" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter

    End Sub

    Private Sub CreateHeaderForTerritoryReport(ByVal objSheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)

        objSheet.Cells(y, 1) = "District Code"
        objSheet.Cells(y, 2) = "Company Code"
        objSheet.Cells(y, 3) = "Customer Code"
        objSheet.Cells(y, 4) = "Customer Name"
        objSheet.Cells(y, 5) = "Ship to Code"
        objSheet.Cells(y, 6) = "Ship to Address1"
        objSheet.Cells(y, 7) = "Ship to Address2"

        range = objSheet.Range("A" & Convert.ToString(y) & ":G" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            chkForAM.Checked = False
            chkNationalReport.Checked = False
            cboYear2.Enabled = True
            cboYear3.Enabled = True
            cboYear3.Visible = True
            Label8.Visible = True
            cboMonth2.Enabled = True
            cboMonth3.Enabled = True
            LoadMedicalRep()
        End If
    End Sub

    Private Sub cboMonth2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMonth2.SelectedIndexChanged
        If cboMonth2.SelectedIndex = -1 Then Exit Sub
        LoadMonths(cboYear2.Text, cboMonth3)
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub chkConsolitededDistrict_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkConsolitededDistrict.CheckedChanged
        If chkConsolitededDistrict.Checked Then
            chkMedicalRep.Checked = False
            chkForAM.Checked = False
            ChkconsolitededTerrity.Checked = False
            chkNationalReport.Checked = False
            optItem.Checked = False
            cboYear3.Visible = False
            Label8.Visible = False
        End If
    End Sub

    Private Sub ChkconsolitededTerrity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkconsolitededTerrity.CheckedChanged
        If ChkconsolitededTerrity.Checked Then
            chkMedicalRep.Checked = False
            chkForAM.Checked = False
            chkNationalReport.Checked = False
            optItem.Checked = False
            cboYear3.Visible = False
            Label8.Visible = False
        End If
    End Sub

    Private Sub checkitemdistrict_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkitemdistrict.CheckedChanged
        If checkitemdistrict.Checked Then
            chkMedicalRep.Checked = False
            chkForAM.Checked = False
            chkNationalReport.Checked = False
            optItem.Checked = False
            cboYear3.Visible = False
            Label8.Visible = False
            chkConsolitededDistrict.Checked = False
        End If
    End Sub

    Private Sub cmbConfigtypeCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbConfigtypeCode.Click

    End Sub

    Private Sub cmbConfigtypeCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbConfigtypeCode.TextChanged
        table = GetRecords("Select ConfigTypeName from ConfigurationType where ConfigtypeCode = '" & cmbConfigtypeCode.Text & "'")
        For i As Integer = 0 To table.Rows.Count - 1
            txtconfigtypeName.Text = table.Rows(i)("ConfigTypeName")
        Next
    End Sub

    Private Sub cboMonth3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMonth3.SelectedIndexChanged

    End Sub
End Class