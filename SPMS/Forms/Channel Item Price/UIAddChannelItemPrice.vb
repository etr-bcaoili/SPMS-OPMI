Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports ADODB
Imports Telerik.WinControls.UI
Public Class UIAddChannelItemPrice
    Private _ChannelItemPrice As New ChannelItemPrice
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private table As New DataTable
    Private m_ItemID As Integer = -1
    Private m_ChannelCode As String = String.Empty
    Private m_ChannelName As String = String.Empty

    Public Property ChannelCode As String
        Get
            Return m_ChannelCode
        End Get
        Set(value As String)
            m_ChannelCode = value
        End Set
    End Property
    Public Property ChannelName As String
        Get
            Return m_ChannelName
        End Get
        Set(value As String)
            m_ChannelName = value
        End Set
    End Property


    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnFind.Enabled = Not IsEditMode
        btnAddItemPrice.Enabled = IsEditMode


        txtChanneCode.ReadOnly = Not IsEditMode
        txtChanneCode.BackColor = Color.White

        txtChannelName.ReadOnly = Not IsEditMode
        txtChannelName.BackColor = Color.White

        txtItemCode.ReadOnly = Not IsEditMode
        txtItemCode.BackColor = Color.White

        txtItemDescription.ReadOnly = Not IsEditMode
        txtItemDescription.BackColor = Color.White

        txtParentItemCode.ReadOnly = Not IsEditMode
        txtParentItemCode.BackColor = Color.White

        txtParentItemDescription.ReadOnly = Not IsEditMode
        txtParentItemDescription.BackColor = Color.White

        txtPrice.ReadOnly = Not IsEditMode
        txtPrice.BackColor = Color.DarkOrange
        txtPrice.Select()
    End Sub
    Private Sub Clear()
        txtChanneCode.Text = String.Empty
        txtChannelName.Text = String.Empty
        txtItemCode.Text = String.Empty
        txtItemDescription.Text = String.Empty
        txtParentItemCode.Text = String.Empty
        txtParentItemDescription.Text = String.Empty
        txtPrice.Text = "0.00"
        dtStartDate.Text = Date.Now
        dtEndDate.Text = Date.Now

    End Sub
    Private Sub NewRecord()
        Clear()
        _ChannelItemPrice = New ChannelItemPrice
        EditMode(True)
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click, btnClear.Click, btnClose.Click, btnItemPriceApproved.Click, btnAddItemPrice.Click
        If sender Is btnFind Then
            Find()
        ElseIf sender Is btnClear Then
            Clear()
            EditMode(False)
        ElseIf sender Is btnClose Then
            Close()
        ElseIf sender Is btnAddItemPrice Then
            If ValidateData() Then
                AddChannelItemPrice()
            End If
        ElseIf sender Is btnItemPriceApproved Then
            If ValidateData() Then
                ChannelPriceApproved()
            End If
        End If
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ChannelItemPrice.GetItem, "Item")
        If Not tag Is Nothing Then
            ShowDataItem(tag.KeyColumn11)
            EditMode(True)
        End If
    End Sub
    'Private Sub Delete()
    '    If ShowDeleteDialog() = MsgBoxResult.Yes Then
    '        If _ChannelItemPrice.Delete Then
    '            DeleteSuccess()
    '            Clear()
    '            EditMode(False)
    '        End If
    '    End If
    'End Sub
    Private Sub ShowDataItem(ByVal ItemID As String)
        table = GetRecords(ChannelItemPrice.GetSelectItem(ItemID))
        For i As Integer = 0 To table.Rows.Count - 1
            m_ItemID = table.Rows(i)("ID")
            txtItemCode.Text = table.Rows(i)("ITEMCD")
            txtItemDescription.Text = table.Rows(i)("IMDBRN2")
            txtParentItemCode.Text = table.Rows(i)("itemthr")
            txtParentItemDescription.Text = table.Rows(i)("ITEMMDES")
            txtProductGroup.Text = table.Rows(i)("ITEMDIVCD")
        Next
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        ''''Show the Entry
        'Clear()
        'If RecordCode < 1 Then Exit Sub
        '_ChannelItemPrice = ChannelItemPrice.Load(RecordCode)
        'txtCode.Tag = _UnitOfMeasurement.UnitOfMeasurementID
        'txtCode.Text = _UnitOfMeasurement.Code
        'txtDescription.Text = _UnitOfMeasurement.DescriptionName
        'EditMode(False)
    End Sub

    Private Sub UIAddChannelItemPrice_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadProperties()
    End Sub
    Private Sub LoadProperties()
        txtPrice.BackColor = Color.DarkOrange
        dtStartDate.Text = Date.Now
        dtEndDate.Text = Date.Now
        txtPrice.Text = "0.00"
        txtChanneCode.Text = ChannelCode
        txtChannelName.Text = ChannelName
    End Sub

    Private Sub AddChannelItemPrice()
        Dim rowInfo As GridViewRowInfo = GrdMainView.Rows.AddNew
        rowInfo.Cells(0).Value = False
        rowInfo.Cells(1).Value = txtParentItemCode.Text
        rowInfo.Cells(2).Value = txtParentItemDescription.Text
        rowInfo.Cells(3).Value = txtItemCode.Text
        rowInfo.Cells(4).Value = txtPrice.Text
        rowInfo.Cells(5).Value = dtStartDate.Text
        rowInfo.Cells(6).Value = dtEndDate.Text
        If chkIsActive.Enabled = True Then
            rowInfo.Cells(7).Value = "Active"
        Else
            rowInfo.Cells(7).Value = "IsActive"
        End If
    End Sub
    Private Sub LoadChannelItemprice()
        table = GetRecords(ChannelItemPrice.GetChannelItemPriceViewSql)
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowInfo As GridViewRowInfo = GrdMainView.Rows.AddNew
            rowInfo.Cells(0).Value = False
            rowInfo.Cells(1).Value = table.Rows(i)("ItemMotherCode")
            rowInfo.Cells(2).Value = table.Rows(i)("ITEMMDES")
            rowInfo.Cells(3).Value = table.Rows(i)("ItemCode")
            rowInfo.Cells(4).Value = table.Rows(i)("Price")
            rowInfo.Cells(5).Value = table.Rows(i)("StartDate")
            rowInfo.Cells(6).Value = table.Rows(i)("EndDate")
            rowInfo.Cells(7).Value = table.Rows(i)("IsActive")
            rowInfo.Cells(8).Value = m_ItemID
        Next
    End Sub

    Private Sub ChannelPriceApproved()
        _ChannelItemPrice = New ChannelItemPrice
        For a As Integer = 0 To GrdMainView.Rows.Count - 1
            Dim rowInfos As GridViewRowInfo = GrdMainView.Rows(a)
            _ChannelItemPrice.ChannelCode = txtChanneCode.Text
            _ChannelItemPrice.ItemMotherCode = rowInfos.Cells(1).Value
            _ChannelItemPrice.ItemCode = rowInfos.Cells(3).Value
            _ChannelItemPrice.StartDate = rowInfos.Cells(5).Value
            _ChannelItemPrice.EndDate = rowInfos.Cells(6).Value
            _ChannelItemPrice.Price = rowInfos.Cells(4).Value
            _ChannelItemPrice.ChannelItemStatusID = 1
            _ChannelItemPrice.ReferenceItemID = rowInfos.Cells(8).Value
            _ChannelItemPrice.Save()
        Next
    End Sub
    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
        Dim selectedRow As GridViewRowInfo = GrdMainView.CurrentRow
        If selectedRow IsNot Nothing AndAlso Not TypeOf selectedRow Is GridViewNewRowInfo Then
            GrdMainView.Rows.Remove(selectedRow)
        Else
            MessageBox.Show("Please select a valid row to remove.")
        End If
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If txtItemCode.Text = "" Then
            m_Err.SetError(txtItemCode, "Code is Required")
            m_HasError = True
        Else
            If ChannelItemPrice.GetValidateChannelItemPrice(txtChanneCode.Text, txtItemCode.Text, txtParentItemCode.Text) = False Then
                m_Err.SetError(txtItemCode, "Item not found in ChannelItemPrice.")
                m_HasError = True
            End If
        End If

        If txtPrice.Text = "" Then
            m_Err.SetError(txtPrice, "Please provide a price, even if it's zero.")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
End Class