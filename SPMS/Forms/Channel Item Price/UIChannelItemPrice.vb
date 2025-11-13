Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing
Imports System.Text
Imports Telerik.WinControls.UI
Imports System.Windows.Forms
Imports Telerik.WinControls
Imports System.Drawing.Drawing2D
Public Class UIChannelItemPrice
    Dim table As New DataTable
    Private _ChannelCode As String = String.Empty
    Private _EndDate As String = String.Empty

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainFind.Click, btnMainAdjustedEndDate.Click
        If sender Is btnMainFind Then
            Find()
        ElseIf sender Is btnMainAdjustedEndDate Then
            ''Delete()
        End If
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ChannelItemPrice.GetChannelItemPriceViewSql, "Channel Item Price")
        If Not tag Is Nothing Then
            _ChannelCode = tag.KeyColumn22
            _EndDate = Year(tag.KeyColumn44)
            GetMainSpecificChannelItemPriceView(_ChannelCode, _EndDate)
            GetCloseSpecificChannekItemPriceView(_ChannelCode, _EndDate)
        End If
    End Sub
    Private Sub GetMainSpecificChannelItemPriceView(ByVal ChannelCode As String, ByVal EndDate As String)
        GrdMainView.Rows.Clear()
        table = GetRecords(ChannelItemPrice.GetSpecificChannelItemPriceSql(ChannelCode, EndDate))
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowInfo As GridViewRowInfo = GrdMainView.Rows.AddNew
            _ChannelCode = table.Rows(i)("ChannelCode")
            txtChannelName.Text = table.Rows(i)("DISTNAME")
            rowInfo.Cells(0).Value = False
            rowInfo.Cells(1).Value = table.Rows(i)("ItemMotherCode")
            rowInfo.Cells(2).Value = table.Rows(i)("ITEMMDES")
            rowInfo.Cells(3).Value = table.Rows(i)("ItemCode")
            rowInfo.Cells(4).Value = table.Rows(i)("Price")
            rowInfo.Cells(5).Value = table.Rows(i)("StartDate")
            rowInfo.Cells(6).Value = table.Rows(i)("EndDate")
            If table.Rows(i)("IsActive") = True Then
                rowInfo.Cells(7).Value = "Active"
            Else
                rowInfo.Cells(7).Value = "IsActive"
            End If

            rowInfo.Cells(4).Style.BackColor = Color.LightBlue
        Next
    End Sub
    Private Sub GetCloseSpecificChannekItemPriceView(ByVal ChannelCode As String, ByVal EndDate As String)
        GrdCloseView.Rows.Clear()
        table = GetRecords(ChannelItemPrice.GetCloseSpecificChannelItemPriceSql(ChannelCode, EndDate))
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowInfo As GridViewRowInfo = GrdCloseView.Rows.AddNew
            _ChannelCode = table.Rows(i)("ChannelCode")
            txtChannelName.Text = table.Rows(i)("DISTNAME")
            rowInfo.Cells(0).Value = False
            rowInfo.Cells(1).Value = table.Rows(i)("ItemMotherCode")
            rowInfo.Cells(2).Value = table.Rows(i)("ITEMMDES")
            rowInfo.Cells(3).Value = table.Rows(i)("ItemCode")
            rowInfo.Cells(4).Value = table.Rows(i)("Price")
            rowInfo.Cells(5).Value = table.Rows(i)("StartDate")
            rowInfo.Cells(6).Value = table.Rows(i)("EndDate")
            If table.Rows(i)("IsActive") = True Then
                rowInfo.Cells(7).Value = "Active"
            Else
                rowInfo.Cells(7).Value = "IsActive"
            End If

            rowInfo.Cells(4).Style.BackColor = Color.LightBlue
        Next
    End Sub
    Private Sub GrdMainView_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles GrdMainView.CellFormatting
        If e.CellElement.ColumnInfo.Name = "Price" Then ' Use column **name**, not index
            e.CellElement.BackColor = Color.LightBlue
            e.CellElement.DrawFill = True ' IMPORTANT: must be enabled to show color
        Else
            e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
            e.CellElement.DrawFill = False
        End If
    End Sub

    Private Sub btnMainAddItem_Click(sender As Object, e As EventArgs) Handles btnMainAddItem.Click
        Dim AddChannelItem As New UIAddChannelItemPrice
        AddChannelItem.ChannelCode = _ChannelCode
        AddChannelItem.ChannelName = txtChannelName.Text
        AddChannelItem.ShowDialog()
    End Sub
End Class
