Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ucMasterRegion
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class ucUploadedRawdata
    Private rsUploadedRawdata As New ADODB.Recordset

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub openlisting()
        If rsUploadedRawdata.State = 1 Then rsUploadedRawdata.Close()
        rsUploadedRawdata.Open("Select * from UploadedRawdata", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


        GridListing.Rows.Clear()
        If rsUploadedRawdata.RecordCount > 0 Then
            For i As Integer = 1 To rsUploadedRawdata.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(CompanyCode.Index).Value = rsUploadedRawdata.Fields("CompanyCode").Value
                row.Cells(FileName.Index).Value = rsUploadedRawdata.Fields("CheckFileName").Value
                row.Cells(UploadedDate.Index).Value = rsUploadedRawdata.Fields("UploadDate").Value
                row.Cells(Uploadedby.Index).Value = rsUploadedRawdata.Fields("ActiveUser").Value
                row.Cells(TotalGrossAmount.Index).Value = rsUploadedRawdata.Fields("TotalGrossAmount").Value
                row.Cells(TotalNetAmount.Index).Value = rsUploadedRawdata.Fields("TotalNetAmount").Value
                row.Cells(TotalQuantity.Index).Value = rsUploadedRawdata.Fields("TotalQuantity").Value
                row.Cells(ProductDisc.Index).Value = rsUploadedRawdata.Fields("TotalProductDisc").Value
                rsUploadedRawdata.MoveNext()
            Next
        End If
    End Sub

    Private Sub ucUploadedRawdata_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(GridListing)
        openlisting()
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Dim field As String
        If cmbfilter.Text = "Channel's Code" Then
            field = "CompanyCode"
        ElseIf cmbfilter.Text = "File Name" Then
            field = "CheckFileName"
        ElseIf cmbfilter.Text = "Upload Date" Then
            field = "UploadDate"
        ElseIf cmbfilter.Text = "Upload By" Then
            field = "ActiveUser"
        Else
            field = ""
        End If
        Dim GridRs As New ADODB.Recordset
        GridRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        GridRs.Open("SELECT * FROM UploadedRawdata WHERE " & field & " like '%" & txtFilter.Text & "%'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        GridListing.Rows.Clear()
        If GridRs.RecordCount > 0 Then
            For i As Integer = 1 To GridRs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(CompanyCode.Index).Value = GridRs.Fields("CompanyCode").Value
                row.Cells(FileName.Index).Value = GridRs.Fields("CheckFileName").Value
                row.Cells(UploadedDate.Index).Value = GridRs.Fields("UploadDate").Value
                row.Cells(Uploadedby.Index).Value = GridRs.Fields("ActiveUser").Value
                row.Cells(TotalGrossAmount.Index).Value = GridRs.Fields("TotalGrossAmount").Value
                row.Cells(TotalNetAmount.Index).Value = GridRs.Fields("TotalNetAmount").Value
                row.Cells(TotalQuantity.Index).Value = GridRs.Fields("TotalQuantity").Value
                row.Cells(ProductDisc.Index).Value = GridRs.Fields("TotalProductDisc").Value
                GridRs.MoveNext()
            Next
        End If
    End Sub
End Class
