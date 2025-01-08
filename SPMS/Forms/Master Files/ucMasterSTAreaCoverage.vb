Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ucMasterRegion
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule

Public Class ucMasterSTAreaCoverage

    Private Operation As String = ""
    Private GridRs As New ADODB.Recordset

    Private Sub SetupButtons(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation
    End Sub

    Private Sub ClearForm()
        txtAreaCoverageCode.Text = ""
        txtCoverageName.Text = ""
        txtFilter.Text = ""
        cmbfilter.Text = ""
    End Sub
    Private Sub EnableText()
        txtAreaCoverageCode.ReadOnly = True
        txtCoverageName.ReadOnly = True
    End Sub
    Private Sub UnEnableText()
        txtAreaCoverageCode.ReadOnly = True
        txtCoverageName.ReadOnly = False
    End Sub
    Private Sub UnEnableTextadd()
        txtAreaCoverageCode.ReadOnly = False
        txtCoverageName.ReadOnly = False
    End Sub
    Private Sub MastState_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Code below will set up the form in add mode
        ClearForm()
        ApplyGridTheme(GridListing)
        SetupButtons(True)
        Operation = "Add"

        OpenListing()
    End Sub

    Private Sub OpenListing()
        GridRs = New ADODB.Recordset
        GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        GridRs.Open("SELECT STACOVCD, STACOVNAME, EFFECTIVITYSTARTDATE,EFFECTIVITYENDDATE, IsActive FROM STAREACOVERAGE WHERE DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        GridListing.Rows.Clear()
        If GridRs.RecordCount > 0 Then
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)

                row.Cells(AreaCoverageCode.Index).Value = GridRs.Fields("STACOVCD").Value
                row.Cells(AreaCoverageName.Index).Value = GridRs.Fields("STACOVNAME").Value
                row.Cells(colEffectivityStartDate.Index).Value = CDate(GridRs.Fields("EFFECTIVITYSTARTDATE").Value).ToShortDateString
                row.Cells(colEffectivityEndDate.Index).Value = CDate(GridRs.Fields("EFFECTIVITYENDDATE").Value).ToShortDateString
                row.Cells(colStatus.Index).Value = IIf(GridRs.Fields("IsActive").Value = True, "Active", "Inactive")
                GridRs.MoveNext()
            Next

        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        SetupButtons(True)
        Operation = "Add"
        ClearForm()
        UnEnableTextadd()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        SetupButtons(True)
        Operation = "Edit"
        UnEnableText()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Operation = "Add" Then
            If CheckRecordExists(txtAreaCoverageCode.Text) = False Then
                SaveRecord(txtAreaCoverageCode.Text, txtCoverageName.Text, dtStart.Value, dtEnd.Value)
                SaveSuccess()
                EnableText()
                SetupButtons(False)
                Operation = ""
                OpenListing()
                ClearForm()
            Else
                RecordExists()
            End If
        ElseIf Operation = "Edit" Then
            If CheckRecordExists(txtAreaCoverageCode.Text) = True Then
                UpdateRecord(txtAreaCoverageCode.Text, txtCoverageName.Text, dtStart.Value, dtEnd.Value)
                SaveSuccess()
                EnableText()
                SetupButtons(False)
                Operation = ""
                OpenListing()
                ClearForm()
            Else
                RecordInexist()
            End If
        End If
    End Sub

    Private Function SaveRecord(ByVal Code As String, ByVal Description As String, ByVal EFFECTIVITYSTARTDATE As Date, ByVal EFFECTIVITYENDDATE As Date) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC  uspSTAreaCoverage @ACTION = 'ADD', @DLTFLG = 0, @STACOVCD = '" & Code & "', @STACOVNAME = '" & Description & "', @CRTDATE = '" & Now & "', @CRTU = '', @UPDD = '" & Now & "', @UPDU = '',@EFFECTIVITYSTARTDATE = '" & EFFECTIVITYSTARTDATE & "',@EFFECTIVITYENDDATE = '" & EFFECTIVITYENDDATE & "' , @IsActive = " & chkIsActive.Checked & " ")
        Return True

ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Function UpdateRecord(ByVal Code As String, ByVal Description As String, ByVal EFFECTIVITYSTARTDATE As Date, ByVal EFFECTIVITYENDDATE As Date) As Boolean
        On Error GoTo ErrorHandler
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM [STAREACOVERAGE] WHERE STACOVCD = '" & Code & "' And DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then
            SPMSConn.Execute("EXEC  uspSTAREACOVERAGE @ACTION = 'UPDATE', @DLTFLG = 0, @STACOVCD = '" & Code & "', @STACOVNAME = '" & Description & "', @CRTDATE = '" & Now & "', @CRTU = '', @UPDD = '" & Now & "', @UPDU = '',@EFFECTIVITYSTARTDATE = '" & EFFECTIVITYSTARTDATE & "',@EFFECTIVITYENDDATE = '" & EFFECTIVITYENDDATE & "' , @IsActive = " & chkIsActive.Checked & " ")
            Return True
        End If
ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function


    Private Function DeleteRecord(ByVal Code As String, ByVal Description As String) As Boolean
        On Error GoTo ErrorHandler

        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM [STAREACOVERAGE] WHERE STACOVCD = '" & Code & "' And DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then


            SPMSConn.Execute("EXEC  uspSTAREACOVERAGE @ACTION = 'UPDATE', @DLTFLG = 1, @STACOVCD = '" & Code & "', @STACOVNAME = '" & Description & "', @CRTDATE = '" & Now & "', @CRTU = '', @UPDD = '" & Now & "', @UPDU = '' , @IsActive = " & chkIsActive.Checked & "")
            Return True
        End If
ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Function CheckRecordExists(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM STAREACOVERAGE WHERE STACOVCD  = '" & Code & "' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If


    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If CheckRecordExists(txtAreaCoverageCode.Text) = True Then

            If HasReferenceRecords("STAREACOVERAGE", txtAreaCoverageCode.Text) = False Then
                DeleteRecord(txtAreaCoverageCode.Text, txtCoverageName.Text)

                SetupButtons(False)
                Operation = ""
                DeleteSuccess()
                ClearForm()
                OpenListing()
            Else
                EntryHasReference()
            End If
        Else
            RecordInexist()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub GridListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub

        Dim row As DataGridViewRow = GridListing.Rows(e.RowIndex)

        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM STAREACOVERAGE WHERE STACOVCD = '" & row.Cells(AreaCoverageCode.Index).Value & "' And DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            txtAreaCoverageCode.Text = rs.Fields("STACOVCD").Value
            txtCoverageName.Text = rs.Fields("STACOVNAME").Value
            dtStart.Value = rs.Fields("EFFECTIVITYSTARTDATE").Value
            dtEnd.Value = rs.Fields("EFFECTIVITYENDDATE").Value
            chkIsActive.Checked = IIf(row.Cells(colStatus.Index).Value = "Active", True, False)
            MainTab.SelectTab(0)

            SetupButtons(False)
            Operation = ""
            EnableText()
        End If
    End Sub

    Private Function ValidFields() As Boolean
        If txtAreaCoverageCode.Text = "" Then
            Return False
        ElseIf txtCoverageName.Text = "" Then
            Return False
        Else
            Return True
        End If
    End Function


    Private Sub GridListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick

    End Sub
    Private Sub Filter()
        Dim field As String
        Dim rs As New ADODB.Recordset
        If cmbfilter.Text <> "" Then
            If cmbfilter.Text = "AreaCoverageCode" Then
                field = "STACOVCD"
            ElseIf cmbfilter.Text = "AreaCoverageDescription" Then
                field = "STACOVNAME"
            Else
                field = ""
            End If
            If cmbfilter.Text = "All" Then
                OpenListing()
                txtFilter.Text = ""
                Exit Sub
            End If
            GridRs.Close()
            GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            GridRs.Open("SELECT * FROM STAREACOVERAGE WHERE " & field & " like '%" & txtFilter.Text & "%' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


            If GridRs.RecordCount > 0 Then
                GridListing.Rows.Clear()
                For i As Integer = 1 To GridRs.RecordCount
                    Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)

                    row.Cells(AreaCoverageCode.Index).Value = GridRs.Fields("STACOVCD").Value
                    row.Cells(AreaCoverageName.Index).Value = GridRs.Fields("STACOVNAME").Value
                    row.Cells(colEffectivityStartDate.Index).Value = CDate(GridRs.Fields("EFFECTIVITYSTARTDATE").Value).ToShortDateString
                    row.Cells(colEffectivityEndDate.Index).Value = CDate(GridRs.Fields("EFFECTIVITYENDDATE").Value).ToShortDateString
                    row.Cells(colStatus.Index).Value = IIf(GridRs.Fields("IsActive").Value = True, "Active", "Inactive")
                    GridRs.MoveNext()
                Next
            End If
            EnableText()
        End If
    End Sub
    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Filter()
    End Sub


    Private Sub txtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtDescription_KeyPress(ByVal sender As System.Object, ByVal c As System.Windows.Forms.KeyPressEventArgs)
        c.KeyChar = UCase(c.KeyChar)
    End Sub


    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = Chr(13) Then
            Filter()
        End If
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub
End Class

