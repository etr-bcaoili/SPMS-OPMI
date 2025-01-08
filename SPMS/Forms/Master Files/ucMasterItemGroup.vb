Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ucMasterRegion
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule

Public Class ucMasterItemGroup
    Private GridRs As New ADODB.Recordset
    Private Operation As String
    Private Sub SetupbyOperation(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation
    End Sub
    Private Sub ClearForm()
        txtFilter.Text = ""
        txtCode.Text = ""
        txtDescription.Text = ""
    End Sub

    Private Sub OpenListing()
        If GridRs.State = 1 Then GridRs.Close()
        GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        GridRs.Open("SELECT * FROM ITEMGROUP WHERE ITEMGROUPDEL = 0 ORDER BY ITEMGROUPCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        GridListing.Rows.Clear()
        If GridRs.RecordCount > 0 Then
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)


                row.Cells(colCode.Index).Value = GridRs.Fields("ITEMGROUPCD").Value
                row.Cells(colDescription.Index).Value = GridRs.Fields("ITEMGROUPNAME").Value

                row.Cells(colStartDate.Index).Value = CDate(GridRs.Fields("EffectivityStartDate").Value).ToShortDateString
                row.Cells(colEndDate.Index).Value = CDate(GridRs.Fields("EffectivityEndDate").Value).ToShortDateString
                row.Cells(colStatus.Index).Value = IIf(GridRs.Fields("IsActive").Value = True, "Active", "InActive")
                GridRs.MoveNext()
            Next
        End If
    End Sub

    Private Function SaveRecord(ByVal Code As String, ByVal Description As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("EXEC USPITEMGROUP @ACTION = 'ADD', @ITEMGROUPDEL = 0, @ITEMGROUPCD = '" & Code & "', @ITEMGROUPNAME = '" & Description & "', @CRTDDTE = '" & Now & "', @CRTDBY = '', @EDTDTE = '" & Now & "', @EDTBY = '', @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' , @IsActive = " & chkIsActive.Checked & " ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return True
    End Function

    Private Function UpdateRecord(ByVal Code As String, ByVal Description As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("EXEC USPITEMGROUP @ACTION = 'UPDATE', @ITEMGROUPDEL = 0, @ITEMGROUPCD = '" & Code & "', @ITEMGROUPNAME = '" & Description & "', @EDTDTE = '" & Now & "', @EDTBY = '', @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' , @IsActive = " & chkIsActive.Checked & " ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return True
    End Function

    Private Function DeleteRecord(ByVal Code As String, ByVal Description As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("EXEC USPITEMGROUP @ACTION = 'UPDATE', @ITEMGROUPDEL = 1, @ITEMGROUPCD = '" & Code & "', @ITEMGROUPNAME = '" & Description & "',  @EDTDTE = '" & Now & "', @EDTBY = '' , @IsActive = " & chkIsActive.Checked & " ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return True
    End Function

    Private Function ValidFields() As Boolean
        If txtCode.Text = "" Then
            Return False
        ElseIf txtDescription.Text = "" Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function CheckRecordExists(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM ITEMGROUP WHERE ITEMGROUPCD = '" & Code & "' AND ITEMGROUPDEL = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function CheckRecordExistss(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM ITEMGROUP WHERE ITEMGROUPNAME = '" & Code & "' AND ITEMGROUPDEL = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub EnableText()
        txtCode.ReadOnly = True
        'txtDescription.ReadOnly = True
    End Sub
    Private Sub UnaEnableText()
        txtCode.ReadOnly = False
        txtDescription.ReadOnly = False
    End Sub
    Private Sub MasterItemGroup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetupbyOperation(True)
        ApplyGridTheme(GridListing)
        Operation = "Add"
        OpenListing()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Operation = "Add" Then
            If CheckRecordExists(txtCode.Text) = False Then
                SaveRecord(txtCode.Text, txtDescription.Text)
                SetupbyOperation(False)
                Operation = ""
                OpenListing()
                SaveSuccess()
                ClearForm()
                EnableText()
                txtCode.Enabled = True
            Else
                VDialog.Show("Record Already Exists", "Record Exists", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        ElseIf Operation = "Edit" Then
            If CheckRecordExistss(txtDescription.Text) = False Then
                UpdateRecord(txtCode.Text, txtDescription.Text)
                SetupbyOperation(False)
                Operation = ""
                OpenListing()
                SaveSuccess()
                EnableText()
                txtCode.Enabled = True
            Else
                VDialog.Show("Record Already Exists", "Record Exists", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        SetupbyOperation(True)
        Operation = "Edit"
        UnaEnableText()

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        SetupbyOperation(True)
        Operation = "Add"
        ClearForm()
        UnaEnableText()
        txtCode.Enabled = True
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If CheckRecordExists(txtCode.Text) = True Then
            DeleteRecord(txtCode.Text, txtDescription.Text)
            DeleteSuccess()
            SetupbyOperation(False)
            Operation = ""
            OpenListing()
            ClearForm()
        End If
    End Sub

    Private Sub GridListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick

    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Filter()
    End Sub

    Private Sub Filter()
        Dim field As String = ""
        If GridRs.State = 1 Then GridRs.Close()
        If cmbfilter.Text = "ItemGroupCode" Then
            field = "ITEMGROUPCD"
        ElseIf cmbfilter.Text = "ItemGroupName" Then
            field = "ITEMGROUPNAME"
        End If
        If cmbfilter.Text = "All" Then
            OpenListing()
            txtFilter.Text = ""
            Exit Sub
        End If
        GridRs.Open("SELECT * FROM ITEMGROUP WHERE " & field & " like '%" & txtFilter.Text & "%'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        GridListing.Rows.Clear()
        If GridRs.RecordCount > 0 Then
            For i As Integer = 0 To GridRs.RecordCount - 1
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)

                row.Cells(colCode.Index).Value = GridRs.Fields("ITEMGROUPCD").Value
                row.Cells(colDescription.Index).Value = GridRs.Fields("ITEMGROUPNAME").Value

                row.Cells(colStartDate.Index).Value = CDate(GridRs.Fields("EffectivityStartDate").Value).ToShortDateString
                row.Cells(colEndDate.Index).Value = CDate(GridRs.Fields("effectivityEndDate").Value).ToShortDateString
                row.Cells(colStatus.Index).Value = IIf(GridRs.Fields("IsActive").Value = True, "Active", "IsActive")
                GridRs.MoveNext()
            Next
        End If
    End Sub

    Private Sub GridListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick
        Dim row As DataGridViewRow = GridListing.Rows(e.RowIndex)
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM ITEMGROUP WHERE ITEMGROUPCD = '" & row.Cells(colCode.Index).Value & "' AND ITEMGROUPDEL = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            txtCode.Text = rs.Fields("ITEMGROUPCD").Value
            txtDescription.Text = rs.Fields("ITEMGROUPNAME").Value
            dtStart.Value = rs.Fields("EffectivityStartDate").Value
            dtEnd.Value = rs.Fields("EffectivityEndDate").Value
            chkIsActive.Checked = IIf(row.Cells(colStatus.Index).Value = "Active", True, False)
            SetupbyOperation(False)
            EnableText()
            txtCode.Enabled = False
            Operation = ""
            MainTab.SelectTab(0)
        Else

        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub txtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCode.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescription.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then
            Filter()
        End If
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub
End Class