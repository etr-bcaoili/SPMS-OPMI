Imports System.Data.SqlClient
Imports SPMSOPCI.ConnectionModule

Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

Imports System.Threading


Public Class ucReportItemDetailmanComparative
    Implements ExcelPrint
    Dim ThreadLoadData As Thread '(New ThreadStart(AddressOf LoadData))
    Dim ThreadGenerateReport As Thread '(New ThreadStart(AddressOf Printing ))

    Dim dt As New DataTable
    Dim table As DataTable
    Dim dv As New DataView
    Dim _PrinttoExcel As New CReportPrint
    Dim Month As String
    Dim Year As String
    Dim by As String
    Dim TimerCounter As Integer = 0
    Dim ThreadLoadDataIsActive As Integer = 0, ThreadGenerateReportIsActive As Integer = 0


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub ucReportItemDetailmanComparative_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Loadyear()
        cmbBy.Items.Add("Territory")
        cmbBy.Items.Add("Item")
        ApplyGridTheme(Me.DataGridView1)
    End Sub

    Private Sub Loadyear()
        dt = GetRecords("Select DISTINCT CAYR FROM CALENDAR")
        For I As Integer = 0 To dt.Rows.Count - 1
            cmbStartYear.Items.Add(dt.Rows(I)(0))
            cmbEndYear.Items.Add(dt.Rows(I)(0))
        Next
    End Sub

    Private Sub cmbStartYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStartYear.SelectedIndexChanged
        dt = GetRecords("Select DISTINCT CAPN FROM CALENDAR WHERE CAYR=" & cmbStartYear.Text)
        For I As Integer = 0 To dt.Rows.Count - 1
            cmbStartMonth.Items.Add(dt.Rows(I)(0))
        Next
    End Sub

    Private Sub cmbEndYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEndYear.SelectedIndexChanged
        dt = GetRecords("Select DISTINCT CAPN FROM CALENDAR WHERE CAYR=" & cmbEndYear.Text)
        For I As Integer = 0 To dt.Rows.Count - 1
            cmbEndMonth.Items.Add(dt.Rows(I)(0))
        Next
    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        ucReportItemDetailmanComparative.CheckForIllegalCrossThreadCalls = False
        ProgressBar1.Visible = True
        Timer1.Enabled = True

        'Me.DataGridView1.DataSource = table
        ' ''LoadData()
        ThreadLoadData = New Thread(New ThreadStart(AddressOf LoadData))
        ThreadLoadData.Start()

    End Sub

    Private Sub LoadData()
        ThreadLoadDataIsActive = 1
        ucReportItemDetailmanComparative.CheckForIllegalCrossThreadCalls = False

        Label7.Text = "Generating Preview . . ."

        Dim bY As String
        If cmbBy.Text = "Territory" Then
            bY = "TERRCD"
        ElseIf cmbBy.Text = "Item" Then
            bY = "PROD"
        End If

        dv.Table = GetRecords("EXEC [uspMONTHLYCOMPARISONBYCHANNEL] @STARTMONTH=" & cmbStartMonth.Text & ",@ENDMONTH=" & cmbEndMonth.Text & ",@STARTYEAR=" & cmbStartYear.Text & ",@ENDYEAR=" & cmbEndYear.Text & ",@GROUPBY='" & bY & "'")

        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        Dim col1 As Integer = 0
        Dim Columns As New ArrayList
        'REMOVE QTY COLUMN IF NOT ITEM
        For Each ColumnHeader As DataColumn In dv.Table.Columns
            If ColumnHeader.ColumnName.Contains("QTY") Then
                Columns.Add(ColumnHeader.ColumnName)
            End If
        Next

        If cmbBy.Text.Contains("Item") Then
        Else
            For Each ColumnName As String In Columns
                dv.Table.Columns.Remove(ColumnName)
            Next
        End If

        col1 = 0
        For Each ColumnHeader As System.Data.DataColumn In dv.Table.Columns
            Me.DataGridView1.Columns.Add(ColumnHeader.ColumnName, ColumnHeader.ColumnName)
            If col1 < 2 Then
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
#Region "excel Region"
    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        'Export()
        ProgressBar1.Visible = True
        Timer1.Enabled = True
        Label7.Text = "Generating Report . . ."
        Month = cmbStartMonth.Text
        Year = cmbStartYear.Text
        by = cmbBy.Text
        ThreadGenerateReport = New Thread(New ThreadStart(AddressOf Printing))
        ThreadGenerateReport.Start()
    End Sub
