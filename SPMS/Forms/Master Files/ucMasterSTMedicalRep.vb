Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ucMasterRegion
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule

Public Class ucMasterSTMedicalRep

    Private Operation As String = ""
    Private GridRs As New ADODB.Recordset


    Private Sub SetupButtons(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation
    End Sub

    Private Sub ClearForm()
        txtSalesManCode.Text = ""
        txtSalesManName.Text = ""
        txtFilter.Text = ""
        cmbfilter.Text = ""
        txtterritorycode.Text = ""
        txtterritoryname.Text = ""
        txtposition.Text = ""
        txtpositioncode.Text = ""
        cmbSalesManCode.SelectedIndex = -1
    End Sub

    Private Sub Enabletext()
        txtSalesManCode.ReadOnly = True
        txtSalesManName.ReadOnly = True
        txtFilter.ReadOnly = True
        txtterritorycode.ReadOnly = True
        txtterritoryname.ReadOnly = True
        txtposition.ReadOnly = True
        txtpositioncode.ReadOnly = True
        cmbSalesManCode.Enabled = False
    End Sub
    Private Sub MastState_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Code below will set up the form in add mode
        ClearForm()
        ApplyGridTheme(GridListing)
        LoadSalesmanCode()
        SetupButtons(True)
        Operation = "Add"
        OpenListing()
    End Sub

    Private Sub OpenListing()
        GridRs = New ADODB.Recordset
        GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        GridRs.Open("SELECT SLSMNCD, SLSMNNAME,EFFECTIVITYSTARTDATE,EFFECTIVITYENDDATE, IsActive  FROM MEDICALREP WHERE DLTFLG = 0 ", SPMSOPCI.ConnectionModule.SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        GridListing.Rows.Clear()
        If GridRs.RecordCount > 0 Then
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)

                row.Cells(SalesManCode.Index).Value = GridRs.Fields("SLSMNCD").Value
                row.Cells(SalesManName.Index).Value = GridRs.Fields("SLSMNNAME").Value
                row.Cells(colEffectivityStartdate.Index).Value = GridRs.Fields("EFFECTIVITYSTARTDATE").Value
                row.Cells(colEffectivityEnddate.Index).Value = GridRs.Fields("EFFECTIVITYENDDATE").Value
                row.Cells(colStatus.Index).Value = IIf(GridRs.Fields("IsActive").Value = True, "Active", "Inactive")
                GridRs.MoveNext()
            Next

        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        SetupButtons(True)
        Operation = "Add"
        ClearForm()
        UnEnabletext()
    End Sub
    Private Sub UnEnbletext2()
        txtSalesManCode.ReadOnly = True
        txtSalesManName.ReadOnly = False
        txtFilter.ReadOnly = False
        txtterritorycode.ReadOnly = False
        txtterritoryname.ReadOnly = False
        txtposition.ReadOnly = False
        txtpositioncode.ReadOnly = False
        cmbSalesManCode.Enabled = False
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        SetupButtons(True)
        Operation = "Edit"
        UnEnbletext2()
    End Sub
    Private Sub UnEnabletext()
        txtSalesManCode.ReadOnly = False
        txtSalesManName.ReadOnly = False
        txtFilter.ReadOnly = False
        txtterritorycode.ReadOnly = False
        txtterritoryname.ReadOnly = False
        txtposition.ReadOnly = False
        txtpositioncode.ReadOnly = False
        cmbSalesManCode.Enabled = True
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Operation = "Add" Then
            If CheckRecordExists(txtSalesManCode.Text) = False Then
                SaveRecord(txtSalesManCode.Text, txtSalesManName.Text, dtStart.Value, dtEnd.Value)
                SaveSuccess()
                SetupButtons(False)
                Operation = ""
                OpenListing()
                ClearForm()
                Enabletext()
            Else
                RecordExists()
            End If
        ElseIf Operation = "Edit" Then
            If CheckRecordExists(txtSalesManCode.Text) = True Then
                UpdateRecord(txtSalesManCode.Text, txtSalesManName.Text, dtStart.Value, dtEnd.Value)
                SaveSuccess()
                SetupButtons(False)
                Operation = ""
                OpenListing()
                ClearForm()
                UnEnabletext()
            Else
                RecordInexist()
            End If
        End If
    End Sub

    Private Function SaveRecord(ByVal Code As String, ByVal Description As String, ByVal EffectivityStartDate As Date, ByVal EffectivityEndDate As Date) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC  uspMedicalRep @ACTION = 'ADD', @DLTFLG = 0, @SLSMNCD = '" & HandleSingleQuoteInSql(Code) & "', " & _
                         " @SLSMNNAME = '" & HandleSingleQuoteInSql(Description) & "', @CRTDATE = '" & Now & "', @CRTU = '', @UPDD = '" & Now & "', @UPDU = '',@EFFECTIVITYSTARTDATE = '" & EffectivityStartDate & "' ,@EFFECTIVITYENDDATE = '" & EffectivityEndDate & "' ,@PositionName = '" & txtposition.Text & "',@PositionCode = '" & txtpositioncode.Text & "',@TerritoryCode = '" & txtterritorycode.Text & "',@TerritoryName = '" & txtterritoryname.Text & "', @IsActive = " & chkIsActive.Checked & "")
        Return True

ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Function UpdateRecord(ByVal Code As String, ByVal Description As String, ByVal EffectivityStartDate As Date, ByVal EffectivityEndDate As Date) As Boolean
        On Error GoTo ErrorHandler
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM [MEDICALREP] WHERE SLSMNCD = '" & Code & "'", SPMSOPCI.ConnectionModule.SPMSConn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then
            SPMSConn.Execute("EXEC  uspMEDICALREP @ACTION = 'UPDATE', @DLTFLG = 0, @SLSMNCD = '" & Code & "', @SLSMNNAME = '" & Description & "', @CRTDATE = '" & Now & "', @CRTU = '', @UPDD = '" & Now & "', @UPDU = '',@EFFECTIVITYSTARTDATE = '" & EffectivityStartDate & "',@EFFECTIVITYENDDATE = '" & EffectivityEndDate & "' ,@PositionCode = '" & txtpositioncode.Text & "' , @PositionName = '" & txtposition.Text & "',@TerritoryCode = '" & txtterritorycode.Text & "',@TerritoryName = '" & txtterritoryname.Text & "',@IsActive = " & chkIsActive.Checked & " ")
            Return True
        End If
