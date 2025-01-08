Imports System.Data.SqlClient
Imports SPMSOPCI.ConnectionModule
Public Class CustomerMappingOverlappingCache

    Private dt As DataTable
    Private dv As New DataView

    Private m_Channel As String = String.Empty
    Private m_CustomerCode As String = String.Empty
    Private m_ShipToCode As String = String.Empty
    Private m_ShipToName As String = String.Empty
    Private m_RegionCode As String = String.Empty
    Private m_Province As String = String.Empty
    Private m_Municipality As String = String.Empty
    Private m_Territory As String = String.Empty
    Private m_EffectivityStartDate As Date = "1/1/1900"
    Private m_EffectivityEndDate As Date = "1/1/1900"

    Private m_WithErr As Boolean = False

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

    Public Property Territory() As String
        Get
            Return m_Territory
        End Get
        Set(ByVal value As String)
            m_Territory = value
        End Set
    End Property
    Public Property Municipality() As String
        Get
            Return m_Municipality
        End Get
        Set(ByVal value As String)
            m_Municipality = value
        End Set
    End Property

    Public Property Province() As String
        Get
            Return m_Province
        End Get
        Set(ByVal value As String)
            m_Province = value
        End Set
    End Property

    Public Property RegionCode() As String
        Get
            Return m_RegionCode
        End Get
        Set(ByVal value As String)
            m_RegionCode = value
        End Set
    End Property
    Public Property ShipToName() As String
        Get
            Return m_ShipToName
        End Get
        Set(ByVal value As String)
            m_ShipToName = value
        End Set
    End Property

    Public Property Channel() As String
        Get
            Return m_Channel
        End Get
        Set(ByVal value As String)
            m_Channel = value
        End Set
    End Property

    Public Property CustomerCode() As String
        Get
            Return m_CustomerCode
        End Get
        Set(ByVal value As String)
            m_CustomerCode = value
        End Set
    End Property

    Public Property ShipToCode() As String
        Get
            Return m_ShipToCode
        End Get
        Set(ByVal value As String)
            m_ShipToCode = value
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
        cmd.Parameters.AddWithValue("@Action", "CustomerMapping")
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

        Dim m_Filter As String = String.Empty

        If m_Channel <> "" Then
            m_Filter = "Channel like '%" & HandleSingleQuoteInSql(RefineFilter(m_Channel)) & "%' "
        End If
        If m_CustomerCode <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "CustomerCode like '%" & HandleSingleQuoteInSql(RefineFilter(m_CustomerCode)) & "%' "
        End If
        If m_ShipToCode <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "ShipToCode like '%" & HandleSingleQuoteInSql(RefineFilter(m_ShipToCode)) & "%' "
        End If
        If m_ShipToName <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "ShipToName  like '%" & HandleSingleQuoteInSql(RefineFilter(m_ShipToName)) & "%' "
        End If
        If m_RegionCode <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "RegionCode like '%" & HandleSingleQuoteInSql(RefineFilter(m_RegionCode)) & "%' "
        End If
        If m_Province <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "ProvinceCode like '%" & HandleSingleQuoteInSql(RefineFilter(m_Province)) & "%' "
        End If
        If m_Municipality <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "MunicipalityCode like '%" & HandleSingleQuoteInSql(RefineFilter(m_Municipality)) & "%' "
        End If
        If m_Territory <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "TerritoryCode like '%" & HandleSingleQuoteInSql(RefineFilter(m_Territory)) & "%' "
        End If
        If m_EffectivityStartDate <> "1/1/1900" And m_EffectivityEndDate <> "1/1/1900" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "(EffectivityStartDate >= '" & HandleSingleQuoteInSql((m_EffectivityStartDate.ToShortDateString)) & "'   OR  EffectivityEndDate <= '" & HandleSingleQuoteInSql((m_EffectivityEndDate.ToShortDateString)) & "' )"
        End If
        'If m_EffectivityEndDate <> "1/1/1900" Then
        '    If m_Filter <> "" Then m_Filter &= " AND "
        '    m_Filter &= "EffectivityEndDate = '" & HandleSingleQuoteInSql((m_EffectivityEndDate.ToShortDateString)) & "' "
        'End If

        dv.RowFilter = m_Filter

        Return dv
    End Function

End Class
