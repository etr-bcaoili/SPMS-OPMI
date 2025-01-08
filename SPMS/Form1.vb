Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports SPMSOPCI.ConnectionModule
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.Threading

Public Class Form1
    Implements ExcelPrint
    Dim ThreadLoadData As New Thread(New ThreadStart(AddressOf LoadData))
    Dim ThreadGenerateReport As New Thread(New ThreadStart(AddressOf Printing))
    Dim _PrintToExcel As CReportPrint
    Private bindingSource1 As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Private table As New DataTable
    Private m_HasErr As Boolean = False
    Private m_Err As New ErrorProvider
    Dim dv As New DataView
    Dim TimerCounter As Integer = 0
    Dim ThreadLoadDataIsActive As Integer = 0, ThreadGenerateReportIsActive As Integer = 0

    Private Sub ExecuteData()
        Try
            ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspMetroDrugInvoiceReport3", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ToCutMo", dtTo.Value.Month)
            cmd.Parameters.AddWithValue("@ToCutYear", dtTo.Value.Year)
            cmd.Parameters.AddWithValue("@FromCutMo", dtFrom.Value.Month)
            cmd.Parameters.AddWithValue("@FromCutYear", dtFrom.Value.Year)
            cmd.Parameters.AddWithValue("@COMID", cmbCompany.Text)
            SPMSOPCI.ConnectionModule.Disconnect()


            Me.dataAdapter = New SqlDataAdapter(cmd)
            table = New DataTable
            table.TableName = "uspMetroDrugInvoiceReport3"
            table.Locale = System.Globalization.CultureInfo.InvariantCulture
            'Me.dataAdapter.Fill(table)
            Me.dataAdapter.Fill(table)
            'Me.bindingSource1.DataSource = table
            dv.Table = table
            'Dim style As DataGridViewCellStyle
            'Dim i As Integer
            'Dim j As Decimal
            'style = New DataGridViewCellStyle()
            'style.Alignment = DataGridViewContentAlignment.MiddleRight
            'i = 0
            'While i < DataGridView1.ColumnCount
            '    If (DataGridView1.Columns.Item(i).ValueType Is j.GetType) Then
            '        DataGridView1.Columns.Item(i).DefaultCellStyle = style
            '    End If
            '    i = i + 1
            'End While

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadCompany()
        ApplyGridTheme(Me.DataGridView1)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If ValidateData() Then


            'Me.DataGridView1.ClearSelection()
            'Me.DataGridView1.DataSource = Me.bindingSource1
            'ExecuteData()
            'lblCount.Text = DataGridView1.RowCount - 1

            UCReportSalesComparison.CheckForIllegalCrossThreadCalls = False
            ProgressBar1.Visible = True
            Timer1.Enabled = True


            'dv.Table = GetRecords("Exec uspSalesComparison @STARTYEAR='" & cmbStartYear.Text & "',@STARTMONTH='" & cmbStartMonth.Text & "',@ENDMONTH='" & cmbEndMonth.Text & "',@GROUPBY='" & GetComparisonCode(cmbComparison.Text) & "'")

            'Me.DataGridView1.DataSource = table
            ExecuteData()
            ThreadLoadData = New Thread(New ThreadStart(AddressOf LoadData))
            ThreadLoadData.Start()
        End If
    End Sub

    Private Sub LoadData()
        ThreadLoadDataIsActive = 1
        UCReportSalesComparison.CheckForIllegalCrossThreadCalls = False

        Label8.Text = "Generating Preview . . ."

        'dv.Table = GetRecords("Exec uspSalesComparison @STARTYEAR='" & cmbStartYear.Text & "',@STARTMONTH='" & cmbStartMonth.Text & "',@ENDMONTH='" & cmbEndMonth.Text & "',@GROUPBY='" & GetComparisonCode(cmbComparison.Text) & "'")
        'LoadToDV()
        ExecuteData()

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

    Private Function ValidateData()
        m_HasErr = False
        m_Err.Clear()
        If txtCompanyName.Text = String.Empty Or txtCompanyName.Text = Nothing Then
            m_Err.SetError(txtCompanyName, "Company Required")
            m_HasErr = True
        End If
        If dtFrom.Value > dtTo.Value Then
            m_Err.SetError(dtTo, "Must Higher Than Cut - Off Month From")
            m_HasErr = True
        End If
        Return Not m_HasErr
    End Function

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        'If MsgBox("Are You Sure You Want To Terminate The System?", vbYesNo) = Windows.Forms.DialogResult.Yes Then
        '    End
        'Else
        '    Exit Sub
        'End If
        close()
    End Sub

    Private Overloads Sub close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub LoadCompany()
        dv.Table = GetRecords("select distinct DISTCOMID  from Distributor")
        For i As Integer = 0 To dv.Table.Rows.Count - 1
            cmbCompany.Items.Add(dv.Table.Rows(i)(0))
        Next
    End Sub

    Private Sub ExportToExcel()
        On Error GoTo errHandler


        Dim objExcel As Excel.Application = Nothing
        Dim objBooks As Excel.Workbooks = Nothing
        Dim objBook As Excel.Workbook = Nothing
        Dim objSheets As Excel.Sheets = Nothing
        Dim objSheet As Excel.Worksheet = Nothing
        Dim objRange As Excel.Range = Nothing

        objExcel = New Excel.Application
        objExcel.Visible = False
        objExcel.DisplayAlerts = False

        objBook = CType(objExcel.Workbooks.Add(), Excel.Workbook)

        objBooks = objExcel.Workbooks
        objSheet = CType(objBooks(1).Sheets.Item(1), Excel.Worksheet)
        objSheets = objBook.Worksheets

        objSheets.Add(Count:=6)

        objBook = objBooks.Item(1)
        objSheet = CType(objSheets.Item(1), Excel.Worksheet)

        objSheet.Name = "Invoice Report"
        objSheet.Range("A1:A2", "D1:D2").Font.Size = 12
        objSheet.Range("A1:A2", "D1:D2").Font.Bold = True
        objSheet.Range("A1", "D1").MergeCells = True
        objSheet.Range("A2", "D2").MergeCells = True
        objExcel.Cells(1, 1).value = txtCompanyName.Text & " INVOICE REPORT"
        objExcel.Cells(2, 1).value = "CUT OFF : " & dtFrom.Value.ToShortDateString & " - " & dtTo.Value.ToShortDateString

        For i As Integer = 0 To table.Columns.Count - 1
            objSheet.Range("A4", "ZA4").Font.Size = 12
            objSheet.Range("A4", "ZA4").Font.Bold = True
            'objSheet.Range("A4:A5", "ZA4:ZA5").Justify()
            'objSheet.Range("A4:ZA4").EntireColumn.EntireRow.AutoFit()

            objExcel.Cells(4, i + 1).value = table.Columns(i).ColumnName
        Next

        objSheet.Range("A6:az2000").Font.Size = 8
        objSheet.Range("A6:az2000").Font.Bold = False
        'objSheet.Range("A6:az2000").EntireColumn.Justify()
        For i As Integer = 6 To table.Rows.Count + 5
            Dim dr As DataRow = table.Rows(i - 6)
            For o As Integer = 0 To table.Columns.Count - 1
                objExcel.Cells(i, o + 1).value = dr.Item(o)
            Next
        Next

        objSheet.Range("A6:az2000").EntireColumn.AutoFit()


        objSheet = objBook.ActiveSheet()
        Dim objFirstSheet As Excel.Worksheet
        objSheets = objBook.Worksheets
        objFirstSheet = CType(objSheets.Item(1), Excel.Worksheet)
        objFirstSheet.Activate()

        Marshal.ReleaseComObject(objSheet)
        Marshal.ReleaseComObject(objSheets)


        If System.IO.File.Exists(Environment.CurrentDirectory & "\Reports\" & txtCompanyName.Text & "  - INVOICE REPORT " & dtFrom.Value.Month & " - " & dtFrom.Value.Day & " - " & dtFrom.Value.Year & " To " & dtTo.Value.Month & " - " & dtTo.Value.Day & " - " & dtTo.Value.Year & ".xls") Then
            System.IO.File.Delete(Environment.CurrentDirectory & "\Reports\" & txtCompanyName.Text & "  - INVOICE REPORT " & dtFrom.Value.Month & " - " & dtFrom.Value.Day & " - " & dtFrom.Value.Year & " To " & dtTo.Value.Month & " - " & dtTo.Value.Day & " - " & dtTo.Value.Year & ".xls")
        End If
        objBook.SaveAs(Environment.CurrentDirectory & "\Reports\" & txtCompanyName.Text & "  - INVOICE REPORT " & dtFrom.Value.Month & " - " & dtFrom.Value.Day & " - " & dtFrom.Value.Year & " To " & dtTo.Value.Month & " - " & dtTo.Value.Day & " - " & dtTo.Value.Year & ".xls")

        objBook.Close()
        objExcel.Quit()

        MessageBox.Show("Successfully Export To Excel")

        Exit Sub
errHandler:

        objExcel.Quit()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        'ExportToExcel()
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("No Report to generate.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        ProgressBar1.Visible = True
        Timer1.Enabled = True
        Label8.Text = "Generating Report . . ."
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

        _PrintToExcel.PrintText(dtFrom.Value & " - " & dtTo.Value, StartRowX + 2, 2)


        _PrintToExcel.BackColor(StartRowX + 3, 1, StartRowX + 3, AreaL, CEnumeration.ColorIndex.No20)
        _PrintToExcel.PrintText(Label11.Text, StartRowX + 3, 5, , 11, FontStyle.Bold, CEnumeration.ColorIndex.DarkBlue)

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
            Label8.Text = "Refreshing . . . "
            Timer2.Enabled = True
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If TimerCounter = 5 Then
            Timer1.Enabled = False
            ProgressBar1.Visible = False
            ProgressBar1.Value = 0
            Label8.Text = ""
            Timer1.Enabled = False
            Me.Enabled = True
            TimerCounter = 0
            Timer2.Enabled = False

        Else
            TimerCounter = TimerCounter + 1
        End If
    End Sub


End Class
