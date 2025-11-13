Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Imports System.Data.OleDb
Imports System
Imports System.IO
Imports System.Collections
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices.ComTypes
Public Class frmRawDataUploader

    Private m_OpenFolder As OpenFileDialog = New OpenFileDialog
    Dim table As New DataTable
    Dim dt As New DataTable
    Dim _ExcelResult As New ExcelUploading
    Private m_RawData As New RawData
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_CompanyName As String
    Private _Distributor As New Distributor

    Public Property _CompanyName() As String
        Get
            Return m_CompanyName
        End Get
        Set(ByVal value As String)
            m_CompanyName = value
        End Set
    End Property
    Private Sub frmRawDataUploader_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub cmbCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        If cmbCompany.SelectedIndex = -1 Then Exit Sub
        LoadYear(cmbCompany.Text)
    End Sub
    Private Sub cmbYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.SelectedIndexChanged
        If cmbYear.SelectedIndex = -1 Then Exit Sub
        LoadMonth(cmbCompany.Text, cmbYear.Text)
    End Sub
    Private Sub cmbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedIndexChanged
        lblBrowseFile.Enabled = True
    End Sub
    Private Sub lblUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblUpload.Click, lblClose.Click, lblBrowseFile.Click
        If sender Is lblBrowseFile Then
            BrowseFile()
        ElseIf sender Is lblClose Then
            Me.Close()
        ElseIf sender Is lblUpload Then
            If ValidateData() Then
                UploadFile()
                'RawData.UpdateGetConversion(cmbYear.Text, cmbMonth.Text, cmbCompany.Text)
            End If
        End If
    End Sub
    Private Sub BrowseFile()
        _ExcelResult.CompanyCode = cmbCompany.Text
        _ExcelResult.Month = cmbMonth.Text
        _ExcelResult.Year = cmbYear.Text
        OpenFileDialog1.Title = "RawData Uploading"
        If cmbFiletype.Text = ".XLS" Then
            OpenFileDialog1.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*"
        ElseIf cmbFiletype.Text = ".TXT" Then
            OpenFileDialog1.Filter = "Text files(*.txt)|*.txt"
        ElseIf cmbFiletype.Text = ".SP" Then
            OpenFileDialog1.Filter = "SP files(*.SP)|*.SP"
        End If
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
    Private Sub UploadFile()
        If txtfile.Text = "" Then
            MsgBox("No file to be uploaded", MsgBoxStyle.Information, "Please select file")
            Exit Sub
        End If
        ProgressBar1.Visible = True
        If cmbFiletype.Text = ".TXT" Then
            If cmbCompany.Text = "GB" Then
                UploadingGB()
                NonSystemFiles()
            ElseIf cmbCompany.Text = "MDI" Then
                UploadingMDITEXT()
                NonSystemFiles()
            ElseIf cmbCompany.Text = "PM" Then
                UploadingPM()
            ElseIf cmbCompany.Text = "ZPC" Then
                UploadingZPC()
            ElseIf cmbCompany.Text = "WAT" Then
                UploadingWAT()
            ElseIf cmbCompany.Text = "GBD" Then
                UploadingGBD()
                Exit Sub
            End If
        End If
        If cmbFiletype.Text = ".XLS" Then
            loadView()
            Exit Sub
        End If
        If cmbFiletype.Text = ".SP" Then
            uploadingMer()
        End If
    End Sub
    Private Sub NonSystemFiles()
    End Sub

    Private Sub UploadingGB()
        Dim b As Integer = 18
        Dim ctr As Integer = 0
        Dim TotalNetAmount As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim totalQuantity As Decimal = 0
        Dim ProductDiscount As Decimal = 0
        Dim _Month As String = String.Empty
        Dim objReader As New StreamReader(txtfile.Text)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For Each sLine In arrText
                ProgressBar1.Value = ctr / arrText.Count * 100
                m_RawData = New RawData
                m_RawData.CompanyCode = "GB"
                m_RawData.CustomerNumber = Trim(Mid(sLine, 19, 6))
                m_RawData.CustomerName = Trim(Mid(sLine, 25, 50))
                m_RawData.CustomerAddress = Trim(Mid(sLine, 76, 50))
                m_RawData.TranscationDate = Trim(Mid(sLine, 3, 8))
                m_RawData.InvoiceNumber = Trim(Mid(sLine, 11, 8))
                If Trim(Mid(sLine, 167, 9)) < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If
                If Trim(Mid(sLine, 167, 9)) = 0 Then
                    m_RawData.QuantitySold = Trim(Mid(sLine, 167, 9))
                Else
                    m_RawData.QuantityFree = Trim(Mid(sLine, 167, 9))
                End If
                m_RawData.ItemNumber = Trim(Mid(sLine, 125, 20))
                m_RawData.ItemDescription = Trim(Mid(sLine, 140, 20))
                m_RawData.QuantitySold = CDbl(Mid(sLine, 167, 9))
                m_RawData.QuantityFree = CDbl(Mid(sLine, 177, 9))
                m_RawData.NetAmount = CDbl(Mid(sLine, 228, 13))
                TotalNetAmount = TotalNetAmount + CDbl(Mid(sLine, 228, 13))
                m_RawData.GrossAmount = CDbl(Mid(sLine, 195, 13))
                GrossAmount = GrossAmount + CDbl(Mid(sLine, 195, 13))
                m_RawData.ProductDiscount = CDbl(Mid(sLine, 215, 13))
                m_RawData.InvoiceReferenceNumber = -1
                m_RawData.SONumber = -1
                TotalNetAmount = TotalNetAmount + CDbl(Mid(sLine, 228, 13))
                m_RawData.CustomerDeliveryCode = "001"
                m_RawData.OrderType = "N"
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                ctr += 1
                m_RawData.Save()
            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & totalQuantity & "','" & GrossAmount & "' )")
        Else
            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For Each sLine In arrText
                ProgressBar1.Value = ctr / arrText.Count * 100
                m_RawData = New RawData
                m_RawData.CompanyCode = "GB"
                m_RawData.CustomerNumber = Trim(Mid(sLine, 19, 6))
                m_RawData.CustomerName = Trim(Mid(sLine, 25, 50))
                m_RawData.CustomerAddress = Trim(Mid(sLine, 76, 50))
                m_RawData.TranscationDate = Trim(Mid(sLine, 3, 8))
                m_RawData.InvoiceNumber = Trim(Mid(sLine, 11, 8))
                If Trim(Mid(sLine, 167, 9)) < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If
                If Trim(Mid(sLine, 167, 9)) = 0 Then
                    m_RawData.QuantitySold = CDbl(Mid(sLine, 167, 9))
                Else
                    m_RawData.QuantityFree = CDbl(Mid(sLine, 167, 9))
                End If
                m_RawData.ItemNumber = Trim(Mid(sLine, 125, 20))
                m_RawData.ItemDescription = Trim(Mid(sLine, 140, 20))
                m_RawData.QuantitySold = CDbl(Mid(sLine, 167, 9))
                m_RawData.QuantityFree = CDbl(Mid(sLine, 177, 9))
                m_RawData.NetAmount = CDbl(Mid(sLine, 228, 13))
                m_RawData.GrossAmount = CDbl(Mid(sLine, 195, 13))
                m_RawData.ProductDiscount = CDbl(Mid(sLine, 215, 13))
                m_RawData.InvoiceReferenceNumber = -1
                m_RawData.SONumber = -1
                TotalNetAmount = TotalNetAmount + Trim(Mid(sLine, 228, 13))
                m_RawData.CustomerDeliveryCode = "001"
                m_RawData.OrderType = "N"
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                ctr += 1
                m_RawData.Save()
            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & totalQuantity & "','" & GrossAmount & "' )")
        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()
    End Sub

    Private Sub UploadingGBD()

        Dim b As Integer = 18
        Dim ctr As Integer = 0
        Dim TotalNetAmount As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim totalQuantity As Decimal = 0
        Dim ProductDiscount As Decimal = 0
        Dim _Month As String = String.Empty


        Dim objReader As New StreamReader(txtfile.Text)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()



        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For Each sLine In arrText
                ProgressBar1.Value = ctr / arrText.Count * 100
                m_RawData = New RawData

                m_RawData.CompanyCode = cmbCompany.Text
                m_RawData.CustomerNumber = Trim(Mid(sLine, 19, 7))
                m_RawData.CustomerName = Trim(Mid(sLine, 26, 45))
                m_RawData.CustomerAddress = Trim(Mid(sLine, 71, 50))
                m_RawData.CustomerAddress2 = Trim(Mid(sLine, 71, 50))
                m_RawData.TranscationDate = Trim(Mid(sLine, 3, 8))
                m_RawData.InvoiceNumber = Trim(Mid(sLine, 11, 8))
                If Trim(Mid(sLine, 167, 9)) < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If

                m_RawData.ItemNumber = Trim(Mid(sLine, 125, 18))
                m_RawData.ItemDescription = Trim(Mid(sLine, 144, 25))
                m_RawData.QuantitySold = CDbl(Mid(sLine, 166, 9))
                m_RawData.QuantityFree = CDbl(Mid(sLine, 175, 9))
                m_RawData.NetAmount = Trim(Mid(sLine, 228, 10))
                TotalNetAmount = TotalNetAmount + Trim(Mid(sLine, 228, 10))
                m_RawData.GrossAmount = Trim(Mid(sLine, 194, 11))
                GrossAmount = GrossAmount + Trim(Mid(sLine, 194, 11))
                m_RawData.ProductDiscount = Trim(Mid(sLine, 194, 11))
                m_RawData.UnitPrice = Trim(Mid(sLine, 184, 9))
                m_RawData.InvoiceReferenceNumber = -1
                m_RawData.SONumber = -1
                TotalNetAmount = TotalNetAmount + Trim(Mid(sLine, 226, 10))
                m_RawData.CustomerDeliveryCode = "001"
                m_RawData.OrderType = "N"
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                'm_RawData.UploadDate = dtStart.Text
                'm_RawData.EffectivityStartDate = dtStart.Text
                'm_RawData.EffectivityEndDate = dtEnd.Text
                ctr += 1
                m_RawData.Save()

            Next

            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & totalQuantity & "','" & GrossAmount & "' )")

        Else


            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For Each sLine In arrText
                ProgressBar1.Value = ctr / arrText.Count * 100
                m_RawData = New RawData

                m_RawData.CompanyCode = cmbCompany.Text
                m_RawData.CustomerNumber = Trim(Mid(sLine, 19, 7))
                m_RawData.CustomerName = Trim(Mid(sLine, 26, 45))
                m_RawData.CustomerAddress = Trim(Mid(sLine, 71, 50))
                m_RawData.CustomerAddress2 = Trim(Mid(sLine, 71, 50))
                m_RawData.TranscationDate = Trim(Mid(sLine, 3, 8))
                m_RawData.InvoiceNumber = Trim(Mid(sLine, 11, 8))
                If Trim(Mid(sLine, 167, 9)) < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If

                m_RawData.ItemNumber = Trim(Mid(sLine, 125, 18))
                m_RawData.ItemDescription = Trim(Mid(sLine, 144, 25))
                m_RawData.QuantitySold = CDbl(Mid(sLine, 166, 9))
                m_RawData.QuantityFree = CDbl(Mid(sLine, 175, 9))
                m_RawData.NetAmount = Trim(Mid(sLine, 228, 10))
                TotalNetAmount = TotalNetAmount + Trim(Mid(sLine, 228, 10))
                m_RawData.GrossAmount = Trim(Mid(sLine, 194, 11))
                GrossAmount = GrossAmount + Trim(Mid(sLine, 194, 11))
                m_RawData.ProductDiscount = Trim(Mid(sLine, 194, 11))
                m_RawData.UnitPrice = Trim(Mid(sLine, 184, 9))
                m_RawData.InvoiceReferenceNumber = -1
                m_RawData.SONumber = -1
                TotalNetAmount = TotalNetAmount + Trim(Mid(sLine, 226, 10))
                m_RawData.CustomerDeliveryCode = "001"
                m_RawData.OrderType = "N"
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                'm_RawData.UploadDate = dtStart.Text
                'm_RawData.EffectivityStartDate = dtStart.Text
                'm_RawData.EffectivityEndDate = dtEnd.Text

                ctr += 1
                m_RawData.Save()

            Next

            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & totalQuantity & "','" & GrossAmount & "' )")

        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()

    End Sub

    Private Sub UploadingMDITEXT()
        Dim b As Integer = 18
        Dim ctr As Integer = 0
        Dim TotalNetAmountIV As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim totalQuantityCR As Decimal = 0
        Dim TotalGrossAmountCR As Decimal = 0
        Dim TotalProductDiscountCR As Decimal = 0
        Dim totalQuantityIV As Decimal = 0
        Dim TotalGrossAmountIV As Decimal = 0
        Dim TotalProductDiscountIV As Decimal = 0
        Dim TotalNetAmountCR As Decimal = 0
        Dim _Month As String = String.Empty
        Dim TotalQuantity As Decimal = 0
        Dim TotalProductDicount As Decimal = 0
        Dim TotalGrossAmount As Decimal = 0
        Dim TotalNetAmount As Decimal = 0
        Dim objReader As New StreamReader(txtfile.Text)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For Each sLine In arrText
                ProgressBar1.Value = ctr / arrText.Count * 100
                m_RawData = New RawData
                m_RawData.CompanyCode = -1
                m_RawData.CompanyCode = "MDI"
                m_RawData.BranchCode = Trim(Mid(sLine, 3, 3))
                m_RawData.BranchName = Trim(Mid(sLine, 6, 24))
                m_RawData.CustomerNumber = Trim(Mid(sLine, 30, 6))
                m_RawData.CustomerName = Trim(Mid(sLine, 36, 50))
                m_RawData.CustomerAddress = Trim(Mid(sLine, 86, 50))
                m_RawData.CustomerAddress2 = Trim(Mid(sLine, 136, 50))
                m_RawData.TranscationDate = Trim(Mid(sLine, 186, 8))
                m_RawData.InvoiceNumber = Trim(Mid(sLine, 194, 8))
                m_RawData.TransactionType = Trim(Mid(sLine, 202, 2))
                m_RawData.ItemNumber = Trim(Mid(sLine, 204, 20))
                m_RawData.ItemDescription = Trim(Mid(sLine, 224, 20))
                m_RawData.WarehouseNumber = Trim(Mid(sLine, 224, 3))
                If Trim(Mid(sLine, 202, 2)) = "CR" Then
                    m_RawData.QuantitySold = (CDbl(Mid(sLine, 250, 9)) * -1)
                    totalQuantityCR += (0 - CDbl(Mid(sLine, 259, 9)))
                    m_RawData.QuantityFree = (CDbl(Mid(sLine, 259, 9)) * -1)
                    m_RawData.GrossAmount = (CDbl(Mid(sLine, 268, 13)) / 100) * -1
                    TotalGrossAmountCR += (CDbl(Mid(sLine, 268, 13)) / 100) * -1
                    m_RawData.LineDiscount = (CDbl(Mid(sLine, 281, 7)) / 10000) * -1
                    m_RawData.ProductDiscount = (CDbl(Mid(sLine, 288, 13)) / 100) * -1
                    TotalProductDiscountCR += (CDbl(Mid(sLine, 288, 13)) / 100) * -1
                Else
                    m_RawData.QuantitySold = CDbl(Mid(sLine, 250, 9))
                    totalQuantityIV += CDbl(Mid(sLine, 250, 9))
                    m_RawData.QuantityFree = CDbl(Mid(sLine, 259, 9))
                    m_RawData.GrossAmount = CDbl(Mid(sLine, 268, 13)) / 100
                    TotalGrossAmountIV += CDbl(Mid(sLine, 268, 13)) / 100
                    m_RawData.LineDiscount = CDbl(Mid(sLine, 281, 7)) / 10000
                    m_RawData.ProductDiscount = CDbl(Mid(sLine, 288, 13)) / 100
                    TotalProductDiscountIV += CDbl(Mid(sLine, 288, 13)) / 100
                    TotalQuantity = totalQuantityCR + totalQuantityIV
                End If
                m_RawData.VatCode = Trim(Mid(sLine, 301, 1))
                m_RawData.Route = Trim(Mid(sLine, 653, 4))
                m_RawData.Taxes = CDbl(Mid(sLine, 308, 13)) / 100
                m_RawData.Freight = CDbl(Mid(sLine, 321, 13)) / 100
                m_RawData.Additional = 0
                If Trim(Mid(sLine, 202, 2)) = "CR" Then
                    m_RawData.NetAmount = (CDbl(Mid(sLine, 347, 13)) / 100) * -1
                    TotalNetAmountCR += (CDbl(Mid(sLine, 347, 13)) / 100) * -1
                Else
                    m_RawData.NetAmount = (CDbl(Mid(sLine, 347, 13)) / 100)
                    TotalNetAmountIV += (CDbl(Mid(sLine, 347, 13)) / 100)
                End If
                TotalGrossAmount = TotalGrossAmountIV
                TotalNetAmount = TotalNetAmountIV
                TotalProductDicount = TotalProductDiscountIV
                m_RawData.UnitPrice = CDbl(Mid(sLine, 360, 9)) / 100
                m_RawData.InvoiceReferenceNumber = Val(Mid(sLine, 369, 8))
                m_RawData.CMCode = Trim(Mid(sLine, 377, 8))
                m_RawData.SONumber = Trim(Mid(sLine, 380, 8))
                m_RawData.SODate = Trim(Mid(sLine, 388, 8))
                m_RawData.SOTerms = Trim(Mid(sLine, 396, 6))
                m_RawData.ExpiryDate = Trim(Mid(sLine, 402, 8))
                m_RawData.LotNumber = Trim(Mid(sLine, 410, 15))
                m_RawData.SalesmanNumber = Trim(Mid(sLine, 425, 3))
                m_RawData.SalesmanName = Trim(Mid(sLine, 428, 24))
                m_RawData.ShipToName = Trim(Mid(sLine, 452, 50))
                m_RawData.ShipToAddress1 = Trim(Mid(sLine, 502, 50))
                m_RawData.ShipToAddress2 = Trim(Mid(sLine, 552, 50))
                m_RawData.Zipcode = Trim(Mid(sLine, 602, 6))
                m_RawData.TerritoryNumber = Trim(Mid(sLine, 608, 3))
                m_RawData.Area = Trim(Mid(sLine, 611, 3))
                m_RawData.CustomerClass = Trim(Mid(sLine, 611, 3))
                m_RawData.ClassName = Trim(Mid(sLine, 247, 3))
                m_RawData.Principal = Trim(Mid(sLine, 641, 3))
                m_RawData.SubPrincipal = Trim(Mid(sLine, 644, 6))
                m_RawData.PrincipalDivisionCode = Trim(Mid(sLine, 650, 3))
                m_RawData.SalesWeek = Trim(Mid(sLine, 653, 1))
                If Trim(Mid(sLine, 654, 3)) = "" Then
                    m_RawData.CustomerDeliveryCode = "001"
                Else
                    m_RawData.CustomerDeliveryCode = Trim(Mid(sLine, 654, 3))
                End If
                m_RawData.ListOfTaxIncluse = ""
                m_RawData.ContractPrincipalApprovalNumber = ""
                m_RawData.OrderType = "N"
                m_RawData.IsCode = ""
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                ctr += 1
                m_RawData.Save()
            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount,TotalProductDisc) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & TotalGrossAmount & "','" & TotalQuantity & "','" & TotalNetAmount & "','" & TotalProductDicount & "')")
        Else
            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For Each sLine In arrText
                ProgressBar1.Value = ctr / arrText.Count * 100
                m_RawData = New RawData
                m_RawData.CompanyCode = -1
                m_RawData.CompanyCode = "MDI"
                m_RawData.BranchCode = Trim(Mid(sLine, 3, 3))
                m_RawData.BranchName = Trim(Mid(sLine, 6, 24))
                m_RawData.CustomerNumber = Trim(Mid(sLine, 30, 6))
                m_RawData.CustomerName = Trim(Mid(sLine, 36, 50))
                m_RawData.CustomerAddress = Trim(Mid(sLine, 86, 50))
                m_RawData.CustomerAddress2 = Trim(Mid(sLine, 136, 50))
                m_RawData.TranscationDate = Trim(Mid(sLine, 186, 8))
                m_RawData.InvoiceNumber = Trim(Mid(sLine, 194, 8))
                m_RawData.TransactionType = Trim(Mid(sLine, 202, 2))
                m_RawData.ItemNumber = Trim(Mid(sLine, 204, 20))
                m_RawData.ItemDescription = Trim(Mid(sLine, 224, 20))
                m_RawData.WarehouseNumber = Trim(Mid(sLine, 224, 3))
                If Trim(Mid(sLine, 202, 2)) = "CR" Then
                    m_RawData.QuantitySold = CDbl(Mid(sLine, 250, 9)) * -1
                    totalQuantityCR += (0 - CDbl(Mid(sLine, 259, 9)))
                    m_RawData.QuantityFree = CDbl(Mid(sLine, 259, 9)) * -1
                    m_RawData.GrossAmount = (CDbl(Mid(sLine, 268, 13)) / 100) * -1
                    TotalGrossAmountCR += (CDbl(Mid(sLine, 268, 13)) / 100) * -1
                    m_RawData.LineDiscount = (CDbl(Mid(sLine, 281, 7)) / 10000) * -1
                    m_RawData.ProductDiscount = (CDbl(Mid(sLine, 288, 13)) / 100) * -1
                    TotalProductDiscountCR += (CDbl(Mid(sLine, 288, 13)) / 100) * -1
                Else
                    m_RawData.QuantitySold = CDbl(Mid(sLine, 250, 9))
                    totalQuantityIV += CDbl(Mid(sLine, 250, 9))
                    m_RawData.QuantityFree = CDbl(Mid(sLine, 259, 9))
                    m_RawData.GrossAmount = CDbl(Mid(sLine, 268, 13)) / 100
                    TotalGrossAmountIV += CDbl(Mid(sLine, 268, 13)) / 100
                    m_RawData.LineDiscount = CDbl(Mid(sLine, 281, 7)) / 10000
                    m_RawData.ProductDiscount = CDbl(Mid(sLine, 288, 13)) / 100
                    TotalProductDiscountIV += CDbl(Mid(sLine, 288, 13)) / 100
                    TotalQuantity = totalQuantityCR + totalQuantityIV
                End If
                m_RawData.VatCode = Trim(Mid(sLine, 301, 1))
                m_RawData.Route = Trim(Mid(sLine, 653, 4))
                m_RawData.Taxes = CDbl(Mid(sLine, 308, 13)) / 100
                m_RawData.Freight = CDbl(Mid(sLine, 321, 13)) / 100
                m_RawData.Additional = 0
                If Trim(Mid(sLine, 202, 2)) = "CR" Then
                    m_RawData.NetAmount = (CDbl(Mid(sLine, 347, 13)) / 100) * -1
                    TotalNetAmountCR += (CDbl(Mid(sLine, 347, 13)) / 100) * -1
                Else
                    m_RawData.NetAmount = (CDbl(Mid(sLine, 347, 13)) / 100)
                    TotalNetAmountIV += (CDbl(Mid(sLine, 347, 13)) / 100)
                End If
                TotalGrossAmount = TotalGrossAmountCR + TotalGrossAmountIV
                TotalNetAmount = TotalNetAmountCR + TotalNetAmountIV
                TotalProductDicount = TotalProductDiscountCR + TotalProductDiscountIV
                m_RawData.UnitPrice = CDbl(Mid(sLine, 360, 9)) / 100
                m_RawData.InvoiceReferenceNumber = Val(Mid(sLine, 369, 8))
                m_RawData.CMCode = Trim(Mid(sLine, 377, 8))
                m_RawData.SONumber = Trim(Mid(sLine, 380, 8))
                m_RawData.SODate = Trim(Mid(sLine, 388, 8))
                m_RawData.SOTerms = Trim(Mid(sLine, 396, 6))
                m_RawData.ExpiryDate = Trim(Mid(sLine, 402, 8))
                m_RawData.LotNumber = Trim(Mid(sLine, 410, 15))
                m_RawData.SalesmanNumber = Trim(Mid(sLine, 425, 3))
                m_RawData.SalesmanName = Trim(Mid(sLine, 428, 24))
                m_RawData.ShipToName = Trim(Mid(sLine, 452, 50))
                m_RawData.ShipToAddress1 = Trim(Mid(sLine, 502, 50))
                m_RawData.ShipToAddress2 = Trim(Mid(sLine, 552, 50))
                m_RawData.Zipcode = Trim(Mid(sLine, 602, 6))
                m_RawData.TerritoryNumber = Trim(Mid(sLine, 608, 3))
                m_RawData.Area = Trim(Mid(sLine, 611, 3))
                m_RawData.CustomerClass = Trim(Mid(sLine, 611, 3))
                m_RawData.ClassName = Trim(Mid(sLine, 247, 3))
                m_RawData.Principal = Trim(Mid(sLine, 641, 3))
                m_RawData.SubPrincipal = Trim(Mid(sLine, 644, 6))
                m_RawData.PrincipalDivisionCode = Trim(Mid(sLine, 650, 3))
                m_RawData.SalesWeek = Trim(Mid(sLine, 653, 1))
                If Trim(Mid(sLine, 654, 3)) = "" Then
                    m_RawData.CustomerDeliveryCode = "001"
                Else
                    m_RawData.CustomerDeliveryCode = Trim(Mid(sLine, 654, 3))
                End If
                m_RawData.ListOfTaxIncluse = ""
                m_RawData.ContractPrincipalApprovalNumber = ""
                m_RawData.OrderType = "N"
                m_RawData.IsCode = ""
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                ctr += 1
                m_RawData.Save()
            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount,TotalProductDisc) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & TotalGrossAmount & "','" & TotalQuantity & "','" & TotalNetAmount & "','" & TotalProductDicount & "')")
        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()
    End Sub
    Private Sub UploadingPM()
        Dim b As Integer = 18
        Dim ctr As Integer = 0
        Dim TotalNetAmountIV As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim totalQuantityCR As Decimal = 0
        Dim TotalGrossAmountCR As Decimal = 0
        Dim TotalProductDiscountCR As Decimal = 0
        Dim totalQuantityIV As Decimal = 0
        Dim TotalGrossAmountIV As Decimal = 0
        Dim TotalProductDiscountIV As String = String.Empty
        Dim TotalNetAmountCR As Decimal = 0
        Dim _Month As String = String.Empty
        Dim TotalQuantity As Decimal = 0
        Dim TotalProductDicount As Decimal = 0
        Dim TotalGrossAmount As Decimal = 0
        Dim TotalNetAmount As Decimal = 0
        Dim objReader As New StreamReader(txtfile.Text)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For Each sLine In arrText
                ProgressBar1.Value = ctr / arrText.Count * 100
                m_RawData = New RawData
                m_RawData.CompanyCode = -1
                m_RawData.CompanyCode = "PM"
                'm_RawData.BranchCode = Trim(Mid(sLine, 3, 3))
                'm_RawData.BranchName = Trim(Mid(sLine, 6, 24))
                m_RawData.CustomerNumber = Trim(Mid(sLine, 1, 10))
                m_RawData.CustomerName = Trim(Mid(sLine, 11, 39))
                'm_RawData.CustomerAddress = Trim(Mid(sLine, 86, 50))
                'm_RawData.CustomerAddress2 = Trim(Mid(sLine, 136, 50))
                m_RawData.TranscationDate = Trim(Mid(sLine, 121, 10))
                'm_RawData.InvoiceNumber = Trim(Mid(sLine, 194, 8))
                m_RawData.ItemNumber = Trim(Mid(sLine, 61, 8))
                'm_RawData.ItemDescription = Trim(Mid(sLine, 224, 20))
                'm_RawData.WarehouseNumber = Trim(Mid(sLine, 224, 3))
                If Trim(Mid(sLine, 202, 2)) = "CR" Then
                    m_RawData.QuantitySold = CDbl(Mid(sLine, 71, 5)) * -1
                    totalQuantityCR += (CDbl(Mid(sLine, 71, 5)))
                    m_RawData.QuantityFree = CDbl(Mid(sLine, 76, 4)) * -1
                    ' m_RawData.GrossAmount = CDbl(Mid(sLine, 268, 13)) / 100
                    'TotalGrossAmountCR += (CDbl(Mid(sLine, 268, 13)) / 100)
                    ' m_RawData.LineDiscount = (CDbl(Mid(sLine, 281, 7)) / 10000)
                    m_RawData.ProductDiscount = (CDbl(Mid(sLine, 281, 7)) / 100)
                    TotalProductDiscountCR += (CDbl(Mid(sLine, 288, 13)))
                Else
                    If Trim(Mid(sLine, 71, 5)) = "" Then
                        m_RawData.QuantitySold = "0"
                    Else
                        m_RawData.QuantitySold = CDbl(Mid(sLine, 71, 5))
                        totalQuantityIV += CDbl(Mid(sLine, 71, 5))
                    End If
                    If Trim(Mid(sLine, 75, 5)) = "" Then
                        m_RawData.QuantityFree = "0"
                    Else
                        m_RawData.QuantityFree = CDbl(Mid(sLine, 75, 5))
                    End If

                    If Trim(Mid(sLine, 101, 9)) = "" Then
                        m_RawData.GrossAmount = 0
                    ElseIf Trim(Mid(sLine, 202, 2)) = "CR" Then
                        m_RawData.GrossAmount = CDbl(Mid(sLine, 101, 9)) * -1
                    Else
                        m_RawData.GrossAmount = CDbl(Mid(sLine, 101, 9))
                    End If
                    If Trim(Mid(sLine, 71, 5)) = "" Then
                        m_RawData.TransactionType = "CR"
                    Else
                        If Trim(Mid(sLine, 71, 5)) < 0 Then
                            m_RawData.TransactionType = "CR"
                        Else
                            m_RawData.TransactionType = "IV"
                        End If
                    End If
                    If Trim(Mid(sLine, 281, 7)) = "" Then
                        m_RawData.ProductDiscount = "0"
                    Else
                        m_RawData.ProductDiscount = Trim(Mid(sLine, 281, 7))
                        TotalProductDiscountIV += Trim(Mid(sLine, 281, 7))
                    End If
                End If
                If Trim(Mid(sLine, 202, 2)) = "CR" Then
                    m_RawData.NetAmount = (CDbl(Mid(sLine, 88, 8))) * -1
                    TotalGrossAmountCR += (CDbl(Mid(sLine, 88, 8))) * -1
                Else
                    If Trim(Mid(sLine, 101, 9)) = "" Then
                        m_RawData.NetAmount = 0
                    Else
                        m_RawData.NetAmount = (CDbl(Mid(sLine, 101, 9)))
                        TotalNetAmountIV += (CDbl(Mid(sLine, 101, 9)))
                    End If
                End If
                TotalGrossAmount = TotalGrossAmountIV
                TotalNetAmount = TotalNetAmountIV
                TotalQuantity = totalQuantityIV
                'm_RawData.SONumber = Trim(Mid(sLine, 131, 4))
                m_RawData.SalesmanNumber = Trim(Mid(sLine, 51, 9))
                table = GetRecords("select SLSMNNAME  from MEDICALREP  where SLSMNCD = '" & Trim(Mid(sLine, 51, 9)) & "'")
                For i As Integer = 0 To table.Rows.Count - 1
                    m_RawData.SalesmanName = (table.Rows(i)("SLSMNNAME"))
                Next
                m_RawData.CustomerDeliveryCode = "001"
                m_RawData.OrderType = "N"
                m_RawData.InvoiceNumber = Trim(Mid(sLine, 111, 10))
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                ctr += 1
                m_RawData.Save()
            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & TotalGrossAmount & "','" & TotalQuantity & "','" & TotalNetAmount & "' )")
        Else
            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For Each sLine In arrText
                ProgressBar1.Value = ctr / arrText.Count * 100
                m_RawData = New RawData
                m_RawData.CompanyCode = -1
                m_RawData.CompanyCode = "PM"
                'm_RawData.BranchCode = Trim(Mid(sLine, 3, 3))
                'm_RawData.BranchName = Trim(Mid(sLine, 6, 24))
                m_RawData.CustomerNumber = Trim(Mid(sLine, 1, 10))
                m_RawData.CustomerName = Trim(Mid(sLine, 11, 39))
                'm_RawData.CustomerAddress = Trim(Mid(sLine, 86, 50))
                'm_RawData.CustomerAddress2 = Trim(Mid(sLine, 136, 50))
                m_RawData.TranscationDate = Trim(Mid(sLine, 121, 10))
                'm_RawData.InvoiceNumber = Trim(Mid(sLine, 194, 8))
                m_RawData.ItemNumber = Trim(Mid(sLine, 61, 8))
                'm_RawData.ItemDescription = Trim(Mid(sLine, 224, 20))
                'm_RawData.WarehouseNumber = Trim(Mid(sLine, 224, 3))
                If Trim(Mid(sLine, 202, 2)) = "CR" Then
                    m_RawData.QuantitySold = Trim(Mid(sLine, 71, 5))
                    totalQuantityCR += (Trim(Mid(sLine, 71, 5)))
                    m_RawData.QuantityFree = Trim(Mid(sLine, 76, 4))
                    'm_RawData.GrossAmount = CDbl(Mid(sLine, 268, 13)) / 100
                    'TotalGrossAmountCR += (CDbl(Mid(sLine, 268, 13)) / 100)
                    'm_RawData.LineDiscount = (CDbl(Mid(sLine, 281, 7)) / 10000)
                    m_RawData.ProductDiscount = (CDbl(Mid(sLine, 281, 7)) / 100)
                    TotalProductDiscountCR += (CDbl(Mid(sLine, 288, 13)))
                Else
                    If Trim(Mid(sLine, 71, 5)) = "" Then
                        m_RawData.QuantitySold = "0"
                    Else
                        m_RawData.QuantitySold = CDbl(Mid(sLine, 71, 5))
                        totalQuantityIV += CDbl(Mid(sLine, 71, 5))
                    End If
                    If Trim(Mid(sLine, 75, 5)) = "" Then
                        m_RawData.QuantityFree = "0"
                    Else
                        m_RawData.QuantityFree = CDbl(Mid(sLine, 75, 5))
                    End If
                    If Trim(Mid(sLine, 101, 9)) = "" Then
                        m_RawData.GrossAmount = 0
                    ElseIf Trim(Mid(sLine, 202, 2)) = "CR" Then
                        m_RawData.GrossAmount = CDbl(Mid(sLine, 101, 9)) * -1
                    Else
                        m_RawData.GrossAmount = CDbl(Mid(sLine, 101, 9))
                    End If
                    If Trim(Mid(sLine, 71, 5)) = "" Then
                        m_RawData.TransactionType = "CR"
                    Else
                        If Trim(Mid(sLine, 71, 5)) < 0 Then
                            m_RawData.TransactionType = "CR"
                        Else
                            m_RawData.TransactionType = "IV"
                        End If
                    End If
                    If Trim(Mid(sLine, 281, 7)) = "" Then
                        m_RawData.ProductDiscount = "0"
                    Else
                        m_RawData.ProductDiscount = Trim(Mid(sLine, 281, 7))
                        TotalProductDiscountIV += Trim(Mid(sLine, 281, 7))
                    End If
                End If
                If Trim(Mid(sLine, 202, 2)) = "CR" Then
                    m_RawData.NetAmount = (CDbl(Mid(sLine, 88, 8))) * -1
                    TotalGrossAmountCR += (CDbl(Mid(sLine, 88, 8))) * -1
                Else
                    If Trim(Mid(sLine, 101, 9)) = "" Then
                        m_RawData.NetAmount = 0
                    Else
                        m_RawData.NetAmount = (CDbl(Mid(sLine, 101, 9)))
                        TotalNetAmountIV += (CDbl(Mid(sLine, 101, 9)))
                    End If
                End If
                TotalGrossAmount = TotalGrossAmountIV
                TotalNetAmount = TotalNetAmountIV
                TotalQuantity = totalQuantityIV
                'TotalProductDicount = TotalProductDiscountCR + TotalProductDiscountIV
                'm_RawData.UnitPrice = CDbl(Mid(sLine, 360, 9)) / 100
                'm_RawData.InvoiceReferenceNumber = Val(Mid(sLine, 369, 8))
                'm_RawData.CMCode = Trim(Mid(sLine, 377, 8))
                m_RawData.SONumber = Trim(Mid(sLine, 131, 4))
                m_RawData.SalesmanNumber = Trim(Mid(sLine, 51, 9))
                table = GetRecords("select SLSMNNAME  from MEDICALREP  where SLSMNCD = '" & Trim(Mid(sLine, 51, 9)) & "'")
                For i As Integer = 0 To table.Rows.Count - 1
                    m_RawData.SalesmanName = (table.Rows(i)("SLSMNNAME"))
                Next
                m_RawData.CustomerDeliveryCode = "001"
                m_RawData.OrderType = "N"
                m_RawData.InvoiceNumber = Trim(Mid(sLine, 111, 10))
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                ctr += 1
                m_RawData.Save()
            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & TotalGrossAmount & "','" & TotalQuantity & "','" & TotalNetAmount & "' )")
        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()
    End Sub
    Private Sub UploadingZPC()
        Dim b As Integer = 18
        Dim ctr As Integer = 0
        Dim TotalNetAmountIV As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim totalQuantityCR As Decimal = 0
        Dim TotalGrossAmountCR As Decimal = 0
        Dim TotalProductDiscountCR As Decimal = 0
        Dim totalQuantityIV As Decimal = 0
        Dim TotalGrossAmountIV As Decimal = 0
        Dim TotalProductDiscountIV As Decimal = 0
        Dim TotalNetAmountCR As Decimal = 0
        Dim _Month As String = String.Empty
        Dim TotalQuantity As Decimal = 0
        Dim TotalProductDicount As Decimal = 0
        Dim TotalGrossAmount As Decimal = 0
        Dim TotalNetAmount As Decimal = 0
        Dim reccompanycode As String
        Dim recheader As String
        Dim recprocipal As String
        Dim rectotalQuantityOrder As String
        Dim rectotalQuantityship As String
        Dim rectotalrecordcouncil As String = String.Empty
        Dim recprincipla As String = String.Empty
        Dim totalrecord As String
        Dim objReader As New StreamReader(txtfile.Text)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For Each sLine In arrText
                ProgressBar1.Value = ctr / arrText.Count * 100
                If Trim(Mid(sLine, 1, 3)) = "ZPH" Then
                    reccompanycode = Trim(Mid(sLine, 1, 2))
                    recheader = Trim(Mid(sLine, 3, 1))
                    recprocipal = Trim(Mid(sLine, 198, 10))
                    rectotalQuantityOrder = Trim(Mid(sLine, 263, 11))
                    rectotalQuantityship = Trim(Mid(sLine, 274, 11))
                    totalrecord = Trim(Mid(sLine, 287, 15))
                Else
                    m_RawData = New RawData
                    m_RawData.CompanyCode = -1
                    m_RawData.CompanyCode = "ZPC"
                    reccompanycode = Trim(Mid(sLine, 3, 1))
                    m_RawData.BranchCode = Trim(Mid(sLine, 4, 3))
                    m_RawData.BranchName = Trim(Mid(sLine, 8, 3))
                    m_RawData.CustomerNumber = Trim(Mid(sLine, 12, 10))
                    m_RawData.CustomerDeliveryCode = Trim(Mid(sLine, 24, 10))
                    m_RawData.CustomerName = Trim(Mid(sLine, 34, 50))
                    m_RawData.CustomerAddress = Trim(Mid(sLine, 71, 50))
                    m_RawData.CustomerAddress2 = Trim(Mid(sLine, 121, 50))
                    m_RawData.ShipToName = Trim(Mid(sLine, 34, 50))
                    m_RawData.ShipToAddress1 = Trim(Mid(sLine, 71, 50))
                    m_RawData.ShipToAddress2 = Trim(Mid(sLine, 121, 50))
                    m_RawData.CustomerClass = Trim(Mid(sLine, 183, 3))
                    m_RawData.Zipcode = Trim(Mid(sLine, 186, 6))
                    m_RawData.SalesmanNumber = Trim(Mid(sLine, 192, 3))
                    m_RawData.PrincipalCode = Trim(Mid(sLine, 198, 10))
                    m_RawData.Principal = Trim(Mid(sLine, 198, 10))
                    m_RawData.SubPrincipal = Trim(Mid(sLine, 208, 6))
                    If Trim(Mid(sLine, 214, 1)) = 0 Then
                        m_RawData.TransactionType = "IV"
                    ElseIf Trim(Mid(sLine, 214, 1)) = 2 Then
                        m_RawData.TransactionType = "IV"
                    ElseIf Trim(Mid(sLine, 214, 1)) = 6 Then
                        m_RawData.TransactionType = "IV"
                    Else
                        m_RawData.TransactionType = "CR"
                    End If
                    m_RawData.TranscationDate = Trim(Mid(sLine, 215, 8))
                    m_RawData.InvoiceNumber = Trim(Mid(sLine, 223, 10))
                    m_RawData.ItemNumber = Trim(Mid(sLine, 246, 20))
                    ' If IsDBNull(Trim(Mid(sLine, 266, 11))) Then
                    'm_RawData.QuantityFree = "0"
                    ' Else
                    'm_RawData.QuantityFree = Trim(Mid(sLine, 266, 11))
                    'End If
                    If Trim(Mid(sLine, 214, 1)) = 1 Then
                        m_RawData.QuantitySold = (CDec(Mid(sLine, 277, 11)) * -1)
                    ElseIf Trim(Mid(sLine, 214, 1)) = 2 Then
                        m_RawData.QuantityFree = (CDec(Mid(sLine, 277, 11)))
                    ElseIf Trim(Mid(sLine, 214, 1)) = 3 Then
                        m_RawData.QuantityFree = (CDec(Mid(sLine, 277, 11)) * -1)
                    Else
                        m_RawData.QuantitySold = CDec(Mid(sLine, 277, 11))
                    End If
                    m_RawData.UnitOfMesurement = Trim(Mid(sLine, 288, 3))
                    If Trim(Mid(sLine, 306, 15)) = "" Then
                        m_RawData.Taxes = "0"
                    Else
                        m_RawData.Taxes = Trim(Mid(sLine, 306, 15))
                    End If
                    If Trim(Mid(sLine, 321, 15)) = "" Then
                        m_RawData.ListOfTaxIncluse = "0"
                    Else
                        m_RawData.ListOfTaxIncluse = Trim(Mid(sLine, 321, 15))
                    End If

                    If Trim(Mid(sLine, 321, 15)) = "" Then
                        m_RawData.UnitPrice = "0"
                    Else
                        m_RawData.UnitPrice = Trim(Mid(sLine, 321, 15))
                    End If
                    m_RawData.ExpiryDate = Trim(Mid(sLine, 336, 8))
                    m_RawData.LotNumber = Trim(Mid(sLine, 344, 15))
                    If Trim(Mid(sLine, 392, 15)) = "" Then
                        m_RawData.ProductDiscount = "0"
                    Else
                        m_RawData.ProductDiscount = CDec(Mid(sLine, 392, 15))
                    End If
                    m_RawData.SalesmanNumber = Trim(Mid(sLine, 387, 3))
                    If Trim(Mid(sLine, 407, 15)) = "" Then
                        m_RawData.Freight = "0"
                    Else
                        m_RawData.Freight = Trim(Mid(sLine, 407, 15))
                    End If
                    m_RawData.Principal = Trim(Mid(sLine, 198, 10))
                    m_RawData.ContractPrincipalApprovalNumber = Trim(Mid(sLine, 430, 15))
                    m_RawData.PONumber = Trim(Mid(sLine, 445, 15))

                    m_RawData.PricipalClass = Trim(Mid(sLine, 208, 6))
                    If Trim(Mid(sLine, 460, 1)) = "" Then
                        m_RawData.OrderType = "N"
                    Else
                        m_RawData.OrderType = Trim(Mid(sLine, 460, 1))
                    End If
                    If Trim(Mid(sLine, 462, 15)) = "" Then
                        m_RawData.NetAmount = "0"
                    ElseIf Trim(Mid(sLine, 214, 1)) = 0 Then
                        m_RawData.NetAmount = Val(Trim(Mid(sLine, 291, 15)))
                    ElseIf Trim(Mid(sLine, 214, 1)) = 1 Then
                        m_RawData.NetAmount = -1 * Val(Trim(Mid(sLine, 291, 15)))
                    ElseIf Trim(Mid(sLine, 214, 1)) = 2 Then
                        m_RawData.QuantityFree = (CDec(Mid(sLine, 277, 11)))
                    ElseIf Trim(Mid(sLine, 214, 1)) = 3 Then
                        m_RawData.QuantityFree = (CDec(Mid(sLine, 277, 11)) * -1)
                    ElseIf Trim(Mid(sLine, 214, 1)) = 6 Then
                        m_RawData.NetAmount = -1 * Val(Trim(Mid(sLine, 291, 15)))
                    ElseIf Trim(Mid(sLine, 214, 1)) = 7 Then
                        m_RawData.NetAmount = -1 * Val(Trim(Mid(sLine, 291, 15)))
                    Else
                        m_RawData.NetAmount = Trim(Mid(sLine, 291, 15))
                        GrossAmount += Trim(Mid(sLine, 291, 15))
                    End If
                    m_RawData.CMCode = Trim(Mid(sLine, 243, 3))
                    m_RawData.PaymentType = " "
                    '----------------Sales Debtor code-------------------------
                    m_RawData.CutMO = cmbMonth.Text
                    m_RawData.CutYear = cmbYear.Text
                    ctr += 1
                    m_RawData.Save()
                End If
            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        Else
            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For Each sLine In arrText
                ProgressBar1.Value = ctr / arrText.Count * 100
                If Trim(Mid(sLine, 1, 3)) = "ZPH" Then
                    reccompanycode = Trim(Mid(sLine, 1, 2))
                    recheader = Trim(Mid(sLine, 3, 1))
                    recprocipal = Trim(Mid(sLine, 198, 10))
                    rectotalQuantityOrder = Trim(Mid(sLine, 263, 11))
                    rectotalQuantityship = Trim(Mid(sLine, 274, 11))
                    totalrecord = Trim(Mid(sLine, 287, 15))
                Else
                    m_RawData = New RawData
                    m_RawData.CompanyCode = -1
                    m_RawData.CompanyCode = "ZPC"
                    reccompanycode = Trim(Mid(sLine, 3, 1))
                    m_RawData.BranchCode = Trim(Mid(sLine, 4, 3))
                    m_RawData.BranchName = Trim(Mid(sLine, 8, 3))
                    m_RawData.CustomerNumber = Trim(Mid(sLine, 12, 10))
                    m_RawData.CustomerDeliveryCode = Trim(Mid(sLine, 24, 10))
                    m_RawData.CustomerName = Trim(Mid(sLine, 34, 50))
                    m_RawData.CustomerAddress = Trim(Mid(sLine, 71, 50))
                    m_RawData.CustomerAddress2 = Trim(Mid(sLine, 121, 50))
                    m_RawData.ShipToName = Trim(Mid(sLine, 34, 50))
                    m_RawData.ShipToAddress1 = Trim(Mid(sLine, 71, 50))
                    m_RawData.ShipToAddress2 = Trim(Mid(sLine, 121, 50))
                    m_RawData.CustomerClass = Trim(Mid(sLine, 183, 3))
                    m_RawData.Zipcode = Trim(Mid(sLine, 186, 6))
                    m_RawData.SalesmanNumber = Trim(Mid(sLine, 192, 3))
                    m_RawData.PrincipalCode = Trim(Mid(sLine, 198, 10))
                    m_RawData.Principal = Trim(Mid(sLine, 198, 10))
                    m_RawData.SubPrincipal = Trim(Mid(sLine, 208, 6))
                    If Trim(Mid(sLine, 214, 1)) = 0 Then
                        m_RawData.TransactionType = "IV"
                    ElseIf Trim(Mid(sLine, 214, 1)) = 2 Then
                        m_RawData.TransactionType = "IV"
                    ElseIf Trim(Mid(sLine, 214, 1)) = 6 Then
                        m_RawData.TransactionType = "IV"
                    Else
                        m_RawData.TransactionType = "CR"
                    End If
                    m_RawData.TranscationDate = Trim(Mid(sLine, 215, 8))
                    m_RawData.InvoiceNumber = Trim(Mid(sLine, 223, 10))
                    m_RawData.ItemNumber = Trim(Mid(sLine, 246, 20))
                    ' If IsDBNull(Trim(Mid(sLine, 266, 11))) Then
                    'm_RawData.QuantityFree = "0"
                    ' Else
                    'm_RawData.QuantityFree = Trim(Mid(sLine, 266, 11))
                    'End If
                    If Trim(Mid(sLine, 214, 1)) = 1 Then
                        m_RawData.QuantitySold = (CDec(Mid(sLine, 277, 11)) * -1)
                    ElseIf Trim(Mid(sLine, 214, 1)) = 2 Then
                        m_RawData.QuantityFree = (CDec(Mid(sLine, 277, 11)))
                    ElseIf Trim(Mid(sLine, 214, 1)) = 3 Then
                        m_RawData.QuantityFree = (CDec(Mid(sLine, 277, 11)) * -1)
                    Else
                        m_RawData.QuantitySold = CDec(Mid(sLine, 277, 11))
                    End If
                    m_RawData.UnitOfMesurement = Trim(Mid(sLine, 288, 3))
                    If Trim(Mid(sLine, 306, 15)) = "" Then
                        m_RawData.Taxes = "0"
                    Else
                        m_RawData.Taxes = Trim(Mid(sLine, 306, 15))
                    End If
                    If Trim(Mid(sLine, 321, 15)) = "" Then
                        m_RawData.ListOfTaxIncluse = "0"
                    Else
                        m_RawData.ListOfTaxIncluse = Trim(Mid(sLine, 321, 15))
                    End If

                    If Trim(Mid(sLine, 321, 15)) = "" Then
                        m_RawData.UnitPrice = "0"
                    Else
                        m_RawData.UnitPrice = Trim(Mid(sLine, 321, 15))
                    End If
                    m_RawData.ExpiryDate = Trim(Mid(sLine, 336, 8))
                    m_RawData.LotNumber = Trim(Mid(sLine, 344, 15))
                    If Trim(Mid(sLine, 392, 15)) = "" Then
                        m_RawData.ProductDiscount = "0"
                    Else
                        m_RawData.ProductDiscount = CDec(Mid(sLine, 392, 15))
                    End If
                    m_RawData.SalesmanNumber = Trim(Mid(sLine, 387, 3))
                    If Trim(Mid(sLine, 407, 15)) = "" Then
                        m_RawData.Freight = "0"
                    Else
                        m_RawData.Freight = Trim(Mid(sLine, 407, 15))
                    End If
                    m_RawData.Principal = Trim(Mid(sLine, 198, 10))
                    m_RawData.ContractPrincipalApprovalNumber = Trim(Mid(sLine, 430, 15))
                    m_RawData.PONumber = Trim(Mid(sLine, 445, 15))
                    m_RawData.PricipalClass = Trim(Mid(sLine, 208, 6))
                    If Trim(Mid(sLine, 460, 1)) = "" Then
                        m_RawData.OrderType = "N"
                    Else
                        m_RawData.OrderType = Trim(Mid(sLine, 460, 1))
                    End If
                    If Trim(Mid(sLine, 462, 15)) = "" Then
                        m_RawData.NetAmount = "0"
                    ElseIf Trim(Mid(sLine, 214, 1)) = 0 Then
                        m_RawData.NetAmount = Val(Trim(Mid(sLine, 291, 15)))
                    ElseIf Trim(Mid(sLine, 214, 1)) = 1 Then
                        m_RawData.NetAmount = -1 * Val(Trim(Mid(sLine, 291, 15)))
                    ElseIf Trim(Mid(sLine, 214, 1)) = 2 Then
                        m_RawData.QuantityFree = (CDec(Mid(sLine, 277, 11)))
                    ElseIf Trim(Mid(sLine, 214, 1)) = 3 Then
                        m_RawData.QuantityFree = (CDec(Mid(sLine, 277, 11)) * -1)
                    ElseIf Trim(Mid(sLine, 214, 1)) = 6 Then
                        m_RawData.NetAmount = -1 * Val(Trim(Mid(sLine, 291, 15)))
                    ElseIf Trim(Mid(sLine, 214, 1)) = 7 Then
                        m_RawData.NetAmount = -1 * Val(Trim(Mid(sLine, 291, 15)))
                    Else
                        m_RawData.NetAmount = Trim(Mid(sLine, 291, 15))
                        GrossAmount += Trim(Mid(sLine, 291, 15))
                    End If
                    m_RawData.CMCode = Trim(Mid(sLine, 243, 3))
                    m_RawData.PaymentType = " "
                    '----------------Sales Debtor code-------------------------
                    m_RawData.CutMO = cmbMonth.Text
                    m_RawData.CutYear = cmbYear.Text
                    ctr += 1
                    m_RawData.Save()
                End If
            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()
    End Sub

    Private Sub UploadingWAT()
        Dim b As Integer = 18
        Dim ctr As Integer = 0
        Dim TotalNetAmountIV As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim totalQuantityCR As Decimal = 0
        Dim TotalGrossAmountCR As Decimal = 0
        Dim TotalProductDiscountCR As Decimal = 0
        Dim totalQuantityIV As Decimal = 0
        Dim TotalGrossAmountIV As Decimal = 0
        Dim TotalProductDiscountIV As Decimal = 0
        Dim TotalNetAmountCR As Decimal = 0
        Dim _Month As String = String.Empty
        Dim TotalQuantity As Decimal = 0
        Dim TotalProductDicount As Decimal = 0
        Dim TotalGrossAmount As Decimal = 0
        Dim TotalNetAmount As Decimal = 0
        Dim objReader As New StreamReader(txtfile.Text)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For Each sLine In arrText
                ProgressBar1.Value = ctr / arrText.Count * 100
                m_RawData = New RawData
                If Trim(Mid(sLine, 36, 3)) = "WAT" Then
                    m_RawData.CompanyCode = -1
                    m_RawData.CompanyCode = "WAT"
                    m_RawData.BranchCode = Trim(Mid(sLine, 30, 6))
                    m_RawData.BranchName = Trim(Mid(sLine, 6, 24))
                    m_RawData.CustomerNumber = Trim(Mid(sLine, 654, 3))
                    m_RawData.CustomerName = Trim(Mid(sLine, 36, 50))
                    m_RawData.CustomerAddress = Trim(Mid(sLine, 86, 50))
                    m_RawData.CustomerAddress2 = Trim(Mid(sLine, 136, 50))
                    m_RawData.TranscationDate = Trim(Mid(sLine, 186, 8))
                    m_RawData.InvoiceNumber = Trim(Mid(sLine, 194, 8))
                    m_RawData.TransactionType = Trim(Mid(sLine, 202, 2))
                    m_RawData.ItemNumber = Trim(Mid(sLine, 204, 20))
                    m_RawData.ItemDescription = Trim(Mid(sLine, 224, 20))
                    m_RawData.WarehouseNumber = Trim(Mid(sLine, 224, 3))
                    If Trim(Mid(sLine, 202, 2)) = "CR" Then
                        m_RawData.QuantitySold = (CDbl(Mid(sLine, 250, 9)) * -1)
                        totalQuantityCR += (0 - CDbl(Mid(sLine, 250, 9)))
                        m_RawData.QuantitySold = Trim(Mid(sLine, 250, 9)) * -1
                        m_RawData.GrossAmount = (CDbl(Mid(sLine, 268, 13)) / 100) * -1
                        TotalGrossAmountCR += (CDbl(Mid(sLine, 268, 13)) / 100) * -1
                        m_RawData.LineDiscount = (CDbl(Mid(sLine, 281, 7)) / 10000) * -1
                        m_RawData.ProductDiscount = (CDbl(Mid(sLine, 288, 13)) / 100) * -1
                        TotalProductDiscountCR += (CDbl(Mid(sLine, 288, 13)) / 100)
                    Else
                        m_RawData.QuantitySold = Trim(Mid(sLine, 250, 9))
                        totalQuantityIV += (Trim(Mid(sLine, 250, 9)))
                        m_RawData.QuantityFree = Trim(Mid(sLine, 259, 9))
                        m_RawData.GrossAmount = CDbl(Mid(sLine, 268, 13)) / 100
                        TotalGrossAmountIV += (CDbl(Mid(sLine, 268, 13)) / 100)
                        m_RawData.LineDiscount = (CDbl(Mid(sLine, 281, 7)) / 10000)
                        m_RawData.ProductDiscount = (CDbl(Mid(sLine, 288, 13)) / 100)
                        TotalProductDiscountIV += (CDbl(Mid(sLine, 288, 13)) / 100)
                        TotalQuantity = totalQuantityCR + totalQuantityIV
                    End If
                    m_RawData.VatCode = Trim(Mid(sLine, 301, 1))
                    m_RawData.Route = Trim(Mid(sLine, 653, 4))
                    m_RawData.Taxes = CDbl(Mid(sLine, 308, 13)) / 100
                    m_RawData.Freight = CDbl(Mid(sLine, 321, 13)) / 100
                    m_RawData.Additional = 0
                    If Trim(Mid(sLine, 202, 2)) = "CR" Then
                        m_RawData.NetAmount = (CDbl(Mid(sLine, 347, 13)) / 100) * -1
                        TotalGrossAmountCR += (CDbl(Mid(sLine, 347, 13)) / 100)
                    Else
                        m_RawData.NetAmount = (CDbl(Mid(sLine, 347, 13)) / 100)
                        TotalNetAmountIV += (CDbl(Mid(sLine, 347, 13)) / 100)
                    End If
                    TotalGrossAmount = TotalGrossAmountCR + TotalGrossAmountIV
                    TotalNetAmount = TotalNetAmountCR + TotalNetAmountIV
                    TotalProductDicount = TotalProductDiscountCR + TotalProductDiscountIV
                    m_RawData.UnitPrice = CDbl(Mid(sLine, 360, 9)) / 100
                    m_RawData.InvoiceReferenceNumber = Val(Mid(sLine, 369, 8))
                    m_RawData.CMCode = Trim(Mid(sLine, 377, 8))
                    m_RawData.SONumber = Trim(Mid(sLine, 380, 8))
                    m_RawData.SODate = Trim(Mid(sLine, 388, 8))
                    m_RawData.SOTerms = Trim(Mid(sLine, 396, 6))
                    m_RawData.ExpiryDate = Trim(Mid(sLine, 402, 8))
                    m_RawData.LotNumber = Trim(Mid(sLine, 410, 15))
                    m_RawData.SalesmanNumber = Trim(Mid(sLine, 425, 3))
                    m_RawData.SalesmanName = Trim(Mid(sLine, 428, 24))
                    m_RawData.ShipToName = Trim(Mid(sLine, 452, 50))
                    m_RawData.ShipToAddress1 = Trim(Mid(sLine, 502, 50))
                    m_RawData.ShipToAddress2 = Trim(Mid(sLine, 552, 50))
                    m_RawData.Zipcode = Trim(Mid(sLine, 602, 6))
                    m_RawData.TerritoryNumber = Trim(Mid(sLine, 608, 3))
                    m_RawData.Area = Trim(Mid(sLine, 611, 3))
                    m_RawData.CustomerClass = Trim(Mid(sLine, 611, 3))
                    m_RawData.ClassName = Trim(Mid(sLine, 247, 3))
                    m_RawData.Principal = Trim(Mid(sLine, 641, 3))
                    m_RawData.SubPrincipal = Trim(Mid(sLine, 644, 6))
                    m_RawData.PrincipalDivisionCode = Trim(Mid(sLine, 650, 3))
                    m_RawData.SalesWeek = Trim(Mid(sLine, 653, 1))
                    m_RawData.CustomerDeliveryCode = "001"
                    m_RawData.ListOfTaxIncluse = ""
                    m_RawData.ContractPrincipalApprovalNumber = ""
                    m_RawData.OrderType = Trim(Mid(sLine, 648, 1))
                    m_RawData.IsCode = ""
                    m_RawData.CutMO = cmbMonth.Text
                    m_RawData.CutYear = cmbYear.Text
                    ctr += 1
                    m_RawData.Save()
                End If
            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        Else
            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For Each sLine In arrText
                ProgressBar1.Value = ctr / arrText.Count * 100
                If Trim(Mid(sLine, 36, 3)) = "WAT" Then
                    m_RawData = New RawData
                    m_RawData.CompanyCode = -1
                    m_RawData.CompanyCode = "WAT"
                    m_RawData.BranchCode = Trim(Mid(sLine, 30, 6))
                    m_RawData.BranchName = Trim(Mid(sLine, 6, 24))
                    m_RawData.CustomerNumber = Trim(Mid(sLine, 654, 3))
                    m_RawData.CustomerName = Trim(Mid(sLine, 36, 50))
                    m_RawData.CustomerAddress = Trim(Mid(sLine, 86, 50))
                    m_RawData.CustomerAddress2 = Trim(Mid(sLine, 136, 50))
                    m_RawData.TranscationDate = Trim(Mid(sLine, 186, 8))
                    m_RawData.InvoiceNumber = Trim(Mid(sLine, 194, 8))
                    m_RawData.TransactionType = Trim(Mid(sLine, 202, 2))
                    m_RawData.ItemNumber = Trim(Mid(sLine, 204, 20))
                    m_RawData.ItemDescription = Trim(Mid(sLine, 224, 20))
                    m_RawData.WarehouseNumber = Trim(Mid(sLine, 224, 3))
                    If Trim(Mid(sLine, 202, 2)) = "CR" Then
                        m_RawData.QuantitySold = (Trim(Mid(sLine, 250, 9)) * -1)
                        totalQuantityCR += (0 - Trim(Mid(sLine, 250, 9)))
                        m_RawData.QuantityFree = Trim(Mid(sLine, 259, 9))
                        m_RawData.GrossAmount = (CDbl(Mid(sLine, 268, 13)) / 100) * -1
                        TotalGrossAmountCR += (CDbl(Mid(sLine, 268, 13)) / 100) * -1
                        m_RawData.LineDiscount = (CDbl(Mid(sLine, 281, 7)) / 10000) * -1
                        m_RawData.ProductDiscount = (CDbl(Mid(sLine, 288, 13)) / 100)
                        TotalProductDiscountCR += (CDbl(Mid(sLine, 288, 13)) / 100)
                    Else
                        m_RawData.QuantitySold = Trim(Mid(sLine, 250, 9))
                        totalQuantityIV += Trim(Mid(sLine, 250, 9))
                        m_RawData.QuantityFree = Trim(Mid(sLine, 259, 9))
                        m_RawData.GrossAmount = CDbl(Mid(sLine, 268, 13)) / 100
                        TotalGrossAmountIV += CDbl(Mid(sLine, 268, 13)) / 100
                        m_RawData.LineDiscount = CDbl(Mid(sLine, 281, 7)) / 10000
                        m_RawData.ProductDiscount = CDbl(Mid(sLine, 288, 13)) / 100
                        TotalProductDiscountIV += CDbl(Mid(sLine, 288, 13)) / 100
                        TotalQuantity = totalQuantityCR + totalQuantityIV
                    End If
                    m_RawData.VatCode = Trim(Mid(sLine, 301, 1))
                    m_RawData.Route = Trim(Mid(sLine, 653, 4))
                    m_RawData.Taxes = CDbl(Mid(sLine, 308, 13)) / 100
                    m_RawData.Freight = CDbl(Mid(sLine, 321, 13)) / 100
                    m_RawData.Additional = 0
                    If Trim(Mid(sLine, 202, 2)) = "CR" Then
                        m_RawData.NetAmount = (CDbl(Mid(sLine, 347, 13)) / 100) * -1
                        TotalGrossAmountCR += (CDbl(Mid(sLine, 347, 13)) / 100)
                    Else
                        m_RawData.NetAmount = (CDbl(Mid(sLine, 347, 13)) / 100)
                        TotalNetAmountIV += (CDbl(Mid(sLine, 347, 13)) / 100)
                    End If
                    TotalGrossAmount = TotalGrossAmountCR + TotalGrossAmountIV
                    TotalNetAmount = TotalNetAmountCR + TotalNetAmountIV
                    TotalProductDicount = TotalProductDiscountCR + TotalProductDiscountIV
                    m_RawData.UnitPrice = CDbl(Mid(sLine, 360, 9)) / 100
                    m_RawData.InvoiceReferenceNumber = Val(Mid(sLine, 369, 8))
                    m_RawData.CMCode = Trim(Mid(sLine, 377, 8))
                    m_RawData.SONumber = Trim(Mid(sLine, 380, 8))
                    m_RawData.SODate = Trim(Mid(sLine, 388, 8))
                    m_RawData.SOTerms = Trim(Mid(sLine, 396, 6))
                    m_RawData.ExpiryDate = Trim(Mid(sLine, 402, 8))
                    m_RawData.LotNumber = Trim(Mid(sLine, 410, 15))
                    m_RawData.SalesmanNumber = Trim(Mid(sLine, 425, 3))
                    m_RawData.SalesmanName = Trim(Mid(sLine, 428, 24))
                    m_RawData.ShipToName = Trim(Mid(sLine, 452, 50))
                    m_RawData.ShipToAddress1 = Trim(Mid(sLine, 502, 50))
                    m_RawData.ShipToAddress2 = Trim(Mid(sLine, 552, 50))
                    m_RawData.Zipcode = Trim(Mid(sLine, 602, 6))
                    m_RawData.TerritoryNumber = Trim(Mid(sLine, 608, 3))
                    m_RawData.Area = Trim(Mid(sLine, 611, 3))
                    m_RawData.CustomerClass = Trim(Mid(sLine, 611, 3))
                    m_RawData.ClassName = Trim(Mid(sLine, 247, 3))
                    m_RawData.Principal = Trim(Mid(sLine, 641, 3))
                    m_RawData.SubPrincipal = Trim(Mid(sLine, 644, 6))
                    m_RawData.PrincipalDivisionCode = Trim(Mid(sLine, 650, 3))
                    m_RawData.SalesWeek = Trim(Mid(sLine, 653, 1))
                    m_RawData.CustomerDeliveryCode = "001"
                    m_RawData.ListOfTaxIncluse = ""
                    m_RawData.ContractPrincipalApprovalNumber = ""
                    m_RawData.OrderType = Trim(Mid(sLine, 648, 1))
                    m_RawData.IsCode = ""
                    m_RawData.CutMO = cmbMonth.Text
                    m_RawData.CutYear = cmbYear.Text
                    ctr += 1
                    m_RawData.Save()
                End If
            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()
    End Sub
    Private Sub gettexting()
    End Sub

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
    Private Sub loadView()
        '  Try
        If _ExcelResult.CheckIfExist(txtfile.Text) Then
            dt = _ExcelResult.GetExcelData(txtfile.Text)
            If cmbCompany.Text = "ODI" Then
                ODIUploading()
            ElseIf cmbCompany.Text = "ODIGOV" Then
                ODIGOVUploading()
            ElseIf cmbCompany.Text = "ALDRTZ" Then
                AldrtzUploading()
            ElseIf cmbCompany.Text = "OPCI" Then
                Uploading()
            ElseIf cmbCompany.Text = "PRI" Then
                UploadingPRI()
            ElseIf cmbCompany.Text = "SSD" Then
                UploadingSSD()
            ElseIf cmbCompany.Text = "MDI" Then
                Uploadingmetro()
            ElseIf cmbCompany.Text = "GB" Then
                UploadingGBEXC()
            ElseIf cmbCompany.Text = "RBC" Then
                UploadingRBC()
            ElseIf cmbCompany.Text = "DIR" Then
                Uploading()
            ElseIf cmbCompany.Text = "DIRGOV" Then
                Uploading()
            ElseIf cmbCompany.Text = "MDC" Then
                UploadingMDC()
            ElseIf cmbCompany.Text = "ACT" Then
                UploadingActimed()
            ElseIf cmbCompany.Text = "MDCR" Then
                UploadMDCRUD()
            ElseIf cmbCompany.Text = "WAT" Then
                UploadingExelWAT()
            ElseIf cmbCompany.Text = "ZURE" Then
                UploadingExelZURE()
            ElseIf cmbCompany.Text = "ODIGOVS" Then
                UploadingODIGOVEXEC()
            ElseIf cmbCompany.Text = "DIRGOVS" Then
                UploadingDIRGOVEXEC()
            End If
        End If
        'Catch ex As Exception
        'MsgBox(ex.Message)
        '  End Try
    End Sub
    Private Sub UploadingDIRGOVEXEC()
        Try
            Dim a As Decimal = 0
            Dim b As Integer = 18
            Dim ctr As Integer = 0
            Dim TotalNetAmount As Decimal = 0
            Dim GrossAmount As Decimal = 0
            Dim totalQuantity As Decimal = 0
            Dim ProductDiscount As Decimal = 0
            Dim _Month As String = String.Empty


            If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
                For m As Integer = 0 To dt.Rows.Count - 1
                    ProgressBar1.Value = ctr / dt.Rows.Count * 100
                    Dim dr As DataRow = dt.Rows(m)

                    m_RawData = New RawData

                    m_RawData.CompanyCode = cmbCompany.Text
                    If IsDBNull(dr("CustomerCode")) Then
                        m_RawData.CustomerNumber = ""
                    Else
                        m_RawData.CustomerNumber = RefineSQL(dr("CustomerCode")).ToString
                    End If
                    If IsDBNull(dr("Customername")) Then
                        m_RawData.CustomerName = ""
                    Else
                        m_RawData.CustomerName = dr("CustomerName")
                    End If
                    If IsDBNull(dr("Invoice/CMNumber")) Then
                        m_RawData.ItemNumber = ""
                    Else
                        m_RawData.InvoiceNumber = dr("Invoice/CMNumber").ToString
                    End If
                    If IsDBNull(dr("Invoice/CMDate")) Then
                        m_RawData.TranscationDate = ""
                    Else
                        m_RawData.TranscationDate = dr("Invoice/CMDate").ToString
                    End If
                    If IsDBNull(dr("ItemCode")) Then
                        m_RawData.ItemNumber = ""
                    Else
                        m_RawData.ItemNumber = dr("ItemCode")
                    End If


                    If IsDBNull(dr("ItemName")) Then
                        m_RawData.ItemDescription = ""
                    Else
                        m_RawData.ItemDescription = dr("ItemName")
                    End If
                    If dr("Net") = 0 Then
                        m_RawData.QuantityFree = dr("Quantity")
                    Else
                        m_RawData.QuantitySold = dr("Quantity")
                    End If
                    If IsDBNull(dr("Quantity")) Then
                        m_RawData.QuantitySold = "0"
                    Else

                        totalQuantity = totalQuantity + dr("Quantity")
                    End If
                    If IsDBNull(dr("UOM")) Then
                        m_RawData.UnitOfMesurement = ""
                    Else
                        m_RawData.UnitOfMesurement = dr("UOM").ToString
                    End If
                    If IsDBNull(dr("TM Code")) Then
                        m_RawData.SalesmanNumber = ""
                    Else
                        m_RawData.SalesmanNumber = dr("TM Code").ToString
                    End If
                    If IsDBNull(dr("TM Name")) Then
                        m_RawData.SalesmanName = ""
                    Else
                        m_RawData.SalesmanName = dr("TM Name")
                    End If
                    If IsDBNull(dr("Net")) Then
                        m_RawData.NetAmount = "0"
                    Else
                        m_RawData.NetAmount = dr("Net")
                        TotalNetAmount = TotalNetAmount + dr("Net")
                    End If
                    If dr("Net") < 0 Then
                        m_RawData.TransactionType = "CR"
                    Else
                        m_RawData.TransactionType = "IV"
                    End If

                    m_RawData.CustomerDeliveryCode = "001"

                    m_RawData.OrderType = "N"
                    m_RawData.CutMO = cmbMonth.Text
                    m_RawData.CutYear = cmbYear.Text
                    m_RawData.PaymentType = ""

                    ctr += 1
                    m_RawData.Save()

                Next

                ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & TotalNetAmount & "','" & totalQuantity & "','" & TotalNetAmount & "' )")

            Else

                RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
                For m As Integer = 0 To dt.Rows.Count - 1
                    ProgressBar1.Value = ctr / dt.Rows.Count * 100
                    Dim dr As DataRow = dt.Rows(m)

                    m_RawData = New RawData

                    m_RawData.CompanyCode = cmbCompany.Text
                    If IsDBNull(dr("CustomerCode")) Then
                        m_RawData.CustomerNumber = ""
                    Else
                        m_RawData.CustomerNumber = RefineSQL(dr("CustomerCode")).ToString
                    End If
                    If IsDBNull(dr("Customername")) Then
                        m_RawData.CustomerName = ""
                    Else
                        m_RawData.CustomerName = dr("CustomerName")
                    End If
                    If IsDBNull(dr("Invoice/CMNumber")) Then
                        m_RawData.ItemNumber = ""
                    Else
                        m_RawData.InvoiceNumber = dr("Invoice/CMNumber").ToString
                    End If
                    If IsDBNull(dr("Invoice/CMDate")) Then
                        m_RawData.TranscationDate = ""
                    Else
                        m_RawData.TranscationDate = dr("Invoice/CMDate").ToString
                    End If

                    If IsDBNull(dr("Itemcode")) Then
                        m_RawData.ItemDescription = ""
                    Else
                        m_RawData.ItemNumber = dr("ItemCode")
                    End If


                    If IsDBNull(dr("ItemName")) Then
                        m_RawData.ItemDescription = ""
                    Else
                        m_RawData.ItemDescription = dr("ItemName")
                    End If
                    If dr("Net") = 0 Then
                        m_RawData.QuantityFree = dr("Quantity")
                    Else
                        m_RawData.QuantitySold = dr("Quantity")

                    End If

                    If IsDBNull(dr("Quantity")) Then
                        m_RawData.QuantitySold = "0"
                    Else

                        totalQuantity = totalQuantity + dr("Quantity")
                    End If
                    If IsDBNull(dr("UOM")) Then
                        m_RawData.UnitOfMesurement = ""
                    Else
                        m_RawData.UnitOfMesurement = dr("UOM").ToString
                    End If
                    If IsDBNull(dr("TM Code")) Then
                        m_RawData.SalesmanNumber = ""
                    Else
                        m_RawData.SalesmanNumber = dr("TM Code").ToString
                    End If
                    If IsDBNull(dr("TM Name")) Then
                        m_RawData.SalesmanName = ""
                    Else
                        m_RawData.SalesmanName = dr("TM Name")
                    End If
                    If IsDBNull(dr("Net")) Then
                        m_RawData.NetAmount = "0"
                    Else
                        m_RawData.NetAmount = dr("Net")
                        TotalNetAmount = TotalNetAmount + dr("Net")
                    End If
                    m_RawData.NetAmount = dr("Net")
                    GrossAmount = GrossAmount + dr("Net")

                    If dr("Net") < 0 Then
                        m_RawData.TransactionType = "CR"
                    Else
                        m_RawData.TransactionType = "IV"
                    End If

                    m_RawData.CustomerDeliveryCode = "001"
                    m_RawData.OrderType = "N"

                    m_RawData.CutMO = cmbMonth.Text
                    m_RawData.CutYear = cmbYear.Text
                    m_RawData.PaymentType = ""

                    ctr += 1
                    m_RawData.Save()

                Next

                ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & TotalNetAmount & "','" & totalQuantity & "','" & TotalNetAmount & "' )")
            End If
            ProgressBar1.Visible = False
            MessageBox.Show("File Successfully Uploaded!")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub UploadingODIGOVEXEC()
        Dim a As Integer = 20
        Dim b As Integer = 18

        Dim ctr As Integer = 0
        Dim TotalQuantity As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim ProductDiscount As Decimal = 0

        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                If Not "ODIGOV" = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData
                If IsDBNull(dr("Customer Code")) Then Exit For
                m_RawData.CompanyCode = "ODIGOV"
                m_RawData.BranchCode = dr("Customer Code").ToString
                If IsDBNull(dr("Customer Name")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("Customer Name")
                End If

                m_RawData.CustomerNumber = dr("Customer Code")
                m_RawData.CustomerName = dr("Customer Name")
                If dr("Address") <> "" Then
                    m_RawData.CustomerAddress = dr("Address")
                    m_RawData.ShipToAddress1 = dr("Address")
                Else
                    m_RawData.CustomerAddress = ""
                    m_RawData.ShipToAddress1 = ""
                End If
                m_RawData.CustomerDeliveryCode = dr("Ship To Code")

                m_RawData.TranscationDate = dr("Invoice Date")

                m_RawData.InvoiceNumber = dr("Invoice Number")
                If dr("Gross Amount") < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If

                m_RawData.ItemNumber = dr("Item Code")
                m_RawData.ItemDescription = dr("Item Description")
                m_RawData.QuantitySold = CDec(dr("Gross Quantity"))
                m_RawData.QuantityFree = CDec(dr("Free Quantity"))
                TotalQuantity = TotalQuantity + CDec(dr("Gross Quantity"))
                m_RawData.GrossAmount = CDec(dr("Gross Amount"))
                m_RawData.UnitPrice = CDec(dr("Trade Price"))
                m_RawData.NetAmount = CDec(dr("Net Value"))
                GrossAmount = GrossAmount + CDec(dr("Gross Amount"))
                m_RawData.InvoiceNumber = dr("Invoice Number")
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                m_RawData.LotNumber = dr("Lot Number")
                m_RawData.ExpiryDate = dr("Expiry Date")
                m_RawData.WarehouseNumber = dr("Warehouse Code")
                m_RawData.Principal = dr("Principal Code")
                m_RawData.SOTerms = dr("Credit Terms")
                m_RawData.PaymentType = ""
                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "' ,'" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        Else
            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                If Not "ODIGOV" = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData
                If IsDBNull(dr("Customer Code")) Then Exit For
                m_RawData.CompanyCode = "ODIGOV"
                m_RawData.BranchCode = dr("Customer Code").ToString
                If IsDBNull(dr("Customer Name")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("Customer Name")
                End If

                m_RawData.CustomerNumber = dr("Customer Code")
                m_RawData.CustomerName = dr("Customer Name")
                If dr("Address") <> "" Then
                    m_RawData.CustomerAddress = dr("Address")
                    m_RawData.ShipToAddress1 = dr("Address")
                Else
                    m_RawData.CustomerAddress = ""
                    m_RawData.ShipToAddress1 = ""
                End If
                m_RawData.CustomerDeliveryCode = dr("Ship to Code")

                m_RawData.TranscationDate = dr("Invoice Date")

                m_RawData.InvoiceNumber = dr("Invoice Number")
                If dr("Gross Amount") < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If

                m_RawData.ItemNumber = dr("Item Code")
                m_RawData.ItemDescription = dr("Item Description")
                m_RawData.QuantitySold = CDec(dr("Gross Quantity"))
                m_RawData.QuantityFree = CDec(dr("Free Quantity"))
                TotalQuantity = TotalQuantity + CDec(dr("Gross Quantity"))
                m_RawData.GrossAmount = CDec(dr("Gross Amount"))
                m_RawData.UnitPrice = dr("Trade Price")
                m_RawData.NetAmount = CDec(dr("Net Value"))
                GrossAmount = GrossAmount + CDec(dr("Gross Amount"))
                m_RawData.InvoiceNumber = dr("Invoice Number")
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                m_RawData.LotNumber = dr("Lot Number")
                m_RawData.ExpiryDate = dr("Expiry Date")
                m_RawData.WarehouseNumber = dr("Warehouse Code")
                m_RawData.Principal = dr("Principal Code")
                m_RawData.SOTerms = dr("Credit Terms")
                m_RawData.PaymentType = ""
                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()

    End Sub
    Private Sub UploadingMDC()
        On Error Resume Next
        Dim rsCustomer As New ADODB.Recordset
        Dim b As Integer = 18
        Dim num As String
        Dim null As Char
        Dim ctr As Integer = 0
        Dim TotalNetAmount
        Dim GrossAmount
        Dim totalQuantity As Decimal = 0
        Dim Quantitys
        Dim ProductDiscount As Decimal = 0
        Dim _Month As String = String.Empty
        Dim TotalGrossAmount As Decimal = 0

        If RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                m_RawData = New RawData
                m_RawData.CompanyCode = cmbCompany.Text
                m_RawData.CustomerNumber = dr("CustomerCode")
                If IsDBNull(dr("CustomerCode")) Then
                    m_RawData.CustomerNumber = ""
                Else
                    If rsCustomer.State = 1 Then rsCustomer.Close()
                    rsCustomer.Open("Select CUSTOMERNAME,CADD1,CADD2 FROM CUSTOMER WHERE CUSTOMERCD = '" & dr("CustomerCode") & "' AND COMID = '" & "MDC" & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset)
                    If rsCustomer.RecordCount <> 0 Then
                        m_RawData.CustomerName = rsCustomer.Fields(0).Value
                        m_RawData.CustomerNumber = RefineSQL(dr("CustomerCode")).ToString

                    End If
                End If
                If rsCustomer.RecordCount <> 0 Then
                    m_RawData.CustomerAddress = rsCustomer.Fields(1).Value
                Else
                    m_RawData.CustomerAddress = ""
                End If
                If rsCustomer.RecordCount <> 0 Then
                    m_RawData.CustomerAddress2 = rsCustomer.Fields(2).Value
                Else
                    m_RawData.CustomerAddress2 = ""
                End If
                m_RawData.TranscationDate = ""
                m_RawData.InvoiceNumber = ""
                If dr("QuantitySold") = 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If
                m_RawData.ItemNumber = dr("ItemCode")
                m_RawData.ItemDescription = ""
                m_RawData.WarehouseNumber = ""
                m_RawData._Class = ""
                Quantitys = 0
                If dr("ItemCode") = "209121" Then
                    Quantitys = dr("QuantitySold") * Val(6)
                    m_RawData.QuantitySold = Quantitys
                Else
                    Quantitys = dr("QuantitySold")
                    totalQuantity += dr("QuantitySold")
                    m_RawData.QuantitySold = Quantitys
                End If
                m_RawData.QuantityFree = 0
                GrossAmount = 0
                Dim rsDistributors As New ADODB.Recordset
                If rsDistributors.State = 1 Then rsDistributors.Close()
                rsDistributors.Open("Select * from distributoritems where DISTITEMCD = '" & dr("ItemCode") & "' And DISTITEMCD <> '' And COMID = 'MDC' ", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset)
                If rsDistributors.RecordCount <> 0 Then
                    GrossAmount = rsDistributors.Fields(4).Value * dr("QuantitySold")
                End If
                m_RawData.GrossAmount = GrossAmount
                m_RawData.LineDiscount = 0
                m_RawData.ProductDiscount = 0
                m_RawData.VatCode = ""
                m_RawData.Route = ""
                m_RawData.Taxes = 0
                m_RawData.Freight = 0
                m_RawData.Additional = 0
                TotalNetAmount = 0
                Dim rsDistributor As New ADODB.Recordset
                If rsDistributor.State = 1 Then rsDistributor.Close()
                rsDistributor.Open("Select * from distributoritems where DISTITEMCD = '" & dr("ItemCode") & "' And DISTITEMCD <> '' And COMID = 'MDC'  ", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset)
                If rsDistributor.RecordCount <> 0 Then
                    TotalNetAmount = rsDistributor.Fields(4).Value * dr("QuantitySold")
                    TotalGrossAmount += rsDistributor.Fields(4).Value * dr("QuantitySold")
                End If
                m_RawData.NetAmount = TotalNetAmount
                m_RawData.UnitPrice = 0
                m_RawData.InvoiceReferenceNumber = -1
                m_RawData.CMCode = ""
                m_RawData.SONumber = -1
                m_RawData.SODate = ""
                m_RawData.SOTerms = ""
                m_RawData.ExpiryDate = ""
                m_RawData.LotNumber = ""
                m_RawData.SalesmanNumber = ""
                m_RawData.SalesmanName = ""
                If rsCustomer.RecordCount <> 0 Then
                    m_RawData.ShipToName = rsCustomer.Fields(0).Value
                Else
                    m_RawData.ShipToName = ""
                End If
                If rsCustomer.RecordCount <> 0 Then
                    m_RawData.ShipToAddress1 = rsCustomer.Fields(1).Value
                Else
                    m_RawData.ShipToAddress1 = ""
                End If
                If rsCustomer.RecordCount <> 0 Then
                    m_RawData.ShipToAddress2 = rsCustomer.Fields(2).Value
                Else
                    m_RawData.ShipToAddress2 = ""
                End If
                m_RawData.Zipcode = ""
                m_RawData.TerritoryNumber = ""
                m_RawData.Area = ""
                m_RawData.CustomerClass = ""
                m_RawData.ClassName = ""
                m_RawData.Principal = ""
                m_RawData.SubPrincipal = ""
                m_RawData.PrincipalDivisionCode = ""
                m_RawData.SalesWeek = ""
                m_RawData.CustomerDeliveryCode = "001"
                m_RawData.ListOfTaxIncluse = ""
                m_RawData.ContractPrincipalApprovalNumber = ""
                m_RawData.OrderType = ""
                m_RawData.IsCode = ""
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text

                ctr += 1
                m_RawData.Save()
            Next
        End If
        ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & TotalGrossAmount & "','" & totalQuantity & "','" & TotalGrossAmount & "' )")
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        ' Me.Close()
    End Sub
    Private Sub ODIUploading()
        Dim a As Integer = 20
        Dim b As Integer = 18

        Dim ctr As Integer = 0
        Dim TotalQuantity As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim NETAmount As Decimal = 0
        Dim ProductDiscount As Decimal = 0

        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                If Not "ODI" = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData
                If IsDBNull(dr("Customer Code")) Then Exit For
                m_RawData.CompanyCode = cmbCompany.Text
                m_RawData.BranchCode = dr("Customer Code").ToString
                If IsDBNull(dr("Customer Name")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("Customer Name")
                End If

                m_RawData.CustomerNumber = dr("Customer Code")
                m_RawData.CustomerName = dr("Customer Name")
                If dr("Ship To Address") <> "" Then
                    m_RawData.CustomerAddress = dr("Ship To Address")
                    m_RawData.ShipToAddress1 = dr("Ship To Address")
                Else
                    m_RawData.CustomerAddress = ""
                    m_RawData.ShipToAddress1 = ""
                End If
                m_RawData.CustomerDeliveryCode = dr("Ship To Code")

                m_RawData.TranscationDate = dr("Invoice Date")

                m_RawData.InvoiceNumber = dr("Invoice Number")
                If dr("Gross Amount") < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If

                m_RawData.ItemNumber = dr("Item Code")
                m_RawData.ItemDescription = dr("Item Description")
                m_RawData.QuantitySold = CDec(dr("Gross Quantity"))
                m_RawData.QuantityFree = CDec(dr("Free Quantity"))
                TotalQuantity = TotalQuantity + CDec(dr("Gross Quantity"))

                _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                    Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                    Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal

                    Dim number As Double = CDec(dr("Net Amount VAT Ex"))

                    Dim number1 As Double = MuncipalVat * number

                    Dim Number2 As Double = DistMargin * number1

                    m_RawData.NetAmount = Number2

                    NETAmount = NETAmount + Number2
                    m_RawData.GrossAmount = CDec(dr("Net Amount VAT Ex"))
                    GrossAmount = GrossAmount + CDec(dr("Net Amount VAT Ex"))
                Else
                    m_RawData.NetAmount = CDec(dr("Net Amount VAT Ex"))
                    m_RawData.GrossAmount = CDec(dr("Net Amount VAT Ex"))
                    GrossAmount = GrossAmount + CDec(dr("Net Amount VAT Ex"))
                End If

                'm_RawData.GrossAmount = CDec(dr("Net Amount VAT Ex"))
                m_RawData.UnitPrice = CDec(dr("List Price"))
                'GrossAmount = GrossAmount + CDec(dr("Net Amount VAT Ex"))
                m_RawData.InvoiceNumber = dr("Invoice Number")
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                m_RawData.LotNumber = dr("Lot Number")
                m_RawData.ExpiryDate = dr("Expiry Date")
                m_RawData.WarehouseNumber = dr("Warehouse Code")
                m_RawData.Principal = dr("Principal Code")
                m_RawData.SOTerms = dr("Credit Term")
                m_RawData.PaymentType = ""
                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "' ,'" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & NETAmount & "' )")
        Else
            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                If Not "ODI" = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData
                If IsDBNull(dr("Customer Code")) Then Exit For
                m_RawData.CompanyCode = cmbCompany.Text
                m_RawData.BranchCode = dr("Customer Code").ToString
                If IsDBNull(dr("Customer Name")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("Customer Name")
                End If

                m_RawData.CustomerNumber = dr("Customer Code")
                m_RawData.CustomerName = dr("Customer Name")
                If dr("Ship To Address") <> "" Then
                    m_RawData.CustomerAddress = dr("Ship To Address")
                    m_RawData.ShipToAddress1 = dr("Ship To Address")
                Else
                    m_RawData.CustomerAddress = ""
                    m_RawData.ShipToAddress1 = ""
                End If
                m_RawData.CustomerDeliveryCode = dr("Ship To Code")

                m_RawData.TranscationDate = dr("Invoice Date")

                m_RawData.InvoiceNumber = dr("Invoice Number")
                If dr("Gross Amount") < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If

                m_RawData.ItemNumber = dr("Item Code")
                m_RawData.ItemDescription = dr("Item Description")
                m_RawData.QuantitySold = CDec(dr("Gross Quantity"))
                m_RawData.QuantityFree = CDec(dr("Free Quantity"))
                TotalQuantity = TotalQuantity + CDec(dr("Gross Quantity"))
                m_RawData.GrossAmount = CDec(dr("Net Amount VAT Ex"))
                m_RawData.UnitPrice = CDec(dr("List Price"))

                _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                    Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                    Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal

                    Dim number As Double = CDec(dr("Net Amount VAT Ex"))

                    Dim number1 As Double = MuncipalVat * number

                    Dim Number2 As Double = DistMargin * number1

                    m_RawData.NetAmount = Number2

                    NETAmount = NETAmount + Number2
                    m_RawData.GrossAmount = CDec(dr("Net Amount VAT Ex"))
                    GrossAmount = GrossAmount + CDec(dr("Net Amount VAT Ex"))
                Else
                    m_RawData.NetAmount = CDec(dr("Net Amount VAT Ex"))
                    m_RawData.GrossAmount = CDec(dr("Net Amount VAT Ex"))
                    GrossAmount = GrossAmount + CDec(dr("Net Amount VAT Ex"))
                End If

                'GrossAmount = GrossAmount + CDec(dr("Net Amount VAT Ex"))
                m_RawData.InvoiceNumber = dr("Invoice Number")
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                m_RawData.LotNumber = dr("Lot Number")
                m_RawData.ExpiryDate = dr("Expiry Date")
                m_RawData.WarehouseNumber = dr("Warehouse Code")
                m_RawData.Principal = dr("Principal Code")
                m_RawData.SOTerms = dr("Credit Term")
                m_RawData.PaymentType = ""
                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & NETAmount & "' )")
        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()

    End Sub
    Private Sub ODIGOVUploading()
        Dim a As Integer = 20
        Dim b As Integer = 18

        Dim ctr As Integer = 0
        Dim TotalQuantity As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim ProductDiscount As Decimal = 0

        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                If Not "ODIGOV" = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData
                If IsDBNull(dr("Customer Code")) Then Exit For
                m_RawData.CompanyCode = cmbCompany.Text
                m_RawData.BranchCode = dr("Customer Code").ToString
                If IsDBNull(dr("Customer Name")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("Customer Name")
                End If

                m_RawData.CustomerNumber = dr("Customer Code")
                m_RawData.CustomerName = dr("Customer Name")
                If dr("Ship To Address") <> "" Then
                    m_RawData.CustomerAddress = dr("Ship To Address")
                    m_RawData.ShipToAddress1 = dr("Ship To Address")
                Else
                    m_RawData.CustomerAddress = ""
                    m_RawData.ShipToAddress1 = ""
                End If
                m_RawData.CustomerDeliveryCode = dr("Ship To Code")

                m_RawData.TranscationDate = dr("Invoice Date")

                m_RawData.InvoiceNumber = dr("Invoice Number")
                If dr("Gross Amount") < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If

                m_RawData.ItemNumber = dr("Item Code")
                m_RawData.ItemDescription = dr("Item Description")
                m_RawData.QuantitySold = CDec(dr("Gross Quantity"))
                m_RawData.QuantityFree = CDec(dr("Free Quantity"))
                TotalQuantity = TotalQuantity + CDec(dr("Gross Quantity"))
                m_RawData.GrossAmount = CDec(dr("Net Amount VAT Ex"))
                m_RawData.UnitPrice = CDec(dr("List Price"))
                m_RawData.NetAmount = CDec(dr("Net Amount VAT Ex"))
                GrossAmount = GrossAmount + CDec(dr("Net Amount VAT Ex"))
                m_RawData.InvoiceNumber = dr("Invoice Number")
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                m_RawData.LotNumber = dr("Lot Number")
                m_RawData.ExpiryDate = dr("Expiry Date")
                m_RawData.WarehouseNumber = dr("Warehouse Code")
                m_RawData.Principal = dr("Principal Code")
                m_RawData.SOTerms = dr("Credit Term")
                m_RawData.PaymentType = ""
                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "' ,'" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        Else
            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                If Not "ODIGOV" = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData
                If IsDBNull(dr("Customer Code")) Then Exit For
                m_RawData.CompanyCode = cmbCompany.Text
                m_RawData.BranchCode = dr("Customer Code").ToString
                If IsDBNull(dr("Customer Name")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("Customer Name")
                End If

                m_RawData.CustomerNumber = dr("Customer Code")
                m_RawData.CustomerName = dr("Customer Name")
                If dr("Ship To Address") <> "" Then
                    m_RawData.CustomerAddress = dr("Ship To Address")
                    m_RawData.ShipToAddress1 = dr("Ship To Address")
                Else
                    m_RawData.CustomerAddress = ""
                    m_RawData.ShipToAddress1 = ""
                End If
                m_RawData.CustomerDeliveryCode = dr("Ship To Code")

                m_RawData.TranscationDate = dr("Invoice Date")

                m_RawData.InvoiceNumber = dr("Invoice Number")
                If dr("Gross Amount") < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If

                m_RawData.ItemNumber = dr("Item Code")
                m_RawData.ItemDescription = dr("Item Description")
                m_RawData.QuantitySold = CDec(dr("Gross Quantity"))
                m_RawData.QuantityFree = CDec(dr("Free Quantity"))
                TotalQuantity = TotalQuantity + CDec(dr("Gross Quantity"))
                m_RawData.GrossAmount = CDec(dr("Net Amount VAT Ex"))
                m_RawData.UnitPrice = CDec(dr("List Price"))
                m_RawData.NetAmount = CDec(dr("Net Amount VAT Ex"))
                GrossAmount = GrossAmount + CDec(dr("Net Amount VAT Ex"))
                m_RawData.InvoiceNumber = dr("Invoice Number")
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                m_RawData.LotNumber = dr("Lot Number")
                m_RawData.ExpiryDate = dr("Expiry Date")
                m_RawData.WarehouseNumber = dr("Warehouse Code")
                m_RawData.Principal = dr("Principal Code")
                m_RawData.SOTerms = dr("Credit Term")
                m_RawData.PaymentType = ""
                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()

    End Sub
    Private Sub UploadingActimed()
        Dim b As Integer = 18
        Dim num As String
        Dim null As Char
        Dim ctr As Integer = 0
        Dim TotalNetAmount As Decimal = 0
        Dim GrossAmount
        Dim totalQuantity As Decimal = 0
        Dim Quantitys
        Dim ProductDiscount As Decimal = 0
        Dim _Month As String = String.Empty
        Dim TotalGrossAmount As Decimal = 0
        Dim a As Integer = 20
        Dim dateString As String = cmbMonth.Text + "01" + cmbYear.Text
        Dim format As String = "MMddyyyy"

        Dim startDate As Date = DateTime.ParseExact(dateString, format, System.Globalization.CultureInfo.InvariantCulture)

        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                If Not "ACT" = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData
                If IsDBNull(dr("Card Code")) Then Exit For
                m_RawData.CompanyCode = "ACT"
                m_RawData.BranchCode = dr("Card Code").ToString
                If IsDBNull(dr("Customer Name")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("Customer Name")
                End If

                m_RawData.CustomerNumber = dr("Card Code")
                m_RawData.CustomerName = dr("Customer Name")
                If IsDBNull(dr("Address")) Then
                    m_RawData.CustomerAddress = ""
                    m_RawData.ShipToAddress1 = ""
                Else
                    m_RawData.CustomerAddress = dr("Address")
                    m_RawData.ShipToAddress1 = dr("Address")
                End If
                m_RawData.CustomerDeliveryCode = "001"

                m_RawData.TranscationDate = dr("Doc Date")

                m_RawData.InvoiceNumber = dr("Doc #")
                If dr("Qty") < 0 Then
                    m_RawData.TransactionType = "CR"
                    table = GetRecords(Items.GetItempricelist(dr("ItemCode"), cmbCompany.Text, startDate))
                    For i As Integer = 0 To table.Rows.Count - 1
                        _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                        If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                            Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                            Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal
                            Dim number As Double = dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                            Dim number1 As Double = MuncipalVat * number
                            Dim Number2 As Double = DistMargin * number1
                            m_RawData.NetAmount = Number2
                            TotalNetAmount = TotalNetAmount + Number2
                        Else
                            m_RawData.NetAmount = dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                            TotalNetAmount = TotalNetAmount + dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                            m_RawData.GrossAmount = dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                            TotalGrossAmount = TotalGrossAmount + dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                        End If
                    Next
                Else
                    m_RawData.TransactionType = "IV"
                    table = GetRecords(Items.GetItempricelist(dr("ItemCode"), cmbCompany.Text, startDate))
                    For i As Integer = 0 To table.Rows.Count - 1
                        _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                        If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                            Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                            Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal
                            Dim number As Double = dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                            Dim number1 As Double = MuncipalVat * number
                            Dim Number2 As Double = DistMargin * number1
                            m_RawData.NetAmount = Number2
                            TotalNetAmount = TotalNetAmount + Number2
                        Else
                            m_RawData.NetAmount = dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                            TotalNetAmount = TotalNetAmount + dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                            m_RawData.GrossAmount = dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                            TotalGrossAmount = TotalGrossAmount + dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                        End If
                    Next
                End If

                m_RawData.ItemNumber = dr("Itemcode")
                m_RawData.ItemDescription = dr("Item Name")
                m_RawData.QuantitySold = CDec(dr("Qty"))
                m_RawData.QuantityFree = "0.00"
                totalQuantity = totalQuantity + CDec(dr("Qty"))
                m_RawData.UnitPrice = "0.00"

                'If dr("Qty") < 0 Then

                'Else
                '    Dim rsDistributor As New ADODB.Recordset
                '    If rsDistributor.State = 1 Then rsDistributor.Close()
                '    rsDistributor.Open("Select * from distributoritems where DISTITEMCD = '" & dr("Itemcode") & "' And DISTITEMCD <> '' And COMID = 'ACT'  And IsActive = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset)
                '    If rsDistributor.RecordCount <> 0 Then
                '        m_RawData.GrossAmount = rsDistributor.Fields(4).Value * dr("Qty")
                '        TotalGrossAmount += rsDistributor.Fields(4).Value * dr("Qty")
                '    End If
                'End If
                m_RawData.InvoiceNumber = dr("Doc #")
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "' ,'" & cmbMonth.Text & "','" & cmbYear.Text & "','" & TotalGrossAmount & "','" & totalQuantity & "','" & TotalNetAmount & "' )")
        Else
            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                If Not "ACT" = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData
                If IsDBNull(dr("Card Code")) Then Exit For
                m_RawData.CompanyCode = "ACT"
                m_RawData.BranchCode = dr("Card Code").ToString
                If IsDBNull(dr("Customer Name")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("Customer Name")
                End If

                m_RawData.CustomerNumber = dr("Card Code")
                m_RawData.CustomerName = dr("Customer Name")
                If IsDBNull(dr("Address")) Then
                    m_RawData.CustomerAddress = ""
                    m_RawData.ShipToAddress1 = ""
                Else
                    m_RawData.CustomerAddress = dr("Address")
                    m_RawData.ShipToAddress1 = dr("Address")
                End If
                m_RawData.CustomerDeliveryCode = "001"

                m_RawData.TranscationDate = dr("Doc Date")

                m_RawData.InvoiceNumber = dr("Doc #")
                If dr("Qty") < 0 Then
                    m_RawData.TransactionType = "CR"
                    table = GetRecords(Items.GetItempricelist(dr("ItemCode"), cmbCompany.Text, startDate))
                    For i As Integer = 0 To table.Rows.Count - 1
                        _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                        If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                            Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                            Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal
                            Dim number As Double = dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                            Dim number1 As Double = MuncipalVat * number
                            Dim Number2 As Double = DistMargin * number1
                            m_RawData.NetAmount = Number2
                            TotalNetAmount = TotalNetAmount + Number2
                            m_RawData.GrossAmount = dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                        Else
                            m_RawData.NetAmount = dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                            TotalNetAmount = TotalNetAmount + dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                            m_RawData.GrossAmount = dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                            TotalGrossAmount = TotalGrossAmount + dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                        End If
                    Next
                Else
                    m_RawData.TransactionType = "IV"
                    table = GetRecords(Items.GetItempricelist(dr("ItemCode"), cmbCompany.Text, startDate))
                    For i As Integer = 0 To table.Rows.Count - 1
                        _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                        If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                            Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                            Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal
                            Dim number As Double = dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                            Dim number1 As Double = MuncipalVat * number
                            Dim Number2 As Double = DistMargin * number1
                            m_RawData.NetAmount = Number2
                            TotalNetAmount = TotalNetAmount + Number2
                            m_RawData.GrossAmount = dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                        Else
                            m_RawData.NetAmount = dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                            TotalNetAmount = TotalNetAmount + dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                            m_RawData.GrossAmount = dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                            TotalGrossAmount = TotalGrossAmount + dr("Qty") * table.Rows(i)("DISTITEMPRICE")
                        End If
                    Next
                End If

                m_RawData.ItemNumber = dr("Itemcode")
                m_RawData.ItemDescription = dr("Item Name")
                m_RawData.QuantitySold = CDec(dr("Qty"))
                m_RawData.QuantityFree = "0.00"
                totalQuantity = totalQuantity + CDec(dr("Qty"))
                m_RawData.UnitPrice = "0.00"

                'If dr("Qty") < 0 Then

                'Else
                '    Dim rsDistributor As New ADODB.Recordset
                '    If rsDistributor.State = 1 Then rsDistributor.Close()
                '    rsDistributor.Open("Select * from distributoritems where DISTITEMCD = '" & dr("Itemcode") & "' And DISTITEMCD <> '' And COMID = 'ACT'  And IsActive = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset)
                '    If rsDistributor.RecordCount <> 0 Then
                '        m_RawData.GrossAmount = rsDistributor.Fields(4).Value * dr("Qty")
                '        TotalGrossAmount += rsDistributor.Fields(4).Value * dr("Qty")
                '    End If
                'End If
                m_RawData.InvoiceNumber = dr("Doc #")
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "' ,'" & cmbMonth.Text & "','" & cmbYear.Text & "','" & TotalGrossAmount & "','" & totalQuantity & "','" & TotalNetAmount & "' )")
        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()

    End Sub
    Private Sub UploadMDCRUD()
        Dim b As Integer = 18
        Dim num As String
        Dim null As Char
        Dim ctr As Integer = 0
        Dim TotalNetAmount As Decimal = 0
        Dim GrossAmount
        Dim totalQuantity As Decimal = 0
        Dim Quantitys
        Dim ProductDiscount As Decimal = 0
        Dim _Month As String = String.Empty
        Dim TotalGrossAmount As Decimal = 0
        Dim a As Integer = 20

        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                If Not "MDCR" = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData
                If IsDBNull(dr("Customer Code")) Then Exit For
                m_RawData.CompanyCode = "MDCR"
                m_RawData.BranchCode = dr("BRANCH No#").ToString
                If IsDBNull(dr("BRANCH NAME")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("BRANCH NAME")
                End If
                m_RawData.CustomerNumber = dr("Customer Code")
                m_RawData.CustomerName = dr("BRANCH NAME")
                m_RawData.CustomerAddress = ""
                m_RawData.ShipToAddress1 = ""

                m_RawData.CustomerDeliveryCode = "001"
                m_RawData.TranscationDate = dr("DATE RECEIVED")

                m_RawData.InvoiceNumber = ""
                If dr("LOOSE") < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "CR"
                End If

                m_RawData.ItemNumber = dr("Item Code")
                m_RawData.ItemDescription = dr("DESCRIPTION")
                m_RawData.QuantitySold = CDec(dr("LOOSE"))
                m_RawData.QuantityFree = "0.00"
                totalQuantity = totalQuantity + CDec(dr("LOOSE"))
                m_RawData.GrossAmount = "0.00"
                m_RawData.UnitPrice = "0.00"
                If dr("LOOSE") < 0 Then
                Else
                    Dim rsDistributor As New ADODB.Recordset
                    If rsDistributor.State = 1 Then rsDistributor.Close()
                    rsDistributor.Open("Select * from distributoritems where DISTITEMCD = '" & dr("Item Code") & "' And DISTITEMCD <> '' And COMID = 'MDCR'  And IsActive = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset)
                    If rsDistributor.RecordCount <> 0 Then
                        m_RawData.NetAmount = rsDistributor.Fields(4).Value * dr("LOOSE")
                        TotalNetAmount += rsDistributor.Fields(4).Value * dr("LOOSE")

                    End If
                End If
                If dr("LOOSE") < 0 Then
                Else
                    Dim rsDistributor As New ADODB.Recordset
                    If rsDistributor.State = 1 Then rsDistributor.Close()
                    rsDistributor.Open("Select * from distributoritems where DISTITEMCD = '" & dr("Item Code") & "' And DISTITEMCD <> '' And COMID = 'MDCR'  And IsActive = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset)
                    If rsDistributor.RecordCount <> 0 Then
                        m_RawData.GrossAmount = rsDistributor.Fields(4).Value * dr("LOOSE")
                        TotalGrossAmount += rsDistributor.Fields(4).Value * dr("LOOSE")
                    End If
                End If
                m_RawData.InvoiceNumber = ""
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "' ,'" & cmbMonth.Text & "','" & cmbYear.Text & "','" & TotalGrossAmount & "','" & totalQuantity & "','" & TotalGrossAmount & "' )")
        Else
            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                If Not "MDCR" = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData
                If IsDBNull(dr("Customer Code")) Then Exit For
                m_RawData.CompanyCode = "MDCR"
                m_RawData.BranchCode = dr("BRANCH No#").ToString
                If IsDBNull(dr("BRANCH NAME")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("BRANCH NAME")
                End If
                m_RawData.CustomerNumber = dr("Customer Code")
                m_RawData.CustomerName = dr("BRANCH NAME")
                m_RawData.CustomerAddress = ""
                m_RawData.ShipToAddress1 = ""

                m_RawData.CustomerDeliveryCode = "001"
                m_RawData.TranscationDate = dr("DATE RECEIVED")

                m_RawData.InvoiceNumber = ""
                If dr("LOOSE") < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "CR"
                End If

                m_RawData.ItemNumber = dr("Item Code")
                m_RawData.ItemDescription = dr("DESCRIPTION")
                m_RawData.QuantitySold = CDec(dr("LOOSE"))
                m_RawData.QuantityFree = "0.00"
                totalQuantity = totalQuantity + CDec(dr("LOOSE"))
                m_RawData.GrossAmount = "0.00"
                m_RawData.UnitPrice = "0.00"
                If dr("LOOSE") < 0 Then
                Else
                    Dim rsDistributor As New ADODB.Recordset
                    If rsDistributor.State = 1 Then rsDistributor.Close()
                    rsDistributor.Open("Select * from distributoritems where DISTITEMCD = '" & dr("Item Code") & "' And DISTITEMCD <> '' And COMID = 'MDCR'  And IsActive = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset)
                    If rsDistributor.RecordCount <> 0 Then
                        m_RawData.NetAmount = rsDistributor.Fields(4).Value * dr("LOOSE")
                        TotalNetAmount += rsDistributor.Fields(4).Value * dr("LOOSE")

                    End If
                End If
                If dr("LOOSE") < 0 Then
                Else
                    Dim rsDistributor As New ADODB.Recordset
                    If rsDistributor.State = 1 Then rsDistributor.Close()
                    rsDistributor.Open("Select * from distributoritems where DISTITEMCD = '" & dr("Item Code") & "' And DISTITEMCD <> '' And COMID = 'MDCR'  And IsActive = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset)
                    If rsDistributor.RecordCount <> 0 Then
                        m_RawData.GrossAmount = rsDistributor.Fields(4).Value * dr("LOOSE")
                        TotalGrossAmount += rsDistributor.Fields(4).Value * dr("LOOSE")
                    End If
                End If
                m_RawData.InvoiceNumber = ""
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                ctr += 1
                m_RawData.Save()
            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "' ,'" & cmbMonth.Text & "','" & cmbYear.Text & "','" & TotalGrossAmount & "','" & totalQuantity & "','" & TotalGrossAmount & "' )")
        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()
    End Sub

    Private Sub AldrtzUploading()

        Dim a As Integer = 20
        Dim b As Integer = 18

        Dim ctr As Integer = 0
        Dim TotalQuantity As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim ProductDiscount As Decimal = 0
        Dim _Month As String = String.Empty

        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                If Not dr("DistributorCode") = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData

                m_RawData.CompanyCode = dr("DistributorCode")
                m_RawData.BranchCode = dr("CUSTOMERCD").ToString
                If IsDBNull(dr("CUSTOMERNAME")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("CUSTOMERNAME")
                End If

                m_RawData.CustomerNumber = dr("CUSTOMERCD")
                m_RawData.CustomerName = dr("CUSTOMERNAME")
                If dr("CADD1") <> "" Then
                    m_RawData.CustomerAddress = dr("CADD1")
                    m_RawData.ShipToAddress1 = dr("CADD1")
                Else
                    m_RawData.CustomerAddress = ""
                    m_RawData.ShipToAddress1 = ""
                End If

                If dr("CADD2") <> "" Then
                    m_RawData.CustomerAddress2 = dr("CADD2")
                    m_RawData.ShipToAddress2 = dr("CADD2")
                Else
                    m_RawData.CustomerAddress2 = ""
                    m_RawData.ShipToAddress2 = ""
                End If
                m_RawData.CustomerDeliveryCode = "001"


                m_RawData.TranscationDate = dr("Invoice Date")

                m_RawData.InvoiceNumber = dr("Invoice Number")
                If dr("Amount") < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If

                m_RawData.ItemNumber = dr("ITEMCD")
                m_RawData.ItemDescription = dr("IMDBRN")
                'If dr("VLAMT") = 0 Then
                'm_RawData.QuantityFree = dr("QuantityFree")
                '   TotalQuantity = TotalQuantity + dr("QTYSH")
                m_RawData.QuantitySold = dr("QuantitySold")
                ' Else
                m_RawData.QuantityFree = dr("QuantityFree")
                TotalQuantity = TotalQuantity + dr("QuantitySold")
                m_RawData.GrossAmount = dr("Amount")
                m_RawData.UnitPrice = dr("ListPrice")
                m_RawData.NetAmount = dr("Amount")
                GrossAmount = GrossAmount + dr("Amount")
                m_RawData.InvoiceNumber = dr("InvoiceNumber")
                m_RawData.LineDiscount = dr("Discount")
                m_RawData.SalesmanNumber = dr("SalesManCode")
                m_RawData.SalesmanName = dr("SLSMNNAME")
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                m_RawData.PaymentType = ""

                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "' ,'" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        Else

            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                If Not dr("DistributorCode") = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData

                m_RawData.CompanyCode = dr("DistributorCode")
                m_RawData.BranchCode = dr("CUSTOMERCD").ToString
                If IsDBNull(dr("CUSTOMERNAME")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("CUSTOMERNAME")
                End If
                m_RawData.CustomerNumber = dr("CUSTOMERCD")
                m_RawData.CustomerName = dr("CUSTOMERNAME")
                If dr("CADD1") <> "" Then
                    m_RawData.CustomerAddress = dr("CADD1")
                    m_RawData.ShipToAddress1 = dr("CADD1")
                Else
                    m_RawData.CustomerAddress = ""
                    m_RawData.ShipToAddress1 = ""
                End If

                If dr("CADD2") <> "" Then
                    m_RawData.CustomerAddress2 = dr("CADD2")
                    m_RawData.ShipToAddress2 = dr("CADD2")
                Else
                    m_RawData.CustomerAddress2 = ""
                    m_RawData.ShipToAddress2 = ""
                End If
                m_RawData.TranscationDate = dr("InvoiceDate")
                m_RawData.InvoiceNumber = dr("InvoiceNumber")
                If dr("Amount") < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If
                m_RawData.ItemNumber = dr("Itemcd")
                m_RawData.ItemDescription = dr("IMDBRN")
                'm_RawData.QuantityFree = dr("QuantityFree")
                m_RawData.QuantitySold = dr("QuantitySold")
                m_RawData.QuantityFree = dr("Quantityfree")
                TotalQuantity = TotalQuantity + dr("QuantitySold")
                'm_RawData.QuantityFree = 0
                m_RawData.GrossAmount = dr("Amount")
                m_RawData.UnitPrice = dr("ListPrice")
                m_RawData.NetAmount = dr("Amount")
                GrossAmount = GrossAmount + dr("Amount")
                m_RawData.InvoiceNumber = dr("InvoiceNumber")
                m_RawData.CustomerDeliveryCode = "001"
                m_RawData.LineDiscount = dr("Discount")
                m_RawData.LotNumber = ""
                m_RawData.SalesmanNumber = dr("SalesManCode")
                m_RawData.SalesmanName = dr("SLSMNNAME")
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                m_RawData.PaymentType = ""

                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()
    End Sub

    Private Sub Uploading()

        Try
            Dim a As Decimal = 0
            Dim b As Integer = 18
            Dim ctr As Integer = 0
            Dim TotalNetAmount As Decimal = 0
            Dim GrossAmount As Decimal = 0
            Dim totalQuantity As Decimal = 0
            Dim ProductDiscount As Decimal = 0
            Dim _Month As String = String.Empty


            If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
                For m As Integer = 0 To dt.Rows.Count - 1
                    ProgressBar1.Value = ctr / dt.Rows.Count * 100
                    Dim dr As DataRow = dt.Rows(m)

                    m_RawData = New RawData

                    m_RawData.CompanyCode = cmbCompany.Text
                    If IsDBNull(dr("Customer_Code")) Then
                        m_RawData.CustomerNumber = ""
                    Else
                        m_RawData.CustomerNumber = RefineSQL(dr("Customer_Code")).ToString
                    End If
                    If IsDBNull(dr("Customer Name")) Then
                        m_RawData.CustomerName = ""
                    Else
                        m_RawData.CustomerName = dr("Customer Name")
                    End If
                    If IsDBNull(dr("Invoice /CM Number")) Then
                        m_RawData.ItemNumber = ""
                    Else
                        m_RawData.InvoiceNumber = dr("Invoice /CM Number").ToString
                    End If
                    If IsDBNull(dr("Invoice /CM_Date")) Then
                        m_RawData.TranscationDate = ""
                    Else
                        m_RawData.TranscationDate = dr("Invoice /CM_Date").ToString
                    End If
                    If IsDBNull(dr("Item_Code")) Then
                        m_RawData.ItemNumber = ""
                    Else
                        m_RawData.ItemNumber = dr("Item_Code")
                    End If
                    If IsDBNull(dr("Item_Name")) Then
                        m_RawData.ItemDescription = ""
                    Else
                        m_RawData.ItemDescription = dr("Item_Name")
                    End If
                    'If dr("Net") = 0 Then
                    '    m_RawData.QuantityFree = dr("Quantity")
                    'Else
                    '    m_RawData.QuantitySold = dr("Quantity")
                    'End If
                    If IsDBNull(dr("Quantity")) Then
                        m_RawData.QuantitySold = "0"
                    Else
                        m_RawData.QuantitySold = dr("Quantity")
                        totalQuantity = totalQuantity + dr("Quantity")
                    End If
                    If IsDBNull(dr("Free")) Then
                        m_RawData.QuantityFree = "0"
                    Else
                        m_RawData.QuantityFree = dr("Free")
                    End If

                    If IsDBNull(dr("TM Code")) Then
                        m_RawData.SalesmanNumber = ""
                    Else
                        m_RawData.SalesmanNumber = dr("TM Code").ToString
                    End If
                    If IsDBNull(dr("TM Name")) Then
                        m_RawData.SalesmanName = ""
                    Else
                        m_RawData.SalesmanName = dr("TM Name")
                    End If
                    If IsDBNull(dr("Batch Number")) Then
                        m_RawData.LotNumber = ""
                    Else
                        m_RawData.LotNumber = dr("Batch Number")
                    End If
                    If IsDBNull(dr("Expiry_Date")) Then
                        m_RawData.ExpiryDate = ""
                    Else
                        m_RawData.ExpiryDate = dr("Expiry_Date")
                    End If
                    If IsDBNull(dr("Distribution Name")) Then
                        m_RawData.CustomerAddress = ""
                    Else
                        m_RawData.CustomerAddress = dr("Distribution Name")
                    End If

                    If IsDBNull(dr("Net")) Then
                        m_RawData.NetAmount = "0"
                    Else
                        _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                        If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                            Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                            Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal

                            Dim number As Double = dr("Net")
                            m_RawData.GrossAmount = dr("Net")

                            Dim number1 As Double = MuncipalVat * number

                            Dim Number2 As Double = DistMargin * number1

                            m_RawData.NetAmount = Number2

                            TotalNetAmount = TotalNetAmount + Number2
                        Else

                            m_RawData.NetAmount = dr("Net")
                            TotalNetAmount = TotalNetAmount + dr("Net")
                            GrossAmount = GrossAmount + dr("Net")
                        End If
                    End If

                    If dr("Net") < 0 Then
                        m_RawData.TransactionType = "CR"
                    Else
                        m_RawData.TransactionType = "IV"
                    End If

                    m_RawData.CustomerDeliveryCode = "001"

                    m_RawData.OrderType = "N"
                    m_RawData.CutMO = cmbMonth.Text
                    m_RawData.CutYear = cmbYear.Text
                    m_RawData.PaymentType = ""

                    ctr += 1
                    m_RawData.Save()

                Next

                ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & totalQuantity & "','" & TotalNetAmount & "' )")

            Else

                RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
                For m As Integer = 0 To dt.Rows.Count - 1
                    ProgressBar1.Value = ctr / dt.Rows.Count * 100
                    Dim dr As DataRow = dt.Rows(m)

                    m_RawData = New RawData

                    m_RawData.CompanyCode = cmbCompany.Text
                    If IsDBNull(dr("Customer_Code")) Then
                        m_RawData.CustomerNumber = ""
                    Else
                        m_RawData.CustomerNumber = RefineSQL(dr("Customer_Code")).ToString
                    End If
                    If IsDBNull(dr("Customer Name")) Then
                        m_RawData.CustomerName = ""
                    Else
                        m_RawData.CustomerName = dr("Customer Name")
                    End If
                    If IsDBNull(dr("Invoice /CM Number")) Then
                        m_RawData.ItemNumber = ""
                    Else
                        m_RawData.InvoiceNumber = dr("Invoice /CM Number").ToString
                    End If
                    If IsDBNull(dr("Invoice /CM_Date")) Then
                        m_RawData.TranscationDate = ""
                    Else
                        m_RawData.TranscationDate = dr("Invoice /CM_Date").ToString
                    End If
                    If IsDBNull(dr("Item_Code")) Then
                        m_RawData.ItemNumber = ""
                    Else
                        m_RawData.ItemNumber = dr("Item_Code")
                    End If
                    If IsDBNull(dr("Item_Name")) Then
                        m_RawData.ItemDescription = ""
                    Else
                        m_RawData.ItemDescription = dr("Item_Name")
                    End If
                    'If dr("Net") = 0 Then
                    '    m_RawData.QuantityFree = dr("Quantity")
                    'Else
                    '    m_RawData.QuantitySold = dr("Quantity")
                    'End If
                    If IsDBNull(dr("Quantity")) Then
                        m_RawData.QuantitySold = "0"
                    Else
                        m_RawData.QuantitySold = dr("Quantity")
                        totalQuantity = totalQuantity + dr("Quantity")
                    End If
                    If IsDBNull(dr("Free")) Then
                        m_RawData.QuantityFree = "0"
                    Else
                        m_RawData.QuantityFree = dr("Free")
                    End If

                    If IsDBNull(dr("TM Code")) Then
                        m_RawData.SalesmanNumber = ""
                    Else
                        m_RawData.SalesmanNumber = dr("TM Code").ToString
                    End If
                    If IsDBNull(dr("TM Name")) Then
                        m_RawData.SalesmanName = ""
                    Else
                        m_RawData.SalesmanName = dr("TM Name")
                    End If
                    If IsDBNull(dr("Batch Number")) Then
                        m_RawData.LotNumber = ""
                    Else
                        m_RawData.LotNumber = dr("Batch Number")
                    End If
                    If IsDBNull(dr("Expiry_Date")) Then
                        m_RawData.ExpiryDate = ""
                    Else
                        m_RawData.ExpiryDate = dr("Expiry_Date")
                    End If
                    If IsDBNull(dr("Distribution Name")) Then
                        m_RawData.CustomerAddress = ""
                    Else
                        m_RawData.CustomerAddress = dr("Distribution Name")
                    End If

                    If IsDBNull(dr("Net")) Then
                        m_RawData.NetAmount = "0"
                    Else
                        _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                        If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                            Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                            Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal

                            Dim number As Double = dr("Net")
                            m_RawData.GrossAmount = dr("Net")

                            Dim number1 As Double = MuncipalVat * number

                            Dim Number2 As Double = DistMargin * number1

                            m_RawData.NetAmount = Number2

                            TotalNetAmount = TotalNetAmount + Number2
                        Else

                            m_RawData.NetAmount = dr("Net")
                            TotalNetAmount = TotalNetAmount + dr("Net")
                            GrossAmount = GrossAmount + dr("Net")
                        End If
                    End If

                    If dr("Net") < 0 Then
                        m_RawData.TransactionType = "CR"
                    Else
                        m_RawData.TransactionType = "IV"
                    End If

                    m_RawData.CustomerDeliveryCode = "001"

                    m_RawData.OrderType = "N"
                    m_RawData.CutMO = cmbMonth.Text
                    m_RawData.CutYear = cmbYear.Text
                    m_RawData.PaymentType = ""

                    ctr += 1
                    m_RawData.Save()

                Next

                ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & totalQuantity & "','" & TotalNetAmount & "' )")
            End If
            ProgressBar1.Visible = False
            MessageBox.Show("File Successfully Uploaded!")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub UploadingPRI()
        Dim a As Integer = 20
        Dim b As Integer = 18
        Dim TotalNetAmount As Decimal = 0
        Dim ctr As Integer = 0
        Dim TotalQuantity As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim ProductDiscount As Decimal = 0
        Dim _Month As String = String.Empty


        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)

                m_RawData = New RawData

                m_RawData.CompanyCode = dr("CMP")

                m_RawData.TranscationDate = dr("Date")
                m_RawData.CustomerNumber = dr("AccNum")
                m_RawData.CustomerName = dr("CustName")
                m_RawData.CustomerDeliveryCode = "001"
                If dr("Amount W/ VAT") < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If

                m_RawData.ItemNumber = dr("ItemCode")

                If dr("Amount W/ VAT") = 0 Then
                    m_RawData.QuantityFree = dr("QTY")
                Else
                    m_RawData.QuantitySold = dr("QTY")

                End If

                TotalQuantity = TotalQuantity + dr("Qty")
                m_RawData.GrossAmount = dr("Amount W/ VAT")

                m_RawData.NetAmount = dr("Amount W/ VAT")
                TotalNetAmount = TotalNetAmount + dr("Amount W/ VAT")
                GrossAmount = GrossAmount + dr("Amount W/ VAT")
                If IsDBNull(dr("NUm")) Then
                    m_RawData.InvoiceNumber = ""
                Else
                    m_RawData.InvoiceNumber = dr("Num")
                End If
                If IsDBNull(dr("RepCode")) Then
                    m_RawData.SalesmanNumber = ""
                Else
                    m_RawData.SalesmanNumber = dr("RepCode")
                End If
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text

                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "' ,'" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        Else


            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                If Not dr("CMP") = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData

                m_RawData.CompanyCode = dr("CMP")

                m_RawData.TranscationDate = dr("Date")
                m_RawData.CustomerNumber = dr("AccNum")
                m_RawData.CustomerName = dr("CustName")



                m_RawData.CustomerDeliveryCode = "001"



                If dr("Amount W/ VAT") < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If

                m_RawData.ItemNumber = dr("ItemCode")

                m_RawData.QuantitySold = dr("Qty")
                TotalQuantity = TotalQuantity + dr("Qty")
                m_RawData.GrossAmount = dr("Amount W/ VAT")

                m_RawData.NetAmount = dr("Amount W/ VAT")
                TotalNetAmount = TotalNetAmount + dr("Amount W/ VAT")
                GrossAmount = GrossAmount + dr("Amount W/ VAT")
                m_RawData.InvoiceNumber = dr("Num")
                If IsDBNull(dr("RepCode")) Then
                    m_RawData.SalesmanNumber = ""
                Else
                    m_RawData.SalesmanNumber = dr("RepCode")
                End If
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        End If


        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()
    End Sub
    Private Sub UploadingSSD()
        Dim a As Integer = 20
        Dim b As Integer = 18

        Dim ctr As Integer = 0
        Dim TotalQuantity As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim NetAmount As Decimal = 0
        Dim ProductDiscount As Decimal = 0

        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                If Not "SSD" = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData

                m_RawData.CompanyCode = "SSD"
                m_RawData.BranchCode = dr("Store Code").ToString
                If IsDBNull(dr("Store Description")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("Store Description")
                End If

                m_RawData.CustomerNumber = dr("Store Code")
                m_RawData.CustomerName = dr("Store Description")

                m_RawData.CustomerDeliveryCode = "001"

                If dr("Transfer In Amount TY (Ex-VAT)") < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If
                m_RawData.ItemNumber = dr("Product Code")
                m_RawData.ItemDescription = dr("Product Description")
                m_RawData.QuantitySold = CDec(dr("Transfer In Units TY"))
                m_RawData.QuantityFree = 0
                TotalQuantity = TotalQuantity + CDec(dr("Transfer In Units TY"))
                m_RawData.GrossAmount = CDec(dr("Transfer In Amount TY (Ex-VAT)"))
                _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                    Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                    Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal

                    Dim number As Double = CDec(dr("Transfer In Amount TY (Ex-VAT)"))

                    Dim number1 As Double = MuncipalVat * number

                    Dim Number2 As Double = DistMargin * number1

                    m_RawData.NetAmount = Number2

                    NetAmount = NetAmount + Number2
                Else
                    m_RawData.NetAmount = CDec(dr("Transfer In Amount TY (Ex-VAT)"))
                    NetAmount = NetAmount + CDec(dr("Transfer In Amount TY (Ex-VAT)"))
                    m_RawData.NetAmount = CDec(dr("Transfer In Amount TY (Ex-VAT)"))
                    GrossAmount = GrossAmount + CDec(dr("Transfer In Amount TY (Ex-VAT)"))
                End If


                'm_RawData.NetAmount = CDec(dr("Transfer In Amount TY (Ex-VAT)"))


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
                If Not "SSD" = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData

                m_RawData.CompanyCode = "SSD"
                m_RawData.BranchCode = dr("Store Code").ToString
                If IsDBNull(dr("Store Description")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("Store Description")
                End If

                m_RawData.CustomerNumber = dr("Store Code")
                m_RawData.CustomerName = dr("Store Description")

                m_RawData.CustomerDeliveryCode = "001"

                If dr("Transfer In Amount TY (Ex-VAT)") < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If
                m_RawData.ItemNumber = dr("Product Code")
                m_RawData.ItemDescription = dr("Product Description")
                m_RawData.QuantitySold = CDec(dr("Transfer In Units TY"))
                m_RawData.QuantityFree = 0
                TotalQuantity = TotalQuantity + CDec(dr("Transfer In Units TY"))
                m_RawData.GrossAmount = CDec(dr("Transfer In Amount TY (Ex-VAT)"))
                _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                    Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                    Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal

                    Dim number As Double = CDec(dr("Transfer In Amount TY (Ex-VAT)"))

                    Dim number1 As Double = MuncipalVat * number

                    Dim Number2 As Double = DistMargin * number1

                    m_RawData.NetAmount = Number2

                    NetAmount = NetAmount + Number2
                Else
                    m_RawData.NetAmount = CDec(dr("Transfer In Amount TY (Ex-VAT)"))
                    NetAmount = NetAmount + CDec(dr("Transfer In Amount TY (Ex-VAT)"))
                    m_RawData.NetAmount = CDec(dr("Transfer In Amount TY (Ex-VAT)"))
                    GrossAmount = GrossAmount + CDec(dr("Transfer In Amount TY (Ex-VAT)"))
                End If
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text

                ctr += 1
                m_RawData.Save()
            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()
    End Sub
    Private Sub UploadingExelZURE()
        Dim a As Integer = 20
        Dim b As Integer = 18
        On Error Resume Next
        Dim rsCustomer As New ADODB.Recordset
        Dim ctr As Integer = 0
        Dim TotalQuantity As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim NetAmount As Decimal = 0
        Dim TotalNetAmount As Decimal = 0
        Dim ProductDiscount As Decimal = 0

        Dim dateString As String = cmbMonth.Text + "01" + cmbYear.Text
        Dim format As String = "MMddyyyy"

        Dim startDate As Date = DateTime.ParseExact(dateString, format, System.Globalization.CultureInfo.InvariantCulture)

        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                m_RawData = New RawData

                m_RawData.CompanyCode = cmbCompany.Text
                m_RawData.CustomerNumber = dr("Store Code")
                If rsCustomer.State = 1 Then rsCustomer.Close()
                rsCustomer.Open("Select CUSTOMERNAME,CADD1,CADD2 FROM CUSTOMER WHERE CUSTOMERCD = '" & dr("Store Code").ToString & "' AND COMID = '" & cmbCompany.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset)
                If rsCustomer.RecordCount <> 0 Then
                    m_RawData.CustomerName = rsCustomer.Fields(0).Value
                Else
                    m_RawData.CustomerName = ""
                End If

                m_RawData.BranchCode = dr("Store Code").ToString
                If rsCustomer.State = 1 Then rsCustomer.Close()
                rsCustomer.Open("Select CUSTOMERNAME,CADD1,CADD2 FROM CUSTOMER WHERE CUSTOMERCD = '" & dr("Store Code").ToString & "' AND COMID = '" & cmbCompany.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset)
                If rsCustomer.RecordCount <> 0 Then
                    m_RawData.BranchName = rsCustomer.Fields(0).Value
                Else
                    m_RawData.BranchName = ""
                End If

                m_RawData.CustomerDeliveryCode = "001"

                If dr("Sales Units TY") < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If
                m_RawData.ItemNumber = dr("SKU Code")
                m_RawData.ItemDescription = dr("SKU Name")
                m_RawData.QuantitySold = CDec(dr("Sales Units TY"))
                m_RawData.QuantityFree = 0
                TotalQuantity = TotalQuantity + CDec(dr("Sales Units TY"))


                table = GetRecords(Items.GetItempricelist(dr("SKU Code"), cmbCompany.Text, startDate))
                For i As Integer = 0 To table.Rows.Count - 1
                    GrossAmount = CDec(dr("Sales Units TY")) * table.Rows(i)("DISTITEMPRICE")
                    NetAmount = CDec(dr("Sales Units TY")) * table.Rows(i)("DISTITEMPRICE")
                Next

                _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                    Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                    Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal

                    Dim number As Double = NetAmount

                    Dim number1 As Double = MuncipalVat * number

                    Dim Number2 As Double = DistMargin * number1

                    m_RawData.NetAmount = Math.Round(Convert.ToDecimal(Number2), 2)

                    TotalNetAmount = TotalNetAmount + Number2
                    m_RawData.GrossAmount = Math.Round(Convert.ToDecimal(GrossAmount), 2)
                    GrossAmount += GrossAmount
                Else
                    m_RawData.NetAmount = Math.Round(Convert.ToDecimal(NetAmount), 2)
                    m_RawData.GrossAmount = Math.Round(Convert.ToDecimal(GrossAmount), 2)
                    GrossAmount += GrossAmount
                End If


                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text

                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "' ,'" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        Else
            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                m_RawData = New RawData

                m_RawData.CompanyCode = cmbCompany.Text
                m_RawData.CustomerNumber = dr("Store Code")
                If rsCustomer.State = 1 Then rsCustomer.Close()
                rsCustomer.Open("Select CUSTOMERNAME,CADD1,CADD2 FROM CUSTOMER WHERE CUSTOMERCD = '" & dr("Store Code").ToString & "' AND COMID = '" & cmbCompany.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset)
                If rsCustomer.RecordCount <> 0 Then
                    m_RawData.CustomerName = rsCustomer.Fields(0).Value
                Else
                    m_RawData.CustomerName = ""
                End If

                m_RawData.BranchCode = dr("Store Code").ToString
                If rsCustomer.State = 1 Then rsCustomer.Close()
                rsCustomer.Open("Select CUSTOMERNAME,CADD1,CADD2 FROM CUSTOMER WHERE CUSTOMERCD = '" & dr("Store Code").ToString & "' AND COMID = '" & cmbCompany.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset)
                If rsCustomer.RecordCount <> 0 Then
                    m_RawData.BranchName = rsCustomer.Fields(0).Value
                Else
                    m_RawData.BranchName = ""
                End If

                m_RawData.CustomerDeliveryCode = "001"

                If dr("Sales Units TY") < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If
                m_RawData.ItemNumber = dr("SKU Code")
                m_RawData.ItemDescription = dr("SKU Name")
                m_RawData.QuantitySold = CDec(dr("Sales Units TY"))
                m_RawData.QuantityFree = 0
                TotalQuantity = TotalQuantity + CDec(dr("Sales Units TY"))


                table = GetRecords(Items.GetItempricelist(dr("SKU Code"), cmbCompany.Text, startDate))
                For i As Integer = 0 To table.Rows.Count - 1
                    GrossAmount = CDec(dr("Sales Units TY")) * table.Rows(i)("DISTITEMPRICE")
                    NetAmount = CDec(dr("Sales Units TY")) * table.Rows(i)("DISTITEMPRICE")
                Next

                _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                    Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                    Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal

                    Dim number As Double = NetAmount

                    Dim number1 As Double = MuncipalVat * number

                    Dim Number2 As Double = DistMargin * number1

                    m_RawData.NetAmount = Math.Round(Convert.ToDecimal(Number2), 2)

                    TotalNetAmount = TotalNetAmount + Number2
                    m_RawData.GrossAmount = Math.Round(Convert.ToDecimal(GrossAmount), 2)
                    GrossAmount += GrossAmount
                Else
                    m_RawData.NetAmount = Math.Round(Convert.ToDecimal(NetAmount), 2)
                    m_RawData.GrossAmount = Math.Round(Convert.ToDecimal(GrossAmount), 2)
                    GrossAmount += GrossAmount
                End If

                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text

                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()
    End Sub
    Private Sub UploadingExelWAT()
        Dim a As Integer = 20
        Dim b As Integer = 18

        Dim ctr As Integer = 0
        Dim TotalQuantity As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim NetAmount As Decimal = 0
        Dim ProductDiscount As Decimal = 0

        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                If Not "WAT" = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData

                m_RawData.CompanyCode = "WAT"
                m_RawData.BranchCode = dr("Store Code").ToString
                If IsDBNull(dr("Store Name")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("Store Name")
                End If

                m_RawData.CustomerNumber = dr("Store Code")
                m_RawData.CustomerName = dr("Store Name")

                m_RawData.CustomerDeliveryCode = "001"

                If dr("Gross Sales Retail TY") < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If
                m_RawData.ItemNumber = dr("SKU Code")
                m_RawData.ItemDescription = dr("SKU Name")
                m_RawData.QuantitySold = CDec(dr("Sales Units TY"))
                m_RawData.QuantityFree = 0
                TotalQuantity = TotalQuantity + CDec(dr("Sales Units TY"))

                _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                    Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                    Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal

                    Dim number As Double = CDec(dr("Gross Sales Retail TY"))

                    Dim number1 As Double = MuncipalVat * number

                    Dim Number2 As Double = DistMargin * number1

                    m_RawData.NetAmount = Number2

                    NetAmount = NetAmount + Number2
                    GrossAmount = GrossAmount + CDec(dr("Gross Sales Retail TY"))
                    m_RawData.GrossAmount = CDec(dr("Gross Sales Retail TY"))
                Else
                    m_RawData.NetAmount = CDec(dr("Gross Sales Retail TY"))
                    m_RawData.GrossAmount = CDec(dr("Gross Sales Retail TY"))
                    NetAmount = NetAmount + CDec(dr("Gross Sales Retail TY"))
                    GrossAmount = GrossAmount + CDec(dr("Gross Sales Retail TY"))
                End If
                'm_RawData.NetAmount = CDec(dr("Gross Sales Retail TY"))
                GrossAmount = GrossAmount + CDec(dr("Gross Sales Retail TY"))
                m_RawData.GrossAmount = CDec(dr("Gross Sales Retail TY"))
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text

                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "' ,'" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        Else
            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                If Not "WAT" = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData

                m_RawData.CompanyCode = "WAT"
                m_RawData.BranchCode = dr("Store Code").ToString
                If IsDBNull(dr("Store Name")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("Store Name")
                End If

                m_RawData.CustomerNumber = dr("Store Code")
                m_RawData.CustomerName = dr("Store Name")

                m_RawData.CustomerDeliveryCode = "001"

                If dr("Gross Sales Retail TY") < 0 Then
                    m_RawData.TransactionType = "CR"
                Else
                    m_RawData.TransactionType = "IV"
                End If
                m_RawData.ItemNumber = dr("SKU Code")
                m_RawData.ItemDescription = dr("SKU Name")
                m_RawData.QuantitySold = CDec(dr("Sales Units TY"))
                m_RawData.QuantityFree = 0
                TotalQuantity = TotalQuantity + CDec(dr("Sales Units TY"))

                _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                    Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                    Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal

                    Dim number As Double = CDec(dr("Gross Sales Retail TY"))

                    Dim number1 As Double = MuncipalVat * number

                    Dim Number2 As Double = DistMargin * number1

                    m_RawData.NetAmount = Number2

                    NetAmount = NetAmount + Number2
                    GrossAmount = GrossAmount + CDec(dr("Gross Sales Retail TY"))
                    m_RawData.GrossAmount = CDec(dr("Gross Sales Retail TY"))
                Else
                    m_RawData.NetAmount = CDec(dr("Gross Sales Retail TY"))
                    m_RawData.GrossAmount = CDec(dr("Gross Sales Retail TY"))
                    NetAmount = NetAmount + CDec(dr("Gross Sales Retail TY"))
                    GrossAmount = GrossAmount + CDec(dr("Gross Sales Retail TY"))
                End If
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text

                ctr += 1
                m_RawData.Save()
            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()
    End Sub
    
    Private Sub Uploadingmetro()


        Dim a As Integer = 20
        Dim b As Integer = 18

        Dim ctr As Integer = 0
        Dim TotalQuantity As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim ProductDiscount As Decimal = 0
        Dim _Month As String = String.Empty
        Dim TotalNetAmount As Decimal = 0

        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                'If Not dr("DistributorCode") = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData

                m_RawData.CompanyCode = cmbCompany.Text
                m_RawData.BranchCode = dr("Branch Code").ToString
                If IsDBNull(dr("Branch Name")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("Branch Name")
                End If

                m_RawData.CustomerNumber = dr("CUST CODE").ToString
                m_RawData.CustomerName = dr("Customer Name")
                m_RawData.ShipToAddress1 = dr("DELIVERY ADD1")
                m_RawData.ShipToAddress2 = dr("DELIVERY ADD2")
                If IsDBNull(dr("PRINCIPAL APPROVAL#")) Then
                    m_RawData.ContractPrincipalApprovalNumber = ""
                Else
                    m_RawData.ContractPrincipalApprovalNumber = dr("PRINCIPAL APPROVAL#")
                End If

                m_RawData.ClassName = dr("CUSTOMER CLASS")
                If IsDBNull(dr("SALES REP CODE")) Then
                    m_RawData.SalesmanNumber = ""
                Else
                    m_RawData.SalesmanNumber = dr("SALES REP CODE")
                End If
                If IsDBNull(dr("SALES REP NAME")) Then
                    m_RawData.SalesmanName = ""
                Else
                    m_RawData.SalesmanName = dr("SALES REP NAME")
                End If
                m_RawData.QuantitySold = dr("COM QTY")
                m_RawData.QuantityFree = dr("FG QTY")
                m_RawData.UnitPrice = dr("UNIT SELLING PRICE")
                m_RawData.ListOfTaxIncluse = dr("UNIT LIST PRICE")
                m_RawData.NetAmount = dr("NET SALES")
                m_RawData.ProductDiscount = dr("PRODUCT DISCOUNT")
                m_RawData.GrossAmount = dr("GROSS SALE")
                m_RawData.ShipToName = dr("DELIVERY NAME")
                m_RawData.OrderType = dr("ORDER TYPE")
                If dr("RETURN QTY") < 0 Then
                    m_RawData.QuantitySold = dr("RETURN QTY")
                End If
                If dr("RET FG") Then
                    m_RawData.QuantityFree = dr("RET FG")
                End If
                If IsDBNull(dr("CUST DELIVERY CODE")) Then
                    m_RawData.CustomerDeliveryCode = "001"
                Else
                    m_RawData.CustomerDeliveryCode = dr("CUST DELIVERY CODE")
                End If
                If IsDBNull(dr("REFERENCE INVOICE")).ToString Then
                    m_RawData.InvoiceReferenceNumber = -1
                Else
                    m_RawData.InvoiceReferenceNumber = dr("REFERENCE INVOICE").ToString
                End If
                If IsDBNull(dr("REASON CODE")) Then
                    m_RawData.CMCode = ""
                Else
                    m_RawData.CMCode = dr("REASON CODE")
                End If
                m_RawData.TranscationDate = dr("INV/CM DATE")
                m_RawData.InvoiceNumber = dr("INV/CM#")
                m_RawData.TransactionType = dr("TTYPE")
                m_RawData.Region = dr("STATE")
                m_RawData.ItemDescription = dr("ITEM DESCRIPTION")
                m_RawData.ItemNumber = dr("ITEM CODE")

                GrossAmount = GrossAmount + dr("GROSS SALE")
                TotalQuantity = TotalQuantity + dr("COM QTY")
                TotalNetAmount = TotalNetAmount + dr("NET SALES")

                m_RawData.OrderType = "N"
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                m_RawData.PaymentType = ""


                ctr += 1
                m_RawData.Save()

            Next

            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "' ,'" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & TotalNetAmount & "' )")

        Else

            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                m_RawData = New RawData

                m_RawData.CompanyCode = cmbCompany.Text
                m_RawData.BranchCode = dr("Branch Code").ToString
                If IsDBNull(dr("Branch Name")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("Branch Name")
                End If

                m_RawData.CustomerNumber = dr("CUST CODE").ToString
                m_RawData.CustomerName = dr("Customer Name")
                m_RawData.ShipToAddress1 = dr("DELIVERY ADD1")
                m_RawData.ShipToAddress2 = dr("DELIVERY ADD2")
                If IsDBNull(dr("PRINCIPAL APPROVAL#")) Then
                    m_RawData.ContractPrincipalApprovalNumber = ""
                Else
                    m_RawData.ContractPrincipalApprovalNumber = dr("PRINCIPAL APPROVAL#")
                End If

                m_RawData.ClassName = dr("CUSTOMER CLASS")
                If IsDBNull(dr("SALES REP CODE")) Then
                    m_RawData.SalesmanNumber = ""
                Else
                    m_RawData.SalesmanNumber = dr("SALES REP CODE")
                End If
                If IsDBNull(dr("SALES REP NAME")) Then
                    m_RawData.SalesmanName = ""
                Else
                    m_RawData.SalesmanName = dr("SALES REP NAME")
                End If
                m_RawData.QuantitySold = dr("COM QTY")
                m_RawData.QuantityFree = dr("FG QTY")
                m_RawData.UnitPrice = dr("UNIT SELLING PRICE")
                m_RawData.ListOfTaxIncluse = dr("UNIT LIST PRICE")
                m_RawData.NetAmount = dr("NET SALES")
                m_RawData.ProductDiscount = dr("PRODUCT DISCOUNT")
                m_RawData.GrossAmount = dr("GROSS SALE")
                m_RawData.ShipToName = dr("DELIVERY NAME")
                m_RawData.OrderType = dr("ORDER TYPE")
                If dr("RETURN QTY") < 0 Then
                    m_RawData.QuantitySold = dr("RETURN QTY")
                End If
                If dr("RET FG") Then
                    m_RawData.QuantityFree = dr("RET FG")
                End If
                If IsDBNull(dr("CUST DELIVERY CODE")) Then
                    m_RawData.CustomerDeliveryCode = "001"
                Else
                    m_RawData.CustomerDeliveryCode = dr("CUST DELIVERY CODE")
                End If
                If IsDBNull(dr("REFERENCE INVOICE")).ToString Then
                    m_RawData.InvoiceReferenceNumber = -1
                Else
                    m_RawData.InvoiceReferenceNumber = dr("REFERENCE INVOICE").ToString
                End If
                If IsDBNull(dr("REASON CODE")) Then
                    m_RawData.CMCode = ""
                Else
                    m_RawData.CMCode = dr("REASON CODE")
                End If
                m_RawData.TranscationDate = dr("INV/CM DATE")
                m_RawData.InvoiceNumber = dr("INV/CM#")
                m_RawData.TransactionType = dr("TTYPE")
                m_RawData.Region = dr("STATE")
                m_RawData.ItemDescription = dr("ITEM DESCRIPTION")
                m_RawData.ItemNumber = dr("ITEM CODE")
                GrossAmount = GrossAmount + dr("GROSS SALE")
                TotalQuantity = TotalQuantity + dr("COM QTY")
                TotalNetAmount = TotalNetAmount + dr("NET SALES")

                m_RawData.OrderType = "N"
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                m_RawData.PaymentType = ""

                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & TotalNetAmount & "' )")
        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()

    End Sub

    Private Sub UploadingGBEXC()


        Dim b As Integer = 18
        Dim ctr As Integer = 0
        Dim TotalNetAmount As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim totalQuantity As Decimal = 0
        Dim ProductDiscount As Decimal = 0
        Dim _Month As String = String.Empty


        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                '  If Not dr("Channel Code") = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData

                m_RawData.CompanyCode = cmbCompany.Text

                m_RawData.PrincipalCode = dr("F1")
                m_RawData.PricipalClass = dr("F2")
                m_RawData.CustomerNumber = dr("F3")
                m_RawData.CustomerName = dr("F4")
                m_RawData.CustomerAddress = dr("F5")
                m_RawData.CustomerAddress2 = dr("F6")
                m_RawData.Address3 = dr("F7")
                m_RawData.Address4 = dr("F8")
                m_RawData.Zipcode = dr("F9")
                m_RawData.SalesmanName = dr("F10")
                m_RawData.Area = dr("F11")
                m_RawData.InvoiceNumber = dr("F12")
                m_RawData.TranscationDate = dr("F13")
                m_RawData.TransactionType = dr("F14")
                m_RawData.SalesmanNumber = dr("F16")
                m_RawData.ItemNumber = dr("F17")
                m_RawData.ItemDescription = dr("F18")
                If dr("F19") = "-" Then
                    m_RawData.QuantitySold = "0"
                Else
                    m_RawData.QuantitySold = dr("F19")
                    totalQuantity = totalQuantity + dr("F19")

                End If
                If dr("F20") = "-" Then
                    m_RawData.QuantityFree = "0"
                Else
                    m_RawData.QuantityFree = dr("F20")
                End If
                If dr("F21") = "-" Then
                    m_RawData.NetAmount = "0"
                Else
                    m_RawData.NetAmount = dr("F21")
                    GrossAmount = GrossAmount + dr("F21")
                    TotalNetAmount = TotalNetAmount + dr("F21")
                End If
                m_RawData.CustomerDeliveryCode = "001"
                m_RawData.OrderType = "N"
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                m_RawData.PaymentType = ""

                ctr += 1
                m_RawData.Save()

            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "' ,'" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & totalQuantity & "','" & GrossAmount & "' )")

        Else
            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)

            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                m_RawData = New RawData

                m_RawData.CompanyCode = cmbCompany.Text

                m_RawData.PrincipalCode = dr("F1")
                m_RawData.PricipalClass = dr("F2")
                m_RawData.CustomerNumber = dr("F3")
                m_RawData.CustomerName = dr("F4")
                m_RawData.CustomerAddress = dr("F5")
                m_RawData.CustomerAddress2 = dr("F6")
                m_RawData.Address3 = dr("F7")
                m_RawData.Address4 = dr("F8")
                m_RawData.Zipcode = dr("F9")
                m_RawData.SalesmanName = dr("F10")
                m_RawData.Area = dr("F11")
                m_RawData.InvoiceNumber = dr("F12")
                m_RawData.TranscationDate = dr("F13")
                m_RawData.TransactionType = dr("F14")
                m_RawData.SalesmanNumber = dr("F16")
                m_RawData.ItemNumber = dr("F17")
                m_RawData.ItemDescription = dr("F18")
                If dr("F19") = "-" Then
                    m_RawData.QuantitySold = "0"
                Else
                    m_RawData.QuantitySold = dr("F19")
                    totalQuantity = totalQuantity + dr("F19")
                End If
                If dr("F20") = "-" Then
                    m_RawData.QuantityFree = "0"
                Else
                    m_RawData.QuantityFree = dr("F20")
                End If
                If dr("F21") = "-" Then
                    m_RawData.NetAmount = "0"
                Else
                    m_RawData.NetAmount = dr("F21")
                    GrossAmount = GrossAmount + dr("F21")
                    TotalNetAmount = TotalNetAmount + dr("F21")
                End If
                m_RawData.CustomerDeliveryCode = "001"
                m_RawData.OrderType = "N"
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                m_RawData.PaymentType = ""
                ctr += 1
                m_RawData.Save()
            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & totalQuantity & "','" & GrossAmount & "' )")
        End If

        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()

    End Sub
    Private Sub uploadingMer()

        On Error Resume Next
        Dim rsCustomer As New ADODB.Recordset
        Dim b As Integer = 18
        Dim num As String
        Dim null As Char
        Dim ctr As Integer = 0
        Dim TotalNetAmount
        Dim GrossAmount
        Dim totalQuantity As Decimal = 0
        Dim Quantitys
        Dim ProductDiscount As Decimal = 0
        Dim _Month As String = String.Empty
        Dim TotalGrossAmount As Decimal = 0
        Dim NETAmount As Decimal = 0
        Dim objReader As New StreamReader(txtfile.Text)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()
        Dim dateString As String = cmbMonth.Text + "01" + cmbYear.Text
        Dim format As String = "MMddyyyy"

        Dim startDate As Date = DateTime.ParseExact(dateString, format, System.Globalization.CultureInfo.InvariantCulture)
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()

        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For Each sLine In arrText
                If Trim(Mid(sLine, 1, 1)) = 2 Then
                    If IsNumeric(Trim(Mid(sLine, 1, 1))) Then
                        ProgressBar1.Value = ctr / arrText.Count * 100
                        m_RawData = New RawData
                        m_RawData.CompanyCode = cmbCompany.Text
                        m_RawData.BranchCode = Trim(Mid(sLine, 2, 4))
                        m_RawData.BranchName = ""
                        m_RawData.CustomerNumber = Trim(Mid(sLine, 2, 4))
                        If rsCustomer.State = 1 Then rsCustomer.Close()
                        rsCustomer.Open("Select CUSTOMERNAME,CADD1,CADD2 FROM CUSTOMER WHERE CUSTOMERCD = '" & Trim(Mid(sLine, 2, 4)) & "' AND COMID = '" & "MDC" & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset)
                        If rsCustomer.RecordCount <> 0 Then
                            m_RawData.CustomerName = rsCustomer.Fields(0).Value
                        Else
                            m_RawData.CustomerName = ""
                        End If
                        If rsCustomer.RecordCount <> 0 Then
                            m_RawData.CustomerAddress = rsCustomer.Fields(1).Value
                        Else
                            m_RawData.CustomerAddress = ""
                        End If
                        If rsCustomer.RecordCount <> 0 Then
                            m_RawData.CustomerAddress2 = rsCustomer.Fields(2).Value
                        Else
                            m_RawData.CustomerAddress2 = ""
                        End If
                        m_RawData.TranscationDate = Trim(Mid(sLine, 186, 8))
                        m_RawData.InvoiceNumber = ""
                        m_RawData.TransactionType = "IV"
                        m_RawData.ItemNumber = Trim(Mid(sLine, 6, 6))
                        m_RawData.ItemDescription = ""
                        m_RawData.WarehouseNumber = ""
                        m_RawData._Class = ""
                        Quantitys = 0
                        m_RawData.QuantityFree = 0
                        'GrossAmount = 0
                        'Dim rsDistributors As New ADODB.Recordset
                        'If rsDistributors.State = 1 Then rsDistributors.Close()
                        'rsDistributors.Open("Select * from distributoritems where DISTITEMCD = '" & Trim(Mid(sLine, 6, 6)) & "' And DISTITEMCD <> '' And COMID = 'MDC' And IsActive = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset)
                        'If rsDistributors.RecordCount <> 0 Then
                        '    GrossAmount = rsDistributors.Fields(4).Value * Trim(Mid(sLine, 12, 5))
                        'End If
                        'm_RawData.GrossAmount = GrossAmount
                        m_RawData.LineDiscount = 0
                        m_RawData.ProductDiscount = 0
                        m_RawData.VatCode = ""
                        m_RawData.Route = ""
                        m_RawData.Taxes = 0
                        m_RawData.Freight = 0
                        m_RawData.Additional = 0
                        TotalNetAmount = 0
                        If Trim(Mid(sLine, 6, 6)) = "896611" Then
                            table = GetRecords(Items.GetItempricelist(Trim(Mid(sLine, 6, 6)), cmbCompany.Text, startDate))
                            For i As Integer = 0 To table.Rows.Count - 1
                                Quantitys = Trim(Mid(sLine, 12, 5)) * Val(20)
                                _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                                If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                                    Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                                    Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal
                                    Dim number As Double = Quantitys * table.Rows(i)("DISTITEMPRICE")
                                    Dim number1 As Double = MuncipalVat * number
                                    Dim Number2 As Double = DistMargin * number1
                                    m_RawData.NetAmount = Number2
                                    NETAmount = NETAmount + Number2
                                    m_RawData.QuantitySold = Quantitys
                                    m_RawData.GrossAmount = Quantitys * table.Rows(i)("DISTITEMPRICE")
                                    GrossAmount = GrossAmount + Quantitys * table.Rows(i)("DISTITEMPRICE")
                                Else
                                    m_RawData.NetAmount = Quantitys * table.Rows(i)("DISTITEMPRICE")
                                    m_RawData.GrossAmount = Quantitys * table.Rows(i)("DISTITEMPRICE")
                                    GrossAmount = GrossAmount + Quantitys * table.Rows(i)("DISTITEMPRICE")
                                End If
                            Next
                        Else
                            Quantitys = Trim(Mid(sLine, 12, 5))
                            table = GetRecords(Items.GetItempricelist(Trim(Mid(sLine, 6, 6)), cmbCompany.Text, startDate))
                            For i As Integer = 0 To table.Rows.Count - 1
                                _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                                If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                                    Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                                    Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal
                                    Dim number As Double = Quantitys * table.Rows(i)("DISTITEMPRICE")
                                    Dim number1 As Double = MuncipalVat * number
                                    Dim Number2 As Double = DistMargin * number1
                                    m_RawData.NetAmount = Number2
                                    NETAmount = NETAmount + Number2
                                    m_RawData.QuantitySold = Quantitys
                                    m_RawData.GrossAmount = Quantitys * table.Rows(i)("DISTITEMPRICE")
                                Else
                                    m_RawData.QuantitySold = Quantitys
                                    m_RawData.NetAmount = Quantitys * table.Rows(i)("DISTITEMPRICE")
                                    m_RawData.GrossAmount = Quantitys * table.Rows(i)("DISTITEMPRICE")
                                    GrossAmount = GrossAmount + Quantitys * table.Rows(i)("DISTITEMPRICE")
                                End If
                            Next
                        End If
                        m_RawData.UnitPrice = 0
                        m_RawData.InvoiceReferenceNumber = -1
                        m_RawData.CMCode = ""
                        m_RawData.SONumber = -1
                        m_RawData.SODate = ""
                        m_RawData.SOTerms = ""
                        m_RawData.ExpiryDate = ""
                        m_RawData.LotNumber = ""
                        m_RawData.SalesmanNumber = ""
                        m_RawData.SalesmanName = ""
                        If rsCustomer.RecordCount <> 0 Then
                            m_RawData.ShipToName = rsCustomer.Fields(0).Value
                        Else
                            m_RawData.ShipToName = ""
                        End If
                        If rsCustomer.RecordCount <> 0 Then
                            m_RawData.ShipToAddress1 = rsCustomer.Fields(1).Value
                        Else
                            m_RawData.ShipToAddress1 = ""
                        End If
                        If rsCustomer.RecordCount <> 0 Then
                            m_RawData.ShipToAddress2 = rsCustomer.Fields(2).Value
                        Else
                            m_RawData.ShipToAddress2 = ""
                        End If
                        m_RawData.Zipcode = ""
                        m_RawData.TerritoryNumber = ""
                        m_RawData.Area = ""
                        m_RawData.CustomerClass = ""
                        m_RawData.ClassName = ""
                        m_RawData.Principal = ""
                        m_RawData.SubPrincipal = ""
                        m_RawData.PrincipalDivisionCode = ""
                        m_RawData.SalesWeek = ""
                        m_RawData.CustomerDeliveryCode = "001"
                        m_RawData.ListOfTaxIncluse = ""
                        m_RawData.ContractPrincipalApprovalNumber = ""
                        m_RawData.OrderType = ""
                        m_RawData.IsCode = ""
                        m_RawData.CutMO = cmbMonth.Text
                        m_RawData.CutYear = cmbYear.Text
                    End If
                End If
                ctr += 1
                m_RawData.Save()
            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & TotalGrossAmount & "','" & totalQuantity & "','" & NETAmount & "' )")
        Else
            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For Each sLine In arrText
                If Trim(Mid(sLine, 1, 1)) = 2 Then
                    If IsNumeric(Trim(Mid(sLine, 1, 1))) Then
                        ProgressBar1.Value = ctr / arrText.Count * 100
                        m_RawData = New RawData
                        m_RawData.CompanyCode = cmbCompany.Text
                        m_RawData.BranchCode = Trim(Mid(sLine, 2, 4))
                        m_RawData.BranchName = ""
                        m_RawData.CustomerNumber = Trim(Mid(sLine, 2, 4))
                        If rsCustomer.State = 1 Then rsCustomer.Close()
                        rsCustomer.Open("Select CUSTOMERNAME,CADD1,CADD2 FROM CUSTOMER WHERE CUSTOMERCD = '" & Trim(Mid(sLine, 2, 4)) & "' AND COMID = '" & "MDC" & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset)
                        If rsCustomer.RecordCount <> 0 Then
                            m_RawData.CustomerName = rsCustomer.Fields(0).Value
                        Else
                            m_RawData.CustomerName = ""
                        End If
                        If rsCustomer.RecordCount <> 0 Then
                            m_RawData.CustomerAddress = rsCustomer.Fields(1).Value
                        Else
                            m_RawData.CustomerAddress = ""
                        End If
                        If rsCustomer.RecordCount <> 0 Then
                            m_RawData.CustomerAddress2 = rsCustomer.Fields(2).Value
                        Else
                            m_RawData.CustomerAddress2 = ""
                        End If
                        m_RawData.TranscationDate = Trim(Mid(sLine, 186, 8))
                        m_RawData.InvoiceNumber = ""
                        m_RawData.TransactionType = "IV"
                        m_RawData.ItemNumber = Trim(Mid(sLine, 6, 6))
                        m_RawData.ItemDescription = ""
                        m_RawData.WarehouseNumber = ""
                        m_RawData._Class = ""
                        Quantitys = 0
                        m_RawData.QuantityFree = 0
                        GrossAmount = 0
                        'Dim rsDistributors As New ADODB.Recordset
                        'If rsDistributors.State = 1 Then rsDistributors.Close()
                        'rsDistributors.Open("Select * from distributoritems where DISTITEMCD = '" & Trim(Mid(sLine, 6, 6)) & "'  And DISTITEMCD <> '' And COMID = 'MDC'  And isActive = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset)
                        'If rsDistributors.RecordCount <> 0 Then
                        '    GrossAmount = rsDistributors.Fields(4).Value * Trim(Mid(sLine, 12, 5))
                        'End If
                        'm_RawData.GrossAmount = GrossAmount
                        m_RawData.LineDiscount = 0
                        m_RawData.ProductDiscount = 0
                        m_RawData.VatCode = ""
                        m_RawData.Route = ""
                        m_RawData.Taxes = 0
                        m_RawData.Freight = 0
                        m_RawData.Additional = 0
                        TotalNetAmount = 0
                        If Trim(Mid(sLine, 6, 6)) = "896611" Then
                            table = GetRecords(Items.GetItempricelist(Trim(Mid(sLine, 6, 6)), cmbCompany.Text, startDate))
                            For i As Integer = 0 To table.Rows.Count - 1
                                Quantitys = Trim(Mid(sLine, 12, 5)) * Val(20)
                                _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                                If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                                    Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                                    Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal
                                    Dim number As Double = Quantitys * table.Rows(i)("DISTITEMPRICE")
                                    Dim number1 As Double = MuncipalVat * number
                                    Dim Number2 As Double = DistMargin * number1
                                    m_RawData.NetAmount = Number2
                                    NETAmount = NETAmount + Number2
                                    m_RawData.QuantitySold = Quantitys
                                    m_RawData.GrossAmount = Quantitys * table.Rows(i)("DISTITEMPRICE")
                                Else
                                    m_RawData.QuantitySold = Quantitys
                                    m_RawData.NetAmount = Quantitys * table.Rows(i)("DISTITEMPRICE")
                                    m_RawData.GrossAmount = Quantitys * table.Rows(i)("DISTITEMPRICE")
                                    GrossAmount = GrossAmount + Quantitys * table.Rows(i)("DISTITEMPRICE")
                                End If
                            Next
                        Else
                            Quantitys = Trim(Mid(sLine, 12, 5))
                            table = GetRecords(Items.GetItempricelist(Trim(Mid(sLine, 6, 6)), cmbCompany.Text, startDate))
                            For i As Integer = 0 To table.Rows.Count - 1
                                _Distributor = Distributor.LoadByCode(m_RawData.CompanyCode)
                                If Distributor.VatCalculated(m_RawData.CompanyCode) Then
                                    Dim MuncipalVat As Double = _Distributor.MunTax / 100 ' Convert 99.5% to decimal
                                    Dim DistMargin As Double = _Distributor.DistMargin / 100 ' Convert 91.5% to decimal
                                    Dim number As Double = Quantitys * table.Rows(i)("DISTITEMPRICE")
                                    Dim number1 As Double = MuncipalVat * number
                                    Dim Number2 As Double = DistMargin * number1
                                    m_RawData.NetAmount = Number2
                                    NETAmount = NETAmount + Number2
                                    m_RawData.QuantitySold = Quantitys
                                    m_RawData.GrossAmount = Quantitys * table.Rows(i)("DISTITEMPRICE")
                                Else
                                    m_RawData.QuantitySold = Quantitys
                                    m_RawData.NetAmount = Quantitys * table.Rows(i)("DISTITEMPRICE")
                                    m_RawData.GrossAmount = Quantitys * table.Rows(i)("DISTITEMPRICE")
                                    GrossAmount = GrossAmount + Quantitys * table.Rows(i)("DISTITEMPRICE")
                                End If
                            Next
                        End If
                        m_RawData.UnitPrice = 0
                        m_RawData.InvoiceReferenceNumber = -1
                        m_RawData.CMCode = ""
                        m_RawData.SONumber = -1
                        m_RawData.SODate = ""
                        m_RawData.SOTerms = ""
                        m_RawData.ExpiryDate = ""
                        m_RawData.LotNumber = ""
                        m_RawData.SalesmanNumber = ""
                        m_RawData.SalesmanName = ""
                        If rsCustomer.RecordCount <> 0 Then
                            m_RawData.ShipToName = rsCustomer.Fields(0).Value
                        Else
                            m_RawData.ShipToName = ""
                        End If
                        If rsCustomer.RecordCount <> 0 Then
                            m_RawData.ShipToAddress1 = rsCustomer.Fields(1).Value
                        Else
                            m_RawData.ShipToAddress1 = ""
                        End If
                        If rsCustomer.RecordCount <> 0 Then
                            m_RawData.ShipToAddress2 = rsCustomer.Fields(2).Value
                        Else
                            m_RawData.ShipToAddress2 = ""
                        End If
                        m_RawData.Zipcode = ""
                        m_RawData.TerritoryNumber = ""
                        m_RawData.Area = ""
                        m_RawData.CustomerClass = ""
                        m_RawData.ClassName = ""
                        m_RawData.Principal = ""
                        m_RawData.SubPrincipal = ""
                        m_RawData.PrincipalDivisionCode = ""
                        m_RawData.SalesWeek = ""
                        m_RawData.CustomerDeliveryCode = "001"
                        m_RawData.ListOfTaxIncluse = ""
                        m_RawData.ContractPrincipalApprovalNumber = ""
                        m_RawData.OrderType = ""
                        m_RawData.IsCode = ""
                        m_RawData.CutMO = cmbMonth.Text
                        m_RawData.CutYear = cmbYear.Text
                    End If
                End If
                ctr += 1
                m_RawData.Save()
            Next
            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & TotalGrossAmount & "','" & totalQuantity & "','" & NETAmount & "' )")
        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        ' Me.Close()
    End Sub
    Private Sub UploadingRBC()

        Dim b As Integer = 18
        Dim null As Char
        Dim ctr As Integer = 0
        Dim GrossAmount As Decimal = 0
        Dim TotalQuantity As Decimal = 0
        Dim ProductDiscount As Decimal = 0
        Dim TotalNetAmount As Decimal = 0

        If Not RawData.CheckIfRawDataExist(cmbCompany.Text, cmbYear.Text, cmbMonth.Text) Then
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                '  If Not dr("Channel Code") = cmbCompany.Text Then Exit Sub
                m_RawData = New RawData


                m_RawData.CompanyCode = cmbCompany.Text

                m_RawData.BranchCode = dr("BR")
                m_RawData.CustomerNumber = dr("CusNo")
                m_RawData.CustomerName = dr("CustNm")
                If IsDBNull(dr("cadd1")) Then
                    m_RawData.CustomerAddress = " "
                Else
                    m_RawData.CustomerAddress = dr("cadd1")
                End If

                If IsDBNull(dr("cadd2")) Then
                    m_RawData.CustomerAddress2 = " "
                Else
                    m_RawData.CustomerAddress2 = dr("cadd2")
                End If
                If IsDBNull(dr("SHIP TO ADD1")) Then
                    m_RawData.ShipToAddress1 = ""
                Else
                    m_RawData.ShipToAddress1 = dr("SHIP TO ADD1")
                End If
                If IsDBNull(dr("SHIP TO ADD2")) Then
                    m_RawData.ShipToAddress2 = ""
                Else
                    m_RawData.ShipToAddress2 = dr("SHIP TO ADD2")
                End If
                m_RawData.CustomerClass = dr("CLS CODE")
                m_RawData.ClassName = dr("CLS DSCRPTN")
                If IsDBNull(dr("SRCODE")) Then
                    m_RawData.SalesmanNumber = 0
                Else
                    m_RawData.SalesmanNumber = dr("SRCODE")
                End If

                m_RawData.SalesmanName = dr("SR NAME")
                m_RawData.PrincipalCode = dr("PRIN")
                If IsDBNull(dr("SO Date")) Then
                    m_RawData.SODate = ""
                Else
                    m_RawData.SODate = dr("SO Date")
                End If

                m_RawData.TranscationDate = dr("INVDTE")
                m_RawData.TransactionType = dr("INVNO")
                m_RawData.CMCode = dr("REASN")
                m_RawData.ItemNumber = dr("PRODCD")
                m_RawData.ItemDescription = dr("PRODDSCRPTN")
                m_RawData.LotNumber = dr("LOTNO")
                m_RawData.ExpiryDate = dr("EXPDTE")
                If dr("QTYSH") = 0 Then
                    m_RawData.QuantityFree = dr("QTYSH")
                Else
                    m_RawData.QuantitySold = dr("QTYSH")
                End If
                m_RawData.UnitOfMesurement = dr("UM")
                If dr("Value") = 0 Then
                    m_RawData.NetAmount = 0
                Else
                    m_RawData.NetAmount = dr("Value")
                    GrossAmount = GrossAmount + dr("Value")
                    TotalNetAmount = TotalNetAmount + dr("Value")
                End If
                If dr("Unit Price") = 0 Then
                    m_RawData.UnitPrice = 0
                Else
                    m_RawData.UnitPrice = dr("Unit Price")
                End If

                m_RawData.LineDiscount = dr("DISC1 RATE")
                m_RawData.ProductDiscount = dr("DISC1 VLE")
                m_RawData.SOTerms = dr("TRMCDE")
                m_RawData.OrderType = dr("TYPE")
                m_RawData.CustomerDeliveryCode = "001"
                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                m_RawData.PaymentType = ""


                ctr += 1
                m_RawData.Save()

                ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "' ,'" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
            Next

        Else
            RawData.DeleteExistRawData(cmbCompany.Text, cmbYear.Text, cmbMonth.Text)
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)

                m_RawData = New RawData

                m_RawData.CompanyCode = cmbCompany.Text

                m_RawData.BranchCode = dr("BR")
                m_RawData.CustomerNumber = dr("CusNo")
                m_RawData.CustomerName = dr("CustNm")
                If IsDBNull(dr("cadd1")) Then
                    m_RawData.CustomerAddress = " "
                Else
                    m_RawData.CustomerAddress = dr("cadd1")
                End If

                If IsDBNull(dr("cadd2")) Then
                    m_RawData.CustomerAddress2 = " "
                Else
                    m_RawData.CustomerAddress2 = dr("cadd2")
                End If
                If IsDBNull(dr("SHIP TO ADD1")) Then
                    m_RawData.ShipToAddress1 = ""
                Else
                    m_RawData.ShipToAddress1 = dr("SHIP TO ADD1")
                End If
                If IsDBNull(dr("SHIP TO ADD2")) Then
                    m_RawData.ShipToAddress2 = ""
                Else
                    m_RawData.ShipToAddress2 = dr("SHIP TO ADD2")
                End If
                m_RawData.CustomerClass = dr("CLS CODE")
                m_RawData.ClassName = dr("CLS DSCRPTN")
                If IsDBNull(dr("SRCODE")) Then
                    m_RawData.SalesmanNumber = 0
                Else
                    m_RawData.SalesmanNumber = dr("SRCODE")
                End If


                m_RawData.SalesmanName = dr("SR NAME")
                m_RawData.PrincipalCode = dr("PRIN")
                If IsDBNull(dr("SO Date")) Then
                    m_RawData.SODate = ""
                Else
                    m_RawData.SODate = dr("SO Date")
                End If
                If IsDBNull(dr("SO No")) Then
                    m_RawData.SONumber = ""
                Else
                    m_RawData.SONumber = dr("SO No")
                End If

                m_RawData.TranscationDate = dr("INVDTE")
                m_RawData.TransactionType = dr("INVNO")
                m_RawData.CMCode = dr("REASN")
                m_RawData.ItemNumber = dr("PRODCD")
                m_RawData.ItemDescription = dr("PRODDSCRPTN")
                m_RawData.LotNumber = dr("LOTNO")
                m_RawData.ExpiryDate = dr("EXPDTE")
                If dr("QTYSH") = 0 Then
                    m_RawData.QuantityFree = dr("QTYSH")
                Else
                    m_RawData.QuantitySold = dr("QTYSH")
                End If
                m_RawData.UnitOfMesurement = dr("UM")
                If dr("Value") = 0 Then
                    m_RawData.NetAmount = 0
                Else
                    m_RawData.NetAmount = dr("Value")
                End If
                If dr("Unit Price") = 0 Then
                    m_RawData.UnitPrice = 0
                Else
                    m_RawData.UnitPrice = dr("Unit Price")
                End If

                m_RawData.LineDiscount = dr("DISC1 RATE")
                m_RawData.ProductDiscount = dr("DISC1 VLE")
                m_RawData.SOTerms = dr("TRMCDE")
                m_RawData.OrderType = dr("TYPE")
                m_RawData.CustomerDeliveryCode = "001"

                m_RawData.CutMO = cmbMonth.Text
                m_RawData.CutYear = cmbYear.Text
                m_RawData.PaymentType = ""

                ctr += 1
                m_RawData.Save()
            Next

            ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & cmbCompany.Text & "','" & txtfile.Text & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()
    End Sub
End Class