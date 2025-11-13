Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing
Imports System.Text
Imports Telerik.WinControls.UI
Imports System.Windows.Forms
Imports Telerik.WinControls
Imports DataLayer
Imports Telerik.Charting

Public Class UIProductManagerTargetUploading
    Dim table As New DataTable
    Private m_CompanyCode As New Company
    Private m_ProductManagerItem As New ProductManagerItem
    Dim _ExcelResult As New ExcelProductManagerItem
    Dim dt As New DataTable
    Private Sub LoadYear()
        table = GetRecords(Configuration.GetYearbyConfig)
        For i As Integer = 0 To table.Rows.Count - 1
            DropYear.Items.Add(table.Rows(i)("CAYR"))
        Next
    End Sub
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Medical Configuration")
        If Not tag Is Nothing Then
            txtConfigtypeCode.Text = tag.KeyColumn11
            txtConfigtypeName.Text = tag.KeyColumn33
        End If
    End Sub
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        '_ExcelResult.CompanyCode = m_Channel.DISTCOMID
        OpenFileDialog1.Title = "Product Manager Item"
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
                        ProductManagerItem.DeleteExistList(DropYear.Text, txtConfigtypeCode.Text)
                        Uploading()
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnCanced_Click(sender As Object, e As EventArgs) Handles btnCanced.Click
        Me.Close()
    End Sub
    Private Sub Uploading()
        Dim ctr As Integer = 0
        pbar.Visible = True
            For m As Integer = 0 To dt.Rows.Count - 1
                pbar.Value = ctr / dt.Rows.Count * 100
            Dim m_ProductManagerItem As New ProductManagerItem
            m_ProductManagerItem = New ProductManagerItem
            Dim dr As DataRow = dt.Rows(m)
            m_ProductManagerItem.ItemCode = dr("Item Code")
            m_ProductManagerItem.ItemName = dr("Item Description")
            m_ProductManagerItem.ProductGroupCode = dr("Product Group")
            m_ProductManagerItem.ConfigtypeCode = dr("ConfigtypeCode")
            m_ProductManagerItem.Year = dr("Year")
            m_ProductManagerItem.Month = dr("Month")
            m_ProductManagerItem.Quantity = dr("Quantity")
            m_ProductManagerItem.Amount = dr("Amount")
            m_ProductManagerItem.Createby = MainWindow.MainUserName
            m_ProductManagerItem.Save()
            ctr += 1
            Next
            pbar.Visible = False
        UploadSuccess()
    End Sub
    Private Sub LoadCompany()
        table = GetRecords(Company.GetCompanySql())
        For i As Integer = 0 To table.Rows.Count - 1
            m_CompanyCode.CompanyCode = table.Rows(i)("COMID")
        Next
    End Sub
    Private Sub UIProductManagerTargetUploading_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadYear()
        LoadCompany()
    End Sub


End Class