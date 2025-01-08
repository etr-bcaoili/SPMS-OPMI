Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Public Class ucMasterMunicipalityLocations
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_Regions As New Regions
    Private m_CityProvince As New Districts
    Private m_ML As New Area

    Private Sub EditMode(ByVal IsEditMode As Boolean)
        LinkLabel3.Enabled = IsEditMode
        LinkLabel1.Enabled = IsEditMode
        btnSave.Enabled = IsEditMode
        btnUpdate.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtDistrictCode.ReadOnly = Not IsEditMode
        txtDistrictCode.BackColor = Color.White

        txtDistrictName.ReadOnly = Not IsEditMode
        txtDistrictName.BackColor = Color.White

        txtRegionCode.ReadOnly = Not IsEditMode
        txtRegionCode.BackColor = Color.White

        txtRegionDescription.ReadOnly = Not IsEditMode
        txtRegionDescription.BackColor = Color.White

        txtMLCode.ReadOnly = Not IsEditMode
        txtMLCode.BackColor = Color.White

        txtMLName.ReadOnly = Not IsEditMode
        txtMLName.BackColor = Color.White

    End Sub
    Private Sub Clear()
        txtDistrictCode.Text = String.Empty
        txtDistrictName.Text = String.Empty
        txtRegionCode.Text = String.Empty
        txtRegionDescription.Text = String.Empty
        txtMLCode.Text = String.Empty
        txtMLName.Text = String.Empty
    End Sub
    Private Sub EnableTextBox(ByVal IsEditMode As Boolean)
        txtMLCode.Enabled = Not IsEditMode
    End Sub
    Private Sub NewRecord()
        Clear()
        m_ML = New Area
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
            If m_ML.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub
    Private Sub SaveRecord()
        m_ML.DistrictCode = txtDistrictCode.Text
        m_ML.RegionCode = txtRegionCode.Text
        m_ML.AreaCode = txtMLCode.Text
        m_ML.AreaName = txtMLName.Text
        If m_ML.Save Then
            SaveSuccess()
            EditMode(False)
            ShowData(m_ML.ID)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        If RecordCode < 1 Then Exit Sub
        m_ML = Area.Load(RecordCode)
        txtMLCode.Tag = m_ML.ID
        txtMLCode.Text = m_ML.AreaCode
        txtMLName.Text = m_ML.AreaName

        If Not m_ML.RegionCode = String.Empty Then
            If Regions.CheckCustomerRegion1(m_ML.RegionCode) = False Then
                txtRegionCode.Text = String.Empty
                txtRegionDescription.Text = String.Empty
            Else
                LoadRegion(m_ML.RegionCode)
            End If
        End If

        If Not m_ML.DistrictCode = String.Empty Then
            If Districts.GetDistrictsql2(m_ML.DistrictCode) = False Then
                txtDistrictCode.Text = String.Empty
                txtDistrictName.Text = String.Empty
            Else
                LoadDistrict(m_ML.DistrictCode)
            End If
        End If
        EditMode(False)
    End Sub
   
    Private Sub LoadDistrict(ByVal DistrictCode As String)
        m_CityProvince = Districts.LoadByCode(DistrictCode)
        txtDistrictCode.Text = m_CityProvince.DistrinctCode
        txtDistrictName.Text = m_CityProvince.DistrictName
    End Sub
    Private Sub LoadRegion(ByVal RegionCode As String)
        m_Regions = Regions.LoadByCode(RegionCode)
        txtRegionCode.Text = m_Regions.RegionCode
        txtRegionDescription.Text = m_Regions.RegionName
    End Sub
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Regions.GetRegionSql, "Region")
        If Not tag Is Nothing Then
            LoadRegion(tag.KeyColumn11)
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If txtRegionCode.Text = "" Then

            Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Districts.GetDistrictSql, "Region")
            If Not tag Is Nothing Then
                LoadDistrict(tag.KeyColumn11)
            End If
        Else
            Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Districts.GetDistrictbyRegion(txtRegionCode.Text))
            If Not tag Is Nothing Then
                LoadDistrict(tag.KeyColumn11)

            End If
        End If
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If txtMLCode.Text = "" Then
            m_Err.SetError(txtMLCode, "Municipality/Location Code is Required!")
            m_HasError = True
        Else
            If Area.CheckCustomerArea1(txtMLCode.Text, IIf(txtMLCode.Tag Is Nothing, -1, txtMLCode.Tag)) Then
                m_Err.SetError(txtMLCode, "Municipality/Location Code Already Exist")
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

        If txtMLCode.Text = "" Then
            m_Err.SetError(txtMLCode, "City/Province Code is Required!")
            m_HasError = True
        End If

        If txtMLName.Text = "" Then
            m_Err.SetError(txtMLName, "City/Province Name is Required!")
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
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Area.GetAreaSql1, "Municipality")
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
