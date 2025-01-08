Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule

Public Class UCUnMapCustomer
    Private m_RsCustomerNotInSystem As New ADODB.Recordset
    Private m_RsCustomerWithoutTerritory As New ADODB.Recordset
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_WithError As Boolean = False
    Private m_ForDeletes As New ForDeletesCollection
    Private m_RsDistributor As New ADODB.Recordset
    Private m_RsMonth As New ADODB.Recordset
    Private m_RsShipToCustomerNotInSystem As New ADODB.Recordset
    Private m_RsItemsNotInSystem As New ADODB.Recordset
    Private m_RSCustomersWithStateAreaTerritoryProblem As New ADODB.Recordset
    Private m_RsShipToCustomerWithStateAreaTerritoryProblem As New ADODB.Recordset
    Private m_rsUnmappedCustomers As New ADODB.Recordset
    Private m_RsCompanyItemsNotInSystem As New ADODB.Recordset
    Private m_RsUnmappedShipToCustomers As New ADODB.Recordset
    Dim m_Recid As Integer = -1
    Dim m_Companycode As String
    Dim m_Cutyear As String
    Dim m_cutmonth As String
    Public Property CompanyCode() As String
        Get
            Return m_Companycode
        End Get
        Set(ByVal value As String)
            m_Companycode = value
        End Set
    End Property
    Public Property Year() As String
        Get
            Return m_Cutyear
        End Get
        Set(ByVal value As String)
            m_Cutyear = value
        End Set
    End Property
    Public Property Month() As String
        Get
            Return m_cutmonth
        End Get
        Set(ByVal value As String)
            m_cutmonth = value
        End Set
    End Property

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub
    Private Sub LoadDistributor()
        If m_RsDistributor.State = 1 Then m_RsDistributor.Close()
        m_RsDistributor.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsDistributor.Open("SELECT * FROM DISTRIBUTOR WHERE  DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsDistributor.RecordCount > 0 Then
            cboCompanyCode.Items.Clear()
            For m As Integer = 0 To m_RsDistributor.RecordCount - 1
                cboCompanyCode.Items.Add(m_RsDistributor.Fields("DISTCOMID").Value)
                m_RsDistributor.MoveNext()
            Next
        End If
    End Sub

    Private Sub UCUnMapCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDistributor()
        ApplyGridTheme(dgCustomerNotintheSystem1)
        ApplyGridTheme(dgCustomerWithoutTerritory3)
        ApplyGridTheme(dgShipToNotInSystem2)
        ApplyGridTheme(dgCompanyItemsNotInSystem4)
        '   ApplyGridTheme(dgItemsNotInSystem)
        ApplyGridTheme(dgCustomerWithStateAreaTerritory5)
        ApplyGridTheme(dgUnmappedCustomers7)
        ApplyGridTheme(dgShipToCustomer6)
        ApplyGridTheme(dgUnmappedShipToCustomers8)
        LoadYear()
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

    Private Sub LinkLabel29_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgCustomerNotintheSystem1.Rows.Count - 1
            Dim row As DataGridViewRow = dgCustomerNotintheSystem1.Rows(m)
            If row.Cells(colSelect.Index).Value = True Then
                row.Cells(colShipTo.Index).Value = "001"
                row.Cells(colShipToName.Index).Value = row.Cells(colCustomerName.Index).Value
            End If
        Next
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgCustomerNotintheSystem1.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerNotintheSystem1.Rows(m)
            row.Cells(colSelect.Index).Value = True
        Next
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgCustomerNotintheSystem1.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerNotintheSystem1.Rows(m)
            row.Cells(colSelect.Index).Value = False
        Next
    End Sub

    Private Sub LinkLabel7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub
    Private Sub SaveCustomerNotInSystem()
        m_ForDeletes.Clear()
        For m As Integer = 0 To dgCustomerNotintheSystem1.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerNotintheSystem1.Rows(m)
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
            dgCustomerNotintheSystem1.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next

        ShowInformation("Record Successfully Saved", "Save")

    End Sub

    Private Sub SaveDefaultCustomerShipTo(ByVal row As DataGridViewRow)
        Try
            SPMSConn.Execute("EXEC uspCustomerShipTo @Action = 'ADD' ,  @COMID =  '" & cboCompanyCode.Text & "' , " & _
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

    Private Sub SaveDefaultCustomerShipToWithZipCdAutomation(ByVal row As DataGridViewRow)
        Try

            If CheckIfZipCodeExists(row.Cells(colZipCode.Index).Value) Then

                Dim rs As ADODB.Recordset = LoadZipCode(row.Cells(colZipCode.Index).Value)
                If Not rs Is Nothing And rs.RecordCount = 1 Then
                    SPMSConn.Execute("EXEC uspCustomerShipTo @Action = 'ADD' ,  @COMID =  '" & cboCompanyCode.Text & "' , " & _
                                        " @CustomerCD = '" & HandleSingleQuoteInSql(row.Cells(colCustomerCode.Index).Value) & "' ,  " & _
                                        " @CDACD = '" & HandleSingleQuoteInSql(row.Cells(colShipTo.Index).Value) & "' , @CDANAME = '" & HandleSingleQuoteInSql(row.Cells(colShipToName.Index).Value) & "' , " & _
                                        " @CDACADD1 = '" & HandleSingleQuoteInSql(row.Cells(colCustomerAddress.Index).Value) & "' , @CDACADD2 = '" & HandleSingleQuoteInSql(row.Cells(colCustomerAddress2.Index).Value) & "' , " & _
                                        " @ZIPCD = '" & HandleSingleQuoteInSql(row.Cells(colZipCode.Index).Value) & "' , @REGCD = '" & HandleSingleQuoteInSql(rs.Fields("ZIPCD").Value) & "' , " & _
                                        " @DISTCD = '" & HandleSingleQuoteInSql(rs.Fields("DISTRCTCD").Value) & "' , @AREACD = '" & HandleSingleQuoteInSql(rs.Fields("AREACD").Value) & "' , @TERRCD = '' , @CMGRP = '" & HandleSingleQuoteInSql(row.Cells(colCustomerClass.Index).Value) & "'  , @CMCLASS =  '' , " & _
                                        " @AREACOVRG = " & IIf(row.Cells(col1Shared.Index).Value = True, "1", "0") & " ")
                Else
                    SPMSConn.Execute("EXEC uspCustomerShipTo @Action = 'ADD' ,  @COMID =  '" & cboCompanyCode.Text & "' , " & _
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

    Private Sub SaveCustomerWithZipCodeAutomation(ByVal row As DataGridViewRow)
        Try
            If CheckIfZipCodeExists(row.Cells(colZipCode.Index).Value) Then

                Dim rs As ADODB.Recordset = LoadZipCode(row.Cells(colZipCode.Index).Value)
                If Not rs Is Nothing And rs.RecordCount = 1 Then
                    SPMSConn.Execute("EXEC uspCustomer @Action = 'ADD' , @Comid = '" & cboCompanyCode.Text & "' , " & _
                            " @CustomerCD = '" & HandleSingleQuoteInSql(row.Cells(colCustomerCode.Index).Value) & "', @CustomerNAME = '" & HandleSingleQuoteInSql(row.Cells(colCustomerName.Index).Value) & "' , @DistribCD = '', " & _
                            " @CADD1 = '" & HandleSingleQuoteInSql(row.Cells(colCustomerAddress.Index).Value) & "', @CADD2 = '" & HandleSingleQuoteInSql(row.Cells(colCustomerAddress2.Index).Value) & "' , @CMCont = '' , @Cmphon = '', " & _
                            " @CDACD = '" & HandleSingleQuoteInSql(row.Cells(colShipTo.Index).Value) & "'  , @ZIPCD = '" & HandleSingleQuoteInSql(row.Cells(colZipCode.Index).Value) & "' , @REGCD = '" & HandleSingleQuoteInSql(rs.Fields("REGCD").Value) & "' , " & _
                            " @DISTCD = '" & rs.Fields("DISTRCTCD").Value & "' , @AREACD = '" & rs.Fields("AREACD").Value & "' , @TERRCD = '' , @CMGRP = '" & row.Cells(colCustomerClass.Index).Value & "' , @CMCLASS = ''  , " & _
                            " @AREACOVRG = " & IIf(row.Cells(col1Shared.Index).Value = True, "1", "0") & "  , @VAT =  1 , @OLDCUSTCODE = '' , " & _
                        " @ACCNTSHRD =  " & IIf(row.Cells(col1Shared.Index).Value = True, "1", "0") & " ")
                Else

                    SPMSConn.Execute("EXEC uspCustomer @Action = 'ADD' , @Comid = '" & cboCompanyCode.Text & "' , " & _
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
    Private Sub SaveCustomerNotIntheSystem(ByVal row As DataGridViewRow)
        Try

            SPMSConn.Execute("EXEC uspCustomer @Action = 'ADD' , @Comid = '" & cboCompanyCode.Text & "' , " & _
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

    Private Function ValidateCustomer() As Boolean
        m_HasError = False


        If cboCompanyCode.Text = "MER" Then
            For m As Integer = 0 To dgCustomerNotintheSystem1.RowCount - 1
                Dim row As DataGridViewRow = dgCustomerNotintheSystem1.Rows(m)
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


        For m As Integer = 0 To dgCustomerNotintheSystem1.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerNotintheSystem1.Rows(m)
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

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cboCompanyCode.SelectedIndex <> -1 Then
            GetCompanyName(cboCompanyCode.Text)
            cboYears.Text = ""
            cboMonth.Text = ""
        Else
        End If
    End Sub
    Private Sub GetCompanyName(ByVal CompanyCode As String)
        If m_RsDistributor.State = 1 Then m_RsDistributor.Close()
        m_RsDistributor.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsDistributor.Open("SELECT DISTNAME FROM DISTRIBUTOR WHERE DLTFLG = 0 AND DISTCOMID= '" & CompanyCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsDistributor.RecordCount > 0 Then
        End If
    End Sub
    Private Sub txtCompany_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboCalendarYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cboYears.SelectedIndex <> -1 Then
            LoadMonth(cboCompanyCode.Text, cboYears.Text)
        End If
    End Sub
    Private Sub LoadMonth(ByVal DistributorCode As String, ByVal Year As String)

        If m_RsMonth.State = 1 Then m_RsMonth.Close()
        m_RsMonth.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsMonth.Open("SELECT * FROM Calendar WHERE COMID = '" & DistributorCode & "' AND CAYR = '" & Year & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsMonth.RecordCount > 0 Then
            cboMonth.Items.Clear()
            For m As Integer = 0 To m_RsMonth.RecordCount - 1
                cboMonth.Items.Add(m_RsMonth.Fields("CAPN").Value)
                ' txtMonthName.Text = (m_RsMonth.Fields("MonthlDescription").Value)
                m_RsMonth.MoveNext()
            Next
        End If
    End Sub
    Private Sub cboMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GetMonthDescription(cboCompanyCode.Text, cboYears.Text, cboMonth.Text)
    End Sub

    Private Sub GetMonthDescription(ByVal DistributorCode As String, ByVal Year As String, ByVal MonthCode As String)
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT MonthDescription FROM Calendar Where COMID = '" & DistributorCode & "' AND CAYR = '" & Year & "'   AND CAPN = '" & MonthCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
        Else
        End If
    End Sub
    Private Function ValidateData() As Boolean
        m_HasError = False
        m_Err.Clear()

        If cboCompanyCode.Text = "" Then
            m_Err.SetError(cboCompanyCode, "Channel is required")
            m_HasError = True
        End If

        If cboYears.Text = "" Then
            m_Err.SetError(cboYears, "Year is required")
            m_HasError = True
        End If

        If cboMonth.Text = "" Then
            m_Err.SetError(cboMonth, "Month is required")
            m_HasError = True
        End If
        Return Not m_HasError
    End Function
    Private Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Load.Click
        lblChannel.Text = Space(20) & cboCompanyCode.Text & " - "
        m_WithError = False

        If ValidateData() Then
            LoadCustomerNotInSystem()
            LoadShipToCustomerNotInSystem()
            If GetDefaultCompany() = "GPI" Then
                ReExecuteZipCodeTerritoryAssignment()
            End If
            LoadCustomerNotInTerritory()
            ' LoadItemsNotInSystem()
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
                ShowExclamation("Errors have been found. Check Analysis Results tab for references.", "Start")
            End If
        End If

    End Sub
    Private Sub LoadUnmappedShipToCustomers()
        If m_RsUnmappedShipToCustomers.State = 1 Then m_RsUnmappedShipToCustomers.Close()
        m_RsUnmappedShipToCustomers.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsUnmappedShipToCustomers.Open("EXEC uspAnalysisResult @ACTION = 'UnmappedShipToCustomers', @CompanyCode = '" & cboCompanyCode.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgUnmappedShipToCustomers8.Rows.Clear()
        If m_RsUnmappedShipToCustomers.RecordCount > 0 Then
            m_WithError = True
            If chkShipto.Checked Then
                Dim m_IsRegionEmpty As Boolean = False
                Dim m_IsProvinceEmpty As Boolean = False
                Dim m_IsMunicipalityEmpty As Boolean = False

                For m As Integer = 0 To m_RsUnmappedShipToCustomers.RecordCount - 1
                    Dim row As DataGridViewRow = dgUnmappedShipToCustomers8.Rows(dgUnmappedShipToCustomers8.Rows.Add)
                    m_IsRegionEmpty = False
                    row.Cells(col10CustCode.Index).Value = m_RsUnmappedShipToCustomers.Fields("CUSTOMERCD").Value
                    row.Cells(col10CustomerName.Index).Value = GetCustomerName(cboCompanyCode.Text, m_RsUnmappedShipToCustomers.Fields("CUSTOMERCD").Value)

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
    Private Sub LoadUnmappedCustomers()

        If m_rsUnmappedCustomers.State = 1 Then m_rsUnmappedCustomers.Close()
        m_rsUnmappedCustomers.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_rsUnmappedCustomers.Open("EXEC uspAnalysisResult @ACTION = 'UnmappedCustomers', @CompanyCode = '" & cboCompanyCode.Text & "' , @CUTMO = '" & cboMonth.Text & "' , @CUTYEAR = '" & cboYears.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgUnmappedCustomers7.Rows.Clear()

        If m_rsUnmappedCustomers.RecordCount > 0 Then
            m_WithError = True
            If chkUnmapped.Checked Then
                For m As Integer = 0 To m_rsUnmappedCustomers.RecordCount - 1
                    Dim row As DataGridViewRow = dgUnmappedCustomers7.Rows(dgUnmappedCustomers7.Rows.Add)

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
    Private Sub LoadCustomersWithStateAreaTerritoryProblem()
        If m_RSCustomersWithStateAreaTerritoryProblem.State = 1 Then m_RSCustomersWithStateAreaTerritoryProblem.Close()
        m_RSCustomersWithStateAreaTerritoryProblem.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RSCustomersWithStateAreaTerritoryProblem.Open("EXEC uspAnalysisResult @ACTION = 'CustomersWithStateAreaTerritoryProblem', @CompanyCode = '" & cboCompanyCode.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgCustomerWithStateAreaTerritory5.Rows.Clear()
        If m_RSCustomersWithStateAreaTerritoryProblem.RecordCount > 0 Then
            m_WithError = True
            If chkCustWithStateAreaTerritoryProblem.Checked Then
                Dim m_IsRegionEmpty As Boolean = False
                Dim m_IsProvinceEmpty As Boolean = False
                Dim m_IsMunicipalityEmpty As Boolean = False
                For m As Integer = 0 To m_RSCustomersWithStateAreaTerritoryProblem.RecordCount - 1
                    Dim row As DataGridViewRow = dgCustomerWithStateAreaTerritory5.Rows(dgCustomerWithStateAreaTerritory5.Rows.Add)
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
    Private Sub LoadShipToCustomersWithStateAreaTerritoryProblem()
        If m_RsShipToCustomerWithStateAreaTerritoryProblem.State = 1 Then m_RsShipToCustomerWithStateAreaTerritoryProblem.Close()
        m_RsShipToCustomerWithStateAreaTerritoryProblem.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsShipToCustomerWithStateAreaTerritoryProblem.Open("EXEC uspAnalysisResult @ACTION = 'ShipToCutomerWithStateAreaTerritoryProblem', @CompanyCode = '" & cboCompanyCode.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgShipToCustomer6.Rows.Clear()
        If m_RsShipToCustomerWithStateAreaTerritoryProblem.RecordCount > 0 Then
            m_WithError = True
            If chkShipto.Checked Then
                Dim m_IsRegionEmpty As Boolean = False
                Dim m_IsProvinceEmpty As Boolean = False
                Dim m_IsMunicipalityEmpty As Boolean = False

                For m As Integer = 0 To m_RsShipToCustomerWithStateAreaTerritoryProblem.RecordCount - 1
                    Dim row As DataGridViewRow = dgShipToCustomer6.Rows(dgShipToCustomer6.Rows.Add)
                    m_IsRegionEmpty = False
                    row.Cells(col6CustomerCode.Index).Value = m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("CUSTOMERCD").Value
                    row.Cells(col6CustName.Index).Value = GetCustomerName(cboCompanyCode.Text, m_RsShipToCustomerWithStateAreaTerritoryProblem.Fields("CUSTOMERCD").Value)

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
    Private Sub LoadCompanyItemsNotInSystem()

        If m_RsCompanyItemsNotInSystem.State = 1 Then m_RsCompanyItemsNotInSystem.Close()
        m_RsCompanyItemsNotInSystem.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        m_RsCompanyItemsNotInSystem.Open("EXEC uspAnalysisResult @ACTION = 'CompanyItemsNotInSystem', @CompanyCode = '" & cboCompanyCode.Text & "' , @CUTMO = '" & cboMonth.Text & "' , @CUTYEAR = '" & cboYears.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgCompanyItemsNotInSystem4.Rows.Clear()
        If m_RsCompanyItemsNotInSystem.RecordCount > 0 Then
            m_WithError = True
            For m As Integer = 0 To m_RsCompanyItemsNotInSystem.RecordCount - 1
                Dim row As DataGridViewRow = dgCompanyItemsNotInSystem4.Rows(dgCompanyItemsNotInSystem4.Rows.Add)
                row.Cells(col9ItemCode.Index).Value = m_RsCompanyItemsNotInSystem.Fields("itemnumber").Value
                row.Cells(col9ItemBrandName.Index).Value = m_RsCompanyItemsNotInSystem.Fields("itemdescription").Value
                m_RsCompanyItemsNotInSystem.MoveNext()
            Next
        End If

    End Sub
    Private Sub LoadCustomerNotInTerritory()
        If m_RsCustomerWithoutTerritory.State = 1 Then m_RsCustomerWithoutTerritory.Close()
        m_RsCustomerWithoutTerritory.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsCustomerWithoutTerritory.Open("EXEC uspAnalysisResult @ACTION = 'CustomerNotAssignedToTerritory', @CompanyCode = '" & cboCompanyCode.Text & "' , @CUTMO = '" & cboMonth.Text & "' , @CUTYEAR = '" & cboYears.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgCustomerWithoutTerritory3.Rows.Clear()
        Dim rsdiv As New ADODB.Recordset
        If rsdiv.State = 1 Then rsdiv.Close()
        rsdiv.Open("SELECT * FROM iTEMdIVISION Where DLTFLG = 0 AND ITMDIVCD <> '999'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsCustomerWithoutTerritory.RecordCount > 0 Then
            m_WithError = True
            If chkCustWithoutAssignedTerritory.Checked Then
                For m As Integer = 0 To m_RsCustomerWithoutTerritory.RecordCount - 1
                    rsdiv.MoveFirst()
                    For L As Integer = 0 To rsdiv.RecordCount - 1
                        Dim row As DataGridViewRow = dgCustomerWithoutTerritory3.Rows(dgCustomerWithoutTerritory3.Rows.Add)
                        row.Cells(col2CustomerCode.Index).Value = m_RsCustomerWithoutTerritory.Fields("CustomerCode").Value
                        row.Cells(col2CustomerName.Index).Value = m_RsCustomerWithoutTerritory.Fields("CustomerName").Value
                        row.Cells(col2CustomerGroup.Index).Value = m_RsCustomerWithoutTerritory.Fields("CustomerGroup").Value
                        row.Cells(col2CustomerAddress.Index).Value = m_RsCustomerWithoutTerritory.Fields("CustomerAddress").Value
                        row.Cells(col2ShipTo.Index).Value = m_RsCustomerWithoutTerritory.Fields("ShipToCode").Value
                        row.Cells(col2ShipToName.Index).Value = m_RsCustomerWithoutTerritory.Fields("ShipToName").Value

                        row.Cells(col2Region.Index).Tag = m_RsCustomerWithoutTerritory.Fields("REGCD").Value
                        row.Cells(col2Province.Index).Tag = m_RsCustomerWithoutTerritory.Fields("DISTCD").Value
                        row.Cells(col2Area.Index).Tag = m_RsCustomerWithoutTerritory.Fields("AREACD").Value
                        ''  row.Cells(colAreacode.Index).Value = m_RsCustomerWithoutTerritory.Fields("AreaCovrg").Value
                        row.Cells(col2Region.Index).Value = m_RsCustomerWithoutTerritory.Fields("Region Name").Value
                        row.Cells(col2Province.Index).Value = m_RsCustomerWithoutTerritory.Fields("Province Name").Value
                        row.Cells(col2Area.Index).Value = m_RsCustomerWithoutTerritory.Fields("Municipality Name").Value

                        row.Cells(col2ZipCode.Index).Value = m_RsCustomerWithoutTerritory.Fields("ZipCd").Value
                        row.Cells(col2SalesDivision.Index).Value = rsdiv.Fields("ITMDIVNAME").Value
                        row.Cells(colTerritory.Index) = New DataGridViewLinkCell
                        row.Cells(colTerritory.Index).Value = "Select  Territory"
                        rsdiv.MoveNext()
                    Next
                    m_RsCustomerWithoutTerritory.MoveNext()
                Next
            End If
        End If
    End Sub

    Private Sub LoadShipToCustomerNotInSystem()
        If m_RsShipToCustomerNotInSystem.State = 1 Then m_RsShipToCustomerNotInSystem.Close()

        m_RsShipToCustomerNotInSystem.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsShipToCustomerNotInSystem.Open("EXEC uspAnalysisResult @ACTION = 'CustomerShipToNotInTheSystem', @CompanyCode = '" & cboCompanyCode.Text & "' , @CUTMO = '" & cboMonth.Text & "' , @CUTYEAR = '" & cboYears.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgShipToNotInSystem2.Rows.Clear()
        If m_RsShipToCustomerNotInSystem.RecordCount > 0 Then
            m_WithError = True

            If chkShipToNotInSystem.Checked Then


                '                If cboCompany.Text <> "MER" Then
                For m As Integer = 0 To m_RsShipToCustomerNotInSystem.RecordCount - 1
                    Dim row As DataGridViewRow = dgShipToNotInSystem2.Rows(dgShipToNotInSystem2.Rows.Add)
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
            End If
        End If
    End Sub
    Private Sub ReExecuteZipCodeTerritoryAssignment()
        Try
            SPMSConn.CommandTimeout = 0
            SPMSConn.Execute("EXEC UspReExecuteZipCodeTerritoryMapping ")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
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
    Private Sub LoadYear()
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT DISTINCT CAYR FROM CALENDAR  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        cboYears.Items.Clear()
        For m As Integer = 0 To rs.RecordCount - 1
            cboYears.Items.Add(rs.Fields("CAYR").Value)
            rs.MoveNext()
        Next
    End Sub
    Private Sub LoadCustomerNotInSystem()
        If m_RsCustomerNotInSystem.State = 1 Then m_RsCustomerNotInSystem.Close()

        m_RsCustomerNotInSystem.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsCustomerNotInSystem.Open("EXEC uspAnalysisResult @ACTION = 'CustomerNotInSystem', @CompanyCode = '" & cboCompanyCode.Text & "' , @CUTMO = '" & cboMonth.Text & "' , @CUTYEAR = '" & cboYears.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgCustomerNotintheSystem1.Rows.Clear()
        If m_RsCustomerNotInSystem.RecordCount > 0 Then
            m_WithError = True


            If cboCompanyCode.Text <> "MER" Then
                For m As Integer = 0 To m_RsCustomerNotInSystem.RecordCount - 1
                    Dim row As DataGridViewRow = dgCustomerNotintheSystem1.Rows(dgCustomerNotintheSystem1.Rows.Add)
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


                dgCustomerNotintheSystem1.Columns(colCustomerName.Index).ReadOnly = False
                dgCustomerNotintheSystem1.Columns(colCustomerClass.Index).ReadOnly = False
                dgCustomerNotintheSystem1.Columns(colCustomerAddress.Index).ReadOnly = False
                dgCustomerNotintheSystem1.Columns(colCustomerAddress2.Index).ReadOnly = False
                dgCustomerNotintheSystem1.Columns(colRegion.Index).ReadOnly = False
                dgCustomerNotintheSystem1.Columns(colProvince.Index).ReadOnly = False
                dgCustomerNotintheSystem1.Columns(colArea.Index).ReadOnly = False
                dgCustomerNotintheSystem1.Columns(colZipCode.Index).ReadOnly = False


                For m As Integer = 0 To m_RsCustomerNotInSystem.RecordCount - 1
                    Dim row As DataGridViewRow = dgCustomerNotintheSystem1.Rows(dgCustomerNotintheSystem1.Rows.Add)
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
    End Sub
    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgCustomerNotintheSystem1.Rows.Count - 1
            Dim row As DataGridViewRow = dgCustomerNotintheSystem1.Rows(m)
            If row.Cells(colSelect.Index).Value = True Then
                row.Cells(colShipTo.Index).Value = "001"
                row.Cells(colShipToName.Index).Value = row.Cells(colCustomerName.Index).Value
            End If
        Next
    End Sub

    Private Sub LinkLabel7_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        If ShowQuestion("Are you sure you want to add selected customers?", "Add Customer") = MsgBoxResult.Yes Then
            Dim ctr As Integer = 0
            For m As Integer = 0 To dgCustomerNotintheSystem1.Rows.Count - 1
                Dim row As DataGridViewRow = dgCustomerNotintheSystem1.Rows(m)
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
                ShowExclamation("At least 1 checked detail is required.", "Save")
            End If
        End If
    End Sub


    Private Sub CheckalllinkTab1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgCustomerNotintheSystem1.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerNotintheSystem1.Rows(m)
            row.Cells(colSelect.Index).Value = True
        Next
    End Sub

    Private Sub Uncheckalllinktab1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgCustomerNotintheSystem1.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerNotintheSystem1.Rows(m)
            row.Cells(colSelect.Index).Value = False
        Next
    End Sub

    Private Sub checkalllinktab2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgShipToNotInSystem2.RowCount - 1
            Dim row As DataGridViewRow = dgShipToNotInSystem2.Rows(m)
            row.Cells(col8Select.Index).Value = True
        Next
    End Sub

    Private Sub Uncheckalllinktab2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgShipToNotInSystem2.RowCount - 1
            Dim row As DataGridViewRow = dgShipToNotInSystem2.Rows(m)
            row.Cells(col8Select.Index).Value = False
        Next
    End Sub


    Private Sub AddSelectedlinktab2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        If ShowQuestion("Are you sure you want to add selected ship to customers?", "Add Ship To Customer") = MsgBoxResult.Yes Then
            Dim ctr As Integer = 0
            For m As Integer = 0 To dgShipToNotInSystem2.Rows.Count - 1
                Dim row As DataGridViewRow = dgShipToNotInSystem2.Rows(m)
                If row.Cells(col8Select.Index).Value = True Then
                    ctr += 1
                    'Exit sub
                    Exit For
                End If
            Next
            If ctr > 0 Then
                SaveShipToCustomerNotInSystem()
            Else
                ShowExclamation("At least 1 checked detail is required.", "Save")
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

    Private Sub SaveShipToCustomerNotInSystemWithZipCdAutomation(ByVal row As DataGridViewRow)
        Try

            If CheckIfZipCodeExists(row.Cells(col8ZipCode.Index).Value) Then

                Dim rs As ADODB.Recordset = LoadZipCode(row.Cells(col8ZipCode.Index).Value)
                If Not rs Is Nothing And rs.RecordCount = 1 Then

                    SPMSConn.Execute("EXEC uspCustomerShipTo @Action = 'ADD' ,  @COMID =  '" & cboCompanyCode.Text & "' , " & _
                                        " @CustomerCD = '" & HandleSingleQuoteInSql(row.Cells(col8CustomerCode.Index).Value) & "' ,  " & _
                                        " @CDACD = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToCode.Index).Value) & "' , @CDANAME = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToName.Index).Value) & "' , " & _
                                        " @CDACADD1 = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToCustomerAddress1.Index).Value) & "' , @CDACADD2 = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToAddress2.Index).Value) & "' , " & _
                                        " @ZIPCD = '" & HandleSingleQuoteInSql(row.Cells(col8ZipCode.Index).Value) & "' , @REGCD = '" & HandleSingleQuoteInSql(rs.Fields("REGCD").Value) & "' , " & _
                                        " @DISTCD = '" & HandleSingleQuoteInSql(rs.Fields("DISTRCTCD").Value) & "' , @AREACD = '" & HandleSingleQuoteInSql(rs.Fields("AREACD").Value) & "' , @TERRCD = '' , @CMGRP = '" & HandleSingleQuoteInSql(row.Cells(colCustomerClass.Index).Value) & "'  , @CMCLASS =  '' , " & _
                                        " @AREACOVRG = '', @ACCNTSHRD = 0 ")
                Else
                    SPMSConn.Execute("EXEC uspCustomerShipTo @Action = 'ADD' ,  @COMID =  '" & cboCompanyCode.Text & "' , " & _
                    " @CustomerCD = '" & HandleSingleQuoteInSql(row.Cells(col8CustomerCode.Index).Value) & "' ,  " & _
                    " @CDACD = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToCode.Index).Value) & "' , @CDANAME = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToName.Index).Value) & "' , " & _
                    " @CDACADD1 = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToCustomerAddress1.Index).Value) & "' , @CDACADD2 = '" & HandleSingleQuoteInSql(row.Cells(col8ShipToAddress2.Index).Value) & "' , " & _
                    " @ZIPCD = '" & HandleSingleQuoteInSql(row.Cells(col8ZipCode.Index).Value) & "' , @REGCD = '" & HandleSingleQuoteInSql(rs.Fields("REGCD").Value) & "' , " & _
                    " @DISTCD = '" & HandleSingleQuoteInSql(row.Cells(col8Province.Index).Tag) & "' , @AREACD = '" & HandleSingleQuoteInSql(row.Cells(col8Municipality.Index).Tag) & "' , @TERRCD = '' , @CMGRP = '" & HandleSingleQuoteInSql(row.Cells(colCustomerClass.Index).Value) & "'  , @CMCLASS =  '' , " & _
                    " @AREACOVRG = '', @ACCNTSHRD = 0 ")
                    'SaveShipToCustomerNotInSystem(row)
                End If

            Else
                '  ShipToCustomerNotInSystem()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub SaveShipToCustomerNotInSystem()
        m_ForDeletes.Clear()
        For m As Integer = 0 To dgShipToNotInSystem2.RowCount - 1
            Dim row As DataGridViewRow = dgShipToNotInSystem2.Rows(m)
            If row.Cells(colSelect.Index).Value = True Then

                If Not CheckIfShipToCustomerCodeExist(row.Cells(col8ShipToCode.Index).Value, cboCompanyCode.Text, row.Cells(col8CustomerCode.Index).Value) Then

                    If row.Cells(colZipCode.Index).Value <> String.Empty Then
                        If row.Cells(colRegion.Index).Value = String.Empty Or row.Cells(colProvince.Index).Value = String.Empty Or row.Cells(colArea.Index).Value = String.Empty Then
                            SaveShipToCustomerNotInSystemWithZipCdAutomation(row)
                        Else
                            SaveShipToCustomerNotInSystem()
                        End If
                    Else
                        SaveShipToCustomerNotInSystem()
                    End If
                End If

                m_ForDeletes.Add.ID = m
            End If
        Next

        For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
            dgShipToNotInSystem2.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next

        ShowInformation("Record Successfully Saved", "Save")

    End Sub

    Private Sub checkalllinktab4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgCompanyItemsNotInSystem4.Rows.Count - 1
            Dim row As DataGridViewRow = dgCompanyItemsNotInSystem4.Rows(m)
            row.Cells(col9Select.Index).Value = True
        Next
    End Sub

    Private Sub Uncheckalltab4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgCompanyItemsNotInSystem4.Rows.Count - 1
            Dim row As DataGridViewRow = dgCompanyItemsNotInSystem4.Rows(m)
            row.Cells(col9Select.Index).Value = False
        Next
    End Sub

    Private Sub Checkalllinktab5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgCustomerWithStateAreaTerritory5.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerWithStateAreaTerritory5.Rows(m)
            row.Cells(col4Select.Index).Value = True
        Next
    End Sub

    Private Sub Uncheckalllinktab5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgCustomerWithStateAreaTerritory5.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerWithStateAreaTerritory5.Rows(m)
            row.Cells(col4Select.Index).Value = False
        Next
    End Sub

    Private Sub UpdateSelectedlinktab5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        If ShowQuestion("Are you sure you want to update selected customers?", "Update") = MsgBoxResult.Yes Then
            Dim ctr As Integer = 0
            For m As Integer = 0 To dgCustomerWithStateAreaTerritory5.Rows.Count - 1
                Dim row As DataGridViewRow = dgCustomerWithStateAreaTerritory5.Rows(m)
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
    Private Sub UpdateCustomersStateAreaTerritory()
        m_ForDeletes.Clear()

        For m As Integer = 0 To dgCustomerWithStateAreaTerritory5.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerWithStateAreaTerritory5.Rows(m)
            If row.Cells(col4Select.Index).Value = True Then
                UpdateCustomersStateAreaTerritory()
                m_ForDeletes.Add.ID = m
            End If

        Next

        For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
            dgCustomerWithStateAreaTerritory5.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next

        ShowInformation("Record Successfully Updated", "Update")
    End Sub
    Private Function ValidateCustomerStateAreaTerritoryUpdate() As Boolean
        Dim m_HasErrors As Boolean = False
        For m As Integer = 0 To dgCustomerWithStateAreaTerritory5.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerWithStateAreaTerritory5.Rows(m)
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

    Private Sub SetSelectedtodefaultlinktab5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        If ShowQuestion("Are you sure you want to update selected items to default?", "Update") = MsgBoxResult.Yes Then
            Dim ctr As Integer = 0
            For m As Integer = 0 To dgCustomerWithStateAreaTerritory5.Rows.Count - 1
                Dim row As DataGridViewRow = dgCustomerWithStateAreaTerritory5.Rows(m)
                If row.Cells(colSelect.Index).Value = True Then
                    ctr += 1
                    Exit For
                End If
            Next
            If ctr > 0 Then
                SetToDefaultCustomersStateAreaTerritory()
            Else
                ShowExclamation("At least 1 checked detail is required", "Update")
            End If
        End If
    End Sub

    Private Sub SetToDefaultCustomersStateAreaTerritory()
        m_ForDeletes.Clear()

        For m As Integer = 0 To dgCustomerWithStateAreaTerritory5.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerWithStateAreaTerritory5.Rows(m)
            If row.Cells(col4Select.Index).Value = True Then
                SetToDefaultCustomersStateAreaTerritory()
                m_ForDeletes.Add.ID = m
            End If

        Next

        For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
            dgCustomerWithStateAreaTerritory5.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next

        ShowInformation("Record Successfully Updated", "Update")
    End Sub

    Private Sub checkalllinktab6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgShipToCustomer6.RowCount - 1
            Dim row As DataGridViewRow = dgShipToCustomer6.Rows(m)
            row.Cells(col6Select.Index).Value = True
        Next
    End Sub

    Private Sub Uncheckalllinktab6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgShipToCustomer6.RowCount - 1
            Dim row As DataGridViewRow = dgShipToCustomer6.Rows(m)
            row.Cells(col6Select.Index).Value = False
        Next
    End Sub

    Private Sub UpdateSelectedlinktab6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        If ShowQuestion("Are you sure you want to update selected customers?", "Update") = MsgBoxResult.Yes Then
            Dim ctr As Integer = 0
            For m As Integer = 0 To dgShipToCustomer6.Rows.Count - 1
                Dim row As DataGridViewRow = dgShipToCustomer6.Rows(m)
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

        For m As Integer = 0 To dgShipToCustomer6.Rows.Count - 1
            Dim row As DataGridViewRow = dgShipToCustomer6.Rows(m)
            If row.Cells(col6Select.Index).Value = True Then
                UpdateShipToCustomerWithStateAreaTerritory()
                m_ForDeletes.Add.ID = m
            End If
        Next

        For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
            dgShipToCustomer6.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next

        ShowInformation("Record Sucessfully Updated.", "Update")

    End Sub

    Private Function ValidateShipToCustomerWithStateAreaTerritoryProblemUpdate() As Boolean
        Dim m_HasErrors As Boolean = False
        For m As Integer = 0 To dgShipToCustomer6.RowCount - 1
            Dim row As DataGridViewRow = dgShipToCustomer6.Rows(m)
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

    Private Sub UpdateUnmappedShipToCustomers(ByVal row As DataGridViewRow)
        Try
            Dim rs As New ADODB.Recordset

            If rs.State = 1 Then rs.Close()
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.Open("SELECT * FROM CustomerShipTo WHERE CustomerShipTODEL = 0  AND COMID = '" & cboCompanyCode.Text & "'   AND CUSTOMERCD = '" & HandleSingleQuoteInSql(row.Cells(col6CustomerCode.Index).Value) & "'  AND CDACD = '" & HandleSingleQuoteInSql(row.Cells(col6ShipToCode.Index).Value) & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
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

    Private Sub SetSelectedtodefaultlinktab6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim q As MsgBoxResult
        VDialog.Show("Are you sure you want to update selected customers?", "Update", MessageBoxButtons.YesNo)
        If q = MsgBoxResult.Yes Then
            Dim ctr As Integer = 0
            For m As Integer = 0 To dgShipToCustomer6.Rows.Count - 1
                Dim row As DataGridViewRow = dgShipToCustomer6.Rows(m)
                If row.Cells(col6Select.Index).Value = True Then
                    ctr += 1
                    Exit For
                End If
            Next
            If ctr > 0 Then
                SetToDefaultShipToCustomerWithStateAreaTerritory()
            Else
                ShowExclamation("At least 1 checked detail is required.", "Save")
            End If
        End If

    End Sub
    Private Sub SetToDefaultShipToCustomerWithStateAreaTerritory()
        m_ForDeletes.Clear()

        For m As Integer = 0 To dgShipToCustomer6.Rows.Count - 1
            Dim row As DataGridViewRow = dgShipToCustomer6.Rows(m)
            If row.Cells(col6Select.Index).Value = True Then
                SetToDefaultShipToCustomerWithStateAreaTerritory()
                m_ForDeletes.Add.ID = m
            End If
        Next

        For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
            dgShipToCustomer6.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next

        ShowInformation("Record Sucessfully Updated.", "Update")

    End Sub

    Private Sub Checkalllinktab7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgUnmappedCustomers7.RowCount - 1
            Dim row As DataGridViewRow = dgUnmappedCustomers7.Rows(m)
            row.Cells(col5Select.Index).Value = True
        Next
    End Sub

    Private Sub uncheckalllinktab7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgUnmappedCustomers7.RowCount - 1
            Dim row As DataGridViewRow = dgUnmappedCustomers7.Rows(m)
            row.Cells(col5Select.Index).Value = False
        Next
    End Sub
    Private Sub UpdateUnmappedCustomers()
        m_ForDeletes.Clear()

        For m As Integer = 0 To dgUnmappedCustomers7.RowCount - 1
            Dim row As DataGridViewRow = dgUnmappedCustomers7.Rows(m)
            If row.Cells(col5Select.Index).Value = True Then
                UpdateUnmappedCustomers()
                m_ForDeletes.Add.ID = m
            End If
        Next

        For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
            dgUnmappedCustomers7.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next

        ShowInformation("Record Successfully Updated", "Update")
    End Sub

    Private Sub UpdateSelectedlinktab7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        If ShowQuestion("Are you sure you want to update selected customers?", "Update") = MsgBoxResult.Yes Then
            Dim ctr As Integer = 0
            For m As Integer = 0 To dgUnmappedCustomers7.Rows.Count - 1
                Dim row As DataGridViewRow = dgUnmappedCustomers7.Rows(m)
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

    Private Sub checkalllinktab8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgUnmappedShipToCustomers8.RowCount - 1
            Dim row As DataGridViewRow = dgUnmappedShipToCustomers8.Rows(m)
            row.Cells(col10Select.Index).Value = True
        Next
    End Sub

    Private Sub uncheckalllinktab8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgUnmappedShipToCustomers8.RowCount - 1
            Dim row As DataGridViewRow = dgUnmappedShipToCustomers8.Rows(m)
            row.Cells(col10Select.Index).Value = False
        Next
    End Sub

    Private Sub UpdateUnmappedShipToCustomers()
        m_ForDeletes.Clear()

        For m As Integer = 0 To dgUnmappedShipToCustomers8.Rows.Count - 1
            Dim row As DataGridViewRow = dgUnmappedShipToCustomers8.Rows(m)
            If row.Cells(col10Select.Index).Value = True Then
                UpdateUnmappedShipToCustomers(row)
                m_ForDeletes.Add.ID = m
            End If
        Next

        For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
            dgUnmappedShipToCustomers8.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next
        ShowInformation("Record Sucessfully Updated.", "Update")
    End Sub

    Private Sub UpdateSelectedlinktab8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        If ShowQuestion("Are you sure you want to update selected customers?", "Update") = MsgBoxResult.Yes Then
            Dim ctr As Integer = 0
            For m As Integer = 0 To dgUnmappedShipToCustomers8.Rows.Count - 1
                Dim row As DataGridViewRow = dgUnmappedShipToCustomers8.Rows(m)
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

    Private Sub Checkalllinktab3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgCustomerWithoutTerritory3.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerWithoutTerritory3.Rows(m)
            row.Cells(col2Select.Index).Value = True
        Next
    End Sub

    Private Sub uncheckalllinktab3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        For m As Integer = 0 To dgCustomerWithoutTerritory3.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerWithoutTerritory3.Rows(m)
            row.Cells(col2Select.Index).Value = False
        Next
    End Sub

    Private Sub addSelectedlinktab3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        If ShowQuestion("Are you sure you want to add selected items?", "MapTerritory to Customer") = MsgBoxResult.Yes Then
            Dim ctr As Integer = 0
            For m As Integer = 0 To dgCustomerWithoutTerritory3.Rows.Count - 1
                Dim row As DataGridViewRow = dgCustomerWithoutTerritory3.Rows(m)
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
        rs.Open("SELECT 'A' FROM CustomerMapping Where  DLTFLG = 0 AND CustomerCd = '" & row.Cells(col2CustomerCode.Index).Value & "' AND CDACD = '" & row.Cells(col2ShipTo.Index).Value & "' AND COMID = '" & cboCompanyCode.Text & "'  AND AreaCovrg = '" & row.Cells(colTerritory.Index).Tag & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub AddSharingToTerritory(ByVal row As DataGridViewRow)
        Try
            SPMSConn.Execute("EXEC uspSharing @Action = 'SAVE',@Recid = '" & m_Recid & "',@Comid = '" & cboCompanyCode.Text & "',@Cutmo = '" & cboMonth.Text & "',@Cutyear = '" & cboYears.Text & "', " & _
                             "@cuscd = '" & HandleSingleQuoteInSql(row.Cells(col2CustomerCode.Index).Value) & "',@Cusnam = '" & HandleSingleQuoteInSql(row.Cells(col2CustomerName.Index).Value) & "', " & _
                             "@cdaname = '" & HandleSingleQuoteInSql(row.Cells(col2CustomerName.Index).Value) & "',@CDACD = '" & row.Cells(col2ShipTo.Index).Value & "',@Terrcd = '" & row.Cells(colTerritory.Index).Value & "',@STSLSMNCD = '" & row.Cells(colSalesMancode.Index).Value & "',@STSLSMNNAME = '" & row.Cells(colSalesManName.Index).Value & "',@Pershr = 1.0,@Itemdivcd = '" & HandleSingleQuoteInSql(row.Cells(col2SalesDivision.Index).Value) & "', " & _
                             "@delflag = 0,@Isactive = 1")
        Catch ex As Exception

        End Try

    End Sub
    Private Sub AddCustomerToTerritory()
        m_ForDeletes.Clear()

        For m As Integer = 0 To dgCustomerWithoutTerritory3.RowCount - 1
            Dim row As DataGridViewRow = dgCustomerWithoutTerritory3.Rows(m)
            If row.Cells(col2Select.Index).Value = True And row.Cells(colTerritory.Index).Value <> "Select Territory" Then
                If Not CheckIfCustomerAlreadyMappedToTheTerrritory(row) Then
                    'AddCustomerToTerritory(row)
                    AddSharingToTerritory(row)

                End If
                m_ForDeletes.Add.ID = m
            End If
        Next

        For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
            dgCustomerWithoutTerritory3.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next

        ShowInformation("Record Successfully Saved", "Save")
    End Sub

    Private Sub dgShipToCustomer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgShipToCustomer6.CellContentClick

    End Sub

    Private Sub cboCompanyCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCompanyCode.SelectedIndexChanged

    End Sub

    Private Sub cboYears_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYears.SelectedIndexChanged
        If cboYears.SelectedIndex <> -1 Then
            LoadMonth(cboCompanyCode.Text, cboYears.Text)
        End If
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub cboMonth_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMonth.SelectedIndexChanged

    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub level1createDefaultshiptoforSelectcustomer_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles level1createDefaultshiptoforSelectcustomer.LinkClicked
        For m As Integer = 0 To dgCustomerNotintheSystem1.Rows.Count - 1
            Dim row As DataGridViewRow = dgCustomerNotintheSystem1.Rows(m)
            row.Cells(colSelect.Index).Value = "001"
            row.Cells(colShipToName.Index).Value = row.Cells(colCustomerName.Index).Value
        Next
    End Sub

    Private Sub LinkLabel26_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel26.LinkClicked

    End Sub
End Class
