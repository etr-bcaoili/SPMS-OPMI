Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ucMasterRegion
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class ucMasterSTDistrict
    Private GridRs As New ADODB.Recordset
    Private Operation As String

    Private Sub ClearForm()


        cboDistrictCode.SelectedIndex = -1
        cboDistrictName.SelectedIndex = -1
        cmbRegionCode.Text = ""
        txtDivisionCode.Text = ""
        txtRegionCode.Text = ""
        txtDescription.Text = ""
        txtdistrictCode.Text = ""
        txtFilter.Text = ""
        txtSalesManagerCode.Text = ""
        txtSalesManagerName.Text = ""
        txtRegionCode.Text = ""
    End Sub

    Private Sub SetupOperation(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation
    End Sub
    Private Sub EnableText()
        txtSalesManagerCode.ReadOnly = True
        txtSalesManagerName.ReadOnly = True
        txtDivisionCode.ReadOnly = True
        txtDescription.ReadOnly = True
    End Sub
    Private Sub UnEnabletext()
        txtSalesManagerCode.ReadOnly = True
        txtSalesManagerName.ReadOnly = False
        txtDivisionCode.ReadOnly = True
        txtDescription.ReadOnly = False
    End Sub
    Private Sub UnEnabletextadd()
        txtSalesManagerCode.ReadOnly = False
        txtSalesManagerName.ReadOnly = False
        txtDivisionCode.ReadOnly = False
        txtDescription.ReadOnly = False
    End Sub
    Private Sub OpenListing()
        If GridRs.State = 1 Then GridRs.Close()
        GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        GridRs.Open("SELECT * FROM STDISTRICT WHERE DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        GridListing.Rows.Clear()
        If GridRs.RecordCount > 0 Then
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                Dim rsSTRegion As New ADODB.Recordset
                If rsSTRegion.State = 1 Then rsSTRegion.Close()
                rsSTRegion.Open("Select STREGNAME FROM STREGION WHERE DLTFLG = 0 AND STREGCD = '" & GridRs.Fields("STREGCD").Value & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                row.Cells(colCode.Index).Value = GridRs.Fields("STREGCD").Value
                If rsSTRegion.RecordCount > 0 Then
                    row.Cells(colSalesDivisionName.Index).Value = rsSTRegion.Fields("STREGNAME").Value
                Else
                    row.Cells(colSalesDivisionName.Index).Value = ""
                End If
                row.Cells(colDistrictCode.Index).Value = GridRs.Fields("STDISTRCTCD").Value

                row.Cells(colDescription.Index).Value = GridRs.Fields("STDISTRCTNAME").Value
                row.Cells(colEffectivityStartDate.Index).Value = GridRs.Fields("EFFECTIVITYSTARTDATE").Value
                row.Cells(colEffectivityEndDate.Index).Value = GridRs.Fields("EFFECTIVITYENDDATE").Value
                row.Cells(colStatus.Index).Value = IIf(GridRs.Fields("IsActive").Value = True, "Active", "Isactive")
                GridRs.MoveNext()

            Next



        End If


        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT STREGCD FROM STREGION WHERE DLTFLG = 0 AND IsActive = 1 ORDER BY STREGCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            cmbRegionCode.Items.Clear()
            For i As Integer = 1 To rs.RecordCount
                cmbRegionCode.Items.Add(rs.Fields("STREGCD").Value)
                rs.MoveNext()
            Next
        End If
    End Sub

    Private Function CheckRecordExists(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM STDISTRICT WHERE STDISTRCTCD = '" & Code & "' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function SaveRecord(ByVal RegionCode As String, ByVal DistrictCode As String, ByVal DistrictDescription As String, ByVal SLSMGR As String, ByVal EFFECTIVITYSTARTDATE As Date, ByVal EFFECTIVITYENDDATE As Date) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC uspSTDistrict @Action = 'ADD', @DLTFLG = 0, @STREGCD = '" & HandleSingleQuoteInSql(RegionCode) & "', " & _
                         " @STDISTRCTCD = '" & HandleSingleQuoteInSql(DistrictCode) & "', @STDISTRCTNAME = '" & HandleSingleQuoteInSql(DistrictDescription) & "', " & _
                         " @STSLSMGRCD = '" & HandleSingleQuoteInSql(SLSMGR) & "', @CRTDATE = '" & Now & "',  @CRTU = '', @UPDD = '" & Now & "',  @UPDU = '', " & _
                         " @EFFECTIVITYSTARTDATE = '" & EFFECTIVITYSTARTDATE & "',@EFFECTIVITYENDDATE = '" & EFFECTIVITYENDDATE & "' , @IsActive = " & chkIsActive.Checked & "")
        Return True

ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If

    End Function

    Private Function UpdateRecord(ByVal RegionCode As String, ByVal DistrictCode As String, ByVal DistrictDescription As String, ByVal SLSMGR As String, ByVal EFFECTIVITYSTARTDATE As Date, ByVal EFFECTIVITYENDDATE As Date) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC uspSTDistrict @Action = 'UPDATE',@DLTFLG = '" & "0" & "', @STREGCD = '" & HandleSingleQuoteInSql(RegionCode) & "', " & _
                         " @STDISTRCTCD = '" & HandleSingleQuoteInSql(DistrictCode) & "', @STDISTRCTNAME = '" & HandleSingleQuoteInSql(DistrictDescription) & "', " & _
                         " @STSLSMGRCD = '" & HandleSingleQuoteInSql(SLSMGR) & "',@EFFECTIVITYSTARTDATE = '" & EFFECTIVITYSTARTDATE & "' , @EFFECTIVITYENDDATE = '" & EFFECTIVITYENDDATE & "' , @IsActive = " & chkIsActive.Checked & "")
        Return True

ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Function DeleteRecord(ByVal RegionCode As String, ByVal DistrictCode As String, ByVal DistrictDescription As String) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC uspSTDistrict @Action = 'UPDATE', @DLTFLG = 1, @STREGCD = '" & HandleSingleQuoteInSql(RegionCode) & "',  " & _
                         " @STDISTRCTCD = '" & HandleSingleQuoteInSql(DistrictCode) & "', @STDISTRCTNAME = '" & HandleSingleQuoteInSql(DistrictDescription) & "' , " & _
                         " @IsActive = " & chkIsActive.Checked & " ")
        Return True

ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        cmbRegionCode.Focus()
        SetupOperation(True)
        Operation = "Add"
        ClearForm()
        UnEnabletextadd()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        SetupOperation(True)
        Operation = "Edit"
        UnEnabletext()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidFields() = True Then
            If Operation = "Add" Then
                If CheckRecordExists(cboDistrictCode.Text) = True Then
                    RecordExists()
                Else
                    SaveRecord(txtDivisionCode.Text, cboDistrictCode.Text, cboDistrictName.Text, txtSalesManagerCode.Text, dtStart.Value.ToShortDateString, dtEnd.Value.ToShortDateString)
                    SaveSuccess()
                    EnableText()
                    SetupOperation(False)
                    Operation = ""
                    OpenListing()
                    ClearForm()
                End If
            ElseIf Operation = "Edit" Then
                If CheckRecordExists(cboDistrictCode.Text) = True Then
                    UpdateRecord(txtDivisionCode.Text, cboDistrictCode.Text, cboDistrictName.Text, txtSalesManagerCode.Text, dtStart.Value, dtEnd.Value)
                    SaveSuccess()
                    EnableText()
                    SetupOperation(False)
                    Operation = ""
                    OpenListing()
                    ClearForm()
                Else
                    RecordInexist()
                End If
            End If

        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        'If CheckRecordExists(txtdistrictCode.Text) = True Then
        'If HasReferenceRecords("STDISTRICT", txtdistrictCode.Text) = False Then
        DeleteRecord(txtDivisionCode.Text, cboDistrictCode.Text, cboDistrictName.Text)
        DeleteSuccess()
        Operation = ""
        OpenListing()
        ClearForm()
        'Else
        '  EntryHasReference()
        ' End If
        '   End If
    End Sub

    Private Sub Filter()
        Dim field As String
        If cmbfilter.Text = "" Then Exit Sub
        If cmbfilter.Text = "RegionCode" Then
            field = "STREGCD"
        ElseIf cmbfilter.Text = "DistrictCode" Then
            field = "STDISTRCTCD"
        ElseIf cmbfilter.Text = "Description" Then
            field = "STDISTRCTNAME"
        Else
            field = ""
        End If
        If cmbfilter.Text = "All" Then
            OpenListing()
            txtFilter.Text = ""
            Exit Sub
        End If
        Dim GridRs As New ADODB.Recordset
        GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        GridRs.Open("SELECT * FROM STDISTRICT WHERE " & field & " like '%" & txtFilter.Text & "%' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If GridRs.RecordCount > 0 Then
            GridListing.Rows.Clear()
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                Dim rsSTRegion As New ADODB.Recordset
                If rsSTRegion.State = 1 Then rsSTRegion.Close()
                rsSTRegion.Open("Select STREGNAME FROM STREGION WHERE DLTFLG = 0 AND STREGCD = '" & GridRs.Fields("STREGCD").Value & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rsSTRegion.RecordCount > 0 Then
                    row.Cells(colSalesDivisionName.Index).Value = rsSTRegion.Fields("STREGNAME").Value
                Else
                    row.Cells(colSalesDivisionName.Index).Value = ""
                End If

                row.Cells(colCode.Index).Value = GridRs.Fields("STREGCD").Value
                row.Cells(colDistrictCode.Index).Value = GridRs.Fields("STDISTRCTCD").Value
                row.Cells(colDescription.Index).Value = GridRs.Fields("STDISTRCTNAME").Value
                row.Cells(colEffectivityStartDate.Index).Value = CDate(GridRs.Fields("EFFECTIVITYSTARTDATE").Value).ToShortDateString
                row.Cells(colEffectivityEndDate.Index).Value = CDate(GridRs.Fields("EFFECTIVITYENDDATE").Value).ToShortDateString
                row.Cells(colStatus.Index).Value = IIf(GridRs.Fields("IsActive").Value = True, "Active", "Isactive")
                GridRs.MoveNext()
            Next
        End If
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        
        Filter()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub MasterDistrict_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus

    End Sub

    Private Sub MasterDistrict_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetupOperation(True)
        ApplyGridTheme(GridListing)
        LoadDistrict()
        Operation = "Add"

        OpenListing()
    End Sub


    Private Sub GridListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Dim row As DataGridViewRow = GridListing.Rows(e.RowIndex)
        If CheckRecordExists(row.Cells(colDistrictCode.Index).Value) = True Then
            Dim rs As New ADODB.Recordset
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            'rs.Open("SELECT * FROM STDISTRICT WHERE DLTFLG = 0 AND STDISTRCTNAME = '" & row.Cells(colDescription.Index).Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            rs.Open("SELECT * FROM STDISTRICT WHERE DLTFLG = 0 AND STDISTRCTCD = '" & row.Cells(colDistrictCode.Index).Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            Dim rsSalesManager As New ADODB.Recordset
            rsSalesManager.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rsSalesManager.Open("SELECT STSLSMGRNAME FROM STSALESMANAGER WHERE DLTFLG = 0 AND STSLSMGRCD = '" & rs.Fields("STSLSMGRCD").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rs.RecordCount > 0 Then
                'cmbRegionCode.Text = rs.Fields("STREGCD").Value
                txtDivisionCode.Text = rs.Fields("STREGCD").Value
                cboDistrictCode.Text = rs.Fields("STDISTRCTCD").Value
                cboDistrictName.Text = rs.Fields("STDISTRCTNAME").Value
                txtRegionCode.Text = GetSalesDivisionName(rs.Fields("STREGCD").Value)
                ' txtdistrictCode.Text = rs.Fields("STDISTRCTCD").Value
                '  txtDescription.Text = rs.Fields("STDISTRCTNAME").Value
                dtStart.Value = rs.Fields("EFFECTIVITYSTARTDATE").Value
                dtEnd.Value = rs.Fields("EFFECTIVITYENDDATE").Value
                chkIsActive.Checked = IIf(row.Cells(colStatus.Index).Value = "Active", True, False)
                txtSalesManagerCode.Text = rs.Fields(5).Value
                If rsSalesManager.RecordCount <> 0 Then
                    txtSalesManagerName.Text = rsSalesManager.Fields(0).Value
                Else
                    txtSalesManagerName.Text = ""
                End If
                SetupOperation(False)
                Operation = ""
                MainTab.SelectTab(0)
                EnableText()
            End If
        End If
    End Sub

    Private Function ValidFields() As Boolean
        If txtDivisionCode.Text = "" Then
            Return False
        ElseIf cboDistrictName.Text = "" Then
            Return False
        ElseIf cboDistrictCode.Text = "" Then
            Return False
        Else
            If CDate(dtStart.Value.ToShortDateString) > CDate(dtEnd.Value.ToShortDateString) Then
                ShowExclamation("Effectivity Start Date should not be greater than the effectivity end date", "Validate")
                Return False
            End If

            Return True
        End If
    End Function


    Private Sub cmbRegionCode_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        OpenListing()
    End Sub


    Private Sub txtdistrictCode_KeyPress(ByVal sender As System.Object, ByVal c As System.Windows.Forms.KeyPressEventArgs)
        c.KeyChar = UCase(c.KeyChar)
    End Sub
    Private Sub txtDescription_KeyPress(ByVal sender As System.Object, ByVal c As System.Windows.Forms.KeyPressEventArgs)
        c.KeyChar = UCase(c.KeyChar)
    End Sub


    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim find As New FindSalesManager
        find.ShowDialog(Me)
        If find.ManagerCode = "" Then
        ElseIf find.ManagerName = "" Then
        Else
            txtSalesManagerCode.Text = find.ManagerCode
            txtSalesManagerName.Text = find.ManagerName
        End If

        'FindSalesManager.ShowDialog(Me)
    End Sub


    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = Chr(13) Then
            Filter()
        End If
    End Sub

    Private Sub cmbRegionCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT STREGNAME FROM STREGION WHERE STREGCD = '" & cmbRegionCode.Text & "' AND DLTFLG = 0 ORDER BY STREGCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then

            txtRegionCode.Text = rs.Fields("STREGNAME").Value

        End If
    End Sub


    Private Sub GridListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick

    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub LoadDistrict()
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT DistCd, DistName From StDistrictCreation Where DLTFLG = 0 AND IsActive = 1 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            cboDistrictCode.Items.Clear()
            cboDistrictName.Items.Clear()

            For m As Integer = 0 To rs.RecordCount - 1
                cboDistrictCode.Items.Add(rs.Fields("DistCd").Value)
                cboDistrictName.Items.Add(rs.Fields("DistName").Value)
                rs.MoveNext()
            Next
        End If
    End Sub

    Private Sub cboDistrictCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrictCode.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT DISTNAME,  DivCd FROM StDistrictCreation Where DLTFLG =0 AND IsActive = 1 AND DIstCd = '" & cboDistrictCode.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            cboDistrictName.Text = rs.Fields("DISTNAME").Value
            txtDivisionCode.Text = rs.Fields("DivCd").Value
            txtRegionCode.Text = GetSalesDivisionName(rs.Fields("DIVCD").Value)
        End If
    End Sub

    Private Sub cboDistrictName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrictName.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT DISTCD, DivCd FROM StDistrictCreation Where DLTFLG =0 AND IsActive = 1 AND DIstname = '" & cboDistrictName.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            cboDistrictCode.Text = rs.Fields("DISTCD").Value
            txtDivisionCode.Text = rs.Fields("DivCd").Value
            txtRegionCode.Text = GetSalesDivisionName(rs.Fields("DIVCD").Value)
        End If
    End Sub
    Private Function GetSalesDivisionName(ByVal DivisionCode As String) As String
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT STREGNAME FROM STREGION Where DLTFLG = 0 AND IsActive = 1 AND STREGCD = '" & DivisionCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return rs.Fields("STREGNAME").Value
        Else
            Return ""
        End If
    End Function

    Private Sub LinkLabel1_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim find As New FindSalesManager
        find.ShowDialog(Me)
        If find.ManagerCode = "" Then
        ElseIf find.ManagerName = "" Then
        Else
            txtSalesManagerCode.Text = find.ManagerCode
            txtSalesManagerName.Text = find.ManagerName
        End If
    End Sub

    Private Sub cboDistrictCode_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrictCode.SelectedIndexChanged

    End Sub

    Private Sub cboDistrictName_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrictName.SelectedIndexChanged

    End Sub
End Class