Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.GlobalFunctionsModule


Public Class UCUserSchema
    Private Operation As String = "'"

    

    Private Sub SetupByOperation(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation

    End Sub

    Private Sub ClearSchemaGrid()
        dgSalesFlash.Rows.Clear()
        dgTransaction.Rows.Clear()
        dgAdmin.Rows.Clear()
        dgInquiry.Rows.Clear()
        dgListing.Rows.Clear()
        dgMDM.Rows.Clear()
        dgSAR.Rows.Clear()
        dgTransaction.Rows.Clear()
        dgutilities.Rows.Clear()
    End Sub

    Private Sub ClearItems()
        txtSchemaCode.Tag = -1
        txtSchemaCode.Text = ""
        txtSchemaName.Text = ""
    End Sub

    Private Function ValidFields() As Boolean
        If txtSchemaCode.Text = "" Then
            ShowInformation("Populate Code first", "Schema Code Missing")
            Return False
        ElseIf txtSchemaName.Text = "" Then
            ShowInformation("Populate Description first", "Schema Name Missing")
            Return False
        Else
            Return True
        End If
    End Function


    'Private Function rsUserSchema(Optional ByVal Filter As String = "") As ADODB.Recordset
    '    Dim rs As New ADODB.Recordset
    '    If Filter <> "" Then
    '        Filter = " AND " & Filter
    '    End If

    '    rs.Open("SELECT * FROM USERSCHEMA WHERE DLTFLG = 0" & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

    '    Return rs
    'End Function

    Private Sub SaveRecord()
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXECUTE [dbo].[USPUserSchema] @Action = 'ADD' , @SchemaID = '" & txtSchemaCode.Tag & "', @SchemaCD = '" & txtSchemaCode.Text & "', @SchemaName = '" & txtSchemaName.Text & "', @dltflg = 0, @isactive= 1   ")
        Exit Sub
ErrorHandler:
        ShowInformation(Err.Description, "Error")
        Err.Clear()
    End Sub

    Private Sub UpdateRecord()
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXECUTE [dbo].[USPUserSchema] @Action = 'UPDATE' , @SchemaID = " & txtSchemaCode.Tag & ", @SchemaCD = '" & txtSchemaCode.Text & "', @SchemaName = '" & txtSchemaName.Text & "', @dltflg = 0, @isactive= 1   ")
        Exit Sub
ErrorHandler:
        ShowInformation(Err.Description, "Error")
        Err.Clear()
    End Sub

    Private Sub DeleteRecord()
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXECUTE [dbo].[USPUserSchema] @Action = 'DELETE' , @SchemaID = " & txtSchemaCode.Tag & ", @dltflg = 1")
        Exit Sub
ErrorHandler:
        ShowInformation(Err.Description, "Error")
        Err.Clear()
    End Sub

    Private Sub ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click, btnEdit.Click, btnDelete.Click, btnSave.Click, btnClose.Click
        If sender Is btnAdd Then
            ClearItems()
            SetupByOperation(True)
            Operation = "Add"
        ElseIf sender Is btnEdit Then
            SetupByOperation(True)
            Operation = "Edit"
        ElseIf sender Is btnDelete Then
            If ValidFields() = True Then
                DeleteRecord()
                ClearItems()
                Operation = ""
                DeleteSuccess()
                PopulateListing(rsSchema)
            End If
        ElseIf sender Is btnSave Then
            If ValidFields() = True Then

                If Operation = "Add" Then
                    If RecordExist() = False Then
                        SaveRecord()
                        SaveTemplate()
                        Operation = "Add"
                        SetupByOperation(True)
                        ClearItems()
                        PopulateListing(rsSchema)
                        SaveSuccess()
                    Else
                        RecordExists()
                    End If
                ElseIf Operation = "Edit" Then
                    UpdateRecord()
                    UpdateTemplate()
                    Operation = "Add"
                    SetupByOperation(True)
                    ClearItems()
                    PopulateListing(rsSchema)
                    SaveSuccess()
                End If

            End If
        ElseIf sender Is btnClose Then
            On Error Resume Next
            Dim m_TabPage As TabPage = Me.Parent
            CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
            Me.Dispose()
        End If

    End Sub

    Private Function rsSchema(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT * FROM USERSCHEMA WHERE DLTFLG = 0" & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs
    End Function

    Private Sub PopulateListing(ByVal rs As ADODB.Recordset)
        dgListing.Rows.Clear()
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim row As DataGridViewRow = dgListing.Rows(dgListing.Rows.Add)
                row.Cells(colID.Index).Value = rs.Fields("SchemaID").Value
                row.Cells(colCode.Index).Value = rs.Fields("SchemaCd").Value
                row.Cells(colDescription.Index).Value = rs.Fields("SchemaName").Value
                rs.MoveNext()
            Next
        End If
    End Sub

    Private Sub UCUserSchema_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(dgSalesFlash)
        ApplyGridTheme(dgTransaction)
        ApplyGridTheme(dgSAR)
        ApplyGridTheme(dgMDM)
        ApplyGridTheme(dgAdmin)
        ApplyGridTheme(dgutilities)
        ApplyGridTheme(dgInquiry)
        ApplyGridTheme(dgListing)
        ClearItems()
        ClearSchemaGrid()
        SetupByOperation(True)
        Operation = "Add"
        PopulateListing(rsSchema)
        PopulateSchema()
    End Sub

    Private Sub PopulateSchemaByListing()
        Dim rs As New ADODB.Recordset

        rs = RsModules("ModuleName = 'Sales Flash' AND SchemaCD = '" & txtSchemaCode.Text & "' ")
        'for the sales flash
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim rows As DataGridViewRow = dgSalesFlash.Rows(dgSalesFlash.Rows.Add)
                rows.Cells(col1SubModuleName.Index).Value = rs.Fields("SubModuleName").Value
                rows.Cells(col1FileName.Index).Value = rs.Fields("SubModuleFormName").Value
                rows.Cells(col1ModuleName.Index).Value = rs.Fields("ModuleName").Value
                rows.Cells(Col1ModuleID.Index).Value = rs.Fields("ModuleID").Value
                'If rs.Fields("Enabled").Value = 1 Then
                'rows.Cells(col1Enable.Index).Value = True
                'Else
                'rows.Cells(col1Enable.Index).Value = False
                'End If

                rows.Cells(col1Enable.Index).Value = rs.Fields("Enabled").Value
                rs.MoveNext()
            Next
        End If

        rs = RsModules("ModuleName = 'Transaction' AND SchemaCD = '" & txtSchemaCode.Text & "' ")
        'for the transaction
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim rows As DataGridViewRow = dgTransaction.Rows(dgTransaction.Rows.Add)
                rows.Cells(col2submodulename.Index).Value = rs.Fields("SubModuleName").Value
                rows.Cells(col2filename.Index).Value = rs.Fields("SubModuleFormName").Value
                rows.Cells(col2modulename.Index).Value = rs.Fields("ModuleName").Value
                rows.Cells(col2moduleid.Index).Value = rs.Fields("ModuleID").Value
                'If rs.Fields("Enabled").Value = 1 Then
                '    rows.Cells(col2Enable.Index).Value = True
                'Else
                '    rows.Cells(col2Enable.Index).Value = False
                'End If
                rows.Cells(col2Enable.Index).Value = rs.Fields("Enabled").Value
                rs.MoveNext()
            Next
        End If

        rs = RsModules("ModuleName = 'Sales Analysis Reports' AND SchemaCD = '" & txtSchemaCode.Text & "' ")
        'for the Sales Analysis Reports
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim rows As DataGridViewRow = dgSAR.Rows(dgSAR.Rows.Add)
                rows.Cells(col3submodulename.Index).Value = rs.Fields("SubModuleName").Value
                rows.Cells(col3filename.Index).Value = rs.Fields("SubModuleFormName").Value
                rows.Cells(col3modulename.Index).Value = rs.Fields("ModuleName").Value
                rows.Cells(col3moduleid.Index).Value = rs.Fields("ModuleID").Value
                'If rs.Fields("Enabled").Value = 1 Then
                '    rows.Cells(col3Enable.Index).Value = True
                'Else
                '    rows.Cells(col3Enable.Index).Value = False
                'End If
                rows.Cells(col3Enable.Index).Value = rs.Fields("Enabled").Value
                rs.MoveNext()
            Next
        End If


        rs = RsModules("ModuleName = 'Master Data Maintenance'  AND SchemaCD = '" & txtSchemaCode.Text & "' ")
        'for the Master Data Maintenance
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim rows As DataGridViewRow = dgMDM.Rows(dgMDM.Rows.Add)
                rows.Cells(col4submodulename.Index).Value = rs.Fields("SubModuleName").Value
                rows.Cells(col4filename.Index).Value = rs.Fields("SubModuleFormName").Value
                rows.Cells(col4modulename.Index).Value = rs.Fields("ModuleName").Value
                rows.Cells(col4moduleid.Index).Value = rs.Fields("ModuleID").Value
                'If rs.Fields("Enabled").Value = 1 Then
                '    rows.Cells(col4Enable.Index).Value = True
                'Else
                '    rows.Cells(col4Enable.Index).Value = False
                'End If
                rows.Cells(col4Enable.Index).Value = rs.Fields("Enabled").Value
                rs.MoveNext()
            Next
        End If

        rs = RsModules("ModuleName = 'Administration' AND SchemaCD = '" & txtSchemaCode.Text & "' ")
        'for the Master Data Maintenance
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim rows As DataGridViewRow = dgAdmin.Rows(dgAdmin.Rows.Add)
                rows.Cells(col5submodulename.Index).Value = rs.Fields("SubModuleName").Value
                rows.Cells(col5filename.Index).Value = rs.Fields("SubModuleFormName").Value
                rows.Cells(col5modulename.Index).Value = rs.Fields("ModuleName").Value
                rows.Cells(col5moduleid.Index).Value = rs.Fields("ModuleID").Value
                'If rs.Fields("Enabled").Value = 1 Then
                '    rows.Cells(col5enable.Index).Value = True
                'Else
                '    rows.Cells(col5enable.Index).Value = False
                'End If
                rows.Cells(col5enable.Index).Value = rs.Fields("Enabled").Value
                rs.MoveNext()
            Next
        End If


        rs = RsModules("ModuleName = 'Utilities' AND SchemaCD = '" & txtSchemaCode.Text & "' ")
        'for the Utilities
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim rows As DataGridViewRow = dgutilities.Rows(dgutilities.Rows.Add)
                rows.Cells(col6submodulename.Index).Value = rs.Fields("SubModuleName").Value
                rows.Cells(col6filename.Index).Value = rs.Fields("SubModuleFormName").Value
                rows.Cells(col6modulename.Index).Value = rs.Fields("ModuleName").Value
                rows.Cells(col6moduleid.Index).Value = rs.Fields("ModuleID").Value
                'If rs.Fields("Enabled").Value = 1 Then
                '    rows.Cells(col6enable.Index).Value = True
                'Else
                '    rows.Cells(col6enable.Index).Value = False
                'End If
                rows.Cells(col6enable.Index).Value = rs.Fields("Enabled").Value
                rs.MoveNext()
            Next
        End If



        rs = RsModules("ModuleName = 'Inquiry' AND SchemaCD = '" & txtSchemaCode.Text & "' ")
        'for the Inquiry
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim rows As DataGridViewRow = dgInquiry.Rows(dgInquiry.Rows.Add)
                rows.Cells(col7submodulename.Index).Value = rs.Fields("SubModuleName").Value
                rows.Cells(col7filename.Index).Value = rs.Fields("SubModuleFormName").Value
                rows.Cells(col7modulename.Index).Value = rs.Fields("ModuleName").Value
                rows.Cells(col7moduleid.Index).Value = rs.Fields("ModuleID").Value
                rows.Cells(col7enable.Index).Value = rs.Fields("Enabled").Value
                rs.MoveNext()
            Next
        End If
    End Sub


    Private Sub PopulateSchema()
        Dim rs As New ADODB.Recordset


        rs = rsModuleTemplate("ModuleName = 'Sales Flash' ")
        'for the sales flash
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim rows As DataGridViewRow = dgSalesFlash.Rows(dgSalesFlash.Rows.Add)
                rows.Cells(col1SubModuleName.Index).Value = rs.Fields("SubModuleName").Value
                rows.Cells(col1FileName.Index).Value = rs.Fields("SubModuleFormName").Value
                rows.Cells(col1ModuleName.Index).Value = rs.Fields("ModuleName").Value
                rows.Cells(Col1ModuleID.Index).Value = -1 'rs.Fields("ModuleID").Value
                rows.Cells(col1Enable.Index).Value = True
                rs.MoveNext()
            Next
        End If

        rs = rsModuleTemplate("ModuleName = 'Transaction'")
        'for the transaction
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim rows As DataGridViewRow = dgTransaction.Rows(dgTransaction.Rows.Add)
                rows.Cells(col2submodulename.Index).Value = rs.Fields("SubModuleName").Value
                rows.Cells(col2filename.Index).Value = rs.Fields("SubModuleFormName").Value
                rows.Cells(col2modulename.Index).Value = rs.Fields("ModuleName").Value
                rows.Cells(col2moduleid.Index).Value = -1 'rs.Fields("ModuleID").Value
                rows.Cells(col2Enable.Index).Value = True
                rs.MoveNext()
            Next
        End If

        rs = rsModuleTemplate("ModuleName = 'Sales Analysis Reports'")
        'for the Sales Analysis Reports
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim rows As DataGridViewRow = dgSAR.Rows(dgSAR.Rows.Add)
                rows.Cells(col3submodulename.Index).Value = rs.Fields("SubModuleName").Value
                rows.Cells(col3filename.Index).Value = rs.Fields("SubModuleFormName").Value
                rows.Cells(col3modulename.Index).Value = rs.Fields("ModuleName").Value
                rows.Cells(col3moduleid.Index).Value = -1 'rs.Fields("ModuleID").Value
                rows.Cells(col3Enable.Index).Value = True
                rs.MoveNext()
            Next
        End If


        rs = rsModuleTemplate("ModuleName = 'Master Data Maintenance'")
        'for the Master Data Maintenance
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim rows As DataGridViewRow = dgMDM.Rows(dgMDM.Rows.Add)
                rows.Cells(col4submodulename.Index).Value = rs.Fields("SubModuleName").Value
                rows.Cells(col4filename.Index).Value = rs.Fields("SubModuleFormName").Value
                rows.Cells(col4modulename.Index).Value = rs.Fields("ModuleName").Value
                rows.Cells(col4moduleid.Index).Value = -1 'rs.Fields("ModuleID").Value
                rows.Cells(col4Enable.Index).Value = True
                rs.MoveNext()
            Next
        End If

        rs = rsModuleTemplate("ModuleName = 'Administration'")
        'for the Master Data Maintenance
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim rows As DataGridViewRow = dgAdmin.Rows(dgAdmin.Rows.Add)
                rows.Cells(col5submodulename.Index).Value = rs.Fields("SubModuleName").Value
                rows.Cells(col5filename.Index).Value = rs.Fields("SubModuleFormName").Value
                rows.Cells(col5modulename.Index).Value = rs.Fields("ModuleName").Value
                rows.Cells(col5moduleid.Index).Value = -1 'rs.Fields("ModuleID").Value
                rows.Cells(col5enable.Index).Value = True
                rs.MoveNext()
            Next
        End If


        rs = rsModuleTemplate("ModuleName = 'Utilities'")
        'for the Utilities
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim rows As DataGridViewRow = dgutilities.Rows(dgutilities.Rows.Add)
                rows.Cells(col6submodulename.Index).Value = rs.Fields("SubModuleName").Value
                rows.Cells(col6filename.Index).Value = rs.Fields("SubModuleFormName").Value
                rows.Cells(col6modulename.Index).Value = rs.Fields("ModuleName").Value
                rows.Cells(col6moduleid.Index).Value = -1 'rs.Fields("ModuleID").Value
                rows.Cells(col6enable.Index).Value = True
                rs.MoveNext()
            Next
        End If



        rs = rsModuleTemplate("ModuleName = 'Inquiry'")
        'for the Inquiry
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim rows As DataGridViewRow = dgInquiry.Rows(dgInquiry.Rows.Add)
                rows.Cells(col7submodulename.Index).Value = rs.Fields("SubModuleName").Value
                rows.Cells(col7filename.Index).Value = rs.Fields("SubModuleFormName").Value
                rows.Cells(col7modulename.Index).Value = rs.Fields("ModuleName").Value
                rows.Cells(col7moduleid.Index).Value = -1 'rs.Fields("ModuleID").Value
                rows.Cells(col7enable.Index).Value = True
                rs.MoveNext()
            Next
        End If
    End Sub

    Private Sub Filter()
        Dim rs As New ADODB.Recordset
        If cmbfilter.Text = "" Then
        ElseIf cmbfilter.Text = "SchemaCode" Then
            rs = rsSchema("SchemaCd like '%" & txtFilter.Text & "%' ")
        ElseIf cmbfilter.Text = "SchemaName" Then
            rs = rsSchema("SchemaNmae like '%" & txtFilter.Text & "%' ")
        End If
        PopulateListing(rs)
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If AscW(e.KeyChar) = 13 Then
            Filter()
        End If
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Filter()
    End Sub

    Private Sub dgListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgListing.CellContentClick

    End Sub

    Private Sub dgListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgListing.CellDoubleClick
        Dim rs As New ADODB.Recordset
        If e.RowIndex > -1 Then
            ClearItems()
            Operation = ""
            SetupByOperation(False)
            Dim row As DataGridViewRow = dgListing.Rows(e.RowIndex)

            txtSchemaCode.Tag = row.Cells(colID.Index).Value
            txtSchemaCode.Text = row.Cells(colCode.Index).Value
            txtSchemaName.Text = row.Cells(colDescription.Index).Value


            ClearSchemaGrid()
            PopulateSchemaByListing()

            MainTab.SelectTab(0)



        End If
    End Sub

    Private Function rsModuleTemplate(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset

        If Filter <> "" Then
            Filter = " WHERE " & Filter
        End If
        rs.Open("SELECT * FROM SUBMODULETEMPLATE" & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs

    End Function

    Private Sub SaveTemplate()
        'for the salesflash
        If dgSalesFlash.Rows.Count > 0 Then
            For i As Integer = 0 To dgSalesFlash.Rows.Count - 1
                Dim row As DataGridViewRow = dgSalesFlash.Rows(i)
                If row.Cells(col1Enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'ADD', @MODULEID = " & row.Cells(Col1ModuleID.Index).Value & ", @MODULENAME = '" & row.Cells(col1ModuleName.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col1FileName.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "' , @SUBMODULENAME = '" & row.Cells(col1SubModuleName.Index).Value & "'  ")


                    'SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'ADD', @MODULEID = " & row.Cells(Col1ModuleID.Index).Value & ", @MODULENAME = '" & row.Cells(col1ModuleName.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col1FileName.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "', @SUBMODULENAME = '" & row.Cells(col1SubModuleName.Index).Value & "'  ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'ADD', @MODULEID = " & row.Cells(Col1ModuleID.Index).Value & ", @MODULENAME = '" & row.Cells(col1ModuleName.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col1FileName.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "' , @SUBMODULENAME = '" & row.Cells(col1SubModuleName.Index).Value & "'  ")
                End If
            Next
        End If


        'for the transaction
        If dgTransaction.Rows.Count > 0 Then
            For i As Integer = 0 To dgTransaction.Rows.Count - 1
                Dim row As DataGridViewRow = dgTransaction.Rows(i)
                If row.Cells(col2Enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'ADD', @MODULEID = " & row.Cells(col2moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col2modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col2filename.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "' , @SUBMODULENAME = '" & row.Cells(col2submodulename.Index).Value & "'  ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'ADD', @MODULEID = " & row.Cells(col2moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col2modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col2filename.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "' , @SUBMODULENAME = '" & row.Cells(col2submodulename.Index).Value & "'  ")
                End If
            Next
        End If

        'for the Sales Analysis Reports
        If dgSAR.Rows.Count > 0 Then
            For i As Integer = 0 To dgSAR.Rows.Count - 1
                Dim row As DataGridViewRow = dgSAR.Rows(i)
                If row.Cells(col3Enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'ADD', @MODULEID = " & row.Cells(col3moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col3modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col3filename.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "' , @SUBMODULENAME = '" & row.Cells(col3submodulename.Index).Value & "'  ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'ADD', @MODULEID = " & row.Cells(col3moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col3modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col3filename.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "' , @SUBMODULENAME = '" & row.Cells(col3submodulename.Index).Value & "'  ")
                End If
            Next
        End If


        'for the Master Data Maintenance
        If dgMDM.Rows.Count > 0 Then
            For i As Integer = 0 To dgMDM.Rows.Count - 1
                Dim row As DataGridViewRow = dgMDM.Rows(i)
                If row.Cells(col4Enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'ADD', @MODULEID = " & row.Cells(col4moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col4modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col4filename.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "'  , @SUBMODULENAME = '" & row.Cells(col4submodulename.Index).Value & "'  ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'ADD', @MODULEID = " & row.Cells(col4moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col4modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col4filename.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "'  , @SUBMODULENAME = '" & row.Cells(col4submodulename.Index).Value & "'  ")
                End If
            Next
        End If


        'for the Administration
        If dgAdmin.Rows.Count > 0 Then
            For i As Integer = 0 To dgAdmin.Rows.Count - 1
                Dim row As DataGridViewRow = dgAdmin.Rows(i)
                If row.Cells(col5enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'ADD', @MODULEID = " & row.Cells(col5moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col5modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col5filename.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "' , @SUBMODULENAME = '" & row.Cells(col5submodulename.Index).Value & "'   ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'ADD', @MODULEID = " & row.Cells(col5moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col5modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col5filename.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "'  , @SUBMODULENAME = '" & row.Cells(col5submodulename.Index).Value & "'  ")
                End If
            Next
        End If


        'for the Utilities
        If dgutilities.Rows.Count > 0 Then
            For i As Integer = 0 To dgutilities.Rows.Count - 1
                Dim row As DataGridViewRow = dgutilities.Rows(i)
                If row.Cells(col6enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'ADD', @MODULEID = " & row.Cells(col6moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col6modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col6filename.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "' , @SUBMODULENAME = '" & row.Cells(col6submodulename.Index).Value & "'   ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'ADD', @MODULEID = " & row.Cells(col6moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col6modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col6filename.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "' , @SUBMODULENAME = '" & row.Cells(col6submodulename.Index).Value & "'   ")
                End If
            Next
        End If

        'for the inquiry
        If dgInquiry.Rows.Count > 0 Then
            For i As Integer = 0 To dgInquiry.Rows.Count - 1
                Dim row As DataGridViewRow = dgInquiry.Rows(i)
                If row.Cells(col7enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'ADD', @MODULEID = " & row.Cells(col7moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col7modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col7filename.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "'  , @SUBMODULENAME = '" & row.Cells(col7submodulename.Index).Value & "'  ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'ADD', @MODULEID = " & row.Cells(col7moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col7modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col7filename.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "'  , @SUBMODULENAME = '" & row.Cells(col7submodulename.Index).Value & "'  ")
                End If
            Next
        End If

    End Sub



    Private Sub UpdateTemplate()
        'for the salesflash
        If dgSalesFlash.Rows.Count > 0 Then
            For i As Integer = 0 To dgSalesFlash.Rows.Count - 1
                Dim row As DataGridViewRow = dgSalesFlash.Rows(i)
                If row.Cells(col1Enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'UPDATE', @MODULEID = " & row.Cells(Col1ModuleID.Index).Value & ", @MODULENAME = '" & row.Cells(col1ModuleName.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col1FileName.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "' , @SUBMODULENAME = '" & row.Cells(col1SubModuleName.Index).Value & "'  ")


                    'SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'UPDATE', @MODULEID = " & row.Cells(Col1ModuleID.Index).Value & ", @MODULENAME = '" & row.Cells(col1ModuleName.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col1FileName.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "', @SUBMODULENAME = '" & row.Cells(col1SubModuleName.Index).Value & "'  ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'UPDATE', @MODULEID = " & row.Cells(Col1ModuleID.Index).Value & ", @MODULENAME = '" & row.Cells(col1ModuleName.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col1FileName.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "' , @SUBMODULENAME = '" & row.Cells(col1SubModuleName.Index).Value & "'  ")
                End If
            Next
        End If


        'for the transaction
        If dgTransaction.Rows.Count > 0 Then
            For i As Integer = 0 To dgTransaction.Rows.Count - 1
                Dim row As DataGridViewRow = dgTransaction.Rows(i)
                If row.Cells(col2Enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'UPDATE', @MODULEID = " & row.Cells(col2moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col2modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col2filename.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "' , @SUBMODULENAME = '" & row.Cells(col2submodulename.Index).Value & "'  ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'UPDATE', @MODULEID = " & row.Cells(col2moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col2modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col2filename.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "' , @SUBMODULENAME = '" & row.Cells(col2submodulename.Index).Value & "'  ")
                End If
            Next
        End If

        'for the Sales Analysis Reports
        If dgSAR.Rows.Count > 0 Then
            For i As Integer = 0 To dgSAR.Rows.Count - 1
                Dim row As DataGridViewRow = dgSAR.Rows(i)
                If row.Cells(col3Enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'UPDATE', @MODULEID = " & row.Cells(col3moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col3modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col3filename.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "' , @SUBMODULENAME = '" & row.Cells(col3submodulename.Index).Value & "'  ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'UPDATE', @MODULEID = " & row.Cells(col3moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col3modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col3filename.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "' , @SUBMODULENAME = '" & row.Cells(col3submodulename.Index).Value & "'  ")
                End If
            Next
        End If


        'for the Master Data Maintenance
        If dgMDM.Rows.Count > 0 Then
            For i As Integer = 0 To dgMDM.Rows.Count - 1
                Dim row As DataGridViewRow = dgMDM.Rows(i)
                If row.Cells(col4Enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'UPDATE', @MODULEID = " & row.Cells(col4moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col4modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col4filename.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "'  , @SUBMODULENAME = '" & row.Cells(col4submodulename.Index).Value & "'  ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'UPDATE', @MODULEID = " & row.Cells(col4moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col4modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col4filename.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "'  , @SUBMODULENAME = '" & row.Cells(col4submodulename.Index).Value & "'  ")
                End If
            Next
        End If


        'for the Administration
        If dgAdmin.Rows.Count > 0 Then
            For i As Integer = 0 To dgAdmin.Rows.Count - 1
                Dim row As DataGridViewRow = dgAdmin.Rows(i)
                If row.Cells(col5enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'UPDATE', @MODULEID = " & row.Cells(col5moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col5modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col5filename.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "' , @SUBMODULENAME = '" & row.Cells(col5submodulename.Index).Value & "'   ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'UPDATE', @MODULEID = " & row.Cells(col5moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col5modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col5filename.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "'  , @SUBMODULENAME = '" & row.Cells(col5submodulename.Index).Value & "'  ")
                End If
            Next
        End If


        'for the Utilities
        If dgutilities.Rows.Count > 0 Then
            For i As Integer = 0 To dgutilities.Rows.Count - 1
                Dim row As DataGridViewRow = dgutilities.Rows(i)
                If row.Cells(col6enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'UPDATE', @MODULEID = " & row.Cells(col6moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col6modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col6filename.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "' , @SUBMODULENAME = '" & row.Cells(col6submodulename.Index).Value & "'   ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'UPDATE', @MODULEID = " & row.Cells(col6moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col6modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col6filename.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "' , @SUBMODULENAME = '" & row.Cells(col6submodulename.Index).Value & "'   ")
                End If
            Next
        End If

        'for the inquiry
        If dgInquiry.Rows.Count > 0 Then
            For i As Integer = 0 To dgInquiry.Rows.Count - 1
                Dim row As DataGridViewRow = dgInquiry.Rows(i)
                If row.Cells(col7enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'UPDATE', @MODULEID = " & row.Cells(col7moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col7modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col7filename.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "'  , @SUBMODULENAME = '" & row.Cells(col7submodulename.Index).Value & "'  ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'UPDATE', @MODULEID = " & row.Cells(col7moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col7modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col7filename.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "'  , @SUBMODULENAME = '" & row.Cells(col7submodulename.Index).Value & "'  ")
                End If
            Next
        End If

    End Sub




    Private Sub DeleteTemplate()
        'for the salesflash
        If dgSalesFlash.Rows.Count > 0 Then
            For i As Integer = 0 To dgSalesFlash.Rows.Count - 1
                Dim row As DataGridViewRow = dgSalesFlash.Rows(i)
                If row.Cells(col1Enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'DELETE', @MODULEID = " & row.Cells(Col1ModuleID.Index).Value & ", @MODULENAME = '" & row.Cells(col1ModuleName.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col1FileName.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "' ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'DELETE', @MODULEID = " & row.Cells(Col1ModuleID.Index).Value & ", @MODULENAME = '" & row.Cells(col1ModuleName.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col1FileName.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "' ")
                End If
            Next
        End If


        'for the transaction
        If dgTransaction.Rows.Count > 0 Then
            For i As Integer = 0 To dgTransaction.Rows.Count - 1
                Dim row As DataGridViewRow = dgTransaction.Rows(i)
                If row.Cells(col2Enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'DELETE', @MODULEID = " & row.Cells(col2moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col2modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col2filename.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "' ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'DELETE', @MODULEID = " & row.Cells(col2moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col2modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col2filename.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "' ")
                End If
            Next
        End If

        'for the Sales Analysis Reports
        If dgSAR.Rows.Count > 0 Then
            For i As Integer = 0 To dgSAR.Rows.Count - 1
                Dim row As DataGridViewRow = dgSAR.Rows(i)
                If row.Cells(col3Enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'DELETE', @MODULEID = " & row.Cells(col3moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col3modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col3filename.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "' ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'DELETE', @MODULEID = " & row.Cells(col3moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col3modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col3filename.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "' ")
                End If
            Next
        End If


        'for the Master Data Maintenance
        If dgMDM.Rows.Count > 0 Then
            For i As Integer = 0 To dgMDM.Rows.Count - 1
                Dim row As DataGridViewRow = dgMDM.Rows(i)
                If row.Cells(col4Enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'DELETE', @MODULEID = " & row.Cells(col4moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col4modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col4filename.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "' ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'DELETE', @MODULEID = " & row.Cells(col4moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col4modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col4filename.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "' ")
                End If
            Next
        End If


        'for the Administration
        If dgAdmin.Rows.Count > 0 Then
            For i As Integer = 0 To dgAdmin.Rows.Count - 1
                Dim row As DataGridViewRow = dgAdmin.Rows(i)
                If row.Cells(col5enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'DELETE', @MODULEID = " & row.Cells(col5moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col5modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col5filename.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "' ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'DELETE', @MODULEID = " & row.Cells(col5moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col5modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col5filename.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "' ")
                End If
            Next
        End If


        'for the Utilities
        If dgutilities.Rows.Count > 0 Then
            For i As Integer = 0 To dgutilities.Rows.Count - 1
                Dim row As DataGridViewRow = dgutilities.Rows(i)
                If row.Cells(col6enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'DELETE', @MODULEID = " & row.Cells(col6moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col6modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col6filename.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "' ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'DELETE', @MODULEID = " & row.Cells(col6moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col6modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col6filename.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "' ")
                End If
            Next
        End If

        'for the inquiry
        If dgInquiry.Rows.Count > 0 Then
            For i As Integer = 0 To dgInquiry.Rows.Count - 1
                Dim row As DataGridViewRow = dgInquiry.Rows(i)
                If row.Cells(col7enable.Index).Value = True Then
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'DELETE', @MODULEID = " & row.Cells(col7moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col7modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col7filename.Index).Value & "' , @ENABLED = 1, @SCHEMACD = '" & txtSchemaCode.Text & "' ")
                Else
                    SPMSConn.Execute("EXECUTE USPPROJECTSUBMODULES @ACTION = 'DELETE', @MODULEID = " & row.Cells(col7moduleid.Index).Value & ", @MODULENAME = '" & row.Cells(col7modulename.Index).Value & "',  @SUBMODULEFORMNAME = '" & row.Cells(col7filename.Index).Value & "' , @ENABLED = 0, @SCHEMACD = '" & txtSchemaCode.Text & "' ")
                End If
            Next
        End If

    End Sub

    Private Function RecordExist() As Boolean
        Dim rs As New ADODB.Recordset

        rs = RsModules("SchemaCD = '" & txtSchemaCode.Text & "' ")
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
End Class


