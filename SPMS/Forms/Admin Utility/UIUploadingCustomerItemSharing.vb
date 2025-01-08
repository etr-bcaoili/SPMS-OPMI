Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing
Imports System.Text
Imports Telerik.WinControls.UI
Imports System.Windows.Forms
Imports Telerik.WinControls
Public Class UIUploadingCustomerItemSharing
    Dim table As New DataTable
    Private m_DistributorPrimary As String = "OPCI"
    Private m_Channel As New Distributor
    Dim _ExcelResult As New ExcelCustomerItemSharing
    Dim dt As New DataTable
    Private Sub LoadYear()
        table = GetRecords(Configuration.GetYearbyConfig)
        For i As Integer = 0 To table.Rows.Count - 1
            DropYear.Items.Add(table.Rows(i)("CAYR"))
        Next
    End Sub
    Private Sub DropYear_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles DropYear.SelectedIndexChanged
        If DropYear.SelectedIndex = -1 Then Exit Sub
        LoadMonth(m_DistributorPrimary, DropYear.Text)
    End Sub
    Private Sub LoadMonth(ByVal DistributorCode As String, ByVal Year As String)
        DropMonth.Items.Clear()
        table = GetRecords(Configuration.GetMonthConfigtype(DistributorCode, Year))
        For i As Integer = 0 To table.Rows.Count - 1
            DropMonth.Items.Add(table.Rows(i)("CAPN"))
        Next
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Medical Configuration")
        If Not tag Is Nothing Then
            txtConfigtypeCode.Text = tag.KeyColumn11
            txtConfigtypeName.Text = tag.KeyColumn33
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If txtConfigtypeCode.Text <> "" Then
            Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Distributor.GetDistributorSql, "Search Item")
            If Not tag Is Nothing Then
                LoadChannel(tag.KeyColumn22)
            End If
        End If
    End Sub
    Private Sub LoadChannel(ByVal ChannelCode As String)
        m_Channel = Distributor.LoadByCode(ChannelCode)
        m_Channel.DISTCOMID = m_Channel.DISTCOMID
        txtChannelCode.Text = m_Channel.DISTCOMID
        txtChannelName.Text = m_Channel.DISTNAME
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        _ExcelResult.CompanyCode = m_Channel.DISTCOMID
        OpenFileDialog1.Title = "Item Price"
        OpenFileDialog1.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtFileName.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnStartProcess_Click(sender As Object, e As EventArgs) Handles btnStartProcess.Click
        Try
            If txtFileName.Text = "" Then
                MsgBox("No file to be Uploaded", MsgBoxStyle.Information, "Please Select file")
                Exit Sub
            End If
            pbar.Visible = True
            loadView()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub loadView()
        Try
            If _ExcelResult.CheckIfExist(txtFileName.Text) Then
                dt = _ExcelResult.GetExcelData(txtFileName.Text)
                If dt Is Nothing Then
                    MsgBox("No Record Upload!!!")
                Else
                    If dt.Rows.Count = 0 Then
                        MsgBox("No Record Upload!!!")
                    Else
                        Uploading()
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Uploading()
        Dim ctr As Integer = 0
        If Not CustomerItemSharingUploading.CheckUploadingFileExist(DropMonth.Text, DropYear.Text, txtConfigtypeCode.Text, txtChannelCode.Text) Then
            pbar.Visible = True
            For m As Integer = 0 To dt.Rows.Count - 1
                pbar.Value = ctr / dt.Rows.Count * 100
                Dim m_Sharing As New CustomerItemSharingUploading
                m_Sharing = New CustomerItemSharingUploading
                Dim dr As DataRow = dt.Rows(m)
                m_Sharing.ChannelCode = txtChannelCode.Text
                m_Sharing.ConfigtypeCode = txtConfigtypeCode.Text
                m_Sharing.Year = DropYear.Text
                m_Sharing.Month = DropMonth.Text

                If IsDBNull(dr("Customer Code")) Then
                    MsgBox("Customer Code is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.CustomerCode = dr("Customer Code")
                End If

                If IsDBNull(dr("Customer Name")) Then
                    MsgBox("Customer Name is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.CustomerName = dr("Customer Name")
                End If
                If IsDBNull(dr("Ship to Code")) Then
                    MsgBox("Customer Ship to Code is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.ShiptoCode = dr("Ship to Code")
                End If
                If IsDBNull(dr("Ship to Name")) Then
                    MsgBox("Customer ship to Name  is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.CustomerName = dr("Ship to Name")
                End If

                If IsDBNull(dr("Salesman Code")) Then
                    MsgBox("Salesman Code is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.SalesAgentCode = dr("Salesman Code")
                End If

                If IsDBNull(dr("ItemCode")) Then
                    MsgBox("Item Code is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.ItemCode = dr("ItemCode")
                End If

                If IsDBNull(dr("Per Share")) Then
                    MsgBox("Per Share is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.Shareds = dr("Per Share")
                End If
                If IsDBNull(dr("OR/SH")) Then
                    MsgBox("[ORIGINAL/SHARED] is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.OR_SH = dr("OR/SH")
                End If

                m_Sharing.Save()
                ctr += 1
            Next
            pbar.Visible = False
            UploadSuccess()
        Else
            CustomerItemSharingUploading.DeleteExistList(DropMonth.Text, DropYear.Text, txtConfigtypeCode.Text, txtChannelCode.Text)
            pbar.Visible = True
            For m As Integer = 0 To dt.Rows.Count - 1
                pbar.Value = ctr / dt.Rows.Count * 100
                Dim m_Sharing As New CustomerItemSharingUploading
                m_Sharing = New CustomerItemSharingUploading
                Dim dr As DataRow = dt.Rows(m)
                m_Sharing.ChannelCode = txtChannelCode.Text
                m_Sharing.ConfigtypeCode = txtConfigtypeCode.Text
                m_Sharing.Year = DropYear.Text
                m_Sharing.Month = DropMonth.Text

                If IsDBNull(dr("Customer Code")) Then
                    MsgBox("Customer Code is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.CustomerCode = dr("Customer Code")
                End If

                If IsDBNull(dr("Customer Name")) Then
                    MsgBox("Customer Name is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.CustomerName = dr("Customer Name")
                End If
                If IsDBNull(dr("Ship to Code")) Then
                    MsgBox("Customer Ship to Code is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.ShiptoCode = dr("Ship to Code")
                End If
                If IsDBNull(dr("Ship to Name")) Then
                    MsgBox("Customer ship to Name  is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.CustomerName = dr("Ship to Name")
                End If

                If IsDBNull(dr("Salesman Code")) Then
                    MsgBox("Salesman Code is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.SalesAgentCode = dr("Salesman Code")
                End If

                If IsDBNull(dr("ItemCode")) Then
                    MsgBox("Item Code is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.ItemCode = dr("ItemCode")
                End If

                If IsDBNull(dr("Per Share")) Then
                    MsgBox("Per Share is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.Shareds = dr("Per Share")
                End If
                If IsDBNull(dr("OR/SH")) Then
                    MsgBox("[ORIGINAL/SHARED] is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.OR_SH = dr("OR/SH")
                End If

                m_Sharing.Save()
                ctr += 1
            Next
            pbar.Visible = False
            UploadSuccess()
        End If
    End Sub

    Private Sub btnCanced_Click(sender As Object, e As EventArgs) Handles btnCanced.Click
        Me.Close()
    End Sub
    Private Sub UIUploadingCustomerItemSharing_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadYear()
    End Sub
End Class