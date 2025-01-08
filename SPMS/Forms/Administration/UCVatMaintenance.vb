Imports SPMSOPCI.ConnectionModule


Public Class UCVatMaintenance

    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_Action As String = EnumAction.SAVE.ToString
    Private m_RsVat As New ADODB.Recordset

    Private Enum EnumAction
        SAVE = 1
        UPDATE = 2
        DELETE = 3
    End Enum

    Private Sub UCVatMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ApplyGridTheme(dgListing)
        m_Action = EnumAction.SAVE.ToString
        Clear()
        LockFields(True)
        LoadSelection()
        PopulateListingGrid()
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        m_Action = EnumAction.SAVE.ToString
        Clear()
        EditMode(True)
        LockFields(False)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If txtVatCode.Tag Is Nothing Then
            ShowExclamation("There was no record to modify", "Edit")
        Else
            EditMode(True)
            LockFields(False)
            m_Action = EnumAction.UPDATE.ToString
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If ShowQuestion("Are you sure you want to delete this record?", "Delete") = MsgBoxResult.Yes Then
            If Not txtVatCode.Tag Is Nothing Then
                m_Action = EnumAction.DELETE.ToString
                Delete(txtVatCode.Tag)
                ShowInformation("Record Successfully Deleted", "Delete")
                Clear()
                PopulateListingGrid()
                m_Action = EnumAction.SAVE.ToString
                EditMode(False)
            Else
                ShowExclamation("This record is currently not saved. Record Deletion Failed", "Delete")
            End If

        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ShowQuestion("Are you sure you want to save this record?", "Save") = MsgBoxResult.Yes Then
            If ValidateData() Then
                SaveData(IIf(txtVatCode.Tag Is Nothing, -1, txtVatCode.Tag), txtVatCode.Text, txtVat.Text, dtStart.Value.ToShortDateString, dtEnd.Value.ToShortDateString, chkIsActive.Checked)
                ShowDataForLoading(" AND VatCode = '" & HandleSingleQuoteInSql(txtVatCode.Text) & "' ")
                PopulateListingGrid()
                ShowInformation("Record Successfully Saved", "Save")
            End If
        End If
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Filter()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Chr(13) Then
            Filter()
        End If
    End Sub


    Private Sub dgListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgListing.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Dim row As DataGridViewRow = dgListing.Rows(e.RowIndex)
        ShowDataForLoading(" AND VatMaintenanceID = " & row.Tag)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    '================================================= User - Defined Functions and Sub ========================================

    Private Sub Clear()
        txtVat.Clear()
        txtVatCode.Clear()
        txtVatCode.Tag = Nothing
    End Sub

    Private Sub ShowDataForLoading(ByVal Filter As String)
        If m_RsVat.State = 1 Then m_RsVat.Close()
        m_RsVat.Open("SELECT * FROM VatMaintenance WHERE DLTFLG = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsVat.RecordCount > 0 Then
            ShowData(m_RsVat)
        End If
    End Sub

    Private Sub LockFields(ByVal IsLocked As Boolean)
        txtVat.ReadOnly = IsLocked
        txtVat.BackColor = Color.White
        txtVatCode.BackColor = Color.White
        txtVatCode.ReadOnly = IsLocked
        dtStart.Enabled = Not IsLocked
        dtEnd.Enabled = Not IsLocked
        chkIsActive.Enabled = Not IsLocked
    End Sub

    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnAdd.Enabled = Not IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnDelete.Enabled = IsEditMode
    End Sub

    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False

        If txtVatCode.Text = "" Then
            m_Err.SetError(txtVatCode, "Vat Code is required")
            m_HasError = True
        Else
            If CheckIfRecordExist(txtVatCode.Text, IIf(txtVatCode.Tag Is Nothing, -1, txtVatCode.Tag)) Then
                m_Err.SetError(txtVatCode, "Vat Code Already Exist")
                m_HasError = True
            End If
        End If

        If txtVat.Text = "" Then
            m_Err.SetError(txtVat, "Vat is required")
            m_HasError = True
        Else
            If Not IsNumeric(txtVat.Text) Then
                m_Err.SetError(txtVat, "Value must be numeric")
                m_HasError = True
            End If
        End If

        If CDate(dtStart.Value.ToShortDateString) > CDate(dtEnd.Value.ToShortDateString) Then
            m_Err.SetError(dtStart, "Effectivity Start Date should not be grater than the effectivity end date")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function

    Private Function CheckIfRecordExist(ByVal VatCode As String, ByVal VatMaintenanceID As Integer) As Boolean
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT 'A' FROM VatMaintenance WHERE DLTFLG = 0 AND VatCode = '" & HandleSingleQuoteInSql(VatCode) & "' AND  VatMaintenanceID <> " & VatMaintenanceID & " ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SaveData(ByVal VatMaintenanceID As Integer, ByVal VatCode As String, ByVal Vat As Double, ByVal StartDate As Date, ByVal EndDate As Date, ByVal IsActive As Boolean)

        Try

            SPMSConn.Execute("EXEC uspVatMaintenance @Action = '" & m_Action & "' , @VatMaintenanceID = " & VatMaintenanceID & " ," & _
                                                                " @VatCode = '" & HandleSingleQuoteInSql(VatCode) & "' , @Vat = " & Vat & " , @EffectivityStartDate = '" & StartDate & "', @EffectivityEndDate = '" & EndDate & "' ," & _
                                                                " @IsActive = " & IIf(IsActive = True, "1", "0"))

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub Delete(ByVal VatMaintenanceID As Integer)
        Try
            SPMSConn.Execute("EXEC uspVatMaintenance @Action = '" & m_Action & "', @VatMaintenanceID = " & VatMaintenanceID & " ")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub ShowData(ByVal rs As ADODB.Recordset)
        txtVatCode.Text = rs.Fields("VatCode").Value
        txtVatCode.Tag = rs.Fields("VatMaintenanceID").Value
        txtVat.Text = rs.Fields("Vat").Value
        chkIsActive.Checked = rs.Fields("IsActive").Value
        dtStart.Value = CDate(rs.Fields("EffectivityStartDate").Value).ToShortDateString
        dtEnd.Value = CDate(rs.Fields("EffectivityEndDate").Value).ToShortDateString
        EditMode(False)
        LockFields(True)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub LoadSelection()
        cboSelection.Items.Clear()
        For m As Integer = 0 To dgListing.ColumnCount - 1
            If dgListing.Columns(m).HeaderText <> "Status" Then
                cboSelection.Items.Add(dgListing.Columns(m).HeaderText)
            End If
        Next
    End Sub

    Private Sub Filter()
        Dim filter As String = ""
        If Not cboSelection.Text = "" Then
            If cboSelection.Text = "Vat Code" Then
                filter = " AND VatCode like '%" & txtFilter.Text & "%'"
            End If
            If cboSelection.Text = "Vat (%)" Then
                filter = " AND Vat  =  " & txtFilter.Text & " "
            End If
            If cboSelection.Text = "Effectivity Start Date" Then
                If IsDate(txtFilter.Text) Then
                    filter = "AND EffectivityStartDate = '" & txtFilter.Text & "' "
                Else
                    ShowExclamation("Must be a valid Date", "Filter")
                End If
            End If
            If cboSelection.Text = "Effectivity End Date" Then
                If IsDate(txtFilter.Text) Then
                    filter = "AND EffectivityEndDate = '" & txtFilter.Text & "' "
                Else
                    ShowExclamation("Must be a valid Date", "Filter")
                End If
            End If
            PopulateListingGrid(filter)
        End If
    End Sub
    Private Sub PopulateListingGrid(Optional ByVal Filter As String = "")

        If m_RsVat.State = 1 Then m_RsVat.Close()
        m_RsVat.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        m_RsVat.Open("SELECT * FROM VatMaintenance WHERE DLTFLG = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsVat.RecordCount > 0 Then
            PopulateGrid(m_RsVat)
        End If

    End Sub

    Private Sub PopulateGrid(ByVal rs As ADODB.Recordset)

        dgListing.Rows.Clear()
        For m As Integer = 0 To rs.RecordCount - 1
            Dim row As DataGridViewRow = dgListing.Rows(dgListing.Rows.Add)
            row.Cells(colVatCode.Index).Value = rs.Fields("VatCode").Value
            row.Cells(colVat.Index).Value = rs.Fields("Vat").Value
            row.Cells(colEffectivityStartDate.Index).Value = CDate(rs.Fields("EffectivityStartDate").Value).ToShortDateString
            row.Cells(colEffectivityEndDate.Index).Value = CDate(rs.Fields("EffectivityEndDate").Value).ToShortDateString
            row.Cells(colStatus.Index).Value = IIf(rs.Fields("IsActive").Value = True, "Active", "Inactive")
            row.Tag = rs.Fields("VatMaintenanceID").Value
            rs.MoveNext()
        Next

    End Sub


End Class
