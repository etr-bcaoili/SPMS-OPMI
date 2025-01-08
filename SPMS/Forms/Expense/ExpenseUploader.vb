Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class ExpenseUploader
    Private m_FileName As String = String.Empty
    Private m_ExpenseUploading As New ExpenseRawData

    Dim _ExcelResult As New ExceItempricelist

    Private m_ExpenseRawCol As ExpenseRawDataCollection
    Private m_Expense As Expense
    Private m_Err As New ErrorProvider
    Private m_RsMonth As New ADODB.Recordset
    Private m_RsYear As New ADODB.Recordset

    Private Sub lnkClose_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkClose.LinkClicked
        Me.Dispose()
    End Sub

    Private Sub lnkSelectFile_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        OpenFile()
    End Sub

    Private Sub OpenFile()
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Microsoft Office Excel(*.xls)|*.xls;*.xlsx"
        If (ofd.ShowDialog() = DialogResult.OK) Then
            If ofd.FileName.Length > 255 Then
                ShowExclamation("Path Too Long.", "Uploading")
                Exit Sub
            End If
            txtfile.Text = ofd.FileName
        End If
    End Sub

    Private Sub StartUpload()

        m_FileName = txtfile.Text

        Dim con As OleDbConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & m_FileName & " ;Extended Properties=Excel 8.0;")
        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter("SELECT * FROM [Sheet1$]  Where [SalesAgentCode] IS NOT NULL", con)
        da.Fill(dt)
        If dt.Rows.Count = 0 Then
            VDialog.Show("No Record Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            Dim ctr As Integer = 0
            pbar.Visible = True
            For m As Integer = 0 To dt.Rows.Count - 1

                pbar.Value = ctr / dt.Rows.Count * 100

                Dim dr As DataRow = dt.Rows(m)
                If Not dr("SalesAgentCode") = String.Empty Or Not dr("SalesAgentCode") Is Nothing Or Not dr("SalesAgentCode") = "" Then
                    m_ExpenseUploading = New ExpenseRawData

                    m_ExpenseUploading.Amount = dr("ExpenseAmount")
                    m_ExpenseUploading.ExpenseCode = dr("EntryNumber")
                    m_ExpenseUploading.ExpenseDate = dr("ExpenseDate")
                    If IsDBNull(dr("Remarks")) Then
                        m_ExpenseUploading.Remarks = ""
                    Else
                        m_ExpenseUploading.Remarks = dr("Remarks")
                    End If
                    m_ExpenseUploading.ExpenseTypeCode = dr("ExpenseTypeCode")
                    m_ExpenseUploading.SalesAgentCode = dr("SalesAgentCode")
                    m_ExpenseUploading.VAT = dr("VATInclusiveAmount")
                    m_ExpenseUploading.Vat2 = dr("VATExclusiveAmount")
                    m_ExpenseUploading.TotalVat = dr("TotalVAT")
                    m_ExpenseUploading.Accountdescription = dr("Account Description")
                    m_ExpenseUploading.Saves()

                End If
                ctr += 1

            Next

            If ExpenseRawData.UploadExpenseFromSource(cboMonth.Text, cboYear.Text) = 1 Then
                CreateExpense()
                pbar.Visible = False
                ShowInformation("Record Successfully Uploaded", "Expense Uploading")
            End If
        End If

    End Sub

    Private Sub CreateExpense()
        Dim Agent As String() = ExpenseRawData.GetSalesAgentCodeForUpload
        If Agent.Length = 0 Then Exit Sub
        For m As Integer = 0 To Agent.Length - 1

            m_ExpenseRawCol = ExpenseRawData.LoadBySalesAgent(Agent(m))

            If m_ExpenseRawCol.Count > 0 Then
                m_Expense = New Expense
                Dim det As ExpenseDetails
                Dim TotVat As Double = 0
                Dim VatEx As Double = 0
                Dim VatInc As Double = 0
                For l As Integer = 0 To m_ExpenseRawCol.Count - 1
                    det = New ExpenseDetails
                    det.ExpenseAmount = m_ExpenseRawCol(l).Amount
                    det.ExpenseDate = m_ExpenseRawCol(l).ExpenseDate
                    det.ExpenseTypeCode = m_ExpenseRawCol(l).ExpenseCode
                    det.VAT = m_ExpenseRawCol(l).TotalVat
                    det.Remarks = m_ExpenseRawCol(l).Remarks
                    m_Expense.ExpenseDetailsCollection.Add(det)
                    TotVat += m_ExpenseRawCol(l).TotalVat
                    VatEx += (m_ExpenseRawCol(l).Amount - m_ExpenseRawCol(l).TotalVat)
                    VatInc += m_ExpenseRawCol(l).Amount

                Next

                m_Expense.ExpenseDate = GetServerDate.ToShortDateString
                m_Expense.EntryNumber = SystemSequences.GetExpenseNextSequence
                m_Expense.Remarks = "Auto - Generated from Expense Uploader."
                m_Expense.SalesAgentCode = Agent(m)
                m_Expense.TotalVat = TotVat
                m_Expense.VatExclusiveAmount = VatEx
                m_Expense.VatInclusiveAmount = VatInc
                m_Expense.Status = Expense.EnumExpenseStatus.Approved
                m_Expense.Save()

                For Each expraw As ExpenseRawData In m_ExpenseRawCol
                    expraw.Delete()
                Next


            End If
        Next

    End Sub

    Private Sub lnkStartUploading_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStartUploading.LinkClicked
        If ValidateData() Then
            StartUpload()
        End If
    End Sub

    Private Function ValidateData() As Boolean
        Dim m_HasError As Boolean = False
        m_Err.Clear()

        'If CDate(dtFrom.Value.ToShortDateString) > CDate(dtTo.Value.ToShortDateString) Then
        '    m_Err.SetError(dtFrom, "Date From should not be greater than the Date To")
        '    m_HasError = True
        'End If

        If cboMonth.Text = "" Then
            m_Err.SetError(cboMonth, "Month is required.")
            m_HasError = True
        End If

        If cboYear.Text = "" Then
            m_Err.SetError(cboYear, "Year is required.")
            m_HasError = True
        End If

        ExpenseRawData.DeletesExistingData(cboMonth.Text, cboYear.Text)

        Return Not m_HasError
    End Function

    Private Sub ExpenseUploader_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_Err.Clear()
        LoadYear()
    End Sub


    Private Sub LoadMonth(ByVal Year As String)

        If m_RsMonth.State = 1 Then m_RsMonth.Close()
        m_RsMonth.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        m_RsMonth.Open("SELECT * FROM Calendar WHERE COMID = '" & ConnectionModule.GetDefaultCompany & "' AND CAYR = '" & Year & "' ", ConnectionModule.SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsMonth.RecordCount > 0 Then
            cboMonth.Items.Clear()
            For m As Integer = 0 To m_RsMonth.RecordCount - 1
                cboMonth.Items.Add(m_RsMonth.Fields("CAPN").Value)
                m_RsMonth.MoveNext()
            Next
        End If

    End Sub

    Private Sub LoadYear()
        If m_RsYear.State = 1 Then m_RsYear.Close()
        m_RsYear.Open("SELECT Distinct CAYR  FROM Calendar WHERE COMID = '" & ConnectionModule.GetDefaultCompany & "' ", ConnectionModule.SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsYear.RecordCount > 0 Then
            cboYear.Items.Clear()
            For m As Integer = 0 To m_RsYear.RecordCount - 1
                cboYear.Items.Add(m_RsYear.Fields("CAYR").Value)
                m_RsYear.MoveNext()
            Next
        End If
    End Sub

    Private Sub cboYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYear.SelectedIndexChanged
        If cboYear.SelectedIndex = -1 Then Exit Sub
        LoadMonth(cboYear.Text)
    End Sub
    Private Sub BrowseFile()

        OpenFileDialog1.Title = "Expense"
        OpenFileDialog1.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtfile.Text = OpenFileDialog1.FileName
        End If

    End Sub
    Private Sub lblBrowseFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBrowseFile.Click
        OpenFile()
    End Sub
End Class