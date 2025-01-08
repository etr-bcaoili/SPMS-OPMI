Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Threading

Public Class ucMercuryPerRepPerBranch
    Implements ExcelPrint
    Dim _PrinttoExcel As New CReportPrint
    Dim ThreadLoadData As Thread '(New ThreadStart(AddressOf LoadData))
    Dim ThreadGenerateReport As Thread
    Dim dv As New DataView
    Dim TimerCounter As Integer = 0
    Dim ThreadLoadDataIsActive As Integer = 0, ThreadGenerateReportIsActive As Integer = 0

    Private Sub Loadyear()
        dv.Table = GetRecords("Select DISTINCT CAYR FROM CALENDAR")
        For I As Integer = 0 To dv.Table.Rows.Count - 1
            cmbStartYear.Items.Add(dv.Table.Rows(I)(0))
            cmbEndYear.Items.Add(dv.Table.Rows(I)(0))
        Next
    End Sub

    Private Sub cmbStartYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStartYear.SelectedIndexChanged
        dv.Table = GetRecords("Select DISTINCT CAPN FROM CALENDAR WHERE CAYR=" & cmbStartYear.Text)
        For I As Integer = 0 To dv.Table.Rows.Count - 1
            cmbStartMonth.Items.Add(dv.Table.Rows(I)(0))
        Next
        LoadDetDetails()
    End Sub

    Private Sub cmbEndYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEndYear.SelectedIndexChanged
        dv.Table = GetRecords("Select DISTINCT CAPN FROM CALENDAR WHERE CAYR=" & cmbEndYear.Text)
        For I As Integer = 0 To dv.Table.Rows.Count - 1
            cmbEndMonth.Items.Add(dv.Table.Rows(I)(0))
        Next
        LoadDetDetails()
    End Sub

    Private Sub LoadDetDetails()
        cmbDetCode.Items.Clear()
        cmbDetName.Items.Clear()
        dv.Table = GetRecords("SELECT DISTINCT TERRCD,SSE FROM cust_div_item_sales WHERE CUTYEAR BETWEEN '" & cmbStartYear.Text & "' AND '" & cmbEndYear.Text & "' ORDER BY TERRCD")
        For I As Integer = 0 To dv.Table.Rows.Count - 1
            cmbDetCode.Items.Add(dv.Table.Rows(I)(0))
            cmbDetName.Items.Add(dv.Table.Rows(I)(1))
        Next
    End Sub

    Private Sub ucMercuryPerRepPerBranch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(Me.DataGridView1)
        Loadyear()
    End Sub

    Private Sub LoadData()
        ThreadLoadDataIsActive = 1
        ucReportItemDetailmanComparative.CheckForIllegalCrossThreadCalls = False

        Label7.Text = "Generating Preview . . ."

        dv.Table = GetRecords("EXEC [uspMERPerRepPerBranch] @YEARFROM =" & cmbStartYear.Text & ",@YEARTO =" & cmbEndYear.Text & ",@MONTHFROM =" & cmbStartMonth.Text & ",@MONTHTO =" & cmbEndMonth.Text & ",@TERRCD='" & cmbDetCode.Text & "'")

        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        Dim col1 As Integer = 0


        col1 = 0
        For Each ColumnHeader As System.Data.DataColumn In dv.Table.Columns
            Me.DataGridView1.Columns.Add(ColumnHeader.ColumnName, ColumnHeader.ColumnName)
            'If col1 < 2 Then
            '    Me.DataGridView1.Columns(col1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
            'Else
            '    Me.DataGridView1.Columns(col1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
            'End If
            'col1 = col1 + 1
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

    Private Sub MenuButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click, btnExport.Click, btnClose.Click
        If sender Is btnPrintPreview Then
            ucReportItemDetailmanComparative.CheckForIllegalCrossThreadCalls = False
            ProgressBar1.Visible = True
            Timer1.Enabled = True

            'Me.DataGridView1.DataSource = table
            ' ''LoadData()
            ThreadLoadData = New Thread(New ThreadStart(AddressOf LoadData))
            ThreadLoadData.Start()
        ElseIf sender Is btnExport Then
            'Export()
            ProgressBar1.Visible = True
            Timer1.Enabled = True
            Label7.Text = "Generating Report . . ."
            ThreadGenerateReport = New Thread(New ThreadStart(AddressOf Printing))
            ThreadGenerateReport.Start()
        ElseIf sender Is btnClose Then
            Close()
        End If
    End Sub

    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

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

        _PrinttoExcel.PrintText(Label1.Text, StartRowX + 3, 5, , 11, FontStyle.Bold, CEnumeration.ColorIndex.DarkBlue)

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

        'For Each ColumnHeader As DataGridViewColumn In DataGridView1.Columns
        '    If ColumnHeader.Index > 1 Then
        '        _PrinttoExcel.PrintText(ColumnHeader.Name, StartRowX, ColumnHeader.Index + 1, , , True, CEnumeration.ColorIndex.OliveGreen)
        '    End If
        'Next
        Dim col1 As Integer = 0
        For Each ColumnHeader As System.Data.DataColumn In dv.Table.Columns
            _PrinttoExcel.PrintText(ColumnHeader.ColumnName, StartRowX, col1 + 1, , , True, CEnumeration.ColorIndex.OliveGreen)
            col1 = col1 + 1
        Next

        'end Column Header
        'Print Details-----

        'For ir As Integer = 0 To DataGridView1.Rows.Count - 1
        Dim TERRCD As String = String.Empty
        Dim PROD As String = String.Empty
        For ir As Integer = 0 To dv.Table.Rows.Count - 1
            ''For ic As Integer = 0 To DataGridView1.Columns.Count - 1
            ''If TERRCD <> dv.Table.Rows(ir)(0) Or PROD <> dv.Table.Rows(ir)(1) Then
            ''    _PrinttoExcel.PrintText(dv.Table.Rows(ir)(0), ir + (StartRowX + 1), 0 + StartColY)
            ''    _PrinttoExcel.PrintText(dv.Table.Rows(ir)(1), ir + (StartRowX + 1), 1 + StartColY)
            ''    _PrinttoExcel.PrintText(dv.Table.Rows(ir)(2), ir + (StartRowX + 2), 1 + StartColY)
            ''    _PrinttoExcel.PrintText(dv.Table.Rows(ir)(3), ir + (StartRowX + 2), 2 + StartColY)
            ''End If
            ''For ic As Integer = 4 To dv.Table.Columns.Count - 1
            ''    If IsNumeric(IIf(dv.Table.Rows(ir)(ic) Is DBNull.Value, "0.00", dv.Table.Rows(ir)(ic))) Then
            ''        _PrinttoExcel.PrintText(IIf(dv.Table.Rows(ir)(ic) Is DBNull.Value, "0.00", dv.Table.Rows(ir)(ic)), ir + (StartRowX + 2), ic + StartColY, , , , , Excel.XlHAlign.xlHAlignRight)
            ''    Else
            ''        _PrinttoExcel.PrintText(IIf(dv.Table.Rows(ir)(ic) Is DBNull.Value, "0.00", dv.Table.Rows(ir)(ic)), ir + (StartRowX + 2), ic + StartColY)
            ''    End If
            ''    'FormLoading.ProgressBar1.Value = 1
            ''    'FormLoading.ProgressBar2.Value = 2
            ''Next ic
            ''TERRCD = dv.Table.Rows(ir)(0)
            ''PROD = dv.Table.Rows(ir)(1)
            For ic As Integer = 0 To dv.Table.Columns.Count - 1
                If IsNumeric(IIf(dv.Table.Rows(ir)(ic) Is DBNull.Value, "0.00", dv.Table.Rows(ir)(ic))) Then
                    _PrinttoExcel.PrintText(IIf(dv.Table.Rows(ir)(ic) Is DBNull.Value, "0.00", dv.Table.Rows(ir)(ic)), ir + (StartRowX + 1), ic + StartColY, , , , , Excel.XlHAlign.xlHAlignRight)
                Else
                    _PrinttoExcel.PrintText(IIf(dv.Table.Rows(ir)(ic) Is DBNull.Value, "0.00", dv.Table.Rows(ir)(ic)), ir + (StartRowX + 1), ic + StartColY)
                End If
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

    Private Sub cmbDetCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDetCode.SelectedIndexChanged
        cmbDetName.SelectedIndex = cmbDetCode.SelectedIndex
    End Sub

    Private Sub cmbDetName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDetName.SelectedIndexChanged
        cmbDetCode.SelectedIndex = cmbDetName.SelectedIndex
    End Sub
End Class
