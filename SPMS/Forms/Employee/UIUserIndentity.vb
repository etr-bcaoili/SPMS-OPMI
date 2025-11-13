Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.Windows
Imports Telerik.WinControls
Imports Telerik.Windows.Controls
Imports Telerik.WinControls.UI
Imports System.Text
Imports DataLayer
Public Class UIUserIndentity
    Private _UserIdentity As New UserIdentity
    Private table As New DataTable
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False

    Public Enum UserType
        Executive = 5
        RegionalManager = 4
        DistrictManager = 2
        PMR = 1
    End Enum
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

        dtFromDate.ReadOnly = Not IsEditMode
        dtFromDate.BackColor = Color.White

        dtTodate.ReadOnly = Not IsEditMode
        dtFromDate.BackColor = Color.White

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
        dtFromDate.Text = DateTime.Now
        dtTodate.Text = DateTime.Now
    End Sub
    Private Sub NewRecord()
        Clear()
        _UserIdentity = New UserIdentity
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
            End If
        End If
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(UserIdentity.GetUserIndentitySql, "UserIdentity")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
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
            If UserIdentity.CheckofUserIndentityAlreadyExist(txtEmployeeCode.Text, IIf(txtEmployeeCode.Tag Is Nothing, -1, txtEmployeeCode.Tag)) Then
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

        If txtPosition.Text = "" Then
            m_Err.SetError(txtPosition, "Position/Designation is Required!")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
    Private Sub SaveRecord()
        _UserIdentity.EmployeeCode = txtEmployeeCode.Text
        _UserIdentity.EmployeeFirstName = txtEmployeeFirstName.Text
        _UserIdentity.EmployeeLastName = txtEmployeeLastName.Text
        _UserIdentity.EmployeeMeddleName = txtEmployeeMeddleName.Text
        _UserIdentity.EmployeePhoneNumber = txtPhoneNumber.Text
        _UserIdentity.EmployeeGender = cmbGender.Text
        _UserIdentity.EmployeeEmail = txtEmail.Text
        If "Executive" = txtPosition.Text Then
            _UserIdentity.EmployeePosition = UserType.Executive
        ElseIf "RegionalManager" = txtPosition.Text Then
            _UserIdentity.EmployeePosition = UserType.RegionalManager
        ElseIf "DistrictManager" = txtPosition.Text Then
            _UserIdentity.EmployeePosition = UserType.DistrictManager
        Else
            _UserIdentity.EmployeePosition = UserType.PMR
        End If
        _UserIdentity.EmployeeAddress1 = txtAddress1.Text
        _UserIdentity.EmployeeAddress2 = txtAddress1.Text
        _UserIdentity.EffectivityStartDate = dtFromDate.Text
        _UserIdentity.EffectivityEndDate = dtTodate.Text
        If chkIsActive.Checked = True Then
            _UserIdentity.IsActive = True
        Else
            _UserIdentity.IsActive = False
        End If

        If _UserIdentity.Save Then
            SaveSuccess()
            ShowData(_UserIdentity.ID)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        If RecordCode < 1 Then Exit Sub
        _UserIdentity = UserIdentity.Load(RecordCode)
        txtEmployeeCode.Tag = _UserIdentity.ID
        txtEmployeeCode.Text = _UserIdentity.EmployeeCode
        txtEmployeeFirstName.Text = _UserIdentity.EmployeeFirstName
        txtEmployeeLastName.Text = _UserIdentity.EmployeeLastName
        txtEmployeeMeddleName.Text = _UserIdentity.EmployeeMeddleName
        txtPhoneNumber.Text = _UserIdentity.EmployeePhoneNumber
        txtEmail.Text = _UserIdentity.EmployeeEmail
        cmbGender.Text = _UserIdentity.EmployeeGender
        If UserType.Executive = _UserIdentity.EmployeePosition Then
            txtPosition.Text = "Executive"
        ElseIf UserType.RegionalManager = _UserIdentity.EmployeePosition Then
            txtPosition.Text = "RegionalManager"
        ElseIf UserType.DistrictManager = _UserIdentity.EmployeePosition Then
            txtPosition.Text = "DistrictManager"
        Else
            txtPosition.Text = "Professional Medical Representative"
        End If

        txtAddress1.Text = _UserIdentity.EmployeeAddress1
        dtFromDate.Text = _UserIdentity.EffectivityStartDate
        dtTodate.Text = _UserIdentity.EffectivityEndDate
        EditMode(False)
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog() = DialogResult.Yes Then
            If _UserIdentity.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub
    Private Sub UIUserIndentity_Load(sender As Object, e As EventArgs) Handles Me.Load
        EditMode(False)
        Clear()
    End Sub
    Private Sub Findconfig_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Findconfig.LinkClicked
        Positions()
    End Sub
End Class
