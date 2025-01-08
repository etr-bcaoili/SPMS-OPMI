Option Strict Off
Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Imports SPMSOPCI.ConnectionModule

Public Class UCConfig

    Private m_ConfigTypeID As Integer = -1

    Private m_ConfigTypeCode As String = String.Empty

    Private m_ConfigtypeName As String = String.Empty

    Private m_EffictivityStartDate As Date = "1/1/1900"

    Private m_EffictivityEndDate As Date = "1/1/1900"

    Public Property Configtypecode() As String
        Get
            Return m_ConfigTypeCode
        End Get
        Set(ByVal value As String)
            m_ConfigTypeCode = value
        End Set
    End Property
    Public Property ConfigtypeNama() As String
        Get
            Return m_ConfigtypeName
        End Get
        Set(ByVal value As String)
            m_ConfigtypeName = value
        End Set
    End Property
    Public Property EffictivityStartDate() As Date
        Get
            Return m_EffictivityStartDate
        End Get
        Set(ByVal value As Date)
            m_EffictivityStartDate = value
        End Set
    End Property

    Public Property EffictivityEndDate() As Date
        Get
            Return m_EffictivityEndDate
        End Get
        Set(ByVal value As Date)
            m_EffictivityEndDate = value
        End Set
    End Property

    Public Function Save() As Boolean
        Connect()

        Dim cmd As New SqlCommand("uspConfigurationTypecode", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Action", "ADD")
        cmd.Parameters.AddWithValue("@ConfigTypeID", m_ConfigTypeID)
        cmd.Parameters.AddWithValue("@ConfigTypeCode", m_ConfigTypeCode)
        cmd.Parameters.AddWithValue("@ConfigTypeName", m_ConfigtypeName)
        cmd.Parameters.AddWithValue("@EffictivityStartDate", EffictivityStartDate)
        cmd.Parameters.AddWithValue("@EffictivityEndDate", EffictivityEndDate)
        m_ConfigTypeID = cmd.ExecuteScalar
        Disconnect()

    End Function
    Public Function Delete() As Boolean
        Connect()
        Try
            Dim cmd As New SqlCommand("uspConfigurationTypecode", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Delete")
            cmd.Parameters.AddWithValue("@ConfigTypeID", m_ConfigTypeID)
            cmd.ExecuteNonQuery()
            Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As UCConfigCollection
        Dim col As New UCConfigCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_Config As New UCConfig
            Dim row As DataRow = table.Rows(j)
            m_Config.m_ConfigTypeID = row("ConfitypeID")
            m_Config.m_ConfigTypeCode = row("ConfigTypeCode")
            m_Config.m_ConfigtypeName = row("ConfigTypeName")
            m_Config.m_EffictivityEndDate = row("EffictivityStartDate")
            m_Config.m_EffictivityEndDate = row("EffictivityEndDate")
            col.Add(m_Config)
        Next
        Return col
    End Function
End Class
Public Class UCConfigCollection
    Inherits List(Of UCConfig)
End Class
