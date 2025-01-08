Imports SPMSOPCI.ConnectionModule
Imports System.Data
Imports System.Data.SqlClient


Imports Microsoft.Office.Interop
'Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices


Public Class UCReportProfitAndLoss

    Private bindingSource1 As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Private table As New DataTable()

    Private m_Err As New ErrorProvider
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
            Dim cmd As New SqlCommand("uspOPCIProfitAndLoss", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@DateFrom", dtFrom.Value.ToShortDateString)
            cmd.Parameters.AddWithValue("@DateTo", dtto.Value.ToShortDateString)
            cmd.Parameters.AddWithValue("@AgentCode", txtAgent.Tag)
            cmd.CommandTimeout = 0
            table = New DataTable


            Dim da As New SqlDataAdapter(cmd)
            da.Fill(table)


            Me.dataAdapter = New SqlDataAdapter(cmd)

            table.Locale = System.Globalization.CultureInfo.InvariantCulture

            table.Columns.Add("Total", System.Type.GetType("System.String"))

            Dim Total As Double = 0
            For r As Integer = 1 To table.Rows.Count
                Total = 0
                For c As Integer = 2 To table.Columns.Count
                    If c = (table.Columns.Count) Then

                        table.Rows(r - 1)(c - 1) = Total.ToString("###,###,###0.0000")
                        ''DataGridView1.Rows(r).Cells(Me.DataGridView1.ColumnCount - 1).Value = Total.ToString("###,###,###,##0.00")
                        ''DataGridView1.Rows(r).Cells(Me.DataGridView1.ColumnCount - 1).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    Else
                        'Total = Val(Total) + Val(table.Rows(r)(c))
                        Total = Val(Total) + Val(table.Rows(r - 1)(c - 1))
                    End If
                    'table.Rows(r)(table.Columns.Count - 1) = "10.53"
                Next
            Next

            'Me.DataGridView1.Columns.Clear()
            Me.bindingSource1.DataSource = table
            Disconnect()
            ' Right Align double data types
            Dim style As DataGridViewCellStyle
            Dim i As Integer
            Dim j As Decimal
            style = New DataGridViewCellStyle()
            style.Alignment = DataGridViewContentAlignment.MiddleRight
            i = 0
            DataGridView1.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            While i < DataGridView1.ColumnCount - 1
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


        objSheet.Name = "Profit And Loss"




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
        objBook.SaveAs("Profit And Loss", Excel.XlFileFormat.xlWorkbookNormal, System.Reflection.Missing.Value, System.Reflection.Missing.Value, True, False, Excel.XlSaveAsAccessMode.xlNoChange, False, False, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
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

    Private Sub UCReportProfitAndLoss_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(DataGridView1)
    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        RefreshData()
    End Sub

    Private Sub lnkClear_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkClear.LinkClicked
        txtAgent.Text = String.Empty

    End Sub

    Private Sub lnkMedicalRep_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkMedicalRep.LinkClicked
        Dim tag As SelectionTag = ShowSearchDialog(MedicalRep.GetMedicalRepColumns, MedicalRep.GetMedicalRepSql, "Medical Rep.")
        If Not tag Is Nothing Then
            txtAgent.Tag = tag.KeyColumn1
            txtAgent.Text = tag.KeyColumn3
        End If
    End Sub
End Class
