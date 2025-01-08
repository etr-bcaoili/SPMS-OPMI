Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class ucMasterCustomerClass
    Private Operation As String = "'"
    Private Gridrs As New ADODB.Recordset


    Private Sub ClearForm()
        cmbCustomerGroup.Text = ""
        txtCustomerGroupName.Text = ""
        txtFilter.Text = ""
        txtCustomerClassCode.Text = ""
        txtCustomerClassDescription.Text = ""
    End Sub

    Private Sub SetupOperation(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation
    End Sub
    Private Sub EnableText()
        txtCustomerGroupName.ReadOnly = True
        txtCustomerClassCode.ReadOnly = True
        txtCustomerClassDescription.ReadOnly = True
    End Sub
    Private Sub UnEnableText()
        txtCustomerGroupName.ReadOnly = True
        txtCustomerClassCode.ReadOnly = False
        txtCustomerClassDescription.ReadOnly = False
    End Sub
    Private Sub UnEnabletextAdd()
        txtCustomerGroupName.ReadOnly = False
        txtCustomerClassCode.ReadOnly = False
        txtCustomerClassDescription.ReadOnly = False
    End Sub
    Private Function CheckRecordExists(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM CUSTOMERCLASS WHERE DLTFLG = 0 AND CUSTOMERCLASSCD = '" & Code & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function ValidFields() As Boolean
        If txtCustomerClassCode.Text = "" Then
            Return False
        ElseIf txtCustomerClassDescription.Text = "" Then
            Return False
        ElseIf cmbCustomerGroup.Text = "" Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub OpenListing()
        If Gridrs.State = 1 Then Gridrs.Close()
        Gridrs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Gridrs.Open("SELECT * FROM CUSTOMERCLASS WHERE DLTFLG = 0 ORDER BY CUSTOMERCLASSCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        GridListing.Rows.Clear()
        If Gridrs.RecordCount > 0 Then

            For i As Integer = 1 To Gridrs.RecordCount

                Dim rsCustomerGroup As New ADODB.Recordset
                If rsCustomerGroup.State = 1 Then rsCustomerGroup.Close()
                rsCustomerGroup.Open("Select CustomerGroupName From CustomerGroup Where CustomerGroupCD = '" & Gridrs.Fields("CUSTOMERGROUPCD").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(ColClassCode.Index).Value = Gridrs.Fields("CUSTOMERCLASSCD").Value
                row.Cells(CustomerGroupName.Index).Value = rsCustomerGroup.Fields("CUSTOMERGROUPNAME").Value
                row.Cells(colClassName.Index).Value = Gridrs.Fields("CUSTOMERCLASSNAME").Value
                row.Cells(ColCustomerGroup.Index).Value = Gridrs.Fields("CUSTOMERGROUPCD").Value
                row.Cells(colEffectivityStartDate.Index).Value = CDate(Gridrs.Fields("EFFECTIVITYSTARTDATE").Value).ToShortDateString
                row.Cells(colEffectivityEndDate.Index).Value = CDate(Gridrs.Fields("EFFECTIVITYENDDATE").Value).ToShortDateString
                Gridrs.MoveNext()
            Next
        End If

        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT DISTINCT CUSTOMERGROUPCD,CUSTOMERGROUPNAME FROM CUSTOMERGROUP WHERE DLTFLG = 0 ORDER BY CUSTOMERGROUPCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            cmbCustomerGroup.Items.Clear()
            For i As Integer = 1 To rs.RecordCount
                cmbCustomerGroup.Items.Add(rs.Fields("CUSTOMERGROUPCD").Value)
                rs.MoveNext()
            Next
        End If
    End Sub

    Private Function SaveRecord(ByVal Code As String, ByVal Description As String, ByVal Group As String, ByVal EffectivityEndDate As Date, ByVal EffectivityStartdate As Date) As Boolean
        SPMSConn.Execute("EXEC uspCustomerClass @Action = 'ADD', @DLTFLG= 0, @CUSTOMERGROUPCD = '" & Group & "', @CUSTOMERCLASSCD = '" & Code & "', @CUSTOMERCLASSNAME = '" & Description & "', @CRTDATE = '" & Now & "', @CRTU = '',@EFFECTIVITYSTARTDATE = '" & EffectivityStartdate & "',@EFFECTIVITYENDDATE = '" & EffectivityEndDate & "'")
    End Function

    Private Function UpdateRecord(ByVal Code As String, ByVal Description As String, ByVal Group As String, ByVal EffectivityEndDate As Date, ByVal EffectivityStartdate As Date) As Boolean
        SPMSConn.Execute("EXEC uspCustomerClass @Action = 'UPDATE', @DLTFLG= 0, @CUSTOMERGROUPCD = '" & Group & "', @CUSTOMERCLASSCD = '" & Code & "', @CUSTOMERCLASSNAME = '" & Description & "', @CRTDATE = '" & Now & "', @CRTU = '',,@EFFECTIVITYSTARTDATE = '" & EffectivityStartdate & "',@EFFECTIVITYENDDATE = '" & EffectivityEndDate & "' ")
    End Function

    Private Function DeleteRecord(ByVal Code As String, ByVal Description As String, ByVal Group As String) As Boolean
        SPMSConn.Execute("EXEC uspCustomerClass @Action = 'UPDATE', @DLTFLG= 1, @CUSTOMERGROUPCD = '" & Group & "', @CUSTOMERCLASSCD = '" & Code & "', @CUSTOMERCLASSNAME = '" & Description & "', @CRTDATE = '" & Now & "', @CRTU = '' ")
    End Function
    Private Sub Filter()
        Dim field As String = ""

        If cmbfilter.Text = "CustomerGroupCode" Then
            field = "CUSTOMERGROUPCD"
        ElseIf cmbfilter.Text = "CustomerClassCode" Then
            field = "CUSTOMERCLASSCD"
        ElseIf cmbfilter.Text = "CustomerClassName" Then
            field = "CUSTOMERCLASSNAME"
        Else
            txtFilter.Text = ""
            OpenListing()
        End If
        If field <> "" Then

            If Gridrs.State = 1 Then Gridrs.Close()
            Gridrs.Open("SELECT * FROM CUSTOMERCLASS WHERE DLTFLG = 0 AND " & field & " LIKE '%" & txtFilter.Text & "%' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            GridListing.Rows.Clear()
            If Gridrs.RecordCount > 0 Then
                For i As Integer = 1 To Gridrs.RecordCount
                    Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                    Dim rsCustomerGroup As New ADODB.Recordset
                    If rsCustomerGroup.State = 1 Then rsCustomerGroup.Close()
                    rsCustomerGroup.Open("Select CustomerGroupName From CustomerGroup Where CustomerGroupCD = '" & Gridrs.Fields("CUSTOMERCLASSCD").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    row.Cells(ColClassCode.Index).Value = Gridrs.Fields("CUSTOMERCLASSCD").Value
                    row.Cells(CustomerGroupName.Index).Value = rsCustomerGroup.Fields("CUSTOMERGROUPNAME").Value
                    row.Cells(colClassName.Index).Value = Gridrs.Fields("CUSTOMERCLASSNAME").Value
                    row.Cells(ColCustomerGroup.Index).Value = Gridrs.Fields("CUSTOMERGROUPCD").Value
                    row.Cells(colEffectivityStartDate.Index).Value = CDate(Gridrs.Fields("EFFECTIVITYSTARTDATE").Value).ToShortDateString
                    row.Cells(colEffectivityEndDate.Index).Value = CDate(Gridrs.Fields("EFFECTIVITYENDDATE").Value).ToShortDateString
                    Gridrs.MoveNext()
                Next
            End If
        End If
    End Sub
    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Filter()
    End Sub



    Private Sub ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click, btnEdit.Click, btnDelete.Click, btnSave.Click, btnClose.Click
        If sender Is btnAdd Then
            SetupOperation(True)
            Operation = "Add"
            cmbCustomerGroup.Focus()
            ClearForm()
            UnEnabletextAdd()
        ElseIf sender Is btnEdit Then
            SetupOperation(True)
            Operation = "Edit"
            UnEnableText()
            cmbCustomerGroup.Focus()
        ElseIf sender Is btnDelete Then
            If CheckRecordExists(txtCustomerClassCode.Text) = True Then
                If ValidFields() = True Then
                    SetupOperation(False)
                    Operation = ""
                    DeleteRecord(txtCustomerClassCode.Text, txtCustomerClassDescription.Text, cmbCustomerGroup.Text)
                    OpenListing()
                    DeleteSuccess()
                    ClearForm()
                End If
            End If
        ElseIf sender Is btnSave Then
            'If CheckRecordExists(txtCustomerClassCode.Text) = True Then
            If ValidFields() = True Then
                If Operation = "Add" Then
                    If CheckRecordExists(txtCustomerClassCode.Text) = False Then
                        SetupOperation(False)
                        Operation = ""
                        SaveRecord(txtCustomerClassCode.Text, txtCustomerClassDescription.Text, cmbCustomerGroup.Text, dtStart.Value, dtEnd.Value)
                        OpenListing()
                        SaveSuccess()
                        ClearForm()

                    Else
                        VDialog.Show("Record Already Exists", "Record Exists", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    End If
                ElseIf Operation = "Edit" Then
                    If CheckRecordExists(txtCustomerClassCode.Text) = True Then
                        SetupOperation(False)
                        Operation = ""
                        UpdateRecord(txtCustomerClassCode.Text, txtCustomerClassDescription.Text, cmbCustomerGroup.Text, dtStart.Value, dtEnd.Value)
                        OpenListing()
                        SaveSuccess()
                        ClearForm()
                    Else
                        VDialog.Show("Record Already Exists", "Record Exists", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    End If
                End If
            End If
            'End If
        ElseIf sender Is btnClose Then
            On Error Resume Next
            Dim m_TabPage As TabPage = Me.Parent
            CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
            Me.Dispose()
        End If


    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub MasterCustomerClass_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetupOperation(True)
        ApplyGridTheme(GridListing)
        Operation = "Add"
        cmbCustomerGroup.Focus()
        OpenListing()
    End Sub

    Private Sub GridListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick
        Dim rs As New ADODB.Recordset
        Dim row As DataGridViewRow = GridListing.Rows(e.RowIndex)
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM CUSTOMERCLASS WHERE DLTFLG = 0 AND CUSTOMERCLASSCD = '" & row.Cells(ColClassCode.Index).Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            txtCustomerClassCode.Text = rs.Fields("CUSTOMERCLASSCD").Value
            txtCustomerClassDescription.Text = rs.Fields("CUSTOMERCLASSNAME").Value
            cmbCustomerGroup.Text = rs.Fields("CUSTOMERGROUPCD").Value
            dtStart.Value = rs.Fields("EFFECTIVITYSTARTDATE").Value
            dtEnd.Value = rs.Fields("EFFECTIVITYENDDATE").Value
            EnableText()
            Operation = ""
            SetupOperation(False)
            cmbCustomerGroup.Focus()
        End If
        EnableText()
        MainTab.SelectTab(0)
    End Sub

    Private Sub txtCustomerClassCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtCustomerClassDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then
            Filter()
        End If

    End Sub

    Private Sub cmbCustomerGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerGroup.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT  CUSTOMERGROUPNAME FROM CUSTOMERGROUP WHERE CUSTOMERGROUPCD = '" & cmbCustomerGroup.Text & "' AND DLTFLG = 0 ORDER BY CUSTOMERGROUPCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            txtCustomerGroupName.Text = rs.Fields("CUSTOMERGROUPNAME").Value
        End If
    End Sub

    Private Sub cmbCustomerGroup_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerGroup.SelectedIndexChanged

    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub

    Private Sub GridListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick

    End Sub
End Class