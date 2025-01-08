Imports SPMSOPCI.ConnectionModule
Imports System.Data
Imports System.Data.SqlClient

Imports System.Net.Mail
'Imports System.Web.mail

Imports Microsoft.Office.Interop
'Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices

Public Class UCReportSalesAchievementTerritoryWise





    Private bindingSource1 As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Private table As New DataTable()

    Private m_Err As New ErrorProvider

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
        Me.DataGridView1.ClearSelection()
        'Me.Label4.Text = "Sales Report for Current Month"
        Me.DataGridView1.DataSource = Me.bindingSource1

        GetData("EXEC USPSalesAchievementTerritoryWisePerDate @MonthFrom=" & cmbStartMonth.Text & ",  @YearFrom=" & cmbStartYear.Text & ", @MonthTo=" & cmbEndMonth.Text & ",  @YearTo=" & cmbEndYear.Text & " ")


    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

    Private Sub UCReportMasterFileDownload_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        DeleteObject(ReturnExePath() & "\companylogo.jpg")

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

        SendMessagemeow()


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

    Private Sub SendMessagemeow()
        Try
            Dim SmtpServer As New SmtpClient()
            Dim aw As SmtpAccess = SmtpAccess.Connect

            Dim mail As New MailMessage()
            SmtpServer.Credentials = New Net.NetworkCredential("mbordonada@etrphils.com", "mbordonada")

            SmtpServer.Port = 587
            SmtpServer.EnableSsl = True
            SmtpServer.UseDefaultCredentials = False
            SmtpServer.Host = "smtp.gmail.com"
            mail = New MailMessage()
            mail.From = New MailAddress("mbordonada@etrphils.com")
            mail.To.Add("mbordonada@etrphils.com")

            mail.Subject = "Test Mail"
            mail.Body = "This is for testing SMTP mail from GMAIL"
            SmtpServer.Send(mail)
            MsgBox("mail send")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'Try
        '    Dim SmtpServer As New SmtpClient()
        '    Dim mail As New MailMessage()
        '    SmtpServer.Credentials = New Net.NetworkCredential("support@etrph.com", "p@ssw0rd")
        '    'SmtpServer.EnableSsl = True


        '    SmtpServer.Host = "smtpout.secureserver.net"
        '    mail = New MailMessage()
        '    mail.From = New MailAddress("michael_bordonada@yahoo.com")
        '    mail.To.Add("mbordonada@etrphils.com")
        '    mail.Subject = "Test Mail"
        '    mail.Body = "This is for testing SMTP mail from GMAIL"
        '    SmtpServer.Send(mail)
        '    MsgBox("mail send")
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try


        'Dim mailmsg As MailMessage = New MailMessage
        'Dim SentFrom As New MailAddress("mbordonada@etrphils.com")
        'Dim SendTo As New MailAddress("mbordonada@etrphils.com")
        'mailmsg.From = SentFrom
        'mailmsg.ReplyTo = SendTo
        'mailmsg.Body = "meow"


    End Sub


End Class
