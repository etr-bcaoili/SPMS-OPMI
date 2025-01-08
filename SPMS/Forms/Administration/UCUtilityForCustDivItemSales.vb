Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.GlobalFunctionsModule
Public Class UCUtilityForCustDivItemSales

    Private m_RsDistributor As New ADODB.Recordset
    Private m_RsMonth As New ADODB.Recordset

    Private Function CalendarYear(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset

        rs.Open("SELECT DISTINCT CAYR FROM CALENDAR  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If Filter <> "" Then
            rs.Filter = Filter
        End If
        Return rs
    End Function
    Private Sub LoadMonth(ByVal DistributorCode As String, ByVal Year As String)

        If m_RsMonth.State = 1 Then m_RsMonth.Close()
        m_RsMonth.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsMonth.Open("SELECT * FROM Calendar WHERE COMID = '" & DistributorCode & "' AND CAYR = '" & Year & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsMonth.RecordCount > 0 Then
            cboMonth.Items.Clear()
            txtMonthDescription.Text = ""
            For m As Integer = 0 To m_RsMonth.RecordCount - 1
                cboMonth.Items.Add(m_RsMonth.Fields("CAPN").Value)
                m_RsMonth.MoveNext()
            Next
        End If

    End Sub
    Private Sub cboMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMonth.SelectedIndexChanged
        GetMonthDescription(cboCompany.Text, cboCalendarYear.Text, cboMonth.Text)
    End Sub
    Private Sub GetMonthDescription(ByVal DistributorCode As String, ByVal Year As String, ByVal MonthCode As String)
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT MonthDescription FROM Calendar Where COMID = '" & DistributorCode & "' AND CAYR = '" & Year & "'   AND CAPN = '" & MonthCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            txtMonthDescription.Text = rs.Fields("MonthDescription").Value
        Else
            txtMonthDescription.Text = ""
        End If

    End Sub
    Private Sub LoadDistributor()
        If m_RsDistributor.State = 1 Then m_RsDistributor.Close()
        m_RsDistributor.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsDistributor.Open("SELECT * FROM DISTRIBUTOR WHERE  DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsDistributor.RecordCount > 0 Then
            cboCompany.Items.Clear()
            For m As Integer = 0 To m_RsDistributor.RecordCount - 1
                cboCompany.Items.Add(m_RsDistributor.Fields("DISTCOMID").Value)
                m_RsDistributor.MoveNext()
            Next
        End If
    End Sub
    Private Sub cboCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCompany.SelectedIndexChanged
        If cboCompany.SelectedIndex <> -1 Then
            GetCompanyName(cboCompany.Text)
        Else
            txtCompany.Text = String.Empty
        End If
    End Sub
    Private Sub GetCompanyName(ByVal CompanyCode As String)
        If m_RsDistributor.State = 1 Then m_RsDistributor.Close()
        m_RsDistributor.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsDistributor.Open("SELECT DISTNAME FROM DISTRIBUTOR WHERE DLTFLG = 0 AND DISTCOMID= '" & CompanyCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsDistributor.RecordCount > 0 Then
            txtCompany.Text = m_RsDistributor.Fields("DISTNAME").Value
        End If

    End Sub


    Private Sub lnkMedRep_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkMedRep.LinkClicked
        Dim tag As SelectionTag = ShowSearchDialog("SLSMNCD; SLSMNCD; SLSMNNAME; ", "SELECT SLSMNCD, SLSMNCD [Emp. Code], SLSMNNAME [Medical Representative Name] FROM MEDICALREP WHERE DLTFLG =0")
        If Not tag Is Nothing Then
            txtMedRep.Tag = tag.KeyColumn1
            txtMedRep.Text = tag.KeyColumn3
        End If
    End Sub

    Private Sub lnkCustomer_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCustomer.LinkClicked

        If cboCompany.Text = "" Then
            ShowExclamation("Channel is required", "Channel")
        Else
            Dim tag As SelectionTag = ShowSearchDialog("CUSTOMERCD; CUSTOMERCD; CUSTOMERNAME;", "SELECT CUSTOMERCD, CUSTOMERCD [Customer Code], CUSTOMERNAME [Customer Name] FROM CUSTOMER WHERE CUSTOMERDEL =0 AND COMID = '" & cboCompany.Text & "' ")
            If Not tag Is Nothing Then
                txtCustomer.Tag = tag.KeyColumn1
                txtCustomer.Text = tag.KeyColumn3
            End If
        End If
    End Sub

    Private Sub UCUtilityForCustDivItemSales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDistributor()
        ApplyGridTheme(dgDetails)
        Dim rs As ADODB.Recordset = CalendarYear()
        For m As Integer = 0 To rs.RecordCount - 1
            cboCalendarYear.Items.Add(rs.Fields("CAYR").Value)
            rs.MoveNext()
        Next

    End Sub

    Private Sub cboCalendarYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCalendarYear.SelectedIndexChanged
        If cboCalendarYear.SelectedIndex <> -1 Then
            LoadMonth(cboCompany.Text, cboCalendarYear.Text)
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim FilterString As String = ""

        If CDate(dtInvoiceDate.Value.ToShortDateString) > CDate(dtInvoiceDateTo.Value.ToShortDateString) Then
            ShowExclamation("Invoice Date From should not be greater than the Invoice Date To", "Filter")
            Exit Sub
        End If


        If cboCompany.Text = "" Then
            ShowExclamation("Channel is required", "Filter")
            Exit Sub
        Else
            FilterString &= "COMID = '" & cboCompany.Text & "' "
        End If

        If cboCalendarYear.Text = "" Then
            ShowExclamation("Year is required", "Filter")
            Exit Sub
        Else
            If FilterString <> "" Then FilterString &= " AND "
            FilterString &= "cutyear = '" & cboCalendarYear.Text & "' "
        End If

        If cboMonth.Text = "" Then
            ShowExclamation("Month is required", "Filter")
            Exit Sub
        Else
            If FilterString <> "" Then FilterString &= " AND "
            FilterString &= "cutmo = '" & cboMonth.Text & "' "
        End If

        '  If Not dtInvoiceDate.Value = "" Then
        If FilterString <> "" Then FilterString &= " AND "
        FilterString &= "CAST(CONVERT(VARCHAR(20), dyer,101) AS DATETIME) BETWEEN '" & dtInvoiceDate.Value.ToShortDateString & "'  AND '" & dtInvoiceDateTo.Value.ToShortDateString & "' "
        ' End If

        If txtInvoiceNumber.Text <> "" Then
            If FilterString <> "" Then FilterString &= " AND "
            FilterString &= "INVNUM = '" & HandleSingleQuoteInSql(txtInvoiceNumber.Text) & "' "
        End If

        If txtCustomer.Text <> "" Then
            If FilterString <> "" Then FilterString &= " AND "
            FilterString &= "CUST = '" & txtCustomer.Tag & "' "
        End If

        If txtMedRep.Text <> "" Then
            If FilterString <> "" Then FilterString &= " AND "
            FilterString &= "DETCD = '" & txtMedRep.Tag & "' "
        End If

        If txtTransactionType.Text <> "" Then
            If FilterString <> "" Then FilterString &= " AND "
            FilterString &= "TransactionType = '" & HandleSingleQuoteInSql(txtTransactionType.Text) & "' "
        End If

        If txtOrderType.Text <> "" Then
            If FilterString <> "" Then FilterString &= " AND "
            FilterString &= "ORDERTYPE = '" & HandleSingleQuoteInSql(txtOrderType.Text) & "' "
        End If

        If txtSalesDivision.Text <> "" Then
            If FilterString <> "" Then FilterString &= " AND "
            FilterString &= "DIVCD = '" & HandleSingleQuoteInSql(txtSalesDivision.Tag) & "' "
        End If
        FilterCustDiv(FilterString)
    End Sub

    Private Sub FilterCustDiv(ByVal Condition As String)
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM CUST_DIV_ITEM_SALES " & IIf(Condition <> "", " WHERE " & Condition & " ", ""), SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            ShowData(rs)
        Else
            dgDetails.Rows.Clear()
        End If

    End Sub

    Private Sub ShowData(ByVal rs As ADODB.Recordset)

        dgDetails.Rows.Clear()

        For m As Integer = 0 To rs.RecordCount - 1
            Dim row As DataGridViewRow = dgDetails.Rows(dgDetails.Rows.Add)
            row.Cells(colCustomerCode.Index).Value = rs.Fields("CUST").Value
            row.Cells(colCustomerName.Index).Value = rs.Fields("CNAME").Value
            row.Cells(colBranch.Index).Value = rs.Fields("BRAN").Value
            row.Cells(colItemCode.Index).Value = rs.Fields("PROD").Value
            row.Cells(colItemDescription.Index).Value = rs.Fields("PDES").Value
            row.Cells(colQty.Index).Value = rs.Fields("QTSO").Value
            row.Cells(colAmount.Index).Value = rs.Fields("VLAM").Value
            row.Cells(colQtyRet.Index).Value = rs.Fields("QTRET").Value
            row.Cells(colAmountReturn.Index).Value = rs.Fields("VLAMRET").Value
            row.Cells(colQtyFree.Index).Value = rs.Fields("QTFR").Value
            row.Cells(colQtyFreeRet.Index).Value = rs.Fields("QTFRRET").Value
            row.Cells(colPdsc.Index).Value = rs.Fields("PDSC").Value
            row.Cells(colDyer.Index).Value = rs.Fields("dyer").Value
            row.Cells(colDetCd.Index).Value = rs.Fields("DETCD").Value
            row.Cells(colDivCode.Index).Value = rs.Fields("DIVCD").Value
            row.Cells(colTeamCd.Index).Value = rs.Fields("TEAMCD").Value
            row.Cells(colGrpCd.Index).Value = rs.Fields("GRPCD").Value
            row.Cells(colMRName.Index).Value = rs.Fields("SSE").Value
            row.Cells(colItemTeam.Index).Value = rs.Fields("ITMTEAM").Value
            row.Cells(colCustGrp.Index).Value = rs.Fields("CUSTGRP").Value
            row.Cells(colCustGrpName.Index).Value = rs.Fields("CUSTGRPNAM").Value
            row.Cells(colMDCItemPrice.Index).Value = rs.Fields("MDCITMPRC").Value
            row.Cells(colDummy.Index).Value = rs.Fields("DUMMY").Value
            row.Cells(colZipCode.Index).Value = rs.Fields("ZIPCD").Value
            row.Cells(colItemTeamCode.Index).Value = rs.Fields("ITMTM").Value
            row.Cells(colItemTeamName.Index).Value = rs.Fields("ITMTMNM").Value
            row.Cells(ColSDivName.Index).Value = rs.Fields("SDIVNM").Value
            row.Cells(colSTeamCode.Index).Value = rs.Fields("STEAMCD1").Value
            row.Cells(colSTeamName.Index).Value = rs.Fields("STEAMNM").Value
            row.Cells(colMergeDiv.Index).Value = rs.Fields("MERGEDIV").Value
            row.Cells(colItemGrp.Index).Value = rs.Fields("ITMGRP").Value
            row.Cells(colItemGrpName.Index).Value = rs.Fields("ITMGRPNM").Value
            row.Cells(colShipToCode.Index).Value = rs.Fields("SHIPTO").Value
            row.Cells(colShipToAdd.Index).Value = rs.Fields("SHIPTOADD").Value
            row.Cells(colShipToAdd2.Index).Value = rs.Fields("SHIPTOADD2").Value
            row.Cells(colInvoiceNumber.Index).Value = rs.Fields("INVNUM").Value
            row.Cells(colVatInclusiveRawDataNetAmount.Index).Value = rs.Fields("VatInclusiveRawDataNetAmount").Value
            row.Cells(colVatIncGrossAmount.Index).Value = rs.Fields("VatInclusiveGrossAmount").Value
            row.Cells(colVatIncDiscount.Index).Value = rs.Fields("VatInclusiveDiscount").Value
            row.Cells(colVatIncDiscountPercentage.Index).Value = rs.Fields("VatInclusiveDiscountPercentage").Value
            row.Cells(colVatExcRawDataNetAmount.Index).Value = rs.Fields("VatExclusiveRawDataNetAmount").Value
            row.Cells(colVatExcGrossAmount.Index).Value = rs.Fields("VatEXclusiveGrossAmount").Value
            row.Cells(colVatExcDiscount.Index).Value = rs.Fields("VatExclusiveDiscount").Value
            row.Cells(colVatExcDiscountPercentage.Index).Value = rs.Fields("VatExclusiveDiscountPercentage").Value
            row.Cells(colVatAmount.Index).Value = rs.Fields("VATAMOUNT").Value
            row.Cells(colInvoiceReferenceNumber.Index).Value = rs.Fields("InvoiceReferenceNumber").Value
            row.Cells(colExpiryDate.Index).Value = rs.Fields("ExpiryDate").Value
            row.Cells(colLotNo.Index).Value = rs.Fields("LotNumber").Value
            row.Cells(colTransactionType.Index).Value = rs.Fields("TransactionType").Value
            row.Cells(colOrderType.Index).Value = rs.Fields("OrderType").Value
            row.Cells(colCMCode.Index).Value = rs.Fields("CMCode").Value
            row.Cells(colDistributorItemPrice.Index).Value = rs.Fields("DistributorItemPrice").Value
            row.Cells(colTransID.Index).Value = rs.Fields("TransactionID").Value
            row.Cells(colLock.Index).Value = rs.Fields("trxflg").Value
            rs.MoveNext()
        Next


    End Sub

    

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click, btnAssign.Click, btnDiv.Click
        If sender Is btnClose Then
            On Error Resume Next
            Dim m_TabPage As TabPage = Me.Parent
            CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
            Me.Dispose()
        ElseIf sender Is btnAssign Then
            If ValidFields() = True Then
                For i As Integer = 0 To dgDetails.Rows.Count - 1
                    Dim row As DataGridViewRow = dgDetails.Rows(i)
                    If row.Cells(colSelect.Index).Value = True Then
                        row.Cells(colDetCd.Index).Value = txtAgent.Tag
                        row.Cells(colMRName.Index).Value = txtAgent.Text
                    End If
                Next
            Else
                NothingSelected()
            End If
        ElseIf sender Is btnDiv Then
            If ValidFields() = True Then
                For i As Integer = 0 To dgDetails.Rows.Count - 1
                    Dim row As DataGridViewRow = dgDetails.Rows(i)
                    If row.Cells(colSelect.Index).Value = True Then
                        row.Cells(colDivCode.Index).Value = txtDIV.Tag

                    End If
                Next
            End If
        End If
    End Sub

    Private Sub lnkSalesDivision_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSalesDivision.LinkClicked
        Dim tag As SelectionTag = ShowSearchDialog("ITMDIVCD; ITMDIVCD; ITMDIVNAME;", "SELECT ITMDIVCD, ITMDIVCD [Sales Division Code], ITMDIVNAME [Sales Division Name] FROM ITEMDIVISION WHERE DLTFLG = 0")
        If Not tag Is Nothing Then
            txtSalesDivision.Tag = tag.KeyColumn1
            txtSalesDivision.Text = tag.KeyColumn3
        End If
    End Sub


    Private Sub dgDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick
        'If e.ColumnIndex = colDetCd.Index Or e.ColumnIndex = colMRName.Index Then
        '    Dim tag As SelectionTag = ShowSearchDialog("SLSMNCD; SLSMNCD; SLSMNNAME; ", "SELECT SLSMNCD, SLSMNCD [Emp. Code], SLSMNNAME [Medical Representative Name] FROM MEDICALREP WHERE DLTFLG =0")
        '    If Not tag Is Nothing Then
        '        Dim row As DataGridViewRow = dgDetails.Rows(e.RowIndex)
        '        row.Cells(colDetCd.Index).Value = tag.KeyColumn1
        '        row.Cells(colMRName.Index).Value = tag.KeyColumn3
        '    End If
        'End If
    End Sub

    Private Sub LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCheck.LinkClicked, llUncheck.LinkClicked, llagent.LinkClicked, llDiv.LinkClicked
        If sender Is llCheck Then
            For i As Integer = 0 To dgDetails.Rows.Count - 1
                Dim row As DataGridViewRow = dgDetails.Rows(i)

                row.Cells(colSelect.Index).Value = True

            Next
        ElseIf sender Is llUncheck Then
            For i As Integer = 0 To dgDetails.Rows.Count - 1
                Dim row As DataGridViewRow = dgDetails.Rows(i)

                row.Cells(colSelect.Index).Value = False

            Next
        ElseIf sender Is llagent Then
            Dim tag As SelectionTag = ShowSearchDialog("SLSMNCD; SLSMNCD; SLSMNNAME; ", "SELECT SLSMNCD, SLSMNCD [Emp. Code], SLSMNNAME [Medical Representative Name] FROM MEDICALREP WHERE DLTFLG =0")
            If Not tag Is Nothing Then
                txtAgent.Tag = tag.KeyColumn1
                txtAgent.Text = tag.KeyColumn3
            End If
        ElseIf sender Is llDiv Then
            Dim tag As SelectionTag = ShowSearchDialog("ITMDIVCD; ITMDIVCD; ITMDIVNAME;", "SELECT ITMDIVCD, ITMDIVCD [Sales Division Code], ITMDIVNAME [Sales Division Name] FROM ITEMDIVISION WHERE DLTFLG = 0")
            If Not tag Is Nothing Then
                txtDIV.Tag = tag.KeyColumn1
                txtDIV.Text = tag.KeyColumn3
            End If
        End If

    End Sub

    
    Private Sub ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim ctr As Integer = 0
        If ValidFields() = True Then
            For i As Integer = 0 To dgDetails.Rows.Count - 1
                Dim row As DataGridViewRow = dgDetails.Rows(i)
                If row.Cells(colSelect.Index).Value = True Then
                    If row.Cells(colLock.Index).Value = 0 Then
                        SPMSConn.Execute("UPDATE CUST_DIV_ITEM_SALES SET SSE = '" & row.Cells(colMRName.Index).Value & "', DETCD = '" & row.Cells(colDetCd.Index).Value & "', divcd = '" & row.Cells(colDivCode.Index).Value & "'  WHERE TransactionID = " & row.Cells(colTransID.Index).Value)
                    Else

                        ctr += 1
                    End If



                End If
            Next

            If ctr > 0 Then
                PartialUpdate()
            End If

            SaveSuccess()
        Else
            NothingSelected()
        End If
    End Sub

    Private Function ValidFields() As Boolean

        For i As Integer = 0 To dgDetails.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetails.Rows(i)
            If row.Cells(colSelect.Index).Value = True Then
                Return True
            End If

        Next

        Return False
    End Function

  

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
End Class
