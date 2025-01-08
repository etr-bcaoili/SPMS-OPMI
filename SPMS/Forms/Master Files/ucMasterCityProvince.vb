Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ucMasterRegion
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class ucMasterCityProvince
    Private GridRs As New ADODB.Recordset
    Private rsRegion As New ADODB.Recordset
    Private Operation As String

    Private Sub ClearForm()
        cmbRegionCode.Text = ""
        cmbRegionDesc.Text = ""
        txtDescription.Text = ""
        txtdistrictCode.Text = ""
        txtFilter.Text = ""
    End Sub

    Private Sub SetupOperation(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation
    End Sub
    Private Sub EnableText()
        txtdistrictCode.ReadOnly = True
        txtDescription.ReadOnly = True
    End Sub
    Private Sub UnEnableText()
        txtdistrictCode.ReadOnly = False
        txtDescription.ReadOnly = False
    End Sub
    Private Sub OpenListing()

        If GridRs.State = 1 Then GridRs.Close()
        GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        GridRs.Open("SELECT * FROM DISTRICT WHERE DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        

        GridListing.Rows.Clear()
        If GridRs.RecordCount > 0 Then
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(colCode.Index).Value = GridRs.Fields("REGCD").Value
                If rsRegion.State = 1 Then rsRegion.Close()
                rsRegion.Open("Select REGNAME From REGION Where REGCD = '" & GridRs.Fields("REGCD").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                row.Cells(RegionDescription.Index).Value = rsRegion.Fields("REGNAME").Value
                row.Cells(colDistrictCode.Index).Value = GridRs.Fields("DISTRCTCD").Value
                row.Cells(colDescription.Index).Value = GridRs.Fields("DISTRCTNAME").Value
                row.Cells(colEffectivityStartDate.Index).Value = CDate(GridRs.Fields("EFFECTIVITYSTARTDATE").Value).ToShortDateString
                row.Cells(colEffectivityEndDate.Index).Value = CDate(GridRs.Fields("EFFECTIVITYENDDATE").Value).ToShortDateString

                GridRs.MoveNext()
            Next



        End If


        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT REGCD,REGNAME FROM REGION WHERE DLTFLG = 0 ORDER BY REGCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            cmbRegionCode.Items.Clear()
            For i As Integer = 1 To rs.RecordCount
                cmbRegionCode.Items.Add(rs.Fields("REGCD").Value)
                cmbRegionDesc.Items.Add(rs.Fields("REGNAME").Value)
                rs.MoveNext()
            Next
        End If
    End Sub

    Private Function CheckRecordExists(ByVal Code As String, ByVal RegionCode As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM DISTRICT WHERE REGCD = '" & RegionCode & "' AND DISTRCTCD = '" & Code & "' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function SaveRecord(ByVal RegionCode As String, ByVal DistrictCode As String, ByVal DistrictDescription As String, ByVal EffectivityStartDate As Date, ByVal EffectivityEndDate As Date) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC uspDistrict @Action = 'ADD', @DLTFLG = 0, @REGCD = '" & RegionCode & "', @DISTRCTCD = '" & DistrictCode & "', @DISTRCTNAME = '" & DistrictDescription & "', @CRTDATE = '" & Now & "',  @CRTU = '', @UPDD = '" & Now & "',  @UPDU = '' , @EFFECTIVITYSTARTDATE = '" & EffectivityStartDate & "',@EFFECTIVITYENDDATE = '" & EffectivityEndDate & "'")
        Return True

ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If

    End Function

    Private Function UpdateRecord(ByVal RegionCode As String, ByVal DistrictCode As String, ByVal DistrictDescription As String, ByVal EffectivityStartDate As Date, ByVal EffectivityEndDate As Date) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC uspDistrict @Action = 'UPDATE', @REGCD = '" & RegionCode & "', @DISTRCTCD = '" & DistrictCode & "', @DISTRCTNAME = '" & DistrictDescription & "' , @EFFECTIVITYSTARTDATE = '" & EffectivityStartDate & "',@EFFECTIVITYENDDATE = '" & EffectivityEndDate & "'")
        Return True

ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Function DeleteRecord(ByVal RegionCode As String, ByVal DistrictCode As String) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC uspDistrict @Action = 'DELETE', @REGCD = '" & RegionCode & "', @DISTRCTCD = '" & DistrictCode & "' ")
        Return True

ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        cmbRegionCode.Focus()
        SetupOperation(True)
        Operation = "Add"
        ClearForm()
        UnEnableText()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        SetupOperation(True)
        Operation = "Edit"
        UnEnableText()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidFields() = True Then
            If Operation = "Add" Then
                If CheckRecordExists(txtdistrictCode.Text, cmbRegionCode.Text) = True Then
                    RecordExists()
                Else
                    SaveRecord(cmbRegionCode.Text, txtdistrictCode.Text, txtDescription.Text, dtStart.Value, dtEnd.Value)
                    SaveSuccess()
                    SetupOperation(False)
                    Operation = ""
                    OpenListing()
                    ClearForm()
                    EnableText()
                End If
            ElseIf Operation = "Edit" Then
                If CheckRecordExists(txtdistrictCode.Text, cmbRegionCode.Text) = True Then
                    UpdateRecord(cmbRegionCode.Text, txtdistrictCode.Text, txtDescription.Text, dtStart.Value, dtEnd.Value)
                    SaveSuccess()
                    SetupOperation(False)
                    Operation = ""
                    OpenListing()
                    ClearForm()
                    EnableText()
                Else
                    RecordInexist()
                End If
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If CheckRecordExists(txtdistrictCode.Text, cmbRegionCode.Text) = True Then
            If HasReferenceRecords("DISTRICT", txtdistrictCode.Text) = False Then
                DeleteRecord(cmbRegionCode.Text, txtdistrictCode.Text)
                DeleteSuccess()
                Operation = ""
                OpenListing()
                ClearForm()
                EnableText()
            Else
                EntryHasReference()
            End If
        End If
    End Sub

    Private Sub Filter()
        Dim field As String
        If cmbfilter.Text = "RegionCode" Then
            field = "REGCD"
        ElseIf cmbfilter.Text = "City/ProvinceCode" Then
            field = "DISTRCTCD"
        ElseIf cmbfilter.Text = "Description" Then
            field = "DISTRCTNAME"
        Else
            field = ""
        End If
        Dim GridRs As New ADODB.Recordset
        GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        If cmbfilter.Text = "All" Then
            GridRs.Open("SELECT * FROM DISTRICT WHERE DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Else
            GridRs.Open("SELECT * FROM DISTRICT WHERE " & field & " like '%" & txtFilter.Text & "%' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        End If
        If GridRs.RecordCount > 0 Then
            GridListing.Rows.Clear()
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(colCode.Index).Value = GridRs.Fields("REGCD").Value
                If rsRegion.State = 1 Then rsRegion.Close()
                rsRegion.Open("Select REGNAME From REGION Where REGCD = '" & GridRs.Fields("REGCD").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                row.Cells(RegionDescription.Index).Value = rsRegion.Fields("REGNAME").Value
                row.Cells(colDistrictCode.Index).Value = GridRs.Fields("DISTRCTCD").Value
                row.Cells(colDescription.Index).Value = GridRs.Fields("DISTRCTNAME").Value
                row.Cells(colEffectivityStartDate.Index).Value = CDate(GridRs.Fields("EFFECTIVITYSTARTDATE").Value).ToShortDateString
                row.Cells(colEffectivityEndDate.Index).Value = CDate(GridRs.Fields("EFFECTIVITYENDDATE").Value).ToShortDateString

                GridRs.MoveNext()
            Next
        End If
    End Sub


    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        
        Filter()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub MasterDistrict_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus

    End Sub

    Private Sub MasterDistrict_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetupOperation(True)
        Operation = "Add"
        ApplyGridTheme(GridListing)
        OpenListing()
    End Sub


    Private Sub GridListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick
        Dim row As DataGridViewRow = GridListing.Rows(e.RowIndex)
        If CheckRecordExists(row.Cells(colDistrictCode.Index).Value, row.Cells(colCode.Index).Value) = True Then
            Dim rs As New ADODB.Recordset
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.Open("SELECT * FROM DISTRICT WHERE DLTFLG = 0 AND REGCD = '" & row.Cells(colCode.Index).Value & "' AND DISTRCTCD = '" & row.Cells(colDistrictCode.Index).Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                cmbRegionCode.Text = rs.Fields("REGCD").Value
                txtdistrictCode.Text = rs.Fields("DISTRCTCD").Value
                txtdistrictCode.Tag = rs.Fields("DISTRCTCD").Value
                txtDescription.Text = rs.Fields("DISTRCTNAME").Value
                SetupOperation(False)
                EnableText()
                Operation = ""
                MainTab.SelectTab(0)
            End If
        End If
    End Sub

    Private Function ValidFields() As Boolean
        If cmbRegionCode.Text = "" Then
            Return False
        ElseIf txtDescription.Text = "" Then
            Return False
        ElseIf txtdistrictCode.Text = "" Then
            Return False
        Else
            Return True
        End If
    End Function

   

    Private Sub cmbRegionCode_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        OpenListing()
    End Sub

    

    Private Sub txtdistrictCode_KeyPress(ByVal sender As System.Object, ByVal c As System.Windows.Forms.KeyPressEventArgs)
        c.KeyChar = UCase(c.KeyChar)
    End Sub
    Private Sub txtDescription_KeyPress(ByVal sender As System.Object, ByVal c As System.Windows.Forms.KeyPressEventArgs)
        c.KeyChar = UCase(c.KeyChar)
    End Sub

    Private Sub llRegion_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llRegion.LinkClicked
        MainWindow.TabControl1.TabPages.Add(MainWindow.TabControl1.TabPages.Count)
        Dim mine As New ucMasterRegion
        mine.Width = Me.Width
        mine.Height = MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Height - 30
        MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Text = mine.Name
        MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Controls.Add(mine)
        MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Text = "Master Region"
        MainWindow.TabControl1.SelectTab(MainWindow.TabControl1.TabPages.Count - 1)
    End Sub

    Public Sub RepopulateCombo()
        cmbRegionCode.Items.Clear()
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT REGCD FROM REGION WHERE DLTFLG = 0 ORDER BY REGCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            cmbRegionCode.Items.Clear()
            For i As Integer = 1 To rs.RecordCount
                cmbRegionCode.Items.Add(rs.Fields("REGCD").Value)
                rs.MoveNext()
            Next
        End If
    End Sub

    Private Sub cmbRegionCode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRegionCode.GotFocus
        RepopulateCombo()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then
            Filter()
        End If
    End Sub

    Private Sub cmbRegionCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegionCode.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
        'rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rs.Open("SELECT REGNAME FROM REGION WHERE REGCD = '" & cmbRegionCode.Text & "' AND DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        'If rs.RecordCount > 0 Then
        '    txtRegion.Text = (rs.Fields("REGNAME").Value)
        'End If
        rs = RsRegionInfo("RegCD = '" & cmbRegionCode.Text & "' ")

        If rs.RecordCount > 0 Then
            cmbRegionDesc.Text = rs.Fields("RegName").Value
        End If

    End Sub

    Private Function RsRegionInfo(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT * FROM REGION WHERE DLTFLG = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function

    Private Sub cmbRegionDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegionDesc.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
        rs = rsRegionInfo("Regname = '" & cmbRegionDesc.Text & "' ")
        If rs.RecordCount > 0 Then
            cmbRegionCode.Text = rs.Fields("RegCD").Value
        End If
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub

    Private Sub GridListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick

    End Sub
End Class