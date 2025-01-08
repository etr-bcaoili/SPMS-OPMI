Public Class UCExpense

    Implements IStandardPage

    Private m_Expense As New Expense
    Private m_ExpenseRawdata As New ExpenseRawData
    Private m_HasError As Boolean = False
    Private m_Err As New ErrorProvider
    Private m_ExpenseTypeCache As New ExpenseTypeCache
    Private m_ForDeletes As New ForDeletesCollection

    Private m_IsEdit As Boolean = False

    Public Sub Clear() Implements IStandardPage.Clear
        m_Err.Clear()
        dgDetails.Rows.Clear()
        txtCode.Text = String.Empty
        txtDescription.Text = String.Empty
        txtExpenseNumber.Text = String.Empty
        txtRemarks.Text = String.Empty
        txtSalesAgent.Text = String.Empty
        txtSalesAgent.Tag = Nothing
        txtVat.Text = "0.00"
        txtVatEx.Text = "0.00"
        txtVatInc.Text = "0.00"
    End Sub

    Public Sub Close() Implements IStandardPage.Close
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Public Sub Delete() Implements IStandardPage.Delete
        If ShowQuestion("Are you sure you want to delete this record?", "Delete") = MsgBoxResult.Yes Then
            If m_Expense.Delete Then
                ShowInformation("Record Sucessfully Deleted.", "Delete")
                NewRecord()
            Else
                ShowExclamation("Record not deleted.", "Delete")
            End If
        End If
    End Sub

    Public Function EditMode(ByVal IsEditMode As Boolean) As Boolean Implements IStandardPage.EditMode
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
        lnkDeleteSelected.Enabled = IsEditMode

        For Each row As DataGridViewRow In dgDetails.Rows
            row.Cells(colAmount.Index).ReadOnly = Not IsEditMode
            row.Cells(colVat.Index).ReadOnly = Not IsEditMode
            row.Cells(colRemarks.Index).ReadOnly = Not IsEditMode
        Next

        m_IsEdit = IsEditMode

    End Function

    Public Sub FindRecord() Implements IStandardPage.FindRecord
        Dim tag As SelectionTag = ShowSearchDialog(Expense.GetExpenseColumns, Expense.GetExpenseSql, "Expense")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn1)
            EditMode(False)
        End If
    End Sub

    Public Sub NewRecord() Implements IStandardPage.NewRecord
        Clear()
        txtExpenseNumber.Text = SystemSequences.GetExpenseNextSequence
        EditMode(True)
    End Sub

    Public Sub SaveData() Implements IStandardPage.SaveData
        Dim det As ExpenseDetails

        For m As Integer = 0 To dgDetails.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetails.Rows(m)
            If row.Tag Is Nothing Then
                det = New ExpenseDetails
                m_Expense.ExpenseDetailsCollection.Add(det)
                row.Tag = det
            Else
                det = row.Tag
            End If

            det.ExpenseAmount = row.Cells(colAmount.Index).Value
            det.ExpenseTypeCode = row.Cells(colExpense.Index).Tag
            det.VAT = row.Cells(colVat.Index).Value
            det.ExpenseDate = row.Cells(colExpenseDate.Index).Value
            det.Remarks = row.Cells(colRemarks.Index).Value
        Next
        m_Expense.SalesAgentCode = txtsalesagentcode.Text
        m_Expense.EntryNumber = txtExpenseNumber.Text
        m_Expense.ExpenseDate = dtExpenseDate.Value.ToShortDateString
        m_Expense.Remarks = txtRemarks.Text
        m_Expense.SalesAgentCode = txtSalesAgent.Tag
        m_Expense.TotalVat = txtVat.Text
        m_Expense.VatExclusiveAmount = txtVatEx.Text
        m_Expense.VatInclusiveAmount = txtVatInc.Text

        If m_Expense.Save Then
            ShowInformation("Record Successfully Save", "Save")
            ShowData(m_Expense.ExpenseID)
            EditMode(False)
        Else
            ShowExclamation("Record not Saved.", "Save")
        End If

    End Sub

    Public Sub ShowData(ByVal RecordID As Integer) Implements IStandardPage.ShowData


        m_Expense = Expense.Load(RecordID)

        txtExpenseNumber.Text = m_Expense.EntryNumber
        txtRemarks.Text = m_Expense.Remarks
        txtSalesAgent.Text = MedicalRep.GetSalesAgentName(m_Expense.SalesAgentCode)
        txtsalesagentcode.Text = m_Expense.SalesAgentCode
        txtSalesAgent.Tag = m_Expense.SalesAgentCode
        dtExpenseDate.Value = m_Expense.ExpenseDate.ToShortDateString

        txtVat.Text = m_Expense.TotalVat.ToString("#,##0.0000")
        txtVatEx.Text = m_Expense.VatExclusiveAmount.ToString("#,##0.0000")
        txtVatInc.Text = m_Expense.VatInclusiveAmount.ToString("#,##0.0000")

        dgDetails.Rows.Clear()

        For m As Integer = 0 To m_Expense.ExpenseDetailsCollection.Count - 1
            Dim det As ExpenseDetails = m_Expense.ExpenseDetailsCollection(m)
            Dim row As DataGridViewRow = dgDetails.Rows(dgDetails.Rows.Add)
            row.Cells(colExpense.Index).Value = Particulars.GetParticualrDescription(det.ExpenseTypeCode, Particulars.EnumParticularType.Expense)
            row.Cells(colExpense.Index).Tag = det.ExpenseTypeCode
            row.Cells(colAmount.Index).Value = det.ExpenseAmount.ToString("#,##0.0000")
            row.Cells(colVat.Index).Value = det.VAT.ToString("#,##0.0000")
            row.Cells(colVatEx.Index).Value = (det.ExpenseAmount - det.VAT).ToString("#,##0.0000")
            row.Cells(colExpenseDate.Index).Value = det.ExpenseDate.ToShortDateString
            row.Cells(colRemarks.Index).Value = det.Remarks
            row.Tag = det
        Next

    End Sub

    Public Sub Undo() Implements IStandardPage.Undo

    End Sub

    Public Function ValidateData() As Boolean Implements IStandardPage.ValidateData
        m_HasError = False
        m_Err.Clear()
        lblErrorMessage.Visible = False
        Dim m_WithDetErr As Boolean = False

        If txtSalesAgent.Tag Is Nothing Then
            m_Err.SetError(txtSalesAgent, "Sales Agent is required.")
            m_HasError = True
        End If


        For m As Integer = 0 To dgDetails.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetails.Rows(m)

            If Not IsNumeric(row.Cells(colAmount.Index).Value) Then
                row.Cells(colAmount.Index).Style.BackColor = Color.LightPink
                row.Cells(colAmount.Index).ToolTipText = "Value must be numeric"
                m_HasError = True
                m_WithDetErr = True
            Else
                row.Cells(colAmount.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                row.Cells(colAmount.Index).ToolTipText = String.Empty
            End If
            If Not IsNumeric(row.Cells(colVat.Index).Value) Then
                row.Cells(colVat.Index).Style.BackColor = Color.LightPink
                row.Cells(colVat.Index).ToolTipText = "Value must be numeric"
                m_HasError = True
                m_WithDetErr = True
            Else
                row.Cells(colVat.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                row.Cells(colVat.Index).ToolTipText = String.Empty
            End If

            If row.Cells(colExpenseDate.Index).Value = String.Empty Or row.Cells(colExpenseDate.Index).Value Is Nothing Then
                row.Cells(colExpenseDate.Index).Style.BackColor = Color.LightPink
                row.Cells(colExpenseDate.Index).ToolTipText = "Value must be a valid date."
                m_HasError = True
                m_WithDetErr = True
            Else
                If Not IsDate(row.Cells(colExpenseDate.Index).Value) Then
                    row.Cells(colExpenseDate.Index).Style.BackColor = Color.LightPink
                    row.Cells(colExpenseDate.Index).ToolTipText = "Value must be a valid date."
                    m_HasError = True
                    m_WithDetErr = True
                Else
                    row.Cells(colExpenseDate.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                    row.Cells(colExpenseDate.Index).ToolTipText = String.Empty
                End If
            End If

        Next

        If m_WithDetErr Then
            lblErrorMessage.Visible = True
        End If


        Return Not m_HasError
    End Function

    Private Sub UCExpense_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(dgDetails)
        ApplyGridTheme(dgExpenses)
        m_ExpenseTypeCache.InitializedCache()
        dgExpenses.AutoGenerateColumns = False
        NewRecord()
        FilterExpenseType()
    End Sub

    Private Sub FilterExpenseType()
        m_ExpenseTypeCache.ExpenseCode = txtCode.Text
        m_ExpenseTypeCache.ExpenseDescription = txtDescription.Text
        dgExpenses.DataSource = m_ExpenseTypeCache.FilterDv
    End Sub

    Private Sub lnkSalesAgent_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSalesAgent.LinkClicked
        Dim tag As SelectionTag = ShowSearchDialog(MedicalRep.GetMedicalRepColumns, MedicalRep.GetMedicalRepSql, "Medical Rep")
        If Not tag Is Nothing Then
            txtSalesAgent.Text = tag.KeyColumn3
            txtSalesAgent.Tag = tag.KeyColumn2
        End If
    End Sub

    Private Sub txtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged, txtDescription.TextChanged
        FilterExpenseType()
    End Sub

    Private Sub dgExpenses_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgExpenses.CellDoubleClick
        If Not m_IsEdit Then Exit Sub
        If e.RowIndex = -1 Then Exit Sub
        Dim rowexp As DataGridViewRow = dgExpenses.Rows(e.RowIndex)
        Dim row As DataGridViewRow = dgDetails.Rows(dgDetails.Rows.Add)

        row.Cells(colExpense.Index).Value = rowexp.Cells(colDescription.Index).Value
        row.Cells(colExpense.Index).Tag = rowexp.Cells(colCode.Index).Value

        row.Cells(colVat.Index).Value = "0.0000"
        row.Cells(colAmount.Index).Value = "0.0000"
        row.Cells(colVatEx.Index).Value = "0.0000"
    End Sub

    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        If Not m_IsEdit Then Exit Sub
        Dim rowexp As DataGridViewRow = dgExpenses.Rows(dgExpenses.CurrentRow.Index)
        Dim row As DataGridViewRow = dgDetails.Rows(dgDetails.Rows.Add)

        row.Cells(colExpense.Index).Value = rowexp.Cells(colDescription.Index).Value
        row.Cells(colExpense.Index).Tag = rowexp.Cells(colCode.Index).Value

        row.Cells(colVat.Index).Value = "0.0000"
        row.Cells(colAmount.Index).Value = "0.0000"
        row.Cells(colVatEx.Index).Value = "0.0000"
    End Sub

    Private Sub dgDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick

    End Sub

    Private Sub dgDetails_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellEndEdit
        If e.RowIndex = -1 Then Exit Sub

        Dim row As DataGridViewRow = dgDetails.Rows(e.RowIndex)

        If e.ColumnIndex = colAmount.Index Then

            If IsNumeric(row.Cells(colAmount.Index).Value) Then
                Dim amt As Double = row.Cells(colAmount.Index).Value
                row.Cells(colAmount.Index).Value = amt.ToString("#,##0.0000")
                RecomputeTotals()

            End If
        ElseIf e.ColumnIndex = colVat.Index Then
            If IsNumeric(row.Cells(colVat.Index).Value) Then
                Dim amt As Double = row.Cells(colVat.Index).Value
                row.Cells(colVat.Index).Value = amt.ToString("#,##0.0000")
                RecomputeTotals()

            End If
        End If

    End Sub

    Private Sub RecomputeTotals()

        Dim m_TotalVat As Double = 0
        Dim m_VatEx As Double = 0
        Dim m_VatInc As Double = 0

        For m As Integer = 0 To dgDetails.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetails.Rows(m)
            If IsNumeric(row.Cells(colAmount.Index).Value) Then
                m_VatInc += row.Cells(colAmount.Index).Value
            End If
            If IsNumeric(row.Cells(colVat.Index).Value) Then
                m_TotalVat += row.Cells(colVat.Index).Value
            End If
            If IsNumeric(row.Cells(colAmount.Index).Value) And IsNumeric(row.Cells(colVat.Index).Value) Then
                row.Cells(colVatEx.Index).Value = (CDbl(row.Cells(colAmount.Index).Value) - CDbl(row.Cells(colVat.Index).Value)).ToString("#,##0.0000")
                m_VatEx += row.Cells(colVatEx.Index).Value
            End If

        Next

        txtVat.Text = m_TotalVat.ToString("#,##0.0000")
        txtVatEx.Text = m_VatEx.ToString("#,##0.0000")
        txtVatInc.Text = m_VatInc.ToString("#,##0.0000")
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnEdit.Click, btnApproved.Click, btnClose.Click, btnDelete.Click, btnFind.Click, btnSave.Click
        If sender Is btnApproved Then
        ElseIf sender Is btnClose Then
            Close()
        ElseIf sender Is btnDelete Then
            Delete()
        ElseIf sender Is btnEdit Then
            EditMode(True)
        ElseIf sender Is btnFind Then
            FindRecord()
        ElseIf sender Is btnNew Then
            NewRecord()
        ElseIf sender Is btnSave Then
            If ValidateData() Then
                SaveData()
            End If
        End If

    End Sub


    Private Sub DeleteSelected()
        m_ForDeletes.Clear()
        Dim m_HasSelected As Boolean = False
        For m As Integer = 0 To dgDetails.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetails.Rows(m)
            If row.Cells(colSelect.Index).Value = True Then
                m_HasSelected = True
                Exit For
            End If
        Next

        If m_HasSelected And ShowQuestion("Are you sure you want to delete the selected items?", "Delete Selected") = MsgBoxResult.Yes Then
            For m As Integer = 0 To dgDetails.Rows.Count - 1
                Dim row As DataGridViewRow = dgDetails.Rows(m)
                If row.Cells(colSelect.Index).Value = True Then
                    If Not row.Tag Is Nothing Then
                        Dim det As ExpenseDetails = row.Tag
                        det.MarkForDelete = True
                    End If
                    m_ForDeletes.Add.ID = m
                End If
            Next

            For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
                dgDetails.Rows.RemoveAt(m_ForDeletes(m).ID)
            Next
            RecomputeTotals()
        End If

    End Sub

    Private Sub lnkDeleteSelected_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkDeleteSelected.LinkClicked
        DeleteSelected()

    End Sub

    Private Sub dgExpenses_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgExpenses.CellContentClick

    End Sub
End Class
