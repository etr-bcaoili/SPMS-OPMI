Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Imports System.IO

Public Class ucMasterItemClass
    Private GridRs As New ADODB.Recordset
    Private Operation As String = ""
    Private Sub ClearForm()
        txtFilter.Text = ""
        txtCode.Text = ""
        txtDescription.Text = ""
    End Sub
    Private Sub SetupOperation(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation
    End Sub
    Private Sub OpenListing()
        If GridRs.State = 1 Then GridRs.Close()
        GridRs.Open("SELECT * FROM ITEMCLASS WHERE ITEMCLASSDEL = 0 ORDER BY ITEMCLASSCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If GridRs.RecordCount > 0 Then
            GridListing.Rows.Clear()
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(ItemClassCode.Index).Value = GridRs.Fields("ITEMCLASSCD").Value
                row.Cells(ItemClassName.Index).Value = GridRs.Fields("ITEMCLASSNAME").Value
                row.Cells(colStartDate.Index).Value = CDate(GridRs.Fields("EffectivityStartDate").Value).ToShortDateString
                row.Cells(colEndDate.Index).Value = CDate(GridRs.Fields("EffectivityEndDate").Value).ToShortDateString
                row.Cells(colStatus.Index).Value = IIf(GridRs.Fields("IsActive").Value = True, "Active", "Inactive")
                GridRs.MoveNext()
            Next
        End If
    End Sub
    Private Function CheckRecordExist(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("select * from itemclass where itemclasscd = '" & Code & "' and itemclassdel = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function CheckRecordExists(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("select * from itemclass where ITEMCLASSNAME = '" & Code & "' and itemclassdel = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function SaveRecord(ByVal Code As String, ByVal Description As String) As Boolean
        SPMSConn.Execute("EXEC uspItemClass @ACTION = 'ADD', @ITEMCLASSDEL = 0, @ITEMCLASSCD = '" & Code & "',  @ITEMCLASSNAME = '" & Description & "', @CRTDDTE = '" & Now & "', @CRTDBY = '', @EDTDTE = '" & Now & "', @EDTBY = '' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' , @IsActive = " & chkIsActive.Checked & " ")
    End Function

    Private Function UpdateRecord(ByVal Code As String, ByVal Description As String) As Boolean
        SPMSConn.Execute("EXEC uspItemClass @ACTION = 'UPDATE', " & _
       "@ITEMCLASSDEL = 0, " & _
       "@ITEMCLASSCD = '" & Code & "', " & _
       "@ITEMCLASSNAME = '" & Description & "', " & _
       "@EDTDTE = '" & Now & "', " & _
       "@EDTBY = '" & Now & "' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' , @IsActive = " & chkIsActive.Checked & " ")
    End Function

    Private Function DeleteRecord(ByVal Code As String, ByVal Description As String) As Boolean
        SPMSConn.Execute("EXEC uspItemClass @ACTION = 'UPDATE', " & _
    "@ITEMCLASSDEL = 1, " & _
    "@ITEMCLASSCD = '" & Code & "', " & _
    "@ITEMCLASSNAME = '" & Description & "', " & _
    "@EDTDTE = '" & Now & "', " & _
    "@EDTBY = '" & Now & "' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "', @IsActive = 0 ")
    End Function
    Private Sub EnableText()
        txtCode.ReadOnly = True
        txtDescription.ReadOnly = True
    End Sub
    Private Sub UnEnableText()
        txtCode.Enabled = False
        txtCode.ReadOnly = False
        txtDescription.ReadOnly = False
    End Sub
    Private Sub AddEnableText()
        txtCode.Enabled = True
        txtCode.ReadOnly = False
        txtDescription.ReadOnly = False
    End Sub
    Private Sub ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click, btnAdd.Click, btnEdit.Click, btnSave.Click, btnClose.Click
        If sender Is btnDelete Then
            If CheckRecordExist(txtCode.Text) = True Then
                DeleteRecord(txtCode.Text, txtDescription.Text)
                DeleteSuccess()
                SetupOperation(False)
                Operation = ""
                OpenListing()
                ClearForm()
                EnableText()
            End If
        ElseIf sender Is btnEdit Then
            Operation = "Edit"
            SetupOperation(True)
            txtCode.Focus()
            UnEnableText()
        ElseIf sender Is btnAdd Then
            Operation = "Add"
            SetupOperation(True)
            txtCode.Focus()
            ClearForm()
            AddEnableText()
        ElseIf sender Is btnClose Then
            On Error Resume Next
            Dim m_TabPage As TabPage = Me.Parent
            CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
            Me.Dispose()
        ElseIf sender Is btnSave Then
            If Operation = "Add" Then
                If CheckRecordExist(txtCode.Text) = True Then
                    VDialog.Show("Record Already Exists", "Record Exists", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    EnableText()
                Else
                    SaveRecord(txtCode.Text, txtDescription.Text)
                    Operation = ""
                    SetupOperation(False)
                    OpenListing()
                    SaveSuccess()
                    ClearForm()
                    EnableText()
                End If
            ElseIf Operation = "Edit" Then
                If CheckRecordExists(txtDescription.Text) = False Then
                    UpdateRecord(txtCode.Text, txtDescription.Text)
                    Operation = ""
                    SetupOperation(False)
                    OpenListing()
                    SaveSuccess()
                    ClearForm()
                Else
                    VDialog.Show("Record Does not Exist", "Record Exists", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                End If
            End If
        End If
    End Sub
    Private Sub Filter()
        Dim field As String = ""
        If GridRs.State = 1 Then GridRs.Close()
        If cmbfilter.Text = "" Then Exit Sub
        If cmbfilter.Text = "ItemClassCode" Then
            field = "ITEMCLASSCD"
        ElseIf cmbfilter.Text = "ItemClassName" Then
            field = "ITEMCLASSNAME"
        End If
        If cmbfilter.Text = "All" Then
            OpenListing()
            txtFilter.Text = ""
            Exit Sub
        End If
        GridRs.Open("SELECT * FROM ITEMCLASS WHERE ITEMCLASSDEL = 0 AND " & field & " like    '%" & txtFilter.Text & "%' ORDER BY ITEMCLASSCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If GridRs.RecordCount > 0 Then
            GridListing.Rows.Clear()
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(ItemClassCode.Index).Value = GridRs.Fields("ITEMCLASSCD").Value
                row.Cells(ItemClassName.Index).Value = GridRs.Fields("ITEMCLASSNAME").Value

                row.Cells(colStartDate.Index).Value = CDate(GridRs.Fields("EffectivityStartDate").Value).ToShortDateString
                row.Cells(colEndDate.Index).Value = CDate(GridRs.Fields("effectivityEndDate").Value).ToShortDateString
                row.Cells(colStatus.Index).Value = IIf(GridRs.Fields("IsActive").Value = True, "Active", "Inactive")
                GridRs.MoveNext()
            Next
        End If
    End Sub
    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Filter()
    End Sub

    Private Sub MasterItemClass_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetupOperation(True)
        ApplyGridTheme(GridListing)
        Operation = "Add"
        txtCode.Focus()
        OpenListing()
    End Sub

    Private Sub GridListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick

    End Sub

    Private Sub GridListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick
        Dim row As DataGridViewRow = GridListing.Rows(e.RowIndex)
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM ITEMCLASS WHERE ITEMCLASSCD = '" & row.Cells(ItemClassCode.Index).Value & "' AND ITEMCLASSDEL = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            txtCode.Text = rs.Fields("ITEMCLASSCD").Value
            txtDescription.Text = rs.Fields("ITEMCLASSNAME").Value

            dtStart.Value = rs.Fields("EffectivityStartDate").Value
            dtEnd.Value = rs.Fields("EffectivityEndDate").Value
            chkIsActive.Checked = IIf(row.Cells(colStatus.Index).Value = "Active", True, False)
            SetupOperation(False)
            EnableText()
            Operation = ""
            MainTab.SelectTab(0)
        Else

        End If
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

    Private Sub txtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged

    End Sub
End Class