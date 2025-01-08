Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule

Public Class ucTransactionSalesSharing
    Private Gridrs As New ADODB.Recordset
    Private Operation As String = ""
    Private m_ForDeletes As New ForDeletesCollection

    Dim m_HasError As Boolean = False
    Private PrevSharing As Double = 0
    Private m_Err As New ErrorProvider

    Private Sub PopulateComboBoxes()
        Dim rs As New ADODB.Recordset
        'for the year
        cmbYear.Items.Clear()
        cmbCompany.Items.Clear()
        cmbCustomerCode.Items.Clear()
        cmbitemdiv.Items.Clear()
        For i As Integer = Year(Now) - 5 To Year(Now)
            cmbYear.Items.Add(i)
        Next

        'for the Company
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT DISTINCT DISTCOMID FROM DISTRIBUTOR WHERE DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbCompany.Items.Add(rs.Fields("DISTCOMID").Value)
                rs.MoveNext()
            Next
        End If

        'for the itemgroup
        rs = New ADODB.Recordset
        rs.Open("select distinct ItmDivCd from Itemdivision where DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbitemdiv.Items.Add(rs.Fields("itmdivcd").Value)
                rs.MoveNext()
            Next
        End If
    End Sub

    Private Sub clearform()
        cmbCompany.Text = ""
        cmbCustomerCode.Text = ""
        cmbfilter.Text = ""
        cmbMonth.Text = ""
        cmbYear.Text = ""
        cmbMonth.SelectedIndex = -1

        PopulateComboBoxes()
        txtCustomerName.Text = ""
        txtcomname.Text = ""
        dgDetail.Rows.Clear()
    End Sub

    Private Sub SetupOperation(ByVal hasOperation As Boolean)
        btnAdd.Enabled = Not hasOperation
        btnEdit.Enabled = Not hasOperation
        btnDelete.Enabled = Not hasOperation
        btnSave.Enabled = hasOperation
    End Sub

    Private Function CheckRecordExists(ByVal comid As String, ByVal CustomerCd As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal CustomerShipToCode As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        rs.Open("select * from salesterritorymapping where CDACD = '" & CustomerShipToCode & "' AND  comid = '" & comid & "' and cuscd = '" & CustomerCd & "' and EffectivityStartDate = '" & StartDate & "' and EffectivityEndDate = '" & EndDate & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function ValidFields() As Boolean
        Dim totalcount As Double = 0

        If CDate(dtFrom.Value.ToShortDateString) > CDate(dtTo.Value.ToShortDateString) Then
            ShowExclamation("Effectivity Date From should not be greater than the effectivity Date To", "Save")
            Return False
        End If

        If cmbCompany.Text = "" Then
            Return False
            'ElseIf cmbCustomerCode.Text = "" Then
            '    Return False
            'ElseIf cmbMonth.Text = "" Then
            '    Return False
            'ElseIf cmbYear.Text = "" Then
            '    Return False
        ElseIf dgDetail.Rows.Count = 0 Then
            Return False
            'Else
            '    For i As Integer = 0 To dgDetail.Rows.Count - 1
            '        Dim row As DataGridViewRow = dgDetail.Rows(i)
            '        totalcount = totalcount + row.Cells(colSharing.Index).Value

            '        If row.Cells(colTerritoryName.Index).Value = "" Then
            '            Return False
            '        End If
            '    Next

            '    If totalcount = GetDivisionDistinctCount() Then
            '        Return True
            '    Else
            '        Return False
            '    End If

            '    Return True
        End If
        Return True
    End Function

    Private Function ValidateData() As Boolean
        m_HasError = False
        m_Err.Clear()
        For m As Integer = 0 To dgDetail.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetail.Rows(m)
            If row.Cells(colSharing.Index).Value = 0 Then
                row.Cells(colSharing.Index).Style.BackColor = Color.LightPink
                row.Cells(colSharing.Index).ToolTipText = "Sharing should not be zero"
                m_HasError = True
            Else
                row.Cells(colSharing.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                row.Cells(colSharing.Index).ToolTipText = String.Empty
            End If
        Next


        If CDate(dtFrom.Value.ToShortDateString) > CDate(dtTo.Value.ToShortDateString) Then
            m_Err.SetError(dtFrom, "Date From Should not be greater than date to.")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function


    Private Sub OpenListing()
        If Gridrs.State = 1 Then Gridrs.Close()
        Gridrs.Open("select DISTINCT COMID, CUSCD, CDACD,  CDANAME, EFFECTIVITYSTARTDATE, EFFECTIVITYENDDATE From SALESTERRITORYMAPPING WHERE DELFLAG = 0 ORDER BY COMID, CUSCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        GridListing.Rows.Clear()
        If Gridrs.RecordCount > 0 Then
            For i As Integer = 1 To Gridrs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(colComID.Index).Value = Gridrs.Fields("COMID").Value
                row.Cells(colCustomerCode.Index).Value = Gridrs.Fields("CUSCD").Value
                row.Cells(colShipToCode.Index).Value = Gridrs.Fields("CDACD").Value
                row.Cells(colCustomerName.Index).Value = Gridrs.Fields("CDANAME").Value
                row.Cells(colCutMo.Index).Value = CDate(Gridrs.Fields("EFFECTIVITYSTARTDATE").Value).ToShortDateString
                row.Cells(colCutYear.Index).Value = CDate(Gridrs.Fields("EFFECTIVITYENDDATE").Value).ToShortDateString

                Gridrs.MoveNext()
            Next
        End If
    End Sub

    Private Sub ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click, btnEdit.Click, btnDelete.Click, btnSave.Click, btnClose.Click
        If sender Is btnAdd Then
            SetupOperation(True)
            Operation = "Add"
            clearform()
            cmbCompany.Focus()
        ElseIf sender Is btnEdit Then
            SetupOperation(True)
            Operation = "Edit"
            cmbCompany.Focus()
        ElseIf sender Is btnDelete Then
            If CheckRecordExists(cmbCompany.Text, txtCustomerCode.Tag, dtFrom.Value.ToShortDateString, dtTo.Value.ToShortDateString, txtCustomerCode.Text) = True Then
                DeleteRecord()
                VDialog.Show("Successfull sales Delete", "Delete",MessageBoxButtons.OK,MessageBoxIcon.Information  )
                Operation = ""
                SetupOperation(False)
                clearform()
                OpenListing()
            Else
                VDialog.Show("Record Does not Exist", "Record not Existing", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        ElseIf sender Is btnSave Then
            If ValidFields() = True Then
                If ValidateData() Then
                    If Operation = "Add" Then
                        If CheckRecordExists(cmbCompany.Text, txtCustomerCode.Tag, dtFrom.Value.ToShortDateString, dtTo.Value.ToShortDateString, txtCustomerCode.Text) = True Then
                            VDialog.Show("Record Already Exists", "Record Exists", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        Else
                            SaveRecord()
                            Operation = ""
                            SetupOperation(False)
                            OpenListing()
                            VDialog.Show("Successfull SalesSharing Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    ElseIf Operation = "Edit" Then
                        If CheckRecordExists(cmbCompany.Text, txtCustomerCode.Tag, dtFrom.Value.ToShortDateString, dtTo.Value.ToShortDateString, txtCustomerCode.Text) = True Then
                            UpdateRecord()
                            Operation = ""
                            SetupOperation(False)
                            OpenListing()
                            VDialog.Show("Successfull SalesSharing Update", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            VDialog.Show("Record Already Exists", "Record Exists", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        End If

                    End If
                Else
                    VDialog.Show("Error Exist . Kindly check details", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                InvalidValues()
            End If
            ElseIf sender Is btnClose Then

                On Error Resume Next
                Dim m_TabPage As TabPage = Me.Parent
                CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
                Me.Dispose()
            End If

    End Sub


    Private Sub TransactionSalesSharing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PopulateComboBoxes()
        ApplyGridTheme(GridListing)
        ApplyGridTheme(dgDetail)
        OpenListing()
        Operation = "Add"
        SetupOperation(True)
        m_Err.Clear()

        SPMSConn.CommandTimeout = 0
        SPMSConn.Execute("EXEC USPUPDATECUSTOMERSHARINGTAG")

        ' SPMSConn.CommandTimeout = 0
        '  SPMSConn.Execute("EXEC UspSyncMappingNames")

        SPMSConn.CommandTimeout = 0
        SPMSConn.Execute("EXEC uspUpdateCustomerMappingStateAreaTerritory")
        'Dim aw()
        'aw = Split("bords-fast", "-")

        'For i As Integer = 0 To 1
        '    ShowInformation(aw(i), "")
        'Next

    End Sub

    Private Sub ComboIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerCode.SelectedValueChanged, cmbCompany.SelectedValueChanged
        If sender Is cmbCustomerCode Then
            If cmbCompany.Text = "" Then
            ElseIf cmbCustomerCode.Text = "" Then
            Else
                'place the description in the textbox
                Dim rs As New ADODB.Recordset
                rs.Open("SELECT * FROM Customer where Customerdel = 0 and CustomerCd = '" & cmbCustomerCode.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rs.RecordCount > 0 Then
                    txtCustomerName.Text = rs.Fields("CustomerName").Value
                End If


                'populate the grid
                If dgDetail.Rows.Count = 0 Then
                    rs = New ADODB.Recordset
                    rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    rs.Open("select distinct ItmDivCd, itmdivname from Itemdivision where DLTFLG = 0 and itmdivcd <> '999' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    If rs.RecordCount > 0 Then
                        For i As Integer = 1 To rs.RecordCount
                            Dim row As DataGridViewRow = dgDetail.Rows(dgDetail.Rows.Add)

                            'place a link 
                            row.Cells(ColTercode.Index).Value = "Select a Territory"


                            row.Cells(colItemDiv.Index).Value = rs.Fields("itmdivcd").Value
                            row.Cells(colDescription.Index).Value = rs.Fields("itmdivname").Value
                            row.Cells(colSharing.Index).Value = 1
                            rs.MoveNext()
                        Next
                    End If
                End If
            End If
        ElseIf sender Is cmbCompany Then
            If cmbCompany.Text = "" Then
            Else
                'Dim rs As New ADODB.Recordset
                'rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                'rs.Open("select * from Customer where customerdel = 0 and comid = '" & cmbCompany.Text & "' and accntshrd = 1 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                'If rs.RecordCount > 0 Then
                '    cmbCustomerCode.Items.Clear()
                '    For i As Integer = 1 To rs.RecordCount
                '        cmbCustomerCode.Items.Add(rs.Fields("customercd").Value)
                txtcomname.Text = GetCompanyName(cmbCompany.Text)
                'txtCustomerName.Text = ""
                'rs.MoveNext()
                '    Next
            End If

        End If


    End Sub

    Private Function GetCompanyName(ByVal CompanyCode As String) As String
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("select * from distributor where Distcomid = '" & CompanyCode & "' and dltflg = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return rs.Fields("DISTNAME").Value
        Else
            Return ""
        End If
    End Function

    Private Sub btninsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btninsert.Click
        If cmbitemdiv.SelectedIndex = -1 Then
            ShowExclamation("Sales Division is required", "Add Sharing")
            Exit Sub
        ElseIf txtCustomerCode.Text = "" Then
            VDialog.Show("Customer is required", "Add Sharing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim row As DataGridViewRow
        Dim areacovrgcode = GetCustomerShipToTerritory(cmbCompany.Text, txtCustomerCode.Tag, txtCustomerCode.Text)
        If Not areacovrgcode = "" Then
            Dim rs As ADODB.Recordset = GetCustomerShipToTerritoryCode(cmbitemdiv.Text, areacovrgcode)
            If Not rs Is Nothing Then
                Dim ctr As Double = rs.RecordCount
                Dim share As Double = 1 / ctr

                For m As Integer = 0 To rs.RecordCount - 1
                    row = dgDetail.Rows(dgDetail.Rows.Add)
                    row.Cells(ColTercode.Index) = New DataGridViewTextBoxCell
                    row.Cells(ColTercode.Index).Value = rs.Fields("STTERRCD").Value
                    row.Cells(colTerritoryName.Index).Value = rs.Fields("STACOVNAME").Value
                    row.Cells(colMRCode.Index).Value = rs.Fields("STSLSMNCD").Value
                    row.Cells(colRep.Index).Value = rs.Fields("STSLSMNNAME").Value
                    row.Cells(colItemDiv.Index).Value = cmbitemdiv.Text
                    row.Cells(colDescription.Index).Value = GetItemDivisionDescription(cmbitemdiv.Text)
                    row.Cells(colSharing.Index).Value = share
                    rs.MoveNext()
                Next

            End If
        Else
            row = dgDetail.Rows(dgDetail.Rows.Add)
            row.Cells(ColTercode.Index).Value = "Select a Territory"
            row.Cells(colItemDiv.Index).Value = cmbitemdiv.Text
            row.Cells(colDescription.Index).Value = GetItemDivisionDescription(cmbitemdiv.Text)
            row.Cells(colSharing.Index).Value = 1
        End If

    End Sub

    Private Sub dgDetail_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgDetail.CellBeginEdit
        PrevSharing = 0
        If e.RowIndex = -1 Then Exit Sub
        Dim row As DataGridViewRow = dgDetail.Rows(dgDetail.CurrentRow.Index)
        If e.ColumnIndex = colSharing.Index Then
            PrevSharing = row.Cells(colSharing.Index).Value
        End If
    End Sub
    Private Sub dgDetail_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellEndEdit
        If e.RowIndex = -1 Then Exit Sub
        Dim row As DataGridViewRow = dgDetail.Rows(dgDetail.CurrentRow.Index)
        If e.ColumnIndex = colSharing.Index Then

            If IsNumeric(row.Cells(colSharing.Index).Value) Then
                If PrevSharing <> (row.Cells(colSharing.Index).Value) Then
                    'row.Cells(colSharing.Index).Tag = True
                    'row.Cells(colSharing.Index).Style.BackColor = Color.LemonChiffon
                    row.Cells(colSharing.Index).Value = CDec(row.Cells(colSharing.Index).Value).ToString("#,##0.0000")
                Else
                    row.Cells(colSharing.Index).Value = CDec(row.Cells(colSharing.Index).Value).ToString("#,##0.0000")
                End If
            End If
        End If
    End Sub



    Private Sub DgDetailCellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellContentClick
        If e.RowIndex <> -1 Then
            Dim row As DataGridViewRow = dgDetail.Rows(e.RowIndex)
            Select Case e.ColumnIndex
                Case ColTercode.Index
                    Dim Search As New TransactionSalesSharingSearchTerritory
                    Search.PopulateGrid(row.Cells(colItemDiv.Index).Value)
                    Search.ShowDialog(Me)
                    If Search.ReturnTerrCode = "" Then

                    ElseIf Search.ReturnAgentName = "" Then

                    ElseIf Search.ReturnTerrName = "" Then

                    Else
                        row.Cells(ColTercode.Index).Value = Search.ReturnTerrCode
                        row.Cells(colTerritoryName.Index).Value = Search.ReturnTerrName
                        row.Cells(colRep.Index).Value = Search.ReturnAgentName
                        row.Cells(colMRCode.Index).Value = Search.ReturnAgentCode
                    End If
                    'Case colSharing.Index
                    '    If Not PrevSharing = CDbl(row.Cells(colSharing.Index).Value) Then
                    '        row.Cells(colSharing.Index).Tag = True
                    '    End If

            End Select
        End If
    End Sub

    Private Sub SaveRecord()
        For i As Integer = 0 To dgDetail.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetail.Rows(i)
            SPMSConn.Execute("EXEC uspSalesTerritoryMapping @ACTION = 'ADD', @COMID = '" & cmbCompany.Text & "', " & _
                                                                " @CUSCD = '" & txtCustomerCode.Tag & "', @CDACD = '" & txtCustomerCode.Text & "' , @CDANAME= '" & HandleSingleQuoteInSql(txtCustomerName.Text) & "', " & _
                                                                " @itemdivcd = '" & row.Cells(colItemDiv.Index).Value & "', @TERRCD = '" & row.Cells(ColTercode.Index).Value & "', " & _
                                                                " @PERSHR = " & row.Cells(colSharing.Index).Value & ", @EffectivityStartDate = '" & dtFrom.Value.ToShortDateString & "', @EffectivityEndDate = '" & dtTo.Value.ToShortDateString & "', " & _
                                                                " @DELFLAG = 0, @STSLSMNCD = '" & row.Cells(colMRCode.Index).Value & "',  " & _
                                                                " @STSLSMNNAME = '" & HandleSingleQuoteInSql(row.Cells(colRep.Index).Value) & "' , @IsManual = 1 ")
        Next
    End Sub

    Private Sub UpdateRecord()
        For i As Integer = 0 To dgDetail.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetail.Rows(i)
            SPMSConn.Execute("EXEC uspSalesTerritoryMapping @ACTION = 'UPDATE', @COMID = '" & cmbCompany.Text & "', " & _
                                                                 " @CUSCD = '" & txtCustomerCode.Tag & "', @CDACD = '" & txtCustomerCode.Text & "' , @CDANAME= '" & HandleSingleQuoteInSql(txtCustomerName.Text) & "', " & _
                                                                " @itemdivcd = '" & row.Cells(colItemDiv.Index).Value & "', @TERRCD = '" & row.Cells(ColTercode.Index).Value & "', " & _
                                                                " @PERSHR = " & row.Cells(colSharing.Index).Value & ", @EffectivityStartDate = '" & dtFrom.Value.ToShortDateString & "', @EffectivityEndDate = '" & dtTo.Value.ToShortDateString & "', " & _
                                                                " @DELFLAG = 0, @STSLSMNCD = '" & row.Cells(colMRCode.Index).Value & "',  " & _
                                                                " @STSLSMNNAME = '" & HandleSingleQuoteInSql(row.Cells(colRep.Index).Value) & "',  @IsManual = " & IIf(row.Cells(colSharing.Index).Tag = False, IIf(row.Cells(colMRCode.Index).Tag = row.Cells(colSharing.Index).Value, "0", "1"), "1"))
        Next
    End Sub

    Private Sub DeleteRecord()
        For i As Integer = 0 To dgDetail.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetail.Rows(i)
            SPMSConn.Execute("EXEC uspSalesTerritoryMapping @ACTION = 'UPDATE', @COMID = '" & cmbCompany.Text & "', " & _
                                                             " @CUSCD = '" & txtCustomerCode.Tag & "', @CDACD = '" & txtCustomerCode.Text & "' , @CDANAME= '" & HandleSingleQuoteInSql(txtCustomerName.Text) & "', " & _
                                                            " @itemdivcd = '" & row.Cells(colItemDiv.Index).Value & "', @TERRCD = '" & row.Cells(ColTercode.Index).Value & "', " & _
                                                         " @PERSHR = " & row.Cells(colSharing.Index).Value & ", @EffectivityStartDate = '" & dtFrom.Value.ToShortDateString & "', @EffectivityEndDate = '" & dtTo.Value.ToShortDateString & "', " & _
                                                            " @DELFLAG = 1 , @STSLSMNCD = '" & row.Cells(colMRCode.Index).Value & "',  " & _
                                                            " @STSLSMNNAME = '" & HandleSingleQuoteInSql(row.Cells(colRep.Index).Value) & "'")
        Next
    End Sub

    Private Sub DeleteSingleRecord(ByVal row As DataGridViewRow)

        SPMSConn.Execute("EXEC uspSalesTerritoryMapping @ACTION = 'UPDATE', @COMID = '" & cmbCompany.Text & "', " & _
                                                         " @CUSCD = '" & txtCustomerCode.Tag & "', @CDACD = '" & txtCustomerCode.Text & "' , @CDANAME= '" & HandleSingleQuoteInSql(txtCustomerName.Text) & "', " & _
                                                        " @itemdivcd = '" & row.Cells(colItemDiv.Index).Value & "', @TERRCD = '" & row.Cells(ColTercode.Index).Value & "', " & _
                                                     " @PERSHR = " & row.Cells(colSharing.Index).Value & ", @EffectivityStartDate = '" & dtFrom.Value.ToShortDateString & "', @EffectivityEndDate = '" & dtTo.Value.ToShortDateString & "', " & _
                                                        " @DELFLAG = 1 , @STSLSMNCD = '" & row.Cells(colMRCode.Index).Value & "',  " & _
                                                        " @STSLSMNNAME = '" & HandleSingleQuoteInSql(row.Cells(colRep.Index).Value) & "'")
    End Sub


    Private Function GetDivisionDistinctCount() As Integer
        Dim rs As New ADODB.Recordset
        rs.Open("select distinct itmdivcd from itemdivision where dltflg = 0 and itmdivcd <> '999' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs.RecordCount
    End Function

    Private Sub GridListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Dim rs As New ADODB.Recordset
        m_Err.Clear()
        Dim row As DataGridViewRow = GridListing.Rows(e.RowIndex)
        '        rs.Open("select a.comid as [comid], a.cuscd as [cuscd], a.cusnam as [cusnam], a.cdacd, a.cdaname, a.effectivitystartdate, a.effectivityenddate,  a.itemdivcd as [itmdivcd], b.stslsmncd as [stslsmncd], b.stslsmnname as [stslsmnname], a.terrcd as [TerrCD], b.stacovname as [TerrName], a.pershr as [Pershr] , a.cutmo as [cutmo], a.cutyear  as [cutyear]  from salesterritorymapping a, salesmatrix b where b.stterrcd = a.terrcd and b.dltflg = 0 and a.delflag = 0 and b.stitmdivcd = a.itemdivcd and  a.comid = '" & row.Cells(colComID.Index).Value & "' and a.cuscd = '" & row.Cells(colCustomerCode.Index).Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        rs.Open("SELECT a.comid as [comid], a.cuscd as [cuscd], a.cusnam as [cusnam], a.cdacd, a.cdaname, a.effectivitystartdate, a.effectivityenddate, a.itemdivcd as [itmdivcd], b.stslsmncd as [stslsmncd], b.stslsmnname as [stslsmnname], a.terrcd as [TerrCD], b.stacovname as [TerrName], a.pershr as [Pershr] , 	a.cutmo as [cutmo], a.cutyear  as [cutyear] , a.IsManual   FROM SALESTERRITORYMAPPING A, SALESMATRIX B WHERE   A.EFFECTIVITYSTARTDATE = '" & (row.Cells(colCutMo.Index).Value) & "' AND  A.EFFECTIVITYENDDATE  = '" & (row.Cells(colCutYear.Index).Value) & "'  AND  B.EFFECTIVITYSTARTDATE  = '" & (row.Cells(colCutMo.Index).Value) & "' AND  B.EFFECTIVITYENDDATE  ='" & (row.Cells(colCutYear.Index).Value) & "'     AND B.STTERRCD = A.TERRCD AND B.DLTFLG =0 AND A.DELFLaG = 0 AND B.STITMDIVCD = A.ITEMDIVCD AND A.COMID = '" & row.Cells(colComID.Index).Value & "' AND A.DELFLAG = 0 AND A.CUSCD = '" & row.Cells(colCustomerCode.Index).Value & "' AND A.CDACD='" & row.Cells(colShipToCode.Index).Value & "' AND B.STSLSMNCD=A.STSLSMNCD AND B.stterrcd = A.terrcd  Order By A.ItemDivCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Dim itemDivCD As String = ""
        Dim area As String = ""
        If rs.RecordCount > 0 Then
            clearform()
            PopulateComboBoxes()
            Operation = ""
            SetupOperation(False)

            dgDetail.Rows.Clear()

            For i As Integer = 1 To rs.RecordCount
                Dim dgrow As DataGridViewRow = dgDetail.Rows(dgDetail.Rows.Add)

                'If rs.Fields("terrcd").Value = "R404" Then
                ' MsgBox("aw")
                'End If
                dgrow.Cells(colItemDiv.Index).Value = rs.Fields("itmdivcd").Value
                dgrow.Cells(ColTercode.Index) = New DataGridViewTextBoxCell
                dgrow.Cells(ColTercode.Index).Value = rs.Fields("TerrCD").Value
                dgrow.Cells(colTerritoryName.Index).Value = rs.Fields("TerrName").Value
                dgrow.Cells(colRep.Index).Value = rs.Fields("stslsmnname").Value
                dgrow.Cells(colSharing.Index).Value = rs.Fields("pershr").Value
                dgrow.Cells(colSharing.Index).Tag = rs.Fields("IsManual").Value
                dgrow.Cells(colDescription.Index).Value = GetItemDivisionDescription(rs.Fields("itmdivcd").Value)
                dgrow.Cells(colMRCode.Index).Value = rs.Fields("stslsmncd").Value
                dgrow.Cells(colMRCode.Index).Tag = rs.Fields("pershr").Value
                'If itemDivCD = "" Then
                '    If area <> "" Then area &= " , "
                '    area &= "'" & rs.Fields("TerrCD").Value & "'"
                'Else
                '    If itemDivCD <> rs.Fields("itmdivcd").Value Then
                '        Dim areacovrg As String = ""
                '        areacovrg = GetCustomerShipToTerritoryForNew(rs.Fields("comid").Value, rs.Fields("cuscd").Value, rs.Fields("CDACD").Value, area)
                '        If areacovrg <> "" Then
                '            AddNewShare(itemDivCD, areacovrg, row)
                '        End If
                '    Else
                '        If i = rs.RecordCount Then
                '            If area <> "" Then area &= " , "
                '            area &= "'" & rs.Fields("TerrCD").Value & "'"
                '            Dim areacovrg As String = ""
                '            areacovrg = GetCustomerShipToTerritoryForNew(rs.Fields("comid").Value, rs.Fields("cuscd").Value, rs.Fields("CDACD").Value, area)
                '            If areacovrg <> "" Then
                '                AddNewShare(itemDivCD, areacovrg, row)
                '            End If
                '        Else
                '            If area <> "" Then area &= " , "
                '            area &= "'" & rs.Fields("TerrCD").Value & "'"
                '        End If
                '    End If
                'End If
                itemDivCD = rs.Fields("itmdivcd").Value
                rs.MoveNext()
            Next
            rs.MovePrevious()
            cmbCompany.Text = rs.Fields("comid").Value
            txtCustomerCode.Tag = rs.Fields("cuscd").Value
            txtCustomerCode.Text = rs.Fields("CDACD").Value
            txtCustomerName.Text = rs.Fields("CDANAME").Value
            cmbMonth.Text = rs.Fields("cutmo").Value
            cmbYear.Text = rs.Fields("cutyear").Value
            dtFrom.Value = rs.Fields("EFFECTIVITYSTARTDATE").Value
            dtTo.Value = rs.Fields("EFFECTIVITYENDDATE").Value
            MainTab.SelectTab(0)

        End If

    End Sub


    Private Sub AddNewShare(ByVal ItemDivisionCode As String, ByVal AreaCoverage As String, ByVal row As DataGridViewRow)
        Dim rs As ADODB.Recordset = GetCustomerShipToTerritoryCode(ItemDivisionCode, AreaCoverage)
        If Not rs Is Nothing Then

            Dim share As Double = 0
            For m As Integer = 0 To rs.RecordCount - 1
                row = dgDetail.Rows(dgDetail.Rows.Add)
                row.Cells(ColTercode.Index) = New DataGridViewTextBoxCell
                row.Cells(ColTercode.Index).Value = rs.Fields("STTERRCD").Value
                row.Cells(colTerritoryName.Index).Value = rs.Fields("STACOVNAME").Value
                row.Cells(colMRCode.Index).Value = rs.Fields("STSLSMNCD").Value
                row.Cells(colRep.Index).Value = rs.Fields("STSLSMNNAME").Value
                row.Cells(colItemDiv.Index).Value = ItemDivisionCode
                row.Cells(colDescription.Index).Value = GetItemDivisionDescription(ItemDivisionCode)
                row.Cells(colSharing.Index).Value = share
                rs.MoveNext()
            Next

        End If
    End Sub
    Private Sub GridListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick

    End Sub
    Private Sub Filter()
        Dim field As String = ""
        Dim rs As New ADODB.Recordset

        If cmbfilter.Text = "" Then
            Exit Sub
        ElseIf cmbfilter.Text = "CompanyCode" Then
            field = "comid"
        ElseIf cmbfilter.Text = "CustomerCode" Then
            field = "CusCD"
        ElseIf cmbfilter.Text = "CustomerName" Then
            field = "CDAName"
        ElseIf cmbfilter.Text = "Month" Then
            field = "CUTMO"
        ElseIf cmbfilter.Text = "Year" Then
            field = "CUTYEAR"

        End If

        rs.Open("select DISTINCT COMID, CUSCD, CDACD,  CDANAME, EFFECTIVITYSTARTDATE, EFFECTIVITYENDDATE From SALESTERRITORYMAPPING WHERE DELFLAG = 0  AND " & field & " like '%" & txtFilter.Text & "%'  ORDER BY COMID, CUSCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        '   rs.Open("select * from salesterritorymapping where " & field & " like '%" & txtFilter.Text & "%' and delflag = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        GridListing.Rows.Clear()
        If rs.RecordCount > 0 Then

            For i As Integer = 1 To rs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(colComID.Index).Value = rs.Fields("COMID").Value
                row.Cells(colCustomerCode.Index).Value = rs.Fields("CUSCD").Value
                row.Cells(colShipToCode.Index).Value = rs.Fields("CDACD").Value
                row.Cells(colCustomerName.Index).Value = rs.Fields("CDANAME").Value
                row.Cells(colCutMo.Index).Value = CDate(rs.Fields("EFFECTIVITYSTARTDATE").Value).ToShortDateString
                row.Cells(colCutYear.Index).Value = CDate(rs.Fields("EFFECTIVITYENDDATE").Value).ToShortDateString
                rs.MoveNext()
            Next
        End If
    End Sub
    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Filter()
    End Sub

    Private Function GetItemDivisionDescription(ByVal ItemDivisionCode As String) As String
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("select * from ItemDivision where itmdivcd = '" & ItemDivisionCode & "' and dltflg  = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return rs.Fields("itmDivName").Value
        Else
            Return ""
        End If
    End Function

    Private Sub cmbCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged

    End Sub

    Private Sub lnkDeleteSelected_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkDeleteSelected.LinkClicked
        Dim q As MsgBoxResult

        q = VDialog.Show("This process is irreversible. Are you sure you want to delete the selected items?", "Delete Selected", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If q = MsgBoxResult.Yes Then
            DeleteSeleted()
        End If
    End Sub

    Public Sub DeleteSeleted()
        m_ForDeletes.Clear()

        For m As Integer = 0 To dgDetail.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetail.Rows(m)
            If row.Cells(colSelect.Index).Value = True Then
                DeleteSingleRecord(row)
                m_ForDeletes.Add.ID = m
            End If
        Next

        For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
            dgDetail.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If cmbCompany.Text = "" Then
            VDialog.Show("Channel is required", "Customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim tag As SelectionTag = ShowSearchDialog("CUSTOMERCD;CUSTOMERCD; CDACD; CDANAME; CDACADD1; CDACADD2;", "Select CustomerCD, CustomerCD [Customer Code], CDACD [Customer Ship To Code], CDANAME [Customer Ship To Name], CDACADD1 [Ship To Address 1], CDACADD2 [Ship To Address 2] FROM CUSTOMERSHIPTO WHERE ACCNTSHRD= 1 AND COMID = '" & cmbCompany.Text & "' ")

        If Not tag Is Nothing Then
            txtCustomerCode.Tag = tag.KeyColumn1
            txtCustomerCode.Text = tag.KeyColumn3
            txtCustomerName.Text = GetCustomerShipToName(cmbCompany.Text, tag.KeyColumn1, tag.KeyColumn3)
            LoadSharing()
        End If

    End Sub

    Private Sub LoadSharing()
        If txtCustomerCode.Text = "" Then
            VDialog.Show("Customer is required", "Add Sharing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim row As DataGridViewRow
        Dim areacovrgcode = GetCustomerShipToTerritory(cmbCompany.Text, txtCustomerCode.Tag, txtCustomerCode.Text)
        dgDetail.Rows.Clear()
        If Not areacovrgcode = "" Then
            For l As Integer = 0 To cmbitemdiv.Items.Count - 1
                Dim rs As ADODB.Recordset = GetCustomerShipToTerritoryCode(cmbitemdiv.Items(l), areacovrgcode)
                If Not rs Is Nothing Then
                    If rs.RecordCount > 1 Then
                        Dim ctr As Double = rs.RecordCount
                        Dim share As Double = 1 / ctr
                        For m As Integer = 0 To rs.RecordCount - 1
                            row = dgDetail.Rows(dgDetail.Rows.Add)
                            row.Cells(ColTercode.Index) = New DataGridViewTextBoxCell
                            row.Cells(ColTercode.Index).Value = rs.Fields("STTERRCD").Value
                            row.Cells(colTerritoryName.Index).Value = rs.Fields("STACOVNAME").Value
                            row.Cells(colMRCode.Index).Value = rs.Fields("STSLSMNCD").Value
                            row.Cells(colRep.Index).Value = rs.Fields("STSLSMNNAME").Value
                            row.Cells(colItemDiv.Index).Value = cmbitemdiv.Items(l)
                            row.Cells(colDescription.Index).Value = GetItemDivisionDescription(cmbitemdiv.Items(l))
                            row.Cells(colSharing.Index).Value = share
                            rs.MoveNext()
                        Next
                    End If
                End If
            Next
        End If

    End Sub

    Private Sub LoadSharingForNewTerritory()

    End Sub


    Public Function GetCustomerShipToName(ByVal ComID As String, ByVal CustomerCode As String, ByVal CustomerShipToCode As String) As String
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT CDANAME FROM CUSTOMERSHIPTO WHERE COMID = '" & ComID & "' AND  CUSTOMERCD = '" & CustomerCode & "' AND CDACD = '" & CustomerShipToCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return rs.Fields("CDANAME").Value
        Else
            Return ""
        End If
    End Function

    Public Function GetCustomerShipToTerritory(ByVal ComID As String, ByVal CustomerCode As String, ByVal CustomerShipToCode As String) As String
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rs.Open("SELECT AREACOVRG FROM CUSTOMERSHIPTO WHERE COMID = '" & ComID & "' AND  CUSTOMERCD = '" & CustomerCode & "' AND CDACD = '" & CustomerShipToCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        rs.Open("SELECT * FROM CUSTOMERMAPPING WHERE       ( '" & dtFrom.Value.ToShortDateString & "' BETWEEN EffectivityStartDate AND EffectivityEndDate  OR  '" & dtTo.Value.ToShortDateString & "' BETWEEN EffectivityStartDate AND EffectivityEndDate )   AND  CUSTOMERCD = '" & CustomerCode & "' AND CDACD ='" & CustomerShipToCode & "' AND COMID = '" & ComID & "' AND DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Dim areacovgcd As String = ""
            For m As Integer = 0 To rs.RecordCount - 1
                If areacovgcd <> "" Then areacovgcd &= ","
                areacovgcd &= "'" & rs.Fields("AREACOVRG").Value & "'"
                rs.MoveNext()
            Next
            Return areacovgcd
        Else
            Return ""
        End If
    End Function

    Public Function GetCustomerShipToTerritoryForNew(ByVal ComID As String, ByVal CustomerCode As String, ByVal CustomerShipToCode As String, ByVal AreaCoverage As String) As String
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rs.Open("SELECT AREACOVRG FROM CUSTOMERSHIPTO WHERE COMID = '" & ComID & "' AND  CUSTOMERCD = '" & CustomerCode & "' AND CDACD = '" & CustomerShipToCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        rs.Open("SELECT * FROM CUSTOMERMAPPING WHERE      ( '" & dtFrom.Value.ToShortDateString & "' BETWEEN EffectivityStartDate AND EffectivityEndDate  OR  '" & dtTo.Value.ToShortDateString & "' BETWEEN EffectivityStartDate AND EffectivityEndDate )   AND CUSTOMERCD = '" & CustomerCode & "' AND CDACD ='" & CustomerShipToCode & "' AND COMID = '" & ComID & "' AND DLTFLG = 0 AND AREACOVRG NOT IN ( " & AreaCoverage & " ) ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Dim areacovgcd As String = ""
            For m As Integer = 0 To rs.RecordCount - 1

                'For l As Integer = 0 To dgDetail.Rows.Count - 1
                '    Dim row As DataGridViewRow = dgDetail.Rows(m)
                '    If row.Cells(ColTercode.Index).Value <>
                'Next

                If areacovgcd <> "" Then areacovgcd &= ","
                areacovgcd &= "'" & rs.Fields("AREACOVRG").Value & "'"
                rs.MoveNext()
            Next
            Return areacovgcd
        Else
            Return ""
        End If
    End Function

    Public Function GetCustomerShipToTerritoryCode(ByVal SalesDivisionCode As String, ByVal AreaCoverageCode As String) As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM SALESMATRIX WHERE DLTFLG = 0 AND STITMDIVCD = '" & SalesDivisionCode & "' AND STACOVCD IN (" & AreaCoverageCode & ")   ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return rs
        Else
            Return Nothing
        End If
    End Function
    Public Function GetAreaCoverageName(ByVal AreaCoverageCode As String) As String
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT STACOVNAME FROM STAREACOVERAGE WHERE DLTFLG = 0 AND  STACOVCD = '" & AreaCoverageCode & "'  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return rs.Fields("STACOVNAME").Value
        Else
            Return ""
        End If
    End Function


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim a As New AutoCreateSharing
        a.ShowDialog()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Chr(13) Then
            Filter()
        End If
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub


End Class