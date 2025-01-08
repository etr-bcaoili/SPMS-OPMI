Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports SPMS.ConnectionModule

Imports SPMS.ErrorMessagesModule
Imports SPMS.InformationMessagesModule
Public Class UcReportMasterFile
    Private Reportname As String = "'"
    Private Sub ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click, btnClose.Click
        If sender Is btnClose Then
            On Error Resume Next
            Dim m_TabPage As TabPage = Me.Parent
            CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
            Me.Dispose()
        ElseIf sender Is btnPrintPreview Then
            If cmbReportType.Text <> "" Then
                Dim cryRpt As New ReportDocument


                'ReportParameterName()
                'Dim row As DataGridViewRow = dg1.Rows(RowIndex)

                'cryRpt.Load(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Reports\ReportSalesTransactionforthePeriod.rpt")
                cryRpt.Load(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\Reports\" & Reportname)

                cryRpt.DataSourceConnections.Item(0).SetLogon(GetSourceUserID, GetSourcePassword)
                'cryRpt.SetDatabaseLogon(GetSourceUserID, GetSourcePassword, GetSourceIP, GetSourceDatabaseName)

                cryRpt.VerifyDatabase()
                rv.ReportSource = cryRpt
                rv.Refresh()
            End If
        End If

    End Sub

    Private Sub PopulateCombo()
        Dim rs As New ADODB.Recordset
        rs = ReportNames()
        cmbReportType.Items.Clear()
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbReportType.Items.Add(rs.Fields("ReportName").Value)
                rs.MoveNext()
            Next
        End If
    End Sub

    Private Function ReportNames(Optional ByVal filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        rs.Open("SELECT * FROM REPORTS WHERE REPORTTYPE = 'MASTERLIST' ORDER BY REPORTNAME", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If filter <> "" Then
            rs.Filter = filter
        End If
        Return rs
    End Function

    Private Sub UcReportMasterFile_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PopulateCombo()
    End Sub


    Private Sub cmbReportType_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbReportType.SelectedValueChanged
        Dim rs As New ADODB.Recordset
        rs = ReportNames("ReportName = '" & cmbReportType.Text & "' ")
        If rs.RecordCount > 0 Then
            Reportname = rs.Fields("ReportFileName").Value
        End If
    End Sub



End Class
