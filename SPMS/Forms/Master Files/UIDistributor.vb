Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Public Class UIDistributor
    Private _Distributor As New Distributor
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False

    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnUpdate.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtChannelCode.ReadOnly = Not IsEditMode
        txtChannelCode.BackColor = Color.White

        txtDistributor.ReadOnly = Not IsEditMode
        txtDistributor.BackColor = Color.White

        txtAddress.ReadOnly = Not IsEditMode
        txtAddress.BackColor = Color.White

    End Sub
    Private Sub Clear()
        txtChannelCode.Text = String.Empty
        txtDistributor.Text = String.Empty
        txtAddress.Text = String.Empty
    End Sub
    Private Sub NewRecord()
        Clear()
        _Distributor = New Distributor
        EditMode(True)
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnDelete.Click, btnUpdate.Click, btnFind.Click, btnSave.Click, btnClear.Click, btnClose.Click
        If sender Is btnNew Then
            NewRecord()
        ElseIf sender Is btnDelete Then
            Delete()
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
    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If txtChannelCode.Text = "" Then
            m_Err.SetError(txtChannelCode, "Channel Code is Required!")
            m_HasError = True
        Else
            If Distributor.CheckofDistributorAlreadyExist(txtChannelCode.Text, IIf(txtChannelCode.Tag Is Nothing, -1, txtChannelCode.Tag)) Then
                m_Err.SetError(txtChannelCode, "Channel Code Already Exist")
                m_HasError = True
            End If
        End If
        If txtDistributor.Text = "" Then
            m_Err.SetError(txtDistributor, "Description is Required!")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Distributor.GetDistributorSql, "Distributor")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
            EditMode(False)
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        If RecordCode < 1 Then Exit Sub
        _Distributor = Distributor.Load(RecordCode)
        txtChannelCode.Tag = _Distributor.DISTRIBUTORID
        txtChannelCode.Text = _Distributor.DISTCOMID
        txtDistributor.Text = _Distributor.DISTNAME
        txtAddress.Text = _Distributor.ADDR
        EditMode(False)
    End Sub
    Private Sub SaveRecord()
        _Distributor.DISTCOMID = txtChannelCode.Text
        _Distributor.DISTNAME = txtDistributor.Text
        _Distributor.ADDR = txtAddress.Text
        If _Distributor.Save Then
            SaveSuccess()
            ShowData(_Distributor.DISTRIBUTORID)
            EditMode(False)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog() = MsgBoxResult.Yes Then
            If _Distributor.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub
End Class
