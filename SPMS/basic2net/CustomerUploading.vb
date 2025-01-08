Public Class CustomerUploading

    Private m_OpenFolder As OpenFileDialog = New OpenFileDialog
    Dim table As New DataTable
    Dim dt As New DataTable

    Dim _ExcelResult As New CustomerExcelUploading
    Private m_Customer As New Customer
    Private m_CustShipTo = New CustomerShipTo
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False

    Private Sub lblUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBrowseFile.Click, lblUpload.Click, lblClose.Click

        If sender Is lblBrowseFile Then
            BrowseFile()
        ElseIf sender Is lblClose Then
            Me.Close()
        ElseIf sender Is lblUpload Then
            If ValidateData() Then
                UploadFile()
            End If
        End If

    End Sub


    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False
        If cmbCompany.Text = String.Empty Or cmbCompany.Text Is Nothing Then
            m_Err.SetError(cmbCompany, "Channel is required")
            m_HasError = True
        End If


        Return Not m_HasError
    End Function
    Private Sub PopulateComboBox()

        table = GetRecords("SELECT * FROM DISTRIBUTOR WHERE DLTFLG = 0")
        For I As Integer = 0 To table.Rows.Count - 1
            cmbCompany.Items.Add(table.Rows(I)("DISTCOMID"))
        Next
    End Sub
    Private Sub UploadFile()

        ' Try

        If txtfile.Text = "" Then

            MsgBox("No file to be uploaded", MsgBoxStyle.Information, "Please select file")
            Exit Sub
        End If
        ProgressBar1.Visible = True

        loadView()


        ' Catch ex As Exception
        'MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub BrowseFile()

        _ExcelResult.CompanyCode = cmbCompany.Text
        OpenFileDialog1.Title = "ALDC CUSTOMER"
        If cmbFiletype.Text = ".XLS" Then
            OpenFileDialog1.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*"
        Else
            OpenFileDialog1.Filter = "Text files(*.txt)|*.txt"
        End If
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtfile.Text = OpenFileDialog1.FileName
        End If

    End Sub


    Private Sub loadView()
        ' Try

        If _ExcelResult.CheckIfExist(txtfile.Text) Then
            dt = _ExcelResult.GetExcelData(txtfile.Text)
            If dt.Rows.Count = 0 Then
                MsgBox("No Record Upload!!!")
            Else
                Uploading()
            End If
        End If
        '  Catch ex As Exception
        'MsgBox(ex.Message)
        ' End Try
    End Sub


    Private Sub Uploading()

        Dim ctr As Integer = 0

       
        For m As Integer = 0 To dt.Rows.Count - 1
            ProgressBar1.Value = ctr / dt.Rows.Count * 100
            Dim dr As DataRow = dt.Rows(m)
            'If Not dr("CHANNEL") = cmbCompany.Text Then Exit Sub
            'm_Customer = New Customer
            'm_CustShipTo = New CustomerShipTo
            'If IsDBNull(dr("CHANNEL")) Then
            '    m_Customer.COMID = ""
            '    m_CustShipTo.COMID = ""
            'Else
            '    m_Customer.COMID = dr("CHANNEL")
            '    m_CustShipTo.COMID = dr("CHANNEL")
            'End If
            'If IsDBNull(dr("CUSTOMERCODE")) Then
            '    m_Customer.CUSTOMERCD = ""
            '    m_CustShipTo.CustoomerCd = ""
            'Else
            '    m_Customer.CUSTOMERCD = dr("CUSTOMERCODE")
            '    m_CustShipTo.Customercd = dr("CustomerCode")
            'End If

            'If IsDBNull(dr("CUSTOMERNAME")) Then
            '    m_Customer.CUSTOMERNAME = ""
            '    m_CustShipTo.CustomerName = ""
            'Else
            '    m_Customer.CUSTOMERNAME = dr("CUSTOMERNAME")
            '    m_CustShipTo.CustomerName = dr("CustomerName")
            'End If
            'If IsDBNull(dr("SHIPTONAME")) Then
            '    m_CustShipTo.CDaName = ""
            'Else
            '    m_CustShipTo.CDANAME = dr("SHIPTONAME")
            'End If
            'If IsDBNull(dr("SHIPTOCODE")) Then
            '    m_CustShipTo.CDACD = ""
            'Else
            '    m_CustShipTo.CDACD = dr("SHIPTOCODE")
            'End If
            'If IsDBNull(dr("ADDRESS1")) Then
            '    m_Customer.CADD1 = dr("ADDRESS1")
            'Else
            '    m_CustShipTo.CDACADD1 = dr("ADDRESS1")
            'End If
            'If IsDBNull(dr("ADDRESS2")) Then
            '    m_Customer.CADD2 = ""
            'Else
            '    m_Customer.CADD2 = dr("ADDRESS2")
            'End If

            'If IsDBNull(dr("ZIPCODE")) Then
            '    m_Customer.ZIPCD = ""
            'Else
            '    m_Customer.ZIPCD = dr("ZIPCODE")
            'End If

            'If IsDBNull(dr("REGIONCODE")) Then
            '    m_Customer.REGCD = ""
            'Else
            '    m_Customer.REGCD = dr("REGIONCODE")
            'End If
            'If IsDBNull(dr("REGIONCODE")) Then
            '    m_Customer.REGCD = ""
            'Else
            '    m_CustShipTo.REGCD = dr("REGIONCODE")
            'End If
            'If IsDBNull(dr("PROVINCECODE")) Then
            '    m_Customer.DISTCD = ""
            'Else
            '    m_Customer.DISTCD = dr("PROVINCECODE")
            'End If
            'If IsDBNull(dr("PROVINCECODE")) Then
            '    m_CustShipTo.DISTCD = ""
            'Else
            '    m_CustShipTo.DISTCD = dr("PROVINCECODE")
            'End If
            'If IsDBNull(dr("MUNICIPALITYCODE")) Then
            '    m_Customer.AREACD = ""
            'Else
            '    m_Customer.AREACD = dr("MUNICIPALITYCODE")
            'End If
            'If IsDBNull(dr("MUNICIPALITYCODE")) Then
            '    m_CustShipTo.Areacd = ""
            'Else
            '    m_CustShipTo.AREACD = dr("MUNICIPALITYCODE")
            'End If
            'If IsDBNull(dr("CUSTOMERGROUP")) Then
            '    m_Customer.CMGRP = ""
            'Else
            '    m_Customer.CMGRP = dr("CUSTOMERGROUP")
            'End If
            'If IsDBNull(dr("CUSTOMERGROUP")) Then
            '    m_CustShipTo.CMGRP = ""
            'Else
            '    m_CustShipTo.CMGRP = dr("CUSTOMERGROUP")
            'End If
            'If IsDBNull(dr("CUSTOMERCLASS")) Then
            '    m_Customer.CMCLASS = ""
            'Else
            '    m_Customer.CMCLASS = dr("CUSTOMERCLASS")
            'End If
            'If IsDBNull(dr("CUSTOMERCLASS")) Then
            '    m_CustShipTo.CMCLASS = ""
            'Else
            '    m_CustShipTo.CMCLASS = dr("CUSTOMERCLASS")
            'End If
            'If IsDBNull(dr("ACCOUNT SHARED")) Then
            '    m_Customer.ACCNTSHRD = ""
            'Else
            '    m_Customer.ACCNTSHRD = dr("ACCOUNT SHARED")
            'End If

            'If IsDBNull(dr("ACCOUNT SHARED")) Then
            '    m_CustShipTo.ACCNTSHRD = ""
            'Else
            '    m_CustShipTo.ACCNTSHRD = dr("ACCOUNT SHARED")
            'End If

            If Not dr("CHANNEL") = cmbCompany.Text Then Exit Sub
            m_Customer = New Customer
            m_CustShipTo = New CustomerShipTo
            m_Customer.COMID = dr("CHANNEL")
            m_CustShipTo.COMID = dr("CHANNEL")
            m_Customer.CUSTOMERCD = dr("CUSTOMERCODE")
            m_CustShipTo.CUSTOMERCD = dr("CUSTOMERCODE")
            m_Customer.CUSTOMERNAME = dr("CUSTOMERNAME")
            m_CustShipTo.CDANAME = dr("SHIPTONAME")
            m_CustShipTo.CDACD = dr("SHIPTOCODE")
            If IsDBNull(dr("ADDRESS1")) Then
                m_Customer.CADD1 = ""
            Else
                m_Customer.CADD1 = dr("ADDRESS1")
            End If
            If IsDBNull(dr("ADDRESS1")) Then
                m_CustShipTo.CDACADD1 = ""
            Else
                m_CustShipTo.CDACADD1 = dr("ADDRESS1")
            End If
            If IsDBNull(dr("ADDRESS2")) Then
                m_Customer.CADD2 = ""
            Else
                m_Customer.CADD2 = dr("ADDRESS2")
            End If
            If IsDBNull(dr("ADDRESS2")) Then
                m_CustShipTo.CDACADD2 = ""
            Else
                m_CustShipTo.CDACADD2 = dr("ADDRESS2")
            End If
            m_Customer.ZIPCD = dr("ZIPCODE")
            m_CustShipTo.ZIPCD = dr("ZIPCODE")
            m_Customer.REGCD = dr("REGIONCODE")
            m_CustShipTo.REGCD = dr("REGIONCODE")
            m_Customer.DISTCD = dr("PROVINCECODE")
            m_CustShipTo.DISTCD = dr("PROVINCECODE")
            m_Customer.AREACD = dr("MUNICIPALITYCODE")
            m_CustShipTo.AREACD = dr("MUNICIPALITYCODE")
            m_Customer.CMGRP = dr("CUSTOMERGROUP")
            m_CustShipTo.CMGRP = dr("CUSTOMERGROUP")
            If IsDBNull(dr("CUSTOMERCLASS")) Then
                m_Customer.CMCLASS = ""
            Else
                m_Customer.CMCLASS = dr("CUSTOMERCLASS")
            End If
            If IsDBNull(dr("CUSTOMERCLASS")) Then
                m_CustShipTo.CMCLASS = ""
            Else
                m_CustShipTo.CMCLASS = dr("CUSTOMERCLASS")
            End If

            m_Customer.ACCNTSHRD = dr("ACCOUNT SHARED")
            m_CustShipTo.ACCNTSHRD = dr("ACCOUNT SHARED")

            ctr += 1
            If Not Customer.CheckCustomerAndCompanyIfExist(m_Customer.CUSTOMERCD, m_Customer.COMID) Then
                m_Customer.Save()
                m_CustShipTo.Save()
            Else
                m_Customer.Update()
                m_CustShipTo.Update()
            End If
        Next

        ProgressBar1.Visible = False
        MessageBox.Show("File Successfully Uploaded!")
        Me.Close()

    End Sub


    Private Sub CustomerUploading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateComboBox()
        Timer1.Enabled = False
    End Sub

    Private Sub cmbFiletype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFiletype.SelectedIndexChanged
        lblBrowseFile.Enabled = True
    End Sub

    Private Sub cmbCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        cmbFiletype.Enabled = True
    End Sub

End Class