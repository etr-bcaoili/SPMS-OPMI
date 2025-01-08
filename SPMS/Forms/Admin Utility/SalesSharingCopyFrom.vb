Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class SalesSharingCopyFrom
    Private m_RsDistributor As New ADODB.Recordset
    Dim m_RsYear As ADODB.Recordset
    Private m_Err As New ErrorProvider
    Private m_Year As New ADODB.Recordset
    Private m_HasError As Boolean = False
    Private m_RsMonth As New ADODB.Recordset
    Private table As DataTable

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
    Private Sub lnkStartProcess_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStartProcess.LinkClicked
        If ValidateData() Then
            StartProcess()
        End If
    End Sub
    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False
        If cboCompany.Text = String.Empty Or cboCompany.Text Is Nothing Then
            m_Err.SetError(cboCompany, "Channel is required")
            m_HasError = True
        End If
        If cboConfig.Text = String.Empty Or cboConfig.Text Is Nothing Then
            m_Err.SetError(cboConfig, "ConfigType is required")
            m_HasError = True
        End If
        If (cboyear.Text) > (cboyear.Text) Or (cboyear.Text) < (cboyear.Text) Then
            m_Err.SetError(cboyear, "Not greater than year ")
            m_HasError = True
        End If
        If (month.Text) > (month.Text) Or (month.Text) < (month.Text) Then
            m_Err.SetError(cboyear2, "Not greater month")
            m_HasError = True
        End If
        Return Not m_HasError
    End Function
    Private Sub StartProcess()
        Connect()
        Dim ret As Integer = -1
        Dim cmd As New SqlCommand("uspSharingCopyFrom", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.AddWithValue("@COMID", cboCompany.Text)
        cmd.Parameters.AddWithValue("@ConfigTypeCode", cboConfig.Text)
        cmd.Parameters.AddWithValue("@TOMONTH", month2.Text)
        cmd.Parameters.AddWithValue("@TOYEAR", cboyear2.Text)
        cmd.Parameters.AddWithValue("@FROMYEAR", cboyear.Text)
        cmd.Parameters.AddWithValue("@FROMMONTH", month.Text)
        ret = cmd.ExecuteScalar
        Disconnect()
        If ret = 1 Then
            VDialog.Show("Sales Sharing Successfully Copied", "Copy From", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
   
    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Close()
    End Sub
    Private Sub CustomerMappingCopyFrom_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDistributor()
        loadConfigType()
        LoadYear()
    End Sub
    Private Sub LoadConfigType()
        table = GetRecords("Select ConfigTypeCode from ConfigurationType")
        For i As Integer = 0 To table.Rows.Count - 1
            cboConfig.Items.Add(table.Rows(i)("ConfigTypeCode"))
        Next
    End Sub
    Private Sub cboYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboyear.SelectedIndexChanged
        fillterSharing()
        If cboyear.SelectedIndex = -1 Then Exit Sub
        LoadMonth(cboCompany.Text, cboyear.Text)

    End Sub
    Private Sub LoadMonth(ByVal DistributorCode As String, ByVal Year As String)

        If m_RsMonth.State = 1 Then m_RsMonth.Close()
        m_RsMonth.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        m_RsMonth.Open("SELECT * FROM Calendar WHERE COMID = '" & DistributorCode & "' AND CAYR = '" & Year & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_RsMonth.RecordCount > 0 Then
            month.Items.Clear()
            month2.Items.Clear()
            For m As Integer = 0 To m_RsMonth.RecordCount - 1
                month.Items.Add(m_RsMonth.Fields("CAPN").Value)
                month2.Items.Add(m_RsMonth.Fields("CAPN").Value)
                m_RsMonth.MoveNext()
            Next
        End If

    End Sub
    Private Sub fillterSharing()
        On Error Resume Next
        m_RsYear.Open("Select * from Sharing where " & "CUTYEAR" & " LIKE '" & cboCompany.Text & _
                     "*' AND " & "CUTMO" & " LIKE '" & month.Text & _
                     "*' AND " & "COMID" & " LIKE '" & cboCompany.Text & "*'", ConnectionModule.SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

    End Sub
    Private Sub LoadYear()
        If m_Year.State = 1 Then m_Year.Close()
        m_Year.Open("SELECT Distinct CAYR  FROM Calendar WHERE COMID = '" & ConnectionModule.GetDefaultCompany & "' ", ConnectionModule.SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If m_Year.RecordCount > 0 Then
            cboyear.Items.Clear()
            cboyear2.Items.Clear()
            For m As Integer = 0 To m_Year.RecordCount - 1
                cboyear.Items.Add(m_Year.Fields("CAYR").Value)
                cboyear2.Items.Add(m_Year.Fields("CAYR").Value)
                m_Year.MoveNext()
            Next
        End If
    End Sub

    Private Sub month2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles month2.SelectedIndexChanged

    End Sub

    Private Sub cboConfig_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboConfig.SelectedIndexChanged
        If cboConfig.SelectedIndex <> -1 Then
            GetConfigName(cboConfig.Text)
        Else
            txtconfigname.Text = String.Empty
        End If
    End Sub
    Private Function GetConfigName(ByVal ConfigName As String) As Boolean
        table = GetRecords("Select * from ConfigurationType where ConfigTypeCOde = '" & cboConfig.Text & "'")
        For i As Integer = 0 To table.Rows.Count - 1
            txtconfigname.Text = table.Rows(i)("ConfigTypeName")
        Next
    End Function
End Class