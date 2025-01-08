Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Public Class UCUnitOfMeasurement
    Private _UnitOfMeasurement As New UnitOfMeasurement
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_Edit As Integer = 0
    Private m_Edittext As Boolean = False

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
    Private Sub Clear()
        txtCode.Text = String.Empty
        txtDescription.Text = String.Empty
    End Sub
    Private Sub EnableEdit(ByVal IsEditMode As Boolean)
        If m_Edittext = False Then
            btnSave.Enabled = IsEditMode
            btnEdit.Enabled = Not IsEditMode
            btnNew.Enabled = Not IsEditMode
            btnDelete.Enabled = Not IsEditMode

            txtCode.ReadOnly = IsEditMode
            txtCode.BackColor = Color.WhiteSmoke

            txtDescription.ReadOnly = IsEditMode
            txtDescription.BackColor = Color.WhiteSmoke
        Else
            btnSave.Enabled = IsEditMode
            btnEdit.Enabled = Not IsEditMode
            btnNew.Enabled = Not IsEditMode
            btnDelete.Enabled = Not IsEditMode

            txtCode.ReadOnly = IsEditMode
            txtCode.BackColor = Color.WhiteSmoke

            txtDescription.ReadOnly = False
            txtDescription.BackColor = Color.White
        End If
    End Sub
    Private Sub NewRecord()
        Clear()
        _UnitOfMeasurement = New UnitOfMeasurement
        EditMode(True)
        m_Edit = 1
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnDelete.Click, btnEdit.Click, btnFinddata.Click, btnSave.Click, btnClear.Click, btnClose.Click
        If sender Is btnNew Then
            NewRecord()
            m_Edittext = False
        ElseIf sender Is btnDelete Then
            Delete()
        ElseIf sender Is btnEdit Then
            EnableEdit(True)
            m_Edittext = True
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
    Private Sub Delete()
        If ShowDeleteDialog() = MsgBoxResult.Yes Then
            If _UnitOfMeasurement.Delete Then
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
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(UnitOfMeasurement.GetUnitOfMeasurementSql, "Unit of Measurement")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
            EditMode(False)
        End If
    End Sub
    Private Sub SaveRecord()
        _UnitOfMeasurement.Code = txtCode.Text
        _UnitOfMeasurement.DescriptionName = txtDescription.Text
        If _UnitOfMeasurement.Save Then
            SaveSuccess()
            ShowData(_UnitOfMeasurement.UnitOfMeasurementID)
            EditMode(False)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        If RecordCode < 1 Then Exit Sub
        _UnitOfMeasurement = UnitOfMeasurement.Load(RecordCode)
        txtCode.Tag = _UnitOfMeasurement.UnitOfMeasurementID
        txtCode.Text = _UnitOfMeasurement.Code
        txtDescription.Text = _UnitOfMeasurement.DescriptionName
        EditMode(False)
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

         If txtCode.Text = "" Then
            m_Err.SetError(txtCode, "Code is Required")
            m_HasError = True
        Else
            If UnitOfMeasurement.CheckUnitOfMeasurement(txtCode.Text, IIf(txtCode.Tag Is Nothing, -1, txtCode.Tag)) Then
                m_Err.SetError(txtCode, "Code is Already Exist")
                m_HasError = True
            End If
        End If

        If txtDescription.Text = "" Then
            m_Err.SetError(txtDescription, "Description Name is Required!")
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
End Class
