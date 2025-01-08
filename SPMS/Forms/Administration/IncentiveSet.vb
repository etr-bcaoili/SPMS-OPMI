Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class IncentiveSets

    Private m_Err As New ErrorProvider
    Private m_rsIncentive As New ADODB.Recordset
    Private m_RsIncen As New ADODB.Recordset
    Private m_HasError As Boolean = False
    Private m_Action As String = ""
    Private m_IsNewMode As Boolean = True
    Private m_RsFilter As New ADODB.Recordset
  
    Private Enum EnumAction
        ADD = 1
        UPDATE = 2
    End Enum

    Private Sub IncentiveSet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(dgItemList)
        LoadItemsToGrid()
        txtdes.CharacterCasing = CharacterCasing.Upper
        MainTab.SelectTab(0)
    End Sub
    Private Function CheckIfItemExist(ByVal ItemCode As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM IncentiveSet  WHERE  Desig = '" & ItemCode & "' AND Ranges = '" & txtrange.Text & "'AND dltflg = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount = 0 Then
            Return True
        End If
        Return False
    End Function

    Private Sub LoadItemsToGrid()

        If m_rsIncentive.State = 1 Then m_rsIncentive.Close()
        m_rsIncentive.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_rsIncentive.Open("SELECT * FROM IncentiveSet Where Dltflg = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgItemList.Rows.Clear()
        If m_rsIncentive.RecordCount = 0 Then Exit Sub

        RefreshGrid(m_rsIncentive)

    End Sub
    Private Sub RefreshGrid(ByVal rs As ADODB.Recordset)
        For m As Integer = 0 To rs.RecordCount - 1
            Dim row As DataGridViewRow = dgItemList.Rows(dgItemList.Rows.Add)
            row.Cells(colPer.Index).Value = rs.Fields("Pern1").Value
            row.Cells(colshem.Index).Value = rs.Fields("scem").Value
            row.Cells(colDes.Index).Value = rs.Fields("desig").Value
            row.Cells(colRange.Index).Value = rs.Fields("Ranges").Value
            row.Cells(colMonth.Index).Value = Format(rs.Fields("Monthly").Value, "#,###,###.00")
            rs.MoveNext()
        Next
    End Sub

    Private Sub Clear()
        txtscem.Text = String.Empty
        txtper1.Text = String.Empty
        txtdes.Text = String.Empty
        txtrange.Text = String.Empty
        txtmonthly.Text = String.Empty
    End Sub
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnAdd.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Clear()
        m_IsNewMode = True
        EditMode(True)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        m_IsNewMode = False
        EditMode(True)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If ShowQuestion("Are you sure you want to delete this record?", "Delete") = MsgBoxResult.Yes Then
            Delete()
            Clear()
        End If
    End Sub
    Private Sub delete()
        Dim rs As New ADODB.Recordset
        If Not txtdes.Text = "" Then
            Try
                SPMSConn.Execute("EXEC uspIncentiveSet @Action = 'Delete' , @Recid = '" & txtred.Text & "', @Dltflg = 0 ")
                ShowInformation("Record Sucessfully Deleted", "Delete")
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        Else

            ShowExclamation("There are no record to be deleted", "Delete")
        End If
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateData() Then
            If SaveData() Then
                ShowInformation("Record Sucessfully Saved", "Saved")
                LoadItemsToGrid()
                EditMode(False)
                Clear()
            End If
        End If
    End Sub

    Public Function SaveData() As Boolean

        Try
            If CheckIfItemExist(txtdes.Text) Then
                m_Action = EnumAction.ADD.ToString
            Else
                m_Action = EnumAction.UPDATE.ToString
            End If

            SPMSConn.Execute("EXEC uspIncentiveSet @Action = '" & m_Action & "' , @DLTFLG = 0, @DESIG= '" & HandleSingleQuoteInSql(txtdes.Text) & "', @RANGES = '" & HandleSingleQuoteInSql(txtrange.Text) & "', @MONTHLY = '" & HandleSingleQuoteInSql(txtmonthly.Text) & "',@pern1 = '" & txtper1.Text & "',@scem = '" & txtscem.Text & "',  @IsActive = '" & chkIsActive.Checked & " ' ")

            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False

        If txtdes.Text = "" Then
            m_Err.SetError(txtdes, "Designation is requered")
            m_HasError = True
        End If
        If txtscem.Text = "" Then
            m_Err.SetError(txtdes, "Scheme is requered ")
            m_HasError = True
        End If

        If txtper1.Text = "" Then
            m_Err.SetError(txtper1, "Percentage is requered")
            m_HasError = True
        End If

        If txtrange.Text = "" Then
            m_Err.SetError(txtrange, "Range is required")
            m_HasError = True
        End If

        If txtmonthly.Text = "" Then
            m_Err.SetError(txtmonthly, "Monthly Incentive is required")
            m_HasError = True
        Else
            If m_IsNewMode Then
                If Not CheckIfItemExist(txtdes.Text) Then
                    ShowExclamation("Record Already Exist", "Save")
                    m_HasError = True
                End If
            End If
        End If
        Return Not m_HasError
    End Function

    Private Sub dgItemList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItemList.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub

        Dim row As DataGridViewRow = dgItemList.Rows(e.RowIndex)
        If m_RsIncen.State = 1 Then m_RsIncen.Close()
        m_RsIncen.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsIncen.Open("SELECT * FROM  IncentiveSet WHERE dltflg = 0 AND Desig = '" & row.Cells(colDes.Index).Value & "' AND Ranges  = '" & row.Cells(colRange.Index).Value & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If m_RsIncen.RecordCount > 0 Then
            ShowData(m_RsIncen)
        End If
    End Sub
    Private Sub ShowData(ByVal rs As ADODB.Recordset)
        txtscem.Text = rs.Fields("Scem").Value
        txtper1.Text = rs.Fields("Pern1").Value
        txtdes.Text = rs.Fields("Desig").Value
        txtrange.Text = rs.Fields("Ranges").Value
        txtmonthly.Text = rs.Fields("Monthly").Value
        txtred.Text = rs.Fields("RECID").Value
        EditMode(False)
        MainTab.SelectTab(0)
    End Sub

    Private Sub dgItemList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItemList.CellContentClick

    End Sub

    Private Sub lnkRefresh_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkRefresh.LinkClicked
        LoadItemsToGrid()
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Call Filter()
    End Sub
    Private Sub Filter()
        Dim field As String = ""
        Dim FilterField As String = ""
        If cboSelection.SelectedItem = "Designation" Then
            FilterField = "Desig"
        ElseIf cboSelection.SelectedItem = "Percentage" Then
            FilterField = "Pern1"
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
            m_RsFilter.Open("SELECT * FROM IncentiveSet WHERE " & FilterField & " like '%" & txtFilter.Text & "%' " & FilterField & " like '%" & txtFilter.Text & "%' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If m_RsFilter.RecordCount > 0 Then
                dgItemList.Rows.Clear()
                RefreshGrid(m_RsFilter)
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtscem.TextChanged

    End Sub

    Private Sub txtper1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtper1.KeyPress

    End Sub
End Class
