Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.WinControls.UI
Imports Telerik.WinControls 
Public Class UIProductItemGroup
    Private _ProductItemGroup As New ProductItemGroup
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_EnableEdit As Boolean = False
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtPGcode.ReadOnly = Not IsEditMode
        txtPGcode.BackColor = Color.White

        txtPGDescription.ReadOnly = Not IsEditMode
        txtPGDescription.BackColor = Color.White

    End Sub
    Private Sub Clear()
        txtPGcode.Text = String.Empty
        txtPGDescription.Text = String.Empty
    End Sub
    Private Sub NewRecord()
        Clear()
        _ProductItemGroup = New ProductItemGroup
        EditMode(True)
        m_EnableEdit = False
    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click, btnClear.Click, btnDelete.Click, btnFinddata.Click, btnEdit.Click, btnSave.Click
        If sender Is btnNew Then
            NewRecord()
        ElseIf sender Is btnDelete Then
            Delete()
        ElseIf sender Is btnEdit Then
            m_EnableEdit = True
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
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ProductItemGroup.GetProductItemGroupSql, "Product Item Group")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn22)
            EditMode(False)
        End If
    End Sub
    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False

        If m_EnableEdit = False Then
            If txtPGcode.Text = "" Then
                m_Err.SetError(txtPGcode, "Product Item Group Code is Required!")
                m_HasError = True
            Else
                If ProductItemGroup.CheckofProductItemGroupAlreadyExist(txtPGcode.Text, IIf(txtPGcode.Tag Is Nothing, -1, txtPGcode.Tag)) Then
                    m_Err.SetError(txtPGcode, "Channel Code Already Exist")
                    m_HasError = True
                End If
            End If
            If ProductItemGroup.CheckofProductItemGroupCodeExist(txtPGcode.Text) Then
                Dim ds As DialogResult = RadMessageBox.Show(Me, "Product Item Group is Already Exist", "Invalid Code", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                m_HasError = True
            End If
        End If

        If txtPGDescription.Text = "" Then
            m_Err.SetError(txtPGDescription, "Product Item Group Description is Required!")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
    Private Sub SaveRecord()
        _ProductItemGroup.PGCode = txtPGcode.Text
        _ProductItemGroup.PGDescription = txtPGDescription.Text
        If _ProductItemGroup.Save Then
            SaveSuccess()
            ShowData(_ProductItemGroup.PGCode)
            EditMode(False)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog = MsgBoxResult.Yes Then
            If _ProductItemGroup.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        _ProductItemGroup = ProductItemGroup.LoadByCode(RecordCode)
        txtPGcode.Tag = _ProductItemGroup.ID
        txtPGcode.Text = _ProductItemGroup.PGCode
        txtPGDescription.Text = _ProductItemGroup.PGDescription
        EditMode(False)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class
