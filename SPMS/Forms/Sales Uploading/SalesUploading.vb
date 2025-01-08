Public Class SalesUploading

    Private m_OpenFolder As OpenFileDialog = New OpenFileDialog
    Dim table As New DataTable
    Dim dt As New DataTable

    Dim _ExcelResult As New SalesExcelUploading
    Private m_rawData As New RawData
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False

    Private Sub lblUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBrowseFile.Click, lblUpload.Click, lblClose.Click

        If sender Is lblBrowseFile Then
            BrowseFile()
        ElseIf sender Is lblClose Then
            Me.Close()
        ElseIf sender Is lblUpload Then
            If ValidateData() Then
                UploadFile()
            End If
        End If

    End Sub


    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False
        If cmbCompany.Text = String.Empty Or cmbCompany.Text Is Nothing Then
            m_Err.SetError(cmbCompany, "Channel is required")
            m_HasError = True
        End If

        If cmbYear.Text = String.Empty Or cmbYear.Text Is Nothing Then
            m_Err.SetError(cmbYear, "Year is required")
            m_HasError = True
        End If


        Return Not m_HasError
    End Function
    Private Sub PopulateComboBox()

        table = GetRecords("SELECT * FROM DISTRIBUTOR WHERE DLTFLG = 0")
        For I As Integer = 0 To table.Rows.Count - 1
            cmbCompany.Items.Add(table.Rows(I)("DISTCOMID"))
        Next
    End Sub
    Private Sub UploadFile()

        Try

            If txtfile.Text = "" Then

                MsgBox("No file to be uploaded", MsgBoxStyle.Information, "Please select file")
                Exit Sub
            End If
            ProgressBar1.Visible = True

            loadView()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BrowseFile()

        _ExcelResult.CompanyCode = cmbCompany.Text
        OpenFileDialog1.Title = "Sales"
        If cmbFiletype.Text = ".XLS" Then
            OpenFileDialog1.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*"
        Else
            OpenFileDialog1.Filter = "Text files(*.txt)|*.txt"
        End If
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtfile.Text = OpenFileDialog1.FileName
        End If

    End Sub


    Private Sub loadView()
        Try

            If _ExcelResult.CheckIfExist(txtfile.Text) Then
                dt = _ExcelResult.GetExcelData(txtfile.Text)
                If dt.Rows.Count = 0 Then
                    MsgBox("No Record Upload!!!")
                Else
                    Uploading()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Uploading()

        Dim ctr As Integer = 0
        Dim TotalQuantity As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim ProductDiscount As Decimal = 0
        Dim _Month As String = String.Empty

        If Len(cmbMonth.Text) = 1 Then
            _Month = "0" + cmbMonth.Text
        Else
            _Month = cmbMonth.Text
        End If

        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then

            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                If Not dr("COMPANY CODE") = cmbCompany.Text Then Exit Sub

                If IsDBNull(dr("COMPANY CODE")) Then Exit For

                m_rawData = New RawData
                m_rawData.CompanyCode = dr("COMPANY CODE")
                m_rawData.TranscationDate = dr("TRANS DATE")
                If dr("Amount") < 0 Then
                    m_rawData.TransactionType = "CR"
                Else
                    m_rawData.TransactionType = "IV"
                End If

                If IsDBNull(dr("INVOICE #")) Then
                    m_rawData.InvoiceNumber = ""
                Else
                    m_rawData.InvoiceNumber = dr("INVOICE #")
                End If
                m_rawData.SalesmanNumber = dr("DETAILMAN #")
                m_rawData.SalesmanName = dr("SALESMAN")
                m_rawData.CustomerNumber = dr("CUSTOMER CODE")
                m_rawData.CustomerName = dr("CUSTOMER NAME")
                m_rawData.CustomerAddress = dr("CUSTOMER ADDRESS")
                m_rawData.ItemNumber = dr("ITEM CODE")
                m_rawData.ItemDescription = dr("ITEM NAME")
                m_rawData.QuantitySold = dr("SOLD QTY")
                m_rawData.QuantityFree = dr("FREE GOODS")
                TotalQuantity = TotalQuantity + dr("SOLD QTY")
                m_rawData.UnitPrice = dr("UNIT PRICE")
                m_rawData.LineDiscount = dr("% DISCOUNT")
                m_rawData.GrossAmount = dr("AMOUNT")
                m_rawData.NetAmount = dr("AMOUNT")
                GrossAmount = GrossAmount + dr("AMOUNT")
                m_rawData.CutMO = _Month
                m_rawData.CutYear = cmbYear.Text
                m_rawData.ShipToName = dr("CUSTOMER NAME")
                m_rawData.ShipToAddress1 = dr("CUSTOMER ADDRESS")
                m_rawData.CustomerDeliveryCode = "001"

                ctr += 1
                m_rawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "' ,'" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        Else
            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                If Not dr("COMPANY CODE") = cmbCompany.Text Then Exit Sub

                If IsDBNull(dr("COMPANY CODE")) Then Exit For

                m_rawData = New RawData
                m_rawData.CompanyCode = dr("COMPANY CODE")
                m_rawData.TranscationDate = dr("TRANS DATE")
                If dr("Amount") < 0 Then
                    m_rawData.TransactionType = "CR"
                Else
                    m_rawData.TransactionType = "IV"
                End If

                If IsDBNull(dr("INVOICE #")) Then
                    m_rawData.InvoiceNumber = ""
                Else
                    m_rawData.InvoiceNumber = dr("INVOICE #")
                End If

                m_rawData.SalesmanNumber = dr("DETAILMAN #")
                m_rawData.SalesmanName = dr("SALESMAN")
                m_rawData.CustomerNumber = dr("CUSTOMER CODE")
                m_rawData.CustomerName = dr("CUSTOMER NAME")
                m_rawData.CustomerAddress = dr("CUSTOMER ADDRESS")
                m_rawData.ItemNumber = dr("ITEM CODE")
                m_rawData.ItemDescription = dr("ITEM NAME")
                m_rawData.QuantitySold = dr("SOLD QTY")
                m_rawData.QuantityFree = dr("FREE GOODS")
                TotalQuantity = TotalQuantity + dr("SOLD QTY")
                m_rawData.UnitPrice = dr("UNIT PRICE")
                m_rawData.LineDiscount = dr("% DISCOUNT")
                m_rawData.GrossAmount = dr("AMOUNT")
                m_rawData.NetAmount = dr("AMOUNT")
                GrossAmount = GrossAmount + dr("AMOUNT")
                m_rawData.CutMO = _Month
                m_rawData.CutYear = cmbYear.Text
                m_rawData.ShipToName = dr("CUSTOMER NAME")
                m_rawData.ShipToAddress1 = dr("CUSTOMER ADDRESS")
                m_rawData.CustomerDeliveryCode = "001"

                ctr += 1
                m_rawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")

        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()

    End Sub


    Private Sub SalesUploading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateComboBox()
        Timer1.Enabled = False
    End Sub

    Private Sub cmbFiletype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFiletype.SelectedIndexChanged
        lblBrowseFile.Enabled = True
    End Sub

    'Private Sub cmbCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
    '    cmbFiletype.Enabled = True
    'End Sub

    Private Sub LoadYear(ByVal DistributorCode As String)
        table = GetRecords("SELECT Distinct CAYR  FROM Calendar WHERE COMID = '" & DistributorCode & "' ")
        For i As Integer = 0 To table.Rows.Count - 1
            cmbYear.Items.Add(table.Rows(i)("CAYR"))
        Next
        _ExcelResult.Year = cmbYear.Text
    End Sub

    Private Sub LoadMonth(ByVal DistributorCode As String, ByVal Year As String)

        table = GetRecords("SELECT * FROM Calendar WHERE COMID = '" & DistributorCode & "' AND CAYR = '" & Year & "' ")
        For I As Integer = 0 To table.Rows.Count - 1
            cmbMonth.Items.Add(table.Rows(I)("CAPN"))
        Next
        _ExcelResult.Month = cmbMonth.Text
    End Sub

    Private Sub cmbYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.SelectedIndexChanged
        If cmbYear.SelectedIndex = -1 Then Exit Sub
        LoadMonth(cmbCompany.Text, cmbYear.Text)
    End Sub

    Private Sub cmbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedIndexChanged
        lblBrowseFile.Enabled = True

    End Sub

    Private Sub cmbCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        If cmbCompany.SelectedIndex = -1 Then Exit Sub
        LoadYear(cmbCompany.Text)
    End Sub



End Class