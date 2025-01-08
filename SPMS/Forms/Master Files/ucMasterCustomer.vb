Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule

Public Class ucMasterCustomer

    '==============================================================================
    'Variable Declaration Starts Here

    Private m_RsCustomer As New ADODB.Recordset

    Private m_RsDistributor As New ADODB.Recordset
    Private m_RsCustomerShipTo As New ADODB.Recordset
    Private m_RsCustomerGroup As New ADODB.Recordset
    Private m_RsCustomerClass As New ADODB.Recordset
    Private m_RsAreaOfCoverage As New ADODB.Recordset
    Private Table As New DataTable

    Private m_RsRegion As New ADODB.Recordset
    Private m_RsDistrict As New ADODB.Recordset
    Private m_RsArea As New ADODB.Recordset
    Private m_RsTerritory As New ADODB.Recordset
    Private m_RsZipCode As New ADODB.Recordset

    Private m_IsNewMode As Boolean = True
    Private m_HasError As Boolean = False
    Private m_Err As New ErrorProvider
    Private m_Action As String = ""
    '==============================================================================
    Private Enum EnumAction
        ADD = 1
        UPDATE = 2
        DELETE = 3
    End Enum

    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnAdd.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode
    End Sub

    Private Sub Clear()
        txtArea.Text = String.Empty
        txtAreaOfCoverage.Text = String.Empty
        txtCompany.Text = String.Empty
        txtContactPerson.Text = String.Empty
        txtCustomerAddress1.Text = String.Empty
        txtCustomerAddress2.Text = String.Empty
        'txtCustomerClass.Text = String.Empty
        txtCustomerCode.Text = String.Empty
        txtCustomerGroup.Text = String.Empty
        txtCustomerName.Text = String.Empty
        txtDiscount.Text = String.Empty
        txtCollectionClassification.Text = String.Empty
        txtAreaName.Text = String.Empty
        cboTermCode.SelectedIndex = -1

        CheckBox1.Checked = False
        txtShipTO.Text = String.Empty
        txtDefaultShipTo.Text = String.Empty
        txtDistrict.Text = String.Empty
        txtFilter.Text = String.Empty
        txtPhoneNumber.Text = String.Empty
        txtTerritory.Text = String.Empty
        cboCompany.Text = ""
        cboTerritory.SelectedIndex = -1

        m_Err.Clear()
        m_HasError = False

        chkAccountShared.Checked = False
        chkIsDistributor.Checked = False
        chkVatable.Checked = False

        cboCompany.SelectedIndex = -1
        cboRegion.SelectedIndex = -1
        cboRegionDesc.SelectedIndex = -1
        cmbPHRegionCode.SelectedIndex = -1
        cmbPHRegionName.SelectedIndex = -1
        

        cboDistrict.Items.Clear()
        cboDistrictDesc.Items.Clear()
        cboArea.Items.Clear()
        cboAreaDesc.Items.Clear()
        cboZipCode.Items.Clear()
        'cmbPHRegionCode.Items.Clear()
        'cboTerritory.Items.Clear()
        cboDistrict.Text = ""
        cboDistrictDesc.Text = ""
        cboArea.Text = ""
        cboAreaDesc.Text = ""
        'cboZipCode.Text = ""
        txtZipCode.Text = ""
        cboCompany.Text = ""
        'cmbPHRegionCode.Text = ""

        cboCustomerGroup.SelectedIndex = -1
        cboCustomerClass.SelectedIndex = -1
        LoadCustomerGroup()
        LoadCustomerClass()
        
        'cboDistrict.Items.Clear()
        '
        'cboArea.Items.Clear()
        '
        'cboZipCode.Items.Clear()
    End Sub

    Private Sub FieldLock(ByVal IsLocked As Boolean)
        txtContactPerson.ReadOnly = IsLocked
        txtContactPerson.BackColor = Color.White
        txtCustomerAddress1.ReadOnly = IsLocked
        txtCustomerAddress1.BackColor = Color.White
        txtCustomerAddress2.ReadOnly = IsLocked
        txtCustomerAddress2.BackColor = Color.White
        txtCustomerCode.ReadOnly = IsLocked
        txtCustomerCode.BackColor = Color.White
        txtCustomerName.ReadOnly = IsLocked
        txtCustomerName.BackColor = Color.White
        txtPhoneNumber.ReadOnly = IsLocked
        txtPhoneNumber.BackColor = Color.White

        chkAccountShared.Enabled = Not IsLocked
        chkIsDistributor.Enabled = Not IsLocked
        chkVatable.Enabled = Not IsLocked
        cboCompany.Enabled = Not IsLocked
        cboRegion.Enabled = Not IsLocked
        cboRegionDesc.Enabled = Not IsLocked
        cboDistrict.Enabled = Not IsLocked
        cboDistrictDesc.Enabled = Not IsLocked
        cboArea.Enabled = Not IsLocked
        cboAreaDesc.Enabled = Not IsLocked
        'cboZipCode.Enabled = Not IsLocked

    End Sub
    Private Sub EnableText()
        txtContactPerson.ReadOnly = True
        txtCustomerAddress1.ReadOnly = True
        txtCustomerAddress2.ReadOnly = True
        txtCustomerCode.ReadOnly = True
        txtCustomerName.ReadOnly = True
        txtPhoneNumber.ReadOnly = True
        txtCompany.ReadOnly = True
    End Sub
    Private Sub UnEnableText()
        txtContactPerson.ReadOnly = False
        txtCustomerAddress1.ReadOnly = False
        txtCustomerAddress2.ReadOnly = False
        txtCustomerCode.ReadOnly = False
        txtCustomerName.ReadOnly = False
        txtPhoneNumber.ReadOnly = False
        txtCompany.ReadOnly = False
    End Sub
    Private Sub LoadSelection()
        cboSelection.Items.Clear()
        cboSelection.Items.Add("All")
        For m As Integer = 0 To dgCustomerList.ColumnCount - 1
            cboSelection.Items.Add(dgCustomerList.Columns(m).HeaderText)
        Next

    End Sub

    Private Sub Customer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadSelection()
        ApplyGridTheme(dgCustomerList)

        Clear()

        LoadAreaOfCoverage()
        LoadCustomerClass()
        LoadCustomerGroup()
        'LoadCustomerShipTo()
        LoadDistributor()
        LoadTerms()

        LoadRegion()
        MainTab.SelectTab(0)
        LoadCustomerToGrid()

        FieldLock(True)
        EditMode(False)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    '===========================================================================================
    'Code For Sales Area Teritory Falls Here

    Private Sub LoadRegion()
        Table = GetRecords("SELECT REGCD,  REGNAME FROM REGION WHERE DLTFLG = 0 ")
        If Table.Rows.Count > 0 Then
            txtRegion.Text = ""
            cboRegion.Items.Clear()
            cboRegionDesc.Items.Clear()
            For i As Integer = 0 To Table.Rows.Count - 1
                cboRegion.Items.Add(Table.Rows(i)("REGCD"))
                cboRegionDesc.Items.Add(Table.Rows(i)("REGNAME"))
            Next
        End If
    End Sub

    Private Sub LoadTerms()
        Table = GetRecords("Select Code, CreditTerm From Credit_Terms")
        If Table.Rows.Count > 0 Then
            txtTerm.Text = ""
            cboTermCode.Items.Clear()
            For i As Integer = 0 To Table.Rows.Count - 1
                cboTermCode.Items.Add(Table.Rows(i)("CreditTerm"))
                txtTerm.Text = Table.Rows(i)("Code")
            Next
        End If
    End Sub

    Private Sub LoadDistrict(ByVal RegionCode As String)

        Table = GetRecords("SELECT DISTRCTCD FROM District WHERE DLTFLG = 0  AND REGCD = '" & RegionCode & "'")
        cboDistrict.Items.Clear()
        txtDistrict.Text = ""
        If Table.Rows.Count > 0 Then
            For i As Integer = 0 To Table.Rows.Count - 1
                cboDistrict.Items.Add(Table.Rows(i)("DISTRCTCD"))
            Next
            cboArea.Items.Clear()
            cboArea.Text = ""
            txtArea.Text = ""
        Else
            cboDistrict.SelectedIndex = -1
        End If

    End Sub


    'Private Sub LoadArea(ByVal DistrictCode As String, ByVal RegionCode As String)

    '    Table = GetRecords("SELECT AREACD FROM AREA WHERE  DLTFLG = 0  AND DISTRCTCD = '" & DistrictCode & "'  AND REGCD = '" & RegionCode & "' ")
    '    cboArea.Items.Clear()
    '    cboArea.Text = ""
    '    txtArea.Text = ""
    '    If Table.Rows.Count > 0 Then
    '        For i As Integer = 0 To Table.Rows.Count - 1
    '            cboArea.Items.Add(Table.Rows(i)("AREACD"))
    '        Next
    '        cboZipCode.Items.Clear()
    '        cboZipCode.Text = ""
    '    Else
    '        cboArea.SelectedIndex = -1
    '    End If

    'End Sub


    Private Sub LoadZipCode(ByVal AreaCode As String, ByVal RegionCode As String, ByVal DistrictCode As String)

        Table = GetRecords("SELECT ZIPCD FROM ZIPCODE WHERE DLTFLG = 0 " & IIf(AreaCode <> "", " AND AREACD = '" & AreaCode & "' ", "") & IIf(RegionCode <> "", " AND REGCD = '" & RegionCode & "' ", "") & IIf(DistrictCode <> "", " AND DISTRCTCD = '" & DistrictCode & "' ", ""))
        cboZipCode.Items.Clear()
        If Table.Rows.Count > 0 Then
            For i As Integer = 0 To Table.Rows.Count - 1
                cboZipCode.Items.Add(Table.Rows(i)("ZIPCD"))
            Next
        End If
    End Sub

    Private Sub LoadTerritory(ByVal RegionCode As String, ByVal DistrictCode As String)

        Table = GetRecords("SELECT DISTINCT STTERRCD FROM SALESMATRIX WHERE DLTFLG = 0  " & IIf(RegionCode <> "", " AND REGCD = '" & RegionCode & "' ", "") & IIf(DistrictCode <> "", " AND DISTRCTCD = '" & DistrictCode & "' ", ""))
        cboTerritory.Items.Clear()
        If Table.Rows.Count > 0 Then
            For i As Integer = 0 To Table.Rows.Count - 1
                cboTerritory.Items.Add(Table.Rows(i)("STTERRCD"))
            Next
        End If
    End Sub

    Private Sub GetRegionDescription(ByVal RegionCode As String)

        Table = GetRecords("SELECT REGNAME FROM REGION WHERE DLTFLG = 0  AND REGCD = '" & RegionCode & "'")
        If Table.Rows.Count > 0 Then
            For i As Integer = 0 To Table.Rows.Count - 1
                txtRegion.Text = Table.Rows(i)("REGNAME")
                cboRegionDesc.Text = Table.Rows(i)("REGNAME")
            Next
        Else
            cboRegionDesc.Text = ""
            txtRegion.Text = ""

        End If
    End Sub

    Private Sub GetTermCode(ByVal CreditTerm As String)

        Table = GetRecords("Select Code From Credit_Terms Where CreditTerm = '" & CreditTerm & "' ")
        If Table.Rows.Count > 0 Then
            For i As Integer = 0 To Table.Rows.Count - 1
                txtTerm.Text = Table.Rows(i)("Code")
            Next
        Else
            txtTerm.Text = ""
        End If
    End Sub

    Private Sub GetDistrictDescription(ByVal DistrictCode As String, ByVal RegionCode As String)

        Table = GetRecords("SELECT DISTRCTNAME FROM District WHERE DLTFLG = 0 AND DISTRCTCD = '" & DistrictCode & "' AND REGCD = '" & RegionCode & "' ")
        If Table.Rows.Count > 0 Then
            For i As Integer = 0 To Table.Rows.Count - 1
                txtDistrict.Text = Table.Rows(i)("DISTRCTNAME")
                cboDistrictDesc.Text = Table.Rows(i)("DISTRCTNAME")
            Next
        Else
            cboDistrictDesc.Text = ""
            txtDistrict.Text = ""
        End If
    End Sub

    'Private Sub GetAreaDescription(ByVal AreaCode As String, ByVal RegionCode As String, ByVal DistrictCode As String)

    '    Table = GetRecords("SELECT AREANAME FROM AREA WHERE  DLTFLG = 0  AND AREACD = '" & AreaCode & "'  AND REGCD = '" & RegionCode & "'  AND DISTRCTCD  = '" & DistrictCode & "'")
    '    If Table.Rows.Count > 0 Then
    '        For i As Integer = 0 To Table.Rows.Count - 1
    '            txtArea.Text = Table.Rows(i)("AREANAME")
    '            cboAreaDesc.Text = Table.Rows(i)("AREANAME")
    '        Next
    '    Else
    '        txtArea.Text = ""
    '        cboAreaDesc.Text = ""
    '    End If

    'End Sub

    Private Sub GetPhRegionName(ByVal PhRegionCode As String)

        Table = GetRecords("Select RegionName from PhRegion Where RegionCode  = '" & PhRegionCode & "' ")
        If Table.Rows.Count > 0 Then
            For i As Integer = 0 To Table.Rows.Count - 1
                cmbPHRegionName.Text = Table.Rows(i)("RegionName")
            Next
        Else
            cmbPHRegionName.Text = ""
        End If

    End Sub

    Private Sub GetTerritoryDescription(ByVal TerritoryCode As String)

        Table = GetRecords("SELECT STACOVNAME FROM SALESMATRIX  WHERE STTERRCD = '" & TerritoryCode & "' GROUP BY STTERRCD, STACOVNAME ")
        If Table.Rows.Count > 0 Then
            For i As Integer = 0 To Table.Rows.Count - 1
                txtTerritory.Text = Table.Rows(i)("STACOVNAME")
            Next
        Else
            txtTerritory.Text = ""
        End If
    End Sub
    Private Sub cboRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRegion.SelectedIndexChanged
        GetRegionDescription(cboRegion.Text)
        LoadDistrict(cboRegion.Text)
    End Sub
    Private Sub cboDistrict_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDistrict.SelectedIndexChanged
        GetDistrictDescription(cboDistrict.Text, cboRegion.Text)
        'LoadArea(cboDistrict.Text, cboRegion.Text)
    End Sub

    Private Sub cboArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboArea.SelectedIndexChanged
        'GetAreaDescription(cboArea.Text, cboRegion.Text, cboDistrict.Text)
        LoadZipCode(cboArea.Text, cboRegion.Text, cboDistrict.Text)
    End Sub

    Private Sub cmbPHRegionCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPHRegionCode.SelectedIndexChanged
        GetPhRegionName(cmbPHRegionCode.Text)
    End Sub

    Private Sub cboTerritory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTerritory.SelectedIndexChanged
        GetTerritoryDescription(cboTerritory.Text)
        LoadTerritory(cboRegion.Text, cboDistrict.Text)
    End Sub

    '========================================================================================================================
    'All Codes for loading items to combo boxes falls here.

    Private Sub LoadDistributor()
        Table = GetRecords("SELECT * FROM DISTRIBUTOR WHERE  DLTFLG = 0 ")
        If Table.Rows.Count > 0 Then
            cboCompany.Items.Clear()
            For i As Integer = 0 To Table.Rows.Count - 1
                cboCompany.Items.Add(Table.Rows(i)("DISTCOMID"))
            Next
        End If
    End Sub

    Private Sub LoadCustomerShipTo()
        Table = GetRecords("SELECT * FROM CustomerShipTo WHERE CUSTOMERSHIPTODEL = 0")
        If Table.Rows.Count > 0 Then
            cboDefaultShipTo.Items.Clear()
            For i As Integer = 0 To Table.Rows.Count - 1
                cboDefaultShipTo.Items.Add(Table.Rows(i)("CDACD"))
                m_RsCustomerShipTo.MoveNext()
            Next
        End If
    End Sub

    Private Sub LoadCustomerClass()
        Table = GetRecords("SELECT * FROM CustomerClass WHERE DLTFLG = 0")
        If Table.Rows.Count > 0 Then
            cboCustomerClass.Items.Clear()
            For i As Integer = 0 To Table.Rows.Count - 1
                cboCustomerClass.Items.Add(Trim(Table.Rows(i)("CUSTOMERCLASSCD")))
            Next
        End If
    End Sub

    Private Sub LoadCustomerGroup()
        Table = GetRecords("SELECT * FROM CUSTOMERGROUP WHERE DLTFLG = 0 ")
        If Table.Rows.Count > 0 Then
            cboCustomerGroup.Items.Clear()
            For i As Integer = 0 To Table.Rows.Count - 1
                cboCustomerGroup.Items.Add(Trim(Table.Rows(i)("CUSTOMERGROUPCD")))
            Next
        End If
    End Sub

    Private Sub LoadAreaOfCoverage()
        Table = GetRecords("SELECT * FROM STAREACOVERAGE WHERE DLTFLG = 0 ")
        If Table.Rows.Count > 0 Then
            cboAreaOfCoverage.Items.Clear()
            For i As Integer = 0 To Table.Rows.Count - 1
                cboAreaOfCoverage.Items.Add(Table.Rows(i)("STACOVCD"))
            Next
        End If
    End Sub

    '============================================================================================================
    'Codes For ComboBox Value Changed falls here
    Private Sub GetCompanyName(ByVal CompanyCode As String)
        Table = GetRecords("SELECT DISTNAME FROM DISTRIBUTOR WHERE DLTFLG = 0 AND DISTCOMID= '" & CompanyCode & "'")
        If Table.Rows.Count > 0 Then
            For i As Integer = 0 To Table.Rows.Count - 1
                txtCompany.Text = Table.Rows(i)("DISTNAME")
            Next
        End If
    End Sub

    Private Sub GetCustomerClassName(ByVal CustomerClassCode As String)
        Table = GetRecords("SELECT CUSTOMERCLASSNAME  FROM CustomerClass WHERE DLTFLG = 0  AND  CUSTOMERCLASSCD = '" & CustomerClassCode & "' ")
        If Table.Rows.Count > 0 Then
            For i As Integer = 0 To Table.Rows.Count - 1
                txtCustomerClass.Text = Table.Rows(i)("CUSTOMERCLASSNAME")
            Next
        End If
    End Sub

    Private Sub GetCustomerGroupName(ByVal CustomerGroupCode As String)
        Table = GetRecords("SELECT CUSTOMERGROUPNAME FROM CUSTOMERGROUP WHERE DLTFLG = 0 AND CUSTOMERGROUPCD = '" & CustomerGroupCode & "'")
        If Table.Rows.Count > 0 Then
            For i As Integer = 0 To Table.Rows.Count - 1
                txtCustomerGroup.Text = Table.Rows(i)("CUSTOMERGROUPNAME")
            Next
    End If
    End Sub

    Private Sub GetCustomerShipToName(ByVal CustomerShipToCode As String, ByVal ComID As String, ByVal CustomerCode As String)
        Table = GetRecords("SELECT CDANAME FROM CUSTOMERSHIPTO WHERE CUSTOMERSHIPTODEL = 0  AND COMID =  '" & ComID & "'  AND CustomerCD = '" & CustomerCode & "'   AND CDACD = '" & CustomerShipToCode & "'")
        If Table.Rows.Count > 0 Then
            For i As Integer = 0 To Table.Rows.Count - 1
                txtDefaultShipTo.Text = Table.Rows(i)("CDANAME")
            Next
        End If
    End Sub

    Private Sub GetAreaOfCoverageDescription(ByVal AreaofCoverageCode As String)
        Table = GetRecords("SELECT STACOVNAME FROM STAREACOVERAGE WHERE DLTFLG = 0  AND STACOVCD = '" & AreaofCoverageCode & "'")
        If Table.Rows.Count > 0 Then
            For i As Integer = 0 To Table.Rows.Count - 1
                txtAreaOfCoverage.Text = Table.Rows(i)("STACOVNAME")
            Next
        Else
            txtAreaOfCoverage.Text = ""
        End If
    End Sub

    Private Sub cboCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If cboCompany.SelectedIndex <> -1 Then
            GetCompanyName(cboCompany.Text)
        Else
            txtCompany.Text = String.Empty
        End If
    End Sub

    Private Sub cboCustomerClass_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomerClass.SelectedIndexChanged
        If cboCustomerClass.SelectedIndex <> -1 Then
            GetCustomerClassName(cboCustomerClass.Text)
        End If
    End Sub

    Private Sub cboCustomerGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomerGroup.SelectedIndexChanged
        If cboCustomerGroup.SelectedIndex <> -1 Then
            GetCustomerGroupName(cboCustomerGroup.Text)
        End If
    End Sub

    Private Sub cboDefaultShipTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'If cboDefaultShipTo.SelectedIndex <> -1 Then
        '    GetCustomerShipToName(cboDefaultShipTo.Text)
        'End If
    End Sub
    Private Sub cboAreaOfCoverage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        GetAreaOfCoverageDescription(cboAreaOfCoverage.Text)
    End Sub

    Private Sub cboTermCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTermCode.SelectedIndexChanged
        GetTermCode(cboTermCode.Text)
    End Sub
    Private Function CheckIfCustomerCodeExist(ByVal CustomerCode As String) As Boolean
        Table = GetRecords("SELECT * FROM CUSTOMER WHERE COMID ='" & cboCompany.Text & "' AND CUSTOMERDEL = 0 AND CUSTOMERCD = '" & CustomerCode & "'")
        If Table.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    '=======================================================================================================
    'Loading Data

    Private Sub ShowData(ByVal rs As ADODB.Recordset)

        'cboCustomerClass.SelectedItem = Trim(rs.Fields("CMCLASS").Value)
        'GetCustomerClassName(rs.Fields("CMCLASS").Value)

        cboCustomerGroup.SelectedItem = Trim(rs.Fields("CMGRP").Value)
        GetCustomerGroupName(rs.Fields("CMGRP").Value)

        txtShipTO.Text = rs.Fields("CDACD").Value
        GetCustomerShipToName(rs.Fields("CDACD").Value, rs.Fields("COMID").Value, rs.Fields("CustomerCD").Value)

        txtCustomerCode.Text = rs.Fields("CUSTOMERCD").Value
        txtCustomerCode.Tag = rs.Fields("CUSTOMERCD").Value

        txtCustomerName.Text = rs.Fields("CUSTOMERNAME").Value
        txtCustomerAddress1.Text = rs.Fields("CADD1").Value
        txtCustomerAddress2.Text = rs.Fields("CADD2").Value
        txtPhoneNumber.Text = rs.Fields("CMPHON").Value
        txtContactPerson.Text = rs.Fields("CMCONT").Value
        txtDiscount.Text = rs.Fields("DISCOUNT").Value
        txtCollectionClassification.Text = rs.Fields("COLLECTOR").Value

        cboRegion.SelectedItem = rs.Fields("REGCD").Value
        GetRegionDescription(cboRegion.Text)

        cboDistrict.SelectedItem = rs.Fields("DISTCD").Value
        GetDistrictDescription(cboDistrict.Text, cboRegion.Text)

        'cboArea.SelectedItem = rs.Fields("AREACD").Value
        'GetAreaDescription(cboArea.Text, cboRegion.Text, cboDistrict.Text)

        cboTerritory.SelectedItem = rs.Fields("TERRCD").Value
        GetTerritoryDescription(cboTerritory.Text)

        'cboAreaOfCoverage.SelectedItem = rs.Fields("AREACOVRG").Value
        'GetAreaOfCoverageDescription(cboAreaOfCoverage.Text)

        txtAreaName.Text = rs.Fields("AREACD").Value

        'cboZipCode.SelectedItem = rs.Fields("ZIPCD").Value

        txtZipCode.Text = rs.Fields("ZIPCD").Value

        If rs.Fields("PHREGCD").Value = "" Then
            cmbPHRegionCode.SelectedIndex = -1
            cmbPHRegionName.SelectedIndex = -1
        Else
            cmbPHRegionCode.SelectedItem = rs.Fields("PHREGCD").Value
            GetPhRegionName(cmbPHRegionCode.Text)
        End If

        dtStart.Value = rs.Fields("EFFECTIVITYSTARTDATE").Value
        dtEnd.Value = rs.Fields("EFFECTIVITYENDDATE").Value
        dtCustomerClass.Value = rs.Fields("CMCLASS").Value


        If rs.Fields("DISTRIBCD").Value <> "" Then
            chkIsDistributor.Checked = True
        Else
            chkIsDistributor.Checked = False
            cboCompany.SelectedItem = rs.Fields("COMID").Value
            GetCompanyName(rs.Fields("COMID").Value)
        End If


        chkVatable.Checked = rs.Fields("VAT").Value
        chkAccountShared.Checked = rs.Fields("ACCNTSHRD").Value

        EditMode(False)
        FieldLock(True)
    End Sub


    Private Sub chkIsDistributor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If chkIsDistributor.Checked = True Then
            cboCompany.Enabled = False
            cboCompany.SelectedIndex = -1
        Else
            cboCompany.Enabled = True
        End If
    End Sub


    '===========================================================================================
    ' Code for Distributor

    Private Sub SaveDistributor()

        Try
            SPMSConn.Execute("EXEC uspDistributor @Action = '" & m_Action & "' , @DISTNAME = '" & txtCustomerName.Text & "' , @DISTCOMID = '" & txtCustomerCode.Text & "' ")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub DeleteDistributor()
        Try
            SPMSConn.Execute("EXEC uspDistributor @Action = 'DELETE' , @DLTFLG = 1 , @DISTCOMID= '" & txtCustomerCode.Text & "'")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Function RsLockedShipto(Optional ByVal Filter As String = "", Optional ByVal Orderby As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        If Filter <> "" Then
            Filter = " and " & Filter
        End If
        If Orderby <> "" Then
            Orderby = " Order by " & Orderby
        End If
        rs.Open("select * From CustomerShipto where customershiptodel = 0 " & Filter & Orderby, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function

    Private Function CustomerShiptoExist(ByVal CustomerCD As String, ByVal CdaCd As String, ByVal ComID As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs = RsLockedShipto("customercd = '" & CustomerCD & "' and cdacd = '" & CdaCd & "' and comid = '" & ComID & "' ")
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SaveShipToAddress()
        Try
            If CustomerShiptoExist(HandleSingleQuoteInSql(txtCustomerCode.Text), HandleSingleQuoteInSql(txtShipTO.Text), IIf(chkIsDistributor.Checked, txtCustomerCode.Text, cboCompany.Text)) = True Then
                SPMSConn.Execute("EXEC uspCustomerShipTo @Action = '" & m_Action & "' ,  @COMID =  '" & IIf(chkIsDistributor.Checked, txtCustomerCode.Text, cboCompany.Text) & "' , " & _
                                                " @CustomerCD = '" & HandleSingleQuoteInSql(txtCustomerCode.Text) & "' ,  " & _
                                                " @CDACD = '" & HandleSingleQuoteInSql(txtShipTO.Text) & "' , @CDANAME = '" & HandleSingleQuoteInSql(txtDefaultShipTo.Text) & "' , " & _
                                                " @CDACADD1 = '" & HandleSingleQuoteInSql(txtCustomerAddress1.Text) & "' , @CDACADD2 = '" & HandleSingleQuoteInSql(txtCustomerAddress2.Text) & "' , " & _
                                                " @CDACONT= '" & HandleSingleQuoteInSql(txtContactPerson.Text) & "' , @CDAPHON = '" & txtPhoneNumber.Text & "', " & _
                                                " @ZIPCD = '" & txtZipCode.Text & "' , @REGCD = '" & cboRegion.Text & "' , " & _
                                                " @DISTCD = '" & cboDistrict.Text & "' , @AREACD = '" & txtAreaName.Text & "' , @TERRCD = '" & cboTerritory.Text & "' , @CMGRP = '" & cboCustomerGroup.Text & "' , @CMCLASS = '" & dtCustomerClass.Value & "'  , " & _
                                                " @AREACOVRG = '" & cboAreaOfCoverage.Text & "' , @ACCNTSHRD = " & IIf(chkAccountShared.Checked, "1", "0") & ",@EFFECTIVITYSTARTDATE  = '" & dtStart.Value & "' ,@EFFECTIVITYENDDATE  = '" & dtEnd.Value & "' ")
            Else
                m_Action = EnumAction.ADD.ToString
                SPMSConn.Execute("EXEC uspCustomerShipTo @Action = '" & m_Action & "' ,  @COMID =  '" & IIf(chkIsDistributor.Checked, txtCustomerCode.Text, cboCompany.Text) & "' , " & _
                                                " @CustomerCD = '" & HandleSingleQuoteInSql(txtCustomerCode.Text) & "' ,  " & _
                                                " @CDACD = '" & HandleSingleQuoteInSql(txtShipTO.Text) & "' , @CDANAME = '" & HandleSingleQuoteInSql(txtDefaultShipTo.Text) & "' , " & _
                                                " @CDACADD1 = '" & HandleSingleQuoteInSql(txtCustomerAddress1.Text) & "' , @CDACADD2 = '" & HandleSingleQuoteInSql(txtCustomerAddress2.Text) & "' , " & _
                                                " @CDACONT= '" & HandleSingleQuoteInSql(txtContactPerson.Text) & "' , @CDAPHON = '" & txtPhoneNumber.Text & "', " & _
                                                " @ZIPCD = '" & txtZipCode.Text & "' , @REGCD = '" & cboRegion.Text & "' , " & _
                                                " @DISTCD = '" & cboDistrict.Text & "' , @AREACD = '" & txtAreaName.Text & "' , @TERRCD = '" & cboTerritory.Text & "' , @CMGRP = '" & cboCustomerGroup.Text & "' , @CMCLASS = '" & dtCustomerClass.Value & "'  , " & _
                                                " @AREACOVRG = '" & cboAreaOfCoverage.Text & "' , @ACCNTSHRD = " & IIf(chkAccountShared.Checked, "1", "0") & ",@EFFECTIVITYSTARTDATE  = '" & dtStart.Value & "' ,@EFFECTIVITYENDDATE  = '" & dtEnd.Value & "' ")
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub DeleteCustomerShipto()
        Try
            SPMSConn.Execute("EXEC uspCustomerShipTo @Action = 'DELETE' , @CustomerCD = '" & txtCustomerCode.Text & "', @CDACD = '" & HandleSingleQuoteInSql(txtShipTO.Text) & "' , @COMID =  '" & IIf(chkIsDistributor.Checked, txtCustomerCode.Text, cboCompany.Text) & "' ")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Function SaveData() As Boolean
        Try
            If m_IsNewMode Then
                m_Action = EnumAction.ADD.ToString
            Else
                m_Action = EnumAction.UPDATE.ToString
            End If
            SPMSConn.Execute("EXEC uspCustomer @Action = '" & m_Action & "' , @Comid = '" & IIf(chkIsDistributor.Checked, txtCustomerCode.Text, cboCompany.Text) & "' , " & _
                " @CustomerCD = '" & HandleSingleQuoteInSql(txtCustomerCode.Text) & "', @CustomerNAME = '" & HandleSingleQuoteInSql(txtCustomerName.Text) & "' , @DistribCD = '" & IIf(chkIsDistributor.Checked, txtCustomerCode.Text, "") & "', " & _
                " @CADD1 = '" & HandleSingleQuoteInSql(txtCustomerAddress1.Text) & "', @CADD2 = '" & HandleSingleQuoteInSql(txtCustomerAddress2.Text) & "' , @CMCont = '" & HandleSingleQuoteInSql(txtContactPerson.Text) & "' , @Cmphon = '" & txtPhoneNumber.Text & "', " & _
                " @CDACD = '" & HandleSingleQuoteInSql(txtShipTO.Text) & "' , @ZIPCD = '" & txtZipCode.Text & "' , @REGCD = '" & cboRegion.Text & "' , " & _
                " @DISTCD = '" & cboDistrict.Text & "' , @AREACD = '" & txtAreaName.Text & "' , @TERRCD = '" & cboTerritory.Text & "' , @CMGRP = '" & cboCustomerGroup.Text & "' , @CMCLASS = '" & dtCustomerClass.Value & "'  , " & _
                " @AREACOVRG = '""' , @VAT = " & IIf(chkVatable.Checked, "1", "0") & ", @OLDCUSTCODE = '" & IIf(txtCustomerCode.Tag Is Nothing, "", txtCustomerCode.Tag) & "' , " & _
                " @ACCNTSHRD = " & IIf(chkAccountShared.Checked, "1", "0") & ", @EFFECTIVITYSTARTDATE = '" & dtStart.Value & "' ,@EFFECTIVITYENDDATE  = '" & dtEnd.Value & "', " & _
                " @CREDITTERMCODE = '" & txtTerm.Text & "', @DISCOUNT = '" & txtDiscount.Text & "', @COLLECTOR = '" & txtCollectionClassification.Text & "' ")
            SaveShipToAddress()
            If chkIsDistributor.Checked Then
                SaveDistributor()
            End If

            SaveSuccess()
            LoadCustomerToGrid()
            Clear()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Sub Delete()
        Try
            SPMSConn.Execute("EXEC uspCustomer @Action = 'DELETE' , @CustomerCD = '" & txtCustomerCode.Text & "'")
            'DeleteCustomerShipto()
            DeleteShipTo()
            If chkIsDistributor.Checked Then
                DeleteDistributor()
            End If
            DeleteSuccess()
            RefreshAll()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub DeleteShipTo()
        Try
            SPMSConn.Execute("EXEC uspCustomerShipTo @Action = 'DELETESHIPTO' , @CustomerCD= '" & txtCustomerCode.Text & "', @COMID =  '" & cboCompany.Text & "' ")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub
    Private Sub btnAdd_Click(ByVal sende5r As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        m_IsNewMode = True
        Clear()
        EditMode(True)
        FieldLock(False)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If txtCustomerCode.Text <> "" Then
            m_IsNewMode = False
            EditMode(True)
            FieldLock(False)
        Else
            VDialog.Show("There was no record to modify", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim q As MsgBoxResult
        q = VDialog.Show("Are you sure you want to Delete this record?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If q = MsgBoxResult.Yes Then
            Delete()
            Clear()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateData() Then
            If SaveData() Then
                EditMode(False)
                FieldLock(True)
                Clear()
            End If
        End If
    End Sub

    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False

        If Not chkIsDistributor.Checked Then
            If cboCompany.Text = "" Then
                m_Err.SetError(cboCompany, "Company is required")
                m_HasError = True
            End If
        End If
        If txtCustomerCode.Text = "" Then
            m_Err.SetError(txtCustomerCode, "Customer Code is required")
            m_HasError = True
        Else
            If m_IsNewMode Then
                If CheckIfCustomerCodeExist(txtCustomerCode.Text) Then
                    m_Err.SetError(txtCustomerCode, "Customer Code Already Exist")
                    m_HasError = True
                End If
            End If
        End If
        If txtCustomerName.Text = "" Then
            m_Err.SetError(txtCustomerName, "Custome Name is required")
            m_HasError = True
        End If

        If txtCustomerAddress1.Text = "" Then
            m_Err.SetError(txtCustomerAddress1, "Customer Address1 is required")
            m_HasError = True
        End If

        If txtCustomerAddress2.Text = "" Then
            m_Err.SetError(txtCustomerAddress2, "Customer Address2 is required")
            m_HasError = True
        End If

        'If cboCustomerClass.Text = "" Then
        '    m_Err.SetError(cboCustomerClass, "Customer Class is required")
        '    m_HasError = True
        'End If

        If cboCustomerGroup.Text = "" Then
            m_Err.SetError(cboCustomerGroup, "Customer Group is required")
            m_HasError = True
        End If

        If cboRegion.Text = "" Then
            m_Err.SetError(cboRegion, "State is required")
            m_HasError = True
        End If

        'If cmbPHRegionCode.Text = "" Then
        '    m_Err.SetError(cmbPHRegionCode, "Region is required")
        '    m_HasError = True
        'End If

        If cboDistrict.Text = "" Then
            m_Err.SetError(cboDistrict, "District is required")
            m_HasError = True
        End If

        'If cboArea.Text = "" Then
        '    m_Err.SetError(cboArea, "Area is required")
        '    m_HasError = True
        'End If

        'If cboZipCode.Text = "" Then
        '    m_Err.SetError(cboZipCode, "Zip Code is required")
        '    m_HasError = True
        'End If

        If txtShipTO.Text = "" Then
            m_Err.SetError(txtShipTO, "Ship To is required")
            m_HasError = True
        End If

        If txtDefaultShipTo.Text = "" Then
            m_Err.SetError(txtDefaultShipTo, "Ship To is required")
            m_HasError = True
        End If


        'If cboTerritory.Text = "" Then
        '    m_Err.SetError(cboTerritory, "Territory is required")
        '    m_HasError = True
        'End If

        Return Not m_HasError
    End Function

    '==============================================================================================
    ' Listing goes here

    Private Sub LoadCustomerToGrid()
        If m_RsCustomer.State = 1 Then m_RsCustomer.Close()
        m_RsCustomer.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsCustomer.Open("SELECT * FROM CUSTOMER WHERE CUSTOMERDEL = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsCustomer.RecordCount > 0 Then
            RefreshGrid(m_RsCustomer)
        Else
            dgCustomerList.Rows.Clear()
        End If
    End Sub
    Private Sub RefreshGrid(ByVal rs As ADODB.Recordset)
        dgCustomerList.Rows.Clear()
        For m As Integer = 0 To rs.RecordCount - 1
            Dim row As DataGridViewRow = dgCustomerList.Rows(dgCustomerList.Rows.Add)
            row.Cells(colCompanyCode.Index).Value = rs.Fields("COMID").Value
            row.Cells(colCustomerCode.Index).Tag = rs.Fields("CUSTOMERCD").Value
            row.Cells(colCustomerCode.Index).Value = rs.Fields("CUSTOMERCD").Value
            row.Cells(colCustomerName.Index).Value = rs.Fields("CUSTOMERNAME").Value
            row.Cells(colEffectivityStartDate.Index).Value = rs.Fields("EFFECTIVITYSTARTDATE").Value
            row.Cells(colEffectivityEndDate.Index).Value = rs.Fields("EFFECTIVITYENDDATE").Value

            rs.MoveNext()
        Next
    End Sub

    Private Sub FilterData()
        Dim FilterField As String = ""
        If cboSelection.Text = "Channel's Code" Then
            FilterField = "COMID"
        ElseIf cboSelection.Text = "Customer Code" Then
            FilterField = "CUSTOMERCD"
        ElseIf cboSelection.Text = "Customer Name" Then
            FilterField = "CUSTOMERNAME"
        End If
        If cboSelection.Text = "All" Then
            txtFilter.Text = ""
            LoadCustomerToGrid()
        End If
        If FilterField <> "" Then
            If m_RsCustomer.State = 1 Then m_RsCustomer.Close()
            m_RsCustomer.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            m_RsCustomer.Open("SELECT * FROM CUSTOMER WHERE CUSTOMERDEL = 0 AND " & FilterField & " like '%" & txtFilter.Text & "%' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If m_RsCustomer.RecordCount > 0 Then
                RefreshGrid(m_RsCustomer)
            End If
        End If
    End Sub

    Private Sub lnkRefresh_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkRefresh.LinkClicked
        LoadCustomerToGrid()
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        FilterData()
    End Sub

    Private Sub dgCustomerList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCustomerList.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Dim row As DataGridViewRow = dgCustomerList.Rows(e.RowIndex)

        If m_RsCustomer.State = 1 Then m_RsCustomer.Close()
        m_RsCustomer.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsCustomer.Open("SELECT * FROM CUSTOMER WHERE CUSTOMERDEL = 0 AND COMID = '" & row.Cells(colCompanyCode.Index).Value & "'  AND CUSTOMERCD = '" & row.Cells(colCustomerCode.Index).Tag & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsCustomer.RecordCount > 0 Then
            ShowData(m_RsCustomer)
            MainTab.SelectTab(0)
        End If

    End Sub

    Private Sub RefreshAll()
        LoadSelection()
       
        Clear()
        'LoadRegion()
        'LoadTerritory()
        MainTab.SelectTab(0)
        LoadCustomerToGrid()
        FieldLock(True)
        EditMode(False)
    End Sub

    Private Sub dgCustomerList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCustomerList.CellContentClick

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        txtShipTO.Text = "001"
        txtDefaultShipTo.Text = txtCustomerName.Text
    End Sub

    Private Function RsRegion(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT * FROM REGION WHERE DLTFLG= 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


        Return rs
    End Function

    Private Function District(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT * FROM DISTRICT WHERE DLTFLG = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function

    Private Function Area(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT * FROM AREA WHERE DLTFLG = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


        Return rs
    End Function

    Private Sub cboRegionDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRegionDesc.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
        rs = RsRegion("RegName = '" & cboRegionDesc.Text & "' ")
        If rs.RecordCount > 0 Then
            cboRegion.Text = rs.Fields("RegCD").Value

            rs = District("REGCD = '" & cboRegion.Text & "' ")
            cboDistrictDesc.Items.Clear()
            cboAreaDesc.Items.Clear()
            cboDistrictDesc.Text = ""
            cboAreaDesc.Text = ""
            cboDistrict.Text = ""
            If rs.RecordCount > 0 Then
                For i As Integer = 1 To rs.RecordCount
                    cboDistrictDesc.Items.Add(rs.Fields("DISTRCTNAME").Value)
                    rs.MoveNext()
                Next
            End If
        End If


    End Sub

    Private Sub cboDistrictDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrictDesc.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
        rs = District("RegCD = '" & cboRegion.Text & "' AND DISTRCTNAME = '" & cboDistrictDesc.Text & "' ")

        cboAreaDesc.Items.Clear()
        cboAreaDesc.Text = ""

        If rs.RecordCount > 0 Then
            cboDistrict.Text = rs.Fields("DISTRCTCD").Value

            rs = Area("REGCD = '" & cboRegion.Text & "' AND DISTRCTCD  = '" & cboDistrict.Text & "' ")
            If rs.RecordCount > 0 Then
                For i As Integer = 1 To rs.RecordCount
                    cboAreaDesc.Items.Add(rs.Fields("AREANAME").Value)
                    rs.MoveNext()
                Next
            End If
        End If
    End Sub

    Private Sub cboAreaDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAreaDesc.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
        rs = Area("REGCD = '" & cboRegion.Text & "' AND DISTRCTCD = '" & cboDistrict.Text & "'  AND AREANAME = '" & cboAreaDesc.Text & "' ")
        If rs.RecordCount > 0 Then
            cboArea.Text = rs.Fields("AREACD").Value
        End If
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Chr(13) Then
            FilterData()
        End If

    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub


    Private Sub cboCompany_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCompany.SelectedIndexChanged
        Table = GetRecords("SELECT DISTCOMID,DISTNAME   FROM DISTRIBUTOR WHERE  DLTFLG = 0 AND DISTCOMID = '" & cboCompany.Text & "'")
        For i As Integer = 0 To Table.Rows.Count - 1
            txtCompany.Text = Table.Rows(i)("DISTNAME")
        Next
    End Sub

    Private Sub chkAccountShared_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccountShared.CheckedChanged

    End Sub
End Class
