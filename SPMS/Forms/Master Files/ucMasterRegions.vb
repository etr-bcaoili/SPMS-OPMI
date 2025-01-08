Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Public Class ucMasterRegions
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_Region As New Regions
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnUpdate.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtRegionCode.ReadOnly = Not IsEditMode
        txtRegionCode.BackColor = Color.White

        txtRegionName.ReadOnly = Not IsEditMode
        txtRegionName.BackColor = Color.White
    End Sub
    Private Sub Clear()
        txtRegionCode.Text = String.Empty
        txtRegionName.Text = String.Empty
    End Sub
    Private Sub EnableTextBox(ByVal IsEditMode As Boolean)
        txtRegionCode.Enabled = Not IsEditMode
    End Sub
    Private Sub NewRecord()
        Clear()
        m_Region = New Regions
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
            If m_Region.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub
    Private Sub SaveRecord()
        m_Region.RegionCode = txtRegionCode.Text
        m_Region.RegionName = txtRegionName.Text
        If m_Region.Save Then
            SaveSuccess()
            ShowData(m_Region.ID)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        If RecordCode < 1 Then Exit Sub
        m_Region = Regions.Load(RecordCode)
        txtRegionCode.Tag = m_Region.ID
        txtRegionCode.Text = m_Region.RegionCode
        txtRegionName.Text = m_Region.RegionName
        EditMode(False)
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If txtRegionCode.Text = "" Then
            m_Err.SetError(txtRegionCode, "Region ID is Required!")
            m_HasError = True
        Else
            If Regions.CheckCustomerRegion(txtRegionCode.Text, IIf(txtRegionCode.Tag Is Nothing, -1, txtRegionCode.Tag)) Then
                m_Err.SetError(txtRegionCode, "Region ID Already Exist")
                m_HasError = True
            End If
        End If
        If txtRegionName.Text = "" Then
            m_Err.SetError(txtRegionName, "Region Name is Required!")
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
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Regions.GetRegion1Sql, "Region")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
            EditMode(False)
        End If
    End Sub
End Class
