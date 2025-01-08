Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class UCAdministrationSalesMatrix
    Private Operation As String = ""
    Private table As New DataTable
    Private m_IsTerritoryCode As Integer = -1
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False

    Private Sub PopulateComboBox()
        Dim rs As New ADODB.Recordset
        cmbDivision.Items.Clear()
        cmbregion.Items.Clear()
        cmbdistrict.Items.Clear()
        cmbRep.Items.Clear()
        cmbrepDesc.Items.Clear()
        cmbTeam.Items.Clear()
        cmbcoverage.Items.Clear()
        cmbCoverageName.Items.Clear()
        cmbConfigtype.Items.Clear()

        cmbDivision.Text = ""
        cmbregion.Text = ""
        cmbdistrict.Text = ""
        cmbRep.Text = ""
        cmbrepDesc.Text = ""
        cmbTeam.Text = ""
        cmbcoverage.Text = ""
        cmbCoverageName.Text = ""
        txtConfigtypename.Text = ""
        'for the region
        rs.Open("SELECT * FROM STREGION WHERE DLTFLG = 0  and isactive = 1 ORDER BY STREGCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbregion.Items.Add(rs.Fields("stregcd").Value)
                rs.MoveNext()
            Next
        End If

        ''populate the Team  
        'rs.Open("select * from stteam where dltflg = 0 order by stteamcd, stteamname", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        'If rs.RecordCount > 0 Then
        '    For i As Integer = 1 To rs.RecordCount
        '        cmbTeam.Items.Add(rs.Fields("stteamcd").Value)
        '        rs.MoveNext()
        '    Next
        'End If

        'for the itemdivision
        rs = New ADODB.Recordset
        rs.Open("select * from itemdivision where dltflg = 0 and isactive = 1  order by itmdivcd", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbDivision.Items.Add(rs.Fields("itmdivcd").Value)

                ' ''for the itemGroup
                ''Dim rsItemGroup As New ADODB.Recordset
                ''rsItemGroup = New ADODB.Recordset
                ''rsItemGroup.Open("select distinct(Itemgrpcd) from item where itemdivcd = '" & rs.Fields("itmdivcd").Value & "' and itemdel = '" & "0" & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                ''If rsItemGroup.RecordCount > 0 Then
                ''    'For j As Integer = 1 To rsItemGroup.RecordCount
                ''    cmbItemGroup.Items.Add(rsItemGroup.Fields("ITEMGRPCD").Value)
                ''    rsItemGroup.MoveNext()
                ''    'Next
                ''End If

                rs.MoveNext()
            Next
        End If
        
        'for the covearge  
        rs = New ADODB.Recordset
        rs.Open("select * from stareacoverage where dltflg = 0 and isactive = 1 order by stacovcd", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbcoverage.Items.Add(rs.Fields("stacovcd").Value)
                cmbCoverageName.Items.Add(rs.Fields("Stacovname").Value)

                rs.MoveNext()
            Next
        End If

        'for the sales agent
        rs = New ADODB.Recordset
        rs.Open("select * from MedicalRep where dltflg = 0 and isactive = 1 order by slsmncd", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbRep.Items.Add(rs.Fields("slsmncd").Value)
                cmbrepDesc.Items.Add(rs.Fields("slsmnname").Value)

                rs.MoveNext()
            Next
        End If
        table = GetRecords("Select * from ConfigurationType")
        For i As Integer = 0 To table.Rows.Count - 1
            cmbConfigtype.Items.Add(table.Rows(i)("ConfigtypeCode"))
        Next

    End Sub

    Private Sub AdministrationSalesMatrix_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearForm()
        PopulateComboBox()
        ApplyGridTheme(GridListing)
        OpenListing()
        Operation = "Add"
        SetupOperation(True)
        m_Err.Clear()
    End Sub


    Private Sub SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTeam.SelectedValueChanged, cmbcoverage.SelectedValueChanged, cmbDivision.SelectedValueChanged, cmbRep.SelectedValueChanged, cmbrepDesc.SelectedValueChanged, _
        cmbregion.SelectedValueChanged, cmbdistrict.SelectedValueChanged, cmbItemGroup.SelectedValueChanged, cmbConfigtype.SelectedIndexChanged
        If sender Is cmbcoverage Then
            Dim rs As New ADODB.Recordset
            m_IsTerritoryCode = 1
            rs.Open("select * from stareacoverage where dltflg = 0 and stacovcd = '" & cmbcoverage.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                txtCoverageName.Text = rs.Fields("stacovname").Value
                cmbCoverageName.Text = rs.Fields("stacovname").Value
                txtTerritory.Text = cmbcoverage.Text
            End If

        ElseIf sender Is cmbregion Then
            cmbdistrict.Items.Clear()
            cmbTeam.Items.Clear()

            cmbdistrict.Text = ""
            cmbTeam.Text = ""

            txtDistrict.Text = ""
            txtTeamDescription.Text = ""

            Dim rs As New ADODB.Recordset
            rs.Open("SELECT * FROM STREGION WHERE DLTFLG = 0 AND STREGCD = '" & cmbregion.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                txtRegion.Text = rs.Fields("stregname").Value

            End If
            rs = New ADODB.Recordset
            rs.Open("SELECT * FROM STDISTRICTCreation WHERE DLTFLG = 0 AND  IsActive = 1  AND DIVCD  = '" & cmbregion.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                For i As Integer = 1 To rs.RecordCount
                    cmbdistrict.Items.Add(rs.Fields("DISTCD").Value)
                    rs.MoveNext()
                Next
            End If

        ElseIf sender Is cmbdistrict Then
            cmbTeam.Items.Clear()
            cmbTeam.Text = ""
            txtTeamDescription.Text = ""

            Dim rs As New ADODB.Recordset
            rs.Open("SELECT * FROM STDISTRICTCreation WHERE DLTFLG = 0  AND DivCd= '" & cmbregion.Text & "' AND DistCd = '" & cmbdistrict.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                txtDistrict.Text = rs.Fields("DistName").Value
            End If


            rs = New ADODB.Recordset
            rs.Open("SELECT * FROM STTEAM WHERE DLTFLG = 0 and STREGCD = '" & cmbregion.Text & "' AND STDISTRCTCD = '" & cmbdistrict.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                For i As Integer = 1 To rs.RecordCount
                    cmbTeam.Items.Add(rs.Fields("StTeamCd").Value)
                    rs.MoveNext()
                Next
            End If
        ElseIf sender Is cmbDivision Then
            Dim rs As New ADODB.Recordset
            rs.Open("select * from ItemDivision where dltflg = 0  and itmdivcd = '" & cmbDivision.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rs.RecordCount > 0 Then
                txtDivision.Text = rs.Fields("ItmDivName").Value
            End If

            Dim rsItemGroup As New ADODB.Recordset
            rsItemGroup = New ADODB.Recordset
            rsItemGroup.Open("select distinct(Itemgrpcd) from item where itemdivcd = '" & rs.Fields("itmdivcd").Value & "' and itemdel = '" & "0" & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            cmbItemGroup.Items.Clear()
            If rsItemGroup.RecordCount > 0 Then
                For j As Integer = 1 To rsItemGroup.RecordCount
                    cmbItemGroup.Items.Add(rsItemGroup.Fields("ITEMGRPCD").Value)
                    rsItemGroup.MoveNext()
                Next
            End If


        ElseIf sender Is cmbItemGroup Then

            Dim rs As New ADODB.Recordset
            rs.Open("select * from ItemGroup where itemgroupcd = '" & cmbItemGroup.Text & "' and itemgroupdel = '" & "0" & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                txtItemGroup.Text = rs.Fields("ITEMGROUPName").Value
            End If

        ElseIf sender Is cmbRep Then
            Dim rs As New ADODB.Recordset
            rs.Open("select * from medicalRep where dltflg = 0 and slsmncd = '" & cmbRep.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                txtREp.Text = rs.Fields("slsmnName").Value
                cmbrepDesc.Text = rs.Fields("slsmnname").Value
            End If

        ElseIf sender Is cmbrepDesc Then
            Dim rs As New ADODB.Recordset
            rs = MedRep("slsmnName = '" & cmbrepDesc.Text & "' ")
            If rs.RecordCount > 0 Then
                cmbRep.Text = rs.Fields("slsmncd").Value
            End If
        ElseIf sender Is cmbTeam Then
            Dim rs As New ADODB.Recordset
            rs.Open("select * from stteam where stteamcd = '" & cmbTeam.Text & "' and dltflg = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                txtTeamDescription.Text = rs.Fields("stteamName").Value

                'txtDistrict.Text = rs.Fields("StDistrctname").Value
                'txtRegion.Text = rs.Fields("STRegname").Value
            End If
        ElseIf sender Is cmbConfigtype Then
            table = GetRecords("Select ConfigtypeName from Configurationtype where ConfigtypeCode = '" & cmbConfigtype.Text & "'")
            For i As Integer = 0 To table.Rows.Count - 1
                txtConfigtypename.Text = table.Rows(i)("ConfigtypeName")
            Next
        End If
        m_IsTerritoryCode = -1
    End Sub

    Private Sub ClearForm()
        m_Err.Clear()
        'PopulateComboBox()
        txtREp.Tag = -1
        txtTerritory.Text = ""
        cmbcoverage.Text = ""
        txtCoverageName.Text = ""
        cmbRep.Text = ""
        cmbregion.Text = ""
        cmbdistrict.Text = ""
        cmbTeam.Text = ""
        cmbDivision.Text = ""
        cmbItemGroup.Text = ""
        txtItemGroup.Text = ""
        txtCoverageName.Text = ""
        txtDistrict.Text = ""
        txtDivision.Text = ""
        txtFilter.Text = ""
        txtRegion.Text = ""
        txtREp.Text = ""
        txtTeamDescription.Text = ""
        cmbCoverageName.Text = ""
        cmbrepDesc.Text = ""
        cmbConfigtype.Text = ""
        txtConfigtypename.Text = ""

    End Sub
    Private Sub SetupOperation(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation
    End Sub


    Private Sub buttonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click, btnEdit.Click, btnDelete.Click, btnSave.Click, btnClose.Click
        If sender Is btnAdd Then
            Operation = "Add"
            SetupOperation(True)
            ClearForm()

        ElseIf sender Is btnEdit Then
            Operation = "Edit"
            SetupOperation(True)
        ElseIf sender Is btnDelete Then
            If CheckRecordExist() = True Then
                Operation = ""
                SetupOperation(False)
                DeleteRecord()
                DeleteSuccess()
            Else
                RecordInexist()
            End If
        ElseIf sender Is btnSave Then
            If Operation = "Add" Then
                If validFields() <> True Then
                    InvalidValues()
                ElseIf CheckRecordExist() = True Then
                    RecordExists()
                Else
                    SaveRecord()
                    Operation = ""
                    SetupOperation(False)
                    OpenListing()
                    SaveSuccess()
                    ClearForm()
                End If
            ElseIf Operation = "Edit" Then
                If validFields() <> True Then
                    InvalidValues()
                Else
                    If txtREp.Tag > 0 Then
                        UPDATERecord()
                        Operation = ""
                        SetupOperation(False)
                        OpenListing()
                        SaveSuccess()
                        ClearForm()
                    End If
                    End If
            End If
        ElseIf sender Is btnClose Then

            On Error Resume Next
            Dim m_TabPage As TabPage = Me.Parent
            CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
            Me.Dispose()
        End If
    End Sub

    Private Function CheckRecordExist() As Boolean
        Dim rs As New ADODB.Recordset
        'rs.Open("select * from SalesMatrix where dltflg = 0 and stitmdivcd = '" & cmbDivision.Text & "' and stterrcd = '" & txtTerritory.Text & "'  AND stslsmncd = '" & cmbRep.Text & "'  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        rs.Open("select * from salesmatrix where dltflg = 0 and salesmatrixid = " & txtREp.Tag, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Function validFields() As Boolean
        m_Err.Clear()
        m_HasError = False
        If CDate(dtStart.Value.ToShortDateString) > CDate(dtEnd.Value.ToShortDateString) Then
            m_Err.SetError(dtStart, "Date From Should not be greater than date to.")
            m_HasError = True
        End If
        If m_HasError Then
            Return False
        End If
        If txtCoverageName.Text = "" Then
            Return False
        ElseIf txtDistrict.Text = "" Then
            Return False
        ElseIf txtDivision.Text = "" Then
            Return False
        ElseIf txtRegion.Text = "" Then
            Return False
        ElseIf txtREp.Text = "" Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function SaveRecord() As Boolean
        SPMSConn.Execute("EXEC uspSalesMatrix @ACtion = 'ADD', @DLTFLG = 0, @STREGCD = '" & cmbregion.Text & "', @STDISTRCTCD = '" & cmbdistrict.Text & "', @STTEAMCD = '" & cmbTeam.Text & "', @STITMDIVCD = '" & cmbDivision.Text & "', @STTERRCD = '" & txtTerritory.Text & "', @STACOVCD = '" & cmbcoverage.Text & "', @STACOVNAME = '" & txtCoverageName.Text & "', @STSLSMNCD = '" & cmbRep.Text & "', @STSLSMNNAME = '" & txtREp.Text & "', @CRTDATE = '" & Now & "', @CRTU = '', @UPDD = '" & Now & "', @UPDU = '' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "',@ITEMGRPCD = '" & cmbItemGroup.Text & "',@ConfigtypeCode = '" & cmbConfigtype.Text & "', @IsActive = " & chkIsActive.Checked & "")
        Return True
    End Function

    Private Function UPDATERecord() As Boolean
        SPMSConn.Execute("EXEC uspSalesMatrix @Action = 'UPDATE', @DLTFLG = 0, @STREGCD = '" & cmbregion.Text & "', @STDISTRCTCD = '" & cmbdistrict.Text & "', @STTEAMCD = '" & cmbTeam.Text & "', @STITMDIVCD = '" & cmbDivision.Text & "', @STTERRCD = '" & txtTerritory.Text & "', @STACOVCD = '" & cmbcoverage.Text & "', @STACOVNAME = '" & txtCoverageName.Text & "', @STSLSMNCD = '" & cmbRep.Text & "', @STSLSMNNAME = '" & txtREp.Text & "', @CRTDATE = '" & Now & "', @CRTU = '', @UPDD = '" & Now & "', @UPDU = '' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "',@ConfigtypeCode = '" & cmbConfigtype.Text & "',@ITEMGRPCD = '" & cmbItemGroup.Text & "' , @IsActive = " & chkIsActive.Checked & ", @SMID = " & txtREp.Tag)
        Return True
    End Function

    Private Function DeleteRecord() As Boolean
        SPMSConn.Execute("EXEC uspSalesMatrix @Action = 'UPDATE', @DLTFLG = 1, @STREGCD = '" & cmbregion.Text & "', @STDISTRCTCD = '" & cmbdistrict.Text & "', @STTEAMCD = '" & cmbTeam.Text & "', @STITMDIVCD = '" & cmbDivision.Text & "', @STTERRCD = '" & txtTerritory.Text & "', @STACOVCD = '" & cmbcoverage.Text & "', @STACOVNAME = '" & txtCoverageName.Text & "', @STSLSMNCD = '" & cmbRep.Text & "', @STSLSMNNAME = '" & txtREp.Text & "', @CRTDATE = '" & Now & "', @CRTU = '', @UPDD = '" & Now & "', @UPDU = '' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' , @IsActive = " & chkIsActive.Checked & " , @SMID = " & txtREp.Tag)
        Return True
    End Function

    Private Sub OpenListing()
        Dim rs As New ADODB.Recordset
        rs.Open("select * from salesmatrix where dltflg = 0 and Configtypecode = 'Y2019' order by stTeamCd, stItmDivCd, StTerrCD, Stacovcd", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        GridListing.Rows.Clear()
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(colmrid.Index).Value = rs.Fields("SalesMatrixID").Value
                row.Cells(colTerritory.Index).Value = rs.Fields("stTerrCd").Value
                row.Cells(colTerritoryName.Index).Value = rs.Fields("stacovname").Value
                row.Cells(colItemDivision.Index).Value = rs.Fields("stitmdivcd").Value
                Dim rsItemDivName As New ADODB.Recordset
                If rsItemDivName.State = 1 Then rsItemDivName.Close()
                rsItemDivName.Open("Select ITMDIVNAME from itemdivision WHERE ITMDIVCD = '" & rs.Fields("stitmdivcd").Value & "' and dltflg = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                'row.Cells(colItemDivisionName.Index).Value = rsItemDivName.Fields("ITMDIVNAME").Value
                row.Cells(colMR.Index).Value = rs.Fields("stslsmncd").Value
                row.Cells(colMRName.Index).Value = rs.Fields("stslsmnname").Value
                If rsItemDivName.RecordCount > 0 Then
                    row.Cells(colItemDivisionName.Index).Value = rsItemDivName.Fields("ITMDIVNAME").Value
                Else
                    row.Cells(colItemDivisionName.Index).Value = 0
                End If
                row.Cells(ColConfigTypeCode.Index).Value = rs.Fields("ConfigtypeCode").Value
                row.Cells(colStartDate.Index).Value = rs.Fields("effectivityStartDate").Value
                row.Cells(colEndDate.Index).Value = rs.Fields("EffectivityEndDate").Value
                row.Cells(colStatus.Index).Value = IIf(rs.Fields("IsActive").Value = True, "Active", "Inactive")
                rs.MoveNext()
            Next
        End If
    End Sub



    Private Sub GridListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Dim row As DataGridViewRow = GridListing.Rows(e.RowIndex)
        m_Err.Clear()
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rs.Open("select * from salesmatrix where   stTerrcd = '" & row.Cells(colTerritory.Index).Value & "' and stacovname = '" & row.Cells(colTerritoryName.Index).Value & "' and stitmdivcd = '" & row.Cells(colItemDivision.Index).Value & "' and stslsmncd = '" & row.Cells(colMR.Index).Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)\
        rs.Open("select * from salesmatrix where  SalesMatrixID = '" & row.Cells(colmrid.Index).Value & "' And DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            chkIsActive.Checked = rs.Fields("IsActive").Value
            cmbregion.SelectedItem = rs.Fields("STREGCD").Value
            txtREp.Tag = rs.Fields("SalesMatrixID").Value
            Dim rsregion As New ADODB.Recordset
            rsregion.Open("SELECT * FROM STREGION WHERE DLTFLG = 0 AND STREGCD = '" & rs.Fields("stregcd").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rsregion.RecordCount > 0 Then
                txtRegion.Text = rsregion.Fields("STREGNAME").Value

            End If


            cmbdistrict.SelectedItem = rs.Fields("STDISTRCTCD").Value

            Dim rsDistrict = New ADODB.Recordset
            rsDistrict.Open("SELECT * FROM STDISTRICTCreation  WHERE DLTFLG = 0 AND DistCd  = '" & rs.Fields("stdistrctcd").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rsDistrict.RecordCount > 0 Then

                txtDistrict.Text = rsDistrict.Fields("DistName").Value

            End If
            cmbcoverage.SelectedItem = rs.Fields("STACOVCD").Value
            Dim rsCoverage = New ADODB.Recordset
            rsCoverage.Open("SELECT * FROM stareacoverage WHERE DLTFLG = 0 AND stacovcd  = '" & rs.Fields("stacovcd").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rsCoverage.RecordCount > 0 Then

                txtCoverageName.Text = rsCoverage.Fields("STACOVNAME").Value

            End If


            cmbDivision.SelectedItem = rs.Fields("STITMDIVCD").Value
            Dim rsItemDiv = New ADODB.Recordset
            rsItemDiv.Open("SELECT * FROM stItemDivision WHERE DLTFLG = 0 AND STITEMDIVCD  = '" & rs.Fields("stitmdivcd").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rsItemDiv.RecordCount > 0 Then

                txtDivision.Text = rsItemDiv.Fields("STITEMDIVNAME").Value

            End If
            cmbConfigtype.SelectedItem = rs.Fields("ConfigtypeCode").Value
            table = GetRecords("Select * from Configurationtype where ConfigtypeCode = '" & cmbConfigtype.Text & "'")
            For i As Integer = 0 To table.Rows.Count - 1
                txtConfigtypename.Text = table.Rows(i)("ConfigtypeName")
            Next

            cmbRep.SelectedItem = rs.Fields("STSLSMNCD").Value
            txtREp.Text = rs.Fields("STSLSMNNAME").Value
            'Dim rsMR = New ADODB.Recordset
            'rsMR.Open("SELECT * FROM MEDICALREP WHERE DLTFLG = 0 AND SLSMNCD  = '" & rs.Fields("stslsmncd").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            'If rsMR.RecordCount > 0 Then

            '    txtREp.Text = rsMR.Fields("SLSMNNAME").Value

            'End If


            cmbTeam.SelectedItem = rs.Fields("STTEAMCD").Value

            Dim rsTeam = New ADODB.Recordset
            rsTeam.Open("SELECT * FROM STTEAM WHERE DLTFLG = 0 AND STTEAMCD  = '" & rs.Fields("STTEAMCD").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rsTeam.RecordCount > 0 Then

                txtTeamDescription.Text = rsTeam.Fields("STTEAMNAME").Value

            End If

            txtTerritory.Text = rs.Fields("STTERRCD").Value

            dtStart.Value = rs.Fields("effectivityStartDate").Value
            dtEnd.Value = rs.Fields("EffectivityEndDate").Value
            cmbItemGroup.SelectedItem = rs.Fields("ITEMGRPCD").Value
        End If

        Operation = ""
        SetupOperation(False)

        MainTab.SelectTab(0)

    End Sub

    Private Sub cmbTeam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTeam.SelectedIndexChanged

    End Sub

    Private Sub cmbdistrict_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdistrict.SelectedIndexChanged

    End Sub

    Private Sub cmbregion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbregion.SelectedIndexChanged

    End Sub

    Private Sub cmbDivision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDivision.SelectedIndexChanged

    End Sub

    Private Sub txtRegion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRegion.TextChanged

    End Sub

    Private Sub txtCoverageName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoverageName.TextChanged

    End Sub

    Private Sub txtDivision_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDivision.TextChanged

    End Sub

    Private Sub txtTeamDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTeamDescription.TextChanged

    End Sub

    Private Sub txtDistrict_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDistrict.TextChanged

    End Sub

    Private Sub ItemDivision_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemDivision.Enter

    End Sub
    Private Sub Filter()

        Dim field As String
        If cmbfilter.Text = String.Empty Then Exit Sub
        If cmbfilter.Text = "Territory Code" Then
            field = "STTERRCD"
        ElseIf cmbfilter.Text = "Territory Name" Then
            field = "STACOVNAME"
        ElseIf cmbfilter.Text = "ItemDivision" Then
            field = "STITMDIVCD"
        ElseIf cmbfilter.Text = "Employee Code" Then
            field = "STSLSMNCD"
        ElseIf cmbfilter.Text = "MR Name" Then
            field = "STSLSMNNAME"
        Else
            field = ""
        End If
        Dim GridRs As New ADODB.Recordset
        GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        If cmbfilter.Text = "All" Then
            GridRs.Open("SELECT * FROM SALESMATRIX WHERE DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Else
            GridRs.Open("SELECT * FROM SALESMATRIX WHERE " & field & " like '%" & HandleSingleQuoteInSql(txtFilter.Text) & "%' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        End If
        If GridRs.RecordCount > 0 Then
            GridListing.Rows.Clear()
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(colmrid.Index).Value = GridRs.Fields("SalesMatrixID").Value
                row.Cells(colTerritory.Index).Value = GridRs.Fields("stTerrCd").Value
                row.Cells(colTerritoryName.Index).Value = GridRs.Fields("stacovname").Value
                row.Cells(colItemDivision.Index).Value = GridRs.Fields("stitmdivcd").Value
                Dim rsItemDivName As New ADODB.Recordset
                If rsItemDivName.State = 1 Then rsItemDivName.Close()
                rsItemDivName.Open("Select ITMDIVNAME from itemdivision WHERE ITMDIVCD = '" & GridRs.Fields("stitmdivcd").Value & "' and dltflg = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                row.Cells(colItemDivisionName.Index).Value = rsItemDivName.Fields("ITMDIVNAME").Value
                row.Cells(colMR.Index).Value = GridRs.Fields("stslsmncd").Value
                row.Cells(colStartDate.Index).Value = GridRs.Fields("effectivityStartDate").Value
                row.Cells(colEndDate.Index).Value = GridRs.Fields("EffectivityEndDate").Value
                row.Cells(colStatus.Index).Value = IIf(GridRs.Fields("IsActive").Value = True, "Active", "Inactive")
                Dim rsMR As New ADODB.Recordset
                If rsMR.State = 1 Then rsMR.Close()
                rsMR.Open("Select STSLSMNNAME FROM STMEDICALREP WHERE STSLSMNCD = '" & GridRs.Fields("stslsmncd").Value & "' and dltflg = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rsMR.RecordCount <> 0 Then
                    row.Cells(colMRName.Index).Value = rsMR.Fields("STSLSMNNAME").Value
                End If
                GridRs.MoveNext()
            Next
        End If
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Filter()
    End Sub

    Private Function MedRep(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset

        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT * FROM MEDICALREP WHERE DLTFLG = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs
    End Function

    Private Function AreaCoverage(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT  * FROM STAreaCOVERAGE WHERE DLTFLG = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs
    End Function


    Private Sub cmbRep_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRep.SelectedIndexChanged

    End Sub

    Private Sub cmbrepDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbrepDesc.SelectedIndexChanged

    End Sub

    Private Sub cmbcoverage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcoverage.SelectedIndexChanged

    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Chr(13) Then
            Filter()
        End If
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub

    Private Sub GridListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick

    End Sub

    Private Sub cmbCoverageName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCoverageName.SelectedIndexChanged

    End Sub

    Private Sub cmbCoverageName_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCoverageName.SelectedValueChanged
        If sender Is cmbCoverageName Then
            If m_IsTerritoryCode = 1 Then Exit Sub
            Dim rs As New ADODB.Recordset
            rs = AreaCoverage("stacovname = '" & cmbCoverageName.Text & "' ")
            If rs.RecordCount > 0 Then
                cmbcoverage.Text = rs.Fields("StacovCD").Value
                txtTerritory.Text = rs.Fields("StacovCD").Value
            End If
        End If
    End Sub

    Private Sub UCAdministrationSalesMatrix_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move

    End Sub
End Class