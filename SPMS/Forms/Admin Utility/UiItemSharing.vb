Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Telerik.WinControls.UI.VisualEffects

Public Class UiItemSharing
    Private _Employee As New MedicalRepresentative
    Private _ItemSharing As New ItemSharing
    Private _ConfigurationType As New Configuration
    Private m_CustomerShipTo As New CustomerShipTo
    Private m_Distributor As Distributor
    Private m_ItemSharing As New ItemSharing
    Private m_Items As New Items
    Dim table As New DataTable
    Dim tables As New DataTable

    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_CountRow As Integer = 0
    Private m_New_DataTable As Boolean = False
    Private Sub Clear()
        'txtConfigCode.Text = String.Empty
        'txtConfgName.Text = String.Empty
        txtItemCode.Text = String.Empty
        txtItemName.Text = String.Empty
        txtConfigCode.Text = String.Empty
        txtConfgName.Text = String.Empty
        DropYear.Text = String.Empty
        DropMonth.Text = String.Empty
        For m As Integer = 0 To GrdViewProductGroup.Rows.Count - 1
            Dim rowinfos As GridViewRowInfo = GrdViewProductGroup.Rows(m)
            rowinfos.Cells(0).Value = False
        Next
        ResetGridView()
        'GrdViewPMR.Rows.Clear()
        'GrdViewProductGroup.Rows.Clear()
    End Sub
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtConfigCode.ReadOnly = Not IsEditMode
        txtConfigCode.BackColor = Color.White

        txtItemCode.ReadOnly = Not IsEditMode
        txtItemCode.BackColor = Color.White

        txtItemName.ReadOnly = Not IsEditMode
        txtItemName.BackColor = Color.White

        GrdViewPMR.ReadOnly = Not IsEditMode
        GrdViewProductGroup.ReadOnly = Not IsEditMode
    End Sub
    Private Sub Findconfig_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Findconfig.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Medical Configuration")
        If Not tag Is Nothing Then
            txtConfigCode.Text = tag.KeyColumn11
            txtConfgName.Text = tag.KeyColumn33
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        _ItemSharing.ExecuteItemSharingWithSalesmatrix(txtConfigCode.Text)
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ItemSharing.GetItemDetailSql(txtConfigCode.Text), "Item Details")
        If Not tag Is Nothing Then
            txtItemCode.Text = tag.KeyColumn33
            txtItemName.Text = tag.KeyColumn44
            If ItemSharing.CheckofItemSharingPGAlreadyExist(txtConfigCode.Text, DropYear.Text, DropMonth.Text, txtItemCode.Text) Then
                tables = GetRecords(ItemSharing.GetItemSharingPGSql(txtConfigCode.Text, DropYear.Text, DropMonth.Text, txtItemCode.Text))
                For i As Integer = 0 To tables.Rows.Count - 1
                    LoadConfig(tables.Rows(i)("CONFIG"))
                    DropYear.Text = tables.Rows(i)("YEAR")
                    DropMonth.Text = tables.Rows(i)("MONTH")
                    LoadItem(tables.Rows(i)("ITEMCODE"))
                    For m As Integer = 0 To GrdViewProductGroup.Rows.Count - 1
                        Dim rowinfos As GridViewRowInfo = GrdViewProductGroup.Rows(m)
                        Dim PGCode As String = tables.Rows(i)("PGCODE")
                        If rowinfos.Cells(1).Value = PGCode Then
                            rowinfos.Cells(0).Value = True
                        End If
                    Next
                Next
                btnPMR.PerformClick()
            Else
                For m As Integer = 0 To GrdViewProductGroup.Rows.Count - 1
                    Dim rowinfos As GridViewRowInfo = GrdViewProductGroup.Rows(m)
                    If rowinfos.Cells(1).Value = tag.KeyColumn11 Then
                        rowinfos.Cells(0).Value = True
                    End If
                Next
                btnPMR.PerformClick()
            End If

        End If
    End Sub
    Private Sub UiItemSharing_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadProductGroup()
        LoadPMRList()
        LoadYear()
        lblErrormessage.Visible = False
    End Sub
    Private Sub LoadProductGroup()
        table = GetRecords(ProductItemGroup.GetProductGroupList)
        GrdViewProductGroup.Rows.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewProductGroup.Rows.AddNew
            rowinfo.Cells(0).Value = False
            rowinfo.Cells(1).Value = table.Rows(i)("PGCode")
            rowinfo.Cells(2).Value = table.Rows(i)("PGDescription")
        Next
    End Sub
    Private Sub LoadPMRList()
        table = GetRecords(ProductItemGroup.GetPMRList)
        GrdViewPMR.Rows.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewPMR.Rows.AddNew
            rowinfo.Cells(0).Value = table.Rows(i)("PMRAB")
            rowinfo.Cells(1).Value = 0
            rowinfo.Cells(2).Value = table.Rows(i)("PMRC")
            rowinfo.Cells(3).Value = 0
            rowinfo.Cells(4).Value = table.Rows(i)("PMRD")
            rowinfo.Cells(5).Value = 0
            rowinfo.Cells(6).Value = table.Rows(i)("PMREF")
            rowinfo.Cells(7).Value = 0
            rowinfo.Cells(8).Value = 0
            rowinfo.Cells(9).Value = table.Rows(i)("ID")
            rowinfo.Cells(10).Value = ""
        Next
    End Sub
    Private Sub LoadItemSharing()
        table = GetRecords(ItemSharing.GetItemSharingSql(txtConfigCode.Text, DropYear.Text, DropMonth.Text, txtItemCode.Text))
        GrdViewPMR.Rows.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewPMR.Rows.AddNew
            rowinfo.Cells(0).Value = table.Rows(i)("PMRAB")
            rowinfo.Cells(1).Value = table.Rows(i)("PMRABSHR")
            rowinfo.Cells(2).Value = table.Rows(i)("PMRC")
            rowinfo.Cells(3).Value = table.Rows(i)("PMRCSHR")
            rowinfo.Cells(4).Value = table.Rows(i)("PMRD")
            rowinfo.Cells(5).Value = table.Rows(i)("PMRDSHR")
            rowinfo.Cells(6).Value = table.Rows(i)("PMREF")
            rowinfo.Cells(7).Value = table.Rows(i)("PMREFSHR")
            rowinfo.Cells(8).Value = table.Rows(i)("TOTALSHR")
            rowinfo.Cells(9).Value = table.Rows(i)("SDI")
            rowinfo.Cells(10).Value = table.Rows(i)("ID")
        Next
        SetConditions()
    End Sub
    Private Sub SetConditions()
        Dim c4 As New ConditionalFormattingObject("", ConditionTypes.Equal, "0.0000", "", False)
        c4.RowBackColor = Color.FromArgb(251, 174, 210)
        c4.CellBackColor = Color.FromArgb(251, 174, 210)
        GrdViewPMR.Columns("column9").ConditionalFormattingObjectList.Add(c4)

        Dim Num1 As Double = "1.0000"
        Dim c2 As New ConditionalFormattingObject("", ConditionTypes.LessOrEqual, Num1, "", False)
        'c2.RowBackColor = Color.FromArgb(255, 0, 0)
        'c2.CellBackColor = Color.FromArgb(255, 0, 0)
        c2.RowBackColor = Color.FromArgb(251, 103, 189)
        c2.CellBackColor = Color.FromArgb(251, 103, 189)
        GrdViewPMR.Columns("column9").ConditionalFormattingObjectList.Add(c2)

        Dim Num2 As Double = "1.0000"
        Dim c3 As New ConditionalFormattingObject("", ConditionTypes.GreaterOrEqual, Num2, "", False)
        c3.RowBackColor = Color.FromArgb(255, 0, 0)
        c3.CellBackColor = Color.FromArgb(255, 0, 0)
        GrdViewPMR.Columns("column9").ConditionalFormattingObjectList.Add(c3)

        Dim Num3 As Double = "1.0000"
        Dim c5 As New ConditionalFormattingObject("Red", ConditionTypes.Equal, "1.0000", "", False)
        c5.RowBackColor = Color.FromArgb(219, 251, 91)
        'c5.RowBackColor = Color.FromArgb(255, 153, 0)
        c5.CellBackColor = Color.FromArgb(219, 251, 91)
        'c5.RowForeColor = Color.Black
        GrdViewPMR.Columns("column9").ConditionalFormattingObjectList.Add(c5)



    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Sub NewRecord()
        Clear()
        _ItemSharing = New ItemSharing
        EditMode(True)
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnDelete.Click, btnEdit.Click, btnFinddata.Click, btnSave.Click, btnClear.Click, btnClose.Click
        If sender Is btnNew Then
            NewRecord()
        ElseIf sender Is btnDelete Then
            Delete
        ElseIf sender Is btnEdit Then
            EditMode(True)
            'm_EditFile = True
        ElseIf sender Is btnClear Then
            Clear()
            EditMode(False)
            GrdViewPMR.ReadOnly = True
            GrdViewProductGroup.ReadOnly = True
        ElseIf sender Is btnClose Then
            Close()
        ElseIf sender Is btnFinddata Then
            Find()
        ElseIf sender Is btnSave Then
            If ValidationItemSharingFinal() Then
                ItemSharingAutoData()
                SavePG()
                SaveItemSharing()
                EditMode(False)
            End If
        End If
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ItemSharing.GetItemSharingListSql, "Item Sharing")
        If Not tag Is Nothing Then
            Clear()
            ShowDataItemSharingPG(tag.KeyColumn22, tag.KeyColumn33, tag.KeyColumn44, tag.KeyColumn55)
            ShowDataItemSharing(tag.KeyColumn22, tag.KeyColumn33, tag.KeyColumn44, tag.KeyColumn55)
            EditMode(False)
        End If
    End Sub
    Private Sub ShowDataItemSharingPG(ByVal Config As String, ByVal Year As String, ByVal Month As String, ByVal ItemCode As String)
        tables = GetRecords(ItemSharing.GetItemSharingPGSql(Config, Year, Month, ItemCode))
        For i As Integer = 0 To tables.Rows.Count - 1
            LoadConfig(tables.Rows(i)("CONFIG"))
            DropYear.Text = tables.Rows(i)("YEAR")
            DropMonth.Text = tables.Rows(i)("MONTH")
            LoadItem(tables.Rows(i)("ITEMCODE"))
            For m As Integer = 0 To GrdViewProductGroup.Rows.Count - 1
                Dim rowinfos As GridViewRowInfo = GrdViewProductGroup.Rows(m)
                Dim PGCode As String = tables.Rows(i)("PGCODE")
                If rowinfos.Cells(1).Value = PGCode Then
                    rowinfos.Cells(0).Value = True
                End If
            Next
        Next
        btnPMR.PerformClick()
    End Sub
    Private Sub LoadConfig(ByVal ConfigCode As String)
        _ConfigurationType = Configuration.LoadbyCode(ConfigCode)
        txtConfigCode.Text = _ConfigurationType.ConfigTypeCode
        txtConfgName.Text = _ConfigurationType.ConfigTypeName
    End Sub
    Private Sub LoadItem(ByVal ItemCode As String)
        m_Items = Items.LoadByCode(ItemCode)
        txtItemCode.Text = m_Items.ItemCode
        txtItemName.Text = m_Items.ItemBrand
    End Sub

    Private Sub ShowDataItemSharing(ByVal Config As String, ByVal Year As String, ByVal Month As String, ByVal ItemCode As String)
        table = GetRecords(ItemSharing.GetItemSharingSql(txtConfigCode.Text, DropYear.Text, DropMonth.Text, txtItemCode.Text))
        GrdViewPMR.Rows.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewPMR.Rows.AddNew
            rowinfo.Cells(0).Value = table.Rows(i)("PMRAB")
            rowinfo.Cells(1).Value = table.Rows(i)("PMRABSHR")
            rowinfo.Cells(2).Value = table.Rows(i)("PMRC")
            rowinfo.Cells(3).Value = table.Rows(i)("PMRCSHR")
            rowinfo.Cells(4).Value = table.Rows(i)("PMRD")
            rowinfo.Cells(5).Value = table.Rows(i)("PMRDSHR")
            rowinfo.Cells(6).Value = table.Rows(i)("PMREF")
            rowinfo.Cells(7).Value = table.Rows(i)("PMREFSHR")
            rowinfo.Cells(8).Value = table.Rows(i)("TOTALSHR")
            rowinfo.Cells(9).Value = table.Rows(i)("SDI")
            rowinfo.Cells(10).Value = table.Rows(i)("ID")
        Next
        SetConditions()
    End Sub
    Private Sub btnPMR_Click(sender As Object, e As EventArgs) Handles btnPMR.Click
        For m As Integer = 0 To GrdViewProductGroup.Rows.Count - 1
            Dim rowinfos As GridViewRowInfo = GrdViewProductGroup.Rows(m)
            If rowinfos.Cells(0).Value = True Then
                If rowinfos.Cells(1).Value = "PG-AB" Then
                    GrdViewPMR.Columns("column1").IsVisible = True
                    GrdViewPMR.Columns("column2").IsVisible = True
                End If
                If rowinfos.Cells(1).Value = "PG-C" Then
                    GrdViewPMR.Columns("column3").IsVisible = True
                    GrdViewPMR.Columns("column4").IsVisible = True
                End If
                If rowinfos.Cells(1).Value = "PG-D" Then
                    GrdViewPMR.Columns("column5").IsVisible = True
                    GrdViewPMR.Columns("column6").IsVisible = True
                End If
                If rowinfos.Cells(1).Value = "PG-EF" Then
                    GrdViewPMR.Columns("column7").IsVisible = True
                    GrdViewPMR.Columns("column8").IsVisible = True
                End If
            Else
                If rowinfos.Cells(1).Value = "PG-AB" Then
                    GrdViewPMR.Columns("column1").IsVisible = False
                    GrdViewPMR.Columns("column2").IsVisible = False
                End If
                If rowinfos.Cells(1).Value = "PG-C" Then
                    GrdViewPMR.Columns("column3").IsVisible = False
                    GrdViewPMR.Columns("column4").IsVisible = False
                End If
                If rowinfos.Cells(1).Value = "PG-D" Then
                    GrdViewPMR.Columns("column5").IsVisible = False
                    GrdViewPMR.Columns("column6").IsVisible = False
                End If
                If rowinfos.Cells(1).Value = "PG-EF" Then
                    GrdViewPMR.Columns("column7").IsVisible = False
                    GrdViewPMR.Columns("column8").IsVisible = False
                End If
            End If
        Next
        If ValidationItemSharing() Then
        End If
    End Sub
    Private Sub ResetGridView()
        For m As Integer = 0 To GrdViewProductGroup.Rows.Count - 1
            Dim rowinfos As GridViewRowInfo = GrdViewProductGroup.Rows(m)
            If rowinfos.Cells(0).Value = True Then
                If rowinfos.Cells(1).Value = "PG-AB" Then
                    GrdViewPMR.Columns("column1").IsVisible = True
                    GrdViewPMR.Columns("column2").IsVisible = True
                End If
                If rowinfos.Cells(1).Value = "PG-C" Then
                    GrdViewPMR.Columns("column3").IsVisible = True
                    GrdViewPMR.Columns("column4").IsVisible = True
                End If
                If rowinfos.Cells(1).Value = "PG-D" Then
                    GrdViewPMR.Columns("column5").IsVisible = True
                    GrdViewPMR.Columns("column6").IsVisible = True
                End If
                If rowinfos.Cells(1).Value = "PG-EF" Then
                    GrdViewPMR.Columns("column7").IsVisible = True
                    GrdViewPMR.Columns("column8").IsVisible = True
                End If
            Else
                If rowinfos.Cells(1).Value = "PG-AB" Then
                    GrdViewPMR.Columns("column1").IsVisible = False
                    GrdViewPMR.Columns("column2").IsVisible = False
                End If
                If rowinfos.Cells(1).Value = "PG-C" Then
                    GrdViewPMR.Columns("column3").IsVisible = False
                    GrdViewPMR.Columns("column4").IsVisible = False
                End If
                If rowinfos.Cells(1).Value = "PG-D" Then
                    GrdViewPMR.Columns("column5").IsVisible = False
                    GrdViewPMR.Columns("column6").IsVisible = False
                End If
                If rowinfos.Cells(1).Value = "PG-EF" Then
                    GrdViewPMR.Columns("column7").IsVisible = False
                    GrdViewPMR.Columns("column8").IsVisible = False
                End If
            End If
        Next
        For m As Integer = 0 To GrdViewPMR.Rows.Count - 1
            Dim rowinfos As GridViewRowInfo = GrdViewPMR.Rows(m)
            rowinfos.Cells(1).Value = "0.0000"
            rowinfos.Cells(3).Value = "0.0000"
            rowinfos.Cells(5).Value = "0.0000"
            rowinfos.Cells(7).Value = "0.0000"
            rowinfos.Cells(8).Value = "0.0000"
        Next
    End Sub
    Private Function ValidationItemSharingFinal() As Boolean
        m_HasError = False

        If txtConfigCode.Text = "" Then
            m_Err.SetError(txtConfigCode, "Configtype Code is Required!")
            m_HasError = True
        End If

        If txtItemCode.Text = "" Then
            m_Err.SetError(txtItemCode, "Item Code is Required!")
            m_HasError = True
        End If

        If DropYear.Text = "" Then
            m_Err.SetError(DropYear, "Year is Required!")
            m_HasError = True
        End If

        If DropMonth.Text = "" Then
            m_Err.SetError(DropMonth, "Month is Required!")
            m_HasError = True
        End If

        For m As Integer = 0 To GrdViewPMR.Rows.Count - 1
            Dim rowinfos As GridViewRowInfo = GrdViewPMR.Rows(m)
            Dim pershr As Double = rowinfos.Cells(8).Value
            Dim pershr2 As Double = 100 * pershr
            If pershr2 = 0 Then
                pershr2 = 100
            End If
            If pershr2 <> 100 Then
                lblErrormessage.Visible = True
                m_HasError = True
                Exit Function
            End If
            'If pershr <> 0 AndAlso 1 Then
            '    lblErrormessage.Visible = True
            '    m_HasError = True
            '    Exit Function
            'End If
        Next
        Return Not m_HasError
    End Function
    Private Function ValidationItemSharing() As Boolean
        m_HasError = False

        If txtConfigCode.Text = "" Then
            m_Err.SetError(txtConfigCode, "Configtype Code is Required!")
            m_HasError = True
        End If

        If txtItemCode.Text = "" Then
            m_Err.SetError(txtItemCode, "Item Code is Required!")
            m_HasError = True
        End If

        If DropYear.Text = "" Then
            m_Err.SetError(DropYear, "Year is Required!")
            m_HasError = True
        End If

        If DropMonth.Text = "" Then
            m_Err.SetError(DropMonth, "Month is Required!")
            m_HasError = True
        End If

        If ItemSharing.CheckofItemSharingAlreadyExist(txtConfigCode.Text, DropYear.Text, DropMonth.Text, txtItemCode.Text) Then
            LoadItemSharing()
            AutoDataModify()
        Else
            AutoData()
            LoadItemSharing()
        End If
        Return Not m_HasError
    End Function
    Private Sub SavePG()
        ItemSharing.DeleteFromProductGroup(txtConfigCode.Text, DropYear.Text, DropMonth.Text, txtItemCode.Text)
        For r As Integer = 0 To GrdViewProductGroup.Rows.Count - 1
            Dim rowPG As GridViewRowInfo = GrdViewProductGroup.Rows(r)
            If rowPG.Cells(0).Value = True Then
                _ItemSharing = New ItemSharing
                _ItemSharing.Config = txtConfigCode.Text
                _ItemSharing.Year = DropYear.Text
                _ItemSharing.Month = DropMonth.Text
                _ItemSharing.ItemCode = txtItemCode.Text
                _ItemSharing.PGCode = rowPG.Cells(1).Value
                _ItemSharing.SavePG()
            End If
        Next
    End Sub
    Private Sub SaveItemSharing()
        _ItemSharing = New ItemSharing
        _ItemSharing.Config = txtConfigCode.Text
        _ItemSharing.Year = DropYear.Text
        _ItemSharing.Month = DropMonth.Text
        _ItemSharing.ItemCode = txtItemCode.Text
        _ItemSharing.SaveItemSharing()
    End Sub
    Private Sub AutoData()
        For a As Integer = 0 To GrdViewPMR.Rows.Count - 1
            Dim rowPMR As GridViewRowInfo = GrdViewPMR.Rows(a)
            _ItemSharing = New ItemSharing
            _ItemSharing.Config = txtConfigCode.Text
            _ItemSharing.Year = DropYear.Text
            _ItemSharing.Month = DropMonth.Text
            _ItemSharing.ItemCode = txtItemCode.Text
            _ItemSharing.SDI = rowPMR.Cells(9).Value
            _ItemSharing.PMRAB = rowPMR.Cells(0).Value
            _ItemSharing.PMRABSHR = rowPMR.Cells(1).Value
            _ItemSharing.PMRC = rowPMR.Cells(2).Value
            _ItemSharing.PMRCSHR = rowPMR.Cells(3).Value
            _ItemSharing.PMRD = rowPMR.Cells(4).Value
            _ItemSharing.PMRDSHR = rowPMR.Cells(5).Value
            _ItemSharing.PMREF = rowPMR.Cells(6).Value
            _ItemSharing.PMREFSHR = rowPMR.Cells(7).Value
            _ItemSharing.TOTALSHR = rowPMR.Cells(8).Value
            _ItemSharing.Save()
        Next
    End Sub

    Private Sub ItemSharingAutoData()
        ItemSharing.DeleteFromItemSharingCollection(txtConfigCode.Text, DropYear.Text, DropMonth.Text, txtItemCode.Text)
        For a As Integer = 0 To GrdViewPMR.Rows.Count - 1
            Dim rowPMR As GridViewRowInfo = GrdViewPMR.Rows(a)
            _ItemSharing = New ItemSharing
            _ItemSharing.Config = txtConfigCode.Text
            _ItemSharing.Year = DropYear.Text
            _ItemSharing.Month = DropMonth.Text
            _ItemSharing.ItemCode = txtItemCode.Text
            _ItemSharing.SDI = rowPMR.Cells(9).Value
            _ItemSharing.PMRAB = rowPMR.Cells(0).Value
            _ItemSharing.PMRABSHR = rowPMR.Cells(1).Value
            _ItemSharing.PMRC = rowPMR.Cells(2).Value
            _ItemSharing.PMRCSHR = rowPMR.Cells(3).Value
            _ItemSharing.PMRD = rowPMR.Cells(4).Value
            _ItemSharing.PMRDSHR = rowPMR.Cells(5).Value
            _ItemSharing.PMREF = rowPMR.Cells(6).Value
            _ItemSharing.PMREFSHR = rowPMR.Cells(7).Value
            _ItemSharing.TOTALSHR = rowPMR.Cells(8).Value
            _ItemSharing.Save()
        Next
        SaveSuccess()
        lblErrormessage.Visible = False
    End Sub
    Private Sub AutoDataModify()
        Dim PMRABSHR As Double = 0
        Dim PMRCSHR As Double = 0
        Dim PMRDSHR As Double = 0
        Dim PMREFSHR As Double = 0
        Dim TOTALSHR As Double = 0
        For a As Integer = 0 To GrdViewPMR.Rows.Count - 1
            Dim rowPMR As GridViewRowInfo = GrdViewPMR.Rows(a)
            _ItemSharing.Config = txtConfigCode.Text
            _ItemSharing.Year = DropYear.Text
            _ItemSharing.Month = DropMonth.Text
            _ItemSharing.ItemCode = txtItemCode.Text
            _ItemSharing.SDI = rowPMR.Cells(9).Value
            _ItemSharing.PMRAB = rowPMR.Cells(0).Value
            _ItemSharing.PMRABSHR = rowPMR.Cells(1).Value
            PMRABSHR = rowPMR.Cells(1).Value
            _ItemSharing.PMRC = rowPMR.Cells(2).Value
            _ItemSharing.PMRCSHR = rowPMR.Cells(3).Value
            PMRCSHR = rowPMR.Cells(3).Value
            _ItemSharing.PMRD = rowPMR.Cells(4).Value
            _ItemSharing.PMRDSHR = rowPMR.Cells(5).Value
            PMRDSHR = rowPMR.Cells(5).Value
            _ItemSharing.PMREF = rowPMR.Cells(6).Value
            _ItemSharing.PMREFSHR = rowPMR.Cells(7).Value
            PMREFSHR = rowPMR.Cells(7).Value
            TOTALSHR = PMRABSHR + PMRCSHR + PMRDSHR + PMREFSHR
            _ItemSharing.TOTALSHR = TOTALSHR
            _ItemSharing.IDS = rowPMR.Cells(10).Value
            _ItemSharing.Update()
        Next
    End Sub
    Private Sub LoadYear()
        table = GetRecords("Select Distinct CAYR from Calendar Order by CAYR")
        DropYear.Items.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            DropYear.Items.Add(table.Rows(i)("CAYR"))
        Next
    End Sub
    Private Sub LoadMonth(ByVal Year As String)
        table = GetRecords("Select Distinct CAPN from Calendar Where CAYR = '" & Year & "' Order by CAPN")
        DropMonth.Items.Clear()
        For I As Integer = 0 To table.Rows.Count - 1
            DropMonth.Items.Add(table.Rows(I)("CAPN"))
        Next
    End Sub
    Private Sub GrdViewPMR_CellClick(sender As Object, e As GridViewCellEventArgs) Handles GrdViewPMR.CellClick
        For a As Integer = 0 To GrdViewPMR.Rows.Count - 1
            Dim rowPMR As GridViewRowInfo = GrdViewPMR.Rows(a)
        Next
    End Sub

    Private Sub DropYear_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles DropYear.SelectedIndexChanged
        If DropYear.SelectedIndex = -1 Then Exit Sub
        LoadMonth(DropYear.Text)
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        AutoDataModify()
    End Sub
    Private Sub UpdateState(ByVal row As GridViewRowInfo, ByVal column As GridViewColumn)
        If row IsNot Nothing AndAlso column IsNot Nothing Then
            Dim isEnabled As Boolean = (Not String.IsNullOrEmpty(row.ErrorText)) OrElse Not String.IsNullOrEmpty(row.Cells(column.Name).ErrorText)
        End If
    End Sub
    Private Sub GridViewPMR_CurrentCellChanged(ByVal sender As Object, ByVal e As CurrentCellChangedEventArgs)
        UpdateState(If(e.NewCell IsNot Nothing, e.NewCell.RowInfo, Nothing), If(e.NewCell IsNot Nothing, e.NewCell.ColumnInfo, Nothing))
    End Sub
    Private Sub GrdViewPMR_CellFormatting(sender As Object, e As CellFormattingEventArgs) Handles GrdViewPMR.CellFormatting
        Dim cell As GridDataCellElement = TryCast(e.CellElement, GridDataCellElement)
        If cell IsNot Nothing Then
            If cell.ContainsErrors Then
                cell.DrawBorder = True
                cell.BorderBoxStyle = BorderBoxStyle.SingleBorder
                cell.BorderBottomColor = Color.Transparent
                cell.BorderTopColor = Color.Transparent
                cell.BorderRightShadowColor = Color.Transparent
                cell.BorderLeftShadowColor = Color.Transparent
                cell.BorderTopShadowColor = Color.Transparent
                cell.BorderBottomShadowColor = Color.Red
                cell.BorderTopShadowColor = Color.Red
                cell.BorderRightColor = Color.Red
                cell.BorderLeftColor = Color.Red
                cell.BorderBottomWidth = 1
                cell.BorderTopWidth = 1
                cell.BorderRightWidth = 1
                cell.BorderLeftWidth = 1

                cell.BorderDrawMode = BorderDrawModes.HorizontalOverVertical
                cell.ZIndex = 2
            Else
                cell.ResetValue(LightVisualElement.DrawBorderProperty, ValueResetFlags.Local)
                cell.ResetValue(LightVisualElement.BorderBoxStyleProperty, ValueResetFlags.Local)
                cell.ResetValue(LightVisualElement.BorderWidthProperty, ValueResetFlags.Local)
                cell.ResetValue(LightVisualElement.BorderColorProperty, ValueResetFlags.Local)
            End If
        End If
    End Sub

    Private Sub GrdViewPMR_CellEndEdit(sender As Object, e As GridViewCellEventArgs) Handles GrdViewPMR.CellEndEdit
        AutoDataModify()
        LoadItemSharing()
    End Sub

    Private Sub Delete()
        If txtConfigCode.Text <> "" Or txtItemCode.Text <> "" And DropYear.Text <> "" Or DropMonth.Text <> "" Then
            ItemSharing.DeleteFromItemSharingCollection(txtConfigCode.Text, DropYear.Text, DropMonth.Text, txtItemCode.Text)
            ItemSharing.DeleteItemSharingMajorCollection(txtConfigCode.Text, DropYear.Text, DropMonth.Text, txtItemCode.Text)
            ItemSharing.DeleteItemSharingJoniorCollection(txtConfigCode.Text, DropYear.Text, DropMonth.Text, txtItemCode.Text)
            ItemSharing.DeleteFromItemSharingSC03(txtConfigCode.Text, DropYear.Text, DropMonth.Text, txtItemCode.Text)
            DeleteSuccess()
        Else
            UnDeleteSuccess()
        End If
    End Sub

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        If ValidationProcess Then
            InsertTheItemSharing(txtConfigCode.Text, DropYear.Text, DropMonth.Text, txtItemCode.Text)
            GetPerPMRItemSharing(txtConfigCode.Text, DropYear.Text, DropMonth.Text, txtItemCode.Text)
            InsertSC03()
        End If
    End Sub
    Private Sub InsertTheItemSharing(ByVal ConfigtypeCode As String, ByVal Year As String, Month As String, ByVal ItemCode As String)
        ItemSharing.DeleteFromItemSharingSC03(txtConfigCode.Text, DropYear.Text, DropMonth.Text, txtItemCode.Text)
        m_ItemSharing = New ItemSharing
        m_ItemSharing.Config = ConfigtypeCode
        m_ItemSharing.Year = Year
        m_ItemSharing.Month = Month
        m_ItemSharing.ItemCode = ItemCode
        m_ItemSharing.InsertItemSharingMajor()

        m_ItemSharing = New ItemSharing
        m_ItemSharing.Config = ConfigtypeCode
        m_ItemSharing.Year = Year
        m_ItemSharing.Month = Month
        m_ItemSharing.ItemCode = ItemCode
        m_ItemSharing.InsertItemSharingJonior()
    End Sub
    Private Sub GetPerPMRItemSharing(ByVal ConfigtypeCode As String, ByVal Year As String, Month As String, ByVal ItemCode As String)
        Dim ItemSharingID As Integer = -1
        Dim PMRCodeMajor As String = String.Empty
        table = GetRecords(ItemSharing.GetItemSharingMajorSql(ConfigtypeCode, Year, Month, ItemCode))
        For i As Integer = 0 To table.Rows.Count - 1
            m_ItemSharing = New ItemSharing
            m_ItemSharing.PMRCodeMajor = table.Rows(i)("PMRCode")
            m_ItemSharing.Config = ConfigtypeCode
            m_ItemSharing.Year = Year
            m_ItemSharing.Month = Month
            m_ItemSharing.ItemCode = ItemCode
            ItemSharingID = table.Rows(i)("ItemSharingCollectionID")
            PMRCodeMajor = table.Rows(i)("PMRCode")
            m_ItemSharing.InsertItemSharingSC03Major()

            tables = GetRecords(ItemSharing.GetItemSharingJoniorSql(ConfigtypeCode, Year, Month, ItemCode, ItemSharingID))
            For a As Integer = 0 To tables.Rows.Count - 1
                m_ItemSharing = New ItemSharing
                m_ItemSharing.PMRCodejonior = tables.Rows(a)("PMRCode")
                m_ItemSharing.Config = ConfigtypeCode
                m_ItemSharing.Year = Year
                m_ItemSharing.Month = Month
                m_ItemSharing.ItemCode = ItemCode
                m_ItemSharing.PMRCodeMajor = PMRCodeMajor
                m_ItemSharing.ItemSharingCollectionID = ItemSharingID
                m_ItemSharing.InsertSC03ItemSharingJonior()
            Next
        Next

    End Sub
    Private Function ValidationProcess() As Boolean
        m_HasError = False

        If txtConfigCode.Text = "" Then
            m_Err.SetError(txtConfigCode, "Configtype Code is Required!")
            m_HasError = True
        End If

        If txtItemCode.Text = "" Then
            m_Err.SetError(txtItemCode, "Item Code is Required!")
            m_HasError = True
        End If

        If DropYear.Text = "" Then
            m_Err.SetError(DropYear, "Year is Required!")
            m_HasError = True
        End If

        If DropMonth.Text = "" Then
            m_Err.SetError(DropMonth, "Month is Required!")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function

    Private Sub btnSharingCopyFrom_Click(sender As Object, e As EventArgs) Handles btnSharingCopyFrom.Click
        Dim a As New ItemSharingCopyFrom
        a.ShowDialog()
    End Sub

    Private Sub GrdViewPMR_Click(sender As Object, e As EventArgs) Handles GrdViewPMR.Click

    End Sub

    Private Sub GrdViewProductGroup_Click(sender As Object, e As EventArgs) Handles GrdViewProductGroup.Click

    End Sub
End Class
