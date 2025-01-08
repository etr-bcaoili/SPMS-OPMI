
<System.ComponentModel.ToolboxItem(False)> _
Public Class UCInfraReportResult
    Inherits Althea.Base.UI.BasePage


    Private v_Report As New InfraReporting

    Private v_err As New ErrorProvider

    Private v_HasError As Boolean = False

    Private UltraGridExcelExporter1 As New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter

    Private m_objSheet As Infragistics.Excel.Worksheet

    Private m_objBook As Infragistics.Excel.Workbook

    Private m_objCell As Infragistics.Excel.WorksheetCell

    Dim mergedRegion1 As Infragistics.Excel.WorksheetMergedCellsRegion

    'Public Overrides ReadOnly Property ApplicationModule() As Services.DirectoryServices.ApplicationModule
    '    Get
    '        Return New InfraReportingApplicationModule
    '    End Get
    'End Property

    Public Sub dgSearchDefault(ByVal SP As String)

        dgView.Text = txtReportTitle.Text
        dgView.DisplayLayout.Bands(0).Summaries.Clear()
        dgView.DataSource = InfraReporting.GetStoredProcResult(SP)


        dgView.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True
        dgView.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButtonFixedSize



        dgView.DisplayLayout.Bands(0).ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False


        dgView.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.Bottom
        dgView.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True
        dgView.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False

        dgView.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.PaleGreen
        dgView.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Teal

        dgView.DisplayLayout.Override.HeaderAppearance.FontData.SizeInPoints = 10
        dgView.DisplayLayout.Override.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True


        For i As Integer = 0 To dgView.DisplayLayout.Bands(0).Columns.Count - 1
            If dgView.DisplayLayout.Rows.Count <= 0 Then Exit For
            If dgView.DisplayLayout.Bands(0).Columns(i).DataType Is System.Type.GetType("System.Decimal") Then
                dgView.DisplayLayout.Bands(0).Columns(i).Format = "#,##0.00"
                dgView.DisplayLayout.Bands(0).Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                dgView.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, dgView.DisplayLayout.Bands(0).Columns(i)).DisplayFormat = "{0:##,##0.00#}"

            Else
                dgView.DisplayLayout.Bands(0).Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            End If
            dgView.DisplayLayout.Bands(0).Columns(i).AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.Default

            dgView.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Next

        dgView.DisplayLayout.Bands(0).SummaryFooterCaption = "Grand Total :"

        For i As Integer = 0 To dgView.DisplayLayout.Bands(0).Summaries.Count - 1
            dgView.DisplayLayout.Bands(0).Summaries(i).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        Next

        dgView.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

    End Sub

    Private Sub UCInfraReportResult_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Althea.Base.UI.Utilities.ApplyGridTheme(dgFilter)
    End Sub

    Private Sub Clear()
        dgView.DataSource = Nothing
        dgFilter.Rows.Clear()
    End Sub

    Private Sub lnkReportTitle_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkReportTitle.LinkClicked
        If cboType.SelectedIndex = -1 Then Exit Sub
        Dim tag As SelectionTag = ShowSearchDialog(InfraReporting.GetInfraReportColumns, InfraReporting.GetInfraReportSQL(cboType.SelectedIndex), "Select Report.")
        If Not tag Is Nothing Then
            Clear()

            txtReportTitle.Text = tag.KeyColumn3

            v_Report = InfraReporting.Load(tag.KeyColumn1)(0)

            lnkReportTitle.Tag = v_Report.ReportHeaderID
            txtReportTitle.Tag = v_Report.SqlStoredProc
            txtReportTitle.Text = v_Report.ReportTitle

            dgFilter.Rows.Clear()
            Dim det As ReportFilter
            For i As Integer = 0 To v_Report.ReportFilterDetails.Count - 1
                Dim row As DataGridViewRow = dgFilter.Rows(dgFilter.Rows.Add)
                det = v_Report.ReportFilterDetails(i)

                row.Tag = det.ReportFilterID
                row.Cells(colLabel.Index).Tag = det.ColumnName
                row.Cells(colLabel.Index).Value = det.FilterLabel
                row.Cells(colInputType.Index).Value = det.DataType


                If det.DataType.ToUpper = "DATETIME" Then
                    row.Cells(colValue.Index) = New DataGridViewLinkCell
                    row.Cells(colValue.Index).Value = "Select Date."
                    row.Cells(colValue.Index).ReadOnly = True
                ElseIf det.DataType.ToUpper = "VARCHAR" Then
                    row.Cells(colValue.Index) = New DataGridViewLinkCell

                    row.Cells(colValue.Index).Value = "Select Value."
                Else
                    row.Cells(colValue.Index) = New DataGridViewTextBoxCell

                    row.Cells(colValue.Index).Value = ""
                End If

                row.Cells(colValue.Index).Tag = Nothing
                row.Cells(colClear.Index).Value = "Clear"

            Next
        End If

    End Sub


    Private Sub dgFilter_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFilter.CellClick



    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        If ValidateEntries() Then
            If txtReportTitle.Tag = Nothing Then Exit Sub
            Dim SqlStoredProc As String = "Exec " & txtReportTitle.Tag & " "
            For i As Integer = 0 To dgFilter.Rows.Count - 1
                Dim row As DataGridViewRow = dgFilter.Rows(i)
                SqlStoredProc = SqlStoredProc & row.Cells(colLabel.Index).Tag & " = '" & row.Cells(colValue.Index).Tag & "',"
            Next
            SqlStoredProc = Mid(SqlStoredProc, 1, Len(SqlStoredProc) - 1)
            dgSearchDefault(SqlStoredProc)
        End If




        'If ValidateEntries() Then
        '    If txtReportTitle.Tag = Nothing Then Exit Sub
        '    Dim SqlStoredProc As String = "Exec " & txtReportTitle.Tag & " "

        '    For i As Integer = 0 To dgFilter.Rows.Count - 1
        '        Dim row As DataGridViewRow = dgFilter.Rows(i)

        '        SqlStoredProc = SqlStoredProc & row.Cells(colLabel.Index).Tag & " = '" & row.Cells(colValue.Index).Tag & "',"
        '    Next

        '    SqlStoredProc = Mid(SqlStoredProc, 1, Len(SqlStoredProc) - 1)

        '    dgSearchDefault(SqlStoredProc)

        '    dgView.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Both

        'End If
    End Sub

    Private Function ValidateEntries() As Boolean
        v_HasError = False
        For i As Integer = 0 To dgFilter.Rows.Count - 1
            Dim row As DataGridViewRow = dgFilter.Rows(i)

            If row.Cells(colInputType.Index).Value = "Date" Then
                If IsDate(row.Cells(colValue.Index).Value) = False Then
                    row.Cells(colValue.Index).Style.BackColor = Color.LightPink
                    row.Cells(colValue.Index).ToolTipText = "Invalid Date Value."
                    v_HasError = True
                Else
                    row.Cells(colValue.Index).Style.BackColor = Color.White
                    row.Cells(colValue.Index).ToolTipText = String.Empty
                    v_HasError = False
                End If
            End If

            If row.Cells(colInputType.Index).Value = "Int" Then
                If IsNumeric(row.Cells(colValue.Index).Value) = False Then
                    row.Cells(colValue.Index).Style.BackColor = Color.LightPink
                    row.Cells(colValue.Index).ToolTipText = "Invalid Numeric Value."
                    v_HasError = True
                Else
                    row.Cells(colValue.Index).Style.BackColor = Color.White
                    row.Cells(colValue.Index).ToolTipText = String.Empty
                    v_HasError = False
                End If
            End If
        Next

        Return Not v_HasError
    End Function

    Private Sub dgFilter_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFilter.CellContentClick
        Dim row As DataGridViewRow = dgFilter.Rows(e.RowIndex)
        If e.RowIndex = -1 Then Exit Sub

        If e.ColumnIndex = colClear.Index Then
            row.Cells(colValue.Index).Tag = Nothing
            row.Cells(colValue.Index).Value = String.Empty
            If row.Cells(colInputType.Index).Value.ToString.ToUpper = "DATETIME" Then
                row.Cells(colValue.Index).Value = "Select Date."
            Else
                row.Cells(colValue.Index).Value = "Select Value."
            End If
            row.Cells(colValue.Index).Tag = Nothing
            'row.Cells(colValue.Index).Value = "Select Value."
        End If
        If e.ColumnIndex = colValue.Index Then
            If row.Cells(colInputType.Index).Value.ToString.ToUpper = "DATETIME" Then
                Dim FrmCalendar As New Calendar
                FrmCalendar.ShowDialog()
                row.Cells(colValue.Index).Tag = FrmCalendar.DateValue.ToShortDateString
                row.Cells(colValue.Index).Value = FrmCalendar.DateValue.ToShortDateString
            Else
                Dim tag As SelectionTag = ShowSearchDialog(ReportFilter.GetSqlColumnsByID(row.Tag), ReportFilter.GetSqlQueryByID(row.Tag), "Select .")
                If Not tag Is Nothing Then
                    row.Cells(colValue.Index).Tag = tag.KeyColumn2
                    row.Cells(colValue.Index).Value = tag.KeyColumn2
                End If
            End If

        End If
    End Sub

    Private Sub colExporttoExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles colExporttoExcel.Click
       Dim fileName As String = Application.StartupPath & "\Reports\" & txtReportTitle.Text & " " & DateTime.Now.ToString("yyyy-MM-dd hhmmss") & ".xls"
        If IO.File.Exists(fileName) Then
            IO.File.Delete(fileName)
        End If

        'm_objBook = New Infragistics.Excel.Workbook
        'm_objBook.Worksheets.Add(txtReportTitle.Text)
        'm_objSheet = m_objBook.Worksheets(0)

        'm_objSheet.Name = m_objBook.Worksheets.Item(0).Name

        'm_objCell = m_objSheet.Rows(0).Cells(0)
        'mergedRegion1 = m_objSheet.MergedCellsRegions.Add(0, 0, 0, dgView.DisplayLayout.Bands(0).Columns.Count)
        'mergedRegion1.CellFormat.Font.Bold = Infragistics.Excel.ExcelDefaultableBoolean.True
        'mergedRegion1.CellFormat.Alignment = Infragistics.Excel.HorizontalCellAlignment.Left
        'mergedRegion1.CellFormat.Font.Height = GetFontSize(10)
        'm_objCell.Value = GlobalFunctionsModule.GetCompanyName



        'm_objCell = m_objSheet.Rows(1).Cells(0)
        'mergedRegion1 = m_objSheet.MergedCellsRegions.Add(1, 0, 1, 4)
        'mergedRegion1.CellFormat.Font.Bold = Infragistics.Excel.ExcelDefaultableBoolean.True
        'mergedRegion1.CellFormat.Alignment = Infragistics.Excel.HorizontalCellAlignment.Left
        'mergedRegion1.CellFormat.Font.Height = GetFontSize(10)
        'm_objCell.Value = m_objSheet.Name

        ''-------------------------------------------------------------------------------

        'For i As Integer = 3 To dgFilter.Rows.Count + 2
        '    Dim row As DataGridViewRow = dgFilter.Rows(i - 3)
        '    m_objCell = m_objSheet.Rows(i).Cells(0)
        '    mergedRegion1 = m_objSheet.MergedCellsRegions.Add(i, 0, i, 0)
        '    mergedRegion1.CellFormat.Font.Bold = Infragistics.Excel.ExcelDefaultableBoolean.True
        '    mergedRegion1.CellFormat.Alignment = Infragistics.Excel.HorizontalCellAlignment.Left
        '    mergedRegion1.CellFormat.Font.Height = GetFontSize(9)
        '    m_objCell.Value = row.Cells(colLabel.Index).Value


        '    m_objCell = m_objSheet.Rows(i).Cells(1)
        '    mergedRegion1 = m_objSheet.MergedCellsRegions.Add(i, 1, i, 3)
        '    mergedRegion1.CellFormat.Font.Bold = Infragistics.Excel.ExcelDefaultableBoolean.True
        '    mergedRegion1.CellFormat.Alignment = Infragistics.Excel.HorizontalCellAlignment.Left
        '    mergedRegion1.CellFormat.Font.Height = GetFontSize(9)
        '    m_objCell.Value = row.Cells(colValue.Index).Tag
        'Next

        'Me.UltraGridExcelExporter1.Export(dgView, m_objSheet, dgFilter.Rows.Count + 4, 0).Save(fileName)
        ''m_objBook.Save(fileName)

        'Process.Start(fileName)

        m_objBook = New Infragistics.Excel.Workbook
        m_objBook.Worksheets.Add(txtReportTitle.Text)
        m_objSheet = m_objBook.Worksheets(0)

        m_objSheet.Name = m_objBook.Worksheets.Item(0).Name

        m_objCell = m_objSheet.Rows(0).Cells(0)
        mergedRegion1 = m_objSheet.MergedCellsRegions.Add(0, 0, 0, dgView.DisplayLayout.Bands(0).Columns.Count)
        mergedRegion1.CellFormat.Font.Bold = Infragistics.Excel.ExcelDefaultableBoolean.True
        mergedRegion1.CellFormat.Alignment = Infragistics.Excel.HorizontalCellAlignment.Left
        mergedRegion1.CellFormat.Font.Height = GetFontSize(10)
        m_objCell.Value = GlobalFunctionsModule.GetCompanyName



        m_objCell = m_objSheet.Rows(1).Cells(0)
        mergedRegion1 = m_objSheet.MergedCellsRegions.Add(1, 0, 1, 4)
        mergedRegion1.CellFormat.Font.Bold = Infragistics.Excel.ExcelDefaultableBoolean.True
        mergedRegion1.CellFormat.Alignment = Infragistics.Excel.HorizontalCellAlignment.Left
        mergedRegion1.CellFormat.Font.Height = GetFontSize(10)
        m_objCell.Value = m_objSheet.Name

        '-------------------------------------------------------------------------------

        For i As Integer = 3 To dgFilter.Rows.Count + 2
            Dim row As DataGridViewRow = dgFilter.Rows(i - 3)
            m_objCell = m_objSheet.Rows(i).Cells(0)
            mergedRegion1 = m_objSheet.MergedCellsRegions.Add(i, 0, i, 0)
            mergedRegion1.CellFormat.Font.Bold = Infragistics.Excel.ExcelDefaultableBoolean.True
            mergedRegion1.CellFormat.Alignment = Infragistics.Excel.HorizontalCellAlignment.Left
            mergedRegion1.CellFormat.Font.Height = GetFontSize(9)
            m_objCell.Value = row.Cells(colLabel.Index).Value

            m_objCell = m_objSheet.Rows(i).Cells(1)
            mergedRegion1 = m_objSheet.MergedCellsRegions.Add(i, 1, i, 3)
            mergedRegion1.CellFormat.Font.Bold = Infragistics.Excel.ExcelDefaultableBoolean.True
            mergedRegion1.CellFormat.Alignment = Infragistics.Excel.HorizontalCellAlignment.Left
            mergedRegion1.CellFormat.Font.Height = GetFontSize(9)
            m_objCell.Value = row.Cells(colValue.Index).Tag
        Next

        Me.UltraGridExcelExporter1.Export(dgView, m_objSheet, dgFilter.Rows.Count + 4, 0).Save(fileName)
        'm_objBook.Save(fileName)

        Process.Start(fileName)
    End Sub

    Private Function GetFontSize(ByVal Size As Decimal) As Decimal
        Return Size * 20
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub dgFilter_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFilter.CellEndEdit
        Dim row As DataGridViewRow = dgFilter.Rows(e.RowIndex)
        If row.Index = -1 Then Exit Sub
        If e.ColumnIndex = colValue.Index Then
            row.Cells(colValue.Index).Tag = row.Cells(colValue.Index).Value
        End If
    End Sub

    Private Sub dgView_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dgView.InitializeLayout

    End Sub
End Class
