Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class SalesMatrixCache

    Private dt As New DataTable
    Private dv As New DataView


    Private m_ItemDivision As String = String.Empty
    Private m_TerritoryCode As String = String.Empty
    Private m_TerritoryName As String = String.Empty
    Private m_SalesmanCode As String = String.Empty
    Private m_SalesmanName As String = String.Empty

    Private m_WithErr As Boolean = False
    Private m_EffectivityStartDate As Date = "1/1/1900"
    Private m_EffectivityEndDate As Date = "1/1/1900"

    Public Property WithErr() As Boolean
        Get
            Return m_WithErr
        End Get
        Set(ByVal value As Boolean)
            m_WithErr = value
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

    Public Property EffectivityStartDate() As Date
        Get
            Return m_EffectivityStartDate
        End Get
        Set(ByVal value As Date)
            m_EffectivityStartDate = value
        End Set
    End Property

    Public Property ItemDivision() As String
        Get
            Return m_ItemDivision
        End Get
        Set(ByVal value As String)
            m_ItemDivision = value
        End Set
    End Property

    Public Property TerritoryCode() As String
        Get
            Return m_TerritoryCode
        End Get
        Set(ByVal value As String)
            m_TerritoryCode = value
        End Set
    End Property

    Public Property TerritoryName() As String
        Get
            Return m_TerritoryName
        End Get
        Set(ByVal value As String)
            m_TerritoryName = value
        End Set
    End Property

    Public Property SalesmanCode() As String
        Get
            Return m_SalesmanCode
        End Get
        Set(ByVal value As String)
            m_SalesmanCode = value
        End Set
    End Property

    Public Property SalesmanName() As String
        Get
            Return m_SalesmanName
        End Get
        Set(ByVal value As String)
            m_SalesmanName = value
        End Set
    End Property

    Public Sub InitializedCache(ByVal ComID As String, ByVal FromDate As Date, ByVal ToDate As Date)
        dt = LoadDataTable(HandleSingleQuoteInSql(ComID), FromDate, ToDate)
        If dt.Rows.Count > 0 Then
            m_WithErr = True
        End If
    End Sub

    Private Function LoadDataTable(ByVal COMID As String, ByVal FromDate As Date, ByVal ToDate As Date) As DataTable

        Connect()
        Dim cmd As New SqlCommand("uspSalesTerritoryMappingAnalysis", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Action", "SalesMatrix")
        cmd.Parameters.AddWithValue("@COMID", COMID)
        cmd.Parameters.AddWithValue("@EffectivityStartDate", FromDate)
        cmd.Parameters.AddWithValue("@EffectivityEndDate", ToDate)

        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        Return dt
    End Function

    Private Function RefineFilter(ByVal Value As String) As String
        Value = Replace(Value, "[", "")
        Value = Replace(Value, "]", "")
        Return IIf(Value Is Nothing, "", Value)
    End Function

    Public Function FilterDv() As DataView

        dv = dt.DefaultView

        If dt.Rows.Count > 0 Then
            m_WithErr = True
        End If
        Dim m_Filter As String = String.Empty

        If m_ItemDivision <> "" Then
            m_Filter = "ItemDivision like '%" & HandleSingleQuoteInSql(RefineFilter(m_ItemDivision)) & "%' "
        End If
        If m_SalesmanCode <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "SalesmanCode like '%" & HandleSingleQuoteInSql(RefineFilter(m_SalesmanCode)) & "%' "
        End If
        If m_SalesmanName <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "SalesmanName like '%" & HandleSingleQuoteInSql(RefineFilter(m_SalesmanName)) & "%' "
        End If
        If m_TerritoryCode <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "TerritoryCode like '%" & HandleSingleQuoteInSql(RefineFilter(m_TerritoryCode)) & "%' "
        End If
        If m_TerritoryName <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "TerritoryName like '%" & HandleSingleQuoteInSql(RefineFilter(m_TerritoryName)) & "%' "
        End If

        If m_EffectivityStartDate <> "1/1/1900" And m_EffectivityEndDate <> "1/1/1900" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            'm_Filter &= "(EffectivityStartDate >= '" & HandleSingleQuoteInSql((m_EffectivityStartDate.ToShortDateString)) & "'   and  EffectivityEndDate <= '" & HandleSingleQuoteInSql((m_EffectivityEndDate.ToShortDateString)) & "' )"
            'm_Filter &= "(EffectivityStartDate >= '" & "04/01/2010" & "'   and  EffectivityEndDate <= '" & "04/30/2010" & "' )"
            m_Filter &= "(EffectivityStartDate >= '" & m_EffectivityStartDate.ToString("MM/dd/yyyy") & "'   and  EffectivityEndDate <= '" & m_EffectivityEndDate.ToString("MM/dd/yyyy") & "' )"
        End If

        dv.RowFilter = m_Filter
        Return dv
    End Function



End Class
