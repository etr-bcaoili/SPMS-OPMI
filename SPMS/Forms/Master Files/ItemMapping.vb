Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class ItemMapping
    Private m_Err As New ErrorProvider
    Private m_RsItemClass As New ADODB.Recordset
    Private m_RsItemGroup As New ADODB.Recordset
    Private M_rsitemedit As New ADODB.Recordset
    Private m_RsItemDivision As New ADODB.Recordset
    Private m_RsItem As New ADODB.Recordset
    Private m_Recount As New ADODB.Recordset
    Private m_RsItemForViewing As New ADODB.Recordset
    Private m_Action As String = ""
    Private GridRs As New ADODB.Recordset
    Private m_ForDeletes As New ForDeletesCollection
    Private m_HasError As Boolean = False
    Private m_IsNewMode As Boolean = True
    Private m_RsFilter As New ADODB.Recordset
    Dim row As DataGridView
    Private m_ItemCode As String = ""
    Private m_ItemDescription As String = ""
    Private Operation As String

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
    Private Sub SetupbyOperation(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation
    End Sub

    Private Sub Clear()
        cbomthecode.Enabled = True
        txtmathercode.Enabled = True
        txtdivname.Text = ""
        txtItemCode.Text = ""
        txtitemname.Text = ""
        txtItemCode.Text = ""
        txtitemname.Text = ""
        txtmathercode.Text = ""
        txtdivname.Text = ""
        txtItemdivcode.Text = ""
    End Sub
    Private Sub ItemMapping_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If m_ItemCode <> "" Then
            m_Err.Clear()
            groups.Visible = False
            LoadItemGroup()
            LoadItemsToGrid()
            loadedit()
            ApplyGridTheme(dgtails)
            ApplyGridTheme(dgtails)
            m_IsNewMode = True
            txtItemCode.Text = m_ItemCode
            txtItemdivcode.Text = m_ItemDescription
            LOADITEMBACK()
            MainTab.SelectTab(0)
            m_Recount.Open("Select * from itemteammap ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            txtcount.Text = m_Recount.RecordCount
            LoadItemDivision()
            cbomthecode.Enabled = False
            txtmathercode.Enabled = False
            Dim rs As New ADODB.Recordset
            rs.Open("select * from item where ITEMCD not in(select MTHRCODE from itemteammap)", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            cboedit.Visible = False



        Else
            m_Err.Clear()
            LoadItemGroup()
            LoadItemsToGrid()
            loadedit()
            ApplyGridTheme(dgtails)
            ApplyGridTheme(dgtails)
            m_IsNewMode = True
            m_Recount.Open("Select * from itemteammap ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            txtcount.Text = m_Recount.RecordCount
            LoadItemDivision()
            LOADITEMBACK()
            cbomthecode.Enabled = False
            txtmathercode.Enabled = False
            MainTab.SelectTab(0)
            cboedit.Visible = False

        End If


    End Sub
    Private Sub LoadItemsToGrid()
        Dim style As New DataGridViewCellStyle
        style.Alignment = DataGridViewContentAlignment.BottomCenter
        If m_RsItemForViewing.State = 1 Then m_RsItemForViewing.Close()
        m_RsItemForViewing.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsItemForViewing.Open("Select distinct ITMDIVCD,ITMTMNM,ITEMCD,ITEMNAME from itemteammap  where dltflg = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgtails.Rows.Clear()
        If m_RsItemForViewing.RecordCount = 0 Then Exit Sub
        LOADITEMBACK()
        RefreshGrid(m_RsItemForViewing)
    End Sub
    Private Sub LOADITEMBACK()
        Dim rs As New ADODB.Recordset
        rs.Open("select * from item where ITEMCD not in(select itemTHR from itemteammap)", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

    End Sub

    Private Sub RefreshGrid(ByVal rs As ADODB.Recordset)
        For m As Integer = 0 To rs.RecordCount - 1
            Dim row As DataGridViewRow = dgtails.Rows(dgtails.Rows.Add)

            row.Cells(colItemCode.Index).Value = rs.Fields("ITEMCD").Value
            row.Cells(colItemcodediv.Index).Value = rs.Fields("ITMDIVCD").Value
            row.Cells(colitemname.Index).Value = rs.Fields("ITMTMNM").Value
            row.Cells(colItemnamediv.Index).Value = rs.Fields("ITEMNAME").Value
            rs.MoveNext()
        Next
    End Sub
    Private Function CheckIfItemExist(ByVal ItemCode As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM ITEMTEAMMAP  WHERE ITEMCD = '" & ItemCode & "'  AND delflag = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.RecordCount = 0 Then
            Return True
        End If
        Return False
    End Function

    Private Sub LoadItemDivision()
        If m_RsItemDivision.State = 1 Then m_RsItemDivision.Close()
        m_RsItemDivision.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsItemDivision.Open("SELECT * FROM ITEMDIVISION WHERE DLTFLG = 0 And IsActive = 1 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        txtdivname.Text = ""

        If m_RsItemDivision.RecordCount > 0 Then
            For m As Integer = 0 To m_RsItemDivision.RecordCount - 1
                ' cboItemDivision.Items.Add(m_RsItemDivision.Fields("ITMDIVCD").Value)
                m_RsItemDivision.MoveNext()
            Next
        End If

    End Sub
    Private Sub LoadItemGroup()

        If m_RsItemGroup.State = 1 Then m_RsItemGroup.Close()
        m_RsItemGroup.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsItemGroup.Open("SELECT * FROM Item WHERE ITEMDEL = 0 AND IsActive = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        cbomthecode.Items.Clear()
        If m_RsItemGroup.RecordCount = 0 Then Exit Sub
        For m As Integer = 0 To m_RsItemGroup.RecordCount - 1
            cbomthecode.Items.Add(m_RsItemGroup.Fields("ITEMCD").Value)
            m_RsItemGroup.MoveNext()
        Next

        'txtItemdivcode.Text = ""

       
       

    End Sub
    Private Sub loadedit()

        If M_rsitemedit.State = 1 Then M_rsitemedit.Close()
        M_rsitemedit.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        M_rsitemedit.Open("SELECT * FROM Item WHERE ITEMDEL = 0 AND IsActive = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        cboedit.Items.Clear()
        If M_rsitemedit.RecordCount = 0 Then Exit Sub
        For m As Integer = 0 To M_rsitemedit.RecordCount - 1
            cboedit.Items.Add(M_rsitemedit.Fields("ITEMCD").Value)
            M_rsitemedit.MoveNext()
        Next

        'txtItemdivcode.Text = ""
    End Sub

   
    Private Sub cbomthecode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbomthecode.SelectedIndexChanged
        txtmathercode.Text = ""
        Dim rsItem As New ADODB.Recordset
        If rsItem.State = 1 Then rsItem.Close()
        rsItem.Open("Select *  from Item WHERE ITEMDEL = 0 AND ITEMCD = '" & cbomthecode.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsItem.RecordCount <> 0 Then

        End If

        txtmathercode.Text = rsItem.Fields("IMDBRN").Value
        txtItemCode.Text = rsItem.Fields("ITEMCD").Value
        txtItemdivcode.Text = rsItem.Fields("ITEMDIVCD").Value
        txtitemname.Text = rsItem.Fields("IMDBRN").Value
        txtdivname.Text = rsItem.Fields("ITEMDIVNAME").Value
        LoadItemsToGrid()





    End Sub
   


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim address As Point = Me.dgtails.CurrentCellAddress

        If address.Y > 0 Then
            address.Y -= 1
        End If

        Me.dgtails.CurrentCell = Me.dgtails(address.X, address.Y)
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        
        Dim address As Point = Me.dgtails.CurrentCellAddress

        If address.Y < Me.dgtails.RowCount - 1 Then
            address.Y += 1
        End If

        Me.dgtails.CurrentCell = Me.dgtails(address.X, address.Y)

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        SetupbyOperation(True)
        Operation = "Add"
        Clear()
        cbomthecode.Visible = True
        cboedit.Visible = False

    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        SetupbyOperation(True)
        Operation = "Edit"
        cboedit.Visible = True
        cbomthecode.Visible = False


    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim q As MsgBoxResult
        q = VDialog.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If q = MsgBoxResult.Yes Then
            delete()
            Clear()
        End If

    End Sub

    Private Sub delete()
        Dim rs As New ADODB.Recordset
        If Not txtItemCode.Text = "" Then
            Try
                SPMSConn.Execute("EXEC uspitemteammap @Action = 'UPDATE' , @ITEMCD = '" & txtItemCode.Text & "', @Dltflg = 1 ")
                rs.Open("Delete from itemteammap where Dltflg = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                VDialog.Show("Record Sucessfully Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadItemsToGrid()
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try

        Else
            VDialog.Show("There are no record to be deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub



    Private Function CheckRecordExists(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM ITEMTEAMMAP WHERE ITEMCD= '" & txtItemCode.Text & "' AND dltflg = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function SaveRecord(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("EXEC USPITEMTEAMMAP @ACTION = 'ADD', @Dltflg = 0, @ITMDIVCD = '" & HandleSingleQuoteInSql(txtItemdivcode.Text) & "', @ITMTMCD = '" & HandleSingleQuoteInSql(txtItemdivcode.Text) & "', @ITMTMNM = '" & HandleSingleQuoteInSql(txtdivname.Text) & "', @itemthr = '" & HandleSingleQuoteInSql(txtItemCode.Text) & "',  @ITEMCD = '" & HandleSingleQuoteInSql(txtItemCode.Text) & "', @ITEMNAME = '" & HandleSingleQuoteInSql(txtitemname.Text) & "' , @IsActive = " & chkIsActive.Checked & "  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return True
    End Function
    Private Function DeleteRecord(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("EXEC USPITEMTEAMMAP @ACTION = 'UPDATE', @Dltflg = 1, @itemcd = '" & txtItemCode.Text & "' , @IsActive = " & chkIsActive.Checked & " ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        rs.Open("Delete from itemteammap where Dltflg = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return True
    End Function
    Private Function UpdateRecord(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("EXEC USPITEMTEAMMAP @ACTION = 'UPDATE', @Dltflg = 0, @ITMDIVCD = '" & txtItemdivcode.Text & "', @ITMTMCD = '" & txtItemdivcode.Text & "', @ITMTMNM = '" & txtdivname.Text & "', @itemthr = '" & cboedit.Text & "',  @ITEMCD = '" & txtItemCode.Text & "', @ITEMNAME = '" & HandleSingleQuoteInSql(txtitemname.Text) & "' , @IsActive = " & chkIsActive.Checked & "  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return True
    End Function
   
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Operation = "Add" Then
            If CheckRecordExists(txtItemCode.Text) = False Then
                SaveRecord(txtItemdivcode.Text)
                SetupbyOperation(False)
                Operation = ""
                LoadItemsToGrid()
                VDialog.Show("Successfull new ItemMapping", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Clear()
            Else

                VDialog.Show("Record Already Exists", "Record Exists", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        ElseIf Operation = "Edit" Then
            UpdateRecord(txtItemCode.Text)
            SetupbyOperation(False)
            Operation = ""
            LoadItemsToGrid()
            VDialog.Show("Successfull update ItemMapping", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboedit.Visible = False
            cbomthecode.Visible = True
            Clear()
        Else
            VDialog.Show("Record Already Exists", "Record Exists", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If

    End Sub
    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False

        If Not IsNumeric(txtItemCode.Text) Then
            m_Err.SetError(txtItemCode, "Item Code is Number only")
            m_HasError = True

        End If

        If txtItemCode.Text = "" Then
            m_Err.SetError(cbomthecode, "Item Code is required")
            m_HasError = True
        End If


        If txtItemdivcode.Text = "" Then
            m_Err.SetError(txtItemCode, "Item division Code is required")
            m_HasError = True
        End If

       

        If txtitemname.Text = "" Then
            m_Err.SetError(txtitemname, "Item  description is required")
            m_HasError = True
        End If
        If txtdivname.Text = "" Then
            m_Err.SetError(txtdivname, "Item  division name is required")
            m_HasError = True

        Else
            If m_IsNewMode Then
                If Not CheckIfItemExist(txtItemCode.Text) Then
                    ShowExclamation("Record Already Exist", "Save")
                    m_HasError = True
                End If
            End If
        End If
        Return Not m_HasError
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub dgtails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgtails.CellContentClick
        Dim i As Integer

        i = dgtails.CurrentRow.Index

        txtItemCode.Text = dgtails.Item(0, i).Value
        txtItemdivcode.Text = dgtails.Item(1, i).Value
        txtdivname.Text = dgtails.Item(3, i).Value
        txtitemname.Text = dgtails.Item(2, i).Value
    End Sub

    Private Sub dgtails_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgtails.CellMouseClick
        Dim i As Integer

        i = dgtails.CurrentRow.Index

        txtItemCode.Text = dgtails.Item(0, i).Value
        txtItemdivcode.Text = dgtails.Item(1, i).Value
        txtdivname.Text = dgtails.Item(3, i).Value
        txtitemname.Text = dgtails.Item(2, i).Value
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub cboedit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboedit.SelectedIndexChanged
        txtmathercode.Text = ""
        Dim rsItem As New ADODB.Recordset
        If rsItem.State = 1 Then rsItem.Close()
        rsItem.Open("Select *  from Item WHERE ITEMDEL = 0 AND ITEMCD = '" & cbomthecode.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsItem.RecordCount <> 0 Then

        End If

        ' txtmathercode.Text = rsItem.Fields("IMDBRN").Value
        'txtItemdivcode.Text = rsItem.Fields("ITEMDIVCD").Value
        ' txtitemname.Text = rsItem.Fields("IMDBRN").Value
        ' txtdivname.Text = rsItem.Fields("ITEMDIVNAME").Value
        LoadItemsToGrid()
    End Sub

    Private Sub txtcount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcount.TextChanged

    End Sub
End Class
