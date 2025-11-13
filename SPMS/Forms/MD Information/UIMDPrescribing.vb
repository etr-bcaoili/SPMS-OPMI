Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.Windows
Imports Telerik.WinControls
Imports Telerik.Windows.Controls
Imports Telerik.WinControls.UI
Imports System.Text
Imports DataLayer
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Public Class UIMDPrescribing
    Private _MDPrescribing As New MDPrescription
    Private _MDSpecialization As New MDSpecialization
    Private _MDProduct As New MDPrescritionProduct
    Private _MDAccount As New MDPrescriptionAccount
    Private _MDPrescritionMappingCredite As New MDPrescritionMappingCredite
    Private _Item As New Items
    Private table As New DataTable
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False

    Private m_SpecializationCode As String = String.Empty

    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtMDCode.ReadOnly = Not IsEditMode
        txtMDCode.BackColor = Color.White

        txtlastName.ReadOnly = Not IsEditMode
        txtlastName.BackColor = Color.White

        txtFirstName.ReadOnly = Not IsEditMode
        txtFirstName.BackColor = Color.White

        txtMiddleName.ReadOnly = Not IsEditMode
        txtMiddleName.BackColor = Color.White

        txtSpecialization.ReadOnly = Not IsEditMode
        txtSpecialization.BackColor = Color.White

    End Sub
    Private Sub Clear()
        txtMDCode.Text = String.Empty
        txtlastName.Text = String.Empty
        txtFirstName.Text = String.Empty
        txtMiddleName.Text = String.Empty
        txtSpecialization.Text = String.Empty
        GrdMapping.Rows.Clear()
        GrdProductView.Rows.Clear()
        GrdCustomerView.Rows.Clear()
        EditMode(False)
    End Sub
    Private Sub NewRecord()
        Clear()
        _MDPrescribing = New MDPrescription
        txtMDCode.Text = MDPrescription.GenerateNewMDCode()
        Ischeck.Checked = True
        EditMode(True)
    End Sub
    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
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
        ElseIf sender Is btnClose Then
            Close()
        ElseIf sender Is btnFinddata Then
            Find()
        ElseIf sender Is btnSave Then
            If ValidateData() Then
                SaveRecord()
                SaveRecordItem()
                SaveRecordCustomer()
                SaveRecordMapping
            End If
        End If
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(MDPrescription.GetMDPrescriptionSql, "Employee Salesman")
        If Not tag Is Nothing Then
            Clear()
            ShowDataMD(tag.KeyColumn11)
            ShowDataMDPR(tag.KeyColumn11)
            ShowDataMDAccountsbyMDID(tag.KeyColumn11)
            ShowDataMappingbyMDID(tag.KeyColumn11)
            EditMode(False)
        End If
    End Sub
    Private Sub ShowDataMD(ByVal RecordCode As String)
        If RecordCode < 1 Then Exit Sub
        _MDPrescribing = MDPrescription.Load(RecordCode)
        txtMDCode.Tag = _MDPrescribing.MDID
        txtMDCode.Text = _MDPrescribing.MDCode
        txtlastName.Text = _MDPrescribing.LastName
        txtFirstName.Text = _MDPrescribing.FirstName
        txtMiddleName.Text = _MDPrescribing.MiddleName
        If _MDPrescribing.SPCode <> "" Then
            _MDSpecialization = MDSpecialization.LoadByCode(_MDPrescribing.SPCode)
            m_SpecializationCode = _MDSpecialization.Code
            txtSpecialization.Text = _MDSpecialization.Description
        Else
            txtSpecialization.Text = ""
        End If

        EditMode(False)
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If txtMDCode.Text = "" Then
            m_Err.SetError(txtMDCode, "MD Code is Required!")
            m_HasError = True
        Else
            If MDPrescription.CheckofMDPrecriptionAlreadyExist(txtMDCode.Text, IIf(txtMDCode.Tag Is Nothing, -1, txtMDCode.Tag)) Then
                m_Err.SetError(txtMDCode, "MD Code Already Exist")
                m_HasError = True
            End If
        End If

        If txtlastName.Text = "" Then
            m_Err.SetError(txtlastName, "MD Last Name is Required!")
            m_HasError = True
        End If

        If txtFirstName.Text = "" Then
            m_Err.SetError(txtFirstName, "MD First Name is Required!")
            m_HasError = True
        End If

        If txtMiddleName.Text = "" Then
            m_Err.SetError(txtMiddleName, "MD Middle Name is Required!")
            m_HasError = True
        End If

        If txtSpecialization.Text = "" Then
            m_Err.SetError(txtSpecialization, "MD Specialization is Required!")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
    Private Sub SaveRecord()
        _MDPrescribing.MDCode = txtMDCode.Text
        _MDPrescribing.LastName = txtlastName.Text
        _MDPrescribing.FirstName = txtFirstName.Text
        _MDPrescribing.MiddleName = txtMiddleName.Text
        _MDPrescribing.SPCode = m_SpecializationCode

        If Ischeck.Checked = True Then
            _MDPrescribing.IsDeleted = True
        Else
            _MDPrescribing.IsDeleted = False
        End If

        If _MDPrescribing.Save Then
            SaveSuccess()
            ShowDataMD(_MDPrescribing.MDID)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub SaveRecordCustomer()
        _MDAccount.MDID = _MDPrescribing.MDID
        _MDAccount.Delete()

        For a As Integer = 0 To GrdCustomerView.Rows.Count - 1
            Dim GrdCustomerViews As GridViewRowInfo = GrdCustomerView.Rows(a)
            _MDAccount = New MDPrescriptionAccount
            _MDAccount.MDID = _MDPrescribing.MDID
            _MDAccount.AccountCode = GrdCustomerViews.Cells(0).Value
            _MDAccount.AccountName = GrdCustomerViews.Cells(1).Value
            _MDAccount.ShipToCode = GrdCustomerViews.Cells(2).Value
            _MDAccount.ChannelCode = GrdCustomerViews.Cells(9).Value
            _MDAccount.Save()
        Next
    End Sub
    Private Sub SaveRecordItem()
        _MDProduct.MDID = _MDPrescribing.MDID
        _MDProduct.Delete()
        For a As Integer = 0 To GrdProductView.Rows.Count - 1
            Dim GrdProductViews As GridViewRowInfo = GrdProductView.Rows(a)
            _MDProduct = New MDPrescritionProduct
            _MDProduct.MDID = _MDPrescribing.MDID
            _MDProduct.ItemCode = GrdProductViews.Cells(0).Value
            _MDProduct.ItemDescription = GrdProductViews.Cells(1).Value
            _MDProduct.ProductGroup = GrdProductViews.Cells(2).Value
            _MDProduct.Save()
        Next
    End Sub
    Private Sub SaveRecordMapping()
        _MDPrescritionMappingCredite.MDID = _MDPrescribing.MDID
        _MDPrescritionMappingCredite.Delete()
        For a As Integer = 0 To GrdMapping.Rows.Count - 1
            Dim GrdMappingCredite As GridViewRowInfo = GrdMapping.Rows(a)
            _MDPrescritionMappingCredite = New MDPrescritionMappingCredite
            _MDPrescritionMappingCredite.MDID = _MDPrescribing.MDID
            _MDPrescritionMappingCredite.DMCode = GrdMappingCredite.Cells(0).Value
            _MDPrescritionMappingCredite.EmployeeCode = GrdMappingCredite.Cells(1).Value
            _MDPrescritionMappingCredite.PMRCode = GrdMappingCredite.Cells(3).Value
            _MDPrescritionMappingCredite.Save()
        Next
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog() = DialogResult.Yes Then
            If _MDPrescribing.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub

    Private Sub btnOpefile_specialization_Click(sender As Object, e As EventArgs) Handles btnOpefile_specialization.Click
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(MDSpecialization.GetSpecializationSql, "Specialization")
        If Not tag Is Nothing Then
            m_SpecializationCode = tag.KeyColumn22
            txtSpecialization.Text = tag.KeyColumn33
        End If
    End Sub

    Private Sub btnItemOpenFile_Click(sender As Object, e As EventArgs) Handles btnItemOpenFile.Click
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Items.GetItemlistWithProductGroup, "Item and Product")
        If Not tag Is Nothing Then

            Dim rowInfo As GridViewRowInfo = GrdProductView.Rows.AddNew
            rowInfo.Cells(0).Value = tag.KeyColumn11
            rowInfo.Cells(1).Value = tag.KeyColumn22
            rowInfo.Cells(2).Value = tag.KeyColumn33
        End If
    End Sub
    Private Sub ShowDataMDPR(ByVal MDID As Integer)
        GrdProductView.Rows.Clear()
        table = GetRecords(MDPrescritionProduct.GetMDPrescriptionProductSql(MDID))
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowInfo As GridViewRowInfo = GrdProductView.Rows.AddNew
            rowInfo.Cells(0).Value = table.Rows(i)("ItemCode")
            rowInfo.Cells(1).Value = table.Rows(i)("ItemDescription")
            rowInfo.Cells(2).Value = table.Rows(i)("ProductGroup")
        Next
    End Sub

    Private Sub btnAccountOpenFile_Click(sender As Object, e As EventArgs) Handles btnAccountOpenFile.Click
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(CustomerShipTo.GetMDPrescriptionCustomer, "MD Prescription Customer")
        If Not tag Is Nothing Then
            ShowDataMDCustomer(tag.KeyColumn11)
        End If
    End Sub
    Private Sub ShowDataMDAccount(ByVal CustomerID As Integer)
        table = GetRecords(CustomerShipTo.GetMDPrescriptionCustomers(CustomerID))
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowInfo As GridViewRowInfo = GrdCustomerView.Rows.AddNew
            rowInfo.Cells(0).Value = table.Rows(i)("Customercd")
            rowInfo.Cells(1).Value = table.Rows(i)("CDANAME")
            rowInfo.Cells(2).Value = table.Rows(i)("CDACD")
            rowInfo.Cells(3).Value = table.Rows(i)("CDACADD1")
            rowInfo.Cells(4).Value = table.Rows(i)("CDACADD2")
            rowInfo.Cells(5).Value = table.Rows(i)("REGNAME")
            rowInfo.Cells(6).Value = table.Rows(i)("DISTRCTNAME")
            rowInfo.Cells(7).Value = table.Rows(i)("AREANAME")
            rowInfo.Cells(8).Value = table.Rows(i)("CustomerGroupName")
            rowInfo.Cells(9).Value = table.Rows(i)("COMID")
        Next
    End Sub
    Private Sub ShowDataMDCustomer(ByVal CustomerID As Integer)
        table = GetRecords(CustomerShipTo.GetMDPrescriptionCustomers(CustomerID))
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowInfo As GridViewRowInfo = GrdCustomerView.Rows.AddNew
            rowInfo.Cells(0).Value = table.Rows(i)("Customercd")
            rowInfo.Cells(1).Value = table.Rows(i)("CDANAME")
            rowInfo.Cells(2).Value = table.Rows(i)("CDACD")
            rowInfo.Cells(3).Value = table.Rows(i)("CDACADD1")
            rowInfo.Cells(4).Value = table.Rows(i)("CDACADD2")
            rowInfo.Cells(5).Value = table.Rows(i)("REGNAME")
            rowInfo.Cells(6).Value = table.Rows(i)("DISTRCTNAME")
            rowInfo.Cells(7).Value = table.Rows(i)("AREANAME")
            rowInfo.Cells(8).Value = table.Rows(i)("CustomerGroupName")
            rowInfo.Cells(9).Value = table.Rows(i)("COMID")
        Next
    End Sub

    Private Sub btnMappingOpenFile_Click(sender As Object, e As EventArgs) Handles btnMappingOpenFile.Click
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(MDPrescritionMappingCredite.GetMDPrescritionMappingCredite, "Mapping Credite")
        If Not tag Is Nothing Then
            ShowDataMDMapping(tag.KeyColumn11)
        End If
    End Sub
    Private Sub ShowDataMDAccountsbyMDID(ByVal MDID As Integer)
        GrdCustomerView.Rows.Clear()
        table = GetRecords(CustomerShipTo.GetMDPrescriptionCustomersbyMDID(MDID))
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowInfo As GridViewRowInfo = GrdCustomerView.Rows.AddNew
            rowInfo.Cells(0).Value = table.Rows(i)("Customercd")
            rowInfo.Cells(1).Value = table.Rows(i)("CDANAME")
            rowInfo.Cells(2).Value = table.Rows(i)("CDACD")
            rowInfo.Cells(3).Value = table.Rows(i)("CDACADD1")
            rowInfo.Cells(4).Value = table.Rows(i)("CDACADD2")
            rowInfo.Cells(5).Value = table.Rows(i)("REGNAME")
            rowInfo.Cells(6).Value = table.Rows(i)("DISTRCTNAME")
            rowInfo.Cells(7).Value = table.Rows(i)("AREANAME")
            rowInfo.Cells(8).Value = table.Rows(i)("CustomerGroupName")
            rowInfo.Cells(9).Value = table.Rows(i)("COMID")
        Next
    End Sub
    Private Sub ShowDataMDMapping(ByVal EmployeeID As Integer)
        table = GetRecords(MDPrescritionMappingCredite.GetMDPrescritionMappingCredites(EmployeeID))
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowInfo As GridViewRowInfo = GrdMapping.Rows.AddNew
            rowInfo.Cells(0).Value = table.Rows(i)("STDISTRCTCD")
            rowInfo.Cells(1).Value = table.Rows(i)("STSLSMGRNAME")
            rowInfo.Cells(2).Value = table.Rows(i)("EmployeeCode")
            rowInfo.Cells(3).Value = table.Rows(i)("STSLSMNCD")
            rowInfo.Cells(4).Value = table.Rows(i)("PMR Name")
            rowInfo.Cells(5).Value = table.Rows(i)("TerritoryCode")
            rowInfo.Cells(6).Value = table.Rows(i)("STACOVNAME")
        Next
    End Sub
    Private Sub ShowDataMappingbyMDID(ByVal MDID As Integer)
        GrdMapping.Rows.Clear()
        table = GetRecords(MDPrescritionMappingCredite.GetMDPrescritionMappingCreditebyMDID(MDID))
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowInfo As GridViewRowInfo = GrdMapping.Rows.AddNew
            rowInfo.Cells(0).Value = table.Rows(i)("STDISTRCTCD")
            rowInfo.Cells(1).Value = table.Rows(i)("STSLSMGRNAME")
            rowInfo.Cells(2).Value = table.Rows(i)("EmployeeCode")
            rowInfo.Cells(3).Value = table.Rows(i)("STSLSMNCD")
            rowInfo.Cells(4).Value = table.Rows(i)("PMR Name")
            rowInfo.Cells(5).Value = table.Rows(i)("TerritoryCode")
            rowInfo.Cells(6).Value = table.Rows(i)("STACOVNAME")
        Next
    End Sub

    Private Sub UIMDPrescribing_ForeColorChanged(sender As Object, e As EventArgs) Handles Me.ForeColorChanged

    End Sub

    Private Sub UIMDPrescribing_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.GrdCustomerView.TableElement.RowHeight = 35
        Me.GrdMapping.TableElement.RowHeight = 35
        Me.GrdProductView.TableElement.RowHeight = 35
    End Sub

    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
        Dim selectedRows(Me.GrdProductView.SelectedRows.Count - 1) As GridViewRowInfo
        Me.GrdProductView.SelectedRows.CopyTo(selectedRows, 0)
        Me.GrdProductView.TableElement.BeginUpdate()
        For i As Integer = 0 To selectedRows.Length - 1
            Me.GrdProductView.Rows.Remove(TryCast(selectedRows(i), GridViewDataRowInfo))
        Next i
        Me.GrdProductView.TableElement.EndUpdate()
    End Sub

    Private Sub btnRemoveAccount_Click(sender As Object, e As EventArgs) Handles btnRemoveAccount.Click
        Dim selectedRows(Me.GrdCustomerView.SelectedRows.Count - 1) As GridViewRowInfo
        Me.GrdCustomerView.SelectedRows.CopyTo(selectedRows, 0)
        Me.GrdCustomerView.TableElement.BeginUpdate()
        For i As Integer = 0 To selectedRows.Length - 1
            Me.GrdCustomerView.Rows.Remove(TryCast(selectedRows(i), GridViewDataRowInfo))
        Next i
        Me.GrdCustomerView.TableElement.EndUpdate()
    End Sub

    Private Sub btnRemoveMapping_Click(sender As Object, e As EventArgs) Handles btnRemoveMapping.Click
        Dim selectedRows(Me.GrdMapping.SelectedRows.Count - 1) As GridViewRowInfo
        Me.GrdMapping.SelectedRows.CopyTo(selectedRows, 0)
        Me.GrdMapping.TableElement.BeginUpdate()
        For i As Integer = 0 To selectedRows.Length - 1
            Me.GrdMapping.Rows.Remove(TryCast(selectedRows(i), GridViewDataRowInfo))
        Next i
        Me.GrdMapping.TableElement.EndUpdate()
    End Sub
End Class
