Imports SPMSOPCI.ConnectionModule
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

Imports System.Threading

Public Class UCReportSalesComparison
    Implements ExcelPrint
    Dim ThreadLoadData As New Thread(New ThreadStart(AddressOf LoadData))
    Dim ThreadGenerateReport As New Thread(New ThreadStart(AddressOf Printing))
    Dim _PrintToExcel As CReportPrint
    Dim rs As New DataTable
    'Dim table As New DataTable
    Dim dv As New DataView
    Dim Month As String
    Dim Year As String
    Dim TimerCounter As Integer = 0
    Dim ThreadLoadDataIsActive As Integer = 0, ThreadGenerateReportIsActive As Integer = 0

    Private Function RsGpiCalendarMonth(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If
        rs.Open("SELECT DISTINCT CAPN FROM CALENDAR WHERE COMID = '" & ConnectionModule.GetDefaultCompany & "' " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs
    End Function

    Private Function RsGpiCalendarYear(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
            rs.Open("SELECT DISTINCT CAYR FROM CALENDAR WHERE COMID = '" & ConnectionModule.GetDefaultCompany & "' " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        End If
        Return rs
    End Function

    Private Sub LoadYear()
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT DISTINCT CAYR FROM CALENDAR WHERE COMID = '" & ConnectionModule.GetDefaultCompany & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        cmbStartYear.Items.Clear()
        For m As Integer = 0 To rs.RecordCount - 1
            cmbStartYear.Items.Add(rs.Fields("CAYR").Value)
            rs.MoveNext()
        Next

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


    '        objSheet.Name = "Sales Comparison"




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
    '        objBook.SaveAs("Sales Comparison", Excel.XlFileFormat.xlWorkbookNormal, System.Reflection.Missing.Value, System.Reflection.Missing.Value, True, False, Excel.XlSaveAsAccessMode.xlNoChange, False, False, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
    '        Exit Sub
    'errHandler:

    '        objExcel.Quit()
    '    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        UCReportSalesComparison.CheckForIllegalCrossThreadCalls = False
        ProgressBar1.Visible = True
        Timer1.Enabled = True
        
        Month = cmbStartMonth.Text
        Year = cmbStartYear.Text

        'dv.Table = GetRecords("Exec uspSalesComparison @STARTYEAR='" & cmbStartYear.Text & "',@STARTMONTH='" & cmbStartMonth.Text & "',@ENDMONTH='" & cmbEndMonth.Text & "',@GROUPBY='" & GetComparisonCode(cmbComparison.Text) & "'")

        'Me.DataGridView1.DataSource = table
        ''LoadData()
        ThreadLoadData = New Thread(New ThreadStart(AddressOf LoadData))
        ThreadLoadData.Start()

    End Sub

    Private Sub LoadToDV()
        dv.Table = GetRecords("Exec uspSalesComparison @STARTYEAR='" & cmbStartYear.Text & "',@STARTMONTH='" & cmbStartMonth.Text & "',@ENDMONTH='" & cmbEndMonth.Text & "',@GROUPBY='" & GetComparisonCode(cmbComparison.Text) & "'")
    End Sub

    Private Sub LoadData()
        ThreadLoadDataIsActive = 1
        UCReportSalesComparison.CheckForIllegalCrossThreadCalls = False

        Label6.Text = "Generating Preview . . ."

        'dv.Table = GetRecords("Exec uspSalesComparison @STARTYEAR='" & cmbStartYear.Text & "',@STARTMONTH='" & cmbStartMonth.Text & "',@ENDMONTH='" & cmbEndMonth.Text & "',@GROUPBY='" & GetComparisonCode(cmbComparison.Text) & "'")
        LoadToDV()

        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()
        'ClearDatagridView(Me.DataGridView1)
        Dim col1 As Integer = 0
        For Each ColumnHeader As System.Data.DataColumn In dv.Table.Columns
            Me.DataGridView1.Columns.Add(ColumnHeader.ColumnName, ColumnHeader.ColumnName)
            If col1 = 0 Then
                Me.DataGridView1.Columns(col1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
            Else
                Me.DataGridView1.Columns(col1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
            End If
            col1 = col1 + 1
        Next

        For r As Integer = 0 To dv.Table.Rows.Count - 1
            DataGridView1.Rows.Add()
            For c As Integer = 0 To dv.Table.Columns.Count - 1
                DataGridView1.Rows(r).Cells(c).Value = dv.Table.Rows(r)(c)
                DataGridView1.Rows(r).Cells(c).Style.WrapMode = DataGridViewTriState.True
            Next
        Next
        ThreadLoadDataIsActive = 0
    End Sub

    Private Sub ClearDatagridView(ByVal DataGrid As DataGridView)
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()
    End Sub

    Private Sub UCReportSalesComparison_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbComparison.Items.Add("Company")
        cmbComparison.Items.Add("Territory")
        cmbComparison.Items.Add("Item")
        cmbComparison.Items.Add("District")
        cmbComparison.Items.Add("Customer")

        LoadYear()
        ApplyGridTheme(Me.DataGridView1)
    End Sub

    Private Function GetComparisonCode(ByVal ComparisonName As String) As String
        Dim ComparisonCode As String
        ComparisonCode = ""
        If UCase(ComparisonName) = UCase("Company") Then
            ComparisonCode = "COMID"
        ElseIf UCase(ComparisonName) = UCase("Territory") Then
            ComparisonCode = "TERRCD"
        ElseIf UCase(ComparisonName) = UCase("Item") Then
            ComparisonCode = "PROD"
        ElseIf UCase(ComparisonName) = UCase("District") Then
            ComparisonCode = "DIVCD"
        ElseIf UCase(ComparisonName) = UCase("Customer") Then
            ComparisonCode = "CUST"
        End If
        Return ComparisonCode
    End Function

    Private Sub RefreshData()


    End Sub

    Private Sub cmbStartYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStartYear.SelectedIndexChanged
        LoadMonth(cmbStartYear.Text)
    End Sub

    Private Sub LoadMonth(ByVal Year As String)
        Dim m_RsMonth As New ADODB.Recordset
        If m_RsMonth.State = 1 Then m_RsMonth.Close()
        m_RsMonth.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsMonth.Open("SELECT * FROM Calendar WHERE COMID = '" & ConnectionModule.GetDefaultCompany & "' AND CAYR = '" & Year & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsMonth.RecordCount > 0 Then
            cmbStartMonth.Items.Clear()

            cmbEndMonth.Items.Clear()
            For m As Integer = 0 To m_RsMonth.RecordCount - 1
                cmbStartMonth.Items.Add(m_RsMonth.Fields("CAPN").Value)
                cmbEndMonth.Items.Add(m_RsMonth.Fields("CAPN").Value)
                m_RsMonth.MoveNext()
            Next
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("No Report to generate.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        ProgressBar1.Visible = True
        Timer1.Enabled = True
        Label6.Text = "Generating Report . . ."
        Month = cmbStartMonth.Text
        Year = cmbStartYear.Text
        ThreadGenerateReport = New Thread(New ThreadStart(AddressOf Printing))
        ThreadGenerateReport.Start()

    End Sub

    Private Sub Printing()
        ThreadGenerateReportIsActive = 1
        _PrintToExcel = New CReportPrint
        Dim RowX As Integer = 3
        Dim ColY As Integer = 1
        Dim AreaLength As Integer = dv.Table.Columns.Count
        Dim AreaHeight As Integer = dv.Table.Rows.Count
        Dim CountRecord As Integer = dv.Table.Rows.Count


        '_PrintToExcel.OpenExcel()

        PrintHeader(RowX, ColY, AreaLength)

        PrintDetails(RowX, ColY, AreaHeight, AreaLength, CountRecord)

        PrintFooter(RowX, ColY)
        ThreadGenerateReportIsActive = 0
    End Sub
#Region "Excel Printing"

    Public Sub PrintDetails(ByVal StartRowX As Integer, ByVal StartColY As Integer, ByVal AreaH As Integer, ByVal AreaL As Integer, ByVal DetailCount As Integer) Implements ExcelPrint.PrintDetails
        
        StartRowX = StartRowX + 4
        'Try
        _PrintToExcel.BackColor(StartRowX, StartColY, StartRowX, AreaL, CEnumeration.ColorIndex.Aqua)
        _PrintToExcel.DetailsArea(StartRowX, StartColY, AreaH + StartRowX, AreaL)
        'print Column Header
        For Each ColumnHeader As DataColumn In dv.Table.Columns
            _PrintToExcel.PrintText(ColumnHeader.ColumnName, StartRowX, ColumnHeader.Ordinal + 1, , , True, CEnumeration.ColorIndex.OliveGreen)
        Next
        ''For Each ColumnHeader As DataGridViewColumn In DataGridView1.Columns
        ''    _PrintToExcel.PrintText(ColumnHeader.Name, StartRowX, ColumnHeader.Index + 1, , , True, CEnumeration.ColorIndex.OliveGreen)
        ''Next
        'end Column Header
        'Print Details-----

        For ir As Integer = 0 To dv.Table.Rows.Count - 1

            For ic As Integer = 0 To dv.Table.Columns.Count - 1

                If IsNumeric(IIf(dv.Table.Rows(ir)(ic) Is DBNull.Value, "0.00", dv.Table.Rows(ir)(ic))) Then

                    _PrintToExcel.PrintText(IIf(dv.Table.Rows(ir)(ic) Is DBNull.Value, "0.00", dv.Table.Rows(ir)(ic)), ir + (StartRowX + 1), ic + StartColY, , , , , Excel.XlHAlign.xlHAlignRight)
                Else
                    _PrintToExcel.PrintText(IIf(dv.Table.Rows(ir)(ic) Is DBNull.Value, "0.00", dv.Table.Rows(ir)(ic)), ir + (StartRowX + 1), ic + StartColY)
                End If
            Next ic
            'ProgressBar1.Value = ((DetailCount - (DetailCount - (ir + 1))) / DetailCount) * 100
        Next ir


            'Print Details
            'ResetProgressBar()
            'Catch ex As Exception
            '    'ResetProgressBar()
            '    MsgBox(ex.Message)
            'End Try
    End Sub

    Public Sub PrintFooter(ByVal StartRowX As Integer, ByVal StartColY As Integer) Implements ExcelPrint.PrintFooter
        _PrintToExcel.CloseExcel()
    End Sub

    Public Sub PrintHeader(ByVal StartRowX As Integer, ByVal StartColY As Integer, ByVal AreaL As Integer) Implements ExcelPrint.PrintHeader
        

        _PrintToExcel.OpenExcel()
        'Try
        _PrintToExcel.PrintText(GetDefaultCompanyName, 2, 1, "Lucida Handwriting", 9, FontStyle.Italic)
        _PrintToExcel.MergeCell(2, 1, 2, 4)

        _PrintToExcel.HeaderArea(StartRowX + 1, StartColY, 5, AreaL)


        _PrintToExcel.PrintText("Run Date : ", StartRowX, 1, , 9, FontStyle.Bold)
        _PrintToExcel.PrintText(Now.Date.ToString, StartRowX, 2)
        _PrintToExcel.PrintText("Run Time : ", StartRowX + 1, 1, , 9, FontStyle.Bold)
        _PrintToExcel.PrintText(Now.ToString("hh:mm:ss"), StartRowX + 1, 2)
        _PrintToExcel.PrintText("Report Date : ", StartRowX + 2, 1, , 9, FontStyle.Bold)

        _PrintToExcel.PrintText(cmbStartMonth.Text & " TO " & cmbEndMonth.Text & "  " & cmbStartYear.Text, StartRowX + 2, 2)


        _PrintToExcel.BackColor(StartRowX + 3, 1, StartRowX + 3, AreaL, CEnumeration.ColorIndex.No20)
        _PrintToExcel.PrintText(Label1.Text, StartRowX + 3, 5, , 11, FontStyle.Bold, CEnumeration.ColorIndex.DarkBlue)

        _PrintToExcel.MergeCell(StartRowX + 3, 1, StartRowX + 3, AreaL)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
#End Region


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If ProgressBar1.Value = 100 Then
            ProgressBar1.Value = 0
        Else
            ProgressBar1.Value = ProgressBar1.Value + 5
        End If
        Me.Enabled = False
        'ThreadLoadData.
        If ThreadLoadDataIsActive = 0 And ThreadGenerateReportIsActive = 0 Then
            Label6.Text = "Refreshing . . . "
            Timer2.Enabled = True
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If TimerCounter = 5 Then
            Timer1.Enabled = False
            ProgressBar1.Visible = False
            ProgressBar1.Value = 0
            Label6.Text = ""
            Timer1.Enabled = False
            Me.Enabled = True
            TimerCounter = 0
            Timer2.Enabled = False

        Else
            TimerCounter = TimerCounter + 1
        End If
    End Sub
End Class
