Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ucMasterRegion
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class ucMasterMunicipalityLocation
    Private GridRs As New ADODB.Recordset
    
    Private Operation As String

    Private Sub ClearForm()
        cmbRegionCode.Text = ""

        cmbDistrictCode.Items.Clear()

        txtAreaCode.Text = ""
        txtAreaName.Text = ""
    End Sub
    Private Sub EnableText()
        txtAreaCode.ReadOnly = True
        txtAreaName.ReadOnly = True
    End Sub
    Private Sub UnEnableText()
        txtAreaCode.ReadOnly = False
        txtAreaName.ReadOnly = False
    End Sub
    Private Sub SetupOperation(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation
    End Sub

    Private Sub OpenListing()
        Dim rsSearchRegion As New ADODB.Recordset
        Dim rsCityProvince As New ADODB.Recordset
        If GridRs.State = 1 Then GridRs.Close()
        GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        GridRs.Open("SELECT * FROM AREA WHERE DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        GridListing.Rows.Clear()
        If GridRs.RecordCount > 0 Then
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(RegionCode.Index).Value = GridRs.Fields("REGCD").Value

                If rsSearchRegion.State = 1 Then rsSearchRegion.Close()
                rsSearchRegion.Open("Select REGNAME FROM REGION Where REGCD = '" & GridRs.Fields("REGCD").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                row.Cells(RegionDescription.Index).Value = rsSearchRegion.Fields("REGNAME").Value
                row.Cells(DistrictCode.Index).Value = GridRs.Fields("DISTRCTCD").Value

                If rsCityProvince.State = 1 Then rsCityProvince.Close()
                rsCityProvince.Open("Select DISTRCTNAME FROM DISTRICT WHERE DISTRCTCD =  '" & GridRs.Fields("DISTRCTCD").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                row.Cells(CityProvinceDescription.Index).Value = rsCityProvince.Fields("DISTRCTNAME").Value
                row.Cells(AreaCode.Index).Value = GridRs.Fields("AREACD").Value
                row.Cells(AreaName.Index).Value = GridRs.Fields("AREANAME").Value
                row.Cells(colEffectivityStartDate.Index).Value = CDate(GridRs.Fields("EFFECTIVITYSTARTDATE").Value).ToShortDateString
                row.Cells(colEffectivityEndDate.Index).Value = CDate(GridRs.Fields("EFFECTIVITYENDDATE").Value).ToShortDateString
                GridRs.MoveNext()
            Next



        End If

        Dim rsRegion As New ADODB.Recordset
        rsRegion.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rsRegion.Open("SELECT REGCD,REGNAME FROM REGION WHERE DLTFLG = 0 ORDER BY REGCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsRegion.RecordCount > 0 Then
            cmbRegionCode.Items.Clear()
            For i As Integer = 1 To rsRegion.RecordCount
                cmbRegionCode.Items.Add(rsRegion.Fields("REGCD").Value)
                cmbRegionDesc.Items.Add(rsRegion.Fields("REGNAME").Value)
                rsRegion.MoveNext()
            Next
        End If


    End Sub

    Private Function CheckRecordExists(ByVal Code As String, ByVal RegionCode As String, ByVal DistrictCode As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM AREA WHERE  /*REGCD = '" & RegionCode & "' AND DISTRCTCD = '" & DistrictCode & "' AND  */ AREACD = '" & Code & "' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function SaveRecord(ByVal RegionCode As String, ByVal DistrictCode As String, ByVal AreaCode As String, ByVal AreaName As String, ByVal EffectivityStartDate As Date, ByVal EffectivityEndDate As Date) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC uspAREA @Action = 'ADD', @DLTFLG = 0, @REGCD = '" & RegionCode & "', @DISTRCTCD = '" & DistrictCode & "', @AREACD = '" & AreaCode & "', @AREANAME = '" & AreaName & "',  @CRTU = '',   @UPDU = '',@EFFECTIVITYSTARTDATE = '" & EffectivityStartDate & "',@EFFECTIVITYENDDATE = '" & EffectivityEndDate & "' ")
        Return True

ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If

    End Function

    Private Function UpdateRecord(ByVal RegionCode As String, ByVal DistrictCode As String, ByVal AreaCode As String, ByVal AreaName As String, ByVal OldAreaCode As String, ByVal EffectivityStartDate As Date, ByVal EffectivityEndDate As Date) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC uspArea @Action = 'UPDATE', @REGCD = '" & RegionCode & "', @DISTRCTCD = '" & DistrictCode & "', @AREACD = '" & AreaCode & "',@AREANAME = '" & AreaName & "' , @OLDAREACD = '" & OldAreaCode & "',@EFFECTIVITYSTARTDATE = '" & EffectivityStartDate & "' ,@EFFECTIVITYENDDATE = '" & EffectivityEndDate & "' ")
        Return True

ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Function DeleteRecord(ByVal RegionCode As String, ByVal DistrictCode As String, ByVal AreaCode As String) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC uspArea @Action = 'DELETE', @REGCD = '" & RegionCode & "', @DISTRCTCD = '" & DistrictCode & "', @AREACD = '" & AreaCode & "' ")
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
        UnEnableText()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        SetupOperation(True)
        Operation = "Edit"
        UnEnableText()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If CheckRecordExists(txtAreaCode.Text, cmbRegionCode.Text, cmbDistrictCode.Text) = True Then
            If HasReferenceRecords("AREA", txtAreaCode.Text) = False Then
                DeleteRecord(cmbRegionCode.Text, cmbDistrictCode.Text, txtAreaCode.Text)
                DeleteSuccess()
                Operation = ""
                OpenListing()
                ClearForm()
                EnableText()
            Else
                EntryHasReference()
            End If
        End If
    End Sub
    Private Sub Filter()

        Dim rsSearchRegion As New ADODB.Recordset
        Dim rsCityProvince As New ADODB.Recordset

        Dim field As String
        If cmbfilter.Text = "Region Code" Then
            field = "REGCD"
        ElseIf cmbfilter.Text = "City / Province Code" Then
            field = "DISTRCTCD"
        ElseIf cmbfilter.Text = "Municipality / Location Code" Then
            field = "AREACD"
        ElseIf cmbfilter.Text = "Municipality / Location Name" Then
            field = "AREANAME"
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
        GridRs.Open("SELECT * FROM AREA WHERE " & field & " like '%" & txtFilter.Text & "%' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If GridRs.RecordCount > 0 Then
            GridListing.Rows.Clear()
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(RegionCode.Index).Value = GridRs.Fields("REGCD").Value
                If rsSearchRegion.State = 1 Then rsSearchRegion.Close()
                rsSearchRegion.Open("Select REGNAME FROM REGION Where REGCD = '" & GridRs.Fields("REGCD").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                row.Cells(RegionDescription.Index).Value = rsSearchRegion.Fields("REGNAME").Value
                row.Cells(DistrictCode.Index).Value = GridRs.Fields("DISTRCTCD").Value

                If rsCityProvince.State = 1 Then rsCityProvince.Close()
                rsCityProvince.Open("Select DISTRCTNAME FROM DISTRICT WHERE DISTRCTCD =  '" & GridRs.Fields("DISTRCTCD").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                row.Cells(CityProvinceDescription.Index).Value = rsCityProvince.Fields("DISTRCTNAME").Value
                row.Cells(AreaCode.Index).Value = GridRs.Fields("AREACD").Value
                row.Cells(AreaName.Index).Value = GridRs.Fields("AREANAME").Value
                row.Cells(colEffectivityStartDate.Index).Value = CDate(GridRs.Fields("EFFECTIVITYSTARTDATE").Value).ToShortDateString
                row.Cells(colEffectivityEndDate.Index).Value = CDate(GridRs.Fields("EFFECTIVITYENDDATE").Value).ToShortDateString
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
        Operation = "Add"

        OpenListing()
    End Sub


    Private Sub GridListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick
        Dim row As DataGridViewRow = GridListing.Rows(e.RowIndex)
        If CheckRecordExists(row.Cells(AreaCode.Index).Value, row.Cells(RegionCode.Index).Value, row.Cells(DistrictCode.Index).Value) = True Then
            Dim rs As New ADODB.Recordset
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.Open("SELECT * FROM AREA WHERE DLTFLG = 0 AND REGCD = '" & row.Cells(RegionCode.Index).Value & "' AND DISTRCTCD = '" & row.Cells(DistrictCode.Index).Value & "'   AND AREACD = '" & row.Cells(AreaCode.Index).Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                cmbRegionCode.Text = rs.Fields("REGCD").Value
                cmbDistrictCode.Text = rs.Fields("DISTRCTCD").Value
                txtAreaCode.Text = rs.Fields("AREACD").Value
                txtAreaCode.Tag = rs.Fields("AREACD").Value
                txtAreaName.Text = rs.Fields("AREANAME").Value
                dtStart.Value = rs.Fields("EFFECTIVITYSTARTDATE").Value
                dtEnd.Value = rs.Fields("EFFECTIVITYENDDATE").Value
                SetupOperation(False)
                EnableText()
                Operation = ""
                MainTab.SelectTab(0)
            End If
        End If
    End Sub

    Private Function ValidFields() As Boolean
        If cmbRegionCode.Text = "" Then
            Return False
        ElseIf cmbDistrictCode.Text = "" Then
            Return False
        ElseIf txtAreaCode.Text = "" Then
            Return False
        ElseIf txtAreaName.Text = "" Then
            Return False
        Else
            Return True
        End If
    End Function



    Private Sub tbEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbEntry.Click

    End Sub

    Private Sub cmbRegionCode_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        OpenListing()
    End Sub


    Private Sub cmbRegionCode_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegionCode.SelectedIndexChanged
        cmbDistrictCode.Text = ""
        cmbDistrictDesc.Text = ""
        Dim rsRegion As New ADODB.Recordset
        rsRegion.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rsRegion.Open("SELECT REGNAME FROM REGION WHERE DLTFLG = 0 AND REGCD = '" & cmbRegionCode.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsRegion.RecordCount > 0 Then
            '    txtRegionName.Text = ""
            '    txtRegionName.Text = rsRegion.Fields("REGNAME").Value
        Else
            '   txtRegionName.Text = ""
        End If

        Dim rsDistrict As New ADODB.Recordset
        rsDistrict.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rsDistrict.Open("SELECT DISTRCTCD,DISTRCTNAME FROM DISTRICT WHERE DLTFLG = 0 AND REGCD = '" & cmbRegionCode.Text & "' ORDER BY DISTRCTCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsDistrict.RecordCount > 0 Then
            cmbDistrictCode.Items.Clear()
            cmbDistrictDesc.Items.Clear()
            For i As Integer = 1 To rsDistrict.RecordCount
                cmbDistrictCode.Items.Add(rsDistrict.Fields("DISTRCTCD").Value)
                cmbDistrictDesc.Items.Add(rsDistrict.Fields("DISTRCTNAME").Value)
                rsDistrict.MoveNext()
            Next
        Else
            cmbDistrictCode.Items.Clear()
        End If
    End Sub

    Private Sub cmbDistrictCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDistrictCode.SelectedIndexChanged
        ''txtDistrictName.Text = ""
        'Dim rsDistrict As New ADODB.Recordset
        'rsDistrict.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rsDistrict.Open("SELECT DISTRCTNAME FROM DISTRICT WHERE DLTFLG = 0 AND REGCD = '" & cmbRegionCode.Text & "' AND DISTRCTCD = '" & cmbDistrictCode.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        'If rsDistrict.RecordCount > 0 Then
        '    '   txtDistrictName.Text = rsDistrict.Fields("DISTRCTNAME").Value
        'Else
        '    '  txtDistrictName.Text = ""
        'End If
        Dim rs As New ADODB.Recordset

        rs = RsDistrictInfo("DistrctCD = '" & cmbDistrictCode.Text & "' ")
        If rs.RecordCount > 0 Then
            cmbDistrictDesc.Text = rs.Fields("DistrctName").Value
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidFields() = True Then
            If Operation = "Add" Then
                If CheckRecordExists(txtAreaCode.Text, cmbRegionCode.Text, cmbDistrictCode.Text) = True Then
                    RecordExists()
                Else
                    SaveRecord(cmbRegionCode.Text, cmbDistrictCode.Text, txtAreaCode.Text, txtAreaName.Text, dtStart.Value, dtEnd.Value)
                    SaveSuccess()
                    SetupOperation(False)
                    Operation = ""
                    OpenListing()
                    ClearForm()
                    EnableText()
                End If
            ElseIf Operation = "Edit" Then
                If CheckRecordExists(txtAreaCode.Text, cmbRegionCode.Text, cmbDistrictCode.Text) = True Then
                    UpdateRecord(cmbRegionCode.Text, cmbDistrictCode.Text, txtAreaCode.Text, txtAreaName.Text, txtAreaCode.Tag, dtStart.Value, dtEnd.Value)
                    SaveSuccess()
                    SetupOperation(False)
                    Operation = ""
                    OpenListing()
                    EnableText()
                Else
                    RecordInexist()
                End If
            End If
        End If
    End Sub

    Private Sub txtAreaCode_KeyPress(ByVal sender As System.Object, ByVal c As System.Windows.Forms.KeyPressEventArgs) Handles txtAreaCode.KeyPress
        c.KeyChar = UCase(c.KeyChar)
    End Sub
    Private Sub txtAreaName_KeyPress(ByVal sender As System.Object, ByVal c As System.Windows.Forms.KeyPressEventArgs) Handles txtAreaName.KeyPress
        c.KeyChar = UCase(c.KeyChar)
    End Sub
    Private Sub txtFilter_Keypress(ByVal sender As System.Object, ByVal c As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        c.KeyChar = UCase(c.KeyChar)
        If c.KeyChar = Chr(13) Then
            Filter()
        End If
    End Sub
    Private Sub cmbRegionCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegionCode.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
        'rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rs.Open("SELECT REGNAME FROM REGION WHERE REGCD = '" & cmbRegionCode.Text & "' AND DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        'If rs.RecordCount > 0 Then
        '    txtRegion.Text = (rs.Fields("REGNAME").Value)
        'End If
        rs = RsRegionInfo("RegCD = '" & cmbRegionCode.Text & "' ")

        If rs.RecordCount > 0 Then
            cmbRegionDesc.Text = rs.Fields("RegName").Value
        End If

    End Sub

    Private Function RsRegionInfo(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If
        rs.Open("SELECT * FROM REGION WHERE DLTFLG = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function
    Private Function RsDistrictInfo(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT * FROM DISTRICT WHERE DLTFLG = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function
    Private Sub cmbRegionDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegionDesc.SelectedIndexChanged
        Dim rs As New ADODB.Recordset

        rs = RsRegionInfo("Regname = '" & cmbRegionDesc.Text & "' ")
        If rs.RecordCount > 0 Then
            cmbRegionCode.Text = rs.Fields("RegCD").Value
        End If


    End Sub
    Private Sub cmbDistrictDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDistrictDesc.SelectedIndexChanged
        Dim rs As New ADODB.Recordset

        rs = RsDistrictInfo("Distrctname = '" & cmbDistrictDesc.Text & "' ")
        If rs.RecordCount > 0 Then
            cmbDistrictCode.Text = rs.Fields("DistrctCD").Value
        End If


    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub

    Private Sub GridListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick

    End Sub
End Class