Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ucMasterRegion
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class ucMasterSTTeam

    Private GridRs As New ADODB.Recordset
    Private Operation As String

    Private Sub ClearForm()
        cmbRegionCode.Text = String.Empty
        txtRegionName.Text = ""
        txtDistrictName.Text = ""
        cmbDistrict.Text = String.Empty
        txtTeamCode.Text = ""
        txtTeamName.Text = ""
        txtFilter.Text = ""
        txtTeamCode.Tag = -1
    End Sub

    Private Sub SetupOperation(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation
    End Sub
    Private Sub EnableText()
        txtDistrictName.ReadOnly = True
        txtTeamCode.ReadOnly = True
        txtRegionName.ReadOnly = True
    End Sub
    Private Sub UnEnabletext()
        txtDistrictName.ReadOnly = False
        txtTeamCode.ReadOnly = True
        txtRegionName.ReadOnly = False
    End Sub
    Private Sub UnaEnabletextadd()
        txtDistrictName.ReadOnly = False
        txtTeamCode.ReadOnly = False
        txtRegionName.ReadOnly = False
    End Sub
    Private Sub OpenListing()

        Dim rsSTRegion As New ADODB.Recordset
        Dim rsSTCityProvince As New ADODB.Recordset

        If GridRs.State = 1 Then GridRs.Close()
        GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        GridRs.Open("SELECT * FROM STTEAM WHERE DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        GridListing.Rows.Clear()
        If GridRs.RecordCount > 0 Then
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)

                row.Tag = GridRs.Fields("STTEAMID").Value
                row.Cells(RegionCode.Index).Value = GridRs.Fields("STREGCD").Value
                If rsSTRegion.State = 1 Then rsSTRegion.Close()
                rsSTRegion.Open("Select STREGNAME FROM STREGION WHERE STREGCD = '" & GridRs.Fields("STREGCD").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                ' row.Cells(RegionDescription.Index).Value = rsSTRegion.Fields("STREGNAME").Value

                row.Cells(DistrictCode.Index).Value = GridRs.Fields("STDISTRCTCD").Value
                If rsSTCityProvince.State = 1 Then rsSTCityProvince.Close()
                rsSTCityProvince.Open("Select STDISTRCTNAME FROM STDISTRICT WHERE STDISTRCTCD = '" & GridRs.Fields("STDISTRCTCD").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rsSTCityProvince.RecordCount <> 0 Then
                    row.Cells(DistrictDescription.Index).Value = rsSTCityProvince.Fields("STDISTRCTNAME").Value
                End If
                row.Cells(TeamCode.Index).Value = GridRs.Fields("STTEAMCD").Value
                row.Cells(TeamName.Index).Value = GridRs.Fields("STTEAMNAME").Value
                row.Cells(colEffectivityStartDate.Index).Value = GridRs.Fields("EFFECTIVITYSTARTDATE").Value
                row.Cells(colEffectivityEndDate.Index).Value = GridRs.Fields("EFFECTIVITYENDDATE").Value
                row.Cells(colStatus.Index).Value = IIf(GridRs.Fields("IsActive").Value = True, "Active", "Inactive")
                GridRs.MoveNext()
            Next



        End If


        Dim rsRegion As New ADODB.Recordset
        rsRegion.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rsRegion.Open("SELECT STREGCD FROM STREGION WHERE DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsRegion.RecordCount > 0 Then
            cmbRegionCode.Items.Clear()
            For i As Integer = 1 To rsRegion.RecordCount
                cmbRegionCode.Items.Add(rsRegion.Fields("STREGCD").Value)
                rsRegion.MoveNext()
            Next
        End If

        Dim rsDisrict As New ADODB.Recordset
        rsDisrict.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rsDisrict.Open("SELECT STDISTRCTCD FROM STDISTRICT WHERE DLTFLG = 0 ORDER BY STDISTRCTCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsDisrict.RecordCount > 0 Then
            cmbDistrict.Items.Clear()
            For i As Integer = 1 To rsDisrict.RecordCount
                cmbDistrict.Items.Add(rsDisrict.Fields("STDISTRCTCD").Value)
                rsDisrict.MoveNext()
            Next
        End If
    End Sub

    Private Function CheckRecordExists(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM STTEAM WHERE DLTFLG = 0  AND STTEAMID = " & txtTeamCode.Tag, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function SaveRecord(ByVal RegionCode As String, ByVal DistrictCode As String, ByVal TeamCode As String, ByVal TeamName As String, ByVal EffectivityStartDate As Date, ByVal EffectivityEndDate As Date) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC uspSTTEAM @Action = 'ADD', @DLTFLG = 0, @STREGCD = '" & RegionCode & "', @STDISTRCTCD = '" & DistrictCode & "', @STTEAMCD = '" & TeamCode & "', @STTEAMNAME = '" & TeamName & "', @CRTDATE = '" & Now & "',  @CRTU = '', @UPDD = '" & Now & "',  @UPDU = '',@EFFECTIVITYSTARTDATE = '" & EffectivityStartDate & "',@EFFECTIVITYENDDATE = '" & EffectivityEndDate & "' , @IsActive = " & chkIsActive.Checked & " ")
        Return True

ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If

    End Function

    Private Function UpdateRecord(ByVal RegionCode As String, ByVal DistrictCode As String, ByVal TeamCode As String, ByVal TeamName As String, ByVal EffectivityStartDate As Date, ByVal EffectivityEndDate As Date) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC uspSTTeam @Action = 'UPDATE', @STREGCD = '" & RegionCode & "', @STDISTRCTCD = '" & DistrictCode & "', @STTEAMCD = '" & TeamCode & "', @STTEAMNAME = '" & TeamName & "',@EFFECTIVITYSTARTDATE = '" & EffectivityStartDate & "',@EFFECTIVITYENDDATE = '" & EffectivityEndDate & "' , @IsActive = " & chkIsActive.Checked & ", @STTEAMID = " & txtTeamCode.Tag)
        Return True

ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Function DeleteRecord(ByVal RegionCode As String, ByVal DistrictCode As String, ByVal TeamCode As String, ByVal TeamName As String) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC uspSTTeam @Action = 'UPDATE', @DLTFLG = 1, @STREGCD = '" & RegionCode & "', @STDISTRCTCD = '" & DistrictCode & "', @STTEAMCD = '" & TeamCode & "', @STTEAMNAME = '" & TeamName & "' , @IsActive = " & chkIsActive.Checked & ", @STTEAMID = " & txtTeamCode.Tag)
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
        UnaEnabletextadd()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        SetupOperation(True)
        Operation = "Edit"
        UnEnabletext()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidFields() = True Then
            If Operation = "Add" Then
                If CheckRecordExists(txtTeamCode.Text) = True Then
                    RecordExists()
                Else
                    SaveRecord(cmbRegionCode.Text, cmbDistrict.Text, txtTeamCode.Text, txtTeamName.Text, dtStart.Value, dtEnd.Value)
                    SaveSuccess()
                    EnableText()
                    SetupOperation(False)
                    Operation = ""
                    OpenListing()
                    ClearForm()
                End If
            ElseIf Operation = "Edit" Then
                If CheckRecordExists(txtTeamCode.Text) = True Then
                    UpdateRecord(cmbRegionCode.Text, cmbDistrict.Text, txtTeamCode.Text, txtTeamName.Text, dtStart.Value, dtEnd.Value)
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
        If CheckRecordExists(txtTeamCode.Text) = True Then
            ' If HasReferenceRecords("STDISTRICT", txtdistrictCode.Text) = False Then
            DeleteRecord(cmbRegionCode.Text, cmbDistrict.Text, txtTeamCode.Text, txtTeamName.Text)
            DeleteSuccess()
            Operation = ""
            OpenListing()
            'Else
            'EntryHasReference()
            'End If
        End If
    End Sub

    Private Sub Filter()
        Dim field As String
        If cmbfilter.Text = "RegionCode" Then
            field = "STREGCD"
        ElseIf cmbfilter.Text = "DistrictCode" Then
            field = "STDISTRCTCD"
        ElseIf cmbfilter.Text = "TeamCode" Then
            field = "STTEAMCD"
        ElseIf cmbfilter.Text = "TeamName" Then
            field = "STTEAMNAME"
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
        GridRs.Open("SELECT * FROM STTEAM WHERE " & field & " like '%" & txtFilter.Text & "%' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If GridRs.RecordCount > 0 Then
            GridListing.Rows.Clear()
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Tag = GridRs.Fields("STTeamID").Value
                row.Cells(RegionCode.Index).Value = GridRs.Fields("STREGCD").Value
                row.Cells(DistrictCode.Index).Value = GridRs.Fields("STDISTRCTCD").Value
                row.Cells(TeamCode.Index).Value = GridRs.Fields("STTEAMCD").Value
                row.Cells(TeamName.Index).Value = GridRs.Fields("STTEAMNAME").Value
                row.Cells(colEffectivityStartDate.Index).Value = GridRs.Fields("EFFECTIVITYSTARTDATE").Value
                row.Cells(colEffectivityEndDate.Index).Value = GridRs.Fields("EFFECTIVITYENDDATE").Value
                row.Cells(colStatus.Index).Value = IIf(GridRs.Fields("IsActive").Value = True, "Active", "Inactive")
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
        ClearForm()
        Operation = "Add"

        OpenListing()

    End Sub


    Private Sub GridListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick
        Dim row As DataGridViewRow = GridListing.Rows(e.RowIndex)
        ' If CheckRecordExists(row.Cells(TeamCode.Index).Value) = True Then
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM STTEAM WHERE DLTFLG = 0 AND STTEAMCD = '" & row.Cells(TeamCode.Index).Value & "' AND STREGCD =  '" & row.Cells(RegionCode.Index).Value & "' AND STDISTRCTCD = '" & row.Cells(DistrictCode.Index).Value & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            txtTeamCode.Tag = row.Tag
            cmbRegionCode.Text = rs.Fields("STREGCD").Value
            cmbDistrict.Text = rs.Fields("STDISTRCTCD").Value
            txtTeamCode.Text = rs.Fields("STTEAMCD").Value
            txtTeamName.Text = rs.Fields("STTEAMNAME").Value
            dtStart.Value = rs.Fields("EFFECTIVITYSTARTDATE").Value
            dtEnd.Value = rs.Fields("EFFECTIVITYENDDATE").Value
            chkIsActive.Checked = rs.Fields("IsActive").Value
            SetupOperation(False)
            Operation = ""
            MainTab.SelectTab(0)
        End If
        ' End If
    End Sub

    Private Function ValidFields() As Boolean
        If cmbRegionCode.Text = "" Then
            Return False
        ElseIf cmbDistrict.Text = "" Then
            Return False
        ElseIf txtTeamCode.Text = "" Then
            Return False
        ElseIf txtTeamName.Text = "" Then
            Return False
        Else
            Return True
        End If
    End Function


    'Private Sub cmbRegionCode_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    OpenListing()
    'End Sub

    

    Private Sub txtdistrictCode_KeyPress(ByVal sender As System.Object, ByVal c As System.Windows.Forms.KeyPressEventArgs)
        c.KeyChar = UCase(c.KeyChar)
    End Sub
    Private Sub txtDescription_KeyPress(ByVal sender As System.Object, ByVal c As System.Windows.Forms.KeyPressEventArgs)
        c.KeyChar = UCase(c.KeyChar)
    End Sub


    Private Sub txtTeamCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtTeamName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
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
        rs.Open("SELECT STREGNAME FROM STREGION WHERE STREGCD = '" & cmbRegionCode.Text & "' AND DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            txtRegionName.Text = rs.Fields("STREGNAME").Value
        End If


    End Sub

    Private Sub cmbDistrict_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim rsDisrict As New ADODB.Recordset
        rsDisrict.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rsDisrict.Open("SELECT STDISTRCTNAME FROM STDISTRICT WHERE STDISTRCTCD = '" & cmbDistrict.Text & "' AND DLTFLG = 0 ORDER BY STDISTRCTCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsDisrict.RecordCount > 0 Then
            txtDistrictName.Text = rsDisrict.Fields("STDISTRCTNAME").Value
        End If
    End Sub

    
 
    Private Sub GridListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick

    End Sub
End Class