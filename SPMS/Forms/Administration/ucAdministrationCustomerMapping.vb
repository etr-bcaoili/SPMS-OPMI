
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class ucAdministrationCustomerMapping


    Private Operation = ""

    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False


    Private Sub PopulateCombo()
        cmbzipCode.Items.Clear()
        cmbRegion.Items.Clear()
        cmbRegionDesc.Items.Clear()
        cmbDistrict.Items.Clear()
        cmbDistrictDesc.Items.Clear()
        cmbMunicipality.Items.Clear()
        cmbMunicipalityDesc.Items.Clear()

        cmbCompany.Items.Clear()
        cmbCompany.Text = ""

        cmbCustomerGroup.Items.Clear()
        cmbCustomerCode.Items.Clear()

        cmbzipCode.Text = ""
        cmbRegion.Text = ""
        cmbRegionDesc.Text = ""
        cmbDistrict.Text = ""
        cmbDistrictDesc.Text = ""
        cmbMunicipality.Text = ""
        cmbMunicipalityDesc.Text = ""

        cmbCustomerCode.Text = ""
        cmbCustomerGroup.Text = ""


        'cmbMunicipality.Items.Clear()
        'cmbDistrict.Items.Clear()
        'cmbRegion.Items.Clear()
        'cmbCompany.Items.Clear()

        'for the customergroup
        Dim rs As New ADODB.Recordset
        rs.Open("select * from CustomerGroup where dltflg = 0 order by customerGroupCd", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        cmbCustomerGroup.Items.Add("")
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbCustomerGroup.Items.Add(rs.Fields("CustomerGroupNAME").Value)
                rs.MoveNext()
            Next
        End If

        'for the Region Combo box
        rs = RsRegion()
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbRegion.Items.Add(rs.Fields("RegCD").Value)
                cmbRegionDesc.Items.Add(rs.Fields("RegName").Value)

                rs.MoveNext()
            Next
        End If

        ''for the region
        'rs = New ADODB.Recordset
        'rs.Open("SELECT * FROM REGION WHERE  DLTFLG = 0 ORDER BY REGCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        'If rs.RecordCount > 0 Then
        '    cmbRegion.Items.Add("")
        '    For i As Integer = 1 To rs.RecordCount
        '        cmbRegion.Items.Add(rs.Fields("REGNAME").Value)
        '        rs.MoveNext()
        '    Next
        'End If

        rs = New ADODB.Recordset
        rs.Open("SELECT * FROM distributor WHERE dltflg = 0 order by distcomid", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            cmbCompany.Items.Add("")
            For i As Integer = 1 To rs.RecordCount
                cmbCompany.Items.Add(rs.Fields("Distcomid").Value)
                rs.MoveNext()
            Next
        End If


    End Sub

    Private Sub ComboSelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerGroup.SelectedValueChanged, _
         cmbCustomerCode.SelectedValueChanged, cmbCustomerGroup.SelectedValueChanged

        If sender Is cmbMunicipality Then
            cmbzipCode.Items.Clear()

            Dim rs As New ADODB.Recordset
            rs.Open("SELECT * FROM AREA WHERE DLTFLG = 0 AND REGCD = '" & txtRegion.Text & "' AND DISTRCTCD = '" & txtDistrict.Text & "' AND AREANAME = '" & cmbMunicipality.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                txtArea.Text = rs.Fields("AREACD").Value
            End If

            rs = New ADODB.Recordset
            rs.Open("select * from zipcode where dltflg = 0 and areacd = '" & txtArea.Text & "'  and regcd = '" & txtRegion.Text & "' and distrctcd = '" & txtDistrict.Text & "' order by zipcd", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            cmbzipCode.Items.Add("")
            For i As Integer = 1 To rs.RecordCount
                cmbzipCode.Items.Add(rs.Fields("zipcd").Value)
                rs.MoveNext()
            Next
            rs = New ADODB.Recordset
            If cmbMunicipality.Text = "" Then
                txtArea.Text = ""
                rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD,A.CMGRP,B.CDACD AS CDACD, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "'and  A.DISTCD = '" & txtDistrict.Text & "'AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            Else
                rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD,A.CMGRP,B.CDACD AS CDACD, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "'and  A.DISTCD = '" & txtDistrict.Text & "'AND A.AREACD = '" & txtArea.Text & "' AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            End If
            dgCustomer.Rows.Clear()
            If rs.RecordCount > 0 Then
                For I As Integer = 1 To rs.RecordCount
                    Dim row As DataGridViewRow = dgCustomer.Rows(dgCustomer.Rows.Add)
                    row.Cells(colCustomerCode.Index).Value = rs.Fields("CustomerCD").Value

                    row.Cells(colShiptoCode.Index).Value = rs.Fields("cdacd").Value
                    row.Cells(colShiptoName.Index).Value = rs.Fields("cdaname").Value
                    row.Cells(ShipToAddress1.Index).Value = rs.Fields("CDACADD1").Value
                    row.Cells(ShipToAddress2.Index).Value = rs.Fields("CDACADD2").Value
                    row.Cells(colRegion.Index).Value = rs.Fields("REGCD").Value
                    row.Cells(colProvince.Index).Value = rs.Fields("DISTCD").Value
                    row.Cells(colMunicipality.Index).Value = rs.Fields("AREACD").Value
                    row.Cells(colZipCode.Index).Value = rs.Fields("ZIPCD").Value
                    row.Cells(colCustomerGroup.Index).Value = rs.Fields("CMGRP").Value

                    'edited may 31 2010 

                    row.Cells(colRegionDesc.Index).Value = GetRegionDesc(rs.Fields("RegCD").Value)
                    row.Cells(colProvinceDesc.Index).Value = GetDistrictDesc(rs.Fields("RegCD").Value, rs.Fields("Distcd").Value)
                    row.Cells(colMunicipalityDesc.Index).Value = GetAreaDesc(rs.Fields("RegCD").Value, rs.Fields("DistCD").Value, rs.Fields("AreaCd").Value)


                    rs.MoveNext()
                Next
            End If
        ElseIf sender Is cmbCompany Then


            cmbCustomerCode.Items.Clear()
            txtCustomerCode.Text = ""


            Dim rs As New ADODB.Recordset
            rs.Open("SELECT * FROM DISTRIBUTOR WHERE DLTFLG = 0 AND DISTCOMID = '" & cmbCompany.Text & "'  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                txtCompany.Text = rs.Fields("distname").Value
            End If

            rs = New ADODB.Recordset
            'rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, B.CDACD AS CDACD, B.CDANAME AS CDANAME FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD AND  A.CMGRP = '" & cmbCustomerGroup.Text & "' and  A.COMID = '" & cmbCompany.Text & "' AND A.customerdel = 0 AND A.REGCD = '" & cmbRegion.Text & "' AND A.DISTCD  = '" & cmbDistrict.Text & "' AND A.AREACD = '" & cmbMunicipality.Text & "' AND A.CUSTOMERDEL = 0  ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If cmbCompany.Text = "" Then
                txtCompany.Text = ""
                rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, B.CDACD AS CDACD, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD,A.CMGRP, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD AND  A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            Else
                rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, B.CDACD AS CDACD, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD,A.CMGRP, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD AND   A.COMID = '" & cmbCompany.Text & "' AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            End If
            dgCustomer.Rows.Clear()
            If rs.RecordCount > 0 Then
                For I As Integer = 1 To rs.RecordCount
                    Dim row As DataGridViewRow = dgCustomer.Rows(dgCustomer.Rows.Add)
                    row.Cells(colCustomerCode.Index).Value = rs.Fields("CustomerCD").Value

                    row.Cells(colShiptoCode.Index).Value = rs.Fields("cdacd").Value
                    row.Cells(colShiptoName.Index).Value = rs.Fields("cdaname").Value
                    row.Cells(ShipToAddress1.Index).Value = rs.Fields("CDACADD1").Value
                    row.Cells(ShipToAddress2.Index).Value = rs.Fields("CDACADD2").Value

                    row.Cells(colRegion.Index).Value = rs.Fields("REGCD").Value
                    row.Cells(colProvince.Index).Value = rs.Fields("DISTCD").Value
                    row.Cells(colMunicipality.Index).Value = rs.Fields("AREACD").Value
                    row.Cells(colZipCode.Index).Value = rs.Fields("ZIPCD").Value
                    row.Cells(colCustomerGroup.Index).Value = rs.Fields("CMGRP").Value

                    'edited may 31 2010 

                    row.Cells(colRegionDesc.Index).Value = GetRegionDesc(rs.Fields("RegCD").Value)
                    row.Cells(colProvinceDesc.Index).Value = GetDistrictDesc(rs.Fields("RegCD").Value, rs.Fields("Distcd").Value)
                    row.Cells(colMunicipalityDesc.Index).Value = GetAreaDesc(rs.Fields("RegCD").Value, rs.Fields("DistCD").Value, rs.Fields("AreaCd").Value)

                    rs.MoveNext()
                Next
            End If
        ElseIf sender Is cmbCustomerCode Then

            Dim rs As New ADODB.Recordset
            rs.Open("SELECT * FROM CUSTOMER WHERE CUSTOMERCD = '" & cmbCustomerCode.Text & "' AND COMID = '" & cmbCompany.Text & "'  AND  CUSTOMERDEL = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                txtCustomerCode.Text = rs.Fields("CustomerName").Value
            End If
        ElseIf sender Is cmbCustomerGroup Then
            Dim rs As New ADODB.Recordset
            rs.Open("SELECT * FROM CUSTOMERGROUP WHERE DLTFLG = 0 AND CUSTOMERGROUPNAME = '" & cmbCustomerGroup.Text & "' order by CUSTOMERGROUPCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                txtCustomerGroup.Text = rs.Fields("CustomerGroupCD").Value
            End If
            rs = New ADODB.Recordset
            If cmbCustomerGroup.Text = "" Then
                txtCustomerGroup.Text = ""
                rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD, A.CMGRP,B.CDACD AS CDACD, B.CDANAME,B.CDACADD1,B.CDACADD2 AS CDANAME FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "'and  A.DISTCD = '" & txtDistrict.Text & "'AND A.AREACD = '" & txtArea.Text & "'AND A.ZIPCD = '" & cmbzipCode.Text & "' AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            Else
                rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD, A.CMGRP,B.CDACD AS CDACD, B.CDANAME,B.CDACADD1,B.CDACADD2 AS CDANAME FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "'and  A.DISTCD = '" & txtDistrict.Text & "'AND A.AREACD = '" & txtArea.Text & "'AND A.ZIPCD = '" & cmbzipCode.Text & "'AND A.CMGRP = '" & cmbCustomerGroup.Text & "' AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            End If

            dgCustomer.Rows.Clear()
            If rs.RecordCount > 0 Then
                For I As Integer = 1 To rs.RecordCount
                    Dim row As DataGridViewRow = dgCustomer.Rows(dgCustomer.Rows.Add)
                    row.Cells(colCustomerCode.Index).Value = rs.Fields("CustomerCD").Value

                    row.Cells(colShiptoCode.Index).Value = rs.Fields("cdacd").Value
                    row.Cells(colShiptoName.Index).Value = rs.Fields("cdaname").Value
                    row.Cells(ShipToAddress1.Index).Value = rs.Fields("CDACADD1").Value
                    row.Cells(ShipToAddress2.Index).Value = rs.Fields("CDACADD2").Value
                    row.Cells(colRegion.Index).Value = rs.Fields("REGCD").Value
                    row.Cells(colProvince.Index).Value = rs.Fields("DISTCD").Value
                    row.Cells(colMunicipality.Index).Value = rs.Fields("AREACD").Value
                    row.Cells(colZipCode.Index).Value = rs.Fields("ZIPCD").Value
                    row.Cells(colCustomerGroup.Index).Value = rs.Fields("CMGRP").Value


                    'edited may 31 2010 

                    row.Cells(colRegionDesc.Index).Value = GetRegionDesc(rs.Fields("RegCD").Value)
                    row.Cells(colProvinceDesc.Index).Value = GetDistrictDesc(rs.Fields("RegCD").Value, rs.Fields("Distcd").Value)
                    row.Cells(colMunicipalityDesc.Index).Value = GetAreaDesc(rs.Fields("RegCD").Value, rs.Fields("DistCD").Value, rs.Fields("AreaCd").Value)

                    rs.MoveNext()
                Next
            End If
        ElseIf sender Is cmbDistrict Then
            Dim rs As New ADODB.Recordset

            cmbMunicipality.Items.Clear()
            cmbzipCode.Items.Clear()
            txtArea.Text = ""


            rs.Open("SELECT * FROM DISTRICT WHERE DLTFLG = 0 AND REGCD = '" & txtRegion.Text & "' AND DISTRCTNAME = '" & cmbDistrict.Text & "'  ORDER BY DISTRCTCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                txtDistrict.Text = rs.Fields("DISTRCTCD").Value
                rs.MoveNext()
            End If

            rs = New ADODB.Recordset
            rs.Open("select * from Area where dltflg = 0 and regcd = '" & txtRegion.Text & "' and distrctCD = '" & txtDistrict.Text & "' order by areacd", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            cmbMunicipality.Items.Add("")
            If rs.RecordCount > 0 Then
                For i As Integer = 1 To rs.RecordCount
                    cmbMunicipality.Items.Add(rs.Fields("areaNAME").Value)
                    rs.MoveNext()
                Next
            End If
            dgMunicipality.Rows.Clear()
            Dim rsMunicipality As New ADODB.Recordset
            rsMunicipality.Open("select * from Area where dltflg = 0 and regcd = '" & txtRegion.Text & "' and distrctCD = '" & txtDistrict.Text & "' order by areacd", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                For i As Integer = 1 To rs.RecordCount
                    Dim row As DataGridViewRow = dgMunicipality.Rows(dgMunicipality.Rows.Add)
                    row.Cells(MunicipalityCode.Index).Value = rsMunicipality.Fields("AREACD").Value
                    row.Cells(MunicipalityName.Index).Value = rsMunicipality.Fields("AREANAME").Value
                    row.Cells(colRegionCode.Index).Value = rsMunicipality.Fields("REGCD").Value
                    row.Cells(colProvinceCode.Index).Value = rsMunicipality.Fields("DISTRCTCD").Value

                    row.Cells(colRegionName.Index).Value = GetRegionDesc(rsMunicipality.Fields("RegCD").Value)
                    row.Cells(colProvinceName.Index).Value = GetDistrictDesc(rsMunicipality.Fields("RegCD").Value, rsMunicipality.Fields("DISTRCTCD").Value)
                    row.Cells(ZipCode.Index).Value = GetZipCode(rsMunicipality.Fields("RegCD").Value, rsMunicipality.Fields("DISTRCTCD").Value, rsMunicipality.Fields("AREACD").Value)

                    rsMunicipality.MoveNext()
                Next
            End If

            rs = New ADODB.Recordset
            If cmbDistrict.Text = "" Then
                txtDistrict.Text = ""
                rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD,A.CMGRP, B.CDACD AS CDACD, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "'AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            Else
                rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD,A.CMGRP, B.CDACD AS CDACD, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "'and  A.DISTCD = '" & txtDistrict.Text & "' AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            End If

            dgCustomer.Rows.Clear()
            If rs.RecordCount > 0 Then
                For I As Integer = 1 To rs.RecordCount
                    Dim row As DataGridViewRow = dgCustomer.Rows(dgCustomer.Rows.Add)
                    row.Cells(colCustomerCode.Index).Value = rs.Fields("CustomerCD").Value

                    row.Cells(colShiptoCode.Index).Value = rs.Fields("cdacd").Value
                    row.Cells(colShiptoName.Index).Value = rs.Fields("cdaname").Value
                    row.Cells(ShipToAddress1.Index).Value = rs.Fields("CDACADD1").Value
                    row.Cells(ShipToAddress2.Index).Value = rs.Fields("CDACADD2").Value
                    row.Cells(colRegion.Index).Value = rs.Fields("REGCD").Value
                    row.Cells(colProvince.Index).Value = rs.Fields("DISTCD").Value
                    row.Cells(colMunicipality.Index).Value = rs.Fields("AREACD").Value
                    row.Cells(colZipCode.Index).Value = rs.Fields("ZIPCD").Value
                    row.Cells(colCustomerGroup.Index).Value = rs.Fields("CMGRP").Value


                    'edited may 31 2010 

                    row.Cells(colRegionDesc.Index).Value = GetRegionDesc(rs.Fields("RegCD").Value)
                    row.Cells(colProvinceDesc.Index).Value = GetDistrictDesc(rs.Fields("RegCD").Value, rs.Fields("Distcd").Value)
                    row.Cells(colMunicipalityDesc.Index).Value = GetAreaDesc(rs.Fields("RegCD").Value, rs.Fields("DistCD").Value, rs.Fields("AreaCd").Value)

                    rs.MoveNext()
                Next
            End If
        ElseIf sender Is cmbRegion Then

            Dim rs As New ADODB.Recordset
            rs.Open("SELECT * FROM REGION WHERE REGNAME = '" & cmbRegion.Text & "' and dltflg = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
            If rs.RecordCount > 0 Then
                txtRegion.Text = rs.Fields("regCD").Value
            End If
            cmbDistrict.Items.Clear()
            cmbMunicipality.Items.Clear()
            cmbzipCode.Items.Clear()

            txtDistrict.Text = ""
            txtArea.Text = ""



            rs = New ADODB.Recordset
            rs.Open("select * from district where regCD = '" & txtRegion.Text & "' and dltflg = 0 order by distrctcd", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                cmbDistrict.Items.Add("")
                For i As Integer = 1 To rs.RecordCount
                    cmbDistrict.Items.Add(rs.Fields("distrctNAME").Value)
                    rs.MoveNext()
                Next
            End If

            rs = New ADODB.Recordset
            If cmbRegion.Text = "" Then
                txtRegion.Text = ""
                rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD, A.CMGRP,B.CDACD AS CDACD, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'AND A.customerdel = 0 AND A.CUSTOMERDEL = 0  ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            Else
                rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD, A.CMGRP,B.CDACD AS CDACD, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "' AND A.customerdel = 0 AND A.CUSTOMERDEL = 0  ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            End If
            dgCustomer.Rows.Clear()
            If rs.RecordCount > 0 Then
                For I As Integer = 1 To rs.RecordCount
                    Dim row As DataGridViewRow = dgCustomer.Rows(dgCustomer.Rows.Add)
                    row.Cells(colCustomerCode.Index).Value = rs.Fields("CustomerCD").Value

                    row.Cells(colShiptoCode.Index).Value = rs.Fields("cdacd").Value
                    row.Cells(colShiptoName.Index).Value = rs.Fields("cdaname").Value
                    row.Cells(ShipToAddress1.Index).Value = rs.Fields("CDACADD1").Value
                    row.Cells(ShipToAddress2.Index).Value = rs.Fields("CDACADD2").Value
                    row.Cells(colRegion.Index).Value = rs.Fields("REGCD").Value
                    row.Cells(colProvince.Index).Value = rs.Fields("DISTCD").Value
                    row.Cells(colMunicipality.Index).Value = rs.Fields("AREACD").Value
                    row.Cells(colZipCode.Index).Value = rs.Fields("ZIPCD").Value
                    row.Cells(colCustomerGroup.Index).Value = rs.Fields("CMGRP").Value


                    'edited may 31 2010 

                    row.Cells(colRegionDesc.Index).Value = GetRegionDesc(rs.Fields("RegCD").Value)
                    row.Cells(colProvinceDesc.Index).Value = GetDistrictDesc(rs.Fields("RegCD").Value, rs.Fields("Distcd").Value)
                    row.Cells(colMunicipalityDesc.Index).Value = GetAreaDesc(rs.Fields("RegCD").Value, rs.Fields("DistCD").Value, rs.Fields("AreaCd").Value)

                    rs.MoveNext()
                Next
            End If

        ElseIf sender Is cmbzipCode Then
            Dim rs As New ADODB.Recordset
            rs.Open("SELECT * FROM ZIPCODE WHERE DLTFLG = 0  AND ZIPCD = '" & cmbzipCode.Text & "' AND AREACD = '" & cmbMunicipality.Text & "' AND REGCD = '" & cmbRegion.Text & "' AND DISTRCTCD = '" & cmbDistrict.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                'txtZipCode.Text = rs.Fields("AREANAME").Value
            End If
            rs = New ADODB.Recordset
            If cmbzipCode.Text = "" Then

                rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD,A.CMGRP, B.CDACD AS CDACD, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "'and  A.DISTCD = '" & txtDistrict.Text & "'AND A.AREACD = '" & txtArea.Text & "'AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            Else
                rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD,A.CMGRP, B.CDACD AS CDACD, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "'and  A.DISTCD = '" & txtDistrict.Text & "'AND A.AREACD = '" & txtArea.Text & "'AND A.ZIPCD = '" & cmbzipCode.Text & "' AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            End If
            dgCustomer.Rows.Clear()
            If rs.RecordCount > 0 Then
                For I As Integer = 1 To rs.RecordCount
                    Dim row As DataGridViewRow = dgCustomer.Rows(dgCustomer.Rows.Add)
                    row.Cells(colCustomerCode.Index).Value = rs.Fields("CustomerCD").Value

                    row.Cells(colShiptoCode.Index).Value = rs.Fields("cdacd").Value
                    row.Cells(colShiptoName.Index).Value = rs.Fields("cdaname").Value
                    row.Cells(ShipToAddress1.Index).Value = rs.Fields("CDACADD1").Value
                    row.Cells(ShipToAddress2.Index).Value = rs.Fields("CDACADD2").Value
                    row.Cells(colRegion.Index).Value = rs.Fields("REGCD").Value
                    row.Cells(colProvince.Index).Value = rs.Fields("DISTCD").Value
                    row.Cells(colMunicipality.Index).Value = rs.Fields("AREACD").Value
                    row.Cells(colZipCode.Index).Value = rs.Fields("ZIPCD").Value
                    row.Cells(colCustomerGroup.Index).Value = rs.Fields("CMGRP").Value


                    'edited may 31 2010 

                    row.Cells(colRegionDesc.Index).Value = GetRegionDesc(rs.Fields("RegCD").Value)
                    row.Cells(colProvinceDesc.Index).Value = GetDistrictDesc(rs.Fields("RegCD").Value, rs.Fields("Distcd").Value)
                    row.Cells(colMunicipalityDesc.Index).Value = GetAreaDesc(rs.Fields("RegCD").Value, rs.Fields("DistCD").Value, rs.Fields("AreaCd").Value)

                    rs.MoveNext()
                Next
            End If
        End If

    End Sub

    Private Sub ucAdministrationCustomerMapping_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(GridListing)
        ApplyGridTheme(dgCustomer)
        ApplyGridTheme(dgMunicipality)
        OpenListing()
        PopulateCombo()
        Operation = "Add"
        SetupOperation(True)
    End Sub

    Private Sub cmbCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cmbRegion.Text = ""
        cmbDistrict.Text = ""
        cmbMunicipality.Text = ""
        cmbzipCode.Text = ""

        txtRegion.Text = ""
        txtDistrict.Text = ""
        txtArea.Text = ""


    End Sub

    'Private Sub llTerritory_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llTerritory.LinkClicked
    '    Dim Find As New AdministrationCustomerMappingSearchTerritory
    '    Find.PopulateGrid()
    '    Find.ShowDialog()

    '    If Find.ReturnTerrCode = "" Then
    '    ElseIf Find.ReturnTerrName = "" Then
    '    Else
    '        'txtTerritory.Text = Find.ReturnTerrCode
    '        txtTerritoryCode.Text = Find.ReturnTerrCode
    '        txtTerritory.Text = Find.ReturnTerrName
    '    End If
    'End Sub

    Private Sub llCheckAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCheckAll.LinkClicked
        For I As Integer = 0 To dgCustomer.Rows.Count - 1
            Dim row As DataGridViewRow = dgCustomer.Rows(I)
            row.Cells(colSelect.Index).Value = True

        Next
    End Sub

    'Private Sub llUncheck_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llUncheck.LinkClicked
    '    For i As Integer = 0 To dgCustomer.Rows.Count - 1
    '        Dim row As DataGridViewRow = dgCustomer.Rows(i)
    '        row.Cells(colSelect.Index).Value = False
    '    Next
    'End Sub



    Private Sub buttonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click, btnEdit.Click, btnDelete.Click, btnSave.Click, btnClose.Click
        If sender Is btnAdd Then
            Operation = "Add"
            SetupOperation(True)
            ClearForm()
            dgMunicipality.Rows.Clear()
        ElseIf sender Is btnEdit Then
            Operation = "Edit"
            SetupOperation(True)

        ElseIf sender Is btnDelete Then
            If ValidFields() = False Then
                InvalidValues()
            Else
                DELETERecord()
                Operation = ""
                SetupOperation(False)
                DeleteSuccess()
                OpenListing()
            End If
        ElseIf sender Is btnSave Then
            If ValidFields() = False Then
                InvalidValues()
            ElseIf Operation = "Add" Then
                SaveRecord()
                Operation = ""
                SetupOperation(False)
                SaveSuccess()
                OpenListing()
            ElseIf Operation = "Edit" Then
                UPdateRecord()
                Operation = ""
                SetupOperation(False)
                SaveSuccess()
            End If
        ElseIf sender Is btnClose Then
            On Error Resume Next
            Dim m_TabPage As TabPage = Me.Parent
            CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
            Me.Dispose()
        End If

    End Sub

    Private Sub SetupOperation(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation

    End Sub

    Private Function ValidFields() As Boolean
        m_HasError = False
        m_Err.Clear()
        'If cmbCompany.Text = "" Then
        'Return False
        'ElseIf cmbCustomerCode.Text = "" Then
        '    Return False
        'ElseIf txtTerritoryCode.Text = "" Then
        'Return False

        If CDate(dtStart.Value.ToShortDateString) > CDate(dtEnd.Value.ToShortDateString) Then
            m_Err.SetError(dtStart, "Date From Should not be greater than date to.")
            m_HasError = True
        End If

        If dgCustomer.Rows.Count = 0 Then
            Return False
        Else
            Dim Test As Boolean = False
            For i As Integer = 0 To dgCustomer.Rows.Count - 1
                Dim row As DataGridViewRow = dgCustomer.Rows(i)

                If row.Cells(colSelect.Index).Value = True Then
                    Test = True
                    Exit For
                End If

            Next

            If Test = True Then
                Return True
            Else
                Return False
            End If
        End If
    End Function


    Private Sub ClearForm()
        PopulateCombo()

        txtArea.Text = ""
        txtCompany.Text = ""
        txtCustomerCode.Text = ""
        txtDistrict.Text = ""
        txtRegion.Text = ""
        txtTerritory.Text = ""
        txtTerritoryCode.Text = ""
        m_Err.Clear()
        dgCustomer.Rows.Clear()
    End Sub

    Private Function SaveRecord() As Boolean
        ' SPMSConn.Execute("UPDATE CUSTOMER SET TERRCD = '" & txtTerritoryCode.Text & "' WHERE CUSTOMERCD = '" & CustomerCode & "' AND COMID = '" & cmbCompany.Text & "' ")
        ' SPMSConn.Execute("INSERT INTO CUSTOMERMAPPINGVALUES ( '" & cmbCustomerCode.Text & "' , '" & cmbRegion.Text & "' , '" & cmbDistrict.Text & "' , '" & cmbMunicipality.Text & "' ,  '" & cmbZipcode.Text & "' , '" & CustomerCode & "' , '" & txtTerritoryCode.Text & "' , 0)")
        For i As Integer = 0 To dgCustomer.Rows.Count - 1
            Dim row As DataGridViewRow = dgCustomer.Rows(i)
            If row.Cells(colSelect.Index).Value = True Then
                SPMSConn.Execute("EXECUTE USPCUSTOMERMAPPING @ACTION = 'ADD', @customergroupcd = '" & row.Cells(colCustomerGroup.Index).Value & "' , @regcd = '" & row.Cells(colRegion.Index).Value & "' , @Distrctcd = '" & row.Cells(colProvince.Index).Value & "' , @AreaCD = '" & row.Cells(colMunicipality.Index).Value & "' , @zipCD = '" & row.Cells(colZipCode.Index).Value & "' , @CustomerCD = '" & row.Cells(colCustomerCode.Index).Value & "' , @AREACOVRG = '" & txtTerritoryCode.Text & "' , @dltflg = 0 , @COMID = '" & row.Cells(colCompanyCode.Index).Value & "' , @CDACD = '" & row.Cells(colShiptoCode.Index).Value & "' , @CDANAME = '" & HandleSingleQuoteInSql(row.Cells(colShiptoName.Index).Value) & "', @EffectivityStartDate = '" & dtStart.Value.ToShortDateString & "' , @EffectivityEndDate = '" & dtEnd.Value.ToShortDateString & "' , @IsActive = " & chkIsActive.Checked & ",@TRANSACTIONTYPE='0' ")

            End If
        Next

    End Function

    Private Function UPdateRecord() As Boolean
        ' SPMSConn.Execute("UPDATE CUSTOMER SET TERRCD = '" & txtTerritoryCode.Text & "' WHERE CUSTOMERCD = '" & CustomerCode & "' AND COMID = '" & cmbCompany.Text & "' ")
        ' SPMSConn.Execute("INSERT INTO CUSTOMERMAPPINGVALUES ( '" & cmbCustomerCode.Text & "' , '" & cmbRegion.Text & "' , '" & cmbDistrict.Text & "' , '" & cmbMunicipality.Text & "' ,  '" & cmbZipcode.Text & "' , '" & CustomerCode & "' , '" & txtTerritoryCode.Text & "' , 0)")
        For i As Integer = 0 To dgCustomer.Rows.Count - 1
            Dim row As DataGridViewRow = dgCustomer.Rows(i)
            If row.Cells(colSelect.Index).Value = True Then
                SPMSConn.Execute("EXECUTE USPCUSTOMERMAPPING @ACTION = 'UPDATE', @customergroupcd = '" & row.Cells(colCustomerGroup.Index).Value & "' , @regcd = '" & row.Cells(colRegion.Index).Value & "' , @Distrctcd = '" & row.Cells(colProvince.Index).Value & "' , @AreaCD = '" & row.Cells(colMunicipality.Index).Value & "' , @zipCD = '" & row.Cells(colZipCode.Index).Value & "' , @CustomerCD = '" & row.Cells(colCustomerCode.Index).Value & "' , @AREACOVRG = '" & txtTerritoryCode.Text & "' , @dltflg = 0 , @COMID = '" & row.Cells(colCompanyCode.Index).Value & "' , @CDACD = '" & row.Cells(colShiptoCode.Index).Value & "' , @CDANAME = '" & HandleSingleQuoteInSql(row.Cells(colShiptoName.Index).Value) & "', @ID = '" & row.Cells(colID.Index).Value & "' , @EffectivityStartDate = '" & dtStart.Value.ToShortDateString & "' , @EffectivityEndDate = '" & dtEnd.Value.ToShortDateString & "' , @IsActive = " & chkIsActive.Checked & ",@TRANSACTIONTYPE='0'")
            End If
        Next
    End Function

    Private Function DELETERecord() As Boolean
        ' SPMSConn.Execute("UPDATE CUSTOMER SET TERRCD = '" & txtTerritoryCode.Text & "' WHERE CUSTOMERCD = '" & CustomerCode & "' AND COMID = '" & cmbCompany.Text & "' ")
        ' SPMSConn.Execute("INSERT INTO CUSTOMERMAPPINGVALUES ( '" & cmbCustomerCode.Text & "' , '" & cmbRegion.Text & "' , '" & cmbDistrict.Text & "' , '" & cmbMunicipality.Text & "' ,  '" & cmbZipcode.Text & "' , '" & CustomerCode & "' , '" & txtTerritoryCode.Text & "' , 0)")
        For i As Integer = 0 To dgCustomer.Rows.Count - 1
            Dim row As DataGridViewRow = dgCustomer.Rows(i)
            If row.Cells(colSelect.Index).Value = True Then
                SPMSConn.Execute("EXECUTE USPCUSTOMERMAPPING @ACTION = 'DELETE', @ID = " & row.Cells(colID.Index).Value & ", @dltflg = 1 ")
            End If
        Next
    End Function

    Private Sub OpenListing()
        Dim Gridrs As New ADODB.Recordset
        If Gridrs.State = 1 Then Gridrs.Close()
        Gridrs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Gridrs.Open("select distinct(areacovrg),comid,effectivitystartdate, effectivityenddate, isactive from customermapping WHERE DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        GridListing.Rows.Clear()
        If Gridrs.RecordCount > 0 Then

            For i As Integer = 1 To Gridrs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(ChannelCode.Index).Value = Gridrs.Fields("COMID").Value
                row.Cells(AreaCoverageCode.Index).Value = Gridrs.Fields("AREACOVRG").Value
                row.Cells(colStartDate.Index).Value = Gridrs.Fields("EffectivityStartDate").Value
                row.Cells(colEndDate.Index).Value = Gridrs.Fields("EffectivityEndDate").Value
                row.Cells(colStatus.Index).Value = IIf(Gridrs.Fields("IsActive").Value = True, "Active", "Inactive")
                Dim rsAreaCoverage As New ADODB.Recordset
                If rsAreaCoverage.State = 1 Then rsAreaCoverage.Close()
                rsAreaCoverage.Open("Select STACOVNAME FROM STAREACOVERAGE WHERE STACOVCD = '" & Gridrs.Fields("AREACOVRG").Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rsAreaCoverage.RecordCount <> 0 Then
                    row.Cells(AreaCoverageName.Index).Value = rsAreaCoverage.Fields("STACOVNAME").Value
                End If
                Gridrs.MoveNext()
            Next
        End If
    End Sub


    Private Sub GridListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick

        If e.RowIndex >= 0 Then
            Dim active As Integer = 1

            ClearForm()
            Dim rowCustomerMappping As DataGridViewRow = GridListing.Rows(e.RowIndex)
            Dim rs As New ADODB.Recordset
            active = IIf(rowCustomerMappping.Cells(colStatus.Index).Value = "Active", 1, 0)
            rs.Open("SELECT * FROM CUSTOMERMAPPING WHERE EffectivityStartDate = '" & rowCustomerMappping.Cells(colStartDate.Index).Value & "' AND EffectivityEndDate = '" & rowCustomerMappping.Cells(colEndDate.Index).Value & "' AND  COMID = '" & rowCustomerMappping.Cells(ChannelCode.Index).Value & "' AND AREACOVRG = '" & rowCustomerMappping.Cells(AreaCoverageCode.Index).Value & "' AND  DLTFLG = 0 AND ISACTIVE = " & active, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            dgCustomer.Rows.Clear()
            If rs.RecordCount > 0 Then
                For I As Integer = 1 To rs.RecordCount
                    Dim row As DataGridViewRow = dgCustomer.Rows(dgCustomer.Rows.Add)

                    row.Cells(colCustomerCode.Index).Value = rs.Fields("CustomerCD").Value

                    row.Cells(colShiptoCode.Index).Value = rs.Fields("cdacd").Value
                    row.Cells(colShiptoName.Index).Value = rs.Fields("cdaname").Value
                    Dim rsCustomerShipTo As New ADODB.Recordset
                    rsCustomerShipTo.Open("SELECT CDACADD1,CDACADD2 FROM CUSTOMERSHIPTO WHERE CUSTOMERCD = '" & rs.Fields("CustomerCD").Value & "' AND CDACD = '" & rs.Fields("cdacd").Value & "' AND COMID = '" & rowCustomerMappping.Cells(ChannelCode.Index).Value & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    If rsCustomerShipTo.RecordCount > 0 Then
                        row.Cells(ShipToAddress1.Index).Value = rsCustomerShipTo.Fields("CDACADD1").Value
                    Else
                        row.Cells(ShipToAddress1.Index).Value = ""
                    End If
                    If rsCustomerShipTo.RecordCount > 0 Then
                        row.Cells(ShipToAddress1.Index).Value = rsCustomerShipTo.Fields("CDACADD2").Value
                    Else
                        row.Cells(ShipToAddress1.Index).Value = ""
                    End If
                    'row.Cells(ShipToAddress2.Index).Value = rsCustomerShipTo.Fields("CDACADD2").Value

                    row.Cells(colRegion.Index).Value = rs.Fields("REGCD").Value

                    row.Cells(colRegionDesc.Index).Value = GetRegionDesc(rs.Fields("REGCD").Value)


                    row.Cells(colProvince.Index).Value = rs.Fields("DISTRCTCD").Value

                    row.Cells(colProvinceDesc.Index).Value = GetDistrictDesc(rs.Fields("REGCD").Value, rs.Fields("DISTRCTCD").Value)

                    row.Cells(colMunicipality.Index).Value = rs.Fields("AREACD").Value

                    row.Cells(colMunicipalityDesc.Index).Value = GetAreaDesc(rs.Fields("REGCD").Value, rs.Fields("DISTRCTCD").Value, rs.Fields("AREACD").Value)

                    row.Cells(colZipCode.Index).Value = rs.Fields("ZIPCD").Value
                    row.Cells(colCustomerGroup.Index).Value = rs.Fields("CUSTOMERGROUPCD").Value
                    row.Cells(colID.Index).Value = rs.Fields("CustomerMappingID").Value




                    'edited june 3 2010
                    row.Cells(colCompanyCode.Index).Value = rs.Fields("COMID").Value

                    rs.MoveNext()

                Next
            End If
            txtTerritoryCode.Text = rowCustomerMappping.Cells(AreaCoverageCode.Index).Value
            txtTerritory.Text = rowCustomerMappping.Cells(AreaCoverageName.Index).Value

            dtStart.Value = rowCustomerMappping.Cells(colStartDate.Index).Value
            dtEnd.Value = rowCustomerMappping.Cells(colEndDate.Index).Value
            chkIsActive.Checked = IIf(rowCustomerMappping.Cells(colStatus.Index).Value = "Active", True, False)

            'cmbCompany.Text = rowCustomerMappping.Cells(ChannelCode.Index).Value
            dgMunicipality.Rows.Clear()
            SetupOperation(False)
            MainTab.SelectTab(0)
            Operation = ""
        End If
    End Sub

    

    Private Sub lblCheckAllMunicipality_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblCheckAllMunicipality.LinkClicked
        dgCustomer.Rows.Clear()
        For I As Integer = 0 To dgMunicipality.Rows.Count - 1
            Dim row As DataGridViewRow = dgMunicipality.Rows(I)
            row.Cells(colSelect.Index).Value = True

        Next
        'For i As Integer = 0 To dgMunicipality.Rows.Count - 1
        '    Dim rowCustomer As DataGridViewRow = dgMunicipality.Rows(i)
        '    If rowCustomer.Cells(colSelect.Index).Value = True Then
        '        Dim rs As New ADODB.Recordset
        '        rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD, A.CMGRP,B.CDACD AS CDACD, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "'and  A.DISTCD = '" & txtDistrict.Text & "'AND A.AREACD = '" & rowCustomer.Cells(MunicipalityCode.Index).Value & "' AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        '        'dgCustomer.Rows.Clear()
        '        If rs.RecordCount > 0 Then
        '            For j As Integer = 1 To rs.RecordCount
        '                Dim row As DataGridViewRow = dgCustomer.Rows(dgCustomer.Rows.Add)
        '                row.Cells(colCustomerCode.Index).Value = rs.Fields("CustomerCD").Value

        '                row.Cells(colShiptoCode.Index).Value = rs.Fields("cdacd").Value
        '                row.Cells(colShiptoName.Index).Value = rs.Fields("cdaname").Value
        '                row.Cells(ShipToAddress1.Index).Value = rs.Fields("CDACADD1").Value
        '                row.Cells(ShipToAddress2.Index).Value = rs.Fields("CDACADD2").Value
        '                row.Cells(colRegion.Index).Value = rs.Fields("REGCD").Value
        '                row.Cells(colProvince.Index).Value = rs.Fields("DISTCD").Value
        '                row.Cells(colMunicipality.Index).Value = rs.Fields("AREACD").Value
        '                row.Cells(colZipCode.Index).Value = rs.Fields("ZIPCD").Value
        '                row.Cells(colCustomerGroup.Index).Value = rs.Fields("CMGRP").Value
        '                rs.MoveNext()
        '            Next
        '        End If
        '    End If
        'Next
        PopulateRsCustomer(RsCustomer)
    End Sub

    Private Sub lblCheckUncheckAllMunicipality_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblCheckUncheckAllMunicipality.LinkClicked
        dgCustomer.Rows.Clear()
        For I As Integer = 0 To dgMunicipality.Rows.Count - 1
            Dim row As DataGridViewRow = dgMunicipality.Rows(I)
            row.Cells(colSelect.Index).Value = False

        Next

    End Sub


    Private Sub dgMunicipality_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMunicipality.CellEndEdit
        Dim rowa As DataGridViewRow = dgMunicipality.Rows(e.RowIndex)
        If e.ColumnIndex = check.Index Then

            dgCustomer.Rows.Clear()
            PopulateRsCustomer(RsCustomer)
            'For i As Integer = 0 To dgMunicipality.Rows.Count - 1
            '    Dim rowCustomer As DataGridViewRow = dgMunicipality.Rows(i)
            '    If rowCustomer.Cells(colSelect.Index).Value = True Then
            '        Dim rs As New ADODB.Recordset
            '        rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD, A.CMGRP,B.CDACD AS CDACD, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2  FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "'and  A.DISTCD = '" & txtDistrict.Text & "'AND A.AREACD = '" & rowCustomer.Cells(MunicipalityCode.Index).Value & "' AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            '        '
            '        If rs.RecordCount > 0 Then
            '            For j As Integer = 1 To rs.RecordCount
            '                Dim row As DataGridViewRow = dgCustomer.Rows(dgCustomer.Rows.Add)
            '                row.Cells(colCustomerCode.Index).Value = rs.Fields("CustomerCD").Value

            '                row.Cells(colShiptoCode.Index).Value = rs.Fields("cdacd").Value
            '                row.Cells(colShiptoName.Index).Value = rs.Fields("cdaname").Value
            '                row.Cells(ShipToAddress1.Index).Value = rs.Fields("CDACADD1").Value
            '                row.Cells(ShipToAddress2.Index).Value = rs.Fields("CDACADD2").Value
            '                row.Cells(colRegion.Index).Value = rs.Fields("REGCD").Value
            '                row.Cells(colProvince.Index).Value = rs.Fields("DISTCD").Value
            '                row.Cells(colMunicipality.Index).Value = rs.Fields("AREACD").Value
            '                row.Cells(colZipCode.Index).Value = rs.Fields("ZIPCD").Value
            '                row.Cells(colCustomerGroup.Index).Value = rs.Fields("CMGRP").Value


            '                'edited may 31 2010 

            '                row.Cells(colRegionDesc.Index).Value = GetRegionDesc(rs.Fields("RegCD").Value)
            '                row.Cells(colProvinceDesc.Index).Value = GetDistrictDesc(rs.Fields("RegCD").Value, rs.Fields("Distcd").Value)
            '                row.Cells(colMunicipalityDesc.Index).Value = GetAreaDesc(rs.Fields("RegCD").Value, rs.Fields("DistCD").Value, rs.Fields("AreaCd").Value)
            '                rs.MoveNext()
            '            Next
            '        End If
            '    End If
            'Next
        End If
    End Sub

  
   
    Private Sub llTerritory_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llTerritory.LinkClicked
        Dim Find As New AdministrationCustomerMappingSearchTerritory
        Find.PopulateGrid()
        Find.ShowDialog()

        If Find.ReturnTerrCode = "" Then
        ElseIf Find.ReturnTerrName = "" Then
        Else
            'txtTerritory.Text = Find.ReturnTerrCode
            txtTerritoryCode.Text = Find.ReturnTerrCode
            txtTerritory.Text = Find.ReturnTerrName
        End If
    End Sub

    Private Function GetRegionDesc(ByVal RegionCode As String) As String
        Dim rs As New ADODB.Recordset
        rs.Open("select * from region where regcd = '" & RegionCode & "' and dltflg = 0  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return rs.Fields("RegName").Value
        Else
            Return ""
        End If
    End Function

    Private Function GetDistrictDesc(ByVal RegionCode As String, ByVal DistrictCode As String) As String
        Dim rs As New ADODB.Recordset
        rs.Open("select * from District where regcd = '" & RegionCode & "' and DistrctCD = '" & DistrictCode & "' and dltflg = 0  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


        If rs.RecordCount > 0 Then
            Return rs.Fields("DistrctName").Value
        Else
            Return ""
        End If
    End Function

    Private Function GetAreaDesc(ByVal RegionCode As String, ByVal DistrictCode As String, ByVal AreaCode As String) As String
        Dim rs As New ADODB.Recordset
        rs.Open("SELECT * FROM AREA WHERE REGCD = '" & RegionCode & "' AND DISTRCTCD = '" & DistrictCode & "' AND AREACD = '" & AreaCode & "' AND DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.RecordCount > 0 Then
            Return rs.Fields("AreaName").Value
        Else
            Return ""
        End If
    End Function
    Private Function GetZipCode(ByVal RegionCode As String, ByVal DistrictCode As String, ByVal AreaCode As String) As String
        Dim rs As New ADODB.Recordset
        rs.Open("SELECT * FROM ZIPCODE WHERE REGCD = '" & RegionCode & "' AND DISTRCTCD = '" & DistrictCode & "' AND AREACD = '" & AreaCode & "' AND DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.RecordCount > 0 Then
            Return rs.Fields("ZIPCD").Value
        Else
            Return ""
        End If
    End Function

    
   
   
    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub llUncheck_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llUncheck.LinkClicked
        For I As Integer = 0 To dgCustomer.Rows.Count - 1
            Dim row As DataGridViewRow = dgCustomer.Rows(I)
            row.Cells(colSelect.Index).Value = False

        Next
    End Sub


    Private Function RsRegion(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT * FROM REGION WHERE DLTFLG = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function

    Private Function RsDistrict(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT * FROM DISTRICT WHERE DLTFLG  = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs
    End Function


    Private Function RsMunicipality(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT * FROM AREA WHERE DLTFLG = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs
    End Function

    
 

    Private Sub SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerGroup.SelectedValueChanged, cmbMunicipality.SelectedValueChanged, _
             cmbCustomerCode.SelectedValueChanged, cmbCustomerGroup.SelectedValueChanged, cmbDistrict.SelectedValueChanged, cmbRegion.SelectedValueChanged, cmbzipCode.SelectedValueChanged, cmbCompany.SelectedValueChanged

        'If sender Is cmbMunicipality Then
        '    cmbzipCode.Items.Clear()

        '    Dim rs As New ADODB.Recordset
        '    rs.Open("SELECT * FROM AREA WHERE DLTFLG = 0 AND REGCD = '" & txtRegion.Text & "' AND DISTRCTCD = '" & txtDistrict.Text & "' AND AREANAME = '" & cmbMunicipality.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        '    If rs.RecordCount > 0 Then
        '        txtArea.Text = rs.Fields("AREACD").Value
        '    End If

        '    rs = New ADODB.Recordset
        '    rs.Open("select * from zipcode where dltflg = 0 and areacd = '" & txtArea.Text & "'  and regcd = '" & txtRegion.Text & "' and distrctcd = '" & txtDistrict.Text & "' order by zipcd", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        '    cmbzipCode.Items.Add("")
        '    For i As Integer = 1 To rs.RecordCount
        '        cmbzipCode.Items.Add(rs.Fields("zipcd").Value)
        '        rs.MoveNext()
        '    Next
        '    rs = New ADODB.Recordset
        '    If cmbMunicipality.Text = "" Then
        '        txtArea.Text = ""
        '        rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD,A.CMGRP,B.CDACD AS CDACD, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "'and  A.DISTCD = '" & txtDistrict.Text & "'AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        '    Else
        '        rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD,A.CMGRP,B.CDACD AS CDACD, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "'and  A.DISTCD = '" & txtDistrict.Text & "'AND A.AREACD = '" & txtArea.Text & "' AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        '    End If
        '    dgCustomer.Rows.Clear()
        '    If rs.RecordCount > 0 Then
        '        For I As Integer = 1 To rs.RecordCount
        '            Dim row As DataGridViewRow = dgCustomer.Rows(dgCustomer.Rows.Add)
        '            row.Cells(colCustomerCode.Index).Value = rs.Fields("CustomerCD").Value

        '            row.Cells(colShiptoCode.Index).Value = rs.Fields("cdacd").Value
        '            row.Cells(colShiptoName.Index).Value = rs.Fields("cdaname").Value
        '            row.Cells(ShipToAddress1.Index).Value = rs.Fields("CDACADD1").Value
        '            row.Cells(ShipToAddress2.Index).Value = rs.Fields("CDACADD2").Value
        '            row.Cells(colRegion.Index).Value = rs.Fields("REGCD").Value
        '            row.Cells(colProvince.Index).Value = rs.Fields("DISTCD").Value
        '            row.Cells(colMunicipality.Index).Value = rs.Fields("AREACD").Value
        '            row.Cells(colZipCode.Index).Value = rs.Fields("ZIPCD").Value
        '            row.Cells(colCustomerGroup.Index).Value = rs.Fields("CMGRP").Value

        '            'edited may 31 2010 

        '            row.Cells(colRegionDesc.Index).Value = GetRegionDesc(rs.Fields("RegCD").Value)
        '            row.Cells(colProvinceDesc.Index).Value = GetDistrictDesc(rs.Fields("RegCD").Value, rs.Fields("Distcd").Value)
        '            row.Cells(colMunicipalityDesc.Index).Value = GetAreaDesc(rs.Fields("RegCD").Value, rs.Fields("DistCD").Value, rs.Fields("AreaCd").Value)


        '            rs.MoveNext()
        '        Next
        '    End If
        If sender Is cmbCompany Then


            cmbCustomerCode.Items.Clear()
            txtCustomerCode.Text = ""


            Dim rs As New ADODB.Recordset
            rs.Open("SELECT * FROM DISTRIBUTOR WHERE DLTFLG = 0 AND DISTCOMID = '" & cmbCompany.Text & "'  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                txtCompany.Text = rs.Fields("distname").Value
            End If

            'populate the rscustomer
            PopulateRsCustomer(RsCustomer)



            'rs = New ADODB.Recordset
            ''rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, B.CDACD AS CDACD, B.CDANAME AS CDANAME FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD AND  A.CMGRP = '" & cmbCustomerGroup.Text & "' and  A.COMID = '" & cmbCompany.Text & "' AND A.customerdel = 0 AND A.REGCD = '" & cmbRegion.Text & "' AND A.DISTCD  = '" & cmbDistrict.Text & "' AND A.AREACD = '" & cmbMunicipality.Text & "' AND A.CUSTOMERDEL = 0  ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            'If cmbCompany.Text = "" Then
            '    txtCompany.Text = ""
            '    rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, B.CDACD AS CDACD, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD,A.CMGRP, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD AND  A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            'Else
            '    rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, B.CDACD AS CDACD, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD,A.CMGRP, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD AND   A.COMID = '" & cmbCompany.Text & "' AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            'End If
            'dgCustomer.Rows.Clear()
            'If rs.RecordCount > 0 Then
            '    For I As Integer = 1 To rs.RecordCount
            '        Dim row As DataGridViewRow = dgCustomer.Rows(dgCustomer.Rows.Add)
            '        row.Cells(colCustomerCode.Index).Value = rs.Fields("CustomerCD").Value

            '        row.Cells(colShiptoCode.Index).Value = rs.Fields("cdacd").Value
            '        row.Cells(colShiptoName.Index).Value = rs.Fields("cdaname").Value
            '        row.Cells(ShipToAddress1.Index).Value = rs.Fields("CDACADD1").Value
            '        row.Cells(ShipToAddress2.Index).Value = rs.Fields("CDACADD2").Value

            '        row.Cells(colRegion.Index).Value = rs.Fields("REGCD").Value
            '        row.Cells(colProvince.Index).Value = rs.Fields("DISTCD").Value
            '        row.Cells(colMunicipality.Index).Value = rs.Fields("AREACD").Value
            '        row.Cells(colZipCode.Index).Value = rs.Fields("ZIPCD").Value
            '        row.Cells(colCustomerGroup.Index).Value = rs.Fields("CMGRP").Value

            '        'edited may 31 2010 

            '        row.Cells(colRegionDesc.Index).Value = GetRegionDesc(rs.Fields("RegCD").Value)
            '        row.Cells(colProvinceDesc.Index).Value = GetDistrictDesc(rs.Fields("RegCD").Value, rs.Fields("Distcd").Value)
            '        row.Cells(colMunicipalityDesc.Index).Value = GetAreaDesc(rs.Fields("RegCD").Value, rs.Fields("DistCD").Value, rs.Fields("AreaCd").Value)

            '        rs.MoveNext()
            '    Next
            'End If
        ElseIf sender Is cmbCustomerCode Then

            Dim rs As New ADODB.Recordset
            rs.Open("SELECT * FROM CUSTOMER WHERE CUSTOMERCD = '" & cmbCustomerCode.Text & "' AND COMID = '" & cmbCompany.Text & "'  AND  CUSTOMERDEL = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                txtCustomerCode.Text = rs.Fields("CustomerName").Value
            End If
        ElseIf sender Is cmbCustomerGroup Then
            Dim rs As New ADODB.Recordset
            rs.Open("SELECT * FROM CUSTOMERGROUP WHERE DLTFLG = 0 AND CUSTOMERGROUPNAME = '" & cmbCustomerGroup.Text & "' order by CUSTOMERGROUPCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                txtCustomerGroup.Text = rs.Fields("CustomerGroupCD").Value
            End If

            'populate the rscustomer
            PopulateRsCustomer(RsCustomer)




            'rs = New ADODB.Recordset
            'If cmbCustomerGroup.Text = "" Then
            '    txtCustomerGroup.Text = ""
            '    rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD, A.CMGRP,B.CDACD AS CDACD, B.CDANAME,B.CDACADD1,B.CDACADD2 AS CDANAME FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "'and  A.DISTCD = '" & txtDistrict.Text & "'AND A.AREACD = '" & txtArea.Text & "'AND A.ZIPCD = '" & cmbzipCode.Text & "' AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            'Else
            '    rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD, A.CMGRP,B.CDACD AS CDACD, B.CDANAME,B.CDACADD1,B.CDACADD2 AS CDANAME FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "'and  A.DISTCD = '" & txtDistrict.Text & "'AND A.AREACD = '" & txtArea.Text & "'AND A.ZIPCD = '" & cmbzipCode.Text & "'AND A.CMGRP = '" & cmbCustomerGroup.Text & "' AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            'End If

            'dgCustomer.Rows.Clear()
            'If rs.RecordCount > 0 Then
            '    For I As Integer = 1 To rs.RecordCount
            '        Dim row As DataGridViewRow = dgCustomer.Rows(dgCustomer.Rows.Add)
            '        row.Cells(colCustomerCode.Index).Value = rs.Fields("CustomerCD").Value

            '        row.Cells(colShiptoCode.Index).Value = rs.Fields("cdacd").Value
            '        row.Cells(colShiptoName.Index).Value = rs.Fields("cdaname").Value
            '        row.Cells(ShipToAddress1.Index).Value = rs.Fields("CDACADD1").Value
            '        row.Cells(ShipToAddress2.Index).Value = rs.Fields("CDACADD2").Value
            '        row.Cells(colRegion.Index).Value = rs.Fields("REGCD").Value
            '        row.Cells(colProvince.Index).Value = rs.Fields("DISTCD").Value
            '        row.Cells(colMunicipality.Index).Value = rs.Fields("AREACD").Value
            '        row.Cells(colZipCode.Index).Value = rs.Fields("ZIPCD").Value
            '        row.Cells(colCustomerGroup.Index).Value = rs.Fields("CMGRP").Value


            '        'edited may 31 2010 

            '        row.Cells(colRegionDesc.Index).Value = GetRegionDesc(rs.Fields("RegCD").Value)
            '        row.Cells(colProvinceDesc.Index).Value = GetDistrictDesc(rs.Fields("RegCD").Value, rs.Fields("Distcd").Value)
            '        row.Cells(colMunicipalityDesc.Index).Value = GetAreaDesc(rs.Fields("RegCD").Value, rs.Fields("DistCD").Value, rs.Fields("AreaCd").Value)

            '        rs.MoveNext()
            '    Next
        End If
        'ElseIf sender Is cmbDistrict Then
        '    Dim rs As New ADODB.Recordset

        '    cmbMunicipality.Items.Clear()
        '    cmbzipCode.Items.Clear()
        '    txtArea.Text = ""


        '    rs.Open("SELECT * FROM DISTRICT WHERE DLTFLG = 0 AND REGCD = '" & txtRegion.Text & "' AND DISTRCTNAME = '" & cmbDistrict.Text & "'  ORDER BY DISTRCTCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        '    If rs.RecordCount > 0 Then
        '        txtDistrict.Text = rs.Fields("DISTRCTCD").Value
        '        rs.MoveNext()
        '    End If

        '    rs = New ADODB.Recordset
        '    rs.Open("select * from Area where dltflg = 0 and regcd = '" & txtRegion.Text & "' and distrctCD = '" & txtDistrict.Text & "' order by areacd", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        '    cmbMunicipality.Items.Add("")
        '    If rs.RecordCount > 0 Then
        '        For i As Integer = 1 To rs.RecordCount
        '            cmbMunicipality.Items.Add(rs.Fields("areaNAME").Value)
        '            rs.MoveNext()
        '        Next
        '    End If
        '    dgMunicipality.Rows.Clear()
        '    Dim rsMunicipality As New ADODB.Recordset
        '    rsMunicipality.Open("select * from Area where dltflg = 0 and regcd = '" & txtRegion.Text & "' and distrctCD = '" & txtDistrict.Text & "' order by areacd", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        '    If rs.RecordCount > 0 Then
        '        For i As Integer = 1 To rs.RecordCount
        '            Dim row As DataGridViewRow = dgMunicipality.Rows(dgMunicipality.Rows.Add)
        '            row.Cells(MunicipalityCode.Index).Value = rsMunicipality.Fields("AREACD").Value
        '            row.Cells(MunicipalityName.Index).Value = rsMunicipality.Fields("AREANAME").Value
        '            row.Cells(colRegionCode.Index).Value = rsMunicipality.Fields("REGCD").Value
        '            row.Cells(colProvinceCode.Index).Value = rsMunicipality.Fields("DISTRCTCD").Value

        '            row.Cells(colRegionName.Index).Value = GetRegionDesc(rsMunicipality.Fields("RegCD").Value)
        '            row.Cells(colProvinceName.Index).Value = GetDistrictDesc(rsMunicipality.Fields("RegCD").Value, rsMunicipality.Fields("DISTRCTCD").Value)
        '            row.Cells(ZipCode.Index).Value = GetZipCode(rsMunicipality.Fields("RegCD").Value, rsMunicipality.Fields("DISTRCTCD").Value, rsMunicipality.Fields("AREACD").Value)

        '            rsMunicipality.MoveNext()
        '        Next
        '    End If

        '    rs = New ADODB.Recordset
        '    If cmbDistrict.Text = "" Then
        '        txtDistrict.Text = ""
        '        rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD,A.CMGRP, B.CDACD AS CDACD, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "'AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        '    Else
        '        rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD,A.CMGRP, B.CDACD AS CDACD, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "'and  A.DISTCD = '" & txtDistrict.Text & "' AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        '    End If

        '    dgCustomer.Rows.Clear()
        '    If rs.RecordCount > 0 Then
        '        For I As Integer = 1 To rs.RecordCount
        '            Dim row As DataGridViewRow = dgCustomer.Rows(dgCustomer.Rows.Add)
        '            row.Cells(colCustomerCode.Index).Value = rs.Fields("CustomerCD").Value

        '            row.Cells(colShiptoCode.Index).Value = rs.Fields("cdacd").Value
        '            row.Cells(colShiptoName.Index).Value = rs.Fields("cdaname").Value
        '            row.Cells(ShipToAddress1.Index).Value = rs.Fields("CDACADD1").Value
        '            row.Cells(ShipToAddress2.Index).Value = rs.Fields("CDACADD2").Value
        '            row.Cells(colRegion.Index).Value = rs.Fields("REGCD").Value
        '            row.Cells(colProvince.Index).Value = rs.Fields("DISTCD").Value
        '            row.Cells(colMunicipality.Index).Value = rs.Fields("AREACD").Value
        '            row.Cells(colZipCode.Index).Value = rs.Fields("ZIPCD").Value
        '            row.Cells(colCustomerGroup.Index).Value = rs.Fields("CMGRP").Value


        '            'edited may 31 2010 

        '            row.Cells(colRegionDesc.Index).Value = GetRegionDesc(rs.Fields("RegCD").Value)
        '            row.Cells(colProvinceDesc.Index).Value = GetDistrictDesc(rs.Fields("RegCD").Value, rs.Fields("Distcd").Value)
        '            row.Cells(colMunicipalityDesc.Index).Value = GetAreaDesc(rs.Fields("RegCD").Value, rs.Fields("DistCD").Value, rs.Fields("AreaCd").Value)

        '            rs.MoveNext()
        '        Next
        '    End If
        'ElseIf sender Is cmbRegion Then

        '    Dim rs As New ADODB.Recordset
        '    rs.Open("SELECT * FROM REGION WHERE REGNAME = '" & cmbRegion.Text & "' and dltflg = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)
        '    If rs.RecordCount > 0 Then
        '        txtRegion.Text = rs.Fields("regCD").Value
        '    End If
        '    cmbDistrict.Items.Clear()
        '    cmbMunicipality.Items.Clear()
        '    cmbzipCode.Items.Clear()

        '    txtDistrict.Text = ""
        '    txtArea.Text = ""



        '    rs = New ADODB.Recordset
        '    rs.Open("select * from district where regCD = '" & txtRegion.Text & "' and dltflg = 0 order by distrctcd", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        '    If rs.RecordCount > 0 Then
        '        cmbDistrict.Items.Add("")
        '        For i As Integer = 1 To rs.RecordCount
        '            cmbDistrict.Items.Add(rs.Fields("distrctNAME").Value)
        '            rs.MoveNext()
        '        Next
        '    End If

        '    rs = New ADODB.Recordset
        '    If cmbRegion.Text = "" Then
        '        txtRegion.Text = ""
        '        rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD, A.CMGRP,B.CDACD AS CDACD, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'AND A.customerdel = 0 AND A.CUSTOMERDEL = 0  ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        '    Else
        '        rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD, A.CMGRP,B.CDACD AS CDACD, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "' AND A.customerdel = 0 AND A.CUSTOMERDEL = 0  ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        '    End If
        '    dgCustomer.Rows.Clear()
        '    If rs.RecordCount > 0 Then
        '        For I As Integer = 1 To rs.RecordCount
        '            Dim row As DataGridViewRow = dgCustomer.Rows(dgCustomer.Rows.Add)
        '            row.Cells(colCustomerCode.Index).Value = rs.Fields("CustomerCD").Value

        '            row.Cells(colShiptoCode.Index).Value = rs.Fields("cdacd").Value
        '            row.Cells(colShiptoName.Index).Value = rs.Fields("cdaname").Value
        '            row.Cells(ShipToAddress1.Index).Value = rs.Fields("CDACADD1").Value
        '            row.Cells(ShipToAddress2.Index).Value = rs.Fields("CDACADD2").Value
        '            row.Cells(colRegion.Index).Value = rs.Fields("REGCD").Value
        '            row.Cells(colProvince.Index).Value = rs.Fields("DISTCD").Value
        '            row.Cells(colMunicipality.Index).Value = rs.Fields("AREACD").Value
        '            row.Cells(colZipCode.Index).Value = rs.Fields("ZIPCD").Value
        '            row.Cells(colCustomerGroup.Index).Value = rs.Fields("CMGRP").Value


        '            'edited may 31 2010 

        '            row.Cells(colRegionDesc.Index).Value = GetRegionDesc(rs.Fields("RegCD").Value)
        '            row.Cells(colProvinceDesc.Index).Value = GetDistrictDesc(rs.Fields("RegCD").Value, rs.Fields("Distcd").Value)
        '            row.Cells(colMunicipalityDesc.Index).Value = GetAreaDesc(rs.Fields("RegCD").Value, rs.Fields("DistCD").Value, rs.Fields("AreaCd").Value)

        '            rs.MoveNext()
        '        Next
        '    End If

        'ElseIf sender Is cmbzipCode Then
        '    Dim rs As New ADODB.Recordset
        '    rs.Open("SELECT * FROM ZIPCODE WHERE DLTFLG = 0  AND ZIPCD = '" & cmbzipCode.Text & "' AND AREACD = '" & cmbMunicipality.Text & "' AND REGCD = '" & cmbRegion.Text & "' AND DISTRCTCD = '" & cmbDistrict.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        '    If rs.RecordCount > 0 Then
        '        '                txtZipCode.Text = rs.Fields("AREANAME").Value
        '    End If
        '    rs = New ADODB.Recordset
        '    If cmbzipCode.Text = "" Then

        '        rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD,A.CMGRP, B.CDACD AS CDACD, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "'and  A.DISTCD = '" & txtDistrict.Text & "'AND A.AREACD = '" & txtArea.Text & "'AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        '    Else
        '        rs.Open("SELECT A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD,A.CMGRP, B.CDACD AS CDACD, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD  and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "'and  A.DISTCD = '" & txtDistrict.Text & "'AND A.AREACD = '" & txtArea.Text & "'AND A.ZIPCD = '" & cmbzipCode.Text & "' AND A.customerdel = 0 ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        '    End If
        '    dgCustomer.Rows.Clear()
        '    If rs.RecordCount > 0 Then
        '        For I As Integer = 1 To rs.RecordCount
        '            Dim row As DataGridViewRow = dgCustomer.Rows(dgCustomer.Rows.Add)
        '            row.Cells(colCustomerCode.Index).Value = rs.Fields("CustomerCD").Value

        '            row.Cells(colShiptoCode.Index).Value = rs.Fields("cdacd").Value
        '            row.Cells(colShiptoName.Index).Value = rs.Fields("cdaname").Value
        '            row.Cells(ShipToAddress1.Index).Value = rs.Fields("CDACADD1").Value
        '            row.Cells(ShipToAddress2.Index).Value = rs.Fields("CDACADD2").Value
        '            row.Cells(colRegion.Index).Value = rs.Fields("REGCD").Value
        '            row.Cells(colProvince.Index).Value = rs.Fields("DISTCD").Value
        '            row.Cells(colMunicipality.Index).Value = rs.Fields("AREACD").Value
        '            row.Cells(colZipCode.Index).Value = rs.Fields("ZIPCD").Value
        '            row.Cells(colCustomerGroup.Index).Value = rs.Fields("CMGRP").Value


        '            'edited may 31 2010 

        '            row.Cells(colRegionDesc.Index).Value = GetRegionDesc(rs.Fields("RegCD").Value)
        '            row.Cells(colProvinceDesc.Index).Value = GetDistrictDesc(rs.Fields("RegCD").Value, rs.Fields("Distcd").Value)
        '            row.Cells(colMunicipalityDesc.Index).Value = GetAreaDesc(rs.Fields("RegCD").Value, rs.Fields("DistCD").Value, rs.Fields("AreaCd").Value)

        '            rs.MoveNext()
        '        Next
        '    End If
        'End If

    End Sub

    Private Function RsZipCode(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT * FROM ZIPCODE WHERE DLTFLG = 0" & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function

    Private Sub cmbRegion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegion.SelectedIndexChanged, cmbRegionDesc.SelectedIndexChanged, cmbDistrict.SelectedIndexChanged, cmbDistrictDesc.SelectedIndexChanged, cmbMunicipality.SelectedIndexChanged, cmbMunicipalityDesc.SelectedIndexChanged, cmbzipCode.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
        If sender Is cmbRegion Then
            'clear the combo bxo related to this combo box
            cmbDistrict.Items.Clear()
            cmbDistrictDesc.Items.Clear()
            cmbMunicipality.Items.Clear()
            cmbMunicipalityDesc.Items.Clear()
            cmbzipCode.Items.Clear()

            cmbDistrict.Text = ""
            cmbDistrictDesc.Text = ""
            cmbMunicipality.Text = ""
            cmbMunicipalityDesc.Text = ""
            cmbzipCode.Text = ""

            dgCustomer.Rows.Clear()
            rs = RsRegion("RegCD = '" & cmbRegion.Text & "' ")

            If rs.RecordCount > 0 Then
                cmbRegionDesc.Text = rs.Fields("RegName").Value


                'populate the combo box of district
                rs = RsDistrict(" RegCd = '" & cmbRegion.Text & "' ")
                If rs.RecordCount > 0 Then
                    For i As Integer = 1 To rs.RecordCount
                        cmbDistrict.Items.Add(rs.Fields("DistrctCD").Value)
                        cmbDistrictDesc.Items.Add(rs.Fields("distrctname").Value)

                        rs.MoveNext()
                    Next

                    'populate municipality
                    'PopulateMunicipality()

                    'populate the rscustomer
                    PopulateRsCustomer(RsCustomer)

                End If


            End If

        ElseIf sender Is cmbRegionDesc Then

            rs = RsRegion("Regname = '" & cmbRegionDesc.Text & "' ")
            If rs.RecordCount > 0 Then
                cmbRegion.Text = rs.Fields("RegCD").Value
            End If


        ElseIf sender Is cmbDistrict Then
            cmbMunicipality.Items.Clear()
            cmbMunicipalityDesc.Items.Clear()
            cmbzipCode.Items.Clear()

         
            cmbMunicipality.Text = ""
            cmbMunicipalityDesc.Text = ""
            cmbzipCode.Text = ""

            rs = RsDistrict("RegCD = '" & cmbRegion.Text & "' AND DistrctCD = '" & cmbDistrict.Text & "' ")

            If rs.RecordCount > 0 Then
                cmbDistrictDesc.Text = rs.Fields("Distrctname").Value


                rs = RsMunicipality("RegCD = '" & cmbRegion.Text & "' AND DistrctCD = '" & cmbDistrict.Text & "' ")
                If rs.RecordCount > 0 Then
                    For i As Integer = 1 To rs.RecordCount
                        cmbMunicipality.Items.Add(rs.Fields("AreaCd").Value)
                        cmbMunicipalityDesc.Items.Add(rs.Fields("Areaname").Value)
                        rs.MoveNext()
                    Next
                    'populate municipality
                    PopulateMunicipality()

                    'populate the rscustomer
                    PopulateRsCustomer(RsCustomer)
                End If
            End If

        ElseIf sender Is cmbDistrictDesc Then

            rs = RsDistrict("RegCD = '" & cmbRegion.Text & "' AND DistrctName = '" & cmbDistrictDesc.Text & "' ")
            If rs.RecordCount > 0 Then
                cmbDistrict.Text = rs.Fields("DistrctCd").Value
            End If

        ElseIf sender Is cmbMunicipality Then


            cmbzipCode.Items.Clear()


            cmbzipCode.Text = ""

            rs = RsMunicipality("RegCd = '" & cmbRegion.Text & "' AND DistrctCD = '" & cmbDistrict.Text & "' AND AreaCD = '" & cmbMunicipality.Text & "' ")

            If rs.RecordCount > 0 Then
                cmbMunicipalityDesc.Text = rs.Fields("AreaName").Value
                cmbzipCode.Items.Clear()


                cmbzipCode.Text = ""


                rs = RsZipCode("RegCd = '" & cmbRegion.Text & "' AND DistrctCD = '" & cmbDistrict.Text & "' AND AreaCD = '" & cmbMunicipality.Text & "' ")
                If rs.RecordCount > 0 Then
                    For i As Integer = 1 To rs.RecordCount
                        cmbzipCode.Items.Add(rs.Fields("Zipcd").Value)
                        rs.MoveNext()
                    Next

                    'populate the rscustomer
                    PopulateRsCustomer(RsCustomer)
                End If
            End If
        ElseIf sender Is cmbMunicipalityDesc Then
            rs = RsMunicipality("RegCD = '" & cmbRegion.Text & "' AND DistrctCD = '" & cmbDistrict.Text & "'  AND AreaName = '" & cmbMunicipalityDesc.Text & "' ")
            If rs.RecordCount > 0 Then
                cmbMunicipality.Text = rs.Fields("AreaCD").Value


            End If
        ElseIf sender Is cmbzipCode Then
            PopulateRsCustomer(RsCustomer)

        End If

    End Sub

    Private Function RsCustomer() As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        Dim SQL As String = ""
        If cmbCompany.Text <> "" Then
            SQL = SQL & " AND A.COMID = '" & cmbCompany.Text & "' "
        End If
        If cmbRegion.Text <> "" Then
            SQL = SQL & " AND A.RegCD = '" & cmbRegion.Text & "' "
        End If
        If cmbDistrict.Text <> "" Then
            SQL = SQL & " AND A.DistCD = '" & cmbDistrict.Text & "' "
        End If

        If dgMunicipality.Rows.Count > 0 Then
            Dim ctr As Integer = 0
            For i As Integer = 0 To dgMunicipality.Rows.Count - 1
                Dim row As DataGridViewRow = dgMunicipality.Rows(i)
                If row.Cells(check.Index).Value = True Then
                    ctr += 1
                    Exit For
                End If
            Next
            If ctr > 0 Then
                ctr = 0

                For i As Integer = 0 To dgMunicipality.Rows.Count - 1
                    Dim row As DataGridViewRow = dgMunicipality.Rows(i)
                    If row.Cells(check.Index).Value = True Then
                        If ctr = 0 Then
                            SQL = SQL & " AND A.AreaCD IN ('" & row.Cells(MunicipalityCode.Index).Value & "'"

                            ctr += 1
                        Else
                            SQL = SQL & ",'" & row.Cells(MunicipalityCode.Index).Value & "'"
                        End If
                    End If
                Next
                SQL = SQL & ") "
            ElseIf cmbMunicipality.Text <> "" Then
                SQL = SQL & " AND A.AreaCD = '" & cmbMunicipality.Text & "' "
            End If
        End If

        If cmbzipCode.Text <> "" Then
            SQL = SQL & " AND A.ZIPCD = '" & cmbzipCode.Text & "' "
        End If
        rs.Open("SELECT A.COMID , A.CUSTOMERCD AS CUSTOMERCD, A.CUSTOMERNAME AS CUSTOMERNAME, A.CADD1 AS CADD1, A.CADD2 AS CADD2, A.REGCD,A.DISTCD,A.AREACD,A.ZIPCD,A.CMGRP, B.CDACD AS CDACD, B.CDANAME AS CDANAME,B.CDACADD1,B.CDACADD2 FROM CUSTOMER AS A, CUSTOMERSHIPTO AS B WHERE B.COMID = A.COMID AND B.CUSTOMERCD = A.CUSTOMERCD /* and  A.COMID = '" & cmbCompany.Text & "'and  A.REGCD = '" & txtRegion.Text & "'*/  AND A.customerdel = 0 " & SQL & " ORDER BY A.CUSTOMERCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs
    End Function

    Private Sub PopulateRsCustomer(ByVal Rs As ADODB.Recordset)
        dgCustomer.Rows.Clear()
        If Rs.RecordCount > 0 Then
            For I As Integer = 1 To Rs.RecordCount
                Dim row As DataGridViewRow = dgCustomer.Rows(dgCustomer.Rows.Add)
                row.Cells(colCustomerCode.Index).Value = Rs.Fields("CustomerCD").Value

                row.Cells(colShiptoCode.Index).Value = Rs.Fields("cdacd").Value
                row.Cells(colShiptoName.Index).Value = Rs.Fields("cdaname").Value
                row.Cells(ShipToAddress1.Index).Value = Rs.Fields("CDACADD1").Value
                row.Cells(ShipToAddress2.Index).Value = Rs.Fields("CDACADD2").Value
                row.Cells(colRegion.Index).Value = Rs.Fields("REGCD").Value
                row.Cells(colProvince.Index).Value = Rs.Fields("DISTCD").Value
                row.Cells(colMunicipality.Index).Value = Rs.Fields("AREACD").Value
                row.Cells(colZipCode.Index).Value = Rs.Fields("ZIPCD").Value
                row.Cells(colCustomerGroup.Index).Value = Rs.Fields("CMGRP").Value

                'edited may 31 2010 

                row.Cells(colRegionDesc.Index).Value = GetRegionDesc(Rs.Fields("RegCD").Value)
                row.Cells(colProvinceDesc.Index).Value = GetDistrictDesc(Rs.Fields("RegCD").Value, Rs.Fields("Distcd").Value)
                row.Cells(colMunicipalityDesc.Index).Value = GetAreaDesc(Rs.Fields("RegCD").Value, Rs.Fields("DistCD").Value, Rs.Fields("AreaCd").Value)

                'edited june 3 2010 
                row.Cells(colCompanyCode.Index).Value = Rs.Fields("COMID").Value

                Rs.MoveNext()
            Next
        End If

    End Sub

    Private Sub PopulateMunicipality()
        dgMunicipality.Rows.Clear()
        Dim sql As String = ""
        Dim rs As New ADODB.Recordset
        If cmbRegion.Text <> "" Then
            sql = sql & " and regcd = '" & cmbRegion.Text & "' "
        End If

        If cmbDistrict.Text <> "" Then
            sql = sql & " and Distrctcd = '" & cmbDistrict.Text & "' "
        End If

        rs.Open("select * from Area where dltflg = 0 " & sql & " order by areacd", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim row As DataGridViewRow = dgMunicipality.Rows(dgMunicipality.Rows.Add)
                row.Cells(MunicipalityCode.Index).Value = rs.Fields("AREACD").Value
                row.Cells(MunicipalityName.Index).Value = rs.Fields("AREANAME").Value
                row.Cells(colRegionCode.Index).Value = rs.Fields("REGCD").Value
                row.Cells(colProvinceCode.Index).Value = rs.Fields("DISTRCTCD").Value

                row.Cells(colRegionName.Index).Value = GetRegionDesc(rs.Fields("RegCD").Value)
                row.Cells(colProvinceName.Index).Value = GetDistrictDesc(rs.Fields("RegCD").Value, rs.Fields("DISTRCTCD").Value)
                row.Cells(ZipCode.Index).Value = GetZipCode(rs.Fields("RegCD").Value, rs.Fields("DISTRCTCD").Value, rs.Fields("AREACD").Value)

                rs.MoveNext()
            Next
        End If
    End Sub

    Private Sub cmbCompany_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged

    End Sub

    Private Sub dgMunicipality_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMunicipality.CellContentClick

    End Sub

    Private Sub GridListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick

    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Filter()

    End Sub

    Private Sub Filter()
        Dim rs As New ADODB.Recordset
        If cmbfilter.Text <> "" Then
            If cmbfilter.Text = "All" Then
                rs = RsListing()
            ElseIf cmbfilter.Text = "CompanyID" Then
                rs = RsListing("COMID like '%" & txtFilter.Text & "%' ")
                'ElseIf cmbfilter.Text = "CompanyName" Then
                '    rs = RsListing("")
            ElseIf cmbfilter.Text = "CoverageCode" Then
                rs = RsListing("AreaCovrg like '%" & txtFilter.Text & "%' ")
                'ElseIf cmbfilter.Text = "CoverageName" Then
                '    rs = RsListing("")
            End If

            PopulateListing(rs)
        End If
    End Sub
    Private Sub PopulateListing(ByVal rs As ADODB.Recordset)
        GridListing.Rows.Clear()
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(ChannelCode.Index).Value = rs.Fields("COMID").Value
                row.Cells(AreaCoverageCode.Index).Value = rs.Fields("Areacovrg").Value
                row.Cells(colStartDate.Index).Value = rs.Fields("EffectivityStartDate").Value
                row.Cells(colEndDate.Index).Value = rs.Fields("EffectivityEndDate").Value
                row.Cells(colStatus.Index).Value = IIf(rs.Fields("IsActive").Value = True, "Active", "Inactive")
                row.Cells(AreaCoverageName.Index).Value = RsCoverage("staCovcd = '" & rs.Fields("Areacovrg").Value & "' ").Fields("stacovname").Value
                rs.MoveNext()
            Next
        End If
    End Sub


    Private Function RsListing(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If
        rs.Open("select distinct(areacovrg),comid, EffectivityStartDate, EffectivityEndDate, IsActive from customermapping  WHERE DLTFLG = 0  " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function


    Private Function RsCoverage(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If
        rs.Open("SELECT * FROM STAREACOVERAGE WHERE DLTFLG = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


        Return rs
    End Function

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If AscW(e.KeyChar) = 13 Then
            Filter()
        End If
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub
End Class
