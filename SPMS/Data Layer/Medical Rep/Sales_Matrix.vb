Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class Sales_Matrix

    Private _SalesMatrixID As Integer = -1

    Private _DLTFLG As Boolean = False

    Private _STREGCD As String = String.Empty

    Private _STDISTRCTCD As String = String.Empty

    Private _STTEAMCD As String = String.Empty

    Private _STITMDIVCD As String = String.Empty

    Private _STTERRCD As String = String.Empty

    Private _STACOVCD As String = String.Empty

    Private _STACOVNAME As String = String.Empty

    Private _STSLSMNCD As String = String.Empty

    Private _STSLSMNNAME As String = String.Empty

    Private _CRTDATE As Date = "1/1/1900"

    Private _CRTU As String = String.Empty

    Private _UPDD As DateTime = "1/1/1900"

    Private _UPDU As String = String.Empty

    Private _SMID = -1

    Private _EFFECTIVITYSTARTDATE As Date = "1/1/1900"

    Private _EFFECTIVITYENDDATE As Date = "1/1/1900"

    Private _ITEMGRPCD As String = String.Empty

    Private _ISACTIVE As Boolean = True

    Private _ConfigTypeCode As String = String.Empty

    Public Property SalesMatrixID As Integer
        Get
            Return _SalesMatrixID
        End Get
        Set(value As Integer)
            _SalesMatrixID = value
        End Set
    End Property

    Public Property DLTFLG As Boolean
        Get
            Return _DLTFLG
        End Get
        Set(value As Boolean)
            _DLTFLG = value
        End Set
    End Property

    Public Property STREGCD As String
        Get
            Return _STREGCD
        End Get
        Set(value As String)
            _STREGCD = value
        End Set
    End Property

    Public Property STDISTRCTCD As String
        Get
            Return _STDISTRCTCD
        End Get
        Set(value As String)
            _STDISTRCTCD = value
        End Set
    End Property

    Public Property STTEAMCD As String
        Get
            Return _STTEAMCD
        End Get
        Set(value As String)
            _STTEAMCD = value
        End Set
    End Property
    Public Property STITMDIVCD As String
        Get
            Return _STITMDIVCD
        End Get
        Set(value As String)
            _STITMDIVCD = value
        End Set
    End Property
    Public Property STTERRCD As String
        Get
            Return _STTERRCD
        End Get
        Set(value As String)
            _STTERRCD = value
        End Set
    End Property
    Public Property STACOVCD As String
        Get
            Return _STACOVCD
        End Get
        Set(value As String)
            _STACOVCD = value
        End Set
    End Property
    Public Property STACOVNAME As String
        Get
            Return _STACOVNAME
        End Get
        Set(value As String)
            _STACOVNAME = value
        End Set
    End Property
    Public Property STSLSMNCD As String
        Get
            Return _STSLSMNCD
        End Get
        Set(value As String)
            _STSLSMNCD = value
        End Set
    End Property
    Public Property STSLSMNNAME As String
        Get
            Return _STSLSMNNAME
        End Get
        Set(value As String)
            _STSLSMNNAME = value
        End Set
    End Property
    Public Property CRTDATE As Date
        Get
            Return _CRTDATE
        End Get
        Set(value As Date)
            _CRTDATE = value
        End Set
    End Property
    Public Property CRTU As String
        Get
            Return _CRTU
        End Get
        Set(value As String)
            _CRTU = value
        End Set
    End Property
    Public Property UPDD As DateTime
        Get
            Return _UPDD
        End Get
        Set(value As DateTime)
            _UPDD = value
        End Set
    End Property
    Public Property UPDU As String
        Get
            Return _UPDU
        End Get
        Set(value As String)
            _UPDU = value
        End Set
    End Property
    Public Property EffectivityStartDate As Date
        Get
            Return _EFFECTIVITYSTARTDATE
        End Get
        Set(value As Date)
            _EFFECTIVITYSTARTDATE = value
        End Set
    End Property
    Public Property EffectivityEndDate As Date
        Get
            Return _EFFECTIVITYENDDATE
        End Get
        Set(value As Date)
            _EFFECTIVITYENDDATE = value
        End Set
    End Property
    Public Property ITEMGRPCD As String
        Get
            Return _ITEMGRPCD
        End Get
        Set(value As String)
            _ITEMGRPCD = value
        End Set
    End Property
    Public Property IsActive As Boolean
        Get
            Return _ISACTIVE
        End Get
        Set(value As Boolean)
            _ISACTIVE = value
        End Set
    End Property

    Public Property Configtypecode As String
        Get
            Return _ConfigTypeCode
        End Get
        Set(value As String)
            _ConfigTypeCode = value
        End Set
    End Property

    Public Function Save() As Boolean
        Try
            Connect()
            Dim cmd As New SqlCommand("uspSalesMatrix", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "ADD")
            cmd.Parameters.AddWithValue("@DLTFLG", DLTFLG)
            cmd.Parameters.AddWithValue("@STREGCD", STREGCD)
            cmd.Parameters.AddWithValue("@STDISTRCTCD", STDISTRCTCD)
            cmd.Parameters.AddWithValue("@STTEAMCD", STTEAMCD)
            cmd.Parameters.AddWithValue("@STITMDIVCD", STITMDIVCD)
            cmd.Parameters.AddWithValue("@STTERRCD", STTERRCD)
            cmd.Parameters.AddWithValue("@STACOVCD", STACOVCD)
            cmd.Parameters.AddWithValue("@STACOVNAME", STACOVNAME)
            cmd.Parameters.AddWithValue("@STSLSMNCD", STSLSMNCD)
            cmd.Parameters.AddWithValue("@STSLSMNNAME", STSLSMNNAME)
            cmd.Parameters.AddWithValue("@CRTDATE", CRTDATE)
            cmd.Parameters.AddWithValue("@CRTU", CRTU)
            cmd.Parameters.AddWithValue("@UPDD", UPDD)
            cmd.Parameters.AddWithValue("@UPDU", UPDU)
            cmd.Parameters.AddWithValue("@EffectivityStartDate", EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EffectivityEndDate", EffectivityEndDate)
            cmd.Parameters.AddWithValue("@ITEMGRPCD", ITEMGRPCD)
            cmd.Parameters.AddWithValue("@IsActive", IsActive)
            cmd.Parameters.AddWithValue("@Configtypecode", Configtypecode)
            _SalesMatrixID = cmd.ExecuteScalar()
            Disconnect()
            Return True
        Catch ex As System.Exception
            Disconnect()
            Throw
        End Try
    End Function

    Public Function Edit() As Boolean
        Try
            Connect()
            Dim cmd As SqlCommand = New SqlCommand("uspSalesMatrix", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "UPDATE")
            cmd.Parameters.AddWithValue("@DLTFLG", DLTFLG)
            cmd.Parameters.AddWithValue("@STREGCD", STREGCD)
            cmd.Parameters.AddWithValue("@STDISTRCTCD", STDISTRCTCD)
            cmd.Parameters.AddWithValue("@STTEAMCD", STTEAMCD)
            cmd.Parameters.AddWithValue("@STITMDIVCD", STITMDIVCD)
            cmd.Parameters.AddWithValue("@STTERRCD", STTERRCD)
            cmd.Parameters.AddWithValue("@STACOVCD", STACOVCD)
            cmd.Parameters.AddWithValue("@STACOVNAME", STACOVNAME)
            cmd.Parameters.AddWithValue("@STSLSMNCD", STSLSMNCD)
            cmd.Parameters.AddWithValue("@STSLSMNNAME", STSLSMNNAME)
            cmd.Parameters.AddWithValue("@CRTDATE", CRTDATE)
            cmd.Parameters.AddWithValue("@CRTU", CRTU)
            cmd.Parameters.AddWithValue("@UPDD", UPDD)
            cmd.Parameters.AddWithValue("@UPDU", UPDU)
            cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", EffectivityEndDate)
            cmd.Parameters.AddWithValue("@ITEMGRPCD", ITEMGRPCD)
            cmd.Parameters.AddWithValue("@ISACTIVE", IsActive)
            cmd.Parameters.AddWithValue("@ConfigTypeCode", Configtypecode)
            cmd.Parameters.AddWithValue("@SMID", SalesMatrixID)
            cmd.ExecuteNonQuery()
            Disconnect()
            Return True
        Catch ex As Exception
            Disconnect()
            Throw
        End Try
    End Function
    Public Function Delete() As Boolean
        Try
            Connect()
            Dim cmd As SqlCommand = New SqlCommand("uspSalesMatrix", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "DELETE")
            cmd.Parameters.AddWithValue("@SMID", SalesMatrixID)
            cmd.ExecuteNonQuery()
            Disconnect()
            Return True
        Catch ex As Exception
            Disconnect()
            Throw
        End Try
    End Function
    Public Shared Function GetSalesmatrixSql() As String
        Return "Select Distinct STTERRCD,STTERRCD [Territory Code],STACOVNAME [Territory Name],Configtypecode [Configtype Code] from SalesMatrix Where DLTFLG = 0 "
    End Function

End Class
