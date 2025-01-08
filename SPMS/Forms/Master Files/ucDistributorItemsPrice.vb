Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.WinControls.UI
Imports System.Text
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports Telerik.WinControls

Public Class ucDistributorItemsPrice
    '' Implements IDataErrorInfo
    Private m_Distributor As New Distributor
    Private m_Item As New Items
    Private _DistributoryItemPrices As New DistributorItemPrices
    Dim table As New DataTable
    Private m_Err As New ErrorProvider
    Private m_HasErrors As Boolean = False
    Private m_EnableEdit As Boolean = False
    Private m_Action As String = EnumAction.Save.ToString
    Private Enum EnumAction
        Save = 1
        Update = 2
    End Enum
    Private Sub Clear()
        txtChannelCode.Text = String.Empty
        txtChannelName.Text = String.Empty
        GrdViewItemPrice.Rows.Clear()
    End Sub
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        LinkProductManager.Enabled = IsEditMode
        btnUpdate.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtChannelCode.ReadOnly = Not IsEditMode
        txtChannelName.BackColor = Color.White

        txtChannelName.ReadOnly = Not IsEditMode
        txtChannelName.BackColor = Color.White

        GrdViewItemPrice.ReadOnly = Not IsEditMode
    End Sub
    Private Sub NewRecord()
        Clear()
        _DistributoryItemPrices = New DistributorItemPrices
        EditMode(True)
    End Sub
    Private Sub LinkProductManager_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkProductManager.LinkClicked
        Clear()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Distributor.GetDistributorSql, "Search Item")
        If Not tag Is Nothing Then
            LoadChannel(tag.KeyColumn22)
        End If
        LoadItemNew()
    End Sub
    Private Sub LoadChannel(ByVal ChannelCode As String)
        m_Distributor = Distributor.LoadByCode(ChannelCode)
        txtChannelCode.Text = m_Distributor.DISTCOMID
        txtChannelName.Text = m_Distributor.DISTNAME
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnDelete.Click, btnUpdate.Click, btnFind.Click, btnSave.Click, btnClear.Click, btnClose.Click
        If sender Is btnNew Then
            NewRecord()
            m_EnableEdit = False
        ElseIf sender Is btnDelete Then
            'elete()
        ElseIf sender Is btnUpdate Then
            EditMode(True)
            m_EnableEdit = True
        ElseIf sender Is btnClear Then
            Clear()
            EditMode(False)
        ElseIf sender Is btnClose Then
            Close()
        ElseIf sender Is btnFind Then
            Find()
        ElseIf sender Is btnSave Then
            If ValidateData() Then
                SaveRecord()
                SaveSuccess()
                EditMode(False)
            End If
        End If
    End Sub
    Private Sub SaveRecord()
        If m_EnableEdit = False Then
            For m As Integer = 0 To GrdViewItemPrice.Rows.Count - 1
                Dim row As GridViewRowInfo = GrdViewItemPrice.Rows(m)
                If row.Cells(3).Value <> String.Empty Then
                    _DistributoryItemPrices.CompanyCode = HandleSingleQuoteInSql(txtChannelCode.Text)
                    _DistributoryItemPrices.ItemCode = HandleSingleQuoteInSql(row.Cells(0).Value)
                    _DistributoryItemPrices.ChannelItemCode = HandleSingleQuoteInSql(row.Cells(3).Value)
                    _DistributoryItemPrices.ChannelItemDescription = HandleSingleQuoteInSql(row.Cells(4).Value)
                    _DistributoryItemPrices.ChannelPrices = CDbl(row.Cells(5).Value)
                    _DistributoryItemPrices.CompanyPrices = CDbl(row.Cells(6).Value)
                    _DistributoryItemPrices.EffectivityStartDate = dtStart.Value.ToShortDateString
                    _DistributoryItemPrices.EffectivityEndDate = dtEnd.Value.ToShortDateString
                    _DistributoryItemPrices.IsAction = chkIsActive.Checked
                    _DistributoryItemPrices.Save()
                End If
            Next
        Else
            For m As Integer = 0 To GrdViewItemPrice.Rows.Count - 1
                Dim row As GridViewRowInfo = GrdViewItemPrice.Rows(m)
                If row.Cells(3).Value <> Nothing Then
                    If row.Cells(7).Value Is Nothing Then
                        _DistributoryItemPrices = New DistributorItemPrices
                        _DistributoryItemPrices.CompanyCode = HandleSingleQuoteInSql(txtChannelCode.Text)
                        _DistributoryItemPrices.ItemCode = HandleSingleQuoteInSql(row.Cells(0).Value)
                        _DistributoryItemPrices.ChannelItemCode = HandleSingleQuoteInSql(row.Cells(3).Value)
                        _DistributoryItemPrices.ChannelItemDescription = HandleSingleQuoteInSql(row.Cells(4).Value)
                        _DistributoryItemPrices.ChannelPrices = CDbl(row.Cells(5).Value)
                        _DistributoryItemPrices.CompanyPrices = CDbl(row.Cells(6).Value)
                        _DistributoryItemPrices.EffectivityStartDate = dtStart.Value.ToShortDateString
                        _DistributoryItemPrices.EffectivityEndDate = dtEnd.Value.ToShortDateString
                        _DistributoryItemPrices.IsAction = chkIsActive.Checked
                        _DistributoryItemPrices.Save()
                    Else
                        If Not DistributorItemPrices.GetCheckIfItemExistSql(row.Cells(0).Value, txtChannelCode.Text, dtStart.Value.ToShortTimeString, dtEnd.Value.ToShortDateString, IIf(row.Cells(7).Value Is Nothing, -1, row.Cells(7).Value)) Then
                            _DistributoryItemPrices.CompanyCode = HandleSingleQuoteInSql(txtChannelCode.Text)
                            _DistributoryItemPrices.ItemCode = HandleSingleQuoteInSql(row.Cells(0).Value)
                            _DistributoryItemPrices.ChannelItemCode = HandleSingleQuoteInSql(row.Cells(3).Value)
                            _DistributoryItemPrices.IDS = HandleSingleQuoteInSql(row.Cells(7).Value)
                            _DistributoryItemPrices.ChannelItemDescription = HandleSingleQuoteInSql(row.Cells(4).Value)
                            _DistributoryItemPrices.ChannelPrices = CDbl(row.Cells(5).Value)
                            _DistributoryItemPrices.CompanyPrices = CDbl(row.Cells(6).Value)
                            _DistributoryItemPrices.EffectivityStartDate = dtStart.Value.ToShortDateString
                            _DistributoryItemPrices.EffectivityEndDate = dtEnd.Value.ToShortDateString
                            _DistributoryItemPrices.IsAction = chkIsActive.Checked
                            _DistributoryItemPrices.Update()
                        End If
                    End If
                Else
                    If row.Cells(3).Value Is Nothing Then
                        _DistributoryItemPrices.CompanyCode = HandleSingleQuoteInSql(txtChannelCode.Text)
                        _DistributoryItemPrices.ItemCode = HandleSingleQuoteInSql(row.Cells(0).Value)
                        _DistributoryItemPrices.ChannelItemCode = HandleSingleQuoteInSql(row.Cells(3).Value)
                        _DistributoryItemPrices.IDS = HandleSingleQuoteInSql(row.Cells(7).Value)
                        _DistributoryItemPrices.ChannelItemDescription = HandleSingleQuoteInSql(row.Cells(4).Value)
                        _DistributoryItemPrices.ChannelPrices = CDbl(row.Cells(5).Value)
                        _DistributoryItemPrices.CompanyPrices = CDbl(row.Cells(6).Value)
                        _DistributoryItemPrices.EffectivityStartDate = dtStart.Value.ToShortDateString
                        _DistributoryItemPrices.EffectivityEndDate = dtEnd.Value.ToShortDateString
                        _DistributoryItemPrices.IsAction = chkIsActive.Checked
                        _DistributoryItemPrices.Update()
                    Else
                        If Not DistributorItemPrices.GetCheckIfItemExistSql(row.Cells(0).Value, txtChannelCode.Text, dtStart.Value.ToShortDateString, dtEnd.Value.ToShortDateString, IIf(row.Cells(7).Value Is Nothing, -1, row.Cells(7).Value)) Then
                            _DistributoryItemPrices.CompanyCode = HandleSingleQuoteInSql(txtChannelCode.Text)
                            _DistributoryItemPrices.ItemCode = HandleSingleQuoteInSql(row.Cells(0).Value)
                            _DistributoryItemPrices.ChannelItemCode = HandleSingleQuoteInSql(row.Cells(3).Value)
                            _DistributoryItemPrices.IDS = HandleSingleQuoteInSql(row.Cells(7).Value)
                            _DistributoryItemPrices.ChannelItemDescription = HandleSingleQuoteInSql(row.Cells(4).Value)
                            _DistributoryItemPrices.ChannelPrices = CDbl(row.Cells(5).Value)
                            _DistributoryItemPrices.CompanyPrices = CDbl(row.Cells(6).Value)
                            _DistributoryItemPrices.EffectivityStartDate = dtStart.Value.ToShortDateString
                            _DistributoryItemPrices.EffectivityEndDate = dtEnd.Value.ToShortDateString
                            _DistributoryItemPrices.IsAction = chkIsActive.Checked
                            _DistributoryItemPrices.Delete()
                        End If
                    End If
                End If
            Next
        End If
    End Sub
    Private Function ValidateData() As Boolean

        m_HasErrors = False
        lblErrorMessage.Visible = False
        m_Err.Clear()

        If txtChannelCode.Text = "" Then
            m_Err.SetError(txtChannelCode, "Channel is required")
            m_HasErrors = True
        Else
            If m_EnableEdit = False Then
                If DistributorItemPrices.CheckOfDistributorChannelAlreadyExist(txtChannelCode.Text, dtStart.Value.ToShortDateString, dtEnd.Value.ToShortDateString) Then
                    ShowExclamation("There was already a transaction created for this channel with the same effectivity dates", "Record not saved")
                    Return False
                End If
            End If
        End If

        If CDate(dtStart.Value.ToShortDateString) > CDate(dtEnd.Value.ToShortDateString) Then
            m_Err.SetError(dtStart, "Effectivity Start Date should not be greater than the end date")
            m_HasErrors = True
        End If

        For x As Integer = 0 To GrdViewItemPrice.Rows.Count - 1
            For y As Integer = 0 To GrdViewItemPrice.Rows.Count - 1
                If GrdViewItemPrice.Rows(x).Cells(3).Value <> Nothing Or GrdViewItemPrice.Rows(y).Cells(3).Value <> Nothing Then
                    If y <> x AndAlso GrdViewItemPrice.Rows(x).Cells(3).Value = GrdViewItemPrice.Rows(y).Cells(3).Value Then
                        'm_HasErrors = True
                        ''ShowExclamation("There was already Item Chal. '" & GrdViewItemPrice.Rows(x).Cells(3).Value.ToString & "' Prices List", "Duplicate Data!")
                        ''Exit Function
                    End If
                End If
            Next
        Next

        For m As Integer = 0 To GrdViewItemPrice.Rows.Count - 1
            Dim row As GridViewRowInfo = GrdViewItemPrice.Rows(m)
            If row.Cells(3).Value <> String.Empty Then
                If row.Cells(3).Tag Is Nothing Then
                    If DistributorItemPrices.GetCheckIfItemExistSql(row.Cells(3).Value, txtChannelCode.Text, dtStart.Value.ToShortDateString, dtEnd.Value.ToShortDateString, IIf(row.Cells(7).Value Is Nothing, -1, row.Cells(7).Value)) Then
                        'row.Cells(3).Style.BackColor = Color.LightPink
                        'ShowExclamation("There was already Item Chal. '" & row.Cells(3).Value & "' Prices List", "Duplicate Data!")
                        'm_HasErrors = True
                    Else
                        row.Cells(3).Style.BackColor = Color.Black
                        ''row.Cells(3).ToolTipText = String.Empty
                    End If
                End If
                If row.Cells(5).Value Is Nothing Then
                    row.Cells(5).Style.BackColor = Color.LightPink
                    'row.Cells(5).ToolTipText = "Item Price should not be empty"
                    m_HasErrors = True
                ElseIf Not IsNumeric(row.Cells(5).Value) Then
                    row.Cells(5).Style.BackColor = Color.LightPink
                    ' row.Cells(colItemPrice.Index).ToolTipText = "Value must be numeric"
                    m_HasErrors = True
                Else
                    'row.Cells(colItemPrice.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                    'row.Cells(colItemPrice.Index).ToolTipText = String.Empty
                End If


            End If
        Next




        If m_HasErrors Then
            lblErrorMessage.Visible = True
        End If

        Return Not m_HasErrors
    End Function
    Private Sub ErrorInfor()
        Dim obj As New ConditionalFormattingObject()
        obj.CellBackColor = Color.Red
        obj.CellForeColor = Color.Red
        obj.TextAlignment = ContentAlignment.MiddleRight
        Me.GrdViewItemPrice.Columns("column4").ConditionalFormattingObjectList.Add(obj)
    End Sub
    Private Sub ErrorInfoce(ByVal sender As Object, e As RowFormattingEventArgs)
        If e.RowElement.RowInfo.Cells("column4").Value = True Then
            e.RowElement.DrawFill = True
            e.RowElement.GradientStyle = GradientStyles.Solid
            e.RowElement.BackColor = Color.Aqua
        Else
            e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
            e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local)
            e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local)
        End If
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(DistributorItemPrices.GetItemDescriptionSql, "Customer")
        If Not tag Is Nothing Then
            Clear()
            LoadChannel(tag.KeyColumn22)
            ShowItemList()
            ShowData(tag.KeyColumn11, tag.KeyColumn33, tag.KeyColumn44)
            dtEnd.Text = tag.KeyColumn44
            dtStart.Text = tag.KeyColumn33
            EditMode(False)
        End If
    End Sub
    Private Sub LoadItemNew()

        table = GetRecords(Items.GetNewPriceItemSetup)
        GrdViewItemPrice.Rows.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowInfo As GridViewRowInfo = GrdViewItemPrice.Rows.AddNew
            rowInfo.Cells(0).Value = table.Rows(i)("itemthr")
            rowInfo.Cells(1).Value = table.Rows(i)("ITEMMDES")
            rowInfo.Cells(2).Value = table.Rows(i)("ITEMMDES")
        Next
    End Sub
    Private Sub ShowItemList()
        table = GetRecords(DistributorItemPrices.GetItemsSql)
        GrdViewItemPrice.Rows.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowInfo As GridViewRowInfo = GrdViewItemPrice.Rows.AddNew
            rowInfo.Cells(0).Value = table.Rows(i)("itemthr")
            rowInfo.Cells(1).Value = table.Rows(i)("ITEMMDES")
            rowInfo.Cells(2).Value = table.Rows(i)("IMDBRN")
        Next
    End Sub
    Private Sub ShowData(ByVal CompanyCode As String, ByVal EffectivityStartdate As Date, ByVal EffectivityEnddate As Date)
        table = GetRecords(DistributorItemPrices.GetItemDescriptionPriceSql(CompanyCode, EffectivityStartdate, EffectivityEnddate))
        For i As Integer = 0 To table.Rows.Count - 1
            For m As Integer = 0 To GrdViewItemPrice.Rows.Count - 1
                Dim rowinfo As GridViewRowInfo = GrdViewItemPrice.Rows(m)
                If rowinfo.Cells(0).Value = table.Rows(i)("Itemcd") Then
                    rowinfo.Cells(3).Value = table.Rows(i)("Distitemcd")
                    rowinfo.Cells(4).Value = table.Rows(i)("ItemName")
                    rowinfo.Cells(5).Value = table.Rows(i)("Distitemprice")
                    rowinfo.Cells(6).Value = table.Rows(i)("CompanyPrice")
                    rowinfo.Cells(7).Value = table.Rows(i)("DISTID")
                End If
            Next
        Next
    End Sub

    Private Sub ucDistributorItemsPrice_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.GrdViewItemPrice.EnableAlternatingRowColor = True
        EditMode(False)
    End Sub
    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub GrdViewItemPrice_CellEndEdit(sender As Object, e As GridViewCellEventArgs) Handles GrdViewItemPrice.CellEndEdit

        If e.RowIndex = -1 Then Exit Sub

        Dim row As GridViewRowInfo = GrdViewItemPrice.Rows(e.RowIndex)
        If IsNumeric(row.Cells(5).Value) Then
            Dim price As Double = row.Cells(5).Value
            row.Cells(5).Value = price.ToString("#,##0.0000")
        Else
            row.Cells(5).Value = "0.0000"
        End If

        If IsNumeric(row.Cells(6).Value) Then
            Dim price As Double = row.Cells(6).Value
            row.Cells(6).Value = price.ToString("#,##0.0000")
        Else
            row.Cells(6).Value = "0.0000"
        End If


        If row.Cells(3).Value = "" Then
            row.Cells(3).Value = String.Empty
            row.Cells(4).Value = String.Empty
            row.Cells(5).Value = "0.0000"
            row.Cells(6).Value = "0.0000"
        Else
            row.Cells(4).Value = row.Cells(2).Value
        End If

        For x As Integer = 0 To GrdViewItemPrice.Rows.Count - 1
            For y As Integer = 0 To GrdViewItemPrice.Rows.Count - 1
                If GrdViewItemPrice.Rows(x).Cells(3).Value <> Nothing Or GrdViewItemPrice.Rows(y).Cells(3).Value <> Nothing Then
                    If y <> x AndAlso GrdViewItemPrice.Rows(x).Cells(3).Value = GrdViewItemPrice.Rows(y).Cells(3).Value Then
                        'm_HasErrors = True
                        'ShowExclamation("There was already Item Chal. '" & GrdViewItemPrice.Rows(x).Cells(3).Value.ToString & "' Prices List", "Duplicate Data!")
                        'Exit Sub
                    End If
                End If
            Next
        Next


    End Sub

    Private Sub GrdViewItemPrice_CellFormatting(sender As Object, e As CellFormattingEventArgs) Handles GrdViewItemPrice.CellFormatting
        Dim cell As GridDataCellElement = TryCast(e.CellElement, GridDataCellElement)
        If cell IsNot Nothing Then
            If cell.ContainsErrors Then
                cell.DrawBorder = True
                cell.BorderBoxStyle = BorderBoxStyle.FourBorders

                cell.BorderBottomColor = Color.Red
                cell.BorderTopColor = Color.Red
                cell.BorderRightShadowColor = Color.Red
                cell.BorderLeftShadowColor = Color.Red
                cell.BorderBottomShadowColor = Color.Red
                cell.BorderTopShadowColor = Color.Red
                cell.BorderRightColor = Color.Red
                cell.BorderLeftColor = Color.Red
                cell.BorderBottomWidth = 2
                cell.BorderTopWidth = 2
                cell.BorderRightWidth = 2
                cell.BorderLeftWidth = 2

                cell.ZIndex = 500
            Else
                cell.ResetValue(LightVisualElement.DrawBorderProperty, ValueResetFlags.Local)
                cell.ResetValue(LightVisualElement.BorderBoxStyleProperty, ValueResetFlags.Local)
                cell.ResetValue(LightVisualElement.BorderBottomColorProperty, ValueResetFlags.Local)
                cell.ResetValue(LightVisualElement.BorderBottomShadowColorProperty, ValueResetFlags.Local)
                cell.ResetValue(LightVisualElement.BorderBottomWidthProperty, ValueResetFlags.Local)
                cell.ResetValue(LightVisualElement.BorderTopColorProperty, ValueResetFlags.Local)
                cell.ResetValue(LightVisualElement.BorderTopShadowColorProperty, ValueResetFlags.Local)
                cell.ResetValue(LightVisualElement.BorderTopWidthProperty, ValueResetFlags.Local)
                cell.ResetValue(LightVisualElement.BorderLeftColorProperty, ValueResetFlags.Local)
                cell.ResetValue(LightVisualElement.BorderLeftShadowColorProperty, ValueResetFlags.Local)
                cell.ResetValue(LightVisualElement.BorderLeftWidthProperty, ValueResetFlags.Local)
                cell.ResetValue(LightVisualElement.ZIndexProperty, ValueResetFlags.Local)
            End If
        End If
    End Sub
    Private Sub GrdViewItemPrice_CurrentCellChanged(sender As Object, e As CurrentCellChangedEventArgs) Handles GrdViewItemPrice.CurrentCellChanged
        If e.NewCell IsNot Nothing Then
            'Me.radSpinEditorRow.Value = Me.GrdViewItemPrice.Rows.IndexOf(e.NewCell.RowInfo)
            'Me.radSpinEditorColumn.Value = Me.GrdViewItemPrice.Columns.IndexOf(CType(e.NewCell.ColumnInfo, GridViewDataColumn))
        End If
        UpdateState(If(e.NewCell IsNot Nothing, e.NewCell.RowInfo, Nothing), If(e.NewCell IsNot Nothing, e.NewCell.ColumnInfo, Nothing))
    End Sub
    Private Sub UpdateState(ByVal row As GridViewRowInfo, ByVal column As GridViewColumn)
        If row IsNot Nothing AndAlso column IsNot Nothing Then
            'Me.radTextBoxRowError.Text = row.ErrorText
            'Me.radTextBoxCellError.Text = row.Cells(column.Name).ErrorText

            Dim isEnabled As Boolean = (Not String.IsNullOrEmpty(row.ErrorText)) OrElse Not String.IsNullOrEmpty(row.Cells(column.Name).ErrorText)

            Dim dataErrorInfo As IDataErrorInfo = TryCast(row.DataBoundItem, IDataErrorInfo)

            If dataErrorInfo IsNot Nothing AndAlso isEnabled Then
                Dim [error] As String = dataErrorInfo(column.Name)
                isEnabled = String.IsNullOrEmpty([error])
            End If

            'Me.radButtonClear.Enabled = isEnabled
            'Me.UpdateSetButtonState()

            'Me.radTextBoxRowError.Enabled = True
            'Me.radTextBoxCellError.Enabled = True
        Else
            'Me.radButtonClear.Enabled = False
            'Me.radButtonSet.Enabled = False
            'Me.radTextBoxCellError.Enabled = False
            'Me.radTextBoxRowError.Enabled = False
        End If
    End Sub

    Private Sub GrdViewItemPrice_Click(sender As Object, e As EventArgs) Handles GrdViewItemPrice.Click

    End Sub

    Private Sub GrdViewItemPrice_CellPaint(sender As Object, e As GridViewCellPaintEventArgs) Handles GrdViewItemPrice.CellPaint

    End Sub
End Class
