Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Public Class UIExpense
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_Expense As New Expense
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Sub Clear()
        m_Err.Clear()
        GridViewDetails.Rows.Clear()
        txtExpenseNumber.Text = String.Empty
        txtRemarks.Text = String.Empty
        txtSalesAgentCode.Text = String.Empty
        txtSalesAgentCode.Tag = Nothing
        txtSalesAgentName.Text = String.Empty
        txtVat.Text = "0.00"
        txtVatEx.Text = "0.00"
        txtVatInc.Text = "0.00"
    End Sub
    Public Sub NewRecord()
        Clear()
        txtExpenseNumber.Text = SystemSequences.GetExpenseNextSequence
        EditMode(True)
    End Sub
    Public Sub EditMode(ByVal IsEditMode As Boolean)
        If m_Expense.Status = Expense.EnumExpenseStatus.Approved Then
            btnApproved.Enabled = False
            btnDelete.Enabled = False
            btnEdit.Enabled = False
        Else
            btnEdit.Enabled = Not IsEditMode
            btnApproved.Enabled = False
            btnDelete.Enabled = Not IsEditMode
        End If

        btnSave.Enabled = IsEditMode

        txtRemarks.ReadOnly = Not IsEditMode
        txtRemarks.BackColor = Color.White

        lnkSalesAgent.Enabled = IsEditMode

        For Each row As GridViewRowInfo In GridViewDetails.Rows
            row.Cells(1).ReadOnly = Not IsEditMode
            row.Cells(2).ReadOnly = Not IsEditMode
            row.Cells(3).ReadOnly = Not IsEditMode
        Next
    End Sub
    'Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnEdit.Click, btnApproved.Click, btnClose.Click, btnDelete.Click, btnFind.Click, btnSave.Click
    '    If sender Is btnApproved Then
    '    ElseIf sender Is btnClose Then
    '        Close()
    '    ElseIf sender Is btnDelete Then
    '        Delete()
    '    ElseIf sender Is btnEdit Then
    '        EditMode(True)
    '        'ElseIf sender Is btnFind Then
    '        '    FindRecord()
    '    ElseIf sender Is btnNew Then
    '        NewRecord()
    '        'ElseIf sender Is btnSave Then
    '        '    If ValidateData() Then
    '        '        SaveData()
    '        '    End If
    '    End If
    'End Sub
    Public Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Public Sub Delete()
        If ShowQuestion("Are you sure you want to delete this record?", "Delete") = MsgBoxResult.Yes Then
            If m_Expense.Delete Then
                ShowInformation("Record Sucessfully Deleted.", "Delete")
                NewRecord()
            Else
                ShowExclamation("Record not deleted.", "Delete")
            End If
        End If
    End Sub
    'Public Sub FindRecord()
    '    Dim tag As SelectionTag = ShowSearchDialog(Expense.GetExpenseColumns, Expense.GetExpenseSql, "Expense")
    '    If Not tag Is Nothing Then
    '        Clear()
    '        ShowData(tag.KeyColumn1)
    '        EditMode(False)
    '    End If
    'End Sub
    Public Sub SaveData()
        'Dim det As ExpenseDetails
        'For m As Integer = 0 To GridViewDetails.Rows.Count - 1
        '    Dim row As GridViewRowInfo = GridViewDetails.Rows(m)
        '    If row.Tag Is Nothing Then
        '        det = New ExpenseDetails
        '        m_Expense.ExpenseDetailsCollection.Add(det)
        '        row.Tag = det
        '    Else
        '        det = row.Tag
        '    End If

        '    det.ExpenseAmount = row.Cells(colAmount.Index).Value
        '    det.ExpenseTypeCode = row.Cells(colExpense.Index).Tag
        '    det.VAT = row.Cells(colVat.Index).Value
        '    det.ExpenseDate = row.Cells(colExpenseDate.Index).Value
        '    det.Remarks = row.Cells(colRemarks.Index).Value
        'Next
        'm_Expense.SalesAgentCode = txtSalesAgentCode.Text
        'm_Expense.EntryNumber = txtExpenseNumber.Text
        'm_Expense.ExpenseDate = dtExpenseDate.Value.ToShortDateString
        'm_Expense.Remarks = txtRemarks.Text
        'm_Expense.SalesAgentCode = txtSalesAgent.Tag
        'm_Expense.TotalVat = txtVat.Text
        'm_Expense.VatExclusiveAmount = txtVatEx.Text
        'm_Expense.VatInclusiveAmount = txtVatInc.Text

        'If m_Expense.Save Then
        '    ShowInformation("Record Successfully Save", "Save")
        '    ShowData(m_Expense.ExpenseID)
        '    EditMode(False)
        'Else
        '    ShowExclamation("Record not Saved.", "Save")
        'End If

    End Sub

    Private Sub RadGridView1_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles RadGridView1.CellDoubleClick

    End Sub

    Private Sub RadGridView1_Click(sender As Object, e As EventArgs) Handles RadGridView1.Click

    End Sub
End Class
