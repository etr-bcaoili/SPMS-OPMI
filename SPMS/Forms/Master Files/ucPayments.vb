Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class ucPayments

    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Dim r_rebatespayment As New RebatesPayment
    Dim dtholder As New DataTable
    Dim checkbx As New DataGridViewCheckBoxColumn
    Dim recordIDholder As Integer

    Dim rebfetched As New Rebates
    Dim m_customernumberfilter As String
    Dim m_invoicenumberfilter As String
    Dim dvRB As New DataView
    Private m_IsNewMode As Boolean = True
    Dim userlog As New UserLogin

    Dim r_rebatespaymentverify As New RebatesPaymentCollection

    Dim m_compmoyr As New RebatesCompanyMonthYear
    Dim m_colleccompmoyr As New RebatesCompanyMonthYearCollection


    '=====
    Dim rebcache As New RebatesCache
    '=====
    Private m_rep As New MedicalRep
    Private Sub ucPayments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'prevents the user from editing the combobox
        cboxCompCode.DropDownStyle = ComboBoxStyle.DropDownList
        cboxMonth.DropDownStyle = ComboBoxStyle.DropDownList
        cboxYear.DropDownStyle = ComboBoxStyle.DropDownList

        ApplyGridTheme(rebatesdgv)

        FillComboBox()

        btnSave.Enabled = False



    End Sub

    Private Sub FillComboBox()
        m_colleccompmoyr = m_compmoyr.YearLoader


        For x As Integer = 0 To m_colleccompmoyr.Count - 1
            cboxYear.Items.Add(m_colleccompmoyr.Item(x).Year)
        Next

        m_colleccompmoyr = m_compmoyr.MonthLoader

        For x As Integer = 0 To m_colleccompmoyr.Count - 1
            cboxMonth.Items.Add(m_colleccompmoyr.Item(x).Month)
        Next

        m_colleccompmoyr = m_compmoyr.CompanyCodeLoader("Rebates")

        For x As Integer = 0 To m_colleccompmoyr.Count - 1
            cboxCompCode.Items.Add(m_colleccompmoyr.Item(x).CompanyCode)
        Next


    End Sub


    Private Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Load.Click

        Dim selectedcompany As String = cboxCompCode.Text
        Dim selectedmonth As String = cboxMonth.Text
        Dim selectedyear As String = cboxYear.Text

        If VerifyCompCode() = True Then 'And VerifyCutMo() = True And VerifyCutYr() = True Then

            txtcustNumber.Text = ""
            txtinvoicenum.Text = ""
            txtcheckNum.Text = ""
            txtrebateAmt.Text = ""
            txtremainingBal.Text = ""
            txtPaymentAmt.Text = ""

            FillRebatesDGV(selectedcompany, selectedmonth, selectedyear, "")

            rebatesdgv.Columns("colRecordID").Visible = False
            rebatesdgv.AutoResizeColumns()

            For colcount As Integer = 0 To rebatesdgv.Columns.Count - 1
                If colcount = 0 Then
                    rebatesdgv.Columns(colcount).ReadOnly = False
                Else
                    rebatesdgv.Columns(colcount).ReadOnly = True
                End If
            Next

        End If

    End Sub


    Private Sub Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close.Click
        On Error Resume Next
        Dim m_tabPage As TabPage = Me.Parent
        CType(m_tabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_tabPage)
        Me.Dispose()
    End Sub

    '=====
    Private Sub FillRebatesDGV(ByVal cCompcode As String, ByVal cCutMonth As Integer, ByVal cCutYear As Integer, ByVal cCNumber As String)

        Dim rb_collect As New RebatesCollection
        Dim x As Integer = 0

        rebatesdgv.Columns.Clear()

        rebatesdgv.AllowUserToAddRows = False
        rebatesdgv.MultiSelect = True
        checkbx.CellTemplate = New DataGridViewCheckBoxCell()

        rebatesdgv.Columns.Add(checkbx)

        rb_collect = Rebates.Load(cCompcode, cCutMonth, cCutYear)
        x = rb_collect.Count

        rebatesdgv.Columns.Add("colCompanyCode", "CompanyCode")
        rebatesdgv.Columns.Add("colCustomerNumber", "CustomerNumber")
        rebatesdgv.Columns.Add("colCustomerName", "CustomerName")
        rebatesdgv.Columns.Add("colCustomerAddress1", "CustomerAddress1")
        rebatesdgv.Columns.Add("colCustomerAddress2", "CustomerAddress2")
        rebatesdgv.Columns.Add("colTransactionDate", "TransactionDate")
        rebatesdgv.Columns.Add("colInvoiceNumber", "InvoiceNumber")
        rebatesdgv.Columns.Add("colItemNumber", "ItemNumber")
        rebatesdgv.Columns.Add("colItemDescription", "ItemDescription")
        rebatesdgv.Columns.Add("colQuantitySold", "QuantitySold")
        rebatesdgv.Columns.Add("colQuantityFree", "QuantityFree")
        rebatesdgv.Columns.Add("colNetAmount", "NetAmount")
        rebatesdgv.Columns.Add("colCUTMO", "CUTMO")
        rebatesdgv.Columns.Add("colCUTYEAR", "CUTYEAR")
        rebatesdgv.Columns.Add("colRecordID", "RecordID")
        rebatesdgv.Columns.Add("colRebatesPercentage", "RebatesPercentage")
        rebatesdgv.Columns.Add("colRebatesValue", "RebatesValue")


        For i As Integer = 0 To x - 1

            Dim rows As DataGridViewRow = rebatesdgv.Rows(rebatesdgv.Rows.Add)

            rows.Cells("colCompanyCode").Value = rb_collect.Item(i).CompanyCode
            rows.Cells("colCustomerNumber").Value = rb_collect.Item(i).CustomerNumber
            rows.Cells("colCustomerName").Value = rb_collect.Item(i).CustomerName
            rows.Cells("colCustomerAddress1").Value = rb_collect.Item(i).CustomerAddress1
            rows.Cells("colCustomerAddress2").Value = rb_collect.Item(i).CustomerAddress2
            rows.Cells("colTransactionDate").Value = rb_collect.Item(i).TransactionDate
            rows.Cells("colInvoiceNumber").Value = rb_collect.Item(i).InvoiceNumber
            rows.Cells("colItemNumber").Value = rb_collect.Item(i).ItemNumber
            rows.Cells("colItemDescription").Value = rb_collect.Item(i).ItemDescription
            rows.Cells("colQuantitySold").Value = rb_collect.Item(i).QuantitySold
            rows.Cells("colQuantityFree").Value = rb_collect.Item(i).QuantityFree
            rows.Cells("colNetAmount").Value = rb_collect.Item(i).NetAmount
            rows.Cells("colCUTMO").Value = rb_collect.Item(i).CutMo
            rows.Cells("colCUTYEAR").Value = rb_collect.Item(i).CutYear
            rows.Cells("colRecordID").Value = rb_collect.Item(i).RecordID
            rows.Cells("colRebatesPercentage").Value = rb_collect.Item(i).RebatesPercentage
            rows.Cells("colRebatesValue").Value = rb_collect.Item(i).RebatesValue

        Next

    End Sub


    '=====

    Private Sub SelectedCell(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim chckdcell As Integer = 0
        Dim ictr As Integer = 0
        Try

            If TypeOf rebatesdgv.Rows(e.RowIndex).Cells(0) Is DataGridViewCheckBoxCell Then
                Dim checkboxvalidator As DataGridViewCheckBoxCell = rebatesdgv.Rows(e.RowIndex).Cells(0)

                rebatesdgv.CommitEdit(DataGridViewDataErrorContexts.Commit)

                Dim checked As Boolean = CType(checkboxvalidator.Value, Boolean)

                If checked = True Then

                    recordIDholder = rebatesdgv("colRecordID", e.RowIndex).Value
                    rebfetched = Rebates.Load(recordIDholder)

                    txtrebateAmt.Text = rebfetched.RebatesValue
                    ' txtPayTo.Text = rebfetched.CustomerName
                    r_rebatespaymentverify = RebatesPayment.Filter(rebfetched.CompanyCode, rebfetched.CutMo, rebfetched.CutYear)
                    ictr = r_rebatespaymentverify.Count

                    For i As Integer = 0 To ictr - 1

                        If rebfetched.CompanyCode = r_rebatespaymentverify.Item(i).CompanyCode And rebfetched.CutMo = r_rebatespaymentverify.Item(i).CutMo _
                            And rebfetched.CutYear = r_rebatespaymentverify.Item(i).CutYear And rebfetched.InvoiceNumber = r_rebatespaymentverify.Item(i).InvoiceNumber _
                            And rebfetched.ItemNumber = r_rebatespaymentverify.Item(i).ItemNumber Then

                            r_rebatespayment.RemainingBalance = r_rebatespaymentverify.Item(i).RemainingBalance
                            txtremainingBal.Text = r_rebatespayment.RemainingBalance

                        End If
                    Next

                Else
                    txtrebateAmt.Text = ""
                    txtremainingBal.Text = ""
                End If

            Else
                Exit Sub
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Compute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Compute.Click
        If VerifyPaymentAmount() = True And VerifyCheckNumber() = True Then

            If Val(txtremainingBal.Text) = 0 Then

                txtremainingBal.Text = Val(txtrebateAmt.Text) - Val(txtPaymentAmt.Text)

            Else

                txtremainingBal.Text = Val(txtremainingBal.Text) - Val(txtPaymentAmt.Text)

            End If

            btnSave.Enabled = True

        End If


    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim r_rebatespaymentdone As New RebatesPayment

        'r_rebatespaymentdone.CompanyCode = rebfetched.CompanyCode
        'r_rebatespaymentdone.CustomerNumber = rebfetched.CustomerNumber
        'r_rebatespaymentdone.CustomerName = rebfetched.CustomerName
        'r_rebatespaymentdone.CustomerAddress1 = rebfetched.CustomerAddress1
        'r_rebatespaymentdone.CustomerAddress2 = rebfetched.CustomerAddress2
        'r_rebatespaymentdone.TransactionDate = rebfetched.TransactionDate
        'r_rebatespaymentdone.InvoiceNumber = rebfetched.InvoiceNumber
        'r_rebatespaymentdone.ItemNumber = rebfetched.ItemNumber
        'r_rebatespaymentdone.ItemDescription = rebfetched.ItemDescription
        'r_rebatespaymentdone.QuantitySold = rebfetched.QuantitySold
        'r_rebatespaymentdone.QuantityFree = rebfetched.QuantityFree
        'r_rebatespaymentdone.NetAmount = rebfetched.NetAmount
        'r_rebatespaymentdone.CutMo = rebfetched.CutMo
        'r_rebatespaymentdone.CutYear = rebfetched.CutYear
        'r_rebatespaymentdone.RebatesPercentage = rebfetched.RebatesPercentage
        'r_rebatespaymentdone.RebatesValue = rebfetched.RebatesValue
        'r_rebatespaymentdone.CheckNumber = txtcheckNum.Text
        'r_rebatespaymentdone.CheckDate = dtpCheckDate.Text
        'r_rebatespaymentdone.PayTo = txtPayTo.Text
        'r_rebatespaymentdone.PaymentAmount = Val(txtPaymentAmt.Text)
        'r_rebatespaymentdone.RemainingBalance = Val(txtremainingBal.Text)
        'r_rebatespaymentdone.SalesCodes = txtSaleAgentCode.Text
        'If Val(txtremainingBal.Text) = 0 Or Val(txtremainingBal.Text) < 0 Then
        '    r_rebatespaymentdone.Status = RebatesPayment.enumStatus.FullPayment
        'ElseIf Val(txtremainingBal.Text) > 0 Then
        '    r_rebatespaymentdone.Status = RebatesPayment.enumStatus.PartialPayment
        'ElseIf Val(txtremainingBal.Text) = Val(txtrebateAmt) Then
        '    r_rebatespaymentdone.Status = RebatesPayment.enumStatus.Unpaid
        'End If

        'r_rebatespaymentdone.Save()
        'clears()

        'FillRebatesDGV(cboxCompCode.Text, cboxMonth.Text, cboxYear.Text, "")
        ''rebatesdgv.DataSource = Fetch(cboxCompCode.Text, cboxYear.Text, cboxMonth.Text, "")
        'rebatesdgv.AutoResizeColumns()

        '.Enabled = False

    End Sub

    Private Sub clears()
        txtcustNumber.Text = String.Empty
        txtPaymentAmt.Text = String.Empty
        txtPayTo.Text = String.Empty
        txtremainingBal.Text = String.Empty
        txtSaleAgentCode.Text = String.Empty
        txtSaleAgentName.Text = String.Empty
        txtrebateAmt.Text = String.Empty
    End Sub

    Private Sub Filter()
        rebcache.CustomerNumber = txtcustNumber.Text
        rebcache.InvoiceNumber = txtinvoicenum.Text

        '    rebatesdgv.DataSource = rebcache.DVFilter(dtholder)
    End Sub

    Private Function VerifyCompCode() As Boolean
        m_Err.Clear()
        m_HasError = False

        If cboxCompCode.Text = "" Then
            m_Err.SetError(cboxCompCode, "Select the Company")
            m_HasError = True

        ElseIf cboxYear.Text = "" Then
            m_Err.SetError(cboxYear, "Select the Year")
            m_HasError = True

        ElseIf cboxMonth.Text = "" Then
            m_Err.SetError(cboxMonth, "Select then Month")
            m_HasError = True

            'ElseIf cboxCompCode.Text = "" Then
            '    MsgBox("Select a Company")
            'ElseIf cboxYear.Text = "" Then
            '    MsgBox("Select a Year")
            'ElseIf cboxMonth.Text = "" Then
            '    MsgBox("Select a Month")

        Else
            cboxCompCode.Text = cboxCompCode.Text
            cboxYear.Text = cboxYear.Text
            cboxMonth.Text = cboxMonth.Text

            Return True
        End If
        Return False

    End Function

    Private Function VerifyCutMo() As Boolean

        If cboxMonth.Text = "" Then
            MsgBox("Select a Month")
        Else
            cboxMonth.Text = cboxMonth.Text
            Return True
        End If
        Return False

    End Function
    Private Function Varifytext() As Boolean
        m_Err.Clear()
        m_HasError = False

        If txtcheckNum.Text = "" Then
            m_Err.SetError(txtcheckNum, "Please Enter the Check Number")
            m_HasError = True
        ElseIf txtPayTo.Text = "" Then
            m_Err.SetError(txtPayTo, "Enter the Payment Person")
            m_HasError = True
        ElseIf txtSaleAgentCode.Text = "" Then
            m_Err.SetError(txtSaleAgentCode, "SaleAgentCode was empty")
            m_HasError = True
        ElseIf txtSaleAgentName.Text = "" Then
            m_Err.SetError(txtSaleAgentName, "SaleAgentName was empty")
            m_HasError = True
        End If

        If m_IsNewMode Then
            If Not CheckIfItemExist(txtcheckNum.Text) Then
                ShowExclamation("CheckNumber is Already Exits", "CheckNumber")
                m_HasError = True
            End If
        End If

        Return Not m_HasError


    End Function

    Private Function CheckIfItemExist(ByVal ItemCode As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM RebatesDetail WHERE checkNumber = '" & ItemCode & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount = 0 Then
            Return True
        End If
        Return False
    End Function

    Private Function VerifyCutYr() As Boolean

        If cboxYear.Text = "" Then
            MsgBox("Select a Year")
        Else
            cboxYear.Text = cboxYear.Text
            Return True
        End If

        Return False

    End Function

    Private Function VerifyPaymentAmount() As Boolean
        m_Err.Clear()
        m_HasError = False

        If txtPaymentAmt.Text = "" Then
            m_Err.SetError(txtPaymentAmt, "Please Enter the Amount")
            m_HasError = True
            'ElseIf txtPaymentAmt.Text = "" Then
            '    MsgBox("Enter amount")
        Else
            txtPaymentAmt.Text = Val(txtPaymentAmt.Text)
            Return True
        End If
        Return False
    End Function

    Private Function VerifyCheckNumber() As Boolean
        m_Err.Clear()
        m_HasError = False
        If txtcheckNum.Text = "" Then
            m_Err.SetError(txtcheckNum, "Enter the CheckNumber")
            m_HasError = True
        Else
            txtcheckNum.Text = txtcheckNum.Text
            Return True
        End If

    End Function


    Private Sub txtcustNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcustNumber.TextChanged

        Filter()

    End Sub


    Private Sub txtinvoicenum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtinvoicenum.TextChanged

        Filter()

    End Sub



    Private NonNumbers As Boolean = False

    Private Sub Payment_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        NonNumbers = False

        If e.KeyValue = 110 Or e.KeyValue = 46 Then
            If (txtPaymentAmt.Text.IndexOf(".") > -1) Then
                e.SuppressKeyPress = True
            End If
        ElseIf e.KeyCode < Keys.D0 Or e.KeyCode > Keys.D9 Then
            If e.KeyCode < Keys.NumPad0 Or e.KeyCode > Keys.NumPad9 Then
                If e.KeyCode <> Keys.Back Then
                    e.SuppressKeyPress = True
                    NonNumbers = True
                End If
            End If
        End If

    End Sub


    Private Sub cboxcompcode_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboxCompCode.SelectedIndexChanged

        Dim selecteditem As String = cboxCompCode.Items(cboxCompCode.SelectedIndex)

        cboxCompCode.Text = selecteditem

    End Sub


    Private Sub cboxmo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboxMonth.SelectedIndexChanged

        Dim selecteditem As String = cboxMonth.Items(cboxMonth.SelectedIndex)

        cboxMonth.Text = selecteditem

    End Sub


    Private Sub cboxyr_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboxYear.SelectedIndexChanged

        Dim selecteditem As String = cboxYear.Items(cboxYear.SelectedIndex)

        cboxYear.Text = selecteditem

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If txtPayTo.Text <> "" Then
            Dim tag As SelectionTag = ShowSearchDialog(MedicalRep.GetMedicalRepColumns, MedicalRep.GetMedicalRepSql, "Sales Agent")
            If Not tag Is Nothing Then
                LoadSalesAgent(tag.KeyColumn2)
            End If
        End If

    End Sub
    Private Sub LoadSalesAgent(ByVal LoadRep As String)
        m_rep = MedicalRep.LoadByCode(LoadRep)
        txtSaleAgentName.Text = m_rep.SalesAgentName
        txtSaleAgentCode.Text = m_rep.SalesAgentCode

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Varifytext() = True Then
            Saved()
        End If
    End Sub

    Private Function Saved() As Boolean

        Dim r_rebatespaymentdone As New RebatesPayment

        r_rebatespaymentdone.CompanyCode = rebfetched.CompanyCode
        r_rebatespaymentdone.CustomerNumber = rebfetched.CustomerNumber
        r_rebatespaymentdone.CustomerName = rebfetched.CustomerName
        r_rebatespaymentdone.CustomerAddress1 = rebfetched.CustomerAddress1
        r_rebatespaymentdone.CustomerAddress2 = rebfetched.CustomerAddress2
        r_rebatespaymentdone.TransactionDate = rebfetched.TransactionDate
        r_rebatespaymentdone.InvoiceNumber = rebfetched.InvoiceNumber
        r_rebatespaymentdone.ItemNumber = rebfetched.ItemNumber
        r_rebatespaymentdone.ItemDescription = rebfetched.ItemDescription
        r_rebatespaymentdone.QuantitySold = rebfetched.QuantitySold
        r_rebatespaymentdone.QuantityFree = rebfetched.QuantityFree
        r_rebatespaymentdone.NetAmount = rebfetched.NetAmount
        r_rebatespaymentdone.CutMo = rebfetched.CutMo
        r_rebatespaymentdone.CutYear = rebfetched.CutYear
        r_rebatespaymentdone.RebatesPercentage = rebfetched.RebatesPercentage
        r_rebatespaymentdone.RebatesValue = rebfetched.RebatesValue
        r_rebatespaymentdone.CheckNumber = txtcheckNum.Text
        r_rebatespaymentdone.CheckDate = dtpCheckDate.Text
        r_rebatespaymentdone.PayTo = txtPayTo.Text
        r_rebatespaymentdone.PaymentAmount = Val(txtPaymentAmt.Text)
        r_rebatespaymentdone.RemainingBalance = Val(txtremainingBal.Text)
        r_rebatespaymentdone.SalesCodes = txtSaleAgentCode.Text
        If Val(txtremainingBal.Text) = 0 Or Val(txtremainingBal.Text) < 0 Then
            r_rebatespaymentdone.Status = RebatesPayment.enumStatus.FullPayment
        ElseIf Val(txtremainingBal.Text) > 0 Then
            r_rebatespaymentdone.Status = RebatesPayment.enumStatus.PartialPayment
        ElseIf Val(txtremainingBal.Text) = Val(txtrebateAmt) Then
            r_rebatespaymentdone.Status = RebatesPayment.enumStatus.Unpaid
        End If

        r_rebatespaymentdone.Save()


        FillRebatesDGV(cboxCompCode.Text, cboxMonth.Text, cboxYear.Text, "")
        'rebatesdgv.DataSource = Fetch(cboxCompCode.Text, cboxYear.Text, cboxMonth.Text, "")
        rebatesdgv.AutoResizeColumns()

        clears()

        btnSave.Enabled = False
    End Function

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
