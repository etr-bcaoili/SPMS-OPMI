Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ucMasterRegion
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule

Public Class ucMasterSTSalesManager

    Private Operation As String = ""
    Private GridRs As New ADODB.Recordset
    Private table As New DataTable

    Private Sub SetupButtons(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation
        LoadConfigType()
    End Sub

    Private Sub ClearForm()
        txtSalesManagerCode.Text = ""
        txtSalesManagerName.Text = ""
        txtFilter.Text = ""
        cmbfilter.Text = ""
    End Sub
    Private Sub EnableText()
        txtSalesManagerCode.ReadOnly = True
        txtSalesManagerName.ReadOnly = True
    End Sub
    Private Sub UnEnableText()
        txtSalesManagerCode.ReadOnly = True
        txtSalesManagerName.ReadOnly = False
    End Sub
    Private Sub UnEnableTextadd()
        txtSalesManagerCode.ReadOnly = False
        txtSalesManagerName.ReadOnly = False
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
        GridRs.Open("SELECT STSLSMGRCD, STSLSMGRNAME,EffectivityStartDate, EffectivityEndDate,IsActive  FROM STSALESMANAGER WHERE DLTFLG = 0 ", SPMSOPCI.ConnectionModule.SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        GridListing.Rows.Clear()
        If GridRs.RecordCount > 0 Then
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)

                row.Cells(SalesManagerCode.Index).Value = GridRs.Fields("STSLSMGRCD").Value
                row.Cells(SalesManagerName.Index).Value = GridRs.Fields("STSLSMGRNAME").Value

                row.Cells(colStartDate.Index).Value = CDate(GridRs.Fields("EffectivityStartDate").Value).ToShortDateString
                row.Cells(colEndDate.Index).Value = CDate(GridRs.Fields("EffectivityEndDate").Value).ToShortDateString
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
            If CheckRecordExists(txtSalesManagerCode.Text) = False Then
                SaveRecord(txtSalesManagerCode.Text, txtSalesManagerName.Text)
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
            If CheckRecordExists(txtSalesManagerCode.Text) = True Then
                UpdateRecord(txtSalesManagerCode.Text, txtSalesManagerName.Text)
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

    Private Function SaveRecord(ByVal Code As String, ByVal Description As String) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC  uspSalesManager @ACTION = 'ADD', @DLTFLG = 0, @STSLSMGRCD = '" & Code & "', @STSLSMGRNAME = '" & Description & "', @CRTDATE = '" & Now & "', @CRTU = '', @UPDD = '" & Now & "', @UPDU = ''  , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' , @IsActive = " & chkIsActive.Checked & ", @ConfigTypeCode = '" & cmbConfigType.Text & "' ")
        Return True

ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Function UpdateRecord(ByVal Code As String, ByVal Description As String) As Boolean
        On Error GoTo ErrorHandler
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM STSALESMANAGER WHERE STSLSMGRCD = '" & Code & "' And DLTFLG = 0 ", SPMSOPCI.ConnectionModule.SPMSConn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then


            SPMSConn.Execute("EXEC  uspSalesManager @ACTION = 'UPDATE', @DLTFLG = 0, @STSLSMGRCD = '" & Code & "', @STSLSMGRNAME = '" & Description & "', @CRTDATE = '" & Now & "', @CRTU = '', @UPDD = '" & Now & "', @UPDU = ''  , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "'  , @IsActive = " & chkIsActive.Checked & "")
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
        rs.Open("SELECT * FROM STSALESMANAGER WHERE STSLSMGRCD = '" & Code & "' And DLTFLG = 0 ", SPMSOPCI.ConnectionModule.SPMSConn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then


            SPMSConn.Execute("EXEC  uspSalesManager @ACTION = 'UPDATE', @DLTFLG = 1, @STSLSMGRCD = '" & Code & "', @STSLSMGRNAME = '" & Description & "', @CRTDATE = '" & Now & "', @CRTU = '', @UPDD = '" & Now & "', @UPDU = ''  , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' , @IsActive = " & chkIsActive.Checked & "")
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
        rs.Open("SELECT * FROM STSALESMANAGER WHERE STSLSMGRCD  = '" & Code & "' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If


    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If CheckRecordExists(txtSalesManagerCode.Text) = True Then

            If HasReferenceRecords("REGION", txtSalesManagerCode.Text) = False Then
                DeleteRecord(txtSalesManagerCode.Text, txtSalesManagerName.Text)

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
        rs.Open("SELECT * FROM STSALESMANAGER WHERE STSLSMGRCD = '" & row.Cells(SalesManagerCode.Index).Value & "'  And DLTFLG = 0  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            txtSalesManagerCode.Text = rs.Fields("STSLSMGRCD").Value
            txtSalesManagerName.Text = rs.Fields("STSLSMGRNAME").Value

            dtStart.Value = rs.Fields("EffectivityStartDate").Value
            dtEnd.Value = rs.Fields("EffectivityEndDate").Value
            chkIsActive.Checked = rs.Fields("IsActive").Value
            MainTab.SelectTab(0)


            SetupButtons(False)
            Operation = ""
        End If
    End Sub

    Private Function ValidFields() As Boolean
        If txtSalesManagerCode.Text = "" Then
            Return False
        ElseIf txtSalesManagerName.Text = "" Then
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
            If cmbfilter.Text = "Employee's Code" Then
                field = "STSLSMGRCD"
            ElseIf cmbfilter.Text = "District Sales Manager Name" Then
                field = "STSLSMGRNAME"
            Else
                field = ""
            End If
            GridRs.Close()
            GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            GridRs.Open("SELECT * FROM STSALESMANAGER WHERE " & field & " like '%" & txtFilter.Text & "%' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


            If GridRs.RecordCount > 0 Then
                GridListing.Rows.Clear()
                For i As Integer = 1 To GridRs.RecordCount
                    Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)

                    row.Cells(SalesManagerCode.Index).Value = GridRs.Fields("STSLSMGRCD").Value
                    row.Cells(SalesManagerName.Index).Value = GridRs.Fields("STSLSMGRNAME").Value

                    row.Cells(colStartDate.Index).Value = GridRs.Fields("EffectivityStartDate").Value
                    row.Cells(colEndDate.Index).Value = GridRs.Fields("EffectivityEndDate").Value
                    row.Cells(colStatus.Index).Value = IIf(GridRs.Fields("IsActive").Value = True, "Active", "Inactive")
                    GridRs.MoveNext()
                Next
            End If



        End If
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Filter()
    End Sub


    Private Sub txtSalesManagerCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtSalesManagerName_KeyPress(ByVal sender As System.Object, ByVal c As System.Windows.Forms.KeyPressEventArgs)
        c.KeyChar = UCase(c.KeyChar)
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then
            Filter()
        End If
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub

    Private Sub cmbConfigType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbConfigType.SelectedIndexChanged

    End Sub

    Private Sub LoadConfigType()
        table = GetRecords("SELECT Distinct ConfigTypeCode From ConfigurationType")
        For i As Integer = 0 To table.Rows.Count - 1
            cmbConfigType.Items.Add(table.Rows(i)("ConfigTypeCode"))
        Next
    End Sub

End Class

