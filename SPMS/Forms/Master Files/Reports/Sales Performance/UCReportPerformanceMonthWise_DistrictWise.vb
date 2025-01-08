Imports SPMSOPCI.ConnectionModule
Imports System.Data
Imports System.Data.SqlClient

Imports System.Net.Mail
'Imports System.Web.mail

Imports Microsoft.Office.Interop
'Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports System.Threading

Public Class UCReportPerformanceMonthWise_DistrictWise
    Dim ThreadLoadData As Thread
    Dim ThreadGenerateReport As Thread
    Private bindingSource1 As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Private table As New DataTable()
    Private m_Err As New ErrorProvider
    Dim TimerCounter As Integer = 0
    Dim dv As New DataView
    Dim ThreadLoadDataIsActive As Integer = 0, ThreaGenerateReportIsactive As Integer = 0
    Private Function RsLockedCompany(Optional ByVal Filter As String = "", Optional ByVal Orderby As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " where " & Filter
        End If
        If Orderby <> "" Then
            Orderby = " order by " & Orderby

        End If
        rs.Open("select * from company" & Filter & Orderby, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function

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
            'Me.dataAdapter = New SqlDataAdapter(selectCommand, connectionString)
            Connect()

            Dim cmd As New SqlCommand(selectCommand, SPMSConn2)
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.Text

            Me.dataAdapter = New SqlDataAdapter(cmd)
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
    Private Function ValidataData() As Boolean
        Dim m_HasError As Boolean = False
        If cmbEndMonth.Text = String.Empty Then
            m_Err.SetError(cmbEndMonth, "End Month is Required")
            m_HasError = True
        End If
        If cmbEndYear.Text = String.Empty Then
            m_Err.SetError(cmbEndYear, "End Year is Required")
            m_HasError = True
        End If
        If cmbStartYear.Text = String.Empty Then
            m_Err.SetError(cmbStartYear, "Start Year is Required")
            m_HasError = True
        End If
        If cmbStartMonth.Text = String.Empty Then
            m_Err.SetError(cmbStartMonth, "Start Month is Required")
            m_HasError = True
        End If
        Return Not m_HasError
    End Function
    Private Sub LoadData1()
        ThreadLoadDataIsActive = 1
        UCReportPerformanceMonthWise_DistrictWise.CheckForIllegalCrossThreadCalls = False
        Label8.Text = "Genereting Preview . . ."

        Connect()
        Dim cmd As New SqlCommand("uspPerformanceMonthWise_DistrictWise", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@FromCutmo", cmbStartMonth.Text)
        cmd.Parameters.AddWithValue("@FromCutyear", cmbStartYear.Text)
        cmd.Parameters.AddWithValue("@ToCutmo", cmbEndMonth.Text)
        cmd.Parameters.AddWithValue("ToCutYear", cmbEndYear.Text)
        dataAdapter = New SqlDataAdapter(cmd)
        Dim commmandBuilder As New SqlCommandBuilder(dataAdapter)
        table = New DataTable
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        dataAdapter.Fill(table)
        Me.bindingSource1.DataSource = table
        Dim style As New DataGridViewCellStyle
        Dim i As Integer
        Dim j As Decimal
        style.Alignment = DataGridViewContentAlignment.MiddleRight
        i = 0
        While i < DataGridView1.ColumnCount
            If (DataGridView1.Columns.Item(i).ValueType Is j.GetType) Then
                DataGridView1.Columns.Item(i).DefaultCellStyle = style
            End If
            i += 1
        End While
        ThreadLoadDataIsActive = 0
        table.TableName = "a"
        dv.Table = table
        Me.DataGridView1.DataSource = dv
        If dv.Count > 0 Then Me.DataGridView1.Columns.Item(0).Visible = False
    End Sub
    Private Sub RefreshData()
        ProgressBar1.Visible = True
        Timer1.Enabled = True
        Me.DataGridView1.ClearSelection()
        Me.DataGridView1.DataSource = Me.bindingSource1
        If ValidataData Then
            ThreadLoadData = New Thread(New ThreadStart(AddressOf LoadData1))
            ThreadLoadData.Start()
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        UCReportPerformanceMonthWise_DistrictWise.CheckForIllegalCrossThreadCalls = False
        ThreadGenerateReport = New Thread(New ThreadStart(AddressOf Export))
        ThreadGenerateReport.Start()
        'Export()
    End Sub

    Private Sub UCReportMasterFileDownload_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        For i = 1900 To 3000
            cmbStartYear.Items.Add(i)
            cmbEndYear.Items.Add(i)
        Next
        cmbStartYear.SelectedIndex = 110
        cmbEndYear.SelectedIndex = 110

        ApplyGridTheme(DataGridView1)
        PopulateComboBox()
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

        Dim rs As New ADODB.Recordset
        rs = RsLockedCompany()
        If rs.RecordCount > 0 Then
            ConvertBytesToImageFile(rs.Fields("CompanyLogo").Value, ReturnExePath() & "\companylogo.jpg")
        End If


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

        Dim pic As New Object
        pic = objSheet.Pictures.Insert(ReturnExePath() & "\companylogo.jpg")

        With pic
            .height = 50
            .top = objSheet.Cells(1, 1).top
            .left = objSheet.Cells(1, 1).left
        End With


        objSheet.Name = "SalesAchievementTerritoryWise"
        objSheet.Range("A4", "A6").Font.Size = 14
        objSheet.Range("A4", "A6").Font.Bold = True
        'objExcel.Cells(4, 1).value = rs.Fields("COMNAME").Value
        objExcel.Cells(5, 1).value = lblTitle.Text
        objExcel.Cells(6, 1).value = "Date Range: " & cmbStartYear.Text & " " & cmbStartMonth.Text & " To " & cmbEndYear.Text & " " & cmbEndMonth.Text


        For i As Integer = 0 To table.Columns.Count - 1
            objSheet.Range("A8", "ZA8").Font.Size = 12
            objSheet.Range("A8", "ZA8").Font.Bold = True

            objExcel.Cells(8, i + 1).value = table.Columns(i).ColumnName
        Next
        For i As Integer = 9 To table.Rows.Count + 8
            Dim dr As DataRow = table.Rows(i - 9)

            For o As Integer = 0 To table.Columns.Count - 1
                objExcel.Cells(i, o + 1).value = dr.Item(o)
            Next
        Next
        objSheet.Range("B1:az400").EntireColumn.AutoFit()
        DeleteObject(ReturnExePath() & "\aldrtz.jpg")

        ' Focus on summary log file sheet

        objSheet = objBook.ActiveSheet()
        Dim objFirstSheet As Excel.Worksheet
        objSheets = objBook.Worksheets
        objFirstSheet = CType(objSheets.Item(1), Excel.Worksheet)
        objFirstSheet.Activate()

        Marshal.ReleaseComObject(objSheet)
        Marshal.ReleaseComObject(objSheets)

        'Saving the Workbook as a normal workbook format under log location
        objBook.SaveAs("SalesAchievementTerritoryWise ", Excel.XlFileFormat.xlWorkbookNormal, System.Reflection.Missing.Value, System.Reflection.Missing.Value, True, False, Excel.XlSaveAsAccessMode.xlNoChange, False, False, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)




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

    Private Sub PopulateComboBox()
        'Dim rs As New ADODB.Recordset
        'cmbStartYear.Items.Clear()
        'cmbEndYear.Items.Clear()
        'cmbStartMonth.Items.Clear()
        'cmbEndMonth.Items.Clear()
        ''for the year   
        'rs = RsGpiCalendarYear()
        'If rs.RecordCount > 0 Then
        '    For i As Integer = 1 To rs.RecordCount
        '        cmbStartYear.Items.Add(rs.Fields("cayr").Value)
        '        cmbEndYear.Items.Add(rs.Fields("cayr").Value)
        '        rs.MoveNext()
        '    Next
        'End If
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

    Private Sub SendMessagemeow()
        Try
            Dim SmtpServer As New SmtpClient()
            Dim aw As SmtpAccess = SmtpAccess.Connect

            Dim mail As New MailMessage()
            SmtpServer.Credentials = New Net.NetworkCredential("mbordonada@gmail.com", "bords1396")

            SmtpServer.Port = 587
            SmtpServer.EnableSsl = True
            SmtpServer.UseDefaultCredentials = False
            SmtpServer.Host = "smtp.gmail.com"
            mail = New MailMessage()
            mail.From = New MailAddress("mbordonada@gmail.com")
            mail.To.Add("mbordonada@etrphils.com")

            mail.Subject = "Test Mail"
            mail.Body = "This is for testing SMTP mail from GMAIL"
            SmtpServer.Send(mail)
            MsgBox("mail send")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



        'Dim mailmsg As MailMessage = New MailMessage
        'Dim SentFrom As New MailAddress("mbordonada@etrphils.com")
        'Dim SendTo As New MailAddress("mbordonada@etrphils.com")
        'mailmsg.From = SentFrom
        'mailmsg.ReplyTo = SendTo
        'mailmsg.Body = "meow"


    End Sub


    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub cmbStartMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStartMonth.SelectedIndexChanged

    End Sub

    Private Sub DataGridView1_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

        dv.Sort = "[SORT] ASC " & IIf(e.ColumnIndex <> 0, ", [" & Me.DataGridView1.Columns.Item(e.ColumnIndex).Name & "] " & Mid(Me.DataGridView1.SortOrder.ToString, 1, 3), "")
        Me.DataGridView1.Columns.Item(0).Visible = False
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = 100 Then
            ProgressBar1.Value = 0
        Else
            ProgressBar1.Value = ProgressBar1.Value + 5
        End If
        Me.Enabled = False
        If ThreadLoadDataIsActive = 0 And ThreaGenerateReportIsactive = 0 Then
            Label8.Text = "Refress...."
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
            TimerCounter = 0
            Me.Enabled = True
            Timer2.Enabled = False
        Else
            TimerCounter = TimerCounter + 1
        End If

    End Sub
End Class