ErrorHandler:
        If ErrorExist(Err.Number) = True Then
        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function
    Private Function DeleteRecord(ByVal Code As String, ByVal Description As String) As Boolean
        On Error GoTo ErrorHandler
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM [MEDICALREP] WHERE SLSMNCD = '" & Code & "' And DLTFLG = 0", SPMSOPCI.ConnectionModule.SPMSConn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then
            SPMSConn.Execute("EXEC  uspMEDICALREP @ACTION = 'UPDATE', @DLTFLG = 1, @SLSMNCD = '" & Code & "', @SLSMNNAME = '" & Description & "', @CRTDATE = '" & Now & "', @CRTU = '', @UPDD = '" & Now & "', @UPDU = '' , @IsActive = " & chkIsActive.Checked & "")
            Return True
        End If
ErrorHandler:
        If ErrorExist(Err.Number) = True Then
        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Function CheckRecordExists(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM MEDICALREP WHERE SLSMNCD  = '" & Code & "' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If


    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If CheckRecordExists(txtSalesManCode.Text) = True Then

            If HasReferenceRecords("MEDICALREP", txtSalesManCode.Text) = False Then
                DeleteRecord(txtSalesManCode.Text, txtSalesManName.Text)
                SetupButtons(False)
                Operation = ""
                DeleteSuccess()
                ClearForm()
                OpenListing()
            Else
                EntryHasReference()
            End If
        Else
            RecordInexist()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub GridListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Dim row As DataGridViewRow = GridListing.Rows(e.RowIndex)

        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM MEDICALREP WHERE SLSMNCD = '" & row.Cells(SalesManCode.Index).Value & "' And DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            txtSalesManCode.Text = rs.Fields("SLSMNCD").Value
            txtSalesManName.Text = rs.Fields("SLSMNNAME").Value
            chkIsActive.Checked = IIf(row.Cells(colStatus.Index).Value = "Active", True, False)
            dtStart.Value = rs.Fields("EffectivityStartDate").Value
            dtEnd.Value = rs.Fields("EffectivityEndDate").Value
            txtposition.Text = rs.Fields("PositionName").Value
            txtpositioncode.Text = rs.Fields("PositionCode").Value
            txtterritorycode.Text = rs.Fields("TerritoryCode").Value
            txtterritoryname.Text = rs.Fields("TerritoryName").Value
            cmbSalesManCode.SelectedItem = rs.Fields("SLSMNCD").Value
            MainTab.SelectTab(0)

            SetupButtons(False)
            Enabletext()
            Operation = ""
        End If
    End Sub

    Private Function ValidFields() As Boolean
        If txtSalesManCode.Text = "" Then
            Return False
        ElseIf txtSalesManName.Text = "" Then
            Return False
        Else
            Return True
        End If
    End Function


    Private Sub GridListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick

    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Filter()
    End Sub
    Private Sub Filter()
        Dim field As String
        Dim rs As New ADODB.Recordset
        If cmbfilter.Text <> "" Then
            If cmbfilter.Text = "Employee's Code" Then
                field = "SlSMNCD"
            ElseIf cmbfilter.Text = "MR Name" Then
                field = "SLSMNNAME"
            Else
                field = ""
            End If
            If cmbfilter.Text = "All" Then
                OpenListing()
                txtFilter.Text = ""
                Exit Sub
            End If
            GridRs.Close()
            GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            GridRs.Open("SELECT * FROM MEDICALREP WHERE " & field & " like '%" & txtFilter.Text & "%' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


            If GridRs.RecordCount > 0 Then
                GridListing.Rows.Clear()
                For i As Integer = 1 To GridRs.RecordCount
                    Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)

                    row.Cells(SalesManCode.Index).Value = GridRs.Fields("SLSMNCD").Value
                    row.Cells(SalesManName.Index).Value = GridRs.Fields("SLSMNNAME").Value
                    row.Cells(colEffectivityStartdate.Index).Value = GridRs.Fields("EFFECTIVITYSTARTDATE").Value
                    row.Cells(colEffectivityEnddate.Index).Value = GridRs.Fields("EFFECTIVITYENDDATE").Value
                    row.Cells(colStatus.Index).Value = IIf(GridRs.Fields("IsActive").Value = True, "Active", "Inactive")
                    GridRs.MoveNext()
                Next
                UnEnbletext2()
            End If
        End If
    End Sub

    Private Sub txtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtDescription_KeyPress(ByVal sender As System.Object, ByVal c As System.Windows.Forms.KeyPressEventArgs)
        c.KeyChar = UCase(c.KeyChar)
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then
            Filter()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        MainWindow.TabControl1.TabPages.Add(MainWindow.TabControl1.TabPages.Count)
        Dim mine As New UCAdministrationSalesMatrix
        mine.Width = Me.Width
        mine.Height = MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Height - 30
        MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Text = mine.Name
        MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Controls.Add(mine)
        MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Text = "Sales Matrix"
        MainWindow.TabControl1.SelectTab(MainWindow.TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub
    Public Shared Function GetSalesmansql(Optional ByVal SalesmanCode As String = "") As String
        Return "Select DLTFLG,SLSMNCD[SALEMANCODE],SLSMNNAME[SALESMAN NAME]  from MedicalRep where  DLTFLG =  0"
    End Function

    Public Shared Function GetSalesman() As String
        Return "SLSMNCD;"
    End Function

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim Manager As New frmProductManager
        Manager.PositionCode = txtposition.Text
        Manager.ShowDialog()
        txtposition.Text = Manager.PositionCode
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        On Error Resume Next
        Dim Manager As New frmViewPosition
        Manager.PositionCode = txtposition.Text
        Manager.ShowDialog()
        txtposition.Text = Manager.PositionCode
        txtpositioncode.Text = Manager.PositionCodes
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Dim TerritoryselectPosition As New frmViewStAreaCoverage
        TerritoryselectPosition.TerritoryCode = txtterritorycode.Text
        TerritoryselectPosition.ShowDialog()
        txtterritorycode.Text = TerritoryselectPosition.TerritoryCode
        txtterritoryname.Text = TerritoryselectPosition.TerritoryName
    End Sub

    Private Sub LoadSalesmanCode()
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT STACOVCD FROM STAreaCoverage WHERE DLTFLG = 0 ORDER BY STACOVCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            cmbSalesManCode.Items.Clear()
            For i As Integer = 1 To rs.RecordCount
                cmbSalesManCode.Items.Add(rs.Fields("STACOVCD").Value)
                rs.MoveNext()
            Next
        End If
    End Sub

    Private Sub cmbSalesManCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSalesManCode.SelectedIndexChanged
        txtSalesManCode.Text = ""

        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT STACOVCD FROM STAreaCoverage WHERE DLTFLG = 0  And STACOVCD = '" & cmbSalesManCode.Text & "' ORDER BY STACOVCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount <> 0 Then
            txtSalesManCode.Text = rs.Fields(0).Value
        End If
    End Sub
End Class

