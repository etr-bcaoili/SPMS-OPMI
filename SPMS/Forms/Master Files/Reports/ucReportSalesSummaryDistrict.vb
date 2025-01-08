Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Threading

Public Class ucReportSalesSummaryDistrict
    Implements ExcelPrint
    Dim _PrintToExcel As New CReportPrint
    Dim ThreadLoadData As New Thread(New ThreadStart(AddressOf LoadData))
    Dim ThreadGenerateReport As New Thread(New ThreadStart(AddressOf Printing))
    Dim dv As New DataView
    Dim Month As String
    Dim Year As String
    Dim TimerCounter As Integer = 0
    Dim ThreadLoadDataIsActive As Integer = 0, ThreadGenerateReportIsActive As Integer = 0

    Private Sub MenuButton_Click(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click, btnExport.Click, btnClose.Click
        If Sender Is btnPrintPreview Then
            If ValidateFilterViewing() = True Then
                ucReportSalesSummaryDistrict.CheckForIllegalCrossThreadCalls = False
                ProgressBar1.Visible = True
                Timer1.Enabled = True

                'LoadData()
                ThreadLoadData = New Thread(New ThreadStart(AddressOf LoadData))
                ThreadLoadData.Start()
            End If
        ElseIf Sender Is btnExport Then
            ProgressBar1.Visible = True
            Timer1.Enabled = True
            Label6.Text = "Generating Report . . ."
            Month = cmbMonth.Text
            Year = cmbYear.Text
            ThreadGenerateReport = New Thread(New ThreadStart(AddressOf Printing))
            ThreadGenerateReport.Start()
        ElseIf Sender Is btnClose Then
            Close()
        End If
    End Sub

    Private Sub LoadYear()
        dv.Table = GetRecords("SELECT DISTINCT CAYR FROM CALENDAR WHERE COMID='" & GetDefaultCompany() & "'")
        For i As Integer = 0 To dv.Table.Rows.Count - 1
            cmbYear.Items.Add(dv.Table.Rows(i)(0))
        Next
    End Sub

    Private Sub LoadDistrict()
        cmbDistrictCode.Items.Clear()
        cmbDistrictName.Items.Clear()
        dv.Table = GetRecords("SELECT DISTINCT DISTRCTCD,DISTRCTNAME  FROM cust_div_item_sales WHERE cutyear =" & cmbYear.Text, "Year table")
        For i As Integer = 0 To dv.Table.Rows.Count - 1
            cmbDistrictCode.Items.Add(dv.Table.Rows(i)(0))
            cmbDistrictName.Items.Add(dv.Table.Rows(i)(1))
        Next
    End Sub

    Private Sub LoadMonth()
        cmbMonth.Items.Clear()
        dv.Table = GetRecords("SELECT DISTINCT CAPN FROM CALENDAR WHERE COMID='" & GetDefaultCompany() & "' AND CAYR=" & cmbYear.Text, "Month Table")
        For i As Integer = 0 To dv.Table.Rows.Count - 1
            cmbMonth.Items.Add(dv.Table.Rows(i)(0))
        Next
    End Sub

    Private Sub ucReportSalesSummaryDistrict_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(Me.DataGridView1)
        LoadYear()
    End Sub

    Private Sub cmbDistrictCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDistrictCode.SelectedIndexChanged
        cmbDistrictName.SelectedIndex = cmbDistrictCode.SelectedIndex
    End Sub

    Private Sub cmbDistrictName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDistrictName.SelectedIndexChanged
        cmbDistrictCode.SelectedIndex = cmbDistrictName.SelectedIndex
    End Sub

    Private Sub cmbYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.SelectedIndexChanged
        LoadMonth()
        LoadDistrict()
    End Sub

    Private Sub LoadData()

        'Dim cmd As New SqlCommand("EXEC [uspSUMMARYDISTRICT] @YEAR = " & cmbYear.Text & ", @MONTH=" & cmbMonth.Text & ", @DISTRICTCODE ='" & cmbDistrictCode.Text & "'", SPMSConn2)
        'cmd.CommandTimeout = 0
        'cmd.CommandType = CommandType.Text
        'Dim da As New SqlDataAdapter(cmd)
        'da.Fill(dv.Table)
        dv.Table = GetRecords("EXEC [uspSUMMARYDISTRICT] @YEAR = " & cmbYear.Text & ", @MONTH=" & cmbMonth.Text & ", @DISTRICTCODE ='" & cmbDistrictCode.Text & "'", "Summary District")

        Label6.Text = "Generating Preview . . ."
        ClearDatagrid()
        For Each ColumnHeader As DataColumn In dv.Table.Columns
            DataGridView1.Columns.Add(ColumnHeader.ColumnName, ColumnHeader.ColumnName)
        Next
        For r As Integer = 0 To dv.Table.Rows.Count - 1
            DataGridView1.Rows.Add()
            For c As Integer = 0 To dv.Table.Columns.Count - 1
                If c > 2 Then
                    DataGridView1.Rows(r).Cells(c).Style.Alignment = DataGridViewContentAlignment.BottomRight
                    DataGridView1.Rows(r).Cells(c).Value = CType(dv.Table.Rows(r)(c), Decimal).ToString("###,###,###.00")
                Else
                    DataGridView1.Rows(r).Cells(c).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                    DataGridView1.Rows(r).Cells(c).Value = dv.Table.Rows(r)(c)
                End If

            Next
        Next
        DataGridView1.Rows.Add()
        DataGridView1.Rows.Add()
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(0).Value = "TOTAL : >>"
        Dim TNetSales As Decimal, TTargetValue As Decimal

        TNetSales = dv.Table.Compute("SUM([NET SALES])", "")
        TTargetValue = dv.Table.Compute("SUM([TARGET VALUE])", "")
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(3).Style.Alignment = DataGridViewContentAlignment.BottomRight
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(3).Value = TNetSales.ToString("###,###,###.00")

        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(4).Style.Alignment = DataGridViewContentAlignment.BottomRight
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(4).Value = TTargetValue.ToString("###,###,###.00")

        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(5).Style.Alignment = DataGridViewContentAlignment.BottomRight
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(5).Value = ((TNetSales / TTargetValue) * 100).ToString("###,###,###.00")
    End Sub

    Private Sub ClearDatagrid()
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
    End Sub

    Private Function ValidateFilterViewing() As Boolean
        If Len(Trim(cmbYear.Text)) = 0 Or Len(Trim(cmbMonth.Text)) = 0 Or Len(Trim(cmbDistrictCode.Text)) = 0 Then
            MessageBox.Show("Complete filter for viewing.", "Preview", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3)
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub Close()
        Dim m_tabPage As TabPage = Me.Parent
        CType(m_tabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_tabPage)
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
        _PrintToExcel.PrintText(cmbMonth.Text & "  " & cmbYear.Text, StartRowX + 2, 2)

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
