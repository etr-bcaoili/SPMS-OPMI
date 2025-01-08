Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports SPMSOPCI.ConnectionModule

Public Class AreaCoverages

    Private m_STTeamID As Integer = -1

    Private m_DTFLG As String = String.Empty

    Private m_STACOVCD As String = String.Empty

    Private m_STACOVNAME As String = String.Empty

    Private m_CRTDATE As Date = "1/1/1900"

    Private m_UPDD As Date = "1/1/1900"

    Private m_EffictivetyStartDate As Date = "1/1/1900"

    Private m_EffictivetyEndDate As Date = "1/1/1900"

    Private m_ConfigtypeCode As String = String.Empty

    Public Property DTFLG() As String
        Get
            Return m_DTFLG
        End Get
        Set(ByVal value As String)
            m_DTFLG = value
        End Set
    End Property
    Public Property STACOVCD() As String
        Get
            Return m_STACOVCD
        End Get
        Set(ByVal value As String)
            m_STACOVCD = value
        End Set
    End Property
    Public Property STACOVNAME() As String
        Get
            Return m_STACOVNAME
        End Get
        Set(ByVal value As String)
            m_STACOVNAME = value
        End Set
    End Property
    Public Property CRTDATE() As String
        Get
            Return m_CRTDATE
        End Get
        Set(ByVal value As String)
            m_CRTDATE = value
        End Set
    End Property
    Public Property UPDD() As Date
        Get
            Return m_UPDD
        End Get
        Set(ByVal value As Date)
            m_UPDD = value
        End Set
    End Property
    Public Property EffictivetyStartDate() As Date
        Get
            Return m_EffictivetyStartDate
        End Get
        Set(ByVal value As Date)
            m_EffictivetyStartDate = value
        End Set
    End Property
    Public Property EffictivetyEndDate() As Date
        Get
            Return m_EffictivetyEndDate
        End Get
        Set(ByVal value As Date)
            m_EffictivetyEndDate = value
        End Set
    End Property
    Public Property ConfigTypeCode() As String
        Get
            Return m_ConfigtypeCode
        End Get
        Set(ByVal value As String)
            m_ConfigtypeCode = value
        End Set
    End Property

    Public Function Save() As Boolean
        Connect()
        Try
            Dim cmd As New SqlCommand("uspSTAreaCoverage", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "ADD")
            cmd.Parameters.AddWithValue("@STTemaID", m_STTeamID)
            cmd.Parameters.AddWithValue("@STACOVCD", m_STACOVCD)
            cmd.Parameters.AddWithValue("@STACOVNAME", m_STACOVNAME)
            cmd.Parameters.AddWithValue("@CRTDATE", m_CRTDATE)
            cmd.Parameters.AddWithValue("@UPDD", m_UPDD)
            cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", m_EffictivetyStartDate)
            cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", m_EffictivetyEndDate)
            cmd.Parameters.AddWithValue("@ConfigTypeCode", m_ConfigtypeCode)
            cmd.Parameters.AddWithValue("@DLTFLG", m_DTFLG)
            m_STTeamID = cmd.ExecuteScalar()
            Disconnect()
            Return True
        Catch ex As System.Exception
            Disconnect()
            Throw
        End Try
    End Function
    Public Shared Function CheckField(ByVal CompanyCode As String) As Boolean
        Return ExecuteCommand("Select * from STAreaCoverage where ConfigTypeCode = '" & CompanyCode & "'")
    End Function
    Public Shared Function DeleteField(ByVal CompanyCode As String) As Boolean
        Return ExecuteCommand("Delete from STAreaCoverage where ConfigTypeCode = '" & CompanyCode & "'")
    End Function
End Class
