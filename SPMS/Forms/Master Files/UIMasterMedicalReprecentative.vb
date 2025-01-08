Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class UIMasterMedicalReprecentative
    Private _Employee As New MedicalRepresentative
    Private _ConfigurationType As New Configuration
    Dim table As New DataTable

    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False

    Private m_EditFile As Boolean = False

    Dim dt As SqlDataReader

    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtEmployeeCode.ReadOnly = Not IsEditMode
        txtEmployeeCode.BackColor = Color.White

        txtEmployeeName.ReadOnly = Not IsEditMode
        txtEmployeeName.BackColor = Color.White

        txtPositionCode.ReadOnly = Not IsEditMode
        txtPositionCode.BackColor = Color.White

        txtPositionName.ReadOnly = Not IsEditMode
        txtPositionName.BackColor = Color.White

        txtTerroryName.ReadOnly = Not IsEditMode
        txtTerritoryCode.BackColor = Color.White

        txtTerroryName.ReadOnly = Not IsEditMode
        txtTerroryName.BackColor = Color.White

        txtConfigCode.ReadOnly = Not IsEditMode
        txtConfigCode.BackColor = Color.White

        txtConfgName.ReadOnly = Not IsEditMode
        txtConfgName.BackColor = Color.White

        txtEmailAddress.ReadOnly = Not IsEditMode
        txtEmailAddress.BackColor = Color.White

    End Sub
    Private Sub EditModes(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtEmployeeCode.ReadOnly = IsEditMode

        txtEmployeeName.ReadOnly = Not IsEditMode
        txtEmployeeName.BackColor = Color.White

        txtPositionCode.ReadOnly = Not IsEditMode
        txtPositionCode.BackColor = Color.White

        txtPositionName.ReadOnly = Not IsEditMode
        txtPositionName.BackColor = Color.White

        txtTerroryName.ReadOnly = Not IsEditMode
        txtTerritoryCode.BackColor = Color.White

        txtTerroryName.ReadOnly = Not IsEditMode
        txtTerroryName.BackColor = Color.White

        txtConfigCode.ReadOnly = Not IsEditMode
        txtConfigCode.BackColor = Color.White

        txtConfgName.ReadOnly = Not IsEditMode
        txtConfgName.BackColor = Color.White

        txtEmailAddress.ReadOnly = Not IsEditMode
        txtEmailAddress.BackColor = Color.White
    End Sub
    Private Sub NewRecord()
        Clear()
        _Employee = New MedicalRepresentative
        EditMode(True)
    End Sub
    Private Sub Clear()
        txtEmployeeCode.Text = String.Empty
        txtEmployeeName.Text = String.Empty
        txtPositionCode.Text = String.Empty
        txtPositionName.Text = String.Empty
        txtTerroryName.Text = String.Empty
        txtTerritoryCode.Text = String.Empty
        txtConfigCode.Text = String.Empty
        txtConfgName.Text = String.Empty
        txtEmailAddress.Text = String.Empty
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnDelete.Click, btnEdit.Click, btnFinddata.Click, btnSave.Click, btnClear.Click, btnClose.Click
        If sender Is btnNew Then
            NewRecord()
        ElseIf sender Is btnDelete Then
            Delete()
        ElseIf sender Is btnEdit Then
            EditMode(True)
            m_EditFile = True
        ElseIf sender Is btnClear Then
            Clear()
            EditMode(False)
        ElseIf sender Is btnClose Then
            Close()
        ElseIf sender Is btnFinddata Then
            Find()
        ElseIf sender Is btnSave Then
            If m_EditFile = True Then
                If ValidateData() Then
                    UpdateRecord()
                    MedicalRepresentative.UpdateRecordSharing(txtConfigCode.Text, txtEmployeeCode.Text, txtEmployeeName.Text)
                    MedicalRepresentative.UpdateRecordSalesmatrix(txtConfigCode.Text, txtEmployeeCode.Text, txtEmployeeName.Text, txtTerroryName.Text)
                    m_EditFile = False
                Else
                    If ValidateData() Then
                        SaveRecord()
                    End If
                End If
            Else
                If ValidateData() Then
                    SaveRecord()
                End If
            End If
        End If
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If m_EditFile = False Then
            If txtEmployeeCode.Text = "" Then
                m_Err.SetError(txtEmployeeCode, "Employee Code or Medical Rep Code is Required!")
                m_HasError = True
            Else
                If MedicalRepresentative.CheckofMedicalRepAlreadyExist(txtEmployeeCode.Text) Then
                    m_Err.SetError(txtEmployeeCode, "Employee Code or Medical Rep Code Already Exist")
                    m_HasError = True
                End If
            End If
        Else

        End If

        If txtEmployeeName.Text = "" Then
            m_Err.SetError(txtEmployeeName, "Employee Name or Medical Rep Name is Required!")
            m_HasError = True
        End If

        If txtPositionCode.Text = "" Then
            m_Err.SetError(txtPositionCode, "Position Code is Required!")
            m_HasError = True
        End If

        If txtPositionName.Text = "" Then
            m_Err.SetError(txtPositionName, "Position Name is Required!")
            m_HasError = True
        End If

        If txtTerritoryCode.Text = "" Then
            m_Err.SetError(txtTerritoryCode, "Territory Code is Required!")
            m_HasError = True
        End If

        If txtTerroryName.Text = "" Then
            m_Err.SetError(txtTerroryName, "Territory Name is Required!")
            m_HasError = True
        End If

        If txtConfigCode.Text = "" Then
            m_Err.SetError(txtConfigCode, "Configtype Code is Required!")
            m_HasError = True
        End If

        If txtConfgName.Text = "" Then
            m_Err.SetError(txtConfgName, "Configtype Name is Required!")
            m_HasError = True
        End If


        Return Not m_HasError
    End Function
    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(MedicalRepresentative.GetMedicalRepSql, "Medical Representative")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
            ShowByPMRDataSource(tag.KeyColumn11, _Employee.ConfigTypeCode)
            EditMode(False)
        End If
    End Sub
    Private Sub SaveRecord()
        _Employee.SLSMNCD = txtEmployeeCode.Text
        _Employee.SLSMNNAME = txtEmployeeName.Text
        _Employee.PositionCode = txtPositionCode.Text
        _Employee.PositionName = txtPositionName.Text
        _Employee.TerritoryCode = txtTerritoryCode.Text
        _Employee.TerritoryName = txtTerroryName.Text
        _Employee.ConfigTypeCode = txtConfigCode.Text
        _Employee.EffectivityStartDate = dtEffectivityStartDate.Text
        _Employee.EffectivityEndDate = dtEffectivityEndDate.Text
        _Employee.EmailAddress = txtEmailAddress.Text
        If _Employee.Save Then
            SaveSuccess()
            ShowData(_Employee.SLSMNCD)
            EditMode(False)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub UpdateRecord()
        _Employee.SLSMNCD = txtEmployeeCode.Text
        _Employee.SLSMNNAME = txtEmployeeName.Text
        _Employee.PositionCode = txtPositionCode.Text
        _Employee.PositionName = txtPositionName.Text
        _Employee.TerritoryCode = txtTerritoryCode.Text
        _Employee.TerritoryName = txtTerroryName.Text
        _Employee.ConfigTypeCode = txtConfigCode.Text
        _Employee.EmailAddress = txtEmailAddress.Text
        If IscheckEmail.Checked = True Then
            _Employee.IsActiveEmail = True
        Else
            _Employee.IsActiveEmail = False
        End If

        If _Employee.Update Then
            SaveSuccess()
            ShowData(_Employee.SLSMNCD)
            EditMode(False)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        If RecordCode Is Nothing Then Exit Sub
        _Employee = MedicalRepresentative.LoadByCode(RecordCode)
        'txtEmployeeCode.Tag = _Employee.
        txtEmployeeCode.Text = _Employee.SLSMNCD
        txtEmployeeName.Text = _Employee.SLSMNNAME
        txtPositionCode.Text = _Employee.PositionCode
        txtPositionName.Text = _Employee.PositionName
        txtTerritoryCode.Text = _Employee.TerritoryCode
        txtTerroryName.Text = _Employee.TerritoryName
        dtEffectivityStartDate.Text = _Employee.EffectivityStartDate
        dtEffectivityEndDate.Text = _Employee.EffectivityEndDate

        If Not _Employee.ConfigTypeCode = String.Empty Then
            txtConfigCode.Tag = _Employee.ConfigTypeCode
            txtConfigCode.Text = _Employee.ConfigTypeCode
            txtConfgName.Text = Configuration.GetConfigTypeCode(txtConfigCode.Tag)
        End If

        txtEmailAddress.Text = _Employee.EmailAddress

        If _Employee.IsActiveEmail = True Then
            IscheckEmail.Checked = True
        Else
            IscheckEmail.Checked = False
        End If
    End Sub
    Private Sub ShowByPMRDataSource(ByVal PMRCode As String, ByVal ConfigtypeCode As String)
        Try
            Connect()
            Dim cmd As SqlCommand = New SqlCommand("uspTMLbyConfig", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@TMLCode", PMRCode)
            cmd.Parameters.AddWithValue("@ConfigtypeCode", ConfigtypeCode)
            DataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            GrdViewPeriodOfTransaction.Rows.Clear()
            dt = DataReader
            Do While DataReader.Read = True
                Dim rowinfo As GridViewRowInfo = GrdViewPeriodOfTransaction.Rows.AddNew
                rowinfo.Cells(0).Value = True
                rowinfo.Cells(1).Value = dt(0)
                rowinfo.Cells(2).Value = dt(1)
                rowinfo.Cells(3).Value = dt(2)
                rowinfo.Cells(4).Value = dt(3)
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog = MsgBoxResult.Yes Then
            If _Employee.Delete Then
                _Employee.SLSMNCD = txtEmployeeCode.Text
                DeleteSuccess()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub

    Private Sub FindNatureOfCoverage_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(UCproductManager.GetPositionsql, "Medical Position")
        If Not tag Is Nothing Then
            txtPositionCode.Text = tag.KeyColumn11
            txtPositionName.Text = tag.KeyColumn33
        End If
    End Sub

    Private Sub FindTerritory_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(frmViewStAreaCoverage.GetTerritoryArea, "Medical Territory")
        If Not tag Is Nothing Then
            txtTerritoryCode.Text = tag.KeyColumn11
            txtTerroryName.Text = tag.KeyColumn33
        End If
    End Sub

    Private Sub Findconfig_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Medical Configuration")
        If Not tag Is Nothing Then
            txtConfigCode.Text = tag.KeyColumn11
            txtConfgName.Text = tag.KeyColumn33
        End If
    End Sub

    Private Sub FindPosition_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles FindPosition.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(UCproductManager.GetPositionsql, "Medical Position")
        If Not tag Is Nothing Then
            txtPositionCode.Text = tag.KeyColumn11
            txtPositionName.Text = tag.KeyColumn33
        End If
    End Sub

    Private Sub FindTerritory_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles FindTerritory.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(frmViewStAreaCoverage.GetTerritoryArea, "Medical Territory")
        If Not tag Is Nothing Then
            txtTerritoryCode.Text = tag.KeyColumn11
            txtTerroryName.Text = tag.KeyColumn33
        End If
    End Sub

    Private Sub Findconfig_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Findconfig.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Medical Configuration")
        If Not tag Is Nothing Then
            txtConfigCode.Text = tag.KeyColumn11
            txtConfgName.Text = tag.KeyColumn33
        End If
    End Sub

    Private Sub UIMasterMedicalReprecentative_Load(sender As Object, e As EventArgs) Handles Me.Load
        EditMode(False)
        dtFromDate.Value = DateTime.Now
        dtTodate.Value = DateTime.Now
    End Sub
End Class
