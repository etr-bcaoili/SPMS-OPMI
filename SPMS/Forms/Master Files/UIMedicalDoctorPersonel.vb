Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.WinControls.UI
Imports Telerik.Windows
Imports Telerik.WinControls
Public Class UIMedicalDoctorPersonel
    Private _MedicalDoctor As New MedicalDoctorPersonel
    Private _MedicalDoctorChild As New MedicalDoctor_NoofChild
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Dim table As New DataTable

    Private m_CivilStatus As String = String.Empty

    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnUpdate.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtMDNumber.ReadOnly = Not IsEditMode
        txtMDNumber.BackColor = Color.White

        txtLastName.ReadOnly = Not IsEditMode
        txtLastName.BackColor = Color.White

        txtsuffix.ReadOnly = Not IsEditMode
        txtsuffix.BackColor = Color.White

        txtFirstName.ReadOnly = Not IsEditMode
        txtFirstName.BackColor = Color.White


        txtMiddle.ReadOnly = Not IsEditMode
        txtMiddle.BackColor = Color.White

        txtAddress1.ReadOnly = Not IsEditMode
        txtAddress1.BackColor = Color.White

        txtAddress2.ReadOnly = Not IsEditMode
        txtAddress2.BackColor = Color.White

        txtPTRNO.ReadOnly = Not IsEditMode
        txtPTRNO.BackColor = Color.White

        txtNameOfSpouse.ReadOnly = Not IsEditMode
        txtNameOfSpouse.BackColor = Color.White

        txtHabbiesAndInterest.ReadOnly = Not IsEditMode
        txtHabbiesAndInterest.BackColor = Color.White

    End Sub
    Private Sub Clear()
        txtMDNumber.Text = String.Empty
        txtLastName.Text = String.Empty
        txtsuffix.Text = String.Empty
        txtFirstName.Text = String.Empty
        txtMiddle.Text = String.Empty
        txtAddress1.Text = String.Empty
        txtAddress2.Text = String.Empty
        txtPTRNO.Text = String.Empty
        txtNameOfSpouse.Text = String.Empty
        txtHabbiesAndInterest.Text = String.Empty
        OptionFemale.IsChecked = False
        OptionMale.IsChecked = False
        txtCivilStatusName.Text = String.Empty
        dtAnniversaryDate.Text = Date.Now
        dttBirthday.Text = Date.Now
        Check_Enrolled.Checked = False

    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnDelete.Click, btnUpdate.Click, btnFind.Click, btnSave.Click, btnClear.Click, btnClose.Click
        If sender Is btnNew Then
            NewRecord()
        ElseIf sender Is btnDelete Then
            ''  Delete()
        ElseIf sender Is btnUpdate Then
            EditMode(True)
        ElseIf sender Is btnClear Then
            Clear()
            EditMode(False)
        ElseIf sender Is btnClose Then
            Close()
        ElseIf sender Is btnFind Then
            Find()
        ElseIf sender Is btnSave Then
            If ValidateData() Then
                SaveRecord()
            End If
        End If
    End Sub
    Private Sub NewRecord()
        Clear()
        _MedicalDoctor = New MedicalDoctorPersonel
        txtMDNumber.Text = "MD-" & SystemSequences.GetMedicalDoctorSequence
        EditMode(True)
    End Sub
    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Sub SaveRecord()
        _MedicalDoctor.DoctorNumber = txtMDNumber.Text
        _MedicalDoctor.LastName = txtLastName.Text
        _MedicalDoctor.FirstName = txtFirstName.Text
        _MedicalDoctor.Middle = txtMiddle.Text
        _MedicalDoctor.Suffix = txtsuffix.Text
        If OptionMale.IsChecked = True Then
            _MedicalDoctor.Gender = 1
        ElseIf OptionFemale.IsChecked = True Then
            _MedicalDoctor.Gender = 2
        End If
        _MedicalDoctor.Address1 = txtAddress1.Text
        _MedicalDoctor.Address2 = txtAddress2.Text
        _MedicalDoctor.CivilStatus = m_CivilStatus
        _MedicalDoctor.PTRNO = txtPTRNO.Text
        If chkIsActive.Checked = True Then
            _MedicalDoctor.IsActive = True
        Else
            _MedicalDoctor.IsActive = False
        End If
        If Check_Enrolled.Checked = True Then
            _MedicalDoctor.Enrolled = 1
        Else
            _MedicalDoctor.Enrolled = 0
        End If
        _MedicalDoctor.BirthDate = dttBirthday.Text
        _MedicalDoctor.NameOfSpouse = txtNameOfSpouse.Text
        _MedicalDoctor.AnniversaryDate = dtAnniversaryDate.Text
        _MedicalDoctor.HabbiesAndInterest = txtHabbiesAndInterest.Text

        If _MedicalDoctor.Save Then
            SaveSuccess()
            ShowData(_MedicalDoctor.DoctorID)
            EditMode(False)
        Else
            UnSuccesSave()
        End If


        For m As Integer = 0 To GrdViewChild.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewChild.Rows(m)
            _MedicalDoctorChild.FullName = rowinfo.Cells(0).Value
            _MedicalDoctorChild.Age = rowinfo.Cells(1).Value
            _MedicalDoctorChild.Save()
        Next


        For m As Integer = 0 To GrdViewEducational.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewEducational.Rows(m)
            _MedicalDoctorChild.FullName = rowinfo.Cells(0).Value
            _MedicalDoctorChild.Age = rowinfo.Cells(1).Value
            _MedicalDoctorChild.Save()
        Next

    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        If RecordCode < 1 Then Exit Sub
        _MedicalDoctor = MedicalDoctorPersonel.Load(RecordCode)
        txtMDNumber.Tag = _MedicalDoctor.DoctorID
        txtMDNumber.Text = _MedicalDoctor.DoctorNumber
        txtLastName.Text = _MedicalDoctor.LastName
        txtFirstName.Text = _MedicalDoctor.FirstName
        txtMiddle.Text = _MedicalDoctor.Middle
        txtPTRNO.Text = _MedicalDoctor.PTRNO
        txtAddress1.Text = _MedicalDoctor.Address1
        txtAddress2.Text = _MedicalDoctor.Address2
        txtsuffix.Text = _MedicalDoctor.Suffix
        txtHabbiesAndInterest.Text = _MedicalDoctor.HabbiesAndInterest
        txtNameOfSpouse.Text = _MedicalDoctor.NameOfSpouse
        dtAnniversaryDate.Text = _MedicalDoctor.AnniversaryDate
        dttBirthday.Text = _MedicalDoctor.BirthDate

        If _MedicalDoctor.IsActive = True Then
            chkIsActive.Checked = True
        Else
            chkIsActive.Checked = False
        End If
        If _MedicalDoctor.Enrolled = 1 Then
            Check_Enrolled.Checked = True
        Else
            Check_Enrolled.Checked = False
        End If

        If _MedicalDoctor.Gender = 1 Then
            OptionMale.IsChecked = True
        ElseIf _MedicalDoctor.Gender = 2 Then
            OptionFemale.IsChecked = True
        End If
        If Not _MedicalDoctor.CivilStatus = String.Empty Then
            txtCivilStatusName.Tag = _MedicalDoctor.CivilStatus
            m_CivilStatus = _MedicalDoctor.CivilStatus
            txtCivilStatusName.Text = CivilStatus.GetCivilStatus(_MedicalDoctor.CivilStatus)
        End If
        EditMode(False)
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If txtMDNumber.Text = "" Then
            m_Err.SetError(txtMDNumber, "Medical Doctor Number is Required!")
            m_HasError = True
        Else
            If MedicalDoctorPersonel.CheckofMedicalDoctorPersonelAlreadyExist(txtMDNumber.Text, IIf(txtMDNumber.Tag Is Nothing, -1, txtMDNumber.Tag)) Then
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
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(MedicalDoctorPersonel.GetMedicalDoctorPersonelSql, "Medical Doctor Personel")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
            'ShowDataWithBranchDrugs(tag.KeyColumn22)
            EditMode(False)
        End If
    End Sub


    Private Sub FindPosition_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles FindCivilStatus.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(CivilStatus.GetCivilStatusSql, "Civil Status")
        If Not tag Is Nothing Then
            m_CivilStatus = tag.KeyColumn11
            txtCivilStatusName.Text = tag.KeyColumn33
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.GrdViewChild.Rows.Add(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.GrdViewEducational.Rows.Add(Nothing, DateTime.Now, Nothing, DateTime.Now)
    End Sub
End Class
