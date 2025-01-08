Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class CustomerMappingClassCache

    Private dt As New DataTable
    Private dv As New DataView

    Private m_ComID As String = String.Empty
    Private m_CustomerCD As String = String.Empty
    Private m_CdaCD As String = String.Empty
    Private m_CdaName As String = String.Empty
    Private m_RegCD As String = String.Empty
    Private m_DistrcdCd As String = String.Empty
    Private m_AreaCd As String = String.Empty
    Private m_ZipCd As String = String.Empty
    Private m_TransactionType As String = String.Empty
    Private m_EffectivityStartDate As Date = "1/1/1900"
    Private m_EffectivityEndDate As Date = "1/1/1900"
    Private m_WithErr As Boolean = False

    Private m_AreaCovRg As String = String.Empty

    Public Property AreaCovrg() As String
        Get
            Return m_AreaCovRg
        End Get
        Set(ByVal value As String)
            m_AreaCovRg = value
        End Set
    End Property

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

    Public Property TransactionType() As String
        Get
            Return m_TransactionType
        End Get
        Set(ByVal value As String)
            m_TransactionType = value
        End Set
    End Property

    Public Property ZipCd() As String
        Get
            Return m_ZipCd
        End Get
        Set(ByVal value As String)
            m_ZipCd = value
        End Set
    End Property

    Public Property AreaCd() As String
        Get
            Return m_AreaCd
        End Get
        Set(ByVal value As String)
            m_AreaCd = value
        End Set
    End Property

    Public Property DistrctCD() As String
        Get
            Return m_DistrcdCd
        End Get
        Set(ByVal value As String)
            m_DistrcdCd = value
        End Set
    End Property

    Public Property RegCd() As String
        Get
            Return m_RegCD
        End Get
        Set(ByVal value As String)
            m_RegCD = value
        End Set
    End Property

    Public Property CDACD() As String
        Get
            Return m_CdaCD
        End Get
        Set(ByVal value As String)
            m_CdaCD = value
        End Set
    End Property

    Public Property CustomerCd() As String
        Get
            Return m_CustomerCD
        End Get
        Set(ByVal value As String)
            m_CustomerCD = value
        End Set
    End Property

    Public Property ComID() As String
        Get
            Return m_ComID
        End Get
        Set(ByVal value As String)
            m_ComID = value
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
        cmd.Parameters.AddWithValue("@Action", "CustomerMappingType")
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

        If m_AreaCd <> "" Then
            m_Filter = "AreaCd like '%" & HandleSingleQuoteInSql(RefineFilter(m_AreaCd)) & "%' "
        End If
        If m_CdaCD <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "CdaCD like '%" & HandleSingleQuoteInSql(RefineFilter(m_CustomerCD)) & "%' "
        End If
        If m_CdaName <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "CdaName like '%" & HandleSingleQuoteInSql(RefineFilter(m_CdaName)) & "%' "
        End If
        If m_ComID <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "COMID like '%" & HandleSingleQuoteInSql(RefineFilter(m_ComID)) & "%' "
        End If
        If m_CustomerCD <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "CustomerCD like '%" & HandleSingleQuoteInSql(RefineFilter(m_CustomerCD)) & "%' "
        End If
        If m_DistrcdCd <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "DistrctCD like '%" & HandleSingleQuoteInSql(RefineFilter(m_DistrcdCd)) & "%' "
        End If
        If m_RegCD <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "RegCd like '%" & HandleSingleQuoteInSql(RefineFilter(m_RegCD)) & "%' "
        End If
        If m_AreaCovRg <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "AreaCovrg like '%" & HandleSingleQuoteInSql(RefineFilter(m_AreaCovRg)) & "%' "
        End If
        If m_TransactionType <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "TransactionType like '%" & HandleSingleQuoteInSql(RefineFilter(m_TransactionType)) & "%' "
        End If
        If m_ZipCd <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "ZipCd like '%" & HandleSingleQuoteInSql(RefineFilter(m_ZipCd)) & "%' "
        End If
        If m_EffectivityStartDate <> "1/1/1900" And m_EffectivityEndDate <> "1/1/1900" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "(EffectivityStartDate >= '" & HandleSingleQuoteInSql((m_EffectivityStartDate.ToShortDateString)) & "'   OR  EffectivityEndDate <= '" & HandleSingleQuoteInSql((m_EffectivityEndDate.ToShortDateString)) & "' )"
        End If
        dv.RowFilter = m_Filter

        Return dv
    End Function

End Class
