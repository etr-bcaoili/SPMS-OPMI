Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.WinControls.UI
Public Class UISalesManager
    Private _SalesDistrictManager As New SalesManager
    Private _ConfigurationType As New Configuration

    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Dim table As New DataTable
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtDistrictCode.ReadOnly = Not IsEditMode
        txtDistrictCode.BackColor = Color.White

        txtDistrictSalesManager.ReadOnly = Not IsEditMode
        txtDistrictSalesManager.BackColor = Color.White

        txtConfigCode.ReadOnly = Not IsEditMode
        txtConfigCode.BackColor = Color.White



        txtEmailAddress.ReadOnly = Not IsEditMode
        txtEmailAddress.BackColor = Color.White

        GrdViewPeriodOfTransaction.ReadOnly = Not IsEditMode
    End Sub
    Private Sub Clear()
        txtDistrictSalesManager.Text = String.Empty
        txtDistrictCode.Text = String.Empty
        txtConfigCode.Text = String.Empty
        txtEmailAddress.Text = String.Empty
    End Sub
    Private Sub NewRecord()
        Clear()
        _SalesDistrictManager = New SalesManager
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
                UpdateProcess()
                SaveRecord()
            End If
        End If
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(SalesManager.GetDistrictManagerSql, "Sales Manager District")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
            ShowDataGrid(txtConfigCode.Text, txtDistrictCode.Text)
            EditMode(False)
        End If
    End Sub
    Private Sub ShowDataGrid(ByVal Congfig As String, ByVal DistrictCode As String)
        table = GetRecords(SalesManager.GetDistrictManagerProcessSql(Congfig, DistrictCode))
        GrdViewPeriodOfTransaction.Rows.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewPeriodOfTransaction.Rows.AddNew
            rowinfo.Cells(0).Value = False
            rowinfo.Cells(1).Value = table.Rows(i)("Year")
            rowinfo.Cells(2).Value = table.Rows(i)("Month")
            rowinfo.Cells(3).Value = table.Rows(i)("Configtypecode")
            rowinfo.Cells(4).Value = table.Rows(i)("District Manager Code")
        Next
    End Sub
    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Sub SaveRecord()
        _SalesDistrictManager.DistrictCode = txtDistrictCode.Text
        _SalesDistrictManager.DistrictName = txtDistrictSalesManager.Text
        _SalesDistrictManager.ConfigtypeCode = txtConfigCode.Text
        _SalesDistrictManager.EffectivityStartDate = dtEffectivityStartDate.Text
        _SalesDistrictManager.EffectivityEndDate = dtEffectivityEndDate.Text
        _SalesDistrictManager.EmailAddress = txtEmailAddress.Text
        If IscheckEmail.Checked = True Then
            _SalesDistrictManager.EmailIsActive = True
        Else
            _SalesDistrictManager.EmailIsActive = False
        End If
        If _SalesDistrictManager.Save Then
            SaveSuccess()
            ShowData(_SalesDistrictManager.DistrictID)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub UpdateProcess()
        For i As Integer = 0 To GrdViewPeriodOfTransaction.Rows.Count - 1
            Dim rowinfos As GridViewRowInfo = GrdViewPeriodOfTransaction.Rows(i)
            If rowinfos.Cells(0).Value = True Then
                SalesManager.UpdatebyProcessDistrictManager(rowinfos.Cells(1).Value, rowinfos.Cells(2).Value, rowinfos.Cells(3).Value, txtDistrictCode.Text, txtDistrictSalesManager.Text)
            End If
        Next
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If txtDistrictCode.Text = "" Then
            m_Err.SetError(txtDistrictCode, "District Code is Required!")
            m_HasError = True
        Else
            If SalesManager.CheckofDistrictManagerAlreadyExist(txtDistrictCode.Text, txtConfigCode.Text, IIf(txtDistrictCode.Tag Is Nothing, -1, txtDistrictCode.Tag)) Then
                m_Err.SetError(txtDistrictCode, "District Code Already Exist")
                m_HasError = True
            End If
        End If
        If txtDistrictSalesManager.Text = "" Then
            m_Err.SetError(txtDistrictSalesManager, "District Description is Required!")
            m_HasError = True
        End If
        Return Not m_HasError
    End Function
    Private Sub Delete()
        If ShowDeleteDialog() = DialogResult.Yes Then
            If _SalesDistrictManager.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        _SalesDistrictManager = SalesManager.LoadID(RecordCode)
        txtDistrictCode.Tag = _SalesDistrictManager.DistrictID
        txtDistrictCode.Text = _SalesDistrictManager.DistrictCode
        txtDistrictSalesManager.Text = _SalesDistrictManager.DistrictName
        dtEffectivityStartDate.Text = _SalesDistrictManager.EffectivityStartDate
        dtEffectivityEndDate.Text = _SalesDistrictManager.EffectivityEndDate
        txtConfigCode.Text = _SalesDistrictManager.ConfigtypeCode
        txtEmailAddress.Text = _SalesDistrictManager.EmailAddress
        EditMode(False)
    End Sub
    Private Sub Findconfig_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Findconfig.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Medical Configuration")
        If Not tag Is Nothing Then
            txtConfigCode.Text = tag.KeyColumn11
        End If
    End Sub
End Class
