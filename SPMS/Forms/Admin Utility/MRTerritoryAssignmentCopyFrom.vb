Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class MRTerritoryAssignmentCopyFrom

    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private table As DataTable

    Private Sub lnkStartProcess_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStartProcess.LinkClicked
        If ValidateData() Then
            StartProcess()
        End If
    End Sub

    Private Function ValidateData() As Boolean
        m_HasError = False

        If cboConfig.Text = String.Empty Or cboConfig.Text Is Nothing Then
            m_Err.SetError(cboConfig, "ConfigType is required")
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
        Dim cmd As New SqlCommand("uspMRTerritoryAssignmentCopyFrom", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@ConfigTypeCode", cboConfig.Text)
        cmd.Parameters.AddWithValue("@EffectivityStartDate", dt2From.Text)
        cmd.Parameters.AddWithValue("@EffectivityEndDate", dt2To.Text)
        cmd.Parameters.AddWithValue("@FromDate", dt1From.Text)
        cmd.Parameters.AddWithValue("@ToDate", dt1To.Text)

        ret = cmd.ExecuteScalar
        Disconnect()
        If ret = 1 Then
            VDialog.Show("MR Territory Assignment Successfully Copied", "Copy From", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Close()
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

    Private Sub MRTerritoryAssignmentCopyFrom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadConfigType()
    End Sub
    Private Sub LoadConfigType()
        table = GetRecords("Select ConfigTypeCode from ConfigurationType")
        For i As Integer = 0 To table.Rows.Count - 1
            cboConfig.Items.Add(table.Rows(i)("ConfigTypeCode"))
        Next
    End Sub
End Class