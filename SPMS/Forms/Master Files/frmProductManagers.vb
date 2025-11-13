
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class frmProductManagers
    Private m_ProductManager As New ProductManager
    Private m_IsNewMode As Boolean = True
    Private m_Err As New ErrorProvider
    Private m_Action As String = ""
    Private m_HasError As Boolean = False
    Private m_RsItemForViewing As New ADODB.Recordset
    Private m_RsItem As New ADODB.Recordset
    Private m_RsFilter As New ADODB.Recordset

    Private m_PM_ID As String = ""
    Private m_PM_Name As String = ""
    Private m_PM_RECID As String = ""
    Public Property PM_ID As String
        Get
            Return m_PM_ID
        End Get
        Set(value As String)
            m_PM_ID = value
        End Set
    End Property
    Public Property PM_Name As String
        Get
            Return m_PM_Name
        End Get
        Set(value As String)
            m_PM_Name = value
        End Set
    End Property
    Public Property PM_RECID As String
        Get
            Return m_PM_RECID
        End Get
        Set(value As String)
            m_PM_RECID = value
        End Set
    End Property
    Private Enum EnumAction
        ADD = 1
        UPDATE = 2
    End Enum
    Private Sub Clear()
        txtPm_Name.Text = String.Empty
        txtPM_ID.Text = String.Empty
    End Sub

    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnAdd.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    Private Sub loads()
        txtPM_ID.ReadOnly = True
        txtPm_Name.ReadOnly = True
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear()
        m_IsNewMode = True
        m_ProductManager = New ProductManager
        EditMode(True)
        loadtext2()
    End Sub
    Private Sub loadtext2()
        txtPM_ID.ReadOnly = False
        txtPm_Name.ReadOnly = False
    End Sub
    Private Sub loadtext()
        txtPM_ID.ReadOnly = True
        txtPm_Name.ReadOnly = True
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ValidateData() Then
            SaveData()
            LoadItemsToGrid()
            EditMode(False)
            Clear()
            MainTab.SelectTab(1)
        End If
    End Sub
    Private Sub deleteds()
        Dim rs2 As New ADODB.Recordset
        rs2.Open("Delete  from  itemteammap where itemcd = '" & txtPM_ID.Text & "' AND Recid = '" & m_PM_RECID & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
    End Sub
    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False

        If txtPM_ID.Text = "" Then
            m_Err.SetError(txtPM_ID, "Product Manager ID is required")
            m_HasError = True
        End If
        If txtPm_Name.Text = "" Then
            m_Err.SetError(txtPm_Name, "Product Manager Name  is required")
            m_HasError = True
        End If

        If m_IsNewMode Then
            If Not CheckIfItemExist(txtPM_ID.Text) Then
                ShowExclamation("Record Already Exist", "Save")
                m_HasError = True
            End If
        End If

        If txtConfigtypeCode.Text = "" Then
            m_Err.SetError(txtPm_Name, "Product Manager Name  is required")
            m_HasError = True
        End If
        Return Not m_HasError
    End Function
    Private Function SaveData() As Boolean
        m_ProductManager.PriductID = RefineSQL(txtPM_ID.Text)
        m_ProductManager.ProductManager = RefineSQL(txtPm_Name.Text)
        m_ProductManager.ConfigtypeCode = txtConfigtypeCode.Text
        m_ProductManager.EffectivityStartDate = dtStart.Text
        m_ProductManager.EffectivityEndDate = dtEnd.Text
        m_ProductManager.IsActive = True

        If m_ProductManager.Save() Then
            SaveSuccess()
            ShowData(m_ProductManager.PriductID)
        Else
            UnSuccesSave()
        End If
    End Function

    Private Sub frmProductManagers_Load(sender As Object, e As EventArgs) Handles Me.Load
        If m_PM_ID <> "" Then
            m_Err.Clear()
            loads()
            ApplyGridTheme(dgItemList)
            EditMode(False)
            Clear()
            m_IsNewMode = True
            txtPM_ID.Text = m_PM_ID
            txtPm_Name.Text = m_PM_Name
            LoadSelectionBox()
            MainTab.SelectTab(0)
            LoadItemsToGrid()
        Else
            LoadSelectionBox()
            MainTab.SelectTab(0)
            LoadItemsToGrid()
            m_Err.Clear()
            ApplyGridTheme(dgItemList)
            EditMode(False)
            Clear()
            m_IsNewMode = True
            MainTab.SelectTab(0)
        End If

    End Sub
    Private Sub LoadItemsToGrid()
        If m_RsItemForViewing.State = 1 Then m_RsItemForViewing.Close()
        m_RsItemForViewing.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsItemForViewing.Open("SELECT * FROM ProductManagers Where IsActive = 1 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgItemList.Rows.Clear()
        If m_RsItemForViewing.RecordCount = 0 Then Exit Sub
        RefreshGrid(m_RsItemForViewing)
    End Sub
    Private Sub RefreshGrid(ByVal rs As ADODB.Recordset)
        For m As Integer = 0 To rs.RecordCount - 1
            Dim row As DataGridViewRow = dgItemList.Rows(dgItemList.Rows.Add)
            row.Cells(colPM_ID.Index).Value = rs.Fields("PM_ID").Value
            row.Cells(colPM_Name.Index).Value = rs.Fields("PM_Name").Value
            row.Cells(colStartDate.Index).Value = rs.Fields("EffectivityStartDate").Value
            row.Cells(colEndDate.Index).Value = rs.Fields("EffectivityEndDate").Value
            rs.MoveNext()
        Next
    End Sub
    Private Sub LoadSelectionBox()
        cboSelection.Items.Clear()
        cboSelection.Items.Add("All")
        cboSelection.Items.Add("PM ID")
        cboSelection.Items.Add("PM Name")
    End Sub
    Private Sub ShowData(ByVal ProductManagerCode As String)
        m_IsNewMode = False
        Clear()
        m_ProductManager = ProductManager.LoadByCode(ProductManagerCode)
        txtPM_ID.Tag = m_ProductManager.ID
        txtPM_ID.Text = m_ProductManager.PriductID
        txtPm_Name.Text = m_ProductManager.ProductManager

        dtStart.Value = m_ProductManager.EffectivityStartDate
        dtEnd.Value = m_ProductManager.EffectivityEndDate
        EditMode(False)
        MainTab.SelectTab(0)
    End Sub
    Private Function CheckIfItemExist(ByVal ItemCode As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM ProductManagers WHERE PM_ID = '" & ItemCode & "'  AND  ISACtive = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.RecordCount = 0 Then
            Return True
        End If
        Return False
    End Function

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim q As MsgBoxResult
        q = VDialog.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If q = MsgBoxResult.Yes Then
            Delete()
            Clear()
            LoadItemsToGrid()
        End If
    End Sub
    Private Sub Delete()

        If Not txtPM_ID.Text = "" Then
            Try
                SPMSConn.Execute("EXEC uspProductManagers @Action = 'DELETE' , @PM_ID = '" & txtPM_ID.Text & "'")
                DeleteSuccess()
                loadtext()
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        Else
            VDialog.Show("There are no record to be Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Private Sub dgItemList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgItemList.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Dim row As DataGridViewRow = dgItemList.Rows(e.RowIndex)
        ShowData(row.Cells(colPM_ID.Index).Value)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        m_IsNewMode = False
        EditMode(True)
        loadtext2()
        txtPM_ID.Enabled = False
    End Sub
    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Chr(13) Then
            FilterData()
        End If
    End Sub

    Private Sub FilterData()
        Dim FilterField As String = ""
        If cboSelection.SelectedItem = "PM ID" Then
            FilterField = "PM_ID"
        ElseIf cboSelection.SelectedItem = "PM Name" Then
            FilterField = "PM_Name"
        Else
            FilterField = ""
        End If
        If cboSelection.Text = "All" Then
            LoadItemsToGrid()
            txtFilter.Text = ""
            Exit Sub
        End If
        If FilterField <> "" Then
            If m_RsFilter.State = 1 Then m_RsFilter.Close()
            m_RsFilter.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            m_RsFilter.Open("SELECT * FROM ProductManagers WHERE " & FilterField & " like '%" & txtFilter.Text & "%' and IsActive = 1 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If m_RsFilter.RecordCount > 0 Then
                dgItemList.Rows.Clear()
                RefreshGrid(m_RsFilter)
            End If
        End If
    End Sub

    Private Sub dgItemList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgItemList.CellContentClick

    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Medical Configuration")
        If Not tag Is Nothing Then
            txtConfigtypeCode.Text = tag.KeyColumn11
            txtConfigtypeName.Text = tag.KeyColumn33
        End If
    End Sub
End Class
