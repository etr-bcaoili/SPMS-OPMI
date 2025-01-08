Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class UCMasterItem

    Private m_Err As New ErrorProvider
    Private m_RsItemClass As New ADODB.Recordset
    Private m_RsItemGroup As New ADODB.Recordset
    Private m_RsItemDivision As New ADODB.Recordset
    Private m_RsItem As New ADODB.Recordset
    Private m_RsItemForViewing As New ADODB.Recordset
    Private m_Action As String = ""
    Private m_HasError As Boolean = False
    Private m_IsNewMode As Boolean = True
    Private m_RsFilter As New ADODB.Recordset

    Private m_ItemCode As String = ""
    Private m_ItemDescription As String = ""
    Private m_itemteammapRecid As String = ""

    Private m_Items As New Items
    Public Property itemteammapRecid() As String
        Get
            Return m_itemteammapRecid

        End Get
        Set(ByVal value As String)
            m_itemteammapRecid = value
        End Set
    End Property

    Public Property ItemDescription() As String
        Get
            Return m_ItemDescription
        End Get
        Set(ByVal value As String)
            m_ItemDescription = value
        End Set
    End Property

    Public Property ItemCode() As String
        Get
            Return m_ItemCode
        End Get
        Set(ByVal value As String)
            m_ItemCode = value
        End Set
    End Property

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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateData() Then
            If SaveData() Then
                loadseam()
                createds()
                loadtext()
                SaveSuccess()
                loads()
                LoadItemsToGrid()
                EditMode(False)
                Clear()
            End If
        End If
    End Sub
    Private Sub loadseam()
        Dim ds As New ADODB.Recordset
        ds.Open("Select Recid,ITMDIVCD,ITMTMCD,ITMTMNM,itemthr,ITEMNAME,ITEMCD,IsActive,dltflg  from itemteammap where itemcd = '" & txtItemCode1.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If ds.EOF = False Then
            m_ItemteammapRecid = ds.Fields("Recid").Value
            deleteds()
        End If
    End Sub
    Private Sub deleteds()
        Dim rs2 As New ADODB.Recordset
        rs2.Open("Delete  from  itemteammap where itemcd = '" & txtItemCode1.Text & "' AND Recid = '" & m_ItemteammapRecid & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
    End Sub
    Private Sub createds()
        m_RsItem = New ADODB.Recordset
        m_RsItem.Open("insert into itemteammap(ITMDIVCD,ITMTMCD,ITMTMNM,ITEMTHR,ITEMNAME,ITEMCD,IsActive,dltflg)values('" & cboItemDivision.Text & "','" & cboItemDivision.Text & "','" & txtItemdivisionName.Text & "','" & txtMotherCode.Text & "','" & HandleSingleQuoteInSql(txtItemBrand.Text) & "','" & txtItemCode1.Text & "' ,'1','0')select ITEMCD  from item", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        loaddeleted()
    End Sub
    Private Sub loaddeleted()
        Dim rs As New ADODB.Recordset
        rs.Open("DELETE FROM ITEMTEAMMAP WHERE RECID not in (SELECT MIN(RECID) FROM ITEMTEAMMAP GROUP BY ITMDIVCD, ITMTMCD, ITMTMNM,ItemThr,ITEMCD,ITEMNAME)", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
    End Sub
   


    Private Function SaveData() As Boolean

        Try
            If CheckIfItemExist(txtItemCode1.Text) Then
                m_Action = EnumAction.ADD.ToString
            Else
                m_Action = EnumAction.UPDATE.ToString
            End If

            SPMSConn.Execute("EXEC uspItem @Action = '" & m_Action & "' , @ITEMCD = '" & txtItemCode1.Text & "',  @ITEMCD1 = '" & txtItemCode1.Text & "', " & _
                                                                " @IMDBRN = '" & HandleSingleQuoteInSql(txtBrandName2.Text) & "', @IMDGEN = '" & HandleSingleQuoteInSql(txtGenericName.Text) & "' , " & _
                                                                " @IMDFRM = '" & txtItemForm.Text & "' , @IMDSTR = '" & HandleSingleQuoteInSql(txtItemStrength.Text) & "' ,  @IMDSIZ = '" & HandleSingleQuoteInSql(txtunitment.Text) & "' ,@PCKSIZE = '" & HandleSingleQuoteInSql(txtItemSize.Text) & "' , @ITEMGRPCD = '" & cboItemGroup.Text & "' , " & _
                                                                " @ITEMCLSCD = '" & cboItemClass.Text & "' , @ITEMTHR = '" & txtMotherCode.Text & "' ,@ITEMMDES = '" & HandleSingleQuoteInSql(txtItemBrand.Text) & "', " & _
                                                                " @ITEMDIVCD = '" & cboItemDivision.Text & "' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "'  , @IMDBRN2 = '" & HandleSingleQuoteInSql(txtBrandName2.Text) & "', @ITEMDIVNAME = '" & txtItemdivisionName.Text & "'  ")



            Return True

        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try


    End Function

    Private Sub MasterItem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If m_ItemCode <> "" Then
            m_Err.Clear()
            LoadItemClass()
            LoadItemGroup()
            LoadItemDivision()
            LoadItemsToGrid()
            'LoadItem(ITEM)
            loads()

            ApplyGridTheme(dgItemList)
            EditMode(False)
            Clear()
            m_IsNewMode = True
            txtItemCode1.Text = m_ItemCode
            txtItemBrand.Text = m_ItemDescription
            LoadSelectionBox()
            MainTab.SelectTab(0)



        Else
            m_Err.Clear()
            'LoadItem()
            LoadItemClass()
            LoadItemGroup()
            LoadItemDivision()
            LoadItemsToGrid()
            ApplyGridTheme(dgItemList)
            EditMode(False)
            Clear()
            m_IsNewMode = True
            LoadSelectionBox()
            MainTab.SelectTab(0)
        End If


    End Sub
    Private Sub loadtext()
        txtItemCode1.ReadOnly = True
        txtItemBrand.ReadOnly = True
        txtunitment.ReadOnly = True
        txtBrandName2.ReadOnly = True
        txtGenericName.ReadOnly = True
        txtItemForm.ReadOnly = True
        txtItemStrength.ReadOnly = True
        txtItemSize.ReadOnly = True
        txtItemdivisionName.ReadOnly = True
        txtItemClassName.ReadOnly = True
        txtItemGroupName.ReadOnly = True
        txtmotherDesc.ReadOnly = True
        txtMotherCode.ReadOnly = True
        txtmotherDesc.ReadOnly = True
        'cboItemClass.ReadOnly = False
        txtItemClassName.ReadOnly = True
        'cboItemDivision.ReadOnly = False
        txtItemdivisionName.ReadOnly = True
        'cboItemGroup.ReadOnly = False
        txtItemGroupName.ReadOnly = True
    End Sub
    Private Sub Clear()
        'txtFilter.Text = ""
        txtGenericName.Text = String.Empty
        txtItemBrand.Text = String.Empty
        txtItemCode1.Text = String.Empty
        txtBrandName2.Text = String.Empty

        txtItemForm.Text = String.Empty
        'txtitemGroupCode.Text = String.Empty
        txtItemSize.Text = String.Empty
        txtItemStrength.Text = String.Empty
        txtunitment.Text = String.Empty
        txtMotherCode.Text = String.Empty
        txtmotherDesc.Text = String.Empty
        cboItemClass.SelectedIndex = -1
        txtItemClassName.Text = String.Empty
        cboItemDivision.SelectedIndex = -1
        txtItemdivisionName.Text = String.Empty
        cboItemGroup.SelectedIndex = -1
        txtItemGroupName.Text = String.Empty
    End Sub

    Private Sub LoadSelectionBox()
        cboSelection.Items.Clear()
        cboSelection.Items.Add("All")
        cboSelection.Items.Add("Item Code")
        cboSelection.Items.Add("Generic Name")
        cboSelection.Items.Add("Brand Name")
    End Sub

    Private Sub LoadItemClass()

        If m_RsItemClass.State = 1 Then m_RsItemClass.Close()
        m_RsItemClass.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsItemClass.Open("SELECT * FROM ItemClass WHERE ITEMCLASSDEL = 0 AND IsActive = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        cboItemClass.Items.Clear()
        If m_RsItemClass.RecordCount = 0 Then Exit Sub
        For m As Integer = 0 To m_RsItemClass.RecordCount - 1
            cboItemClass.Items.Add(m_RsItemClass.Fields("ITEMCLASSCD").Value)
            m_RsItemClass.MoveNext()
        Next
    End Sub
    Private Sub LoadItem(ByVal ItemCode As String)
        m_Items = Items.LoadByCode(ItemCode)
        txtMotherCode.Text = m_Items.ItemCode
        txtmotherDesc.Text = m_Items.ItemBrand
        'If m_RsItemClass.State = 1 Then m_RsItemClass.Close()
        'm_RsItemClass.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'm_RsItemClass.Open("SELECT * FROM Item WHERE ITEMDEL = 0 AND IsActive = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        'cboItemClass.Items.Clear()
        'If m_RsItemClass.RecordCount = 0 Then Exit Sub
        'For m As Integer = 0 To m_RsItemClass.RecordCount - 1
        '    cbomothercode.Items.Add(m_RsItemClass.Fields("ITEMCD").Value)
        '    m_RsItemClass.MoveNext()
        'Next
    End Sub

    'Private Sub cbomothercode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    txtmotherDesc.Text = ""

    '    Dim rsItemClass As New ADODB.Recordset
    '    If rsItemClass.State = 1 Then rsItemClass.Close()
    '    rsItemClass.Open("Select IMDBRN from Item WHERE ITEMDEL = 0 AND ITEMCD = '" & txtMotherCode.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
    '    If rsItemClass.RecordCount <> 0 Then
    '        txtmotherDesc.Text = rsItemClass.Fields(0).Value
    '    End If
    'End Sub

    Private Sub lnkMotherCode_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkMotherCode.LinkClicked
        Dim Tag As SelectionTag = ShowSearchDialog(Items.GetItemColumns, Items.GetItemSql, "Search Item")
        If Not Tag Is Nothing Then
            LoadItem(Tag.KeyColumn2)
        End If
    End Sub

    Private Sub LoadItemGroup()

        If m_RsItemGroup.State = 1 Then m_RsItemGroup.Close()
        m_RsItemGroup.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsItemGroup.Open("SELECT * FROM ItemGroup WHERE ITEMGROUPDEL = 0 AND IsActive = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        cboItemGroup.Items.Clear()
        If m_RsItemGroup.RecordCount = 0 Then Exit Sub
        For m As Integer = 0 To m_RsItemGroup.RecordCount - 1
            cboItemGroup.Items.Add(m_RsItemGroup.Fields("ITEMGROUPCD").Value)
            m_RsItemGroup.MoveNext()
        Next

    End Sub

    Private Sub LoadItemDivision()
        If m_RsItemDivision.State = 1 Then m_RsItemDivision.Close()
        m_RsItemDivision.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsItemDivision.Open("SELECT * FROM ITEMDIVISION WHERE DLTFLG = 0 And IsActive = 1 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        cboItemDivision.Items.Clear()

        If m_RsItemDivision.RecordCount > 0 Then
            For m As Integer = 0 To m_RsItemDivision.RecordCount - 1
                cboItemDivision.Items.Add(m_RsItemDivision.Fields("ITMDIVCD").Value)
                m_RsItemDivision.MoveNext()
            Next
        End If

    End Sub

    Private Sub LoadItemsToGrid()

        If m_RsItemForViewing.State = 1 Then m_RsItemForViewing.Close()
        m_RsItemForViewing.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsItemForViewing.Open("SELECT * FROM Item Where ITEMDEL = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgItemList.Rows.Clear()
        If m_RsItemForViewing.RecordCount = 0 Then Exit Sub

        RefreshGrid(m_RsItemForViewing)

    End Sub

    Private Sub RefreshGrid(ByVal rs As ADODB.Recordset)
        For m As Integer = 0 To rs.RecordCount - 1
            Dim row As DataGridViewRow = dgItemList.Rows(dgItemList.Rows.Add)
            row.Cells(colItemCode.Index).Value = rs.Fields("ITEMCD").Value
            row.Cells(colItemCode.Index).Tag = rs.Fields("ITEMCD").Value
            row.Cells(colItemDescription.Index).Value = rs.Fields("IMDGEN").Value
            row.Cells(colItemBrandName.Index).Value = rs.Fields("IMDBRN").Value
            row.Cells(colStartDate.Index).Value = rs.Fields("EffectivityStartDate").Value
            row.Cells(colEndDate.Index).Value = rs.Fields("EffectivityEndDate").Value
            rs.MoveNext()
        Next
    End Sub


    Private Function CheckIfItemExist(ByVal ItemCode As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM ITEM WHERE ITEMCD = '" & ItemCode & "'  AND  ITEMDEL = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.RecordCount = 0 Then
            Return True
        End If
        Return False
    End Function

    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False

        If Not IsNumeric(txtItemSize.Text) Then
            m_Err.SetError(txtItemSize, "Please Number only.")
            m_HasError = True

        End If
        If cboItemClass.Text = "" Then
            m_Err.SetError(cboItemClass, "Item Classification is required")
            m_HasError = True
        End If

        If cboItemGroup.Text = "" Then
            m_Err.SetError(cboItemGroup, "Item Group is required")
            m_HasError = True
        End If

        If cboItemDivision.Text = "" Then
            m_Err.SetError(cboItemDivision, "Item Division is required")
            m_HasError = True
        End If

        If txtItemCode1.Text = "" Then
            m_Err.SetError(txtItemCode1, "Item Code is required")
            m_HasError = True
        End If

        If txtMotherCode.Text = "" Then
            m_Err.SetError(txtMotherCode, "Mother is required")
            m_HasError = True
        End If

        If txtmotherDesc.Text = "" Then
            m_Err.SetError(txtmotherDesc, "Mother description is nrequired")
            m_HasError = True
        End If
        ' If txtItemCode1.Text <> cbomothercode.Text Then
        'm_Err.SetError(cbomothercode, "Item code and Mother Code is not Equal")
        ' m_HasError = True

        If m_IsNewMode Then
            If Not CheckIfItemExist(txtItemCode1.Text) Then
                ShowExclamation("Record Already Exist", "Save")
                m_HasError = True
            End If
        End If
        Return Not m_HasError
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Clear()
        m_IsNewMode = True
        EditMode(True)
        loadtext2()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim q As MsgBoxResult
        q = VDialog.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If q = MsgBoxResult.Yes Then
            Delete()
            Clear()
            LoadItemsToGrid()
        End If
    End Sub

    Private Sub Delete()

        If Not txtItemCode1.Text = "" Then
            Try
                SPMSConn.Execute("EXEC uspItem @Action = 'DELETE' , @ITEMCD = '" & txtItemCode1.Text & "'")
                DeleteSuccess()
                loadtext()
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try

        Else
            VDialog.Show("There are no record to be Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Private Sub dgItemList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItemList.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Dim row As DataGridViewRow = dgItemList.Rows(e.RowIndex)
        If Not CheckIfItemExist(row.Cells(colItemCode.Index).Tag) Then
            If m_RsItem.State = 1 Then m_RsItem.Close()
            m_RsItem.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            m_RsItem.Open("SELECT * FROM Item WHERE ITEMDEL = 0 AND ITEMCD  = '" & row.Cells(colItemCode.Index).Tag & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If m_RsItem.RecordCount > 0 Then
                ShowData(m_RsItem)
            End If
        End If
    End Sub

    Private Sub ShowData(ByVal rs As ADODB.Recordset)
        loadtext()
        m_IsNewMode = False
        Clear()
        LoadItemClass()
        LoadItemGroup()

        txtGenericName.Text = rs.Fields("IMDGEN").Value
        txtItemBrand.Text = rs.Fields("IMDBRN").Value
        txtItemCode1.Text = rs.Fields("ITEMCD").Value
        txtItemCode1.Tag = rs.Fields("ITEMCD").Value
        txtBrandName2.Text = rs.Fields("IMDBRN2").Value

        txtItemForm.Text = rs.Fields("IMDFRM").Value
        '    txtitemGroupCode.Text = rs.Fields("ITEMGRPCD").Value
        txtMotherCode.Text = rs.Fields("ITEMTHR").Value.ToString
        txtmotherDesc.Text = rs.Fields("ITEMMDES").Value.ToString
        cboItemClass.SelectedItem = rs.Fields("ITEMCLSCD").Value
        cboItemGroup.SelectedItem = rs.Fields("ITEMGRPCD").Value
        cboItemDivision.SelectedItem = rs.Fields("ITEMDIVCD").Value
        txtunitment.Text = rs.Fields("IMDSIZ").Value
        txtItemStrength.Text = rs.Fields("IMDSTR").Value
        txtItemSize.Text = rs("PCKSIZE").Value.ToString

        dtStart.Value = rs.Fields("EffectivityStartDate").Value
        dtEnd.Value = rs.Fields("EffectivityEndDate").Value
        EditMode(False)
        loadtext()
        MainTab.SelectTab(0)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        m_IsNewMode = False
        EditMode(True)
        loadtext2()
        txtItemCode1.Enabled = False
    End Sub
    Private Sub loadtext2()
        txtItemCode1.ReadOnly = False
        txtItemBrand.ReadOnly = False
        txtunitment.ReadOnly = False
        txtBrandName2.ReadOnly = False
        txtGenericName.ReadOnly = False
        txtItemForm.ReadOnly = False
        txtItemStrength.ReadOnly = False
        txtItemSize.ReadOnly = False
        txtItemdivisionName.ReadOnly = False
        txtItemClassName.ReadOnly = False
        txtItemGroupName.ReadOnly = False
        txtmotherDesc.ReadOnly = False
        txtMotherCode.ReadOnly = False


    End Sub
    Private Sub loads()
        txtItemCode1.ReadOnly = True
        txtItemBrand.ReadOnly = True
        txtunitment.ReadOnly = True
        txtBrandName2.ReadOnly = True
        txtGenericName.ReadOnly = True
        txtItemForm.ReadOnly = True
        txtItemStrength.ReadOnly = True
        txtItemSize.ReadOnly = True
        txtItemdivisionName.ReadOnly = True
        txtItemClassName.ReadOnly = True
        txtItemGroupName.ReadOnly = True
        txtmotherDesc.ReadOnly = True

    End Sub
    Private Sub createmmap()

    End Sub


    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        FilterData()
    End Sub
    Private Sub FilterData()
        Dim FilterField As String = ""
        If cboSelection.SelectedItem = "Item Code" Then
            FilterField = "ITEMCD"
        ElseIf cboSelection.SelectedItem = "Generic Name" Then
            FilterField = "IMDBRN"
        ElseIf cboSelection.SelectedItem = "Brand Name" Then
            FilterField = "IMDGEN"
        Else
            FilterField = ""
        End If
        If cboSelection.Text = "All" Then
            LoadItemsToGrid()
            txtFilter.Text = ""
            Exit Sub
        End If
        If FilterField <> "" Then
            If m_RsFilter.State = 1 Then m_RsFilter.Close()
            m_RsFilter.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            m_RsFilter.Open("SELECT * FROM Item WHERE " & FilterField & " like '%" & txtFilter.Text & "%' and ITEMDEL = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If m_RsFilter.RecordCount > 0 Then
                dgItemList.Rows.Clear()
                RefreshGrid(m_RsFilter)
            End If
        End If
    End Sub

    Private Sub lnkRefresh_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkRefresh.LinkClicked
        LoadItemsToGrid()
    End Sub


    Private Sub cboItemGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemGroup.SelectedIndexChanged
        txtItemGroupName.Text = ""
        Dim rsItemGroup As New ADODB.Recordset
        If rsItemGroup.State = 1 Then rsItemGroup.Close()
        rsItemGroup.Open("Select ITEMGROUPNAME from ITEMGROUP WHERE ITEMGROUPCD = '" & cboItemGroup.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsItemGroup.RecordCount <> 0 Then
            txtItemGroupName.Text = rsItemGroup.Fields(0).Value
        End If
    End Sub

    Private Sub dgItemList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItemList.CellContentClick

    End Sub

    Private Sub txtItemForm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemForm.TextChanged

    End Sub


    Private Sub cboItemDivision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemDivision.SelectedIndexChanged
        txtItemdivisionName.Text = ""

        Dim rsItemDivision As New ADODB.Recordset
        If rsItemDivision.State = 1 Then rsItemDivision.Close()
        rsItemDivision.Open("Select ITMDIVNAME from ITEMDIVISION WHERE ITMDIVCD = '" & cboItemDivision.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsItemDivision.RecordCount <> 0 Then
            txtItemdivisionName.Text = rsItemDivision.Fields(0).Value

        End If
    End Sub

    Private Sub cboItemClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemClass.SelectedIndexChanged
        txtItemClassName.Text = ""

        Dim rsItemClass As New ADODB.Recordset
        If rsItemClass.State = 1 Then rsItemClass.Close()
        rsItemClass.Open("Select ITEMCLASSNAME from ITEMCLASS WHERE ITEMCLASSDEL = 0 AND ITEMCLASSCD = '" & cboItemClass.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsItemClass.RecordCount <> 0 Then
            txtItemClassName.Text = rsItemClass.Fields(0).Value
        End If
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Chr(13) Then
            FilterData()
        End If
    End Sub


    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub

    Private Sub txtItemSize_KeyPress(ByVal KeyAscii As Integer, ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Select Case KeyAscii
            Case 65 To 90, 48 To 57, 8

            Case 97 To 122, 8

            Case Else

                KeyAscii = 0
        End Select
    End Sub

    Private Sub txtItemSize_KeyPress(ByVal KeyAscii As Integer)
        Select Case KeyAscii
            Case 65 To 90, 48 To 57, 8

            Case 97 To 122, 8

            Case Else

                KeyAscii = 0
        End Select
    End Sub

    Private Sub txtItemSize_TextChanged(ByVal KeyAscii As Integer, ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case KeyAscii
            Case 65 To 90, 48 To 57, 8

            Case 97 To 122, 8

            Case Else

                KeyAscii = 0
        End Select
    End Sub

    Private Sub tbEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbEntry.Click

    End Sub


    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub cboSelection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSelection.SelectedIndexChanged

    End Sub
End Class

