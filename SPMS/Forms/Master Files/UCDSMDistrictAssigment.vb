'Created  by : Mark Lester 'R3ckaH' Guiquing
'Created Date: June 13, 2010

Imports SPMSOPCI.ConnectionModule
Public Class UCDSMDistrictAssigment

    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_Action As String = EnumAction.SAVE.ToString

    Private Enum EnumAction
        SAVE = 1
        UPDATE = 2
        DELETE = 3
    End Enum

    Private Sub UCDSMDistrictAssigment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(dgListing)
        LoadSTRegion()
        LoadSelection()
        m_Err.Clear()
        Filter()
        m_Action = EnumAction.SAVE.ToString
        LockFields(True)
    End Sub

    Private Sub cmbRegionCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegionCode.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT STREGNAME FROM STREGION WHERE STREGCD = '" & cmbRegionCode.Text & "' AND DLTFLG = 0 ORDER BY STREGCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            cboRegionDesc.Text = rs.Fields("STREGNAME").Value
            'txtRegionCode.Text = rs.Fields("STREGNAME").Value
        End If
    End Sub

    Private Sub cboRegionDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRegionDesc.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT STREGCD FROM STREGION WHERE STREGNAME = '" & cboRegionDesc.Text & "' AND DLTFLG = 0 ORDER BY STREGCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            cmbRegionCode.Text = rs.Fields("STREGCD").Value
            'txtRegionCode.Text = rs.Fields("STREGNAME").Value
        End If
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click, btnEdit.Click, btnDelete.Click, btnClose.Click, btnSave.Click
        If sender Is btnAdd Then
            Clear()
            EditMode(True)
            LockFields(False)
            m_Action = EnumAction.SAVE.ToString
            Clear()
        ElseIf sender Is btnEdit Then
            If Not txtdistrictCode.Tag Is Nothing Then
                EditMode(True)
                LockFields2(False)
                m_Action = EnumAction.UPDATE.ToString
                Clear()
            Else
                ShowExclamation("There was no record to modify", "Edit")
            End If

        ElseIf sender Is btnSave Then
            If ValidateData() Then
                SaveData(IIf(txtdistrictCode.Tag Is Nothing, -1, txtdistrictCode.Tag), txtdistrictCode.Text, txtDescription.Text, cmbRegionCode.Text, chkIsActive.Checked)
                EditMode(False)
                LockFields(True)
            End If
            Filter()
        ElseIf sender Is btnDelete Then
            If ShowQuestion("Are you sure you want to delete this record?", "Delete") = MsgBoxResult.Yes Then
                If Not txtdistrictCode.Tag Is Nothing Then
                    Delete(txtdistrictCode.Tag)
                    Clear()
                    EditMode(True)
                    LockFields(False)
                    m_Action = EnumAction.SAVE.ToString
                Else
                    ShowExclamation("Record not yet saved", "Delete")
                End If
                Filter()
            End If
        ElseIf sender Is btnClose Then
            Close()
        End If
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Filter()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        Filter()
    End Sub
    

    Private Sub dgListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgListing.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Dim row As DataGridViewRow = dgListing.Rows(e.RowIndex)
        GetDataForLoading(row.Cells(colDivCD.Index).Value)
    End Sub

    '====================================== User Defined Functions and Subs =============================================


    Private Sub LoadSelection()
        cmbfilter.Items.Clear()
        For m As Integer = 0 To dgListing.ColumnCount - 1
            If dgListing.Columns(m).HeaderText <> "Status" Then
                cmbfilter.Items.Add(dgListing.Columns(m).HeaderText)
            End If
        Next

    End Sub
    Private Sub GetDataForLoading(ByVal DistrictCode As String)
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT *  FROM StDistrictCreation Where DLTFLG = 0 and DistCD = '" & DistrictCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            ShowData(rs)
            EditMode(False)
            LockFields(True)
            TabControl1.SelectTab(0)
        End If
    End Sub
    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Sub Filter()
        Dim StrFilter As String = ""
        If Not cmbfilter.Text = "" Then
            If cmbfilter.Text = "Sales District Code" Then
                StrFilter = " AND DISTCD like '%" & cmbfilter.Text & "%' "
            End If
            If cmbfilter.Text = "Sales District Name" Then
                StrFilter = " AND DISTNAME like '%" & cmbfilter.Text & "%' "
            End If
            If cmbfilter.Text = "Sales Division Code" Then
                StrFilter = " AND DIVCD like '%" & cmbfilter.Text & "%' "
            End If
        End If
        LoadDistrict(StrFilter)
    End Sub

    Private Sub LoadDistrict(Optional ByVal StrFilter As String = "")

        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT * FROM StDistrictCreation WHERE DLTFLG = 0 " & StrFilter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            PopulateGrid(rs)
            LockFields(False)
        Else
            dgListing.Rows.Clear()
        End If
    End Sub

    Private Sub PopulateGrid(ByVal rs As ADODB.Recordset)
        dgListing.Rows.Clear()
        For m As Integer = 0 To rs.RecordCount - 1
            Dim row As DataGridViewRow = dgListing.Rows(dgListing.Rows.Add)
            row.Cells(colDivCD.Index).Value = rs.Fields("DISTCD").Value
            row.Cells(colDivName.Index).Value = rs.Fields("DISTNAME").Value
            row.Cells(colAreaCode.Index).Value = rs.Fields("DIVCD").Value
            row.Cells(colStatus.Index).Value = IIf(rs.Fields("IsActive").Value = True, "Active", "Inactive")
            rs.MoveNext()
        Next
    End Sub


    Private Function CheckIfDistrictCodeExists(ByVal DistrictCode As String, Optional ByVal DistrictID As Integer = -1) As Boolean
        Dim Str As String = ""
        If DistrictID <> -1 Then Str &= " AND StDistrictCreationID  <> " & DistrictID
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT * FROM StDistrictCreation Where DLTFLG = 0 AND DistCd = '" & DistrictCode & "'  " & Str, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub ShowData(ByVal rs As ADODB.Recordset)
        cmbRegionCode.Text = rs.Fields("DIVCD").Value
        txtDescription.Text = rs.Fields("DISTNAME").Value
        txtdistrictCode.Text = rs.Fields("DISTCD").Value
        txtdistrictCode.Tag = rs.Fields("StDistrictCreationID").Value
    End Sub

    Private Sub SaveData(ByVal StDistrictCreationID As Integer, ByVal DistCD As String, ByVal DistrictName As String, ByVal DivisionCode As String, ByVal IsActive As Boolean)
        Try

            SPMSConn.Execute("Execute uspStDistrictCreation @Action = '" & m_Action & "', " & _
                                                            "@StDistrictCreationID = " & StDistrictCreationID & ", " & _
                                                            "@DistCd = '" & HandleSingleQuoteInSql(DistCD) & "', @DistName = '" & HandleSingleQuoteInSql(DistrictName) & "' ," & _
                                                            " @DivCD = '" & HandleSingleQuoteInSql(DivisionCode) & "' , @IsActive = " & IIf(IsActive = True, "1", "0") & "")
            ShowInformation("Record Successfully Saved", "Save")
            GetDataForLoading(txtdistrictCode.Text)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub
    Private Sub Delete(ByVal StDistrictCreationID As Integer)
        Try
            SPMSConn.Execute("Execute uspStDistrictCreation @Action = 'DELETE' , @StDistrictCreationID = " & StDistrictCreationID)
            ShowInformation("Record Successfully Deleted", "Delete")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False

        If txtdistrictCode.Text = "" Then
            m_Err.SetError(txtdistrictCode, "District Code is required")
            m_HasError = True
        Else
            If CheckIfDistrictCodeExists(txtdistrictCode.Text, IIf(txtdistrictCode.Tag Is Nothing, -1, txtdistrictCode.Tag)) Then
                m_Err.SetError(txtdistrictCode, "District Code Already Exist")
                m_HasError = True
            End If
        End If

        If txtDescription.Text = "" Then
            m_Err.SetError(txtDescription, "Description is required")
            m_HasError = True
        End If

        If cmbRegionCode.Text = "" Then
            m_Err.SetError(cmbRegionCode, "Sales Division is required")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function

    Private Sub LoadSTRegion()
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT STREGCD, STREGNAME FROM STREGION WHERE DLTFLG = 0 AND IsActive = 1 ORDER BY STREGCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            cmbRegionCode.Items.Clear()
            cboRegionDesc.Items.Clear()
            For i As Integer = 1 To rs.RecordCount
                cmbRegionCode.Items.Add(rs.Fields("STREGCD").Value)
                cboRegionDesc.Items.Add(rs.Fields("STREGNAME").Value)
                rs.MoveNext()
            Next
        End If



    End Sub

    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnAdd.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
    End Sub
    Private Sub Clear()
        cmbfilter.Text = String.Empty
        txtDescription.Text = String.Empty
        txtdistrictCode.Text = String.Empty
        txtdistrictCode.Tag = Nothing
    End Sub
    Private Sub LockFields(ByVal IsLocked As Boolean)
        txtdistrictCode.Enabled = True
        txtdistrictCode.ReadOnly = IsLocked
        txtdistrictCode.BackColor = Color.White
        txtDescription.ReadOnly = IsLocked
        txtDescription.BackColor = Color.White
        cmbRegionCode.Enabled = Not IsLocked
        cboRegionDesc.Enabled = Not IsLocked
    End Sub
    Private Sub LockFields2(ByVal IsLocked As Boolean)
        txtdistrictCode.Enabled = False
        txtdistrictCode.BackColor = Color.White
        txtDescription.ReadOnly = IsLocked
        txtDescription.BackColor = Color.White
        cmbRegionCode.Enabled = Not IsLocked
        cboRegionDesc.Enabled = Not IsLocked
    End Sub


    Private Sub dgListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgListing.CellContentClick

    End Sub
End Class
