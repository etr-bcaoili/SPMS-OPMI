Imports SPMSOPCI.ConnectionModule

Public Class UCTerritoryItemTargetPerDistributor

    Private m_RsDistributor As New ADODB.Recordset
    Private m_RsTerritory As New ADODB.Recordset
    Private m_RsItems As New ADODB.Recordset
    Private m_RsMonth As New ADODB.Recordset
    Private m_HasErrors As Boolean = False
    Private m_Err As New ErrorProvider
    Private m_Action As String = ""
    Private m_IsNewMode As Boolean = True
    Private m_RsTerritoryItemTarget As New ADODB.Recordset

    Private Enum EnumAction
        SAVE = 1
        UPDATE = 2
    End Enum

    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnAdd.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode
        dgDetails.ReadOnly = Not IsEditMode
    End Sub

    Private Sub Clear()
        cboCalendarYear.SelectedIndex = -1
        cboChannel.SelectedIndex = -1
        cboMonth.SelectedIndex = -1
        cboTerritory.SelectedIndex = -1
        txtChannel.Text = ""
        txtMonthDescription.Text = ""
        txtTerritory.Text = ""
        dgDetails.Rows.Clear()
    End Sub

    Private Sub FieldLock(ByVal IsLocked As Boolean)
        cboCalendarYear.Enabled = IsLocked
        cboChannel.Enabled = IsLocked
        cboMonth.Enabled = IsLocked
        cboTerritory.Enabled = IsLocked

        txtTerritory.ReadOnly = Not IsLocked
        txtTerritory.BackColor = Color.White
        txtChannel.ReadOnly = Not IsLocked
        txtChannel.BackColor = Color.White
        txtMonthDescription.ReadOnly =  Not IsLocked
        txtMonthDescription.BackColor = Color.White
    End Sub
    Private Sub LoadDistributor()
        If m_RsDistributor.State = 1 Then m_RsDistributor.Close()
        m_RsDistributor.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsDistributor.Open("SELECT * FROM DISTRIBUTOR WHERE  DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsDistributor.RecordCount > 0 Then
            cboChannel.Items.Clear()
            Dim rs As New ADODB.Recordset
            If rs.State = 1 Then rs.Close()
            rs.Open("SELECT TOP 1 COMID FROM Company Where DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                cboChannel.Items.Add(rs.Fields("COMID").Value)
            End If

            For m As Integer = 0 To m_RsDistributor.RecordCount - 1
                cboChannel.Items.Add(m_RsDistributor.Fields("DISTCOMID").Value)
                m_RsDistributor.MoveNext()
            Next
        End If
    End Sub

    Private Sub UCTerritoryItemTargetPerDistributor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(dgDetails)
        LoadDistributor()
        LoadTerritory()
        LoadYear()
        ' LoadItemsToGrid()
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
        Else
            txtChannel.Text = String.Empty
        End If
        'EditMode(True)
    End Sub
    Private Sub LoadTerritory()
        If m_RsTerritory.State = 1 Then m_RsTerritory.Close()
        m_RsTerritory.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsTerritory.Open("SELECT DISTINCT STTERRCD FROM SALESMATRIX GROUP BY STTERRCD ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        cboTerritory.Items.Clear()
        If m_RsTerritory.RecordCount > 0 Then
            For m As Integer = 0 To m_RsTerritory.RecordCount - 1
                cboTerritory.Items.Add(m_RsTerritory.Fields("STTERRCD").Value)
                m_RsTerritory.MoveNext()
            Next
        End If
    End Sub
    Private Sub GetTerritoryDescription(ByVal TerritoryCode As String)
        If m_RsTerritory.State = 1 Then m_RsTerritory.Close()
        m_RsTerritory.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsTerritory.Open("SELECT STACOVNAME FROM SALESMATRIX  WHERE STTERRCD = '" & TerritoryCode & "' GROUP BY STTERRCD, STACOVNAME ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsTerritory.RecordCount > 0 Then
            txtTerritory.Text = m_RsTerritory.Fields("STACOVNAME").Value
            cboCalendarYear.SelectedIndex = -1
            cboMonth.SelectedIndex = -1
        Else
            txtTerritory.Text = ""
        End If
    End Sub
    Private Sub cboTerritory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTerritory.SelectedIndexChanged
        GetTerritoryDescription(cboTerritory.Text)
    End Sub

    Private Sub LoadYear()
        Dim yr As Integer = Now.Year()
        cboCalendarYear.Items.Clear()
        For m As Integer = yr - 10 To yr + 10
            cboCalendarYear.Items.Add(m)
        Next
    End Sub

    Private Sub LoadItemsToGrid(Optional ByVal ITEMDIVCD As String = "")

        If m_RsItems.State = 1 Then m_RsItems.Close()
        m_RsItems.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Dim condition As String = ""
        If ITEMDIVCD <> "" Then condition &= "  AND ITEMDIVCD = '" & ITEMDIVCD & "' "
        m_RsItems.Open("SELECT * FROM Item Where ITEMDEL = 0  " & condition, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsItems.RecordCount > 0 Then
            dgDetails.Rows.Clear()
            For m As Integer = 0 To m_RsItems.RecordCount - 1
                Dim row As DataGridViewRow = dgDetails.Rows(dgDetails.Rows.Add)
                row.Cells(colItemCode.Index).Value = Trim(m_RsItems.Fields("ITEMCD").Value)
                row.Cells(colItemDesc.Index).Value = m_RsItems.Fields("IMDBRN").Value
                row.Cells(colUnitOfMeasure.Index).Value = ""
                m_RsItems.MoveNext()
            Next

        End If

    End Sub

    Private Sub LoadMonth(ByVal DistributorCode As String, ByVal Year As String)

        If m_RsMonth.State = 1 Then m_RsMonth.Close()
        m_RsMonth.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        If cboChannel.Text = "All" Then
            m_RsMonth.Open("SELECT * FROM Calendar WHERE COMID = '" & "INH" & "' AND CAYR = '" & Year & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Else
            m_RsMonth.Open("SELECT * FROM Calendar WHERE COMID = '" & DistributorCode & "' AND CAYR = '" & Year & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        End If


        If m_RsMonth.RecordCount > 0 Then
            cboMonth.Items.Clear()
            txtMonthDescription.Text = ""
            For m As Integer = 0 To m_RsMonth.RecordCount - 1
                cboMonth.Items.Add(m_RsMonth.Fields("CAPN").Value)
                m_RsMonth.MoveNext()
            Next
        End If

    End Sub
    Private Function GetTerritoryDivisionCode(ByVal TerritoryCode As String) As String
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT STITMDIVCD  FROM SalesMatrix Where STTERRCD = '" & TerritoryCode & "' AND DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return rs.Fields("STITMDIVCD").Value
        Else
            Return ""
        End If
    End Function

    Private Sub GetMonthDescription(ByVal DistributorCode As String, ByVal Year As String, ByVal MonthCode As String)

        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'If cboChannel.Text = "All" Then
        '    rs.Open("SELECT MonthDescription FROM Calendar Where COMID = '" & "INH" & "' AND CAYR = '" & Year & "'   AND CAPN = '" & MonthCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        'Else
        rs.Open("SELECT MonthDescription FROM Calendar Where COMID = '" & DistributorCode & "' AND CAYR = '" & Year & "'   AND CAPN = '" & MonthCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        ' End If

        If rs.RecordCount > 0 Then
            txtMonthDescription.Text = rs.Fields("MonthDescription").Value
            Dim itemdivcd As String = GetTerritoryDivisionCode(cboTerritory.Text)
            LoadItemsToGrid(itemdivcd)
            LoadTerritoryItemTarget()
            EditMode(False)
            FieldLock(True)
        Else
            txtMonthDescription.Text = ""
            dgDetails.Rows.Clear()
        End If
        
    End Sub
    Private Sub cboCalendarYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCalendarYear.SelectedIndexChanged
        If cboCalendarYear.SelectedIndex <> -1 Then
            If cboTerritory.Text = "" Then
                ShowExclamation("Territory is required", "Territory")
            Else
                LoadMonth(cboChannel.Text, cboCalendarYear.Text)
            End If

        End If
    End Sub

    Private Sub cboMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMonth.SelectedIndexChanged
        GetMonthDescription(cboChannel.Text, cboCalendarYear.Text, cboMonth.Text)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub



    Private Function ValidateData() As Boolean

        m_HasErrors = False
        m_Err.Clear()
        lblErrorMessage.Visible = False

        If cboChannel.Text = "" Then
            m_Err.SetError(cboChannel, "Channel is required")
            m_HasErrors = True
        End If

        If cboTerritory.Text = "" Then
            m_Err.SetError(cboTerritory, "Territory is required")
            m_HasErrors = True
        End If

        If cboCalendarYear.Text = "" Then
            m_Err.SetError(cboCalendarYear, "Year is required")
            m_HasErrors = True
        End If

        If cboMonth.Text = "" Then
            m_Err.SetError(cboMonth, "Month is required")
            m_HasErrors = True
        End If


        If m_HasErrors Then
            Return False
        End If


        'For m As Integer = 0 To dgDetails.Rows.Count - 1

        '    Dim row As DataGridViewRow = dgDetails.Rows(m)

        '    If row.Cells(colQuantity.Index).Value Is Nothing Then
        '        row.Cells(colQuantity.Index).Style.BackColor = Color.LightPink
        '        row.Cells(colQuantity.Index).ToolTipText = "Quantity is required"
        '        m_HasErrors = True
        '    Else
        '        'If CDbl(row.Cells(colQuantity.Index).Value) = 0 Then
        '        '    row.Cells(colQuantity.Index).Style.BackColor = Color.LightPink
        '        '    row.Cells(colQuantity.Index).ToolTipText = "Quantity must be greate"
        '        '    m_HasErrors = True
        '        'Else
        '        row.Cells(colQuantity.Index).Style.BackColor = row.DefaultCellStyle.BackColor
        '        row.Cells(colQuantity.Index).ToolTipText = String.Empty
        '        ' End If
        '    End If

        '    If row.Cells(colAmount.Index).Value Is Nothing Then
        '        row.Cells(colAmount.Index).Style.BackColor = Color.LightPink
        '        row.Cells(colAmount.Index).ToolTipText = "Amount is required"
        '        m_HasErrors = True
        '    Else
        '        'If CDbl(row.Cells(colAmount.Index).Value) = 0 Then

        '        'Else
        '        row.Cells(colAmount.Index).Style.BackColor = row.DefaultCellStyle.BackColor
        '        row.Cells(colAmount.Index).ToolTipText = String.Empty
        '        ' End If
        '    End If
        '    If row.Cells(colSalesTarget.Index).Value Is Nothing Then
        '        row.Cells(colSalesTarget.Index).Style.BackColor = Color.LightPink
        '        row.Cells(colSalesTarget.Index).ToolTipText = "Sales Target is required"
        '        m_HasErrors = True
        '    Else
        '        row.Cells(colSalesTarget.Index).Style.BackColor = row.DefaultCellStyle.BackColor
        '        row.Cells(colSalesTarget.Index).ToolTipText = String.Empty
        '    End If

        'Next

        If m_HasErrors Then
            lblErrorMessage.Visible = True
        End If

        Return Not m_HasErrors
    End Function

    Private Sub dgDetails_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellEndEdit
        If e.RowIndex = -1 Then Exit Sub

        Dim row As DataGridViewRow = dgDetails.Rows(e.RowIndex)
        Dim quantity As Double = 0
        Dim amount As Double = 0
        If IsNumeric(row.Cells(colQuantity.Index).Value) Then
            quantity = row.Cells(colQuantity.Index).Value
            row.Cells(colQuantity.Index).Value = quantity.ToString("#,##0.0000")
        Else
            quantity = 0
            row.Cells(colQuantity.Index).Value = "0.0000"
        End If
        If IsNumeric(row.Cells(colAmount.Index).Value) Then
            amount = row.Cells(colAmount.Index).Value
        Else
            row.Cells(colAmount.Index).Value = "0.0000"
            amount = 0
        End If

        If e.ColumnIndex = colQuantity.Index Then
            If IsNumeric(row.Cells(colQuantity.Index).Value) Then
                row.Cells(colQuantity.Index).Value = quantity.ToString("#,##0.0000")
                row.Cells(colSalesTarget.Index).Value = ComputeSalesTarget(amount, quantity).ToString("#,##0.0000")
            Else
                row.Cells(colQuantity.Index).Value = "0.0000"
            End If
        ElseIf e.ColumnIndex = colAmount.Index Then
            row.Cells(colAmount.Index).Value = amount.ToString("#,##0.0000")
            row.Cells(colSalesTarget.Index).Value = ComputeSalesTarget(amount, quantity).ToString("#,##0.0000")
        End If

    End Sub

    Private Function ComputeSalesTarget(ByVal BaseAmount As Double, ByVal Quantity As Double) As Double
        Return BaseAmount * Quantity
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateData() Then
            SaveData()
            EditMode(False)
            FieldLock(False)
        End If
    End Sub

    Private Sub SaveData()

        For m As Integer = 0 To dgDetails.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetails.Rows(m)

            If Not row.Cells(colQuantity.Index).Value Is Nothing Then
                If CheckIfTargetExist(row.Cells(colItemCode.Index).Value, cboCalendarYear.Text, cboMonth.Text, cboTerritory.Text, cboChannel.Text) Then
                    m_Action = EnumAction.UPDATE.ToString
                Else
                    m_Action = EnumAction.SAVE.ToString
                End If
                SaveTerritoryTarget(row)
            End If


        Next

        ShowInformation("Record Successfully Saved", "Save")
    End Sub

    Private Sub SaveTerritoryTarget(ByVal row As DataGridViewRow)
        Try

            SPMSConn.Execute("EXEC uspTerritoryItemTarget @Action = '" & m_Action & "' ,  " & _
                                                                " @ComID = '" & cboChannel.Text & "', " & _
                                                                " @STTERRCD = '" & cboTerritory.Text & "' , " & _
                                                                " @YEAR = " & cboCalendarYear.Text & " , " & _
                                                                " @MONTH = '" & cboMonth.Text & "' ,  " & _
                                                                " @ITEMCD = '" & HandleSingleQuoteInSql(row.Cells(colItemCode.Index).Value) & "' , " & _
                                                                " @Quantity = " & CDec(row.Cells(colQuantity.Index).Value) & " , " & _
                                                                " @Amount = " & CDbl(row.Cells(colAmount.Index).Value) & " , " & _
                                                                " @SalesTarget = " & CDbl(row.Cells(colSalesTarget.Index).Value) & " ")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub


    Private Function CheckIfTargetExist(ByVal ItemCode As String, ByVal Year As Integer, ByVal Month As String, ByVal TerritoryCode As String, ByVal DistributorCode As String) As Boolean

        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM TerritoryItemTarget WHERE DLTFLG =0 AND ITEMCD = '" & HandleSingleQuoteInSql(ItemCode) & "' AND YEAR = " & Year & "  AND Month = " & Month & " AND STTERRCD = '" & HandleSingleQuoteInSql(TerritoryCode) & "' AND COMID = '" & HandleSingleQuoteInSql(DistributorCode) & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If ShowQuestion("Are you sure you want to delete this record?", "Delete") = MsgBoxResult.Yes Then
            Delete()
            ShowInformation("Record Successfully Deleted", "Delete")
        End If
    End Sub
    Private Sub Delete()

        Try
            SPMSConn.Execute("EXEC uspTerritoryItemTarget @Action = 'DELETE' , @ComID = '" & cboChannel.Text & "' , @YEAR = " & cboCalendarYear.Text & " , @MONTH= '" & cboMonth.Text & "' , @STTERRCD = '" & cboTerritory.Text & "' ")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        EditMode(True)
        FieldLock(True)
    End Sub

    Private Sub LoadTerritoryItemTarget()

        If m_RsTerritoryItemTarget.State = 1 Then m_RsTerritoryItemTarget.Close()
        m_RsTerritoryItemTarget.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        If cboChannel.Text = "All" Then
            m_RsTerritoryItemTarget.Open("SELECT * FROM TerritoryItemTarget Where DLTFLG =0 AND YEAR = " & cboCalendarYear.Text & " AND MONTH = '" & cboMonth.Text & "' AND COMID = '" & "INH" & "' AND STTERRCD = '" & HandleSingleQuoteInSql(cboTerritory.Text) & "'  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Else
            m_RsTerritoryItemTarget.Open("SELECT * FROM TerritoryItemTarget Where DLTFLG =0 AND YEAR = " & cboCalendarYear.Text & " AND MONTH = '" & cboMonth.Text & "' AND COMID = '" & HandleSingleQuoteInSql(cboChannel.Text) & "' AND STTERRCD = '" & HandleSingleQuoteInSql(cboTerritory.Text) & "'  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        End If


        If m_RsTerritoryItemTarget.RecordCount > 0 Then

            For l As Integer = 0 To m_RsTerritoryItemTarget.RecordCount - 1
                For m As Integer = 0 To dgDetails.Rows.Count - 1
                    Dim row As DataGridViewRow = dgDetails.Rows(m)
                    If row.Cells(colItemCode.Index).Value = m_RsTerritoryItemTarget.Fields("ITEMCD").Value Then
                        Dim quan As Decimal = m_RsTerritoryItemTarget.Fields("Quantity").Value
                        Dim amt As Double = m_RsTerritoryItemTarget.Fields("Amount").Value
                        Dim salestarget As Double = m_RsTerritoryItemTarget.Fields("SalesTarget").Value
                        row.Cells(colQuantity.Index).Value = quan.ToString("#,##0.0000")
                        row.Cells(colAmount.Index).Value = amt.ToString("#,##0.0000")
                        row.Cells(colSalesTarget.Index).Value = salestarget.ToString("#,##0.0000")
                    End If
                Next
                m_RsTerritoryItemTarget.MoveNext()
            Next


        End If

    End Sub

End Class
