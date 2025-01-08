Imports System.Data.SqlClient
Public Class DistributorChannleGroup

    Private m_ID As Integer = -1

    Private m_ChannelCode As String = String.Empty

    Private m_ChannelGroupCode As String = String.Empty

    Private m_ChannelGroupDescription As String = String.Empty

    Private m_EffectivityStartDate As Date = "1/1/1990"

    Private m_EffectivityEndDate As Date = "1/1/1990"

    Public ReadOnly Property ID As Integer
        Get
            Return m_ID
        End Get
    End Property
    Public Property Channelcode As String
        Get
            Return m_ChannelCode
        End Get
        Set(value As String)
            m_ChannelCode = value
        End Set
    End Property
    Public Property ChannelgroupCode As String
        Get
            Return m_ChannelGroupCode
        End Get
        Set(value As String)
            m_ChannelGroupCode = value
        End Set
    End Property
    Public Property ChannelGroupDescription As String
        Get
            Return m_ChannelGroupDescription
        End Get
        Set(value As String)
            m_ChannelGroupDescription = value
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
    Public Property EffectivityEndDate As Date
        Get
            Return m_EffectivityEndDate
        End Get
        Set(value As Date)
            m_EffectivityEndDate = value
        End Set
    End Property
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspDistributorGroup", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.Parameters.AddWithValue("@DLTFLG", False)
            cmd.Parameters.AddWithValue("@ChannelCode", m_ChannelCode)
            cmd.Parameters.AddWithValue("@ChanneGroupCode", m_ChannelGroupCode)
            cmd.Parameters.AddWithValue("@ChannelGroupNAME", m_ChannelGroupDescription)
            cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", m_EFFECTIVITYSTARTDATE)
            cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", m_EFFECTIVITYENDDATE)
            m_ID = cmd.ExecuteScalar()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Function Update() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspDistributorGroup", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "UPDATE")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.Parameters.AddWithValue("@DLTFLG", False)
            cmd.Parameters.AddWithValue("@ChannelCode", m_ChannelCode)
            cmd.Parameters.AddWithValue("@ChanneGroupCode", m_ChannelGroupCode)
            cmd.Parameters.AddWithValue("@ChannelGroupNAME", m_ChannelGroupDescription)
            cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", m_EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", m_EffectivityEndDate)
            cmd.ExecuteNonQuery()
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
            Dim cmd As New SqlCommand("uspDistributorGroup", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Delete")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As DistributorChannelGroupCollection
        Dim col As New DistributorChannelGroupCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_DistributorGroup As New DistributorChannleGroup
            Dim row As DataRow = table.Rows(j)
            m_DistributorGroup.m_ID = row("ID")
            m_DistributorGroup.m_ChannelCode = row("DistributorCode")
            m_DistributorGroup.m_ChannelGroupCode = row("CHANNELGROUPCD")
            m_DistributorGroup.m_ChannelGroupDescription = row("CHANNELGROUPNAME")
            m_DistributorGroup.m_EffectivityStartDate = row("EFFECTIVITYSTARTDATE")
            m_DistributorGroup.m_EffectivityEndDate = row("EFFECTIVITYENDDATE")
            col.Add(m_DistributorGroup)
        Next
        Return col
    End Function
    Public Shared Function Filter(ByVal Condition As String) As DistributorChannelGroupCollection
        Return BaseFilter(GetRecords("SELECT * FROM DistributorGroup  WHERE DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As DistributorChannelGroupCollection
        Return Filter("")
    End Function

    Public Overloads Shared Function Load(ByVal ID As Integer) As DistributorChannleGroup
        Return Filter("ID = " & ID)(0)
    End Function

    Public Shared Function LoadByCode(ByVal ChannelgroupCode As String) As DistributorChannleGroup
        Return Filter("CHANNELGROUPCD = '" & RefineSQL(ChannelgroupCode) & "'")(0)
    End Function
    Public Shared Function CheckofDistributorGroupAlreadyExist(ByVal Code As String, CompanyCode As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM DistributorGroup WHERE DLTFLG = 0 AND  DistributorCode = '" & RefineSQL(CompanyCode) & "' And   CHANNELGROUPCD = '" & RefineSQL(Code) & "'") = "A"
    End Function
    Public Shared Function GetDistributorGroupSql(Optional ByVal CustomerGroup As String = "") As String
        Return "SELECT ID, DistributorCode [Company Code],CHANNELGROUPCD [Group Code], CHANNELGROUPNAME [Group Description] FROM DistributorGroup Where DLTFLG = 0 "
    End Function

    Public Shared Function GetDistributorGroupColumns() As String
        Return "ID; [Company Code];[Group Code];[Description];"
    End Function
End Class
Public Class DistributorChannelGroupCollection
    Inherits List(Of DistributorChannleGroup)
End Class
