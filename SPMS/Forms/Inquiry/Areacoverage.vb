Imports System.Data.OleDb
Imports System.Windows.Forms
Public Class Areacoverage
    Private m_FileName As String = String.Empty
    Private m_Err As New ErrorProvider
    Private m_Areacoverages As New AreaCoverages
    Dim table As DataTable
    Private Sub lnkStartUploading_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStartUploading.LinkClicked
        If ValidateData() Then
            StartUpload()
        End If
    End Sub
    Private Sub StartUpload()
        Dim ctr As Integer = 0
        m_FileName = txtfile.Text
        Dim con As OleDbConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & m_FileName & " ;Extended Properties=Excel 8.0;")
        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter("SELECT * FROM [Sheet1$] where STACOVNAME ", con)
        da.Fill(dt)
        If dt.Rows.Count = 0 Then
            VDialog.Show("No Record Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If Not AreaCoverages.CheckField(cboCompanycode.Text) Then
                pbar.Visible = True
                For m As Integer = 0 To dt.Rows.Count - 1
                    pbar.Value = ctr / dt.Rows.Count * 100
                    Dim dr As DataRow = dt.Rows(m)
                    m_Areacoverages = New AreaCoverages
                    m_Areacoverages.DTFLG = dr("DLTFLG")
                    m_Areacoverages.ConfigTypeCode = cboCompanycode.Text
                    If IsDBNull(dr("STACOVCD")) Then
                        m_Areacoverages.STACOVCD = "999"
                    Else
                        m_Areacoverages.STACOVCD = dr("STACOVCD")
                    End If
                    If IsDBNull(dr("STACOVNAME")) Then
                        m_Areacoverages.STACOVNAME = "999"
                    Else
                        m_Areacoverages.STACOVNAME = dr("STACOVNAME")
                    End If
                    If IsDBNull(dr("CRTDATE")) Then
                        m_Areacoverages.CRTDATE = "1/1/1900"
                    Else
                        m_Areacoverages.CRTDATE = dr("CRTDATE")
                    End If
                    If IsDBNull(dr("UPDD")) Then
                        m_Areacoverages.UPDD = "1/1/1900"
                    Else
                        m_Areacoverages.UPDD = dr("UPDD")
                    End If
                    m_Areacoverages.EffictivetyStartDate = dr("EffectivityStartDate")
                    m_Areacoverages.EffictivetyEndDate = dr("EffectivityEndDate")
                    m_Areacoverages.Save()
                    ctr += 1
                Next
            Else
                AreaCoverages.DeleteField(cboCompanycode.Text)
                pbar.Visible = True
                For m As Integer = 0 To dt.Rows.Count - 1
                    pbar.Value = ctr / dt.Rows.Count * 100
                    Dim dr As DataRow = dt.Rows(m)
                    m_Areacoverages = New AreaCoverages
                    m_Areacoverages.DTFLG = dr("DLTFLG")
                    m_Areacoverages.ConfigTypeCode = cboCompanycode.Text
                    If IsDBNull(dr("STACOVCD")) Then
                        m_Areacoverages.STACOVCD = "999"
                    Else
                        m_Areacoverages.STACOVCD = dr("STACOVCD")
                    End If
                    If IsDBNull(dr("STACOVNAME")) Then
                        m_Areacoverages.STACOVNAME = "999"
                    Else
                        m_Areacoverages.STACOVNAME = dr("STACOVNAME")
                    End If
                    If IsDBNull(dr("CRTDATE")) Then
                        m_Areacoverages.CRTDATE = "1/1/1900"
                    Else
                        m_Areacoverages.CRTDATE = dr("CRTDATE")
                    End If
                    If IsDBNull(dr("UPDD")) Then
                        m_Areacoverages.UPDD = "1/1/1900"
                    Else
                        m_Areacoverages.UPDD = dr("UPDD")
                    End If
                    m_Areacoverages.EffictivetyStartDate = dr("EffectivityStartDate")
                    m_Areacoverages.EffictivetyEndDate = dr("EffectivityEndDate")
                    m_Areacoverages.Save()
                    ctr += 1
                Next
            End If
            pbar.Visible = False
            ShowInformation("Record Successfully Uploaded", "Expense Uploading")
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

    Private Sub Areacoverage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadData()
    End Sub
    Private Sub loadData()
        table = GetRecords("Select ConfigTypeCode from ConfigurationType")
        For i As Integer = 0 To table.Rows.Count - 1
            cboCompanycode.Items.Add(table.Rows(i)("ConfigTypecode"))
        Next
    End Sub

    Private Sub lblBrowseFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBrowseFile.Click
        OpenFile()
    End Sub
    Private Sub OpenFile()
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

    Private Sub lnkClose_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkClose.LinkClicked
        Me.Dispose()
    End Sub
End Class