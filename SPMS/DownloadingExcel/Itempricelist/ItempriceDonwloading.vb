
Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class ItempriceDonwloading

    Private m_distid As Integer = -1

    Private m_CompanyCode As String = String.Empty

    Private m_itemcode As String = String.Empty

    Private m_citemcode As String = String.Empty

    Private m_itemname As String = String.Empty

    Private m_genericname As String = String.Empty

    Private m_itemdivision As String = String.Empty

    Private m_DISTITEMCD As Decimal = 0

    Private m_citemprice As Decimal = 0

    Private m_EffectivityStartDate As Date = "1/1/1900"

    Private m_EffectivityEndDate As Date = "1/1/1900"

    Public ReadOnly Property ItemID() As Integer
        Get
            Return m_distid
        End Get
    End Property
    Public Property CompanyCode() As String
        Get
            Return m_CompanyCode
        End Get
        Set(ByVal value As String)
            m_CompanyCode = value
        End Set
    End Property
    Public Property ItemCode() As String
        Get
            Return m_itemcode
        End Get
        Set(ByVal value As String)
            m_itemcode = value
        End Set
    End Property
    Public Property CompanyItyemCode() As String
        Get
            Return m_citemcode
        End Get
        Set(ByVal value As String)
            m_citemcode = value
        End Set
    End Property
    Public Property ItemName() As String
        Get
            Return m_itemname
        End Get
        Set(ByVal value As String)
            m_itemname = value
        End Set
    End Property

    Public Property genericname() As String
        Get
            Return m_genericname
        End Get
        Set(ByVal value As String)
            m_genericname = value
        End Set
    End Property
    Public Property ItemDivision() As String
        Get
            Return m_itemdivision
        End Get
        Set(ByVal value As String)
            m_genericname = value
        End Set
    End Property
    Public Property CompanyItemprice() As Decimal
        Get
            Return m_citemprice
        End Get
        Set(ByVal value As Decimal)
            m_citemprice = value
        End Set
    End Property
    Public Property DISTITEMCD() As Decimal
        Get
            Return m_DISTITEMCD
        End Get
        Set(ByVal value As Decimal)
            m_DISTITEMCD = value
        End Set
    End Property
    Public Property EffectivityStartDate() As Date
        Get
            Return m_EffectivityStartDate
        End Get
        Set(ByVal value As Date)
            m_EffectivityStartDate = value
        End Set
    End Property

    Public Property EffectivityEndDate() As Date
        Get
            Return m_EffectivityEndDate
        End Get
        Set(ByVal value As Date)
            m_EffectivityEndDate = value
        End Set
    End Property
    Public Function Save() As Boolean
        Connect()
        Try
            Dim cmd As New SqlCommand("uspDistributorItemPrice", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Save")
            cmd.Parameters.AddWithValue("@DISTID", m_distid)
            cmd.Parameters.AddWithValue("@CompanyCode", m_CompanyCode)
            cmd.Parameters.AddWithValue("@ITEMCODE", m_itemcode)
            cmd.Parameters.AddWithValue("@COMPANYITEMCODE", m_citemcode)
            cmd.Parameters.AddWithValue("@ITEMNAME", m_itemname)
            cmd.Parameters.AddWithValue("@ITEMDIVISION", m_itemdivision)
            cmd.Parameters.AddWithValue("@COMPANYPRICE", m_citemprice)
            cmd.Parameters.AddWithValue("@GENERICNAME", m_genericname)
            cmd.Parameters.AddWithValue("@ITEMNAME", m_itemname)
            cmd.Parameters.AddWithValue("@EffectivityStartDate", m_EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EffectivityEndDate", m_EffectivityEndDate)
            
            m_distid = cmd.ExecuteScalar()
            Disconnect()
            Return True
        Catch ex As System.Exception
            Disconnect()
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As ItempriceDonwloadingCollection
        ' Return BaseFilter(GetRecords("SELECT * FROM DISTRIBUTORITEMS  " & IIf(Condition <> "", " WHERE " & Condition, "")))
    End Function

    Public Overloads Shared Function Load() As ItempriceDonwloadingCollection
        Return Filter("")
    End Function

    Public Overloads Shared Function Load(ByVal RawDataID As Integer) As ItempriceDonwloading
        Return Filter("DISTID = " & RawDataID)(0)
    End Function

    Public Shared Function CheckIfRawDataExist(ByVal CompanyCode As String, ByVal Year As String, ByVal Month As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM DISTRIBUTORITEMS  Where Comid = '" & CompanyCode & "'") = "A"
    End Function
End Class
Public Class ItempriceDonwloadingCollection
    Inherits List(Of ItempriceDonwloading)
End Class
