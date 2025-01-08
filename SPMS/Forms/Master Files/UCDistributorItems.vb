Imports SPMSOPCI.ConnectionModule

Public Class UCDistributorItems

    Private m_RsDistributor As New ADODB.Recordset
    Private m_RsItems As New ADODB.Recordset
    Private m_RsDistributorItems As New ADODB.Recordset
    Private m_Err As New ErrorProvider
    Private m_HasErrors As Boolean = False

    Private m_Action As String = EnumAction.Save.ToString

    Private m_DistributorCode As String = ""

    Public Property DistributorCode() As String
        Get
            Return m_DistributorCode
        End Get
        Set(ByVal value As String)
            m_DistributorCode = value
        End Set
    End Property

    Private Enum EnumAction
        Save = 1
        Update = 2
    End Enum
    Private Sub Clear()
        cboChannel.SelectedIndex = -1
        dgDetails.Rows.Clear()
        LoadItemsToGrid()
    End Sub

    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnEdit.Enabled = IsEditMode
        btnAdd.Enabled = IsEditMode
        btnSave.Enabled = Not IsEditMode
        dgDetails.ReadOnly = IsEditMode
        cboChannel.Enabled = Not IsEditMode
        dtStart.Enabled = Not IsEditMode
        dtEnd.Enabled = Not IsEditMode
    End Sub

    Private Sub LoadDistributor()
        cboChannel.Items.Clear()
        Dim rs2 As New ADODB.Recordset
        If rs2.State = 1 Then rs2.Close()
        cboChannel.Items.Add("")
        rs2.Open("SELECT TOP 1 COMID FROM Company Where DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs2.RecordCount > 0 Then
            cboChannel.Items.Add(rs2.Fields("COMID").Value)
        End If

        If m_RsDistributor.State = 1 Then m_RsDistributor.Close()
        m_RsDistributor.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsDistributor.Open("SELECT * FROM DISTRIBUTOR WHERE  DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsDistributor.RecordCount > 0 Then

            For m As Integer = 0 To m_RsDistributor.RecordCount - 1
                cboChannel.Items.Add(m_RsDistributor.Fields("DISTCOMID").Value)
                m_RsDistributor.MoveNext()
            Next
        End If
    End Sub

    Private Sub GetCompanyName(ByVal CompanyCode As String)

        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT COMNAME FROM Company WHERE DLTFLG = 0 AND COMID = '" & CompanyCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            txtChannel.Text = rs.Fields("COMNAME").Value
        Else
            If m_RsDistributor.State = 1 Then m_RsDistributor.Close()
            m_RsDistributor.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            m_RsDistributor.Open("SELECT DISTNAME FROM DISTRIBUTOR WHERE DLTFLG = 0 AND DISTCOMID= '" & CompanyCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If m_RsDistributor.RecordCount > 0 Then
                txtChannel.Text = m_RsDistributor.Fields("DISTNAME").Value
            End If
        End If
    End Sub

    Private Sub cboChannel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboChannel.SelectedIndexChanged
        If cboChannel.SelectedIndex <> -1 Then
            GetCompanyName(cboChannel.Text)
            LoadItemsToGrid()
            'LoadDistributorItems(cboChannel.Text)

        Else
            txtChannel.Text = String.Empty
        End If
        'EditMode(True)
    End Sub

    Public Sub LoadItemsToGrid()
        If m_RsItems.State = 1 Then m_RsItems.Close()
        m_RsItems.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsItems.Open("SELECT * FROM Item Where ITEMDEL = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsItems.RecordCount > 0 Then
            dgDetails.Rows.Clear()
            For m As Integer = 0 To m_RsItems.RecordCount - 1
                Dim row As DataGridViewRow = dgDetails.Rows(dgDetails.Rows.Add)
                row.Cells(colItemCode.Index).Value = Trim(m_RsItems.Fields("ITEMCD").Value)
                row.Cells(colItemBrandName.Index).Value = m_RsItems.Fields("IMDBRN").Value
                row.Cells(colItemGenericName.Index).Value = m_RsItems.Fields("IMDGEN").Value
                m_RsItems.MoveNext()
            Next
        End If
    End Sub

    Public Sub LoadDistributorItems(ByVal DistributorCode As String, ByVal StartDate As Date, ByVal EndDate As Date)
        If m_RsDistributorItems.State = 1 Then m_RsDistributorItems.Close()
        m_RsDistributorItems.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsDistributorItems.Open("SELECT  * FROM DistributorItems WHERE COMID = '" & HandleSingleQuoteInSql(DistributorCode) & "' AND CONVERT(VARCHAR(20), EffectivityStartDate,101) = '" & StartDate.ToString("MM/dd/yyyy") & "' AND  CONVERT(VARCHAR(20),EffectivityEndDate,101) = '" & EndDate.ToString("MM/dd/yyyy") & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsDistributorItems.RecordCount > 0 Then
            For l As Integer = 0 To m_RsDistributorItems.RecordCount - 1
                For m As Integer = 0 To dgDetails.Rows.Count - 1
                    Dim row As DataGridViewRow = dgDetails.Rows(m)
                    If row.Cells(colItemCode.Index).Value = m_RsDistributorItems.Fields("ITEMCD").Value Then
                        row.Cells(colDistributorItemCode.Index).Value = m_RsDistributorItems.Fields("DISTITEMCD").Value
                        row.Cells(colDistributorItemCode.Index).Tag = m_RsDistributorItems.Fields("DISTITEMCD").Value
                        row.Cells(colDistributorItemDesc.Index).Value = m_RsDistributorItems.Fields("ITEMNAME").Value
                        Dim price As Double = m_RsDistributorItems.Fields("DISTITEMPRICE").Value
                        row.Cells(colItemPrice.Index).Value = price.ToString("#,##0.0000")
                        Dim compprice As Double = m_RsDistributorItems.Fields("CompanyPrice").Value
                        row.Cells(colCompanyPrice.Index).Value = compprice.ToString("#,##0.0000")
                        row.Tag = m_RsDistributorItems.Fields("DISTID").Value
                    End If
                Next
                m_RsDistributorItems.MoveNext()
            Next
        End If
    End Sub
    Private Sub LoadSelection()
        cboSelection.Items.Clear()
        For m As Integer = 0 To dgListing.Columns.Count - 1
            cboSelection.Items.Add(dgListing.Columns(m).HeaderText)
        Next
        cboSelection.SelectedIndex = 0
    End Sub

    Private Sub UCDistributorItems_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(dgDetails)
        ApplyGridTheme(dgListing)
        PopulateSearchGrid()
        LoadSelection()
        LoadDistributor()
        LoadItemsToGrid()
        EditMode(False)
        btnAdd.Enabled = True
        btnEdit.Enabled = False

        If m_DistributorCode <> "" Then
            Dim rs As New ADODB.Recordset
            If rs.State = 1 Then rs.Close()
            rs.Open("SELECT  Top 1  * FROM DistributorItems WHERE COMID = '" & HandleSingleQuoteInSql(m_DistributorCode) & "' AND IsActive = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rs.RecordCount > 0 Then
                cboChannel.SelectedItem = rs.Fields("COMID").Value
                dtStart.Value = rs.Fields("EffectivityStartDate").Value
                dtEnd.Value = rs.Fields("EffectivityEndDate").Value
                chkIsActive.Checked = rs.Fields("IsActive").Value
                LoadDistributorItems(m_DistributorCode, rs.Fields("EffectivityStartDate").Value, rs.Fields("EffectivityEndDate").Value)
                EditMode(True)
            End If

        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Function CheckIfDistributorItemExist(ByVal CompanyCode As String, ByVal StartDate As Date, ByVal EndDate As Date) As Boolean
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT 'A' FROM DistributorItems Where COMID = '" & CompanyCode & "' AND EffectivityStartDate = '" & StartDate & "' AND EffectivityEndDate = '" & EndDate & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub SaveData()
        If m_Action = EnumAction.Save.ToString Then
            For m As Integer = 0 To dgDetails.Rows.Count - 1
                Dim row As DataGridViewRow = dgDetails.Rows(m)
                If row.Cells(colDistributorItemCode.Index).Value <> String.Empty Then
                    m_Action = EnumAction.Save.ToString
                    SaveDistributorItems(row)
                End If
            Next
        Else
            For m As Integer = 0 To dgDetails.Rows.Count - 1
                Dim row As DataGridViewRow = dgDetails.Rows(m)
                If row.Cells(colDistributorItemCode.Index).Value <> String.Empty Then
                    If row.Cells(colDistributorItemCode.Index).Tag Is Nothing Then
                        m_Action = EnumAction.Save.ToString
                        SaveDistributorItems(row)
                    Else
                        m_Action = EnumAction.Update.ToString
                        If Not CheckIfItemExist(row.Cells(colDistributorItemCode.Index).Value, cboChannel.Text, IIf(row.Tag Is Nothing, -1, row.Tag)) Then
                            SaveDistributorItems(row)
                        End If
                    End If
                Else
                    If Not row.Cells(colDistributorItemCode.Index).Value = String.Empty Then
                        m_Action = EnumAction.Update.ToString
                        SaveDistributorItems(row)
                    Else
                        m_Action = EnumAction.Update.ToString
                        If Not CheckIfItemExist(row.Cells(colDistributorItemCode.Index).Value, cboChannel.Text, IIf(row.Tag Is Nothing, -1, row.Tag)) Then
                            SaveDistributorItems(row)
                        End If
                    End If

                End If
            Next
        End If
        btnEdit.Enabled = True
        dgDetails.ReadOnly = True
        btnAdd.Enabled = True
        ShowInformation("Record Successfully Saved.", "Save")
    End Sub


    Private Function ValidateData() As Boolean
        m_HasErrors = False
        lblErrorMessage.Visible = False
        m_Err.Clear()

        If cboChannel.Text = "" Then
            m_Err.SetError(cboChannel, "Channel is required")
            m_HasErrors = True
        End If
        If CDate(dtStart.Value.ToShortDateString) > CDate(dtEnd.Value.ToShortDateString) Then
            m_Err.SetError(dtStart, "Effectivity Start Date should not be greater than the end date")
            m_HasErrors = True
        End If


        If m_HasErrors Then
            Return False
        End If

        If m_Action = EnumAction.Save.ToString Then
            If CheckIfDistributorItemExist(cboChannel.Text, dtStart.Value.ToShortDateString, dtEnd.Value.ToShortDateString) Then
                ShowExclamation("There was already a transaction created for this channel with the same effectivity dates", "Record not saved")
                Return False
            End If
        End If

        For m As Integer = 0 To dgDetails.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetails.Rows(m)
            If row.Cells(colDistributorItemCode.Index).Value <> String.Empty Then
                If row.Cells(colDistributorItemCode.Index).Tag Is Nothing Then
                    If CheckIfItemExist(row.Cells(colDistributorItemCode.Index).Value, cboChannel.Text, IIf(row.Tag Is Nothing, -1, row.Tag)) Then
                        row.Cells(colDistributorItemCode.Index).Style.BackColor = Color.LightPink
                        row.Cells(colDistributorItemCode.Index).ToolTipText = "Channel Item Code Already Exist"
                        m_HasErrors = True
                    Else
                        row.Cells(colDistributorItemCode.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                        row.Cells(colDistributorItemCode.Index).ToolTipText = String.Empty
                    End If
                End If
                If row.Cells(colItemPrice.Index).Value Is Nothing Then
                    row.Cells(colItemPrice.Index).Style.BackColor = Color.LightPink
                    row.Cells(colItemPrice.Index).ToolTipText = "Item Price should not be empty"
                    m_HasErrors = True
                ElseIf Not IsNumeric(row.Cells(colItemPrice.Index).Value) Then
                    row.Cells(colItemPrice.Index).Style.BackColor = Color.LightPink
                    row.Cells(colItemPrice.Index).ToolTipText = "Value must be numeric"
                    m_HasErrors = True
                Else
                    row.Cells(colItemPrice.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                    row.Cells(colItemPrice.Index).ToolTipText = String.Empty
                End If


            End If
        Next


        If m_HasErrors Then
            lblErrorMessage.Visible = True
        End If

        Return Not m_HasErrors
    End Function

    Private Sub SaveDistributorItems(ByVal row As DataGridViewRow)
        Try
            SPMSConn.Execute("EXEC uspDistributorItems @Action = '" & m_Action & "' , @COMID = '" & cboChannel.Text & "' ,  @ITEMCD = '" & HandleSingleQuoteInSql(row.Cells(colItemCode.Index).Value) & "' , @DISTITEMCD = '" & HandleSingleQuoteInSql(row.Cells(colDistributorItemCode.Index).Value) & "' , " & _
                                " @ITEMNAME = '" & HandleSingleQuoteInSql(row.Cells(colDistributorItemDesc.Index).Value) & "'  , @DISTID= '" & IIf(row.Tag Is Nothing, -1, row.Tag) & "'  , @DISTITEMPRICE =  " & CDbl(row.Cells(colItemPrice.Index).Value) & " , " & _
                                "  @EFFECTIVITYSTARTDATE = '" & dtStart.Value.ToShortDateString & "' ,  @EFFECTIVITYENDDATE = '" & dtEnd.Value.ToShortDateString & "' , @IsActive = " & chkIsActive.Checked & " , @CompanyPrice = " & CDbl(row.Cells(colCompanyPrice.Index).Value) & " ")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Function CheckIfItemExist(ByVal DistributorItemCode As String, ByVal DistributorCode As String, ByVal DISTID As Integer) As Boolean
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM DistributorItems WHERE DISTID <> " & DISTID & " AND DISTITEMCD = '" & HandleSingleQuoteInSql(DistributorItemCode) & "' AND COMID = '" & HandleSingleQuoteInSql(DistributorCode) & "'  AND EffectivityStartDate  = '" & dtStart.Value.ToShortDateString & "' AND EffectivityEndDate = '" & dtEnd.Value.ToShortDateString & "'  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateData() Then

            SaveData()
            EditMode(False)
            PopulateSearchGrid()
            LoadItemsToGrid()
            LoadDistributorItems(cboChannel.Text, dtStart.Value.ToShortDateString, dtEnd.Value.ToShortDateString)
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        EditMode(False)
        m_Action = EnumAction.Update.ToString
    End Sub

    Private Sub dgDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick

    End Sub

    Private Sub dgDetails_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellEndEdit
        If e.RowIndex = -1 Then Exit Sub

        Dim row As DataGridViewRow = dgDetails.Rows(e.RowIndex)

        If e.ColumnIndex = colItemPrice.Index Then
            If IsNumeric(row.Cells(colItemPrice.Index).Value) Then
                Dim price As Double = row.Cells(colItemPrice.Index).Value
                row.Cells(colItemPrice.Index).Value = price.ToString("#,##0.0000")
            End If
        ElseIf e.ColumnIndex = colDistributorItemCode.Index Then
            If row.Cells(colDistributorItemCode.Index).Value = "" Then
                row.Cells(colDistributorItemDesc.Index).Value = String.Empty
            Else
                row.Cells(colDistributorItemDesc.Index).Value = row.Cells(colItemBrandName.Index).Value
            End If
        ElseIf e.ColumnIndex = colCompanyPrice.Index Then
            If IsNumeric(row.Cells(colCompanyPrice.Index).Value) Then
                Dim price As Double = row.Cells(colCompanyPrice.Index).Value
                row.Cells(colCompanyPrice.Index).Value = price.ToString("#,##0.0000")
            Else
                row.Cells(colCompanyPrice.Index).Value = "0.0000"
            End If
        End If

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        EditMode(False)
        Clear()
        m_Action = EnumAction.Save.ToString
    End Sub

    Private Sub dgListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgListing.CellContentClick

    End Sub

    Private Sub dgListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgListing.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        EditMode(True)
        Dim row As DataGridViewRow = dgListing.Rows(e.RowIndex)
        cboChannel.SelectedItem = row.Cells(colChannelCode.Index).Value
        dtStart.Value = row.Cells(colEffectivityStartDate.Index).Value
        dtEnd.Value = row.Cells(colEffectivityEndDate.Index).Value
        chkIsActive.Checked = IIf(row.Cells(colStatus.Index).Value = "Active", True, False)
        LoadItemsToGrid()
        LoadDistributorItems(row.Cells(colChannelCode.Index).Value, CDate(row.Cells(colEffectivityStartDate.Index).Value).ToShortDateString, CDate(row.Cells(colEffectivityEndDate.Index).Value).ToShortDateString)
        TabControl1.SelectTab(0)
    End Sub


    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Filter()
    End Sub
    Private Sub Filter()
        If cboSelection.SelectedItem = "Channel Code" Then
            PopulateSearchGrid(" COMID like '%" & txtFilter.Text & "%' ")
        Else
            If IsDate(txtFilter.Text) Then
                If cboSelection.SelectedItem = "Effectivity Start Date" Then
                    PopulateSearchGrid(" EffectivityStartDate = '" & txtFilter.Text & "' ")
                Else
                    PopulateSearchGrid(" EffectivityEndDate = '" & txtFilter.Text & "' ")
                End If
            Else
                ShowExclamation("Value must be a valid date", "Filter")
            End If
        End If
    End Sub
    Private Sub PopulateSearchGrid(Optional ByVal Filter As String = "")
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()

        rs.Open("select COMID, EffectivityStartDate, EffectivityEndDate, IsActive from distributoritems  " & IIf(Filter <> "", " WHERE " & Filter, "") & "  GROUP BY COMID, EffectivityStartDate, EffectivityEndDate, IsActive", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgListing.Rows.Clear()
        If rs.RecordCount > 0 Then
            For m As Integer = 0 To rs.RecordCount - 1
                Dim row As DataGridViewRow = dgListing.Rows(dgListing.Rows.Add)
                row.Cells(colChannelCode.Index).Value = rs.Fields("COMID").Value
                row.Cells(colEffectivityStartDate.Index).Value = CDate(rs.Fields("EffectivityStartDate").Value).ToShortDateString
                row.Cells(colEffectivityEndDate.Index).Value = CDate(rs.Fields("EffectivityEndDate").Value).ToShortDateString
                row.Cells(colStatus.Index).Value = IIf(rs.Fields("IsActive").Value = True, "Active", "Inactive")
                rs.MoveNext()
            Next
        End If
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Chr(13) Then
            Filter()
        End If
    End Sub


End Class
