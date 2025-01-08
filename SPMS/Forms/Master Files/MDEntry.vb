Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.WinControls.UI
Imports Telerik.Windows
Imports Telerik.WinControls

Public Class MDEntry
    Dim _MedicalDoctor As New MedicalDoctor
    Dim _MedicalDoctorHospitalVisitClinic As New MedicalDoctorHospitalVisitClinic
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Dim table As New DataTable
    Private m_DoctorID As String = String.Empty
    Private m_CustomerShipto As New CustomerShipTo

    Public Property DoctorID As String
        Get
            Return m_DoctorID
        End Get
        Set(value As String)
            m_DoctorID = value
        End Set
    End Property
    Private Sub EditMode(ByVal IsEditMode As Boolean)

        btnSave.Enabled = IsEditMode
        btnUpdate.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtMDNumber.ReadOnly = Not IsEditMode
        txtMDNumber.BackColor = Color.White

        txtMDNumber.ReadOnly = Not IsEditMode
        txtMDNumber.BackColor = Color.White

        txtLastName.ReadOnly = Not IsEditMode
        txtLastName.BackColor = Color.White

        txtFirstName.ReadOnly = Not IsEditMode
        txtFirstName.BackColor = Color.White

        txtMiddleName.ReadOnly = Not IsEditMode
        txtMiddleName.BackColor = Color.White

        txtSuffix.ReadOnly = Not IsEditMode
        txtSuffix.BackColor = Color.White

        txtAddressLine1.ReadOnly = Not IsEditMode
        txtAddressLine1.BackColor = Color.White

        txtAddressLine2.ReadOnly = Not IsEditMode
        txtAddressLine2.BackColor = Color.White

        txtzipCode.ReadOnly = Not IsEditMode
        txtzipCode.BackColor = Color.White

        txtCity.ReadOnly = Not IsEditMode
        txtCity.BackColor = Color.White

        txtHomephone.ReadOnly = Not IsEditMode
        txtHomephone.BackColor = Color.White

        txtEmailAddress.ReadOnly = Not IsEditMode
        txtEmailAddress.BackColor = Color.White

    End Sub
    Private Function AutoTextAddGerated()
        Dim myDate As DateTime = DateTime.Now
        Dim format As String = "MMdHHmmss"
        Dim myYear As Int32 = myDate.Year
        Dim myMonth As Int32 = myDate.Month
        Try
            txtMDNumber.Text = "MD-" & myYear & Strings.Right(myDate.ToString(format), 15)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub Clear()
        txtMDNumber.Text = String.Empty
        txtMDNumber.Text = String.Empty
        txtLastName.Text = String.Empty
        txtSuffix.Text = String.Empty
        txtFirstName.Text = String.Empty
        txtMiddleName.Text = String.Empty
        OptionDoctor.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off
        OptionResource.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off
        OptionFacilty.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off
        CheckMidLevel.Checked = False
        CheckSpecialist.Checked = False
        CheckIndividual.Checked = False
        txtAddressLine1.Text = String.Empty
        txtAddressLine2.Text = String.Empty
        txtzipCode.Text = String.Empty
        txtCity.Text = String.Empty
        txtHomephone.Text = String.Empty
        txtEmailAddress.Text = String.Empty
        txtspecializationCode.Text = String.Empty
        txtspecializationName.Text = String.Empty
        GrdViewMedicalDoctor.Rows.Clear()
    End Sub
    Private Sub NewRecord()
        Clear()
        _MedicalDoctor = New MedicalDoctor
        EditMode(True)
        AutoTextAddGerated()
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If txtMDNumber.Text = "" Then
            m_Err.SetError(txtMDNumber, "Medical Doctor Number is Required!")
            m_HasError = True
        Else
            If MedicalDoctor.CheckofMedicalDoctorAlreadyExist(txtMDNumber.Text, IIf(txtMDNumber.Tag Is Nothing, -1, txtMDNumber.Tag)) Then
                m_Err.SetError(txtMDNumber, "Medical Doctor Number  Already Exist")
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
        If txtSuffix.Text = "" Then
            m_Err.SetError(txtSuffix, "Suffix is Required!")
            m_HasError = True
        End If

        If txtMiddleName.Text = "" Then
            m_Err.SetError(txtMiddleName, "Middle Name is Required!")
            m_HasError = True
        End If

        If txtAddressLine1.Text = "" Then
            m_Err.SetError(txtAddressLine1, "Address line is Required!")
            m_HasError = True
        End If

        If txtspecializationCode.Text = "" Then
            m_Err.SetError(txtspecializationCode, "Specialization Code is Required!")
            m_HasError = True
        End If

        If txtspecializationName.Text = "" Then
            m_Err.SetError(txtspecializationName, "Specialization Name is Required!")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click, btnDelete.Click, btnUpdate.Click, btnFind.Click, btnNew.Click, btnSave.Click, btnClear.Click
        If sender Is btnClose Then
            Close()
        ElseIf sender Is btnDelete Then
            Delete()
        ElseIf sender Is btnClear Then
            Clear()
            EditMode(False)
        ElseIf sender Is btnFind Then
            FindRecord()
        ElseIf sender Is btnNew Then
            NewRecord()
        ElseIf sender Is btnSave Then
            If ValidateData() Then
                SaveRecord()
            End If
        ElseIf sender Is btnUpdate Then
            EditMode(True)
        End If
    End Sub
    Private Sub SaveRecord()
        If chkIsActive.Checked = True Then
            _MedicalDoctor.IsActive = True
        Else
            _MedicalDoctor.IsActive = False
        End If
        _MedicalDoctor.DoctorNumber = txtMDNumber.Text
        _MedicalDoctor.FirstName = txtFirstName.Text
        _MedicalDoctor.Suffix = txtSuffix.Text
        _MedicalDoctor.LastName = txtLastName.Text
        _MedicalDoctor.MiddleName = txtMiddleName.Text
        If OptionDoctor.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            _MedicalDoctor.DoctorType = 1
        ElseIf OptionResource.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            _MedicalDoctor.DoctorType = 2
        ElseIf OptionFacilty.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            _MedicalDoctor.DoctorType = 3
        End If

        If CheckMidLevel.Checked = True Then
            _MedicalDoctor.MidLevel = True
        End If
        If CheckSpecialist.Checked = True Then
            _MedicalDoctor.Specialist = True
        End If
        If CheckIndividual.Checked = True Then
            _MedicalDoctor.Individual = True
        End If

        _MedicalDoctor.AddressLine1 = txtAddressLine1.Text
        _MedicalDoctor.AddressLine2 = txtAddressLine2.Text
        _MedicalDoctor.ZipCode = txtzipCode.Text
        _MedicalDoctor.City = txtCity.Text
        _MedicalDoctor.HomePhone = txtHomephone.Text
        _MedicalDoctor.EmailAddress = txtEmailAddress.Text



        If _MedicalDoctor.Save Then
            MedicalDoctorHospitalVisitClinic.DeleteAfterEditDoctor(_MedicalDoctor.DoctorID)
            For m As Integer = 0 To GrdViewMedicalDoctor.Rows.Count - 1
                Dim rowinfo As GridViewRowInfo = GrdViewMedicalDoctor.Rows(m)
                _MedicalDoctorHospitalVisitClinic.ClinicName = rowinfo.Cells(0).Value
                _MedicalDoctorHospitalVisitClinic.ClinicAddress = rowinfo.Cells(1).Value
                _MedicalDoctorHospitalVisitClinic.DoctorID = _MedicalDoctor.DoctorID
                _MedicalDoctorHospitalVisitClinic.Save()
            Next
            SaveSuccess()
            ShowData(_MedicalDoctor.DoctorID)
            ShowDataMedicalDoctorHospitalVisitClinic(_MedicalDoctor.DoctorID)
            EditMode(False)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub FindRecord()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(MedicalDoctor.GetMedicalDoctorsSql, "Medical Doctor")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
            ShowDataMedicalDoctorHospitalVisitClinic(tag.KeyColumn11)
            EditMode(False)
        End If
    End Sub
    Private Sub ShowDataMedicalDoctorHospitalVisitClinic(ByVal RecordCode As String)
        table = GetRecords(MedicalDoctorHospitalVisitClinic.GetMedicalDoctorHospitalVisitClinicSql(RecordCode))
        GrdViewMedicalDoctor.Rows.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowInfo As GridViewRowInfo = GrdViewMedicalDoctor.Rows.AddNew
            rowInfo.Cells(0).Value = table.Rows(i)("ClinicName")
            rowInfo.Cells(1).Value = table.Rows(i)("ClinicAddress")
        Next
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        If RecordCode < 1 Then Exit Sub
        _MedicalDoctor = MedicalDoctor.Load(RecordCode)
        m_DoctorID = _MedicalDoctor.DoctorID
        txtMDNumber.Tag = _MedicalDoctor.DoctorID
        txtMDNumber.Text = _MedicalDoctor.DoctorNumber
        txtFirstName.Text = _MedicalDoctor.FirstName
        txtSuffix.Text = _MedicalDoctor.Suffix
        txtLastName.Text = _MedicalDoctor.LastName
        txtMiddleName.Text = _MedicalDoctor.MiddleName
        If _MedicalDoctor.IsActive = True Then
            chkIsActive.Checked = True
        Else
            chkIsActive.Checked = False
        End If

        If _MedicalDoctor.DoctorType = 1 Then
            OptionDoctor.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On
        ElseIf _MedicalDoctor.DoctorType = 2 Then
            OptionResource.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On
        ElseIf _MedicalDoctor.DoctorType = 3 Then
            OptionFacilty.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On
        End If

        If _MedicalDoctor.MidLevel = True Then
            CheckMidLevel.Checked = True
        Else
            CheckMidLevel.Checked = False
        End If
        If _MedicalDoctor.Specialist = True Then
            CheckSpecialist.Checked = True
        Else
            CheckSpecialist.Checked = False
        End If
        If CheckIndividual.Checked = True Then
            CheckIndividual.Checked = True
        Else
            CheckIndividual.Checked = False
        End If

        txtAddressLine1.Text = _MedicalDoctor.AddressLine1
        txtAddressLine2.Text = _MedicalDoctor.AddressLine2
        txtzipCode.Text = _MedicalDoctor.ZipCode
        txtCity.Text = _MedicalDoctor.City
        txtHomephone.Text = _MedicalDoctor.HomePhone
        txtEmailAddress.Text = _MedicalDoctor.EmailAddress
        EditMode(False)
    End Sub
    Public Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog() = MsgBoxResult.Yes Then
            If _MedicalDoctor.Delete(m_DoctorID) Then
                If _MedicalDoctorHospitalVisitClinic.Delete(m_DoctorID) Then
                    DeleteSuccess()
                    NewRecord()
                Else
                    UnDeleteSuccess()
                End If
            End If
        End If
    End Sub
    Private Sub MDEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
        NewRecord()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckSpecialist.CheckedChanged

    End Sub

    Private Sub OptionDoctor_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles OptionDoctor.ToggleStateChanged
        If OptionDoctor.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            OptionResource.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off
            OptionFacilty.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off
        End If
    End Sub

    Private Sub OptionResource_ToggleStateChanged(sender As Object, args As StateChangedEventArgs) Handles OptionResource.ToggleStateChanged
        If OptionResource.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            OptionDoctor.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off
            OptionFacilty.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off
        End If
    End Sub

    Private Sub OptionFacilty_ToggleStateChanged(sender As Object, args As StateChangedEventArgs) Handles OptionFacilty.ToggleStateChanged
        If OptionFacilty.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On Then
            OptionDoctor.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off
            OptionResource.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off
        End If
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If txtClinicName.Text <> "" Or txtClinicAddress.Text <> "" Then
            Dim rowinfo As GridViewRowInfo = GrdViewMedicalDoctor.Rows.AddNew
            rowinfo.Cells(0).Value = txtClinicName.Text
            rowinfo.Cells(1).Value = txtClinicAddress.Text
        End If
        txtClinicAddress.Text = String.Empty
        txtClinicName.Text = String.Empty
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim selectedRows(Me.GrdViewMedicalDoctor.SelectedRows.Count - 1) As GridViewRowInfo
        Me.GrdViewMedicalDoctor.SelectedRows.CopyTo(selectedRows, 0)
        Me.GrdViewMedicalDoctor.TableElement.BeginUpdate()
        For i As Integer = 0 To selectedRows.Length - 1
            Me.GrdViewMedicalDoctor.Rows.Remove(TryCast(selectedRows(i), GridViewDataRowInfo))
        Next i
        Me.GrdViewMedicalDoctor.TableElement.EndUpdate()
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Find()
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(CustomerShipTo.GetCustomerSqls, "Customer List")
        If Not tag Is Nothing Then
            Clear()
            ShowDataCustomer(tag.KeyColumn22)
            EditMode(False)
        End If
    End Sub
    Private Sub ShowDataCustomer(ByVal RecordCode As String)
        m_CustomerShipto = CustomerShipTo.LoadbyCode(RecordCode)
        Dim rowinfo As GridViewRowInfo = GrdViewCustomer.Rows.AddNew
        rowinfo.Cells(0).Value = m_CustomerShipto.CUSTOMERCD
        rowinfo.Cells(1).Value = m_CustomerShipto.CDANAME
        rowinfo.Cells(2).Value = m_CustomerShipto.CDACD
        rowinfo.Cells(3).Value = m_CustomerShipto.CDACADD1
        rowinfo.Cells(4).Value = m_CustomerShipto.CDACADD2
    End Sub
End Class
