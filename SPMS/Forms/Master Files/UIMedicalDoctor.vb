Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.WinControls.UI
Imports Telerik.Windows
Imports Telerik.WinControls
Public Class UIMedicalDoctor
    Private _MedicalDoctor As New MedicalDoctor_Seniorcitizens
    Private _MedicalDoctor_Seniorcitizens As New MedicalDoctor_SeniorcitizensCollection
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Dim table As New DataTable
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnUpdate.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtMDNumber.ReadOnly = Not IsEditMode
        txtMDNumber.BackColor = Color.White

        txtLastName.ReadOnly = Not IsEditMode
        txtLastName.BackColor = Color.White

        txtSuffix.ReadOnly = Not IsEditMode
        txtSuffix.BackColor = Color.White

        txtFirstName.ReadOnly = Not IsEditMode
        txtFirstName.BackColor = Color.White


        txtMiddleName.ReadOnly = Not IsEditMode
        txtMiddleName.BackColor = Color.White

        txtAddressLine1.ReadOnly = Not IsEditMode
        txtAddressLine1.BackColor = Color.White

        txtAddressLine2.ReadOnly = Not IsEditMode
        txtAddressLine2.BackColor = Color.White

        txtPTRNO.ReadOnly = Not IsEditMode
        txtPTRNO.BackColor = Color.White


    End Sub
    Private Sub Clear()
        txtMDNumber.Text = String.Empty
        txtLastName.Text = String.Empty
        txtSuffix.Text = String.Empty
        txtFirstName.Text = String.Empty
        txtMiddleName.Text = String.Empty
        txtAddressLine1.Text = String.Empty
        txtAddressLine2.Text = String.Empty
        txtPTRNO.Text = String.Empty
        GrdViewBranch.Rows.Clear()
    End Sub
    Private Sub NewRecord()
        Clear()
        _MedicalDoctor = New MedicalDoctor_Seniorcitizens
        txtMDNumber.Text = "MD-" & SystemSequences.GetMedicalDoctorSequence
        EditMode(True)
    End Sub
    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If txtMDNumber.Text = "" Then
            m_Err.SetError(txtMDNumber, "Medical Doctor Number is Required!")
            m_HasError = True
        Else
            If MedicalDoctor_Seniorcitizens.CheckofMedicalDoctor_SeniorcitizensAlreadyExist(txtMDNumber.Text, IIf(txtMDNumber.Tag Is Nothing, -1, txtMDNumber.Tag)) Then
                m_Err.SetError(txtMDNumber, "Medical Doctor Number Already Exist")
                m_HasError = True
            End If
        End If
        If txtFirstName.Text = "" Then
            m_Err.SetError(txtFirstName, "First Name is Required!")
            m_HasError = True
        End If

        If txtLastName.Text = "" Then
            m_Err.SetError(txtLastName, "Last Name is Required!")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
    Private Function ValidationDatas()
        m_Err.Clear()
        m_HasError = False

        If txtMDNumber.Text = "" Then
            m_Err.SetError(txtMDNumber, "Medical Doctor Number is Required!")
            m_HasError = True
        End If

        If _MedicalDoctor.DoctorID = "-1" Then
            m_Err.SetError(txtMDNumber, "Please save the doctor before add the branch")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
    Private Function CheckifAlreadySelected(ByVal DoctorCode As String, ByVal BranchCode As String) As Boolean
        m_Err.Clear()
        m_HasError = False

        For m As Integer = 0 To GrdViewBranch.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewBranch.Rows(m)
            If rowinfo.Cells(1).Value = BranchCode Then
                ShowExclamation("Medical Doctor Number Already Exist", "Aready Exist")
                Exit Function
            End If
        Next

        If MedicalDoctor_SeniorcitizensCollection.CheckofMedicalDoctor_SeniorcitizensCollectionAlreadyExist(DoctorCode, BranchCode) Then
            ShowExclamation("Medical Doctor Number Already Exist", "Aready Exist")
            Exit Function
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(MedicalDoctor_Seniorcitizens.GetMedicalDoctor_SeniorcitizensSql, "MedicalDoctor Seniorcitizens")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
            ShowDataWithBranchDrugs(tag.KeyColumn22)
            EditMode(False)
        End If
    End Sub
    Private Sub ShowDataBranchDrugs(ByVal BranchCode As String)
        table = GetRecords(CustomerShipTo.GetBranchCodeSql(BranchCode))
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewBranch.Rows.AddNew
            rowinfo.Cells(0).Value = table.Rows(i)("Branch Code")
            rowinfo.Cells(1).Value = table.Rows(i)("Branch Name")
            rowinfo.Cells(2).Value = table.Rows(i)("Branch Address 1")
            rowinfo.Cells(3).Value = table.Rows(i)("Branch Address 2")
        Next
    End Sub
    Private Sub ShowDataWithBranchDrugs(ByVal DoctorCode As String)
        table = GetRecords(MedicalDoctor_SeniorcitizensCollection.GetOpenBranchCodeSql(DoctorCode))
        GrdViewBranch.Rows.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewBranch.Rows.AddNew
            rowinfo.Cells(0).Value = table.Rows(i)("Branch Code")
            rowinfo.Cells(1).Value = table.Rows(i)("Branch Name")
            rowinfo.Cells(2).Value = table.Rows(i)("Branch Address 1")
            rowinfo.Cells(3).Value = table.Rows(i)("Branch Address 2")
        Next
    End Sub
    Private Sub FindBatch()
        If txtMDNumber.Text <> "" Then
            Dim tag As SelectionTags = Dialogs.ShowSearchDialog(CustomerShipTo.GetBranchSql, "Branch Drugs Store")
            If Not tag Is Nothing Then
                If CheckifAlreadySelected(txtMDNumber.Text, tag.KeyColumn11) Then
                    ShowDataBranchDrugs(tag.KeyColumn11)
                End If
            End If
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        If RecordCode < 1 Then Exit Sub
        _MedicalDoctor = MedicalDoctor_Seniorcitizens.Load(RecordCode)
        txtMDNumber.Tag = _MedicalDoctor.DoctorID
        txtMDNumber.Text = _MedicalDoctor.DoctorNumber
        txtFirstName.Text = _MedicalDoctor.FirstName
        txtLastName.Text = _MedicalDoctor.LastName
        txtMiddleName.Text = _MedicalDoctor.MiddleName
        txtSuffix.Text = _MedicalDoctor.Suffix
        txtAddressLine1.Text = _MedicalDoctor.AddressLine1
        txtAddressLine2.Text = _MedicalDoctor.AddressLine2
        txtPTRNO.Text = _MedicalDoctor.PTRNO
        EditMode(False)
    End Sub
    Private Sub SaveRecord()
        _MedicalDoctor.DoctorNumber = txtMDNumber.Text
        _MedicalDoctor.FirstName = txtFirstName.Text
        _MedicalDoctor.LastName = txtLastName.Text
        _MedicalDoctor.Suffix = txtSuffix.Text
        _MedicalDoctor.MiddleName = txtMiddleName.Text
        _MedicalDoctor.PTRNO = txtPTRNO.Text
        _MedicalDoctor.AddressLine1 = txtAddressLine1.Text
        _MedicalDoctor.AddressLine2 = txtAddressLine2.Text
        If _MedicalDoctor.Save Then
            SaveSuccess()
            ShowData(_MedicalDoctor.DoctorID)
            EditMode(False)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub SaveBranch()
        If ValidationDatas() Then
            _MedicalDoctor_Seniorcitizens.DeleteAll(_MedicalDoctor.DoctorNumber)
            For m As Integer = 0 To GrdViewBranch.Rows.Count - 1
                Dim rowinfo As GridViewRowInfo = GrdViewBranch.Rows(m)
                _MedicalDoctor_Seniorcitizens.DoctorID = _MedicalDoctor.DoctorID
                _MedicalDoctor_Seniorcitizens.DoctorNumber = _MedicalDoctor.DoctorNumber
                _MedicalDoctor_Seniorcitizens.BranchCode = rowinfo.Cells(0).Value
                _MedicalDoctor_Seniorcitizens.BranchName = rowinfo.Cells(1).Value
                _MedicalDoctor_Seniorcitizens.AddressLine1 = rowinfo.Cells(2).Value
                _MedicalDoctor_Seniorcitizens.AddressLine2 = rowinfo.Cells(3).Value
                _MedicalDoctor_Seniorcitizens.IsActive = True
                _MedicalDoctor_Seniorcitizens.DLTFLG = False
                _MedicalDoctor_Seniorcitizens.Save()
            Next
            ShowInformation("Record Successfully Branch Add", "New Branch")
        End If
    End Sub
    Private Sub SaveBranchbyRemove()
        If ValidationDatas() Then
            _MedicalDoctor_Seniorcitizens.DeleteAll(_MedicalDoctor.DoctorNumber)
            For m As Integer = 0 To GrdViewBranch.Rows.Count - 1
                Dim rowinfo As GridViewRowInfo = GrdViewBranch.Rows(m)
                _MedicalDoctor_Seniorcitizens.DoctorID = _MedicalDoctor.DoctorID
                _MedicalDoctor_Seniorcitizens.DoctorNumber = _MedicalDoctor.DoctorNumber
                _MedicalDoctor_Seniorcitizens.BranchCode = rowinfo.Cells(0).Value
                _MedicalDoctor_Seniorcitizens.BranchName = rowinfo.Cells(1).Value
                _MedicalDoctor_Seniorcitizens.AddressLine1 = rowinfo.Cells(2).Value
                _MedicalDoctor_Seniorcitizens.AddressLine2 = rowinfo.Cells(3).Value
                _MedicalDoctor_Seniorcitizens.IsActive = True
                _MedicalDoctor_Seniorcitizens.DLTFLG = False
                _MedicalDoctor_Seniorcitizens.Save()
            Next
        End If
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog = MsgBoxResult.Yes Then
            If _MedicalDoctor.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnDelete.Click, btnUpdate.Click, btnFind.Click, btnSave.Click, btnClear.Click, btnClose.Click, btnFindBatch.Click, btnSaveBranch.Click, btnBranchremove.Click
        If sender Is btnNew Then
            NewRecord()
        ElseIf sender Is btnDelete Then
            Delete()
        ElseIf sender Is btnUpdate Then
            EditMode(True)
        ElseIf sender Is btnClear Then
            Clear()
            EditMode(False)
        ElseIf sender Is btnClose Then
            Close()
        ElseIf sender Is btnFind Then
            Find()
        ElseIf sender Is btnFindBatch Then
            FindBatch()
        ElseIf sender Is btnSave Then
            If ValidateData() Then
                SaveRecord()
            End If
        ElseIf sender Is btnSaveBranch Then
            SaveBranch()
        ElseIf sender Is btnBranchremove Then
            DeleteBranch()
        End If
    End Sub
    Private Sub DeleteBranch()
        If ShowDeleteDialog() = MsgBoxResult.Yes Then
            Dim selectedRows(Me.GrdViewBranch.SelectedRows.Count - 1) As GridViewRowInfo
            Me.GrdViewBranch.SelectedRows.CopyTo(selectedRows, 0)
            Me.GrdViewBranch.TableElement.BeginUpdate()
            For i As Integer = 0 To selectedRows.Length - 1
                Me.GrdViewBranch.Rows.Remove(TryCast(selectedRows(i), GridViewDataRowInfo))
            Next i
            Me.GrdViewBranch.TableElement.EndUpdate()
            DeleteSuccess()
            SaveBranchbyRemove()
        Else
            UnDeleteSuccess()
        End If
    End Sub

End Class
