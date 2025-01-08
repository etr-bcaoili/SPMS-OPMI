Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class ZipCodeTerritoryMappingCopyFrom
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private Sub lnkStartProcess_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStartProcess.LinkClicked
        If ValidateData() Then
            StartProcess()
        End If
    End Sub

    Private Function ValidateData() As Boolean
        m_HasError = False


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
        Dim cmd As New SqlCommand("uspZipCodeTerritoryMappingCopyFrom", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EffectivityStartDate", dt2From.Value.ToShortDateString)
        cmd.Parameters.AddWithValue("@EffectivityEndDate", dt2To.Value.ToShortDateString)
        cmd.Parameters.AddWithValue("@FromDate", dt1From.Value.ToShortDateString)
        cmd.Parameters.AddWithValue("@ToDate", dt1To.Value.ToShortDateString)

        ret = cmd.ExecuteScalar
        Disconnect()
        If ret = 1 Then
            ShowInformation("Zip Code Territory Mapping Successfully Copied", "Copy From")
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Close()
    End Sub

    Private Sub CustomerMappingCopyFrom_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub
End Class