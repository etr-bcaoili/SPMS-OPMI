Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule

Public Class UCMasterZipCodeAssignmentToTerritory
    Dim OPeration As String
    Private Sub UCMasterZipCodeAssignmentToTerritory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(GridListing)
        ApplyGridTheme(DGZip)
        ApplyGridTheme(dgMuni)
        ClearItems()
        PopulateRecordset()
        OPeration = "Add"
        SetupOperation(True)
        OpenListing()
    End Sub

    Private Sub ClearItems()
        PopulateRecordset()
        DGZip.Rows.Clear()
    End Sub

    Private Sub PopulateRecordset()
        Dim rs As New ADODB.Recordset
        cmbArea.Items.Clear()
        cmbAreaDesc.Items.Clear()
        cmbzipCode.Items.Clear()
        cmbRegion.Items.Clear()
        cmbRegionDesc.Items.Clear()
        cmbDistrict.Items.Clear()
        cmbDistrictDesc.Items.Clear()
        cmbMunicipality.Items.Clear()
        cmbMunicipalityDesc.Items.Clear()

        'cmbArea.Items.Add("") 'this value will be used for all
        cmbzipCode.Items.Add("") 'this value will be used for all




        'for the Region Combo box
        rs = RsRegion()
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbRegion.Items.Add(rs.Fields("RegCD").Value)
                cmbRegionDesc.Items.Add(rs.Fields("RegName").Value)

                rs.MoveNext()
            Next
        End If

        'If rs.RecordCount > 0 Then
        '    For i As Integer = 1 To rs.RecordCount
        '        cmbzipCode.Items.Add(rs.Fields("ZipCD").Value)
        '        rs.MoveNext()
        '    Next
        'End If


        ' for the area
        rs = RsArea()
     
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbArea.Items.Add(rs.Fields("STACOVCD").Value)
                cmbAreaDesc.Items.Add(rs.Fields("STACOVNAME").Value)
                rs.MoveNext()
            Next
        End If


    End Sub

    Private Function RsZipCode(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT * FROM ZIPCODE WHERE DLTFLG = 0" & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function

    Private Function RsArea(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If
        rs.Open("SELECT * FROM STAREACOVERAGE WHERE DLTFLG = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


       
        Return rs
    End Function

    Private Function RsMatrix(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT  * FROM SALESMATRIX WHERE dltflg = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


        Return rs
    End Function

    Private Sub comboSelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbzipCode.SelectedIndexChanged
        If sender Is cmbzipCode Then
            Dim rs As New ADODB.Recordset
            DGZip.Rows.Clear()
            rs = RsCompleteZip("ZipCd = '" & cmbzipCode.Text & "'")
            If rs.RecordCount > 0 Then
                For i As Integer = 1 To rs.RecordCount
                    Dim row As DataGridViewRow = DGZip.Rows(DGZip.Rows.Add)
                    row.Cells(selAreaCD.Index).Value = rs.Fields("AreaCD").Value
                    row.Cells(selAreaDescription.Index).Value = rs.Fields("AreaName").Value
                    row.Cells(selDistrictCD.Index).Value = rs.Fields("DistrctCD").Value
                    row.Cells(selDistrictDescription.Index).Value = rs.Fields("DistrctName").Value
                    row.Cells(selRegCd.Index).Value = rs.Fields("RegCD").Value
                    row.Cells(selRegionDesc.Index).Value = rs.Fields("RegName").Value
                    row.Cells(selZipCode.Index).Value = rs.Fields("ZipCD").Value
                    row.Cells(selZipID.Index).Value = -1
                    rs.MoveNext()
                Next
            End If
        End If

    End Sub

    Private Function RsCompleteZip(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        rs.Open("SELECT A.ZIPID 	AS ZIPID, A.DLTFLG 	AS DLTFLG, A.ZIPCD 	AS ZIPCD, A.AREACD 	AS AREACD, A.AREANAME 	AS AREANAME, A.REGCD 	AS REGCD, " & _
                 "B.REGNAME 	AS REGNAME, A.DISTRCTCD 	AS DISTRCTCD, C.DISTRCTNAME AS DISTRCTNAME FROM 	ZIPCODE 	AS A, " & _
                    " REGION 	AS B, DISTRICT 	AS C WHERE(B.REGCD = A.REGCD) AND	C.DISTRCTCD = A.DISTRCTCD AND	A.DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If Filter <> "" Then
            rs.Filter = Filter
        End If
        Return rs
    End Function

    Private Function RsLinkedZip(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If
        rs.Open("SELECT A.ZIPID 	AS ZIPID, A.DLTFLG 	AS DLTFLG, A.ZIPCD 	AS ZIPCD, A.AREACD 	AS AREACD, A.AREANAME 	AS AREANAME, A.REGCD 	AS REGCD, " & _
                 "B.REGNAME 	AS REGNAME, A.DISTRCTCD 	AS DISTRCTCD, C.DISTRCTNAME AS DISTRCTNAME FROM 	ZIPCODE 	AS A, " & _
                    " REGION 	AS B, DISTRICT 	AS C WHERE(B.REGCD = A.REGCD) AND	C.DISTRCTCD = A.DISTRCTCD AND	A.DLTFLG = 0" & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

       
        Return rs
    End Function

    Private Function ValidFields() As Boolean
        Dim ctr As Integer = 0
        ' If cmbzipCode.Text <> "" Then
        'Return False
        If DGZip.Rows.Count = 0 Then
            Return False
        Else
            For i As Integer = 0 To DGZip.Rows.Count - 1
                Dim row As DataGridViewRow = DGZip.Rows(i)
                If row.Cells(selCheckBox.Index).Value = True Then
                    ctr = +1
                    Exit For
                End If
            Next

            If ctr > 0 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function


    Private Function SaveRecord() As Boolean
        For I As Integer = 0 To DGZip.Rows.Count - 1
            Dim row As DataGridViewRow = DGZip.Rows(I)
            If row.Cells(selCheckBox.Index).Value = True Then
                SPMSConn.Execute("EXEC USPZIPCODETERRITORYMAPPING @Action = 'ADD', @DLTFLG = 0  , " & _
                                 " @REGCD = '" & HandleSingleQuoteInSql(row.Cells(selRegCd.Index).Value) & "' ," & "@REGNAME = '" & HandleSingleQuoteInSql(row.Cells(selRegionDesc.Index).Value) & "' ,@DISTRCTCD = '" & HandleSingleQuoteInSql(row.Cells(selDistrictCD.Index).Value) & "'," & "@DISTRCTNAME  = '" & HandleSingleQuoteInSql(row.Cells(selDistrictDescription.Index).Value) & "'," & "@AREACD = '" & HandleSingleQuoteInSql(row.Cells(selAreaCD.Index).Value) & "' ," & "@AREANAME = '" & HandleSingleQuoteInSql(row.Cells(selAreaDescription.Index).Value) & "' ," & "@ZIPCD = '" & HandleSingleQuoteInSql(row.Cells(selZipCode.Index).Value) & "' ," & "@AREACOVRG = '" & HandleSingleQuoteInSql(cmbArea.Text) & "'," & "@AREACOVERGDESCRIPTION = '" & HandleSingleQuoteInSql(cmbAreaDesc.Text) & "', @EFFECTIVITYSTARTDATE = '" & dtStart.Value & "' ,  @EFFECTIVITYENDDATE = '" & dtEnd.Value & "' ")
            End If
        Next
    End Function

    Private Sub SetupOperation(ByVal HasOPeration As Boolean)
        btnAdd.Enabled = Not HasOPeration
        btnEdit.Enabled = Not HasOPeration
        btnDelete.Enabled = Not HasOPeration
        btnSave.Enabled = HasOPeration
    End Sub

    Private Sub UpdateRecord()
        For i As Integer = 0 To DGZip.Rows.Count - 1
            Dim row As DataGridViewRow = DGZip.Rows(i)
            If row.Cells(selCheckBox.Index).Value = True Then
                If row.Cells(selZipID.Index).Value <> -1 Then
                    SPMSConn.Execute("EXEC USPZIPCODETERRITORYMAPPING @ACTION = 'UPDATE' , @ZipCD = '" & row.Cells(selZipCode.Index).Value & "' ,  " & _
                                     " @REGCD = '" & HandleSingleQuoteInSql(row.Cells(selRegCd.Index).Value) & "' ," & "@REGNAME = '" & HandleSingleQuoteInSql(row.Cells(selRegionDesc.Index).Value) & "' , " & _
                                     " @DISTRCTCD = '" & HandleSingleQuoteInSql(row.Cells(selDistrictCD.Index).Value) & "'," & "@DISTRCTNAME  = '" & HandleSingleQuoteInSql(row.Cells(selDistrictDescription.Index).Value) & "'," & _
                                     "@AREACD = '" & HandleSingleQuoteInSql(row.Cells(selAreaCD.Index).Value) & "' ," & "@AREANAME = '" & HandleSingleQuoteInSql(row.Cells(selAreaDescription.Index).Value) & "' , " & _
                                     " @ZIPCODETERRITORYMAPPINGID = " & row.Cells(selZipID.Index).Value & ", @DLTFLG = 0, @AREACOVRG = '" & HandleSingleQuoteInSql(cmbArea.Text) & "'  , @AREACOVERGDESCRIPTION = '" & HandleSingleQuoteInSql(cmbAreaDesc.Text) & "' , @EFFECTIVITYSTARTDATE = '" & dtStart.Value & "' , @EFFECTIVITYENDDATE = '" & dtEnd.Value & "' ")
                End If
            End If
        Next
    End Sub

    Private Sub DeleteRecord()
        For i As Integer = 0 To DGZip.Rows.Count - 1
            Dim row As DataGridViewRow = DGZip.Rows(i)
            If row.Cells(selCheckBox.Index).Value = True Then
                SPMSConn.Execute("EXEC USPZIPCODETERRITORYMAPPING @ACTION = 'DELETE' , @ZIPCODETERRITORYMAPPINGID = " & row.Cells(selZipID.Index).Value & ", @DLTFLG = 1 ")
            End If
        Next
    End Sub

    Private Sub ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click, btnAdd.Click, btnEdit.Click, btnDelete.Click, btnClose.Click, cmbArea.SelectedValueChanged, cmbAreaDesc.SelectedValueChanged
        If sender Is btnAdd Then
            OPeration = "Add"
            ClearItems()
            PopulateRecordset()
            SetupOperation(True)
        ElseIf sender Is btnEdit Then
            OPeration = "Edit"
            SetupOperation(True)
        ElseIf sender Is btnDelete Then
            DeleteRecord()
            OPeration = ""
            SetupOperation(False)
            DeleteSuccess()
            OpenListing()

        ElseIf sender Is btnSave Then
            If ValidFields() = True Then
                If OPeration = "Add" Then
                    SaveRecord()
                    OPeration = ""
                    SetupOperation(False)
                    OpenListing()
                    SaveSuccess()
                ElseIf OPeration = "Edit" Then
                    UpdateRecord()
                    OPeration = ""
                    SetupOperation(False)
                    OpenListing()
                    SaveSuccess()
                End If
            End If
        ElseIf sender Is btnClose Then
            On Error Resume Next
            Dim m_TabPage As TabPage = Me.Parent
            CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
            Me.Dispose()
            ElseIf sender Is cmbArea Then
                Dim rs As New ADODB.Recordset
                rs = RsArea("STACOVCD =  '" & cmbArea.Text & "'")

                If rs.RecordCount > 0 Then
                    cmbAreaDesc.Text = rs.Fields("STACOVNAME").Value
                End If


                rs = RsMatrix("STACOVCD = '" & cmbArea.Text & "' ")
                If rs.RecordCount > 0 Then
                    txtdiv.Text = rs.Fields("stitmdivcd").Value
                End If
            ElseIf sender Is cmbAreaDesc Then
                Dim rs As New ADODB.Recordset
                rs = RsArea("STACOVNAME = '" & cmbAreaDesc.Text & "'")
                If rs.RecordCount > 0 Then
                    cmbArea.Text = rs.Fields("STACOVCD").Value

                End If

            End If

    End Sub

    Private Function RsZipCodeMapping(Optional ByVal filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If filter <> "" Then
            filter = " AND " & filter
        End If
        rs.Open("SELECT * FROM ZIPCODETERRITORYMAPPING WHERE DLTFLG = 0 " & filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        'rs.Open("SELECT * F")
        Return rs
    End Function

    Private Sub OpenListing()
        Dim rs As New ADODB.Recordset
        rs = RsZipCodeMapping()
        GridListing.Rows.Clear()
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(colZipCode.Index).Value = rs.Fields("zipcd").Value
                row.Cells(colAreaCd.Index).Value = rs.Fields("Areacd").Value
                row.Cells(colAreaDesc.Index).Value = rs.Fields("AreaName").Value
                row.Cells(colDistrictCd.Index).Value = rs.Fields("distrctcd").Value
                row.Cells(colDistrictDesc.Index).Value = rs.Fields("Districtname").Value

                row.Cells(colRegCd.Index).Value = rs.Fields("RegCd").Value
                row.Cells(colRegDesc.Index).Value = rs.Fields("RegName").Value


                row.Cells(colCoverageCD.Index).Value = rs.Fields("AreaCovrg").Value
                row.Cells(colCoverageName.Index).Value = rs.Fields("AreaCovrgDescription").Value

                row.Cells(colZipMappingID.Index).Value = rs.Fields("ZipCodeTerritoryMappingID").Value

                row.Cells(colStartDate.Index).Value = rs.Fields("EffectivityStartDate").Value
                row.Cells(colEndDate.Index).Value = rs.Fields("EffectivityEndDate").Value

                rs.MoveNext()
            Next
        End If
    End Sub

    Private Sub GridListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick

        If e.RowIndex = -1 Then Exit Sub
        Dim rs As New ADODB.Recordset
        SetupOperation(False)
        OPeration = ""
        ClearItems()
        PopulateRecordset()
        Dim row As DataGridViewRow = GridListing.Rows(e.RowIndex)
        rs = RsZipCodeMapping("ZipCodeTerritoryMappingID = " & row.Cells(colZipMappingID.Index).Value)

        cmbzipCode.Text = row.Cells(colZipCode.Index).Value
        cmbArea.Text = row.Cells(colCoverageCD.Index).Value
        cmbAreaDesc.Text = row.Cells(colCoverageName.Index).Value

        dtStart.Value = rs.Fields("EffectivityStartDate").Value
        dtEnd.Value = rs.Fields("EffectivityEndDate").Value

        DGZip.Rows.Clear()

        Dim ZipRow As DataGridViewRow = DGZip.Rows(DGZip.Rows.Add)
        ZipRow.Cells(selRegCd.Index).Value = row.Cells(colRegCd.Index).Value
        ZipRow.Cells(selRegionDesc.Index).Value = row.Cells(colRegDesc.Index).Value
        ZipRow.Cells(selDistrictCD.Index).Value = row.Cells(colDistrictCd.Index).Value
        ZipRow.Cells(selDistrictDescription.Index).Value = row.Cells(colDistrictDesc.Index).Value
        ZipRow.Cells(selAreaCD.Index).Value = row.Cells(colAreaCd.Index).Value
        ZipRow.Cells(selAreaDescription.Index).Value = row.Cells(colAreaDesc.Index).Value
        ZipRow.Cells(selZipID.Index).Value = row.Cells(colZipMappingID.Index).Value
        ZipRow.Cells(selZipCode.Index).Value = row.Cells(colZipCode.Index).Value
        MainTab.SelectTab(0)

    End Sub

    Private Function RsRegion(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT * FROM REGION WHERE DLTFLG = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function

    Private Function RsDistrict(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT * FROM DISTRICT WHERE DLTFLG  = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs
    End Function


    Private Function RsMunicipality(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT * FROM AREA WHERE DLTFLG = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs
    End Function

    Private Sub SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegion.SelectedIndexChanged, cmbRegionDesc.SelectedIndexChanged, cmbDistrict.SelectedIndexChanged, cmbDistrictDesc.SelectedIndexChanged, cmbMunicipalityDesc.SelectedIndexChanged, cmbMunicipality.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
        If sender Is cmbRegion Then
            'clear the combo boxes
            cmbDistrict.Items.Clear()
            cmbDistrictDesc.Items.Clear()
            cmbMunicipality.Items.Clear()
            cmbMunicipalityDesc.Items.Clear()
            cmbzipCode.Items.Clear()


            dgMuni.Rows.Clear()


            rs = RsRegion("RegCD = '" & cmbRegion.Text & "' ")
            If rs.RecordCount > 0 Then


                cmbRegionDesc.Text = rs.Fields("RegName").Value

                cmbDistrict.Items.Clear()
                cmbDistrictDesc.Items.Clear()
                cmbMunicipality.Items.Clear()
                cmbMunicipalityDesc.Items.Clear()
                cmbzipCode.Items.Clear()
                dgMuni.Rows.Clear()
                rs = RsDistrict("RegCD = '" & cmbRegion.Text & "' ")



                cmbDistrict.Text = ""
                cmbDistrictDesc.Text = ""
                cmbMunicipality.Text = ""
                cmbMunicipalityDesc.Text = ""
                cmbzipCode.Text = ""

                If rs.RecordCount > 0 Then
                    For i As Integer = 1 To rs.RecordCount
                        cmbDistrict.Items.Add(rs.Fields("DistrctCD").Value)
                        cmbDistrictDesc.Items.Add(rs.Fields("DistrctName").Value)

                        rs.MoveNext()
                    Next

                End If


                'for the zipcode grid
                DGZip.Rows.Clear()
                rs = RsCompleteZip("RegCD = '" & cmbRegion.Text & "'")
                If rs.RecordCount > 0 Then
                    For i As Integer = 1 To rs.RecordCount
                        Dim row As DataGridViewRow = DGZip.Rows(DGZip.Rows.Add)
                        row.Cells(selAreaCD.Index).Value = rs.Fields("AreaCD").Value
                        row.Cells(selAreaDescription.Index).Value = rs.Fields("AreaName").Value
                        row.Cells(selDistrictCD.Index).Value = rs.Fields("DistrctCD").Value
                        row.Cells(selDistrictDescription.Index).Value = rs.Fields("DistrctName").Value
                        row.Cells(selRegCd.Index).Value = rs.Fields("RegCD").Value
                        row.Cells(selRegionDesc.Index).Value = rs.Fields("RegName").Value
                        row.Cells(selZipCode.Index).Value = rs.Fields("ZipCD").Value
                        row.Cells(selZipID.Index).Value = -1
                        rs.MoveNext()
                    Next
                End If

            End If



        ElseIf sender Is cmbRegionDesc Then
            'clear the combo boxes
            cmbDistrict.Items.Clear()
            cmbDistrictDesc.Items.Clear()
            cmbMunicipality.Items.Clear()
            cmbMunicipalityDesc.Items.Clear()
            cmbzipCode.Items.Clear()
            dgMuni.Rows.Clear()



            rs = RsRegion("RegName = '" & cmbRegionDesc.Text & "' ")
            If rs.RecordCount > 0 Then
                cmbRegion.Text = rs.Fields("RegCD").Value

                cmbDistrict.Items.Clear()
                cmbDistrictDesc.Items.Clear()
                cmbMunicipality.Items.Clear()
                cmbMunicipalityDesc.Items.Clear()
                cmbzipCode.Items.Clear()

                dgMuni.Rows.Clear()

                cmbDistrict.Text = ""
                cmbDistrictDesc.Text = ""
                cmbMunicipality.Text = ""
                cmbMunicipalityDesc.Text = ""
                cmbzipCode.Text = ""

                rs = RsDistrict("RegCD = '" & cmbRegion.Text & "' ")
                If rs.RecordCount > 0 Then
                    For i As Integer = 1 To rs.RecordCount
                        cmbDistrict.Items.Add(rs.Fields("DistrctCD").Value)
                        cmbDistrictDesc.Items.Add(rs.Fields("DistrctName").Value)

                        rs.MoveNext()
                    Next
                End If



                'for the zipcode grid
                DGZip.Rows.Clear()
                rs = RsCompleteZip("RegCD = '" & cmbRegion.Text & "'")

                If rs.RecordCount > 0 Then
                    For i As Integer = 1 To rs.RecordCount
                        Dim row As DataGridViewRow = DGZip.Rows(DGZip.Rows.Add)
                        row.Cells(selAreaCD.Index).Value = rs.Fields("AreaCD").Value
                        row.Cells(selAreaDescription.Index).Value = rs.Fields("AreaName").Value
                        row.Cells(selDistrictCD.Index).Value = rs.Fields("DistrctCD").Value
                        row.Cells(selDistrictDescription.Index).Value = rs.Fields("DistrctName").Value
                        row.Cells(selRegCd.Index).Value = rs.Fields("RegCD").Value
                        row.Cells(selRegionDesc.Index).Value = rs.Fields("RegName").Value
                        row.Cells(selZipCode.Index).Value = rs.Fields("ZipCD").Value
                        row.Cells(selZipID.Index).Value = -1
                        rs.MoveNext()
                    Next
                End If

            End If

        ElseIf sender Is cmbDistrict Then

            'clear the combo boxes

            cmbMunicipality.Items.Clear()
            cmbMunicipalityDesc.Items.Clear()
            cmbzipCode.Items.Clear()

            dgMuni.Rows.Clear()

            rs = RsDistrict("RegCD = '" & cmbRegion.Text & "' AND DistrctCD = '" & cmbDistrict.Text & "' ")
            If rs.RecordCount > 0 Then
                cmbDistrictDesc.Text = rs.Fields("DistrctName").Value


                cmbMunicipality.Items.Clear()
                cmbMunicipalityDesc.Items.Clear()
                cmbzipCode.Items.Clear()

                dgMuni.Rows.Clear()

                cmbMunicipality.Text = ""
                cmbMunicipalityDesc.Text = ""
                cmbzipCode.Text = ""



                rs = RsMunicipality("RegCD = '" & cmbRegion.Text & "' AND DistrctCD = '" & cmbDistrict.Text & "' ")
                If rs.RecordCount > 0 Then
                    For i As Integer = 1 To rs.RecordCount
                        cmbMunicipality.Items.Add(rs.Fields("Areacd").Value)
                        cmbMunicipalityDesc.Items.Add(rs.Fields("AreaName").Value)

                        Dim rows As DataGridViewRow = dgMuni.Rows(dgMuni.Rows.Add)

                        rows.Cells(selMunicipality.Index).Value = rs.Fields("Areacd").Value
                        rows.Cells(selMunicipalityDesc.Index).Value = rs.Fields("AreaName").Value


                        rs.MoveNext()
                    Next
                End If


                'for the zipcode grid
                DGZip.Rows.Clear()
                rs = RsCompleteZip("RegCD = '" & cmbRegion.Text & "'")
                rs.Filter = "DistrctCD = '" & cmbDistrict.Text & "' "
                If rs.RecordCount > 0 Then
                    For i As Integer = 1 To rs.RecordCount
                        Dim row As DataGridViewRow = DGZip.Rows(DGZip.Rows.Add)
                        row.Cells(selAreaCD.Index).Value = rs.Fields("AreaCD").Value
                        row.Cells(selAreaDescription.Index).Value = rs.Fields("AreaName").Value
                        row.Cells(selDistrictCD.Index).Value = rs.Fields("DistrctCD").Value
                        row.Cells(selDistrictDescription.Index).Value = rs.Fields("DistrctName").Value
                        row.Cells(selRegCd.Index).Value = rs.Fields("RegCD").Value
                        row.Cells(selRegionDesc.Index).Value = rs.Fields("RegName").Value
                        row.Cells(selZipCode.Index).Value = rs.Fields("ZipCD").Value
                        row.Cells(selZipID.Index).Value = -1
                        rs.MoveNext()
                    Next
                End If
            End If



        ElseIf sender Is cmbDistrictDesc Then

            'clear the combo boxes

            cmbMunicipality.Items.Clear()

            cmbMunicipalityDesc.Items.Clear()
            cmbMunicipalityDesc.Text = ""
            cmbzipCode.Items.Clear()

            rs = RsDistrict("RegCD = '" & cmbRegion.Text & "' AND DistrctName = '" & cmbDistrictDesc.Text & "' ")
            If rs.RecordCount > 0 Then
                cmbDistrict.Text = rs.Fields("DistrctCD").Value

                cmbMunicipality.Items.Clear()
                cmbMunicipalityDesc.Items.Clear()
                cmbzipCode.Items.Clear()

                cmbMunicipality.Text = ""
                cmbMunicipalityDesc.Text = ""
                cmbzipCode.Text = ""

                rs = RsMunicipality("RegCD = '" & cmbRegion.Text & "' AND DistrctCD = '" & cmbDistrict.Text & "' ")
                If rs.RecordCount > 0 Then
                    For i As Integer = 1 To rs.RecordCount
                        cmbMunicipality.Items.Add(rs.Fields("Areacd").Value)
                        cmbMunicipalityDesc.Items.Add(rs.Fields("AreaName").Value)


                        Dim rows As DataGridViewRow = dgMuni.Rows(dgMuni.Rows.Add)

                        rows.Cells(selMunicipality.Index).Value = rs.Fields("Areacd").Value
                        rows.Cells(selMunicipalityDesc.Index).Value = rs.Fields("AreaName").Value


                        rs.MoveNext()
                    Next
                End If


                'for the zipcode grid
                DGZip.Rows.Clear()
                rs = RsCompleteZip("RegCD = '" & cmbRegion.Text & "'")
                rs.Filter = "DistrctCD = '" & cmbDistrict.Text & "' "
                If rs.RecordCount > 0 Then
                    For i As Integer = 1 To rs.RecordCount
                        Dim row As DataGridViewRow = DGZip.Rows(DGZip.Rows.Add)
                        row.Cells(selAreaCD.Index).Value = rs.Fields("AreaCD").Value
                        row.Cells(selAreaDescription.Index).Value = rs.Fields("AreaName").Value
                        row.Cells(selDistrictCD.Index).Value = rs.Fields("DistrctCD").Value
                        row.Cells(selDistrictDescription.Index).Value = rs.Fields("DistrctName").Value
                        row.Cells(selRegCd.Index).Value = rs.Fields("RegCD").Value
                        row.Cells(selRegionDesc.Index).Value = rs.Fields("RegName").Value
                        row.Cells(selZipCode.Index).Value = rs.Fields("ZipCD").Value
                        row.Cells(selZipID.Index).Value = -1
                        rs.MoveNext()
                    Next
                End If


            End If

        ElseIf sender Is cmbMunicipality Then
            'clear the combo boxes
            cmbzipCode.Items.Clear()

            rs = RsMunicipality("RegCd = '" & cmbRegion.Text & "' AND DistrctCD = '" & cmbDistrict.Text & "' AND AreaCD = '" & cmbMunicipality.Text & "' ")

            If rs.RecordCount > 0 Then
                cmbMunicipalityDesc.Text = rs.Fields("AreaName").Value
                cmbzipCode.Items.Clear()


                cmbzipCode.Text = ""


                rs = RsZipCode("RegCd = '" & cmbRegion.Text & "' AND DistrctCD = '" & cmbDistrict.Text & "' AND AreaCD = '" & cmbMunicipality.Text & "' ")
                If rs.RecordCount > 0 Then
                    For i As Integer = 1 To rs.RecordCount
                        cmbzipCode.Items.Add(rs.Fields("Zipcd").Value)
                        rs.MoveNext()
                    Next
                End If


                'for the zipcode grid
                DGZip.Rows.Clear()
                rs = RsCompleteZip("RegCD = '" & cmbRegion.Text & "' AND DistrctCD = '" & cmbDistrict.Text & "'  AND AreaCD = '" & cmbMunicipality.Text & "' ")
                'rs.Filter = "DistrctCD = '" & cmbDistrict.Text & "' "
                ' rs.Filter = "AreaCD = '" & cmbMunicipality.Text & "' "
                If rs.RecordCount > 0 Then
                    For i As Integer = 1 To rs.RecordCount
                        Dim row As DataGridViewRow = DGZip.Rows(DGZip.Rows.Add)
                        row.Cells(selAreaCD.Index).Value = rs.Fields("AreaCD").Value
                        row.Cells(selAreaDescription.Index).Value = rs.Fields("AreaName").Value
                        row.Cells(selDistrictCD.Index).Value = rs.Fields("DistrctCD").Value
                        row.Cells(selDistrictDescription.Index).Value = rs.Fields("DistrctName").Value
                        row.Cells(selRegCd.Index).Value = rs.Fields("RegCD").Value
                        row.Cells(selRegionDesc.Index).Value = rs.Fields("RegName").Value
                        row.Cells(selZipCode.Index).Value = rs.Fields("ZipCD").Value
                        row.Cells(selZipID.Index).Value = -1
                        rs.MoveNext()
                    Next
                End If

            End If
        ElseIf sender Is cmbMunicipalityDesc Then
            'clear the combo boxes
            cmbzipCode.Items.Clear()

            rs = RsMunicipality("RegCd = '" & cmbRegion.Text & "' AND DistrctCD = '" & cmbDistrict.Text & "' AND AreaName = '" & cmbMunicipalityDesc.Text & "' ")

            If rs.RecordCount > 0 Then
                cmbMunicipality.Text = rs.Fields("AreaCD").Value
                cmbzipCode.Items.Clear()


                cmbzipCode.Text = ""

                rs = RsZipCode("RegCd = '" & cmbRegion.Text & "' AND DistrctCD = '" & cmbDistrict.Text & "' AND AreaCD = '" & cmbMunicipality.Text & "' ")
                If rs.RecordCount > 0 Then
                    For i As Integer = 1 To rs.RecordCount
                        cmbzipCode.Items.Add(rs.Fields("Zipcd").Value)
                        rs.MoveNext()
                    Next
                End If

                'for the zipcode grid
                DGZip.Rows.Clear()
                rs = RsCompleteZip("RegCD = '" & cmbRegion.Text & "' AND DistrctCD = '" & cmbDistrict.Text & "'  AND AreaCD = '" & cmbMunicipality.Text & "' ")
                'rs.Filter = "DistrctCD = '" & cmbDistrict.Text & "' "
                ' rs.Filter = "AreaCD = '" & cmbMunicipality.Text & "' "
                If rs.RecordCount > 0 Then
                    For i As Integer = 1 To rs.RecordCount
                        Dim row As DataGridViewRow = DGZip.Rows(DGZip.Rows.Add)
                        row.Cells(selAreaCD.Index).Value = rs.Fields("AreaCD").Value
                        row.Cells(selAreaDescription.Index).Value = rs.Fields("AreaName").Value
                        row.Cells(selDistrictCD.Index).Value = rs.Fields("DistrctCD").Value
                        row.Cells(selDistrictDescription.Index).Value = rs.Fields("DistrctName").Value
                        row.Cells(selRegCd.Index).Value = rs.Fields("RegCD").Value
                        row.Cells(selRegionDesc.Index).Value = rs.Fields("RegName").Value
                        row.Cells(selZipCode.Index).Value = rs.Fields("ZipCD").Value
                        row.Cells(selZipID.Index).Value = -1
                        rs.MoveNext()
                    Next
                End If

            End If
        End If

    End Sub



    Private Sub LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llcheck.LinkClicked, llUncheck.Click, llCheckAll.LinkClicked, llUncheckAll.LinkClicked
        If sender Is llcheck Then
            If DGZip.Rows.Count > 0 Then
                For i As Integer = 0 To DGZip.Rows.Count - 1
                    Dim row As DataGridViewRow = DGZip.Rows(i)
                    row.Cells(selCheckBox.Index).Value = True

                Next
            End If
        ElseIf sender Is llUncheck Then
            If DGZip.Rows.Count > 0 Then
                For i As Integer = 0 To DGZip.Rows.Count - 1
                    Dim row As DataGridViewRow = DGZip.Rows(i)
                    row.Cells(selCheckBox.Index).Value = False

                Next
            End If
        ElseIf sender Is llCheckAll Then
            If dgMuni.Rows.Count > 0 Then
                For i As Integer = 0 To dgMuni.Rows.Count - 1
                    Dim row As DataGridViewRow = dgMuni.Rows(i)
                    row.Cells(selSelect.Index).Value = True
                Next
                dgMuni_CellEndEdit()

            End If
        ElseIf sender Is llUncheckAll Then
            If dgMuni.Rows.Count > 0 Then
                For i As Integer = 0 To dgMuni.Rows.Count - 1
                    Dim row As DataGridViewRow = dgMuni.Rows(i)
                    row.Cells(selSelect.Index).Value = False
                Next
                dgMuni_CellEndEdit()
            End If
        End If
    End Sub


    Private Sub dgMuni_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMuni.CellContentClick

    End Sub

    Private Sub dgMuni_CellEndEdit() Handles dgMuni.CellEndEdit
        Dim StrWhere As String = ""
        Dim rs As New ADODB.Recordset
        Dim ctr As Integer = 0

        For i As Integer = 0 To dgMuni.Rows.Count - 1
            Dim row As DataGridViewRow = dgMuni.Rows(i)
            If row.Cells(selSelect.Index).Value = True Then
                ctr += 1
                Exit For
            End If
        Next

        If ctr >= 1 Then
            For i As Integer = 0 To dgMuni.Rows.Count - 1
                Dim row As DataGridViewRow = dgMuni.Rows(i)
                If row.Cells(selSelect.Index).Value = True Then
                    If StrWhere = "" Then
                        StrWhere = "A.AreacD IN ('" & row.Cells(selMunicipality.Index).Value & "'"

                    Else
                        StrWhere = StrWhere & ", '" & row.Cells(selMunicipality.Index).Value & "'"
                    End If
                End If
            Next
            StrWhere = StrWhere & ")"


            'for the zipcode grid
            DGZip.Rows.Clear()
            rs = RsLinkedZip("A.RegCD = '" & cmbRegion.Text & "' AND A.DistrctCD = '" & cmbDistrict.Text & "'  AND " & StrWhere)
            'rs.Filter = "DistrctCD = '" & cmbDistrict.Text & "' "
            ' rs.Filter = "AreaCD = '" & cmbMunicipality.Text & "' "
            If rs.RecordCount > 0 Then
                For i As Integer = 1 To rs.RecordCount
                    Dim row As DataGridViewRow = DGZip.Rows(DGZip.Rows.Add)
                    row.Cells(selAreaCD.Index).Value = rs.Fields("AreaCD").Value
                    row.Cells(selAreaDescription.Index).Value = rs.Fields("AreaName").Value
                    row.Cells(selDistrictCD.Index).Value = rs.Fields("DistrctCD").Value
                    row.Cells(selDistrictDescription.Index).Value = rs.Fields("DistrctName").Value
                    row.Cells(selRegCd.Index).Value = rs.Fields("RegCD").Value
                    row.Cells(selRegionDesc.Index).Value = rs.Fields("RegName").Value
                    row.Cells(selZipCode.Index).Value = rs.Fields("ZipCD").Value
                    row.Cells(selZipID.Index).Value = -1
                    rs.MoveNext()
                Next
            End If
        Else
            DGZip.Rows.Clear()
        End If

    End Sub

    Private Sub GridListing_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick

    End Sub

    Private Sub cmbArea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbArea.SelectedIndexChanged

    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        filter()
    End Sub


    Private Sub filter()
        If cmbfilter.Text <> "" Then
            Dim rs As New ADODB.Recordset
            If cmbfilter.Text = "All" Then
                rs = RsZipCodeMapping()
            ElseIf cmbfilter.Text = "Region Code" Then
                rs = RsZipCodeMapping("RegCD like '%" & txtFilter.Text & "%' ")
            ElseIf cmbfilter.Text = "City/Province Code" Then
                rs = RsZipCodeMapping("DISTRCTCD like '%" & txtFilter.Text & "%' ")
            ElseIf cmbfilter.Text = "Municipality / Location Code" Then
                rs = RsZipCodeMapping("AreaCD like '%" & txtFilter.Text & "%' ")
            ElseIf cmbfilter.Text = "Municipality / Location Name" Then
                rs = RsZipCodeMapping("AreaName like '%" & txtFilter.Text & "%'")
            ElseIf cmbfilter.Text = "ZipCode" Then
                rs = RsZipCodeMapping("ZIPCd like '%" & txtFilter.Text & "%' ")
            End If
            PopulateGridListing(rs)
        End If

    End Sub

    Private Sub PopulateGridListing(ByVal rs As ADODB.Recordset)
        GridListing.Rows.Clear()
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(colAreaCd.Index).Value = rs.Fields("AreaCD").Value
                row.Cells(colAreaDesc.Index).Value = rs.Fields("AreaName").Value
                row.Cells(colCoverageCD.Index).Value = rs.Fields("AreaCovrg").Value
                row.Cells(colCoverageName.Index).Value = rs.Fields("AreaCovrgDescription").Value
                row.Cells(colDistrictCd.Index).Value = rs.Fields("DistrctCd").Value
                row.Cells(colDistrictDesc.Index).Value = rs.Fields("DistrictName").Value
                row.Cells(colRegCd.Index).Value = rs.Fields("RegCd").Value
                row.Cells(colRegDesc.Index).Value = rs.Fields("RegName").Value
                row.Cells(colZipCode.Index).Value = rs.Fields("ZipCD").Value
                row.Cells(colZipMappingID.Index).Value = rs.Fields("ZipCodeTerritoryMappingID").Value
                row.Cells(colStartDate.Index).Value = rs.Fields("EffectivityStartDate").Value
                row.Cells(colEndDate.Index).Value = rs.Fields("EffectivityEndDate").Value
                rs.MoveNext()
            Next
        End If
    End Sub



    Private Sub btnFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnFilter.KeyPress
        If AscW(e.KeyChar) = 13 Then
            filter()
        End If
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If AscW(e.KeyChar) = 13 Then
            filter()
        End If
    End Sub
End Class



