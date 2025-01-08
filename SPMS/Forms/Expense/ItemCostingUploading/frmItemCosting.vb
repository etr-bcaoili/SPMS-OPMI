Public Class frmItemCosting
    Private m_OpenFolder As OpenFileDialog = New OpenFileDialog
    Dim table As New DataTable
    Dim dt As New DataTable

    Dim _ExcelResult As New ExcelItemCostingUpload
    Private m_ItemCost As New ItemCost
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False

    Private Sub BrowseFile()

        _ExcelResult.CompanyCode = cmbCompany.Text
        OpenFileDialog1.Title = "Item Price"
        OpenFileDialog1.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtfile.Text = OpenFileDialog1.FileName
        End If

    End Sub
    Private Sub UploadFile()

        Try

            If txtfile.Text = "Item Cost" Then

                MsgBox("No file to be uploaded", MsgBoxStyle.Information, "Please select file")
                Exit Sub
            End If
            ProgressBar1.Visible = True

            loadView()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Uploading()
        Dim ctr As Integer = 0
        Dim TotalQuantity As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim ProductDiscount As Decimal = 0
        Dim _Month As String = String.Empty
        Dim q As MsgBoxResult


        If Not ItemCost.CheckIfItemcostDataExist(cmbCompany.Text, cmbmonth.Text, cmbyear.Text) Then

            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                m_ItemCost = New ItemCost

                m_ItemCost.ItemcostCompanyCode = dr("CHANNEL CODE")
                m_ItemCost.Month = dr("Month")
                m_ItemCost.Year = dr("Year")
                m_ItemCost.ItemCostTC = dr("Item Code")
                m_ItemCost.ChannelCodeItemCode = dr("Channel Item Code")
                m_ItemCost.ItemcostDescription = dr("Item Description")
                m_ItemCost.ItemCostprice = dr("Item Cost")

                ctr += 1
                m_ItemCost.Save()
            Next

        Else

            ItemCost.DeleteExistIFItemcost(cmbCompany.Text, cmbmonth.Text, cmbyear.Text)

            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                m_ItemCost = New ItemCost

                m_ItemCost.ItemcostCompanyCode = dr("CHANNEL CODE")
                m_ItemCost.Month = dr("Month")
                m_ItemCost.Year = dr("Year")
                m_ItemCost.ItemCostTC = dr("Item Code")
                m_ItemCost.ChannelCodeItemCode = dr("Channel Item Code")
                m_ItemCost.ItemcostDescription = dr("Item Description")
                m_ItemCost.ItemCostprice = dr("Item Cost")


                ctr += 1
                m_ItemCost.Save()
            Next

        End If
        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()

    End Sub

  

    Private Sub PopulateComboBox()

        table = GetRecords("SELECT * FROM DISTRIBUTOR WHERE DLTFLG = 0")
        For I As Integer = 0 To table.Rows.Count - 1
            cmbCompany.Items.Add(table.Rows(I)("DISTCOMID"))
        Next

    End Sub
   
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, lblBrowseFile.Click, Button2.Click
        If sender Is lblBrowseFile Then
            BrowseFile()
        ElseIf sender Is Button2 Then
            Me.Close()
        ElseIf sender Is Button1 Then
            UploadFile()
        End If
        _ExcelResult.Month = cmbmonth.Text
        _ExcelResult.Year = cmbyear.Text
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

    Private Sub frmItemCosting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateComboBox()
        Timer1.Enabled = False
        _ExcelResult.Month = cmbmonth.Text
        _ExcelResult.Year = cmbyear.Text
    End Sub

 

    Private Sub cmbmonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbmonth.SelectedIndexChanged
        lblBrowseFile.Enabled = True
    End Sub

    Private Sub cmbCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        If cmbCompany.SelectedIndex = -1 Then Exit Sub
        LoadYear(cmbCompany.Text)
    End Sub

    Private Sub cmbyear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbyear.SelectedIndexChanged
        If cmbyear.SelectedIndex = -1 Then Exit Sub
        LoadMonth(cmbCompany.Text, cmbyear.Text)
    End Sub
End Class