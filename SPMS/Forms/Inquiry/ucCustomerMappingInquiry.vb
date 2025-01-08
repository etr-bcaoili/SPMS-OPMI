
Imports SPMSOPCI.ConnectionModule

Public Class ucCustomerMappingInquiry

    Public Function RsTable(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        Dim str As String = ""
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        str = str & "select  a.zipcd as [zipcode], "
        str = str & "a.customercd as [customercode], "
        str = str & "a.cdacd as [shiptocode], "
        str = str & "a.cdaname as [customershiptoname], "
        str = str & "c.regcd as [Region], "
        str = str & "c.Distrctcd as [Province], "
        str = str & "c.areacovrg as [territoryassigned], "
        str = str & "d.stacovname as [territoryname], "
        str = str & "e.stitmdivcd as [division] "
        str = str & "from 	customershipto  as a,  "
        str = str & "(select comid, cdacd, customercd  "
        str = str & "from customermapping "
        str = str & "group by comid, cdacd, customercd "
        str = str & "having count(cdacd) > 1) as b, "
        str = str & "customermapping as c, "
        str = str & "stareacoverage as d, "
        str = str & "SalesMatrix as e "
        str = str & "where a.comid = b.comid "
        str = str & "and	a.cdacd = b.cdacd "
        str = str & "and	a.customercd = b.customercd "
        str = str & "and	c.comid = a.comid "
        str = str & "and	c.customercd = a.customercd "
        str = str & "and	c.cdacd = a.cdacd "
        str = str & "and	d.stacovcd = c.areacovrg "
        str = str & "and e.stacovcd = d.stacovcd"


        rs.Open(str & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


        Return rs
    End Function


    Private Function RSMatrix(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If


        rs.Open("SELECT * FROM SALESMATRIX WHERE DLTFLG =0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


        Return rs
    End Function

    Private Sub ucCustomerMappingInquiry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(dgdetails)
        PopulateGrid(RsTable)
    End Sub

    Private Sub PopulateGrid(ByVal rs As ADODB.Recordset)
        dgdetails.Rows.Clear()
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim rows As DataGridViewRow = dgdetails.Rows(dgdetails.Rows.Add)

                rows.Cells(colCustomerCode.Index).Value = rs.Fields("CUstomerCode").Value
                rows.Cells(colShiptoCD.Index).Value = rs.Fields("ShiptoCode").Value
                rows.Cells(colShipToName.Index).Value = rs.Fields("CustomerShipToName").Value
                rows.Cells(colZipCode.Index).Value = rs.Fields("ZipCode").Value
                rows.Cells(colReg.Index).Value = rs.Fields("Region").Value
                rows.Cells(colProvince.Index).Value = rs.Fields("Province").Value
                rows.Cells(colTerrCode.Index).Value = rs.Fields("TerritoryAssigned").Value
                rows.Cells(colTerrName.Index).Value = rs.Fields("TerritoryName").Value
                'rows.Cells(colDivision.Index).Value = RSMatrix("Stacovcd = '" & rs.Fields("TerritoryAssigned").Value & "' ").Fields("stitmdivcd").Value
                rows.Cells(colDivision.Index).Value = rs.Fields("Division").Value
                rs.MoveNext()
            Next
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
End Class
