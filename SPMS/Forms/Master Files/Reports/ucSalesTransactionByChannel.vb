Imports SPMSOPCI.ConnectionModule
Imports System.Data
Imports System.Data.SqlClient

Imports System.Threading
Imports Microsoft.Office.Interop
'Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Public Class ucSalesTransactionByChannel
    Dim ThreadLoadData As Thread '(New ThreadStart(AddressOf LoadData))
    Dim ThreadGenerateReport As Thread '(New ThreadStart(AddressOf Printing ))

    Private bindingSource1 As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Private table As New DataTable()
    Private m_Err As New ErrorProvider
    Dim TimerCounter As Integer = 0
    Dim ThreadLoadDataIsActive As Integer = 0, ThreadGenerateReportIsActive As Integer = 0

    Private Sub GetData(ByVal selectCommand As String)

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
            Me.dataAdapter = New SqlDataAdapter(selectCommand, connectionString)

            ' Create a command builder to generate SQL update, insert, and
            ' delete commands based on selectCommand. These are used to
            ' update the database.
            Dim commandBuilder As New SqlCommandBuilder(Me.dataAdapter)

            ' Populate a new data table and bind it to the BindingSource.
            ' Dim table As New DataTable()
            SPMSConn.CommandTimeout = 0
            table = New DataTable
            table.Locale = System.Globalization.CultureInfo.InvariantCulture
            Me.dataAdapter.Fill(table)
            Me.bindingSource1.DataSource = table

            ' Right Align double data types
            Dim style As DataGridViewCellStyle
            Dim i As Integer
            Dim j As Decimal
            style = New DataGridViewCellStyle()
            style.Alignment = DataGridViewContentAlignment.MiddleRight
            i = 0
            While i < DataGridView1.ColumnCount
                If (DataGridView1.Columns.Item(i).ValueType Is j.GetType) Then
                    DataGridView1.Columns.Item(i).DefaultCellStyle = style
                End If
                i = i + 1
            End While


        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Function ValidateData() As Boolean
        Dim m_HasError As Boolean = False
        m_Err.Clear()
        If cmbChannel.Text = String.Empty Then
            m_Err.SetError(cmbChannel, "Channel is required")
            m_HasError = True
        End If
        Return Not m_HasError
    End Function
    Private Sub LoadData1()
        ThreadLoadDataIsActive = 1
        ucSalesTransactionByChannel.CheckForIllegalCrossThreadCalls = False
        Label7.Text = "Generating Preview . . ."

        Connect()
        Dim cmd As New SqlCommand("uspSPMSGPISalesTransactionListForThePeriodOFByChannel", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@Channel", cmbChannel.Text)
        cmd.Parameters.AddWithValue("@BeginMonth", cmbStartMonth.Text)
        cmd.Parameters.AddWithValue("@BeginYear", cmbStartYear.Text)
        cmd.Parameters.AddWithValue("@EndMonth", cmbEndMonth.Text)
        cmd.Parameters.AddWithValue("@EndYear", cmbEndYear.Text)

        Me.dataAdapter = New SqlDataAdapter(cmd)
        Dim sqlCommandBluider As New SqlCommandBuilder(dataAdapter)
        table = New DataTable
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        Me.dataAdapter.Fill(table)
        Me.bindingSource1.DataSource = table

        Dim style As DataGridViewCellStyle
        Dim i As Integer
        Dim j As Decimal
        style = New DataGridViewCellStyle()
        style.Alignment = DataGridViewContentAlignment.MiddleRight
        i = 0
        While i < DataGridView1.ColumnCount
            If (DataGridView1.Columns.Item(i).ValueType Is j.GetType) Then
                DataGridView1.Columns.Item(i).DefaultCellStyle = style
            End If
            i = i + 1
        End While
        ThreadLoadDataIsActive = 0
    End Sub
    Private Sub LoadData2()
        ThreadLoadDataIsActive = 1
        ucSalesTransactionByChannel.CheckForIllegalCrossThreadCalls = False
        Label7.Text = "Generating Preview . . ."


        Connect()
        Dim cmd As New SqlCommand("uspSPMSGPISalesTransactionListForThePeriodOfByChannelwithExclusion", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@Channel", cmbChannel.Text)
        cmd.Parameters.AddWithValue("@BeginMonth", cmbStartMonth.Text)
        cmd.Parameters.AddWithValue("@BeginYear", cmbStartYear.Text)
        cmd.Parameters.AddWithValue("@EndMonth", cmbEndMonth.Text)
        cmd.Parameters.AddWithValue("@EndYear", cmbEndYear.Text)

        Me.dataAdapter = New SqlDataAdapter(cmd)
        Dim sqlCommandBluider As New SqlCommandBuilder(dataAdapter)
        table = New DataTable
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        Me.dataAdapter.Fill(table)
        Me.bindingSource1.DataSource = table

        Dim style As DataGridViewCellStyle
        Dim i As Integer
        Dim j As Decimal
        style = New DataGridViewCellStyle()
        style.Alignment = DataGridViewContentAlignment.MiddleRight
        i = 0
        While i < DataGridView1.ColumnCount
            If (DataGridView1.Columns.Item(i).ValueType Is j.GetType) Then
                DataGridView1.Columns.Item(i).DefaultCellStyle = style
            End If
            i = i + 1
        End While


        ThreadLoadDataIsActive = 0

    End Sub
    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        ProgressBar1.Visible = True
        Timer1.Enabled = True
        Me.DataGridView1.ClearSelection()
        Me.DataGridView1.DataSource = Me.bindingSource1
        If ValidateData() Then
            If Not chkExclude.Checked Then
                ThreadLoadData = New Thread(New ThreadStart(AddressOf LoadData1))
                ThreadLoadData.Start()
            Else
                ThreadLoadData = New Thread(New ThreadStart(AddressOf LoadData2))
                ThreadLoadData.Start()
            End If
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

    Private Sub UCReportMasterFileDownload_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(DataGridView1)
        PopulateComboBox()
        ChannelCode()
        m_Err.Clear()
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


        objSheet.Name = "Sales Transaction By Channel"




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
        objBook.SaveAs("Sales Transaction By Channel", Excel.XlFileFormat.xlWorkbookNormal, System.Reflection.Missing.Value, System.Reflection.Missing.Value, True, False, Excel.XlSaveAsAccessMode.xlNoChange, False, False, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
        Exit Sub
errHandler:
        ShowInformation(Err.Description, "")
        objExcel.Quit()
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
    End Sub
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
        End If
        rs.Open("SELECT DISTINCT CAYR FROM CALENDAR WHERE COMID = '" & ConnectionModule.GetDefaultCompany & "' " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs
    End Function
    Private Function ChannelCode() As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        Dim j
        rs.Open("SELECT DISTINCT DISTCOMID FROM DISTRIBUTOR WHERE DLTFLG = '" & "0" & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        For j = 1 To rs.RecordCount
            cmbChannel.Items.Add(rs.Fields("DISTCOMID").Value)
            rs.MoveNext()
        Next
        Return rs
    End Function
    Private Sub PopulateComboBox()
        Dim rs As New ADODB.Recordset
        cmbStartYear.Items.Clear()
        cmbEndYear.Items.Clear()
        cmbStartMonth.Items.Clear()
        cmbEndMonth.Items.Clear()
        'for the year   
        rs = RsGpiCalendarYear()
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbStartYear.Items.Add(rs.Fields("cayr").Value)
                cmbEndYear.Items.Add(rs.Fields("cayr").Value)
                rs.MoveNext()
            Next
        End If
    End Sub

    Private Sub comboSelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStartYear.SelectedIndexChanged, cmbEndYear.SelectedIndexChanged
        Dim rs As New ADODB.Recordset

        If sender Is cmbStartYear Then
            cmbStartMonth.Items.Clear()
            rs = RsGpiCalendarMonth("CAYR = '" & cmbStartYear.Text & "' ")
            If rs.RecordCount > 0 Then
                For i As Integer = 1 To rs.RecordCount
                    cmbStartMonth.Items.Add(rs.Fields("CAPN").Value)
                    rs.MoveNext()
                Next
            End If
        ElseIf sender Is cmbEndYear Then
            cmbEndMonth.Items.Clear()
            rs = RsGpiCalendarMonth("CAYR = '" & cmbEndYear.Text & "' ")
            If rs.RecordCount > 0 Then
                For i As Integer = 1 To rs.RecordCount
                    cmbEndMonth.Items.Add(rs.Fields("CAPN").Value)
                    rs.MoveNext()
                Next
            End If
        End If
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
