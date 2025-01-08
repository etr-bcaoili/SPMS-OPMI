Imports SPMSOPCI.ConnectionModule
Imports System.Data.OleDb
Imports System.IO
Imports System
Imports System.Collections
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class frmInHouseRawData

    Dim table As New DataTable
    Dim dt As New DataTable
    Dim _ExcelResult As New ExcelInhouseUploading
    Private m_Err As New ErrorProvider
    Private m_RawData As New RawData
    Private m_HasError As Boolean = False
    Private m_companyName As String
    Private _Distributor As New Distributor
    Private Sub frmInHouseRawData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateComboBox()
        Timer1.Enabled = False
    End Sub

    Private Sub PopulateComboBox()
        If m_CompanyName = "ODI" Then
            table = GetRecords("SELECT DISTCOMID FROM DISTRIBUTOR WHERE DLTFLG = 0 and DISTCOMID = 'ODI'")
            For I As Integer = 0 To table.Rows.Count - 1
                cmbCompany.Items.Add(table.Rows(I)("DISTCOMID"))
            Next
        Else
            table = GetRecords("SELECT * FROM DISTRIBUTOR WHERE DLTFLG = 0")
            For I As Integer = 0 To table.Rows.Count - 1
                cmbCompany.Items.Add(table.Rows(I)("DISTCOMID"))
            Next
        End If
    End Sub

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

    Private Sub lblBrowseFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBrowseFile.Click, lblUpload.Click, lblclose.Click
        If sender Is lblBrowseFile Then
            BrowseFile()
        ElseIf sender Is lblclose Then
            Me.Close()
        ElseIf sender Is lblUpload Then
            If ValidateData() Then
                UploadFile()
            End If
        End If
    End Sub

    Private Sub BrowseFile()
        _ExcelResult.CompanyCode = cmbCompany.Text
        _ExcelResult.Month = cmbMonth.Text
        _ExcelResult.Year = cmbYear.Text
        OpenFileDialog1.Title = "In-HouseRawData Uploading"
        OpenFileDialog1.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtfile.Text = OpenFileDialog1.FileName
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

    Private Sub OpenFile()
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Microsoft Office Excel(*.xls)|*.xls;*.xlsx"
        If (ofd.ShowDialog() = DialogResult.OK) Then
            If ofd.FileName.Length > 255 Then
                ShowExclamation("Path Too Long.", "Sales Agent")
                Exit Sub
            End If
            txtfile.Text = ofd.FileName
        End If
    End Sub

    Private Sub UploadFile()
        If txtfile.Text = "" Then
            MsgBox("No file to be uploaded", MsgBoxStyle.Information, "Please select file")
            Exit Sub
        End If
        ProgressBar1.Visible = True
        loadUploading()
    End Sub

    Private Sub loadUploading()
        If _ExcelResult.CheckIfExist(txtfile.Text) Then
            dt = _ExcelResult.GetExcelData(txtfile.Text)
            If dt.Rows.Count = 0 Then
                MsgBox("Not Record Found", MsgBoxStyle.Critical, "System")
            Else
                loadINH()
            End If
        End If
    End Sub
  
    Private Sub loadINH()
        Dim a As Integer = 20
        Dim b As Integer = 18
        Dim NetAmount As Decimal = 0
        Dim ctr As Integer = 0
        Dim TotalQuantity As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim ProductDiscount As Decimal = 0
        Dim _Month As String = String.Empty
        Dim dateString As String = cmbMonth.Text + "01" + cmbYear.Text
        Dim format As String = "MMddyyyy"

        Dim startDate As Date = DateTime.ParseExact(dateString, format, System.Globalization.CultureInfo.InvariantCulture)

        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                m_RawData = New RawData
                m_RawData.CompanyCode = dr("Channel Code")
                m_RawData.BranchCode = ""
                m_RawData.BranchName = ""
                m_RawData.CustomerNumber = dr("Channel Customer Code")
                m_RawData.CustomerName = dr("Customer Name")
                If IsDBNull(dr("Customer Address 1")) Then
                    m_RawData.CustomerAddress = ""
                    m_RawData.ShipToAddress1 = ""
                Else
                    m_RawData.CustomerAddress = dr("Customer Address 1")
                    m_RawData.ShipToAddress1 = dr("Customer Address 1")
                End If

                If IsDBNull(dr("Customer Address 2")) Then
                    m_RawData.CustomerAddress2 = ""
                    m_RawData.ShipToAddress2 = ""
                Else
                    m_RawData.CustomerAddress2 = dr("Customer Address 2")
                    m_RawData.ShipToAddress2 = dr("Customer Address 2")
                End If

                If IsDBNull(dr("Ship To Code")) Then
                    m_RawData.CustomerDeliveryCode = "001"
                Else
                    m_RawData.CustomerDeliveryCode = dr("Ship To Code")
                End If

                If IsDBNull(dr("Invoice Date")) Then
                    m_RawData.TranscationDate = DateTime.Now
                Else
                    m_RawData.TranscationDate = dr("Invoice Date")
                End If
                If IsDBNull(dr("Invoice Number")) Then
                    m_RawData.InvoiceNumber = String.Empty
                Else
                    m_RawData.InvoiceNumber = dr("Invoice Number").ToString
                End If

                If IsDBNull(dr("Transaction Type")) Then
                    m_RawData.TransactionType = "IV"
                Else
                    m_RawData.TransactionType = dr("Transaction Type")
                End If

                m_RawData.ItemNumber = dr("ItemCode")
                If IsDBNull(dr("ItemName")) Then
                    m_RawData.ItemDescription = ""
                Else
                    m_RawData.ItemDescription = dr("ItemName")
                End If
                m_RawData.QuantitySold = dr("Quantity")
                If IsDBNull(dr("Free")) Then
                    m_RawData.QuantityFree = 0
                Else
                    m_RawData.QuantityFree = dr("Free")
                End If
                TotalQuantity = TotalQuantity + dr("Quantity")
                If dr("Net Value (Inclusive of Vat)") = "0" Then
                    table = GetRecords(Items.GetItempricelist(dr("ItemCode"), cmbCompany.Text, startDate))
                    For i As Integer = 0 To table.Rows.Count - 1
                        m_RawData.GrossAmount = dr("Quantity") * table.Rows(i)("DISTITEMPRICE")
                        m_RawData.UnitPrice = 0
                        _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                        If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                            Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                            Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal
                            Dim number As Double = dr("Quantity") * table.Rows(i)("DISTITEMPRICE")
                            Dim number1 As Double = MuncipalVat * number
                            Dim Number2 As Double = DistMargin * number1
                            m_RawData.NetAmount = Number2
                            NetAmount = NetAmount + Number2
                        Else
                            m_RawData.NetAmount = dr("Quantity") * table.Rows(i)("DISTITEMPRICE")
                        End If
                        GrossAmount = GrossAmount + dr("Quantity") * table.Rows(i)("DISTITEMPRICE")
                    Next
                Else
                    _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                    If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                        Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                        Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal

                        Dim number As Double = dr("Net Value (Inclusive of Vat)")

                        Dim number1 As Double = MuncipalVat * number

                        Dim Number2 As Double = DistMargin * number1

                        m_RawData.NetAmount = Number2

                        NetAmount = NetAmount + Number2
                    Else
                        m_RawData.NetAmount = dr("Net Value (Inclusive of Vat)")
                        m_RawData.GrossAmount = dr("Net Value (Inclusive of Vat)")
                        m_RawData.UnitPrice = 0
                    End If

                    m_RawData.GrossAmount = dr("Net Value (Inclusive of Vat)")
                    m_RawData.UnitPrice = 0
                    GrossAmount = GrossAmount + dr("Net Value (Inclusive of Vat)")
                End If
                'm_RawData.GrossAmount = GrossAmount
                'm_RawData.NetAmount = NetAmount

                m_RawData.LineDiscount = 0
                m_RawData.SalesmanNumber = ""
                m_RawData.SalesmanName = ""
              
                m_RawData.PaymentType = ""
                If IsDBNull(dr("Lot Number")) Then
                    m_RawData.LotNumber = ""
                Else
                    m_RawData.LotNumber = dr("Lot Number")
                End If
                If IsDBNull(dr("Expiry Date")) Then
                    m_RawData.ExpiryDate = ""
                Else
                    m_RawData.ExpiryDate = dr("Expiry Date")
                End If

                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text

                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "' ,'" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & NetAmount & "' )")
        Else

            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                m_RawData = New RawData
                m_RawData.CompanyCode = dr("Channel Code")
                m_RawData.BranchCode = ""
                m_RawData.BranchName = ""
                m_RawData.CustomerNumber = dr("Channel Customer Code")
                m_RawData.CustomerName = dr("Customer Name")
                If IsDBNull(dr("Customer Address 1")) Then
                    m_RawData.CustomerAddress = ""
                    m_RawData.ShipToAddress1 = ""
                Else
                    m_RawData.CustomerAddress = dr("Customer Address 1")
                    m_RawData.ShipToAddress1 = dr("Customer Address 1")
                End If

                If IsDBNull(dr("Customer Address 2")) Then
                    m_RawData.CustomerAddress2 = ""
                    m_RawData.ShipToAddress2 = ""
                Else
                    m_RawData.CustomerAddress2 = dr("Customer Address 2")
                    m_RawData.ShipToAddress2 = dr("Customer Address 2")
                End If

                If IsDBNull(dr("Ship To Code")) Then
                    m_RawData.CustomerDeliveryCode = "001"
                Else
                    m_RawData.CustomerDeliveryCode = dr("Ship To Code")
                End If

                If IsDBNull(dr("Invoice Date")) Then
                    m_RawData.TranscationDate = DateTime.Now
                Else
                    m_RawData.TranscationDate = dr("Invoice Date")
                End If
                If IsDBNull(dr("Invoice Number")) Then
                    m_RawData.InvoiceNumber = String.Empty
                Else
                    m_RawData.InvoiceNumber = dr("Invoice Number").ToString
                End If

                If IsDBNull(dr("Transaction Type")) Then
                    m_RawData.TransactionType = "IV"
                Else
                    m_RawData.TransactionType = dr("Transaction Type")
                End If

                m_RawData.ItemNumber = dr("ItemCode")
                If IsDBNull(dr("ItemName")) Then
                    m_RawData.ItemDescription = ""
                Else
                    m_RawData.ItemDescription = dr("ItemName")
                End If
                m_RawData.QuantitySold = dr("Quantity")
                If IsDBNull(dr("Free")) Then
                    m_RawData.QuantityFree = 0
                Else
                    m_RawData.QuantityFree = dr("Free")
                End If
                TotalQuantity = TotalQuantity + dr("Quantity")
                If dr("Net Value (Inclusive of Vat)") = "0" Then
                    table = GetRecords(Items.GetItempricelist(dr("ItemCode"), cmbCompany.Text, startDate))
                    For i As Integer = 0 To table.Rows.Count - 1
                        m_RawData.GrossAmount = dr("Quantity") * table.Rows(i)("DISTITEMPRICE")
                        m_RawData.UnitPrice = 0

                        _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                        If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                            Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                            Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal
                            Dim number As Double = dr("Quantity") * table.Rows(i)("DISTITEMPRICE")
                            Dim number1 As Double = MuncipalVat * number
                            Dim Number2 As Double = DistMargin * number1
                            m_RawData.NetAmount = Number2
                            NetAmount = NetAmount + Number2
                        Else
                            m_RawData.NetAmount = dr("Quantity") * table.Rows(i)("DISTITEMPRICE")
                        End If

                        GrossAmount = GrossAmount + dr("Quantity") * table.Rows(i)("DISTITEMPRICE")
                    Next
                Else
                    _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                    If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                        Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                        Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal

                        Dim number As Double = dr("Net Value (Inclusive of Vat)")

                        Dim number1 As Double = MuncipalVat * number

                        Dim Number2 As Double = DistMargin * number1

                        m_RawData.NetAmount = Number2

                        NetAmount = NetAmount + Number2
                    Else
                        m_RawData.NetAmount = dr("Net Value (Inclusive of Vat)")
                        m_RawData.GrossAmount = dr("Net Value (Inclusive of Vat)")
                        m_RawData.UnitPrice = 0
                    End If

                    m_RawData.GrossAmount = dr("Net Value (Inclusive of Vat)")
                    m_RawData.UnitPrice = 0
                    'm_RawData.NetAmount = dr("Net Value (Inclusive of Vat)")
                    GrossAmount = GrossAmount + dr("Net Value (Inclusive of Vat)")
                End If
                'm_RawData.GrossAmount = GrossAmount
                'm_RawData.NetAmount = NetAmount
                m_RawData.LineDiscount = 0
                m_RawData.SalesmanNumber = ""
                m_RawData.SalesmanName = ""

                m_RawData.PaymentType = ""
                If IsDBNull(dr("Lot Number")) Then
                    m_RawData.LotNumber = ""
                Else
                    m_RawData.LotNumber = dr("Lot Number")
                End If
                If IsDBNull(dr("Expiry Date")) Then
                    m_RawData.ExpiryDate = ""
                Else
                    m_RawData.ExpiryDate = dr("Expiry Date")
                End If

                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text

                ctr += 1
                m_RawData.Save()
            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & NetAmount & "' )")
        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()
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

    Private Sub lblclose_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblclose.LinkClicked
        Me.Close()
    End Sub

    Private Sub lblUpload_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblUpload.LinkClicked

    End Sub
End Class