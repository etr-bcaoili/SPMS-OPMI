Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing
Imports System.Text
Imports Telerik.WinControls.UI
Imports System.Windows.Forms
Imports Telerik.WinControls
Public Class UISalesMatrix
    Private m_FileName As String = String.Empty
    Private m_Err As New ErrorProvider
    Private m_SalesMatrix As New SalesMatrixs
    Dim _ExcelResult As New ExcelSalesMatrix
    Dim dt As New DataTable
    Dim table As DataTable
    Private Function ValidateData() As Boolean
        Dim m_HasError As Boolean = False
        m_Err.Clear()
        If cboCompanycode.Text = String.Empty Then
            m_Err.SetError(cboCompanycode, "Configtype Code is required.")
            m_HasError = True
        End If
        If txtfileName.Text = String.Empty Then
            m_Err.SetError(txtfileName, "Upload FileName is required.")
            m_HasError = True
        End If
        If txtSheetName.Text = String.Empty Then
            m_Err.SetError(txtSheetName, "Sheet Name is required.")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
    Private Sub loadData()
        table = GetRecords("Select Configtypecode,ConfigTypeName from ConfigurationType")
        For i As Integer = 0 To table.Rows.Count - 1
            cboCompanycode.Items.Add(table.Rows(i)("Configtypecode"))
        Next
    End Sub
    Private Sub LoadConfigtypeName(ByVal ConfigtypeCode As String)
        table = GetRecords("Select Configtypecode,ConfigTypeName from ConfigurationType Where Configtypecode = '" & ConfigtypeCode & "'")
        For i As Integer = 0 To table.Rows.Count - 1
            txtConfigurationName.Text = table.Rows(i)("ConfigTypeName")
            Exit Sub
        Next
    End Sub

    Private Sub UISalesMatrix_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadData()
    End Sub

    Private Sub cboCompanycode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCompanycode.SelectedIndexChanged
        LoadConfigtypeName(cboCompanycode.Text)
    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        OpenFile()
    End Sub
    Private Sub OpenFile()
        _ExcelResult.ConfigTypeCode = cboCompanycode.Text
        _ExcelResult.EffectivityStartDate = dtStartDate.Value.ToShortDateString
        _ExcelResult.EffectivityEndDate = dtEndDate.Value.ToShortDateString
        _ExcelResult.SheetName = txtSheetName.Text
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Microsoft Office Excel(*.xls)|*.xls;*.xlsx"
        If (ofd.ShowDialog() = DialogResult.OK) Then
            If ofd.FileName.Length > 255 Then
                ShowExclamation("Path Too Long.", "Uploading")
                Exit Sub
            End If
            txtfileName.Text = ofd.FileName
        End If
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        If txtSheetName.Text = String.Empty Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "SheetName Input First", "Uploaded Error", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        Else
            If _ExcelResult.CheckIfExist(txtfileName.Text) Then
                dt = _ExcelResult.GetExcelData(txtfileName.Text)
                If dt.Rows.Count = 0 Then
                    MsgBox("No Record Found", MsgBoxStyle.Critical, "System")
                Else
                    StartUpload()
                End If
            End If
        End If
    End Sub
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
                If IsDBNull(dr("Item Division")) Then
                    m_SalesMatrix.SalesTerritoryDivision = "999"
                Else
                    m_SalesMatrix.SalesTerritoryDivision = dr("Item Division")
                End If

                If IsDBNull(dr("Territory Code")) Then
                    m_SalesMatrix.SalesTerritoryCodeas = "999"
                Else
                    m_SalesMatrix.SalesTerritoryCodeas = dr("Territory Code")
                End If

                If IsDBNull(dr("Territory Name")) Then
                    m_SalesMatrix.SalesTerritoryName = "DEFAULT AREA COVERAGE"
                Else
                    m_SalesMatrix.SalesTerritoryName = dr("Territory Name")
                End If

                If IsDBNull(dr("Salesman Code")) Then
                    m_SalesMatrix.SalesmanCode = "999"
                Else
                    m_SalesMatrix.SalesmanCode = dr("Salesman Code")
                End If
                If IsDBNull(dr("Salesman Name")) Then
                    m_SalesMatrix.SalesmanName = dr("Salesman Name")
                Else
                    m_SalesMatrix.SalesmanName = dr("Salesman Name")
                End If
                m_SalesMatrix.EffictivetyStart = dr("Effectivity Start Date")
                m_SalesMatrix.EffictivetyEndDate = dr("Effectivity End Date")
                If IsDBNull(dr("Item Group")) Then
                    m_SalesMatrix.ItemGroupProductCode = ""
                Else
                    m_SalesMatrix.ItemGroupProductCode = dr("Item Group")
                End If
                m_SalesMatrix.IsActive = dr("Is Active")
                m_SalesMatrix.ConfigTypeCode = cboCompanycode.Text
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
                If IsDBNull(dr("Item Division")) Then
                    m_SalesMatrix.SalesTerritoryDivision = "999"
                Else
                    m_SalesMatrix.SalesTerritoryDivision = dr("Item Division")
                End If

                If IsDBNull(dr("Territory Code")) Then
                    m_SalesMatrix.SalesTerritoryCodeas = "999"
                Else
                    m_SalesMatrix.SalesTerritoryCodeas = dr("Territory Code")
                End If

                If IsDBNull(dr("Territory Name")) Then
                    m_SalesMatrix.SalesTerritoryName = "DEFAULT AREA COVERAGE"
                Else
                    m_SalesMatrix.SalesTerritoryName = dr("Territory Name")
                End If

                If IsDBNull(dr("Salesman Code")) Then
                    m_SalesMatrix.SalesmanCode = "999"
                Else
                    m_SalesMatrix.SalesmanCode = dr("Salesman Code")
                End If
                If IsDBNull(dr("Salesman Name")) Then
                    m_SalesMatrix.SalesmanName = "DEFAULT TM REP."
                Else
                    m_SalesMatrix.SalesmanName = dr("Salesman Name")
                End If
                m_SalesMatrix.EffictivetyStart = dr("Effectivity Start Date")
                m_SalesMatrix.EffictivetyEndDate = dr("Effectivity End Date")
                If IsDBNull(dr("Item Group")) Then
                    m_SalesMatrix.ItemGroupProductCode = ""
                Else
                    m_SalesMatrix.ItemGroupProductCode = dr("Item Group")
                End If
                m_SalesMatrix.IsActive = dr("Is Active")
                m_SalesMatrix.ConfigTypeCode = cboCompanycode.Text
                m_SalesMatrix.Save()
                ctr += 1
            Next
        End If
        pbar.Visible = False
        ShowInformation("Record Successfully Uploaded", "Expense Uploading")
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Me.Dispose()
    End Sub
End Class