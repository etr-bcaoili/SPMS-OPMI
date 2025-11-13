Imports Main.SQLConnect
Imports Main.ConnectionModule
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Text
Imports Telerik.WinControls.UI
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Text.RegularExpressions
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI.Export
Imports Microsoft.Office.Interop
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Diagnostics.Eventing
Public Class UISASDistrictTarget
    Dim objApp As Excel.Application
    Dim objBook As Excel._Workbook
    Dim table As New DataTable
    Private m_CompanyCode As New Company
    Private m_SASDistrictTaget As New SASDistrictTaget
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
        OpenFileDialog1.Title = "SAS District Target"
        OpenFileDialog1.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtFileName.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnUploadinFormat_Click(sender As Object, e As EventArgs) Handles btnUploadinFormat.Click
        LoadGeneratingReport()
    End Sub
    Private Sub LoadGeneratingReport()
        ' Create Excel
        Dim xlApp As New Excel.Application
        Dim xlWorkbook As Excel.Workbook = xlApp.Workbooks.Add()
        Dim xlWorksheet As Excel.Worksheet = CType(xlWorkbook.Sheets(1), Excel.Worksheet)

        ' Sheet 1 - SAS Target
        xlWorksheet.Name = "SAS Target"
        xlWorksheet.Cells(1, 1) = "Configuration Code"
        xlWorksheet.Cells(1, 2) = "Year"
        xlWorksheet.Cells(1, 3) = "Month"
        xlWorksheet.Cells(1, 4) = "District Code"
        xlWorksheet.Cells(1, 5) = "Target Value"
        xlWorksheet.Range("A1:E1").Font.Bold = True
        xlWorksheet.Columns("A:E").AutoFit()

        ' Sheet 2 - District Details
        Dim sheet2 As Excel.Worksheet = CType(xlWorkbook.Sheets.Add(After:=xlWorkbook.Sheets(xlWorkbook.Sheets.Count)), Excel.Worksheet)
        sheet2.Name = "District Details"
        sheet2.Cells(1, 1) = "District Code"
        sheet2.Cells(1, 2) = "District Name"
        sheet2.Range("A1:B1").Font.Bold = True

        ' Get data and fill sheet2
        Dim table As DataTable = GetRecords(DistrictAssignment.GetDistrictAssignmentSql())
        Dim rowIndex As Integer = 2
        For i As Integer = 0 To table.Rows.Count - 1
            sheet2.Cells(rowIndex, 1) = table.Rows(i)("DistrictGroup").ToString()
            sheet2.Cells(rowIndex, 2) = table.Rows(i)("STDISTRCTNAME").ToString()
            rowIndex += 1
        Next
        sheet2.Columns("A:B").AutoFit()



        ' Optional: Open Excel to view
        xlWorkbook.Windows(1).Caption = "SAS Target"
        xlApp.Visible = True

        ' Clean up
        ReleaseObject(sheet2)
        ReleaseObject(xlWorksheet)
        ReleaseObject(xlWorkbook)
        ReleaseObject(xlApp)

        MessageBox.Show("Report saved successfully to Desktop as 'SAS Target.xlsx'")
    End Sub

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        End Try
        GC.Collect()
    End Sub

    Private Sub btnCanced_Click(sender As Object, e As EventArgs) Handles btnCanced.Click
        Me.Close()
    End Sub
    Private Sub btnStartProcess_Click(sender As Object, e As EventArgs) Handles btnStartProcess.Click
        Try
            If txtFileName.Text = "" And txtConfigtypeCode.Text = "" And DropYear.Text = "" Then
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
                        SASDistrictTaget.DeleteExistList(DropYear.Text, txtConfigtypeCode.Text)
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
        pbar.Visible = True
        For m As Integer = 0 To dt.Rows.Count - 1
            pbar.Value = ctr / dt.Rows.Count * 100
            Dim m_SASDistrictTaget As New SASDistrictTaget
            m_SASDistrictTaget = New SASDistrictTaget
            Dim dr As DataRow = dt.Rows(m)
            m_SASDistrictTaget.ConfigtypeCode = dr("Configuration Code")
            m_SASDistrictTaget.Year = dr("Year")
            m_SASDistrictTaget.Month = dr("Month")
            m_SASDistrictTaget.DistrictCode = dr("District Code")
            m_SASDistrictTaget.TagetValue = dr("Target Value")
            m_SASDistrictTaget.Createby = MainWindow.MainUserName
            m_SASDistrictTaget.Save()
            ctr += 1
        Next
        pbar.Visible = False
        UploadSuccess()
    End Sub

    Private Sub UISASDistrictTarget_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadYear()
    End Sub
End Class