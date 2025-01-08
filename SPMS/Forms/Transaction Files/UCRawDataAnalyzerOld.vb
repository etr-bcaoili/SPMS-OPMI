Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule

Public Class UCRawDataAnalyzerOld

    Private m_RsCustomerNotInSystem As New ADODB.Recordset
    Private m_RsCustomerWithoutTerritory As New ADODB.Recordset
    Private m_RsItemsNotInSystem As New ADODB.Recordset
    Private m_RsDistributor As New ADODB.Recordset
    Private m_RSCustomersWithStateAreaTerritoryProblem As New ADODB.Recordset
    Private m_RsShipToCustomerWithStateAreaTerritoryProblem As New ADODB.Recordset
    Private m_rsUnmappedCustomers As New ADODB.Recordset
    Private m_RsShipToCustomerNotInSystem As New ADODB.Recordset
    Private m_RsCompanyItemsNotInSystem As New ADODB.Recordset
    Private m_RsUnmappedShipToCustomers As New ADODB.Recordset
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False

    Private m_ForDeletes As New ForDeletesCollection
    Private m_WithError As Boolean = False
    Private m_RsMonth As New ADODB.Recordset


    Private Function CheckIfZipCodeExists(ByVal ZipCd As String) As Boolean
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT * FROM ZIPCODE WHERE DLTFLG =0 AND ZIPCD = '" & ZipCd & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function LoadZipCode(ByVal ZipCd As String) As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT * FROM ZIPCODE WHERE DLTFLG =0 AND ZIPCD = '" & ZipCd & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return rs
        Else
            Return Nothing
        End If
    End Function


    Private Sub LoadYear()
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT DISTINCT CAYR FROM CALENDAR  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        cboCalendarYear.Items.Clear()
        For m As Integer = 0 To rs.RecordCount - 1
            cboCalendarYear.Items.Add(rs.Fields("CAYR").Value)
            rs.MoveNext()
        Next
        'Dim yr As Integer = Now.Year()
        'cboCalendarYear.Items.Clear()
        'For m As Integer = yr - 10 To yr + 10
        '    cboCalendarYear.Items.Add(m)
        'Next
    End Sub

    Private Sub LoadMonth(ByVal DistributorCode As String, ByVal Year As String)

        If m_RsMonth.State = 1 Then m_RsMonth.Close()
        m_RsMonth.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsMonth.Open("SELECT * FROM Calendar WHERE COMID = '" & DistributorCode & "' AND CAYR = '" & Year & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsMonth.RecordCount > 0 Then
            cboMonth.Items.Clear()
            txtMonthDescription.Text = ""
            For m As Integer = 0 To m_RsMonth.RecordCount - 1
                cboMonth.Items.Add(m_RsMonth.Fields("CAPN").Value)
                m_RsMonth.MoveNext()
            Next
        End If

    End Sub

    Private Sub LoadUnmappedCustomers()

        If m_rsUnmappedCustomers.State = 1 Then m_rsUnmappedCustomers.Close()
        m_rsUnmappedCustomers.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_rsUnmappedCustomers.Open("EXEC uspAnalysisResult @ACTION = 'UnmappedCustomers', @CompanyCode = '" & cboCompany.Text & "' , @CUTMO = '" & cboMonth.Text & "' , @CUTYEAR = '" & cboCalendarYear.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgUnmappedCustomers.Rows.Clear()

        If m_rsUnmappedCustomers.RecordCount > 0 Then
            m_WithError = True
            If chkUnmapped.Checked Then
                For m As Integer = 0 To m_rsUnmappedCustomers.RecordCount - 1
                    Dim row As DataGridViewRow = dgUnmappedCustomers.Rows(dgUnmappedCustomers.Rows.Add)

                    row.Cells(col5CustomerCode.Index).Value = m_rsUnmappedCustomers.Fields("CustomerCD").Value
                    row.Cells(col5CustomerName.Index).Value = m_rsUnmappedCustomers.Fields("CustomerName").Value
                    row.Cells(col5CustomerAddress1.Index).Value = m_rsUnmappedCustomers.Fields("CADD1").Value
                    row.Cells(col5CustomerAddress2.Index).Value = m_rsUnmappedCustomers.Fields("CADD2").Value

                    row.Cells(col5Region.Index) = New DataGridViewLinkCell
                    row.Cells(col5Region.Index).Value = m_rsUnmappedCustomers.Fields("REGCD").Value
                    row.Cells(col5Region.Index).Tag = m_rsUnmappedCustomers.Fields("REGCD").Value

                    row.Cells(col5Province.Index) = New DataGridViewLinkCell
                    row.Cells(col5Province.Index).Value = m_rsUnmappedCustomers.Fields("DISTCD").Value
                    row.Cells(col5Province.Index).Tag = m_rsUnmappedCustomers.Fields("DISTCD").Value

                    row.Cells(col5Municipality.Index) = New DataGridViewLinkCell
                    row.Cells(col5Municipality.Index).Value = m_rsUnmappedCustomers.Fields("AREACD").Value
                    row.Cells(col5Municipality.Index).Tag = m_rsUnmappedCustomers.Fields("AREACD").Value

                    row.Cells(col5ZipCode.Index) = New DataGridViewLinkCell
                    row.Cells(col5ZipCode.Index).Value = m_rsUnmappedCustomers.Fields("ZIPCD").Value
                    row.Cells(col5ZipCode.Index).Tag = m_rsUnmappedCustomers.Fields("ZIPCD").Value


                    m_rsUnmappedCustomers.MoveNext()
                Next

            End If
        End If

    End Sub

    Private Function GetRegionDescription(ByVal RegionCode As String) As String
        Dim m_RsRegion As New ADODB.Recordset
        If m_RsRegion.State = 1 Then m_RsRegion.Close()
        m_RsRegion.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsRegion.Open("SELECT REGNAME FROM REGION WHERE DLTFLG = 0  AND REGCD = '" & RegionCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsRegion.RecordCount > 0 Then
            Return m_RsRegion.Fields("REGNAME").Value
        Else
            Return ""
        End If
    End Function
    Private Function GetDistrictDescription(ByVal DistrictCode As String, ByVal RegionCode As String) As String
        Dim m_RsDistrict As New ADODB.Recordset
        If m_RsDistrict.State = 1 Then m_RsDistrict.Close()
        m_RsDistrict.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsDistrict.Open("SELECT DISTRCTNAME FROM District WHERE DLTFLG = 0 AND DISTRCTCD = '" & DistrictCode & "' AND REGCD = '" & RegionCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsDistrict.RecordCount > 0 Then
            Return m_RsDistrict.Fields("DISTRCTNAME").Value
        Else
            Return ""
        End If
    End Function
    Private Function GetAreaDescription(ByVal AreaCode As String, ByVal RegionCode As String, ByVal DistrictCode As String) As String
        Dim m_RsArea As New ADODB.Recordset
        If m_RsArea.State = 1 Then m_RsArea.Close()
        m_RsArea.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsArea.Open("SELECT AREANAME FROM AREA WHERE  DLTFLG = 0  AND AREACD = '" & AreaCode & "'  AND REGCD = '" & RegionCode & "'  AND DISTRCTCD  = '" & DistrictCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsArea.RecordCount > 0 Then
            Return m_RsArea.Fields("AREANAME").Value
        Else
            Return ""
        End If

    End Function
    Private Sub LoadShipToCustomersWithStateAreaTerritoryProblem()
        If m_RsShipToCustomerWithStateAreaTerritoryProblem.State = 1 Then m_RsShipToCustomerWithStateAreaTerritoryProblem.Close()
        m_RsShipToCustomerWithStateAreaTerritoryProblem.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsShipToCustomerWithStateAreaTerritoryProblem.Open("EXEC uspAnalysisResult @ACTION = 'ShipToCutomerWithStateAreaTerritoryProblem', @CompanyCode = '" & cboCompany.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgShipToCustomer.Rows.Clear()
        If m_RsShipToCustomerWithStateAreaTerritoryProblem.RecordCount > 0 Then
            m_WithError = True
            If chkShipto.Checked Then
                Dim m_IsRegionEmpty As Boolean = False
                Dim m_IsProvinceEmpty As Boolean = False
                Dim m_IsMunicipalityEmpty As Boolean = False

                For m As Integer = 0 To m_RsShipToCustomerWithStateAreaTerritoryProblem.RecordCount - 1
                    Dim row As DataGridViewRow = dgShipToCustomer.Rows(dgShipToCustomer.Rows.Add)
                    m_IsRegionEmpty = False
                    row.Cells(col6CustomerCode.Index).Value = m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("CUSTOMERCD").Value
                    row.Cells(col6CustName.Index).Value = GetCustomerName(cboCompany.Text, m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("CUSTOMERCD").Value)

                    row.Cells(col6ShipToCode.Index).Value = m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("CDACD").Value
                    row.Cells(col6ShipToName.Index).Value = m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("CDANAME").Value
                    row.Cells(col6CustomerAddress.Index).Value = m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("CDACADD1").Value
                    row.Cells(col6CustomerAddress2.Index).Value = m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("CDACADD2").Value


                    If m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("REGCD").Value = "" Then
                        m_IsRegionEmpty = True
                        row.Cells(col6Region.Index) = New DataGridViewLinkCell
                        row.Cells(col6Region.Index).Value = "Select Region"
                        row.Cells(col6Region.Index).Tag = True
                    Else
                        row.Cells(col6Region.Index) = New DataGridViewTextBoxCell
                        row.Cells(col6Region.Index).Value = m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("REGCD").Value
                        row.Cells(col6RegionName.Index).Value = GetRegionDescription(m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("REGCD").Value)
                        row.Cells(col6Region.Index).Tag = False
                    End If


                    If m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("DISTCD").Value = "" Or m_IsRegionEmpty Then
                        m_IsProvinceEmpty = True
                        row.Cells(col6Province.Index) = New DataGridViewLinkCell
                        row.Cells(col6Province.Index).Value = "Select Province"
                        row.Cells(col6Province.Index).Tag = True
                    Else
                        row.Cells(col6Province.Index) = New DataGridViewTextBoxCell
                        row.Cells(col6Province.Index).Value = m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("DISTCD").Value
                        If Not m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("REGCD").Value = "" Then
                            row.Cells(col6ProvinceName.Index).Value = GetDistrictDescription(m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("DISTCD").Value, m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("REGCD").Value)
                        End If

                        row.Cells(col6Province.Index).Tag = False
                    End If


                    If m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("AREACD").Value = "" Or m_IsRegionEmpty Or m_IsProvinceEmpty Then
                        m_IsMunicipalityEmpty = True
                        row.Cells(col6Municipality.Index) = New DataGridViewLinkCell
                        row.Cells(col6Municipality.Index).Value = "Select Municipality"
                        row.Cells(col6Municipality.Index).Tag = True
                    Else
                        row.Cells(col6Municipality.Index) = New DataGridViewTextBoxCell
                        row.Cells(col6Municipality.Index).Value = m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("AREACD").Value
                        If Not m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("REGCD").Value = "" And Not m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("DISTCD").Value = "" Then
                            row.Cells(col6MunicipalityName.Index).Value = GetAreaDescription(m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("AREACD").Value, m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("REGCD").Value, m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("DISTCD").Value)
                        End If

                        row.Cells(col6Municipality.Index).Tag = False
                    End If


                    If Trim(m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("ZIPCD").Value) = "" Or m_IsRegionEmpty Or m_IsProvinceEmpty Or m_IsMunicipalityEmpty Then
                        row.Cells(col6ZipCode.Index) = New DataGridViewLinkCell
                        row.Cells(col6ZipCode.Index).Value = "Select ZipCode"
                        row.Cells(col6ZipCode.Index).Tag = True
                    Else
                        row.Cells(col6ZipCode.Index) = New DataGridViewTextBoxCell
                        row.Cells(col6ZipCode.Index).Value = m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("ZIPCD").Value
                        row.Cells(col6ZipCode.Index).Tag = False
                    End If

                    m_RsShipToCustomerWithStateAreaTerritoryProblem.MoveNext()
                Next

            End If
        End If

    End Sub


    Private Sub LoadUnmappedShipToCustomers()
        If m_RsUnmappedShipToCustomers.State = 1 Then m_RsUnmappedShipToCustomers.Close()
        m_RsUnmappedShipToCustomers.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsUnmappedShipToCustomers.Open("EXEC uspAnalysisResult @ACTION = 'UnmappedShipToCustomers', @CompanyCode = '" & cboCompany.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgUnmappedShipToCustomers.Rows.Clear()
        If m_RsUnmappedShipToCustomers.RecordCount > 0 Then
            m_WithError = True
            If chkShipto.Checked Then
                Dim m_IsRegionEmpty As Boolean = False
                Dim m_IsProvinceEmpty As Boolean = False
                Dim m_IsMunicipalityEmpty As Boolean = False

                For m As Integer = 0 To m_RsUnmappedShipToCustomers.RecordCount - 1
                    Dim row As DataGridViewRow = dgUnmappedShipToCustomers.Rows(dgUnmappedShipToCustomers.Rows.Add)
                    m_IsRegionEmpty = False
                    row.Cells(col10CustCode.Index).Value = m_RsUnmappedShipToCustomers.Fields("CUSTOMERCD").Value
                    row.Cells(col10CustomerName.Index).Value = GetCustomerName(cboCompany.Text, m_RsUnmappedShipToCustomers.Fields("CUSTOMERCD").Value)

                    row.Cells(col10ShipToCode.Index).Value = m_RsUnmappedShipToCustomers.Fields("CDACD").Value
                    row.Cells(col10ShipToName.Index).Value = m_RsUnmappedShipToCustomers.Fields("CDANAME").Value
                    row.Cells(col10ShipToAddress1.Index).Value = m_RsUnmappedShipToCustomers.Fields("CDACADD1").Value
                    row.Cells(col10ShipToAddress2.Index).Value = m_RsUnmappedShipToCustomers.Fields("CDACADD2").Value


                    If m_RsUnmappedShipToCustomers.Fields("REGCD").Value = "" Then
                        m_IsRegionEmpty = True
                        row.Cells(col10Region.Index) = New DataGridViewLinkCell
                        row.Cells(col10Region.Index).Value = "Select Region"
                        row.Cells(col10Region.Index).Tag = True
                    Else
                        row.Cells(col10Region.Index) = New DataGridViewLinkCell
                        row.Cells(col10Region.Index).Value = m_RsUnmappedShipToCustomers.Fields("REGCD").Value
                        row.Cells(col10RegionName.Index).Value = GetRegionDescription(m_RsUnmappedShipToCustomers.Fields("REGCD").Value)
                        row.Cells(col10Region.Index).Tag = False
                    End If


                    If m_RsUnmappedShipToCustomers.Fields("DISTCD").Value = "" Or m_IsRegionEmpty Then
                        m_IsProvinceEmpty = True
                        row.Cells(col10Province.Index) = New DataGridViewLinkCell
                        row.Cells(col10Province.Index).Value = "Select Province"
                        row.Cells(col10Province.Index).Tag = True
                    Else
                        row.Cells(col10Province.Index) = New DataGridViewLinkCell
                        row.Cells(col10Province.Index).Value = m_RsUnmappedShipToCustomers.Fields("DISTCD").Value
                        If Not m_RsUnmappedShipToCustomers.Fields("REGCD").Value = "" Then
                            row.Cells(col10ProvinceName.Index).Value = GetDistrictDescription(m_RsUnmappedShipToCustomers.Fields("DISTCD").Value, m_RsUnmappedShipToCustomers.Fields("REGCD").Value)
                        End If

                        row.Cells(col10Province.Index).Tag = False
                    End If


                    If m_RsUnmappedShipToCustomers.Fields("AREACD").Value = "" Or m_IsRegionEmpty Or m_IsProvinceEmpty Then
                        m_IsMunicipalityEmpty = True
                        row.Cells(col10Municipality.Index) = New DataGridViewLinkCell
                        row.Cells(col10Municipality.Index).Value = "Select Municipality"
                        row.Cells(col10Municipality.Index).Tag = True
                    Else
                        row.Cells(col10Municipality.Index) = New DataGridViewLinkCell
                        row.Cells(col10Municipality.Index).Value = m_RsUnmappedShipToCustomers.Fields("AREACD").Value
                        If Not m_RsUnmappedShipToCustomers.Fields("REGCD").Value = "" And Not m_RsUnmappedShipToCustomers.Fields("DISTCD").Value = "" Then
                            row.Cells(col10MunicipalityName.Index).Value = GetAreaDescription(m_RsUnmappedShipToCustomers.Fields("AREACD").Value, m_RsUnmappedShipToCustomers.Fields("REGCD").Value, m_RsUnmappedShipToCustomers.Fields("DISTCD").Value)
                        End If

                        row.Cells(col10Municipality.Index).Tag = False
                    End If


                    If Trim(m_RsUnmappedShipToCustomers.Fields("ZIPCD").Value) = "" Or m_IsRegionEmpty Or m_IsProvinceEmpty Or m_IsMunicipalityEmpty Then
                        row.Cells(col10ZipCode.Index) = New DataGridViewLinkCell
                        row.Cells(col10ZipCode.Index).Value = "Select ZipCode"
                        row.Cells(col10ZipCode.Index).Tag = True
                    Else
                        row.Cells(col10ZipCode.Index) = New DataGridViewLinkCell
                        row.Cells(col10ZipCode.Index).Value = m_RsUnmappedShipToCustomers.Fields("ZIPCD").Value
                        row.Cells(col10ZipCode.Index).Tag = False
                    End If

                    m_RsUnmappedShipToCustomers.MoveNext()
                Next

            End If
        End If
    End Sub



    Private Sub LoadCustomersWithStateAreaTerritoryProblem()
        If m_RSCustomersWithStateAreaTerritoryProblem.State = 1 Then m_RSCustomersWithStateAreaTerritoryProblem.Close()
        m_RSCustomersWithStateAreaTerritoryProblem.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RSCustomersWithStateAreaTerritoryProblem.Open("EXEC uspAnalysisResult @ACTION = 'CustomersWithStateAreaTerritoryProblem', @CompanyCode = '" & cboCompany.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgCustomerWithStateAreaTerritory.Rows.Clear()
        If m_RSCustomersWithStateAreaTerritoryProblem.RecordCount > 0 Then
            m_WithError = True
            If chkCustWithStateAreaTerritoryProblem.Checked Then
                Dim m_IsRegionEmpty As Boolean = False
                Dim m_IsProvinceEmpty As Boolean = False
                Dim m_IsMunicipalityEmpty As Boolean = False
                For m As Integer = 0 To m_RSCustomersWithStateAreaTerritoryProblem.RecordCount - 1
                    Dim row As DataGridViewRow = dgCustomerWithStateAreaTerritory.Rows(dgCustomerWithStateAreaTerritory.Rows.Add)
                    m_IsRegionEmpty = False
                    m_IsProvinceEmpty = False
                    m_IsMunicipalityEmpty = False
                    row.Cells(col4CustomerCode.Index).Value = m_RSCustomersWithStateAreaTerritoryProblem.Fields("CustomerCD").Value
                    row.Cells(col4CustomerName.Index).Value = m_RSCustomersWithStateAreaTerritoryProblem.Fields("CustomerName").Value
                    row.Cells(col4CustomerAddress1.Index).Value = m_RSCustomersWithStateAreaTerritoryProblem.Fields("CADD1").Value
                    row.Cells(col4CustomerAddress2.Index).Value = m_RSCustomersWithStateAreaTerritoryProblem.Fields("CADD2").Value


                    If m_RSCustomersWithStateAreaTerritoryProblem.Fields("REGCD").Value = "" Then
                        m_IsRegionEmpty = True
                        row.Cells(col4Region.Index) = New DataGridViewLinkCell
                        row.Cells(col4Region.Index).Value = "Select Region"
                        row.Cells(col4Region.Index).Tag = True
                    Else
                        row.Cells(col4Region.Index) = New DataGridViewTextBoxCell
                        row.Cells(col4Region.Index).Value = m_RSCustomersWithStateAreaTerritoryProblem.Fields("REGCD").Value
                        row.Cells(col4RegionName.Index).Value = GetRegionDescription(m_RSCustomersWithStateAreaTerritoryProblem.Fields("REGCD").Value)
                        row.Cells(col4Region.Index).Tag = False
                    End If


                    If m_RSCustomersWithStateAreaTerritoryProblem.Fields("DISTCD").Value = "" Or m_IsRegionEmpty Then
                        m_IsProvinceEmpty = True
                        row.Cells(col4Province.Index) = New DataGridViewLinkCell
                        row.Cells(col4Province.Index).Value = "Select Province"
                        row.Cells(col4Province.Index).Tag = True
                    Else
                        row.Cells(col4Province.Index) = New DataGridViewTextBoxCell
                        row.Cells(col4Province.Index).Value = m_RSCustomersWithStateAreaTerritoryProblem.Fields("DISTCD").Value
                        If Not m_RSCustomersWithStateAreaTerritoryProblem.Fields("REGCD").Value = "" Then
                            row.Cells(col4ProvinceName.Index).Value = GetDistrictDescription(m_RSCustomersWithStateAreaTerritoryProblem.Fields("DISTCD").Value, m_RSCustomersWithStateAreaTerritoryProblem.Fields("REGCD").Value)
                        End If

                        row.Cells(col4Province.Index).Tag = False
                    End If


                    If m_RSCustomersWithStateAreaTerritoryProblem.Fields("AREACD").Value = "" Or m_IsRegionEmpty Or m_IsProvinceEmpty Then
                        m_IsMunicipalityEmpty = True
                        row.Cells(col4Municipality.Index) = New DataGridViewLinkCell
                        row.Cells(col4Municipality.Index).Value = "Select Municipality"
                        row.Cells(col4Municipality.Index).Tag = True
                    Else
                        row.Cells(col4Municipality.Index) = New DataGridViewTextBoxCell
                        row.Cells(col4Municipality.Index).Value = m_RSCustomersWithStateAreaTerritoryProblem.Fields("AREACD").Value
                        If Not m_RSCustomersWithStateAreaTerritoryProblem.Fields("REGCD").Value = "" And Not m_RSCustomersWithStateAreaTerritoryProblem.Fields("DISTCD").Value = "" Then
                            row.Cells(col4MunicipalityName.Index).Value = GetAreaDescription(m_RSCustomersWithStateAreaTerritoryProblem.Fields("AREACD").Value, m_RSCustomersWithStateAreaTerritoryProblem.Fields("REGCD").Value, m_RSCustomersWithStateAreaTerritoryProblem.Fields("DISTCD").Value)
                        End If

                        row.Cells(col4Municipality.Index).Tag = False
                    End If


                    If m_RSCustomersWithStateAreaTerritoryProblem.Fields("ZIPCD").Value = "" Or m_IsRegionEmpty Or m_IsProvinceEmpty Or m_IsMunicipalityEmpty Then
                        row.Cells(col4ZipCode.Index) = New DataGridViewLinkCell
                        row.Cells(col4ZipCode.Index).Value = "Select Zip Code"
                        row.Cells(col4ZipCode.Index).Tag = True
                    Else
                        row.Cells(col4ZipCode.Index) = New DataGridViewTextBoxCell
                        row.Cells(col4ZipCode.Index).Value = m_RSCustomersWithStateAreaTerritoryProblem.Fields("ZIPCD").Value
                        row.Cells(col4ZipCode.Index).Tag = False
                    End If

                    m_RSCustomersWithStateAreaTerritoryProblem.MoveNext()
                Next
            End If
        End If
    End Sub


    Private Sub LoadCompanyItemsNotInSystem()

        If m_RsCompanyItemsNotInSystem.State = 1 Then m_RsCompanyItemsNotInSystem.Close()
        m_RsCompanyItemsNotInSystem.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        m_RsCompanyItemsNotInSystem.Open("EXEC uspAnalysisResult @ACTION = 'CompanyItemsNotInSystem', @CompanyCode = '" & cboCompany.Text & "' , @CUTMO = '" & cboMonth.Text & "' , @CUTYEAR = '" & cboCalendarYear.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgCompanyItemsNotInSystem.Rows.Clear()
        If m_RsCompanyItemsNotInSystem.RecordCount > 0 Then
            m_WithError = True
            For m As Integer = 0 To m_RsCompanyItemsNotInSystem.RecordCount - 1
                Dim row As DataGridViewRow = dgCompanyItemsNotInSystem.Rows(dgCompanyItemsNotInSystem.Rows.Add)
                row.Cells(col9ItemCode.Index).Value = m_RsCompanyItemsNotInSystem.Fields("itemnumber").Value
                row.Cells(col9ItemBrandName.Index).Value = m_RsCompanyItemsNotInSystem.Fields("itemdescription").Value
                m_RsCompanyItemsNotInSystem.MoveNext()
            Next
        End If


    End Sub

    Private Sub LoadItemsNotInSystem()

        'If m_RsItemsNotInSystem.State = 1 Then m_RsItemsNotInSystem.Close()
        'm_RsItemsNotInSystem.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'm_RsItemsNotInSystem.Open("EXEC uspAnalysisResult @ACTION = 'ItemsNotInTheSystem', @CompanyCode = '" & cboCompany.Text & "' , @CUTMO = '" & cboMonth.Text & "' , @CUTYEAR = '" & cboCalendarYear.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        'dgItemsNotInSystem.Rows.Clear()
        'If m_RsItemsNotInSystem.RecordCount > 0 Then
        '    m_WithError = True
        '    If chkItemsNotInSystem.Checked Then
        '        For m As Integer = 0 To m_RsItemsNotInSystem.RecordCount - 1
        '            Dim row As DataGridViewRow = dgItemsNotInSystem.Rows(dgItemsNotInSystem.Rows.Add)
        '            row.Cells(colChannelItemCode.Index).Value = m_RsItemsNotInSystem.Fields("itemnumber").Value
        '            row.Cells(colChannelItemDesc.Index).Value = m_RsItemsNotInSystem.Fields("itemdescription").Value
        '            row.Cells(colItemCode.Index) = New DataGridViewLinkCell
        '            row.Cells(colItemCode.Index).Value = "Select Item"
        '            m_RsItemsNotInSystem.MoveNext()
        '        Next
        '    End If
        'End If
    End Sub

    Private Sub LoadCustomerNotInTerritory()
        If m_RsCustomerWithoutTerritory.State = 1 Then m_RsCustomerWithoutTerritory.Close()
        m_RsCustomerWithoutTerritory.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsCustomerWithoutTerritory.Open("EXEC uspAnalysisResult @ACTION = 'CustomerNotAssignedToTerritory', @CompanyCode = '" & cboCompany.Text & "' , @CUTMO = '" & cboMonth.Text & "' , @CUTYEAR = '" & cboCalendarYear.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgCustomerWithoutTerritory.Rows.Clear()
        Dim rsdiv As New ADODB.Recordset
        If rsdiv.State = 1 Then rsdiv.Close()
        rsdiv.Open("SELECT * FROM iTEMdIVISION Where DLTFLG = 0 AND ITMDIVCD <> '999'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsCustomerWithoutTerritory.RecordCount > 0 Then
            m_WithError = True
            If chkCustWithoutAssignedTerritory.Checked Then
                For m As Integer = 0 To m_RsCustomerWithoutTerritory.RecordCount - 1
                    rsdiv.MoveFirst()
                    For l As Integer = 0 To rsdiv.RecordCount - 1
                        Dim row As DataGridViewRow = dgCustomerWithoutTerritory.Rows(dgCustomerWithoutTerritory.Rows.Add)
                        row.Cells(col2CustomerCode.Index).Value = m_RsCustomerWithoutTerritory.Fields("CustomerCode").Value
                        row.Cells(col2CustomerName.Index).Value = m_RsCustomerWithoutTerritory.Fields("CustomerName").Value
                        row.Cells(col2CustomerGroup.Index).Value = m_RsCustomerWithoutTerritory.Fields("CustomerGroup").Value
                        row.Cells(col2CustomerAddress.Index).Value = m_RsCustomerWithoutTerritory.Fields("CustomerAddress").Value
                        row.Cells(col2ShipTo.Index).Value = m_RsCustomerWithoutTerritory.Fields("ShipToCode").Value
                        row.Cells(col2ShipToName.Index).Value = m_RsCustomerWithoutTerritory.Fields("ShipToName").Value

                        row.Cells(col2Region.Index).Tag = m_RsCustomerWithoutTerritory.Fields("REGCD").Value
                        row.Cells(col2Province.Index).Tag = m_RsCustomerWithoutTerritory.Fields("DISTCD").Value
                        row.Cells(col2Area.Index).Tag = m_RsCustomerWithoutTerritory.Fields("AREACD").Value

                        row.Cells(col2Region.Index).Value = m_RsCustomerWithoutTerritory.Fields("Region Name").Value
                        row.Cells(col2Province.Index).Value = m_RsCustomerWithoutTerritory.Fields("Province Name").Value
                        row.Cells(col2Area.Index).Value = m_RsCustomerWithoutTerritory.Fields("Municipality Name").Value

                        row.Cells(col2ZipCode.Index).Value = m_RsCustomerWithoutTerritory.Fields("ZIPCD").Value
                        row.Cells(col2SalesDivision.Index).Value = rsdiv.Fields("ITMDIVcd").Value
                        row.Cells(colTerritory.Index) = New DataGridViewLinkCell
                        row.Cells(colTerritory.Index).Value = "Select  Territory"
                        rsdiv.MoveNext()
                    Next
                    m_RsCustomerWithoutTerritory.MoveNext()
                Next
            End If
        End If
    End Sub

    Private Function CheckIfShipToCustomerCodeExist(ByVal CustomerShipToCode As String, ByVal CompanyCode As String, ByVal CustomerCode As String) As Boolean
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM CUSTOMERSHIPTO WHERE CUSTOMERSHIPTODEL = 0 AND COMID = '" & HandleSingleQuoteInSql(CompanyCode) & "' AND CUSTOMERCD = '" & HandleSingleQuoteInSql(CustomerCode) & "' AND CDACD = '" & HandleSingleQuoteInSql(CustomerShipToCode) & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub LoadShipToCustomerNotInSystem()
        If m_RsShipToCustomerNotInSystem.State = 1 Then m_RsShipToCustomerNotInSystem.Close()

        m_RsShipToCustomerNotInSystem.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsShipToCustomerNotInSystem.Open("EXEC uspAnalysisResult @ACTION = 'CustomerShipToNotInTheSystem', @CompanyCode = '" & cboCompany.Text & "' , @CUTMO = '" & cboMonth.Text & "' , @CUTYEAR = '" & cboCalendarYear.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgShipToNotInSystem.Rows.Clear()
        If m_RsShipToCustomerNotInSystem.RecordCount > 0 Then
            m_WithError = True

            If chkShipToNotInSystem.Checked Then


                '                If cboCompany.Text <> "MER" Then
                For m As Integer = 0 To m_RsShipToCustomerNotInSystem.RecordCount - 1
                    Dim row As DataGridViewRow = dgShipToNotInSystem.Rows(dgShipToNotInSystem.Rows.Add)
                    row.Cells(col8CustomerCode.Index).Value = m_RsShipToCustomerNotInSystem.Fields("CustomerNumber").Value
                    row.Cells(col8CustomerName.Index).Value = m_RsShipToCustomerNotInSystem.Fields("CustomerName").Value
                    row.Cells(col8ShipToCode.Index).Value = m_RsShipToCustomerNotInSystem.Fields("CustomerDeliveryCode").Value
                    row.Cells(col8ShipToName.Index).Value = m_RsShipToCustomerNotInSystem.Fields("ShipToName").Value
                    row.Cells(col8CustomerGrp.Index).Value = m_RsShipToCustomerNotInSystem.Fields("CustomerClass").Value
                    row.Cells(col8ShipToCustomerAddress1.Index).Value = m_RsShipToCustomerNotInSystem.Fields("ShipToAddress1").Value
                    row.Cells(col8ShipToAddress2.Index).Value = m_RsShipToCustomerNotInSystem.Fields("ShipToAddress2").Value

                    row.Cells(col8Region.Index).Tag = m_RsShipToCustomerNotInSystem.Fields("Region").Value
                    If Trim(m_RsShipToCustomerNotInSystem.Fields("Region").Value) <> "" Then
                        row.Cells(col8Region.Index).Value = GetRegionDescription(m_RsShipToCustomerNotInSystem.Fields("Region").Value)
                    End If

                    row.Cells(col8Province.Index).Tag = m_RsShipToCustomerNotInSystem.Fields("Province").Value
                    If Trim(m_RsShipToCustomerNotInSystem.Fields("Region").Value) <> "" And Trim(m_RsShipToCustomerNotInSystem.Fields("Province").Value) <> "" Then
                        row.Cells(col8Province.Index).Value = GetDistrictDescription(m_RsShipToCustomerNotInSystem.Fields("Province").Value, m_RsShipToCustomerNotInSystem.Fields("Region").Value)
                    End If

                    row.Cells(col8Municipality.Index).Tag = m_RsShipToCustomerNotInSystem.Fields("Area").Value
                    If Trim(m_RsShipToCustomerNotInSystem.Fields("Region").Value) <> "" And Trim(m_RsShipToCustomerNotInSystem.Fields("Province").Value) <> "" And Trim(m_RsShipToCustomerNotInSystem.Fields("Area").Value) <> "" Then
                        row.Cells(col8Municipality.Index).Value = GetAreaDescription(Trim(m_RsShipToCustomerNotInSystem.Fields("Area").Value), Trim(m_RsShipToCustomerNotInSystem.Fields("Region").Value), Trim(m_RsShipToCustomerNotInSystem.Fields("Province").Value))
                    End If


                    row.Cells(col8ZipCode.Index).Value = m_RsShipToCustomerNotInSystem.Fields("ZipCode").Value
                    'row.Cells(colShipTo.Index).Value = m_RsShipToCustomerNotInSystem.Fields("Ship To").Value
                    m_RsShipToCustomerNotInSystem.MoveNext()
                Next

                '    Else

                '        dgCustomerNotintheSystem.Columns(colCustomerName.Index).ReadOnly = False
                '        dgCustomerNotintheSystem.Columns(colCustomerClass.Index).ReadOnly = False
                '        dgCustomerNotintheSystem.Columns(colCustomerAddress.Index).ReadOnly = False
                '        dgCustomerNotintheSystem.Columns(colCustomerAddress2.Index).ReadOnly = False
                '        dgCustomerNotintheSystem.Columns(colRegion.Index).ReadOnly = False
                '        dgCustomerNotintheSystem.Columns(colProvince.Index).ReadOnly = False
                '        dgCustomerNotintheSystem.Columns(colArea.Index).ReadOnly = False
                '        dgCustomerNotintheSystem.Columns(colZipCode.Index).ReadOnly = False


                '        For m As Integer = 0 To m_RsCustomerNotInSystem.RecordCount - 1
                '            Dim row As DataGridViewRow = dgCustomerNotintheSystem.Rows(dgCustomerNotintheSystem.Rows.Add)
                '            row.Cells(colCustomerCode.Index).Value = m_RsCustomerNotInSystem.Fields("CustomerNumber").Value
                '            row.Cells(colCustomerName.Index).Value = m_RsCustomerNotInSystem.Fields("CustomerName").Value

                '            row.Cells(colCustomerClass.Index) = New DataGridViewLinkCell
                '            row.Cells(colCustomerClass.Index).Value = "Select Customer Group"
                '            row.Cells(colCustomerAddress.Index).Value = m_RsCustomerNotInSystem.Fields("CustomerAddress1").Value
                '            row.Cells(colCustomerAddress2.Index).Value = m_RsCustomerNotInSystem.Fields("CustomerAddress2").Value

                '            row.Cells(colRegion.Index) = New DataGridViewLinkCell
                '            row.Cells(colRegion.Index).Value = "Select Region"
                '            row.Cells(colProvince.Index) = New DataGridViewLinkCell
                '            row.Cells(colProvince.Index).Value = "Select Province"
                '            row.Cells(colArea.Index) = New DataGridViewLinkCell
                '            row.Cells(colArea.Index).Value = "Select Municipality"
                '            row.Cells(colZipCode.Index) = New DataGridViewLinkCell
                '            row.Cells(colZipCode.Index).Value = "Select ZipCode"

                '            m_RsCustomerNotInSystem.MoveNext()
                '        Next

                '    End If

            End If
        End If
    End Sub


    Private Sub LoadCustomerNotInSystem()
        If m_RsCustomerNotInSystem.State = 1 Then m_RsCustomerNotInSystem.Close()

        m_RsCustomerNotInSystem.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsCustomerNotInSystem.Open("EXEC uspAnalysisResult @ACTION = 'CustomerNotInSystem', @CompanyCode = '" & cboCompany.Text & "' , @CUTMO = '" & cboMonth.Text & "' , @CUTYEAR = '" & cboCalendarYear.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgCustomerNotintheSystem.Rows.Clear()
        If m_RsCustomerNotInSystem.RecordCount > 0 Then
            m_WithError = True

            If chkCustNotInSystem.Checked Then


                If cboCompany.Text <> "MER" Then
                    For m As Integer = 0 To m_RsCustomerNotInSystem.RecordCount - 1
                        Dim row As DataGridViewRow = dgCustomerNotintheSystem.Rows(dgCustomerNotintheSystem.Rows.Add)
                        row.Cells(colCustomerCode.Index).Value = m_RsCustomerNotInSystem.Fields("CustomerNumber").Value
                        row.Cells(colCustomerName.Index).Value = m_RsCustomerNotInSystem.Fields("CustomerName").Value

                        row.Cells(colCustomerClass.Index).Value = m_RsCustomerNotInSystem.Fields("CustomerClass").Value
                        row.Cells(colCustomerAddress.Index).Value = m_RsCustomerNotInSystem.Fields("CustomerAddress1").Value
                        row.Cells(colCustomerAddress2.Index).Value = m_RsCustomerNotInSystem.Fields("CustomerAddress2").Value

                        row.Cells(colShipTo.Index).Value = m_RsCustomerNotInSystem.Fields("CustomerDeliveryCode").Value
                        row.Cells(colShipToName.Index).Value = m_RsCustomerNotInSystem.Fields("ShiptoName").Value

                        row.Cells(colRegion.Index).Tag = m_RsCustomerNotInSystem.Fields("Region").Value
                        If Trim(m_RsCustomerNotInSystem.Fields("Region").Value) <> "" Then
                            row.Cells(colRegion.Index).Value = GetRegionDescription(m_RsCustomerNotInSystem.Fields("Region").Value)
                        End If

                        row.Cells(colProvince.Index).Tag = m_RsCustomerNotInSystem.Fields("Province").Value
                        If Trim(m_RsCustomerNotInSystem.Fields("Region").Value) <> "" And Trim(m_RsCustomerNotInSystem.Fields("Province").Value) <> "" Then
                            row.Cells(colProvince.Index).Value = GetDistrictDescription(m_RsCustomerNotInSystem.Fields("Province").Value, m_RsCustomerNotInSystem.Fields("Region").Value)
                        End If

                        row.Cells(colArea.Index).Tag = m_RsCustomerNotInSystem.Fields("Area").Value
                        If Trim(m_RsCustomerNotInSystem.Fields("Region").Value) <> "" And Trim(m_RsCustomerNotInSystem.Fields("Province").Value) <> "" And Trim(m_RsCustomerNotInSystem.Fields("Area").Value) <> "" Then
                            row.Cells(colArea.Index).Value = GetAreaDescription(m_RsCustomerNotInSystem.Fields("Area").Value, m_RsCustomerNotInSystem.Fields("Region").Value, m_RsCustomerNotInSystem.Fields("Province").Value)
                        End If

                        row.Cells(colZipCode.Index).Value = m_RsCustomerNotInSystem.Fields("ZipCode").Value
                        'row.Cells(colShipTo.Index).Value = m_RsCustomerNotInSystem.Fields("Ship To").Value
                        m_RsCustomerNotInSystem.MoveNext()
                    Next
                Else


                    dgCustomerNotintheSystem.Columns(colCustomerName.Index).ReadOnly = False
                    dgCustomerNotintheSystem.Columns(colCustomerClass.Index).ReadOnly = False
                    dgCustomerNotintheSystem.Columns(colCustomerAddress.Index).ReadOnly = False
                    dgCustomerNotintheSystem.Columns(colCustomerAddress2.Index).ReadOnly = False
                    dgCustomerNotintheSystem.Columns(colRegion.Index).ReadOnly = False
                    dgCustomerNotintheSystem.Columns(colProvince.Index).ReadOnly = False
                    dgCustomerNotintheSystem.Columns(colArea.Index).ReadOnly = False
                    dgCustomerNotintheSystem.Columns(colZipCode.Index).ReadOnly = False


                    For m As Integer = 0 To m_RsCustomerNotInSystem.RecordCount - 1
                        Dim row As DataGridViewRow = dgCustomerNotintheSystem.Rows(dgCustomerNotintheSystem.Rows.Add)
                        row.Cells(colCustomerCode.Index).Value = m_RsCustomerNotInSystem.Fields("CustomerNumber").Value
                        row.Cells(colCustomerName.Index).Value = m_RsCustomerNotInSystem.Fields("CustomerName").Value

                        row.Cells(colCustomerClass.Index) = New DataGridViewLinkCell
                        row.Cells(colCustomerClass.Index).Value = "Select Customer Group"
                        row.Cells(colCustomerAddress.Index).Value = m_RsCustomerNotInSystem.Fields("CustomerAddress1").Value
                        row.Cells(colCustomerAddress2.Index).Value = m_RsCustomerNotInSystem.Fields("CustomerAddress2").Value

                        row.Cells(colRegion.Index) = New DataGridViewLinkCell
                        row.Cells(colRegion.Index).Value = "Select Region"
                        row.Cells(colProvince.Index) = New DataGridViewLinkCell
                        row.Cells(colProvince.Index).Value = "Select Province"
                        row.Cells(colArea.Index) = New DataGridViewLinkCell
                        row.Cells(colArea.Index).Value = "Select Municipality"
                        row.Cells(colZipCode.Index) = New DataGridViewLinkCell
                        row.Cells(colZipCode.Index).Value = "Select ZipCode"

                        m_RsCustomerNotInSystem.MoveNext()
                    Next

                End If

            End If
        End If
    End Sub

    Private Sub UCRawDataAnalyzer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDistributor()
        ApplyGridTheme(dgCustomerNotintheSystem)
        ApplyGridTheme(dgCustomerWithoutTerritory)
        ApplyGridTheme(dgShipToNotInSystem)
        ApplyGridTheme(dgCompanyItemsNotInSystem)
        '   ApplyGridTheme(dgItemsNotInSystem)
        ApplyGridTheme(dgCustomerWithStateAreaTerritory)
        ApplyGridTheme(dgUnmappedCustomers)
        ApplyGridTheme(dgShipToCustomer)
        ApplyGridTheme(dgUnmappedShipToCustomers)
        ApplyGridTheme(dgBatch)
        LoadUploadedRawData()
        LoadYear()
        'LoadCustomerNotInSystem()
        'LoadCustomerNotInTerritory()
        'LoadItemsNotInSystem()

        SPMSConn.CommandTimeout = 0
        SPMSConn.Execute("EXEC uspUpdateCustomerMappingStateAreaTerritory")



        For m As Integer = 0 To tbPages.TabPages.Count - 1
            tbPages.TabPages(m).Text = "Page " & m + 1
        Next
    End Sub


    Private Sub LoadUploadedRawData()
        'Dim rs As New ADODB.Recordset
        'If rs.State = 1 Then rs.Close()
        'rs.Open("select companycode, checkfilename, cutmo, cutyear from uploadedrawdata group by companycode, checkfilename, cutmo, cutyear", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        'dgBatch.Rows.Clear()
        'If rs.RecordCount > 0 Then
        '    For m As Integer = 0 To rs.RecordCount - 1
        '        Dim row As DataGridViewRow = dgBatch.Rows(dgBatch.Rows.Add)
        '        row.Cells(colCompanyCode.Index).Value = rs.Fields("CompanyCode").Value
        '        row.Cells(colFileName.Index).Value = rs.Fields("CheckFileName").Value
        '        row.Cells(colCutMo.Index).Value = rs.Fields("CutMo").Value
        '        row.Cells(colYear.Index).Value = rs.Fields("CutYear").Value
        '        rs.MoveNext()
        '    Next
        'End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        For m As Integer = 0 To dgCustomerNotintheSystem.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerNotintheSystem.Rows(m)
            row.Cells(colSelect.Index).Value = True
        Next
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        For m As Integer = 0 To dgCustomerNotintheSystem.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerNotintheSystem.Rows(m)
            row.Cells(colSelect.Index).Value = False
        Next
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        For m As Integer = 0 To dgCustomerWithoutTerritory.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerWithoutTerritory.Rows(m)
            row.Cells(col2Select.Index).Value = True
        Next
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        For m As Integer = 0 To dgCustomerWithoutTerritory.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerWithoutTerritory.Rows(m)
            row.Cells(col2Select.Index).Value = False
        Next
    End Sub

    Private Sub LinkLabel6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        'For m As Integer = 0 To dgItemsNotInSystem.RowCount - 1
        '    Dim row As DataGridViewRow = dgItemsNotInSystem.Rows(m)
        '    row.Cells(col3Select.Index).Value = True
        'Next
    End Sub

    Private Sub LinkLabel5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        'For m As Integer = 0 To dgItemsNotInSystem.RowCount - 1
        '    Dim row As DataGridViewRow = dgItemsNotInSystem.Rows(m)
        '    row.Cells(col3Select.Index).Value = False
        'Next
    End Sub
    Private Function GetCustomerName(ByVal CompanyCode As String, ByVal CustomerCode As String) As String
        If m_RsDistributor.State = 1 Then m_RsDistributor.Close()
        m_RsDistributor.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsDistributor.Open("SELECT CustomerName  FROM Customer WHERE CUSTOMERDEL = 0 AND COMID= '" & CompanyCode & "' AND CUSTOMERCD = '" & HandleSingleQuoteInSql(CustomerCode) & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsDistributor.RecordCount > 0 Then
            Return m_RsDistributor.Fields("CustomerName").Value
        Else
            Return ""
        End If

    End Function
    Private Sub GetCompanyName(ByVal CompanyCode As String)
        If m_RsDistributor.State = 1 Then m_RsDistributor.Close()
        m_RsDistributor.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsDistributor.Open("SELECT DISTNAME FROM DISTRIBUTOR WHERE DLTFLG = 0 AND DISTCOMID= '" & CompanyCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsDistributor.RecordCount > 0 Then
            txtCompany.Text = m_RsDistributor.Fields("DISTNAME").Value
        End If

    End Sub
    Private Sub cboCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCompany.SelectedIndexChanged
        If cboCompany.SelectedIndex <> -1 Then
            GetCompanyName(cboCompany.Text)
            txtBatchNo.Text = ""
            txtBatchNo.Text = ""
            cboCalendarYear.Text = ""
            cboMonth.Text = ""
        Else
            txtCompany.Text = String.Empty
        End If
    End Sub

    Private Sub LoadDistributor()
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

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblChannel.Text = Space(20) & cboCompany.Text & " - " & txtCompany.Text

        m_WithError = False
        If ValidateData() Then
            LoadCustomerNotInSystem()
            LoadShipToCustomerNotInSystem()
            If GetDefaultCompany() = "GPI" Then
                ReExecuteZipCodeTerritoryAssignment()
            End If
            LoadCustomerNotInTerritory()
            LoadItemsNotInSystem()
            LoadCompanyItemsNotInSystem()
            If Not chkOverrideShipToCustomers.Checked Then
                LoadShipToCustomersWithStateAreaTerritoryProblem()
            End If
            If Not chkOverrideCustomerWithStateAreaTerritoryProblem.Checked Then
                LoadCustomersWithStateAreaTerritoryProblem()
            End If
            If Not chkOverrideUnmappedCustomer.Checked Then
                LoadUnmappedCustomers()
            End If
            If Not chkUnmappedShipto.Checked Then
                LoadUnmappedShipToCustomers()
            End If


            If m_WithError Then


                VDialog.Show("Errors have been found. Check Analysis Results tab for references.", "Start", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                If chkStartCrediting.Checked Then
                    If CheckIfMonthAndYearIsLocked(cboMonth.Text, cboCalendarYear.Text, cboCompany.Text) Then
                        VDialog.Show("This sales month was already locked and data cannot be overriden.", "Raw Data Analyzer", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    Else
                        'ReExecuteZipCodeTerritoryAssignment()
                        Rebuild()
                    End If

                End If
            End If
        End If
    End Sub

    Private Function CheckIfMonthAndYearIsLocked(ByVal Month As String, ByVal Year As String, ByVal CompanyCode As String) As Boolean
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT 'A' FROM Cust_div_item_sales where  TRXFLG = 1 AND  CUTMO = '" & Month & "' AND CUTYEAR = '" & Year & "' AND COMID = '" & CompanyCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Rebuild()
        Try
            SPMSConn.CommandTimeout = 0
            SPMSConn.Execute("EXEC uspRebuild @COMID = '" & cboCompany.Text & "' , @CUTMO = '" & cboMonth.Text & "' , @CUTYEAR = '" & cboCalendarYear.Text & "' ")
            'Updated on 09152010
            'RebuildExclusion(cboCompany.Text)
            VDialog.Show("Sales for " & cboCompany.Text & " - " & txtCompany.Text & " :  For the month of  " & cboMonth.Text & " - " & txtMonthDescription.Text & " , " & cboCalendarYear.Text & " Successfully Processed", "Rebuild", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub ReExecuteZipCodeTerritoryAssignment()
        Try
            SPMSConn.CommandTimeout = 0
            SPMSConn.Execute("EXEC UspReExecuteZipCodeTerritoryMapping ")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub RebuildExclusion(ByVal CompanyCode As String)
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT DISTINCT COMIDTO FROM SalesExtension WHERE COMID = '" & CompanyCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.RecordCount > 0 Then
            For m As Integer = 0 To rs.RecordCount - 1
                Dim rs2 As New ADODB.Recordset
                If rs2.State = 1 Then rs2.Close()
                rs2.Open("SELECT DISTINCT COMPANYCODE FROM RAWDATA WHERE COMPANYCODE = '" & rs.Fields("COMIDTO").Value & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rs2.RecordCount = 0 Then
                    SPMSConn.Execute("EXEC uspExclusionRebuild @COMID = '" & cboCompany.Text & "' , @CUTMO = '" & cboMonth.Text & "' , @CUTYEAR = '" & cboCalendarYear.Text & "', @COMIDTO = '" & rs.Fields("COMIDTO").Value & "' ")
                End If
                rs.MoveNext()
            Next
        End If

    End Sub

    Private Function ValidateData() As Boolean
        m_HasError = False
        m_Err.Clear()

        If cboCompany.Text = "" Then
            m_Err.SetError(cboCompany, "Channel is required")
            m_HasError = True
        End If

        If cboCalendarYear.Text = "" Then
            m_Err.SetError(cboCalendarYear, "Year is required")
            m_HasError = True
        End If

        If cboMonth.Text = "" Then
            m_Err.SetError(cboMonth, "Month is required")
            m_HasError = True
        End If
        Return Not m_HasError
    End Function

    Private Sub lnkCustomersNotInSystem_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCustomersNotInSystem.LinkClicked
        MainTab.SelectedTab = tbListing
        tbPages.SelectedTab = TabPage1
    End Sub

    Private Sub lnkAddressProblem_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAddressProblem.LinkClicked
        MainTab.SelectedTab = tbListing
        tbPages.SelectedTab = TabPage2
    End Sub

    Private Sub lnkItemsNotInSystem_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkUnmappedShipToCustomers.LinkClicked
        MainTab.SelectedTab = tbListing
        tbPages.SelectedTab = TabPage9
    End Sub

    Private Sub LinkLabel7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Dim q As MsgBoxResult

        q = VDialog.Show("Are you sure you want to add selected customers?", "Add Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If q = MsgBoxResult.Yes Then
            Dim ctr As Integer = 0
            For m As Integer = 0 To dgCustomerNotintheSystem.Rows.Count - 1
                Dim row As DataGridViewRow = dgCustomerNotintheSystem.Rows(m)
                If row.Cells(colSelect.Index).Value = True Then
                    ctr += 1
                    'Exit sub
                    Exit For
                End If
            Next
            If ctr > 0 Then
                If ValidateCustomer() Then
                    SaveCustomerNotInSystem()
                End If
            Else
                VDialog.Show("At least 1 checked detail is required.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        End If
    End Sub

    Private Function ValidateCustomer() As Boolean
        m_HasError = False


        If cboCompany.Text = "MER" Then
            For m As Integer = 0 To dgCustomerNotintheSystem.RowCount - 1
                Dim row As DataGridViewRow = dgCustomerNotintheSystem.Rows(m)
                If row.Cells(colSelect.Index).Value = True Then

                    If row.Cells(colCustomerClass.Index).Value = "Select Customer Group" Then
                        row.Cells(colCustomerClass.Index).Style.BackColor = Color.LightPink
                        row.Cells(colCustomerClass.Index).ToolTipText = "Customer Group is required"
                        m_HasError = True
                    Else
                        row.Cells(colCustomerClass.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                        row.Cells(colCustomerClass.Index).ToolTipText = String.Empty
                    End If

                    If row.Cells(colCustomerName.Index).Value = "" Then
                        row.Cells(colCustomerName.Index).Style.BackColor = Color.LightPink
                        row.Cells(colCustomerName.Index).ToolTipText = "Customer Name is required"
                        m_HasError = True
                    Else
                        row.Cells(colCustomerName.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                        row.Cells(colCustomerName.Index).ToolTipText = String.Empty
                    End If

                    If row.Cells(colCustomerName.Index).Value = "" Then
                        row.Cells(colCustomerName.Index).Style.BackColor = Color.LightPink
                        row.Cells(colCustomerName.Index).ToolTipText = "Customer Name is required"
                        m_HasError = True
                    Else
                        row.Cells(colCustomerName.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                        row.Cells(colCustomerName.Index).ToolTipText = String.Empty
                    End If

                    If row.Cells(colCustomerAddress.Index).Value = "" Then
                        row.Cells(colCustomerAddress.Index).Style.BackColor = Color.LightPink
                        row.Cells(colCustomerAddress.Index).ToolTipText = "Customer Address 1 is required"
                        m_HasError = True
                    Else
                        row.Cells(colCustomerAddress.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                        row.Cells(colCustomerAddress.Index).ToolTipText = String.Empty
                    End If

                    If row.Cells(colCustomerAddress2.Index).Value = "" Then
                        row.Cells(colCustomerAddress2.Index).Style.BackColor = Color.LightPink
                        row.Cells(colCustomerAddress2.Index).ToolTipText = "Customer Address 2 is required"
                        m_HasError = True
                    Else
                        row.Cells(colCustomerAddress2.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                        row.Cells(colCustomerAddress2.Index).ToolTipText = String.Empty
                    End If

                    If row.Cells(colRegion.Index).Value = "Select Region" Then
                        row.Cells(colRegion.Index).Style.BackColor = Color.LightPink
                        row.Cells(colRegion.Index).ToolTipText = "Region is required"
                        m_HasError = True
                    Else
                        row.Cells(colRegion.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                        row.Cells(colRegion.Index).ToolTipText = String.Empty
                    End If

                    If row.Cells(colProvince.Index).Value = "Select Province" Then
                        row.Cells(colProvince.Index).Style.BackColor = Color.LightPink
                        row.Cells(colProvince.Index).ToolTipText = "Province is required"
                        m_HasError = True
                    Else
                        row.Cells(colProvince.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                        row.Cells(colProvince.Index).ToolTipText = String.Empty
                    End If

                    If row.Cells(colArea.Index).Value = "Select Municipality" Then
                        row.Cells(colArea.Index).Style.BackColor = Color.LightPink
                        row.Cells(colArea.Index).ToolTipText = "Municipality is required"
                        m_HasError = True
                    Else
                        row.Cells(colArea.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                        row.Cells(colArea.Index).ToolTipText = String.Empty
                    End If

                    If row.Cells(colZipCode.Index).Value = "Select ZipCode" Then
                        row.Cells(colZipCode.Index).Style.BackColor = Color.LightPink
                        row.Cells(colZipCode.Index).ToolTipText = "ZipCode is required"
                        m_HasError = True
                    Else
                        row.Cells(colZipCode.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                        row.Cells(colZipCode.Index).ToolTipText = String.Empty
                    End If


                End If
            Next

        End If


        For m As Integer = 0 To dgCustomerNotintheSystem.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerNotintheSystem.Rows(m)
            If row.Cells(colSelect.Index).Value = True Then
                If row.Cells(colShipTo.Index).Value = "" Then
                    row.Cells(colShipTo.Index).Style.BackColor = Color.LightPink
                    row.Cells(colShipTo.Index).ToolTipText = "Default Ship to Code is required"
                    m_HasError = True
                Else
                    row.Cells(colShipTo.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                    row.Cells(colShipTo.Index).ToolTipText = String.Empty
                End If

                If row.Cells(colShipToName.Index).Value = "" Then
                    row.Cells(colShipToName.Index).Style.BackColor = Color.LightPink
                    row.Cells(colShipToName.Index).ToolTipText = "Default Ship to Name is required"
                    m_HasError = True
                Else
                    row.Cells(colShipToName.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                    row.Cells(colShipToName.Index).ToolTipText = String.Empty
                End If
            End If
        Next

        Return Not m_HasError
    End Function

    Private Sub SaveShipToCustomerNotInSystem()
        m_ForDeletes.Clear()
        For m As Integer = 0 To dgShipToNotInSystem.RowCount - 1
            Dim row As DataGridViewRow = dgShipToNotInSystem.Rows(m)
            If row.Cells(colSelect.Index).Value = True Then

                If Not CheckIfShipToCustomerCodeExist(row.Cells(col8ShipToCode.Index).Value, cboCompany.Text, row.Cells(col8CustomerCode.Index).Value) Then

                    If row.Cells(colZipCode.Index).Value <> String.Empty Then
                        If row.Cells(colRegion.Index).Value = String.Empty Or row.Cells(colProvince.Index).Value = String.Empty Or row.Cells(colArea.Index).Value = String.Empty Then
                            SaveShipToCustomerNotInSystemWithZipCdAutomation(row)
                        Else
                            SaveShipToCustomerNotInSystem(row)
                        End If
                    Else
                        SaveShipToCustomerNotInSystem(row)
                    End If
                End If

                m_ForDeletes.Add.ID = m
            End If
        Next

        For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
            dgShipToNotInSystem.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next

        VDialog.Show("Record Successfully Saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Private Sub SaveShipToCustomerNotInSystemWithZipCdAutomation(ByVal row As DataGridViewRow)
        Try

            If CheckIfZipCodeExists(row.Cells(col8ZipCode.Index).Value) Then

                Dim rs As ADODB.Recordset = LoadZipCode(row.Cells(col8ZipCode.Index).Value)
                If Not rs Is Nothing And rs.RecordCount = 1 Then

                    SPMSConn.Execute("EXEC uspCustomerShipTo @Action = 'ADD' ,  @COMID =  '" & cboCompany.Text & "' , " & _
                                        " @CustomerCD = '" & HandleSingleQuoteInSql(row.Cells(col8CustomerCode.Index).Value) & "' ,  " & _
                                        " @CDACD = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToCode.Index).Value) & "' , @CDANAME = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToName.Index).Value) & "' , " & _
                                        " @CDACADD1 = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToCustomerAddress1.Index).Value) & "' , @CDACADD2 = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToAddress2.Index).Value) & "' , " & _
                                        " @ZIPCD = '" & HandleSingleQuoteInSql(row.Cells(col8ZipCode.Index).Value) & "' , @REGCD = '" & HandleSingleQuoteInSql(rs.Fields("REGCD").Value) & "' , " & _
                                        " @DISTCD = '" & HandleSingleQuoteInSql(rs.Fields("DISTRCTCD").Value) & "' , @AREACD = '" & HandleSingleQuoteInSql(rs.Fields("AREACD").Value) & "' , @TERRCD = '' , @CMGRP = '" & HandleSingleQuoteInSql(row.Cells(colCustomerClass.Index).Value) & "'  , @CMCLASS =  '' , " & _
                                        " @AREACOVRG = '', @ACCNTSHRD = 0 ")
                Else
                    SPMSConn.Execute("EXEC uspCustomerShipTo @Action = 'ADD' ,  @COMID =  '" & cboCompany.Text & "' , " & _
                    " @CustomerCD = '" & HandleSingleQuoteInSql(row.Cells(col8CustomerCode.Index).Value) & "' ,  " & _
                    " @CDACD = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToCode.Index).Value) & "' , @CDANAME = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToName.Index).Value) & "' , " & _
                    " @CDACADD1 = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToCustomerAddress1.Index).Value) & "' , @CDACADD2 = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToAddress2.Index).Value) & "' , " & _
                    " @ZIPCD = '" & HandleSingleQuoteInSql(row.Cells(col8ZipCode.Index).Value) & "' , @REGCD = '" & HandleSingleQuoteInSql(rs.Fields("REGCD").Value) & "' , " & _
                    " @DISTCD = '" & HandleSingleQuoteInSql(row.Cells(col8Province.Index).Tag) & "' , @AREACD = '" & HandleSingleQuoteInSql(row.Cells(col8Municipality.Index).Tag) & "' , @TERRCD = '' , @CMGRP = '" & HandleSingleQuoteInSql(row.Cells(colCustomerClass.Index).Value) & "'  , @CMCLASS =  '' , " & _
                    " @AREACOVRG = '', @ACCNTSHRD = 0 ")
                    'SaveShipToCustomerNotInSystem(row)
                End If

            Else
                SaveShipToCustomerNotInSystem(row)
            End If



        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub SaveShipToCustomerNotInSystem(ByVal row As DataGridViewRow)
        Try
            SPMSConn.Execute("EXEC uspCustomerShipTo @Action = 'ADD' ,  @COMID =  '" & cboCompany.Text & "' , " & _
                                " @CustomerCD = '" & HandleSingleQuoteInSql(row.Cells(col8CustomerCode.Index).Value) & "' ,  " & _
                                " @CDACD = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToCode.Index).Value) & "' , @CDANAME = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToName.Index).Value) & "' , " & _
                                " @CDACADD1 = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToCustomerAddress1.Index).Value) & "' , @CDACADD2 = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToAddress2.Index).Value) & "' , " & _
                                " @ZIPCD = '" & HandleSingleQuoteInSql(row.Cells(col8ZipCode.Index).Value) & "' , @REGCD = '" & HandleSingleQuoteInSql(row.Cells(col8Region.Index).Tag) & "' , " & _
                                " @DISTCD = '" & HandleSingleQuoteInSql(row.Cells(col8Province.Index).Tag) & "' , @AREACD = '" & HandleSingleQuoteInSql(row.Cells(col8Municipality.Index).Tag) & "' , @TERRCD = '' , @CMGRP = '" & HandleSingleQuoteInSql(row.Cells(colCustomerClass.Index).Value) & "'  , @CMCLASS =  '' , " & _
                                " @AREACOVRG = '', @ACCNTSHRD = 0 ")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub SaveCustomerNotInSystem()
        m_ForDeletes.Clear()
        For m As Integer = 0 To dgCustomerNotintheSystem.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerNotintheSystem.Rows(m)
            If row.Cells(colSelect.Index).Value = True Then

                If row.Cells(colZipCode.Index).Value <> String.Empty Then
                    If row.Cells(colRegion.Index).Value = String.Empty Or row.Cells(colProvince.Index).Value = String.Empty Or row.Cells(colArea.Index).Value = String.Empty Then
                        SaveCustomerWithZipCodeAutomation(row)
                        SaveDefaultCustomerShipToWithZipCdAutomation(row)
                    Else
                        SaveCustomerNotIntheSystem(row)
                        SaveDefaultCustomerShipTo(row)
                    End If
                Else
                    SaveCustomerNotIntheSystem(row)
                    SaveDefaultCustomerShipTo(row)
                End If


                m_ForDeletes.Add.ID = m
            End If
        Next

        For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
            dgCustomerNotintheSystem.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next

        VDialog.Show("Record Successfully Saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub SaveCustomerWithZipCodeAutomation(ByVal row As DataGridViewRow)
        Try
            If CheckIfZipCodeExists(row.Cells(colZipCode.Index).Value) Then

                Dim rs As ADODB.Recordset = LoadZipCode(row.Cells(colZipCode.Index).Value)
                If Not rs Is Nothing And rs.RecordCount = 1 Then
                    SPMSConn.Execute("EXEC uspCustomer @Action = 'ADD' , @Comid = '" & cboCompany.Text & "' , " & _
                            " @CustomerCD = '" & HandleSingleQuoteInSql(row.Cells(colCustomerCode.Index).Value) & "', @CustomerNAME = '" & HandleSingleQuoteInSql(row.Cells(colCustomerName.Index).Value) & "' , @DistribCD = '', " & _
                            " @CADD1 = '" & HandleSingleQuoteInSql(row.Cells(colCustomerAddress.Index).Value) & "', @CADD2 = '" & HandleSingleQuoteInSql(row.Cells(colCustomerAddress2.Index).Value) & "' , @CMCont = '' , @Cmphon = '', " & _
                            " @CDACD = '" & HandleSingleQuoteInSql(row.Cells(colShipTo.Index).Value) & "'  , @ZIPCD = '" & HandleSingleQuoteInSql(row.Cells(colZipCode.Index).Value) & "' , @REGCD = '" & HandleSingleQuoteInSql(rs.Fields("REGCD").Value) & "' , " & _
                            " @DISTCD = '" & rs.Fields("DISTRCTCD").Value & "' , @AREACD = '" & rs.Fields("AREACD").Value & "' , @TERRCD = '' , @CMGRP = '" & row.Cells(colCustomerClass.Index).Value & "' , @CMCLASS = ''  , " & _
                            " @AREACOVRG = " & IIf(row.Cells(col1Shared.Index).Value = True, "1", "0") & "  , @VAT =  1 , @OLDCUSTCODE = '' , " & _
                        " @ACCNTSHRD =  " & IIf(row.Cells(col1Shared.Index).Value = True, "1", "0") & " ")
                Else

                    SPMSConn.Execute("EXEC uspCustomer @Action = 'ADD' , @Comid = '" & cboCompany.Text & "' , " & _
                            " @CustomerCD = '" & HandleSingleQuoteInSql(row.Cells(colCustomerCode.Index).Value) & "', @CustomerNAME = '" & HandleSingleQuoteInSql(row.Cells(colCustomerName.Index).Value) & "' , @DistribCD = '', " & _
                            " @CADD1 = '" & HandleSingleQuoteInSql(row.Cells(colCustomerAddress.Index).Value) & "', @CADD2 = '" & HandleSingleQuoteInSql(row.Cells(colCustomerAddress2.Index).Value) & "' , @CMCont = '' , @Cmphon = '', " & _
                            " @CDACD = '" & HandleSingleQuoteInSql(row.Cells(colShipTo.Index).Value) & "'  , @ZIPCD = '" & HandleSingleQuoteInSql(row.Cells(colZipCode.Index).Value) & "' , @REGCD = '" & HandleSingleQuoteInSql(rs.Fields("REGCD").Value) & "' , " & _
                            " @DISTCD = '" & row.Cells(colProvince.Index).Tag & "' , @AREACD = '" & row.Cells(colArea.Index).Tag & "' , @TERRCD = '' , @CMGRP = '" & row.Cells(colCustomerClass.Index).Value & "' , @CMCLASS = ''  , " & _
                            " @AREACOVRG = " & IIf(row.Cells(col1Shared.Index).Value = True, "1", "0") & "  , @VAT =  1 , @OLDCUSTCODE = '' , " & _
                        " @ACCNTSHRD =  " & IIf(row.Cells(col1Shared.Index).Value = True, "1", "0") & " ")

                End If

            Else
                SaveCustomerNotIntheSystem(row)
            End If




        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub SaveDefaultCustomerShipToWithZipCdAutomation(ByVal row As DataGridViewRow)
        Try

            If CheckIfZipCodeExists(row.Cells(colZipCode.Index).Value) Then

                Dim rs As ADODB.Recordset = LoadZipCode(row.Cells(colZipCode.Index).Value)
                If Not rs Is Nothing And rs.RecordCount = 1 Then
                    SPMSConn.Execute("EXEC uspCustomerShipTo @Action = 'ADD' ,  @COMID =  '" & cboCompany.Text & "' , " & _
                                        " @CustomerCD = '" & HandleSingleQuoteInSql(row.Cells(colCustomerCode.Index).Value) & "' ,  " & _
                                        " @CDACD = '" & HandleSingleQuoteInSql(row.Cells(colShipTo.Index).Value) & "' , @CDANAME = '" & HandleSingleQuoteInSql(row.Cells(colShipToName.Index).Value) & "' , " & _
                                        " @CDACADD1 = '" & HandleSingleQuoteInSql(row.Cells(colCustomerAddress.Index).Value) & "' , @CDACADD2 = '" & HandleSingleQuoteInSql(row.Cells(colCustomerAddress2.Index).Value) & "' , " & _
                                        " @ZIPCD = '" & HandleSingleQuoteInSql(row.Cells(colZipCode.Index).Value) & "' , @REGCD = '" & HandleSingleQuoteInSql(rs.Fields("ZIPCD").Value) & "' , " & _
                                        " @DISTCD = '" & HandleSingleQuoteInSql(rs.Fields("DISTRCTCD").Value) & "' , @AREACD = '" & HandleSingleQuoteInSql(rs.Fields("AREACD").Value) & "' , @TERRCD = '' , @CMGRP = '" & HandleSingleQuoteInSql(row.Cells(colCustomerClass.Index).Value) & "'  , @CMCLASS =  '' , " & _
                                        " @AREACOVRG = " & IIf(row.Cells(col1Shared.Index).Value = True, "1", "0") & " ")
                Else
                    SPMSConn.Execute("EXEC uspCustomerShipTo @Action = 'ADD' ,  @COMID =  '" & cboCompany.Text & "' , " & _
                    " @CustomerCD = '" & HandleSingleQuoteInSql(row.Cells(colCustomerCode.Index).Value) & "' ,  " & _
                    " @CDACD = '" & HandleSingleQuoteInSql(row.Cells(colShipTo.Index).Value) & "' , @CDANAME = '" & HandleSingleQuoteInSql(row.Cells(colShipToName.Index).Value) & "' , " & _
                    " @CDACADD1 = '" & HandleSingleQuoteInSql(row.Cells(colCustomerAddress.Index).Value) & "' , @CDACADD2 = '" & HandleSingleQuoteInSql(row.Cells(colCustomerAddress2.Index).Value) & "' , " & _
                    " @ZIPCD = '" & HandleSingleQuoteInSql(row.Cells(colZipCode.Index).Value) & "' , @REGCD = '" & HandleSingleQuoteInSql(rs.Fields("REGCD").Value) & "' , " & _
                    " @DISTCD = '" & HandleSingleQuoteInSql(row.Cells(colProvince.Index).Value) & "' , @AREACD = '" & HandleSingleQuoteInSql(row.Cells(colArea.Index).Value) & "' , @TERRCD = '' , @CMGRP = '" & HandleSingleQuoteInSql(row.Cells(colCustomerClass.Index).Value) & "'  , @CMCLASS =  '' , " & _
                    " @AREACOVRG = " & IIf(row.Cells(col1Shared.Index).Value = True, "1", "0") & " ")

                End If

            Else
                SaveDefaultCustomerShipTo(row)
            End If



        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub SaveCustomerNotIntheSystem(ByVal row As DataGridViewRow)
        Try

            SPMSConn.Execute("EXEC uspCustomer @Action = 'ADD' , @Comid = '" & cboCompany.Text & "' , " & _
                                        " @CustomerCD = '" & HandleSingleQuoteInSql(row.Cells(colCustomerCode.Index).Value) & "', @CustomerNAME = '" & HandleSingleQuoteInSql(row.Cells(colCustomerName.Index).Value) & "' , @DistribCD = '', " & _
                                        " @CADD1 = '" & HandleSingleQuoteInSql(row.Cells(colCustomerAddress.Index).Value) & "', @CADD2 = '" & HandleSingleQuoteInSql(row.Cells(colCustomerAddress2.Index).Value) & "' , @CMCont = '' , @Cmphon = '', " & _
                                        " @CDACD = '" & HandleSingleQuoteInSql(row.Cells(colShipTo.Index).Value) & "'  , @ZIPCD = '" & HandleSingleQuoteInSql(row.Cells(colZipCode.Index).Value) & "' , @REGCD = '" & HandleSingleQuoteInSql(row.Cells(colRegion.Index).Tag) & "' , " & _
                                        " @DISTCD = '" & row.Cells(colProvince.Index).Tag & "' , @AREACD = '" & row.Cells(colArea.Index).Tag & "' , @TERRCD = '' , @CMGRP = '" & row.Cells(colCustomerClass.Index).Value & "' , @CMCLASS = ''  , " & _
                                        " @AREACOVRG = " & IIf(row.Cells(col1Shared.Index).Value = True, "1", "0") & "  , @VAT =  1 , @OLDCUSTCODE = '' , " & _
                                    " @ACCNTSHRD =  " & IIf(row.Cells(col1Shared.Index).Value = True, "1", "0") & " ")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Private Sub SaveDefaultCustomerShipTo(ByVal row As DataGridViewRow)
        Try
            SPMSConn.Execute("EXEC uspCustomerShipTo @Action = 'ADD' ,  @COMID =  '" & cboCompany.Text & "' , " & _
                                " @CustomerCD = '" & HandleSingleQuoteInSql(row.Cells(colCustomerCode.Index).Value) & "' ,  " & _
                                " @CDACD = '" & HandleSingleQuoteInSql(row.Cells(colShipTo.Index).Value) & "' , @CDANAME = '" & HandleSingleQuoteInSql(row.Cells(colShipToName.Index).Value) & "' , " & _
                                " @CDACADD1 = '" & HandleSingleQuoteInSql(row.Cells(colCustomerAddress.Index).Value) & "' , @CDACADD2 = '" & HandleSingleQuoteInSql(row.Cells(colCustomerAddress2.Index).Value) & "' , " & _
                                " @ZIPCD = '" & HandleSingleQuoteInSql(row.Cells(colZipCode.Index).Value) & "' , @REGCD = '" & HandleSingleQuoteInSql(row.Cells(colRegion.Index).Tag) & "' , " & _
                                " @DISTCD = '" & HandleSingleQuoteInSql(row.Cells(colProvince.Index).Tag) & "' , @AREACD = '" & HandleSingleQuoteInSql(row.Cells(colArea.Index).Tag) & "' , @TERRCD = '' , @CMGRP = '" & HandleSingleQuoteInSql(row.Cells(colCustomerClass.Index).Value) & "'  , @CMCLASS =  '' , " & _
                                " @AREACOVRG = " & IIf(row.Cells(col1Shared.Index).Value = True, "1", "0") & " ")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub dgCustomerWithoutTerritory_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCustomerWithoutTerritory.CellContentClick
        If e.RowIndex = -1 Then Exit Sub
        Dim row As DataGridViewRow = dgCustomerWithoutTerritory.Rows(e.RowIndex)
        Dim tag As New SelectionTag
        If e.ColumnIndex = colTerritory.Index Then
            '            tag = ShowSearchDialog("STACOVCD; STACOVCD; STACOVNAME;", "SELECT DISTINCT STACOVCD, STACOVCD [Area Coverage Code], STACOVNAME [Area Coverage Description] FROM SalesMatrix  WHERE DLTFLG = 0")
            tag = ShowSearchDialog("STACOVCD; STACOVCD; STACOVNAME;EffectivityStartDate; EffectivityEndDate;  ", "select STACOVCD, STACOVCD [Territory Code], STACOVNAME [Territory Name], EffectivityStartDate [Efectivity Start Date], EffectivityEndDate  [Effectivity End Date]  from STAREACOVERAGE where dltflg = 0   AND  CONVERT(VARCHAR(50), EffectivityStartDate,101) = '" & dtStart.Value.ToString("MM/dd/yyyy") & "'  AND CONVERT(VARCHAR(50),EffectivityEndDate,101) = '" & dtEnd.Value.ToString("MM/dd/yyyy") & "'   order by STACOVCD ")

            If Not tag Is Nothing Then
                row.Cells(colTerritory.Index).Value = tag.KeyColumn1 & " - " & tag.KeyColumn3
                row.Cells(colTerritory.Index).Tag = tag.KeyColumn1
            End If
        End If
    End Sub

    Private Sub lnkTerritory_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkTerritory.LinkClicked

        Dim tag As New SelectionTag

        '  tag = ShowSearchDialog("STACOVCD; STACOVCD; STACOVNAME;", "SELECT DISTINCT STACOVCD, STACOVCD [Area Coverage Code], STACOVNAME [Area Coverage Description] FROM SalesMatrix  WHERE DLTFLG = 0")
        tag = ShowSearchDialog("STACOVCD; STACOVCD; STACOVNAME;EffectivityStartDate; EffectivityEndDate;  ", "select STACOVCD, STACOVCD [Territory Code], STACOVNAME [Territory Name], EffectivityStartDate [Efectivity Start Date], EffectivityEndDate  [Effectivity End Date]  from STAREACOVERAGE where dltflg = 0   AND  CONVERT(VARCHAR(50), EffectivityStartDate,101) = '" & dtStart.Value.ToString("MM/dd/yyyy") & "'  AND CONVERT(VARCHAR(50),EffectivityEndDate,101) = '" & dtEnd.Value.ToString("MM/dd/yyyy") & "'   order by STACOVCD ")

        If Not tag Is Nothing Then
            txtTerritory.Text = tag.KeyColumn1 & " - " & tag.KeyColumn3
            txtTerritory.Tag = tag.KeyColumn1
        End If

    End Sub

    Private Sub LinkLabel8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        If txtTerritory.Text = "" Then Exit Sub
        If ShowQuestion("Are you sure you want to update selected customer?", "Update") = MsgBoxResult.Yes Then
            For m As Integer = 0 To dgCustomerWithoutTerritory.RowCount - 1
                Dim row As DataGridViewRow = dgCustomerWithoutTerritory.Rows(m)
                If row.Cells(col2Select.Index).Value = True Then
                    row.Cells(colTerritory.Index).Value = txtTerritory.Text
                    row.Cells(colTerritory.Index).Tag = txtTerritory.Tag
                End If
            Next
        End If
    End Sub

    Private Sub LinkLabel9_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        If ShowQuestion("Are you sure you want to add selected items?", "MapTerritory to Customer") = MsgBoxResult.Yes Then
            Dim ctr As Integer = 0
            For m As Integer = 0 To dgCustomerWithoutTerritory.Rows.Count - 1
                Dim row As DataGridViewRow = dgCustomerWithoutTerritory.Rows(m)
                If row.Cells(col2Select.Index).Value = True Then
                    ctr += 1
                    Exit For
                End If
            Next
            If ctr > 0 Then
                AddCustomerToTerritory()
            Else
                ShowExclamation("At least 1 checked detail is required.", "Save")
            End If
        End If
    End Sub

    Private Function CheckIfCustomerAlreadyMappedToTheTerrritory(ByVal row As DataGridViewRow) As Boolean
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT 'A' FROM CustomerMapping Where  DLTFLG = 0 AND CustomerCd = '" & row.Cells(col2CustomerCode.Index).Value & "' AND CDACD = '" & row.Cells(col2ShipTo.Index).Value & "' AND COMID = '" & cboCompany.Text & "'  AND AreaCovrg = '" & row.Cells(colTerritory.Index).Tag & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub AddCustomerToTerritory()
        m_ForDeletes.Clear()

        For m As Integer = 0 To dgCustomerWithoutTerritory.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerWithoutTerritory.Rows(m)
            If row.Cells(col2Select.Index).Value = True And row.Cells(colTerritory.Index).Value <> "Select Territory" Then
                If Not CheckIfCustomerAlreadyMappedToTheTerrritory(row) Then
                    AddCustomerToTerritory(row)
                End If
                m_ForDeletes.Add.ID = m
            End If
        Next

        For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
            dgCustomerWithoutTerritory.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next

        VDialog.Show("Record Successfully Saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub AddCustomerToTerritory(ByVal row As DataGridViewRow)

        Try
            SPMSConn.Execute("EXEC uspCustomerMapping  @Action = 'ADD' , @customergroupcd = '" & row.Cells(col2CustomerGroup.Index).Value & "' , @regcd = '" & row.Cells(col2Region.Index).Tag & "' ," & _
                                                            " @DistrctCd = '" & row.Cells(col2Province.Index).Tag & "' , @AreaCd = '" & row.Cells(col2Area.Index).Tag & "' , @ZipCd = '" & row.Cells(col2ZipCode.Index).Value & "' , " & _
                                                            " @CustomerCd = '" & row.Cells(col2CustomerCode.Index).Value & "' , @AreaCovrg= '" & row.Cells(colTerritory.Index).Tag & "' , @COMID = '" & cboCompany.Text & "' ,  " & _
                                                            " @CDACD = '" & HandleSingleQuoteInSql(row.Cells(col2ShipTo.Index).Value) & "' , @CDANAME = '" & HandleSingleQuoteInSql(row.Cells(col2ShipToName.Index).Value) & "' , " & _
                                                            " @EffectivityStartDate = '" & dtStart.Value.ToShortDateString & "' , @EffectivityEndDate = '" & dtEnd.Value.ToShortDateString & "' , @IsActive = 0 ")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Private Sub dgCustomerWithStateAreaTerritory_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCustomerWithStateAreaTerritory.CellContentClick
        If e.RowIndex = -1 Then Exit Sub
        Dim tag As New SelectionTag
        Dim row As DataGridViewRow = dgCustomerWithStateAreaTerritory.Rows(e.RowIndex)
        If e.ColumnIndex = col4Region.Index Then
            If row.Cells(col4Region.Index).Tag = True Then
                tag = ShowSearchDialog("REGCD; REGCD; REGNAME;", "SELECT REGCD, REGCD as [Region Code], REGNAME as [Region Name] FROM Region WHERE DLTFLG = 0")
                If Not tag Is Nothing Then
                    row.Cells(col4Region.Index).Value = tag.KeyColumn1
                    row.Cells(col4RegionName.Index).Value = tag.KeyColumn3
                End If
            End If
        ElseIf e.ColumnIndex = col4Province.Index Then
            If row.Cells(col4Province.Index).Tag = True Then
                If row.Cells(col4Region.Index).Value <> "Select Region" Then
                    If CheckIfRegionExist(row.Cells(col4Region.Index).Value) Then
                        tag = ShowSearchDialog("DISTRCTCD; DISTRCTCD;DISTRCTNAME;REGCD;", "SELECT DISTRCTCD, DistrctCD [Province Code], DISTRCTNAME [Province Description], REGCD [Region Code]  FROM DISTRICT WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(row.Cells(col4Region.Index).Value) & "' ")
                        If Not tag Is Nothing Then
                            row.Cells(col4Province.Index).Value = tag.KeyColumn1
                            row.Cells(col4ProvinceName.Index).Value = tag.KeyColumn3
                        End If
                    Else
                        ShowExclamation("There was no available Province for the selected area.", "Search")
                    End If
                End If
            End If
        ElseIf e.ColumnIndex = col4Municipality.Index Then
            If row.Cells(col4Municipality.Index).Tag = True Then
                If row.Cells(col4Region.Index).Value <> "Select Region" And row.Cells(col4Province.Index).Value <> "Select Province" Then
                    If CheckIfProvinceExist(row.Cells(col4Region.Index).Value, row.Cells(col4Province.Index).Value) Then
                        tag = ShowSearchDialog("AREACD; AREACD; AREANAME; REGCD; DISTRCTCD; ", "SELECT AREACD,AREACD [Municipality Code], AREANAME [Municipality Name], REGCD [Region Code], DISTRCTCD [District Code] FROM ARea WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(row.Cells(col4Region.Index).Value) & "' AND DISTRCTCD = '" & HandleSingleQuoteInSql(row.Cells(col4Province.Index).Value) & "' ")
                        If Not tag Is Nothing Then
                            row.Cells(col4Municipality.Index).Value = tag.KeyColumn1
                            row.Cells(col4MunicipalityName.Index).Value = tag.KeyColumn3
                        End If
                    Else
                        ShowExclamation("There was no available Municipality for the selected area.", "Search")
                    End If
                End If
            End If

        ElseIf e.ColumnIndex = col4ZipCode.Index Then
            If row.Cells(col4ZipCode.Index).Tag = True Then
                If row.Cells(col4Region.Index).Value <> "Select Region" And row.Cells(col4Province.Index).Value <> "Select Province" And row.Cells(col4Municipality.Index).Value <> "Select Municipality" Then
                    If CheckIfMunicipalityExist(row.Cells(col4Region.Index).Value, row.Cells(col4Province.Index).Value, row.Cells(col4Municipality.Index).Value) Then
                        tag = ShowSearchDialog("ZIPCD;ZIPCD; REGCD; DISTRCTCD; AREACD; AREANAME;", "SELECT ZIPCD, ZIPCD [Zip Code], RegCD [Region Code], DISTRCTCD [Province Code], AREACD [Municipality Code] , AREANAME [Municipality Code] FROM ZipCode WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(row.Cells(col4Region.Index).Value) & "' AND DISTRCTCD = '" & HandleSingleQuoteInSql(row.Cells(col4Province.Index).Value) & "' AND AREACD = '" & HandleSingleQuoteInSql(row.Cells(col4Municipality.Index).Value) & "' ")
                        If Not tag Is Nothing Then
                            row.Cells(col4ZipCode.Index).Value = tag.KeyColumn1
                        End If
                    Else
                        ShowExclamation("There was no available ZipCode for the selected area.", "Search")
                    End If
                End If
            End If
        End If

    End Sub

    Private Function CheckIfMunicipalityExist(ByVal RegionCode As String, ByVal ProvinceCode As String, ByVal MunicipalityCode As String) As Boolean
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM ZIPCODE WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(RegionCode) & "' AND DISTRCTCD = '" & HandleSingleQuoteInSql(ProvinceCode) & "' AND AREACD = '" & HandleSingleQuoteInSql(MunicipalityCode) & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function CheckIfRegionExist(ByVal RegionCode As String) As Boolean
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM Region WHERE REGCD = '" & HandleSingleQuoteInSql(RegionCode) & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function CheckIfProvinceExist(ByVal RegionCode As String, ByVal ProvinceCode As String) As Boolean
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM DISTRICT WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(RegionCode) & "' AND DISTRCTCD = '" & HandleSingleQuoteInSql(ProvinceCode) & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub dgItemsNotInSystem_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'If e.RowIndex = -1 Then Exit Sub
        'Dim row As DataGridViewRow = dgItemsNotInSystem.Rows(e.RowIndex)
        'Dim tag As New SelectionTag
        'If e.ColumnIndex = colItemCode.Index Then
        '    tag = ShowSearchDialog("ITEMCD; ITEMCD; IMDBRN;  IMDGEN; ", "SELECT ITEMCD, ITEMCD [Item Code], IMDBRN [Brand Name], IMDGEN [Generic Name] FROM ITEM WHERE ITEMDEL = 0")
        '    If Not tag Is Nothing Then
        '        row.Cells(colItemCode.Index).Value = tag.KeyColumn1
        '        row.Cells(colItemCode.Index).Tag = tag.KeyColumn1
        '        row.Cells(colItemDescription.Index).Value = tag.KeyColumn3
        '    End If

        'End If

    End Sub


    Private Function ValidateItemToBeSave() As Boolean
        'Dim m_HasError As Boolean = False

        'For m As Integer = 0 To dgItemsNotInSystem.RowCount - 1
        '    Dim row As DataGridViewRow = dgItemsNotInSystem.Rows(m)

        '    If row.Cells(col3Select.Index).Value = True Then
        '        If row.Cells(colItemCode.Index).Tag Is Nothing Then
        '            row.Cells(colItemCode.Index).Style.BackColor = Color.LightPink
        '            row.Cells(colItemCode.Index).ToolTipText = "Item is required."
        '            m_HasError = True
        '        Else
        '            If CheckIfItemExist(row.Cells(colItemCode.Index).Value, cboCompany.Text) Then
        '                row.Cells(colItemCode.Index).Style.BackColor = Color.LightPink
        '                row.Cells(colItemCode.Index).ToolTipText = "Item Code already had a maintained channel item code."
        '                m_HasError = True
        '            Else
        '                row.Cells(colItemCode.Index).Style.BackColor = row.DefaultCellStyle.BackColor
        '                row.Cells(colItemCode.Index).ToolTipText = String.Empty
        '            End If
        '        End If

        '        If row.Cells(colItemPrice.Index).Value Is Nothing Then
        '            row.Cells(colItemPrice.Index).Style.BackColor = Color.LightPink
        '            row.Cells(colItemPrice.Index).ToolTipText = "Price is required."
        '            m_HasError = True
        '        Else
        '            If Not IsNumeric(row.Cells(colItemPrice.Index).Value) Then
        '                row.Cells(colItemPrice.Index).Style.BackColor = Color.LightPink
        '                row.Cells(colItemPrice.Index).ToolTipText = "Value must be numeric"
        '                m_HasError = True
        '            Else
        '                row.Cells(colItemPrice.Index).Style.BackColor = row.DefaultCellStyle.BackColor
        '                row.Cells(colItemPrice.Index).ToolTipText = String.Empty
        '            End If

        '        End If
        '    End If
        'Next
        'Return Not m_HasError

    End Function

    Private Function ValidateCustomerStateAreaTerritoryUpdate() As Boolean
        Dim m_HasErrors As Boolean = False
        For m As Integer = 0 To dgCustomerWithStateAreaTerritory.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerWithStateAreaTerritory.Rows(m)
            If row.Cells(col4Select.Index).Value = True Then
                If row.Cells(col4Region.Index).Tag = True And row.Cells(col4Region.Index).Value = "Select Region" Then
                    row.Cells(col4Region.Index).Style.BackColor = Color.LightPink
                    row.Cells(col4Region.Index).ToolTipText = "Region is required."
                    m_HasErrors = True
                Else
                    row.Cells(col4Region.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                    row.Cells(col4Region.Index).ToolTipText = String.Empty
                End If
                If row.Cells(col4Province.Index).Tag = True And row.Cells(col4Province.Index).Value = "Select Province" Then
                    row.Cells(col4Province.Index).Style.BackColor = Color.LightPink
                    row.Cells(col4Province.Index).ToolTipText = "Province is required."
                    m_HasErrors = True
                Else
                    row.Cells(col4Province.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                    row.Cells(col4Province.Index).ToolTipText = String.Empty
                End If
                If row.Cells(col4Municipality.Index).Tag = True And row.Cells(col4Municipality.Index).Value = "Select Municipality" Then
                    row.Cells(col4Municipality.Index).Style.BackColor = Color.LightPink
                    row.Cells(col4Municipality.Index).ToolTipText = "Municipality is required."
                    m_HasErrors = True
                Else
                    row.Cells(col4Municipality.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                    row.Cells(col4Municipality.Index).ToolTipText = String.Empty
                End If
                If row.Cells(col4ZipCode.Index).Tag = True And row.Cells(col4ZipCode.Index).Value = "Select ZipCode" Then
                    row.Cells(col4ZipCode.Index).Style.BackColor = Color.LightPink
                    row.Cells(col4ZipCode.Index).ToolTipText = "ZipCode is required."
                    m_HasErrors = True
                Else
                    row.Cells(col4ZipCode.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                    row.Cells(col4ZipCode.Index).ToolTipText = String.Empty
                End If
            End If
        Next
        Return Not m_HasErrors
    End Function


    Private Sub lnkWithoutAgent_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkWithoutAgent.LinkClicked
        MainTab.SelectedTab = tbListing
        tbPages.SelectedTab = TabPage5
    End Sub

    Private Sub lnkSharing_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSharing.LinkClicked
        MainTab.SelectedTab = tbListing
        tbPages.SelectedTab = TabPage6
    End Sub
    Private Function CheckIfItemExist(ByVal ItemCode As String, ByVal DistributorCode As String) As Boolean
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM DistributorItems WHERE  ITEMCD = '" & HandleSingleQuoteInSql(ItemCode) & "' AND COMID = '" & HandleSingleQuoteInSql(DistributorCode) & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SaveItemsNotInTheSystem()
        'm_ForDeletes.Clear()
        'For m As Integer = 0 To dgItemsNotInSystem.Rows.Count - 1
        '    Dim row As DataGridViewRow = dgItemsNotInSystem.Rows(m)
        '    If row.Cells(col3Select.Index).Value = True Then
        '        SaveItemsNotInTheSystem(row)
        '        m_ForDeletes.Add.ID = m
        '    End If
        'Next

        'For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
        '    dgItemsNotInSystem.Rows.RemoveAt(m_ForDeletes(m).ID)
        'Next

        'ShowInformation("Record Successfully Saved", "Save")
    End Sub

    Private Sub SaveItemsNotInTheSystem(ByVal row As DataGridViewRow)

        'Try

        '    SPMSConn.Execute("EXEC uspDistributorItems @Action = 'SAVE' , @COMID = '" & cboCompany.Text & "' ,  @ITEMCD = '" & HandleSingleQuoteInSql(row.Cells(colItemCode.Index).Value) & "' , @DISTITEMCD = '" & HandleSingleQuoteInSql(row.Cells(colChannelItemCode.Index).Value) & "' , " & _
        '            " @ITEMNAME = '" & HandleSingleQuoteInSql(row.Cells(colChannelItemDesc.Index).Value) & "'  , @DISTITEMPRICE =  " & row.Cells(colItemPrice.Index).Value & " ," & _
        '             "  @EFFECTIVITYSTARTDATE = '" & dtStart.Value.ToShortDateString & "' ,  @EFFECTIVITYENDDATE = '" & dtEnd.Value.ToShortDateString & "' , @IsActive = 0")

        'Catch ex As Exception
        '    Throw New Exception(ex.Message)
        'End Try

    End Sub

    Private Sub UpdateCustomersStateAreaTerritory()
        m_ForDeletes.Clear()

        For m As Integer = 0 To dgCustomerWithStateAreaTerritory.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerWithStateAreaTerritory.Rows(m)
            If row.Cells(col4Select.Index).Value = True Then
                UpdateCustomersStateAreaTerritory(row)
                m_ForDeletes.Add.ID = m
            End If

        Next

        For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
            dgCustomerWithStateAreaTerritory.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next

        VDialog.Show("Record Successfully Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub UpdateCustomersStateAreaTerritory(ByVal row As DataGridViewRow)
        Try
            Dim rs As New ADODB.Recordset

            If rs.State = 1 Then rs.Close()
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.Open("SELECT * FROM Customer WHERE CustomerDEL = 0 AND CustomerCD = '" & HandleSingleQuoteInSql(row.Cells(col4CustomerCode.Index).Value) & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If rs.RecordCount > 0 Then
                For m As Integer = 0 To rs.RecordCount - 1
                    rs.Fields("REGCD").Value = row.Cells(col4Region.Index).Value
                    rs.Fields("DISTCD").Value = row.Cells(col4Province.Index).Value
                    rs.Fields("AREACD").Value = row.Cells(col4Municipality.Index).Value
                    rs.Fields("ZIPCD").Value = row.Cells(col4ZipCode.Index).Value
                    rs.Update()
                    rs.MoveNext()

                    UpdateShipToCustomerWithStateAreaTerritory(cboCompany.Text, "001", row.Cells(col4CustomerCode.Index).Value, row.Cells(col4Region.Index).Value, row.Cells(col4Province.Index).Value, row.Cells(col4Municipality.Index).Value, row.Cells(col4ZipCode.Index).Value)

                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub LinkLabel11_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked
        Dim q As MsgBoxResult
        q = VDialog.Show("Are you sure you want to update selected customers?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If q = MsgBoxResult.Yes Then
            Dim ctr As Integer = 0
            For m As Integer = 0 To dgCustomerWithStateAreaTerritory.Rows.Count - 1
                Dim row As DataGridViewRow = dgCustomerWithStateAreaTerritory.Rows(m)
                If row.Cells(colSelect.Index).Value = True Then
                    ctr += 1
                    Exit For
                End If
            Next
            If ctr > 0 Then
                If ValidateCustomerStateAreaTerritoryUpdate() Then
                    UpdateCustomersStateAreaTerritory()
                End If
            Else
                ShowExclamation("At least 1 checked detail is required", "Update")
            End If
        End If
    End Sub

    'Private Sub LinkLabel10_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    '    If ShowQuestion("Are you sure you want to add selected items?", "Add Item") = MsgBoxResult.Yes Then
    '        Dim ctr As Integer = 0
    '        For m As Integer = 0 To dgItemsNotInSystem.Rows.Count - 1
    '            Dim row As DataGridViewRow = dgItemsNotInSystem.Rows(m)
    '            If row.Cells(colSelect.Index).Value = True Then
    '                ctr += 1
    '                Exit For
    '            End If
    '        Next
    '        If ctr > 0 Then
    '            If ValidateItemToBeSave() Then
    '                SaveItemsNotInTheSystem()
    '            End If
    '        Else
    '            ShowExclamation("At least 1 checked detail is required.", "Save")
    '        End If
    '    End If
    'End Sub

    Private Sub dgItemsNotInSystem_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'If e.RowIndex = -1 Then Exit Sub

        'Dim row As DataGridViewRow = dgItemsNotInSystem.Rows(e.RowIndex)
        'If e.ColumnIndex = colItemPrice.Index Then
        '    If IsNumeric(row.Cells(colItemPrice.Index).Value) Then
        '        Dim amt As Double = row.Cells(colItemPrice.Index).Value
        '        row.Cells(colItemPrice.Index).Value = amt.ToString("#,##0.0000")
        '    Else
        '        row.Cells(colItemPrice.Index).Value = "0.0000"
        '    End If

        'End If

    End Sub

    Private Sub dgUnmappedCustomers_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgUnmappedCustomers.CellContentClick
        If e.RowIndex = -1 Then Exit Sub

        Dim row As DataGridViewRow = dgUnmappedCustomers.Rows(e.RowIndex)
        Dim tag As New SelectionTag
        If e.ColumnIndex = col5Region.Index Then
            '   If row.Cells(col5Region.Index).Tag = True Then
            tag = ShowSearchDialog("REGCD; REGCD; REGNAME;", "SELECT REGCD, REGCD as [Region Code], REGNAME as [Region Name] FROM Region WHERE DLTFLG = 0")
            If Not tag Is Nothing Then
                row.Cells(col5Region.Index).Tag = tag.KeyColumn1
                row.Cells(col5Region.Index).Value = tag.KeyColumn3
            End If
            'End If
        ElseIf e.ColumnIndex = col5Province.Index Then
            'If row.Cells(col5Province.Index).Tag = True Then
            If row.Cells(col5Region.Index).Value <> "Select Region" Then
                If CheckIfRegionExist(row.Cells(col5Region.Index).Tag) Then
                    tag = ShowSearchDialog("DISTRCTCD; REGCD;DISTRCTCD;DISTRCTNAME;", "SELECT DISTRCTCD, REGCD [Region Code], DistrctCD [Province Code], DISTRCTNAME [Province Description] FROM DISTRICT WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(row.Cells(col5Region.Index).Tag) & "' ")
                    If Not tag Is Nothing Then

                        row.Cells(col5Province.Index).Tag = tag.KeyColumn1
                        row.Cells(col5Province.Index).Value = Trim(tag.KeyColumn4)
                    End If
                Else
                    ShowExclamation("There was no available Province for the selected area.", "Search")
                End If
                'End If
            End If
        ElseIf e.ColumnIndex = col5Municipality.Index Then
            ' If row.Cells(col5Municipality.Index).Tag = True Then

            If CheckIfProvinceExist(row.Cells(col5Region.Index).Tag, row.Cells(col5Province.Index).Tag) Then
                tag = ShowSearchDialog("AREACD; AREACD; AREANAME; REGCD; DISTRCTCD; ", "SELECT AREACD,AREACD [Municipality Code], AREANAME [Municipality Name], REGCD [Region Code], DISTRCTCD [District Code] FROM ARea WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(row.Cells(col5Region.Index).Tag) & "' AND DISTRCTCD = '" & HandleSingleQuoteInSql(row.Cells(col5Province.Index).Tag) & "' ")
                If Not tag Is Nothing Then
                    row.Cells(col5Municipality.Index).Tag = tag.KeyColumn1
                    row.Cells(col5Municipality.Index).Value = Trim(tag.KeyColumn3)
                End If
            Else
                ShowExclamation("There was no available Municipality for the selected area.", "Search")
            End If
            '  End If

        ElseIf e.ColumnIndex = col5ZipCode.Index Then
            '      If row.Cells(col5ZipCode.Index).Tag = True Then
            If CheckIfMunicipalityExist(row.Cells(col5Region.Index).Tag, row.Cells(col5Province.Index).Tag, row.Cells(col5Municipality.Index).Tag) Then
                tag = ShowSearchDialog("ZIPCD;ZIPCD; REGCD; DISTRCTCD; AREACD; AREANAME;", "SELECT ZIPCD, ZIPCD [Zip Code], RegCD [Region Code], DISTRCTCD [Province Code], AREACD [Municipality Code] , AREANAME [Municipality Code] FROM ZipCode WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(row.Cells(col5Region.Index).Tag) & "' AND DISTRCTCD = '" & HandleSingleQuoteInSql(row.Cells(col5Province.Index).Tag) & "' AND AREACD = '" & HandleSingleQuoteInSql(row.Cells(col5Municipality.Index).Tag) & "' ")
                If Not tag Is Nothing Then
                    row.Cells(col5ZipCode.Index).Value = tag.KeyColumn1
                End If
            Else
                ShowExclamation("There was no available ZipCode for the selected area.", "Search")
            End If
            'End If
        End If

    End Sub

    Private Sub UpdateUnmappedCustomers()
        m_ForDeletes.Clear()

        For m As Integer = 0 To dgUnmappedCustomers.RowCount - 1
            Dim row As DataGridViewRow = dgUnmappedCustomers.Rows(m)
            If row.Cells(col5Select.Index).Value = True Then
                UpdateUnmappedCustomers(row)
                m_ForDeletes.Add.ID = m
            End If
        Next

        For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
            dgUnmappedCustomers.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next

        VDialog.Show("Record Successfully Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub UpdateUnmappedCustomers(ByVal row As DataGridViewRow)
        Try
            Dim rs As New ADODB.Recordset

            If rs.State = 1 Then rs.Close()
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.Open("SELECT * FROM Customer WHERE CustomerDEL = 0 AND CustomerCD = '" & HandleSingleQuoteInSql(row.Cells(col5CustomerCode.Index).Value) & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If rs.RecordCount > 0 Then
                For m As Integer = 0 To rs.RecordCount - 1
                    rs.Fields("REGCD").Value = row.Cells(col5Region.Index).Tag
                    rs.Fields("DISTCD").Value = row.Cells(col5Province.Index).Tag
                    rs.Fields("AREACD").Value = row.Cells(col5Municipality.Index).Tag
                    rs.Fields("ZIPCD").Value = row.Cells(col5ZipCode.Index).Value
                    rs.Update()
                    rs.MoveNext()

                    UpdateShipToCustomerWithStateAreaTerritory(cboCompany.Text, "001", row.Cells(col5CustomerCode.Index).Value, row.Cells(col4Region.Index).Value, row.Cells(col5Province.Index).Tag, row.Cells(col5Municipality.Index).Tag, row.Cells(col5ZipCode.Index).Value)

                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub LinkLabel14_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel14.LinkClicked
        Dim q As MsgBoxResult

        VDialog.Show("Are you sure you want to update selected customers?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If q = MsgBoxResult.Yes Then
            Dim ctr As Integer = 0
            For m As Integer = 0 To dgUnmappedCustomers.Rows.Count - 1
                Dim row As DataGridViewRow = dgUnmappedCustomers.Rows(m)
                If row.Cells(colSelect.Index).Value = True Then
                    ctr += 1
                    Exit For
                End If
            Next
            If ctr > 0 Then
                UpdateUnmappedCustomers()
            Else
                ShowExclamation("At least 1 detail is required.", "Update")
            End If

        End If
    End Sub

    Private Sub LinkLabel16_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel16.LinkClicked
        For m As Integer = 0 To dgUnmappedCustomers.RowCount - 1
            Dim row As DataGridViewRow = dgUnmappedCustomers.Rows(m)
            row.Cells(col5Select.Index).Value = True
        Next
    End Sub

    Private Sub LinkLabel13_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel13.LinkClicked
        For m As Integer = 0 To dgCustomerWithStateAreaTerritory.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerWithStateAreaTerritory.Rows(m)
            row.Cells(col4Select.Index).Value = True
        Next
    End Sub

    Private Sub LinkLabel12_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel12.LinkClicked
        For m As Integer = 0 To dgCustomerWithStateAreaTerritory.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerWithStateAreaTerritory.Rows(m)
            row.Cells(col4Select.Index).Value = False
        Next
    End Sub

    Private Sub LinkLabel15_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel15.LinkClicked
        For m As Integer = 0 To dgUnmappedCustomers.RowCount - 1
            Dim row As DataGridViewRow = dgUnmappedCustomers.Rows(m)
            row.Cells(col5Select.Index).Value = False
        Next
    End Sub

    Private Sub cboCalendarYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCalendarYear.SelectedIndexChanged
        If cboCalendarYear.SelectedIndex <> -1 Then
            LoadMonth(cboCompany.Text, cboCalendarYear.Text)
        End If
    End Sub
    Private Sub cboMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMonth.SelectedIndexChanged
        GetMonthDescription(cboCompany.Text, cboCalendarYear.Text, cboMonth.Text)
    End Sub
    Private Sub GetMonthDescription(ByVal DistributorCode As String, ByVal Year As String, ByVal MonthCode As String)
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT MonthDescription FROM Calendar Where COMID = '" & DistributorCode & "' AND CAYR = '" & Year & "'   AND CAPN = '" & MonthCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            txtMonthDescription.Text = rs.Fields("MonthDescription").Value
            '   GetBatchNo(DistributorCode, MonthCode, Year)
        Else
            txtMonthDescription.Text = ""
        End If

    End Sub

    Private Sub GetBatchNo(ByVal CompanyCode As String, ByVal CutMo As String, ByVal CutYear As String)
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT TOP 1 * FROM UPLOADEDRAWDATA WHERE COMPANYCODE = '" & CompanyCode & "' AND CUTYEAR =  '" & CutYear & "'  AND CUTMO = '" & CutMo & "' ORDER BY UPLOADDATE DESC", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            lblBatchNo.Text = rs.Fields("CheckFileName").Value
        Else
            lblBatchNo.Text = ""
        End If

    End Sub

    Private Sub dgCustomerNotintheSystem_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCustomerNotintheSystem.CellContentClick
        If e.RowIndex = -1 Then Exit Sub
        Dim row As DataGridViewRow = dgCustomerNotintheSystem.Rows(e.RowIndex)



        If cboCompany.Text = "MER" Then
            Dim tag As New SelectionTag
            If e.ColumnIndex = colCustomerClass.Index Then

                tag = ShowSearchDialog("CUSTOMERGROUPCD; CUSTOMERGROUPCD; CUSTOMERGROUPNAME; ", "SELECT CUSTOMERGROUPCD, CUSTOMERGROUPCD [Customer Group Code], CUSTOMERGROUPNAME [Customer Group Name] FROM CUSTOMERGROUP WHERE DLTFLG = 0")
                If Not tag Is Nothing Then
                    row.Cells(colCustomerClass.Index).Value = tag.KeyColumn1
                End If

            ElseIf e.ColumnIndex = colRegion.Index Then

                tag = ShowSearchDialog("REGCD; REGCD; REGNAME;", "SELECT REGCD, REGCD as [Region Code], REGNAME as [Region Name] FROM Region WHERE DLTFLG = 0")
                If Not tag Is Nothing Then
                    row.Cells(colRegion.Index).Tag = tag.KeyColumn1
                    row.Cells(colRegion.Index).Value = tag.KeyColumn3
                End If

            ElseIf e.ColumnIndex = colProvince.Index Then

                If row.Cells(colRegion.Index).Value <> "Select Region" Then
                    If CheckIfRegionExist(row.Cells(colRegion.Index).Value) Then
                        tag = ShowSearchDialog("DISTRCTCD; REGCD;DISTRCTCD;DISTRCTNAME;", "SELECT DISTRCTCD, REGCD [Region Code], DistrctCD [Province Code], DISTRCTNAME [Province Description] FROM DISTRICT WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(row.Cells(colRegion.Index).Tag) & "' ")
                        If Not tag Is Nothing Then
                            row.Cells(colProvince.Index).Tag = tag.KeyColumn1
                            row.Cells(colProvince.Index).Value = tag.KeyColumn4
                        End If
                    Else
                        VDialog.Show("There was no available Province for the selected area.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If

            ElseIf e.ColumnIndex = colArea.Index Then


                If CheckIfProvinceExist(row.Cells(colRegion.Index).Value, row.Cells(colProvince.Index).Value) Then
                    tag = ShowSearchDialog("AREACD; AREACD; AREANAME; REGCD; DISTRCTCD; ", "SELECT AREACD,AREACD [Municipality Code], AREANAME [Municipality Name], REGCD [Region Code], DISTRCTCD [District Code] FROM ARea WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(row.Cells(colRegion.Index).Tag) & "' AND DISTRCTCD = '" & HandleSingleQuoteInSql(row.Cells(colProvince.Index).Tag) & "' ")
                    If Not tag Is Nothing Then
                        row.Cells(colArea.Index).Tag = tag.KeyColumn1
                        row.Cells(colArea.Index).Value = tag.KeyColumn3
                    End If
                Else
                    VDialog.Show("There was no available Municipality for the selected area.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            ElseIf e.ColumnIndex = colZipCode.Index Then

                If CheckIfMunicipalityExist(row.Cells(colRegion.Index).Value, row.Cells(colProvince.Index).Value, row.Cells(colArea.Index).Value) Then
                    tag = ShowSearchDialog("ZIPCD;ZIPCD; REGCD; DISTRCTCD; AREACD; AREANAME;", "SELECT ZIPCD, ZIPCD [Zip Code], RegCD [Region Code], DISTRCTCD [Province Code], AREACD [Municipality Code] , AREANAME [Municipality Code] FROM ZipCode WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(row.Cells(colRegion.Index).Tag) & "' AND DISTRCTCD = '" & HandleSingleQuoteInSql(row.Cells(colProvince.Index).Tag) & "' AND AREACD = '" & HandleSingleQuoteInSql(row.Cells(colArea.Index).Tag) & "' ")
                    If Not tag Is Nothing Then
                        row.Cells(colZipCode.Index).Value = tag.KeyColumn1
                    End If
                Else
                    VDialog.Show ("There was no available ZipCode for the selected area.", "Search",MessageBoxButtons.OK,MessageBoxIcon.Warning  )
                End If
            End If

        Else


            If e.RowIndex = -1 Then Exit Sub
            Dim tag As New SelectionTag
            Dim rows As DataGridViewRow = dgCustomerNotintheSystem.Rows(e.RowIndex)
            If e.ColumnIndex = colRegion.Index Then
                ' If rows.Cells(colRegion.Index).Tag = True Then
                tag = ShowSearchDialog("REGCD; REGCD; REGNAME;", "SELECT REGCD, REGCD as [Region Code], REGNAME as [Region Name] FROM Region WHERE DLTFLG = 0")
                If Not tag Is Nothing Then
                    rows.Cells(colRegion.Index).Tag = tag.KeyColumn1
                    rows.Cells(colRegion.Index).Value = tag.KeyColumn3
                End If
                'End If
            ElseIf e.ColumnIndex = colProvince.Index Then
                'If rows.Cells(colProvince.Index).Tag = True Then
                If rows.Cells(colRegion.Index).Value <> "Select Region" Then
                    If CheckIfRegionExist(rows.Cells(colRegion.Index).Tag) Then
                        tag = ShowSearchDialog("DISTRCTCD; DISTRCTCD;DISTRCTNAME;REGCD;", "SELECT DISTRCTCD, DistrctCD [Province Code], DISTRCTNAME [Province Description], REGCD [Region Code]  FROM DISTRICT WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(rows.Cells(colRegion.Index).Tag) & "' ")
                        If Not tag Is Nothing Then
                            rows.Cells(colProvince.Index).Tag = tag.KeyColumn1
                            rows.Cells(colProvince.Index).Value = tag.KeyColumn3
                        End If
                    Else
                        VDialog.Show("There was no available Province for the selected area.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
                'End If
            ElseIf e.ColumnIndex = colArea.Index Then
                ' If rows.Cells(colArea.Index).Tag = True Then
                If rows.Cells(colRegion.Index).Value <> "Select Region" And rows.Cells(colProvince.Index).Value <> "Select Province" Then
                    If CheckIfProvinceExist(rows.Cells(colRegion.Index).Tag, rows.Cells(colProvince.Index).Tag) Then
                        tag = ShowSearchDialog("AREACD; AREACD; AREANAME; REGCD; DISTRCTCD; ", "SELECT AREACD,AREACD [Municipality Code], AREANAME [Municipality Name], REGCD [Region Code], DISTRCTCD [District Code] FROM ARea WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(rows.Cells(colRegion.Index).Tag) & "' AND DISTRCTCD = '" & HandleSingleQuoteInSql(rows.Cells(colProvince.Index).Tag) & "' ")
                        If Not tag Is Nothing Then
                            rows.Cells(colArea.Index).Tag = tag.KeyColumn1
                            rows.Cells(col4MunicipalityName.Index).Value = tag.KeyColumn3
                        End If
                    Else
                        VDialog.Show("There was no available Municipality for the selected area.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
                'End If

            ElseIf e.ColumnIndex = colZipCode.Index Then
                'If rows.Cells(colZipCode.Index).Tag = True Then
                If rows.Cells(colRegion.Index).Value <> "Select Region" And rows.Cells(colProvince.Index).Value <> "Select Province" And rows.Cells(colArea.Index).Value <> "Select Municipality" Then
                    If CheckIfMunicipalityExist(rows.Cells(colRegion.Index).Tag, rows.Cells(colProvince.Index).Tag, rows.Cells(colArea.Index).Tag) Then
                        tag = ShowSearchDialog("ZIPCD;ZIPCD; REGCD; DISTRCTCD; AREACD; AREANAME;", "SELECT ZIPCD, ZIPCD [Zip Code], RegCD [Region Code], DISTRCTCD [Province Code], AREACD [Municipality Code] , AREANAME [Municipality Code] FROM ZipCode WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(rows.Cells(colRegion.Index).Tag) & "' AND DISTRCTCD = '" & HandleSingleQuoteInSql(rows.Cells(colProvince.Index).Tag) & "' AND AREACD = '" & HandleSingleQuoteInSql(rows.Cells(colArea.Index).Tag) & "' ")
                        If Not tag Is Nothing Then
                            rows.Cells(colZipCode.Index).Tag = tag.KeyColumn1
                            rows.Cells(colZipCode.Index).Value = tag.KeyColumn1
                        End If
                    Else
                        VDialog.Show("There was no available ZipCode for the selected area.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
                'End If
            End If

        End If

    End Sub

    Private Sub LinkLabel17_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel17.LinkClicked
        MainTab.SelectedTab = tbListing
        tbPages.SelectedTab = TabPage7
    End Sub

    Private Sub dgShipToCustomer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgShipToCustomer.CellContentClick
        If e.RowIndex = -1 Then Exit Sub
        Dim tag As New SelectionTag
        Dim row As DataGridViewRow = dgShipToCustomer.Rows(e.RowIndex)
        If e.ColumnIndex = col6Region.Index Then
            If row.Cells(col6Region.Index).Tag = True Then
                tag = ShowSearchDialog("REGCD; REGCD; REGNAME;", "SELECT REGCD, REGCD as [Region Code], REGNAME as [Region Name] FROM Region WHERE DLTFLG = 0")
                If Not tag Is Nothing Then
                    row.Cells(col6Region.Index).Value = tag.KeyColumn1
                    row.Cells(col6RegionName.Index).Value = tag.KeyColumn3
                End If
            End If
        ElseIf e.ColumnIndex = col6Province.Index Then
            If row.Cells(col6Province.Index).Tag = True Then
                If row.Cells(col6Region.Index).Value <> "Select Region" Then
                    If CheckIfRegionExist(row.Cells(col6Region.Index).Value) Then
                        tag = ShowSearchDialog("DISTRCTCD; DISTRCTCD;DISTRCTNAME;REGCD;", "SELECT DISTRCTCD, DistrctCD [Province Code], DISTRCTNAME [Province Description], REGCD [Region Code]  FROM DISTRICT WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(row.Cells(col6Region.Index).Value) & "' ")
                        If Not tag Is Nothing Then
                            row.Cells(col6Province.Index).Value = tag.KeyColumn1
                            row.Cells(col6ProvinceName.Index).Value = tag.KeyColumn3
                        End If
                    Else
                        VDialog.Show("There was no available Province for the selected area.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            End If
        ElseIf e.ColumnIndex = col6Municipality.Index Then
            If row.Cells(col6Municipality.Index).Tag = True Then
                If row.Cells(col6Region.Index).Value <> "Select Region" And row.Cells(col6Province.Index).Value <> "Select Province" Then
                    If CheckIfProvinceExist(row.Cells(col6Region.Index).Value, row.Cells(col6Province.Index).Value) Then
                        tag = ShowSearchDialog("AREACD; AREACD; AREANAME; REGCD; DISTRCTCD; ", "SELECT AREACD,AREACD [Municipality Code], AREANAME [Municipality Name], REGCD [Region Code], DISTRCTCD [District Code] FROM ARea WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(row.Cells(col6Region.Index).Value) & "' AND DISTRCTCD = '" & HandleSingleQuoteInSql(row.Cells(col6Province.Index).Value) & "' ")
                        If Not tag Is Nothing Then
                            row.Cells(col6Municipality.Index).Value = tag.KeyColumn1
                            row.Cells(col6MunicipalityName.Index).Value = tag.KeyColumn3
                        End If
                    Else
                        VDialog.Show("There was no available Municipality for the selected area.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            End If

        ElseIf e.ColumnIndex = col6ZipCode.Index Then
            If row.Cells(col6ZipCode.Index).Tag = True Then
                If row.Cells(col6Region.Index).Value <> "Select Region" And row.Cells(col6Province.Index).Value <> "Select Province" And row.Cells(col6Municipality.Index).Value <> "Select Municipality" Then
                    If CheckIfMunicipalityExist(row.Cells(col6Region.Index).Value, row.Cells(col6Province.Index).Value, row.Cells(col6Municipality.Index).Value) Then
                        tag = ShowSearchDialog("ZIPCD;ZIPCD; REGCD; DISTRCTCD; AREACD; AREANAME;", "SELECT ZIPCD, ZIPCD [Zip Code], RegCD [Region Code], DISTRCTCD [Province Code], AREACD [Municipality Code] , AREANAME [Municipality Code] FROM ZipCode WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(row.Cells(col6Region.Index).Value) & "' AND DISTRCTCD = '" & HandleSingleQuoteInSql(row.Cells(col6Province.Index).Value) & "' AND AREACD = '" & HandleSingleQuoteInSql(row.Cells(col6Municipality.Index).Value) & "' ")
                        If Not tag Is Nothing Then
                            row.Cells(col6ZipCode.Index).Value = tag.KeyColumn1
                        End If
                    Else
                        VDialog.Show("There was no available ZipCode for the selected area.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub LinkLabel20_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel20.LinkClicked
        For m As Integer = 0 To dgShipToCustomer.RowCount - 1
            Dim row As DataGridViewRow = dgShipToCustomer.Rows(m)
            row.Cells(col6Select.Index).Value = True
        Next
    End Sub

    Private Sub LinkLabel19_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel19.LinkClicked
        For m As Integer = 0 To dgShipToCustomer.RowCount - 1
            Dim row As DataGridViewRow = dgShipToCustomer.Rows(m)
            row.Cells(col6Select.Index).Value = False
        Next
    End Sub

    Private Function ValidateShipToCustomerWithStateAreaTerritoryProblemUpdate() As Boolean
        Dim m_HasErrors As Boolean = False
        For m As Integer = 0 To dgShipToCustomer.RowCount - 1
            Dim row As DataGridViewRow = dgShipToCustomer.Rows(m)
            If row.Cells(col6Select.Index).Value = True Then
                If row.Cells(col6Region.Index).Tag = True And row.Cells(col6Region.Index).Value = "Select Region" Then
                    row.Cells(col6Region.Index).Style.BackColor = Color.LightPink
                    row.Cells(col6Region.Index).ToolTipText = "Region is required."
                    m_HasErrors = True
                Else
                    row.Cells(col6Region.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                    row.Cells(col6Region.Index).ToolTipText = String.Empty
                End If
                If row.Cells(col6Province.Index).Tag = True And row.Cells(col6Province.Index).Value = "Select Province" Then
                    row.Cells(col6Province.Index).Style.BackColor = Color.LightPink
                    row.Cells(col6Province.Index).ToolTipText = "Province is required."
                    m_HasErrors = True
                Else
                    row.Cells(col6Province.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                    row.Cells(col6Province.Index).ToolTipText = String.Empty
                End If
                If row.Cells(col6Municipality.Index).Tag = True And row.Cells(col6Municipality.Index).Value = "Select Municipality" Then
                    row.Cells(col6Municipality.Index).Style.BackColor = Color.LightPink
                    row.Cells(col6Municipality.Index).ToolTipText = "Municipality is required."
                    m_HasErrors = True
                Else
                    row.Cells(col6Municipality.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                    row.Cells(col6Municipality.Index).ToolTipText = String.Empty
                End If
                If row.Cells(col6ZipCode.Index).Tag = True And row.Cells(col6ZipCode.Index).Value = "Select ZipCode" Then
                    row.Cells(col6ZipCode.Index).Style.BackColor = Color.LightPink
                    row.Cells(col6ZipCode.Index).ToolTipText = "ZipCode is required."
                    m_HasErrors = True
                Else
                    row.Cells(col6ZipCode.Index).Style.BackColor = row.DefaultCellStyle.BackColor
                    row.Cells(col6ZipCode.Index).ToolTipText = String.Empty
                End If
            End If
        Next
        Return Not m_HasErrors
    End Function

    Private Sub LinkLabel18_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel18.LinkClicked
        Dim q As MsgBoxResult
        q = VDialog.Show("Are you sure you want to update selected customers?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If q = MsgBoxResult.Yes Then
            Dim ctr As Integer = 0
            For m As Integer = 0 To dgShipToCustomer.Rows.Count - 1
                Dim row As DataGridViewRow = dgShipToCustomer.Rows(m)
                If row.Cells(col6Select.Index).Value = True Then
                    ctr += 1
                    Exit For
                End If
            Next
            If ctr > 0 Then
                If ValidateShipToCustomerWithStateAreaTerritoryProblemUpdate() Then
                    UpdateShipToCustomerWithStateAreaTerritory()
                End If
            Else
                ShowExclamation("At least 1 checked detail is required.", "Save")
            End If
        End If

    End Sub

    Private Sub UpdateShipToCustomerWithStateAreaTerritory()
        m_ForDeletes.Clear()

        For m As Integer = 0 To dgShipToCustomer.Rows.Count - 1
            Dim row As DataGridViewRow = dgShipToCustomer.Rows(m)
            If row.Cells(col6Select.Index).Value = True Then
                UpdateShipToCustomerWithStateAreaTerritory(row)
                m_ForDeletes.Add.ID = m
            End If
        Next

        For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
            dgShipToCustomer.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next

        ShowInformation("Record Sucessfully Updated.", "Update")

    End Sub

    Private Sub UpdateShipToCustomerWithStateAreaTerritory(ByVal CompanyCode As String, ByVal ShipToCode As String, ByVal CustomerCode As String, ByVal RegionCode As String, ByVal ProvinceCode As String, ByVal AreaCode As String, ByVal ZipCode As String)
        Try
            Dim rs As New ADODB.Recordset

            If rs.State = 1 Then rs.Close()
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.Open("SELECT * FROM CustomerShipTo WHERE CustomerShipTODEL = 0  AND COMID = '" & CompanyCode & "'   AND CUSTOMERCD = '" & HandleSingleQuoteInSql(CustomerCode) & "'  AND CDACD = '" & HandleSingleQuoteInSql(ShipToCode) & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If rs.RecordCount > 0 Then
                For m As Integer = 0 To rs.RecordCount - 1
                    rs.Fields("REGCD").Value = RegionCode
                    rs.Fields("DISTCD").Value = ProvinceCode
                    rs.Fields("AREACD").Value = AreaCode
                    rs.Fields("ZIPCD").Value = ZipCode
                    rs.Update()
                    rs.MoveNext()
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub UpdateShipToCustomerWithStateAreaTerritory(ByVal row As DataGridViewRow)
        Try
            Dim rs As New ADODB.Recordset

            If rs.State = 1 Then rs.Close()
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.Open("SELECT * FROM CustomerShipTo WHERE CustomerShipTODEL = 0  AND COMID = '" & cboCompany.Text & "'   AND CUSTOMERCD = '" & HandleSingleQuoteInSql(row.Cells(col6CustomerCode.Index).Value) & "'  AND CDACD = '" & HandleSingleQuoteInSql(row.Cells(col6ShipToCode.Index).Value) & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If rs.RecordCount > 0 Then
                For m As Integer = 0 To rs.RecordCount - 1
                    rs.Fields("REGCD").Value = row.Cells(col6Region.Index).Value
                    rs.Fields("DISTCD").Value = row.Cells(col6Province.Index).Value
                    rs.Fields("AREACD").Value = row.Cells(col6Municipality.Index).Value
                    rs.Fields("ZIPCD").Value = row.Cells(col6ZipCode.Index).Value
                    rs.Update()
                    rs.MoveNext()
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub LinkLabel21_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel21.LinkClicked
        If ShowQuestion("Are you sure you want to update selected items to default?", "Update") = MsgBoxResult.Yes Then
            Dim ctr As Integer = 0
            For m As Integer = 0 To dgCustomerWithStateAreaTerritory.Rows.Count - 1
                Dim row As DataGridViewRow = dgCustomerWithStateAreaTerritory.Rows(m)
                If row.Cells(colSelect.Index).Value = True Then
                    ctr += 1
                    Exit For
                End If
            Next
            If ctr > 0 Then
                SetToDefaultCustomersStateAreaTerritory()
            Else
                VDialog.Show("At least 1 checked detail is required", "Update", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        End If
    End Sub

    Private Sub SetToDefaultCustomersStateAreaTerritory()
        m_ForDeletes.Clear()

        For m As Integer = 0 To dgCustomerWithStateAreaTerritory.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerWithStateAreaTerritory.Rows(m)
            If row.Cells(col4Select.Index).Value = True Then
                SetToDefaultCustomersStateAreaTerritory(row)
                m_ForDeletes.Add.ID = m
            End If

        Next

        For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
            dgCustomerWithStateAreaTerritory.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next

        VDialog.Show("Record Successfully Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Hand)
    End Sub
    Private Sub SetToDefaultCustomersStateAreaTerritory(ByVal row As DataGridViewRow)
        Try
            Dim rs As New ADODB.Recordset

            If rs.State = 1 Then rs.Close()
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.Open("SELECT * FROM Customer WHERE CustomerDEL = 0 AND CustomerCD = '" & HandleSingleQuoteInSql(row.Cells(col4CustomerCode.Index).Value) & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If rs.RecordCount > 0 Then
                For m As Integer = 0 To rs.RecordCount - 1
                    rs.Fields("REGCD").Value = "999"
                    rs.Fields("DISTCD").Value = "999"
                    rs.Fields("AREACD").Value = "999"
                    rs.Fields("ZIPCD").Value = "999"
                    rs.Update()
                    rs.MoveNext()
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub LinkLabel22_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel22.LinkClicked
        Dim q As MsgBoxResult
        q = VDialog.Show("Are you sure you want to update selected customers?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If q = MsgBoxResult.Yes Then
            Dim ctr As Integer = 0
            For m As Integer = 0 To dgShipToCustomer.Rows.Count - 1
                Dim row As DataGridViewRow = dgShipToCustomer.Rows(m)
                If row.Cells(col6Select.Index).Value = True Then
                    ctr += 1
                    Exit For
                End If
            Next
            If ctr > 0 Then
                SetToDefaultShipToCustomerWithStateAreaTerritory()
            Else
                VDialog.Show("At least 1 checked detail is required.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        End If
    End Sub

    Private Sub SetToDefaultShipToCustomerWithStateAreaTerritory()
        m_ForDeletes.Clear()

        For m As Integer = 0 To dgShipToCustomer.Rows.Count - 1
            Dim row As DataGridViewRow = dgShipToCustomer.Rows(m)
            If row.Cells(col6Select.Index).Value = True Then
                SetToDefaultShipToCustomerWithStateAreaTerritory(row)
                m_ForDeletes.Add.ID = m
            End If
        Next

        For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
            dgShipToCustomer.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next

        VDialog.Show("Record Sucessfully Updated.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Hand)

    End Sub

    Private Sub SetToDefaultShipToCustomerWithStateAreaTerritory(ByVal row As DataGridViewRow)
        Try
            Dim rs As New ADODB.Recordset

            If rs.State = 1 Then rs.Close()
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.Open("SELECT * FROM CustomerShipTo WHERE CustomerShipTODEL = 0  AND COMID = '" & cboCompany.Text & "'   AND CUSTOMERCD = '" & HandleSingleQuoteInSql(row.Cells(col6CustomerCode.Index).Value) & "'  AND CDACD = '" & HandleSingleQuoteInSql(row.Cells(col6ShipToCode.Index).Value) & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If rs.RecordCount > 0 Then
                For m As Integer = 0 To rs.RecordCount - 1
                    rs.Fields("REGCD").Value = "999"
                    rs.Fields("DISTCD").Value = "999"
                    rs.Fields("AREACD").Value = "999"
                    rs.Fields("ZIPCD").Value = "999"
                    rs.Update()
                    rs.MoveNext()
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub lnkShipToNotInSystem_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkShipToNotInSystem.LinkClicked
        MainTab.SelectedTab = tbListing
        tbPages.SelectedTab = TabPage8
    End Sub

    Private Sub LinkLabel25_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel25.LinkClicked
        For m As Integer = 0 To dgShipToNotInSystem.RowCount - 1
            Dim row As DataGridViewRow = dgShipToNotInSystem.Rows(m)
            row.Cells(col8Select.Index).Value = True
        Next
    End Sub

    Private Sub LinkLabel24_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel24.LinkClicked
        For m As Integer = 0 To dgShipToNotInSystem.RowCount - 1
            Dim row As DataGridViewRow = dgShipToNotInSystem.Rows(m)
            row.Cells(col8Select.Index).Value = False
        Next
    End Sub

    Private Sub LinkLabel23_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel23.LinkClicked
        Dim q As MsgBoxResult
        q = VDialog.Show("Are you sure you want to add selected ship to customers?", "Add Ship To Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If q = MsgBoxResult.Yes Then
            Dim ctr As Integer = 0
            For m As Integer = 0 To dgShipToNotInSystem.Rows.Count - 1
                Dim row As DataGridViewRow = dgShipToNotInSystem.Rows(m)
                If row.Cells(col8Select.Index).Value = True Then
                    ctr += 1
                    'Exit sub
                    Exit For
                End If
            Next
            If ctr > 0 Then


                SaveShipToCustomerNotInSystem()




            Else
                VDialog.Show("At least 1 checked detail is required.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        End If
    End Sub

    Private Sub LinkLabel28_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel28.LinkClicked
        For m As Integer = 0 To dgCompanyItemsNotInSystem.Rows.Count - 1
            Dim row As DataGridViewRow = dgCompanyItemsNotInSystem.Rows(m)
            row.Cells(col9Select.Index).Value = True
        Next
    End Sub

    Private Sub LinkLabel27_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel27.LinkClicked
        For m As Integer = 0 To dgCompanyItemsNotInSystem.Rows.Count - 1
            Dim row As DataGridViewRow = dgCompanyItemsNotInSystem.Rows(m)
            row.Cells(col9Select.Index).Value = False
        Next
    End Sub

    Private Sub dgCompanyItemsNotInSystem_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCompanyItemsNotInSystem.CellContentClick

    End Sub

    Private Sub dgCompanyItemsNotInSystem_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCompanyItemsNotInSystem.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        'Dim row As DataGridViewRow = dgCompanyItemsNotInSystem.Rows(e.RowIndex)
        'MainWindow.TabControl1.TabPages.Add(MainWindow.TabControl1.TabPages.Count)
        'Dim mine As New UCMasterItem
        'mine.Width = Me.Width
        'mine.ItemCode = row.Cells(col9ItemCode.Index).Value
        'mine.ItemDescription = row.Cells(col9ItemBrandName.Index).Value
        'mine.Height = MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Height - 30
        'MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Text = mine.Name
        'MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Controls.Add(mine)
        'MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Text = "Item Creation"
        'MainWindow.TabControl1.SelectTab(MainWindow.TabControl1.TabPages.Count - 1)


        Dim row As DataGridViewRow = dgCompanyItemsNotInSystem.Rows(e.RowIndex)
        MainWindow.TabControl1.TabPages.Add(MainWindow.TabControl1.TabPages.Count)
        Dim mine As New UCDistributorItems
        mine.Width = Me.Width
        mine.DistributorCode = cboCompany.Text
        mine.Height = MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Height - 30
        MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Text = mine.Name
        MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Controls.Add(mine)
        MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Text = "Channel Items Price List"
        MainWindow.TabControl1.SelectTab(MainWindow.TabControl1.TabPages.Count - 1)



    End Sub

    Private Sub tbEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbEntry.Click

    End Sub

    Private Sub dgBatch_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBatch.CellContentClick

    End Sub

    Private Sub cboCalendarYear_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCalendarYear.SelectedValueChanged

    End Sub

    Private Sub lnkItemsNotInPricelist_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkItemsNotInPricelist.LinkClicked
        MainTab.SelectedTab = tbListing
        tbPages.SelectedTab = TabPage9
    End Sub

    Private Sub dgBatch_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBatch.CellContentDoubleClick

    End Sub

    Private Sub dgBatch_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBatch.CellEnter
        'If e.RowIndex = -1 Then Exit Sub
        'If Not cboMonth.Items.Count > 0 Then
        '    LoadDistributor()
        '    LoadYear()


        'End If

        'Dim row As DataGridViewRow = dgBatch.Rows(e.RowIndex)
        'cboCompany.SelectedItem = row.Cells(colCompanyCode.Index).Value
        'cboCalendarYear.SelectedItem = row.Cells(colYear.Index).Value
        'cboMonth.SelectedItem = row.Cells(colCutMo.Index).Value
        'lblBatchNo.Text = row.Cells(colFileName.Index).Value
    End Sub

    Private Sub dgBatch_CellErrorTextChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBatch.CellErrorTextChanged

    End Sub

    Private Sub lnkBatch_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkBatch.LinkClicked
        If cboCompany.Text <> "" Then

            Dim tag As SelectionTag = ShowSearchDialog("CompanyCode, CheckFileName, CutMo, CutYear", "select companycode , checkfilename [Batch No], cutmo [Month], cutyear [Year], totalgrossamount [Total Gross Amount], totalQuantity [Total Quantity], totalnetamount [Total Net Amount], totalproductdisc [Total Product Disc], UploadDate from uploadedrawdata   where companycode = '" & HandleSingleQuoteInSql(cboCompany.Text) & "' group by companycode, checkfilename, cutmo, cutyear, totalgrossamount , totalQuantity, totalnetamount, totalproductdisc ,UploadDate")
            If Not tag Is Nothing Then
                cboCompany.SelectedItem = tag.KeyColumn1
                cboCalendarYear.SelectedItem = tag.KeyColumn4
                cboMonth.SelectedItem = tag.KeyColumn3
                txtBatchNo.Text = tag.KeyColumn2
            End If
        Else
            ShowExclamation("Channel is required", "Select Batch No")
        End If
    End Sub

    Private Sub LinkLabel5_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Dim q As MsgBoxResult

        q = VDialog.Show("Are you sure you want to update selected customers?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Hand)
        If q = MsgBoxResult.Yes Then
            Dim ctr As Integer = 0
            For m As Integer = 0 To dgUnmappedShipToCustomers.Rows.Count - 1
                Dim row As DataGridViewRow = dgUnmappedShipToCustomers.Rows(m)
                If row.Cells(col10Select.Index).Value = True Then
                    ctr += 1
                    Exit For
                End If
            Next
            If ctr > 0 Then
                'If ValidateShipToCustomerWithStateAreaTerritoryProblemUpdate() Then
                UpdateUnmappedShipToCustomers()
                'End If
            Else
                ShowExclamation("At least 1 checked detail is required.", "Save")
            End If
        End If
    End Sub
    Private Sub UpdateUnmappedShipToCustomers()
        m_ForDeletes.Clear()

        For m As Integer = 0 To dgUnmappedShipToCustomers.Rows.Count - 1
            Dim row As DataGridViewRow = dgUnmappedShipToCustomers.Rows(m)
            If row.Cells(col10Select.Index).Value = True Then
                UpdateUnmappedShipToCustomers(row)
                m_ForDeletes.Add.ID = m
            End If
        Next

        For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
            dgUnmappedShipToCustomers.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next

        VDialog.Show("Record Sucessfully Updated.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Hand)

    End Sub

    Private Sub UpdateUnmappedShipToCustomers(ByVal row As DataGridViewRow)
        Try
            Dim rs As New ADODB.Recordset

            If rs.State = 1 Then rs.Close()
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.Open("SELECT * FROM CustomerShipTo WHERE CustomerShipTODEL = 0  AND COMID = '" & cboCompany.Text & "'   AND CUSTOMERCD = '" & HandleSingleQuoteInSql(row.Cells(col6CustomerCode.Index).Value) & "'  AND CDACD = '" & HandleSingleQuoteInSql(row.Cells(col6ShipToCode.Index).Value) & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If rs.RecordCount > 0 Then
                For m As Integer = 0 To rs.RecordCount - 1
                    rs.Fields("REGCD").Value = row.Cells(col10Region.Index).Value
                    rs.Fields("DISTCD").Value = row.Cells(col10Province.Index).Value
                    rs.Fields("AREACD").Value = row.Cells(col10Municipality.Index).Value
                    rs.Fields("ZIPCD").Value = row.Cells(col10ZipCode.Index).Value
                    rs.Update()
                    rs.MoveNext()
                Next

            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub dgUnmappedShipToCustomers_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgUnmappedShipToCustomers.CellContentClick
        If e.RowIndex = -1 Then Exit Sub

        Dim row As DataGridViewRow = dgUnmappedShipToCustomers.Rows(e.RowIndex)
        Dim tag As New SelectionTag
        If e.ColumnIndex = col10Region.Index Then
            '   If row.Cells(col5Region.Index).Tag = True Then
            tag = ShowSearchDialog("REGCD; REGCD; REGNAME;", "SELECT REGCD, REGCD as [Region Code], REGNAME as [Region Name] FROM Region WHERE DLTFLG = 0")
            If Not tag Is Nothing Then
                row.Cells(col10Region.Index).Tag = tag.KeyColumn1
                row.Cells(col10Region.Index).Value = tag.KeyColumn1
                row.Cells(col10RegionName.Index).Value = tag.KeyColumn3
            End If
            'End If
        ElseIf e.ColumnIndex = col10Province.Index Then
            'If row.Cells(col5Province.Index).Tag = True Then
            If row.Cells(col10Region.Index).Value <> "Select Region" Then
                If CheckIfRegionExist(row.Cells(col10Region.Index).Tag) Then
                    tag = ShowSearchDialog("DISTRCTCD; REGCD;DISTRCTCD;DISTRCTNAME;", "SELECT DISTRCTCD, REGCD [Region Code], DistrctCD [Province Code], DISTRCTNAME [Province Description] FROM DISTRICT WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(row.Cells(col10Region.Index).Tag) & "' ")
                    If Not tag Is Nothing Then

                        row.Cells(col10Province.Index).Tag = tag.KeyColumn1
                        row.Cells(col10Province.Index).Value = Trim(tag.KeyColumn1)
                        row.Cells(col10ProvinceName.Index).Value = Trim(tag.KeyColumn4)
                    End If
                Else
                    VDialog.Show("There was no available Province for the selected area.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                End If
                'End If
            End If
        ElseIf e.ColumnIndex = col10Municipality.Index Then
            ' If row.Cells(col10Municipality.Index).Tag = True Then

            If CheckIfProvinceExist(row.Cells(col10Region.Index).Tag, row.Cells(col10Province.Index).Tag) Then
                tag = ShowSearchDialog("AREACD; AREACD; AREANAME; REGCD; DISTRCTCD; ", "SELECT AREACD,AREACD [Municipality Code], AREANAME [Municipality Name], REGCD [Region Code], DISTRCTCD [District Code] FROM ARea WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(row.Cells(col10Region.Index).Tag) & "' AND DISTRCTCD = '" & HandleSingleQuoteInSql(row.Cells(col10Province.Index).Tag) & "' ")
                If Not tag Is Nothing Then
                    row.Cells(col10Municipality.Index).Tag = tag.KeyColumn1
                    row.Cells(col10Municipality.Index).Value = Trim(tag.KeyColumn1)
                    row.Cells(col10MunicipalityName.Index).Value = Trim(tag.KeyColumn3)
                End If
            Else
                VDialog.Show("There was no available Municipality for the selected area.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
            '  End If

        ElseIf e.ColumnIndex = col10ZipCode.Index Then
            '      If row.Cells(col10ZipCode.Index).Tag = True Then
            If CheckIfMunicipalityExist(row.Cells(col10Region.Index).Tag, row.Cells(col10Province.Index).Tag, row.Cells(col10Municipality.Index).Tag) Then
                tag = ShowSearchDialog("ZIPCD;ZIPCD; REGCD; DISTRCTCD; AREACD; AREANAME;", "SELECT ZIPCD, ZIPCD [Zip Code], RegCD [Region Code], DISTRCTCD [Province Code], AREACD [Municipality Code] , AREANAME [Municipality Code] FROM ZipCode WHERE DLTFLG = 0 AND REGCD = '" & HandleSingleQuoteInSql(row.Cells(col10Region.Index).Tag) & "' AND DISTRCTCD = '" & HandleSingleQuoteInSql(row.Cells(col10Province.Index).Tag) & "' AND AREACD = '" & HandleSingleQuoteInSql(row.Cells(col10Municipality.Index).Tag) & "' ")
                If Not tag Is Nothing Then
                    row.Cells(col10ZipCode.Index).Value = tag.KeyColumn1
                    row.Cells(col10ZipCode.Index).Tag = tag.KeyColumn1
                End If
            Else
                VDialog.Show("There was no available ZipCode for the selected area.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
            'End If
        End If
    End Sub

    Private Sub dgCustomerNotintheSystem_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCustomerNotintheSystem.CellEndEdit
        If e.RowIndex = -1 Then Exit Sub
        Dim row As DataGridViewRow = dgCustomerNotintheSystem.Rows(e.RowIndex)

        If e.ColumnIndex = colShipTo.Index Then
            row.Cells(colShipToName.Index).Value = row.Cells(colCustomerName.Index).Value
        End If
    End Sub

    Private Sub LinkLabel29_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel29.LinkClicked
        For m As Integer = 0 To dgCustomerNotintheSystem.Rows.Count - 1
            Dim row As DataGridViewRow = dgCustomerNotintheSystem.Rows(m)
            If row.Cells(colSelect.Index).Value = True Then
                row.Cells(colShipTo.Index).Value = "001"
                row.Cells(colShipToName.Index).Value = row.Cells(colCustomerName.Index).Value
            End If
        Next
    End Sub

    Private Sub LinkLabel10_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked
        For m As Integer = 0 To dgUnmappedShipToCustomers.RowCount - 1
            Dim row As DataGridViewRow = dgUnmappedShipToCustomers.Rows(m)
            row.Cells(col10Select.Index).Value = True
        Next
    End Sub

    Private Sub LinkLabel6_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        For m As Integer = 0 To dgUnmappedShipToCustomers.RowCount - 1
            Dim row As DataGridViewRow = dgUnmappedShipToCustomers.Rows(m)
            row.Cells(col10Select.Index).Value = False
        Next
    End Sub

    Private Sub dgShipToCustomer_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgShipToCustomer.RowsAdded
        'MsgBox("SHIT!!")
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class