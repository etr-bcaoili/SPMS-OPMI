Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.WinControls
Public Class UIDistrictGroup
    Private _DistrictGroup As New DistrictGroup
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtCode.ReadOnly = Not IsEditMode
        txtCode.BackColor = Color.White

        txtDistrictName.ReadOnly = Not IsEditMode
        txtDistrictName.BackColor = Color.White

    End Sub
    Private Sub Clear()
        txtCode.Text = String.Empty
        txtDistrictName.Text = String.Empty
    End Sub
    Private Sub NewRecord()
        Clear()
        _DistrictGroup = New DistrictGroup
        EditMode(True)
    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click, btnClear.Click, btnDelete.Click, btnFinddata.Click, btnEdit.Click, btnSave.Click
        If sender Is btnNew Then
            NewRecord()
        ElseIf sender Is btnDelete Then
            Delete()
        ElseIf sender Is btnEdit Then
            EditMode(True)
        ElseIf sender Is btnSave Then
            If ValidateData() Then
                SaveRecord()
            End If
        ElseIf sender Is btnClear Then
            Clear()
        ElseIf sender Is btnFinddata Then
            FindData()
        End If
    End Sub
    Private Sub FindData()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(DistrictGroup.GetDistrictGroupql, "District Group")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn22)
            EditMode(False)
        End If
    End Sub
    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False

        If txtCode.Text = "" Then
            m_Err.SetError(txtCode, "District Code is Required!")
            m_HasError = True
        Else
            If DistrictGroup.CheckDistrictGroupIsAlreadyExist(txtCode.Text, IIf(txtCode.Tag Is Nothing, -1, txtCode.Tag)) Then
                m_Err.SetError(txtCode, "District Code Already Exist")
                m_HasError = True
            End If
        End If
        If txtDistrictName.Text = "" Then
            m_Err.SetError(txtDistrictName, "District Group Description is Required!")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
    Private Sub SaveRecord()
        _DistrictGroup.Code = txtCode.Text
        _DistrictGroup.Description = txtDistrictName.Text
        If _DistrictGroup.Save Then
            SaveSuccess()
            ShowData(_DistrictGroup.Code)
            EditMode(False)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog() = MsgBoxResult.Yes Then
            If _DistrictGroup.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        _DistrictGroup = DistrictGroup.LoadByCode(RecordCode)
        txtCode.Tag = _DistrictGroup.ID
        txtCode.Text = _DistrictGroup.Code
        txtDistrictName.Text = _DistrictGroup.Description
        EditMode(False)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
End Class
