Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.Windows
Imports Telerik.WinControls
Imports Telerik.Windows.Controls
Imports Telerik.WinControls.UI
Public Class UIPosition
    Private _Position As New Position
    Private table As New DataTable
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False

    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtCode.ReadOnly = Not IsEditMode
        txtCode.BackColor = Color.White

        txtDescription.ReadOnly = Not IsEditMode
        txtDescription.BackColor = Color.White
    End Sub
    Private Sub EditDefault(ByVal IsEditMode As Boolean)

        txtCode.ReadOnly = Not IsEditMode
        txtCode.BackColor = Color.WhiteSmoke

        txtDescription.ReadOnly = Not IsEditMode
        txtDescription.BackColor = Color.WhiteSmoke
    End Sub
    Private Sub Clear()
        txtCode.Text = String.Empty
        txtDescription.Text = String.Empty
    End Sub
    Private Sub NewRecord()
        Clear()
        _Position = New Position
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
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Position.GetPositionSql, "Position")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
            EditMode(False)
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

        If txtCode.Text = "" Then
            m_Err.SetError(txtCode, "Position Code is Required!")
            m_HasError = True
        Else
            If Position.CheckofPositionAlreadyExist(txtCode.Text, IIf(txtCode.Tag Is Nothing, -1, txtCode.Tag)) Then
                m_Err.SetError(txtCode, "Position Code Already Exist")
                m_HasError = True
            End If
        End If
        Return Not m_HasError
    End Function
    Private Sub SaveRecord()
        _Position.Code = txtCode.Text
        _Position.Description = txtDescription.Text
        _Position.EffectivityStartDate = dtStartDate.Text
        _Position.EffectivityEndDate = dtEnddate.Text
        If chkIsActive.Checked = True Then
            _Position.IsActive = True
        Else
            _Position.IsActive = False
        End If

        If _Position.Save Then
            SaveSuccess()
            ShowData(_Position.ID)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        If RecordCode < 1 Then Exit Sub
        _Position = Position.Load(RecordCode)
        txtCode.Tag = _Position.ID
        txtCode.Text = _Position.Code
        txtDescription.Text = _Position.Description
        dtStartDate.Text = _Position.EffectivityStartDate
        dtEnddate.Text = _Position.EffectivityStartDate
        If _Position.IsActive = True Then
            chkIsActive.Checked = True
        Else
            chkIsActive.Checked = False
        End If
        EditMode(False)
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog() = DialogResult.Yes Then
            If _Position.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub

    Private Sub UIPosition_Load(sender As Object, e As EventArgs) Handles Me.Load
        EditDefault(False)
        dtStartDate.Text = DateTime.Now
        dtEnddate.Text = DateTime.Now
    End Sub
End Class
