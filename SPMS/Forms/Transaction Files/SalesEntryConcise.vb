Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ucMasterRegion
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class SalesEntryConcise

    Private m_CustomerShipTo As New CustomerShipTo
    Private m_Salesman As New MedicalRep
    Private m_BillingOrder As New BillingOrder
    Private m_Distributor As New Distributor
    Private m_ForDeletes As New ForDeletesCollection
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False

    Private Sub lnkCustomer_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCustomer.LinkClicked
        If txtCompany.Text = "" Then
            ShowExclamation("Please Select Company", "Sales Order Entry")
        Else
            Dim Tag As SelectionTag = ShowSearchDialog(CustomerShipTo.GetCustomerColumns, CustomerShipTo.GetCustomerSql(txtCompany.Text), "Search Customer")
            If Not Tag Is Nothing Then
                ShowCustomer(Tag.KeyColumn1)
            End If
        End If
    End Sub


    Private Sub lnkDistributor_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkDistributor.LinkClicked
        Dim Tag As SelectionTag = ShowSearchDialog(Distributor.GetDistributorColumns, Distributor.GetDistributorSql, "Search Company")
        If Not Tag Is Nothing Then
            ShowCompany(Tag.KeyColumn1)
        End If
    End Sub

    Private Sub ShowCustomer(ByVal CustomerShipID As Integer)
        m_CustomerShipTo = CustomerShipTo.Load(CustomerShipID)
        txtCustomer.Tag = m_CustomerShipTo.CUSTOMERSHIPTOID
        txtCustomer.Text = m_CustomerShipTo.CDANAME
        txtCustomerAddress.Text = m_CustomerShipTo.CDACADD1
        txtCustomerShipTo.Text = m_CustomerShipTo.CDACD
        txtCustromerShioToAddress.Text = m_CustomerShipTo.CDACADD2
    End Sub
    Private Sub ShowSaleman(ByVal SalesmanID As String)
        m_Salesman = MedicalRep.LoadByCodes(SalesmanID)
        txtSalesmanCodes.Text = m_Salesman.SalesAgentCode
        txtSalesmancode.Text = m_Salesman.SalesAgentName
        'Dim rs As New ADODB.Recordset
        'rs = New ADODB.Recordset
        'rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rs.Open("Select * from  STMedicalRep where DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        'txtSalesman.Tag = rs.Fields("SLSMNCD").Value
        'txtSalesman.Text = rs.Fields("SLSMNCD").Value
        'txtSalesmanname.Text = rs.Fields("SLSMNNAME").Value

    End Sub

    Private Sub ShowCompany(ByVal DistributorID As Integer)
        m_Distributor = Distributor.Load(DistributorID)
        txtCompany.Text = m_Distributor.DISTCOMID
        txtCompanyName.Text = m_Distributor.DISTNAME
    End Sub


    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnEdit.Click, btnDelete.Click, btnFind.Click, btnSave.Click, btnApprove.Click, btnClose.Click, btnCancel.Click, btnPrint.Click
        If sender Is btnNew Then
            NewRecord()
            dgDetails.Enabled = True
        ElseIf sender Is btnEdit Then
            EditMode(True)
            dgDetails.Enabled = True
        ElseIf sender Is btnDelete Then
            Delete()
        ElseIf sender Is btnFind Then
            FindRecord()
        ElseIf sender Is btnSave Then
            If valedate() Then
                SaveRecord()
                dgDetails.Enabled = False
            End If
        ElseIf sender Is btnApprove Then
            Approved()
            'btnPrint.Visible = True
            dgDetails.Enabled = False
        ElseIf sender Is btnPrint Then
            LoadtoPreview()

        ElseIf sender Is btnClose Then
            Close()
        ElseIf sender Is btnCancel Then
            Canceled()
        End If

    End Sub
    Public Sub LoadtoPreview()
        'Try
        Dim m_Preview As New PrintingSalesOrder
        ' Dim m_CommercialInvoice As New CommercialInvoice
        'Dim sup As Supplier = Supplier.LoadByCode(m_SupplierCode)
        'm_Preview.PrintDate = GetServerDate.ToShortDateString
        'm_Preview.ShiptoParty = sup.Name
        'm_Preview.ShiptoPartyAdd = sup.Address
        'm_Preview.Telephone = sup.TelephoneNumber
        'm_Preview.Fax = sup.FaxNumber
        'm_Preview.PONumber = m_ReferenceNo
        'm_Preview.ReferenceNumber = m_ReferenceNo
        'm_Preview.Supplier = m_SupplierCode
        'm_Preview.SupplierAdd = sup.Address
        'm_Preview.Currency = Currency.GetDescriptionByCode(m_CurrencyCode)
        'm_Preview.CreditTerms = CreditTerms.GetDecriptionByCode(m_TermsCode)
        'm_Preview.Remarks = m_Remarks
        'm_Preview.DocumentDate = m_DocumentDate.ToShortDateString
        'm_Preview.PostingDate = m_PostingDate.ToShortDateString
        'm_Preview.DeliveryDate = m_DeliveryDate.ToShortDateString
        'm_Preview.CreatedBy = SystemUsers.GetUserName(m_CreatedBy)
        ''m_Preview.CreatedOn = m_CreateDate.ToShortDateString
        'm_Preview.ApprovedBy = SystemUsers.GetUserName(m_ApprovedBy)
        ''m_Preview.ApprovedOn = m_ApprovedDate.ToShortDateString
        'm_Preview.RejectedBy = SystemUsers.GetUserName(m_RejectedBy)
        'm_Preview.RejectedOn = m_RejectedDate.ToShortDateString
        'm_Preview.CancelledBy = m_CancelledBy
        'm_Preview.CancelledOn = m_CancelledDate.ToShortDateString
        'm_Preview.CancelledReason = m_CancellationReason

        'm_Preview.ModeOfShipment = m_CommercialInvoice.ModeofTransportationCode
        'm_Preview.PaymentTerms = CreditTerms.GetDecriptionByCode(m_TermsCode)

        'Dim det As PreviewOfPurchaseOrderDetail

        'For m As Integer = 0 To m_PurchaseOrderDetail.Count - 1
        '    det = New PreviewOfPurchaseOrderDetail
        '    m_Preview.PreviewOfPurchaseOrderDetailCollection.Add(det)
        '    Dim item As Item = item.LoadByCode(m_PurchaseOrderDetail(m).ItemCode)
        '    det.Free = m_PurchaseOrderDetail(m).IsFreeGoods
        '    det.ItemCode = item.Code
        '    det.ItemDescription = item.ShortDescription
        '    det.PackSize = item.PackSize
        '    det.Quantity = m_PurchaseOrderDetail(m).Quantity
        '    det.PurchaseCost = m_PurchaseOrderDetail(m).UnitCost
        '    det.Unit = m_PurchaseOrderDetail(m).UnitOfMeasurementCode
        '    det.Amount = m_PurchaseOrderDetail(m).Amount
        '    det.TotalOrderQuantity = m_PurchaseOrderDetail(m).Quantity
        '    det.TA = m_TotalAmount
        'Next

        m_Preview.GenerateReport()

        'Catch ex As Exception

        'MsgBox("No Record to be Viewed!")

        'End Try

    End Sub




    Private Sub Clear()
        txtSONumber.Clear()
        txtInvoiceNumber.Clear()
        txtCompany.Clear()
        txtCompanyName.Clear()
        txtCustomer.Clear()
        txtCustomerAddress.Clear()
        dtInvoiceDate.Text = DateTime.Now()
        dtSOdate.Text = DateTime.Now()
        txtCustomerShipTo.Clear()
        txtCustromerShioToAddress.Clear()
        txtRemarks.Clear()
        txtGrossTotal.Clear()
        txtDiscFormula.Clear()
        txtDiscTotal.Clear()
        txtNetTotal.Clear()
        txtSalesmancode.Clear()
        txtSalesmanCodes.Clear()
        dgDetails.Rows.Clear()
        'dgPreview.Rows.Clear()
    End Sub

    Private Sub NewRecord()
        m_BillingOrder = New BillingOrder
        Clear()
        EditMode(True)
    End Sub

    Private Sub EditMode(ByVal IsEditMode As Boolean)
        dgDetails.ReadOnly = Not IsEditMode
        'dgPreview.ReadOnly = Not IsEditMode
        If m_BillingOrder.Status = BillingOrder.EnumBillingOrderStatus.Finalized Then
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            btnSave.Enabled = False
            btnApprove.Enabled = False
            btnCancel.Enabled = True
        ElseIf m_BillingOrder.Status = BillingOrder.EnumBillingOrderStatus.Canceled Then
            btnFind.Enabled = Not IsEditMode
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            btnSave.Enabled = False
            btnApprove.Enabled = False
            btnCancel.Enabled = False
        Else
            btnNew.Enabled = True
            btnSave.Enabled = IsEditMode
            btnEdit.Enabled = Not IsEditMode
            btnDelete.Enabled = Not IsEditMode
            btnApprove.Enabled = Not IsEditMode
            dgDetails.ReadOnly = Not IsEditMode
            'btnCancel.Enabled = Not IsEditMode
            'dgPreview.ReadOnly = Not IsEditMode
        End If
        lnkCustomer.Enabled = IsEditMode
        dtInvoiceDate.Enabled = IsEditMode
        txtRemarks.ReadOnly = Not IsEditMode
        lnkDistributor.Enabled = IsEditMode
        UcItemGrid1.Enabled = IsEditMode
        LinkLabel1.Enabled = IsEditMode

        For j As Integer = 0 To dgDetails.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetails.Rows(j)
            'row.Cells(colSalesAgent.Index).ReadOnly = Not IsEditMode
            'row.Cells(colShare.Index).ReadOnly = Not IsEditMode
            'row.Cells(colDistrictCode.Index).ReadOnly = Not IsEditMode
            'row.Cells(colDistrictDesc.Index).ReadOnly = Not IsEditMode
            row.Cells(colQty.Index).ReadOnly = Not IsEditMode
            row.Cells(colDiscFormula.Index).ReadOnly = Not IsEditMode
            'row.Cells(colCreditedAmount.Index).ReadOnly = Not IsEditMode
            row.Cells(colRemarks.Index).ReadOnly = Not IsEditMode

        Next
    End Sub

    Private Sub Delete()
        Dim q As MsgBoxResult
        q = VDialog.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Question)
        If q = MsgBoxResult.Yes Then
            If m_BillingOrder.Delete Then
                VDialog.Show("Record Successfully Deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                NewRecord()
            Else
                VDialog.Show("Record not deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub FindRecord()
        Dim tag As SelectionTag = ShowSearchDialog(BillingOrder.GetBillingOrderColumns, BillingOrder.GetBillingOrderSql, "Sales Order Entry")
        If Not tag Is Nothing Then
            ShowData(tag.KeyColumn1)
            EditMode(False)
        End If
    End Sub
    Private Function valedate() As Boolean
        m_Err.Clear()
        m_HasError = False
        If txtInvoiceNumber.Text = "" Then
            m_Err.SetError(txtInvoiceNumber, "Invoice Number is Required")
            m_HasError = True
        End If
        If txtSalesmancode.Text = "" Then
            m_Err.SetError(txtSalesmancode, "SalesManCode is empty")
            m_HasError = True
        End If
        If txtSalesmanCodes.Text = "" Then
            m_Err.SetError(txtSalesmanCodes, "Salesman is empty")
            m_HasError = True
        End If
        If txtCompany.Text = "" Then
            m_Err.SetError(txtCompany, "Company Code is Emty")
            m_HasError = True

        End If
        If txtCompanyName.Text = "" Then
            m_Err.SetError(txtCompanyName, "Company Name is Empty")
            m_HasError = True

        End If
        If txtCustomer.Text = "" Then
            m_Err.SetError(txtCustomer, "Customer Code is Empty")
            m_HasError = True

        End If
        If txtCustomerAddress.Text = "" Then
            m_Err.SetError(txtCustomerAddress, "Customer Address is Empty")
            m_HasError = True

        End If
        If txtCustomerShipTo.Text = "" Then
            m_Err.SetError(txtCustomerShipTo, "Customer shipto is Empty")
            m_HasError = True

        End If
        If txtCustromerShioToAddress.Text = "" Then
            m_Err.SetError(txtCustromerShioToAddress, "CustomershipToAddress is Empty")
            m_HasError = True

        End If
        If txtDiscFormula.Text = "" Then
            m_Err.SetError(txtDiscFormula, "Disc Fomula is Empty")
            m_HasError = True

        End If
        If txtGrossTotal.Text = "" Then
            m_Err.SetError(txtGrossTotal, "GrossTotal is not Empty")
            m_HasError = True

        End If
        Return Not m_HasError

    End Function
    Private Sub SaveRecord()

        If m_BillingOrder.BillingOrderID = -1 Then
            txtSONumber.Text = SystemSequences.GetBillingOrderSequence
        End If

        m_BillingOrder.BillingOrderNumber = txtSONumber.Text
        m_BillingOrder.TransactionDate = dtSOdate.Value.ToShortDateString
        m_BillingOrder.InvoiceNumber = txtInvoiceNumber.Text
        m_BillingOrder.SalesManCode = txtSalesmanCodes.Text
        m_BillingOrder.DistributorCode = txtCompany.Text
        m_BillingOrder.InvoiceDate = dtInvoiceDate.Value.ToShortDateString
        m_BillingOrder.CustomerId = txtCustomer.Tag
        m_BillingOrder.Address = txtCustomerAddress.Text
        m_BillingOrder.ShipToCustomerId = txtCustomer.Tag
        m_BillingOrder.Remarks = txtRemarks.Text
        m_BillingOrder.GrossTotal = txtGrossTotal.Text
        m_BillingOrder.GrossDiscount = txtDiscTotal.Text
        m_BillingOrder.NetTotal = txtNetTotal.Text

        Dim det As BillingOrderDetails
        For m As Integer = 0 To dgDetails.Rows.Count - 1

            Dim row As DataGridViewRow = dgDetails.Rows(m)


            If row.Tag Is Nothing Then
                det = New BillingOrderDetails
                row.Tag = det
                m_BillingOrder.BillingOrderDetailsCollection.Add(det)
            Else
                det = row.Tag
            End If

            det.ItemID = row.Cells(colCode.Index).Value
            det.ListPrice = row.Cells(colListPrice.Index).Value
            det.Discount = row.Cells(colDiscFormula.Index).Value
            det.DiscountAmount = row.Cells(colDiscAmount.Index).Value
            det.Amount = row.Cells(colTotal.Index).Value
            det.VatExclusiveRawDataAmount = row.Cells(colTotal.Index).Value
            det.Quantity = row.Cells(colQty.Index).Value
            det.IsFreeGoods = CBool(row.Cells(colIsFree.Index).Value)
            det.Remarks = row.Cells(colRemarks.Index).Value
        Next

        If m_BillingOrder.Save() Then

            VDialog.Show("Record Successfully Saved.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ShowData(m_BillingOrder.BillingOrderID)
            EditMode(False)
        Else
            VDialog.Show("Record not saved.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub Approved()
        If m_BillingOrder.Finalized Then
            VDialog.Show("Record Successfully Finalized.", "Finalize", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EditMode(False)
        Else
            VDialog.Show("Record not finalized.", "Finalize", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Canceled()
        If m_BillingOrder.Canceled Then
            VDialog.Show("Record Successfully Canceled.", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EditMode(False)
        Else
            VDialog.Show("Record not canceled.", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Sub InsertItemToGrid(ByVal row As DataGridViewRow, ByVal item As Items)
        row.Cells(colCode.Index).Value = item.ItemCode
        row.Cells(colCode.Index).Tag = item.ItemCode
        row.Cells(colDescription.Index).Value = item.ItemBrand
        row.Cells(colListPrice.Index).Value = DistributorItems.GetListPrice(txtCompany.Text, item.ItemCode)

    End Sub

    Private Sub ShowData(ByVal BillingOrderID As Integer)
        dgDetails.Enabled = False
        m_BillingOrder = BillingOrder.Load(BillingOrderID)

        Dim ShipTo As CustomerShipTo = CustomerShipTo.Load(m_BillingOrder.CustomerId)
        Dim Dist As Distributor = Distributor.LoadByCode(ShipTo.COMID)
        Dim _SalesMan As MedicalRep = MedicalRep.LoadByCode(m_BillingOrder.SalesManCode)
        Dim Formula As Double = 0

        Formula = ((m_BillingOrder.GrossDiscount / m_BillingOrder.GrossTotal) * 100)

        txtSONumber.Tag = BillingOrderID
        txtSONumber.Text = m_BillingOrder.BillingOrderNumber
        dtSOdate.Text = m_BillingOrder.TransactionDate
        txtInvoiceNumber.Text = m_BillingOrder.InvoiceNumber
        dtInvoiceDate.Text = m_BillingOrder.InvoiceDate
        txtSalesmanCodes.Text = _SalesMan.SalesAgentCode
        txtSalesmancode.Text = _SalesMan.SalesAgentName
        txtCompany.Text = Dist.DISTCOMID
        txtCompanyName.Text = Dist.DISTNAME
        txtCustomer.Tag = ShipTo.CUSTOMERSHIPTOID
        txtCustomer.Text = ShipTo.CDANAME
        txtCustomerAddress.Text = m_BillingOrder.Address
        txtCustomerShipTo.Text = ShipTo.CDACD
        txtCustromerShioToAddress.Text = ShipTo.CDACADD2
        txtRemarks.Text = m_BillingOrder.Remarks
        txtDiscFormula.Text = Formula.ToString("#,##0.00")
        txtGrossTotal.Text = m_BillingOrder.GrossTotal.ToString("#,##0.00")
        txtDiscTotal.Text = m_BillingOrder.GrossDiscount.ToString("#,##0.00")
        txtNetTotal.Text = m_BillingOrder.NetTotal.ToString("#,##0.00")

        dgDetails.Rows.Clear()

        For m As Integer = 0 To m_BillingOrder.BillingOrderDetailsCollection.Count - 1
            Dim row As DataGridViewRow = dgDetails.Rows(dgDetails.Rows.Add)
            Dim det As BillingOrderDetails = m_BillingOrder.BillingOrderDetailsCollection(m)
            row.Cells(colCode.Index).Value = det.ItemID
            row.Cells(colDescription.Index).Value = Items.GetItemName(det.ItemID)
            row.Cells(colListPrice.Index).Value = det.ListPrice.ToString("#,##0.00")
            row.Cells(colDiscFormula.Index).Value = det.Discount
            row.Cells(colDiscAmount.Index).Value = det.DiscountAmount.ToString("#,##0.00")
            row.Cells(colTotal.Index).Value = det.Amount.ToString("#,##0.00")
            row.Cells(colQty.Index).Value = det.Quantity.ToString("#,##0")
            row.Cells(colIsFree.Index).Value = det.IsFreeGoods
            row.Cells(colRemarks.Index).Value = det.Remarks
            row.Tag = det

        Next
    End Sub

    Private Sub SalesEntryConcise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UcItemGrid1.InitializeControl()
        ApplyGridTheme(dgDetails)
        'ApplyGridTheme(dgPreview)
        NewRecord()
        dtSOdate.Focus()
    End Sub


    Private Sub UcItemGrid1_ItemSelected(ByVal ItemCode As String, ByVal ItemDescription As String) Handles UcItemGrid1.ItemSelected
        If txtCustomer.Text = String.Empty And txtCustomerShipTo.Text = String.Empty Then
            VDialog.Show("Please Select Customer and CustomerShipTo", "Sales Entry Concise", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If
        Dim item As Items = Items.LoadByCode(ItemCode)
        Dim row2 As DataGridViewRow = dgDetails.Rows(dgDetails.Rows.Add)
        InsertItemToGrid(row2, item)
        row2.Cells(colRemarks.Index).Value = ""
    End Sub

    Private Function ComputedTotalDetails(ByVal Quantity As Double, ByVal ListPirce As Double) As Double
        Return Quantity * ListPirce
    End Function

    Private Function ComputedDiscountTotal(ByVal DiscountFormula As Double, ByVal Amount As Double) As Double
        Return (DiscountFormula / 100) * Amount
    End Function

    Private Sub dgDetails_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellEndEdit
        If e.RowIndex = -1 Then Exit Sub
        Dim Amount As Double = 0
        Dim Price As Double = 0
        Dim GrossAmount As Double = 0
        Dim Total As Double = 0
        Dim DisountAmt As Double = 0
        Dim TotalDiscount As Double = 0
        Dim Formula As Double = 0

        Dim row As DataGridViewRow = dgDetails.Rows(e.RowIndex)
        If row.Cells(colCode.Index).Value Is Nothing Then Exit Sub

        If CDbl(row.Cells(colIsFree.Index).Value) = True Then
            row.Cells(colListPrice.Index).Value = Price.ToString("#,##0.00")
            row.Cells(colDiscFormula.Index).Value = ""
            row.Cells(colDiscAmount.Index).Value = DisountAmt.ToString("#,##0.00")
            row.Cells(colDiscFormula.Index).ReadOnly = True
        End If

        If row.Cells(colQty.Index).Value <> 0 Then
            Amount = ComputedTotalDetails(row.Cells(colQty.Index).Value, row.Cells(colListPrice.Index).Value)
            GrossAmount = ComputedTotalDetails(row.Cells(colQty.Index).Value, row.Cells(colListPrice.Index).Value)
            If row.Cells(colDiscFormula.Index).Value = "" Then
                DisountAmt = "0.00"
            Else
                DisountAmt = ComputedDiscountTotal(CDbl(row.Cells(colDiscFormula.Index).Value), Amount)
            End If

        End If

        If DisountAmt = 0 Then
            row.Cells(colTotal.Index).Value = Amount.ToString("#,##0.00")
            row.Cells(colamount.Index).Value = GrossAmount.ToString("#,##0.00")
        Else
            row.Cells(colTotal.Index).Value = (Amount - DisountAmt).ToString("#,##0.00")
            row.Cells(colamount.Index).Value = GrossAmount.ToString("#,##0.00")
            row.Cells(colDiscAmount.Index).Value = DisountAmt.ToString("#,##0.00")
        End If

        For j As Integer = 0 To dgDetails.Rows.Count - 1
            DisountAmt = dgDetails.Rows(j).Cells(colDiscAmount.Index).Value
            GrossAmount = dgDetails.Rows(j).Cells(colamount.Index).Value
            Total += GrossAmount
            TotalDiscount += DisountAmt
        Next

        If row.Cells(colDiscFormula.Index).Value = "" Then
            row.Cells(colDiscAmount.Index).Value = "0.00"
        End If

        txtGrossTotal.Text = Total.ToString("#,##0.00")
        txtDiscTotal.Text = TotalDiscount.ToString("#,##0.00")
        txtNetTotal.Text = (Total - TotalDiscount).ToString("#,##0.00")
        If TotalDiscount <> 0 Then
            txtDiscFormula.Text = ((TotalDiscount / Total) * 100.0).ToString("#,##0.00")
        Else
            txtDiscFormula.Text = "0.00"
        End If
    End Sub

    Private Sub dgDetails_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellEnter
        If e.RowIndex = -1 Then Exit Sub
        Dim Amount As Double = 0
        Dim Price As Double = 0
        Dim GrossAmount As Double = 0
        Dim Total As Double = 0
        Dim DisountAmt As Double = 0
        Dim TotalDiscount As Double = 0
        Dim Formula As Double = 0

        Dim row As DataGridViewRow = dgDetails.Rows(e.RowIndex)
        If row.Cells(colCode.Index).Value Is Nothing Then Exit Sub

        If CDbl(row.Cells(colIsFree.Index).Value) = True Then
            row.Cells(colListPrice.Index).Value = Price.ToString("#,##0.00")
            row.Cells(colDiscFormula.Index).Value = ""
            row.Cells(colDiscAmount.Index).Value = DisountAmt.ToString("#,##0.00")
            row.Cells(colDiscFormula.Index).ReadOnly = True
        End If

        If row.Cells(colQty.Index).Value <> 0 Then
            Amount = ComputedTotalDetails(row.Cells(colQty.Index).Value, row.Cells(colListPrice.Index).Value)
            GrossAmount = ComputedTotalDetails(row.Cells(colQty.Index).Value, row.Cells(colListPrice.Index).Value)
            If row.Cells(colDiscFormula.Index).Value = "" Then
                DisountAmt = "0.00"
            Else
                DisountAmt = ComputedDiscountTotal(CDbl(row.Cells(colDiscFormula.Index).Value), Amount)
            End If

        End If

        If DisountAmt = 0 Then
            row.Cells(colTotal.Index).Value = Amount.ToString("#,##0.00")
            row.Cells(colamount.Index).Value = GrossAmount.ToString("#,##0.00")
        Else
            row.Cells(colTotal.Index).Value = (Amount - DisountAmt).ToString("#,##0.00")
            row.Cells(colamount.Index).Value = GrossAmount.ToString("#,##0.00")
            row.Cells(colDiscAmount.Index).Value = DisountAmt.ToString("#,##0.00")
        End If

        For j As Integer = 0 To dgDetails.Rows.Count - 1
            DisountAmt = dgDetails.Rows(j).Cells(colDiscAmount.Index).Value
            GrossAmount = dgDetails.Rows(j).Cells(colamount.Index).Value
            Total += GrossAmount
            TotalDiscount += DisountAmt
        Next

        If row.Cells(colDiscFormula.Index).Value = "" Then
            row.Cells(colDiscAmount.Index).Value = "0.00"
        End If

        txtGrossTotal.Text = Total.ToString("#,##0.00")
        txtDiscTotal.Text = TotalDiscount.ToString("#,##0.00")
        txtNetTotal.Text = (Total - TotalDiscount).ToString("#,##0.00")
        If TotalDiscount <> 0 Then
            txtDiscFormula.Text = ((TotalDiscount / Total) * 100.0).ToString("#,##0.00")
        Else
            txtDiscFormula.Text = "0.00"
        End If

    End Sub

    Private Sub DeleteSelected()
        m_ForDeletes.Clear()

        Dim m_HasSelected As Boolean = False
        For m As Integer = 0 To dgDetails.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetails.Rows(m)
            If row.Cells(colSelectedDetails.Index).Value = True Then
                m_HasSelected = True
                Exit For
            End If
        Next
        If Not m_HasSelected Then Exit Sub
        Dim q As MsgBoxResult
        q = VDialog.Show("Are you sure you want to delete the selected items?", "Delete Selected", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If q = MsgBoxResult.Yes Then
            For m As Integer = 0 To dgDetails.Rows.Count - 1
                Dim row As DataGridViewRow = dgDetails.Rows(m)
                If row.Cells(colSelectedDetails.Index).Value = True Then
                    Dim det As BillingOrderDetails
                    If Not row.Tag Is Nothing Then
                        det = row.Tag
                        det.MarkForDelete = True
                    End If
                    m_ForDeletes.Add.ID = m
                End If
            Next

            For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
                dgDetails.Rows.RemoveAt(m_ForDeletes(m).ID)
            Next
        End If
    End Sub

    Private Sub lnkRemoveItem_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkRemoveItem.LinkClicked
        DeleteSelected()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim Tag As SelectionTag = ShowSearchDialog(MedicalRep.GetMedicalRepColumns, MedicalRep.GetMedicalRepSql(txtSalesmanCodes.Text), "Search Salesman")
        If Not Tag Is Nothing Then
            ShowSaleman(Tag.KeyColumn1)
        End If
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Panel2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.Click

    End Sub

    Private Sub dgDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick

    End Sub

    Private Sub dgDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgDetails.KeyDown

    End Sub


    Private Sub BasePageHeader1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BasePageHeader1.Load

    End Sub
End Class
