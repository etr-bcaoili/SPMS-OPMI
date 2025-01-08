Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Public Class ucMasterItemDivisions
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private _ItemDivision As New ItemDivision
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnUpdate.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtCode.ReadOnly = Not IsEditMode
        txtCode.BackColor = Color.White

        txtDescription.ReadOnly = Not IsEditMode
        txtDescription.BackColor = Color.White
    End Sub
    Private Sub EnableTextbox(ByVal IsEditMode As Boolean)
        txtCode.Enabled = Not IsEditMode
    End Sub
    Private Sub Clear()
        txtCode.Text = String.Empty
        txtDescription.Text = String.Empty
        txtCode.Tag = -1
    End Sub
    Private Sub NewRecord()
        Clear()
        _ItemDivision = New ItemDivision
        EditMode(True)
        EnableTextbox(False)
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
    Private Sub SaveRecord()
        _ItemDivision.ItemDivisionCode = txtCode.Text
        _ItemDivision.ItemDivisionName = txtDescription.Text
        If _ItemDivision.Save Then
            SaveSuccess()
            ShowData(_ItemDivision.ID)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog() = DialogResult.Yes Then
            If _ItemDivision.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        If RecordCode < 1 Then Exit Sub
        _ItemDivision = ItemDivision.Load(RecordCode)
        txtCode.Tag = _ItemDivision.ID
        txtCode.Text = _ItemDivision.ItemDivisionCode
        txtDescription.Text = _ItemDivision.ItemDivisionName
        EditMode(False)
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If txtCode.Text = "" Then
            m_Err.SetError(txtCode, "Item Code Division is Required!")
            m_HasError = True
        Else
            If ItemDivision.CheckOfItemDivisionAlreadyExist(txtCode.Text, IIf(txtCode.Tag Is Nothing, -1, txtCode.Tag)) Then
                m_Err.SetError(txtCode, "Item Code Division Already Exist")
                m_HasError = True
            End If
        End If
        If txtDescription.Text = "" Then
            m_Err.SetError(txtDescription, "Item Division Description is Required!")
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
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ItemDivision.GetItemDivisionSql, "Distributor")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
            EditMode(False)
        End If
    End Sub
    Private Sub ucMasterItemDivisions_Load(sender As Object, e As EventArgs) Handles Me.Load
        EditMode(False)
        Clear()
    End Sub
End Class
