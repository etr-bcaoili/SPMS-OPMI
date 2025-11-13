Imports System.Data.SqlClient
Public Class ExportSourceData

    Private _FromMonth As String = String.Empty

    Private _ToMonth As String = String.Empty

    Private _LastYear As String = String.Empty

    Private _Year As String = String.Empty

    Private _Companycode As String = String.Empty

    Private _ConfigtypeCode As String = String.Empty


    Public Property FromMonth As String
        Get
            Return _FromMonth
        End Get
        Set(value As String)
            _FromMonth = value
        End Set
    End Property
    Public Property ToMonth As String
        Get
            Return _ToMonth
        End Get
        Set(value As String)
            _ToMonth = value
        End Set
    End Property
    Public Property Year As String
        Get
            Return _Year
        End Get
        Set(value As String)
            _Year = value
        End Set
    End Property
    Public Property LastYear As String
        Get
            Return _LastYear
        End Get
        Set(value As String)
            _LastYear = value
        End Set
    End Property
    Public Property CompanyCode As String
        Get
            Return _Companycode
        End Get
        Set(value As String)
            _Companycode = value
        End Set
    End Property
    Public Property ConfigtypeCode As String
        Get
            Return _ConfigtypeCode
        End Get
        Set(value As String)
            _ConfigtypeCode = value
        End Set
    End Property

    Public Function TrasnferData() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspSourceDatePerioToPeriod", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@Action", "RefreshData")
            cmd.Parameters.AddWithValue("@ConfigtypeCode", _ConfigtypeCode)
            cmd.Parameters.AddWithValue("@CompanyCode", _Companycode)
            cmd.Parameters.AddWithValue("@Year", _Year)
            cmd.Parameters.AddWithValue("@StartMonth", _FromMonth)
            cmd.Parameters.AddWithValue("@EndMonth", _ToMonth)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function TrasnferDataTerritoryPerformance() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspSalesAnalysisReport_ProductPerformancePerodToPeriodByPIVOT", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@ConfigTypeCode", _ConfigtypeCode)
            cmd.Parameters.AddWithValue("@Year", _Year)
            cmd.Parameters.AddWithValue("@Month", _FromMonth)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function DMItemCustomerTerritoryManagerComparativePeriodByPivot() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspDMItemCustomerTerritoryManagerComparativePeriodByPivot", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@ConfigtypeCode", _ConfigtypeCode)
            cmd.Parameters.AddWithValue("@CompanyCode", _Companycode)
            cmd.Parameters.AddWithValue("@Year", _Year)
            cmd.Parameters.AddWithValue("@StartMonth", _FromMonth)
            cmd.Parameters.AddWithValue("@EndMonth", _ToMonth)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function DMCustomerTerritoryComparativePeriodtoPeriodNetVATMTDM() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("RptDMCustomerTerritoryComparativePeriodtoPeriodNetVATMTDM", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@ConfigtypeCode", _ConfigtypeCode)
            cmd.Parameters.AddWithValue("@Year", _Year)
            cmd.Parameters.AddWithValue("@StartMonth", _FromMonth)
            cmd.Parameters.AddWithValue("@EndMonth", _ToMonth)
            cmd.Parameters.AddWithValue("@CompanyCode", _Companycode)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function TrasnferDelete() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspSourceDataView", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@Action", "DELETE")
            cmd.Parameters.AddWithValue("@ChannelCode", _Companycode)
            cmd.Parameters.AddWithValue("@Year", _Year)
            cmd.Parameters.AddWithValue("@FromMonth", _FromMonth)
            cmd.Parameters.AddWithValue("@ToMonth", _ToMonth)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function TransferDatabyTerritorybyPivot(ByVal Month As String, ByVal ToMonth As String, ByVal ConfigtypeCode As String) As String
        Return "Select * from [SalesAnalysisReportProductPerformancePerodToPeriodByPIVOT] Where [Credit Month No] between '" & Month & "' And '" & ToMonth & "' and ConfigtypeCode = '" & ConfigtypeCode & "'"
    End Function
    Public Function DMItemCustomerTerritoryManagerComparativePeriodByPivot(ByVal StartMonth As String, ByVal EndMonth As String, ByVal ConfigtypeCode As String) As String
        Return "Select * from [DMItemCustomerTerritoryManagerComparativePeriodByPivot] Where [Credit Month No] between '" & StartMonth & "' And '" & EndMonth & "' And [ConfigtypeCode] = '" & ConfigtypeCode & "' Order by [Credit Month No]"
    End Function
    Public Function DMCustomerTerritoryComparativePeriodtoPeriodNetVATMTDM(ByVal Year As String, ByVal StartMonth As String, ByVal ToMonth As String, ByVal ConfigtypeCode As String) As String
        Return "SELECT * FROM [DMCustomerTerritoryComparativePeriodtoPeriodNetVATMTDM] WHERE Year = '" & Year & "' AND Month Between '" & StartMonth & "' AND '" & ToMonth & "' AND [Configtype Code] = '" & ConfigtypeCode & "'"
    End Function
    Public Function GetMonthReport(ByVal ConfigtypeCode As String, ByVal ToYear As String, ByVal FromMonth As String, ByVal ToMonth As String) As String
        Return "Select Distinct Month from SC02File Where Month between '" & FromMonth & "' and '" & ToMonth & "' And Year = '" & ToYear & "' and Configtypecode = '" & ConfigtypeCode & "'"
    End Function
End Class
