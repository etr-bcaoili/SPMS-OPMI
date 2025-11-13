Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.Dialogs
Imports Telerik.WinControls.UI
Public Class UIItemCreate
    Private m_Err As New ErrorProvider
    Private m_Action As String = ""
    Private m_HasError As Boolean = False
    Private m_IsNewMode As Boolean = True

    Private m_Items As New Items
    Private m_ItemDivision As New ItemDivision
    Private m_ItemClass As New ItemClass
    Private m_ItemGroup As New ItemGroup
    Private m_ItemCategory As New ItemCategory
    Private m_ProductManager As New ItemProductAssignment
    Private m_ProductItemGroup As New ProductItemGroup
    Private m_ProductGroupEffectivity As New ProductGroupEffectivity
    Dim table As New DataTable
    Private Sub EditMode(ByVal IsEditMode As Boolean)

        lnkMotherCode.Enabled = IsEditMode
        LinkItemDivision.Enabled = IsEditMode
        LinkItemGroup.Enabled = IsEditMode
        LinkTherapeutic.Enabled = IsEditMode
        LinkProductCategory.Enabled = IsEditMode
        'LinkProductManager.Enabled = IsEditMode

        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtItemCode.ReadOnly = Not IsEditMode
        txtItemCode.BackColor = Color.White

        txtItemDescription.ReadOnly = Not IsEditMode
        txtItemDescription.BackColor = Color.White

        txtBrandName.ReadOnly = Not IsEditMode
        txtBrandName.BackColor = Color.White

        txtGenericName.ReadOnly = Not IsEditMode
        txtGenericName.BackColor = Color.White

        txtItemForm.ReadOnly = Not IsEditMode
        txtItemForm.BackColor = Color.White

        txtItemStrength.ReadOnly = Not IsEditMode
        txtItemStrength.BackColor = Color.White

        txtunitment.ReadOnly = Not IsEditMode
        txtunitment.BackColor = Color.White

        txtItemQuantity.ReadOnly = Not IsEditMode
        txtItemQuantity.BackColor = Color.White

        txtMotherCode.ReadOnly = Not IsEditMode
        txtMotherCode.BackColor = Color.White

        txtmotherDescription.ReadOnly = Not IsEditMode
        txtmotherDescription.BackColor = Color.White

        txtItemDivisionCode.ReadOnly = Not IsEditMode
        txtItemDivisionCode.BackColor = Color.White



        txtItemdivisionName.ReadOnly = Not IsEditMode
        txtItemdivisionName.BackColor = Color.White

        txtItemTherapeuticCode.ReadOnly = Not IsEditMode
        txtItemTherapeuticCode.BackColor = Color.White

        txtItemGroupCode.ReadOnly = Not IsEditMode
        txtItemGroupCode.BackColor = Color.White

        txtProductCategoryCode.ReadOnly = Not IsEditMode
        txtProductCategoryCode.BackColor = Color.White

        txtProductItemCategory.ReadOnly = Not IsEditMode
        txtProductItemCategory.BackColor = Color.White

    End Sub
    Private Sub Clear()
        txtItemCode.Text = String.Empty
        txtItemDescription.Text = String.Empty
        txtBrandName.Text = String.Empty
        txtGenericName.Text = String.Empty
        txtItemForm.Text = String.Empty
        txtItemStrength.Text = String.Empty
        txtunitment.Text = String.Empty
        txtItemQuantity.Text = String.Empty
        txtMotherCode.Text = String.Empty
        txtmotherDescription.Text = String.Empty
        txtItemDivisionCode.Text = String.Empty
        txtItemdivisionName.Text = String.Empty
        txtItemTherapeuticCode.Text = String.Empty
        txtItemClassName.Text = String.Empty
        txtItemGroupCode.Text = String.Empty
        txtItemGroupName.Text = String.Empty
        txtProductCategoryCode.Text = String.Empty

        txtProductItemCategory.Text = String.Empty
        GrdView.Rows.Clear()

    End Sub
    Private Sub EnableTextBox(ByVal IsEditMode As Boolean)
        txtItemCode.Enabled = Not IsEditMode
    End Sub
    Private Sub lnkMotherCode_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkMotherCode.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Items.GetItemSql, "Search Item")
        If Not tag Is Nothing Then
            LoadItem(tag.KeyColumn11)
        End If
    End Sub
    Private Sub LoadItem(ByVal ItemCode As String)
        m_Items = Items.LoadByMotherCode(ItemCode)
        txtMotherCode.Text = m_Items.ItemCode
        txtmotherDescription.Text = m_Items.ItemBrand
    End Sub
    Private Sub NewRecord()
        Clear()
        m_Items = New Items
        EditMode(True)
        EnableTextBox(False)
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnDelete.Click, btnEdit.Click, btnFinddata.Click, btnSave.Click, btnClear.Click, btnClose.Click
        If sender Is btnNew Then
            NewRecord()
            m_IsNewMode = True
        ElseIf sender Is btnDelete Then
            Delete()
        ElseIf sender Is btnEdit Then
            EditMode(True)
            EnableTextBox(True)
            m_IsNewMode = False
        ElseIf sender Is btnClear Then
            Clear()
            EditMode(False)
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
    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False

        If Not IsNumeric(txtItemQuantity.Text) Then
            m_Err.SetError(txtItemQuantity, "Please Number only.")
            m_HasError = True

        End If
        If txtItemTherapeuticCode.Text = "" Then
            m_Err.SetError(txtItemTherapeuticCode, "Item Classification is required")
            m_HasError = True
        End If

        If txtItemGroupCode.Text = "" Then
            m_Err.SetError(txtItemGroupCode, "Item Group is required")
            m_HasError = True
        End If

        If GrdView.Rows.Count = 0 Then
            m_Err.SetError(GrdView, "Item Division is required")
            m_HasError = True
        End If

        If txtItemCode.Text = "" Then
            m_Err.SetError(txtItemCode, "Item Code is required")
            m_HasError = True
        End If

        If txtMotherCode.Text = "" Then
            m_Err.SetError(txtMotherCode, "Mother is required")
            m_HasError = True
        End If

        If txtmotherDescription.Text = "" Then
            m_Err.SetError(txtmotherDescription, "Mother description is nrequired")
            m_HasError = True
        End If

        If txtItemCode.Text = "" Then
            m_Err.SetError(txtItemCode, "Item Code ID is Required!")
            m_HasError = True
        Else
            If m_IsNewMode = True Then
                If Items.CheckItemCodeIsAlreadyExist(txtItemCode.Text, IIf(txtItemCode.Tag Is Nothing, -1, txtItemCode.Tag)) Then
                    m_Err.SetError(txtItemCode, "Item Product ID Already Exist")
                    m_HasError = True
                End If
            End If
        End If
        Return Not m_HasError
    End Function
    Private Sub SaveRecord()
        m_Items.ItemCode = txtItemCode.Text
        m_Items.ItemCode1 = txtItemCode.Text
        m_Items.ItemBrand = txtItemDescription.Text
        m_Items.ItemBrand2 = txtBrandName.Text
        m_Items.ItemGeneric = txtGenericName.Text
        m_Items.ItemDel = False
        m_Items.IsActive = True
        m_Items.ItemForm = txtItemForm.Text
        m_Items.ItemStrength = txtItemStrength.Text
        m_Items.ItemUnit = txtunitment.Text
        m_Items.ItemQuantity = txtItemQuantity.Text

        m_Items.Itemthr = txtMotherCode.Text
        m_Items.ItemMMDES = txtmotherDescription.Text
        m_Items.ItemDivisionCode = txtItemDivisionCode.Text
        m_Items.ItemClassCode = txtItemTherapeuticCode.Text
        m_Items.ItemGroupCode = txtItemGroupCode.Text
        m_Items.ItemProductCategoryCode = txtProductCategoryCode.Text

        For a As Integer = 0 To GrdView.Rows.Count - 1
            Dim Growinfo As GridViewRowInfo = GrdView.Rows(a)
            m_ProductGroupEffectivity = New ProductGroupEffectivity
            m_ProductGroupEffectivity.ItemCode = txtItemCode.Text
            m_ProductGroupEffectivity.Code = Growinfo.Cells(0).Value
            m_ProductGroupEffectivity.EffectivityStartDate = Growinfo.Cells(2).Value
            m_ProductGroupEffectivity.EffectivityEndDate = Growinfo.Cells(3).Value
            m_ProductGroupEffectivity.ConfigtypeCode = Growinfo.Cells(4).Value
            m_ProductGroupEffectivity.Delete()
            m_ProductGroupEffectivity.Save()
        Next


        If m_Items.Save Then
            SaveSuccess()
            LoadItems(m_Items.ItemCode)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog() = DialogResult.Yes Then
            If m_Items.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub
    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Items.GetItemSql, "Distributor")
        If Not tag Is Nothing Then
            LoadItems(tag.KeyColumn11)
        End If
    End Sub
    Private Sub LoadItems(ByVal RecordCode As String)
        Clear()
        m_Items = Items.LoadByCode(RecordCode)
        txtItemCode.Tag = m_Items.ID
        txtItemCode.Text = m_Items.ItemCode1
        txtItemDescription.Text = m_Items.ItemBrand
        txtBrandName.Text = m_Items.ItemBrand2
        txtGenericName.Text = m_Items.ItemGeneric
        txtItemForm.Text = m_Items.ItemForm
        txtItemStrength.Text = m_Items.ItemStrength
        txtItemQuantity.Text = m_Items.ItemQuantity
        txtunitment.Text = m_Items.ItemUnit
        txtMotherCode.Text = m_Items.Itemthr
        txtmotherDescription.Text = m_Items.ItemMMDES

        If Not m_Items.ItemDivisionCode = String.Empty Then
            LoadItemDivision(m_Items.ItemDivisionCode)
        End If
        If Not m_Items.ItemClassCode = String.Empty Then
            LoadItemClass(m_Items.ItemClassCode)
        End If
        If Not m_Items.ItemGroupCode = String.Empty Then
            LoadItemGroup(m_Items.ItemGroupCode)
        End If
        If Not m_Items.ItemProductCategoryCode = String.Empty Then
            LoadItemCategory(m_Items.ItemProductCategoryCode)
        End If
        'If Not m_Items.ItemProductAssign = String.Empty Then
        '    LoadItemProductManager(m_Items.ItemProductAssign)
        'End If
        If Not m_Items.ProductItemGroup = String.Empty Then
            LoadProductItemGroup(m_Items.ProductItemGroup)
        End If
        If Not m_Items.Itemthr = String.Empty Then
            LoadProductGroupList(m_Items.Itemthr)
        End If
        EditMode(False)
    End Sub
    Private Sub LoadProductGroupList(ByVal ItemCode As String)
        GrdView.Rows.Clear()
        table = GetRecords(ProductGroupEffectivity.GetProductGroupSql(ItemCode))
        For m As Integer = 0 To table.Rows.Count - 1
            Dim rowinfos As GridViewRowInfo = GrdView.Rows.AddNew
            rowinfos.Cells(0).Value = table.Rows(m)("Code")
            rowinfos.Cells(1).Value = table.Rows(m)("PGDescription")
            rowinfos.Cells(2).Value = table.Rows(m)("EffectivityStartDate")
            rowinfos.Cells(3).Value = table.Rows(m)("EffectivityEndDate")
            rowinfos.Cells(4).Value = table.Rows(m)("ConfigtypeCode")
        Next
    End Sub
    Private Sub LoadItemMonther(ByVal RecordCode As String)
        m_Items = Items.LoadByMotherCode(RecordCode)
        txtMotherCode.Text = m_Items.Itemthr
        txtmotherDescription.Text = m_Items.ItemMMDES
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkItemDivision.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ItemDivision.GetItemDivisionSql, "Search Item")
        If Not tag Is Nothing Then
            LoadItemDivision(tag.KeyColumn22)
        End If
    End Sub
    Private Sub LoadItemDivision(ByVal ItemDivisionCode As String)
        m_ItemDivision = ItemDivision.LoadByCode(ItemDivisionCode)
        txtItemDivisionCode.Text = m_ItemDivision.ItemDivisionCode
        txtItemdivisionName.Text = m_ItemDivision.ItemDivisionName
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkTherapeutic.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ItemClass.GetItemClassSql, "Search Item")
        If Not tag Is Nothing Then
            LoadItemClass(tag.KeyColumn22)
        End If
    End Sub
    Private Sub LoadItemClass(ByVal ItemClassCode As String)
        m_ItemClass = ItemClass.LoadByCode(ItemClassCode)
        txtItemTherapeuticCode.Text = m_ItemClass.ItemClassCode
        txtItemClassName.Text = m_ItemClass.ItemClassDescription
    End Sub


    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkItemGroup.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ItemGroup.GetItemGroupSql, "Search Item")
        If Not tag Is Nothing Then
            LoadItemGroup(tag.KeyColumn22)
        End If
    End Sub
    Private Sub LoadItemGroup(ByVal ItemGroupCode As String)
        m_ItemGroup = ItemGroup.LoadByCode(ItemGroupCode)
        txtItemGroupCode.Text = m_ItemGroup.ItemGroupCode
        txtItemGroupName.Text = m_ItemGroup.ItemGroupDescription
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkProductCategory.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ItemCategory.GetItemCategorySql, "Search Item")
        If Not tag Is Nothing Then
            LoadItemCategory(tag.KeyColumn22)
        End If
    End Sub
    Private Sub LoadItemCategory(ByVal ItemCategoryCode As String)
        m_ItemCategory = ItemCategory.LoadByCode(ItemCategoryCode)
        txtProductCategoryCode.Text = m_ItemCategory.ItemCode
        txtProductItemCategory.Text = m_ItemCategory.ItemDescription
    End Sub

    'Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
    '    Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ItemProductAssignment.GetItemProductManagerAssigmentSql, "Search Item")
    '    If Not tag Is Nothing Then
    '        LoadItemProductManager(tag.KeyColumn22)
    '    End If
    'End Sub
    'Private Sub LoadItemProductManager(ByVal ItemProductCode As String)
    '    m_ProductManager = ItemProductAssignment.LoadByCode(ItemProductCode)
    '    txtProductManagerCode.Text = m_ProductManager.ItemPriductID
    '    txtProductManagerName.Text = m_ProductManager.ItemProductManagerAssignment
    'End Sub

    Private Sub UIItemCreate_Load(sender As Object, e As EventArgs) Handles Me.Load
        EditMode(False)
        dtFromDate.Value = DateTime.Now
        dtTodate.Value = DateTime.Now
        'LoadConfigtypeCode()
    End Sub

    Private Sub LoadConfigtypeCode()
        ' Remove the existing auto-generated column first
        GrdView.Columns.Remove("Configtype Code")

        ' Create a new ComboBox column
        Dim comboCol As New GridViewComboBoxColumn()
        comboCol.Name = "ConfigtypeCode"
        comboCol.HeaderText = "Configtype Code"


        ' Bind it to your DataTable
        Dim table As DataTable = GetRecords(Configuration.GetConfigtypeSql)
        comboCol.DataSource = table
        comboCol.DisplayMember = "ConfigtypeCode"   ' column from your table to show
        comboCol.ValueMember = "ConfigtypeCode"     ' column from your table to save


        ' Add it back to the grid
        GrdView.Columns.Add(comboCol)
        GrdView.Columns("ConfigtypeCode").BestFit()

    End Sub

    Private Sub LinkProductItemGroup_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ProductItemGroup.GetProductItemGroupSql, "Search Item")
        If Not tag Is Nothing Then
            LoadProductItemGroup(tag.KeyColumn22)
        End If
    End Sub
    Private Sub LoadProductItemGroup(ByVal Code As String)
        Dim year As Integer = DateTime.Now.Year
        Dim firstDayOfYear As New DateTime(year, 1, 1)
        Dim lastDayOfYear As New DateTime(year, 12, 31)
        m_ProductItemGroup = ProductItemGroup.LoadByCode(Code)

        ' Bind it to your DataTable
        Dim table As DataTable = GetRecords(Configuration.GetConfigtypeSql)

        Dim comboCol As GridViewComboBoxColumn = CType(GrdView.Columns(4), GridViewComboBoxColumn)
        comboCol.DataSource = table
        comboCol.DisplayMember = "ConfigtypeCode"
        comboCol.ValueMember = "ConfigtypeCode"

        ' Add row
        Dim row As GridViewRowInfo = GrdView.Rows.AddNew()
        row.Cells(0).Value = m_ProductItemGroup.PGCode
        row.Cells(1).Value = m_ProductItemGroup.PGDescription
        row.Cells(2).Value = firstDayOfYear
        row.Cells(3).Value = lastDayOfYear
        row.Cells(4).Value = table.Rows(0)("ConfigtypeCode")
    End Sub
    Private Sub btnModificationSales_Click(sender As Object, e As EventArgs) Handles btnModificationSales.Click
        If txtItemCode.Text = "" Or txtMotherCode.Text = "" Then
            ShowExclamation("Select the Item want to Item modified.", "Item Modified Sales")
        Else
            Dim ItemModifiedSales As New frmItemModifieldSales
            ItemModifiedSales.ItemCode = txtItemCode.Text
            ItemModifiedSales.ItemMotherCode = txtMotherCode.Text
            ItemModifiedSales.ShowDialog()
        End If
    End Sub

    Private Sub btnAdd_productGroup_Click(sender As Object, e As EventArgs) Handles btnAdd_productGroup.Click
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ProductItemGroup.GetProductItemGroupSql, "Search Item")
        If Not tag Is Nothing Then
            LoadProductItemGroup(tag.KeyColumn22)
        End If
    End Sub

    Private Sub LoadColumnsComboBox()
        For Each Column As GridViewDataColumn In Me.GrdView.Columns
            Dim ComboItem As New RadListDataItem(Column.HeaderText)
            ComboItem.Tag = Column
        Next Column
    End Sub
End Class
