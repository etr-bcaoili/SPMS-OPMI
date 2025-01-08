Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class UCConfigurationType
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_Config As New UCConfig
    Private table As DataTable
    Private m_IsNewMode As Boolean = True
    Private Enum EnumAction
        ADD = 1
        UPDATE = 2
    End Enum
    Private Sub UCConfigurationType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ApplyGridTheme(dgItemList)
        LoadViewData()
        LoadSelectionBox()
    End Sub
    Private Sub LoadViewData()
        dgItemList.Rows.Clear()
        table = GetRecords("Select * from ConfigurationType")
        If table.Rows.Count > 0 Then
            For i As Integer = 0 To table.Rows.Count - 1
                Dim dr As DataRow = table.Rows(i)
                Dim row As DataGridViewRow = dgItemList.Rows(dgItemList.Rows.Add)
                row.Cells(colCode.Index).Value = dr("ConfigtypeCode")
                row.Cells(colDescription.Index).Value = dr("ConfigTypeName")
            Next
        End If
    End Sub
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnAdd.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Sub LoadSelectionBox()
        cboSelection.Items.Clear()
        cboSelection.Items.Add("All")
        cboSelection.Items.Add("ConfigTypeCode")
        cboSelection.Items.Add("ConfigTypeName")
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateData() Then
            If SaveData() Then
                VDialog.Show("Record Sucessfully Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                EditMode(False)
                Clear()
                loadtext2()
                LoadViewData()
            End If
        End If
    End Sub
    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False

        If txtcode.Text = String.Empty Then
            m_Err.SetError(txtcode, "Configtypecode is required")
            m_HasError = True

        End If
        If txtdecriptionname.Text = String.Empty Then
            m_Err.SetError(txtdecriptionname, "ConfigType Name is required")
            m_HasError = True
        End If

        If m_IsNewMode Then
            If Not CheckIfItemExist(txtcode.Text) Then
                ShowExclamation("Record Already Exist", "Save")
                m_HasError = True
            End If
        End If

        Return Not m_HasError
    End Function
    Private Function saveData() As Boolean
        m_HasError = False
        If CheckIfItemExist(txtcode.Text) Then
            SPMSConn.Execute("insert into ConfigurationType(ConfigTypeCode,ConfigTypeName,EffictivityStartDate,EffictivityEndDate)values('" & txtcode.Text & "','" & txtdecriptionname.Text & "','" & dtStart.Text & "','" & dtEnd.Text & "')")
        Else
            SPMSConn.Execute("Update Configurationtype set ConfigTypeCode = '" & txtcode.Text & "',ConfigtypeName = '" & txtdecriptionname.Text & "',EffictivityStartDate = '" & dtStart.Text & "',EffictivityEndDate = '" & dtEnd.Text & "' where ConfigTypeCode = '" & txtcode.Text & "'")
        End If
        Return Not m_HasError
    End Function
    Private Sub Clear()
        txtcode.Text = String.Empty
        txtdecriptionname.Text = String.Empty
    End Sub
    Private Sub FuntionText()
        txtcode.ReadOnly = False
        txtdecriptionname.ReadOnly = False
        dtStart.Enabled = False
        dtEnd.Enabled = False
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Clear()
        m_IsNewMode = True
        EditMode(True)
        loadtext()
    End Sub
    Private Sub loadtext()
        txtcode.ReadOnly = False
        txtdecriptionname.ReadOnly = False
    End Sub

    Private Function CheckIfItemExist(ByVal ItemCode As String) As Boolean
        table = GetRecords("SELECT * FROM ConfigurationType WHERE ConfigtypeCode = '" & ItemCode & "'")
        If table.Rows.Count = 0 Then
            Return True
        End If
        Return False
    End Function

    Private Sub dgItemList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItemList.CellContentClick
        If e.RowIndex = -1 Then Exit Sub
        Dim row As DataGridViewRow = dgItemList.Rows(e.RowIndex)
        If Not CheckIfItemExist(row.Cells(colCode.Index).Value) Then
            table = GetRecords("SELECT * FROM ConfigurationType WHERE  ConfigtypeCode  = '" & row.Cells(colCode.Index).Value & "'")
            If table.Rows.Count > 0 Then
                For i As Integer = 0 To table.Rows.Count - 1
                    txtcode.Text = table.Rows(i)("ConfigTypeCode")
                    txtdecriptionname.Text = table.Rows(i)("ConfigTypeName")
                    dtStart.Text = table.Rows(i)("EffictivityStartDate")
                    dtEnd.Text = table.Rows(i)("EffictivityEndDate")
                   
                Next
            End If
        End If
        EditMode(False)
        MainTab.SelectTab(0)
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        FilterData()
    End Sub
    Private Sub FilterData()
        Dim FilterField As String = ""
        If cboSelection.SelectedItem = "ConfigTypeCode" Then
            FilterField = "ConfigTypeCode"
        ElseIf cboSelection.SelectedItem = "ConfigTypeName" Then
            FilterField = "ComfigTypeName"
        Else
            FilterField = ""
        End If
        If cboSelection.Text = "All" Then
            LoadItemsToGrid()
            txtFilter.Text = ""
            Exit Sub
        End If
        If FilterField <> "" Then
            table = GetRecords("SELECT * FROM ConfigurationType WHERE " & FilterField & " like '%" & txtFilter.Text & "%' ")
            If table.Rows.Count > 0 Then
                dgItemList.Rows.Clear()
                For i As Integer = 0 To table.Rows.Count - 1
                    Dim dr As DataRow = table.Rows(i)
                    Dim row As DataGridViewRow = dgItemList.Rows(dgItemList.Rows.Add)
                    row.Cells(colCode.Index).Value = dr("ConfigTypecode")
                    row.Cells(colDescription.Index).Value = dr("ConfigTypeName")
                Next
            End If
        End If
    End Sub
    Private Sub LoadItemsToGrid()
        table = GetRecords("SELECT * FROM ConfigurationType")
        dgItemList.Rows.Clear()
        If table.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To table.Rows.Count - 1
            Dim dr As DataRow = table.Rows(i)
            Dim row As DataGridViewRow = dgItemList.Rows(dgItemList.Rows.Add)
            row.Cells(colCode.Index).Value = dr("ConfigTypeCode")
            row.Cells(colDescription.Index).Value = dr("ConfigTypeName")
        Next
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        m_IsNewMode = False
        EditMode(True)
        loadtext()
    End Sub
    Private Sub loadtext2()
        txtcode.ReadOnly = True
        txtdecriptionname.ReadOnly = True
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim q As MsgBoxResult
        q = VDialog.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If q = MsgBoxResult.Yes Then
            Delete()
            Clear()
            LoadViewData()

        End If
    End Sub
    Private Sub Delete()

        If Not txtcode.Text = "" Then
            Try
                SPMSConn.Execute("Delete from ConfigurationType where ConfigTypeCode = '" & txtcode.Text & "'")
                VDialog.Show("Record Sucessfully Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        Else
            VDialog.Show("There are no record to be deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
End Class
