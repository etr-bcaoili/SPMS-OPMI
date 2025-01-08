Imports DataLayer
Imports JLCLibrary.Utils

Public Class UCInfraReport
    Inherits Althea.Base.UI.BasePage


    Private v_InfraReport As New InfraReporting

    Private v_hasError As Boolean = False

    Private v_Err As New ErrorProvider

    Private Sub NewRecord()
        v_InfraReport = New InfraReporting
        Clear()
        EditMode(True)
    End Sub

    Private Sub Clear()
        cboType.SelectedIndex = -1
        txtReportTitle.Text = String.Empty
        txtCode.Text = String.Empty
        txtDescription.Text = String.Empty
        txtSqlStoredProc.Tag = Nothing
        txtSqlStoredProc.Text = String.Empty

        dgFilters.DataSource = Nothing

        chkActive.Checked = True
    End Sub

    Private Sub EditMode(ByVal State As Boolean)
        btnSave.Enabled = State
        btnEdit.Enabled = Not State
        btnDelete.Enabled = State

        txtReportTitle.BackColor = Color.White
        txtReportTitle.ReadOnly = Not State

        txtCode.BackColor = Color.White
        txtCode.ReadOnly = Not State

        txtDescription.BackColor = Color.White
        txtDescription.ReadOnly = Not State

        lnkSqlStoredProc.Enabled = State

        For j As Integer = 0 To dgFilters.Rows.Count - 1
            Dim row As DataGridViewRow = dgFilters.Rows(j)
            row.Cells(colLabel.Index).ReadOnly = Not State
            row.Cells(colColumnName.Index).ReadOnly = Not State
            row.Cells(colDataType.Index).ReadOnly = Not State
        Next j


    End Sub

    Private Sub lnkSqlStoredProc_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSqlStoredProc.LinkClicked
        Dim tag As SelectionTag = ShowSearchDialog(InfraReporting.GetStoredProcedureColumns, InfraReporting.GetStoreProcedureSQL, "Select Stored Procedure.")
        If Not tag Is Nothing Then
            txtSqlStoredProc.Tag = tag.KeyColumn2
            txtSqlStoredProc.Text = tag.KeyColumn2

            dgFilters.DataSource = InfraReporting.GetSPParameter(tag.KeyColumn2)
        End If
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        If cboType.SelectedIndex = -1 Then Exit Sub
        Dim tag As SelectionTag = ShowSearchDialog(InfraReporting.GetInfraReportColumns, InfraReporting.GetInfraReportSQL, "Select Report.")
        If Not tag Is Nothing Then
            Clear()

            v_InfraReport = InfraReporting.Load(tag.KeyColumn1)(0)

            txtReportTitle.Tag = tag.KeyColumn1
            txtReportTitle.Text = v_InfraReport.ReportTitle
            txtCode.Text = v_InfraReport.Code
            txtDescription.Text = v_InfraReport.Description
            txtSqlStoredProc.Tag = v_InfraReport.SqlStoredProc
            txtSqlStoredProc.Text = v_InfraReport.SqlStoredProc

            ShowDetail()
        End If
    End Sub

    Private Sub ShowDetail()
        Dim det As ReportFilter
        For i As Integer = 0 To v_InfraReport.ReportFilterDetails.Count - 1
            det = v_InfraReport.ReportFilterDetails(i)
            Dim row As DataGridViewRow = dgFilters.Rows(dgFilters.Rows.Add)


            row.Cells(colLabel.Index).Value = det.FilterLabel
            row.Cells(colColumnName.Index).Value = det.ColumnName
            row.Cells(colDataType.Index).Value = det.DataType

            row.Tag = det
        Next
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        NewRecord()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateEntries() Then
            SaveData()
        End If
    End Sub

    Private Function ValidateEntries() As Boolean
        v_hasError = False
        v_Err.Clear()
        If cboType.SelectedIndex = -1 Then
            v_Err.SetError(cboType, "Type is required.")
            v_hasError = True
        End If
        If txtReportTitle.Text = String.Empty Then
            v_Err.SetError(txtReportTitle, "Report Title is required.")
            v_hasError = True
        End If

        If txtCode.Text = String.Empty Then
            v_Err.SetError(txtCode, "Code is required.")
            v_hasError = True
        End If

        If InfraReporting.CheckIfCodeExist(txtCode.Text) Then
            v_Err.SetError(txtCode, "Code Already Exist.")
            v_hasError = True
        End If

        If txtDescription.Text = String.Empty Then
            v_Err.SetError(txtDescription, "Description is required.")
            v_hasError = True
        End If

        If txtSqlStoredProc.Tag = Nothing Then
            v_Err.SetError(txtSqlStoredProc, "SQL Stored Procedure is required.")
            v_hasError = True
        End If

        For i As Integer = 0 To dgFilters.Rows.Count - 1
            Dim row As DataGridViewRow = dgFilters.Rows(i)

            If row.Cells(colLabel.Index).Value = String.Empty Then
                row.Cells(colLabel.Index).Style.BackColor = Color.LightPink
                row.Cells(colLabel.Index).ToolTipText = "Label is required."
                v_hasError = True
            Else
                row.Cells(colLabel.Index).Style.BackColor = Color.White
                row.Cells(colLabel.Index).ToolTipText = String.Empty
            End If

            If row.Cells(colColumnName.Index).Value = String.Empty Then
                row.Cells(colColumnName.Index).Style.BackColor = Color.LightPink
                row.Cells(colColumnName.Index).ToolTipText = "Column Name is required."
                v_hasError = True
            Else
                row.Cells(colColumnName.Index).Style.BackColor = Color.White
                row.Cells(colColumnName.Index).ToolTipText = String.Empty
            End If

            If row.Cells(colDataType.Index).Value = String.Empty Then
                row.Cells(colDataType.Index).Style.BackColor = Color.LightPink
                row.Cells(colDataType.Index).ToolTipText = "DataType is required."
                v_hasError = True
            Else
                row.Cells(colDataType.Index).Style.BackColor = Color.White
                row.Cells(colDataType.Index).ToolTipText = String.Empty
            End If
        Next

        Return Not v_hasError
    End Function

    Private Sub SaveData()
        v_InfraReport.Type = cboType.SelectedIndex
        v_InfraReport.ReportTitle = txtReportTitle.Text
        v_InfraReport.Code = txtCode.Text
        v_InfraReport.Description = txtDescription.Text
        v_InfraReport.SqlStoredProc = txtSqlStoredProc.Text
        v_InfraReport.IsDeleted = Not chkActive.Checked

        Dim det As ReportFilter
        For i As Integer = 0 To dgFilters.Rows.Count - 1
            Dim row As DataGridViewRow = dgFilters.Rows(i)
            det = row.Tag
            If row.Tag Is Nothing Then
                det = New ReportFilter
                v_InfraReport.ReportFilterDetails.Add(det)

            Else
                det = row.Tag
            End If
            det.ReportHeaderCode = txtCode.Text
            det.FilterLabel = row.Cells(colLabel.Index).Value
            det.ColumnName = row.Cells(colColumnName.Index).Value
            det.DataType = row.Cells(colDataType.Index).Value

            det.SqlColumns = row.Cells(colSqlColumns.Index).Value
            det.SqlQuery = row.Cells(colSqlQuery.Index).Value
            det.Search = row.Cells(colSearchTo.Index).Tag
        Next

        If v_InfraReport.Save() Then
            ShowInformation("Saved", "Report Maintenance.")
        Else
            ShowInformation("Record not save", "Report Maintenance.")
        End If
    End Sub

    Private Sub UCInfraReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Althea.Base.UI.Utilities.ApplyGridTheme(dgFilters)
        dgFilters.AutoGenerateColumns = False
        NewRecord()
    End Sub

    Private Sub lnkTableColumns_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub dgFilters_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFilters.CellContentClick
        Dim row As DataGridViewRow = dgFilters.Rows(e.RowIndex)
        Dim SelectColumns As New SelectColumns
        If e.ColumnIndex = colSearchTo.Index Then
            Dim tag As SelectionTag = ShowSearchDialog(InfraReporting.GetAllTablesColumn, InfraReporting.GetAllTablesSql, "Select Table.")
            If Not tag Is Nothing Then
                row.Cells(colSearchTo.Index).Tag = tag.KeyColumn2
                row.Cells(colSearchTo.Index).Value = tag.KeyColumn2
                ''SelectColumns.TableName = tag.KeyColumn2
                ''SelectColumns.ShowDialog()
                ''row.Cells(colSqlColumns.Index).Value = SelectColumns.SqlColumns
                ''row.Cells(colSqlQuery.Index).Value = SelectColumns.SqlQuery
            End If
        ElseIf e.ColumnIndex = colSqlColumns.Index Then
            If Not row.Cells(colSearchTo.Index).Tag = Nothing Then
                SelectColumns.TableName = row.Cells(colSearchTo.Index).Tag
                SelectColumns.ShowDialog()
                If SelectColumns.SqlColumns <> "Select Columns." Then
                    row.Cells(colSqlColumns.Index).Value = SelectColumns.SqlColumns
                    row.Cells(colSqlQuery.Index).Value = SelectColumns.SqlQuery
                End If

            End If

        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub dgFilters_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFilters.RowEnter
        On Error Resume Next
        Dim row As DataGridViewRow = dgFilters.Rows(e.RowIndex)
        'row.Cells(colLabel.Index).Value = row.Cells(colColumnName.Index).Value.ToString.Substring(2, Len(row.Cells(colColumnName.Index).Value))
        If row.Cells(colDataType.Index).Value.ToString.ToUpper = "DATETIME" Then
            row.Cells(colSearchTo.Index) = New DataGridViewTextBoxCell
            row.Cells(colSearchTo.Index).Tag = Nothing
            row.Cells(colSearchTo.Index).Value = ""
            row.Cells(colSearchTo.Index).ReadOnly = True
        ElseIf row.Cells(colDataType.Index).Value.ToString.ToUpper = "VARCHAR" Then
            row.Cells(colSearchTo.Index) = New DataGridViewLinkCell
            row.Cells(colSearchTo.Index).Tag = Nothing
            row.Cells(colSearchTo.Index).Value = "Select Value."

            row.Cells(colSqlColumns.Index) = New DataGridViewLinkCell
            row.Cells(colSqlColumns.Index).Tag = Nothing
            row.Cells(colSqlColumns.Index).Value = "Select Columns."
            'Else
            'row.Cells(colSearchTo.Index) = New DataGridViewTextBoxCell
        Else
            'row.Cells(colSearchTo.Index) = New DataGridViewLinkCell
            'row.Cells(colSearchTo.Index).Tag = Nothing
            'row.Cells(colSearchTo.Index).Value = "Select Value."
            row.Cells(colSearchTo.Index).ReadOnly = True

            row.Cells(colSqlColumns.Index).ReadOnly = True

            'row.Cells(colSqlColumns.Index) = New DataGridViewLinkCell
            'row.Cells(colSqlColumns.Index).Tag = Nothing
            'row.Cells(colSqlColumns.Index).Value = "Select Columns."
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Delete()
    End Sub

    Private Sub Delete()
        If v_InfraReport.Delete Then
            Dialogs.ShowInformation("Succesfully Delete.", "Delete")
        Else
            Dialogs.ShowExclamation("Delete Failed.", "Deleted")
        End If
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
