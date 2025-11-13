Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.Windows
Imports Telerik.WinControls
Imports Telerik.Windows.Controls
Imports Telerik.WinControls.UI
Imports System.Text
Imports DataLayer
Public Class UIEmployeeDistrictManager

    Private _EmployeeDistrictManager As New EmployeeDistrictManager
    Private _EmployeeSalesmanCollection As New EmployeeDistrictCollection
    Private table As New DataTable
    Private table2 As New DataTable
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_ConfigtypeCode As String = String.Empty

    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtEmployeeCode.ReadOnly = Not IsEditMode
        txtEmployeeCode.BackColor = Color.White

        txtEmployeeFirstName.ReadOnly = Not IsEditMode
        txtEmployeeFirstName.BackColor = Color.White

        txtEmployeeLastName.ReadOnly = Not IsEditMode
        txtEmployeeLastName.BackColor = Color.White

        txtEmployeeMeddleName.ReadOnly = Not IsEditMode
        txtEmployeeMeddleName.BackColor = Color.White

        txtPhoneNumber.ReadOnly = Not IsEditMode
        txtPhoneNumber.BackColor = Color.White

        txtPosition.ReadOnly = Not IsEditMode
        txtPosition.BackColor = Color.White

        txtEmail.ReadOnly = Not IsEditMode
        txtEmail.BackColor = Color.White

        txtAddress1.ReadOnly = Not IsEditMode
        txtAddress1.BackColor = Color.White
    End Sub
    Private Sub EditDefault(ByVal IsEditMode As Boolean)

        txtEmployeeCode.ReadOnly = Not IsEditMode
        txtEmployeeCode.BackColor = Color.WhiteSmoke

        txtEmployeeFirstName.ReadOnly = Not IsEditMode
        txtEmployeeFirstName.BackColor = Color.WhiteSmoke

        txtEmployeeLastName.ReadOnly = Not IsEditMode
        txtEmployeeLastName.BackColor = Color.WhiteSmoke

        txtEmployeeMeddleName.ReadOnly = Not IsEditMode
        txtEmployeeMeddleName.BackColor = Color.WhiteSmoke

        txtPhoneNumber.ReadOnly = Not IsEditMode
        txtPhoneNumber.BackColor = Color.WhiteSmoke

        txtPosition.ReadOnly = Not IsEditMode
        txtPosition.BackColor = Color.WhiteSmoke

        txtEmail.ReadOnly = Not IsEditMode
        txtEmail.BackColor = Color.WhiteSmoke

        txtAddress1.ReadOnly = Not IsEditMode
        txtAddress1.BackColor = Color.WhiteSmoke
    End Sub
    Private Sub EditModeCollection(ByVal IsEditMode As Boolean)
        GrdViewDistrictManager.ReadOnly = Not IsEditMode
        btnAddPMR.Enabled = IsEditMode
        btnRemovePMR.Enabled = IsEditMode
    End Sub
    Private Sub Clear()
        txtEmployeeCode.Text = String.Empty
        txtEmployeeFirstName.Text = String.Empty
        txtEmployeeLastName.Text = String.Empty
        txtEmployeeMeddleName.Text = String.Empty
        txtPhoneNumber.Text = String.Empty
        cmbGender.Text = String.Empty
        txtPosition.Text = String.Empty
        txtEmail.Text = String.Empty
        txtAddress1.Text = String.Empty
        GrdViewDistrictManager.Rows.Clear()
        GrdViewPMRReference.Rows.Clear()
    End Sub

    Private Sub NewRecord()
        Clear()
        _EmployeeDistrictManager = New EmployeeDistrictManager
        EditMode(True)
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(EmployeeDistrictManager.GetEmployeeDistrictManagerSql, "Employee District Manager")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
            ShowDataCollection(tag.KeyColumn11)
            EditMode(False)
        End If
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnDelete.Click, btnEdit.Click, btnFinddata.Click, btnSave.Click, btnClear.Click, btnClose.Click
        If sender Is btnNew Then
            NewRecord()
        ElseIf sender Is btnDelete Then
            Delete()
        ElseIf sender Is btnEdit Then
            EditMode(True)
            EditModeCollection(True)
        ElseIf sender Is btnClear Then
            Clear()
            EditMode(False)
            EditModeCollection(False)
        ElseIf sender Is btnClose Then
            Close()
        ElseIf sender Is btnFinddata Then
            Find()
        ElseIf sender Is btnSave Then
            If ValidateData() Then
                SaveRecord()
                SaveRecordCollection()
            End If
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        If RecordCode < 1 Then Exit Sub
        _EmployeeDistrictManager = EmployeeDistrictManager.Load(RecordCode)
        txtEmployeeCode.Tag = _EmployeeDistrictManager.EmployeeID
        txtEmployeeCode.Text = _EmployeeDistrictManager.EmployeeCode
        txtEmployeeFirstName.Text = _EmployeeDistrictManager.EmployeeFirstName
        txtEmployeeLastName.Text = _EmployeeDistrictManager.EmployeeLastName
        txtEmployeeMeddleName.Text = _EmployeeDistrictManager.EmployeeMeddleName
        txtPhoneNumber.Text = _EmployeeDistrictManager.EmployeePhoneNumber
        txtEmail.Text = _EmployeeDistrictManager.EmployeeEmail
        cmbGender.Text = _EmployeeDistrictManager.EmployeeGender
        txtPosition.Text = _EmployeeDistrictManager.EmployeePosition
        txtAddress1.Text = _EmployeeDistrictManager.EmployeeAddress1
        EditMode(False)
    End Sub
    Private Sub Positions()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Position.GetPositionSql, "Position")
        If Not tag Is Nothing Then
            txtPosition.Text = tag.KeyColumn33
        End If
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

        If txtEmployeeCode.Text = "" Then
            m_Err.SetError(txtEmployeeCode, "Employee Code is Required!")
            m_HasError = True
        Else
            If EmployeeDistrictManager.CheckofEmployeeDistrictManagerAlreadyExist(txtEmployeeCode.Text, IIf(txtEmployeeCode.Tag Is Nothing, -1, txtEmployeeCode.Tag)) Then
                m_Err.SetError(txtEmployeeCode, "Employee Code Already Exist")
                m_HasError = True
            End If
        End If
        For m As Integer = 0 To GrdViewDistrictManager.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewDistrictManager.Rows(m)
            If rowinfo.Cells(5).Value = False Then
                If MedicalRepresentative.CheckofDMTaggingAlreadyExist(rowinfo.Cells(0).Value, rowinfo.Cells(2).Value, rowinfo.Cells(3).Value, rowinfo.Cells(4).Value) Then
                    Dim ds As DialogResult = RadMessageBox.Show(Me, "District Manager Code and Effectivity Date  is Already already assign Please check the Effectivity Date!", "", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    Exit Function
                    m_HasError = True
                End If
            End If
        Next

        If txtEmployeeFirstName.Text = "" Then
            m_Err.SetError(txtEmployeeFirstName, "Employee First Name is Required!")
            m_HasError = True
        End If

        If txtEmployeeLastName.Text = "" Then
            m_Err.SetError(txtEmployeeLastName, "EmployeeEmployee Last Name is Required!")
            m_HasError = True
        End If

        If txtEmployeeFirstName.Text = "" Then
            m_Err.SetError(txtEmployeeMeddleName, "Employee First Name is Required!")
            m_HasError = True
        End If

        If txtEmployeeFirstName.Text = "" Then
            m_Err.SetError(txtAddress1, "Employee First Name is Required!")
            m_HasError = True
        End If

        If txtPosition.Text = "" Then
            m_Err.SetError(txtPosition, "Position/Designation is Required!")
            m_HasError = True
        End If
        Return Not m_HasError
    End Function
    Private Sub SaveRecord()
        _EmployeeDistrictManager.EmployeeCode = txtEmployeeCode.Text
        _EmployeeDistrictManager.EmployeeFirstName = txtEmployeeFirstName.Text
        _EmployeeDistrictManager.EmployeeLastName = txtEmployeeLastName.Text
        _EmployeeDistrictManager.EmployeeMeddleName = txtEmployeeMeddleName.Text
        _EmployeeDistrictManager.EmployeePhoneNumber = txtPhoneNumber.Text
        _EmployeeDistrictManager.EmployeeGender = cmbGender.Text
        _EmployeeDistrictManager.EmployeeEmail = txtEmail.Text
        _EmployeeDistrictManager.EmployeePosition = txtPosition.Text
        _EmployeeDistrictManager.EmployeeAddress1 = txtAddress1.Text
        _EmployeeDistrictManager.EmployeeAddress2 = txtAddress1.Text
        If chkIsActive.Checked = True Then
            _EmployeeDistrictManager.IsActive = True
        Else
            _EmployeeDistrictManager.IsActive = False
        End If

        If _EmployeeDistrictManager.Save Then
            SaveSuccess()
            ShowData(_EmployeeDistrictManager.EmployeeID)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub SaveRecordCollection()
        If GrdViewDistrictManager.Rows.Count = 0 Then
            EmployeeDistrictCollection.EmployeeCollectionDelete(_EmployeeDistrictManager.EmployeeID)
        Else
            EmployeeDistrictCollection.EmployeeCollectionDelete(_EmployeeDistrictManager.EmployeeID)
            For m As Integer = 0 To GrdViewDistrictManager.Rows.Count - 1
                Dim rowinfo As GridViewRowInfo = GrdViewDistrictManager.Rows(m)
                _EmployeeSalesmanCollection.EmployeeID = _EmployeeDistrictManager.EmployeeID
                _EmployeeSalesmanCollection.DistrictCode = rowinfo.Cells(0).Value
                _EmployeeSalesmanCollection.ConfigtypeCode = rowinfo.Cells(4).Value
                _EmployeeSalesmanCollection.DateStartEffectivity = rowinfo.Cells(2).Value
                _EmployeeSalesmanCollection.DateEndEffectivity = rowinfo.Cells(3).Value
                _EmployeeSalesmanCollection.Save()
            Next
        End If
    End Sub
    Private Sub ShowDataCollection(ByVal EmployeeID As Integer)
        table = GetRecords(EmployeeDistrictCollection.GetEmployeeCollection2(EmployeeID))
        GrdViewDistrictManager.Rows.Clear()
        GrdViewPMRReference.Rows.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewDistrictManager.Rows.AddNew
            rowinfo.Cells(0).Value = table.Rows(i)("DistrictCode")
            ShowDataCollectionDistrictManagerReference(table.Rows(i)("DistrictCode"), EmployeeID)
            rowinfo.Cells(1).Value = _EmployeeDistrictManager.EmployeeLastName + " " + _EmployeeDistrictManager.EmployeeFirstName
            rowinfo.Cells(2).Value = table.Rows(i)("EffectivityStartDate")
            rowinfo.Cells(3).Value = table.Rows(i)("EffectivityEndDate")
            rowinfo.Cells(4).Value = table.Rows(i)("ConfigtypeCode")
            rowinfo.Cells(5).Value = True
        Next
    End Sub
    Private Sub ShowDataCollectionDistrictManagerReference(ByVal DistrictManagerCode As String, ByVal EmployeeID As Integer)
        table2 = GetRecords(EmployeeDistrictCollection.GetEmployeeCollectionDistrict(DistrictManagerCode, EmployeeID))
        For m As Integer = 0 To table2.Rows.Count - 1
            Dim rowinfos As GridViewRowInfo = GrdViewPMRReference.Rows.AddNew
            rowinfos.Cells(0).Value = table2.Rows(m)("DistrictCode")
            rowinfos.Cells(1).Value = table2.Rows(m)("EmployeeName")
            rowinfos.Cells(2).Value = table2.Rows(m)("EffectivityStartDate")
            rowinfos.Cells(3).Value = table2.Rows(m)("EffectivityEndDate")
            rowinfos.Cells(4).Value = table2.Rows(m)("ConfigtypeCode")
            rowinfos.Cells(5).Value = True
        Next
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog() = DialogResult.Yes Then
            If _EmployeeDistrictManager.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub
    'Private Sub btnAdd_Click_1(sender As Object, e As EventArgs) Handles btnAdd.Click
    '    Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Sales_Matrix.GetSalesmatrixSql, "Salesmatrix")
    '    If Not tag Is Nothing Then
    '        If GrdViewPMR.Rows.Count = 0 Then
    '            Dim rowinfos As GridViewRowInfo = GrdViewPMR.Rows.AddNew
    '            rowinfos.Cells(0).Value = tag.KeyColumn11
    '            rowinfos.Cells(1).Value = tag.KeyColumn33
    '            rowinfos.Cells(2).Value = tag.KeyColumn44
    '            Exit Sub
    '        Else
    '            For m As Integer = 0 To GrdViewPMR.Rows.Count - 1
    '                Dim rowinfo As GridViewRowInfo = GrdViewPMR.Rows(m)
    '                If tag.KeyColumn11 = rowinfo.Cells(0).Value Then
    '                    Dim ds As DialogResult = RadMessageBox.Show(Me, "Territory Code is Already Tag.!", "", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
    '                    Exit Sub
    '                End If
    '            Next
    '            Dim rowinfos As GridViewRowInfo = GrdViewPMR.Rows.AddNew
    '            rowinfos.Cells(0).Value = tag.KeyColumn11
    '            rowinfos.Cells(1).Value = tag.KeyColumn33
    '            rowinfos.Cells(2).Value = tag.KeyColumn44
    '        End If
    '    End If
    'End Sub
    Private Sub Findconfig_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Findconfig.LinkClicked
        Positions()
    End Sub
    Private Sub btnAddPMR_Click(sender As Object, e As EventArgs) Handles btnAddPMR.Click
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(MedicalRepresentative.GetDMEmployeeSql, "District Manager")
        If Not tag Is Nothing Then
            m_ConfigtypeCode = tag.KeyColumn22
            ShowDataDM(tag.KeyColumn11, tag.KeyColumn33)
        End If
    End Sub
    Private Sub ShowDataDM(ByVal DMCode As String, ByVal ConfigtypeCode As String)
        table = GetRecords(MedicalRepresentative.GetSalematrixDMSql(DMCode, ConfigtypeCode))
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfoNew As GridViewRowInfo = GrdViewDistrictManager.Rows.AddNew
            rowinfoNew.Cells(0).Value = table.Rows(i)("STDISTRCTCD")
            rowinfoNew.Cells(1).Value = _EmployeeDistrictManager.EmployeeLastName + " " + _EmployeeDistrictManager.EmployeeFirstName
            rowinfoNew.Cells(2).Value = DateTime.Now
            rowinfoNew.Cells(3).Value = DateTime.Now
            rowinfoNew.Cells(4).Value = table.Rows(i)("ConfigTypeCode")
            rowinfoNew.Cells(5).Value = False
            Exit Sub
        Next
    End Sub

    Private Sub btnRemovePMR_Click(sender As Object, e As EventArgs) Handles btnRemovePMR.Click
        If ShowQuestion("Are you sure you want to Remove this record?", "Removed") = MsgBoxResult.Yes Then
            ShowInformation("Record Successfully Removed.", "Removed")
            Dim selectedRows(Me.GrdViewDistrictManager.SelectedRows.Count - 1) As GridViewRowInfo
            Me.GrdViewDistrictManager.SelectedRows.CopyTo(selectedRows, 0)
            Me.GrdViewDistrictManager.TableElement.BeginUpdate()
            For i As Integer = 0 To selectedRows.Length - 1
                Me.GrdViewDistrictManager.Rows.Remove(TryCast(selectedRows(i), GridViewDataRowInfo))
            Next i
            Me.GrdViewDistrictManager.TableElement.EndUpdate()
        Else
            ShowExclamation("Record not deleted.", "Delete")
        End If
    End Sub

    Private Function ValidateDataDM(ByVal DMCode As String, ByVal StartDate As String, ByVal EnddDate As String, ByVal ConfigtypeCode As String)
        m_Err.Clear()
        m_HasError = False
        If EmployeeDistrictManager.CheckofDistrictManagerStartDateAlreadyExist(DMCode, StartDate, ConfigtypeCode) Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "The Selection Startdate is Already Entry please check the Effectivity Start!", "", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Exit Function
        End If

        If EmployeeDistrictManager.CheckofDistrictManagerEndDateAlreadyExist(DMCode, EnddDate, ConfigtypeCode) Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "The Selection Enddate is Already Entry please check the Effectivity End!", "", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Exit Function
        End If

        Return Not m_HasError
    End Function

    Private Sub UIEmployeeDistrictManager_Load(sender As Object, e As EventArgs) Handles Me.Load
        EditModeCollection(False)
        EditDefault(False)
    End Sub
    Private Sub GrdViewPMR_CellEndEdit(sender As Object, e As GridViewCellEventArgs) Handles GrdViewDistrictManager.CellEndEdit
        For m As Integer = 0 To GrdViewDistrictManager.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewDistrictManager.Rows(m)
            If rowinfo.Cells(5).Value = False Then
                Dim dateStart As String = rowinfo.Cells(2).Value
                Dim dateEnd As String = rowinfo.Cells(3).Value
                Dim dateValueStart As DateTime
                Dim dateValueEnd As DateTime
                DateTime.TryParse(dateStart, dateValueStart)
                DateTime.TryParse(dateEnd, dateValueEnd)
                Dim monthValueStart As Integer = dateValueStart.Month
                Dim monthValueEnd As Integer = dateValueEnd.Month
                If ValidateDataDM(rowinfo.Cells(0).Value, monthValueStart, monthValueEnd, rowinfo.Cells(4).Value) Then
                End If
            End If
        Next
    End Sub

    Private Sub btnProcessData_Click(sender As Object, e As EventArgs) Handles btnProcessData.Click

    End Sub
End Class
