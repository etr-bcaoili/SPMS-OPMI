Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Public Class ucMasterCustomers
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
        btnUpdate.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtChannelCode.ReadOnly = Not IsEditMode
        txtChannelCode.BackColor = Color.White

        txtChannelName.ReadOnly = Not IsEditMode
        txtChannelName.BackColor = Color.White


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

    End Sub
    Private Sub Clear()
        txtChannelCode.Text = String.Empty
        txtChannelName.Text = String.Empty
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

    End Sub
    Private Sub NewRecord()
        Clear()
        m_Customer = New Customer
        m_CustomerShipTo = New CustomerShipTo
        m_Proponent = New DispensingProponent
        EditMode(True)
    End Sub
    Private Sub SaveRecordShipTo()
        m_CustomerShipTo.CustomerShiptoIDD = m_CustomerShiptoCodeID
        m_CustomerShipTo.COMID = txtChannelCode.Text
        m_CustomerShipTo.CUSTOMERCD = txtCustomerCode.Text
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
        m_CustomerShipTo.CMGRP = txtCustomerGroupCode.Text
        m_CustomerShipTo.CMCLASS = txtCustomerClassCode.Text
        m_CustomerShipTo.Coordinator = txtCoordinatorCode.Text
        m_CustomerShipTo.REGCD = txtRegionCode.Text
        m_CustomerShipTo.DISTCD = txtProvinceCode.Text
        m_CustomerShipTo.AREACD = txtMunicipalCode.Text
        m_CustomerShipTo.ZIPCD = txtZipCode.Text
        m_CustomerShipTo.EffectivityStartDate = dtStart.Text
        m_CustomerShipTo.EffectivityEndDate = dtEnd.Text
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
        m_CustomerShipTo.CustomerShiptoSave()
    End Sub
    Private Sub SaveRecord()

        m_Customer.COMID = txtChannelCode.Text
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
        m_Customer.EffectivityStartDate = dtStart.Text
        m_Customer.EffectivityEndDate = dtEnd.Text
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
            ShowData(m_Customer.CUSTOMERID)
        Else
            UnSuccesSave()
        End If

    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        If RecordCode < 1 Then Exit Sub
        m_Customer = Customer.Load(RecordCode)

        If Not m_Customer.COMID = String.Empty Then
            LoadChannel(m_Customer.COMID)
        End If
        txtCustomerCode.Tag = m_Customer.CUSTOMERID
        txtCustomerCode.Text = m_Customer.CUSTOMERCD
        txtCustomerName.Text = m_Customer.CUSTOMERNAME
        txtAddress1.Text = m_Customer.CADD1
        txtAddress2.Text = m_Customer.CADD2
        txtContactPerson.Text = m_Customer.CMCONT
        txtPhoneNumber.Text = m_Customer.CMPHON
        txtDiscount.Text = m_Customer.Discount
        If m_Customer.CDACD = "001" Then
            txtCustomerShiptoCode.Text = "001"
            txtCustomerShiptoName.Text = m_Customer.CUSTOMERNAME
            CheckAutoCreateDefaultShipTo.Checked = True
        Else
            txtCustomerShiptoCode.Text = m_Customer.CDACD
            txtCustomerShiptoName.Text = m_Customer.CUSTOMERNAME
            CheckAutoCreateDefaultShipTo.Checked = False
        End If

        If m_Customer.VAT = False Then
            chkVatable.Checked = False
        Else
            chkVatable.Checked = True
        End If

        If m_Customer.ACCNTSHRD = False Then
            chkAccountShared.Checked = False
        Else
            chkAccountShared.Checked = True
        End If

        If Not m_Customer.CMGRP = String.Empty Then
            If CustomerGroup.CheckCustomerGroup(m_Customer.CMGRP) = False Then
                txtCustomerGroupCode.Text = String.Empty
                txtCustomerGroupName.Text = String.Empty
            Else
                LoadCustomerGroup(m_Customer.CMGRP)
            End If
        End If

        If Not m_Customer.CMCLASS = String.Empty Then
            If CustomerCoordinator.CheckCustomerCoordinator(m_Customer.CMCLASS) = False Then
                txtCustomerClassCode.Text = String.Empty
                txtCustomerClassName.Text = String.Empty
            Else
                LoadCustomerClass(m_Customer.CMCLASS)
            End If
        End If

        If Not m_Customer.ProponentCode = String.Empty Then
            If Customer.CheckProponent(m_Customer.COMID, m_Customer.ProponentCode, m_Customer.CDACD) = False Then
                txtPioneerCode.Text = String.Empty
                txtPioneerName.Text = String.Empty
            Else
                LoadCustomerProponent(m_Customer.ProponentCode, m_Customer.CDACD)
            End If
        End If

        If Not m_Customer.PioneerCode = String.Empty Then
            If Customer.CheckProponent(m_Customer.COMID, m_Customer.PioneerCode, m_Customer.CDACD) = False Then
                txtPioneerCode.Text = String.Empty
                txtPioneerName.Text = String.Empty
            Else
                LoadCustomerPioneer(m_Customer.PioneerCode, m_Customer.CDACD)
            End If
        End If

        If Not m_Customer.Coordinator = String.Empty Then
            If CustomerCoordinator.CheckCustomerCoordinator(m_Customer.Coordinator) = False Then
                txtCoordinatorCode.Text = String.Empty
                txtCoordinatorName.Text = String.Empty
            Else
                LoadCoordinator(m_Customer.Coordinator)
            End If
        End If


        If Not m_Customer.REGCD = String.Empty Then
            If Regions.CheckCustomerRegion1(m_Customer.REGCD) = False Then
                txtRegionCode.Text = String.Empty
                txtRegionName.Text = String.Empty
            Else
                LoadRegion(m_Customer.REGCD)
            End If
        End If

        If Not m_Customer.DISTCD = String.Empty Then
            If Districts.CheckCustomerDistrict(m_Customer.DISTCD) = False Then
                txtProvinceCode.Text = String.Empty
                txtProvinceName.Text = String.Empty
            Else
                LoadDistrict(m_Customer.DISTCD)
            End If
        End If

        If Not m_Customer.AREACD = String.Empty Then
            If Area.CheckCustomerArea(m_Customer.AREACD) = False Then
                txtMunicipalCode.Text = String.Empty
                txtMunicipalDescription.Text = String.Empty
            Else
                LoadArea(m_Customer.AREACD)
            End If
        End If

        If Not m_Customer.ZIPCD = String.Empty Then
            If ZipCodes.CheckCustomerZipCode(m_Customer.ZIPCD) = False Then
                txtZipCode.Text = String.Empty
                txtZipDescription.Text = String.Empty
            Else
                LoadZipCode(m_Customer.ZIPCD)
            End If

        End If

        If m_Customer.OAPEnrollemnt = True Then
            check_OAPEnrollment.Checked = True
        Else
            check_OAPEnrollment.Checked = False
        End If
        If m_Customer.OAPMemberShip = True Then
            Check_OAPMemberShip.Checked = True
        Else
            Check_OAPMemberShip.Checked = False
        End If
        txtRemarks.Text = m_Customer.Remarks
        EditMode(False)
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If txtCustomerCode.Text = "" Or txtChannelCode.Text = "" Then
            m_Err.SetError(txtCustomerCode, "Customer Code is Required!")
            m_HasError = True
        Else
            If Customer.CheckCustomerAndCompanyIfExist1(txtCustomerCode.Text, txtCustomerShiptoCode.Text, txtChannelCode.Text, IIf(txtCustomerCode.Tag Is Nothing, -1, txtCustomerCode.Tag)) Then
                m_Err.SetError(txtCustomerCode, "Customer Code Already Exist")
                m_HasError = True
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
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnDelete.Click, btnUpdate.Click, btnFind.Click, btnSave.Click, btnClear.Click, btnClose.Click
        If sender Is btnNew Then
            NewRecord()
        ElseIf sender Is btnDelete Then
            Delete()
        ElseIf sender Is btnUpdate Then
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
        ElseIf sender Is btnFind Then
            Find()
        ElseIf sender Is btnSave Then
            If ValidateData() Then
                'SaveRecord()
                SaveRecordShipTo()
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
        If txtChannelCode.Text = "" Then
            ChannelFind()
        Else
            Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Customer.CustomerFindlist(txtChannelCode.Text), "Customer")
            If Not tag Is Nothing Then
                Clear()
                ShowData(tag.KeyColumn11)
                ShowDataShipto(tag.KeyColumn22)
                EditMode(False)
            End If
        End If
    End Sub
    Private Sub ShowDataShipto(ByVal RecordCode As String)
        m_CustomerShipTo = CustomerShipTo.LoadbyCode(RecordCode)
        m_CustomerShiptoCodeID = m_CustomerShipTo.CUSTOMERSHIPTOID
    End Sub
    Private Sub lnkMotherCode_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkMotherCode.LinkClicked
        Clear()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Distributor.GetDistributorSql, "Search Item")
        If Not tag Is Nothing Then
            LoadChannel(tag.KeyColumn22)
        End If
    End Sub
    Private Sub LoadChannel(ByVal ChannelCode As String)
        m_Distributor = Distributor.LoadByCode(ChannelCode)
        txtChannelCode.Text = m_Distributor.DISTCOMID
        txtChannelName.Text = m_Distributor.DISTNAME
    End Sub
    Private Sub LinkItemGroup_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkItemGroup.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(CustomerGroup.GetCustomerGroupSql, "Customer Group")
        If Not tag Is Nothing Then
            LoadCustomerGroup(tag.KeyColumn11)
        End If
    End Sub
    Private Sub LoadCustomerGroup(ByVal CustomerCode As String)
        m_CustomerGroup = CustomerGroup.LoadByCode(CustomerCode)
        txtCustomerGroupCode.Text = m_CustomerGroup.CustomerGroupCode
        txtCustomerGroupName.Text = m_CustomerGroup.CustomerGroupName
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(CustomerCoordinator.GetCustomerCoordinatorSql, "Customer Coordinator")
        If Not tag Is Nothing Then
            LoadCustomerClass(tag.KeyColumn22)
        End If
    End Sub
    Private Sub LoadCustomerClass(ByVal CustomerClassCode As String)
        m_CustomerCoordinator = CustomerCoordinator.LoadByCode(CustomerClassCode)
        txtCustomerClassCode.Text = m_CustomerCoordinator.Code
        txtCustomerClassName.Text = m_CustomerCoordinator.CoordinatorName
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

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Coordinator.GetCoordinatorSql, "Coordinator")
        If Not tag Is Nothing Then
            LoadCoordinator(tag.KeyColumn11)
        End If
    End Sub
    Private Sub LoadCoordinator(ByVal CoodinatorCode As String)
        m_Coodinator = Coordinator.LoadByCode(CoodinatorCode)
        txtCoordinatorCode.Text = m_Coodinator.CoordinatorID
        txtCoordinatorName.Text = m_Coodinator.CoordinatorName
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Regions.GetRegionSql, "Region")
        If Not tag Is Nothing Then
            LoadRegion(tag.KeyColumn11)
        End If
    End Sub
    Private Sub LoadRegion(ByVal RegionCode As String)
        m_Regions = Regions.LoadByCode(RegionCode)
        txtRegionCode.Text = m_Regions.RegionCode
        txtRegionName.Text = m_Regions.RegionName
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
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
    Private Sub LoadDistrict(ByVal DistrictCode As String)
        m_District = Districts.LoadByCode(DistrictCode)
        txtProvinceCode.Text = m_District.DistrinctCode
        txtProvinceName.Text = m_District.DistrictName
    End Sub

    Private Sub LinkArea_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkArea.LinkClicked
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
    Private Sub LoadArea(ByVal AreaCode As String)
        m_Area = Area.LoadByCode(AreaCode)
        txtMunicipalCode.Text = m_Area.AreaCode
        txtMunicipalDescription.Text = m_Area.AreaName
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
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
    Private Sub LoadZipCode(ByVal ZipCode As String)
        m_ZipCode = ZipCodes.LoadByCode(ZipCode)
        txtZipCode.Text = m_ZipCode.ZipAreaCode
        txtZipDescription.Text = m_ZipCode.ZipAreaName
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckAutoCreateDefaultShipTo.CheckedChanged
        If CheckAutoCreateDefaultShipTo.Checked = True Then
            txtCustomerShiptoCode.Text = "001"
            txtCustomerShiptoName.Text = txtCustomerName.Text
        Else
            txtCustomerShiptoCode.Text = String.Empty
            txtCustomerShiptoName.Text = String.Empty
        End If
    End Sub
    Private Sub ucMasterCustomers_Load(sender As Object, e As EventArgs) Handles Me.Load
        dtStart.Value = DateTime.Now
        dtEnd.Value = DateTime.Now
    End Sub

    Private Sub LinkLabel1_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Customer.GetCustomerProponent(txtChannelCode.Text), "Proponent")
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

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Customer.GetCustomerPoineer(txtChannelCode.Text), "Pioneer")
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
End Class
