Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Imports System.Data.OleDb
Imports ADODB
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Windows
Public Class UISharingUploading
    Dim Table As New DataTable
    Private m_sharing As New SharingCompany
    Private m_Configtype As New Configuration
    Dim m_HasError As Boolean = False
    Private m_Err As New ErrorProvider
    Private m_CompanyCodes As New Sharing
    Private m_Months As New Sharing
    Private m_Years As New Sharing
    Dim dt As New DataTable

    Dim objExcel As Excel.Application
    Dim rec_count
    Dim _ExcelResult As New ExcelSharing

    Private m_ConfigtypeCode As String = String.Empty
    Private m_Distributor As New Distributor
    Private m_DistributorCode As String = String.Empty


    Private Sub Clear()
        txtConfig.Text = String.Empty
        txtDistributor.Text = String.Empty
        txtFilename.Text = String.Empty
    End Sub
    Private Sub lnkMotherCode_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkMotherCode.LinkClicked
        Clear()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Configuration")
        If Not tag Is Nothing Then
            LoadConfigType(tag.KeyColumn22)
        End If
    End Sub
    Private Sub LoadConfigType(ByVal ConfigtypeCode As String)
        m_Configtype = Configuration.LoadbyCode(ConfigtypeCode)
        txtConfig.Text = m_Configtype.ConfigTypeName
        m_ConfigtypeCode = m_Configtype.ConfigTypeCode
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Distributor.GetDistributorSql, "Search Item")
        If Not tag Is Nothing Then
            LoadChannel(tag.KeyColumn22)
        End If
    End Sub
    Private Sub LoadChannel(ByVal ChannelCode As String)
        m_Distributor = Distributor.LoadByCode(ChannelCode)
        m_DistributorCode = m_Distributor.DISTCOMID
        txtDistributor.Text = m_Distributor.DISTNAME
    End Sub

    Private Sub UISharingUploading_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadYear()
    End Sub
    Private Sub LoadYear()
        Table = GetRecords(Configuration.GetYearbyConfig)
        For i As Integer = 0 To Table.Rows.Count - 1
            cboYear.Items.Add(Table.Rows(i)("CAYR"))
        Next
    End Sub

    Private Sub cboYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboYear.SelectedIndexChanged
        If cboYear.SelectedIndex = -1 Then Exit Sub
        LoadMonth(m_DistributorCode, cboYear.Text)
    End Sub

    Private Sub LoadMonth(ByVal DistributorCode As String, ByVal Year As String)
        cboMonth.Items.Clear()
        Table = GetRecords(Configuration.GetMonthConfigtype(DistributorCode, Year))
        For i As Integer = 0 To Table.Rows.Count - 1
            cboMonth.Items.Add(Table.Rows(i)("CAPN"))
        Next
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click, btnClear.Click, LinkLabel2.Click
        If sender Is LinkLabel2 Then
            BrowseFile()
        ElseIf sender Is btnClear Then
            Me.Close()
        ElseIf sender Is btnFind Then
            UploadFile()
        End If
    End Sub
    Private Sub BrowseFile()
        _ExcelResult.CompanyCode = m_DistributorCode
        OpenFileDialog1.Title = "Item Price"
        OpenFileDialog1.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtFileName.Text = OpenFileDialog1.FileName
        End If
    End Sub
    Private Sub UploadFile()
        Try
            If txtFileName.Text = "" Then
                MsgBox("No file to be uploaded", MsgBoxStyle.Information, "Please select file")
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
        If Not SharingCompany.CheckIfItempriceListDataExist(m_DistributorCode, cboYear.Text, cboMonth.Text, m_ConfigtypeCode) Then
            pbar.Visible = True
            For m As Integer = 0 To dt.Rows.Count - 1
                pbar.Value = ctr / dt.Rows.Count * 100
                Dim m_Sharing As New SharingCompany
                m_Sharing = New SharingCompany
                Dim dr As DataRow = dt.Rows(m)
                If IsDBNull(dr("Year")) Then
                    MsgBox("Year is  Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.CUTYEAR = dr("YEAR")
                End If
                If IsDBNull(dr("Month")) Then
                    MsgBox("Month is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.CUTMO = dr("Month")
                End If
                If IsDBNull(dr("Company")) Then
                    MsgBox("Company is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.COMID = dr("Company")
                End If

                If IsDBNull(dr("Customer Code")) Then
                    MsgBox("Customer Code is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.CUSCD = dr("Customer Code")
                End If

                If IsDBNull(dr("Customer Name")) Then
                    MsgBox("Customer Name is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.CUSNAM = dr("Customer Name")
                End If
                If IsDBNull(dr("Ship to Code")) Then
                    MsgBox("Customer Ship to Code is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.CDACD = dr("Ship to Code")
                End If
                If IsDBNull(dr("Ship to Name")) Then
                    MsgBox("Customer ship to Name  is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.CDANAME = dr("Ship to Name")
                End If

                If IsDBNull(dr("Territory Code")) Then
                    MsgBox("Territory Code is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.TERRCD = dr("Territory Code")
                End If

                If IsDBNull(dr("Salesman Code")) Then
                    MsgBox("Salesman Code is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.STSLSMNCD = dr("Salesman Code")
                End If

                If IsDBNull(dr("Salesman Name")) Then
                    MsgBox("Salesman Name is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.STSLSMNNAME = dr("Salesman Name")
                End If

                If IsDBNull(dr("Item Division")) Then
                    MsgBox("Item Division is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.ITEMDIVCD = dr("Item Division")
                End If

                If IsDBNull(dr("Per Share")) Then
                    MsgBox("Per Share is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.PERSHR = dr("Per Share")
                End If

                If IsDBNull(dr("Status")) Then
                    MsgBox("Status is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.DELFLAG = dr("Status")
                End If

                If IsDBNull(dr("Active")) Then
                    MsgBox("Active is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.IsActive = dr("Active")
                End If

                If IsDBNull(dr("ConfigTypecode")) Then
                    MsgBox("ConfigtypeCode is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.ConfigTypeCode = dr("ConfigTypeCode")
                End If

                m_Sharing.Save()
                ctr += 1
            Next
            pbar.Visible = False
            UploadSuccess()
        Else
            SharingCompany.DeleteExistIfitempriceList(m_DistributorCode, cboYear.Text, cboMonth.Text, m_ConfigtypeCode)
            pbar.Visible = True
            For m As Integer = 0 To dt.Rows.Count - 1
                pbar.Value = ctr / dt.Rows.Count * 100
                Dim m_Sharing As New SharingCompany

                m_Sharing = New SharingCompany
                Dim dr As DataRow = dt.Rows(m)
                If IsDBNull(dr("Year")) Then
                    MsgBox("Year is  Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.CUTYEAR = dr("YEAR")
                End If

                If IsDBNull(dr("Month")) Then
                    MsgBox("Month is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.CUTMO = dr("Month")
                End If
                If IsDBNull(dr("Company")) Then
                    MsgBox("Company is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.COMID = dr("Company")
                End If

                If IsDBNull(dr("Customer Code")) Then
                    MsgBox("Customer Code is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.CUSCD = dr("Customer Code")
                End If

                If IsDBNull(dr("Customer Name")) Then
                    MsgBox("Customer Name is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.CUSNAM = dr("Customer Name")
                End If
                If IsDBNull(dr("Ship to Code")) Then
                    MsgBox("Customer Ship to Code is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.CDACD = dr("Ship to Code")
                End If
                If IsDBNull(dr("Ship to Name")) Then
                    MsgBox("Customer ship to Name  is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.CDANAME = dr("Ship to Name")
                End If

                If IsDBNull(dr("Territory Code")) Then
                    MsgBox("Territory Code is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.TERRCD = dr("Territory Code")
                End If

                If IsDBNull(dr("Salesman Code")) Then
                    MsgBox("Salesman Code is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.STSLSMNCD = dr("Salesman Code")
                End If

                If IsDBNull(dr("Salesman Name")) Then
                    MsgBox("Salesman Name is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.STSLSMNNAME = dr("Salesman Name")
                End If

                If IsDBNull(dr("Item Division")) Then
                    MsgBox("Item Division is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.ITEMDIVCD = dr("Item Division")
                End If

                If IsDBNull(dr("Per Share")) Then
                    MsgBox("Per Share is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.PERSHR = dr("Per Share")
                End If

                If IsDBNull(dr("Status")) Then
                    MsgBox("Status is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.DELFLAG = dr("Status")
                End If

                If IsDBNull(dr("Active")) Then
                    MsgBox("Active is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.IsActive = dr("Active")
                End If

                If IsDBNull(dr("ConfigTypeCode")) Then
                    MsgBox("ConfigTypeCode is Required", MsgBoxStyle.Exclamation, "Please Entry")
                    Exit Sub
                Else
                    m_Sharing.ConfigTypeCode = dr("ConfigTypeCode")
                End If

                m_Sharing.Save()
                ctr += 1
            Next
            pbar.Visible = False
            UploadSuccess()
        End If
    End Sub
    Private Sub cboMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMonth.SelectedIndexChanged

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked

    End Sub
End Class