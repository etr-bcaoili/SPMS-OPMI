Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.Windows
Imports Telerik.WinControls
Imports Telerik.Windows.Controls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Enumerations
Public Class UISalesAccountSpecialist
    Private _SalesAccountSpecialist As New SalesAccountSpecialist
    Private _SalesAccountSpecialistCollection As New SalesAccountSpecialistCollection
    Private _DistrictManager As New SalesManager

    Private table As New DataTable
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False

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
        GrdViewDistrictProperty.Rows.Clear()
    End Sub
    Private Sub NewRecord()
        Clear()
        _SalesAccountSpecialist = New SalesAccountSpecialist
        EditMode(True)
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnDelete.Click, btnEdit.Click, btnFinddata.Click, btnSave.Click, btnClear.Click, btnClose.Click
        If sender Is btnNew Then
            NewRecord()
        ElseIf sender Is btnDelete Then
            Delete()
        ElseIf sender Is btnEdit Then
            EditMode(True)
        ElseIf sender Is btnClear Then
            Clear()
            EditMode(False)
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
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(SalesAccountSpecialist.GetSalesAccountSpecialistSql, "Sales Account Specialist")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
            ShowDataCollection(tag.KeyColumn11)
            EditMode(False)
        End If
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
            If SalesAccountSpecialist.CheckofSalesAccountSpecialistAlreadyExist(txtEmployeeCode.Text, IIf(txtEmployeeCode.Tag Is Nothing, -1, txtEmployeeCode.Tag)) Then
                m_Err.SetError(txtEmployeeCode, "Employee Code Already Exist")
                m_HasError = True
            End If
        End If

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
        Return Not m_HasError
    End Function
    Private Sub SaveRecord()
        _SalesAccountSpecialist.EmployeeCode = txtEmployeeCode.Text
        _SalesAccountSpecialist.EmployeeFirstName = txtEmployeeFirstName.Text
        _SalesAccountSpecialist.EmployeeLastName = txtEmployeeLastName.Text
        _SalesAccountSpecialist.EmployeeMeddleName = txtEmployeeMeddleName.Text
        _SalesAccountSpecialist.EmployeePhoneNumber = txtPhoneNumber.Text
        _SalesAccountSpecialist.EmployeeGender = cmbGender.Text
        _SalesAccountSpecialist.EmployeeEmail = txtEmail.Text
        _SalesAccountSpecialist.EmployeePosition = txtPosition.Text
        _SalesAccountSpecialist.EmployeeAddress1 = txtAddress1.Text
        _SalesAccountSpecialist.EmployeeAddress2 = txtAddress1.Text
        _SalesAccountSpecialist.DateStart = DateTime.Now
        _SalesAccountSpecialist.DateEnd = DateTime.Now
        If chkIsActive.Checked = True Then
            _SalesAccountSpecialist.IsActive = True
        Else
            _SalesAccountSpecialist.IsActive = False
        End If

        If _SalesAccountSpecialist.Save Then
            SaveSuccess()
            ShowData(_SalesAccountSpecialist.SalesAccountSpecialistID)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub SaveRecordCollection()
        If GrdViewDistrictProperty.Rows.Count <> 0 Then
            EmployeeCollection.SalesAccountSpecialistCollectionDelete(_SalesAccountSpecialist.SalesAccountSpecialistID)
            For m As Integer = 0 To GrdViewDistrictProperty.Rows.Count - 1
                Dim rowinfo As GridViewRowInfo = GrdViewDistrictProperty.Rows(m)
                _SalesAccountSpecialistCollection.IsActive = rowinfo.Cells(0).Value
                _SalesAccountSpecialistCollection.DistrictManagerName = rowinfo.Cells(1).Value
                _SalesAccountSpecialistCollection.SalesAccountSpecialistID = _SalesAccountSpecialist.SalesAccountSpecialistID
                _SalesAccountSpecialistCollection.DistrictManagerCode = rowinfo.Cells(4).Value
                _SalesAccountSpecialistCollection.TerritoryCodeMultipleValues = rowinfo.Cells(2).Value
                _SalesAccountSpecialistCollection.TerritoryNameMultipleValues = rowinfo.Cells(3).Value
                _SalesAccountSpecialistCollection.EffectivityStartDate = rowinfo.Cells(5).Value
                _SalesAccountSpecialistCollection.EffectivityEndDate = rowinfo.Cells(6).Value
                _SalesAccountSpecialistCollection.ConfigtypeCode = rowinfo.Cells(7).Value
                _SalesAccountSpecialistCollection.Save()
            Next
        End If
    End Sub
    Private Sub ShowDataCollection(ByVal EmployeeID As Integer)
        GrdViewDistrictProperty.Rows.Clear()
        table = GetRecords(SalesAccountSpecialistCollection.GetSalesAccountSpecialistICollection(EmployeeID))
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewDistrictProperty.Rows.AddNew
            rowinfo.Cells(0).Value = table.Rows(i)("IsActive")
            rowinfo.Cells(1).Value = table.Rows(i)("DistrictManagerName")
            rowinfo.Cells(2).Value = table.Rows(i)("PMRCode")
            rowinfo.Cells(3).Value = table.Rows(i)("PMRName")
            rowinfo.Cells(4).Value = table.Rows(i)("DistrictManagerCode")
            rowinfo.Cells(5).Value = table.Rows(i)("EffectivityStartDate")
            rowinfo.Cells(6).Value = table.Rows(i)("EffectivityEndDate")
            rowinfo.Cells(7).Value = table.Rows(i)("ConfigtypeCode")
        Next
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        If RecordCode < 1 Then Exit Sub
        _SalesAccountSpecialist = SalesAccountSpecialist.Load(RecordCode)
        txtEmployeeCode.Tag = _SalesAccountSpecialist.SalesAccountSpecialistID
        txtEmployeeCode.Text = _SalesAccountSpecialist.EmployeeCode
        txtEmployeeFirstName.Text = _SalesAccountSpecialist.EmployeeFirstName
        txtEmployeeLastName.Text = _SalesAccountSpecialist.EmployeeLastName
        txtEmployeeMeddleName.Text = _SalesAccountSpecialist.EmployeeMeddleName
        txtPhoneNumber.Text = _SalesAccountSpecialist.EmployeePhoneNumber
        txtEmail.Text = _SalesAccountSpecialist.EmployeeEmail
        cmbGender.Text = _SalesAccountSpecialist.EmployeeGender
        txtPosition.Text = _SalesAccountSpecialist.EmployeePosition
        txtAddress1.Text = _SalesAccountSpecialist.EmployeeAddress1
        EditMode(False)
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog() = DialogResult.Yes Then
            If _SalesAccountSpecialist.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub

    Private Sub UISalesAccountSpecialist_Load(sender As Object, e As EventArgs) Handles Me.Load
        EditDefault(False)
    End Sub
    Private Sub Findconfig_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Findconfig.LinkClicked
        Positions()
    End Sub
    Private Function AppendNewColumn(ByVal columnType As String, ByVal numberInTheHeader As Boolean) As GridViewDataColumn
        ''table = GetRecords(SalesAccountSpecialist.GetConfigtypeCode())
        Dim newColumn As GridViewDataColumn = Nothing
        Select Case columnType
            Case "column4"
                newColumn = New GridViewComboBoxColumn()
                CType(newColumn, GridViewComboBoxColumn).DataSource = table
                newColumn.Width = 100
                newColumn.FieldName = "column4"
        End Select
        Me.GrdViewDistrictManager2.Columns.Add(newColumn)
        Return newColumn
    End Function

    Private Sub btnprocesssas_Click(sender As Object, e As EventArgs)
        If txtEmployeeCode.Text <> "" Then
            Dim a As New UISalesAccountSpecialistProcess
            a.EmployeeCode = _SalesAccountSpecialist.SalesAccountSpecialistID
            a.ShowDialog()
        Else
            MessageBox.Show("Please select the Employee SAS", "Invalid")
        End If
    End Sub

    Private Sub btnAdds_Click(sender As Object, e As EventArgs) Handles btnAddPMR.Click
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(SalesManager.GetDistrictManagerSql, "SalesManager")
        If Not tag Is Nothing Then
            If GrdViewDistrictProperty.Rows.Count = 0 Then
                _DistrictManager.DistrictCode = tag.KeyColumn22
                _DistrictManager.ConfigtypeCode = tag.KeyColumn44
                _DistrictManager.SASCode = _SalesAccountSpecialist.SalesAccountSpecialistID
                _DistrictManager.EffectivityStartDate = Date.Now.ToShortDateString
                _DistrictManager.EffectivityEndDate = Date.Now.ToShortDateString
                _DistrictManager.InsertDistrict()
                ShowDataCollection(_SalesAccountSpecialist.SalesAccountSpecialistID)
            Else
                For m As Integer = 0 To GrdViewDistrictProperty.Rows.Count - 1
                    Dim rowinfo As GridViewRowInfo = GrdViewDistrictProperty.Rows(m)
                    If tag.KeyColumn11 = rowinfo.Cells(4).Value Then
                        Dim ds As DialogResult = RadMessageBox.Show(Me, "District Code is Already Tag.!", "", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                        Exit Sub
                    Else
                        _DistrictManager.DistrictCode = tag.KeyColumn22
                        _DistrictManager.ConfigtypeCode = tag.KeyColumn44
                        _DistrictManager.SASCode = _SalesAccountSpecialist.SalesAccountSpecialistID
                        _DistrictManager.InsertDistrict()
                        ShowDataCollection(_SalesAccountSpecialist.SalesAccountSpecialistID)
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class
