
Imports SPMSOPCI.ConnectionModule
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

Public Class UCGrossProfitAnalysis
    Private m_RsMonth As New ADODB.Recordset
    Private m_DisCode As String = String.Empty
    Private bindingSource1 As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Private table As New DataTable()

    Private m_Err As New ErrorProvider
    Private Sub LoadYear()
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT DISTINCT CAYR FROM CALENDAR  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        cboCalendarYear.Items.Clear()
        For m As Integer = 0 To rs.RecordCount - 1
            cboCalendarYear.Items.Add(rs.Fields("CAYR").Value)
            rs.MoveNext()
        Next
        'Dim yr As Integer = Now.Year()
        'cboCalendarYear.Items.Clear()
        'For m As Integer = yr - 10 To yr + 10
        '    cboCalendarYear.Items.Add(m)
        'Next
    End Sub

    Private Sub LoadMonth(ByVal DistributorCode As String, ByVal Year As String)

        If m_RsMonth.State = 1 Then m_RsMonth.Close()
        m_RsMonth.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsMonth.Open("SELECT * FROM Calendar WHERE COMID = '" & DistributorCode & "' AND CAYR = '" & Year & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsMonth.RecordCount > 0 Then
            cboMonth.Items.Clear()
            txtMonthDescription.Text = ""
            For m As Integer = 0 To m_RsMonth.RecordCount - 1
                cboMonth.Items.Add(m_RsMonth.Fields("CAPN").Value)
                m_RsMonth.MoveNext()
            Next
        End If

    End Sub

    Private Sub UCGrossProfitAnalysis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadYear()
        m_DisCode = GetDefaultCompany()
        ApplyGridTheme(DataGridView1)
    End Sub

    Private Sub cboCalendarYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCalendarYear.SelectedIndexChanged
        If cboCalendarYear.SelectedIndex <> -1 Then
            LoadMonth(m_DisCode, cboCalendarYear.Text)
        End If
    End Sub

    Private Sub cboMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMonth.SelectedIndexChanged
        GetMonthDescription(m_DisCode, cboCalendarYear.Text, cboMonth.Text)
    End Sub

    Private Sub GetMonthDescription(ByVal DistributorCode As String, ByVal Year As String, ByVal MonthCode As String)
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT MonthDescription FROM Calendar Where COMID = '" & DistributorCode & "' AND CAYR = '" & Year & "'   AND CAPN = '" & MonthCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            txtMonthDescription.Text = rs.Fields("MonthDescription").Value
            '   GetBatchNo(DistributorCode, MonthCode, Year)
        Else
            txtMonthDescription.Text = ""
        End If

    End Sub
    Private Sub RefreshData()
        Me.DataGridView1.ClearSelection()
        'Me.Label4.Text = "Sales Report for Current Month"
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.ClearSelection()

        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData()

    End Sub
    Private Sub GetData()

        Try
            ' Specify a connection string. Replace the given value with a 
            ' valid connection string for a Northwind SQL Server sample
            ' database accessible to your system.
            Dim connectionString As String = ""

            If SqlConnectionExists() = True Then
                connectionString = GetSqlconnectionPath()

            Else
                connectionString = "data source=192.168.0.2; initial catalog=SPMS; user id=sa; password=;"
            End If

            ' Create a new data adapter based on the specified query.

            Connect()
            Dim cmd As New SqlCommand("uspGrossProfitAnalysis", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@CutMo", cboMonth.Text)
            cmd.Parameters.AddWithValue("@CutYear", cboCalendarYear.Text)
            cmd.CommandTimeout = 0
            table = New DataTable

            Dim da As New SqlDataAdapter(cmd)
            da.Fill(table)

            Me.dataAdapter = New SqlDataAdapter(cmd)

            table.Locale = System.Globalization.CultureInfo.InvariantCulture

            Me.bindingSource1.DataSource = table
            Disconnect()
            ' Right Align double data types
            Dim style As DataGridViewCellStyle
            Dim i As Integer
            Dim j As Decimal
            Dim k As Double
            style = New DataGridViewCellStyle()
            style.Alignment = DataGridViewContentAlignment.MiddleRight
            i = 0
            While i < DataGridView1.ColumnCount
                If (DataGridView1.Columns.Item(i).ValueType Is j.GetType) Or (DataGridView1.Columns.Item(i).ValueType Is k.GetType) Then
                    DataGridView1.Columns.Item(i).DefaultCellStyle = style

                End If
                i = i + 1
            End While


            'For m As Integer = 0 To DataGridView1.Rows.Count - 1
            '    Dim row As DataGridViewRow = DataGridView1.Rows(m)

            '    For l As Integer = 0 To DataGridView1.Columns.Count - 1
            '        Dim col As DataGridViewColumn = DataGridView1.Columns(l)
            '        If IsNumeric(row.Cells(l).Value) Then
            '            Dim val As Decimal = row.Cells(l).Value
            '            row.Cells(l).Value = val.ToString("#,##0.0000")
            '        End If
            '    Next

            'Next





        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        RefreshData()
    End Sub
    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
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


        objSheet.Name = "GPA"




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
        objBook.SaveAs("Gross Profit Analysis", Excel.XlFileFormat.xlWorkbookNormal, System.Reflection.Missing.Value, System.Reflection.Missing.Value, True, False, Excel.XlSaveAsAccessMode.xlNoChange, False, False, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
        Exit Sub
errHandler:

        objExcel.Quit()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

End Class
