Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Imports System.Linq
Public Class MDPrescriptionAccount

    Private m_ID As Integer = -1

    Private m_MDID As Integer = -1

    Private m_AccountCode As String = String.Empty

    Private m_AccountName As String = String.Empty

    Private m_ShipToCode As String = String.Empty

    Private m_ChannelCode As String = String.Empty

    Private m_CreatedBy As String = String.Empty

    Private m_LastModifiedBy As String = String.Empty
    Public ReadOnly Property ID As Integer
        Get
            Return m_ID
        End Get
    End Property
    Public Property MDID As String
        Get
            Return m_MDID
        End Get
        Set(value As String)
            m_MDID = value
        End Set
    End Property
    Public Property AccountCode As String
        Get
            Return m_AccountCode
        End Get
        Set(value As String)
            m_AccountCode = value
        End Set
    End Property
    Public Property AccountName As String
        Get
            Return m_AccountName
        End Get
        Set(value As String)
            m_AccountName = value
        End Set
    End Property
    Public Property ShipToCode As String
        Get
            Return m_ShipToCode
        End Get
        Set(value As String)
            m_ShipToCode = value
        End Set
    End Property
    Public Property ChannelCode As String
        Get
            Return m_ChannelCode
        End Get
        Set(value As String)
            m_ChannelCode = value
        End Set
    End Property
    Public Property CreatedBy As String
        Get
            Return m_CreatedBy
        End Get
        Set(value As String)
            m_CreatedBy = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As MDPrescriptionAccountCollection
        Dim col As New MDPrescriptionAccountCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim m_MDPrescriptionAccount As New MDPrescriptionAccount
            Dim row As DataRow = Table.Rows(j)
            m_MDPrescriptionAccount.m_ID = row("ID")
            m_MDPrescriptionAccount.m_MDID = row("MDID")
            m_MDPrescriptionAccount.m_AccountCode = row("ACCOUNTCODE")
            m_MDPrescriptionAccount.m_AccountName = row("ACCOUNTNAME")
            m_MDPrescriptionAccount.m_ShipToCode = row("SHIPTOCODE")
            m_MDPrescriptionAccount.m_ChannelCode = row("CHANNELCODE")
            m_MDPrescriptionAccount.m_CreatedBy = row("CreatedBy")
            m_MDPrescriptionAccount.m_LastModifiedBy = row("LastModifiedBy")
            col.Add(m_MDPrescriptionAccount)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspMDPrescritionAccount", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.Parameters.AddWithValue("@MDID", m_MDID)
            cmd.Parameters.AddWithValue("@ACCOUNTCODE", m_AccountCode)
            cmd.Parameters.AddWithValue("@ACCOUNTNAME", m_AccountName)
            cmd.Parameters.AddWithValue("@SHIPTCODE", m_ShipToCode)
            cmd.Parameters.AddWithValue("@CHANNELCODE", m_ChannelCode)
            cmd.Parameters.AddWithValue("@CreatedBy", m_CreatedBy)
            cmd.Parameters.AddWithValue("@LastModifiedBy", m_LastModifiedBy)
            m_MDID = cmd.ExecuteScalar
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            SPMSOPCI.ConnectionModule.Disconnect()
        End Try
    End Function
    Public Function Delete() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspMDPrescritionAccount", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "DELETE")
            cmd.Parameters.AddWithValue("@MDID", m_MDID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
End Class
Public Class MDPrescriptionAccountCollection
    Inherits List(Of MDPrescriptionAccount)
End Class