#End Region

    Private Sub Printing()
        ThreadGenerateReportIsActive = 1
        Try
            Dim RowX As Integer = 3
            Dim ColY As Integer = 1
            Dim AreaLength As Integer = DataGridView1.Columns.Count
            Dim AreaHeight As Integer = DataGridView1.Rows.Count
            Dim CountRecord As Integer = DataGridView1.Rows.Count


            _PrinttoExcel.OpenExcel()

            PrintHeader(RowX, ColY, AreaLength)

            PrintDetails(RowX, ColY, AreaHeight, AreaLength, CountRecord)

            _PrinttoExcel.CloseExcel()

        Catch ex As Exception

            'Print Details
            _PrinttoExcel.CloseExcel()
            MsgBox(ex.Message)
        End Try
        ThreadGenerateReportIsActive = 0
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


        objSheet.Name = cmbBy.Text & " " & "Comparative Report"




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
        objBook.SaveAs(cmbBy.Text & " " & "Comparative Report", Excel.XlFileFormat.xlWorkbookNormal, System.Reflection.Missing.Value, System.Reflection.Missing.Value, True, False, Excel.XlSaveAsAccessMode.xlNoChange, False, False, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
        Exit Sub
errHandler:

        objExcel.Quit()
    End Sub
#Region "Excel Print Header"
    Public Sub PrintHeader(ByVal StartRowX As Integer, ByVal StartColY As Integer, ByVal AreaL As Integer) Implements ExcelPrint.PrintHeader
        'Try
        _PrinttoExcel.PrintText(GetDefaultCompanyName, 2, 1, "Lucida Handwriting", 9, FontStyle.Italic)
        _PrinttoExcel.MergeCell(2, 1, 2, AreaL - 5)

        _PrinttoExcel.HeaderArea(StartRowX + 1, StartColY, 5, AreaL)


        _PrinttoExcel.PrintText("Run Date : ", StartRowX, 1, , 9, FontStyle.Bold)
        _PrinttoExcel.PrintText(Now.Date, StartRowX, 2)
        _PrinttoExcel.PrintText("Run Time : ", StartRowX + 1, 1, , 9, FontStyle.Bold)
        _PrinttoExcel.PrintText(Format(Now, "hh:mm:ss"), StartRowX + 1, 2)
        _PrinttoExcel.PrintText("Report Date : ", StartRowX + 2, 1, , 9, FontStyle.Bold)


        _PrinttoExcel.BackColor(StartRowX + 3, 1, StartRowX + 3, AreaL, CEnumeration.ColorIndex.No20)
        If by = "Territory" Then
            _PrinttoExcel.PrintText("MR Channel Comparative", StartRowX + 3, 5, , 11, FontStyle.Bold, CEnumeration.ColorIndex.DarkBlue)
        Else
            _PrinttoExcel.PrintText(UCase(by) & " Channel Comparative", StartRowX + 3, 5, , 11, FontStyle.Bold, CEnumeration.ColorIndex.DarkBlue)
        End If
        _PrinttoExcel.MergeCell(StartRowX + 3, 1, StartRowX + 3, AreaL)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub
#End Region
    
#Region "Excel Print Details"
    Public Sub PrintDetails(ByVal StartRowX As Integer, ByVal StartColY As Integer, ByVal AreaH As Integer, ByVal AreaL As Integer, ByVal DetailCount As Integer) Implements ExcelPrint.PrintDetails

        Dim OnGoingProcess As Integer = 0
        Dim ProcessCount As Integer = dv.Table.Rows.Count * dv.Table.Columns.Count
        StartRowX = StartRowX + 4
        'Try
        _PrinttoExcel.BackColor(StartRowX, StartColY, StartRowX, AreaL, CEnumeration.ColorIndex.Aqua)
        _PrinttoExcel.DetailsArea(StartRowX, StartColY, AreaH + StartRowX, AreaL)
        'print Column Header
        _PrinttoExcel.PrintText(UCase(by), StartRowX, StartColY, , , True, CEnumeration.ColorIndex.OliveGreen)

        _PrinttoExcel.PrintText(UCase(by) & " NAME", StartRowX, StartColY + 1, , , True, CEnumeration.ColorIndex.OliveGreen)

        'For Each ColumnHeader As DataGridViewColumn In DataGridView1.Columns
        '    If ColumnHeader.Index > 1 Then
        '        _PrinttoExcel.PrintText(ColumnHeader.Name, StartRowX, ColumnHeader.Index + 1, , , True, CEnumeration.ColorIndex.OliveGreen)
        '    End If
        'Next
        Dim col1 As Integer = 0
        For Each ColumnHeader As System.Data.DataColumn In dv.Table.Columns
            If col1 > 1 Then
                _PrinttoExcel.PrintText(ColumnHeader.ColumnName, StartRowX, col1 + 1, , , True, CEnumeration.ColorIndex.OliveGreen)
            End If
            col1 = col1 + 1
        Next

        'end Column Header
        'Print Details-----

        'For ir As Integer = 0 To DataGridView1.Rows.Count - 1
        For ir As Integer = 0 To dv.Table.Rows.Count - 1
            'For ic As Integer = 0 To DataGridView1.Columns.Count - 1
            For ic As Integer = 0 To dv.Table.Columns.Count - 1
                If IsNumeric(IIf(dv.Table.Rows(ir)(ic) Is DBNull.Value, "0.00", dv.Table.Rows(ir)(ic))) Then
                    _PrinttoExcel.PrintText(IIf(dv.Table.Rows(ir)(ic) Is DBNull.Value, "0.00", dv.Table.Rows(ir)(ic)), ir + (StartRowX + 1), ic + StartColY, , , , , Excel.XlHAlign.xlHAlignRight)
                Else
                    _PrinttoExcel.PrintText(IIf(dv.Table.Rows(ir)(ic) Is DBNull.Value, "0.00", dv.Table.Rows(ir)(ic)), ir + (StartRowX + 1), ic + StartColY)
                End If
                'FormLoading.ProgressBar1.Value = 1
                'FormLoading.ProgressBar2.Value = 2
            Next ic
        Next ir
        'Print Details

        'Catch ex As Exception
        '    ResetProgressBar()
        '    MsgBox(ex.Message)
        'End Try

    End Sub
#End Region
   

    Public Sub PrintFooter(ByVal StartRowX As Integer, ByVal StartColY As Integer) Implements ExcelPrint.PrintFooter

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If ProgressBar1.Value = 100 Then
            ProgressBar1.Value = 0
        Else
            ProgressBar1.Value = ProgressBar1.Value + 5
        End If
        Me.Enabled = False

        If ThreadLoadDataIsActive = 0 And ThreadGenerateReportIsActive = 0 Then
            Label7.Text = "Refreshing . . . "
            Timer2.Enabled = True
        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If TimerCounter = 5 Then
            Timer1.Enabled = False
            ProgressBar1.Visible = False
            ProgressBar1.Value = 0
            Label7.Text = ""
            Timer1.Enabled = False
            Me.Enabled = True
            TimerCounter = 0
            Timer2.Enabled = False

        Else
            TimerCounter = TimerCounter + 1
        End If
    End Sub
End Class
