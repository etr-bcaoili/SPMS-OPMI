Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ucMasterCustomerGroup
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class ucMasterCustomerGroup
    Private Operation As String = ""
    Private GridRs As New ADODB.Recordset

    Private Sub SetupButtons(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation
    End Sub

    Private Sub ClearForm()
        txtCode.Text = ""
        txtDescription.Text = ""

    End Sub
    Private Sub EnableText()
        txtCode.ReadOnly = True
        txtDescription.ReadOnly = True
    End Sub
    Private Sub UnEnableText()
        txtCode.ReadOnly = True
        txtDescription.ReadOnly = False
    End Sub
    Private Sub UnEnableTextadd()
        txtCode.ReadOnly = False
        txtDescription.ReadOnly = False
    End Sub
    Private Function CheckRecordExists(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM CustomerGroup WHERE CustomerGroupCD  = '" & txtCode.Text & "' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If


    End Function

    Private Sub OpenListing()
        GridRs = New ADODB.Recordset
        GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        GridRs.Open("SELECT CustomerGroupCD AS [Code], CustomerGroupNAME AS [Description],EFFECTIVITYSTARTDATE,EFFECTIVITYENDDATE FROM CustomerGroup WHERE DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        GridListing.Rows.Clear()
        If GridRs.RecordCount > 0 Then
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)

                row.Cells(Code.Index).Value = GridRs.Fields("Code").Value
                row.Cells(Description.Index).Value = GridRs.Fields("Description").Value
                row.Cells(colEffectivityStartDate.Index).Value = CDate(GridRs.Fields("EFFECTIVITYSTARTDATE").Value).ToShortDateString
                row.Cells(colEffectivityEndDate.Index).Value = CDate(GridRs.Fields("EFFECTIVITYENDDATE").Value).ToShortDateString
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
        OpenListing()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Operation = "Add" Then
            If CheckRecordExists(txtCode.Text) = False Then
                SaveRecord(txtCode.Text, txtDescription.Text, dtStart.Value, dtEnd.Value)
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
            UpdateRecord(txtCode.Text, txtDescription.Text, dtStart.Value, dtEnd.Value)
            SaveSuccess()
            EnableText()
            OpenListing()
            ClearForm()
        End If
    End Sub

    Private Function SaveRecord(ByVal Code As String, ByVal Description As String, ByVal EffectivityEndDate As Date, ByVal EffectivityStartDate As Date) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC  uspCustomerGroup @ACTION = 'ADD', @DLTFLG = 0, @CustomerGroupCD = '" & Code & "', @CustomerGroupNAME = '" & Description & "', @CRTDATE = '" & Now.ToShortDateString & "', @CRTU = '',@EFFECTIVITYSTARTDATE = '" & EffectivityStartDate & "',@EFFECTIVITYENDDATE = '" & EffectivityEndDate & "' ")
        Return True
ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Function UpdateRecord(ByVal Code As String, ByVal Description As String, ByVal EffectivityStartDate As Date, ByVal EffectivityEndDate As Date) As Boolean
        On Error GoTo ErrorHandler
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM [CustomerGroup] WHERE CustomerGroupCD = '" & txtCode.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then


            SPMSConn.Execute("EXEC  uspCustomerGroup @ACTION = 'UPDATE', @DLTFLG = 0, @CustomerGroupCD = '" & Code & "', @CustomerGroupNAME = '" & Description & "', @CRTDATE = '" & Now.ToShortDateString & "', @CRTU = '',@EFFECTIVITYSTARTDATE = '" & EffectivityStartDate & "',@EFFECTIVITYENDDATE = '" & EffectivityEndDate & "' ")
            Return True
        End If


ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Sub MasterCustomerGroup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Code below will set up the form in add mode
        ClearForm()
        SetupButtons(True)
        Operation = "Add"
        ApplyGridTheme(GridListing)
        OpenListing()
    End Sub

    Private Sub GridListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick
        Dim row As DataGridViewRow = GridListing.Rows(e.RowIndex)

        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM CUSTOMERGROUP WHERE CUSTOMERGROUPCD = '" & row.Cells(Code.Index).Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            txtCode.Text = rs.Fields("CUSTOMERGROUPCD").Value
            txtDescription.Text = rs.Fields("CUSTOMERGROUPNAME").Value
            dtStart.Value = rs.Fields("EFFECTIVITYSTARTDATE").Value
            dtEnd.Value = rs.Fields("EFFECTIVITYENDDATE").Value
            MainTab.SelectTab(0)

            SetupButtons(False)
            Operation = ""
            EnableText()
        End If
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC  uspCustomerGroup @ACTION = 'UPDATE', @DLTFLG = 1, @CustomerGroupCD = '" & txtCode.Text & "'")

        DeleteSuccess()
        OpenListing()
        ClearForm()
ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Sub
    Private Sub Filter()
        Dim field As String
        Dim rs As New ADODB.Recordset
        If cmbFilter.Text <> "" Then
            If cmbFilter.Text = "CustomerGroupCode" Then
                field = "CustomerGroupCD"
            ElseIf cmbFilter.Text = "CustomerGroupDescription" Then
                field = "CustomerGroupNAME"
            Else
                field = ""
            End If
            If cmbFilter.Text = "All" Then
                txtFilter.Text = ""
                OpenListing()
                Exit Sub
            End If
            GridRs.Close()
            GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            GridRs.Open("SELECT * FROM CustomerGroup WHERE " & field & " like '%" & txtFilter.Text & "%'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)



            If GridRs.RecordCount > 0 Then
                GridListing.Rows.Clear()
                For i As Integer = 1 To GridRs.RecordCount
                    Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)

                    row.Cells(Code.Index).Value = GridRs.Fields("CustomerGroupCD").Value
                    row.Cells(Description.Index).Value = GridRs.Fields("CustomerGroupNAME").Value
                    row.Cells(colEffectivityStartDate.Index).Value = CDate(GridRs.Fields("EFFECTIVITYSTARTDATE").Value).ToShortDateString
                    row.Cells(colEffectivityEndDate.Index).Value = CDate(GridRs.Fields("EFFECTIVITYENDDATE").Value).ToShortDateString
                    GridRs.MoveNext()
                Next
                EnableText()
            End If
        End If
    End Sub
    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Filter()
    End Sub

    Private Sub txtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then
            Filter()
        End If
    End Sub

    Private Sub GridListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick

    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub
End Class