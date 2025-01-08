Imports SPMSOPCI.ConnectionModule
Imports System.Data
Imports System.Data.SqlClient

Public Class ucRebatesTagging

    Dim rb As New Rebates
    Dim m_rawdata As New RawData
    Dim rawidcaller As Integer
    Dim percentage As Double
    Dim dt As New DataTable
    Dim dv As New DataView
    Dim holdertable As New DataTable
    Dim m_searcher As New DataView
    Dim rowindex As Integer
    Dim checker As New DataGridViewCheckBoxColumn
    Dim m_customernumberfilter As String
    Dim m_invoicenumberfilter As String
    Dim m_compmoyr As New RebatesCompanyMonthYear
    Dim m_colleccompmoyr As New RebatesCompanyMonthYearCollection

    '-----
    Dim selcompany As String

    Dim rbcache As New RebatesCache
    '----

    Dim ctr As Integer


    Private Sub ucRebatesTagging_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'prevents the user for editing the combobox
        cboxcompcode.DropDownStyle = ComboBoxStyle.DropDownList
        cboxCutMonth.DropDownStyle = ComboBoxStyle.DropDownList
        cboxCutYR.DropDownStyle = ComboBoxStyle.DropDownList

        ApplyGridTheme(rebatedgv)

        FillComboBox()

    End Sub

    Private Sub FillComboBox()
        m_colleccompmoyr = m_compmoyr.YearLoader


        For x As Integer = 0 To m_colleccompmoyr.Count - 1
            cboxCutYR.Items.Add(m_colleccompmoyr.Item(x).Year)
        Next

        m_colleccompmoyr = m_compmoyr.MonthLoader

        For x As Integer = 0 To m_colleccompmoyr.Count - 1
            cboxCutMonth.Items.Add(m_colleccompmoyr.Item(x).Month)
        Next

        m_colleccompmoyr = m_compmoyr.CompanyCodeLoader("RawData")

        For x As Integer = 0 To m_colleccompmoyr.Count - 1
            cboxcompcode.Items.Add(m_colleccompmoyr.Item(x).CompanyCode)
        Next


    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_tabPage As TabPage = Me.Parent
        CType(m_tabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_tabPage)
        Me.Dispose()
    End Sub


    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click

        Dim selectedcompcode As String = cboxcompcode.Text
        Dim selectedcutmo As Integer = cboxCutMonth.Text
        Dim selectedcutyr As Integer = cboxCutYR.Text


        If VerifyCompCode() = True And VerifyCutMo() = True And VerifyCutYr() = True Then



            FillRebatesDG(selectedcompcode, selectedcutmo, selectedcutyr, "")

            rebatedgv.Columns("colRawDataID").Visible = False
            rebatedgv.AutoResizeColumns()


            For xy As Integer = 0 To rebatedgv.Columns.Count - 1
                If xy = 0 Then
                    rebatedgv.Columns(xy).ReadOnly = False
                Else
                    rebatedgv.Columns(xy).ReadOnly = True
                End If
            Next

            txtCustNum.Text = ""
            txtInvNum.Text = ""

            txtCustNum.Enabled = True
            txtInvNum.Enabled = True

        End If

    End Sub

    '=====
    Private Sub FillRebatesDG(ByVal compcode As String, ByVal cmonth As Integer, ByVal cyear As Integer, ByVal cNumber As String)
        Dim r_collec As New RawDataCollection
        Dim m_rawdataget As New RawData


        '   rbcache.InitializedCache(compcode, cmonth, cyear)

        rebatedgv.Columns.Clear()


        rebatedgv.AllowUserToAddRows = False
        rebatedgv.MultiSelect = True

        checker.CellTemplate = New DataGridViewCheckBoxCell()

        rebatedgv.Columns.Add(checker)

        Dim x As Integer = 0

        If cNumber = "" Then
            ' r_collec = m_rawdataget.GetData(compcode, cmonth, cyear, "")
            r_collec = RawData.Filter("not exists (Select * from Rebates rb where rb.CustomerNumber=rawdata.CustomerNumber and rb.ItemNumber=rawdata.ItemNumber and rb.InvoiceNumber=rawdata.InvoiceNumber and rb.CutMo= rawdata.CutMo and rb.CutYear= rawdata.CutYear) and CUTMO=" & cmonth & "and CUTYEAR= " & cyear & "and CompanyCode= '" & compcode & "'")
            x = r_collec.Count
        Else
            '            r_collec = m_rawdataget.GetData(compcode, cmonth, cyear, cNumber)
            r_collec = RawData.Filter("not exists (Select * from Rebates rb where rb.CustomerNumber=rawdata.CustomerNumber and rb.ItemNumber=rawdata.ItemNumber and rb.InvoiceNumber=rawdata.InvoiceNumber and rb.CutMo= rawdata.CutMo and rb.CutYear= rawdata.CutYear) and CUTMO=" & cmonth & "and CUTYEAR= " & cyear & "and CompanyCode= '" & compcode & "'")

            x = r_collec.Count
        End If

        rebatedgv.Columns.Add("colCompanyCode", "CompanyCode")
        rebatedgv.Columns.Add("colCustomerNumber", "CustomerNumber")
        rebatedgv.Columns.Add("colCustomerName", "CustomerName")
        rebatedgv.Columns.Add("colCustomerAddress1", "CustomerAddress1")
        rebatedgv.Columns.Add("colCustomerAddress2", "CustomerAddress2")
        rebatedgv.Columns.Add("colTransactionDate", "TransactionDate")
        rebatedgv.Columns.Add("colInvoiceNumber", "InvoiceNumber")
        rebatedgv.Columns.Add("colItemNumber", "ItemNumber")
        rebatedgv.Columns.Add("colItemDescription", "ItemDescription")
        rebatedgv.Columns.Add("colQuantitySold", "QuantitySold")
        rebatedgv.Columns.Add("colQuantityFree", "QuantityFree")
        rebatedgv.Columns.Add("colNetAmount", "NetAmount")
        rebatedgv.Columns.Add("colCUTMO", "CUTMO")
        rebatedgv.Columns.Add("colCUTYEAR", "CUTYEAR")
        rebatedgv.Columns.Add("colRawDataID", "RawDataID")


        For i As Integer = 0 To x - 1
            Dim rows As DataGridViewRow = rebatedgv.Rows(rebatedgv.Rows.Add)

            rows.Cells("colCompanyCode").Value = r_collec.Item(i).CompanyCode
            rows.Cells("colCustomerNumber").Value = r_collec.Item(i).CustomerNumber
            rows.Cells("colCustomerName").Value = r_collec.Item(i).CustomerName
            rows.Cells("colCustomerAddress1").Value = r_collec.Item(i).CustomerAddress
            rows.Cells("colCustomerAddress2").Value = r_collec.Item(i).CustomerAddress2
            rows.Cells("colTransactionDate").Value = r_collec.Item(i).TranscationDate
            rows.Cells("colInvoiceNumber").Value = r_collec.Item(i).InvoiceNumber
            rows.Cells("colItemNumber").Value = r_collec.Item(i).ItemNumber
            rows.Cells("colItemDescription").Value = r_collec.Item(i).ItemDescription
            rows.Cells("colQuantitySold").Value = r_collec.Item(i).QuantitySold
            rows.Cells("colQuantityFree").Value = r_collec.Item(i).QuantityFree
            rows.Cells("colNetAmount").Value = r_collec.Item(i).NetAmount
            rows.Cells("colCUTMO").Value = r_collec.Item(i).CutMO
            rows.Cells("colCUTYEAR").Value = r_collec.Item(i).CutYear
            rows.Cells("colRawDataID").Value = r_collec.Item(i).RawDataID

        Next

    End Sub

    '=====


    Dim chckdrow As New List(Of Integer)


    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Try
        '    For z As Integer = 0 To rebatedgv.Rows.Count - 1
        '        If TypeOf rebatedgv.Rows(z).Cells(0) Is DataGridViewCheckBoxCell Then
        '            Dim checkboxvalidator As DataGridViewCheckBoxCell = rebatedgv.Rows(z).Cells(0)

        '            rebatedgv.CommitEdit(DataGridViewDataErrorContexts.Commit)

        '            Dim checked As Boolean = CType(checkboxvalidator.Value, Boolean)

        '            If checked = True Then
        '                chckdrow.Add(z)
        '            Else
        '                chckdrow.Remove(z)
        '            End If

        '        Else
        '            Exit Sub
        '        End If
        '    Next
        'Catch ex As Exception

        'End Try

        'If VerifyRebatePercentage() = True Then

        '    For Each y As Integer In chckdrow
        '        Dim rawdat2 As New RawData
        '        Dim rbsave As New Rebates

        '        rawdat2 = RawData.Load(rebatedgv.Rows(y).Cells("colRawDataID").Value)

        '        rbsave.CompanyCode = rawdat2.CompanyCode
        '        rbsave.CustomerNumber = rawdat2.CustomerNumber
        '        rbsave.CustomerName = rawdat2.CustomerName
        '        rbsave.CustomerAddress1 = rawdat2.CustomerAddress
        '        rbsave.CustomerAddress2 = rawdat2.CustomerAddress2
        '        rbsave.TransactionDate = rawdat2.TranscationDate
        '        rbsave.ItemNumber = rawdat2.ItemNumber
        '        rbsave.InvoiceNumber = rawdat2.InvoiceNumber
        '        rbsave.ItemDescription = rawdat2.ItemDescription
        '        rbsave.QuantitySold = rawdat2.QuantitySold
        '        rbsave.QuantityFree = rawdat2.QuantityFree
        '        rbsave.NetAmount = rawdat2.NetAmount
        '        rbsave.CutMo = rawdat2.CutMO
        '        rbsave.CutYear = rawdat2.CutYear
        '        rbsave.Status = 0
        '        rbsave.RebatesPercentage = Val(txtrebpercent.Text / 100)
        '        rbsave.RebatesValue = rawdat2.NetAmount * Val(txtrebpercent.Text / 100)
        '        rbsave.Save()

        '    Next y

        '    txtCustNum.Text = ""
        '    txtInvNum.Text = ""
        '    txtrebpercent.Text = ""


        '    FillRebatesDG(cboxcompcode.Text, cboxCutMonth.Text, cboxCutYR.Text, "")
        '    rebatedgv.AutoResizeColumns()

        '    For x As Integer = 0 To rebatedgv.Columns.Count - 1
        '        If x = 0 Then
        '            rebatedgv.Columns(x).ReadOnly = False
        '        Else
        '            rebatedgv.Columns(x).ReadOnly = True
        '        End If
        '    Next

        '    For Each row As DataGridViewRow In rebatedgv.Rows
        '        row.Cells(0).Value = False
        '    Next

        '    chckdrow.Clear()

        '    ctr = 0

        'Else
        '    MsgBox("ERROR")
        'End If
    End Sub


    Private Sub Filter()
        rbcache.CustomerNumber = txtCustNum.Text
        rbcache.InvoiceNumber = txtInvNum.Text

        '        rebatedgv.DataSource = rbcache.DVFilter()
    End Sub

    Private Sub CustNum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustNum.TextChanged

        Filter()

    End Sub

    Private Sub InvNum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvNum.TextChanged

        Filter()

    End Sub

    Private Function VerifyCompCode() As Boolean

        If cboxcompcode.Text = "" Then
            MsgBox("Select a Company")
        Else
            cboxcompcode.Text = cboxcompcode.Text
            Return True
        End If
        Return False

    End Function

    Private Function VerifyCutMo() As Boolean

        If cboxCutMonth.Text = "" Then
            MsgBox("Select a Month")
        Else
            cboxCutMonth.Text = cboxCutMonth.Text
            Return True
        End If
        Return False

    End Function

    Private Function VerifyCutYr() As Boolean

        If cboxCutYR.Text = "" Then
            MsgBox("Select a Year")
        Else
            cboxCutYR.Text = cboxCutYR.Text
            Return True
        End If

        Return False

    End Function


    Private Function VerifyRebatePercentage() As Boolean

        If txtrebpercent.Text = "" Then
            MsgBox("Enter percentage")
        Else
            txtrebpercent.Text = Val(txtrebpercent.Text)
            Return True
        End If

    End Function


    Private NonNumbers As Boolean = False

    Private Sub Rebpercent_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtrebpercent.KeyDown
        NonNumbers = False

        If e.KeyValue = 110 OrElse e.KeyValue = 46 Then
            If (txtrebpercent.Text.IndexOf(".") > -1) Then
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


    Private Sub cboxcompcode_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboxcompcode.SelectedIndexChanged

        Dim selecteditem As String = cboxcompcode.Items(cboxcompcode.SelectedIndex)

        selcompany = selecteditem

        cboxcompcode.Text = selcompany

    End Sub


    Private Sub cboxmo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboxCutMonth.SelectedIndexChanged

        Dim selecteditem As String = cboxCutMonth.Items(cboxCutMonth.SelectedIndex)

        cboxCutMonth.Text = selecteditem

    End Sub


    Private Sub cboxyr_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboxCutYR.SelectedIndexChanged

        Dim selecteditem As String = cboxCutYR.Items(cboxCutYR.SelectedIndex)

        cboxCutYR.Text = selecteditem

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            For z As Integer = 0 To rebatedgv.Rows.Count - 1
                If TypeOf rebatedgv.Rows(z).Cells(0) Is DataGridViewCheckBoxCell Then
                    Dim checkboxvalidator As DataGridViewCheckBoxCell = rebatedgv.Rows(z).Cells(0)

                    rebatedgv.CommitEdit(DataGridViewDataErrorContexts.Commit)

                    Dim checked As Boolean = CType(checkboxvalidator.Value, Boolean)

                    If checked = True Then
                        chckdrow.Add(z)
                    Else
                        chckdrow.Remove(z)
                    End If

                Else
                    Exit Sub
                End If
            Next
        Catch ex As Exception

        End Try

        If VerifyRebatePercentage() = True Then

            For Each y As Integer In chckdrow
                Dim rawdat2 As New RawData
                Dim rbsave As New Rebates

                rawdat2 = RawData.Load(rebatedgv.Rows(y).Cells("colRawDataID").Value)

                rbsave.CompanyCode = rawdat2.CompanyCode
                rbsave.CustomerNumber = rawdat2.CustomerNumber
                rbsave.CustomerName = rawdat2.CustomerName
                rbsave.CustomerAddress1 = rawdat2.CustomerAddress
                rbsave.CustomerAddress2 = rawdat2.CustomerAddress2
                rbsave.TransactionDate = rawdat2.TranscationDate
                rbsave.ItemNumber = rawdat2.ItemNumber
                rbsave.InvoiceNumber = rawdat2.InvoiceNumber
                rbsave.ItemDescription = rawdat2.ItemDescription
                rbsave.QuantitySold = rawdat2.QuantitySold
                rbsave.QuantityFree = rawdat2.QuantityFree
                rbsave.NetAmount = rawdat2.NetAmount
                rbsave.CutMo = rawdat2.CutMO
                rbsave.CutYear = rawdat2.CutYear
                rbsave.Status = 0
                rbsave.RebatesPercentage = Val(txtrebpercent.Text / 100)
                rbsave.RebatesValue = rawdat2.NetAmount * Val(txtrebpercent.Text / 100)
                rbsave.Save()

            Next y

            txtCustNum.Text = ""
            txtInvNum.Text = ""
            txtrebpercent.Text = ""


            FillRebatesDG(cboxcompcode.Text, cboxCutMonth.Text, cboxCutYR.Text, "")
            rebatedgv.AutoResizeColumns()

            For x As Integer = 0 To rebatedgv.Columns.Count - 1
                If x = 0 Then
                    rebatedgv.Columns(x).ReadOnly = False
                Else
                    rebatedgv.Columns(x).ReadOnly = True
                End If
            Next

            For Each row As DataGridViewRow In rebatedgv.Rows
                row.Cells(0).Value = False
            Next

            chckdrow.Clear()

            ctr = 0

        Else
            MsgBox("ERROR")
        End If
    End Sub
End Class
