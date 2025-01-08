Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Public Class UICustomerEntrys
    Dim Table As New DataTable
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False

    Private m_Customer As New Customer
    Private m_CustomerShipTo As New CustomerShipTo
    Private m_Proponent As New DispensingProponent
    Private m_Pioneer As New DispensingPioneer
    Private m_Distributor As New Distributor
    Private m_CreditTerms As New CreditTerms
    Private m_CustomerGroup As New CustomerGroup
    Private m_Coodinator As New Coordinator
    Private m_CustomerCoordinator As New CustomerCoordinator
    Private m_CustomerClass As New CustomerClass
    Private m_Regions As New Regions
    Private m_District As New Districts
    Private m_Area As New Area
    Private m_ZipCode As New ZipCodes

    Private m_Vat As Boolean = False
    Private m_AccountShared As Boolean = False
    Private m_EditCustomer As Boolean = False
    Private m_ProponentShipto As String = String.Empty
    Private m_CustomerShiptoCodeID As String = String.Empty
    Private Property Vat As Boolean
        Get
            Return m_Vat
        End Get
        Set(value As Boolean)
            m_Vat = value
        End Set
    End Property
    Private Property AccoutShared As Boolean
        Get
            Return m_AccountShared
        End Get
        Set(value As Boolean)
            m_AccountShared = value
        End Set
    End Property
    Private Property ProponentShipto As String
        Get
            Return m_ProponentShipto
        End Get
        Set(value As String)
            m_ProponentShipto = value
        End Set
    End Property
    Private Sub EnableTextBox(ByVal IsEditMode As Boolean)
        txtCustomerCode.Enabled = Not IsEditMode
    End Sub
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtDistributorCode.ReadOnly = Not IsEditMode
        txtDistributorCode.BackColor = Color.White

        txtDistributorName.ReadOnly = Not IsEditMode
        txtDistributorName.BackColor = Color.White


        txtCustomerCode.ReadOnly = Not IsEditMode
        txtCustomerCode.BackColor = Color.White

        txtCustomerName.ReadOnly = Not IsEditMode
        txtCustomerName.BackColor = Color.White

        txtAddress1.ReadOnly = Not IsEditMode
        txtAddress1.BackColor = Color.White

        txtAddress2.ReadOnly = Not IsEditMode
        txtAddress2.BackColor = Color.White

        txtContactPerson.ReadOnly = Not IsEditMode
        txtContactPerson.BackColor = Color.White

        txtPhoneNumber.ReadOnly = Not IsEditMode
        txtPhoneNumber.BackColor = Color.White


        txtDiscount.ReadOnly = Not IsEditMode
        txtDiscount.BackColor = Color.White

        txtCustomerShiptoCode.ReadOnly = Not IsEditMode
        txtCustomerShiptoCode.BackColor = Color.White

        txtCustomerShiptoName.ReadOnly = Not IsEditMode
        txtCustomerShiptoName.BackColor = Color.White


        txtCustomerGroupCode.ReadOnly = Not IsEditMode
        txtCustomerGroupCode.BackColor = Color.White

        txtCustomerClassCode.ReadOnly = Not IsEditMode
        txtCustomerClassCode.BackColor = Color.White

        txtCustomerClassName.ReadOnly = Not IsEditMode
        txtCustomerClassName.BackColor = Color.White

        txtCoordinatorCode.ReadOnly = Not IsEditMode
        txtCoordinatorCode.BackColor = Color.White

        txtCoordinatorName.ReadOnly = Not IsEditMode
        txtCoordinatorName.BackColor = Color.White

        txtRegionCode.ReadOnly = Not IsEditMode
        txtRegionCode.BackColor = Color.White

        txtRegionName.ReadOnly = Not IsEditMode
        txtRegionName.BackColor = Color.White

        txtProvinceCode.ReadOnly = Not IsEditMode
        txtProvinceCode.BackColor = Color.White

        txtProvinceName.ReadOnly = Not IsEditMode
        txtProvinceName.BackColor = Color.White

        txtMunicipalCode.ReadOnly = Not IsEditMode
        txtMunicipalCode.BackColor = Color.White

        txtMunicipalDescription.ReadOnly = Not IsEditMode
        txtMunicipalDescription.BackColor = Color.White

        txtZipCode.ReadOnly = Not IsEditMode
        txtZipCode.BackColor = Color.White

        txtZipDescription.ReadOnly = Not IsEditMode
        txtZipDescription.BackColor = Color.White

        txtProponentCode.ReadOnly = Not IsEditMode
        txtProponentCode.BackColor = Color.White

        txtproponetName.ReadOnly = Not IsEditMode
        txtproponetName.BackColor = Color.White


        txtPioneerCode.ReadOnly = Not IsEditMode
        txtPioneerCode.BackColor = Color.White

        txtPioneerName.ReadOnly = Not IsEditMode
        txtPioneerName.BackColor = Color.White

        txtRemarks.ReadOnly = Not IsEditMode
        txtRemarks.BackColor = Color.White

        txtCustomerGroupName.ReadOnly = Not IsEditMode
        txtCustomerGroupName.BackColor = Color.White


    End Sub
    Private Sub Clear()
        txtDistributorCode.Text = String.Empty
        txtDistributorName.Text = String.Empty
        txtCustomerCode.Text = String.Empty
        txtCustomerName.Text = String.Empty
        txtAddress1.Text = String.Empty
        txtAddress2.Text = String.Empty
        txtContactPerson.Text = String.Empty
        txtPhoneNumber.Text = String.Empty
        txtDiscount.Text = String.Empty
        txtCustomerShiptoCode.Text = String.Empty
        txtCustomerShiptoName.Text = String.Empty
        txtCustomerGroupCode.Text = String.Empty
        txtCustomerClassCode.Text = String.Empty
        txtCustomerClassName.Text = String.Empty
        txtCoordinatorCode.Text = String.Empty
        txtCoordinatorName.Text = String.Empty
        txtRegionCode.Text = String.Empty
        txtRegionName.Text = String.Empty
        txtProvinceCode.Text = String.Empty
        txtProvinceName.Text = String.Empty
        txtMunicipalCode.Text = String.Empty
        txtMunicipalDescription.Text = String.Empty
        txtZipCode.Text = String.Empty
        txtZipDescription.Text = String.Empty
        chkAccountShared.Checked = False
        chkVatable.Checked = False
        CheckAutoCreateDefaultShipTo.Checked = False
        txtCustomerGroupName.Text = String.Empty
        txtProponentCode.Text = String.Empty
        txtproponetName.Text = String.Empty
        txtPioneerCode.Text = String.Empty
        txtPioneerName.Text = String.Empty
        ChckLoyaltyCustomer.Checked = False
        chckDataTransferStocks.Checked = False
        chckLoyaltyMD.Checked = False
    End Sub
    Private Sub lnkMotherCode_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkMotherCode.LinkClicked
        Clear()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Distributor.GetDistributorSql, "Search Item")
        If Not tag Is Nothing Then
            LoadChannel(tag.KeyColumn22)
        End If
    End Sub
    Private Sub NewRecord()
        Clear()
        m_CustomerShipTo = New CustomerShipTo
        m_Proponent = New DispensingProponent
        EditMode(True)
    End Sub
    Private Sub LoadChannel(ByVal ChannelCode As String)
        m_Distributor = Distributor.LoadByCode(ChannelCode)
        txtDistributorCode.Text = m_Distributor.DISTCOMID
        txtDistributorName.Text = m_Distributor.DISTNAME
    End Sub
    Private Sub SaveRecordShipTo()
        m_CustomerShipTo.COMID = txtDistributorCode.Text
        m_CustomerShipTo.CUSTOMERCD = txtCustomerCode.Text
        m_CustomerShipTo.CDANAME = txtCustomerName.Text
        m_CustomerShipTo.CDACADD1 = txtAddress1.Text
        m_CustomerShipTo.CDACADD2 = txtAddress2.Text
        m_CustomerShipTo.CDACD = txtCustomerShiptoCode.Text
        m_CustomerShipTo.CDACONT = txtContactPerson.Text
        m_CustomerShipTo.CDAPHON = txtPhoneNumber.Text

        If chkIsActive.Checked = True Then
            m_CustomerShipTo.IsActive = True
        Else
            m_CustomerShipTo.IsActive = False
        End If
        If chkAccountShared.Checked = True Then
            m_CustomerShipTo.ACCNTSHRD = True
        Else
            m_CustomerShipTo.ACCNTSHRD = False
        End If
        If chkVatable.Checked = True Then
            m_CustomerShipTo.VAT = True
        Else
            m_CustomerShipTo.VAT = False
        End If
        m_CustomerShipTo.Discount = txtDiscount.Text

        m_CustomerShipTo.CMGRP = txtCustomerGroupCode.Text
        m_CustomerShipTo.CMCLASS = txtCustomerClassCode.Text
        m_CustomerShipTo.Coordinator = txtCoordinatorCode.Text
        m_CustomerShipTo.REGCD = txtRegionCode.Text
        m_CustomerShipTo.DISTCD = txtProvinceCode.Text
        m_CustomerShipTo.AREACD = txtMunicipalCode.Text
        m_CustomerShipTo.ZIPCD = txtZipCode.Text
        m_CustomerShipTo.EffectivityStartDate = dtFromDate.Text
        m_CustomerShipTo.EffectivityEndDate = dtTodate.Text
        m_CustomerShipTo.ProponentCode = txtProponentCode.Text
        m_CustomerShipTo.ProponentShipto = m_ProponentShipto
        m_CustomerShipTo.PioneerCode = txtPioneerCode.Text

        If check_OAPEnrollment.Checked = True Then
            m_CustomerShipTo.OAPEnrollment = True
        Else
            m_CustomerShipTo.OAPEnrollment = False
        End If
        If Check_OAPMemberShip.Checked = True Then
            m_CustomerShipTo.OAPMemberShip = True
        Else
            m_CustomerShipTo.OAPMemberShip = False
        End If
        m_CustomerShipTo.Remarks = txtRemarks.Text

        If ChckLoyaltyCustomer.Checked = True Then
            m_CustomerShipTo.CustomerofType = 1
        ElseIf chckDataTransferStocks.Checked = True Then
            m_CustomerShipTo.CustomerofType = 2
        ElseIf chckLoyaltyMD.Checked = True Then
            m_CustomerShipTo.CustomerofType = 3
        End If


        If m_CustomerShipTo.CustomerShiptoSave Then
            DispensingProponent.DeleteExistProponent(txtCustomerCode.Text, txtProponentCode.Text)
            m_Proponent.ProponentCustomerCode = txtCustomerCode.Text
            m_Proponent.ProponentCode = txtProponentCode.Text
            m_Proponent.ProponentName = txtproponetName.Text
            m_Proponent.ProponentShipto = m_ProponentShipto
            m_Proponent.Save()
            DispensingPioneer.DeleteExistPioneer(txtCustomerCode.Text, txtPioneerCode.Text)
            m_Pioneer.PioneerCustomerCode = txtCustomerCode.Text
            m_Pioneer.PioneerCode = txtPioneerCode.Text
            m_Pioneer.PioneerName = txtPioneerName.Text
            m_Pioneer.PioneerShipTo = m_ProponentShipto
            m_Pioneer.Save()
            SaveSuccess()
            ShowData(m_CustomerShipTo.CUSTOMERSHIPTOID)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnDelete.Click, btnEdit.Click, btnFinddata.Click, btnSave.Click, btnClear.Click, btnClose.Click
        If sender Is btnNew Then
            NewRecord()
        ElseIf sender Is btnDelete Then
            Delete()
        ElseIf sender Is btnEdit Then
            EditMode(True)
            EnableTextBox(True)
            m_Proponent = New DispensingProponent
            m_Pioneer = New DispensingPioneer
            m_EditCustomer = True
        ElseIf sender Is btnClear Then
            Clear()
            EditMode(False)
        ElseIf sender Is btnClose Then
            Close()
        ElseIf sender Is btnFinddata Then
            ''Find()
        ElseIf sender Is btnSave Then
            If ValidateData() Then
                If m_EditCustomer = True Then
                    UpdateCustomerShipTo()
                Else
                    SaveRecordShipTo()
                End If
            End If
        End If
    End Sub
    Private Sub UpdateCustomerShipTo()
        m_CustomerShipTo.COMID = txtDistributorCode.Text
        m_Customer.CUSTOMERCD = txtCustomerCode.Text
        m_CustomerShipTo.CDANAME = txtCustomerName.Text
        m_CustomerShipTo.CDACADD1 = txtAddress1.Text
        m_CustomerShipTo.CDACADD2 = txtAddress2.Text
        m_CustomerShipTo.CDACD = txtCustomerShiptoCode.Text
        m_CustomerShipTo.CDACONT = txtContactPerson.Text
        m_CustomerShipTo.CDAPHON = txtPhoneNumber.Text

        If chkAccountShared.Checked = True Then
            m_CustomerShipTo.ACCNTSHRD = True
        Else
            m_CustomerShipTo.ACCNTSHRD = False
        End If
        If chkVatable.Checked = True Then
            m_CustomerShipTo.VAT = True
        Else
            m_CustomerShipTo.VAT = False
        End If
        m_CustomerShipTo.Discount = txtDiscount.Text

        m_CustomerShipTo.CMGRP = txtCustomerGroupCode.Text
        m_CustomerShipTo.CMCLASS = txtCustomerClassCode.Text
        m_CustomerShipTo.Coordinator = txtCoordinatorCode.Text
        m_CustomerShipTo.REGCD = txtRegionCode.Text
        m_CustomerShipTo.DISTCD = txtProvinceCode.Text
        m_CustomerShipTo.AREACD = txtMunicipalCode.Text
        m_CustomerShipTo.ZIPCD = txtZipCode.Text
        m_CustomerShipTo.EffectivityStartDate = dtFromDate.Text
        m_CustomerShipTo.EffectivityEndDate = dtTodate.Text
        m_CustomerShipTo.ProponentCode = txtProponentCode.Text
        m_CustomerShipTo.ProponentShipto = m_ProponentShipto
        m_CustomerShipTo.PioneerCode = txtPioneerCode.Text

        If check_OAPEnrollment.Checked = True Then
            m_CustomerShipTo.OAPEnrollment = True
        Else
            m_CustomerShipTo.OAPEnrollment = False
        End If
        If Check_OAPMemberShip.Checked = True Then
            m_CustomerShipTo.OAPMemberShip = True
        Else
            m_CustomerShipTo.OAPMemberShip = False
        End If
        m_CustomerShipTo.Remarks = txtRemarks.Text

        If ChckLoyaltyCustomer.Checked = True Then
            m_CustomerShipTo.CustomerofType = 1
        ElseIf chckDataTransferStocks.Checked = True Then
            m_CustomerShipTo.CustomerofType = 2
        ElseIf chckLoyaltyMD.Checked = True Then
            m_CustomerShipTo.CustomerofType = 3
        End If
        If m_CustomerShipTo.UpdateCustomerShipTo Then
            DispensingProponent.DeleteExistProponent(txtCustomerCode.Text, txtProponentCode.Text)
            m_Proponent.ProponentCustomerCode = txtCustomerCode.Text
            m_Proponent.ProponentCode = txtProponentCode.Text
            m_Proponent.ProponentName = txtproponetName.Text
            m_Proponent.ProponentShipto = m_ProponentShipto
            m_Proponent.Save()
            DispensingPioneer.DeleteExistPioneer(txtCustomerCode.Text, txtPioneerCode.Text)
            m_Pioneer.PioneerCustomerCode = txtCustomerCode.Text
            m_Pioneer.PioneerCode = txtPioneerCode.Text
            m_Pioneer.PioneerName = txtPioneerName.Text
            m_Pioneer.PioneerShipTo = m_ProponentShipto
            m_Pioneer.Save()
            SaveSuccess()
            ShowData(m_CustomerShipTo.CUSTOMERSHIPTOID)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub SaveRecord()

        m_Customer.COMID = txtDistributorCode.Text
        m_Customer.CUSTOMERCD = txtCustomerCode.Text
        m_Customer.CUSTOMERNAME = txtCustomerName.Text
        m_Customer.CADD1 = txtAddress1.Text
        m_Customer.CADD2 = txtAddress2.Text
        m_Customer.CDACD = txtCustomerShiptoCode.Text
        m_Customer.CMCONT = txtContactPerson.Text
        m_Customer.CMPHON = txtPhoneNumber.Text
        m_Customer.Discount = txtDiscount.Text

        If chkAccountShared.Checked = True Then
            m_Customer.ACCNTSHRD = True
        Else
            m_Customer.ACCNTSHRD = False
        End If

        If chkVatable.Checked = True Then
            m_Customer.VAT = True
        Else
            m_Customer.VAT = False
        End If

        m_Customer.CMGRP = txtCustomerGroupCode.Text
        m_Customer.CMCLASS = txtCustomerClassCode.Text
        m_Customer.Coordinator = txtCoordinatorCode.Text
        m_Customer.REGCD = txtRegionCode.Text
        m_Customer.DISTCD = txtProvinceCode.Text
        m_Customer.AREACD = txtMunicipalCode.Text
        m_Customer.ZIPCD = txtZipCode.Text
        m_Customer.EffectivityStartDate = dtFromDate.Text
        m_Customer.EffectivityEndDate = dtTodate.Text
        m_Customer.ProponentCode = txtProponentCode.Text
        m_Customer.PioneerCode = txtPioneerCode.Text
        m_Customer.ProponentShipto = m_ProponentShipto
        m_Customer.PioneerCode = txtPioneerCode.Text
        If check_OAPEnrollment.Checked = True Then
            m_Customer.OAPEnrollemnt = True
        Else
            m_Customer.OAPEnrollemnt = False
        End If
        If Check_OAPMemberShip.Checked = True Then
            m_Customer.OAPMemberShip = True
        Else
            m_Customer.OAPMemberShip = False
        End If
        m_Customer.Remarks = txtRemarks.Text
        If m_Customer.Save Then
            DispensingProponent.DeleteExistProponent(txtCustomerCode.Text, txtProponentCode.Text)
            m_Proponent.ProponentCustomerCode = txtCustomerCode.Text
            m_Proponent.ProponentCode = txtProponentCode.Text
            m_Proponent.ProponentName = txtproponetName.Text
            m_Proponent.ProponentShipto = m_ProponentShipto
            m_Proponent.Save()
            DispensingPioneer.DeleteExistPioneer(txtCustomerCode.Text, txtPioneerCode.Text)
            m_Pioneer.PioneerCustomerCode = txtCustomerCode.Text
            m_Pioneer.PioneerCode = txtPioneerCode.Text
            m_Pioneer.PioneerName = txtPioneerName.Text
            m_Pioneer.PioneerShipTo = m_ProponentShipto
            m_Pioneer.Save()
            SaveSuccess()
            'ShowData(m_Customer.CUSTOMERID)
        Else
            UnSuccesSave()
        End If

    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        'If txtCustomerCode.Text = "" Or txtDistributorCode.Text = "" Then
        '    m_Err.SetError(txtCustomerCode, "Customer Code is Required!")
        '    m_HasError = True
        'Else
        '    If CustomerShipTo.CheckCustomerAndCompanyIfExist1(txtCustomerCode.Text, txtCustomerShiptoCode.Text, txtDistributorCode.Text, IIf(txtCustomerCode.Tag Is Nothing, -1, txtCustomerCode.Tag)) Then
        '        m_Err.SetError(txtCustomerCode, "Customer Code Already Exist")
        '        m_HasError = True
        '    End If
        'End If
        If txtCustomerCode.Text = "" Or txtDistributorCode.Text = "" Then
            m_Err.SetError(txtCustomerCode, "Customer Code is Required!")
            m_HasError = True
        Else
            If m_EditCustomer = True Then
                m_HasError = False
            Else
                If CustomerShipTo.CheckCustomerAndCompanyIfExist1(txtCustomerCode.Text, txtCustomerShiptoCode.Text, txtDistributorCode.Text) Then
                    m_Err.SetError(txtCustomerCode, "Customer Code Already Exist")
                    m_HasError = True
                End If
            End If
        End If
        If txtCustomerName.Text = "" Then
            m_Err.SetError(txtCustomerName, "Customer Name is Required!")
            m_HasError = True
        End If
        If txtCustomerShiptoCode.Text = "" Then
            m_Err.SetError(txtCustomerShiptoCode, "Customer Shipto Code is Required!")
            m_HasError = True
        End If

        If txtCustomerShiptoName.Text = "" Then
            m_Err.SetError(txtCustomerShiptoName, "Customer Shiptp Name is Required!")
            m_HasError = True
        End If
        Return Not m_HasError
    End Function
    Private Sub Delete()
        If ShowDeleteDialog() = DialogResult.Yes Then
            If m_Customer.Delete Then
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

    Private Sub CheckAutoCreateDefaultShipTo_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles CheckAutoCreateDefaultShipTo.ToggleStateChanged
        If CheckAutoCreateDefaultShipTo.Checked = True Then
            txtCustomerShiptoCode.Text = "001"
            txtCustomerShiptoName.Text = txtCustomerName.Text
        Else
            txtCustomerShiptoCode.Text = String.Empty
            txtCustomerShiptoName.Text = String.Empty
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Find()
    End Sub
    Private Sub Find()
        If txtDistributorCode.Text = "" Then
            ChannelFind()
        Else
            Dim tag As SelectionTags = Dialogs.ShowSearchDialog(CustomerShipTo.CustomerFindlist(txtDistributorCode.Text), "Customer")
            If Not tag Is Nothing Then
                Clear()
                ShowData(tag.KeyColumn11)
                ' ShowDataShipto(tag.KeyColumn22)
                EditMode(False)
            End If
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        If RecordCode < 1 Then Exit Sub
        m_CustomerShipTo = CustomerShipTo.Load(RecordCode)

        If Not m_CustomerShipTo.COMID = String.Empty Then
            LoadChannel(m_CustomerShipTo.COMID)
        End If
        txtCustomerCode.Tag = m_CustomerShipTo.CUSTOMERSHIPTOID
        txtCustomerCode.Text = m_CustomerShipTo.CUSTOMERCD
        txtCustomerName.Text = m_CustomerShipTo.CDANAME
        txtAddress1.Text = m_CustomerShipTo.CDACADD1
        txtAddress2.Text = m_CustomerShipTo.CDACADD2
        txtContactPerson.Text = m_CustomerShipTo.CDANAME
        txtPhoneNumber.Text = m_CustomerShipTo.CDAPHON
        txtDiscount.Text = m_CustomerShipTo.Discount

        If m_CustomerShipTo.CDACD = "001" Then
            txtCustomerShiptoCode.Text = "001"
            txtCustomerShiptoName.Text = m_CustomerShipTo.CDANAME
            CheckAutoCreateDefaultShipTo.Checked = True
        Else
            txtCustomerShiptoCode.Text = m_CustomerShipTo.CDACD
            txtCustomerShiptoName.Text = m_CustomerShipTo.CDANAME
            CheckAutoCreateDefaultShipTo.Checked = False
        End If

        If m_CustomerShipTo.VAT = False Then
            chkVatable.Checked = False
        Else
            chkVatable.Checked = True
        End If

        If m_CustomerShipTo.ACCNTSHRD = False Then
            chkAccountShared.Checked = False
        Else
            chkAccountShared.Checked = True
        End If

        If m_CustomerShipTo.CustomerofType = 1 Then
            ChckLoyaltyCustomer.Checked = True
            chckDataTransferStocks.Checked = False
            chckLoyaltyMD.Checked = False
        ElseIf m_CustomerShipTo.CustomerofType = 2 Then
            ChckLoyaltyCustomer.Checked = False
            chckDataTransferStocks.Checked = True
            chckLoyaltyMD.Checked = False
        ElseIf m_CustomerShipTo.CustomerofType = 3 Then
            ChckLoyaltyCustomer.Checked = False
            chckDataTransferStocks.Checked = False
            chckLoyaltyMD.Checked = True
        End If

        If Not m_CustomerShipTo.CMGRP = String.Empty Then
            If CustomerGroup.CheckCustomerGroup(m_CustomerShipTo.CMGRP) = False Then
                txtCustomerGroupCode.Text = String.Empty
                txtCustomerGroupName.Text = String.Empty
            Else
                LoadCustomerGroup(m_CustomerShipTo.CMGRP)
            End If
        End If

        If Not m_CustomerShipTo.CMCLASS = String.Empty Then
            If Coordinator.CheckCustomerClass(m_CustomerShipTo.CMCLASS) = False Then
                txtCustomerClassCode.Text = String.Empty
                txtCustomerClassName.Text = String.Empty
            Else
                LoadCoordinator(m_CustomerShipTo.CMCLASS)
            End If
        End If

        If Not m_CustomerShipTo.ProponentCode = String.Empty Then
            If CustomerShipTo.CheckProponent(m_CustomerShipTo.COMID, m_CustomerShipTo.ProponentCode, m_CustomerShipTo.CDACD) = False Then
                txtPioneerCode.Text = String.Empty
                txtPioneerName.Text = String.Empty
            Else
                LoadCustomerProponent(m_CustomerShipTo.ProponentCode, m_CustomerShipTo.CDACD)
            End If
        End If

        If Not m_CustomerShipTo.PioneerCode = String.Empty Then
            If CustomerShipTo.CheckProponent(m_CustomerShipTo.COMID, m_CustomerShipTo.PioneerCode, m_CustomerShipTo.CDACD) = False Then
                txtPioneerCode.Text = String.Empty
                txtPioneerName.Text = String.Empty
            Else
                LoadCustomerPioneer(m_CustomerShipTo.PioneerCode, m_CustomerShipTo.CDACD)
            End If
        End If
     

        If Not m_CustomerShipTo.Coordinator = String.Empty Then
            If CustomerCoordinator.CheckCustomerCoordinator(m_CustomerShipTo.Coordinator) = False Then
                txtCoordinatorCode.Text = String.Empty
                txtCoordinatorName.Text = String.Empty
            Else
                LoadCustomerCoordinator(m_CustomerShipTo.Coordinator)
            End If
        End If


        If Not m_CustomerShipTo.REGCD = String.Empty Then
            If Regions.CheckCustomerRegion1(m_CustomerShipTo.REGCD) = False Then
                txtRegionCode.Text = String.Empty
                txtRegionName.Text = String.Empty
            Else
                LoadRegion(m_CustomerShipTo.REGCD)
            End If
        End If

        If Not m_CustomerShipTo.DISTCD = String.Empty Then
            If Districts.CheckCustomerDistrict(m_CustomerShipTo.DISTCD) = False Then
                txtProvinceCode.Text = String.Empty
                txtProvinceName.Text = String.Empty
            Else
                LoadDistrict(m_CustomerShipTo.DISTCD)
            End If
        End If

        If Not m_CustomerShipTo.AREACD = String.Empty Then
            If Area.CheckCustomerArea(m_CustomerShipTo.AREACD) = False Then
                txtMunicipalCode.Text = String.Empty
                txtMunicipalDescription.Text = String.Empty
            Else
                LoadArea(m_CustomerShipTo.AREACD)
            End If
        End If

        If Not m_CustomerShipTo.ZIPCD = String.Empty Then
            If ZipCodes.CheckCustomerZipCode(m_CustomerShipTo.ZIPCD) = False Then
                txtZipCode.Text = String.Empty
                txtZipDescription.Text = String.Empty
            Else
                LoadZipCodes(m_CustomerShipTo.REGCD, m_CustomerShipTo.DISTCD, m_CustomerShipTo.AREACD)
            End If

        End If

        If m_CustomerShipTo.OAPEnrollment = True Then
            check_OAPEnrollment.Checked = True
        Else
            check_OAPEnrollment.Checked = False
        End If
        If m_CustomerShipTo.OAPMemberShip = True Then
            Check_OAPMemberShip.Checked = True
        Else
            Check_OAPMemberShip.Checked = False
        End If
        txtRemarks.Text = m_CustomerShipTo.Remarks
        EditMode(False)
    End Sub
    Private Sub LoadCustomerGroup(ByVal CustomerCode As String)
        m_CustomerGroup = CustomerGroup.LoadByCode(CustomerCode)
        txtCustomerGroupCode.Text = m_CustomerGroup.CustomerGroupCode
        txtCustomerGroupName.Text = m_CustomerGroup.CustomerGroupName
    End Sub
    Private Sub LoadCustomerCoordinator(ByVal CoordinatorCode As String)
        m_CustomerCoordinator = CustomerCoordinator.LoadByCode(CoordinatorCode)
        txtCoordinatorCode.Text = m_CustomerCoordinator.Code
        txtCoordinatorName.Text = m_CustomerCoordinator.CoordinatorName
    End Sub

    Private Sub LoadCustomerProponent(ByVal Code As String, ByVal Shipto As String)
        Table = GetRecords(Customer.GetProponentSql(Code, Shipto))
        For i As Integer = 0 To Table.Rows.Count - 1
            txtProponentCode.Text = Table.Rows(i)("Code")
            txtproponetName.Text = Table.Rows(i)("Name")
            m_ProponentShipto = Table.Rows(i)("Shipto")
            Exit Sub
        Next
    End Sub
    Private Sub LoadCustomerPioneer(ByVal Code As String, ByVal ShipTo As String)
        Table = GetRecords(Customer.GetPioneerSql(Code, ShipTo))
        For i As Integer = 0 To Table.Rows.Count - 1
            txtPioneerCode.Text = Table.Rows(i)("Code")
            txtPioneerName.Text = Table.Rows(i)("Name")
            m_ProponentShipto = Table.Rows(i)("Shipto")
        Next
    End Sub
    Private Sub LoadCoordinator(ByVal CoodinatorCode As String)
        m_Coodinator = Coordinator.LoadByCode(CoodinatorCode)
        txtCustomerClassCode.Text = m_Coodinator.CoordinatorID
        txtCustomerClassName.Text = m_Coodinator.CoordinatorName
    End Sub
    Private Sub LoadRegion(ByVal RegionCode As String)
        m_Regions = Regions.LoadByCode(RegionCode)
        txtRegionCode.Text = m_Regions.RegionCode
        txtRegionName.Text = m_Regions.RegionName
    End Sub
    Private Sub LoadDistrict(ByVal DistrictCode As String)
        m_District = Districts.LoadByCode(DistrictCode)
        txtProvinceCode.Text = m_District.DistrinctCode
        txtProvinceName.Text = m_District.DistrictName
    End Sub
    Private Sub LoadArea(ByVal AreaCode As String)
        m_Area = Area.LoadByCode(AreaCode)
        txtMunicipalCode.Text = m_Area.AreaCode
        txtMunicipalDescription.Text = m_Area.AreaName
    End Sub
    Private Sub LoadZipCode(ByVal ZipCode As String)
        m_ZipCode = ZipCodes.LoadByCode(ZipCode)
        txtZipCode.Text = m_ZipCode.ZipCode
        txtZipDescription.Text = m_ZipCode.ZipCode
    End Sub
    Private Sub LoadZipCodes(ByVal RegionCode As String, ByVal DistrictCode As String, ByVal AreaCode As String)
        Table = GetRecords(ZipCodes.GetZipCode(RegionCode, DistrictCode, AreaCode))
        For i As Integer = 0 To Table.Rows.Count - 1
            txtZipCode.Text = Table.Rows(i)("ZIPCD")
            txtZipDescription.Text = Table.Rows(i)("ZIPCD")
        Next
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(CustomerGroup.GetCustomerGroupSql, "Customer Group")
        If Not tag Is Nothing Then
            LoadCustomerGroup(tag.KeyColumn11)
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Coordinator.GetCoordinatorSql, "Coordinator")
        If Not tag Is Nothing Then
            LoadCoordinator(tag.KeyColumn11)
        End If
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(CustomerCoordinator.GetCustomerCoordinatorSql, "Customer Coordinator")
        If Not tag Is Nothing Then
            LoadCustomerCoordinator(tag.KeyColumn22)
        End If
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(CustomerShipTo.GetCustomerProponent(txtDistributorCode.Text), "Proponent")
        If Not tag Is Nothing Then
            If txtCustomerCode.Text = tag.KeyColumn22 Then
                CustomerProponent()
                txtProponentCode.Text = String.Empty
                txtproponetName.Text = String.Empty
            Else
                txtProponentCode.Text = tag.KeyColumn22
                txtproponetName.Text = tag.KeyColumn33
                m_ProponentShipto = tag.KeyColumn44
            End If
        End If
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(CustomerShipTo.GetCustomerPoineer(txtDistributorCode.Text), "Pioneer")
        If Not tag Is Nothing Then
            If txtCustomerCode.Text = tag.KeyColumn22 Then
                CustomerProponent()
                txtPioneerCode.Text = String.Empty
                txtPioneerName.Text = String.Empty
            Else
                txtPioneerCode.Text = tag.KeyColumn22
                txtPioneerName.Text = tag.KeyColumn33
                m_ProponentShipto = tag.KeyColumn44
            End If
        End If
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Regions.GetRegionSql, "Region")
        If Not tag Is Nothing Then
            LoadRegion(tag.KeyColumn11)
        End If
    End Sub

    Private Sub LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        If txtRegionCode.Text = "" Then
            Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Districts.GetDistrictSql, "District")
            If Not tag Is Nothing Then
                LoadDistrict(tag.KeyColumn11)
            End If
        Else
            Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Districts.GetDistrictbyRegion(txtRegionCode.Text))
            If Not tag Is Nothing Then
                LoadDistrict(tag.KeyColumn11)
            End If
        End If
    End Sub

    Private Sub LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        If txtRegionCode.Text = "" And txtProvinceCode.Text = "" Then
            Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Area.GetAreaSql, "Area")
            If Not tag Is Nothing Then
                LoadArea(tag.KeyColumn11)
            End If
        Else
            Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Area.GetAreabyRegionAndDistrict(txtRegionCode.Text, txtProvinceCode.Text))
            If Not tag Is Nothing Then
                LoadArea(tag.KeyColumn11)
            End If
        End If
    End Sub

    Private Sub LinkLabel10_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked
        If txtRegionCode.Text = "" And txtProvinceCode.Text = "" And txtMunicipalCode.Text Then
            Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ZipCodes.GeZipCodeSql, "ZipCode")
            If Not tag Is Nothing Then
                LoadZipCode(tag.KeyColumn11)
            End If
        Else
            Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ZipCodes.GetZipCodebyRegionAndDistrictAndArea(txtRegionCode.Text, txtProvinceCode.Text, txtMunicipalCode.Text))
            If Not tag Is Nothing Then
                LoadZipCode(tag.KeyColumn11)
            End If
        End If
    End Sub

    Private Sub ChckLoyaltyCustomer_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles ChckLoyaltyCustomer.ToggleStateChanged
        If ChckLoyaltyCustomer.Checked = True Then
            chckDataTransferStocks.Checked = False
            chckLoyaltyMD.Checked = False
        End If
    End Sub

    Private Sub chckDataTransferStocks_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chckDataTransferStocks.ToggleStateChanged
        If chckDataTransferStocks.Checked = True Then
            ChckLoyaltyCustomer.Checked = False
            chckLoyaltyMD.Checked = False
        End If
    End Sub

    Private Sub chckLoyaltyMD_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chckLoyaltyMD.ToggleStateChanged
        If chckLoyaltyMD.Checked = True Then
            ChckLoyaltyCustomer.Checked = False
            chckDataTransferStocks.Checked = False
        End If
    End Sub
End Class
