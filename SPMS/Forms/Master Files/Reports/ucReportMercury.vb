Imports SPMSOPCI.ConnectionModule
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

Public Class ucReportMercury

    Private bindingSource1 As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Private table As New DataTable()

    Dim strFrMonth, strFrYear, strToMonth, strToYear, strChannel, str, strMedRep, strItem As String

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub GetData(ByVal selectCommand As String)

        Try
            Dim connectionString As String = ""
            If SqlConnectionExists() = True Then
                connectionString = GetSqlconnectionPath()
            Else : connectionString = "data source=ETRWS10/SQLEXPRESS; initial catalog=SPMSGPI; user id=sa; password=p@ssw0rd;"
            End If
            Me.dataAdapter = New SqlDataAdapter(selectCommand, connectionString)
            Dim commandBuilder As New SqlCommandBuilder(Me.dataAdapter)
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
        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        Catch ex2 As Exception
            MessageBox.Show(ex2.Message)
        End Try

    End Sub


    Private Sub ucReportMercury_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ApplyGridTheme(DataGridView1)

        For i = 1900 To 2500
            ComboBox_frYear.Items.Add(i.ToString())
            ComboBox_toYear.Items.Add(i.ToString())
        Next
        ComboBox_frYear.SelectedIndex = 110
        ComboBox_frMonth.SelectedIndex = 0
        ComboBox_toYear.SelectedIndex = 110
        ComboBox_toMonth.SelectedIndex = 0

        Dim sel As String
        sel = "SELECT DISTINCT DISTCOMID, DISTNAME FROM DISTRIBUTOR ORDER BY DISTNAME"
        AddItemsToComboBox(sel, ComboBox_Channel)
        ComboBox_Channel.Items.Insert(0, "ALL Channels")
        ComboBox_Channel.SelectedIndex = -1

        sel = "SELECT DISTINCT SM.STSLSMNCD, SM.STSLSMNNAME FROM SALESMATRIX SM ORDER BY STSLSMNCD"
        AddItemsToComboBox(sel, ComboBox_MedRep)
        ComboBox_MedRep.SelectedIndex = -1

        sel = "SELECT DISTINCT CD.PROD, CD.PDES FROM CUST_DIV_ITEM_SALES CD ORDER BY CD.PROD"
        AddItemsToComboBox(sel, ComboBox_Item)
        ComboBox_Item.SelectedIndex = -1
    End Sub

    Private Sub AddItemsToComboBox(ByVal selectCommand As String, ByRef CB As ComboBox)
        'Adding Items to ComboBox        
        Dim connection As SqlConnection
        Dim connectionString As String = ""
        Dim adapter As SqlDataAdapter
        Dim ds As New DataSet

        If SqlConnectionExists() = True Then
            connectionString = GetSqlconnectionPath()
        Else : connectionString = "data source=ETRWS10\SQLEXPRESS; initial catalog=SPMSGPI; user id=sa; password=p@ssw0rd;"
        End If
        connection = New SqlConnection(connectionString)

        Try
            connection.Open()
            adapter = New SqlDataAdapter(selectCommand, connectionString)
            adapter.Fill(ds)
            Dim str As String
            str = String.Empty
            For i = 0 To ds.Tables(0).Rows.Count - 1
                str = ds.Tables(0).Rows(i).Item(0) + " - " + ds.Tables(0).Rows(i).Item(1)
                CB.Items.Insert(i, str)
            Next
            connection.Close()
        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        Catch ex2 As Exception
            MessageBox.Show(ex2.Message)
        End Try
    End Sub


    Private Sub Button_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_OK.Click
        Try

            str = "  "
            strChannel = " @COMID = '" + ComboBox_Channel.SelectedItem.ToString.Split(" ")(0) + "' "
            strFrMonth = " @FromCutMo = '" + ComboBox_frMonth.SelectedItem.ToString.Split(" ")(0) + "' "
            strFrYear = " @FromCutYear = '" + ComboBox_frYear.SelectedItem.ToString + "' "
            strToMonth = " @ToCutMo = '" + ComboBox_toMonth.SelectedItem.ToString.Split(" ")(0) + "' "
            strToYear = " @ToCutYear = '" + ComboBox_toYear.SelectedItem.ToString + "' "
            strMedRep = " @MedRep = '" + ComboBox_MedRep.SelectedItem.ToString.Split(" ")(0) + "' "
            strItem = " @ProductCode = '" + ComboBox_Item.SelectedItem.ToString.Split(" ")(0) + "' "

            str = " EXECUTE uspMercuryTransaction " & _
                    strMedRep + "," + strItem + "," + strChannel + "," + strFrMonth + "," + strFrYear + "," + strToMonth + "," + strToYear

            Me.DataGridView1.ClearSelection()
            Me.table.Rows.Clear()
            Me.table.Columns.Clear()
            Me.DataGridView1.DataSource = Me.bindingSource1
            GetData(str)

        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        Catch ex2 As Exception
            MessageBox.Show(ex2.Message)
        End Try
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

    Private Sub Export()
        On Error GoTo errHandler
        Dim objExcel As Excel.Application = Nothing
        Dim objBooks As Excel.Workbooks = Nothing
        Dim objBook As Excel.Workbook = Nothing
        Dim objSheets As Excel.Sheets = Nothing
        Dim objSheet As Excel.Worksheet = Nothing
        Dim objRange As Excel.Range = Nothing
        objExcel = New Excel.Application
        objExcel.Visible = True
        objExcel.DisplayAlerts = False
        objBook = CType(objExcel.Workbooks.Add(), Excel.Workbook)
        objBooks = objExcel.Workbooks
        objSheet = CType(objBooks(1).Sheets.Item(1), Excel.Worksheet)
        objSheets = objBook.Worksheets
        objSheets.Add(Count:=6)
        objBook = objBooks.Item(1)
        objSheet = CType(objSheets.Item(1), Excel.Worksheet)
        objSheet.Name = "sheet1"
        For i As Integer = 0 To table.Columns.Count - 1
            objExcel.Cells(1, i + 1).value = table.Columns(i).ColumnName
        Next
        For i As Integer = 2 To table.Rows.Count + 1
            Dim dr As DataRow = table.Rows(i - 2)
            For o As Integer = 0 To table.Columns.Count - 1
                objExcel.Cells(i, o + 1).value = dr.Item(o)
            Next
        Next
        objSheet = objBook.ActiveSheet()
        Dim objFirstSheet As Excel.Worksheet
        objSheets = objBook.Worksheets
        objFirstSheet = CType(objSheets.Item(1), Excel.Worksheet)
        objFirstSheet.Activate()
        Marshal.ReleaseComObject(objSheet)
        Marshal.ReleaseComObject(objSheets)
        objBook.SaveAs(Label4.Text, Excel.XlFileFormat.xlWorkbookNormal, System.Reflection.Missing.Value, System.Reflection.Missing.Value, True, False, Excel.XlSaveAsAccessMode.xlNoChange, False, False, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
        Exit Sub
errHandler:
        objExcel.Quit()
    End Sub
End Class
