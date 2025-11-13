Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports Telerik.WinControls.UI
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports Infragistics.Win.FormattedLinkLabel
Imports DataLayer
Imports SPMSOPCI.MainWindow
Public Class UIProductManagerMapping
    Private _ProductManager As New ProductManager
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private table As New DataTable
    Private _ProductManagerItemMapping As New ProductManagerMapping

    Private Sub LoadItemUnmapped()
        table = GetRecords(Items.GetItemlistWithProductGroup())
        GrdViewUnmapped.Rows.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowInfo As GridViewRowInfo = GrdViewUnmapped.Rows.AddNew
            rowInfo.Cells(0).Value = False
            rowInfo.Cells(1).Value = table.Rows(i)("Item Code")
            rowInfo.Cells(2).Value = table.Rows(i)("Item Description Name")
            rowInfo.Cells(3).Value = table.Rows(i)("Product Group")
        Next
    End Sub

    Private Sub btnAccept_Click_1(sender As Object, e As EventArgs) Handles btnAccept.Click
        For m As Integer = 0 To GrdViewUnmapped.Rows.Count - 1
            Dim row As GridViewRowInfo = GrdViewUnmapped.Rows(m)
            If row.Cells(0).Value = True Then
                Dim itemCode As String = row.Cells(1).Value.ToString()
                Dim ItemCodeName As String = row.Cells(2).Value.ToString()

                ' Check if the item code already exists
                Dim isAlreadyExists As Boolean = False
                For Each existingRow As GridViewRowInfo In GrdviewItemMapping.Rows
                    If existingRow.Cells(1).Value.ToString() = itemCode Then
                        isAlreadyExists = True
                        Exit For
                    End If
                Next

                If Not isAlreadyExists Then
                    Dim rowInfo As GridViewRowInfo = GrdviewItemMapping.Rows.AddNew
                    rowInfo.Cells(0).Value = False
                    rowInfo.Cells(1).Value = itemCode
                    rowInfo.Cells(2).Value = row.Cells(2).Value
                    rowInfo.Cells(3).Value = Date.Now.ToShortDateString
                    rowInfo.Cells(4).Value = Date.Now.ToShortDateString
                Else
                    MessageBox.Show("Item Details " & itemCode & " " & ItemCodeName & " already exists in the mapping.")
                End If

                ' Uncheck this row only
                row.Cells(0).Value = False
            End If
        Next

        'For m As Integer = 0 To GrdViewUnmapped.Rows.Count - 1
        '    Dim row As GridViewRowInfo = GrdViewUnmapped.Rows(m)
        '    If row.Cells(0).Value = True Then
        '        Dim itemCode As String = row.Cells(1).Value.ToString()
        '        Dim ItemCodeName As String = row.Cells(2).Value.ToString()   ' Assuming item code is in the second column

        '        ' Check if the item code already exists in GrdviewItemMapping
        '        Dim isAlreadyExists As Boolean = False
        '        For Each existingRow As GridViewRowInfo In GrdviewItemMapping.Rows
        '            If existingRow.Cells(1).Value.ToString() = itemCode Then
        '                isAlreadyExists = True
        '                Exit For
        '            End If
        '        Next

        '        If Not isAlreadyExists Then
        '            Dim rowInfo As GridViewRowInfo = GrdviewItemMapping.Rows.AddNew
        '            rowInfo.Cells(0).Value = False
        '            rowInfo.Cells(1).Value = itemCode
        '            rowInfo.Cells(2).Value = row.Cells(2).Value  ' Assuming other details are in the third column
        '            rowInfo.Cells(3).Value = Date.Now.ToShortDateString
        '            rowInfo.Cells(4).Value = Date.Now.ToShortDateString

        '        Else
        '            'Handle case where item code already exists (e.g., Show message, skip adding, etc.)
        '            ' Example:
        '            MessageBox.Show("Item Details " & itemCode & " " & ItemCodeName & " already exists in the mapping.")
        '        End If
        '    End If
        'Next

        'For m As Integer = 0 To GrdViewUnmapped.Rows.Count - 1
        '    Dim row As GridViewRowInfo = GrdViewUnmapped.Rows(m)
        '    row.Cells(0).Value = False
        'Next
    End Sub

    Private Sub lnkMotherCode_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkMotherCode.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ProductManager.GetProductManagerSql, "Product Manager")
        If Not tag Is Nothing Then
            txtProductManagerCode.Text = tag.KeyColumn22
            txtProductManagerName.Text = tag.KeyColumn33
            LoadProudctManagerItemMapping(tag.KeyColumn22)
            LoadItemUnmapped()
        End If
    End Sub
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnNew.Enabled = Not IsEditMode

        txtProductManagerCode.ReadOnly = Not IsEditMode
        txtProductManagerCode.BackColor = Color.White

        txtProductManagerName.ReadOnly = Not IsEditMode
        txtProductManagerName.BackColor = Color.White
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnFinddata.Click, btnSave.Click, btnClear.Click, btnClose.Click
        If sender Is btnClear Then
            Clear()
            EditMode(False)
        ElseIf sender Is btnNew Then
            Clear()
            EditMode(True)
            LoadItemUnmapped()
        ElseIf sender Is btnClose Then
            Close()
        ElseIf sender Is btnFinddata Then
            Find()
        ElseIf sender Is btnSave Then
            If ValidateData() Then
                SaveRecord()
            End If
        End If
    End Sub

    Private Sub Clear()
        txtProductManagerCode.Text = String.Empty
        txtProductManagerName.Text = String.Empty
        GrdViewUnmapped.Rows.Clear()
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If txtProductManagerCode.Text = "" Then
            m_Err.SetError(txtProductManagerCode, "Product Manager Code is Required!")
            m_HasError = True
        End If

        If txtProductManagerName.Text = "" Then
            m_Err.SetError(txtProductManagerName, "Product Manager Name is Required!")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
    Private Sub SaveRecord()
        _ProductManagerItemMapping.Delete()
        For m As Integer = 0 To GrdviewItemMapping.Rows.Count - 1
            Dim row As GridViewRowInfo = GrdviewItemMapping.Rows(m)
            _ProductManagerItemMapping = New ProductManagerMapping
            _ProductManagerItemMapping.PriductManagerCode = txtProductManagerCode.Text
            _ProductManagerItemMapping.ProductManagerName = txtProductManagerName.Text
            _ProductManagerItemMapping.ItemCode = row.Cells(1).Value
            _ProductManagerItemMapping.ItemDescriptionName = row.Cells(2).Value
            _ProductManagerItemMapping.EffectivityStartDate = row.Cells(3).Value
            _ProductManagerItemMapping.EffectivityEndDate = row.Cells(4).Value
            _ProductManagerItemMapping.Createby = MainWindow.MainUserName
            _ProductManagerItemMapping.Createby = MainWindow.MainUserName
            _ProductManagerItemMapping.Save()
        Next
        SaveSuccess()
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ProductManagerMapping.GetProductManagerItemMappingSql, "Product Manager")
        If Not tag Is Nothing Then
            Clear()
            txtProductManagerCode.Text = tag.KeyColumn22
            txtProductManagerName.Text = tag.KeyColumn33
            LoadProudctManagerItemMapping(tag.KeyColumn22)
            LoadItemUnmapped()
            EditMode(True)
        End If
    End Sub
    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Sub LoadProudctManagerItemMapping(ByVal ProductManagerItemMappingCode As String)
        table = GetRecords(ProductManagerMapping.GetProductManagerItemMapping(ProductManagerItemMappingCode))
        GrdviewItemMapping.Rows.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowInfo As GridViewRowInfo = GrdviewItemMapping.Rows.AddNew
            _ProductManagerItemMapping.PriductManagerCode = table.Rows(i)("PMCode")
            rowInfo.Cells(0).Value = False
            rowInfo.Cells(1).Value = table.Rows(i)("ItemMotherCode")
            rowInfo.Cells(2).Value = table.Rows(i)("ItemMotherName")
            rowInfo.Cells(3).Value = table.Rows(i)("StartDateEffectivity")
            rowInfo.Cells(4).Value = table.Rows(i)("EndDateEffectivity")
        Next
    End Sub

    Private Sub txtRemove_Click(sender As Object, e As EventArgs) Handles txtRemove.Click
        For m As Integer = GrdviewItemMapping.Rows.Count - 1 To 0 Step -1
            Dim row As GridViewRowInfo = GrdviewItemMapping.Rows(m)
            If row.Cells(0).Value = True Then
                GrdviewItemMapping.Rows.RemoveAt(m)
            End If
        Next

    End Sub

    Private Sub UIProductManagerMapping_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.GrdviewItemMapping.TableElement.RowHeight = 35
        Me.GrdViewUnmapped.TableElement.RowHeight = 35
    End Sub
End Class
