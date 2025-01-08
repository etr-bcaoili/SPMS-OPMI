Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Public Class UIDistributorChannelGroup
    Private _Distributor As New Distributor
    Private _DistributorGroup As DistributorChannleGroup
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_Edit As Integer = 0

    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtChannelCode.ReadOnly = Not IsEditMode
        txtChannelCode.BackColor = Color.White

        txtChannelGroupCode.ReadOnly = Not IsEditMode
        txtChannelGroupCode.BackColor = Color.White

        txtChannelDescription.ReadOnly = Not IsEditMode
        txtChannelDescription.BackColor = Color.White

        txtChannelGroupDescription.ReadOnly = Not IsEditMode
        txtChannelGroupDescription.BackColor = Color.White
    End Sub
    Private Sub Clear()
        txtChannelCode.Text = String.Empty
        txtChannelGroupCode.Text = String.Empty
        txtChannelDescription.Text = String.Empty
        txtChannelGroupDescription.Text = String.Empty
    End Sub
    Private Sub EnableEdit(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtChannelCode.ReadOnly = IsEditMode
        txtChannelCode.BackColor = Color.WhiteSmoke

        txtChannelGroupCode.ReadOnly = IsEditMode
        txtChannelGroupCode.BackColor = Color.WhiteSmoke

        txtChannelDescription.ReadOnly = IsEditMode
        txtChannelDescription.BackColor = Color.WhiteSmoke

        txtChannelGroupDescription.ReadOnly = Not IsEditMode
        txtChannelGroupDescription.BackColor = Color.White
    End Sub
    Private Sub NewRecord()
        Clear()
        _DistributorGroup = New DistributorChannleGroup
        EditMode(True)
        m_Edit = 1
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnDelete.Click, btnEdit.Click, btnFinddata.Click, btnSave.Click, btnClear.Click, btnClose.Click
        If sender Is btnNew Then
            NewRecord()
        ElseIf sender Is btnDelete Then
            Delete()
        ElseIf sender Is btnEdit Then
            EnableEdit(True)
        ElseIf sender Is btnClear Then
            Clear()
            EditMode(False)
        ElseIf sender Is btnClose Then
            Close()
        ElseIf sender Is btnFinddata Then
            Find()
        ElseIf sender Is btnSave Then
            If ValidateData() Then
                If m_Edit = 1 Then
                    SaveRecord()
                Else
                    UpdateRecord()
                End If

            End If
        End If
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog() = MsgBoxResult.Yes Then
            If _DistributorGroup.Delete Then
                DeleteSuccess()
                Clear()
                EditMode(False)
            Else
                UnDeleteSuccess()
                Clear()
                EditMode(False)
            End If
        End If
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(DistributorChannleGroup.GetDistributorGroupSql, "Channel Group")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
            EditMode(False)
        End If
    End Sub
    Private Sub SaveRecord()
        _DistributorGroup.Channelcode = txtChannelCode.Text
        _DistributorGroup.ChannelgroupCode = txtChannelGroupCode.Text
        _DistributorGroup.ChannelGroupDescription = txtChannelGroupDescription.Text
        If _DistributorGroup.Save Then
            SaveSuccess()
            ShowData(_DistributorGroup.ID)
            EditMode(False)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub UpdateRecord()
        _DistributorGroup.Channelcode = txtChannelCode.Text
        _DistributorGroup.ChannelgroupCode = txtChannelGroupCode.Text
        _DistributorGroup.ChannelGroupDescription = txtChannelGroupDescription.Text
        If _DistributorGroup.Update Then
            SaveSuccess()
            ShowData(_DistributorGroup.ID)
            EditMode(False)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        If RecordCode < 1 Then Exit Sub
        _DistributorGroup = DistributorChannleGroup.Load(RecordCode)
        txtChannelCode.Tag = _DistributorGroup.ID
        txtChannelGroupCode.Text = _DistributorGroup.ChannelgroupCode
        txtChannelCode.Text = _DistributorGroup.Channelcode
        txtChannelDescription.Text = Distributor.GetDistributorDescription(_DistributorGroup.Channelcode)
        txtChannelGroupDescription.Text = _DistributorGroup.ChannelGroupDescription
        dtFromDate.Text = _DistributorGroup.EffectivityStartDate
        dtTodate.Text = _DistributorGroup.EffectivityEndDate
        EditMode(False)
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If txtChannelCode.Text = "" Then
            m_Err.SetError(txtChannelCode, "Group Code is Required!")
            m_HasError = True
        Else
            If m_Edit = 1 Then
                If DistributorChannleGroup.CheckofDistributorGroupAlreadyExist(txtChannelGroupCode.Text, txtChannelCode.Text) Then
                    m_Err.SetError(txtChannelDescription, "Channel Code Already Exist")
                    m_Err.SetError(txtChannelGroupDescription, "Channel Group Code Already Exist")
                    m_HasError = True
                End If
            End If
        End If

        If txtChannelDescription.Text = "" Then
            m_Err.SetError(txtChannelDescription, "Group Description is Required!")
            m_HasError = True
        End If
        If txtChannelCode.Text = "" Then
            m_Err.SetError(txtChannelCode, "Distributor Code is Required!")
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

    Private Sub lnkDistributorCode_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDistributorCode.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Distributor.GetDistributorSql, "Distributor")
        If Not tag Is Nothing Then
            ShowDataDistributor(tag.KeyColumn11)
        End If
    End Sub
    Private Sub ShowDataDistributor(ByVal RecordCode As String)
        If RecordCode < 1 Then Exit Sub
        _Distributor = Distributor.Load(RecordCode)
        txtChannelCode.Tag = _Distributor.DISTRIBUTORID
        txtChannelCode.Text = _Distributor.DISTCOMID
        txtChannelDescription.Text = _Distributor.DISTNAME
    End Sub
End Class
