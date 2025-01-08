Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class Distributor

    Private m_DISTRIBUTORID As Integer = -1
    Private m_DISTCOMID As String = String.Empty
    Private m_DLTFLG As Boolean = False
    Private m_DISTNAME As String = String.Empty
    Private m_CUST As String = String.Empty
    Private m_ADDR As String = String.Empty
    Private m_CRTDATE As Date = "1/1/1900"
    Private m_CRTU As String = String.Empty
    Private m_UPDD As Date = "1/1/1900"
    Private m_UPDU As String = String.Empty
    Private m_EFFECTIVITYSTARTDATE As Date = "1/1/1900"
    Private m_EFFECTIVITYENDDATE As Date = "1/1/1900"
    Private m_IsActive As Boolean = False
    Private m_IsActiveVat As Boolean = False
    Private m_MunTax As Decimal = "0.00"
    Private m_DistMargin As Decimal = "0.00"

    Public ReadOnly Property DISTRIBUTORID() As Integer
        Get
            Return m_DISTRIBUTORID
        End Get
    End Property

    Public Property DISTCOMID() As String
        Get
            Return m_DISTCOMID
        End Get
        Set(ByVal value As String)
            m_DISTCOMID = value
        End Set
    End Property

    Public Property DLTFLG() As Boolean
        Get
            Return m_DLTFLG
        End Get
        Set(ByVal value As Boolean)
            m_DLTFLG = value
        End Set
    End Property

    Public Property DISTNAME() As String
        Get
            Return m_DISTNAME
        End Get
        Set(ByVal value As String)
            m_DISTNAME = value
        End Set
    End Property

    Public Property CUST() As String
        Get
            Return m_CUST
        End Get
        Set(ByVal value As String)
            m_CUST = value
        End Set
    End Property

    Public Property ADDR() As String
        Get
            Return m_ADDR
        End Get
        Set(ByVal value As String)
            m_ADDR = value
        End Set
    End Property

    Public Property CRTDATE() As Date
        Get
            Return m_CRTDATE
        End Get
        Set(ByVal value As Date)
            m_CRTDATE = value
        End Set
    End Property

    Public Property CRTU() As String
        Get
            Return m_CRTU
        End Get
        Set(ByVal value As String)
            m_CRTU = value
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

    Public Property UPDU() As String
        Get
            Return m_UPDU
        End Get
        Set(ByVal value As String)
            m_UPDU = value
        End Set
    End Property

    Public Property EFFECTIVITYSTARTDATE() As Date
        Get
            Return m_EFFECTIVITYSTARTDATE
        End Get
        Set(ByVal value As Date)
            m_EFFECTIVITYSTARTDATE = value
        End Set
    End Property

    Public Property EFFECTIVITYENDDATE() As Date
        Get
            Return m_EFFECTIVITYENDDATE
        End Get
        Set(ByVal value As Date)
            m_EFFECTIVITYENDDATE = value
        End Set
    End Property

    Public Property IsActive() As Boolean
        Get
            Return m_IsActive
        End Get
        Set(ByVal value As Boolean)
            m_IsActive = value
        End Set
    End Property

    Public Property IsActiveVat As Boolean
        Get
            Return m_IsActiveVat
        End Get
        Set(ByVal value As Boolean)
            m_IsActiveVat = value
        End Set
    End Property
    Public Property MunTax As Decimal
        Get
            Return m_MunTax
        End Get
        Set(value As Decimal)
            m_MunTax = value
        End Set
    End Property
    Public Property DistMargin As Decimal
        Get
            Return m_DistMargin
        End Get
        Set(value As Decimal)
            m_DistMargin = value
        End Set
    End Property
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspDISTRIBUTOR", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@DISTRIBUTORID", m_DISTRIBUTORID)
            cmd.Parameters.AddWithValue("@DISTCOMID", m_DISTCOMID)
            cmd.Parameters.AddWithValue("@DLTFLG", m_DLTFLG)
            cmd.Parameters.AddWithValue("@DISTNAME", m_DISTNAME)
            cmd.Parameters.AddWithValue("@CUST", m_CUST)
            cmd.Parameters.AddWithValue("@ADDR", m_ADDR)
            cmd.Parameters.AddWithValue("@CRTDATE", m_CRTDATE)
            cmd.Parameters.AddWithValue("@CRTU", m_CRTU)
            cmd.Parameters.AddWithValue("@UPDD", m_UPDD)
            cmd.Parameters.AddWithValue("@UPDU", m_UPDU)
            cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", m_EFFECTIVITYSTARTDATE)
            cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", m_EFFECTIVITYENDDATE)
            cmd.Parameters.AddWithValue("@IsActive", m_IsActive)
            cmd.Parameters.AddWithValue("@ISACTIVEVAT", m_IsActiveVat)
            cmd.Parameters.AddWithValue("@MunTax", m_MunTax)
            cmd.Parameters.AddWithValue("@DistMargin", m_DistMargin)
            m_DISTCOMID = cmd.ExecuteScalar()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function

    Public Function Delete() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspDISTRIBUTOR", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Delete")
            cmd.Parameters.AddWithValue("@DISTRIBUTORID", m_DISTRIBUTORID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function

    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As DistributorCollection
        Dim col As New DistributorCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_Distributor As New Distributor
            Dim row As DataRow = table.Rows(j)
            m_Distributor.m_DISTRIBUTORID = row("DISTRIBUTORID")
            m_Distributor.m_DISTCOMID = row("DISTCOMID")
            m_Distributor.m_DLTFLG = row("DLTFLG")
            m_Distributor.m_DISTNAME = row("DISTNAME")
            m_Distributor.m_CUST = row("CUST")
            m_Distributor.m_ADDR = row("ADDR")
            m_Distributor.m_CRTDATE = row("CRTDATE")
            m_Distributor.m_UPDD = row("UPDD")
            m_Distributor.m_CRTU = row("CRTU")
            m_Distributor.m_UPDU = row("UPDU")
            m_Distributor.m_IsActive = row("IsActive")
            m_Distributor.m_EFFECTIVITYSTARTDATE = row("EFFECTIVITYSTARTDATE")
            m_Distributor.m_EFFECTIVITYENDDATE = row("EFFECTIVITYENDDATE")
            m_Distributor.m_IsActiveVat = row("IsActiveVat")
            m_Distributor.m_MunTax = row("MunTax")
            m_Distributor.m_DistMargin = row("DistMargin")
            col.Add(m_Distributor)
        Next
        Return col
    End Function

    Public Shared Function Filter(ByVal Condition As String) As DistributorCollection
        Return BaseFilter(GetRecords("SELECT * FROM Distributor  WHERE DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function

    Public Overloads Shared Function Load() As DistributorCollection
        Return Filter("")
    End Function

    Public Overloads Shared Function Load(ByVal DISTRIBUTORID As Integer) As Distributor
        Return Filter("DISTRIBUTORID = " & DISTRIBUTORID)(0)
    End Function

    Public Shared Function LoadByCode(ByVal DISTCOMID As String) As Distributor
        Return Filter("DISTCOMID = '" & RefineSQL(DISTCOMID) & "'")(0)
    End Function
    Public Shared Function VatCalculated(ByVal CompanyCode) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM Distributor WHERE DLTFLG = 0  AND IsActiveVat = 1 AND  DISTCOMID = '" & RefineSQL(CompanyCode) & "'") = "A"
    End Function

    Public Shared Function CheckofDistributorAlreadyExist(ByVal Code As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM Distributor WHERE DLTFLG = 0  And  DISTCOMID = '" & RefineSQL(Code) & "' AND DISTRIBUTORID <> " & ID) = "A"
    End Function
    Public Shared Function GetDistributorSql(Optional ByVal CustomerGroup As String = "") As String
        Return "SELECT DISTRIBUTORID, DISTCOMID [Company Code], DISTNAME [Description] FROM DISTRIBUTOR Where DLTFLG = 0 "
    End Function

    Public Shared Function GetDistributorColumns() As String
        Return "DISTRIBUTORID; [Company Code]; [Description];"
    End Function
    Public Shared Function GetChannelSql() As String
        Return "SELECT DISTCOMID,DISTNAME FROM DISTRIBUTOR Where DLTFLG = 0 "
    End Function
    Public Shared Function GetDistributorDescription(ByVal CompanyCode As String) As String
        Return LoadByCode(CompanyCode).DISTNAME
    End Function
End Class

Public Class DistributorCollection

    Inherits List(Of Distributor)
End Class
