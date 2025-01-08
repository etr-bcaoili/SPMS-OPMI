Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Imports System.Data.OleDb
Imports System
Imports System.IO
Imports System.Collections
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class UIMedicalDoctorValidationRawData
    Dim table As New DataTable
    Dim dt As New DataTable
    Dim dts As SqlDataReader
    Private m_RawData As New RawData
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private _Distributor As New Distributor
    Private _ModifyMedicalDoctor As New UIModifyRawdata

    Private strKeyColumn As String = ""
    Private strKeyColumn1 As String = ""
    Private strKeyColumn2 As String = ""
    Private strKeyColumn3 As String = "'"
    Private strKeyColumn4 As String = "'"
    Private strKeyColumn5 As String = "'"

    Public ReadOnly Property Keycolumn() As String
        Get
            Return strKeyColumn
        End Get
    End Property


    Public ReadOnly Property Keycolumn1() As String
        Get
            Return strKeyColumn1
        End Get
    End Property


    Public ReadOnly Property Keycolumn2() As String
        Get
            Return strKeyColumn2
        End Get
    End Property

    Public ReadOnly Property Keycolumn4() As String
        Get
            Return strKeyColumn4
        End Get
    End Property
    Public ReadOnly Property Keycolumn5() As String
        Get
            Return strKeyColumn5
        End Get
    End Property
    Public ReadOnly Property Keycolumn3() As String
        Get
            Return strKeyColumn3
        End Get
    End Property
    Private Sub Clear()
        txtChannelCode.Text = String.Empty
        txtChannelName.Text = String.Empty
    End Sub
    Private Sub FindBestTimeCall_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles FindBestTimeCall.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Distributor.GetDistributorSql, "Distributor")
        If Not tag Is Nothing Then
            ShowData(tag.KeyColumn11)
            LoadYear(txtChannelCode.Text)
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        If RecordCode < 1 Then Exit Sub
        _Distributor = Distributor.Load(RecordCode)
        txtChannelCode.Tag = _Distributor.DISTRIBUTORID
        txtChannelCode.Text = _Distributor.DISTCOMID
        txtChannelName.Text = _Distributor.DISTNAME
    End Sub
    Private Sub LoadYear(ByVal DistributorCode As String)
        table = GetRecords("SELECT Distinct CAYR  FROM Calendar WHERE COMID = '" & DistributorCode & "' ")
        For i As Integer = 0 To table.Rows.Count - 1
            cboyear.Items.Add(table.Rows(i)("CAYR"))
        Next
    End Sub
    Private Sub LoadMonth(ByVal DistributorCode As String, ByVal Year As String)
        table = GetRecords("SELECT * FROM Calendar WHERE COMID = '" & DistributorCode & "' AND CAYR = '" & Year & "' ")
        For I As Integer = 0 To table.Rows.Count - 1
            cboMonth.Items.Add(table.Rows(I)("CAPN"))
        Next
    End Sub

    Private Sub cboyear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboyear.SelectedIndexChanged
        If cboyear.SelectedIndex = -1 Then Exit Sub
        LoadMonth(txtChannelCode.Text, cboyear.Text)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click, btnClear.Click, btnClose.Click, btnFinalized.Click, btnRefresh.Click
        If sender Is btnRefresh Then
            RefreshRawData()
            LoadNumberofRecord(txtChannelCode.Text, cboyear.Text, cboMonth.Text)
            LoadTotalQty(txtChannelCode.Text, cboyear.Text, cboMonth.Text)
            LoadTotalNetAmount(txtChannelCode.Text, cboyear.Text, cboMonth.Text)
            LoadDateTimeUpload(txtChannelCode.Text, cboyear.Text, cboMonth.Text)
        ElseIf sender Is btnClose Then
            ' Me.btnClose()
        ElseIf sender Is btnFinalized Then
            'If ValidateData() Then
            '    FinalizedData()
            'End If
        End If
    End Sub
    Private Function RefreshRawData() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspRawDataMedicalDoctor", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "RawData")
            cmd.Parameters.AddWithValue("@CompanyCode", txtChannelCode.Text)
            cmd.Parameters.AddWithValue("@Month", cboMonth.Text)
            cmd.Parameters.AddWithValue("@Year", cboyear.Text)


            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Clear()

            da.Fill(dt)

            GrdViewRawData.DataSource = dt
            Disconnect()

            GrdViewRawData.Columns(0).Width = 150
            GrdViewRawData.Columns(1).Width = 150
            GrdViewRawData.Columns(2).Width = 150
            GrdViewRawData.Columns(3).Width = 150
            GrdViewRawData.Columns(4).Width = 150
            GrdViewRawData.Columns(5).Width = 150
            GrdViewRawData.Columns(6).Width = 150
            GrdViewRawData.Columns(7).Width = 150
            GrdViewRawData.Columns(8).Width = 150
            GrdViewRawData.Columns(9).Width = 150
            GrdViewRawData.Columns(10).Width = 150
            GrdViewRawData.Columns(11).Width = 150
            GrdViewRawData.Columns(12).Width = 150
            GrdViewRawData.Columns(12).FormatString = "{0:F2}"
            GrdViewRawData.Columns(13).Width = 150
            GrdViewRawData.Columns(13).FormatString = "{0:F2}"
            Disconnect()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub LoadNumberofRecord(ByVal CompanyCode As String, ByVal Year As String, ByVal Month As String)
        table = GetRecords(RawData.GetNumberofRecord(CompanyCode, Year, Month))
        For i As Integer = 0 To table.Rows.Count - 1
            txtNumberofRecord.Text = table.Rows(i)("Counts")
            Exit Sub
        Next
    End Sub
    Private Sub LoadTotalQty(ByVal CompanyCode As String, ByVal Year As String, ByVal Month As String)
        table = GetRecords(RawData.GetTotalQty(CompanyCode, Year, Month))
        For i As Integer = 0 To table.Rows.Count - 1
            txtTotalQty.Text = Format(table.Rows(i)("TotalQty"), "#,##0.00")
            Exit Sub
        Next
    End Sub
    Private Sub LoadTotalNetAmount(ByVal CompanyCode As String, ByVal Year As String, ByVal Month As String)
        table = GetRecords(RawData.GetTotalNetAmount(CompanyCode, Year, Month))
        For i As Integer = 0 To table.Rows.Count - 1
            txtTotalAmount.Text = Format(table.Rows(i)("TotalNetAmount"), "#,##0.00")
            Exit Sub
        Next
    End Sub
    Private Sub LoadDateTimeUpload(ByVal CompanyCode As String, ByVal Year As String, ByVal Month As String)
        table = GetRecords(RawData.GetDateTimeUpload(CompanyCode, Year, Month))
        For i As Integer = 0 To table.Rows.Count - 1
            txtUploadDateTime.Visible = True
            txtUploadDateTime.Text = table.Rows(i)("UploadDateTime")
            Exit Sub
        Next
    End Sub

    Private Sub GrdViewRawData_CellDoubleClick(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles GrdViewRawData.CellDoubleClick
        SelectRecordMD()
        If _ModifyMedicalDoctor.DoctorName Is Nothing Then
        Else
            Dim ModifyRawData As New UIModifyRawdata
            ModifyRawData.CompanyCode = txtChannelCode.Text
            ModifyRawData.Year = cboyear.Text
            ModifyRawData.Month = cboMonth.Text
            ModifyRawData.DoctorName = _ModifyMedicalDoctor.DoctorName
            ModifyRawData.ShowDialog()
        End If
    End Sub
    Private Sub SelectRecordMD()
        If GrdViewRawData.SelectedRows.Count > 0 Then
            strKeyColumn = GrdViewRawData.SelectedRows(0).Cells(0).Value
            If GrdViewRawData.ColumnCount > 1 Then
                _ModifyMedicalDoctor.DoctorName = GrdViewRawData.SelectedRows(0).Cells(4).Value
            Else
                _ModifyMedicalDoctor.DoctorName = String.Empty
            End If
            If GrdViewRawData.ColumnCount > 2 Then
                _ModifyMedicalDoctor.PTRNO = GrdViewRawData.SelectedRows(0).Cells(5).Value
            Else
                _ModifyMedicalDoctor.PTRNO = String.Empty
            End If
        End If
    End Sub
End Class
