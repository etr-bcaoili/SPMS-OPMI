' Date Created : 06082010
' Developer : Mark Lester 'R3ckaH ' T. Guiquing

Imports SPMS.ConnectionModule
Public Class AutoCreateSharing

    Private m_RsDistributor As New ADODB.Recordset
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_RsItemDivision As New ADODB.Recordset
    Private m_RsCustomer As New ADODB.Recordset
    Private m_RsSharing As New ADODB.Recordset
    Private m_RsDistinctCoverageCode As New ADODB.Recordset
    Private m_RsCustomerCount As New ADODB.Recordset
    Private m_RsCustomerShare As New ADODB.Recordset

    Private m_ForDeletes As New ForDeletesCollection

    Private m_IsAllowedAutoSharing As Boolean = False

    Public Property IsAllowedAutoSharing() As Boolean
        Get
            Return m_IsAllowedAutoSharing
        End Get
        Set(ByVal value As Boolean)
            m_IsAllowedAutoSharing = value
        End Set
    End Property


    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Close()
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
    Private Sub cboCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCompany.SelectedIndexChanged
        If cboCompany.SelectedIndex <> -1 Then
            GetCompanyName(cboCompany.Text)
        Else
            txtcomname.Text = String.Empty
        End If
    End Sub
    Private Sub GetCompanyName(ByVal CompanyCode As String)
        If m_RsDistributor.State = 1 Then m_RsDistributor.Close()
        m_RsDistributor.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsDistributor.Open("SELECT DISTNAME FROM DISTRIBUTOR WHERE DLTFLG = 0 AND DISTCOMID= '" & CompanyCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If m_RsDistributor.RecordCount > 0 Then
            txtcomname.Text = m_RsDistributor.Fields("DISTNAME").Value
        End If
    End Sub

    Private Sub AutoCreateSharing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtcomname.Text = ""
        Me.Height = 212
        ApplyGridTheme(dgCustomers)
        LoadDistributor()
        LoadItemDivision()
        m_ForDeletes.Clear()
    End Sub

    Private Sub LoadItemDivision()
        If m_RsItemDivision.State = 1 Then m_RsItemDivision.Close()
        m_RsItemDivision.Open("select distinct ItmDivCd from Itemdivision where DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        cboItemDivision.Items.Clear()
        cboItemDivision.Items.Add("")
        For m As Integer = 0 To m_RsItemDivision.RecordCount - 1
            cboItemDivision.Items.Add(m_RsItemDivision.Fields("ItmDIVCD").Value)
            m_RsItemDivision.MoveNext()
        Next
    End Sub

    Public Function LastDayOfMonth(ByRef dt As Date, ByVal wd As DayOfWeek) As Date
        Return New Date(dt.Year, dt.Month, Date.DaysInMonth(dt.Year, dt.Month))
    End Function

    Private Sub lnkProcess_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkProcess.LinkClicked
        If cboCompany.Text = String.Empty Or cboCompany.Text Is Nothing Then
            ShowExclamation("Channel is required.", "Channel")
            Exit Sub
        End If
        If ShowQuestion("Are you sure you want to auto create sharing for the specified date?", "Auto Create Sharing") = MsgBoxResult.Yes Then
            Dim a As New SalesTerritoryMappingAnalysis
            a.COMID = cboCompany.Text
            a.FromDate = dtFrom.Value
            a.ToDate = dtTo.Value
            a.AutoShare = Me
            a.ShowDialog()

            If Not m_IsAllowedAutoSharing Then
                ShowExclamation("Cannot Process Auto - Sharing. Kindly Check Customer Mapping And MR Territory Assignment", "Auto Create Sharing")
            Else
                If ValidateData() Then
                    If cboCompany.Text = "" Then
                        m_RsDistributor.MoveFirst()
                        For m As Integer = 0 To m_RsDistributor.RecordCount - 1
                            SPMSConn.Execute("EXEC uspDeleteAutoCreateSharing @COMID = '" & m_RsDistributor.Fields("DISTCOMID").Value & "' , @EffectivityStartDate = '" & dtFrom.Value.ToShortDateString & "' , @EffectivityEndDate = '" & dtTo.Value.ToShortDateString & "' ")
                            m_RsDistributor.MoveNext()
                        Next
                    Else
                        SPMSConn.Execute("EXEC uspDeleteAutoCreateSharing @COMID = '" & cboCompany.Text & "' , @EffectivityStartDate = '" & dtFrom.Value.ToShortDateString & "' , @EffectivityEndDate = '" & dtTo.Value.ToShortDateString & "' ")
                    End If


                    If ShowQuestion("Do you want to manually select multiple customers ?", "Auto Create Sharing") = MsgBoxResult.Yes Then
                        Me.Height = 507
                        LoadCustomers(cboCompany.Text)
                    Else
                        Me.Height = 212
                        If cboItemDivision.Text <> "" Then
                            AutoCreateSharing(cboItemDivision.Text)
                        Else
                            AutoCreateSharing()
                        End If

                    End If

                End If
            End If
        End If

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

    Private Sub LoadCustomers(ByVal CompanyCode As String)
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT * From CustomerShipTo WHere COMID = '" & CompanyCode & "'  AND CustomerShipTodel = 0 And AccntShrd = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        dgCustomers.Rows.Clear()

        If rs.RecordCount > 0 Then
            For m As Integer = 0 To rs.RecordCount - 1
                Dim row As DataGridViewRow = dgCustomers.Rows(dgCustomers.Rows.Add)
                row.Cells(colCustomerCode.Index).Value = rs.Fields("CUSTOMERCD").Value
                row.Cells(colCustomerName.Index).Value = GetCustomerName(cboCompany.Text, rs.Fields("CUSTOMERCD").Value)
                row.Cells(colShipToCode.Index).Value = rs.Fields("CDACD").Value
                row.Cells(colShipToName.Index).Value = rs.Fields("CDANAME").Value
                row.Cells(colAddress1.Index).Value = rs.Fields("CDACADD1").Value
                row.Cells(colAddress2.Index).Value = rs.Fields("CDACADD2").Value
                rs.MoveNext()
            Next

        End If

    End Sub
    Private Function ValidateData() As Boolean
        m_HasError = False
        m_Err.Clear()
        If CDate(dtFrom.Value.ToShortDateString) > CDate(dtTo.Value.ToShortDateString) Then
            ShowExclamation("Effectivity Date From should not be greater than the effectivity Date To", "Save")
            m_HasError = True
        End If
        Return Not m_HasError
    End Function

    Private Function CheckRecordExists(ByVal comid As String, ByVal CustomerCd As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal CustomerShipToCode As String, ByVal ItemDivisionCode As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        rs.Open("select * from salesterritorymapping where dELFLAG = 0 AND CDACD = '" & CustomerShipToCode & "' AND  comid = '" & comid & "' and cuscd = '" & CustomerCd & "' and EffectivityStartDate = '" & StartDate & "' and EffectivityEndDate = '" & EndDate & "' AND ItemDivCD = '" & ItemDivisionCode & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function CheckRecordExists2(ByVal comid As String, ByVal CustomerCd As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal CustomerShipToCode As String, ByVal ItemDivisionCode As String, ByVal TerrCD As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        rs.Open("select * from salesterritorymapping where dELFLAG = 0 AND CDACD = '" & CustomerShipToCode & "' AND  comid = '" & comid & "' and cuscd = '" & CustomerCd & "' and EffectivityStartDate = '" & StartDate & "' and EffectivityEndDate = '" & EndDate & "' AND ItemDivCD = '" & ItemDivisionCode & "' And Terrcd ='" & TerrCD & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub AutoCreateSharingForSelectedCustomers()

        m_ForDeletes.Clear()
        If m_RsItemDivision.State = 1 Then m_RsItemDivision.Close()
        m_RsItemDivision.Open("select distinct ItmDivCd from Itemdivision where DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsItemDivision.RecordCount > 0 Then

            For m As Integer = 0 To dgCustomers.Rows.Count - 1
                Dim row As DataGridViewRow = dgCustomers.Rows(m)
                If row.Cells(colSelect.Index).Value = True Then


                    Dim areacovrgcode = GetCustomerShipToTerritory(cboCompany.Text, row.Cells(colCustomerCode.Index).Value, row.Cells(colShipToCode.Index).Value)
       
                    If areacovrgcode <> "" Then
                        m_RsItemDivision.MoveFirst()
                        For l As Integer = 0 To m_RsItemDivision.RecordCount - 1
                            m_RsSharing = GetCustomerShipToTerritoryCode(m_RsItemDivision.Fields("ItmDIVCD").Value, areacovrgcode)
                            If Not m_RsSharing Is Nothing Then
                                If m_RsSharing.RecordCount > 1 Then
                                    If Not CheckRecordExists(cboCompany.Text, row.Cells(colCustomerCode.Index).Value, dtFrom.Value.ToShortDateString, dtTo.Value.ToShortDateString, row.Cells(colShipToCode.Index).Value, m_RsItemDivision.Fields("itmDIVCD").Value) Then
                                        For g As Integer = 0 To m_RsSharing.RecordCount - 1
                                            Dim ctr As Double = m_RsSharing.RecordCount
                                            Dim share As Double = 1 / ctr
                                            SaveRecord(cboCompany.Text, row.Cells(colCustomerCode.Index).Value, row.Cells(colShipToCode.Index).Value, row.Cells(colShipToName.Index).Value, m_RsItemDivision.Fields("itmDIVCD").Value, m_RsSharing.Fields("STTERRCD").Value, share, dtFrom.Value.ToShortDateString, dtTo.Value.ToShortDateString, m_RsSharing.Fields("STSLSMNCD").Value, m_RsSharing.Fields("STSLSMNNAME").Value)
                                            m_RsSharing.MoveNext()
                                        Next
                                    End If
                                End If
                            End If
                            m_RsItemDivision.MoveNext()
                        Next
                    End If
                    m_ForDeletes.Add.ID = m
                End If

            Next

            For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
                dgCustomers.Rows.RemoveAt(m_ForDeletes(m).ID)
            Next

        End If
    End Sub

    Private Sub AutoCreateSharingForSelectedCustomers(ByVal ItemDivision As String)
        m_ForDeletes.Clear()
        For m As Integer = 0 To dgCustomers.Rows.Count - 1
            Dim row As DataGridViewRow = dgCustomers.Rows(m)
            If row.Cells(colSelect.Index).Value = True Then
                Dim areacovrgcode = GetCustomerShipToTerritory(cboCompany.Text, row.Cells(colCustomerCode.Index).Value, row.Cells(colShipToCode.Index).Value)
                If areacovrgcode <> "" Then
                    m_RsSharing = GetCustomerShipToTerritoryCode(ItemDivision, areacovrgcode)
                    If Not m_RsSharing Is Nothing Then
                        If m_RsSharing.RecordCount > 1 Then
                            If Not CheckRecordExists(cboCompany.Text, row.Cells(colCustomerCode.Index).Value, dtFrom.Value.ToShortDateString, dtTo.Value.ToShortDateString, row.Cells(colShipToCode.Index).Value, ItemDivision) Then
                                For g As Integer = 0 To m_RsSharing.RecordCount - 1
                                    Dim ctr As Double = m_RsSharing.RecordCount
                                    Dim share As Double = 1 / ctr
                                    SaveRecord(cboCompany.Text, row.Cells(colCustomerCode.Index).Value, row.Cells(colShipToCode.Index).Value, row.Cells(colShipToName.Index).Value, ItemDivision, m_RsSharing.Fields("STTERRCD").Value, share, dtFrom.Value.ToShortDateString, dtTo.Value.ToShortDateString, m_RsSharing.Fields("STSLSMNCD").Value, m_RsSharing.Fields("STSLSMNNAME").Value)
                                    m_RsSharing.MoveNext()
                                Next
                            End If
                        End If
                    End If
                End If
                m_ForDeletes.Add.ID = m
            End If
        Next

        For m As Integer = m_ForDeletes.Count - 1 To 0 Step -1
            dgCustomers.Rows.RemoveAt(m_ForDeletes(m).ID)
        Next
    End Sub

    Private Sub AutoCreateSharing()


        If m_RsItemDivision.State = 1 Then m_RsItemDivision.Close()
        m_RsItemDivision.Open("select distinct ItmDivCd from Itemdivision where DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsItemDivision.RecordCount > 0 Then

            If m_RsCustomer.State = 1 Then m_RsCustomer.Close()
            m_RsCustomer.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            'select customers in ship to whose accntshrd = 1

            m_RsCustomer.Open("Select CustomerCD, CustomerCD, CDACD, CDANAME, CDACADD1, CDACADD2 FROM CUSTOMERSHIPTO WHERE ACCNTSHRD= 1 AND COMID = '" & cboCompany.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockPessimistic)

            If m_RsCustomer.RecordCount > 0 Then

                For m As Integer = 0 To m_RsCustomer.RecordCount - 1

                    '=====
                    'm_RsCustomerCount = GetCustomerCount(cboCompany.Text, m_RsCustomer.Fields("CustomerCD").Value, m_RsCustomer.Fields("CDACD").Value)
                    'If Not m_RsCustomerCount Is Nothing Then
                    '    For h As Integer = 0 To m_RsCustomerCount.RecordCount - 1
                    '===================================

                    Dim areacovrgcode = GetCustomerShipToTerritory(cboCompany.Text, m_RsCustomer.Fields("CustomerCD").Value, m_RsCustomer.Fields("CDACD").Value)
                    'Dim areacovrgcode = GetCustomerShipToTerritory(cboCompany.Text, m_RsCustomerCount.Fields("CustomerCD").Value, m_RsCustomerCount.Fields("CDACD").Value, m_RsCustomerCount.Fields("RegCD").Value, m_RsCustomerCount.Fields("DistrctCD").Value, m_RsCustomerCount.Fields("AreaCd").Value, m_RsCustomerCount.Fields("ZipCd").Value)

                    If areacovrgcode <> "" Then
                        m_RsItemDivision.MoveFirst()
                        For l As Integer = 0 To m_RsItemDivision.RecordCount - 1
                            m_RsSharing = GetCustomerShipToTerritoryCode(m_RsItemDivision.Fields("ItmDIVCD").Value, areacovrgcode)
                            If Not m_RsSharing Is Nothing Then
                                If m_RsSharing.RecordCount > 1 Then
                                    If Not CheckRecordExists(cboCompany.Text, m_RsCustomer.Fields("CustomerCD").Value, dtFrom.Value.ToShortDateString, dtTo.Value.ToShortDateString, m_RsCustomer.Fields("CDACD").Value, m_RsItemDivision.Fields("itmDIVCD").Value) Then
                                        For g As Integer = 0 To m_RsSharing.RecordCount - 1
                                            Dim ctr As Double = m_RsSharing.RecordCount
                                            Dim share As Double = 1 / ctr
                                            SaveRecord(cboCompany.Text, m_RsCustomer.Fields("CustomerCD").Value, m_RsCustomer.Fields("CDACD").Value, m_RsCustomer.Fields("CDANAME").Value, m_RsItemDivision.Fields("itmDIVCD").Value, m_RsSharing.Fields("STTERRCD").Value, share, dtFrom.Value.ToShortDateString, dtTo.Value.ToShortDateString, m_RsSharing.Fields("STSLSMNCD").Value, m_RsSharing.Fields("STSLSMNNAME").Value)
                                            m_RsSharing.MoveNext()
                                        Next
                                    End If
                                End If
                            End If
                            m_RsItemDivision.MoveNext()
                        Next
                    End If

                    '===================================
                    '        m_RsCustomerCount.MoveNext()
                    '    Next
                    'End If
                    '===================
                    m_RsCustomer.MoveNext()
                Next
            End If
            ShowInformation("Auto - Create Sharing Successfully Processed.", "Auto Create Sharing")



            ' ''If m_RsItemDivision.State = 1 Then m_RsItemDivision.Close()
            ' ''m_RsItemDivision.Open("select distinct ItmDivCd from Itemdivision where DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            ' ''If m_RsItemDivision.RecordCount > 0 Then

            ' ''    If m_RsCustomer.State = 1 Then m_RsCustomer.Close()
            ' ''    m_RsCustomer.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            ' ''    'select customers in ship to whose accntshrd = 1

            ' ''    m_RsCustomer.Open("Select CustomerCD, CustomerCD, CDACD, CDANAME, CDACADD1, CDACADD2 FROM CUSTOMERSHIPTO WHERE ACCNTSHRD= 1 AND COMID = '" & cboCompany.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockPessimistic)

            ' ''    If m_RsCustomer.RecordCount > 0 Then

            ' ''        For m As Integer = 0 To m_RsCustomer.RecordCount - 1
            ' ''            SPMSConn.Execute("Exec USPDELETENotinCustomerMapping @COMID='" & HandleSingleQuoteInSql(cboCompany.Text) & _
            ' ''                                "',@EFFECTIVITYSTARTDATE='" & dtFrom.Value.ToShortDateString & "',@EFFECTIVITYENDDATE='" & dtTo.Value.ToShortDateString & _
            ' ''                                "',@CUSTOMERCD='" & m_RsCustomer.Fields("CustomerCD").Value & "',@CDACD='" & m_RsCustomer.Fields("CDACD").Value & "'")
            ' ''            '=====
            ' ''            'm_RsCustomerCount = GetCustomerCount(cboCompany.Text, m_RsCustomer.Fields("CustomerCD").Value, m_RsCustomer.Fields("CDACD").Value)
            ' ''            'If Not m_RsCustomerCount Is Nothing Then
            ' ''            '    For h As Integer = 0 To m_RsCustomerCount.RecordCount - 1
            ' ''            '===================================


            ' ''            Dim areacovrgcode = GetCustomerShipToTerritory(cboCompany.Text, m_RsCustomer.Fields("CustomerCD").Value, m_RsCustomer.Fields("CDACD").Value)
            ' ''            'Dim areacovrgcode = GetCustomerShipToTerritory(cboCompany.Text, m_RsCustomerCount.Fields("CustomerCD").Value, m_RsCustomerCount.Fields("CDACD").Value, m_RsCustomerCount.Fields("RegCD").Value, m_RsCustomerCount.Fields("DistrctCD").Value, m_RsCustomerCount.Fields("AreaCd").Value, m_RsCustomerCount.Fields("ZipCd").Value)

            ' ''            If areacovrgcode <> "" Then
            ' ''                m_RsItemDivision.MoveFirst()
            ' ''                For l As Integer = 0 To m_RsItemDivision.RecordCount - 1
            ' ''                    m_RsSharing = GetCustomerShipToTerritoryCode(m_RsItemDivision.Fields("ItmDIVCD").Value, areacovrgcode)
            ' ''                    If Not m_RsSharing Is Nothing Then
            ' ''                        If m_RsSharing.RecordCount > 1 Then
            ' ''                            If m_RsCustomerShare.State = 1 Then m_RsCustomerShare.Close()
            ' ''                            'If Not CheckRecordExists(cboCompany.Text, m_RsCustomer.Fields("CustomerCD").Value, dtFrom.Value.ToShortDateString, dtTo.Value.ToShortDateString, m_RsCustomer.Fields("CDACD").Value, m_RsItemDivision.Fields("itmDIVCD").Value) Then
            ' ''                            m_RsCustomerShare.Open("Select COMID,CUSCD,	ITEMDIVCD,TERRCD,PERSHR,EFFECTIVITYSTARTDATE,EFFECTIVITYENDDATE,CDACD " & _
            ' ''                                                    "from salesterritorymapping " & _
            ' ''                                                    "Where ComID='" & cboCompany.Text & "' " & _
            ' ''                                                        "AND TERRCD IN (" & areacovrgcode & ") " & _
            ' ''                                                        " And ItemDivCD='" & m_RsItemDivision.Fields("ItmDIVCD").Value & "' " & _
            ' ''                                                        "ANd Effectivityenddate ='" & dtTo.Value.ToShortDateString & "' " & _
            ' ''                                                        "And Effectivitystartdate='" & dtFrom.Value.ToShortDateString & "' " & _
            ' ''                                                        "And delflag='0' AND CDACD='" & m_RsCustomer.Fields("CDACD").Value & "' " & _
            ' ''                                                        "And IsManual='0'", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockPessimistic)
            ' ''                            'm_RsCustomerShare.Open("Exec uspGetCustomerManual @CompanyName='" & cboCompany.Text & "',@CustomerCD='" & m_RsCustomer.Fields("CustomerCD").Value & "',@EffectiveDate='" & dtFrom.Value.ToShortDateString & "',@ExpiryDate='" & dtTo.Value.ToShortDateString & "',@CADCD='" & m_RsCustomer.Fields("CDACD").Value & "'")

            ' ''                            Dim ctr As Double = m_RsCustomerShare.RecordCount
            ' ''                            Dim share As Double = 0
            ' ''                            Dim share2 As Double = 0
            ' ''                            If m_RsCustomerShare.RecordCount > 0 Then
            ' ''                                For q As Integer = 1 To m_RsCustomerShare.RecordCount
            ' ''                                    share = share + m_RsCustomerShare.Fields("PERSHR").Value
            ' ''                                    m_RsCustomerShare.MoveNext()
            ' ''                                Next
            ' ''                                m_RsCustomerShare.MoveFirst()
            ' ''                            End If

            ' ''                            For g As Integer = 0 To m_RsSharing.RecordCount - 1
            ' ''                                ctr = Math.Abs(m_RsSharing.RecordCount - ctr)
            ' ''                                If ctr = 0 Then
            ' ''                                    share = Math.Abs(1 - share)
            ' ''                                Else
            ' ''                                    share = Math.Abs(1 - share) / ctr
            ' ''                                End If

            ' ''                                share2 = 0
            ' ''                                'MsgBox(m_RsCustomerShare.Fields("COMID").Value)
            ' ''                                If m_RsCustomerShare.RecordCount > 0 Then
            ' ''                                    If m_RsCustomerShare.Fields("COMID").Value = cboCompany.Text And m_RsCustomerShare.Fields("CUSCD").Value = m_RsCustomer.Fields("CustomerCD").Value _
            ' ''                                        And m_RsCustomerShare.Fields("TERRCD").Value = m_RsSharing.Fields("STTERRCD").Value And m_RsCustomerShare.Fields("EFFECTIVITYSTARTDATE").Value = dtFrom.Value.ToShortDateString _
            ' ''                                        And m_RsCustomerShare.Fields("EFFECTIVITYENDDATE").Value = dtTo.Value.ToShortDateString And m_RsCustomerShare.Fields("CDACD").Value = m_RsCustomer.Fields("CDACD").Value Then
            ' ''                                        share2 = m_RsCustomerShare.Fields("PERSHR").Value
            ' ''                                        m_RsCustomerShare.MoveNext()
            ' ''                                    End If
            ' ''                                End If

            ' ''                                If share2 = 0 Or Not IsNumeric(share2) Then
            ' ''                                    share2 = share
            ' ''                                End If


            ' ''                                Dim v_isManual As Integer = IsManual(m_RsCustomer.Fields("CustomerCD").Value, cboCompany.Text, m_RsSharing.Fields("STTERRCD").Value, dtFrom.Value, dtTo.Value, m_RsCustomer.Fields("CDACD").Value, m_RsItemDivision.Fields("itmDIVCD").Value, "0")
            ' ''                                SaveRecord(cboCompany.Text, m_RsCustomer.Fields("CustomerCD").Value, m_RsCustomer.Fields("CDACD").Value, m_RsCustomer.Fields("CDANAME").Value, m_RsItemDivision.Fields("itmDIVCD").Value, m_RsSharing.Fields("STTERRCD").Value, share2, dtFrom.Value.ToShortDateString, dtTo.Value.ToShortDateString, m_RsSharing.Fields("STSLSMNCD").Value, m_RsSharing.Fields("STSLSMNNAME").Value, v_isManual)

            ' ''                                m_RsSharing.MoveNext()

            ' ''                            Next
            ' ''                            'End If
            ' ''                        End If
            ' ''                    End If
            ' ''                    m_RsItemDivision.MoveNext()
            ' ''                Next
            ' ''            End If

            ' ''            '===================================
            ' ''            '        m_RsCustomerCount.MoveNext()
            ' ''            '    Next
            ' ''            'End If
            ' ''            '===================
            ' ''            m_RsCustomer.MoveNext()
            ' ''        Next
            ' ''    End If
            ' ''    ShowInformation("Auto - Create Sharing Successfully Processed.", "Auto Create Sharing")



            '    For m As Integer = 0 To m_RsCustomer.RecordCount - 1

            '        If m_RsCustomer.Fields("CustomerCD").Value = "072163" Then

            '            MsgBox("HI")
            '        End If

            '        Dim areacovrgcode = GetCustomerShipToTerritory(cboCompany.Text, m_RsCustomer.Fields("CustomerCD").Value, m_RsCustomer.Fields("CDACD").Value)

            '        If areacovrgcode <> "" Then
            '            m_RsItemDivision.MoveFirst()
            '            For l As Integer = 0 To m_RsItemDivision.RecordCount - 1

            '                m_RsDistinctCoverageCode = GetDistinctAreaCovrg(m_RsItemDivision.Fields("ItmDIVCD").Value, areacovrgcode)
            '                If m_RsDistinctCoverageCode.RecordCount > 0 Then

            '                    For t As Integer = 0 To m_RsDistinctCoverageCode.RecordCount - 1
            '                        m_RsSharing = GetCustomerShipToTerritoryCode(m_RsItemDivision.Fields("ItmDIVCD").Value, "'" & m_RsDistinctCoverageCode.Fields("STACOVCD").Value & "'")
            '                        If Not m_RsSharing Is Nothing Then
            '                            If m_RsSharing.RecordCount > 1 Then
            '                                If Not CheckRecordExists(cboCompany.Text, m_RsCustomer.Fields("CustomerCD").Value, dtFrom.Value.ToShortDateString, dtTo.Value.ToShortDateString, m_RsCustomer.Fields("CDACD").Value, m_RsItemDivision.Fields("itmDIVCD").Value) Then
            '                                    For g As Integer = 0 To m_RsSharing.RecordCount - 1
            '                                        Dim ctr As Double = m_RsSharing.RecordCount
            '                                        Dim share As Double = 1 / ctr
            '                                        SaveRecord(cboCompany.Text, m_RsCustomer.Fields("CustomerCD").Value, m_RsCustomer.Fields("CDACD").Value, m_RsCustomer.Fields("CDANAME").Value, m_RsItemDivision.Fields("itmDIVCD").Value, m_RsSharing.Fields("STTERRCD").Value, share, dtFrom.Value.ToShortDateString, dtTo.Value.ToShortDateString, m_RsSharing.Fields("STSLSMNCD").Value, m_RsSharing.Fields("STSLSMNNAME").Value)
            '                                        m_RsSharing.MoveNext()
            '                                    Next
            '                                End If
            '                            End If
            '                        End If
            '                        m_RsDistinctCoverageCode.MoveNext()
            '                    Next



            '                End If


            '                m_RsItemDivision.MoveNext()
            '            Next
            '        End If
            '        m_RsCustomer.MoveNext()
            '    Next
            'End If
            'ShowInformation("Auto - Create Sharing Successfully Processed.", "Auto Create Sharing")





        Else
            ShowExclamation("There were no sales division maintained in the system.", "Auto - Create Sharing")
        End If

    End Sub

    Private Sub AutoCreateSharing(ByVal ItemDivision As String)


        If m_RsCustomer.State = 1 Then m_RsCustomer.Close()
        m_RsCustomer.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'select customers in ship to whose accntshrd = 1
        m_RsCustomer.Open("Select CustomerCD, CustomerCD, CDACD, CDANAME, CDACADD1, CDACADD2 FROM CUSTOMERSHIPTO WHERE ACCNTSHRD= 1 AND COMID = '" & cboCompany.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockPessimistic)

        If m_RsCustomer.RecordCount > 0 Then

            For m As Integer = 0 To m_RsCustomer.RecordCount - 1




                Dim areacovrgcode = GetCustomerShipToTerritory(cboCompany.Text, m_RsCustomer.Fields("CustomerCD").Value, m_RsCustomer.Fields("CDACD").Value)
                If areacovrgcode <> "" Then
                    m_RsSharing = GetCustomerShipToTerritoryCode(ItemDivision, areacovrgcode)
                    If Not m_RsSharing Is Nothing Then
                        If m_RsSharing.RecordCount > 1 Then
                            If Not CheckRecordExists(cboCompany.Text, m_RsCustomer.Fields("CustomerCD").Value, dtFrom.Value.ToShortDateString, dtTo.Value.ToShortDateString, m_RsCustomer.Fields("CDACD").Value, ItemDivision) Then
                                For g As Integer = 0 To m_RsSharing.RecordCount - 1
                                    Dim ctr As Double = m_RsSharing.RecordCount
                                    Dim share As Double = 1 / ctr
                                    SaveRecord(cboCompany.Text, m_RsCustomer.Fields("CustomerCD").Value, m_RsCustomer.Fields("CDACD").Value, m_RsCustomer.Fields("CDANAME").Value, ItemDivision, m_RsSharing.Fields("STTERRCD").Value, share, dtFrom.Value.ToShortDateString, dtTo.Value.ToShortDateString, m_RsSharing.Fields("STSLSMNCD").Value, m_RsSharing.Fields("STSLSMNNAME").Value)
                                    m_RsSharing.MoveNext()
                                Next
                            End If
                        End If
                    End If
                End If
                m_RsCustomer.MoveNext()
            Next
        End If
        ShowInformation("Auto - Create Sharing Successfully Processed.", "Auto Create Sharing")



        'If m_RsCustomer.State = 1 Then m_RsCustomer.Close()
        'm_RsCustomer.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        ''select customers in ship to whose accntshrd = 1
        'm_RsCustomer.Open("Select CustomerCD, CustomerCD, CDACD, CDANAME, CDACADD1, CDACADD2 FROM CUSTOMERSHIPTO WHERE ACCNTSHRD= 1 AND COMID = '" & cboCompany.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockPessimistic)

        'If m_RsCustomer.RecordCount > 0 Then

        '    For m As Integer = 0 To m_RsCustomer.RecordCount - 1
        '        Dim areacovrgcode = GetCustomerShipToTerritory(cboCompany.Text, m_RsCustomer.Fields("CustomerCD").Value, m_RsCustomer.Fields("CDACD").Value)
        '        If areacovrgcode <> "" Then
        '            m_RsDistinctCoverageCode = GetDistinctAreaCovrg(ItemDivision, areacovrgcode)

        '            If m_RsDistinctCoverageCode.RecordCount > 0 Then
        '                For l As Integer = 0 To m_RsDistinctCoverageCode.RecordCount - 1
        '                    m_RsSharing = GetCustomerShipToTerritoryCode(ItemDivision, m_RsDistinctCoverageCode.Fields("STACOVCD").Value)
        '                    If Not m_RsSharing Is Nothing Then
        '                        If m_RsSharing.RecordCount > 1 Then
        '                            If Not CheckRecordExists(cboCompany.Text, m_RsCustomer.Fields("CustomerCD").Value, dtFrom.Value.ToShortDateString, dtTo.Value.ToShortDateString, m_RsCustomer.Fields("CDACD").Value, ItemDivision) Then
        '                                For g As Integer = 0 To m_RsSharing.RecordCount - 1
        '                                    Dim ctr As Double = m_RsSharing.RecordCount
        '                                    Dim share As Double = 1 / ctr
        '                                    SaveRecord(cboCompany.Text, m_RsCustomer.Fields("CustomerCD").Value, m_RsCustomer.Fields("CDACD").Value, m_RsCustomer.Fields("CDANAME").Value, ItemDivision, m_RsSharing.Fields("STTERRCD").Value, share, dtFrom.Value.ToShortDateString, dtTo.Value.ToShortDateString, m_RsSharing.Fields("STSLSMNCD").Value, m_RsSharing.Fields("STSLSMNNAME").Value)
        '                                    m_RsSharing.MoveNext()
        '                                Next
        '                            End If
        '                        End If
        '                    End If
        '                    m_RsDistinctCoverageCode.MoveNext()
        '                Next
        '            End If


        '        End If
        '        m_RsCustomer.MoveNext()
        '    Next
        'End If
        'ShowInformation("Auto - Create Sharing Successfully Processed.", "Auto Create Sharing")


    End Sub

    Public Function GetCustomerCount(ByVal ComID As String, ByVal CustomerCode As String, ByVal CustomerShipToCode As String) As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rs.Open("SELECT AREACOVRG FROM CUSTOMERSHIPTO WHERE COMID = '" & ComID & "' AND  CUSTOMERCD = '" & CustomerCode & "' AND CDACD = '" & CustomerShipToCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        rs.Open("SELECT  regcd, distrctcd, areacd, zipcd,  customercd, comid, cdacd FROM CUSTOMERMAPPING WHERE           ( '" & dtFrom.Value.ToShortDateString & "' BETWEEN EffectivityStartDate AND EffectivityEndDate  OR  '" & dtTo.Value.ToShortDateString & "' BETWEEN EffectivityStartDate AND EffectivityEndDate )  AND                              CUSTOMERCD = '" & CustomerCode & "' AND CDACD ='" & CustomerShipToCode & "' AND COMID = '" & ComID & "' AND DLTFLG = 0 GROUP BY regcd, distrctcd, areacd, zipcd,  customercd, comid, cdacd ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return rs
        Else
            Return Nothing
        End If

    End Function

    Public Function GetCustomerShipToTerritory(ByVal ComID As String, ByVal CustomerCode As String, ByVal CustomerShipToCode As String, Optional ByVal RegionCode As String = "", Optional ByVal ProvinceCode As String = "", Optional ByVal Municipality As String = "", Optional ByVal ZipCode As String = "") As String
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rs.Open("SELECT AREACOVRG FROM CUSTOMERSHIPTO WHERE COMID = '" & ComID & "' AND  CUSTOMERCD = '" & CustomerCode & "' AND CDACD = '" & CustomerShipToCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If RegionCode = "" Then
            rs.Open("SELECT * FROM CUSTOMERMAPPING WHERE           ( '" & dtFrom.Value.ToShortDateString & "' BETWEEN EffectivityStartDate AND EffectivityEndDate  AND  '" & dtTo.Value.ToShortDateString & "' BETWEEN EffectivityStartDate AND EffectivityEndDate )  AND                              CUSTOMERCD = '" & CustomerCode & "' AND CDACD ='" & CustomerShipToCode & "' AND COMID = '" & ComID & "' AND DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Else
            rs.Open("SELECT * FROM CUSTOMERMAPPING WHERE           ( '" & dtFrom.Value.ToShortDateString & "' BETWEEN EffectivityStartDate AND EffectivityEndDate  AND  '" & dtTo.Value.ToShortDateString & "' BETWEEN EffectivityStartDate AND EffectivityEndDate )   " & _
                    " AND    CUSTOMERCD = '" & CustomerCode & "' " & _
                    " AND CDACD ='" & CustomerShipToCode & "'  " & _
                     " AND COMID = '" & ComID & "' AND DLTFLG = 0 " & _
                     " AND RegCd = '" & RegionCode & "' AND DisTrctCD = '" & ProvinceCode & "' AND  AreaCD = '" & Municipality & "' AND ZipCD = '" & ZipCode & "'   ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        End If

        If rs.RecordCount > 0 Then
            Dim areacovgcd As String = ""
            For m As Integer = 0 To rs.RecordCount - 1
                If areacovgcd <> "" Then areacovgcd &= ","
                areacovgcd &= "'" & rs.Fields("AREACOVRG").Value & "'"
                rs.MoveNext()
            Next
            Return areacovgcd
        Else
            Return ""
        End If
    End Function

    Private Function IsManual(ByVal CustCD As String, ByVal ComId As String, ByVal TerrCd As String, ByVal EffectiveDate As Date, ByVal ExpiryDate As Date, ByVal CdaCd As String, ByVal ItemDiv As String, Optional ByVal delFlag As String = "0") As Integer
        Dim rs As New ADODB.Recordset
        Dim STTerrCd As String
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT STTERRCD FROM SALESMATRIX WHERE DLTFLG ='" & delFlag & "' AND ( '" & EffectiveDate & "' BETWEEN EffectivityStartDate AND EffectivityEndDate  or  '" & ExpiryDate & "' BETWEEN EffectivityStartDate AND EffectivityEndDate ) AND STITMDIVCD = '" & ItemDiv & "' AND STACOVCD = '" & TerrCd & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

 
        If rs.RecordCount > 0 Then
            STTerrCd = rs.Fields(0).Value
            If rs.State = 1 Then rs.Close()
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.Open("Select TransactionType From CustomerMapping Where CustomerCd ='" & CustCD & "' And  ComId='" & ComId & "' And CdaCd='" & CdaCd & "' And AreaCovrg='" & STTerrCd & "' And ( '" & EffectiveDate & "' BETWEEN EffectivityStartDate AND EffectivityEndDate  or  '" & ExpiryDate & "' BETWEEN EffectivityStartDate AND EffectivityEndDate ) And dltflg='" & delFlag & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rs.RecordCount > 0 Then
                Return rs.Fields(0).Value
                Exit Function
            End If

        End If

        STTerrCd = ""
        Return 1
       
    End Function




    Public Function GetCustomerShipToTerritoryCode(ByVal SalesDivisionCode As String, ByVal AreaCoverageCode As String) As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM SALESMATRIX WHERE    DLTFLG = 0   AND ( '" & dtFrom.Value.ToShortDateString & "' BETWEEN EffectivityStartDate AND EffectivityEndDate  or  '" & dtTo.Value.ToShortDateString & "' BETWEEN EffectivityStartDate AND EffectivityEndDate )  AND STITMDIVCD = '" & SalesDivisionCode & "' AND STACOVCD IN (" & AreaCoverageCode & ")  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return rs
        Else
            Return Nothing
        End If
    End Function

    Public Function GetDistinctAreaCovrg(ByVal SalesDivisionCode As String, ByVal AreaCoverageCode As String) As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT DISTINCT STACOVCD FROM SALESMATRIX WHERE    DLTFLG = 0   AND ( '" & dtFrom.Value.ToShortDateString & "' BETWEEN EffectivityStartDate AND EffectivityEndDate  or  '" & dtTo.Value.ToShortDateString & "' BETWEEN EffectivityStartDate AND EffectivityEndDate )  AND STITMDIVCD = '" & SalesDivisionCode & "' AND STACOVCD IN (" & AreaCoverageCode & ")  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return rs
        Else
            Return Nothing
        End If
    End Function


    Private Sub SaveRecord(ByVal CompanyID As String, ByVal CustomerCode As String, ByVal ShipToCode As String, ByVal ShipToName As String, ByVal SalesDivisionCode As String, ByVal TerritoryCode As String, ByVal Sharing As Double, ByVal StartDate As Date, ByVal EndDate As Date, ByVal MedrepCode As String, ByVal MedRepName As String, Optional ByVal bIsManual As Integer = 1)
        'If CheckRecordExists2(CompanyID, CustomerCode, StartDate, EndDate, HandleSingleQuoteInSql(ShipToCode), HandleSingleQuoteInSql(SalesDivisionCode), HandleSingleQuoteInSql(TerritoryCode)) Then
        '    '    SPMSConn.Execute("EXEC uspSalesTerritoryMapping @ACTION = 'UPDATE', @COMID = '" & HandleSingleQuoteInSql(CompanyID) & "', " & _
        '    '                                                    " @CUSCD = '" & HandleSingleQuoteInSql(CustomerCode) & "', @CDACD = '" & HandleSingleQuoteInSql(ShipToCode) & "' , @CDANAME= '" & HandleSingleQuoteInSql(ShipToName) & "', " & _
        '    '                                                    " @itemdivcd = '" & HandleSingleQuoteInSql(SalesDivisionCode) & "', @TERRCD = '" & HandleSingleQuoteInSql(TerritoryCode) & "', " & _
        '    '                                                    " @PERSHR = '" & Sharing & "', @EffectivityStartDate = '" & StartDate & "', @EffectivityEndDate = '" & EndDate & "', " & _
        '    '                                                    " @DELFLAG = 0, @STSLSMNCD = '" & HandleSingleQuoteInSql(MedrepCode) & "',  " & _
        '    '                                                    " @STSLSMNNAME = '" & HandleSingleQuoteInSql(MedRepName) & "' , @IsManual = '" & bIsManual & "'")
        'Else
        'SPMSConn.Execute("EXEC uspSalesTerritoryMapping @ACTION = 'ADD', @COMID = '" & HandleSingleQuoteInSql(CompanyID) & "', " & _
        '                                                " @CUSCD = '" & HandleSingleQuoteInSql(CustomerCode) & "', @CDACD = '" & HandleSingleQuoteInSql(ShipToCode) & "' , @CDANAME= '" & HandleSingleQuoteInSql(ShipToName) & "', " & _
        '                                                " @itemdivcd = '" & HandleSingleQuoteInSql(SalesDivisionCode) & "', @TERRCD = '" & HandleSingleQuoteInSql(TerritoryCode) & "', " & _
        '                                                " @PERSHR = " & Sharing & ", @EffectivityStartDate = '" & StartDate & "', @EffectivityEndDate = '" & EndDate & "', " & _
        '                                                " @DELFLAG = 0, @STSLSMNCD = '" & HandleSingleQuoteInSql(MedrepCode) & "',  " & _
        '                                                " @STSLSMNNAME = '" & HandleSingleQuoteInSql(MedRepName) & "' , @IsManual = '" & bIsManual & "'")
        SPMSConn.Execute("EXEC uspSalesTerritoryMapping @ACTION = 'ADD', @COMID = '" & HandleSingleQuoteInSql(CompanyID) & "', " & _
                                                " @CUSCD = '" & HandleSingleQuoteInSql(CustomerCode) & "', @CDACD = '" & HandleSingleQuoteInSql(ShipToCode) & "' , @CDANAME= '" & HandleSingleQuoteInSql(ShipToName) & "', " & _
                                                " @itemdivcd = '" & HandleSingleQuoteInSql(SalesDivisionCode) & "', @TERRCD = '" & HandleSingleQuoteInSql(TerritoryCode) & "', " & _
                                                " @PERSHR = " & Sharing & ", @EffectivityStartDate = '" & StartDate & "', @EffectivityEndDate = '" & EndDate & "', " & _
                                                " @DELFLAG = 0, @STSLSMNCD = '" & HandleSingleQuoteInSql(MedrepCode) & "',  " & _
                                                " @STSLSMNNAME = '" & HandleSingleQuoteInSql(MedRepName) & "' , @IsManual = 0")

        'End If


    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked

        If ShowQuestion("Create sharing for selected customers?", "Auto Create Sharing") = MsgBoxResult.Yes Then
            Dim ctr As Integer = 0
            For m As Integer = 0 To dgCustomers.Rows.Count - 1
                Dim row As DataGridViewRow = dgCustomers.Rows(m)
                If row.Cells(colSelect.Index).Value = True Then
                    ctr += 1
                    Exit For
                End If
            Next
            If ctr > 0 Then
                If cboItemDivision.Text <> "" Then
                    AutoCreateSharingForSelectedCustomers(cboItemDivision.Text)
                Else
                    AutoCreateSharingForSelectedCustomers()
                End If
                ShowInformation("Auto Create Sharing Sucessfully Completed", "Auto Create Sharing")
            Else
                ShowExclamation("At least 1 detail is needed to continue this process.", "Auto Create Sharing")
            End If
        End If
    End Sub

    Private Sub cboItemDivision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemDivision.SelectedIndexChanged
        txtItemdivisionName.Text = ""

        Dim rsItemDivision As New ADODB.Recordset
        If rsItemDivision.State = 1 Then rsItemDivision.Close()
        rsItemDivision.Open("Select ITMDIVNAME from ITEMDIVISION WHERE ITMDIVCD = '" & cboItemDivision.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsItemDivision.RecordCount <> 0 Then
            txtItemdivisionName.Text = rsItemDivision.Fields(0).Value
        Else
            txtItemdivisionName.Text = ""
        End If
    End Sub

    Private Sub txtcomname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcomname.TextChanged

    End Sub

    Private Sub dtFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFrom.ValueChanged
        dtTo.Value = LastDayOfMonth(dtFrom.Value, dtFrom.Value.DayOfWeek)
    End Sub
End Class