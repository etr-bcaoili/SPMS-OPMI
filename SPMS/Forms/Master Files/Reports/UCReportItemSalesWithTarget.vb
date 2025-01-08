Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Threading

Public Class UCReportItemSalesWithTarget
    Implements ExcelPrint
    Dim _PrintToExcel As New CReportPrint
    Dim ThreadLoadData As New Thread(New ThreadStart(AddressOf LoadData))
    Dim ThreadGenerateReport As New Thread(New ThreadStart(AddressOf Printing))
    Dim dv As New DataView
    Dim Month As String
    Dim Year As String
    Dim TimerCounter As Integer = 0
    Dim ThreadLoadDataIsActive As Integer = 0, ThreadGenerateReportIsActive As Integer = 0

    Private Sub lnkTerritory_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkTerritory.LinkClicked
        Dim tag As SelectionTag = ShowSearchDialog("SELECT [STACOVCD],[STACOVCD],[STACOVNAME] FROM STAreaCoverage", "SELECT [STACOVCD],[STACOVCD],[STACOVNAME] FROM STAreaCoverage", "Select Territory.")
        If Not tag Is Nothing Then
            txtTerritory.Tag = tag.KeyColumn1
            txtTerritory.Text = tag.KeyColumn2 & " - " & tag.KeyColumn3
        End If
    End Sub
    Private Sub ucSalesSummaryChannelPerCustomer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Loadyear()
        ApplyGridTheme(Me.DataGridView1)
    End Sub

    Private Sub MenuButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click, btnExport.Click, btnClose.Click
        If sender Is btnPrintPreview Then
            UCSTD_Sales_Per_Product_MTD_QTD_YTD.CheckForIllegalCrossThreadCalls = False
            ProgressBar1.Visible = True
            Timer1.Enabled = True

            'LoadData()
            ThreadLoadData = New Thread(New ThreadStart(AddressOf LoadData))
            ThreadLoadData.Start()
        ElseIf sender Is btnExport Then
            ProgressBar1.Visible = True
            Timer1.Enabled = True
            Label5.Text = "Generating Report . . ."
            Month = cmbMonthFrom.Text
            Year = cmbYearFrom.Text
            ThreadGenerateReport = New Thread(New ThreadStart(AddressOf Printing))
            ThreadGenerateReport.Start()
        ElseIf sender Is btnClose Then
            Close()
        End If
    End Sub

    Private Sub Loadyear()
        dv.Table = GetRecords("SELECT DISTINCT CAYR FROM CALENDAR WHERE COMID='" & GetDefaultCompany() & "'", "Year Table")
        For i As Integer = 0 To dv.Table.Rows.Count - 1
            cmbYearFrom.Items.Add(dv.Table.Rows(i)(0))
            cmbYearTo.Items.Add(dv.Table.Rows(i)(0))
        Next
    End Sub

    Private Sub LoadMonth()
        dv.Table = GetRecords("SELECT DISTINCT CAPN FROM CALENDAR WHERE COMID='" & GetDefaultCompany() & "' AND CAYR=" & cmbYearFrom.Text, "MOnth Table")
        cmbMonthFrom.Items.Clear()
        For i As Integer = 0 To dv.Table.Rows.Count - 1
            cmbMonthFrom.Items.Add(dv.Table.Rows(i)(0))
            cmbMonthto.Items.Add(dv.Table.Rows(i)(0))
        Next
    End Sub

    Private Sub cmbYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYearFrom.SelectedIndexChanged
        LoadMonth()
    End Sub

    Private Sub LoadData()
        UCReportItemSalesWithTarget.CheckForIllegalCrossThreadCalls = False
        Dim PrevComid As String = String.Empty
        Dim Rw As Integer = 0
        dv.Table = GetRecords("EXEC uspReportItemSalesWithTarget @TerrCd ='" & txtTerritory.Tag & "', @YearFrom =" & cmbYearFrom.Text & ", @YearTo=" & cmbYearTo.Text  & ",@MonthFrom =" & cmbMonthFrom.Text & ", @MonthTo=" & cmbMonthTo.Text )
        Label5.Text = "Generating Preview . . ."

        DataGridView1.DataSource = dv
        DataGridView1.Columns.RemoveAt(0)
        'DataGridView1.Rows.Add 

        'For c As Integer = 1 to DataGridView1.Columns.Count -1
        '    For r As Integer = 1 to DataGridView1.Rows.Count -2
        '        Dim row As DataGridViewRow = DataGridView1.Rows(r)
        '        row.Cells(DataGridView1.Rows.Count-1).Value = 5
        '    Next r
        'Next c



        'Cleardatagrid()
