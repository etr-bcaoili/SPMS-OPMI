Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ucMasterRegion
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule

Public Class ucCompany
    Private GridRs As New ADODB.Recordset
    Private Operation As String

    Private Function RsCompany(Optional ByVal Filter As String = "", Optional ByVal OrderBy As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " where " & Filter
        End If
        If OrderBy <> "" Then
            OrderBy = " order by " & OrderBy
        End If
        rs.Open("select * from company " & Filter & OrderBy, SPMSConn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Return rs
    End Function

    Private Sub SetupbyOperation(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation
    End Sub
    Private Sub ClearForm()
        txtCode.Text = ""
        txtName.Text = ""
        txtAddress.Text = ""
        txtContactNumber.Text = ""
        txtEmail.Text = ""
        txtTinno.Text = ""
        txtBanker.Text = ""
        txtCustom1.Text = ""
        txtCustom2.Text = ""
    End Sub

    Private Sub OpenListing()
        If GridRs.State = 1 Then GridRs.Close()
        GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        GridRs.Open("SELECT * FROM COMPANY WHERE DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        GridListing.Rows.Clear()
        If GridRs.RecordCount > 0 Then
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)


                row.Cells(CompanyID.Index).Value = GridRs.Fields("COMID").Value
                row.Cells(ComName.Index).Value = GridRs.Fields("COMNAME").Value
                row.Cells(Address.Index).Value = GridRs.Fields("ADDR").Value
                row.Cells(ContactNumber.Index).Value = GridRs.Fields("CONTACTNUMBER").Value
                row.Cells(EmailAdd.Index).Value = GridRs.Fields("EMAIL").Value
                row.Cells(TinNo.Index).Value = GridRs.Fields("TINNO").Value

                row.Cells(colStartDate.Index).Value = GridRs.Fields("EffectivityStartDate").Value
                row.Cells(colEndDate.Index).Value = GridRs.Fields("EffectivityEndDate").Value
                GridRs.MoveNext()
            Next
        End If
    End Sub

    Private Function SaveRecord(ByVal Code As String, ByVal Name As String, ByVal Address As String, ByVal ContactNumber As String, ByVal Email As String, ByVal Tinno As String) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC USPCOMPANY @ACTION = 'ADD', @DLTFLG = 0, @COMID = '" & Code & "', @COMNAME = '" & Name & "', @ADDR = '" & Address & "', @CONTACTNUMBER = '" & ContactNumber & "', @EMAIL = '" & Email & "', @TINNO = '" & Tinno & "', @CRTDATE = '" & Now & "',  @CRTU = '', @UPDD = '" & Now & "',  @UPDU = '' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "', @DateofIncorporation = '" & dtIncorporation.Value.ToShortDateString & "' , @BankersName = '" & txtBanker.Text & "' , @Customfield1 = '" & txtCustom1.Text & "'  , @CustomField2 = '" & txtCustom2.Text & "'  ")

        



        Return True

ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Function UpdateRecord(ByVal Code As String, ByVal Name As String, ByVal Address As String, ByVal ContactNumber As String, ByVal Email As String, ByVal Tinno As String) As Boolean
        On Error GoTo ErrorHandler
        'SPMSConn.Execute("EXEC USPCOMPANY @ACTION = 'UPDATE', @DLTFLG = 0, @COMID = '" & Code & "', @COMNAME = '" & Name & "', @ADDR = '" & Address & "', @CONTACTNUMBER = '" & ContactNumber & "', @EMAIL = '" & Email & "', @TINNO = '" & Tinno & "', @CRTDATE = '" & Now & "',  @CRTU = '', @UPDD = '" & Now & "',  @UPDU = '', @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "'  , @DateofIncorporation = '" & dtIncorporation.Value & "' , @BankersName = '" & txtBanker.Text & "' , @Customfield1 = '" & txtCustom1.Text & "'  , @CustomField2 = '" & txtCustom2.Text & "' ")
        Dim rs As New ADODB.Recordset
        rs = RsCompany("Comid = '" & Code & "'")
        If rs.RecordCount > 0 Then
            rs.Fields("CompanyLogo").Value = ConvertImageFiletoBytes(txtLogo.Text)
            rs.Update()
        End If

        Return True
ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Function DeleteRecord(ByVal Code As String, ByVal Name As String, ByVal Address As String) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC USPCOMPANY @ACTION = 'UPDATE', @DLTFLG = 1, @COMID = '" & Code & "', @COMNAME = '" & Name & "', @ADDR = '" & Address & "', , @CRTDATE = '" & Now & "',  @CRTU = '', @UPDD = '" & Now & "',  @UPDU = '', @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "', @DateofIncorporation = '" & dtIncorporation.Value & "' , @BankersName = '" & txtBanker.Text & "' , @Customfield1 = '" & txtCustom1.Text & "'  , @CustomField2 = '" & txtCustom2.Text & "'  ")
        Return True
ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Function ValidFields() As Boolean
        If txtCode.Text = "" Then
            Return False
        ElseIf txtName.Text = "" Then
            Return False
        ElseIf txtAddress.Text = "" Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function CheckRecordExists(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM COMPANY WHERE COMID = '" & Code & "' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function



    Private Sub MasterItemGroup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetupbyOperation(True)
        ApplyGridTheme(GridListing)
        Operation = "Add"
        OpenListing()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Operation = "Add" Then
            If CheckRecordExists(txtCode.Text) = False Then
                SaveRecord(txtCode.Text, txtName.Text, txtAddress.Text, txtContactNumber.Text, txtEmail.Text, txtTinno.Text)
                SetupbyOperation(False)
                Operation = ""
                OpenListing()
                SaveSuccess()
                ClearForm()
            Else
                RecordExists()
            End If
        ElseIf Operation = "Edit" Then
            If CheckRecordExists(txtCode.Text) = True Then
                UpdateRecord(txtCode.Text, txtName.Text, txtAddress.Text, txtContactNumber.Text, txtEmail.Text, txtTinno.Text)
                SetupbyOperation(False)
                Operation = ""
                OpenListing()
                SaveSuccess()
                ClearForm()
            Else
                RecordInexist()
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        SetupbyOperation(True)
        Operation = "Edit"

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        SetupbyOperation(True)
        Operation = "Add"
        ClearForm()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If CheckRecordExists(txtCode.Text) = True Then
            DeleteRecord(txtCode.Text, txtName.Text, txtAddress.Text)
            DeleteSuccess()
            SetupbyOperation(False)
            Operation = ""
            OpenListing()
        End If
    End Sub

    Private Sub GridListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick

    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Dim field As String = ""
        If GridRs.State = 1 Then GridRs.Close()
        If cmbfilter.Text = "Channel's Code" Then
            field = "COMID"
        ElseIf cmbfilter.Text = "Channel's Name" Then
            field = "COMNAME"
        ElseIf cmbfilter.Text = "Address" Then
            field = "ADDR"
        End If
        GridRs.Open("SELECT * FROM COMPANY WHERE " & field & " like '%" & txtFilter.Text & "%'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If GridRs.RecordCount > 0 Then
            For i As Integer = 0 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)

                row.Cells(CompanyID.Index).Value = GridRs.Fields("COMID").Value
                row.Cells(ComName.Index).Value = GridRs.Fields("COMNAME").Value
                row.Cells(Address.Index).Value = GridRs.Fields("ADDR").Value
                row.Cells(ContactNumber.Index).Value = GridRs.Fields("CONTACTNUMBER").Value
                row.Cells(EmailAdd.Index).Value = GridRs.Fields("EMAIL").Value
                row.Cells(TinNo.Index).Value = GridRs.Fields("TINNO").Value

                row.Cells(colStartDate.Index).Value = GridRs.Fields("EffectivityStartDate").Value
                row.Cells(colEndDate.Index).Value = GridRs.Fields("EffectivityEndDate").Value


                GridRs.MoveNext()
            Next
        End If
    End Sub

    Private Sub GridListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick
        Dim row As DataGridViewRow = GridListing.Rows(e.RowIndex)
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM COMPANY WHERE COMID = '" & row.Cells(CompanyID.Index).Value & "' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            txtCode.Text = rs.Fields("COMID").Value
            txtName.Text = rs.Fields("COMNAME").Value
            txtAddress.Text = rs.Fields("ADDR").Value
            txtContactNumber.Text = rs.Fields("CONTACTNUMBER").Value
            txtEmail.Text = rs.Fields("EMAIL").Value
            txtTinno.Text = rs.Fields("TINNO").Value
            txtBanker.Text = rs.Fields("BankersName").Value
            txtCustom1.Text = rs.Fields("Customfield1").Value
            txtCustom2.Text = rs.Fields("Customfield2").Value
            dtIncorporation.Value = rs.Fields("DateofIncorporation").Value

            dtStart.Value = rs.Fields("EffectivityStartDate").Value
            dtEnd.Value = rs.Fields("EffectivityEndDate").Value

            SetupbyOperation(False)
            Operation = ""
            MainTab.SelectTab(0)
        Else

        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub txtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCode.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtContactNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContactNumber.KeyPress
        'e.KeyChar = UCase(e.KeyChar)



        If IsNumeric(e.KeyChar) = False Then
            If AscW(e.KeyChar) = 45 Then
            ElseIf AscW(e.KeyChar) = 8 Then
            ElseIf AscW(e.KeyChar) = 13 Then
            Else
                e.KeyChar = Nothing
            End If
        End If
    End Sub

    Private Sub txtEmail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmail.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtTinno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTinno.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtContactNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContactNumber.TextChanged

    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        OFDPic.FileName = ""
        OFDPic.ShowDialog()

        If OFDPic.FileName <> "" Then
            txtLogo.Text = OFDPic.FileName
        End If
    End Sub
End Class
