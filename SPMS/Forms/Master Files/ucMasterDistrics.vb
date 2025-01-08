Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Public Class ucMasterDistrics
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_Regions As New Regions
    Private m_CityProvince As New Districts
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        LinkLabel3.Enabled = IsEditMode
        btnSave.Enabled = IsEditMode
        btnUpdate.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtCityPrivinceCode.ReadOnly = Not IsEditMode
        txtCityPrivinceCode.BackColor = Color.White

        txtCityProvinceDescription.ReadOnly = Not IsEditMode
        txtCityProvinceDescription.BackColor = Color.White

        txtRegionCode.ReadOnly = Not IsEditMode
        txtRegionCode.BackColor = Color.White

        txtRegionDescription.ReadOnly = Not IsEditMode
        txtRegionDescription.BackColor = Color.White

    End Sub
    Private Sub Clear()
        txtCityPrivinceCode.Text = String.Empty
        txtCityProvinceDescription.Text = String.Empty
        txtRegionCode.Text = String.Empty
        txtRegionDescription.Text = String.Empty
    End Sub
    Private Sub EnableTextBox(ByVal IsEditMode As Boolean)
        txtCityPrivinceCode.Enabled = Not IsEditMode
    End Sub
    Private Sub NewRecord()
        Clear()
        m_CityProvince = New Districts
        EditMode(True)
        EnableTextBox(False)
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnDelete.Click, btnUpdate.Click, btnFind.Click, btnSave.Click, btnClear.Click, btnClose.Click
        If sender Is btnNew Then
            NewRecord()
        ElseIf sender Is btnDelete Then
            Delete()
        ElseIf sender Is btnUpdate Then
            EditMode(True)
            EnableTextbox(True)
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
    Private Sub Delete()
        If ShowDeleteDialog() = DialogResult.Yes Then
            If m_CityProvince.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub
    Private Sub SaveRecord()
        m_CityProvince.DistrinctCode = txtCityPrivinceCode.Text
        m_CityProvince.DistrictName = txtCityProvinceDescription.Text
        m_CityProvince.RegionCode = txtRegionCode.Text
        If m_CityProvince.Save Then
            SaveSuccess()
            ShowData(m_CityProvince.ID)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        If RecordCode < 1 Then Exit Sub
        m_CityProvince = Districts.Load(RecordCode)
        txtCityPrivinceCode.Tag = m_CityProvince.ID
        txtCityPrivinceCode.Text = m_CityProvince.DistrinctCode
        txtCityProvinceDescription.Text = m_CityProvince.DistrictName

        If Not m_CityProvince.RegionCode = String.Empty Then
            If Regions.CheckCustomerRegion1(m_CityProvince.RegionCode) = False Then
                txtRegionCode.Text = String.Empty
                txtRegionDescription.Text = String.Empty
            Else
                LoadRegion(m_CityProvince.RegionCode)
            End If
        End If
        EditMode(False)
    End Sub
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Regions.GetRegionSql, "Region")
        If Not tag Is Nothing Then
            LoadRegion(tag.KeyColumn11)
        End If
    End Sub
    Private Sub LoadRegion(ByVal RegionCode As String)
        m_Regions = Regions.LoadByCode(RegionCode)
        txtRegionCode.Text = m_Regions.RegionCode
        txtRegionDescription.Text = m_Regions.RegionName
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If txtCityPrivinceCode.Text = "" Then
            m_Err.SetError(txtCityPrivinceCode, "City Province Code is Required!")
            m_HasError = True
        Else
            If Districts.CheckCustomerDistrict1(txtCityPrivinceCode.Text, IIf(txtCityPrivinceCode.Tag Is Nothing, -1, txtCityPrivinceCode.Tag)) Then
                m_Err.SetError(txtCityPrivinceCode, "City Province Code Already Exist")
                m_HasError = True
            End If
        End If

        If txtRegionCode.Text = "" Then
            m_Err.SetError(txtRegionCode, "Region Code is Required!")
            m_HasError = True
        End If

        If txtRegionDescription.Text = "" Then
            m_Err.SetError(txtRegionDescription, "Region Description is Required!")
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
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Districts.GetDistrictSql1, "City/Province")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
            EditMode(False)
        End If
    End Sub

    Private Sub ucMasterDistrics_Load(sender As Object, e As EventArgs) Handles Me.Load
        EditMode(False)
    End Sub
End Class
