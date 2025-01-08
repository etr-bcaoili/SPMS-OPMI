Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ErrorMessagesModule
Public Class UCCustomerMappingListing



    Private Sub PopulateCombo()
        Dim rs As New ADODB.Recordset
        rs = RsChannel()
        cmbChannel.Items.Clear()
        cmbChannelName.Items.Clear()
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbChannel.Items.Add(rs.Fields("DistComID").Value)
                cmbChannelName.Items.Add(rs.Fields("DistName").Value)
                rs.MoveNext()
            Next
        End If
    End Sub

    Private Sub btnfilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfilter.Click
        Dim rs As New ADODB.Recordset
        If cmbChannel.Text = "" Then
            rs = rsLinkedCustomerMapping()
        Else
            rs = rsLinkedCustomerMapping("A.[COMID] = '" & cmbChannel.Text & "' ")
        End If

        PopulateGridbyRs(rs)
    End Sub

    Private Sub PopulateGridbyRs(ByVal rs As ADODB.Recordset)
        dgdetails.Rows.Clear()

        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim row As DataGridViewRow = dgdetails.Rows(dgdetails.Rows.Add)
                row.Cells(colCustomerCd.Index).Value = rs.Fields("CustomerCd").Value
                row.Cells(colCustomerGroup.Index).Value = rs.Fields("CustomerGroupName").Value
                row.Cells(colRegionCode.Index).Value = rs.Fields("RegionCode").Value
                row.Cells(colRegionName.Index).Value = rs.Fields("RegionName").Value
                row.Cells(colDistrictCode.Index).Value = rs.Fields("DistrictCode").Value
                row.Cells(colDistrictName.Index).Value = rs.Fields("DIstrictName").Value
                row.Cells(colAreaCode.Index).Value = rs.Fields("AreaCode").Value
                row.Cells(colAreaName.Index).Value = rs.Fields("AreaName").Value
                row.Cells(colAreaCoverage.Index).Value = rs.Fields("AreaCoverage").Value
                row.Cells(colAreaCoverageName.Index).Value = rs.Fields("AreaCoverageName").Value
                row.Cells(colComid.Index).Value = rs.Fields("ChannelCode").Value
                row.Cells(colShiptoCode.Index).Value = rs.Fields("ShiptoCode").Value
                row.Cells(colShiptoname.Index).Value = rs.Fields("ShiptoName").Value
                row.Cells(colZipCode.Index).Value = rs.Fields("Zipcode").Value
                row.Cells(colDivisionCode.Index).Value = rs.Fields("ItemDivision").Value
                row.Cells(colMedicalRep.Index).Value = rs.Fields("SalesmanCode").Value
                row.Cells(colMedicalRepName.Index).Value = rs.Fields("SalesmanName").Value
                row.Cells(colCustomerName.Index).Value = rs.Fields("CustomerName").Value
                row.Cells(colAddress1.Index).Value = rs.Fields("Address1").Value
                row.Cells(colAddress2.Index).Value = rs.Fields("Address2").Value
                rs.MoveNext()
            Next
        End If
    End Sub

    Private Function rsLinkedCustomerMapping(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset

        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        Dim str As String = ""

        str = str & "SELECT	A.[CUSTOMERGROUPCD]		AS [CUSTOMERGROUPCODE], "
        str = str & "E.[CUSTOMERGROUPNAME]	AS [CUSTOMERGROUPNAME], "
        str = str & "A.[REGCD]				AS [REGIONCODE], "
        str = str & "B.[REGNAME]				AS [REGIONNAME], "
        str = str & "A.[DISTRCTCD]			AS [DISTRICTCODE], "
        str = str & "C.[DISTRCTNAME]			AS [DISTRICTNAME], "
        str = str & "A.[AREACD]				AS [AREACODE], "
        str = str & "D.[AREANAME]			AS [AREANAME], "
        str = str & "A.[CUSTOMERCD]			AS [CUSTOMERCD], "
        str = str & "A.[AREACOVRG]			AS [AREACOVERAGE], "
        str = str & "A.[COMID]				AS [CHANNELCODE], "
        str = str & "A.[CDACD]				AS [SHIPTOCODE], "
        str = str & "A.[CDANAME]			AS [SHIPTONAME], "
        str = str & "G.[CADD1]              AS [ADDRESS1], "
        str = str & "G.[CADD2]              AS [ADDRESS2], "
        str = str & "A.[EFFECTIVITYSTARTDATE] AS [EFFECTIVITYSTARTDATE], "
        str = str & "A.[EFFECTIVITYENDDATE]	AS [EFFECTIVITYENDDATE], "
        str = str & "F.[STACOVNAME]         AS [AREACOVERAGENAME], "
        str = str & "A.[ZipCd]              AS [ZipCode], "
        str = str & "F.[STITMDIVCD]         AS [ItemDivision], "
        str = str & "F.[STSLSMNCD]          AS [SalesManCode], "
        str = str & "F.[STSLSMNNAME]        AS [SalesManName], "
        str = str & "G.[CUSTOMERNAME]       AS [CUSTOMERNAME] "
        str = str & "FROM	[CUSTOMERMAPPING] AS A "
        str = str & "LEFT JOIN [REGION] AS B "
        str = str & "ON	B.[REGCD] = A.[REGCD] "
        str = str & "AND	B.[DLTFLG] = 0 "
        str = str & "AND    B.[ISACTIVE] = 1"
        str = str & "LEFT JOIN [DISTRICT] AS C "
        str = str & "ON	    C.[REGCD] = A.[REGCD] "
        str = str & "AND	C.[DISTRCTCD] = A.[DISTRCTCD] "
        str = str & "AND	C.[DLTFLG] = 0 "
        str = str & "AND    C.[ISACTIVE] = 1"
        str = str & "LEFT JOIN [AREA] AS D "
        str = str & "ON	    D.[REGCD] = A.[REGCD] "
        str = str & "AND	D.[DISTRCTCD] = A.[DISTRCTCD] "
        str = str & "AND	D.[AREACD] = A.[AREACD] "
        str = str & "AND    D.[DLTFLG] = 0 "
        str = str & "AND    D.[ISACTIVE] = 1"
        str = str & "LEFT JOIN [CUSTOMERGROUP] AS E "
        str = str & "ON	    E.[CUSTOMERGROUPCD] = A.[CUSTOMERGROUPCD] "
        str = str & "AND    E.[DLTFLG] = 0 "
        str = str & "AND    E.[ISACTIVE] = 1"
        str = str & "LEFT JOIN [SALESMATRIX] AS F "
        str = str & "ON	    F.[STACOVCD] = A.[AREACOVRG] "
        str = str & "AND	F.[DLTFLG] = 0 "
        str = str & "AND    F.[ISACTIVE] = 1"
        str = str & "LEFT JOIN [Customer] AS G "
        str = str & "ON     G.[COMID] = A.[COMID]"
        str = str & "AND    G.[CUSTOMERCD] = A.[CUSTOMERCD] "
        str = str & "AND    G.[CUSTOMERDEL] = 0"
        str = str & "WHERE A.[DLTFLG] = 0"


        rs.Open(str & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


        Return rs
    End Function

    Private Sub UCCustomerMappingListing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(dgdetails)
        PopulateCombo()
    End Sub

    Private Function RsChannel(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If
        rs.Open("SELECT * FROM DISTRIBUTOR WHERE DLTFLG = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


        Return rs
    End Function

    Private Sub cmbChannel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbChannel.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
        rs = RsChannel(" DistComID = '" & cmbChannel.Text & "' ")
        If rs.RecordCount > 0 Then
            cmbChannelName.Text = rs.Fields("DistName").Value
        End If
    End Sub

    Private Sub cmbChannelName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbChannelName.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
        rs = RsChannel(" DistName = '" & cmbChannelName.Text & "' ")
        If rs.RecordCount > 0 Then
            cmbChannel.Text = rs.Fields("DistComID").Value
        End If
    End Sub

    Private Sub btnremove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()

    End Sub
End Class
