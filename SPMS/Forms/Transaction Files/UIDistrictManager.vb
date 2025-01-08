Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Public Class UIDistrictManager
    Private _DistrictAssignment As New DistrictAssignment
    Private _Regions As New STRegion
    Private _SalesManager As New SalesManager
    Private _District As New STDistrict
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
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
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If txtDistrictCode.Text = "" Then
            m_Err.SetError(txtDistrictCode, "District Code is Required!")
            m_HasError = True
        End If
        If txtDistrictName.Text = "" Then
            m_Err.SetError(txtDistrictName, "District Description is Required!")
            m_HasError = True
        End If
        If txtDistrictSalesmanagerCode.Text = "" Then
            m_Err.SetError(txtDistrictSalesmanagerCode, "Sales Manager Code")
            m_HasError = True
        End If
        If txtDistrictSalesManagerName.Text = "" Then
            m_Err.SetError(txtDistrictSalesManagerName, "Sales Manager Name")
        End If
        If txtRegionCode.Text = "" Then
            m_Err.SetError(txtRegionCode, "Region Code is Required!")
            m_HasError = True
        End If
        If txtRegionName.Text = "" Then
            m_Err.SetError(txtRegionName, "Region Name is Required!")
            m_HasError = True
        End If
        Return Not m_HasError
    End Function
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtDistrictCode.ReadOnly = Not IsEditMode
        txtDistrictCode.BackColor = Color.White

        txtDistrictName.ReadOnly = Not IsEditMode
        txtDistrictName.BackColor = Color.White

        txtRegionCode.ReadOnly = Not IsEditMode
        txtRegionCode.BackColor = Color.White

        txtRegionName.ReadOnly = Not IsEditMode
        txtRegionName.BackColor = Color.White

        txtDistrictSalesmanagerCode.ReadOnly = Not IsEditMode
        txtDistrictSalesmanagerCode.BackColor = Color.White

        txtDistrictSalesManagerName.ReadOnly = Not IsEditMode
        txtDistrictSalesManagerName.BackColor = Color.White

    End Sub
    Private Sub Clear()
        txtDistrictSalesmanagerCode.Text = String.Empty
        txtDistrictSalesManagerName.Text = String.Empty
        txtDistrictName.Text = String.Empty
        txtDistrictCode.Text = String.Empty
        txtRegionCode.Text = String.Empty
        txtRegionName.Text = String.Empty
    End Sub
    Private Sub NewRecord()
        Clear()
        _DistrictAssignment = New DistrictAssignment
        EditMode(True)
    End Sub
    Private Sub SaveRecord()
        _DistrictAssignment.RegionCodde = txtRegionCode.Text
        _DistrictAssignment.DistrictCode = txtDistrictCode.Text
        _DistrictAssignment.DistrictName = txtDistrictName.Text
        _DistrictAssignment.DMDistrictCode = txtDistrictSalesmanagerCode.Text
        If _DistrictAssignment.Save Then
            SaveSuccess()
            LoadDistrictAssign(_DistrictAssignment.DistrictCode)
        Else
            UnSuccesSave()
        End If
        EditMode(False)
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(DistrictAssignment.GetDMDistrictSql, "District Assignment")
        If Not tag Is Nothing Then
            LoadDistrictAssign(tag.KeyColumn22)
        End If
    End Sub
    Private Sub LoadDistrictAssign(ByVal RecordCode As String)
        Clear()
        _DistrictAssignment = DistrictAssignment.LoadByCode(RecordCode)
        txtDistrictCode.Tag = _DistrictAssignment.DistrictID
        txtDistrictCode.Text = _DistrictAssignment.DistrictCode
        txtDistrictName.Text = _DistrictAssignment.DistrictName
        If _DistrictAssignment.RegionCodde <> "" Then
            _Regions = STRegion.LoadByCode(_DistrictAssignment.RegionCodde)
            txtRegionCode.Text = _Regions.Code
            txtRegionName.Text = _Regions.Description
        Else
            txtRegionCode.Text = String.Empty
            txtRegionName.Text = String.Empty
        End If
        If _DistrictAssignment.DMDistrictCode <> "" Then
            _SalesManager = SalesManager.LoadByCode(_DistrictAssignment.DMDistrictCode)
            txtDistrictSalesmanagerCode.Text = _SalesManager.DistrictCode
            txtDistrictSalesManagerName.Text = _SalesManager.DistrictName
        Else
            txtDistrictSalesmanagerCode.Text = ""
            txtDistrictSalesManagerName.Text = ""
        End If
        dtEffectivityStartDate.Text = _DistrictAssignment.EffectivityStartDate
        dtEffectivityEndDate.Text = _DistrictAssignment.EffectivityEndDate
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog() = DialogResult.Yes Then
            If _DistrictAssignment.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub

    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(STDistrict.GetDistrictsql, "District")
        If Not tag Is Nothing Then
            LoadDistrict(tag.KeyColumn22)
        End If
    End Sub
    Private Sub LoadDistrict(ByVal RecordCode As String)
        _District = STDistrict.LoadByCode(RecordCode)
        txtDistrictCode.Text = _District.DistrictCode
        txtDistrictName.Text = _District.DistrictName
    End Sub

    Private Sub Findconfig_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Findconfig.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(STRegion.GetRegionsql, "Region")
        If Not tag Is Nothing Then
            ShowDataRegion(tag.KeyColumn22)
        End If
    End Sub
    Private Sub ShowDataRegion(ByVal RecordCode As String)
        _Regions = STRegion.LoadByCode(RecordCode)
        txtRegionCode.Text = _Regions.Code
        txtRegionName.Text = _Regions.Description
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(SalesManager.GetDistrictManagerSql, "Sales Manager District")
        If Not tag Is Nothing Then
            ShowDataSalesmanager(tag.KeyColumn22)
        End If
    End Sub
    Private Sub ShowDataSalesmanager(ByVal RecordCode As String)
        _SalesManager = SalesManager.LoadByCode(RecordCode)
        txtDistrictSalesmanagerCode.Text = _SalesManager.DistrictCode
        txtDistrictSalesManagerName.Text = _SalesManager.DistrictName
    End Sub

    Private Sub UIDistrictManager_Load(sender As Object, e As EventArgs) Handles Me.Load
        Clear()
        dtEffectivityStartDate.Text = Date.Now
        dtEffectivityEndDate.Text = Date.Now
    End Sub
End Class
