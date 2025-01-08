Imports System.Data.OleDb
Imports System.Windows.Forms
Public Class SalesMatrix
    Private m_FileName As String = String.Empty
    Private m_Err As New ErrorProvider
    Private m_SalesMatrix As New SalesMatrixs
    Private _ExcelResult As New ExcelSalesMatrix
    Dim dt As New DataTable
    Dim table As DataTable

    Private Sub lnkClose_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkClose.LinkClicked
        Me.Dispose()
    End Sub
    Private Sub lnkStartUploading_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStartUploading.LinkClicked
        If ValidateData() Then
            If _ExcelResult.CheckIfExist(txtfile.Text) Then
                dt = _ExcelResult.GetExcelData(txtfile.Text)
                If dt.Rows.Count = 0 Then
                    MsgBox("No Record Found", MsgBoxStyle.Critical, "System")
                Else
                    StartUpload()
                End If
            End If
        End If
    End Sub
    Private Function ValidateData() As Boolean
        Dim m_HasError As Boolean = False
        m_Err.Clear()
        If cboCompanycode.Text = String.Empty Then
            m_Err.SetError(cboCompanycode, "CompanyCode is required.")
            m_HasError = True
        End If
        If txtfile.Text = String.Empty Then
            m_Err.SetError(txtfile, "Upload FileName is required.")
            m_HasError = True
        End If
        Return Not m_HasError
    End Function
    Private Sub StartUpload()
        Dim ctr As Integer = 0
        Dim Sdate As Date = dtStartDate.Value.ToShortDateString
        Dim Edate As Date = dtEndDate.Value.ToShortDateString
        If Not SalesMatrixs.CheckField(cboCompanycode.Text, Sdate, Edate) Then
            pbar.Visible = True
            For m As Integer = 0 To dt.Rows.Count - 1
                pbar.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                m_SalesMatrix = New SalesMatrixs
                m_SalesMatrix.DLFLG = 0
                m_SalesMatrix.ConfigTypeCode = cboCompanycode.Text
                If IsDBNull(dr("Region Code")) Then
                    m_SalesMatrix.SalesAreacode = "999"
                Else
                    m_SalesMatrix.SalesAreacode = dr("Region Code")
                End If
                If IsDBNull(dr("District Code")) Then
                    m_SalesMatrix.SalesDistrictCode = "999"
                Else
                    m_SalesMatrix.SalesDistrictCode = dr("District Code")
                End If
                If IsDBNull(dr("Team Code")) Then
                    m_SalesMatrix.SalesTeamCode = "999"
                Else
                    m_SalesMatrix.SalesTeamCode = dr("Team Code")
                End If

                m_SalesMatrix.SalesTerritoryDivision = dr("Item Division")

                If IsDBNull(dr("Territory Code")) Then
                    m_SalesMatrix.SalesTerritoryCodeas = "999"
                Else
                    m_SalesMatrix.SalesTerritoryCodeas = dr("Territory Code")
                End If
                'If IsDBNull(dr("STACOVCD")) Then
                '    m_SalesMatrix.SalesDivisionName = "999"
                'Else
                '    m_SalesMatrix.SalesDivisionCode = dr("STACOVCD")
                'End If
                m_SalesMatrix.SalesDivisionCode = ""
                '  m_SalesMatrix.SalesDivisionName = dr("Territory Name")
                If IsDBNull(dr("Salesman Code")) Then
                    m_SalesMatrix.SalesmanCode = "999"
                Else
                    m_SalesMatrix.SalesmanCode = dr("Salesman Code")
                End If
                m_SalesMatrix.SalesmanName = dr("Salesman Name")
                'm_SalesMatrix.UploadDate = dr("UPDD")
                'm_SalesMatrix.CreatDate = dr("CRTDATE")
                m_SalesMatrix.EffictivetyStart = dr("Effectivity Start Date")
                m_SalesMatrix.EffictivetyEndDate = dr("Effectivity End Date")
                If IsDBNull(dr("Item Group")) Then
                    m_SalesMatrix.ItemGroupProductCode = ""
                Else
                    m_SalesMatrix.ItemGroupProductCode = dr("Item Group")
                End If
                m_SalesMatrix.IsActive = dr("Is Active")
                m_SalesMatrix.Save()
                ctr += 1
            Next
        Else
            SalesMatrixs.DeletedField(cboCompanycode.Text, Sdate, Edate)
            pbar.Visible = True
            For m As Integer = 0 To dt.Rows.Count - 1
                pbar.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                m_SalesMatrix = New SalesMatrixs
                m_SalesMatrix.DLFLG = 0
                m_SalesMatrix.ConfigTypeCode = cboCompanycode.Text
                If IsDBNull(dr("Region Code")) Then
                    m_SalesMatrix.SalesAreacode = "999"
                Else
                    m_SalesMatrix.SalesAreacode = dr("Region Code")
                End If
                If IsDBNull(dr("District Code")) Then
                    m_SalesMatrix.SalesDistrictCode = "999"
                Else
                    m_SalesMatrix.SalesDistrictCode = dr("District Code")
                End If
                If IsDBNull(dr("Team Code")) Then
                    m_SalesMatrix.SalesTeamCode = "999"
                Else
                    m_SalesMatrix.SalesTeamCode = dr("Team Code")
                End If

                m_SalesMatrix.SalesTerritoryDivision = dr("Item Division")

                If IsDBNull(dr("Territory Code")) Then
                    m_SalesMatrix.SalesTerritoryCodeas = "999"
                Else
                    m_SalesMatrix.SalesTerritoryCodeas = dr("Territory Code")
                End If
                'If IsDBNull(dr("STACOVCD")) Then
                '    m_SalesMatrix.SalesDivisionName = "999"
                'Else
                '    m_SalesMatrix.SalesDivisionCode = dr("STACOVCD")
                'End If
                m_SalesMatrix.SalesDivisionCode = ""
                ' m_SalesMatrix.SalesDivisionName = dr("Territory Name")
                If IsDBNull(dr("Salesman Code")) Then
                    m_SalesMatrix.SalesmanCode = "999"
                Else
                    m_SalesMatrix.SalesmanCode = dr("Salesman Code")
                End If
                m_SalesMatrix.SalesmanName = dr("Salesman Name")
                'm_SalesMatrix.UploadDate = dr("UPDD")
                'm_SalesMatrix.CreatDate = dr("CRTDATE")
                m_SalesMatrix.EffictivetyStart = dr("Effectivity Start Date")
                m_SalesMatrix.EffictivetyEndDate = dr("Effectivity End Date")
                If IsDBNull(dr("Item Group")) Then
                    m_SalesMatrix.ItemGroupProductCode = ""
                Else
                    m_SalesMatrix.ItemGroupProductCode = dr("Item Group")
                End If
                m_SalesMatrix.IsActive = dr("Is Active")
                m_SalesMatrix.Save()
                ctr += 1
            Next
        End If
        pbar.Visible = False
        ShowInformation("Record Successfully Uploaded", "Expense Uploading")
    End Sub

    Private Sub SalesMatrix_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadData()
    End Sub
    Private Sub loadData()
        table = GetRecords("Select Configtypecode,ConfigTypeName from ConfigurationType")
        For i As Integer = 0 To table.Rows.Count - 1
            cboCompanycode.Items.Add(table.Rows(i)("Configtypecode"))
        Next

        _ExcelResult.ConfigTypeCode = cboCompanycode.Text
    End Sub

    Private Sub lblBrowseFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBrowseFile.Click
        OpenFile()
    End Sub
    Private Sub OpenFile()
        _ExcelResult.ConfigTypeCode = cboCompanycode.Text
        _ExcelResult.EffectivityStartDate = dtStartDate.Value.ToShortDateString
        _ExcelResult.EffectivityEndDate = dtEndDate.Value.ToShortDateString

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
End Class