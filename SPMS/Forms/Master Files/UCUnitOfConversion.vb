Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Public Class UCUnitOfConversion
    Private _UnitOfConversion As New UMConversion
    Private _Items As New Items
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_Edit As Integer = 0
    Private m_EditText As Boolean = False
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        LinkLabel2.Enabled = IsEditMode
        LinkLabel5.Enabled = IsEditMode
        LinkLabel1.Enabled = IsEditMode

        txtCode.ReadOnly = Not IsEditMode
        txtCode.BackColor = Color.White

        txtDescription.ReadOnly = Not IsEditMode
        txtDescription.BackColor = Color.White

        txtFrom.ReadOnly = Not IsEditMode
        txtFrom.BackColor = Color.White

        txtTo.ReadOnly = Not IsEditMode
        txtTo.BackColor = Color.White

        txtQty.ReadOnly = Not IsEditMode
        txtQty.BackColor = Color.White

        txtItemCode.ReadOnly = Not IsEditMode
        txtItemCode.BackColor = Color.White

        txtItemName.ReadOnly = Not IsEditMode
        txtItemName.BackColor = Color.White
    End Sub
    Private Sub Clear()
        txtCode.Text = String.Empty
        txtDescription.Text = String.Empty
        txtItemCode.Text = String.Empty
        txtItemName.Text = String.Empty
        txtDescription.Text = String.Empty
        txtFrom.Text = String.Empty
        txtTo.Text = String.Empty
        txtQty.Text = String.Empty
        cmdMathOperation.Text = String.Empty
    End Sub
    Private Sub EnableEdit(ByVal IsEditMode As Boolean)
        'btnSave.Enabled = Not IsEditMode
        'btnEdit.Enabled = Not IsEditMode
        'btnNew.Enabled = Not IsEditMode
        'btnDelete.Enabled = Not IsEditMode

        LinkLabel2.Enabled = Not IsEditMode
        LinkLabel5.Enabled = Not IsEditMode
        LinkLabel1.Enabled = Not IsEditMode

        txtCode.ReadOnly = IsEditMode
        txtCode.BackColor = Color.WhiteSmoke

        txtDescription.ReadOnly = IsEditMode
        txtDescription.BackColor = Color.WhiteSmoke

        txtQty.ReadOnly = IsEditMode
        txtQty.BackColor = Color.WhiteSmoke


        txtFrom.ReadOnly = Not IsEditMode
        txtFrom.BackColor = Color.WhiteSmoke

        txtTo.ReadOnly = Not IsEditMode
        txtTo.BackColor = Color.WhiteSmoke

        txtItemCode.ReadOnly = Not IsEditMode
        txtItemCode.BackColor = Color.WhiteSmoke

        txtItemName.ReadOnly = Not IsEditMode
        txtItemName.BackColor = Color.WhiteSmoke
    End Sub
    Private Sub NewRecord()
        Clear()
        _UnitOfConversion = New UMConversion
        EditMode(True)
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnDelete.Click, btnEdit.Click, btnFinddata.Click, btnSave.Click, btnClear.Click, btnClose.Click
        If sender Is btnNew Then
            NewRecord()
        ElseIf sender Is btnDelete Then
            Delete()
        ElseIf sender Is btnEdit Then
            EditMode(True)
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
                EnableEdit(False)
            End If
        End If
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(UMConversion.GetUMConversionSql, "Unit of Conversion")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
            EnableEdit(True)
        End If
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog() = MsgBoxResult.Yes Then
            If _UnitOfConversion.Delete Then
                DeleteSuccess()
                Clear()
                EditMode(False)
            Else
                UnDeleteSuccess()
                Clear()
                EditMode(False)
            End If
        End If
    End Sub
    Private Sub SaveRecord()
        _UnitOfConversion.Code = txtCode.Text
        _UnitOfConversion.DescriptionName = txtDescription.Text
        _UnitOfConversion.UnitFromCode = txtFrom.Text
        _UnitOfConversion.UnitTo = txtTo.Text
        _UnitOfConversion.ConversionQty = txtQty.Text
        _UnitOfConversion.MathOperation = cmdMathOperation.Text
        _UnitOfConversion.ItemCode = txtItemCode.Text
        If chkIsActive.Enabled = True Then
            _UnitOfConversion.IsActive = True
        Else
            _UnitOfConversion.IsActive = False
        End If
        If _UnitOfConversion.Save Then
            SaveSuccess()
            ShowData(_UnitOfConversion.UMConversionID)
            EditMode(False)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        If RecordCode < 1 Then Exit Sub
        _UnitOfConversion = UMConversion.Load(RecordCode)
        txtCode.Tag = _UnitOfConversion.UMConversionID
        txtCode.Text = _UnitOfConversion.Code
        txtFrom.Text = _UnitOfConversion.UnitFromCode
        txtTo.Text = _UnitOfConversion.UnitTo
        txtDescription.Text = _UnitOfConversion.DescriptionName
        cmdMathOperation.Text = _UnitOfConversion.MathOperation
        txtQty.Text = _UnitOfConversion.ConversionQty
        LoadItem(_UnitOfConversion.ItemCode)
        If _UnitOfConversion.IsActive = True Then
            chkIsActive.Enabled = True
        Else
            chkIsActive.Enabled = False
        End If
        EditMode(False)
    End Sub
    Private Sub LoadItem(ByVal ItemCode As String)
        _Items = Items.LoadByItemCode(ItemCode)
        txtItemCode.Text = _Items.ItemCode
        txtItemName.Text = _Items.ItemBrand
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If txtCode.Text = "" Then
            m_Err.SetError(txtCode, "Code is Required")
            m_HasError = True
        Else
            If UMConversion.CheckUMConversion(txtCode.Text, IIf(txtCode.Tag Is Nothing, -1, txtCode.Tag)) Then
                m_Err.SetError(txtCode, "Code is Already Exist")
                m_HasError = True
            End If
        End If
        If txtDescription.Text = "" Then
            m_Err.SetError(txtDescription, "Description Name is Required!")
            m_HasError = True
        End If
        If txtFrom.Text = "" Then
            m_Err.SetError(txtFrom, "From Conversion is Required!")
            m_HasError = True
        End If
        If txtTo.Text = "" Then
            m_Err.SetError(txtTo, "To Conversion is Required!")
            m_HasError = True
        End If
        If txtQty.Text = "" Then
            m_Err.SetError(txtQty, "Quantity Conversion is Required!")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(UnitOfMeasurement.GetUnitOfMeasurementSql, "Unit of Measurement")
        If Not tag Is Nothing Then
            txtFrom.Text = tag.KeyColumn22
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(UnitOfMeasurement.GetUnitOfMeasurementSql, "Unit of Measurement")
        If Not tag Is Nothing Then
            txtTo.Text = tag.KeyColumn22
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Items.GetItemSql, "Search Item")
        If Not tag Is Nothing Then
            txtItemCode.Text = tag.KeyColumn22
            txtItemName.Text = tag.KeyColumn44
        End If
    End Sub
End Class