'        For Each ColumnHeader As DataColumn In dv.Table.Columns
'            Me.DataGridView1.Columns.Add(ColumnHeader.ColumnName, ColumnHeader.ColumnName)
'        Next
'        'dv.Table.Rows.Add(dv.Table.Rows)
'        For r As Integer = 0 To dv.Table.Rows.Count - 1
'            'If PrevComid <> String.Empty Then
'            '    If PrevComid <> IIf(IsDBNull(dv.Table.Rows(r)(0)), "", dv.Table.Rows(r)(0)) Then
'            '        DataGridView1.Rows.Add()
'            '        DataGridView1.Rows(r + Rw).Cells(0).Value = "TOTAL " & PrevComid & ":>>"
'            '        DataGridView1.Rows(r + Rw).Cells(4).Value = dv.Table.Compute("Sum([NET QUANTITY])", "CHANNEL='" & PrevComid & "'")
'            '        DataGridView1.Rows(r + Rw).Cells(5).Value = dv.Table.Compute("Sum([NET Value])", "CHANNEL='" & PrevComid & "'")
'            '        Rw = Rw + 3
'            '        DataGridView1.Rows.Add()
'            '        DataGridView1.Rows.Add()
'            '    End If
'            'End If
'            DataGridView1.Rows.Add()
'            For c As Integer = 0 To dv.Table.Columns.Count - 1
'                'If PrevComid <> IIf(IsDBNull(dv.Table.Rows(r)(0)), "", dv.Table.Rows(r)(0)) Then
'                '    DataGridView1.Rows(r + Rw).Cells(c).Value = dv.Table.Rows(r)(c)
'                'Else
'                '    DataGridView1.Rows(r + Rw).Cells(c).Value = dv.Table.Rows(r)(c)
'                'End If
'                'If c > 0 Then
'                    'DataGridView1.Rows(r + Rw).Cells(c).Value = dv.Table.Rows(r)(c)
'DataGridView1.Rows(r ).Cells(c).Value = dv.Table.Rows(r)(c)
'                'Else
'                '    If PrevComid <> IIf(IsDBNull(dv.Table.Rows(r)(0)), "", dv.Table.Rows(r)(0)) Then
'                '        DataGridView1.Rows(r + Rw).Cells(c).Value = dv.Table.Rows(r)(c)
'                '    Else
'                '        DataGridView1.Rows(r + Rw).Cells(c).Value = ""
'                '    End If
'                'End If

'            Next
'            PrevComid = dv.Table.Rows(r)(0)
'            Rw = Rw - 2
'        Next
    End Sub

    Private Sub Cleardatagrid()
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
    End Sub

    Private Sub Close()
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub Printing()
        Try

            ThreadGenerateReportIsActive = 1
            _PrintToExcel = New CReportPrint
            Dim RowX As Integer = 3
            Dim ColY As Integer = 1
            Dim AreaLength As Integer = DataGridView1.Columns.Count
            Dim AreaHeight As Integer = DataGridView1.Rows.Count
            Dim CountRecord As Integer = DataGridView1.Rows.Count


            '_PrintToExcel.OpenExcel()

            PrintHeader(RowX, ColY, AreaLength)

            PrintDetails(RowX, ColY, AreaHeight, AreaLength, CountRecord)

            PrintFooter(RowX, ColY)
            ThreadGenerateReportIsActive = 0

        Catch ex As Exception
            ThreadGenerateReportIsActive = 0
            MsgBox(ex.Message)
        End Try
    End Sub


#Region "Excel Printing"

    Public Sub PrintDetails(ByVal StartRowX As Integer, ByVal StartColY As Integer, ByVal AreaH As Integer, ByVal AreaL As Integer, ByVal DetailCount As Integer) Implements ExcelPrint.PrintDetails

        StartRowX = StartRowX + 4
        'Try
        _PrintToExcel.BackColor(StartRowX, StartColY, StartRowX, AreaL, CEnumeration.ColorIndex.Aqua)
        _PrintToExcel.DetailsArea(StartRowX, StartColY, AreaH + StartRowX, AreaL)
        'print Column Header


        For Each ColumnHeader As DataGridViewColumn In DataGridView1.Columns
            _PrintToExcel.PrintText(ColumnHeader.Name, StartRowX, ColumnHeader.Index + 1, , , True, CEnumeration.ColorIndex.OliveGreen)
        Next
        'end Column Header
        'Print Details-----

        For ir As Integer = 0 To DataGridView1.Rows.Count - 1

            For ic As Integer = 0 To DataGridView1.Columns.Count - 1

                If IsNumeric(IIf(DataGridView1.Rows(ir).Cells(ic).Value Is DBNull.Value, "0.00", DataGridView1.Rows(ir).Cells(ic).Value)) Then

                    _PrintToExcel.PrintText(IIf(DataGridView1.Rows(ir).Cells(ic).Value Is DBNull.Value, "0.00", DataGridView1.Rows(ir).Cells(ic).Value), ir + (StartRowX + 1), ic + StartColY, , , , , Excel.XlHAlign.xlHAlignRight)
                Else
                    _PrintToExcel.PrintText(IIf(DataGridView1.Rows(ir).Cells(ic).Value Is DBNull.Value, "0.00", DataGridView1.Rows(ir).Cells(ic).Value), ir + (StartRowX + 1), ic + StartColY)
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
        _PrintToExcel.PrintText(Now.Date, StartRowX, 2)
        _PrintToExcel.PrintText("Run Time : ", StartRowX + 1, 1, , 9, FontStyle.Bold)
        _PrintToExcel.PrintText(Format(Now, "hh:mm:ss"), StartRowX + 1, 2)
        _PrintToExcel.PrintText("Report Date : ", StartRowX + 2, 1, , 9, FontStyle.Bold)
        '_PrintToExcel.PrintText(Format(month, "mmmm") & " - " & year, StartRowX + 2, 2)
        _PrintToExcel.PrintText(cmbMonthFrom.Text & "  " & cmbYearFrom.Text, StartRowX + 2, 2)

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

        If ThreadLoadDataIsActive = 0 And ThreadGenerateReportIsActive = 0 Then
            Label5.Text = "Refreshing . . . "
            Timer2.Enabled = True
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If TimerCounter = 5 Then
            Timer1.Enabled = False
            ProgressBar1.Visible = False
            ProgressBar1.Value = 0
            Label5.Text = ""
            Timer1.Enabled = False
            Me.Enabled = True
            TimerCounter = 0
            Timer2.Enabled = False
        Else
            TimerCounter = TimerCounter + 1
        End If
    End Sub

    Private Sub lnkClear_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkClear.LinkClicked
        txtTerritory.Tag = Nothing 
    lnkTerritory.Tag = Nothing 
    End Sub
End Class
