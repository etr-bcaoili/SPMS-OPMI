Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Threading


Public Class UCSTD_Sales_Per_Product_MTD_QTD_YTD
    Implements ExcelPrint

    Dim _PrintToExcel As New CReportPrint
    Dim ThreadLoadData As New Thread(New ThreadStart(AddressOf LoadData))
    Dim ThreadGenerateReport As New Thread(New ThreadStart(AddressOf Printing))
    Dim dt As New DataTable
    Dim dv As New DataView
    Dim Month As String
    Dim Year As String
    Dim TimerCounter As Integer = 0
    Dim ThreadLoadDataIsActive As Integer = 0, ThreadGenerateReportIsActive As Integer = 0


    Private Sub UCSTD_Sales_Per_Product_MTD_QTD_YTD_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadYear()
        ApplyGridTheme(Me.DataGridView1)
        'Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoResizeColumns()

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
        '_PrintToExcel.PrintText(Format(Month, "mmmm") & " - " & Year, StartRowX + 2, 2)
        _PrintToExcel.PrintText(cmbMonth.Text & "  " & cmbYear.Text, StartRowX + 2, 2)


        _PrintToExcel.BackColor(StartRowX + 3, 1, StartRowX + 3, AreaL, CEnumeration.ColorIndex.No20)
        _PrintToExcel.PrintText(Label1.Text, StartRowX + 3, 5, , 11, FontStyle.Bold, CEnumeration.ColorIndex.DarkBlue)

        _PrintToExcel.MergeCell(StartRowX + 3, 1, StartRowX + 3, AreaL)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
#End Region

    Private Sub LoadYear()
        dt = GetRecords("Select DISTINCT CAYR FROM CALENDAR WHERE COMID='" & GetDefaultCompany() & "'")

        For I As Integer = 0 To dt.Rows.Count - 1
            cmbYear.Items.Add(dt.Rows(I)(0))
        Next
    End Sub

    Private Sub LoadMonth()
        dt = GetRecords("Select DISTINCT CAPN FROM CALENDAR WHERE CAYR='" & cmbYear.Text & "'")
        cmbMonth.Items.Clear()
        For I As Integer = 0 To dt.Rows.Count - 1
            cmbMonth.Items.Add(dt.Rows(I)(0))
        Next
    End Sub

    Private Sub LoadDistrict()

        dt = GetRecords("SELECT DISTINCT DISTRCTCD,DISTRCTNAME FROM CUST_DIV_ITEM_SALES WHERE CUTYEAR=" & IIf(cmbYear.Text = "", 0, cmbYear.Text) & " AND CUTMO=" & IIf(cmbMonth.Text = "", 0, cmbMonth.Text) & " Order by DISTRCTCD")
        cmbDistrictCode.Items.Clear()
        cmbDistrictDesc.Items.Clear()
        For I As Integer = 0 To dt.Rows.Count - 1
            cmbDistrictCode.Items.Add(dt.Rows(I)(0))
            cmbDistrictDesc.Items.Add(dt.Rows(I)(1))
        Next
    End Sub

    Private Sub cmbYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbYear.SelectedIndexChanged
        LoadMonth()
        LoadDistrict()
    End Sub

    Private Sub cmbMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedIndexChanged
        LoadDistrict()
    End Sub

    Private Sub cmbDistrictCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDistrictCode.SelectedIndexChanged
        cmbDistrictDesc.SelectedIndex = cmbDistrictCode.SelectedIndex
    End Sub

    Private Sub cmbDistrictDesc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDistrictDesc.SelectedIndexChanged
        cmbDistrictCode.SelectedIndex = cmbDistrictDesc.SelectedIndex
    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        UCSTD_Sales_Per_Product_MTD_QTD_YTD.CheckForIllegalCrossThreadCalls = False
        ProgressBar1.Visible = True
        Timer1.Enabled = True

        'LoadData()
        ThreadLoadData = New Thread(New ThreadStart(AddressOf LoadData))
        ThreadLoadData.Start()
    End Sub

    Private Sub LoadData()
        Try


            ThreadLoadDataIsActive = 1
            UCSTD_Sales_Per_Product_MTD_QTD_YTD.CheckForIllegalCrossThreadCalls = False

            Label5.Text = "Generating Preview . . ."

            Me.DataGridView1.DataSource = GetRecords("EXEC [uspSTDSalesPerProduct2]  @Month = " & cmbMonth.Text & ", @Year = " & cmbYear.Text & ", @DISTRICTCD = '" & cmbDistrictCode.Text & "'")
            'dt.Columns.RemoveAt(0)

            Me.DataGridView1.Columns(0).Visible = False
            'Me.DataGridView1.Rows.Clear()
            'Me.DataGridView1.Columns.Clear()
            'ClearDatagridView(Me.DataGridView1)
            'Dim col1 As Integer = 0
            'For Each ColumnHeader As System.Data.DataColumn In dv.Table.Columns
            '    Me.DataGridView1.Columns.Add(ColumnHeader.ColumnName, ColumnHeader.ColumnName)
            '    Me.DataGridView1.Columns(ColumnHeader.ColumnName).SortMode = DataGridViewColumnSortMode.NotSortable
            '    If col1 = 0 Then
            '        Me.DataGridView1.Columns(ColumnHeader.ColumnName).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
            '    Else
            '        Me.DataGridView1.Columns(ColumnHeader.ColumnName).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
            '    End If
            '    col1 = col1 + 1
            'Next

            'For r As Integer = 0 To dv.Table.Rows.Count - 1
            '    DataGridView1.Rows.Add()
            '    For c As Integer = 0 To dv.Table.Columns.Count - 1
            '        DataGridView1.Rows(r).Cells(c).Value = dv.Table.Rows(r)(c)
            '        'DataGridView1.Rows(r).Cells(c).Style = DataGridViewTriState.True
            '    Next
            'Next
            ThreadLoadDataIsActive = 0
        Catch ex As Exception
            ThreadLoadDataIsActive = 0
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearDatagridView(ByVal DataGrid As DataGridView)
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        ProgressBar1.Visible = True
        Timer1.Enabled = True
        Label5.Text = "Generating Report . . ."
        Month = cmbMonth.Text
        Year = cmbYear.Text
        ThreadGenerateReport = New Thread(New ThreadStart(AddressOf Printing))
        ThreadGenerateReport.Start()

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

    Private Sub DataGridView1_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        Dim a
        a = 0
        'Me.DataGridView1.Sort = "me.da"
        Exit Sub
    End Sub

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

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Sorted
        Exit Sub
    End Sub
End Class
