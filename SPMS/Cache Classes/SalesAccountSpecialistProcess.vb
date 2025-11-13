Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class SalesAccountSpecialistProcess
    Private _ID As Integer = -1

    Private _Year As Integer = -1

    Private _Month As String = String.Empty

    Private _SalesAccountSpecialistCode As String = String.Empty

    Private _SalesAccountSpecialistName As String = String.Empty

    Private _EffectivityStartDate As Date = "1/1/1990"

    Private _EffectivityEndDate As Date = "1/1/1990"

    Private _ConfigtypeCode As String = String.Empty

    Private _DistrictGroup As String = String.Empty

    Private _DistrictName As String = String.Empty

    Private _AreaName As String = String.Empty

    Private _CompanyCode As String = String.Empty

    Private _CustomerCode As String = String.Empty

    Private _CustomerName As String = String.Empty

    Private _Target As Decimal = 0

    Private _IsCheck As Boolean = False

    Private _Createby As String = String.Empty

    Private _UpCreateby As String = String.Empty

    Public ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property

    Public Property Year As Integer
        Get
            Return _Year
        End Get
        Set(value As Integer)
            _Year = value
        End Set
    End Property

    Public Property Month As String
        Get
            Return _Month
        End Get
        Set(value As String)
            _Month = value
        End Set
    End Property

    Public Property SalesAccountSpecialistCode As String
        Get
            Return _SalesAccountSpecialistCode
        End Get
        Set(value As String)
            _SalesAccountSpecialistCode = value
        End Set
    End Property
    Public Property SalesAccountSpecialistName As String
        Get
            Return _SalesAccountSpecialistName
        End Get
        Set(value As String)
            _SalesAccountSpecialistName = value
        End Set
    End Property

    Public Property EffectivityStartDate As Date
        Get
            Return _EffectivityStartDate
        End Get
        Set(value As Date)
            _EffectivityStartDate = value
        End Set
    End Property
    Public Property EffectivityEndDate As Date
        Get
            Return _EffectivityEndDate
        End Get
        Set(value As Date)
            _EffectivityEndDate = value
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
    Public Property DistrictGroup As String
        Get
            Return _DistrictGroup
        End Get
        Set(value As String)
            _DistrictGroup = value
        End Set
    End Property
    Public Property DistrictName As String
        Get
            Return _DistrictName
        End Get
        Set(value As String)
            _DistrictName = value
        End Set
    End Property
    Public Property AreaName As String
        Get
            Return _AreaName
        End Get
        Set(value As String)
            _AreaName = value
        End Set
    End Property
    Public Property CompanyCode As String
        Get
            Return _CompanyCode
        End Get
        Set(value As String)
            _CompanyCode = value
        End Set
    End Property
    Public Property CustomerCode As String
        Get
            Return _CustomerCode
        End Get
        Set(value As String)
            _CustomerCode = value
        End Set
    End Property
    Public Property CustomerName As String
        Get
            Return _CustomerName
        End Get
        Set(value As String)
            _CustomerName = value
        End Set
    End Property

    Public Property Target As Decimal
        Get
            Return _Target
        End Get
        Set(value As Decimal)
            _Target = value
        End Set
    End Property
    Public Property Ischecked As Boolean
        Get
            Return _IsCheck
        End Get
        Set(value As Boolean)
            _IsCheck = value
        End Set
    End Property
    Public Property Createby As String
        Get
            Return _Createby
        End Get
        Set(value As String)
            _Createby = value
        End Set
    End Property
    Public Property UpCreateby As String
        Get
            Return _UpCreateby
        End Get
        Set(value As String)
            _UpCreateby = value
        End Set
    End Property

    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As SalesAccountSpecialistProcessCollection
        Dim col As New SalesAccountSpecialistProcessCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _SalesAccountSpecialistProcess As New SalesAccountSpecialistProcess
            Dim row As DataRow = Table.Rows(j)
            _SalesAccountSpecialistProcess._ID = row("ID")
            _SalesAccountSpecialistProcess._Year = row("Year")
            _SalesAccountSpecialistProcess._Month = row("Month")
            _SalesAccountSpecialistProcess._SalesAccountSpecialistCode = row("SalesAccountCode")
            _SalesAccountSpecialistProcess._SalesAccountSpecialistName = row("SalesAccountName")
            _SalesAccountSpecialistProcess._ConfigtypeCode = row("ConfigtypeCode")
            _SalesAccountSpecialistProcess._DistrictGroup = row("DistrictGroup")
            _SalesAccountSpecialistProcess._DistrictName = row("DistrictName")
            _SalesAccountSpecialistProcess._AreaName = row("AreaName")
            _SalesAccountSpecialistProcess._CompanyCode = row("CompanyCode")
            _SalesAccountSpecialistProcess._CustomerCode = row("CustomerCode")
            _SalesAccountSpecialistProcess._CustomerName = row("CustomerName")
            _SalesAccountSpecialistProcess._Target = row("Target")
            col.Add(_SalesAccountSpecialistProcess)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspProcessSalesAccountSpecialist", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Save")
            cmd.Parameters.AddWithValue("@ID", _ID)
            cmd.Parameters.AddWithValue("@Year", _Year)
            cmd.Parameters.AddWithValue("@Month", _Month)
            cmd.Parameters.AddWithValue("@SalesAccountCode", _SalesAccountSpecialistCode)
            cmd.Parameters.AddWithValue("@SalesAccountName", _SalesAccountSpecialistName)
            cmd.Parameters.AddWithValue("@ConfigtypeCode", _ConfigtypeCode)
            cmd.Parameters.AddWithValue("@DistrictGroup", _DistrictGroup)
            cmd.Parameters.AddWithValue("@DistrictName", _DistrictName)
            cmd.Parameters.AddWithValue("@AreaName", _AreaName)
            cmd.Parameters.AddWithValue("@CompanyCode", _CompanyCode)
            cmd.Parameters.AddWithValue("@CustomerCode", _CustomerCode)
            cmd.Parameters.AddWithValue("@CustomerName", _CustomerName)
            cmd.Parameters.AddWithValue("@Target", _Target)
            _ID = cmd.ExecuteScalar
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Function SASDistrictSave() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspSalesAccountSpecialistDistrict", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "SAVE")
            cmd.Parameters.AddWithValue("@ID", _ID)
            cmd.Parameters.AddWithValue("@SASCode   ", _SalesAccountSpecialistCode)
            cmd.Parameters.AddWithValue("@EffectivityStartDate", _EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EffectivityEndDate", _EffectivityEndDate)
            cmd.Parameters.AddWithValue("@CheckIn", _IsCheck)
            cmd.Parameters.AddWithValue("@DistrictGroupCode", _DistrictGroup)
            cmd.Parameters.AddWithValue("@DistrictName", _DistrictName)
            cmd.Parameters.AddWithValue("@TargetAmount", _Target)
            cmd.Parameters.AddWithValue("@Createby", _Createby)
            cmd.Parameters.AddWithValue("@Updateby", _UpCreateby)
            _ID = cmd.ExecuteScalar
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Function SASAreaNameSave() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspSalesAccountSpecialistAreaName", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "SAVE")
            cmd.Parameters.AddWithValue("@ID", _ID)
            cmd.Parameters.AddWithValue("@SASCode   ", _SalesAccountSpecialistCode)
            cmd.Parameters.AddWithValue("@EffectivityStartDate", _EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EffectivityEndDate", _EffectivityEndDate)
            cmd.Parameters.AddWithValue("@CheckIn", _IsCheck)
            cmd.Parameters.AddWithValue("@DistrictGroupCode", _DistrictGroup)
            cmd.Parameters.AddWithValue("@DistrictName", _DistrictName)
            cmd.Parameters.AddWithValue("@AreaName", _AreaName)
            cmd.Parameters.AddWithValue("@TargetAmount", _Target)
            cmd.Parameters.AddWithValue("@Createby", _Createby)
            cmd.Parameters.AddWithValue("@Updateby", _UpCreateby)
            _ID = cmd.ExecuteScalar
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Function SASChannelbyCustomerSave() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspSalesAccountSpecialistChannelbyCustomer", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "SAVE")
            cmd.Parameters.AddWithValue("@ID", _ID)
            cmd.Parameters.AddWithValue("@SASCode   ", _SalesAccountSpecialistCode)
            cmd.Parameters.AddWithValue("@EffectivityStartDate", _EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EffectivityEndDate", _EffectivityEndDate)
            cmd.Parameters.AddWithValue("@CheckIn", _IsCheck)
            cmd.Parameters.AddWithValue("@ChannelCode", _CompanyCode)
            cmd.Parameters.AddWithValue("@CustomerCode", _CustomerCode)
            cmd.Parameters.AddWithValue("@CustomerName", _CustomerName)
            cmd.Parameters.AddWithValue("@DistrictGroupCode", _DistrictGroup)
            cmd.Parameters.AddWithValue("@DistrictName", _DistrictName)
            cmd.Parameters.AddWithValue("@AreaName", _AreaName)
            cmd.Parameters.AddWithValue("@TargetAmount", _Target)
            cmd.Parameters.AddWithValue("@Createby", _Createby)
            cmd.Parameters.AddWithValue("@Updateby", _UpCreateby)
            _ID = cmd.ExecuteScalar
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Shared Function CheckofSalesAccountSpecialistAlreadyExist(ByVal SASCode As String, ByVal ConfigtypeCode As String) As String
        Return ExecuteCommand("Select Distinct 'A' from  [dbo].[ProcessSalesAccountSpecialist] Where SalesAccountCode = '" & SASCode & "' AND ConfigtypeCode  = '" & ConfigtypeCode & "'") = "A"
    End Function
    Public Shared Function SalesAccountSpecialistDistrictDelete(ByVal SASCode As String) As String
        Return ExecuteCommand("DELETE FROM SalesAccountSpecialistDistrict Where SASCode = '" & SASCode & "'")
    End Function
    Public Shared Function SalesAccountSpecialistAreaNameDelete(ByVal SASCode As String) As String
        Return ExecuteCommand("DELETE FROM SalesAccountSpecialistAreaName Where SASCode = '" & SASCode & "'")
    End Function
    Public Shared Function SalesAccountSpecialistChannelbyCustomerDelete(ByVal SASCode As String) As String
        Return ExecuteCommand("DELETE FROM SalesAccountSpecialistChannelbyCustomer Where SASCode = '" & SASCode & "'")
    End Function
    Public Shared Function SalesAccountSpecialistAlreadyExist(ByVal SASCode As String, ByVal ConfigtypeCode As String) As String
        Return ExecuteCommand("Select Distinct 'A' from  [dbo].[ProcessSalesAccountSpecialist] Where SalesAccountCode = '" & SASCode & "' AND ConfigtypeCode  = '" & ConfigtypeCode & "'") = "A"
    End Function
    Public Shared Function DeleteUpdate(ByVal SASCode As String, ByVal ConfigtypeCode As String) As String
        Return ExecuteCommand("DELETE FROM [ProcessSalesAccountSpecialist] Where SalesAccountCode = '" & SASCode & "' AND ConfigtypeCode  = '" & ConfigtypeCode & "'")
    End Function
End Class
Public Class SalesAccountSpecialistProcessCollection
    Inherits List(Of SalesAccountSpecialistProcess)
End Class