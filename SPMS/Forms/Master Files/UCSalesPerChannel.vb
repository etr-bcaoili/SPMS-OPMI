Imports SPMSOPCI.ConnectionModule
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.InvalidCastException



Public Class UCSalesPerChannel

    Dim objApp As Excel.Application
    Dim objBook As Excel._Workbook

    Private m_CompanyCode As String
    Dim Table As New DataTable
    Dim dt As New DataTable
    Private m_HasError As Boolean = False
    Private m_Err As New ErrorProvider
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub btnopen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnopen.Click
        If ValidateData() Then
            OpenSoure()
        End If
    End Sub
    Private Sub OpenSoure()
        Connect()
        Dim cmd As New SqlCommand("uspRptSalesPerChannel", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@Channel", cmbchannelcode.Text)
        cmd.Parameters.AddWithValue("@Year", cmbyear.Text)
        cmd.Parameters.AddWithValue("@Month", cmbMonth.Text)
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        dgDetails.Rows.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)
                Dim row As DataGridViewRow = dgDetails.Rows(dgDetails.Rows.Add)
                If dr("ITEM MOTHER NAME") = "Total :" Then
                    row.Cells(colProductName.Index).Style.BackColor = Color.DodgerBlue
                    row.Cells(colProductName.Index).Value = dr("ITEM MOTHER NAME")
                    row.Cells(colLYTD.Index).Style.BackColor = Color.DodgerBlue
                    row.Cells(colLYTD.Index).Value = ""
                    row.Cells(coljan.Index).Style.BackColor = Color.DodgerBlue
                    row.Cells(coljan.Index).Value = dr("January")
                    row.Cells(colFeb.Index).Style.BackColor = Color.DodgerBlue
                    row.Cells(colFeb.Index).Value = dr("Febraury")
                    row.Cells(colMar.Index).Style.BackColor = Color.DodgerBlue
                    row.Cells(colMar.Index).Value = dr("March")
                    row.Cells(colAp.Index).Style.BackColor = Color.DodgerBlue
                    row.Cells(colAp.Index).Value = dr("April")
                    row.Cells(colMay.Index).Style.BackColor = Color.DodgerBlue
                    row.Cells(colMay.Index).Value = dr("May")
                    row.Cells(colJune.Index).Style.BackColor = Color.DodgerBlue
                    row.Cells(colJune.Index).Value = dr("June")
                    row.Cells(colJuly.Index).Style.BackColor = Color.DodgerBlue
                    row.Cells(colJuly.Index).Value = dr("July")
                    row.Cells(colAgust.Index).Style.BackColor = Color.DodgerBlue
                    row.Cells(colAgust.Index).Value = dr("August")
                    row.Cells(colAgust.Index).Style.BackColor = Color.DodgerBlue
                    row.Cells(colSept.Index).Value = dr("September")
                    row.Cells(colSept.Index).Style.BackColor = Color.DodgerBlue
                    row.Cells(colOct.Index).Value = dr("October")
                    row.Cells(colOct.Index).Style.BackColor = Color.DodgerBlue
                    row.Cells(colNov.Index).Value = dr("November")
                    row.Cells(colNov.Index).Style.BackColor = Color.DodgerBlue
                    row.Cells(coldec.Index).Value = dr("December")
                    row.Cells(coldec.Index).Style.BackColor = Color.DodgerBlue
                    row.Cells(colYTD.Index).Value = dr("YTD")
                    row.Cells(colYTD.Index).Style.BackColor = Color.DodgerBlue
                    row.Cells(colYTDAVE.Index).Value = ""
                    row.Cells(colYTDAVE.Index).Style.BackColor = Color.DodgerBlue
                    row.Cells(colgrowth.Index).Value = ""
                    row.Cells(colgrowth.Index).Style.BackColor = Color.DodgerBlue
                Else
                    row.Cells(colProductName.Index).Value = dr("ITEM MOTHER NAME")
                    row.Cells(colLYTD.Index).Value = dr("LTYD")
                    row.Cells(coljan.Index).Value = dr("January")
                    row.Cells(colFeb.Index).Value = dr("Febraury")
                    row.Cells(colMar.Index).Value = dr("March")
                    row.Cells(colAp.Index).Value = dr("April")
                    row.Cells(colMay.Index).Value = dr("May")
                    row.Cells(colJune.Index).Value = dr("June")
                    row.Cells(colJuly.Index).Value = dr("July")
                    row.Cells(colAgust.Index).Value = dr("August")
                    row.Cells(colSept.Index).Value = dr("September")
                    row.Cells(colOct.Index).Value = dr("October")
                    row.Cells(colNov.Index).Value = dr("November")
                    row.Cells(coldec.Index).Value = dr("December")
                    row.Cells(colYTD.Index).Value = dr("YTD")
                    row.Cells(colYTDAVE.Index).Value = dr("YTDEVE")
                    row.Cells(colgrowth.Index).Value = dr("Growth")
                End If
            Next
        End If

        dgDetails.Refresh()
    End Sub
    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False
        If cmbchannelcode.Text = String.Empty Or cmbchannelcode.Text Is Nothing Then
            m_Err.SetError(cmbchannelcode, "Channel is required")
            m_HasError = True
        End If
        If cmbyear.Text = String.Empty Or cmbyear.Text Is Nothing Then
            m_Err.SetError(cmbyear, "Year is required")
            m_HasError = True
        End If
        If cmbMonth.Text = String.Empty Or cmbMonth.Text Is Nothing Then
            m_Err.SetError(cmbMonth, "Month is required")
            m_HasError = True
        End If
        Return Not m_HasError
    End Function

    Private Sub UCSalesPerChannel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulatingCombox()
    End Sub
    Private Sub PopulatingCombox()
        If m_CompanyCode = "ODI" Then
            Table = GetRecords("Select DistComid From DistricButor where DLTFLG = 0 and DIStComid = 'ODI'")
            For I As Integer = 0 To Table.Rows.Count - 1
                cmbchannelcode.Items.Add(Table.Rows(I)("DistComid"))
            Next
        Else
            Table = GetRecords("Select * from Distributor  where DLTFLG  = 0 ")
            For i As Integer = 0 To Table.Rows.Count - 1
                cmbchannelcode.Items.Add(Table.Rows(i)("DistComid"))
            Next
        End If
    End Sub

    Private Sub cmbyear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbyear.SelectedIndexChanged
        If cmbyear.SelectedIndex = -1 Then Exit Sub
        cmbMonth.Items.Clear()
        LoadMonth(cmbchannelcode.Text, cmbyear.Text)
    End Sub

    Private Sub cmbchannelcode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbchannelcode.SelectedIndexChanged
        If cmbchannelcode.SelectedIndex = -1 Then Exit Sub
        cmbyear.Items.Clear()
        LoadYear(cmbchannelcode.Text)
    End Sub
    Private Sub LoadYear(ByVal DistributorCode As String)
        Table = GetRecords("Select Distinct Cayr from Calendar where comid = '" & DistributorCode & "'")
        For i As Integer = 0 To Table.Rows.Count - 1
            cmbyear.Items.Add(Table.Rows(i)("CAYR"))
        Next
    End Sub
    Private Sub LoadMonth(ByVal DistributorCode As String, ByVal year As String)
        Table = GetRecords("Select * from Calendar where Comid = '" & DistributorCode & "' and CAYR = '" & year & "'")
        For i As Integer = 0 To Table.Rows.Count - 1
            cmbMonth.Items.Add(Table.Rows(i)("CAPN"))
        Next
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        clear()
    End Sub
    Private Sub clear()
        dgDetails.Rows.Clear()
        cmbchannelcode.Text = String.Empty
        cmbMonth.Text = String.Empty
        cmbyear.Text = String.Empty
    End Sub

    Private Sub ToolStripLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel1.Click
        If cmbchannelcode.Text = String.Empty Or cmbMonth.Text = String.Empty Or cmbyear.Text = String.Empty Then
            ValidateData()
        Else
            ReportingExcell()
        End If
    End Sub
    Private Sub ReportingExcell()


        Dim objBooks As Excel.Workbooks
        Dim objSheets As Excel.Sheets
        Dim objSheet As Excel._Worksheet
        Dim range As Excel.Range
        If Not File.Exists(ReturnExePath() & "\Report") Then
            Directory.CreateDirectory(ReturnExePath() & "\Report")
        End If
        Directory.CreateDirectory(ReturnExePath() & "\Report" & "\SalesAnalysisChannel")

        objApp = New Excel.Application()
        objBooks = objApp.Workbooks
        objBook = objBooks.Add
        objSheets = objBook.Worksheets

        CreateChannelPerMonth(objBooks, objSheets, objSheet, range)
        If File.Exists(ReturnExePath() & "Report" & "\SalesAnalysisChannel\" & "Sales Analysis Per Channel as of (" & cmbyear.Text & "-" & cmbMonth.Text & ")-(" & cmbyear.Text & "-" & cmbMonth.Text & ").xls") Then
            Kill(ReturnExePath() & "Report" & "\SalesAnalysisChannel\" & "Sales Analysis Per Channel as of (" & cmbyear.Text & "-" & cmbMonth.Text & ")-(" & cmbyear.Text & "-" & cmbMonth.Text & ").xls")
        End If
        objApp.ActiveWorkbook.SaveAs(ReturnExePath() & "Report" & "\SalesAnalysisChannel" & "\Sales Analysis Per Channel as of (" & cmbyear.Text & "-" & cmbMonth.Text & ")-(" & cmbyear.Text & "-" & cmbMonth.Text & ")", Excel.XlFileFormat.xlExcel8)
        objApp.Quit()
        range = Nothing
        objSheet = Nothing
        objSheets = Nothing
        objBooks = Nothing
    End Sub
    Private Sub CreateChannelPerMonth(ByVal objbooks As Excel.Workbooks, ByVal objsheets As Excel.Sheets, ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range)

        objsheet = objsheets.Add

        objsheet.Move(After:=objsheets(1))
        objsheet.Name = ("SALESGETAVERDATA")

        MergeCell(objsheet, range, "A2", "C2", GetDefaultCompanyName, 16, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
        MergeCell(objsheet, range, "A3", "C3", "Sales Perforemances Per Channel Report :  (" & cmbMonth.Text & " - " & cmbyear.Text & ")-(" & cmbMonth.Text & " - " & cmbyear.Text & ")", 11, True, Excel.Constants.xlCenter, Excel.Constants.xlCenter)

        Dim Counter As Integer = 0
        Dim y As Integer = 5
        Dim yheader As Integer = 0

        Connect()
        Dim cmd As New SqlCommand("uspRptSalesPerChannel", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@Channel", cmbchannelcode.Text)
        cmd.Parameters.AddWithValue("@Month", cmbMonth.Text)
        cmd.Parameters.AddWithValue("@Year", cmbyear.Text)
        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        If dt.Rows.Count > 0 Then
            CreateHeaderForSalesPerChannel(objsheet, range, y + yheader)
            For l As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(l)
                objsheet.Cells(6 + Counter + l, 1) = dr("ITEM MOTHER NAME")
                objsheet.Cells(6 + Counter + l, 2) = dr("LTYD")
                objsheet.Cells(6 + Counter + l, 3) = dr("January")
                objsheet.Cells(6 + Counter + l, 4) = dr("Febraury")
                objsheet.Cells(6 + Counter + l, 5) = dr("March")
                objsheet.Cells(6 + Counter + l, 6) = dr("April")
                objsheet.Cells(6 + Counter + l, 7) = dr("May")
                objsheet.Cells(6 + Counter + l, 8) = dr("June")
                objsheet.Cells(6 + Counter + l, 9) = dr("July")
                objsheet.Cells(6 + Counter + l, 10) = dr("August")
                objsheet.Cells(6 + Counter + l, 11) = dr("September")
                objsheet.Cells(6 + Counter + l, 12) = dr("October")
                objsheet.Cells(6 + Counter + l, 13) = dr("November")
                objsheet.Cells(6 + Counter + l, 14) = dr("December")
                objsheet.Cells(6 + Counter + l, 15) = dr("YTD")
                objsheet.Cells(6 + Counter + l, 16) = dr("YTDEVE")
                objsheet.Cells(6 + Counter + l, 17) = dr("Growth")
            Next
        End If

        range = objsheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)


        range.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

        range = objsheet.Range("A" & Convert.ToString(y + yheader), Reflection.Missing.Value)
        range = range.Resize(dt.Rows.Count + 1, dt.Columns.Count)
        range.Cells.NumberFormat = "#,##0.00"

        Counter += dt.Rows.Count + 3
        yheader += dt.Rows.Count + 3

        objsheet.Range("A1:AZ400").EntireColumn.AutoFit()


    End Sub
    Private Sub MergeCell(ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal FromRange As String, _
                          ByVal ToRange As String, ByVal Value As String, ByVal FontSize As Integer, ByVal Bold As Boolean, ByVal horizontalalign As Excel.Constants, ByVal vertical As Excel.Constants)

        range = objsheet.Range(FromRange, ToRange)

        range.Merge()
        range.HorizontalAlignment = horizontalalign
        range.VerticalAlignment = vertical

        range.WrapText = True
        range.ShrinkToFit = False
        range.Value = Value
        range.Font.Size = FontSize
        range.Font.Bold = Bold
    End Sub

    Private Sub CreateHeaderForSalesPerChannel(ByVal objsheet As Excel._Worksheet, ByVal range As Excel.Range, ByVal y As Integer)
        objsheet.Cells(y, 1) = "ProductName"
        objsheet.Cells(y, 2) = "Average" & cmbyear.Text - 1
        objsheet.Cells(y, 3) = "January"
        objsheet.Cells(y, 4) = "February"
        objsheet.Cells(y, 5) = "March"
        objsheet.Cells(y, 6) = "April"
        objsheet.Cells(y, 7) = "May"
        objsheet.Cells(y, 8) = "June"
        objsheet.Cells(y, 9) = "July"
        objsheet.Cells(y, 10) = "August"
        objsheet.Cells(y, 11) = "September"
        objsheet.Cells(y, 12) = "October"
        objsheet.Cells(y, 13) = "November"
        objsheet.Cells(y, 14) = "December"
        objsheet.Cells(y, 15) = "YTD" & cmbyear.Text
        objsheet.Cells(y, 16) = "Average" & cmbyear.Text
        objsheet.Cells(y, 17) = "Growth%"
        range = objsheet.Range("A" & Convert.ToString(y) & ":Q" & Convert.ToString(y))
        range.Font.Bold = True
        range.HorizontalAlignment = Excel.Constants.xlCenter
    End Sub

    Private Sub dgDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick

    End Sub
End Class
