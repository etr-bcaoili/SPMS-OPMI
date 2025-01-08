Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class SharingMapping
    Private Gridrs As New ADODB.Recordset
    Private Operation As String = ""
    Private m_ForDeletes As New ForDeletesCollection
    Dim m_HasError As Boolean = False
    Private PrevSharing As Double = 0
    Private m_Err As New ErrorProvider
    Private CurrVal As Long
    Private MaxVal As Long
    Private Sub dgDetail_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgDetail.CellBeginEdit
        PrevSharing = 0
        If e.RowIndex = -1 Then Exit Sub
        Dim row As DataGridViewRow = dgDetail.Rows(dgDetail.CurrentRow.Index)
        If e.ColumnIndex = colSharing.Index Then
            PrevSharing = row.Cells(colSharing.Index).Value
        End If
    End Sub
    Private Sub dgDetail_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellEndEdit
        Dim rs As New ADODB.Recordset
        rs.Open("Select pershr,TerrCD from sharing where Delflag = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If e.RowIndex = -1 Then Exit Sub
        Dim row As DataGridViewRow = dgDetail.Rows(dgDetail.CurrentRow.Index)
        If e.ColumnIndex = colSharing.Index Then

            If IsNumeric(row.Cells(colSharing.Index).Value) Then

                If PrevSharing <> (row.Cells(colSharing.Index).Value) Then
                    row.Cells(colSharing.Index).Value = Val(row.Cells(colSharing.Index).Value) / Val(100)
                Else
                    row.Cells(colSharing.Index).Value = CDec(row.Cells(colSharing.Index).Value).ToString("#,##0.0000")
                    ' row.Cells(colSharing.Index).Value = 1 / row.Cells(colSharing.Index).Value

                End If
            Else

                row.Cells(colSharing.Index).Value = CDec(row.Cells(colSharing.Index).Value).ToString("#,##0.0000")
            End If
        End If


    End Sub
   
    Private Sub PopulateComboBoxes()
        Dim rs As New ADODB.Recordset
        'for the year
        txtyear.Text = String.Empty
        cmbCompany.Items.Clear()
        txtmonth.Text = String.Empty
        For i As Integer = Year(Now) - 5 To Year(Now)
            ' txtyear.Items.Add(i)
        Next

        'for the Company
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT DISTINCT COMID FROM SHARING WHERE DELFLAG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbCompany.Items.Add(rs.Fields("COMID").Value)
                rs.MoveNext()
            Next
        End If


        
    End Sub
    Private Sub SharingMapping_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PopulateComboBoxes()
        ApplyGridTheme(GridListing)
        ApplyGridTheme(dgDetail)
        'OpenListing()
        Operation = "Add"
        '   SetupOperation(True)
        m_Err.Clear()

        

        SPMSConn.CommandTimeout = 0
        SPMSConn.Execute("EXEC uspSharing")

        SPMSConn.CommandTimeout = 0
        SPMSConn.Execute("EXEC uspUpdateCustomerMappingStateAreaTerritory")
        

    End Sub
    
    Private Sub OpenListing()
        If Gridrs.State = 1 Then Gridrs.Close()
        Gridrs.Open("select  COMID, CUSCD, CDACD,CUSNAM,  CDANAME,PERSHR, CUTMO, CUTYEAR From SHARING WHERE DELFLAG = 0 Group BY COMID, CUSCD, CDACD,CUSNAM,  CDANAME,PERSHR, CUTMO, CUTYEAR", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        GridListing.Rows.Clear()
        If Gridrs.RecordCount > 0 Then
            For i As Integer = 1 To Gridrs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(colComID.Index).Value = Gridrs.Fields("COMID").Value
                row.Cells(colCustomerCode.Index).Value = Gridrs.Fields("CUSCD").Value
                row.Cells(colShipToCode.Index).Value = Gridrs.Fields("CDACD").Value
                row.Cells(colCustomerName.Index).Value = Gridrs.Fields("CDANAME").Value
                row.Cells(colCutMo.Index).Value = Gridrs.Fields("CUTMO").Value
                row.Cells(colCutYear.Index).Value = Gridrs.Fields("CUTYEAR").Value
                Gridrs.MoveNext()
            Next
        End If
    End Sub
    Private Sub SetupOperation(ByVal hasOperation As Boolean)
        btnEdit.Enabled = Not hasOperation
        btnDelete.Enabled = Not hasOperation
        btnSave.Enabled = hasOperation
    End Sub
    Private Sub cmbCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged

    End Sub
    
    Private Function ValidateData() As Boolean
        m_HasError = False
        m_Err.Clear()
        For m As Integer = 0 To dgDetail.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetail.Rows(m)
            If row.Cells(colSharing.Index).Value = 0 Then
                row.Cells(colSharing.Index).Style.BackColor = Color.LightPink
                row.Cells(colSharing.Index).ToolTipText = "Sharing should not be zero"
                m_HasError = True
            End If
            If row.Cells(colSharing.Index).Value > 1 Then
                row.Cells(colSharing.Index).Style.BackColor = Color.LightPink
                row.Cells(colSharing.Index).ToolTipText = "Not more than 100"
                m_HasError = True
            Else
                row.Cells(colSharing.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                row.Cells(colSharing.Index).ToolTipText = String.Empty
            End If
        Next


        Return Not m_HasError
    End Function
   
    Private Sub clearform()
        cmbCompany.Text = ""
        txtcodenum.Text = ""
        cmbfilter.Text = ""
        txtmonth.Text = ""
        txtyear.Text = ""



        'PopulateComboBoxes()
        txtcustname.Text = ""
        txtCustomerCode.Text = ""
        dgDetail.Rows.Clear()
    End Sub
   
    Private Sub DeleteRecord()
        For i As Integer = 0 To dgDetail.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetail.Rows(i)
            SPMSConn.Execute("EXEC uspSharing @ACTION = 'DELETE', @Recid = '" & row.Tag & "', @COMID = '" & cmbCompany.Text & "', " & _
                                                                 " @CUSCD = '" & txtCustomerCode.Text & "', @CDACD = '" & txtcodenum.Text & "', @CUSNAM = '" & HandleSingleQuoteInSql(txtcustname.Text) & "' , @CDANAME= '" & HandleSingleQuoteInSql(txtcustname.Text) & "', " & _
                                                                " @itemdivcd = '" & row.Cells(colItemDiv.Index).Value & "', @TERRCD = '" & row.Cells(ColTercode.Index).Value & "', " & _
                                                                " @PERSHR = " & row.Cells(colSharing.Index).Value & ", @CUTYEAR = '" & txtyear.Text & "', @CUTMO = '" & txtmonth.Text & "', " & _
                                                                " @DELFLAG = 0, @STSLSMNCD = '" & row.Cells(colMRCode.Index).Value & "',  " & _
                                                                " @STSLSMNNAME = '" & HandleSingleQuoteInSql(row.Cells(colRep.Index).Value) & "',  @IsActive = 1")
        Next
    End Sub

   

    Private Sub UpdateRecord()

        For i As Integer = 0 To dgDetail.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetail.Rows(i)
            SPMSConn.Execute("EXEC uspSharing @ACTION = 'SAVE', @Recid = '" & row.Tag & "', @COMID = '" & cmbCompany.Text & "', " & _
                                                                 " @CUSCD = '" & txtCustomerCode.Text & "', @CDACD = '" & txtcodenum.Text & "', @CUSNAM = '" & HandleSingleQuoteInSql(txtcustname.Text) & "' , @CDANAME= '" & HandleSingleQuoteInSql(txtcustname.Text) & "', " & _
                                                                " @itemdivcd = '" & row.Cells(colItemDiv.Index).Value & "', @TERRCD = '" & row.Cells(ColTercode.Index).Value & "', " & _
                                                                " @PERSHR = " & row.Cells(colSharing.Index).Value & ", @CUTYEAR = '" & txtyear.Text & "', @CUTMO = '" & txtmonth.Text & "', " & _
                                                                " @DELFLAG = 0, @STSLSMNCD = '" & row.Cells(colMRCode.Index).Value & "',  " & _
                                                                " @STSLSMNNAME = '" & HandleSingleQuoteInSql(row.Cells(colRep.Index).Value) & "',  @IsActive = 1")
        Next

    End Sub
   
   
    Private Sub DeleteSingleRecord(ByVal row As DataGridViewRow)


        SPMSConn.Execute("EXEC uspSharing @ACTION = 'DELETE', @Recid = '" & row.Tag & "', @COMID = '" & cmbCompany.Text & "', " & _
                                                                 " @CUSCD = '" & txtCustomerCode.Text & "', @CDACD = '" & txtcodenum.Text & "', @CUSNAM = '" & HandleSingleQuoteInSql(txtcustname.Text) & "' , @CDANAME= '" & HandleSingleQuoteInSql(txtcustname.Text) & "', " & _
                                                                " @itemdivcd = '" & row.Cells(colItemDiv.Index).Value & "', @TERRCD = '" & row.Cells(ColTercode.Index).Value & "', " & _
                                                                " @PERSHR = " & row.Cells(colSharing.Index).Value & ", @CUTYEAR = '" & txtyear.Text & "', @CUTMO = '" & txtmonth.Text & "', " & _
                                                                " @DELFLAG = 0, @STSLSMNCD = '" & row.Cells(colMRCode.Index).Value & "',  " & _
                                                                " @STSLSMNNAME = '" & HandleSingleQuoteInSql(row.Cells(colRep.Index).Value) & "',  @IsActive = 1")

       
    End Sub


    Private Sub GridListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

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
    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Filter()
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

        rs.Open("select  COMID,CUSCD, CDACD,  CDANAME,  CUTMO,CUTYEAR  From Sharing WHERE DELFLAG = 0  AND " & field & " like '%" & txtFilter.Text & "%' group by COMID,CUSCD, CDACD,  CDANAME,  CUTMO,CUTYEAR ORDER BY COMID, CUSCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        '   rs.Open("select * from salesterritorymapping where " & field & " like '%" & txtFilter.Text & "%' and delflag = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        GridListing.Rows.Clear()
        If rs.RecordCount > 0 Then

            For i As Integer = 1 To rs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)

                row.Cells(colComID.Index).Value = rs.Fields("COMID").Value
                row.Cells(colCustomerCode.Index).Value = rs.Fields("CUSCD").Value
                row.Cells(colShipToCode.Index).Value = rs.Fields("CDACD").Value
                row.Cells(colCustomerName.Index).Value = rs.Fields("CDANAME").Value
                row.Cells(colcutMo.Index).Value = rs.Fields("CUTMO").Value
                row.Cells(colCutYear.Index).Value = rs.Fields("CUTYEAR").Value
                rs.MoveNext()
            Next
        End If
    End Sub

    Public Function GetCustomerShipToName(ByVal ComID As String, ByVal CustomerCode As String, ByVal CustomerShipToCode As String) As String
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT CDANAME FROM Sharing WHERE Recid = '" & ComID & "' AND CDACD  = '" & CustomerCode & "' AND STSLSMNCD = '" & CustomerShipToCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return rs.Fields("CDANAME").Value
        Else
            Return ""
        End If
    End Function

    Private Sub dgDetail_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
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
                        row.Cells(colTerritory.Index).Value = Search.ReturnTerrName
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
    Private Function ValidFields() As Boolean
        Dim totalcount As Double = 0

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
   

    Private Sub GridListingCellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick
      

    End Sub


    Private Sub lnkDeleteSelected_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkDeleteSelected.LinkClicked
        If ShowQuestion("This process is irreversible. Are you sure you want to delete the selected items?", "Delete Selected") = MsgBoxResult.Yes Then
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
   
    Private Sub SetupbyOperation(ByVal HasOperation As Boolean)
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation
    End Sub
    Private Function CheckRecordExists(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM SHARING WHERE COMID = '" & Code & "' AND DELFLAG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click, btnDelete.Click, btnSave.Click, btnClose.Click
       
        If sender Is btnEdit Then
            SetupOperation(True)
            Operation = "Edit"
            cmbCompany.Focus()
        ElseIf sender Is btnDelete Then
            If CheckRecordExists(cmbCompany.Text) = True Then
                DeleteRecord()
                DeleteSuccess()
                Operation = ""
                SetupOperation(False)
                clearform()
                OpenListing()
            Else
                RecordInexist()
            End If
        ElseIf sender Is btnSave Then
            If ValidFields() = True Then
                If ValidateData() Then
                    If Operation = "Add" Then
                        If CheckRecordExists(cmbCompany.Text) = True Then
                            RecordExists()
                        Else

                            Operation = ""
                            SetupOperation(False)
                            OpenListing()
                            SaveSuccess()
                        End If
                    ElseIf Operation = "Edit" Then
                        If CheckRecordExists(cmbCompany.Text) = True Then
                            UpdateRecord()
                            Operation = ""
                            SetupOperation(False)
                            OpenListing()
                            SaveSuccess()
                        Else
                            RecordInexist()
                        End If

                    End If
                Else
                    ShowExclamation("Error Exist . Kindly check details", "Save")
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

    

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
       
    End Sub

    Private Sub GridListing_CellDoubleClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Dim rs As New ADODB.Recordset
        m_Err.Clear()
        Dim row As DataGridViewRow = GridListing.Rows(e.RowIndex)
        rs.Open("SELECT  a.recid, a.comid as [comid], a.cuscd as [cuscd], a.cusnam as [cusnam], a.cdacd, a.cdaname, a.itemdivcd as [itmdivcd],a.stslsmncd as [stslsmncd], a.stslsmnname as [stslsmnname], a.terrcd as [TerrCD], b.stacovname as [TerrName], a.pershr as [Pershr] , 	a.cutmo as [cutmo], a.cutyear  as [cutyear] FROM SHARING A, SALESMATRIX B WHERE   A.CUTMO = '" & row.Cells(colcutMo.Index).Value & "' AND  A.CUTYEAR  = '" & row.Cells(colCutYear.Index).Value & "'AND B.STTERRCD = A.TERRCD AND B.DLTFLG =0 AND A.DELFLaG = 0 AND A.COMID = '" & row.Cells(colComID.Index).Value & "' AND A.CUSCD = '" & row.Cells(colCustomerCode.Index).Value & "' AND A.CDACD = '" & row.Cells(colShipToCode.Index).Value & "'AND month(b.effectivitystartdate)  = '" & row.Cells(colcutMo.Index).Value & "'and year(b.effectivitystartdate) = '" & row.Cells(colCutYear.Index).Value & "' Order by A.ItemDivCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Dim itemDivCD As String = ""
        Dim area As String = ""
        If rs.RecordCount > 0 Then

            PopulateComboBoxes()
            Operation = ""


            dgDetail.Rows.Clear()

            For i As Integer = 1 To rs.RecordCount
                Dim dgrow As DataGridViewRow = dgDetail.Rows(dgDetail.Rows.Add)

                dgrow.Tag = rs.Fields("RecID").Value
                dgrow.Cells(colItemDiv.Index).Value = rs.Fields("itmdivcd").Value
                dgrow.Cells(ColTercode.Index) = New DataGridViewTextBoxCell
                dgrow.Cells(ColTercode.Index).Value = rs.Fields("TerrCD").Value
                dgrow.Cells(colTerritoryName.Index).Value = rs.Fields("TerrName").Value
                dgrow.Cells(colRep.Index).Value = rs.Fields("stslsmnname").Value
                dgrow.Cells(colSharing.Index).Value = rs.Fields("Pershr").Value
                dgrow.Cells(colDescription.Index).Value = rs.Fields("itmdivcd").Value
                dgrow.Cells(colMRCode.Index).Value = rs.Fields("stslsmncd").Value
                dgrow.Cells(colMRCode.Index).Tag = rs.Fields("pershr").Value


                itemDivCD = rs.Fields("itmdivcd").Value
                rs.MoveNext()
            Next

            rs.MovePrevious()

            cmbCompany.Text = rs.Fields("comid").Value
            txtCustomerCode.Text = rs.Fields("cuscd").Value
            txtcustname.Text = rs.Fields("CDANAME").Value
            txtcodenum.Text = rs.Fields("CDACD").Value
            txtmonth.Text = rs.Fields("CUTMO").Value
            txtyear.Text = rs.Fields("CUTYEAR").Value



            MainTab.SelectTab(0)

        End If

    End Sub

    Private Sub txtFilter_StyleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFilter.StyleChanged
        If txtFilter.Text = "" Then
            OpenListing()
        End If
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        SetupbyOperation(True)
        Operation = "Edit"
    End Sub



    Private Sub dgDetail_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgDetail.CellFormatting
       
    End Sub

    Private Sub dgDetail_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellContentClick

    End Sub
End Class
