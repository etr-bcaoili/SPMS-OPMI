Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class STRegion
    Private m_ID As Integer = -1

    Private m_Code As String = String.Empty

    Private m_Description As String = String.Empty

    Private m_EffectivityStartDate As Date = "1/1/1990"

    Private m_EffectivityEndDate As Date = "1/1/1990"
    Public ReadOnly Property ID As Integer
        Get
            Return m_ID
        End Get
    End Property
    Public Property Code As String
        Get
            Return m_Code
        End Get
        Set(value As String)
            m_Code = value
        End Set
    End Property
    Public Property Description As String
        Get
            Return m_Description
        End Get
        Set(value As String)
            m_Description = value
        End Set
    End Property
    Public Property EffectivityStardDate As Date
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
        Connect()
        Try
            Dim cmd As New SqlCommand("uspSTRegion", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Save")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.Parameters.AddWithValue("@STREGCD", m_Code)
            cmd.Parameters.AddWithValue("@STREGNAME", m_Description)
            cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", m_EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", m_EffectivityEndDate)
            m_ID = cmd.ExecuteScalar
            Disconnect()
            Return True
        Catch ex As System.Exception
            Disconnect()
        End Try
    End Function
    Public Function Delete() As Boolean
        Connect()
        Try
            Dim cmd As New SqlCommand("uspSTRegion", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "DELETE")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.ExecuteNonQuery()
            Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As STRegionCollection
        Dim col As New STRegionCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_STRegion As New STRegion
            Dim row As DataRow = table.Rows(j)
            m_STRegion.m_ID = row("STRegionID")
            m_STRegion.m_Code = row("STREGCD")
            m_STRegion.m_Description = row("STREGNAME")
            m_STRegion.m_EffectivityStartDate = row("EffectivityStartDate")
            m_STRegion.m_EffectivityEndDate = row("EffectivityEndDate")
            col.Add(m_STRegion)
        Next
        Return col
    End Function
    Public Shared Function Filter(ByVal Condition As String) As STRegionCollection
        Return BaseFilter(GetRecords("Select * from STREGION  WHERE DLTFLG = 0" & IIf(Condition <> "", " AND " & Condition, "")))
    End Function
    Public Overloads Shared Function Load() As STRegionCollection
        Return Filter("")
    End Function

    Public Overloads Shared Function Load(ByVal ID As Integer) As STRegion
        Return Filter("STRegionID = " & ID)(0)
    End Function
    Public Shared Function LoadByCode(ByVal Pm_code As String) As STRegion
        Return Filter("STREGCD = '" & HandleSingleQuoteInSql(Pm_code) & "'")(0)
    End Function
    Public Shared Function CheckRegionIsAlreadyExist(ByVal RegionCode As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM STREGION Where DLTFLG = 0 AND STREGCD = '" & RefineSQL(RegionCode) & "' AND STRegionID <> " & ID) = "A"
    End Function
    Public Shared Function GetRegionsql() As String
        Return "Select STRegionID, STREGCD [Region Code], STREGNAME [Region Name] From STREGION"
    End Function
    Public Class STRegionCollection
        Inherits List(Of STRegion)
    End Class
End Class
