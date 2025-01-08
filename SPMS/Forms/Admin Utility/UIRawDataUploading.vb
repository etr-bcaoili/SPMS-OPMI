Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Imports System.Data.OleDb
Imports System
Imports System.IO
Imports System.Collections
Imports System.Data.SqlClient
Public Class UIRawDataUploading

    Private m_OpenFolder As OpenFileDialog = New OpenFileDialog
    Dim table As New DataTable
    Dim dt As New DataTable
    Dim _ExcelResult As New ExcelUploading
    Private m_RawData As New RawData
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_CompanyName As String
    Private _Distributor As New Distributor
    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnUpload.Click, btnFind.Click, btnClose.Click
        If sender Is btnFind Then
            BrowseFile()
        ElseIf sender Is btnClose Then
            Me.Close()
        ElseIf sender Is btnUpload Then
            If ValidateData() Then
                UploadFile()
            End If
        End If
    End Sub
    Private Sub BrowseFile()
        OpenFileDialog1.Title = "RawData Uploading"
        If cmbFiletype.Text = ".XLS" Then
            OpenFileDialog1.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*"
        ElseIf cmbFiletype.Text = ".TXT" Then
            OpenFileDialog1.Filter = "Text files(*.txt)|*.txt"
        ElseIf cmbFiletype.Text = ".SP" Then
            OpenFileDialog1.Filter = "SP files(*.SP)|*.SP"
        End If
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtFindName.Text = OpenFileDialog1.FileName
        End If
    End Sub
    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False
        If txtChannelCode.Text = String.Empty Or txtChannelName.Text = String.Empty Then
            m_Err.SetError(txtChannelName, "Channel Company is required!")
            m_HasError = True
        End If

        If cboyear.Text = String.Empty Then
            m_Err.SetError(cboyear, "Year is required!")
            m_HasError = True
        End If

        If cboMonth.Text = String.Empty Then
            m_Err.SetError(cboMonth, "Month is required!")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
    Private Sub UploadFile()
        If txtFindName.Text = "" Then
            MsgBox("No file to be uploaded", MsgBoxStyle.Information, "Please select file")
            Exit Sub
        End If
        pbar.Visible = True
        If cmbFiletype.Text = ".TXT" Then
            If txtChannelCode.Text = "MDCMD" Then
                UploadingGBDistributor()
                Exit Sub
            End If
        End If
        'If cmbFiletype.Text = ".XLS" Then
        '    loadView()
        '    Exit Sub
        'End If
        'If cmbFiletype.Text = ".SP" Then
        '    uploadingMer()
        'End If
    End Sub
    Private Sub UploadingGBDistributor()
        Dim b As Integer = 18
        Dim null As Char
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
        Dim objReader As New StreamReader(txtFindName.Text)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()
        Dim Num As Integer
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()


        RawData.DeleteExistRawData(txtChannelCode.Text, cboyear.Text, cboMonth.Text)
        For Each sLine In arrText
            pbar.Value = ctr / arrText.Count * 100
            m_RawData = New RawData
            m_RawData.CompanyCode = txtChannelCode.Text
            Num = Trim(Mid(sLine, 1, 5))
            m_RawData.BranchCode = String.Format("{0:000#}", Num)
            m_RawData.BranchName = Trim(Mid(sLine, 6, 36))
            m_RawData.CustomerNumber = Trim(Mid(sLine, 1, 5))
            m_RawData.CustomerDeliveryCode = "001"
            m_RawData.TranscationDate = Trim(Mid(sLine, 37, 15))
            m_RawData.CustomerName = Trim(Mid(sLine, 53, 31))
            m_RawData.SalesmanName = Trim(Mid(sLine, 89, 13))
            m_RawData.CustomerAddress = Trim(Mid(sLine, 97, 36))
            m_RawData.CustomerAddress2 = Trim(Mid(sLine, 133, 31))
            m_RawData.Principal = Trim(Mid(sLine, 206, 31))
            m_RawData.ItemNumber = Trim(Mid(sLine, 237, 9))
            m_RawData.ItemDescription = Trim(Mid(sLine, 246, 30))
            m_RawData.QuantitySold = Trim(Mid(sLine, 289, 3))
            TotalQuantity += Trim(Mid(sLine, 289, 3))
            m_RawData.NetAmount = Trim(Mid(sLine, 292, 16))
            GrossAmount += Trim(Mid(sLine, 292, 16))
            m_RawData.CutMO = cboMonth.Text
            m_RawData.CutYear = cboyear.Text
            ctr += 1
            m_RawData.Save()
        Next
        ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & txtChannelCode.Text & "','" & txtFindName.Text & "','" & cboMonth.Text & "','" & cboyear.Text & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        pbar.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()
    End Sub

    Private Sub FindBestTimeCall_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles FindBestTimeCall.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Distributor.GetDistributorSql, "Distributor")
        If Not tag Is Nothing Then
            ShowData(tag.KeyColumn11)
            LoadYear(txtChannelCode.Text)
        End If
    End Sub
    Private Sub Clear()
        txtChannelCode.Text = String.Empty
        txtChannelName.Text = String.Empty
        txtFindName.Text = String.Empty
    End Sub

    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        If RecordCode < 1 Then Exit Sub
        _Distributor = Distributor.Load(RecordCode)
        txtChannelCode.Tag = _Distributor.DISTRIBUTORID
        txtChannelCode.Text = _Distributor.DISTCOMID
        txtChannelName.Text = _Distributor.DISTNAME
    End Sub

    Private Sub cboyear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboyear.SelectedIndexChanged
        If cboyear.SelectedIndex = -1 Then Exit Sub
        LoadMonth(txtChannelCode.Text, cboyear.Text)
    End Sub
    Private Sub LoadYear(ByVal DistributorCode As String)
        table = GetRecords("SELECT Distinct CAYR  FROM Calendar WHERE COMID = '" & DistributorCode & "' ")
        For i As Integer = 0 To table.Rows.Count - 1
            cboyear.Items.Add(table.Rows(i)("CAYR"))
        Next
    End Sub

    Private Sub LoadMonth(ByVal DistributorCode As String, ByVal Year As String)

        table = GetRecords("SELECT * FROM Calendar WHERE COMID = '" & DistributorCode & "' AND CAYR = '" & Year & "' ")
        For I As Integer = 0 To table.Rows.Count - 1
            cboMonth.Items.Add(table.Rows(I)("CAPN"))
        Next
    End Sub

    Private Sub cboMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMonth.SelectedIndexChanged

    End Sub

    Private Sub txtChannelCode_TextChanged(sender As Object, e As EventArgs) Handles txtChannelCode.TextChanged

    End Sub

    Private Sub txtChannelName_TextChanged(sender As Object, e As EventArgs) Handles txtChannelName.TextChanged

    End Sub

    Private Sub lblItemCode_Click(sender As Object, e As EventArgs) Handles lblItemCode.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class