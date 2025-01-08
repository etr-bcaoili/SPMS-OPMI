Public Class ItemListUploading
    Private m_OpenFolder As OpenFileDialog = New OpenFileDialog
    Dim table As New DataTable
    Dim dt As New DataTable

    Dim _ExcelResult As New ExceItempricelist
    Private m_ItemList As New ItempriceListUploading
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private Sub lblUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBrowseFile.Click

        'If sender Is lblBrowseFile Then
        '    BrowseFile()
        'ElseIf sender Is lblClose Then
        '    Me.Close()
        'ElseIf sender Is lblUpload Then
        '    UploadFile()
        'End If


    End Sub
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
            If txtfile.Text = "PRICELIST" Then
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
        If Not ItempriceListUploading.CheckIfItempriceListDataExist(cmbCompany.Text, startDate.Text, EndDate.Text) Then
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                m_ItemList = New ItempriceListUploading
                m_ItemList.COMID = cmbCompany.Text
                m_ItemList.ITEMCD = dr("ITEM CODE")
                If IsDBNull(dr("CHANNEL ITEM CODE")) Then
                    m_ItemList.DISTITEMCD = ""
                Else
                    m_ItemList.DISTITEMCD = dr("CHANNEL ITEM CODE")
                End If
                m_ItemList.ITEMNAME = dr("ITEM NAME")
                m_ItemList.DISTITEMPRICE = dr("CHANNEL ITEM PRICE")
                m_ItemList.CompanyPrice = dr("CHANNEL ITEM PRICE")
                m_ItemList.EffectivityStartDate = startDate.Text
                m_ItemList.EffectivityEndDate = EndDate.Text
                ctr += 1
                m_ItemList.Save()
            Next
        Else
            ItempriceListUploading.DeleteExistIfitempriceList(cmbCompany.Text, startDate.Text, EndDate.Text)
            For m As Integer = 0 To dt.Rows.Count - 1
                ProgressBar1.Value = ctr / dt.Rows.Count * 100
                Dim dr As DataRow = dt.Rows(m)
                m_ItemList = New ItempriceListUploading
                m_ItemList.COMID = cmbCompany.Text
                m_ItemList.ITEMCD = dr("ITEM CODE")
                If IsDBNull(dr("CHANNEL ITEM CODE")) Then
                    m_ItemList.DISTITEMCD = ""
                Else
                    m_ItemList.DISTITEMCD = dr("CHANNEL ITEM CODE")
                End If
                m_ItemList.ITEMNAME = dr("ITEM NAME")
                m_ItemList.DISTITEMPRICE = dr("CHANNEL ITEM PRICE")
                m_ItemList.CompanyPrice = dr("CHANNEL ITEM PRICE")
                m_ItemList.EffectivityStartDate = startDate.Text
                m_ItemList.EffectivityEndDate = EndDate.Text
                ctr += 1
                m_ItemList.Save()
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

    Private Sub cmbCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
      
    End Sub

    Private Sub ItemListUploading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateComboBox()
        Timer1.Enabled = False
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBrowseFile.Click, lblUpload.Click, lblClose.Click
        If sender Is lblBrowseFile Then
            BrowseFile()
        ElseIf sender Is lblClose Then
            Me.Close()
        ElseIf sender Is lblUpload Then
            UploadFile()
        End If
    End Sub
End Class
