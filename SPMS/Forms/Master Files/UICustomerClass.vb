Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Public Class UICustomerClass
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_CustomerCoordinator As New CustomerCoordinator
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnUpdate.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtCoordanateCode.ReadOnly = Not IsEditMode
        txtCoordanateCode.BackColor = Color.White

        txtCoordinatorName.ReadOnly = Not IsEditMode
        txtCoordinatorName.BackColor = Color.White
    End Sub
    Private Sub EnableTextbox(ByVal IsEditMode As Boolean)
        txtCoordanateCode.Enabled = Not IsEditMode
    End Sub
    Private Sub Clear()
        txtCoordanateCode.Text = String.Empty
        txtCoordinatorName.Text = String.Empty
    End Sub
    Private Sub NewRecord()
        Clear()
        m_CustomerCoordinator = New CustomerCoordinator
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
    Private Sub Delete()
        If ShowDeleteDialog() = DialogResult.Yes Then
            If m_CustomerCoordinator.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If txtCoordanateCode.Text = "" Then
            m_Err.SetError(txtCoordanateCode, "Coordinator Code is Required!")
            m_HasError = True
        Else
            If ItemCategory.CheckOfItemCategoryAlreadyExist(txtCoordanateCode.Text, IIf(txtCoordanateCode.Tag Is Nothing, -1, txtCoordanateCode.Tag)) Then
                m_Err.SetError(txtCoordanateCode, "Coordinator Code Already Exist")
                m_HasError = True
            End If
        End If
        If txtCoordinatorName.Text = "" Then
            m_Err.SetError(txtCoordinatorName, "Coordinator Name is Required!")
            m_HasError = True
        End If
        Return Not m_HasError
    End Function
    Private Sub SaveRecord()
        m_CustomerCoordinator.Code = txtCoordanateCode.Text
        m_CustomerCoordinator.CoordinatorName = txtCoordinatorName.Text
        If m_CustomerCoordinator.Save Then
            SaveSuccess()
            ShowData(m_CustomerCoordinator.ID)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        If RecordCode < 1 Then Exit Sub
        m_CustomerCoordinator = CustomerCoordinator.Load(RecordCode)
        txtCoordanateCode.Tag = m_CustomerCoordinator.ID
        txtCoordanateCode.Text = m_CustomerCoordinator.Code
        txtCoordinatorName.Text = m_CustomerCoordinator.CoordinatorName
        EditMode(False)
    End Sub
    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(CustomerCoordinator.GetCustomerCoordinatorSql, "Customer Coordinator")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
            EditMode(False)
        End If
    End Sub

    Private Sub UICustomerClass_Load(sender As Object, e As EventArgs) Handles Me.Load
        EditMode(False)
        Clear()
    End Sub
End Class
