Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class ucTargetUploading

    Private m_OpenFolder As OpenFileDialog = New OpenFileDialog
    Dim table As New DataTable
    Dim dt As New DataTable

    Dim _ExcelResult As New TargetSalesUploading
    Private m_rawData As New TargerSales
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Dim _ExcelResults As New ExcelUploading
    Dim m_compmoyr As New RebatesCompanyMonthYear
    Dim m_colleccompmoyr As New RebatesCompanyMonthYearCollection
    Dim m_RsYear As ADODB.Recordset
    Private Sub ucTargetUploading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillComboBox()
        loadConfigType()
    End Sub
    Private Sub loadConfigType()
        table = GetRecords("Select ConfigTypeCode,ConfigTypeName from ConfigurationType")
        For i As Integer = 0 To table.Rows.Count - 1
            cmbConfigtypeCode.Items.Add(table.Rows(i)("ConfigTypeCode"))
        Next
    End Sub
    Private Sub FillComboBox()
        m_colleccompmoyr = m_compmoyr.YearLoader
        For x As Integer = 0 To m_colleccompmoyr.Count - 1
            cboyear.Items.Add(m_colleccompmoyr.Item(x).Year)
        Next
        m_colleccompmoyr = m_compmoyr.MonthLoader
    End Sub


    Private Sub lblUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBrowseFile.Click, lblUpload.Click, lblClose.Click
        If sender Is lblBrowseFile Then
            BrowseFile()
        ElseIf sender Is lblClose Then
            Me.Close()
        ElseIf sender Is lblUpload Then
            UploadFile()
        End If
    End Sub
    Private Sub UploadFile()
        If txtfile.Text = "" Then
            MsgBox("No file to be uploaded", MsgBoxStyle.Information, "Please select file")
            Exit Sub
        End If
        ProgressBar1.Visible = True
        loadView()
    End Sub
    Private Sub BrowseFile()
        OpenFileDialog1.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*"
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
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Uploading()
        Dim ctr As Integer = 0
        Dim TotalQuantity As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim ProductDiscount As Decimal = 0
        Dim _Month As String = String.Empty
        For m As Integer = 0 To dt.Rows.Count - 1
            ProgressBar1.Value = ctr / dt.Rows.Count * 100
            Dim dr As DataRow = dt.Rows(m)
            m_rawData = New TargerSales
            If IsDBNull(dr("COMID")) Then
                MsgBox("Company Code is Required", MsgBoxStyle.Critical, "Please Entry Required")
                Exit Sub
            Else
                m_rawData.CompanyCode = dr("COMID")
            End If
            If IsDBNull(dr("TerritoryCode")) Then
                MsgBox("TerritoryCode is Required", MsgBoxStyle.Critical, "Please Entry Required")
                Exit Sub
            Else
                m_rawData.TerretoryCode = dr("TerritoryCode")
            End If
            If IsDBNull(dr("EmployeeID")) Then
                MsgBox("EmployeeID is Required", MsgBoxStyle.Critical, "Please Entry Required")
                Exit Sub
            Else
                m_rawData.EmployeeID = dr("EmployeeID")
            End If
            If IsDBNull(dr("EmployeeName")) Then
                MsgBox("Employee Name is Required", MsgBoxStyle.Critical, "Please Entry Required")
                Exit Sub
            Else
                m_rawData.EmployeeName = dr("EmployeeName")
            End If
            If IsDBNull(dr("ItemDivisionCode")) Then
                MsgBox("ItemDivisionCode is Required", MsgBoxStyle.Critical, "Please Entry Required")
                Exit Sub
            Else
                m_rawData.ItemCodeDivision = dr("ItemDivisionCode")
            End If
            If IsDBNull(dr("Item Code")) Then
                MsgBox("Item Code is Required", MsgBoxStyle.Critical, "Please Entry Required")
                Exit Sub
            Else
                m_rawData.ItemCode = dr("Item Code")
            End If
            If IsDBNull(dr("Item Name")) Then
                MsgBox("ItemName is Required", MsgBoxStyle.Critical, "Please Entry Required")
                Exit Sub
            Else
                m_rawData.ItemName = dr("Item Name")
            End If
            m_rawData.ConfigtypeCode = cmbConfigtypeCode.Text
            If IsDBNull(dr("Year")) Then
                MsgBox("Year is Required", MsgBoxStyle.Critical, "Please Entry Required")
                Exit Sub
            Else
                m_rawData.CutYear = dr("Year")
            End If
            If IsDBNull(dr("QT01")) Then
                m_rawData.QuantityTagetJanuary = "0"
            Else
                m_rawData.QuantityTagetJanuary = RefineSQL(dr("QT01"))
            End If
            If IsDBNull(dr("ST01")) Then
                m_rawData.SalesTargetJanuary = "0"
            Else
                m_rawData.SalesTargetJanuary = dr("ST01")
            End If
            If IsDBNull(dr("QT02")) Then
                m_rawData.QuantitytargetFebrary = "0"
            Else
                m_rawData.QuantitytargetFebrary = dr("QT02")
            End If
            If IsDBNull(dr("ST02")) Then
                m_rawData.SalesTargetFebrary = "0"
            Else
                m_rawData.SalesTargetFebrary = dr("ST02")
            End If
            If IsDBNull(dr("QT03")) Then
                m_rawData.QuantityTagetMarch = "0"
            Else
                m_rawData.QuantityTagetMarch = dr("QT03")
            End If
            If IsDBNull(dr("ST03")) Then
                m_rawData.SaleTagetMarch = "0"
            Else
                m_rawData.SaleTagetMarch = dr("ST03")
            End If
            If IsDBNull(dr("QT04")) Then
                m_rawData.QuantityTargetApril = "0"
            Else
                m_rawData.QuantityTargetApril = dr("QT04")
            End If
            If IsDBNull(dr("ST04")) Then
                m_rawData.SaleTargerApril = "0"
            Else
                m_rawData.SaleTargerApril = dr("ST04")
            End If
            If IsDBNull(dr("QT05")) Then
                m_rawData.QuantityTargetMay = "0"
            Else
                m_rawData.QuantityTargetMay = dr("QT05")
            End If
            If IsDBNull(dr("ST05")) Then
                m_rawData.SaleTargetMay = "0"
            Else
                m_rawData.SaleTargetMay = dr("ST05")
            End If
            If IsDBNull(dr("QT06")) Then
                m_rawData.QuantityTargerJune = "0"
            Else
                m_rawData.QuantityTargerJune = dr("QT06")
            End If
            If IsDBNull(dr("ST06")) Then
                m_rawData.SaleTargetJune = "0"
            Else
                m_rawData.SaleTargetJune = dr("ST06")
            End If

            If IsDBNull(dr("ST07")) Then
                m_rawData.SalesTargetJuly = "0"
            Else
                m_rawData.SalesTargetJuly = dr("ST07")
            End If

            If IsDBNull(dr("QT07")) Then
                m_rawData.QuantityTargetJuly = "0"
            Else
                m_rawData.QuantityTargetJuly = dr("QT07")
            End If
            If IsDBNull(dr("ST08")) Then
                m_rawData.SaleTargetAugust = "0"
            Else
                m_rawData.SaleTargetAugust = dr("ST08")
            End If
            If IsDBNull(dr("QT08")) Then
                m_rawData.QuantityTargetAugust = "0"
            Else
                m_rawData.QuantityTargetAugust = dr("QT08")
            End If
            If IsDBNull(dr("ST09")) Then
                m_rawData.SaleTargetSeptember = "0"
            Else
                m_rawData.SaleTargetSeptember = dr("ST09")
            End If
            If IsDBNull(dr("QT09")) Then
                m_rawData.QuantityTargetSeptember = "0"
            Else
                m_rawData.QuantityTargetSeptember = dr("QT09")
            End If
            If IsDBNull(dr("QT10")) Then
                m_rawData.QuantityTargetOctober = "0"
            Else
                m_rawData.QuantityTargetOctober = dr("QT10")
            End If
            If IsDBNull(dr("ST10")) Then
                m_rawData.SaleTargetOctober = "0"
            Else
                m_rawData.SaleTargetOctober = dr("ST10")
            End If
            If IsDBNull(dr("QT11")) Then
                m_rawData.QuantityTargetNovember = "0"
            Else
                m_rawData.QuantityTargetNovember = dr("QT11")
            End If
            If IsDBNull(dr("ST11")) Then
                m_rawData.SalesTargetNovember = "0"
            Else
                m_rawData.SalesTargetNovember = dr("ST11")
            End If

            If IsDBNull(dr("QT12")) Then
                m_rawData.QuantityTargetDecember = "0"
            Else
                m_rawData.QuantityTargetDecember = dr("QT12")
            End If
            If IsDBNull(dr("ST12")) Then
                m_rawData.Salestragetdecember = "0"
            Else
                m_rawData.Salestragetdecember = dr("ST12")
            End If

            ctr += 1
            m_rawData.Save()
        Next

        SPMSConn.Execute("Exec usProcessuploading")
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")


        Me.Close()

    End Sub
    Private Sub LoadYear(ByVal DistributorCode As String)
        table = GetRecords("SELECT Distinct CAYR  FROM Calendar WHERE COMID = '" & DistributorCode & "' ")
        For i As Integer = 0 To table.Rows.Count - 1
            cboyear.Items.Add(table.Rows(i)("CAYR"))
        Next
        _ExcelResults.Year = cboyear.Text

    End Sub

    'Private Sub LoadMonth(ByVal DistributorCode As String, ByVal Year As String)

    '    table = GetRecords("SELECT * FROM Calendar WHERE COMID = '" & DistributorCode & "' AND CAYR = '" & Year & "' ")
    '    For I As Integer = 0 To table.Rows.Count - 1
    '        cbomonth.Items.Add(table.Rows(I)("CAPN"))
    '    Next
    '    _ExcelResults.Month = cbomonth.Text
    'End Sub
    Public Function UploadingSaleTarget() As Boolean


    End Function


    Private Sub lblBrowseFile_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblBrowseFile.LinkClicked

    End Sub

    Private Sub cboyear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboyear.SelectedIndexChanged
        Dim selecteditem As String = cboyear.Items(cboyear.SelectedIndex)
        cboyear.Text = selecteditem
        vALIDT()
    End Sub

    Private Sub vALIDT()

        m_RsYear = New ADODB.Recordset
        Dim q As MsgBoxResult
        m_RsYear.Open("select * from TerritoryItemTarget   where Year = '" & cboyear.Text & "' and Configtypecode = '" & cmbConfigtypeCode.Text & "'", ConnectionModule.SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsYear.EOF = False Then
            q = VDialog.Show("File upload is already exist Do want to Continue?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If q = MsgBoxResult.Yes Then
                Delete()
            End If
        Else

        End If

    End Sub
    Private Sub delete()
        m_RsYear = New ADODB.Recordset
        m_RsYear.Open("Delete from TerritoryItemTarget  where Year = '" & cboyear.Text & "' and Configtypecode = '" & cmbConfigtypeCode.Text & "'", ConnectionModule.SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
    End Sub

    'Private Sub cbomonth2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim selecteditem As String = cbomonth2.Items(cbomonth2.SelectedIndex)

    '    cbomonth2.Text = selecteditem
    'End Sub
    Private Sub cmbConfigtypeCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbConfigtypeCode.SelectedIndexChanged
        table = GetRecords("Select ConfigTypeName from ConfigurationType where ConfigtypeCode = '" & cmbConfigtypeCode.Text & "'")
        For i As Integer = 0 To table.Rows.Count - 1
            txtconfigtypeName.Text = table.Rows(i)("ConfigTypeName")
        Next
    End Sub

    Private Sub cmbConfigtypeCode_Click(sender As Object, e As EventArgs) Handles cmbConfigtypeCode.Click

    End Sub
End Class