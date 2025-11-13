Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Public Class ProductGroupEffectivity
    Private m_ID As Integer = -1

    Private m_ItemCode As String = String.Empty

    Private m_Code As String = String.Empty

    Private m_EffectivityStartDate As Date = "1/1/1900"

    Private m_EffectivityEndDate As Date = "1/1/1900"

    Private m_CongfigtypeCode As String = String.Empty

    Private m_IsDeleted As Boolean = False

    Public ReadOnly Property ID As Integer
        Get
            Return m_ID
        End Get
    End Property
    Public Property ItemCode As String
        Get
            Return m_ItemCode
        End Get
        Set(value As String)
            m_ItemCode = value
        End Set
    End Property
    Public Property Code As String
        Get
            Return m_Code
        End Get
        Set(value As String)
            m_Code = value
        End Set
    End Property

    Public Property EffectivityStartDate As Date
        Get
            Return m_EffectivityStartDate
        End Get
        Set(value As Date)
            m_EffectivityStartDate = value
        End Set
    End Property
    Public Property EffectivityEndDate As String
        Get
            Return m_EffectivityEndDate
        End Get
        Set(value As String)
            m_EffectivityEndDate = value
        End Set
    End Property

    Public Property ConfigtypeCode As String
        Get
            Return m_CongfigtypeCode
        End Get
        Set(value As String)
            m_CongfigtypeCode = value
        End Set
    End Property
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()

        Try
            Dim cmd As New SqlCommand("uspProductGroupEffectivity", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.Parameters.AddWithValue("@ItemCode", m_ItemCode)
            cmd.Parameters.AddWithValue("@Code", m_Code)
            cmd.Parameters.AddWithValue("@EffectivityStartDate", m_EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EffectivityEndDate", m_EffectivityEndDate)
            cmd.Parameters.AddWithValue("@ConfigtypeCode", m_CongfigtypeCode)
            cmd.Parameters.AddWithValue("@IsDeleted", m_IsDeleted)
            m_ID = cmd.ExecuteScalar
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
            Dim cmd As New SqlCommand("uspProductGroupEffectivity", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Delete")
            cmd.Parameters.AddWithValue("@ItemCode", m_ItemCode)
            cmd.Parameters.AddWithValue("@Code", m_Code)
            cmd.Parameters.AddWithValue("@EffectivityStartDate", m_EffectivityStartDate)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function

    Private Shared Function BaseFilter(ByVal dtItem As DataTable) As ProductGroupEffectivityCollection
        Dim col As New ProductGroupEffectivityCollection
        For m As Integer = 0 To dtItem.Rows.Count - 1
            Dim dr As DataRow = dtItem.Rows(m)
            Dim m_ProductGroupEffectivity As New ProductGroupEffectivity
            m_ProductGroupEffectivity.m_ID = dr("ID")
            m_ProductGroupEffectivity.m_ItemCode = dr("ItemCode")
            m_ProductGroupEffectivity.m_Code = dr("Code")
            m_ProductGroupEffectivity.m_EffectivityStartDate = dr("EffectivityStartDate")
            m_ProductGroupEffectivity.m_EffectivityEndDate = dr("EffectivityEndDate")
            m_ProductGroupEffectivity.m_CongfigtypeCode = dr("ConfigtypeCode")
            col.Add(m_ProductGroupEffectivity)
        Next
        Return col
    End Function
    Public Shared Function Filter(ByVal Condition As String) As ProductGroupEffectivityCollection
        Return BaseFilter(GetRecords("SELECT * FROM ProductGroupEffectivity  WHERE IsDeleted = 0" & IIf(Condition <> "", " AND " & Condition, "")))
    End Function
    Public Overloads Shared Function Load() As ProductGroupEffectivityCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As ProductGroupEffectivity
        Return Filter("ID = " & ID)(0)
    End Function
    Public Shared Function LoadByCode(ByVal Code As String) As ProductGroupEffectivity
        Return Filter("Code = '" & HandleSingleQuoteInSql(Code) & "'")(0)
    End Function
    Public Shared Function GetProductGroupSql(ByVal ItemCode As String) As String
        Return ("Select A.Code,B.PGDescription,A.EffectivityStartDate,A.EffectivityEndDate,A.ConfigtypeCode from [ProductGroupEffectivity] A Inner Join ProductItemGroup B ON A.Code = B.PGCode WHERE A.ItemCode = '" & ItemCode & "'")
    End Function
End Class
Public Class ProductGroupEffectivityCollection
    Inherits List(Of ProductGroupEffectivity)
End Class
