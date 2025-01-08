Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class CustomerMappingCopyFrom
    Private m_RsDistributor As New ADODB.Recordset

    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
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
        m_HasError = False

        If cboCompany.Text = String.Empty Or cboCompany.Text Is Nothing Then
            m_Err.SetError(cboCompany, "Channel is required")
            m_HasError = True
        End If

        If CDate(dt1From.Value.ToShortDateString) > CDate(dt1To.Value.ToShortDateString) Then
            m_Err.SetError(dt1From, "Effectivity Start Date From should not be greater than the effectivity end date from.")
            m_HasError = True
        End If

        If CDate(dt2From.Value.ToShortDateString) > CDate(dt2To.Value.ToShortDateString) Then
            m_Err.SetError(dt2From, "Effectivity Start Date From should not be greater than the effectivity end date from.")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function

    Private Sub StartProcess()

        Connect()
        Dim ret As Integer = -1
        Dim cmd As New SqlCommand("uspCustomerMappingCopyFrom", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@COMID", cboCompany.Text)
        cmd.Parameters.AddWithValue("@EffectivityStartDate", dt2From.Value.ToShortDateString)
        cmd.Parameters.AddWithValue("@EffectivityEndDate", dt2To.Value.ToShortDateString)
        cmd.Parameters.AddWithValue("@FromDate", dt1From.Value.ToShortDateString)
        cmd.Parameters.AddWithValue("@ToDate", dt1To.Value.ToShortDateString)

        ret = cmd.ExecuteScalar
        Disconnect()
        If ret = 1 Then
            ShowInformation("Customer Mapping Successfully Copied", "Copy From")
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Close()
    End Sub

    Private Sub CustomerMappingCopyFrom_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDistributor()
    End Sub
End Class