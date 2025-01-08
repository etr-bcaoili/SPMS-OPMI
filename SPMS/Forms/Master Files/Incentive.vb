Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ucMasterRegion
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class Incentive
    Private GridRs As New ADODB.Recordset
    Private Operation As String
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_IsNewMode As Boolean = True
    Private m_Action As String = ""
    Private m_Recid As Integer = -1
    Private m_RsFilter As New ADODB.Recordset
    Private m_RsInncenForViewing As New ADODB.Recordset
    Private m_Desig As String = ""
    Private m_Perform As String = ""
    Private m_Incentive As New ADODB.Recordset

    Private Sub txtDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Public Property Performance() As String
        Get
            Return m_Perform
        End Get
        Set(ByVal value As String)
            m_Perform = value
        End Set
    End Property
    Public Property Designation() As String
        Get
            Return m_Desig
        End Get
        Set(ByVal value As String)
            m_Desig = value
        End Set
    End Property
    Private Sub Incentive_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If m_Desig <> "" Then
            m_Err.Clear()
            loaddeleted()
            LoadIncentiveToGrid()
            ApplyGridTheme(dgItemList)
            Dim n As Integer = 10000
            txtmontive.Text = n.ToString("#,###,###.00")
        Else
            LoadIncentiveToGrid()
            ApplyGridTheme(dgItemList)
            txtDesign.CharacterCasing = CharacterCasing.Upper
            loaddeleted()
        End If
    End Sub
    Private Sub Clear()
        txtDesign.Text = ""
        txtperf.Text = ""
        txtrange.Text = ""
        txtmontive.Text = ""
    End Sub
    Private Enum EnumAction
        ADD = 1
        UPDATE = 2
    End Enum

    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnAdd.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode
    End Sub
    Private Sub SetupbyOperation(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation
    End Sub
    Private Sub ClearForm()
        txtFilter.Text = ""
        txtperf.Text = ""
        txtDesign.Text = ""
        txtrange.Text = ""
    End Sub
    Private Function CheckRecordExists(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM Incentive WHERE IncenDesig = '" & Code & "' AND DELFLAG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        SetupbyOperation(True)
        Operation = "Add"
        Clear()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        SetupbyOperation(True)
        Operation = "Edit"
    End Sub
    Private Sub Filter()
        Dim field As String = ""
        Dim FilterField As String = ""
        If Selectioncbo.SelectedItem = "Performance" Then
            FilterField = "IncenPerf"
        ElseIf Selectioncbo.SelectedItem = "Designation" Then
            FilterField = "IncenDesig"
        Else
            FilterField = ""
        End If
        If Selectioncbo.Text = "All" Then
            LoadIncentiveToGrid()
            txtFilter.Text = ""
            Exit Sub
        End If
        If FilterField <> "" Then
            If m_RsFilter.State = 1 Then m_RsFilter.Close()
            m_RsFilter.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            m_RsFilter.Open("SELECT * FROM Incentive WHERE " & FilterField & " like '%" & txtFilter.Text & "%' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If m_RsFilter.RecordCount > 0 Then
                dgItemList.Rows.Clear()
                RefreshGrid(m_RsFilter)
            End If
        End If
    End Sub
    Private Function SaveRecord(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("EXEC USPIncentive @ACTION = 'ADD' ,@DELFLAG = 0, @IncenPerf = '" & txtperf.Text & "', @IncenDesig = '" & txtDesign.Text & "', @Incen_Range = '" & txtrange.Text & "', @Incen_PerMonth = '" & txtmontive.Text & "',@IsActive = " & chkIsActive.Checked & "  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return True
    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If CheckRecordExists(txtDesign.Text) = True Then
            DeleteRecord(txtperf.Text)
            VDialog.Show("Successfull Delete", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SetupbyOperation(False)
            Clear()
            Operation = ""
            LoadIncentiveToGrid()

        End If
    End Sub
    Private Sub loaddeleted()
        Dim rs As New ADODB.Recordset
        rs.Open("DELETE FROM Incentive WHERE RECID not in (SELECT MIN(RECID) FROM Incentive GROUP BY IncenPerf, IncenDesig, Incen_Range,Incen_PerMonth)", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Operation = "Add" Then
            If ValidateData() Then
                SaveRecord(txtDesign.Text)
                SetupbyOperation(False)
                Operation = ""
                LoadIncentiveToGrid()
                loaddeleted()
                VDialog.Show("Successfull new Incentive", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Clear()
            End If
        ElseIf Operation = "Edit" Then
            If ValidateData() Then
                If CheckRecordExists(txtDesign.Text) = True Then
                    UpdateRecord(txtperf.Text, txtDesign.Text, txtrange.Text)
                    SetupbyOperation(False)
                    Operation = ""
                    LoadIncentiveToGrid()
                    loaddeleted()
                    VDialog.Show("Successfull update Incentive", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Clear()
                End If
            End If
            End If
    End Sub
    Private Function UpdateRecord(ByVal Code As String, ByVal per As String, ByVal des As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("EXEC USPIncentive @ACTION = 'UPDATE', @DELFLAG = 0, @IncenPerf = '" & Code & "', @IncenDesig = '" & per & "', @Incen_Range = '" & des & "', @Incen_PerMonth = '" & txtmontive.Text & "' , @IsActive = " & chkIsActive.Checked & "  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return True
    End Function
    Private Function DeleteRecord(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("EXEC USPIncentive @ACTION = 'UPDATE', @DELFLAG = 1, @IncenPerf = '" & Code & "', @IncenDesig = '" & txtDesign.Text & "' , @IsActive = " & chkIsActive.Checked & " ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        rs.Open("Delete from Incentive where Delflag = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return True
    End Function
    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False


        If Not IsNumeric(txtperf.Text) Then
            m_Err.SetError(txtperf, "Please Number only.")
            m_HasError = True

        End If
        If txtperf.Text = "" Then
            m_Err.SetError(txtperf, "Performation is not required.")
            m_HasError = True
        End If
        If txtmontive.Text = "" Then
            m_Err.SetError(txtmontive, "Incentive is  not required")
            m_HasError = True
        End If
        If txtrange.Text = "" Then
            m_Err.SetError(txtrange, "Range is not required")
            m_HasError = True
        End If

        If txtperf.Text = "" Then
            m_Err.SetError(txtperf, "Performance is not required")
            m_HasError = True
        End If

            loaddeleted()
            Return Not m_HasError
    End Function
    Private Sub comfirmdata(ByVal test As String)
        m_Incentive = New ADODB.Recordset
        Dim q As MsgBoxResult
        m_Incentive.Open("Select *  from Incentive where  IncenPerf='" & txtperf.Text & "' AND IncenDesig= '" & txtDesign.Text & "' AND Incen_Range= '" & txtrange.Text & "' AND Delflag = 0", ConnectionModule.SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_Incentive.EOF = False Then
            q = MsgBox("Record Already Exist Do you want to countineu Delete Firts", vbQuestion + vbYesNo, "System Message")
            If q = vbYes Then
                loaddeleted()
            End If
        End If
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub LoadIncentiveToGrid()
        If m_RsInncenForViewing.State = 1 Then m_RsInncenForViewing.Close()
        m_RsInncenForViewing.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsInncenForViewing.Open("SELECT * FROM Incentive Where Delflag = 0 order by Incen_PerMonth ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgItemList.Rows.Clear()
        If m_RsInncenForViewing.RecordCount = 0 Then Exit Sub
        RefreshGrid(m_RsInncenForViewing)
    End Sub
    Private Sub Delete()
        If Not txtDesign.Text = "" Then
            Try
                SPMSConn.Execute("EXEC uspIncentive  @Action = 'DELETE' , @IncenDesig = '" & txtDesign.Text & "' , @Delflag = 1 ")
                ShowInformation("Record Sucessfully Deleted", "Delete")
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        Else
            VDialog.Show("There are no record to be deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    Private Sub RefreshGrid(ByVal rs As ADODB.Recordset)
        For m As Integer = 0 To rs.RecordCount - 1
            Dim row As DataGridViewRow = dgItemList.Rows(dgItemList.Rows.Add)
            row.Cells(colDesg.Index).Value = rs.Fields("IncenDesig").Value
            row.Cells(colPer.Index).Value = rs.Fields("IncenPerf").Value
            row.Cells(colRng.Index).Value = rs.Fields("Incen_Range").Value
            row.Cells(colMonth.Index).Value = rs.Fields("Incen_PerMonth").Value
            row.Cells(colStatus.Index).Value = IIf(rs.Fields("IsActive").Value = True, "Active", "InActive")
            rs.MoveNext()
        Next
    End Sub


    Private Sub ShowData(ByVal rs As ADODB.Recordset)
        m_IsNewMode = False
        Clear()
        txtDesign.Text = rs.Fields("IncenDesig").Value
        txtperf.Text = rs.Fields("IncenPerf").Value
        txtrange.Text = rs.Fields("Incen_Range").Value
        txtmontive.Text = rs.Fields("Incen_PerMonth").Value
        EditMode(False)
        MainTab.SelectTab(0)
    End Sub

    Private Sub cboSelection_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnFilter_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Filter()
    End Sub

    Private Sub dgItemList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItemList.CellContentClick

    End Sub

    Private Sub dgItemList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItemList.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim row As DataGridViewRow = dgItemList.Rows(e.RowIndex)
            Dim rs As New ADODB.Recordset
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.Open("SELECT * FROM INCENTIVE WHERE IncenDesig = '" & row.Cells(colDesg.Index).Value & "'AND IncenPerf = '" & row.Cells(colPer.Index).Value & "'AND DELFLAG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                txtDesign.Text = rs.Fields("IncenDesig").Value
                txtperf.Text = rs.Fields("IncenPerf").Value
                txtrange.Text = rs.Fields("Incen_Range").Value
                txtmontive.Text = rs.Fields("Incen_PerMonth").Value
                chkIsActive.Checked = IIf(row.Cells(colStatus.Index).Value = "Active", True, False)
                EditMode(False)
                Operation = ""
                MainTab.SelectTab(0)
            Else

            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call Filter()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        funct()
    End Sub
    Private Function funct() As Boolean
        m_Err.Clear()
        m_HasError = False
        If txtperf.Text = "" Then
            m_Err.SetError(txtperf, "Performance required")
            m_HasError = True
            If txtDesign.Text = "" Then
                m_Err.SetError(txtDesign, "Designation required")
                m_HasError = True
            End If
        Else
            process2()
        End If
        Return Not m_HasError

    End Function

    Private Sub process2()

        Dim per As Integer
        per = txtperf.Text

        If txtDesign.Text = "KAS" Then
            Select Case per
                Case 100 To 125
                    If txtDesign.Text = "KAS" Then
                        txtrange.Text = "100-125"
                        txtmontive.Text = "8000"
                    End If
                Case Is > 125
                    If txtDesign.Text = "KAS" Then
                        txtrange.Text = "> 125 "
                        txtmontive.Text = "10800"
                    End If
            End Select
        End If

        If txtDesign.Text = "FSM" Then
            Select Case per
                Case 100 To 109
                    If txtDesign.Text = "FSM" Then
                        txtrange.Text = "100-109"
                        txtmontive.Text = "12000"
                    End If
                Case 110 To 120
                    If txtDesign.Text = "FSM" Then
                        txtrange.Text = "110-120"
                        txtmontive.Text = "15000"
                    End If
                Case 121 To 125
                    If txtDesign.Text = "FSM" Then
                        txtrange.Text = "112-125"
                        txtmontive.Text = "18000"
                    End If
                Case Is > 125
                    If txtDesign.Text = "FSM" Then
                        txtrange.Text = " > 125"
                        txtmontive.Text = "18000"
                    End If
            End Select
        End If
        If txtDesign.Text = "PM" Then
            Select Case per
                Case 100 To 125
                    If txtDesign.Text = "PM" Then
                        txtrange.Text = "100-125"
                        txtmontive.Text = "9000"
                    End If
                Case Is > 125
                    If txtDesign.Text = "PM" Then
                        txtrange.Text = "> 125"
                        txtmontive.Text = "12150"
                    End If
            End Select
        End If
        If txtDesign.Text = "DSM" Then
            Select Case per
                Case 100 To 109
                    If txtDesign.Text = "DSM" Then
                        txtrange.Text = "100-109"
                        txtmontive.Text = "7500"
                    End If
                Case 110 To 120
                    If txtDesign.Text = "DSM" Then
                        txtrange.Text = "110-120"
                        txtmontive.Text = "10500"
                    End If
                Case 121 To 125
                    If txtDesign.Text = "DSM" Then
                        txtrange.Text = "121-125"
                        txtmontive.Text = "14000"
                    End If
                Case Is > 125
                    If txtDesign.Text = "DSM" Then
                        txtrange.Text = "> 125"
                        txtmontive.Text = "14000"
                    End If
            End Select
        End If
        If txtDesign.Text = "MR" Then
            Select Case per
                Case 100 To 109
                    If txtDesign.Text = "MR" Then
                        txtrange.Text = "100-109"
                        txtmontive.Text = "5000"
                    End If
                Case 110 To 120
                    If txtDesign.Text = "MR" Then
                        txtrange.Text = "110-120"
                        txtmontive.Text = "6500"

                    End If
                Case 121 To 125
                    If txtDesign.Text = "MR" Then
                        txtrange.Text = "121-125"
                        txtmontive.Text = "7500"
                    End If
            End Select
        End If

    End Sub
    Private Function TrapKey(ByVal KCode As String) As Boolean
        If (KCode >= 48 And KCode <= 57) Or KCode = 8 Then
            TrapKey = False
        Else
            TrapKey = True
        End If
    End Function

    Private Sub txtperf_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtperf.KeyPress
        e.Handled = TrapKey(Asc(e.KeyChar))
    End Sub

    Private Sub txtmontive_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmontive.TextChanged

    End Sub

    Private Sub txtperf_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtperf.TextChanged

    End Sub

    Private Sub Selectioncbo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Selectioncbo.SelectedIndexChanged

    End Sub

    Private Sub MainTab_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainTab.SelectedIndexChanged
        loaddeleted()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        LoadIncentiveToGrid()
    End Sub
End Class

