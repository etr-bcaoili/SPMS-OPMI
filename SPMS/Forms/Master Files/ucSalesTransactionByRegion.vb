Imports SPMSOPCI.ConnectionModule
Imports System.Data
Imports System.Data.SqlClient


Imports Microsoft.Office.Interop
'Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Public Class ucSalesTransactionByRegion

    Private bindingSource1 As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Private table As New DataTable()
    Private c_RegionCode As String
    Private m_Err As New ErrorProvider
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
        If cmbRegion.Text = String.Empty Then
            m_Err.SetError(cmbRegion, "Region is required")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        Me.DataGridView1.ClearSelection()
        'Me.Label4.Text = "Sales Report for Current Month"
        Me.DataGridView1.DataSource = Me.bindingSource1

        If ValidateData() Then
            If Not chkExclude.Checked Then
                GetData(" EXECUTE uspSPMSGPISalesTransactionListForThePeriodOFByRegion @RegionCode='" & c_RegionCode & "', @BeginMonth=" & cmbStartMonth.Text & ",  @BeginYear=" & cmbStartYear.Text & ", @EndMonth=" & cmbEndMonth.Text & ",  @EndYear= " & cmbEndYear.Text)
            Else
                GetData(" EXECUTE uspSPMSGPISalesTransactionListForThePeriodOfByRegionWithExclusion @RegionCode='" & c_RegionCode & "', @BeginMonth=" & cmbStartMonth.Text & ",  @BeginYear=" & cmbStartYear.Text & ", @EndMonth=" & cmbEndMonth.Text & ",  @EndYear= " & cmbEndYear.Text)
            End If
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

    Private Sub UCReportMasterFileDownload_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(DataGridView1)
        PopulateComboBox()
        RegionCode()
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


        objSheet.Name = "Sales Transaction By Region"




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
        objBook.SaveAs("Sales Transaction By Region", Excel.XlFileFormat.xlWorkbookNormal, System.Reflection.Missing.Value, System.Reflection.Missing.Value, True, False, Excel.XlSaveAsAccessMode.xlNoChange, False, False, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
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
    Private Function RegionCode() As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        Dim j
        rs.Open("SELECT DISTINCT STREGNAME FROM STREGION WHERE DLTFLG = '" & "0" & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        For j = 1 To rs.RecordCount
            cmbRegion.Items.Add(rs.Fields("STREGNAME").Value)
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

    Private Sub cmbRegion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegion.SelectedIndexChanged
        Dim rs As New ADODB.Recordset

        rs.Open("SELECT DISTINCT STREGCD FROM STREGION WHERE STREGNAME = '" & cmbRegion.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        c_RegionCode = rs.Fields("STREGCD").Value


    End Sub
End Class
