Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Imports System.Data.OleDb
Imports ADODB
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Windows
Public Class CustMapping

    Private m_sharing As New SharingCompany
    Dim m_HasError As Boolean = False
    Private m_Err As New ErrorProvider
    Private m_CompanyCodes As New Sharing
    Private m_Months As New Sharing
    Private m_Years As New Sharing
    Dim _Sharing As New SharingCompany
    Dim l_results As ListViewItem
    Private m_SharingRowCol As SharingCollection
    Private m_SharingOrg As Sharing
    Private m_CompanyCode As String = String.Empty
    Private m_Month As String = String.Empty
    Private m_Year As New ADODB.Recordset
    Private m_RsMonth As New ADODB.Recordset
    Dim m_RsYear As ADODB.Recordset
    Dim rs As ADODB.Recordset
    Dim dt As New DataTable
    Dim rs1 As ADODB.Recordset
    Dim urec As Long
    Dim objExcel As Excel.Application
    Dim rec_count
    Dim _ExcelResult As New ExcelSharing
    Dim _n As String
    Private table As DataTable


    Private Sub PopulateComboBox()
        Dim rs As New ADODB.Recordset
        cbocompany.Items.Clear()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM DISTRIBUTOR WHERE /*DISTCOMID <> '" & "WAT" & "' AND*/ DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            For i = 1 To rs.RecordCount
                cbocompany.Items.Add(rs.Fields("DISTCOMID").Value)
                rs.MoveNext()
            Next i

        End If
    End Sub

    Private Sub CustMapping_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateComboBox()
        LoadYear()
        Timer1.Enabled = False
        loadViewConfig()
    End Sub
    Private Sub loadViewConfig()
        table = GetRecords("Select * from ConfigurationType")
        For i As Integer = 0 To table.Rows.Count - 1
            cboConfig.Items.Add(table.Rows(i)("ConfigTypeCode"))
        Next
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
    End Sub
    Private Sub OpenFile()
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Microsoft Office Excel(*.xls)|*.xls;*.xlsx"
        If (ofd.ShowDialog() = DialogResult.OK) Then
            If ofd.FileName.Length > 255 Then
                ShowExclamation("Path Too Long.", "Sales Agent")
                Exit Sub
            End If
            txtFileName.Text = ofd.FileName
        End If

    End Sub

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click, LinkLabel1.Click, Button1.Click

        If sender Is LinkLabel1 Then
            BrowseFile()
        ElseIf sender Is Button1 Then
            Me.Close()
        ElseIf sender Is btnUpload Then
            UploadFile()
        End If
    End Sub
    Private Sub BrowseFile()

        _ExcelResult.CompanyCode = cbocompany.Text
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
        If Not SharingCompany.CheckIfItempriceListDataExist(cbocompany.Text, cboYear.Text, cboMonth.Text, cboConfig.Text) Then
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

            VDialog.Show("Record Successfully Uploaded", "Sharing  Uploading", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            SharingCompany.DeleteExistIfitempriceList(cbocompany.Text, cboYear.Text, cboMonth.Text, cboConfig.Text)
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
            VDialog.Show("Record Successfully Uploaded", "Sharing  Uploading", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function valit() As Boolean

        m_Err.Clear()
        m_HasError = False
        'valid2()

        If cbocompany.Text = "" Then
            m_Err.SetError(cbocompany, "Company code is Empty")
            m_HasError = True
        End If

        If cboYear.Text = "" Then
            m_Err.SetError(cboYear, "Year Selection is not Required")
            m_HasError = True
        End If

        If cboMonth.Text = "" Then
            m_Err.SetError(cboMonth, "Month Selection is not Required")
            m_HasError = True
        End If

        If txtFileName.Text = "" Then
            m_Err.SetError(txtFileName, "Filename is Empty")
            m_HasError = True
        End If

        If cboConfig.Text = "" Then
            m_Err.SetError(cboConfig, "Configtype Code is Requared!")
            m_HasError = True
        End If

        Return Not m_HasError

    End Function
    Private Sub vALIDT()

        m_RsYear = New ADODB.Recordset
        Dim q As MsgBoxResult
        m_RsYear.Open("Select *  from Sharing where  CUTYEAR='" & cboYear.Text & "' AND CUTMO= '" & cboMonth.Text & "' AND COMID= '" & cbocompany.Text & "'", ConnectionModule.SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsYear.EOF = False Then
            q = VDialog.Show("File upload is already exist Do want to Continue?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If q = MsgBoxResult.Yes Then
                Delete()
            End If
        Else
            StartUpload(txtFileName.Text)
        End If

    End Sub
    Private Sub valid2()
        m_RsYear = New ADODB.Recordset
        m_CompanyCodes = New Sharing
        m_RsYear.Open("Select *  from Sharing where  CUTYEAR='" & cboYear.Text & "' AND CUTMO= '" & cboMonth.Text & "' AND COMID= '" & cbocompany.Text & "'", ConnectionModule.SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        m_Err.Clear()
        m_HasError = False

        If (String.IsNullOrEmpty(cbocompany.Text)) Then
            m_Err.SetError(cbocompany, "This is a required field")
            m_HasError = True
        End If
        If (String.IsNullOrEmpty(cboMonth.Text)) Then
            m_Err.SetError(cboMonth, "This is a required field")
            m_HasError = True
        End If
        If (String.IsNullOrEmpty(cboYear.Text)) Then
            m_Err.SetError(cboYear, "This is a required field")
            m_HasError = True
        End If

        If cbocompany.Text <> m_CompanyCodes.CUSCD Then
            m_Err.SetError(cbocompany, "Item Code is required")
            m_HasError = True
        End If
        If cboMonth.Text <> m_Months.CUTMO Then
            m_Err.SetError(cboMonth, "Month is not equal")
            m_HasError = True
        End If
        If cboYear.Text <> m_Years.CUTYEAR Then
            m_Err.SetError(cboYear, "Year is not equal")
            m_HasError = True
        End If
    End Sub
    Private Sub Delete()

        If Not cbocompany.Text = "" Then
            '' Try
            SPMSConn.Execute("EXEC uspSharing @Action = 'DELETE' , @COMID = '" & cbocompany.Text & "',@CUTYEAR = '" & cboYear.Text & "', @CUTMO = '" & cboMonth.Text & "' , @Delflag = 0 ")
            'VDialog.Show("Record Sucessfully Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            StartUpload(txtFileName.Text)
            ' Catch ex As Exception
            'Throw New Exception(ex.Message)
            ' End Try
        Else
            VDialog.Show("There are no record to be deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub deletecompany()
        m_RsYear = New ADODB.Recordset
        m_RsYear.Open("Truncate table SharingCompany", ConnectionModule.SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
    End Sub


    Private Function StartUpload(ByVal FileName As String) As Boolean
        ' On Error Resume Next
        'Try 
        Dim conn As OleDbConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & FileName & " ;Extended Properties=Excel 8.0;")
        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter("SELECT * FROM [Sharing per Channel$A8:N]  Where [Year] like '" & cboYear.Text & "' AND [Month]  like '" & cboMonth.Text & "' and  [Company] like '" & cbocompany.Text & "'", conn)

        Dim m_Sharing As New SharingCompany
        da.Fill(dt)
        Dim ctr As Integer = 0

        pbar.Visible = True

        For m As Integer = 0 To dt.Rows.Count - 1

            Dim dr As DataRow = dt.Rows(m)
            pbar.Value = ctr / dt.Rows.Count * 100
            m_Sharing = New SharingCompany
            m_Sharing.CUTYEAR = dr("YEAR")
            m_Sharing.CUTMO = dr("Month")
            If IsDBNull(dr("Company")) Then
                m_Sharing.COMID = ""
            Else
                m_Sharing.COMID = dr("Company")
            End If
            If IsDBNull(dr("Customer Code")) Then
                m_Sharing.CUSCD = ""
            Else
                m_Sharing.CUSCD = dr("Customer Code")
            End If
            If IsDBNull(dr("Customer Name")) Then
                m_Sharing.CUSNAM = ""
            Else
                m_Sharing.CUSNAM = dr("Customer Name")
            End If
            If IsDBNull(dr("Ship to Code")) Then
                m_Sharing.CDACD = ""
            Else
                m_Sharing.CDACD = dr("Ship to Code")
            End If
            If IsDBNull(dr("Ship to name")) Then
                m_Sharing.CDANAME = ""
            Else
                m_Sharing.CDANAME = dr("Ship to Name")
            End If
            If IsDBNull(dr("Territory Code")) Then
                m_Sharing.TERRCD = ""
            Else
                m_Sharing.TERRCD = dr("Territory Code")
            End If
            If IsDBNull(dr("Salesman Code")) Then
                m_Sharing.STSLSMNCD = ""
            Else
                m_Sharing.STSLSMNCD = dr("Salesman Code")
            End If
            If IsDBNull(dr("Salesman Name")) Then
                m_Sharing.STSLSMNNAME = ""
            Else
                m_Sharing.STSLSMNNAME = dr("Salesman Name")
            End If
            If IsDBNull(dr("Item Division")) Then
                m_Sharing.ITEMDIVCD = ""
            Else
                m_Sharing.ITEMDIVCD = dr("Item Division")
            End If

            m_Sharing.PERSHR = dr("Per Share")
            m_Sharing.DELFLAG = dr("Status")
            m_Sharing.IsActive = dr("Active")
            m_Sharing.Save()
            ctr += 1
        Next

        'pbar.Value = ctr

        'If pbar.Value = 100 Then

        VDialog.Show("Record Successfully Uploaded", "Sharing  Uploading", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Me.Close()
        '  End If

        'Catch ex As Exception
        'MsgBox(ex.Message)
        ' End Try

    End Function

    
    Private Sub LoadYear()
        If m_Year.State = 1 Then m_Year.Close()
        m_Year.Open("SELECT Distinct CAYR  FROM Calendar", ConnectionModule.SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_Year.RecordCount > 0 Then
            cboYear.Items.Clear()
            For m As Integer = 0 To m_Year.RecordCount - 1
                cboYear.Items.Add(m_Year.Fields("CAYR").Value)
                m_Year.MoveNext()
            Next
        End If
    End Sub

    Private Sub cboYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboYear.SelectedIndexChanged
        fillterSharing()
        If cboYear.SelectedIndex = -1 Then Exit Sub
        LoadMonth(cbocompany.Text, cboYear.Text)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub cboMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMonth.SelectedIndexChanged
        fillterSharing()

    End Sub

    Private Sub cmbcompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbocompany.SelectedIndexChanged
        fillterSharing()
    End Sub
    Private Sub fillterSharing()
        On Error Resume Next
        m_RsYear.Open("Select * from Sharing where " & "CUTYEAR" & " LIKE '" & cbocompany.Text & _
                     "*' AND " & "CUTMO" & " LIKE '" & cboMonth.Text & _
                     "*' AND " & "COMID" & " LIKE '" & cbocompany.Text & "*'", ConnectionModule.SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

    End Sub
    Private Sub LoadMonth(ByVal DistributorCode As String, ByVal Year As String)
        If m_RsMonth.State = 1 Then m_RsMonth.Close()
        m_RsMonth.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsMonth.Open("SELECT * FROM Calendar WHERE COMID = '" & DistributorCode & "' AND CAYR = '" & Year & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsMonth.RecordCount > 0 Then
            cboMonth.Items.Clear()
            For m As Integer = 0 To m_RsMonth.RecordCount - 1
                cboMonth.Items.Add(m_RsMonth.Fields("CAPN").Value)
                m_RsMonth.MoveNext()
            Next
        End If

    End Sub


    Private Sub txtFileName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFileName.TextChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class