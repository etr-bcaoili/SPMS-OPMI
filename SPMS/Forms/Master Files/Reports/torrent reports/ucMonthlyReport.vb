Imports SPMS.ConnectionModule
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

Public Class ucMonthlyReport

    Private bindingSource1 As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Private table As New DataTable()

    Dim strMonth, strYear, strAM, strMR, strItemDiv, strChannel, str, strDate As String

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


    Private Sub ucMonthlyReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ApplyGridTheme(DataGridView1)

        For i = 1900 To 2500
            ComboBox_Year.Items.Add(i)
        Next
        ComboBox_Year.SelectedIndex = 110
        ComboBox_Month.SelectedIndex = 0
        ComboBox_AM.SelectedIndex = 0
        ComboBox_MR.SelectedIndex = 0
        ComboBox_National.SelectedIndex = 0

        Dim sel As String

        sel = "SELECT ITMDIVCD, ITMDIVNAME FROM ITEMDIVISION ORDER BY ITMDIVNAME"
        AddItemsToComboBox(sel, ComboBox_ItemDiv)
        ComboBox_ItemDiv.Items.Insert(0, "ALL Item Divisions")
        ComboBox_ItemDiv.SelectedIndex = 0

        sel = "SELECT STSLSMGRCD, STSLSMGRNAME FROM STSALESMANAGER ORDER BY STSLSMGRNAME"
        AddItemsToComboBox(sel, ComboBox_AMSelect)
        ComboBox_AMSelect.SelectedIndex = 0

        sel = "SELECT SLSMNCD, SLSMNNAME FROM MEDICALREP ORDER BY SLSMNNAME"
        AddItemsToComboBox(sel, ComboBox_MRSelect)
        ComboBox_MRSelect.SelectedIndex = 0

        sel = "SELECT DISTCOMID, DISTNAME FROM DISTRIBUTOR ORDER BY DISTNAME"
        AddItemsToComboBox(sel, ComboBox_AMChannel)
        ComboBox_AMChannel.Items.Insert(0, "ALL Channels")
        ComboBox_AMChannel.SelectedIndex = 0
        AddItemsToComboBox(sel, ComboBox_MRChannel)
        ComboBox_MRChannel.Items.Insert(0, "ALL Channels")
        ComboBox_MRChannel.SelectedIndex = 0

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

    Private Sub RadioButton_National_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_National.CheckedChanged
        If RadioButton_National.Checked Then
            Panel_National.Enabled = True
        Else
            Panel_National.Enabled = False
        End If
    End Sub

    Private Sub RadioButton_AM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_AM.CheckedChanged
        If RadioButton_AM.Checked Then
            Panel_AM.Enabled = True
        Else
            Panel_AM.Enabled = False
        End If
    End Sub

    Private Sub RadioButton_MR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_MR.CheckedChanged
        If RadioButton_MR.Checked Then
            Panel_MR.Enabled = True
        Else
            Panel_MR.Enabled = False
        End If
    End Sub

    Private Sub ComboBox_National_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_National.SelectedIndexChanged
        If ComboBox_National.SelectedIndex = 2 Then
            Label_ItemDiv.Enabled = True
            ComboBox_ItemDiv.Enabled = True
        Else
            Label_ItemDiv.Enabled = False
            ComboBox_ItemDiv.Enabled = False
        End If
    End Sub

    Private Sub ComboBox_AM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_AM.SelectedIndexChanged
        If ComboBox_AM.SelectedIndex = 3 Then
            Label_AMChannel.Enabled = True
            ComboBox_AMChannel.Enabled = True
        Else
            Label_AMChannel.Enabled = False
            ComboBox_AMChannel.Enabled = False
        End If
    End Sub

    Private Sub ComboBox_MR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_MR.SelectedIndexChanged
        If ComboBox_MR.SelectedIndex = 2 Then
            Label_MRChannel.Enabled = True
            ComboBox_MRChannel.Enabled = True
        Else
            Label_MRChannel.Enabled = False
            ComboBox_MRChannel.Enabled = False
        End If
    End Sub

    Private Sub Button_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_OK.Click
        Try

            str = "  "
            strMonth = " @Month = " + ComboBox_Month.SelectedItem.ToString.Split(" ")(0) + " "
            strYear = " @Year = " + ComboBox_Year.SelectedItem.ToString + " "
            strDate = ComboBox_Month.SelectedItem.ToString.Split(" ")(2) & _
                      " " + ComboBox_Year.SelectedItem.ToString + " "

            If RadioButton_National.Checked = True Then
                If ComboBox_National.SelectedIndex = 0 Then
                    str = " EXECUTE uspNationalConsolidatedMonthlySalesReport_ProductWise " & _
                            strMonth + "," + strYear
                    Me.Label4.Text = "National Consolidated Monthly Sales Report (Product Wise) for " + strDate

                ElseIf ComboBox_National.SelectedIndex = 1 Then
                    str = " EXECUTE uspNationalConsolidatedMonthlySalesReport_MedRepWise " & _
                            strMonth + "," + strYear
                    Me.Label4.Text = "National Consolidated Monthly Sales Report (Medical Representative Wise) for " + strDate

                ElseIf ComboBox_National.SelectedIndex = 2 Then
                    strItemDiv = " @DivCode = '" + ComboBox_ItemDiv.SelectedItem.ToString.Split(" ")(0) + "' "
                    str = " EXECUTE uspNationalConsolidatedMonthlySalesReport_ProductDIVWise " & _
                            strItemDiv + "," + strMonth + "," + strYear
                    Me.Label4.Text = "National Consolidated Monthly Sales Report (Product Wise, By Item Division) for " + strDate

                End If

            ElseIf RadioButton_AM.Checked = True Then
                strAM = " @AreaManager = '" + ComboBox_AMSelect.SelectedItem.ToString.Split(" ")(0) + "' "

                If ComboBox_AM.SelectedIndex = 0 Then
                    str = " EXECUTE uspAreaManagerMonthlySalesReport_ProductWise " & _
                            strAM + "," + strMonth + "," + strYear
                    Me.Label4.Text = "Area Manager Monthly Sales Report (Product Wise) for " + strDate

                ElseIf ComboBox_AM.SelectedIndex = 1 Then
                    str = " EXECUTE uspAreaManagerMonthlySalesReport_ChannelWise " & _
                    Me.Label4.Text = "Area Manager Monthly Sales Report (Channel Wise) for " + strDate

                ElseIf ComboBox_AM.SelectedIndex = 2 Then
                    str = " EXECUTE uspAreaManagerMonthlySalesReport_MedRepWise " & _
                            strAM + "," + strMonth + "," + strYear
                    Me.Label4.Text = "Area Manager Monthly Sales Report (Medical Representative Wise) for " + strDate

                ElseIf ComboBox_AM.SelectedIndex = 3 Then
                    strChannel = " @Channel = '" + ComboBox_AMChannel.SelectedItem.ToString.Split(" ")(0) + "' "
                    str = " EXECUTE uspAreaManagerMonthlySalesReport_CustomerWise_ByChannel " & _
                            strAM + "," + strMonth + "," + strYear + "," + strChannel
                    Me.Label4.Text = "Area Manager Monthly Sales Report (Customer Wise, By Channel) for " + strDate

                End If

            ElseIf RadioButton_MR.Checked = True Then
                strMR = " @MedRep = '" + ComboBox_MRSelect.SelectedItem.ToString.Split(" ")(0) + "' "

                If ComboBox_MR.SelectedIndex = 0 Then
                    str = " EXECUTE uspMedRepMonthlySalesReport_ProductWise " & _
                            strMR + "," + strMonth + "," + strYear
                    Me.Label4.Text = "Medical Representative Manager Monthly Sales Report (Product Wise) for " + strDate

                ElseIf ComboBox_MR.SelectedIndex = 1 Then
                    str = " EXECUTE uspMedRepMonthlySalesReport_ChannelWise " & _
                            strMR + "," + strMonth + "," + strYear
                    Me.Label4.Text = "Medical Representative Monthly Sales Report (Channel Wise) for " + strDate

                ElseIf ComboBox_MR.SelectedIndex = 2 Then
                    strChannel = " @Channel = '" + ComboBox_MRChannel.SelectedItem.ToString.Split(" ")(0) + "' "
                    str = " EXECUTE uspMedRepMonthlySalesReport_CustomerWise_ByChannel " & _
                            strMR + "," + strMonth + "," + strYear + "," + strChannel
                    Me.Label4.Text = "Medical Representative Monthly Sales Report (Customer Wise, By Channel) for " + strDate

                End If

            End If

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
        objSheet.Name = strDate
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
