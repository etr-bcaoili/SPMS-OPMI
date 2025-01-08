Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ucMasterRegion
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule

Public Class ucMasterCustomerShipTo
    Private GridRs As New ADODB.Recordset
    Private Operation As String
    Private m_RsRegion As New ADODB.Recordset
    Private m_RsDistrict As New ADODB.Recordset
    Private m_RsArea As New ADODB.Recordset
    Private m_RsZipCode As New ADODB.Recordset
    Private m_RsTerritory As New ADODB.Recordset
    Private m_RsCustomerClass As New ADODB.Recordset
    Private m_RsCustomerGroup As New ADODB.Recordset
    Private m_RsDistributor As New ADODB.Recordset
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_Action As String = ""

    Private m_IsNewMode As Boolean = False

    Private Enum EnumAction
        ADD = 1
        UPDATE = 2
    End Enum


    Private Sub SetupbyOperation(ByVal HasOperation As Boolean)
        btnAdd.Enabled = HasOperation
        btnEdit.Enabled = HasOperation
        btnDelete.Enabled = HasOperation
        btnSave.Enabled = Not HasOperation
    End Sub
    Private Sub LoadSelection()
        cboSelection.Items.Clear()
        cboSelection.Items.Add("All")
        For m As Integer = 0 To GridListing.ColumnCount - 1
            cboSelection.Items.Add(GridListing.Columns(m).HeaderText)
        Next

    End Sub
    Private Sub ClearForm()
        txtCustomerName.Text = ""
        txtCustomerShiptoName.Text = ""
        txtCustomerShipToCode.Text = ""
        txtCustomerAddress1.Text = ""
        txtCustomerAddress2.Text = ""
        txtFilter.Text = ""
        cboCompany.SelectedIndex = -1
        txtCompany.Text = ""

        cboRegion.SelectedIndex = -1
        txtRegion.Text = ""
        cboArea.SelectedIndex = -1
        txtArea.Text = ""
        txtAreaOfCoverage.Text = ""
        cboCustomerClass.SelectedIndex = -1
        txtCustomerClass.Text = ""
        cboCustomerGroup.SelectedIndex = -1
        txtCustomerGroup.Text = ""
        cboDistrict.SelectedIndex = -1
        txtDistrict.Text = ""

        txtCustomerCode.Text = ""
        txtPhoneNumber.Text = ""
        txtContactPerson.Text = ""
        cboAreaDesc.Text = ""
        cboDistrictDesc.Text = ""


        cboZipCode.SelectedIndex = -1

    End Sub

    Private Sub LoadCustomerShipToGrid(ByVal gridrs As ADODB.Recordset)
        Dim RsRegion As New ADODB.Recordset
        Dim RsDistrict As New ADODB.Recordset
        Dim RsArea As New ADODB.Recordset

        For i As Integer = 1 To gridrs.RecordCount
            Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
            RsRegion = RsLockedregion("RegCD = '" & gridrs.Fields("RegCD").Value & "' ")
            RsDistrict = RsLockedDistrict("RegCD = '" & gridrs.Fields("RegCD").Value & "' AND DistrctCD = '" & gridrs.Fields("DistCD").Value & "' ")
            RsArea = RsLockedArea("RegCD = '" & gridrs.Fields("RegCD").Value & "' AND DistrctCD = '" & gridrs.Fields("DistCD").Value & "' AND AreaCD = '" & gridrs.Fields("AreaCD").Value & "' ")


            row.Cells(ChannelsCode.Index).Value = gridrs.Fields("COMID").Value
            row.Cells(CustomerCode.Index).Value = gridrs.Fields("CUSTOMERCD").Value
            row.Cells(CustomerShipToCode.Index).Value = gridrs.Fields("CDACD").Value
            row.Cells(CustomerShipToName.Index).Value = gridrs.Fields("CDANAME").Value
            row.Cells(CustomerShipToAddress1.Index).Value = gridrs.Fields("CDACADD1").Value
            row.Cells(CustomerShipToAddress2.Index).Value = gridrs.Fields("CDACADD2").Value
            row.Cells(colRegion.Index).Value = gridrs.Fields("REGCD").Value
            If RsRegion.RecordCount > 0 Then
                row.Cells(colRegionName.Index).Value = RsRegion.Fields("RegName").Value
            End If

            row.Cells(CityProvince.Index).Value = gridrs.Fields("DISTCD").Value
            If RsDistrict.RecordCount > 0 Then
                row.Cells(CityProvinceName.Index).Value = RsDistrict.Fields("DistrctName").Value
            End If
            row.Cells(Municipality.Index).Value = gridrs.Fields("AREACD").Value

            If RsArea.RecordCount > 0 Then
                row.Cells(MunicipalityName.Index).Value = RsArea.Fields("AreaName").Value
            End If

            row.Cells(ZipCode.Index).Value = gridrs.Fields("ZIPCD").Value


            gridrs.MoveNext()
        Next
    End Sub

    Private Function RsLockedregion(Optional ByVal Filter As String = "", Optional ByVal OrderBy As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " and " & Filter
        End If
        If OrderBy <> "" Then
            OrderBy = " order by " & OrderBy
        End If
        rs.Open("Select * from Region where dltflg = 0 " & Filter & OrderBy, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs
    End Function

    Private Function RsLockedDistrict(Optional ByVal Filter As String = "", Optional ByVal Orderby As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " and " & Filter
        End If
        If Orderby <> "" Then
            Orderby = " order by " & Orderby
        End If
        rs.Open("select * from District where dltflg = 0 " & Filter & Orderby, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function

    Private Function RsLockedArea(Optional ByVal Filter As String = "", Optional ByVal Orderby As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " and " & Filter
        End If
        If Orderby <> "" Then
            Orderby = " order by " & Orderby
        End If
        rs.Open("select * from area where dltflg = 0 " & Filter & Orderby, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function


    Private Sub OpenListing()
        If GridRs.State = 1 Then GridRs.Close()
        GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        GridRs.Open("SELECT * FROM CUSTOMERSHIPTO WHERE CUSTOMERSHIPTODEL = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        GridListing.Rows.Clear()
        If GridRs.RecordCount > 0 Then
            LoadCustomerShipToGrid(GridRs)
        End If
    End Sub

    Private Function SaveRecord(ByVal Code As String, ByVal Name As String, ByVal Address As String, ByVal ContactNumber As String, ByVal Email As String, ByVal Tinno As String) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC uspCustomerShipTo @ACTION = 'ADD', @DLTFLG = 0, @COMID = '" & Code & "', @COMNAME = '" & Name & "', @ADDR = '" & Address & "', @CONTACTNUMBER = '" & ContactNumber & "', @EMAIL = '" & Email & "', @TINNO = '" & Tinno & "', @CRTDATE = '" & Now & "',  @CRTU = '', @UPDD = '" & Now & "',  @UPDU = '' ")
        Return True

ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Function UpdateRecord(ByVal Code As String, ByVal Name As String, ByVal Address As String, ByVal ContactNumber As String, ByVal Email As String, ByVal Tinno As String) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC USPCOMPANY @ACTION = 'UPDATE', @DLTFLG = 0, @COMID = '" & Code & "', @COMNAME = '" & Name & "', @ADDR = '" & Address & "', @CONTACTNUMBER = '" & ContactNumber & "', @EMAIL = '" & Email & "', @TINNO = '" & Tinno & "', @CRTDATE = '" & Now & "',  @CRTU = '', @UPDD = '" & Now & "',  @UPDU = '' ")
        Return True
ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Function DeleteRecord(ByVal Code As String, ByVal Name As String, ByVal Address As String) As Boolean
        On Error GoTo ErrorHandler
        SPMSConn.Execute("EXEC USPCOMPANY @ACTION = 'UPDATE', @DLTFLG = 1, @COMID = '" & Code & "', @COMNAME = '" & Name & "', @ADDR = '" & Address & "', , @CRTDATE = '" & Now & "',  @CRTU = '', @UPDD = '" & Now & "',  @UPDU = '' ")
        Return True
ErrorHandler:
        If ErrorExist(Err.Number) = True Then

        Else
            ShowExclamation(Err.Number & " - " & Err.Description, "Error")
            Err.Clear()
        End If
    End Function

    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False

        If txtCustomerShipToCode.Text = "" Then
            m_Err.SetError(txtCustomerShipToCode, "Customer Ship To Code is required")
            m_HasError = True
        End If

        If txtCustomerShiptoName.Text = "" Then
            m_Err.SetError(txtCustomerShiptoName, "Customer Ship To Name is required")
            m_HasError = True
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

        If cboCustomerClass.Text = "" Then
            m_Err.SetError(cboCustomerClass, "Customer Class is required")
            m_HasError = True
        End If

        If cboCustomerGroup.Text = "" Then
            m_Err.SetError(cboCustomerGroup, "Customer Group is required")
            m_HasError = True
        End If

        If cboRegion.Text = "" Then
            m_Err.SetError(cboRegion, "Region is required")
            m_HasError = True
        End If

        If cboDistrict.Text = "" Then
            m_Err.SetError(cboDistrict, "District is required")
            m_HasError = True
        End If

        If cboArea.Text = "" Then
            m_Err.SetError(cboArea, "Area is required")
            m_HasError = True
        End If

        If cboZipCode.Text = "" Then
            m_Err.SetError(cboZipCode, "Zip Code is required")
            m_HasError = True
        End If

        'If txtShipTO.Text = "" Then
        '    m_Err.SetError(txtShipTO, "Ship To is required")
        '    m_HasError = True
        'End If

        'If cboTerritory.Text = "" Then
        '    m_Err.SetError(cboTerritory, "Territory is required")
        '    m_HasError = True
        'End If

        Return Not m_HasError
    End Function

    Private Function CheckRecordExists(ByVal Code As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM COMPANY WHERE COMID = '" & Code & "' AND DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub LockFields(ByVal isLocked As Boolean)

        cboArea.Enabled = Not isLocked
        chkAccountShared.Enabled = Not isLocked

        cboAreaOfCoverage.Enabled = Not isLocked

        cboCompany.Enabled = Not isLocked
        cboCustomerClass.Enabled = Not isLocked
        cboCustomerGroup.Enabled = Not isLocked
        cboDistrict.Enabled = Not isLocked
        cboRegion.Enabled = Not isLocked
        cboZipCode.Enabled = Not isLocked

        txtCustomerShipToCode.ReadOnly = isLocked
        txtCustomerShipToCode.BackColor = Color.White
        txtCustomerShiptoName.ReadOnly = isLocked
        txtCustomerShiptoName.BackColor = Color.White
        txtContactPerson.ReadOnly = isLocked
        txtContactPerson.BackColor = Color.White
        txtCustomerAddress1.ReadOnly = isLocked
        txtCustomerAddress1.BackColor = Color.White
        txtCustomerAddress2.ReadOnly = isLocked
        txtCustomerAddress2.BackColor = Color.White
        txtCustomerName.ReadOnly = isLocked
        txtCustomerName.BackColor = Color.White
        txtPhoneNumber.ReadOnly = isLocked
        txtPhoneNumber.BackColor = Color.White


    End Sub

    Private Sub MasterItemGroup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetupbyOperation(True)
        ApplyGridTheme(GridListing)
        LockFields(True)
        'OpenListing()
        LoadRegion()
        LoadAreaOfCoverage()
        LoadCustomerClass()
        LoadCustomerGroup()
        LoadDistributor()
        LoadSelection()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateData() Then
            If Not CheckIfShipToCustomerCodeExist(txtCustomerShipToCode.Text, cboCompany.Text, txtCustomerCode.Text, IIf(txtCustomerShipToCode.Tag Is Nothing, -1, txtCustomerShipToCode.Tag)) Then
                SaveShipToAddress()
                LockFields(True)
                ClearForm()
                VDialog.Show("Record Sucessfully Saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                VDialog.Show("Customer Ship To Code Already Exist", "Record Exists", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        SetupbyOperation(False)
        LockFields(False)
        'Operation = "Edit"
        m_IsNewMode = False
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        SetupbyOperation(False)
        'Operation = "Add"
        m_IsNewMode = True
        LockFields(False)
        ClearForm()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim q As MsgBoxResult
        q = VDialog.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If q = MsgBoxResult.Yes Then
            DeleteCustomerShipto()
            ClearForm()
            m_IsNewMode = True
            SetupbyOperation(True)
            VDialog.Show("Record Successfully Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        'If CheckRecordExists(txtCode.Text) = True Then
        '    DeleteRecord(txtCode.Text, txtName.Text, txtAddress.Text)
        '    DeleteSuccess()
        '    SetupbyOperation(False)
        '    Operation = ""
        '    OpenListing()
        'End If
    End Sub



    Private Sub ShowData(ByVal rs As ADODB.Recordset)


        cboCustomerClass.SelectedItem = Trim(rs.Fields("CMCLASS").Value)
        GetCustomerClassName(rs.Fields("CMCLASS").Value)

        cboCustomerGroup.SelectedItem = Trim(rs.Fields("CMGRP").Value)
        GetCustomerGroupName(rs.Fields("CMGRP").Value)

        cboCompany.SelectedItem = rs.Fields("COMID").Value
        GetCompanyName(rs.Fields("COMID").Value)

        txtCustomerCode.Text = rs.Fields("CUSTOMERCD").Value
        GetCustomerName(rs.Fields("COMID").Value, rs.Fields("CUSTOMERCD").Value)

        cboRegion.SelectedItem = rs.Fields("REGCD").Value
        GetRegionDescription(rs.Fields("REGCD").Value)

        cboDistrict.SelectedItem = rs.Fields("DISTCD").Value
        GetDistrictDescription(rs.Fields("DISTCD").Value, rs.Fields("REGCD").Value)

        cboArea.SelectedItem = rs.Fields("AREACD").Value
        GetAreaDescription(rs.Fields("AREACD").Value, rs.Fields("REGCD").Value, rs.Fields("DISTCD").Value)

        cboZipCode.SelectedItem = Trim(rs.Fields("ZIPCD").Value)
        dtStart.Value = rs.Fields("EFFECTIVITYSTARTDATE").Value
        dtEnd.Value = rs.Fields("EFFECTIVITYENDDATE").Value

        txtCustomerShipToCode.Text = rs.Fields("CDACD").Value
        txtCustomerShipToCode.Tag = rs.Fields("CUSTOMERSHIPTOID").Value
        txtCustomerShiptoName.Text = rs.Fields("CDANAME").Value
        txtCustomerAddress1.Text = rs.Fields("CDACADD1").Value
        txtCustomerAddress2.Text = rs.Fields("CDACADD2").Value

        txtContactPerson.Text = rs.Fields("CDACONT").Value
        txtPhoneNumber.Text = rs.Fields("CDAPHON").Value

        chkAccountShared.Checked = rs.Fields("ACCNTSHRD").Value


    End Sub

    Private Sub Filter()
        Dim field As String = ""
        Dim filterString As String = ""
        If GridRs.State = 1 Then GridRs.Close()
        If cboSelection.Text = "Channel's Code" Then
            field = "COMID"
        ElseIf cboSelection.Text = "Customer Code" Then
            field = "CUSTOMERCD"
        ElseIf cboSelection.Text = "Customer Ship To Code" Then
            field = "CDACD"
        ElseIf cboSelection.Text = "Customer Ship To Name" Then
            field = "CDANAME"
        ElseIf cboSelection.Text = "Customer Ship To Address 1" Then
            field = "CDACADD1"
        ElseIf cboSelection.Text = "Customer Ship To Address 2" Then
            field = "CDACADD2"
        ElseIf cboSelection.Text = "Region" Then
            field = "REGCD"
        ElseIf cboSelection.Text = "City/Province" Then
            field = "DISTCD"
        ElseIf cboSelection.Text = "Municipality" Then
            field = "AREACD"
        ElseIf cboSelection.Text = "Zip Code" Then
            field = "ZIPCD"
        Else
            field = ""
            txtFilter.Text = ""
        End If
        If field <> "" Then filterString = " AND  " & field & " like '%" & txtFilter.Text & "%'"
        GridRs.Open("SELECT * FROM CUSTOMERSHIPTO WHERE CUSTOMERSHIPTODEL = 0  " & filterString, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If GridRs.RecordCount > 0 Then
            GridListing.Rows.Clear()
            LoadCustomerShipToGrid(GridRs)
        End If
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Filter()

    End Sub

    Private Sub GridListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Dim row As DataGridViewRow = GridListing.Rows(e.RowIndex)
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM CUSTOMERSHIPTO WHERE COMID = '" & row.Cells(ChannelsCode.Index).Value & "' AND CUSTOMERSHIPTODEL = 0  AND CUSTOMERCD = '" & row.Cells(CustomerCode.Index).Value & "'  AND CDACD = '" & row.Cells(CustomerShipToCode.Index).Value & "'   ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            ShowData(rs)
            SetupbyOperation(True)
            LockFields(True)
            MainTab.SelectTab(0)
        Else

        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub LoadDistributor()
        Dim m_RsDistributor As New ADODB.Recordset
        If m_RsDistributor.State = 1 Then m_RsDistributor.Close()
        m_RsDistributor.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsDistributor.Open("SELECT * FROM DISTRIBUTOR WHERE  DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsDistributor.RecordCount > 0 Then
            cboCompany.Items.Clear()
            For m As Integer = 0 To m_RsDistributor.RecordCount - 1
                cboCompany.Items.Add(m_RsDistributor.Fields("DISTCOMID").Value)
                m_RsDistributor.MoveNext()
            Next
        End If
    End Sub
    Private Sub SaveShipToAddress()
        Try

            If m_IsNewMode Then
                m_Action = EnumAction.ADD.ToString
            Else
                m_Action = EnumAction.UPDATE.ToString
            End If

            SPMSConn.Execute("EXEC uspCustomerShipTo @Action = '" & m_Action & "' ,  @COMID =  '" & cboCompany.Text & "' , " & _
                                            " @CustomerCD = '" & HandleSingleQuoteInSql(txtCustomerCode.Text) & "' ,  " & _
                                            " @CDACD = '" & HandleSingleQuoteInSql(txtCustomerShipToCode.Text) & "' , @CDANAME = '" & HandleSingleQuoteInSql(txtCustomerShiptoName.Text) & "' , " & _
                                            " @CDACADD1 = '" & HandleSingleQuoteInSql(txtCustomerAddress1.Text) & "' , @CDACADD2 = '" & HandleSingleQuoteInSql(txtCustomerAddress2.Text) & "' , " & _
                                            " @CDACONT= '" & txtContactPerson.Text & "' , @CDAPHON = '" & txtPhoneNumber.Text & "', " & _
                                            " @ZIPCD = '" & cboZipCode.Text & "' , @REGCD = '" & cboRegion.Text & "' , " & _
                                            " @DISTCD = '" & cboDistrict.Text & "' , @AREACD = '" & cboArea.Text & "' , @TERRCD = '" & "" & "' , @CMGRP = '" & cboCustomerGroup.Text & "' , @CMCLASS = '" & cboCustomerClass.Text & "'  , " & _
                                            " @AREACOVRG = '" & "" & "' , @ACCNTSHRD = " & IIf(chkAccountShared.Checked = True, "1", "0") & " , @EFFECTIVITYSTARTDATE = '" & dtStart.Value & "' ,@EFFECTIVITYENDDATE = '" & dtEnd.Value & "'")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub


    Private Function CheckIfShipToCustomerCodeExist(ByVal CustomerShipToCode As String, ByVal CompanyCode As String, ByVal CustomerCode As String, ByVal CustomerShipToID As Integer) As Boolean
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM CUSTOMERSHIPTO WHERE CUSTOMERSHIPTODEL = 0 AND CustomerShipToID <> " & CustomerShipToID & " AND COMID = '" & HandleSingleQuoteInSql(CompanyCode) & "' AND CUSTOMERCD = '" & HandleSingleQuoteInSql(CustomerCode) & "' AND CDACD = '" & HandleSingleQuoteInSql(CustomerShipToCode) & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub DeleteCustomerShipto()
        Try
            SPMSConn.Execute("EXEC uspCustomerShipTo @Action = 'DELETE' , @CustomerCD= '" & txtCustomerCode.Text & "', @CDACD = '" & HandleSingleQuoteInSql(txtCustomerShipToCode.Text) & "' , @COMID =  '" & cboCompany.Text & "' ")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    'Private Sub LoadCustomerClass()
    '    Dim m_RsCustomerClass As New ADODB.Recordset
    '    If m_RsCustomerClass.State = 1 Then m_RsCustomerClass.Close()
    '    m_RsCustomerClass.CursorLocation = ADODB.CursorLocationEnum.adUseClient
    '    m_RsCustomerClass.Open("SELECT * FROM CustomerClass WHERE DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
    '    If m_RsCustomerClass.RecordCount > 0 Then
    '        cboCustomerClass.Items.Clear()
    '        For m As Integer = 0 To m_RsCustomerClass.RecordCount - 1
    '            cboCustomerClass.Items.Add(m_RsCustomerClass.Fields("CUSTOMERCLASSNAME").Value)
    '            m_RsCustomerClass.MoveNext()
    '        Next
    '    End If
    'End Sub

    'Private Sub LoadCustomerGroup()
    '    Dim m_RsCustomerGroup As New ADODB.Recordset
    '    If m_RsCustomerGroup.State = 1 Then m_RsCustomerGroup.Close()
    '    m_RsCustomerGroup.CursorLocation = ADODB.CursorLocationEnum.adUseClient
    '    m_RsCustomerGroup.Open("SELECT * FROM CUSTOMERGROUP WHERE DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
    '    If m_RsCustomerGroup.RecordCount > 0 Then
    '        cboCustomerGroup.Items.Clear()
    '        For m As Integer = 0 To m_RsCustomerGroup.RecordCount - 1
    '            cboCustomerGroup.Items.Add(m_RsCustomerGroup.Fields("CUSTOMERGROUPNAME").Value)
    '            m_RsCustomerGroup.MoveNext()
    '        Next
    '    End If
    'End Sub
    Private Sub LoadCustomerClass()
        If m_RsCustomerClass.State = 1 Then m_RsCustomerClass.Close()
        m_RsCustomerClass.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsCustomerClass.Open("SELECT * FROM CustomerClass WHERE DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsCustomerClass.RecordCount > 0 Then
            cboCustomerClass.Items.Clear()
            For m As Integer = 0 To m_RsCustomerClass.RecordCount - 1
                cboCustomerClass.Items.Add(Trim(m_RsCustomerClass.Fields("CUSTOMERCLASSCD").Value))
                m_RsCustomerClass.MoveNext()
            Next
        End If
    End Sub

    Private Sub LoadCustomerGroup()
        If m_RsCustomerGroup.State = 1 Then m_RsCustomerGroup.Close()
        m_RsCustomerGroup.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsCustomerGroup.Open("SELECT * FROM CUSTOMERGROUP WHERE DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsCustomerGroup.RecordCount > 0 Then
            cboCustomerGroup.Items.Clear()
            For m As Integer = 0 To m_RsCustomerGroup.RecordCount - 1
                cboCustomerGroup.Items.Add(Trim(m_RsCustomerGroup.Fields("CUSTOMERGROUPCD").Value))
                m_RsCustomerGroup.MoveNext()
            Next
        End If
    End Sub

    Private Sub LoadAreaOfCoverage()
        Dim m_RsAreaOfCoverage As New ADODB.Recordset
        If m_RsAreaOfCoverage.State = 1 Then m_RsAreaOfCoverage.Close()
        m_RsAreaOfCoverage.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsAreaOfCoverage.Open("SELECT * FROM STAREACOVERAGE WHERE DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsAreaOfCoverage.RecordCount > 0 Then
            cboAreaOfCoverage.Items.Clear()
            For m As Integer = 0 To m_RsAreaOfCoverage.RecordCount - 1
                cboAreaOfCoverage.Items.Add(m_RsAreaOfCoverage.Fields("STACOVNAME").Value)
                m_RsAreaOfCoverage.MoveNext()
            Next
        End If

    End Sub

    Private Sub LoadRegion()
        If m_RsRegion.State = 1 Then m_RsRegion.Close()
        m_RsRegion.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsRegion.Open("SELECT REGCD,  REGNAME FROM REGION WHERE DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsRegion.RecordCount > 0 Then
            txtRegion.Text = ""
            cboRegion.Items.Clear()
            cboRegionDesc.Items.Clear()
            For m As Integer = 0 To m_RsRegion.RecordCount - 1
                cboRegion.Items.Add(m_RsRegion.Fields("REGCD").Value)
                cboRegionDesc.Items.Add(m_RsRegion.Fields("REGNAME").Value)
                m_RsRegion.MoveNext()
            Next
        End If
    End Sub


    Private Sub LoadDistrict(ByVal RegionCode As String)
        If m_RsDistrict.State = 1 Then m_RsDistrict.Close()
        m_RsDistrict.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsDistrict.Open("SELECT DISTRCTCD FROM District WHERE DLTFLG = 0 " & IIf(RegionCode <> "", " AND REGCD = '" & RegionCode & "' ", ""), SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        cboDistrict.Items.Clear()
        txtDistrict.Text = ""

        If m_RsDistrict.RecordCount > 0 Then
            For m As Integer = 0 To m_RsDistrict.RecordCount - 1
                cboDistrict.Items.Add(m_RsDistrict.Fields("DISTRCTCD").Value)
                m_RsDistrict.MoveNext()
            Next
            cboArea.Items.Clear()
            cboArea.Text = ""
            txtArea.Text = ""
        Else
            cboDistrict.SelectedIndex = -1

        End If

    End Sub


    Private Sub LoadArea(ByVal DistrictCode As String, ByVal RegionCode As String)

        If m_RsArea.State = 1 Then m_RsArea.Close()
        m_RsArea.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsArea.Open("SELECT AREACD FROM AREA WHERE  DLTFLG = 0  AND DISTRCTCD = '" & DistrictCode & "'  AND REGCD = '" & RegionCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        cboArea.Items.Clear()
        cboArea.Text = ""
        txtArea.Text = ""
        cboAreaDesc.Text = ""

        If m_RsArea.RecordCount > 0 Then
            For m As Integer = 0 To m_RsArea.RecordCount - 1
                cboArea.Items.Add(m_RsArea.Fields("AREACD").Value)
                m_RsArea.MoveNext()
            Next
            cboZipCode.Items.Clear()
            cboZipCode.Text = ""
        Else
            cboArea.SelectedIndex = -1
        End If

    End Sub



    Private Sub LoadZipCode(ByVal AreaCode As String, ByVal RegionCode As String, ByVal DistrictCode As String)
        If m_RsZipCode.State = 1 Then m_RsZipCode.Close()
        m_RsZipCode.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsZipCode.Open("SELECT ZIPCD FROM ZIPCODE WHERE DLTFLG = 0 " & IIf(AreaCode <> "", " AND AREACD = '" & AreaCode & "' ", "") & IIf(RegionCode <> "", " AND REGCD = '" & RegionCode & "' ", "") & IIf(DistrictCode <> "", " AND DISTRCTCD = '" & DistrictCode & "' ", ""), SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        cboZipCode.Items.Clear()
        If m_RsZipCode.RecordCount > 0 Then
            For m As Integer = 0 To m_RsZipCode.RecordCount - 1
                cboZipCode.Items.Add(m_RsZipCode.Fields("ZIPCD").Value)
                m_RsZipCode.MoveNext()
            Next
        End If
    End Sub

    Private Sub LoadTerritory()
        'If m_RsTerritory.State = 1 Then m_RsTerritory.Close()
        'm_RsTerritory.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'm_RsTerritory.Open("SELECT DISTINCT STTERRCD FROM SALESMATRIX GROUP BY STTERRCD ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        'cboTerritory.Items.Clear()
        'If m_RsTerritory.RecordCount > 0 Then
        '    For m As Integer = 0 To m_RsTerritory.RecordCount - 1
        '        cboTerritory.Items.Add(m_RsTerritory.Fields("STTERRCD").Value)
        '        m_RsTerritory.MoveNext()
        '    Next
        'End If
    End Sub



    Private Sub GetRegionDescription(ByVal RegionCode As String)
        If m_RsRegion.State = 1 Then m_RsRegion.Close()
        m_RsRegion.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsRegion.Open("SELECT REGNAME FROM REGION WHERE DLTFLG = 0  AND REGCD = '" & RegionCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsRegion.RecordCount > 0 Then
            txtRegion.Text = m_RsRegion.Fields("REGNAME").Value
            cboRegionDesc.Text = m_RsRegion.Fields("REGNAME").Value
        Else
            cboRegionDesc.Text = ""
            txtRegion.Text = ""

        End If
    End Sub

    Private Sub GetDistrictDescription(ByVal DistrictCode As String, ByVal RegionCode As String)
        If m_RsDistrict.State = 1 Then m_RsDistrict.Close()
        m_RsDistrict.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsDistrict.Open("SELECT DISTRCTNAME FROM District WHERE DLTFLG = 0 AND DISTRCTCD = '" & DistrictCode & "' AND REGCD = '" & RegionCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsDistrict.RecordCount > 0 Then
            txtDistrict.Text = m_RsDistrict.Fields("DISTRCTNAME").Value
            cboDistrictDesc.Text = m_RsDistrict.Fields("DISTRCTNAME").Value
        Else
            cboDistrictDesc.Text = ""
            txtDistrict.Text = ""
        End If
    End Sub

    Private Sub GetAreaDescription(ByVal AreaCode As String, ByVal RegionCode As String, ByVal DistrictCode As String)
        If m_RsArea.State = 1 Then m_RsArea.Close()
        m_RsArea.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsArea.Open("SELECT AREANAME FROM AREA WHERE  DLTFLG = 0  AND AREACD = '" & AreaCode & "'  AND REGCD = '" & RegionCode & "'  AND DISTRCTCD  = '" & DistrictCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsArea.RecordCount > 0 Then
            txtArea.Text = m_RsArea.Fields("AREANAME").Value
            cboAreaDesc.Text = m_RsArea.Fields("AREANAME").Value
        Else
            txtArea.Text = ""
            cboAreaDesc.Text = ""
        End If

    End Sub
    Private Sub GetTerritoryDescription(ByVal TerritoryCode As String)
        'If m_RsTerritory.State = 1 Then m_RsTerritory.Close()
        'm_RsTerritory.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'm_RsTerritory.Open("SELECT STACOVNAME FROM SALESMATRIX  WHERE STTERRCD = '" & TerritoryCode & "' GROUP BY STTERRCD, STACOVNAME ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        'If m_RsTerritory.RecordCount > 0 Then
        '    txtTerritory.Text = m_RsTerritory.Fields("STACOVNAME").Value
        'Else
        '    txtTerritory.Text = ""
        'End If
    End Sub
    Private Sub cboRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRegion.SelectedIndexChanged
        ' If cboRegion.SelectedIndex <> -1 Then
        GetRegionDescription(cboRegion.Text)
        LoadDistrict(cboRegion.Text)

        'Else
        '   txtRegion.Text = ""
        ' End If
    End Sub

    Private Sub cboDistrict_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDistrict.SelectedIndexChanged
        GetDistrictDescription(cboDistrict.Text, cboRegion.Text)
        LoadArea(cboDistrict.Text, cboRegion.Text)

    End Sub

    Private Sub cboArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboArea.SelectedIndexChanged
        GetAreaDescription(cboArea.Text, cboRegion.Text, cboDistrict.Text)
        LoadZipCode(cboArea.Text, cboRegion.Text, cboDistrict.Text)
    End Sub

    'Private Sub cboTerritory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTerritory.SelectedIndexChanged
    '    'GetTerritoryDescription(cboTerritory.Text)
    'End Sub
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

    Private Sub GetCustomerClassName(ByVal CustomerClassCode As String)
        If m_RsCustomerClass.State = 1 Then m_RsCustomerClass.Close()
        m_RsCustomerClass.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsCustomerClass.Open("SELECT CUSTOMERCLASSNAME  FROM CustomerClass WHERE DLTFLG = 0  AND  CUSTOMERCLASSCD = '" & CustomerClassCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsCustomerClass.RecordCount > 0 Then
            txtCustomerClass.Text = m_RsCustomerClass.Fields("CUSTOMERCLASSNAME").Value
        End If

    End Sub

    Private Sub GetCustomerGroupName(ByVal CustomerGroupCode As String)
        If m_RsCustomerGroup.State = 1 Then m_RsCustomerGroup.Close()
        m_RsCustomerGroup.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsCustomerGroup.Open("SELECT CUSTOMERGROUPNAME FROM CUSTOMERGROUP WHERE DLTFLG = 0 AND CUSTOMERGROUPCD = '" & CustomerGroupCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsCustomerGroup.RecordCount > 0 Then
            txtCustomerGroup.Text = m_RsCustomerGroup.Fields("CUSTOMERGROUPNAME").Value
        End If

    End Sub

    Private Sub lnkCustCode_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCustCode.LinkClicked

        If cboCompany.Text = "" Then
            ShowExclamation("Channel is required", "Channel")
        Else
            Dim tag As SelectionTag = ShowSearchDialog("CUSTOMERCD; CUSTOMERCD; CUSTOMERNAME;", "SELECT CUSTOMERCD, CUSTOMERCD [Customer Code], CUSTOMERNAME [Customer Name] FROM CUSTOMER WHERE CUSTOMERDEL =0 AND COMID = '" & cboCompany.Text & "' ")
            If Not tag Is Nothing Then
                txtCustomerCode.Text = tag.KeyColumn1
                txtCustomerCode.Tag = tag.KeyColumn1
                txtCustomerName.Text = tag.KeyColumn3
            End If
        End If


    End Sub

    Private Sub cboCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCompany.SelectedIndexChanged
        If cboCompany.SelectedIndex <> -1 Then
            GetCompanyName(cboCompany.Text)
        Else
            txtCompany.Text = String.Empty
        End If
    End Sub
    Private Sub GetCompanyName(ByVal CompanyCode As String)
        If m_RsDistributor.State = 1 Then m_RsDistributor.Close()
        m_RsDistributor.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsDistributor.Open("SELECT DISTNAME FROM DISTRIBUTOR WHERE DLTFLG = 0 AND DISTCOMID= '" & CompanyCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsDistributor.RecordCount > 0 Then
            txtCompany.Text = m_RsDistributor.Fields("DISTNAME").Value
        End If

    End Sub
    Private Sub GetCustomerName(ByVal CompanyCode As String, ByVal CustomerCode As String)
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT CUSTOMERNAME FROM CUSTOMER WHERE CUSTOMERDEL = 0 AND COMID = '" & CompanyCode & "' AND CUSTOMERCD = '" & CustomerCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            txtCustomerName.Text = rs.Fields("CUSTOMERNAME").Value
        Else
            txtCustomerName.Text = ""
        End If
    End Sub

    Private Sub GridListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick

    End Sub

    Private Sub lnkRefresh_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkRefresh.LinkClicked
        OpenListing()
    End Sub


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

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Chr(13) Then
            Filter()
        End If
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub
End Class
