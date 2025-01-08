Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ucMasterRegion
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class ucMasterZipCode
    Private GridRs As New ADODB.Recordset
    Private Operation As String

    Private m_RsRegion As New ADODB.Recordset
    Private m_RsDistrict As New ADODB.Recordset
    Private m_RsArea As New ADODB.Recordset

    Private Sub ClearForm()
        cboRegion.Text = ""
        txtRegion.Text = ""
        cboDistrict.Items.Clear()
        txtDistrict.Text = ""
        cmbAreaCode.Items.Clear()
        txtAreaName.Text = ""
        txtZipCode.Text = ""
    End Sub
    Private Sub EnableText()
        txtRegion.ReadOnly = True
        txtZipCode.ReadOnly = True
        txtAreaName.ReadOnly = True
        txtZipCode.ReadOnly = True
    End Sub
    Private Sub UnEnableText()
        txtRegion.ReadOnly = False
        txtZipCode.ReadOnly = False
        txtAreaName.ReadOnly = False
        txtZipCode.ReadOnly = False
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
        GridRs.Open("SELECT * FROM ZIPCODE WHERE DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        GridListing.Rows.Clear()
        If GridRs.RecordCount > 0 Then
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(colRegionCode.Index).Value = GridRs.Fields("REGCD").Value
                If rsSearchRegion.State = 1 Then rsSearchRegion.Close()
                rsSearchRegion.Open("Select REGNAME FROM REGION Where REGCD = '" & GridRs.Fields("REGCD").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                row.Cells(RegionDescription.Index).Value = rsSearchRegion.Fields("REGNAME").Value
                row.Cells(colDistrictCode.Index).Value = GridRs.Fields("DISTRCTCD").Value

                If rsCityProvince.State = 1 Then rsCityProvince.Close()
                rsCityProvince.Open("Select DISTRCTNAME FROM DISTRICT WHERE DISTRCTCD =  '" & GridRs.Fields("DISTRCTCD").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                row.Cells(CityProvinceDiscription.Index).Value = rsCityProvince.Fields("DISTRCTNAME").Value
                row.Cells(AreaCode.Index).Value = GridRs.Fields("AREACD").Value
                row.Cells(AreaName.Index).Value = GridRs.Fields("AREANAME").Value
                row.Cells(ZipCode.Index).Value = GridRs.Fields("ZIPCD").Value
                row.Cells(colEffectivityStartDate.Index).Value = GridRs.Fields("EFFECTIVITYSTARTDATE").Value
                row.Cells(colEffectivityEndDate.Index).Value = GridRs.Fields("EFFECTIVITYENDDATE").Value
                GridRs.MoveNext()
            Next

        End If



    End Sub

    Private Function CheckRecordExists(ByVal Code As String, ByVal RegionCode As String, ByVal DistrictCode As String, ByVal AreaCode As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM ZIPCODE WHERE  REGCD = '" & RegionCode & "' AND DISTRCTCD = '" & DistrictCode & "'  AND  AREACD = '" & AreaCode & "'  AND  ZIPCD = '" & Code & "' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function SaveRecord(ByVal ZipCode As String, ByVal AreaCode As String, ByVal AreaName As String, ByVal RegionCode As String, ByVal DistrictCode As String, ByVal EffectivityStartDate As Date, ByVal EffectivityEndDate As Date) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC uspZipCode @Action = 'ADD', @DLTFLG = 0, @ZIPCD = '" & HandleSingleQuoteInSql(ZipCode) & "', @AREACD = '" & HandleSingleQuoteInSql(AreaCode) & "', @AREANAME = '" & HandleSingleQuoteInSql(AreaName) & "',  @CRTU = '',  @UPDU = '' , @REGCD = '" & HandleSingleQuoteInSql(RegionCode) & "' , @DISTRCTCD = '" & HandleSingleQuoteInSql(DistrictCode) & "',@EFFECTIVITYSTARTDATE = '" & EffectivityStartDate & "',@EFFECTIVITYENDDATE = '" & EffectivityEndDate & "' ")
        Return True

ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If

    End Function

    Private Function UpdateRecord(ByVal ZipCode As String, ByVal AreaCode As String, ByVal AreaName As String, ByVal RegionCode As String, ByVal DistrictCode As String, ByVal OldZipCode As String, ByVal EffectivityStartDate As Date, ByVal EffectivityEndDate As Date) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC uspZipCode @Action = 'UPDATE', @ZIPCD = '" & HandleSingleQuoteInSql(ZipCode) & "', @AREACD = '" & HandleSingleQuoteInSql(AreaCode) & "', @AREANAME = '" & HandleSingleQuoteInSql(AreaName) & "' , @REGCD = '" & HandleSingleQuoteInSql(RegionCode) & "' , @DISTRCTCD = '" & HandleSingleQuoteInSql(DistrictCode) & "' , @OLDZIPCODE = '" & HandleSingleQuoteInSql(OldZipCode) & "',@EFFECTIVITYSTARTDATE = '" & EffectivityStartDate & "',@EFFECTIVITYENDDATE = '" & EffectivityEndDate & "' ")
        Return True

ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Function DeleteRecord(ByVal ZipCode As String, ByVal AreaCode As String, ByVal RegionCode As String, ByVal DistrictCode As String) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC uspZipCode @Action = 'DELETE',@ZIPCD = '" & ZipCode & "', @AREACD = '" & AreaCode & "', @REGCD = '" & RegionCode & "' , @DISTRCTCD = '" & DistrictCode & "' ")
        Return True

ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        cmbAreaCode.Focus()
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
        If CheckRecordExists(txtZipCode.Text, cboRegion.Text, cboDistrict.Text, cmbAreaCode.Text) = True Then
            DeleteRecord(txtZipCode.Text, cmbAreaCode.Text, cboRegion.Text, cboDistrict.Text)
            DeleteSuccess()
            Operation = ""
            OpenListing()
            ClearForm()
            UnEnableText()
        End If
    End Sub
    Private Sub Filter()
        Dim rsSearchRegion As New ADODB.Recordset
        Dim rsCityProvince As New ADODB.Recordset

        Dim field As String
        If cmbfilter.Text = "ZipCode" Then
            field = "ZIPCD"
        ElseIf cmbfilter.Text = "Region Code" Then
            field = "REGCD"
        ElseIf cmbfilter.Text = "City/Province Code" Then
            field = "DISTRCTCD"
        ElseIf cmbfilter.Text = "Municipality / Location Code" Then
            field = "AREACD"
        ElseIf cmbfilter.Text = "Municipality / Location Name" Then
            field = "AREANAME"
        Else
            field = ""
        End If

        If cmbfilter.Text = "All" Then

            If GridRs.State = 1 Then GridRs.Close()
            GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            GridRs.Open("SELECT * FROM ZIPCODE WHERE DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Else
            If GridRs.State = 1 Then GridRs.Close()
            GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            GridRs.Open("SELECT * FROM ZIPCODE WHERE " & field & " like '%" & txtFilter.Text & "%' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        End If
        
        If GridRs.RecordCount > 0 Then
            GridListing.Rows.Clear()
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)

                If rsSearchRegion.State = 1 Then rsSearchRegion.Close()
                row.Cells(colRegionCode.Index).Value = GridRs.Fields("REGCD").Value
                rsSearchRegion.Open("Select REGNAME FROM REGION Where REGCD = '" & GridRs.Fields("REGCD").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                row.Cells(RegionDescription.Index).Value = rsSearchRegion.Fields("REGNAME").Value
                row.Cells(colDistrictCode.Index).Value = GridRs.Fields("DISTRCTCD").Value

                If rsCityProvince.State = 1 Then rsCityProvince.Close()
                rsCityProvince.Open("Select DISTRCTNAME FROM DISTRICT WHERE DISTRCTCD =  '" & GridRs.Fields("DISTRCTCD").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                row.Cells(CityProvinceDiscription.Index).Value = rsCityProvince.Fields("DISTRCTNAME").Value
                row.Cells(ZipCode.Index).Value = GridRs.Fields("ZIPCD").Value
                row.Cells(AreaCode.Index).Value = GridRs.Fields("AREACD").Value
                row.Cells(AreaName.Index).Value = GridRs.Fields("AREANAME").Value
                row.Cells(AreaName.Index).Value = GridRs.Fields("EFFECTIVITYSTARTDATE").Value
                row.Cells(AreaName.Index).Value = GridRs.Fields("EFFECTIVITYENDDATE").Value
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
        LoadRegion()
        OpenListing()
    End Sub


    Private Sub GridListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick
        Dim row As DataGridViewRow = GridListing.Rows(e.RowIndex)
        If CheckRecordExists(row.Cells(ZipCode.Index).Value, row.Cells(colRegionCode.Index).Value, row.Cells(colDistrictCode.Index).Value, row.Cells(AreaCode.Index).Value) = True Then
            Dim rs As New ADODB.Recordset
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.Open("SELECT * FROM ZIPCODE WHERE DLTFLG = 0 AND REGCD = '" & row.Cells(colRegionCode.Index).Value & "' AND DISTRCTCD = '" & row.Cells(colDistrictCode.Index).Value & "'  AND AREACD = '" & row.Cells(AreaCode.Index).Value & "'  AND ZIPCD = '" & row.Cells(ZipCode.Index).Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then

                cboRegion.Text = rs.Fields("REGCD").Value
                GetRegionDescription(rs.Fields("REGCD").Value)

                cboDistrict.Text = rs.Fields("DISTRCTCD").Value
                GetDistrictDescription(rs.Fields("DISTRCTCD").Value, rs.Fields("REGCD").Value)

                cmbAreaCode.Text = rs.Fields("AREACD").Value
                txtAreaName.Text = rs.Fields("AREANAME").Value
                txtZipCode.Text = rs.Fields("ZIPCD").Value
                txtZipCode.Tag = rs.Fields("ZIPCD").Value
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
        If cmbAreaCode.Text = "" Then
            Return False
        ElseIf txtAreaName.Text = "" Then
            Return False
        ElseIf txtZipCode.Text = "" Then
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


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidFields() = True Then
            If Operation = "Add" Then
                If CheckRecordExists(txtZipCode.Text, cboRegion.Text, cboDistrict.Text, cmbAreaCode.Text) = True Then
                    RecordExists()
                Else
                    SaveRecord(txtZipCode.Text, cmbAreaCode.Text, txtAreaName.Text, cboRegion.Text, cboDistrict.Text, dtStart.Value, dtEnd.Value)
                    SaveSuccess()
                    SetupOperation(False)
                    Operation = ""
                    ClearForm()
                    EnableText()
                    OpenListing()
                End If
            ElseIf Operation = "Edit" Then
                '   If CheckRecordExists(txtZipCode.Text, cboRegion.Text, cboDistrict.Text, cmbAreaCode.Text) = True Then
                UpdateRecord(txtZipCode.Text, cmbAreaCode.Text, txtAreaName.Text, cboRegion.Text, cboDistrict.Text, txtZipCode.Tag, dtStart.Value, dtEnd.Value)
                SaveSuccess()
                EnableText()
                SetupOperation(False)
                Operation = ""
                OpenListing()
                'Else
                ' RecordInexist()
                'End If
            End If
        End If
    End Sub

    Private Sub GetAreaDescription(ByVal AreaCode As String, ByVal RegionCode As String, ByVal DistrictCode As String)
        If m_RsArea.State = 1 Then m_RsArea.Close()
        m_RsArea.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsArea.Open("SELECT AREANAME FROM AREA WHERE  DLTFLG = 0  AND AREACD = '" & AreaCode & "'  AND REGCD = '" & RegionCode & "'  AND DISTRCTCD  = '" & DistrictCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsArea.RecordCount > 0 Then
            txtAreaName.Text = m_RsArea.Fields("AREANAME").Value
        Else
            txtAreaName.Text = ""
        End If

    End Sub

    Private Sub cmbTerritoryCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAreaCode.SelectedIndexChanged
        GetAreaDescription(cmbAreaCode.Text, cboRegion.Text, cboDistrict.Text)

    End Sub

    Private Sub txtZipCode_KeyPress(ByVal sender As System.Object, ByVal c As System.Windows.Forms.KeyPressEventArgs) Handles txtZipCode.KeyPress
        c.KeyChar = UCase(c.KeyChar)
    End Sub

    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then
            Filter()
        End If
    End Sub


    '=======================================================================================

    Private Sub GetRegionDescription(ByVal RegionCode As String)
        If m_RsRegion.State = 1 Then m_RsRegion.Close()
        m_RsRegion.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsRegion.Open("SELECT REGNAME FROM REGION WHERE DLTFLG = 0  AND REGCD = '" & RegionCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsRegion.RecordCount > 0 Then
            txtRegion.Text = m_RsRegion.Fields("REGNAME").Value
        Else
            txtRegion.Text = ""
        End If
    End Sub

    Private Sub GetDistrictDescription(ByVal DistrictCode As String, ByVal RegionCode As String)
        If m_RsDistrict.State = 1 Then m_RsDistrict.Close()
        m_RsDistrict.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsDistrict.Open("SELECT DISTRCTNAME FROM District WHERE DLTFLG = 0 AND DISTRCTCD = '" & DistrictCode & "' AND REGCD = '" & RegionCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsDistrict.RecordCount > 0 Then
            txtDistrict.Text = m_RsDistrict.Fields("DISTRCTNAME").Value
        Else
            txtDistrict.Text = ""
        End If
    End Sub



    Private Sub LoadRegion()
        If m_RsRegion.State = 1 Then m_RsRegion.Close()
        m_RsRegion.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsRegion.Open("SELECT REGCD,REGNAME FROM REGION WHERE DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsRegion.RecordCount > 0 Then
            txtRegion.Text = ""
            cboRegion.Items.Clear()
            'cboRegionDesc.Items.Clear()
            For m As Integer = 0 To m_RsRegion.RecordCount - 1
                cboRegion.Items.Add(m_RsRegion.Fields("REGCD").Value)
                '   cboRegionDesc.Items.Add(m_RsRegion.Fields("REGNAME").Value)
                m_RsRegion.MoveNext()
            Next
        End If
    End Sub


    Private Sub LoadDistrict(ByVal RegionCode As String)
        If m_RsDistrict.State = 1 Then m_RsDistrict.Close()
        m_RsDistrict.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsDistrict.Open("SELECT DISTRCTCD FROM District WHERE DLTFLG = 0 " & IIf(RegionCode <> "", " AND REGCD = '" & RegionCode & "' ", ""), SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        cboDistrict.Items.Clear()
        txtDistrict.Text = ""

        If m_RsDistrict.RecordCount > 0 Then
            For m As Integer = 0 To m_RsDistrict.RecordCount - 1
                cboDistrict.Items.Add(m_RsDistrict.Fields("DISTRCTCD").Value)
                m_RsDistrict.MoveNext()
            Next
            cmbAreaCode.Items.Clear()
            txtAreaName.Text = ""
        Else
            cboDistrict.SelectedIndex = -1

        End If

    End Sub

    Private Sub cboRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRegion.SelectedIndexChanged
        ' If cboRegion.SelectedIndex <> -1 Then
        GetRegionDescription(cboRegion.Text)
        LoadDistrict(cboRegion.Text)

        'Else
        '   txtRegion.Text = ""
        ' End If
    End Sub



    Private Sub cboDistrict_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDistrict.SelectedIndexChanged


        GetDistrictDescription(cboDistrict.Text, cboRegion.Text)
        LoadArea(cboDistrict.Text, cboRegion.Text)

    End Sub


    Private Sub LoadArea(ByVal DistrictCode As String, ByVal RegionCode As String)

        Dim rsArea As New ADODB.Recordset
        rsArea.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rsArea.Open("SELECT AREACD FROM AREA WHERE DLTFLG = 0 AND REGCD = '" & RegionCode & "' AND DISTRCTCD = '" & DistrictCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        cmbAreaCode.Items.Clear()
        txtAreaName.Text = ""
        If rsArea.RecordCount > 0 Then
            cmbAreaCode.Items.Clear()
            For i As Integer = 1 To rsArea.RecordCount
                cmbAreaCode.Items.Add(rsArea.Fields("AREACD").Value)
                rsArea.MoveNext()
            Next

        Else
            cmbAreaCode.Items.Clear()
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
    'Private Sub cmbRegionDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim rs As New ADODB.Recordset

    '    rs = RsRegionInfo("Regname = '" & cboRegionDesc.Text & "' ")
    '    If rs.RecordCount > 0 Then
    '        cboRegionDesc.Text = rs.Fields("RegCD").Value
    '    End If


    'End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub

    Private Sub GridListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick

    End Sub
End Class