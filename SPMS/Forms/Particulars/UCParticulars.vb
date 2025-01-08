Public Class UCParticulars

    Private m_Particular As New Particulars
    Private m_HasError As Boolean = False
    Private m_Err As New ErrorProvider

    Private Sub LoadType()
        lstusage.Items.Clear()
        lstusage.Items.Add(Particulars.EnumParticularType.Specialty.ToString)
        lstusage.Items.Add(Particulars.EnumParticularType.CoverageLeave.ToString)
        lstusage.Items.Add(Particulars.EnumParticularType.Expense.ToString)
    End Sub

    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnEdit.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode
        btnSave.Enabled = IsEditMode

        lstusage.Enabled = IsEditMode
        lnkParent.Enabled = IsEditMode

        txtCode.ReadOnly = Not IsEditMode
        txtDescription.ReadOnly = Not IsEditMode

        txtCode.BackColor = Color.White
        txtDescription.BackColor = Color.White
    End Sub

    Private Sub NewRecord()

        Clear()
        m_Particular = New Particulars
        EditMode(True)
    End Sub

    Private Sub Clear()
        m_Err.Clear()
        txtCode.Tag = Nothing
        txtCode.Text = String.Empty
        txtDescription.Text = String.Empty
        txtSubAccountOf.Text = String.Empty
        txtSubAccountOf.Tag = Nothing
    End Sub

    Private Sub SaveData()
        m_Particular.ParentCode = txtSubAccountOf.Text
        m_Particular.Code = txtCode.Text
        m_Particular.Description = txtDescription.Text
        m_Particular.Type = GetParticularType(lstusage)

        If txtSubAccountOf.Text = "" Or txtSubAccountOf.Text = String.Empty Then
            m_Particular.Level = 1
        Else
            m_Particular.Level = Particulars.GetLevel(txtSubAccountOf.Text, Particulars.EnumParticularType.Expense) + 1
        End If

        If m_Particular.Save Then
            ShowInformation("Record Sucessfully Saved.", "Save")
            EditMode(False)
        Else
            ShowExclamation("Record not saved.", "Save")
        End If
    End Sub

    Private Sub ShowData(ByVal RecordID As Integer)
        m_Particular = Particulars.Load(RecordID)

        txtCode.Text = m_Particular.Code
        txtCode.Tag = m_Particular.ParticularID
        txtDescription.Text = m_Particular.Description
        txtSubAccountOf.Text = m_Particular.ParentCode

        lstusage.SelectedItem = m_Particular.Type.ToString

    End Sub

    Private Function GetParticularType(ByVal lst As ListBox) As Particulars.EnumParticularType
        Select Case lst.SelectedIndex
            Case 0
                Return Particulars.EnumParticularType.Specialty
            Case 1
                Return Particulars.EnumParticularType.CoverageLeave
            Case 2
                Return Particulars.EnumParticularType.Expense
            Case Else
                Return Particulars.EnumParticularType.None
        End Select
    End Function

    Private Function ValidateData() As Boolean
        m_HasError = False
        m_Err.Clear()
        If lstusage.SelectedIndex < 0 Then
            m_Err.SetError(lstusage, "Type is required.")
            m_HasError = True
        End If

        If txtCode.Text = String.Empty Then
            m_Err.SetError(txtCode, "Code is required.")
            m_HasError = True
        Else
            If Not GetParticularType(lstusage) = Particulars.EnumParticularType.None Then
                If Particulars.CheckIfCodeAlreadyExist(txtCode.Text, IIf(txtCode.Tag Is Nothing, -1, txtCode.Tag), GetParticularType(lstusage)) Then
                    m_Err.SetError(txtCode, "Code Already Exist")
                    m_HasError = True
                End If
            Else
                m_Err.SetError(lstusage, "Expense Type is required")
                m_HasError = True
            End If
        End If

            If txtDescription.Text = String.Empty Then
                m_Err.SetError(txtDescription, "Description is required.")
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

    Private Sub Delete()
        If ShowQuestion("Are you sure you want to delete this record?", "Delete") = MsgBoxResult.Yes Then
            If m_Particular.Delete Then
                ShowInformation("Record Successfully Deleted.", "Delete")
                NewRecord()
            Else
                ShowExclamation("Record not deleted.", "Delete")
            End If
        End If
    End Sub

    Private Sub Find()
        Dim tag As SelectionTag = ShowSearchDialog(Particulars.GetParticularsColumns, Particulars.GetParticularsSQL, "Particulars")
        If Not tag Is Nothing Then
            ShowData(tag.KeyColumn1)
            EditMode(False)
        End If
    End Sub

    Private Sub UCParticulars_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        NewRecord()
        LoadType()
    End Sub

    Private Sub lnkParent_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkParent.LinkClicked
        If lstusage.SelectedIndex < 0 Then
            ShowExclamation("Type is required.", "Sub Reference Of")
            Exit Sub
        End If

        Dim tag As SelectionTag = ShowSearchDialog(Particulars.GetParticularsColumns, Particulars.GetParticularsSQL(GetParticularType(lstusage)), "Particulars")
        If Not tag Is Nothing Then
            txtSubAccountOf.Text = tag.KeyColumn3
            If txtCode.Text = String.Empty Then
                txtCode.Text = tag.KeyColumn3 & " - "
            End If
        End If

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click, btnClose.Click, btnDelete.Click, btnEdit.Click, btnFind.Click, btnSave.Click
        If sender Is btnAdd Then
            NewRecord()
        ElseIf sender Is btnClose Then
            Close()
        ElseIf sender Is btnDelete Then
            Delete()
        ElseIf sender Is btnEdit Then
            EditMode(True)
        ElseIf sender Is btnFind Then
            Find()
        ElseIf sender Is btnSave Then
            If ValidateData() Then
                SaveData()
            End If
        End If
    End Sub
End Class
