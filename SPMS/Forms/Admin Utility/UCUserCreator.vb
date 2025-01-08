Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class UCUserCreator
    Private Operation As String = ""
    Private Function RsUserAccess(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT * FROM USERACCESS WHERE DLTFLG = 0" & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs
    End Function

    Private Function Rsprofile(Optional ByVal filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If filter <> "" Then
            filter = " AND " & filter
        End If

        rs.Open("SELECT * FROM USERSCHEMA WHERE DLTFLG = 0 " & filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs

    End Function

    Private Sub SetupByOperation(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation
    End Sub

    Private Sub ClearItems()
        cmbuser.Items.Clear()
        cmbProfileName.Items.Clear()
        txtUserName.Text = ""
        txtPassword.Text = ""
        cmbuser.Text = ""
        cmbProfileName.Text = ""
        txtUserName.Tag = -1

        PopulateBox()
    End Sub



    Private Sub PopulateBox()
        Dim rs As New ADODB.Recordset

        rs = Rsprofile()

        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbuser.Items.Add(rs.Fields("SchemaCd").Value)
                cmbProfileName.Items.Add(rs.Fields("SchemaName").Value)
                rs.MoveNext()
            Next
        End If
    End Sub


    Private Sub UCUserCreator_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ClearItems()
        ' PopulateBox()
        SetupByOperation(False)
        Operation = "Add"
        PopulateListing(RsUserAccess)
        ApplyGridTheme(dgListing)
        LockFields(True)
    End Sub


    Private Sub LockFields(ByVal IsLocked As Boolean)
        txtPassword.ReadOnly = IsLocked
        txtUserName.ReadOnly = IsLocked
        txtPassword.BackColor = Color.White
        txtUserName.BackColor = Color.White
        cmbProfileName.Enabled = Not IsLocked
        cmbuser.Enabled = Not IsLocked
    End Sub

    Private Sub Filter()
        Dim rs As New ADODB.Recordset

        If cmbfilter.Text = "" Then
        ElseIf cmbfilter.Text = "UserName" Then
            rs = RsUserAccess("UserName like '%" & txtFilter.Text & "%' ")
        ElseIf cmbfilter.Text = "UserProfile" Then
            rs = RsUserAccess("SchemaCD like '%" & txtFilter.Text & "%' ")
        End If

        PopulateListing(rs)
    End Sub

    Private Sub PopulateListing(ByVal rs As ADODB.Recordset)
        dgListing.Rows.Clear()
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim row As DataGridViewRow = dgListing.Rows(dgListing.Rows.Add)
                row.Cells(colID.Index).Value = rs.Fields("UserID").Value
                row.Cells(colUserName.Index).Value = rs.Fields("UserName").Value
                row.Cells(colSchema.Index).Value = rs.Fields("SchemaCD").Value
                row.Cells(colPass.Index).Value = rs.Fields("Password").Value
                rs.MoveNext()
            Next
        End If
    End Sub

    
    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If AscW(e.KeyChar) = 13 Then
            Filter()
        End If
    End Sub

    
    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Filter()
    End Sub

    

    Private Sub dgListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgListing.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim row As DataGridViewRow = dgListing.Rows(e.RowIndex)
            txtUserName.Tag = row.Cells(colID.Index).Value
            txtUserName.Text = row.Cells(colUserName.Index).Value
            txtPassword.Text = row.Cells(colPass.Index).Value
            cmbuser.Text = row.Cells(colSchema.Index).Value


            Operation = ""
            SetupByOperation(False)

            MainTab.SelectTab(0)
            LockFields(True)


        End If
    End Sub



    Private Sub cmbuser_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbuser.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
        rs = Rsprofile("SchemaCD = '" & cmbuser.Text & "' ")
        If rs.RecordCount > 0 Then
            cmbProfileName.Text = rs.Fields("SchemaName").Value
        End If
    End Sub

    Private Sub cmbProfileName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProfileName.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
        rs = Rsprofile("SchemaName = '" & cmbProfileName.Text & "' ")
        If rs.RecordCount > 0 Then
            cmbuser.Text = rs.Fields("SchemaCD").Value
        End If
    End Sub

    Private Sub ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click, btnEdit.Click, btnDelete.Click, btnSave.Click, btnClose.Click
        If sender Is btnAdd Then
            ClearItems()
            SetupByOperation(True)
            Operation = "Add"
            LockFields(False)
        ElseIf sender Is btnEdit Then
            SetupByOperation(True)
            Operation = "Edit"
            LockFields(False)
        ElseIf sender Is btnDelete Then
            If ValidFields() = True Then
                DeleteRecord()
                DeleteSuccess()
                ClearItems()
                Operation = "Add"
                SetupByOperation(False)
                PopulateListing(RsUserAccess)
                LockFields(True)
            End If
        ElseIf sender Is btnSave Then
            If ValidFields() = True Then
                If Operation = "Add" Then
                    SaveRecord()
                    ClearItems()
                    Operation = "Add"
                    SetupByOperation(False)
                    PopulateListing(RsUserAccess)
                    'LockFields(True)
                    SaveSuccess()

                ElseIf Operation = "Edit" Then
                    UpdateRecord()
                    ClearItems()
                    Operation = "Add"
                    SetupByOperation(False)
                    PopulateListing(RsUserAccess)
                    'LockFields(True)
                    SaveSuccess()
                End If
                LockFields(True)
            End If
        ElseIf sender Is btnClose Then
            On Error Resume Next
            Dim m_TabPage As TabPage = Me.Parent
            CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
            Me.Dispose()
        End If
    End Sub

    Private Function ValidFields() As Boolean
        If txtUserName.Text = "" Then
            ShowInformation("Populate UserName First", "UserName Empty")
            Return False
        ElseIf txtPassword.Text = "" Then
            ShowInformation("Can't Save Blank Password", "Password Empty")
            Return False
        ElseIf cmbuser.Text = "" Then
            ShowInformation("Select a Profile first", "No Profile Selected")
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub SaveRecord()
        SPMSConn.Execute("EXECUTE uspUSerAccess @ACTION = 'ADD', @USERNAME = '" & txtUserName.Text & "', @PASSWORD = '" & txtPassword.Text & "', @SCHEMACD = '" & cmbuser.Text & "', @DLTFLG = 0, @ISACTIVE = 0, @USERID = " & txtUserName.Tag & "  ")
    End Sub

    Private Sub UpdateRecord()
        SPMSConn.Execute("EXECUTE uspUSerAccess @ACTION = 'UPDATE', @USERNAME = '" & txtUserName.Text & "', @PASSWORD = '" & txtPassword.Text & "', @SCHEMACD = '" & cmbuser.Text & "', @DLTFLG = 0, @ISACTIVE = 0, @USERID = " & txtUserName.Tag & "    ")
    End Sub

    Private Sub DeleteRecord()
        SPMSConn.Execute("EXECUTE uspUSerAccess @ACTION = 'DELETE', @DLTFLG = 1, @USERID = " & txtUserName.Tag & "    ")
    End Sub



End Class
